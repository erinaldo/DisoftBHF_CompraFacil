
Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Public Class R0_UTilidadPorProducto

#Region "VARIABLES GLOBALES"
    Public _nameButton As String
    Public _tab As SuperTabItem
    Dim titulo As String = ""
    Public _modulo As SideNavItem

#End Region

    Public Sub _prIniciarTodo()

        If (Not gb_ConexionAbierta) Then
            L_prAbrirConexion()
        End If
        Me.WindowState = FormWindowState.Maximized
        '' L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        Me.Text = "REPORTE DE UTILIDADES"
        MCrReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        _IniciarComponentes()
    End Sub

    Public Sub _IniciarComponentes()

        tbFechaI.Value = Now.Date
        tbFechaF.Value = Now.Date

    End Sub


    Private Sub _prCargarReporte()
        Dim _dt As New DataTable
        If ((tbFechaI.Value.ToString = String.Empty) Or (tbFechaF.Value.ToString = String.Empty)) Then
            ToastNotification.Show(Me, "Selecione fechas Validas!!!",
                                       My.Resources.INFORMATION, 2000,
                                       eToastGlowColor.Blue,
                                       eToastPosition.BottomLeft)
            MCrReporte.ReportSource = Nothing
            Return
        End If

        _dt = L_prListarReporteUtilidadPorProducto(tbFechaI.Value.ToString("yyyy/MM/dd"), tbFechaF.Value.ToString("yyyy/MM/dd"))

        If (_dt.Rows.Count > 0) Then

            Dim objrep As New R_UtilidadPorProducto
            objrep.SetDataSource(_dt)
            Dim fechaI As String = tbFechaI.Value.ToString("dd/MM/yyyy")
            Dim fechaF As String = tbFechaF.Value.ToString("dd/MM/yyyy")
            objrep.SetParameterValue("FechaIni", fechaI)
            objrep.SetParameterValue("FechaFin", fechaF)
            objrep.SetParameterValue("Usuario", L_Usuario)
            MCrReporte.ReportSource = objrep
            MCrReporte.Show()
            MCrReporte.BringToFront()



        Else
            ToastNotification.Show(Me, "NO HAY DATOS PARA LOS PARAMETROS SELECCIONADOS..!!!",
                                       My.Resources.INFORMATION, 2000,
                                       eToastGlowColor.Blue,
                                       eToastPosition.BottomLeft)
            MCrReporte.ReportSource = Nothing
        End If





    End Sub
    Private Sub MBtGenerar_Click(sender As Object, e As EventArgs) Handles MBtGenerar.Click
        _prCargarReporte()
    End Sub

    Private Sub R01_VentasAtendidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()

    End Sub

    Private Sub MBtSalir_Click(sender As Object, e As EventArgs) Handles MBtSalir.Click
        _tab.Close()
        _modulo.Select()
    End Sub


End Class