Imports JobLibrary
Imports CommonLibrary
Imports UserLibrary

Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.UI


Partial Class CMSWebParts_SMTWebParts_JobUC_SolarSystemUVRaise
    Inherits System.Web.UI.UserControl
    Public ReadOnly Property UserName() As String
        Get
            If Not IsNothing(Request.Item("UserName")) AndAlso Request.Item("UserName").Trim.Length > 0 Then
                Return Request.Item("UserName").Trim
            Else
                Return ""
            End If
        End Get

    End Property

    Public ReadOnly Property UserID() As Integer
        Get
            If Not IsNothing(Request.Item("UserID")) AndAlso IsNumeric(Request.Item("UserID")) Then
                Return CInt(Request.Item("UserID"))
            Else
                Return 0
            End If
        End Get
    End Property

    Public Function GetUser() As Users
        Dim ui As New Users

        If (UserID > 0) Then
            ui = New Users(UserID)
        End If
        If UserName <> String.Empty Then
            ui = New Users(UserName)
        Else
            If Not IsNothing(Session("Users")) Then
                ui = Session("Users")
            Else
                ui = New Users
            End If
        End If

        If Not IsNothing(ui) AndAlso ui.UserID > 0 Then
            Return ui
        Else
            Return New Users
        End If
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.PlanetSearch1.UserID = GetUser().UserID
            Me.PlanetSearch1.LoadResults(0)
        End If
    End Sub
End Class
