Imports CommonLibrary
Imports UserLibrary
Partial Class UIControls_SendMessage
    Inherits System.Web.UI.UserControl
    Public Event MessageSent()
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
    Public Property SendToUserID As Integer 
        Get
            If Not IsNothing(ViewState("SendToUserID")) AndAlso IsNumeric(ViewState("SendToUserID")) Then
                Return CInt(ViewState("SendToUserID"))
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            ViewState("SendToUserID") = value
        End Set
    End Property

    Public Sub LoadData()
        If MessageID > 0 Then
            Dim oMessage As New IMessages(MessageID)
            Dim oU As New Users(UserID)
            Me.lblFromUserName.Text = oU.Username

            If SendToUserID = oMessage.SenderUserID Then
                'reply
                Dim oU1 As New Users(SendToUserID)
                If Not IsNothing(oU1) AndAlso oU.UserID > 0 Then
                    Me.txtToUser.Text = oU1.Username
                End If
                Me.txtSubject.Text = "RE: " & oMessage.Subject
                Me.txtBody.Text = "" 'oMessage.Body
            Else
                'forward
                Me.txtSubject.Text = "FW: " & oMessage.Subject
                Me.txtBody.Text = "" 'oMessage.Body
            End If
        Else
            If SendToUserID > 0 Then
                Dim oU As New Users(SendToUserID)
                If Not IsNothing(oU) AndAlso oU.UserID > 0 Then
                    Me.lblFromUserName.Text = oU.Username
                End If
            End If
        End If

    End Sub

    Protected Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        If IsValidate() Then
            Dim oRecUser As New Users(Me.txtToUser.Text.Trim)
            Dim oMessage As New IMessages()
            oMessage.SenderUserID = UserID
            oMessage.SenderNickName = Me.lblFromUserName.Text
            oMessage.RecipientUserID = oRecUser.UserID
            oMessage.RecipientNickName = oRecUser.Username
            oMessage.DateSent = DateTime.Now()
            oMessage.Subject = Me.txtSubject.Text.Trim
            oMessage.Body = Server.HtmlEncode(Me.txtBody.Text.Trim)
            oMessage.save()
            RaiseEvent MessageSent()
        End If
    End Sub
    Public Function IsValidate() As Boolean
        lblError.Text = ""
        If UserID <= 0 Then
            lblError.Text = "Something goes wrong. please sure that you are loged in."
            Return False
        End If
        If Me.txtToUser.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Please enter/select To username."
            Return False
        Else
            Dim oU As New Users(Me.txtToUser.Text.Trim)
            If IsNothing(oU) Then
                Me.lblError.Text = "Invalid enter To Username."
                Return False
            End If
        End If
        If Me.txtSubject.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Please enter subject."
            Return False
        End If
        If Me.txtBody.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Please enter mail body."
            Return False
        End If
        Return True
    End Function
End Class
