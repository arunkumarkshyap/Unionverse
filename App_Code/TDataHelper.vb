Imports Microsoft.VisualBasic

Public Class TDataHelper
    Public Shared Sub LoadPriorities(ByVal ddl As System.Web.UI.WebControls.ListControl, Optional ByVal indexItem As String = "")
        ddl.Items.Clear()
        ddl.Items.Add(New ListItem("Imperative", "1"))
        ddl.Items.Add(New ListItem("Urgent", "2"))
        ddl.Items.Add(New ListItem("High", "3"))
        ddl.Items.Add(New ListItem("Normal", "4"))
        ddl.Items.Add(New ListItem("Can Wait", "5"))
        If indexItem.Trim.Length > 0 Then
            ddl.Items.Insert(0, New ListItem(indexItem, -1))
        End If
    End Sub
End Class
