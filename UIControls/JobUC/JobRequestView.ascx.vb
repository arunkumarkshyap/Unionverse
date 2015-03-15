Imports JobLibrary
Partial Class JobUC_JobRequestView
    Inherits System.Web.UI.UserControl
    Public Event LoadEdit(ByVal jobID As Integer)
    Public Property JobID() As Integer
        Get
            If Not IsNothing(ViewState("jid")) AndAlso IsNumeric(ViewState("jid")) Then
                Return ViewState("jid")
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            ViewState("jid") = value
        End Set
    End Property

    Public Property UserID() As Integer
        Get
            If Not IsNothing(ViewState("UserID")) AndAlso IsNumeric(ViewState("UserID")) Then
                Return ViewState("UserID")
            Else
                Return 0
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
        Dim oJob As New Job
        If JobID > 0 Then
            oJob = New Job(Me.JobID)
            With oJob
                'Load user object and display the user info
                lblUsername.Text = .PosterID
                lblRadius.Text = .Param2
                lblSalary.Text = .SalaryMin
                lblYear.Text = .ExperienceYr
                lblMonth.Text = .ExperienceMn
                lblCountry.Text = .CountryID
                lblState.Text = .StateID
            End With
            SetJobIndustry()
            SetCareerLevel()
            SetEduLevel()
            SetCategories()
            SetJobType()
        End If
    End Sub
    Public Sub SetJobIndustry()
        lblIndustry.Text = ""
        If Me.JobID > 0 Then
            Dim al As New ArrayList
            Dim oIndustry As New Industry
            al = oIndustry.GetByJob(Me.JobID)
            If Not IsNothing(al) AndAlso al.Count > 0 Then
                For Each oIndus As Industry In al
                    lblIndustry.Text = lblIndustry.Text & "<span class='gvlu'>" & oIndus.IndustryName & "</span>"
                Next
            End If
        End If
    End Sub
    Public Sub SetJobType()
        lblJobType.Text = ""
        If Me.JobID > 0 Then
            Dim al As New ArrayList
            Dim oJobType As New JobType
            al = oJobType.GetByJob(Me.JobID)
            If Not IsNothing(al) AndAlso al.Count > 0 Then
                For Each oJT As JobType In al
                    lblJobType.Text = lblJobType.Text & "<span class='gvlu'>" & oJT.JobType & "</span>"
                Next
            End If
        End If
    End Sub
    Public Sub SetEduLevel()
        lblEduLevel.Text = ""
        If Me.JobID > 0 Then
            Dim al As New ArrayList
            Dim oEduLevel As New EduLevel
            al = oEduLevel.GetByJob(Me.JobID)
            If Not IsNothing(al) AndAlso al.Count > 0 Then
                For Each oEL As EduLevel In al
                    lblEduLevel.Text = lblEduLevel.Text & "<span class='gvlu'>" & oEL.EduLevel & "</span>"
                Next
            End If

        End If
    End Sub
    Public Sub SetCareerLevel()
        lblCareerLevel.Text = ""
        If Me.JobID > 0 Then
            Dim al As New ArrayList
            Dim oCarLevel As New CareerLevel
            al = oCarLevel.GetByJob(Me.JobID)
            If Not IsNothing(al) AndAlso al.Count > 0 Then
                For Each oCL As CareerLevel In al
                    lblCareerLevel.Text = lblCareerLevel.Text & "<span class='gvlu'>" & oCL.CareerLevel & "</span>"
                Next
            End If
        End If
    End Sub
    Public Sub SetCategories()
        lblCategory.Text = ""
        If Me.JobID > 0 Then
            Dim al As New ArrayList
            Dim oCate As New JCategory
            al = oCate.GetJJobCategories(Me.JobID)
            If Not IsNothing(al) AndAlso al.Count > 0 Then
                For Each oJC As JCategory In al
                    lblCategory.Text = lblCategory.Text & "<span class='gvlu'>" & oJC.JobCategory & "</span>"
                Next
            End If
        End If
    End Sub
    Protected Sub lbtEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtEdit.Load
        RaiseEvent LoadEdit(Me.JobID)
    End Sub
End Class
