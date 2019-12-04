Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class R01_EquipoPrestadoVsVenta

#Region "Atributos generales"

    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

#End Region

#Region "Variables Globales"

    Dim InDuracion As Byte = 5

#End Region

#Region "Eventos"

    Private Sub My_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        P_prInicio()
    End Sub

    Private Sub SbFiltroCliente_ValueChanged(sender As Object, e As EventArgs) Handles SbFiltroTodosUno.ValueChanged
        btBuscarProducto.Enabled = SbFiltroTodosUno.Value
        If (Not SbFiltroTodosUno.Value) Then
            tbCodigoProducto.Clear()
            tbDescripcionProducto.Clear()
        End If
    End Sub

    Private Sub TbCodigoCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles tbCodigoProducto.KeyDown
        If (e.KeyData = Keys.Control + Keys.Enter) Then
            P_prCargarAyudaProducto()
        End If
    End Sub

    Private Sub BtBuscarCliente_Click_1(sender As Object, e As EventArgs) Handles btBuscarProducto.Click
        P_prCargarAyudaProducto()
    End Sub

    Private Sub MBtGenerar_Click(sender As Object, e As EventArgs) Handles MBtGenerar.Click
        P_prCargarReporte()
    End Sub

    Private Sub MBtSalir_Click(sender As Object, e As EventArgs) Handles MBtSalir.Click
        Me.Close()
        _modulo.Select()
        _tab.Close()
    End Sub

#End Region

#Region "Metodos"

    Private Sub P_prInicio()
        'Abrir conexion
        If (Not gb_ConexionAbierta) Then
            L_prAbrirConexion()
        End If

        Me.Text = "P R E S T A M O   D E   E Q U I P O S   V S   V E N T A S   R E A L I Z A D A S ".ToUpper
        Me.WindowState = FormWindowState.Maximized
        MCrReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

        tbCodigoProducto.ReadOnly = True
        tbDescripcionProducto.ReadOnly = True
        btBuscarProducto.Enabled = False

        DtiDesde.Value = Now.Date
        DtiHasta.Value = Now.Date
    End Sub

    Private Sub P_prCargarReporte()
        Dim dt As New DataTable
        Dim produto As String = ""
        If (DtiDesde.Value > DtiHasta.Value) Then
            ToastNotification.Show(Me, "La fecha desde debe ser menor o igual a la fecha hasta.".ToUpper,
                                       My.Resources.INFORMATION, InDuracion * 500,
                                       eToastGlowColor.Blue,
                                       eToastPosition.BottomLeft)
            Return
        End If

        Dim desde As String = DtiDesde.Value.ToString("yyyy/MM/dd")
        Dim hasta As String = DtiHasta.Value.ToString("yyyy/MM/dd")
        If (Not SbFiltroTodosUno.Value) Then
            'Todos
            produto = "TODOS"
            dt = L_fnPrestamoEquipoVsVenta("0", desde, hasta, tbCodigoCliente.Text.Trim, tbNombreCliente.Text.Trim)
        Else
            'Filtro un cliente
            If (Not tbCodigoProducto.Text.Trim = String.Empty) Then
                'Se elijio un cliente
                produto = tbCodigoProducto.Text + " - " + tbDescripcionProducto.Text.Trim
                dt = L_fnPrestamoEquipoVsVenta(tbCodigoProducto.Text.Trim, desde, hasta, tbCodigoCliente.Text.Trim, tbNombreCliente.Text.Trim)
            Else
                'No ha eligido un cliente
                ToastNotification.Show(Me, "el código de procucto no es valido, coloque un código valido..".ToUpper,
                                       My.Resources.INFORMATION, InDuracion * 500,
                                       eToastGlowColor.Blue,
                                       eToastPosition.BottomLeft)
                Exit Sub
            End If
        End If

        If (dt.Rows.Count > 0) Then
            Dim objrep As New R_PrestamoEquipoPrestadoVsVenta
            objrep.SetDataSource(dt)
            objrep.SetParameterValue("Desde", desde)
            objrep.SetParameterValue("Hasta", hasta)
            objrep.SetParameterValue("Producto", produto)

            MCrReporte.ReportSource = objrep
            MCrReporte.Show()
            MCrReporte.BringToFront()
        Else
            ToastNotification.Show(Me, "no hay datos para los parametros seleccionados.".ToUpper,
                                       My.Resources.INFORMATION, InDuracion * 500,
                                       eToastGlowColor.Blue,
                                       eToastPosition.BottomLeft)
            MCrReporte.ReportSource = Nothing
        End If
    End Sub

    Private Sub P_prCargarAyudaProducto()
        If (SbFiltroTodosUno.Value) Then
            Dim frmAyuda As Modelo.ModeloAyuda
            Dim dt As DataTable = L_ProductosGeneral(1, "caserie=0").Tables(0)
            Dim listEstCeldas As New List(Of Modelo.MCelda)
            'b.ccnumi, b.ccdctnum, b.ccdesc, b.ccdirec
            listEstCeldas.Add(New Modelo.MCelda("canumi", True, "Codigo", 80))
            listEstCeldas.Add(New Modelo.MCelda("cadesc", True, "Descripción", 300))
            listEstCeldas.Add(New Modelo.MCelda("cadesc2", True, "Descripción corta", 150))

            frmAyuda = New Modelo.ModeloAyuda(550, 400, dt, "Seleccione un producto".ToUpper, listEstCeldas)
            frmAyuda.StartPosition = FormStartPosition.CenterScreen
            frmAyuda.ShowDialog()

            If frmAyuda.seleccionado = True Then
                Dim id As String = frmAyuda.filaSelect.Cells("canumi").Value
                Dim descr As String = frmAyuda.filaSelect.Cells("cadesc").Value

                tbCodigoProducto.Text = id
                tbDescripcionProducto.Text = descr
            End If
        End If
    End Sub

#End Region

End Class