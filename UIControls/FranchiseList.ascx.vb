Imports UserLibrary
Partial Class UIControls_FranchiseList
    Inherits System.Web.UI.UserControl
    Public Property UserID As Integer 
        Get
            If Not IsNothing(ViewState("UserID")) AndAlso IsNumeric(ViewState("UserID")) Then
                Return CInt(ViewState("UserID"))
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            ViewState("UserID") = value
        End Set
    End Property
    Public Sub LoadGrid()
        Dim oBU As New smt_BusinessType
        Dim Arl As New ArrayList
        Arl = oBU.GetByFillter("", 0, "", 0, "", "", 0, UserID)
        If Arl.Count > 0 Then
            Me.rpFranchise.DataSource = Arl
            Me.rpFranchise.DataBind()
            Me.rpFranchise.Visible = True
        Else
            Me.rpFranchise.DataSource = New ArrayList
            Me.rpFranchise.DataBind()
            Me.rpFranchise.Visible = False
        End If
    End Sub
    Public Function GetUserName(ByVal UID As Integer) As String
        Dim str As String = ""
        Dim oU As New Users(UID)
        If Not IsNothing(oU) AndAlso oU.UserID > 0 Then
            Return oU.Username.Trim
        Else
            Return ""
        End If
        Return str
    End Function
End Class
