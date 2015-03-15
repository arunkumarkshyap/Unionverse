Imports CommonLibrary
Imports UserLibrary

Partial Class UIControls_PollView
    Inherits System.Web.UI.UserControl

    Public ReadOnly Property CurrentUserID As Integer
        Get
            If Not IsNothing(Session("Users")) Then
                Return CType(Session("Users"), Users).UserID
            Else
                Return 0
            End If
        End Get
    End Property
    Public Property PollID As Integer 
        Get
            If Not IsNothing(ViewState("PollID")) AndAlso IsNumeric(ViewState("PollID")) Then
                Return CInt(ViewState("PollID"))
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            ViewState("PollID") = value
        End Set
    End Property
    Public Sub loadData()
        If PollID > 0 Then
            Dim oPoll As New Polls(PollID)
            Me.hPollQuestion.InnerHtml = oPoll.PollQuestion
            Dim Arl As New ArrayList
            Dim oPO As New PollOptions
            Arl = oPO.GetByFillter(0, PollID)
            Me.rpQuestion.DataSource = Arl
            Me.rpQuestion.DataBind()
        End If
    End Sub
    Public Function GetWidth(ByVal _OptionResponse As Integer, ByVal PollResponse As Integer) As String
        Dim _r As Integer = 0
        If _OptionResponse <= 0 OrElse PollResponse <= 0 Then
            Return "0px; "
        Else
            Return CInt((500 / PollResponse) * _OptionResponse).ToString() & "px; "
        End If
    End Function
    Public Function GetPerecentage(ByVal TotalResponse As Double, PollOptionResponse As Double) As String
        If TotalResponse = 0 Then
            Return " 0 %"
        ElseIf PollOptionResponse = 0 Then
            Return " 0 %"
        Else
            Return " " & CInt((PollOptionResponse / TotalResponse) * 100).ToString & " %"
        End If
    End Function
End Class
