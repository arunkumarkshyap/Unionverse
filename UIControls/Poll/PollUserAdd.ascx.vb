Imports UserLibrary
Imports CommonLibrary
Partial Class UIControls_PollUserAdd
    Inherits System.Web.UI.UserControl
    Public Event DataSaved()
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
            Me.rblQuestion.DataSource = Arl
            Me.rblQuestion.DataTextField = "OptionText"
            Me.rblQuestion.DataValueField = "PollOptionID"
            Me.rblQuestion.DataBind()

            If oPoll.HaveUserPolled(PollID, CurrentUserID) Then
                Me.btnSave.Enabled = False
            Else
                Me.btnSave.Enabled = True
            End If
        End If
    End Sub

    Public Function IsValidate() As Boolean
        Me.lblError.Text = ""
        Dim Arl As New ArrayList
        Dim oUP As New UserPollOptions
        Arl = oUP.GetByFillter(0, PollID, CurrentUserID)
        If Arl.Count > 0 Then
            Return False
        End If
        If Me.rblQuestion.SelectedIndex < 0 Then
            Me.lblError.Text = "Plesae select an option"
            Return False
        End If

        Return True
    End Function

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If IsValidate() Then
            If rblQuestion.SelectedValue > 0 Then
                Dim oUPO As New UserPollOptions
                oUPO.UserID = CurrentUserID
                oUPO.PollID = PollID
                oUPO.PollOptionID = CInt(rblQuestion.SelectedValue)
                oUPO.OptionText = ""
                oUPO.save()
                Dim oPollOptions As New PollOptions 
                oPollOptions.PollOptionUpdateResponseCount(oUPO.PollOptionID)
                loadData()
            End If
            RaiseEvent DataSaved()
        End If
    End Sub
End Class
