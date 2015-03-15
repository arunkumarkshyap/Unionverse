Imports UserLibrary

Partial Class UIControls_Album_AddPhotos
    Inherits System.Web.UI.UserControl

    Public Sub LoadData(ByVal Albumbid As Integer)
        Dim objImage As New UserImages
        grdViewAlbum.DataSource = objImage.GetImagesByAlbumId(Albumbid)
        grdViewAlbum.DataBind()

    End Sub
    Public Function GetImage(ByVal imagepath As String) As String
        Return UIHelper.GetBasePath & "/" & imagepath
    End Function

    Public Function GetIds() As String
        Return Me.hdnIds.Value

    End Function

    Public Function GetIndexes() As String
        Return Me.hdnIndexs.Value

    End Function


End Class
