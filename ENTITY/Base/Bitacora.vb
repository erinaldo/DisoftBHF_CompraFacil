Public Class Bitacora
    Private _fechaActualizacion As DateTime
    Public Property FechaActualizacion() As DateTime
        Get
            Return _fechaActualizacion
        End Get
        Set(ByVal value As DateTime)
            _fechaActualizacion = value
        End Set
    End Property

    Private _horaActualizacion As String
    Public Property HoraActualizacion() As String
        Get
            Return _horaActualizacion
        End Get
        Set(ByVal value As String)
            _horaActualizacion = value
        End Set
    End Property

    Private _usuarioActualizacion As String
    Public Property UsuarioActualizacion() As String
        Get
            Return _usuarioActualizacion
        End Get
        Set(ByVal value As String)
            _usuarioActualizacion = value
        End Set
    End Property
End Class
