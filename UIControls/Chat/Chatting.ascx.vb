Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Imports UserLibrary
Imports CommonLibrary

Partial Class UIControls_Chat_Chatting
    Inherits System.Web.UI.UserControl

    Public ReadOnly Property CurrentUser() As Users
        Get
            If Not IsNothing(Session("Users")) AndAlso CType(Session("Users"), Users).UserID > 0 Then
                Return CType(Session("Users"), Users)
            Else
                Return New Users
            End If
        End Get
    End Property

    Public ReadOnly Property FriendGUID() As Guid
        Get
            If Not IsNothing(Request.Item("FriendGUID")) AndAlso CStr(Request.Item("FriendGUID")).Trim.Length > 0 Then
                Return New Guid(CStr(Request.Item("FriendGUID")))
            Else
                Return Guid.NewGuid
            End If
        End Get
    End Property
    Public Property MaxChatID() As Integer
        Get
            If Not IsNothing(ViewState("MaxChatID")) AndAlso IsNumeric(ViewState("MaxChatID")) Then
                Return CInt(ViewState("MaxChatID"))
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("MaxChatID") = value
        End Set
    End Property

    Public Sub LoadData()
        Dim oUser As New Users
        Dim oFriend As New Users
        oUser = CurrentUser
        oFriend.LoadUserByGUID(FriendGUID.ToString)
        If oFriend.UserTypeID = CommonLibrary.Utility.eUserTypes.UserType1 AndAlso oFriend.UserTypeID = CommonLibrary.Utility.eUserTypes.BusinessUser Then
            Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/Forbidden.aspx")
        End If

        If oFriend.UserTypeID = 0 AndAlso UIHelper.IsInd1or2(oUser.UserID) Then  ' 0 means admin
            pAdmin.Visible = True
        Else
            pAdmin.Visible = False
        End If

        Me.txtMessage.Enabled = False
        Me.btn_Send.Enabled = False
        Me.pOnline.InnerHtml = "<small><i>( offline )</i></small>"
        If Not IsNothing(oUser) AndAlso oUser.UserID > 0 AndAlso Not IsNothing(oFriend) AndAlso oFriend.UserID > 0 Then
            Me.spnUserName.InnerHtml = oFriend.UserName
            Me.imgProfile.Src = GetUserImage(oFriend.UserGUID)
            If UIHelper.IsUserOnline(oFriend.UserID) Then
                Me.txtMessage.Enabled = True
                Me.btn_Send.Enabled = True
                Me.pOnline.InnerHtml = "<small><i>( online )</i></small>"
            End If
            Dim Arl As New ArrayList
            Dim oChat As New smt_Chat
            oChat.SortColum = "ChatID"
            oChat.SortDirection = " ASC "
            oChat.ChatUpdateIsRead(CurrentUser.UserGUID, FriendGUID)
            Arl = oChat.GetByFillter(0, 0, CurrentUser.UserGUID.ToString, FriendGUID.ToString, MaxChatID)
            If Arl.Count > 0 Then
                divChat.InnerHtml = GetHTML(Arl)
                Me.divChat.Focus()
                Dim script As String = ""
                script = "scroll();" & vbLf
                ScriptManager.RegisterStartupScript(Me, GetType(String), "Scroll", script, True)
                ScriptManager.RegisterStartupScript(Me.UpdatePanel1, Me.UpdatePanel1.GetType(), "CloseWindow", script, True)
                '               Me.divChat.ScrollToCaret()
            Else
                divChat.InnerHtml = ""
            End If
        End If
    End Sub
    Public Function GetHTML(ByVal Arl As ArrayList) As String
        Dim str As String = ""
        If Arl.Count > 0 Then
            For Each oChat As smt_Chat In Arl
                'If oChat.ChatID > MaxChatID Then
                'MaxChatID = oChat.ChatID
                'End If
                If oChat.IsSent Then
                    str = str & "<p class='msgsent'>" & oChat.Message & "<br /><small><b><i>Sent: " & oChat.MessageDate.ToString & "</i></b></small></p>"
                Else
                    str = str & "<p class='msgrec'>" & oChat.Message & "<br /><small><b><i>Received: " & oChat.MessageDate.ToString & "</i></b></small></p>"
                End If
            Next
        End If
        Return str
    End Function
    Public Function GetUserImage(ByVal UGUID As Guid) As String
        If UGUID.ToString.Trim.Length > 0 Then
            Dim _u1 As New Users
            _u1.LoadUserByGUID(UGUID.ToString)

            Dim _user As New Users
            _user.LoadUserByGUID(_u1.UserGUID.ToString)


            Dim oUT4 As New smt_GroupType4
            oUT4.LoadByUserID(_user.UserID)
            If Not IsNothing(oUT4) AndAlso oUT4.GroupType4ID > 0 Then
                Dim oUI As New Users(_user.UserID)
                If Not IsNothing(oUI) AndAlso oUI.UserID > 0 Then
                    Return UIHelper.GetWhiteWholesPathURL & GetProfileImage(oUI.UserID)
                Else
                    Return ""
                End If
            Else
                Dim ou As New Users
                ou.LoadUserByGUID(_user.UserGUID.ToString)
                If Not IsNothing(ou) Then
                    Dim oUU As New Users(ou.UserID)
                    If Not IsNothing(oUU) Then
                        Return UIHelper.GetUnionVerseBasePathURL & GetProfileImage(oUU.UserID) ' SMTUIHelper.GetBasePathURL() & "/CMSModules/Avatars/CMSPages/GetAvatar.aspx?avatarguid=" & oA.AvatarGUID.ToString.Trim()
                    Else
                        Return ""
                    End If
                Else
                    Return ""
                End If
            End If
        Else
            Return ""
        End If
    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            MaxChatID = 0
            LoadData()

            'Dim script As String = "function displayRequest_" & ClientID & "(){ " & vbLf & "modalDialog('" & ResolveUrl("~/CMSModules/Friends/CMSPages/Friends_Request.aspx") & "?userid=" & CMSContext.CurrentUser.UserID & "&requestid= " & UserID & "' ,'requestFriend', 480, 350); " & vbLf & "} " & vbLf
            'ScriptHelper.RegisterStartupScript(Me, [GetType](), "displayModalRequest_" & ClientID, ScriptHelper.GetScript(script))
            'ScriptHelper.RegisterDialogScript(Me.Page)
            'hlAddFriend.Attributes.Add("onclick", "javascript:displayRequest_" & ClientID & "();")
            'hlAddFriend.Style.Add("cursor", "pointer")
            'hlAddFriend.Text = "Add as Connection"
        End If
    End Sub
    Public Function GetProfileImage(ByVal UserID As Integer) As String
        Dim oU As New Users(UserID)
        If Not IsNothing(oU) AndAlso oU.UserID > 0 Then

            If oU.ProfileImage.Trim.Length > 0 Then
                Return "/" & oU.ProfileImage.Trim
            Else
                Return "/UserFiles/Profiles/Profile-Pic-Man.png"
            End If
        Else
            Return "/UserFiles/Profiles/Profile-Pic-Man.png"
        End If
    End Function

    Protected Sub btn_Send_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Send.Click
        If IsValidate() Then
            Dim oUser As New Users
            Dim oFriend As New Users
            oUser = CurrentUser
            oFriend.LoadUserByGUID(FriendGUID.ToString)
            If Not IsNothing(oUser) AndAlso oUser.UserID > 0 AndAlso Not IsNothing(oFriend) AndAlso oFriend.UserID > 0 Then
                Dim oChat As New smt_Chat
                oChat.ChatID = 0
                oChat.UserGUID = CurrentUser.UserGUID
                oChat.FriendGUID = FriendGUID
                oChat.MessageDate = DateTime.Now
                oChat.Message = Me.txtMessage.Text.Trim
                oChat.IsRead = True
                oChat.IsSent = True
                oChat.save()

                oChat.FriendGUID = CurrentUser.UserGUID
                oChat.UserGUID = FriendGUID
                oChat.ChatID = 0
                oChat.IsRead = False
                oChat.IsSent = False
                oChat.save()
                Me.txtMessage.Text = ""
            End If
            LoadData()
        End If
    End Sub
    Public Function IsValidate() As Boolean
        If Me.txtMessage.Text.Trim.Length <= 0 Then
            Return False
        End If
        Return True
    End Function

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LoadData()
    End Sub
End Class
