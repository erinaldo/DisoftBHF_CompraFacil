Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports Entidades
Imports DevComponents.DotNetBar.Controls

Public Class F02_Pedido

#Region "Variables"
    'Dim _Dsencabezado As DataSet
    Dim _Pos As Integer
    Dim _Nuevo As Boolean
    Public _nuevoBasePeriodico As Boolean

    Dim _ClientePasivo

    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

#End Region

#Region "Metodos Privados"
    Private Sub _PIniciarTodo()
        'L_prAbrirConexion()

        Me.Text = "P E D I D O S"
        Me.WindowState = FormWindowState.Maximized
        MSuperTabControlPrincipal.SelectedTabIndex = 0

        P_prArmarCombos()

        _PCargarGridClientes()
        _PCargarGridTiposProd()
        _PCargarGridDetalle(-1)
        _PCargarBuscador()

        _PFiltrar()
        _PInhabilitar()

        'Habilitar pedido por frecuencia
        _PHabilitarPedidoConFrecuencia()

        'activar los permisos del rol
        _pCambiarFuente()
        _PAsignarPermisos()

        tbFechaDel.Value = Now.Date
        tbFechaAl.Value = Now.Date
    End Sub
    Private Sub _pCambiarFuente()
        Dim fuente As New Font("Tahoma", gi_fuenteTamano, FontStyle.Regular)
        Dim xCtrl As Control
        For Each xCtrl In PanelEx3.Controls
            Try
                xCtrl.Font = fuente
            Catch ex As Exception
            End Try
        Next

        For Each xCtrl In PanelEx4.Controls
            Try
                xCtrl.Font = fuente
            Catch ex As Exception
            End Try
        Next

        For Each xCtrl In GroupPanel2.Controls
            Try
                xCtrl.Font = fuente
            Catch ex As Exception
            End Try
        Next

        For Each xCtrl In GroupPanel2.Controls
            Try
                xCtrl.Font = fuente
            Catch ex As Exception
            End Try
        Next
        For Each xCtrl In GroupPanel3.Controls
            Try
                xCtrl.Font = fuente
            Catch ex As Exception
            End Try
        Next
        For Each xCtrl In GroupPanel4.Controls
            Try
                xCtrl.Font = fuente
            Catch ex As Exception
            End Try
        Next
        For Each xCtrl In PanelEx9.Controls
            Try
                xCtrl.Font = fuente
            Catch ex As Exception
            End Try
        Next


        Tb_DireccionDetalle.Font = fuente
        JGr_Clientes.Font = fuente
        GroupPanel3.Font = fuente
        GroupPanel4.Font = fuente
        GroupPanel5.Font = fuente
        GroupPanel6.Font = fuente
        JGr_Buscador.Font = fuente
    End Sub
    Private Sub _PAsignarPermisos()
        Dim dtRolUsu() As DataRow = L_prRolDetalleGeneral(gi_userRol).Select("yaprog='" + _nameButton + "'")

        Dim show As Boolean = False
        Dim add As Boolean = False
        Dim modif As Boolean = False
        Dim del As Boolean = False

        If (dtRolUsu.Count = 1) Then
            show = dtRolUsu(0).Item("ycshow")
            add = dtRolUsu(0).Item("ycadd")
            modif = dtRolUsu(0).Item("ycmod")
            del = dtRolUsu(0).Item("ycdel")
        End If

        If add = False Then
            MBtNuevo.Visible = False
        End If
        If modif = False Then
            MBtModificar.Visible = False
        End If
        If del = False Then
            MBtEliminar.Visible = False
        End If
    End Sub

    Private Sub _PHabilitarPedidoConFrecuencia()
        If _nuevoBasePeriodico = True Then
            Tb_Estado.Visible = True
            Lb_Estado.Visible = True
            Me.Text = "P E D I D O S     P E R I O D I C O"
            GrPan_PeriodoPedido.Style.BackColor = Color.LightGreen
            GrPan_PeriodoPedido.Style.BackColor2 = Color.LightGreen

            GrPan_PeriodoPedido.Visible = True
            PaFrecEnDias.Visible = False
            Btn_Check1.PerformClick()
        Else
            Tb_Estado.Visible = False
            Lb_Estado.Visible = False
            GrPan_PeriodoPedido.Visible = False
            Btn_GenerarPedidos.Visible = False
        End If

    End Sub

    Private Sub _PCargarBuscador(Optional where As String = "")

        JGr_Buscador.BoundMode = BoundMode.Bound
        If _nuevoBasePeriodico = True Then
            JGr_Buscador.DataSource = L_PedidoCabecera_General_Pedido(-1, " AND oaest=10" + where)
        Else
            JGr_Buscador.DataSource = L_PedidoCabecera_GeneralTOPN(-1, " AND oaest<>10" + where, 100)
        End If
        JGr_Buscador.RetrieveStructure()

        'dar formato a las columnas

        With JGr_Buscador.RootTable.Columns("oanumi")
            .Caption = "Codigo".ToUpper
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Buscador.RootTable.Columns("oafdoc")
            .Caption = "Fecha".ToUpper
            .Width = 90
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Buscador.RootTable.Columns("oahora")
            .Caption = "Hora".ToUpper
            .Width = 90
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Buscador.RootTable.Columns("oaccli")
            .Caption = "Cod. cli.".ToUpper
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Buscador.RootTable.Columns("ccdesc")
            .Caption = "Cliente".ToUpper
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With

        With JGr_Buscador.RootTable.Columns("ccdirec")
            .Caption = "direccion".ToUpper
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With

        With JGr_Buscador.RootTable.Columns("cctelf1")
            .Caption = "telefono".ToUpper
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Buscador.RootTable.Columns("cccat")
            .Visible = False
        End With

        With JGr_Buscador.RootTable.Columns("oazona")
            .Caption = "cod. zona".ToUpper
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Buscador.RootTable.Columns("cedesc")
            .Caption = "zona".ToUpper
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With

        With JGr_Buscador.RootTable.Columns("oaobs")
            .Caption = "observacion".ToUpper
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With

        With JGr_Buscador.RootTable.Columns("oaobs2")
            .Visible = False
        End With

        With JGr_Buscador.RootTable.Columns("oaest")
            .Visible = False
        End With

        With JGr_Buscador.RootTable.Columns("cclat")
            .Visible = False
        End With

        With JGr_Buscador.RootTable.Columns("cclongi")
            .Visible = False
        End With

        With JGr_Buscador.RootTable.Columns("cclongi")
            .Visible = False
        End With
        With JGr_Buscador.RootTable.Columns("oaap")
            .Visible = False
        End With
        With JGr_Buscador.RootTable.Columns("oapg")
            .Visible = False
        End With
        With JGr_Buscador.RootTable.Columns("ccultvent")
            .Visible = False
        End With
        With JGr_Buscador.RootTable.Columns("oarepa")
            .Visible = False
        End With
        With JGr_Buscador.RootTable.Columns("oaanumiprev")
            .Visible = False
        End With

        JGr_Buscador.ContextMenuStrip = ConMenu_Buscador

        'Habilitar Filtradores
        With JGr_Buscador
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
        End With

        'diseño de la grilla
        JGr_Buscador.VisualStyle = VisualStyle.Office2007
    End Sub
    Private Sub _PCargarGridDetalle(idCabecera As Integer)
        Dim dtProd, dtCatPrecios As New DataTable
        dtProd = L_PedidoDetalle_General(-1, idCabecera)

        JGr_DetallePedido.BoundMode = BoundMode.Bound
        JGr_DetallePedido.DataSource = dtProd
        JGr_DetallePedido.RetrieveStructure()

        'dar formato a las columnas
        With JGr_DetallePedido.RootTable.Columns(0)
            .Visible = False
        End With

        With JGr_DetallePedido.RootTable.Columns(1)
            .Caption = "Codigo"
            .Key = "CodProd"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_DetallePedido.RootTable.Columns(2)
            .Caption = "Descripcion"
            .Key = "Descripcion"
            .Width = 350
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With

        With JGr_DetallePedido.RootTable.Columns(3)
            .Caption = "Cantidad"
            .Key = "Cantidad"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .FormatString = "0.00"
        End With
        With JGr_DetallePedido.RootTable.Columns(4)
            .Caption = "Precio"
            .Key = "Precio"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .FormatString = "0.00"
        End With
        With JGr_DetallePedido.RootTable.Columns(5)
            .Caption = "Monto Bs."
            .Key = "Monto"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .FormatString = "0.00"
            .AggregateFunction = AggregateFunction.Sum
        End With

        'Habilitar Filtradores
        With JGr_DetallePedido
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .TotalRow = InheritableBoolean.True
            .TotalRowFormatStyle.BackColor = Color.Gold
            .TotalRowPosition = TotalRowPosition.BottomFixed
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
        End With

    End Sub

    Private Sub _PCargarGridTiposProd()
        Dim dtProd, dtCatPrecios As New DataTable
        dtProd = L_General_LibreriaDetalleProductos(-1, 5).Tables(0)

        JGr_TipoProd.BoundMode = BoundMode.Bound
        JGr_TipoProd.DataSource = dtProd
        JGr_TipoProd.RetrieveStructure()

        'dar formato a las columnas
        With JGr_TipoProd.RootTable.Columns(0)
            .Visible = False
        End With
        With JGr_TipoProd.RootTable.Columns(1)
            .Visible = False
        End With

        With JGr_TipoProd.RootTable.Columns(2)
            .Caption = "Codigo"
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_TipoProd.RootTable.Columns(3)
            .Caption = "Descripcion"
            .Width = 250
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With

        'Habilitar Filtradores
        With JGr_TipoProd
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
        End With

        'diseño de la grilla
        JGr_TipoProd.VisualStyle = VisualStyle.Office2007
    End Sub
    Private Sub _PCargarGridProductos(idTipProd As Integer, idCatCli As Integer)
        Dim dtProd, dtCatPrecios As New DataTable
        If gi_mprec = 0 Then
            dtProd = L_ProductosPedido_General(-1, idTipProd, idCatCli, "IIF(cacod='5',1,100)")
        Else
            dtProd = L_ProductosPedido_General2(-1, idTipProd, idCatCli, "IIF(cacod='5',1,100)", Tb_CliCod.Text)

            Dim dtProd2 As DataTable = L_ProductosPedido_General(-1, idTipProd, idCatCli, "IIF(cacod='5',1,100)")
            For Each fila As DataRow In dtProd2.Rows
                Dim filasSelect As DataRow() = dtProd.Select("canumi=" + fila.Item("canumi").ToString)
                If filasSelect.Count = 0 Then
                    dtProd.ImportRow(fila)
                End If
            Next
        End If

        JGr_Productos.BoundMode = BoundMode.Bound
        JGr_Productos.DataSource = dtProd
        JGr_Productos.RetrieveStructure()

        'dar formato a las columnas

        With JGr_Productos.RootTable.Columns(0)
            .Caption = "Codigo"
            .Key = "Codigo"
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Productos.RootTable.Columns(1)
            .Caption = "Descripcion"
            .Key = "Descripcion"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With

        With JGr_Productos.RootTable.Columns(2)
            .Caption = "Precio"
            .Key = "Precio"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .FormatString = "0.00"
        End With
        With JGr_Productos.RootTable.Columns(3)
            .Visible = False
        End With
        With JGr_Productos.RootTable.Columns(4)
            .Visible = False
        End With
        With JGr_Productos.RootTable.Columns(5)
            .Visible = False
        End With


        'añadir columna de imagenes
        'JGr_Productos.RootTable.Columns.Add("Imagenes", ColumnType.Image)
        'With JGr_Productos.RootTable.Columns(8)
        '    .Visible = True
        '    .
        'End With
        'For i = 0 To JGr_Productos.RowCount - 1
        '    JGr_Productos.Row = i
        '    JGr_Productos.CurrentRow.Cells("Imagenes").Image = My.Resources.EDITAR
        'Next


        'Habilitar Filtradores
        With JGr_Productos
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
        End With

        'diseño de la grilla
        JGr_Productos.VisualStyle = VisualStyle.Office2007
    End Sub

    Private Sub _PCargarGridProductos2(idTipProd As Integer, idCatCli As Integer)
        Dim dtProd, dtCatPrecios As New DataTable
        dtProd = L_ProductosPedido_General(-1, idTipProd, idCatCli)

        JGr_Productos.BoundMode = BoundMode.Bound
        JGr_Productos.DataSource = dtProd
        JGr_Productos.RetrieveStructure()

        'dar formato a las columnas

        With JGr_Productos.RootTable.Columns(0)
            .Caption = "Codigo"
            .Key = "Codigo"
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Productos.RootTable.Columns(1)
            .Caption = "Descripcion"
            .Key = "Descripcion"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With

        With JGr_Productos.RootTable.Columns(2)
            .Caption = "Precio"
            .Key = "Precio"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With
        With JGr_Productos.RootTable.Columns(3)
            .Visible = False
        End With
        With JGr_Productos.RootTable.Columns(4)
            .Visible = False
        End With

        'añadir columna de imagenes
        'JGr_Productos.RootTable.Columns.Add("Imagenes", ColumnType.Image)
        'With JGr_Productos.RootTable.Columns(8)
        '    .Visible = True
        '    .
        'End With
        'For i = 0 To JGr_Productos.RowCount - 1
        '    JGr_Productos.Row = i
        '    JGr_Productos.CurrentRow.Cells("Imagenes").Image = My.Resources.EDITAR
        'Next


        'Habilitar Filtradores
        With JGr_Productos
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
        End With

        'diseño de la grilla
        JGr_Productos.VisualStyle = VisualStyle.Office2007
    End Sub

    Private Sub _PCargarGridClientes(Optional pasActivos As Boolean = False)
        Dim dtProd As New DataTable
        If pasActivos = True Then
            dtProd = L_GetClientes3("", "ccdesc").Tables(0)
        Else
            dtProd = L_GetClientes3("and ccest=1", "ccdesc").Tables(0)
        End If

        JGr_Clientes.BoundMode = BoundMode.Bound
        JGr_Clientes.DataSource = dtProd
        JGr_Clientes.RetrieveStructure()

        'dar formato a las columnas
        With JGr_Clientes.RootTable.Columns(0)
            .Key = "CliId"
            .Caption = "ID Cli."
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With
        With JGr_Clientes.RootTable.Columns(1)
            .Key = "codCliente"
            .Caption = "Cod Cliente"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = (gi_vccli = 1)
        End With

        With JGr_Clientes.RootTable.Columns(2)
            .Key = "CliNombre"
            .Caption = "Nombre"
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With

        With JGr_Clientes.RootTable.Columns(3)
            .Key = "CliDireccion"
            .Caption = "Direccion"
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With
        With JGr_Clientes.RootTable.Columns(4)
            .Visible = False
            .Key = "CliTelefono"
            .Caption = "Telefono"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With
        With JGr_Clientes.RootTable.Columns(5)
            .Key = "CliTelefono2"
            .Caption = "Telefono"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With

        With JGr_Clientes.RootTable.Columns(6)
            .Key = "CliCodZona"
            .Visible = False
        End With
        With JGr_Clientes.RootTable.Columns(7)
            .Key = "CliZona"
            .Caption = "Zona"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With
        With JGr_Clientes.RootTable.Columns(8)
            .Visible = False
        End With
        With JGr_Clientes.RootTable.Columns(9)
            .Caption = "Doc"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = False
        End With
        With JGr_Clientes.RootTable.Columns(10)
            .Key = "CliNroDoc"
            .Caption = "CI/NIT"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Clientes.RootTable.Columns(11)
            .Key = "CliCateg"
            .Visible = False
        End With
        With JGr_Clientes.RootTable.Columns(12)
            .Caption = "Categoria"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With
        With JGr_Clientes.RootTable.Columns(13)
            .Visible = False
        End With
        With JGr_Clientes.RootTable.Columns(14)
            .Visible = False
        End With
        With JGr_Clientes.RootTable.Columns(15)
            .Visible = False
        End With
        With JGr_Clientes.RootTable.Columns(16)
            .Visible = False
        End With
        With JGr_Clientes.RootTable.Columns(17)
            .Visible = False
        End With
        With JGr_Clientes.RootTable.Columns(18)
            .Visible = False
        End With

        JGr_Clientes.ContextMenuStrip = ConMenu_Clientes

        'Habilitar Filtradores
        With JGr_Clientes
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            .FilterRowButtonStyle = FilterRowButtonStyle.ConditionOperatorDropDown

            '.RecordNavigator = True
        End With

        'diseño de la grilla
        JGr_Clientes.VisualStyle = VisualStyle.Office2007

        If pasActivos = True Then
            'poner color a la fila de acuerdo a la condicion 
            Dim fc As GridEXFormatCondition
            fc = New GridEXFormatCondition(JGr_Clientes.RootTable.Columns("ccest"), ConditionOperator.Equal, "0")
            fc.FormatStyle.BackColor = Color.LightGray

            JGr_Clientes.RootTable.FormatConditions.Add(fc)
        End If
    End Sub

    Private Sub _PCargarGridRegistrosPedidos(ByRef objGrid As Janus.Windows.GridEX.GridEX, codCli As String, Optional estado As String = "")
        Dim dt As DataTable
        If estado = "" Then
            dt = L_PedidoCabecera_GeneralTop10(-1, " AND oaccli=" + codCli + " AND oaest>=1 AND oaest<=4 and oaap=1 ")
        Else
            dt = L_PedidoCabecera_GeneralTop10(-1, " AND oaest=" + estado + " AND oaccli=" + codCli + " AND oaest>=1 AND oaest<=4 oaap=1 ")
        End If



        If dt.Rows.Count > 0 Then
            objGrid.BoundMode = BoundMode.Bound
            objGrid.DataSource = dt
            objGrid.RetrieveStructure()

            'dar formato a las columnas
            With objGrid.RootTable.Columns("oanumi")
                .Caption = "Cod. Pedido"
                .Key = "Cod"
                .Width = 60
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.FontSize = gi_fuenteTamano
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            End With
            With objGrid.RootTable.Columns("oafdoc")
                .Caption = "Fecha"
                .Width = 100
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.FontSize = gi_fuenteTamano
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            End With

            With objGrid.RootTable.Columns("oahora")
                .Caption = "Hora"
                .Width = 70
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.FontSize = gi_fuenteTamano
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            End With

            With objGrid.RootTable.Columns("diasTrans")
                .Caption = "Dias Trancurridos"
                .Width = 90
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.FontSize = gi_fuenteTamano
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            End With

            With objGrid.RootTable.Columns("oaobs")
                .Visible = False
            End With

            With objGrid.RootTable.Columns("oaobs2")
                .Visible = False
            End With

            With objGrid.RootTable.Columns("reclamo")
                .Visible = False
            End With

            With objGrid.RootTable.Columns("oapg")
                .Visible = False
            End With

            With objGrid.RootTable.Columns("oaest")
                .Visible = False
            End With
            'Habilitar Filtradores
            With objGrid
                '.DefaultFilterRowComparison = FilterConditionOperator.Contains
                '.FilterMode = FilterMode.Automatic
                '.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
                .GroupByBoxVisible = False
                .VisualStyle = VisualStyle.Office2007
            End With

            'cargar contexmenu
            JGr_UltimosPedidos.ContextMenuStrip = ConMenu_Opciones1

            'poner color a la fila de acuerdo a la condicion 
            Dim fc, fc1, fc2, fc3 As GridEXFormatCondition

            'formato para decir si el pedido tiene reclamo
            fc = New GridEXFormatCondition(objGrid.RootTable.Columns("reclamo"), ConditionOperator.Equal, 1)
            fc.FormatStyle.ForeColor = Color.Red

            'formato para decir si es un pedido generado automaticamente
            fc1 = New GridEXFormatCondition(objGrid.RootTable.Columns("oapg"), ConditionOperator.Equal, 1)
            fc1.FormatStyle.BackColor = Color.LightGreen

            'formato para decir si es un pedido esta entregado y con nota
            fc2 = New GridEXFormatCondition(objGrid.RootTable.Columns("oaest"), ConditionOperator.Equal, 4)
            fc2.FormatStyle.BackColor = Color.LightGray

            'formato para decir si es un pedido fue regerado a partir de otro pedido
            fc3 = New GridEXFormatCondition(objGrid.RootTable.Columns("oapg"), ConditionOperator.Equal, 2)
            fc3.FormatStyle.BackColor = Color.Yellow

            objGrid.RootTable.FormatConditions.Add(fc)
            objGrid.RootTable.FormatConditions.Add(fc1)
            objGrid.RootTable.FormatConditions.Add(fc2)
            objGrid.RootTable.FormatConditions.Add(fc3)

            'Actualizar los dias transcurridos
            Dim ant As Integer = 0
            Dim aux As Integer
            For i = 0 To JGr_UltimosPedidos.RowCount - 1
                JGr_UltimosPedidos.Row = i
                aux = JGr_UltimosPedidos.GetValue("diasTrans")
                JGr_UltimosPedidos.SetValue("diasTrans", aux - ant)
                ant = aux
            Next
        Else
            JGr_Reclamos.ClearStructure()
            JGr_UltimosPedidos.ClearStructure()
            Tb_TotalPedidos3Meses.Text = ""
            Tb_Obs.Text = ""
            Tb_Obs2.Text = ""
        End If

    End Sub

    Private Sub _PCargarGridReclamos(idPedido As Integer)
        Dim dt As New DataTable
        dt = L_PedidoReclamos_General(-1, idPedido, " order by ofnumi desc")

        JGr_Reclamos.DataSource = dt
        JGr_Reclamos.RetrieveStructure()

        'dar formato a las columnas
        With JGr_Reclamos.RootTable.Columns("ofnumi")
            .Caption = "Id"
            .Width = 40
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With
        With JGr_Reclamos.RootTable.Columns("ofnumiped")
            .Visible = False
        End With
        With JGr_Reclamos.RootTable.Columns("oftip")
            .Visible = False
        End With
        With JGr_Reclamos.RootTable.Columns("oftip2")
            .Caption = "TIPO"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With
        With JGr_Reclamos.RootTable.Columns("ofest")
            .Visible = False
        End With
        With JGr_Reclamos.RootTable.Columns("ofest2")
            .Caption = "ESTADO"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With

        With JGr_Reclamos.RootTable.Columns("ofobs")
            .Caption = "Observacion"
            .Width = 350
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With

        With JGr_Reclamos.RootTable.Columns("offact")
            .Caption = "Fecha"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With
        With JGr_Reclamos.RootTable.Columns("ofhact")
            .Caption = "Hora"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Reclamos.RootTable.Columns("ofconcep")
            .Visible = False
        End With

        With JGr_Reclamos.RootTable.Columns("cedesc")
            .Caption = "Concepto"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With

        With JGr_Reclamos.RootTable.Columns("ofuact")
            .Caption = "User"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With


        'Habilitar Filtradores
        With JGr_Reclamos
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            .VisualStyle = VisualStyle.Office2007
        End With

        'poner color a la fila de acuerdo a la condicion 
        Dim fc, fc1 As GridEXFormatCondition
        fc = New GridEXFormatCondition(JGr_Reclamos.RootTable.Columns("oftip"), ConditionOperator.Equal, 1)
        fc.FormatStyle.BackColor = Color.LightGreen

        fc1 = New GridEXFormatCondition(JGr_Reclamos.RootTable.Columns("oftip"), ConditionOperator.Equal, 2)
        fc1.FormatStyle.BackColor = Color.LightBlue

        JGr_Reclamos.RootTable.FormatConditions.Add(fc)
        JGr_Reclamos.RootTable.FormatConditions.Add(fc1)


    End Sub


    Private Sub _PCargarComboLibreria(ByVal cb As Janus.Windows.GridEX.EditControls.MultiColumnCombo, ByVal concep As Integer)
        Dim _Ds As New DataSet
        _Ds = L_General_LibreriaDetalle(-1, concep)

        cb.DropDownList.Columns.Clear()

        cb.DropDownList.Columns.Add(_Ds.Tables(0).Columns("cenum").ToString).Width = 50
        cb.DropDownList.Columns(0).Caption = "Código"
        cb.DropDownList.Columns.Add(_Ds.Tables(0).Columns("cedesc").ToString).Width = 250
        cb.DropDownList.Columns(1).Caption = "Descripcion"

        cb.ValueMember = _Ds.Tables(0).Columns("cenum").ToString
        cb.DisplayMember = _Ds.Tables(0).Columns("cedesc").ToString
        cb.DataSource = _Ds.Tables(0)
        cb.Refresh()

    End Sub

    Private Sub _PHabilitar()
        'Tb_Observaciones.Enabled = True
        Tb_Observaciones.ReadOnly = False
        Tb_CantProd.ReadOnly = False

        MBtNuevo.Enabled = False
        MBtModificar.Enabled = False
        MBtEliminar.Enabled = False
        MBtGrabar.Enabled = True
        Tb_Fecha.Enabled = True

        'BBtn_Nuevo.Enabled = False
        'BBtn_Modificar.Enabled = False
        'BBtn_Eliminar.Enabled = False
        'BBtn_Grabar.Enabled = True

        Btn_AddProd.Enabled = True
        Btn_TerminarAdd.Enabled = True

        JGr_Clientes.Enabled = True
        JGr_DetallePedido.Enabled = True
        JGr_Productos.Enabled = True
        JGr_TipoProd.Enabled = True
        Tb_Estado.Enabled = True

        cbDistribuidor.ReadOnly = False
        'cbPreVendedor.ReadOnly = False

        If _nuevoBasePeriodico = True Then
            GrPan_PeriodoPedido.Enabled = True
            Btn_GenerarPedidos.Enabled = False
            Btn_Check1.PerformClick()
        End If

    End Sub
    Private Sub _PInhabilitar()
        Tb_CantProd.ReadOnly = True
        Tb_Id.ReadOnly = True
        Tb_Fecha.Enabled = False
        Tb_Hora.ReadOnly = True
        Tb_Zona.ReadOnly = False
        Tb_Observaciones.ReadOnly = True
        Tb_CliCateg.ReadOnly = True
        Tb_CliCod.ReadOnly = True
        Tb_CliCodZona.ReadOnly = True
        Tb_CliDireccion.ReadOnly = True
        Tb_CliNombre.ReadOnly = True
        Tb_CliTelef.ReadOnly = True
        Tb_Estado.Enabled = False
        Tb_Obs.ReadOnly = True
        Tb_Obs2.ReadOnly = True
        Tb_PromCosumo.ReadOnly = True
        Tb_TotalPedidos3Meses.ReadOnly = True

        cbDistribuidor.ReadOnly = True
        cbPreVendedor.ReadOnly = True

        'BBtn_Nuevo.Enabled = True
        'BBtn_Modificar.Enabled = True
        'BBtn_Eliminar.Enabled = True
        'BBtn_Grabar.Enabled = False
        MBtNuevo.Enabled = True
        MBtModificar.Enabled = True
        MBtEliminar.Enabled = True
        MBtGrabar.Enabled = False

        Btn_AddProd.Enabled = False
        Btn_TerminarAdd.Enabled = False

        If _nuevoBasePeriodico = True Then
            GrPan_PeriodoPedido.Enabled = False
            Btn_GenerarPedidos.Enabled = True
        End If

        'Txt_Paginacion.Text = ""

        'BBtn_Grabar.Image = My.Resources.GRABAR
        'BBtn_Grabar.ImageLarge = My.Resources.GRABAR

        Btn_TerminarAdd.Image = My.Resources.GRABAR

        JGr_Clientes.Enabled = False
        JGr_DetallePedido.Enabled = False
        JGr_Productos.Enabled = False
        JGr_TipoProd.Enabled = False


        _PLimpiarErrores()
    End Sub
    Private Sub _PLimpiarErrores()
        'Ep1.Clear()
        'Ep2.Clear()
        'J_Cb_Ciudad.BackColor = Color.White
        'J_Cb_Provincia.BackColor = Color.White
        'J_Cb_Zona.BackColor = Color.White
        'ButtonX1.BackColor = Color.White
    End Sub
    Private Sub _PLimpiar()
        Tb_Id.Text = ""
        Tb_Hora.Text = Now.Hour.ToString() + ":" + Now.Minute.ToString()
        Tb_Zona.Text = ""
        Tb_Observaciones.Text = ""
        Tb_CliCateg.Text = ""
        Tb_CliCod.Text = ""
        Tb_CliCodZona.Text = ""
        Tb_CliDireccion.Text = ""
        Tb_CliNombre.Text = ""
        Tb_CliTelef.Text = ""
        Tb_Estado.Value = True
        Tb_CantProd.Text = ""

        If _nuevoBasePeriodico = True Then
            CheckBoxX1.Checked = False
            CheckBoxX2.Checked = False
            CheckBoxX3.Checked = False
            CheckBoxX4.Checked = False
            CheckBoxX5.Checked = False
            CheckBoxX6.Checked = False
            CheckBoxX7.Checked = False

            Tb_FrecEnDias.Text = 1
            Tb_FrecMensual.Text = 1

            Btn_Check1.PerformClick()
        End If

        'limpiar grid
        CType(JGr_DetallePedido.DataSource, DataTable).Clear() '_PCargarGridDetalle(-1)

        'aumentado 
        MLbPaginacion.Text = ""

    End Sub
    Private Sub _PHabilitarFocus()
        Tb_Hora.FocusHighlightEnabled = True
        Tb_Zona.FocusHighlightEnabled = True
        Tb_Observaciones.FocusHighlightEnabled = True
    End Sub

    Private Sub _PFiltrar()
        '_Dsencabezado = New DataSet
        'If _nuevoBasePeriodico = True Then
        '    _Dsencabezado.Tables.Add(L_PedidoCabecera_General(-1, " AND oaest=10"))
        'Else
        '    _Dsencabezado.Tables.Add(L_PedidoCabecera_General(-1, " AND oaest<>10"))
        'End If

        '_First = False
        If JGr_Buscador.RowCount <> 0 Then '_Dsencabezado.Tables(0).Rows.Count
            _Pos = 0
            _PMostrarRegistro(_Pos)
            'Txt_Paginacion.Text = Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString
            If JGr_Buscador.RowCount > 0 Then '_Dsencabezado.Tables(0).Rows.Count > 0
                MBtPrimero.Visible = True
                MBtAnterior.Visible = True
                MBtSiguiente.Visible = True
                MBtUltimo.Visible = True
            End If
        End If

    End Sub
    Private Sub _PMostrarRegistro(_N As Integer)
        JGr_Buscador.Row = _N
        With JGr_Buscador '_Dsencabezado.Tables(0).Rows(_N)
            Tb_Id.Text = .GetValue("oanumi")
            Tb_Fecha.Value = .GetValue("oafdoc")
            Tb_Hora.Text = .GetValue("oahora")
            Tb_CliCod.Text = .GetValue("oaccli")
            Tb_CliNombre.Text = .GetValue("ccdesc")
            Tb_CliDireccion.Text = IIf(IsDBNull(.GetValue("ccdirec")), "", .GetValue("ccdirec"))
            Tb_CliTelef.Text = IIf(IsDBNull(.GetValue("cctelf1")), "", .GetValue("cctelf1"))
            Tb_CliCodZona.Text = .GetValue("oazona")
            Tb_CliCateg.Text = .GetValue("cccat")
            Tb_Zona.Text = .GetValue("cedesc")
            Tb_Observaciones.Text = .GetValue("oaobs")
            If .GetValue("oaest") = 0 Then
                Tb_Estado.Value = False
            Else
                Tb_Estado.Value = True
            End If
            cbDistribuidor.Clear()
            cbDistribuidor.Value = .GetValue("oarepa")
            cbPreVendedor.Clear()
            cbPreVendedor.Value = .GetValue("oaanumiprev")
        End With

        'cargar detalle
        _PCargarGridDetalle(Tb_Id.Text)
        'Dim dtDet As DataTable = L_PedidoDetalle_General(-1, Tb_Id.Text)
        'Dim codProd, cant, precio, subTotal As String
        'Dim i As Integer

        'For i = 0 To JGr_DetallePedido.RowCount - 1
        '    JGr_DetallePedido.Row = i
        '    codProd = JGr_DetallePedido.CurrentRow.Cells("CodProd").Value
        '    cant = JGr_DetallePedido.CurrentRow.Cells("Cantidad").Value
        '    precio = JGr_DetallePedido.CurrentRow.Cells("Precio").Value
        '    subTotal = JGr_DetallePedido.CurrentRow.Cells("Monto").Value
        '    L_PedidoDetalle_Grabar(Tb_Id.Text, codProd, cant, precio, subTotal)
        'Next

        'cargar Frecuencia
        If _nuevoBasePeriodico = True Then
            Dim dt As DataTable = L_PedidoDetalleFrecuencia_General(-1, Tb_Id.Text)
            If dt.Rows.Count > 0 Then
                Dim diasSem As String = dt.Rows(0).Item("ohdiassem")
                If diasSem <> "0" Then
                    CheckBoxX1.Checked = IIf(diasSem(6) = "1", True, False)
                    CheckBoxX2.Checked = IIf(diasSem(5) = "1", True, False)
                    CheckBoxX3.Checked = IIf(diasSem(4) = "1", True, False)
                    CheckBoxX4.Checked = IIf(diasSem(3) = "1", True, False)
                    CheckBoxX5.Checked = IIf(diasSem(2) = "1", True, False)
                    CheckBoxX6.Checked = IIf(diasSem(1) = "1", True, False)
                    CheckBoxX7.Checked = IIf(diasSem(0) = "1", True, False)
                Else
                    CheckBoxX1.Checked = False
                    CheckBoxX2.Checked = False
                    CheckBoxX3.Checked = False
                    CheckBoxX4.Checked = False
                    CheckBoxX5.Checked = False
                    CheckBoxX6.Checked = False
                    CheckBoxX7.Checked = False
                End If

                Tb_FrecEnDias.Text = IIf(dt.Rows(0).Item("ohdias") = 0, "", dt.Rows(0).Item("ohdias"))

                Tb_FrecMensual.Text = IIf(dt.Rows(0).Item("ohdiames") = 0, "", dt.Rows(0).Item("ohdiames"))
            End If

        End If

        MLbPaginacion.Text = Str(_N + 1) + "/" + JGr_Buscador.RowCount.ToString '_Dsencabezado.Tables(0).Rows.Count.ToString
    End Sub
    Private Function _PValidar() As Boolean
        Dim _Error As Boolean = False

        If Tb_Zona.Text = "" Then
            Tb_Zona.BackColor = Color.Red   'error de validacion
            'Ep1.SetError(Tb_Nombre, "Ingrese el nombre del empleado!")
            _Error = True
        Else
            Tb_Zona.BackColor = Color.White
            'Ep1.SetError(Tb_Nombre, "")
        End If

        If Tb_CliCod.Text = "" Then
            Tb_CliCod.BackColor = Color.Red   'error de validacion
            'Ep1.SetError(Tb_Nombre, "Ingrese el nombre del empleado!")
            _Error = True
        Else
            Tb_CliCod.BackColor = Color.White
            'Ep1.SetError(Tb_Nombre, "")
        End If

        If (JGr_DetallePedido.RowCount = 0) Then
            ToastNotification.Show(Me, "El pedido no puede quedar sin items.".ToUpper, My.Resources.WARNING, 3000, eToastGlowColor.Green, eToastPosition.BottomCenter)
            _Error = True
        End If

        If (cbDistribuidor.SelectedIndex = -1) Then
            cbDistribuidor.BackColor = Color.Red   'error de validacion
            'Ep1.SetError(Tb_Nombre, "Ingrese el nombre del empleado!")
            _Error = True
        Else
            cbDistribuidor.BackColor = Color.White
            'Ep1.SetError(Tb_Nombre, "")
        End If

        If (cbPreVendedor.SelectedIndex = -1) Then
            cbPreVendedor.BackColor = Color.Red   'error de validacion
            'Ep1.SetError(Tb_Nombre, "Ingrese el nombre del empleado!")
            _Error = True
        Else
            cbPreVendedor.BackColor = Color.White
            'Ep1.SetError(Tb_Nombre, "")
        End If

        Dim i As Integer
        For i = 0 To JGr_DetallePedido.RowCount - 1
            JGr_DetallePedido.Row = i
            If IsNumeric(JGr_DetallePedido.CurrentRow.Cells("Cantidad").Value) = False Then
                ToastNotification.Show(Me, "falta cantidad en algun producto en el detalle".ToUpper, My.Resources.WARNING, 3000, eToastGlowColor.Green, eToastPosition.BottomCenter)
                _Error = True
            End If
        Next

        If _nuevoBasePeriodico = True Then
            If Btn_Check1.Tag = 1 Then 'frecuencia por dias a la semana
                Dim diasSem As String = ""
                diasSem = IIf(CheckBoxX1.Checked = True, "1", "0") + diasSem
                diasSem = IIf(CheckBoxX2.Checked = True, "1", "0") + diasSem
                diasSem = IIf(CheckBoxX3.Checked = True, "1", "0") + diasSem
                diasSem = IIf(CheckBoxX4.Checked = True, "1", "0") + diasSem
                diasSem = IIf(CheckBoxX5.Checked = True, "1", "0") + diasSem
                diasSem = IIf(CheckBoxX6.Checked = True, "1", "0") + diasSem
                diasSem = IIf(CheckBoxX7.Checked = True, "1", "0") + diasSem
                If diasSem = "0000000" Then
                    GrB_FrecSemanal.BackColor = Color.Red   'error de validacion
                    'Ep1.SetError(Tb_Nombre, "Ingrese el nombre del empleado!")
                    _Error = True
                Else
                    GrB_FrecSemanal.BackColor = Color.Transparent
                    'Ep1.SetError(Tb_Nombre, "")
                End If
            Else
                If Btn_Check2.Tag = 1 Then 'frecuencia cada ciertos dias
                    If Tb_FrecEnDias.Text = "" Then
                        Tb_FrecEnDias.BackColor = Color.Red   'error de validacion
                        'Ep1.SetError(Tb_Nombre, "Ingrese el nombre del empleado!")
                        _Error = True
                    Else
                        Tb_FrecEnDias.BackColor = Color.White
                        'Ep1.SetError(Tb_Nombre, "")
                    End If
                Else 'frecuencia por dia del mes
                    If Tb_FrecMensual.Text = "" Then
                        Tb_FrecMensual.BackColor = Color.Red   'error de validacion
                        'Ep1.SetError(Tb_Nombre, "Ingrese el nombre del empleado!")
                        _Error = True
                    Else
                        Tb_FrecMensual.BackColor = Color.White
                        'Ep1.SetError(Tb_Nombre, "")
                    End If
                End If

            End If
        End If

        Return _Error
    End Function

    Private Sub _PGrabarRegistro()
        Dim _Error As Boolean = False
        If _PValidar() Then
            Exit Sub
        End If

        If MBtGrabar.Enabled = False Then
            Exit Sub
        End If

        If _Nuevo Then
            'INICIAR OBJETOS PARA MANDAR NOTIFICACION
            Dim objListDetalle As New List(Of RequestDetail) 'webLuis

            'Tb_Fecha.Text = Date.Now.Date.ToString("yyyy/MM/dd")
            'Tb_Hora.Text = Now.Hour.ToString + ":" + Now.Minute.ToString

            'ACTUALIZAR EL PROMEDIO DE CONSUMO
            If _nuevoBasePeriodico = False Then
                Dim prom As Integer
                Dim dtClienteSelect As DataTable = L_GetCliente2(Tb_CliCod.Text).Tables(0)
                If IsDBNull(dtClienteSelect.Rows(0).Item("ccprconsu")) = False Then
                    prom = L_GetCliente2(Tb_CliCod.Text).Tables(0).Rows(0).Item("ccprconsu")
                Else
                    prom = 0
                End If
                Dim ultimaFechaPedido As Date = IIf(IsDBNull(dtClienteSelect.Rows(0).Item("ccultped")), Today.Date, dtClienteSelect.Rows(0).Item("ccultped"))
                Dim diasTrans As Integer = DateDiff(DateInterval.Day, ultimaFechaPedido, Today.Date)
                prom = (prom + diasTrans) / 2

                L_GrabarModificarCliente("ccprconsu=" + Str(prom), "ccnumi=" + Str(Tb_CliCod.Text))
                L_GrabarModificarCliente("ccultped='" + Today.Date.ToString("yyyy/MM/dd") + "'", "ccnumi=" + Str(Tb_CliCod.Text))
                L_GrabarModificarCliente("ccultvent='" + Today.Date.ToString("yyyy/MM/dd") + "'", "ccnumi=" + Str(Tb_CliCod.Text))

            End If

            L_PedidoCabecera_Grabar(Tb_Id.Text, Date.Now.Date.ToString("yyyy/MM/dd"), Tb_Hora.Text, Tb_CliCod.Text, Tb_CliCodZona.Text, cbDistribuidor.Value.ToString, Tb_Observaciones.Text, IIf(_nuevoBasePeriodico = True, "10", "1"), "1", "0")
            L_PedidoCabecera_GrabarExtencion(Tb_Id.Text, cbPreVendedor.Value.ToString, "2", "0")

            'Cambiar de zona al cliente a la zona del chofer
            L_GrabarModificarCliente("cczona=" + Tb_CliCodZona.Text, "ccnumi=" + Str(Tb_CliCod.Text))

            'grabar detalle
            Dim codProd, cant, precio, subTotal As String
            Dim i As Integer
            For i = 0 To JGr_DetallePedido.RowCount - 1
                JGr_DetallePedido.Row = i
                codProd = JGr_DetallePedido.CurrentRow.Cells("CodProd").Value
                cant = JGr_DetallePedido.CurrentRow.Cells("Cantidad").Value
                precio = JGr_DetallePedido.CurrentRow.Cells("Precio").Value
                subTotal = JGr_DetallePedido.CurrentRow.Cells("Monto").Value
                L_PedidoDetalle_Grabar(Tb_Id.Text, codProd, cant, precio, subTotal)

                'adiciono un objeto detalle
                objListDetalle.Add(New RequestDetail(Tb_Id.Text, codProd, cant, precio, subTotal, L_ClaseGetProducto(codProd))) 'webLuis
            Next

            'VERIFICAR SI EL CLIENTE ESTABA PASIVO
            If Tb_CliEstado.Text = "0" Then
                L_GrabarModificarCliente("ccest=1", "ccnumi=" + Tb_CliCod.Text)
            End If

            'Grabar detalle de frecuencia del pedido
            If _nuevoBasePeriodico = True Then
                If Btn_Check1.Tag = 1 Then 'frecuencia por dias a la semana
                    Dim diasSem As String = ""
                    diasSem = IIf(CheckBoxX1.Checked = True, "1", "0") + diasSem
                    diasSem = IIf(CheckBoxX2.Checked = True, "1", "0") + diasSem
                    diasSem = IIf(CheckBoxX3.Checked = True, "1", "0") + diasSem
                    diasSem = IIf(CheckBoxX4.Checked = True, "1", "0") + diasSem
                    diasSem = IIf(CheckBoxX5.Checked = True, "1", "0") + diasSem
                    diasSem = IIf(CheckBoxX6.Checked = True, "1", "0") + diasSem
                    diasSem = IIf(CheckBoxX7.Checked = True, "1", "0") + diasSem

                    L_PedidoDetalleFrecuencia_Grabar(Tb_Id.Text, diasSem, "0", "0")
                Else
                    If Btn_Check2.Tag = 1 Then 'frecuencia cada ciertos dias
                        L_PedidoDetalleFrecuencia_Grabar(Tb_Id.Text, "0", Tb_FrecEnDias.Text, "0")
                    Else 'frecuencia por dia del mes
                        L_PedidoDetalleFrecuencia_Grabar(Tb_Id.Text, "0", "0", Tb_FrecMensual.Text)
                    End If

                End If

            End If


            'grabar estado del pedido
            L_PedidoEstados_Grabar(Tb_Id.Text, IIf(_nuevoBasePeriodico = True, "10", "1"), Date.Now.Date.ToString("yyyy/MM/dd"), Tb_Hora.Text, gs_user)

            ''actualizar el promedio de pedidos del cliente
            ''If _nuevoBasePeriodico = False Then
            ''    Dim prom As Integer
            ''    If IsDBNull(L_GetCliente(Tb_CliCod.Text).Tables(0).Rows(0).Item("ccprconsu")) = False Then
            ''        prom = L_GetCliente(Tb_CliCod.Text).Tables(0).Rows(0).Item("ccprconsu")
            ''    Else
            ''        prom = 0
            ''    End If
            ''    Dim dt As DataTable = L_PedidoCabecera_GeneralTop10(-1, " AND oaccli=" + Tb_CliCod.Text + " AND oaest>=1 AND oaest<=4 ")
            ''    If dt.Rows.Count >= 2 Then
            ''        Dim ultFechaPeddido As Date = dt.Rows(1).Item("oafdoc")
            ''        Dim diasTrans As Integer = DateDiff(DateInterval.Day, ultFechaPeddido, Today.Date)
            ''        prom = (prom + diasTrans) / 2
            ''    Else
            ''        prom = 0
            ''    End If
            ''    L_GrabarModificarCliente("ccprconsu=" + Str(prom), "ccnumi=" + Str(Tb_CliCod.Text))
            ''End If

            If (gi_notiPed = 1) Then
                'webLuis-----------------'MANDAR LA NOTIFICACION DEL PEDIDO 'webLuis-----------------------------------------------
                Dim objResult As New Result
                Dim dtRepartidor As DataTable = L_ZonaDetalleRepartidor_General(-1, Tb_CliCodZona.Text).Tables(0)
                Dim codRep As String = "-1"
                If dtRepartidor.Rows.Count > 0 Then
                    codRep = dtRepartidor.Rows(0).Item("lccbnumi")
                End If
                'Dim objPedido As New RequestHeader(Tb_Id.Text, Date.Now.Date.ToString("yyyy/MM/dd"), Tb_Hora.Text, Tb_CliCod.Text, Tb_CliCodZona.Text, codRep, Tb_Observaciones.Text, "", IIf(_nuevoBasePeriodico = True, "10", "1"), "1", "0", Date.Now.Date.ToString("yyyy/MM/dd"), Now.Hour.ToString + ":" + Now.Minute.ToString, gs_user, objListDetalle, L_ClaseGetCliente(Tb_CliCod.Text))
                Dim objPedido As New RequestHeader(Tb_Id.Text, Date.Now.Date.ToString("yyyy-MM-dd"), Tb_Hora.Text, Tb_CliCod.Text, Tb_CliCodZona.Text, codRep, Tb_Observaciones.Text, "", IIf(_nuevoBasePeriodico = True, "10", "1"), "1", "0", Date.Now.Date.ToString("yyyy-MM-dd"), Now.Hour.ToString + ":" + Now.Minute.ToString, gs_user, objListDetalle, L_ClaseGetCliente(Tb_CliCod.Text))
                Dim dtLlave As DataTable = L_TC0022General(codRep)
                If dtLlave.Rows.Count > 0 Then
                    Dim llaveRep As String = dtLlave(0).Item("ckidfsm")
                    objResult.fcmToken = llaveRep
                    objResult.mRequestHeader = objPedido
                    Dim respuesta As Boolean = JsonApiClient._prMandarNotificacion(objResult) 'objResult
                    If respuesta = False Then
                        ''ToastNotification.Show(Me, "El Pedido no se pudo enviar a la app del repartidor".ToUpper, My.Resources.WARNING, 10000, eToastGlowColor.Red, eToastPosition.TopCenter)
                    End If
                Else
                    ''ToastNotification.Show(Me, "no se pudo enviar el pedido al repartidor!!! , ".ToUpper + "el repartidor con codigo: ".ToUpper + codRep + " no tiene grabado su llave en la tabla TC0022", My.Resources.WARNING, 10000, eToastGlowColor.Red, eToastPosition.TopCenter)
                End If
                '---------------------------------------'webLuis-------------------------------------------------------------------

            End If

            'ACTUALIZAR GRILLA DE BUSQUEDA
            ''AC******************************_PCargarBuscador()

            'Volver al foco para uno nuevo
            Tb_Fecha.Focus()
            ToastNotification.Show(Me, "Codigo de Pedido " + Tb_Id.Text + " Grabado con Exito.", My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.BottomLeft)
            _PLimpiar()

            'ir a clientes
            MSuperTabControlPrincipal.SelectedTabIndex = 2
            JGr_Clientes.Focus()

            'limpiar el buscador
            JGr_Clientes.RemoveFilters()

            JGr_Clientes.MoveTo(JGr_Clientes.FilterRow)
            JGr_Clientes.Col = 1
        Else
            L_PedidoCabacera_Modificar(Tb_Id.Text, Tb_Fecha.Value.ToString("yyyy/MM/dd"), Tb_Hora.Text, Tb_CliCod.Text, Tb_CliCodZona.Text, cbDistribuidor.Value.ToString, Tb_Observaciones.Text, IIf(_nuevoBasePeriodico = True, "10", "1"))
            L_PedidoCabacera_ModificarExtencion(Tb_Id.Text, cbPreVendedor.Value.ToString)

            'modificar detalle
            L_PedidoDetalle_Borrar(Tb_Id.Text)
            Dim codProd, cant, precio, subTotal As String
            Dim i As Integer
            For i = 0 To JGr_DetallePedido.RowCount - 1
                JGr_DetallePedido.Row = i
                codProd = JGr_DetallePedido.CurrentRow.Cells("CodProd").Value
                cant = JGr_DetallePedido.CurrentRow.Cells("Cantidad").Value
                precio = JGr_DetallePedido.CurrentRow.Cells("Precio").Value
                subTotal = JGr_DetallePedido.CurrentRow.Cells("Monto").Value
                L_PedidoDetalle_Grabar(Tb_Id.Text, codProd, cant, precio, subTotal)
            Next

            'Grabar detalle de frecuencia del pedido
            If _nuevoBasePeriodico = True Then
                L_PedidoDetalleFrecuencia_Borrar(Tb_Id.Text)
                If Btn_Check1.Tag = 1 Then 'frecuencia por dias a la semana
                    Dim diasSem As String = ""
                    diasSem = IIf(CheckBoxX1.Checked = True, "1", "0") + diasSem
                    diasSem = IIf(CheckBoxX2.Checked = True, "1", "0") + diasSem
                    diasSem = IIf(CheckBoxX3.Checked = True, "1", "0") + diasSem
                    diasSem = IIf(CheckBoxX4.Checked = True, "1", "0") + diasSem
                    diasSem = IIf(CheckBoxX5.Checked = True, "1", "0") + diasSem
                    diasSem = IIf(CheckBoxX6.Checked = True, "1", "0") + diasSem
                    diasSem = IIf(CheckBoxX7.Checked = True, "1", "0") + diasSem
                    L_PedidoDetalleFrecuencia_Grabar(Tb_Id.Text, diasSem, "0", "0")
                Else
                    If Btn_Check2.Tag = 1 Then 'frecuencia cada ciertos dias
                        L_PedidoDetalleFrecuencia_Grabar(Tb_Id.Text, "0", Tb_FrecEnDias.Text, "0")
                    Else 'frecuencia por dia del mes
                        L_PedidoDetalleFrecuencia_Grabar(Tb_Id.Text, "0", "0", Tb_FrecMensual.Text)
                    End If

                End If

            End If

            ToastNotification.Show(Me, "Codigo de Pedido " + Tb_Id.Text + " Modificado con Exito.", My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.BottomLeft)
            '_Deshabilitar()

            'TSB0_5.PerformClick()
            _Nuevo = False 'aumentado danny
            '_Modificar = False 'aumentado danny
            _PInhabilitar()
            _PCargarBuscador()
            _PFiltrar()
        End If
    End Sub

    Private Sub _PNuevoRegistro()
        _PHabilitar()
        'BBtn_Nuevo.Enabled = True
        MBtNuevo.Enabled = True

        _PLimpiar()
        Tb_Fecha.Focus()
        _Nuevo = True

        'ir a clientes
        MSuperTabControlPrincipal.SelectedTabIndex = 2
        JGr_Clientes.Focus()

        JGr_Clientes.MoveTo(JGr_Clientes.FilterRow)
        JGr_Clientes.Col = 1
    End Sub

    Private Sub _PModificarRegistro()
        _Nuevo = False
        '_Modificar = True
        _PHabilitar()
        JGr_Clientes.Enabled = False
    End Sub

    Private Sub _PEliminarRegistro()
        Dim _Result As MsgBoxResult
        _Result = MsgBox("Esta seguro de Eliminar el Registro?", MsgBoxStyle.YesNo, "Advertencia")
        If _Result = MsgBoxResult.Yes Then
            L_PedidoCabecera_Borrar(Tb_Id.Text) 'solo lo cambia el estado

            _PFiltrar()
            'mi codigo, actualizo el sub
            '_Pos = 0
            'Txt_Paginacion.Text = Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString
        End If
    End Sub

    Private Sub _PSalirRegistro()
        If MBtGrabar.Enabled = True Then
            _PInhabilitar()
            _PFiltrar()
            _Nuevo = False
            MSuperTabControlPrincipal.SelectedTabIndex = 0
        Else
            Me.Close()
            _modulo.Select()
            _tab.Close()
        End If
    End Sub

    Private Sub _PGenerarPedidosPeriodicamente()
        Dim dtFechaFrecPed = L_PedidoDetalleFechaFrecPedido_General(Tb_Id.Text, Today.Date.ToString("yyyy-MM-dd"))
        If dtFechaFrecPed.Rows.Count > 0 Then 'significa que ya se genero un pedido en el dia
            ToastNotification.Show(Me, "ya se genero pedidos hoy a partir de esta base periodica".ToUpper, My.Resources.WARNING, 5000, eToastGlowColor.Green, eToastPosition.BottomLeft)
            Exit Sub
        End If

        Dim dt As DataTable = L_PedidoDetalleFrecuencia_General(-1, Tb_Id.Text)
        Dim diasSem As String = dt.Rows(0).Item("ohdiassem")

        Dim grabar As Boolean = False
        Dim fecha As Date = Today.Date
        If diasSem <> "0" Then 'geerar pedidos automaticamente
            Select Case Today.DayOfWeek
                Case DayOfWeek.Monday
                    grabar = IIf(diasSem(6) = "1", True, False)
                Case DayOfWeek.Tuesday
                    grabar = IIf(diasSem(5) = "1", True, False)
                Case DayOfWeek.Wednesday
                    grabar = IIf(diasSem(4) = "1", True, False)
                Case DayOfWeek.Thursday
                    grabar = IIf(diasSem(3) = "1", True, False)
                Case DayOfWeek.Friday
                    grabar = IIf(diasSem(2) = "1", True, False)
                Case DayOfWeek.Saturday
                    grabar = IIf(diasSem(1) = "1", True, False)
                Case DayOfWeek.Sunday
                    grabar = IIf(diasSem(0) = "1", True, False)
            End Select
        Else
            Dim cadaDias As Integer = dt.Rows(0).Item("ohdias")
            If cadaDias <> 0 Then

            Else
                Dim diaMes As Integer = dt.Rows(0).Item("ohdiames")

                If fecha.Day = diaMes Then
                    Dim dtFeriados As DataTable = L_Feriado_General(0).Tables(0)
                    Dim listFeriados As New List(Of DateTime)
                    For i = 0 To dtFeriados.Rows.Count - 1
                        Dim fs As String = dtFeriados.Rows(i).Item("pfflib").ToString
                        Dim f As DateTime = Convert.ToDateTime(fs)
                        listFeriados.Add(f)
                    Next

                    'recorrer la fecha hasta un dia que no sea feriado o fin de semana
                    While listFeriados.Contains(fecha) = True Or (fecha.DayOfWeek = DayOfWeek.Sunday Or fecha.DayOfWeek = DayOfWeek.Saturday) = True
                        fecha = DateAdd(DateInterval.Day, 1, fecha)
                    End While
                    grabar = True
                End If
            End If
        End If

        If grabar = True Then
            'GRABAR PEDIDO
            Dim idPedido As String = ""
            L_PedidoCabecera_Grabar(idPedido, fecha, Now.Hour.ToString + ":" + Now.Minute.ToString, Tb_CliCod.Text, Tb_CliCodZona.Text, cbDistribuidor.Value.ToString, Tb_Observaciones.Text, "1", "1", "1")

            'grabar detalle
            Dim codProd, cant, precio, subTotal As String
            For i = 0 To JGr_DetallePedido.RowCount - 1
                JGr_DetallePedido.Row = i
                codProd = JGr_DetallePedido.CurrentRow.Cells("CodProd").Value
                cant = JGr_DetallePedido.CurrentRow.Cells("Cantidad").Value
                precio = JGr_DetallePedido.CurrentRow.Cells("Precio").Value
                subTotal = JGr_DetallePedido.CurrentRow.Cells("Monto").Value
                L_PedidoDetalle_Grabar(idPedido, codProd, cant, precio, subTotal)
            Next
            'grabar estado del pedido
            L_PedidoEstados_Grabar(idPedido, "11", Date.Now.Date.ToString("yyyy/MM/dd"), Now.Hour.ToString + ":" + Now.Minute.ToString, gs_user)

            L_PedidoDetalleFechaFrecPedido_Grabar(Tb_Id.Text, Today.Date.ToString("yyyy-MM-dd"))
            ToastNotification.Show(Me, "Codigo de Pedido " + idPedido + " Generado con Exito.", My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.BottomLeft)
        Else
            ToastNotification.Show(Me, "No hay ningun pedido programado para hoy", My.Resources.I64x64_error, 5000, eToastGlowColor.Green, eToastPosition.BottomLeft)
        End If
    End Sub

    Private Sub _PPrimerRegistro()
        If JGr_Buscador.RowCount > 0 Then
            _Pos = 0
            _PMostrarRegistro(_Pos)
        End If
        'Txt_Paginacion.Text = Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString
    End Sub
    Private Sub _PAnteriorRegistro()
        If _Pos > 0 Then
            _Pos = _Pos - 1
            _PMostrarRegistro(_Pos)
            'Txt_Paginacion.Text = Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString
        End If
    End Sub
    Private Sub _PSiguienteRegistro()
        If _Pos < JGr_Buscador.RowCount - 1 Then '_Pos < _Dsencabezado.Tables(0).Rows.Count - 1
            _Pos = _Pos + 1
            _PMostrarRegistro(_Pos)
            'Txt_Paginacion.Text = Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString
        End If
    End Sub
    Private Sub _PUltimoRegistro()
        If JGr_Buscador.RowCount > 0 Then
            _Pos = JGr_Buscador.RowCount - 1
            _PMostrarRegistro(_Pos)
            'Txt_Paginacion.Text = Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString
        End If

    End Sub
