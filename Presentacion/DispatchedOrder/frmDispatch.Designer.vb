<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDispatch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDispatch))
        Me.PanelBase = New System.Windows.Forms.Panel()
        Me.PanelSubBase = New System.Windows.Forms.Panel()
        Me.PanelPedido = New System.Windows.Forms.Panel()
        Me.dgjPedido = New Janus.Windows.GridEX.GridEX()
        Me.PanelProducto = New System.Windows.Forms.Panel()
        Me.dgjProducto = New Janus.Windows.GridEX.GridEX()
        Me.PanelAccion = New System.Windows.Forms.Panel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.cbChoferes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.PanelZona = New System.Windows.Forms.Panel()
        Me.PanelZonaGrilla = New System.Windows.Forms.Panel()
        Me.dgjZona = New Janus.Windows.GridEX.GridEX()
        Me.btGrabar = New DevComponents.DotNetBar.ButtonX()
        Me.btActualizar = New DevComponents.DotNetBar.ButtonX()
        Me.btConsultar = New DevComponents.DotNetBar.ButtonX()
        Me.PanelBase.SuspendLayout()
        Me.PanelSubBase.SuspendLayout()
        Me.PanelPedido.SuspendLayout()
        CType(Me.dgjPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelProducto.SuspendLayout()
        CType(Me.dgjProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelAccion.SuspendLayout()
        CType(Me.cbChoferes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelZona.SuspendLayout()
        Me.PanelZonaGrilla.SuspendLayout()
        CType(Me.dgjZona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelBase
        '
        Me.PanelBase.Controls.Add(Me.PanelSubBase)
        Me.PanelBase.Controls.Add(Me.PanelZona)
        Me.PanelBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBase.Location = New System.Drawing.Point(0, 0)
        Me.PanelBase.Name = "PanelBase"
        Me.PanelBase.Size = New System.Drawing.Size(800, 450)
        Me.PanelBase.TabIndex = 0
        '
        'PanelSubBase
        '
        Me.PanelSubBase.Controls.Add(Me.PanelPedido)
        Me.PanelSubBase.Controls.Add(Me.PanelProducto)
        Me.PanelSubBase.Controls.Add(Me.PanelAccion)
        Me.PanelSubBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelSubBase.Location = New System.Drawing.Point(270, 0)
        Me.PanelSubBase.Name = "PanelSubBase"
        Me.PanelSubBase.Size = New System.Drawing.Size(530, 450)
        Me.PanelSubBase.TabIndex = 1
        '
        'PanelPedido
        '
        Me.PanelPedido.Controls.Add(Me.dgjPedido)
        Me.PanelPedido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelPedido.Location = New System.Drawing.Point(0, 60)
        Me.PanelPedido.Name = "PanelPedido"
        Me.PanelPedido.Size = New System.Drawing.Size(530, 290)
        Me.PanelPedido.TabIndex = 2
        '
        'dgjPedido
        '
        Me.dgjPedido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgjPedido.Location = New System.Drawing.Point(0, 0)
        Me.dgjPedido.Name = "dgjPedido"
        Me.dgjPedido.Size = New System.Drawing.Size(530, 290)
        Me.dgjPedido.TabIndex = 1
        '
        'PanelProducto
        '
        Me.PanelProducto.Controls.Add(Me.dgjProducto)
        Me.PanelProducto.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelProducto.Location = New System.Drawing.Point(0, 350)
        Me.PanelProducto.Name = "PanelProducto"
        Me.PanelProducto.Size = New System.Drawing.Size(530, 100)
        Me.PanelProducto.TabIndex = 1
        '
        'dgjProducto
        '
        Me.dgjProducto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgjProducto.Location = New System.Drawing.Point(0, 0)
        Me.dgjProducto.Name = "dgjProducto"
        Me.dgjProducto.Size = New System.Drawing.Size(530, 100)
        Me.dgjProducto.TabIndex = 2
        '
        'PanelAccion
        '
        Me.PanelAccion.Controls.Add(Me.btGrabar)
        Me.PanelAccion.Controls.Add(Me.btActualizar)
        Me.PanelAccion.Controls.Add(Me.LabelX2)
        Me.PanelAccion.Controls.Add(Me.cbChoferes)
        Me.PanelAccion.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelAccion.Location = New System.Drawing.Point(0, 0)
        Me.PanelAccion.Name = "PanelAccion"
        Me.PanelAccion.Size = New System.Drawing.Size(530, 60)
        Me.PanelAccion.TabIndex = 0
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(6, 12)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(55, 23)
        Me.LabelX2.TabIndex = 1
        Me.LabelX2.Text = "Choferes:"
        '
        'cbChoferes
        '
        cbChoferes_DesignTimeLayout.LayoutString = resources.GetString("cbChoferes_DesignTimeLayout.LayoutString")
        Me.cbChoferes.DesignTimeLayout = cbChoferes_DesignTimeLayout
        Me.cbChoferes.Location = New System.Drawing.Point(67, 14)
        Me.cbChoferes.Name = "cbChoferes"
        Me.cbChoferes.SelectedIndex = -1
        Me.cbChoferes.SelectedItem = Nothing
        Me.cbChoferes.Size = New System.Drawing.Size(200, 20)
        Me.cbChoferes.TabIndex = 0
        '
        'PanelZona
        '
        Me.PanelZona.Controls.Add(Me.PanelZonaGrilla)
        Me.PanelZona.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelZona.Location = New System.Drawing.Point(0, 0)
        Me.PanelZona.Name = "PanelZona"
        Me.PanelZona.Size = New System.Drawing.Size(270, 450)
        Me.PanelZona.TabIndex = 0
        '
        'PanelZonaGrilla
        '
        Me.PanelZonaGrilla.Controls.Add(Me.dgjZona)
        Me.PanelZonaGrilla.Controls.Add(Me.btConsultar)
        Me.PanelZonaGrilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelZonaGrilla.Location = New System.Drawing.Point(0, 0)
        Me.PanelZonaGrilla.Name = "PanelZonaGrilla"
        Me.PanelZonaGrilla.Size = New System.Drawing.Size(270, 450)
        Me.PanelZonaGrilla.TabIndex = 1
        '
        'dgjZona
        '
        Me.dgjZona.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgjZona.Location = New System.Drawing.Point(0, 0)
        Me.dgjZona.Name = "dgjZona"
        Me.dgjZona.Size = New System.Drawing.Size(270, 400)
        Me.dgjZona.TabIndex = 0
        '
        'btGrabar
        '
        Me.btGrabar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btGrabar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btGrabar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btGrabar.Image = Global.Presentacion.My.Resources.Resources.GRABAR
        Me.btGrabar.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.btGrabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btGrabar.Location = New System.Drawing.Point(380, 0)
        Me.btGrabar.Name = "btGrabar"
        Me.btGrabar.Size = New System.Drawing.Size(75, 60)
        Me.btGrabar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btGrabar.TabIndex = 2
        Me.btGrabar.Text = "Grabar"
        '
        'btActualizar
        '
        Me.btActualizar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btActualizar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btActualizar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btActualizar.Image = Global.Presentacion.My.Resources.Resources.ACTUALIZAR
        Me.btActualizar.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.btActualizar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btActualizar.Location = New System.Drawing.Point(455, 0)
        Me.btActualizar.Name = "btActualizar"
        Me.btActualizar.Size = New System.Drawing.Size(75, 60)
        Me.btActualizar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btActualizar.TabIndex = 3
        Me.btActualizar.Text = "Actualizar"
        '
        'btConsultar
        '
        Me.btConsultar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btConsultar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btConsultar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btConsultar.Image = Global.Presentacion.My.Resources.Resources.buscar
        Me.btConsultar.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.btConsultar.Location = New System.Drawing.Point(0, 400)
        Me.btConsultar.Name = "btConsultar"
        Me.btConsultar.Size = New System.Drawing.Size(270, 50)
        Me.btConsultar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btConsultar.TabIndex = 1
        Me.btConsultar.Text = "CONSULTAR"
        '
        'frmDispatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.PanelBase)
        Me.Name = "frmDispatch"
        Me.Text = "frmDispatch"
        Me.PanelBase.ResumeLayout(False)
        Me.PanelSubBase.ResumeLayout(False)
        Me.PanelPedido.ResumeLayout(False)
        CType(Me.dgjPedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelProducto.ResumeLayout(False)
        CType(Me.dgjProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelAccion.ResumeLayout(False)
        Me.PanelAccion.PerformLayout()
        CType(Me.cbChoferes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelZona.ResumeLayout(False)
        Me.PanelZonaGrilla.ResumeLayout(False)
        CType(Me.dgjZona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelBase As Panel
    Friend WithEvents PanelSubBase As Panel
    Friend WithEvents PanelPedido As Panel
    Friend WithEvents PanelProducto As Panel
    Friend WithEvents PanelAccion As Panel
    Friend WithEvents PanelZona As Panel
    Friend WithEvents PanelZonaGrilla As Panel
    Friend WithEvents dgjPedido As Janus.Windows.GridEX.GridEX
    Friend WithEvents dgjProducto As Janus.Windows.GridEX.GridEX
    Friend WithEvents btActualizar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btGrabar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbChoferes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btConsultar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dgjZona As Janus.Windows.GridEX.GridEX
End Class
