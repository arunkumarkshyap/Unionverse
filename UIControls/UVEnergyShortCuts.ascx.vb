Imports UserLibrary
Imports CommonLibrary

Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.UI



Partial Class UIControls_UVEnergyShortCuts
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim _IsAdmin As Boolean = False
           If CType(Session("Users"), Users).UserTypeID = 0 Then
            _IsAdmin = True
        End If
        Me.phUserAdmin.Visible = False
        Me.phUsers.Visible = False

        If _IsAdmin Then
            Me.phUserAdmin.Visible = True
        Else
            Me.phUsers.Visible = True
        End If
    End Sub
End Class
