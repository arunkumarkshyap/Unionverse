Imports Microsoft.VisualBasic
Imports JobLibrary
Public Class JDataHelper

    Enum ePostType
        Job = 1
        iResume = 2
    End Enum

    Public Shared Sub LoadCareerLevels(ByVal ddl As System.Web.UI.WebControls.ListControl, Optional ByVal indexItem As String = "")
        Dim oCareerLvl As New CareerLevel
        Dim al As New ArrayList
        al = oCareerLvl.GetAll()
        ddl.DataSource = al

        ddl.DataTextField = "CareerLevel"
        ddl.DataValueField = "CareerLevelID"

        ddl.DataBind()
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
        al = Nothing
    End Sub
    Public Shared Sub LoadEduLevels(ByVal ddl As System.Web.UI.WebControls.ListControl, Optional ByVal indexItem As String = "")
        Dim oEduLevel As New EduLevel
        Dim al As New ArrayList
        al = oEduLevel.GetAll()
        ddl.DataSource = al

        ddl.DataTextField = "EduLevel"
        ddl.DataValueField = "EduLevelID"

        ddl.DataBind()
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
        al = Nothing
    End Sub
    Public Shared Sub LoadIndustry(ByVal ddl As System.Web.UI.WebControls.ListControl, Optional ByVal indexItem As String = "")
        Dim oIndustry As New Industry
        Dim al As New ArrayList
        al = oIndustry.GetAll()
        ddl.DataSource = al

        ddl.DataTextField = "IndustryName"
        ddl.DataValueField = "IndustryID"

        ddl.DataBind()
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
        al = Nothing
    End Sub
    Public Shared Sub LoadJobSubCategories(ByVal ddl As System.Web.UI.WebControls.ListControl, Optional ByVal pCategoryID As Integer = 0, Optional ByVal indexItem As String = "")
        Dim oJCategory As New JCategory
        Dim al As New ArrayList
        al = oJCategory.GetChildCategories(pCategoryID)
        ddl.DataSource = al

        ddl.DataTextField = "JobCategory"
        ddl.DataValueField = "JobCategoryID"

        ddl.DataBind()
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
        al = Nothing
    End Sub
    Public Shared Sub LoadJobCategories(ByVal ddl As System.Web.UI.WebControls.ListControl, Optional ByVal indexItem As String = "")
        Dim oJCategory As New JCategory
        Dim al As New ArrayList
        al = oJCategory.GetParentCategories()
        ddl.DataSource = al

        ddl.DataTextField = "JobCategory"
        ddl.DataValueField = "JobCategoryID"

        ddl.DataBind()
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
        al = Nothing
    End Sub
    Public Shared Sub LoadJobType(ByVal ddl As System.Web.UI.WebControls.ListControl, Optional ByVal indexItem As String = "")
        Dim oJobType As New JobType
        Dim al As New ArrayList
        al = oJobType.GetAll()
        ddl.DataSource = al

        ddl.DataTextField = "JobType"
        ddl.DataValueField = "JobTypeID"

        ddl.DataBind()
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
        al = Nothing
    End Sub
    Public Shared Sub LoadJYears(ByVal ddl As System.Web.UI.WebControls.ListControl, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        ddl.Items.Add(New ListItem("0", "0"))
        ddl.Items.Add(New ListItem("1", "1"))
        ddl.Items.Add(New ListItem("2", "2"))
        ddl.Items.Add(New ListItem("3", "3"))
        ddl.Items.Add(New ListItem("4", "4"))
        ddl.Items.Add(New ListItem("5", "5"))
        ddl.Items.Add(New ListItem("6", "6"))
        ddl.Items.Add(New ListItem("7", "7"))
        ddl.Items.Add(New ListItem("8", "8"))
        ddl.Items.Add(New ListItem("9", "9"))
        ddl.Items.Add(New ListItem("10", "10"))
        ddl.Items.Add(New ListItem("11", "1"))
        ddl.Items.Add(New ListItem("12", "12"))
        ddl.Items.Add(New ListItem("13", "13"))
        ddl.Items.Add(New ListItem("14", "14"))
        ddl.Items.Add(New ListItem("15", "15"))
        ddl.Items.Add(New ListItem("16", "16"))
        ddl.Items.Add(New ListItem("17", "17"))
        ddl.Items.Add(New ListItem("18", "18"))
        ddl.Items.Add(New ListItem("19", "19"))
        ddl.Items.Add(New ListItem("20", "20"))
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
    End Sub
    Public Shared Sub LoadJMonths(ByVal ddl As System.Web.UI.WebControls.ListControl, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        ddl.Items.Add(New ListItem("0", "0"))
        ddl.Items.Add(New ListItem("1", "1"))
        ddl.Items.Add(New ListItem("2", "2"))
        ddl.Items.Add(New ListItem("3", "3"))
        ddl.Items.Add(New ListItem("4", "4"))
        ddl.Items.Add(New ListItem("5", "5"))
        ddl.Items.Add(New ListItem("6", "6"))
        ddl.Items.Add(New ListItem("7", "7"))
        ddl.Items.Add(New ListItem("8", "8"))
        ddl.Items.Add(New ListItem("9", "9"))
        ddl.Items.Add(New ListItem("10", "10"))
        ddl.Items.Add(New ListItem("11", "1"))
  
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
    End Sub
End Class
