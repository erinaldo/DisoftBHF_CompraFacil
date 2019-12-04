<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCImagen
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.UcPnBase = New System.Windows.Forms.Panel()
        Me.UcPbImage = New System.Windows.Forms.PictureBox()
        Me.UcPnBase.SuspendLayout()
        CType(Me.UcPbImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UcPnBase
        '
        Me.UcPnBase.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.UcPnBase.Controls.Add(Me.UcPbImage)
        Me.UcPnBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcPnBase.Location = New System.Drawing.Point(0, 0)
        Me.UcPnBase.Name = "UcPnBase"
        Me.UcPnBase.Padding = New System.Windows.Forms.Padding(7)
        Me.UcPnBase.Size = New System.Drawing.Size(200, 200)
        Me.UcPnBase.TabIndex = 4
        '
        'UcPbImage
        '
        Me.UcPbImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcPbImage.Image = Global.Presentacion.My.Resources.Resources.I256x256_image_capture
        Me.UcPbImage.Location = New System.Drawing.Point(7, 7)
        Me.UcPbImage.Name = "UcPbImage"
        Me.UcPbImage.Size = New System.Drawing.Size(186, 186)
        Me.UcPbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.UcPbImage.TabIndex = 0
        Me.UcPbImage.TabStop = False
        '
        'UCImagen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UcPnBase)
        Me.Name = "UCImagen"
        Me.Size = New System.Drawing.Size(200, 200)
        Me.UcPnBase.ResumeLayout(False)
        CType(Me.UcPbImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents UcPnBase As System.Windows.Forms.Panel
    Friend WithEvents UcPbImage As System.Windows.Forms.PictureBox

End Class
