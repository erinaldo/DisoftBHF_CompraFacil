Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar.SuperGrid
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class F01_KardexInventarioEquiProd

#Region "Atributos generales"

    Private stTitulo As String = "K A R D E X   D E   E Q U I P O"
    Private inTipo As Byte = 1

    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

#End Region

#Region "Propiedades generales"

    Public Property Titulo() As String
        Get
            Return stTitulo
        End Get
        Set(ByVal valor As String)
            stTitulo = valor
        End Set
    End Property

    Public Property Tipo() As Byte
        Get
            Return inTipo
        End Get
        Set(ByVal valor As Byte)
            inTipo = valor
        End Set
    End Property

#End Region

#Region "Variables Globales"

    Dim Dt1Kardex As DataTable
    Dim Dt2KardexTotal As DataTable
    Dim inDuracion As Integer = 5

#End Region

#Region "Eventos"

    Private Sub My_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        P_prInicio()
    End Sub

    Private Sub Bt1BuscarCliente_Click(sender As Object, e As EventArgs) Handles Bt1BuscarCliente.Click
        P_FiltrarGridBusqueda()
    End Sub

    Private Sub Bt3Generar_Click(sender As Object, e As EventArgs) Handles Bt3Generar.Click
        P_GenerarKardexCliente()
    End Sub

#End Region

#Region "Medotos"

    Private Sub P_prInicio()
        'Abrir conexion
        If (Not gb_ConexionAbierta) Then
            L_prAbrirConexion()
        End If

        Me.Text = Titulo
        Me.WindowState = FormWindowState.Maximized

        MRlAccion.Text = IIf(Tipo = 1, "KARDEX DE EQUIPO", "KARDEX DE PRODUCTO")
        lbEquiProd.Text = IIf(Tipo = 1, "Equipo", "Producto")
        GroupPanelKardex.Text = IIf(Tipo = 1, "HISTORIAL KARDEX DE EQUIPO", "HISTORIAL KARDEX DE PRODUCTO")
        GroupPanelBusqueda.Text = IIf(Tipo = 1, "BUSQUEDA DE EQUIPO", "BUSQUEDA DE PRODUCTO")

        MBtNuevo.Visible = False
        MBtModificar.Visible = False
        MBtEliminar.Visible = False
        MBtGrabar.Visible = False
        MPanelToolBarNavegacion.Visible = False

        MSuperTabItemBusqueda.Visible = False
        MSuperTabControlPrincipal.SelectedTabIndex = 0

        Dti1FechaIni.Value = Now.Date
        Dti2FechaFin.Value = Now.Date

        P_ArmarGrillaDatos()
        P_ArmarGrillaAyuda()

        Tb1CodEquipo.Select()
    End Sub

