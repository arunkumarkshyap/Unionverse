Imports UserLibrary
Imports CommonLibrary
Partial Class UIControls_BOrderShipping
    Inherits System.Web.UI.UserControl
    Public ReadOnly Property CurrentUser As Users
        Get
            If Not IsNothing(Session("Users")) AndAlso CType(Session("Users"), Users).UserID > 0 Then
                Return CType(Session("Users"), Users)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Property BusinessOrder As BOrders
        Get
            If Not IsNothing(Session("BusinessOrder")) Then
                Return CType(Session("BusinessOrder"), BOrders)
            Else
                Return Nothing
            End If
        End Get
        Set(value As BOrders)
            Session("BusinessOrder") = value
        End Set
    End Property
    Public Sub LoadData()
        LoadCountryState()
        If Not IsNothing(BusinessOrder) Then
            Dim oBO As New BOrders
            oBO = BusinessOrder
            Me.txtShipName.Text = oBO.ShipName
            Me.txtShipEmail.Text = oBO.ShipEmail
            Me.txtShipPhone.Text = oBO.ShipPhone
            Me.txtShipCompany.Text = oBO.ShipCompany
            Me.txtShipAddress.Text = oBO.ShipAddress
            Me.txtShipCity.Text = oBO.ShipCity
            Me.txtZipCode.Text = oBO.ShipZipCode
            If Me.ddCountry.Items.Contains(Me.ddCountry.Items.FindByValue(oBO.ShipCountry)) Then
                Me.ddCountry.SelectedValue = oBO.ShipCountry
                UIHelper.LoadStatesByCountry(Me.ddState, "-- Select State --", CInt(Me.ddCountry.SelectedValue))
                If Me.ddState.Items.Count = 0 Then
                    Me.ddState.Visible = False
                Else
                    Me.ddState.Visible = True
                End If
            End If
            If Not IsNothing(Me.ddState) AndAlso Me.ddState.Items.Contains(Me.ddState.Items.FindByValue(oBO.ShipState)) Then
                Me.ddState.SelectedValue = oBO.ShipState
            End If
        End If
    End Sub
    Public Function IsValidate() As Boolean
        Me.lblError.Text = ""
        If Me.txtShipName.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Please enter shipping name."
            Return False
        End If
        If Me.txtShipEmail.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Please eneter emai."
            Return False
        End If
        If Me.txtShipPhone.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Please enter phone."
            Return False
        End If
        If Me.txtShipAddress.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Please enter address."
            Return False
        End If
        If Me.txtShipCity.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Please enter city."
            Return False
        End If
        If Me.txtZipCode.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Please enter zipcode."
            Return False
        End If
        Return False
    End Function
    Public Sub SaveData()
        If Not IsNothing(BusinessOrder) Then
            Dim oBO As New BOrders
            oBO = BusinessOrder
            oBO.ShipCountry = Me.ddCountry.SelectedValue
            If Me.ddState.Items.Count > 0 Then
                oBO.ShipState = Me.ddState.SelectedValue
            End If
            oBO.ShipName = Me.txtShipName.Text.Trim
            oBO.ShipEmail = Me.txtShipEmail.Text.Trim
            oBO.ShipPhone = Me.txtShipPhone.Text.Trim
            oBO.ShipAddress = Me.txtShipAddress.Text.Trim
            oBO.ShipCity = Me.txtShipCity.Text.Trim
            oBO.ShipCompany = Me.txtShipCompany.Text.Trim
            oBO.ShipZipCode = Me.txtZipCode.Text.Trim
            oBO.save()
            BusinessOrder = oBO
        End If
    End Sub
    Protected Sub ddCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddCountry.SelectedIndexChanged
        UIHelper.LoadStatesByCountry(Me.ddState, "-- Select State --", CInt(Me.ddCountry.SelectedValue))
        If Me.ddState.Items.Count = 0 Then
            Me.ddState.Visible = False
        Else
            Me.ddState.Visible = True
        End If
    End Sub
    Public Sub LoadCountryState()
        UIHelper.LoadCountry(Me.ddCountry, "--Select Country")
        Me.ddCountry.SelectedValue = "271"

        UIHelper.LoadStatesByCountry(Me.ddState, "-- Select State --", CInt(Me.ddCountry.SelectedValue))
        If Me.ddState.Items.Count = 0 Then
            Me.ddState.Visible = False
        Else
            Me.ddState.Visible = True
        End If
    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ' response.redirect to the ViewCart Page.
    End Sub

    Protected Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        If IsValidate() Then
            SaveData()
            ' Response.Redirect("")   ' Redirect to the final page.
        End If
    End Sub
End Class
