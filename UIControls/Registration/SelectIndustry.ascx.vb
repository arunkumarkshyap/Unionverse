
Partial Class CMSModules_Membership_Controls_SelectIndustry
    Inherits System.Web.UI.UserControl
    Public Event IndustrySelected(ByVal Industry As String)

    Public Property Industry() As String
        Get
            If Not IsNothing(ViewState("Industry")) Then
                Return CStr(ViewState("Industry"))
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            ViewState("Industry") = value
        End Set
    End Property

    Public Sub LoadData()
        If Me.Industry.Trim.Length > 0 Then
            Me.rdIndustry.SelectedValue = Industry
        End If
    End Sub

    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Industry = Me.rdIndustry.SelectedValue.Trim
        RaiseEvent IndustrySelected(Industry)
    End Sub
End Class
