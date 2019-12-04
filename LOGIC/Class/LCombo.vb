Imports ENTITY
Imports UTILITIES

Public Class LCombo

#Region "Privado, metodos y funciones"
    Private Function AdicionarNoTieneDatos() As VCombo
        Try
            Dim combo As VCombo = New VCombo With
            {
                .Id = ENCombo.ID_NO_TIENE_DATOS,
                .Descripcion = ENCombo.NO_TIENE_DATOS
            }
            Return combo
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region

#Region "Publico, metodos y funciones"
    Public Sub ValidarCombo(ByRef listCombo As List(Of VCombo))
        Try
            If (listCombo Is Nothing) Then
                listCombo = New List(Of VCombo)
                listCombo.Add(AdicionarNoTieneDatos())
                Return
            End If
            If (listCombo.Count = 0) Then
                listCombo = New List(Of VCombo)
                listCombo.Add(AdicionarNoTieneDatos())
                Return
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub AdicionarTodos(ByRef listCombo As List(Of VCombo))
        Try
            Dim combo = listCombo.Where(Function(a) a.Id = ENCombo.ID_NO_TIENE_DATOS).FirstOrDefault()
            If (combo IsNot Nothing) Then
                Return
            End If

            combo = listCombo.Where(Function(a) a.Id = ENCombo.ID_TODOS).FirstOrDefault()
            If (combo Is Nothing) Then
                combo = New VCombo With
                {
                    .Id = ENCombo.ID_TODOS,
                    .Descripcion = ENCombo.TODOS
                }
                listCombo.Insert(0, combo)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub AdicionarNinguno(listCombo As List(Of VCombo))
        Try
            Dim combo = listCombo.Where(Function(a) a.Id = ENCombo.ID_NO_TIENE_DATOS).FirstOrDefault()
            If (combo IsNot Nothing) Then
                Return
            End If

            combo = listCombo.Where(Function(a) a.Id = ENCombo.ID_NINGUNO).FirstOrDefault()
            If (combo Is Nothing) Then
                combo = New VCombo With
                {
                    .Id = ENCombo.ID_NINGUNO,
                    .Descripcion = ENCombo.NINGUNO
                }
                listCombo.Insert(0, combo)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub AdicionarSeleccionar(listCombo As List(Of VCombo))
        Try
            Dim combo = listCombo.Where(Function(a) a.Id = ENCombo.ID_NO_TIENE_DATOS).FirstOrDefault()
            If (combo IsNot Nothing) Then
                Return
            End If

            combo = listCombo.Where(Function(a) a.Id = ENCombo.ID_SELECCIONAR).FirstOrDefault()
            If (combo Is Nothing) Then
                combo = New VCombo With
                {
                    .Id = ENCombo.ID_SELECCIONAR,
                    .Descripcion = ENCombo.SELECCIONAR
                }
                listCombo.Insert(0, combo)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region

End Class
