<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F02_Compra
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
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanelPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupPanelDetalle = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.dgjDetalle = New Janus.Windows.GridEX.GridEX()
        Me.cmDetalle = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiEliminarFilaDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupPanelDatosGenerales = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelExDatosGenerales = New DevComponents.DotNetBar.PanelEx()
        Me.swAsiento = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.swRetencion = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanelFactura2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lbNFactura = New DevComponents.DotNetBar.LabelX()
        Me.tbSACF = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbNroFactura = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lbSACF = New DevComponents.DotNetBar.LabelX()
        Me.lbNAutoriz = New DevComponents.DotNetBar.LabelX()
        Me.tbNDui = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbNAutorizacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lbNDui = New DevComponents.DotNetBar.LabelX()
        Me.lbCodCtrl = New DevComponents.DotNetBar.LabelX()
        Me.tbCodControl = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.swConsigna = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.swEmision = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.lbCredito = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.tbFechaVenc = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.swTipoVenta = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.tbNitProv = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btBuscarProveedor = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.tbObs = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbProveedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbCodProveedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.dtiFechaCompra = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.tbCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tbtotal = New DevComponents.Editors.DoubleInput()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.tbMdesc = New DevComponents.Editors.DoubleInput()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.tbSubtotalC = New DevComponents.Editors.DoubleInput()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanelBuscador = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.dgjBusqueda = New Janus.Windows.GridEX.GridEX()
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
        Me.GroupPanelDetalle.SuspendLayout()
        CType(Me.dgjDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmDetalle.SuspendLayout()
        Me.GroupPanelDatosGenerales.SuspendLayout()
        Me.PanelExDatosGenerales.SuspendLayout()
        Me.GroupPanelFactura2.SuspendLayout()
        CType(Me.tbFechaVenc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtiFechaCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.tbtotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbMdesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSubtotalC, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.MSuperTabControlPrincipal.SelectedTabIndex = 1
        Me.MSuperTabControlPrincipal.Size = New System.Drawing.Size(1286, 455)
        Me.MSuperTabControlPrincipal.Controls.SetChildIndex(Me.MSuperTabControlPanelRegistro, 0)
        Me.MSuperTabControlPrincipal.Controls.SetChildIndex(Me.MSuperTabControlPanelBusqueda, 0)
        '
        'MSuperTabControlPanelBusqueda
        '
        Me.MSuperTabControlPanelBusqueda.Controls.Add(Me.GroupPanelBuscador)
        Me.MSuperTabControlPanelBusqueda.Margin = New System.Windows.Forms.Padding(4)
        Me.MSuperTabControlPanelBusqueda.Size = New System.Drawing.Size(1244, 455)
        '
        'MSuperTabControlPanelRegistro
        '
        Me.MSuperTabControlPanelRegistro.Controls.Add(Me.TableLayoutPanelPrincipal)
        Me.MSuperTabControlPanelRegistro.Margin = New System.Windows.Forms.Padding(4)
        Me.MSuperTabControlPanelRegistro.Size = New System.Drawing.Size(1244, 455)
        Me.MSuperTabControlPanelRegistro.Controls.SetChildIndex(Me.TableLayoutPanelPrincipal, 0)
        Me.MSuperTabControlPanelRegistro.Controls.SetChildIndex(Me.MPnUsuario, 0)
        '
        'MPnSuperior
        '
        Me.MPnSuperior.Size = New System.Drawing.Size(1286, 70)
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
        Me.MPnInferior.Size = New System.Drawing.Size(1286, 36)
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
        Me.MPanelToolBarUsuario.Location = New System.Drawing.Point(1086, 0)
        '
        'MTbUsuario
        '
        Me.MTbUsuario.Margin = New System.Windows.Forms.Padding(4)
        Me.MTbUsuario.ReadOnly = True
        Me.MTbUsuario.Size = New System.Drawing.Size(135, 32)
        Me.MTbUsuario.Text = "DEFAULT"
        '
        'MBtUltimo
        '
        Me.MBtUltimo.Margin = New System.Windows.Forms.Padding(2)
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
        Me.MPanelToolBarImprimir.Location = New System.Drawing.Point(1206, 0)
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
        'MPnUsuario
        '
        Me.MPnUsuario.Location = New System.Drawing.Point(421, -2)
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
        'TableLayoutPanelPrincipal
        '
        Me.TableLayoutPanelPrincipal.ColumnCount = 1
        Me.TableLayoutPanelPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelPrincipal.Controls.Add(Me.GroupPanelDetalle, 0, 1)
        Me.TableLayoutPanelPrincipal.Controls.Add(Me.GroupPanelDatosGenerales, 0, 0)
        Me.TableLayoutPanelPrincipal.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelPrincipal.Name = "TableLayoutPanelPrincipal"
        Me.TableLayoutPanelPrincipal.RowCount = 3
        Me.TableLayoutPanelPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.TableLayoutPanelPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanelPrincipal.Size = New System.Drawing.Size(1244, 455)
        Me.TableLayoutPanelPrincipal.TabIndex = 29
        '
        'GroupPanelDetalle
        '
        Me.GroupPanelDetalle.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelDetalle.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelDetalle.Controls.Add(Me.dgjDetalle)
        Me.GroupPanelDetalle.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelDetalle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelDetalle.Location = New System.Drawing.Point(3, 203)
        Me.GroupPanelDetalle.Name = "GroupPanelDetalle"
        Me.GroupPanelDetalle.Size = New System.Drawing.Size(1238, 199)
        '
        '
        '
        Me.GroupPanelDetalle.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanelDetalle.Style.BackColorGradientAngle = 90
        Me.GroupPanelDetalle.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanelDetalle.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDetalle.Style.BorderBottomWidth = 1
        Me.GroupPanelDetalle.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelDetalle.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDetalle.Style.BorderLeftWidth = 1
        Me.GroupPanelDetalle.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDetalle.Style.BorderRightWidth = 1
        Me.GroupPanelDetalle.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDetalle.Style.BorderTopWidth = 1
        Me.GroupPanelDetalle.Style.CornerDiameter = 4
        Me.GroupPanelDetalle.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelDetalle.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelDetalle.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelDetalle.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelDetalle.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelDetalle.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelDetalle.TabIndex = 1
        Me.GroupPanelDetalle.Text = "D E T A L L E"
        '
        'dgjDetalle
        '
        Me.dgjDetalle.ContextMenuStrip = Me.cmDetalle
        Me.dgjDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgjDetalle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgjDetalle.Location = New System.Drawing.Point(0, 0)
        Me.dgjDetalle.Name = "dgjDetalle"
        Me.dgjDetalle.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.dgjDetalle.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.dgjDetalle.Size = New System.Drawing.Size(1232, 177)
        Me.dgjDetalle.TabIndex = 0
        Me.dgjDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmDetalle
        '
        Me.cmDetalle.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmDetalle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiEliminarFilaDetalle})
        Me.cmDetalle.Name = "Cms1Equipos"
        Me.cmDetalle.Size = New System.Drawing.Size(148, 36)
        '
        'tsmiEliminarFilaDetalle
        '
        Me.tsmiEliminarFilaDetalle.Image = Global.Presentacion.My.Resources.Resources.eliminar
        Me.tsmiEliminarFilaDetalle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsmiEliminarFilaDetalle.Name = "tsmiEliminarFilaDetalle"
        Me.tsmiEliminarFilaDetalle.Size = New System.Drawing.Size(147, 32)
        Me.tsmiEliminarFilaDetalle.Text = "Eliminar Fila"
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
        Me.GroupPanelDatosGenerales.Size = New System.Drawing.Size(1238, 194)
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
        Me.GroupPanelDatosGenerales.TabIndex = 0
        Me.GroupPanelDatosGenerales.Text = "D A T O S   G E N E R A L E S"
        '
        'PanelExDatosGenerales
        '
        Me.PanelExDatosGenerales.AutoScroll = True
        Me.PanelExDatosGenerales.CanvasColor = System.Drawing.Color.Transparent
        Me.PanelExDatosGenerales.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelExDatosGenerales.Controls.Add(Me.swAsiento)
        Me.PanelExDatosGenerales.Controls.Add(Me.LabelX2)
        Me.PanelExDatosGenerales.Controls.Add(Me.swRetencion)
        Me.PanelExDatosGenerales.Controls.Add(Me.LabelX13)
        Me.PanelExDatosGenerales.Controls.Add(Me.GroupPanelFactura2)
        Me.PanelExDatosGenerales.Controls.Add(Me.swConsigna)
        Me.PanelExDatosGenerales.Controls.Add(Me.LabelX12)
        Me.PanelExDatosGenerales.Controls.Add(Me.swEmision)
        Me.PanelExDatosGenerales.Controls.Add(Me.LabelX16)
        Me.PanelExDatosGenerales.Controls.Add(Me.lbCredito)
        Me.PanelExDatosGenerales.Controls.Add(Me.LabelX5)
        Me.PanelExDatosGenerales.Controls.Add(Me.tbFechaVenc)
        Me.PanelExDatosGenerales.Controls.Add(Me.swTipoVenta)
        Me.PanelExDatosGenerales.Controls.Add(Me.LabelX4)
        Me.PanelExDatosGenerales.Controls.Add(Me.tbNitProv)
        Me.PanelExDatosGenerales.Controls.Add(Me.btBuscarProveedor)
        Me.PanelExDatosGenerales.Controls.Add(Me.LabelX3)
        Me.PanelExDatosGenerales.Controls.Add(Me.tbObs)
        Me.PanelExDatosGenerales.Controls.Add(Me.tbProveedor)
        Me.PanelExDatosGenerales.Controls.Add(Me.tbCodProveedor)
        Me.PanelExDatosGenerales.Controls.Add(Me.LabelX8)
        Me.PanelExDatosGenerales.Controls.Add(Me.dtiFechaCompra)
        Me.PanelExDatosGenerales.Controls.Add(Me.LabelX6)
        Me.PanelExDatosGenerales.Controls.Add(Me.tbCodigo)
        Me.PanelExDatosGenerales.Controls.Add(Me.LabelX1)
        Me.PanelExDatosGenerales.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelExDatosGenerales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelExDatosGenerales.Location = New System.Drawing.Point(0, 0)
        Me.PanelExDatosGenerales.Name = "PanelExDatosGenerales"
        Me.PanelExDatosGenerales.Size = New System.Drawing.Size(1232, 173)
        Me.PanelExDatosGenerales.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelExDatosGenerales.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PanelExDatosGenerales.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PanelExDatosGenerales.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelExDatosGenerales.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelExDatosGenerales.Style.GradientAngle = 90
        Me.PanelExDatosGenerales.TabIndex = 0
        '
        'swAsiento
        '
        '
        '
        '
        Me.swAsiento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swAsiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.swAsiento.Location = New System.Drawing.Point(744, 137)
        Me.swAsiento.Name = "swAsiento"
        Me.swAsiento.OffBackColor = System.Drawing.Color.RoyalBlue
        Me.swAsiento.OffText = "NO"
        Me.swAsiento.OnBackColor = System.Drawing.Color.LightSkyBlue
        Me.swAsiento.OnText = "SI"
        Me.swAsiento.Size = New System.Drawing.Size(65, 22)
        Me.swAsiento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swAsiento.TabIndex = 384
        Me.swAsiento.Value = True
        Me.swAsiento.ValueObject = "Y"
        Me.swAsiento.Visible = False
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX2.Location = New System.Drawing.Point(705, 137)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(55, 23)
        Me.LabelX2.TabIndex = 385
        Me.LabelX2.Text = "Asiento:"
        Me.LabelX2.Visible = False
        '
        'swRetencion
        '
        '
        '
        '
        Me.swRetencion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swRetencion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.swRetencion.Location = New System.Drawing.Point(747, 109)
        Me.swRetencion.Name = "swRetencion"
        Me.swRetencion.OffBackColor = System.Drawing.Color.RoyalBlue
        Me.swRetencion.OffText = "NO"
        Me.swRetencion.OnBackColor = System.Drawing.Color.LightSkyBlue
        Me.swRetencion.OnText = "SI"
        Me.swRetencion.Size = New System.Drawing.Size(65, 22)
        Me.swRetencion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swRetencion.TabIndex = 382
        Me.swRetencion.Visible = False
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX13.Location = New System.Drawing.Point(706, 108)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(70, 23)
        Me.LabelX13.TabIndex = 383
        Me.LabelX13.Text = "Retención:"
        Me.LabelX13.Visible = False
        '
        'GroupPanelFactura2
        '
        Me.GroupPanelFactura2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelFactura2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelFactura2.Controls.Add(Me.lbNFactura)
        Me.GroupPanelFactura2.Controls.Add(Me.tbSACF)
        Me.GroupPanelFactura2.Controls.Add(Me.tbNroFactura)
        Me.GroupPanelFactura2.Controls.Add(Me.lbSACF)
        Me.GroupPanelFactura2.Controls.Add(Me.lbNAutoriz)
        Me.GroupPanelFactura2.Controls.Add(Me.tbNDui)
        Me.GroupPanelFactura2.Controls.Add(Me.tbNAutorizacion)
        Me.GroupPanelFactura2.Controls.Add(Me.lbNDui)
        Me.GroupPanelFactura2.Controls.Add(Me.lbCodCtrl)
        Me.GroupPanelFactura2.Controls.Add(Me.tbCodControl)
        Me.GroupPanelFactura2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelFactura2.Location = New System.Drawing.Point(816, 6)
        Me.GroupPanelFactura2.Name = "GroupPanelFactura2"
        Me.GroupPanelFactura2.Size = New System.Drawing.Size(389, 160)
        '
        '
        '
        Me.GroupPanelFactura2.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanelFactura2.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanelFactura2.Style.BackColorGradientAngle = 90
        Me.GroupPanelFactura2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelFactura2.Style.BorderBottomWidth = 1
        Me.GroupPanelFactura2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelFactura2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelFactura2.Style.BorderLeftWidth = 1
        Me.GroupPanelFactura2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelFactura2.Style.BorderRightWidth = 1
        Me.GroupPanelFactura2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelFactura2.Style.BorderTopWidth = 1
        Me.GroupPanelFactura2.Style.CornerDiameter = 4
        Me.GroupPanelFactura2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelFactura2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelFactura2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelFactura2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelFactura2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelFactura2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelFactura2.TabIndex = 381
        Me.GroupPanelFactura2.Text = "DATOS FACTURACIÓN"
        '
        'lbNFactura
        '
        Me.lbNFactura.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lbNFactura.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbNFactura.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNFactura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lbNFactura.Location = New System.Drawing.Point(24, 4)
        Me.lbNFactura.Name = "lbNFactura"
        Me.lbNFactura.SingleLineColor = System.Drawing.SystemColors.Control
        Me.lbNFactura.Size = New System.Drawing.Size(105, 23)
        Me.lbNFactura.TabIndex = 356
        Me.lbNFactura.Text = "Nro. Factura:"
        '
        'tbSACF
        '
        Me.tbSACF.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbSACF.Border.Class = "TextBoxBorder"
        Me.tbSACF.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbSACF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSACF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbSACF.Location = New System.Drawing.Point(178, 110)
        Me.tbSACF.Name = "tbSACF"
        Me.tbSACF.PreventEnterBeep = True
        Me.tbSACF.Size = New System.Drawing.Size(180, 22)
        Me.tbSACF.TabIndex = 365
        Me.tbSACF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNroFactura
        '
        Me.tbNroFactura.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbNroFactura.Border.Class = "TextBoxBorder"
        Me.tbNroFactura.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNroFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNroFactura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbNroFactura.Location = New System.Drawing.Point(178, 3)
        Me.tbNroFactura.Name = "tbNroFactura"
        Me.tbNroFactura.PreventEnterBeep = True
        Me.tbNroFactura.Size = New System.Drawing.Size(180, 22)
        Me.tbNroFactura.TabIndex = 355
        Me.tbNroFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbSACF
        '
        Me.lbSACF.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lbSACF.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbSACF.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSACF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lbSACF.Location = New System.Drawing.Point(25, 110)
        Me.lbSACF.Name = "lbSACF"
        Me.lbSACF.SingleLineColor = System.Drawing.SystemColors.Control
        Me.lbSACF.Size = New System.Drawing.Size(134, 22)
        Me.lbSACF.TabIndex = 364
        Me.lbSACF.Text = "Sujeto a Créd. Fiscal:"
        '
        'lbNAutoriz
        '
        Me.lbNAutoriz.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lbNAutoriz.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbNAutoriz.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNAutoriz.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lbNAutoriz.Location = New System.Drawing.Point(25, 30)
        Me.lbNAutoriz.Name = "lbNAutoriz"
        Me.lbNAutoriz.SingleLineColor = System.Drawing.SystemColors.Control
        Me.lbNAutoriz.Size = New System.Drawing.Size(125, 22)
        Me.lbNAutoriz.TabIndex = 358
        Me.lbNAutoriz.Text = "Nro. Autorización:"
        '
        'tbNDui
        '
        Me.tbNDui.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbNDui.Border.Class = "TextBoxBorder"
        Me.tbNDui.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNDui.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNDui.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbNDui.Location = New System.Drawing.Point(178, 83)
        Me.tbNDui.Name = "tbNDui"
        Me.tbNDui.PreventEnterBeep = True
        Me.tbNDui.Size = New System.Drawing.Size(180, 22)
        Me.tbNDui.TabIndex = 363
        Me.tbNDui.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNAutorizacion
        '
        Me.tbNAutorizacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbNAutorizacion.Border.Class = "TextBoxBorder"
        Me.tbNAutorizacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNAutorizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNAutorizacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbNAutorizacion.Location = New System.Drawing.Point(178, 29)
        Me.tbNAutorizacion.Name = "tbNAutorizacion"
        Me.tbNAutorizacion.PreventEnterBeep = True
        Me.tbNAutorizacion.Size = New System.Drawing.Size(180, 22)
        Me.tbNAutorizacion.TabIndex = 359
        Me.tbNAutorizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbNDui
        '
        Me.lbNDui.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lbNDui.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbNDui.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNDui.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lbNDui.Location = New System.Drawing.Point(25, 84)
        Me.lbNDui.Name = "lbNDui"
        Me.lbNDui.SingleLineColor = System.Drawing.SystemColors.Control
        Me.lbNDui.Size = New System.Drawing.Size(105, 22)
        Me.lbNDui.TabIndex = 362
        Me.lbNDui.Text = "Número DUI:"
        '
        'lbCodCtrl
        '
        Me.lbCodCtrl.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lbCodCtrl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbCodCtrl.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCodCtrl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lbCodCtrl.Location = New System.Drawing.Point(24, 57)
        Me.lbCodCtrl.Name = "lbCodCtrl"
        Me.lbCodCtrl.SingleLineColor = System.Drawing.SystemColors.Control
        Me.lbCodCtrl.Size = New System.Drawing.Size(135, 23)
        Me.lbCodCtrl.TabIndex = 361
        Me.lbCodCtrl.Text = "Código de Control:"
        '
        'tbCodControl
        '
        Me.tbCodControl.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbCodControl.Border.Class = "TextBoxBorder"
        Me.tbCodControl.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCodControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodControl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbCodControl.Location = New System.Drawing.Point(178, 56)
        Me.tbCodControl.MaxLength = 14
        Me.tbCodControl.Name = "tbCodControl"
        Me.tbCodControl.PreventEnterBeep = True
        Me.tbCodControl.Size = New System.Drawing.Size(180, 22)
        Me.tbCodControl.TabIndex = 360
        '
        'swConsigna
        '
        '
        '
        '
        Me.swConsigna.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swConsigna.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.swConsigna.Location = New System.Drawing.Point(610, 109)
        Me.swConsigna.Name = "swConsigna"
        Me.swConsigna.OffBackColor = System.Drawing.Color.Teal
        Me.swConsigna.OffText = "NO"
        Me.swConsigna.OnBackColor = System.Drawing.Color.DodgerBlue
        Me.swConsigna.OnText = "SI"
        Me.swConsigna.Size = New System.Drawing.Size(91, 22)
        Me.swConsigna.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swConsigna.TabIndex = 379
        '
        'LabelX12
        '
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX12.Location = New System.Drawing.Point(504, 109)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(90, 23)
        Me.LabelX12.TabIndex = 380
        Me.LabelX12.Text = "Consignación:"
        Me.LabelX12.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'swEmision
        '
        '
        '
        '
        Me.swEmision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swEmision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.swEmision.Location = New System.Drawing.Point(610, 76)
        Me.swEmision.Name = "swEmision"
        Me.swEmision.OffBackColor = System.Drawing.Color.LawnGreen
        Me.swEmision.OffText = "RECIBO"
        Me.swEmision.OnBackColor = System.Drawing.Color.Gold
        Me.swEmision.OnText = "FACTURA"
        Me.swEmision.Size = New System.Drawing.Size(110, 22)
        Me.swEmision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swEmision.TabIndex = 377
        Me.swEmision.Value = True
        Me.swEmision.ValueObject = "Y"
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX16.Location = New System.Drawing.Point(534, 75)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(60, 23)
        Me.LabelX16.TabIndex = 378
        Me.LabelX16.Text = "Emisión:"
        Me.LabelX16.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lbCredito
        '
        Me.lbCredito.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lbCredito.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbCredito.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCredito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lbCredito.Location = New System.Drawing.Point(438, 43)
        Me.lbCredito.Name = "lbCredito"
        Me.lbCredito.SingleLineColor = System.Drawing.SystemColors.Control
        Me.lbCredito.Size = New System.Drawing.Size(156, 23)
        Me.lbCredito.TabIndex = 375
        Me.lbCredito.Text = "Vencimiento de Crédito:"
        Me.lbCredito.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX5.Location = New System.Drawing.Point(465, 9)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX5.Size = New System.Drawing.Size(129, 23)
        Me.LabelX5.TabIndex = 374
        Me.LabelX5.Text = "Tipo Compra:"
        Me.LabelX5.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'tbFechaVenc
        '
        '
        '
        '
        Me.tbFechaVenc.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbFechaVenc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaVenc.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.tbFechaVenc.ButtonDropDown.Visible = True
        Me.tbFechaVenc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFechaVenc.IsPopupCalendarOpen = False
        Me.tbFechaVenc.Location = New System.Drawing.Point(610, 43)
        '
        '
        '
        '
        '
        '
        Me.tbFechaVenc.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaVenc.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.tbFechaVenc.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.tbFechaVenc.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.tbFechaVenc.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.tbFechaVenc.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.tbFechaVenc.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.tbFechaVenc.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.tbFechaVenc.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.tbFechaVenc.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaVenc.MonthCalendar.DisplayMonth = New Date(2017, 2, 1, 0, 0, 0, 0)
        Me.tbFechaVenc.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.tbFechaVenc.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.tbFechaVenc.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.tbFechaVenc.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.tbFechaVenc.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaVenc.MonthCalendar.TodayButtonVisible = True
        Me.tbFechaVenc.Name = "tbFechaVenc"
        Me.tbFechaVenc.Size = New System.Drawing.Size(120, 22)
        Me.tbFechaVenc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbFechaVenc.TabIndex = 371
        '
        'swTipoVenta
        '
        '
        '
        '
        Me.swTipoVenta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swTipoVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.swTipoVenta.Location = New System.Drawing.Point(610, 10)
        Me.swTipoVenta.Name = "swTipoVenta"
        Me.swTipoVenta.OffBackColor = System.Drawing.Color.LawnGreen
        Me.swTipoVenta.OffText = "CREDITO"
        Me.swTipoVenta.OnBackColor = System.Drawing.Color.Gold
        Me.swTipoVenta.OnText = "CONTADO"
        Me.swTipoVenta.Size = New System.Drawing.Size(135, 22)
        Me.swTipoVenta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swTipoVenta.TabIndex = 372
        Me.swTipoVenta.Value = True
        Me.swTipoVenta.ValueObject = "Y"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX4.Location = New System.Drawing.Point(6, 90)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(100, 22)
        Me.LabelX4.TabIndex = 356
        Me.LabelX4.Text = "Nit Proveedor:"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'tbNitProv
        '
        Me.tbNitProv.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbNitProv.Border.Class = "TextBoxBorder"
        Me.tbNitProv.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNitProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNitProv.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbNitProv.Location = New System.Drawing.Point(112, 91)
        Me.tbNitProv.Name = "tbNitProv"
        Me.tbNitProv.PreventEnterBeep = True
        Me.tbNitProv.Size = New System.Drawing.Size(150, 22)
        Me.tbNitProv.TabIndex = 355
        Me.tbNitProv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btBuscarProveedor
        '
        Me.btBuscarProveedor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btBuscarProveedor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btBuscarProveedor.Image = Global.Presentacion.My.Resources.Resources.buscar
        Me.btBuscarProveedor.ImageFixedSize = New System.Drawing.Size(23, 23)
        Me.btBuscarProveedor.Location = New System.Drawing.Point(379, 62)
        Me.btBuscarProveedor.Name = "btBuscarProveedor"
        Me.btBuscarProveedor.Size = New System.Drawing.Size(40, 24)
        Me.btBuscarProveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btBuscarProveedor.TabIndex = 116
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX3.Location = New System.Drawing.Point(6, 114)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(100, 22)
        Me.LabelX3.TabIndex = 113
        Me.LabelX3.Text = "Observación:"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'tbObs
        '
        Me.tbObs.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbObs.Border.Class = "TextBoxBorder"
        Me.tbObs.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbObs.Location = New System.Drawing.Point(112, 119)
        Me.tbObs.Multiline = True
        Me.tbObs.Name = "tbObs"
        Me.tbObs.PreventEnterBeep = True
        Me.tbObs.Size = New System.Drawing.Size(307, 48)
        Me.tbObs.TabIndex = 3
        '
        'tbProveedor
        '
        '
        '
        '
        Me.tbProveedor.Border.Class = "TextBoxBorder"
        Me.tbProveedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbProveedor.Location = New System.Drawing.Point(112, 63)
        Me.tbProveedor.Name = "tbProveedor"
        Me.tbProveedor.PreventEnterBeep = True
        Me.tbProveedor.Size = New System.Drawing.Size(267, 23)
        Me.tbProveedor.TabIndex = 1
        '
        'tbCodProveedor
        '
        '
        '
        '
        Me.tbCodProveedor.Border.Class = "TextBoxBorder"
        Me.tbCodProveedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCodProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodProveedor.Location = New System.Drawing.Point(238, 34)
        Me.tbCodProveedor.Name = "tbCodProveedor"
        Me.tbCodProveedor.PreventEnterBeep = True
        Me.tbCodProveedor.Size = New System.Drawing.Size(51, 23)
        Me.tbCodProveedor.TabIndex = 112
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX8.Location = New System.Drawing.Point(1, 34)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(105, 23)
        Me.LabelX8.TabIndex = 111
        Me.LabelX8.Text = "*Fecha Compra:"
        Me.LabelX8.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dtiFechaCompra
        '
        '
        '
        '
        Me.dtiFechaCompra.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtiFechaCompra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFechaCompra.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtiFechaCompra.ButtonDropDown.Visible = True
        Me.dtiFechaCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtiFechaCompra.IsPopupCalendarOpen = False
        Me.dtiFechaCompra.Location = New System.Drawing.Point(112, 34)
        '
        '
        '
        '
        '
        '
        Me.dtiFechaCompra.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFechaCompra.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtiFechaCompra.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtiFechaCompra.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtiFechaCompra.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiFechaCompra.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtiFechaCompra.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtiFechaCompra.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtiFechaCompra.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtiFechaCompra.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFechaCompra.MonthCalendar.DisplayMonth = New Date(2017, 2, 1, 0, 0, 0, 0)
        Me.dtiFechaCompra.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.dtiFechaCompra.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtiFechaCompra.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiFechaCompra.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtiFechaCompra.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFechaCompra.MonthCalendar.TodayButtonVisible = True
        Me.dtiFechaCompra.Name = "dtiFechaCompra"
        Me.dtiFechaCompra.Size = New System.Drawing.Size(120, 23)
        Me.dtiFechaCompra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtiFechaCompra.TabIndex = 0
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX6.Location = New System.Drawing.Point(6, 64)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(100, 22)
        Me.LabelX6.TabIndex = 110
        Me.LabelX6.Text = "*Proveedor:"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'tbCodigo
        '
        '
        '
        '
        Me.tbCodigo.Border.Class = "TextBoxBorder"
        Me.tbCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodigo.Location = New System.Drawing.Point(112, 5)
        Me.tbCodigo.Name = "tbCodigo"
        Me.tbCodigo.PreventEnterBeep = True
        Me.tbCodigo.Size = New System.Drawing.Size(75, 23)
        Me.tbCodigo.TabIndex = 105
        Me.tbCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(6, 5)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(100, 23)
        Me.LabelX1.TabIndex = 106
        Me.LabelX1.Text = "Código:"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel1.Controls.Add(Me.tbtotal)
        Me.Panel1.Controls.Add(Me.LabelX11)
        Me.Panel1.Controls.Add(Me.tbMdesc)
        Me.Panel1.Controls.Add(Me.LabelX9)
        Me.Panel1.Controls.Add(Me.tbSubtotalC)
        Me.Panel1.Controls.Add(Me.LabelX10)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 408)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1238, 44)
        Me.Panel1.TabIndex = 2
        '
        'tbtotal
        '
        '
        '
        '
        Me.tbtotal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbtotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbtotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbtotal.Increment = 1.0R
        Me.tbtotal.Location = New System.Drawing.Point(1119, 12)
        Me.tbtotal.MinValue = 0R
        Me.tbtotal.Name = "tbtotal"
        Me.tbtotal.Size = New System.Drawing.Size(109, 21)
        Me.tbtotal.TabIndex = 45
        Me.tbtotal.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Right
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.ForeColor = System.Drawing.Color.White
        Me.LabelX11.Location = New System.Drawing.Point(1075, 14)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX11.Size = New System.Drawing.Size(40, 18)
        Me.LabelX11.TabIndex = 46
        Me.LabelX11.Text = "Total:"
        '
        'tbMdesc
        '
        '
        '
        '
        Me.tbMdesc.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbMdesc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbMdesc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbMdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMdesc.Increment = 1.0R
        Me.tbMdesc.Location = New System.Drawing.Point(962, 12)
        Me.tbMdesc.MinValue = 0R
        Me.tbMdesc.Name = "tbMdesc"
        Me.tbMdesc.Size = New System.Drawing.Size(89, 21)
        Me.tbMdesc.TabIndex = 43
        Me.tbMdesc.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Right
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.ForeColor = System.Drawing.Color.White
        Me.LabelX9.Location = New System.Drawing.Point(866, 13)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX9.Size = New System.Drawing.Size(90, 18)
        Me.LabelX9.TabIndex = 44
        Me.LabelX9.Text = "M. Descuento:"
        '
        'tbSubtotalC
        '
        '
        '
        '
        Me.tbSubtotalC.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbSubtotalC.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbSubtotalC.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbSubtotalC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSubtotalC.Increment = 1.0R
        Me.tbSubtotalC.Location = New System.Drawing.Point(727, 11)
        Me.tbSubtotalC.MinValue = 0R
        Me.tbSubtotalC.Name = "tbSubtotalC"
        Me.tbSubtotalC.Size = New System.Drawing.Size(111, 21)
        Me.tbSubtotalC.TabIndex = 41
        Me.tbSubtotalC.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Right
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.White
        Me.LabelX10.Location = New System.Drawing.Point(661, 13)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX10.Size = New System.Drawing.Size(60, 18)
        Me.LabelX10.TabIndex = 42
        Me.LabelX10.Text = "Subtotal:"
        '
        'GroupPanelBuscador
        '
        Me.GroupPanelBuscador.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelBuscador.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelBuscador.Controls.Add(Me.dgjBusqueda)
        Me.GroupPanelBuscador.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelBuscador.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelBuscador.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelBuscador.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanelBuscador.Name = "GroupPanelBuscador"
        Me.GroupPanelBuscador.Size = New System.Drawing.Size(1244, 455)
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
        Me.GroupPanelBuscador.TabIndex = 8
        Me.GroupPanelBuscador.Text = "B U S C A D O R"
        '
        'dgjBusqueda
        '
        Me.dgjBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgjBusqueda.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgjBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.dgjBusqueda.Name = "dgjBusqueda"
        Me.dgjBusqueda.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.dgjBusqueda.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.dgjBusqueda.Size = New System.Drawing.Size(1238, 433)
        Me.dgjBusqueda.TabIndex = 0
        Me.dgjBusqueda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'F02_Compra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1286, 561)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "F02_Compra"
        Me.Text = "F02_Compra"
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
        Me.GroupPanelDetalle.ResumeLayout(False)
        CType(Me.dgjDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmDetalle.ResumeLayout(False)
        Me.GroupPanelDatosGenerales.ResumeLayout(False)
        Me.PanelExDatosGenerales.ResumeLayout(False)
        Me.GroupPanelFactura2.ResumeLayout(False)
        CType(Me.tbFechaVenc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtiFechaCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.tbtotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbMdesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSubtotalC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanelBuscador.ResumeLayout(False)
        CType(Me.dgjBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanelPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupPanelDetalle As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents dgjDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupPanelBuscador As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents dgjBusqueda As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmDetalle As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiEliminarFilaDetalle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupPanelDatosGenerales As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PanelExDatosGenerales As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GroupPanelFactura2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lbNFactura As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbSACF As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbNroFactura As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lbSACF As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbNAutoriz As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbNDui As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbNAutorizacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lbNDui As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbCodCtrl As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbCodControl As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents swConsigna As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents swEmision As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbCredito As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbFechaVenc As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents swTipoVenta As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbNitProv As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btBuscarProveedor As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbObs As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbProveedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbCodProveedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtiFechaCompra As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel1 As Panel
    Friend WithEvents tbtotal As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbMdesc As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbSubtotalC As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents swAsiento As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents swRetencion As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
End Class
