
Partial Class CMSModules_Membership_Controls_SelectCharity
    Inherits System.Web.UI.UserControl
    Public Event CharitySelected(ByVal str As String)

    Public Property Charity() As String
        Get
            If Not IsNothing(ViewState("Charity")) Then
                Return CStr(ViewState("Charity"))
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            ViewState("Charity") = value
        End Set
    End Property
    Public Sub LoadData()
        Select Case Charity
            Case "Advocacy Groups for Human Rights and Civil Liberties"
                Me.rb1.Checked = True
            Case "Animal Rights"
                Me.rb2.Checked = True
            Case "Children and Youth"
                Me.rb3.Checked = True
            Case "Education, Research and Cultural Preservation Groups"
                Me.rb4.Checked = True
            Case "Feeding the Hungry"
                Me.rb5.Checked = True
            Case "General Emergency Relief"
                Me.rb6.Checked = True
            Case "Health: Cancer Support and Research"
                Me.rb7.Checked = True
            Case "Health: Support for Chronic Illnesses and Diseases"
                Me.rb8.Checked = True
            Case "Health: Support for Physical and Cognitive Disabilities"
                Me.rb9.Checked = True
            Case "Impoverished Children"
                Me.rb10.Checked = True
            Case "Land Conservation and the Environment"
                Me.rb11.Checked = True
            Case "Medical Assistance"
                Me.rb12.Checked = True
            Case "Other (Non-Profit)"
                Me.rb13.Checked = True
            Case "Poverty"
                Me.rb14.Checked = True
            Case "Promoting Self-Sufficiency"
                Me.rb15.Checked = True
            Case "Refugees"
                Me.rb16.Checked = True
            Case "Sanctity of Life"
                Me.rb17.Checked = True
            Case "Senior Citizens"
                Me.rb18.Checked = True
            Case "Supporting Fire Fighters and Police"
                Me.rb19.Checked = True
            Case "Supporting Military and Veterans"
                Me.rb20.Checked = True
            Case "Watchdog Groups"
                Me.rb21.Checked = True
            Case "Women"
                Me.rb22.Checked = True
        End Select
    End Sub

    
    Protected Sub btnCharitySelected_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCharitySelected.Click
        If Me.rb1.Checked Then
            RaiseEvent CharitySelected("Advocacy Groups for Human Rights and Civil Liberties")
        ElseIf Me.rb2.Checked Then
            RaiseEvent CharitySelected("Animal Rights")
        ElseIf Me.rb3.Checked Then
            RaiseEvent CharitySelected("Children and Youth")
        ElseIf Me.rb4.Checked Then
            RaiseEvent CharitySelected("Education, Research and Cultural Preservation Groups")
        ElseIf Me.rb5.Checked Then
            RaiseEvent CharitySelected("Feeding the Hungry")
        ElseIf Me.rb6.Checked Then
            RaiseEvent CharitySelected("General Emergency Relief")
        ElseIf Me.rb7.Checked Then
            RaiseEvent CharitySelected("Health: Cancer Support and Research")
        ElseIf Me.rb8.Checked Then
            RaiseEvent CharitySelected("Health: Support for Chronic Illnesses and Diseases")
        ElseIf Me.rb9.Checked Then
            RaiseEvent CharitySelected("Health: Support for Physical and Cognitive Disabilities")
        ElseIf Me.rb10.Checked Then
            RaiseEvent CharitySelected("Impoverished Children")
        ElseIf Me.rb11.Checked Then
            RaiseEvent CharitySelected("Land Conservation and the Environment")
        ElseIf Me.rb12.Checked Then
            RaiseEvent CharitySelected("Medical Assistance")
        ElseIf Me.rb13.Checked Then
            RaiseEvent CharitySelected("Other (Non-Profit)")
        ElseIf Me.rb14.Checked Then
            RaiseEvent CharitySelected("Poverty")
        ElseIf Me.rb15.Checked Then
            RaiseEvent CharitySelected("Promoting Self-Sufficiency")
        ElseIf Me.rb16.Checked Then
            RaiseEvent CharitySelected("Refugees")
        ElseIf Me.rb17.Checked Then
            RaiseEvent CharitySelected("Sanctity of Life")
        ElseIf Me.rb18.Checked Then
            RaiseEvent CharitySelected("Senior Citizens")
        ElseIf Me.rb19.Checked Then
            RaiseEvent CharitySelected("Supporting Fire Fighters and Police")
        ElseIf Me.rb20.Checked Then
            RaiseEvent CharitySelected("Supporting Military and Veterans")
        ElseIf Me.rb21.Checked Then
            RaiseEvent CharitySelected("Watchdog Groups")
        ElseIf Me.rb22.Checked Then
            RaiseEvent CharitySelected("Women")
        End If
    End Sub
End Class
