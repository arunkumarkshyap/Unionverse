
Partial Class _Message
    Inherits System.Web.UI.Page
    Public ReadOnly Property MessageID As Integer
        Get
            If Not IsNothing(Request.Item("mid")) AndAlso IsNumeric(Request.Item("mid")) Then
                Return CInt(Request.Item("mid"))
            Else
                Return 0
            End If
        End Get
    End Property
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            MessageView1.MessageID = MessageID
            MessageView1.LoadData()
        End If
    End Sub
End Class
