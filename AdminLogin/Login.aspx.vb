Imports AdminLibrary
Imports CMSLibrary
Partial Class AdminLogin_Login
    Inherits System.Web.UI.Page
    Public ReadOnly Property LoginMessage() As Integer
        Get
            If Not IsNothing(Request.Form("LogStatus")) AndAlso Request.Form("LogStatus").Trim.Length > 0 Then
                Return Request.Form("LogStatus")
            Else
                Return ""
            End If
        End Get
    End Property
    Public ReadOnly Property username() As String
        Get
            If Not IsNothing(Request.QueryString("uid")) AndAlso Request.QueryString("uid").Trim.Length > 0 Then
                Return Request.QueryString("uid")
            Else
                Return ""
            End If
        End Get
    End Property
    Public Enum eLoginMessages
        LoginFailed = 1
        CookiesBlock = 2
    End Enum
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        lblMessage.Text = ""
        lblNote.Text = ""
        plhErrMsg.Visible = False
        If Request.Cookies("AdminCookie") Is Nothing Then
            Dim cookieCheck As New HttpCookie("AdminCookie")
            cookieCheck.Value = "Yes"
            cookieCheck.Expires = Now.AddDays(1)
            Response.Cookies.Add(cookieCheck)
        End If

        'If IsPostBack = False Then


        '    Dim loginSessionID As Integer = 0
        '    If Not IsNothing(Request.QueryString("ss")) AndAlso IsNumeric(Request.QueryString("ss")) Then
        '        loginSessionID = Request.QueryString("ss")
        '        Dim oLoginSession As New LoginSession(loginSessionID)

        '        txtUsername.Text = Utility.DecryptText(oLoginSession.Username)
        '        txtPassword.Text = Utility.DecryptText(oLoginSession.password)
        '        lbtLogIn_Click(New Object, Nothing)

        '    End If

        'End If
    End Sub

    Public Function ValidateInfo() As Boolean
        If txtUsername.Text.Trim.Length <= 0 Then
            Return False
        End If
        If txtPassword.Text.Trim.Length <= 0 Then
            Return False
        End If
        Return True
    End Function
    Protected Sub lbtLogIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtLogIn.Click
        Try

            If Request.Cookies("AdminCookie") Is Nothing Then
                lblMessage.Text = "Unable to login to this system."
                lblNote.Text = "<b>You cannot log in without cookies enabled in your browser.  Please set your browser to accept cookies and try again.</b>"
                plhErrMsg.Visible = True
                Exit Sub
            End If

            Dim groupID As Integer
            If ValidateInfo() = False Then
                plhErrMsg.Visible = True
                lblMessage.Text = "Login failed. Incorrect username or password."
                lblNote.Text = "If you have forgotten your password, type your email into the field box and click Forgot your password?"
                Exit Sub
            Else
                Dim oAdmin As New Administrators()
                oAdmin.LoadByUserName(txtUsername.Text)
                If oAdmin.AdministratorID = 0 OrElse oAdmin.Password <> Me.txtPassword.Text Then
                    plhErrMsg.Visible = True
                    lblMessage.Text = "Login failed. Incorrect username or password."
                    lblNote.Text = "If you have forgotten your password, type your email into the field box and click Forgot your password?"
                    Exit Sub
                End If
            End If
            Dim oAdministrator As New Administrators()
            oAdministrator.LoadByUserName(txtUsername.Text)

            If oAdministrator.AdministratorID > 0 AndAlso oAdministrator.IsActive = False Then
                lblMessage.Text = "Login failed."
                plhErrMsg.Visible = True
                lblNote.Text = "Your account is currently not active, please complete the registration and try again."
                Exit Sub
            End If
            'userId = Users.AuthenticateUserByEmail(txtUsername.Text, txtPassword.Text)

            If oAdministrator.AdministratorID > 0 Then
                'oUser = New Users(userId)

                Session("Administrator") = oAdministrator
                Session("CurrentAdmin") = oAdministrator.AdministratorID
                Session.Add("Authenticated", True)
                oAdministrator.LastLogin = Date.Now
                oAdministrator.save()
                Dim ticket As FormsAuthenticationTicket = New FormsAuthenticationTicket(0, oAdministrator.AdministratorID.ToString(), DateTime.Now, DateTime.Now.AddMinutes(30), False, groupID.ToString(), FormsAuthentication.FormsCookiePath)
                Dim data As String = FormsAuthentication.Encrypt(ticket)
                Dim cookie As HttpCookie = New HttpCookie(FormsAuthentication.FormsCookieName, data)
                cookie.Expires = DateTime.Now.AddDays(1)
                Response.Cookies.Add(cookie)
                Response.Redirect(UIHelper.GetBasePath & "/Admin/managepagecontent.aspx", True)
            Else
                plhErrMsg.Visible = True
                lblMessage.Text = "Login failed. Incorrect username or password."
                lblNote.Text = "If you have forgotten your password, type your email into the email field and click Forgot your password?"
            End If

        Catch ex As Exception
            Throw ex
            ' ExceptionManager.Publish(ex)
        End Try
    End Sub
    Public Function GetOldSession() As String
        If Not IsNothing(Request.QueryString("ss")) AndAlso Request.QueryString("ss").ToString.Length > 0 Then
            Return CStr(Request.QueryString("ss"))
        Else
            Return ""
        End If
    End Function
    Protected Sub btnPwdReminder_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPwdReminder.Click
        If VerifyUserEmailAddress() = True Then
            Dim oAdministrator As New Administrators
            oAdministrator.LoadByEmail(txtUsername.Text)
            If Not IsNothing(oAdministrator) AndAlso oAdministrator.AdministratorID > 0 Then
                Dim oEmail As New Email
                oEmail.Subject = "Accessories2you.com Password Reminder."
                oEmail.Body = "Good Day." & vbCrLf & "You have requested a password reminder from Stellar Management admin. " & _
            "Your login information is as follows:" & vbCrLf & vbCrLf & "Email Address: " & oAdministrator.Email1 & vbCrLf & _
            "Username: " & oAdministrator.Username & vbCrLf & vbCrLf & _
            "Password: " & oAdministrator.Password & vbCrLf & vbCrLf & _
            "Make sure that you type your password exactly as it appears here." & vbCrLf & vbCrLf & "Sincerely, " & vbCrLf & "The Stellarmanagement.com " & _
            "administrators."
                oEmail.EmailTo = oAdministrator.Email1
                oEmail.sendMailDirect(oEmail.EmailTo, Utility.GetWebSiteSettingKey("MailFromAddress"), oEmail.Subject, oEmail.Body)
            End If
            plhLogin.Visible = False
            plhMessage.Visible = True
        End If
    End Sub
    Public Function VerifyUserEmailAddress() As Boolean
        Dim oAdministrator As New Administrators
        If txtUsername.Text.Trim.Length > 0 Then
            If Utility.isValidEmail(txtUsername.Text) = False Then
                lblMessage.Text = "Invalid information. Please see the note below."
                lblNote.Text = "Invalid email address. Please enter valid email address and try again."
                plhErrMsg.Visible = True
                Return False
            Else
                oAdministrator.LoadByEmail(txtUsername.Text)

                If Not IsNothing(oAdministrator) OrElse oAdministrator.AdministratorID = 0 Then
                    lblMessage.Text = "Invalid information. Please see the note below."
                    lblNote.Text = "Email address not found in the system. You are not currently register with Accessories2you.com. Please sign up first."
                    plhErrMsg.Visible = True
                    Return False
                Else
                    Return True
                End If
            End If
        Else
            lblMessage.Text = "Please enter your email address."
            lblNote.Text = "You must supply a valid email address in username textbox in order to retrive your password."
            plhErrMsg.Visible = True
        End If
    End Function
End Class



