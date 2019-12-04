Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class MetodoDatos

    Public Shared Function CrearComando(Optional Ip As String = "", Optional UsuarioSql As String = "", Optional ClaveSql As String = "", Optional NombreBD As String = "") As SqlCommand
        Dim _cadenaConexion = Configuracion.CadenaConexion(Ip, UsuarioSql, ClaveSql, NombreBD)
        Dim _conexion As New SqlConnection() 'SqlConnection()
        _conexion.ConnectionString = _cadenaConexion
        Dim _comando As New SqlCommand() 'SqlCommand()
        _comando = _conexion.CreateCommand()
        _comando.CommandType = CommandType.Text
        'abrir
        _comando.Connection.Open()
        Return _comando
    End Function
    Public Shared Function CrearComandoProcedimiento(Optional Ip As String = "", Optional UsuarioSql As String = "", Optional ClaveSql As String = "", Optional NombreBD As String = "") As SqlCommand
        Dim _cadenaConexion = Configuracion.CadenaConexion(Ip, UsuarioSql, ClaveSql, NombreBD)
        Dim _conexion As New SqlConnection() 'SqlConnection()
        _conexion.ConnectionString = _cadenaConexion
        Dim _comando As New SqlCommand() 'SqlCommand()
        _comando = _conexion.CreateCommand()
        _comando.CommandType = CommandType.StoredProcedure
        'abrir
        _comando.Connection.Open()
        Return _comando
    End Function

    'Public Shared Function CrearComando() As SqlCommand
    '    Dim _cadenaConexion = Configuracion.CadenaConexion
    '    Dim _conexion As New SqlConnection() 'SqlConnection()
    '    _conexion.ConnectionString = _cadenaConexion
    '    Dim _comando As New SqlCommand() 'SqlCommand()
    '    _comando = _conexion.CreateCommand()
    '    _comando.CommandType = CommandType.Text
    '    'abrir
    '    _comando.Connection.Open()
    '    Return _comando
    'End Function

    'Public Shared Function CrearComandoProcedimiento() As SqlCommand
    '    Dim _cadenaConexion = Configuracion.CadenaConexion
    '    Dim _conexion As New SqlConnection() 'SqlConnection()
    '    _conexion.ConnectionString = _cadenaConexion
    '    Dim _comando As New SqlCommand() 'SqlCommand()
    '    _comando = _conexion.CreateCommand()
    '    _comando.CommandType = CommandType.StoredProcedure
    '    'abrir
    '    _comando.Connection.Open()
    '    Return _comando
    'End Function

    Public Shared Function EjecutarComandoSelect(Comando As SqlCommand) As DataTable
        Dim _tabla As New DataTable()
        Try
            'Comando.Connection.Open()
            Dim _adaptador As New SqlDataAdapter 'SqlDataAdapter()
            _adaptador.SelectCommand = Comando

            _adaptador.Fill(_tabla)
        Catch ex As Exception
            MsgBox(ex.Message)
            'Finally
            '    Comando.Connection.Close()
        End Try
        Return _tabla
    End Function
    Public Shared Function EjecutarInsert(Comando As SqlCommand) As Boolean
        Dim _tabla As New DataTable()
        Dim _Err As Boolean = False

        Dim transaction As SqlTransaction
        transaction = Comando.Connection.BeginTransaction("Insert")
        Comando.Transaction = transaction
        Try
            'Comando.Connection.Open()
            Comando.ExecuteNonQuery()
            transaction.Commit()
        Catch ex As Exception
            transaction.Rollback()
            MsgBox(ex.Message)
            _Err = True
            'Finally
            '    Comando.Connection.Close()
        End Try
        Return _Err
    End Function

    Public Shared Function EjecutarProcedimiento(Comando As SqlCommand) As DataTable
        Dim _tabla As New DataTable()
        Try
            'Comando.Connection.Open()
            Dim _adaptador As New SqlDataAdapter(Comando) 'SqlDataAdapter()

            _adaptador.Fill(_tabla)
        Catch ex As Exception
            MsgBox(ex.Message)
            'Finally
            '    Comando.Connection.Close()
        End Try
        Return _tabla
    End Function

    Public Shared Function EjecutarProcedimientoSABM(Comando As SqlCommand) As Boolean
        Try
            'Comando.Connection.Open()
            Dim i As Integer = Comando.ExecuteNonQuery
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            'Finally
            '    Comando.Connection.Close()
            Return False
        End Try
    End Function
End Class