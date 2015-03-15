Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Partial Class Common_JpegImage
    Inherits System.Web.UI.Page
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Session("CaptchaImageText") = CStr(DateTime.Now.ToString("ssfff"))
            'Create a CAPTCHA image using the text stored in the Session object.

            Dim ci As CaptchaImage = New CaptchaImage(IIf(Not IsNothing(Session("CaptchaImageText")), Session("CaptchaImageText"), "0000"), 160, 50, "Century Schoolbook")
            ' Change the response headers to output a JPEG image.
            Me.Response.Clear()
            Me.Response.ContentType = "image/jpeg"
            ' Write the image to the response stream in JPEG format.
            ci.Image.Save(Me.Response.OutputStream, ImageFormat.Jpeg)
            ' Dispose of the CAPTCHA image object.
            ci.Dispose()
        Catch ex As Exception

        End Try

    End Sub
End Class
