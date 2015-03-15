Imports UserLibrary
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.UI
Partial Class UIControls_UNIonVERSITYSideMenu
    Inherits System.Web.UI.UserControl
    Public currentUser As New Users
    Public ReadOnly Property UserID() As Integer
        Get
            If Not IsNothing(Request.Item("uid")) AndAlso IsNumeric(Request.Item("uid")) Then
                Return CInt(Request.Item("uid"))
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
        If Not IsNothing(ui) AndAlso ui.UserID > 0 Then
            Return ui
        ElseIf Not IsNothing(Session("Users")) Then
            Return CType(Session("Users"), Users)
        Else
            Return New Users
        End If
    End Function
    Public Function GetStarShipUserName() As String
        Dim str As String = ""
        If GetUser().UserTypeID = CommonLibrary.Utility.eUserTypes.IndividualType1 Then
            Dim oIU1 As New smt_IndividualUserType1
            oIU1.LoadByUserID(UserID)
            If Not IsNothing(oIU1) AndAlso oIU1.GroupTypeID > 0 Then
                Dim oGT1 As New smt_UserType1(oIU1.GroupTypeID)
                If Not IsNothing(oGT1) AndAlso oGT1.UserType1ID > 0 Then
                    Return oGT1.UserName
                End If
            End If
        ElseIf GetUser().UserTypeID = CommonLibrary.Utility.eUserTypes.IndividualType2 Then
            Dim oIU2 As New smt_IndividualUserType2
            oIU2.LoadByUserID(UserID)
            If Not IsNothing(oIU2) AndAlso oIU2.GroupTypeID > 0 Then
                Dim oGT1 As New smt_UserType1(oIU2.GroupTypeID)
                If Not IsNothing(oGT1) AndAlso oGT1.UserType1ID > 0 Then
                    Return oGT1.UserName
                End If
            End If
        Else
            str = ""
        End If
        Return str
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        currentUser = GetUser()
        Me.phGroupType1.Visible = False
        Me.phIndividualType1.Visible = False
        Me.phMasterUVAccount.Visible = False

        If GetUser.UserID > 0 Then
            Dim oUT1 As New smt_UserType1
            oUT1.LoadByUserID(GetUser.UserID)   '-------- For Group Type 1

            If Not IsNothing(oUT1) AndAlso oUT1.UserType1ID > 0 Then
                Me.phGroupType1.Visible = True

                Exit Sub
            End If
            Dim oIU1 As New smt_IndividualUserType1     '----------- For Individual User Type 1
            oIU1.LoadByUserID(GetUser.UserID)
            If Not IsNothing(oIU1) AndAlso oIU1.IndividualUserType1ID > 0 Then
                Me.phIndividualType1.Visible = True

                Exit Sub
            End If
            Dim oIU2 As New smt_IndividualUserType2     '----------- For Individual User Type 2
            oIU2.LoadByUserID(GetUser.UserID)
            If Not IsNothing(oIU2) AndAlso oIU2.IndividualUserType2ID > 0 Then
                Me.phIndividualType1.Visible = True
                Exit Sub
            End If
            If GetUser().RoleID = 0 Then
                Me.phMasterUVAccount.Visible = True
                Exit Sub
            End If
        End If
    End Sub

End Class
