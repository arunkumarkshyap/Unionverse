Imports CommonLibrary
Imports UserLibrary
Partial Class UIControls_BusinessProductsAddEdit
    Inherits System.Web.UI.UserControl
    Public Event DataSaved()
    Public ReadOnly Property CurrentUser As Users
        Get
            If Not IsNothing(Session("Users")) AndAlso CType(Session("Users"), Users).UserID > 0 Then
                Return CType(Session("Users"), Users)
            Else
                Return New Users
            End If
        End Get
    End Property
    Public Property BusinessProductID As Integer
        Get
            If Not IsNothing(ViewState("BusinessProductID")) AndAlso IsNumeric(ViewState("BusinessProductID")) Then
                Return CInt(ViewState("BusinessProductID"))
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            ViewState("BusinessProductID") = value
        End Set
    End Property
    Public Sub LoadData()
        If CurrentUser.UserID > 0 Then
            Dim oBP As New BusinessProducts()
            If BusinessProductID > 0 Then
                oBP = New BusinessProducts(BusinessProductID)
            End If
            If IsNothing(oBP) Then
                oBP = New BusinessProducts
                oBP.UserName = CurrentUser.Username
            End If
            Me.lblUserName.Text = oBP.UserName
            If Me.ddProductType.Items.Contains(Me.ddProductType.Items.FindByValue(oBP.ProductType)) Then
                Me.ddProductType.SelectedValue = oBP.ProductType
            End If
            If Me.ddStoreType.Items.Contains(Me.ddStoreType.Items.FindByValue(oBP.StoreTypeID)) Then
                Me.ddStoreType.SelectedValue = oBP.StoreTypeID
            End If
            Me.txtProductTitle.Text = oBP.ProductTitle
            Me.txtOrginalPrice.Text = oBP.OrginalPrice
            Me.txtCurrentPrice.Text = oBP.CurrentPrice
            If oBP.OrginalPrice > 0 Then
                Me.lblPercentageSaving.Text = (((oBP.OrginalPrice - oBP.CurrentPrice) / oBP.OrginalPrice) * 100)
            End If
            Me.txtWebsiteURL.Text = oBP.WebsiteURL
            Me.txtDescription.Text = oBP.Description
            Me.txtTotalAvailable.Text = oBP.Stock
            Me.imgProduct.Src = GetProductImage(oBP.Image1)

        Else
            Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "Login.aspx")
        End If
    End Sub
    Public Function GetProductImage(ByVal ImageURL As String) As String
        If ImageURL.Trim.Length > 0 Then
            Return UIHelper.GetUnionVerseBasePathURL & "/" & ImageURL.Trim
        Else
            Return "NoImage.jpg"
        End If
    End Function
    Public Function IsValidate() As Boolean
        Me.lblError.Text = ""
        If CurrentUser.UserID <= 0 Then
            Me.lblError.Text = "Please login first."
            Return False
        End If
        If Me.txtProductTitle.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Please enter product title."
            Return False
        End If
        If Me.txtOrginalPrice.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Please enter Orginal Price."
            Return False
        End If
        If Not IsNumeric(Me.txtOrginalPrice.Text.Trim) Then
            Me.lblError.Text = "Please enter valid orginal price."
            Return False
        End If
        If Me.txtCurrentPrice.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Please enter current price."
            Return False
        End If
        If Not IsNumeric(Me.txtCurrentPrice.Text.Trim) Then
            Me.lblError.Text = "Please enter valid current price."
            Return False
        End If
        If Me.txtTotalAvailable.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Plesase enter Quanity Available."
            Return False
        End If
        If Not IsNumeric(Me.txtTotalAvailable.Text.Trim) Then
            Me.lblError.Text = "enter valid quantity available"
            Return False
        End If

        Return True
    End Function
    Public Sub SaveData()
        Dim oBP As New BusinessProducts(BusinessProductID)
        If IsNothing(oBP) OrElse oBP.BusinessProductID <= 0 Then
            oBP = New BusinessProducts
            oBP.UserID = CurrentUser.UserID
            oBP.UserName = CurrentUser.Username
        End If
        oBP.ProductTitle = Me.txtProductTitle.Text.Trim
        oBP.StoreTypeID = Me.ddStoreType.SelectedItem.Value
        oBP.StoreType = Me.ddStoreType.SelectedItem.Text
        oBP.ProductType = Me.ddProductType.SelectedValue
        oBP.OrginalPrice = Me.txtOrginalPrice.Text.Trim
        oBP.CurrentPrice = Me.txtCurrentPrice.Text.Trim
        oBP.WebsiteURL = Me.txtWebsiteURL.Text.Trim
        oBP.Description = Me.txtDescription.Text.Trim
        oBP.Stock = Me.txtTotalAvailable.Text.Trim
        oBP.IsAvailable = True
        oBP.save()
        BusinessProductID = oBP.BusinessProductID

        If Me.fuProductImage.PostedFile.FileName.Trim.Length > 0 Then
            oBP.Image1 = SaveProductImage(oBP.BusinessProductID)
        End If
        oBP.save()
    End Sub
    Public Function SaveProductImage(ByVal BusinessProductID As Integer) As String
        If Me.fuProductImage.FileName.Trim.Length > 0 Then
            Dim str As String = ""
            Dim fPath As String = fuProductImage.PostedFile.FileName
            Dim filename As String = fPath.Substring(fPath.LastIndexOf("\") + 1)
            Dim Name As String = filename.Substring(0, filename.LastIndexOf("."))
            Dim type As String = filename.Substring(filename.LastIndexOf("."))
            Dim path As String = Server.MapPath(Request.ApplicationPath) & "/UserFiles/"
            If Not (IO.Directory.Exists(path)) Then
                IO.Directory.CreateDirectory(path)
            End If
            path = Server.MapPath(Request.ApplicationPath) & "/UserFiles/Products/"
            If Not (IO.Directory.Exists(path)) Then
                IO.Directory.CreateDirectory(path)
            End If
            'upAvatar.SaveAs(path & UserID & "_" & Name & "_img" & type)
            str = "UserFiles/Products/" & BusinessProductID & "_" & Name & "_img" & type

            Dim filetype As String = fuProductImage.FileName.Substring(fuProductImage.FileName.IndexOf("."))
            Dim oUI As New UIHelper
            Dim thumbnail As System.Drawing.Bitmap = oUI.CreateThumbNailWhiteBack(New Drawing.Bitmap(fuProductImage.PostedFile.InputStream, False), 178, 235)
            thumbnail.Save(Server.MapPath(Request.ApplicationPath) & "/UserFiles/Products/" & BusinessProductID & "_" & Name & "_img" & type)
            Return str
        Else
            Return ""
        End If
    End Function

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If IsValidate() Then
            SaveData()
            RaiseEvent DataSaved()
        End If
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        RaiseEvent DataSaved()
    End Sub
End Class
