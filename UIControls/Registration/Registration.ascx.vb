Imports UserLibrary

Partial Class UIControls_Registration_Registration
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

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
        If IsValidate() Then
            Dim oU As New Users()
            oU.Username = Me.txtUsername.Text.Trim
            oU.Email = Me.txtEmail.Text
            oU.Password = Me.txtPassword.Text.Trim
            oU.CreatedDate = DateTime.Now
            oU.Status = 4
            oU.Save()
            AutoLogin(oU)
        End If
    End Sub
    Public Function IsValidate() As Boolean
        Me.lblError.Text = ""

        If Session("CaptchaImageText") Is Nothing Then
            Response.Redirect(UIHelper.GetUnionVerseBasePathURL() & "/login.aspx")
        End If

        If Me.txtUsername.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Please enter username."
            Return False
        End If
        If Me.hdnStrength.Value = "0" Then
            Me.lblError.Text = "Password does not meet the minimum requirments."
            Return False
        End If

        Dim oU As New Users(Me.txtUsername.Text.Trim)
        If Not IsNothing(oU) AndAlso oU.Username.Trim.Length > 0 AndAlso oU.Status = 1 Then
            Me.lblError.Text = "Username already exist."
            Return False
        End If
        If Me.txtEmail.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Please enter email."
            Return False
        End If
        Dim oU1 As New Users
        oU1.LoadUserByEmail(Me.txtEmail.Text.Trim)
        If Not IsNothing(oU) AndAlso oU.Email.Trim.Length > 0 AndAlso oU.Status = 1 Then
            Me.lblError.Text = "Email already exist."
            Return False
        End If
        If Me.txtPassword.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Please enter Password."
            Return False
        End If
        If Me.txtPassword.Text.Trim <> Me.txtConfirmPassword.Text.Trim Then
            Me.lblError.Text = "'Confirm Password' should match 'Password'."
            Return False
        End If
        If Session("CaptchaImageText") Is Nothing Then
            lblError.Text = "Invalid code, please enter the code as you see in the image."
            Return False
        End If

        If Session("CaptchaImageText").ToString <> txtSecurityCode.Text.Trim Then
            lblError.Text = "Invalid code, please enter the code as you see in the image."
            Return False
        End If
        If Me.chkPrivacy.Checked = False Then
            Me.lblError.Text = "You must have to agree with UNIonVERSE Terms."
            Return False
        End If
        Return True
    End Function
    Public Sub AutoLogin(ByVal oU As Users)
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
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If GroupType1UserName.Trim.Length > 0 Then
                Me.trGroupType.Visible = True
                Me.lblGroupType1.Text = GroupType1UserName.Trim
            Else
                Me.trGroupType.Visible = False
            End If
        End If

        TermsandCondition()
    End Sub
    Public ReadOnly Property GroupType1UserName() As String
        Get
            If Not IsNothing(Request.QueryString("ReturnURL")) AndAlso Request.QueryString("ReturnURL").Trim.Trim <> "" Then
                Dim str As [String] = Request.QueryString("ReturnURL").ToString().Trim()
                If str.Trim().Length > 0 Then
                    str = str.Substring(str.LastIndexOf("/") + 1)
                    str = str.Replace(".aspx", "")
                    str = str.Replace("_", " ")
                    Dim _ut1 As New smt_UserType1(str)
                    If _ut1 IsNot Nothing AndAlso _ut1.UserType1ID > 0 Then
                        Return _ut1.UserName
                    Else
                        Return ""
                    End If
                Else
                    Return ""
                End If
            Else
                Return ""

            End If
        End Get

    End Property

    Public Sub TermsandCondition()
        If Not IsNothing(Request.QueryString("ReturnURL")) AndAlso Request.QueryString("ReturnURL").Trim.Trim <> "" Then
            Dim str As [String] = Request.QueryString("ReturnURL").ToString().Trim()
            If str.Trim().Length > 0 Then
                str = str.Substring(str.LastIndexOf("/") + 1)
                str = str.Replace(".aspx", "")
                str = str.Replace("_", " ")
                If str <> "" Then
                    If str.Contains("grouptype1") Then
                        Me.lblTerms.Text = " I understand, agree, and accept the <a href='http://www.unionverse.com/Terms.aspx'>UNIonVERSE Terms & Conditions</a>, <a href='http://www.unionverse.com/plateform-policy.aspx'>UNIonVERSE Policy Rights and Responsibilities</a>, and <a href='http://www.wormwholes.com/Terms.aspx'> WormWholes Payment Terms</a>. Further, we hereby agree, understand and accept that all UNI, and the equivalent withdrawal currencies, are donations, and UNIonVERSE is not obligated to any contractual monetary agreement."

                    ElseIf str.Contains("business") Then
                        Me.lblTerms.Text = "I understand, agree, and accept the <a href='http://www.unionverse.com/Terms.aspx'>UNIonVERSE Terms & Conditions</a>, <a href='http://www.unionverse.com/plateform-policy.aspx'>UNIonVERSE Policy Rights and Responsibilities</a>, and <a href='http://www.wormwholes.com/Terms.aspx'>WormWholes Payment Terms</a>. Further, we hereby agree, understand and accept that for the use of the UNIonVERSE Platform, UNIonVERSE will take a fee of 35% of the Total UNI from each respective sale for `Non-Connections', also known as non-linked individuals or businesses, and 10% for any `Connections`, also known as linked individuals or businesses, between you and (potential) consumers."
                    Else
                        Me.lblTerms.Text = "I understand, agree, and accept the <a href='http://www.unionverse.com/Terms.aspx'>UNIonVERSE Terms & Conditions</a>, <a href='http://www.unionverse.com/plateform-policy.aspx'>UNIonVERSE Policy Rights and Responsibilities</a>, and <a href='http://www.wormwholes.com/Terms.aspx'>WormWholes Payment Terms</a>."
                    End If
                End If

            Else


            End If
        End If


    End Sub
End Class
