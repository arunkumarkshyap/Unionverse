Imports JobLibrary
Imports UserLibrary
Imports CommonLibrary
Partial Class JobUC_PlanetSearch
    Inherits System.Web.UI.UserControl
    Enum eView
        Grid = 1
        Search = 2
    End Enum
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
    Public Property currentView() As eView
        Get
            If Not IsNothing(ViewState("currentView")) AndAlso IsNumeric(ViewState("currentView")) Then
                Return ViewState("currentView")
            Else
                Return eView.Search
            End If
        End Get
        Set(ByVal value As eView)
            ViewState("currentView") = value
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
    Public Property CountryID() As Integer
        Get
            If Not IsNothing(ViewState("CountryID")) AndAlso IsNumeric(ViewState("CountryID")) Then
                Return ViewState("CountryID")
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("CountryID") = value
        End Set
    End Property
    Public Property StateID() As Integer
        Get
            If Not IsNothing(ViewState("StateID")) AndAlso IsNumeric(ViewState("StateID")) Then
                Return ViewState("StateID")
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("StateID") = value
        End Set
    End Property
    Public Property City() As String
        Get
            If Not IsNothing(ViewState("City")) AndAlso IsNumeric(ViewState("City")) Then
                Return ViewState("City")
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            ViewState("City") = value
        End Set
    End Property

    Public Property CurrentPage() As Integer
        Get
            If Not IsNothing(ViewState("CurrentPage")) AndAlso IsNumeric(ViewState("CurrentPage")) Then
                Return ViewState("CurrentPage")
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("CurrentPage") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetView()
            LoadData()
        End If
    End Sub
    Public Sub SetView(Optional ByVal iView As eView = eView.Search)
        currentView = iView
        If iView = eView.Grid Then
            plhGrid.Visible = True
            plhNoRec.Visible = False
            plhSearch.Visible = False
        ElseIf iView = eView.Search Then
            plhGrid.Visible = False
            plhNoRec.Visible = False
            plhSearch.Visible = True
        End If
    End Sub
    Public Sub LoadData()
        JDataHelper.LoadCareerLevels(chkCareerLevel, "")
        JDataHelper.LoadEduLevels(chkEduLevel, "")
        JDataHelper.LoadIndustry(chkIndustry, "")
        JDataHelper.LoadJobType(chkJobType, "")
        JDataHelper.LoadJobCategories(chkCategory, "")
        JDataHelper.LoadJYears(ddlYear, "")

        txtKeyword.Text = ""
        txtZipCode.Text = ""
        txtDateFrom.Text = ""
        txtDateTo.Text = ""
        txtSrchRadius.Text = ""

    End Sub
    Public Sub LoadResults(Optional ByVal pageNo As Integer = 0)
        Dim al As New ArrayList
        Dim oJob As New Job

        uc_paging.PageNumber = pageNo
        uc_paging.PageSize = 20
        uc_paging.GroupSize = 10
        oJob.PageSize = uc_paging.PageSize
        oJob.CurrentPageNo = uc_paging.PageNumber

        SetView(eView.Grid)

        Dim icate As String = GetCareerLevel()
        Dim iedu As String = GetEduLevel()
        Dim iJType As String = GetJobType()
        Dim iIndus As String = GetJobIndustry()
        Dim iCareer As String = GetCareerLevel()
        Dim radius As Integer = 0

        If Not IsNothing(txtSrchRadius.Text) AndAlso txtSrchRadius.Text.Trim.Length > 0 Then
            radius = CInt(txtSrchRadius.Text)
        Else
            radius = 100000
        End If
        Dim iDtFrm As DateTime = #1/1/1900#
        Dim iDtTo As DateTime = #1/1/1900#
        If Not IsNothing(txtDateFrom) AndAlso txtDateFrom.Text.Trim.Length > 0 AndAlso IsDate(txtDateFrom.Text) Then
            iDtFrm = CDate(txtDateFrom.Text)
        End If
        If Not IsNothing(txtDateTo) AndAlso txtDateTo.Text.Trim.Length > 0 AndAlso IsDate(txtDateTo.Text) Then
            iDtTo = CDate(txtDateTo.Text)
        End If


        If UserID > 0 Then
            If UIHelper.IsSolarSystem(UserID) Then ' For Solar system
                al = oJob.GetFilteredPaged(UserID, JDataHelper.ePostType.iResume, txtKeyword.Text, txtZipCode.Text, radius, icate, iJType, iIndus, iedu, iCareer, iDtFrm, iDtTo, 0, 0, , 0, Me.CountryID, Me.StateID, Me.City, 0, 0, "DatePosted", "Desc")
            Else ' for induvidual
                al = oJob.GetFilteredPaged(UserID, JDataHelper.ePostType.iResume, txtKeyword.Text, txtZipCode.Text, radius, icate, iJType, iIndus, iedu, iCareer, iDtFrm, iDtTo, 0, 0, , 0, Me.CountryID, Me.StateID, Me.City, 0, 0, "DatePosted", "Desc")
            End If
        Else
            al = oJob.GetFilteredPaged(0, JDataHelper.ePostType.iResume, txtKeyword.Text, txtZipCode.Text, radius, icate, iJType, iIndus, iedu, iCareer, iDtFrm, iDtTo, 0, 0, , 0, Me.CountryID, Me.StateID, Me.City, 0, 0, "DatePosted", "Desc")
        End If

        If al.Count > 0 Then
            dgJobs.Visible = True
            plhNoRec.Visible = False
            dgJobs.DataSource = al
            dgJobs.DataBind()
            Me.uc_paging.PageCount = Math.Ceiling(oJob.TotalRecords / oJob.PageSize)
            Me.uc_paging.TotalRecords = oJob.TotalRecords
            Me.phPaging.Visible = True
            Me.lblTotleRecords.Text = oJob.TotalRecords
            If pageNo < Me.uc_paging.PageCount Then
                Me.lblViewing.Text = pageNo * oJob.PageSize - (oJob.PageSize - 1) & "-" & pageNo * oJob.PageSize
            Else
                Me.lblViewing.Text = pageNo * oJob.PageSize - (oJob.PageSize - 1) & "-" & oJob.TotalRecords
            End If
        Else
            plhGrid.Visible = False
            plhNoRec.Visible = True
        End If
    End Sub
    Public Function GetJobIndustry() As String
        Dim result As String = ""
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
        If result.Trim.Length > 0 Then
            result = result.Substring(0, result.LastIndexOf(","))
        End If
        Return result
    End Function
    Public Function GetJobType() As String
        Dim result As String = ""
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
        If result.Trim.Length > 0 Then
            result = result.Substring(0, result.LastIndexOf(","))
        End If
        Return result
    End Function
    Public Function GetEduLevel() As String
        Dim result As String = ""
        If Not IsNothing(chkEduLevel) AndAlso chkEduLevel.Items.Count > 0 Then
            Dim oEduLevel As New EduLevel
            For Each itm As ListItem In chkEduLevel.Items
                If itm.Selected Then
                    result = result & ","
                End If
            Next
        End If
        If result.Trim.Length > 0 Then
            result = result.Substring(0, result.LastIndexOf(","))
        End If
        Return result
    End Function
    Public Function GetCareerLevel() As String
        Dim result As String = ""
        If Not IsNothing(chkCareerLevel) AndAlso chkCareerLevel.Items.Count > 0 Then
            Dim oCarLevel As New CareerLevel
            For Each itm As ListItem In chkCareerLevel.Items
                If itm.Selected Then
                    result = result & ","
                End If
            Next
        End If
        If result.Trim.Length > 0 Then
            result = result.Substring(0, result.LastIndexOf(","))
        End If
        Return result
    End Function
    Public Function GetCategories() As String
        Dim result As String = ""
        If Not IsNothing(chkCategory) AndAlso chkCategory.Items.Count > 0 Then
            Dim oCate As New JCategory
            For Each itm As ListItem In chkCategory.Items
                If itm.Selected Then
                    result = result & ","
                End If
            Next
        End If
        If result.Trim.Length > 0 Then
            result = result.Substring(0, result.LastIndexOf(","))
        End If
        Return result
    End Function
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        plhSearch.Visible = False
        plhGrid.Visible = True
        plhNoRec.Visible = False
        LoadResults(1)

    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        LoadData()
    End Sub
    Protected Sub uc_paging_ClickPage(ByVal PageNumber As Integer) Handles uc_paging.ClickPage
        uc_paging.PageNumber = PageNumber
        Me.CurrentPage = PageNumber
        LoadResults(CurrentPage)
    End Sub

    Protected Sub lbtBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtBack.Click
        SetView(eView.Search)
        LoadData()
    End Sub

    Protected Sub lbtSrchAgain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtSrchAgain.Click
        SetView(eView.Search)
    End Sub
    Protected Sub dgJobs_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgJobs.ItemCommand
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/Members/uvraise/requestview.aspx?jid=" & e.CommandArgument)
        End If
    End Sub
    Public Shared Function getUserProfileIcon(ByVal userID As Integer) As String
        If userID > 0 Then
            Dim _u1 As New Users(userID)

            If _u1.ProfileImage.Trim.Length > 0 Then
                Return UIHelper.GetUnionVerseBasePathURL & "/" & _u1.ProfileImage.Trim
            Else
                Return UIHelper.GetUnionVerseBasePathURL & "/UserFiles/Profiles/Profile-Pic-Man.png"
            End If
        Else
            Return ""
        End If
    End Function

  

    Public Shared Function getUsername(ByVal userID As Integer) As String
        'get username from db
        Dim oU As New Users(userID)
        If Not IsNothing(oU) Then
            Return oU.UserName
        Else
            Return ""
        End If
    End Function
    Public Shared Function getUserEmail(ByVal userID As Integer) As String
        Dim oU As New Users(userID)
        If Not IsNothing(oU) Then
            Return oU.Email
        Else
            Return ""
        End If
    End Function
    Public Shared Function getIndustry(ByVal jobID As Integer) As String
        Dim result As String = ""
        If jobID > 0 Then
            Dim oJI As New Industry
            Dim al As New ArrayList
            al = oJI.GetByJob(jobID)
            For Each oJI In al
                result = result & oJI.IndustryName.Trim & ", "
            Next
        End If
        If result.Trim.Length > 0 Then
            result = result.Substring(0, result.LastIndexOf(","))
        End If
        Return result
    End Function
    Public Shared Function getCategory(ByVal jobID As Integer) As String
        Dim result As String = ""
        If jobID > 0 Then
            Dim oJC As New JCategory
            Dim al As New ArrayList
            al = oJC.GetJJobCategories(jobID)
            For Each oJC In al
                result = result & oJC.JobCategory.Trim & ", "
            Next
        End If
        If result.Trim.Length > 0 Then
            result = result.Substring(0, result.LastIndexOf(","))
        End If
        Return result
    End Function
End Class
