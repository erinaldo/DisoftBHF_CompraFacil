Imports System.Data
Imports System.Data.SqlClient 'Se cambio SqlCommand por OLeDBCommand
Imports System.Data.OleDb
Public Class AccesoDatos
    Shared _comando As SqlCommand
    Shared _comandoProcedimiento As SqlCommand

    Public Shared Sub D_abrirConexion(Optional Ip As String = "", Optional UsuarioSql As String = "", Optional ClaveSql As String = "", Optional NombreBD As String = "")
        _comando = MetodoDatos.CrearComando(Ip, UsuarioSql, ClaveSql, NombreBD)
        _comandoProcedimiento = MetodoDatos.CrearComandoProcedimiento(Ip, UsuarioSql, ClaveSql, NombreBD)
    End Sub

    'Public Shared Sub D_abrirConexion()
    '    _comando = MetodoDatos.CrearComando()
    '    _comandoProcedimiento = MetodoDatos.CrearComandoProcedimiento()
    'End Sub

    Public Shared Function D_Datos_Tabla(_Campos As String, _Tabla As String, _Where As String) As DataTable
        'Dim _comando As OleDbCommand = MetodoDatos.CrearComando()
        _comando.CommandText = "SELECT " + _Campos + " FROM " + _Tabla + " WHERE " + _Where
        Return MetodoDatos.EjecutarComandoSelect(_comando)
    End Function
    Public Shared Function D_Maximo(_Tabla As String, _Campo As String, _Where As String) As DataTable
        'Dim _comando As OleDbCommand = MetodoDatos.CrearComando()
        _comando.CommandText = "SELECT MAX(" + _Campo + ") FROM " + _Tabla + " WHERE " + _Where
        Return MetodoDatos.EjecutarComandoSelect(_comando)
    End Function
    Public Shared Function D_Sum(_Tabla As String, _Where As String, _Campo1 As String, Optional _Campo2 As String = "") As DataTable
        'Dim _comando As OleDbCommand = MetodoDatos.CrearComando()
        Dim Sql As String
        Sql = "SELECT SUM(" + _Campo1 + ")"
        If _Campo2 <> "" Then
            Sql = Sql + ", SUM(" + _Campo2 + ")"
        End If
        _comando.CommandText = Sql + " FROM " + _Tabla + " WHERE " + _Where
        Return MetodoDatos.EjecutarComandoSelect(_comando)
    End Function
    Public Shared Function D_Insertar_Datos(_Tabla As String, _Campos As String) As Boolean
        'Dim _comando As OleDbCommand = MetodoDatos.CrearComando()
        _comando.CommandText = "Insert Into " + _Tabla + " Values(" + _Campos + ")"

        Return MetodoDatos.EjecutarInsert(_comando)
        'Return D_ProcedimientoABM("Sp_Insert", _comando.CommandText)
    End Function
    Public Shared Function D_Modificar_Datos(_Tabla As String, _Campos As String, _Where As String) As Boolean
        'Dim _comando As OleDbCommand = MetodoDatos.CrearComando()
        _comando.CommandText = "Update " + _Tabla + " Set " + _Campos + " Where " + _Where

        Return MetodoDatos.EjecutarInsert(_comando)

    End Function
    Public Shared Function D_Eliminar_Datos(_Tabla As String, _Where As String) As Boolean
        'Dim _comando As OleDbCommand = MetodoDatos.CrearComando()
        _comando.CommandText = "Delete From " + _Tabla + " Where " + _Where

        Return MetodoDatos.EjecutarInsert(_comando)

    End Function

    Public Shared Function D_ProcedimientoABM(_Nombre As String, _Query As String) As Boolean
        _comandoProcedimiento = MetodoDatos.CrearComandoProcedimiento()
        _comandoProcedimiento.CommandText = _Nombre
        _comandoProcedimiento.CommandType = CommandType.StoredProcedure
        _comandoProcedimiento.Parameters.Add("@sql", SqlDbType.NVarChar, _Query.Length)
        _Query = "N'" + _Query.Replace("'", "''") + "'"

        _comandoProcedimiento.Parameters("@sql").Value = _Query

        Return MetodoDatos.EjecutarProcedimientoSABM(_comandoProcedimiento)
    End Function

    Public Shared Function D_Procedimiento(_Nombre As String) As DataTable
        _comandoProcedimiento.Parameters.Clear()
        _comandoProcedimiento.CommandText = _Nombre
        _comandoProcedimiento.CommandType = CommandType.StoredProcedure

        Return MetodoDatos.EjecutarProcedimiento(_comandoProcedimiento)
    End Function

    Public Shared Function D_ProcedimientoConParam(_Nombre As String, _listaParam As List(Of DParametro)) As DataTable
        _comandoProcedimiento.Parameters.Clear()
        _comandoProcedimiento.CommandText = _Nombre

        For i = 0 To _listaParam.Count - 1
            Dim nombre As String = _listaParam.Item(i).nombre
            Dim valor As String = _listaParam.Item(i).valor
            Dim detalle As DataTable = _listaParam.Item(i).detalle

            If IsNothing(detalle) Then
                _comandoProcedimiento.Parameters.AddWithValue(nombre.Trim, valor)
            Else
                _comandoProcedimiento.Parameters.Add(nombre, SqlDbType.Structured)
                _comandoProcedimiento.Parameters(nombre).Value = detalle
            End If

        Next

        Return MetodoDatos.EjecutarProcedimiento(_comandoProcedimiento)
    End Function
End Class


