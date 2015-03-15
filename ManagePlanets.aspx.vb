Imports UserLibrary
Imports CommonLibrary

Partial Class _ManagePlanets
    Inherits System.Web.UI.Page
    Public ReadOnly Property PlanetID As Integer
        Get
            If Not IsNothing(Request.Item("PlanetID")) AndAlso IsNumeric(Request.Item("PlanetID")) Then
                Return CInt(Request.Item("PlanetID"))
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

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If PlanetID > 0 Then
                Dim oPlanets As New smt_UserType1Planet(PlanetID)

                If Not IsNothing(oPlanets) AndAlso oPlanets.UserType1PlanetID > 0 Then
                    If oPlanets.IsApproved Then
                        Me.lblError.Text = "Already approved."
                        Me.btnAccept.Visible = False
                        Me.btnReject.Visible = False
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
        Dim oPlanets As New smt_UserType1Planet(PlanetID)

        If Not IsNothing(oPlanets) Then
            oPlanets.IsApproved = True
            oPlanets.save()

            Dim oInd2 As New Users(CurrentUser.UserID)
            Dim oInd1 As New Users(oPlanets.FriendID)
            Dim oM As New IMessages()
            oM.SenderUserID = oInd2.UserID
            oM.SenderNickName = oInd2.Username
            oM.RecipientUserID = oInd1.UserID
            oM.RecipientNickName = oInd1.Username
            oM.DateSent = DateTime.Now
            oM.LastModified = oM.DateSent
            oM.Subject = oInd2.Username + " Approved your planet request. "
            oM.Body = "<p>You are now planet of " & oInd2.Username & " <br /></p>"
            oM.save()
            Me.lblError.Text = "Request Approved."
            Me.btnAccept.Visible = False
            Me.btnReject.Visible = False
        End If
    End Sub

    Protected Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        Dim oPlanets As New smt_UserType1Planet(PlanetID)

        If Not IsNothing(oPlanets) Then
            oPlanets.IsApproved = False
            oPlanets.save()

            Dim oInd2 As New Users(CurrentUser.UserID)
            Dim oInd1 As New Users(oPlanets.FriendID)
            Dim oM As New IMessages()
            oM.SenderUserID = oInd2.UserID
            oM.SenderNickName = oInd2.Username
            oM.RecipientUserID = oInd1.UserID
            oM.RecipientNickName = oInd1.Username
            oM.DateSent = DateTime.Now
            oM.LastModified = oM.DateSent
            oM.Subject = oInd2.Username + " Rejected your planet request. "
            oM.Body = "<p>Planet request has been rejected by " & oInd2.Username & " <br /></p>"
            oM.save()
            Me.lblError.Text = "Request Rejected."
            Me.btnAccept.Visible = False
            Me.btnReject.Visible = False
        End If
    End Sub
End Class
