Imports UserLibrary
Partial Class GroupType1IndReg
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
    Public ReadOnly Property GroupID() As Integer   '  UserType1ID will come from UserType1 table.
        Get
            If Not IsNothing(Request.Item("GID")) AndAlso IsNumeric(Request.Item("GID")) Then
                Return CInt(Request.Item("GID"))
            Else
                Return 0
            End If
        End Get
    End Property
    Public Sub LoadData()
        Dim oUT1 As New smt_UserType1(GroupID)
        If Not IsNothing(oUT1) AndAlso oUT1.UserType1ID > 0 Then
            Me.hGroupName.InnerHtml = oUT1.UserName.Trim
            Me.hlIndividualregistration.NavigateUrl = "ind1reg_" & oUT1.UserName.Trim.Replace(" ", "_") & ".aspx"
            Me.hlIndividualregistration2.NavigateUrl = "ind2reg_" & oUT1.UserName.Trim.Replace(" ", "_") & ".aspx"
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If UserID <= 0 Then
            If GroupID > 0 Then
                Dim out1 As New smt_UserType1(GroupID)
                If Not IsNothing(out1) AndAlso out1.UserType1ID > 0 Then
                    Response.Redirect(UIHelper.GetUnionVerseBasePathURL & "/Registration.aspx?returnurl=" & UIHelper.GetUnionVerseBasePathURL() & "/" & out1.UserName & ".aspx")
                End If
            Else
                Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/default.aspx")
            End If
        End If
        If Not Page.IsPostBack Then
            LoadData()
        End If
    End Sub
End Class
