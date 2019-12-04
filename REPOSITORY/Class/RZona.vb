Imports ENTITY
Imports UTILITIES

Public Class RZona
    Inherits RBaseTSM
    Implements IZona

    Private Function Listar() As List(Of EZona) Implements IZona.Listar
        Throw New NotImplementedException()
    End Function

    Public Function ListarCombo() As List(Of VCombo) Implements IZona.ListarCombo
        Try
            Using db = GetSchema()
                Dim listResult As List(Of VCombo) = (From a In db.VR_GO_ListarZona
                                                     Select New VCombo With {
                                                         .Id = a.numi,
                                                         .Descripcion = a.nzona
                                                         }).ToList()
                Return listResult
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
