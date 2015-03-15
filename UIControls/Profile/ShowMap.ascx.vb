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

Partial Class UIControls_Profile_ShowMap
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
    Public Property MapLocation() As String
        Get
            If Not IsNothing(ViewState("MapLocation")) AndAlso CStr(ViewState("MapLocation")).Trim.Length > 0 Then
                Return CStr(ViewState("MapLocation"))
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            ViewState("MapLocation") = value
        End Set
    End Property

    Public Sub LoadData()
        Dim oU As New Users(UserID)

        If oU.UserTypeID = CommonLibrary.Utility.eUserTypes.WhiteWholes Then
            Dim oGT4 As New smt_GroupType4
            oGT4.LoadByUserID(oU.UserID)
            MapLocation = oGT4.Address1 & ", " & oGT4.State & ", " & oGT4.ZipCode
            Me.location.Value = MapLocation
        ElseIf oU.UserTypeID = CommonLibrary.Utility.eUserTypes.BusinessUser Then
            Dim oB As New smt_BusinessType
            oB.LoadByUserID(oU.UserID)
            If Not IsNothing(oB) Then
                MapLocation = (oB.Address1 & " " & oB.Address2 & ", " & oB.City & ", " & oB.State & ", " & oB.ZipCode).Replace("  ", " ").Trim
                Me.location.Value = MapLocation
            End If
        ElseIf oU.UserTypeID = CommonLibrary.Utility.eUserTypes.IndividualType1 Then
            Dim oI1 As New smt_IndividualUserType1
            oI1.LoadByUserID(oU.UserID)
            If Not IsNothing(oI1) Then
                MapLocation = (oI1.Address1 & " " & oI1.Address2 & ", " & oI1.City & ", " & oI1.State & ", " & oI1.ZipCode).Replace("  ", " ").Trim
                Me.location.Value = MapLocation
            End If
        ElseIf oU.UserTypeID = CommonLibrary.Utility.eUserTypes.IndividualType2 Then
            Dim oI2 As New smt_IndividualUserType2
            oI2.LoadByUserID(oU.UserID)
            If Not IsNothing(oI2) Then
                MapLocation = (oI2.Address1 & " " & oI2.Address2 & ", " & oI2.City & ", " & oI2.State & ", " & oI2.ZipCode).Replace("  ", " ").Trim
                Me.location.Value = MapLocation
            End If
        ElseIf oU.UserTypeID = CommonLibrary.Utility.eUserTypes.UserType1 Then
            Dim oUT1 As New smt_UserType1
            oUT1.LoadByUserID(oU.UserID)
            If Not IsNothing(oUT1) Then
                MapLocation = (oUT1.Address1 & " " & oUT1.Address2 & ", " & oUT1.City & ", " & oUT1.State & ", " & oUT1.ZipCode).Replace("  ", " ").Trim
                Me.location.Value = MapLocation
            End If
        ElseIf oU.UserTypeID = CommonLibrary.Utility.eUserTypes.SchoolType Then
            Dim oS As New smt_School
            oS.LoadByUserID(oU.UserID)
            If Not IsNothing(oS) Then
                MapLocation = (oS.Address1 & " " & oS.Address2 & ", " & oS.City & ", " & oS.State & ", " & oS.ZipCode).Replace("  ", " ").Trim
                Me.location.Value = MapLocation
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadData()
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Page.ClientScript.RegisterStartupScript(GetType(Page), "onload", "<script language='javascript'>load();CallShowAddress();</script>", False)
    End Sub

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

End Class
