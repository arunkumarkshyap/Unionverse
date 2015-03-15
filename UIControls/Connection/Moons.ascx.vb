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


Partial Class UIControls_Moons
    Inherits System.Web.UI.UserControl

    Public Property UserID() As Integer
        Get
            If Not IsNothing(ViewState("UserID")) AndAlso IsNumeric(ViewState("UserID")) Then
                Return CInt(ViewState("UserID"))
            Else
                If Not IsNothing(Request.Item("uid")) AndAlso IsNumeric(Request.Item("uid")) Then
                    Return CInt(Request.Item("uid"))
                Else
                    Return 0
                End If
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("UserID") = value
        End Set
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
    Public Sub LoadData()
        Dim oFriend As New Friends
        Dim Arl As New ArrayList
        Arl = oFriend.GetApprovedMoonsList(GetUser.UserID)
        If Not IsNothing(Arl) AndAlso Arl.Count > 0 Then
            Me.rpPlanets.DataSource = Arl
            Me.rpPlanets.DataBind()
            Me.lblNoRecord.Visible = False
            Me.rpPlanets.Visible = True
        Else
            Me.rpPlanets.DataSource = New ArrayList
            Me.rpPlanets.DataBind()
            Me.lblNoRecord.Visible = True
            Me.rpPlanets.Visible = False
        End If
    End Sub


    Public Function GetUserHTML(ByVal FriendRequestedUserID As Integer, ByVal FriendUserID As Integer) As String
        Dim str As String = ""
        Dim _UserID As Integer = 0
        If FriendRequestedUserID <> UserID Then
            _UserID = FriendRequestedUserID
        ElseIf FriendUserID <> UserID Then
            UserID = FriendUserID
        End If
        If _UserID > 0 Then
            Dim oUI As New Users(_UserID)
            If Not IsNothing(oUI) Then
                If Not IsNothing(oUI) AndAlso oUI.UserID > 0 Then
                    str = "<span class='pbox_itm_img'><img src='" & GetUserImage(oUI.UserID) & "'/></span> <span class='pbox_inf'><a href='" & UIHelper.GetUnionVerseBasePathURL() & "/Members/" & oUI.Username.Trim & ".aspx'>" & oUI.Username & "</a></span>"
                Else
                    Return ""
                End If
            End If
        Else
            Return ""
        End If

        Return str
    End Function

    Public Function GetUserImage(ByVal UserID As Integer) As String
        Return UIHelper.GetUserImage(UserID)
    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadData()
    End Sub
End Class
