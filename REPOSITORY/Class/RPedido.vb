Imports DATA
Imports ENTITY
Imports REPOSITORY
Imports UTILITIES

Public Class RPedido
    Inherits RBaseTSM
    Implements IPedido

    Public Function ListarPedidoDistribucion(listIdZona As List(Of Integer)) As List(Of VPedido_Dispatch) Implements IPedido.ListarPedidoDistribucion
        Try
            Using db = GetSchema()
                Dim listResult = (From a In db.TO001
                                  Join a1 In db.TO001A On a.oanumi Equals a1.oaato1numi
                                  Join b In db.TC004 On a.oaccli Equals b.ccnumi
                                  Join c In db.TC002 On a1.oaanumiprev Equals c.cbnumi
                                  Where a.oaest = ENEstadoPedido.DICTADO And
                                      listIdZona.Contains(a.oazona) And
                                      Not db.TO001C.Select(Function(aa) aa.oacoanumi).ToList().Contains(a.oanumi)
                                  Select New VPedido_Dispatch With {
                                      .Id = a.oanumi,
                                      .Fecha = a.oafdoc,
                                      .NombreCliente = b.ccdesc,
                                      .NombreVendedor = c.cbdesc
                                      }).ToList()
                Return listResult
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarPedidoAsignadoAChofer(idChofer As Integer) As List(Of VPedido_BillingDispatch) Implements IPedido.ListarPedidoAsignadoAChofer
        Try
            Using db = GetSchema()
                Dim listResult = (From a In db.TO001
                                  Join a1 In db.TO001A On a.oanumi Equals a1.oaato1numi
                                  Join b In db.TC004 On a.oaccli Equals b.ccnumi
                                  Join c In db.TC002 On a1.oaanumiprev Equals c.cbnumi
                                  Join d In db.TO001C On a.oanumi Equals d.oacoanumi
                                  Where a.oaest = ENEstadoPedido.DICTADO And d.oaccbnumi = idChofer
                                  Select New VPedido_BillingDispatch With {
                                      .Id = a.oanumi,
                                      .Fecha = a.oafdoc,
                                      .NombreCliente = b.ccdesc,
                                      .NombreVendedor = c.cbdesc,
                                      .NroFactura = String.Empty
                                      }).ToList()
                Return listResult
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function GuardarPedidoDeChofer(listIdPedido As List(Of Integer), idChofer As Integer) As Boolean Implements IPedido.GuardarPedidoDeChofer
        Try
            Using db = GetSchema()
                For Each id As String In listIdPedido
                    Dim data = New TO001C With
                    {
                        .oacoanumi = id,
                        .oaccbnumi = idChofer
                    }
                    db.TO001C.Add(data)
                Next

                db.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarDespachoXClienteDeChofer(idChofer As Integer) As List(Of RDespachoxCliente) Implements IPedido.ListarDespachoXClienteDeChofer
        Try
            Using db = GetSchema()
                Dim listResult = (From a In db.VR_GO_DespachoXCliente
                                  Where a.oaccbnumi = idChofer
                                  Select New RDespachoxCliente With {
                                      .oaccbnumi = a.oaccbnumi,
                                      .ccnumi = a.ccnumi,
                                      .cccod = a.cccod,
                                      .ccdesc = a.ccdesc,
                                      .oacnrofact = a.oacnrofact,
                                      .obptot = a.obptot
                                      }).ToList()
                Return listResult
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarDespachoXProductoDeChofer(idChofer As Integer) As List(Of RDespachoXProducto) Implements IPedido.ListarDespachoXProductoDeChofer
        Try
            Using db = GetSchema()
                Dim listResult = (From a In db.VR_GO_DespachoXProducto
                                  Where a.oaccbnumi = idChofer
                                  Select New RDespachoXProducto With {
                                      .oaccbnumi = a.oaccbnumi,
                                      .canumi = a.canumi,
                                      .cacod = a.cacod,
                                      .cadesc = a.cadesc,
                                      .cadesc2 = a.cadesc2,
                                      .categoria = a.categoria,
                                      .obpcant = a.obpcant
                                      }).ToList()
                Return listResult
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
