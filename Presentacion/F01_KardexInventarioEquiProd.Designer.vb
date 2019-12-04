<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F01_KardexInventarioEquiProd
    Inherits Modelo.ModeloF02_cd

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanelPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupPanelKardex = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Dgj1Datos = New Janus.Windows.GridEX.GridEX()
        Me.GroupPanelDatosGenerales = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelExDatosGenerales = New DevComponents.DotNetBar.PanelEx()
        Me.lbEquiProd = New DevComponents.DotNetBar.LabelX()
        Me.Tb1CodEquipo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Tb3Saldo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Bt1BuscarCliente = New DevComponents.DotNetBar.ButtonX()
        Me.Dti1FechaIni = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Bt3Generar = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Dti2FechaFin = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Tb2DescEquipo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanelBusqueda = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Dgj2Busqueda = New Janus.Windows.GridEX.GridEX()
        CType(Me.MSuperTabControlPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MSuperTabControlPrincipal.SuspendLayout()
        Me.MSuperTabControlPanelBusqueda.SuspendLayout()
        Me.MSuperTabControlPanelRegistro.SuspendLayout()
        Me.MPnSuperior.SuspendLayout()
        Me.MPnInferior.SuspendLayout()
        Me.MPanelToolBarUsuario.SuspendLayout()
        Me.MPanelToolBarNavegacion.SuspendLayout()
        Me.MPanelToolBarAccion.SuspendLayout()
        Me.MPanelToolBarImprimir.SuspendLayout()
        CType(Me.MBubbleBarUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MPnUsuario.SuspendLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanelPrincipal.SuspendLayout()
        Me.GroupPanelKardex.SuspendLayout()
        CType(Me.Dgj1Datos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanelDatosGenerales.SuspendLayout()
        Me.PanelExDatosGenerales.SuspendLayout()
        CType(Me.Dti1FechaIni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dti2FechaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanelBusqueda.SuspendLayout()
        CType(Me.Dgj2Busqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MSuperTabControlPrincipal
        '
        '
        '
        '
        '
        '
        '
        Me.MSuperTabControlPrincipal.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.MSuperTabControlPrincipal.ControlBox.MenuBox.Name = ""
        Me.MSuperTabControlPrincipal.ControlBox.Name = ""
        Me.MSuperTabControlPrincipal.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MSuperTabControlPrincipal.ControlBox.MenuBox, Me.MSuperTabControlPrincipal.ControlBox.CloseBox})
        Me.MSuperTabControlPrincipal.Controls.SetChildIndex(Me.MSuperTabControlPanelBusqueda, 0)
        Me.MSuperTabControlPrincipal.Controls.SetChildIndex(Me.MSuperTabControlPanelRegistro, 0)
        '
        'MSuperTabControlPanelBusqueda
        '
        Me.MSuperTabControlPanelBusqueda.Controls.Add(Me.GroupPanelBusqueda)
        Me.MSuperTabControlPanelBusqueda.Size = New System.Drawing.Size(942, 455)
        '
        'MSuperTabControlPanelRegistro
        '
        Me.MSuperTabControlPanelRegistro.Controls.Add(Me.TableLayoutPanelPrincipal)
        Me.MSuperTabControlPanelRegistro.Size = New System.Drawing.Size(942, 455)
        Me.MSuperTabControlPanelRegistro.Controls.SetChildIndex(Me.MPnUsuario, 0)
        Me.MSuperTabControlPanelRegistro.Controls.SetChildIndex(Me.TableLayoutPanelPrincipal, 0)
        '
        'MPnSuperior
        '
        Me.MPnSuperior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.MPnSuperior.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.MPnSuperior.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.MPnSuperior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.MPnSuperior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.MPnSuperior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.MPnSuperior.Style.GradientAngle = 90
        '
        'MPnInferior
        '
        Me.MPnInferior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.MPnInferior.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.MPnInferior.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.MPnInferior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.MPnInferior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.MPnInferior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.MPnInferior.Style.GradientAngle = 90
        '
        'MTbUsuario
        '
        Me.MTbUsuario.ReadOnly = True
        Me.MTbUsuario.Text = "DEFAULT"
        '
        'MBtSalir
        '
        '
        'MBtImprimir
        '
        '
        'MBubbleBarUsuario
        '
        '
        '
        '
        Me.MBubbleBarUsuario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.MBubbleBarUsuario.ButtonBackAreaStyle.BackColor = System.Drawing.Color.Transparent
        Me.MBubbleBarUsuario.ButtonBackAreaStyle.BorderBottomWidth = 1
        Me.MBubbleBarUsuario.ButtonBackAreaStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.MBubbleBarUsuario.ButtonBackAreaStyle.BorderLeftWidth = 1
        Me.MBubbleBarUsuario.ButtonBackAreaStyle.BorderRightWidth = 1
        Me.MBubbleBarUsuario.ButtonBackAreaStyle.BorderTopWidth = 1
        Me.MBubbleBarUsuario.ButtonBackAreaStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MBubbleBarUsuario.ButtonBackAreaStyle.PaddingBottom = 3
        Me.MBubbleBarUsuario.ButtonBackAreaStyle.PaddingLeft = 3
        Me.MBubbleBarUsuario.ButtonBackAreaStyle.PaddingRight = 3
        Me.MBubbleBarUsuario.ButtonBackAreaStyle.PaddingTop = 3
        Me.MBubbleBarUsuario.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight
        Me.MBubbleBarUsuario.SelectedTabColors.BorderColor = System.Drawing.Color.Black
        '
        'MLbPaginacion
        '
        '
        '
        '
        Me.MLbPaginacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'MRlAccion
        '
        '
        '
        '
        Me.MRlAccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MRlAccion.Size = New System.Drawing.Size(500, 60)
        '
        'TableLayoutPanelPrincipal
        '
        Me.TableLayoutPanelPrincipal.ColumnCount = 1
        Me.TableLayoutPanelPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelPrincipal.Controls.Add(Me.GroupPanelKardex, 0, 1)
        Me.TableLayoutPanelPrincipal.Controls.Add(Me.GroupPanelDatosGenerales, 0, 0)
        Me.TableLayoutPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanelPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelPrincipal.Name = "TableLayoutPanelPrincipal"
        Me.TableLayoutPanelPrincipal.RowCount = 2
        Me.TableLayoutPanelPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanelPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelPrincipal.Size = New System.Drawing.Size(942, 455)
        Me.TableLayoutPanelPrincipal.TabIndex = 30
        '
        'GroupPanelKardex
        '
        Me.GroupPanelKardex.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelKardex.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelKardex.Controls.Add(Me.Dgj1Datos)
        Me.GroupPanelKardex.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelKardex.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelKardex.Location = New System.Drawing.Point(3, 153)
        Me.GroupPanelKardex.Name = "GroupPanelKardex"
        Me.GroupPanelKardex.Size = New System.Drawing.Size(936, 299)
        '
        '
        '
        Me.GroupPanelKardex.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanelKardex.Style.BackColorGradientAngle = 90
        Me.GroupPanelKardex.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanelKardex.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelKardex.Style.BorderBottomWidth = 1
        Me.GroupPanelKardex.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelKardex.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelKardex.Style.BorderLeftWidth = 1
        Me.GroupPanelKardex.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelKardex.Style.BorderRightWidth = 1
        Me.GroupPanelKardex.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelKardex.Style.BorderTopWidth = 1
        Me.GroupPanelKardex.Style.CornerDiameter = 4
        Me.GroupPanelKardex.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelKardex.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelKardex.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelKardex.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelKardex.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelKardex.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelKardex.TabIndex = 7
        Me.GroupPanelKardex.Text = "KARDEX"
        '
        'Dgj1Datos
        '
        Me.Dgj1Datos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgj1Datos.Location = New System.Drawing.Point(0, 0)
        Me.Dgj1Datos.Name = "Dgj1Datos"
        Me.Dgj1Datos.Size = New System.Drawing.Size(930, 277)
        Me.Dgj1Datos.TabIndex = 0
        '
        'GroupPanelDatosGenerales
        '
        Me.GroupPanelDatosGenerales.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelDatosGenerales.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelDatosGenerales.Controls.Add(Me.PanelExDatosGenerales)
        Me.GroupPanelDatosGenerales.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelDatosGenerales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelDatosGenerales.Location = New System.Drawing.Point(3, 3)
        Me.GroupPanelDatosGenerales.Name = "GroupPanelDatosGenerales"
        Me.GroupPanelDatosGenerales.Size = New System.Drawing.Size(936, 144)
        '
        '
        '
        Me.GroupPanelDatosGenerales.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanelDatosGenerales.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanelDatosGenerales.Style.BackColorGradientAngle = 90
        Me.GroupPanelDatosGenerales.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatosGenerales.Style.BorderBottomWidth = 1
        Me.GroupPanelDatosGenerales.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelDatosGenerales.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatosGenerales.Style.BorderLeftWidth = 1
        Me.GroupPanelDatosGenerales.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatosGenerales.Style.BorderRightWidth = 1
        Me.GroupPanelDatosGenerales.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatosGenerales.Style.BorderTopWidth = 1
        Me.GroupPanelDatosGenerales.Style.CornerDiameter = 4
        Me.GroupPanelDatosGenerales.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelDatosGenerales.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelDatosGenerales.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelDatosGenerales.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelDatosGenerales.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelDatosGenerales.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelDatosGenerales.TabIndex = 6
        Me.GroupPanelDatosGenerales.Text = "DATOS GENERALES"
        '
        'PanelExDatosGenerales
        '
        Me.PanelExDatosGenerales.AutoScroll = True
        Me.PanelExDatosGenerales.CanvasColor = System.Drawing.Color.Transparent
        Me.PanelExDatosGenerales.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelExDatosGenerales.Controls.Add(Me.lbEquiProd)
        Me.PanelExDatosGenerales.Controls.Add(Me.Tb1CodEquipo)
        Me.PanelExDatosGenerales.Controls.Add(Me.Tb3Saldo)
        Me.PanelExDatosGenerales.Controls.Add(Me.Bt1BuscarCliente)
        Me.PanelExDatosGenerales.Controls.Add(Me.Dti1FechaIni)
        Me.PanelExDatosGenerales.Controls.Add(Me.Bt3Generar)
        Me.PanelExDatosGenerales.Controls.Add(Me.LabelX2)
        Me.PanelExDatosGenerales.Controls.Add(Me.Dti2FechaFin)
        Me.PanelExDatosGenerales.Controls.Add(Me.LabelX3)
        Me.PanelExDatosGenerales.Controls.Add(Me.Tb2DescEquipo)
        Me.PanelExDatosGenerales.Controls.Add(Me.LabelX4)
        Me.PanelExDatosGenerales.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelExDatosGenerales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelExDatosGenerales.Location = New System.Drawing.Point(0, 0)
        Me.PanelExDatosGenerales.Name = "PanelExDatosGenerales"
        Me.PanelExDatosGenerales.Size = New System.Drawing.Size(930, 122)
        Me.PanelExDatosGenerales.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelExDatosGenerales.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PanelExDatosGenerales.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PanelExDatosGenerales.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelExDatosGenerales.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelExDatosGenerales.Style.GradientAngle = 90
        Me.PanelExDatosGenerales.TabIndex = 14
        '
        'lbEquiProd
        '
        '
        '
        '
        Me.lbEquiProd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbEquiProd.Location = New System.Drawing.Point(3, 3)
        Me.lbEquiProd.Name = "lbEquiProd"
        Me.lbEquiProd.Size = New System.Drawing.Size(82, 23)
        Me.lbEquiProd.TabIndex = 0
        Me.lbEquiProd.Text = "Equipo:"
        Me.lbEquiProd.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Tb1CodEquipo
        '
        '
        '
        '
        Me.Tb1CodEquipo.Border.Class = "TextBoxBorder"
        Me.Tb1CodEquipo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb1CodEquipo.Location = New System.Drawing.Point(91, 6)
        Me.Tb1CodEquipo.Name = "Tb1CodEquipo"
        Me.Tb1CodEquipo.PreventEnterBeep = True
        Me.Tb1CodEquipo.Size = New System.Drawing.Size(76, 21)
        Me.Tb1CodEquipo.TabIndex = 0
        '
        'Tb3Saldo
        '
        '
        '
        '
        Me.Tb3Saldo.Border.Class = "TextBoxBorder"
        Me.Tb3Saldo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb3Saldo.Location = New System.Drawing.Point(91, 64)
        Me.Tb3Saldo.Name = "Tb3Saldo"
        Me.Tb3Saldo.PreventEnterBeep = True
        Me.Tb3Saldo.ReadOnly = True
        Me.Tb3Saldo.Size = New System.Drawing.Size(100, 21)
        Me.Tb3Saldo.TabIndex = 12
        '
        'Bt1BuscarCliente
        '
        Me.Bt1BuscarCliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Bt1BuscarCliente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Bt1BuscarCliente.Image = Global.Presentacion.My.Resources.Resources.BUSQUEDA
        Me.Bt1BuscarCliente.ImageFixedSize = New System.Drawing.Size(20, 20)
        Me.Bt1BuscarCliente.Location = New System.Drawing.Point(164, 6)
        Me.Bt1BuscarCliente.Name = "Bt1BuscarCliente"
        Me.Bt1BuscarCliente.Size = New System.Drawing.Size(27, 21)
        Me.Bt1BuscarCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bt1BuscarCliente.TabIndex = 1
        Me.Bt1BuscarCliente.Tooltip = "Buscar Cliente"
        '
        'Dti1FechaIni
        '
        '
        '
        '
        Me.Dti1FechaIni.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dti1FechaIni.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dti1FechaIni.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dti1FechaIni.ButtonDropDown.Visible = True
        Me.Dti1FechaIni.IsPopupCalendarOpen = False
        Me.Dti1FechaIni.Location = New System.Drawing.Point(91, 35)
        '
        '
        '
        '
        '
        '
        Me.Dti1FechaIni.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dti1FechaIni.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dti1FechaIni.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dti1FechaIni.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dti1FechaIni.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dti1FechaIni.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dti1FechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dti1FechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dti1FechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dti1FechaIni.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dti1FechaIni.MonthCalendar.DisplayMonth = New Date(2016, 9, 1, 0, 0, 0, 0)
        Me.Dti1FechaIni.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.Dti1FechaIni.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dti1FechaIni.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dti1FechaIni.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dti1FechaIni.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dti1FechaIni.MonthCalendar.TodayButtonVisible = True
        Me.Dti1FechaIni.Name = "Dti1FechaIni"
        Me.Dti1FechaIni.Size = New System.Drawing.Size(100, 21)
        Me.Dti1FechaIni.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dti1FechaIni.TabIndex = 2
        Me.Dti1FechaIni.Value = New Date(2016, 9, 23, 6, 49, 32, 0)
        '
        'Bt3Generar
        '
        Me.Bt3Generar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Bt3Generar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Bt3Generar.Image = Global.Presentacion.My.Resources.Resources.GENERAR_REPORTE
        Me.Bt3Generar.ImageFixedSize = New System.Drawing.Size(50, 50)
        Me.Bt3Generar.Location = New System.Drawing.Point(511, 35)
        Me.Bt3Generar.Name = "Bt3Generar"
        Me.Bt3Generar.Size = New System.Drawing.Size(130, 60)
        Me.Bt3Generar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bt3Generar.TabIndex = 4
        Me.Bt3Generar.Text = "Generar"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(3, 32)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(82, 23)
        Me.LabelX2.TabIndex = 5
        Me.LabelX2.Text = "Fecha del:"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Dti2FechaFin
        '
        '
        '
        '
        Me.Dti2FechaFin.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dti2FechaFin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dti2FechaFin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dti2FechaFin.ButtonDropDown.Visible = True
        Me.Dti2FechaFin.IsPopupCalendarOpen = False
        Me.Dti2FechaFin.Location = New System.Drawing.Point(225, 35)
        '
        '
        '
        '
        '
        '
        Me.Dti2FechaFin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dti2FechaFin.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dti2FechaFin.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dti2FechaFin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dti2FechaFin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dti2FechaFin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dti2FechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dti2FechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dti2FechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dti2FechaFin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dti2FechaFin.MonthCalendar.DisplayMonth = New Date(2016, 9, 1, 0, 0, 0, 0)
        Me.Dti2FechaFin.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.Dti2FechaFin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dti2FechaFin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dti2FechaFin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dti2FechaFin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dti2FechaFin.MonthCalendar.TodayButtonVisible = True
        Me.Dti2FechaFin.Name = "Dti2FechaFin"
        Me.Dti2FechaFin.Size = New System.Drawing.Size(100, 21)
        Me.Dti2FechaFin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dti2FechaFin.TabIndex = 3
        Me.Dti2FechaFin.Value = New Date(2016, 9, 23, 6, 49, 32, 0)
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(197, 32)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(22, 23)
        Me.LabelX3.TabIndex = 6
        Me.LabelX3.Text = "Al:"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Tb2DescEquipo
        '
        '
        '
        '
        Me.Tb2DescEquipo.Border.Class = "TextBoxBorder"
        Me.Tb2DescEquipo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb2DescEquipo.Location = New System.Drawing.Point(197, 6)
        Me.Tb2DescEquipo.Name = "Tb2DescEquipo"
        Me.Tb2DescEquipo.PreventEnterBeep = True
        Me.Tb2DescEquipo.ReadOnly = True
        Me.Tb2DescEquipo.Size = New System.Drawing.Size(444, 21)
        Me.Tb2DescEquipo.TabIndex = 8
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(3, 61)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(82, 23)
        Me.LabelX4.TabIndex = 7
        Me.LabelX4.Text = "Saldo:"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'GroupPanelBusqueda
        '
        Me.GroupPanelBusqueda.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelBusqueda.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelBusqueda.Controls.Add(Me.Dgj2Busqueda)
        Me.GroupPanelBusqueda.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanelBusqueda.Name = "GroupPanelBusqueda"
        Me.GroupPanelBusqueda.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupPanelBusqueda.Size = New System.Drawing.Size(942, 455)
        '
        '
        '
        Me.GroupPanelBusqueda.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanelBusqueda.Style.BackColorGradientAngle = 90
        Me.GroupPanelBusqueda.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanelBusqueda.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBusqueda.Style.BorderBottomWidth = 1
        Me.GroupPanelBusqueda.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelBusqueda.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBusqueda.Style.BorderLeftWidth = 1
        Me.GroupPanelBusqueda.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBusqueda.Style.BorderRightWidth = 1
        Me.GroupPanelBusqueda.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBusqueda.Style.BorderTopWidth = 1
        Me.GroupPanelBusqueda.Style.CornerDiameter = 4
        Me.GroupPanelBusqueda.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelBusqueda.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelBusqueda.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelBusqueda.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelBusqueda.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelBusqueda.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelBusqueda.TabIndex = 1
        Me.GroupPanelBusqueda.Text = "BUSQUEDA DE EQUIPOS"
        '
        'Dgj2Busqueda
        '
        Me.Dgj2Busqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgj2Busqueda.Location = New System.Drawing.Point(5, 5)
        Me.Dgj2Busqueda.Name = "Dgj2Busqueda"
        Me.Dgj2Busqueda.Size = New System.Drawing.Size(926, 424)
        Me.Dgj2Busqueda.TabIndex = 1
        '
        'F01_KardexInventarioEquiProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "F01_KardexInventarioEquiProd"
        Me.Text = "F01_KardexInventarioEquiProd"
        Me.Controls.SetChildIndex(Me.MPnSuperior, 0)
        Me.Controls.SetChildIndex(Me.MPnInferior, 0)
        Me.Controls.SetChildIndex(Me.MSuperTabControlPrincipal, 0)
        CType(Me.MSuperTabControlPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MSuperTabControlPrincipal.ResumeLayout(False)
        Me.MSuperTabControlPanelBusqueda.ResumeLayout(False)
        Me.MSuperTabControlPanelRegistro.ResumeLayout(False)
        Me.MPnSuperior.ResumeLayout(False)
        Me.MPnInferior.ResumeLayout(False)
        Me.MPanelToolBarUsuario.ResumeLayout(False)
        Me.MPanelToolBarUsuario.PerformLayout()
        Me.MPanelToolBarNavegacion.ResumeLayout(False)
        Me.MPanelToolBarAccion.ResumeLayout(False)
        Me.MPanelToolBarImprimir.ResumeLayout(False)
        CType(Me.MBubbleBarUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MPnUsuario.ResumeLayout(False)
        Me.MPnUsuario.PerformLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanelPrincipal.ResumeLayout(False)
        Me.GroupPanelKardex.ResumeLayout(False)
        CType(Me.Dgj1Datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanelDatosGenerales.ResumeLayout(False)
        Me.PanelExDatosGenerales.ResumeLayout(False)
        CType(Me.Dti1FechaIni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dti2FechaFin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanelBusqueda.ResumeLayout(False)
        CType(Me.Dgj2Busqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanelPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupPanelKardex As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Dgj1Datos As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupPanelDatosGenerales As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PanelExDatosGenerales As DevComponents.DotNetBar.PanelEx
    Friend WithEvents lbEquiProd As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb1CodEquipo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Tb3Saldo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bt1BuscarCliente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Dti1FechaIni As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Bt3Generar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dti2FechaFin As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb2DescEquipo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanelBusqueda As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Dgj2Busqueda As Janus.Windows.GridEX.GridEX
End Class
