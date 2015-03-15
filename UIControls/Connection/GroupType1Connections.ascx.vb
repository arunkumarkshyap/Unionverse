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

Partial Class CMSWebParts_Membership_GroupType1Connections
    Inherits System.Web.UI.UserControl

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
  
    Public Sub LoadData()
        Dim Ui As New Users

        If GetUser.UserID > 0 Then
            Ui = New Users(GetUser.UserID)

            Dim oUT1 As New smt_UserType1
            oUT1.LoadByUserID(Ui.UserID)
            If Not IsNothing(oUT1) AndAlso oUT1.UserType1ID > 0 Then

                '             Dim oUnionVerse As New smt_UnionverseUsers
                '             oUnionVerse.LoadByUserID(oUT1.UserID)


                Me.UserType1Planets1.UserType1ID = oUT1.UserType1ID
                Me.UserType1Planets1.IndividualType1or2 = 1
                Me.UserType1Planets1.LoadData()

                Me.UserType1Planets2.UserType1ID = oUT1.UserType1ID
                Me.UserType1Planets2.IndividualType1or2 = 2
                Me.UserType1Planets2.LoadData()


                Me.GravitationalPlanetsII1.UserID = oUT1.UserID
                Me.GravitationalPlanetsII1.LoadData()

            End If
        End If
    End Sub

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not IsNothing(GetUser()) AndAlso GetUser().UserID > 0 AndAlso UIHelper.IsSolarSystem(GetUser.UserID) Then
                LoadData()
                Me.phGRoupType.Visible = True
            Else
                Me.phGRoupType.Visible = False
            End If

        End If
    End Sub
End Class