#End Region

    Private Sub P_Pedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _PIniciarTodo()
    End Sub

    Private Sub MBtNuevo_Click(sender As Object, e As EventArgs) Handles MBtNuevo.Click
        _PNuevoRegistro()
    End Sub

    Private Sub BBtn_NuevoPedBasePeriodico_Click(sender As Object, e As ClickEventArgs)
        _PNuevoRegistro()
    End Sub

    Private Sub JGr_Clientes_KeyDown(sender As Object, e As KeyEventArgs) Handles JGr_Clientes.KeyDown

        If e.KeyData = Keys.Enter And JGr_Clientes.Row >= 0 Then
            Tb_CliCod.Text = Convert.ToString(JGr_Clientes.CurrentRow.Cells("CliId").Value)
            Tb_CliNombre.Text = Convert.ToString(JGr_Clientes.CurrentRow.Cells("CliNombre").Value)
            Tb_CliDireccion.Text = Convert.ToString(JGr_Clientes.CurrentRow.Cells("CliDireccion").Value)
            Tb_CliTelef.Text = Convert.ToString(JGr_Clientes.CurrentRow.Cells("CliTelefono2").Value)
            Tb_CliCodZona.Text = Convert.ToString(JGr_Clientes.CurrentRow.Cells("CliCodZona").Value)
            Tb_Zona.Text = Convert.ToString(JGr_Clientes.CurrentRow.Cells("CliZona").Value)
            Tb_CliCateg.Text = Convert.ToString(JGr_Clientes.CurrentRow.Cells("CliCateg").Value)
            Tb_CliEstado.Text = Convert.ToString(JGr_Clientes.CurrentRow.Cells("ccest").Value)
            tbCodCliente.Text = JGr_Clientes.CurrentRow.Cells("codCliente").Value.ToString

            Dim codZona As String = JGr_Clientes.CurrentRow.Cells("CliCodZona").Value.ToString
            Dim dtDist As DataTable = L_fnObtenerTabla("a.lanumi, c.cbnumi, c.cbdesc",
                                                       "TL001 a inner join TL0012 b on a.lanumi=b.lcnumi inner join TC002 c on b.lccbnumi=c.cbnumi",
                                                       "c.cbcat=1")
            Dim dtPreV As DataTable = L_fnObtenerTabla("a.lanumi, c.cbnumi, c.cbdesc",
                                                       "TL001 a inner join TL0012 b on a.lanumi=b.lcnumi inner join TC002 c on b.lccbnumi=c.cbnumi",
                                                       "c.cbcat=3")
            Dim dr As DataRow()
            If (dtDist.Rows.Count > 0) Then
                dr = dtDist.Select("lanumi=" + codZona)
                If (dr.Count > 0) Then
                    cbDistribuidor.Clear()
                    cbDistribuidor.SelectedText = dr(0).Item("cbdesc").ToString
                Else
                    cbDistribuidor.Clear()
                    cbDistribuidor.SelectedText = ""
                End If
            End If

            If (dtPreV.Rows.Count > 0) Then
                dr = dtPreV.Select("lanumi=" + codZona)
                If (dr.Count > 0) Then
                    cbPreVendedor.Clear()
                    cbPreVendedor.SelectedText = dr(0).Item("cbdesc").ToString
                Else
                    cbPreVendedor.Clear()
                    cbPreVendedor.SelectedText = ""
                End If
            End If

            'poner el foco en tipo de producto
            MSuperTabControlPrincipal.SelectedTabIndex = 0
            JGr_TipoProd.Focus()
            JGr_TipoProd.Row = 0
        End If

    End Sub

    Private Sub JGr_TipoProd_KeyDown(sender As Object, e As KeyEventArgs) Handles JGr_TipoProd.KeyDown
        Dim id, nombre As String
        If e.KeyData = Keys.Enter Then
            id = Convert.ToString(JGr_TipoProd.CurrentRow.Cells(2).Value)
            nombre = Convert.ToString(JGr_TipoProd.CurrentRow.Cells(3).Value)
            _PCargarGridProductos(id, Tb_CliCateg.Text)
            'poner el foco en productos
            GroupPanel1.Text = nombre
            JGr_Productos.Focus()
        End If
    End Sub

    Private Sub JGr_Productos_KeyDown(sender As Object, e As KeyEventArgs) Handles JGr_Productos.KeyDown
        If e.KeyData = Keys.Enter Then
            'agregar al detalle producto seleccionado
            Dim codProd, descrip, precio As String

            codProd = Convert.ToString(JGr_Productos.CurrentRow.Cells("Codigo").Value)
            descrip = Convert.ToString(JGr_Productos.CurrentRow.Cells("Descripcion").Value)
            precio = Convert.ToString(JGr_Productos.CurrentRow.Cells("Precio").Value)

            Dim nuevaFila As DataRow = CType(JGr_DetallePedido.DataSource, DataTable).NewRow()

            nuevaFila(1) = codProd
            nuevaFila(2) = descrip
            nuevaFila(4) = precio

            CType(JGr_DetallePedido.DataSource, DataTable).Rows.Add(nuevaFila)

            'poner el foco en cantidad
            Tb_CantProd.Text = "1"
            Tb_CantProd.Focus()
        End If

    End Sub

    Private Sub Tb_ProdObs_KeyDown(sender As Object, e As KeyEventArgs) Handles Tb_Observaciones.KeyDown
        If e.KeyData = Keys.Enter Then
            'Tb_Observaciones.Text = Tb_ProdObs.Text
            Btn_TerminarAdd.Focus()
            'Tb_CantProd.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub Btn_AddProd_Click(sender As Object, e As EventArgs) Handles Btn_AddProd.Click
        JGr_Productos.Focus()
        Tb_CantProd.Text = "1"
    End Sub

    Private Sub Btn_TerminarAdd_Click(sender As Object, e As EventArgs) Handles Btn_TerminarAdd.Click
        _PGrabarRegistro()
    End Sub

    Private Sub MBtGrabar_Click(sender As Object, e As EventArgs) Handles MBtGrabar.Click
        _PGrabarRegistro()
    End Sub

    Private Sub JGr_DetallePedido_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_DetallePedido.EditingCell
        If e.Column.Index <> 3 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub JGr_TipoProd_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_TipoProd.EditingCell
        e.Cancel = True
    End Sub

    Private Sub JGr_Productos_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_Productos.EditingCell
        e.Cancel = True
    End Sub

    Private Sub JGr_Clientes_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_Clientes.EditingCell
        e.Cancel = True
    End Sub

    Private Sub MBtPrimero_Click(sender As Object, e As EventArgs) Handles MBtPrimero.Click
        _PPrimerRegistro()
    End Sub

    Private Sub MBtAnterior_Click(sender As Object, e As EventArgs) Handles MBtAnterior.Click
        _PAnteriorRegistro()
    End Sub

    Private Sub MBtSiguiente_Click(sender As Object, e As EventArgs) Handles MBtSiguiente.Click
        _PSiguienteRegistro()
    End Sub

    Private Sub MBtUltimo_Click(sender As Object, e As EventArgs) Handles MBtUltimo.Click
        _PUltimoRegistro()
    End Sub

    Private Sub MBtSalir_Click(sender As Object, e As EventArgs) Handles MBtSalir.Click
        _PSalirRegistro()
    End Sub

    Private Sub JGr_DetallePedido_KeyDown(sender As Object, e As KeyEventArgs) Handles JGr_DetallePedido.KeyDown
        If e.KeyData = Keys.Delete And JGr_DetallePedido.Row >= 0 Then
            JGr_DetallePedido.CurrentRow.Delete()
        End If
    End Sub


    Private Sub JGr_DetallePedido_UpdatingCell(sender As Object, e As UpdatingCellEventArgs) Handles JGr_DetallePedido.UpdatingCell
        Dim cantidad, precio As Double
        cantidad = e.Value
        precio = JGr_DetallePedido.CurrentRow.Cells("Precio").Value
        JGr_DetallePedido.CurrentRow.Cells("Monto").Value = cantidad * precio
    End Sub

    Private Sub MBtModificar_Click(sender As Object, e As EventArgs) Handles MBtModificar.Click
        _PModificarRegistro()
    End Sub

    Private Sub MBtEliminar_Click(sender As Object, e As EventArgs) Handles MBtEliminar.Click
        _PEliminarRegistro()
    End Sub

    Private Sub JGr_Clientes_SelectionChanged(sender As Object, e As EventArgs) Handles JGr_Clientes.SelectionChanged
        If JGr_Clientes.Row >= 0 Then
            Dim codCliente As Integer = JGr_Clientes.GetValue(0)
            _PCargarGridRegistrosPedidos(JGr_UltimosPedidos, codCliente)
            If IsDBNull(L_GetCliente2(codCliente).Tables(0).Rows(0).Item("ccprconsu")) = False Then
                Tb_PromCosumo.Text = L_GetCliente2(codCliente).Tables(0).Rows(0).Item("ccprconsu")
            End If
            'Dim dt As DataTable
            'dt = L_PedidoCabecera_GeneralTop10(-1, " AND oaccli=" + codCliente.ToString + " AND oaest>=1 AND oaest<=4 ")
            'Tb_TotalPedidos.Text = dt.Rows.Count

            Dim dtTop3meses As DataTable
            dtTop3meses = L_PedidoCabecera_GeneralTotal3Meses(-1, " AND oaccli=" + codCliente.ToString + " AND oaest>=1 AND oaest<=4 ")
            Tb_TotalPedidos3Meses.Text = dtTop3meses.Rows.Count

            Try
                Tb_DireccionDetalle.Text = IIf(IsDBNull(JGr_Clientes.CurrentRow.Cells("CliDireccion").Value), "", JGr_Clientes.CurrentRow.Cells("CliDireccion").Value)
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub JGr_UltimosPedidos_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_UltimosPedidos.EditingCell
        e.Cancel = True
    End Sub

    Private Sub JGr_UltimosPedidos_SelectionChanged(sender As Object, e As EventArgs) Handles JGr_UltimosPedidos.SelectionChanged
        If (JGr_UltimosPedidos.GetRows.Count > 0) Then
            Tb_Obs.Text = IIf(IsDBNull(JGr_UltimosPedidos.GetValue(4)), "", JGr_UltimosPedidos.GetValue(4))
            Tb_Obs2.Text = IIf(IsDBNull(JGr_UltimosPedidos.GetValue(5)), "", JGr_UltimosPedidos.GetValue(5))
            Dim idPedido As String = JGr_UltimosPedidos.GetValue(0)
            _PCargarGridReclamos(idPedido)
        End If
    End Sub

    Private Sub JGr_UltimosPedidos_DoubleClick(sender As Object, e As EventArgs) Handles JGr_UltimosPedidos.DoubleClick
        If JGr_UltimosPedidos.Row >= 0 Then
            Dim frmReclamos As P_ReclamoAyuda
            Dim codPedido As Integer = JGr_UltimosPedidos.GetValue("Cod")
            frmReclamos = New P_ReclamoAyuda(codPedido)
            frmReclamos.ShowDialog()
        End If
    End Sub

    Private Sub Btn_Check1_Click(sender As Object, e As EventArgs) Handles Btn_Check1.Click
        If Btn_Check1.Tag = 0 Then
            'Btn_Check1.Enabled = False
            Btn_Check2.Enabled = True
            Btn_Check3.Enabled = True

            GrB_FrecSemanal.Enabled = True
            GrB_FrecMensual.Enabled = False
            GrB_FrecEnDias.Enabled = False

            Btn_Check1.Image = My.Resources.CHECK_ORI
            Btn_Check2.Image = My.Resources.UNCHECK_ORI
            Btn_Check3.Image = My.Resources.UNCHECK_ORI

            GrB_FrecSemanal.BackColor = Color.LightSkyBlue
            GrB_FrecEnDias.BackColor = Color.Transparent
            GrB_FrecMensual.BackColor = Color.Transparent

            Btn_Check1.Tag = 1
            Btn_Check2.Tag = 0
            Btn_Check3.Tag = 0
        End If


    End Sub

    Private Sub Btn_Check2_Click(sender As Object, e As EventArgs) Handles Btn_Check2.Click
        If Btn_Check2.Tag = 0 Then
            Btn_Check1.Enabled = True
            'Btn_Check2.Enabled = False
            Btn_Check3.Enabled = True

            GrB_FrecSemanal.Enabled = False
            GrB_FrecMensual.Enabled = False
            GrB_FrecEnDias.Enabled = True

            Btn_Check1.Image = My.Resources.UNCHECK_ORI
            Btn_Check2.Image = My.Resources.CHECK_ORI
            Btn_Check3.Image = My.Resources.UNCHECK_ORI

            GrB_FrecSemanal.BackColor = Color.Transparent
            GrB_FrecEnDias.BackColor = Color.LightSkyBlue
            GrB_FrecMensual.BackColor = Color.Transparent

            Btn_Check1.Tag = 0
            Btn_Check2.Tag = 1
            Btn_Check3.Tag = 0
        End If

    End Sub

    Private Sub Btn_Check3_Click(sender As Object, e As EventArgs) Handles Btn_Check3.Click
        If Btn_Check3.Tag = 0 Then
            Btn_Check1.Enabled = True
            Btn_Check2.Enabled = True
            'Btn_Check3.Enabled = False

            GrB_FrecSemanal.Enabled = False
            GrB_FrecMensual.Enabled = True
            GrB_FrecEnDias.Enabled = False

            Btn_Check1.Image = My.Resources.UNCHECK_ORI
            Btn_Check2.Image = My.Resources.UNCHECK_ORI
            Btn_Check3.Image = My.Resources.CHECK_ORI

            GrB_FrecSemanal.BackColor = Color.Transparent
            GrB_FrecEnDias.BackColor = Color.Transparent
            GrB_FrecMensual.BackColor = Color.LightSkyBlue

            Btn_Check1.Tag = 0
            Btn_Check2.Tag = 0
            Btn_Check3.Tag = 1
        End If

    End Sub

    Private Sub Btn_GenerarPedidos_Click(sender As Object, e As EventArgs) Handles Btn_GenerarPedidos.Click
        _PGenerarPedidosPeriodicamente()
    End Sub

    Private Sub VERHISTORIALToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VERHISTORIALToolStripMenuItem.Click
        If JGr_Buscador.Row >= 0 Then
            Dim frmReclamos As P_HistorialAyuda
            Dim codPedido As Integer = JGr_Buscador.GetValue("oanumi")
            frmReclamos = New P_HistorialAyuda(codPedido)
            frmReclamos.ShowDialog()
        End If
    End Sub

    Private Sub JGr_Buscador_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_Buscador.EditingCell
        e.Cancel = True
    End Sub

    Private Sub VERHISTORIALToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VERHISTORIALToolStripMenuItem1.Click
        Dim frmReclamos As P_HistorialAyuda
        Dim codPedido As Integer = JGr_UltimosPedidos.GetValue("Cod")
        frmReclamos = New P_HistorialAyuda(codPedido)
        frmReclamos.ShowDialog()
    End Sub

    Private Sub ACTUALIZARCLIENTESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ACTUALIZARCLIENTESToolStripMenuItem.Click
        'pbCargando.IsRunning = True
        'pbCargando.Visible = True
        'pbCargando.Refresh()
        _PCargarGridClientes()
        'pbCargando.IsRunning = False
        'pbCargando.Visible = False
    End Sub

    Private Sub VERCLIENTESPASIVOSYACTIVOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VERCLIENTESPASIVOSYACTIVOSToolStripMenuItem.Click
        _PCargarGridClientes(True)
    End Sub

    Private Sub VERCLIENTESACTIVOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VERCLIENTESACTIVOSToolStripMenuItem.Click
        _PCargarGridClientes()
    End Sub

    Private Sub P_Pedidos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MBtGrabar.Enabled = True Then
            If (MessageBox.Show("ESTA SEGURO DE SALIR SIN GUARDAR?", "AVERTENCIA", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK) Then
                Me.Dispose()
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub FlyoutUsuario_PrepareContent(sender As Object, e As EventArgs) Handles MFlyoutUsuario.PrepareContent
        If sender Is MBubbleBarUsuario And MBtGrabar.Enabled = False Then
            Dim dtAud As DataTable = L_ObtenerAuditoria("TO001", "oa", "oanumi=" + Tb_Id.Text)
            If IsDBNull(dtAud.Rows(0).Item(0)) = True Then
                MLbFecha.Text = ""
            Else
                MLbFecha.Text = Convert.ToDateTime(dtAud.Rows(0).Item(0)).ToString("dd/MM/yyyy")
            End If
            MLbHora.Text = dtAud.Rows(0).Item(1).ToString
            MLbUsuario.Text = dtAud.Rows(0).Item(2).ToString
            MFlyoutUsuario.BorderColor = Color.FromArgb(&HC0, 0, 0)
            MFlyoutUsuario.Content = MPnUsuario
        End If

    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As SuperTabStripSelectedTabChangedEventArgs) Handles MSuperTabControlPrincipal.SelectedTabChanged 'SuperTabControl1.SelectedTabChanged
        If e.NewValue.ToString = "REGISTRO" And _Nuevo = False Then
            If JGr_Buscador.RowCount > 0 Then
                _Pos = 0
                _PMostrarRegistro(0)
            Else
                MLbPaginacion.Text = 0
            End If

        End If
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        _PCargarBuscador(" and oafdoc>='" + tbFechaDel.Value.Date.ToString("yyyy/MM/dd") + "' and oafdoc<='" + tbFechaAl.Value.Date.ToString("yyyy/MM/dd") + "'")
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles Btn_AddProd.Click
        _PCargarBuscador()
    End Sub

    Private Sub REGERARPEDIDOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REGERARPEDIDOToolStripMenuItem.Click

    End Sub

    Private Sub Tb_Id_Enter(sender As Object, e As EventArgs) Handles Tb_Id.Enter
        Tb_Observaciones.Focus()
    End Sub

    Private Sub MBtUsuario_Click(sender As Object, e As ClickEventArgs) Handles MBtUsuario.Click
        FlyoutUsuario_PrepareContent(MBubbleBarUsuario, e)
    End Sub

    Private Sub Tb_CantProd_KeyDown(sender As Object, e As KeyEventArgs) Handles Tb_CantProd.KeyDown
        If e.KeyData = Keys.Enter Then
            Dim precio As Double
            JGr_DetallePedido.Row = JGr_DetallePedido.RowCount - 1
            JGr_DetallePedido.CurrentRow.Cells("Cantidad").Value = Tb_CantProd.Text
            precio = JGr_DetallePedido.CurrentRow.Cells("Precio").Value
            JGr_DetallePedido.CurrentRow.Cells("Monto").Value = CDbl(Tb_CantProd.Text) * precio

            Tb_Observaciones.Focus()
            'Tb_CantProd.Text = ""
        End If
    End Sub

    Private Sub Tb_CantProd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tb_CantProd.KeyPress
        g_prValidarTextBox(3, e, sender)
    End Sub

    Private Sub P_prArmarCombos()
        P_prArmarComboDistribuidor()
        P_prArmarComboPreVendedor()
    End Sub

    Private Sub P_prArmarComboDistribuidor()
        Dim dt As DataTable
        dt = L_fnObtenerTabla("cbnumi as [cod], cbdesc as [desc]", "TC002", "cbcat=1")
        g_prArmarCombo(cbDistribuidor, dt, 60, 200, "Código", "Distribuidor")
    End Sub

    Private Sub P_prArmarComboPreVendedor()
        Dim dt As DataTable
        dt = L_fnObtenerTabla("cbnumi as [cod], cbdesc as [desc]", "TC002", "cbcat=3")
        g_prArmarCombo(cbPreVendedor, dt, 60, 200, "Código", "Pre-Vendedor")
    End Sub

    Private Sub btActualizar_Click(sender As Object, e As EventArgs) Handles btActualizar.Click
        If (Not MBtGrabar.Enabled) Then
            _PCargarBuscador()
            _PFiltrar()
        Else
            ToastNotification.Show(Me,
                                   "No se puede actualizar los datos cuando se esta haciendo un nuevo registro o modificación de registro.".ToUpper,
                                   My.Resources.WARNING,
                                   1000 * 5,
                                   eToastGlowColor.Red,
                                   eToastPosition.TopCenter)
        End If
    End Sub

    Private Sub QuitarItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarItemToolStripMenuItem.Click
        If (MBtGrabar.Enabled) Then
            Try
                JGr_DetallePedido.CurrentRow.EndEdit()
                JGr_DetallePedido.CurrentRow.Delete()
                JGr_DetallePedido.Refetch()
                JGr_DetallePedido.Refresh()
            Catch ex As Exception
                'sms
                'MsgBox(ex)
            End Try
        Else
            ToastNotification.Show(Me,
                                   "Para eliminar el item tiene que estar en acción nuevo o modificar".ToUpper,
                                   My.Resources.WARNING,
                                   1000 * 5,
                                   eToastGlowColor.Red,
                                   eToastPosition.TopCenter)
        End If
    End Sub

    Private Sub cbDistribuidor_ValueChanged(sender As Object, e As EventArgs) Handles cbDistribuidor.ValueChanged
        If (MBtGrabar.Enabled) Then
            If (Not IsNothing(cbDistribuidor.Value)) Then
                Dim dt As DataTable = L_fnObtenerTabla("b.lcnumi, d.cedesc",
                                                      "TL001 a inner join TL0012 b on a.lanumi=b.lcnumi
	                                                   inner join TC002 c on b.lccbnumi=c.cbnumi and c.cbcat=1
	                                                   inner join TC0051 d on a.lazona=d.cenum and d.cecon=2",
                                                      "b.lccbnumi=" + cbDistribuidor.Value.ToString)
                If (dt.Rows.Count > 0) Then
                    Tb_CliCodZona.Text = dt.Rows(0).Item("lcnumi").ToString
                    Tb_Zona.Text = dt.Rows(0).Item("cedesc").ToString
                End If
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim estado As Integer = JGr_UltimosPedidos.GetValue("oaest")
        If estado = 1 Or estado = 2 Then
            Dim codPedido As Integer = JGr_UltimosPedidos.GetValue("Cod")

            Dim frm As New F0_IngresarReclamo(codPedido, "1", "1")
            frm.ShowDialog()
            If frm.respuesta = True Then
                _PCargarGridReclamos(codPedido)

                If JGr_Clientes.Row >= 0 Then
                    Dim codCliente As Integer = JGr_Clientes.GetValue(0)
                    _PCargarGridRegistrosPedidos(JGr_UltimosPedidos, codCliente)

                End If
            End If
        Else
            MessageBox.Show("no se puede grabar reclamo por que este pedido ya esta entregado".ToUpper)
        End If
    End Sub

    Private Sub GRABARRECLAMOREPARTIDORToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GRABARRECLAMOREPARTIDORToolStripMenuItem.Click
        'grabo el reclamo del pedido
        Dim estado As Integer = JGr_UltimosPedidos.GetValue("oaest")
        If estado = 1 Or estado = 2 Then
            Dim codPedido As Integer = JGr_UltimosPedidos.GetValue("Cod")

            Dim frm As New F0_IngresarReclamo(codPedido, "1", "2")
            frm.ShowDialog()
            If frm.respuesta = True Then
                _PCargarGridReclamos(codPedido)

                If JGr_Clientes.Row >= 0 Then
                    Dim codCliente As Integer = JGr_Clientes.GetValue(0)
                    _PCargarGridRegistrosPedidos(JGr_UltimosPedidos, codCliente)
                End If
            End If
        Else
            MessageBox.Show("no se puede grabar reclamo por que este pedido ya esta entregado".ToUpper)
        End If
    End Sub

    Private Sub ANULARPEDIDOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ANULARPEDIDOToolStripMenuItem.Click
        Dim codPedido As Integer = JGr_UltimosPedidos.GetValue("Cod")

        Dim frm As New F0_IngresarReclamo(codPedido, "1", "3")
        frm.ShowDialog()
        If frm.respuesta = True Then
            'L_PedidoCabacera_ModificarEstado(codPedido, "8")
            L_PedidoCabacera_ModificarActivoPasivo(codPedido, "2")

            'actualizar la grilla
            If JGr_Clientes.Row >= 0 Then
                Dim codCliente As Integer = JGr_Clientes.GetValue(0)
                _PCargarGridRegistrosPedidos(JGr_UltimosPedidos, codCliente)
            End If
        End If
    End Sub

    Private Sub JGr_TipoProd_FormattingRow(sender As Object, e As RowLoadEventArgs) Handles JGr_TipoProd.FormattingRow

    End Sub
End Class