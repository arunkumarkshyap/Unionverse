Imports AdminLibrary
Partial Class CMS_AdministratorsList
    Inherits System.Web.UI.UserControl
    Public Event LoadAddEdit(ByVal id As Integer)
    Public Property AdministratorID() As Integer
        Get
            If Not IsNothing(ViewState("AdministratorID")) AndAlso IsNumeric(ViewState("AdministratorID")) Then
                Return ViewState("AdministratorID")
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("AdministratorID") = value
        End Set
    End Property
    Public Property SortColumn() As String
        Get
            If Not IsNothing(ViewState("SortColumn")) Then
                Return ViewState("SortColumn")
            Else
                Return "AdministratorID"
            End If
        End Get
        Set(ByVal value As String)
            ViewState("SortColumn") = value
        End Set
    End Property
    Public Property Direction() As String
        Get
            If Not IsNothing(ViewState("Direction")) Then
                Return ViewState("Direction")
            Else
                Return "ASC"
            End If
        End Get
        Set(ByVal value As String)
            ViewState("Direction") = value
        End Set
    End Property
    Public Sub Bind_Datagrid(Optional ByVal PageNo As Integer = 1)
        Dim oMT As New Administrators
        Me.pagingFooter1.PageNumber = PageNo
        Me.pagingFooter1.PageSize = ConfigurationManager.AppSettings("PageSize")
        Me.pagingFooter1.GroupSize = ConfigurationManager.AppSettings("GroupSize")
        oMT.PageSize = Me.pagingFooter1.PageSize
        oMT.CurrentPageNo = Me.pagingFooter1.PageNumber
        oMT.SortColum = SortColumn
        oMT.SortDirection = Direction
        Dim aladministrator As New ArrayList
        aladministrator = oMT.AdministratorsGetByFilter(AdministratorID)
        If aladministrator.Count > 0 Then
            Me.dgAdministrators.Visible = True
            Me.pagingFooter1.Visible = True
            Me.dgAdministrators.DataSource = aladministrator
            Me.dgAdministrators.DataBind()
            Me.lblnorecord.Visible = False
            Me.pagingFooter1.PageCount = Math.Ceiling(oMT.TotalRecords / oMT.PageSize)
            Me.pagingFooter1.TotalRecords = oMT.TotalRecords
            Me.phPaging.Visible = True
            Me.lblTotleRecords.Text = oMT.TotalRecords
            If PageNo < Me.pagingFooter1.PageCount Then
                Me.lblViewing.Text = PageNo * oMT.PageSize - (oMT.PageSize - 1) & "-" & PageNo * oMT.PageSize
            Else
                Me.lblViewing.Text = PageNo * oMT.PageSize - (oMT.PageSize - 1) & "-" & oMT.TotalRecords
            End If
        Else
            phPaging.Visible = False
            Me.lblnorecord.Visible = True
            Me.dgAdministrators.Visible = False
            Me.pagingFooter1.Visible = False

        End If
    End Sub

    'Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    '    RaiseEvent LoadAddEdit(0)
    'End Sub

    Protected Sub dgAdministrators_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgAdministrators.ItemCommand
        If e.CommandName.ToUpper = "EDIT" Then
            RaiseEvent LoadAddEdit(e.CommandArgument)
        ElseIf e.CommandName.ToUpper = "DELETE" Then
            AdministratorsData.AdministratorsDelete(e.CommandArgument)
            Bind_Datagrid()
        End If
    End Sub
    Protected Sub dgAdministrators_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgAdministrators.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
            CType(e.Item.FindControl("lbtDelete"), LinkButton).Attributes.Add("OnClick", "return confirm('Are you sure you want to delete?');")
        End If
    End Sub
    Protected Sub dgAdministrators_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgAdministrators.SortCommand
        SortColumn = e.SortExpression.ToString
        If SortColumn = e.SortExpression.ToString Then
            If Direction = "ASC" Then
                Direction = "DESC"
            Else
                Direction = "ASC"
            End If
        Else
            Direction = "ASC"
        End If
        Me.Bind_Datagrid()
    End Sub
    Protected Sub pagingFooter1_ClickPage(ByVal PageNumber As Integer) Handles pagingFooter1.ClickPage
        pagingFooter1.PageNumber = PageNumber
        Bind_Datagrid(PageNumber)
    End Sub

    Protected Sub lbtnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnadd.Click
        RaiseEvent LoadAddEdit(0)
    End Sub
End Class


