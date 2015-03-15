Imports System
Imports System.Web.UI
Imports System.Web.Security


Imports UserLibrary


Partial Class UIControls_Chat_ChatButton
    Inherits System.Web.UI.UserControl
    Public Property UserID As Integer
        Get
            If Not IsNothing(Request.Item("uid")) AndAlso IsNumeric(Request.Item("uid")) Then
                Return CInt(Request.Item("uid"))
            ElseIf Not IsNothing(ViewState("UserID")) AndAlso IsNumeric(ViewState("UserID")) Then
                Return CInt(ViewState("UserID"))
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            ViewState("UserID") = value
        End Set
    End Property
    Public ReadOnly Property CurrentUser As Users
        Get
            If Not IsNothing(Session("Users")) AndAlso CType(Session("Users"), Users).UserID > 0 Then
                Return CType(Session("Users"), Users)
            Else
                Return New Users
            End If
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If CurrentUser.UserID <> 0 AndAlso Not UserID <> 0 Then
                If CurrentUser.UserID <> UserID Then
                    Me.phSendFeedBack.Visible = True
                Else
                    Me.phSendFeedBack.Visible = False
                End If
            End If
        End If
    End Sub

    Function GetChatURL() As String
        If CurrentUser.UserID <> 0 AndAlso UserID <> 0 Then
            Dim oU As New Users(UserID)
            If CurrentUser.UserID <> UserID Then
                Return UIHelper.GetUnionVerseBasePathURL() & "/Members/" & CurrentUser.Username & "/Chat.aspx?FriendGUID=" & oU.UserGUID.ToString
            Else
                Return ""
            End If
        Else
            Return ""
        End If
    End Function
End Class
