Imports AdminLibrary
Imports CMSLibrary

Partial Class CMS_AdministratorsAddEdit
    Inherits System.Web.UI.UserControl
    Public Event HideAddEdit()
    Public Property AdministratorID() As Integer
        Get
            If Not IsNothing(ViewState("AdministratorID")) AndAlso IsNumeric(ViewState("AdministratorID")) Then
                Return ViewState("AdministratorID")
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("AdministratorID") = value
        End Set
    End Property
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click, btnUSave.Click
        If IsValidate() Then
            SaveData()
            RaiseEvent HideAddEdit()
        End If
    End Sub
    Public Sub LoadAdRoleID()
        Dim UI As New UIHelper
        UI.LoadAdRoleID(Me.ddlAdroleid, "--Select--")
    End Sub


    Public Sub LoadData()
        LoadAdRoleID()
        If AdministratorID > 0 Then
            uc_ErrMsg.Message = ""
            Dim oMI As New Administrators(AdministratorID)

            If Not IsNothing(oMI.AdRoleID) AndAlso IsNumeric(oMI.AdRoleID) AndAlso Me.ddlAdroleid.Items.Contains(Me.ddlAdroleid.Items.FindByValue(oMI.AdRoleID.ToString)) Then
                Me.ddlAdroleid.SelectedValue = oMI.AdRoleID
            End If

            Me.txtName.Text = oMI.Name
            Me.txtEmail1.Text = oMI.Email1
            Me.txtEmail2.Text = CStr(oMI.Email2)
            Me.Txtusername.Text = oMI.Username
            Me.txtPassword.Text = oMI.Password
            Me.txtAccountNotes.Text = oMI.AccountNotes
            Me.chkisactive.Checked = oMI.IsActive
            Me.lbllastlogin.Text = oMI.LastLogin
            Me.lblDateReg.Text = oMI.DateRegistered
        Else
            uc_ErrMsg.Message = ""
            Me.txtEmail2.Text = ""
            Me.txtEmail1.Text = ""
            Me.Txtusername.Text = ""
            Me.txtPassword.Text = ""
            Me.txtAccountNotes.Text = ""
            Me.txtName.Text = ""
            Me.ddlAdroleid.SelectedValue = 0
            Me.lblDateReg.Text = Date.Now
            Me.chkisactive.Checked = True
        End If
    End Sub

    Public Function IsValidate() As Boolean
        uc_ErrMsg.Message = ""

        If Me.txtName.Text.Trim.Length <= 0 Then
            uc_ErrMsg.Message = "Please enter name."
            Me.txtName.Focus()
            Return False
        End If
        If Me.Txtusername.Text.Trim.Length <= 0 Then
            uc_ErrMsg.Message = "Please enter username."
            Me.Txtusername.Focus()
            Return False
        End If

        If Me.txtPassword.Text.Trim.Length <= 0 Then
            uc_ErrMsg.Message = "Please enter password."
            Me.txtPassword.Focus()
            Return False
        End If
        If Me.txtEmail1.Text.Trim.Length <= 0 Then
            uc_ErrMsg.Message = "Please enter email1."
            Me.txtEmail1.Focus()
            Return False
        End If
        If Me.txtPassword.Text.Trim.Length < 6 Then
            uc_ErrMsg.Message = "Password characters should be 6 minimum."
            Me.txtPassword.Focus()
            Return False
        End If

        If Me.ddlAdroleid.SelectedValue <= 0 Then
            uc_ErrMsg.Message = "Please select adroleid."
            Me.ddlAdroleid.Focus()
            Return False
        End If

        If Not UIHelper.isValidEmail(txtEmail1.Text.Trim) Then
            uc_ErrMsg.Message = "Please enter valid email1 address."
            Me.txtEmail1.Focus()
            Return False
        End If

        If Me.txtEmail2.Text.Trim.Length > 0 Then
            If Not UIHelper.isValidEmail(txtEmail2.Text.Trim) Then
                uc_ErrMsg.Message = "Please enter valid email2 address."
                Me.txtEmail2.Focus()
                Return False
            End If
        End If
        Return True
    End Function
    Private Sub SaveData()
        Dim oAd As New Administrators
        If AdministratorID > 0 Then
            oAd = New Administrators(AdministratorID)
            If IsNothing(oAd.DateRegistered) Or oAd.DateRegistered.ToShortDateString = "1/1/1900" Then
                oAd.DateRegistered = Date.Now
            End If
        Else
            oAd = New Administrators
            oAd.DateRegistered = Date.Now
            oAd.LastLogin = Date.Now
        End If
        oAd.Name = Me.txtName.Text.Trim
        oAd.IsActive = Me.chkisactive.Checked
        oAd.Username = Me.Txtusername.Text.Trim
        oAd.AdRoleID = Me.ddlAdroleid.SelectedValue
        oAd.Password = Me.txtPassword.Text.Trim
        oAd.Email1 = Me.txtEmail1.Text.Trim
        oAd.Email2 = Me.txtEmail2.Text.Trim
        oAd.AccountNotes = Me.txtAccountNotes.Text.Trim
        Me.lblDateReg.Text = Date.Now
        oAd.save()
        AdministratorID = oAd.AdministratorID
        If Me.ddlAdroleid.SelectedValue = 1 Then
            Dim AdRoleID As Integer = Me.ddlAdroleid.SelectedValue
            'SaveRights()
        End If

    End Sub
    'Public Sub SaveRights()
    '    ' Delete existing adRole rights
    '    Dim oAdministratorRight As New AdministratorRights
    '    oAdministratorRight.DeleteoAdministratorRights(Me.ddlRightCategory.SelectedValue, ddlAdministrators.SelectedValue)
    '    ' Add Selected right to adRole 
    '    For Each il As ListItem In chkRights.Items
    '        If il.Selected = True Then
    '            'Add li.selected.value to AdRole
    '            oAdministratorRight.AddRightToAdministrator(ddlAdministrators.SelectedValue, il.Value, Date.Now, 0)
    '            oAdministratorRight.AdministratorRightID = 0
    '        End If
    '    Next
    'End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click, btnUCancel.Click
        RaiseEvent HideAddEdit()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.txtName.Focus()
            Me.lblDateReg.Text = Now
            Me.lbllastlogin.Text = "01/01/2000"
            LoadAdRoleID()
        End If
    End Sub
End Class