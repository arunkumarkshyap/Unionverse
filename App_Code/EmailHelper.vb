Imports Microsoft.VisualBasic
Imports UserLibrary
Imports CommonLibrary

Public Class EmailHelper
    Public Shared Sub GroupType1RegistrationConfirmation(ByVal UserID As Integer)
        Dim oU As New Users(UserID)
        If Not IsNothing(oU) Then
            Dim oEmail As New CommonLibrary.Email
            Dim oMailFrom As String = CommonLibrary.Utility.GetSiteConfigrationValue("MailFromAddress")
            Dim oSubject As String = "Registration Completed Successfully"
            Dim oBody As String = "<p>Registration Completed Successfully!</p><p>Here is the link that you can use to register Individuals with you. <br/>" & UIHelper.GetBasePath() & "/members/" & oU.Username.Trim & ".aspx</p>"
            oEmail.sendMailDirect(oU.Email, oMailFrom, oSubject, oBody, "", True, Nothing)
        End If
    End Sub

    Public Shared Sub EmployeeAddEmail(ByVal EmpUserID As Integer, ByVal UserType1UserID As Integer)
        Dim oEmpU As New Users(EmpUserID)
        Dim oUT1U As New Users(UserType1UserID)
        If Not IsNothing(oEmpU) AndAlso Not IsNothing(oUT1U) Then
            Dim oEmail As New CommonLibrary.Email
            Dim oMailFrom As String = CommonLibrary.Utility.GetSiteConfigrationValue("MailFromAddress")
            Dim oSubject As String = "Employee Request"
            Dim oBody As String = "<p>" & oUT1U.Username & " added you as employee</p><p>Here are your temporary username and password to the system <br/>Username: " & oEmpU.Username & "<br>Password: " & oEmpU.Password & "<br/>Please Follow the link below to complete the registration. <br/>" & UIHelper.GetBasePath() & "/login.aspx?ReturnURL=" & UIHelper.GetBasePath() & "/members/" & oUT1U.Username.Trim & ".aspx</p>"
            oEmail.sendMailDirect(oEmpU.Email, oMailFrom, oSubject, oBody, "", True, Nothing)
        End If
    End Sub

    Public Shared Sub MoonRegistration(ByVal UserID As Integer)
        Dim oU As New Users(UserID)
        If Not IsNothing(oU) Then
            Dim oEmail As New CommonLibrary.Email
            Dim oMailFrom As String = CommonLibrary.Utility.GetSiteConfigrationValue("MailFromAddress")
            Dim oSubject As String = "Registration Completed Successfully"
            Dim oBody As String = "<p>Registration Completed Successfully!</p>"
            oEmail.sendMailDirect(oU.Email, oMailFrom, oSubject, oBody, "", True, Nothing)
        End If
    End Sub

    Public Shared Sub BusinessRegistration(ByVal UserID As Integer)
        Dim oU As New Users(UserID)
        If Not IsNothing(oU) Then
            Dim oEmail As New CommonLibrary.Email
            Dim oMailFrom As String = CommonLibrary.Utility.GetSiteConfigrationValue("MailFromAddress")
            Dim oSubject As String = "Registration Completed Successfully"
            Dim oBody As String = "<p>Registration Completed Successfully!</p>"
            oEmail.sendMailDirect(oU.Email, oMailFrom, oSubject, oBody, "", True, Nothing)
        End If
    End Sub

    Public Shared Sub IndividualRegistration(ByVal UserID As Integer)
        Dim oU As New Users(UserID)
        If Not IsNothing(oU) Then
            Dim oEmail As New CommonLibrary.Email
            Dim oMailFrom As String = CommonLibrary.Utility.GetSiteConfigrationValue("MailFromAddress")
            Dim oSubject As String = "Registration Completed Successfully"
            Dim oBody As String = "<p>Registration Completed Successfully!</p>"
            oEmail.sendMailDirect(oU.Email, oMailFrom, oSubject, oBody, "", True, Nothing)
        End If
    End Sub

    Public Shared Sub WhiteWholeRegistration(ByVal UserID As Integer)
        Dim oU As New Users(UserID)
        If Not IsNothing(oU) Then
            Dim oEmail As New CommonLibrary.Email
            Dim oMailFrom As String = CommonLibrary.Utility.GetSiteConfigrationValue("MailFromAddress")
            Dim oSubject As String = "Registration Completed Successfully"
            Dim oBody As String = "<p>Registration Completed Successfully!</p>"
            oEmail.sendMailDirect(oU.Email, oMailFrom, oSubject, oBody, "", True, Nothing)
        End If
    End Sub


    Public Shared Sub TerminateAccount(ByVal EmpUserID As Integer)
        Dim oEmpU As New Users(EmpUserID)
        If Not IsNothing(oEmpU) Then
            Dim oEmail As New CommonLibrary.Email
            Dim oMailFrom As String = CommonLibrary.Utility.GetSiteConfigrationValue("MailFromAddress")
            Dim oSubject As String = "Unionverse-Close Account Request"
            Dim oBody As String = "<p>Please click on the following link to close your account:-<br/> " & UIHelper.GetBasePath() & "/CloseAccount.aspx?op=" & CommonLibrary.Utility.EncryptText(oEmpU.UserID) & "</p>"
            oEmail.sendMailDirect(oEmpU.Email, oMailFrom, oSubject, oBody, "", True, Nothing)
        End If

    End Sub
End Class
