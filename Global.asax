<%@ Application Language="VB" %>
<%@ Import Namespace="UserLibrary" %>
<script RunAt="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub
       
    Sub Application_AcquireRequestState(ByVal sender As Object, ByVal e As EventArgs)
        '    If Not IsNothing(Session("Users")) AndAlso CType(Session("Users"), Users).UserID > 0 Then
        '        Dim oOU As New OnlineUsers
        '        oOU.UserID = CType(Session("Users"), Users).UserID
        '        oOU.OnlineSince = DateTime.Now
        '        oOU.UserAddUpdateTime()
        '    End If
        End Sub
    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        Dim str As String = ""
        Dim relativePath = HttpContext.Current.Request.Url.AbsoluteUri.ToLower.Replace(UIHelper.GetUnionVerseBasePathURL().ToLower.Trim, "")
        If relativePath.Contains(".aspx") AndAlso Not relativePath.ToLower.Trim.Contains("/electrons/") AndAlso Not relativePath.ToLower.Trim.Contains("/uvraise/") AndAlso Not relativePath.ToLower.Trim.Contains("/unionversity/") AndAlso Not relativePath.ToLower.Trim.Contains("/gravity/") AndAlso Not relativePath.ToLower.Trim.Contains("/umatter/") AndAlso Not relativePath.ToLower.Trim.Contains("/connections/") AndAlso Not relativePath.ToLower.Trim.Contains("message") AndAlso Not relativePath.ToLower.Trim.Contains("jpegimage") AndAlso Not relativePath.ToLower.Trim.Contains("manageplanets") AndAlso Not relativePath.ToLower.Trim.Contains("managefriends")  AndAlso Not relativePath.ToLower.Trim.Contains("testing") Then
            If relativePath.ToLower().Contains("?") Then
                str = relativePath.ToLower().Substring(0, relativePath.ToLower().IndexOf("?"))
            Else
                str = relativePath.ToLower()
            End If
            str = str.ToLower().Replace(".aspx", "")
            If str.IndexOf("/") = 0 Then
                str = str.Substring(1)
            End If
            Select Case str
                Case "login"
                    Exit Select
                Case "registration-type"
                    Exit Select
                Case "grouptype1employees"
                    If True Then
                        HttpContext.Current.RewritePath("~/GroupType1Employees.aspx")
                        Exit Select
                    End If
                Case "sync"
                    If True Then
                        HttpContext.Current.RewritePath("~/sync.aspx")
                        Exit Select
                    End If
                Case "registration"
                    If True Then
                        HttpContext.Current.RewritePath("~/Registration.aspx")
                        Exit Select
                    End If
                Case "grouptype1"
                    If True Then
                        HttpContext.Current.RewritePath("~/GroupType1.aspx")
                        Exit Select
                    End If
                Case "grouptype4"
                    If True Then
                        HttpContext.Current.RewritePath("~/GroupType4.aspx")
                        Exit Select
                    End If
                Case "businessusers"
                    If True Then
                        Dim str1 As String = ""
                        If relativePath.ToLower.Contains("?") Then
                            str = relativePath.ToLower().Substring(relativePath.ToLower().IndexOf("?")).Replace("?", "")
                        End If
                        If str1.Trim.Length > 0 Then
                            HttpContext.Current.RewritePath("~/BusinessUsers.aspx?" & str1.Trim)
                        Else
                            HttpContext.Current.RewritePath("~/BusinessUsers.aspx")
                        End If
                        Exit Select
                    End If
                Case "individualusertype1"
                    If True Then
                        HttpContext.Current.RewritePath("~/IndividualUserType1.aspx")
                        Exit Select
                    End If
                Case "individualusertype2"
                    If True Then
                        HttpContext.Current.RewritePath("~/IndividualUserType2.aspx")
                        Exit Select
                    End If
                Case "moonregistration"
                    If True Then
                        HttpContext.Current.RewritePath("~/MoonRegistration.aspx")
                        Exit Select
                    End If
                Case "selectgroup"
                    If True Then
                        HttpContext.Current.RewritePath("~/SelectGroup.aspx")
                        Exit Select
                    End If
                Case "selectgroup"
                    If True Then
                        HttpContext.Current.RewritePath("~/SelectGroup.aspx")
                        Exit Select
                    End If
                Case "closeaccount"
                    If True Then
                        HttpContext.Current.RewritePath("~/closeaccount.aspx")
                        Exit Select
                    End If
               
               
                Case "usertype1ind2reg"
                    Exit Select
                Case "usertype1ind1reg"
                    Exit Select
                Case Else
                    
                    If str.Contains("members/") AndAlso (str.Contains("/addfranchise") OrElse str.Contains("/businessusers")) Then
                        str = str.Substring((str.IndexOf("members/") + 8)).Replace(".aspx", "")
                        str = str.Replace("/addfranchise", "").Trim
                        str = str.Replace("/businessusers", "").Trim
                        If str.Contains("/") Then
                            Exit Select
                        Else
                            Dim oU As New Users(str.Trim)
                            If Not IsNothing(oU) Then
                                HttpContext.Current.RewritePath("~/BusinessUsers.aspx?puid=" & oU.UserID)
                            End If
                            Exit Select
                        End If
                    ElseIf str.Contains("members/") AndAlso str.Contains("/wall") Then
                        str = str.Substring((str.IndexOf("members/") + 8)).Replace(".aspx", "")
                        str = str.Replace("/wall", "").Trim
                        If str.Contains("/") Then
                            Exit Select
                        Else
                            Dim oU As New Users(str.Trim)
                            If Not IsNothing(oU) Then
                                HttpContext.Current.RewritePath("~/Wall.aspx?uid=" & oU.UserID)
                            End If
                            Exit Select
                        End If
                    ElseIf str.Contains("members/") AndAlso str.Contains("/gravitationalplanets") Then
                        str = str.Substring((str.IndexOf("members/") + 8)).Replace(".aspx", "")
                        str = str.Replace("/gravitationalplanets", "").Trim
                        If str.Contains("/") Then
                            Exit Select
                        Else
                            Dim oU As New Users(str.Trim)
                            If Not IsNothing(oU) Then
                                HttpContext.Current.RewritePath("~/GravitationalPlanets.aspx?uid=" & oU.UserID)
                            End If
                            Exit Select
                        End If
                    ElseIf str.Contains("members/") AndAlso str.Contains("/starshipvouager") Then
                        str = str.Substring((str.IndexOf("members/") + 8)).Replace(".aspx", "")
                        str = str.Replace("/starshipvouager", "").Trim
                        If str.Contains("/") Then
                            Exit Select
                        Else
                            Dim oU As New Users(str.Trim)
                            If Not IsNothing(oU) Then
                                HttpContext.Current.RewritePath("~/StarShipVouager.aspx?uid=" & oU.UserID)
                            End If
                            Exit Select
                        End If
                    ElseIf str.Contains("members/") AndAlso str.Contains("/chat") AndAlso str.Contains("members/chat") Then
                        str = str.Substring((str.IndexOf("members/") + 8)).Replace(".aspx", "")
                        str = str.Replace("/chat", "").Trim
                        If str.Contains("/") Then
                            Exit Select
                        Else
                            Dim oU As New Users(str.Trim)
                            If Not IsNothing(oU) Then
                                str = relativePath.ToLower().Substring(relativePath.ToLower().IndexOf("?")).Replace("?", "")
                                HttpContext.Current.RewritePath("~/chat.aspx?uid=" & oU.UserID & "&" & str)
                            End If
                            Exit Select
                        End If
                        
                    ElseIf str.Contains("members/") AndAlso str.Contains("/userlisting") Then
                        str = str.Substring((str.IndexOf("members/") + 8)).Replace(".aspx", "")
                        str = str.Replace("/userlisting", "").Trim
                        If str.Contains("/") Then
                            Exit Select
                        Else
                            Dim oU As New Users(str.Trim)
                            If Not IsNothing(oU) Then
                               
                                HttpContext.Current.RewritePath("~/userlisting.aspx?uid=" & oU.UserID & "&" & str)
                            End If
                            Exit Select
                        End If
                        
                        
                        
                        
                    ElseIf str.Contains("members/") AndAlso str.Contains("/addeditalbum") Then
                        str = str.Substring((str.IndexOf("members/") + 8)).Replace(".aspx", "")
                        str = str.Replace("/addeditalbum", "").Trim
                        If str.Contains("/") Then
                            Exit Select
                        Else
                            Dim oU As New Users(str.Trim)
                            If Not IsNothing(oU) Then
                                If relativePath.Contains("?") = True Or relativePath.Contains("&albumid") = True Then
                                    str = relativePath.ToLower().Substring(relativePath.ToLower().IndexOf("?")).Replace("?", "")
                                    If str.Contains("uid") Then
                                        HttpContext.Current.RewritePath("~/addeditalbum.aspx?" & str)
                                    Else
                                        HttpContext.Current.RewritePath("~/addeditalbum.aspx?uid=" & oU.UserID & "&" & str)
                                    End If
                                    
                                Else
                                    HttpContext.Current.RewritePath("~/addeditalbum.aspx?uid=" & oU.UserID)
                                End If
                                
                                
                            End If
                            Exit Select
                        End If
                    ElseIf str.Contains("members/") AndAlso str.Contains("/viewalbumphotos") Then
                        str = str.Substring((str.IndexOf("members/") + 8)).Replace(".aspx", "")
                        str = str.Replace("/viewalbumphotos", "").Trim
                        If str.Contains("/") Then
                            Exit Select
                        Else
                            
                            Dim oU As New Users(str.Trim)
                            If Not IsNothing(oU) Then
                                If relativePath.Contains("?albumid") = True Then
                                    str = relativePath.ToLower().Substring(relativePath.ToLower().IndexOf("?")).Replace("?", "")
                                    HttpContext.Current.RewritePath("~/viewalbumphotos.aspx?uid=" & oU.UserID & "&" & str)
                                Else
                                    HttpContext.Current.RewritePath("~/viewalbumphotos.aspx?uid=" & oU.UserID)
                                End If
                                
                                
                            End If
                            Exit Select
                            
                        End If
                    ElseIf str.Contains("members/") AndAlso str.Contains("/viewalbums") Then
                        str = str.Substring((str.IndexOf("members/") + 8)).Replace(".aspx", "")
                        str = str.Replace("/viewalbums", "").Trim
                        If str.Contains("/") Then
                            Exit Select
                        Else
                            Dim oU As New Users(str.Trim)
                            If Not IsNothing(oU) Then
                                HttpContext.Current.RewritePath("~/viewalbums.aspx?uid=" & oU.UserID)
                            End If
                            Exit Select
                        End If
                        
                    ElseIf str.Contains("viewalbumphotos") AndAlso str.Contains("getslides") Then
                        HttpContext.Current.RewritePath("~/viewalbumphotos.aspx/getslides")
                           
                        Exit Select
                    
  
                        
                    ElseIf str.Contains("members/") Then
                        If Not str.Contains("members/profile") Then
                            str = str.Substring((str.IndexOf("members/") + 8)).Replace(".aspx", "")
                            If str.Contains("/") Then
                                Exit Select
                            Else
                                Dim oU As New Users(str.Trim)
                                If Not IsNothing(oU) Then
                                    HttpContext.Current.RewritePath("~/profile.aspx?uid=" & oU.UserID)
                                End If
                                Exit Select
                            End If
                        Else
                            str = relativePath.ToLower().Substring(relativePath.ToLower().IndexOf("?")).Replace("?", "")
                            HttpContext.Current.RewritePath("~/profile.aspx?" & str)
                            Exit Select
                        End If
                    End If
                    If str.Contains("group_") Then
                        Dim _gname As String = ""
                        _gname = str.Replace("group_", "").Replace("_", " ")
                        Dim _ut1 As New smt_UserType1(_gname)
                        If _ut1 IsNot Nothing AndAlso _ut1.UserType1ID > 0 Then
                            HttpContext.Current.RewritePath("~/GroupHome.aspx?GID=" & _ut1.UserType1ID.ToString())
                        Else
                            HttpContext.Current.RewritePath("~/Default.aspx")

                        End If
                    ElseIf str.Contains("grouphome") Then
                        Exit Select
                    ElseIf str.Contains("ind1reg_") Then
                        Dim _gname As String = ""
                        _gname = str.Replace("ind1reg_", "").Replace("_", " ")
                        Dim _ut1 As New smt_UserType1(_gname)
                        If _ut1 IsNot Nothing AndAlso _ut1.UserType1ID > 0 Then
                            HttpContext.Current.RewritePath("~/UserType1Ind1Reg.aspx?GID=" & _ut1.UserType1ID.ToString())
                        Else
                            HttpContext.Current.RewritePath("~/Default.aspx")
                        End If
                    ElseIf str.Contains("ind2reg_") Then
                        Dim _gname As String = ""
                        _gname = str.Replace("ind2reg_", "").Replace("_", " ")
                        Dim _ut1 As New smt_UserType1(_gname)
                        If _ut1 IsNot Nothing AndAlso _ut1.UserType1ID > 0 Then
                            HttpContext.Current.RewritePath("~/UserType1Ind2Reg.aspx?GID=" & _ut1.UserType1ID.ToString())
                        Else
                            HttpContext.Current.RewritePath("~/Default.aspx")
                        End If
                   
                    Else
                        Dim _gname As String = ""
                        _gname = str.Replace("_", " ")
                        Dim _ut1 As New smt_UserType1(_gname)
                        If _ut1 IsNot Nothing AndAlso _ut1.UserType1ID > 0 Then
                            HttpContext.Current.RewritePath("~/GroupType1IndReg.aspx?GID=" & _ut1.UserType1ID.ToString())
                        Else
                            HttpContext.Current.RewritePath("~/Default.aspx")
                        End If
                    End If
             
                    Exit Select
                        
            End Select
    
        End If
    End Sub
    
</script>
