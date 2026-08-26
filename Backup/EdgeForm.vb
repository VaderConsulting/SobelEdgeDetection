Option Strict On
Option Explicit On

Public Class EdgeForm

    Dim xMask(,) As Single = New Single(,) {{-1, 0, 1}, _
                                            {-2, 0, 2}, _
                                            {-1, 0, 1}}

    Dim yMask(,) As Single = New Single(,) {{1, 2, 1}, _
                                            {0, 0, 0}, _
                                            {-1, -2, -1}}

    Function DetectEdges(ByVal inImg As Bitmap) As Bitmap
        Dim out As New Bitmap(inImg.Width, inImg.Height, Imaging.PixelFormat.Format32bppArgb)

        For y As Integer = 0 To inImg.Height - 1
            For x As Integer = 0 To inImg.Width - 1
                Dim gradX As Single = 0
                Dim gradY As Single = 0
                Dim grad As Single = 0

                If x = 0 Or y = 0 Or x = inImg.Width - 1 Or y = inImg.Height - 1 Then
                    grad = 0
                Else
                    For i As Integer = -1 To 1
                        For j As Integer = -1 To 1
                            Dim p As Color = inImg.GetPixel(x + i, y + j)
                            Dim intensity As Single = 0.333F * (CInt(p.R) + p.G + p.B)
                            '// approximate X gradient
                            gradX += intensity * xMask(i + 1, j + 1)
                            '// approximate Y gradient
                            gradY += intensity * yMask(i + 1, j + 1)
                        Next
                    Next

                    grad = (Math.Abs(gradX) + Math.Abs(gradY))
                    '   grad = grad / 100
                End If

                grad = Math.Max(0, grad)
                '// could easily add a threshold here:
                '// If grad < 100 Then
                '//     grad = 0
                '// End If

                grad = Math.Min(255, grad)

                'grad = 255 - grad

                out.SetPixel(x, y, Color.FromArgb(CInt(grad), CInt(grad), CInt(grad)))
            Next

            Me.pbAfter.Image = out
            Me.pbAfter.Refresh()
        Next

        Return out
    End Function

    Function DetectEdges2(ByVal inImg As Bitmap) As Bitmap
        Dim out As New Bitmap(inImg.Width, inImg.Height, Imaging.PixelFormat.Format32bppArgb)
        Dim bOut As New BitmapDirect(out)
        Dim bIn As New BitmapDirect(inImg)

        Using bOut
            Using bIn
                '// use these variables instead to see the performance increase
                'Dim iH As Integer = inImg.Height - 1
                'Dim iW As Integer = inImg.Width - 1

                For y As Integer = 0 To inImg.Height - 1
                    For x As Integer = 0 To inImg.Width - 1
                        Dim gradX As Single = 0
                        Dim gradY As Single = 0
                        Dim grad As Single = 0

                        If x = 0 Or y = 0 Or x = inImg.Width - 1 Or y = inImg.Height - 1 Then
                            grad = 0
                        Else
                            For i As Integer = -1 To 1
                                For j As Integer = -1 To 1
                                    Dim intensity As Single = bIn.GetPixelIntensity(x + i, y + j)
                                    gradX += intensity * xMask(i + 1, j + 1)
                                    gradY += intensity * yMask(i + 1, j + 1)
                                Next
                            Next

                            grad = (Math.Abs(gradX) + Math.Abs(gradY))
                        End If

                        grad = Math.Max(0, grad)
                        grad = Math.Min(255, grad)

                        bOut.SetPixel(x, y, CByte(grad))
                    Next
                Next
            End Using
        End Using

        Return out
    End Function

    Sub DetectEdges2Par(ByVal o As Object)
        Dim work As ImageWorkUnit = CType(o, ImageWorkUnit)
        Dim inImg As Bitmap = work.Image
        Dim outImg As Bitmap = work.Result
        Dim area As Rectangle = work.WorkArea
        Dim bOut As New BitmapDirect(outImg, area)
        Dim bIn As New BitmapDirect(inImg, area)

        Using bOut
            Using bIn

                For y As Integer = 0 To area.Height - 1
                    For x As Integer = 0 To area.Width - 1
                        Dim gradX As Single = 0
                        Dim gradY As Single = 0
                        Dim grad As Single = 0

                        For i As Integer = -1 To 1
                            For j As Integer = -1 To 1
                                If x + i < 0 OrElse x + i > area.Width - 1 Or y + j < 0 OrElse y + j > area.Height - 1 Then
                                    Dim xi As Integer = Math.Min(Math.Max(0, x + i), area.Width - 1)
                                    Dim yj As Integer = Math.Min(Math.Max(0, y + j), area.Height - 1)
                                    Dim intensity As Single = bIn.GetPixelIntensity(xi, yj)
                                    gradX += intensity * xMask(i + 1, j + 1)
                                    gradY += intensity * yMask(i + 1, j + 1)
                                ElseIf y + j < 0 OrElse y + j > area.Height - 1 Then
                                    Dim yj As Integer = Math.Min(Math.Max(0, y + j), area.Height - 1)
                                    Dim intensity As Single = bIn.GetPixelIntensity(x + i, yj)
                                    gradY += intensity * yMask(i + 1, j + 1)
                                Else
                                    Dim intensity As Single = bIn.GetPixelIntensity(x + i, y + j)
                                    gradX += intensity * xMask(i + 1, j + 1)
                                    gradY += intensity * yMask(i + 1, j + 1)
                                End If
                            Next
                        Next

                        grad = (Math.Abs(gradX) + Math.Abs(gradY))

                        grad = Math.Max(0, grad)

                        '// could easily add a threshold here:
                        '// If grad < 100 Then
                        '//     grad = 0
                        '// End If

                        grad = Math.Min(255, grad)
                        bOut.SetPixel(x, y, CByte(grad))
                    Next
                Next

            End Using
        End Using
    End Sub


    Private Sub BmpDirectTest(ByVal bmp As Bitmap)
        Dim b As New BitmapDirect(bmp)

        Using b
            For y As Integer = 0 To bmp.Height - 1
                For x As Integer = 0 To bmp.Width - 1
                    b.SetPixel(x, y, CByte(b.GetPixelIntensity(x, y)))
                Next
            Next
        End Using
    End Sub



    Sub SafeDispose(ByRef d As IDisposable)
        If Not d Is Nothing Then
            d.Dispose()
        End If
    End Sub

    Sub ShowPixelSpeed(ByVal pixels As Integer, ByVal time As Double)
        MsgBox(FormatNumber(pixels / 1000 / time, 2) & " K Pixels per second")
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Try
            ofdLoadImage.FileName = ""
            ofdLoadImage.ShowDialog()
            If ofdLoadImage.FileName = "" Then Return

            If Not Me.pbBefore.Image Is Nothing Then
                Me.pbBefore.Image.Dispose()
            End If

            Me.pbBefore.Image = Image.FromFile(ofdLoadImage.FileName) 'New Bitmap(ofdLoadImage.FileName)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnDetectDirect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetectDirect.Click
        SafeDispose(CType(Me.pbAfter.Image, IDisposable))
        Me.pbAfter.Image = Nothing
        Me.pbAfter.Refresh()
        Dim t As New VisualCore.Utilities.PrecisionTimer()
        t.Start()
        Me.pbAfter.Image = DetectEdges2(CType(Me.pbBefore.Image, Bitmap))
        ShowPixelSpeed(pbAfter.Image.Width * pbAfter.Image.Height, t.GetElapsedTime)
        Me.pbAfter.Refresh()
    End Sub

    Private Sub btnDetectGdi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetectGdi.Click
        SafeDispose(CType(Me.pbAfter.Image, IDisposable))
        Me.pbAfter.Image = Nothing
        Me.pbAfter.Refresh()
        Dim t As New VisualCore.Utilities.PrecisionTimer()
        t.Start()
        Me.pbAfter.Image = DetectEdges(CType(Me.pbBefore.Image, Bitmap))
        ShowPixelSpeed(pbAfter.Image.Width * pbAfter.Image.Height, t.GetElapsedTime)
        Me.pbAfter.Refresh()
    End Sub

    Private Sub btnPar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPar.Click
        SafeDispose(CType(Me.pbAfter.Image, IDisposable))
        Me.pbAfter.Image = Nothing
        Me.pbAfter.Refresh()
        Dim t As New VisualCore.Utilities.PrecisionTimer()
        t.Start()

        Dim p As New Parallelizer(CType(Me.pbBefore.Image, Bitmap), AddressOf DetectEdges2Par)

        Me.pbAfter.Image = p.ExecuteParallel()
        ShowPixelSpeed(pbAfter.Image.Width * pbAfter.Image.Height, t.GetElapsedTime)
        Me.pbAfter.Refresh()
    End Sub

    Private Sub btnSerial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerial.Click
        SafeDispose(CType(Me.pbAfter.Image, IDisposable))
        Me.pbAfter.Image = Nothing
        Me.pbAfter.Refresh()
        Dim t As New VisualCore.Utilities.PrecisionTimer()
        t.Start()

        Dim p As New Parallelizer(CType(Me.pbBefore.Image, Bitmap), AddressOf DetectEdges2Par)

        Me.pbAfter.Image = p.ExecuteSerial()
        ShowPixelSpeed(pbAfter.Image.Width * pbAfter.Image.Height, t.GetElapsedTime)
        Me.pbAfter.Refresh()
    End Sub
End Class
