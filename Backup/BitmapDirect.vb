Option Strict On
Option Explicit On

Public Class BitmapDirect
    Implements IDisposable

    Dim bmpData As System.Drawing.Imaging.BitmapData
    Dim ptr As IntPtr
    Dim rect As Rectangle
    Dim bytes As Integer
    Dim rgbValues() As Byte
    Private bmp As Bitmap

    '// WARNING: This class was designed for 24bpp image format only
    '// Reference: http://msdn2.microsoft.com/en-us/library/5ey6h79d.aspx

    '// Usage: Create a new BitmapDirect object before working on data
    '//         make desired changes to pixels via Get/Set pixel methods
    '//         dispose BitmapDirect, which unlocks bitmap bits making it usable

    Public Sub New(ByVal bitmap As Bitmap)
        Me.New(bitmap, New Rectangle(0, 0, bitmap.Width, bitmap.Height))
    End Sub

    Public Sub New(ByVal bitmap As Bitmap, ByVal area As Rectangle)
        Me.bmp = bitmap
        rect = area

        '// 24 bpp RGB is forced here intentionally 
        bmpData = bmp.LockBits(rect, _
                    Drawing.Imaging.ImageLockMode.ReadWrite, _
                    Imaging.PixelFormat.Format24bppRgb)

        Dim dx As Integer = bitmap.Width

        bytes = bmpData.Stride * rect.Height
        ptr = bmpData.Scan0
        ReDim rgbValues(bytes - 1)

        ' Copy the RGB values into the array.
        System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes)
    End Sub


    Public Sub SetPixel(ByVal x As Integer, ByVal y As Integer, ByVal intensity As Byte)
        rgbValues(bmpData.Stride * y + x * 3) = intensity
        rgbValues(bmpData.Stride * y + x * 3 + 1) = intensity
        rgbValues(bmpData.Stride * y + x * 3 + 2) = intensity
    End Sub

    Public Sub SetPixel(ByVal x As Integer, ByVal y As Integer, ByVal c As Color)
        '// notice, alpha color data is ignored
        rgbValues(bmpData.Stride * y + x * 3) = c.R
        rgbValues(bmpData.Stride * y + x * 3 + 1) = c.G
        rgbValues(bmpData.Stride * y + x * 3 + 2) = c.B
    End Sub

    Public Function GetPixelIntensity(ByVal x As Integer, ByVal y As Integer) As Single
        Dim c As Color = GetPixel(x, y)
        Return 0.333F * (CSng(c.R) + c.G + c.B)
    End Function

    Public Function GetPixel(ByVal x As Integer, ByVal y As Integer) As Color
        Return Color.FromArgb(rgbValues(bmpData.Stride * y + x * 3), _
                                 rgbValues(bmpData.Stride * y + x * 3 + 1), _
                                 rgbValues(bmpData.Stride * y + x * 3 + 2))
    End Function


#Region "Disposable"

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free managed resources when explicitly called
                ' Copy the RGB values back to the bitmap
                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes)

                ' Unlock the bits.
                bmp.UnlockBits(bmpData)
            End If

            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#End Region

End Class
