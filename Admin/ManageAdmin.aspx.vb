Imports CMSLibrary
Partial Class Admin_ManageAdmin
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.AdministratorsAddEdit.Visible = False
            Me.AdministratorsList.Visible = True
            Me.AdministratorsList.Bind_Datagrid()
        End If

    End Sub

    Protected Sub AdministratorsAddEdit_HideAddEdit() Handles AdministratorsAddEdit.HideAddEdit
        Me.AdministratorsAddEdit.Visible = False
        Me.AdministratorsList.Visible = True
        Me.AdministratorsList.Bind_Datagrid()
    End Sub

    Protected Sub AdministratorsList_LoadAddEdit(ByVal AdministratorID As Integer) Handles AdministratorsList.LoadAddEdit
        Me.AdministratorsAddEdit.Visible = True
        Me.AdministratorsList.Visible = False

        Me.AdministratorsAddEdit.AdministratorID = AdministratorID
        Me.AdministratorsAddEdit.LoadData()
    End Sub
End Class
