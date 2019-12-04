Imports ENTITY
Imports REPOSITORY

Public Class LZona
    Friend iZona As IZona

    Public Sub New()
        Me.iZona = New RZona()
    End Sub
    Public Function Listar() As List(Of EZona)
        Throw New NotImplementedException()
    End Function

    Public Function ListarCombo() As List(Of VCombo)
        Try
            Return iZona.ListarCombo()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
