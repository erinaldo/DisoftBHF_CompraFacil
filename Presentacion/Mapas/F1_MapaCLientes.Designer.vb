<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F1_MapaCLientes
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F1_MapaCLientes))
        Dim cbZona_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.PanelPrincipal = New System.Windows.Forms.Panel()
        Me.PanelMapa = New System.Windows.Forms.Panel()
        Me.btnz2 = New DevComponents.DotNetBar.ButtonX()
        Me.btnz1 = New DevComponents.DotNetBar.ButtonX()
        Me.Gmc_Cliente = New GMap.NET.WindowsForms.GMapControl()
        Me.PanelGroup = New System.Windows.Forms.Panel()
        Me.slpanelInfo = New DevComponents.DotNetBar.Controls.SlidePanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lbobs = New System.Windows.Forms.TextBox()
        Me.lbtel = New System.Windows.Forms.Label()
        Me.lb4 = New System.Windows.Forms.Label()
        Me.lb3 = New System.Windows.Forms.Label()
        Me.lbcliente = New System.Windows.Forms.Label()
        Me.lb1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lb2 = New System.Windows.Forms.Label()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanelJanus = New System.Windows.Forms.Panel()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.grCliente = New Janus.Windows.GridEX.GridEX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.checkTodos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbZona = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Dt_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.RBPE = New System.Windows.Forms.RadioButton()
        Me.RBCL = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelInferior = New System.Windows.Forms.Panel()
        Me.PanelSuperior = New System.Windows.Forms.Panel()
        Me.MBtSalir = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.lbmap = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.pbmap = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PanelPrincipal.SuspendLayout()
        Me.PanelMapa.SuspendLayout()
        Me.PanelGroup.SuspendLayout()
        Me.slpanelInfo.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.PanelJanus.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.grCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.cbZona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.PanelSuperior.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.pbmap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.BackColor = System.Drawing.Color.Transparent
        Me.PanelPrincipal.Controls.Add(Me.PanelMapa)
        Me.PanelPrincipal.Controls.Add(Me.PanelGroup)
        Me.PanelPrincipal.Controls.Add(Me.PanelInferior)
        Me.PanelPrincipal.Controls.Add(Me.PanelSuperior)
        Me.PanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.PanelPrincipal.Name = "PanelPrincipal"
        Me.PanelPrincipal.Size = New System.Drawing.Size(1279, 733)
        Me.PanelPrincipal.TabIndex = 0
        '
        'PanelMapa
        '
        Me.PanelMapa.BackColor = System.Drawing.Color.Transparent
        Me.PanelMapa.Controls.Add(Me.btnz2)
        Me.PanelMapa.Controls.Add(Me.btnz1)
        Me.PanelMapa.Controls.Add(Me.Gmc_Cliente)
        Me.PanelMapa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMapa.Location = New System.Drawing.Point(358, 70)
        Me.PanelMapa.Name = "PanelMapa"
        Me.PanelMapa.Size = New System.Drawing.Size(921, 635)
        Me.PanelMapa.TabIndex = 1
        '
        'btnz2
        '
        Me.btnz2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnz2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnz2.Image = Global.Presentacion.My.Resources.Resources.iconalejar
        Me.btnz2.Location = New System.Drawing.Point(66, 20)
        Me.btnz2.Name = "btnz2"
        Me.btnz2.Size = New System.Drawing.Size(39, 39)
        Me.btnz2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnz2.TabIndex = 4
        Me.btnz2.Visible = False
        '
        'btnz1
        '
        Me.btnz1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnz1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnz1.Image = Global.Presentacion.My.Resources.Resources.iconacercar
        Me.btnz1.Location = New System.Drawing.Point(21, 20)
        Me.btnz1.Name = "btnz1"
        Me.btnz1.Size = New System.Drawing.Size(39, 39)
        Me.btnz1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnz1.TabIndex = 3
        Me.btnz1.Visible = False
        '
        'Gmc_Cliente
        '
        Me.Gmc_Cliente.AccessibleRole = System.Windows.Forms.AccessibleRole.Animation
        Me.Gmc_Cliente.BackColor = System.Drawing.Color.Transparent
        Me.Gmc_Cliente.Bearing = 0!
        Me.Gmc_Cliente.CanDragMap = True
        Me.Gmc_Cliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Gmc_Cliente.EmptyTileColor = System.Drawing.Color.Transparent
        Me.Gmc_Cliente.GrayScaleMode = False
        Me.Gmc_Cliente.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
        Me.Gmc_Cliente.LevelsKeepInMemmory = 5
        Me.Gmc_Cliente.Location = New System.Drawing.Point(0, 0)
        Me.Gmc_Cliente.MarkersEnabled = True
        Me.Gmc_Cliente.MaxZoom = 2
        Me.Gmc_Cliente.MinZoom = 2
        Me.Gmc_Cliente.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
        Me.Gmc_Cliente.Name = "Gmc_Cliente"
        Me.Gmc_Cliente.NegativeMode = False
        Me.Gmc_Cliente.PolygonsEnabled = True
        Me.Gmc_Cliente.RetryLoadTile = 0
        Me.Gmc_Cliente.RoutesEnabled = True
        Me.Gmc_Cliente.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
        Me.Gmc_Cliente.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.Gmc_Cliente.ShowTileGridLines = False
        Me.Gmc_Cliente.Size = New System.Drawing.Size(921, 635)
        Me.Gmc_Cliente.TabIndex = 0
        Me.Gmc_Cliente.Zoom = 0R
        '
        'PanelGroup
        '
        Me.PanelGroup.BackColor = System.Drawing.Color.White
        Me.PanelGroup.Controls.Add(Me.slpanelInfo)
        Me.PanelGroup.Controls.Add(Me.Panel1)
        Me.PanelGroup.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelGroup.Location = New System.Drawing.Point(0, 70)
        Me.PanelGroup.Name = "PanelGroup"
        Me.PanelGroup.Size = New System.Drawing.Size(358, 635)
        Me.PanelGroup.TabIndex = 0
        '
        'slpanelInfo
        '
        Me.slpanelInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.slpanelInfo.Controls.Add(Me.Panel4)
        Me.slpanelInfo.Controls.Add(Me.Panel3)
        Me.slpanelInfo.Dock = System.Windows.Forms.DockStyle.Left
        Me.slpanelInfo.Location = New System.Drawing.Point(0, 0)
        Me.slpanelInfo.Name = "slpanelInfo"
        Me.slpanelInfo.Size = New System.Drawing.Size(27, 635)
        Me.slpanelInfo.TabIndex = 1
        Me.slpanelInfo.Text = "SlidePanel1"
        Me.slpanelInfo.UsesBlockingAnimation = False
        Me.slpanelInfo.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Controls.Add(Me.lbobs)
        Me.Panel4.Controls.Add(Me.lbtel)
        Me.Panel4.Controls.Add(Me.lb4)
        Me.Panel4.Controls.Add(Me.lb3)
        Me.Panel4.Controls.Add(Me.lbcliente)
        Me.Panel4.Controls.Add(Me.lb1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 59)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(23, 572)
        Me.Panel4.TabIndex = 2
        '
        'lbobs
        '
        Me.lbobs.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbobs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lbobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbobs.Location = New System.Drawing.Point(21, 108)
        Me.lbobs.Multiline = True
        Me.lbobs.Name = "lbobs"
        Me.lbobs.Size = New System.Drawing.Size(278, 31)
        Me.lbobs.TabIndex = 7
        '
        'lbtel
        '
        Me.lbtel.AutoSize = True
        Me.lbtel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbtel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lbtel.Location = New System.Drawing.Point(22, 166)
        Me.lbtel.Name = "lbtel"
        Me.lbtel.Size = New System.Drawing.Size(65, 16)
        Me.lbtel.TabIndex = 5
        Me.lbtel.Text = "CLIENTE:"
        Me.lbtel.Visible = False
        '
        'lb4
        '
        Me.lb4.AutoSize = True
        Me.lb4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lb4.Location = New System.Drawing.Point(18, 142)
        Me.lb4.Name = "lb4"
        Me.lb4.Size = New System.Drawing.Size(95, 18)
        Me.lb4.TabIndex = 4
        Me.lb4.Text = "TELEFONO:"
        Me.lb4.Visible = False
        '
        'lb3
        '
        Me.lb3.AutoSize = True
        Me.lb3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lb3.Location = New System.Drawing.Point(17, 86)
        Me.lb3.Name = "lb3"
        Me.lb3.Size = New System.Drawing.Size(121, 18)
        Me.lb3.TabIndex = 2
        Me.lb3.Text = "OBSERVACION:"
        Me.lb3.Visible = False
        '
        'lbcliente
        '
        Me.lbcliente.AutoSize = True
        Me.lbcliente.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lbcliente.Location = New System.Drawing.Point(17, 59)
        Me.lbcliente.Name = "lbcliente"
        Me.lbcliente.Size = New System.Drawing.Size(65, 16)
        Me.lbcliente.TabIndex = 1
        Me.lbcliente.Text = "CLIENTE:"
        Me.lbcliente.Visible = False
        '
        'lb1
        '
        Me.lb1.AutoSize = True
        Me.lb1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lb1.Location = New System.Drawing.Point(16, 29)
        Me.lb1.Name = "lb1"
        Me.lb1.Size = New System.Drawing.Size(77, 18)
        Me.lb1.TabIndex = 0
        Me.lb1.Text = "CLIENTE:"
        Me.lb1.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Controls.Add(Me.lb2)
        Me.Panel3.Controls.Add(Me.btn1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.ForeColor = System.Drawing.Color.White
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(25, 20, 0, 15)
        Me.Panel3.Size = New System.Drawing.Size(23, 59)
        Me.Panel3.TabIndex = 1
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.Presentacion.My.Resources.Resources.man
        Me.PictureBox2.Location = New System.Drawing.Point(284, 11)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(42, 35)
        Me.PictureBox2.TabIndex = 2
        Me.PictureBox2.TabStop = False
        '
        'lb2
        '
        Me.lb2.AutoSize = True
        Me.lb2.Dock = System.Windows.Forms.DockStyle.Left
        Me.lb2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb2.Location = New System.Drawing.Point(54, 20)
        Me.lb2.Name = "lb2"
        Me.lb2.Padding = New System.Windows.Forms.Padding(6, 1, 0, 0)
        Me.lb2.Size = New System.Drawing.Size(224, 19)
        Me.lb2.TabIndex = 0
        Me.lb2.Text = "INFORMACION DEL CLIENTE"
        Me.lb2.Visible = False
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.Transparent
        Me.btn1.BackgroundImage = CType(resources.GetObject("btn1.BackgroundImage"), System.Drawing.Image)
        Me.btn1.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn1.FlatAppearance.BorderSize = 0
        Me.btn1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn1.Location = New System.Drawing.Point(25, 20)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(29, 24)
        Me.btn1.TabIndex = 1
        Me.btn1.UseVisualStyleBackColor = False
        Me.btn1.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PanelJanus)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(358, 635)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Visible = False
        '
        'PanelJanus
        '
        Me.PanelJanus.Controls.Add(Me.GroupPanel1)
        Me.PanelJanus.Controls.Add(Me.GroupPanel2)
        Me.PanelJanus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelJanus.Location = New System.Drawing.Point(0, 85)
        Me.PanelJanus.Name = "PanelJanus"
        Me.PanelJanus.Padding = New System.Windows.Forms.Padding(6)
        Me.PanelJanus.Size = New System.Drawing.Size(358, 550)
        Me.PanelJanus.TabIndex = 1
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.grCliente)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 68)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(346, 476)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColor = System.Drawing.Color.White
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
        Me.GroupPanel1.Text = "CLIENTES"
        '
        'grCliente
        '
        Me.grCliente.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grCliente.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None
        Me.grCliente.FlatBorderColor = System.Drawing.Color.DodgerBlue
        Me.grCliente.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle
        Me.grCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grCliente.GridLineColor = System.Drawing.Color.DodgerBlue
        Me.grCliente.HeaderFormatStyle.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grCliente.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grCliente.Location = New System.Drawing.Point(0, 0)
        Me.grCliente.Name = "grCliente"
        Me.grCliente.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.grCliente.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.grCliente.RowHeaderFormatStyle.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grCliente.SelectedFormatStyle.BackColor = System.Drawing.Color.DodgerBlue
        Me.grCliente.SelectedFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grCliente.SelectedFormatStyle.ForeColor = System.Drawing.Color.White
        Me.grCliente.Size = New System.Drawing.Size(340, 453)
        Me.grCliente.TabIndex = 0
        Me.grCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        Me.grCliente.VisualStyleAreas.CardsStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupPanel2
        '
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Panel6)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupPanel2.Location = New System.Drawing.Point(6, 6)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(346, 62)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel2.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColor = System.Drawing.Color.White
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 2
        Me.GroupPanel2.Text = "ZONAS"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.Controls.Add(Me.checkTodos)
        Me.Panel6.Controls.Add(Me.cbZona)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(340, 39)
        Me.Panel6.TabIndex = 0
        '
        'checkTodos
        '
        '
        '
        '
        Me.checkTodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.checkTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkTodos.Location = New System.Drawing.Point(19, 7)
        Me.checkTodos.Name = "checkTodos"
        Me.checkTodos.Size = New System.Drawing.Size(65, 23)
        Me.checkTodos.TabIndex = 2
        Me.checkTodos.Text = "TODOS"
        Me.checkTodos.TextColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        '
        'cbZona
        '
        Me.cbZona.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.cbZona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        cbZona_DesignTimeLayout.LayoutString = resources.GetString("cbZona_DesignTimeLayout.LayoutString")
        Me.cbZona.DesignTimeLayout = cbZona_DesignTimeLayout
        Me.cbZona.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbZona.Location = New System.Drawing.Point(108, 7)
        Me.cbZona.Name = "cbZona"
        Me.cbZona.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbZona.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbZona.SelectedIndex = -1
        Me.cbZona.SelectedItem = Nothing
        Me.cbZona.Size = New System.Drawing.Size(220, 22)
        Me.cbZona.TabIndex = 1
        Me.cbZona.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Dt_Fecha)
        Me.Panel2.Controls.Add(Me.RBPE)
        Me.Panel2.Controls.Add(Me.RBCL)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.ForeColor = System.Drawing.Color.White
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(15, 20, 0, 0)
        Me.Panel2.Size = New System.Drawing.Size(358, 85)
        Me.Panel2.TabIndex = 0
        '
        'Dt_Fecha
        '
        Me.Dt_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dt_Fecha.Location = New System.Drawing.Point(215, 62)
        Me.Dt_Fecha.Margin = New System.Windows.Forms.Padding(2)
        Me.Dt_Fecha.Name = "Dt_Fecha"
        Me.Dt_Fecha.Size = New System.Drawing.Size(84, 22)
        Me.Dt_Fecha.TabIndex = 2
        Me.Dt_Fecha.Visible = False
        '
        'RBPE
        '
        Me.RBPE.AutoSize = True
        Me.RBPE.Location = New System.Drawing.Point(126, 62)
        Me.RBPE.Margin = New System.Windows.Forms.Padding(2)
        Me.RBPE.Name = "RBPE"
        Me.RBPE.Size = New System.Drawing.Size(77, 20)
        Me.RBPE.TabIndex = 1
        Me.RBPE.Text = "Pedidos"
        Me.RBPE.UseVisualStyleBackColor = True
        '
        'RBCL
        '
        Me.RBCL.AutoSize = True
        Me.RBCL.Checked = True
        Me.RBCL.Location = New System.Drawing.Point(126, 40)
        Me.RBCL.Margin = New System.Windows.Forms.Padding(2)
        Me.RBCL.Name = "RBCL"
        Me.RBCL.Size = New System.Drawing.Size(77, 20)
        Me.RBCL.TabIndex = 1
        Me.RBCL.TabStop = True
        Me.RBCL.Text = "Clientes"
        Me.RBCL.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(197, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "INFORMACION CLIENTE"
        '
        'PanelInferior
        '
        Me.PanelInferior.BackgroundImage = CType(resources.GetObject("PanelInferior.BackgroundImage"), System.Drawing.Image)
        Me.PanelInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelInferior.Location = New System.Drawing.Point(0, 705)
        Me.PanelInferior.Name = "PanelInferior"
        Me.PanelInferior.Size = New System.Drawing.Size(1279, 28)
        Me.PanelInferior.TabIndex = 2
        '
        'PanelSuperior
        '
        Me.PanelSuperior.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.PanelSuperior.Controls.Add(Me.MBtSalir)
        Me.PanelSuperior.Controls.Add(Me.ButtonX1)
        Me.PanelSuperior.Controls.Add(Me.lbmap)
        Me.PanelSuperior.Controls.Add(Me.Panel5)
        Me.PanelSuperior.Controls.Add(Me.PictureBox1)
        Me.PanelSuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSuperior.Location = New System.Drawing.Point(0, 0)
        Me.PanelSuperior.Name = "PanelSuperior"
        Me.PanelSuperior.Padding = New System.Windows.Forms.Padding(0, 0, 70, 0)
        Me.PanelSuperior.Size = New System.Drawing.Size(1279, 70)
        Me.PanelSuperior.TabIndex = 0
        '
        'MBtSalir
        '
        Me.MBtSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.MBtSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
        Me.MBtSalir.Dock = System.Windows.Forms.DockStyle.Left
        Me.MBtSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MBtSalir.Image = Global.Presentacion.My.Resources.Resources.SELECCIONAR_TODOS
        Me.MBtSalir.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.MBtSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.MBtSalir.Location = New System.Drawing.Point(430, 0)
        Me.MBtSalir.Name = "MBtSalir"
        Me.MBtSalir.Size = New System.Drawing.Size(76, 70)
        Me.MBtSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MBtSalir.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1})
        Me.MBtSalir.TabIndex = 11
        Me.MBtSalir.Text = "SALIR"
        Me.MBtSalir.TextColor = System.Drawing.Color.Black
        '
        'ButtonItem1
        '
        Me.ButtonItem1.GlobalItem = False
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "ButtonItem1"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
        Me.ButtonX1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ButtonX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX1.Image = Global.Presentacion.My.Resources.Resources.reload_5
        Me.ButtonX1.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.ButtonX1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonX1.Location = New System.Drawing.Point(358, 0)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(72, 70)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 12
        Me.ButtonX1.Text = "RECARGAR"
        Me.ButtonX1.TextColor = System.Drawing.Color.Black
        '
        'lbmap
        '
        '
        '
        '
        Me.lbmap.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbmap.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbmap.Location = New System.Drawing.Point(79, 0)
        Me.lbmap.Name = "lbmap"
        Me.lbmap.Size = New System.Drawing.Size(279, 70)
        Me.lbmap.TabIndex = 2
        Me.lbmap.Text = "<b><font size=""+6""><font color=""#FEFCFC"">UBICACIONES DE CLIENTES</font></font></b" &
    ">"
        Me.lbmap.Visible = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.pbmap)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(20, 10, 10, 10)
        Me.Panel5.Size = New System.Drawing.Size(79, 70)
        Me.Panel5.TabIndex = 1
        '
        'pbmap
        '
        Me.pbmap.BackgroundImage = Global.Presentacion.My.Resources.Resources.place3
        Me.pbmap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbmap.Location = New System.Drawing.Point(20, 10)
        Me.pbmap.Name = "pbmap"
        Me.pbmap.Size = New System.Drawing.Size(49, 50)
        Me.pbmap.TabIndex = 0
        Me.pbmap.TabStop = False
        Me.pbmap.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.Presentacion.My.Resources.Resources.dinases
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Location = New System.Drawing.Point(954, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(255, 70)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'F1_MapaCLientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1279, 733)
        Me.Controls.Add(Me.PanelPrincipal)
        Me.Name = "F1_MapaCLientes"
        Me.Text = "F1_MapaCLientes"
        Me.PanelPrincipal.ResumeLayout(False)
        Me.PanelMapa.ResumeLayout(False)
        Me.PanelGroup.ResumeLayout(False)
        Me.slpanelInfo.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.PanelJanus.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.grCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.cbZona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PanelSuperior.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.pbmap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelPrincipal As System.Windows.Forms.Panel
    Friend WithEvents PanelMapa As System.Windows.Forms.Panel
    Friend WithEvents PanelGroup As System.Windows.Forms.Panel
    Friend WithEvents PanelSuperior As System.Windows.Forms.Panel
    Friend WithEvents Gmc_Cliente As GMap.NET.WindowsForms.GMapControl
    Friend WithEvents PanelInferior As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents slpanelInfo As DevComponents.DotNetBar.Controls.SlidePanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lb2 As System.Windows.Forms.Label
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lbtel As System.Windows.Forms.Label
    Friend WithEvents lb4 As System.Windows.Forms.Label
    Friend WithEvents lb3 As System.Windows.Forms.Label
    Friend WithEvents lbcliente As System.Windows.Forms.Label
    Friend WithEvents lb1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbmap As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents pbmap As System.Windows.Forms.PictureBox
    Friend WithEvents btnz2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnz1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelJanus As System.Windows.Forms.Panel
    Friend WithEvents lbobs As System.Windows.Forms.TextBox
    Protected WithEvents MBtSalir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents grCliente As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents checkTodos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbZona As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Protected WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents RBPE As RadioButton
    Friend WithEvents RBCL As RadioButton
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Dt_Fecha As DateTimePicker
End Class
