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

Partial Class UIControls_Connection_UserType1Planets
    Inherits System.Web.UI.UserControl
    Public Property UserType1ID() As Integer
        Get
            If Not IsNothing(ViewState("UserType1ID")) AndAlso IsNumeric(ViewState("UserType1ID")) Then
                Return CInt(ViewState("UserType1ID"))
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("UserType1ID") = value
        End Set
    End Property
    Public Property IndividualType1or2() As Integer
        Get
            If Not IsNothing(ViewState("IndividualType1or2")) AndAlso IsNumeric(ViewState("IndividualType1or2")) Then
                Return CInt(ViewState("IndividualType1or2"))
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("IndividualType1or2") = value
        End Set
    End Property
    Public Sub LoadData()
        Dim oUTP As New smt_UserType1Planet
        Dim Arl As New ArrayList
        Arl = oUTP.GetByFillter(0, UserType1ID, 0, 1, IndividualType1or2)
        If Not IsNothing(Arl) AndAlso Arl.Count > 0 Then
            Me.rpPlanets.DataSource = Arl
            Me.rpPlanets.DataBind()
            Me.lblNoRecord.Visible = False
            Me.rpPlanets.Visible = True
        Else
            Me.rpPlanets.DataSource = New ArrayList
            Me.rpPlanets.DataBind()
            Me.lblNoRecord.Visible = True
            Me.rpPlanets.Visible = False
        End If
    End Sub

    Public Function GetUserHTML(ByVal UserID As Integer) As String
        Dim str As String = ""
        If UserID > 0 Then
            Dim oUI As New Users(UserID)
            If Not IsNothing(oUI) AndAlso oUI.UserID > 0 Then
                str = "<span class='pbox_itm_img'><a href='" & UIHelper.GetBasePath() & "/Members/" & oUI.Username.Trim & ".aspx'><img src='" & GetUserImage(oUI.UserID) & "' /></a></span><span class='pbox_inf'><a href='" & UIHelper.GetBasePath() & "/Members/" & oUI.Username.Trim & ".aspx'>" & oUI.Username & "</a></span>"
            End If
        Else
            str = ""
        End If

        Return str
    End Function

    Public Function GetUserImage(ByVal UserID As Integer) As String
        Dim _u1 As New Users(UserID)
        If _u1.ProfileImage.Trim.Length > 0 Then
            Return UIHelper.GetUnionVerseBasePathURL & "/UserFiles/Profiles/" & _u1.ProfileImage.Trim
        Else
            Return UIHelper.GetUnionVerseBasePathURL & "/UserFiles/Profiles/Profile-Pic-Man.png"
        End If
    End Function

End Class
