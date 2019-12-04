Imports ENTITY
Imports REPOSITORY
Imports UTILITIES

Public Class RPersonal
    Inherits RBaseTSM
    Implements IPersonal

    Public Function ListarCombo(tipo As ENTipoPersonal) As List(Of VCombo) Implements IPersonal.ListarCombo
        Try
            Using db = GetSchema()
                Dim listResult As List(Of VCombo) = (From a In db.TC002
                                                     Where a.cbcat = tipo
                                                     Select New VCombo With {
                                                         .Id = a.cbnumi,
                                                         .Descripcion = a.cbdesc
                                                         }).ToList()
                Return listResult
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
