Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class R01_PrestamoEquiposAgrupado

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

    Private Sub SbFiltroCliente_ValueChanged(sender As Object, e As EventArgs) Handles SbFiltroCliente.ValueChanged
        BtBuscarCliente.Enabled = SbFiltroCliente.Value
        'TbCodigoCliente.Enabled = SbFiltroCliente.Value
        If (Not SbFiltroCliente.Value) Then
            TbCodigoCliente.Clear()
            TbNombreCliente.Clear()
        End If
    End Sub

    Private Sub TbCodigoCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles TbCodigoCliente.KeyDown
        If (e.KeyData = Keys.Control + Keys.Enter) Then
            P_prCargarAyudaCliente()
        End If
    End Sub

    Private Sub BtBuscarCliente_Click_1(sender As Object, e As EventArgs) Handles BtBuscarCliente.Click
        P_prCargarAyudaCliente()
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

        Me.Text = "K A R D E X   P R E S T A M O   A G R U P A D O".ToUpper
        Me.WindowState = FormWindowState.Maximized
        MCrReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

        TbCodigoCliente.ReadOnly = True
        TbNombreCliente.ReadOnly = True
        BtBuscarCliente.Enabled = False
    End Sub

    Private Sub P_prCargarReporte()
        Dim dt As New DataTable
        Dim cliente As String = ""
        If (Not SbFiltroCliente.Value) Then
            'Todos
            cliente = "TODOS"
            dt = L_VistaPrestamoEquiposAgrupado()
        Else
            'Filtro un cliente
            If (Not TbCodigoCliente.Text.Trim = String.Empty) Then
                'Se elijio un cliente
                cliente = TbNombreCliente.Text.Trim
                dt = L_VistaPrestamoEquiposAgrupado(TbCodigoCliente.Text.Trim)
            Else
                'No ha eligido un cliente
                ToastNotification.Show(Me, "el código de cliente no es valido, coloque un código valido..".ToUpper,
                                       My.Resources.INFORMATION, InDuracion * 500,
                                       eToastGlowColor.Blue,
                                       eToastPosition.BottomLeft)
                Exit Sub
            End If
        End If

        If (dt.Rows.Count > 0) Then
            Dim objrep As New R_PrestamoEquiposAgrupado
            objrep.SetDataSource(dt)

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

    Private Sub P_prCargarAyudaCliente()
        If (SbFiltroCliente.Value) Then
            Dim frmAyuda As Modelo.ModeloAyuda
            Dim dt As DataTable = L_GetClientesSimple2().Tables(0)
            Dim listEstCeldas As New List(Of Modelo.MCelda)
            'b.ccnumi, b.ccdctnum, b.ccdesc, b.ccdirec
            listEstCeldas.Add(New Modelo.MCelda("ccnumi", True, "Codigo", 80))
            listEstCeldas.Add(New Modelo.MCelda("ccdctnum", True, "CI", 100))
            listEstCeldas.Add(New Modelo.MCelda("ccdesc", True, "Nombre", 300))
            listEstCeldas.Add(New Modelo.MCelda("ccdirec", True, "Direccion", 200))

            frmAyuda = New Modelo.ModeloAyuda(750, 400, dt, "Seleccione un cliente".ToUpper, listEstCeldas)
            frmAyuda.StartPosition = FormStartPosition.CenterScreen
            frmAyuda.ShowDialog()

            If frmAyuda.seleccionado = True Then
                Dim id As String = frmAyuda.filaSelect.Cells("ccnumi").Value
                Dim descr As String = frmAyuda.filaSelect.Cells("ccdesc").Value

                TbCodigoCliente.Text = id
                TbNombreCliente.Text = descr
            End If
        End If
    End Sub

#End Region

End Class