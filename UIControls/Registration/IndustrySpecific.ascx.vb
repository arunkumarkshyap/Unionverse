
Partial Class UIControls_Registration_IndustrySpecific
    Inherits System.Web.UI.UserControl
    Public Event GeographicalSelected(ByVal Value As String)
    Public Property IndustrySpecific() As String
        Get
            If Not IsNothing(ViewState("IndustrySpecific")) Then
                Return CStr(ViewState("IndustrySpecific"))
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            ViewState("IndustrySpecific") = value
        End Set
    End Property

    Public Sub LoadData()
        Select Case IndustrySpecific
            Case "Consultants"
                Me.rb1.Checked = True
            Case "Distributors"
                Me.rb2.Checked = True
            Case "Invention Development (R & D)"
                Me.rb3.Checked = True
            Case "Machinery & Equipment"
                Me.rb4.Checked = True
            Case "Marketing & Advertising"
                Me.rb5.Checked = True
            Case "Raw Materials"
                Me.rb6.Checked = True
            Case "Processed Materials"
                Me.rb7.Checked = True
            Case "Product Development (Post R & D)"
                Me.rb8.Checked = True
        End Select

    End Sub

    Protected Sub btnGeographical_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGeographical.Click
        If Me.rb1.Checked Then
            RaiseEvent GeographicalSelected("Consultants")
        ElseIf Me.rb2.Checked Then
            RaiseEvent GeographicalSelected("Distributors")
        ElseIf Me.rb3.Checked Then
            RaiseEvent GeographicalSelected("Invention Development (R & D)")
        ElseIf Me.rb4.Checked Then
            RaiseEvent GeographicalSelected("Machinery & Equipment")
        ElseIf Me.rb5.Checked Then
            RaiseEvent GeographicalSelected("Marketing & Advertising")
        ElseIf Me.rb6.Checked Then
            RaiseEvent GeographicalSelected("Raw Materials")
        ElseIf Me.rb7.Checked Then
            RaiseEvent GeographicalSelected("Processed Materials")
        ElseIf Me.rb8.Checked Then
            RaiseEvent GeographicalSelected("Product Development (Post R & D)")
        End If
    End Sub
End Class
