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
        Me.GroupType1View1.Visible = False
        Me.IndividualType1View1.Visible = False
        Me.IndividualType2View1.Visible = False
        Me.BusinessUsersView1.Visible = False
        Me.MoonsView1.Visible = False
        Me.GroupType4View1.Visible = False
        Me.BasicProfile1.Visible = False
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
                Me.GroupType1View1.Visible = True
                Me.GroupType1View1.UserID = UserID
                Me.GroupType1View1.LoadData()
                Exit Sub
            End If
            Dim oIU1 As New smt_IndividualUserType1     '----------- For Individual User Type 1
            oIU1.LoadByUserID(UserID)
            If Not IsNothing(oIU1) AndAlso oIU1.IndividualUserType1ID > 0 Then
                Me.IndividualType1View1.Visible = True
                Me.IndividualType1View1.UserID = UserID
                Me.IndividualType1View1.LoadData()
                Exit Sub
            End If

            Dim oIU2 As New smt_IndividualUserType2     '----------- For Individual User Type 2
            oIU2.LoadByUserID(UserID)
            If Not IsNothing(oIU2) AndAlso oIU2.IndividualUserType2ID > 0 Then
                Me.IndividualType2View1.Visible = True
                Me.IndividualType2View1.UserID = UserID
                Me.IndividualType2View1.LoadData()
                Exit Sub
            End If

            Dim oBU As New smt_BusinessType             '----------- For Business User
            oBU.LoadByUserID(UserID)
            If Not IsNothing(oBU) AndAlso oBU.BusinessTypeID > 0 Then
                Me.BusinessUsersView1.Visible = True
                Me.BusinessUsersView1.UserID = UserID
                Me.BusinessUsersView1.LoadData()
                Exit Sub
            End If

            Dim oSU As New smt_School                   '----------- For Moon User (schools and etc)
            oSU.LoadByUserID(UserID)
            If Not IsNothing(oSU) AndAlso oSU.SchoolID > 0 Then
                Me.MoonsView1.Visible = True
                Me.MoonsView1.UserID = UserID
                Me.MoonsView1.LoadData()
                Exit Sub
            End If

            Dim oG4 As New smt_GroupType4               '----------- For Group Type 4 (WhiteWholes.com)
            oG4.LoadByUserID(UserID)
            If Not IsNothing(oG4) AndAlso oG4.GroupType4ID > 0 Then
                Me.GroupType4View1.Visible = True
                Me.GroupType4View1.UserID = UserID
                Me.GroupType4View1.LoadData()
                Exit Sub
            End If

            Me.BasicProfile1.Visible = True
            Me.BasicProfile1.UserID = UserID
            Me.BasicProfile1.LoadData()
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
