Imports System.Web.Services
Imports System.Web.Script.Services
Imports AjaxControlToolkit
Imports UserLibrary

Partial Class ViewAlbumPhotos
    Inherits System.Web.UI.Page
    Public ReadOnly Property AlbumId As Integer
        Get
            If Not IsNothing(Request.Item("AlbumId")) AndAlso IsNumeric(Request.Item("AlbumId")) Then
                Return CInt(Request.Item("AlbumId"))
            Else
                Return 0
            End If
        End Get
    End Property
    Public ReadOnly Property UserID As Integer
        Get
            If Not IsNothing(Request.Item("uid")) AndAlso IsNumeric(Request.Item("uid")) Then
                Return CInt(Request.Item("uid"))
            Else
                Return 0
            End If
        End Get
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function GetSlides(ByVal contextKey As String) As Slide()
        Dim slides As New List(Of Slide)()
        Dim sPath As String = HttpContext.Current.Server.MapPath("~/images/")
        If sPath.EndsWith("\") Then
            sPath = sPath.Remove(sPath.Length - 1)
        End If

        Dim pathUri As New Uri(sPath, UriKind.Absolute)
        '//Dim files As String() = Directory.GetFiles(sPath)
        Dim objImages As New UserImages()
        Dim images As ArrayList = objImages.GetImagesByAlbumId(CInt(contextKey))
        For Each file As UserImages In images
            Dim path As String = UIHelper.GetBasePath & "/" & file.ImageURL
            slides.Add(New Slide() With { _
    .ImagePath = path _
  })
        Next
        Return slides.ToArray()
    End Function

    Protected Sub lbtBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtBack.Click
        Dim oU As New Users(UserID)
        If Not oU Is Nothing And oU.UserID > 0 Then
            Response.Redirect("~/members/" & oU.Username & "/viewalbums.aspx")
        End If
    End Sub

End Class
