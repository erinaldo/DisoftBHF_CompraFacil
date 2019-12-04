Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class R01_VisitasDiarias

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

        Me.Text = "V I S I T A S   D I A R I A S".ToUpper
        Me.WindowState = FormWindowState.Maximized
        MCrReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

        P_prArmarCombos()
        dtFecha.Value = Now.Date
    End Sub

    Private Sub P_prArmarCombos()
        P_prArmarComboDistribuidor
    End Sub

    Private Sub P_prArmarComboDistribuidor()
        Dim dt As New DataTable
        dt = L_fnObtenerTabla("a.lanumi, l.cedesc, c.cbnumi, c.cbdesc",
                              "TL001 a inner join TL0012 b on a.lanumi=b.lcnumi " _
                              + "inner join TC0051 l on a.lazona=l.cenum and l.cecon=2 " _
                              + "inner join TC002 c on b.lccbnumi=c.cbnumi",
                              "1=1")

        With cbDistribuidor.DropDownList
            .Columns.Add(dt.Columns("lanumi").ToString).Width = 0
            .Columns(0).Visible = False

            .Columns.Add(dt.Columns("cedesc").ToString).Width = 100
            .Columns(1).Caption = "Cuidad"

            .Columns.Add(dt.Columns("cbnumi").ToString).Width = 0
            .Columns(2).Visible = False

            .Columns.Add(dt.Columns("cbdesc").ToString).Width = 200
            .Columns(3).Caption = "Distribuidor"
        End With

        cbDistribuidor.ValueMember = dt.Columns("lanumi").ToString
        cbDistribuidor.DisplayMember = dt.Columns("cbdesc").ToString
        cbDistribuidor.DataSource = dt
        cbDistribuidor.Refresh()

    End Sub

    Private Sub P_prCargarReporte()
        Dim dt As New DataTable
        'Filtro un cliente
        If (IsNumeric(cbDistribuidor.Value)) Then
            'Se elijio un cliente
            Dim array As String() = {"Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sábado", "Domingo"}
            Dim dia As String = dtFecha.Value.ToString("dddd")
            Dim filtro As Integer = 0

            For i As Integer = 0 To array.Count - 1
                If (array(i).ToUpper = dia.ToUpper) Then
                    filtro = i + 1
                    Exit For
                End If
            Next

            dt = L_fnObtenerTabla("*",
                                 "vr_go_visitasDiarias",
                                 "cczona=" + cbDistribuidor.Value.ToString + " and ccaandia=" + filtro.ToString)
        Else
            'No ha eligido un cliente
            ToastNotification.Show(Me,
                                   "Seleccione un distribuidor valido.".ToUpper,
                                   My.Resources.INFORMATION,
                                   InDuracion * 500,
                                   eToastGlowColor.Blue,
                                   eToastPosition.TopCenter)
            Exit Sub
        End If

        If (dt.Rows.Count > 0) Then
            Dim objrep As New R_VisitasDiarias

            objrep.SetDataSource(dt)

            objrep.SetParameterValue("distribuidor", cbDistribuidor.Text)
            objrep.SetParameterValue("zona", CType(cbDistribuidor.DataSource, DataTable).Select("lanumi=" + cbDistribuidor.Value.ToString)(0).Item("cedesc"))

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

#End Region

End Class