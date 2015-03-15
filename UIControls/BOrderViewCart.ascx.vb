Imports CommonLibrary
Imports UserLibrary
Partial Class UIControls_BOrderViewCart
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
    Public Sub BindGrid()
        If Not IsNothing(BusinessOrder) AndAlso BusinessOrder.BOrderID > 0 Then
            Me.rpOrderList.Visible = True
            Me.lblOrderTotal.Visible = True

            Dim oBOD As New BOrderDetails
            Dim Arl As New ArrayList
            Arl = oBOD.GetByFillter(0, 0, BusinessOrder.BOrderID)
            If Arl.Count > 0 Then
                Me.rpOrderList.DataSource = Arl
                Me.rpOrderList.DataBind()
            Else
                Me.rpOrderList.DataSource = New ArrayList
                Me.rpOrderList.DataBind()
            End If
            Me.lblOrderTotal.Text = BusinessOrder.OrderAmount
        Else
            Me.rpOrderList.Visible = False
            Me.lblOrderTotal.Visible = False
        End If
    End Sub

    Protected Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        If IsValidate() Then
            UpdateCart()
            Dim oBO As New BOrders
            oBO.BOrdersUpdateCounts(BusinessOrder.BOrderID)
            Session("BusinessOrder") = New BOrders(BusinessOrder.BOrderID)
            'Response.Redirect("")   ' Go to Next step
        End If
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If IsValidate() Then
            UpdateCart()
            Dim oBO As New BOrders
            oBO.BOrdersUpdateCounts(BusinessOrder.BOrderID)
            Session("BusinessOrder") = New BOrders(BusinessOrder.BOrderID)
            BindGrid()
        End If
    End Sub
    Public Sub UpdateCart()
        For Each rpi As RepeaterItem In Me.rpOrderList.Items
            If Not IsNothing(rpi.FindControl("lbtDelet")) Then
                Dim BOID As Integer = 0
                BOID = CType(rpi.FindControl("lbtDelet"), LinkButton).CommandArgument
                If BOID > 0 AndAlso Not IsNothing(rpi.FindControl("txtQuantity")) Then
                    Dim oBO As New BOrderDetails(BOID)
                    If Not IsNothing(oBO) AndAlso oBO.BOrderID > 0 Then
                        oBO.Quantity = CType(rpi.FindControl("txtQuantity"), TextBox).Text.Trim
                        oBO.save()
                    End If
                End If
            End If
        Next

    End Sub
    Public Function IsValidate() As Boolean
        Me.lblError.Text = ""
        For Each rpi As RepeaterItem In Me.rpOrderList.Items
            If Not IsNothing(rpi.FindControl("txtQuantity")) Then
                If CType(rpi.FindControl("txtQuantity"), TextBox).Text.Trim.Length > 0 AndAlso CInt(CType(rpi.FindControl("txtQuantity"), TextBox).Text.Trim) > 0 Then
                Else
                    Me.lblError.Text = "Please enter valid Quanity."
                    Return False
                End If
            Else
                Me.lblError.Text = "Something goes worng. Please re-login and try again."
                Return False
            End If
        Next
        Return True
    End Function
    Protected Sub rpOrderList_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rpOrderList.ItemCommand
        If e.CommandName = "DELETE" Then
            Dim oBOD As New BOrderDetails
            oBOD.Delete(CInt(e.CommandArgument))
            BindGrid()
        End If
    End Sub
End Class
