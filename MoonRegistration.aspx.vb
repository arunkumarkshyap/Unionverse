Imports UserLibrary
Partial Class MoonRegistration
    Inherits System.Web.UI.Page
    Public Property UserID() As Integer
        Get
            If Not IsNothing(ViewState("UserID")) AndAlso IsNumeric(ViewState("UserID")) Then
                Return CInt(ViewState("UserID"))
            Else
                If Not IsNothing(Session("Users")) AndAlso CType(Session("Users"), Users).UserID Then
                    Return CType(Session("Users"), Users).UserID
                Else
                    Return 0
                End If
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("UserID") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            If UserID <= 0 Then
                Response.Redirect(UIHelper.GetUnionVerseBasePathURL & "/Registration.aspx?ReturnURL=" + HttpContext.Current.Request.Url.AbsoluteUri.ToLower)
            End If
            Me.SchoolRegis1.LoadData()
        End If

    End Sub
End Class
