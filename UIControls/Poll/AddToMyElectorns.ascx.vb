Imports UserLibrary
Partial Class UIControls_Poll_AddToMyElectorns
    Inherits System.Web.UI.UserControl
    Public ReadOnly Property CurrentUser As Users
        Get
            If Not IsNothing(Session("Users")) Then
                Return CType(Session("Users"), Users)
            Else
                Return New Users
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
    Public Sub LoadData()
        Me.lbtAddAdMyElectron.Visible = False
        Me.lbtRemove.Visible = False
        Me.divEditPoll.Visible = False
        If CurrentUser.UserID > 0 AndAlso PollID > 0 AndAlso CurrentUser.UserTypeID = CommonLibrary.Utility.eUserTypes.UserType1 Then
            Dim oPoll As New CommonLibrary.Polls(PollID)
            If Not IsNothing(oPoll) AndAlso oPoll.ByUserID <> CurrentUser.UserID Then
                Dim oSP As New CommonLibrary.SolarSystemPolls(CurrentUser.UserID, PollID)
                If Not IsNothing(oSP) AndAlso oSP.SolarSystemPollID > 0 Then
                    Me.lbtAddAdMyElectron.Visible = False
                    Me.lbtRemove.Visible = True
                    Me.divEditPoll.Visible = True
                Else
                    Me.lbtAddAdMyElectron.Visible = True
                    Me.lbtRemove.Visible = False
                    Me.divEditPoll.Visible = True
                End If
            End If
        End If
    End Sub

    Protected Sub lbtAddAdMyElectron_Click(sender As Object, e As EventArgs) Handles lbtAddAdMyElectron.Click
        If PollID > 0 AndAlso CurrentUser.UserID > 0 Then
            Dim oSP As New CommonLibrary.SolarSystemPolls
            oSP.SolarSystemPollsDeleteByUserIDPollID(CurrentUser.UserID, PollID)
            LoadData()
        End If
    End Sub

    Protected Sub lbtRemove_Click(sender As Object, e As EventArgs) Handles lbtRemove.Click
        If PollID > 0 AndAlso CurrentUser.UserID > 0 Then
            Dim oSP As New CommonLibrary.SolarSystemPolls
            oSP.SolarSystemPollsDeleteByUserIDPollID(CurrentUser.UserID, PollID)
            oSP.UserID = CurrentUser.UserID
            oSP.PollID = PollID
            oSP.DateAdded = DateTime.Now
            oSP.save()
            LoadData()
        End If
    End Sub
End Class
