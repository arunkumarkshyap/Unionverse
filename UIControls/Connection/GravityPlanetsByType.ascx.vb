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
Partial Class CMSWebParts_Membership_GravityPlanetsByType
    Inherits System.Web.UI.UserControl
    Public Property UserID() As Integer
        Get
            If Not IsNothing(ViewState("UserID")) AndAlso IsNumeric(ViewState("UserID")) Then
                Return CInt(ViewState("UserID"))
            Else
                If Not IsNothing(Session("Users")) AndAlso CType(Session("Users"), Users).UserID > 0 Then
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
    Public Property TypeOfAgent() As String
        Get
            If Not IsNothing(ViewState("TypeOfAgent")) Then
                Return CStr(ViewState("TypeOfAgent"))
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            ViewState("TypeOfAgent") = value
        End Set
    End Property
    Public Property InsuranceBroker() As String
        Get
            If Not IsNothing(ViewState("InsuranceBroker")) Then
                Return CStr(ViewState("InsuranceBroker"))
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            ViewState("InsuranceBroker") = value
        End Set
    End Property
    Public Property Attorney() As String
        Get
            If Not IsNothing(ViewState("Attorney")) Then
                Return CStr(ViewState("Attorney"))
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            ViewState("Attorney") = value
        End Set
    End Property
    Public Property Doctor() As String
        Get
            If Not IsNothing(ViewState("Doctor")) Then
                Return CStr(ViewState("Doctor"))
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            ViewState("Doctor") = value
        End Set
    End Property

    Public Function GetHeaderHTML() As String
        Dim str As String = ""
        If TypeOfAgent.Trim.ToLower = "insurance broker" Then
            Return "<div style='padding-left:10px;'><b>" & TypeOfAgent.Trim & "</b><div style='padding-left:20px; border:solid 0px #000; display:inline-table; width:550px;'><b>" & InsuranceBroker & "</b><div class='cb'></div><div>"
        ElseIf TypeOfAgent.Trim.ToLower = "doctor" Then
            Return "<div style='padding-left:10px;'><b>" & TypeOfAgent.Trim & "</b><div style='padding-left:20px; border:solid 0px #000; display:inline-table; width:550px;'><b>" & Doctor & "</b><div><div class='cb'></div><div>"
        ElseIf TypeOfAgent.Trim.ToLower = "attorney" Then
            Return "<div style='padding-left:10px;'><b>" & TypeOfAgent.Trim & "</b><div style='padding-left:20px; border:solid 0px #000; display:inline-table; width:550px;'><b>" & Attorney & "<div><div class='cb'></div><div>"
        Else
            Return "<div style='padding-left:10px; border:solid 0px #000; display:inline-table; width:550px;'><b>" & TypeOfAgent.Trim & "</b><div class='cb'></div><div>"
        End If
        Return ""
    End Function
    Public Function GetFooterHTML() As String
        Dim str As String = ""
        If TypeOfAgent.Trim.ToLower = "insurance broker" OrElse TypeOfAgent.Trim.ToLower = "doctor" OrElse TypeOfAgent.Trim.ToLower = "attorney" Then
            Return "</div></div></div>"
        Else
            Return "</div></div>"
        End If
        Return ""
    End Function
    Public Function GetBodyHTML() As String
        Dim Arl As New ArrayList
        Dim oU1 As New Users
        Arl = oU1.IndividualUserType2AgentTypesGravity(UserID)
        Dim str As String = ""

        For Each oU As Users In Arl
            Dim oI2 As New smt_IndividualUserType2()
            oI2.LoadByUserID(oU.UserID)
            If TypeOfAgent.Trim.ToLower = "insurance broker" AndAlso InsuranceBroker.Trim.ToLower = oI2.InsuranceBroker.Trim.ToLower Then
                str = str & BodyText(oI2, oU)
            ElseIf TypeOfAgent.Trim.ToLower = "doctor" AndAlso Doctor.Trim.ToLower = oI2.Doctor.Trim.ToLower Then
                str = str & BodyText(oI2, oU)
            ElseIf TypeOfAgent.Trim.ToLower = "attorney" AndAlso Attorney.Trim.ToLower = oI2.Attorney.Trim.ToLower Then
                str = str & BodyText(oI2, oU)
            Else
                str = str & BodyText(oI2, oU)
            End If
        Next
        Return str
    End Function
    Public Function BodyText(ByVal oI2 As smt_IndividualUserType2, ByVal oU As Users) As String
        Dim str As String = ""
        Dim oUT1 As New smt_UserType1(oI2.GroupTypeID)
        str = "<table cellpadding='0' cellspacing='0' border='0'>"
        str = str & "<tr><td rowspan='7' valign='top' style='padding-right:5px;'>" & "<a href='" & UIHelper.GetBasePath() & "/Members/" & oU.Username & "'><img width='120' height='120' src='" & GetUserImage(oI2.UserID) & "' /></a>" & "</td><td><b>Agent:</b>&nbsp;<a href='" & UIHelper.GetBasePath() & "/Members/" & oU.Username & ".aspx'>" & oU.Username & "</a></td></tr>"
        str = str & "<tr><td><b>Employer:</b>&nbsp;" & "" & "</td></tr>"
        str = str & "<tr><td><b>Resume:</b>&nbsp;" & "<a href='" & UIHelper.GetBasePath() & "/Members/uvraise/" & oU.Username & "/viewresume.aspx" & "'>View Resume</a>" & "</td></tr>"
        str = str & "<tr><td><b>Experience:</b>&nbsp;" & "<a href='" & UIHelper.GetBasePath() & "/Members/" & oU.Username & "/OrbI2I.aspx" & "'>Orb Connections</a>" & "</td></tr>"
        str = str & "<tr><td><b>Religious Sanctuary:</b>&nbsp;<a href='" & UIHelper.GetBasePath() & "/Members/" & oUT1.UserName & "'>" & oUT1.UserName & "</a></td></tr>"
        str = str & "<tr><td><b>Chat:</b>&nbsp;" & IsChatAvailable(oU) & "</td></tr>"
        str = str & "</table>"
        Return str
    End Function

    Public Function IsChatAvailable(ByVal oU As Users) As String
        Dim str As String = ""
        If oU.UserID <> CType(Session("Users"), Users).UserID AndAlso (CType(Session("Users"), Users).UserTypeID = CommonLibrary.Utility.eUserTypes.IndividualType2 OrElse CType(Session("Users"), Users).UserTypeID = CommonLibrary.Utility.eUserTypes.IndividualType1) Then
            '  If CMS.CMSHelper.SessionManager.IsUserOnline(CMSContext.CurrentSiteName, oU.UserID, True) = True Then
            ' str = "<a href='" & SMTUIHelper.GetUnionVerseBasePathURL() & "/Members/" & oU.Username & "/Chat.aspx?FriendGUID=" & oU.UserGUID.ToString & "'>Online</a>"
            ' Else
            str = "<a href='#'>Offline</a>"
            ' End If
        Else
            str = "n/a"
        End If

        Return str
    End Function

    Public Function GetUserImage(ByVal UserID As Integer) As String
        Dim oU As New Users(UserID)
        If oU.ProfileImage.Trim.Length > 0 Then
            Return UIHelper.GetUnionVerseBasePathURL & "/" & oU.ProfileImage.Trim
        Else
            Return UIHelper.GetUnionVerseBasePathURL & "/UserFiles/Profiles/Profile-Pic-Man.png"
        End If
    End Function


End Class
