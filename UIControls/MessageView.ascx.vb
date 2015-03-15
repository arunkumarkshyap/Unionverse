Imports UserLibrary
Imports CommonLibrary
Partial Class UIControls_MessageView
    Inherits System.Web.UI.UserControl
    Public ReadOnly Property UserID As Integer
        Get
            If Not IsNothing(Session("Users")) AndAlso CType(Session("Users"), Users).UserID > 0 Then
                Return CType(Session("Users"), Users).UserID
            Else
                Return 0
            End If
        End Get
    End Property
    Public Property MessageID As Integer
        Get
            If Not IsNothing(ViewState("MessageID")) AndAlso IsNumeric(ViewState("MessageID")) Then
                Return CInt(ViewState("MessageID"))
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            ViewState("MessageID") = value
        End Set
    End Property
    Public Sub LoadData()
        Dim oMessage As New IMessages(MessageID)
        If Not IsNothing(oMessage) AndAlso oMessage.RecipientUserID = UserID Then
            Me.tFrom.InnerHtml = oMessage.SenderNickName
            Me.tSubject.InnerHtml = oMessage.Subject
            Me.tDate.InnerHtml = oMessage.DateSent.ToString
            Me.tBody.InnerHtml = Server.HtmlDecode(oMessage.Body)
            If Not oMessage.IsRead Then
                oMessage.IsRead = True
                oMessage.DateRead = DateTime.Now
                oMessage.save()
            End If
        End If
    End Sub

    Protected Sub lbtForward_Click(sender As Object, e As EventArgs) Handles lbtForward.Click
        Dim oMessage As New IMessages(MessageID)
        If Not IsNothing(oMessage) AndAlso oMessage.MessageID > 0 Then
            Response.Redirect(UIHelper.GetBasePath() & "/MessageSend.aspx?mid=" & oMessage.MessageID)
        End If
    End Sub

    Protected Sub lbtReply_Click(sender As Object, e As EventArgs) Handles lbtReply.Click
        Dim oMessage As New IMessages(MessageID)
        If Not IsNothing(oMessage) AndAlso oMessage.MessageID > 0 Then
            Response.Redirect(UIHelper.GetBasePath() & "/MessageSend.aspx?mid=" & oMessage.MessageID & "&suid=" & oMessage.SenderUserID)
        End If
    End Sub
End Class
