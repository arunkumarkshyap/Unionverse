Imports UserLibrary
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.UI
Partial Class UIControls_SideMenu_
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
        LoadPicture()
        FranchiseList.UserID = UserID
        FranchiseList.LoadGrid()
        currentUser = GetUser()
        Me.phGroupType1.Visible = False
        Me.phBusinessType.Visible = False
        Me.phGroupType3Moon.Visible = False
        Me.phWhiteWhole.Visible = False
        Me.phIndividualType1.Visible = False
        Me.phIndividualType2.Visible = False
        Me.pG1.Visible = False
        Me.pG2.Visible = False
        Me.pG3.Visible = False
        Me.pG4.Visible = False
        Me.pI1.Visible = False
        Me.pI2.Visible = False
        Me.aMorePictures.HRef = UIHelper.GetUnionVerseBasePathURL & "/Members/" & currentUser.Username & ".aspx#Pictures"
        Me.divPicture.Visible = False
        If GetUser.UserID > 0 Then
            Dim oUT1 As New smt_UserType1
            oUT1.LoadByUserID(GetUser.UserID)   '-------- For Group Type 1
            Me.hlInbox.NavigateUrl = UIHelper.GetBasePath & "/Messages.aspx"
            If Not IsNothing(oUT1) AndAlso oUT1.UserType1ID > 0 Then
                Me.divPicture.Visible = True
                Me.phGroupType1.Visible = True
                Me.hlG1HomePage.NavigateUrl = UIHelper.GetBasePath & "/Members/" & currentUser.Username & ".aspx"
                Me.pG1.Visible = True
                Exit Sub
            End If
            Dim oIU1 As New smt_IndividualUserType1     '----------- For Individual User Type 1
            oIU1.LoadByUserID(GetUser.UserID)
            If Not IsNothing(oIU1) AndAlso oIU1.IndividualUserType1ID > 0 Then
                Me.phIndividualType1.Visible = True
                Me.pI1.Visible = True
                Me.hlI1HomePage.NavigateUrl = UIHelper.GetBasePath & "/Members/" & currentUser.Username & ".aspx"
                Dim oSV As New smt_StarShipVoyager()
                Dim Arl As New ArrayList
                Arl = oSV.StarShipVoyagerGetByEmployeeUserID(GetUser.UserID)
                If Arl.Count > 0 Then
                    oSV = New smt_StarShipVoyager
                    oSV = Arl.Item(0)
                    If Not IsNothing(oSV) AndAlso oSV.FriendUserName.Trim.Length > 0 Then
                        Me.hlI1StarShipHomePage.NavigateUrl = UIHelper.GetUnionVerseBasePathURL() & "/Members/" & oSV.FriendUserName.Trim & ".aspx"
                    Else
                        Me.hlI1StarShipHomePage.NavigateUrl = UIHelper.GetUnionVerseBasePathURL() & "/Connections/StarShipSearch.aspx"
                    End If
                Else
                    Me.hlI1StarShipHomePage.NavigateUrl = UIHelper.GetUnionVerseBasePathURL() & "/Connections/StarShipSearch.aspx"
                End If
                Me.hlI1SolarSystem.NavigateUrl = UIHelper.GetUnionVerseBasePathURL() & "/Connections/SolarSystemSearch.aspx"
                Me.divPicture.Visible = True
                Exit Sub
            End If
            Dim oIU2 As New smt_IndividualUserType2     '----------- For Individual User Type 2
            oIU2.LoadByUserID(GetUser.UserID)
            If Not IsNothing(oIU2) AndAlso oIU2.IndividualUserType2ID > 0 Then
                Me.phIndividualType2.Visible = True
                Me.pI2.Visible = True
                Me.hlI2HomePage.NavigateUrl = UIHelper.GetBasePath & "/Members/" & currentUser.Username & ".aspx"
                Dim oSV As New smt_StarShipVoyager()
                Dim Arl As New ArrayList
                Arl = oSV.StarShipVoyagerGetByEmployeeUserID(GetUser.UserID)
                If Arl.Count > 0 Then
                    oSV = New smt_StarShipVoyager
                    oSV = Arl.Item(0)
                    If Not IsNothing(oSV) AndAlso oSV.FriendUserName.Trim.Length > 0 Then
                        Me.hlI2StarShipHomePage.NavigateUrl = UIHelper.GetUnionVerseBasePathURL() & "/Members/" & oSV.FriendUserName.Trim & ".aspx"
                    Else
                        Me.hlI2StarShipHomePage.NavigateUrl = UIHelper.GetUnionVerseBasePathURL() & "/Connections/StarShipSearch.aspx"
                    End If
                Else
                    Me.hlI2StarShipHomePage.NavigateUrl = UIHelper.GetUnionVerseBasePathURL() & "/Connections/StarShipSearch.aspx"
                End If
                Me.hlI2SolarSystem.NavigateUrl = UIHelper.GetUnionVerseBasePathURL() & "/Connections/SolarSystemSearch.aspx"
                Me.divPicture.Visible = True
                Exit Sub
            End If
            Dim oBU As New smt_BusinessType             '----------- For Business User
            oBU.LoadByUserID(GetUser.UserID)
            If Not IsNothing(oBU) AndAlso oBU.BusinessTypeID > 0 Then
                Me.phBusinessType.Visible = True
                Me.pG2.Visible = True
                Me.hlG2HomePage.NavigateUrl = UIHelper.GetBasePath & "/Members/" & currentUser.Username & ".aspx"
                Me.divPicture.Visible = True
                Exit Sub
            End If
            Dim oSU As New smt_School                   '----------- For Moon User (schools and etc)
            oSU.LoadByUserID(GetUser.UserID)
            If Not IsNothing(oSU) AndAlso oSU.SchoolID > 0 Then
                Me.phGroupType3Moon.Visible = True
                Me.pG3.Visible = True
                Me.hlG3MyHomePage.NavigateUrl = UIHelper.GetBasePath & "/Members/" & currentUser.Username & ".aspx"
                Me.hlG3StarShipHomePage.NavigateUrl = UIHelper.GetUnionVerseBasePathURL() & "/StarShipSearch.aspx"
                Me.divPicture.Visible = True
                Exit Sub
            End If
            Dim oG4 As New smt_GroupType4               '----------- For Group Type 4 (WhiteWholes.com)
            oG4.ConnectionString = ConfigurationManager.AppSettings("connectionString")
            oG4.LoadByUserID(GetUser.UserID)
            If Not IsNothing(oG4) AndAlso oG4.GroupType4ID > 0 Then
                Me.phWhiteWhole.Visible = True
                Me.pG4.Visible = True
                Me.aMorePictures.HRef = UIHelper.GetWhiteWholesPathURL & "/Members/" & currentUser.Username & ".aspx#Pictures"
                Me.hlG4MyHomePage.NavigateUrl = UIHelper.GetWhiteWholesPathURL() & "/Members/" & currentUser.Username & ".aspx"
                Me.hlG4StarShipHomePage.NavigateUrl = UIHelper.GetUnionVerseBasePathURL & "/StarShipSearch.aspx"
                Me.divPicture.Visible = False
                Exit Sub
            End If
        End If
    End Sub
    Public Sub LoadPicture()
        If GetUser.UserID > 0 Then
            Dim _u1 As New Users
            _u1 = GetUser()
            If _u1.ProfileImage.Trim.Length > 0 Then
                imgProfile.Src = UIHelper.GetUnionVerseBasePathURL & "/" & _u1.ProfileImage.Trim
            Else
                ' imgProfile.Src = UIHelper.GetUnionVerseBasePathURL & "/UserFiles/Profiles/Default_Pic_icon.png"
                imgProfile.Src = UIHelper.GetDefaultPicture(_u1.RoleID)
            End If

        End If
    End Sub
End Class
