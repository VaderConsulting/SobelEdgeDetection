Option Strict On
Option Explicit On

''' <summary>
''' Breaks up an image based on the number of available processors and then
''' creates tasks for each
''' </summary>
''' <remarks></remarks>
Public Class Parallelizer
    Private _process As Threading.ParameterizedThreadStart
    Private _image As Bitmap
    Private threads As New Dictionary(Of Threading.Thread, ImageWorkUnit)

    Public Sub New(ByVal image As Bitmap, ByVal process As Threading.ParameterizedThreadStart)
        Me.Image = image
        Me.Process = process
    End Sub


#Region "Properties"

    Public Property Process() As Threading.ParameterizedThreadStart
        Get
            Return _process
        End Get
        Set(ByVal Value As Threading.ParameterizedThreadStart)
            _process = Value
        End Set
    End Property

    Public Property Image() As Bitmap
        Get
            Return _image
        End Get
        Set(ByVal Value As Bitmap)
            _image = Value
        End Set
    End Property

#End Region

    Public Function ExecuteSerial() As Bitmap
        Dim out As New Bitmap(Me.Image.Width, Me.Image.Height, Imaging.PixelFormat.Format32bppArgb)
        Dim segments As List(Of Rectangle) = GetSegments(1, Image.Size)

        For Each segment As Rectangle In segments
            Process.Invoke(New ImageWorkUnit(Me.Image, segment, out))
        Next

        Return out
    End Function

    Public Function ExecuteParallel() As Bitmap
        Dim out As New Bitmap(Me.Image.Width, Me.Image.Height, Imaging.PixelFormat.Format32bppArgb)
        Dim procs As Integer = Environment.ProcessorCount
        Dim segments As List(Of Rectangle)

        segments = GetSegments(procs, Image.Size)

        For Each segment As Rectangle In segments
            Dim work As New ImageWorkUnit(CType(Image.Clone(), Bitmap), segment, CType(out.Clone(), Bitmap))
            AddThread(work)
        Next

        CompileOutput(out)
        Return out
    End Function

    Private Sub CompileOutput(ByVal out As Bitmap)
        Dim g As Graphics = Graphics.FromImage(out)
        Using g
            For Each t As Threading.Thread In Me.threads.Keys
                t.Join()
                g.DrawImage(Me.threads(t).Result, 0, 0)
            Next
        End Using
    End Sub


    Private Sub AddThread(ByVal work As ImageWorkUnit)
        Dim t As New Threading.Thread(Process)
        t.Start(work)
        threads.Add(t, work)
    End Sub

    Private Function GetSegmentsW(ByVal procs As Integer, ByVal size As Size) As List(Of Rectangle)
        Dim w As Integer = size.Width \ procs
        Dim rects As New List(Of Rectangle)
        Dim sum As Integer
        For i As Integer = 0 To procs - 1
            rects.Add(New Rectangle(w * i, 0, w, size.Height))
            sum += w
        Next

        If sum < size.Width Then
            Dim r As Rectangle = rects(rects.Count - 1)
            r = New Rectangle(0, 0, r.Width + size.Width - sum, r.Height)
            rects(rects.Count - 1) = r
        End If

        Return rects
    End Function

    Public Shared Function GetSegments(ByVal procs As Integer, ByVal size As Size) As List(Of Rectangle)
        Dim h As Integer = size.Height \ procs
        Dim rects As New List(Of Rectangle)
        Dim sum As Integer
        For i As Integer = 0 To procs - 1
            rects.Add(New Rectangle(0, h * i, size.Width, h))
            sum += h
        Next

        If sum < size.Height Then
            Dim r As Rectangle = rects(rects.Count - 1)
            r = New Rectangle(r.X, r.Y, r.Width, r.Height + (size.Height - sum))
            rects(rects.Count - 1) = r
        End If

        Return rects
    End Function

End Class
