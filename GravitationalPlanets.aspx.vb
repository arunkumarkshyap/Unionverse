Imports UserLibrary

Partial Class _GravitationalPlanets
    Inherits System.Web.UI.Page
    Public ReadOnly Property UserID As Integer
        Get
            If Not IsNothing(Request.Item("uid")) AndAlso IsNumeric(Request.Item("uid")) Then
                Return CInt(Request.Item("uid"))
            ElseIf Not IsNothing(Session("Users")) AndAlso CType(Session("Users"), Users).UserID > 0 Then
                Return CType(Session("Users"), Users).UserID
            Else
                Return 0
            End If
        End Get
    End Property

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.GravityPlanetsByType.UserID = UserID
            Me.GravityPlanetsByType.DataBind()
        End If
    End Sub
End Class
