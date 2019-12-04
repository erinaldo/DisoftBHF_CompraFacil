Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports OfficeOpenXml.Style
Imports OfficeOpenXml
Imports System.IO
Imports Janus.Windows.GridEX

Public Class R01_NotaVenta
    Dim Vendedor As String = ""
#Region "Atributos generales"

    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

#End Region
    Private Sub R01_NotaVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IniciarTodo()
    End Sub

    Private Sub IniciarTodo()
        tbFechaI.Value = Now.Date
        'Abrir conexion
        If (Not gb_ConexionAbierta) Then
            L_prAbrirConexion()
        End If
        Me.Text = "N O T A  D E  V E N T A".ToUpper
        Me.WindowState = FormWindowState.Maximized
        P_prArmarComboVendedor()
    End Sub

    Private Sub P_prArmarComboVendedor()
        Dim dt As DataTable
        dt = L_fnObtenerTabla("cbnumi as [cod], cbdesc as [desc]", "TC002", "cbcat=1")
        g_prArmarCombo(cbVendedor, dt, 60, 200, "Código", "Repartidor")
    End Sub

    Private Sub MBtGenerar_Click(sender As Object, e As EventArgs) Handles MBtGenerar.Click
        P_prCargarReporte()
    End Sub

    Private Sub P_prCargarReporte()
        Dim _dt As New DataTable
        _prInterpretarDatos(_dt)
        If (_dt.Rows.Count > 0) Then
            Dim objrep As New R_NotadeVenta
            Dim FechaI As String = tbFechaI.Value.ToString("dd/MM/yyyy")
            objrep.SetDataSource(_dt)
            objrep.SetParameterValue("FechaI", FechaI)
            objrep.SetParameterValue("Vendedor", Vendedor)
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

    Private Sub MBtSalir_Click(sender As Object, e As EventArgs) Handles MBtSalir.Click
        Me.Close()
        _modulo.Select()
        _tab.Close()
    End Sub

    Public Sub _prInterpretarDatos(ByRef _dt As DataTable)
        Dim FechaI As String = tbFechaI.Value.ToString("dd/MM/yyyy")

        'Vendedor = "" + cbVendedor.Text
        Vendedor = cbVendedor.Text
        _dt = L_fnNotaVenta(FechaI, Vendedor)

    End Sub

End Class