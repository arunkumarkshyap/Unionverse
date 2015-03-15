Imports UserLibrary
Imports CommonLibrary

Partial Class ManageFriends
    Inherits System.Web.UI.Page
    Public ReadOnly Property FriendGUID As String
        Get
            If Not IsNothing(Request.Item("FriendGUID")) Then
                Return Request.Item("FriendGUID")
            Else
                Return ""
            End If
        End Get
    End Property
    Public ReadOnly Property CurrentUser As Users
        Get
            If Not IsNothing(Session("Users")) AndAlso CType(Session("Users"), Users).UserID > 0 Then
                Return CType(Session("Users"), Users)
            Else
                Return New Users
            End If
        End Get
    End Property

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If FriendGUID > 0 Then
                Dim oFriend As New Friends()
                oFriend.LoadByFriendGUID(New Guid(FriendGUID))
                If Not IsNothing(oFriend) Then
                    If oFriend.FriendStatus = CommonLibrary.Utility.eFriendStatus.Approved Then
                        Me.lblError.Text = "Already approved."
                        Me.btnAccept.Visible = False
                        Me.btnReject.Visible = False
                    ElseIf oFriend.FriendStatus = CommonLibrary.Utility.eFriendStatus.Rejected Then
                        Me.lblError.Text = "Connection request rejected."
                        Me.btnAccept.Visible = False
                        Me.btnReject.Visible = False
                    ElseIf oFriend.FriendStatus = CommonLibrary.Utility.eFriendStatus.Pending Then
                        Me.btnAccept.Visible = True
                        Me.btnReject.Visible = True
                    End If
                Else
                    Me.lblError.Text = "URL contain invalid validation code."
                    Me.btnAccept.Visible = False
                    Me.btnReject.Visible = False
                End If
            Else
                Me.lblError.Text = "URL contain invalid validation code."
                Me.btnAccept.Visible = False
                Me.btnReject.Visible = False
            End If
        End If
    End Sub

    Protected Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        Dim objFriend As New Friends()
        objFriend.LoadByFriendGUID(New Guid(FriendGUID))
        If Not IsNothing(objFriend) Then
            objFriend.FriendApprovedBy = CurrentUser.UserID
            objFriend.FriendApprovedWhen = DateTime.Now
            objFriend.FriendStatus = CommonLibrary.Utility.eFriendStatus.Approved
            objFriend.save()

            Dim oInd2 As New Users(CurrentUser.UserID)
            Dim oInd1 As New Users(objFriend.FriendRequestedUserID)
            Dim oM As New IMessages()
            oM.SenderUserID = oInd2.UserID
            oM.SenderNickName = oInd2.Username
            oM.RecipientUserID = oInd1.UserID
            oM.RecipientNickName = oInd1.Username
            oM.DateSent = DateTime.Now
            oM.LastModified = oM.DateSent
            oM.Subject = oInd2.Username + " Approved your Friend request. "
            oM.Body = "<p>You are now Friend with " & oInd2.Username & " <br /></p>"
            oM.save()
            Me.lblError.Text = "Request Approved."
            Me.btnAccept.Visible = False
            Me.btnReject.Visible = False
        End If
    End Sub

    Protected Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        Dim objFriend As New Friends()
        objFriend.LoadByFriendGUID(New Guid(FriendGUID))
        If Not IsNothing(objFriend) Then
            objFriend.FriendApprovedBy = CurrentUser.UserID
            objFriend.FriendApprovedWhen = DateTime.Now
            objFriend.FriendStatus = CommonLibrary.Utility.eFriendStatus.Rejected
            objFriend.save()

            Dim oInd2 As New Users(CurrentUser.UserID)
            Dim oInd1 As New Users(objFriend.FriendRequestedUserID)
            Dim oM As New IMessages()
            oM.SenderUserID = oInd2.UserID
            oM.SenderNickName = oInd2.Username
            oM.RecipientUserID = oInd1.UserID
            oM.RecipientNickName = oInd1.Username
            oM.DateSent = DateTime.Now
            oM.LastModified = oM.DateSent
            oM.Subject = oInd2.Username + " Rejected your Friend request. "
            oM.Body = "<p>Friend request has been rejected by " & oInd2.Username & " <br /></p>"
            oM.save()
            Me.lblError.Text = "Request Rejected."
            Me.btnAccept.Visible = False
            Me.btnReject.Visible = False
        End If
    End Sub
End Class
