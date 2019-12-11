
Imports System.Data
Imports System.Data.SqlClient
Imports Datos.AccesoDatos
Imports Datos.DParametro
Imports Entidades


Public Class AccesoLogica

#Region "constantes"
    Const conConcepReclamo As String = "13"
#End Region

    Public Shared L_Usuario As String = "UD"

    '////////////////////////////////////////////codigo trabajado/////////////////////////////////////////////////////////
    Public Shared Sub L_prAbrirConexion(Optional Ip As String = "", Optional UsuarioSql As String = "", Optional ClaveSql As String = "", Optional NombreBD As String = "")
        D_abrirConexion(Ip, UsuarioSql, ClaveSql, NombreBD)
    End Sub

    'Public Shared Sub L_abrirConexion()
    '    D_abrirConexion()
    'End Sub

#Region "Validar eliminación"

    Public Shared Function L_fnbValidarEliminacion(_numi As String, _tablaOri As String, _campoOri As String, ByRef _respuesta As String) As Boolean
        Dim _Tabla As DataTable
        Dim _Where, _campos As String
        _Where = "bbtori='" + _tablaOri + "' and bbtran=1"
        _campos = "bbnumi,bbtran,bbtori,bbcori,bbtdes,bbcdes,bbprog"
        _Tabla = D_Datos_Tabla(_campos, "TB002", _Where)
        _respuesta = "no se puede eliminar el registro: ".ToUpper + _numi + " por que esta siendo usado en los siguientes programas: ".ToUpper + vbCrLf

        Dim result As Boolean = True
        For Each fila As DataRow In _Tabla.Rows
            If L_fnbExisteRegEnTabla(_numi, fila.Item("bbtdes").ToString, fila.Item("bbcdes").ToString) = True Then
                _respuesta = _respuesta + fila.Item("bbprog").ToString + vbCrLf
                result = False
            End If
        Next
        Return result
    End Function

    Private Shared Function L_fnbExisteRegEnTabla(_numiOri As String, _tablaDest As String, _campoDest As String) As Boolean
        Dim _Tabla As DataTable
        Dim _Where, _campos As String
        _Where = _campoDest + "=" + _numiOri
        _campos = _campoDest
        _Tabla = D_Datos_Tabla(_campos, _tablaDest, _Where)
        If _Tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

#End Region

