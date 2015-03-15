Imports UserLibrary
Partial Class UIControls_LogonMiniForm
    Inherits System.Web.UI.UserControl

    Public ReadOnly Property ReturnURL As String
        Get
            If Not IsNothing(Request.Item("ReturnURL")) AndAlso Request.Item("ReturnURL").Trim.Length > 0 Then
                Return Request.Item("ReturnURL").Trim
            Else
                Return ""
            End If
        End Get
    End Property
    Protected Sub lbtLogon_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtLogon.Click
        If IsValiate() Then
            Dim oU As New Users(UserName.Text.Trim)
            '======================= Cookies Part Starts Here ==============================
            Response.Cookies("UnionVERSEUserInfo")("userName") = oU.Username
            Response.Cookies("UnionVERSEUserInfo")("lastVisit") = DateTime.Now.ToString
            Response.Cookies("UnionVERSEUserInfo").Expires = DateTime.Now.AddDays(1)
            Dim aCookie As New HttpCookie("UnionVERSEUserInfo")
            aCookie.Values("userName") = oU.Username
            aCookie.Values("lastVisit") = DateTime.Now.ToString
            aCookie.Expires = DateTime.Now.AddDays(1)
            Response.Cookies.Add(aCookie)
            '======================= Cookies Part Ends Here ==============================


            Session("Users") = oU
            Session.Add("Authenticated", True)
            Dim ticket As FormsAuthenticationTicket = New FormsAuthenticationTicket(0, oU.UserID.ToString(), DateTime.Now, DateTime.Now.AddDays(1), False, oU.UserID.ToString(), FormsAuthentication.FormsCookiePath)
            Dim data As String = FormsAuthentication.Encrypt(ticket)
            Dim cookie As HttpCookie = New HttpCookie(FormsAuthentication.FormsCookieName, data)
            cookie.Expires = DateTime.Now.AddDays(1)
            Response.Cookies.Add(cookie)
            ' If ReturnURL.Trim.Length > 0 Then
            'Response.Redirect(ReturnURL)
            'Else
            If oU.RoleID = CommonLibrary.Utility.eUserRole.Administrator Then
                Response.Redirect(UIHelper.GetBasePath & "/Admin/AdminDashBoard.aspx")
            ElseIf oU.UserTypeID = 0 Then
                Dim oUE As New smt_UserType1Employee
                oUE.LoadByUserID(oU.UserID)
                If Not IsNothing(oUE) AndAlso oUE.UserType1UserID > 0 Then
                    Dim oU1 As New Users(oUE.UserType1UserID)
                    If Not IsNothing(oU1) AndAlso oU1.Username.Trim.Length > 0 Then
                        Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/" & oU1.Username.Trim & ".aspx")
                    End If
                End If
                Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/Registration-Type.aspx")
            Else
                Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/Members/" & oU.Username & ".aspx")
            End If
            ' End If
        End If
    End Sub
    Public Function IsValiate() As Boolean
        Me.lblError.Text = ""
        lblError.Visible = False
        If Me.UserName.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Please enter username."
            lblError.Visible = True
            Return False
        End If
        If Me.Password.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Please enter password."
            lblError.Visible = True
            Return False
        End If
        Dim oU As New Users(Me.UserName.Text.Trim)
        If IsNothing(oU) AndAlso oU.UserID <= 0 Then
            Me.lblError.Text = "Username or Password is Invalid."
            lblError.Visible = True
            Return False
        ElseIf oU.Password.Trim <> Me.Password.Text.Trim Then
            Me.lblError.Text = "Username or Password is Invalid."
            lblError.Visible = True
            Return False
        ElseIf oU.IsActive = True Then
            Me.lblError.Text = "Your account is not activated."
            lblError.Visible = True
            Return False

        End If
        Return True
    End Function
    Public Sub AutoLogin()
        If Not IsNothing(Request.Cookies("UnionVERSEUserInfo")) Then
            If Not IsNothing(Request.Cookies("UnionVERSEUserInfo")("userName")) Then
                Dim oU As New Users(Server.HtmlEncode(Request.Cookies("UnionVERSEUserInfo")("userName")))
                If Not IsNothing(oU) AndAlso oU.UserID > 0 Then

                    '======================= Cookies Part Starts Here ==============================
                    Response.Cookies("UnionVERSEUserInfo")("userName") = oU.Username
                    Response.Cookies("UnionVERSEUserInfo")("lastVisit") = DateTime.Now.ToString
                    Response.Cookies("UnionVERSEUserInfo").Expires = DateTime.Now.AddDays(1)
                    Dim aCookie As New HttpCookie("UnionVERSEUserInfo")
                    aCookie.Values("userName") = oU.Username
                    aCookie.Values("lastVisit") = DateTime.Now.ToString
                    aCookie.Expires = DateTime.Now.AddDays(1)
                    Response.Cookies.Add(aCookie)
                    '======================= Cookies Part Ends Here ==============================

                    Session("Users") = oU
                    Session.Add("Authenticated", True)
                    Dim ticket As FormsAuthenticationTicket = New FormsAuthenticationTicket(0, oU.UserID.ToString(), DateTime.Now, DateTime.Now.AddDays(1), False, oU.UserID.ToString(), FormsAuthentication.FormsCookiePath)
                    Dim data As String = FormsAuthentication.Encrypt(ticket)
                    Dim cookie As HttpCookie = New HttpCookie(FormsAuthentication.FormsCookieName, data)
                    cookie.Expires = DateTime.Now.AddDays(1)
                    Response.Cookies.Add(cookie)
                    If ReturnURL.Trim.Length > 0 Then
                        Response.Redirect(ReturnURL)
                    Else
                        If oU.RoleID = CommonLibrary.Utility.eUserRole.Administrator Then
                            Response.Redirect(UIHelper.GetBasePath & "/Admin/AdminDashBoard.aspx")
                        ElseIf oU.UserTypeID = 0 Then
                            Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/Registration-Type.aspx")
                        Else
                            Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/Members/" & oU.Username & ".aspx")
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ' AutoLogin()
        End If
    End Sub
End Class
