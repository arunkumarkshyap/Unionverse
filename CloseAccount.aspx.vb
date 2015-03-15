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

Partial Class CloseAccount
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Request.QueryString("op") Is Nothing And Not Request.QueryString("op") = "" Then
            Dim user As New Users()
            Dim Userid As Integer
            Userid = Convert.ToInt32(CommonLibrary.Utility.DecryptText(Convert.ToString(Request.QueryString("op"))))
            user.UpdateuserStatus(Userid, True)
            Me.lblInfo.Text = "Your Account has been terminated successfully. If you want to re-activate your account, Please contact to administrator."
        End If
    End Sub
End Class
