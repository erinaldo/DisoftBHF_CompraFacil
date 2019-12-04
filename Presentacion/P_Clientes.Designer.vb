<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class P_Clientes
    Inherits Modelo.ModeloHor

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Cbx_Zona_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim Cbx_TipoDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim Cbx_Categoria_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(P_Clientes))
        Dim CbFiltroResumenEquipo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Codigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Nombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_NroDoc = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Direccion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Telefono1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Telefono2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.GridCell1 = New DevComponents.DotNetBar.SuperGrid.GridCell()
        Me.GridCell2 = New DevComponents.DotNetBar.SuperGrid.GridCell()
        Me.Hl_Clientes = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.Txt_Obs = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Dt1FechaNac = New System.Windows.Forms.DateTimePicker()
        Me.Cbx_Zona = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Cbx_TipoDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Cbx_Categoria = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Dt2FechaIng = New System.Windows.Forms.DateTimePicker()
        Me.DtiUltimoPedido = New System.Windows.Forms.DateTimePicker()
        Me.DtiUltimaVenta = New System.Windows.Forms.DateTimePicker()
        Me.Bt1AddEquipos = New DevComponents.DotNetBar.ButtonX()
        Me.Dgs_Equipos = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.Cms1Equipos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Tsmi1Eliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridCell3 = New DevComponents.DotNetBar.SuperGrid.GridCell()
        Me.GridCell4 = New DevComponents.DotNetBar.SuperGrid.GridCell()
        Me.GridCell5 = New DevComponents.DotNetBar.SuperGrid.GridCell()
        Me.GridCell6 = New DevComponents.DotNetBar.SuperGrid.GridCell()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Tb11Nit = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Tb10NombreFactura = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.Gp1Estado = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Rb3Devuelto = New System.Windows.Forms.RadioButton()
        Me.Rb2Pasivo = New System.Windows.Forms.RadioButton()
        Me.Rb1Activo = New System.Windows.Forms.RadioButton()
        Me.Bt2Confirmar = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.Sb_Eventual = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelEx7 = New DevComponents.DotNetBar.PanelEx()
        Me.PanelEx6 = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.TbiCantEntrante = New DevComponents.Editors.IntegerInput()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.TbiCantSaliente = New DevComponents.Editors.IntegerInput()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.TbiCantSaldo = New DevComponents.Editors.IntegerInput()
        Me.CbFiltroResumenEquipo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Dgj1Busqueda = New Janus.Windows.GridEX.GridEX()
        Me.Rl1Accion = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.FlyoutUsuario = New DevComponents.DotNetBar.Controls.Flyout(Me.components)
        Me.StcSugerenciaUbicacion = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.DgjSugerencias = New Janus.Windows.GridEX.GridEX()
        Me.StiFiltroCliente = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Gmc_Cliente = New GMap.NET.WindowsForms.GMapControl()
        Me.Gp_Datos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelUsuario = New System.Windows.Forms.Panel()
        Me.lbHora = New System.Windows.Forms.Label()
        Me.lbFecha = New System.Windows.Forms.Label()
        Me.lbUsuario = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btnx_ChekGetPoint = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Longitud = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Latitud = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.StiUbicacion = New DevComponents.DotNetBar.SuperTabItem()
        Me.BtActualizar = New DevComponents.DotNetBar.ButtonX()
        Me.CpActCliente = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.TiCliente = New System.Windows.Forms.Timer(Me.components)
        Me.BtPasarCliente = New DevComponents.DotNetBar.ButtonX()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        CType(Me.BubbleBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BubbleBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx2.SuspendLayout()
        Me.PanelEx3.SuspendLayout()
        Me.PanelEx4.SuspendLayout()
        CType(Me.BubbleBar4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BubbleBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BubbleBar5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx5.SuspendLayout()
        CType(Me.Cbx_Zona, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbx_TipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbx_Categoria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cms1Equipos.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.Gp1Estado.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.PanelEx7.SuspendLayout()
        Me.PanelEx6.SuspendLayout()
        CType(Me.TbiCantEntrante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbiCantSaliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbiCantSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbFiltroResumenEquipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgj1Busqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StcSugerenciaUbicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StcSugerenciaUbicacion.SuspendLayout()
        Me.SuperTabControlPanel3.SuspendLayout()
        CType(Me.DgjSugerencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel4.SuspendLayout()
        Me.GroupPanel4.SuspendLayout()
        Me.Gp_Datos.SuspendLayout()
        Me.PanelUsuario.SuspendLayout()
        Me.SuspendLayout()
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
        Me.SuperTabControl1.SelectedTabIndex = 1
        Me.SuperTabControl1.Size = New System.Drawing.Size(1084, 611)
        Me.SuperTabControl1.Controls.SetChildIndex(Me.SuperTabControlPanel1, 0)
        Me.SuperTabControl1.Controls.SetChildIndex(Me.SuperTabControlPanel2, 0)
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.Dgj1Busqueda)
        Me.SuperTabControlPanel2.Padding = New System.Windows.Forms.Padding(5)
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(1084, 586)
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(1084, 586)
        Me.SuperTabControlPanel1.Controls.SetChildIndex(Me.PanelEx1, 0)
        Me.SuperTabControlPanel1.Controls.SetChildIndex(Me.PanelEx2, 0)
        Me.SuperTabControlPanel1.Controls.SetChildIndex(Me.PanelEx3, 0)
        Me.SuperTabControlPanel1.Controls.SetChildIndex(Me.PanelEx4, 0)
        '
        'PanelEx1
        '
        Me.PanelEx1.Controls.Add(Me.BtPasarCliente)
        Me.PanelEx1.Controls.Add(Me.CpActCliente)
        Me.PanelEx1.Controls.Add(Me.BtActualizar)
        Me.PanelEx1.Controls.Add(Me.Rl1Accion)
        Me.PanelEx1.Size = New System.Drawing.Size(1084, 64)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.Blue
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.Blue
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.Controls.SetChildIndex(Me.BubbleBar1, 0)
        Me.PanelEx1.Controls.SetChildIndex(Me.Rl1Accion, 0)
        Me.PanelEx1.Controls.SetChildIndex(Me.BtActualizar, 0)
        Me.PanelEx1.Controls.SetChildIndex(Me.CpActCliente, 0)
        Me.PanelEx1.Controls.SetChildIndex(Me.BubbleBar2, 0)
        Me.PanelEx1.Controls.SetChildIndex(Me.BtPasarCliente, 0)
        '
        'BubbleBar1
        '
        '
        '
        '
        Me.BubbleBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.BubbleBar1.ButtonBackAreaStyle.BackColor = System.Drawing.Color.Transparent
        Me.BubbleBar1.ButtonBackAreaStyle.BorderBottomWidth = 1
        Me.BubbleBar1.ButtonBackAreaStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BubbleBar1.ButtonBackAreaStyle.BorderLeftWidth = 1
        Me.BubbleBar1.ButtonBackAreaStyle.BorderRightWidth = 1
        Me.BubbleBar1.ButtonBackAreaStyle.BorderTopWidth = 1
        Me.BubbleBar1.ButtonBackAreaStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BubbleBar1.ButtonBackAreaStyle.PaddingBottom = 3
        Me.BubbleBar1.ButtonBackAreaStyle.PaddingLeft = 3
        Me.BubbleBar1.ButtonBackAreaStyle.PaddingRight = 3
        Me.BubbleBar1.ButtonBackAreaStyle.PaddingTop = 3
        Me.BubbleBar1.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BubbleBar1.SelectedTabColors.BorderColor = System.Drawing.Color.Black
        Me.BubbleBar1.TabIndex = 0
        '
        'BBtn_Modificar
        '
        '
        'BBtn_Eliminar
        '
        '
        'BBtn_Grabar
        '
        Me.BBtn_Grabar.Enabled = False
        '
        'BBtn_Cancelar
        '
        Me.BBtn_Cancelar.TooltipText = "SALIR"
        '
        'BubbleBar2
        '
        '
        '
        '
        Me.BubbleBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.BubbleBar2.ButtonBackAreaStyle.BackColor = System.Drawing.Color.Transparent
        Me.BubbleBar2.ButtonBackAreaStyle.BorderBottomWidth = 1
        Me.BubbleBar2.ButtonBackAreaStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BubbleBar2.ButtonBackAreaStyle.BorderLeftWidth = 1
        Me.BubbleBar2.ButtonBackAreaStyle.BorderRightWidth = 1
        Me.BubbleBar2.ButtonBackAreaStyle.BorderTopWidth = 1
        Me.BubbleBar2.ButtonBackAreaStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BubbleBar2.ButtonBackAreaStyle.PaddingBottom = 3
        Me.BubbleBar2.ButtonBackAreaStyle.PaddingLeft = 3
        Me.BubbleBar2.ButtonBackAreaStyle.PaddingRight = 3
        Me.BubbleBar2.ButtonBackAreaStyle.PaddingTop = 3
        Me.BubbleBar2.Location = New System.Drawing.Point(870, 0)
        Me.BubbleBar2.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BubbleBar2.SelectedTabColors.BorderColor = System.Drawing.Color.Black
        Me.BubbleBar2.TabIndex = 1
        '
        'PanelEx2
        '
        Me.PanelEx2.Location = New System.Drawing.Point(0, 550)
        Me.PanelEx2.Size = New System.Drawing.Size(1084, 36)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.Color = System.Drawing.Color.Blue
        Me.PanelEx2.Style.BackColor2.Color = System.Drawing.Color.Blue
        Me.PanelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.Controls.SetChildIndex(Me.BubbleBar3, 0)
        Me.PanelEx2.Controls.SetChildIndex(Me.PanelEx5, 0)
        Me.PanelEx2.Controls.SetChildIndex(Me.BubbleBar4, 0)
        Me.PanelEx2.Controls.SetChildIndex(Me.Txt_Paginacion, 0)
        '
        'PanelEx3
        '
        Me.PanelEx3.Controls.Add(Me.StcSugerenciaUbicacion)
        Me.PanelEx3.Controls.Add(Me.GroupPanel1)
        Me.PanelEx3.Size = New System.Drawing.Size(1084, 309)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 0
        '
        'PanelEx4
        '
        Me.PanelEx4.Controls.Add(Me.GroupPanel2)
        Me.PanelEx4.Location = New System.Drawing.Point(0, 373)
        Me.PanelEx4.Padding = New System.Windows.Forms.Padding(5)
        Me.PanelEx4.Size = New System.Drawing.Size(1084, 177)
        Me.PanelEx4.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx4.Style.GradientAngle = 90
        '
        'BubbleBar4
        '
        '
        '
        '
        Me.BubbleBar4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.BubbleBar4.ButtonBackAreaStyle.BackColor = System.Drawing.Color.Transparent
        Me.BubbleBar4.ButtonBackAreaStyle.BorderBottomWidth = 1
        Me.BubbleBar4.ButtonBackAreaStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BubbleBar4.ButtonBackAreaStyle.BorderLeftWidth = 1
        Me.BubbleBar4.ButtonBackAreaStyle.BorderRightWidth = 1
        Me.BubbleBar4.ButtonBackAreaStyle.BorderTopWidth = 1
        Me.BubbleBar4.ButtonBackAreaStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BubbleBar4.ButtonBackAreaStyle.PaddingBottom = 3
        Me.BubbleBar4.ButtonBackAreaStyle.PaddingLeft = 3
        Me.BubbleBar4.ButtonBackAreaStyle.PaddingRight = 3
        Me.BubbleBar4.ButtonBackAreaStyle.PaddingTop = 3
        Me.BubbleBar4.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BubbleBar4.SelectedTabColors.BorderColor = System.Drawing.Color.Black
        Me.BubbleBar4.TabIndex = 1
        '
        'Txt_Paginacion
        '
        Me.Txt_Paginacion.TabIndex = 2
        '
        'BBtn_Imprimir
        '
        Me.BBtn_Imprimir.Image = Global.Presentacion.My.Resources.Resources.BUSQUEDA
        Me.BBtn_Imprimir.ImageLarge = Global.Presentacion.My.Resources.Resources.BUSQUEDA
        Me.BBtn_Imprimir.TooltipText = "BUSCAR"
        '
        'BubbleBar3
        '
        '
        '
        '
        Me.BubbleBar3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.BubbleBar3.ButtonBackAreaStyle.BackColor = System.Drawing.Color.Transparent
        Me.BubbleBar3.ButtonBackAreaStyle.BorderBottomWidth = 1
        Me.BubbleBar3.ButtonBackAreaStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BubbleBar3.ButtonBackAreaStyle.BorderLeftWidth = 1
        Me.BubbleBar3.ButtonBackAreaStyle.BorderRightWidth = 1
        Me.BubbleBar3.ButtonBackAreaStyle.BorderTopWidth = 1
        Me.BubbleBar3.ButtonBackAreaStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BubbleBar3.ButtonBackAreaStyle.PaddingBottom = 3
        Me.BubbleBar3.ButtonBackAreaStyle.PaddingLeft = 3
        Me.BubbleBar3.ButtonBackAreaStyle.PaddingRight = 3
        Me.BubbleBar3.ButtonBackAreaStyle.PaddingTop = 3
        Me.BubbleBar3.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BubbleBar3.SelectedTabColors.BorderColor = System.Drawing.Color.Black
        Me.BubbleBar3.TabIndex = 0
        '
        'BubbleBar5
        '
        '
        '
        '
        Me.BubbleBar5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.BubbleBar5.ButtonBackAreaStyle.BackColor = System.Drawing.Color.Transparent
        Me.BubbleBar5.ButtonBackAreaStyle.BorderBottomWidth = 1
        Me.BubbleBar5.ButtonBackAreaStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BubbleBar5.ButtonBackAreaStyle.BorderLeftWidth = 1
        Me.BubbleBar5.ButtonBackAreaStyle.BorderRightWidth = 1
        Me.BubbleBar5.ButtonBackAreaStyle.BorderTopWidth = 1
        Me.BubbleBar5.ButtonBackAreaStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BubbleBar5.ButtonBackAreaStyle.PaddingBottom = 3
        Me.BubbleBar5.ButtonBackAreaStyle.PaddingLeft = 3
        Me.BubbleBar5.ButtonBackAreaStyle.PaddingRight = 3
        Me.BubbleBar5.ButtonBackAreaStyle.PaddingTop = 3
        Me.BubbleBar5.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BubbleBar5.SelectedTabColors.BorderColor = System.Drawing.Color.Black
        Me.BubbleBar5.TabIndex = 1
        '
        'BBtn_Usuario
        '
        '
        'PanelEx5
        '
        Me.PanelEx5.Location = New System.Drawing.Point(884, 0)
        Me.PanelEx5.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx5.Style.BackColor1.Color = System.Drawing.Color.Blue
        Me.PanelEx5.Style.BackColor2.Color = System.Drawing.Color.Blue
        Me.PanelEx5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx5.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx5.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx5.Style.GradientAngle = 90
        Me.PanelEx5.TabIndex = 3
        '
        'Txt_NombreUsu
        '
        Me.Txt_NombreUsu.TabIndex = 0
        Me.Txt_NombreUsu.Text = "DEFAULT"
        '
        'BBtn_Nuevo
        '
        '
        'BBtn_Siguiente
        '
        '
        'BBtn_Ultimo
        '
        '
        'BBtn_Inicio
        '
        '
        'BBtn_Anterior
        '
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(2, 0)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(101, 23)
        Me.LabelX1.TabIndex = 9
        Me.LabelX1.Text = "CÓDIGO..........................."
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(2, 29)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(101, 23)
        Me.LabelX2.TabIndex = 10
        Me.LabelX2.Text = "NOMBRE......................"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(2, 83)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(101, 23)
        Me.LabelX3.TabIndex = 11
        Me.LabelX3.Text = "ZONA................................"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(2, 104)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(101, 23)
        Me.LabelX4.TabIndex = 12
        Me.LabelX4.Text = "TIPO DE DOC.............."
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(2, 129)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(101, 23)
        Me.LabelX5.TabIndex = 13
        Me.LabelX5.Text = "NRO DE DOC..............."
        '
        'Txt_Codigo
        '
        '
        '
        '
        Me.Txt_Codigo.Border.Class = "TextBoxBorder"
        Me.Txt_Codigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Hl_Clientes.SetHighlightOnFocus(Me.Txt_Codigo, True)
        Me.Txt_Codigo.Location = New System.Drawing.Point(95, 3)
        Me.Txt_Codigo.Name = "Txt_Codigo"
        Me.Txt_Codigo.PreventEnterBeep = True
        Me.Txt_Codigo.ReadOnly = True
        Me.Txt_Codigo.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Codigo.TabIndex = 12
        '
        'Txt_Nombre
        '
        '
        '
        '
        Me.Txt_Nombre.Border.Class = "TextBoxBorder"
        Me.Txt_Nombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Hl_Clientes.SetHighlightOnFocus(Me.Txt_Nombre, True)
        Me.Txt_Nombre.Location = New System.Drawing.Point(95, 29)
        Me.Txt_Nombre.MaxLength = 50
        Me.Txt_Nombre.Multiline = True
        Me.Txt_Nombre.Name = "Txt_Nombre"
        Me.Txt_Nombre.PreventEnterBeep = True
        Me.Txt_Nombre.Size = New System.Drawing.Size(302, 45)
        Me.Txt_Nombre.TabIndex = 0
        '
        'Txt_NroDoc
        '
        '
        '
        '
        Me.Txt_NroDoc.Border.Class = "TextBoxBorder"
        Me.Txt_NroDoc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Hl_Clientes.SetHighlightOnFocus(Me.Txt_NroDoc, True)
        Me.Txt_NroDoc.Location = New System.Drawing.Point(95, 132)
        Me.Txt_NroDoc.MaxLength = 20
        Me.Txt_NroDoc.Name = "Txt_NroDoc"
        Me.Txt_NroDoc.PreventEnterBeep = True
        Me.Txt_NroDoc.Size = New System.Drawing.Size(180, 20)
        Me.Txt_NroDoc.TabIndex = 3
        '
        'Txt_Direccion
        '
        '
        '
        '
        Me.Txt_Direccion.Border.Class = "TextBoxBorder"
        Me.Txt_Direccion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Hl_Clientes.SetHighlightOnFocus(Me.Txt_Direccion, True)
        Me.Txt_Direccion.Location = New System.Drawing.Point(95, 184)
        Me.Txt_Direccion.MaxLength = 200
        Me.Txt_Direccion.Multiline = True
        Me.Txt_Direccion.Name = "Txt_Direccion"
        Me.Txt_Direccion.PreventEnterBeep = True
        Me.Txt_Direccion.Size = New System.Drawing.Size(593, 46)
        Me.Txt_Direccion.TabIndex = 5
        '
        'Txt_Telefono1
        '
        '
        '
        '
        Me.Txt_Telefono1.Border.Class = "TextBoxBorder"
        Me.Txt_Telefono1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Hl_Clientes.SetHighlightOnFocus(Me.Txt_Telefono1, True)
        Me.Txt_Telefono1.Location = New System.Drawing.Point(484, 55)
        Me.Txt_Telefono1.MaxLength = 30
        Me.Txt_Telefono1.Name = "Txt_Telefono1"
        Me.Txt_Telefono1.PreventEnterBeep = True
        Me.Txt_Telefono1.Size = New System.Drawing.Size(120, 20)
        Me.Txt_Telefono1.TabIndex = 7
        '
        'Txt_Telefono2
        '
        '
        '
        '
        Me.Txt_Telefono2.Border.Class = "TextBoxBorder"
        Me.Txt_Telefono2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Hl_Clientes.SetHighlightOnFocus(Me.Txt_Telefono2, True)
        Me.Txt_Telefono2.Location = New System.Drawing.Point(484, 29)
        Me.Txt_Telefono2.MaxLength = 30
        Me.Txt_Telefono2.Name = "Txt_Telefono2"
        Me.Txt_Telefono2.PreventEnterBeep = True
        Me.Txt_Telefono2.Size = New System.Drawing.Size(120, 20)
        Me.Txt_Telefono2.TabIndex = 6
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(2, 184)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(85, 23)
        Me.LabelX6.TabIndex = 15
        Me.LabelX6.Text = "DIRECCIÓN......................"
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(403, 26)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(85, 23)
        Me.LabelX7.TabIndex = 16
        Me.LabelX7.Text = "TELÉFONO 1...................."
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Location = New System.Drawing.Point(403, 52)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(85, 23)
        Me.LabelX8.TabIndex = 17
        Me.LabelX8.Text = "TELÉFONO 2...................."
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Location = New System.Drawing.Point(403, 83)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(85, 23)
        Me.LabelX9.TabIndex = 18
        Me.LabelX9.Text = "CATEGORIA....................."
        '
        'GridCell1
        '
        Me.GridCell1.Value = "1"
        '
        'GridCell2
        '
        Me.GridCell2.Value = "Bien"
        '
        'Hl_Clientes
        '
        Me.Hl_Clientes.ContainerControl = Me
        '
        'Txt_Obs
        '
        '
        '
        '
        Me.Txt_Obs.Border.Class = "TextBoxBorder"
        Me.Txt_Obs.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Hl_Clientes.SetHighlightOnFocus(Me.Txt_Obs, True)
        Me.Txt_Obs.Location = New System.Drawing.Point(610, 80)
        Me.Txt_Obs.MaxLength = 150
        Me.Txt_Obs.Multiline = True
        Me.Txt_Obs.Name = "Txt_Obs"
        Me.Txt_Obs.PreventEnterBeep = True
        Me.Txt_Obs.Size = New System.Drawing.Size(211, 72)
        Me.Txt_Obs.TabIndex = 11
        '
        'Dt1FechaNac
        '
        Me.Dt1FechaNac.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Hl_Clientes.SetHighlightOnFocus(Me.Dt1FechaNac, True)
        Me.Dt1FechaNac.Location = New System.Drawing.Point(95, 158)
        Me.Dt1FechaNac.Name = "Dt1FechaNac"
        Me.Dt1FechaNac.Size = New System.Drawing.Size(120, 20)
        Me.Dt1FechaNac.TabIndex = 4
        '
        'Cbx_Zona
        '
        Cbx_Zona_DesignTimeLayout.LayoutString = resources.GetString("Cbx_Zona_DesignTimeLayout.LayoutString")
        Me.Cbx_Zona.DesignTimeLayout = Cbx_Zona_DesignTimeLayout
        Me.Hl_Clientes.SetHighlightOnFocus(Me.Cbx_Zona, True)
        Me.Cbx_Zona.Location = New System.Drawing.Point(95, 80)
        Me.Cbx_Zona.Name = "Cbx_Zona"
        Me.Cbx_Zona.SelectedIndex = -1
        Me.Cbx_Zona.SelectedItem = Nothing
        Me.Cbx_Zona.Size = New System.Drawing.Size(180, 20)
        Me.Cbx_Zona.TabIndex = 1
        '
        'Cbx_TipoDoc
        '
        Cbx_TipoDoc_DesignTimeLayout.LayoutString = resources.GetString("Cbx_TipoDoc_DesignTimeLayout.LayoutString")
        Me.Cbx_TipoDoc.DesignTimeLayout = Cbx_TipoDoc_DesignTimeLayout
        Me.Hl_Clientes.SetHighlightOnFocus(Me.Cbx_TipoDoc, True)
        Me.Cbx_TipoDoc.Location = New System.Drawing.Point(95, 106)
        Me.Cbx_TipoDoc.Name = "Cbx_TipoDoc"
        Me.Cbx_TipoDoc.SelectedIndex = -1
        Me.Cbx_TipoDoc.SelectedItem = Nothing
        Me.Cbx_TipoDoc.Size = New System.Drawing.Size(180, 20)
        Me.Cbx_TipoDoc.TabIndex = 2
        '
        'Cbx_Categoria
        '
        Cbx_Categoria_DesignTimeLayout.LayoutString = resources.GetString("Cbx_Categoria_DesignTimeLayout.LayoutString")
        Me.Cbx_Categoria.DesignTimeLayout = Cbx_Categoria_DesignTimeLayout
        Me.Hl_Clientes.SetHighlightOnFocus(Me.Cbx_Categoria, True)
        Me.Cbx_Categoria.Location = New System.Drawing.Point(484, 81)
        Me.Cbx_Categoria.Name = "Cbx_Categoria"
        Me.Cbx_Categoria.SelectedIndex = -1
        Me.Cbx_Categoria.SelectedItem = Nothing
        Me.Cbx_Categoria.Size = New System.Drawing.Size(120, 20)
        Me.Cbx_Categoria.TabIndex = 8
        '
        'Dt2FechaIng
        '
        Me.Dt2FechaIng.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Hl_Clientes.SetHighlightOnFocus(Me.Dt2FechaIng, True)
        Me.Dt2FechaIng.Location = New System.Drawing.Point(380, 158)
        Me.Dt2FechaIng.Name = "Dt2FechaIng"
        Me.Dt2FechaIng.Size = New System.Drawing.Size(120, 20)
        Me.Dt2FechaIng.TabIndex = 30
        '
        'DtiUltimoPedido
        '
        Me.DtiUltimoPedido.Enabled = False
        Me.DtiUltimoPedido.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Hl_Clientes.SetHighlightOnFocus(Me.DtiUltimoPedido, True)
        Me.DtiUltimoPedido.Location = New System.Drawing.Point(484, 3)
        Me.DtiUltimoPedido.Name = "DtiUltimoPedido"
        Me.DtiUltimoPedido.Size = New System.Drawing.Size(120, 20)
        Me.DtiUltimoPedido.TabIndex = 34
        '
        'DtiUltimaVenta
        '
        Me.DtiUltimaVenta.Enabled = False
        Me.DtiUltimaVenta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Hl_Clientes.SetHighlightOnFocus(Me.DtiUltimaVenta, True)
        Me.DtiUltimaVenta.Location = New System.Drawing.Point(694, 3)
        Me.DtiUltimaVenta.Name = "DtiUltimaVenta"
        Me.DtiUltimaVenta.Size = New System.Drawing.Size(127, 20)
        Me.DtiUltimaVenta.TabIndex = 36
        '
        'Bt1AddEquipos
        '
        Me.Bt1AddEquipos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Bt1AddEquipos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Bt1AddEquipos.ImageFixedSize = New System.Drawing.Size(30, 50)
        Me.Bt1AddEquipos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.Bt1AddEquipos.Location = New System.Drawing.Point(3, 8)
        Me.Bt1AddEquipos.Name = "Bt1AddEquipos"
        Me.Bt1AddEquipos.Size = New System.Drawing.Size(120, 40)
        Me.Bt1AddEquipos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bt1AddEquipos.TabIndex = 0
        Me.Bt1AddEquipos.Text = "Add Registro"
        '
        'Dgs_Equipos
        '
        Me.Dgs_Equipos.ContextMenuStrip = Me.Cms1Equipos
        Me.Dgs_Equipos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgs_Equipos.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.Dgs_Equipos.Location = New System.Drawing.Point(0, 0)
        Me.Dgs_Equipos.Name = "Dgs_Equipos"
        '
        '
        '
        Me.Dgs_Equipos.PrimaryGrid.CheckBoxes = True
        Me.Dgs_Equipos.PrimaryGrid.Checked = True
        '
        '
        '
        Me.Dgs_Equipos.PrimaryGrid.ColumnHeader.RowHeight = 25
        Me.Dgs_Equipos.PrimaryGrid.DefaultRowHeight = 40
        Me.Dgs_Equipos.PrimaryGrid.RowDoubleClickBehavior = DevComponents.DotNetBar.SuperGrid.RowDoubleClickBehavior.ExpandCollapse
        Me.Dgs_Equipos.PrimaryGrid.RowFocusMode = DevComponents.DotNetBar.SuperGrid.RowFocusMode.CellsOnly
        Me.Dgs_Equipos.PrimaryGrid.RowHeaderIndexOffset = 1
        Me.Dgs_Equipos.PrimaryGrid.ShowRowGridIndex = True
        Me.Dgs_Equipos.PrimaryGrid.UseAlternateRowStyle = True
        Me.Dgs_Equipos.Size = New System.Drawing.Size(1058, 83)
        Me.Dgs_Equipos.TabIndex = 1
        Me.Dgs_Equipos.Text = "SuperGridControl1"
        '
        'Cms1Equipos
        '
        Me.Cms1Equipos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsmi1Eliminar})
        Me.Cms1Equipos.Name = "Cms1Equipos"
        Me.Cms1Equipos.Size = New System.Drawing.Size(118, 26)
        '
        'Tsmi1Eliminar
        '
        Me.Tsmi1Eliminar.Name = "Tsmi1Eliminar"
        Me.Tsmi1Eliminar.Size = New System.Drawing.Size(117, 22)
        Me.Tsmi1Eliminar.Text = "Eliminar"
        '
        'GridCell6
        '
        Me.GridCell6.Value = "333"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.DtiUltimaVenta)
        Me.GroupPanel1.Controls.Add(Me.LabelX21)
        Me.GroupPanel1.Controls.Add(Me.DtiUltimoPedido)
        Me.GroupPanel1.Controls.Add(Me.LabelX18)
        Me.GroupPanel1.Controls.Add(Me.Dt2FechaIng)
        Me.GroupPanel1.Controls.Add(Me.LabelX17)
        Me.GroupPanel1.Controls.Add(Me.GroupPanel3)
        Me.GroupPanel1.Controls.Add(Me.Gp1Estado)
        Me.GroupPanel1.Controls.Add(Me.Bt2Confirmar)
        Me.GroupPanel1.Controls.Add(Me.Cbx_Categoria)
        Me.GroupPanel1.Controls.Add(Me.Cbx_TipoDoc)
        Me.GroupPanel1.Controls.Add(Me.Cbx_Zona)
        Me.GroupPanel1.Controls.Add(Me.Dt1FechaNac)
        Me.GroupPanel1.Controls.Add(Me.LabelX15)
        Me.GroupPanel1.Controls.Add(Me.Sb_Eventual)
        Me.GroupPanel1.Controls.Add(Me.Txt_Obs)
        Me.GroupPanel1.Controls.Add(Me.LabelX13)
        Me.GroupPanel1.Controls.Add(Me.Txt_Codigo)
        Me.GroupPanel1.Controls.Add(Me.Txt_Telefono2)
        Me.GroupPanel1.Controls.Add(Me.Txt_Nombre)
        Me.GroupPanel1.Controls.Add(Me.Txt_Telefono1)
        Me.GroupPanel1.Controls.Add(Me.Txt_NroDoc)
        Me.GroupPanel1.Controls.Add(Me.Txt_Direccion)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Controls.Add(Me.LabelX8)
        Me.GroupPanel1.Controls.Add(Me.LabelX9)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.Controls.Add(Me.LabelX14)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(827, 309)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
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
        Me.GroupPanel1.TabIndex = 21
        Me.GroupPanel1.Text = "Datos Cliente"
        '
        'LabelX21
        '
        '
        '
        '
        Me.LabelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX21.Location = New System.Drawing.Point(610, 0)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(92, 23)
        Me.LabelX21.TabIndex = 37
        Me.LabelX21.Text = "ULTIMA VENTA...."
        '
        'LabelX18
        '
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Location = New System.Drawing.Point(393, 0)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(95, 23)
        Me.LabelX18.TabIndex = 35
        Me.LabelX18.Text = "ULTIMO PEDIDO...."
        '
        'LabelX17
        '
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Location = New System.Drawing.Point(257, 159)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(131, 23)
        Me.LabelX17.TabIndex = 31
        Me.LabelX17.Text = "FECHA DE INGRESO..............."
        '
        'GroupPanel3
        '
        Me.GroupPanel3.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Tb11Nit)
        Me.GroupPanel3.Controls.Add(Me.Tb10NombreFactura)
        Me.GroupPanel3.Controls.Add(Me.LabelX16)
        Me.GroupPanel3.Controls.Add(Me.LabelX10)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupPanel3.Location = New System.Drawing.Point(0, 235)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(821, 53)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 29
        Me.GroupPanel3.Text = "DATOS DE FACTURA"
        '
        'Tb11Nit
        '
        '
        '
        '
        Me.Tb11Nit.Border.Class = "TextBoxBorder"
        Me.Tb11Nit.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb11Nit.Location = New System.Drawing.Point(639, 3)
        Me.Tb11Nit.MaxLength = 20
        Me.Tb11Nit.Name = "Tb11Nit"
        Me.Tb11Nit.PreventEnterBeep = True
        Me.Tb11Nit.Size = New System.Drawing.Size(172, 20)
        Me.Tb11Nit.TabIndex = 1
        '
        'Tb10NombreFactura
        '
        '
        '
        '
        Me.Tb10NombreFactura.Border.Class = "TextBoxBorder"
        Me.Tb10NombreFactura.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb10NombreFactura.Location = New System.Drawing.Point(125, 3)
        Me.Tb10NombreFactura.MaxLength = 200
        Me.Tb10NombreFactura.Name = "Tb10NombreFactura"
        Me.Tb10NombreFactura.PreventEnterBeep = True
        Me.Tb10NombreFactura.Size = New System.Drawing.Size(476, 20)
        Me.Tb10NombreFactura.TabIndex = 0
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Location = New System.Drawing.Point(607, 0)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(47, 23)
        Me.LabelX16.TabIndex = 1
        Me.LabelX16.Text = "NIT......."
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Location = New System.Drawing.Point(4, 3)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(115, 23)
        Me.LabelX10.TabIndex = 0
        Me.LabelX10.Text = "NOMBRE FACTURA..."
        '
        'Gp1Estado
        '
        Me.Gp1Estado.CanvasColor = System.Drawing.SystemColors.Control
        Me.Gp1Estado.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Gp1Estado.Controls.Add(Me.Rb3Devuelto)
        Me.Gp1Estado.Controls.Add(Me.Rb2Pasivo)
        Me.Gp1Estado.Controls.Add(Me.Rb1Activo)
        Me.Gp1Estado.DisabledBackColor = System.Drawing.Color.Empty
        Me.Gp1Estado.Location = New System.Drawing.Point(363, 106)
        Me.Gp1Estado.Name = "Gp1Estado"
        Me.Gp1Estado.Size = New System.Drawing.Size(241, 45)
        '
        '
        '
        Me.Gp1Estado.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Gp1Estado.Style.BackColorGradientAngle = 90
        Me.Gp1Estado.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Gp1Estado.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Gp1Estado.Style.BorderBottomWidth = 1
        Me.Gp1Estado.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Gp1Estado.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Gp1Estado.Style.BorderLeftWidth = 1
        Me.Gp1Estado.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Gp1Estado.Style.BorderRightWidth = 1
        Me.Gp1Estado.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Gp1Estado.Style.BorderTopWidth = 1
        Me.Gp1Estado.Style.CornerDiameter = 4
        Me.Gp1Estado.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Gp1Estado.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Gp1Estado.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Gp1Estado.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Gp1Estado.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Gp1Estado.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Gp1Estado.TabIndex = 9
        Me.Gp1Estado.Text = "ESTADO"
        '
        'Rb3Devuelto
        '
        Me.Rb3Devuelto.AutoSize = True
        Me.Rb3Devuelto.Location = New System.Drawing.Point(151, 3)
        Me.Rb3Devuelto.Name = "Rb3Devuelto"
        Me.Rb3Devuelto.Size = New System.Drawing.Size(68, 17)
        Me.Rb3Devuelto.TabIndex = 2
        Me.Rb3Devuelto.TabStop = True
        Me.Rb3Devuelto.Text = "Devuelto"
        Me.Rb3Devuelto.UseVisualStyleBackColor = True
        '
        'Rb2Pasivo
        '
        Me.Rb2Pasivo.AutoSize = True
        Me.Rb2Pasivo.Location = New System.Drawing.Point(74, 3)
        Me.Rb2Pasivo.Name = "Rb2Pasivo"
        Me.Rb2Pasivo.Size = New System.Drawing.Size(57, 17)
        Me.Rb2Pasivo.TabIndex = 1
        Me.Rb2Pasivo.TabStop = True
        Me.Rb2Pasivo.Text = "Pasivo"
        Me.Rb2Pasivo.UseVisualStyleBackColor = True
        '
        'Rb1Activo
        '
        Me.Rb1Activo.AutoSize = True
        Me.Rb1Activo.Location = New System.Drawing.Point(3, 3)
        Me.Rb1Activo.Name = "Rb1Activo"
        Me.Rb1Activo.Size = New System.Drawing.Size(55, 17)
        Me.Rb1Activo.TabIndex = 0
        Me.Rb1Activo.TabStop = True
        Me.Rb1Activo.Text = "Activo"
        Me.Rb1Activo.UseVisualStyleBackColor = True
        '
        'Bt2Confirmar
        '
        Me.Bt2Confirmar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Bt2Confirmar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Bt2Confirmar.ImageFixedSize = New System.Drawing.Size(30, 50)
        Me.Bt2Confirmar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.Bt2Confirmar.Location = New System.Drawing.Point(694, 188)
        Me.Bt2Confirmar.Name = "Bt2Confirmar"
        Me.Bt2Confirmar.Size = New System.Drawing.Size(127, 40)
        Me.Bt2Confirmar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bt2Confirmar.TabIndex = 27
        Me.Bt2Confirmar.Text = "Confirmar"
        '
        'LabelX15
        '
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Location = New System.Drawing.Point(2, 159)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(101, 23)
        Me.LabelX15.TabIndex = 26
        Me.LabelX15.Text = "FECHA DE NAC..............."
        '
        'Sb_Eventual
        '
        '
        '
        '
        Me.Sb_Eventual.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Sb_Eventual.Location = New System.Drawing.Point(694, 29)
        Me.Sb_Eventual.Name = "Sb_Eventual"
        Me.Sb_Eventual.OffText = "EVENTUAL"
        Me.Sb_Eventual.OnText = "CONFIRMADO"
        Me.Sb_Eventual.Size = New System.Drawing.Size(127, 22)
        Me.Sb_Eventual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Sb_Eventual.TabIndex = 10
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Location = New System.Drawing.Point(610, 55)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(204, 23)
        Me.LabelX13.TabIndex = 23
        Me.LabelX13.Text = "OBSERVACIÓN"
        Me.LabelX13.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX14
        '
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Location = New System.Drawing.Point(610, 26)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(85, 23)
        Me.LabelX14.TabIndex = 25
        Me.LabelX14.Text = "TIPO CLIENTE............................"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.PanelEx7)
        Me.GroupPanel2.Controls.Add(Me.PanelEx6)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel2.Location = New System.Drawing.Point(5, 5)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupPanel2.Size = New System.Drawing.Size(1074, 167)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 22
        Me.GroupPanel2.Text = "Equipos"
        '
        'PanelEx7
        '
        Me.PanelEx7.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx7.Controls.Add(Me.Dgs_Equipos)
        Me.PanelEx7.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx7.Location = New System.Drawing.Point(5, 58)
        Me.PanelEx7.Name = "PanelEx7"
        Me.PanelEx7.Size = New System.Drawing.Size(1058, 83)
        Me.PanelEx7.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx7.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx7.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx7.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx7.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx7.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx7.Style.GradientAngle = 90
        Me.PanelEx7.TabIndex = 6
        '
        'PanelEx6
        '
        Me.PanelEx6.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx6.Controls.Add(Me.LabelX20)
        Me.PanelEx6.Controls.Add(Me.TbiCantEntrante)
        Me.PanelEx6.Controls.Add(Me.LabelX22)
        Me.PanelEx6.Controls.Add(Me.TbiCantSaliente)
        Me.PanelEx6.Controls.Add(Me.LabelX23)
        Me.PanelEx6.Controls.Add(Me.LabelX19)
        Me.PanelEx6.Controls.Add(Me.TbiCantSaldo)
        Me.PanelEx6.Controls.Add(Me.CbFiltroResumenEquipo)
        Me.PanelEx6.Controls.Add(Me.Bt1AddEquipos)
        Me.PanelEx6.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx6.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx6.Location = New System.Drawing.Point(5, 5)
        Me.PanelEx6.Name = "PanelEx6"
        Me.PanelEx6.Size = New System.Drawing.Size(1058, 53)
        Me.PanelEx6.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx6.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx6.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx6.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx6.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx6.Style.GradientAngle = 90
        Me.PanelEx6.TabIndex = 2
        '
        'LabelX20
        '
        '
        '
        '
        Me.LabelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX20.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX20.Location = New System.Drawing.Point(441, 0)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(100, 23)
        Me.LabelX20.TabIndex = 14
        Me.LabelX20.Text = "Entrante"
        '
        'TbiCantEntrante
        '
        '
        '
        '
        Me.TbiCantEntrante.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.TbiCantEntrante.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TbiCantEntrante.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.TbiCantEntrante.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbiCantEntrante.IsInputReadOnly = True
        Me.TbiCantEntrante.Location = New System.Drawing.Point(441, 24)
        Me.TbiCantEntrante.Name = "TbiCantEntrante"
        Me.TbiCantEntrante.Size = New System.Drawing.Size(100, 23)
        Me.TbiCantEntrante.TabIndex = 13
        '
        'LabelX22
        '
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX22.Location = New System.Drawing.Point(335, 0)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(100, 23)
        Me.LabelX22.TabIndex = 12
        Me.LabelX22.Text = "Saliente"
        '
        'TbiCantSaliente
        '
        '
        '
        '
        Me.TbiCantSaliente.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.TbiCantSaliente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TbiCantSaliente.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.TbiCantSaliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbiCantSaliente.IsInputReadOnly = True
        Me.TbiCantSaliente.Location = New System.Drawing.Point(335, 24)
        Me.TbiCantSaliente.Name = "TbiCantSaliente"
        Me.TbiCantSaliente.Size = New System.Drawing.Size(100, 23)
        Me.TbiCantSaliente.TabIndex = 11
        '
        'LabelX23
        '
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX23.Location = New System.Drawing.Point(547, 0)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(100, 23)
        Me.LabelX23.TabIndex = 8
        Me.LabelX23.Text = "Saldo Cliente"
        '
        'LabelX19
        '
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX19.Location = New System.Drawing.Point(129, 0)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(75, 23)
        Me.LabelX19.TabIndex = 7
        Me.LabelX19.Text = "Producto"
        '
        'TbiCantSaldo
        '
        '
        '
        '
        Me.TbiCantSaldo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.TbiCantSaldo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TbiCantSaldo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.TbiCantSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbiCantSaldo.IsInputReadOnly = True
        Me.TbiCantSaldo.Location = New System.Drawing.Point(547, 24)
        Me.TbiCantSaldo.Name = "TbiCantSaldo"
        Me.TbiCantSaldo.Size = New System.Drawing.Size(100, 23)
        Me.TbiCantSaldo.TabIndex = 2
        '
        'CbFiltroResumenEquipo
        '
        CbFiltroResumenEquipo_DesignTimeLayout.LayoutString = resources.GetString("CbFiltroResumenEquipo_DesignTimeLayout.LayoutString")
        Me.CbFiltroResumenEquipo.DesignTimeLayout = CbFiltroResumenEquipo_DesignTimeLayout
        Me.CbFiltroResumenEquipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbFiltroResumenEquipo.Location = New System.Drawing.Point(129, 24)
        Me.CbFiltroResumenEquipo.Name = "CbFiltroResumenEquipo"
        Me.CbFiltroResumenEquipo.SelectedIndex = -1
        Me.CbFiltroResumenEquipo.SelectedItem = Nothing
        Me.CbFiltroResumenEquipo.Size = New System.Drawing.Size(200, 23)
        Me.CbFiltroResumenEquipo.TabIndex = 1
        '
        'Dgj1Busqueda
        '
        Me.Dgj1Busqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgj1Busqueda.Location = New System.Drawing.Point(5, 5)
        Me.Dgj1Busqueda.Name = "Dgj1Busqueda"
        Me.Dgj1Busqueda.RecordNavigator = True
        Me.Dgj1Busqueda.Size = New System.Drawing.Size(1074, 576)
        Me.Dgj1Busqueda.TabIndex = 2
        '
        'Rl1Accion
        '
        '
        '
        '
        Me.Rl1Accion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rl1Accion.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rl1Accion.ForeColor = System.Drawing.Color.White
        Me.Rl1Accion.Location = New System.Drawing.Point(297, 1)
        Me.Rl1Accion.Name = "Rl1Accion"
        Me.Rl1Accion.Size = New System.Drawing.Size(300, 60)
        Me.Rl1Accion.TabIndex = 7
        Me.Rl1Accion.Text = "<b><font size=""+10""><font color=""#FF0000""></font></font></b>"
        '
        'FlyoutUsuario
        '
        Me.FlyoutUsuario.DropShadow = False
        Me.FlyoutUsuario.TargetControl = Me.BubbleBar5
        '
        'StcSugerenciaUbicacion
        '
        '
        '
        '
        '
        '
        '
        Me.StcSugerenciaUbicacion.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.StcSugerenciaUbicacion.ControlBox.MenuBox.Name = ""
        Me.StcSugerenciaUbicacion.ControlBox.Name = ""
        Me.StcSugerenciaUbicacion.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.StcSugerenciaUbicacion.ControlBox.MenuBox, Me.StcSugerenciaUbicacion.ControlBox.CloseBox})
        Me.StcSugerenciaUbicacion.Controls.Add(Me.SuperTabControlPanel3)
        Me.StcSugerenciaUbicacion.Controls.Add(Me.SuperTabControlPanel4)
        Me.StcSugerenciaUbicacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StcSugerenciaUbicacion.Location = New System.Drawing.Point(827, 0)
        Me.StcSugerenciaUbicacion.Name = "StcSugerenciaUbicacion"
        Me.StcSugerenciaUbicacion.ReorderTabsEnabled = True
        Me.StcSugerenciaUbicacion.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.StcSugerenciaUbicacion.SelectedTabIndex = 0
        Me.StcSugerenciaUbicacion.Size = New System.Drawing.Size(257, 309)
        Me.StcSugerenciaUbicacion.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StcSugerenciaUbicacion.TabIndex = 22
        Me.StcSugerenciaUbicacion.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.StiFiltroCliente, Me.StiUbicacion})
        Me.StcSugerenciaUbicacion.Text = "SuperTabControl2"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.DgjSugerencias)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Padding = New System.Windows.Forms.Padding(5)
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(257, 284)
        Me.SuperTabControlPanel3.TabIndex = 1
        Me.SuperTabControlPanel3.TabItem = Me.StiFiltroCliente
        '
        'DgjSugerencias
        '
        Me.DgjSugerencias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgjSugerencias.Location = New System.Drawing.Point(5, 5)
        Me.DgjSugerencias.Name = "DgjSugerencias"
        Me.DgjSugerencias.RecordNavigator = True
        Me.DgjSugerencias.Size = New System.Drawing.Size(247, 274)
        Me.DgjSugerencias.TabIndex = 0
        '
        'StiFiltroCliente
        '
        Me.StiFiltroCliente.AttachedControl = Me.SuperTabControlPanel3
        Me.StiFiltroCliente.GlobalItem = False
        Me.StiFiltroCliente.Name = "StiFiltroCliente"
        Me.StiFiltroCliente.Text = "Sugerencias"
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.Controls.Add(Me.GroupPanel4)
        Me.SuperTabControlPanel4.Controls.Add(Me.Gp_Datos)
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(257, 284)
        Me.SuperTabControlPanel4.TabIndex = 0
        Me.SuperTabControlPanel4.TabItem = Me.StiUbicacion
        '
        'GroupPanel4
        '
        Me.GroupPanel4.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Gmc_Cliente)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel4.Location = New System.Drawing.Point(168, 0)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(89, 284)
        '
        '
        '
        Me.GroupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel4.Style.BackColorGradientAngle = 90
        Me.GroupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderBottomWidth = 1
        Me.GroupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderLeftWidth = 1
        Me.GroupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderRightWidth = 1
        Me.GroupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderTopWidth = 1
        Me.GroupPanel4.Style.CornerDiameter = 4
        Me.GroupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel4.TabIndex = 5
        Me.GroupPanel4.Text = "Mapa"
        '
        'Gmc_Cliente
        '
        Me.Gmc_Cliente.Bearing = 0.0!
        Me.Gmc_Cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Gmc_Cliente.CanDragMap = True
        Me.Gmc_Cliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Gmc_Cliente.EmptyTileColor = System.Drawing.Color.Navy
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
        Me.Gmc_Cliente.Padding = New System.Windows.Forms.Padding(5)
        Me.Gmc_Cliente.PolygonsEnabled = True
        Me.Gmc_Cliente.RetryLoadTile = 0
        Me.Gmc_Cliente.RoutesEnabled = True
        Me.Gmc_Cliente.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
        Me.Gmc_Cliente.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.Gmc_Cliente.ShowTileGridLines = False
        Me.Gmc_Cliente.Size = New System.Drawing.Size(83, 263)
        Me.Gmc_Cliente.TabIndex = 2
        Me.Gmc_Cliente.Zoom = 0.0R
        '
        'Gp_Datos
        '
        Me.Gp_Datos.CanvasColor = System.Drawing.SystemColors.Control
        Me.Gp_Datos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Gp_Datos.Controls.Add(Me.PanelUsuario)
        Me.Gp_Datos.Controls.Add(Me.Btnx_ChekGetPoint)
        Me.Gp_Datos.Controls.Add(Me.Txt_Longitud)
        Me.Gp_Datos.Controls.Add(Me.LabelX12)
        Me.Gp_Datos.Controls.Add(Me.Txt_Latitud)
        Me.Gp_Datos.Controls.Add(Me.LabelX11)
        Me.Gp_Datos.DisabledBackColor = System.Drawing.Color.Empty
        Me.Gp_Datos.Dock = System.Windows.Forms.DockStyle.Left
        Me.Gp_Datos.Location = New System.Drawing.Point(0, 0)
        Me.Gp_Datos.Name = "Gp_Datos"
        Me.Gp_Datos.Size = New System.Drawing.Size(168, 284)
        '
        '
        '
        Me.Gp_Datos.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Gp_Datos.Style.BackColorGradientAngle = 90
        Me.Gp_Datos.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Gp_Datos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Gp_Datos.Style.BorderBottomWidth = 1
        Me.Gp_Datos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Gp_Datos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Gp_Datos.Style.BorderLeftWidth = 1
        Me.Gp_Datos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Gp_Datos.Style.BorderRightWidth = 1
        Me.Gp_Datos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Gp_Datos.Style.BorderTopWidth = 1
        Me.Gp_Datos.Style.CornerDiameter = 4
        Me.Gp_Datos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Gp_Datos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Gp_Datos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Gp_Datos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Gp_Datos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Gp_Datos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Gp_Datos.TabIndex = 4
        Me.Gp_Datos.Text = "Coordenadas"
        '
        'PanelUsuario
        '
        Me.PanelUsuario.Controls.Add(Me.lbHora)
        Me.PanelUsuario.Controls.Add(Me.lbFecha)
        Me.PanelUsuario.Controls.Add(Me.lbUsuario)
        Me.PanelUsuario.Controls.Add(Me.Label3)
        Me.PanelUsuario.Controls.Add(Me.Label2)
        Me.PanelUsuario.Controls.Add(Me.Label1)
        Me.PanelUsuario.Location = New System.Drawing.Point(5, 173)
        Me.PanelUsuario.Name = "PanelUsuario"
        Me.PanelUsuario.Size = New System.Drawing.Size(220, 100)
        Me.PanelUsuario.TabIndex = 7
        Me.PanelUsuario.TabStop = True
        Me.PanelUsuario.Visible = False
        '
        'lbHora
        '
        Me.lbHora.AutoSize = True
        Me.lbHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbHora.Location = New System.Drawing.Point(115, 65)
        Me.lbHora.Name = "lbHora"
        Me.lbHora.Size = New System.Drawing.Size(79, 18)
        Me.lbHora.TabIndex = 6
        Me.lbHora.Text = "USUARIO:"
        '
        'lbFecha
        '
        Me.lbFecha.AutoSize = True
        Me.lbFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFecha.Location = New System.Drawing.Point(115, 42)
        Me.lbFecha.Name = "lbFecha"
        Me.lbFecha.Size = New System.Drawing.Size(79, 18)
        Me.lbFecha.TabIndex = 5
        Me.lbFecha.Text = "USUARIO:"
        '
        'lbUsuario
        '
        Me.lbUsuario.AutoSize = True
        Me.lbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUsuario.Location = New System.Drawing.Point(115, 19)
        Me.lbUsuario.Name = "lbUsuario"
        Me.lbUsuario.Size = New System.Drawing.Size(79, 18)
        Me.lbUsuario.TabIndex = 4
        Me.lbUsuario.Text = "USUARIO:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(31, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "HORA:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "FECHA:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "USUARIO:"
        '
        'Btnx_ChekGetPoint
        '
        Me.Btnx_ChekGetPoint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btnx_ChekGetPoint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btnx_ChekGetPoint.Location = New System.Drawing.Point(5, 104)
        Me.Btnx_ChekGetPoint.Name = "Btnx_ChekGetPoint"
        Me.Btnx_ChekGetPoint.Size = New System.Drawing.Size(150, 60)
        Me.Btnx_ChekGetPoint.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btnx_ChekGetPoint.TabIndex = 5
        Me.Btnx_ChekGetPoint.Text = "???"
        '
        'Txt_Longitud
        '
        '
        '
        '
        Me.Txt_Longitud.Border.Class = "TextBoxBorder"
        Me.Txt_Longitud.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Longitud.Location = New System.Drawing.Point(5, 78)
        Me.Txt_Longitud.Name = "Txt_Longitud"
        Me.Txt_Longitud.PreventEnterBeep = True
        Me.Txt_Longitud.Size = New System.Drawing.Size(150, 20)
        Me.Txt_Longitud.TabIndex = 3
        Me.Txt_Longitud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX12
        '
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Location = New System.Drawing.Point(5, 55)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(150, 23)
        Me.LabelX12.TabIndex = 2
        Me.LabelX12.Text = "LONGITUD"
        Me.LabelX12.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Txt_Latitud
        '
        '
        '
        '
        Me.Txt_Latitud.Border.Class = "TextBoxBorder"
        Me.Txt_Latitud.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Latitud.Location = New System.Drawing.Point(5, 29)
        Me.Txt_Latitud.Name = "Txt_Latitud"
        Me.Txt_Latitud.PreventEnterBeep = True
        Me.Txt_Latitud.Size = New System.Drawing.Size(150, 20)
        Me.Txt_Latitud.TabIndex = 1
        Me.Txt_Latitud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX11
        '
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Location = New System.Drawing.Point(5, 8)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(150, 23)
        Me.LabelX11.TabIndex = 0
        Me.LabelX11.Text = "LATITUD"
        Me.LabelX11.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'StiUbicacion
        '
        Me.StiUbicacion.AttachedControl = Me.SuperTabControlPanel4
        Me.StiUbicacion.GlobalItem = False
        Me.StiUbicacion.Name = "StiUbicacion"
        Me.StiUbicacion.Text = "Ubicación"
        '
        'BtActualizar
        '
        Me.BtActualizar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtActualizar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtActualizar.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtActualizar.Image = Global.Presentacion.My.Resources.Resources.BT_ACTUALIZAR
        Me.BtActualizar.ImageFixedSize = New System.Drawing.Size(45, 45)
        Me.BtActualizar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtActualizar.Location = New System.Drawing.Point(1009, 0)
        Me.BtActualizar.Name = "BtActualizar"
        Me.BtActualizar.Size = New System.Drawing.Size(75, 64)
        Me.BtActualizar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtActualizar.TabIndex = 8
        Me.BtActualizar.Text = "Actualizar"
        '
        'CpActCliente
        '
        '
        '
        '
        Me.CpActCliente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CpActCliente.Dock = System.Windows.Forms.DockStyle.Right
        Me.CpActCliente.Location = New System.Drawing.Point(934, 0)
        Me.CpActCliente.Name = "CpActCliente"
        Me.CpActCliente.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.CpActCliente.ProgressColor = System.Drawing.Color.Black
        Me.CpActCliente.Size = New System.Drawing.Size(75, 64)
        Me.CpActCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CpActCliente.TabIndex = 9
        '
        'TiCliente
        '
        Me.TiCliente.Interval = 40
        '
        'BtPasarCliente
        '
        Me.BtPasarCliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtPasarCliente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtPasarCliente.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtPasarCliente.Image = Global.Presentacion.My.Resources.Resources.I512X512_Intercambio
        Me.BtPasarCliente.ImageFixedSize = New System.Drawing.Size(45, 45)
        Me.BtPasarCliente.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtPasarCliente.Location = New System.Drawing.Point(795, 0)
        Me.BtPasarCliente.Name = "BtPasarCliente"
        Me.BtPasarCliente.Size = New System.Drawing.Size(75, 64)
        Me.BtPasarCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtPasarCliente.TabIndex = 10
        Me.BtPasarCliente.Text = "Exportar"
        '
        'P_Clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1084, 611)
        Me.Name = "P_Clientes"
        Me.Text = "CLIENTES"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.SuperTabControl1, 0)
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.BubbleBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BubbleBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx2.ResumeLayout(False)
        Me.PanelEx2.PerformLayout()
        Me.PanelEx3.ResumeLayout(False)
        Me.PanelEx4.ResumeLayout(False)
        CType(Me.BubbleBar4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BubbleBar3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BubbleBar5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx5.ResumeLayout(False)
        Me.PanelEx5.PerformLayout()
        CType(Me.Cbx_Zona, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbx_TipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbx_Categoria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cms1Equipos.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GroupPanel3.ResumeLayout(False)
        Me.Gp1Estado.ResumeLayout(False)
        Me.Gp1Estado.PerformLayout()
        Me.GroupPanel2.ResumeLayout(False)
        Me.PanelEx7.ResumeLayout(False)
        Me.PanelEx6.ResumeLayout(False)
        Me.PanelEx6.PerformLayout()
        CType(Me.TbiCantEntrante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbiCantSaliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbiCantSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbFiltroResumenEquipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgj1Busqueda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StcSugerenciaUbicacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StcSugerenciaUbicacion.ResumeLayout(False)
        Me.SuperTabControlPanel3.ResumeLayout(False)
        CType(Me.DgjSugerencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel4.ResumeLayout(False)
        Me.GroupPanel4.ResumeLayout(False)
        Me.Gp_Datos.ResumeLayout(False)
        Me.PanelUsuario.ResumeLayout(False)
        Me.PanelUsuario.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Telefono2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Telefono1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Direccion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_NroDoc As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Nombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Codigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Hl_Clientes As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents GridCell1 As DevComponents.DotNetBar.SuperGrid.GridCell
    Friend WithEvents GridCell2 As DevComponents.DotNetBar.SuperGrid.GridCell
    Friend WithEvents Bt1AddEquipos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Dgs_Equipos As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents GridCell3 As DevComponents.DotNetBar.SuperGrid.GridCell
    Friend WithEvents GridCell4 As DevComponents.DotNetBar.SuperGrid.GridCell
    Friend WithEvents GridCell5 As DevComponents.DotNetBar.SuperGrid.GridCell
    Friend WithEvents GridCell6 As DevComponents.DotNetBar.SuperGrid.GridCell
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Sb_Eventual As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Txt_Obs As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dt1FechaNac As System.Windows.Forms.DateTimePicker
    Friend WithEvents Cbx_Zona As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Cbx_TipoDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Cbx_Categoria As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Bt2Confirmar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Gp1Estado As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Rb3Devuelto As System.Windows.Forms.RadioButton
    Friend WithEvents Rb2Pasivo As System.Windows.Forms.RadioButton
    Friend WithEvents Rb1Activo As System.Windows.Forms.RadioButton
    Friend WithEvents Dgj1Busqueda As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Tb11Nit As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Tb10NombreFactura As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rl1Accion As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Dt2FechaIng As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cms1Equipos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Tsmi1Eliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FlyoutUsuario As DevComponents.DotNetBar.Controls.Flyout
    Friend WithEvents StcSugerenciaUbicacion As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Gmc_Cliente As GMap.NET.WindowsForms.GMapControl
    Friend WithEvents Gp_Datos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PanelUsuario As System.Windows.Forms.Panel
    Friend WithEvents lbHora As System.Windows.Forms.Label
    Friend WithEvents lbFecha As System.Windows.Forms.Label
    Friend WithEvents lbUsuario As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Btnx_ChekGetPoint As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Longitud As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Latitud As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents StiUbicacion As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents StiFiltroCliente As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents DgjSugerencias As Janus.Windows.GridEX.GridEX
    Friend WithEvents CpActCliente As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents BtActualizar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TiCliente As System.Windows.Forms.Timer
    Friend WithEvents PanelEx7 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PanelEx6 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents CbFiltroResumenEquipo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TbiCantSaldo As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TbiCantSaliente As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TbiCantEntrante As DevComponents.Editors.IntegerInput
    Private WithEvents DtiUltimoPedido As System.Windows.Forms.DateTimePicker
    Private WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Private WithEvents DtiUltimaVenta As System.Windows.Forms.DateTimePicker
    Private WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtPasarCliente As DevComponents.DotNetBar.ButtonX

End Class
