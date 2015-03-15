
Partial Class Registration_Type
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Session("Users") = Nothing

        End If
    End Sub
End Class
