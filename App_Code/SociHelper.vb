Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics
Imports iSocialLibrary
Imports System.Text
Imports System.Text.RegularExpressions
Public Class SociHelper
    Public Shared Function ValidateURL(url As String) As Boolean

        Dim URLReg As String = "^(http|https|ftp)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&amp;%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{2}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&amp;%\$#\=~_\-]+))*$"

        'Match m = ;
        If Regex.IsMatch(url, URLReg) Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Shared Function GetDomainName(URL As String) As String
        Return New Uri(URL).Host
    End Function
    Public Shared Function GetDateTimeStamp(idate As DateTime) As String
        Dim result As String = ""
        If (Not IsNothing(idate) AndAlso IsDate(idate)) Then
            If CType(System.DateTime.Now - idate, TimeSpan).TotalSeconds < 59 Then
                result = Convert.ToString(CType(System.DateTime.Now - idate, TimeSpan).Seconds) & " seconds ago"
            ElseIf CType(System.DateTime.Now - idate, TimeSpan).TotalMinutes < 59 Then
                result = Convert.ToString(CType(System.DateTime.Now - idate, TimeSpan).Minutes) & " minutes ago"
            ElseIf CType(System.DateTime.Now - idate, TimeSpan).TotalHours < 24 Then
                result = CType(System.DateTime.Now - idate, TimeSpan).Hours & " hours ago"
            ElseIf CType(System.DateTime.Now - idate, TimeSpan).TotalDays < 7 Then
                result = Convert.ToString(idate.DayOfWeek) & " at " & idate.Hour & ":" & idate.Minute
            ElseIf CType(System.DateTime.Now - idate, TimeSpan).TotalDays > 7 Then
                result = idate.Day & " " & idate.ToString("MMM") & " at " & idate.Hour & ":" & idate.Minute
            End If
        End If
        Return result
    End Function
    Public Shared Function trimtext(text As String, noChar As Integer) As String
        If (text IsNot Nothing) AndAlso text.Length > 0 Then
            If text.Length > noChar Then
                Return text.Substring(0, noChar) & "..."
            Else
                Return text
            End If
        Else
            Return ""
        End If
    End Function
    Public Shared Function GetYoutubeCode(Link As String) As String
        Dim text As String = Link
        Dim startInd As Int32 = text.IndexOf("?v=")
        Dim StIndex As Int32 = startInd + 3
        Dim text1 As String = text.Substring(StIndex)
        Dim code As String = ""
        For i As Int32 = 0 To text1.Length - 1
            Dim testCount As Int32 = i
            Dim test As String = text1.Substring(testCount, 1)
            If test = "&" Then
                Exit For
            Else
                code += test
            End If
        Next
        Return code
    End Function

    Public Shared Function GetPostContent(ByRef oPost As iPost) As String
        Dim result As String = ""

        'oPost.SourceURL = "http://" + oPost.SourceURL;

        If (oPost IsNot Nothing) AndAlso oPost.iPostID > 0 Then
            Select Case oPost.iPostTypeID
                Case CInt(Utility.ePostType.Photo)
                    If oPost.iUpdate.Trim().Length > 0 Then
                        result = result & "<p class=""iupdt"">" & Convert.ToString(oPost.iUpdate) & "</p>"
                    End If
                    result = result & "<center><img src=""" & UIHelper.GetBasePath() & "/test.aspx?img=" & Convert.ToString(oPost.iPostImage) & "&w=350&h=300"" /></center>"
                    Exit Select
                Case CInt(Utility.ePostType.Link)

                    If oPost.iUpdate.Trim().Length > 0 Then
                        If oPost.SourceURL.Trim().Length > 0 Then
                            result = result & "<p class=""iupdt"">" & Convert.ToString(oPost.iUpdate) & "&nbsp;&nbsp;<a href=""" & Convert.ToString(oPost.SourceURL) & """ target=""_blank"" >" & Convert.ToString(oPost.SourceURL) & "</a></p>"
                        Else
                            result = result & "<p class=""iupdt"">" & Convert.ToString(oPost.iUpdate) & "</p>"
                        End If
                    ElseIf oPost.SourceURL.Trim().Length > 0 Then
                        result = result & "<p class=""iupdt""><a href=""" & Convert.ToString(oPost.SourceURL) & """ target=""_blank"" >" & Convert.ToString(oPost.SourceURL) & "</a></p>"
                    End If

                    result = result & "<div class=""ip_cnt"">"
                    result = result & "<span class=""iimg""><img src=""" & UIHelper.GetBasePath() & "/test.aspx?img=" & Convert.ToString(oPost.iPostImage) & "&w=65&h=65"" /></span>"
                    result = result & "<span class=""itit""><a href=""" & Convert.ToString(oPost.SourceURL) & """ target=""_blank"">" & Convert.ToString(oPost.iPostTitle) & "</a></span>"
                    'if (oPost.SourceURL.Trim().Length > 0)
                    '{
                    '    result = result + "<span class=\"ip_sUri\"><a href=\"" + new Uri(oPost.SourceURL).Host + "\" target=\"_blank\" >" + new Uri(oPost.SourceURL).Host + "</a></span>";
                    '}
                    ' result = result & "<p>" & New Uri(oPost.SourceURL).Host & "</p></span>"
                    result = result & "<span class=""idesc"">" & SociHelper.trimtext(oPost.iPostDescription, 150) & "</span>"

                    result = result & "<div class=""cb""></div></div>"
                    Exit Select
                Case CInt(Utility.ePostType.Video)
                    If oPost.iUpdate.Trim().Length > 0 Then
                        result = result & "<p class=""iupdt"">" & Convert.ToString(oPost.iUpdate) & "</p>"
                    End If
                    result = result & "<div class=""ipv_cnt"">"

                    If oPost.SourceURL.Contains("www.youtube.com") Then
                        Dim youtubeentry As String = GetYoutubeCode(oPost.SourceURL.ToString())
                        result = result & "<object width='250' height='200'>" & vbCr & vbLf & "            <param name='movie' value='http://www.youtube.com/v/" & youtubeentry & "&hl=en_US&fs=1&'>" & vbCr & vbLf & "            </param>" & vbCr & vbLf & "            <param name='allowFullScreen' value='true'></param>" & vbCr & vbLf & "            <param name='allowscriptaccess' value='always'></param>" & vbCr & vbLf & "            <embed src='http://www.youtube.com/v/" & youtubeentry & "&hl=en_US&fs=1&' type='application/x-shockwave-flash'" & vbCr & vbLf & "                allowscriptaccess='always' allowfullscreen='true' width='250' height='200'></embed></object>"
                    Else
                        ' Alter for Video
                        result = result & "<object style='z-index: 1;' id='MediaPlayer1' name='aa1' width='250px' height='200px' autoplay='false' autostart='false' " & vbCr & vbLf & "                        classid='CLSID:22D6F312-B0F6-11D0-94AB-0080C74C7E95' codebase='http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=5,1,52,701'" & vbCr & vbLf & "                        standby='Loading Microsoft® Windows® Media Player components...' type='application/x-oleobject'" & vbCr & vbLf & "                        align='middle'>" & vbCr & vbLf & "                        <param name='filename' value='" & Convert.ToString(oPost.AssetURL) & "' />" & vbCr & vbLf & "                        <param name='showstatusbar' value='true' />" & vbCr & vbLf & "                        <param name='showcontrols' value='true' />" & vbCr & vbLf & "                        <param name='defaultframe' value='mainframe' />" & vbCr & vbLf & "                        <param name='autoplay' value='false' />  " & vbCr & vbLf & "                        <param name='autostart' value='false' />" & vbCr & vbLf & "                                                                       " & vbCr & vbLf & "                        <embed type='application/x-mplayer2' pluginspage='http://microsoft.com/windows/mediaplayer/en/download/'" & vbCr & vbLf & "                            id='mediaPlayer' name='mediaPlayer' displaysize='4' autosize='-1' bgcolor='darkgrey'" & vbCr & vbLf & "                            showcontrols='true' showtracker='-1' showdisplay='0' showstatusbar='-1' videoborder3d='-1'" & vbCr & vbLf & "                            width='250' height='200' src='" & Convert.ToString(oPost.AssetURL) & "' autostart='0' designtimesp='5311'" & vbCr & vbLf & "                            loop='false'></embed>" & vbCr & vbLf & "                    </object>"
                    End If
                    'result = result + System.Web.HttpUtility.HtmlDecode(oPost.SourceEmbed);
                    result = result & "<p>"
                    If oPost.iPostTitle.Trim().Length > 0 Then
                        result = result & "<span class=""itit""><a href=""" & Convert.ToString(oPost.SourceURL) & """ target=""_blank"" >" & Convert.ToString(oPost.iPostTitle) & "</a></span>"
                    End If
                    If oPost.SourceURL.Trim().Length > 0 Then
                        result = result & "<span class=""ip_sUri""><a href=""" & New Uri(oPost.SourceURL).Host & """ target=""_blank"" >" & New Uri(oPost.SourceURL).Host & "</a></span>"
                    End If
                    If oPost.iPostDescription.Trim().Length > 0 Then
                        result = result & "<span class=""idesc"">" & SociHelper.trimtext(oPost.iPostDescription, 100) & "</span>"
                    End If
                    result = result & "</p>"
                    result = result & "</div>"
                    Exit Select
                Case CInt(Utility.ePostType.Text)
                    result = result & "<p>" & Convert.ToString(oPost.iUpdate) & "</p>"
                    Exit Select
                Case CInt(Utility.ePostType.Document)
                    Exit Select
                Case CInt(Utility.ePostType.Music)
                    Exit Select
            End Select
        End If
        Return result
    End Function

End Class