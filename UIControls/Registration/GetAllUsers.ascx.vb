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
Partial Class UIControls_Registration_GetAllUsers
    Inherits System.Web.UI.UserControl
    Public Property UserID() As Integer
        Get
            If Not IsNothing(ViewState("UserID")) AndAlso IsNumeric(ViewState("UserID")) Then
                Return CInt(ViewState("UserID"))
            Else
                If Not IsNothing(Session("Users")) AndAlso CType(Session("Users"), Users).UserID Then
                    Return CType(Session("Users"), Users).UserID
                Else
                    Return 0
                End If
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("UserID") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If UserID > 0 Then
            If Not IsPostBack Then
                LoadUserOptions()

            End If
        Else
            Response.Redirect(UIHelper.GetBasePath() & "/Login.aspx")
        End If
    End Sub

    Protected Sub GetListing(ByVal id As Integer)
        rptUsers.DataSource = UserData.GetAllUserByType(id)
        rptUsers.DataBind()
    End Sub


    Protected Sub GetListing1(ByVal id As Integer)
        rptUsers.DataSource = UserData.GetAllUserForRS(id, UserID)
        rptUsers.DataBind()
    End Sub

    Protected Sub rptUsers_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptUsers.ItemCommand
        If e.CommandName = "status" Then
            Dim lbt As LinkButton = e.Item.FindControl("lbtChangeStatus")
            Dim status As Boolean = Convert.ToBoolean(lbt.ToolTip)
            Dim id As Integer = Convert.ToInt32(e.CommandArgument)
            Dim user As New Users()
            status = IIf(status = True, False, True)
            user.UpdateuserStatus(id, status)
            Dim cui As New Users(UserID)
            If Not IsNothing(cui) AndAlso cui.UserID > 0 Then
                If cui.UserTypeID = 1 Then
                    GetListing(ddlUserType1.SelectedValue)
                Else
                    GetListing(ddlUserType.SelectedValue)
                End If
            End If
            Me.lblInfo.Text = "Information updated sucessfully!!!"
        End If
    End Sub

    Protected Sub ddlUserType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlUserType.SelectedIndexChanged
        GetListing(ddlUserType.SelectedValue)
    End Sub

    Protected Sub ddlUserType1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlUserType1.SelectedIndexChanged
        GetListing(ddlUserType1.SelectedValue)
    End Sub



    Protected Sub LoadUserOptions()
        Dim cui As New Users(UserID)
        If Not IsNothing(cui) AndAlso cui.UserID > 0 Then
            If cui.UserTypeID = 1 Then
                Me.trAdmin.Visible = False
                Me.trType.Visible = True
                GetListing1(2)
            Else
                Me.trAdmin.Visible = True
                Me.trType.Visible = False
                GetListing(1)
            End If
        End If

    End Sub
End Class
