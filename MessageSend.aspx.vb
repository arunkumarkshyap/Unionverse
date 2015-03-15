
Partial Class _MessageSend
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
    Public ReadOnly Property SenderUserID As Integer
        Get
            If Not IsNothing(Request.Item("suid")) AndAlso IsNumeric(Request.Item("suid")) Then
                Return CInt(Request.Item("suid"))
            Else
                Return 0
            End If
        End Get
    End Property
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            SendMessage1.MessageID = MessageID
            SendMessage1.SendToUserID = SenderUserID
            SendMessage1.LoadData()
        End If
    End Sub
End Class
