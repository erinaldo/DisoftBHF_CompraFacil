Public Class RDespachoXProducto
    Private _oaccbnumi As Integer
    Public Property oaccbnumi() As Integer
        Get
            Return _oaccbnumi
        End Get
        Set(ByVal value As Integer)
            _oaccbnumi = value
        End Set
    End Property

    Private _canumi As Integer
    Public Property canumi() As Integer
        Get
            Return _canumi
        End Get
        Set(ByVal value As Integer)
            _canumi = value
        End Set
    End Property

    Private _cacod As String
    Public Property cacod() As String
        Get
            Return _cacod
        End Get
        Set(ByVal value As String)
            _cacod = value
        End Set
    End Property

    Private _cadesc As String
    Public Property cadesc() As String
        Get
            Return _cadesc
        End Get
        Set(ByVal value As String)
            _cadesc = value
        End Set
    End Property

    Private _cadesc2 As String
    Public Property cadesc2() As String
        Get
            Return _cadesc2
        End Get
        Set(ByVal value As String)
            _cadesc2 = value
        End Set
    End Property

    Private _categoria As String
    Public Property categoria() As String
        Get
            Return _categoria
        End Get
        Set(ByVal value As String)
            _categoria = value
        End Set
    End Property

    Private _obpcant As Decimal
    Public Property obpcant() As Decimal
        Get
            Return _obpcant
        End Get
        Set(ByVal value As Decimal)
            _obpcant = value
        End Set
    End Property
End Class
