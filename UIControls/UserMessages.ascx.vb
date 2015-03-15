Imports CommonLibrary
Imports UserLibrary

Partial Class UIControls_UserMessages
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
    Public Property MessageType As eMessageType
        Get
            If Not IsNothing(ViewState("MessageType")) AndAlso IsNumeric(ViewState("MessageType")) Then
                Return CType(ViewState("MessageType"), eMessageType)
            Else
                Return eMessageType.Inbox
            End If
        End Get
        Set(value As eMessageType)
            ViewState("MessageType") = value
        End Set
    End Property
    Enum eMessageType
        Inbox = 1
        Outbox = 2
    End Enum
    Public Sub LoadData()
        Dim objMessage As New IMessages
        Dim Arl As New ArrayList

        If MessageType = eMessageType.Inbox Then
            Arl = objMessage.GetActiveByRecipientUserID(UserID)
            Me.trInbox.Attributes("class") = "TabControlSelected"
            Me.trOutbox.Attributes("class") = "TabControl"
        Else
            Arl = objMessage.GetActiveBySenderUserID(UserID)
            Me.trInbox.Attributes("class") = "TabControl"
            Me.trOutbox.Attributes("class") = "TabControlSelected"
        End If
        If Not IsNothing(Arl) AndAlso Arl.Count > 0 Then
            Me.rpMessages.DataSource = Arl
            Me.rpMessages.DataBind()
        Else
            Me.rpMessages.DataSource = New ArrayList
            Me.rpMessages.DataBind()
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            MessageType = eMessageType.Inbox
            LoadData()
        End If
    End Sub

    Protected Sub lbtInbox_Click(sender As Object, e As EventArgs) Handles lbtInbox.Click
        MessageType = eMessageType.Inbox
        LoadData()
    End Sub

    Protected Sub lbtOutbox_Click(sender As Object, e As EventArgs) Handles lbtOutbox.Click
        MessageType = eMessageType.Outbox
        LoadData()
    End Sub
    Public Function IsVisible() As String
        If MessageType = eMessageType.Outbox Then
            Return False
        Else
            Return True
        End If
    End Function

End Class
