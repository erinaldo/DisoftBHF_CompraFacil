Imports ENTITY
Imports REPOSITORY

Public Class LPedido
    Friend iPedido As IPedido

    Public Sub New()
        Me.iPedido = New RPedido()
    End Sub

    Public Function ListarPedidoDistribucion(listIdZona As List(Of Integer)) As List(Of VPedido_Dispatch)
        Try
            Return iPedido.ListarPedidoDistribucion(listIdZona)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarPedidoAsignadoAChofer(idChofer As Integer) As List(Of VPedido_BillingDispatch)
        Try
            Return iPedido.ListarPedidoAsignadoAChofer(idChofer)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function GuardarPedidoDeChofer(listIdPedido As List(Of Integer), idChofer As Integer) As Boolean
        Try
            Return iPedido.GuardarPedidoDeChofer(listIdPedido, idChofer)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarDespachoXClienteDeChofer(idChofer As Integer) As List(Of RDespachoxCliente)
        Try
            Return iPedido.ListarDespachoXClienteDeChofer(idChofer)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarDespachoXProductoDeChofer(idChofer As Integer) As List(Of RDespachoXProducto)
        Try
            Return iPedido.ListarDespachoXProductoDeChofer(idChofer)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
