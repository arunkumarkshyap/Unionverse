Imports Microsoft.VisualBasic
Imports AdminLibrary
Imports CMSLibrary
Imports System.Drawing
Imports System.Web.Configuration
Imports System.Globalization
Imports System.Security.Cryptography
Imports System.Web
Imports System.Globalization.CultureInfo
Imports System.Net
Imports System.IO
Imports System.Xml
Imports System.Xml.XPath
Imports System.Text
Imports System.Web.UI.WebControls
Imports System
Imports System.Configuration
Imports System.Xml.Linq
Imports System.Data
Imports System.Collections
Imports System.Text.RegularExpressions
Imports UserLibrary
Imports WormWholesLibrary
Imports CommonLibrary
Public Class UIHelper
    Public Shared PhoneNumberExpression As String = "^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$"
    Public Shared EmailExpression As String = "^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$"
    Public Shared IntgerExpression As String = "^(\d+(,\d+)*)?$"

    Public Shared Function IsUserOnline(ByVal UserID As Integer) As Boolean
        Dim oOnline As New OnlineUsers
        Return oOnline.IsOnline(UserID)
    End Function
    Public Shared Sub InviteUserAfterSaleOrbitB2I(ByVal BusinessUserID As Integer, ByVal IndividualUserID As Integer)
        If BusinessUserID > 0 AndAlso IndividualUserID > 0 Then
            Dim oBusiness As New Users(BusinessUserID)
            Dim oIndUser As New Users(IndividualUserID)

            Dim oFrienInfo As New UserLibrary.Friends()

            If oFrienInfo.IsFriendshipExist(BusinessUserID, IndividualUserID) = False AndAlso oFrienInfo.IsFriendshipExist(IndividualUserID, BusinessUserID) = False Then
                Dim objFriend As New Friends
                objFriend.FriendRequestedUserID = IndividualUserID
                objFriend.FriendUserID = BusinessUserID
                objFriend.FriendRequestedWhen = DateTime.Now
                objFriend.FriendGUID = Guid.NewGuid
                objFriend.FriendStatus = CommonLibrary.Utility.eFriendStatus.Pending
                objFriend.save()


                'Dim cmsEmail As New EmailInfo()
                'cmsEmail.EmailFrom = oBusiness.Username + "<" + oBusiness.Email & ">"
                'cmsEmail.EmailTo = oIndUser.Username + "<" + oIndUser.Email & ">"
                'cmsEmail.EmailSubject = oBusiness.Username + " wants to be Connection(Orbit B2I)"
                'cmsEmail.EmailBody = "<p>" + oBusiness.Username & " wants to be Connection(Orbit B2I)</p>" & "<p>To Accpet or Reject the Connection request please follow.</p><p><b><a href='" & SMTUIHelper.GetBasePathURL() & "/Special-pages/B2IManageFriends.aspx?FriendGUID=" & oFriend.FriendGUID.ToString() & "'>Accept / Reject</a></b><br /></p>"
                'cmsEmail.EmailFormat = EmailFormatEnum.Html
                'cmsEmail.EmailPriority = EmailPriorityEnum.Normal
                'cmsEmail.EmailSiteID = 1
                'cmsEmail.EmailStatus = EmailStatusEnum.Waiting


                Dim oM As New CommonLibrary.IMessages()
                oM.SenderUserID = oBusiness.UserID
                oM.SenderNickName = oBusiness.Username
                oM.RecipientUserID = oIndUser.UserID
                oM.RecipientNickName = oIndUser.Username
                oM.DateSent = DateTime.Now
                oM.LastModified = oM.DateSent
                oM.Subject = oBusiness.Username + " wants to be Connection(Orbit B2I)"
                oM.Body = oBusiness.Username + " wants to be Connection(Orbit B2I)" & vbLf & "<p>To Accpet or Reject the Connection request please follow.</p><p><b><a href='" & UIHelper.GetBasePath() & "/B2IManageFriends.aspx?FriendGUID=" & objFriend.FriendGUID.ToString() & "'>Accept / Reject</a></b><br /></p>"
                oM.save()

            End If
        End If
    End Sub
    Public Shared Sub InviteUserAfterUniTransfer(ByVal IndividualUser2ID As Integer, ByVal IndividualUser1ID As Integer)

        If IndividualUser2ID > 0 AndAlso IndividualUser1ID > 0 Then
            Dim oInd2 As New Users(IndividualUser2ID)
            Dim oInd1 As New Users(IndividualUser1ID)
            Dim oFriend As New Friends()

            If oFriend.IsFriendshipExist(IndividualUser2ID, IndividualUser1ID) = False AndAlso oFriend.IsFriendshipExist(IndividualUser1ID, IndividualUser2ID) = False Then
                oFriend.FriendStatus = CommonLibrary.Utility.eFriendStatus.Pending
                oFriend.FriendUserID = IndividualUser2ID
                oFriend.FriendRequestedUserID = IndividualUser1ID
                oFriend.FriendRequestedWhen = DateTime.Now
                oFriend.save()

                'Dim cmsEmail As New EmailInfo()
                'cmsEmail.EmailFrom = oInd2.Username + "<" + oInd2.Email & ">"
                'cmsEmail.EmailTo = oInd1.Username + "<" + oInd1.Email & ">"
                'cmsEmail.EmailSubject = oInd2.Username + " wants to be Connection(Orb I2I)"
                'cmsEmail.EmailBody = "<p>" + oInd2.Username & " wants to be Connection(Orb I2I)</p>" & "<p>To Accpet or Reject the Connection request please follow.</p><p><b><a href='" & SMTUIHelper.GetBasePathURL() & "/Special-pages/ManageFriends.aspx?FriendGUID=" & oFriend.FriendGUID.ToString() & "'>Accept / Reject</a></b><br /></p>"
                'cmsEmail.EmailFormat = EmailFormatEnum.Html
                'cmsEmail.EmailPriority = EmailPriorityEnum.Normal
                'cmsEmail.EmailSiteID = 1
                'cmsEmail.EmailStatus = EmailStatusEnum.Waiting
                'EmailInfoProvider.SetEmailInfo(cmsEmail)

                Dim oM As New IMessages()
                oM.SenderUserID = oInd2.UserID
                oM.SenderNickName = oInd2.Username
                oM.RecipientUserID = oInd1.UserID
                oM.RecipientNickName = oInd1.Username
                oM.DateSent = DateTime.Now
                oM.LastModified = oM.DateSent
                oM.Subject = oInd2.Username + " wants to be Connection(Orb I2I)"
                oM.Body = oInd2.Username + " wants to be Connection(Orb I2I)" & vbLf & "<p>To Accpet or Reject the Connection request please follow.</p><p><b><a href='" & UIHelper.GetBasePath() & "/ManageFriends.aspx?FriendGUID=" & oFriend.FriendGUID.ToString() & "'>Accept / Reject</a></b><br /></p>"
                oM.save()
                'CMS.Messaging.MessageInfoProvider.SetMessageInfo(oM)
            End If
        End If
    End Sub
    Public Shared Sub SendEmailToUser(ByVal SenderUserID As Integer, ByVal RecipientUserID As Integer, ByVal mSubject As String, ByVal mBody As String)
        If SenderUserID > 0 AndAlso RecipientUserID > 0 Then
            Dim oSender As New Users(SenderUserID)
            Dim oRecipient As New Users(RecipientUserID)
            'oSender = UserInfoProvider.GetUserInfo()
            'oRecipient = UserInfoProvider.GetUserInfo()

            'EmailInfo cmsEmail = new EmailInfo();
            'cmsEmail.EmailFrom = oBusiness.UserName + "<" + oBusiness.Email + ">";
            'cmsEmail.EmailTo = oIndUser.UserName + "<" + oIndUser.Email + ">";
            'cmsEmail.EmailSubject = mSubject;
            'cmsEmail.EmailBody = mBody;
            'cmsEmail.EmailFormat = EmailFormatEnum.Html;
            'cmsEmail.EmailPriority = EmailPriorityEnum.Normal;
            'cmsEmail.EmailSiteID = 1;
            'cmsEmail.EmailStatus = EmailStatusEnum.Waiting;
            'EmailInfoProvider.SetEmailInfo(cmsEmail);

            Dim oM As New IMessages()
            If Not IsNothing(oSender) AndAlso oSender.UserID > 0 Then
                oM.SenderUserID = oSender.UserID
                oM.SenderNickName = oSender.Username
            End If
            If Not IsNothing(oRecipient) AndAlso oRecipient.UserID > 0 Then
                oM.RecipientUserID = oRecipient.UserID
                oM.RecipientNickName = oRecipient.Username
            End If

            oM.DateSent = DateTime.Now
            oM.LastModified = oM.DateSent
            oM.Subject = mSubject
            oM.Body = mBody
            oM.save()
            'CMS.Messaging.MessageInfoProvider.SetMessageInfo(oM)

            'CMS.Messaging.MessageInfoProvider.SendNotificationEmail(oM, oRecipient, oSender, CMSContext.CurrentSite.SiteName)
        End If
    End Sub

    Public Shared Function GetUserImage(ByVal UserID As Integer) As String
        Dim oU As New UserLibrary.Users(UserID)
        If oU.ProfileImage.Trim.Length > 0 Then
            Return UIHelper.GetUnionVerseBasePathURL & "/" & oU.ProfileImage.Trim
        Else
            Return UIHelper.GetUnionVerseBasePathURL & "/UserFiles/Profiles/Profile-Pic-Man.png"
        End If
    End Function

    Public Shared Function GetGalaxyName(ByVal GalaxyID As Integer) As String
        Select Case GalaxyID
            Case 1
                Return "Baha'i Faith"
                Exit Select
            Case 2
                Return "Buddhism"
                Exit Select
            Case 3
                Return "Christianity"
                Exit Select
            Case 4
                Return "Hinduism"
                Exit Select
            Case 5
                Return "Islam"
                Exit Select
            Case 6
                Return "Jainism"
                Exit Select
            Case 7
                Return "Judaism"
                Exit Select
            Case 8
                Return "Other Galaxies"
                Exit Select
            Case 9
                Return "Sikhism"
                Exit Select
            Case Else
                Return ""
                Exit Select
        End Select
    End Function
    Public Enum eSEOLinks
        home
        stellar_living
        Todays_Listings
        Bulding_Pages
        Neighborhoods
        Neighborhood_Page
        Company
        Company_Residential
        Company_Commercial
        Company_Capabilities
        Company_Team
        Company_History
        Company_Vision
        Company_Careers
        Company_News
        Search_MapView
        RentalGuide_ViewAListing
        RentalGuide_IncomeRequirements
        RentalGuide_CoSignerRequirements
        RentalGuide_SecurityDeposit
        RentalGuide_ApplicationTimeline
        RentalGuide_RequiredDocuments
        RentalGuide_LeaseSignedPaymentOptions
        ApplyNow
        ResidentLogin
        Blog
    End Enum
    Public Shared Function GetSEOLink(ByVal _LinkID As Integer, ByVal str As String) As String
        Dim _Link As String = ""
        _Link = UIHelper.GetBasePath & "/no-fee-NYC-rentals"

        Select Case _LinkID
            Case eSEOLinks.home
                _Link = _Link & "/index"
            Case eSEOLinks.stellar_living
                _Link = _Link & "/new-york-city-living"
            Case eSEOLinks.Todays_Listings
                _Link = _Link & "/no-fee-rental-apartment-listings"
            Case eSEOLinks.Bulding_Pages
                _Link = _Link & "/new-york-city-neighborhoods/@Neighborhood@-rental-apartment-listings-@building name@"
            Case eSEOLinks.Neighborhoods
                _Link = _Link & "/new-york-city-Neighborhoods"
            Case eSEOLinks.Neighborhood_Page
                _Link = _Link & "/new-york-city-neighborhoods/@neighborhood@-rental-apartment-listings"
            Case eSEOLinks.Company
                _Link = _Link & "/real-estate-developer/company"
            Case eSEOLinks.Company_Residential
                _Link = _Link & "/real-estate-developer/residential-apartments"
            Case eSEOLinks.Company_Commercial
                _Link = _Link & "/real-estate-developer/commercial-properties"
            Case eSEOLinks.Company_Capabilities
                _Link = _Link & "/real-estate-developer/capabilities"
            Case eSEOLinks.Company_Team
                _Link = _Link & "/real-estate-developer/team"
            Case eSEOLinks.Company_History
                _Link = _Link & "/real-estate-developer/history"
            Case eSEOLinks.Company_Vision
                _Link = _Link & "/real-estate-developer/vision"
            Case eSEOLinks.Company_Careers
                _Link = _Link & "/real-estate-developer/careers"
            Case eSEOLinks.Company_News
                _Link = _Link & "/real-estate-developer/news"
            Case eSEOLinks.Search_MapView
                _Link = _Link & "/no-fee-rental-apartment-listings"
            Case eSEOLinks.RentalGuide_ViewAListing
                _Link = _Link & "/rental-guide/view-listing"
            Case eSEOLinks.RentalGuide_IncomeRequirements
                _Link = _Link & "/rental-guide/income-requirements"
            Case eSEOLinks.RentalGuide_CoSignerRequirements
                _Link = _Link & "/rental-guide/cosign"
            Case eSEOLinks.RentalGuide_SecurityDeposit
                _Link = _Link & "/rental-guide/security-deposit"
            Case eSEOLinks.RentalGuide_ApplicationTimeline
                _Link = _Link & "/rental-guide/application-timeline"
            Case eSEOLinks.RentalGuide_RequiredDocuments
                _Link = _Link & "/rental-guide/required-docs"
            Case eSEOLinks.RentalGuide_LeaseSignedPaymentOptions
                _Link = _Link & "/rental-guide/lease-signing"
            Case eSEOLinks.ApplyNow
                _Link = _Link & "/apply-now"
            Case eSEOLinks.ResidentLogin
                _Link = _Link & "/resident-login"
            Case eSEOLinks.Blog
                _Link = _Link & "/stellar-living-blog"
        End Select
        Return _Link
    End Function

    Enum eAmmenityType
        Commpany = 1
        Floorplan = 2
        General = 3
    End Enum
    Public Shared Function GetRandomRotator(ByVal SnippetRotatorID As Integer) As String
        Dim Arl As New ArrayList
        Dim oS As New Sinippts
        oS.SortColum = " newid() "
        oS.SortDirection = " asc "
        Arl = oS.SinipptsGetByFilters(0, "", "", SnippetRotatorID)
        Dim osnp As New Sinippts()
        osnp = CType(Arl(0), Sinippts)

        Dim imgPath As String = ""

        If Not IsNothing(osnp.Sinippt) AndAlso osnp.Sinippt.Trim.Length > 0 Then
            If osnp.Sinippt.ToLower.Contains("img") Then
                Dim m As MatchCollection = Regex.Matches(osnp.Sinippt.ToString, "src\s*=\s*['""](?<src>[^'""]*)['""]")

                imgPath = m.Item(0).ToString
                imgPath = imgPath.ToLower.Replace("src=", "").Replace("""", "")
                imgPath = UIHelper.GetBasePath() & imgPath

            End If
        End If
        imgPath = ""
        If imgPath.Trim.Length <= 0 Then
            imgPath = UIHelper.GetBasePath() & "/images/hm1/slide1bg1.jpg"
        End If
        Return imgPath

    End Function
    Public Shared Sub LoadCountry(ByVal ddl As DropDownList, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        ddl.DataSource = CommonLibrary.CountryData.CountryGetAll()
        ddl.DataTextField = "CountryDisplayName"
        ddl.DataValueField = "CountryID"
        ddl.DataBind()
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, 0))
        End If
    End Sub
    Public Shared Sub LoadStatesByCountry(ByVal ddl As DropDownList, Optional ByVal indexItem As String = "", Optional ByVal CountryID As Integer = 0)
        ddl.Items.Clear()
        ddl.DataSource = CommonLibrary.StatesData.StatesGetByCountryID(CountryID)
        ddl.DataTextField = "StateDisplayName"
        ddl.DataValueField = "StateID"
        ddl.DataBind()
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, 0))
        End If
    End Sub
    Public Sub LoadAdRoleID(ByVal ddl As DropDownList, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        ddl.DataSource = AdRolesData.AdRolesGetAll
        ddl.DataTextField = "AdRole"
        ddl.DataValueField = "AdRoleID"
        ddl.DataBind()
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, 0))
        End If
    End Sub
    Public Shared Function HTMLRemoveStyle(ByVal str As String) As String

        str = System.Text.RegularExpressions.Regex.Replace(str.Replace("&lt;", "<").Replace("&gt;", ">"), "<([^>]*)(?:class|lang|style|size|face|[ovwxp]:\w+)=(?:'[^']*'|""[^""]*""|[^\s>]+)([^>]*)>", "<$1$2>").Replace(Chr(13), "")
        str = System.Text.RegularExpressions.Regex.Replace(str.Replace("&lt;", "<").Replace("&gt;", ">"), "<([^>]*)(?:class|lang|style|size|face|[ovwxp]:\w+)=(?:'[^']*'|""[^""]*""|[^\s>]+)([^>]*)>", "<$1$2>").Replace(Chr(13), "")
        str = System.Text.RegularExpressions.Regex.Replace(str.Replace("&lt;", "<").Replace("&gt;", ">"), "<([^>]*)(?:class|lang|style|size|face|[ovwxp]:\w+)=(?:'[^']*'|""[^""]*""|[^\s>]+)([^>]*)>", "<$1$2>").Replace(Chr(13), "")
        str = System.Text.RegularExpressions.Regex.Replace(str.Replace("&lt;", "<").Replace("&gt;", ">"), "<([^>]*)(?:class|lang|style|size|face|[ovwxp]:\w+)=(?:'[^']*'|""[^""]*""|[^\s>]+)([^>]*)>", "<$1$2>").Replace(Chr(13), "")

        Return str
    End Function
    Public Shared Function RemoveHTML(ByVal str As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(str.Replace("&lt;", "<").Replace("&gt;", ">"), "<[^>]*>", String.Empty).Replace(Chr(13), "")
    End Function
    Public Sub LoadPageContentsDropDown(ByVal ddl As DropDownList, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        Dim oPC As New PageContent
        ddl.DataSource = oPC.PageContentGetAll()
        ddl.DataTextField = "PageName"
        ddl.DataValueField = "PageCode"
        ddl.DataBind()
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, 0))
        End If
    End Sub

    Public Sub LoadMenusDropDown(ByVal ddl As DropDownList, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        Dim oM As New CMSLibrary.Menu
        ddl.DataSource = oM.MenuGetAll()
        ddl.DataTextField = "menuName"
        ddl.DataValueField = "MenuID"
        ddl.DataBind()
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, 0))
        End If
    End Sub

    Public Sub LoadMenusPlaceHolder(ByVal ddl As DropDownList, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        Dim oM As New CMSLibrary.Menu
        ddl.DataSource = oM.MenuPlaceHoldersGetAll()
        ddl.DataTextField = "PlaceHolderName"
        ddl.DataValueField = "PlaceHolderCode"
        ddl.DataBind()
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, 0))
        End If
    End Sub

    Public Shared Sub LoadMonths(ByVal ddl As DropDownList, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        ddl.Items.Add(New ListItem("Jan", 1))
        ddl.Items.Add(New ListItem("Feb", 2))
        ddl.Items.Add(New ListItem("Mar", 3))
        ddl.Items.Add(New ListItem("Apr", 4))
        ddl.Items.Add(New ListItem("May", 5))
        ddl.Items.Add(New ListItem("Jun", 6))
        ddl.Items.Add(New ListItem("Jul", 7))
        ddl.Items.Add(New ListItem("Aug", 8))
        ddl.Items.Add(New ListItem("Sep", 9))
        ddl.Items.Add(New ListItem("Oct", 10))
        ddl.Items.Add(New ListItem("Nov", 11))
        ddl.Items.Add(New ListItem("Dec", 12))
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, 0))
        End If
    End Sub
    Public Shared Sub LoadYears(ByVal ddl As DropDownList, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        ddl.Items.Add(New ListItem(Date.Now.Year, Date.Now.Year))
        ddl.Items.Add(New ListItem(Date.Now.AddYears(1).Year, Date.Now.AddYears(1).Year))
        ddl.Items.Add(New ListItem(Date.Now.AddYears(2).Year, Date.Now.AddYears(2).Year))
        ddl.Items.Add(New ListItem(Date.Now.AddYears(3).Year, Date.Now.AddYears(3).Year))
        ddl.Items.Add(New ListItem(Date.Now.AddYears(4).Year, Date.Now.AddYears(4).Year))
        ddl.Items.Add(New ListItem(Date.Now.AddYears(5).Year, Date.Now.AddYears(5).Year))
        ddl.Items.Add(New ListItem(Date.Now.AddYears(6).Year, Date.Now.AddYears(6).Year))
        ddl.Items.Add(New ListItem(Date.Now.AddYears(7).Year, Date.Now.AddYears(7).Year))
        ddl.Items.Add(New ListItem(Date.Now.AddYears(8).Year, Date.Now.AddYears(8).Year))
        ddl.Items.Add(New ListItem(Date.Now.AddYears(9).Year, Date.Now.AddYears(9).Year))
        ddl.Items.Add(New ListItem(Date.Now.AddYears(10).Year, Date.Now.AddYears(10).Year))
        ddl.Items.Add(New ListItem(Date.Now.AddYears(11).Year, Date.Now.AddYears(11).Year))
        ddl.Items.Add(New ListItem(Date.Now.AddYears(12).Year, Date.Now.AddYears(12).Year))
        ddl.Items.Add(New ListItem(Date.Now.AddYears(13).Year, Date.Now.AddYears(13).Year))
        ddl.Items.Add(New ListItem(Date.Now.AddYears(14).Year, Date.Now.AddYears(14).Year))
        ddl.Items.Add(New ListItem(Date.Now.AddYears(15).Year, Date.Now.AddYears(15).Year))

        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, 0))
        End If
    End Sub


    ' --------------------------------------------------------------------
    ' InvokePopupCal - Accepts a target field ID as a paramter and returns
    ' a string formatted with a javascript call to invoke the Popup calendar.
    ' --------------------------------------------------------------------
    Public Shared Function GetUnionVerseBasePathURL() As String
        Dim basePath As String = ""
        basePath = CMSLibrary.Utility.GetSiteConfigrationValue("UnionVerseBasePath")
        If basePath.Trim.Length > 0 Then
            Return CMSLibrary.Utility.GetSiteConfigrationValue("UnionVerseBasePath")
        Else
            Return ".."
        End If
    End Function
    Public Shared Function GetWhiteWholesPathURL() As String
        Dim basePath As String = ""
        basePath = CMSLibrary.Utility.GetSiteConfigrationValue("WhiteWholesBasePath")
        If basePath.Trim.Length > 0 Then
            Return CMSLibrary.Utility.GetSiteConfigrationValue("WhiteWholesBasePath")
        Else
            Return ".."
        End If
    End Function
    Public Shared Function GetWormWholesBasePathURL() As String
        Dim basePath As String = ""
        basePath = CMSLibrary.Utility.GetSiteConfigrationValue("WormWholesBasePath")
        If basePath.Trim.Length > 0 Then
            Return CMSLibrary.Utility.GetSiteConfigrationValue("WormWholesBasePath")
        Else
            Return ".."
        End If
    End Function
    Public Shared Function GetBlackWholesBasePathURL() As String
        Dim basePath As String = ""
        basePath = CMSLibrary.Utility.GetSiteConfigrationValue("BlackWholesBasePath")
        If basePath.Trim.Length > 0 Then
            Return CMSLibrary.Utility.GetSiteConfigrationValue("BlackWholesBasePath")
        Else
            Return ".."
        End If
    End Function

    Public Shared Function GetFleetPortsBasePathURL() As String
        Dim basePath As String = ""
        basePath = CMSLibrary.Utility.GetSiteConfigrationValue("FleetPortsBasePath")
        If basePath.Trim.Length > 0 Then
            Return CMSLibrary.Utility.GetSiteConfigrationValue("FleetPortsBasePath")
        Else
            Return ".."
        End If
    End Function
    Public Shared Function GetUVEnterpriseBasePathURL() As String
        Dim basePath As String = ""
        basePath = CMSLibrary.Utility.GetSiteConfigrationValue("UVEnterpriseBasePath")
        If basePath.Trim.Length > 0 Then
            Return CMSLibrary.Utility.GetSiteConfigrationValue("UVEnterpriseBasePath")
        Else
            Return ".."
        End If
    End Function
    Public Shared Function GetUVScreenBasePathURL() As String
        Dim basePath As String = ""
        basePath = CMSLibrary.Utility.GetSiteConfigrationValue("UVScreenBasePath")
        If basePath.Trim.Length > 0 Then
            Return CMSLibrary.Utility.GetSiteConfigrationValue("UVScreenBasePath")
        Else
            Return ".."
        End If
    End Function

    Public Shared Function GetBasePath() As String
        Dim basePath As String = ""
        basePath = CMSLibrary.Utility.GetSiteConfigrationValue("HostPath")
        If basePath.Trim.Length > 0 Then
            Return CMSLibrary.Utility.GetSiteConfigrationValue("HostPath")
        Else
            Return ".."
        End If
    End Function

    Public Shared Function AssetsBasePath() As String
        Dim basePath As String = ""
        basePath = CMSLibrary.Utility.GetSiteConfigrationValue("AssetsBasePath")
        If basePath.Trim.Length <= 0 Then
            Return CMSLibrary.Utility.GetSiteConfigrationValue("HostPath") & "/Assets"
        Else
            Return basePath
        End If
    End Function
    Public Shared Function GetAppSetting(ByVal key As String) As String
        Return CMSLibrary.Utility.GetSiteConfigrationValue(key)
    End Function
    Public Sub LoadActiveInActive(ByVal ddl As DropDownList, Optional ByVal indexItem As String = "")
        ddl.Items.Add(New ListItem("Active", "1"))
        ddl.Items.Add(New ListItem("In-Active", "0"))
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
    End Sub



    Public Shared Function GetDescription(ByVal Desc As String) As String
        Dim str As String = Desc
        If str.Trim.Length > 100 Then
            str = str.Substring(0, 100) & "..."
            Return str
        Else
            Return str
        End If
    End Function
    Public Shared Function isValidEmail(ByVal inputEmail As String) As Boolean

        'Dim strRegex As String = "^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" & _
        '      "\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" & _
        '      ".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"


        Dim strRegex As String = "^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"

        Dim re As RegularExpressions.Regex = New RegularExpressions.Regex(strRegex)
        If re.IsMatch(inputEmail) Then
            If inputEmail.Substring(0, inputEmail.IndexOf("@")).Length < 3 Then
                Return False
            End If
            If inputEmail.Substring(inputEmail.IndexOf("@") + 1, inputEmail.LastIndexOf(".") - (inputEmail.IndexOf("@") + 1)).Length < 3 Then
                Return False
            End If
            Return True
        Else
            Return False
        End If
        Return False
    End Function

    Public Sub LoadYesNo(ByVal ddl As DropDownList, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        ddl.Items.Add(New ListItem("Yes", "1"))
        ddl.Items.Add(New ListItem("No", "0"))
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
    End Sub
    Public Sub LoadTitle(ByVal ddl As DropDownList, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        ddl.Items.Add(New ListItem("Mr", "1"))
        ddl.Items.Add(New ListItem("Miss", "2"))
        ddl.Items.Add(New ListItem("Dr", "3"))
        ddl.Items.Add(New ListItem("Mrs", "4"))
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, 0))
        End If
    End Sub


    Public Sub LoadDigits(ByVal ddl As DropDownList, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        Dim temp As String = "10,9,8,7,6,5,4,3,2,1"
        Dim Al() As String
        Al = temp.Split(",")
        Dim c As String
        For Each c In Al
            ddl.Items.Insert(0, New ListItem(c, c))
        Next
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, ""))
        End If
    End Sub
    Public Sub LoadContactType(ByVal ddl As DropDownList, Optional ByVal indexItem As String = "")
        'ddl.Items.Clear()
        'ddl.DataSource = CategoriesData.GetCategoryIDNameExceptThis(CategoryID)
        'ddl.DataTextField = "CategoryName"
        'ddl.DataValueField = "CategoryID"
        'ddl.DataBind()
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, 0))
        End If
    End Sub

    Public Function CreateThumbNail(ByVal postedFile As Bitmap, ByVal width As Integer, ByVal height As Integer) As Bitmap
        Dim bmpOut As System.Drawing.Bitmap
        Dim Format As Imaging.ImageFormat = postedFile.RawFormat
        Dim Ratio As Decimal
        Dim NewWidth As Integer
        Dim NewHeight As Integer

        '*** If the image is smaller than a thumbnail just return it
        If postedFile.Width < width AndAlso postedFile.Height < height Then
            Return postedFile
        End If

        If (postedFile.Width > postedFile.Height) Then
            Ratio = Convert.ToDecimal(width / postedFile.Width)
            NewWidth = width

            Dim Temp As Decimal = postedFile.Height * Ratio
            NewHeight = Convert.ToInt32(Temp)
        Else
            Ratio = Convert.ToDecimal(height / postedFile.Height)
            NewHeight = height

            Dim Temp As Decimal = postedFile.Width * Ratio
            NewWidth = Convert.ToInt32(Temp)
        End If

        bmpOut = New Bitmap(NewWidth, NewHeight)

        Dim g As Graphics = Graphics.FromImage(bmpOut)
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        g.FillRectangle(Brushes.White, 0, 0, NewWidth, NewHeight)
        g.DrawImage(postedFile, 0, 0, NewWidth, NewHeight)

        postedFile.Dispose()

        Return bmpOut
    End Function
    Public Function CreateThumbNailWhiteBack(ByVal postedFile As Bitmap, ByVal width As Integer, ByVal height As Integer) As Bitmap
        Dim bmpOut As System.Drawing.Bitmap
        Dim Format As Imaging.ImageFormat = postedFile.RawFormat
        Dim Ratio As Decimal
        Dim NewWidth As Integer
        Dim NewHeight As Integer
        Dim Left As Integer = 0
        Dim Top As Integer = 0

        If postedFile.Width > 0 Then
            Ratio = postedFile.Height / postedFile.Width
        End If
        If postedFile.Width < width AndAlso postedFile.Height < height Then
            NewWidth = postedFile.Width
            NewHeight = postedFile.Height
        ElseIf postedFile.Width >= postedFile.Height Then
            NewWidth = width
            NewHeight = CInt(Ratio * width)
            If NewHeight > height Then
                NewHeight = height
                NewWidth = CInt(height / Ratio)
            End If
        ElseIf postedFile.Height > postedFile.Width Then
            NewHeight = height
            NewWidth = CInt(height / Ratio)
            If NewWidth > width Then
                NewWidth = width
                NewHeight = CInt(Ratio * width)
            End If
        End If
        If NewWidth < width Then
            Left = CInt((width - NewWidth) / 2)
        End If
        If NewHeight < height Then
            Top = CInt((height - NewHeight) / 2)
        End If
        bmpOut = New Bitmap(width, height)
        Dim g As Graphics = Graphics.FromImage(bmpOut)
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        g.FillRectangle(Brushes.White, 0, 0, width, height)
        Dim rec As New Rectangle
        rec.X = Left
        rec.Y = Top
        rec.Width = NewWidth
        rec.Height = NewHeight
        g.DrawImage(postedFile, rec) 'Left, Top, NewWidth, NewHeight)
        postedFile.Dispose()
        Return bmpOut
    End Function
    Public Shared Function InvokePopupCal(ByVal Field As System.Web.UI.WebControls.TextBox) As String
        Try
            ' Define character array to trim from language strings
            Dim TrimChars As Char() = {","c, " "c}

            ' Get culture array of month names and convert to string for
            ' passing to the popup calendar
            Dim MonthNameString As String = ""
            Dim Month As String
            For Each Month In DateTimeFormatInfo.CurrentInfo.MonthNames
                MonthNameString += Month & ","
            Next
            MonthNameString = MonthNameString.TrimEnd(TrimChars)

            ' Get culture array of day names and convert to string for
            ' passing to the popup calendar
            Dim DayNameString As String = ""
            Dim Day As String
            For Each Day In DateTimeFormatInfo.CurrentInfo.DayNames
                DayNameString += Day.Substring(0, 3) & ","
            Next
            DayNameString = DayNameString.TrimEnd(TrimChars)

            ' Get the short date pattern for the culture
            Dim FormatString As String = DateTimeFormatInfo.CurrentInfo.ShortDatePattern.ToString
            Return "javascript:popupCal('Cal','" & Field.ClientID & "','" & FormatString & "','" & MonthNameString & "','" & DayNameString & "');"
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Public Shared Function GetWebSiteSettingKey(ByVal SettingCode As String) As String
    '    Dim dr As Data.DataRow = WebsiteSettingData.WebsiteSettingByGetBySettingCode(SettingCode)
    '    Dim oWS As New WebsiteSetting(dr)
    '    Return oWS.SettingValue
    'End Function
    Public Shared Function RemoveHTMLTags(ByVal str As String) As String
        Dim ss1 As String = System.Text.RegularExpressions.Regex.Replace(str.Replace("&lt;", "<").Replace("&gt;", ">"), "<(?!(?:!))[^>]*>", String.Empty).Replace(Chr(13), "").Replace(vbLf, "").Replace("  ", " ").Replace("&bull;", "<li>").Replace("&nbsp;", " ").Replace("&amp;bull;", "").Replace("&amp;nbsp;", " ").Replace("<strong>", "").Replace("</strong>", "").Replace("&quot;", "'").Replace("www", "").Replace("http", "").Replace("<br />", "").Replace("<br/>", "").Replace("<br>", "").Replace("&amp;", "&")
        'ss1 = System.Text.RegularExpressions.Regex.Replace(ss1.Replace("&lt;", "<").Replace("&gt;", ">"), "<([^>]*)(?:class|lang|style|size|face|[ovwxp]:\w+)=(?:'[^']*'|""[^""]*""|[^\s>]+)([^>]*)>", String.Empty)
        ss1 = System.Text.RegularExpressions.Regex.Replace(ss1, "<([^>]*)(?:class|lang|style|size|face|[ovwxp]:\w+)=(?:'[^']*'|""[^""]*""|[^\s>]+)([^>]*)>", "<$1$2>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        ss1 = System.Text.RegularExpressions.Regex.Replace(ss1, "<([^>]*)(?:class|lang|style|size|face|[ovwxp]:\w+)=(?:'[^']*'|""[^""]*""|[^\s>]+)([^>]*)>", "<$1$2>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        Return ss1
    End Function

    Public Shared Function TrimKeywodsGrammer(ByVal input As String) As String
        Dim result As String = ""
        result = input
        result = result.ToLower.Replace(" i ", "")
        result = result.ToLower.Replace(" is ", "")
        result = result.ToLower.Replace(" are ", "")
        result = result.ToLower.Replace(" am ", "")
        result = result.ToLower.Replace(" this ", "")
        result = result.ToLower.Replace(" that ", "")
        result = result.ToLower.Replace(" those ", "")
        result = result.ToLower.Replace(" there ", "")
        result = result.ToLower.Replace(" them ", "")
        result = result.ToLower.Replace(" we ", "")
        result = result.ToLower.Replace(" he ", "")
        result = result.ToLower.Replace(" she ", "")
        result = result.ToLower.Replace(" it ", "")
        result = result.ToLower.Replace(" through ", "")
        result = result.ToLower.Replace(" though ", "")
        result = result.ToLower.Replace(" throw ", "")
        result = result.ToLower.Replace(" involve ", "")
        result = result.ToLower.Replace(" him ", "")
        result = result.ToLower.Replace(" her ", "")
        result = result.ToLower.Replace(" here ", "")
        result = result.ToLower.Replace(" have ", "")
        result = result.ToLower.Replace(" a ", "")
        result = result.ToLower.Replace(" as ", "")
        result = result.ToLower.Replace(" because ", "")
        result = result.ToLower.Replace(" things ", "")
        result = result.ToLower.Replace(" were ", "")
        result = result.ToLower.Replace(" was ", "")
        result = result.ToLower.Replace(" will ", "")
        result = result.ToLower.Replace(" shall ", "")
        result = result.ToLower.Replace(" especially ", "")
        result = result.ToLower.Replace(" they'er ", "")
        result = result.ToLower.Replace(" they ", "")

        result = result.ToLower.Replace(" going ", "")
        result = result.ToLower.Replace(" go ", "")
        result = result.ToLower.Replace(" gone ", "")
        result = result.ToLower.Replace(" has ", "")
        result = result.ToLower.Replace(" have ", "")
        result = result.ToLower.Replace(" had ", "")
        result = result.ToLower.Replace(" get ", "")
        result = result.ToLower.Replace(" push ", "")
        result = result.ToLower.Replace(" pull ", "")
        result = result.ToLower.Replace(" to ", "")

        result = result.ToLower.Replace(" now ", "")
        result = result.ToLower.Replace(" right ", "")
        result = result.ToLower.Replace(" left ", "")
        result = result.ToLower.Replace(" at ", "")
        result = result.ToLower.Replace(" on ", "")
        result = result.ToLower.Replace(" in ", "")
        result = result.ToLower.Replace(" gets ", "")
        result = result.ToLower.Replace(" looks ", "")
        result = result.ToLower.Replace(" look ", "")
        result = result.ToLower.Replace(" liked ", "")
        result = result.ToLower.Replace(" like ", "")
        result = result.ToLower.Replace(" live ", "")
        result = result.ToLower.Replace(" leaves ", "")
        result = result.ToLower.Replace(" instead ", "")
        result = result.ToLower.Replace(" understand ", "")
        result = result.ToLower.Replace(" understood ", "")
        result = result.ToLower.Replace(" best ", "")
        result = result.ToLower.Replace(" good ", "")
        result = result.ToLower.Replace(" better ", "")
        result = result.ToLower.Replace(" full ", "")
        result = result.ToLower.Replace(" fill ", "")
        result = result.ToLower.Replace(" over ", "")
        result = result.ToLower.Replace(" under ", "")
        result = result.ToLower.Replace(" offers ", "")
        result = result.ToLower.Replace(" match ", "")
        result = result.ToLower.Replace(" matched ", "")
        result = result.ToLower.Replace(" matching ", "")
        result = result.ToLower.Replace(" update ", "")
        result = result.ToLower.Replace(" updates ", "")
        result = result.ToLower.Replace(" updated ", "")
        result = result.ToLower.Replace(" available ", "")
        result = result.ToLower.Replace(" moved ", "")
        result = result.ToLower.Replace(" move ", "")
        result = result.ToLower.Replace(" stop ", "")
        result = result.ToLower.Replace(" stoper ", "")
        result = result.ToLower.Replace(" stopped ", "")
        result = result.ToLower.Replace(" stops ", "")

        result = result.ToLower.Replace(" fall ", "")
        result = result.ToLower.Replace(" felt ", "")
        result = result.ToLower.Replace(" fallen ", "")

        result = result.ToLower.Replace(" come ", "")
        result = result.ToLower.Replace(" came ", "")
        result = result.ToLower.Replace(" can ", "")

        result = result.ToLower.Replace(" do ", "")
        result = result.ToLower.Replace(" does ", "")

        result = result.ToLower.Replace(" want ", "")
        result = result.ToLower.Replace(" went ", "")
        result = result.ToLower.Replace(" gone ", "")


        result = result.ToLower.Replace(" and ", "")
        result = result.ToLower.Replace(" or ", "")
        result = result.ToLower.Replace(" day ", "")
        result = result.ToLower.Replace(" per ", "")
        result = result.ToLower.Replace(" month ", "")
        result = result.ToLower.Replace(" months ", "")
        result = result.ToLower.Replace(" year ", "")
        result = result.ToLower.Replace(" years ", "")
        result = result.ToLower.Replace(" day ", "")
        result = result.ToLower.Replace(" days ", "")
        result = result.ToLower.Replace(" human ", "")
        result = result.ToLower.Replace(" animal ", "")
        result = result.ToLower.Replace(" humans ", "")
        result = result.ToLower.Replace(" animals ", "")
        result = result.ToLower.Replace(" flip ", "")
        result = result.ToLower.Replace(" flop ", "")

        result = result.ToLower.Replace(" next ", "")
        result = result.ToLower.Replace(" previous ", "")

        result = result.ToLower.Replace(" old ", "")
        result = result.ToLower.Replace(" new ", "")

        result = result.ToLower.Replace(" human ", "")
        result = result.ToLower.Replace(" animal ", "")

        result = result.ToLower.Replace("  ", " ")
        result = result.ToLower.Replace("  ", " ")
        result = result.ToLower.Replace("  ", " ")
        result = result.ToLower.Replace("  ", " ")

        result = result.ToLower.Replace(" ", ",")

        Return result
    End Function
    Public Shared Function trimtext(ByVal text As String, ByVal noChar As Integer) As String
        If Not IsNothing(text) AndAlso text.Length > 0 Then
            If text.Length > noChar Then
                Return text.Substring(0, noChar) & "..."
            Else
                Return text
            End If
        Else
            Return ""
        End If
    End Function
    Public Shared Function MakeSEOName(ByVal str As String) As String
        str = str.Trim
        str = str.Replace(" ", "-")
        str = str.Replace(":", "_colon_")
        str = str.Replace(" & ", "_and_")
        str = str.Replace("'", "quote")
        str = str.Replace("""", "double")
        str = str.Replace(")", "closeparen")
        str = str.Replace("#", "nosign")
        str = str.Replace(".", "dot")
        str = str.Replace("%", "percentage")
        str = str.Replace("$", "dollar")
        str = str.Replace("/", "fslash")
        str = str.Replace("\", "bslash")
        str = str.Replace("!", "excla")
        str = str.Replace("?", "qmark")
        str = str.Replace(",", "comma")
        str = str.Replace("<br/>", "break")
        str = str.Replace("<br />", "break")
        str = str.Replace("<br>", "break")

        Dim Appl As System.Web.HttpApplication = CType(New System.Web.HttpApplication, System.Web.HttpApplication)
        str = System.Web.HttpUtility.UrlEncode(str)
        str = str.Replace("%", "-peeen-")
        Return str

    End Function
    Public Sub LoadNoofHours(ByVal ddl As DropDownList, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        Dim temp As String = "23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,0"
        Dim Al() As String
        Al = temp.Split(",")
        Dim c As String
        For Each c In Al
            If c <= 9 Then
                ddl.Items.Insert(0, New ListItem("0" + c, c))
            Else
                ddl.Items.Insert(0, New ListItem(c, c))
            End If
        Next
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, ""))
        End If
    End Sub

    Public Shared Function LPad(ByVal strFrase As String, ByVal strCaracter As String, ByVal intCantidad As Integer) As String
        Dim strResult As String = vbNullString
        Dim i As Integer
        For i = 0 To intCantidad - 1
            strResult &= strCaracter
        Next
        strResult = strResult & strFrase
        Return Right(strResult, intCantidad)
    End Function
    Public Shared Function GetSiteConfigrationValue(ByVal ConfigrationKey As String) As Object
        Return ConfigurationManager.AppSettings(ConfigrationKey)
    End Function
    Public Shared Function SplitString(ByVal text As String, ByVal noChar As Integer) As ArrayList
        Dim al As New ArrayList
        If text.Length <= noChar Then
            al.Add(text)
        Else
            Dim str() As String = text.Split(" ")
            Dim _temp As String = ""
            For Each s As String In str

                If s.Trim.Length > noChar Then
                    If _temp.Length = 0 Then
                        _temp = s.Substring(0, noChar)
                        If _temp.Length > 0 Then
                            al.Add(_temp)
                        End If
                        _temp = ""
                        s = s.Substring(noChar)
                        While (s.Length > 0)
                            If s.Length > noChar Then
                                _temp = s.Substring(0, noChar)
                                If _temp.Length > 0 Then
                                    al.Add(_temp)
                                End If
                                _temp = ""
                                s = s.Substring(noChar)
                            Else
                                _temp = s
                                s = ""
                            End If
                        End While
                    Else
                        If _temp.Length > 0 Then
                            al.Add(_temp)
                        End If
                        _temp = ""
                        While (s.Length > 0)
                            If s.Length > noChar Then
                                _temp = s.Substring(0, noChar)
                                If _temp.Length > 0 Then
                                    al.Add(_temp)
                                End If
                                _temp = ""
                                s = s.Substring(noChar)
                            Else
                                _temp = s
                                s = ""
                            End If
                        End While
                    End If
                Else
                    If _temp.Length + s.Length < noChar Then
                        _temp = _temp & " " + s
                    Else
                        If _temp.Length > 0 Then
                            al.Add(_temp)
                        End If
                        _temp = s
                    End If
                End If
            Next
            If _temp.Length > 0 Then
                al.Add(_temp)
                _temp = ""
            End If
        End If
        Return al
    End Function
    Public Shared Function IsSolarSystem(ByVal UserID As Integer) As Boolean
        Dim oU As New Users(UserID)
        If oU.UserTypeID = CommonLibrary.Utility.eUserTypes.UserType1 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function IsInd1or2(ByVal UserID As Integer) As Boolean
        Dim oU As New Users(UserID)
        If oU.UserTypeID = CommonLibrary.Utility.eUserTypes.IndividualType1 OrElse oU.UserTypeID = CommonLibrary.Utility.eUserTypes.IndividualType2 Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Shared Function WriteFeedStatus(ByVal IsSuccess As Boolean, ByVal crawlDate As DateTime, ByVal unitCount As Integer, ByVal propertyCount As Integer, ByVal errorMsg As String) As Boolean
        Try
            Dim dt As New System.Data.DataTable("FeedStatus")

            dt.Columns.Add("IsSuccess")
            dt.Columns.Add("CrawlDate")
            dt.Columns.Add("UnitCount")
            dt.Columns.Add("PropertyCount")
            dt.Columns.Add("ErrorMsg")

            Dim dr As System.Data.DataRow
            dr = dt.NewRow
            dr("IsSuccess") = IsSuccess
            dr("CrawlDate") = crawlDate
            dr("UnitCount") = unitCount
            dr("PropertyCount") = propertyCount
            dr("ErrorMsg") = errorMsg

            dt.Rows.Add(dr)

            dt.WriteXml(HttpContext.Current.Server.MapPath("~/Admin/FeedData/StellarStatus.xml"))
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function GetFeedStatus() As System.Data.DataRow
        Dim dt As New System.Data.DataTable
        Dim ds As New DataSet
        ds.ReadXml(HttpContext.Current.Server.MapPath("~/Admin/FeedData/StellarStatus.xml"))
        dt = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function GetUserImageNew(ByVal UserID As Integer) As String
        Dim oU As New UserLibrary.Users(UserID)
        If oU.ProfileImage.Trim.Length > 0 Then
            Return UIHelper.GetUnionVerseBasePathURL & "/" & oU.ProfileImage.Trim
        Else
            ' Return UIHelper.GetUnionVerseBasePathURL & "/UserFiles/Profiles/Default_Pic_icon.png"
            Return GetDefaultPicture(oU.RoleID)
        End If
    End Function

    Public Shared Function GetDefaultPicture(ByRef Roleid As Integer) As String
        If Roleid = 1 Then
            Return UIHelper.GetUnionVerseBasePathURL & "/UserFiles/DefaultPictures/ReligiousSac.png"
        ElseIf Roleid = 2 Then
            Return UIHelper.GetUnionVerseBasePathURL & "/UserFiles/DefaultPictures/indI-II.png"

        ElseIf Roleid = 3 Then
            Return UIHelper.GetUnionVerseBasePathURL & "/UserFiles/DefaultPictures/indI-II.png"

        ElseIf Roleid = 4 Then
            Return UIHelper.GetUnionVerseBasePathURL & "/UserFiles/DefaultPictures/business.png"

        ElseIf Roleid = 5 Then
            Return UIHelper.GetUnionVerseBasePathURL & "/UserFiles/DefaultPictures/Moon.png"

        ElseIf Roleid = 8 Then
            Return UIHelper.GetUnionVerseBasePathURL & "/UserFiles/DefaultPictures/whitewhole.png"
        Else
            Return UIHelper.GetUnionVerseBasePathURL & "/UserFiles/DefaultPictures/default.png"
        End If


    End Function

End Class