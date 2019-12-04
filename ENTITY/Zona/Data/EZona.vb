Public Class EZona
    Inherits Bitacora
    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _concepto As Integer
    Public Property Concepto() As Integer
        Get
            Return _concepto
        End Get
        Set(ByVal value As Integer)
            _concepto = value
        End Set
    End Property

    Private _orden As Integer
    Public Property Orden() As Integer
        Get
            Return _orden
        End Get
        Set(ByVal value As Integer)
            _orden = value
        End Set
    End Property

    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
End Class
