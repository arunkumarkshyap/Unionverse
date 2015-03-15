Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Imports UserLibrary
Imports CommonLibrary

Imports System.IO
Imports System.Net.Mail

Partial Class CMSWebParts_SMTWebParts_Careers
    Inherits System.Web.UI.UserControl
    Public Sub LoadData()
        Me.phForm.Visible = True
        Me.phSuccessFull.Visible = False
        LoadCountryState()
        Me.txtFirstName.Text = ""
        Me.txtLastName.Text = ""
        Me.txtUnionVerseID.Text = ""
        Me.txtCurrentEmployer.Text = ""
        Me.txtCity.Text = ""
        Me.txtZipCode.Text = ""
        Me.txtComments.Text = ""
        Me.lblIndustry.Text = ""
    End Sub


    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If IsValidate() Then
            Dim _EBody As String = ""
            '_EBody = _EBody & "<b>First Name:</b> " & Me.txtFirstName.Text.Trim & "<br />"
            '_EBody = _EBody & "<b>Last Name:</b> " & Me.txtLastName.Text.Trim & "<br />"
            '_EBody = _EBody & "<b>UNIonVERSE ID:</b> " & Me.txtUnionVerseID.Text.Trim & "<br />"
            '_EBody = _EBody & "<b>Email Address:</b> " & Me.txtEmailAddress.Text.Trim & "<br />"
            '_EBody = _EBody & "<b>Location:</b> " & GetLocation() & "<br />"
            '_EBody = _EBody & "<b>Current Employer:</b> " & Me.txtCurrentEmployer.Text.Trim & "<br />"
            '_EBody = _EBody & "<b>Industry:</b> " & GetIndustry() & "<br />"
            '_EBody = _EBody & "<b>Category:</b> " & GetCategory() & "<br />"
            '_EBody = _EBody & "<b>How do you belive you can contribute to the UNIonVERSE:</b> " & Me.txtComments.Text.Trim & "<br />"
            '_EBody = _EBody & "" & "<br />"
            'Dim msg As New EmailMessage()
            'msg.From = SMTUIHelper.GetSiteConfigurationValue("FromEmailAddress") 'Me.txtEmailAddress.Text.Trim
            'msg.Recipients = SMTUIHelper.GetSiteConfigurationValue("CareersToEmail")  '"shamoon555@hotmail.com"  '"userto@domain.cz"
            'msg.Subject = "Career"
            'msg.Body = _EBody
            'If Not IsNothing(fuResume) AndAlso fuResume.FileName.Trim.Length > 0 Then
            '    Dim am As New AttachmentManager()
            '    Dim attachmentGUID As New Guid
            '    attachmentGUID = Guid.NewGuid
            '    Dim attachmentName As [String] = fuResume.FileName  '"pdfTest.pdf"
            '    Dim ms As New MemoryStream(fuResume.FileBytes)
            '    Dim mailAttachment As New Attachment(ms, attachmentName) ', "application/pdf"
            '    msg.Attachments.Add(mailAttachment)
            'End If
            'CMS.EmailEngine.EmailSender.SendEmail(msg)
            'CMS.EmailEngine.EmailSender.SendEmail(CMS.CMSHelper.CMSContext.CurrentSiteName, msg)
            Me.phForm.Visible = False
            Me.phSuccessFull.Visible = True
        End If
    End Sub
    Public Function GetLocation() As String
        Dim str As String = ""
        If Not IsNothing(Me.ddCountry) AndAlso Me.ddCountry.Items.Count > 0 Then
            str = str & Me.ddCountry.SelectedItem.Text & ", "
            If Me.ddCountry.SelectedValue = "271" AndAlso Not IsNothing(Me.ddState) AndAlso Me.ddState.Visible = True AndAlso Me.ddState.Items.Count > 0 Then
                str = str & Me.ddState.SelectedItem.Text & ", "
            End If
        End If
        str = str & Me.txtCity.Text.Trim & ", " & Me.txtZipCode.Text.Trim()
        Return str
    End Function
    Public Function GetIndustry() As String
        Dim str As String = ""
        str = Me.lblIndustry.Text.Trim
        Return str
    End Function
    Public Function GetCategory() As String
        Dim str As String = ""
        Return str
    End Function
    Public Function IsValidate() As Boolean
        lblError.Text = ""
        If Me.txtFirstName.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter fist name."
            Return False
        End If
        If Me.txtLastName.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter last name."
            Return False
        End If
        If Me.txtUnionVerseID.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter UNIonVERSEID."
            Return False
        Else
            Dim oUU As New UserLibrary.Users
            oUU.LoadUserByUnionVerseID(Me.txtUnionVerseID.Text.Trim)
            If IsNothing(oUU) OrElse oUU.UserID <= 0 Then
                Me.lblError.Text = "Enter valid UNIonVERSEID."
                Return False
            End If
        End If
        If Me.txtCity.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter city."
            Return False
        End If
        If Me.txtZipCode.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Enter ZipCode."
            Return False
        End If
        If Me.txtComments.Text.Trim.Length = 0 Then
            Me.lblError.Text = "How do you belive you can contribute to the UNIonVERSE"
            Return False
        End If
        If Me.fuResume.FileName.Trim.Length = 0 Then
            Me.lblError.Text = "Attach resumme file(doc/pdf)."
            Return False
        ElseIf Not Me.fuResume.FileName.Trim.ToLower.Contains(".doc") AndAlso Not Me.fuResume.FileName.Trim.ToLower.Contains(".pdf") Then
            Me.lblError.Text = "Attach valid resumme file(doc/pdf)."
            Return False
        End If

        Return True
    End Function
    Protected Sub SelectIndustry1_IndustrySelected(ByVal Industry As String) Handles SelectIndustry1.IndustrySelected
        Me.mpIndustry.Hide()
        hidIndustry.Value = Industry
        Me.lblIndustry.Text = Industry
    End Sub
    Protected Sub ddCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddCountry.SelectedIndexChanged
        UIHelper.LoadStatesByCountry(Me.ddState, "-- Select State --", CInt(Me.ddCountry.SelectedValue))
        If Me.ddState.Items.Count = 0 Then
            Me.ddState.Visible = False
        Else
            Me.ddState.Visible = True
        End If
    End Sub
    Public Sub LoadCountryState()
        UIHelper.LoadCountry(Me.ddCountry, "--Select Country")
        Me.ddCountry.SelectedValue = "271"
        UIHelper.LoadStatesByCountry(Me.ddState, "-- Select State --", CInt(Me.ddCountry.SelectedValue))
        If Me.ddState.Items.Count = 0 Then
            Me.ddState.Visible = False
        Else
            Me.ddState.Visible = True
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadData()
        End If
    End Sub
End Class
