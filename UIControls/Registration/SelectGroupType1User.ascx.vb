Imports System.Data
Imports System
Imports UserLibrary


Partial Class CMSModules_Membership_Controls_SelectGroupType1User
    Inherits System.Web.UI.UserControl


    Public Sub LoadData()
        Dim _UserName As String = Me.txtUserName.Text.Trim
        Dim Galaxy As Integer = Me.ddGalaxy.SelectedValue
        Dim ZipCode As String = Me.txtZipCode.Text.Trim


        Dim Arl As New ArrayList
        Dim oUt1 As New smt_UserType1
        Arl = oUt1.GetByFillter(0, _UserName, ZipCode, Galaxy)
        If Arl.Count > 0 Then
            Me.rpUsers.DataSource = Arl
            Me.rpUsers.DataBind()
            Me.rpUsers.Visible = True
            Me.lblNoRecord.Visible = False
        Else
            Me.rpUsers.DataSource = New ArrayList
            Me.rpUsers.DataBind()
            Me.rpUsers.Visible = False
            Me.lblNoRecord.Visible = True
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadData()
        End If
    End Sub
    Public Function GetUserImage(ByVal UserID As Integer) As String
        Dim _u1 As New Users(UserID)
        If Not IsNothing(_u1) Then
            If _u1.ProfileImage.Trim.Length > 0 Then
                Return UIHelper.GetUnionVerseBasePathURL & "/" & _u1.ProfileImage.Trim
            Else
                Return UIHelper.GetUnionVerseBasePathURL & "/UserFiles/Profiles/Profile-Pic-Man.png"
            End If
        Else
            Return ""
        End If
    End Function
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        LoadData()
    End Sub

    Public Function GetLink(ByVal str As String) As String
        Return UIHelper.GetUnionVerseBasePathURL() & "/" & str.Trim.Replace(" ", "_") & ".aspx"
    End Function
End Class
