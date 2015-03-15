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

Partial Class CMSModules_Membership_Controls_GroupType1EmployeesAdd
    Inherits System.Web.UI.UserControl
    Public Property GroupType1UserID() As Integer
        Get
            If Not IsNothing(ViewState("GroupType1UserID")) AndAlso IsNumeric(ViewState("GroupType1UserID")) Then
                Return CInt(ViewState("GroupType1UserID"))
            Else
                Return CType(Session("Users"), Users).UserID
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("GroupType1UserID") = value
        End Set
    End Property
    Public Property GroupType1ID() As Integer
        Get
            If Not IsNothing(ViewState("GroupType1ID")) AndAlso IsNumeric(ViewState("GroupType1ID")) Then
                Return CInt(ViewState("GroupType1ID"))
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("GroupType1ID") = value
        End Set
    End Property


    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim oU As New Users(GroupType1UserID)
        Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/Members/" & oU.Username.Replace(" ", " ") & ".aspx")
    End Sub
End Class
