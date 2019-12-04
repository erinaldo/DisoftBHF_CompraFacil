Imports ENTITY
Imports REPOSITORY
Imports UTILITIES

Public Class LPersonal
    Friend iPersonal As IPersonal

    Public Sub New()
        Me.iPersonal = New RPersonal()
    End Sub

#Region "Privado, metodos y funciones"
    Private Function ListarCombo(tipo As ENTipoPersonal) As List(Of VCombo)
        Try
            Dim lCombo = New LCombo()
            Dim listResult = iPersonal.ListarCombo(tipo)
            
            lCombo.ValidarCombo(listResult)
            lCombo.AdicionarSeleccionar(listResult)

            Return listResult
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region

#Region "Publico, metodos y funciones"
    Public Function ListarRepatidorCombo() As List(Of VCombo)
        Try
            Return ListarCombo(ENTipoPersonal.REPARTIDOR)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
End Class
