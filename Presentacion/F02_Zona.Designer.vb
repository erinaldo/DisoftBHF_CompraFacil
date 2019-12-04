<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F02_Zona
    Inherits Modelo.ModeloF02_cd

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
        Dim CbZona_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F02_Zona))
        Dim CbProvincia_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim CbCiudad_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.TableLayoutPanelBase = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanelBase2 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupPanelDatosGenerales = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelExDatosGenerales = New DevComponents.DotNetBar.PanelEx()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtAddZona = New DevComponents.DotNetBar.ButtonX()
        Me.BtAddProvincia = New DevComponents.DotNetBar.ButtonX()
        Me.BtAddCiudad = New DevComponents.DotNetBar.ButtonX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CbZona = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.CbProvincia = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.CbCiudad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.TbCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TbColor = New System.Windows.Forms.TextBox()
        Me.GroupPanelPersonal = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.SuperTabControlPersonal = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgjRepartidor = New Janus.Windows.GridEX.GridEX()
        Me.SuperTabItemRepartidor = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgjPrevendedor = New Janus.Windows.GridEX.GridEX()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.GroupPanelMapa = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelExMapa = New DevComponents.DotNetBar.PanelEx()
        Me.PanelExZoom = New DevComponents.DotNetBar.PanelEx()
        Me.BtZoomMenos = New DevComponents.DotNetBar.ButtonX()
        Me.BtZoomMas = New DevComponents.DotNetBar.ButtonX()
        Me.BtMarcarZona = New DevComponents.DotNetBar.ButtonX()
        Me.GmMapa = New GMap.NET.WindowsForms.GMapControl()
        Me.DgjBusqueda = New Janus.Windows.GridEX.GridEX()
        Me.GroupPanelBusqueda = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ColorDialogZona = New System.Windows.Forms.ColorDialog()
        CType(Me.MSuperTabControlPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MSuperTabControlPrincipal.SuspendLayout()
        Me.MSuperTabControlPanelBusqueda.SuspendLayout()
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
        Me.TableLayoutPanelBase.SuspendLayout()
        Me.TableLayoutPanelBase2.SuspendLayout()
        Me.GroupPanelDatosGenerales.SuspendLayout()
        Me.PanelExDatosGenerales.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.CbZona, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbProvincia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbCiudad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanelPersonal.SuspendLayout()
        CType(Me.SuperTabControlPersonal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPersonal.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.dgjRepartidor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.dgjPrevendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanelMapa.SuspendLayout()
        Me.PanelExMapa.SuspendLayout()
        Me.PanelExZoom.SuspendLayout()
        CType(Me.DgjBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanelBusqueda.SuspendLayout()
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
        Me.MSuperTabControlPrincipal.SelectedTabIndex = 1
        Me.MSuperTabControlPrincipal.Size = New System.Drawing.Size(884, 455)
        Me.MSuperTabControlPrincipal.Controls.SetChildIndex(Me.MSuperTabControlPanelRegistro, 0)
        Me.MSuperTabControlPrincipal.Controls.SetChildIndex(Me.MSuperTabControlPanelBusqueda, 0)
        '
        'MSuperTabControlPanelBusqueda
        '
        Me.MSuperTabControlPanelBusqueda.Controls.Add(Me.GroupPanelBusqueda)
        Me.MSuperTabControlPanelBusqueda.Size = New System.Drawing.Size(942, 455)
        '
        'MSuperTabControlPanelRegistro
        '
        Me.MSuperTabControlPanelRegistro.Controls.Add(Me.TableLayoutPanelBase)
        Me.MSuperTabControlPanelRegistro.Size = New System.Drawing.Size(842, 455)
        Me.MSuperTabControlPanelRegistro.Controls.SetChildIndex(Me.MPnUsuario, 0)
        Me.MSuperTabControlPanelRegistro.Controls.SetChildIndex(Me.TableLayoutPanelBase, 0)
        '
        'MPnSuperior
        '
        Me.MPnSuperior.Size = New System.Drawing.Size(884, 70)
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
        Me.MPnInferior.Size = New System.Drawing.Size(884, 36)
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
        Me.MPanelToolBarUsuario.Location = New System.Drawing.Point(684, 0)
        '
        'MTbUsuario
        '
        Me.MTbUsuario.ReadOnly = True
        Me.MTbUsuario.Text = "DEFAULT"
        '
        'MBtUltimo
        '
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
        'MBtEliminar
        '
        '
        'MBtModificar
        '
        '
        'MBtNuevo
        '
        '
        'MPanelToolBarImprimir
        '
        Me.MPanelToolBarImprimir.Location = New System.Drawing.Point(804, 0)
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
        'TableLayoutPanelBase
        '
        Me.TableLayoutPanelBase.ColumnCount = 2
        Me.TableLayoutPanelBase.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanelBase.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanelBase.Controls.Add(Me.TableLayoutPanelBase2, 0, 0)
        Me.TableLayoutPanelBase.Controls.Add(Me.GroupPanelMapa, 1, 0)
        Me.TableLayoutPanelBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelBase.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelBase.Name = "TableLayoutPanelBase"
        Me.TableLayoutPanelBase.RowCount = 1
        Me.TableLayoutPanelBase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelBase.Size = New System.Drawing.Size(842, 455)
        Me.TableLayoutPanelBase.TabIndex = 29
        '
        'TableLayoutPanelBase2
        '
        Me.TableLayoutPanelBase2.ColumnCount = 1
        Me.TableLayoutPanelBase2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelBase2.Controls.Add(Me.GroupPanelDatosGenerales, 0, 0)
        Me.TableLayoutPanelBase2.Controls.Add(Me.GroupPanelPersonal, 0, 1)
        Me.TableLayoutPanelBase2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelBase2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanelBase2.Name = "TableLayoutPanelBase2"
        Me.TableLayoutPanelBase2.RowCount = 2
        Me.TableLayoutPanelBase2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanelBase2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanelBase2.Size = New System.Drawing.Size(246, 449)
        Me.TableLayoutPanelBase2.TabIndex = 0
        '
        'GroupPanelDatosGenerales
        '
        Me.GroupPanelDatosGenerales.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelDatosGenerales.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelDatosGenerales.Controls.Add(Me.PanelExDatosGenerales)
        Me.GroupPanelDatosGenerales.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelDatosGenerales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelDatosGenerales.Location = New System.Drawing.Point(3, 3)
        Me.GroupPanelDatosGenerales.Name = "GroupPanelDatosGenerales"
        Me.GroupPanelDatosGenerales.Size = New System.Drawing.Size(240, 173)
        '
        '
        '
        Me.GroupPanelDatosGenerales.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanelDatosGenerales.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanelDatosGenerales.Style.BackColorGradientAngle = 90
        Me.GroupPanelDatosGenerales.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatosGenerales.Style.BorderBottomWidth = 1
        Me.GroupPanelDatosGenerales.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelDatosGenerales.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatosGenerales.Style.BorderLeftWidth = 1
        Me.GroupPanelDatosGenerales.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatosGenerales.Style.BorderRightWidth = 1
        Me.GroupPanelDatosGenerales.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatosGenerales.Style.BorderTopWidth = 1
        Me.GroupPanelDatosGenerales.Style.CornerDiameter = 4
        Me.GroupPanelDatosGenerales.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelDatosGenerales.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelDatosGenerales.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelDatosGenerales.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelDatosGenerales.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelDatosGenerales.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelDatosGenerales.TabIndex = 0
        Me.GroupPanelDatosGenerales.Text = "DATOS GENERALES"
        '
        'PanelExDatosGenerales
        '
        Me.PanelExDatosGenerales.AutoScroll = True
        Me.PanelExDatosGenerales.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelExDatosGenerales.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelExDatosGenerales.Controls.Add(Me.GroupBox1)
        Me.PanelExDatosGenerales.Controls.Add(Me.TbCodigo)
        Me.PanelExDatosGenerales.Controls.Add(Me.Label1)
        Me.PanelExDatosGenerales.Controls.Add(Me.TbColor)
        Me.PanelExDatosGenerales.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelExDatosGenerales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelExDatosGenerales.Location = New System.Drawing.Point(0, 0)
        Me.PanelExDatosGenerales.Name = "PanelExDatosGenerales"
        Me.PanelExDatosGenerales.Size = New System.Drawing.Size(234, 152)
        Me.PanelExDatosGenerales.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelExDatosGenerales.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PanelExDatosGenerales.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PanelExDatosGenerales.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelExDatosGenerales.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelExDatosGenerales.Style.GradientAngle = 90
        Me.PanelExDatosGenerales.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtAddZona)
        Me.GroupBox1.Controls.Add(Me.BtAddProvincia)
        Me.GroupBox1.Controls.Add(Me.BtAddCiudad)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CbZona)
        Me.GroupBox1.Controls.Add(Me.CbProvincia)
        Me.GroupBox1.Controls.Add(Me.CbCiudad)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(338, 105)
        Me.GroupBox1.TabIndex = 113
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Zona"
        '
        'BtAddZona
        '
        Me.BtAddZona.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtAddZona.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtAddZona.Image = Global.Presentacion.My.Resources.Resources.ADICIONAR
        Me.BtAddZona.ImageFixedSize = New System.Drawing.Size(35, 35)
        Me.BtAddZona.Location = New System.Drawing.Point(238, 64)
        Me.BtAddZona.Name = "BtAddZona"
        Me.BtAddZona.Size = New System.Drawing.Size(40, 40)
        Me.BtAddZona.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtAddZona.TabIndex = 8
        '
        'BtAddProvincia
        '
        Me.BtAddProvincia.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtAddProvincia.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtAddProvincia.Image = Global.Presentacion.My.Resources.Resources.ADICIONAR
        Me.BtAddProvincia.ImageFixedSize = New System.Drawing.Size(35, 35)
        Me.BtAddProvincia.Location = New System.Drawing.Point(238, 34)
        Me.BtAddProvincia.Name = "BtAddProvincia"
        Me.BtAddProvincia.Size = New System.Drawing.Size(40, 40)
        Me.BtAddProvincia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtAddProvincia.TabIndex = 7
        '
        'BtAddCiudad
        '
        Me.BtAddCiudad.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtAddCiudad.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtAddCiudad.Image = Global.Presentacion.My.Resources.Resources.ADICIONAR
        Me.BtAddCiudad.ImageFixedSize = New System.Drawing.Size(35, 35)
        Me.BtAddCiudad.Location = New System.Drawing.Point(238, 6)
        Me.BtAddCiudad.Name = "BtAddCiudad"
        Me.BtAddCiudad.Size = New System.Drawing.Size(40, 40)
        Me.BtAddCiudad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtAddCiudad.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 17)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Zona:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Provincia:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Ciudad:"
        '
        'CbZona
        '
        CbZona_DesignTimeLayout.LayoutString = resources.GetString("CbZona_DesignTimeLayout.LayoutString")
        Me.CbZona.DesignTimeLayout = CbZona_DesignTimeLayout
        Me.CbZona.Location = New System.Drawing.Point(82, 72)
        Me.CbZona.Name = "CbZona"
        Me.CbZona.SelectedIndex = -1
        Me.CbZona.SelectedItem = Nothing
        Me.CbZona.Size = New System.Drawing.Size(150, 23)
        Me.CbZona.TabIndex = 2
        '
        'CbProvincia
        '
        CbProvincia_DesignTimeLayout.LayoutString = resources.GetString("CbProvincia_DesignTimeLayout.LayoutString")
        Me.CbProvincia.DesignTimeLayout = CbProvincia_DesignTimeLayout
        Me.CbProvincia.Location = New System.Drawing.Point(82, 43)
        Me.CbProvincia.Name = "CbProvincia"
        Me.CbProvincia.SelectedIndex = -1
        Me.CbProvincia.SelectedItem = Nothing
        Me.CbProvincia.Size = New System.Drawing.Size(150, 23)
        Me.CbProvincia.TabIndex = 1
        '
        'CbCiudad
        '
        CbCiudad_DesignTimeLayout.LayoutString = resources.GetString("CbCiudad_DesignTimeLayout.LayoutString")
        Me.CbCiudad.DesignTimeLayout = CbCiudad_DesignTimeLayout
        Me.CbCiudad.Location = New System.Drawing.Point(82, 14)
        Me.CbCiudad.Name = "CbCiudad"
        Me.CbCiudad.SelectedIndex = -1
        Me.CbCiudad.SelectedItem = Nothing
        Me.CbCiudad.Size = New System.Drawing.Size(150, 23)
        Me.CbCiudad.TabIndex = 0
        '
        'TbCodigo
        '
        Me.TbCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbCodigo.Location = New System.Drawing.Point(54, 6)
        Me.TbCodigo.Name = "TbCodigo"
        Me.TbCodigo.Size = New System.Drawing.Size(100, 23)
        Me.TbCodigo.TabIndex = 114
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 17)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "ID:"
        '
        'TbColor
        '
        Me.TbColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbColor.Location = New System.Drawing.Point(160, 6)
        Me.TbColor.Name = "TbColor"
        Me.TbColor.Size = New System.Drawing.Size(100, 23)
        Me.TbColor.TabIndex = 116
        '
        'GroupPanelPersonal
        '
        Me.GroupPanelPersonal.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelPersonal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelPersonal.Controls.Add(Me.SuperTabControlPersonal)
        Me.GroupPanelPersonal.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelPersonal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelPersonal.Location = New System.Drawing.Point(3, 182)
        Me.GroupPanelPersonal.Name = "GroupPanelPersonal"
        Me.GroupPanelPersonal.Size = New System.Drawing.Size(240, 264)
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
        Me.GroupPanelPersonal.TabIndex = 1
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
        Me.SuperTabControlPersonal.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControlPersonal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPersonal.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPersonal.Name = "SuperTabControlPersonal"
        Me.SuperTabControlPersonal.ReorderTabsEnabled = True
        Me.SuperTabControlPersonal.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControlPersonal.SelectedTabIndex = 1
        Me.SuperTabControlPersonal.Size = New System.Drawing.Size(234, 243)
        Me.SuperTabControlPersonal.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControlPersonal.TabIndex = 118
        Me.SuperTabControlPersonal.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItemRepartidor, Me.SuperTabItem2})
        Me.SuperTabControlPersonal.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.SuperTabControlPersonal.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.dgjRepartidor)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 23)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(234, 220)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItemRepartidor
        '
        'dgjRepartidor
        '
        Me.dgjRepartidor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgjRepartidor.Location = New System.Drawing.Point(0, 0)
        Me.dgjRepartidor.Name = "dgjRepartidor"
        Me.dgjRepartidor.Size = New System.Drawing.Size(234, 220)
        Me.dgjRepartidor.TabIndex = 117
        '
        'SuperTabItemRepartidor
        '
        Me.SuperTabItemRepartidor.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItemRepartidor.GlobalItem = False
        Me.SuperTabItemRepartidor.Name = "SuperTabItemRepartidor"
        Me.SuperTabItemRepartidor.Text = "Repartidor"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.dgjPrevendedor)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(234, 218)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'dgjPrevendedor
        '
        Me.dgjPrevendedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgjPrevendedor.Location = New System.Drawing.Point(0, 0)
        Me.dgjPrevendedor.Name = "dgjPrevendedor"
        Me.dgjPrevendedor.Size = New System.Drawing.Size(234, 218)
        Me.dgjPrevendedor.TabIndex = 118
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Pre-Vendedor"
        '
        'GroupPanelMapa
        '
        Me.GroupPanelMapa.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelMapa.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelMapa.Controls.Add(Me.PanelExMapa)
        Me.GroupPanelMapa.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelMapa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelMapa.Location = New System.Drawing.Point(255, 3)
        Me.GroupPanelMapa.Name = "GroupPanelMapa"
        Me.GroupPanelMapa.Size = New System.Drawing.Size(584, 449)
        '
        '
        '
        Me.GroupPanelMapa.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanelMapa.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanelMapa.Style.BackColorGradientAngle = 90
        Me.GroupPanelMapa.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelMapa.Style.BorderBottomWidth = 1
        Me.GroupPanelMapa.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelMapa.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelMapa.Style.BorderLeftWidth = 1
        Me.GroupPanelMapa.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelMapa.Style.BorderRightWidth = 1
        Me.GroupPanelMapa.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelMapa.Style.BorderTopWidth = 1
        Me.GroupPanelMapa.Style.CornerDiameter = 4
        Me.GroupPanelMapa.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelMapa.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelMapa.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelMapa.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelMapa.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelMapa.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelMapa.TabIndex = 1
        Me.GroupPanelMapa.Text = "MAPA"
        '
        'PanelExMapa
        '
        Me.PanelExMapa.AutoScroll = True
        Me.PanelExMapa.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelExMapa.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelExMapa.Controls.Add(Me.PanelExZoom)
        Me.PanelExMapa.Controls.Add(Me.BtMarcarZona)
        Me.PanelExMapa.Controls.Add(Me.GmMapa)
        Me.PanelExMapa.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelExMapa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelExMapa.Location = New System.Drawing.Point(0, 0)
        Me.PanelExMapa.Name = "PanelExMapa"
        Me.PanelExMapa.Size = New System.Drawing.Size(578, 428)
        Me.PanelExMapa.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelExMapa.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PanelExMapa.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PanelExMapa.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelExMapa.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelExMapa.Style.GradientAngle = 90
        Me.PanelExMapa.TabIndex = 7
        '
        'PanelExZoom
        '
        Me.PanelExZoom.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelExZoom.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelExZoom.Controls.Add(Me.BtZoomMenos)
        Me.PanelExZoom.Controls.Add(Me.BtZoomMas)
        Me.PanelExZoom.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelExZoom.Location = New System.Drawing.Point(14, 4)
        Me.PanelExZoom.Name = "PanelExZoom"
        Me.PanelExZoom.Size = New System.Drawing.Size(46, 87)
        Me.PanelExZoom.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelExZoom.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelExZoom.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelExZoom.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelExZoom.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelExZoom.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelExZoom.Style.GradientAngle = 90
        Me.PanelExZoom.TabIndex = 115
        '
        'BtZoomMenos
        '
        Me.BtZoomMenos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtZoomMenos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtZoomMenos.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.BtZoomMenos.Image = Global.Presentacion.My.Resources.Resources.ZOOM_MENOS_ORI
        Me.BtZoomMenos.ImageFixedSize = New System.Drawing.Size(40, 40)
        Me.BtZoomMenos.Location = New System.Drawing.Point(3, 45)
        Me.BtZoomMenos.Name = "BtZoomMenos"
        Me.BtZoomMenos.Size = New System.Drawing.Size(40, 40)
        Me.BtZoomMenos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtZoomMenos.TabIndex = 1
        '
        'BtZoomMas
        '
        Me.BtZoomMas.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtZoomMas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtZoomMas.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.BtZoomMas.Image = Global.Presentacion.My.Resources.Resources.ZOOM_MAS_ORI
        Me.BtZoomMas.ImageFixedSize = New System.Drawing.Size(40, 40)
        Me.BtZoomMas.Location = New System.Drawing.Point(3, 3)
        Me.BtZoomMas.Name = "BtZoomMas"
        Me.BtZoomMas.Size = New System.Drawing.Size(40, 40)
        Me.BtZoomMas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtZoomMas.TabIndex = 0
        '
        'BtMarcarZona
        '
        Me.BtMarcarZona.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtMarcarZona.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.BtMarcarZona.Image = Global.Presentacion.My.Resources.Resources.MARCARZONA
        Me.BtMarcarZona.ImageFixedSize = New System.Drawing.Size(52, 52)
        Me.BtMarcarZona.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtMarcarZona.Location = New System.Drawing.Point(76, 4)
        Me.BtMarcarZona.Name = "BtMarcarZona"
        Me.BtMarcarZona.Size = New System.Drawing.Size(86, 73)
        Me.BtMarcarZona.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtMarcarZona.TabIndex = 116
        Me.BtMarcarZona.Text = "Marcar Zona"
        '
        'GmMapa
        '
        Me.GmMapa.Bearing = 0!
        Me.GmMapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GmMapa.CanDragMap = True
        Me.GmMapa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GmMapa.EmptyTileColor = System.Drawing.Color.Navy
        Me.GmMapa.GrayScaleMode = False
        Me.GmMapa.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
        Me.GmMapa.LevelsKeepInMemmory = 5
        Me.GmMapa.Location = New System.Drawing.Point(0, 0)
        Me.GmMapa.MarkersEnabled = True
        Me.GmMapa.MaxZoom = 2
        Me.GmMapa.MinZoom = 2
        Me.GmMapa.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
        Me.GmMapa.Name = "GmMapa"
        Me.GmMapa.NegativeMode = False
        Me.GmMapa.PolygonsEnabled = True
        Me.GmMapa.RetryLoadTile = 0
        Me.GmMapa.RoutesEnabled = True
        Me.GmMapa.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
        Me.GmMapa.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.GmMapa.ShowTileGridLines = False
        Me.GmMapa.Size = New System.Drawing.Size(578, 428)
        Me.GmMapa.TabIndex = 1
        Me.GmMapa.Zoom = 0R
        '
        'DgjBusqueda
        '
        Me.DgjBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgjBusqueda.Location = New System.Drawing.Point(5, 5)
        Me.DgjBusqueda.Name = "DgjBusqueda"
        Me.DgjBusqueda.Size = New System.Drawing.Size(926, 424)
        Me.DgjBusqueda.TabIndex = 0
        '
        'GroupPanelBusqueda
        '
        Me.GroupPanelBusqueda.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelBusqueda.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelBusqueda.Controls.Add(Me.DgjBusqueda)
        Me.GroupPanelBusqueda.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanelBusqueda.Name = "GroupPanelBusqueda"
        Me.GroupPanelBusqueda.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupPanelBusqueda.Size = New System.Drawing.Size(942, 455)
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
        Me.GroupPanelBusqueda.TabIndex = 1
        Me.GroupPanelBusqueda.Text = "BUSQUEDA DATOS"
        '
        'F02_Zona
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Name = "F02_Zona"
        Me.Text = "F01_Zona"
        Me.Controls.SetChildIndex(Me.MPnSuperior, 0)
        Me.Controls.SetChildIndex(Me.MPnInferior, 0)
        Me.Controls.SetChildIndex(Me.MSuperTabControlPrincipal, 0)
        CType(Me.MSuperTabControlPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MSuperTabControlPrincipal.ResumeLayout(False)
        Me.MSuperTabControlPanelBusqueda.ResumeLayout(False)
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
        Me.TableLayoutPanelBase.ResumeLayout(False)
        Me.TableLayoutPanelBase2.ResumeLayout(False)
        Me.GroupPanelDatosGenerales.ResumeLayout(False)
        Me.PanelExDatosGenerales.ResumeLayout(False)
        Me.PanelExDatosGenerales.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.CbZona, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbProvincia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbCiudad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanelPersonal.ResumeLayout(False)
        CType(Me.SuperTabControlPersonal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPersonal.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        CType(Me.dgjRepartidor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.dgjPrevendedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanelMapa.ResumeLayout(False)
        Me.PanelExMapa.ResumeLayout(False)
        Me.PanelExZoom.ResumeLayout(False)
        CType(Me.DgjBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanelBusqueda.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanelBase As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanelBase2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupPanelBusqueda As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents DgjBusqueda As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupPanelDatosGenerales As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanelPersonal As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanelMapa As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PanelExDatosGenerales As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PanelExMapa As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtAddZona As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtAddProvincia As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtAddCiudad As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CbZona As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents CbProvincia As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents CbCiudad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents TbCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TbColor As System.Windows.Forms.TextBox
    Friend WithEvents PanelExZoom As DevComponents.DotNetBar.PanelEx
    Friend WithEvents BtZoomMenos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtZoomMas As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtMarcarZona As DevComponents.DotNetBar.ButtonX
    Protected WithEvents GmMapa As GMap.NET.WindowsForms.GMapControl
    Friend WithEvents ColorDialogZona As System.Windows.Forms.ColorDialog
    Friend WithEvents dgjRepartidor As Janus.Windows.GridEX.GridEX
    Friend WithEvents SuperTabControlPersonal As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItemRepartidor As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents dgjPrevendedor As Janus.Windows.GridEX.GridEX
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
End Class
