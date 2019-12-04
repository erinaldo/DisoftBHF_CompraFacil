<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F02ZonaAsignacion
    Inherits Modelo.ModeloF02_cd

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
        Me.GroupPanelBusqueda = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TbCodigo = New System.Windows.Forms.TextBox()
        Me.DgjBusqueda = New Janus.Windows.GridEX.GridEX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupPanelPersonal = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.SuperTabControlPersonal = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgjRepartidor = New Janus.Windows.GridEX.GridEX()
        Me.SuperTabItemRepartidor = New DevComponents.DotNetBar.SuperTabItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgjPrevendedor = New Janus.Windows.GridEX.GridEX()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
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
        Me.GroupPanelBusqueda.SuspendLayout()
        CType(Me.DgjBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupPanelPersonal.SuspendLayout()
        CType(Me.SuperTabControlPersonal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPersonal.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.dgjRepartidor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel3.SuspendLayout()
        CType(Me.dgjPrevendedor, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.MSuperTabControlPanelBusqueda.Size = New System.Drawing.Size(1270, 560)
        '
        'MSuperTabControlPanelRegistro
        '
        Me.MSuperTabControlPanelRegistro.Controls.Add(Me.GroupPanelBusqueda)
        Me.MSuperTabControlPanelRegistro.Controls.Add(Me.Panel1)
        Me.MSuperTabControlPanelRegistro.Size = New System.Drawing.Size(1270, 560)
        Me.MSuperTabControlPanelRegistro.Controls.SetChildIndex(Me.MPnUsuario, 0)
        Me.MSuperTabControlPanelRegistro.Controls.SetChildIndex(Me.Panel1, 0)
        Me.MSuperTabControlPanelRegistro.Controls.SetChildIndex(Me.GroupPanelBusqueda, 0)
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
        'MBtUltimo
        '
        Me.MBtUltimo.Location = New System.Drawing.Point(178, 0)
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
        'MBtModificar
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
        'GroupPanelBusqueda
        '
        Me.GroupPanelBusqueda.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelBusqueda.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelBusqueda.Controls.Add(Me.TbCodigo)
        Me.GroupPanelBusqueda.Controls.Add(Me.DgjBusqueda)
        Me.GroupPanelBusqueda.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanelBusqueda.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupPanelBusqueda.Name = "GroupPanelBusqueda"
        Me.GroupPanelBusqueda.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupPanelBusqueda.Size = New System.Drawing.Size(524, 560)
        '
        '
        '
        Me.GroupPanelBusqueda.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanelBusqueda.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanelBusqueda.Style.BackColorGradientAngle = 90
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
        Me.GroupPanelBusqueda.TabIndex = 29
        Me.GroupPanelBusqueda.Text = "BUSQUEDA DATOS"
        '
        'TbCodigo
        '
        Me.TbCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbCodigo.Location = New System.Drawing.Point(193, 255)
        Me.TbCodigo.Margin = New System.Windows.Forms.Padding(4)
        Me.TbCodigo.Name = "TbCodigo"
        Me.TbCodigo.Size = New System.Drawing.Size(132, 26)
        Me.TbCodigo.TabIndex = 115
        Me.TbCodigo.Visible = False
        '
        'DgjBusqueda
        '
        Me.DgjBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgjBusqueda.HeaderFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DgjBusqueda.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.DgjBusqueda.Location = New System.Drawing.Point(7, 6)
        Me.DgjBusqueda.Margin = New System.Windows.Forms.Padding(4)
        Me.DgjBusqueda.Name = "DgjBusqueda"
        Me.DgjBusqueda.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.DgjBusqueda.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.DgjBusqueda.SelectedFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.DgjBusqueda.SelectedFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DgjBusqueda.SelectedFormatStyle.ForeColor = System.Drawing.Color.White
        Me.DgjBusqueda.Size = New System.Drawing.Size(504, 525)
        Me.DgjBusqueda.TabIndex = 0
        Me.DgjBusqueda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupPanelPersonal)
        Me.Panel1.Controls.Add(Me.GroupPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(524, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(746, 560)
        Me.Panel1.TabIndex = 30
        '
        'GroupPanelPersonal
        '
        Me.GroupPanelPersonal.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelPersonal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelPersonal.Controls.Add(Me.SuperTabControlPersonal)
        Me.GroupPanelPersonal.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelPersonal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelPersonal.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanelPersonal.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupPanelPersonal.Name = "GroupPanelPersonal"
        Me.GroupPanelPersonal.Size = New System.Drawing.Size(746, 236)
        '
        '
        '
        Me.GroupPanelPersonal.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanelPersonal.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanelPersonal.Style.BackColorGradientAngle = 90
        Me.GroupPanelPersonal.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelPersonal.Style.BorderBottomWidth = 1
        Me.GroupPanelPersonal.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelPersonal.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelPersonal.Style.BorderLeftWidth = 1
        Me.GroupPanelPersonal.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelPersonal.Style.BorderRightWidth = 1
        Me.GroupPanelPersonal.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelPersonal.Style.BorderTopWidth = 1
        Me.GroupPanelPersonal.Style.CornerDiameter = 4
        Me.GroupPanelPersonal.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelPersonal.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelPersonal.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelPersonal.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelPersonal.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelPersonal.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelPersonal.TabIndex = 2
        Me.GroupPanelPersonal.Text = "PERSONAL"
        '
        'SuperTabControlPersonal
        '
        '
        '
        '
        '
        '
        '
        Me.SuperTabControlPersonal.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControlPersonal.ControlBox.MenuBox.Name = ""
        Me.SuperTabControlPersonal.ControlBox.Name = ""
        Me.SuperTabControlPersonal.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControlPersonal.ControlBox.MenuBox, Me.SuperTabControlPersonal.ControlBox.CloseBox})
        Me.SuperTabControlPersonal.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControlPersonal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPersonal.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPersonal.Margin = New System.Windows.Forms.Padding(4)
        Me.SuperTabControlPersonal.Name = "SuperTabControlPersonal"
        Me.SuperTabControlPersonal.ReorderTabsEnabled = True
        Me.SuperTabControlPersonal.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControlPersonal.SelectedTabIndex = 1
        Me.SuperTabControlPersonal.Size = New System.Drawing.Size(740, 213)
        Me.SuperTabControlPersonal.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControlPersonal.TabIndex = 118
        Me.SuperTabControlPersonal.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItemRepartidor})
        Me.SuperTabControlPersonal.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.SuperTabControlPersonal.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.dgjRepartidor)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.SuperTabControlPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(740, 187)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItemRepartidor
        '
        'dgjRepartidor
        '
        Me.dgjRepartidor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgjRepartidor.Location = New System.Drawing.Point(0, 0)
        Me.dgjRepartidor.Margin = New System.Windows.Forms.Padding(4)
        Me.dgjRepartidor.Name = "dgjRepartidor"
        Me.dgjRepartidor.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.dgjRepartidor.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.dgjRepartidor.Size = New System.Drawing.Size(740, 187)
        Me.dgjRepartidor.TabIndex = 117
        Me.dgjRepartidor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'SuperTabItemRepartidor
        '
        Me.SuperTabItemRepartidor.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItemRepartidor.GlobalItem = False
        Me.SuperTabItemRepartidor.Name = "SuperTabItemRepartidor"
        Me.SuperTabItemRepartidor.Text = "Repartidor"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.SuperTabControl1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 236)
        Me.GroupPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(746, 324)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 3
        Me.GroupPanel1.Text = "PERSONAL"
        '
        'SuperTabControl1
        '
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 1
        Me.SuperTabControl1.Size = New System.Drawing.Size(740, 301)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 118
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem2})
        Me.SuperTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.dgjPrevendedor)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 26)
        Me.SuperTabControlPanel3.Margin = New System.Windows.Forms.Padding(4)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(740, 275)
        Me.SuperTabControlPanel3.TabIndex = 0
        Me.SuperTabControlPanel3.TabItem = Me.SuperTabItem2
        '
        'dgjPrevendedor
        '
        Me.dgjPrevendedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgjPrevendedor.Location = New System.Drawing.Point(0, 0)
        Me.dgjPrevendedor.Margin = New System.Windows.Forms.Padding(4)
        Me.dgjPrevendedor.Name = "dgjPrevendedor"
        Me.dgjPrevendedor.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.dgjPrevendedor.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.dgjPrevendedor.Size = New System.Drawing.Size(740, 275)
        Me.dgjPrevendedor.TabIndex = 118
        Me.dgjPrevendedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel3
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Pre-Vendedor"
        '
        'F02ZonaAsignacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1312, 690)
        Me.Name = "F02ZonaAsignacion"
        Me.Text = "F02ZonaAsignacion"
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
        Me.GroupPanelBusqueda.ResumeLayout(False)
        Me.GroupPanelBusqueda.PerformLayout()
        CType(Me.DgjBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupPanelPersonal.ResumeLayout(False)
        CType(Me.SuperTabControlPersonal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPersonal.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        CType(Me.dgjRepartidor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel3.ResumeLayout(False)
        CType(Me.dgjPrevendedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanelBusqueda As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents DgjBusqueda As Janus.Windows.GridEX.GridEX
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupPanelPersonal As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents SuperTabControlPersonal As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents dgjRepartidor As Janus.Windows.GridEX.GridEX
    Friend WithEvents SuperTabItemRepartidor As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents dgjPrevendedor As Janus.Windows.GridEX.GridEX
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents TbCodigo As TextBox
End Class
