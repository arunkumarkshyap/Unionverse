
Partial Class CMSModules_Membership_Controls_BothGeoNonGeo
    Inherits System.Web.UI.UserControl
    Public Event BothGeoNonGeoSelected(ByVal Value As String)
    Public Property BothGeoNonGeo() As String
        Get
            If Not IsNothing(ViewState("BothGeoNonGeo")) Then
                Return CStr(ViewState("BothGeoNonGeo"))
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            ViewState("BothGeoNonGeo") = value
        End Set
    End Property
    Public Sub LoadData()
        Select Case BothGeoNonGeo
            Case "Superstore"
                Me.rb1.Checked = True
            Case "Department Store"
                Me.rb2.Checked = True
            Case "Pet Store"
                Me.rb4.Checked = True
            Case "Toy Store"
                Me.rb5.Checked = True
            Case "Hobby Store"
                Me.rb6.Checked = True
            Case "Candy Store"
                Me.rb7.Checked = True
            Case "Hardware Store"
                Me.rb8.Checked = True
            Case "Health Food Store"
                Me.rb9.Checked = True
            Case "Consumer Electronics Store"
                Me.rb10.Checked = True
            Case "Footwear Store"
                Me.rb11.Checked = True
            Case "Home Office Store"
                Me.rb12.Checked = True
            Case "Sports, Fitness & Outdoors Store"
                Me.rb13.Checked = True
            Case "Houseware & Home Store"
                Me.rb14.Checked = True
            Case "Cosmetic Store (Bath & Beauty)"
                Me.rb15.Checked = True
            Case "Wireless Store"
                Me.rb16.Checked = True
            Case "Eye-wear Store"
                Me.rb17.Checked = True
            Case "Fashion Couture Store"
                Me.rb18.Checked = True
            Case "Jewelry Store"
                Me.rb19.Checked = True
            Case "Stationary & Books Store"
                Me.rb20.Checked = True
            Case "Children's Apparel Store"
                Me.rb21.Checked = True
            Case "Men's Apparel Store"
                Me.rb22.Checked = True
            Case "Women's Apparel Store"
                Me.rb23.Checked = True
            Case "Spa, Salon, Nails, and Hair Stores"
                Me.rb24.Checked = True
            Case "Portrait & Photography Stores"
                Me.rb25.Checked = True
            Case "Automotive Parts Store"
                Me.rb26.Checked = True
            Case "Outlet Store"
                Me.rb27.Checked = True
        End Select
    End Sub

    Protected Sub btnBothSelected_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBothSelected.Click
        If Me.rb1.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Superstore")
        ElseIf Me.rb2.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Department Store")
        ElseIf Me.rb4.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Pet Store")
        ElseIf Me.rb5.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Toy Store")
        ElseIf Me.rb6.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Hobby Store")
        ElseIf Me.rb7.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Candy Store")
        ElseIf Me.rb8.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Hardware Store")
        ElseIf Me.rb9.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Health Food Store")
        ElseIf Me.rb10.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Consumer Electronics Store")
        ElseIf Me.rb11.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Footwear Store")
        ElseIf Me.rb12.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Home Office Store")
        ElseIf Me.rb13.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Sports, Fitness & Outdoors Store")
        ElseIf Me.rb14.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Houseware & Home Store")
        ElseIf Me.rb15.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Cosmetic Store (Bath & Beauty)")
        ElseIf Me.rb16.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Wireless Store")
        ElseIf Me.rb17.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Eye-wear Store")
        ElseIf Me.rb18.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Fashion Couture Store")
        ElseIf Me.rb19.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Jewelry Store")
        ElseIf Me.rb20.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Stationary & Books Store")
        ElseIf Me.rb21.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Children's Apparel Store")
        ElseIf Me.rb22.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Men's Apparel Store")
        ElseIf Me.rb23.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Women's Apparel Store")
        ElseIf Me.rb24.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Spa, Salon, Nails, and Hair Stores")
        ElseIf Me.rb25.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Portrait & Photography Stores")
        ElseIf Me.rb26.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Automotive Parts Store")
        ElseIf Me.rb27.Checked Then
            RaiseEvent BothGeoNonGeoSelected("Outlet Store")
        End If
    End Sub
End Class
