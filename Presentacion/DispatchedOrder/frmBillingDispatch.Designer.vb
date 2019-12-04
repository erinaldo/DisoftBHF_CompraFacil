<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBillingDispatch
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
        Dim cbChoferes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBillingDispatch))
        Me.PanelBase = New System.Windows.Forms.Panel()
        Me.PanelPedido = New System.Windows.Forms.Panel()
        Me.dgjPedido = New Janus.Windows.GridEX.GridEX()
        Me.PanelProducto = New System.Windows.Forms.Panel()
        Me.dgjProducto = New Janus.Windows.GridEX.GridEX()
        Me.PanelSuperior = New System.Windows.Forms.Panel()
        Me.btFacturar = New DevComponents.DotNetBar.ButtonX()
        Me.btReporteDespachoCliente = New DevComponents.DotNetBar.ButtonX()
        Me.btReporteDespachoLinea = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.cbChoferes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.PanelBase.SuspendLayout()
        Me.PanelPedido.SuspendLayout()
        CType(Me.dgjPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelProducto.SuspendLayout()
        CType(Me.dgjProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSuperior.SuspendLayout()
        CType(Me.cbChoferes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelBase
        '
        Me.PanelBase.Controls.Add(Me.PanelPedido)
        Me.PanelBase.Controls.Add(Me.PanelProducto)
        Me.PanelBase.Controls.Add(Me.PanelSuperior)
        Me.PanelBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBase.Location = New System.Drawing.Point(0, 0)
        Me.PanelBase.Name = "PanelBase"
        Me.PanelBase.Size = New System.Drawing.Size(800, 450)
        Me.PanelBase.TabIndex = 0
        '
        'PanelPedido
        '
        Me.PanelPedido.Controls.Add(Me.dgjPedido)
        Me.PanelPedido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelPedido.Location = New System.Drawing.Point(0, 60)
        Me.PanelPedido.Name = "PanelPedido"
        Me.PanelPedido.Size = New System.Drawing.Size(800, 290)
        Me.PanelPedido.TabIndex = 1
        '
        'dgjPedido
        '
        Me.dgjPedido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgjPedido.Location = New System.Drawing.Point(0, 0)
        Me.dgjPedido.Name = "dgjPedido"
        Me.dgjPedido.Size = New System.Drawing.Size(800, 290)
        Me.dgjPedido.TabIndex = 2
        '
        'PanelProducto
        '
        Me.PanelProducto.Controls.Add(Me.dgjProducto)
        Me.PanelProducto.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelProducto.Location = New System.Drawing.Point(0, 350)
        Me.PanelProducto.Name = "PanelProducto"
        Me.PanelProducto.Size = New System.Drawing.Size(800, 100)
        Me.PanelProducto.TabIndex = 1
        '
        'dgjProducto
        '
        Me.dgjProducto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgjProducto.Location = New System.Drawing.Point(0, 0)
        Me.dgjProducto.Name = "dgjProducto"
        Me.dgjProducto.Size = New System.Drawing.Size(800, 100)
        Me.dgjProducto.TabIndex = 3
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Controls.Add(Me.btFacturar)
        Me.PanelSuperior.Controls.Add(Me.btReporteDespachoCliente)
        Me.PanelSuperior.Controls.Add(Me.btReporteDespachoLinea)
        Me.PanelSuperior.Controls.Add(Me.LabelX2)
        Me.PanelSuperior.Controls.Add(Me.cbChoferes)
        Me.PanelSuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSuperior.Location = New System.Drawing.Point(0, 0)
        Me.PanelSuperior.Name = "PanelSuperior"
        Me.PanelSuperior.Size = New System.Drawing.Size(800, 60)
        Me.PanelSuperior.TabIndex = 0
        '
        'btFacturar
        '
        Me.btFacturar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btFacturar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btFacturar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btFacturar.Image = Global.Presentacion.My.Resources.Resources.REPORTE2
        Me.btFacturar.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.btFacturar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btFacturar.Location = New System.Drawing.Point(575, 0)
        Me.btFacturar.Name = "btFacturar"
        Me.btFacturar.Size = New System.Drawing.Size(75, 60)
        Me.btFacturar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btFacturar.TabIndex = 4
        Me.btFacturar.Text = "Facturar"
        '
        'btReporteDespachoCliente
        '
        Me.btReporteDespachoCliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btReporteDespachoCliente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btReporteDespachoCliente.Dock = System.Windows.Forms.DockStyle.Right
        Me.btReporteDespachoCliente.Image = Global.Presentacion.My.Resources.Resources.PEDI_ULTIMOS_PEDIDOS
        Me.btReporteDespachoCliente.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.btReporteDespachoCliente.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btReporteDespachoCliente.Location = New System.Drawing.Point(650, 0)
        Me.btReporteDespachoCliente.Name = "btReporteDespachoCliente"
        Me.btReporteDespachoCliente.Size = New System.Drawing.Size(75, 60)
        Me.btReporteDespachoCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btReporteDespachoCliente.TabIndex = 6
        Me.btReporteDespachoCliente.Text = "Despacho por cliente"
        '
        'btReporteDespachoLinea
        '
        Me.btReporteDespachoLinea.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btReporteDespachoLinea.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btReporteDespachoLinea.Dock = System.Windows.Forms.DockStyle.Right
        Me.btReporteDespachoLinea.Image = Global.Presentacion.My.Resources.Resources.PEDI_ENTRAGA_PEDIDOS
        Me.btReporteDespachoLinea.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.btReporteDespachoLinea.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btReporteDespachoLinea.Location = New System.Drawing.Point(725, 0)
        Me.btReporteDespachoLinea.Name = "btReporteDespachoLinea"
        Me.btReporteDespachoLinea.Size = New System.Drawing.Size(75, 60)
        Me.btReporteDespachoLinea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btReporteDespachoLinea.TabIndex = 5
        Me.btReporteDespachoLinea.Text = "Despacho por linea"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(12, 12)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(55, 23)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Choferes:"
        '
        'cbChoferes
        '
        cbChoferes_DesignTimeLayout.LayoutString = resources.GetString("cbChoferes_DesignTimeLayout.LayoutString")
        Me.cbChoferes.DesignTimeLayout = cbChoferes_DesignTimeLayout
        Me.cbChoferes.Location = New System.Drawing.Point(73, 14)
        Me.cbChoferes.Name = "cbChoferes"
        Me.cbChoferes.SelectedIndex = -1
        Me.cbChoferes.SelectedItem = Nothing
        Me.cbChoferes.Size = New System.Drawing.Size(200, 20)
        Me.cbChoferes.TabIndex = 2
        '
        'frmBillingDispatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.PanelBase)
        Me.Name = "frmBillingDispatch"
        Me.Text = "frmBillingDispatch"
        Me.PanelBase.ResumeLayout(False)
        Me.PanelPedido.ResumeLayout(False)
        CType(Me.dgjPedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelProducto.ResumeLayout(False)
        CType(Me.dgjProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSuperior.ResumeLayout(False)
        Me.PanelSuperior.PerformLayout()
        CType(Me.cbChoferes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelBase As Panel
    Friend WithEvents PanelPedido As Panel
    Friend WithEvents PanelProducto As Panel
    Friend WithEvents PanelSuperior As Panel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbChoferes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btFacturar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btReporteDespachoLinea As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dgjPedido As Janus.Windows.GridEX.GridEX
    Friend WithEvents dgjProducto As Janus.Windows.GridEX.GridEX
    Friend WithEvents btReporteDespachoCliente As DevComponents.DotNetBar.ButtonX
End Class
