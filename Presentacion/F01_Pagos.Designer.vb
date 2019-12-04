<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F01_Pagos
    Inherits Modelo.ModeloF01_ca

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanelBase = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelArriba = New System.Windows.Forms.Panel()
        Me.GroupPanelDatoPago = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelDatoPago = New System.Windows.Forms.Panel()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.tbdSaldo = New DevComponents.Editors.DoubleInput()
        Me.btBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.tbCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbRecibo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.dtiFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.tbdMonto = New DevComponents.Editors.DoubleInput()
        Me.tbCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanelBuscador = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.dgjBusqueda = New Janus.Windows.GridEX.GridEX()
        CType(Me.MSuperTabControlPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MSuperTabControlPrincipal.SuspendLayout()
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
        Me.TableLayoutPanelBase.SuspendLayout()
        Me.PanelArriba.SuspendLayout()
        Me.GroupPanelDatoPago.SuspendLayout()
        Me.PanelDatoPago.SuspendLayout()
        CType(Me.tbdSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtiFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbdMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanelBuscador.SuspendLayout()
        CType(Me.dgjBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.MSuperTabControlPrincipal.Size = New System.Drawing.Size(1362, 635)
        Me.MSuperTabControlPrincipal.Controls.SetChildIndex(Me.MSuperTabControlPanelRegistro, 0)
        '
        'MSuperTabControlPanelRegistro
        '
        Me.MSuperTabControlPanelRegistro.Controls.Add(Me.TableLayoutPanelBase)
        Me.MSuperTabControlPanelRegistro.Size = New System.Drawing.Size(1320, 635)
        Me.MSuperTabControlPanelRegistro.Controls.SetChildIndex(Me.MPnUsuario, 0)
        Me.MSuperTabControlPanelRegistro.Controls.SetChildIndex(Me.TableLayoutPanelBase, 0)
        '
        'MPnSuperior
        '
        Me.MPnSuperior.Size = New System.Drawing.Size(1362, 70)
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
        Me.MPnInferior.Location = New System.Drawing.Point(0, 705)
        Me.MPnInferior.Size = New System.Drawing.Size(1362, 36)
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
        Me.MPanelToolBarUsuario.Location = New System.Drawing.Point(1162, 0)
        '
        'MTbUsuario
        '
        Me.MTbUsuario.ReadOnly = True
        Me.MTbUsuario.Text = "DEFAULT"
        '
        'MBtUltimo
        '
        '
        'MBtSiguiente
        '
        '
        'MBtAnterior
        '
        '
        'MBtPrimero
        '
        '
        'MBtSalir
        '
        '
        'MBtGrabar
        '
        '
        'MBtEliminar
        '
        '
        'MBtModificar
        '
        '
        'MBtNuevo
        '
        '
        'MPanelToolBarImprimir
        '
        Me.MPanelToolBarImprimir.Location = New System.Drawing.Point(1282, 0)
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
        '
        'TableLayoutPanelBase
        '
        Me.TableLayoutPanelBase.ColumnCount = 1
        Me.TableLayoutPanelBase.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelBase.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelBase.Controls.Add(Me.PanelArriba, 0, 0)
        Me.TableLayoutPanelBase.Controls.Add(Me.GroupPanelBuscador, 0, 1)
        Me.TableLayoutPanelBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelBase.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelBase.Name = "TableLayoutPanelBase"
        Me.TableLayoutPanelBase.RowCount = 2
        Me.TableLayoutPanelBase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanelBase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanelBase.Size = New System.Drawing.Size(1320, 635)
        Me.TableLayoutPanelBase.TabIndex = 29
        '
        'PanelArriba
        '
        Me.PanelArriba.Controls.Add(Me.GroupPanelDatoPago)
        Me.PanelArriba.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelArriba.Location = New System.Drawing.Point(3, 3)
        Me.PanelArriba.Name = "PanelArriba"
        Me.PanelArriba.Size = New System.Drawing.Size(1314, 248)
        Me.PanelArriba.TabIndex = 0
        '
        'GroupPanelDatoPago
        '
        Me.GroupPanelDatoPago.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelDatoPago.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelDatoPago.Controls.Add(Me.PanelDatoPago)
        Me.GroupPanelDatoPago.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelDatoPago.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelDatoPago.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanelDatoPago.Name = "GroupPanelDatoPago"
        Me.GroupPanelDatoPago.Size = New System.Drawing.Size(1314, 248)
        '
        '
        '
        Me.GroupPanelDatoPago.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanelDatoPago.Style.BackColorGradientAngle = 90
        Me.GroupPanelDatoPago.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanelDatoPago.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatoPago.Style.BorderBottomWidth = 1
        Me.GroupPanelDatoPago.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelDatoPago.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatoPago.Style.BorderLeftWidth = 1
        Me.GroupPanelDatoPago.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatoPago.Style.BorderRightWidth = 1
        Me.GroupPanelDatoPago.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatoPago.Style.BorderTopWidth = 1
        Me.GroupPanelDatoPago.Style.CornerDiameter = 4
        Me.GroupPanelDatoPago.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelDatoPago.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelDatoPago.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelDatoPago.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelDatoPago.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelDatoPago.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelDatoPago.TabIndex = 0
        Me.GroupPanelDatoPago.Text = "DATOS DE PAGO"
        '
        'PanelDatoPago
        '
        Me.PanelDatoPago.AutoScroll = True
        Me.PanelDatoPago.BackColor = System.Drawing.Color.Transparent
        Me.PanelDatoPago.Controls.Add(Me.LabelX6)
        Me.PanelDatoPago.Controls.Add(Me.tbdSaldo)
        Me.PanelDatoPago.Controls.Add(Me.btBuscar)
        Me.PanelDatoPago.Controls.Add(Me.tbCliente)
        Me.PanelDatoPago.Controls.Add(Me.tbRecibo)
        Me.PanelDatoPago.Controls.Add(Me.LabelX5)
        Me.PanelDatoPago.Controls.Add(Me.LabelX4)
        Me.PanelDatoPago.Controls.Add(Me.LabelX3)
        Me.PanelDatoPago.Controls.Add(Me.LabelX2)
        Me.PanelDatoPago.Controls.Add(Me.dtiFecha)
        Me.PanelDatoPago.Controls.Add(Me.tbdMonto)
        Me.PanelDatoPago.Controls.Add(Me.tbCodigo)
        Me.PanelDatoPago.Controls.Add(Me.LabelX1)
        Me.PanelDatoPago.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDatoPago.Location = New System.Drawing.Point(0, 0)
        Me.PanelDatoPago.Name = "PanelDatoPago"
        Me.PanelDatoPago.Size = New System.Drawing.Size(1308, 227)
        Me.PanelDatoPago.TabIndex = 0
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.LabelX6.Location = New System.Drawing.Point(6, 149)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 23)
        Me.LabelX6.TabIndex = 12
        Me.LabelX6.Text = "Saldo:"
        '
        'tbdSaldo
        '
        '
        '
        '
        Me.tbdSaldo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbdSaldo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbdSaldo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbdSaldo.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.tbdSaldo.Increment = 1.0R
        Me.tbdSaldo.Location = New System.Drawing.Point(87, 149)
        Me.tbdSaldo.Name = "tbdSaldo"
        Me.tbdSaldo.Size = New System.Drawing.Size(100, 23)
        Me.tbdSaldo.TabIndex = 4
        '
        'btBuscar
        '
        Me.btBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btBuscar.Image = Global.Presentacion.My.Resources.Resources.buscar
        Me.btBuscar.ImageFixedSize = New System.Drawing.Size(22, 22)
        Me.btBuscar.Location = New System.Drawing.Point(370, 91)
        Me.btBuscar.Name = "btBuscar"
        Me.btBuscar.Size = New System.Drawing.Size(23, 23)
        Me.btBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btBuscar.TabIndex = 6
        '
        'tbCliente
        '
        '
        '
        '
        Me.tbCliente.Border.Class = "TextBoxBorder"
        Me.tbCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCliente.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.tbCliente.Location = New System.Drawing.Point(87, 91)
        Me.tbCliente.Name = "tbCliente"
        Me.tbCliente.PreventEnterBeep = True
        Me.tbCliente.Size = New System.Drawing.Size(283, 23)
        Me.tbCliente.TabIndex = 2
        '
        'tbRecibo
        '
        '
        '
        '
        Me.tbRecibo.Border.Class = "TextBoxBorder"
        Me.tbRecibo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbRecibo.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.tbRecibo.Location = New System.Drawing.Point(87, 33)
        Me.tbRecibo.Name = "tbRecibo"
        Me.tbRecibo.PreventEnterBeep = True
        Me.tbRecibo.Size = New System.Drawing.Size(100, 23)
        Me.tbRecibo.TabIndex = 0
        Me.tbRecibo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.LabelX5.Location = New System.Drawing.Point(6, 120)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 23)
        Me.LabelX5.TabIndex = 7
        Me.LabelX5.Text = "Monto:"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.LabelX4.Location = New System.Drawing.Point(6, 91)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 6
        Me.LabelX4.Text = "Cliente:"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.LabelX3.Location = New System.Drawing.Point(6, 62)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 5
        Me.LabelX3.Text = "Fecha:"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.LabelX2.Location = New System.Drawing.Point(6, 33)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 4
        Me.LabelX2.Text = "Recibo:"
        '
        'dtiFecha
        '
        '
        '
        '
        Me.dtiFecha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtiFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFecha.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtiFecha.ButtonDropDown.Visible = True
        Me.dtiFecha.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.dtiFecha.IsPopupCalendarOpen = False
        Me.dtiFecha.Location = New System.Drawing.Point(87, 62)
        '
        '
        '
        '
        '
        '
        Me.dtiFecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFecha.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtiFecha.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtiFecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtiFecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiFecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtiFecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtiFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtiFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtiFecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFecha.MonthCalendar.DisplayMonth = New Date(2018, 2, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.dtiFecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtiFecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiFecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtiFecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFecha.MonthCalendar.TodayButtonVisible = True
        Me.dtiFecha.Name = "dtiFecha"
        Me.dtiFecha.Size = New System.Drawing.Size(100, 23)
        Me.dtiFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtiFecha.TabIndex = 1
        '
        'tbdMonto
        '
        '
        '
        '
        Me.tbdMonto.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbdMonto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbdMonto.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbdMonto.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.tbdMonto.Increment = 1.0R
        Me.tbdMonto.Location = New System.Drawing.Point(87, 120)
        Me.tbdMonto.MinValue = 0R
        Me.tbdMonto.Name = "tbdMonto"
        Me.tbdMonto.Size = New System.Drawing.Size(100, 23)
        Me.tbdMonto.TabIndex = 3
        '
        'tbCodigo
        '
        '
        '
        '
        Me.tbCodigo.Border.Class = "TextBoxBorder"
        Me.tbCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCodigo.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.tbCodigo.Location = New System.Drawing.Point(87, 3)
        Me.tbCodigo.Name = "tbCodigo"
        Me.tbCodigo.PreventEnterBeep = True
        Me.tbCodigo.Size = New System.Drawing.Size(100, 23)
        Me.tbCodigo.TabIndex = 5
        Me.tbCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.LabelX1.Location = New System.Drawing.Point(6, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Código:"
        '
        'GroupPanelBuscador
        '
        Me.GroupPanelBuscador.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelBuscador.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelBuscador.Controls.Add(Me.dgjBusqueda)
        Me.GroupPanelBuscador.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelBuscador.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelBuscador.Location = New System.Drawing.Point(3, 257)
        Me.GroupPanelBuscador.Name = "GroupPanelBuscador"
        Me.GroupPanelBuscador.Size = New System.Drawing.Size(1314, 375)
        '
        '
        '
        Me.GroupPanelBuscador.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanelBuscador.Style.BackColorGradientAngle = 90
        Me.GroupPanelBuscador.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanelBuscador.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBuscador.Style.BorderBottomWidth = 1
        Me.GroupPanelBuscador.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelBuscador.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBuscador.Style.BorderLeftWidth = 1
        Me.GroupPanelBuscador.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBuscador.Style.BorderRightWidth = 1
        Me.GroupPanelBuscador.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBuscador.Style.BorderTopWidth = 1
        Me.GroupPanelBuscador.Style.CornerDiameter = 4
        Me.GroupPanelBuscador.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelBuscador.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelBuscador.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelBuscador.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelBuscador.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelBuscador.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelBuscador.TabIndex = 1
        Me.GroupPanelBuscador.Text = "BUSCADOR"
        '
        'dgjBusqueda
        '
        Me.dgjBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgjBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.dgjBusqueda.Name = "dgjBusqueda"
        Me.dgjBusqueda.Size = New System.Drawing.Size(1308, 354)
        Me.dgjBusqueda.TabIndex = 0
        '
        'F01_Pagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1362, 741)
        Me.Name = "F01_Pagos"
        Me.Text = "F01_Pagos"
        Me.Controls.SetChildIndex(Me.MPnSuperior, 0)
        Me.Controls.SetChildIndex(Me.MPnInferior, 0)
        Me.Controls.SetChildIndex(Me.MSuperTabControlPrincipal, 0)
        CType(Me.MSuperTabControlPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MSuperTabControlPrincipal.ResumeLayout(False)
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
        Me.TableLayoutPanelBase.ResumeLayout(False)
        Me.PanelArriba.ResumeLayout(False)
        Me.GroupPanelDatoPago.ResumeLayout(False)
        Me.PanelDatoPago.ResumeLayout(False)
        CType(Me.tbdSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtiFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbdMonto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanelBuscador.ResumeLayout(False)
        CType(Me.dgjBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanelBase As TableLayoutPanel
    Friend WithEvents PanelArriba As Panel
    Friend WithEvents GroupPanelDatoPago As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PanelDatoPago As Panel
    Friend WithEvents GroupPanelBuscador As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents dgjBusqueda As Janus.Windows.GridEX.GridEX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbdSaldo As DevComponents.Editors.DoubleInput
    Friend WithEvents btBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents tbCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbRecibo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtiFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents tbdMonto As DevComponents.Editors.DoubleInput
    Friend WithEvents tbCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
End Class
