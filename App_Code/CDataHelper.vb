Imports Microsoft.VisualBasic
Imports System.Data
Imports Microsoft.ApplicationBlocks.Data
Public Class CDataHelper

    Public Enum eCStatus
        Open = 1
        InProgress = 2
        Resolved = 3
        Closed = 4
        InComplete = 99

    End Enum
    Public Enum eCPriority
        Urgent = 1
        High = 2
        Normal = 3
        Low = 4
        NotSet = 99

    End Enum
    Public Enum eCUserType
        Planet = 1
        Voyger = 2
    End Enum
    Public Enum eCRepresentative
        Attoney = 1
        Representative = 2
        None = 0
    End Enum
    Public Enum eHYTHow
        Phone = 1
        Mail = 2
        Email = 3
        In_Person = 4
        Other = 99
    End Enum
    Public Enum eResponseHow
        Phone = 1
        Mail = 2
        Email = 3
        In_Person = 4
        Other = 99
    End Enum
    Public Enum eContactTime
        Morning = 1
        Afternoon = 2
        Evening = 3
    End Enum
    Public Enum eCAttorneyType
        Power_of_Attorney = 1
        Letters_Testamentary = 2
        Court_Appointed_Executor_or_Administrator = 3
        Other = 4
    End Enum
    Public Shared Sub LoadHYTHow(ByVal ddl As System.Web.UI.WebControls.ListControl, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        ddl.Items.Add(New ListItem("Phone", "1"))
        ddl.Items.Add(New ListItem("Mail", "2"))
        ddl.Items.Add(New ListItem("Email", "3"))
        ddl.Items.Add(New ListItem("In Person", "4"))
        ddl.Items.Add(New ListItem("Other", "99"))


        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
    End Sub
    Public Shared Sub LoadResponseHow(ByVal ddl As System.Web.UI.WebControls.ListControl, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        ddl.Items.Add(New ListItem("Phone", "1"))
        ddl.Items.Add(New ListItem("Mail", "2"))
        ddl.Items.Add(New ListItem("Email", "3"))
        ddl.Items.Add(New ListItem("In Person", "4"))
        ddl.Items.Add(New ListItem("Other", "99"))


        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
    End Sub
    Public Shared Sub LoadCountries(ByVal ddl As System.Web.UI.WebControls.ListControl, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        Dim resultds As New DataSet
        resultds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings("connectionString"), _
         CommandType.Text, "Select CountryID, CountryDisplayName FROM CMS_Country Order By CountryDisplayName")
        If Not IsNothing(resultds) AndAlso resultds.Tables.Count > 0 AndAlso resultds.Tables(0).Rows.Count > 0 Then
            ddl.DataSource = resultds.Tables(0)
            ddl.DataTextField = "CountryDisplayName"
            ddl.DataValueField = "CountryID"
            ddl.DataBind()
        End If

        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
        resultds = Nothing
    End Sub
    Public Shared Sub LoadStates(ByVal ddl As System.Web.UI.WebControls.ListControl, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        Dim resultds As New DataSet
        resultds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings("connectionString"), _
         CommandType.Text, "Select StateID, StateDisplayName FROM CMS_State Order By StateDisplayName")
        If Not IsNothing(resultds) AndAlso resultds.Tables.Count > 0 AndAlso resultds.Tables(0).Rows.Count > 0 Then
            ddl.DataSource = resultds.Tables(0)
            ddl.DataTextField = "StateDisplayName"
            ddl.DataValueField = "StateID"
            ddl.DataBind()
        End If

        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
        resultds = Nothing
    End Sub
    Public Shared Function getCountryName(ByVal id As Integer) As String

        Dim result As New Object
        result = SqlHelper.ExecuteScalar(ConfigurationManager.AppSettings("connectionString"), _
         CommandType.Text, "Select CountryDisplayName FROM CMS_Country WHERE CountryID = " & id)
        If Not IsNothing(result) AndAlso CStr(result).Trim.Length > 0 Then
            Return CStr(result)
        Else
            Return ""
        End If
    End Function
    Public Shared Function getStateName(ByVal id As Integer) As String

        Dim result As New Object
        result = SqlHelper.ExecuteScalar(ConfigurationManager.AppSettings("connectionString"), _
         CommandType.Text, "Select StateDisplayName FROM CMS_State WHERE StateID = " & id)
        If Not IsNothing(result) AndAlso CStr(result).Trim.Length > 0 Then
            Return CStr(result)
        Else
            Return ""
        End If
    End Function
    Public Shared Function getAccountTypeName(ByVal id As Integer) As String

        Dim result As New Object
        result = SqlHelper.ExecuteScalar(ConfigurationManager.AppSettings("connectionString"), _
         CommandType.Text, "Select CAccountType FROM SMT_CAccountType WHERE CAccountTypeID = " & id)
        If Not IsNothing(result) AndAlso CStr(result).Trim.Length > 0 Then
            Return CStr(result)
        Else
            Return ""
        End If
    End Function
    Public Shared Sub LoadComplaintContactMode(ByVal ddl As System.Web.UI.WebControls.ListControl, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        Dim resultds As New DataSet
        resultds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings("connectionString"), _
         CommandType.Text, "Select CContactMode, CContactModeName FROM SMT_CContactMode Order By DisplayOrder")
        If Not IsNothing(resultds) AndAlso resultds.Tables.Count > 0 AndAlso resultds.Tables(0).Rows.Count > 0 Then
            ddl.DataSource = resultds.Tables(0)
            ddl.DataTextField = "CContactModeName"
            ddl.DataValueField = "CContactMode"
            ddl.DataBind()
        End If

        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
        resultds = Nothing
    End Sub
    Public Shared Sub LoadComplaintContactTime(ByVal ddl As System.Web.UI.WebControls.ListControl, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        Dim resultds As New DataSet
        resultds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings("connectionString"), _
         CommandType.Text, "Select CContactTime, CContactTimeName FROM SMT_CContactTime Order By DisplayOrder")
        If Not IsNothing(resultds) AndAlso resultds.Tables.Count > 0 AndAlso resultds.Tables(0).Rows.Count > 0 Then
            ddl.DataSource = resultds.Tables(0)
            ddl.DataTextField = "CContactTimeName"
            ddl.DataValueField = "CContactTime"
            ddl.DataBind()
        End If

        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
        resultds = Nothing
    End Sub
    Public Shared Sub LoadComplaintAccountTypes(ByVal ddl As System.Web.UI.WebControls.ListControl, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        Dim resultds As New DataSet
        resultds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings("connectionString"), _
         CommandType.Text, "Select CAccountTypeID, CAccountType FROM SMT_CAccountType Order By DisplayOrder")
        If Not IsNothing(resultds) AndAlso resultds.Tables.Count > 0 AndAlso resultds.Tables(0).Rows.Count > 0 Then
            ddl.DataSource = resultds.Tables(0)
            ddl.DataTextField = "CAccountType"
            ddl.DataValueField = "CAccountTypeID"
            ddl.DataBind()
        End If

        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
        resultds = Nothing
    End Sub

    Public Shared Sub LoadComplaintPriority(ByVal ddl As System.Web.UI.WebControls.ListControl, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        Dim resultds As New DataSet
        resultds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings("connectionString"), _
         CommandType.Text, "Select CPriorityID, CPriority FROM SMT_CPriority Order By DisplayOrder")
        If Not IsNothing(resultds) AndAlso resultds.Tables.Count > 0 AndAlso resultds.Tables(0).Rows.Count > 0 Then
            ddl.DataSource = resultds.Tables(0)
            ddl.DataTextField = "CPriority"
            ddl.DataValueField = "CPriorityID"
            ddl.DataBind()
        End If

        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
        resultds = Nothing
    End Sub
    Public Shared Sub LoadAttorneyTypes(ByVal ddl As System.Web.UI.WebControls.ListControl, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        Dim resultds As New DataSet
        resultds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings("connectionString"), _
         CommandType.Text, "Select AttorneyTypeID, AttorneyType FROM SMT_CAttorneyType Order By DisplayOrder")
        If Not IsNothing(resultds) AndAlso resultds.Tables.Count > 0 AndAlso resultds.Tables(0).Rows.Count > 0 Then
            ddl.DataSource = resultds.Tables(0)
            ddl.DataTextField = "AttorneyType"
            ddl.DataValueField = "AttorneyTypeID"
            ddl.DataBind()
        End If

        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
        resultds = Nothing
    End Sub
    Public Shared Sub LoadRepresentativeTypes(ByVal ddl As System.Web.UI.WebControls.ListControl, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        ddl.Items.Add(New ListItem("none", 0))
        ddl.Items.Add(New ListItem("Attorney", 1))
        ddl.Items.Add(New ListItem("Representative", 2))

        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
    End Sub
    Public Shared Sub LoadComplaintStatus(ByVal ddl As System.Web.UI.WebControls.ListControl, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()

        Dim resultds As New DataSet
        resultds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings("connectionString"), _
         CommandType.Text, "Select CStatusID, CStatus FROM SMT_CStatus Order By DisplayOrder")
        If Not IsNothing(resultds) AndAlso resultds.Tables.Count > 0 AndAlso resultds.Tables(0).Rows.Count > 0 Then
            ddl.DataSource = resultds.Tables(0)
            ddl.DataTextField = "CStatus"
            ddl.DataValueField = "CStatusID"
            ddl.DataBind()
        End If

        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
        resultds = Nothing
    End Sub
End Class
