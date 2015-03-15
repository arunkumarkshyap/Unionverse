Imports UserLibrary
Partial Class GroupHome
    Inherits System.Web.UI.Page
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
    Public ReadOnly Property GroupID() As Integer   '  UserType1ID will come from UserType1 table.
        Get
            If Not IsNothing(Request.Item("GID")) AndAlso IsNumeric(Request.Item("GID")) Then
                Return CInt(Request.Item("GID"))
            Else
                Return 0
            End If
        End Get
    End Property
    Public Sub LoadData()
        Dim oUT1 As New smt_UserType1(GroupID)
        If Not IsNothing(oUT1) AndAlso oUT1.UserType1ID > 0 Then
            Me.hGroupName.InnerHtml = oUT1.UserName.Trim
            Me.lblUnionVerseUserID.Text = oUT1.UserID
            Me.hlIndividualregistration.Text = "ind1reg_" & oUT1.UserName.Trim.Replace(" ", "_") & ".aspx"
            Me.hlIndividualregistration.NavigateUrl = "ind1reg_" & oUT1.UserName.Trim.Replace(" ", "_") & ".aspx"

            Me.hlIndividualregistration2.Text = "ind2reg_" & oUT1.UserName.Trim.Replace(" ", "_") & ".aspx"
            Me.hlIndividualregistration2.NavigateUrl = "ind2reg_" & oUT1.UserName.Trim.Replace(" ", "_") & ".aspx"


            ' PlanetsPendingApproval1.Visible = False


            If oUT1.UserID = UserID Then
                '    PlanetsPendingApproval1.Visible = True
                '   PlanetsPendingApproval1.UserType1ID = GroupID
                '  PlanetsPendingApproval1.LoadData()
            End If
            UserType1Planets1.Visible = True
            UserType1Planets1.UserType1ID = GroupID
            UserType1Planets1.LoadData()
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadData()
        End If
    End Sub
End Class
