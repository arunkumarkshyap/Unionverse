Imports JobLibrary
Imports System.IO

Partial Class JobUC_JResumeAddEdit
    Inherits System.Web.UI.UserControl
    Public Property JResumeID() As Integer
        Get
            If Not IsNothing(ViewState("JResumeID")) AndAlso IsNumeric(ViewState("JResumeID")) Then
                Return ViewState("JResumeID")
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("JResumeID") = value
        End Set
    End Property
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
            SetView()
        End If
    End Sub
    Public Sub SetView()
    End Sub
    Public Sub LoadData()
        SetView()
        If JResumeID > 0 Then
        End If
    End Sub
    Public Sub Save()
        Dim oJResume As New JResume()
        Dim oUser As New UserLibrary.Users(UserID)
        If Me.JResumeID > 0 Then
            oJResume = New JResume(Me.JResumeID)
            Me.UserID = oJResume.UserID
        ElseIf UserID > 0 Then
            oJResume.LoadByUser(Me.UserID)
        End If

        With oJResume
            Dim path As String = Server.MapPath(Request.ApplicationPath) & "/iResume/" & Me.UserID & "/"
            If Not Directory.Exists(path) Then
                Directory.CreateDirectory(path)
            End If
            If Me.fupImageURL.FileName.Trim.Length > 0 Then
                Me.fupImageURL.PostedFile.SaveAs(path & Me.fupImageURL.FileName)
                oJResume.ResumeFile = "iResume/" & Me.UserID & "/" & Me.fupImageURL.FileName
                oJResume.ResumeFileType = fupImageURL.PostedFile.ContentType
            End If
            .UserID = Me.UserID
            .DatePosted = Date.Now
            .IsActive = True
            .Username = oUser.Username    '"M. Haroon Bhatti" ' Load from DB
            .LastUpdated = Date.Now
            .jobID = Me.JobID
        End With

        oJResume.Save()
        Me.JResumeID = oJResume.JResumeID
        Me.lblError.Text = "Resume uploaded successfully."
    End Sub
    Public Function Validate() As Boolean
        lblError.Text = ""
        lblError.Visible = True
        If Not Me.fupImageURL.HasFile Then
            lblError.Text = lblError.Text & "Please select a file to upload. <br />"
            'ElseIf Me.fupImageURL.PostedFile.ContentType.ToString <> ".doc" Or Me.fupImageURL.PostedFile.ContentType.ToString <> "pdf" Then
            '    lblError.Text = lblError.Text & "Only MS word or pdf file types are accepted. <br />"
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
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Validate() Then
            Save()
        End If
    End Sub
End Class
