
Partial Class ManageOffers
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.OfferList.LoadData()
            Me.OfferList.Visible = True
            Me.OfferAddEdit.Visible = False
        End If
    End Sub

    Protected Sub OfferAddEdit_SaveSuccessfully() Handles OfferAddEdit.SaveSuccessfully
        Me.OfferList.LoadData()
        Me.OfferList.Visible = True
        Me.OfferAddEdit.Visible = False
    End Sub

    Protected Sub OfferList_LoadEdit(OfferID As Integer) Handles OfferList.LoadEdit
        Me.OfferList.Visible = False
        Me.OfferAddEdit.Visible = True
        Me.OfferAddEdit.OfferID = OfferID
        Me.OfferAddEdit.LoadData()
    End Sub
End Class
