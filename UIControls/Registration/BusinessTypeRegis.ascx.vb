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
Imports System.IO

Partial Class CMSModules_Membership_Controls_BusinessTypeRegis
    Inherits System.Web.UI.UserControl
    Public Property ParentUserID As Integer
        Get
            If Not IsNothing(ViewState("ParentUserID")) AndAlso IsNumeric(ViewState("ParentUserID")) Then
                Return CInt(ViewState("ParentUserID"))
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("ParentUserID") = value
        End Set
    End Property

    Public Property UserID() As Integer
        Get
            If Not IsNothing(ViewState("UserID")) AndAlso IsNumeric(ViewState("UserID")) Then
                Return CInt(ViewState("UserID"))
            Else
                If Not IsNothing(Session("Users")) AndAlso CType(Session("Users"), Users).UserID Then
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
        LoadCountryState()
        Me.trFranchiseLink.Visible = False
        If UserID > 0 Then
            Me.FranchiseAddEdit1.Visible = False
            If Not IsUserRegisterToGroup(UserID) Then
                tblForm.Visible = True
                Me.lblError.Visible = False

                Dim cui As New Users(UserID)
                If Not IsNothing(cui) AndAlso cui.UserID > 0 Then
                    Me.txtUserName.Text = cui.Username

                    Dim oBusiness As New smt_BusinessType
                    oBusiness.LoadByUserID(UserID)

                    If Not IsNothing(oBusiness) AndAlso oBusiness.BusinessTypeID > 0 Then
                        Me.txtCompanyName.Text = oBusiness.CompanyName
                        Me.txtTaxID.Text = oBusiness.TaxID
                        Me.txtWebsiteAddress.Text = oBusiness.WebsiteAddress
                        Me.txtAddress1.Text = oBusiness.Address1
                        Me.txtAddress2.Text = oBusiness.Address2
                        Me.txtCity.Text = oBusiness.City
                        Me.txtZipCode.Text = oBusiness.ZipCode

                        Me.txtTelephoneNumber.Text = oBusiness.TelephoneNumber
                        Me.txtPersonalEmail.Text = oBusiness.PersonalEmail
                        Me.txtNumberofEmployees.Text = oBusiness.NumberOfEmployees
                        Me.chkIsViewable.Checked = oBusiness.IsViewable

                        Me.chkNoStore.Checked = oBusiness.UseStore
                        Me.lblIndustry.Text = oBusiness.Industry
                        Me.SelectIndustry1.Industry = oBusiness.Industry
                        Me.SelectIndustry1.LoadData()
                        Me.trFranchise.Visible = True

                    Else
                        Me.txtCompanyName.Text = ""
                        If ParentUserID > 0 Then
                            Me.trFranchise.Visible = False
                            Me.rpParentOrFranchise.SelectedValue = 1  ' 1 is for Franchise and 0 is for Parent Company.
                            Me.trMainFranchise.Visible = False
                            Me.trFranchiseLink.Visible = False
                        End If
                    End If
                End If
            Else
                Me.tblForm.Visible = False
                Me.lblError.Visible = True
                Me.lblError.Text = "You are already registered to a group."

            End If

        Else
            Response.Redirect(UIHelper.GetBasePath() & "/Login.aspx")
        End If
        If rbCompanyType.SelectedValue = "1" Then
            Me.trIndustry.Visible = True
        Else
            Me.trIndustry.Visible = False
        End If
        ShowHideStoreType()
    End Sub


    Public Sub Loadprofile()
        LoadCountryState()
        If UserID > 0 Then
            Me.spnCancel.Visible = False
            Me.FranchiseAddEdit1.Visible = False

            tblForm.Visible = True
            Me.lblError.Visible = False

            Dim cui As New Users(UserID)
            If Not IsNothing(cui) AndAlso cui.UserID > 0 Then
                Me.txtUserName.Text = cui.Username

                Dim oBusiness As New smt_BusinessType
                oBusiness.LoadByUserID(UserID)

                If Not IsNothing(oBusiness) AndAlso oBusiness.BusinessTypeID > 0 Then
                    Me.mpIndustry.Hide()
                    Me.txtUserName.Text = cui.Username
                    Me.txtCompanyName.Text = oBusiness.CompanyName
                    Me.txtTaxID.Text = oBusiness.TaxID
                    Me.txtWebsiteAddress.Text = oBusiness.WebsiteAddress
                    Me.txtAddress1.Text = oBusiness.Address1
                    Me.txtAddress2.Text = oBusiness.Address2
                    Me.txtCity.Text = oBusiness.City
                    Me.txtZipCode.Text = oBusiness.ZipCode

                    'Me.ddState.SelectedValue = oBusiness.StateID
                    Me.txtTelephoneNumber.Text = oBusiness.TelephoneNumber
                    Me.txtPersonalEmail.Text = oBusiness.PersonalEmail
                    Me.txtNumberofEmployees.Text = oBusiness.NumberOfEmployees
                    Me.chkIsViewable.Checked = oBusiness.IsViewable
                    Me.rpParentOrFranchise.SelectedValue = oBusiness.ParentBusinessTypeID
                    Me.chkNoStore.Checked = oBusiness.UseStore
                    Me.lblIndustry.Text = oBusiness.Industry
                    Me.SelectIndustry1.Industry = oBusiness.Industry
                    Me.hidIndustry.Value = oBusiness.Industry
                    Me.SelectIndustry1.LoadData()
                    Me.rbFranchise.SelectedValue = oBusiness.IsFranchise
                    Me.txtContactPerson.Text = oBusiness.ContactPerson
                    Me.ddCountry.SelectedValue = oBusiness.CountryID
                    If oBusiness.CountryID = 271 Then
                        Me.ddState.Visible = True
                        Me.ddState.SelectedValue = oBusiness.StateID
                    Else
                        Me.ddState.Visible = False
                    End If

                    Me.rbCompanyType.SelectedValue = oBusiness.CompanyTypeID

                    Me.trIndustry.Visible = False
                    Me.rbStoreType.Visible = False
                    Me.rbBusinessType.Visible = False
                    Me.trGeo.Visible = False
                    Me.trboth.Visible = False
                    Me.trNonGeo.Visible = False
                    Me.trUnionVerse.Visible = False
                    Me.trIndSpecific.Visible = False
                    Me.rbBusinessType.Visible = False
                    Me.trEcommerce.Visible = False
                    If oBusiness.CompanyTypeID = "1" Then

                        Me.trIndustry.Visible = True
                        Me.rbStoreType.Visible = True
                        Me.trEcommerce.Visible = True
                        Me.rbStoreType.SelectedValue = oBusiness.StoreTypeID
                        If oBusiness.StoreTypeID = "1" Then
                            Me.hidGeo.Value = oBusiness.StoreType
                            lblGeo.Text = oBusiness.StoreType
                            Me.Geographical1.Geographical = oBusiness.StoreType
                            Me.Geographical1.LoadData()
                            Me.trGeo.Visible = True

                        ElseIf oBusiness.StoreTypeID = "2" Then
                            Me.hidNonGeo.Value = oBusiness.StoreType
                            lblNonGeo.Text = oBusiness.StoreType
                            Me.NonGeographical1.NonGeographical = oBusiness.StoreType
                            Me.NonGeographical1.LoadData()
                            Me.trNonGeo.Visible = True

                        ElseIf oBusiness.StoreTypeID = "3" Then
                            Me.hidBoth.Value = oBusiness.StoreType
                            lblBoth.Text = oBusiness.StoreType
                            Me.BothGeoNonGeo1.BothGeoNonGeo = oBusiness.StoreType
                            Me.BothGeoNonGeo1.LoadData()
                            Me.trboth.Visible = True
                        End If
                    Else
                        Me.rbBusinessType.Visible = True
                        Me.trEcommerce.Visible = False

                        Me.rbBusinessType.SelectedValue = oBusiness.StoreTypeID
                        If oBusiness.StoreTypeID = "1" Then
                            Me.hdnUnionverse.Value = oBusiness.StoreType
                            lblUnionverse.Text = oBusiness.StoreType
                            Me.Unionversal.UnionVersal = oBusiness.StoreType
                            Me.Unionversal.LoadData()
                            Me.trUnionVerse.Visible = True
                            Me.trGeo.Visible = False
                        ElseIf oBusiness.StoreTypeID = "2" Then
                            Me.hdnIndSpecific.Value = oBusiness.StoreType
                            lblIndSpecific.Text = oBusiness.StoreType
                            Me.IndustrySpecific.IndustrySpecific = oBusiness.StoreType
                            Me.IndustrySpecific.LoadData()
                            Me.trIndSpecific.Visible = True

                        End If
                    End If

                    Me.txtAbout.Text = oBusiness.About

                    Me.trMainFranchise.Visible = False
                    Me.trFranchise.Visible = False
                    Me.ddCountry.Enabled = False
                    Me.ddState.Enabled = False
                    Me.txtZipCode.Enabled = False
                    Me.trPrivacy.Visible = False
                    Me.rbCompanyType.Enabled = False

                    Me.rbStoreType.Enabled = False
                    Me.rbBusinessType.Enabled = False
                    Me.btnGeo.Enabled = False
                    Me.btnNonGeo.Enabled = False
                    Me.btnBoth.Enabled = False
                    Me.btnUnionVerse.Enabled = False
                    Me.btnIndSpecific.Enabled = False
                    'profile image load
                    Me.trProfileImage.Visible = True
                    Me.imgProfile.ImageUrl = UIHelper.GetUserImageNew(UserID)
                    Me.trFranchiseLink.Visible = False
                    If oBusiness.ParentUserID > 0 Then
                        Me.trFranchise.Visible = False
                        Me.rpParentOrFranchise.SelectedValue = 1  ' 1 is for Franchise and 0 is for Parent Company.

                    Else
                        Me.trMainFranchise.Visible = True
                        If oBusiness.IsFranchise = 0 Then
                            Me.trFranchise.Visible = True
                            Me.rbFranchise.Enabled = False
                            Me.trFranchiseLink.Visible = True
                            Me.rpParentOrFranchise.Enabled = False
                            Me.rpParentOrFranchise.SelectedValue = 0
                            Me.lblfranchiseLink.Text = UIHelper.GetBasePath() & "/members/" & cui.Username & "/addfranchise.aspx"
                        End If
                    End If
                Else

                End If
            End If

        Else
            Response.Redirect(UIHelper.GetBasePath() & "/Login.aspx")
        End If
        If rbCompanyType.SelectedValue = "1" Then
            Me.trIndustry.Visible = True
        Else
            Me.trIndustry.Visible = False
        End If
        'ShowHideStoreType()
    End Sub
    Public Sub SaveData()
        If UserID > 0 Then
            Dim cui As New Users(UserID)
            If Not IsNothing(cui) AndAlso cui.UserID > 0 Then
                Dim oBusiness As New smt_BusinessType
                oBusiness.LoadByUserID(cui.UserID)
                If IsNothing(oBusiness) OrElse oBusiness.BusinessTypeID = 0 Then
                    oBusiness = New smt_BusinessType()
                    oBusiness.UserID = cui.UserID
                    If ParentUserID > 0 Then
                        Dim oPBU As New smt_BusinessType
                        oPBU.LoadByUserID(ParentUserID)
                        If Not IsNothing(oPBU) AndAlso oPBU.BusinessTypeID > 0 Then
                            oBusiness.ParentUserID = oPBU.UserID
                            oBusiness.ParentBusinessTypeID = oPBU.BusinessTypeID
                        End If
                    Else
                        oBusiness.IsFranchise = rbFranchise.SelectedValue
                       
                    End If
                End If
                oBusiness.CompanyName = Me.txtCompanyName.Text.Trim
                oBusiness.TaxID = Me.txtTaxID.Text.Trim
                oBusiness.WebsiteAddress = Me.txtWebsiteAddress.Text.Trim
                oBusiness.Address1 = Me.txtAddress1.Text.Trim
                oBusiness.Address2 = Me.txtAddress2.Text.Trim
                oBusiness.City = Me.txtCity.Text.Trim
                oBusiness.ZipCode = Me.txtZipCode.Text.Trim
                oBusiness.TelephoneNumber = Me.txtTelephoneNumber.Text.Trim
                oBusiness.PersonalEmail = Me.txtPersonalEmail.Text.Trim
                oBusiness.NumberOfEmployees = Me.txtNumberofEmployees.Text.Trim
                oBusiness.IsViewable = Me.chkIsViewable.Checked
                oBusiness.ContactPerson = Me.txtContactPerson.Text

                oBusiness.Industry = Me.hidIndustry.Value
                oBusiness.CompanyTypeID = Me.rbCompanyType.SelectedValue
                oBusiness.CompanyType = Me.rbCompanyType.SelectedItem.Text

                If Me.rbCompanyType.SelectedValue = "1" Then
                    oBusiness.StoreTypeID = Me.rbStoreType.SelectedValue

                    If Me.rbStoreType.SelectedValue = "1" Then
                        oBusiness.StoreType = Me.hidGeo.Value
                    ElseIf Me.rbStoreType.SelectedValue = "2" Then
                        oBusiness.StoreType = Me.hidNonGeo.Value
                    ElseIf Me.rbStoreType.SelectedValue = "3" Then
                        oBusiness.StoreType = Me.hidBoth.Value
                    End If
                Else
                    oBusiness.StoreTypeID = Me.rbBusinessType.SelectedValue
                    If Me.rbBusinessType.SelectedValue = "1" Then
                        oBusiness.StoreType = Me.hdnUnionverse.Value
                    ElseIf Me.rbBusinessType.SelectedValue = "2" Then
                        oBusiness.StoreType = Me.hdnIndSpecific.Value
                    End If

                End If

                oBusiness.About = Me.txtAbout.Text.Trim


                oBusiness.CountryID = Me.ddCountry.SelectedValue
                If Me.ddState.Items.Count > 0 Then
                    oBusiness.StateID = Me.ddState.SelectedValue
                    oBusiness.State = Me.ddState.SelectedItem.Text
                End If
                oBusiness.UseStore = Me.chkNoStore.Checked


                If hdnImage.Value = "1" And cui.ProfileImage.Trim.Length > 0 Then
                    Dim path As String
                    path = Server.MapPath("~/" & cui.ProfileImage.Trim)
                    If File.Exists(path) Then
                        File.Delete(path)
                        cui.ProfileImage = String.Empty
                        cui.Save()
                    End If
                End If

                Dim str As String
                str = SaveProfileImage()
                If str.Trim.Length > 0 Then
                    cui.ProfileImage = str
                    cui.Save()
                End If


                If oBusiness.BusinessTypeID = 0 Then
                    oBusiness.save()
                    Dim UVID As Integer = 0
                    UVID = cui.UserGetMaxCompanyUnionverseID()
                    cui.UnionVerseID = "UV-" & ((oBusiness.CountryID - 271) + 1) & "-" & ReturnCompanyTypeAbri(oBusiness.CompanyTypeID) & "-" & oBusiness.ZipCode & "-" & ReturnStoreTypeAbri(oBusiness.StoreTypeID) & "-" & UVID + 1
                    cui.UserTypeID = CommonLibrary.Utility.eUserTypes.BusinessUser
                    cui.RoleID = CommonLibrary.Utility.eUserRole.BusinessUser
                    cui.FirstName = oBusiness.CompanyName
                    cui.Status = 1
                    cui.Save()
                    EmailHelper.BusinessRegistration(cui.UserID)
                    Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/Members/" & cui.Username & ".aspx")
                Else
                    oBusiness.save()
                    Me.lblInfo.Visible = True
                    Me.lblInfo.Text = "information saved successfully!!!"
                    Me.imgProfile.ImageUrl = UIHelper.GetUserImageNew(UserID)
                    Dim b As UserControl = Page.Master.FindControl("SideMenu1")
                    CType(b.FindControl("imgProfile"), HtmlImage).Src = UIHelper.GetUserImageNew(UserID)
                End If

                Me.lblInfo.Visible = True

                Me.FranchiseAddEdit1.Visible = True
                Me.FranchiseAddEdit1.BusinessTypeID = oBusiness.BusinessTypeID
                Me.FranchiseAddEdit1.LoadData()


            End If
        End If
    End Sub
    Public Function IsValidate() As Boolean
        Me.lblError.Text = ""
        Me.lblError.Visible = True
        If Me.txtCompanyName.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter company name"
            Return False
        End If
        If Me.txtTaxID.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Tax ID"
            Return False
        End If
        If Me.txtWebsiteAddress.Text.Length = 0 Then
            Me.lblError.Text = "Enter website address"
            Return False
        End If
        If Me.txtAddress1.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter address 1"
            Return False
        End If
        If Me.txtCity.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter city"
            Return False
        End If
        If Me.txtZipCode.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter zip code"
            Return False
        End If
        If Me.txtTelephoneNumber.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter telephone number."
            Return False
        End If
        If Me.txtPersonalEmail.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter personal email."
            Return False
        End If
        If Me.txtNumberofEmployees.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter number of employees."
            Return False
        End If
        If Not IsNumeric(Me.txtNumberofEmployees.Text) Then
            Me.lblError.Text = "Number of employees should be numeric."
            Return False
        End If
        If Me.rbFranchise.SelectedIndex = -1 Then
            Me.lblError.Text = "Select are you franchise or not."
            Return False
        End If
        If Me.rbCompanyType.SelectedValue = "1" AndAlso Me.hidIndustry.Value.Trim.Length = 0 Then
            Me.lblError.Text = "Select industry."
            Return False
        End If
        If Me.rbCompanyType.SelectedValue = "1" AndAlso Me.rbStoreType.SelectedValue = "1" AndAlso Me.hidGeo.Value.Trim.Length = 0 Then
            Me.lblError.Text = "Select from Geographical Type."
            Return False
        End If
        If Me.rbCompanyType.SelectedValue = "1" AndAlso Me.rbStoreType.SelectedValue = "2" AndAlso Me.hidNonGeo.Value.Trim.Length = 0 Then
            Me.lblError.Text = "Select from Non-Geographical Type."
            Return False
        End If
        If Me.rbCompanyType.SelectedValue = "1" AndAlso Me.rbStoreType.SelectedValue = "3" AndAlso Me.hidBoth.Value.Trim.Length = 0 Then
            Me.lblError.Text = "Select from Both Type."
            Return False
        End If
        If Me.rbCompanyType.SelectedValue = "2" AndAlso Me.rbBusinessType.SelectedValue = "1" AndAlso Me.hdnUnionverse.Value.Trim.Length = 0 Then
            Me.lblError.Text = "Select from Unionverse Type."
            Return False
        End If
        If Me.rbCompanyType.SelectedValue = "2" AndAlso Me.rbBusinessType.SelectedValue = "2" AndAlso Me.hdnIndSpecific.Value.Trim.Length = 0 Then
            Me.lblError.Text = "Select from Industry Specific Type."
            Return False
        End If

        If Me.rbFranchise.SelectedValue = "0" And rpParentOrFranchise.SelectedValue = "1" Then
            Me.lblError.Text = " Please register via the url that you would recieve from your parent company to be " & _
                "added as a Franchise to your parent companies list of Franchises."
            Return False
        End If
        'If Not IsNothing(Me.upAvatar.PostedFile) AndAlso Me.upAvatar.PostedFile.FileName.Trim.Length = 0 Then
        '    Me.lblError.Text = "Select image to upload."
        '    Return False
        'End If
        Dim oBusiness As New smt_BusinessType
        oBusiness.LoadByUserID(UserID)
        If IsNothing(oBusiness) OrElse oBusiness.BusinessTypeID = 0 Then
            If Me.chkPrivacy.Checked = False Then
                Me.lblError.Text = "You must have to agree with UNIonVERSE Terms."
                Return False
            End If
        End If

        Me.lblError.Text = ""
        Me.lblError.Visible = False
        Return True
    End Function


    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click, lbtSave.Click
        If IsValidate() Then
            SaveData()
        End If
    End Sub


    Public Function IsUserRegisterToGroup(ByVal UserID As Integer) As Boolean
        Dim oB As New smt_BusinessType()
        oB.LoadByUserID(UserID)
        If Not IsNothing(oB) AndAlso oB.BusinessTypeID > 0 Then
            Return True
        End If

        Dim oS As New smt_School
        oS.LoadByUserID(UserID)
        If Not IsNothing(oS) AndAlso oS.SchoolID > 0 Then
            Return True
        End If

        Dim oUT1 As New smt_UserType1
        oUT1.LoadByUserID(UserID)
        If Not IsNothing(oUT1) AndAlso oUT1.UserType1ID > 0 Then
            Return True
        End If

        Dim oIU1T1 As New smt_IndividualUserType1
        oIU1T1.LoadByUserID(UserID)
        If Not IsNothing(oIU1T1) AndAlso oIU1T1.IndividualUserType1ID > 0 Then
            Return True
        End If

        Dim oIU2T1 As New smt_IndividualUserType2
        oIU2T1.LoadByUserID(UserID)
        If Not IsNothing(oIU2T1) AndAlso oIU2T1.IndividualUserType2ID Then
            Return True
        End If
        Return False
    End Function


    Protected Sub btnIndustry_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIndustry.Click
        Me.mpIndustry.Show()
        Me.SelectIndustry1.Industry = Me.hidIndustry.Value
    End Sub

    Protected Sub SelectIndustry1_IndustrySelected(ByVal Industry As String) Handles SelectIndustry1.IndustrySelected
        Me.mpIndustry.Hide()
        hidIndustry.Value = Industry
        Me.lblIndustry.Text = Industry
    End Sub

    Protected Sub rbCompanyType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbCompanyType.SelectedIndexChanged
        If Me.rbCompanyType.SelectedValue = "1" Then   'Business to Consumer
            Me.trIndustry.Visible = True
            Me.rbStoreType.Visible = True
            Me.rbBusinessType.Visible = False
            Me.trGeo.Visible = True
            Me.trboth.Visible = False
            Me.trNonGeo.Visible = False
            Me.trUnionVerse.Visible = False
            Me.trIndSpecific.Visible = False
            Me.trEcommerce.Visible = True
            Me.rbStoreType.SelectedValue = "1"
        Else
            Me.trIndustry.Visible = False
            Me.rbStoreType.Visible = False
            Me.rbBusinessType.Visible = True
            Me.trGeo.Visible = False
            Me.trboth.Visible = False
            Me.trNonGeo.Visible = False
            Me.trUnionVerse.Visible = True
            Me.trIndSpecific.Visible = False
            Me.trEcommerce.Visible = False
            Me.chkNoStore.Checked = False
            Me.rbBusinessType.SelectedValue = "1"
        End If
    End Sub

    Protected Sub rbStoreType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbStoreType.SelectedIndexChanged
        ShowHideStoreType()
    End Sub

    Public Sub ShowHideStoreType()
        Me.trGeo.Visible = False
        Me.trboth.Visible = False
        Me.trNonGeo.Visible = False

        If Me.rbStoreType.SelectedValue = "1" Then
            Me.trGeo.Visible = True
        ElseIf Me.rbStoreType.SelectedValue = "2" Then
            Me.trNonGeo.Visible = True
        ElseIf Me.rbStoreType.SelectedValue = "3" Then
            Me.trboth.Visible = True
        End If
    End Sub

    Protected Sub btnGeo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGeo.Click
        Me.mpGeo.Show()
    End Sub
    Protected Sub Geographical1_GeographicalSelected(ByVal Value As String) Handles Geographical1.GeographicalSelected
        Me.mpGeo.Hide()
        Me.lblGeo.Text = Value
        Me.hidGeo.Value = Value
    End Sub
    Protected Sub btnNonGeo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNonGeo.Click
        Me.mpNonGeo.Show()
    End Sub
    Protected Sub NonGeographical1_NonGeographicalSelected(ByVal str As String) Handles NonGeographical1.NonGeographicalSelected
        Me.mpNonGeo.Hide()
        Me.lblNonGeo.Text = str
        Me.hidNonGeo.Value = str
    End Sub
    Protected Sub btnBoth_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBoth.Click
        Me.mpBoth.Show()
    End Sub
    Protected Sub BothGeoNonGeo1_BothGeoNonGeoSelected(ByVal Value As String) Handles BothGeoNonGeo1.BothGeoNonGeoSelected
        Me.mpBoth.Hide()
        Me.lblBoth.Text = Value
        Me.hidBoth.Value = Value
    End Sub



    Protected Sub Unionversal1_BothGeoNonGeoSelected(ByVal Value As String) Handles Unionversal.GeographicalSelected
        Me.mpeUnionverse.Hide()
        Me.lblUnionverse.Text = Value
        Me.hdnUnionverse.Value = Value
    End Sub

    Protected Sub IndustrySpecific1_BothGeoNonGeoSelected(ByVal Value As String) Handles IndustrySpecific.GeographicalSelected
        Me.mpeIndSpecific.Hide()
        Me.lblIndSpecific.Text = Value
        Me.hdnIndSpecific.Value = Value
    End Sub



    Protected Sub ddCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddCountry.SelectedIndexChanged
        UIHelper.LoadStatesByCountry(Me.ddState, "-- Select State --", CInt(Me.ddCountry.SelectedValue))
        If Me.ddCountry.SelectedValue <> "271" Then
            Me.ddState.Visible = False
        Else
            Me.ddState.Visible = True
        End If
    End Sub
    Public Sub LoadCountryState()
        UIHelper.LoadCountry(Me.ddCountry, "--Select Country")
        Me.ddCountry.SelectedValue = "271"

        UIHelper.LoadStatesByCountry(Me.ddState, "-- Select State --", CInt(Me.ddCountry.SelectedValue))
        If Me.ddState.Items.Count = 0 Then
            Me.ddState.Visible = False
        Else
            Me.ddState.Visible = True
        End If

    End Sub
    Public Function ReturnStoreTypeAbri(ByVal StoreTypeID As Integer) As String
        If StoreTypeID = 1 Then
            Return "SS"
        ElseIf StoreTypeID = 2 Then
            Return "FP"
        ElseIf StoreTypeID = 3 Then
            Return "MSS"
        Else
            Return ""
        End If
    End Function
    Public Function ReturnCompanyTypeAbri(ByVal CompanyTypeID As Integer) As String
        If CompanyTypeID = 1 Then
            Return "B"
        ElseIf CompanyTypeID = 2 Then
            Return "B"
        Else
            Return ""
        End If
    End Function
    Public Function SaveProfileImage() As String
        If Me.upAvatar.FileName.Trim.Length > 0 Then
            Dim str As String = ""
            Dim fPath As String = upAvatar.PostedFile.FileName
            Dim filename As String = fPath.Substring(fPath.LastIndexOf("\") + 1)
            Dim Name As String = filename.Substring(0, filename.LastIndexOf("."))
            Dim type As String = filename.Substring(filename.LastIndexOf("."))
            Dim path As String = Server.MapPath(Request.ApplicationPath) & "/UserFiles/"
            If Not (IO.Directory.Exists(path)) Then
                IO.Directory.CreateDirectory(path)
            End If
            path = Server.MapPath(Request.ApplicationPath) & "/UserFiles/Profiles/"
            If Not (IO.Directory.Exists(path)) Then
                IO.Directory.CreateDirectory(path)
            End If
            'upAvatar.SaveAs(path & UserID & "_" & Name & "_img" & type)
            str = "UserFiles/Profiles/" & UserID & "_" & Name & "_img" & type

            Dim filetype As String = upAvatar.FileName.Substring(upAvatar.FileName.IndexOf("."))
            Dim oUI As New UIHelper
            Dim thumbnail As System.Drawing.Bitmap = oUI.CreateThumbNailWhiteBack(New Drawing.Bitmap(upAvatar.PostedFile.InputStream, False), 178, 235)
            thumbnail.Save(Server.MapPath(Request.ApplicationPath) & "/UserFiles/Profiles/" & UserID & "_" & Name & "_img" & type)
            Return str
        Else
            Return ""
        End If
    End Function


    Protected Sub btnRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Me.imgProfile.Visible = False
        Me.hdnImage.Value = "1"
    End Sub

    Protected Sub rbBusinessType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbBusinessType.SelectedIndexChanged
        Me.trUnionVerse.Visible = False
        Me.trIndSpecific.Visible = False


        If Me.rbBusinessType.SelectedValue = "1" Then
            Me.trUnionVerse.Visible = True
        ElseIf Me.rbBusinessType.SelectedValue = "2" Then
            Me.trIndSpecific.Visible = True
        End If
    End Sub
    Protected Sub lbtCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtCancel.Click
        Session("Users") = Nothing
        Response.Redirect(UIHelper.GetBasePath() & "/Login.aspx")
    End Sub
End Class
