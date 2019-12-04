<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModeloR02
    Inherits System.Windows.Forms.Form

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
        Me.MPnUsuario = New System.Windows.Forms.Panel()
        Me.MLbHora = New System.Windows.Forms.Label()
        Me.MLbFecha = New System.Windows.Forms.Label()
        Me.MLbUsuario = New System.Windows.Forms.Label()
        Me.MLblHora = New System.Windows.Forms.Label()
        Me.MLblFecha = New System.Windows.Forms.Label()
        Me.MLblUsuario = New System.Windows.Forms.Label()
        Me.MPnSuperior = New DevComponents.DotNetBar.PanelEx()
        Me.MPanelToolBarAccion = New System.Windows.Forms.Panel()
        Me.MBtSalir = New DevComponents.DotNetBar.ButtonX()
        Me.MBtGenerar = New DevComponents.DotNetBar.ButtonX()
        Me.MPnInferior = New DevComponents.DotNetBar.PanelEx()
        Me.MPanelToolBarUsuario = New System.Windows.Forms.Panel()
        Me.MBubbleBarUsuario = New DevComponents.DotNetBar.BubbleBar()
        Me.BubbleBarTabUsuario = New DevComponents.DotNetBar.BubbleBarTab()
        Me.MBtUsuario = New DevComponents.DotNetBar.BubbleButton()
        Me.MTbUsuario = New System.Windows.Forms.TextBox()
        Me.MEP = New System.Windows.Forms.ErrorProvider()
        Me.MHighlighterFocus = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.MFlyoutUsuario = New DevComponents.DotNetBar.Controls.Flyout()
        Me.MPnLeft = New DevComponents.DotNetBar.PanelEx()
        Me.MGpFiltro = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.MPbPublicidad = New System.Windows.Forms.PictureBox()
        Me.MPnReporte = New DevComponents.DotNetBar.PanelEx()
        Me.MPnUsuario.SuspendLayout()
        Me.MPnSuperior.SuspendLayout()
        Me.MPanelToolBarAccion.SuspendLayout()
        Me.MPnInferior.SuspendLayout()
        Me.MPanelToolBarUsuario.SuspendLayout()
        CType(Me.MBubbleBarUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MPnLeft.SuspendLayout()
        Me.MGpFiltro.SuspendLayout()
        CType(Me.MPbPublicidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MPnUsuario
        '
        Me.MPnUsuario.Controls.Add(Me.MLbHora)
        Me.MPnUsuario.Controls.Add(Me.MLbFecha)
        Me.MPnUsuario.Controls.Add(Me.MLbUsuario)
        Me.MPnUsuario.Controls.Add(Me.MLblHora)
        Me.MPnUsuario.Controls.Add(Me.MLblFecha)
        Me.MPnUsuario.Controls.Add(Me.MLblUsuario)
        Me.MPnUsuario.Location = New System.Drawing.Point(682, 153)
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
        'MPnSuperior
        '
        Me.MPnSuperior.CanvasColor = System.Drawing.SystemColors.Control
        Me.MPnSuperior.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MPnSuperior.Controls.Add(Me.MPanelToolBarAccion)
        Me.MPnSuperior.DisabledBackColor = System.Drawing.Color.Empty
        Me.MPnSuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.MPnSuperior.Location = New System.Drawing.Point(0, 0)
        Me.MPnSuperior.Name = "MPnSuperior"
        Me.MPnSuperior.Size = New System.Drawing.Size(300, 70)
        Me.MPnSuperior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.MPnSuperior.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.MPnSuperior.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.MPnSuperior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.MPnSuperior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.MPnSuperior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.MPnSuperior.Style.GradientAngle = 90
        Me.MPnSuperior.TabIndex = 4
        '
        'MPanelToolBarAccion
        '
        Me.MPanelToolBarAccion.Controls.Add(Me.MBtSalir)
        Me.MPanelToolBarAccion.Controls.Add(Me.MBtGenerar)
        Me.MPanelToolBarAccion.Location = New System.Drawing.Point(50, 0)
        Me.MPanelToolBarAccion.Name = "MPanelToolBarAccion"
        Me.MPanelToolBarAccion.Size = New System.Drawing.Size(199, 70)
        Me.MPanelToolBarAccion.TabIndex = 7
        '
        'MBtSalir
        '
        Me.MBtSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.MBtSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
        Me.MBtSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MBtSalir.Image = Global.Modelo.My.Resources.Resources.I512x512_return
        Me.MBtSalir.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.MBtSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.MBtSalir.Location = New System.Drawing.Point(107, 0)
        Me.MBtSalir.Name = "MBtSalir"
        Me.MBtSalir.Size = New System.Drawing.Size(72, 70)
        Me.MBtSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MBtSalir.TabIndex = 10
        Me.MBtSalir.Text = "SALIR"
        Me.MBtSalir.TextColor = System.Drawing.Color.Black
        '
        'MBtGenerar
        '
        Me.MBtGenerar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.MBtGenerar.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.MBtGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MBtGenerar.Image = Global.Modelo.My.Resources.Resources.I512x512_analytics_42
        Me.MBtGenerar.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.MBtGenerar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.MBtGenerar.Location = New System.Drawing.Point(19, 0)
        Me.MBtGenerar.Name = "MBtGenerar"
        Me.MBtGenerar.Size = New System.Drawing.Size(72, 70)
        Me.MBtGenerar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MBtGenerar.TabIndex = 9
        Me.MBtGenerar.Text = "GENERAR"
        Me.MBtGenerar.TextColor = System.Drawing.Color.Black
        '
        'MPnInferior
        '
        Me.MPnInferior.CanvasColor = System.Drawing.SystemColors.Control
        Me.MPnInferior.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MPnInferior.Controls.Add(Me.MPanelToolBarUsuario)
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
        'MEP
        '
        Me.MEP.ContainerControl = Me
        '
        'MFlyoutUsuario
        '
        Me.MFlyoutUsuario.DropShadow = False
        '
        'MPnLeft
        '
        Me.MPnLeft.CanvasColor = System.Drawing.SystemColors.Control
        Me.MPnLeft.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MPnLeft.Controls.Add(Me.MGpFiltro)
        Me.MPnLeft.Controls.Add(Me.MPnSuperior)
        Me.MPnLeft.DisabledBackColor = System.Drawing.Color.Empty
        Me.MPnLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.MPnLeft.Location = New System.Drawing.Point(0, 0)
        Me.MPnLeft.Name = "MPnLeft"
        Me.MPnLeft.Size = New System.Drawing.Size(300, 525)
        Me.MPnLeft.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.MPnLeft.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.MPnLeft.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.MPnLeft.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.MPnLeft.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.MPnLeft.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.MPnLeft.Style.GradientAngle = 90
        Me.MPnLeft.TabIndex = 29
        '
        'MGpFiltro
        '
        Me.MGpFiltro.CanvasColor = System.Drawing.SystemColors.Control
        Me.MGpFiltro.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.MGpFiltro.Controls.Add(Me.MPbPublicidad)
        Me.MGpFiltro.DisabledBackColor = System.Drawing.Color.Empty
        Me.MGpFiltro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MGpFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MGpFiltro.Location = New System.Drawing.Point(0, 70)
        Me.MGpFiltro.Name = "MGpFiltro"
        Me.MGpFiltro.Size = New System.Drawing.Size(300, 455)
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
        Me.MGpFiltro.TabIndex = 0
        Me.MGpFiltro.Text = "FILTROS"
        '
        'MPbPublicidad
        '
        Me.MPbPublicidad.BackColor = System.Drawing.Color.Transparent
        Me.MPbPublicidad.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MPbPublicidad.Image = Global.Modelo.My.Resources.Resources.dinases
        Me.MPbPublicidad.Location = New System.Drawing.Point(0, 363)
        Me.MPbPublicidad.Name = "MPbPublicidad"
        Me.MPbPublicidad.Size = New System.Drawing.Size(294, 70)
        Me.MPbPublicidad.TabIndex = 11
        Me.MPbPublicidad.TabStop = False
        '
        'MPnReporte
        '
        Me.MPnReporte.CanvasColor = System.Drawing.SystemColors.Control
        Me.MPnReporte.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MPnReporte.DisabledBackColor = System.Drawing.Color.Empty
        Me.MPnReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MPnReporte.Location = New System.Drawing.Point(300, 0)
        Me.MPnReporte.Name = "MPnReporte"
        Me.MPnReporte.Size = New System.Drawing.Size(684, 525)
        Me.MPnReporte.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.MPnReporte.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.MPnReporte.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.MPnReporte.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.MPnReporte.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.MPnReporte.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.MPnReporte.Style.GradientAngle = 90
        Me.MPnReporte.TabIndex = 36
        '
        'ModeloR02
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.MPnUsuario)
        Me.Controls.Add(Me.MPnReporte)
        Me.Controls.Add(Me.MPnLeft)
        Me.Controls.Add(Me.MPnInferior)
        Me.KeyPreview = True
        Me.Name = "ModeloR02"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "{...TITULO...}"
        Me.MPnUsuario.ResumeLayout(False)
        Me.MPnUsuario.PerformLayout()
        Me.MPnSuperior.ResumeLayout(False)
        Me.MPanelToolBarAccion.ResumeLayout(False)
        Me.MPnInferior.ResumeLayout(False)
        Me.MPanelToolBarUsuario.ResumeLayout(False)
        Me.MPanelToolBarUsuario.PerformLayout()
        CType(Me.MBubbleBarUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MPnLeft.ResumeLayout(False)
        Me.MGpFiltro.ResumeLayout(False)
        CType(Me.MPbPublicidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents MPnSuperior As DevComponents.DotNetBar.PanelEx
    Protected WithEvents MPnInferior As DevComponents.DotNetBar.PanelEx
    Protected WithEvents MPanelToolBarUsuario As System.Windows.Forms.Panel
    Protected WithEvents MTbUsuario As System.Windows.Forms.TextBox
    Protected WithEvents MPanelToolBarAccion As System.Windows.Forms.Panel
    Protected WithEvents MBtSalir As DevComponents.DotNetBar.ButtonX
    Protected WithEvents MBtGenerar As DevComponents.DotNetBar.ButtonX
    Protected WithEvents MBubbleBarUsuario As DevComponents.DotNetBar.BubbleBar
    Protected WithEvents BubbleBarTabUsuario As DevComponents.DotNetBar.BubbleBarTab
    Protected WithEvents MPnUsuario As System.Windows.Forms.Panel
    Protected WithEvents MLbHora As System.Windows.Forms.Label
    Protected WithEvents MLbFecha As System.Windows.Forms.Label
    Protected WithEvents MLbUsuario As System.Windows.Forms.Label
    Protected WithEvents MLblHora As System.Windows.Forms.Label
    Protected WithEvents MLblFecha As System.Windows.Forms.Label
    Protected WithEvents MLblUsuario As System.Windows.Forms.Label
    Protected WithEvents MEP As System.Windows.Forms.ErrorProvider
    Protected WithEvents MHighlighterFocus As DevComponents.DotNetBar.Validator.Highlighter
    Protected WithEvents MFlyoutUsuario As DevComponents.DotNetBar.Controls.Flyout
    Protected WithEvents MBtUsuario As DevComponents.DotNetBar.BubbleButton
    Friend WithEvents MPnLeft As DevComponents.DotNetBar.PanelEx
    Friend WithEvents MPbPublicidad As System.Windows.Forms.PictureBox
    Protected WithEvents MGpFiltro As DevComponents.DotNetBar.Controls.GroupPanel
    Protected WithEvents MPnReporte As DevComponents.DotNetBar.PanelEx
End Class
