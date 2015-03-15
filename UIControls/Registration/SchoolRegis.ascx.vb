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

Partial Class UIControls_Regsitration_SchoolRegis
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
                Dim cui As New Users(UserID)
                If Not IsNothing(cui) AndAlso cui.UserID > 0 Then
                    'Me.txtSchoolName.Text = cui.Username
                    Dim oSchool As New smt_School
                    oSchool.LoadByUserID(UserID) ' Supply Connection String here.
                    If Not IsNothing(oSchool) AndAlso oSchool.SchoolID > 0 Then
                        Me.ddSelectType.SelectedValue = oSchool.Types
                        Me.txtSchoolName.Text = oSchool.SchoolName
                        Me.txtContactPerson.Text = oSchool.ContactPerson
                        Me.txtEmail.Text = oSchool.Email
                        Me.txtContactPhone.Text = oSchool.ContactPhone
                        Me.txtWebsiteAddress.Text = oSchool.WebsiteAddress
                        Me.txtTelephoneNumber.Text = oSchool.TelephoneNumber
                        Me.txtDescription.Text = oSchool.Description
                        Me.txtAddress1.Text = oSchool.Address1
                        Me.txtAlternativeAddress2.Text = oSchool.Address2
                        Me.txtCity.Text = oSchool.City
                        Me.txtZipCode.Text = oSchool.ZipCode
                        Me.txtAlternativeAddress1.Text = oSchool.AlternateAddress1
                        Me.txtAlternativeAddress2.Text = oSchool.AlternateAddress2
                        Me.txtCity2.Text = oSchool.City2
                        Me.txtAlternativeZipCode.Text = oSchool.ZipCode
                        Me.ddEducationlevel.SelectedValue = oSchool.EducationLevel
                        Me.txtStatus.Text = oSchool.Status
                        Me.txtHoursofOperation.Text = oSchool.HoursOfOperation
                        Me.txtAbout.Text = oSchool.About
                        Me.txtNumberofEmployees.Text = oSchool.NumberOfEmployees
                        Me.chkIsViewable.Checked = oSchool.IsViewable
                        Me.hidIndustry.Value = oSchool.IndustryName
                        Me.ddSelectType.SelectedValue = oSchool.Types
                        Me.ddMediaType.SelectedValue = oSchool.MediaType
                        Me.ddGovtType.SelectedValue = oSchool.GovtType
                    End If
                End If
            Else
                Me.tblForm.Visible = False
                Me.lblError.Visible = True
                Me.lblError.Text = "User are already registered to a group."
            End If
        End If
        ShowHideSections()
        Me.SelectIndustry1.LoadData()
    End Sub

    Public Sub LoadProfile()
        LoadCountryState()

        'Me.trPrivacy.Visible = False
        If UserID > 0 Then
            Me.spnCancel.Visible = False
            Dim cui As New Users(UserID)
            If Not IsNothing(cui) AndAlso cui.UserID > 0 Then
                'Me.txtSchoolName.Text = cui.Username
                Me.tblForm.Visible = True
                Dim oSchool As New smt_School
                oSchool.LoadByUserID(UserID) ' Supply Connection String here.
                If Not IsNothing(oSchool) AndAlso oSchool.SchoolID > 0 Then
                    Me.mpIndustry.Hide()
                    Me.ddSelectType.SelectedValue = oSchool.Types
                    Me.txtSchoolName.Text = oSchool.SchoolName
                    Me.txtContactPerson.Text = oSchool.ContactPerson
                    Me.txtEmail.Text = oSchool.Email
                    Me.txtContactPhone.Text = oSchool.ContactPhone
                    Me.txtWebsiteAddress.Text = oSchool.WebsiteAddress
                    Me.txtTelephoneNumber.Text = oSchool.TelephoneNumber
                    Me.txtDescription.Text = oSchool.Description
                    Me.txtAddress1.Text = oSchool.Address1
                    Me.txtAlternativeAddress2.Text = oSchool.Address2
                    Me.txtCity.Text = oSchool.City
                    Me.txtZipCode.Text = oSchool.ZipCode
                    Me.txtAlternativeAddress1.Text = oSchool.AlternateAddress1
                    Me.txtAlternativeAddress2.Text = oSchool.AlternateAddress2
                    Me.txtCity2.Text = oSchool.City2
                    Me.txtAlternativeZipCode.Text = oSchool.ZipCode
                    Me.ddEducationlevel.SelectedValue = oSchool.EducationLevel
                    Me.txtStatus.Text = oSchool.Status
                    Me.txtHoursofOperation.Text = oSchool.HoursOfOperation
                    Me.txtAbout.Text = oSchool.About
                    Me.txtNumberofEmployees.Text = oSchool.NumberOfEmployees
                    Me.chkIsViewable.Checked = oSchool.IsViewable
                    Me.hidIndustry.Value = oSchool.IndustryName
                    Me.ddSelectType.SelectedValue = oSchool.Types
                    Me.ddMediaType.SelectedValue = oSchool.MediaType
                    Me.ddGovtType.SelectedValue = oSchool.GovtType
                    Me.lblIndustry.Text = oSchool.IndustryName
                    Me.SelectIndustry1.Industry = oSchool.IndustryName
                    Me.SelectIndustry1.LoadData()
                    Me.hidIndustry.Value = oSchool.IndustryName
                    Me.ddCountry.SelectedValue = oSchool.CountryID
                    'Me.ddState.SelectedValue = oSchool.StateID
                    If oSchool.CountryID = 271 Then
                        Me.ddState.Visible = True
                        Me.ddState.SelectedValue = oSchool.StateID
                    Else
                        Me.ddState.Visible = False
                    End If
                    Me.ddCountry2.SelectedValue = oSchool.CountryID2
                    'Me.ddState2.SelectedValue = oSchool.StateID2
                    If oSchool.CountryID = 271 Then
                        Me.ddState.Visible = True
                        Me.ddState.SelectedValue = oSchool.StateID
                    Else
                        Me.ddState.Visible = False
                    End If

                    'profile image load
                    Me.trProfileImage.Visible = True
                    Me.imgProfile.ImageUrl = UIHelper.GetUserImageNew(UserID)

                    Me.ddCountry.Enabled = False
                    Me.ddState.Enabled = False
                    Me.txtZipCode.Enabled = False
                    Me.trPrivacy.Visible = False
                    Me.ddSelectType.Enabled = False
                    Me.ddMediaType.Enabled = False
                    Me.ddEducationlevel.Enabled = False
                End If
            End If
        End If
        ShowHideSections()
        Me.SelectIndustry1.LoadData()
    End Sub

    Public Sub SaveData()
        If UserID > 0 Then
            Me.tblForm.Visible = True
            Me.lblError.Visible = False
            Dim cui As New Users(UserID)
            If Not IsNothing(cui) AndAlso cui.UserID > 0 Then
                Dim oSchool As New smt_School
                oSchool.LoadByUserID(cui.UserID) ' supply Connection String here.
                If IsNothing(oSchool) OrElse oSchool.SchoolID = 0 Then
                    oSchool = New smt_School()
                    oSchool.UserID = cui.UserID
                End If
                oSchool.Types = Me.ddSelectType.SelectedValue
                oSchool.ContactPerson = Me.txtContactPerson.Text.Trim
                oSchool.SchoolName = Me.txtSchoolName.Text.Trim
                oSchool.WebsiteAddress = Me.txtWebsiteAddress.Text.Trim
                oSchool.ContactPhone = Me.txtContactPhone.Text.Trim
                oSchool.Email = Me.txtEmail.Text.Trim
                oSchool.TelephoneNumber = Me.txtTelephoneNumber.Text.Trim
                oSchool.Description = Me.txtDescription.Text.Trim
                oSchool.Address1 = Me.txtAddress1.Text.Trim
                oSchool.Address2 = Me.txtAddress2.Text.Trim
                oSchool.City = Me.txtCity.Text.Trim
                oSchool.CountryID = Me.ddCountry.SelectedValue
                If Me.ddState.Items.Count > 0 Then
                    oSchool.StateID = Me.ddState.SelectedValue
                    oSchool.State = Me.ddState.SelectedItem.Text
                End If
                oSchool.ZipCode = Me.txtZipCode.Text.Trim
                oSchool.AlternateAddress1 = Me.txtAlternativeAddress1.Text.Trim
                oSchool.AlternateAddress2 = Me.txtAlternativeAddress2.Text.Trim
                oSchool.City2 = Me.txtCity2.Text.Trim
                oSchool.AlternateZipCode = Me.txtAlternativeZipCode.Text.Trim
                oSchool.EducationLevel = Me.ddEducationlevel.SelectedValue
                oSchool.Status = Me.txtStatus.Text.Trim
                oSchool.HoursOfOperation = Me.txtHoursofOperation.Text.Trim
                oSchool.About = Me.txtAbout.Text.Trim
                oSchool.NumberOfEmployees = Me.txtNumberofEmployees.Text.Trim
                oSchool.IsViewable = Me.chkIsViewable.Checked
                oSchool.GovtType = Me.ddGovtType.SelectedValue
                oSchool.MediaType = Me.ddMediaType.SelectedValue
                oSchool.CountryID2 = Me.ddCountry2.SelectedValue
                If Me.ddState2.Items.Count > 0 Then
                    oSchool.StateID2 = Me.ddState2.SelectedValue
                    oSchool.AlternateState = Me.ddState2.SelectedItem.Text
                End If
                oSchool.IndustryID = 0
                oSchool.IndustryName = Me.hidIndustry.Value.Trim

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


                If oSchool.SchoolID = 0 Then
                    oSchool.save()
                    Dim UVID As Integer = 0
                    UVID = cui.UserGetMaxMoonUnionverseID()
                    Dim arbrv As String = ""
                    If oSchool.Types = "School" Then
                        arbrv = ReturnAbrMoonTypes(oSchool.Types) & ReturnAbriEducationLevel(oSchool.EducationLevel)
                    ElseIf oSchool.Types = "Government" Then
                        arbrv = ReturnAbrMoonTypes(oSchool.Types) & ReturnAbriGovLevel(oSchool.GovtType)
                    ElseIf oSchool.Types = "Media" Then
                        arbrv = ReturnAbrMoonTypes(oSchool.Types) & ReturnAbriMediaType(oSchool.MediaType)
                    ElseIf oSchool.Types = "Parks & Recreation" Then
                        arbrv = ReturnAbrMoonTypes(oSchool.Types)
                    ElseIf oSchool.Types = "Groups" Then
                        arbrv = ReturnAbrMoonTypes(oSchool.Types)
                    End If
                    cui.UnionVerseID = "M-" & ((oSchool.CountryID - 271) + 1) & "-" & arbrv & "-" & oSchool.ZipCode & "-" & UVID + 1
                    cui.UserTypeID = CommonLibrary.Utility.eUserTypes.SchoolType
                    cui.RoleID = CommonLibrary.Utility.eUserRole.SchoolType
                    cui.FirstName = oSchool.SchoolName
                    cui.Status = 1
                    cui.Save()

                    EmailHelper.MoonRegistration(cui.UserID)
                    Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/Members/" & cui.Username & ".aspx")
                Else
                    oSchool.save()
                    Me.lblInfo.Visible = True

                    Me.lblInfo.Text = "information saved successfully!!!"
                End If

            End If

        Else
            Response.Redirect(UIHelper.GetUnionVerseBasePathURL & "/Login.aspx")
        End If
    End Sub
    Public Function IsValidate() As Boolean
        Me.lblError.Text = ""
        Me.lblError.Visible = True
        If Me.txtSchoolName.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter user name"
            Return False
        End If
        If Me.txtContactPerson.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Contact Person"
            Return False
        End If
        If Me.txtEmail.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Contact Person's Email Address."
            Return False
        End If
        If Me.txtContactPhone.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Contact Person's Telephone Number"
            Return False
        End If
        If Me.txtWebsiteAddress.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter website address"
            Return False
        End If
        If Me.txtTelephoneNumber.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter telephone number"
            Return False
        End If
        If Me.txtDescription.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter description"
            Return False
        End If
        If Me.txtAddress1.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter address line 1"
            Return False
        End If

        If Me.txtCity.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter city"
            Return False
        End If
        If Me.txtZipCode.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter zipcode"
            Return False
        End If

        If Me.txtHoursofOperation.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter hours of operation"
            Return False
        End If
        If Not IsNumeric(Me.txtHoursofOperation.Text) Then
            Me.lblError.Text = "Hours of operation should be numeric"
            Return False
        End If

        If Me.txtAbout.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter about"
            Return False
        End If
        If Me.txtNumberofEmployees.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter number of employees"
            Return False
        End If
        If Not IsNumeric(Me.txtNumberofEmployees.Text) Then
            Me.lblError.Text = "Number of employees should be numeric"
            Return False
        End If

        If Me.hidIndustry.Value.Trim.Length = 0 Then
            Me.lblError.Text = "Please select industry."
            Return False
        End If
        
        Dim oSchool As New smt_School
        oSchool.LoadByUserID(UserID) ' supply Connection String here.
        If IsNothing(oSchool) OrElse oSchool.SchoolID = 0 Then
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

    Protected Sub ddSelectType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddSelectType.TextChanged
        ShowHideSections()
    End Sub
    Public Sub ShowHideSections()
        Me.phSchool.Visible = False
        Me.trGovtType.Visible = False
        Me.trMediaType.Visible = False

        If Me.ddSelectType.SelectedValue = "School" Then
            Me.phSchool.Visible = True
            Me.lblUserName.Text = "School Name:"
        ElseIf Me.ddSelectType.SelectedValue = "Government" Then
            Me.trGovtType.Visible = True
            Me.lblUserName.Text = "Government Name:"
        ElseIf Me.ddSelectType.SelectedValue = "Media" Then
            Me.trMediaType.Visible = True
            Me.lblUserName.Text = "Company Name:"
        ElseIf Me.ddSelectType.SelectedValue = "Parks & Recreation" Then
            Me.lblUserName.Text = "Parks & Recreation Name:"
        ElseIf Me.ddSelectType.SelectedValue = "Groups" Then
            Me.lblUserName.Text = "Group Name:"

        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ' LoadData()
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


    Protected Sub ddCountry2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddCountry2.SelectedIndexChanged
        UIHelper.LoadStatesByCountry(Me.ddState2, "-- Select State --", CInt(Me.ddCountry2.SelectedValue))
        If Me.ddState2.Items.Count = 0 Then
            Me.ddState2.Visible = False
        Else
            Me.ddState2.Visible = True
        End If
    End Sub

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
        UIHelper.LoadCountry(Me.ddCountry2, "--Select Country")
        Me.ddCountry2.SelectedValue = "271"

        UIHelper.LoadStatesByCountry(Me.ddState, "-- Select State --", CInt(Me.ddCountry.SelectedValue))
        If Me.ddState.Items.Count = 0 Then
            Me.ddState.Visible = False
        Else
            Me.ddState.Visible = True
        End If

        UIHelper.LoadStatesByCountry(Me.ddState2, "-- Select State --", CInt(Me.ddCountry2.SelectedValue))
        If Me.ddState2.Items.Count = 0 Then
            Me.ddState2.Visible = False
        Else
            Me.ddState2.Visible = True
        End If
    End Sub

    Public Function ReturnAbrMoonTypes(ByVal str As String) As String
        Select Case str
            Case "School"
                Return "S"
            Case "Government"
                Return "G"
            Case "Media"
                Return "M"
            Case "Parks & Recreation"
                Return "PR"
            Case "Groups"
                Return "N"
            Case Else
                Return ""
        End Select
    End Function
    Public Function ReturnAbriEducationLevel(ByVal str As String) As String
        Select Case str
            Case "Pre-School"
                Return "P"
            Case "Primary School"
                Return "nN"
            Case "Middle School"
                Return "M"
            Case "Secondary"
                Return "N"
            Case "Undergraduate"
                Return "U"
            Case "Postgraduate"
                Return "G"
            Case Else
                Return ""
        End Select
    End Function
    Public Function ReturnAbriGovLevel(ByVal str As String) As String
        Select Case str
            Case "Local"
                Return "L"
            Case "State or Territory"
                Return "T"
            Case "Federal"
                Return "F"
            Case Else
                Return ""
        End Select
    End Function
    Public Function ReturnAbriMediaType(ByVal str As String) As String
        Select Case str
            Case "Print"
                Return "P"
            Case "Internet"
                Return "I"
            Case "Radio"
                Return "R"
            Case "Television"
                Return "T"
            Case "Other"
                Return "O"
            Case Else
                Return ""
        End Select
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
    Protected Sub lbtCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtCancel.Click
        Session("Users") = Nothing
        Response.Redirect(UIHelper.GetBasePath() & "/Login.aspx")
    End Sub
End Class
