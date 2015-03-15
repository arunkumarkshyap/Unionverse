Imports CommonLibrary
Imports UserLibrary
Partial Class UIControls_Poll_PollsSearch
    Inherits System.Web.UI.UserControl
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
        Arl = oPoll.GetByFillter(0, 0, ZipCode, City, State, IsUnionVersal, IsProfitSpending, 0, 0, ParentCategoryID, CountryID, Me.txtPollQuestion.Text.Trim)
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

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadGrid()
    End Sub
End Class
