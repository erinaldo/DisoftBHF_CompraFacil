Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports System.IO
Public Class F0_MCaja

#Region "VARIABLES GLOBALES"
    Dim Numi_Chofer As Integer
    Dim Numi_Conciliacion As Integer
    Dim Bin As New MemoryStream
    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

    Private boShow As Boolean = False
    Private boAdd As Boolean = False
    Private boModif As Boolean = False
    Private boDel As Boolean = False

    Private InDuracion As Byte = 5

#End Region


#Region "METODOS PRIVADOS"
    Private Sub _IniciarTodo()

        ''L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        Me.WindowState = FormWindowState.Maximized

        _prInhabiliitar()
        _prCargarVenta()
        'Dim blah As New Bitmap(New Bitmap(My.Resources.compra), 20, 20)
        'Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        'Me.Icon = ico
        Me.Text = "CAJA"

        _prAsignarPermisos()

        If (GridEX1.RowCount > 0) Then
            _prMostrarRegistro(0)
        End If
        SuperTabControl1.SelectedTabIndex = 0
    End Sub

    Public Sub _prCrearTablaConciliacion()

        Dim TablaPrincipal As DataTable = L_prConciliacionObtenerProducto(Numi_Conciliacion) ''2=Chofer   1=Concepto
        Dim columnas As DataTable = L_prConciliacionObtenerIdNumiTI002(Numi_Conciliacion)
        For Each fila As DataRow In columnas.Rows
            TablaPrincipal.Columns.Add(fila.Item("ibid").ToString.Trim)
        Next
        Dim Productos As DataTable = L_prConciliacionObtenerProductoTI0021(Numi_Conciliacion)
        For j As Integer = 0 To TablaPrincipal.Rows.Count - 1 Step 1
            Dim idprod As Integer = TablaPrincipal.Rows(j).Item("canumi")
            Dim result As DataRow() = Productos.Select("iccprod=" + Str(idprod))
            For i As Integer = 0 To result.Length - 1 Step 1
                Dim rowIndex As Integer = TablaPrincipal.Rows.IndexOf(result(i))
                Dim columnnumi As String = result(i).Item("ibid")

                TablaPrincipal.Rows(j).Item(columnnumi) = result(i).Item("iccant")

            Next
        Next
        TablaPrincipal.Columns.Add("ID_TO1", Type.GetType("System.String"))
        TablaPrincipal.Columns.Add("DEVOLUCION")
        TablaPrincipal.Columns.Add("TOTAL")
        TablaPrincipal.Columns.Add("MOVIL")
        TablaPrincipal.Columns.Add("PC")
        TablaPrincipal.Columns.Add("TOTAL_ENTREGADO")
        TablaPrincipal.Columns.Add("TOTALCOPIA")
        TablaPrincipal.Columns.Add("estado")
        TablaPrincipal.Columns.Add("icid")
        TablaPrincipal.Columns.Add("img", Type.GetType("System.Byte[]"))
        '''''''''''Aqui inserto los movimientos ya insertados para modificarlos
        Dim ProductosMovimientoSalida As DataTable = L_prConciliacionObtenerProductoTI0021Idnumi(Numi_Conciliacion) ''''Estado=3 Conciliacion Chofer
        For j As Integer = 0 To TablaPrincipal.Rows.Count - 1 Step 1
            Dim idprod As Integer = TablaPrincipal.Rows(j).Item("canumi")
            Dim result As DataRow() = ProductosMovimientoSalida.Select("iccprod=" + Str(idprod))
            For i As Integer = 0 To result.Length - 1 Step 1
                Dim rowIndex As Integer = TablaPrincipal.Rows.IndexOf(result(i))
                TablaPrincipal.Rows(j).Item("DEVOLUCION") = result(i).Item("iccant")
                TablaPrincipal.Rows(j).Item("estado") = 1
                TablaPrincipal.Rows(j).Item("icid") = result(i).Item("icid")
            Next
        Next
        'TablaPrincipal.Columns.Add("DEVOLUCION")

        '''''''''''Aqui inserto las ventas realidas con el movil
        Dim dtVentaMovil As DataTable = L_prListarProductosMovil(CType(grtotalpedidos.DataSource, DataTable))


        For j As Integer = 0 To TablaPrincipal.Rows.Count - 1 Step 1
            Dim codProd As String = TablaPrincipal.Rows(j).Item("canumi")
            Dim result As DataRow() = dtVentaMovil.Select("obcprod=" + "'" + codProd + "'")
            For i As Integer = 0 To result.Length - 1 Step 1
                Dim rowIndex As Integer = TablaPrincipal.Rows.IndexOf(result(i))
                TablaPrincipal.Rows(j).Item("MOVIL") = IIf(IsDBNull(TablaPrincipal.Rows(j).Item("MOVIL")), 0, TablaPrincipal.Rows(j).Item("MOVIL")) + result(i).Item("obpcant")
                'If (TablaPrincipal.Rows(j).Item("ID_TO1").ToString.Trim = String.Empty Or IsDBNull(TablaPrincipal.Rows(j).Item("ID_TO1"))) Then
                '    TablaPrincipal.Rows(j).Item("ID_TO1") = result(i).Item("oanumi").ToString
                'Else
                '    TablaPrincipal.Rows(j).Item("ID_TO1") = TablaPrincipal.Rows(j).Item("ID_TO1").ToString + "," + result(i).Item("oanumi").ToString
                'End If

            Next
        Next



        '''''''''''Aqui inserto las ventas realidas con el PC
        Dim dtVentaPc As DataTable = L_prListarProductosPC(CType(grtotalpedidos.DataSource, DataTable))


        For j As Integer = 0 To TablaPrincipal.Rows.Count - 1 Step 1
            Dim idprod As String = TablaPrincipal.Rows(j).Item("canumi")
            Dim result As DataRow() = dtVentaPc.Select("obcprod=" + "'" + idprod + "'")
            For i As Integer = 0 To result.Length - 1 Step 1
                Dim rowIndex As Integer = TablaPrincipal.Rows.IndexOf(result(i))
                TablaPrincipal.Rows(j).Item("PC") = IIf(IsDBNull(TablaPrincipal.Rows(j).Item("PC")), 0, TablaPrincipal.Rows(j).Item("PC")) + result(i).Item("obpcant")


            Next
        Next
        '''''''Suma de Totales
        For i As Integer = 0 To TablaPrincipal.Rows.Count - 1 Step 1
            Dim suma As Double = 0
            Dim sumaMovil As Double = 0
            For c As Integer = 0 To columnas.Rows.Count - 1 Step 1
                Dim colum As String = columnas.Rows(c).Item("ibid")
                suma = suma + IIf(IsDBNull(TablaPrincipal.Rows(i).Item(colum)), 0, TablaPrincipal.Rows(i).Item(colum))
            Next
            sumaMovil = IIf(IsDBNull(TablaPrincipal.Rows(i).Item("MOVIL")), 0, TablaPrincipal.Rows(i).Item("MOVIL"))
            TablaPrincipal.Rows(i).Item("TOTALCOPIA") = suma '- sumaMovil
            suma = suma - IIf(IsDBNull(TablaPrincipal.Rows(i).Item("DEVOLUCION")), 0, TablaPrincipal.Rows(i).Item("DEVOLUCION"))
            TablaPrincipal.Rows(i).Item("TOTAL") = suma '- sumaMovil

        Next


        For i As Integer = 0 To TablaPrincipal.Rows.Count - 1 Step 1
            Dim movil As Double = IIf(IsDBNull(TablaPrincipal.Rows(i).Item("MOVIL")), 0, TablaPrincipal.Rows(i).Item("MOVIL"))
            Dim pc As Double = If(IsDBNull(TablaPrincipal.Rows(i).Item("PC")), 0, TablaPrincipal.Rows(i).Item("PC"))


            TablaPrincipal.Rows(i).Item("TOTAL_ENTREGADO") = movil + pc '- sumaMovil
            Next


        Dim dt As New DataTable
        dt = TablaPrincipal
        _prCargarIcono(dt)
        grdetalle.DataSource = dt
        grdetalle.RetrieveStructure()
        grdetalle.AlternatingColors = True
        For c As Integer = 0 To columnas.Rows.Count - 1 Step 1
            Dim colum As String = columnas.Rows(c).Item("ibid")
            With grdetalle.RootTable.Columns(colum)
                .Width = 150
                .Visible = False
                .TextAlignment = TextAlignment.Far
                .FormatString = "0"
                .Caption = "Salida " + Str(c + 1)
            End With
        Next

        With grdetalle.RootTable.Columns("canumi")
            .Width = 150
            .Visible = False
        End With
        With grdetalle.RootTable.Columns("estado")
            .Width = 150
            .Visible = False
        End With
        With grdetalle.RootTable.Columns("icid")
            .Width = 150
            .Visible = False
        End With
        With grdetalle.RootTable.Columns("cadesc")
            .Width = 200
            .Visible = True
            .Caption = "PRODUCTO"
        End With
        With grdetalle.RootTable.Columns("ID_TO1")
            .Width = 150
            .Visible = False
        End With
        With grdetalle.RootTable.Columns("MOVIL")
            .Width = 150
            .Visible = True
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
            .Caption = "MOVIL"
            '.CellStyle.BackColor = Color.CadetBlue
        End With
        With grdetalle.RootTable.Columns("PC")
            .Width = 150
            .Visible = True
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
            .Caption = "PC"
            '.CellStyle.BackColor = Color.Gold
        End With
        With grdetalle.RootTable.Columns("DEVOLUCION")
            .Width = 150
            .Visible = False
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
            .Caption = "DEVOLUCION"
        End With
        With grdetalle.RootTable.Columns("TOTAL")
            .Width = 150
            .Visible = True
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
            .Caption = "TOTAL PEDIDOS"
            .CellStyle.BackColor = Color.CadetBlue
        End With
        With grdetalle.RootTable.Columns("TOTAL_ENTREGADO")
            .Width = 150
            .Visible = True
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
            .Caption = "TOTAL ENTREGADO"
            .CellStyle.BackColor = Color.CadetBlue
        End With
        With grdetalle.RootTable.Columns("TOTALCOPIA")
            .Width = 150
            .Visible = False
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With

        With grdetalle.RootTable.Columns("img")
            .Width = 80
            .Caption = "ESTADO".ToUpper
            .CellStyle.ImageHorizontalAlignment = ImageHorizontalAlignment.Center
            .Visible = True
        End With
        With grdetalle
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
            .RootTable.RowHeight = 30

        End With
    End Sub


    Public Sub _prCargarIcono(dt As DataTable)
        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            If (dt.Rows(i).Item("TOTAL") = dt.Rows(i).Item("TOTAL_ENTREGADO")) Then
                dt.Rows(i).Item("img") = _fnBytesArchivo(My.Resources.checked, 20, 20)

            Else
                dt.Rows(i).Item("img") = _fnBytesArchivo(My.Resources.cancel, 20, 20)
            End If

        Next
    End Sub

    Private Function _fnBytesArchivo(img As Bitmap, ancho As Integer, alto As Integer) As Object
        Bin = New MemoryStream()
        Dim img2 As New Bitmap(img, ancho, alto)
        img2.Save(Bin, System.Drawing.Imaging.ImageFormat.Png)
        Return Bin.ToArray()
    End Function
    Private Sub _prAsignarPermisos()
        Dim dtRolUsu() As DataRow = L_prRolDetalleGeneral(gi_userRol).Select("yaprog='" + _nameButton + "'")

        If (dtRolUsu.Count = 1) Then
            boShow = dtRolUsu(0).Item("ycshow")
            boAdd = dtRolUsu(0).Item("ycadd")
            boModif = dtRolUsu(0).Item("ycmod")
            boDel = dtRolUsu(0).Item("ycdel")
        End If

        If boAdd = False Then
            btnNuevo.Visible = False
        End If
        If boModif = False Then
            btnModificar.Visible = False
        End If
        If boDel = False Then
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub _prInhabiliitar()
        TbCodigo.ReadOnly = True
        tbchofer.ReadOnly = True
        tbFecha.IsInputReadOnly = True

        ''''''''''
        btnModificar.Enabled = True
        btnGrabar.Enabled = False
        btnNuevo.Enabled = True
        btnEliminar.Enabled = True

        btBuscarChofer.Enabled = False

        GridEX1.Enabled = True

        grtotalpedidos.AllowEdit = InheritableBoolean.False

        tbdRecibido.IsInputReadOnly = True
        tbdSaldo.IsInputReadOnly = True
    End Sub

    Private Sub _prhabilitar()
        TbCodigo.ReadOnly = True
        tbchofer.ReadOnly = False
        tbFecha.IsInputReadOnly = False
        ''  tbCliente.ReadOnly = False  por que solo podra seleccionar Cliente
        ''  tbVendedor.ReadOnly = False

        btnGrabar.Enabled = True

        btBuscarChofer.Enabled = True

        GridEX1.Enabled = False

        grtotalpedidos.AllowEdit = InheritableBoolean.True

        tbdRecibido.IsInputReadOnly = False
    End Sub

    Public Sub _prFiltrar()
        'cargo el buscador
        Dim _Mpos As Integer
        _prCargarVenta()
        If GridEX1.RowCount > 0 Then
            _Mpos = 0
            GridEX1.Row = _Mpos
        Else
            _Limpiar()
            LblPaginacion.Text = "0/0"
        End If
    End Sub
    Private Sub _Limpiar()
        TbCodigo.Clear()
        tbchofer.Clear()
        tbFecha.Value = Now.Date
        _prCargarDetalleVenta(-1)
        Numi_Chofer = 0
        Numi_Conciliacion = 0



        lbconciliacion.Text = 0
        tbchofer.Focus()
        tbdRecibido.Value = 0
        tbdSaldo.Value = 0
    End Sub


    Public Sub _prMostrarRegistro(_N As Integer)
        'olnumi , olnumichof, chofer, olnumiconci, olfecha, olfact, olhact, oluact
        With GridEX1
            TbCodigo.Text = .GetValue("olnumi")
            tbFecha.Value = .GetValue("olfecha")
            Numi_Chofer = .GetValue("olnumichof")
            Numi_Conciliacion = .GetValue("olnumiconci")
            tbchofer.Text = .GetValue("chofer")
            lbconciliacion.Text = .GetValue("olnumiconci")
            lbFecha.Text = CType(.GetValue("olfact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("olhact").ToString
            lbUsuario.Text = .GetValue("oluact").ToString
        End With

        _prCargarDetalleVenta(TbCodigo.Text)
        _prCrearTablaConciliacion()

        tbdRecibido.Value = GridEX1.GetValue("olmrec")

        LblPaginacion.Text = Str(GridEX1.Row + 1) + "/" + GridEX1.RowCount.ToString

    End Sub

    Private Sub P_prArmarAyudaConciliacion()
        Dim dt As DataTable

        dt = L_prListarConciliacion()
        'a.ibid ,a.ibfdoc ,a.ibconcep ,C.cbnumi as idchofer ,c.cbdesc as chofer

        Dim listEstCeldas As New List(Of Modelo.MCelda)
        listEstCeldas.Add(New Modelo.MCelda("ibid", True, "CONCILIACION", 120))
        listEstCeldas.Add(New Modelo.MCelda("ibfdoc", True, "Fecha", 220, "yyyy/MM/dd"))
        listEstCeldas.Add(New Modelo.MCelda("ibconcep", False))
        listEstCeldas.Add(New Modelo.MCelda("idchofer", False))
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

            lbconciliacion.Text = Row.Cells("ibid").Value
            Numi_Conciliacion = Row.Cells("ibid").Value
            tbchofer.Text = Row.Cells("chofer").Value
            Numi_Chofer = Row.Cells("idchofer").Value
        End If
    End Sub

    Public Function _fnAccesible()
        Return tbFecha.IsInputReadOnly = False
    End Function
    Private Sub _prCargarDetalleVenta(_numi As String)
        Dim dt As New DataTable

        dt = L_prObtenerDetalleDeCaja(_numi)
        grtotalpedidos.DataSource = dt
        grtotalpedidos.RetrieveStructure()
        grtotalpedidos.AlternatingColors = True
        'oanumi , oafdoc, oaccli, cliente, oarepa, oaest, oaap, oapg, total,contado,credito, estado
        With grtotalpedidos.RootTable.Columns("oanumi")
            .Width = 100
            .Caption = "CODIGO"
            .Visible = False
        End With
        With grtotalpedidos.RootTable.Columns("oafdoc")
            .Width = 90
            .Visible = False
        End With
        With grtotalpedidos.RootTable.Columns("oaest")
            .Width = 90
            .Visible = False
        End With
        With grtotalpedidos.RootTable.Columns("oaap")
            .Width = 90
            .Visible = False
        End With
        With grtotalpedidos.RootTable.Columns("oapg")
            .Width = 90
            .Visible = False
        End With


        With grtotalpedidos.RootTable.Columns("oaccli")
            .Width = 120
            .Caption = ""
            .Visible = False
        End With

        With grtotalpedidos.RootTable.Columns("cliente")
            .Caption = "CLIENTE"
            .Width = 400
            .Visible = True
        End With
        With grtotalpedidos.RootTable.Columns("total")
            .Caption = "TOTAL"
            .Width = 120
            .AggregateFunction = AggregateFunction.Sum
            .Visible = True
            .FormatString = "0.00"
        End With
        With grtotalpedidos.RootTable.Columns("contado")
            .Caption = "CONTADO"
            .Width = 120
            .AggregateFunction = AggregateFunction.Sum
            .Visible = True
            .FormatString = "0.00"
        End With
        With grtotalpedidos.RootTable.Columns("credito")
            .Caption = "CREDITO"
            .Width = 120
            .AggregateFunction = AggregateFunction.Sum
            .Visible = (gi_vcre2 = 1)
            .FormatString = "0.00"
        End With
        With grtotalpedidos.RootTable.Columns("oarepa")
            .Width = 160
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With grtotalpedidos.RootTable.Columns("tcre")
            .Visible = False
        End With
        With grtotalpedidos.RootTable.Columns("estado")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With

        With grtotalpedidos
            .GroupByBoxVisible = False
            'diseño de la grilla
            .TotalRow = InheritableBoolean.True
            .TotalRowFormatStyle.BackColor = Color.Gold
            .TotalRowPosition = TotalRowPosition.BottomFixed
            .VisualStyle = VisualStyle.Office2007

            Dim fc As GridEXFormatCondition = New GridEXFormatCondition(.RootTable.Columns("tcre"), ConditionOperator.Equal, "1")
            fc.FormatStyle.BackColor = Color.LightSalmon

            .RootTable.FormatConditions.Add(fc)
        End With


    End Sub

    Public Sub cargarDetalleConciliacion()
        Dim dt As New DataTable

        dt = L_prObtenerDetalleChofer(Numi_Chofer, tbFecha.Value.ToString("yyyy/MM/dd"))
        grtotalpedidos.DataSource = dt
        grtotalpedidos.RetrieveStructure()
        grtotalpedidos.AlternatingColors = True
        'oanumi , oafdoc, oaccli, cliente, oarepa, oaest, oaap, oapg, total,contado,credito, estado
        With grtotalpedidos.RootTable.Columns("oanumi")
            .Width = 100
            .Caption = "CODIGO"
            .Visible = False
        End With
        With grtotalpedidos.RootTable.Columns("oafdoc")
            .Width = 90
            .Visible = False
        End With
        With grtotalpedidos.RootTable.Columns("oaest")
            .Width = 90
            .Visible = False
        End With
        With grtotalpedidos.RootTable.Columns("oaap")
            .Width = 90
            .Visible = False
        End With
        With grtotalpedidos.RootTable.Columns("oapg")
            .Width = 90
            .Visible = False
        End With


        With grtotalpedidos.RootTable.Columns("oaccli")
            .Width = 120
            .Caption = ""
            .Visible = False
        End With

        With grtotalpedidos.RootTable.Columns("cliente")
            .Caption = "CLIENTE"
            .Width = 400
            .Visible = True
        End With
        With grtotalpedidos.RootTable.Columns("total")
            .Caption = "TOTAL"
            .Width = 120
            .Visible = True
            .FormatString = "0.00"
            .AggregateFunction = AggregateFunction.Sum
        End With
        With grtotalpedidos.RootTable.Columns("contado")
            .Caption = "CONTADO"
            .Width = 120
            .Visible = True
            .FormatString = "0.00"
            .AggregateFunction = AggregateFunction.Sum
        End With
        With grtotalpedidos.RootTable.Columns("credito")
            .Caption = "CREDITO"
            .Width = 120
            .Visible = (gi_vcre2 = 1)
            .FormatString = "0.00"
            .AggregateFunction = AggregateFunction.Sum
        End With
        With grtotalpedidos.RootTable.Columns("oarepa")
            .Width = 160
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With grtotalpedidos.RootTable.Columns("tcre")
            .Visible = False
        End With
        With grtotalpedidos.RootTable.Columns("estado")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With

        With grtotalpedidos
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
            .TotalRow = InheritableBoolean.True
            .TotalRowFormatStyle.BackColor = Color.Gold
            .TotalRowPosition = TotalRowPosition.BottomFixed

            Dim fc As GridEXFormatCondition = New GridEXFormatCondition(.RootTable.Columns("tcre"), ConditionOperator.Equal, "1")
            fc.FormatStyle.BackColor = Color.LightSalmon

            .RootTable.FormatConditions.Add(fc)
        End With
    End Sub

    Private Sub _prCargarVenta()
        Dim dt As New DataTable
        dt = L_prCajaGeneral()
        GridEX1.DataSource = dt
        GridEX1.RetrieveStructure()
        GridEX1.AlternatingColors = True

        'olnumi , olnumichof, chofer, olnumiconci, olfecha, olfact, olhact, oluact
        With GridEX1.RootTable.Columns("olnumi")
            .Width = 100
            .Caption = "CODIGO"
            .Visible = True

        End With

        With GridEX1.RootTable.Columns("olnumichof")
            .Width = 90
            .Visible = False
        End With

        With GridEX1.RootTable.Columns("chofer")
            .Width = 350
            .Visible = True
            .Caption = "CHOFER"
        End With

        With GridEX1.RootTable.Columns("olnumiconci")
            .Width = 150
            .Visible = True
            .Caption = "CONCILIACION"
        End With

        With GridEX1.RootTable.Columns("olfecha")
            .Width = 120
            .Visible = True
            .Caption = "FECHA"
            .FormatString = "dd/MM/yyyy"
        End With

        With GridEX1.RootTable.Columns("olmrec")
            .Width = 100
            .Visible = True
            .Caption = "MONTO RECIBIDO"
            .FormatString = "0.00"
        End With

        With GridEX1.RootTable.Columns("olfact")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With

        With GridEX1.RootTable.Columns("olhact")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With

        With GridEX1.RootTable.Columns("oluact")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With

        With GridEX1
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

    Public Sub _fnObtenerFilaDetalle(ByRef pos As Integer, numi As Integer)
        For i As Integer = 0 To CType(grtotalpedidos.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim _numi As Integer = CType(grtotalpedidos.DataSource, DataTable).Rows(i).Item("oanumi")
            If (_numi = numi) Then
                pos = i
                Return
            End If
        Next

    End Sub
    Private Sub _prSalir()
        If btnGrabar.Enabled = True Then
            _prInhabiliitar()
            If GridEX1.RowCount > 0 Then
                _prMostrarRegistro(0)
            End If
            btnSalir.Text = "SALIR"
        Else
            Me.Close()
            _modulo.Select()
            _tab.Close()
        End If
    End Sub
    Public Sub _PrimerRegistro()
        Dim _MPos As Integer
        If GridEX1.RowCount > 0 Then
            _MPos = 0
            ''   _prMostrarRegistro(_MPos)
            GridEX1.Row = _MPos
        End If
    End Sub

    Public Function _fnValidarTotal()As Boolean
        'TablaPrincipal.Columns.Add("ID_TO1", Type.GetType("System.String"))
        'TablaPrincipal.Columns.Add("DEVOLUCION")
        'TablaPrincipal.Columns.Add("TOTAL")
        'TablaPrincipal.Columns.Add("MOVIL")
        'TablaPrincipal.Columns.Add("PC")
        'TablaPrincipal.Columns.Add("TOTAL_ENTREGADO")
        'TablaPrincipal.Columns.Add("TOTALCOPIA")
        'TablaPrincipal.Columns.Add("estado")
        'TablaPrincipal.Columns.Add("icid")

        Dim dt As DataTable = CType(grdetalle.DataSource, DataTable)
        For i As Integer = 0 To dt.Rows.Count - 1 Step 1

            Dim totalSacado As Double = dt.Rows(i).Item("TOTAL")
            Dim TotalEntregado As Double = dt.Rows(i).Item("TOTAL_ENTREGADO")
            If (totalSacado <> TotalEntregado) Then


                Return False
            End If
        Next
        Return True
    End Function
    Public Function _ValidarCampos() As Boolean
        If (Numi_Chofer <= 0) Then
            Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
            ToastNotification.Show(Me, "Por Favor Seleccione un Chofer con Ctrl+Enter".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            tbchofer.Focus()
            Return False

        End If
        If (_fnValidarTotal() = False) Then
            Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
            ToastNotification.Show(Me, "ERROR:  LA CANTIDAD DE PRODUCTO SACADOS ES DISTINTO A LOS VENDIDOS ".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            Return False
        End If

        Return True
    End Function
#End Region
    Private Sub tbchofer_KeyDown(sender As Object, e As KeyEventArgs) Handles tbchofer.KeyDown
        If (_fnAccesible()) Then
            If e.KeyData = Keys.Control + Keys.Enter Then
                P_BuscarChofer()
            End If
        End If
    End Sub

    Private Sub P_BuscarChofer()
        P_prArmarAyudaConciliacion()
        cargarDetalleConciliacion()
        _prCrearTablaConciliacion()
    End Sub

    Private Sub F0_Caja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _IniciarTodo()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        _Limpiar()
        _prhabilitar()

        btnNuevo.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnGrabar.Enabled = True

        tbchofer.Select()
        btnSalir.Text = "CANCELAR"
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        _prSalir()
    End Sub
    Public Sub _GuardarNuevo()

        'ByRef _olnumi As String, _olnumichof As String, _olnumiconci As Integer, _olfecha As String, _dt As DataTable
        Dim numi As String = ""

        Dim res As Boolean = L_prCajaGrabar(numi, Numi_Chofer, Numi_Conciliacion, tbFecha.Value.ToString("yyyy/MM/dd"), tbdRecibido.Value.ToString, CType(grtotalpedidos.DataSource, DataTable))

        If res Then

            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Caja ".ToUpper + TbCodigo.Text + " Grabado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter
                                      )

            _prCargarVenta()
            _Limpiar()

        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "La Compra no pudo ser insertado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

        End If

    End Sub
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If _ValidarCampos() = False Then
            Exit Sub
        End If
        If (TbCodigo.Text = String.Empty) Then
            _GuardarNuevo()
        Else
            If (TbCodigo.Text <> String.Empty) Then
                '_prGuardarModificado()
            End If
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        _prhabilitar()
        btnNuevo.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnGrabar.Enabled = True


        tbchofer.Select()
        btnSalir.Text = "CANCELAR"
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        If (GridEX1.RowCount > 0) Then
            Dim ef = New Efecto

            ef.tipo = 2
            ef.Context = "¿esta seguro de eliminar el registro?".ToUpper
            ef.Header = "mensaje principal".ToUpper
            ef.ShowDialog()
            Dim bandera As Boolean = False
            bandera = ef.band
            If (bandera = True) Then
                Dim mensajeError As String = ""
                Dim res As Boolean = L_fnCajaEliminar(TbCodigo.Text, CType(grtotalpedidos.DataSource, DataTable))
                If res Then


                    Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)

                    ToastNotification.Show(Me, "Código de Caja ".ToUpper + TbCodigo.Text + " eliminado con Exito.".ToUpper,
                                              img, 2000,
                                              eToastGlowColor.Green,
                                              eToastPosition.TopCenter)

                    _prFiltrar()

                Else
                    Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                    ToastNotification.Show(Me, mensajeError, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                End If
            End If
        End If


    End Sub

    Private Sub GridEX1_SelectionChanged(sender As Object, e As EventArgs) Handles GridEX1.SelectionChanged
        If (GridEX1.RowCount >= 0 And GridEX1.Row >= 0) Then

            _prMostrarRegistro(GridEX1.Row)
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Dim _pos As Integer = GridEX1.Row
        If _pos < GridEX1.RowCount - 1 Then
            _pos = GridEX1.Row + 1
            '' _prMostrarRegistro(_pos)
            GridEX1.Row = _pos
        End If
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Dim _pos As Integer = GridEX1.Row
        If GridEX1.RowCount > 0 Then
            _pos = GridEX1.RowCount - 1
            ''  _prMostrarRegistro(_pos)
            GridEX1.Row = _pos
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Dim _MPos As Integer = GridEX1.Row
        If _MPos > 0 And GridEX1.RowCount > 0 Then
            _MPos = _MPos - 1
            ''  _prMostrarRegistro(_MPos)
            GridEX1.Row = _MPos
        End If
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        _PrimerRegistro()
    End Sub

    Private Sub grtotalpedidos_KeyDown(sender As Object, e As KeyEventArgs) Handles grtotalpedidos.KeyDown

        If (e.KeyData = Keys.Control + Keys.Enter And grtotalpedidos.Row >= 0) Then

            P_prArmarDetallePedido(grtotalpedidos.GetValue("oanumi"))



        End If


    End Sub
    Private Sub P_prArmarDetallePedido(numi As Integer)
        Dim dt As DataTable

        dt = L_prVerDetallePedido(numi)
        'detalle.obcprod ,producto .cadesc ,detalle .obpbase ,detalle .obpcant ,detalle .obptot 

        Dim listEstCeldas As New List(Of Modelo.MCelda)
        listEstCeldas.Add(New Modelo.MCelda("obcprod", True, "CODIGO", 120))
        listEstCeldas.Add(New Modelo.MCelda("cadesc", True, "PRODUCTO", 250))
        listEstCeldas.Add(New Modelo.MCelda("obpbase", True, "PRECIO", 100))
        listEstCeldas.Add(New Modelo.MCelda("obpcant", True, "CANTIDAD", 100))
        listEstCeldas.Add(New Modelo.MCelda("obptot", True, "total".ToUpper, 100))


        Dim ef = New Efecto
        ef.tipo = 3
        ef.dt = dt
        ef.SeleclCol = 2
        ef.listEstCeldas = listEstCeldas
        ef.alto = 50
        ef.ancho = 350
        ef.Context = "detalle de pedido".ToUpper
        ef.ShowDialog()
        Dim bandera As Boolean = False
        bandera = ef.band
        If (bandera = True) Then

            ''a.ibid ,a.ibfdoc ,a.ibconcep ,a.ibconcep ,c.cbdesc as chofer
            'Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row

            'lbconciliacion.Text = Row.Cells("ibid").Value
            'Numi_Conciliacion = Row.Cells("ibid").Value
            'tbchofer.Text = Row.Cells("chofer").Value
            'Numi_Chofer = Row.Cells("idchofer").Value
        End If
    End Sub


    Function F_GenerarTablaProductoReporte() As DataTable
        Dim dt As DataTable = CType(grdetalle.DataSource, DataTable)
        Dim TablaPrincipal As DataTable = New DataTable
        'Select Case'Hielo de 35 kg' AS producto, 20 AS totalpedidos, 10 AS movil, 10 AS pc, 20 AS totalentregado
        TablaPrincipal.Columns.Add("producto", Type.GetType("System.String"))
        TablaPrincipal.Columns.Add("totalpedidos", Type.GetType("System.Int32"))
        TablaPrincipal.Columns.Add("movil", Type.GetType("System.Int32"))
        TablaPrincipal.Columns.Add("pc", Type.GetType("System.Int32"))
        TablaPrincipal.Columns.Add("totalentregado", Type.GetType("System.Int32"))
        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            TablaPrincipal.Rows.Add()
            Dim n As Integer = TablaPrincipal.Rows.Count - 1
            TablaPrincipal.Rows(n).Item("producto") = CType(grdetalle.DataSource, DataTable).Rows(i).Item("cadesc")
            TablaPrincipal.Rows(n).Item("totalpedidos") = CType(grdetalle.DataSource, DataTable).Rows(i).Item("TOTAL")


            If (CType(grdetalle.DataSource, DataTable).Rows(i).Item("MOVIL").ToString.Equals("")) Then
                TablaPrincipal.Rows(n).Item("movil") = 0
            Else
                TablaPrincipal.Rows(n).Item("movil") = CInt(CType(grdetalle.DataSource, DataTable).Rows(i).Item("MOVIL"))
            End If


            If (CType(grdetalle.DataSource, DataTable).Rows(i).Item("PC").ToString.Equals("")) Then
                TablaPrincipal.Rows(n).Item("pc") = 0
            Else
                TablaPrincipal.Rows(n).Item("pc") = CInt(CType(grdetalle.DataSource, DataTable).Rows(i).Item("PC"))
            End If


            TablaPrincipal.Rows(n).Item("totalentregado") = CType(grdetalle.DataSource, DataTable).Rows(i).Item("TOTAL_ENTREGADO")

        Next

        Return TablaPrincipal

    End Function

    Private Sub P_GenerarReporte()
        Dim dtProducto As DataTable = F_GenerarTablaProductoReporte()
        Dim dtCliente As DataTable = CType(grtotalpedidos.DataSource, DataTable)


        If Not IsNothing(P_Global.Visualizador) Then
            P_Global.Visualizador.Close()
        End If

        P_Global.Visualizador = New Visualizador
        Dim objrep As New R_CajaGeneral
        objrep.Subreports.Item("R_CajaProducto.rpt").SetDataSource(dtProducto)
        objrep.Subreports.Item("R_CajaCliente.rpt").SetDataSource(dtCliente)
        objrep.SetDataSource(dtCliente)
        objrep.SetParameterValue("idcaja", TbCodigo.Text)
        objrep.SetParameterValue("chofer", tbchofer.Text)
        objrep.SetParameterValue("conciliacion", lbconciliacion.Text)
        objrep.SetParameterValue("usuario", L_Usuario)
        objrep.SetParameterValue("fecha", tbFecha.Text)

        P_Global.Visualizador.CRV1.ReportSource = objrep
        P_Global.Visualizador.Show()
        P_Global.Visualizador.BringToFront()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If (TbCodigo.Text.Trim <> String.Empty) Then
            P_GenerarReporte()
        End If
    End Sub

    Private Sub grtotalpedidos_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grtotalpedidos.EditingCell
        If (e.Column.Key = "credito") Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub grtotalpedidos_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles grtotalpedidos.CellEdited
        If (e.Column.Key = "credito") Then
            If (Not IsNumeric(grtotalpedidos.GetValue("credito"))) Then
                grtotalpedidos.SetValue("credito", 0)
            Else
                If (grtotalpedidos.GetValue("credito") < 0) Then
                    grtotalpedidos.SetValue("credito", 0)
                End If
                If (grtotalpedidos.GetValue("credito") > grtotalpedidos.GetValue("contado")) Then
                    grtotalpedidos.SetValue("credito", grtotalpedidos.GetValue("contado"))
                End If
                grtotalpedidos.SetValue("contado", grtotalpedidos.GetValue("total") - grtotalpedidos.GetValue("credito"))
            End If

        End If
    End Sub

    Private Sub btBuscarChofer_Click(sender As Object, e As EventArgs) Handles btBuscarChofer.Click
        P_BuscarChofer()
    End Sub

    Private Sub tbdRecibido_ValueChanged(sender As Object, e As EventArgs) Handles tbdRecibido.ValueChanged
        tbdSaldo.Value = IIf(IsDBNull(CType(grtotalpedidos.DataSource, DataTable).Compute("sum(total)", "1=1")), 0, CType(grtotalpedidos.DataSource, DataTable).Compute("sum(total)", "1=1")) - tbdRecibido.Value
    End Sub
End Class