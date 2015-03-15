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
Partial Class UIControls_Registration_FranchiseAddEdit
    Inherits System.Web.UI.UserControl
    Public Property FranchiseID() As Integer
        Get
            If Not IsNothing(ViewState("FranchiseID")) AndAlso IsNumeric(ViewState("FranchiseID")) Then
                Return CInt(ViewState("FranchiseID"))
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("FranchiseID") = value
        End Set
    End Property
    Public Property BusinessTypeID() As Integer
        Get
            If Not IsNothing(ViewState("BusinessTypeID")) AndAlso IsNumeric(ViewState("BusinessTypeID")) Then
                Return CInt(ViewState("BusinessTypeID"))
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("BusinessTypeID") = value
        End Set
    End Property

    Public Sub LoadData()
        If FranchiseID > 0 Then
            Dim oFranchise As New smt_Franchise(FranchiseID)
            If Not IsNothing(oFranchise) AndAlso oFranchise.FranchiseID > 0 Then
                Me.txtAddress1.Text = oFranchise.Address1
                Me.txtAddress2.Text = oFranchise.Address2
                Me.txtState.Text = oFranchise.State
                Me.txtZipCode.Text = oFranchise.ZipCode
                Me.txtPhoneNumber.Text = oFranchise.PhoneNumber
                Me.txtEmailAddress.Text = oFranchise.EmailAddress
                Me.txtNumberOfEmployees.Text = "0"
                Me.txtWebsiteAddress.Text = oFranchise.WebsiteAddress
                BusinessTypeID = oFranchise.BusinessTypeID
            End If
        Else
            Me.txtAddress1.Text = ""
            Me.txtAddress2.Text = ""
            Me.txtState.Text = ""
            Me.txtZipCode.Text = ""
            Me.txtPhoneNumber.Text = ""
            Me.txtEmailAddress.Text = ""
            Me.txtNumberOfEmployees.Text = "0"
            Me.txtWebsiteAddress.Text = ""
        End If
    End Sub


    Public Function IsValidate() As Boolean
        Me.lblError.Text = ""
        Me.lblError.Visible = True


        If Me.txtAddress1.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter franchise address line 1."
            Return False
        End If
        If Me.txtAddress2.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter franchise address line 2"
            Return False
        End If
        If Me.txtState.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter state."
            Return False
        End If
        If Me.txtZipCode.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter zip code."
            Return False
        End If
        If Me.txtPhoneNumber.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter telephone number."
            Return False
        End If
        If Me.txtEmailAddress.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter email address."
            Return False
        End If
        If Me.txtNumberOfEmployees.Text.Trim.Length = 0 AndAlso Not IsNumeric(Me.txtNumberOfEmployees.Text.Trim) Then
            Me.lblError.Text = "Enter Number of Employees"
            Return False
        End If
        If Me.txtWebsiteAddress.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter website address."
            Return False
        End If

        Me.lblError.Visible = True
        Return True
    End Function
    Public Sub SaveData()
        If BusinessTypeID > 0 Then
            Dim oFranchise As New smt_Franchise(FranchiseID)
            If IsNothing(oFranchise) OrElse oFranchise.FranchiseID > 0 Then
                oFranchise = New smt_Franchise()
            End If
            oFranchise.BusinessTypeID = BusinessTypeID
            oFranchise.Address1 = Me.txtAddress1.Text
            oFranchise.Address2 = Me.txtAddress2.Text
            oFranchise.State = Me.txtState.Text
            oFranchise.ZipCode = Me.txtZipCode.Text
            oFranchise.PhoneNumber = Me.txtPhoneNumber.Text
            oFranchise.EmailAddress = Me.txtEmailAddress.Text
            oFranchise.NumberOfEmployees = Me.txtNumberOfEmployees.Text
            oFranchise.WebsiteAddress = Me.txtWebsiteAddress.Text
            oFranchise.save()
            FranchiseID = oFranchise.FranchiseID
        Else
            Me.lblError.Text = "Business information is not saved yet."
            Me.lblError.Visible = True
        End If
    End Sub


End Class
