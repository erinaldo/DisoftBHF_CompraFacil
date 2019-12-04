<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class R01_PrestamoEquiposAgrupado
    Inherits Modelo.ModeloR01

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
        Me.GpCliente = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.SbFiltroCliente = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.TbNombreCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TbCodigoCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.BtBuscarCliente = New DevComponents.DotNetBar.ButtonX()
        Me.MPnSuperior.SuspendLayout()
        Me.MPnInferior.SuspendLayout()
        Me.MPanelToolBarUsuario.SuspendLayout()
        Me.MPanelToolBarAccion.SuspendLayout()
        CType(Me.MBubbleBarUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MPnUsuario.SuspendLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MGpFiltro.SuspendLayout()
        Me.GpCliente.SuspendLayout()
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
        Me.MGpFiltro.Controls.Add(Me.GpCliente)
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
        Me.MGpFiltro.Controls.SetChildIndex(Me.GpCliente, 0)
        '
        'MCrReporte
        '
        Me.MCrReporte.Size = New System.Drawing.Size(684, 561)
        '
        'GpCliente
        '
        Me.GpCliente.BackColor = System.Drawing.Color.Transparent
        Me.GpCliente.CanvasColor = System.Drawing.SystemColors.Control
        Me.GpCliente.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GpCliente.Controls.Add(Me.SbFiltroCliente)
        Me.GpCliente.Controls.Add(Me.LabelX4)
        Me.GpCliente.Controls.Add(Me.TbNombreCliente)
        Me.GpCliente.Controls.Add(Me.TbCodigoCliente)
        Me.GpCliente.Controls.Add(Me.BtBuscarCliente)
        Me.GpCliente.DisabledBackColor = System.Drawing.Color.Empty
        Me.GpCliente.Dock = System.Windows.Forms.DockStyle.Top
        Me.GpCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GpCliente.Location = New System.Drawing.Point(0, 0)
        Me.GpCliente.Name = "GpCliente"
        Me.GpCliente.Size = New System.Drawing.Size(294, 160)
        '
        '
        '
        Me.GpCliente.Style.BackColor = System.Drawing.Color.Transparent
        Me.GpCliente.Style.BackColor2 = System.Drawing.Color.Transparent
        Me.GpCliente.Style.BackColorGradientAngle = 90
        Me.GpCliente.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpCliente.Style.BorderBottomWidth = 1
        Me.GpCliente.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GpCliente.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpCliente.Style.BorderLeftWidth = 1
        Me.GpCliente.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpCliente.Style.BorderRightWidth = 1
        Me.GpCliente.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpCliente.Style.BorderTopWidth = 1
        Me.GpCliente.Style.CornerDiameter = 4
        Me.GpCliente.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GpCliente.Style.TextColor = System.Drawing.SystemColors.WindowText
        Me.GpCliente.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GpCliente.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GpCliente.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GpCliente.TabIndex = 15
        Me.GpCliente.Text = "CLIENTE"
        '
        'SbFiltroCliente
        '
        '
        '
        '
        Me.SbFiltroCliente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SbFiltroCliente.Location = New System.Drawing.Point(75, 4)
        Me.SbFiltroCliente.Name = "SbFiltroCliente"
        Me.SbFiltroCliente.OffText = "TODOS"
        Me.SbFiltroCliente.OnText = "UNO"
        Me.SbFiltroCliente.Size = New System.Drawing.Size(100, 22)
        Me.SbFiltroCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SbFiltroCliente.TabIndex = 13
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
        'TbNombreCliente
        '
        '
        '
        '
        Me.TbNombreCliente.Border.Class = "TextBoxBorder"
        Me.TbNombreCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TbNombreCliente.Location = New System.Drawing.Point(6, 67)
        Me.TbNombreCliente.Multiline = True
        Me.TbNombreCliente.Name = "TbNombreCliente"
        Me.TbNombreCliente.PreventEnterBeep = True
        Me.TbNombreCliente.Size = New System.Drawing.Size(285, 66)
        Me.TbNombreCliente.TabIndex = 11
        '
        'TbCodigoCliente
        '
        '
        '
        '
        Me.TbCodigoCliente.Border.Class = "TextBoxBorder"
        Me.TbCodigoCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TbCodigoCliente.Location = New System.Drawing.Point(6, 38)
        Me.TbCodigoCliente.Name = "TbCodigoCliente"
        Me.TbCodigoCliente.PreventEnterBeep = True
        Me.TbCodigoCliente.Size = New System.Drawing.Size(62, 21)
        Me.TbCodigoCliente.TabIndex = 10
        '
        'BtBuscarCliente
        '
        Me.BtBuscarCliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtBuscarCliente.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.BtBuscarCliente.Image = Global.Presentacion.My.Resources.Resources.buscar
        Me.BtBuscarCliente.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.BtBuscarCliente.Location = New System.Drawing.Point(75, 31)
        Me.BtBuscarCliente.Name = "BtBuscarCliente"
        Me.BtBuscarCliente.Size = New System.Drawing.Size(38, 34)
        Me.BtBuscarCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtBuscarCliente.TabIndex = 15
        '
        'R01_PrestamoEquiposAgrupado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "R01_PrestamoEquiposAgrupado"
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
        Me.GpCliente.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GpCliente As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents SbFiltroCliente As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TbNombreCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TbCodigoCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents BtBuscarCliente As DevComponents.DotNetBar.ButtonX
End Class
