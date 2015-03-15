Imports AdminLibrary
Partial Class Admin
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session("Administrator")) AndAlso CType(Session("Administrator"), Administrators).AdministratorID > 0 Then
            Me.lblUserName.Text = CType(Session("Administrator"), Administrators).Name
        Else
            Response.Redirect(UIHelper.GetBasePath & "/AdminLogin/Login.aspx")
        End If
    End Sub

    Protected Sub lbtLogOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtLogOut.Click
        FormsAuthentication.SignOut()
        Session("Administrator") = Nothing
        Response.Redirect(UIHelper.GetBasePath & "/AdminLogin/Login.aspx")
    End Sub
End Class

