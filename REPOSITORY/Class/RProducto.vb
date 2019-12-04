Imports ENTITY
Imports REPOSITORY

Public Class RProducto
    Inherits RBaseTSM
    Implements IProducto

    Public Function ListarProductoXPedido(idPedido As Integer) As List(Of VProducto) Implements IProducto.ListarProductoXPedido
        Try
            Using db = GetSchema()
                Dim listResult As List(Of VProducto) = (From a In db.TC001
                                                        Join b In db.TO0011 On a.canumi Equals b.obcprod
                                                        Where b.obnumi = idPedido
                                                        Select New VProducto With {
                                                            .Id = a.canumi,
                                                            .NombreProducto = a.cadesc,
                                                            .Cantidad = b.obpcant,
                                                            .Precio = b.obpbase,
                                                            .Total = b.obptot
                                                            }).ToList()
                Return listResult
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
