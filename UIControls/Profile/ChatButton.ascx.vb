Imports System
Imports System.Web.UI
Imports System.Web.Security

Imports UserLibrary

Partial Class UIControls_Profile_ChatButton
    Inherits System.Web.UI.UserControl
    Public ReadOnly Property UserID() As Integer
        Get
            If Not IsNothing(Request.Item("uid")) AndAlso IsNumeric(Request.Item("uid")) Then
                Return CInt(Request.Item("uid"))
            Else
                Return 0
            End If
        End Get
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If UserID <> CurrentUser.UserID Then
                Dim siteContextUser As New Users(UserID)
                Me.phSendFeedBack.Visible = True
            Else
                Me.phSendFeedBack.Visible = False
            End If
        End If
    End Sub

    Function GetChatURL() As String
        If UserID <> CurrentUser.UserID Then
            Dim siteContextUser As New Users(UserID)
            Return UIHelper.GetUnionVerseBasePathURL() & "/Members/" & siteContextUser.Username & "/Chat.aspx?UserName=" & CurrentUser.Username.ToString
        Else
            Return ""
        End If

    End Function

    Public ReadOnly Property CurrentUser As Users
        Get
            If Not IsNothing(Session("Users")) Then
                Return CType(Session("Users"), Users)
            Else
                Return New Users
            End If
        End Get
    End Property
End Class
