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

Partial Class CMSModules_Membership_Controls_IndividualUserType1Regis
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

    Public Sub SaveData()
        Dim ui As New Users(CType(Session("Users"), Users).UserID)
        If UserID > 0 Then
            Dim cui As New Users(UserID)
            If Not IsNothing(cui) AndAlso cui.UserID > 0 Then
                Dim u1 As smt_IndividualUserType1 = New smt_IndividualUserType1()
                Dim _addToPlanets As Boolean = False
                u1.LoadByUserID(UserID)
                If IsNothing(u1) OrElse u1.IndividualUserType1ID = 0 Then
                    u1 = New smt_IndividualUserType1()
                    _addToPlanets = True
                End If
                u1.UserID = cui.UserID

                u1.FirstName = txtFirstName.Text.Trim()
                u1.LastName = txtLastName.Text.Trim()
                u1.Address1 = txtAddress1.Text.Trim()
                u1.Address2 = txtAddress2.Text.Trim()
                u1.City = txtCity.Text.Trim()
                u1.CountryID = Me.ddCountry.SelectedValue
                If Me.ddState.Items.Count > 0 Then
                    u1.StateID = Me.ddState.SelectedValue
                    u1.State = Me.ddState.SelectedItem.Text
                End If
                u1.ZipCode = txtZipCode.Text.Trim()
                u1.CollegeAttended = txtCollegeAttended.Text.Trim()
                u1.LevelOfEducation = ddEducationLevel.SelectedValue.ToString()
                u1.DegreeIn = txtDegreeIn.Text.Trim()
                u1.EmployerName = txtEmployerName.Text.Trim()
                u1.CurrentPosition = txtCurrentPosition.Text.Trim()
                u1.YearsOfExperience = Me.ddExperience.SelectedValue
                u1.BusinessAddress1 = txtBusinessAddress1.Text.Trim()
                u1.BusinessAddress2 = txtBusinessAddress2.Text.Trim()
                u1.City2 = txtCity2.Text.Trim()
                u1.CountryID2 = Me.ddCountry2.SelectedValue
                If Me.ddState2.Items.Count > 0 Then
                    u1.StateID2 = Me.ddState2.SelectedValue
                    u1.BusinessState = Me.ddState2.SelectedItem.Text
                End If
                u1.BusinessZipCode = txtBusinessZipCode.Text.Trim()
                u1.PersonalTelephoneNumber = txtPersonalTelephoneNumber.Text.Trim()
                u1.PersonalEmailAddress = txtPersonalEmailAddress.Text.Trim()
                u1.IsViewable = chkIsViewable.Checked
                u1.About = ""
                u1.GroupTypeID = UserType1ID
                u1.Gender = rbGender.SelectedValue
                ' save image here...


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

                'Me.lblInfo.Text = "Saved successfully!!!"
                If u1.IndividualUserType1ID = 0 Then
                    u1.save()

                    cui.FirstName = u1.FirstName
                    cui.LastName = u1.LastName
                    cui.Username = Me.txtUsername.Text.Trim

                    cui.Save()

                    Dim oUserType1 As New smt_UserType1(UserType1ID)
                    If Not IsNothing(oUserType1) AndAlso oUserType1.UserID > 0 Then

                        Dim OUV1 As New Users(oUserType1.UserID)
                        If Not IsNothing(OUV1) AndAlso OUV1.UnionVerseID.Trim.Length > 0 Then
                            Dim UVID As Integer = 0
                            UVID = OUV1.UserGetMaxGroupType1PlanetUnionverseID(UserType1ID, "-I-")
                            If UVID < 50 Then
                                UVID = 50
                            End If
                            cui.UnionVerseID = OUV1.UnionVerseID & "-P-I-" & (UVID + 1)
                            cui.UserTypeID = CommonLibrary.Utility.eUserTypes.IndividualType1
                            cui.RoleID = CommonLibrary.Utility.eUserRole.IndividualType1
                            cui.Status = 1
                            cui.Save()
                        End If
                    End If
                    '------------------------------------------------

                    If _addToPlanets Then

                        Dim oUTP As New smt_UserType1Planet
                        oUTP.UserType1ID = UserType1ID
                        oUTP.FriendID = u1.UserID
                        oUTP.IsApproved = False
                        oUTP.IndividualType1or2 = 1
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
                    u1.save()
                    Session("Users") = cui
                    Me.lblInfo.Text = "information saved successfully!!!"
                End If

            End If
        End If
    End Sub

    Public Sub LoadData()
        LoadCountryState()
        JDataHelper.LoadEduLevels(Me.ddEducationLevel, "")
        JDataHelper.LoadJYears(Me.ddExperience, "")
        If (UserID > 0) Then
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
                Dim u1 As smt_IndividualUserType1 = New smt_IndividualUserType1()
                u1.LoadByUserID(UserID)
                If Not IsNothing(u1) Then
                    If (u1.IndividualUserType1ID > 0) Then
                        txtFirstName.Text = u1.FirstName
                        txtLastName.Text = u1.LastName
                        txtAddress1.Text = u1.Address1
                        txtAddress2.Text = u1.Address2
                        txtCity.Text = u1.City
                        txtZipCode.Text = u1.ZipCode
                        txtCollegeAttended.Text = u1.CollegeAttended
                        ddEducationLevel.SelectedValue = u1.LevelOfEducation
                        txtDegreeIn.Text = u1.DegreeIn
                        txtEmployerName.Text = u1.EmployerName
                        txtCurrentPosition.Text = u1.CurrentPosition
                        If Me.ddExperience.Items.Contains(Me.ddExperience.Items.FindByValue(u1.YearsOfExperience)) Then
                            Me.ddExperience.SelectedValue = u1.YearsOfExperience
                        End If

                        txtBusinessAddress1.Text = u1.BusinessAddress1
                        txtBusinessAddress2.Text = u1.BusinessAddress2
                        txtCity2.Text = u1.City2
                        txtBusinessZipCode.Text = u1.BusinessZipCode
                        txtPersonalTelephoneNumber.Text = u1.PersonalTelephoneNumber
                        txtPersonalEmailAddress.Text = u1.PersonalEmailAddress
                        chkIsViewable.Checked = u1.IsViewable
                        'txtAbout.Text = u1.About
                        rbGender.SelectedValue = u1.Gender
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub LoadProfile()
        LoadCountryState()
        JDataHelper.LoadEduLevels(Me.ddEducationLevel, "")
        JDataHelper.LoadJYears(Me.ddExperience, "")
        If (UserID > 0) Then
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
                Dim u1 As smt_IndividualUserType1 = New smt_IndividualUserType1()
                u1.LoadByUserID(UserID)
                If Not IsNothing(u1) Then
                    If (u1.IndividualUserType1ID > 0) Then
                        txtFirstName.Text = u1.FirstName
                        txtLastName.Text = u1.LastName
                        txtAddress1.Text = u1.Address1
                        txtAddress2.Text = u1.Address2
                        txtCity.Text = u1.City
                        txtZipCode.Text = u1.ZipCode
                        txtCollegeAttended.Text = u1.CollegeAttended
                        ddEducationLevel.SelectedValue = u1.LevelOfEducation
                        txtDegreeIn.Text = u1.DegreeIn
                        txtEmployerName.Text = u1.EmployerName
                        txtCurrentPosition.Text = u1.CurrentPosition
                        If Me.ddExperience.Items.Contains(Me.ddExperience.Items.FindByValue(u1.YearsOfExperience)) Then
                            Me.ddExperience.SelectedValue = u1.YearsOfExperience
                        End If
                        ddCountry.SelectedValue = u1.CountryID
                        ddState.SelectedValue = u1.StateID
                        If u1.CountryID = 271 Then
                            Me.ddState.Visible = True
                        Else
                            Me.ddState.Visible = False
                        End If

                        ddCountry2.SelectedValue = u1.CountryID2
                        ddState2.SelectedValue = u1.StateID2

                        If u1.CountryID2 = 271 Then
                            Me.ddState2.Visible = True
                        Else
                            Me.ddState2.Visible = False
                        End If
                        txtBusinessAddress1.Text = u1.BusinessAddress1
                        txtBusinessAddress2.Text = u1.BusinessAddress2
                        txtCity2.Text = u1.City2
                        txtBusinessZipCode.Text = u1.BusinessZipCode
                        txtPersonalTelephoneNumber.Text = u1.PersonalTelephoneNumber
                        txtPersonalEmailAddress.Text = u1.PersonalEmailAddress
                        chkIsViewable.Checked = u1.IsViewable
                        'txtAbout.Text = u1.About
                        rbGender.SelectedValue = u1.Gender
                        Me.trPrivacy.Visible = False

                        'profile image load
                        Me.trProfileImage.Visible = True
                        Me.imgProfile.ImageUrl = UIHelper.GetUserImageNew(UserID)
                    End If
                End If
            End If
        End If
    End Sub


    Public Function IsValidate() As Boolean
        Me.lblError.Text = ""
        Me.lblError.Visible = True
        Dim u1 As smt_IndividualUserType1 = New smt_IndividualUserType1()
        u1.LoadByUserID(UserID)

        If Me.trUserName.Visible Then
            If Me.txtUsername.Text.Trim.Length = 0 Then
                Me.lblError.Text = "Please enter username."
                Return False
            End If

            If IsNothing(u1) OrElse u1.IndividualUserType1ID = 0 Then
                Dim oU As New Users(Me.txtUsername.Text.Trim)
                If Not IsNothing(oU) AndAlso oU.UserID > 0 Then
                    Me.lblError.Text = "Username already exist please choose a different username."
                    Return False
                End If
            End If

        End If

        If Me.txtFirstName.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter first name."
            Return False
        End If
        If Me.txtLastName.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter last name."
            Return False
        End If
        If Me.txtAddress1.Text.Trim.Length = 0 Then
            Me.lblError.Text = "enter address 1."
            Return False
        End If
        If Me.txtCity.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter city."
            Return False
        End If
        If Me.txtZipCode.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter zipcode."
            Return False
        End If
        If Me.txtCollegeAttended.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter college attended."
            Return False
        End If
        If Me.txtDegreeIn.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter degreee in."
            Return False
        End If
        If Me.txtEmployerName.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter employer name."
            Return False
        End If
        If Me.txtCurrentPosition.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter current position."
            Return False
        End If
        If Me.txtBusinessAddress1.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter business address 1."
            Return False
        End If
        If Me.txtCity2.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter business city."
            Return False
        End If
        If Me.txtBusinessZipCode.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter business zipcode."
            Return False
        End If
        If Me.txtPersonalTelephoneNumber.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter personal telephone number."
            Return False
        End If
        If Me.txtPersonalEmailAddress.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter personal email adress."
            Return False
        End If
        If IsNothing(u1) OrElse u1.IndividualUserType1ID = 0 Then
            If Me.chkPrivacy.Checked = False Then
                Me.lblError.Text = "You must have to agree with UNIonVERSE Terms."
                Return False
            End If
        End If
        'If Not IsNothing(Me.upAvatar.PostedFile) AndAlso Me.upAvatar.PostedFile.FileName.Trim.Length = 0 Then
        '    Me.lblError.Text = "Select image to upload."
        '    Return False
        'End If
        Me.lblError.Visible = False
        Return True
    End Function
    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click, lbtSave.Click
        If IsValidate() Then
            SaveData()
        End If
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
