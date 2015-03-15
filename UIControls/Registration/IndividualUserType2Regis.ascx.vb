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
Imports CommonLibrary
Imports System.IO

Partial Class CMSModules_Membership_Controls_IndividualUserType2Regis
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

    Public Property UserType1ID() As Integer
        Get
            If Not IsNothing(ViewState("UserType1ID")) AndAlso IsNumeric(ViewState("UserType1ID")) Then
                Return CInt(ViewState("UserType1ID"))
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("UserType1ID") = value
        End Set
    End Property

    Public Sub LoadData()
        LoadCountryState()
        'JDataHelper.LoadCareerLevels(chkCareerLevel, "")
        JDataHelper.LoadEduLevels(Me.ddEducationLevel, "")
        JDataHelper.LoadJYears(Me.ddYearsofExperience, "")
        If UserID > 0 Then
            Dim cui As New Users(UserID)
            If Not IsNothing(cui) AndAlso cui.UserID > 0 Then
                Me.txtUsername.Text = cui.Username

                If cui.UserTypeID = 0 Then
                    Dim oUE As New smt_UserType1Employee
                    oUE.LoadByUserID(cui.UserID)
                    If Not IsNothing(oUE) AndAlso oUE.UserType1UserID > 0 Then
                        Me.txtUsername.Text = ""
                        Me.trUserName.Visible = True
                    End If
                End If

                Me.txtFirstName.Text = cui.FirstName
                Me.txtLastName.Text = cui.LastName
                Dim oU2 As New smt_IndividualUserType2
                oU2.LoadByUserID(UserID)
                If Not IsNothing(oU2) AndAlso oU2.IndividualUserType2ID > 0 Then
                    Me.txtFirstName.Text = oU2.FirstName
                    Me.txtLastName.Text = oU2.LastName
                    Me.txtAddress1.Text = oU2.Address1
                    Me.txtAddress2.Text = oU2.Address2
                    Me.txtCity.Text = oU2.City
                    Me.txtZipCode.Text = oU2.ZipCode
                    Me.txtCollegeAttended.Text = oU2.CollegeAttended
                    Me.ddEducationLevel.SelectedValue = oU2.LevelOfEducation.Trim
                    Me.txtDegreeIn.Text = oU2.DegreeIn
                    Me.txtEmployerName.Text = oU2.EmployerName
                    Me.txtCurrentPosition.Text = oU2.CurrentPosition
                    Me.ddTypeofAgent.SelectedValue = oU2.TypeOfAgent
                    Me.txtAbout.Text = oU2.About
                    Me.ddInsuranceBroker.Visible = False
                    Me.txtAttorney.Visible = False
                    Me.ddDoctor.Visible = False
                    Select Case oU2.TypeOfAgent
                        Case "Insurance Broker"
                            Me.ddInsuranceBroker.Visible = True
                            Me.ddInsuranceBroker.SelectedValue = oU2.InsuranceBroker
                        Case "Attorney"
                            Me.txtAttorney.Visible = True
                            Me.txtAttorney.Text = oU2.Attorney
                        Case "Doctor"
                            Me.ddDoctor.Visible = True
                            Me.ddDoctor.SelectedValue = oU2.Doctor
                    End Select
                    If Me.ddYearsofExperience.Items.Contains(Me.ddYearsofExperience.Items.FindByValue(oU2.YearsOfExperience)) Then
                        Me.ddYearsofExperience.SelectedValue = oU2.YearsOfExperience
                    End If
                    Me.txtBusinessAddress1.Text = oU2.BusinessAddress1
                    Me.txtBusinessAddress2.Text = oU2.BusinessAddress2
                    Me.txtCity2.Text = oU2.City2
                    Me.txtBusinessZipCode.Text = oU2.BusinessZipCode
                    Me.txtPersonalTelephoneNumber.Text = oU2.PersonalTelephoneNumber
                    Me.txtPersonalEmailAddress.Text = oU2.PersonalEmailAddress
                    Me.chkIsViewable.Checked = oU2.IsViewable
                    Me.rbGender.SelectedValue = oU2.Gender
                End If
            End If
        End If
        ShowHideDropDowns()
    End Sub

    Public Sub LoadProfile()
        LoadCountryState()
        'JDataHelper.LoadCareerLevels(chkCareerLevel, "")
        JDataHelper.LoadEduLevels(Me.ddEducationLevel, "")
        JDataHelper.LoadJYears(Me.ddYearsofExperience, "")
        If UserID > 0 Then
            Me.spnCancel.Visible = False
            Dim cui As New Users(UserID)
            If Not IsNothing(cui) AndAlso cui.UserID > 0 Then
                Me.txtUsername.Text = cui.Username

                If cui.UserTypeID = 0 Then
                    Dim oUE As New smt_UserType1Employee
                    oUE.LoadByUserID(cui.UserID)
                    If Not IsNothing(oUE) AndAlso oUE.UserType1UserID > 0 Then
                        Me.txtUsername.Text = ""
                        Me.trUserName.Visible = True
                    End If
                End If

                Me.txtFirstName.Text = cui.FirstName
                Me.txtLastName.Text = cui.LastName
                Dim oU2 As New smt_IndividualUserType2
                oU2.LoadByUserID(UserID)
                If Not IsNothing(oU2) AndAlso oU2.IndividualUserType2ID > 0 Then
                    Me.txtFirstName.Text = oU2.FirstName
                    Me.txtLastName.Text = oU2.LastName
                    Me.txtAddress1.Text = oU2.Address1
                    Me.txtAddress2.Text = oU2.Address2
                    Me.txtCity.Text = oU2.City
                    Me.txtZipCode.Text = oU2.ZipCode
                    Me.txtCollegeAttended.Text = oU2.CollegeAttended
                    Me.ddEducationLevel.SelectedValue = oU2.LevelOfEducation.Trim
                    Me.txtDegreeIn.Text = oU2.DegreeIn
                    Me.txtEmployerName.Text = oU2.EmployerName
                    Me.txtCurrentPosition.Text = oU2.CurrentPosition
                    Me.ddTypeofAgent.SelectedValue = oU2.TypeOfAgent
                    Me.txtAbout.Text = oU2.About

                    ddCountry.SelectedValue = oU2.CountryID
                    ddState.SelectedValue = oU2.StateID
                    If oU2.CountryID = 271 Then
                        Me.ddState.Visible = True
                    Else
                        Me.ddState.Visible = False
                    End If


                    ddCountry2.SelectedValue = oU2.CountryID2
                    ddState2.SelectedValue = oU2.StateID2

                    If oU2.CountryID2 = 271 Then
                        Me.ddState2.Visible = True
                    Else
                        Me.ddState2.Visible = False
                    End If


                    Me.ddInsuranceBroker.Visible = False
                    Me.txtAttorney.Visible = False
                    Me.ddDoctor.Visible = False
                    Select Case oU2.TypeOfAgent
                        Case "Insurance Broker"
                            Me.ddInsuranceBroker.Visible = True
                            Me.ddInsuranceBroker.SelectedValue = oU2.InsuranceBroker
                        Case "Attorney"
                            Me.txtAttorney.Visible = True
                            Me.txtAttorney.Text = oU2.Attorney
                        Case "Doctor"
                            Me.ddDoctor.Visible = True
                            Me.ddDoctor.SelectedValue = oU2.Doctor
                    End Select
                    If Me.ddYearsofExperience.Items.Contains(Me.ddYearsofExperience.Items.FindByValue(oU2.YearsOfExperience)) Then
                        Me.ddYearsofExperience.SelectedValue = oU2.YearsOfExperience
                    End If
                    Me.txtBusinessAddress1.Text = oU2.BusinessAddress1
                    Me.txtBusinessAddress2.Text = oU2.BusinessAddress2
                    Me.txtCity2.Text = oU2.City2
                    Me.txtBusinessZipCode.Text = oU2.BusinessZipCode
                    Me.txtPersonalTelephoneNumber.Text = oU2.PersonalTelephoneNumber
                    Me.txtPersonalEmailAddress.Text = oU2.PersonalEmailAddress
                    Me.chkIsViewable.Checked = oU2.IsViewable
                    Me.rbGender.SelectedValue = oU2.Gender
                    Me.trPrivacy.Visible = False
                    'Me.ddCountry.Enabled = False
                    'Me.ddState.Enabled = False
                    'Me.txtZipCode.Enabled = False
                    'Me.txtEmployerName.Enabled = False
                    Me.ddTypeofAgent.Enabled = False
                    Me.ddDoctor.Enabled = False

                    'profile image load
                    Me.trProfileImage.Visible = True
                    Me.imgProfile.ImageUrl = UIHelper.GetUserImageNew(UserID)
                End If
            End If
        End If
        ShowHideDropDowns()
    End Sub

    Public Sub SaveData()
        If UserID > 0 Then
            Dim cui As New Users(UserID)
            If Not IsNothing(cui) AndAlso cui.UserID > 0 Then
                Dim oU2 As New smt_IndividualUserType2
                oU2.LoadByUserID(cui.UserID)
                Dim _addToPlanets As Boolean = False

                If IsNothing(oU2) OrElse oU2.IndividualUserType2ID = 0 Then
                    oU2 = New smt_IndividualUserType2()
                    oU2.UserID = cui.UserID
                    _addToPlanets = True
                End If

                oU2.FirstName = Me.txtFirstName.Text.Trim
                oU2.LastName = Me.txtLastName.Text.Trim
                oU2.Address1 = Me.txtAddress1.Text.Trim
                oU2.Address2 = Me.txtAddress2.Text.Trim
                oU2.City = txtCity.Text.Trim()
                oU2.CountryID = Me.ddCountry.SelectedValue
                If Me.ddState.Items.Count > 0 Then
                    oU2.StateID = Me.ddState.SelectedValue
                    oU2.State = Me.ddState.SelectedItem.Text
                End If




                oU2.ZipCode = Me.txtZipCode.Text.Trim
                oU2.GroupTypeID = 2
                oU2.CollegeAttended = Me.txtCollegeAttended.Text.Trim
                oU2.LevelOfEducation = Me.ddEducationLevel.SelectedValue
                oU2.DegreeIn = Me.txtDegreeIn.Text.Trim
                oU2.EmployerName = Me.txtEmployerName.Text.Trim
                oU2.CurrentPosition = Me.txtCurrentPosition.Text.Trim
                oU2.TypeOfAgent = Me.ddTypeofAgent.SelectedValue
                oU2.InsuranceBroker = Me.ddInsuranceBroker.SelectedValue
                oU2.Attorney = Me.txtAttorney.Text.Trim
                oU2.Doctor = Me.ddDoctor.SelectedValue
                oU2.YearsOfExperience = Me.ddYearsofExperience.SelectedValue
                oU2.WorkPhoneNumber = Me.txtWorkTelephoneNumber.Text.Trim
                oU2.BusinessAddress1 = Me.txtBusinessAddress1.Text.Trim
                oU2.BusinessAddress2 = Me.txtBusinessAddress2.Text.Trim
                oU2.City2 = txtCity2.Text.Trim()
                oU2.CountryID2 = Me.ddCountry2.SelectedValue
                If Me.ddState2.Items.Count > 0 Then
                    oU2.StateID2 = Me.ddState2.SelectedValue
                    oU2.BusinessState = Me.ddState2.SelectedItem.Text
                End If


                oU2.BusinessZipCode = Me.txtBusinessZipCode.Text.Trim
                oU2.PersonalTelephoneNumber = Me.txtPersonalTelephoneNumber.Text.Trim
                oU2.PersonalEmailAddress = Me.txtPersonalEmailAddress.Text.Trim
                oU2.IsViewable = Me.chkIsViewable.Checked
                oU2.About = Me.txtAbout.Text.Trim
                oU2.GroupTypeID = UserType1ID
                oU2.Gender = rbGender.SelectedValue

                Me.lblInfo.Visible = True

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
                If oU2.IndividualUserType2ID = 0 Then
                    oU2.save()
                    cui.FirstName = oU2.FirstName
                    cui.LastName = oU2.LastName
                    cui.Username = Me.txtUsername.Text.Trim
                    cui.Status = 1
                    cui.Save()

                    Dim oUserType1 As New smt_UserType1(UserType1ID)
                    If Not IsNothing(oUserType1) AndAlso oUserType1.UserID > 0 Then
                        Dim OUV1 As New Users(oUserType1.UserID)

                        If Not IsNothing(OUV1) AndAlso OUV1.UnionVerseID.Trim.Length > 0 Then
                            Dim UVID As Integer = 0
                            UVID = cui.UserGetMaxGroupType1PlanetUnionverseID(UserType1ID, "-II-")
                            If UVID < 50 Then
                                UVID = 50
                            End If
                            cui.UnionVerseID = OUV1.UnionVerseID & "-P-II-" & (UVID + 1)
                            cui.UserTypeID = CommonLibrary.Utility.eUserTypes.IndividualType2
                            cui.RoleID = CommonLibrary.Utility.eUserRole.IndividualType2
                            cui.Status = 1
                            cui.Save()
                        End If
                    End If
                    '------------------------------------------------

                    If _addToPlanets Then
                        Dim oUTP As New smt_UserType1Planet
                        oUTP.UserType1ID = UserType1ID
                        oUTP.FriendID = oU2.UserID
                        oUTP.IsApproved = False
                        oUTP.IndividualType1or2 = 2
                        oUTP.save()

                        Dim oInd2 As New Users(cui.UserID)
                        Dim oInd1 As New Users(oUserType1.UserID)
                        Dim oM As New IMessages()
                        oM.SenderUserID = oInd2.UserID
                        oM.SenderNickName = oInd2.Username
                        oM.RecipientUserID = oInd1.UserID
                        oM.RecipientNickName = oInd1.Username
                        oM.DateSent = DateTime.Now
                        oM.LastModified = oM.DateSent
                        oM.Subject = oInd2.Username + " wants to be Planet "
                        oM.Body = oInd2.Username + " wants to be Planet " & vbLf & "<p>To Accpet or Reject the Connection request please follow.</p><p><b><a href='" & UIHelper.GetBasePath() & "/ManagePlanets.aspx?PlanetID=" & oUTP.UserType1PlanetID.ToString() & "'>Accept / Reject</a></b><br /></p>"
                        oM.save()

                    End If
                    '------------------------------------------------
                    EmailHelper.IndividualRegistration(cui.UserID)
                    Session("Users") = cui
                    Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/Members/" & cui.Username & ".aspx")
                Else
                    oU2.save()
                    Session("Users") = cui
                    Me.lblInfo.Visible = True
                    Me.lblInfo.Text = "information saved successfully!!!"
                End If

            End If
        End If
    End Sub
    Public Function IsValidate() As Boolean
        Me.lblError.Text = ""
        Me.lblError.Visible = True
        If Me.trUserName.Visible Then
            If Me.txtUsername.Text.Trim.Length = 0 Then
                Me.lblError.Text = "Please enter username."
                Return False
            End If

            Dim oU2 As New smt_IndividualUserType2
            oU2.LoadByUserID(UserID)
            If IsNothing(oU2) OrElse oU2.IndividualUserType2ID = 0 Then
                Dim oU As New Users(Me.txtUsername.Text.Trim)
                If Not IsNothing(oU) AndAlso oU.UserID > 0 Then
                    Me.lblError.Text = "Username already exist please choose a different username."
                    Return False
                End If
            End If
        End If
        Return True
    End Function
    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click, lbtSave.Click
        If IsValidate() Then
            SaveData()
        End If
    End Sub

    Public Sub ShowHideDropDowns()
        Me.ddDoctor.Visible = False
        Me.ddInsuranceBroker.Visible = False
        Me.txtAttorney.Visible = False
        If Me.ddTypeofAgent.SelectedValue = "Doctor" Then
            Me.ddDoctor.Visible = True
        ElseIf Me.ddTypeofAgent.SelectedValue = "Insurance Broker" Then
            Me.ddInsuranceBroker.Visible = True
        ElseIf Me.ddTypeofAgent.SelectedValue = "Attorney" Then
            Me.txtAttorney.Visible = True
        End If
    End Sub
    Protected Sub ddTypeofAgent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddTypeofAgent.SelectedIndexChanged
        ShowHideDropDowns()
    End Sub


    Protected Sub ddCountry2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddCountry2.SelectedIndexChanged
        UIHelper.LoadStatesByCountry(Me.ddState2, "-- Select State --", CInt(Me.ddCountry2.SelectedValue))
        If Me.ddCountry2.SelectedValue <> "271" Then
            Me.ddState2.Visible = False
        Else
            Me.ddState2.Visible = True
        End If
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
