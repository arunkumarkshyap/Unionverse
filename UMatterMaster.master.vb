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
Imports CommonLibrary
Partial Class MasterPage_UMatterMaster
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session("Users")) Then
            Dim oU As New Users(CType(Session("Users"), Users).UserID)
            If Not IsNothing(oU) Then
                Me.spnUNI.InnerHtml = "(" & oU.UserPoints & ")"

                Dim oMessage As New IMessages
                spnMessageCount.InnerHtml = "(" & oMessage.IMessageGetUserUnReadCount(oU.UserID) & ")"
            End If
        Else
            Response.Redirect(UIHelper.GetBasePath() & "/Login.aspx")
        End If
    End Sub

    Protected Sub lbtLogOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtLogOut.Click
        FormsAuthentication.SignOut()
        Session("Users") = Nothing

        '===================== Deleting Cookies Data===============
        Response.Cookies("UnionVERSEUserInfo")("userName") = ""
        Response.Cookies("UnionVERSEUserInfo")("lastVisit") = DateTime.Now.ToString
        Response.Cookies("UnionVERSEUserInfo").Expires = DateTime.Now.AddDays(-1)
        Dim aCookie As New HttpCookie("UnionVERSEUserInfo")
        aCookie.Values("userName") = ""
        aCookie.Values("lastVisit") = DateTime.Now.ToString
        aCookie.Expires = DateTime.Now.AddDays(-1)
        Response.Cookies.Add(aCookie)
        '===================== Deleting Cookies Data===============

        Response.Redirect(UIHelper.GetBasePath() & "/Login.aspx")

    End Sub
End Class

