Public Class VPedido_BillingDispatch
    Inherits VPedido

    Private _estaFacturado As Boolean
    Public Property EstaFacturado() As Boolean
        Get
            Return _estaFacturado
        End Get
        Set(ByVal value As Boolean)
            _estaFacturado = value
        End Set
    End Property

    Private _nroFactura As String
    Public Property NroFactura() As String
        Get
            Return _nroFactura
        End Get
        Set(ByVal value As String)
            _nroFactura = value
        End Set
    End Property
End Class
