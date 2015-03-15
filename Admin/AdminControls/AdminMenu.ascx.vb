Imports AdminLibrary
Partial Class AdminMenu
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not IsNothing(Session("Administrator")) Then
                Dim oAdmin As New Administrators
                oAdmin = CType(Session("Administrator"), Administrators)
                If oAdmin.AdRoleID = 2 Then
                    plhAdmin.visible = False
                Else
                    plhAdmin.visible = True
                End If
            End If
        End If
    End Sub
End Class
