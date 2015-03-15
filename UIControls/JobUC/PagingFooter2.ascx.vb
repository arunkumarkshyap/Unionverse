Imports System.Drawing
Partial Class PagingFooter2
    Inherits System.Web.UI.UserControl
    Public Event ClickPage(ByVal PageNumber As Integer)
    Public PostBack As Integer = 0
    Private mPageNumber As Integer = 0
    Private mPageCount As Integer = 0
    Private mMinRows As Integer = 3
    Private mRowCount As Integer = 0
    Private mPageSize As Integer = 25
    Private MinLimit As Integer
    Private mGroupsCount As Integer = 0
    Private mCurrentGroup As Integer = 0
    Private mTotalRecords As Integer = 0
    Private mGroupSize As Integer = 10
#Region "With Events Variables"
    Protected WithEvents lblPages As System.Web.UI.WebControls.Label
    Protected WithEvents lblTitlee As System.Web.UI.WebControls.Label
#End Region
    Const ROWHEIGHT As Integer = 15
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub


    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Page.IsPostBack = False Or PostBack = 1 Then
            ShowPageNumbers()
            PostBack = 0
        End If
    End Sub
    Private Sub ComputeMinRowSpacerHeight()

        Dim iDisplayedRows As Integer = 0

        'if mPageNumber = mPageCount Then
        'DisplayedRows = mRowCount Mod PAGESIZE
        If mRowCount < PageSize Then
            iDisplayedRows = mRowCount
        Else
            iDisplayedRows = PageSize
        End If

        'trMinRowSpacer.Height = IIf(iDisplayedRows < mMinRows, (mMinRows - iDisplayedRows) * ROWHEIGHT, 0)
        trMinRowSpacer.Height = IIf(iDisplayedRows < mMinRows, 7, 0)
    End Sub

    Private Sub imgbtnPrev_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgbtnPrev.Click
        GroupNumber -= 1
        PageNumber = (mCurrentGroup * GroupSize) + 1
        ShowPageNumbers()
        RaiseEvent ClickPage(PageNumber)
        'RaiseEvent ClickPrev()
    End Sub
    Private Sub imgbtnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgbtnNext.Click
        GroupNumber += 1
        PageNumber = (mCurrentGroup * GroupSize) + 1
        ShowPageNumbers()
        RaiseEvent ClickPage(PageNumber)
        'RaiseEvent ClickNext()
    End Sub
    Public Property PageNumber() As Integer
        Get
            Return Val(lblPageNumber.Text)
        End Get
        Set(ByVal Value As Integer)
            lblPageNumber.Text = Value
            mPageNumber = Value
            'Set paging buttons            
            ComputeMinRowSpacerHeight()
        End Set
    End Property
    Public Property TotalRecords() As Integer
        Get
            Return hidTotalRecords.Value
        End Get
        Set(ByVal Value As Integer)
            hidTotalRecords.Value = Value
            mTotalRecords = hidTotalRecords.Value
            'Me.lblRecordsCount.Visible = (PageCount >= 1)
            '
            ShowPageNumbers()
        End Set
    End Property
    '
    Public Property PageCount() As Integer
        Get
            Return Val(lblPageCount.Text)
        End Get
        Set(ByVal Value As Integer)
            lblPageCount.Text = Value
            mPageCount = Value
            'Set paging buttons
            tdPagingFooter.Visible = (PageCount >= 1)
            ComputeMinRowSpacerHeight()
            ''
            GroupCount = Math.Ceiling(lblPageCount.Text / GroupSize)
        End Set
    End Property
    Public Property CssClass() As String
        Get
            Return trPagingFooter.Attributes.Item("Class")
        End Get
        Set(ByVal Value As String)
            trPagingFooter.Attributes.Add("Class", Value)
        End Set
    End Property

    Public Property MinRows() As Integer
        Get
            Return mMinRows
        End Get
        Set(ByVal Value As Integer)
            mMinRows = Value
        End Set
    End Property
    Public Property RowCount() As Integer
        Get
            Return mRowCount
        End Get
        Set(ByVal Value As Integer)
            mRowCount = Value
            ComputeMinRowSpacerHeight()
        End Set
    End Property
    Public Property PageSize() As Integer
        Get
            Return mPageSize
        End Get
        Set(ByVal Value As Integer)
            mPageSize = Value
            ComputeMinRowSpacerHeight()
        End Set
    End Property
    Public Property GroupCount() As Integer
        Get
            mGroupsCount = Me.hidGroupCount.Value
            Return mGroupsCount
        End Get
        Set(ByVal Value As Integer)
            Me.hidGroupCount.Value = Value
            mGroupsCount = Me.hidGroupCount.Value
            '''
            imgbtnPrev.Visible = (Me.hidCurrentGroup.Value > 0)
            'imgBtnFirst.Visible = imgbtnPrev.Visible
            imgbtnNext.Visible = (Me.hidCurrentGroup.Value + 1 < GroupCount)
            'imgBtnLast.Visible = imgbtnNext.Visible
        End Set
    End Property
    Public Property GroupNumber() As Integer
        Get
            mCurrentGroup = Me.hidCurrentGroup.Value
            Return mCurrentGroup
        End Get
        Set(ByVal Value As Integer)
            Me.hidCurrentGroup.Value = Value
            mCurrentGroup = Me.hidCurrentGroup.Value
            '''
            imgbtnPrev.Visible = (Me.hidCurrentGroup.Value > 0)
            'imgBtnFirst.Visible = imgbtnPrev.Visible
            imgbtnNext.Visible = (Me.hidCurrentGroup.Value + 1 < GroupCount)
            'imgBtnLast.Visible = imgbtnNext.Visible
        End Set
    End Property
    Public Property GroupSize() As Integer
        Get
            mGroupSize = Me.hidGroupSize.Value
            Return mGroupSize
        End Get
        Set(ByVal Value As Integer)
            Me.hidGroupSize.Value = Value
            mGroupSize = Me.hidGroupSize.Value
        End Set
    End Property
    Private Sub imgBtnLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgBtnLast.Click
        GroupNumber = GroupCount - 1
        PageNumber = Me.lblPageCount.Text '(mCurrentGroup * mGroupSize) + 1
        ShowPageNumbers()
        RaiseEvent ClickPage(PageNumber)
        'RaiseEvent ClickLast()
    End Sub
    Private Sub imgBtnFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgBtnFirst.Click
        GroupNumber = 0
        PageNumber = (mCurrentGroup * mGroupSize) + 1
        ShowPageNumbers()
        RaiseEvent ClickPage(PageNumber)
        'RaiseEvent ClickFirst()
    End Sub
    Private Sub ShowPageNumbers()
        Dim minLimit As Integer = (GroupNumber * GroupSize) + 1
        Dim i As Integer
        For i = minLimit To minLimit + (GroupSize - 1)
            Dim str As String = "LBP" & i - ((GroupNumber * GroupSize))
            If i <= Me.PageCount Then
                CType(FindControl(str), LinkButton).Text = i
                CType(FindControl(str), LinkButton).Visible = True
                If i = CInt(lblPageNumber.Text) Then
                    CType(FindControl(str), LinkButton).ForeColor = Color.Red
                    CType(FindControl(str), LinkButton).Font.Underline = False
                    CType(FindControl(str), LinkButton).Font.Bold = True
                Else
                    CType(FindControl(str), LinkButton).ForeColor = Color.Black
                    CType(FindControl(str), LinkButton).Font.Underline = True
                    CType(FindControl(str), LinkButton).Font.Bold = False
                End If
            Else
                CType(FindControl(str), LinkButton).Visible = False
            End If
        Next
        If Not IsNothing(lblPageNumber) AndAlso lblPageNumber.Text.Trim.Length > 0 Then

            Dim FromRecords As Integer = ((lblPageNumber.Text - 1) * PageSize) + 1
            Dim ToRecords As Integer = ((lblPageNumber.Text) * PageSize)

            If ToRecords > TotalRecords Then
                Me.lblRecordsCount.Text = FromRecords & " - " & TotalRecords & " of " & TotalRecords
            Else
                Me.lblRecordsCount.Text = FromRecords & " - " & ToRecords & " of " & TotalRecords
            End If
        End If
    End Sub

