
Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports System.Drawing
Imports DevComponents.DotNetBar.Controls
Imports System.Threading
Imports System.Drawing.Text
Imports System.Reflection
Imports System.Runtime.InteropServices

Public Class F0G_VentaChoferConciliacion

#Region "Variables Globales"
    Dim _codChofer As Integer = 0
    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

    Dim _IdConciliacion As Integer = 0
    Dim _numiConciliacio As Integer = 0 'Aqui se guardar el numi de la conciliacion

    Private boNuevo As Boolean = False '[addclivmovil]
    Private inCantVmovil As Integer = 0

    Private boShow As Boolean = False
    Private boAdd As Boolean = False
    Private boModif As Boolean = False
    Private boDel As Boolean = False

    Private Principal As DataTable

    Private fnTitulo As Font = New Font("Arial", gi_userFuente + 1, FontStyle.Bold)
    Private fnTituloReducido As Font = New Font("Arial", gi_userFuente - 2, FontStyle.Bold)
    Private fnDetalle As Font = New Font("Arial", gi_userFuente)
#End Region

#Region "Metodos Privados"
    Private Sub _IniciarTodo()
        MSuperTabControlPrincipal.SelectedTabIndex = 0

        If (Not gb_ConexionAbierta) Then
            L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        End If

        P_prInicializar()
    End Sub

    Private Sub P_prInicializar()
        Me.WindowState = FormWindowState.Maximized
        Me.Text = "N O T A S    D E   C H O F E R E S"

        '----Poner iconos al tab-----
        'Dim blah As New Bitmap(New Bitmap(My.Resources.compra), 20, 20)
        'Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        'Me.Icon = ico

        '----Poner foco-----
        tbConciliacion.Focus()

        '----Modos-----
        lbSubTotalContado.Visible = (gi_vdes = 1)
        tbSubTotalContado.Visible = (gi_vdes = 1)

        lbTotalDescuento.Visible = (gi_vdes = 1)
        tbTotalDescuento.Visible = (gi_vdes = 1)

        lbTotalContado.Visible = ((gi_vcre = 1) Or (gi_vdes = 1))
        tbTotalContado.Visible = ((gi_vcre = 1) Or (gi_vdes = 1))

        lbTotalCredito.Visible = (gi_vcre = 1)
        tbTotalCredito.Visible = (gi_vcre = 1)

        pnTotales.Visible = ((gi_vcre = 1) Or (gi_vdes = 1))

        '----Funciones-----
        _prCargarVenta()
        _prInhabiliitar()
        _prAsignarPermisos()

        '----Mostrar registro-----
        If (grmovimiento.RowCount > 0) Then
            _prMostrarRegistro(0)
        End If
    End Sub

    Private Sub _prAsignarPermisos()
        Dim dtRolUsu() As DataRow = L_prRolDetalleGeneral(gi_userRol).Select("yaprog='" + _nameButton + "'")

        If (dtRolUsu.Count = 1) Then
            boShow = dtRolUsu(0).Item("ycshow")
            boAdd = dtRolUsu(0).Item("ycadd")
            boModif = dtRolUsu(0).Item("ycmod")
            boDel = dtRolUsu(0).Item("ycdel")
        End If

        If boAdd = False Then
            MBtNuevo.Visible = False
        End If
        If boModif = False Then
            MBtModificar.Visible = False
        End If
        If boDel = False Then
            MBtEliminar.Visible = False
        End If
    End Sub

    Private Sub _prInhabiliitar()
        tbCodigo.ReadOnly = True
        tbChofer.ReadOnly = True
        swestado.IsReadOnly = True
        tbConciliacion.ReadOnly = True
        tbFecha.IsInputReadOnly = True

        tbSubTotalContado.IsInputReadOnly = True
        tbTotalDescuento.IsInputReadOnly = True
        tbTotalContado.IsInputReadOnly = True
        tbTotalCredito.IsInputReadOnly = True

        ''''''''''
        MBtModificar.Enabled = True
        MBtGrabar.Enabled = False
        MBtNuevo.Enabled = True
        MBtEliminar.Enabled = True
        grmovimiento.Enabled = False
        dgjDetalle.RootTable.Columns("img").Visible = False
        dgjDetalle.RootTable.Columns("imgedit").Visible = False '[colimgedit]
        If (GPanelProductos.Visible = True) Then
            _DesHabilitarClientes()
        End If
        grmovimiento.Enabled = True
        MPanelToolBarNavegacion.Enabled = True
        btBuscarConciliacion.Enabled = False
    End Sub

    Private Sub _prhabilitar()
        tbCodigo.ReadOnly = False
        tbChofer.ReadOnly = False
        swestado.IsReadOnly = False
        tbFecha.IsInputReadOnly = False
        grmovimiento.Enabled = True
        ''  tbCliente.ReadOnly = False  por que solo podra seleccionar Cliente
        ''  tbVendedor.ReadOnly = False

        MBtGrabar.Enabled = True
        btBuscarConciliacion.Enabled = True
    End Sub
    Public Sub _prFiltrar()
        'cargo el buscador
        Dim _Mpos As Integer
        _prCargarVenta()
        If grmovimiento.RowCount > 0 Then
            _Mpos = 0
            grmovimiento.Row = _Mpos
        Else
            _Limpiar()
            MLbPaginacion.Text = "0/0"
        End If
    End Sub

    Private Sub _Limpiar()
        tbCodigo.Clear()
        tbChofer.Clear()
        tbConciliacion.Clear()

        tbSubTotalContado.Value = 0
        tbTotalDescuento.Value = 0
        tbTotalContado.Value = 0
        tbTotalCredito.Value = 0

        _codChofer = 0
        tbFecha.Value = Now.Date
        _prCargarDetalleVenta(-1)
        _prCargarDetalleConciliacion("-1")
        _IdConciliacion = 0

        With dgjDetalle.RootTable.Columns("img")
            .Width = 70
            .Caption = "Eliminar".ToUpper
            .CellStyle.ImageHorizontalAlignment = ImageHorizontalAlignment.Center
            .Visible = True
        End With
        _prAddDetalleVenta()
        If (GPanelProductos.Visible = True) Then
            GPanelProductos.Visible = False
            MPnInferior.Visible = True
        End If
        tbConciliacion.Focus()
    End Sub
    Public Sub _prMostrarRegistro(_N As Integer) '[mostrar]
        'a.ohnumi ,a.ohfec ,a.ohcon ,a.ohest,c.cbdesc as chofer ,a.ohfact,a.ohhact ,a.ohuact 
        With grmovimiento
            tbCodigo.Text = .GetValue("ohnumi")
            tbFecha.Value = .GetValue("ohfec")
            tbChofer.Text = .GetValue("chofer")
            swestado.Value = .GetValue("ohest")
            tbConciliacion.Text = .GetValue("ohcon")
            MLbFecha.Text = CType(.GetValue("ohfact"), Date).ToString("dd/MM/yyyy")
            MLbHora.Text = .GetValue("ohhact").ToString
            MLbUsuario.Text = .GetValue("ohuact").ToString
        End With
        _prCargarDetalleConciliacion(tbCodigo.Text)
        _prCargarDetalleVenta(tbCodigo.Text)
        MLbPaginacion.Text = Str(grmovimiento.Row + 1) + "/" + grmovimiento.RowCount.ToString

        If (Not boModif And boAdd) Then
            If (Now.Date = Me.tbFecha.Value) Then
                MBtModificar.Visible = True
            Else
                MBtModificar.Visible = False
            End If
        End If
    End Sub

    Private Sub _prCargarDetalleConciliacion(_numi As String) '[agconciliacion]
        Dim dt As New DataTable
        dt = L_prNotaDetalleConciliacion(_numi)
        dgjTotal.DataSource = dt
        dgjTotal.RetrieveStructure()
        dgjTotal.AlternatingColors = True
        With dgjTotal.RootTable.Columns("oinumi")
            .Width = 100
            .Caption = "CODIGO"
            .Visible = False
        End With
        With dgjTotal.RootTable.Columns("oinumi2")
            .Width = 100
            .Visible = False
        End With
        With dgjTotal.RootTable.Columns("estado")
            .Width = 100
            .Visible = False
        End With
        'a.oinumi ,a.oinumi2 ,a.oicprod ,b.cadesc as producto,a.oicant ,1 as estado
        With dgjTotal.RootTable.Columns("oicprod")
            .Width = 120
            .Caption = "COD PRODUCTO"
            .TextAlignment = TextAlignment.Far
            .Visible = True
        End With
        With dgjTotal.RootTable.Columns("producto")
            .Width = 250
            .Caption = "PRODUCTO"
            .Visible = True
        End With
        With dgjTotal.RootTable.Columns("descripcion")
            .Width = 150
            .Caption = "DESC CORTA"
            .Visible = False
        End With
        With dgjTotal.RootTable.Columns("vmovil")
            .Width = 100
            .Caption = "MOVIL"
            .TextAlignment = TextAlignment.Far
            .Visible = True
            .CellStyle.BackColor = Color.CadetBlue
            .FormatString = "0.00"
        End With
        With dgjTotal.RootTable.Columns("subtotal")
            .Width = 100
            .Caption = "SUBTOTAL"
            .TextAlignment = TextAlignment.Far
            .Visible = True
            .FormatString = "0.00"
        End With
        With dgjTotal.RootTable.Columns("oicant")
            .Width = 100
            .Caption = "CANTIDAD"
            .TextAlignment = TextAlignment.Far
            .Visible = True
            .FormatString = "0.00"
        End With

        'a.icid ,a.icibid ,a.iccprod ,b.cadesc as producto,a.iccant ,Cast(null as image ) as img,1 as estado
        With dgjTotal
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With
        If (tbCodigo.Text = String.Empty And _fnAccesible()) Then
            CType(dgjTotal.DataSource, DataTable).Rows.Clear()
            _prCargarProductosDetalleConciliacion(_numi)
        End If
    End Sub

    Public Sub _prCargarProductosDetalleConciliacion(_conciliacion As String)
        Dim dt As DataTable = L_prNotaObtenerProductosConciliacion(_conciliacion)
        'a.oinumi ,a.oinumi2 ,a.oicprod ,b.cadesc as producto,a.oicant ,1 as estado

        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            CType(dgjTotal.DataSource, DataTable).Rows.Add(0, 0, dt.Rows(i).Item("oicprod"), dt.Rows(i).Item("prod"),
                                                          dt.Rows(i).Item("producto"), dt.Rows(i).Item("vmovil"),
                                                          dt.Rows(i).Item("subtotal"), dt.Rows(i).Item("cantidad"), 0)
            If (i <= dt.Rows.Count - 1) Then
                tbChofer.Text = dt.Rows(i).Item("chofer")
            End If
        Next
        If (dt.Rows.Count <= 0) Then
            tbChofer.Text = ""
        End If

        '[addclivmovil]
        Dim dtVmovil As DataTable
        dtVmovil = L_fnObtenerTabla("idnumi", "TM0013", "idtm1id=" + _conciliacion)
        If (dtVmovil.Rows.Count > 0) Then
            inCantVmovil = dtVmovil.Rows.Count
            Dim tablaP As New DataTable
            tablaP = L_prObtenerClienteEntregaMovil(_conciliacion)
            Dim columnas As New DataTable
            columnas = L_prNotaObtenerProductosConciliacionMovil(_conciliacion)
            _prArmarDetalle(tablaP, columnas, _conciliacion)
        Else
            _prCargarDetalleVenta("-1")
        End If
        _prAddDetalleVenta()
    End Sub

    Private Sub _prArmarDetalle(tablaP As DataTable, columnas As DataTable, _nroCon As String)
        Principal = New DataTable

        Dim FirstImageColumn As DataColumn = New DataColumn() '[colimgedit]
        FirstImageColumn.DataType = GetType(Bitmap)
        FirstImageColumn.ColumnName = "imgedit"
        Principal.Columns.Add(FirstImageColumn)

        Principal.Columns.Add("ojnumi")
        Principal.Columns.Add("ojnumi2")
        Principal.Columns.Add("ojccli")
        Principal.Columns.Add("nombre")

        For Each fila As DataRow In columnas.Rows
            Dim col1 As DataColumn = New DataColumn()
            col1.DataType = GetType(Double)
            col1.ColumnName = fila.Item("oicprod").ToString.Trim
            Principal.Columns.Add(col1)

            Dim precio As DataColumn = New DataColumn()
            precio.DataType = GetType(Double)
            precio.ColumnName = "precio" + fila.Item("oicprod").ToString.Trim
            Principal.Columns.Add(precio)

            Dim numi As DataColumn = New DataColumn()
            numi.DataType = GetType(Integer)
            numi.ColumnName = "numi" + fila.Item("oicprod").ToString.Trim
            Principal.Columns.Add(numi)

            Dim estado As DataColumn = New DataColumn()
            estado.DataType = GetType(Integer)
            estado.ColumnName = "estado" + fila.Item("oicprod").ToString.Trim
            Principal.Columns.Add(estado)
        Next

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim precioContado As DataColumn = New DataColumn()
        precioContado.DataType = GetType(Double)
        precioContado.ColumnName = "ojprecon"
        Principal.Columns.Add(precioContado)

        Dim precioCredito As DataColumn = New DataColumn()
        precioCredito.DataType = GetType(Double)
        precioCredito.ColumnName = "ojprecre"
        Principal.Columns.Add(precioCredito)

        Dim precioDescuento As DataColumn = New DataColumn()
        precioDescuento.DataType = GetType(Double)
        precioDescuento.ColumnName = "ojdesc"
        Principal.Columns.Add(precioDescuento)

        Dim nota As DataColumn = New DataColumn()
        nota.DataType = GetType(String)
        nota.ColumnName = "ojnota"
        Principal.Columns.Add(nota)

        Dim Observacion As DataColumn = New DataColumn()
        Observacion.DataType = GetType(String)
        Observacion.ColumnName = "ojobs"
        Principal.Columns.Add(Observacion)

        Dim colEstado As DataColumn = New DataColumn()
        colEstado.DataType = GetType(Integer)
        colEstado.ColumnName = "estado"
        Principal.Columns.Add(colEstado)

        Dim SecondImageColumn As DataColumn = New DataColumn()
        SecondImageColumn.DataType = GetType(Bitmap)
        SecondImageColumn.ColumnName = "img"
        Principal.Columns.Add(SecondImageColumn)

        'Cargo los datos de Clientes con cantidad de producto insertado
        For i As Integer = 0 To tablaP.Rows.Count - 1 Step 1
            Principal.Rows.Add(Principal.NewRow)
            Principal.Rows(i).Item("ojnumi") = tablaP.Rows(i).Item("ojnumi")
            Principal.Rows(i).Item("ojnumi2") = tablaP.Rows(i).Item("ojnumi2")
            Principal.Rows(i).Item("ojccli") = tablaP.Rows(i).Item("ojccli")
            Principal.Rows(i).Item("nombre") = tablaP.Rows(i).Item("nombre")
            Principal.Rows(i).Item("ojnota") = tablaP.Rows(i).Item("ojnota")
            Principal.Rows(i).Item("ojobs") = tablaP.Rows(i).Item("ojobs")
            Principal.Rows(i).Item("ojprecon") = tablaP.Rows(i).Item("ojprecon")
            Principal.Rows(i).Item("ojprecre") = tablaP.Rows(i).Item("ojprecre")
            Principal.Rows(i).Item("ojdesc") = tablaP.Rows(i).Item("ojdesc")
            Principal.Rows(i).Item("estado") = tablaP.Rows(i).Item("estado")
        Next


        For i As Integer = 0 To Principal.Rows.Count - 1 Step 1
            'a.oknumi ,a.oknumi2 ,a.okcprod ,a.okccant ,1 as estado
            Dim dtprod As New DataTable
            dtprod = L_prNotaDetalleCLienteProdCantPrec(_nroCon, Principal.Rows(i).Item("ojccli"))
            Dim list As List(Of Integer) = New List(Of Integer)
            For j As Integer = 0 To dtprod.Rows.Count - 1 Step 1
                Dim numi As Integer = IIf(IsDBNull(dtprod.Rows(j).Item("oknumi")), 0, dtprod.Rows(j).Item("oknumi"))

                Principal.Rows(i).Item("numi" + dtprod.Rows(j).Item("okcprod").ToString.Trim) = numi

                Principal.Rows(i).Item("estado" + dtprod.Rows(j).Item("okcprod").ToString.Trim) = dtprod.Rows(j).Item("estado")
                Principal.Rows(i).Item("precio" + dtprod.Rows(j).Item("okcprod").ToString.Trim) = dtprod.Rows(j).Item("okprecio")
                Principal.Rows(i).Item(dtprod.Rows(j).Item("okcprod").ToString.Trim) = dtprod.Rows(j).Item("okccant")
                list.Add(dtprod.Rows(j).Item("okcprod"))
            Next
            Dim producto As DataTable = CType(dgjTotal.DataSource, DataTable)
            For k As Integer = 0 To producto.Rows.Count - 1 Step 1
                'a.oinumi ,a.oinumi2 ,a.oicprod ,b.cadesc as producto,b.cadesc2 as descripcion,a.oicant ,1 as estad
                Dim cprod As Integer = producto.Rows(k).Item("oicprod")
                If (Not list.Contains(cprod)) Then
                    Dim numicliente As Integer = Principal.Rows(i).Item("ojccli")
                    Dim dtPrecio As New DataTable
                    dtPrecio = L_prNotaObtenerPrecioClienteProducto(numicliente, cprod)
                    If (dtPrecio.Rows.Count > 0) Then
                        Dim columna As String = "precio" + Str(cprod).Trim
                        Principal.Rows(i).Item(columna) = dtPrecio.Rows(0).Item("chprecio")
                    End If
                End If
            Next
        Next

        P_prArmarGrillaDetalle(Principal, columnas)

        _prCargarIconELiminar()

        For i As Integer = 0 To dgjDetalle.RowCount - 1
            _prCalcularPrecioTotal(i)
            dgjDetalle.MoveNext()
        Next
    End Sub

    Private Sub _prCargarDetalleVenta(_numi As String)
        Principal = New DataTable
        'Dim Principal As DataTable = New DataTable
        Dim tablaP As New DataTable
        tablaP = L_prNotaDetalleCLiente(_numi)
        'a.ojnumi, a.ojnumi2, a.ojccli, b.ccdesc as nombre, a.ojnota, a.ojobs, a.ojprecon, a.ojprecre, 1 as estado

        Dim FirstImageColumn As DataColumn = New DataColumn() '[colimgedit]
        FirstImageColumn.DataType = GetType(Bitmap)
        FirstImageColumn.ColumnName = "imgedit"
        Principal.Columns.Add(FirstImageColumn)

        Principal.Columns.Add("ojnumi")
        Principal.Columns.Add("ojnumi2")
        Principal.Columns.Add("ojccli")
        Principal.Columns.Add("nombre")
        ''Columnas de los productos en conciliacion a.oinumi ,a.oinumi2 ,a.oicprod ,b.cadesc as producto,a.oicant
        ''''''''''''''''Aqui relleno columnas de los productos con una columna adiccional que diga su estado
        Dim columnas As New DataTable
        If (tbConciliacion.Text = String.Empty Or tbCodigo.Text <> String.Empty) Then
            columnas = L_prNotaDetalleConciliacion(_numi)
            For Each fila As DataRow In columnas.Rows
                Dim col1 As DataColumn = New DataColumn()
                col1.DataType = GetType(Double)
                col1.ColumnName = fila.Item("oicprod").ToString.Trim
                Principal.Columns.Add(col1)

                Dim precio As DataColumn = New DataColumn()
                precio.DataType = GetType(Double)
                precio.ColumnName = "precio" + fila.Item("oicprod").ToString.Trim
                Principal.Columns.Add(precio)

                Dim numi As DataColumn = New DataColumn()
                numi.DataType = GetType(Integer)
                numi.ColumnName = "numi" + fila.Item("oicprod").ToString.Trim
                Principal.Columns.Add(numi)

                Dim estado As DataColumn = New DataColumn()
                estado.DataType = GetType(Integer)
                estado.ColumnName = "estado" + fila.Item("oicprod").ToString.Trim
                Principal.Columns.Add(estado)
            Next

        Else
            If (tbConciliacion.Text <> String.Empty And tbCodigo.Text = String.Empty) Then
                columnas = L_prNotaObtenerProductosConciliacion(tbConciliacion.Text)
                For Each fila As DataRow In columnas.Rows
                    Dim col1 As DataColumn = New DataColumn()
                    col1.DataType = GetType(Double)
                    col1.ColumnName = fila.Item("oicprod").ToString.Trim
                    Principal.Columns.Add(col1)

                    Dim precio As DataColumn = New DataColumn()
                    precio.DataType = GetType(Double)
                    precio.ColumnName = "precio" + fila.Item("oicprod").ToString.Trim
                    Principal.Columns.Add(precio)

                    Dim numi As DataColumn = New DataColumn()
                    numi.DataType = GetType(Integer)
                    numi.ColumnName = "numi" + fila.Item("oicprod").ToString.Trim
                    Principal.Columns.Add(numi)

                    Dim estado As DataColumn = New DataColumn()
                    estado.DataType = GetType(Integer)
                    estado.ColumnName = "estado" + fila.Item("oicprod").ToString.Trim
                    Principal.Columns.Add(estado)
                Next
            End If

        End If


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim precioContado As DataColumn = New DataColumn()
        precioContado.DataType = GetType(Double)
        precioContado.ColumnName = "ojprecon"
        Principal.Columns.Add(precioContado)

        Dim precioCredito As DataColumn = New DataColumn()
        precioCredito.DataType = GetType(Double)
        precioCredito.ColumnName = "ojprecre"
        Principal.Columns.Add(precioCredito)

        Dim precioDescuento As DataColumn = New DataColumn()
        precioDescuento.DataType = GetType(Double)
        precioDescuento.ColumnName = "ojdesc"
        Principal.Columns.Add(precioDescuento)

        Dim nota As DataColumn = New DataColumn()
        nota.DataType = GetType(String)
        nota.ColumnName = "ojnota"
        Principal.Columns.Add(nota)

        Dim Observacion As DataColumn = New DataColumn()
        Observacion.DataType = GetType(String)
        Observacion.ColumnName = "ojobs"
        Principal.Columns.Add(Observacion)

        Dim colEstado As DataColumn = New DataColumn()
        colEstado.DataType = GetType(Integer)
        colEstado.ColumnName = "estado"
        Principal.Columns.Add(colEstado)

        Dim SecondImageColumn As DataColumn = New DataColumn()
        SecondImageColumn.DataType = GetType(Bitmap)
        SecondImageColumn.ColumnName = "img"
        Principal.Columns.Add(SecondImageColumn)

        'Cargo los datos de Clientes con cantidad de producto insertado
        For i As Integer = 0 To tablaP.Rows.Count - 1 Step 1
            Principal.Rows.Add()
            Principal.Rows(i).Item("ojnumi") = tablaP.Rows(i).Item("ojnumi")
            Principal.Rows(i).Item("ojnumi2") = tablaP.Rows(i).Item("ojnumi2")
            Principal.Rows(i).Item("ojccli") = tablaP.Rows(i).Item("ojccli")
            Principal.Rows(i).Item("nombre") = tablaP.Rows(i).Item("nombre")
            Principal.Rows(i).Item("ojnota") = tablaP.Rows(i).Item("ojnota")
            Principal.Rows(i).Item("ojobs") = tablaP.Rows(i).Item("ojobs")
            Principal.Rows(i).Item("ojprecon") = tablaP.Rows(i).Item("ojprecon")
            Principal.Rows(i).Item("ojprecre") = tablaP.Rows(i).Item("ojprecre")
            Principal.Rows(i).Item("ojdesc") = tablaP.Rows(i).Item("ojdesc")
            Principal.Rows(i).Item("estado") = tablaP.Rows(i).Item("estado")
        Next


        For i As Integer = 0 To Principal.Rows.Count - 1 Step 1
            'a.oknumi ,a.oknumi2 ,a.okcprod ,a.okccant ,1 as estado
            Dim dtprod As New DataTable
            dtprod = L_prNotaDetalleCLienteProductos(Principal.Rows(i).Item("ojnumi"))
            Dim list As List(Of Integer) = New List(Of Integer)
            For j As Integer = 0 To dtprod.Rows.Count - 1 Step 1
                Dim numi As Integer = IIf(IsDBNull(dtprod.Rows(j).Item("oknumi")), 0, dtprod.Rows(j).Item("oknumi"))
                Principal.Rows(i).Item("numi" + dtprod.Rows(j).Item("okcprod").ToString.Trim) = numi

                Principal.Rows(i).Item("estado" + dtprod.Rows(j).Item("okcprod").ToString.Trim) = dtprod.Rows(j).Item("estado")
                Principal.Rows(i).Item("precio" + dtprod.Rows(j).Item("okcprod").ToString.Trim) = dtprod.Rows(j).Item("okprecio")
                Principal.Rows(i).Item(dtprod.Rows(j).Item("okcprod").ToString.Trim) = dtprod.Rows(j).Item("okccant")
                list.Add(dtprod.Rows(j).Item("okcprod"))
            Next
            Dim producto As New DataTable
            producto = CType(dgjTotal.DataSource, DataTable)
            For k As Integer = 0 To producto.Rows.Count - 1 Step 1
                'a.oinumi ,a.oinumi2 ,a.oicprod ,b.cadesc as producto,b.cadesc2 as descripcion,a.oicant ,1 as estad
                Dim cprod As Integer = producto.Rows(k).Item("oicprod")
                If (Not list.Contains(cprod)) Then
                    Dim numicliente As Integer = Principal.Rows(i).Item("ojccli")
                    Dim dtPrecio As DataTable = L_prNotaObtenerPrecioClienteProducto(numicliente, cprod)
                    If (dtPrecio.Rows.Count > 0) Then
                        Dim columna As String = "precio" + Str(cprod).Trim
                        Principal.Rows(i).Item(columna) = dtPrecio.Rows(0).Item("chprecio")
                    End If
                End If
            Next
        Next

        P_prArmarGrillaDetalle(Principal, columnas)
    End Sub

    Private Sub _prCargarVenta()
        Dim dt As New DataTable
        dt = L_prNotaGeneral()
        grmovimiento.DataSource = dt
        grmovimiento.RetrieveStructure()
        grmovimiento.AlternatingColors = True
        With grmovimiento.RootTable.Columns("ohnumi")
            .Width = 100
            .Caption = "CODIGO"
            .Visible = True
        End With
        With grmovimiento.RootTable.Columns("ohfec")
            .Width = 120
            .Visible = True
            .Caption = "FECHA"
            .FormatString = "dd/MM/yyyy"
        End With
        With grmovimiento.RootTable.Columns("ohcon")
            .Width = 90
            .Visible = False
        End With
        With grmovimiento.RootTable.Columns("ohest")
            .Width = 90
            .Visible = False
        End With

        With grmovimiento.RootTable.Columns("chofer")
            .Width = 400
            .Visible = True
            .Caption = "CHOFER"
        End With
        With grmovimiento.RootTable.Columns("total")
            .Width = 250
            .FormatString = "0.00"
            .Visible = True
            .Caption = "TOTAL"
        End With
        With grmovimiento.RootTable.Columns("ohfact")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With grmovimiento.RootTable.Columns("ohhact")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With grmovimiento.RootTable.Columns("ohuact")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With

        With grmovimiento
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With

        If (dt.Rows.Count <= 0) Then
            _prCargarDetalleVenta(-1)
        End If
    End Sub
    Private Sub _prCargarClientes()
        Dim dt As New DataTable
        dt = L_prNotaListarCLientes()  '1=Almacen
        dgjCliente.DataSource = dt
        dgjCliente.RetrieveStructure()
        dgjCliente.AlternatingColors = True

        'a.ccnumi ,a.ccdesc ,a.ccdirec ,a.cctelf1  

        With dgjCliente.RootTable.Columns("ccnumi")
            .Width = 100
            .Caption = "CODIGO"
            .Visible = True
        End With
        With dgjCliente.RootTable.Columns("ccdesc")
            .Width = 350
            .Caption = "NOMBRE"
            .Visible = True
        End With

        With dgjCliente.RootTable.Columns("ccdirec")
            .Width = 250
            .Visible = True
            .Caption = "DIRECCION"
        End With
        With dgjCliente.RootTable.Columns("cctelf1")
            .Width = 250
            .Visible = True
            .Caption = "TELEFONO"
        End With


        With dgjCliente
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With
    End Sub
    Private Sub _prAddDetalleVenta()
        ''a.icid ,a.icibid ,a.iccprod ,b.cadesc as producto,a.iccant ,Cast(null as image ) as img,1 as estado
        'Dim Bin As New MemoryStream
        'Dim img As New Bitmap(My.Resources.delete, 28, 28)
        'img.Save(Bin, Imaging.ImageFormat.Png)
        Dim Bin As New MemoryStream
        Dim img As New Bitmap(My.Resources.delete, 28, 28)
        img.Save(Bin, Imaging.ImageFormat.Png)
        Dim Bin2 As New MemoryStream
        Dim img2 As New Bitmap(My.Resources.SALDO_ALMACEN, 28, 28)
        img.Save(Bin2, Imaging.ImageFormat.Png)
        CType(dgjDetalle.DataSource, DataTable).Rows.Add()
        Dim pos As Integer = CType(dgjDetalle.DataSource, DataTable).Rows.Count - 1
        If (pos >= 0) Then
            CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("imgedit") = img2 '[colimgedit]
            CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("img") = img
            CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("estado") = 0
            CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("ojnumi") = _fnSiguienteNumi() + 1
            CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("ojprecon") = 0
            CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("ojprecre") = 0
            CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("ojdesc") = 0
        End If

    End Sub
    Public Function _fnSiguienteNumi()
        Dim dt As DataTable = CType(dgjDetalle.DataSource, DataTable)
        Dim mayor As Integer = 0
        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            Dim data As Integer = IIf(IsDBNull(CType(dgjDetalle.DataSource, DataTable).Rows(i).Item("ojnumi")), 0, CType(dgjDetalle.DataSource, DataTable).Rows(i).Item("ojnumi"))
            If (data > mayor) Then
                mayor = data
            End If
        Next
        Return mayor
    End Function

    Public Function _fnAccesible()
        Return tbFecha.IsInputReadOnly = False
    End Function

    Private Sub _HabilitarClientes()
        GPanelProductos.Visible = True
        MPnInferior.Visible = False
        _prCargarClientes()
        dgjCliente.Focus()
        dgjCliente.MoveTo(dgjCliente.FilterRow)
        dgjCliente.Col = 1
    End Sub
    Private Sub _DesHabilitarClientes()
        If (GPanelProductos.Visible = True) Then
            GPanelProductos.Visible = False
            MPnInferior.Visible = True
            dgjDetalle.Select()
            dgjDetalle.Col = 4
            dgjDetalle.Row = dgjDetalle.RowCount - 1
        End If

    End Sub

    Public Sub _fnObtenerFilaDetalle(ByRef pos As Integer, numi As Integer)
        For i As Integer = 0 To CType(dgjDetalle.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim _numi As Integer = CType(dgjDetalle.DataSource, DataTable).Rows(i).Item("ojnumi")
            If (_numi = numi) Then
                pos = i
                Return
            End If
        Next

    End Sub

    Public Sub _fnObtenerFilaDetalleConciliacion(ByRef pos As Integer, producto As Integer)
        For i As Integer = 0 To CType(dgjDetalle.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim _numi As Integer = CType(dgjDetalle.DataSource, DataTable).Rows(i).Item("canumi")
            If (_numi = producto) Then
                pos = i
                Return
            End If
        Next
    End Sub

    Public Function _fnExisteCliente(idClie As Integer) As Boolean
        For i As Integer = 0 To CType(dgjDetalle.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim _idCliente As Integer = IIf(IsDBNull(CType(dgjDetalle.DataSource, DataTable).Rows(i).Item("ojccli")), 0, CType(dgjDetalle.DataSource, DataTable).Rows(i).Item("ojccli"))
            Dim estado As Integer = IIf(IsDBNull(CType(dgjDetalle.DataSource, DataTable).Rows(i).Item("estado")), 0, CType(dgjDetalle.DataSource, DataTable).Rows(i).Item("estado"))
            If (_idCliente = idClie And estado >= 0) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub _prEliminarFila()
        If (dgjDetalle.Row = dgjDetalle.RowCount) Then
            Return
        End If
        If (dgjDetalle.Row >= 0 And dgjDetalle.Row <= dgjDetalle.RowCount - 1) Then
            If (dgjDetalle.RowCount >= 2) Then
                Dim estado As Integer = IIf(IsDBNull(dgjDetalle.GetValue("estado")), 0, dgjDetalle.GetValue("estado"))
                Dim pos As Integer = -1
                Dim lin As Integer = IIf(IsDBNull(dgjDetalle.GetValue("ojnumi")), 0, dgjDetalle.GetValue("ojnumi"))
                _fnObtenerFilaDetalle(pos, lin)
                If (estado = 0) Then
                    CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("estado") = -2
                    dgjDetalle.SetValue("estado", -2)
                End If
                If (estado = 1) Then
                    CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("estado") = -1
                    dgjDetalle.SetValue("estado", -1)
                End If
                dgjDetalle.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(dgjDetalle.RootTable.Columns("estado"), Janus.Windows.GridEX.ConditionOperator.GreaterThanOrEqualTo, 0))

                'grdetalle.Select()
                'grdetalle.Col = 3
            End If
        End If
    End Sub

    Public Function _ValidarCampos() As Boolean
        If (tbChofer.Text = String.Empty) Then
            Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
            ToastNotification.Show(Me, "Por Favor Seleccione un Chofer con Ctrl+Enter".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            tbChofer.Focus()
            Return False
        End If

        If (Not VerificarTotales()) Then
            Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
            ToastNotification.Show(Me, "Por favor Rellene el detalle de la venta con la cantidad exacta de la conciliacion".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            tbChofer.Focus()
            Return False

        End If

        Return True
    End Function
    Public Function VerificarTotales() As Boolean
        'a.oinumi ,a.oinumi2 ,a.oicprod ,b.cadesc as producto,b.cadesc2 as descripcion,a.oicant ,1 as estado
        Dim dt As DataTable = CType(dgjTotal.DataSource, DataTable)
        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            Dim columna As String = dt.Rows(i).Item("oicprod").ToString.Trim
            Dim sum As Integer = dgjDetalle.GetTotal(dgjDetalle.RootTable.Columns(columna), AggregateFunction.Sum)
            'Dim total As Integer = dt.Rows(i).Item("oicant")'[cantvalidacion]
            Dim total As Integer = dt.Rows(i).Item("subtotal")
            If (total <> sum) Then
                Return False
            End If
        Next
        Return True
    End Function

    '    TO0042 a.ojnumi ,a.ojnumi2 ,a.ojccli,b.ccdesc as nombre ,a.ojnota ,a.ojobs ,a.ojprecon ,a.ojprecre,1 as estado 
    '    TO0041
    'a.oinumi ,a.oinumi2 ,a.oicprod ,b.cadesc as producto,b.cadesc2 as descripcion,a.oicant ,1 as estado
    'TO0043
    'a.oknumi ,a.oknumi2 ,a.okcprod ,a.okccant ,1 as estado
    Public Sub _prCargarDetalles(ByRef TO0042 As DataTable, ByRef TO0043 As DataTable)
        Dim dt As DataTable = CType(dgjDetalle.DataSource, DataTable)
        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            Dim estado As Integer = dt.Rows(i).Item("estado")
            If (estado >= 0) Then
                TO0042.Rows.Add(dt.Rows(i).Item("ojnumi"), dt.Rows(i).Item("ojnumi2"), dt.Rows(i).Item("ojccli"), dt.Rows(i).Item("nombre"), dt.Rows(i).Item("ojprecon"), dt.Rows(i).Item("ojprecre"), dt.Rows(i).Item("ojdesc"), dt.Rows(i).Item("ojnota").ToString, dt.Rows(i).Item("ojobs").ToString, dt.Rows(i).Item("estado"))
                Dim dtProducto As DataTable = CType(dgjTotal.DataSource, DataTable)
                'Dim cantprod As Integer = 0
                For j As Integer = 0 To dtProducto.Rows.Count - 1 Step 1
                    Dim columna As String = dtProducto.Rows(j).Item("oicprod").ToString.Trim
                    Dim data As Double = IIf(IsDBNull(dt.Rows(i).Item(columna)), 0, dt.Rows(i).Item(columna))
                    Dim columnaEstado As String = "estado" + dtProducto.Rows(j).Item("oicprod").ToString.Trim
                    Dim estadoProducto As Integer = IIf(IsDBNull(dt.Rows(i).Item(columnaEstado)), 0, dt.Rows(i).Item(columnaEstado))
                    If (estadoProducto >= 0) Then
                        If (data > 0) Then
                            TO0043.Rows.Add(dt.Rows(i).Item("numi" + columna), dt.Rows(i).Item("ojnumi"), columna, data, dt.Rows(i).Item("precio" + columna), estadoProducto)
                        Else
                            If (estadoProducto = 2 And data = 0) Then
                                TO0043.Rows.Add(dt.Rows(i).Item("numi" + columna), dt.Rows(i).Item("ojnumi"), columna, data, dt.Rows(i).Item("precio" + columna), -1)
                            End If
                        End If
                    Else
                        If (estadoProducto = -1) Then
                            TO0043.Rows.Add(dt.Rows(i).Item("numi" + columna), dt.Rows(i).Item("ojnumi"), columna, data, estadoProducto)
                        End If
                    End If
                Next
            End If
        Next
    End Sub

    Public Sub _GuardarNuevo()
        Dim numi As String = ""
        Dim TO0042 As DataTable = L_prNotaDetalleCLiente(-1)
        Dim TO0043 As DataTable = L_prNotaDetalleCLienteProductos(-1)
        _prCargarDetalles(TO0042, TO0043)
        'L_prNotaVentaGrabar(ByRef _ohnumi As String, _ohfec As String, _ohest As Integer,
        '                                       _ohconc As Integer, _TO0041 As DataTable,
        '                                       _TO0042 As DataTable, _TO0043 As DataTable
        Dim res As Boolean = L_prNotaVentaGrabar(tbCodigo.Text, tbFecha.Value.ToString("yyyy/MM/dd"),
                                                 IIf(swestado.Value = True, 1, 0), tbConciliacion.Text,
                                                 CType(dgjTotal.DataSource, DataTable),
                                                 TO0042, TO0043) '.DefaultView.ToTable(False, "oinumi", "oinumi2", "oicprod", "descripcion", "producto", "oicant", "estado")
        If res Then
            _prCargarVenta()
            _Limpiar()
            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Movimiento ".ToUpper + tbCodigo.Text + " Grabado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter
                                      )
            MBtSalir.PerformClick()
        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "El Movimiento no pudo ser insertado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
        End If
    End Sub

    Private Sub _prGuardarModificado()
        Dim numi As String = ""
        Dim TO0042 As DataTable = L_prNotaDetalleCLiente(-1)
        Dim TO0043 As DataTable = L_prNotaDetalleCLienteProductos(-1)
        _prCargarDetalles(TO0042, TO0043)
        'L_prNotaVentaGrabar(ByRef _ohnumi As String, _ohfec As String, _ohest As Integer,
        '                                       _ohconc As Integer, _TO0041 As DataTable,
        '                                       _TO0042 As DataTable, _TO0043 As DataTable
        Dim res As Boolean = L_prNotaVentaModificar(tbCodigo.Text, tbFecha.Value.ToString("yyyy/MM/dd"), IIf(swestado.Value = True, 1, 0), tbConciliacion.Text, CType(dgjTotal.DataSource, DataTable), TO0042, TO0043)
        If res Then
            _prCargarVenta()
            _prInhabiliitar()

            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Movimiento ".ToUpper + tbCodigo.Text + " Grabado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter
                                      )
        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "El Movimiento no pudo ser insertado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
        End If
    End Sub

    Private Sub _prSalir()
        If MBtGrabar.Enabled = True Then
            _prInhabiliitar()
            _Limpiar()
            If grmovimiento.RowCount > 0 Then
                _prMostrarRegistro(grmovimiento.RowCount - 1)
            End If
            boNuevo = False '[addclivmovil]
        Else
            Me.Close()
            _modulo.Select()
            _tab.Close()
        End If
    End Sub

    Public Sub _prCargarIconELiminar()
        For i As Integer = 0 To CType(dgjDetalle.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim Bin As New MemoryStream
            Dim img As New Bitmap(My.Resources.delete, 28, 28)
            img.Save(Bin, Imaging.ImageFormat.Png)
            Dim Bin2 As New MemoryStream
            Dim img2 As New Bitmap(My.Resources.SALDO_ALMACEN, 28, 28)
            img2.Save(Bin2, Imaging.ImageFormat.Png)
            CType(dgjDetalle.DataSource, DataTable).Rows(i).Item("imgedit") = img2 '[colimgedit]
            CType(dgjDetalle.DataSource, DataTable).Rows(i).Item("img") = img
            dgjDetalle.RootTable.Columns("imgedit").Visible = True
            dgjDetalle.RootTable.Columns("img").Visible = True
        Next
    End Sub

    Public Sub _PrimerRegistro()
        Dim _MPos As Integer
        If grmovimiento.RowCount > 0 Then
            _MPos = 0
            ''   _prMostrarRegistro(_MPos)
            grmovimiento.Row = _MPos
        End If
    End Sub
#End Region

    Private Sub F0G_MovimientoChofer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _IniciarTodo()
    End Sub

    Private Sub MBtNuevo_Click(sender As Object, e As EventArgs) Handles MBtNuevo.Click
        _Limpiar()
        _prhabilitar()

        MBtNuevo.Enabled = False
        MBtModificar.Enabled = False
        MBtEliminar.Enabled = False
        MBtGrabar.Enabled = True
        MPanelToolBarNavegacion.Enabled = False

        boNuevo = True
    End Sub

    Private Sub MBtSalir_Click(sender As Object, e As EventArgs) Handles MBtSalir.Click
        _prSalir()
    End Sub

    Private Sub grdetalle_EditingCell(sender As Object, e As EditingCellEventArgs) Handles dgjDetalle.EditingCell
        If (_fnAccesible()) Then
            'Columnas que no se puede editar, Cliente, Contado
            If (e.Column.Key = "nombre" Or e.Column.Key = "ojprecon") Then
                e.Cancel = True
            Else 'Las otras columnas
                'Las filas que son vendidas por el movil
                If (dgjDetalle.Row >= inCantVmovil) Then
                    e.Cancel = False
                Else 'filas que NO son vendidas desde el movil
                    e.Cancel = True
                End If
                'Validar que los productos, contado, crédito y nro de factura sean numeros
                If (e.Column.Index > dgjDetalle.RootTable.Columns("nombre").Index And e.Column.Index <= dgjDetalle.RootTable.Columns("ojnota").Index) Then
                    'If (Not IsNumeric(e.Value)) Then
                    '    e.Value = 0
                    'End If
                End If
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub grdetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles dgjDetalle.KeyDown
        If (Not _fnAccesible()) Then
            Return
        End If

        '        If (e.KeyData = Keys.Enter) Then
        '            Dim f, c As Integer
        '            c = grdetalle.Col
        '            f = grdetalle.Row

        '            If (grdetalle.Col = grdetalle.RootTable.Columns("iccant").Index) Then
        '                If (grdetalle.GetValue("producto") <> String.Empty) Then
        '                    _prAddDetalleVenta()
        '                    _HabilitarProductos()
        '                Else
        '                    ToastNotification.Show(Me, "Seleccione un Producto Por Favor", My.Resources.WARNING, 3000, eToastGlowColor.Red, eToastPosition.TopCenter)
        '                End If

        '            End If
        '            If (grdetalle.Col = grdetalle.RootTable.Columns("producto").Index) Then
        '                If (grdetalle.GetValue("producto") <> String.Empty) Then
        '                    _prAddDetalleVenta()
        '                    _HabilitarProductos()
        '                Else
        '                    ToastNotification.Show(Me, "Seleccione un Producto Por Favor", My.Resources.WARNING, 3000, eToastGlowColor.Red, eToastPosition.TopCenter)
        '                End If

        '            End If
        'salirIf:
        '        End If
        If (dgjDetalle.Row = dgjDetalle.RowCount) Then
            Return
        End If
        If (e.KeyData = Keys.Control + Keys.Enter And dgjDetalle.Row >= 0 And dgjDetalle.Row < dgjDetalle.RowCount And
            dgjDetalle.Col = dgjDetalle.RootTable.Columns("nombre").Index) Then
            Dim indexfil As Integer = dgjDetalle.Row
            Dim indexcol As Integer = dgjDetalle.Col
            dgjDetalle.Row = dgjDetalle.RowCount - 1
            If (dgjDetalle.Row > 0 And Not IsDBNull(dgjDetalle.GetValue("ojccli"))) Then
                _prAddDetalleVenta()
            End If
            _HabilitarClientes()
        End If

        If (e.KeyData = Keys.Escape And dgjDetalle.Row >= 0 And dgjDetalle.Row < dgjDetalle.RowCount) Then
            _prEliminarFila()
        End If
    End Sub

    Private Sub grproducto_KeyDown(sender As Object, e As KeyEventArgs) Handles dgjCliente.KeyDown
        If (Not _fnAccesible()) Then
            Return
        End If
        If (e.KeyData = Keys.Enter) Then
            Dim f, c As Integer
            c = dgjCliente.Col
            f = dgjCliente.Row
            If (f >= 0) Then
                Dim pos As Integer = -1
                dgjDetalle.Row = dgjDetalle.RowCount - 1
                _fnObtenerFilaDetalle(pos, dgjDetalle.GetValue("ojnumi"))
                Dim existe As Boolean = _fnExisteCliente(dgjCliente.GetValue("ccnumi"))
                If ((pos >= 0) And (Not existe)) Then
                    CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("ojccli") = dgjCliente.GetValue("ccnumi")
                    CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("nombre") = dgjCliente.GetValue("ccdesc")
                    _prPonerPreciosCLienteSeleccionado(dgjCliente.GetValue("ccnumi"), pos)
                    ''_prCargarClientes()
                    _prAddDetalleVenta()
                    dgjCliente.RemoveFilters()
                    dgjCliente.Focus()
                    dgjCliente.MoveTo(dgjCliente.FilterRow)
                    dgjCliente.Col = 1
                Else
                    If (existe) Then
                        Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
                        ToastNotification.Show(Me, "El producto ya existe en el detalle".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                        dgjCliente.RemoveFilters()
                        dgjCliente.Focus()
                        dgjCliente.MoveTo(dgjCliente.FilterRow)
                        dgjCliente.Col = 1
                    End If
                End If
            End If
        End If
        If e.KeyData = Keys.Escape Then
            _DesHabilitarClientes()
        End If
    End Sub

    Public Sub _prPonerPreciosCLienteSeleccionado(_numiCliente As Integer, _pos As Integer)
        Dim dt As DataTable = CType(dgjTotal.DataSource, DataTable)
        'a.oinumi ,a.oinumi2 ,a.oicprod ,b.cadesc as producto,b.cadesc2 as descripcion,a.oicant ,1 as estado
        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            Dim dtPrecio As DataTable = L_prNotaObtenerPrecioClienteProducto(_numiCliente, dt.Rows(i).Item("oicprod"))
            If (dtPrecio.Rows.Count > 0) Then
                Dim columna As String = "precio" + Str(dt.Rows(i).Item("oicprod")).Trim
                CType(dgjDetalle.DataSource, DataTable).Rows(_pos).Item(columna) = dtPrecio.Rows(0).Item("chprecio")
            End If
        Next
    End Sub

    Public Function _prEsProducto(ByRef columna As String, index As Integer) As Boolean
        '' a.oinumi ,a.oinumi2 ,a.oicprod ,b.cadesc as producto,b.cadesc2 as descripcion,a.oicant ,1 as estado
        Dim dt As DataTable = CType(dgjTotal.DataSource, DataTable)
        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            Dim column As String = dt.Rows(i).Item("oicprod").ToString.Trim
            If (index = dgjDetalle.RootTable.Columns(column).Index) Then
                columna = column
                Return True
            End If
        Next
        Return False
    End Function

    Public Function _fnObtenerTotalProducto(producto As Integer) As Double
        '' a.oinumi ,a.oinumi2 ,a.oicprod ,b.cadesc as producto,b.cadesc2 as descripcion,a.oicant ,1 as estado
        Dim dt As DataTable = CType(dgjTotal.DataSource, DataTable)
        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            Dim data As Integer = dt.Rows(i).Item("oicprod")
            If (producto = data) Then
                'Return dt.Rows(i).Item("oicant") '[cantvalidacion]
                Return dt.Rows(i).Item("subtotal")
            End If
        Next
        Return 0
    End Function

    Public Function _prVerificarCantidadProductoColumnas(columna As String) As Boolean
        Dim dt As DataTable = CType(dgjDetalle.DataSource, DataTable)
        Dim sum As Double = dgjDetalle.GetTotal(dgjDetalle.RootTable.Columns(columna), AggregateFunction.Sum)
        Dim total As Double = _fnObtenerTotalProducto(columna)
        If (sum <= total) Then
            If (sum = total) Then
                dgjDetalle.RootTable.Columns(columna).CellStyle.BackColor = Color.DodgerBlue
            Else
                dgjDetalle.RootTable.Columns(columna).CellStyle.BackColor = DefaultBackColor
            End If
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub _prCalcularPrecioTotal(_pos As Integer)
        '' a.oinumi ,a.oinumi2 ,a.oicprod ,b.cadesc as producto,b.cadesc2 as descripcion,a.oicant ,1 as estado
        Dim dt As New DataTable
        dt = CType(dgjTotal.DataSource, DataTable)
        Dim total As Double = 0
        Dim con As Double = 0
        Dim cre As Double = 0
        Dim desc As Double = 0
        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            Dim column As String = "precio" + dt.Rows(i).Item("oicprod").ToString.Trim
            Dim columnCantidad As String = dt.Rows(i).Item("oicprod").ToString.Trim
            Dim precio As Double = IIf(IsDBNull(dgjDetalle.GetValue(column)), 0, dgjDetalle.GetValue(column))
            Dim cant As Double = 0
            If (Not IsNumeric(dgjDetalle.GetValue(columnCantidad)) Or dgjDetalle.GetValue(columnCantidad).ToString = String.Empty) Then
                cant = 0
            Else
                cant = IIf(IsDBNull(dgjDetalle.GetValue(columnCantidad)), 0, dgjDetalle.GetValue(columnCantidad))
            End If
            total = total + (precio * cant)
        Next
        'CType(grdetalle.DataSource, DataTable).Rows(_pos).Item("ojprecon") = total
        dgjDetalle.SetValue("ojprecon", total)
        con = dgjDetalle.GetTotal(dgjDetalle.RootTable.Columns("ojprecon"), AggregateFunction.Sum)
        cre = dgjDetalle.GetTotal(dgjDetalle.RootTable.Columns("ojprecre"), AggregateFunction.Sum)
        desc = dgjDetalle.GetTotal(dgjDetalle.RootTable.Columns("ojdesc"), AggregateFunction.Sum)
        tbSubTotalContado.Value = con
        tbTotalDescuento.Value = desc
        tbTotalContado.Value = con - desc
        tbTotalCredito.Value = cre
    End Sub

    Private Sub grdetalle_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles dgjDetalle.CellEdited
        If (dgjDetalle.Row = dgjDetalle.RowCount) Then
            Return
        End If
        Dim columna As String = ""
        If (_prEsProducto(columna, e.Column.Index)) Then
            If (Not IsNumeric(dgjDetalle.GetValue(columna)) Or dgjDetalle.GetValue(columna).ToString = String.Empty) Then
                Dim lin As Integer = dgjDetalle.GetValue("ojnumi")
                Dim pos As Integer = -1
                _fnObtenerFilaDetalle(pos, lin)
                CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item(columna) = 0
                Dim estado As Integer = IIf(IsDBNull(CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("estado" + columna)), 0, CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("estado" + columna))
                If (estado = 1) Then
                    CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("estado" + columna) = 2
                End If
                dgjDetalle.SetValue(columna, 0)
                _prCalcularPrecioTotal(pos)
                _prCambiarEstadoTotalContado(pos)
            Else
                Dim lin As Integer = dgjDetalle.GetValue("ojnumi")
                Dim pos As Integer = -1
                _fnObtenerFilaDetalle(pos, lin)
                CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item(columna) = dgjDetalle.GetValue(columna)
                If (dgjDetalle.GetValue(columna) > 0 And _prVerificarCantidadProductoColumnas(columna)) Then
                    Dim estado As Integer = IIf(IsDBNull(CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("estado" + columna)), 0, CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("estado" + columna))

                    If (estado = 1) Then
                        CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("estado" + columna) = 2
                    End If
                    _prCalcularPrecioTotal(pos)
                    _prCambiarEstadoTotalContado(pos)
                Else
                    _fnObtenerFilaDetalle(pos, lin)
                    CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item(columna) = 0
                    Dim estado As Integer = IIf(IsDBNull(CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("estado" + columna)), 0, CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("estado" + columna))

                    If (estado = 1) Then
                        CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("estado" + columna) = 2
                    End If
                    dgjDetalle.SetValue(columna, 0)
                    _prCalcularPrecioTotal(pos)
                    _prCambiarEstadoTotalContado(pos)
                End If
            End If
        ElseIf (e.Column.Key = "ojprecre" Or e.Column.Key = "ojdesc") Then
            _prCambiarEstadoTotalContado(dgjDetalle.Row)
        End If

        Dim dt As DataTable = CType(dgjDetalle.DataSource, DataTable)
        If (e.Column.Index = dgjDetalle.RootTable.Columns("ojnota").Index Or e.Column.Index = dgjDetalle.RootTable.Columns("ojobs").Index) Then
            Dim lin As Integer = dgjDetalle.GetValue("ojnumi")
            Dim pos As Integer = -1
            _fnObtenerFilaDetalle(pos, lin)
            Dim estado As Integer = IIf(IsDBNull(CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("estado")), 0, CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("estado"))
            If (estado = 1) Then
                CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("estado") = 2
            End If
        End If

        If (e.Column.Key = "ojprecre") Then
            _prCalcularPrecioTotal(dgjDetalle.Row)
            Dim con As Double = dgjDetalle.GetValue("ojprecon")
            Dim cre As Double = dgjDetalle.GetValue("ojprecre")
            If (cre < 0) Then
                dgjDetalle.SetValue("ojprecre", 0)
            ElseIf (cre > con) Then
                dgjDetalle.SetValue("ojprecon", 0)
                dgjDetalle.SetValue("ojprecre", con)
                dgjDetalle.SetValue("ojdesc", 0)
            Else
                dgjDetalle.SetValue("ojprecon", con - cre)
                dgjDetalle.SetValue("ojdesc", 0)
            End If
        End If

        If (e.Column.Key = "ojdesc") Then
            Dim cre As Double = dgjDetalle.GetValue("ojprecre")
            If (cre > 0) Then
                dgjDetalle.SetValue("ojdesc", 0)
            End If
        End If

    End Sub

    Public Sub _prCambiarEstadoTotalContado(pos As Integer)
        Dim estado As Integer = IIf(IsDBNull(CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("estado")), 0, CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("estado"))
        If (estado = 1) Then
            CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("estado") = 2
        End If
    End Sub

    Private Sub grdetalle_MouseClick(sender As Object, e As MouseEventArgs) Handles dgjDetalle.MouseClick
        If (Not _fnAccesible()) Then
            Return
        End If
        If (dgjDetalle.Row = dgjDetalle.RowCount) Then
            Return
        End If
        If (dgjDetalle.RowCount >= 2) Then
            If (dgjDetalle.CurrentColumn.Index = dgjDetalle.RootTable.Columns("img").Index) Then
                _prEliminarFila()
            End If
        End If
    End Sub

    Private Sub MBtGrabar_Click(sender As Object, e As EventArgs) Handles MBtGrabar.Click
        If _ValidarCampos() = False Then
            Exit Sub
        End If

        If (tbCodigo.Text = String.Empty) Then
            _GuardarNuevo()
        Else
            If (tbCodigo.Text <> String.Empty) Then
                _prGuardarModificado()
            End If
        End If
    End Sub

    Private Sub MBtModificar_Click(sender As Object, e As EventArgs) Handles MBtModificar.Click
        If (grmovimiento.RowCount > 0) Then
            _prhabilitar()
            MBtNuevo.Enabled = False
            MBtModificar.Enabled = False
            MBtEliminar.Enabled = False
            MBtGrabar.Enabled = True

            MPanelToolBarNavegacion.Enabled = False
            _prCargarIconELiminar()
        End If

    End Sub

    Private Sub MBtEliminar_Click(sender As Object, e As EventArgs) Handles MBtEliminar.Click
        Dim ef = New Efecto
        ef.tipo = 2
        ef.Context = "¿esta seguro de eliminar el registro?".ToUpper
        ef.Header = "mensaje principal".ToUpper
        ef.ShowDialog()
        Dim bandera As Boolean = False
        bandera = ef.band
        If (bandera = True) Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_prNotaVentaEliminar(tbCodigo.Text, tbConciliacion.Text)
            If res Then
                Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
                ToastNotification.Show(Me, "Código de Movimiento ".ToUpper + tbCodigo.Text + " eliminado con Exito.".ToUpper,
                                          img, 2000,
                                          eToastGlowColor.Green,
                                          eToastPosition.TopCenter)

                _prFiltrar()

            Else
                Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                ToastNotification.Show(Me, mensajeError, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            End If
        End If
    End Sub

    Private Sub grmovimiento_SelectionChanged(sender As Object, e As EventArgs) Handles grmovimiento.SelectionChanged
        If (grmovimiento.RowCount >= 0 And grmovimiento.Row >= 0) Then
            _prMostrarRegistro(grmovimiento.Row)
        End If
    End Sub

    Private Sub MBtSiguiente_Click(sender As Object, e As EventArgs) Handles MBtSiguiente.Click
        Dim _pos As Integer = grmovimiento.Row
        If _pos < grmovimiento.RowCount - 1 Then
            _pos = grmovimiento.Row + 1
            '' _prMostrarRegistro(_pos)
            grmovimiento.Row = _pos
        End If
    End Sub

    Private Sub MBtUltimo_Click(sender As Object, e As EventArgs) Handles MBtUltimo.Click
        Dim _pos As Integer = grmovimiento.Row
        If grmovimiento.RowCount > 0 Then
            _pos = grmovimiento.RowCount - 1
            ''  _prMostrarRegistro(_pos)
            grmovimiento.Row = _pos
        End If
    End Sub

    Private Sub MBtAnterior_Click(sender As Object, e As EventArgs) Handles MBtAnterior.Click
        Dim _MPos As Integer = grmovimiento.Row
        If _MPos > 0 And grmovimiento.RowCount > 0 Then
            _MPos = _MPos - 1
            ''  _prMostrarRegistro(_MPos)
            grmovimiento.Row = _MPos
        End If
    End Sub

    Private Sub MBtPrimero_Click(sender As Object, e As EventArgs) Handles MBtPrimero.Click
        _PrimerRegistro()
    End Sub

    Private Sub grmovimiento_KeyDown(sender As Object, e As KeyEventArgs) Handles grmovimiento.KeyDown
        If e.KeyData = Keys.Enter Then
            MSuperTabControlPrincipal.SelectedTabIndex = 0
            dgjDetalle.Focus()

        End If
    End Sub

    Private Sub grdetalle_Enter(sender As Object, e As EventArgs) Handles dgjDetalle.Enter
        If (dgjDetalle.Row = dgjDetalle.RowCount) Then
            Return
        End If
        If (tbConciliacion.Text = String.Empty) Then
            Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
            ToastNotification.Show(Me, "seleccione primero una conciliacion".ToUpper, img, 3000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            tbConciliacion.Focus()

            Return

        End If
        If (dgjDetalle.RowCount > 0) Then
            dgjDetalle.Select()
            dgjDetalle.Col = 3
            dgjDetalle.Row = 0
        End If

    End Sub

    Private Sub tbConciliacion_KeyDown(sender As Object, e As KeyEventArgs) Handles tbConciliacion.KeyDown
        If (_fnAccesible()) Then
            If e.KeyData = Keys.Control + Keys.Enter Then
                P_prArmarAyudaConciliacion()
            End If
        End If
    End Sub

    Private Sub btBuscarConciliacion_Click(sender As Object, e As EventArgs) Handles btBuscarConciliacion.Click
        P_prArmarAyudaConciliacion()
    End Sub

    Private Sub P_prArmarAyudaConciliacion()
        Dim dt As DataTable

        dt = L_prNotaListarConciliaciones()
        'a.ibid ,a.ibfdoc ,a.ibconcep ,a.ibconcep ,c.cbdesc as chofer

        Dim listEstCeldas As New List(Of Modelo.MCelda)
        listEstCeldas.Add(New Modelo.MCelda("ibid,", True, "ID", 50))
        listEstCeldas.Add(New Modelo.MCelda("ibfdoc", True, "Fecha", 220, "yyyy/MM/dd"))
        listEstCeldas.Add(New Modelo.MCelda("ibconcep", False))
        listEstCeldas.Add(New Modelo.MCelda("chofer", True, "CHOFER".ToUpper, 300))


        Dim ef = New Efecto
        ef.tipo = 3
        ef.dt = dt
        ef.SeleclCol = 2
        ef.listEstCeldas = listEstCeldas
        ef.alto = 50
        ef.ancho = 350
        ef.Context = "Seleccione Conciliacion".ToUpper
        ef.ShowDialog()
        Dim bandera As Boolean = False
        bandera = ef.band
        If (bandera = True) Then

            'a.ibid ,a.ibfdoc ,a.ibconcep ,a.ibconcep ,c.cbdesc as chofer
            Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row

            _IdConciliacion = Row.Cells("ibid").Value
            tbConciliacion.Text = Row.Cells("ibid").Value
            tbChofer.Text = Row.Cells("chofer").Value
            swestado.Focus()

            _prCargarDetalleConciliacion(tbConciliacion.Text)
        End If
    End Sub

    Private Sub P_prArmarGrillaDetalle(Principal As DataTable, columnas As DataTable)
        dgjDetalle.DataSource = Principal
        dgjDetalle.RetrieveStructure()
        dgjDetalle.AlternatingColors = True
        dgjDetalle.Height = 200

        If (_fnAccesible()) Then
            With dgjDetalle.RootTable.Columns("imgedit") '[colimgedit]
                .Width = 60
                .Visible = True
                .CellStyle.ImageHorizontalAlignment = ImageHorizontalAlignment.Center
                .Caption = "EDIT"
                .CellStyle.Font = fnDetalle
                .HeaderStyle.Font = fnTitulo
            End With
        Else
            With dgjDetalle.RootTable.Columns("imgedit")
                .Width = 60
                .Visible = False
                .CellStyle.ImageHorizontalAlignment = ImageHorizontalAlignment.Center
                .Caption = "EDIT"
                .CellStyle.Font = fnDetalle
                .HeaderStyle.Font = fnTitulo
            End With
        End If
        With dgjDetalle.RootTable.Columns("ojnumi")
            .Width = 80
            .Visible = False
        End With
        With dgjDetalle.RootTable.Columns("estado")
            .Width = 80
            .Visible = False
        End With
        With dgjDetalle.RootTable.Columns("ojprecon")
            .Width = 100
            .FormatString = "0.00"
            .Visible = True
            .TextAlignment = TextAlignment.Far
            .AggregateFunction = AggregateFunction.Sum
            .Caption = "Contado".ToUpper
            .CellStyle.Font = fnDetalle
            .HeaderStyle.Font = fnTitulo
        End With
        With dgjDetalle.RootTable.Columns("ojprecre")
            .Width = 100
            .FormatString = "0.00"
            .Visible = (gi_vcre = 1)
            .TextAlignment = TextAlignment.Far
            .AggregateFunction = AggregateFunction.Sum
            .Caption = "Crédito".ToUpper
            .CellStyle.Font = fnDetalle
            .HeaderStyle.Font = fnTitulo
        End With
        With dgjDetalle.RootTable.Columns("ojdesc")
            .Width = 100
            .FormatString = "0.00"
            .Visible = (gi_vdes = 1)
            .TextAlignment = TextAlignment.Far
            .AggregateFunction = AggregateFunction.Sum
            .Caption = "Descuento".ToUpper
            .CellStyle.Font = fnDetalle
            .HeaderStyle.Font = fnTitulo
        End With
        With dgjDetalle.RootTable.Columns("ojnumi2")
            .Width = 80
            .Visible = False
        End With
        With dgjDetalle.RootTable.Columns("ojccli")
            .Width = 80
            .Visible = False
        End With

        With dgjDetalle.RootTable.Columns("nombre")
            .Width = 300
            .Visible = True
            .Caption = "CLIENTE"
            .CellStyle.Font = fnDetalle
            .HeaderStyle.Font = fnTitulo
        End With
        With dgjDetalle.RootTable.Columns("ojnota")
            .Width = 100
            .Visible = True
            .Caption = "FACTURA"
            .FormatString = "0"
            .CellStyle.Font = fnDetalle
            .HeaderStyle.Font = fnTitulo
        End With
        With dgjDetalle.RootTable.Columns("ojobs")
            .Width = 150
            .Visible = True
            .Caption = "OBSERVACION"
            .CellStyle.Font = fnDetalle
            .HeaderStyle.Font = fnTitulo
        End With
        If (_fnAccesible()) Then
            With dgjDetalle.RootTable.Columns("img")
                .Width = 60
                .Visible = True
                .CellStyle.ImageHorizontalAlignment = ImageHorizontalAlignment.Center
                .Caption = "DEL"
                .CellStyle.Font = fnDetalle
                .HeaderStyle.Font = fnTitulo
            End With
        Else
            With dgjDetalle.RootTable.Columns("img")
                .Width = 60
                .Visible = False
                .CellStyle.ImageHorizontalAlignment = ImageHorizontalAlignment.Center
                .Caption = "DEL"
                .CellStyle.Font = fnDetalle
                .HeaderStyle.Font = fnTitulo
            End With
        End If

        For Each fila As DataRow In columnas.Rows

            Dim columPrecio As String = "precio" + fila.Item("oicprod").ToString.Trim
            With dgjDetalle.RootTable.Columns(columPrecio)
                .Width = 80
                .Visible = False
            End With
            Dim columNumi As String = "numi" + fila.Item("oicprod").ToString.Trim
            With dgjDetalle.RootTable.Columns(columNumi)
                .Width = 80
                .Visible = False
            End With
            Dim columEstado As String = "estado" + fila.Item("oicprod").ToString.Trim
            With dgjDetalle.RootTable.Columns(columEstado)
                .Width = 80
                .Visible = False
            End With
            Dim columProducto As String = fila.Item("oicprod").ToString.Trim
            With dgjDetalle.RootTable.Columns(columProducto)
                .Width = 80 '[tamcolproducto]
                .Visible = True
                .AggregateFunction = AggregateFunction.Sum
                .TextAlignment = TextAlignment.Far
                .FormatString = "0.00"
                .Caption = fila.Item("producto").ToString.Trim
                .CellStyle.Font = fnDetalle
                .HeaderStyle.Font = fnTituloReducido
            End With
        Next

        'a.icid ,a.icibid ,a.iccprod ,b.cadesc as producto,a.iccant ,Cast(null as image ) as img,1 as estado
        With dgjDetalle
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
            .TotalRowFormatStyle.BackColor = Color.Gold
            .TotalRowPosition = TotalRowPosition.BottomFixed
            .TotalRow = InheritableBoolean.True
        End With

        For Each col As GridEXColumn In dgjDetalle.RootTable.Columns
            If (dgjDetalle.RowCount > 0) Then
                If (_prEsProducto(col.Key, col.Index)) Then
                    _prVerificarCantidadProductoColumnas(col.Key)

                    Dim con As Double = dgjDetalle.GetTotal(dgjDetalle.RootTable.Columns("ojprecon"), AggregateFunction.Sum)
                    Dim cre As Double = dgjDetalle.GetTotal(dgjDetalle.RootTable.Columns("ojprecre"), AggregateFunction.Sum)
                    Dim desc As Double = dgjDetalle.GetTotal(dgjDetalle.RootTable.Columns("ojdesc"), AggregateFunction.Sum)
                    tbSubTotalContado.Value = con
                    tbTotalDescuento.Value = desc
                    tbTotalContado.Value = con - desc
                    tbTotalCredito.Value = cre
                End If
            End If
        Next

    End Sub

    Private Sub MBtImprimir_Click(sender As Object, e As EventArgs) Handles MBtImprimir.Click
        If (Not tbCodigo.Text.Trim = String.Empty) Then
            P_prGenerarReporte()
        End If
    End Sub

    Private Sub P_prGenerarReporte()
        Dim dt As DataTable
        dt = L_fnObtenerTabla("*", "vr_go_comprobanteVenta", "codigo=" + tbCodigo.Text)

        If Not IsNothing(P_Global.Visualizador) Then
            P_Global.Visualizador.Close()
        End If

        P_Global.Visualizador = New Visualizador
        Dim objrep As New R_ComprobanteVenta

        objrep.SetDataSource(dt)

        P_Global.Visualizador.CRV1.ReportSource = objrep
        P_Global.Visualizador.Show()
        P_Global.Visualizador.BringToFront()
    End Sub

End Class
