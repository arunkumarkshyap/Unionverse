<%@ Import Namespace="System.Drawing.Imaging" %>
<%@ Import Namespace="System.Drawing" %>

<script language="VB" runat="server">
  Sub Page_Load(sender as Object, e as EventArgs)
  
    'Read in the image filename to create a thumbnail of
        Dim imageUrl as String = Request.QueryString("img")
        Dim height As Integer = Request.QueryString("h")
        Dim width As Integer = Request.QueryString("w")
   
   If not isnothing(imageUrl) andalso imageUrl.Trim.Length > 0 then
   
    'Make sure that the image URL doesn't contain any /'s or \'s
        'If imageUrl.IndexOf("/") >= 0 Or imageUrl.IndexOf("\") >= 0 then
        'We found a / or \
        'Response.End()
        ' End If
    
        'Add on the appropriate directory
        ' imageUrl = "/images/" & imageUrl
    
        'Get the image.    
        Dim fullSizeImg As System.Drawing.Image
        fullSizeImg = System.Drawing.Image.FromFile(Server.MapPath(imageUrl))
        
        'fullSizeImg = fullSizeImg.GetThumbnailImage(width, height, Nothing, IntPtr.Zero)
        
        
        'fullSizeImg = ResizeImage(fullSizeImg, height, width)
        fullSizeImg = ResizeImage2(fullSizeImg, width, height, true)
    
        'Set the ContentType to "image/gif" and output the image's data
        Response.ContentType = "image/jpg"
        fullSizeImg.Save(Response.OutputStream, ImageFormat.Jpeg)
        end if
    End Sub
    Public Function ResizeImage(ByRef postedFile As System.Drawing.Image, ByVal height As Integer, ByVal width As Integer) As System.Drawing.Image
        Dim oImg As System.Drawing.Image
        
        Dim Format As Imaging.ImageFormat = postedFile.RawFormat
        Dim Ratio As Decimal
        Dim NewWidth As Integer
        Dim NewHeight As Integer
        Dim Left As Integer = 0
        Dim Top As Integer = 0

        '*** If the image is smaller than a thumbnail just return it
        If postedFile.Width < width AndAlso postedFile.Height < height Then
            Return postedFile
        End If
        If postedFile.Width > 0 Then
            Ratio = postedFile.Height / postedFile.Width
        End If
        If postedFile.Width < width AndAlso postedFile.Height < height Then
            NewWidth = postedFile.Width
            NewHeight = postedFile.Height
        ElseIf postedFile.Width >= postedFile.Height Then
            NewWidth = width
            NewHeight = CInt(Ratio * width)
            If NewHeight > height Then
                NewHeight = height
                NewWidth = CInt(height / Ratio)
            End If
        ElseIf postedFile.Height > postedFile.Width Then
            NewHeight = height
            NewWidth = CInt(height / Ratio)
            If NewWidth > width Then
                NewWidth = width
                NewHeight = CInt(Ratio * width)
            End If
        End If

        If NewWidth < width Then
            Left = CInt((width - NewWidth) / 2)
        End If

        If NewHeight < height Then
            Top = CInt((height - NewHeight) / 2)
        End If
        
        oImg = postedFile.GetThumbnailImage(NewWidth, NewHeight, Nothing, IntPtr.Zero)

        'bmpOut = New Bitmap(NewWidth, NewHeight)

        'Dim g As Graphics = Graphics.FromImage(bmpOut)
        'g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        'g.CompositingQuality = Drawing2D.CompositingQuality.GammaCorrected
        ' ''g.DrawImage(postedFile, Left, 0, NewWidth, NewHeight)
        'g.DrawImage(postedFile, 0, 0, NewWidth, NewHeight)
        'postedFile.Dispose()

        Return oImg
    End Function
    Public Function ResizeImage2(ByRef originalImage As System.Drawing.Image, ByVal NewWidth As Integer, ByVal MaxHeight As Integer, ByVal OnlyResizeIfWider As Boolean) As System.Drawing.Image
         
        Dim FullsizeImage As System.Drawing.Image = originalImage
        ' Prevent using images internal thumbnail
        FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone)
        FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone)
 
        If OnlyResizeIfWider Then
                          If FullsizeImage.Width < NewWidth then
            NewWidth = FullsizeImage.Width
            End If
        End If                  
 
        Dim NewHeight As Integer = FullsizeImage.Height * NewWidth / FullsizeImage.Width
        If NewHeight > MaxHeight Then
             
            ' Resize with height instead
            NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height
            NewHeight = MaxHeight
        End If
        Dim NewImage As System.Drawing.Image = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, Nothing, IntPtr.Zero)

        'Clear handle to original file so that we can overwrite it if necessary
        FullsizeImage.Dispose()
 
        ' Save resized picture
        Return NewImage
         
    End Function


</script>