#Region "Page Number Click Events"
    Private Sub LBP1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBP1.Click
        RaiseEvent ClickPage(LBP1.Text)
        SetPageNumberLinkStyle(1)
    End Sub
    Private Sub LBP2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBP2.Click
        RaiseEvent ClickPage(LBP2.Text)
        SetPageNumberLinkStyle(2)
    End Sub
    Private Sub LBP3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBP3.Click
        RaiseEvent ClickPage(LBP3.Text)
        SetPageNumberLinkStyle(3)
    End Sub
    Private Sub LBP4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBP4.Click
        RaiseEvent ClickPage(LBP4.Text)
        SetPageNumberLinkStyle(4)
    End Sub
    Private Sub LBP5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBP5.Click
        RaiseEvent ClickPage(LBP5.Text)
        SetPageNumberLinkStyle(5)
    End Sub
    Private Sub LBP6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBP6.Click
        RaiseEvent ClickPage(LBP6.Text)
        SetPageNumberLinkStyle(6)
    End Sub
    Private Sub LBP7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBP7.Click
        RaiseEvent ClickPage(LBP7.Text)
        SetPageNumberLinkStyle(7)
    End Sub
    Private Sub LBP8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBP8.Click
        RaiseEvent ClickPage(LBP8.Text)
        SetPageNumberLinkStyle(8)
    End Sub
    Private Sub LBP9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBP9.Click
        RaiseEvent ClickPage(LBP9.Text)
        SetPageNumberLinkStyle(9)
    End Sub
    Private Sub LBP10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBP10.Click
        RaiseEvent ClickPage(LBP10.Text)
        SetPageNumberLinkStyle(10)
    End Sub
    Private Sub SetPageNumberLinkStyle(ByVal pageNumber As Integer)
        Dim i As Integer
        For i = 1 To 10
            Dim str As String = "LBP" & i
            If i = pageNumber Then
                CType(FindControl(str), LinkButton).ForeColor = Color.Red
                CType(FindControl(str), LinkButton).Font.Underline = False
                CType(FindControl(str), LinkButton).Font.Bold = True
            Else
                CType(FindControl(str), LinkButton).ForeColor = Color.Black
                CType(FindControl(str), LinkButton).Font.Underline = True
                CType(FindControl(str), LinkButton).Font.Bold = False
            End If
        Next

        Dim CurrentControl As String = "LBP" & pageNumber
        Dim CurrentPageNumber As Object = CType(FindControl(CurrentControl), LinkButton).Text
        Dim FromRecords As Integer = ((CurrentPageNumber - 1) * PageSize) + 1
        Dim ToRecords As Integer = ((CurrentPageNumber) * (PageSize))
        If ToRecords > TotalRecords Then
            Me.lblRecordsCount.Text = FromRecords & " - " & TotalRecords & " of " & TotalRecords
        Else
            Me.lblRecordsCount.Text = FromRecords & " - " & ToRecords & " of " & TotalRecords
        End If

    End Sub
#End Region

End Class

