Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.UI

Imports UserLibrary

Partial Class UIControls_TopMenuMain
    Inherits System.Web.UI.UserControl
    Public ReadOnly Property UserID() As Integer
        Get
            If Not IsNothing(Session("Users")) Then
                Return CType(Session("Users"), Users).UserID
            Else
                Return 0
            End If
        End Get
    End Property
    Public ReadOnly Property Username() As String
        Get
            If Not IsNothing(Session("Users")) Then
                Return CType(Session("Users"), Users).Username
            Else
                Return ""
            End If
        End Get
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.phGroupType1.Visible = False
        Me.phBusinessType.Visible = False
        Me.phGroupType3Moon.Visible = False
        Me.phWhiteWhole.Visible = False
        Me.phIndividualType1.Visible = False
        Me.phIndividualType2.Visible = False
        If UserID > 0 Then
            Dim oUT1 As New smt_UserType1
            oUT1.LoadByUserID(UserID)   '-------- For Group Type 1

            If Not IsNothing(oUT1) AndAlso oUT1.UserType1ID > 0 Then
                Me.phGroupType1.Visible = True
                Exit Sub
            End If

            Dim oIU1 As New smt_IndividualUserType1     '----------- For Individual User Type 1
            oIU1.LoadByUserID(UserID)
            If Not IsNothing(oIU1) AndAlso oIU1.IndividualUserType1ID > 0 Then
                Me.phIndividualType1.Visible = True
                Exit Sub
            End If

            Dim oIU2 As New smt_IndividualUserType2     '----------- For Individual User Type 2
            oIU2.LoadByUserID(UserID)
            If Not IsNothing(oIU2) AndAlso oIU2.IndividualUserType2ID > 0 Then
                Me.phIndividualType2.Visible = True
                Exit Sub
            End If

            Dim oBU As New smt_BusinessType             '----------- For Business User
            oBU.LoadByUserID(UserID)
            If Not IsNothing(oBU) AndAlso oBU.BusinessTypeID > 0 Then
                aBusinessStore.HRef = UIHelper.GetUnionVerseBasePathURL() & "/Store/store.aspx"
                Me.phBusinessType.Visible = True
                Exit Sub
            End If

            Dim oSU As New smt_School                   '----------- For Moon User (schools and etc)
            oSU.LoadByUserID(UserID)
            If Not IsNothing(oSU) AndAlso oSU.SchoolID > 0 Then
                Me.phGroupType3Moon.Visible = True
                If oSU.Types = "Groups" Then
                    phMoonGeneral.Visible = False
                End If
                Exit Sub
            End If

            Dim oG4 As New smt_GroupType4               '----------- For Group Type 4 (WhiteWholes.com)
            oG4.LoadByUserID(UserID)
            If Not IsNothing(oG4) AndAlso oG4.GroupType4ID > 0 Then
                Me.phWhiteWhole.Visible = True
                Exit Sub
            End If
        End If
    End Sub


End Class
