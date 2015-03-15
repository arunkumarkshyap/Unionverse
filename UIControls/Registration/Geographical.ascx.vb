
Partial Class CMSModules_Membership_Controls_Geographical
    Inherits System.Web.UI.UserControl
    Public Event GeographicalSelected(ByVal Value As String)
    Public Property Geographical() As String
        Get
            If Not IsNothing(ViewState("Geographical")) Then
                Return CStr(ViewState("Geographical"))
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            ViewState("Geographical") = value
        End Set
    End Property

    Public Sub LoadData()
        Select Case Geographical
            Case "Convenience Store/General Store"
                Me.rb1.Checked = True
            Case "Newsagent"
                Me.rb2.Checked = True
            Case "Amusement (Entertainment)"
                Me.rb4.Checked = True
            Case "Venue (Entertainment)"
                Me.rb5.Checked = True
            Case "Social (Entertainment)"
                Me.rb6.Checked = True
            Case "Supermarket"
                Me.rb7.Checked = True
            Case "Warehouse Club"
                Me.rb8.Checked = True
            Case "Restaurant"
                Me.rb10.Checked = True
            Case "Cultural"
                Me.rb12.Checked = True
            Case "Franchise"
                Me.rb13.Checked = True
            Case "Health Conscious"
                Me.rb14.Checked = True
            Case "Take-out (General)"
                Me.rb15.Checked = True
            Case "Spa, Salon, Nails, Barbers"
                Me.rb16.Checked = True
            Case "Car (Repair or Collision)"
                Me.rb17.Checked = True
            Case "Gas Station"
                Me.rb18.Checked = True
            Case "Cable TV, Radio Services (Services)"
                Me.rb19.Checked = True
        End Select

    End Sub

    Protected Sub btnGeographical_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGeographical.Click
        If Me.rb1.Checked Then
            RaiseEvent GeographicalSelected("Convenience Store/General Store")
        ElseIf Me.rb2.Checked Then
            RaiseEvent GeographicalSelected("Newsagent")
        ElseIf Me.rb4.Checked Then
            RaiseEvent GeographicalSelected("Amusement (Entertainment)")
        ElseIf Me.rb5.Checked Then
            RaiseEvent GeographicalSelected("Venue (Entertainment)")
        ElseIf Me.rb6.Checked Then
            RaiseEvent GeographicalSelected("Social (Entertainment)")
        ElseIf Me.rb7.Checked Then
            RaiseEvent GeographicalSelected("Supermarket")
        ElseIf Me.rb8.Checked Then
            RaiseEvent GeographicalSelected("Warehouse Club")
        ElseIf Me.rb10.Checked Then
            RaiseEvent GeographicalSelected("Restaurant")
        ElseIf Me.rb12.Checked Then
            RaiseEvent GeographicalSelected("Cultural")
        ElseIf Me.rb13.Checked Then
            RaiseEvent GeographicalSelected("Franchise")
        ElseIf Me.rb14.Checked Then
            RaiseEvent GeographicalSelected("Health Conscious")
        ElseIf Me.rb15.Checked Then
            RaiseEvent GeographicalSelected("Take-out (General)")
        ElseIf Me.rb16.Checked Then
            RaiseEvent GeographicalSelected("Spa, Salon, Nails, Barbers")
        ElseIf Me.rb17.Checked Then
            RaiseEvent GeographicalSelected("Car (Repair or Collision)")
        ElseIf Me.rb18.Checked Then
            RaiseEvent GeographicalSelected("Gas Station")
        ElseIf Me.rb19.Checked Then
            RaiseEvent GeographicalSelected("Cable TV, Radio Services (Services)")
        End If
    End Sub
End Class
