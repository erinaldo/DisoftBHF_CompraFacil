Imports ENTITY

Public Interface IProducto
    Function ListarProductoXPedido(idPedido As Integer) As List(Of VProducto)
End Interface
