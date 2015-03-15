
Partial Class CMSModules_Membership_Controls_SelectNonProfit
    Inherits System.Web.UI.UserControl
    Public Event NonProfitSelected(ByVal str As String)

    Public Property NonProfit() As String
        Get
            If Not IsNothing(ViewState("NonProfit")) Then
                Return CStr(ViewState("NonProfit"))
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            ViewState("NonProfit") = value
        End Set
    End Property
    Public Sub LoadData()
        Select Case NonProfit
            Case "Aid to Families with Dependent Children"
                Me.rb1.Checked = True
            Case "Alcohol, Drug Abuse, and Mental Health"
                Me.rb2.Checked = True
            Case "Child and Adult Care Food Program"
                Me.rb3.Checked = True
            Case "Community Development"
                Me.rb4.Checked = True
            Case "Conservation Reserve Program"
                Me.rb5.Checked = True
            Case "Crime Prevention and Local Law Enforcement Efforts"
                Me.rb6.Checked = True
            Case "Education"
                Me.rb7.Checked = True
            Case "Health and Nutrition"
                Me.rb8.Checked = True
            Case "Home and Shelter"
                Me.rb9.Checked = True
            Case "Other (Non-Specific)"
                Me.rb10.Checked = True
            Case "Parent Involvement"
                Me.rb11.Checked = True
            Case "Unemployment Aid"
                Me.rb12.Checked = True
        End Select
    End Sub


    Protected Sub btnCharitySelected_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCharitySelected.Click
        If Me.rb1.Checked Then
            RaiseEvent NonProfitSelected("Aid to Families with Dependent Children")
        ElseIf Me.rb2.Checked Then
            RaiseEvent NonProfitSelected("Alcohol, Drug Abuse, and Mental Health")
        ElseIf Me.rb3.Checked Then
            RaiseEvent NonProfitSelected("Child and Adult Care Food Program")
        ElseIf Me.rb4.Checked Then
            RaiseEvent NonProfitSelected("Community Development")
        ElseIf Me.rb5.Checked Then
            RaiseEvent NonProfitSelected("Conservation Reserve Program")
        ElseIf Me.rb6.Checked Then
            RaiseEvent NonProfitSelected("Crime Prevention and Local Law Enforcement Efforts")
        ElseIf Me.rb7.Checked Then
            RaiseEvent NonProfitSelected("Education")
        ElseIf Me.rb8.Checked Then
            RaiseEvent NonProfitSelected("Health and Nutrition")
        ElseIf Me.rb9.Checked Then
            RaiseEvent NonProfitSelected("Home and Shelter")
        ElseIf Me.rb10.Checked Then
            RaiseEvent NonProfitSelected("Other (Non-Specific)")
        ElseIf Me.rb11.Checked Then
            RaiseEvent NonProfitSelected("Parent Involvement")
        ElseIf Me.rb12.Checked Then
            RaiseEvent NonProfitSelected("Unemployment Aid")
        End If
    End Sub
End Class
