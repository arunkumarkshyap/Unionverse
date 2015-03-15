Imports UserLibrary
Partial Class _GroupType1Employees
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
    Public Sub LoadData()
        'Me.hGroupName.InnerHtml = "Employees"
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadData()
            If UserID > 0 Then
                If Not IsUserRegisterToGroup(UserID) Then
                    Me.lblError.Text = "Sorry you are not a GroupType 1 User."
                Else
                    Dim oUT1 As New smt_UserType1
                    oUT1.LoadByUserID(UserID)
                    If Not IsNothing(oUT1) AndAlso oUT1.UserType1ID > 0 Then
                        GroupType1EmployeesAdd1.GroupType1UserID = oUT1.UserID
                        GroupType1EmployeesAdd1.GroupType1ID = oUT1.UserType1ID
                        ' GroupType1EmployeesAdd1.LoadData()
                    End If
                End If
            Else
                Response.Redirect(UIHelper.GetBasePath & "/login.aspx")
            End If
        End If
    End Sub
    Public Function IsUserRegisterToGroup(ByVal UserID As Integer) As Boolean
        Dim oUT1 As New smt_UserType1
        oUT1.LoadByUserID(UserID)
        If Not IsNothing(oUT1) AndAlso oUT1.UserType1ID > 0 Then
            Return True
        End If
        Return False
    End Function
End Class
