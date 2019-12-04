<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class R01_EquipoPrestadoVsVenta
    Inherits Modelo.ModeloR01

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.gpFiltroProducto = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.SbFiltroTodosUno = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.tbDescripcionProducto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbCodigoProducto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btBuscarProducto = New DevComponents.DotNetBar.ButtonX()
        Me.gpFiltroFechas = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.DtiHasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.DtiDesde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.gpCriterio = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.tbCodigoCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbNombreCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.MPnSuperior.SuspendLayout()
        Me.MPnInferior.SuspendLayout()
        Me.MPanelToolBarUsuario.SuspendLayout()
        Me.MPanelToolBarAccion.SuspendLayout()
        CType(Me.MBubbleBarUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MPnUsuario.SuspendLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MGpFiltro.SuspendLayout()
        Me.gpFiltroProducto.SuspendLayout()
        Me.gpFiltroFechas.SuspendLayout()
        CType(Me.DtiHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtiDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpCriterio.SuspendLayout()
        Me.SuspendLayout()
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
        Me.MPnInferior.Location = New System.Drawing.Point(300, 525)
        Me.MPnInferior.Size = New System.Drawing.Size(684, 36)
        Me.MPnInferior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.MPnInferior.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.MPnInferior.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.MPnInferior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.MPnInferior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.MPnInferior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.MPnInferior.Style.GradientAngle = 90
        '
        'MPanelToolBarUsuario
        '
        Me.MPanelToolBarUsuario.Location = New System.Drawing.Point(484, 0)
        '
        'MTbUsuario
        '
        Me.MTbUsuario.ReadOnly = True
        Me.MTbUsuario.Text = "DEFAULT"
        '
        'MBtSalir
        '
        '
        'MBtGenerar
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
        'MGpFiltro
        '
        Me.MGpFiltro.Controls.Add(Me.gpCriterio)
        Me.MGpFiltro.Controls.Add(Me.gpFiltroFechas)
        Me.MGpFiltro.Controls.Add(Me.gpFiltroProducto)
        Me.MGpFiltro.Size = New System.Drawing.Size(300, 491)
        '
        '
        '
        Me.MGpFiltro.Style.BackColor = System.Drawing.SystemColors.Control
        Me.MGpFiltro.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.MGpFiltro.Style.BackColorGradientAngle = 90
        Me.MGpFiltro.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.MGpFiltro.Style.BorderBottomWidth = 1
        Me.MGpFiltro.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.MGpFiltro.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.MGpFiltro.Style.BorderLeftWidth = 1
        Me.MGpFiltro.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.MGpFiltro.Style.BorderRightWidth = 1
        Me.MGpFiltro.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.MGpFiltro.Style.BorderTopWidth = 1
        Me.MGpFiltro.Style.CornerDiameter = 4
        Me.MGpFiltro.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.MGpFiltro.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.MGpFiltro.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.MGpFiltro.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.MGpFiltro.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.MGpFiltro.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MGpFiltro.Controls.SetChildIndex(Me.gpFiltroProducto, 0)
        Me.MGpFiltro.Controls.SetChildIndex(Me.gpFiltroFechas, 0)
        Me.MGpFiltro.Controls.SetChildIndex(Me.gpCriterio, 0)
        '
        'MCrReporte
        '
        Me.MCrReporte.Size = New System.Drawing.Size(684, 561)
        '
        'gpFiltroProducto
        '
        Me.gpFiltroProducto.BackColor = System.Drawing.Color.Transparent
        Me.gpFiltroProducto.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpFiltroProducto.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.gpFiltroProducto.Controls.Add(Me.SbFiltroTodosUno)
        Me.gpFiltroProducto.Controls.Add(Me.LabelX4)
        Me.gpFiltroProducto.Controls.Add(Me.tbDescripcionProducto)
        Me.gpFiltroProducto.Controls.Add(Me.tbCodigoProducto)
        Me.gpFiltroProducto.Controls.Add(Me.btBuscarProducto)
        Me.gpFiltroProducto.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpFiltroProducto.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpFiltroProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFiltroProducto.Location = New System.Drawing.Point(0, 0)
        Me.gpFiltroProducto.Name = "gpFiltroProducto"
        Me.gpFiltroProducto.Size = New System.Drawing.Size(294, 124)
        '
        '
        '
        Me.gpFiltroProducto.Style.BackColor = System.Drawing.Color.Transparent
        Me.gpFiltroProducto.Style.BackColor2 = System.Drawing.Color.Transparent
        Me.gpFiltroProducto.Style.BackColorGradientAngle = 90
        Me.gpFiltroProducto.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpFiltroProducto.Style.BorderBottomWidth = 1
        Me.gpFiltroProducto.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpFiltroProducto.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpFiltroProducto.Style.BorderLeftWidth = 1
        Me.gpFiltroProducto.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpFiltroProducto.Style.BorderRightWidth = 1
        Me.gpFiltroProducto.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpFiltroProducto.Style.BorderTopWidth = 1
        Me.gpFiltroProducto.Style.CornerDiameter = 4
        Me.gpFiltroProducto.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpFiltroProducto.Style.TextColor = System.Drawing.SystemColors.WindowText
        Me.gpFiltroProducto.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpFiltroProducto.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpFiltroProducto.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpFiltroProducto.TabIndex = 15
        Me.gpFiltroProducto.Text = "PRODUCTO"
        '
        'SbFiltroTodosUno
        '
        '
        '
        '
        Me.SbFiltroTodosUno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SbFiltroTodosUno.Location = New System.Drawing.Point(75, 4)
        Me.SbFiltroTodosUno.Name = "SbFiltroTodosUno"
        Me.SbFiltroTodosUno.OffText = "TODOS"
        Me.SbFiltroTodosUno.OnText = "UNO"
        Me.SbFiltroTodosUno.Size = New System.Drawing.Size(100, 22)
        Me.SbFiltroTodosUno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SbFiltroTodosUno.TabIndex = 13
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabelX4.Location = New System.Drawing.Point(6, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(62, 23)
        Me.LabelX4.TabIndex = 12
        Me.LabelX4.Text = "FILTRAR:"
        '
        'tbDescripcionProducto
        '
        '
        '
        '
        Me.tbDescripcionProducto.Border.Class = "TextBoxBorder"
        Me.tbDescripcionProducto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbDescripcionProducto.Location = New System.Drawing.Point(6, 67)
        Me.tbDescripcionProducto.Multiline = True
        Me.tbDescripcionProducto.Name = "tbDescripcionProducto"
        Me.tbDescripcionProducto.PreventEnterBeep = True
        Me.tbDescripcionProducto.Size = New System.Drawing.Size(279, 27)
        Me.tbDescripcionProducto.TabIndex = 11
        '
        'tbCodigoProducto
        '
        '
        '
        '
        Me.tbCodigoProducto.Border.Class = "TextBoxBorder"
        Me.tbCodigoProducto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCodigoProducto.Location = New System.Drawing.Point(6, 38)
        Me.tbCodigoProducto.Name = "tbCodigoProducto"
        Me.tbCodigoProducto.PreventEnterBeep = True
        Me.tbCodigoProducto.Size = New System.Drawing.Size(62, 21)
        Me.tbCodigoProducto.TabIndex = 10
        '
        'btBuscarProducto
        '
        Me.btBuscarProducto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btBuscarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btBuscarProducto.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.btBuscarProducto.Image = Global.Presentacion.My.Resources.Resources.buscar
        Me.btBuscarProducto.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btBuscarProducto.Location = New System.Drawing.Point(75, 31)
        Me.btBuscarProducto.Name = "btBuscarProducto"
        Me.btBuscarProducto.Size = New System.Drawing.Size(38, 34)
        Me.btBuscarProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btBuscarProducto.TabIndex = 15
        '
        'gpFiltroFechas
        '
        Me.gpFiltroFechas.BackColor = System.Drawing.Color.Transparent
        Me.gpFiltroFechas.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpFiltroFechas.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.gpFiltroFechas.Controls.Add(Me.LabelX2)
        Me.gpFiltroFechas.Controls.Add(Me.LabelX1)
        Me.gpFiltroFechas.Controls.Add(Me.DtiHasta)
        Me.gpFiltroFechas.Controls.Add(Me.DtiDesde)
        Me.gpFiltroFechas.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpFiltroFechas.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpFiltroFechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFiltroFechas.Location = New System.Drawing.Point(0, 124)
        Me.gpFiltroFechas.Name = "gpFiltroFechas"
        Me.gpFiltroFechas.Size = New System.Drawing.Size(294, 84)
        '
        '
        '
        Me.gpFiltroFechas.Style.BackColor = System.Drawing.Color.Transparent
        Me.gpFiltroFechas.Style.BackColor2 = System.Drawing.Color.Transparent
        Me.gpFiltroFechas.Style.BackColorGradientAngle = 90
        Me.gpFiltroFechas.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpFiltroFechas.Style.BorderBottomWidth = 1
        Me.gpFiltroFechas.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpFiltroFechas.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpFiltroFechas.Style.BorderLeftWidth = 1
        Me.gpFiltroFechas.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpFiltroFechas.Style.BorderRightWidth = 1
        Me.gpFiltroFechas.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpFiltroFechas.Style.BorderTopWidth = 1
        Me.gpFiltroFechas.Style.CornerDiameter = 4
        Me.gpFiltroFechas.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpFiltroFechas.Style.TextColor = System.Drawing.SystemColors.WindowText
        Me.gpFiltroFechas.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpFiltroFechas.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpFiltroFechas.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpFiltroFechas.TabIndex = 16
        Me.gpFiltroFechas.Text = "RANGO DE FECHAS"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabelX2.Location = New System.Drawing.Point(3, 32)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(52, 23)
        Me.LabelX2.TabIndex = 7
        Me.LabelX2.Text = "Hasta:"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(52, 23)
        Me.LabelX1.TabIndex = 6
        Me.LabelX1.Text = "Desde:"
        '
        'DtiHasta
        '
        '
        '
        '
        Me.DtiHasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DtiHasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiHasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DtiHasta.ButtonDropDown.Visible = True
        Me.DtiHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtiHasta.IsPopupCalendarOpen = False
        Me.DtiHasta.Location = New System.Drawing.Point(61, 32)
        '
        '
        '
        '
        '
        '
        Me.DtiHasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiHasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DtiHasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DtiHasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DtiHasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DtiHasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DtiHasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DtiHasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DtiHasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DtiHasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiHasta.MonthCalendar.DisplayMonth = New Date(2017, 4, 1, 0, 0, 0, 0)
        Me.DtiHasta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.DtiHasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DtiHasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DtiHasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DtiHasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiHasta.MonthCalendar.TodayButtonVisible = True
        Me.DtiHasta.Name = "DtiHasta"
        Me.DtiHasta.Size = New System.Drawing.Size(222, 23)
        Me.DtiHasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DtiHasta.TabIndex = 5
        '
        'DtiDesde
        '
        '
        '
        '
        Me.DtiDesde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DtiDesde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiDesde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DtiDesde.ButtonDropDown.Visible = True
        Me.DtiDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtiDesde.IsPopupCalendarOpen = False
        Me.DtiDesde.Location = New System.Drawing.Point(61, 3)
        '
        '
        '
        '
        '
        '
        Me.DtiDesde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiDesde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DtiDesde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DtiDesde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DtiDesde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DtiDesde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DtiDesde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DtiDesde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DtiDesde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DtiDesde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiDesde.MonthCalendar.DisplayMonth = New Date(2017, 4, 1, 0, 0, 0, 0)
        Me.DtiDesde.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.DtiDesde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DtiDesde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DtiDesde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DtiDesde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiDesde.MonthCalendar.TodayButtonVisible = True
        Me.DtiDesde.Name = "DtiDesde"
        Me.DtiDesde.Size = New System.Drawing.Size(222, 23)
        Me.DtiDesde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DtiDesde.TabIndex = 4
        '
        'gpCriterio
        '
        Me.gpCriterio.BackColor = System.Drawing.Color.Transparent
        Me.gpCriterio.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpCriterio.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.gpCriterio.Controls.Add(Me.tbNombreCliente)
        Me.gpCriterio.Controls.Add(Me.tbCodigoCliente)
        Me.gpCriterio.Controls.Add(Me.LabelX3)
        Me.gpCriterio.Controls.Add(Me.LabelX5)
        Me.gpCriterio.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpCriterio.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpCriterio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpCriterio.Location = New System.Drawing.Point(0, 208)
        Me.gpCriterio.Name = "gpCriterio"
        Me.gpCriterio.Size = New System.Drawing.Size(294, 84)
        '
        '
        '
        Me.gpCriterio.Style.BackColor = System.Drawing.Color.Transparent
        Me.gpCriterio.Style.BackColor2 = System.Drawing.Color.Transparent
        Me.gpCriterio.Style.BackColorGradientAngle = 90
        Me.gpCriterio.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpCriterio.Style.BorderBottomWidth = 1
        Me.gpCriterio.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpCriterio.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpCriterio.Style.BorderLeftWidth = 1
        Me.gpCriterio.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpCriterio.Style.BorderRightWidth = 1
        Me.gpCriterio.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpCriterio.Style.BorderTopWidth = 1
        Me.gpCriterio.Style.CornerDiameter = 4
        Me.gpCriterio.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpCriterio.Style.TextColor = System.Drawing.SystemColors.WindowText
        Me.gpCriterio.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpCriterio.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpCriterio.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpCriterio.TabIndex = 17
        Me.gpCriterio.Text = "CRITERIOS DEL CLIENTE"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabelX3.Location = New System.Drawing.Point(3, 32)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(52, 23)
        Me.LabelX3.TabIndex = 7
        Me.LabelX3.Text = "Cliente:"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabelX5.Location = New System.Drawing.Point(3, 3)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(52, 23)
        Me.LabelX5.TabIndex = 6
        Me.LabelX5.Text = "Código:"
        '
        'tbCodigoCliente
        '
        '
        '
        '
        Me.tbCodigoCliente.Border.Class = "TextBoxBorder"
        Me.tbCodigoCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCodigoCliente.Location = New System.Drawing.Point(61, 4)
        Me.tbCodigoCliente.MaxLength = 15
        Me.tbCodigoCliente.Name = "tbCodigoCliente"
        Me.tbCodigoCliente.PreventEnterBeep = True
        Me.tbCodigoCliente.Size = New System.Drawing.Size(222, 21)
        Me.tbCodigoCliente.TabIndex = 8
        '
        'tbNombreCliente
        '
        '
        '
        '
        Me.tbNombreCliente.Border.Class = "TextBoxBorder"
        Me.tbNombreCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNombreCliente.Location = New System.Drawing.Point(61, 34)
        Me.tbNombreCliente.MaxLength = 50
        Me.tbNombreCliente.Name = "tbNombreCliente"
        Me.tbNombreCliente.PreventEnterBeep = True
        Me.tbNombreCliente.Size = New System.Drawing.Size(222, 21)
        Me.tbNombreCliente.TabIndex = 9
        '
        'R01_EquipoPrestadoVsVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "R01_EquipoPrestadoVsVenta"
        Me.Text = "R01_PrestamoEquiposAgrupado"
        Me.Controls.SetChildIndex(Me.MPnInferior, 0)
        Me.Controls.SetChildIndex(Me.MPnUsuario, 0)
        Me.MPnSuperior.ResumeLayout(False)
        Me.MPnInferior.ResumeLayout(False)
        Me.MPanelToolBarUsuario.ResumeLayout(False)
        Me.MPanelToolBarUsuario.PerformLayout()
        Me.MPanelToolBarAccion.ResumeLayout(False)
        CType(Me.MBubbleBarUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MPnUsuario.ResumeLayout(False)
        Me.MPnUsuario.PerformLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MGpFiltro.ResumeLayout(False)
        Me.gpFiltroProducto.ResumeLayout(False)
        Me.gpFiltroFechas.ResumeLayout(False)
        CType(Me.DtiHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtiDesde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpCriterio.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpFiltroProducto As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents SbFiltroTodosUno As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbDescripcionProducto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbCodigoProducto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btBuscarProducto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents gpFiltroFechas As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DtiHasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents DtiDesde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents gpCriterio As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents tbNombreCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbCodigoCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
End Class
