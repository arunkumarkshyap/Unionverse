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
Imports System.IO

Partial Class UIControls_Album_AddEditAlbum
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
    Public ReadOnly Property AlbumId As Integer
        Get
            If Not IsNothing(Request.Item("albumid")) AndAlso IsNumeric(Request.Item("albumid")) Then
                Return CInt(Request.Item("albumid"))
            Else
                Return 0
            End If
        End Get
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadData()
        End If


    End Sub


    Public Function IsValidate() As Boolean
        Me.lblError.Text = ""
        Me.lblError.Visible = True
        If Me.txtTitle.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter Title of the Album."
            Return False
        End If
        If Me.txtDescription.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter description of the Album."
            Return False
        End If


        Me.lblError.Text = ""
        Me.lblError.Visible = False
        Return True

    End Function

    Protected Sub lbtSav1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtSav1.Click
        If IsValidate() Then
            SaveData()

        End If
    End Sub

    Public Sub SaveData()
        If UserID > 0 Then

            Dim objAlbum As New Album()
            If Not Request.QueryString("albumid") Is Nothing Then
                objAlbum.AlbumID = Convert.ToInt32(Request.QueryString("albumid"))
            Else
                objAlbum.AlbumID = 0
            End If
            objAlbum.AlbumName = Me.txtTitle.Text
            objAlbum.AccessTypeID = Convert.ToInt32(Me.ddlAcess.SelectedValue)
            objAlbum.AccessType = ddlAcess.SelectedItem.ToString()
            objAlbum.UserID = UserID
            objAlbum.DateCreated = DateTime.Now
            objAlbum.Description = Me.txtDescription.Text
            objAlbum.DateUpdate = DateTime.Now
            objAlbum.IsActive = True
            Dim id As Integer = objAlbum.Save()
            Dim i As Int16 = 0
            For i = 0 To Request.Files.Count - 1
                Dim status As Integer = 0
                Dim index As String = Me.AddPhotos.GetIndexes
                If Not index Is Nothing And index.Trim(",") <> "" Then
                    For Each imageid As String In index.Trim(",").Split(",")
                        If i = CInt(imageid) Then
                            status = 1
                        End If
                    Next
                End If

                If status = 0 Then
                    Dim objImages As New UserImages()
                    objImages.FolderID = id
                    objImages.FolderName = txtTitle.Text.Trim()
                    objImages.DateAdded = DateTime.Now
                    objImages.ImageGUID = Guid.NewGuid()
                    Dim objfile As HttpPostedFile = Request.Files(i)

                    Dim basepath As String = Server.MapPath(Request.ApplicationPath) & "images/album/"
                    If Not objfile Is Nothing And objfile.ContentLength > 0 Then
                        Dim filename As String = DateTime.Now.Ticks & "-" & objfile.FileName
                        Dim isExist As Boolean = System.IO.Directory.Exists(basepath)
                        If isExist = False Then
                            System.IO.Directory.CreateDirectory(basepath)
                        End If
                        objImages.ImageURL = "images/album/" & filename
                        objImages.ImageName = objfile.FileName
                        Dim path As String = String.Format("{0}{1}", basepath, filename)
                        objfile.SaveAs(path)
                        objImages.IsActive = True
                        objImages.save()
                    End If
                End If

            Next

            Dim ids As String = Me.AddPhotos.GetIds
            If Not ids Is Nothing And ids.Trim(",") <> "" Then
                For Each imageid As String In ids.Trim(",").Split(",")
                    Dim objImage As New UserImages(CInt(imageid))
                    If Not objImage Is Nothing Then
                        If File.Exists(Server.MapPath(Request.ApplicationPath) & objImage.ImageURL) Then
                            File.Delete(Server.MapPath(Request.ApplicationPath) & objImage.ImageURL)
                        End If
                        objImage.Delete(objImage.UserImageID)
                    End If
                Next

                Me.AddPhotos.LoadData(objAlbum.AlbumID)
            End If
            Me.lblInfo.Visible = True
            Me.lblInfo.Text = "Album added successfully."
            Return

        Else
            Response.Redirect(UIHelper.GetBasePath & "/login.aspx")
        End If


    End Sub
    Public Sub LoadData()

        If UserID > 0 Then
            Dim objAlbum As New Album(AlbumId)
            If Not objAlbum Is Nothing And objAlbum.AlbumID > 0 Then
                Me.txtTitle.Text = objAlbum.AlbumName
                Me.txtDescription.Text = objAlbum.Description
                Me.ddlAcess.SelectedValue = CStr(objAlbum.AccessTypeID)
                Me.AddPhotos.LoadData(AlbumId)
            Else
                Me.txtTitle.Text = Date.Now.ToShortDateString()
            End If

        End If
    End Sub


End Class
