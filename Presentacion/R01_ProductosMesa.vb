Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports Entidades
Imports DevComponents.DotNetBar.Controls
Imports Janus.Windows.GridEX.EditControls
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports GMap.NET.MapProviders
Imports GMap.NET
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.ToolTips
Imports System.Drawing
Imports System.Threading
Imports System.Drawing.Text
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing
Imports CrystalDecisions.Shared
Imports System.Math
Public Class R01_ProductosMesa
#Region "Atributos generales"

    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem
#End Region
#Region "Variables Globales"

    Dim InDuracion As Byte = 5

#End Region
    Private Sub _PIniciarTodo()
        P_prArmarComboMesas()

    End Sub
    Private Sub MBtSalir_Click(sender As Object, e As EventArgs) Handles MBtSalir.Click
        Me.Close()
        _modulo.Select()
        _tab.Close()
    End Sub
    Private Sub P_prArmarComboMesas()
        Dim dt As DataTable
        dt = L_fnObtenerTabla("mamesa", "CM001", "maest=1")
        g_prArmarCombo(cbMesa, dt, 85, 200, "Mesa")
    End Sub
    Public Sub g_prArmarCombo(cbj As MultiColumnCombo, dtCombo As DataTable,
                              Optional anchoCodigo As Integer = 60, Optional anchoDesc As Integer = 200,
                              Optional nombreCodigo As String = "Mesa")
        With cbj.DropDownList
            .Columns.Clear()

            .Columns.Add(dtCombo.Columns("mamesa").ToString).Width = anchoCodigo
            .Columns(0).Key =dtCombo.Columns(0).Caption
            .Columns(0).Caption = nombreCodigo
            .Columns(0).Visible = True

            .ValueMember = dtCombo.Columns("mamesa").ToString
            .DisplayMember = dtCombo.Columns("mamesa").ToString
            .DataSource = dtCombo
            .Refresh()
        End With
    End Sub
    Private Sub R01_ProductosMesa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _PIniciarTodo()
    End Sub

    Private Sub MBtGenerar_Click(sender As Object, e As EventArgs) Handles MBtGenerar.Click
        P_prCargarReporte()
    End Sub
    Private Sub P_prCargarReporte()
        Dim dt As New DataTable
        Dim dm As New DataTable
        Dim repartidor As String

        Dim Vend1 As Integer
        Dim Vend2 As Integer
        Dim Vend3 As Integer
        Dim Vend4 As Integer
        Dim NomVend1 As String
        Dim NomVend2 As String
        Dim NomVend3 As String
        Dim NomVend4 As String
        Dim AuxNomVend1 As String
        Dim AuxNomVend2 As String
        Dim AuxNomVend3 As String
        Dim AuxNomVend4 As String

        If (IsNumeric(cbMesa.Value)) Then

            dm = L_fnVendedoresPorMesa(cbMesa.Value)
            repartidor = dm.Rows(0).Item("repartidor")

            If dm.Rows.Count = 4 Then
                Vend1 = dm.Rows(0).Item("mbcodvendedor")
                Vend2 = dm.Rows(1).Item("mbcodvendedor")
                Vend3 = dm.Rows(2).Item("mbcodvendedor")
                Vend4 = dm.Rows(3).Item("mbcodvendedor")
                NomVend1 = dm.Rows(0).Item("cbdesc")
                NomVend2 = dm.Rows(1).Item("cbdesc")
                NomVend3 = dm.Rows(2).Item("cbdesc")
                NomVend4 = dm.Rows(3).Item("cbdesc")

            ElseIf dm.Rows.Count = 3 Then
                Vend1 = dm.Rows(0).Item("mbcodvendedor")
                Vend2 = dm.Rows(1).Item("mbcodvendedor")
                Vend3 = dm.Rows(2).Item("mbcodvendedor")
                NomVend1 = dm.Rows(0).Item("cbdesc")
                NomVend2 = dm.Rows(1).Item("cbdesc")
                NomVend3 = dm.Rows(2).Item("cbdesc")
            ElseIf dm.Rows.Count = 2 Then
                Vend1 = dm.Rows(0).Item("mbcodvendedor")
                Vend2 = dm.Rows(1).Item("mbcodvendedor")
                NomVend1 = dm.Rows(0).Item("cbdesc")
                NomVend2 = dm.Rows(1).Item("cbdesc")

            ElseIf dm.Rows.Count = 1 Then
                Vend1 = dm.Rows(0).Item("mbcodvendedor")
                NomVend1 = dm.Rows(0).Item("cbdesc")
            End If
            'AuxNomVend1 = NomVend1
            'AuxNomVend2 = NomVend2
            'AuxNomVend3 = NomVend3
            'AuxNomVend4 = NomVend4
            'AuxNomVend3 = NomVend3
            'AuxNomVend4 = NomVend4
            If (String.IsNullOrEmpty(NomVend1)) Then
                AuxNomVend1 = " "
            Else
                AuxNomVend1 = NomVend1
            End If
            If (String.IsNullOrEmpty(NomVend2)) Then
                AuxNomVend2 = " "
            Else
                AuxNomVend2 = NomVend2
            End If
            If (String.IsNullOrEmpty(NomVend3)) Then
                AuxNomVend3 = " "
            Else
                AuxNomVend3 = NomVend3
            End If
            If (String.IsNullOrEmpty(NomVend4)) Then
                AuxNomVend4 = " "
            Else
                AuxNomVend4 = NomVend4
            End If

            dt = L_fnReporteProductosMesas(cbMesa.Value, Vend1, Vend2, Vend3, Vend4)

            If (dt.Rows.Count > 0) Then
                Dim objrep As New R_ProductosMesa

                objrep.SetDataSource(dt)

                objrep.SetParameterValue("mesa", cbMesa.Text)
                objrep.SetParameterValue("repartidor", repartidor)
                objrep.SetParameterValue("vend1", AuxNomVend1)
                objrep.SetParameterValue("vend2", AuxNomVend2)
                objrep.SetParameterValue("vend3", AuxNomVend3)
                objrep.SetParameterValue("vend4", AuxNomVend4)

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
        Else

            ToastNotification.Show(Me,
                                   "Seleccione una mesa".ToUpper,
                                   My.Resources.INFORMATION,
                                   InDuracion * 500,
                                   eToastGlowColor.Blue,
                                   eToastPosition.TopCenter)
            Exit Sub
            'AuxNomVend1 = NomVend1


        End If
    End Sub
End Class