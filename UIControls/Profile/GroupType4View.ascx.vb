Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Imports UserLibrary
Partial Class UIControls_Profile_GroupType4View
    Inherits System.Web.UI.UserControl
    Public Property UserID() As Integer
        Get
            If Not IsNothing(ViewState("UserID")) AndAlso IsNumeric(ViewState("UserID")) Then
                Return CInt(ViewState("UserID"))
            Else
                If Not IsNothing(Session("Users")) Then
                    Return CType(Session("Users"), Users).UserID
                Else
                    Return 0
                End If
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("UserID") = value
        End Set
    End Property
    Public Sub LoadData()
        Dim oU As New Users(UserID)
        Dim oGT4 As New smt_GroupType4
        oGT4.LoadByUserID(oU.UserID)
        If Not IsNothing(oGT4) AndAlso oGT4.GroupType4ID > 0 Then
            Me.lblCompanyName.Text = oGT4.CompanyName.Trim

         
            lblUnionverid.Text = oU.UnionVerseID
         

            'Me.lblUnionverid.Text = "WhiteWhole" & oGT4.GroupType4ID
            Me.lblWebsiteAddress.Text = oGT4.WebsiteAddress.Trim
            Me.lblDescription.Text = oGT4.Description
            Me.lblTelephoneNumber.Text = oGT4.TelephoneNumber
            Me.lblAddress.Text = oGT4.Address1.Trim & " " & oGT4.Address2.Trim
            Me.lblState.Text = oGT4.State
            Me.lblZipCode.Text = oGT4.ZipCode
            Me.lblNumerOfEmployees.Text = oGT4.NumberOfEmployees
            Me.lblAbout.Text = oGT4.About



            Me.lblCity.Text = oGT4.City
            Dim oC As New CommonLibrary.Country(oGT4.CountryID)
            If Not IsNothing(oC) AndAlso oC.CountryDisplayName.Trim.Length > 0 Then
                Me.lblCountry.Text = oC.CountryDisplayName
            End If

            Me.ShowMap1.MapLocation = oGT4.Address1 & ", " & oGT4.State & ", " & oGT4.ZipCode
            Me.ShowMap1.LoadData()

        End If
    End Sub



End Class
