<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F01_MonitoreoPedido
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
        Me.TableLayoutPanelPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelExTrakingRepartidor = New DevComponents.DotNetBar.PanelEx()
        Me.GroupPanelRepartidores = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.grRepartidores = New Janus.Windows.GridEX.GridEX()
        Me.GroupPanelTraking = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelExTraking = New DevComponents.DotNetBar.PanelEx()
        Me.J_Cb_Ciudad = New System.Windows.Forms.ComboBox()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.tbTracking = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.GroupPanelGeoreferencia = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelEx6 = New DevComponents.DotNetBar.PanelEx()
        Me.Btn_ZoomMenos = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_ZoomMas = New DevComponents.DotNetBar.ButtonX()
        Me.GM_Mapa = New GMap.NET.WindowsForms.GMapControl()
        Me.TimerRuta = New System.Windows.Forms.Timer(Me.components)
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
        Me.PanelExTrakingRepartidor.SuspendLayout()
        Me.GroupPanelRepartidores.SuspendLayout()
        CType(Me.grRepartidores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanelTraking.SuspendLayout()
        Me.PanelExTraking.SuspendLayout()
        Me.GroupPanelGeoreferencia.SuspendLayout()
        Me.PanelEx6.SuspendLayout()
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
        Me.MSuperTabControlPrincipal.Controls.SetChildIndex(Me.MSuperTabControlPanelRegistro, 0)
        '
        'MSuperTabControlPanelRegistro
        '
        Me.MSuperTabControlPanelRegistro.Controls.Add(Me.TableLayoutPanelPrincipal)
        Me.MSuperTabControlPanelRegistro.Size = New System.Drawing.Size(1270, 560)
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
        Me.MTbUsuario.Margin = New System.Windows.Forms.Padding(5)
        Me.MTbUsuario.ReadOnly = True
        Me.MTbUsuario.Size = New System.Drawing.Size(179, 38)
        Me.MTbUsuario.Text = "DEFAULT"
        '
        'MBtUltimo
        '
        Me.MBtUltimo.Location = New System.Drawing.Point(178, 0)
        '
        'MBtSalir
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
        Me.MRlAccion.Margin = New System.Windows.Forms.Padding(5)
        Me.MRlAccion.Size = New System.Drawing.Size(733, 74)
        '
        'TableLayoutPanelPrincipal
        '
        Me.TableLayoutPanelPrincipal.ColumnCount = 2
        Me.TableLayoutPanelPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanelPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanelPrincipal.Controls.Add(Me.PanelExTrakingRepartidor, 0, 0)
        Me.TableLayoutPanelPrincipal.Controls.Add(Me.GroupPanelGeoreferencia, 1, 0)
        Me.TableLayoutPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelPrincipal.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanelPrincipal.Name = "TableLayoutPanelPrincipal"
        Me.TableLayoutPanelPrincipal.RowCount = 1
        Me.TableLayoutPanelPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelPrincipal.Size = New System.Drawing.Size(1270, 560)
        Me.TableLayoutPanelPrincipal.TabIndex = 29
        '
        'PanelExTrakingRepartidor
        '
        Me.PanelExTrakingRepartidor.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelExTrakingRepartidor.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelExTrakingRepartidor.Controls.Add(Me.GroupPanelRepartidores)
        Me.PanelExTrakingRepartidor.Controls.Add(Me.GroupPanelTraking)
        Me.PanelExTrakingRepartidor.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelExTrakingRepartidor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelExTrakingRepartidor.Location = New System.Drawing.Point(4, 4)
        Me.PanelExTrakingRepartidor.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelExTrakingRepartidor.Name = "PanelExTrakingRepartidor"
        Me.PanelExTrakingRepartidor.Size = New System.Drawing.Size(373, 552)
        Me.PanelExTrakingRepartidor.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelExTrakingRepartidor.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PanelExTrakingRepartidor.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PanelExTrakingRepartidor.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelExTrakingRepartidor.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelExTrakingRepartidor.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelExTrakingRepartidor.Style.GradientAngle = 90
        Me.PanelExTrakingRepartidor.TabIndex = 0
        '
        'GroupPanelRepartidores
        '
        Me.GroupPanelRepartidores.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelRepartidores.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelRepartidores.Controls.Add(Me.grRepartidores)
        Me.GroupPanelRepartidores.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelRepartidores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelRepartidores.Location = New System.Drawing.Point(0, 111)
        Me.GroupPanelRepartidores.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupPanelRepartidores.Name = "GroupPanelRepartidores"
        Me.GroupPanelRepartidores.Size = New System.Drawing.Size(373, 441)
        '
        '
        '
        Me.GroupPanelRepartidores.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanelRepartidores.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanelRepartidores.Style.BackColorGradientAngle = 90
        Me.GroupPanelRepartidores.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelRepartidores.Style.BorderBottomWidth = 1
        Me.GroupPanelRepartidores.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanelRepartidores.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelRepartidores.Style.BorderLeftWidth = 1
        Me.GroupPanelRepartidores.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelRepartidores.Style.BorderRightWidth = 1
        Me.GroupPanelRepartidores.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelRepartidores.Style.BorderTopWidth = 1
        Me.GroupPanelRepartidores.Style.CornerDiameter = 4
        Me.GroupPanelRepartidores.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelRepartidores.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelRepartidores.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelRepartidores.Style.TextColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanelRepartidores.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelRepartidores.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelRepartidores.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelRepartidores.TabIndex = 2
        Me.GroupPanelRepartidores.Text = "REPARTIDORES"
        '
        'grRepartidores
        '
        Me.grRepartidores.AlternatingRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Solid
        Me.grRepartidores.BackColor = System.Drawing.Color.Linen
        Me.grRepartidores.BorderStyle = Janus.Windows.GridEX.BorderStyle.Sunken
        Me.grRepartidores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grRepartidores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grRepartidores.HeaderFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grRepartidores.Location = New System.Drawing.Point(0, 0)
        Me.grRepartidores.Margin = New System.Windows.Forms.Padding(4)
        Me.grRepartidores.Name = "grRepartidores"
        Me.grRepartidores.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.grRepartidores.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.grRepartidores.Size = New System.Drawing.Size(367, 416)
        Me.grRepartidores.TabIndex = 0
        Me.grRepartidores.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupPanelTraking
        '
        Me.GroupPanelTraking.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelTraking.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelTraking.Controls.Add(Me.PanelExTraking)
        Me.GroupPanelTraking.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelTraking.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupPanelTraking.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelTraking.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanelTraking.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupPanelTraking.Name = "GroupPanelTraking"
        Me.GroupPanelTraking.Size = New System.Drawing.Size(373, 111)
        '
        '
        '
        Me.GroupPanelTraking.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanelTraking.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanelTraking.Style.BackColorGradientAngle = 90
        Me.GroupPanelTraking.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelTraking.Style.BorderBottomWidth = 1
        Me.GroupPanelTraking.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanelTraking.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelTraking.Style.BorderLeftWidth = 1
        Me.GroupPanelTraking.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelTraking.Style.BorderRightWidth = 1
        Me.GroupPanelTraking.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelTraking.Style.BorderTopWidth = 1
        Me.GroupPanelTraking.Style.CornerDiameter = 4
        Me.GroupPanelTraking.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelTraking.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelTraking.Style.TextColor = System.Drawing.Color.AliceBlue
        Me.GroupPanelTraking.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelTraking.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelTraking.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelTraking.TabIndex = 1
        Me.GroupPanelTraking.Text = "TRAKING"
        '
        'PanelExTraking
        '
        Me.PanelExTraking.AutoScroll = True
        Me.PanelExTraking.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelExTraking.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelExTraking.Controls.Add(Me.J_Cb_Ciudad)
        Me.PanelExTraking.Controls.Add(Me.LabelX1)
        Me.PanelExTraking.Controls.Add(Me.LabelX2)
        Me.PanelExTraking.Controls.Add(Me.tbTracking)
        Me.PanelExTraking.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelExTraking.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelExTraking.Location = New System.Drawing.Point(0, 0)
        Me.PanelExTraking.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelExTraking.Name = "PanelExTraking"
        Me.PanelExTraking.Size = New System.Drawing.Size(367, 86)
        Me.PanelExTraking.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelExTraking.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PanelExTraking.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PanelExTraking.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelExTraking.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelExTraking.Style.GradientAngle = 90
        Me.PanelExTraking.TabIndex = 0
        '
        'J_Cb_Ciudad
        '
        Me.J_Cb_Ciudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.J_Cb_Ciudad.FormattingEnabled = True
        Me.J_Cb_Ciudad.Location = New System.Drawing.Point(112, 41)
        Me.J_Cb_Ciudad.Margin = New System.Windows.Forms.Padding(4)
        Me.J_Cb_Ciudad.Name = "J_Cb_Ciudad"
        Me.J_Cb_Ciudad.Size = New System.Drawing.Size(239, 26)
        Me.J_Cb_Ciudad.TabIndex = 5
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(4, 5)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(100, 28)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "TRACKING:"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(4, 41)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(100, 28)
        Me.LabelX2.TabIndex = 4
        Me.LabelX2.Text = "CIUDAD:"
        '
        'tbTracking
        '
        '
        '
        '
        Me.tbTracking.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbTracking.Location = New System.Drawing.Point(112, 6)
        Me.tbTracking.Margin = New System.Windows.Forms.Padding(4)
        Me.tbTracking.Name = "tbTracking"
        Me.tbTracking.Size = New System.Drawing.Size(88, 27)
        Me.tbTracking.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbTracking.TabIndex = 1
        '
        'GroupPanelGeoreferencia
        '
        Me.GroupPanelGeoreferencia.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelGeoreferencia.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelGeoreferencia.Controls.Add(Me.PanelEx6)
        Me.GroupPanelGeoreferencia.Controls.Add(Me.GM_Mapa)
        Me.GroupPanelGeoreferencia.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelGeoreferencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelGeoreferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelGeoreferencia.Location = New System.Drawing.Point(385, 4)
        Me.GroupPanelGeoreferencia.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupPanelGeoreferencia.Name = "GroupPanelGeoreferencia"
        Me.GroupPanelGeoreferencia.Size = New System.Drawing.Size(881, 552)
        '
        '
        '
        Me.GroupPanelGeoreferencia.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanelGeoreferencia.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanelGeoreferencia.Style.BackColorGradientAngle = 90
        Me.GroupPanelGeoreferencia.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelGeoreferencia.Style.BorderBottomWidth = 1
        Me.GroupPanelGeoreferencia.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanelGeoreferencia.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelGeoreferencia.Style.BorderLeftWidth = 1
        Me.GroupPanelGeoreferencia.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelGeoreferencia.Style.BorderRightWidth = 1
        Me.GroupPanelGeoreferencia.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelGeoreferencia.Style.BorderTopWidth = 1
        Me.GroupPanelGeoreferencia.Style.CornerDiameter = 4
        Me.GroupPanelGeoreferencia.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelGeoreferencia.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelGeoreferencia.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelGeoreferencia.Style.TextColor = System.Drawing.Color.AliceBlue
        Me.GroupPanelGeoreferencia.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelGeoreferencia.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelGeoreferencia.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelGeoreferencia.TabIndex = 2
        Me.GroupPanelGeoreferencia.Text = "UBICACIÓN"
        '
        'PanelEx6
        '
        Me.PanelEx6.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx6.Controls.Add(Me.Btn_ZoomMenos)
        Me.PanelEx6.Controls.Add(Me.Btn_ZoomMas)
        Me.PanelEx6.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx6.Location = New System.Drawing.Point(4, 6)
        Me.PanelEx6.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelEx6.Name = "PanelEx6"
        Me.PanelEx6.Size = New System.Drawing.Size(61, 107)
        Me.PanelEx6.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx6.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx6.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx6.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx6.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx6.Style.GradientAngle = 90
        Me.PanelEx6.TabIndex = 5
        '
        'Btn_ZoomMenos
        '
        Me.Btn_ZoomMenos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_ZoomMenos.BackgroundImage = Global.Presentacion.My.Resources.Resources.ZOOM_MENOS_ORI
        Me.Btn_ZoomMenos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_ZoomMenos.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.Btn_ZoomMenos.Image = Global.Presentacion.My.Resources.Resources.ZOOM_MENOS_ORI
        Me.Btn_ZoomMenos.ImageFixedSize = New System.Drawing.Size(40, 40)
        Me.Btn_ZoomMenos.Location = New System.Drawing.Point(4, 55)
        Me.Btn_ZoomMenos.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_ZoomMenos.Name = "Btn_ZoomMenos"
        Me.Btn_ZoomMenos.Size = New System.Drawing.Size(53, 49)
        Me.Btn_ZoomMenos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_ZoomMenos.TabIndex = 1
        '
        'Btn_ZoomMas
        '
        Me.Btn_ZoomMas.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_ZoomMas.BackgroundImage = Global.Presentacion.My.Resources.Resources.ZOOM_MAS_ORI
        Me.Btn_ZoomMas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_ZoomMas.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.Btn_ZoomMas.Image = Global.Presentacion.My.Resources.Resources.ZOOM_MAS_ORI
        Me.Btn_ZoomMas.ImageFixedSize = New System.Drawing.Size(40, 40)
        Me.Btn_ZoomMas.Location = New System.Drawing.Point(4, 4)
        Me.Btn_ZoomMas.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_ZoomMas.Name = "Btn_ZoomMas"
        Me.Btn_ZoomMas.Size = New System.Drawing.Size(53, 49)
        Me.Btn_ZoomMas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_ZoomMas.TabIndex = 0
        '
        'GM_Mapa
        '
        Me.GM_Mapa.Bearing = 0!
        Me.GM_Mapa.CanDragMap = True
        Me.GM_Mapa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GM_Mapa.EmptyTileColor = System.Drawing.Color.Navy
        Me.GM_Mapa.GrayScaleMode = False
        Me.GM_Mapa.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
        Me.GM_Mapa.LevelsKeepInMemmory = 5
        Me.GM_Mapa.Location = New System.Drawing.Point(0, 0)
        Me.GM_Mapa.Margin = New System.Windows.Forms.Padding(4)
        Me.GM_Mapa.MarkersEnabled = True
        Me.GM_Mapa.MaxZoom = 2
        Me.GM_Mapa.MinZoom = 2
        Me.GM_Mapa.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
        Me.GM_Mapa.Name = "GM_Mapa"
        Me.GM_Mapa.NegativeMode = False
        Me.GM_Mapa.PolygonsEnabled = True
        Me.GM_Mapa.RetryLoadTile = 0
        Me.GM_Mapa.RoutesEnabled = True
        Me.GM_Mapa.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
        Me.GM_Mapa.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.GM_Mapa.ShowTileGridLines = False
        Me.GM_Mapa.Size = New System.Drawing.Size(875, 524)
        Me.GM_Mapa.TabIndex = 1
        Me.GM_Mapa.Zoom = 0R
        '
        'TimerRuta
        '
        Me.TimerRuta.Interval = 60000
        '
        'F01_MonitoreoPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1312, 690)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "F01_MonitoreoPedido"
        Me.Text = "F01_MonitoreoPedido"
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
        Me.PanelExTrakingRepartidor.ResumeLayout(False)
        Me.GroupPanelRepartidores.ResumeLayout(False)
        CType(Me.grRepartidores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanelTraking.ResumeLayout(False)
        Me.PanelExTraking.ResumeLayout(False)
        Me.GroupPanelGeoreferencia.ResumeLayout(False)
        Me.PanelEx6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanelPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupPanelTraking As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents grRepartidores As Janus.Windows.GridEX.GridEX
    Friend WithEvents J_Cb_Ciudad As System.Windows.Forms.ComboBox
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbTracking As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanelGeoreferencia As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PanelExTrakingRepartidor As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GroupPanelRepartidores As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PanelExTraking As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GM_Mapa As GMap.NET.WindowsForms.GMapControl
    Friend WithEvents PanelEx6 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents Btn_ZoomMenos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_ZoomMas As DevComponents.DotNetBar.ButtonX
    Public WithEvents TimerRuta As Timer
End Class
