Imports CMSLibrary
Partial Class ErrMsg
    Inherits System.Web.UI.UserControl
    Public Property MessageType() As Utility.eMessageType
        Get
            If Not IsNothing(ViewState("MsgType")) AndAlso IsNumeric(ViewState("MsgType")) Then
                Return ViewState("MsgType")
            Else
                Return Utility.eMessageType.Eerror
            End If
        End Get
        Set(ByVal value As Utility.eMessageType)
            ViewState("MsgType") = value
        End Set
    End Property
    Public Property Message() As String
        Get
            If Not IsNothing(ViewState("ErrMessage")) AndAlso ViewState("ErrMessage").ToString.Trim.Length > 0 Then
                Return CStr(ViewState("ErrMessage"))
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            ViewState("ErrMessage") = value
            LoadData()

        End Set
    End Property
    Public Sub LoadData()
        If Message.Trim.Length > 0 Then
            Me.Visible = True
            lblError.Text = Me.Message
        Else
            Me.Visible = False
            lblError.Text = ""
        End If
        Select Case Me.MessageType
            Case Utility.eMessageType.Eerror
                pErr.Attributes.Add("class", "err")
                lblhead.Text = "Error..."
                divtit.Attributes.Remove("class")
                divtit.Attributes.Add("class", "tit_err")
            Case Utility.eMessageType.Info
                pErr.Attributes.Add("class", "info")
                lblhead.Text = "Information!!!"
                divtit.Attributes.Add("class", "tit_info")
            Case Utility.eMessageType.Success
                pErr.Attributes.Add("class", "succ")
                lblhead.Text = "Successful!!!"
                divtit.Attributes.Add("class", "tit_succ")
            Case Else
                pErr.Attributes.Add("class", "err")
                lblhead.Text = "Error..."
                divtit.Attributes.Add("class", "tit_err")
        End Select
    End Sub
End Class
