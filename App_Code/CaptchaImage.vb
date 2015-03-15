Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Drawing.Text

Public Class CaptchaImage
    ' Public properties (all read-only).
    Private _Text As String
    Private _Image As Bitmap
    Private _width As Integer
    Private _Height As Integer
    Private _familyName As String
    Public ReadOnly Property Text() As String
        Get
            Return _Text
        End Get
    End Property
    Public ReadOnly Property Image() As Bitmap
        Get
            Return _Image
        End Get
    End Property
    Public ReadOnly Property Width() As Integer
        Get
            Return _width
        End Get
    End Property
    Public ReadOnly Property Height() As Integer
        Get
            Return _Height
        End Get
    End Property


    ' For generating random numbers.
    Private oRandom As New Random

    ' ====================================================================
    ' Initializes a new instance of the CaptchaImage class using the
    ' specified text, width and height.
    ' ====================================================================
    Public Sub New(ByVal s As String, ByVal width As Integer, ByVal height As Integer)
        Me._Text = s
        Me.SetDimensions(width, height)
        Me.GenerateImage()
    End Sub

    ' ====================================================================
    ' Initializes a new instance of the CaptchaImage class using the
    ' specified text, width, height and font family.
    ' ====================================================================
    Public Sub New(ByVal s As String, ByVal width As Integer, ByVal height As Integer, ByVal familyName As String)

        Me._Text = s
        Me.SetDimensions(width, height)
        Me.SetFamilyName(familyName)
        Me.GenerateImage()
    End Sub

    ' ====================================================================
    ' This member overrides Object.Finalize.
    ' ====================================================================
    Public Sub finalize()
        Dispose(False)
    End Sub

    ' ====================================================================
    ' Releases all resources used by this object.
    ' ====================================================================
    Public Sub Dispose()
        GC.SuppressFinalize(Me)
        Me.Dispose(True)
    End Sub

    '====================================================================
    ' Custom Dispose method to clean up unmanaged resources.
    ' ====================================================================
    Protected Sub Dispose(ByVal disposing As Boolean)

        If disposing Then
            'Dispose of the bitmap.
            Me.Image.Dispose()
        End If
    End Sub

    ' ====================================================================
    ' Sets the image width and height.
    ' ====================================================================
    Private Sub SetDimensions(ByVal width As Integer, ByVal height As Integer)

        ' Check the width and height.
        If width <= 0 Then
            Throw New ArgumentOutOfRangeException("width", width, "Argument out of range, must be greater than zero.")
        End If
        If height <= 0 Then
            Throw New ArgumentOutOfRangeException("height", height, "Argument out of range, must be greater than zero.")
        End If
        Me._width = width
        Me._Height = height
    End Sub

    ' ====================================================================
    ' Sets the font used for the image text.
    ' ====================================================================
    Private Sub SetFamilyName(ByVal familyName As String)

        ' If the named font is not installed, default to a system font.
        Try

            Dim oFont As Font = New Font(Me._familyName, 12.0F)
            Me._familyName = familyName
            oFont.Dispose()

        Catch ex As Exception
            Me._familyName = System.Drawing.FontFamily.GenericSerif.Name
        End Try
    End Sub

    ' ====================================================================
    ' Creates the bitmap image.
    ' ====================================================================
    Private Sub GenerateImage()

        ' Create a new 32-bit bitmap image.
        Dim oBitmap As Bitmap = New Bitmap(Me._width, Me._Height, PixelFormat.Format32bppArgb)

        ' Create a graphics object for drawing.
        Dim g As Graphics = Graphics.FromImage(oBitmap)
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As Rectangle = New Rectangle(0, 0, Me._width, Me._Height)

        ' Fill in the background.
        Dim ohatchBrush As HatchBrush = New HatchBrush(HatchStyle.SmallConfetti, Color.LightGray, Color.White)
        g.FillRectangle(ohatchBrush, rect)

        ' Set up the text font.
        Dim oSize As SizeF
        Dim fontSize As Decimal = rect.Height + 1
        Dim ofont As Font
        ' Adjust the font size until the text fits within the image.
        Do
            fontSize = fontSize - 1
            ofont = New Font(Me._familyName, fontSize, FontStyle.Bold)
            oSize = g.MeasureString(Me._Text, ofont)
        Loop While oSize.Width > rect.Width
        ' Set up the text format.
        Dim oFormat As StringFormat = New StringFormat
        oFormat.Alignment = StringAlignment.Center
        oFormat.LineAlignment = StringAlignment.Center

        ' Create a path using the text and warp it randomly.
        Dim oPath As GraphicsPath = New GraphicsPath()
        oPath.AddString(Me._Text, ofont.FontFamily, ofont.Style, ofont.Size, rect, oFormat)

        Dim v As Decimal = 4.0F
        Dim points As PointF() = {New PointF(Me.oRandom.Next(rect.Width) / v, Me.oRandom.Next(rect.Height) / v), _
         New PointF(rect.Width - Me.oRandom.Next(rect.Width) / v, Me.oRandom.Next(rect.Height) / v), _
         New PointF(Me.oRandom.Next(rect.Width) / v, rect.Height - Me.oRandom.Next(rect.Height) / v), _
         New PointF(rect.Width - Me.oRandom.Next(rect.Width) / v, rect.Height - Me.oRandom.Next(rect.Height) / v)}

        Dim oMatrix As Matrix = New Matrix()
        oMatrix.Translate(0.0F, 0.0F)
        oPath.Warp(points, rect, oMatrix, WarpMode.Perspective, 0.0F)

        ' Draw the text.
        ohatchBrush = New HatchBrush(HatchStyle.SmallConfetti, Color.LightGray, Color.Black)
        g.FillPath(ohatchBrush, oPath)

        ' Add some random noise.
        Dim m As Integer = Math.Max(rect.Width, rect.Height)
        For i As Integer = 0 To i < CInt(rect.Width * rect.Height / 30.0F)
            Dim x As Integer = Me.oRandom.Next(rect.Width)
            Dim y As Integer = Me.oRandom.Next(rect.Height)
            Dim w As Integer = Me.oRandom.Next(m / 50)
            Dim h As Integer = Me.oRandom.Next(m / 50)
            g.FillEllipse(ohatchBrush, x, y, w, h)
        Next

        ' Clean up.
        ofont.Dispose()
        ohatchBrush.Dispose()
        g.Dispose()

        ' Set the image.
        Me._Image = oBitmap
    End Sub
End Class
