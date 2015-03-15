Imports UserLibrary
Partial Class UserType1Ind1Reg
    Inherits System.Web.UI.Page

    Public ReadOnly Property GroupID() As Integer   '  UserType1ID will come from UserType1 table.
        Get
            If Not IsNothing(Request.Item("GID")) AndAlso IsNumeric(Request.Item("GID")) Then
                Return CInt(Request.Item("GID"))
            Else
                Return 0
            End If
        End Get
    End Property
    Public Property UserID() As Integer
        Get
            If Not IsNothing(ViewState("UserID")) AndAlso IsNumeric(ViewState("UserID")) Then
                Return CInt(ViewState("UserID"))
            Else
                If Not IsNothing(Session("Users")) AndAlso CType(Session("Users"), Users).UserID Then
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
        Me.hGroupName.InnerHtml = "Planet I (Individual)"
        'Dim oUT1 As New smt_UserType1(GroupID)
        'If Not IsNothing(oUT1) AndAlso oUT1.UserType1ID > 0 Then
        '    Me.hGroupName.InnerHtml = oUT1.UserName.Trim
        '    'Me.lblUnionVerseUserID.Text = oUT1.UserID
        '    'Me.hlIndividualregistration.Text = "groupreg_" & oUT1.UserName.Trim.Replace(" ", "_") & ".aspx"
        '    'Me.hlIndividualregistration.NavigateUrl = "groupreg_" & oUT1.UserName.Trim.Replace(" ", "_") & ".aspx"
        'End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If UserID > 0 Then
                If IsUserRegisterToGroup(UserID) Then
                    Me.lblError.Text = "Sorry you have already joined a group."
                Else
                    IndividualUserType1Regis1.Visible = True
                    If GroupID > 0 Then
                        LoadData()
                        IndividualUserType1Regis1.UserType1ID = GroupID
                        IndividualUserType1Regis1.UserID = UserID
                        IndividualUserType1Regis1.LoadData()
                    End If
                End If
            Else
                Response.Redirect(UIHelper.GetBasePath() & "/login.aspx")
            End If
        End If
    End Sub
    Public Function IsUserRegisterToGroup(ByVal UserID As Integer) As Boolean
        Dim oB As New smt_BusinessType()
        oB.LoadByUserID(UserID)
        If Not IsNothing(oB) AndAlso oB.BusinessTypeID > 0 Then
            Return True
        End If

        Dim oS As New smt_School
        oS.LoadByUserID(UserID)
        If Not IsNothing(oS) AndAlso oS.SchoolID > 0 Then
            Return True
        End If

        Dim oUT1 As New smt_UserType1
        oUT1.LoadByUserID(UserID)
        If Not IsNothing(oUT1) AndAlso oUT1.UserType1ID > 0 Then
            Return True
        End If

        Dim oIU1T1 As New smt_IndividualUserType1
        oIU1T1.LoadByUserID(UserID)
        If Not IsNothing(oIU1T1) AndAlso oIU1T1.IndividualUserType1ID > 0 Then
            Return True
        End If

        Dim oIU2T1 As New smt_IndividualUserType2
        oIU2T1.LoadByUserID(UserID)
        If Not IsNothing(oIU2T1) AndAlso oIU2T1.IndividualUserType2ID Then
            Return True
        End If
        Return False
    End Function
End Class
