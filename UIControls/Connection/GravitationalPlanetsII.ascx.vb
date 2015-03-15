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

Partial Class CMSModules_Membership_Controls_GravitationalPlanetsII
    Inherits System.Web.UI.UserControl
    Public Property UserID() As Integer
        Get
            If Not IsNothing(ViewState("UserID")) AndAlso IsNumeric(ViewState("UserID")) Then
                Return CInt(ViewState("UserID"))
            Else
                If Not IsNothing(Session("Users")) AndAlso CType(Session("Users"), Users).UserID > 0 Then
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
        Dim Arl As New ArrayList
        Dim oCF As New Friends
        Arl = oCF.GravitationalPlannetGetByFillter(UserID)
        If Arl.Count > 0 Then
            Me.rpGravirational.DataSource = Arl
            Me.rpGravirational.DataBind()
        Else
            Me.rpGravirational.DataSource = New ArrayList
            Me.rpGravirational.DataBind()
        End If
    End Sub

    Public Function GetUserImage(ByVal UserID As Integer) As String
        Dim _u1 As New Users(UserID)
        If _u1.ProfileImage.Trim.Length > 0 Then
            Return UIHelper.GetUnionVerseBasePathURL & "/" & _u1.ProfileImage.Trim
        Else
            Return UIHelper.GetUnionVerseBasePathURL & "/UserFiles/Profiles/Profile-Pic-Man.png"
        End If

    End Function


End Class
