<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F02_Precio
    Inherits Modelo.ModeloF01_ca

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
        Dim JCb_CatProducto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F02_Precio))
        Me.TableLayoutPanelPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanelDatos2 = New System.Windows.Forms.TableLayoutPanel()
        Me.GpCategoria = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PnCategoria = New DevComponents.DotNetBar.PanelEx()
        Me.btAddCategoria = New DevComponents.DotNetBar.ButtonX()
        Me.GpListaCategoria = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PnListaCategoria = New DevComponents.DotNetBar.PanelEx()
        Me.JGr_Categorias = New Janus.Windows.GridEX.GridEX()
        Me.TableLayoutPanelDatos1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GpDatosGenerales = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PnDatosGenerales = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.JCb_CatProducto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.GpListaPrecio = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PnListaPrecio = New DevComponents.DotNetBar.PanelEx()
        Me.JGr_Detalle = New Janus.Windows.GridEX.GridEX()
        Me.GridEXPrintDocumentListaPrecios = New Janus.Windows.GridEX.GridEXPrintDocument()
        Me.GridEXExporterListaPrecio = New Janus.Windows.GridEX.Export.GridEXExporter(Me.components)
        Me.btExportarExcel = New DevComponents.DotNetBar.ButtonX()
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
        Me.TableLayoutPanelPrincipal.SuspendLayout()
        Me.TableLayoutPanelDatos2.SuspendLayout()
        Me.GpCategoria.SuspendLayout()
        Me.PnCategoria.SuspendLayout()
        Me.GpListaCategoria.SuspendLayout()
        Me.PnListaCategoria.SuspendLayout()
        CType(Me.JGr_Categorias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanelDatos1.SuspendLayout()
        Me.GpDatosGenerales.SuspendLayout()
        Me.PnDatosGenerales.SuspendLayout()
        CType(Me.JCb_CatProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GpListaPrecio.SuspendLayout()
        Me.PnListaPrecio.SuspendLayout()
        CType(Me.JGr_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.MSuperTabControlPrincipal.Size = New System.Drawing.Size(884, 455)
        Me.MSuperTabControlPrincipal.Controls.SetChildIndex(Me.MSuperTabControlPanelRegistro, 0)
        '
        'MSuperTabControlPanelRegistro
        '
        Me.MSuperTabControlPanelRegistro.Controls.Add(Me.TableLayoutPanelPrincipal)
        Me.MSuperTabControlPanelRegistro.Size = New System.Drawing.Size(842, 455)
        Me.MSuperTabControlPanelRegistro.Controls.SetChildIndex(Me.MPnUsuario, 0)
        Me.MSuperTabControlPanelRegistro.Controls.SetChildIndex(Me.TableLayoutPanelPrincipal, 0)
        '
        'MPnSuperior
        '
        Me.MPnSuperior.Controls.Add(Me.btExportarExcel)
        Me.MPnSuperior.Size = New System.Drawing.Size(884, 70)
        Me.MPnSuperior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.MPnSuperior.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.MPnSuperior.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.MPnSuperior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.MPnSuperior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.MPnSuperior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.MPnSuperior.Style.GradientAngle = 90
        Me.MPnSuperior.Controls.SetChildIndex(Me.MPanelToolBarAccion, 0)
        Me.MPnSuperior.Controls.SetChildIndex(Me.MPanelToolBarImprimir, 0)
        Me.MPnSuperior.Controls.SetChildIndex(Me.MRlAccion, 0)
        Me.MPnSuperior.Controls.SetChildIndex(Me.btExportarExcel, 0)
        '
        'MPnInferior
        '
        Me.MPnInferior.Size = New System.Drawing.Size(884, 36)
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
        Me.MPanelToolBarUsuario.Location = New System.Drawing.Point(684, 0)
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
        'MPanelToolBarImprimir
        '
        Me.MPanelToolBarImprimir.Location = New System.Drawing.Point(804, 0)
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
        '
        'TableLayoutPanelPrincipal
        '
        Me.TableLayoutPanelPrincipal.ColumnCount = 2
        Me.TableLayoutPanelPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanelPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanelPrincipal.Controls.Add(Me.TableLayoutPanelDatos2, 1, 0)
        Me.TableLayoutPanelPrincipal.Controls.Add(Me.TableLayoutPanelDatos1, 0, 0)
        Me.TableLayoutPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelPrincipal.Name = "TableLayoutPanelPrincipal"
        Me.TableLayoutPanelPrincipal.RowCount = 1
        Me.TableLayoutPanelPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelPrincipal.Size = New System.Drawing.Size(842, 455)
        Me.TableLayoutPanelPrincipal.TabIndex = 29
        '
        'TableLayoutPanelDatos2
        '
        Me.TableLayoutPanelDatos2.ColumnCount = 1
        Me.TableLayoutPanelDatos2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelDatos2.Controls.Add(Me.GpCategoria, 0, 0)
        Me.TableLayoutPanelDatos2.Controls.Add(Me.GpListaCategoria, 0, 1)
        Me.TableLayoutPanelDatos2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelDatos2.Location = New System.Drawing.Point(676, 3)
        Me.TableLayoutPanelDatos2.Name = "TableLayoutPanelDatos2"
        Me.TableLayoutPanelDatos2.RowCount = 2
        Me.TableLayoutPanelDatos2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanelDatos2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.0!))
        Me.TableLayoutPanelDatos2.Size = New System.Drawing.Size(163, 449)
        Me.TableLayoutPanelDatos2.TabIndex = 2
        '
        'GpCategoria
        '
        Me.GpCategoria.CanvasColor = System.Drawing.SystemColors.Control
        Me.GpCategoria.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GpCategoria.Controls.Add(Me.PnCategoria)
        Me.GpCategoria.DisabledBackColor = System.Drawing.Color.Empty
        Me.GpCategoria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GpCategoria.Location = New System.Drawing.Point(3, 3)
        Me.GpCategoria.Name = "GpCategoria"
        Me.GpCategoria.Size = New System.Drawing.Size(157, 61)
        '
        '
        '
        Me.GpCategoria.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GpCategoria.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GpCategoria.Style.BackColorGradientAngle = 90
        Me.GpCategoria.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpCategoria.Style.BorderBottomWidth = 1
        Me.GpCategoria.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GpCategoria.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpCategoria.Style.BorderLeftWidth = 1
        Me.GpCategoria.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpCategoria.Style.BorderRightWidth = 1
        Me.GpCategoria.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpCategoria.Style.BorderTopWidth = 1
        Me.GpCategoria.Style.CornerDiameter = 4
        Me.GpCategoria.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GpCategoria.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GpCategoria.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GpCategoria.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GpCategoria.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GpCategoria.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GpCategoria.TabIndex = 0
        Me.GpCategoria.Text = "ADICIONAR CATEGORIA"
        '
        'PnCategoria
        '
        Me.PnCategoria.AutoScroll = True
        Me.PnCategoria.CanvasColor = System.Drawing.SystemColors.Control
        Me.PnCategoria.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PnCategoria.Controls.Add(Me.btAddCategoria)
        Me.PnCategoria.DisabledBackColor = System.Drawing.Color.Empty
        Me.PnCategoria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnCategoria.Location = New System.Drawing.Point(0, 0)
        Me.PnCategoria.Name = "PnCategoria"
        Me.PnCategoria.Size = New System.Drawing.Size(151, 40)
        Me.PnCategoria.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PnCategoria.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PnCategoria.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PnCategoria.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PnCategoria.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PnCategoria.Style.GradientAngle = 90
        Me.PnCategoria.TabIndex = 8
        '
        'btAddCategoria
        '
        Me.btAddCategoria.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btAddCategoria.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btAddCategoria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btAddCategoria.ImageFixedSize = New System.Drawing.Size(55, 55)
        Me.btAddCategoria.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.btAddCategoria.Location = New System.Drawing.Point(0, 0)
        Me.btAddCategoria.Name = "btAddCategoria"
        Me.btAddCategoria.Size = New System.Drawing.Size(151, 40)
        Me.btAddCategoria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btAddCategoria.TabIndex = 8
        Me.btAddCategoria.Text = "Añadir Categoria"
        Me.btAddCategoria.Tooltip = "AÑADIR CATEGORIA"
        '
        'GpListaCategoria
        '
        Me.GpListaCategoria.CanvasColor = System.Drawing.SystemColors.Control
        Me.GpListaCategoria.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GpListaCategoria.Controls.Add(Me.PnListaCategoria)
        Me.GpListaCategoria.DisabledBackColor = System.Drawing.Color.Empty
        Me.GpListaCategoria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GpListaCategoria.Location = New System.Drawing.Point(3, 70)
        Me.GpListaCategoria.Name = "GpListaCategoria"
        Me.GpListaCategoria.Size = New System.Drawing.Size(157, 376)
        '
        '
        '
        Me.GpListaCategoria.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GpListaCategoria.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GpListaCategoria.Style.BackColorGradientAngle = 90
        Me.GpListaCategoria.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpListaCategoria.Style.BorderBottomWidth = 1
        Me.GpListaCategoria.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GpListaCategoria.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpListaCategoria.Style.BorderLeftWidth = 1
        Me.GpListaCategoria.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpListaCategoria.Style.BorderRightWidth = 1
        Me.GpListaCategoria.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpListaCategoria.Style.BorderTopWidth = 1
        Me.GpListaCategoria.Style.CornerDiameter = 4
        Me.GpListaCategoria.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GpListaCategoria.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GpListaCategoria.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GpListaCategoria.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GpListaCategoria.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GpListaCategoria.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GpListaCategoria.TabIndex = 1
        Me.GpListaCategoria.Text = "LISTA CATEGORIAS"
        '
        'PnListaCategoria
        '
        Me.PnListaCategoria.AutoScroll = True
        Me.PnListaCategoria.CanvasColor = System.Drawing.SystemColors.Control
        Me.PnListaCategoria.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PnListaCategoria.Controls.Add(Me.JGr_Categorias)
        Me.PnListaCategoria.DisabledBackColor = System.Drawing.Color.Empty
        Me.PnListaCategoria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnListaCategoria.Location = New System.Drawing.Point(0, 0)
        Me.PnListaCategoria.Name = "PnListaCategoria"
        Me.PnListaCategoria.Size = New System.Drawing.Size(151, 355)
        Me.PnListaCategoria.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PnListaCategoria.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PnListaCategoria.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PnListaCategoria.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PnListaCategoria.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PnListaCategoria.Style.GradientAngle = 90
        Me.PnListaCategoria.TabIndex = 8
        '
        'JGr_Categorias
        '
        Me.JGr_Categorias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JGr_Categorias.DynamicFiltering = True
        Me.JGr_Categorias.Location = New System.Drawing.Point(0, 0)
        Me.JGr_Categorias.Name = "JGr_Categorias"
        Me.JGr_Categorias.Size = New System.Drawing.Size(151, 355)
        Me.JGr_Categorias.TabIndex = 2
        '
        'TableLayoutPanelDatos1
        '
        Me.TableLayoutPanelDatos1.ColumnCount = 1
        Me.TableLayoutPanelDatos1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelDatos1.Controls.Add(Me.GpDatosGenerales, 0, 0)
        Me.TableLayoutPanelDatos1.Controls.Add(Me.GpListaPrecio, 0, 1)
        Me.TableLayoutPanelDatos1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelDatos1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanelDatos1.Name = "TableLayoutPanelDatos1"
        Me.TableLayoutPanelDatos1.RowCount = 2
        Me.TableLayoutPanelDatos1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanelDatos1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.0!))
        Me.TableLayoutPanelDatos1.Size = New System.Drawing.Size(667, 449)
        Me.TableLayoutPanelDatos1.TabIndex = 1
        '
        'GpDatosGenerales
        '
        Me.GpDatosGenerales.CanvasColor = System.Drawing.SystemColors.Control
        Me.GpDatosGenerales.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GpDatosGenerales.Controls.Add(Me.PnDatosGenerales)
        Me.GpDatosGenerales.DisabledBackColor = System.Drawing.Color.Empty
        Me.GpDatosGenerales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GpDatosGenerales.Location = New System.Drawing.Point(3, 3)
        Me.GpDatosGenerales.Name = "GpDatosGenerales"
        Me.GpDatosGenerales.Size = New System.Drawing.Size(661, 61)
        '
        '
        '
        Me.GpDatosGenerales.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GpDatosGenerales.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GpDatosGenerales.Style.BackColorGradientAngle = 90
        Me.GpDatosGenerales.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpDatosGenerales.Style.BorderBottomWidth = 1
        Me.GpDatosGenerales.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GpDatosGenerales.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpDatosGenerales.Style.BorderLeftWidth = 1
        Me.GpDatosGenerales.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpDatosGenerales.Style.BorderRightWidth = 1
        Me.GpDatosGenerales.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpDatosGenerales.Style.BorderTopWidth = 1
        Me.GpDatosGenerales.Style.CornerDiameter = 4
        Me.GpDatosGenerales.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GpDatosGenerales.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GpDatosGenerales.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GpDatosGenerales.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GpDatosGenerales.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GpDatosGenerales.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GpDatosGenerales.TabIndex = 0
        Me.GpDatosGenerales.Text = "DATOS GENERALES"
        '
        'PnDatosGenerales
        '
        Me.PnDatosGenerales.AutoScroll = True
        Me.PnDatosGenerales.CanvasColor = System.Drawing.SystemColors.Control
        Me.PnDatosGenerales.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PnDatosGenerales.Controls.Add(Me.LabelX1)
        Me.PnDatosGenerales.Controls.Add(Me.JCb_CatProducto)
        Me.PnDatosGenerales.DisabledBackColor = System.Drawing.Color.Empty
        Me.PnDatosGenerales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnDatosGenerales.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnDatosGenerales.Location = New System.Drawing.Point(0, 0)
        Me.PnDatosGenerales.Name = "PnDatosGenerales"
        Me.PnDatosGenerales.Size = New System.Drawing.Size(655, 40)
        Me.PnDatosGenerales.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PnDatosGenerales.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PnDatosGenerales.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PnDatosGenerales.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PnDatosGenerales.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PnDatosGenerales.Style.GradientAngle = 90
        Me.PnDatosGenerales.TabIndex = 4
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(138, 23)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "Categoria de Producto:"
        '
        'JCb_CatProducto
        '
        JCb_CatProducto_DesignTimeLayout.LayoutString = resources.GetString("JCb_CatProducto_DesignTimeLayout.LayoutString")
        Me.JCb_CatProducto.DesignTimeLayout = JCb_CatProducto_DesignTimeLayout
        Me.JCb_CatProducto.Location = New System.Drawing.Point(147, 3)
        Me.JCb_CatProducto.Name = "JCb_CatProducto"
        Me.JCb_CatProducto.SelectedIndex = -1
        Me.JCb_CatProducto.SelectedItem = Nothing
        Me.JCb_CatProducto.Size = New System.Drawing.Size(250, 23)
        Me.JCb_CatProducto.TabIndex = 1
        '
        'GpListaPrecio
        '
        Me.GpListaPrecio.CanvasColor = System.Drawing.SystemColors.Control
        Me.GpListaPrecio.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GpListaPrecio.Controls.Add(Me.PnListaPrecio)
        Me.GpListaPrecio.DisabledBackColor = System.Drawing.Color.Empty
        Me.GpListaPrecio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GpListaPrecio.Location = New System.Drawing.Point(3, 70)
        Me.GpListaPrecio.Name = "GpListaPrecio"
        Me.GpListaPrecio.Size = New System.Drawing.Size(661, 376)
        '
        '
        '
        Me.GpListaPrecio.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GpListaPrecio.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GpListaPrecio.Style.BackColorGradientAngle = 90
        Me.GpListaPrecio.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpListaPrecio.Style.BorderBottomWidth = 1
        Me.GpListaPrecio.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GpListaPrecio.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpListaPrecio.Style.BorderLeftWidth = 1
        Me.GpListaPrecio.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpListaPrecio.Style.BorderRightWidth = 1
        Me.GpListaPrecio.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpListaPrecio.Style.BorderTopWidth = 1
        Me.GpListaPrecio.Style.CornerDiameter = 4
        Me.GpListaPrecio.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GpListaPrecio.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GpListaPrecio.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GpListaPrecio.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GpListaPrecio.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GpListaPrecio.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GpListaPrecio.TabIndex = 1
        Me.GpListaPrecio.Text = "LISTA DE PRECIOS"
        '
        'PnListaPrecio
        '
        Me.PnListaPrecio.AutoScroll = True
        Me.PnListaPrecio.CanvasColor = System.Drawing.SystemColors.Control
        Me.PnListaPrecio.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PnListaPrecio.Controls.Add(Me.JGr_Detalle)
        Me.PnListaPrecio.DisabledBackColor = System.Drawing.Color.Empty
        Me.PnListaPrecio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnListaPrecio.Location = New System.Drawing.Point(0, 0)
        Me.PnListaPrecio.Name = "PnListaPrecio"
        Me.PnListaPrecio.Size = New System.Drawing.Size(655, 355)
        Me.PnListaPrecio.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PnListaPrecio.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PnListaPrecio.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PnListaPrecio.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PnListaPrecio.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PnListaPrecio.Style.GradientAngle = 90
        Me.PnListaPrecio.TabIndex = 8
        '
        'JGr_Detalle
        '
        Me.JGr_Detalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JGr_Detalle.DynamicFiltering = True
        Me.JGr_Detalle.Location = New System.Drawing.Point(0, 0)
        Me.JGr_Detalle.Name = "JGr_Detalle"
        Me.JGr_Detalle.Size = New System.Drawing.Size(655, 355)
        Me.JGr_Detalle.TabIndex = 1
        '
        'GridEXPrintDocumentListaPrecios
        '
        Me.GridEXPrintDocumentListaPrecios.DocumentName = "ListaPrecios"
        Me.GridEXPrintDocumentListaPrecios.FitColumns = Janus.Windows.GridEX.FitColumnsMode.Zooming
        Me.GridEXPrintDocumentListaPrecios.FooterDistance = 0
        Me.GridEXPrintDocumentListaPrecios.GridEX = Me.JGr_Detalle
        Me.GridEXPrintDocumentListaPrecios.HeaderDistance = 0
        Me.GridEXPrintDocumentListaPrecios.PageHeaderFormatStyle.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridEXPrintDocumentListaPrecios.PageHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '
        'GridEXExporterListaPrecio
        '
        Me.GridEXExporterListaPrecio.GridEX = Me.JGr_Detalle
        '
        'btExportarExcel
        '
        Me.btExportarExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btExportarExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btExportarExcel.Location = New System.Drawing.Point(684, 13)
        Me.btExportarExcel.Name = "btExportarExcel"
        Me.btExportarExcel.Size = New System.Drawing.Size(75, 51)
        Me.btExportarExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btExportarExcel.TabIndex = 10
        Me.btExportarExcel.Text = "ButtonX1"
        Me.btExportarExcel.Visible = False
        '
        'F02_Precio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Name = "F02_Precio"
        Me.Text = "F01_Precio"
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
        Me.TableLayoutPanelPrincipal.ResumeLayout(False)
        Me.TableLayoutPanelDatos2.ResumeLayout(False)
        Me.GpCategoria.ResumeLayout(False)
        Me.PnCategoria.ResumeLayout(False)
        Me.GpListaCategoria.ResumeLayout(False)
        Me.PnListaCategoria.ResumeLayout(False)
        CType(Me.JGr_Categorias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanelDatos1.ResumeLayout(False)
        Me.GpDatosGenerales.ResumeLayout(False)
        Me.PnDatosGenerales.ResumeLayout(False)
        Me.PnDatosGenerales.PerformLayout()
        CType(Me.JCb_CatProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GpListaPrecio.ResumeLayout(False)
        Me.PnListaPrecio.ResumeLayout(False)
        CType(Me.JGr_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanelPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanelDatos2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GpCategoria As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PnCategoria As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GpListaCategoria As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PnListaCategoria As DevComponents.DotNetBar.PanelEx
    Friend WithEvents TableLayoutPanelDatos1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GpDatosGenerales As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PnDatosGenerales As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GpListaPrecio As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PnListaPrecio As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btAddCategoria As DevComponents.DotNetBar.ButtonX
    Friend WithEvents JGr_Categorias As Janus.Windows.GridEX.GridEX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents JCb_CatProducto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents JGr_Detalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents GridEXPrintDocumentListaPrecios As Janus.Windows.GridEX.GridEXPrintDocument
    Friend WithEvents btExportarExcel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GridEXExporterListaPrecio As Janus.Windows.GridEX.Export.GridEXExporter
End Class
