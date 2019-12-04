Imports ENTITY
Imports REPOSITORY

Public Class LProducto
    Friend iProducto As IProducto

    Public Sub New()
        Me.iProducto = New RProducto()
    End Sub

    Public Function ListarProductoXPedido(idPedido As Integer) As List(Of VProducto)
        Try
            Return iProducto.ListarProductoXPedido(idPedido)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
