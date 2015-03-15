Imports CommonLibrary
Imports UserLibrary
Partial Class UIControls_Poll_SearchPollResultsByFilter
    Inherits System.Web.UI.UserControl
    Public Event LoadPollData(ByVal PollID As Integer)
    Public Property UserID As Integer
        Get
            If Not IsNothing(ViewState("UserID")) AndAlso IsNumeric(ViewState("UserID")) Then
                Return ViewState("UserID")
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            ViewState("UserID") = value
        End Set
    End Property
    Public Property CurrentUser As Users
        Get
            If Not IsNothing(Session("Users")) Then
                Return CType(Session("Users"), Users)
            Else
                Return New Users
            End If
        End Get
        Set(value As Users)
            Session("Users") = value
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
    Public Property CountryID As Integer
        Get
            If Not IsNothing(ViewState("CountryID")) AndAlso IsNumeric(ViewState("CountryID")) Then
                Return CInt(ViewState("CountryID"))
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            ViewState("CountryID") = value
        End Set
    End Property
    Public Property ZipCode As String
        Get
            If Not IsNothing(ViewState("ZipCode")) Then
                Return CStr(ViewState("ZipCode"))
            Else
                Return ""
            End If
        End Get
        Set(value As String)
            ViewState("ZipCode") = value
        End Set
    End Property
    Public Property City As String
        Get
            If Not IsNothing(ViewState("City")) Then
                Return CStr(ViewState("City"))
            Else
                Return ""
            End If
        End Get
        Set(value As String)
            ViewState("City") = value
        End Set
    End Property
    Public Property State As Integer
        Get
            If Not IsNothing(ViewState("State")) AndAlso IsNumeric(ViewState("State")) Then
                Return CInt(ViewState("State"))
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            ViewState("State") = value
        End Set
    End Property
    Public Property IsUnionVersal() As Integer
        Get
            If Not IsNothing(ViewState("IsUnionVersal")) AndAlso IsNumeric(ViewState("IsUnionVersal")) Then
                Return CInt(ViewState("IsUnionVersal"))
            Else
                Return -1
            End If
        End Get
        Set(value As Integer)
            ViewState("IsUnionVersal") = value
        End Set
    End Property
    Public Property IsProfitSpending As Integer
        Get
            If Not IsNothing(ViewState("IsProfitSpending")) Then
                Return CInt(ViewState("IsProfitSpending"))
            Else
                Return -1
            End If
        End Get
        Set(value As Integer)
            ViewState("IsProfitSpending") = value
        End Set
    End Property
    Public Sub LoadGrid()
        
        Dim Arl As New ArrayList
        Dim oPoll As New Polls
        Arl = oPoll.GetByFillter(0, UserID, ZipCode, City, State, IsUnionVersal, IsProfitSpending, 0, 0, ParentCategoryID, CountryID, "", CategoryID)
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

    Protected Sub rpPolls_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rpPolls.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
            CType(e.Item.FindControl("PollView"), UIControls_PollViewOnly).loadData()
        End If
    End Sub
    Protected Sub rpPolls_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rpPolls.ItemCommand
        If e.CommandName.ToString.Trim.ToUpper = "DELETE" Then
            Dim oPoll As New Polls()
            oPoll.Delete(CInt(e.CommandArgument))
            LoadGrid()
        ElseIf e.CommandName.ToString.Trim.ToUpper = "EDIT" Then
            RaiseEvent LoadPollData(CInt(e.CommandArgument))
        End If
    End Sub
    Public Function ISEditAble(ByVal PollUserID As Integer) As Boolean
        If PollUserID = CurrentUser.UserID Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
