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
Partial Class UIControls_Profile_MoonsView
    Inherits System.Web.UI.UserControl
    Public Property UserID() As Integer
        Get
            If Not IsNothing(ViewState("UserID")) AndAlso IsNumeric(ViewState("UserID")) Then
                Return CInt(ViewState("UserID"))
            Else
                If Not IsNothing(Session("Users")) Then
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

    Public Sub LoadData()
        Dim oU As New Users(UserID)
        Dim oSchool As New smt_School
        oSchool.LoadByUserID(oU.UserID)
        If Not IsNothing(oSchool) AndAlso oSchool.SchoolID > 0 Then
            Me.lblUserName.InnerHtml = oU.Username.Trim
            Me.spType.InnerHtml = oSchool.Types

            Me.lblWebsiteAddress.InnerHtml = oSchool.WebsiteAddress.Trim
            Me.lblTelephoneNumber.InnerHtml = oSchool.TelephoneNumber
            Me.lblAddress.InnerHtml = oSchool.Address1 & " " & oSchool.Address2
            Me.lblState.InnerHtml = oSchool.State
            Me.lblZipCode.InnerHtml = oSchool.ZipCode
            Me.lblTelephoneNumber.InnerHtml = oSchool.TelephoneNumber


            Me.lblAlternateAddress.InnerHtml = oSchool.AlternateAddress1 & " " & oSchool.AlternateAddress2
            Me.lblAlternateState.InnerHtml = oSchool.State.Trim
            Me.lblAlternateZipCode.InnerHtml = oSchool.AlternateZipCode.Trim

            Me.lblStatus.InnerHtml = oSchool.Status
            Me.lblHoursOfOperation.InnerHtml = oSchool.HoursOfOperation

            '           Me.lblSchoolLevel.InnerHtml = oSchool.EducationLevel


            Me.lblGovenmentLevel.InnerHtml = oSchool.GovtType

            Me.lblMediaType.InnerHtml = oSchool.MediaType

            Me.lblDescription.InnerHtml = oSchool.Description


            If oSchool.Types = "School" Then
                Me.spnSchoolLabel.InnerHtml  = "School Name:"
                phSubType.Visible = True
                Me.spnSubType.InnerHtml = "Education Level:"
                Me.lblSubType.InnerHtml = oSchool.EducationLevel
            ElseIf oSchool.Types = "Government" Then
                Me.spnSchoolLabel.InnerHtml = "Government Name:"

                phSubType.Visible = True
                Me.spnSubType.InnerHtml = "Government Type:"
                Me.lblSubType.InnerHtml = oSchool.GovtType

            ElseIf oSchool.Types = "Media" Then
                Me.spnSchoolLabel.InnerHtml = "Company Name:"
                phSubType.Visible = True
                Me.spnSubType.InnerHtml = "Company Type:"
                Me.lblSubType.InnerHtml = oSchool.MediaType
            ElseIf oSchool.Types = "Parks & Recreation" Then
                Me.spnSchoolLabel.InnerHtml = "Parks & Recreation Name:"
                phSubType.Visible = False
            ElseIf oSchool.Types = "Groups" Then
                Me.spnSchoolLabel.InnerHtml = "Group Name:"
                phSubType.Visible = False
            End If


            Me.lblSchoolName.InnerHtml = oSchool.SchoolName
            Me.lblAbout.InnerHtml = oSchool.About

            Me.lblIndustry.InnerHtml = oSchool.IndustryName

            Me.lblCity.InnerHtml = oSchool.City
            Dim oC As New CommonLibrary.Country(oSchool.CountryID)
            If Not IsNothing(oC) AndAlso oC.CountryDisplayName.Trim.Length > 0 Then
                Me.lblCountry.InnerHtml = oC.CountryDisplayName
                If oC.CountryDisplayName.ToLower.Trim.Contains("usa") Then
                    Me.divState.Visible = True
                Else
                    Me.divState.Visible = False
                End If
            Else
                Me.divState.Visible = False
            End If



            Me.trGovernmentLevel.Visible = False
            Me.trMediaType.Visible = False
            '  Me.trSchoolLevel.Visible = False


            If oSchool.Types = "School" Then
                '    Me.trSchoolLevel.Visible = True
            ElseIf oSchool.Types = "Government" Then
                Me.lblUnionverid.InnerHtml = "Moon" & ReturnAbrMoodTypes(oSchool.Types) & ReturnAbriGovLevel(oSchool.GovtType) & oSchool.SchoolID
            ElseIf oSchool.Types = "Media" Then
                Me.lblUnionverid.InnerHtml = "Moon" & ReturnAbrMoodTypes(oSchool.Types) & ReturnAbriMediaType(oSchool.MediaType) & oSchool.SchoolID
            ElseIf oSchool.Types = "Parks & Recreation" Then
            ElseIf oSchool.Types = "Groups" Then
            End If


            lblUnionverid.InnerHtml = oU.UnionVerseID
            If oSchool.UserID <> CurrentUser.UserID Then
                phButtons.Visible = True
            Else
                phButtons.Visible = False
            End If

            If oSchool.AlternateZipCode.Trim.Length = 0 Then
                Me.tr1AlternateZipCode.Visible = False
            End If
            If oSchool.AlternateAddress1.Trim.Length = 0 Then
                Me.tr1AlternateAddress.Visible = False
            End If
            If oSchool.AlternateState.Trim.Length = 0 Then
                Me.tr1AlternateState.Visible = False
            End If
        End If
    End Sub
    Public Function ReturnAbrMoodTypes(ByVal str As String) As String
        Select Case str
            Case "School"
                Return "S"
            Case "Government"
                Return "G"
            Case "Media"
                Return "M"
            Case "Parks & Recreation"
                Return "PR"
            Case "Groups"
                Return "N"
            Case Else
                Return ""
        End Select
    End Function
    Public Function ReturnAbriEducationLevel(ByVal str As String) As String
        Select Case str
            Case "Pre-School"
                Return "P"
            Case "Primary School"
                Return "nN"
            Case "Middle School"
                Return "M"
            Case "Secondary"
                Return "N"
            Case "Undergraduate"
                Return "U"
            Case "Postgraduate"
                Return "G"
            Case Else
                Return ""
        End Select
    End Function
    Public Function ReturnAbriGovLevel(ByVal str As String) As String
        Select Case str
            Case "Local"
                Return "L"
            Case "State or Territory"
                Return "T"
            Case "Federal"
                Return "F"
            Case Else
                Return ""
        End Select
    End Function
    Public Function ReturnAbriMediaType(ByVal str As String) As String
        Select Case str
            Case "Print"
                Return "P"
            Case "Internet"
                Return "I"
            Case "Radio"
                Return "R"
            Case "Television"
                Return "T"
            Case "Other"
                Return "O"
            Case Else
                Return ""
        End Select
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim script As String = "function displayRequest_" & ClientID & "(){ " & vbLf & "modalDialog('" & ResolveUrl("~/CMSModules/Friends/CMSPages/Friends_Request.aspx") & "?userid=" & CurrentUser.UserID & "&requestid= " & UserID & "&IsLunarBase=1' ,'requestFriend', 480, 250); " & vbLf & "} " & vbLf
            hlAddFriend.Attributes.Add("onclick", "javascript:displayRequest_" & ClientID & "();")
            hlAddFriend.Style.Add("cursor", "pointer")
            hlAddFriend.Text = "Add me as a 'Moon'"
        End If
    End Sub
    Public ReadOnly Property CurrentUser As Users
        Get
            If Not IsNothing(Session("Users")) Then
                Return CType(Session("Users"), Users)
            Else
                Return New Users
            End If
        End Get
    End Property
End Class
