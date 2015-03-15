Imports UserLibrary

Partial Class UIControls_Album_ViewAlbum
    Inherits System.Web.UI.UserControl
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
        If UserID > 0 Then
            If Not IsPostBack Then
                LoadData()
            End If
        Else
            Response.Redirect(UIHelper.GetBasePath() & "/Login.aspx")
        End If

    End Sub

    Public Sub LoadData()
        Dim objAlbum As New Album
        Me.grdViewAlbum.DataSource = objAlbum.GetAllAlbums()
        Me.grdViewAlbum.DataBind()
    End Sub


    Public Function GetImage(ByVal imagepath As String) As String
        Return UIHelper.GetBasePath & "/" & imagepath
    End Function

    Protected Sub grdViewAlbum_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles grdViewAlbum.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim objAlbum As Album = e.Item.DataItem
            Dim objuser As New Users(UserID)
            Dim lbt As LinkButton = e.Item.FindControl("lbtEdit")
            If objAlbum.UserID = UserID Then
                lbt.Visible = True
                lbt.PostBackUrl = UIHelper.GetBasePath() & "/members/" & objuser.Username & "/addeditalbum.aspx?albumid=" & objAlbum.AlbumID
            Else
                lbt.Visible = False
            End If

        End If

    End Sub
End Class
