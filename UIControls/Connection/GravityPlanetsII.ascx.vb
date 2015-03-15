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

Partial Class CMSWebParts_Membership_GravityPlanetsII
    Inherits System.Web.UI.UserControl
    Public ReadOnly Property UserName() As String
        Get
            If Not IsNothing(Request.Item("UserName")) Then
                Return Request.Item("UserName")
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
    Public Sub LoadData()
        Dim Arl As New ArrayList
        Dim oI2 As New Users

        Arl = oI2.IndividualUserType2AgentTypesGravity(GetUser().UserID)
        If Arl.Count > 0 Then
            Me.rpAgentType.DataSource = Arl
            Me.rpAgentType.DataBind()
        Else
            Me.rpAgentType.DataSource = New ArrayList
            Me.rpAgentType.DataBind()
        End If

        aModerator.HRef = UIHelper.GetUnionVerseBasePathURL & "/Members/" & GetUser().Username & "/Chat.aspx?FriendGUID=" & GetUser().UserGUID.ToString
        If Not IsNothing(UIHelper.GetSiteConfigrationValue("AdminUserID")) AndAlso IsNumeric(UIHelper.GetSiteConfigrationValue("AdminUserID")) Then
            Dim oU As New Users(CInt(UIHelper.GetSiteConfigrationValue("AdminUserID")))
            If Not IsNothing(oU) AndAlso oU.UserID > 0 Then
                aUnionverse.HRef = UIHelper.GetUnionVerseBasePathURL & "/Members/" & oU.Username & "/Chat.aspx?FriendGUID=" & oU.UserGUID.ToString
            Else
                aUnionverse.HRef = "#"
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not UIHelper.IsSolarSystem(GetUser().UserID) Then
                Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/Forbidden.aspx")
            End If
            If UIHelper.IsSolarSystem(GetUser().UserID) Then
                LoadData()
                Exit Sub
            End If
            Dim oG1 As New smt_UserType1()
            oG1.LoadByUserID(GetUser().UserID)
            If IsNothing(oG1) OrElse oG1.UserType1ID <= 0 Then
                Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/Forbidden.aspx")
            End If
            LoadData()
        End If
    End Sub
End Class
