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


Partial Class CMSWebParts_Membership_ChatMessages
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

    Public Sub LoadData()
        Dim oUser As New Users
        oUser = CurrentUser
        Dim oFriend As New Users
        If Not IsNothing(oUser) AndAlso oUser.UserID > 0 Then
            Dim Arl As New ArrayList
            Dim oChat As New smt_Chat
            Arl = oChat.ChatGetUnreadMessages(CurrentUser.UserGUID)

            If Arl.Count > 0 Then
                Me.spnMessages.InnerHtml = "Chat Messages (" & Arl.Count & ")"
                Me.spnUsers.InnerHtml = GetHTML(Arl)
                Me.phContents.Visible = True
            Else
                Me.spnMessages.InnerHtml = "Chat Messages (0)"
                Me.spnUsers.InnerHtml = " no unread message."
                Me.phContents.Visible = False
            End If
        End If
    End Sub
    Public Function GetHTML(ByVal Arl As ArrayList) As String
        Dim str As String = ""
        If Arl.Count > 0 Then
            For Each oChat As smt_Chat In Arl
                str = str & GetUserLink(oChat.FriendGUID)
            Next
        End If
        Return str
    End Function
    Public Function GetUserLink(ByVal UserGUID As Guid) As String
        Dim oU As New Users
        oU = CurrentUser
        If Not IsNothing(oU) Then
            Return "<li><a href=""" & UIHelper.GetUnionVerseBasePathURL & "/Members/" & oU.UserName & "/Chat.aspx?FriendGUID=" & oU.UserGUID.ToString & """>" & oU.UserName & "</a></li>"
        Else
            Return ""
        End If
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadData()
        End If
    End Sub

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LoadData()
    End Sub
End Class
