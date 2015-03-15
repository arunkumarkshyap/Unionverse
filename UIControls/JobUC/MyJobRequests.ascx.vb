﻿
Partial Class CMSWebParts_SMTWebParts_JobUC_MyJobRequests
    Inherits System.Web.UI.UserControl
    Public ReadOnly Property CurrentUser As UserLibrary.Users
        Get
            If Not IsNothing(Session("Users")) Then
                Return CType(Session("Users"), UserLibrary.Users)
            Else
                Return New UserLibrary.Users
            End If
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PlanetSearch1.UserID = CurrentUser.UserID
        PlanetSearch1.LoadResults(1)
    End Sub
End Class
