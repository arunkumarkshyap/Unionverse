
Partial Class GroupType4
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Me.GroupType4Regis1.LoadData()
        End If
    End Sub
End Class
