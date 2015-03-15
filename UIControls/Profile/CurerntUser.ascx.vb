Imports UserLibrary

Partial Class UIControls_Profile_CurerntUser
    Inherits System.Web.UI.UserControl
    Public _ProfileURL As String = ""
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

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'If Not Page.IsPostBack Then
        '    If IsNothing(Request.Cookies("UnionVERSEUserInfo")) OrElse IsNothing(Request.Cookies("UnionVERSEUserInfo")("userName")) Then
        '        Response.Redirect(UIHelper.GetBasePath() & "/login.aspx")
        '    End If
        'End If

        Dim _cURL As String = HttpContext.Current.Request.Url.AbsoluteUri.ToLower
        If UserID > 0 Then
            MakeLink()
            Dim oU As New Users(UserID)
            Dim type1 As Boolean = False
            Dim str As String = _cURL
            If str.Trim().Length > 0 Then
                str = str.Substring(str.LastIndexOf("/") + 1)
                str = str.Replace(".aspx", "")
                str = str.Replace("_", " ")
                Dim _ut1 As New smt_UserType1(str)
                If _ut1 IsNot Nothing AndAlso _ut1.UserType1ID > 0 Then
                    type1 = True
                Else
                    type1 = False
                End If
            End If
            If oU.UserTypeID = 0 AndAlso Not _cURL.Contains("selectgroup.aspx") AndAlso Not _cURL.Contains("login.aspx") AndAlso Not _cURL.Contains("registration.aspx") AndAlso Not _cURL.Contains("registration-type.aspx") AndAlso Not type1 Then
                If _cURL.Contains("grouptype1") OrElse _cURL.Contains("businessusers") OrElse _cURL.Contains("moonregistration") OrElse _cURL.Contains("grouptype4") Then
                    Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/Registration.aspx?ReturnURL=" & _cURL)
                Else
                    Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/Login.aspx?ReturnURL=" & _cURL)
                End If
            End If
        End If
    End Sub
    Public Sub MakeLink()
        Dim oU As New Users()
        oU = Session("Users")
        Dim userInfo As String = "<span>"
        userInfo += oU.Username
        userInfo += "</span>"
        userInfo = "<a href=""" & UIHelper.GetUnionVerseBasePathURL() & "/Members/" & oU.Username & ".aspx"">" & userInfo & "</a>"
        Dim utp As New smt_UserType1Planet()
        Dim arl As New ArrayList()
        arl = utp.GetByUserID(oU.UserID)
        If arl.Count > 0 Then
            utp = CType(arl(0), smt_UserType1Planet)
            If utp IsNot Nothing AndAlso utp.IsApproved = True Then
                Dim ut1 As New smt_UserType1(utp.UserType1ID)
                If ut1 IsNot Nothing AndAlso ut1.UserType1ID > 0 Then
                    userInfo = ("<a href=""" & UIHelper.GetUnionVerseBasePathURL() & "/Members/") + ut1.UserName & ".aspx"">" & ut1.UserName & "</a> | " & userInfo
                End If
            End If
        End If
        _ProfileURL = userInfo
    End Sub
End Class
