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

Partial Class UIControls_Registration_UserType1Regis
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
                    Me.txtGroupTypeUsername.Text = cui.Username
                    Me.lblURL.Text = UIHelper.GetUnionVerseBasePathURL() & "/" & cui.Username.Replace(" ", "_") & ".aspx"
                    Dim oUserType1 As New smt_UserType1
                    oUserType1.LoadByUserID(UserID)
                    If Not IsNothing(oUserType1) AndAlso oUserType1.UserType1ID > 0 Then
                        Me.txtGroupTypeUsername.Text = oUserType1.UserName
                        Me.txtLeaderofGroupType1User.Text = oUserType1.LeaderUserName
                        Me.txtContactPerson.Text = oUserType1.ContactPerson
                        Me.txtPersoanlEmailAddress.Text = oUserType1.PersonalEmailAddress
                        Me.txtPhoneNumber.Text = oUserType1.PhoneNumber
                        Me.txtUserTypeType.Text = oUserType1.UserTypeType
                        Me.ddGalaxy.SelectedValue = oUserType1.Galaxy
                        Me.txtWebsiteAddress.Text = oUserType1.WebsiteAddress
                        Me.txtAddress1.Text = oUserType1.Address1
                        Me.txtAddress2.Text = oUserType1.Address2
                        Me.txtCity.Text = oUserType1.City
                        Me.txtZipCode.Text = oUserType1.ZipCode
                        Me.ddCountry.SelectedValue = oUserType1.CountryID
                        If oUserType1.CountryID = 271 Then
                            Me.ddState.Visible = True
                            Me.ddState.SelectedValue = oUserType1.StateID
                        Else
                            Me.ddState.Visible = False
                        End If


                        Me.txtNumerofEmployees.Text = oUserType1.NumberOfUserEmployees
                        Me.txtMemberSize.Text = oUserType1.MemberSize
                        Me.chkIsViewable.Checked = oUserType1.IsViewable
                        Me.txtAbout.Text = oUserType1.About
                    End If
                End If
            Else
                Me.tblForm.Visible = False
                Me.lblError.Visible = True
                Me.lblError.Text = "You are already register to a group."
            End If
        Else
            Response.Redirect(UIHelper.GetBasePath() & "/Login.aspx")
        End If
    End Sub

    Public Sub LoadProfile()
        LoadCountryState()
        If UserID > 0 Then
            Me.spnCancel.Visible = False
            Me.tblForm.Visible = True
            Me.lblError.Visible = False
            Dim cui As New Users(UserID)
            If Not IsNothing(cui) AndAlso cui.UserID > 0 Then
                Me.txtGroupTypeUsername.Text = cui.Username
                Me.lblURL.Text = UIHelper.GetUnionVerseBasePathURL() & "/" & cui.Username.Replace(" ", "_") & ".aspx"
                Dim oUserType1 As New smt_UserType1
                oUserType1.LoadByUserID(UserID)
                If Not IsNothing(oUserType1) AndAlso oUserType1.UserType1ID > 0 Then
                    Me.txtGroupTypeUsername.Text = oUserType1.UserName
                    Me.txtLeaderofGroupType1User.Text = oUserType1.LeaderUserName
                    Me.txtContactPerson.Text = oUserType1.ContactPerson
                    Me.txtPersoanlEmailAddress.Text = oUserType1.PersonalEmailAddress
                    Me.txtPhoneNumber.Text = oUserType1.PhoneNumber
                    Me.txtUserTypeType.Text = oUserType1.UserTypeType
                    Me.ddGalaxy.SelectedValue = oUserType1.Galaxy
                    Me.txtWebsiteAddress.Text = oUserType1.WebsiteAddress
                    Me.txtAddress1.Text = oUserType1.Address1
                    Me.txtAddress2.Text = oUserType1.Address2
                    Me.txtCity.Text = oUserType1.City
                    Me.txtZipCode.Text = oUserType1.ZipCode
                    Me.ddCountry.SelectedValue = oUserType1.CountryID
                    'Me.ddState.SelectedValue = oUserType1.StateID
                    UIHelper.LoadStatesByCountry(Me.ddState, "-- Select State --", oUserType1.CountryID)
                    If oUserType1.CountryID = 271 Then
                        Me.ddState.Visible = True
                        Me.ddState.SelectedValue = oUserType1.StateID
                    Else
                        Me.ddState.Visible = False
                    End If

                    If oUserType1.Galaxy = "8" Then
                        trFaith.Style.Add("display", "")
                        Me.txtfaith.Text = oUserType1.Faith
                        Me.txtFullName.Enabled = False
                    Else
                        trFaith.Style.Add("display", "none")
                    End If
                    Me.txtNumerofEmployees.Text = oUserType1.NumberOfUserEmployees
                    Me.txtMemberSize.Text = oUserType1.MemberSize
                    Me.chkIsViewable.Checked = oUserType1.IsViewable
                    Me.txtAbout.Text = oUserType1.About
                    Me.txtFullName.Text = oUserType1.FullName
                    Me.txtLegalName.Text = oUserType1.LegalName
                    Me.txtTaxIDNumber.Text = oUserType1.TaxIDNumber
                    Me.txtMobileNumber.Text = oUserType1.MobileNumber
                    Me.ddCountry.Enabled = False
                    Me.ddState.Enabled = False
                    Me.txtZipCode.Enabled = False
                    Me.txtUserTypeType.Enabled = False
                    Me.ddGalaxy.Enabled = False
                    Me.trPrivacy.Visible = False

                    'profile image load
                    Me.trProfileImage.Visible = True
                    Me.imgProfile.ImageUrl = UIHelper.GetUserImageNew(UserID)
                End If
            End If

        Else
            Response.Redirect(UIHelper.GetBasePath() & "/Login.aspx")
        End If
    End Sub

    Public Sub SaveData()
        If UserID > 0 Then
            Dim cui As New Users(UserID)
            If Not IsNothing(cui) AndAlso cui.UserID > 0 Then
                Dim oUserType1 As New smt_UserType1
                oUserType1.LoadByUserID(cui.UserID)
                If IsNothing(oUserType1) OrElse oUserType1.UserType1ID = 0 Then
                    oUserType1 = New smt_UserType1()
                    oUserType1.UserID = cui.UserID
                End If
                oUserType1.UserName = Me.txtGroupTypeUsername.Text.Trim
                oUserType1.LeaderUserName = Me.txtLeaderofGroupType1User.Text.Trim
                oUserType1.ContactPerson = Me.txtContactPerson.Text.Trim
                oUserType1.Galaxy = Me.ddGalaxy.SelectedValue

                oUserType1.NumberOfUserEmployees = Me.txtNumerofEmployees.Text
                oUserType1.PersonalEmailAddress = Me.txtPersoanlEmailAddress.Text

                oUserType1.UserTypeType = Me.txtUserTypeType.Text.Trim
                oUserType1.WebsiteAddress = Me.txtWebsiteAddress.Text.Trim
                oUserType1.Address1 = Me.txtAddress1.Text.Trim
                oUserType1.Address2 = Me.txtAddress2.Text.Trim
                oUserType1.City = Me.txtCity.Text
                oUserType1.ZipCode = Me.txtZipCode.Text
                oUserType1.PhoneNumber = Me.txtPhoneNumber.Text

                oUserType1.MemberSize = Me.txtMemberSize.Text
                oUserType1.IsViewable = Me.chkIsViewable.Checked

                oUserType1.About = Me.txtAbout.Text.Trim
                oUserType1.UserID = UserID
                oUserType1.LeaderUserID = UserID



                oUserType1.CountryID = Me.ddCountry.SelectedValue
                If Me.ddState.Items.Count > 0 Then
                    oUserType1.StateID = Me.ddState.SelectedValue
                    oUserType1.State = Me.ddState.SelectedItem.Text
                End If

                oUserType1.FullName = Me.txtFullName.Text
                oUserType1.LegalName = Me.txtLegalName.Text
                oUserType1.TaxIDNumber = Me.txtTaxIDNumber.Text
                oUserType1.MobileNumber = Me.txtMobileNumber.Text
                oUserType1.Faith = Me.txtFullName.Text
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


                If oUserType1.UserType1ID = 0 Then
                    ' Here save user image.
                    oUserType1.save()
                    Dim UVID As Integer = 0
                    UVID = cui.UserGetMaxCompanyUnionverseID()
                    cui.UnionVerseID = "S" & ((oUserType1.CountryID - 271) + 1) & "-" & oUserType1.ZipCode.Trim & "-" & UVID + 1
                    cui.UserTypeID = CommonLibrary.Utility.eUserTypes.UserType1
                    cui.RoleID = CommonLibrary.Utility.eUserRole.UserType1
                    cui.Status = 1
                    cui.Save()
                    EmailHelper.GroupType1RegistrationConfirmation(cui.UserID)
                    Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/GroupType1Employees.aspx")
                Else
                    oUserType1.save()
                    Me.lblInfo.Visible = True
                    Me.lblInfo.Text = "information saved successfully!!!"
                End If





            End If
        End If
    End Sub

    Public Function IsValidate() As Boolean
        Me.lblError.Text = ""
        Me.lblError.Visible = True
        If Me.txtGroupTypeUsername.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Group Type Username"
            Return False
        End If
        If Me.txtFullName.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Full Name"
            Return False
        End If
        If Me.txtLegalName.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Legal Name Of The User"
            Return False
        End If
        If Me.txtTaxIDNumber.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Tax ID Number"
            Return False
        End If
        If Me.txtMobileNumber.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Mobile Number Of The Leader."
            Return False
        Else
            If Not Regex.IsMatch(Me.txtMobileNumber.Text.Trim, UIHelper.PhoneNumberExpression) Then
                Me.lblError.Text = "Enter Correct Mobile Number Of The Leader."
                Return False
            End If

        End If

        If Me.txtLeaderofGroupType1User.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Leader of Group Type Username."
            Return False
        End If
        If Me.txtContactPerson.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Contact Person."
            Return False
        End If
        If Me.txtPersoanlEmailAddress.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Contact Person's Email Address."
            Return False
        Else
            If Not Regex.IsMatch(Me.txtPersoanlEmailAddress.Text.Trim, UIHelper.EmailExpression) Then
                Me.lblError.Text = "Enter Correct Contact Person's Email Address."
                Return False
            End If

        End If
        If Me.txtPhoneNumber.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Contact Person's Phone Number."
            Return False
        Else
            If Not Regex.IsMatch(Me.txtPhoneNumber.Text.Trim, UIHelper.PhoneNumberExpression) Then
                Me.lblError.Text = "Enter Correct Contact Person's Phone Number"
                Return False
            End If
        End If
        If Me.ddGalaxy.SelectedValue = "0" Then
            Me.lblError.Text = "Select Galaxy Type."
            Return False
        End If
        If Me.txtUserTypeType.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Type of Religious Sanctuary"
            Return False
        End If
        If Me.ddGalaxy.SelectedValue = "8" AndAlso txtfaith.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Faith."
            Return False
        End If

        If Me.txtAddress1.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter address 1"
            Return False
        End If
        If Me.txtCity.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter City."
            Return False
        End If
        If Me.txtZipCode.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter ZipCode"
            Return False
        End If

        If Me.txtNumerofEmployees.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Number of Employees"
            Return False
        Else
            If Not Regex.IsMatch(Me.txtNumerofEmployees.Text.Trim, UIHelper.IntgerExpression) Then
                Me.lblError.Text = "Number of Employees Should be Numeric."
                Return False
            End If
        End If

        If Me.txtMemberSize.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Member Size."
            Return False
        Else
            If Not Regex.IsMatch(Me.txtMemberSize.Text.Trim, UIHelper.IntgerExpression) Then
                Me.lblError.Text = "Member Size Should be Numeric."
                Return False
            End If
        End If
        
        If Me.txtAbout.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter about"
            Return False
        End If
        'If Not IsNothing(Me.upAvatar.PostedFile) AndAlso Me.upAvatar.PostedFile.FileName.Trim.Length = 0 Then
        '    Me.lblError.Text = "Select image to upload."
        '    Return False
        'End If
        Dim oUserType1 As New smt_UserType1
        oUserType1.LoadByUserID(UserID)
        If oUserType1.UserType1ID = 0 Then
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

    Protected Sub ddCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddCountry.SelectedIndexChanged
        UIHelper.LoadStatesByCountry(Me.ddState, "-- Select State --", CInt(Me.ddCountry.SelectedValue))
        If Me.ddCountry.SelectedValue <> 271 Then
            Me.ddState.Visible = False
        Else
            Me.ddState.Visible = True
        End If
    End Sub

    Public Sub LoadCountryState()
        UIHelper.LoadCountry(Me.ddCountry, "-- Select Country --")
        If Me.ddCountry.SelectedValue <> "271" Then
            Me.ddState.Visible = False
        Else
            Me.ddState.Visible = True
        End If
    End Sub

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
