Imports System.IO
Imports UserLibrary
Imports System.Web.Services
Imports System.Web.Script.Services
Imports AjaxControlToolkit

Partial Class AddEditAlbum
    Inherits System.Web.UI.Page
    Public ReadOnly Property UserID As Integer
        Get
            If Not IsNothing(Request.Item("uid")) AndAlso IsNumeric(Request.Item("uid")) Then
                Return CInt(Request.Item("uid"))
            Else
                Return 0
            End If
        End Get
    End Property
    Public ReadOnly Property CurrentUser As Users
        Get
            If Not IsNothing(Session("Users")) Then
                Return CType(Session("Users"), Users)
            Else
                Return New Users
            End If
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim oU As New Users(UserID)

    End Sub

    'Protected Sub lbtBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtBack.Click
    '    Dim oU As New Users(UserID)
    '    If Not oU Is Nothing And oU.UserID > 0 Then
    '        Response.Redirect("~/members/" & oU.Username & "/viewalbums.aspx")
    '    End If
    'End Sub
End Class
