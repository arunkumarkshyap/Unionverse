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


Partial Class UIControls_Profile_GroupType1View
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
        Dim oUT1 As New smt_UserType1
        oUT1.LoadByUserID(oU.UserID)
        phButtons.Visible = True
        If Not IsNothing(oUT1) AndAlso oUT1.UserType1ID > 0 Then
            Me.lblUserName.InnerHtml = oUT1.UserName.Trim
            Me.lblUnionverid.InnerHtml = oU.UnionVerseID
            Me.aSendUNI.HRef = UIHelper.GetWormWholesBasePathURL() & "/SpecialPages/SendUNI.aspx?UNIonVERSEID=" & oU.UnionVerseID
            Me.lblGroupType1Leader.InnerHtml = oUT1.LeaderUserName.Trim
            Me.lblGalaxy.InnerHtml = UIHelper.GetGalaxyName(oUT1.Galaxy)
            If oUT1.Galaxy = 8 Then
                Me.divFaith.Visible = True
                Me.lblFaith.InnerHtml = oUT1.Faith
            End If
            Me.lblSub.InnerHtml = oUT1.UserTypeType
            Me.lblWebsiteAddress.InnerHtml = oUT1.WebsiteAddress
            Me.lblAddress.InnerHtml = oUT1.Address1.Trim & " " & oUT1.Address2.Trim
            Me.lblState.InnerHtml = oUT1.State
            Me.lblZipCode.InnerHtml = oUT1.ZipCode
            Me.lblTelephoneNumber.InnerHtml = oUT1.PhoneNumber
            Me.lblAbout.InnerHtml = oUT1.About
            Me.lblCity.InnerHtml = oUT1.City
            Dim oC As New CommonLibrary.Country(oUT1.CountryID)
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
            If CurrentUser.UserID = oUT1.UserID Then
                Me.lblURL.InnerHtml = UIHelper.GetUnionVerseBasePathURL() & "/" & oUT1.UserName.Replace(" ", "_") & ".aspx"
                phButtons.Visible = False
            Else
                phButtons.Visible = True
            End If

            If CurrentUser.UserTypeID = CommonLibrary.Utility.eUserTypes.BusinessUser Then
                Me.phButtons.Visible = False
            Else
                Me.phButtons.Visible = True
            End If


        End If
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If CurrentUser.UserTypeID <> CommonLibrary.Utility.eUserTypes.IndividualType2 AndAlso CurrentUser.UserTypeID <> CommonLibrary.Utility.eUserTypes.UserType1 AndAlso CurrentUser.UserID <> UserID Then
                spnAddConnection.Visible = True
            Else
                spnAddConnection.Visible = False
            End If

            Dim script As String = "function displayRequest_" & ClientID & "(){ " & vbLf & "modalDialog('" & ResolveUrl("~/CMSModules/Friends/CMSPages/Friends_Request.aspx") & "?userid=" & CurrentUser.UserID & "&requestid= " & UserID & "' ,'requestFriend', 480, 350); " & vbLf & "} " & vbLf
            hlAddFriend.Attributes.Add("onclick", "javascript:displayRequest_" & ClientID & "();")
            hlAddFriend.Style.Add("cursor", "pointer")
            hlAddFriend.Text = "Add as Connection"
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
