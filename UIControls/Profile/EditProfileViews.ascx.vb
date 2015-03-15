Imports UserLibrary

Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.UI


Partial Class UIControls_Profile_ProfileViews
    Inherits System.Web.UI.UserControl
    Public ReadOnly Property UserID() As Integer
        Get
            If Not IsNothing(Request.Item("uid")) AndAlso IsNumeric(Request.Item("uid")) Then
                Return CInt(Request.Item("uid"))
            Else
                Return 0
            End If
        End Get
    End Property
 

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ProfileType.Visible = False
        Me.Type4.Visible = False
        Me.planet1.Visible = False
        Me.planet2.Visible = False
        Me.moon.Visible = False
        Me.business.Visible = False

        Dim UserID As Integer = 0
        Dim oui As New Users
        oui = GetUser()
        If Not IsNothing(oui) Then
            UserID = oui.UserID
        End If
        If UserID > 0 Then
            Dim oUT1 As New smt_UserType1
            oUT1.LoadByUserID(UserID)   '-------- For Group Type 1

            If Not IsNothing(oUT1) AndAlso oUT1.UserType1ID > 0 Then
                Me.ProfileType.Visible = True
                Me.ProfileType.UserID = UserID
                If IsPostBack = False Then
                    Me.ProfileType.LoadProfile()
                End If
                Exit Sub
            End If
            Dim oIU1 As New smt_IndividualUserType1     '----------- For Individual User Type 1
            oIU1.LoadByUserID(UserID)
            If Not IsNothing(oIU1) AndAlso oIU1.IndividualUserType1ID > 0 Then
                Me.planet1.Visible = True
                Me.planet1.UserID = UserID
                If IsPostBack = False Then
                    Me.planet1.LoadProfile()

                End If
                Exit Sub
            End If

            Dim oIU2 As New smt_IndividualUserType2     '----------- For Individual User Type 2
            oIU2.LoadByUserID(UserID)
            If Not IsNothing(oIU2) AndAlso oIU2.IndividualUserType2ID > 0 Then
                Me.planet2.Visible = True
                Me.planet2.UserID = UserID
                If IsPostBack = False Then
                    Me.planet2.LoadProfile()
                End If

                Exit Sub
            End If

            Dim oBU As New smt_BusinessType             '----------- For Business User
            oBU.LoadByUserID(UserID)
            If Not IsNothing(oBU) AndAlso oBU.BusinessTypeID > 0 Then
                Me.business.Visible = True
                Me.business.UserID = UserID
                If IsPostBack = False Then
                    Me.business.Loadprofile()
                End If
                Exit Sub
            End If

            Dim oSU As New smt_School                   '----------- For Moon User (schools and etc)
            oSU.LoadByUserID(UserID)
            If Not IsNothing(oSU) AndAlso oSU.SchoolID > 0 Then
                Me.moon.Visible = True
                Me.moon.UserID = UserID
                If IsPostBack = False Then
                    Me.moon.LoadProfile()
                End If

                Exit Sub
            End If

            Dim oG4 As New smt_GroupType4               '----------- For Group Type 4 (WhiteWholes.com)
            oG4.LoadByUserID(UserID)
            If Not IsNothing(oG4) AndAlso oG4.GroupType4ID > 0 Then
                Me.Type4.Visible = True
                Me.Type4.UserID = UserID
                If IsPostBack = False Then
                    Me.Type4.LoadProfile()
                End If

                Exit Sub
            End If

            'Me.BasicProfile1.Visible = True
            'Me.BasicProfile1.UserID = UserID
            'Me.BasicProfile1.LoadData()
        End If
    End Sub

    Public Function GetUser() As Users
        Dim ui As New Users
        If (UserID > 0) Then
            ui = New Users(UserID)
        End If
        Return ui
    End Function
End Class
