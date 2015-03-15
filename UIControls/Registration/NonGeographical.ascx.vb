
Partial Class CMSModules_Membership_Controls_NonGeographical
    Inherits System.Web.UI.UserControl
    Public Event NonGeographicalSelected(ByVal str As String)

    Public Property NonGeographical() As String
        Get
            If Not IsNothing(ViewState("NonGeographical")) Then
                Return CStr(ViewState("NonGeographical"))
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            ViewState("NonGeographical") = value
        End Set
    End Property
    Public Sub LoadData()
        Select Case NonGeographical
            Case "Trading Communities"
                Me.rb2.Checked = True
            Case "Price Comparison Services (General)"
                Me.rb3.Checked = True
            Case "Auctions (Specific)"
                Me.rb4.Checked = True
            Case "Social Commerce"
                Me.rb5.Checked = True
            Case "Online Delivery (Flowers, Fruit, Food, Etc) (Geographical)"
                Me.rb6.Checked = True
            Case "Online Services (Godaddy, Itunes, Etc)"
                Me.rb7.Checked = True
            Case "Online Pharmacy"
                Me.rb8.Checked = True
            Case "Online Health & Fitness Supplements"
                Me.rb9.Checked = True
            Case "Online Video Service Companies"
                Me.rb10.Checked = True
            Case "Cable TV, Radio Services (Services)"
                Me.rb11.Checked = True
            Case "Pet Store"
                Me.rb13.Checked = True
            Case "Toy Store"
                Me.rb14.Checked = True
            Case "Hobby Store"
                Me.rb15.Checked = True
            Case "Candy Store"
                Me.rb16.Checked = True
            Case "Hardware Store"
                Me.rb17.Checked = True
            Case "Health Food Store"
                Me.rb18.Checked = True
            Case "Consumer Electronics Store"
                Me.rb19.Checked = True
            Case "Footwear Store"
                Me.rb20.Checked = True
            Case "Home Office Store"
                Me.rb21.Checked = True
            Case "Sports, Fitness & Outdoors Store"
                Me.rb22.Checked = True
            Case "Houseware & Home Store"
                Me.rb23.Checked = True
            Case "Cosmetic Store (Bath & Beauty)"
                Me.rb24.Checked = True
            Case "Wireless Store"
                Me.rb25.Checked = True
            Case "Eye-wear Store"
                Me.rb26.Checked = True
            Case "Fashion Couture Store"
                Me.rb27.Checked = True
            Case "Jewelry Store"
                Me.rb28.Checked = True
            Case "Stationary & Books Store"
                Me.rb29.Checked = True
            Case "Children's Apparel Store"
                Me.rb30.Checked = True
            Case "Men's Apparel Store"
                Me.rb31.Checked = True
            Case "Women's Apparel Store"
                Me.rb32.Checked = True
            Case "Portrait & Photography Stores"
                Me.rb33.Checked = True
            Case "Automotive Parts Store"
                Me.rb34.Checked = True
            Case "Educational Services"
                Me.rb35.Checked = True
            Case "Online Travel"
                Me.rb36.Checked = True
            Case "Mobile Commerce"
                Me.rb37.Checked = True
        End Select
    End Sub

    Protected Sub btnNonGeoSelected_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNonGeoSelected.Click
        If Me.rb2.Checked Then
            RaiseEvent NonGeographicalSelected("Trading Communities")
        ElseIf Me.rb3.Checked Then
            RaiseEvent NonGeographicalSelected("Price Comparison Services (General)")
        ElseIf Me.rb4.Checked Then
            RaiseEvent NonGeographicalSelected("Auctions (Specific)")
        ElseIf Me.rb5.Checked Then
            RaiseEvent NonGeographicalSelected("Social Commerce")
        ElseIf Me.rb6.Checked Then
            RaiseEvent NonGeographicalSelected("Online Delivery (Flowers, Fruit, Food, Etc) (Geographical)")
        ElseIf Me.rb7.Checked Then
            RaiseEvent NonGeographicalSelected("Online Services (Godaddy, Itunes, Etc)")
        ElseIf Me.rb8.Checked Then
            RaiseEvent NonGeographicalSelected("Online Pharmacy")
        ElseIf Me.rb9.Checked Then
            RaiseEvent NonGeographicalSelected("Online Health & Fitness Supplements")
        ElseIf Me.rb10.Checked Then
            RaiseEvent NonGeographicalSelected("Online Video Service Companies")
        ElseIf Me.rb11.Checked Then
            RaiseEvent NonGeographicalSelected("Cable TV, Radio Services (Services)")
        ElseIf Me.rb13.Checked Then
            RaiseEvent NonGeographicalSelected("Pet Store")
        ElseIf Me.rb14.Checked Then
            RaiseEvent NonGeographicalSelected("Toy Store")
        ElseIf Me.rb15.Checked Then
            RaiseEvent NonGeographicalSelected("Hobby Store")
        ElseIf Me.rb16.Checked Then
            RaiseEvent NonGeographicalSelected("Candy Store")
        ElseIf Me.rb17.Checked Then
            RaiseEvent NonGeographicalSelected("Hardware Store")
        ElseIf Me.rb18.Checked Then
            RaiseEvent NonGeographicalSelected("Health Food Store")
        ElseIf Me.rb19.Checked Then
            RaiseEvent NonGeographicalSelected("Consumer Electronics Store")
        ElseIf Me.rb20.Checked Then
            RaiseEvent NonGeographicalSelected("Footwear Store")
        ElseIf Me.rb21.Checked Then
            RaiseEvent NonGeographicalSelected("Home Office Store")
        ElseIf Me.rb22.Checked Then
            RaiseEvent NonGeographicalSelected("Sports, Fitness & Outdoors Store")
        ElseIf Me.rb23.Checked Then
            RaiseEvent NonGeographicalSelected("Houseware & Home Store")
        ElseIf Me.rb24.Checked Then
            RaiseEvent NonGeographicalSelected("Cosmetic Store (Bath & Beauty)")
        ElseIf Me.rb25.Checked Then
            RaiseEvent NonGeographicalSelected("Wireless Store")
        ElseIf Me.rb26.Checked Then
            RaiseEvent NonGeographicalSelected("Eye-wear Store")
        ElseIf Me.rb27.Checked Then
            RaiseEvent NonGeographicalSelected("Fashion Couture Store")
        ElseIf Me.rb28.Checked Then
            RaiseEvent NonGeographicalSelected("Jewelry Store")
        ElseIf Me.rb29.Checked Then
            RaiseEvent NonGeographicalSelected("Stationary & Books Store")
        ElseIf Me.rb30.Checked Then
            RaiseEvent NonGeographicalSelected("Children's Apparel Store")
        ElseIf Me.rb31.Checked Then
            RaiseEvent NonGeographicalSelected("Men's Apparel Store")
        ElseIf Me.rb32.Checked Then
            RaiseEvent NonGeographicalSelected("Women's Apparel Store")
        ElseIf Me.rb33.Checked Then
            RaiseEvent NonGeographicalSelected("Portrait & Photography Stores")
        ElseIf Me.rb34.Checked Then
            RaiseEvent NonGeographicalSelected("Automotive Parts Store")
        ElseIf Me.rb35.Checked Then
            RaiseEvent NonGeographicalSelected("Educational Services")
        ElseIf Me.rb36.Checked Then
            RaiseEvent NonGeographicalSelected("Online Travel")
        ElseIf Me.rb37.Checked Then
            RaiseEvent NonGeographicalSelected("Mobile Commerce")
        End If
    End Sub
End Class
