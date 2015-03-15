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
Partial Class UIControls_Profile_IndividualType1View
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
        Dim oIU1 As New smt_IndividualUserType1
        oIU1.LoadByUserID(oU.UserID)
        If Not IsNothing(oIU1) AndAlso oIU1.IndividualUserType1ID > 0 Then
            Me.lblUserName.InnerHtml = oU.Username

            lblUnionverid.InnerHtml = oU.UnionVerseID
        
        'Me.lblUnionverid.Text = "Star" & oIU1.GroupTypeID & "PlanetI" & oIU1.IndividualUserType1ID

        Me.lblFullName.InnerHtml = oIU1.FirstName & " " & oIU1.LastName

        Dim oGT1 As New smt_UserType1(oIU1.GroupTypeID)
            Me.lblGroupType1.InnerHtml = oGT1.FullName

        Me.lblState.InnerHtml = oIU1.State
        Me.lblZipCode.InnerHtml = oIU1.ZipCode
        Me.lblEmployerName.InnerHtml = oIU1.EmployerName
        Me.lblCurrentPosition.InnerHtml = oIU1.CurrentPosition
        Me.lblGender.InnerHtml = oIU1.Gender

        Me.lblLevelOfEducation.InnerHtml = oIU1.LevelOfEducation
        Me.lblCollegeAttended.InnerHtml = oIU1.CollegeAttended
        Me.lblDegreeIn.InnerHtml = oIU1.DegreeIn
        Me.lblYearOfExperience.InnerHtml = oIU1.DegreeIn
        Me.lblCity.InnerHtml = oIU1.City
        Me.lblAddress.InnerHtml = (oIU1.Address1 & " " & oIU1.Address2).Replace("  ", " ").Trim


            Dim oC As New CommonLibrary.Country(oIU1.CountryID)
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
        End If
    End Sub

End Class
