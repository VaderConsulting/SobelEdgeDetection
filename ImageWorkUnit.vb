Option Strict On
Option Explicit On

Public Class ImageWorkUnit
    Private _image As Bitmap
    Private _workArea As Rectangle
    Private _result As Bitmap


    Public Sub New(ByVal image As Bitmap, ByVal workArea As Rectangle, ByVal result As Bitmap)
        Me.WorkArea = workArea
        Me.Image = image
        Me.Result = result
    End Sub


    Public Property Result() As Bitmap
        Get
            Return _result
        End Get
        Set(ByVal Value As Bitmap)
            _result = Value
        End Set
    End Property

    Public Property Image() As Bitmap
        Get
            Return _image
        End Get
        Protected Set(ByVal Value As Bitmap)
            _image = Value
        End Set
    End Property

    Public Property WorkArea() As Rectangle
        Get
            Return _workArea
        End Get
        Set(ByVal Value As Rectangle)
            _workArea = Value
        End Set
    End Property


End Class
