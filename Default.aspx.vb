Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports UserLibrary
Imports CommonLibrary

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsNothing(Session("Users")) Then
            Dim oU As New Users(CType(Session("Users"), Users).UserID)
            If Not IsNothing(oU) Then
                If oU.RoleID = CommonLibrary.Utility.eUserRole.Administrator Then
                    Response.Redirect(UIHelper.GetBasePath & "/Admin/AdminDashBoard.aspx")
                ElseIf oU.UserTypeID = 0 Then
                    Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/Registration-Type.aspx")
                Else
                    Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/Members/" & oU.Username & ".aspx")
                End If
            End If
        Else
            Response.Redirect(UIHelper.GetBasePath() & "/Login.aspx")
        End If
    End Sub
End Class
