Imports UserLibrary

Partial Class ViewAlbums
    Inherits System.Web.UI.Page
    Public ReadOnly Property UserID As Integer
        Get
            If Not IsNothing(Request.Item("uid")) AndAlso IsNumeric(Request.Item("uid")) Then
                Return CInt(Request.Item("uid"))
            Else
                Return 0
            End If
        End Get
    End Property
    Protected Sub lbtBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtBack.Click
        Dim oU As New Users(UserID)
        If Not oU Is Nothing And oU.UserID > 0 Then
            Response.Redirect("~/members/" & oU.Username & "/addeditalbum.aspx")
        End If
    End Sub
End Class