#End Region

    Private Sub P_ArmarGrillaDatos() 'Para los datos de Kardex de Cliente
        'Datos
        Dt1Kardex = New DataTable
        Dt2KardexTotal = New DataTable
        If (Tb1CodEquipo.Text.Length > 0) Then
            Dt2KardexTotal = L_VistaKardexInventarioTodo(Tb1CodEquipo.Text, Dti1FechaIni.Value.ToString("yyyy/MM/dd")).Tables(0)
            Dt1Kardex = L_VistaKardexInventario(Tb1CodEquipo.Text, Dti1FechaIni.Value.ToString("yyyy/MM/dd"), Dti2FechaFin.Value.ToString("yyyy/MM/dd")).Tables(0)
            If (Dt1Kardex.Rows.Count > 0) Then
                P_ArmarKardex()
            Else
                ToastNotification.Show(Me, "No hay kardex para el rango de fecha".ToUpper,
                       My.Resources.INFORMATION,
                       inDuracion * 1000,
                       eToastGlowColor.Blue,
                       eToastPosition.BottomLeft)
            End If
        Else
            Dt1Kardex = L_VistaKardexInventario("-1", Dti1FechaIni.Value.ToString("yyyy/MM/dd"), Dti2FechaFin.Value.ToString("yyyy/MM/dd")).Tables(0)
        End If

        Dgj1Datos.BoundMode = Janus.Data.BoundMode.Bound
        Dgj1Datos.DataSource = Dt1Kardex
        Dgj1Datos.RetrieveStructure()

        'dar formato a las columnas
        With Dgj1Datos.RootTable.Columns(0)
            .Caption = ""
            .Key = "id"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Datos.RootTable.Columns(1)
            .Caption = "Fecha"
            .Key = "fdoc"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With Dgj1Datos.RootTable.Columns(2)
            .Caption = ""
            .Key = "concep"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With Dgj1Datos.RootTable.Columns(3)
            .Caption = "Concepto"
            .Key = "descConcep"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Datos.RootTable.Columns(4)
            .Caption = "Observación"
            .Key = "obs"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With Dgj1Datos.RootTable.Columns(5)
            .Caption = ""
            .Key = "est"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Datos.RootTable.Columns(6)
            .Caption = ""
            .Key = "alm"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Datos.RootTable.Columns(7)
            .Caption = ""
            .Key = "id2"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Datos.RootTable.Columns(8)
            .Caption = "Código"
            .Key = "cprod"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
            .FormatString = "0.00"
        End With
        With Dgj1Datos.RootTable.Columns(9)
            .Caption = IIf(Tipo = 1, "Equipo", "Producto")
            .Key = "descProd"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Datos.RootTable.Columns(10)
            .Caption = ""
            .Key = "desc2Prod"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Datos.RootTable.Columns(11)
            .Caption = "Cantidad"
            .Key = "cant"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
            .FormatString = "0.00"
        End With
        With Dgj1Datos.RootTable.Columns(12)
            .Caption = "Saldo"
            .Key = "saldo"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
            .FormatString = "0.00"
        End With
        With Dgj1Datos.RootTable.Columns(13)
            .Caption = "Cliente"
            .Key = "cliente"
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = IIf(Tipo = 1, True, False)
            .Position = 2

        End With

        'Habilitar Filtradores
        With Dgj1Datos
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            '.DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
            .AlternatingColors = True
            .RecordNavigator = True
            .RecordNavigatorText = "Kardex ->"
            .RowHeaders = InheritableBoolean.True
        End With
    End Sub

    Private Sub P_FiltrarGridBusqueda()
        MSuperTabItemBusqueda.Visible = True
        MSuperTabControlPrincipal.SelectedTabIndex = 1
        Dgj2Busqueda.Select()

        Dgj2Busqueda.RemoveFilters()

        Dgj2Busqueda.MoveTo(Dgj2Busqueda.FilterRow)
        Dgj2Busqueda.Col = 2
        Dgj2Busqueda.AlternatingColors = True
    End Sub

    Private Sub Tb1CodCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles Tb1CodEquipo.KeyDown
        If (e.KeyData = Keys.Control + Keys.Enter) Then
            P_FiltrarGridBusqueda()
        End If
    End Sub

    Private Sub Dgj2Busqueda_DoubleClick(sender As Object, e As EventArgs) Handles Dgj2Busqueda.DoubleClick
        If (Dgj2Busqueda.CurrentRow.RowIndex > -1) Then
            P_PonerDatosBusqueda()
        End If
    End Sub

    Private Sub Dgj2Busqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgj2Busqueda.KeyDown
        If (e.KeyData = Keys.Enter And Dgj2Busqueda.CurrentRow.RowIndex > -1) Then
            P_PonerDatosBusqueda()
        End If
    End Sub

    Private Sub P_PonerDatosBusqueda()
        Tb1CodEquipo.Text = Dgj2Busqueda.GetValue("canumi").ToString
        Tb2DescEquipo.Text = Dgj2Busqueda.GetValue("cadesc").ToString
        MSuperTabControlPrincipal.SelectedTabIndex = 0

        'Ponemos el Saldo Total
        If (L_ObtenerStockInventario(1, Tb1CodEquipo.Text).Tables(0).Rows.Count > 0) Then
            Tb3Saldo.Text = L_ObtenerStockInventario(1, Tb1CodEquipo.Text).Tables(0).Rows(0).Item("Cantidad").ToString
        Else
            Tb3Saldo.Text = "0"
        End If

        Dti1FechaIni.Select()
    End Sub

    Private Sub Dgj2Busqueda_EditingCell(sender As Object, e As EditingCellEventArgs) Handles Dgj2Busqueda.EditingCell
        e.Cancel = True
    End Sub

    Private Sub MSuperTabControlPrincipal_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles MSuperTabControlPrincipal.SelectedTabChanged
        'Cuando se cambia de Tab, si va al Tab Registro el Tab Busqueda se pone visible=false
        MSuperTabItemBusqueda.Visible = Not MSuperTabControlPrincipal.SelectedTabIndex = 0
    End Sub

    Private Sub P_GenerarKardexCliente()
        P_ArmarGrillaDatos()
    End Sub

    Private Sub P_ArmarGrillaAyuda() 'Grilla para Buscar Clientes
        'Busqueda
        Dim dt As New DataTable
        dt = L_GetProductos(" caest=1 AND caserie=" + IIf(Tipo = 1, "1", "0")).Tables(0)

        Dgj2Busqueda.BoundMode = Janus.Data.BoundMode.Bound
        Dgj2Busqueda.DataSource = dt
        Dgj2Busqueda.RetrieveStructure()
        'canumi, cacod, cadesc, cadesc2, cacat, TC0051.cedesc, caimg, castc, caest, caserie
        'dar formato a las columnas
        With Dgj2Busqueda.RootTable.Columns(0)
            .Caption = "Código"
            .Key = "canumi"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With Dgj2Busqueda.RootTable.Columns(1)
            .Caption = ""
            .Key = "cacod"
            .Width = 10
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With Dgj2Busqueda.RootTable.Columns(2)
            .Caption = "Descripción"
            .Key = "cadesc"
            .Width = 250
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With Dgj2Busqueda.RootTable.Columns(3)
            .Caption = "Descripción Corta"
            .Key = "cadesc2"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj2Busqueda.RootTable.Columns(4)
            .Caption = ""
            .Key = "cacat"
            .Width = 10
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With Dgj2Busqueda.RootTable.Columns(5)
            .Caption = ""
            .Key = "cedesc"
            .Width = 10
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj2Busqueda.RootTable.Columns(6)
            .Caption = ""
            .Key = "caimg"
            .Width = 10
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With Dgj2Busqueda.RootTable.Columns(7)
            .Caption = ""
            .Key = "castc"
            .Width = 10
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj2Busqueda.RootTable.Columns(8)
            .Caption = ""
            .Key = "caest"
            .Width = 10
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj2Busqueda.RootTable.Columns(9)
            .Caption = ""
            .Key = "caserie"
            .Width = 10
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        'Habilitar Filtradores
        With Dgj2Busqueda
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
        End With
        'Dgj1Busqueda.Dock = DockStyle.Fill
        Dgj2Busqueda.BringToFront()
    End Sub

    Private Sub Dgj1Datos_EditingCell(sender As Object, e As EditingCellEventArgs) Handles Dgj1Datos.EditingCell
        e.Cancel = True
    End Sub

    Private Sub P_ArmarKardex()

        Dim saldo As Double = 0
        Dim ingT As Double = 0
        Dim salT As Double = 0

        If (Not IsDBNull(Dt2KardexTotal.Compute("Sum(cant)", "cprod = " + Tb1CodEquipo.Text + " and concep = 1"))) Then
            ingT = Dt2KardexTotal.Compute("Sum(cant)", "cprod = " + Tb1CodEquipo.Text + " and concep = 1")
        End If
        If (Not IsDBNull(Dt2KardexTotal.Compute("Sum(cant)", "cprod = " + Tb1CodEquipo.Text + " and concep = 2"))) Then
            salT = Dt2KardexTotal.Compute("Sum(cant)", "cprod = " + Tb1CodEquipo.Text + " and concep = 2")
        End If

        saldo = ingT + salT
        Dim ing As Double = 0
        Dim sal As Double = 0
        Dim saldoInicial As Double = 0
        'Sumar ingreso de inventario
        ing = IIf(IsDBNull(Dt1Kardex.Compute("Sum(cant)", "cprod = " + Tb1CodEquipo.Text + " and concep = 1")), 0, Dt1Kardex.Compute("Sum(cant)", "cprod = " + Tb1CodEquipo.Text + " and concep = 1"))
        'Sumar salida de inventario
        sal = IIf(IsDBNull(Dt1Kardex.Compute("Sum(cant)", "cprod = " + Tb1CodEquipo.Text + " and concep = 2")), 0, Dt1Kardex.Compute("Sum(cant)", "cprod = " + Tb1CodEquipo.Text + " and concep = 2"))
        'Saldo inicial al partir de la fecha indicada
        saldoInicial = saldo '+ sal + ing
        'Insertamos la primera fila con el saldo Inicial
        Dim f As DataRow
        'Dim st As System.Type
        f = Dt1Kardex.NewRow
        f.Item(0) = 0
        f.Item(1) = Dti1FechaIni.Value.ToShortDateString
        f.Item(2) = 0
        f.Item(3) = "SALDO INICIAL"
        f.Item(4) = "Saldo Inicial"
        f.Item(5) = 1
        f.Item(6) = 1
        f.Item(7) = 0
        f.Item(8) = Tb1CodEquipo.Text
        f.Item(9) = Tb2DescEquipo.Text
        f.Item(10) = ""
        f.Item(11) = 0
        f.Item(12) = saldoInicial
        f.Item(13) = ""

        Dt1Kardex.Rows.InsertAt(f, 0)

        For Each fil As DataRow In Dt1Kardex.Rows
            Dim s As String = fil.Item("concep").ToString
            If (fil.Item("concep").ToString.Equals("1")) Then
                saldoInicial = saldoInicial + CDbl(fil.Item("cant"))
                fil.Item("saldo") = saldoInicial
            ElseIf (fil.Item("concep").ToString.Equals("2")) Then
                saldoInicial = saldoInicial + CDbl(fil.Item("cant"))
                fil.Item("saldo") = saldoInicial
            End If
        Next

        P_prActualizarSaldo()

    End Sub

    Private Sub P_GenerarReporte()
        If Not IsNothing(P_Global.Visualizador) Then
            P_Global.Visualizador.Close()
        End If

        P_Global.Visualizador = New Visualizador
        Dim objrep As Object
        If (Tipo = 1) Then
            objrep = New R_KardexInventarioEquipos
        Else
            objrep = New R_KardexInventarioProducto
        End If
        objrep.SetDataSource(Dt1Kardex)
        objrep.SetParameterValue("FechaIni", Dti1FechaIni.Value.ToShortDateString)
        objrep.SetParameterValue("FechaFin", Dti2FechaFin.Value.ToShortDateString)
        objrep.SetParameterValue("Titulo", IIf(Tipo = 1, "Equipos", "Productos"))
        objrep.SetParameterValue("Saldo", CDbl(Dt1Kardex.Rows(Dt1Kardex.Rows.Count - 1).Item("saldo").ToString))

        P_Global.Visualizador.CRV1.ReportSource = objrep 'Comentar
        P_Global.Visualizador.Show() 'Comentar
        P_Global.Visualizador.BringToFront() 'Comentar
    End Sub

    Private Sub Tb1CodCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tb1CodEquipo.KeyPress
        g_prValidarTextBox(1, e)
    End Sub

    Private Sub P_prActualizarSaldo()
        If (Dt1Kardex.Rows.Count > 0) Then
            If (Now.Date = Dti2FechaFin.Value) Then
                If (CDbl(Tb3Saldo.Text) <> CDbl(Dt1Kardex.Rows(Dt1Kardex.Rows.Count - 1).Item("saldo").ToString)) Then
                    L_Actualizar_SaldoInventario(Tb1CodEquipo.Text, Dt1Kardex.Rows(Dt1Kardex.Rows.Count - 1).Item("saldo").ToString, "1") 'Cambiar luego por el almacen al que corresponde
                    Tb3Saldo.Text = Dt1Kardex.Rows(Dt1Kardex.Rows.Count - 1).Item("saldo").ToString
                End If
            End If
        End If
    End Sub

    Private Sub MBtImprimir_Click(sender As Object, e As EventArgs) Handles MBtImprimir.Click
        P_prImprimir()
    End Sub

    Private Sub P_prImprimir()
        If (Dgj1Datos.GetRows.Count > 0) Then
            P_GenerarReporte()
        Else
            ToastNotification.Show(Me, "No hay kardex para el rango de fecha".ToUpper,
                       My.Resources.INFORMATION,
                       inDuracion * 1000,
                       eToastGlowColor.Blue,
                       eToastPosition.BottomLeft)
        End If
    End Sub

    Private Sub MBtSalir_Click(sender As Object, e As EventArgs) Handles MBtSalir.Click
        Me.Close()
        Me._modulo.Select()
        Me._tab.Close()
    End Sub
End Class