
Partial Class UIControls_Registration_Unionverse
    Inherits System.Web.UI.UserControl
    Public Event GeographicalSelected(ByVal Value As String)
    Public Property UnionVersal() As String
        Get
            If Not IsNothing(ViewState("UnionVersal")) Then
                Return CStr(ViewState("UnionVersal"))
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            ViewState("UnionVersal") = value
        End Set
    End Property

    Public Sub LoadData()
        Select Case UnionVersal
            Case "Consultants"
                Me.rb1.Checked = True
            Case "Credit-Loans-Collections"
                Me.rb2.Checked = True
            Case "IT (Web) Services"
                Me.rb3.Checked = True
            Case "Employee Incentives"
                Me.rb4.Checked = True
            Case "Energy-Utilities"
                Me.rb5.Checked = True
            Case "Office Electronics (Computers, Phones, Etc)"
                Me.rb6.Checked = True
            Case "Office Supplies"
                Me.rb7.Checked = True
            Case "OfficeWare"
                Me.rb8.Checked = True
            Case "Marketing & Advertising"
                Me.rb9.Checked = True
            Case "Telecommunication Installation"
                Me.rb10.Checked = True
            Case "Travel, Hotel, and Transportation"
                Me.rb11.Checked = True
        End Select

    End Sub

    Protected Sub btnGeographical_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUnionversal.Click
        If Me.rb1.Checked Then
            RaiseEvent GeographicalSelected("Consultants")
        ElseIf Me.rb2.Checked Then
            RaiseEvent GeographicalSelected("Credit-Loans-Collections")
        ElseIf Me.rb3.Checked Then
            RaiseEvent GeographicalSelected("IT (Web) Services")
        ElseIf Me.rb4.Checked Then
            RaiseEvent GeographicalSelected("Employee Incentives")
        ElseIf Me.rb5.Checked Then
            RaiseEvent GeographicalSelected("Energy-Utilities")
        ElseIf Me.rb6.Checked Then
            RaiseEvent GeographicalSelected("Office Electronics (Computers, Phones, Etc)")
        ElseIf Me.rb7.Checked Then
            RaiseEvent GeographicalSelected("Office Supplies")
        ElseIf Me.rb8.Checked Then
            RaiseEvent GeographicalSelected("OfficeWare")
        ElseIf Me.rb9.Checked Then
            RaiseEvent GeographicalSelected("Marketing & Advertising")
        ElseIf Me.rb10.Checked Then
            RaiseEvent GeographicalSelected("Telecommunication Installation")
        ElseIf Me.rb11.Checked Then
            RaiseEvent GeographicalSelected("Travel, Hotel, and Transportation")
        End If
    End Sub
End Class
