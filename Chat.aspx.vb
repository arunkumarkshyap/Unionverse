Imports UserLibrary

Partial Class _Chat
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
    Public ReadOnly Property FriendGUID As String
        Get
            If Not IsNothing(Request.Item("FriendGUID")) AndAlso Request.Item("FriendGUID").Trim.Length > 0 Then
                Return Request.Item("FriendGUID").Trim
            Else
                Return ""
            End If
        End Get
    End Property
    Public Sub LoadData()
        'Dim oU As New Users(UserID)
        ' Response.Write(oU.Username)
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If UserID > 0 Then
                LoadData()
            End If
        End If
    End Sub
End Class
