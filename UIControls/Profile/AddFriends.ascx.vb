Imports UserLibrary
Imports CommonLibrary
Partial Class UIControls_Profile_AddFriends
    Inherits System.Web.UI.UserControl

    Public ReadOnly Property UserID() As Integer
        Get
            If Not IsNothing(Request.Item("uid")) AndAlso IsNumeric(Request.Item("uid")) Then
                Return CInt(Request.Item("uid"))
            Else
                Return 0
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

    Protected Sub lbtAddFriend_Click(sender As Object, e As EventArgs) Handles lbtAddFriend.Click
        Dim objFriend As New Friends
        If Not objFriend.IsFriendOrPening(UserID, CurrentUser.UserID) Then
            objFriend.FriendRequestedUserID = CurrentUser.UserID
            objFriend.FriendUserID = UserID
            objFriend.FriendRequestedWhen = DateTime.Now
            objFriend.FriendGUID = Guid.NewGuid
            objFriend.FriendStatus = CommonLibrary.Utility.eFriendStatus.Pending
            objFriend.save()

            Dim oInd2 As New Users(CurrentUser.UserID)
            Dim oInd1 As New Users(UserID)
    	    Dim oM As New IMessages()
            oM.SenderUserID = oInd2.UserID
            oM.SenderNickName = oInd2.Username
            oM.RecipientUserID = oInd1.UserID
            oM.RecipientNickName = oInd1.Username
            oM.DateSent = DateTime.Now
            oM.LastModified = oM.DateSent
            oM.Subject = oInd2.Username + " wants to be Friend "
            oM.Body = oInd2.Username + " wants to be Friend " & vbLf & "<p>To Accpet or Reject the Connection request please follow.</p><p><b><a href='" & UIHelper.GetBasePath() & "/ManageFriends.aspx?FriendGUID=" & objFriend.FriendGUID.ToString() & "'>Accept / Reject</a></b><br /></p>"
            oM.save()
        End If
        LoadData()
    End Sub


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadData()
    End Sub
    Public Sub LoadData()
        If CurrentUser.UserID > 0 AndAlso UserID > 0 And CurrentUser.UserID <> UserID Then
            Me.spnFriend.Visible = True
            Dim objFriend As New Friends
            If objFriend.IsFriendOrPening(UserID, CurrentUser.UserID) Then
                Me.spnFriend.Visible = False
            Else
                Me.spnFriend.Visible = True
            End If
        Else
            Me.spnFriend.Visible = False
        End If
    End Sub
End Class
