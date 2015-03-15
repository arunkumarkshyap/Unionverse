Imports UserLibrary
Partial Class UIControls_UserImageListAdd
    Inherits System.Web.UI.UserControl
    Public Property UserID As Integer 
        Get
            If Not IsNothing(ViewState("UserID")) AndAlso ViewState("UserID") > 0 Then
                Return CInt(ViewState("UserID"))
            ElseIf Not IsNothing(Request.Item("uid")) AndAlso IsNumeric(Request.Item("uid")) Then
                Return CInt(Request.Item("uid"))
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            ViewState("UserID") = value
        End Set
    End Property
    Public ReadOnly Property CurrentUser As Users
        Get
            If Not IsNothing(Session("Users")) AndAlso CType(Session("Users"), Users).UserID > 0 Then
                Return CType(Session("Users"), Users)
            Else
                Return New Users
            End If
        End Get
    End Property

    Public Sub LoadData()

        Dim oUI As New UserImages
        Dim Arl As New ArrayList
        If UserID > 0 Then
            Arl = oUI.GetByUserID(UserID)
        Else
            Arl = New ArrayList
        End If
        If Arl.Count > 0 Then
            Me.rpUserImages.DataSource = Arl
            Me.rpUserImages.DataBind()


        End If
    End Sub

    Public Function GetImageName(ByVal _url As String) As String
        Dim str As String = ""
        If Not IsNothing(_url) AndAlso _url.Trim.Length > 0 Then
            str = UIHelper.GetUnionVerseBasePathURL & "/" & _url.Replace("UserImages", "UserImages/Thumbs")
        Else
            str = UIHelper.GetUnionVerseBasePathURL & "/UserFiles/Profiles/Profile-Pic-Man.png"
        End If
        Return str
    End Function
    Public Function GetImageLarge(ByVal _url As String) As String
        Dim str As String = ""
        If Not IsNothing(_url) AndAlso _url.Trim.Length > 0 Then
            str = UIHelper.GetWhiteWholesPathURL & "/" & _url.Trim
        Else
            str = UIHelper.GetUnionVerseBasePathURL & "/UserFiles/Profiles/Profile-Pic-Man.png"
        End If
        Return str
    End Function
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If CurrentUser.UserID = UserID Then
            Me.phImageAdd.Visible = True
        Else
            Me.phImageAdd.Visible = False
        End If
        If Not Page.IsPostBack Then
            LoadData()
        End If
    End Sub
    Protected Sub rpUserImages_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rpUserImages.ItemCommand
        If e.CommandName = "DELETE" Then
            If Not IsNothing(e.CommandArgument) AndAlso CInt(e.CommandArgument) > 0 Then
                Dim oUI As New UserImages
                oUI.Delete(CInt(e.CommandArgument))
                LoadData()
            End If
        End If
    End Sub

    Protected Sub rpUserImages_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rpUserImages.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
            If Not IsNothing(e.Item.FindControl("lbtdelete")) Then
                If CurrentUser.UserID = UserID Then
                    CType(e.Item.FindControl("lbtdelete"), LinkButton).Visible = True
                Else
                    CType(e.Item.FindControl("lbtdelete"), LinkButton).Visible = False
                End If
            End If
        End If
    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If IsValidate() Then
            SaveProfileImage()
        End If
    End Sub
    Public Function IsValidate() As Boolean
        If Me.fuImage.FileName.Trim.Length <= 0 Then
            Return False
        End If
        Return True
    End Function
    Public Sub SaveProfileImage()
        If Me.fuImage.FileName.Trim.Length > 0 Then
            Dim oUImage As New UserImages
            Dim str As String = ""
            Dim fPath As String = fuImage.PostedFile.FileName
            Dim filename As String = fPath.Substring(fPath.LastIndexOf("\") + 1)
            Dim Name As String = filename.Substring(0, filename.LastIndexOf("."))
            Dim type As String = filename.Substring(filename.LastIndexOf("."))
            Dim path As String = Server.MapPath(Request.ApplicationPath) & "/UserImages/"
            If Not (IO.Directory.Exists(path)) Then
                IO.Directory.CreateDirectory(path)
            End If
            path = Server.MapPath(Request.ApplicationPath) & "/UserImages/Thumbs/"
            If Not (IO.Directory.Exists(path)) Then
                IO.Directory.CreateDirectory(path)
            End If
            oUImage.ImageName = Name
            oUImage.DateAdded = DateTime.Now
            oUImage.UserID = CurrentUser.UserID
            oUImage.IsActive = True
            oUImage.save()
            'upAvatar.SaveAs(path & UserID & "_" & Name & "_img" & type)
            str = "UserImages/" & oUImage.UserImageID & "_" & Name & "_img" & type
            oUImage.ImageURL = str
            oUImage.save()
            fuImage.SaveAs(Server.MapPath(Request.ApplicationPath) & "/" & str)
            Dim filetype As String = fuImage.FileName.Substring(fuImage.FileName.IndexOf("."))
            Dim oUI As New UIHelper
            Dim thumbnail As System.Drawing.Bitmap = oUI.CreateThumbNailWhiteBack(New Drawing.Bitmap(fuImage.PostedFile.InputStream, False), 100, 100)
            thumbnail.Save(Server.MapPath(Request.ApplicationPath) & "/UserImages/Thumbs/" & oUImage.UserImageID & "_" & Name & "_img" & type)
           ' LoadData()
            Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/Members/" & CurrentUser.Username & ".aspx#Pictures")
        End If
    End Sub
End Class