#Region "Meseros"
    Public Shared Sub L_Grabar_Meseros(ByRef _id As String, _ci As String, _nombre As String, _estado As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean

        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TC006", "cfId", "cfId = cfId")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _id = _Tabla.Rows(0).Item(0) + 1
        Else
            _id = "1"
        End If

        _Actualizacion = "'" + Left(Today.Date.ToString, 10) + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"
        Dim Sql As String
        Sql = "'" + _nombre + "','" + _ci + "','" + _estado + "'," + _Actualizacion
        _Err = D_Insertar_Datos("TC006 (cfNom,cfCI,cfest,cffact,cfhact,cfuact )", Sql)
    End Sub
    Public Shared Function L_MeserosGeneral(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " TC006.cfId = TC006.cfId"
        Else
            _Where = _Cadena
        End If
        _Tabla = D_Datos_Tabla("*", "TC006", _Where + " order by cfId")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    Public Shared Sub L_modificar_Meseros(ByRef _id As String, _ci As String, _nombre As String, _estado As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "cfNom ='" + _nombre + "', " +
        "cfCI ='" + _ci + "', " +
        "cfest = '" + _estado + "', " +
        "cffact = '" + Left(Today.Date.ToString, 10) + "', " +
        "cfhact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "cfuact = '" + "CARLOS" + "'"

        _where = "cfId = " + _id
        _Err = D_Modificar_Datos("TC006", Sql, _where)
    End Sub

    Public Shared Sub L_Borrar_Meseros(_Id As String)

        Dim _Where As String
        Dim _Err As Boolean

        _Where = "cfId = " + _Id
        _Err = D_Eliminar_Datos("TC006", _Where)

    End Sub

    Public Shared Function L_VerificarRelacion_Meseros(_id As String) As String
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla("TO001.oaId", "TO001", "oagar =" + _id)
        If _Tabla.Rows.Count > 0 Then
            Return _Tabla.Rows(0).Item(0)
        Else
            Return ""
        End If
    End Function

#End Region

#Region "Libreria"
    Public Shared Function L_General_LibreriaCabecera(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " TC005.cdId = TC005.cdId and TC005.cdver=1"
        Else
            _Where = _Cadena
        End If
        _Tabla = D_Datos_Tabla("*", "TC005", _Where + " order by cdId")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    'Public Shared Function L_General_LibreriaDetalle(_Modo As Integer, Optional _Cadena As String = "") As DataSet
    '    Dim _Tabla As DataTable
    '    Dim _Ds As New DataSet
    '    Dim _Where As String
    '    If _Modo = 0 Then
    '        _Where = " TC0051.cecon = TC0051.cecon and cenum>0 "
    '    Else
    '        _Where = "TC0051.cecon = " + _Cadena + " AND " +
    '                 "TC005.cdcon=TC0051.cecon and cenum>0 "
    '    End If
    '    _Tabla = D_Datos_Tabla("TC0051.ceid,TC0051.cecon,TC0051.cenum,TC0051.cedesc", "TC005,TC0051", _Where + " order by TC0051.cenum")
    '    _Ds.Tables.Add(_Tabla)
    '    Return _Ds
    'End Function
    Public Shared Function L_General_LibreriaDetalle(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " TC0051.cecon = TC0051.cecon and cenum>0 "
        Else
            _Where = "TC0051.cecon = " + _Cadena + " AND " +
                     "TC005.cdcon=TC0051.cecon and cenum>0 "
        End If
        _Tabla = D_Datos_Tabla("TC0051.ceid, TC0051.cecon,TC0051.cenum, TC0051.cedesc", "TC005, TC0051", _Where + " order by TC0051.ceid")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_General_LibreriaCategoria(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        'If _Modo = 0 Then
        '    _Where = " TC0051.cecon = TC0051.cecon and cenum>0 "
        'Else
        '    _Where = "TC0051.cecon = " + _Cadena + " AND " +
        '             "TC005.cdcon=TC0051.cecon and cenum>0 "
        'End If
        _Tabla = D_Datos_Tabla("0,0,TC005C.canumi,TC005C.canombre", "TC005C", " canumi = canumi order by TC005C.canumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_Grabar_LibreriaCabecera(ByRef _id As String, ByRef _codConcep As String, _descr As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TC005", "cdid", "cdid=cdid")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _codConcep = _Tabla.Rows(0).Item(0) + 1
        Else
            _codConcep = "1"
        End If
        _id = _codConcep
        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"
        Dim Sql As String
        Sql = _id + "," + _codConcep + ",'" + _descr + "'," + _Actualizacion
        _Err = D_Insertar_Datos("TC005 (cdid,cdcon,cddesc,cdfact,cdhact,cduact)", Sql)
    End Sub
    Public Shared Sub L_Grabar_LibreriaDetalle(ByRef _id As String, ByRef _codConcep As String, ByRef _num As String, _descr As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TC0051", "cenum", "cenum=cenum and cecon=" + _codConcep)
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _num = _Tabla.Rows(0).Item(0) + 1
        Else
            _num = "1"
        End If


        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"
        Dim Sql As String
        Sql = _codConcep + "," + _num + ",'" + _descr + "'," + _Actualizacion
        _Err = D_Insertar_Datos("TC0051 (cecon,cenum,cedesc,cefact,cehact,ceuact)", Sql)
    End Sub
    Public Shared Sub L_Modificar_LibreriasCabecera(_id As String, _con As String, _desc As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "cdcon =" + _con + ", " +
        "cddesc ='" + _desc + "', " +
        "cdfact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "cdhact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "cduact = '" + "DANNY" + "'"

        _where = "cdid = " + _id
        _Err = D_Modificar_Datos("TC005", Sql, _where)
    End Sub
    Public Shared Sub L_Modificar_LibreriasDetalle(_id As String, _con As String, _num As String, _desc As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "cecon =" + _con + ", " +
        "cenum =" + _num + ", " +
        "cedesc ='" + _desc + "', " +
        "cefact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "cehact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "ceuact = '" + "DANNY" + "'"

        _where = "ceid = " + _id
        _Err = D_Modificar_Datos("TC0051", Sql, _where)
    End Sub
    Public Shared Sub L_Borrar_LibreriasCabecera(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean

        _Where = "cdId = " + _Id
        _Err = D_Eliminar_Datos("TC005", _Where)
        _Err = D_Eliminar_Datos("TC0051", "cecon=" + _Id)
    End Sub
    Public Shared Sub L_Borrar_LibreriasDetalle(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean

        _Where = "ceId = " + _Id
        _Err = D_Eliminar_Datos("TC0051", _Where)
    End Sub
    Public Shared Function L_Validar_Librerias(_codConcepto As Integer, _numeracion As String) As String
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla("cedesc", "TC0051", "cecon = " + Str(_codConcepto) + " AND " + "cenum = " + _numeracion)
        If _Tabla.Rows.Count > 0 Then
            Return _Tabla.Rows(0).Item(0)
        Else
            Return ""
        End If
    End Function

    Public Shared Function L_Validar_LibreriasDetalle(_codConcepto As Integer, _numeracion As String) As String
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla("cedesc", "TC0051", "cecon = " + Str(_codConcepto) + " AND " + "cenum = " + _numeracion)
        If _Tabla.Rows.Count > 0 Then
            Return _Tabla.Rows(0).Item(0)
        Else
            Return ""
        End If
    End Function
#End Region

#Region "NivelesLibrerias"
    Public Shared Function L_General_NivelesLibreriasCabecera(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " TC006.cfid = TC006.cfId"
        Else
            _Where = _Cadena
        End If
        _Tabla = D_Datos_Tabla("*", "TC006", _Where + " order by cfId")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    Public Shared Function L_General_NivelesLibreriasDetalle(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " TC0061.cgcfid = TC0061.cgcfid"
        Else
            'consulto con el cod del producto(cadena)
            _Where = "TC0061.cgcfid = " + _Cadena + "AND TC0061.cgcon=TC005.cdcon"
        End If
        _Tabla = D_Datos_Tabla("TC0061.cgcfid,TC0061.cgcon,TC005.cddesc,TC0061.cgconp", "TC005,TC0061", _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    Public Shared Sub L_Grabar_NivelesLibreriasCabecera(ByRef _id As String, _descr As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TC006", "cfid", "cfid=cfid")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _id = _Tabla.Rows(0).Item(0) + 1
        Else
            _id = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"
        Dim Sql As String
        Sql = _id + ",'" + _descr + "'," + _Actualizacion
        _Err = D_Insertar_Datos("TC006 (cfid,cfdesc,cffact,cfhact,cfuact)", Sql)
    End Sub
    Public Shared Sub L_Grabar_NivelesLibreriasDetalle(ByRef _idCabecera As String, ByRef _idConcep As String, _idConPadre As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        'Dim _Tabla As DataTable
        '_Tabla = D_Maximo("TC0061", "cenum", "cenum=cenum and cecon=" + _codConcep)
        'If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
        '    _num = _Tabla.Rows(0).Item(0) + 1
        'Else
        '    _num = "1"
        'End If
        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"
        Dim Sql As String
        Sql = _idCabecera + "," + _idConcep + "," + _idConPadre + "," + _Actualizacion
        _Err = D_Insertar_Datos("TC0061 (cgcfid,cgcon,cgconp,cgfact,cghact,cguact)", Sql)
    End Sub
    Public Shared Sub L_Modificar_NivelesLibreriasCabecera(_id As String, _desc As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "cfdesc ='" + _desc + "', " +
        "cffact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "cfhact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "cfuact = '" + "DANNY" + "'"

        _where = "cfid = " + _id
        _Err = D_Modificar_Datos("TC006", Sql, _where)
    End Sub
    Public Shared Sub L_Modificar_NivelesLibreriasDetalle(_id As String, _con As String, _num As String, _desc As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "cecon =" + _con + ", " +
        "cenum =" + _num + ", " +
        "cedesc ='" + _desc + "', " +
        "cefact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "cehact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "ceuact = '" + "DANNY" + "'"

        _where = "ceid = " + _id
        _Err = D_Modificar_Datos("TC0051", Sql, _where)
    End Sub
    Public Shared Sub L_Borrar_NivelesLibreriasCabecera(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean

        _Where = "cfId = " + _Id
        _Err = D_Eliminar_Datos("TC006", _Where)
        _Err = D_Eliminar_Datos("TC0061", "cgcfid=" + _Id)
    End Sub
    Public Shared Sub L_Borrar_NivelesLibreriasDetalle(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean

        _Where = "cgcfId = " + _Id
        _Err = D_Eliminar_Datos("TC0061", _Where)
    End Sub
    'Public Shared Function L_Validar_NivelesLibrerias(_codConcepto As Integer, _numeracion As String) As String
    '    Dim _Tabla As DataTable
    '    _Tabla = D_Datos_Tabla("cedesc", "TC005", "cecon = " + Str(_codConcepto) + " AND " + "cenum = " + _numeracion)
    '    If _Tabla.Rows.Count > 0 Then
    '        Return _Tabla.Rows(0).Item(0)
    '    Else
    '        Return ""
    '    End If
    'End Function

#End Region

#Region "Farmacia Nota Entrega"
    Public Shared Function L_VistaNotaEntrega(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " TC006.cfid = TC006.cfId"
        Else
            _Where = "((TS001.saclen)=TY004.ydper) And ((TY004.ydcli)=1) And ((TS001.sanumi)=TS0011.sbnumi) And ((TS0011.sbcprod)=TY005.yfcprod)" +
                    " AND " + "(TS001.sanumi=" + _Cadena + " )"
        End If
        Dim campos As String
        campos = "TS001.sanfac, TY004.ydnom1, TY004.yddirec, TY004.ydtelef, TS001.safdoc, TS001.saclen, TS001.saven, TS0011.sbcmin, TY005.yfcdprod1, TS0011.sbpbas, TS0011.sbptot, TS001.sadesc1, TS001.safvcr, TS001.satdoc"
        _Tabla = D_Datos_Tabla(campos, "TS001, TS0011, TY005, TY004", _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
#End Region

#Region "Zona"

    Public Shared Function L_ZonaCabecera_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "lanumi=lanumi"
        Else
            _Where = _Cadena
        End If
        _Tabla = D_Datos_Tabla("*", "TL001", _Where + " order by lanumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    Public Shared Function L_ZonaCabecera_GeneralCompleto(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "lanumi=lanumi and lacity = c.cenum  and b.cdcon = c.cecon  and b.cdcon = 4 " _
                    + " and laprovi = cc.cenum  and bb.cdcon = cc.cecon  and bb.cdcon = 3 " _
                    + " and lazona = ccc.cenum  and bbb.cdcon = ccc.cecon  and bbb.cdcon = 2 " _
                    + " and lcnumi = lanumi and lccbnumi = cbnumi"
        Else
            _Where = _Cadena
        End If
        _Tabla = D_Datos_Tabla("lccbnumi, cbdesc, lanumi, lacity, c.cedesc, laprovi, cc.cedesc, lazona, ccc.cedesc, lacolor", "TL001,TC002,TL0012,TC005 b, TC005 bb, TC005 bbb, TC0051 c, TC0051 cc, TC0051 ccc", _Where + " order by lanumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    Public Shared Function L_ZonaCabecera_GeneralCompleto1(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "lacity = c.cenum  and b.cdcon = c.cecon  and b.cdcon = 4 " _
                    + " and laprovi = cc.cenum  and bb.cdcon = cc.cecon  and bb.cdcon = 3 " _
                    + " and lazona = ccc.cenum  and bbb.cdcon = ccc.cecon  and bbb.cdcon = 2 "
        Else
            _Where = _Cadena
        End If
        _Tabla = D_Datos_Tabla("lanumi, lacity ,c.cedesc as ncity, laprovi, cc.cedesc as nprovi, lazona, ccc.cedesc as nzona, lacolor", "TL001,TC005 b, TC005 bb, TC005 bbb, TC0051 c, TC0051 cc, TC0051 ccc", _Where + " order by lanumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    Public Shared Function L_ZonaDetallePuntos_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " lbnumi = lbnumi"
        Else
            'consulto con el cod del producto(cadena)
            _Where = "lbnumi = " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("*", "TL0013", _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_ZonaDetalleRepartidor_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " lcnumi = lcnumi"
        Else
            'consulto con el cod del producto(cadena)
            _Where = "lcnumi = " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("*", "TL0012", _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_fnObtenerRepartidor(codZona As String) As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String = "a.lcnumi = " + codZona

        _Tabla = D_Datos_Tabla("a.lcnumi, a.lccbnumi",
                               "TL0012 a inner Join TC002 b on a.lccbnumi=b.cbnumi And b.cbcat=1",
                               _Where)

        Return _Tabla
    End Function

    Public Shared Function L_ZonaDetalleRepartidor_GeneralCompleto(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " lcnumi = lcnumi AND lccbnumi=cbnumi AND cbcat=1"
        Else
            'consulto con el cod del producto(cadena)
            _Where = "lccbnumi=cbnumi AND cbcat=1 AND lcnumi = " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("lcnumi,lccbnumi,cbdesc", "TL0012,TC002", _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    Public Shared Sub L_ZonaDetalleRepartidor_Grabar(_idCabecera As String, _codRepartidor As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        'Dim _Tabla As DataTable
        '_Tabla = D_Maximo("TC0061", "cenum", "cenum=cenum and cecon=" + _codConcep)
        'If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
        '    _num = _Tabla.Rows(0).Item(0) + 1
        'Else
        '    _num = "1"
        'End If
        '_Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,G_Usuario"
        Dim Sql As String
        Sql = _idCabecera + ",'" + _codRepartidor + "'"
        _Err = D_Insertar_Datos("TL0012", Sql)
    End Sub
    Public Shared Sub L_ZonaDetalleRepartidor_Borrar(_Id As String)

        Dim _Where As String
        Dim _Err As Boolean

        _Where = "lcnumi = " + _Id
        _Err = D_Eliminar_Datos("TL0012", _Where)

    End Sub

    Public Shared Sub L_ZonaCabecera_Grabar(ByRef _numi As String, _city As String, _provi As String, _zona As String, _color As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TL001", "lanumi", "lanumi=lanumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"
        Dim Sql As String
        Sql = _numi + "," + _city + "," + _provi + "," + _zona + ",'" + _color + "'," + _Actualizacion
        _Err = D_Insertar_Datos("TL001", Sql)
    End Sub

    Public Shared Sub L_ZonaDetallePuntos_Grabar(_idCabecera As String, _latitud As String, _longitud As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        'Dim _Tabla As DataTable
        '_Tabla = D_Maximo("TC0061", "cenum", "cenum=cenum and cecon=" + _codConcep)
        'If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
        '    _num = _Tabla.Rows(0).Item(0) + 1
        'Else
        '    _num = "1"
        'End If
        '_Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,G_Usuario"
        Dim Sql As String
        Sql = _idCabecera + "," + _latitud + "," + _longitud
        _Err = D_Insertar_Datos("TL0013", Sql)
    End Sub
    Public Shared Sub L_ZonaCabacera_Modificar(_numi As String, _city As String, _provi As String, _zona As String, _color As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "lacity =" + _city + ", " +
        "laprovi =" + _provi + ", " +
        "lazona =" + _zona + ", " +
        "lacolor = '" + _color + "', " +
        "lafact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "lahact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "lauact = '" + "CARLOS" + "'"

        _where = "lanumi = " + _numi
        _Err = D_Modificar_Datos("TL001", Sql, _where)
    End Sub

    Public Shared Sub L_ZonaDetallePuntos_Modificar(_id As String, _latitu As String, _longitud As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "lblat =" + _latitu + ", " +
        "lblongi =" + _longitud + ", " +
        "lbfact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "lbhact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "lbuact = '" + "DANNY" + "'"

        _where = "lbnumi = " + _id
        _Err = D_Modificar_Datos("TL0013", Sql, _where)
    End Sub

    Public Shared Sub L_ZonaCabecera_Borrar(_Id As String)

        Dim _Where As String
        Dim _Err As Boolean

        _Where = "lanumi = " + _Id
        _Err = D_Eliminar_Datos("TL001", _Where)

    End Sub

    Public Shared Sub L_ZonaDetallePuntos_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean

        _Where = "lbnumi = " + _Id
        _Err = D_Eliminar_Datos("TL0013", _Where)
    End Sub


#End Region

#Region "Empleados"

    Public Shared Function L_Empleado_GeneralRepartidorSimple(_Modo As Integer, Optional _Cadena As String = "", Optional _order As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "cbnumi=cbnumi "
        Else
            _Where = "cbnumi=cbnumi " + _Cadena
        End If
        If _order = String.Empty Then
            _order = " order by cbnumi"
        Else
            _order = " order by " + _order
        End If

        _Tabla = D_Datos_Tabla("cbnumi,cbdesc,cbfot", "TC002", _Where + _order)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_Empleado_General(_Modo As Integer, Optional _Cadena As String = "", Optional _order As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "cbnumi=cbnumi AND cenum=cbcat AND cecon=7 "
        Else
            _Where = "cbnumi=cbnumi AND cenum=cbcat AND cecon=7 " + _Cadena
        End If
        If _order = String.Empty Then
            _order = " order by cbnumi"
        Else
            _order = " order by " + _order
        End If

        _Tabla = D_Datos_Tabla("cbnumi,cbdesc,cbdirec,cbtelef,cbcat,cedesc,cbsal,cbci,cbobs,cbfnac,cbfing,cbfret,cbfot,cbest,cbeciv,cbplan", "TC002,TC0051", _Where + _order)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    Public Shared Function L_Empleado_GeneralSimple(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "cbnumi=cbnumi AND cenum=cbcat AND cecon=7 AND cbcat=1 "
        Else
            _Where = "cbnumi=cbnumi AND cenum=cbcat AND cecon=7 AND cbcat=1 " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("cbnumi,cbdesc", "TC002,TC0051", _Where + " order by cbnumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_Empleado_GeneralConPedidosReclamados(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "oanumi=oanumi AND ofnumiped=oanumi and cbnumi=oarepa "
        Else
            _Where = "oanumi=oanumi AND ofnumiped=oanumi and cbnumi=oarepa " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("distinct oarepa,cbdesc", "TO001,TO0014,TC002", _Where + " order by cbdesc")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_Empleado_Grabar(ByRef _numi As String, _desc As String, _direc As String, _telef As String, _categ As String, _salario As String, _ci As String, _obs As String, _fechaNac As String, _fechaIngreso As String, _fechaRetiro As String, ByRef _foto As String, _estado As String, _estadoCivil As String, _planilla As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TC002", "cbnumi", "cbnumi=cbnumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"

        If _foto <> "" Then
            _foto = "im" + _numi + ".jpg"
        End If

        Dim Sql As String
        Sql = _numi + ",'" + _desc + "','" + _direc + "','" + _telef + "'," + _categ + "," + _salario + ",'" + _ci + "','" + _obs + "','" + _fechaNac + "','" + _fechaIngreso + "','" + _fechaRetiro + "','" + _foto + "'," + _estado + ",'" + _estadoCivil + "'," + _planilla + "," + _Actualizacion
        _Err = D_Insertar_Datos("TC002", Sql)
    End Sub

    Public Shared Sub L_Empleado_Modificar(_numi As String, _desc As String, _direc As String, _telef As String, _categ As String, _salario As String, _ci As String, _obs As String, _fechaNac As String, _fechaIng As String, _fechaRetiro As String, ByRef _foto As String, _estado As String, _estadoCivil As String, _planilla As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        If _foto <> "" Then
            _foto = "im" + _numi + ".jpg"
        End If

        Sql = "cbdesc = '" + _desc + "' , " +
        "cbdirec = '" + _direc + "' , " +
        "cbtelef = '" + _telef + "' , " +
        "cbcat = " + _categ + ", " +
        "cbsal = " + _salario + ", " +
        "cbci = '" + _ci + "', " +
        "cbobs = '" + _obs + "', " +
        "cbfnac = '" + _fechaNac + "', " +
        "cbfing = '" + _fechaIng + "', " +
        "cbfret = '" + _fechaRetiro + "', " +
        "cbfot = '" + _foto + "', " +
        "cbest = " + _estado + ", " +
        "cbeciv = '" + _estadoCivil + "', " +
        "cbplan =" + _planilla + "," +
        "cbfact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "cbhact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "cbuact = '" + "DANNY" + "'"

        _where = "cbnumi = " + _numi
        _Err = D_Modificar_Datos("TC002", Sql, _where)
    End Sub

    Public Shared Sub L_Empleado_ModificarSalario(_numi As String, _salario As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "cbsal = " + _salario

        _where = "cbnumi = " + _numi
        _Err = D_Modificar_Datos("TC002", Sql, _where)
    End Sub

    Public Shared Sub L_Empleado_Borrar(_Id As String)

        Dim _Where As String
        Dim _Err As Boolean

        _Where = "cbnumi = " + _Id
        _Err = D_Eliminar_Datos("TC002", _Where)

    End Sub

    'DETALLE DE HISTORICO SUELDOS
    Public Shared Function L_EmpleadoDetalleSueldos_General(_Modo As Integer, Optional _idCabecera As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " chnumi = chnumi"
        Else
            _Where = "chnumi=" + _idCabecera
        End If
        _Tabla = D_Datos_Tabla("chnumi,chano,chmes,chsueldo", "TC0021", _Where)
        Return _Tabla
    End Function

    Public Shared Sub L_EmpleadoDetalleSueldos_Grabar(_idCabecera As String, _anio As String, _mes As String, _sueldo As String)
        Dim _Err As Boolean
        Dim Sql As String
        Sql = _idCabecera + "," + _anio + "," + _mes + "," + _sueldo
        _Err = D_Insertar_Datos("TC0021", Sql)
    End Sub

    Public Shared Sub L_EmpleadoDetalleSueldos_Modificar(_idCabecera As String, _anio As String, _mes As String, _sueldo As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "chano =" + _anio + ", " +
        "chmes =" + _mes + ", " +
        "chsueldo =" + _sueldo

        _where = "chnumi = " + _idCabecera
        _Err = D_Modificar_Datos("TC0021", Sql, _where)
    End Sub

    Public Shared Sub L_EmpleadoDetalleSueldos_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean

        _Where = "chnumi = " + _Id
        _Err = D_Eliminar_Datos("TC0021", _Where)
    End Sub
#End Region

#Region "Precios Productos"

    Public Shared Function L_PrecioProd_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "chnumi=chnumi"
        Else
            _Where = _Cadena
        End If
        _Tabla = D_Datos_Tabla("*", "TC003", _Where + " order by chnumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    Public Shared Function L_PrecioProd_GeneralConCatPrecio(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "chnumi=chnumi"
        Else
            _Where = _Cadena + " AND " + "chcatcl=cinumi"
        End If
        _Tabla = D_Datos_Tabla("chnumi,chcprod,chcatcl,cicod,chprecio", "TC003,TC007", _Where + " order by cicod")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    'Public Shared Function L_PrecioProd_GeneralConCatPrecio(_Modo As Integer, Optional _Cadena As String = "") As DataSet
    '    Dim _Tabla As DataTable
    '    Dim _Ds As New DataSet
    '    Dim _Where As String
    '    If _Modo = 0 Then
    '        _Where = "chnumi=chnumi"
    '    Else
    '        _Where = _Cadena + " AND " + "chcatcl=cenum" + " AND " + "cecon=8"
    '    End If
    '    _Tabla = D_Datos_Tabla("chnumi,chcprod,chcatcl,cedesc,chprecio", "TC003,TC0051", _Where + " order by cenum")
    '    _Ds.Tables.Add(_Tabla)
    '    Return _Ds
    'End Function

    Public Shared Function L_PrecioProd_GeneralConCatPrecio2(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "chnumi=chnumi"
        Else
            _Where = _Cadena
        End If
        _Tabla = D_Datos_Tabla("chnumi,chcprod,chcatcl,chdesc,chprecio", "TC003", _Where + " order by chcatcl")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_PrecioProd_Grabar(ByRef _numi As String, _codProd As String, _catCliente As String, _precio As Double)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TC003", "chnumi", "chnumi=chnumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"
        Dim Sql As String
        Sql = _numi + ",'" + _codProd + "'," + _catCliente + "," + _precio.ToString() + "," + _Actualizacion
        _Err = D_Insertar_Datos("TC003", Sql)
    End Sub

    Public Shared Sub L_PrecioProd_Grabar2(ByRef _numi As String, _codProd As String, _catCliente As String, _desc As String, _precio As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TC003", "chnumi", "chnumi=chnumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"
        Dim Sql As String
        Sql = _numi + ",'" + _codProd + "','" + _catCliente + "','" + _desc + "'," + _precio + "," + _Actualizacion
        _Err = D_Insertar_Datos("TC003", Sql)
    End Sub

    Public Shared Sub L_PrecioProd_Modificar(_numi As String, _codProd As String, _catCliente As String, _precio As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "chcprod = '" + _codProd + "' , " +
        "chcatcl = " + _catCliente + " , " +
        "chprecio = " + _precio + " , " +
        "chfact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "chhact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "chuact = '" + "DANNY" + "'"

        _where = "chnumi = " + _numi
        _Err = D_Modificar_Datos("TC003", Sql, _where)
    End Sub

    Public Shared Sub L_PrecioProd_ModificarDesc(_numi As String, _codProd As String, _catCliente As String, _precio As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "chcprod = '" + _codProd + "' , " +
        "chcatcl = " + _catCliente + " , " +
        "chprecio = " + _precio + " , " +
        "chfact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "chhact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "chuact = '" + "DANNY" + "'"

        _where = "chnumi = " + _numi
        _Err = D_Modificar_Datos("TC003", Sql, _where)
    End Sub

    Public Shared Sub L_PrecioProd_Borrar(_Id As String)

        Dim _Where As String
        Dim _Err As Boolean

        _Where = "chnumi = " + _Id
        _Err = D_Eliminar_Datos("TC003", _Where)
    End Sub
    Public Shared Sub L_PrecioProd_BorrarPorCodProd(ByVal _IdCodProd As String)
        Dim _Where As String
        Dim _Err As Boolean

        _Where = "chcprod = " + _IdCodProd
        _Err = D_Eliminar_Datos("TC003", _Where)
    End Sub

#End Region

#Region "Metodos Guido"
    Public Shared Function L_ProductosPedido_General(_Modo As Integer, Optional _CatProd As String = "", Optional _CatClie As String = "", Optional _ordenEspecifico As String = "0") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "canumi=canumi"
        Else
            _Where = "cacat=" + _CatProd + " AND cast(canumi as nvarchar(10))=chcprod AND chcatcl=" + _CatClie + " AND caest=1"
        End If
        _Tabla = D_Datos_Tabla("canumi,cadesc,chprecio,caimg,castc, " + _ordenEspecifico + " as orden", "TC001,TC003", _Where + " order by orden,canumi")

        Return _Tabla
    End Function

    Public Shared Function L_ProductosPedido_General2(_Modo As Integer, Optional _CatProd As String = "", Optional _CatClie As String = "", Optional _ordenEspecifico As String = "0", Optional _numiCli As String = "0") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "canumi=canumi"
        Else
            _Where = "cacat=" + _CatProd + " AND cast(canumi as nvarchar(10))=chcprod AND caest=1 " + "and chcatcl=cpcat and canumi=cpprod and cpcli=" + _numiCli
        End If
        _Tabla = D_Datos_Tabla("canumi,cadesc,chprecio,caimg,castc, " + _ordenEspecifico + " as orden", "TC001,TC003,TC0042", _Where + " order by orden,canumi")

        Return _Tabla
    End Function
    Public Shared Function L_Productos_GeneralFiltrado2(_Modo As Integer, Optional _Cadena As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "canumi=canumi"
        Else
            _Where = _Cadena
        End If
        _Tabla = D_Datos_Tabla("canumi, cacod, cadesc", "TC001", _Where + " order by canumi")

        Return _Tabla
    End Function
#End Region

#Region "Pedidos"

    Public Shared Function L_PedidoCabecera_General(_Modo As Integer, Optional _Cadena As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "oanumi=oanumi AND ccnumi=oaccli AND oazona=lanumi AND cecon=2 AND lazona=cenum "
        Else
            _Where = "oanumi=oanumi AND ccnumi=oaccli AND oazona=lanumi AND cecon=2 AND lazona=cenum " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("DISTINCT oanumi,oafdoc,oahora,cccod,ccdesc,ccdirec,cctelf1,cccat,cczona as oazona,cedesc,oaobs,oaobs2,oaest,cclat,cclongi,oaap,IIF((select COUNT(ofnumiped) from TO0014 where ofnumiped=oanumi)>0,1,0 ) as reclamo,oapg,ccultvent,IIF((select COUNT(ofnumiped) from TO0014 where ofnumiped=oanumi and oftip=1)>0,1,0 ) as tipoRecCliente,IIF((select COUNT(ofnumiped) from TO0014 where ofnumiped=oanumi and oftip=2)>0,1,0 ) as tipoRecRepartidor, ccnumi, cceven", "TO001,TC004,TC0051,TL001", _Where + " order by oanumi")
        Return _Tabla
    End Function

    Public Shared Function L_PedidoCabecera_General_Pedido(_Modo As Integer, Optional _Cadena As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "oanumi=oanumi AND ccnumi=oaccli AND oazona=lanumi AND cecon=2 AND lazona=cenum "
        Else
            _Where = "oanumi=oanumi AND ccnumi=oaccli AND oazona=lanumi AND cecon=2 AND lazona=cenum " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("DISTINCT oanumi,oafdoc,oahora,oaccli,ccdesc,ccdirec,cctelf2,cccat,oazona,cedesc,oaobs,oaobs2,oaest,cclat,cclongi,oaap,IIF((select COUNT(ofnumiped) from TO0014 where ofnumiped=oanumi)>0,1,0 ) as reclamo,oapg,ccultvent,IIF((select COUNT(ofnumiped) from TO0014 where ofnumiped=oanumi and oftip=1)>0,1,0 ) as tipoRecCliente,IIF((select COUNT(ofnumiped) from TO0014 where ofnumiped=oanumi and oftip=2)>0,1,0 ) as tipoRecRepartidor, ccnumi, cceven", "TO001,TC004,TC0051,TL001", _Where + " order by oanumi")
        Return _Tabla
    End Function

    Public Shared Function L_PedidoCabecera_GeneralTOPN(_Modo As Integer, Optional _Cadena As String = "", Optional ByVal _top As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " ccnumi=oaccli AND oazona=lanumi AND cecon=2 AND lazona=cenum AND oanumi=oaato1numi "
        Else
            _Where = " ccnumi=oaccli AND oazona=lanumi AND cecon=2 AND lazona=cenum AND oanumi=oaato1numi " + _Cadena
        End If
        If _top <> String.Empty Then
            _top = " TOP " + _top
        End If

        _Tabla = D_Datos_Tabla(_top + " oanumi,oafdoc,oahora,oaccli,ccdesc,ccdirec,cctelf1,cccat,oazona,cedesc,oaobs,oaobs2,oaest,cclat,cclongi,oaap,oapg,ccultvent,oarepa,oaanumiprev ", "TO001,TC004,TC0051,TL001,TO001A", _Where + " order by oanumi desc")
        Return _Tabla
    End Function

    Public Shared Function L_PedidoCabecera_GeneralSoloRepartidor(_Modo As Integer, Optional _Cadena As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "oanumi=oanumi AND ccnumi=oaccli AND cczona=lanumi AND cecon=2 AND lazona=cenum and tc004.cczona = tl001.lanumi and tl001.lanumi = tl0012.lcnumi "
        Else
            _Where = "oanumi=oanumi AND ccnumi=oaccli AND cczona=lanumi AND cecon=2 AND lazona=cenum and tc004.cczona = tl001.lanumi and tl001.lanumi = tl0012.lcnumi " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("DISTINCT oanumi,oafdoc,oahora,cccod,ccdesc,ccdirec,cctelf1,cccat," _
                               + "cczona as oazona,cedesc,oaobs,oaobs2,oaest,cclat,cclongi,oaap," _
                               + "IIF((select COUNT(ofnumiped) from TO0014 where ofnumiped=oanumi)>0,1,0 ) as reclamo," _
                               + "oapg,ccultvent," _
                               + "IIF((select COUNT(ofnumiped) from TO0014 where ofnumiped=oanumi And oftip=1)>0,1,0 ) as tipoRecCliente," _
                               + "IIF((select COUNT(ofnumiped) from TO0014 where ofnumiped=oanumi And oftip=2)>0,1,0 ) as tipoRecRepartidor," _
                               + "ccnumi, cceven",
                               "TO001,TC004,TC0051,TL001,TL0012",
                               _Where + " order by oanumi")
        Return _Tabla
    End Function

    Public Shared Function L_PedidoCabecera_GeneralTop10(_Modo As Integer, Optional _Cadena As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "oanumi=oanumi And ccnumi=oaccli And oazona=lanumi And cecon=2 And lazona=cenum "
        Else
            _Where = "oanumi=oanumi And ccnumi=oaccli And oazona=lanumi And cecon=2 And lazona=cenum " + _Cadena
        End If
        '_Tabla = D_Datos_Tabla("TOP 10 oanumi,oafdoc,oahora,DATEDIFF(dd, oafdoc,GETDATE()) as diasTrans,oaobs,oaobs2", "TO001,TC004,TC0051,TL001", _Where + " order by oanumi desc")
        _Tabla = D_Datos_Tabla("DISTINCT TOP 10 oanumi,oafdoc,oahora,DATEDIFF(dd, oafdoc,GETDATE()) as diasTrans,oaobs,oaobs2,IIF((select COUNT(ofnumiped) from TO0014 where ofnumiped=oanumi)>0,1,0 ) as reclamo,oapg,oaest", "TO001,TC004,TC0051,TL001", _Where + " order by oanumi desc")
        Return _Tabla
    End Function

    Public Shared Function L_PedidoCabecera_GeneralTop10ConEstados(_Modo As Integer, Optional _Cadena As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "oanumi=oanumi And ccnumi=oaccli And oazona=lanumi And cecon=2 And lazona=cenum "
        Else
            _Where = "oanumi=oanumi And ccnumi=oaccli And oazona=lanumi And cecon=2 And lazona=cenum " + _Cadena
        End If
        '_Tabla = D_Datos_Tabla("TOP 10 oanumi,oafdoc,oahora,DATEDIFF(dd, oafdoc,GETDATE()) as diasTrans,oaobs,oaobs2", "TO001,TC004,TC0051,TL001", _Where + " order by oanumi desc")
        _Tabla = D_Datos_Tabla("DISTINCT TOP 10 oanumi,oafdoc,oahora,oaest,IIF(oaest=1,'PENDIENTE',IIF(oaest=2,'DICTADO','ENTREGADO')) as oaest2,DATEDIFF(dd, oafdoc,GETDATE()) as diasTrans,oaobs,oaobs2,IIF((select COUNT(ofnumiped) from TO0014 where ofnumiped=oanumi)>0,1,0 ) as reclamo,oapg", "TO001,TC004,TC0051,TL001", _Where + " order by oanumi desc")
        Return _Tabla
    End Function

    Public Shared Function L_PedidoCabecera_GeneralTotal(_Modo As Integer, Optional _Cadena As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "oanumi=oanumi AND ccnumi=oaccli AND oazona=lanumi AND cecon=2 AND lazona=cenum "
        Else
            _Where = "oanumi=oanumi AND ccnumi=oaccli AND oazona=lanumi AND cecon=2 AND lazona=cenum " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("*", "TO001,TC004,TC0051,TL001", _Where + " order by oanumi desc")
        Return _Tabla
    End Function

    Public Shared Function L_PedidoCabecera_GeneralTotal3Meses(_Modo As Integer, Optional _Cadena As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        Dim fechaHoy As DateTime
        fechaHoy = DateAdd(DateInterval.Month, -3, Now.Date)
        If _Modo = 0 Then
            _Where = "oanumi=oanumi AND ccnumi=oaccli AND oazona=lanumi AND cecon=2 AND lazona=cenum and oafdoc>='" + fechaHoy.Date.ToString("yyyy/MM/dd") + "'"
        Else
            _Where = "oanumi=oanumi AND ccnumi=oaccli AND oazona=lanumi AND cecon=2 AND lazona=cenum and oafdoc>='" + fechaHoy.Date.ToString("yyyy/MM/dd") + "' " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("*", "TO001,TC004,TC0051,TL001", _Where + " order by oanumi desc")
        Return _Tabla
    End Function

    Public Shared Function L_PedidoCabecera_GeneralConReclamos(_Modo As Integer, Optional _Cadena As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "ccnumi=oaccli AND cczona=lanumi AND cecon=2 AND lazona=cenum and tl001.lanumi = tl0012.lcnumi and ofnumiped=oanumi "
        Else
            _Where = "ccnumi=oaccli AND cczona=lanumi AND cecon=2 AND lazona=cenum and tl001.lanumi = tl0012.lcnumi and ofnumiped=oanumi AND " + _Cadena
        End If
        Dim campos As String = "distinct oanumi,oafdoc,oahora,oaccli,ccdesc,ccdirec,cctelf1,cccat,oazona,cedesc,oaobs,oaobs2,oaest,oarepa,ccultvent,oapg"
        _Tabla = D_Datos_Tabla(campos, "TO001,TC004,TC0051,TL001,TO0014,TL0012", _Where + " order by oanumi desc")
        Return _Tabla
    End Function

    Public Shared Sub L_PedidoCabecera_Grabar(ByRef _numi As String, _fecha As String, _hora As String, _idCli As String, _zona As String, distribuidor As String, _obs As String, _estado As String, _activoPasivo As String, _pedGen As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TO001", "oanumi", "oanumi=oanumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"
        Dim Sql As String
        Sql = _numi + ",'" + Date.Now.Date.ToString("yyyy/MM/dd") + "','" + _hora + "'," + _idCli + "," + _zona + "," + distribuidor + ",'" + _obs + "',''," + _estado + "," + _activoPasivo + "," + _pedGen + "," + _Actualizacion
        _Err = D_Insertar_Datos("TO001", Sql)
    End Sub

    Public Shared Sub L_PedidoCabecera_GrabarExtencion(ByRef to1numi As String, numiprev As String, entrega As String, caja As String)
        Dim _Err As Boolean
        Dim Sql As String
        Sql = to1numi + "," + numiprev + "," + entrega + "," + caja + ""
        _Err = D_Insertar_Datos("TO001A (oaato1numi,oaanumiprev,oaaentrega,oaacaja)", Sql)
    End Sub

    Public Shared Sub L_PedidoCabacera_Modificar(_numi As String, _fecha As String, _hora As String, _idCli As String, _zona As String, distribuidor As String, _obs As String, _estado As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "oafdoc ='" + _fecha + "', " +
        "oahora ='" + _hora + "', " +
        "oaccli =" + _idCli + ", " +
        "oazona = " + _zona + ", " +
        "oarepa = " + distribuidor + ", " +
        "oaobs = '" + _obs + "', " +
        "oaest =" + _estado + ", " +
        "oafact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "oahact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "oauact = '" + "CARLOS" + "'"

        _where = "oanumi = " + _numi
        _Err = D_Modificar_Datos("TO001", Sql, _where)
    End Sub

    Public Shared Sub L_PedidoCabacera_ModificarExtencion(to1numi As String, numiprev As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "oaanumiprev =" + numiprev + ""

        _where = "oaato1numi =" + to1numi
        _Err = D_Modificar_Datos("TO001A", Sql, _where)
    End Sub

    Public Shared Sub L_PedidoCabacera_ModificarEstado(_numi As String, _estado As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "oaest =" + _estado
        _where = "oanumi = " + _numi
        _Err = D_Modificar_Datos("TO001", Sql, _where)
    End Sub

    Public Shared Sub L_PedidoCabacera_ModificarEntrega(_numi As String, entrega As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "oaaentrega=" + entrega '1=PC, 2=Movil
        _where = "oaato1numi = " + _numi
        _Err = D_Modificar_Datos("TO001A", Sql, _where)
    End Sub

    Public Shared Sub L_PedidoCabacera_ModificarCodRep(_numi As String, _codRepa As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "oarepa =" + _codRepa
        _where = "oanumi = " + _numi
        _Err = D_Modificar_Datos("TO001", Sql, _where)
    End Sub

    Public Shared Sub L_PedidoCabacera_ModificarObservacion2(_numi As String, _obs2 As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "oaobs2 ='" + _obs2 + "'"
        _where = "oanumi = " + _numi
        _Err = D_Modificar_Datos("TO001", Sql, _where)
    End Sub

    Public Shared Sub L_PedidoCabacera_ModificarActivoPasivo(_numi As String, _estado As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "oaap =" + _estado
        _where = "oanumi = " + _numi
        _Err = D_Modificar_Datos("TO001", Sql, _where)
    End Sub

    Public Shared Sub L_PedidoCabecera_Borrar(_Id As String)

        Dim _Where As String
        Dim _Err As Boolean

        _Where = "oanumi = " + _Id
        _Err = D_Modificar_Datos("TO001", "oaest=0", _Where)

    End Sub

    Public Shared Function L_PedidoGenerarCopia(numi As String) As String
        Dim _dtCabOri, _dtDetOri As DataTable
        Dim _Where As String = "oanumi=" + numi
        _dtCabOri = D_Datos_Tabla("oanumi,oafdoc,oahora,oaccli,oazona,oarepa,oaobs,oaobs2,oaest,oaap,oapg", "TO001", _Where)
        _dtDetOri = L_PedidoDetalle_General(-1, numi)

        'grabar cabecera
        Dim numiNew, numiCli, numiZona, distribuidor, obs As String
        numiCli = _dtCabOri.Rows(0).Item("oaccli").ToString
        numiZona = _dtCabOri.Rows(0).Item("oazona").ToString
        distribuidor = _dtCabOri.Rows(0).Item("oarepa").ToString
        obs = _dtCabOri.Rows(0).Item("oaobs").ToString
        numiNew = ""
        L_PedidoCabecera_Grabar(numiNew, Now.Date.ToString("yyyy/MM/dd"), Now.Hour.ToString("00") + ":" + Now.Minute.ToString("00"), numiCli, numiZona, distribuidor, obs, "1", "1", "2")

        'grabar detalle
        Dim codProd, cant, precio, subTot As String
        For i = 0 To _dtDetOri.Rows.Count - 1
            codProd = _dtDetOri.Rows(i).Item("obcprod").ToString
            cant = _dtDetOri.Rows(i).Item("obpcant").ToString
            precio = _dtDetOri.Rows(i).Item("obpbase").ToString
            subTot = _dtDetOri.Rows(i).Item("obptot").ToString
            L_PedidoDetalle_Grabar(numiNew, codProd, cant, precio, subTot)
        Next

        Return numiNew
    End Function
    Public Shared Function L_General_LibreriaDetalleProductos(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " TC005C.caest = 1"
        Else
            _Where = "TC005C.caest = 1"
        End If
        _Tabla = D_Datos_Tabla("TC005C.canumi as ceid,TC005C.canumi as cecon,TC005C.canumi as cenum,TC005C.canombre as cedesc", "TC005C", _Where + " order by TC005C.canumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    'DETALLE DE PEDIDO
    Public Shared Function L_PedidoDetalle_General(_Modo As Integer, Optional _idCabecera As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " obnumi = obnumi"
        Else
            _Where = "obnumi=" + _idCabecera + "AND obcprod=canumi"
        End If
        _Tabla = D_Datos_Tabla("obnumi,obcprod,cadesc,obpcant,obpbase,obptot", "TO0011,TC001", _Where)
        Return _Tabla
    End Function

    Public Shared Sub L_PedidoDetalle_Grabar(_idCabecera As String, _codProd As String, _cantidad As String, _precio As String, _subTotal As String)
        Dim _Err As Boolean
        Dim Sql As String
        Sql = _idCabecera + ",'" + _codProd + "'," + _cantidad + "," + _precio + "," + _subTotal
        _Err = D_Insertar_Datos("TO0011", Sql)
    End Sub

    Public Shared Sub L_PedidoDetalle_Modificar(_id As String, _latitu As String, _longitud As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "lblat =" + _latitu + ", " +
        "lblongi =" + _longitud + ", " +
        "lbfact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "lbhact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "lbuact = '" + "DANNY" + "'"

        _where = "lbnumi = " + _id
        _Err = D_Modificar_Datos("TL0013", Sql, _where)
    End Sub

    Public Shared Sub L_PedidoDetalle_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean

        _Where = "obnumi = " + _Id
        _Err = D_Eliminar_Datos("TO0011", _Where)
    End Sub

    'DETALLE DE ESTADOS PEDIDO
    Public Shared Sub L_PedidoEstados_Grabar(_idCabecera As String, _estado As String, _fecha As String, _hora As String, _obs As String)
        Dim _Err As Boolean
        Dim Sql As String
        Sql = _idCabecera + "," + _estado + ",'" + _fecha + "','" + _hora + "','" + _obs + "'"
        _Err = D_Insertar_Datos("TO0012", Sql)
    End Sub

    'DETALLE DE RECLAMOS
    Public Shared Function L_PedidoReclamosVistaReporte(_Modo As Integer, _del As String, _al As String, Optional _numiRepart As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "ccnumi=oaccli AND cczona=lanumi AND a.cecon=2 AND lazona=a.cenum and tl001.lanumi = tl0012.lcnumi and ofnumiped=oanumi AND oaap=1 and TO0014.ofconcep=b.cenum and b.cecon=13 and TL0012.lccbnumi=z.cbnumi and b.cenum>0 and oafdoc>='" + _del + "' and oafdoc<='" + _al + "'"
        Else
            _Where = "ccnumi=oaccli AND cczona=lanumi AND a.cecon=2 AND lazona=a.cenum and tl001.lanumi = tl0012.lcnumi and ofnumiped=oanumi AND oaap=1 and TO0014.ofconcep=b.cenum and b.cecon=13 and TL0012.lccbnumi=z.cbnumi and b.cenum>0 and oafdoc>='" + _del + "' and oafdoc<='" + _al + "' and cbnumi=" + _numiRepart
        End If
        Dim _select As String = " distinct oanumi,oafdoc,oahora,oaccli,ccdesc,oazona,a.cedesc aozona2,oaobs,oaest,IIF(oaest=1,'PENDIENTE',IIF(oaest=2,'DICTADO','ENTREGADO')) as ocest2,TO0014.ofconcep,b.cedesc as ofconcep2,z.cbnumi,z.cbdesc"
        _Tabla = D_Datos_Tabla(_select, " TO001,TC004,TC0051 a,TL001,TO0014,TL0012,TC0051 b,TC002 z", _Where + " order by cbdesc")
        Return _Tabla
    End Function

    Public Shared Function L_PedidoReclamos_General(_Modo As Integer, Optional _idCabecera As String = "", Optional _order As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " TO0014.ofconcep=TC0051.cenum and TC0051.cecon=" + conConcepReclamo
        Else
            _Where = "ofnumiped=" + _idCabecera + " and " + " TO0014.ofconcep=TC0051.cenum and TC0051.cecon=" + conConcepReclamo
        End If
        _Tabla = D_Datos_Tabla("ofnumi,ofnumiped,oftip,IIF(oftip=1,'REC. CLIENTE',IIF(oftip=2,'REC. REPARTIDOR',IIF(oftip=3,'ANULACION', 'NOTAS'))) as oftip2,ofest,IIF(ofest=1,'PENDIENTE',IIF(ofest=2,'DICTADO','ENTREGADO')) as ofest2,ofobs,ofconcep,cedesc,offact,ofhact,ofuact", "TO0014,TC0051", _Where + _order)
        Return _Tabla
    End Function

    Public Shared Function L_PedidoHistorial_General(_Modo As Integer, Optional _where1 As String = "", Optional _order As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " 1=1"
        Else
            _Where = _where1
        End If
        _Tabla = D_Datos_Tabla("ocnumi,ocest,IIF(ocest=1,'PENDIENTE',IIF(ocest=2,'DICTADO','ENTREGADO')) as ocest2,ocfecha,ochora,ocobs", "TO0012", _Where + _order)
        Return _Tabla
    End Function

    Public Shared Sub L_PedidoReclamos_Grabar(ByRef _numi As String, _idCabecera As String, _estado As String, _obs As String, _tipo As String, _concepto As String)
        Dim _Err As Boolean
        Dim Sql As String
        Dim _Actualizacion As String

        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TO0014", "ofnumi", "ofnumi=ofnumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"


        Sql = _numi + "," + _idCabecera + "," + _estado + ",'" + _obs.Trim + "'," + _tipo + "," + _concepto + "," + _Actualizacion
        _Err = D_Insertar_Datos("TO0014", Sql)
    End Sub

    'DETALLE DE FRECUENCIA DE PEDIDO
    Public Shared Function L_PedidoDetalleFrecuencia_General(_Modo As Integer, Optional _idCabecera As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " 1=1"
        Else
            _Where = "ohnumi=" + _idCabecera
        End If
        _Tabla = D_Datos_Tabla("ohnumi,ohdiassem,ohdias,ohdiames", "TO0015", _Where)
        Return _Tabla
    End Function

    Public Shared Sub L_PedidoDetalleFrecuencia_Grabar(_idCabecera As String, _diasSemana As String, _cadaCiertoDia As String, _diaMes As String)
        Dim _Err As Boolean
        Dim Sql As String
        Sql = _idCabecera + ",'" + _diasSemana + "'," + _cadaCiertoDia + "," + _diaMes
        _Err = D_Insertar_Datos("TO0015", Sql)
    End Sub

    Public Shared Sub L_PedidoDetalleFrecuencia_Modificar(_idCabecera As String, _diasSemana As String, _cadaCiertoDia As String, _diaMes As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "ohdiassem ='" + _diasSemana + "', " +
        "ohdias =" + _cadaCiertoDia + ", " +
        "ohdiames = " + _diaMes

        _where = "ohnumi = " + _idCabecera
        _Err = D_Modificar_Datos("TO0015", Sql, _where)
    End Sub

    Public Shared Sub L_PedidoDetalleFrecuencia_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean

        _Where = "ohnumi = " + _Id
        _Err = D_Eliminar_Datos("TO0015", _Where)
    End Sub

    'DETALLE DE FECHAS DE PEDIDOS GENERADOS
    Public Shared Sub L_PedidoDetalleFechaFrecPedido_Grabar(_idCabecera As String, _fecha As String)
        Dim _Err As Boolean
        Dim Sql As String
        Sql = _idCabecera + ",'" + _fecha + "'"
        _Err = D_Insertar_Datos("TO0016", Sql)
    End Sub

    Public Shared Function L_PedidoDetalleFechaFrecPedido_General(Optional _idCabecera As String = "", Optional _fecha As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _idCabecera = String.Empty Then
            _Where = " 1=1"
        Else
            If _fecha = String.Empty Then
                _Where = "oinumi=" + _idCabecera
            Else
                _Where = "oinumi=" + _idCabecera + " AND oifecha='" + _fecha + "'"
            End If
        End If
        _Tabla = D_Datos_Tabla("oinumi,oifecha", "TO0016", _Where)
        Return _Tabla
    End Function

    Public Shared Function L_PedidoDetalleFechaFrecPedido_General2(Optional _fecha As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String

        _Where = "oifecha='" + _fecha + "'"

        _Tabla = D_Datos_Tabla("oinumi,oifecha", "TO0016", _Where)
        Return _Tabla
    End Function

#End Region

#Region "Descuentos Fijos"

    Public Shared Function L_DescuentoFijo_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "panumi=panumi AND cbnumi=pacper"
        Else
            _Where = "panumi=panumi AND cbnumi=pacper " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("panumi,patipo,pavalor,pacper,cbdesc,paobs,pavenc,pafvenc", "TP001,TC002", _Where + " order by panumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_DescuentoFijo_Grabar(ByRef _numi As String, _tipo As String, _valor As String, _codPersona As String, _obs As String, _vencimiento As String, _fechaVenci As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TP001", "panumi", "panumi=panumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"

        Dim Sql As String
        Sql = _numi + "," + _tipo + "," + _valor + "," + _codPersona + ",'" + _obs + "'," + _vencimiento + ",'" + _fechaVenci + "'," + _Actualizacion
        _Err = D_Insertar_Datos("TP001", Sql)
    End Sub

    Public Shared Sub L_DescuentoFijo_Modificar(_numi As String, _tipo As String, _valor As String, _codPersona As String, _obs As String, _vencimiento As String, _fechaVenci As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "patipo = " + _tipo + ", " +
        "pavalor = " + _valor + " , " +
        "pacper = " + _codPersona + " , " +
        "paobs = '" + _obs + "', " +
        "pavenc = " + _vencimiento + ", " +
        "pafvenc = '" + _fechaVenci + "', " +
        "pafact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "pahact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "pauact = '" + "DANNY" + "'"

        _where = "panumi = " + _numi
        _Err = D_Modificar_Datos("TP001", Sql, _where)
    End Sub

    Public Shared Sub L_DescuentoFijo_Borrar(_Id As String)

        Dim _Where As String
        Dim _Err As Boolean

        _Where = "panumi = " + _Id
        _Err = D_Eliminar_Datos("TP001", _Where)

    End Sub

#End Region

#Region "Bonos Descuentos"

    Public Shared Function L_BonosDescuentosCabecera_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "pbnumi=pbnumi AND cbnumi=pbcper"
        Else
            _Where = "pbnumi=pbnumi AND cbnumi=pbcper " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("pbnumi,pbcper,cbdesc,pbano,pbmes", "TP002,TC002", _Where + " order by pbnumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_BonosDescuentosCabecera_Grabar(ByRef _numi As String, _codPersona As String, _año As String, _mes As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TP002", "pbnumi", "pbnumi=pbnumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"

        Dim Sql As String
        Sql = _numi + "," + _codPersona + "," + _año + "," + _mes + "," + _Actualizacion
        _Err = D_Insertar_Datos("TP002", Sql)
    End Sub

    Public Shared Sub L_BonosDescuentosCabecera_Modificar(ByRef _numi As String, _codPersona As String, _año As String, _mes As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "pbcper = " + _codPersona + ", " +
        "pbano = " + _año + " , " +
        "pbmes = " + _mes + " , " +
        "pbfact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "pbhact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "pbuact = '" + "DANNY" + "'"

        _where = "pbnumi = " + _numi
        _Err = D_Modificar_Datos("TP002", Sql, _where)
    End Sub

    Public Shared Sub L_BonosDescuentosCabecera_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean
        _Where = "pbnumi = " + _Id
        _Err = D_Eliminar_Datos("TP002", _Where)
    End Sub

    'DETALLE DE BONOS DESCUENTOS
    Public Shared Function L_BonosDescuentosDetalle_General(_Modo As Integer, Optional _idCabecera As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " pcnumi = pcnumi"
        Else
            _Where = "pcnumi=" + _idCabecera
        End If
        _Tabla = D_Datos_Tabla("pcnumi,pcdias,pcmonto,pcobs,pcmul,pcbode", "TP0021", _Where)
        Return _Tabla
    End Function
    Public Shared Function L_BonosDescuentosDetalle_General2(_Modo As Integer, Optional _idCabecera As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " pcnumi = pcnumi"
        Else
            _Where = "pcnumi=" + _idCabecera + " order by pcfecha DESC"
        End If
        _Tabla = D_Datos_Tabla("pcnumi,pcdias,pcmonto,pcobs,pcmul,pcbode,IIF(pcmul=1,'MULTA',IIF(pcbode=1,'BONO','DESCUENTO')) as tipo,pcfecha", "TP0021", _Where)
        Return _Tabla
    End Function

    Public Shared Sub L_BonosDescuentosDetalle_Grabar(_idCabecera As String, _dias As String, _monto As String, _obs As String, _multa As String, _bode As String, _fecha As String)
        Dim _Err As Boolean
        Dim Sql As String
        Sql = _idCabecera + "," + _dias + "," + _monto + ",'" + _obs + "'," + _multa + "," + _bode + ",'" + _fecha + "'"
        _Err = D_Insertar_Datos("TP0021", Sql)
    End Sub

    Public Shared Sub L_BonosDescuentosDetalle_Modificar(_idCabecera As String, _dias As String, _monto As String, _obs As String, _multa As String, _bode As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "pcdias =" + _dias + ", " +
        "pcmonto =" + _monto + ", " +
        "pcobs =" + _obs + ", " +
        "pcmul =" + _multa + ", " +
        "pcbode =" + _bode

        _where = "pcnumi = " + _idCabecera
        _Err = D_Modificar_Datos("TP0021", Sql, _where)
    End Sub

    Public Shared Sub L_BonosDescuentosDetalle_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean

        _Where = "pcnumi = " + _Id
        _Err = D_Eliminar_Datos("TP0021", _Where)
    End Sub

#End Region

#Region "Bono Antiguedad"

    Public Shared Function L_BonosAntiguedad_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "pdnumi=pdnumi"
        Else
            _Where = "pbnumi=pbnumi " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("pdnumi,pdmeses,pdmonto", "TP003", _Where + " order by pdnumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_BonosAntiguedad_Grabar(ByRef _numi As String, _meses As String, _monto As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TP003", "pdnumi", "pdnumi=pdnumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"

        Dim Sql As String
        Sql = _numi + "," + _meses + "," + _monto + "," + _Actualizacion
        _Err = D_Insertar_Datos("TP003", Sql)
    End Sub

    Public Shared Sub L_BonosAntiguedad_Modificar(_numi As String, _meses As String, _monto As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "pdmeses = " + _meses + ", " +
        "pdmonto = " + _monto + " , " +
        "pdfact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "pdhact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "pduact = '" + "DANNY" + "'"

        _where = "pdnumi = " + _numi
        _Err = D_Modificar_Datos("TP003", Sql, _where)
    End Sub

    Public Shared Sub L_BonosAntiguedad_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean
        _Where = "pdnumi = " + _Id
        _Err = D_Eliminar_Datos("TP003", _Where)
    End Sub

#End Region

#Region "Vacacion"

    Public Shared Function L_Vacacion_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "penumi=penumi"
        Else
            _Where = "penumi=penumi " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("penumi,pemeses,pedias,pefvig,petipo", "TP004", _Where + " order by penumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_Vacacion_Grabar(ByRef _numi As String, _meses As String, _dias As String, _fechaVigencia As String, _tipo As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TP004", "penumi", "penumi=penumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"

        Dim Sql As String
        Sql = _numi + "," + _meses + "," + _dias + ",'" + _fechaVigencia + "'," + _tipo + "," + _Actualizacion
        _Err = D_Insertar_Datos("TP004", Sql)
    End Sub

    Public Shared Sub L_Vacacion_Modificar(_numi As String, _meses As String, _dias As String, _fechaVigencia As String, _tipo As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "pemeses = " + _meses + ", " +
        "pedias = " + _dias + " , " +
        "pefvig = '" + _fechaVigencia + "', " +
        "petipo = " + _tipo + " , " +
        "pefact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "pehact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "peuact = '" + "DANNY" + "'"

        _where = "penumi = " + _numi
        _Err = D_Modificar_Datos("TP004", Sql, _where)
    End Sub

    Public Shared Sub L_Vacacion_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean
        _Where = "penumi = " + _Id
        _Err = D_Eliminar_Datos("TP004", _Where)
    End Sub

#End Region

#Region "Planilla de sueldos"
    Public Shared Function L_PAPlanillaSueldos(fecha As String) As DataTable
        Dim _Tabla As DataTable
        '_Tabla = D_Procedimiento("PlanillaSueldo")
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@fecha", "date", fecha))
        '_listParam.Add(New Datos.DParametro("@cbplan", "date", planilla))
        _Tabla = D_ProcedimientoConParam("PlanillaSueldo", _listParam)
        Return _Tabla
    End Function

    Public Shared Function L_PAPlanillaSueldosGrabados(_anio As String, _mes As String, planilla As String) As DataTable
        Dim _Tabla As DataTable
        '_Tabla = D_Procedimiento("PlanillaSueldo")
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@pkmes", _mes))
        _listParam.Add(New Datos.DParametro("@pkanio", _anio))
        _listParam.Add(New Datos.DParametro("@cbplan", planilla))
        _Tabla = D_ProcedimientoConParam("sp_dg_TP008", _listParam)
        Return _Tabla
    End Function

#End Region

#Region "Feriados"

    Public Shared Function L_Feriado_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "pfnumi=pfnumi"
        Else
            _Where = _Cadena
        End If
        _Tabla = D_Datos_Tabla("pfnumi,pfflib,pfdes", "TP005", _Where + " order by pfnumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    Public Shared Function L_Feriado_General2(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "pfnumi=pfnumi"
        Else
            _Where = _Cadena
        End If
        _Tabla = D_Datos_Tabla("pfnumi,pfflib,pfdes", "TP005", _Where + " order by pfflib")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_Feriado_Grabar(ByRef _numi As String, _fechaFeriado As String, _descripcion As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TP005", "pfnumi", "pfnumi=pfnumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"

        Dim Sql As String
        Sql = _numi + ",'" + _fechaFeriado + "','" + _descripcion + "'," + _Actualizacion
        _Err = D_Insertar_Datos("TP005", Sql)
    End Sub

    Public Shared Sub L_Feriado_Modificar(_numi As String, _fechaFeriado As String, _descripcion As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "pfflib = '" + _fechaFeriado + "', " +
        "pfdes = '" + _descripcion + "' , " +
        "pffact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "pfhact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "pfuact = '" + "DANNY" + "'"

        _where = "pfnumi = " + _numi
        _Err = D_Modificar_Datos("TP005", Sql, _where)
    End Sub

    Public Shared Sub L_Feriado_Borrar(_Id As String)

        Dim _Where As String
        Dim _Err As Boolean

        _Where = "pfnumi = " + _Id
        _Err = D_Eliminar_Datos("TP005", _Where)

    End Sub

#End Region

#Region "Pedido Vacacion"

    Public Shared Function L_PedidoVacacionCabecera_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "pgnumi=pgnumi AND pgcper=cbnumi"
        Else
            _Where = "pgcper=cbnumi " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("pgnumi,pgcper,cbdesc,pgfdoc,pgest,pgobs,pgfsal,pgfing,pgdias", "TP006,TC002", _Where + " order by pgnumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_PedidoVacacionCabecera_Grabar(ByRef _numi As String, _codPersona As String, _fechaDoc As String, _estado As String, _obs As String, _fSal As String, _fIng As String, _dias As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TP006", "pgnumi", "pgnumi=pgnumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"

        Dim Sql As String
        Sql = _numi + "," + _codPersona + ",'" + _fechaDoc + "'," + _estado + ",'" + _obs + "','" + _fSal + "','" + _fIng + "'," + _dias + "," + _Actualizacion
        _Err = D_Insertar_Datos("TP006", Sql)
    End Sub

    Public Shared Sub L_PedidoVacacionCabecera_Modificar(_numi As String, _codPersona As String, _fechaDoc As String, _estado As String, _obs As String, _fIng As String, _fSal As String, _dias As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "pgcper = " + _codPersona + ", " +
        "pgfdoc = '" + _fechaDoc + "', " +
        "pgest = " + _estado + " , " +
        "pgobs = '" + _obs + "', " +
        "pgfsal = '" + _fSal + "', " +
        "pgfing = '" + _fIng + "', " +
        "pgdias = " + _dias + " , " +
        "pgfact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "pghact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "pguact = '" + "DANNY" + "'"

        _where = "pgnumi = " + _numi
        _Err = D_Modificar_Datos("TP006", Sql, _where)
    End Sub

    Public Shared Sub L_PedidoVacacionCabecera_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean
        _Where = "pgnumi = " + _Id
        _Err = D_Eliminar_Datos("TP006", _Where)
    End Sub

    'DETALLE DE PEDIDO VACACIONES
    Public Shared Function L_PedidoVacacionDetalle_General(_Modo As Integer, Optional _idCabecera As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " phnumi = phnumi"
        Else
            _Where = "phnumi=" + _idCabecera
        End If
        _Tabla = D_Datos_Tabla("phnumi,phfsal,phfing,phdias", "TP0061", _Where)
        Return _Tabla
    End Function

    Public Shared Sub L_PedidoVacacionDetalle_Grabar(_idCabecera As String, _fechaSalida As String, _fechaIngreso As String, _dias As String)
        Dim _Err As Boolean
        Dim Sql As String
        Sql = _idCabecera + ",'" + _fechaSalida + "','" + _fechaIngreso + "'," + _dias
        _Err = D_Insertar_Datos("TP0061", Sql)
    End Sub

    Public Shared Sub L_PedidoVacacionDetalle_Modificar(_idCabecera As String, _fechaSalida As String, _fechaIngreso As String, _dias As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "phfsal ='" + _fechaSalida + "', " +
        "phfing ='" + _fechaIngreso + "', " +
        "phdias =" + _dias

        _where = "phnumi = " + _idCabecera
        _Err = D_Modificar_Datos("TP0061", Sql, _where)
    End Sub

    Public Shared Sub L_PedidoVacacionDetalle_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean

        _Where = "phnumi = " + _Id
        _Err = D_Eliminar_Datos("TP0061", _Where)
    End Sub

    'METODOS EXTRAS
    Public Shared Function L_PedidoVacacionDetalleFechas(_codEmpl As String) As DataTable
        Dim _Tabla As DataTable
        Dim _Where, _select As String
        _Where = "cbnumi=" + _codEmpl
        _select = "cbfing, DATEADD(YEAR, 1, cbfing) AS fechaFin,0 as diasLibres, 0 as diasUsados,0 as saldo "
        _Tabla = D_Datos_Tabla(_select, "TC002", _Where)
        Return _Tabla
    End Function

    Public Shared Function L_PedidoVacacion_ObtenerDiasVacacion(_meses As String) As Integer
        Dim _Tabla As DataTable
        Dim _Where, _select As String
        _Where = _meses + ">=pemeses order by pemeses desc"
        _select = "top 1 pedias "
        _Tabla = D_Datos_Tabla(_select, "TP004", _Where)
        If _Tabla.Rows.Count = 0 Then
            Return 0
        Else
            Return _Tabla.Rows(0).Item(0)
        End If

    End Function

    Public Shared Function L_PedidoVacacion_ObtenerDiasUsados(_codEmpleado As String) As Integer
        Dim _Tabla As DataTable
        Dim _Where, _select As String
        _Where = "pgcper=" + _codEmpleado
        _select = "sum(pgdias) as totalDias "
        _Tabla = D_Datos_Tabla(_select, "TP006", _Where)
        If IsDBNull(_Tabla.Rows(0).Item(0)) Then
            Return 0
        Else
            Return _Tabla.Rows(0).Item(0)
        End If

    End Function

#End Region

#Region "Producto"

    Public Shared Function L_GetProductos(_Where As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        _Where = " cacat = TC0051.cenum " _
        + " and TC005.cdcon = TC0051.cecon " _
        + " and TC005.cdcon = 5 " + IIf(_Where.Equals(""), "", " and " + _Where) _
        & " order by canumi"
        _Tabla = D_Datos_Tabla("canumi, cacod, cadesc, cadesc2, cacat, TC0051.cedesc, caimg, castc, caest, caserie, capcom, cafing, cafact, cahact, cauact",
                               "TC001, TC005, TC0051", _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    'Public Shared Function L_fnProductoGeneral(Where As String) As DataTable
    '    Dim Tabla As DataTable
    '    Where = " cacat = TC0051.cenum " _
    '    + " and TC005.cdcon = TC0051.cecon " _
    '    + " and TC005.cdcon = 5 " + IIf(Where.Equals(""), "", " and " + Where) _
    '    & " order by canumi"

    '    Tabla = D_Datos_Tabla("canumi, cacod, cadesc, cadesc2, cacat, TC0051.cedesc, caimg, castc, caest, caserie, capcom, cafing, cafact, cahact, cauact",
    '                           "TC001, TC005, TC0051",
    '                           Where)
    '    Return Tabla
    'End Function

    'select *
    'from TC0011
    'where cicod = '12'
    'and ciest =1
    'and cieserie = 1

    Public Shared Function L_GetItemsConceptoLibreria(ByVal _Concepto As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        _Where = " a.cdcon = b.cecon" _
        & " and a.cdcon = " + _Concepto _
        & " order by b.cenum"
        _Tabla = D_Datos_Tabla("b.cenum, b.cedesc", "TC005 a, TC0051 b", _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_fnObtenerLibreria(ByVal concepto As String, where As String) As DataTable
        Dim Tabla As DataTable

        If (where = String.Empty) Then
            where = "1=1"
        Else
            where = where + " and a.cdcon = b.cecon" _
                    & " and a.cdcon = " + concepto _
                    & " order by b.cenum"
        End If

        Tabla = D_Datos_Tabla("b.cenum as [cod], b.cedesc as [desc]", "TC005 a, TC0051 b", where)
        Return Tabla
    End Function

    Public Shared Function L_fnObtenerUnidad() As DataTable
        Dim Tabla As DataTable
        Dim where As String = ""
        'Select Case a.canumi ,a.canombre ,a.cadesc ,a.caimg ,a.cafact,a.cahact,a.cauact
        'From TC005C As a
        If (where = String.Empty) Then
            where = "1=1"
        Else
            where = where + " order by a.cenum"
        End If

        Tabla = D_Datos_Tabla("a.cenum as [cod], a.cedesc as [desc]", "TC0051 a", "cecon = 106")
        Return Tabla
    End Function

    Public Shared Function L_fnObtenerCategoria() As DataTable
        Dim Tabla As DataTable
        Dim where As String = ""
        'Select Case a.canumi ,a.canombre ,a.cadesc ,a.caimg ,a.cafact,a.cahact,a.cauact
        'From TC005C As a
        If (where = String.Empty) Then
            where = "1=1"
        Else
            where = where + " order by a.canumi"
        End If

        Tabla = D_Datos_Tabla("a.canumi as [cod], a.canombre as [desc]", "TC005C a", where)
        Return Tabla
    End Function

    Public Shared Function L_fnObtenerProveedor() As DataTable
        Dim Tabla As DataTable
        Dim where As String = ""
        If (where = String.Empty) Then
            where = "1=1"
        Else
            where = where + " order by a.cmnumi"
        End If

        Tabla = D_Datos_Tabla("a.cmnumi as [cod], a.cmdesc as [desc]", "TC010 a", where)
        Return Tabla
    End Function
    Public Shared Function L_prLibreriaProductoGeneral(cod1 As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@cecon", cod1))
        _Tabla = D_ProcedimientoConParam("sp_go_TC001", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prLibreriaGrabar(ByRef _numi As String, _cod1 As String, _desc1 As String, _desc2 As String) As Boolean
        Dim _Error As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@cecon", _cod1))
        _listParam.Add(New Datos.DParametro("@cedesc", _desc1))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _Error = False
        Else
            _Error = True
        End If
        Return Not _Error
    End Function

    Public Shared Function L_GetConceptoInvetario() As DataTable
        Dim Tabla As DataTable
        Dim Where As String
        Where = " a.cptipo=1 " _
        & " order by a.cpnumi"
        Tabla = D_Datos_Tabla("a.cpnumi, a.cpdesc", "TCI001 a", Where)

        Return Tabla
    End Function

    Public Shared Function L_GetItemsConceptoLibreriaEquipo(ByVal _Concepto As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        _Where = " a.cdcon = b.cecon" _
        & " and a.cdcon = " + _Concepto + " and b.cenum <> 11 " _
        & " order by b.cenum"
        _Tabla = D_Datos_Tabla("b.cenum, b.cedesc", "TC005 a, TC0051 b", _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_GetLastIdTablas(ByVal _Tabla As String, ByVal _Campo As String) As Integer
        If (D_Maximo(_Tabla, _Campo, "1=1").Rows(0).Item(0).ToString.Equals("")) Then
            Return 0
        Else
            Return CInt(D_Maximo(_Tabla, _Campo, "1=1").Rows(0).Item(0).ToString)
        End If
    End Function

    Public Shared Function L_GrabarNuevoProducto(ByVal _Campos As String) As Boolean
        Try
            Return D_Insertar_Datos("TC001", _Campos)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function L_GrabarModificarProducto(ByVal _Campos As String, ByVal _Where As String) As Boolean
        Try
            Return D_Modificar_Datos("TC001", _Campos, _Where)
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function L_GrabarEliminarProducto(ByVal _Where As String) As Boolean
        Try
            Return Not D_Eliminar_Datos("TC001", _Where)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function L_GetSeriesProducto(_Where As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        _Where = " cieserie = 1 " _
        + " and ciest = 1" _
        + IIf(_Where.Equals(""), "", " And " + _Where) _
        & " order by cinserie"
        _Tabla = D_Datos_Tabla("cicod, CAST(cilin as nvarchar) as cilin, cinserie, cieserie, ciest",
                               "TC0011",
                               _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    '  select cacod
    'from TC001
    'where cadesc ='DISPENSADOR DE AGUA'
    Public Shared Function L_GetIdProductoEquipo(_Where As String) As String
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        _Tabla = D_Datos_Tabla("ISNULL(cadesc,'')as cadesc",
                               "TC001",
                               _Where)
        _Ds.Tables.Add(_Tabla)
        If (_Ds.Tables(0).Rows.Count > 0) Then
            Return _Ds.Tables(0).Rows(0).Item("cadesc").ToString
        Else
            Return ""
        End If
    End Function

    Public Shared Function L_GetNroLineaProductoEquipo(_Where As String) As String
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        _Tabla = D_Datos_Tabla("ISNULL(cilin, '')as cilin",
                               "TC0011",
                               _Where)
        _Ds.Tables.Add(_Tabla)
        If (_Ds.Tables(0).Rows.Count > 0) Then
            Return _Ds.Tables(0).Rows(0).Item("cilin").ToString
        Else
            Return ""
        End If
    End Function

    Public Shared Function L_UpdateSeriesProducto(_Where As String) As Boolean
        Try
            Return D_Modificar_Datos("TC0011",
                                     "cieserie = 0",
                                     _Where)
        Catch ex As Exception
            MsgBox(ex.Message + "Logica, L_UpdateSeriesProducto")
            Return True
        End Try
    End Function

    Public Shared Function L_GetImagenProducto(_Where As String) As String
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        _Tabla = D_Datos_Tabla("ISNULL(caimg, '')as caimg",
                               "TC001",
                               _Where)
        _Ds.Tables.Add(_Tabla)
        If (_Ds.Tables(0).Rows.Count > 0) Then
            Return _Ds.Tables(0).Rows(0).Item("caimg").ToString
        Else
            Return ""
        End If
    End Function

#End Region

#Region "TC001 Productos"

    Public Shared Function L_fnProductoGeneral(filtro As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@filtro", filtro))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnProductoGrabar(ByRef numi As String, cod As String, desc As String, desc2 As String,
                                              cat As String, ByRef img As String, stc As String, est As String,
                                              serie As String, pcom As String, fing As String, cemp As String,
                                              barra As String, smin As String, gr1 As String, gr2 As String,
                                              gr3 As String, gr4 As String, umed As String, umin As String,
                                              umax As String, conv As Int32) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@cod", cod))
        _listParam.Add(New Datos.DParametro("@desc", desc))
        _listParam.Add(New Datos.DParametro("@desc2", desc2))
        _listParam.Add(New Datos.DParametro("@cat", cat))
        _listParam.Add(New Datos.DParametro("@img", img))
        _listParam.Add(New Datos.DParametro("@stc", stc))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@serie", serie))
        _listParam.Add(New Datos.DParametro("@pcom", pcom))
        _listParam.Add(New Datos.DParametro("@fing", fing))
        _listParam.Add(New Datos.DParametro("@cemp", cemp))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@cbarra", barra))
        _listParam.Add(New Datos.DParametro("@smin", smin))
        _listParam.Add(New Datos.DParametro("@gr1", gr1))
        _listParam.Add(New Datos.DParametro("@gr2", gr2))
        _listParam.Add(New Datos.DParametro("@gr3", gr3))
        _listParam.Add(New Datos.DParametro("@gr4", gr4))
        _listParam.Add(New Datos.DParametro("@umed", umed))
        _listParam.Add(New Datos.DParametro("@uventa", umin))
        _listParam.Add(New Datos.DParametro("@umax", umax))
        _listParam.Add(New Datos.DParametro("@conv", conv))

        _Tabla = D_ProcedimientoConParam("sp_go_TC001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            img = numi.ToString + "_" + img
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnProductoModificar(ByRef numi As String, cod As String, desc As String, desc2 As String,
                                                 cat As String, ByRef img As String, stc As String, est As String,
                                                 serie As String, pcom As String, fing As String, cemp As String,
                                                 barra As String, smin As String, gr1 As String, gr2 As String,
                                                 gr3 As String, gr4 As String, umed As String, umin As String,
                                                 umax As String, conv As Int32) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@cod", cod))
        _listParam.Add(New Datos.DParametro("@desc", desc))
        _listParam.Add(New Datos.DParametro("@desc2", desc2))
        _listParam.Add(New Datos.DParametro("@cat", cat))
        _listParam.Add(New Datos.DParametro("@img", img))
        _listParam.Add(New Datos.DParametro("@stc", stc))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@serie", serie))
        _listParam.Add(New Datos.DParametro("@pcom", pcom))
        _listParam.Add(New Datos.DParametro("@fing", fing))
        _listParam.Add(New Datos.DParametro("@cemp", cemp))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@cbarra", barra))
        _listParam.Add(New Datos.DParametro("@smin", smin))
        _listParam.Add(New Datos.DParametro("@gr1", gr1))
        _listParam.Add(New Datos.DParametro("@gr2", gr2))
        _listParam.Add(New Datos.DParametro("@gr3", gr3))
        _listParam.Add(New Datos.DParametro("@gr4", gr4))
        _listParam.Add(New Datos.DParametro("@umed", umed))
        _listParam.Add(New Datos.DParametro("@uventa", umin))
        _listParam.Add(New Datos.DParametro("@umax", umax))
        _listParam.Add(New Datos.DParametro("@conv", conv))

        _Tabla = D_ProcedimientoConParam("sp_go_TC001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            img = numi.ToString + "_" + img
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnProductoBorrar(numi As String) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "Clientes"

    Public Shared Function L_GetClientes(Optional modo As Byte = 0) As DataTable 'Ocupo el modo 1 cuando se llama a la consulta desde el formulario de cliente, 0 desde otro formulario
        Dim _Tabla As DataTable
        _Tabla = D_Procedimiento("Sp_GetClientes")
        Return _Tabla
    End Function

    Public Shared Function L_GetClientes2(Optional _where2 As String = "", Optional _order As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        _Where = " a.cczona = d.lanumi and d.lazona = c.cenum  and b.cdcon = c.cecon  and b.cdcon = 2 " _
        + " and a.ccdct = cc.cenum  and bb.cdcon = cc.cecon  and bb.cdcon = 9 " _
        + " and a.cccat = bbb.cinumi " + _where2

        _Where = _Where + IIf(_order = String.Empty, " order by a.ccnumi", " order by " + _order)

        _Tabla = D_Datos_Tabla("a.ccnumi, a.cccod, a.ccdesc, a.cczona as numZona, c.cedesc as descZona," _
                               + " a.ccdct as numDct, cc.cedesc as descDct, a.ccdctnum, a.ccdirec," _
                               + " a.cctelf1, a.cctelf2, a.cccat as numCat, bbb.cidesc as descCat, " _
                               + "a.ccest, a.cclat, a.cclongi, a.cceven, a.ccobs, a.ccfnac",
                               "TC004 a, TC005 b, TC005 bb, TC007 bbb, TC0051 c, TC0051 cc, TL001 d",
                               _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_GetClientes3(Optional _where2 As String = "", Optional _order As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        _Where = " a.cczona = d.lanumi and d.lazona = c.cenum  and b.cdcon = c.cecon  and b.cdcon = 2 " _
        + " and a.ccdct = cc.cenum  and bb.cdcon = cc.cecon  and bb.cdcon = 9 " _
        + " and a.cccat = bbb.cinumi " + _where2

        _Where = _Where + IIf(_order = String.Empty, " order by a.ccnumi", " order by " + _order)

        _Tabla = D_Datos_Tabla("a.ccnumi, a.cccod, a.ccdesc,a.ccdirec,a.cctelf1, a.cctelf2, a.cczona as numZona, c.cedesc as descZona," _
                               + " a.ccdct as numDct, cc.cedesc as descDct, a.ccdctnum," _
                               + " a.cccat as numCat, bbb.cidesc as descCat, " _
                               + "a.ccest, a.cclat, a.cclongi, a.cceven, a.ccobs, a.ccfnac",
                               "TC004 a, TC005 b, TC005 bb, TC007 bbb, TC0051 c, TC0051 cc, TL001 d",
                               _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_GetClientesSimple(_CodZona As String, _CodRep As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        _Where = " a.cczona = b.lanumi	and b.lazona = c.cenum " _
               + " and a.ccest = 1 and c.cecon = 2 order by a.ccdesc "
        _Tabla = D_Datos_Tabla("a.ccnumi, a.ccdctnum, a.ccdesc, a.ccdirec, a.cczona as [zon], c.cedesc as [nzon]",
                               " TC004 a, TL001 b, TC0051 c",
                               _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_GetClientesPedido(_CodTProd As String, _CodRep As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        _Where = " a.cacat = " + _CodTProd _
                 + " and a.zon in (select a.lcnumi " _
                                    + " from TL0012 a " _
                                    + "where a.lccbnumi = " + _CodRep + ")" _
                 + " order by a.ccdesc"
        _Tabla = D_Datos_Tabla(" a.ccnumi, a.ccdctnum, a.ccdesc, a.ccdirec, a.zon, a.nzon, a.codP, a.can, a.tot, a.ped ",
                               " VR_ClientesPendientesNota a ",
                               _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds

    End Function

    Public Shared Function L_GrabarNuevoCliente(ByVal _Campos As String) As Boolean
        Try
            Return D_Insertar_Datos("TC004", _Campos)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function L_fnGrabarCliente(ByRef numi As String, cod As String, desc As String, zona As String,
                                             dct As String, dctnum As String, direc As String, telf1 As String,
                                             telf2 As String, cat As String, est As String, lat As String,
                                             lon As String, prconsu As String, even As String, obs As String,
                                             fnac As String, nomfac As String, nit As String, ultped As String,
                                             fecing As String, ultvent As String, recven As String, supven As String,
                                             preven As String, detalle As DataTable, detalle2 As DataTable,
                                             tacu As String, fini As String, ffin As String, fre As String,
                                             acuEst As String, acuObs As String, tcre As String,
                                             dtDet1 As DataTable, dtDet2 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@ccnumi", numi))
        _listParam.Add(New Datos.DParametro("@cccod", cod))
        _listParam.Add(New Datos.DParametro("@ccdesc", desc))
        _listParam.Add(New Datos.DParametro("@cczona", zona))
        _listParam.Add(New Datos.DParametro("@ccdct", dct))
        _listParam.Add(New Datos.DParametro("@ccdctnum", dctnum))
        _listParam.Add(New Datos.DParametro("@ccdirec", direc))
        _listParam.Add(New Datos.DParametro("@cctelf1", telf1))
        _listParam.Add(New Datos.DParametro("@cctelf2", telf2))
        _listParam.Add(New Datos.DParametro("@cccat", cat))
        _listParam.Add(New Datos.DParametro("@ccest", est))
        _listParam.Add(New Datos.DParametro("@cclat", lat))
        _listParam.Add(New Datos.DParametro("@cclongi", lon))
        _listParam.Add(New Datos.DParametro("@ccprconsu", prconsu))
        _listParam.Add(New Datos.DParametro("@cceven", even))
        _listParam.Add(New Datos.DParametro("@ccobs", obs))
        _listParam.Add(New Datos.DParametro("@ccfnac", fnac))
        _listParam.Add(New Datos.DParametro("@ccnomfac", nomfac))
        _listParam.Add(New Datos.DParametro("@ccnit", nit))
        _listParam.Add(New Datos.DParametro("@ccultped", ultped))
        _listParam.Add(New Datos.DParametro("@ccfecing", fecing))
        _listParam.Add(New Datos.DParametro("@ccultvent", ultvent))
        _listParam.Add(New Datos.DParametro("@recven", recven))
        _listParam.Add(New Datos.DParametro("@supven", supven))
        _listParam.Add(New Datos.DParametro("@preven", preven))
        _listParam.Add(New Datos.DParametro("@tcre", tcre))
        _listParam.Add(New Datos.DParametro("@ccuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TC0041", "", detalle))
        _listParam.Add(New Datos.DParametro("@TC0042", "", detalle2))
        If (Not tacu = -1) Then
            _listParam.Add(New Datos.DParametro("@tacu", tacu))
            _listParam.Add(New Datos.DParametro("@fini", fini))
            _listParam.Add(New Datos.DParametro("@ffin", ffin))
            _listParam.Add(New Datos.DParametro("@fre", fre))
            _listParam.Add(New Datos.DParametro("@est", acuEst))
            _listParam.Add(New Datos.DParametro("@obs", acuObs))
            _listParam.Add(New Datos.DParametro("@TC004A1", "", dtDet1))
            _listParam.Add(New Datos.DParametro("@TC004A2", "", dtDet2))
        End If

        _Tabla = D_ProcedimientoConParam("sp_go_TC004", _listParam)
        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If
        Return _resultado
    End Function

    Public Shared Function L_GrabarModificarCliente(ByVal _Campos As String, ByVal _Where As String) As Boolean
        Try
            Return D_Modificar_Datos("TC004", _Campos, _Where)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function L_fnModificarCliente(ByRef numi As String, cod As String, desc As String, zona As String,
                                                dct As String, dctnum As String, direc As String, telf1 As String,
                                                telf2 As String, cat As String, est As String, lat As String,
                                                lon As String, even As String, obs As String,
                                                fnac As String, nomfac As String, nit As String,
                                                ultped As String, fecing As String, ultvent As String, recven As String,
                                                supven As String, preven As String, detalle As DataTable, detalle2 As DataTable,
                                                tacu As String, fini As String, ffin As String, fre As String,
                                                acuEst As String, acuObs As String, tcre As String,
                                                dtDet1 As DataTable, dtDet2 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@ccnumi", numi))
        _listParam.Add(New Datos.DParametro("@cccod", cod))
        _listParam.Add(New Datos.DParametro("@ccdesc", desc))
        _listParam.Add(New Datos.DParametro("@cczona", zona))
        _listParam.Add(New Datos.DParametro("@ccdct", dct))
        _listParam.Add(New Datos.DParametro("@ccdctnum", dctnum))
        _listParam.Add(New Datos.DParametro("@ccdirec", direc))
        _listParam.Add(New Datos.DParametro("@cctelf1", telf1))
        _listParam.Add(New Datos.DParametro("@cctelf2", telf2))
        _listParam.Add(New Datos.DParametro("@cccat", cat))
        _listParam.Add(New Datos.DParametro("@ccest", est))
        _listParam.Add(New Datos.DParametro("@cclat", lat))
        _listParam.Add(New Datos.DParametro("@cclongi", lon))
        _listParam.Add(New Datos.DParametro("@cceven", even))
        _listParam.Add(New Datos.DParametro("@ccobs", obs))
        _listParam.Add(New Datos.DParametro("@ccfnac", fnac))
        _listParam.Add(New Datos.DParametro("@ccnomfac", nomfac))
        _listParam.Add(New Datos.DParametro("@ccnit", nit))
        _listParam.Add(New Datos.DParametro("@ccultped", ultped))
        _listParam.Add(New Datos.DParametro("@ccfecing", fecing))
        _listParam.Add(New Datos.DParametro("@ccultvent", ultvent))
        _listParam.Add(New Datos.DParametro("@recven", recven))
        _listParam.Add(New Datos.DParametro("@supven", supven))
        _listParam.Add(New Datos.DParametro("@preven", preven))
        _listParam.Add(New Datos.DParametro("@tcre", tcre))
        _listParam.Add(New Datos.DParametro("@ccuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TC0041", "", detalle))
        _listParam.Add(New Datos.DParametro("@TC0042", "", detalle2))

        If (Not tacu = -1) Then
            _listParam.Add(New Datos.DParametro("@tacu", tacu))
            _listParam.Add(New Datos.DParametro("@fini", fini))
            _listParam.Add(New Datos.DParametro("@ffin", ffin))
            _listParam.Add(New Datos.DParametro("@fre", fre))
            _listParam.Add(New Datos.DParametro("@est", acuEst))
            _listParam.Add(New Datos.DParametro("@obs", acuObs))
            _listParam.Add(New Datos.DParametro("@TC004A1", "", dtDet1))
            _listParam.Add(New Datos.DParametro("@TC004A2", "", dtDet2))
        End If

        _Tabla = D_ProcedimientoConParam("sp_go_TC004", _listParam)
        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If
        Return _resultado
    End Function

    Public Shared Function L_GrabarEliminarCliente(ByVal _Where As String) As Boolean
        Try
            Return D_Eliminar_Datos("TC004", _Where)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function L_fnEliminarCliente(ByRef numi As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@ccnumi", numi))
        _listParam.Add(New Datos.DParametro("@ccuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC004", _listParam)
        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If
        Return _resultado
    End Function

    Public Shared Function L_prTraerCategoriasPorClientes(ByRef numi As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 13))
        _listParam.Add(New Datos.DParametro("@ccnumi", numi))
        _listParam.Add(New Datos.DParametro("@ccuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC004", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prTraerCategoriasPorClientesNuevo() As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 11))
        _listParam.Add(New Datos.DParametro("@ccuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC004", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prTraerPrecio(categoria As String, producto As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 14))
        _listParam.Add(New Datos.DParametro("@categoria", categoria))
        _listParam.Add(New Datos.DParametro("@producto", producto))
        _listParam.Add(New Datos.DParametro("@ccuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC004", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prTraerCategoriasTodas() As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 12))
        _listParam.Add(New Datos.DParametro("@ccuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC004", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_GrabarNuevoClienteEquipo(ByVal _Campos As String) As Boolean
        Try
            Return D_Insertar_Datos("TC0041", _Campos)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function L_GrabarModificarClienteEquipo(ByVal _Campos As String, ByVal _Where As String) As Boolean
        Try
            Return D_Modificar_Datos("TC0041", _Campos, _Where)
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function L_GrabarEliminarClienteEquipo(ByVal _Where As String) As Boolean
        Try
            Return D_Eliminar_Datos("TC0041", _Where)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function L_GetClienteEquipo(_Where As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        _Tabla = D_Datos_Tabla("[chnumi] as numi, [chfec] as fec, [chcod] as cod, [chdesc] as des, [chtmov] as tmov," _
                               + "[chnrem] as nrem, [chcan] as can, [chmonbs] as monbs, [chmonsus] as monsus, [chnota] as nota",
                               "TC0041",
                               _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_fnClientes() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@ccuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC004", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnCliente(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@ccnumi", numi))
        _listParam.Add(New Datos.DParametro("@ccuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC004", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnClienteEquipo(Numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@ccnumi", Numi))
        _listParam.Add(New Datos.DParametro("@ccuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC004", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnClienteEquipoConceptos() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@ccuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC004", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnClienteEquipoProductosCompuestos() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@ccuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC004", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_GetZonas() As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String = " a.lazona =c.cenum " _
                                + " and c.cecon = 2 " _
                                + " and a.laprovi = cc.cenum " _
                                + " and cc.cecon = 3 " _
                                + " and a.lacity = ccc.cenum " _
                                + " and ccc.cecon = 4 "
        _Tabla = D_Datos_Tabla("a.lanumi, c.cenum as codZona, c.cedesc as zona, cc.cenum as codProv, " _
                               + "cc.cedesc as prov, ccc.cenum as codCity, ccc.cedesc as city",
                               "TL001 a, TC0051 c, TC0051 cc, TC0051 ccc",
                               _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_GetZonasCPZ() As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String = " a.lazona =c.cenum " _
                                + " and c.cecon = 2 " _
                                + " and a.laprovi = cc.cenum " _
                                + " and cc.cecon = 3 " _
                                + " and a.lacity = ccc.cenum " _
                                + " and ccc.cecon = 4 "
        _Tabla = D_Datos_Tabla("a.lanumi, ccc.cedesc as city, cc.cedesc as prov, c.cedesc as zona ",
                               "TL001 a, TC0051 c, TC0051 cc, TC0051 ccc",
                               _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_GetCliente(idCli As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        _Where = "a.ccest = 1 and ccnumi=" + idCli
        _Tabla = D_Datos_Tabla("*",
                               "TC004 a",
                               _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    Public Shared Function L_GetCliente2(idCli As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        _Where = "ccnumi=" + idCli
        _Tabla = D_Datos_Tabla("*",
                               "TC004 a",
                               _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_VistaClientesPromedios(Optional _where As String = "", Optional _orderby As String = "") As DataTable

        Dim _Tabla As DataTable
        If _where = "" Then
            _where = "1=1"
        Else
            _where = _where
        End If
        If _orderby = "" Then
            _orderby = " order by ccnumi"
        End If

        Dim campos As String = "ccnumi,ccdesc,cczona,cctelf1,ccdirec,ccest,ccprconsu,DATEADD(day,ccprconsu,(select top 1 oafdoc from TO001 where oaccli=ccnumi order by oanumi desc)) fTentativa"

        _Tabla = D_Datos_Tabla(campos, "TC004", _where + _orderby)
        Return _Tabla
    End Function

    Public Shared Function L_VistaClientesPromedios2(Optional _where As String = "", Optional _orderby As String = "") As DataTable

        Dim _Tabla As DataTable
        If _where = "" Then
            _where = "1=1"
        Else
            _where = _where
        End If
        If _orderby = "" Then
            _orderby = " order by ccnumi"
        End If


        Dim campos As String = "*"

        _Tabla = D_Datos_Tabla(campos, "vista_promconsumo", _where + _orderby)
        Return _Tabla
    End Function

    Public Shared Function L_GetDatoTabla(_NomTabla As String, _Campo As String, _Where As String) As String
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        _Tabla = D_Datos_Tabla(_Campo,
                               _NomTabla,
                               _Where)
        _Ds.Tables.Add(_Tabla)
        If (_Ds.Tables(0).Rows.Count > 0) Then
            Return _Ds.Tables(0).Rows(0).Item(_Campo).ToString
        Else
            Return ""
        End If
    End Function

    Public Shared Function L_GetFilaTabla(_NomTabla As String, _Campo As String, _Where As String) As DataRow
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        _Tabla = D_Datos_Tabla(_Campo,
                               _NomTabla,
                               _Where)
        _Ds.Tables.Add(_Tabla)
        If (_Ds.Tables(0).Rows.Count > 0) Then
            Return _Ds.Tables(0).Rows(0)
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function L_DeleteDatoTabla(_NomTabla As String, _Where As String) As Boolean
        Return D_Eliminar_Datos(_NomTabla, _Where)
    End Function

    Public Shared Function L_GetClientesSimple2(Optional _where1 As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _where1 = String.Empty Then
            _Where = "1=1"
        Else
            _Where = _where1
        End If
        _Tabla = D_Datos_Tabla("b.ccnumi, b.ccdctnum, b.ccdesc, b.ccdirec",
                               " TC004 b",
                               _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_fnObtenerDetalleTC004A1(Numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@ccnumi", Numi))
        _listParam.Add(New Datos.DParametro("@ccuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC004", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnObtenerDetalleTC004A2(Numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@ccnumi", Numi))
        _listParam.Add(New Datos.DParametro("@ccuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC004", _listParam)

        Return _Tabla
    End Function

#End Region

#Region "Notas"

    Public Shared Function L_GetNotas() As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        _Where = " a.odtprod = b.cenum " _
                 + " and b.cecon = 5 " _
                 + " and a.odrepa = c.cbnumi " _
                 + " order by fil "
        '+ " and a.odnumi <> 1" 
        _Tabla = D_Datos_Tabla("ROW_NUMBER() OVER(ORDER BY a.odnota ASC) AS fil, a.odnumi, a.odnota, a.odfdoc, a.odrepa, c.cbdesc, a.odtprod, b.cedesc, a.odtap, a.oddes",
                               "TO002 a, TC0051 b, TC002 c",
                               _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_GetNotasAyuda() As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        _Where = " 1 = 1 order by a.odnota"
        _Tabla = D_Datos_Tabla("a.odnumi, a.odnota, a.odfdoc, a.odtprod, c.cedesc, a.odrepa, b.cbdesc, a.oduact",
                               " TO002 a inner join TC002 b on a.odrepa = b.cbnumi " _
                               + " inner join TC0051 c on a.odtprod = c.cenum and c.cecon = 5 ",
                               _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
        'SELECT 
        '	a.odnumi, a.odnota, a.odfdoc, a.odtprod, c.cedesc, a.odrepa, b.cbdesc
        'FROM 
        '	TO002 a inner join TC002 b on a.odrepa = b.cbnumi 
        '	inner join TC0051 c on a.odtprod = c.cenum and c.cecon = 5  WHERE  1 = 1 
    End Function

    Public Shared Function L_GetNotas1(_Where As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        _Where = " a.oencli = b.ccnumi " _
                 + " and " + _Where _
                 + " order by a.oelin "
        _Tabla = D_Datos_Tabla("a.oelin as [or], a.oencli as cod, b.ccdesc as cli, a.oeefec as con," _
                               + " a.oecred as cre, a.oenrec as [not], a.oenfac as fac, a.oenped as ped, a.oetipo as tip",
                               "TO0021 a, TC004 b",
                               _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds

        'select a.oenumi, a.oelin, a.oencli, b.ccdesc, a.oeefec, a.oecred, a.oenrec, a.oenfac, a.oenped, a.oetipo
        'from TO0021 a, TC004 b
        'where a.oencli = b.ccnumi
        'and a.oenumi = 1
        'order by a.oelin

    End Function

    Public Shared Function L_GetNotas2(_Where As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        _Where = " a.ofcprod = b.cacod " _
                 + " and " + _Where _
                 + " group by a.ofnumi, a.oflin, a.ofccli, a.ofcprod, b.cadesc2, a.ofcant " _
                 + " order by a.oflin, cast(a.ofcprod as int) "
        _Tabla = D_Datos_Tabla("a.ofnumi, a.oflin, a.ofccli, a.ofcprod, b.cadesc2, a.ofcant",
                               "TO0022 a, TC001 b",
                               _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds

        'SELECT 
        '	a.ofnumi, 
        '	a.oflin, 
        '	a.ofccli, 
        ' 	a.ofcprod, 
        '	b.cadesc2, 
        '	a.ofcant 
        'FROM 
        '	TO0022 a, 
        '	TC001 b 
        'WHERE  
        '	a.ofcprod = b.cacod  
        '	and a.ofnumi = 112187 
        'group by a.ofnumi, 
        '	a.oflin, 
        '	a.ofccli, 
        ' 	a.ofcprod, 
        '	b.cadesc2, 
        '	a.ofcant
        'order by a.oflin, cast(a.ofcprod as int)

    End Function

    Public Shared Function L_NotasDetalle1_ClienteCredito(_Where As String) As DataTable
        Dim _Tabla As DataTable
        _Where = _Where + " and a.oecred > 0 and a.oetipo <> 'ENTREGA' order by a.oelin "
        _Tabla = D_Datos_Tabla("a.oencli as codC, a.oecred as cre",
                               "TO0021 a",
                               _Where)
        Return _Tabla
    End Function

    Public Shared Function L_GetProductosCategoria(_Where As String) As DataTable
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla("a.cacod, b.cedesc, a.cadesc2, a.cafing",
                               "TC001 a,TC0051 b",
                               "a.cacat = b.cenum and b.cecon = 5 and " + _Where + " order by cast(a.cacod as int) ")
        Return _Tabla
    End Function

    Public Shared Function L_GetDatosNota(_Where As String) As DataTable
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla("ROW_NUMBER() OVER(ORDER BY a.oanumi DESC) AS [or], a.oaccli as [cod], " _
                               + "d.ccdesc as [cli], c.cacod as [codP],	b.obpcant as [can], b.obptot as [tot], a.oanumi as [ped]",
                               "TO001 a, TO0011 b, TC001 c,	TC004 d",
                               "a.oaccli = d.ccnumi and a.oanumi = b.obnumi	and b.obcprod = c.cacod	and a.oaest = 2 " _
                               + " and " + _Where)

        '_Tabla = D_Datos_Tabla("ROW_NUMBER() OVER(ORDER BY a.oanumi DESC) AS [or], a.oaccli as [cod], " _
        '                       + "d.ccdesc as [cli], c.cacod as [codP],	b.obpcant as [can], b.obptot as [tot], a.oanumi as [ped]",
        '                       "TO001 a, TO0011 b, TC001 c,	TC004 d",
        '                       "a.oaccli = d.ccnumi and a.oanumi = b.obnumi	and b.obcprod = c.cacod	and a.oaest = 3 " _
        '                       + " and a.oafdoc = '" + Now.Date.ToShortDateString + "' and " + _Where)
        Return _Tabla
    End Function

    Public Shared Function L_GrabarNuevoNota(ByVal _Campos As String) As Boolean
        Try
            Return D_Insertar_Datos("TO002", _Campos)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function L_GrabarModificarNota(ByVal _Campos As String, ByVal _Where As String) As Boolean
        Try
            Return D_Modificar_Datos("TO002", _Campos, _Where)
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function L_GrabarEliminarNota(ByVal _Where As String) As Boolean
        Try
            Return D_Eliminar_Datos("TO002", _Where)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function L_GrabarNuevoNotaDetalle(ByVal _Campos As String) As Boolean
        Try
            Return D_Insertar_Datos("TO0021", _Campos)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function L_GrabarModificarNotaDetalle(ByVal _Campos As String, ByVal _Where As String) As Boolean
        Try
            Return D_Modificar_Datos("TO0021", _Campos, _Where)
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function L_GrabarEliminarNotaDetalle(ByVal _Where As String) As Boolean
        Try
            Return D_Eliminar_Datos("TO0021", _Where)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function L_ActualizarEstadoPedido(ByVal _Campos As String, ByVal _Where As String) As Boolean
        Try
            Return D_Modificar_Datos("TO001", _Campos, _Where)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function L_GrabarNuevoNotaDetalle2(ByVal _Campos As String) As Boolean
        Try
            Return D_Insertar_Datos("TO0022 ([ofnumi] ,[oflin] ,[ofccli] ,[ofcprod] ,[ofcant])", _Campos)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function L_GrabarModificarNotaDetalle2(ByVal _Campos As String, ByVal _Where As String) As Boolean
        Try
            Return D_Modificar_Datos("TO0022", _Campos, _Where)
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function L_GrabarEliminarNotaDetalle2(ByVal _Where As String) As Boolean
        Try
            Return D_Eliminar_Datos("TO0022", _Where)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function L_GetNotasEquipo(_Where As String) As DataTable
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla(" a.ccdesc, sum(b.chmonbs) as chmon ",
                               " TC004 a, TC0041 b ",
                               " a.ccnumi = b.chnumi " + _Where + " group by a.ccdesc ")
        Return _Tabla
    End Function

    Public Shared Function L_GetNotasEquipos(_Where As String) As DataTable
        Dim _Tabla As DataTable
        _Where = " b.chnota = " + _Where + " and b.chfec>='2016/10/01' group by a.ccnumi, b.chfec, a.ccdesc, b.chtmov, c.cpmov "
        _Tabla = D_Datos_Tabla(" a.ccnumi as numi, b.chfec as fec, a.ccdesc as cli, sum(b.chmonbs)*c.cpmov*-1  as mon ",
                               " TC004 a inner join TC0041 b on a.ccnumi = b.chnumi inner join TCI001 c on b.chtmov=c.cpnumi and c.cptipo=1 ",
                               _Where)
        Return _Tabla
        'SELECT  a.ccnumi as numi, b.chfec as fec, a.ccdesc as cli, sum(b.chmonbs)*c.cpmov*-1  as mon  
        'FROM  TC004 a inner join TC0041 b on a.ccnumi = b.chnumi 
        'inner join TCI001 c on b.chtmov=c.cpnumi and c.cpest=1 
        'WHERE  b.chnota = 43796 group by a.ccnumi, b.chfec, a.ccdesc, b.chtmov, c.cpmov
    End Function

    Public Shared Function L_GetNotasPagos(numi As String, tpro As String) As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String = " a.ognota = " + numi + " and a.ogtprod=" + tpro + " group by b.ccnumi, a.ogfdoc, b.ccdesc "
        _Tabla = D_Datos_Tabla(" b.ccnumi as numi, a.ogfdoc as fec, b.ccdesc as cli, sum(a.ogmon) as mon ",
                               " TO003 a inner join TC004 b on a.ogcli = b.ccnumi ",
                               _Where)
        Return _Tabla

        'select 
        '	b.ccnumi as numi, 
        '	a.ogfdoc as fec,
        '	b.ccdesc as cli,
        '	sum(a.ogmon) as mon
        'from 
        '	TO003 a inner join TC004 b on a.ogcli = b.ccnumi 
        'where 
        '	a.ognota = 880
        'group by b.ccnumi, a.ogfdoc, b.ccdesc
    End Function

    Public Shared Function L_GetNotasGastos(numi As String, tpro As String) As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String = " a.cpanota = " + numi + " and a.cpatpro=" + tpro + " order by a.cpafdoc"
        _Tabla = D_Datos_Tabla(" a.cpanumi as numi, a.cpaprov as pro, a.cpafdoc as fec, a.cpaobs as obs, a.cpamonto as mon ",
                               " TCP001 a ",
                               _Where)
        Return _Tabla
    End Function

    Public Shared Function L_GetNotasPago(_Where As String) As DataTable
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla(" a.ccdesc, sum(b.ogmon) as ogmon ",
                               " TC004 a, TO003 b ",
                               " a.ccnumi = b.ogcli " + _Where + " group by a.ccdesc ")
        Return _Tabla
    End Function

    Public Shared Function L_GetPrecioCategoriaCliente(ccli As String, cprod As String, ByRef flat As Boolean) As Double
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla(" c.chprecio ",
                               " TC004 a, TC003 c ",
                               " a.cccat = c.chcatcl and a.ccnumi = " + ccli + " and c.chcprod = " + cprod)
        If (_Tabla.Rows.Count > 0) Then
            flat = True
            Return CDbl(_Tabla.Rows(0).Item("chprecio").ToString)
        Else
            flat = False
            Return 0
        End If
        'select a.cccat, c.chprecio
        'from TC004 a, TC003 c
        'where 
        'a.cccat = c.chcatcl
        'and a.ccnumi = 9
        'and c.chcprod = 37
    End Function

    Public Shared Function L_ValidarNroNota(Nro As String, codP As String) As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla(" a.odnota",
                               " TO002 a ",
                               " a.odnota = " + Nro + " and a.odtprod = " + codP)
        If (_Tabla.Rows.Count = 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function L_ExisteDescuento(Anho As String, Mes As String, CPer As String) As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla(" a.pbnumi ",
                               " TP002 a ",
                               " a.pbano = " + Anho + " and a.pbmes = " + Mes + " and a.pbcper = " + CPer)
        If (_Tabla.Rows.Count = 0) Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Shared Function L_InsertarCabeceraDescuendo(Campos As String) As Boolean
        Try
            Return D_Insertar_Datos("TP002", Campos)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function L_InsertarDetalleDescuendo(Campos As String) As Boolean
        Try
            Return D_Insertar_Datos("TP0021", Campos)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function L_fnObtenerTabla(campo As String, tabla As String, where As String) As DataTable
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla(campo,
                               tabla,
                               where)
        Return _Tabla
    End Function

    Public Shared Function L_ObtenerDato(campo As String, tabla As String, where As String) As String
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla(campo,
                               tabla,
                               where)
        If (_Tabla.Rows.Count = 0) Then
            Return "0"
        Else
            Return _Tabla(0).Item(campo).ToString
        End If

    End Function

#End Region

#Region "Pagos"

    Public Shared Function L_GrabarNuevoPago(ByVal _Campos As String) As Boolean
        Try
            Return D_Insertar_Datos("TO003", _Campos)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function L_GrabarModificarPago(ByVal _Campos As String, ByVal _Where As String) As Boolean
        Try
            Return D_Modificar_Datos("TO003", _Campos, _Where)
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function L_GrabarEliminarPago(ByVal _Where As String) As Boolean
        Try
            Return D_Eliminar_Datos("TO003", _Where)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function L_GetPagos(Optional condicion As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        _Where = IIf(condicion.Equals(""), " 1 = 1 ", condicion) _
        & " order by a.ogfdoc desc "
        _Tabla = D_Datos_Tabla("a.ognumi, a.ognota, a.ogcli, b.ccdesc as [nombre], a.ogmon, " _
                               + " ISNULL(c.idsaldo, 0)  as saldo, " _
                               + " a.ogfdoc, a.ogrec, a.ogtprod, d.cedesc ",
                               " TO003 a inner join TC004 b on  a.ogcli = b.ccnumi " _
                               + " left join TI003 c on a.ogcli = c.idcodcli " _
                               + " left join TC0051 d on a.ogtprod = d.cenum and d.cecon = 5 ",
                               _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds

        'SELECT 
        '   a.ognumi, 
        '   a.ognota, 
        '   a.ogcli, 
        '   b.ccdesc as [nombre], 
        '   a.ogmon, 
        '   ISNULL(c.idsaldo, 0)  as saldo, 
        '   a.ogfdoc, 
        '   a.ogrec
        'FROM TO003 a inner join TC004 b on  a.ogcli = b.ccnumi 
        '	 left join TI003 c on a.ogcli = c.idcodcli    
        'order by a.ognumi

    End Function

    Public Shared Function L_FiltrarCliente(ByVal _TipoLike As String, ByVal _Where As String) As DataSet
        Dim _tabla As DataTable
        Dim _Ds As New DataSet
        _Where = " TC004." + _TipoLike + _Where + "%' and TC004.ccest = 1"
        _tabla = D_Datos_Tabla("TC004.ccnumi, TC004.ccdesc", "TC004", _Where)
        _Ds.Tables.Add(_tabla)
        Return _Ds
    End Function

    Public Shared Function L_ValidarNroNotaPagos(Nro As String) As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla(" a.odnota",
                               " TO002 a ",
                               " a.odnota = " + Nro)
        If (_Tabla.Rows.Count = 0) Then
            Return False
        Else
            Return True
        End If
    End Function

#End Region

#Region "PR_EntregaPedido"

    Public Shared Function L_ObtenerTipoProducto(_CodTipo As String) As DataSet
        Dim _tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String = ""
        _Where = "a.odtprod = b.cenum And b.cecon = " + _CodTipo
        _tabla = D_Datos_Tabla("Distinct(a.odtprod), b.cedesc",
                               "VR_EntregaPedidos a, TC0051 b",
                               _Where)
        _Ds.Tables.Add(_tabla)
        Return _Ds

        'Select Distinct(a.odtprod), b.cedesc 
        'From VR_EntregaPedidos a, TC0051 b 
        'Where a.odtprod = b.cenum
        'And b.cecon = 5

    End Function

    Public Shared Function L_ObtenerEntregaPedidos(_CodTipoP As String, _Fini As String, _Ffin As String) As DataTable
        Dim _tabla As DataTable
        Dim _Where As String = ""
        _Where = IIf(_CodTipoP.Equals("0"), "1 = 1", "a.odtprod = " + _CodTipoP) _
            + " and a.odfdoc >= '" + _Fini + "' and a.odfdoc <= '" + _Ffin + "' " _
            + "GROUP BY a.odrepa, a.cbdesc"
        _tabla = D_Datos_Tabla("ROW_NUMBER() OVER (ORDER BY a.odrepa ASC) AS Nro, " _
                                + " a.odrepa,	a.cbdesc, SUM(a.Contado) AS Contado, SUM(a.Credito) AS Credito, " _
                                + " SUM(a.Total) AS Total ",
                               "VR_EntregaPedidos a",
                               _Where)
        Return _tabla

        'SELECT
        '	ROW_NUMBER() OVER (ORDER BY a.odrepa ASC) AS Nro, 
        '	a.odrepa, 
        '	a.cbdesc, 
        '	SUM(a.Contado) AS Contado, 
        '	SUM(a.Credito) AS Credito, 
        '	SUM(a.Total) AS Total
        'From VR_EntregaPedidos a
        'GROUP BY 
        '	a.odrepa, 
        '	a.cbdesc

    End Function

#End Region

    Public Shared Function L_ObtenerFidelidadCliente(_CodTipoP As String, _Aini As String, _Afin As String, _Criterio As String) As DataSet
        Dim _tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String = ""
        _Where = IIf(_CodTipoP.Equals("0"), "1 = 1", "a.odtprod = " + _CodTipoP) _
            + " And a.Anho >= " + _Aini + " and a.Anho <= " + _Afin _
            + " Order by " + IIf(_Criterio.Equals("0"), " TotalPedido DESC", " ccprconsu ASC")
        _tabla = D_Datos_Tabla("*",
                               "VR_FidelidadCliente a",
                               _Where)
        _Ds.Tables.Add(_tabla)
        Return _Ds

    End Function

    Public Shared Function L_ObtenerAnhoFidelidad() As DataSet
        Dim _tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String = ""
        _Where = "1 = 1 Order By a.Anho"
        _tabla = D_Datos_Tabla("Distinct(a.Anho)",
                               "VR_FidelidadCliente a",
                               _Where)
        _Ds.Tables.Add(_tabla)
        Return _Ds

        'Select Distinct(a.odtprod), b.cedesc 
        'From VR_EntregaPedidos a, TC0051 b 
        'Where a.odtprod = b.cenum
        'And b.cecon = 5

    End Function

#Region "PR_ResumenNotas"

    Public Shared Function L_ObtenerResumenNotas(_Fini As String, _Ffin As String) As DataSet
        Dim _tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String = ""
        _Where = " a.odfdoc >= '" + _Fini + "' and a.odfdoc <= '" + _Ffin + "' " _
                 + " ORDER BY a.odfdoc"
        _tabla = D_Datos_Tabla("*",
                               "VR_ResumenNotas a",
                               _Where)
        _Ds.Tables.Add(_tabla)
        Return _Ds

    End Function

#End Region

#Region "PR_UltimosPedidos"

    Public Shared Function L_ObtenerUltimosPedidos(_CodZona As String, _CodCliente As String, _CodEquipo As String, _Fmax As String) As DataSet
        Dim _tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String = ""
        _Where = IIf(_CodZona.Equals("0"), "1 = 1", "a.zona = " + _CodZona) _
            + " and " + IIf(_CodCliente.Equals("0"), "1 = 1", "a.codCliente = " + _CodCliente) _
            + " and " + IIf(_CodEquipo.Equals("0"), "1 = 1", "a.codEquipo = " + _CodEquipo) _
            + " and a.FechaUltimoPedido <= '" + _Fmax + "'"
        _tabla = D_Datos_Tabla("*",
                               "VR_UltimosPedidos a",
                               _Where)
        _Ds.Tables.Add(_tabla)
        Return _Ds
    End Function

    Public Shared Function L_ObtenerZona() As DataSet
        Return L_ZonaCabecera_GeneralCompleto(0)
    End Function

    Public Shared Function L_ObtenerCliente() As DataSet
        Dim _tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String = ""
        _Where = "1 = 1"
        _tabla = D_Datos_Tabla("a.ccnumi, a.ccdesc",
                               "TC004 a",
                               _Where)
        _Ds.Tables.Add(_tabla)
        Return _Ds
        'SELECT a.ccnumi, a.ccdesc
        'FROM TC004 a
    End Function

    Public Shared Function L_ObtenerEquipo() As DataSet
        Dim _tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String = ""
        _Where = "a.caserie = 1"
        _tabla = D_Datos_Tabla("a.cacod, a.cadesc",
                               "TC001 a",
                               _Where)
        _Ds.Tables.Add(_tabla)
        Return _Ds
        'SELECT a.cacod, a.cadesc2
        'FROM TC001 a
        'WHERE a.caserie = 1
    End Function

#End Region

#Region "Transacciones"
    Public Shared Function L_VistaTransacciones(Optional _where As String = "", Optional _orderby As String = "") As DataTable

        Dim _Tabla As DataTable
        If _where = "" Then
            _where = "1=1"
        Else
            _where = _where
        End If
        If _orderby = "" Then
            _orderby = " order by numi"
        End If


        Dim campos As String = "*"

        _Tabla = D_Datos_Tabla(campos, "vista_transacciones", _where + _orderby)
        Return _Tabla
    End Function
#End Region

#Region "Formularios"
    Public Shared Function L_Formulario_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "ZY001.yanumi=ZY001.yanumi and ZY001.yamod=TC0051.cenum and cecon=11 "
        Else
            _Where = "ZY001.yanumi=ZY001.yanumi and ZY001.yamod=TC0051.cenum and cecon=11 " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("ZY001.yanumi,ZY001.yaprog,ZY001.yatit,ZY001.yamod,TC0051.cedesc", "ZY001,TC0051", _Where + " order by yanumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_Formulario_Grabar(ByRef _numi As String, _desc As String, _direc As String, _categ As String)
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("ZY001", "yanumi", "yanumi=yanumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        Dim Sql As String
        Sql = _numi + ",'" + _desc + "','" + _direc + "'," + _categ
        _Err = D_Insertar_Datos("ZY001", Sql)
    End Sub

    Public Shared Sub L_Formulario_Modificar(_numi As String, _desc As String, _direc As String, _categ As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "yaprog = '" + _desc + "' , " +
        "yatit = '" + _direc + "' , " +
        "yamod = " + _categ

        _where = "yanumi = " + _numi
        _Err = D_Modificar_Datos("ZY001", Sql, _where)
    End Sub

    Public Shared Sub L_Formulario_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean
        _Where = "yanumi = " + _Id
        _Err = D_Eliminar_Datos("ZY001", _Where)
    End Sub
#End Region

#Region "Roles"
    Public Shared Function L_Rol_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "ZY002.ybnumi=ZY002.ybnumi "
        Else
            _Where = "ZY002.ybnumi=ZY002.ybnumi " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("ZY002.ybnumi,ZY002.ybrol", "ZY002", _Where + " order by ybnumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    Public Shared Function L_RolDetalle_General(_Modo As Integer, Optional _idCabecera As String = "", Optional _idModulo As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " ycnumi = ycnumi"
        Else
            _Where = " ycnumi=" + _idCabecera + " and ZY001.yamod=" + _idModulo + " and ZY0021.ycyanumi=ZY001.yanumi"
        End If
        _Tabla = D_Datos_Tabla("ZY0021.ycnumi,ZY0021.ycyanumi,ZY0021.ycshow,ZY0021.ycadd,ZY0021.ycmod,ZY0021.ycdel,ZY001.yaprog,ZY001.yatit", "ZY0021,ZY001", _Where)
        Return _Tabla
    End Function

    Public Shared Function L_RolDetalle_General2(_Modo As Integer, Optional _idCabecera As String = "", Optional _where1 As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " ycnumi = ycnumi"
        Else
            _Where = " ycnumi=" + _idCabecera + " and " + _where1
        End If
        _Tabla = D_Datos_Tabla("ycnumi,ycyanumi,ycshow,ycadd,ycmod,ycdel", "ZY0021", _Where)
        Return _Tabla
    End Function

    Public Shared Sub L_Rol_Grabar(ByRef _numi As String, _rol As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("ZY002", "ybnumi", "ybnumi=ybnumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"

        Dim Sql As String
        Sql = _numi + ",'" + _rol + "'," + _Actualizacion
        _Err = D_Insertar_Datos("ZY002", Sql)
    End Sub
    Public Shared Sub L_RolDetalle_Grabar(_idCabecera As String, _numi1 As Integer, _show As Boolean, _add As Boolean, _mod As Boolean, _del As Boolean)
        Dim _Err As Boolean
        Dim Sql As String
        Sql = _idCabecera & "," & _numi1 & ",'" & _show & "','" & _add & "','" & _mod & "','" & _del & "'"
        _Err = D_Insertar_Datos("ZY0021", Sql)
    End Sub
    Public Shared Sub L_Rol_Modificar(_numi As String, _desc As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "ybrol = '" + _desc + "' "

        _where = "ybnumi = " + _numi
        _Err = D_Modificar_Datos("ZY002", Sql, _where)
    End Sub
    Public Shared Sub L_Rol_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean
        _Where = "ybnumi = " + _Id
        _Err = D_Eliminar_Datos("ZY002", _Where)
    End Sub
    Public Shared Sub L_RolDetalle_Modificar(_idCabecera As String, _numi1 As Integer, _show As Boolean, _add As Boolean, _mod As Boolean, _del As Boolean)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "ycshow = '" & _show & "' , " & "ycadd = '" & _add & "' , " & "ycmod = '" & _mod & "' , " & "ycdel = '" & _del & "' "

        _where = "ycnumi = " & _idCabecera & " and ycyanumi = " & _numi1
        _Err = D_Modificar_Datos("ZY0021", Sql, _where)
    End Sub
    Public Shared Sub L_RolDetalle_Borrar(_Id As String, _Id1 As String)
        Dim _Where As String
        Dim _Err As Boolean

        _Where = "ycnumi = " + _Id + " and ycyanumi = " + _Id1
        _Err = D_Eliminar_Datos("ZY0021", _Where)
    End Sub
    Public Shared Sub L_RolDetalle_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean

        _Where = "ycnumi = " + _Id
        _Err = D_Eliminar_Datos("ZY0021", _Where)
    End Sub
#End Region

#Region "Usuarios"
    Public Shared Function L_Usuario_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "ZY003.ydnumi=ZY003.ydnumi and ZY002.ybnumi=ZY003.ydrol "
        Else
            _Where = "ZY003.ydnumi=ZY003.ydnumi and ZY002.ybnumi=ZY003.ydrol " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("ZY003.ydnumi,ZY003.yduser,ZY003.ydpass,ZY003.ydest,ZY003.ydcant,ZY002.ybnumi,ZY002.ybrol", "ZY003,ZY002", _Where + " order by ydnumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function


    Public Shared Function L_Usuario_General2(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "ZY003.ydnumi=ZY003.ydnumi and ZY002.ybnumi=ZY003.ydrol "
        Else
            _Where = "ZY003.ydnumi=ZY003.ydnumi and ZY002.ybnumi=ZY003.ydrol " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("ZY003.ydnumi,ZY003.yduser,ZY003.ydpass,ZY003.ydest,ZY003.ydcant,ZY003.ydfontsize,ZY002.ybnumi,ZY002.ybrol", "ZY003,ZY002", _Where + " order by ydnumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_Usuario_General3(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "1=1"
        Else
            _Where = _Cadena
        End If
        _Tabla = D_Datos_Tabla("ZY003.ydnumi,ZY003.yduser", "ZY003", _Where + " order by yduser")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    Public Shared Sub L_Usuario_Grabar(ByRef _numi As String, _user As String, _pass As String, _rol As String, _estado As String, _cantDias As String, _tamFuente As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("ZY003", "ydnumi", "ydnumi=ydnumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"

        Dim Sql As String
        Sql = _numi + ",'" + _user + "'," + _rol + ",'" + _pass + "','" + _estado + "'," + _cantDias + "," + _tamFuente + "," + _Actualizacion
        _Err = D_Insertar_Datos("ZY003", Sql)
    End Sub
    Public Shared Sub L_Usuario_Modificar(_numi As String, _user As String, _pass As String, _rol As String, _estado As String, _cantDias As String, _tamFuente As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "yduser = '" + _user + "' , " +
        "ydpass = '" + _pass + "' , " +
        "ydrol = " + _rol + " , " +
        "ydest = '" + _estado + "' , " +
        "ydcant = " + _cantDias + " , " +
        "ydfontsize = " + _tamFuente + "  "

        _where = "ydnumi = " + _numi
        _Err = D_Modificar_Datos("ZY003", Sql, _where)
    End Sub
    Public Shared Sub L_Usuario_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean
        _Where = "ydnumi = " + _Id
        _Err = D_Eliminar_Datos("ZY003", _Where)
    End Sub

    Public Shared Function L_Validar_Usuario2(_Nom As String, _Pass As String) As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla("*", "ZY003", "yduser = '" + _Nom + "' AND ydpass = '" + _Pass + "'")
        If _Tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function L_Validar_Usuario(_Nom As String, _Pass As String) As DataTable
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla("ydnumi,yduser,ydrol,ydpass,ydest,ydcant,ydfontsize", "ZY003", "yduser = '" + _Nom + "' AND ydpass = '" + _Pass + "'")
        Return _Tabla
    End Function
#End Region

#Region "Movimiento"

    Public Shared Function L_Validar_Producto(_codigo As String) As String
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla("cadesc", "TC001", "cacod = '" + _codigo + "'")
        If _Tabla.Rows.Count > 0 Then
            Return _Tabla.Rows(0).Item(0)
        Else
            Return ""
        End If
    End Function

    Public Shared Function L_ProductosGeneral(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " TC001.canumi = TC001.canumi"
        Else
            _Where = _Cadena
        End If
        _Tabla = D_Datos_Tabla("canumi,cacod, cadesc,cadesc2", "TC001", _Where + " order by canumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function


    Public Shared Function L_MovimientosGeneral(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " 1 = 1"
        Else
            _Where = _Cadena
        End If
        _Tabla = D_Datos_Tabla("*", "TI002", _Where + " order by ibid")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_MovimientosDetalleGeneral(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " TI0021.icId = TI0021.icId"
        Else
            'consulto con el cod del producto(cadena)
            _Where = "TI002.ibid = " + _Cadena + " AND " +
                     "TI002.ibid = TI0021.icibid AND " +
                     "TI0021.iccprod = TC001.cacod"
        End If
        _Tabla = D_Datos_Tabla("TI0021.iccprod, TC001.cadesc, ABS(TI0021.iccant) AS iccant", "TI0021, TI002, TC001", _Where + " order by icid")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_Grabar_Movimientos(ByRef _id As String, _fechaDoc As String, _idConcepto As String, _observaciones As String, _estado As String, _alm As String, numiEqui As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean

        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TI002", "ibid", "ibid = ibid")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _id = _Tabla.Rows(0).Item(0) + 1
        Else
            _id = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"
        Dim Sql As String
        Sql = _id + ", '" + _fechaDoc + "'," + _idConcepto + ",'" + _observaciones + "'," + _estado + "," + _alm + "," + numiEqui + "," + _Actualizacion
        _Err = D_Insertar_Datos("TI002", Sql)
    End Sub

    Public Shared Sub L_Modificar_Movimientos(_id As String, _fechaDoc As String, _idConcepto As String, _observaciones As String, _estado As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "ibfdoc ='" + _fechaDoc + "', " +
        "ibconcep =" + _idConcepto + ", " +
        "ibobs = '" + _observaciones + "', " +
        "ibest = " + _estado + ", " +
        "ibfact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "ibhact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "ibuact = '" + L_Usuario + "'"

        _where = "ibid = " + _id
        _Err = D_Modificar_Datos("TI002", Sql, _where)
    End Sub

    Public Shared Sub L_Grabar_MovimientosDetalle(_id As String, _codProd As String, _cant As String)
        Dim _Err As Boolean
        Dim Sql As String
        Dim _numi As String
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TI0021", "icid", "1 = 1")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        Sql = _numi + ", " + _id + "," + _codProd + "," + _cant
        _Err = D_Insertar_Datos("TI0021", Sql)
    End Sub

    Public Shared Function L_LibreriaGeneral(_codConcepto As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        _Where = "cecon=" + _codConcepto
        _Tabla = D_Datos_Tabla("cenum, cedesc", "TC0051", _Where + " order by cenum")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_Grabar_Libreria(_codConcepto As Integer, ByRef _numeracion As Integer, _descr As String, _usu As String)
        Dim _Err As Boolean
        Dim _numi As String
        Dim _Tabla As DataTable

        '_Tabla = D_Maximo("TC005", "ceid", "1 = 1")
        'If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
        '    _numi = _Tabla.Rows(0).Item(0) + 1
        'Else
        '    _numi = "1"
        'End If

        _Tabla = D_Maximo("TC0051", "cenum", "cecon=" + Str(_codConcepto))
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numeracion = _Tabla.Rows(0).Item(0) + 1
        Else
            _numeracion = "1"
        End If

        Dim _Actualizacion As String = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"
        Dim Sql As String
        'Sql = _numi + ", " + Str(_codConcepto) + "," + Str(_numeracion) + ",'" + _descr + "'," + "0" + "," + _Actualizacion
        Sql = Str(_codConcepto) + "," + Str(_numeracion) + ",'" + _descr + "'," + _Actualizacion
        _Err = D_Insertar_Datos("TC0051 (cecon, cenum, cedesc, cefact, cehact, ceuact)", Sql)
    End Sub

    Public Shared Sub L_Borrar_Movimientos(_Id As String)

        Dim _Where As String
        Dim _Err As Boolean

        _Where = "ibid = " + _Id
        _Err = D_Eliminar_Datos("TI002", _Where)

    End Sub
    Public Shared Sub L_Borrar_MovimientosDetalle(_id As String)
        Dim _Where As String
        Dim _Err As Boolean

        _Where = "icibid = " + _id
        _Err = D_Eliminar_Datos("TI0021", _Where)
    End Sub

    Public Shared Sub L_Actualizar_StockMovimiento(_codProd As String, _cant As String)
        'verificamos si es que ya existe el codigo del producto en la tabla TI001
        Dim _Err As Boolean
        Dim Sql, _where As String


        Dim _Tabla As DataTable
        Dim cantOriginal
        _Tabla = D_Datos_Tabla("TI001.iacant", "TI001", "iacprod ='" + _codProd + "'")
        If _Tabla.Rows.Count > 0 Then 'ya existe el cod del producto en la tabla TI001,se suma la cantidad a lo que hay
            cantOriginal = _Tabla.Rows(0).Item(0)
            _cant = cantOriginal + _cant
            Sql = "iacant =" + _cant

            _where = "iacprod ='" + _codProd + "'"
            _Err = D_Modificar_Datos("TI001", Sql, _where)
        Else ' no existe el cod de producto en la tabla TI001, se crea un nuevo registro con ese codigo y la cantidad
            Sql = "'" + _codProd + "'," + _cant
            _Err = D_Insertar_Datos("TI001", Sql)
        End If
    End Sub

    Public Shared Sub L_Actualizar_StockMovimiento(_codProd As String, _cant As String, _alm As String)
        'verificamos si es que ya existe el codigo del producto en la tabla TI001
        Dim _Err As Boolean
        Dim Sql, _where As String


        Dim _Tabla As DataTable
        Dim cantOriginal
        _Tabla = D_Datos_Tabla("TI001.iacant", "TI001", "iacprod =" + _codProd + " and iaalm=" + _alm)
        If _Tabla.Rows.Count > 0 Then 'ya existe el cod del producto en la tabla TI001,se suma la cantidad a lo que hay
            cantOriginal = _Tabla.Rows(0).Item(0)
            _cant = cantOriginal + _cant
            Sql = "iacant =" + _cant

            _where = "iacprod =" + _codProd + " and iaalm=" + _alm
            _Err = D_Modificar_Datos("TI001", Sql, _where)
        Else ' no existe el cod de producto en la tabla TI001, se crea un nuevo registro con ese codigo y la cantidad
            Sql = "'" + _codProd + "'," + _cant + "," + _alm
            _Err = D_Insertar_Datos("TI001", Sql)
        End If

    End Sub

    Public Shared Function L_ConceptoInventario(tipo As String) As DataTable
        Dim Tabla As DataTable
        Dim Where As String
        Where = "cptipo=" + tipo + " and cpest=1"
        Tabla = D_Datos_Tabla("cpnumi, cpdesc, cpmov", "TCI001", Where + " order by cpnumi")
        Return Tabla
    End Function

#End Region

#Region "Saldo Inventario"

    Public Shared Function L_ObtenerStockInventario(_modo As Integer, Optional cod As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _where As String = IIf(cod.Equals(""), " a.iacprod =b.cacod ", " a.iacprod = " + cod)

        Select Case _modo
            Case 1 'Todos
                _where = _where + " and 1 = 1"
            Case 2 'Diferente de Cero
                _where = _where + " and a.iacant <> 0"
            Case 3 'Positivo
                _where = _where + " and a.iacant > 0"
            Case 4 'Negativo 
                _where = _where + " and a.iacant < 0"
        End Select
        _where = _where + " order by a.iacant desc"
        _Tabla = D_Datos_Tabla("a.iacprod as Codigo, b.cadesc as Producto, a.iacant as Cantidad", "TI001 a, TC001 b", _where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_KardexInventario() As DataTable
        Dim _Tabla As DataTable
        Dim _where As String = " 1 = 1 "

        _Tabla = D_Datos_Tabla("*", "VR_KardexInventario", _where)
        Return _Tabla

    End Function

    Public Shared Sub L_Actualizar_SaldoInventario(cod As String, cant As String, alm As String)
        'verificamos si es que ya existe el codigo del producto en la tabla TI001
        Dim _Err As Boolean
        Dim _where As String = "iacprod =" + cod + " and iaalm = " + alm
        _Err = D_Modificar_Datos("TI001", "iacant = " + cant, _where)
    End Sub

#End Region

#Region "CATEGORIAS PRECIOS"

    Public Shared Function L_CategoriaPrecioGrabar(ByRef _numi As String, _abrev As String, _nom As String) As Boolean
        Dim _Error As Boolean

        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TC007", "cinumi", "1 = 1")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If
        Dim _Actualizacion As String = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"
        Dim _valores As String
        _valores = _numi + ",'" + _abrev + "','" + _nom + "'," + _Actualizacion

        _Error = D_Insertar_Datos("TC007", _valores)
        Return Not _Error
    End Function
    Public Shared Function L_CategoriaPrecioGeneral(Optional _Cadena As String = "", Optional _order As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where, _campos As String
        If _Cadena = "" Then
            _Where = "1=1"
        Else
            _Where = _Cadena
        End If
        _order = IIf(_order = "", " order by cinumi", " order by " + _order)
        _campos = " cinumi,cicod,cidesc "
        _Tabla = D_Datos_Tabla(_campos, "TC007", _Where + _order)
        Return _Tabla
    End Function
    Public Shared Function L_CategoriaPrecioGeneral2(Optional _Cadena As String = "", Optional _order As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where, _campos As String
        If _Cadena = "" Then
            _Where = "1=1"
        Else
            _Where = _Cadena
        End If
        _order = IIf(_order = "", " order by tam,chcatcl", " order by " + _order)
        _campos = " distinct len(chcatcl) as tam,chcatcl,chdesc "
        _Tabla = D_Datos_Tabla(_campos, "TC003", _Where + _order)
        Return _Tabla
    End Function
    Public Shared Function L_CategoriaPrecioModificar(ByRef _numi As String, _fApertura As String, _fCierre As String, _turno As String, _obs As String, _user As String, _estado As String, _efectivo As String) As Boolean
        Dim _Error As Boolean
        Dim Sql, _where As String

        Sql = "odfaper ='" + _fApertura + "', " +
        "odfcierre ='" + _fCierre + "', " +
        "odturno = " + _turno + ", " +
        "odobs = '" + _obs + "', " +
        "oduser = " + _user + ", " +
        "odest = " + _estado + ", " +
        "odefec = " + _efectivo + ", " +
        "odfact = '" + Left(Today.Date.ToString, 10) + "', " +
        "odhact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "oduact = '" + L_Usuario + "'"

        _where = "odnumi = " + _numi
        _Error = D_Modificar_Datos("TO003", Sql, _where)
        Return Not _Error
    End Function

    Public Shared Function L_CategoriaPrecioBorrar(_Id As String) As Boolean

        Dim _Where As String
        Dim _Error As Boolean

        _Where = "odnumi = " + _Id
        _Error = D_Eliminar_Datos("TO003", _Where)
        Return Not _Error
    End Function

#End Region

#Region "Saldo Cliente"

    Public Shared Sub L_Actualizar_Saldo(codCli As String, monto As String)
        'verificamos si es que ya existe el codigo del producto en la tabla TI001
        Dim _Err As Boolean
        Dim Sql, _where As String

        Dim _Tabla As DataTable
        Dim cantOriginal
        _Tabla = D_Datos_Tabla("TI003.idsaldo", "TI003", "idcodcli =" + codCli)
        If _Tabla.Rows.Count > 0 Then 'ya existe el cod del producto en la tabla TI001,se suma la cantidad a lo que hay
            cantOriginal = _Tabla.Rows(0).Item(0)
            monto = cantOriginal + monto
            Sql = "idsaldo =" + monto

            _where = "idcodcli ='" + codCli + "'"
            _Err = D_Modificar_Datos("TI003", Sql, _where)
        Else ' no existe el cod de producto en la tabla TI001, se crea un nuevo registro con ese codigo y la cantidad
            Sql = codCli + ", " + monto
            _Err = D_Insertar_Datos("TI003", Sql)
        End If

    End Sub

    Public Shared Sub L_Actualizar_SaldoTotal(codCli As String, monto As String)
        'verificamos si es que ya existe el codigo del producto en la tabla TI001
        Dim _Err As Boolean
        Dim _where As String = "idcodcli ='" + codCli + "'"
        _Err = D_Modificar_Datos("TI003", "idsaldo = " + monto, _where)
    End Sub

    Public Shared Function L_ObtenerSaldoCliente(_modo As Integer, Optional codC As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _where As String = IIf(codC.Equals(""), "", " And idcodcli = " + codC) + " order by a.idsaldo desc"
        Select Case _modo
            Case 1 'Todos
                _where = " 1 = 1 " + _where
            Case 2 'Diferente de Cero
                _where = " a.idsaldo <> 0 " + _where
            Case 3 'Positivo
                _where = " a.idsaldo > 0 " + _where
            Case 4 'Negativo 
                _where = " a.idsaldo < 0 " + _where
        End Select

        _Tabla = D_Datos_Tabla("a.idcodcli, a.ccdesc, a.idsaldo",
                               "VR_SaldoCliente a",
                               _where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds

    End Function

#End Region

#Region "CONFIGURACION DEL SISTEMA"

    Public Shared Function L_ConfSistemaGeneral() As DataTable
        Dim _Tabla As DataTable
        Dim _Where, _campos As String
        Dim _dtConfSist As DataTable = D_Datos_Tabla("cnumi", "TC000", "1=1")

        _Where = "cccnumi=" + _dtConfSist.Rows(0).Item("cnumi").ToString
        _campos = "*"
        _Tabla = D_Datos_Tabla(_campos, "TC0001", _Where)
        Return _Tabla
    End Function
    Public Shared Function L_ConfSistemaModificar(ByRef _numi As String) As Boolean
        Dim _Error As Boolean
        Dim Sql, _where As String

        Sql = "cnumi =" + _numi

        _where = "1=1"
        _Error = D_Modificar_Datos("TC000", Sql, _where)
        Return Not _Error
    End Function

#End Region

#Region "Vistas"
    Shared Function L_VistaPagos(_fIni As String, _fFin As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String

        _Where = "ogfdoc>='" + _fIni + "' And ogfdoc<='" + _fFin + "'"

        Dim campos As String = "ognumi,ognota,ogfdoc,ogcli,ccdesc,ogmon,ogfact,oghact,oguact,ogrec"
        _Tabla = D_Datos_Tabla(campos, "VR_Pagos", _Where + " order by ogfdoc")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    Shared Function L_VistaFacturas(_fIni As String, _fFin As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String

        _Where = "odfdoc>='" + _fIni + "' And odfdoc<='" + _fFin + "' And oenfac <> 0"

        Dim campos As String = "*"
        _Tabla = D_Datos_Tabla(campos, "VR_FacturasChacaltaya", _Where + " order by oenfac")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    Shared Function L_VistaKardexPrestamos(_fIni As String, _fFin As String, Optional _where1 As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _where1 = String.Empty Then
            _Where = "chfec>='" + _fIni + "' And chfec<='" + _fFin + "'"
        Else
            _Where = "chfec>='" + _fIni + "' And chfec<='" + _fFin + "' and " + _where1
        End If

        Dim campos As String = "chnumi,ccdesc,cczona,cedesc,chfec,chdesc,tipo,chnota,chcan,chmonbs,chmonsus,chtmov"
        _Tabla = D_Datos_Tabla(campos, "VR_KardexPrestamos", _Where + " order by chfec asc")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Shared Function L_VistaClientes(Optional _where1 As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _where1 = String.Empty Then
            _Where = "1=1"
        Else
            _Where = _where1
        End If

        Dim campos As String = "ccnumi,ccdesc,cctelf1,cctelf2,ccdirec,cczona,cedesc,cccat,cicod,cidesc,ccest"
        _Tabla = D_Datos_Tabla(campos, "VR_Clientes", _Where + " order by ccdesc")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Shared Function L_VistaGraficasVentasVs(where1 As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String

        _Where = where1

        Dim campos As String = "*"
        _Tabla = D_Datos_Tabla(campos, "VR_GraficaVentasVs", _Where + " order by oafdoc")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    Shared Function L_VistaStockActual(Optional _where1 As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _where1 = String.Empty Then
            _Where = "1=1"
        Else
            _Where = _where1
        End If

        Dim campos As String = "canumi,cacod,cadesc,cadesc2,caest,iacprod,iacant,cenum,cedesc "
        _Tabla = D_Datos_Tabla(campos, "VR_stockActual", _Where + " order by cadesc")
        Return _Tabla
    End Function
    Shared Function L_VistaStockDisponible(Optional _where1 As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _where1 = String.Empty Then
            _Where = "1=1"
        Else
            _Where = _where1
        End If

        Dim campos As String = "canumi,cadesc,categoria,stockSinPedido,StockSoloPedidos,StockFinal "
        _Tabla = D_Datos_Tabla(campos, "VR_StockDisponible", _Where + " order by cadesc")
        Return _Tabla
    End Function
#End Region

#Region "Kardex de Clientes"

    Shared Function L_VistaKadexClienteUltimo(ccli As String, fIni As String, fFin As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String

        If (ccli.Equals("-1")) Then
            _Where = "ccli = " + ccli + " And fecha >= '" + fIni + "' And fecha <= '" + fFin + "'"
        Else
            _Where = "ccli = " + ccli + " And fecha >= '" + fIni + "' And fecha <= '" + fFin + "'"
        End If


        Dim campos As String = "*"
        _Tabla = D_Datos_Tabla(campos, "VR_KadexCliente", _Where + " order by fecha")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Shared Function L_VistaKadexClienteTodo(ccli As String, Optional fFin As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String = "ccli = " + ccli + IIf(fFin.Equals(""), "", " And fecha <= '" + fFin + "'")
        Dim campos As String = "*"
        _Tabla = D_Datos_Tabla(campos, "VR_KadexCliente", _Where + " order by fecha")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Shared Function L_VistaKadexClienteMes(ccli As String, Optional mIni As String = "", Optional mFin As String = "",
                                               Optional aIni As String = "", Optional aFin As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String = "ccli = " + ccli _
                               + IIf(mIni.Equals(""), "", " And Month(fecha) >= " + mIni) _
                               + IIf(mFin.Equals(""), "", " And Month(fecha) <= " + mFin) _
                               + IIf(aIni.Equals(""), "", " And Year(fecha) >= " + aIni) _
                               + IIf(aFin.Equals(""), "", " And Year(fecha) <= " + aFin)
        Dim campos As String = "*"
        _Tabla = D_Datos_Tabla(campos, "VR_KadexCliente", _Where + " order by fecha")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

#End Region

#Region "SALDO MENSUALES"

    Public Shared Function L_GrabarSaldoMensual(ByVal campos As String) As Boolean
        Try
            Return D_Insertar_Datos("TH001", campos)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function L_EliminarSaldoMensual(ByVal where As String) As Boolean
        Try
            Return D_Eliminar_Datos("TH001", where)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Shared Function L_ObtenerSaldosMensuales(Optional where As String = "") As DataTable
        If (where.Equals("")) Then
            where = "1 = 1"
        End If

        Dim campos As String = "*"
        Return D_Datos_Tabla(campos, "TH001", where + " order by hasaldo desc")
    End Function

#End Region

#Region "MENSAJERIA"

    Public Shared Function L_MensajeriaGrabar(ByRef _numi As String, _idUsuario As String, _idPara As String, _nota As String, _fecha As String, _hora As String, _leido As String) As Boolean
        Dim _Error As Boolean

        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TC008", "cjnumi", "1 = 1")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If
        Dim _valores As String
        _valores = _numi + "," + _idUsuario + "," + _idPara + ",'" + _nota + "','" + _fecha + "','" + _hora + "'," + _leido

        _Error = D_Insertar_Datos("TC008", _valores)
        Return Not _Error
    End Function
    Public Shared Function L_MensajeriaGeneral(Optional _Cadena As String = "", Optional _order As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where, _campos As String
        If _Cadena = "" Then
            _Where = "z1.ydnumi=cjusuario and z2.ydnumi=cjpara"
        Else
            _Where = "z1.ydnumi=cjusuario and z2.ydnumi=cjpara and " + _Cadena
        End If
        _order = IIf(_order = "", " order by cjnumi", " order by " + _order)
        _campos = " cjnumi,cjusuario,z1.yduser as yduser1,cjpara,z2.yduser as yduser2,cjnota,cjfecha,cjhora,cjleido "
        _Tabla = D_Datos_Tabla(_campos, "TC008,ZY003 z1, ZY003 z2", _Where + _order)
        Return _Tabla
    End Function

    Public Shared Function L_MensajeriaModificar(ByRef _numi As String, _idUsuario As String, _idPara As String, _nota As String, _fecha As String, _hora As String, _leido As String) As Boolean
        Dim _Error As Boolean
        Dim Sql, _where As String

        Sql = "cjusuario =" + _idUsuario + ", " +
        "cjpara =" + _idPara + ", " +
        "cjnota = " + _nota + ", " +
        "cjfecha = '" + _fecha + "', " +
        "cjhora = '" + _hora + "', " +
        "cjleido = " + _leido

        _where = "cjnumi = " + _numi
        _Error = D_Modificar_Datos("TC008", Sql, _where)
        Return Not _Error
    End Function

    Public Shared Function L_MensajeriaBorrar(_Id As String) As Boolean

        Dim _Where As String
        Dim _Error As Boolean

        _Where = "cjnumi = " + _Id
        _Error = D_Eliminar_Datos("TC008", _Where)
        Return Not _Error
    End Function

    Public Shared Function L_MensajeriaModificarLeido(ByRef _numi As String, _leido As String) As Boolean
        Dim _Error As Boolean
        Dim Sql, _where As String

        Sql = "cjleido = " + _leido

        _where = "cjnumi = " + _numi
        _Error = D_Modificar_Datos("TC008", Sql, _where)
        Return Not _Error
    End Function
#End Region

#Region "Libro Venta Chacaltaya"

    Public Shared Function L_ObtenerLibroVenta(fechaIni As String, fechaFin As String) As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        _Where = " fec >= '" + fechaIni + "' and fec <= '" + fechaFin + "' order by fec, fac"
        _Tabla = D_Datos_Tabla("*", "VR_LibroVentasChacaltaya2", _Where)
        Return _Tabla
    End Function

#End Region

#Region "Kardex de Inventario"

    Shared Function L_VistaKardexInventario(cod As String, fIni As String, fFin As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String

        If (cod.Equals("-1")) Then
            _Where = "cprod = " + cod + " And fdoc >= '" + fIni + "' And fdoc <= '" + fFin + "'"
        Else
            _Where = "cprod = " + cod + " And fdoc >= '" + fIni + "' And fdoc <= '" + fFin + "'"
        End If

        Dim campos As String = "*"
        _Tabla = D_Datos_Tabla(campos, "VR_KardexInventario", _Where + " order by fdoc")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Shared Function L_VistaKardexInventarioTodo(cod As String, Optional fFin As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String = "cprod = " + cod + IIf(fFin.Equals(""), "", " And fdoc < '" + fFin + "'")
        Dim campos As String = "*"
        _Tabla = D_Datos_Tabla(campos, "VR_KardexInventario", _Where + " order by fdoc")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

#End Region

#Region "AUDITORIA"
    Public Shared Function L_ObtenerAuditoria(_nomTabla As String, _preFijoTabla As String, _where As String) As DataTable
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla(_preFijoTabla + "fact," + _preFijoTabla + "hact," + _preFijoTabla + "uact", _nomTabla, _where)
        Return _Tabla
    End Function
#End Region

#Region "GET CLASES"
    Public Shared Function L_ClaseGetCliente(_numi As String, Optional _Cadena As String = "") As Client
        Dim _Tabla As DataTable
        Dim _Where, _campos As String
        If _Cadena = "" Then
            _Where = "ccnumi=" + _numi
        Else
            _Where = "ccnumi=" + _numi + " AND " + _Cadena
        End If

        _campos = "ccnumi,cccod,ccdesc,cczona,ccdct,ccdctnum,ccdirec,cctelf1,cctelf2,cccat,ccest,cclat,cclongi," +
                  "ccprconsu,cceven,ccobs,ccfnac,ccnomfac,ccnit,ccultped,ccfecing,ccultvent,ccfact,cchact,ccuact"
        _Tabla = D_Datos_Tabla(_campos, "TC004", _Where)

        Dim objCliente As Client
        If _Tabla.Rows.Count > 0 Then
            With _Tabla.Rows(0)
                objCliente = New Client(.Item("ccnumi"), .Item("cccod"), .Item("ccdesc"), .Item("cczona"), .Item("ccdct").ToString, .Item("ccdctnum").ToString, .Item("ccdirec"),
                                    .Item("cctelf1").ToString, .Item("cctelf2").ToString, .Item("cccat"), .Item("ccest"), .Item("cclat"), .Item("cclongi"), .Item("ccprconsu"),
                                    .Item("cceven"), .Item("ccobs").ToString, .Item("ccfnac"), .Item("ccnomfac").ToString, .Item("ccnit").ToString, .Item("ccultped"), .Item("ccfecing"),
                                    .Item("ccultvent"), .Item("ccfact"), .Item("cchact"), .Item("ccuact"))
            End With
        Else
            objCliente = Nothing
        End If
        Return objCliente
    End Function

    Public Shared Function L_ClaseGetProducto(_numi As String, Optional _Cadena As String = "") As Product
        Dim _Tabla As DataTable
        Dim _Where, _campos As String
        If _Cadena = "" Then
            _Where = "canumi=" + _numi
        Else
            _Where = "canumi=" + _numi + " AND " + _Cadena
        End If

        _campos = "canumi,cacod,cadesc,cadesc2,cacat,caimg,castc,caest,caserie,cafact,cahact,cauact"
        _Tabla = D_Datos_Tabla(_campos, "TC001", _Where)

        Dim objProducto As Product
        If _Tabla.Rows.Count > 0 Then
            With _Tabla.Rows(0)
                objProducto = New Product(.Item("canumi"), .Item("cacod"), .Item("cadesc"), .Item("cadesc2"), .Item("cacat"), .Item("caimg"), .Item("castc"),
                                    .Item("caest"), .Item("caserie"), .Item("cafact"), .Item("cahact"), .Item("cauact"))
            End With
        Else
            objProducto = Nothing
        End If
        Return objProducto
    End Function
#End Region

#Region "TC002 PERSONAL"

    Public Shared Function L_fnPersonal() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnGrabarPersonal(ByRef numi As String, desc As String, direc As String, telef As String,
                                              cat As String, sal As String, ci As String, obs As String, fnac As String,
                                              fing As String, fret As String, fot As String, est As String,
                                              eciv As String, plan As String, reloj As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@desc", desc))
        _listParam.Add(New Datos.DParametro("@direc", direc))
        _listParam.Add(New Datos.DParametro("@telef", telef))
        _listParam.Add(New Datos.DParametro("@cat", cat))
        _listParam.Add(New Datos.DParametro("@sal", sal))
        _listParam.Add(New Datos.DParametro("@ci", ci))
        _listParam.Add(New Datos.DParametro("@obs", obs))
        _listParam.Add(New Datos.DParametro("@fnac", fnac))
        _listParam.Add(New Datos.DParametro("@fing", fing))
        _listParam.Add(New Datos.DParametro("@fret", fret))
        _listParam.Add(New Datos.DParametro("@fot", fot))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@eciv", eciv))
        _listParam.Add(New Datos.DParametro("@plan", plan))
        _listParam.Add(New Datos.DParametro("@reloj", reloj))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnModificarPersonal(ByRef numi As String, desc As String, direc As String, telef As String,
                                                  cat As String, sal As String, ci As String, obs As String, fnac As String,
                                                  fing As String, fret As String, fot As String, est As String,
                                                  eciv As String, plan As String, reloj As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@desc", desc))
        _listParam.Add(New Datos.DParametro("@direc", direc))
        _listParam.Add(New Datos.DParametro("@telef", telef))
        _listParam.Add(New Datos.DParametro("@cat", cat))
        _listParam.Add(New Datos.DParametro("@sal", sal))
        _listParam.Add(New Datos.DParametro("@ci", ci))
        _listParam.Add(New Datos.DParametro("@obs", obs))
        _listParam.Add(New Datos.DParametro("@fnac", fnac))
        _listParam.Add(New Datos.DParametro("@fing", fing))
        _listParam.Add(New Datos.DParametro("@fret", fret))
        _listParam.Add(New Datos.DParametro("@fot", fot))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@eciv", eciv))
        _listParam.Add(New Datos.DParametro("@plan", plan))
        _listParam.Add(New Datos.DParametro("@reloj", reloj))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnEliminarPersonal(numi As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "TC0022"
    Public Shared Function L_TC0022General(_numi As String) As DataTable
        Dim _Tabla As DataTable
        Dim _Where, _campos As String
        _Where = "cknumi=" + _numi
        _campos = " cknumi,ckidfsm"
        _Tabla = D_Datos_Tabla(_campos, "TC0022", _Where)
        Return _Tabla
    End Function
#End Region

#Region "TC009 MANUALES"

    Public Shared Function L_fnManuales() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC009", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnManualesDetalle(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC009", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnGrabarManual(ByRef numi As String, desc As String, est As String, ByRef pdf As String, obs As String,
                                            detalle As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@desc", desc))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@pdf", pdf))
        _listParam.Add(New Datos.DParametro("@obs", obs))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TC0091", "", detalle))

        _Tabla = D_ProcedimientoConParam("sp_go_TC009", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            pdf = "manual_" + numi + ".pdf"
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnModificarManual(ByRef numi As String, desc As String, est As String, pdf As String, obs As String,
                                            detalle As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@desc", desc))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@pdf", pdf))
        _listParam.Add(New Datos.DParametro("@obs", obs))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TC0091", "", detalle))

        _Tabla = D_ProcedimientoConParam("sp_go_TC009", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnEliminarManual(numi As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC009", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnManualesPorUsuario(codu As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@codu", codu))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC009", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnModificarManualUsuario(ByRef numi As String, est As String, codu As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@codu", codu))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC009", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "TC010 PROVEEDOR"

    Public Shared Function L_fnProveedores() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC010", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnGrabarProveedor(ByRef numi As String, desc As String, telf As String, email As String,
                                               rsocial As String, nit As String, est As String,
                                               obs As String, cuenta As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@desc", desc))
        _listParam.Add(New Datos.DParametro("@telf", telf))
        _listParam.Add(New Datos.DParametro("@email", email))
        _listParam.Add(New Datos.DParametro("@rsocial", rsocial))
        _listParam.Add(New Datos.DParametro("@nit", nit))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@obs", obs))
        _listParam.Add(New Datos.DParametro("@cuenta", cuenta))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC010", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnModificarProveedor(ByRef numi As String, desc As String, telf As String, email As String,
                                                  rsocial As String, nit As String, est As String,
                                                  obs As String, cuenta As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@desc", desc))
        _listParam.Add(New Datos.DParametro("@telf", telf))
        _listParam.Add(New Datos.DParametro("@email", email))
        _listParam.Add(New Datos.DParametro("@rsocial", rsocial))
        _listParam.Add(New Datos.DParametro("@nit", nit))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@obs", obs))
        _listParam.Add(New Datos.DParametro("@cuenta", cuenta))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC010", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnEliminarProveedor(numi As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TC010", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prCuentaGeneralBasico() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        '_listParam.Add(New Datos.DParametro("@canumi", _numiEmpresa))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_go_TC010", _listParam)

        Return _Tabla
    End Function

#End Region

#Region "TCP001 CUENTAS POR PAGAR"

    Public Shared Function L_fnCuentasPagar() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCP001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnCuentasPagarComboProveedor() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCP001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnGrabarCuentaPagar(ByRef numi As String, prov As String,
                                                monto As String, obs As String,
                                                est As String, fven As String, fdoc As String,
                                                tpago As String, fpro As String, nota As String, tpro As String,
                                                ffec As String, fnit As String, frsocial As String,
                                                fnro As String, fautoriz As String, fmonto As String,
                                                fccont As String, fmcfiscal As String, fdesc As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@prov", prov))
        _listParam.Add(New Datos.DParametro("@fdoc", fdoc))
        _listParam.Add(New Datos.DParametro("@monto", monto))
        _listParam.Add(New Datos.DParametro("@obs", obs))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@fven", fven))
        _listParam.Add(New Datos.DParametro("@tpago", tpago))
        _listParam.Add(New Datos.DParametro("@fpro", fpro))
        _listParam.Add(New Datos.DParametro("@nota", nota))
        _listParam.Add(New Datos.DParametro("@tpro", tpro))
        If (fpro = "1") Then
            _listParam.Add(New Datos.DParametro("@ffec", ffec))
            _listParam.Add(New Datos.DParametro("@fnit", fnit))
            _listParam.Add(New Datos.DParametro("@frsocial", frsocial))
            _listParam.Add(New Datos.DParametro("@fnro", fnro))
            _listParam.Add(New Datos.DParametro("@fautoriz", fautoriz))
            _listParam.Add(New Datos.DParametro("@fmonto", fmonto))
            _listParam.Add(New Datos.DParametro("@fccont", fccont))
            _listParam.Add(New Datos.DParametro("@fmcfiscal", fmcfiscal))
            _listParam.Add(New Datos.DParametro("@fdesc", fdesc))
        End If
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCP001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnModificarCuentaPagar(ByRef numi As String, prov As String,
                                                monto As String, obs As String,
                                                est As String, fven As String, fdoc As String,
                                                Optional tpago As String = "", Optional fpro As String = "", Optional nota As String = "", Optional tpro As String = "",
                                                Optional ffec As String = "", Optional fnit As String = "", Optional frsocial As String = "",
                                                Optional fnro As String = "", Optional fautoriz As String = "", Optional fmonto As String = "",
                                                Optional fccont As String = "", Optional fmcfiscal As String = "", Optional fdesc As String = "") As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@prov", prov))
        _listParam.Add(New Datos.DParametro("@monto", monto))
        _listParam.Add(New Datos.DParametro("@obs", obs))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@fven", fven))
        _listParam.Add(New Datos.DParametro("@fdoc", fdoc))
        If (Not tpago = String.Empty) Then
            _listParam.Add(New Datos.DParametro("@tpago", tpago))
        End If
        If (Not fpro = String.Empty) Then
            _listParam.Add(New Datos.DParametro("@fpro", fpro))
            _listParam.Add(New Datos.DParametro("@nota", nota))
            _listParam.Add(New Datos.DParametro("@tpro", tpro))
            If (fpro = "1") Then
                _listParam.Add(New Datos.DParametro("@ffec", ffec))
                _listParam.Add(New Datos.DParametro("@fnit", fnit))
                _listParam.Add(New Datos.DParametro("@frsocial", frsocial))
                _listParam.Add(New Datos.DParametro("@fnro", fnro))
                _listParam.Add(New Datos.DParametro("@fautoriz", fautoriz))
                _listParam.Add(New Datos.DParametro("@fmonto", fmonto))
                _listParam.Add(New Datos.DParametro("@fccont", fccont))
                _listParam.Add(New Datos.DParametro("@fmcfiscal", fmcfiscal))
                _listParam.Add(New Datos.DParametro("@fdesc", fdesc))
            End If
        End If
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCP001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnEliminarCuentaPagar(numi As String, ByRef mensaje As String) As Boolean
        Dim _resultado As Boolean

        If (L_fnbValidarEliminacion(numi, "TCP001", "cpanumi", mensaje) = True) Then
            Dim _Tabla As DataTable
            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@numi", numi))
            _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_go_TCP001", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnCuentasPagar_ReportePagosProximos(Optional prov As String = "", Optional fven As String = "") As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        If (Not prov = String.Empty) Then
            _listParam.Add(New Datos.DParametro("@prov", prov))
        End If
        _listParam.Add(New Datos.DParametro("@fven", fven))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCP001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnCuentasPagar_ReportePagosRealizados(Optional prov As String = "", Optional fini As String = "", Optional ffin As String = "") As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        If (Not prov = String.Empty) Then
            _listParam.Add(New Datos.DParametro("@prov", prov))
        End If
        _listParam.Add(New Datos.DParametro("@fdoc", fini))
        _listParam.Add(New Datos.DParametro("@fven", ffin))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCP001", _listParam)

        Return _Tabla
    End Function


    Public Shared Function L_fnCuentasPagarDatosFactura(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 12))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCP001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnCuentasPagarDatosFacturaRsNit(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 13))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCP001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnCuentasPagarValidarFactura(fnit As String, fnro As String, fccont As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 14))
        _listParam.Add(New Datos.DParametro("@fnit", fnit))
        _listParam.Add(New Datos.DParametro("@fnro", fnro))
        _listParam.Add(New Datos.DParametro("@fccont", fccont))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCP001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnCuentasPagarValidarMontoPagado(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 15))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCP001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnEliminarPagoCuentaPagar2(numi As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 16))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCP001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "TCP0011 PAGO DE CUENTAS POR PAGAR"

    Public Shared Function L_fnPagoCuentasPagar() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCP001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnPagoCuentasPagarProveedor(prov As String, Optional est As String = "") As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@prov", prov))
        If (Not est = String.Empty) Then
            _listParam.Add(New Datos.DParametro("@est", est))
        End If
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCP001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnGrabarPagoCuentaPagar(ByRef numi As String, detalle As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TCP0011", "", detalle))

        _Tabla = D_ProcedimientoConParam("sp_go_TCP001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnPagoCuentasPagarProveedorDetalle(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCP001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnModificarPagoCuentaPagar(ByRef numi As String, prov As String, monto As String, obs As String, fven As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@prov", prov))
        _listParam.Add(New Datos.DParametro("@monto", monto))
        _listParam.Add(New Datos.DParametro("@obs", obs))
        _listParam.Add(New Datos.DParametro("@fven", fven))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCP001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnEliminarPagoCuentaPagar(numi As String, detalle As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 11))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TCP0011", "", detalle))

        _Tabla = D_ProcedimientoConParam("sp_go_TCP001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "RUTAS"
    Public Shared Function L_RutaGeneral(Optional _Cadena As String = "", Optional _order As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where, _campos As String
        If _Cadena = "" Then
            _Where = "1=1"
        Else
            _Where = _Cadena
        End If
        _order = IIf(_order = "", " order by ldnumi", " order by " + _order)
        _campos = " ldnumi,ldchof,ldfec,ldhora,lblat,lblongi "
        _Tabla = D_Datos_Tabla(_campos, "TL002", _Where + _order)
        Return _Tabla
    End Function

    Public Shared Function L_RutaUltimoPunto(Optional _Cadena As String = "", Optional _order As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where, _campos As String
        If _Cadena = "" Then
            _Where = "1=1"
        Else
            _Where = _Cadena
        End If
        _order = IIf(_order = "", " order by ldnumi desc", " order by " + _order)
        _campos = " ldnumi,ldchof,ldfec,ldhora,lblat,lblongi "
        _Tabla = D_Datos_Tabla(_campos, "TL002", _Where + _order)
        Return _Tabla
    End Function
#End Region

#Region "TC011 TURNOS"

    Public Shared Function L_prTurnoGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@cnuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC011", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prTurnoDetalle(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@cnnumi", numi))
        _listParam.Add(New Datos.DParametro("@cnuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC011", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prTurnoGrabar(ByRef numi As String, fecha As String, obs As String, est As String,
                                            detalle As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@cnnumi", numi))
        _listParam.Add(New Datos.DParametro("@cnfdoc", fecha))
        _listParam.Add(New Datos.DParametro("@cnobs", obs))
        _listParam.Add(New Datos.DParametro("@cnest", est))
        _listParam.Add(New Datos.DParametro("@cnuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TC0111", "", detalle))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC011", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prTurnoModificar(numi As String, fecha As String, obs As String, est As String,
                                            detalle As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@cnnumi", numi))
        _listParam.Add(New Datos.DParametro("@cnfdoc", fecha))
        _listParam.Add(New Datos.DParametro("@cnobs", obs))
        _listParam.Add(New Datos.DParametro("@cnest", est))
        _listParam.Add(New Datos.DParametro("@cnuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TC0111", "", detalle))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC011", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prTurnoEliminar(numi As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@cnnumi", numi))
        _listParam.Add(New Datos.DParametro("@cnuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC011", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "TZ001 Interfaz Marcador"

    Public Shared Function L_prInterfazMarcadorGrabar(tabla As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@tabla", "", tabla))

        _Tabla = D_ProcedimientoConParam("sp_dg_TZ001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prInterfazMarcadorModificarEstados(tabla As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@tabla", "", tabla))

        _Tabla = D_ProcedimientoConParam("sp_dg_TZ001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prInterfazMarcadorGetFechas(_codEmpl As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@zacper", _codEmpl))

        _Tabla = D_ProcedimientoConParam("sp_dg_TZ001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prInterfazMarcadorGetEmpleados() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))

        _Tabla = D_ProcedimientoConParam("sp_dg_TZ001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prInterfazMarcadorGetHoras(_fechas As String, _codEmpl As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@zacper", _codEmpl))
        _listParam.Add(New Datos.DParametro("@zafecha", _fechas))


        _Tabla = D_ProcedimientoConParam("sp_dg_TZ001", _listParam)

        Return _Tabla
    End Function

#End Region

#Region "TP007"
    Public Shared Function L_prAsistenciaReportePlanilla() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@piuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP007", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prAsistenciaDatosPorPersonalGeneral(numiPer As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@picper", numiPer))
        _listParam.Add(New Datos.DParametro("@piuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP007", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAsistenciaEstructuraGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@piuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP007", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAsistenciaGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@cnuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC011", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAsistenciaDetalle(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@cnnumi", numi))
        _listParam.Add(New Datos.DParametro("@cnuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC011", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAsistenciaGrabarTabla(tabla As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@piuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TP007", "", tabla))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP007", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prAsistenciaGrabarTablaDetalle(tabla As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@piuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TP0071", "", tabla))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP007", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prAsistenciaModificar(numi As String, fecha As String, obs As String, est As String,
                                            detalle As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@cnnumi", numi))
        _listParam.Add(New Datos.DParametro("@cnfdoc", fecha))
        _listParam.Add(New Datos.DParametro("@cnobs", obs))
        _listParam.Add(New Datos.DParametro("@cnest", est))
        _listParam.Add(New Datos.DParametro("@cnuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TC0111", "", detalle))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC011", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prAsistenciaEliminar(numi As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@cnnumi", numi))
        _listParam.Add(New Datos.DParametro("@cnuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC011", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "Libro de Ventas"

    Public Shared Function L_ObtenerLV(_CodAlm As String, _Mes As String, _Anho As String) As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String = "fvaalm = " + _CodAlm + "and Month(fvafec) = " + _Mes + " and Year(fvafec) = " + _Anho + " ORDER BY fvafec"
        _Tabla = D_Datos_Tabla("*",
                               "VR_LibroVentas", _Where)
        Return _Tabla
        'SELECT a.ybalm, a.ybdes, a.ybcon1
        'FROM TY002 a
        'ORDER BY a.ybalm
    End Function

    Public Shared Function L_ObtenerAnhoFactura() As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String = "1 = 1 ORDER BY year(fvafec)"
        _Tabla = D_Datos_Tabla("Distinct(year(fvafec)) AS anho",
                               "VR_LibroVentas", _Where)
        Return _Tabla
        'SELECT Distinct(year(fvafec)) AS anho
        'FROM VR_LibroVentas
        'WHERE 1=1
        'ORDER BY year(fvafec)
    End Function

    Public Shared Function L_ObtenerSucursalesFactura() As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String = "1 = 1 ORDER BY a.scnumi"
        _Tabla = D_Datos_Tabla("a.scnumi, a.scnom, a.scnit",
                               "TS003 a", _Where)
        Return _Tabla
        'SELECT a.scnumi, a.scnom, a.scnit FROM TS003 a WHERE 1 = 1 ORDER BY a.scnumi
    End Function

#End Region

#Region "BDDist TCI001"
    Public Shared Function L_ObtenerDatosTCI001(tipo As String) As DataTable
        'OBTENCION_DETALLE_GRID
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@tipo1", tipo))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCI001", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_AgregarDatosTCI001(ByRef numi As String, desc As String, mov As String, movcli As String,
                                                tipo1 As String, est As String) As Boolean
        'OBTENCION_DETALLE_GRID
        Dim _resultado As Boolean
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@desc", desc))
        _listParam.Add(New Datos.DParametro("@mov", mov))
        _listParam.Add(New Datos.DParametro("@movcli", movcli))
        _listParam.Add(New Datos.DParametro("@tipo1", tipo1))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCI001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_ModificarDatosTCI001(ByRef numi As String, desc As String, mov As String, movcli As String,
                                                  tipo1 As String, est As String) As Boolean
        'OBTENCION_DETALLE_GRID
        Dim _resultado As Boolean
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@desc", desc))
        _listParam.Add(New Datos.DParametro("@mov", mov))
        _listParam.Add(New Datos.DParametro("@movcli", movcli))
        _listParam.Add(New Datos.DParametro("@tipo1", tipo1))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCI001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_EliminarDatosTCI001(numi As Integer) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCI001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
#End Region

#Region "VR_GO_KardexPrestamosAgrupado"

    Shared Function L_VistaPrestamoEquiposAgrupado(Optional codCli As String = "") As DataTable
        Dim Tabla As DataTable
        Dim Where As String
        If (codCli = String.Empty) Then
            Where = "1=1"
        Else
            Where = "chnumi=" + codCli
        End If

        Dim campos As String = "*"
        Tabla = D_Datos_Tabla(campos, "VR_GO_PrestamoEquiposAgrupado", Where + " order by chcod asc")
        Return Tabla
    End Function

    Shared Function L_VistaPrestamoEquiposDetalle(Optional codCli As String = "", Optional fini As String = "", Optional ffin As String = "") As DataTable
        Dim Tabla As DataTable
        Dim Where As String
        If (fini = String.Empty And ffin = String.Empty) Then
            Where = "chnumi=" + codCli + " and cpmovcli=1"
        Else
            Where = "chnumi=" + codCli + " and chfec >='" + fini + "' and chfec<='" + ffin + "' and cpmovcli=1"
        End If

        Dim campos As String = "*"
        Tabla = D_Datos_Tabla(campos, "VR_GO_PrestamoEquiposDetallado", Where + " order by chfec asc")
        Return Tabla
    End Function

#End Region

#Region "METODOS MARCO"
#Region "MApasClientes"
    Public Shared Function L_prMapaCLienteGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@ccuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_go_TC004", _listParam)

        Return _Tabla
    End Function
#End Region
#End Region

#Region "VR_UltimaVentaCliente"

    Shared Function L_VistaUltimaVentaCliente(fini As String, ffin As String, czona As String, criterio As String) As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String = ""

        If (criterio = String.Empty) Then
            _Where = _Where + "fultven>='" + fini + "' and fultven<='" + ffin + "' and czona=" + czona
        Else
            _Where = _Where + "fultven>='" + fini + "' and fultven<='" + ffin + "' and czona=" + czona + " and direc like '%" + criterio + "%'"
        End If

        'Dim campos As String = "numi, rsoc, format(fultven, 'dd/MM/yyyy') as fultven, telf, direc, czona, dpto, prov, zona, est"
        Dim campos As String = "numi, rsoc, fultven, telf, direc, czona, dpto, prov, zona, est"
        _Tabla = D_Datos_Tabla(campos, "VR_GO_UltimaVentaCliente", _Where + " order by fultven asc")
        Return _Tabla
    End Function

#End Region

#Region "VR_FaltanteTapas"

    Shared Function L_VistaFaltanteTapas(fini As String, ffin As String, crepa As String, criterio As String) As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String = ""

        If (crepa.Equals("0")) Then
            _Where = "fecha>='" + fini + "' and fecha<='" + ffin + "'"
        Else
            _Where = "fecha>='" + fini + "' and fecha<='" + ffin + "' and crepa=" + crepa
        End If

        _Where = _Where + IIf(criterio = String.Empty, "", criterio)

        'Dim campos As String = "nota, format(fecha, 'dd/MM/yyyy') as fecha, ctprod, ntprod, crepa, nrepa, tapas"
        Dim campos As String = "nota, fecha, ctprod, ntprod, crepa, nrepa, tapas"
        _Tabla = D_Datos_Tabla(campos, "VR_GO_FaltanteTapas", _Where + " order by fecha asc")
        Return _Tabla
    End Function

#End Region

#Region "VR_SaldoPrestamoEquiposUV"

    Shared Function L_VistaSaldoPrestamoEquiposUV(fecha As String, czona As String) As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String = "fultven<='" + fecha + "' and czona=" + czona

        'Dim campos As String = "numi, [desc], format(fultven,'dd/MM/yyyy') as fultven, telf, dir, saldo, cequi, nequi, czona, dpto, prov, zona"
        Dim campos As String = "numi, [desc], fultven, telf, dir, saldo, cequi, nequi, czona, dpto, prov, zona"
        _Tabla = D_Datos_Tabla(campos, "VR_GO_EquipoPrestadoVsUltimaVenta", _Where + " order by [desc] asc")
        Return _Tabla
    End Function

#End Region

#Region "TO0023"

    Public Shared Function L_fnGrabarTO0023(ByRef numi As String, tc1 As String, tc4 As String, cant As String,
                                            est As String, dif As String, to1 As String, to2 As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@tc1", tc1))
        _listParam.Add(New Datos.DParametro("@tc4", tc4))
        _listParam.Add(New Datos.DParametro("@cant", cant))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@dif", dif))
        _listParam.Add(New Datos.DParametro("@to1", to1))
        _listParam.Add(New Datos.DParametro("@to2", to2))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TO0023", _listParam)
        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If
        Return _resultado
    End Function

    Public Shared Function L_fnModificarTO0023(ByRef numi As String, tc1 As String, tc4 As String, cant As String,
                                               est As String, dif As String, to1 As String, to2 As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@tc1", tc1))
        _listParam.Add(New Datos.DParametro("@tc4", tc4))
        _listParam.Add(New Datos.DParametro("@cant", cant))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@dif", dif))
        _listParam.Add(New Datos.DParametro("@to1", to1))
        _listParam.Add(New Datos.DParametro("@to2", to2))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TO0023", _listParam)
        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If
        Return _resultado
    End Function

    Public Shared Function L_fnGeneralTO0023(ByRef numi As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TO0023", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnTO0023ValidarPedido(ByRef to1 As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@to1", to1))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TO0023", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnTO0023Eliminar(ByRef numi As String, numi2 As String) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@tc1", numi2))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TO0023", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
#End Region

#Region "TP008 planillas"
    Public Shared Function L_prPlanillaSueldoGetDetalle(_numiCab) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@pknumi", _numiCab))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP008", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prPlanillaSueldoVerificarExistenciaReg(_numiPer As String, _mes As String, _anio As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@pkper", _numiPer))
        _listParam.Add(New Datos.DParametro("@pkmes", _mes))
        _listParam.Add(New Datos.DParametro("@pkanio", _anio))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP008", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prPlanillaSueldoVerificarExistenciaReg2(_mes As String, _anio As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 51))
        _listParam.Add(New Datos.DParametro("@pkmes", _mes))
        _listParam.Add(New Datos.DParametro("@pkanio", _anio))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP008", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prPlanillaSueldoGrabar(_numiPer As String, _mes As String, _anio As String, tabla As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@pkper", _numiPer))
        _listParam.Add(New Datos.DParametro("@pkmes", _mes))
        _listParam.Add(New Datos.DParametro("@pkanio", _anio))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TP0081", "", tabla))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP008", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function


    Public Shared Function L_prPlanillaSueldoEliminar(numi As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@pknumi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP008", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prPlanillaSueldoEliminarPorMesYAnio(_mes As String, _anio As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -2))
        _listParam.Add(New Datos.DParametro("@pkmes", _mes))
        _listParam.Add(New Datos.DParametro("@pkanio", _anio))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP008", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prPlanillaSueldoEliminarPorNumiPersonalMesAnio(_numiPer As String, _mes As String, _anio As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -3))
        _listParam.Add(New Datos.DParametro("@pkper", _numiPer))
        _listParam.Add(New Datos.DParametro("@pkmes", _mes))
        _listParam.Add(New Datos.DParametro("@pkanio", _anio))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP008", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "TL001 Zona"

    Public Shared Function L_fnZonaGeneral() As DataTable
        Dim Tabla As DataTable
        Dim Where As String = "1=1"
        Tabla = D_Datos_Tabla("*",
                              "VR_GO_ListarZona",
                              Where)
        Return Tabla
    End Function

#End Region

#Region "TI002 MOVIMIENTOS DE SALIDA DEL CHOFER BIOPETROL"

    'Public Shared Function L_prMovimientoChoferGeneral() As DataTable
    '    Dim _Tabla As DataTable

    '    Dim _listParam As New List(Of Datos.DParametro)

    '    _listParam.Add(New Datos.DParametro("@tipo", 3))
    '    _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))

    '    _Tabla = D_ProcedimientoConParam("sp_Mam_TM001", _listParam)

    '    Return _Tabla
    'End Function
    'Public Shared Function L_prMovimientoChoferListarProductos() As DataTable
    '    Dim _Tabla As DataTable

    '    Dim _listParam As New List(Of Datos.DParametro)

    '    _listParam.Add(New Datos.DParametro("@tipo", 5))
    '    _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))

    '    _Tabla = D_ProcedimientoConParam("sp_Mam_TM001", _listParam)

    '    Return _Tabla
    'End Function
    'Public Shared Function L_prMovimientoChoferListarChoferes() As DataTable
    '    Dim _Tabla As DataTable

    '    Dim _listParam As New List(Of Datos.DParametro)

    '    _listParam.Add(New Datos.DParametro("@tipo", 6))
    '    _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))

    '    _Tabla = D_ProcedimientoConParam("sp_Mam_TM001", _listParam)

    '    Return _Tabla
    'End Function

    Public Shared Function L_prMovimientoChoferNoExisteConciliacion(_chofer As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 16))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@chofer", _chofer))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prMovimientoChoferExisteConciliacionSalida(_chofer As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 17))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@chofer", _chofer))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function

    'Public Shared Function L_prMovimientoChoferDetalle(numi As String) As DataTable
    '    Dim _Tabla As DataTable

    '    Dim _listParam As New List(Of Datos.DParametro)

    '    _listParam.Add(New Datos.DParametro("@tipo", 4))
    '    _listParam.Add(New Datos.DParametro("@ibid", numi))
    '    _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))

    '    _Tabla = D_ProcedimientoConParam("sp_Mam_TM001", _listParam)

    '    Return _Tabla
    'End Function

    Public Shared Function L_prConciliacionObtenerProducto(_ibid As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@ibid", _ibid))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prConciliacionObtenerIdNumiTI002(_ibid As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@ibid", _ibid))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prConciliacionObtenerProductoTI0021(_ibid As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 13))
        _listParam.Add(New Datos.DParametro("@ibid", _ibid))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prConciliacionObtenerProductoTI0021Idnumi(_ibid As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 14))
        _listParam.Add(New Datos.DParametro("@ibid", _ibid))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prConciliacionObtenerPedidoEntregado(idrepa As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 20))
        _listParam.Add(New Datos.DParametro("@ibidchof", idrepa))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prConciliacionObtenerPedidoEntregadoGral(idrepa As String, idfecha As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 23))
        _listParam.Add(New Datos.DParametro("@ibidchof", idrepa))
        _listParam.Add(New Datos.DParametro("@ibfdoc", idfecha))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prConciliacionObtenerPedidoEntregadoGrabado(ibid As String, idrepa As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 22))
        _listParam.Add(New Datos.DParametro("@ibid", ibid))
        _listParam.Add(New Datos.DParametro("@ibidchof", idrepa))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function

    'Public Shared Function L_prMovimientoChoferABMDetalle(numi As String, Type As Integer, detalle As DataTable) As DataTable
    '    Dim _Tabla As DataTable

    '    Dim _listParam As New List(Of Datos.DParametro)

    '    _listParam.Add(New Datos.DParametro("@tipo", Type))
    '    _listParam.Add(New Datos.DParametro("@ibid", numi))
    '    _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
    '    _listParam.Add(New Datos.DParametro("@TM0011", "", detalle))
    '    _Tabla = D_ProcedimientoConParam("sp_Mam_TM001", _listParam)

    '    Return _Tabla
    'End Function
    Public Shared Function L_prMovimientoChoferModificarTI0022(Type As Integer, _ibid As String, _ibest As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", Type))
        _listParam.Add(New Datos.DParametro("@ibest", _ibest))
        _listParam.Add(New Datos.DParametro("@ibid", _ibid))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prMovimientoChoferGrabar(ByRef _ibid As String, _ibfdoc As String, _ibconcep As Integer, _ibobs As String, _ibidchof As Integer, _idConciliacion As Integer) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@ibid", _ibid))
        _listParam.Add(New Datos.DParametro("@ibfdoc", _ibfdoc))
        _listParam.Add(New Datos.DParametro("@ibconcep", _ibconcep))
        _listParam.Add(New Datos.DParametro("@ibobs", _ibobs))
        _listParam.Add(New Datos.DParametro("@ibest", 1))
        _listParam.Add(New Datos.DParametro("@ibalm", 1))
        _listParam.Add(New Datos.DParametro("@ibiddc", 0))
        _listParam.Add(New Datos.DParametro("@ibidchof", _ibidchof))
        _listParam.Add(New Datos.DParametro("@ibidvent", 0))
        _listParam.Add(New Datos.DParametro("@ibidconcil", _idConciliacion))

        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _ibid = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function



    'Public Shared Function L_prMovimientoChoferModificar(ByRef _ibid As String, _ibfdoc As String, _ibconcep As Integer, _ibobs As String, _ibidchof As Integer) As Boolean
    '    Dim _resultado As Boolean

    '    Dim _Tabla As DataTable
    '    Dim _listParam As New List(Of Datos.DParametro)

    '    _listParam.Add(New Datos.DParametro("@tipo", 2))
    '    _listParam.Add(New Datos.DParametro("@ibid", _ibid))
    '    _listParam.Add(New Datos.DParametro("@ibfdoc", _ibfdoc))
    '    _listParam.Add(New Datos.DParametro("@ibconcep", _ibconcep))
    '    _listParam.Add(New Datos.DParametro("@ibobs", _ibobs))
    '    _listParam.Add(New Datos.DParametro("@ibest", 1))
    '    _listParam.Add(New Datos.DParametro("@ibalm", 1))
    '    _listParam.Add(New Datos.DParametro("@ibiddc", 0))
    '    _listParam.Add(New Datos.DParametro("@ibidchof", _ibidchof))
    '    _listParam.Add(New Datos.DParametro("@ibidvent", 0))
    '    _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
    '    _Tabla = D_ProcedimientoConParam("sp_Mam_TM001", _listParam)
    '    If _Tabla.Rows.Count > 0 Then
    '        _resultado = True
    '    Else
    '        _resultado = False
    '    End If

    '    Return _resultado
    'End Function

    'Public Shared Function L_prMovimientoChofeEliminar(numi As String) As Boolean
    '    Dim _resultado As Boolean

    '    Dim _Tabla As DataTable
    '    Dim _listParam As New List(Of Datos.DParametro)

    '    _listParam.Add(New Datos.DParametro("@tipo", -1))
    '    _listParam.Add(New Datos.DParametro("@ibid", numi))
    '    _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))

    '    _Tabla = D_ProcedimientoConParam("sp_Mam_TM001", _listParam)

    '    If _Tabla.Rows.Count > 0 Then
    '        _resultado = True
    '    Else
    '        _resultado = False
    '    End If

    '    Return _resultado
    'End Function

#End Region

#Region "TI002 MOVIMIENTOS DE SALIDA DE PRODUCTOS PARA EL CHOFER BIOPETROL"

    Public Shared Function L_prMovimientoChoferGeneralSalida(_idconcepto As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@concepto", _idconcepto))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prMovimientoChoferGeneralSalidaTop20(_idconcepto As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -3))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@concepto", _idconcepto))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prMovimientoChoferGeneralEntrada(_idconcepto As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 19))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@concepto", _idconcepto))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prMovimientoChoferGeneralEntradaTop20(_idconcepto As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -19))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@concepto", _idconcepto))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prMovimientoChoferListarProductosSalida(dt As DataTable) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TM0011", "", dt))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prMovimientoChoferListarChoferesSalida() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function


    Public Shared Function L_prMovimientoChoferDetalleSalida(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@ibid", numi))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prMovimientoChoferDetalleSalida2(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 41))
        _listParam.Add(New Datos.DParametro("@ibid", numi))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prMovimientoChoferConceptoSalida() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function
    ' @ibid ,@ibfdoc,@ibconcep ,@ibobs  ,@ibest,
    '@ibalm ,@ibiddc,@ibidchof ,@ibidvent ,@newFecha,@newHora,@ibuact
    Public Shared Function L_prMovimientoChoferGrabarSalida(ByRef _ibid As String, _ibfdoc As String, _ibconcep As Integer, _ibobs As String, _ibidchof As Integer, _idConciliacion As Integer, _detalle As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@ibid", _ibid))
        _listParam.Add(New Datos.DParametro("@ibfdoc", _ibfdoc))
        _listParam.Add(New Datos.DParametro("@ibconcep", _ibconcep))
        _listParam.Add(New Datos.DParametro("@ibobs", _ibobs))
        _listParam.Add(New Datos.DParametro("@ibest", 1))
        _listParam.Add(New Datos.DParametro("@ibalm", 1))
        _listParam.Add(New Datos.DParametro("@ibiddc", 0))
        _listParam.Add(New Datos.DParametro("@ibidchof", _ibidchof))
        _listParam.Add(New Datos.DParametro("@ibidvent", 0))
        _listParam.Add(New Datos.DParametro("@ibidconcil", _idConciliacion))
        _listParam.Add(New Datos.DParametro("@TM0011", "", _detalle))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _ibid = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function



    Public Shared Function L_prMovimientoChoferModificarSalida(ByRef _ibid As String, _ibfdoc As String, _ibconcep As Integer, _ibobs As String, _ibidchof As Integer, _detalle As DataTable, _icibid As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@ibid", _ibid))
        _listParam.Add(New Datos.DParametro("@ibfdoc", _ibfdoc))
        _listParam.Add(New Datos.DParametro("@ibconcep", _ibconcep))
        _listParam.Add(New Datos.DParametro("@ibobs", _ibobs))
        _listParam.Add(New Datos.DParametro("@ibest", 1))
        _listParam.Add(New Datos.DParametro("@ibalm", 1))
        _listParam.Add(New Datos.DParametro("@ibiddc", _icibid))
        _listParam.Add(New Datos.DParametro("@ibidchof", _ibidchof))
        _listParam.Add(New Datos.DParametro("@ibidvent", 0))
        _listParam.Add(New Datos.DParametro("@TM0011", "", _detalle))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)
        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prMovimientoChoferInsertarEnlacePedidoMovil(ByRef _ibid As String, _detalle As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 21))
        _listParam.Add(New Datos.DParametro("@ibid", _ibid))
        _listParam.Add(New Datos.DParametro("@TM0013", "", _detalle))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)
        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prMovimientoChofeEliminarSalida(numi As String, _icibid As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@ibid", numi))
        _listParam.Add(New Datos.DParametro("@ibiddc", _icibid))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "TO004 Venta"


    Public Shared Function L_prNotaGeneral() As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@ohuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO004", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prNotaDetalleConciliacion(_ohnumi As Integer) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@ohuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@ohnumi", _ohnumi))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO004", _listParam)
        Return _Tabla
    End Function

    Public Shared Function L_prNotaObtenerPrecioClienteProducto(_cliente As Integer, _producto As Integer) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@ohuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@cliente", _cliente))
        _listParam.Add(New Datos.DParametro("@producto", _producto))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO004", _listParam)
        Return _Tabla
    End Function

    Public Shared Function L_prNotaListarCLientes() As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@ohuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO004", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prNotaListarConciliaciones() As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@ohuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO004", _listParam)
        Return _Tabla
    End Function


    Public Shared Function L_prNotaObtenerProductosConciliacion(_conciliacion As Integer) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@ohuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@ohconc", _conciliacion))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO004", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prNotaDetalleCLiente(_ohnumi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@ohuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@ohnumi", _ohnumi))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO004", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prObtenerClienteEntregaMovil(ohconc As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 11))
        _listParam.Add(New Datos.DParametro("@ohuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@ohconc", ohconc))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO004", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prObtenerProductoEntregaMovil(ohconc As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 12))
        _listParam.Add(New Datos.DParametro("@ohuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@ohconc", ohconc))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO004", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prNotaObtenerProductosConciliacionMovil(ohconc As Integer) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 13))
        _listParam.Add(New Datos.DParametro("@ohuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@ohconc", ohconc))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO004", _listParam)
        Return _Tabla
    End Function

    Public Shared Function L_prNotaDetalleCLienteProdCantPrec(ohconc As Integer, codCliente As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 14))
        _listParam.Add(New Datos.DParametro("@ohuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@ohconc", ohconc))
        _listParam.Add(New Datos.DParametro("@ohnumi", codCliente))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO004", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prNotaDetalleCLienteProductos(_ohnumiDetale As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@ohuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@ojnumi", _ohnumiDetale))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO004", _listParam)

        Return _Tabla
    End Function

    ' @ibid ,@ibfdoc,@ibconcep ,@ibobs  ,@ibest,
    '@ibalm ,@ibiddc,@ibidchof ,@ibidvent ,@newFecha,@newHora,@ibuact
    Public Shared Function L_prNotaVentaGrabar(ByRef _ohnumi As String, _ohfec As String, _ohest As Integer,
                                               _ohconc As Integer, _TO0041 As DataTable,
                                               _TO0042 As DataTable, _TO0043 As DataTable) As Boolean
        Dim _resultado As Boolean
        '@ohnumi ,@ohfec ,@ohconc ,@ohest ,@newFecha,@newHora,@ohuact
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@ohnumi", _ohnumi))
        _listParam.Add(New Datos.DParametro("@ohfec", _ohfec))
        _listParam.Add(New Datos.DParametro("@ohconc", _ohconc))
        _listParam.Add(New Datos.DParametro("@ohest", _ohest))
        _listParam.Add(New Datos.DParametro("@TO0041", "", _TO0041))
        _listParam.Add(New Datos.DParametro("@TO0042", "", _TO0042))
        _listParam.Add(New Datos.DParametro("@TO0043", "", _TO0043))
        _listParam.Add(New Datos.DParametro("@ohuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO004", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _ohnumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function



    Public Shared Function L_prNotaVentaModificar(ByRef _ohnumi As String, _ohfec As String, _ohest As Integer,
                                               _ohconc As Integer, _TO0041 As DataTable,
                                               _TO0042 As DataTable, _TO0043 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@ohnumi", _ohnumi))
        _listParam.Add(New Datos.DParametro("@ohfec", _ohfec))
        _listParam.Add(New Datos.DParametro("@ohconc", _ohconc))
        _listParam.Add(New Datos.DParametro("@ohest", _ohest))
        _listParam.Add(New Datos.DParametro("@TO0041", "", _TO0041))
        _listParam.Add(New Datos.DParametro("@TO0042", "", _TO0042))
        _listParam.Add(New Datos.DParametro("@TO0043", "", _TO0043))
        _listParam.Add(New Datos.DParametro("@ohuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO004", _listParam)
        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prNotaVentaEliminar(numi As String, _conciliacion As Integer) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@ohnumi", numi))
        _listParam.Add(New Datos.DParametro("@ohuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@ohconc", _conciliacion))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO004", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "TI002 MOVIMIENTOS DE SALIDA DEL CHOFER BIOPETROL"

    Public Shared Function L_prMovimientoChoferGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prMovimientoChoferListarProductos() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prMovimientoChoferListarChoferes() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prMovimientoChoferDetalle(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@ibid", numi))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prConciliacionObtenerProducto(_chofer As Integer, _fecha As String, _concepto As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@chofer", _chofer))
        _listParam.Add(New Datos.DParametro("@ibfdoc", _fecha))
        _listParam.Add(New Datos.DParametro("@concepto", _concepto))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prConciliacionObtenerIdNumiTI002(_chofer As Integer, _fecha As String, _concepto As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@chofer", _chofer))
        _listParam.Add(New Datos.DParametro("@ibfdoc", _fecha))
        _listParam.Add(New Datos.DParametro("@concepto", _concepto))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prConciliacionObtenerProductoTI0021(_chofer As Integer, _fecha As String, _concepto As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 13))
        _listParam.Add(New Datos.DParametro("@chofer", _chofer))
        _listParam.Add(New Datos.DParametro("@ibfdoc", _fecha))
        _listParam.Add(New Datos.DParametro("@concepto", _concepto))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function


    Public Shared Function L_prMovimientoChoferABMDetalle(numi As String, Type As Integer, detalle As DataTable) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", Type))
        _listParam.Add(New Datos.DParametro("@ibid", numi))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TI0021", "", detalle))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prMovimientoChoferConcepto() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        Return _Tabla
    End Function
    ' @ibid ,@ibfdoc,@ibconcep ,@ibobs  ,@ibest,
    '@ibalm ,@ibiddc,@ibidchof ,@ibidvent ,@newFecha,@newHora,@ibuact
    Public Shared Function L_prMovimientoChoferGrabar(ByRef _ibid As String, _ibfdoc As String, _ibconcep As Integer, _ibobs As String, _ibidchof As Integer) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@ibid", _ibid))
        _listParam.Add(New Datos.DParametro("@ibfdoc", _ibfdoc))
        _listParam.Add(New Datos.DParametro("@ibconcep", _ibconcep))
        _listParam.Add(New Datos.DParametro("@ibobs", _ibobs))
        _listParam.Add(New Datos.DParametro("@ibest", 1))
        _listParam.Add(New Datos.DParametro("@ibalm", 1))
        _listParam.Add(New Datos.DParametro("@ibiddc", 0))
        _listParam.Add(New Datos.DParametro("@ibidchof", _ibidchof))
        _listParam.Add(New Datos.DParametro("@ibidvent", 0))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _ibid = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prMovimientoChoferModificar(ByRef _ibid As String, _ibfdoc As String, _ibconcep As Integer, _ibobs As String, _ibidchof As Integer) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@ibid", _ibid))
        _listParam.Add(New Datos.DParametro("@ibfdoc", _ibfdoc))
        _listParam.Add(New Datos.DParametro("@ibconcep", _ibconcep))
        _listParam.Add(New Datos.DParametro("@ibobs", _ibobs))
        _listParam.Add(New Datos.DParametro("@ibest", 1))
        _listParam.Add(New Datos.DParametro("@ibalm", 1))
        _listParam.Add(New Datos.DParametro("@ibiddc", 0))
        _listParam.Add(New Datos.DParametro("@ibidchof", _ibidchof))
        _listParam.Add(New Datos.DParametro("@ibidvent", 0))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)
        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prMovimientoChofeEliminar(numi As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@ibid", numi))
        _listParam.Add(New Datos.DParametro("@ibuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TM001SalidaChofer", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "ROLES CORRECTO"

    Public Shared Function L_prRolGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_ZY002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prListarZonas() As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _Tabla = D_ProcedimientoConParam("sp_Mam_ReporteVentas", _listParam)
        Return _Tabla
    End Function
    Public Shared Function GrabarDetalleZona(_dt As DataTable) As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@TL0012", "", _dt))
        _Tabla = D_ProcedimientoConParam("sp_Mam_ReporteVentas", _listParam)
        If (_Tabla.Rows.Count > 0) Then
            Return True
        End If
        Return False
    End Function

    Public Shared Function L_prRolDetalleGeneral(_numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@ybnumi", _numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_ZY002", _listParam)

        Return _Tabla
    End Function


    Public Shared Function L_prRolGrabar(ByRef _numi As String, _rol As String, _detalle As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@ybnumi", _numi))
        _listParam.Add(New Datos.DParametro("@ybrol", _rol))
        _listParam.Add(New Datos.DParametro("@ZY0021", "", _detalle))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_ZY002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
            'L_prTipoCambioGrabarHistorial(_numi, _fecha, _dolar, _ufv, "TIPO DE CAMBIO", 1)
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prRolModificar(_numi As String, _rol As String, _detalle As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@ybnumi", _numi))
        _listParam.Add(New Datos.DParametro("@ybrol", _rol))
        _listParam.Add(New Datos.DParametro("@ZY0021", "", _detalle))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_ZY002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
            'L_prTipoCambioGrabarHistorial(_numi, _fecha, _dolar, _ufv, "TIPO DE CAMBIO", 2)
        Else
            _resultado = False
        End If

        Return _resultado
    End Function



    Public Shared Function L_prRolBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "ZY002", "ybnumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@ybnumi", _numi))
            _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_dg_ZY002", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _resultado = True
                'L_prTipoCambioGrabarHistorial(_numi, _fecha, _dolar, _ufv, "TIPO DE CAMBIO", 3)
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function



#End Region

#Region "TI002 Movimientos"

    Public Shared Function L_fnMovimientoGeneral(est As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TI002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnMovimientoDetalle(id As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@id", id))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TI002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnMovimientoGrabar(ByRef id As String, fdoc As String, concep As String, obs As String,
                                                est As String, alm As String, iddc As String, TI0021 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@id", id))
        _listParam.Add(New Datos.DParametro("@fdoc", fdoc))
        _listParam.Add(New Datos.DParametro("@concep", concep))
        _listParam.Add(New Datos.DParametro("@obs", obs))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@alm", alm))
        _listParam.Add(New Datos.DParametro("@iddc", iddc))
        _listParam.Add(New Datos.DParametro("@TI0021", "", TI0021))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TI002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            id = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnMovimientoModificar(ByRef id As String, fdoc As String, concep As String, obs As String,
                                                   est As String, alm As String, iddc As String, TI0021 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@id", id))
        _listParam.Add(New Datos.DParametro("@fdoc", fdoc))
        _listParam.Add(New Datos.DParametro("@concep", concep))
        _listParam.Add(New Datos.DParametro("@obs", obs))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@alm", alm))
        _listParam.Add(New Datos.DParametro("@iddc", iddc))
        _listParam.Add(New Datos.DParametro("@TI0021", "", TI0021))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TI002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            id = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnMovimientoBorrar(id As String) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@id", id))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TI002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            id = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "TCA001 Compra"

    Public Shared Function L_fnCompraGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCA001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prServicioListarCuentas(id As String, proveedor As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@seuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@proveedor", proveedor))
        _listParam.Add(New Datos.DParametro("@Id", id))
        _Tabla = D_ProcedimientoConParam("sp_Mam_Asiento", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prObtenerPlantila(id As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 35))
        _listParam.Add(New Datos.DParametro("@seuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@Id", id))
        _Tabla = D_ProcedimientoConParam("sp_Mam_Asiento", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prComprobanteGrabarIntegracion(ByRef _numi As String, _numDoc As String, _tipo As String, _anio As String, _mes As String, _num As String, _fecha As String, _tipoCambio As String, _glosa As String, _obs As String, _numiEmpresa As String, _detalle As DataTable, _ifnumi As String, _ifto001numi As Integer, _iftc As Double,
                                                            _iffechai As String, _iffechaf As String, _ifest As Integer, _sucursal As Integer,
                                                            tipo As Integer, factura As Integer, fechai As String, fechaf As String, _oaTipo As Integer, numiPadre As Integer) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))

        _listParam.Add(New Datos.DParametro("@oanumdoc", _numDoc))
        _listParam.Add(New Datos.DParametro("@oatip", _oaTipo))
        _listParam.Add(New Datos.DParametro("@oaano", _anio))
        _listParam.Add(New Datos.DParametro("@oames", _mes))
        '_listParam.Add(New Datos.DParametro("@oanum", _num))
        _listParam.Add(New Datos.DParametro("@oafdoc", _fecha))
        _listParam.Add(New Datos.DParametro("@oatc", _tipoCambio))
        _listParam.Add(New Datos.DParametro("@oaglosa", ""))
        _listParam.Add(New Datos.DParametro("@oaobs", ""))
        _listParam.Add(New Datos.DParametro("@oaemp", _numiEmpresa))
        _listParam.Add(New Datos.DParametro("@TI005", "", _detalle))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        '@ifnumi int =-1,@ifto001numi int=-1,@iftc decimal(18,2)=null,
        '					 @iffechai date=null,@iffechaf date=null,@ifest int=-1
        _listParam.Add(New Datos.DParametro("@ifnumi", _ifnumi))
        _listParam.Add(New Datos.DParametro("@ifto001numi", _ifto001numi))
        _listParam.Add(New Datos.DParametro("@iftc", _iftc))
        _listParam.Add(New Datos.DParametro("@iffechai", _iffechai))
        _listParam.Add(New Datos.DParametro("@iffechaf", _iffechaf))
        _listParam.Add(New Datos.DParametro("@ifest", _ifest))
        _listParam.Add(New Datos.DParametro("@ifsuc", 1))  ''' Sucursal
        _listParam.Add(New Datos.DParametro("@plantilla", _sucursal))  '''Plantilla

        _listParam.Add(New Datos.DParametro("@modulo", tipo))
        _listParam.Add(New Datos.DParametro("@factura", factura))
        _listParam.Add(New Datos.DParametro("@fechaI", fechai))
        _listParam.Add(New Datos.DParametro("@fechaF", fechaf))
        _listParam.Add(New Datos.DParametro("@numiPadre", numiPadre))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TI005", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True

        Else
            _resultado = False
        End If

        Return _resultado
    End Function



    Public Shared Function L_prCuentaDiferencia(_cuenta As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 26))
        _listParam.Add(New Datos.DParametro("@cuenta", _cuenta))
        _listParam.Add(New Datos.DParametro("@seuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_Asiento", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prObtenerDetallePlantilla(cuenta As String, id As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 37))
        _listParam.Add(New Datos.DParametro("@seuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@Id", id))
        _listParam.Add(New Datos.DParametro("@cuenta", cuenta))
        _Tabla = D_ProcedimientoConParam("sp_Mam_Asiento", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnCompraDetalle(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCA001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnCompraGrabar(ByRef numi As String, fdoc As String, prov As String, nfac As String,
                                            obs As String, TCA0011 As DataTable, tven As Integer, fvcr As String,
                                            mon As Integer, desc As Double, total As Double, emision As Integer,
                                            consigna As Integer, retencion As Integer, asiento As Integer, fingreso As String, FacturaCompra As DataTable) As Boolean
        '@tven, @fvcred, @mon, @est, @desc, @total, @emision, @consigna
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@fdoc", fdoc))
        _listParam.Add(New Datos.DParametro("@prov", prov))
        _listParam.Add(New Datos.DParametro("@nfac", nfac))
        _listParam.Add(New Datos.DParametro("@obs", obs))
        _listParam.Add(New Datos.DParametro("@TCA0011", "", TCA0011))
        _listParam.Add(New Datos.DParametro("@tven", tven))
        _listParam.Add(New Datos.DParametro("@fvcred", fvcr))
        _listParam.Add(New Datos.DParametro("@mon", mon))
        _listParam.Add(New Datos.DParametro("@est", 1))
        _listParam.Add(New Datos.DParametro("@desc", desc))
        _listParam.Add(New Datos.DParametro("@total", total))
        _listParam.Add(New Datos.DParametro("@emision", emision))
        _listParam.Add(New Datos.DParametro("@consigna", consigna))
        _listParam.Add(New Datos.DParametro("@retenc", retencion))
        _listParam.Add(New Datos.DParametro("@asientoi", asiento))
        _listParam.Add(New Datos.DParametro("@fingreso", fingreso))
        _listParam.Add(New Datos.DParametro("@TFC001", "", FacturaCompra))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCA001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prCompraComprobanteGeneralPorNumi(_numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@numi", _numi))
        ' _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCA001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnCompraModificar(ByRef numi As String, fdoc As String, prov As String, nfac As String,
                                               obs As String, TCA0011 As DataTable, tven As Integer, fvcr As String,
                                               mon As Integer, desc As Double, total As Double, emision As Integer,
                                               consigna As Integer, retencion As Integer, asiento As Integer, FacturaCompra As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@fdoc", fdoc))
        _listParam.Add(New Datos.DParametro("@prov", prov))
        _listParam.Add(New Datos.DParametro("@nfac", nfac))
        _listParam.Add(New Datos.DParametro("@obs", obs))
        _listParam.Add(New Datos.DParametro("@TCA0011", "", TCA0011))
        _listParam.Add(New Datos.DParametro("@tven", tven))
        _listParam.Add(New Datos.DParametro("@fvcred", fvcr))
        _listParam.Add(New Datos.DParametro("@mon", mon))
        _listParam.Add(New Datos.DParametro("@desc", desc))
        _listParam.Add(New Datos.DParametro("@total", total))
        _listParam.Add(New Datos.DParametro("@emision", emision))
        _listParam.Add(New Datos.DParametro("@consigna", consigna))
        _listParam.Add(New Datos.DParametro("@retenc", retencion))
        _listParam.Add(New Datos.DParametro("@asientoi", asiento))
        _listParam.Add(New Datos.DParametro("@TFC001", "", FacturaCompra))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCA001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnCompraEliminar(numi As String) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCA001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_fnVerificarPagosCompras(numi As String) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_go_TCA001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If
        Return _resultado
    End Function
    Public Shared Function L_fnVerificarSiSeContabilizo(_canumi As String) As Boolean
        Dim _Tabla As DataTable
        Dim _resultado As Boolean
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@numi", _canumi))
        _Tabla = D_ProcedimientoConParam("sp_go_TCA001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "TCA00121 PagosCompras"
    Public Shared Function L_prListarBanco(cod1 As Integer, cod2 As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@teuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCA00121Cheque", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnGrabarCobranzaCompras(_tenumi As String, _tefdoc As String, _tety4vend As Integer, _teobs As String, detalle As DataTable) As Boolean
        Dim _Tabla As DataTable
        Dim _resultado As Boolean
        Dim _listParam As New List(Of Datos.DParametro)
        '   @canumi ,@caalm,@cafdoc ,@caty4prov  ,@catven,
        '@cafvcr,@camon ,@caest  ,@caobs ,@cadesc ,@newFecha,@newHora,@cauact
        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@tenumi", _tenumi))
        _listParam.Add(New Datos.DParametro("@tefdoc", _tefdoc))
        _listParam.Add(New Datos.DParametro("@tety4vend", _tety4vend))
        _listParam.Add(New Datos.DParametro("@teobs", _teobs))
        _listParam.Add(New Datos.DParametro("@teuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TC00121", "", detalle))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCA00121Cheque", _listParam)


        If _Tabla.Rows.Count > 0 Then
            _tenumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_fnModificarCobranzaCompras(_tenumi As String, _tefdoc As String, _tety4vend As Integer, _teobs As String, detalle As DataTable) As Boolean
        Dim _Tabla As DataTable
        Dim _resultado As Boolean
        Dim _listParam As New List(Of Datos.DParametro)
        '   @canumi ,@caalm,@cafdoc ,@caty4prov  ,@catven,
        '@cafvcr,@camon ,@caest  ,@caobs ,@cadesc ,@newFecha,@newHora,@cauact
        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@tenumi", _tenumi))
        _listParam.Add(New Datos.DParametro("@tefdoc", _tefdoc))
        _listParam.Add(New Datos.DParametro("@tety4vend", _tety4vend))
        _listParam.Add(New Datos.DParametro("@teobs", _teobs))
        _listParam.Add(New Datos.DParametro("@teuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TC00121", "", detalle))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCA00121Cheque", _listParam)


        If _Tabla.Rows.Count > 0 Then
            _tenumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_fnCobranzasGeneralCompra() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@teuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCA00121Cheque", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnCobranzasDetalleCompras(_numi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@teuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@tenumi", _numi))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCA00121Cheque", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnListarPagosCompras(_credito As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@credito", _credito))
        _listParam.Add(New Datos.DParametro("@teuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCA00121Cheque", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnCobranzasObtenerLasVentasACreditoCompras() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@teuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCA00121Cheque", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnCobranzasObtenerLosPagosCompra(_numi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@teuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@tdnumi", _numi))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCA00121Cheque", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnCobranzasReporteCompras(_numi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@teuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@tenumi", _numi))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCA00121Cheque", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnVerificarSiSeContabilizoPagoCompra(_tenumi As String) As Boolean
        Dim _Tabla As DataTable
        Dim _resultado As Boolean
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@tenumi", _tenumi))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCA00121Cheque", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_fnEliminarCobranzaCompras(numi As String, ByRef mensaje As String) As Boolean
        Dim _resultado As Boolean
        If L_fnbValidarEliminacion(numi, "TC0013", "tenumi", mensaje) = True Then
            Dim _Tabla As DataTable
            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@tenumi", numi))
            _listParam.Add(New Datos.DParametro("@teuact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_Mam_TCA00121Cheque", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If
        Return _resultado
    End Function
#End Region
#Region "TO005 Caja"


    Public Shared Function L_prCajaGrabar(ByRef _olnumi As String, _olnumichof As String, _olnumiconci As Integer, _olfecha As String, olmrec As String, _dt As DataTable) As Boolean
        Dim _resultado As Boolean
        '@olnumi,@olnumichof ,@olnumiconci ,@olfecha ,@newFecha ,@newHora ,@oluact
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@olnumi", _olnumi))
        _listParam.Add(New Datos.DParametro("@olnumichof", _olnumichof))
        _listParam.Add(New Datos.DParametro("@olnumiconci", _olnumiconci))
        _listParam.Add(New Datos.DParametro("@olfecha", _olfecha))
        _listParam.Add(New Datos.DParametro("@mrec", olmrec))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TO001", "", _dt))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _olnumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prReporteCreditoGeneral(fechaI As String, fechaF As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@fechaI", fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", fechaF))
        _listParam.Add(New Datos.DParametro("@yduact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_VentasCredito", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prCajaModificar(ByRef _olnumi As String, _olnumichof As String, _olnumiconci As Integer, _olfecha As String, _dt As DataTable) As Boolean
        Dim _resultado As Boolean
        '@olnumi,@olnumichof ,@olnumiconci ,@olfecha ,@newFecha ,@newHora ,@oluact
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@olnumi", _olnumi))
        _listParam.Add(New Datos.DParametro("@olnumichof", _olnumichof))
        _listParam.Add(New Datos.DParametro("@olnumiconci", _olnumiconci))
        _listParam.Add(New Datos.DParametro("@olfecha", _olfecha))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TO001", "", _dt))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _olnumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnCajaEliminar(numi As String, _dt As DataTable) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@olnumi", numi))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TO001", "", _dt))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prObtenerDetalleChofer(numi As String, fecha As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@olnumichof", numi))
        _listParam.Add(New Datos.DParametro("@olfecha", fecha))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function


    Public Shared Function L_prObtenerDetallePedidoFactura(numi As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 19))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function

    Public Shared Function GrabarTV001(numi As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 20))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function

    Public Shared Function updateTO001C(numi As String, NumFactura As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 21))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@nrofactura", NumFactura))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function

    Public Shared Function L_prObtenerDetalleDeCaja(numi As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@olnumi", numi))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prVerDetallePedido(numiPedido As Integer) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@pedido", numiPedido))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function

    Public Shared Function L_prListarConciliacion() As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function

    Public Shared Function L_prListarProductosMovil(_dt As DataTable) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TO001", "", _dt))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prListarProductosPC(_dt As DataTable) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TO001", "", _dt))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prCajaGeneral() As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function

    Public Shared Function L_prListarZona() As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function



    Public Shared Function L_prListarClienteZona(numizona As Integer) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 11))
        _listParam.Add(New Datos.DParametro("@zona", numizona))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prListarCliente() As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 12))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prListarClienteZona2(numizona As Integer, Fecha As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 13))
        _listParam.Add(New Datos.DParametro("@zona", numizona))
        _listParam.Add(New Datos.DParametro("@olfecha", Fecha))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prListarClienteZona3(numizona As Integer, Fecha As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 18))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@olfecha", Fecha))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function
    'Public Shared Function L_prListarCliente() As DataTable
    '    Dim _Tabla As DataTable
    '    Dim _listParam As New List(Of Datos.DParametro)
    '    _listParam.Add(New Datos.DParametro("@tipo", 16))
    '    _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
    '    _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
    '    Return _Tabla
    'End Function
    Public Shared Function L_prListarChofer() As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 15))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prListarClienteEstadoCuentasTodos(fechai As String, fechaf As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 13))
        _listParam.Add(New Datos.DParametro("@fechai", fechai))
        _listParam.Add(New Datos.DParametro("@fechaf", fechaf))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prListarEstadoCuentasPorCobrarTodos(fechai As String, fechaf As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 16))
        _listParam.Add(New Datos.DParametro("@fechai", fechai))
        _listParam.Add(New Datos.DParametro("@fechaf", fechaf))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prListarClienteEstadoCuentasPorCliente(idcliente As Integer, fechai As String, fechaf As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 14))
        _listParam.Add(New Datos.DParametro("@cliente", idcliente))
        _listParam.Add(New Datos.DParametro("@fechai", fechai))
        _listParam.Add(New Datos.DParametro("@fechaf", fechaf))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prListarEstadoCuentasPorCobrarPorCliente(idcliente As Integer, fechai As String, fechaf As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 17))
        _listParam.Add(New Datos.DParametro("@cliente", idcliente))
        _listParam.Add(New Datos.DParametro("@fechai", fechai))
        _listParam.Add(New Datos.DParametro("@fechaf", fechaf))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prNotaCajaEliminar(numi As String, _dt As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@olnumi", numi))
        _listParam.Add(New Datos.DParametro("@oluact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function


    Public Shared Function L_prLibreriaClienteLGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 12))
        _listParam.Add(New Datos.DParametro("@teuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TV00121Cheque", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnCobranzasDetalle(_numi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@teuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@tenumi", _numi))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TV00121Cheque", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnListarEmpleado() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 13))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TV00121Cheque", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnCobranzasObtenerLosPagos(_numi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@teuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@tdnumi", _numi))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TV00121Cheque", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnGrabarCobranza(_tenumi As String, _tefdoc As String, _tety4vend As Integer, _teobs As String, detalle As DataTable) As Boolean
        Dim _Tabla As DataTable
        Dim _resultado As Boolean
        Dim _listParam As New List(Of Datos.DParametro)
        '   @canumi ,@caalm,@cafdoc ,@caty4prov  ,@catven,
        '@cafvcr,@camon ,@caest  ,@caobs ,@cadesc ,@newFecha,@newHora,@cauact
        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@tenumi", _tenumi))
        _listParam.Add(New Datos.DParametro("@tefdoc", _tefdoc))
        _listParam.Add(New Datos.DParametro("@tety4vend", _tety4vend))
        _listParam.Add(New Datos.DParametro("@teobs", _teobs))
        _listParam.Add(New Datos.DParametro("@teuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TV00121", "", detalle))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TV00121Cheque", _listParam)


        If _Tabla.Rows.Count > 0 Then
            _tenumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_fnModificarCobranza(_tenumi As String, _tefdoc As String, _tety4vend As Integer, _teobs As String, detalle As DataTable) As Boolean
        Dim _Tabla As DataTable
        Dim _resultado As Boolean
        Dim _listParam As New List(Of Datos.DParametro)
        '   @canumi ,@caalm,@cafdoc ,@caty4prov  ,@catven,
        '@cafvcr,@camon ,@caest  ,@caobs ,@cadesc ,@newFecha,@newHora,@cauact
        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@tenumi", _tenumi))
        _listParam.Add(New Datos.DParametro("@tefdoc", _tefdoc))
        _listParam.Add(New Datos.DParametro("@tety4vend", _tety4vend))
        _listParam.Add(New Datos.DParametro("@teobs", _teobs))
        _listParam.Add(New Datos.DParametro("@teuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TV00121", "", detalle))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TV00121Cheque", _listParam)


        If _Tabla.Rows.Count > 0 Then
            _tenumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_fnEliminarCobranza(numi As String, ByRef mensaje As String) As Boolean
        Dim _resultado As Boolean
        If L_fnbValidarEliminacion(numi, "TV0013", "tenumi", mensaje) = True Then
            Dim _Tabla As DataTable
            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@tenumi", numi))
            _listParam.Add(New Datos.DParametro("@teuact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_Mam_TV00121Cheque", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If
        Return _resultado
    End Function
    Public Shared Function L_fnGrabarPagos(_numi As String, dt As DataTable) As Boolean
        Dim _Tabla As DataTable
        Dim _resultado As Boolean
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@tduact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@tdnumi", _numi))
        _listParam.Add(New Datos.DParametro("@TV00121", "", dt))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TV00121", _listParam)


        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_fnObtenerLosPagos(_numi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@tduact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@credito", _numi))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TV00121", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnCobranzasObtenerLasVentasACredito() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@teuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TV00121Cheque", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnCobranzasGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@teuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TV00121Cheque", _listParam)

        Return _Tabla
    End Function

#End Region

#Region "TC005C  CATEGORIA"


    Public Shared Function L_prCategoriaGrabar(ByRef _canumi As String, _canombre As String, _cadesc As String, _caimg As String, _estado As Integer) As Boolean
        Dim _resultado As Boolean
        '@canumi ,@canombre ,@cadesc ,@caimg ,@newFecha ,@newHora ,@cauact
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@canumi", _canumi))
        _listParam.Add(New Datos.DParametro("@canombre", _canombre))
        _listParam.Add(New Datos.DParametro("@cadesc", _cadesc))
        _listParam.Add(New Datos.DParametro("@caimg", _caimg))
        _listParam.Add(New Datos.DParametro("@caest", _estado))
        _listParam.Add(New Datos.DParametro("@cauact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TC005C", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _canumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prCategoriaModificar(ByRef _canumi As String, _canombre As String, _cadesc As String, _caimg As String, _caest As Integer) As Boolean
        Dim _resultado As Boolean
        '@canumi ,@canombre ,@cadesc ,@caimg ,@newFecha ,@newHora ,@cauact
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@canumi", _canumi))
        _listParam.Add(New Datos.DParametro("@canombre", _canombre))
        _listParam.Add(New Datos.DParametro("@cadesc", _cadesc))
        _listParam.Add(New Datos.DParametro("@caimg", _caimg))
        _listParam.Add(New Datos.DParametro("@caest", _caest))
        _listParam.Add(New Datos.DParametro("@cauact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TC005C", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _canumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnCategoriaEliminar(numi As String) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@canumi", numi))
        _listParam.Add(New Datos.DParametro("@cauact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TC005C", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prGeneralCategoria() As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TC005C", _listParam)
        Return _Tabla
    End Function
#End Region

#Region "REPORTE DE VENTAS"
    Public Shared Function L_prListarPrevendedor() As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _Tabla = D_ProcedimientoConParam("sp_Mam_ReporteVentas", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prListarDistribuidor() As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _Tabla = D_ProcedimientoConParam("sp_Mam_ReporteVentas", _listParam)
        Return _Tabla
    End Function


    Public Shared Function L_prObtenerDetallePedido(numi As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 18))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TO005", _listParam)
        Return _Tabla
    End Function

    Public Shared Function L_prListarReportePEdidosVsCosto(_fechaI As String, _FechaF As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@fechaI", _fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", _FechaF))
        _Tabla = D_ProcedimientoConParam("sp_Mam_ReporteVentas", _listParam)
        Return _Tabla
    End Function

    Public Shared Function L_prListarReporteUtilidadPorProducto(_fechaI As String, _FechaF As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 12))
        _listParam.Add(New Datos.DParametro("@fechaI", _fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", _FechaF))
        _Tabla = D_ProcedimientoConParam("sp_Mam_ReporteVentas", _listParam)
        Return _Tabla
    End Function

    Public Shared Function L_prListarReportePEdidosVsCostoUnVendedor(_fechaI As String, _FechaF As String, numiVendedor As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 11))
        _listParam.Add(New Datos.DParametro("@fechaI", _fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", _FechaF))
        _listParam.Add(New Datos.DParametro("@numi", numiVendedor))
        _Tabla = D_ProcedimientoConParam("sp_Mam_ReporteVentas", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prReporteVentasTodosPrevendedores(_fechaI As String, _FechaF As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@fechaI", _fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", _FechaF))
        _Tabla = D_ProcedimientoConParam("sp_Mam_ReporteVentas", _listParam)
        Return _Tabla
    End Function

    Public Shared Function L_prReporteVentasProductos(_fechaI As String, _FechaF As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@fechaI", _fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", _FechaF))
        _Tabla = D_ProcedimientoConParam("sp_Mam_ReporteVentas", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prReporteVentasTodosDistribuidores(_fechaI As String, _FechaF As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@fechaI", _fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", _FechaF))
        _Tabla = D_ProcedimientoConParam("sp_Mam_ReporteVentas", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prReporteVentasUnoPrevendedores(_fechaI As String, _FechaF As String, _codPrevendedor As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@fechaI", _fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", _FechaF))
        _listParam.Add(New Datos.DParametro("@prevendedor", _codPrevendedor))
        _Tabla = D_ProcedimientoConParam("sp_Mam_ReporteVentas", _listParam)
        Return _Tabla
    End Function

    Public Shared Function L_prReporteVentasUnoDistribuidor(_fechaI As String, _FechaF As String, _codPrevendedor As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@fechaI", _fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", _FechaF))
        _listParam.Add(New Datos.DParametro("@distribuidor", _codPrevendedor))
        _Tabla = D_ProcedimientoConParam("sp_Mam_ReporteVentas", _listParam)
        Return _Tabla
    End Function
#End Region

#Region "VENTAS ESTADISTICOS"
    Public Shared Function L_fnObtenerVendedores(_fechaI As String, _fechaF As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@fechaI", _fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", _fechaF))

        _listParam.Add(New Datos.DParametro("@yduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_VentasEstadisticos", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnObtenerVentasVendedores(_fechaI As String, _fechaF As String, _numiVendedor As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@fechaI", _fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", _fechaF))
        _listParam.Add(New Datos.DParametro("@vendedor", _numiVendedor))
        _listParam.Add(New Datos.DParametro("@yduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_VentasEstadisticos", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnObtenerCLientes(_fechaI As String, _fechaF As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@fechaI", _fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", _fechaF))

        _listParam.Add(New Datos.DParametro("@yduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_VentasEstadisticos", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnObtenerVentasClientes(_fechaI As String, _fechaF As String, _numiCliente As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@fechaI", _fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", _fechaF))
        _listParam.Add(New Datos.DParametro("@cliente", _numiCliente))
        _listParam.Add(New Datos.DParametro("@yduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_VentasEstadisticos", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnObtenerProductosVentasEstadistico(_fechaI As String, _fechaF As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@fechaI", _fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", _fechaF))

        _listParam.Add(New Datos.DParametro("@yduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_VentasEstadisticos", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnObtenerVentasProductosEstadistico(_fechaI As String, _fechaF As String, _numiProducto As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@fechaI", _fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", _fechaF))
        _listParam.Add(New Datos.DParametro("@producto", _numiProducto))
        _listParam.Add(New Datos.DParametro("@yduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_VentasEstadisticos", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnObtenerZonasVentasEstadistico(_fechaI As String, _fechaF As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@fechaI", _fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", _fechaF))

        _listParam.Add(New Datos.DParametro("@yduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_VentasEstadisticos", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnObtenerVentasZonasEstadistico(_fechaI As String, _fechaF As String, _numiZona As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@fechaI", _fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", _fechaF))
        _listParam.Add(New Datos.DParametro("@zona", _numiZona))
        _listParam.Add(New Datos.DParametro("@yduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_VentasEstadisticos", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnObtenerCOBRANZASVentasEstadistico(_fechaI As String, _fechaF As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@fechaI", _fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", _fechaF))

        _listParam.Add(New Datos.DParametro("@yduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_VentasEstadisticos", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnObtenerVentasCOBRANZASEstadistico(_fechaI As String, _fechaF As String, _numiVendedor As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@fechaI", _fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", _fechaF))
        _listParam.Add(New Datos.DParametro("@vendedor", _numiVendedor))
        _listParam.Add(New Datos.DParametro("@yduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_VentasEstadisticos", _listParam)

        Return _Tabla
    End Function
#End Region

#Region "VENTAS GRAFICAS"
    Public Shared Function L_prVentasGraficaVendedorMes(fechaI As String, fechaF As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@fechaI", fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", fechaF))
        _listParam.Add(New Datos.DParametro("@yduact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_VentasGraficas", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prVentasGraficaVendedorAlmacen(fechaI As String, fechaF As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@fechaI", fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", fechaF))
        _listParam.Add(New Datos.DParametro("@yduact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_VentasGraficas", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prVentasGraficaVendedorRendimiento(fechaI As String, fechaF As String, dt As DataTable) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@fechaI", fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", fechaF))
        _listParam.Add(New Datos.DParametro("@yduact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@cliente", "", dt))
        _Tabla = D_ProcedimientoConParam("sp_Mam_VentasGraficas", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prReporteCreditoClienteTodosCuentas(fechaI As String, fechaF As String, _numiCliente As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@fechaI", fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", fechaF))
        _listParam.Add(New Datos.DParametro("@yduact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@cliente", _numiCliente))
        _Tabla = D_ProcedimientoConParam("sp_Mam_VentasCredito", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prReporteCreditoGeneralRes(fechaI As String, fechaF As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 111))
        _listParam.Add(New Datos.DParametro("@fechaI", fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", fechaF))
        _listParam.Add(New Datos.DParametro("@yduact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_VentasCredito", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prReporteCreditoClienteRes(fechaI As String, fechaF As String, codcli As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 112))
        _listParam.Add(New Datos.DParametro("@fechaI", fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", fechaF))
        _listParam.Add(New Datos.DParametro("@cliente", codcli))
        _listParam.Add(New Datos.DParametro("@yduact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_VentasCredito", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prReporteCreditoClienteUnaCuentas(_numiCredito As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@yduact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@codCredito", _numiCredito))
        _Tabla = D_ProcedimientoConParam("sp_Mam_VentasCredito", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prVentasGraficaListarVendedores() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@yduact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_VentasGraficas", _listParam)

        Return _Tabla
    End Function
#End Region

#Region "Pago"

    Public Shared Function L_fnPagoGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TO003", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnPagoGrabar(ByRef numi As String, rec As String, fdoc As String, cli As String,
                                          mon As String, nota As String, tprod As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@rec", rec))
        _listParam.Add(New Datos.DParametro("@fdoc", fdoc))
        _listParam.Add(New Datos.DParametro("@cli", cli))
        _listParam.Add(New Datos.DParametro("@mon", mon))
        _listParam.Add(New Datos.DParametro("@nota", nota))
        _listParam.Add(New Datos.DParametro("@tprod", tprod))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TO003", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnPagoModificar(ByRef numi As String, rec As String, fdoc As String, cli As String,
                                             mon As String, nota As String, tprod As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@rec", rec))
        _listParam.Add(New Datos.DParametro("@fdoc", fdoc))
        _listParam.Add(New Datos.DParametro("@cli", cli))
        _listParam.Add(New Datos.DParametro("@mon", mon))
        _listParam.Add(New Datos.DParametro("@nota", nota))
        _listParam.Add(New Datos.DParametro("@tprod", tprod))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TO003", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnPagoBorrar(numi As String) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TO003", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "Saldo Credito Cliente"

    Shared Function L_fnSaldoCreditoCliente() As DataTable
        Dim Tabla As DataTable
        Tabla = D_Datos_Tabla("*", "vr_go_saldoCreditoCliente", "1=1")
        Return Tabla
    End Function

#End Region

#Region "Categoria de productos clientes"
    Public Function L_prTraerCategorias() As DataTable
        Dim _Tabla As DataTable
        Dim _ListParam As New List(Of Datos.DParametro)

        _ListParam.Add(New Datos.DParametro("@tipo", 1))
        _ListParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_da_TC0042", _ListParam)

        Return _Tabla
    End Function
#End Region


#Region "Prestamo de equipo vs ventas"
    Public Shared Function L_fnPrestamoEquipoVsVenta(codProducto As String, desde As String, hasta As String, codCliente As String, nomCliente As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@cprod", codProducto))
        _listParam.Add(New Datos.DParametro("@fini", desde))
        _listParam.Add(New Datos.DParametro("@ffin", hasta))
        _listParam.Add(New Datos.DParametro("@codigo", codCliente))
        _listParam.Add(New Datos.DParametro("@cliente", nomCliente))

        _Tabla = D_ProcedimientoConParam("sp_go_Reportes", _listParam)
        Return _Tabla
    End Function

    Public Shared Function L_fnVentaClientePorMes(bandera As String, anho As String, mes As String, codCliente As String, nomCliente As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@ban", bandera))
        _listParam.Add(New Datos.DParametro("@anho", anho))
        _listParam.Add(New Datos.DParametro("@mes", mes))
        _listParam.Add(New Datos.DParametro("@codigo", codCliente))
        _listParam.Add(New Datos.DParametro("@cliente", nomCliente))

        _Tabla = D_ProcedimientoConParam("sp_go_Reportes", _listParam)
        Return _Tabla
    End Function
#End Region

#Region "Mesas"
    Public Shared Sub L_Mesas_Grabar1(ByRef _numi As String, _user As String, _pass As String, _rol As String, _estado As String, _cantDias As String, _tamFuente As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("CM001", "manumi", "manumi=manumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"

        Dim Sql As String
        Sql = _numi + ",'" + _user + "'," + _rol + ",'" + _pass + "','" + _estado + "'," + _cantDias + "," + _tamFuente + "," + _Actualizacion
        _Err = D_Insertar_Datos("CM001", Sql)
    End Sub
    Public Shared Function L_Mesas_Grabar(ByRef numi As String, mesa As String, codrepartidor As String,
                                          est As String, detalle As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        '@codigo, @mesa,@codrepart, @est, @fact, @hact, @uact
        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@mesa", mesa))
        _listParam.Add(New Datos.DParametro("@codrepart", codrepartidor))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@CM0011", "", detalle))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_go_CM001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_Mesas_Modificar(ByRef numi As String, mesa As String, codrepartidor As String,
                                          est As String, detalle As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        '@codigo, @mesa,@codrepart, @est, @fact, @hact, @uact
        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@mesa", mesa))
        _listParam.Add(New Datos.DParametro("@codrepart", codrepartidor))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@CM0011", "", detalle))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_go_CM001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_Mesas_Eliminar(numi As String, ByRef mensaje As String) As Boolean
        Dim _resultado As Boolean
        If L_fnbValidarEliminacion(numi, "CM001", "manumi", mensaje) = True Then

            Dim _Tabla As DataTable
            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", 3))
            _listParam.Add(New Datos.DParametro("@numi", numi))
            _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
            _Tabla = D_ProcedimientoConParam("sp_go_CM001", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If
        Return _resultado
    End Function
    Public Shared Function L_fnMostrarTodos() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_go_CM001", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnDetalle(_numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@numi", _numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_go_CM001", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnVendedoresPorMesa(_mesa As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@mesa", _mesa))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_go_CM001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnNotaVenta(_FechaI As String, _Vendedor As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@fecha", _FechaI))
        _listParam.Add(New Datos.DParametro("@vendedor", _Vendedor))
        _Tabla = D_ProcedimientoConParam("sp_go_NV001", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnReporteProductosMesas(mesa As Integer, vend1 As Integer, vend2 As Integer, vend3 As Integer, vend4 As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@mesa", mesa))
        _listParam.Add(New Datos.DParametro("@vend1", vend1))
        _listParam.Add(New Datos.DParametro("@vend2", vend2))
        _listParam.Add(New Datos.DParametro("@vend3", vend3))
        _listParam.Add(New Datos.DParametro("@vend4", vend4))
        _Tabla = D_ProcedimientoConParam("sp_go_CM001", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnVerificarMesa(_numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@mesa", _numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_go_CM001", _listParam)

        Return _Tabla
    End Function
#End Region


#Region "TS002 Dosificacion"

    Public Shared Function L_fnEliminarDosificacion(numi As String, ByRef mensaje As String) As Boolean
        Dim _resultado As Boolean
        If L_fnbValidarEliminacion(numi, "TS002", "sbnumi", mensaje) = True Then
            Dim _Tabla As DataTable
            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@numi", numi))
            _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_go_TS002", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If
        Return _resultado
    End Function



    Public Shared Function L_fnGrabarDosificacion(ByRef numi As String, cia As Integer, alm As String, sfc As String,
                                                  autoriz As String, nfac As Double, key As String, fdel As String,
                                                  fal As String, nota As String, nota2 As String, est As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@cia", cia))
        _listParam.Add(New Datos.DParametro("@alm", alm))
        _listParam.Add(New Datos.DParametro("@sfc", sfc))
        _listParam.Add(New Datos.DParametro("@autoriz", autoriz))
        _listParam.Add(New Datos.DParametro("@nfac", nfac))
        _listParam.Add(New Datos.DParametro("@key", key))
        _listParam.Add(New Datos.DParametro("@fdel", fdel))
        _listParam.Add(New Datos.DParametro("@fal", fal))
        _listParam.Add(New Datos.DParametro("@nota", nota))
        _listParam.Add(New Datos.DParametro("@nota2", nota2))
        _listParam.Add(New Datos.DParametro("@est", est))

        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_go_TS002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnModificarDosificacion(ByRef numi As String, cia As Integer, alm As String, sfc As String,
                                                     autoriz As String, nfac As Double, key As String, fdel As String,
                                                     fal As String, nota As String, nota2 As String, est As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@cia", cia))
        _listParam.Add(New Datos.DParametro("@alm", alm))
        _listParam.Add(New Datos.DParametro("@sfc", sfc))
        _listParam.Add(New Datos.DParametro("@autoriz", autoriz))
        _listParam.Add(New Datos.DParametro("@nfac", nfac))
        _listParam.Add(New Datos.DParametro("@key", key))
        _listParam.Add(New Datos.DParametro("@fdel", fdel))
        _listParam.Add(New Datos.DParametro("@fal", fal))
        _listParam.Add(New Datos.DParametro("@nota", nota))
        _listParam.Add(New Datos.DParametro("@nota2", nota2))
        _listParam.Add(New Datos.DParametro("@est", est))

        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_go_TS002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnGeneralDosificacion() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_go_TS002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnListarCompaniaDosificacion() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_go_TS002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnListarAlmacenDosificacion() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_go_TS002", _listParam)

        Return _Tabla
    End Function

#End Region

#Region "Facturar"

    Public Shared Sub L_Grabar_Factura(_Numi As String, _Fecha As String, _Nfac As String, _NAutoriz As String, _Est As String,
                                       _NitCli As String, _CodCli As String, _DesCli1 As String, _DesCli2 As String,
                                       _A As String, _B As String, _C As String, _D As String, _E As String, _F As String,
                                       _G As String, _H As String, _CodCon As String, _FecLim As String,
                                       _Imgqr As String, _Alm As String, _Numi2 As String)
        Dim Sql As String
        Try
            Sql = "" + _Numi + ", " _
                + "'" + _Fecha + "', " _
                + "" + _Nfac + ", " _
                + "" + _NAutoriz + ", " _
                + "" + _Est + ", " _
                + "'" + _NitCli + "', " _
                + "" + _CodCli + ", " _
                + "'" + _DesCli1 + "', " _
                + "'" + _DesCli2 + "', " _
                + "" + _A + ", " _
                + "" + _B + ", " _
                + "" + _C + ", " _
                + "" + _D + ", " _
                + "" + _E + ", " _
                + "" + _F + ", " _
                + "" + _G + ", " _
                + "" + _H + ", " _
                + "'" + _CodCon + "', " _
                + "'" + _FecLim + "', " _
                + "" + _Imgqr + ", " _
                + "" + _Alm + ", " _
                + "" + _Numi2 + ""

            D_Insertar_Datos("TFV001", Sql)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Shared Sub L_Modificar_Factura(Where As String, Optional _Fecha As String = "",
                                          Optional _Nfact As String = "", Optional _NAutoriz As String = "",
                                          Optional _Est As String = "", Optional _NitCli As String = "",
                                          Optional _CodCli As String = "", Optional _DesCli1 As String = "",
                                          Optional _DesCli2 As String = "", Optional _A As String = "",
                                          Optional _B As String = "", Optional _C As String = "",
                                          Optional _D As String = "", Optional _E As String = "",
                                          Optional _F As String = "", Optional _G As String = "",
                                          Optional _H As String = "", Optional _CodCon As String = "",
                                          Optional _FecLim As String = "", Optional _Imgqr As String = "",
                                          Optional _Alm As String = "", Optional _Numi2 As String = "")
        Dim Sql As String
        Try
            Sql = IIf(_Fecha.Equals(""), "", "fvafec = '" + _Fecha + "', ") +
              IIf(_Nfact.Equals(""), "", "fvanfac = " + _Nfact + ", ") +
              IIf(_NAutoriz.Equals(""), "", "fvaautoriz = " + _NAutoriz + ", ") +
              IIf(_Est.Equals(""), "", "fvaest = " + _Est) +
              IIf(_NitCli.Equals(""), "", "fvanitcli = '" + _NitCli + "', ") +
              IIf(_CodCli.Equals(""), "", "fvacodcli = " + _CodCli + ", ") +
              IIf(_DesCli1.Equals(""), "", "fvadescli1 = '" + _DesCli1 + "', ") +
              IIf(_DesCli2.Equals(""), "", "fvadescli2 = '" + _DesCli2 + "', ") +
              IIf(_A.Equals(""), "", "fvastot = " + _A + ", ") +
              IIf(_B.Equals(""), "", "fvaimpsi = " + _B + ", ") +
              IIf(_C.Equals(""), "", "fvaimpeo = " + _C + ", ") +
              IIf(_D.Equals(""), "", "fvaimptc = " + _D + ", ") +
              IIf(_E.Equals(""), "", "fvasubtotal = " + _E + ", ") +
              IIf(_F.Equals(""), "", "fvadesc = " + _F + ", ") +
              IIf(_G.Equals(""), "", "fvatotal = " + _G + ", ") +
              IIf(_H.Equals(""), "", "fvadebfis = " + _H + ", ") +
              IIf(_CodCon.Equals(""), "", "fvaccont = '" + _CodCon + "', ") +
              IIf(_FecLim.Equals(""), "", "fvaflim = '" + _FecLim + "', ") +
              IIf(_Imgqr.Equals(""), "", "fvaimgqr = '" + _Imgqr + "', ") +
              IIf(_Alm.Equals(""), "", "fvaalm = " + _Alm + ", ") +
              IIf(_Numi2.Equals(""), "", "fvanumi2 = " + _Numi2 + ", ")
            Sql = Sql.Trim
            If (Sql.Substring(Sql.Length - 1, 1).Equals(",")) Then
                Sql = Sql.Substring(0, Sql.Length - 1)
            End If

            D_Modificar_Datos("TFV001", Sql, Where)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Shared Sub L_Grabar_Factura_Detalle(_Numi As String, _CodProd As String, _DescProd As String, _Cant As String, _Precio As String, _Numi2 As String)
        Dim Sql As String
        Try
            Sql = _Numi + ", '" + _CodProd + "', '" + _DescProd + "', " + _Cant + ", " + _Precio + ", " + _Numi2

            D_Insertar_Datos("TFV0011", Sql)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Shared Function L_Reporte_Factura(_Numi As String, _Numi2 As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        _Where = " fvanumi = " + _Numi + " and fvanumi2 = " + _Numi2

        _Tabla = D_Datos_Tabla("*", "VR_GO_Factura", _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_Reporte_Factura_Cia(_Cia As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        _Where = " scnumi = " + _Cia

        _Tabla = D_Datos_Tabla("*", "TS003", _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_ObtenerRutaImpresora(_NroImp As String, Optional tImp As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If (Not _NroImp.Trim.Equals("")) Then
            _Where = " cbnumi = " + _NroImp + " and cbest = 1 order by cbnumi"
        Else
            _Where = " cbtimp = " + tImp + " and cbest = 1 order by cbnumi"
        End If
        _Tabla = D_Datos_Tabla("*", "TC002", _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_fnGetIVA() As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        _Where = "1 = 1"
        _Tabla = D_Datos_Tabla("scdebfis", "TS003", _Where)
        Return _Tabla
    End Function

    Public Shared Function L_fnGetICE() As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        _Where = "1 = 1"
        _Tabla = D_Datos_Tabla("scice", "TS003", _Where)
        Return _Tabla
    End Function

    Public Shared Sub L_Grabar_Nit(_Nit As String, _Nom1 As String, _Nom2 As String)
        Dim _Err As Boolean
        Dim _Nom01, _Nom02 As String
        Dim Sql As String
        _Nom01 = ""
        _Nom02 = ""
        L_Validar_Nit(_Nit, _Nom01, _Nom02)

        If _Nom01 = "" Then
            Sql = _Nit + ", '" + _Nom1 + "', '" + _Nom2 + "'"
            _Err = D_Insertar_Datos("TS001", Sql)
        Else
            If (_Nom1 <> _Nom01) Or (_Nom2 <> _Nom02) Then
                Sql = "sanom1 = '" + _Nom1 + "' " +
                      IIf(_Nom02.ToString.Trim.Equals(""), "", ", sanom2 = '" + _Nom2 + "', ")
                _Err = D_Modificar_Datos("TS001", Sql, "sanit = " + _Nit)
            End If
        End If

    End Sub

    Public Shared Sub L_Validar_Nit(_Nit As String, ByRef _Nom1 As String, ByRef _Nom2 As String)
        Dim _Tabla As DataTable

        _Tabla = D_Datos_Tabla("*", "TS001", "sanit = '" + _Nit + "'")

        If _Tabla.Rows.Count > 0 Then
            _Nom1 = _Tabla.Rows(0).Item(2)
            _Nom2 = IIf(_Tabla.Rows(0).Item(3).ToString.Trim.Equals(""), "", _Tabla.Rows(0).Item(3))
        End If
    End Sub

    Public Shared Function L_Eliminar_Nit(_Nit As String) As Boolean
        Dim res As Boolean = False
        Try
            res = D_Eliminar_Datos("TS001", "sanit = " + _Nit)
        Catch ex As Exception
            res = False
        End Try
        Return res
    End Function

    Public Shared Function L_Dosificacion(_cia As String, _alm As String, _fecha As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        _fecha = Now.Date.ToString("yyyy/MM/dd")
        _Where = "yecia = " + _cia + " AND yealm = " + _alm + " AND yefdel <= '" + _fecha + "' AND yefal >= '" + _fecha + "' AND yeap = 1"

        _Tabla = D_Datos_Tabla("*", "TS002", _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_Actualiza_Dosificacion(_Numi As String, _NumFac As String, _Numi2 As String)
        Dim _Err As Boolean
        Dim Sql, _where As String
        Sql = "yenunf = " + _NumFac
        _where = "yenumi = " + _Numi

        _Err = D_Modificar_Datos("TS002", Sql, _where)
    End Sub

    Public Shared Function L_fnObtenerMaxIdTabla(tabla As String, campo As String, where As String) As Long
        Dim Dt As DataTable = New DataTable
        Dt = D_Maximo(tabla, campo, where)

        If (Dt.Rows.Count > 0) Then
            If (Dt.Rows(0).Item(0).ToString.Equals("")) Then
                Return 0
            Else
                Return CLng(Dt.Rows(0).Item(0).ToString)
            End If
        Else
            Return 0
        End If
    End Function



    Public Shared Function L_fnObtenerDatoTabla(tabla As String, campo As String, where As String) As String
        Dim Dt As DataTable = D_Datos_Tabla(campo, tabla, where)
        If (Dt.Rows.Count > 0) Then
            Return Dt.Rows(0).Item(campo).ToString
        Else
            Return ""
        End If
    End Function

    Public Shared Function L_fnEliminarDatos(Tabla As String, Where As String) As Boolean
        Return D_Eliminar_Datos(Tabla, Where)
    End Function

#End Region
End Class
