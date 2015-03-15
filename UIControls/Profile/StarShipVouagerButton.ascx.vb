Imports System
Imports System.Web.UI
Imports System.Web.Security
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports UserLibrary



Partial Class UIControls_Profile_StarShipVouagerButton
    Inherits System.Web.UI.UserControl
    Public ReadOnly Property UserName() As String
        Get
            Return Request.Item("UserName")
        End Get

    End Property

    Public ReadOnly Property UserID() As Integer
        Get
            If Not IsNothing(Request.Item("uid")) AndAlso IsNumeric(Request.Item("uid")) Then
                Return CInt(Request.Item("uid"))
            Else
                Return 0
            End If
        End Get
    End Property
    Public Function GetUser() As Users
        Dim ui As New Users

        If (UserID > 0) Then
            ui = New Users(UserID)
        End If
        If Not IsNothing(ui) AndAlso ui.UserID > 0 Then
            Return ui
        Else
            Return New Users
        End If
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadData()
        End If
    End Sub
    Public Sub LoadData()
        If Not IsNothing(GetUser) AndAlso Not IsNothing(CurrentUser) Then
            If GetUser.UserID <> CurrentUser.UserID Then
                Dim oSV As New smt_StarShipVoyager
                oSV.LoadByEmployeeUserIDGroupTypeUserID(IIf(CurrentUser.UserID = Nothing, 0, CurrentUser.UserID), IIf(GetUser.UserID = Nothing, 0, GetUser.UserID))
                If IsNothing(oSV) Then
                    Me.lbtStarShipVoyager.Visible = True
                    Me.spnStarship.Visible = True
                    Me.lbtDelete.Visible = False
                    Dim oIU1 As New smt_IndividualUserType1     '----------- For Individual User Type 1
                    oIU1.LoadByUserID(CurrentUser.UserID)
                    If Not IsNothing(oIU1) AndAlso oIU1.IndividualUserType1ID > 0 Then
                        Me.lbtStarShipVoyager.Visible = False
                        'Me.spnStarship.Visible = False
                        lbtDelete.Visible = True
                        Exit Sub
                    End If
                    Dim oIU2 As New smt_IndividualUserType2     '----------- For Individual User Type 2
                    oIU2.LoadByUserID(CurrentUser.UserID)
                    If Not IsNothing(oIU2) AndAlso oIU2.IndividualUserType2ID > 0 Then
                        Me.lbtStarShipVoyager.Visible = False
                        'Me.spnStarship.Visible = False
                        Me.lbtDelete.Visible = True
                        Exit Sub
                    End If
                Else
                    Me.lbtStarShipVoyager.Visible = True
                    Me.spnStarship.Visible = True
                    Me.lbtDelete.Visible = False
                End If
            Else
                Me.lbtStarShipVoyager.Visible = False
                Me.spnStarship.Visible = False
                Me.lbtDelete.Visible = False
            End If
        Else
            Me.lbtStarShipVoyager.Visible = False
            Me.spnStarship.Visible = False
        End If
    End Sub
    Protected Sub lbtStarShipVoyager_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtStarShipVoyager.Click
        Dim oU As New Users(GetUser.UserID)
        ' Response.Write("EmployeerID = " & oU.Username & "<br />")
        If Not IsNothing(oU) Then
            Dim oUT1 As New smt_UserType1
            If CurrentUser.UserTypeID = CommonLibrary.Utility.eUserTypes.IndividualType1 Then
                Dim oI1 As New smt_IndividualUserType1
                oI1.LoadByUserID(CurrentUser.UserID)
                If Not IsNothing(oI1) Then
                    ' Response.Write("userID = " & oI1.UserID & "<br />")
                    oUT1 = New smt_UserType1(oI1.GroupTypeID)
                End If
            ElseIf CurrentUser.UserTypeID = CommonLibrary.Utility.eUserTypes.IndividualType2 Then
                Dim oI2 As New smt_IndividualUserType2
                oI2.LoadByUserID(CurrentUser.UserID)
                oUT1 = New smt_UserType1(oI2.GroupTypeID)
                ' Response.Write("user 2 ID = " & oI2.UserID & "<br />")
            End If

            '  oUT1.LoadByUserID(CMSContext.CurrentUser.UserID)

            If Not IsNothing(oUT1) AndAlso oUT1.UserType1ID > 0 Then

                ' Response.Write("User Group Type 1 ID = " & oUT1.UserType1ID & "<br />")

                Dim oSV As New smt_StarShipVoyager

                oSV.EmployeeUserID = CurrentUser.UserID
                oSV.GroupTypeUserID = oU.UserID
                oSV.GroupID = oUT1.UserType1ID
                oSV.IsApproved = False
                oSV.DeleteByEmployeeUserIDGroupTypeUserID(oSV.EmployeeUserID, oSV.GroupTypeUserID)
                oSV.StarShipVoyagerGUID = Guid.NewGuid()
                oSV.save()


                'Dim cmsEmail As New EmailInfo
                'cmsEmail.EmailFrom = oE.UserName & "<" & oE.Email & ">"
                'cmsEmail.EmailTo = oU.UserName & "<" & oU.Email & ">"
                'cmsEmail.EmailSubject = oE.UserName & " wants to be an Employee"
                'cmsEmail.EmailBody = "<p>" + oE.UserName + " wants to be an Employee</p>" + "<p>To Accpet or Reject the Connection request please follow.</p><p><b><a href='" + SMTUIHelper.GetBasePathURL() + "/Special-pages/ManageStarShip.aspx?SVGUID=" + oSV.StarShipVoyagerGUID.ToString() + "'>Accept / Reject</a></b><br /></p>"
                'cmsEmail.EmailFormat = EmailFormatEnum.Html
                'cmsEmail.EmailPriority = EmailPriorityEnum.Normal
                'cmsEmail.EmailSiteID = 1
                'cmsEmail.EmailStatus = EmailStatusEnum.Waiting

                'EmailInfoProvider.SetEmailInfo(cmsEmail)


                'Dim oM As New CMS.Messaging.MessageInfo

                'oM.MessageSenderUserID = oE.UserID
                'oM.MessageSenderNickName = oE.UserName
                'oM.MessageRecipientUserID = oU.UserID
                'oM.MessageRecipientNickName = oU.UserName
                'oM.MessageSent = DateTime.Now
                'oM.MessageLastModified = oM.MessageSent
                'oM.MessageSubject = oE.UserName & " wants to be an Employee"

                'oM.MessageBody = oE.UserName & " wants to be an Employee" & vbCrLf & "To Accpet or Reject the Connection request please follow." & vbCrLf & "[url=" + SMTUIHelper.GetBasePathURL() + "/Special-pages/ManageStarShip.aspx?SVGUID=" + oSV.StarShipVoyagerGUID.ToString() + "]Accept / Reject[/url]" & vbCrLf
                'cmsEmail.EmailBody = oE.UserName & " wants to be an Employee" & vbCrLf & "To Accpet or Reject the Connection request please follow." & vbCrLf & "<a href='" + SMTUIHelper.GetBasePathURL() + "/Special-pages/ManageStarShip.aspx?SVGUID=" + oSV.StarShipVoyagerGUID.ToString() + "'>Accept / Reject</a>" & vbCrLf
                'CMS.Messaging.MessageInfoProvider.SetMessageInfo(oM)

                LoadData()
            End If
        End If
    End Sub
    Public ReadOnly Property CurrentUser As Users
        Get
            If Not IsNothing(Session("Users")) Then
                Return CType(Session("Users"), Users)
            Else
                Return New Users
            End If
        End Get
    End Property

    Protected Sub lbtDelete_Click(sender As Object, e As EventArgs) Handles lbtDelete.Click
        ' Response.Write("EmployeerID = " & oU.Username & "<br />")
        Dim oU As New Users(GetUser.UserID)
        If Not IsNothing(oU) Then
            Dim oUT1 As New smt_UserType1
            If CurrentUser.UserTypeID = CommonLibrary.Utility.eUserTypes.IndividualType1 Then
                Dim oI1 As New smt_IndividualUserType1
                oI1.LoadByUserID(CurrentUser.UserID)
                If Not IsNothing(oI1) Then
                    ' Response.Write("userID = " & oI1.UserID & "<br />")
                    oUT1 = New smt_UserType1(oI1.GroupTypeID)
                End If
            ElseIf CurrentUser.UserTypeID = CommonLibrary.Utility.eUserTypes.IndividualType2 Then
                Dim oI2 As New smt_IndividualUserType2
                oI2.LoadByUserID(CurrentUser.UserID)
                oUT1 = New smt_UserType1(oI2.GroupTypeID)
                ' Response.Write("user 2 ID = " & oI2.UserID & "<br />")
            End If

            '  oUT1.LoadByUserID(CMSContext.CurrentUser.UserID)

            If Not IsNothing(oUT1) AndAlso oUT1.UserType1ID > 0 Then
                Dim oSV As New smt_StarShipVoyager

                oSV.DeleteByEmployeeUserIDGroupTypeUserID(oSV.EmployeeUserID, oSV.GroupTypeUserID)
                LoadData()
            End If
        End If
    End Sub
End Class
