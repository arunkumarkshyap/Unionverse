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
Partial Class UIControls_Profile_BusinessUsersView
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
        If CurrentUser.UserID <> UserID Then
            Me.SendMessageButton1.Visible = True
        End If
        Dim oU As New Users(UserID)
        Dim oBu As New smt_BusinessType
        oBu.LoadByUserID(oU.UserID)
        If Not IsNothing(oBu) AndAlso oBu.BusinessTypeID > 0 Then
            Me.lblCompanyName.InnerHtml = oBu.CompanyName
            Me.lblUserName.InnerHtml = oU.Username
            lblUnionverid.InnerHtml = oU.UnionVerseID
            'Me.lblUnionverid.Text = "USS" & oBu.BusinessTypeID
            Me.lblWebsiteAddress.InnerHtml = oBu.WebsiteAddress
            Me.lblBusinessAddress.InnerHtml = oBu.Address1.Trim & " " & oBu.Address2.Trim
            Me.lblCity.InnerHtml = oBu.City
            Me.lblState.InnerHtml = oBu.State
            Me.lblZipCode.InnerHtml = oBu.ZipCode
            Me.lblIndustry.InnerHtml = oBu.Industry
            Me.lblAbout.InnerHtml = oBu.About
            If oBu.CompanyTypeID = 1 Then
                lblCompanyType.InnerHtml = "Business to Consumer"
                If oBu.StoreTypeID = 1 Then
                    lblStoreType.InnerHtml = "Geographical (Local Community)- " + oBu.StoreType
                ElseIf oBu.StoreTypeID = 2 Then
                    lblStoreType.InnerHtml = "Non-Geographical (UNIonVERSAL)- " + oBu.StoreType
                Else
                    lblStoreType.InnerHtml = "Both- " + oBu.StoreType
                End If
            Else
                lblCompanyType.InnerHtml = "Business to Business"
                If oBu.StoreTypeID = 1 Then
                    lblStoreType.InnerHtml = "UNIonVERSAL- " + oBu.StoreType
                ElseIf oBu.StoreTypeID = 2 Then
                    lblStoreType.InnerHtml = "Industry Specific- " + oBu.StoreType
                End If
            End If




            'If oBu.ParentBusinessTypeID = 0 Then
            '    Me.spnFranchiseLinik.InnerHtml = UIHelper.GetBasePath() & "/members/" & oU.Username & "/addfrenshise.aspx"
            '    Me.phFranshiseLink.Visible = True
            'Else
            '    Me.phFranshiseLink.Visible = False
            'End If

            Dim oC As New CommonLibrary.Country(oBu.CountryID)
            If Not IsNothing(oC) AndAlso oC.CountryDisplayName.Trim.Length > 0 Then
                Me.lblCountry.InnerHtml = oC.CountryDisplayName
                If oC.CountryDisplayName.Trim.ToLower.Contains("usa") Then
                    Me.divState.Visible = True
                Else
                    Me.divState.Visible = False
                End If
            Else
                Me.divState.Visible = False
            End If
            If oBu.UserID <> CurrentUser.UserID Then
                Me.phButtons.Visible = True
            Else
                Me.phButtons.Visible = False
            End If
        End If
    End Sub
    Public ReadOnly Property CurrentUser As Users
        Get
            If Not IsNothing(Session("Users")) Then
                Return CType(Session("Users"), Users)
            Else
                Return New Users
            End If
        End Get
    End Property

End Class
