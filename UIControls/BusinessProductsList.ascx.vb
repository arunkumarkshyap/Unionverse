Imports CommonLibrary
Imports UserLibrary
Partial Class UIControls_BusinessProductsList
    Inherits System.Web.UI.UserControl
    Public Event LoadBusinessProduct(ByVal BusinessProductID As Integer)
    Public ReadOnly Property UserID() As Integer
        Get
            If Not IsNothing(Request.Item("uid")) AndAlso IsNumeric(Request.Item("uid")) Then
                Return CInt(Request.Item("uid"))
            Else
                Return 0
            End If
        End Get
    End Property
    Public ReadOnly Property CurrentUserID As Integer
        Get
            If Not IsNothing(Session("Users")) Then
                Return CType(Session("Users"), Users).UserID
            Else
                Return 0
            End If
        End Get
    End Property
    Public Property BusinessProductID As Integer
        Get
            If Not IsNothing(ViewState("BusinessProductID")) AndAlso IsNumeric(ViewState("BusinessProductID")) Then
                Return CInt(ViewState("BusinessProductID"))
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            ViewState("BusinessProductID") = value
        End Set
    End Property
    Public Sub BindGrid()
        Dim oBP As New BusinessProducts
        Dim Arl As New ArrayList
        Arl = oBP.GetByFillter(0, UserID)
        If Arl.Count > 0 Then
            Me.rpProductList.DataSource = Arl
            Me.rpProductList.DataBind()
        Else
            Me.rpProductList.DataSource = New ArrayList
            Me.rpProductList.DataBind()
        End If
    End Sub
    Public Function GetProductImage(ByVal ImageURL As String) As String
        If ImageURL.Trim.Length > 0 Then
            Return UIHelper.GetUnionVerseBasePathURL & "/" & ImageURL
        Else
            Return ""
        End If
    End Function

    Protected Sub rpProductList_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rpProductList.ItemCommand
        If e.CommandName = "EDIT" Then
            RaiseEvent LoadBusinessProduct(CInt(e.CommandArgument))
        ElseIf e.CommandName = "DELETE" Then
            Dim oBP As New BusinessProducts()
            oBP.Delete(CInt(e.CommandArgument))
            BindGrid()
        End If
    End Sub

    Protected Sub lbtAddNew_Click(sender As Object, e As EventArgs) Handles lbtAddNew.Click
        RaiseEvent LoadBusinessProduct(0)
    End Sub
End Class
