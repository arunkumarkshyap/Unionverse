Imports UserLibrary
Imports CommonLibrary
Imports WormWholesLibrary
Partial Class UIControls_BOrderPayments
    Inherits System.Web.UI.UserControl
    Public Property CurrentUser As Users
        Get
            If Not IsNothing(Session("Users")) AndAlso CType(Session("Users"), Users).UserID > 0 Then
                Return CType(Session("Users"), Users)
            Else
                Return Nothing
            End If
        End Get
        Set(value As Users)
            Session("Users") = value
        End Set
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
            'Response.Redirect() ' to the ViewCart Page or Profile Page. 
        End If
    End Sub

    Protected Sub btnMakePayment_Click(sender As Object, e As EventArgs) Handles btnMakePayment.Click
        If IsValidate() Then

            Dim oBO As New BOrders
            oBO = BusinessOrder
            oBO.OrderStatusID = 1
            oBO.OrderStatus = "Completed"
            oBO.save()
            BusinessOrder = oBO

            '''//////////////////////////////////////////////////////////////////
            '''//////////////////////////////////////////////////////////////////
            '''////////////|====================================|////////////////
            '''////////////|                                    |////////////////
            '''////////////|   UNI PAYMENT LOGIC WILL BE HERE   |////////////////
            '''////////////|                                    |////////////////
            '''////////////|====================================|////////////////
            '''//////////////////////////////////////////////////////////////////
            '''//////////////////////////////////////////////////////////////////

            Dim _Amount As Double = 0.0
            _Amount = oBO.OrderAmount
            Dim oUser As New Users
            oUser = CurrentUser
            Dim arl As New ArrayList()
            Dim _TransactionDetail As String = ""
            Dim oItem As New BOrderDetails
            arl = oItem.GetByFillter(0, 0, BusinessOrder.BOrderID)
            Dim _TotalGoneUniBuyer As Double = 0
            If arl IsNot Nothing AndAlso arl.Count > 0 Then
                For Each oI__2 As BOrderDetails In arl
                   

                    If oI__2 IsNot Nothing Then
                        Dim _ItemTotal As Double = (oI__2.Price * oI__2.Quantity)
                        Dim _SellerAmount As Double = 0
                        Dim _UserType1Amount As Double = 0
                        Dim _AdminUserAmount As Double = 0
                        Dim _BuyerUNIonVERSEID As String = ""
                        Dim _SellerUNIonVERSEID As String = ""
                        _BuyerUNIonVERSEID = CurrentUser.UnionVerseID
                        Dim _SUser As New Users(oI__2.UserID)
                        _SellerUNIonVERSEID = _SUser.UnionVerseID
                        Dim oFriend As New Friends()
                        If oFriend.IsFriendshipExist(CurrentUser.UserID, oI__2.UserID) Then
                            _SellerAmount = _ItemTotal * 0.9
                            _UserType1Amount = (_ItemTotal - _SellerAmount) * 0.17
                            _AdminUserAmount = (_ItemTotal - _SellerAmount) - _UserType1Amount
                        Else
                            _SellerAmount = _ItemTotal * 0.65
                            _UserType1Amount = (_ItemTotal - _SellerAmount) * 0.17
                            _AdminUserAmount = (_ItemTotal - _SellerAmount) - _UserType1Amount
                        End If





                        '========== Increase Seller UNI & Log Transaction. (Group Type 2 Business Users) ==Credit ++

                        Dim _SellerUser As New Users(oI__2.UserID)
                        If Not IsNothing(_SellerUser) AndAlso _SellerUser.UserID > 0 Then
                            _SellerUser.UserPoints = _SellerUser.UserPoints + _SellerAmount
                            _SellerUser.Save()


                            Dim oTransaction As New UniTransaction()
                            oTransaction.TransferFromUserID = _SellerUser.UserID
                            oTransaction.TransferToUserID = 0
                            oTransaction.TransactionNumber = ""
                            oTransaction.Description = " Sell " + oI__2.ProductTitle & " to " & _BuyerUNIonVERSEID & " "
                            oTransaction.AmountDebit = 0
                            oTransaction.AmountCredit = _SellerAmount
                            oTransaction.AmountBalance = _SellerUser.UserPoints
                            oTransaction.TransactionDate = DateTime.Now
                            oTransaction.TransactionTypeID = 2

                            _TransactionDetail = (_TransactionDetail & "<br /> StarShip " & _SellerUNIonVERSEID & " Sell ") + oI__2.ProductTitle & " received amount = " & _SellerAmount.ToString()

                            ' Transfer
                            oTransaction.save()
                        Else
                            _SellerUser.UserPoints = _SellerAmount
                            _SellerUser.Save()



                            Dim oTransaction As New UniTransaction()
                            oTransaction.TransferFromUserID = _SellerUser.UserID
                            oTransaction.TransferToUserID = 0
                            oTransaction.TransactionNumber = ""
                            oTransaction.Description = " Sell " + oI__2.ProductTitle & " to " & _BuyerUNIonVERSEID & " "
                            oTransaction.AmountDebit = 0
                            oTransaction.AmountCredit = _SellerAmount
                            oTransaction.AmountBalance = _SellerUser.UserPoints
                            oTransaction.TransactionDate = DateTime.Now
                            oTransaction.TransactionTypeID = 2
                            ' Transfer

                            _TransactionDetail = (_TransactionDetail & "<br /> StarShip " & _SellerUNIonVERSEID & " Sell ") + oI__2.ProductTitle & " received amount = " & _SellerAmount.ToString()

                            oTransaction.save()
                        End If


                        '========== Increase Group Type 1 UNI & Log Transaction. (Group Type 1 Users) ==Credit ++
                        Dim UT1P As New smt_UserType1Planet()
                        UT1P.LoadByFriendUserID(CurrentUser.UserID, ConfigurationManager.AppSettings("connectionString"))

                        Dim _UserType1 As New smt_UserType1(UT1P.UserType1ID)
                        '_UserType1.ConnectionString = ConfigurationManager.AppSettings["CSUnionVerse"];

                        Dim _UserType1User As New Users(_UserType1.UserID)



                        If Not IsNothing(_UserType1User) AndAlso _UserType1User.UserID > 0 Then
                            _UserType1User.UserPoints = _UserType1User.UserPoints + _UserType1Amount
                            _UserType1User.save()


                            Dim oTransaction As New UniTransaction()
                            oTransaction.TransferFromUserID = _UserType1User.UserID
                            oTransaction.TransferToUserID = 0
                            oTransaction.TransactionNumber = ""
                            oTransaction.Description = (" " & _BuyerUNIonVERSEID & " Purchased ") + oI__2.ProductTitle & " from " & _SellerUNIonVERSEID & " "
                            oTransaction.AmountDebit = 0
                            oTransaction.AmountCredit = _UserType1Amount
                            oTransaction.AmountBalance = _UserType1User.UserPoints
                            oTransaction.TransactionDate = DateTime.Now
                            oTransaction.TransactionTypeID = 2

                            _TransactionDetail = (_TransactionDetail & "<br /> Amount received by SolarSystem ") + _UserType1User.Username & " = " & _UserType1Amount.ToString()

                            ' Transfer
                            oTransaction.save()
                        Else
                            _UserType1User.UserPoints += _UserType1Amount
                            _UserType1User.Save()

                            Dim oTransaction As New UniTransaction()
                            oTransaction.TransferFromUserID = _UserType1User.UserID
                            oTransaction.TransferToUserID = 0
                            oTransaction.TransactionNumber = ""
                            oTransaction.Description = ("" & _BuyerUNIonVERSEID & " Purchased ") + oI__2.ProductTitle & " from " & _SellerUNIonVERSEID & " "
                            oTransaction.AmountDebit = 0
                            oTransaction.AmountCredit = _UserType1Amount
                            oTransaction.AmountBalance = _UserType1User.UserPoints
                            oTransaction.TransactionDate = DateTime.Now
                            oTransaction.TransactionTypeID = 2

                            _TransactionDetail = (_TransactionDetail & "<br /> Amount received by SolarSystem ") + _UserType1User.Username & " = " & _UserType1Amount.ToString()

                            ' Transfer
                            oTransaction.save()
                        End If




                        '========== Increase Admin UNI & Log Transaction. (UNIonVERSE Admin User) ==Credit ++

                        Dim _Admin As New Users(ConfigurationManager.AppSettings("AdminUserID"))
                        ' Here will be administrator ID
                        If Not IsNothing(_Admin) Then
                            _Admin.UserPoints = _Admin.UserPoints + _AdminUserAmount
                            _Admin.Save()
                        End If
                        Dim oTransaction1 As New UniTransaction()
                        oTransaction1.TransferFromUserID = _Admin.UserID
                        oTransaction1.TransferToUserID = 0
                        oTransaction1.TransactionNumber = ""
                        oTransaction1.Description = (" " & _BuyerUNIonVERSEID & " Purchased ") + oI__2.ProductTitle & " from " & _SellerUNIonVERSEID & " "
                        oTransaction1.AmountDebit = 0
                        oTransaction1.AmountCredit = _AdminUserAmount
                        oTransaction1.AmountBalance = _Admin.UserPoints
                        oTransaction1.TransactionDate = DateTime.Now
                        oTransaction1.TransactionTypeID = 2

                        _TransactionDetail = _TransactionDetail & "<br />Amount received my admin = " & _AdminUserAmount.ToString()

                        ' Transfer
                        oTransaction1.save()



                        '========== Decrease buyer UNI & Log Transaction. (Individual Type 1 Users & Individual Type 2 Users) ==Debit --
                        _TotalGoneUniBuyer = _TotalGoneUniBuyer + _ItemTotal


                        Dim uBuyer As New Users(CurrentUser.UserID)
                        If Not IsNothing(uBuyer) Then
                            uBuyer.UserPoints = uBuyer.UserPoints - _ItemTotal
                            uBuyer.Save()
                            CurrentUser = uBuyer
                        End If
                        Dim oTransactionFrom As New UniTransaction()
                        oTransactionFrom.TransferFromUserID = CurrentUser.UserID
                        oTransactionFrom.TransferToUserID = 0
                        oTransactionFrom.TransactionNumber = ""
                        oTransactionFrom.Description = "Purchased " + oI__2.ProductTitle & " from " & _SellerUNIonVERSEID & " "
                        oTransactionFrom.AmountDebit = _ItemTotal
                        oTransactionFrom.AmountCredit = 0
                        oTransactionFrom.AmountBalance = CurrentUser.UserPoints
                        oTransactionFrom.TransactionDate = DateTime.Now
                        oTransactionFrom.TransactionTypeID = 2
                        oTransactionFrom.save()

                        Dim oTransactionDetail As New UniTransaction()
                        oTransactionDetail.TransferFromUserID = CurrentUser.UserID
                        oTransactionDetail.TransferToUserID = 0
                        oTransactionDetail.TransactionNumber = ""
                        oTransactionDetail.Description = "Purchased " + oI__2.ProductTitle & " from " & _SellerUNIonVERSEID & " Amount = " & _ItemTotal & "<br /><br /><b>Transaction Details</b><br /><br />" & _TransactionDetail
                        oTransactionDetail.AmountDebit = _ItemTotal
                        oTransactionDetail.AmountCredit = 0
                        oTransactionDetail.AmountBalance = CurrentUser.UserPoints
                        oTransactionDetail.TransactionDate = DateTime.Now
                        oTransactionDetail.TransactionTypeID = 9
                        ' Transfer
                        '####################   SAVE TRANSACTIOn DETAIL History
                        oTransactionDetail.save()
                    End If

                    UIHelper.InviteUserAfterSaleOrbitB2I(oI__2.UserID, CurrentUser.UserID)
                Next
            End If
            '========== TAX and Shipping  Decrease buyer UNI & Log Transaction. (Individual Type 1 Users & Individual Type 2 Users) ==Debit --

            If (oBO.OrderAmount + oBO.OrderShipping + oBO.OrderVAT) > _TotalGoneUniBuyer Then
                If Not IsNothing(CurrentUser) AndAlso CurrentUser.UserID > 0 Then
                    oUser = CurrentUser

                    oUser.UserPoints = oUser.UserPoints - ((oBO.OrderAmount + oBO.OrderShipping + oBO.OrderVAT) - _TotalGoneUniBuyer)
                    oUser.Save()
                    Dim oTransactionFrom As New UniTransaction()
                    oTransactionFrom.TransferFromUserID = CurrentUser.UserID
                    oTransactionFrom.TransferToUserID = 0
                    oTransactionFrom.TransactionNumber = ""
                    oTransactionFrom.Description = "Purchased products Tax + Shipping Charges "
                    oTransactionFrom.AmountDebit = ((oBO.OrderAmount + oBO.OrderShipping + oBO.OrderVAT) - _TotalGoneUniBuyer)
                    oTransactionFrom.AmountCredit = 0
                    oTransactionFrom.AmountBalance = oUser.UserPoints
                    oTransactionFrom.TransactionDate = DateTime.Now
                    oTransactionFrom.TransactionTypeID = 2
                    _TransactionDetail = (_TransactionDetail & "<br />") + oTransactionFrom.Description & " = " & oTransactionFrom.AmountDebit.ToString()
                    ' Transfer
                    oTransactionFrom.save()
                End If
            End If
            BusinessOrder = Nothing   ' Clear Shopping Cart
            'Me.ShoppingCartControl.CleanUpShoppingCart()
            '  string url = CMSContext.GetUrl("/");
            Response.Redirect("~/OrderCompleted.aspx")
        End If
    End Sub
    Public Sub MakePayment()

    End Sub
    Public Function IsValidate() As Boolean
        Me.lblError.Text = ""
        If Not IsNothing(CurrentUser) AndAlso Not IsNothing(BusinessOrder) Then
            If BusinessOrder.OrderAmount <= 0 Then
                Me.lblError.Text = "Please make sure that you have something in you cart."
                Return False
            End If
            If CurrentUser.UserPoints <= 0 Then
                Me.lblError.Text = "You do not have sufficient UNI's to pay."
                Return False
            End If
            If CurrentUser.UserPoints < BusinessOrder.OrderAmount Then
                Me.lblError.Text = "You do not have sufficient UNI's to pay."
                Return False
            End If
        Else
            Me.lblError.Text = "Please make sure that you have something in your cart."
            Return False
        End If
        Return False
    End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not IsNothing(CurrentUser) Then
                Me.lblUniCount.Text = CurrentUser.UserPoints
            Else
                Response.Redirect("Login.aspx")
            End If
        End If
    End Sub
End Class
