Imports System.Web.Services
Imports System.Web.Script.Services
Imports AjaxControlToolkit
Imports System.IO
Imports UserLibrary

Partial Class UIControls_Album_AlbumPhotoView
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        slideShowExtender1.ContextKey = Request.QueryString("albumid")

    End Sub
End Class
