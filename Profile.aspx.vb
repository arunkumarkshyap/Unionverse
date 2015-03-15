Imports UserLibrary

Partial Class Profile
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
    Public Sub LoadData()
        Dim oU As New Users(UserID)
        ' Response.Write(oU.Username)

        If oU.UserTypeID = CommonLibrary.Utility.eUserTypes.BusinessUser Then
            Dim oBU As New smt_BusinessType()
            oBU.LoadByUserID(oU.UserID)
            If Not IsNothing(oBU) AndAlso oU.UserTypeID = CommonLibrary.Utility.eUserTypes.BusinessUser AndAlso oBU.UserID = CurrentUser.UserID AndAlso Not oBU.UseStore Then
                phBusinessProductsAdd.Visible = True
                BusinessProductsList.Visible = True
                BusinessProductsList.BindGrid()
                BusinessProductsAddEdit.Visible = False
            Else
                phBusinessProductsAdd.Visible = False
            End If
        Else
            phBusinessProductsAdd.Visible = False
        End If
        '

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If UserID > 0 Then
                Me.lbtEdit.Visible = True
                LoadData()
            End If
        End If
    End Sub
   

    Protected Sub BusinessProductsList_LoadBusinessProduct(BusinessProductID As Integer) Handles BusinessProductsList.LoadBusinessProduct
        Me.BusinessProductsList.Visible = False
        Me.BusinessProductsAddEdit.Visible = True
        Me.BusinessProductsAddEdit.BusinessProductID = BusinessProductID
        Me.BusinessProductsAddEdit.LoadData()
    End Sub

    Protected Sub BusinessProductsAddEdit_DataSaved() Handles BusinessProductsAddEdit.DataSaved
        Me.BusinessProductsList.Visible = True
        Me.BusinessProductsAddEdit.Visible = False
        Me.BusinessProductsList.BindGrid()
    End Sub

    Protected Sub lbtEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtEdit.Click
        Me.ProfileViews1.Visible = False
        Me.pnlProfile.Visible = True
        Me.lbtEdit.Visible = False
        Me.lbtBack.Visible = True
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtBack.Click
        Me.ProfileViews1.Visible = True
        Me.pnlProfile.Visible = False
        Me.lbtEdit.Visible = True
        Me.lbtBack.Visible = False
        Dim cui As New Users(UserID)
        If Not IsNothing(cui) AndAlso cui.UserID > 0 Then
            Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/Members/" & cui.Username & ".aspx")
        Else
            Response.Redirect(UIHelper.GetUnionVerseBasePathURL & "/Login.aspx")
        End If

    End Sub
End Class
