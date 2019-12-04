Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports OfficeOpenXml.Style
Imports OfficeOpenXml
Imports System.IO
Imports Janus.Windows.GridEX

Public Class R02_VentaClientePorMes

#Region "Atributos generales"

    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

#End Region

#Region "Variables Globales"

    Dim InDuracion As Byte = 5

#End Region

#Region "Eventos"
    Private Sub R02_VentaClientePorMes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IniciarTodo()
    End Sub

    Private Sub IniciarTodo()
        'Abrir conexion
        If (Not gb_ConexionAbierta) Then
            L_prAbrirConexion()
        End If

        Me.Text = "V E N T A   A   C L I E N T E   P O R   M E S".ToUpper
        Me.WindowState = FormWindowState.Maximized

        tbAnho.Value = Now.Year
        ArmarCombo()
    End Sub

    Private Sub MBtGenerar_Click(sender As Object, e As EventArgs) Handles MBtGenerar.Click
        GenerarReporte()
    End Sub

    Private Sub MBtSalir_Click(sender As Object, e As EventArgs) Handles MBtSalir.Click
        Me.Close()
        _modulo.Select()
        _tab.Close()
    End Sub
#End Region

#Region "Metodos"
    Private Sub ArmarCombo()
        Dim dt As DataTable = New DataTable
        dt.Columns.Add("cod", GetType(Integer))
        dt.Columns.Add("desc", GetType(String))

        For index = 1 To 12
            dt.Rows.Add(index, MonthName(index).ToUpper)
        Next
        g_prArmarCombo(cbMeses, dt, 60, 200, "Nro", "Mes")

        If (CType(cbMeses.DataSource, DataTable).Rows.Count > 0) Then
            cbMeses.SelectedIndex = Now.Month - 1
        End If
    End Sub

    Private Sub GenerarReporte()
        Dim dt As DataTable = L_fnVentaClientePorMes(IIf(SbFiltroCM.Value, "2", "1"), tbAnho.Value.ToString, cbMeses.Value.ToString, tbCodigoCliente.Text.Trim, tbNombreCliente.Text.Trim)
        Dim FechaInicial As Date = New Date(tbAnho.Value, cbMeses.Value, 1)
        Dim CantidadDias As Integer = DateTime.DaysInMonth(tbAnho.Value, cbMeses.Value)
        Dim LiteralDia As String = ObtenerDiaLiteral(FechaInicial)

        dgjPrincipal.BoundMode = Janus.Data.BoundMode.Bound
        dgjPrincipal.DataSource = dt
        dgjPrincipal.RetrieveStructure()

        With dgjPrincipal.RootTable.Columns("codDB")
            .Visible = False
        End With

        With dgjPrincipal.RootTable.Columns("Codigo")
            .Caption = "Código"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With

        With dgjPrincipal.RootTable.Columns("Nombre")
            .Caption = "Nombre cliente"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With

        With dgjPrincipal.RootTable.Columns("Direccion")
            .Caption = "Dirección"
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With

        For index = 1 To 31
            With dgjPrincipal.RootTable.Columns(index.ToString)
                .Caption = ObtenerDiaLiteral(FechaInicial) + ", " + index.ToString
                .Width = 80
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.FontSize = gi_fuenteTamano
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                .Visible = index <= CantidadDias
                .FormatString = "0.00"
            End With
            FechaInicial = FechaInicial.AddDays(1)
        Next
        With dgjPrincipal.RootTable.Columns("Total")
            .Caption = "Total"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            .FormatString = "0.00"
        End With

        With dgjPrincipal
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            '.DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
            .AlternatingColors = True
            .BringToFront()
            .Refresh()
            .AllowEdit = InheritableBoolean.False
        End With
    End Sub

    Private Function ObtenerDiaLiteral(fecha As Date) As String
        Return fecha.ToString("dddd")
    End Function

    Private Sub btExportar_Click(sender As Object, e As EventArgs) Handles btExportar.Click
        If (dgjPrincipal.RowCount > 0) Then
            Dim xlPackage As New ExcelPackage()
            xlPackage = CreateExcel(ProcesarDataTable(CType(dgjPrincipal.DataSource, DataTable)))

            Dim path As String = "C:\Users\" + Environment.UserName + "\Downloads\VentaClientesMes_" + cbMeses.Text + "_" +
                                          tbAnho.Value.ToString + "_" + Now.Day.ToString("00") + Now.Hour.ToString("00") +
                                          Now.Minute.ToString("00") + Now.Second.ToString("00") + ".xlsx"
            Dim excelFile As New FileInfo(path)
            xlPackage.SaveAs(excelFile)

            ToastNotification.Show(Me, "Su archivo esta grabado en la ruta" + Environment.NewLine + path,
                                       My.Resources.INFORMATION, InDuracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
        Else
            ToastNotification.Show(Me, "no hay datos para los parametros seleccionados.".ToUpper,
                                       My.Resources.INFORMATION, InDuracion * 500,
                                       eToastGlowColor.Blue,
                                       eToastPosition.BottomLeft)
        End If
    End Sub

    Private Function ProcesarDataTable(dataSource As DataTable) As DataTable
        Dim dt As DataTable = New DataTable
        Dim index As Integer = 0
        For Each ele As GridEXColumn In dgjPrincipal.RootTable.Columns
            If (ele.Visible) Then
                If (index < dgjPrincipal.RootTable.Columns("Direccion").Index - 1) Then
                    dt.Columns.Add(ele.Caption, GetType(String))
                Else
                    dt.Columns.Add(ele.Key, GetType(Decimal))
                End If
                index += 1
            End If
        Next

        For Each ele As GridEXRow In dgjPrincipal.GetRows
            Dim array(dt.Columns.Count - 1) As Object
            index = 0
            For Each item As GridEXCell In ele.Cells
                If (item.Column.Visible) Then
                    If (IsNumeric(item.Value)) Then
                        array(index) = Convert.ToDecimal(item.Value)
                    Else
                        array(index) = item.Value.ToString
                    End If
                    index += 1
                End If
            Next
            dt.Rows.Add(array)
        Next

        Return dt
    End Function

    Public Shared Function CreateExcel(ByVal dt As DataTable) As ExcelPackage
        Dim xlPackage As New ExcelPackage()
        Dim oBook As ExcelWorkbook = xlPackage.Workbook

        'Load each table into worksheet
        Dim ws As ExcelWorksheet = oBook.Worksheets.Add("Hoja1")
        ws.Cells.LoadFromDataTable(dt, True)

        ws.Cells.Style.Locked = False
        ws.Cells.AutoFitColumns()
        Using rango As ExcelRange = ws.Cells(1, 1, 1, dt.Columns.Count)
            rango.Style.Fill.PatternType = ExcelFillStyle.Solid
            rango.Style.Fill.BackgroundColor.SetColor(Color.Red)
            rango.Style.Font.Bold = True
            rango.Style.Font.Color.SetColor(Color.White)
            rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
        End Using

        Using rango As ExcelRange = ws.Cells(1, dt.Columns.Count, dt.Rows.Count + 1, dt.Columns.Count)
            rango.Style.Fill.PatternType = ExcelFillStyle.Solid
            rango.Style.Fill.BackgroundColor.SetColor(Color.Red)
            rango.Style.Font.Bold = True
            rango.Style.Font.Color.SetColor(Color.White)
        End Using

        Using rango As ExcelRange = ws.Cells(1, 1, dt.Rows.Count + 1, dt.Columns.Count)
            rango.Style.Border.Top.Style = ExcelBorderStyle.Thin
            rango.Style.Border.Left.Style = ExcelBorderStyle.Thin
            rango.Style.Border.Right.Style = ExcelBorderStyle.Thin
            rango.Style.Border.Bottom.Style = ExcelBorderStyle.Thin
        End Using

        Return xlPackage
    End Function

#End Region
End Class