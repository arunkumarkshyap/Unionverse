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
Partial Class UIControls_Profile_BasicProfile
    Inherits System.Web.UI.UserControl

    Public Property UserID() As Integer
        Get
            If Not IsNothing(ViewState("UserID")) AndAlso IsNumeric(ViewState("UserID")) Then
                Return CInt(ViewState("UserID"))
            Else
                If Not IsNothing(Session("Users")) Then
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
    Public Sub LoadData()
        Dim Ui As New Users(UserID)
        If Not IsNothing(Ui) Then
            'Dim oA As AvatarInfo = AvatarInfoProvider.GetAvatarInfo(Ui.UserAvatarID)
            'If Not IsNothing(oA) Then
            '    Me.UserImage.Src = SMTUIHelper.GetBasePathURL() & "/CMSModules/Avatars/CMSPages/GetAvatar.aspx?avatarguid=" & oA.AvatarGUID.ToString.Trim()
            'End If
            Me.lblUserName.InnerHtml = Ui.UserName.Trim
        End If
    End Sub

End Class
