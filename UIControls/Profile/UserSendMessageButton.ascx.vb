Imports System
Imports System.Web.UI
Imports System.Web.Security

Imports UserLibrary

Partial Class UIControls_Profile_UserSendMessageButton
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If UserID <> CurrentUser.UserID Then
                Dim siteContextUser As New Users(UserID)
                Dim script As String = ""
                script = " function ShortcutPrivateMessage(id) { " & vbLf & " modalDialog('" & "http://www.unionverse.com/CMSModules/Messaging/CMSPages/SendMessage.aspx" & "?userid=" & CurrentUser.UserID & "&requestid=' + id , 'sendMessage', 390, 390); " & vbLf & "  }  " & vbLf
                lbtSendFeedBack.Attributes.Add("onclick", "ShortcutPrivateMessage('" & siteContextUser.UserID & "');return false;")
                lbtSendFeedBack.NavigateUrl = Request.Url.AbsoluteUri
                '   ScriptHelper.RegisterClientScriptBlock(Me, GetType(String), "ModalDialog", ScriptHelper.GetScript(script))
                Me.phSendFeedBack.Visible = True
            Else
                Me.phSendFeedBack.Visible = False
            End If
        End If
    End Sub
    Public ReadOnly Property CurrentUser As Users
        Get
            If Not IsNothing(Session("Users")) Then
                Return CType(Session("Users"), Users)
            Else
                Return New Users
            End If
        End Get
    End Property
End Class
