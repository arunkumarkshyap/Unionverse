Imports CommonLibrary
Imports UserLibrary
Partial Class UIControls_Poll_PollList
    Inherits System.Web.UI.UserControl
    Public Event LoadPollData(ByVal PollID As Integer)

    Public ReadOnly Property CurrentUser As Users
        Get
            If Not IsNothing(Session("Users")) Then
                Return CType(Session("Users"), Users)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Property UnionversealPoll As Integer 
        Get
            If Not IsNothing(ViewState("UnionversealPoll")) AndAlso IsNumeric(ViewState("UnionversealPoll")) Then
                Return CInt(ViewState("UnionversealPoll"))
            Else
                Return -1
            End If
        End Get
        Set(value As Integer)
            ViewState("UnionversealPoll") = value
        End Set
    End Property
    Public Property PorfitSpendingPolls As Integer 
        Get
            If Not IsNothing(ViewState("PorfitSpendingPolls")) AndAlso IsNumeric(ViewState("PorfitSpendingPolls")) Then
                Return CInt(ViewState("PorfitSpendingPolls"))
            Else
                Return -1
            End If
        End Get
        Set(value As Integer)
            ViewState("PorfitSpendingPolls") = value
        End Set
    End Property
    Public Property ParentCategoryID As Integer
        Get
            If Not IsNothing(ViewState("ParentCategoryID")) AndAlso IsNumeric(ViewState("ParentCategoryID")) Then
                Return CInt(ViewState("ParentCategoryID"))
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            ViewState("ParentCategoryID") = value
        End Set
    End Property
    Public Property CategoryID As Integer
        Get
            If Not IsNothing(ViewState("CategoryID")) AndAlso IsNumeric(ViewState("CategoryID")) Then
                Return CInt(ViewState("CategoryID"))
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            ViewState("CategoryID") = value
        End Set
    End Property
    Public Sub BindGird()
        Dim oPoll As New Polls
        Dim Arl As New ArrayList
        Arl = oPoll.GetByFillter(0, CurrentUser.UserID, "", "", 0, UnionversealPoll, PorfitSpendingPolls, 0, 0, ParentCategoryID, 0, "", CategoryID)
        If Arl.Count > 0 Then
            Me.rpPolls.DataSource = Arl
            Me.rpPolls.DataBind()
            Me.rpPolls.Visible = True
        Else
            Me.rpPolls.DataSource = New ArrayList
            Me.rpPolls.DataBind()
            Me.rpPolls.Visible = False
        End If
    End Sub

    Protected Sub rpPolls_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rpPolls.ItemCommand
        If e.CommandName.ToString.Trim.ToUpper = "DELETE" Then
            Dim oPoll As New Polls()
            oPoll.Delete(CInt(e.CommandArgument))
            BindGird()
        ElseIf e.CommandName.ToString.Trim.ToLower = "edit" Then
            RaiseEvent LoadPollData(CInt(e.CommandArgument))
        End If
    End Sub

    Protected Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        RaiseEvent LoadPollData(0)
    End Sub
End Class
