Imports UserLibrary
Imports CommonLibrary
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.UI


Partial Class UIControls_UVRaiseShortCuts
    Inherits System.Web.UI.UserControl


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session("Users")) Then


            Dim _IsAdmin As Boolean = False
            If CType(Session("Users"), Users).UserTypeID = 0 Then
                _IsAdmin = True
            End If

            Me.phCompany.Visible = False
            Me.phUsers.Visible = False
            Me.phSolarSystem.Visible = False
            If _IsAdmin Then
                ' Response.Redirect(SMTUIHelper.GetUnionVerseBasePathURL)
            End If

            If UIHelper.IsInd1or2(CType(Session("Users"), Users).UserID) Then
                Me.phUsers.Visible = True
            ElseIf UIHelper.IsSolarSystem(CType(Session("Users"), Users).UserID) Then
                Me.phSolarSystem.Visible = True
            Else
                Me.phCompany.Visible = True
            End If
        End If
    End Sub
    Public ReadOnly Property UserName() As String
        Get
            If Not IsNothing(Request.Item("UserName")) Then
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
                ui = CType(Session("Users"), Users)
            End If
        End If

        If Not IsNothing(ui) AndAlso ui.UserID > 0 Then
            Return ui
        Else
            Return New Users
        End If
    End Function


    Public Function SolarSystemUserName() As String
        If GetUser.UserID > 0 Then
            Dim oInd1 As New smt_IndividualUserType1()
            oInd1.LoadByUserID(GetUser.UserID)
            ' ConfigurationManager.AppSettings("CSUnionVerse")
            Dim GroupTypeID As Integer = 0
            If Not IsNothing(oInd1) AndAlso oInd1.GroupTypeID > 0 Then
                GroupTypeID = oInd1.GroupTypeID
            End If
            Dim oInd2 As New smt_IndividualUserType2
            oInd2.LoadByUserID(GetUser.UserID)
            If Not IsNothing(oInd2) AndAlso oInd2.GroupTypeID > 0 Then
                GroupTypeID = oInd2.GroupTypeID
            End If
            If GroupTypeID > 0 Then
                Dim oUT1 As New smt_UserType1(GroupTypeID)
                If Not IsNothing(oUT1) AndAlso oUT1.UserID > 0 Then
                    Return oUT1.UserName
                Else
                    Return ""
                End If
            Else
                Return ""
            End If
        Else
            Return ""
        End If
    End Function
End Class
