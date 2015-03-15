
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.UI

Imports UserLibrary
Imports JobLibrary
Partial Class JobUC_JResumeView
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
    Public ReadOnly Property UserName() As String
        Get
            If Not IsNothing(Request.Item("UserName")) AndAlso Request.Item("UserName").Trim.Length > 0 Then
                Return Request.Item("UserName")
            Else
                Return ""
            End If
        End Get
    End Property
    Public Function GetUser() As Users
        Dim ui As Users
        If UserName <> String.Empty Then
            ui = New Users(UserName)
        Else
            ui = Session("Users")
        End If

        If Not IsNothing(ui) AndAlso ui.UserID > 0 Then
            Return ui
        Else
            Return New Users
        End If
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadData()
        End If
    End Sub
    Public Sub LoadData()
        Dim oJResume As New JResume()
        If Me.JResumeID > 0 Then
            oJResume = New JResume(Me.JResumeID)
            'Me.UserID = oJResume.UserID
        ElseIf GetUser().UserID > 0 Then
            oJResume.LoadByUser(GetUser().UserID)
            'Response.Write(GetUser().UserID)
        End If

        '    objWord.Attributes.Add("Data", oJResume.ResumeFile)
        gogViewer.Attributes.Add("Src", "http://docs.google.com/viewer?url=" & Server.HtmlEncode("http://www.unionverse.com/" & oJResume.ResumeFile).Replace(":", "%3A").Replace("/", "%2F") & "&embedded=true")
    End Sub
End Class
