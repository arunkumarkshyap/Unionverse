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
Partial Class UIControls_Registration_TerminateAccount
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


    Protected Sub lbtTerminate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtTerminate.Click
        If UserID > 0 Then
            Dim cui As New Users(UserID)
            If Not IsNothing(cui) AndAlso cui.UserID > 0 Then
                EmailHelper.TerminateAccount(cui.UserID)
                'cui.UpdateuserStatus(cui.UserID, True)
                Me.lblInfo.Visible = True
                Me.lblInfo.Text = "An email has been sent to your registered email account for the confirmation to close your account."
            Else
                Response.Redirect(UIHelper.GetBasePath() & "/Login.aspx")
            End If
        Else
            Response.Redirect(UIHelper.GetBasePath() & "/Login.aspx")
        End If
    End Sub
End Class
