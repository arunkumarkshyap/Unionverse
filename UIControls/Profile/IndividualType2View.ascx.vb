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
Partial Class UIControls_Profile_IndividualType2View
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

        Dim oIU2 As New smt_IndividualUserType2
        oIU2.LoadByUserID(oU.UserID)
        If Not IsNothing(oIU2) AndAlso oIU2.IndividualUserType2ID > 0 Then
            Me.lblUserName.InnerHtml = oU.Username

            lblUnionverid.InnerHtml = oU.UnionVerseID

        
        'Me.lblUnionverid.Text = "Star" & oIU2.GroupTypeID & "PlanetII" & oIU2.IndividualUserType2ID
        Me.lblFullName.InnerHtml = oIU2.FirstName & " " & oIU2.LastName

        Dim oGT1 As New smt_UserType1(oIU2.GroupTypeID)
            Me.lblGroupType1.InnerHtml = oGT1.FullName

        Me.lblState.InnerHtml = oIU2.State
        Me.lblZipCode.InnerHtml = oIU2.ZipCode


        Me.lblLevelOfEducation.InnerHtml = oIU2.LevelOfEducation
        Me.lblCollegeAttended.InnerHtml = oIU2.CollegeAttended
        Me.lblDegreeIn.InnerHtml = oIU2.DegreeIn


        Me.lblEmployerName.InnerHtml = oIU2.EmployerName
        Me.lblCurrentPosition.InnerHtml = oIU2.CurrentPosition

        Me.lblTypeOfAgent.InnerHtml = oIU2.TypeOfAgent
        Me.lblYearsOfExperience.InnerHtml = oIU2.YearsOfExperience


        Me.lblBusinessAddress.InnerHtml = oIU2.BusinessAddress1 & " " & oIU2.BusinessAddress2
        Me.lblState.InnerHtml = oIU2.State
        Me.lblZipCode.InnerHtml = oIU2.ZipCode
        Me.lblCity.InnerHtml = oIU2.City

        Me.lblAddress.InnerHtml = (oIU2.Address1 & " " & oIU2.Address2).Replace("  ", " ").Trim

        Me.lblAbout.InnerHtml = oIU2.About

        Me.lblGender.InnerHtml = oIU2.Gender


        Me.lblBusinessCity.InnerHtml = oIU2.City2


        Dim oC As New CommonLibrary.Country(oIU2.CountryID)
            If Not IsNothing(oC) AndAlso oC.CountryDisplayName.Trim.Length > 0 Then
                Me.lblCountry.InnerHtml = oC.CountryDisplayName
                If oC.CountryDisplayName.Trim.ToLower.Contains("usa") Then
                    Me.divState.Visible = True
                Else
                    Me.divState.Visible = False
                End If
            Else
                Me.divState.Visible = False
            End If

            oC = New CommonLibrary.Country(oIU2.CountryID2)
            If Not IsNothing(oC) AndAlso oC.CountryDisplayName.Trim.Length > 0 Then
                Me.lblBusinessCountry.InnerHtml = oC.CountryDisplayName
                If oC.CountryDisplayName.Trim.ToLower.Contains("usa") Then
                    Me.divBusinessState.Visible = True
                Else
                    Me.divBusinessState.Visible = False
                End If
            Else
                Me.divBusinessState.Visible = False
            End If

            If oIU2.UserID <> CurrentUser.UserID Then
                phButtons.Visible = True
            Else
                phButtons.Visible = False
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim script As String = "function displayRequest_" & ClientID & "(){ " & vbLf & "modalDialog('" & ResolveUrl("~/CMSModules/Friends/CMSPages/Friends_Request.aspx") & "?userid=" & CurrentUser.UserID & "&requestid= " & UserID & "' ,'requestFriend', 480, 350); " & vbLf & "} " & vbLf
            hlAddFriend.Attributes.Add("onclick", "javascript:displayRequest_" & ClientID & "();")
            hlAddFriend.Style.Add("cursor", "pointer")
            hlAddFriend.Text = "Link me as an 'Orb'"
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
