Imports UserLibrary
Partial Class GroupType1
    Inherits System.Web.UI.Page
    Public ReadOnly Property UserID() As Integer
        Get
                If Not IsNothing(Session("Users")) AndAlso CType(Session("Users"), Users).UserID Then
                    Return CType(Session("Users"), Users).UserID
                Else
                    Return 0
                End If
        End Get
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If UserID <= 0 Then
                Response.Redirect(UIHelper.GetUnionVerseBasePathURL & "/Registration.aspx?ReturnURL=" + Request.RawUrl.ToLower())
            End If
            Me.UserType1Regis1.LoadData()
        End If
    End Sub
End Class
