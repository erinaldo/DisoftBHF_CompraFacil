<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim cbgrupo4_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btgrupo2 = New DevComponents.DotNetBar.ButtonX()
        Me.btgrupo4 = New DevComponents.DotNetBar.ButtonX()
        Me.lbgrupo4 = New DevComponents.DotNetBar.LabelX()
        Me.cbgrupo4 = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        CType(Me.cbgrupo4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btgrupo2
        '
        Me.btgrupo2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btgrupo2.BackColor = System.Drawing.Color.Transparent
        Me.btgrupo2.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.btgrupo2.Image = Global.Presentacion.My.Resources.Resources.add
        Me.btgrupo2.ImageFixedSize = New System.Drawing.Size(25, 23)
        Me.btgrupo2.Location = New System.Drawing.Point(386, 214)
        Me.btgrupo2.Name = "btgrupo2"
        Me.btgrupo2.Size = New System.Drawing.Size(28, 23)
        Me.btgrupo2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btgrupo2.TabIndex = 211
        Me.btgrupo2.Visible = False
        '
        'btgrupo4
        '
        Me.btgrupo4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btgrupo4.BackColor = System.Drawing.Color.Transparent
        Me.btgrupo4.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.btgrupo4.ImageFixedSize = New System.Drawing.Size(25, 23)
        Me.btgrupo4.Location = New System.Drawing.Point(525, 137)
        Me.btgrupo4.Name = "btgrupo4"
        Me.btgrupo4.Size = New System.Drawing.Size(28, 23)
        Me.btgrupo4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btgrupo4.TabIndex = 215
        Me.btgrupo4.Visible = False
        '
        'lbgrupo4
        '
        Me.lbgrupo4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lbgrupo4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbgrupo4.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbgrupo4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lbgrupo4.Location = New System.Drawing.Point(249, 134)
        Me.lbgrupo4.Name = "lbgrupo4"
        Me.lbgrupo4.SingleLineColor = System.Drawing.SystemColors.Control
        Me.lbgrupo4.Size = New System.Drawing.Size(116, 23)
        Me.lbgrupo4.TabIndex = 214
        Me.lbgrupo4.Text = "Grupo 4:"
        '
        'cbgrupo4
        '
        cbgrupo4_DesignTimeLayout.LayoutString = resources.GetString("cbgrupo4_DesignTimeLayout.LayoutString")
        Me.cbgrupo4.DesignTimeLayout = cbgrupo4_DesignTimeLayout
        Me.cbgrupo4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbgrupo4.Location = New System.Drawing.Point(375, 135)
        Me.cbgrupo4.MaxLength = 40
        Me.cbgrupo4.Name = "cbgrupo4"
        Me.cbgrupo4.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbgrupo4.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbgrupo4.SelectedIndex = -1
        Me.cbgrupo4.SelectedItem = Nothing
        Me.cbgrupo4.Size = New System.Drawing.Size(144, 22)
        Me.cbgrupo4.TabIndex = 213
        Me.cbgrupo4.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btgrupo4)
        Me.Controls.Add(Me.lbgrupo4)
        Me.Controls.Add(Me.cbgrupo4)
        Me.Controls.Add(Me.btgrupo2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.cbgrupo4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btgrupo2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btgrupo4 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lbgrupo4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbgrupo4 As Janus.Windows.GridEX.EditControls.MultiColumnCombo
End Class
