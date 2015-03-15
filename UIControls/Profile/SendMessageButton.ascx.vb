Imports System
Imports System.Web.UI
Imports System.Web.Security

Imports UserLibrary

Partial Class UIControls_Profile_SendMessageButton
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not IsNothing(CurrentUser) AndAlso Not IsNothing(CurrentUser) Then
           
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


End Class
