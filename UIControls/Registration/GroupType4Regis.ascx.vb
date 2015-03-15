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

Partial Class UIControls_Registration_GroupType4Regis
    Inherits System.Web.UI.UserControl

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
        If UserID > 0 Then
            If Not IsUserRegisterToGroup(UserID) Then
                Me.tblForm.Visible = True
                Me.lblError.Visible = False
                Dim cui As New Users(UserID)
                If Not IsNothing(cui) AndAlso cui.UserID > 0 Then
                    Dim oGT4 As New smt_GroupType4
                    oGT4.LoadByUserID(UserID)
                    If Not IsNothing(oGT4) AndAlso oGT4.GroupType4ID > 0 Then
                        Me.txtCompanyName.Text = oGT4.CompanyName
                        Me.lblUsername.Text = cui.Username
                        Me.txtTaxID.Text = oGT4.TaxID
                        Me.txtWebsiteAddress.Text = oGT4.WebsiteAddress
                        Me.txtTelephoneNumber.Text = oGT4.TelephoneNumber
                        Me.txtDescription.Text = oGT4.Description.Trim
                        Me.txtAddress1.Text = oGT4.Address1
                        Me.txtAddress2.Text = oGT4.Address2
                        Me.txtCity.Text = oGT4.City
                        Me.txtZipCode.Text = oGT4.ZipCode
                        Me.txtUserType.Text = oGT4.UserType
                        Me.txtNumberOfEmployees.Text = oGT4.NumberOfEmployees
                        Me.txtAbout.Text = oGT4.About
                        Me.lblIndustry.Text = oGT4.IndustryName
                        Me.SelectIndustry1.Industry = oGT4.IndustryName
                        Me.SelectIndustry1.LoadData()
                        Me.ddState.SelectedValue = oGT4.GroupType
                        If Me.ddType.SelectedValue = "Charity" Then
                            Me.hidCharity.Value = oGT4.GroupTypeOption
                        ElseIf Me.ddType.SelectedValue = "Non Profit" Then
                            Me.hidNonProfit.Value = oGT4.GroupTypeOption
                        End If
                    End If
                End If
            Else
                Me.tblForm.Visible = False
                Me.lblError.Visible = True
                Me.lblError.Text = "You are already register to a group."
            End If
            ShowHideCharityNonProfit()
        Else
            Response.Redirect(UIHelper.GetBasePath & "/Login.aspx")
        End If
    End Sub
    Public Sub LoadProfile()
        LoadCountryState()
        If UserID > 0 Then

            Me.tblForm.Visible = True
            Me.lblError.Visible = False
            Dim cui As New Users(UserID)
            If Not IsNothing(cui) AndAlso cui.UserID > 0 Then
                Dim oGT4 As New smt_GroupType4
                oGT4.LoadByUserID(UserID)
                If Not IsNothing(oGT4) AndAlso oGT4.GroupType4ID > 0 Then
                    Me.mpIndustry.Hide()
                    Me.txtCompanyName.Text = oGT4.CompanyName
                    Me.lblUsername.Text = cui.Username
                    Me.txtTaxID.Text = oGT4.TaxID
                    Me.txtWebsiteAddress.Text = oGT4.WebsiteAddress
                    Me.txtTelephoneNumber.Text = oGT4.TelephoneNumber
                    Me.txtDescription.Text = oGT4.Description.Trim
                    Me.txtAddress1.Text = oGT4.Address1
                    Me.txtAddress2.Text = oGT4.Address2
                    Me.txtCity.Text = oGT4.City
                    Me.txtZipCode.Text = oGT4.ZipCode
                    Me.txtUserType.Text = oGT4.UserType
                    Me.txtNumberOfEmployees.Text = oGT4.NumberOfEmployees
                    Me.txtAbout.Text = oGT4.About
                    Me.lblIndustry.Text = oGT4.IndustryName
                    Me.SelectIndustry1.Industry = oGT4.IndustryName
                    Me.hidIndustry.Value = oGT4.IndustryName
                    Me.SelectIndustry1.LoadData()

                    If oGT4.CountryID = 271 Then
                        Me.ddState.Visible = True
                        Me.ddState.SelectedValue = oGT4.StateID
                    Else
                        Me.ddState.Visible = False
                    End If
                    If Me.ddType.SelectedValue = "Charity" Then
                        Me.hidCharity.Value = oGT4.GroupTypeOption
                        Me.lblCharity.Text = oGT4.GroupTypeOption
                        Me.hidNonProfit.Value = oGT4.GroupTypeOption
                        Me.SelectCharity1.Charity = oGT4.GroupTypeOption
                        Me.SelectCharity1.LoadData()
                    ElseIf Me.ddType.SelectedValue = "Non Profit" Then
                        Me.hidNonProfit.Value = oGT4.GroupTypeOption
                        Me.lblNonProfit.Text = oGT4.GroupTypeOption
                        Me.hidCharity.Value = oGT4.GroupTypeOption
                        Me.SelectNonProfit1.NonProfit = oGT4.GroupTypeOption
                        Me.SelectNonProfit1.LoadData()
                    End If


                    'profile image load
                    Me.trProfileImage.Visible = True
                    Me.imgProfile.ImageUrl = UIHelper.GetUserImageNew(UserID)

                    Me.trPrivacy.Visible = False
                    Me.ddCountry.Enabled = False
                    Me.ddState.Enabled = False
                    Me.ddType.Enabled = False
                    Me.txtZipCode.Enabled = False
                    Me.btnCharity.Enabled = False
                End If
            End If
            ShowHideCharityNonProfit()
        Else
            Response.Redirect(UIHelper.GetBasePath & "/Login.aspx")
        End If
    End Sub

    Public Sub SaveData()
        If UserID > 0 Then
            Dim cui As New Users(UserID)
            If Not IsNothing(cui) AndAlso cui.UserID > 0 Then
                Dim oGT4 As New smt_GroupType4
                oGT4.LoadByUserID(cui.UserID)
                If IsNothing(oGT4) OrElse oGT4.GroupType4ID = 0 Then
                    oGT4 = New smt_GroupType4()
                    oGT4.UserID = cui.UserID
                End If
                oGT4.CompanyName = Me.txtCompanyName.Text.Trim
                oGT4.TaxID = Me.txtTaxID.Text.Trim
                oGT4.WebsiteAddress = Me.txtWebsiteAddress.Text.Trim
                oGT4.TelephoneNumber = Me.txtTelephoneNumber.Text.Trim
                oGT4.Description = Me.txtDescription.Text.Trim
                oGT4.Address1 = Me.txtAddress1.Text.Trim
                oGT4.Address2 = Me.txtAddress2.Text.Trim
                oGT4.City = Me.txtCity.Text
                oGT4.ZipCode = Me.txtZipCode.Text
                oGT4.UserType = Me.txtUserType.Text.Trim
                oGT4.NumberOfEmployees = Me.txtNumberOfEmployees.Text.Trim
                oGT4.GroupType = Me.ddType.SelectedValue
                If Me.ddType.SelectedValue = "Charity" Then
                    oGT4.GroupTypeOption = Me.hidCharity.Value
                ElseIf Me.ddType.SelectedValue = "Non Profit" Then
                    oGT4.GroupTypeOption = Me.hidNonProfit.Value
                End If
                oGT4.UserID = UserID
                oGT4.CountryID = Me.ddCountry.SelectedValue
                If Me.ddState.Items.Count > 0 Then
                    oGT4.StateID = Me.ddState.SelectedValue
                    oGT4.State = Me.ddState.SelectedItem.Text
                End If
                oGT4.IndustryName = Me.hidIndustry.Value
                oGT4.About = Me.txtAbout.Text.Trim


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



                ' Response.Redirect("~/default.aspx")
                If oGT4.GroupType4ID = 0 Then
                    oGT4.save()
                    Dim UVID As Integer = 0
                    UVID = cui.UserGetWhiteWholeUnionverseID()
                    Dim arbrv As String = ""
                    arbrv = ReturnTypeArb(oGT4.GroupType)
                    cui.UnionVerseID = "WW-" & ((oGT4.CountryID - 271) + 1) & "-" & arbrv & "-" & oGT4.ZipCode & "-" & UVID + 1
                    cui.UserTypeID = CommonLibrary.Utility.eUserTypes.WhiteWholes
                    cui.RoleID = CommonLibrary.Utility.eUserRole.WhiteWholes
                    cui.Save()
                    EmailHelper.WhiteWholeRegistration(cui.UserID)
                    Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/Members/" & cui.Username & ".aspx")
                Else
                    oGT4.save()
                    Me.lblInfo.Visible = True
                    Me.lblInfo.Text = "information saved successfully!!!"
                End If


            End If
        End If
    End Sub
    Public Function IsValidate() As Boolean
        Me.lblError.Text = ""
        Me.lblError.Visible = True

        If Me.txtCompanyName.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Company Name."
            Return False
        End If
        If Me.txtTaxID.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter TaxID."
            Return False
        End If
        If Me.hidCharity.Value.Trim.Length = 0 And Me.hidNonProfit.Value.Trim.Length = 0 Then
            If Me.ddType.SelectedValue = "Charity" Then
                Me.lblError.Text = "Select Chartiy Type."
            Else
                Me.lblError.Text = "Select Non-Profit Type."
            End If

            Return False
        End If
        If Me.txtWebsiteAddress.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Website Address."
            Return False
        End If
        If Me.txtTelephoneNumber.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Telephone Number."
            Return False
        End If
        If Me.hidIndustry.Value.Trim.Length = 0 Then
            Me.lblError.Text = "Select industry."
            Return False
        End If
        If Me.txtDescription.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Description."
            Return False
        End If
        If Me.txtAddress1.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter HeadQuater Address Line 1."
            Return False
        End If

        If Me.txtCity.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter City."
            Return False
        End If
        If Me.txtZipCode.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Zip Code."
            Return False
        End If

        If Me.txtNumberOfEmployees.Text.Trim.Length = 0 AndAlso Not IsNumeric(Me.txtNumberOfEmployees.Text.Trim) Then
            Me.lblError.Text = "Enter Number of Employees (should be number)."
            Return False
        End If
        If Me.txtAbout.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter About."
            Return False
        End If
        'If Not IsNothing(Me.upAvatar.PostedFile) AndAlso Me.upAvatar.PostedFile.FileName.Trim.Length = 0 Then
        '    Me.lblError.Text = "Select image to upload."
        '    Return False
        'End If
        Dim oGT4 As New smt_GroupType4
        oGT4.LoadByUserID(UserID)
        If Not IsNothing(oGT4) AndAlso oGT4.GroupType4ID = 0 Then
            If Not chkPrivacy.Checked Then
                Me.lblError.Text = "Accept terms and conditions."
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
    Protected Sub btnIndustry_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIndustry.Click
        Me.mpIndustry.Show()
        Me.SelectIndustry1.Industry = Me.hidIndustry.Value
    End Sub

    Protected Sub SelectIndustry1_IndustrySelected(ByVal Industry As String) Handles SelectIndustry1.IndustrySelected
        Me.mpIndustry.Hide()
        hidIndustry.Value = Industry
        Me.lblIndustry.Text = Industry
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

        Dim oGT4 As New smt_GroupType4
        oGT4.LoadByUserID(UserID)
        If Not IsNothing(oGT4) AndAlso oGT4.GroupType4ID > 0 Then
            Return True
        End If

        Return False
    End Function

    Protected Sub ddCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddCountry.SelectedIndexChanged
        UIHelper.LoadStatesByCountry(Me.ddState, "-- Select State --", CInt(Me.ddCountry.SelectedValue))
        If Me.ddState.Items.Count = 0 Then
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

    Protected Sub btnCharity_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCharity.Click
        Me.mpCharity.Show()
    End Sub

    Protected Sub SelectCharity1_CharitySelected(ByVal str As String) Handles SelectCharity1.CharitySelected
        Me.mpCharity.Hide()
        Me.lblCharity.Text = str
        Me.hidCharity.Value = str
    End Sub
    Protected Sub btnNonProfit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNonProfit.Click
        Me.mpNonProfit.Show()
    End Sub

    Protected Sub SelectNonProfit1_NonProfitSelected(ByVal str As String) Handles SelectNonProfit1.NonProfitSelected
        Me.mpNonProfit.Hide()
        Me.lblNonProfit.Text = str
        Me.hidNonProfit.Value = str
    End Sub

    Protected Sub ddType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddType.SelectedIndexChanged
        ShowHideCharityNonProfit()
    End Sub
    Public Sub ShowHideCharityNonProfit()
        Me.trCharity.Visible = False
        Me.trNonProfit.Visible = False
        If Me.ddType.SelectedValue = "Charity" Then
            Me.trCharity.Visible = True
        ElseIf Me.ddType.SelectedValue = "Non Profit" Then
            Me.trNonProfit.Visible = True
        End If
    End Sub

    Public Function ReturnTypeArb(ByVal str As String) As String
        If str = "Charity" Then
            Return "CH"
        ElseIf str = "Non Profit" Then
            Return "NP"
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
End Class
