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

Imports JobLibrary
Partial Class JobUC_JobPostAddEdit
    Inherits System.Web.UI.UserControl
    Public Property JobID() As Integer
        Get
            If Not IsNothing(ViewState("JobID")) AndAlso IsNumeric(ViewState("JobID")) Then
                Return ViewState("JobID")
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("JobID") = value
        End Set
    End Property
    Public Property UserID() As Integer
        Get
            If Not IsNothing(ViewState("UserID")) AndAlso IsNumeric(ViewState("UserID")) Then
                Return ViewState("UserID")
            Else
                If Not IsNothing(Session("Users")) Then
                    Return CType(Session("Users"), UserLibrary.Users).UserID
                Else
                    Return 0
                End If
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("UserID") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadData()
        End If
    End Sub

    Public Sub SetView()
   
    End Sub
    Public Sub LoadData()
        SetView()
        'Load Lists
        JDataHelper.LoadCareerLevels(chkCareerLevel, "")
        JDataHelper.LoadEduLevels(chkEduLevel, "")
        JDataHelper.LoadIndustry(chkIndustry, "")
        JDataHelper.LoadJobType(chkJobType, "")
        JDataHelper.LoadJobCategories(chkCategory, "")
        JDataHelper.LoadJYears(ddlYear, "")
        JDataHelper.LoadJMonths(ddlMonth, "")

        LoadCountryState()

        Dim oJob As New Job

        If JobID > 0 Then
            oJob = New Job(Me.JobID)

            With oJob
                txtJobTitle.Text = .JobTitle
                txtDescription.Text = .Description

                If Not IsNothing(ddlYear.Items.FindByValue(.ExperienceYr)) Then
                    ddlYear.Items.FindByValue(.ExperienceYr).Selected = True
                End If
                If Not IsNothing(ddlMonth.Items.FindByValue(.ExperienceMn)) Then
                    ddlMonth.Items.FindByValue(.ExperienceMn).Selected = True
                End If
                If Not IsNothing(ddlCountry.Items.FindByValue(.CountryID)) Then
                    ddlCountry.Items.FindByValue(.CountryID).Selected = True
                End If
                If Not IsNothing(ddlState.Items.FindByValue(.StateID)) Then
                    ddlState.Items.FindByValue(.StateID).Selected = True
                End If
            End With

            SetJobIndustry()
            SetCareerLevel()
            SetEduLevel()
            SetCategories()
            SetJobType()
        Else
            txtJobTitle.Text = ""
            txtDescription.Text = ""
            txtCity.Text = ""
            txtZipCode.Text = ""
        End If
    End Sub
    Public Sub Save()
        Dim oJob As New Job
        If Me.JobID > 0 Then
            oJob = New Job(Me.JobID)

            With oJob
                .JobTitle = txtJobTitle.Text
                ' Load UserID based on UNiID and assign it to userID
                '.UserID = 
                '-----------------------------------------------------------------------
                .PosterID = Me.UserID
                .Description = txtDescription.Text
                .ExperienceYr = ddlYear.SelectedValue
                .ExperienceMn = ddlMonth.SelectedValue
                .CountryID = ddlCountry.SelectedValue
                .StateID = ddlState.SelectedValue
                .City = txtCity.Text
                .ZipCode = txtZipCode.Text
            End With
        Else
            With oJob
                .JobTitle = txtJobTitle.Text
                ' Load UserID based on UNiID and assign it to userID
                '.UserID = 
                '-----------------------------------------------------------------------
                .PosterID = Me.UserID
                .JobPostTypeID = JDataHelper.ePostType.Job
                .ExpiryDate = Date.Now.AddMonths(3)
                .Description = txtDescription.Text
                .ExperienceYr = ddlYear.SelectedValue
                .ExperienceMn = ddlMonth.SelectedValue
                .CountryID = ddlCountry.SelectedValue
                .StateID = ddlState.SelectedValue
                .City = txtCity.Text
                .ZipCode = txtZipCode.Text
                .DatePosted = Date.Now
                .IsActive = True

            End With
        End If

        oJob.Save()
        Me.JobID = oJob.JobID

        SaveJobIndustry()
        SaveCareerLevel()
        SaveEduLevel()
        SaveCategories()
        SaveJobType()

    End Sub
    Public Function Validate() As Boolean
        lblError.Text = ""
        lblError.Visible = True
        If Not IsNothing(txtJobTitle) AndAlso txtJobTitle.Text.Trim.Length = 0 Then
            lblError.Text = lblError.Text & "Please enter a job title. <br />"
        End If

        If lblError.Text.Trim.Length = 0 Then
            lblError.Text = ""
            lblError.Visible = False
            Return True
        Else
            Return False
        End If
        Return True
    End Function
    Public Sub SetJobIndustry()
        chkIndustry.Items.Clear()
        If Me.JobID > 0 Then
            If Not IsNothing(chkIndustry) AndAlso chkIndustry.Items.Count > 0 Then
                Dim al As New ArrayList
                Dim oIndustry As New Industry
                al = oIndustry.GetByJob(Me.JobID)
                If Not IsNothing(al) AndAlso al.Count > 0 Then
                    For Each oIndus As Industry In al
                        chkIndustry.Items.FindByValue(oIndus.IndustryID).Selected = True
                    Next
                End If
            End If
        End If
    End Sub
    Public Sub SaveJobIndustry()
        If Not IsNothing(chkIndustry) AndAlso chkIndustry.Items.Count > 0 Then
            Dim oIndus As New Industry
            For Each itm As ListItem In chkIndustry.Items
                If itm.Selected Then
                    oIndus.AddIndustryToJob(Me.JobID, itm.Value)
                Else
                    oIndus.RemoveIndustryFromJob(Me.JobID, itm.Value)
                End If
            Next
        End If
    End Sub
    Public Sub SetJobType()
        chkJobType.Items.Clear()
        If Me.JobID > 0 Then
            If Not IsNothing(chkJobType) AndAlso chkJobType.Items.Count > 0 Then
                Dim al As New ArrayList
                Dim oJobType As New JobType
                al = oJobType.GetByJob(Me.JobID)
                If Not IsNothing(al) AndAlso al.Count > 0 Then
                    For Each oJT As JobType In al
                        chkJobType.Items.FindByValue(oJT.JobTypeID).Selected = True
                    Next
                End If
            End If
        End If
    End Sub
    Public Sub SaveJobType()
        If Not IsNothing(chkJobType) AndAlso chkJobType.Items.Count > 0 Then
            Dim oJobType As New JobType
            For Each itm As ListItem In chkJobType.Items
                If itm.Selected Then
                    oJobType.AddJobTypeToJob(Me.JobID, itm.Value)
                Else
                    oJobType.RemoveJobTypeFromJob(Me.JobID, itm.Value)
                End If
            Next
        End If
    End Sub
    Public Sub SetEduLevel()
        chkEduLevel.Items.Clear()
        If Me.JobID > 0 Then
            If Not IsNothing(chkEduLevel) AndAlso chkEduLevel.Items.Count > 0 Then
                Dim al As New ArrayList
                Dim oEduLevel As New EduLevel
                al = oEduLevel.GetByJob(Me.JobID)
                If Not IsNothing(al) AndAlso al.Count > 0 Then
                    For Each oEL As EduLevel In al
                        chkEduLevel.Items.FindByValue(oEL.EduLevelID).Selected = True
                    Next
                End If
            End If
        End If
    End Sub
    Public Sub SaveEduLevel()
        If Not IsNothing(chkEduLevel) AndAlso chkEduLevel.Items.Count > 0 Then
            Dim oEduLevel As New EduLevel
            For Each itm As ListItem In chkEduLevel.Items
                If itm.Selected Then
                    oEduLevel.AddEduLevelToJob(Me.JobID, itm.Value)
                Else
                    oEduLevel.RemoveEduLevelFromJob(Me.JobID, itm.Value)
                End If
            Next
        End If
    End Sub

    Public Sub SetCareerLevel()
        chkCareerLevel.Items.Clear()
        If Me.JobID > 0 Then
            If Not IsNothing(chkCareerLevel) AndAlso chkCareerLevel.Items.Count > 0 Then
                Dim al As New ArrayList
                Dim oCarLevel As New CareerLevel
                al = oCarLevel.GetByJob(Me.JobID)
                If Not IsNothing(al) AndAlso al.Count > 0 Then
                    For Each oCL As CareerLevel In al
                        chkCareerLevel.Items.FindByValue(oCL.CareerLevelID).Selected = True
                    Next
                End If
            End If
        End If
    End Sub
    Public Sub SaveCareerLevel()
        If Not IsNothing(chkCareerLevel) AndAlso chkCareerLevel.Items.Count > 0 Then
            Dim oCarLevel As New CareerLevel
            For Each itm As ListItem In chkCareerLevel.Items
                If itm.Selected Then
                    oCarLevel.AddCareerLevelToJob(Me.JobID, itm.Value)
                Else
                    oCarLevel.RemoveCareerLevelFromJob(Me.JobID, itm.Value)
                End If
            Next
        End If
    End Sub

    Public Sub SetCategories()
        chkCategory.Items.Clear()
        If Me.JobID > 0 Then
            If Not IsNothing(chkCategory) AndAlso chkCategory.Items.Count > 0 Then
                Dim al As New ArrayList
                Dim oCate As New JCategory
                al = oCate.GetJJobCategories(Me.JobID)
                If Not IsNothing(al) AndAlso al.Count > 0 Then
                    For Each oJC As JCategory In al
                        chkCategory.Items.FindByValue(oJC.JobCategoryID).Selected = True
                    Next
                End If
            End If
        End If
    End Sub
    Public Sub SaveCategories()
        If Not IsNothing(chkCategory) AndAlso chkCategory.Items.Count > 0 Then
            Dim oCate As New JCategory
            For Each itm As ListItem In chkCategory.Items
                If itm.Selected Then
                    oCate.AddCategoryToJob(Me.JobID, itm.Value)
                Else
                    oCate.RemoveCategoryFromJob(Me.JobID, itm.Value)
                End If
            Next
        End If
    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Validate() Then
            Save()
        End If
    End Sub
    Public Sub LoadCountryState()
        UIHelper.LoadCountry(Me.ddlCountry, "--Select Country")
        Me.ddlCountry.SelectedValue = "271"
       
        UIHelper.LoadStatesByCountry(Me.ddlState, "-- Select State --", CInt(Me.ddlCountry.SelectedValue))
        If Me.ddlState.Items.Count = 0 Then
            Me.ddlState.Visible = False
        Else
            Me.ddlState.Visible = True
        End If

    End Sub
    Protected Sub ddlCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCountry.SelectedIndexChanged
        UIHelper.LoadStatesByCountry(Me.ddlState, "-- Select State --", CInt(Me.ddlCountry.SelectedValue))
        If Me.ddlState.Items.Count = 0 Then
            Me.ddlState.Visible = False
        Else
            Me.ddlState.Visible = True
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        LoadData()

    End Sub
End Class
