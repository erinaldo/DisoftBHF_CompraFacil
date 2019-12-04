<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModeloF01_ca
    Inherits System.Windows.Forms.Form

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
        Me.MSuperTabControlPrincipal = New DevComponents.DotNetBar.SuperTabControl()
        Me.MSuperTabControlPanelRegistro = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.MPnUsuario = New System.Windows.Forms.Panel()
        Me.MLbHora = New System.Windows.Forms.Label()
        Me.MLbFecha = New System.Windows.Forms.Label()
        Me.MLbUsuario = New System.Windows.Forms.Label()
        Me.MLblHora = New System.Windows.Forms.Label()
        Me.MLblFecha = New System.Windows.Forms.Label()
        Me.MLblUsuario = New System.Windows.Forms.Label()
        Me.MSuperTabItemRegistro = New DevComponents.DotNetBar.SuperTabItem()
        Me.MPnSuperior = New DevComponents.DotNetBar.PanelEx()
        Me.MRlAccion = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.MPanelToolBarImprimir = New System.Windows.Forms.Panel()
        Me.MBtImprimir = New DevComponents.DotNetBar.ButtonX()
        Me.MPanelToolBarAccion = New System.Windows.Forms.Panel()
        Me.MBtSalir = New DevComponents.DotNetBar.ButtonX()
        Me.MBtGrabar = New DevComponents.DotNetBar.ButtonX()
        Me.MBtEliminar = New DevComponents.DotNetBar.ButtonX()
        Me.MBtModificar = New DevComponents.DotNetBar.ButtonX()
        Me.MBtNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.MPnInferior = New DevComponents.DotNetBar.PanelEx()
        Me.MPanelToolBarUsuario = New System.Windows.Forms.Panel()
        Me.MBubbleBarUsuario = New DevComponents.DotNetBar.BubbleBar()
        Me.BubbleBarTabUsuario = New DevComponents.DotNetBar.BubbleBarTab(Me.components)
        Me.MBtUsuario = New DevComponents.DotNetBar.BubbleButton()
        Me.MTbUsuario = New System.Windows.Forms.TextBox()
        Me.MPanelToolBarNavegacion = New System.Windows.Forms.Panel()
        Me.MLbPaginacion = New DevComponents.DotNetBar.LabelX()
        Me.MBtUltimo = New DevComponents.DotNetBar.ButtonX()
        Me.MBtSiguiente = New DevComponents.DotNetBar.ButtonX()
        Me.MBtAnterior = New DevComponents.DotNetBar.ButtonX()
        Me.MBtPrimero = New DevComponents.DotNetBar.ButtonX()
        Me.MEP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.MHighlighterFocus = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.MFlyoutUsuario = New DevComponents.DotNetBar.Controls.Flyout(Me.components)
        CType(Me.MSuperTabControlPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MSuperTabControlPrincipal.SuspendLayout()
        Me.MSuperTabControlPanelRegistro.SuspendLayout()
        Me.MPnUsuario.SuspendLayout()
        Me.MPnSuperior.SuspendLayout()
        Me.MPanelToolBarImprimir.SuspendLayout()
        Me.MPanelToolBarAccion.SuspendLayout()
        Me.MPnInferior.SuspendLayout()
        Me.MPanelToolBarUsuario.SuspendLayout()
        CType(Me.MBubbleBarUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MPanelToolBarNavegacion.SuspendLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.MSuperTabControlPrincipal.Controls.Add(Me.MSuperTabControlPanelRegistro)
        Me.MSuperTabControlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MSuperTabControlPrincipal.HorizontalText = False
        Me.MSuperTabControlPrincipal.Location = New System.Drawing.Point(0, 70)
        Me.MSuperTabControlPrincipal.Name = "MSuperTabControlPrincipal"
        Me.MSuperTabControlPrincipal.ReorderTabsEnabled = True
        Me.MSuperTabControlPrincipal.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.MSuperTabControlPrincipal.SelectedTabIndex = 0
        Me.MSuperTabControlPrincipal.Size = New System.Drawing.Size(984, 455)
        Me.MSuperTabControlPrincipal.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.MSuperTabControlPrincipal.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MSuperTabControlPrincipal.TabIndex = 0
        Me.MSuperTabControlPrincipal.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MSuperTabItemRegistro})
        Me.MSuperTabControlPrincipal.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.MSuperTabControlPrincipal.TabVerticalSpacing = 5
        '
        'MSuperTabControlPanelRegistro
        '
        Me.MSuperTabControlPanelRegistro.Controls.Add(Me.MPnUsuario)
        Me.MSuperTabControlPanelRegistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MSuperTabControlPanelRegistro.Location = New System.Drawing.Point(0, 0)
        Me.MSuperTabControlPanelRegistro.Name = "MSuperTabControlPanelRegistro"
        Me.MSuperTabControlPanelRegistro.Size = New System.Drawing.Size(942, 455)
        Me.MSuperTabControlPanelRegistro.TabIndex = 1
        Me.MSuperTabControlPanelRegistro.TabItem = Me.MSuperTabItemRegistro
        '
        'MPnUsuario
        '
        Me.MPnUsuario.Controls.Add(Me.MLbHora)
        Me.MPnUsuario.Controls.Add(Me.MLbFecha)
        Me.MPnUsuario.Controls.Add(Me.MLbUsuario)
        Me.MPnUsuario.Controls.Add(Me.MLblHora)
        Me.MPnUsuario.Controls.Add(Me.MLblFecha)
        Me.MPnUsuario.Controls.Add(Me.MLblUsuario)
        Me.MPnUsuario.Location = New System.Drawing.Point(619, 6)
        Me.MPnUsuario.Name = "MPnUsuario"
        Me.MPnUsuario.Size = New System.Drawing.Size(220, 100)
        Me.MPnUsuario.TabIndex = 28
        Me.MPnUsuario.TabStop = True
        Me.MPnUsuario.Visible = False
        '
        'MLbHora
        '
        Me.MLbHora.AutoSize = True
        Me.MLbHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MLbHora.Location = New System.Drawing.Point(115, 65)
        Me.MLbHora.Name = "MLbHora"
        Me.MLbHora.Size = New System.Drawing.Size(79, 18)
        Me.MLbHora.TabIndex = 6
        Me.MLbHora.Text = "USUARIO:"
        '
        'MLbFecha
        '
        Me.MLbFecha.AutoSize = True
        Me.MLbFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MLbFecha.Location = New System.Drawing.Point(115, 42)
        Me.MLbFecha.Name = "MLbFecha"
        Me.MLbFecha.Size = New System.Drawing.Size(79, 18)
        Me.MLbFecha.TabIndex = 5
        Me.MLbFecha.Text = "USUARIO:"
        '
        'MLbUsuario
        '
        Me.MLbUsuario.AutoSize = True
        Me.MLbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MLbUsuario.Location = New System.Drawing.Point(115, 19)
        Me.MLbUsuario.Name = "MLbUsuario"
        Me.MLbUsuario.Size = New System.Drawing.Size(79, 18)
        Me.MLbUsuario.TabIndex = 4
        Me.MLbUsuario.Text = "USUARIO:"
        '
        'MLblHora
        '
        Me.MLblHora.AutoSize = True
        Me.MLblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MLblHora.Location = New System.Drawing.Point(31, 65)
        Me.MLblHora.Name = "MLblHora"
        Me.MLblHora.Size = New System.Drawing.Size(60, 18)
        Me.MLblHora.TabIndex = 2
        Me.MLblHora.Text = "HORA:"
        '
        'MLblFecha
        '
        Me.MLblFecha.AutoSize = True
        Me.MLblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MLblFecha.Location = New System.Drawing.Point(31, 43)
        Me.MLblFecha.Name = "MLblFecha"
        Me.MLblFecha.Size = New System.Drawing.Size(68, 18)
        Me.MLblFecha.TabIndex = 1
        Me.MLblFecha.Text = "FECHA:"
        '
        'MLblUsuario
        '
        Me.MLblUsuario.AutoSize = True
        Me.MLblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MLblUsuario.Location = New System.Drawing.Point(31, 19)
        Me.MLblUsuario.Name = "MLblUsuario"
        Me.MLblUsuario.Size = New System.Drawing.Size(87, 18)
        Me.MLblUsuario.TabIndex = 0
        Me.MLblUsuario.Text = "USUARIO:"
        '
        'MSuperTabItemRegistro
        '
        Me.MSuperTabItemRegistro.AttachedControl = Me.MSuperTabControlPanelRegistro
        Me.MSuperTabItemRegistro.FixedTabSize = New System.Drawing.Size(120, 40)
        Me.MSuperTabItemRegistro.GlobalItem = False
        Me.MSuperTabItemRegistro.Image = Global.Modelo.My.Resources.Resources.I32x32_registrar
        Me.MSuperTabItemRegistro.Name = "MSuperTabItemRegistro"
        Me.MSuperTabItemRegistro.Stretch = True
        Me.MSuperTabItemRegistro.Text = "REGISTRO"
        '
        'MPnSuperior
        '
        Me.MPnSuperior.CanvasColor = System.Drawing.SystemColors.Control
        Me.MPnSuperior.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MPnSuperior.Controls.Add(Me.MRlAccion)
        Me.MPnSuperior.Controls.Add(Me.MPanelToolBarImprimir)
        Me.MPnSuperior.Controls.Add(Me.MPanelToolBarAccion)
        Me.MPnSuperior.DisabledBackColor = System.Drawing.Color.Empty
        Me.MPnSuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.MPnSuperior.Location = New System.Drawing.Point(0, 0)
        Me.MPnSuperior.Name = "MPnSuperior"
        Me.MPnSuperior.Size = New System.Drawing.Size(984, 70)
        Me.MPnSuperior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.MPnSuperior.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.MPnSuperior.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.MPnSuperior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.MPnSuperior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.MPnSuperior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.MPnSuperior.Style.GradientAngle = 90
        Me.MPnSuperior.TabIndex = 4
        '
        'MRlAccion
        '
        '
        '
        '
        Me.MRlAccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MRlAccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MRlAccion.ForeColor = System.Drawing.Color.Black
        Me.MRlAccion.Location = New System.Drawing.Point(382, 4)
        Me.MRlAccion.Name = "MRlAccion"
        Me.MRlAccion.Size = New System.Drawing.Size(200, 60)
        Me.MRlAccion.TabIndex = 9
        Me.MRlAccion.Text = "<b><font size=""+10""><font color=""#FF0000""></font></font></b>"
        '
        'MPanelToolBarImprimir
        '
        Me.MPanelToolBarImprimir.Controls.Add(Me.MBtImprimir)
        Me.MPanelToolBarImprimir.Dock = System.Windows.Forms.DockStyle.Right
        Me.MPanelToolBarImprimir.Location = New System.Drawing.Point(904, 0)
        Me.MPanelToolBarImprimir.Name = "MPanelToolBarImprimir"
        Me.MPanelToolBarImprimir.Size = New System.Drawing.Size(80, 70)
        Me.MPanelToolBarImprimir.TabIndex = 8
        '
        'MBtImprimir
        '
        Me.MBtImprimir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.MBtImprimir.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.MBtImprimir.Dock = System.Windows.Forms.DockStyle.Right
        Me.MBtImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MBtImprimir.Image = Global.Modelo.My.Resources.Resources.I512x512_print
        Me.MBtImprimir.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.MBtImprimir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.MBtImprimir.Location = New System.Drawing.Point(8, 0)
        Me.MBtImprimir.Name = "MBtImprimir"
        Me.MBtImprimir.Size = New System.Drawing.Size(72, 70)
        Me.MBtImprimir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MBtImprimir.TabIndex = 11
        Me.MBtImprimir.Text = "IMPRIMIR"
        Me.MBtImprimir.TextColor = System.Drawing.Color.Black
        '
        'MPanelToolBarAccion
        '
        Me.MPanelToolBarAccion.Controls.Add(Me.MBtSalir)
        Me.MPanelToolBarAccion.Controls.Add(Me.MBtGrabar)
        Me.MPanelToolBarAccion.Controls.Add(Me.MBtEliminar)
        Me.MPanelToolBarAccion.Controls.Add(Me.MBtModificar)
        Me.MPanelToolBarAccion.Controls.Add(Me.MBtNuevo)
        Me.MPanelToolBarAccion.Dock = System.Windows.Forms.DockStyle.Left
        Me.MPanelToolBarAccion.Location = New System.Drawing.Point(0, 0)
        Me.MPanelToolBarAccion.Name = "MPanelToolBarAccion"
        Me.MPanelToolBarAccion.Size = New System.Drawing.Size(376, 70)
        Me.MPanelToolBarAccion.TabIndex = 7
        '
        'MBtSalir
        '
        Me.MBtSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.MBtSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
        Me.MBtSalir.Dock = System.Windows.Forms.DockStyle.Left
        Me.MBtSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MBtSalir.Image = Global.Modelo.My.Resources.Resources.I512x512_return
        Me.MBtSalir.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.MBtSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.MBtSalir.Location = New System.Drawing.Point(288, 0)
        Me.MBtSalir.Name = "MBtSalir"
        Me.MBtSalir.Size = New System.Drawing.Size(72, 70)
        Me.MBtSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MBtSalir.TabIndex = 10
        Me.MBtSalir.Text = "SALIR"
        Me.MBtSalir.TextColor = System.Drawing.Color.Black
        '
        'MBtGrabar
        '
        Me.MBtGrabar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.MBtGrabar.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.MBtGrabar.Dock = System.Windows.Forms.DockStyle.Left
        Me.MBtGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MBtGrabar.Image = Global.Modelo.My.Resources.Resources.I512x512_save
        Me.MBtGrabar.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.MBtGrabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.MBtGrabar.Location = New System.Drawing.Point(216, 0)
        Me.MBtGrabar.Name = "MBtGrabar"
        Me.MBtGrabar.Size = New System.Drawing.Size(72, 70)
        Me.MBtGrabar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MBtGrabar.TabIndex = 9
        Me.MBtGrabar.Text = "GRABAR"
        Me.MBtGrabar.TextColor = System.Drawing.Color.Black
        '
        'MBtEliminar
        '
        Me.MBtEliminar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.MBtEliminar.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta
        Me.MBtEliminar.Dock = System.Windows.Forms.DockStyle.Left
        Me.MBtEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MBtEliminar.Image = Global.Modelo.My.Resources.Resources.I512x512_remove
        Me.MBtEliminar.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.MBtEliminar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.MBtEliminar.Location = New System.Drawing.Point(144, 0)
        Me.MBtEliminar.Name = "MBtEliminar"
        Me.MBtEliminar.Size = New System.Drawing.Size(72, 70)
        Me.MBtEliminar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MBtEliminar.TabIndex = 8
        Me.MBtEliminar.Text = "ELIMINAR"
        Me.MBtEliminar.TextColor = System.Drawing.Color.Black
        '
        'MBtModificar
        '
        Me.MBtModificar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.MBtModificar.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta
        Me.MBtModificar.Dock = System.Windows.Forms.DockStyle.Left
        Me.MBtModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MBtModificar.Image = Global.Modelo.My.Resources.Resources.I512x512_edit
        Me.MBtModificar.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.MBtModificar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.MBtModificar.Location = New System.Drawing.Point(72, 0)
        Me.MBtModificar.Name = "MBtModificar"
        Me.MBtModificar.Size = New System.Drawing.Size(72, 70)
        Me.MBtModificar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MBtModificar.TabIndex = 7
        Me.MBtModificar.Text = "MODIFICAR"
        Me.MBtModificar.TextColor = System.Drawing.Color.Black
        '
        'MBtNuevo
        '
        Me.MBtNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.MBtNuevo.BackColor = System.Drawing.Color.Transparent
        Me.MBtNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta
        Me.MBtNuevo.Dock = System.Windows.Forms.DockStyle.Left
        Me.MBtNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MBtNuevo.Image = Global.Modelo.My.Resources.Resources.I512x512_new
        Me.MBtNuevo.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.MBtNuevo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.MBtNuevo.Location = New System.Drawing.Point(0, 0)
        Me.MBtNuevo.Name = "MBtNuevo"
        Me.MBtNuevo.Size = New System.Drawing.Size(72, 70)
        Me.MBtNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MBtNuevo.TabIndex = 6
        Me.MBtNuevo.Text = "NUEVO"
        Me.MBtNuevo.TextColor = System.Drawing.Color.Black
        '
        'MPnInferior
        '
        Me.MPnInferior.CanvasColor = System.Drawing.SystemColors.Control
        Me.MPnInferior.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MPnInferior.Controls.Add(Me.MPanelToolBarUsuario)
        Me.MPnInferior.Controls.Add(Me.MPanelToolBarNavegacion)
        Me.MPnInferior.DisabledBackColor = System.Drawing.Color.Empty
        Me.MPnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MPnInferior.Location = New System.Drawing.Point(0, 525)
        Me.MPnInferior.Name = "MPnInferior"
        Me.MPnInferior.Size = New System.Drawing.Size(984, 36)
        Me.MPnInferior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.MPnInferior.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.MPnInferior.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.MPnInferior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.MPnInferior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.MPnInferior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.MPnInferior.Style.GradientAngle = 90
        Me.MPnInferior.TabIndex = 8
        '
        'MPanelToolBarUsuario
        '
        Me.MPanelToolBarUsuario.Controls.Add(Me.MBubbleBarUsuario)
        Me.MPanelToolBarUsuario.Controls.Add(Me.MTbUsuario)
        Me.MPanelToolBarUsuario.Dock = System.Windows.Forms.DockStyle.Right
        Me.MPanelToolBarUsuario.Location = New System.Drawing.Point(784, 0)
        Me.MPanelToolBarUsuario.Name = "MPanelToolBarUsuario"
        Me.MPanelToolBarUsuario.Size = New System.Drawing.Size(200, 36)
        Me.MPanelToolBarUsuario.TabIndex = 24
        '
        'MBubbleBarUsuario
        '
        Me.MBubbleBarUsuario.Alignment = DevComponents.DotNetBar.eBubbleButtonAlignment.Bottom
        Me.MBubbleBarUsuario.AntiAlias = True
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
        Me.MBubbleBarUsuario.Dock = System.Windows.Forms.DockStyle.Left
        Me.MBubbleBarUsuario.ImageSizeNormal = New System.Drawing.Size(24, 24)
        Me.MBubbleBarUsuario.Location = New System.Drawing.Point(0, 0)
        Me.MBubbleBarUsuario.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight
        Me.MBubbleBarUsuario.Name = "MBubbleBarUsuario"
        Me.MBubbleBarUsuario.SelectedTab = Me.BubbleBarTabUsuario
        Me.MBubbleBarUsuario.SelectedTabColors.BorderColor = System.Drawing.Color.Black
        Me.MBubbleBarUsuario.Size = New System.Drawing.Size(50, 36)
        Me.MBubbleBarUsuario.TabIndex = 15
        Me.MBubbleBarUsuario.Tabs.Add(Me.BubbleBarTabUsuario)
        Me.MBubbleBarUsuario.TabsVisible = False
        Me.MBubbleBarUsuario.Text = "BubbleBar5"
        '
        'BubbleBarTabUsuario
        '
        Me.BubbleBarTabUsuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.BubbleBarTabUsuario.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.BubbleBarTabUsuario.Buttons.AddRange(New DevComponents.DotNetBar.BubbleButton() {Me.MBtUsuario})
        Me.BubbleBarTabUsuario.DarkBorderColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.BubbleBarTabUsuario.LightBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BubbleBarTabUsuario.Name = "BubbleBarTabUsuario"
        Me.BubbleBarTabUsuario.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Blue
        Me.BubbleBarTabUsuario.Text = "BubbleBarTab3"
        Me.BubbleBarTabUsuario.TextColor = System.Drawing.Color.Black
        '
        'MBtUsuario
        '
        Me.MBtUsuario.Image = Global.Modelo.My.Resources.Resources.I512x512_user
        Me.MBtUsuario.ImageLarge = Global.Modelo.My.Resources.Resources.I512x512_user
        Me.MBtUsuario.Name = "MBtUsuario"
        '
        'MTbUsuario
        '
        Me.MTbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MTbUsuario.Location = New System.Drawing.Point(59, 5)
        Me.MTbUsuario.Multiline = True
        Me.MTbUsuario.Name = "MTbUsuario"
        Me.MTbUsuario.Size = New System.Drawing.Size(135, 27)
        Me.MTbUsuario.TabIndex = 14
        '
        'MPanelToolBarNavegacion
        '
        Me.MPanelToolBarNavegacion.Controls.Add(Me.MLbPaginacion)
        Me.MPanelToolBarNavegacion.Controls.Add(Me.MBtUltimo)
        Me.MPanelToolBarNavegacion.Controls.Add(Me.MBtSiguiente)
        Me.MPanelToolBarNavegacion.Controls.Add(Me.MBtAnterior)
        Me.MPanelToolBarNavegacion.Controls.Add(Me.MBtPrimero)
        Me.MPanelToolBarNavegacion.Dock = System.Windows.Forms.DockStyle.Left
        Me.MPanelToolBarNavegacion.Location = New System.Drawing.Point(0, 0)
        Me.MPanelToolBarNavegacion.Name = "MPanelToolBarNavegacion"
        Me.MPanelToolBarNavegacion.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.MPanelToolBarNavegacion.Size = New System.Drawing.Size(320, 36)
        Me.MPanelToolBarNavegacion.TabIndex = 23
        '
        'MLbPaginacion
        '
        '
        '
        '
        Me.MLbPaginacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MLbPaginacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MLbPaginacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MLbPaginacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MLbPaginacion.Location = New System.Drawing.Point(177, 0)
        Me.MLbPaginacion.Name = "MLbPaginacion"
        Me.MLbPaginacion.Size = New System.Drawing.Size(138, 36)
        Me.MLbPaginacion.TabIndex = 15
        Me.MLbPaginacion.Text = "12345/12345"
        Me.MLbPaginacion.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'MBtUltimo
        '
        Me.MBtUltimo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.MBtUltimo.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.MBtUltimo.Dock = System.Windows.Forms.DockStyle.Left
        Me.MBtUltimo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MBtUltimo.Image = Global.Modelo.My.Resources.Resources.I512x512_last
        Me.MBtUltimo.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.MBtUltimo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.MBtUltimo.Location = New System.Drawing.Point(134, 0)
        Me.MBtUltimo.Name = "MBtUltimo"
        Me.MBtUltimo.Size = New System.Drawing.Size(43, 36)
        Me.MBtUltimo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MBtUltimo.TabIndex = 14
        '
        'MBtSiguiente
        '
        Me.MBtSiguiente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.MBtSiguiente.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.MBtSiguiente.Dock = System.Windows.Forms.DockStyle.Left
        Me.MBtSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MBtSiguiente.Image = Global.Modelo.My.Resources.Resources.I512x512_next
        Me.MBtSiguiente.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.MBtSiguiente.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.MBtSiguiente.Location = New System.Drawing.Point(91, 0)
        Me.MBtSiguiente.Name = "MBtSiguiente"
        Me.MBtSiguiente.Size = New System.Drawing.Size(43, 36)
        Me.MBtSiguiente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MBtSiguiente.TabIndex = 13
        '
        'MBtAnterior
        '
        Me.MBtAnterior.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.MBtAnterior.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.MBtAnterior.Dock = System.Windows.Forms.DockStyle.Left
        Me.MBtAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MBtAnterior.Image = Global.Modelo.My.Resources.Resources.I512x512_previous
        Me.MBtAnterior.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.MBtAnterior.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.MBtAnterior.Location = New System.Drawing.Point(48, 0)
        Me.MBtAnterior.Name = "MBtAnterior"
        Me.MBtAnterior.Size = New System.Drawing.Size(43, 36)
        Me.MBtAnterior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MBtAnterior.TabIndex = 12
        '
        'MBtPrimero
        '
        Me.MBtPrimero.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.MBtPrimero.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.MBtPrimero.Dock = System.Windows.Forms.DockStyle.Left
        Me.MBtPrimero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MBtPrimero.Image = Global.Modelo.My.Resources.Resources.I512x512_first
        Me.MBtPrimero.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.MBtPrimero.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.MBtPrimero.Location = New System.Drawing.Point(5, 0)
        Me.MBtPrimero.Name = "MBtPrimero"
        Me.MBtPrimero.Size = New System.Drawing.Size(43, 36)
        Me.MBtPrimero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MBtPrimero.TabIndex = 11
        '
        'MEP
        '
        Me.MEP.ContainerControl = Me
        '
        'MFlyoutUsuario
        '
        Me.MFlyoutUsuario.DropShadow = False
        '
        'ModeloF01_ca
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.MSuperTabControlPrincipal)
        Me.Controls.Add(Me.MPnInferior)
        Me.Controls.Add(Me.MPnSuperior)
        Me.KeyPreview = True
        Me.Name = "ModeloF01_ca"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "{...TITULO...}"
        CType(Me.MSuperTabControlPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MSuperTabControlPrincipal.ResumeLayout(False)
        Me.MSuperTabControlPanelRegistro.ResumeLayout(False)
        Me.MPnUsuario.ResumeLayout(False)
        Me.MPnUsuario.PerformLayout()
        Me.MPnSuperior.ResumeLayout(False)
        Me.MPanelToolBarImprimir.ResumeLayout(False)
        Me.MPanelToolBarAccion.ResumeLayout(False)
        Me.MPnInferior.ResumeLayout(False)
        Me.MPanelToolBarUsuario.ResumeLayout(False)
        Me.MPanelToolBarUsuario.PerformLayout()
        CType(Me.MBubbleBarUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MPanelToolBarNavegacion.ResumeLayout(False)
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents MSuperTabControlPrincipal As DevComponents.DotNetBar.SuperTabControl
    Protected WithEvents MSuperTabControlPanelRegistro As DevComponents.DotNetBar.SuperTabControlPanel
    Protected WithEvents MSuperTabItemRegistro As DevComponents.DotNetBar.SuperTabItem
    Protected WithEvents MPnSuperior As DevComponents.DotNetBar.PanelEx
    Protected WithEvents MPnInferior As DevComponents.DotNetBar.PanelEx
    Protected WithEvents MPanelToolBarUsuario As System.Windows.Forms.Panel
    Protected WithEvents MTbUsuario As System.Windows.Forms.TextBox
    Protected WithEvents MPanelToolBarNavegacion As System.Windows.Forms.Panel
    Protected WithEvents MBtUltimo As DevComponents.DotNetBar.ButtonX
    Protected WithEvents MBtSiguiente As DevComponents.DotNetBar.ButtonX
    Protected WithEvents MBtAnterior As DevComponents.DotNetBar.ButtonX
    Protected WithEvents MBtPrimero As DevComponents.DotNetBar.ButtonX
    Protected WithEvents MPanelToolBarAccion As System.Windows.Forms.Panel
    Protected WithEvents MBtSalir As DevComponents.DotNetBar.ButtonX
    Protected WithEvents MBtGrabar As DevComponents.DotNetBar.ButtonX
    Protected WithEvents MBtEliminar As DevComponents.DotNetBar.ButtonX
    Protected WithEvents MBtModificar As DevComponents.DotNetBar.ButtonX
    Protected WithEvents MBtNuevo As DevComponents.DotNetBar.ButtonX
    Protected WithEvents MPanelToolBarImprimir As System.Windows.Forms.Panel
    Protected WithEvents MBtImprimir As DevComponents.DotNetBar.ButtonX
    Protected WithEvents MBubbleBarUsuario As DevComponents.DotNetBar.BubbleBar
    Protected WithEvents BubbleBarTabUsuario As DevComponents.DotNetBar.BubbleBarTab
    Protected WithEvents MPnUsuario As System.Windows.Forms.Panel
    Protected WithEvents MLbHora As System.Windows.Forms.Label
    Protected WithEvents MLbFecha As System.Windows.Forms.Label
    Protected WithEvents MLbUsuario As System.Windows.Forms.Label
    Protected WithEvents MLblHora As System.Windows.Forms.Label
    Protected WithEvents MLblFecha As System.Windows.Forms.Label
    Protected WithEvents MLblUsuario As System.Windows.Forms.Label
    Protected WithEvents MLbPaginacion As DevComponents.DotNetBar.LabelX
    Protected WithEvents MEP As System.Windows.Forms.ErrorProvider
    Protected WithEvents MHighlighterFocus As DevComponents.DotNetBar.Validator.Highlighter
    Protected WithEvents MFlyoutUsuario As DevComponents.DotNetBar.Controls.Flyout
    Protected WithEvents MBtUsuario As DevComponents.DotNetBar.BubbleButton
    Protected WithEvents MRlAccion As DevComponents.DotNetBar.Controls.ReflectionLabel
End Class
