<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F02_Pedido
    Inherits Modelo.ModeloF02_cd

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
        Me.components = New System.ComponentModel.Container()
        Dim cbPreVendedor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F02_Pedido))
        Dim cbDistribuidor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.TableLayoutPanelPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GrPan_PeriodoPedido = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PaFrecEnDias = New System.Windows.Forms.Panel()
        Me.GrB_FrecEnDias = New System.Windows.Forms.GroupBox()
        Me.Tb_FrecEnDias = New DevComponents.Editors.IntegerInput()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Check2 = New DevComponents.DotNetBar.ButtonX()
        Me.PaFrecMensual = New System.Windows.Forms.Panel()
        Me.GrB_FrecMensual = New System.Windows.Forms.GroupBox()
        Me.Tb_FrecMensual = New DevComponents.Editors.IntegerInput()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Check3 = New DevComponents.DotNetBar.ButtonX()
        Me.PaFrecSem = New System.Windows.Forms.Panel()
        Me.GrB_FrecSemanal = New System.Windows.Forms.GroupBox()
        Me.CheckBoxX7 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX6 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX5 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX4 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX3 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX2 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Check1 = New DevComponents.DotNetBar.ButtonX()
        Me.GroupPanel5 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.JGr_DetallePedido = New Janus.Windows.GridEX.GridEX()
        Me.cmQuitarDetalle = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.QuitarItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.tbCodCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Tb_CliEstado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Tb_CliCod = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Tb_CliTelef = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Tb_CliNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Tb_CliDireccion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.cbPreVendedor = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbDistribuidor = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Btn_GenerarPedidos = New DevComponents.DotNetBar.ButtonX()
        Me.Tb_Estado = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Lb_Estado = New DevComponents.DotNetBar.LabelX()
        Me.Tb_CliCateg = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Tb_CliCodZona = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Tb_Observaciones = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Tb_Zona = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Tb_Hora = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Tb_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.Tb_Id = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelEx4 = New DevComponents.DotNetBar.PanelEx()
        Me.Tb_CantProd = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_AddProd = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_TerminarAdd = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.JGr_Productos = New Janus.Windows.GridEX.GridEX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.JGr_TipoProd = New Janus.Windows.GridEX.GridEX()
        Me.SuperTabItemCliente = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupPanel10 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.JGr_Reclamos = New Janus.Windows.GridEX.GridEX()
        Me.GroupPanel8 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.JGr_Clientes = New Janus.Windows.GridEX.GridEX()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupPanel12 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Tb_DireccionDetalle = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel11 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelEx6 = New DevComponents.DotNetBar.PanelEx()
        Me.Tb_Obs2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Tb_Obs = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel9 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelEx5 = New DevComponents.DotNetBar.PanelEx()
        Me.JGr_UltimosPedidos = New Janus.Windows.GridEX.GridEX()
        Me.Tb_TotalPedidos3Meses = New System.Windows.Forms.TextBox()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.Tb_PromCosumo = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupPanel7 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.JGr_Buscador = New Janus.Windows.GridEX.GridEX()
        Me.GroupPanel6 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelEx9 = New DevComponents.DotNetBar.PanelEx()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.btBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.tbFechaAl = New System.Windows.Forms.DateTimePicker()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.tbFechaDel = New System.Windows.Forms.DateTimePicker()
        Me.ConMenu_Clientes = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ACTUALIZARCLIENTESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VERCLIENTESPASIVOSYACTIVOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VERCLIENTESACTIVOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConMenu_Buscador = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.VERHISTORIALToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConMenu_Opciones1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GRABARRECLAMOREPARTIDORToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VERHISTORIALToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.REGERARPEDIDOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ANULARPEDIDOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btActualizar = New DevComponents.DotNetBar.ButtonX()
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
        Me.TableLayoutPanelPrincipal.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GrPan_PeriodoPedido.SuspendLayout()
        Me.PaFrecEnDias.SuspendLayout()
        Me.GrB_FrecEnDias.SuspendLayout()
        CType(Me.Tb_FrecEnDias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PaFrecMensual.SuspendLayout()
        Me.GrB_FrecMensual.SuspendLayout()
        CType(Me.Tb_FrecMensual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PaFrecSem.SuspendLayout()
        Me.GrB_FrecSemanal.SuspendLayout()
        Me.GroupPanel5.SuspendLayout()
        CType(Me.JGr_DetallePedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmQuitarDetalle.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        Me.GroupPanel4.SuspendLayout()
        Me.PanelEx2.SuspendLayout()
        CType(Me.cbPreVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDistribuidor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.PanelEx4.SuspendLayout()
        CType(Me.JGr_Productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.PanelEx3.SuspendLayout()
        CType(Me.JGr_TipoProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.GroupPanel10.SuspendLayout()
        CType(Me.JGr_Reclamos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel8.SuspendLayout()
        CType(Me.JGr_Clientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.GroupPanel12.SuspendLayout()
        Me.GroupPanel11.SuspendLayout()
        Me.PanelEx6.SuspendLayout()
        Me.GroupPanel9.SuspendLayout()
        Me.PanelEx5.SuspendLayout()
        CType(Me.JGr_UltimosPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.GroupPanel7.SuspendLayout()
        CType(Me.JGr_Buscador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel6.SuspendLayout()
        Me.PanelEx9.SuspendLayout()
        Me.ConMenu_Clientes.SuspendLayout()
        Me.ConMenu_Buscador.SuspendLayout()
        Me.ConMenu_Opciones1.SuspendLayout()
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
        Me.MSuperTabControlPrincipal.Controls.Add(Me.SuperTabControlPanel1)
        Me.MSuperTabControlPrincipal.Margin = New System.Windows.Forms.Padding(4)
        Me.MSuperTabControlPrincipal.SelectedTabIndex = 2
        Me.MSuperTabControlPrincipal.Size = New System.Drawing.Size(1028, 503)
        Me.MSuperTabControlPrincipal.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItemCliente})
        Me.MSuperTabControlPrincipal.Controls.SetChildIndex(Me.MSuperTabControlPanelRegistro, 0)
        Me.MSuperTabControlPrincipal.Controls.SetChildIndex(Me.MSuperTabControlPanelBusqueda, 0)
        Me.MSuperTabControlPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanel1, 0)
        '
        'MSuperTabControlPanelBusqueda
        '
        Me.MSuperTabControlPanelBusqueda.Controls.Add(Me.TableLayoutPanel3)
        Me.MSuperTabControlPanelBusqueda.Margin = New System.Windows.Forms.Padding(4)
        Me.MSuperTabControlPanelBusqueda.Size = New System.Drawing.Size(990, 516)
        '
        'MSuperTabControlPanelRegistro
        '
        Me.MSuperTabControlPanelRegistro.Controls.Add(Me.TableLayoutPanelPrincipal)
        Me.MSuperTabControlPanelRegistro.Margin = New System.Windows.Forms.Padding(4)
        Me.MSuperTabControlPanelRegistro.Size = New System.Drawing.Size(986, 503)
        Me.MSuperTabControlPanelRegistro.Controls.SetChildIndex(Me.MPnUsuario, 0)
        Me.MSuperTabControlPanelRegistro.Controls.SetChildIndex(Me.TableLayoutPanelPrincipal, 0)
        '
        'MPnSuperior
        '
        Me.MPnSuperior.Margin = New System.Windows.Forms.Padding(4)
        Me.MPnSuperior.Size = New System.Drawing.Size(1028, 70)
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
        Me.MPnInferior.Location = New System.Drawing.Point(0, 573)
        Me.MPnInferior.Margin = New System.Windows.Forms.Padding(4)
        Me.MPnInferior.Size = New System.Drawing.Size(1028, 29)
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
        Me.MPanelToolBarUsuario.Location = New System.Drawing.Point(828, 0)
        Me.MPanelToolBarUsuario.Margin = New System.Windows.Forms.Padding(4)
        Me.MPanelToolBarUsuario.Size = New System.Drawing.Size(200, 29)
        '
        'MTbUsuario
        '
        Me.MTbUsuario.Margin = New System.Windows.Forms.Padding(4)
        Me.MTbUsuario.ReadOnly = True
        Me.MTbUsuario.Size = New System.Drawing.Size(135, 32)
        Me.MTbUsuario.Text = "DEFAULT"
        '
        'MPanelToolBarNavegacion
        '
        Me.MPanelToolBarNavegacion.Margin = New System.Windows.Forms.Padding(4)
        Me.MPanelToolBarNavegacion.Padding = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.MPanelToolBarNavegacion.Size = New System.Drawing.Size(320, 29)
        '
        'MBtUltimo
        '
        Me.MBtUltimo.Location = New System.Drawing.Point(136, 0)
        Me.MBtUltimo.Margin = New System.Windows.Forms.Padding(2)
        Me.MBtUltimo.Size = New System.Drawing.Size(43, 29)
        '
        'MBtSiguiente
        '
        Me.MBtSiguiente.Location = New System.Drawing.Point(93, 0)
        Me.MBtSiguiente.Margin = New System.Windows.Forms.Padding(4)
        Me.MBtSiguiente.Size = New System.Drawing.Size(43, 29)
        '
        'MBtAnterior
        '
        Me.MBtAnterior.Location = New System.Drawing.Point(50, 0)
        Me.MBtAnterior.Margin = New System.Windows.Forms.Padding(4)
        Me.MBtAnterior.Size = New System.Drawing.Size(43, 29)
        '
        'MBtPrimero
        '
        Me.MBtPrimero.Location = New System.Drawing.Point(7, 0)
        Me.MBtPrimero.Margin = New System.Windows.Forms.Padding(4)
        Me.MBtPrimero.Size = New System.Drawing.Size(43, 29)
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
        Me.MPanelToolBarImprimir.Controls.Add(Me.btActualizar)
        Me.MPanelToolBarImprimir.Location = New System.Drawing.Point(868, 0)
        Me.MPanelToolBarImprimir.Margin = New System.Windows.Forms.Padding(4)
        Me.MPanelToolBarImprimir.Size = New System.Drawing.Size(160, 70)
        Me.MPanelToolBarImprimir.Controls.SetChildIndex(Me.MBtImprimir, 0)
        Me.MPanelToolBarImprimir.Controls.SetChildIndex(Me.btActualizar, 0)
        '
        'MBtImprimir
        '
        Me.MBtImprimir.Location = New System.Drawing.Point(88, 0)
        Me.MBtImprimir.Margin = New System.Windows.Forms.Padding(4)
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
        Me.MBubbleBarUsuario.Margin = New System.Windows.Forms.Padding(4)
        Me.MBubbleBarUsuario.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight
        Me.MBubbleBarUsuario.SelectedTabColors.BorderColor = System.Drawing.Color.Black
        Me.MBubbleBarUsuario.Size = New System.Drawing.Size(50, 29)
        '
        'MLbPaginacion
        '
        '
        '
        '
        Me.MLbPaginacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MLbPaginacion.Location = New System.Drawing.Point(179, 0)
        Me.MLbPaginacion.Margin = New System.Windows.Forms.Padding(4)
        Me.MLbPaginacion.Size = New System.Drawing.Size(134, 29)
        '
        'MFlyoutUsuario
        '
        '
        'MBtUsuario
        '
        '
        'MRlAccion
        '
        '
        '
        '
        Me.MRlAccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'TableLayoutPanelPrincipal
        '
        Me.TableLayoutPanelPrincipal.ColumnCount = 2
        Me.TableLayoutPanelPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanelPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanelPrincipal.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.TableLayoutPanelPrincipal.Controls.Add(Me.TableLayoutPanel2, 1, 0)
        Me.TableLayoutPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelPrincipal.Name = "TableLayoutPanelPrincipal"
        Me.TableLayoutPanelPrincipal.RowCount = 1
        Me.TableLayoutPanelPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelPrincipal.Size = New System.Drawing.Size(986, 503)
        Me.TableLayoutPanelPrincipal.TabIndex = 29
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GrPan_PeriodoPedido, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupPanel5, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupPanel3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupPanel4, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(684, 497)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'GrPan_PeriodoPedido
        '
        Me.GrPan_PeriodoPedido.CanvasColor = System.Drawing.SystemColors.Control
        Me.GrPan_PeriodoPedido.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GrPan_PeriodoPedido.Controls.Add(Me.PaFrecEnDias)
        Me.GrPan_PeriodoPedido.Controls.Add(Me.PaFrecMensual)
        Me.GrPan_PeriodoPedido.Controls.Add(Me.PaFrecSem)
        Me.GrPan_PeriodoPedido.DisabledBackColor = System.Drawing.Color.Empty
        Me.GrPan_PeriodoPedido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrPan_PeriodoPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrPan_PeriodoPedido.Location = New System.Drawing.Point(3, 423)
        Me.GrPan_PeriodoPedido.Name = "GrPan_PeriodoPedido"
        Me.GrPan_PeriodoPedido.Size = New System.Drawing.Size(678, 71)
        '
        '
        '
        Me.GrPan_PeriodoPedido.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GrPan_PeriodoPedido.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GrPan_PeriodoPedido.Style.BackColorGradientAngle = 90
        Me.GrPan_PeriodoPedido.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GrPan_PeriodoPedido.Style.BorderBottomWidth = 1
        Me.GrPan_PeriodoPedido.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GrPan_PeriodoPedido.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GrPan_PeriodoPedido.Style.BorderLeftWidth = 1
        Me.GrPan_PeriodoPedido.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GrPan_PeriodoPedido.Style.BorderRightWidth = 1
        Me.GrPan_PeriodoPedido.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GrPan_PeriodoPedido.Style.BorderTopWidth = 1
        Me.GrPan_PeriodoPedido.Style.CornerDiameter = 4
        Me.GrPan_PeriodoPedido.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GrPan_PeriodoPedido.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GrPan_PeriodoPedido.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GrPan_PeriodoPedido.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GrPan_PeriodoPedido.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GrPan_PeriodoPedido.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GrPan_PeriodoPedido.TabIndex = 12
        Me.GrPan_PeriodoPedido.Text = "F R E C U E N C I A      D E L      P E D I D O "
        '
        'PaFrecEnDias
        '
        Me.PaFrecEnDias.BackColor = System.Drawing.Color.Transparent
        Me.PaFrecEnDias.Controls.Add(Me.GrB_FrecEnDias)
        Me.PaFrecEnDias.Controls.Add(Me.Btn_Check2)
        Me.PaFrecEnDias.Dock = System.Windows.Forms.DockStyle.Left
        Me.PaFrecEnDias.Location = New System.Drawing.Point(570, 0)
        Me.PaFrecEnDias.Name = "PaFrecEnDias"
        Me.PaFrecEnDias.Size = New System.Drawing.Size(220, 47)
        Me.PaFrecEnDias.TabIndex = 9
        '
        'GrB_FrecEnDias
        '
        Me.GrB_FrecEnDias.BackColor = System.Drawing.Color.Transparent
        Me.GrB_FrecEnDias.Controls.Add(Me.Tb_FrecEnDias)
        Me.GrB_FrecEnDias.Controls.Add(Me.LabelX20)
        Me.GrB_FrecEnDias.Controls.Add(Me.LabelX19)
        Me.GrB_FrecEnDias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrB_FrecEnDias.Location = New System.Drawing.Point(29, 0)
        Me.GrB_FrecEnDias.Name = "GrB_FrecEnDias"
        Me.GrB_FrecEnDias.Size = New System.Drawing.Size(191, 47)
        Me.GrB_FrecEnDias.TabIndex = 2
        Me.GrB_FrecEnDias.TabStop = False
        Me.GrB_FrecEnDias.Text = "Frecuencia En Dias"
        '
        'Tb_FrecEnDias
        '
        '
        '
        '
        Me.Tb_FrecEnDias.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Tb_FrecEnDias.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_FrecEnDias.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Tb_FrecEnDias.Location = New System.Drawing.Point(61, 15)
        Me.Tb_FrecEnDias.MaxValue = 31
        Me.Tb_FrecEnDias.MinValue = 1
        Me.Tb_FrecEnDias.Name = "Tb_FrecEnDias"
        Me.Tb_FrecEnDias.ShowUpDown = True
        Me.Tb_FrecEnDias.Size = New System.Drawing.Size(45, 23)
        Me.Tb_FrecEnDias.TabIndex = 27
        Me.Tb_FrecEnDias.Value = 1
        '
        'LabelX20
        '
        '
        '
        '
        Me.LabelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX20.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX20.Location = New System.Drawing.Point(112, 15)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(35, 23)
        Me.LabelX20.TabIndex = 26
        Me.LabelX20.Text = "DIAS"
        '
        'LabelX19
        '
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX19.Location = New System.Drawing.Point(11, 15)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(44, 23)
        Me.LabelX19.TabIndex = 25
        Me.LabelX19.Text = "CADA:"
        '
        'Btn_Check2
        '
        Me.Btn_Check2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Check2.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Check2.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.Btn_Check2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Check2.ImageFixedSize = New System.Drawing.Size(20, 20)
        Me.Btn_Check2.Location = New System.Drawing.Point(0, 0)
        Me.Btn_Check2.Name = "Btn_Check2"
        Me.Btn_Check2.Size = New System.Drawing.Size(29, 47)
        Me.Btn_Check2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Check2.TabIndex = 5
        '
        'PaFrecMensual
        '
        Me.PaFrecMensual.BackColor = System.Drawing.Color.Transparent
        Me.PaFrecMensual.Controls.Add(Me.GrB_FrecMensual)
        Me.PaFrecMensual.Controls.Add(Me.Btn_Check3)
        Me.PaFrecMensual.Dock = System.Windows.Forms.DockStyle.Left
        Me.PaFrecMensual.Location = New System.Drawing.Point(350, 0)
        Me.PaFrecMensual.Name = "PaFrecMensual"
        Me.PaFrecMensual.Size = New System.Drawing.Size(220, 47)
        Me.PaFrecMensual.TabIndex = 10
        '
        'GrB_FrecMensual
        '
        Me.GrB_FrecMensual.BackColor = System.Drawing.Color.Transparent
        Me.GrB_FrecMensual.Controls.Add(Me.Tb_FrecMensual)
        Me.GrB_FrecMensual.Controls.Add(Me.LabelX22)
        Me.GrB_FrecMensual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrB_FrecMensual.Location = New System.Drawing.Point(29, 0)
        Me.GrB_FrecMensual.Name = "GrB_FrecMensual"
        Me.GrB_FrecMensual.Size = New System.Drawing.Size(191, 47)
        Me.GrB_FrecMensual.TabIndex = 6
        Me.GrB_FrecMensual.TabStop = False
        Me.GrB_FrecMensual.Text = "Frecuencia Mensual"
        '
        'Tb_FrecMensual
        '
        '
        '
        '
        Me.Tb_FrecMensual.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Tb_FrecMensual.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_FrecMensual.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Tb_FrecMensual.Location = New System.Drawing.Point(85, 15)
        Me.Tb_FrecMensual.MaxValue = 31
        Me.Tb_FrecMensual.MinValue = 1
        Me.Tb_FrecMensual.Name = "Tb_FrecMensual"
        Me.Tb_FrecMensual.ShowUpDown = True
        Me.Tb_FrecMensual.Size = New System.Drawing.Size(45, 23)
        Me.Tb_FrecMensual.TabIndex = 8
        Me.Tb_FrecMensual.Value = 1
        '
        'LabelX22
        '
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX22.Location = New System.Drawing.Point(11, 15)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(68, 23)
        Me.LabelX22.TabIndex = 25
        Me.LabelX22.Text = "EN EL DIA:"
        '
        'Btn_Check3
        '
        Me.Btn_Check3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Check3.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Check3.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.Btn_Check3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Check3.ImageFixedSize = New System.Drawing.Size(20, 20)
        Me.Btn_Check3.Location = New System.Drawing.Point(0, 0)
        Me.Btn_Check3.Name = "Btn_Check3"
        Me.Btn_Check3.Size = New System.Drawing.Size(29, 47)
        Me.Btn_Check3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Check3.TabIndex = 7
        '
        'PaFrecSem
        '
        Me.PaFrecSem.BackColor = System.Drawing.Color.Transparent
        Me.PaFrecSem.Controls.Add(Me.GrB_FrecSemanal)
        Me.PaFrecSem.Controls.Add(Me.Btn_Check1)
        Me.PaFrecSem.Dock = System.Windows.Forms.DockStyle.Left
        Me.PaFrecSem.Location = New System.Drawing.Point(0, 0)
        Me.PaFrecSem.Name = "PaFrecSem"
        Me.PaFrecSem.Size = New System.Drawing.Size(350, 47)
        Me.PaFrecSem.TabIndex = 8
        '
        'GrB_FrecSemanal
        '
        Me.GrB_FrecSemanal.BackColor = System.Drawing.Color.Transparent
        Me.GrB_FrecSemanal.Controls.Add(Me.CheckBoxX7)
        Me.GrB_FrecSemanal.Controls.Add(Me.CheckBoxX6)
        Me.GrB_FrecSemanal.Controls.Add(Me.CheckBoxX5)
        Me.GrB_FrecSemanal.Controls.Add(Me.CheckBoxX4)
        Me.GrB_FrecSemanal.Controls.Add(Me.CheckBoxX3)
        Me.GrB_FrecSemanal.Controls.Add(Me.CheckBoxX2)
        Me.GrB_FrecSemanal.Controls.Add(Me.CheckBoxX1)
        Me.GrB_FrecSemanal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrB_FrecSemanal.Location = New System.Drawing.Point(29, 0)
        Me.GrB_FrecSemanal.Name = "GrB_FrecSemanal"
        Me.GrB_FrecSemanal.Size = New System.Drawing.Size(321, 47)
        Me.GrB_FrecSemanal.TabIndex = 1
        Me.GrB_FrecSemanal.TabStop = False
        Me.GrB_FrecSemanal.Text = "Frecuencia Semanal"
        '
        'CheckBoxX7
        '
        '
        '
        '
        Me.CheckBoxX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX7.Location = New System.Drawing.Point(252, 12)
        Me.CheckBoxX7.Name = "CheckBoxX7"
        Me.CheckBoxX7.Size = New System.Drawing.Size(36, 23)
        Me.CheckBoxX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX7.TabIndex = 6
        Me.CheckBoxX7.Text = "Do"
        '
        'CheckBoxX6
        '
        '
        '
        '
        Me.CheckBoxX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX6.Location = New System.Drawing.Point(210, 12)
        Me.CheckBoxX6.Name = "CheckBoxX6"
        Me.CheckBoxX6.Size = New System.Drawing.Size(36, 23)
        Me.CheckBoxX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX6.TabIndex = 5
        Me.CheckBoxX6.Text = "Sa"
        '
        'CheckBoxX5
        '
        '
        '
        '
        Me.CheckBoxX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX5.Location = New System.Drawing.Point(172, 12)
        Me.CheckBoxX5.Name = "CheckBoxX5"
        Me.CheckBoxX5.Size = New System.Drawing.Size(36, 23)
        Me.CheckBoxX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX5.TabIndex = 4
        Me.CheckBoxX5.Text = "Vi"
        '
        'CheckBoxX4
        '
        '
        '
        '
        Me.CheckBoxX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX4.Location = New System.Drawing.Point(130, 12)
        Me.CheckBoxX4.Name = "CheckBoxX4"
        Me.CheckBoxX4.Size = New System.Drawing.Size(36, 23)
        Me.CheckBoxX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX4.TabIndex = 3
        Me.CheckBoxX4.Text = "Ju"
        '
        'CheckBoxX3
        '
        '
        '
        '
        Me.CheckBoxX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX3.Location = New System.Drawing.Point(90, 12)
        Me.CheckBoxX3.Name = "CheckBoxX3"
        Me.CheckBoxX3.Size = New System.Drawing.Size(34, 23)
        Me.CheckBoxX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX3.TabIndex = 2
        Me.CheckBoxX3.Text = "Mi"
        '
        'CheckBoxX2
        '
        '
        '
        '
        Me.CheckBoxX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX2.Location = New System.Drawing.Point(48, 12)
        Me.CheckBoxX2.Name = "CheckBoxX2"
        Me.CheckBoxX2.Size = New System.Drawing.Size(46, 23)
        Me.CheckBoxX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX2.TabIndex = 1
        Me.CheckBoxX2.Text = "Ma"
        '
        'CheckBoxX1
        '
        '
        '
        '
        Me.CheckBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX1.Location = New System.Drawing.Point(7, 12)
        Me.CheckBoxX1.Name = "CheckBoxX1"
        Me.CheckBoxX1.Size = New System.Drawing.Size(35, 23)
        Me.CheckBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX1.TabIndex = 0
        Me.CheckBoxX1.Text = "Lu"
        '
        'Btn_Check1
        '
        Me.Btn_Check1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Check1.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Check1.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.Btn_Check1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Check1.ImageFixedSize = New System.Drawing.Size(20, 20)
        Me.Btn_Check1.Location = New System.Drawing.Point(0, 0)
        Me.Btn_Check1.Name = "Btn_Check1"
        Me.Btn_Check1.Size = New System.Drawing.Size(29, 47)
        Me.Btn_Check1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Check1.TabIndex = 4
        '
        'GroupPanel5
        '
        Me.GroupPanel5.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel5.Controls.Add(Me.JGr_DetallePedido)
        Me.GroupPanel5.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel5.Location = New System.Drawing.Point(3, 234)
        Me.GroupPanel5.Name = "GroupPanel5"
        Me.GroupPanel5.Size = New System.Drawing.Size(678, 183)
        '
        '
        '
        Me.GroupPanel5.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanel5.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanel5.Style.BackColorGradientAngle = 90
        Me.GroupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderBottomWidth = 1
        Me.GroupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderLeftWidth = 1
        Me.GroupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderRightWidth = 1
        Me.GroupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderTopWidth = 1
        Me.GroupPanel5.Style.CornerDiameter = 4
        Me.GroupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel5.TabIndex = 11
        Me.GroupPanel5.Text = "DETALLE DE PEDIDO"
        '
        'JGr_DetallePedido
        '
        Me.JGr_DetallePedido.ContextMenuStrip = Me.cmQuitarDetalle
        Me.JGr_DetallePedido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JGr_DetallePedido.Location = New System.Drawing.Point(0, 0)
        Me.JGr_DetallePedido.Name = "JGr_DetallePedido"
        Me.JGr_DetallePedido.Size = New System.Drawing.Size(672, 159)
        Me.JGr_DetallePedido.TabIndex = 1
        '
        'cmQuitarDetalle
        '
        Me.cmQuitarDetalle.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmQuitarDetalle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuitarItemToolStripMenuItem})
        Me.cmQuitarDetalle.Name = "ConMenu_Clientes"
        Me.cmQuitarDetalle.Size = New System.Drawing.Size(148, 40)
        '
        'QuitarItemToolStripMenuItem
        '
        Me.QuitarItemToolStripMenuItem.Image = Global.Presentacion.My.Resources.Resources.elim_fila2
        Me.QuitarItemToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.QuitarItemToolStripMenuItem.Name = "QuitarItemToolStripMenuItem"
        Me.QuitarItemToolStripMenuItem.Size = New System.Drawing.Size(147, 36)
        Me.QuitarItemToolStripMenuItem.Text = "Quitar Item"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel3.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.PanelEx1)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel3.Location = New System.Drawing.Point(3, 3)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(678, 99)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanel3.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
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
        Me.GroupPanel3.TabIndex = 9
        Me.GroupPanel3.Text = "DATOS CLIENTE"
        '
        'PanelEx1
        '
        Me.PanelEx1.AutoScroll = True
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.tbCodCliente)
        Me.PanelEx1.Controls.Add(Me.LabelX5)
        Me.PanelEx1.Controls.Add(Me.Tb_CliEstado)
        Me.PanelEx1.Controls.Add(Me.Tb_CliCod)
        Me.PanelEx1.Controls.Add(Me.Tb_CliTelef)
        Me.PanelEx1.Controls.Add(Me.LabelX6)
        Me.PanelEx1.Controls.Add(Me.LabelX8)
        Me.PanelEx1.Controls.Add(Me.Tb_CliNombre)
        Me.PanelEx1.Controls.Add(Me.Tb_CliDireccion)
        Me.PanelEx1.Controls.Add(Me.LabelX7)
        Me.PanelEx1.Controls.Add(Me.LabelX10)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(672, 75)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 4
        '
        'tbCodCliente
        '
        Me.tbCodCliente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbCodCliente.Border.Class = "TextBoxBorder"
        Me.tbCodCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCodCliente.DisabledBackColor = System.Drawing.Color.White
        Me.tbCodCliente.ForeColor = System.Drawing.Color.Black
        Me.tbCodCliente.Location = New System.Drawing.Point(3, 61)
        Me.tbCodCliente.Name = "tbCodCliente"
        Me.tbCodCliente.PreventEnterBeep = True
        Me.tbCodCliente.Size = New System.Drawing.Size(100, 23)
        Me.tbCodCliente.TabIndex = 20
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(3, -4)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(100, 23)
        Me.LabelX5.TabIndex = 10
        Me.LabelX5.Text = "CODIGO:"
        '
        'Tb_CliEstado
        '
        Me.Tb_CliEstado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Tb_CliEstado.Border.Class = "TextBoxBorder"
        Me.Tb_CliEstado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_CliEstado.DisabledBackColor = System.Drawing.Color.White
        Me.Tb_CliEstado.ForeColor = System.Drawing.Color.Black
        Me.Tb_CliEstado.Location = New System.Drawing.Point(641, 45)
        Me.Tb_CliEstado.Name = "Tb_CliEstado"
        Me.Tb_CliEstado.PreventEnterBeep = True
        Me.Tb_CliEstado.Size = New System.Drawing.Size(150, 23)
        Me.Tb_CliEstado.TabIndex = 18
        Me.Tb_CliEstado.Visible = False
        '
        'Tb_CliCod
        '
        Me.Tb_CliCod.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Tb_CliCod.Border.Class = "TextBoxBorder"
        Me.Tb_CliCod.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_CliCod.DisabledBackColor = System.Drawing.Color.White
        Me.Tb_CliCod.ForeColor = System.Drawing.Color.Black
        Me.Tb_CliCod.Location = New System.Drawing.Point(3, 19)
        Me.Tb_CliCod.Name = "Tb_CliCod"
        Me.Tb_CliCod.PreventEnterBeep = True
        Me.Tb_CliCod.Size = New System.Drawing.Size(100, 23)
        Me.Tb_CliCod.TabIndex = 11
        '
        'Tb_CliTelef
        '
        Me.Tb_CliTelef.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Tb_CliTelef.Border.Class = "TextBoxBorder"
        Me.Tb_CliTelef.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_CliTelef.DisabledBackColor = System.Drawing.Color.White
        Me.Tb_CliTelef.ForeColor = System.Drawing.Color.Black
        Me.Tb_CliTelef.Location = New System.Drawing.Point(641, 19)
        Me.Tb_CliTelef.Name = "Tb_CliTelef"
        Me.Tb_CliTelef.PreventEnterBeep = True
        Me.Tb_CliTelef.Size = New System.Drawing.Size(150, 23)
        Me.Tb_CliTelef.TabIndex = 17
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(109, -4)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(114, 23)
        Me.LabelX6.TabIndex = 12
        Me.LabelX6.Text = "NOMBRE:"
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Location = New System.Drawing.Point(641, -4)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(97, 23)
        Me.LabelX8.TabIndex = 16
        Me.LabelX8.Text = "TELEFONO:"
        '
        'Tb_CliNombre
        '
        Me.Tb_CliNombre.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Tb_CliNombre.Border.Class = "TextBoxBorder"
        Me.Tb_CliNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_CliNombre.DisabledBackColor = System.Drawing.Color.White
        Me.Tb_CliNombre.ForeColor = System.Drawing.Color.Black
        Me.Tb_CliNombre.Location = New System.Drawing.Point(109, 19)
        Me.Tb_CliNombre.Multiline = True
        Me.Tb_CliNombre.Name = "Tb_CliNombre"
        Me.Tb_CliNombre.PreventEnterBeep = True
        Me.Tb_CliNombre.Size = New System.Drawing.Size(215, 65)
        Me.Tb_CliNombre.TabIndex = 13
        '
        'Tb_CliDireccion
        '
        Me.Tb_CliDireccion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Tb_CliDireccion.Border.Class = "TextBoxBorder"
        Me.Tb_CliDireccion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_CliDireccion.DisabledBackColor = System.Drawing.Color.White
        Me.Tb_CliDireccion.ForeColor = System.Drawing.Color.Black
        Me.Tb_CliDireccion.Location = New System.Drawing.Point(330, 19)
        Me.Tb_CliDireccion.Multiline = True
        Me.Tb_CliDireccion.Name = "Tb_CliDireccion"
        Me.Tb_CliDireccion.PreventEnterBeep = True
        Me.Tb_CliDireccion.Size = New System.Drawing.Size(291, 65)
        Me.Tb_CliDireccion.TabIndex = 15
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(330, -4)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(135, 23)
        Me.LabelX7.TabIndex = 14
        Me.LabelX7.Text = "DIRECCION:"
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Location = New System.Drawing.Point(3, 38)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(98, 23)
        Me.LabelX10.TabIndex = 19
        Me.LabelX10.Text = "COD CLIENTE:"
        '
        'GroupPanel4
        '
        Me.GroupPanel4.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.PanelEx2)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel4.Location = New System.Drawing.Point(3, 108)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(678, 120)
        '
        '
        '
        Me.GroupPanel4.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanel4.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanel4.Style.BackColorGradientAngle = 90
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
        Me.GroupPanel4.TabIndex = 10
        Me.GroupPanel4.Text = "DATOS PEDIDO"
        '
        'PanelEx2
        '
        Me.PanelEx2.AutoScroll = True
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.LabelX12)
        Me.PanelEx2.Controls.Add(Me.LabelX1)
        Me.PanelEx2.Controls.Add(Me.cbPreVendedor)
        Me.PanelEx2.Controls.Add(Me.cbDistribuidor)
        Me.PanelEx2.Controls.Add(Me.Btn_GenerarPedidos)
        Me.PanelEx2.Controls.Add(Me.Tb_Estado)
        Me.PanelEx2.Controls.Add(Me.Lb_Estado)
        Me.PanelEx2.Controls.Add(Me.Tb_CliCateg)
        Me.PanelEx2.Controls.Add(Me.Tb_CliCodZona)
        Me.PanelEx2.Controls.Add(Me.LabelX9)
        Me.PanelEx2.Controls.Add(Me.Tb_Observaciones)
        Me.PanelEx2.Controls.Add(Me.Tb_Zona)
        Me.PanelEx2.Controls.Add(Me.LabelX4)
        Me.PanelEx2.Controls.Add(Me.Tb_Hora)
        Me.PanelEx2.Controls.Add(Me.LabelX3)
        Me.PanelEx2.Controls.Add(Me.Tb_Fecha)
        Me.PanelEx2.Controls.Add(Me.LabelX11)
        Me.PanelEx2.Controls.Add(Me.LabelX14)
        Me.PanelEx2.Controls.Add(Me.Tb_Id)
        Me.PanelEx2.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx2.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(672, 96)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PanelEx2.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PanelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.TabIndex = 8
        '
        'LabelX12
        '
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Location = New System.Drawing.Point(527, 0)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(120, 23)
        Me.LabelX12.TabIndex = 39
        Me.LabelX12.Text = "PRE-VENDEDOR:"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(235, 0)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(100, 23)
        Me.LabelX1.TabIndex = 38
        Me.LabelX1.Text = "DISTRIBUIDOR:"
        '
        'cbPreVendedor
        '
        cbPreVendedor_DesignTimeLayout.LayoutString = resources.GetString("cbPreVendedor_DesignTimeLayout.LayoutString")
        Me.cbPreVendedor.DesignTimeLayout = cbPreVendedor_DesignTimeLayout
        Me.cbPreVendedor.Location = New System.Drawing.Point(653, 0)
        Me.cbPreVendedor.Name = "cbPreVendedor"
        Me.cbPreVendedor.SelectedIndex = -1
        Me.cbPreVendedor.SelectedItem = Nothing
        Me.cbPreVendedor.Size = New System.Drawing.Size(180, 23)
        Me.cbPreVendedor.TabIndex = 37
        '
        'cbDistribuidor
        '
        cbDistribuidor_DesignTimeLayout.LayoutString = resources.GetString("cbDistribuidor_DesignTimeLayout.LayoutString")
        Me.cbDistribuidor.DesignTimeLayout = cbDistribuidor_DesignTimeLayout
        Me.cbDistribuidor.Location = New System.Drawing.Point(341, 0)
        Me.cbDistribuidor.Name = "cbDistribuidor"
        Me.cbDistribuidor.SelectedIndex = -1
        Me.cbDistribuidor.SelectedItem = Nothing
        Me.cbDistribuidor.Size = New System.Drawing.Size(180, 23)
        Me.cbDistribuidor.TabIndex = 36
        '
        'Btn_GenerarPedidos
        '
        Me.Btn_GenerarPedidos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_GenerarPedidos.BackColor = System.Drawing.Color.Transparent
        Me.Btn_GenerarPedidos.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.Btn_GenerarPedidos.Image = Global.Presentacion.My.Resources.Resources.GEN_PEDIDOS_AUTOMATICAMENTE_ORI
        Me.Btn_GenerarPedidos.ImageFixedSize = New System.Drawing.Size(35, 35)
        Me.Btn_GenerarPedidos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_GenerarPedidos.Location = New System.Drawing.Point(675, 53)
        Me.Btn_GenerarPedidos.Name = "Btn_GenerarPedidos"
        Me.Btn_GenerarPedidos.Size = New System.Drawing.Size(200, 55)
        Me.Btn_GenerarPedidos.TabIndex = 35
        Me.Btn_GenerarPedidos.Text = "GENERAR PEDIDOS"
        Me.Btn_GenerarPedidos.TextColor = System.Drawing.Color.Navy
        '
        'Tb_Estado
        '
        '
        '
        '
        Me.Tb_Estado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_Estado.Location = New System.Drawing.Point(198, 111)
        Me.Tb_Estado.Name = "Tb_Estado"
        Me.Tb_Estado.OffText = "INACTIVO"
        Me.Tb_Estado.OnText = "ACTIVO"
        Me.Tb_Estado.Size = New System.Drawing.Size(88, 22)
        Me.Tb_Estado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Tb_Estado.TabIndex = 34
        '
        'Lb_Estado
        '
        '
        '
        '
        Me.Lb_Estado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lb_Estado.Location = New System.Drawing.Point(128, 110)
        Me.Lb_Estado.Name = "Lb_Estado"
        Me.Lb_Estado.Size = New System.Drawing.Size(64, 23)
        Me.Lb_Estado.TabIndex = 33
        Me.Lb_Estado.Text = "ESTADO:"
        '
        'Tb_CliCateg
        '
        Me.Tb_CliCateg.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Tb_CliCateg.Border.Class = "TextBoxBorder"
        Me.Tb_CliCateg.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_CliCateg.DisabledBackColor = System.Drawing.Color.White
        Me.Tb_CliCateg.ForeColor = System.Drawing.Color.Black
        Me.Tb_CliCateg.Location = New System.Drawing.Point(3, 79)
        Me.Tb_CliCateg.Name = "Tb_CliCateg"
        Me.Tb_CliCateg.PreventEnterBeep = True
        Me.Tb_CliCateg.Size = New System.Drawing.Size(80, 23)
        Me.Tb_CliCateg.TabIndex = 30
        Me.Tb_CliCateg.Visible = False
        '
        'Tb_CliCodZona
        '
        Me.Tb_CliCodZona.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Tb_CliCodZona.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_CliCodZona.DisabledBackColor = System.Drawing.Color.White
        Me.Tb_CliCodZona.ForeColor = System.Drawing.Color.Black
        Me.Tb_CliCodZona.Location = New System.Drawing.Point(292, 111)
        Me.Tb_CliCodZona.Multiline = True
        Me.Tb_CliCodZona.Name = "Tb_CliCodZona"
        Me.Tb_CliCodZona.PreventEnterBeep = True
        Me.Tb_CliCodZona.Size = New System.Drawing.Size(80, 20)
        Me.Tb_CliCodZona.TabIndex = 29
        Me.Tb_CliCodZona.Visible = False
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Location = New System.Drawing.Point(1, 50)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(122, 23)
        Me.LabelX9.TabIndex = 32
        Me.LabelX9.Text = "OBSERVACIONES:"
        '
        'Tb_Observaciones
        '
        Me.Tb_Observaciones.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Tb_Observaciones.Border.Class = "TextBoxBorder"
        Me.Tb_Observaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_Observaciones.DisabledBackColor = System.Drawing.Color.White
        Me.Tb_Observaciones.ForeColor = System.Drawing.Color.Black
        Me.Tb_Observaciones.Location = New System.Drawing.Point(128, 53)
        Me.Tb_Observaciones.MaxLength = 100
        Me.Tb_Observaciones.Multiline = True
        Me.Tb_Observaciones.Name = "Tb_Observaciones"
        Me.Tb_Observaciones.PreventEnterBeep = True
        Me.Tb_Observaciones.Size = New System.Drawing.Size(521, 55)
        Me.Tb_Observaciones.TabIndex = 22
        '
        'Tb_Zona
        '
        Me.Tb_Zona.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Tb_Zona.Border.Class = "TextBoxBorder"
        Me.Tb_Zona.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_Zona.DisabledBackColor = System.Drawing.Color.White
        Me.Tb_Zona.ForeColor = System.Drawing.Color.Black
        Me.Tb_Zona.Location = New System.Drawing.Point(459, 27)
        Me.Tb_Zona.Name = "Tb_Zona"
        Me.Tb_Zona.PreventEnterBeep = True
        Me.Tb_Zona.Size = New System.Drawing.Size(190, 23)
        Me.Tb_Zona.TabIndex = 27
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(398, 27)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(55, 23)
        Me.LabelX4.TabIndex = 31
        Me.LabelX4.Text = "ZONA:"
        '
        'Tb_Hora
        '
        Me.Tb_Hora.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Tb_Hora.Border.Class = "TextBoxBorder"
        Me.Tb_Hora.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_Hora.DisabledBackColor = System.Drawing.Color.White
        Me.Tb_Hora.ForeColor = System.Drawing.Color.Black
        Me.Tb_Hora.Location = New System.Drawing.Point(304, 26)
        Me.Tb_Hora.Name = "Tb_Hora"
        Me.Tb_Hora.PreventEnterBeep = True
        Me.Tb_Hora.Size = New System.Drawing.Size(88, 23)
        Me.Tb_Hora.TabIndex = 26
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(235, 26)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(63, 23)
        Me.LabelX3.TabIndex = 28
        Me.LabelX3.Text = "HORA:"
        '
        'Tb_Fecha
        '
        Me.Tb_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Tb_Fecha.Location = New System.Drawing.Point(92, 27)
        Me.Tb_Fecha.Name = "Tb_Fecha"
        Me.Tb_Fecha.Size = New System.Drawing.Size(137, 23)
        Me.Tb_Fecha.TabIndex = 21
        '
        'LabelX11
        '
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Location = New System.Drawing.Point(15, 26)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(68, 23)
        Me.LabelX11.TabIndex = 24
        Me.LabelX11.Text = "FECHA:"
        '
        'LabelX14
        '
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Location = New System.Drawing.Point(15, -1)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(68, 23)
        Me.LabelX14.TabIndex = 23
        Me.LabelX14.Text = "CODIGO:"
        '
        'Tb_Id
        '
        Me.Tb_Id.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Tb_Id.Border.Class = "TextBoxBorder"
        Me.Tb_Id.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_Id.DisabledBackColor = System.Drawing.Color.White
        Me.Tb_Id.ForeColor = System.Drawing.Color.Black
        Me.Tb_Id.Location = New System.Drawing.Point(92, 0)
        Me.Tb_Id.Name = "Tb_Id"
        Me.Tb_Id.PreventEnterBeep = True
        Me.Tb_Id.Size = New System.Drawing.Size(137, 23)
        Me.Tb_Id.TabIndex = 25
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.GroupPanel1, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupPanel2, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(693, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(290, 497)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.PanelEx4)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Location = New System.Drawing.Point(3, 201)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(284, 293)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
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
        Me.GroupPanel1.TabIndex = 3
        Me.GroupPanel1.Text = "SELECCIONAR PRODUCTO"
        '
        'PanelEx4
        '
        Me.PanelEx4.AutoScroll = True
        Me.PanelEx4.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx4.Controls.Add(Me.Tb_CantProd)
        Me.PanelEx4.Controls.Add(Me.Btn_AddProd)
        Me.PanelEx4.Controls.Add(Me.Btn_TerminarAdd)
        Me.PanelEx4.Controls.Add(Me.LabelX2)
        Me.PanelEx4.Controls.Add(Me.JGr_Productos)
        Me.PanelEx4.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx4.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx4.Name = "PanelEx4"
        Me.PanelEx4.Size = New System.Drawing.Size(278, 269)
        Me.PanelEx4.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx4.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PanelEx4.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PanelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx4.Style.GradientAngle = 90
        Me.PanelEx4.TabIndex = 25
        '
        'Tb_CantProd
        '
        '
        '
        '
        Me.Tb_CantProd.Border.Class = "TextBoxBorder"
        Me.Tb_CantProd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_CantProd.Location = New System.Drawing.Point(72, 232)
        Me.Tb_CantProd.Name = "Tb_CantProd"
        Me.Tb_CantProd.PreventEnterBeep = True
        Me.Tb_CantProd.Size = New System.Drawing.Size(100, 23)
        Me.Tb_CantProd.TabIndex = 27
        '
        'Btn_AddProd
        '
        Me.Btn_AddProd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_AddProd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_AddProd.Image = Global.Presentacion.My.Resources.Resources.add21
        Me.Btn_AddProd.ImageFixedSize = New System.Drawing.Size(40, 40)
        Me.Btn_AddProd.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_AddProd.Location = New System.Drawing.Point(259, 226)
        Me.Btn_AddProd.Name = "Btn_AddProd"
        Me.Btn_AddProd.Size = New System.Drawing.Size(75, 58)
        Me.Btn_AddProd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_AddProd.TabIndex = 5
        Me.Btn_AddProd.Text = "Adicionar"
        '
        'Btn_TerminarAdd
        '
        Me.Btn_TerminarAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_TerminarAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_TerminarAdd.Image = Global.Presentacion.My.Resources.Resources.GRABAR
        Me.Btn_TerminarAdd.ImageFixedSize = New System.Drawing.Size(40, 40)
        Me.Btn_TerminarAdd.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_TerminarAdd.Location = New System.Drawing.Point(178, 226)
        Me.Btn_TerminarAdd.Name = "Btn_TerminarAdd"
        Me.Btn_TerminarAdd.Size = New System.Drawing.Size(75, 58)
        Me.Btn_TerminarAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_TerminarAdd.TabIndex = 4
        Me.Btn_TerminarAdd.Text = "Terminar"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(4, 232)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(62, 23)
        Me.LabelX2.TabIndex = 0
        Me.LabelX2.Text = "Cantidad:"
        '
        'JGr_Productos
        '
        Me.JGr_Productos.Dock = System.Windows.Forms.DockStyle.Top
        Me.JGr_Productos.Location = New System.Drawing.Point(0, 0)
        Me.JGr_Productos.Name = "JGr_Productos"
        Me.JGr_Productos.Size = New System.Drawing.Size(334, 220)
        Me.JGr_Productos.TabIndex = 0
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.PanelEx3)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel2.Location = New System.Drawing.Point(3, 3)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(284, 192)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
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
        Me.GroupPanel2.TabIndex = 1
        Me.GroupPanel2.Text = "SELECCIONAR CATEGORIA"
        '
        'PanelEx3
        '
        Me.PanelEx3.AutoScroll = True
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.JGr_TipoProd)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx3.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(278, 168)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PanelEx3.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 18
        '
        'JGr_TipoProd
        '
        Me.JGr_TipoProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JGr_TipoProd.Location = New System.Drawing.Point(0, 0)
        Me.JGr_TipoProd.Name = "JGr_TipoProd"
        Me.JGr_TipoProd.Size = New System.Drawing.Size(278, 168)
        Me.JGr_TipoProd.TabIndex = 0
        '
        'SuperTabItemCliente
        '
        Me.SuperTabItemCliente.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItemCliente.GlobalItem = False
        Me.SuperTabItemCliente.Name = "SuperTabItemCliente"
        Me.SuperTabItemCliente.Text = "CLIENTE"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.TableLayoutPanel4)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(1312, 503)
        Me.SuperTabControlPanel1.TabIndex = 0
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItemCliente
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel5, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel6, 1, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(1312, 503)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.GroupPanel10, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.GroupPanel8, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(912, 497)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'GroupPanel10
        '
        Me.GroupPanel10.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel10.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel10.Controls.Add(Me.JGr_Reclamos)
        Me.GroupPanel10.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel10.Location = New System.Drawing.Point(3, 375)
        Me.GroupPanel10.Name = "GroupPanel10"
        Me.GroupPanel10.Size = New System.Drawing.Size(906, 119)
        '
        '
        '
        Me.GroupPanel10.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanel10.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanel10.Style.BackColorGradientAngle = 90
        Me.GroupPanel10.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel10.Style.BorderBottomWidth = 1
        Me.GroupPanel10.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel10.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel10.Style.BorderLeftWidth = 1
        Me.GroupPanel10.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel10.Style.BorderRightWidth = 1
        Me.GroupPanel10.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel10.Style.BorderTopWidth = 1
        Me.GroupPanel10.Style.CornerDiameter = 4
        Me.GroupPanel10.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel10.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel10.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel10.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel10.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel10.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel10.TabIndex = 12
        Me.GroupPanel10.Text = "R E C L A M O S      G R A B A D O S"
        '
        'JGr_Reclamos
        '
        Me.JGr_Reclamos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JGr_Reclamos.Location = New System.Drawing.Point(0, 0)
        Me.JGr_Reclamos.Name = "JGr_Reclamos"
        Me.JGr_Reclamos.Size = New System.Drawing.Size(900, 95)
        Me.JGr_Reclamos.TabIndex = 1
        '
        'GroupPanel8
        '
        Me.GroupPanel8.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel8.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel8.Controls.Add(Me.JGr_Clientes)
        Me.GroupPanel8.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel8.Location = New System.Drawing.Point(3, 3)
        Me.GroupPanel8.Name = "GroupPanel8"
        Me.GroupPanel8.Size = New System.Drawing.Size(906, 366)
        '
        '
        '
        Me.GroupPanel8.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanel8.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanel8.Style.BackColorGradientAngle = 90
        Me.GroupPanel8.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel8.Style.BorderBottomWidth = 1
        Me.GroupPanel8.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel8.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel8.Style.BorderLeftWidth = 1
        Me.GroupPanel8.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel8.Style.BorderRightWidth = 1
        Me.GroupPanel8.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel8.Style.BorderTopWidth = 1
        Me.GroupPanel8.Style.CornerDiameter = 4
        Me.GroupPanel8.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel8.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel8.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel8.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel8.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel8.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel8.TabIndex = 0
        Me.GroupPanel8.Text = "BUSQUEDA CLIENTES"
        '
        'JGr_Clientes
        '
        Me.JGr_Clientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JGr_Clientes.Location = New System.Drawing.Point(0, 0)
        Me.JGr_Clientes.Name = "JGr_Clientes"
        Me.JGr_Clientes.Size = New System.Drawing.Size(900, 342)
        Me.JGr_Clientes.TabIndex = 1
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.GroupPanel12, 0, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.GroupPanel11, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.GroupPanel9, 0, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(921, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 3
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(388, 497)
        Me.TableLayoutPanel6.TabIndex = 1
        '
        'GroupPanel12
        '
        Me.GroupPanel12.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel12.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel12.Controls.Add(Me.Tb_DireccionDetalle)
        Me.GroupPanel12.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel12.Location = New System.Drawing.Point(3, 400)
        Me.GroupPanel12.Name = "GroupPanel12"
        Me.GroupPanel12.Size = New System.Drawing.Size(382, 94)
        '
        '
        '
        Me.GroupPanel12.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanel12.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanel12.Style.BackColorGradientAngle = 90
        Me.GroupPanel12.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel12.Style.BorderBottomWidth = 1
        Me.GroupPanel12.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel12.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel12.Style.BorderLeftWidth = 1
        Me.GroupPanel12.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel12.Style.BorderRightWidth = 1
        Me.GroupPanel12.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel12.Style.BorderTopWidth = 1
        Me.GroupPanel12.Style.CornerDiameter = 4
        Me.GroupPanel12.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel12.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel12.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel12.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel12.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel12.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel12.TabIndex = 3
        Me.GroupPanel12.Text = "DIRECCION DEL CLIENTE"
        '
        'Tb_DireccionDetalle
        '
        '
        '
        '
        Me.Tb_DireccionDetalle.Border.Class = "TextBoxBorder"
        Me.Tb_DireccionDetalle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_DireccionDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tb_DireccionDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb_DireccionDetalle.Location = New System.Drawing.Point(0, 0)
        Me.Tb_DireccionDetalle.Multiline = True
        Me.Tb_DireccionDetalle.Name = "Tb_DireccionDetalle"
        Me.Tb_DireccionDetalle.PreventEnterBeep = True
        Me.Tb_DireccionDetalle.ReadOnly = True
        Me.Tb_DireccionDetalle.Size = New System.Drawing.Size(376, 70)
        Me.Tb_DireccionDetalle.TabIndex = 0
        '
        'GroupPanel11
        '
        Me.GroupPanel11.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel11.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel11.Controls.Add(Me.PanelEx6)
        Me.GroupPanel11.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel11.Location = New System.Drawing.Point(3, 251)
        Me.GroupPanel11.Name = "GroupPanel11"
        Me.GroupPanel11.Size = New System.Drawing.Size(382, 143)
        '
        '
        '
        Me.GroupPanel11.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanel11.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanel11.Style.BackColorGradientAngle = 90
        Me.GroupPanel11.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel11.Style.BorderBottomWidth = 1
        Me.GroupPanel11.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel11.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel11.Style.BorderLeftWidth = 1
        Me.GroupPanel11.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel11.Style.BorderRightWidth = 1
        Me.GroupPanel11.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel11.Style.BorderTopWidth = 1
        Me.GroupPanel11.Style.CornerDiameter = 4
        Me.GroupPanel11.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel11.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel11.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel11.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel11.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel11.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel11.TabIndex = 2
        Me.GroupPanel11.Text = "OBSERVACIONES"
        '
        'PanelEx6
        '
        Me.PanelEx6.AutoScroll = True
        Me.PanelEx6.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx6.Controls.Add(Me.Tb_Obs2)
        Me.PanelEx6.Controls.Add(Me.Tb_Obs)
        Me.PanelEx6.Controls.Add(Me.LabelX21)
        Me.PanelEx6.Controls.Add(Me.LabelX23)
        Me.PanelEx6.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx6.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx6.Name = "PanelEx6"
        Me.PanelEx6.Size = New System.Drawing.Size(376, 119)
        Me.PanelEx6.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx6.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PanelEx6.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PanelEx6.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx6.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx6.Style.GradientAngle = 90
        Me.PanelEx6.TabIndex = 4
        '
        'Tb_Obs2
        '
        '
        '
        '
        Me.Tb_Obs2.Border.Class = "TextBoxBorder"
        Me.Tb_Obs2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_Obs2.Location = New System.Drawing.Point(4, 80)
        Me.Tb_Obs2.Multiline = True
        Me.Tb_Obs2.Name = "Tb_Obs2"
        Me.Tb_Obs2.PreventEnterBeep = True
        Me.Tb_Obs2.Size = New System.Drawing.Size(320, 40)
        Me.Tb_Obs2.TabIndex = 3
        Me.Tb_Obs2.Visible = False
        '
        'Tb_Obs
        '
        '
        '
        '
        Me.Tb_Obs.Border.Class = "TextBoxBorder"
        Me.Tb_Obs.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_Obs.Location = New System.Drawing.Point(4, 23)
        Me.Tb_Obs.Multiline = True
        Me.Tb_Obs.Name = "Tb_Obs"
        Me.Tb_Obs.PreventEnterBeep = True
        Me.Tb_Obs.Size = New System.Drawing.Size(320, 40)
        Me.Tb_Obs.TabIndex = 0
        '
        'LabelX21
        '
        '
        '
        '
        Me.LabelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX21.Location = New System.Drawing.Point(4, 60)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(114, 23)
        Me.LabelX21.TabIndex = 2
        Me.LabelX21.Text = "OBS. ADICIONAL:"
        Me.LabelX21.Visible = False
        '
        'LabelX23
        '
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Location = New System.Drawing.Point(4, 3)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(104, 23)
        Me.LabelX23.TabIndex = 1
        Me.LabelX23.Text = "OBSERVACION:"
        '
        'GroupPanel9
        '
        Me.GroupPanel9.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel9.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel9.Controls.Add(Me.PanelEx5)
        Me.GroupPanel9.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel9.Location = New System.Drawing.Point(3, 3)
        Me.GroupPanel9.Name = "GroupPanel9"
        Me.GroupPanel9.Size = New System.Drawing.Size(382, 242)
        '
        '
        '
        Me.GroupPanel9.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanel9.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanel9.Style.BackColorGradientAngle = 90
        Me.GroupPanel9.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel9.Style.BorderBottomWidth = 1
        Me.GroupPanel9.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel9.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel9.Style.BorderLeftWidth = 1
        Me.GroupPanel9.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel9.Style.BorderRightWidth = 1
        Me.GroupPanel9.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel9.Style.BorderTopWidth = 1
        Me.GroupPanel9.Style.CornerDiameter = 4
        Me.GroupPanel9.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel9.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel9.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel9.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel9.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel9.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel9.TabIndex = 1
        Me.GroupPanel9.Text = "ULTIMOS PEDIDOS"
        '
        'PanelEx5
        '
        Me.PanelEx5.AutoScroll = True
        Me.PanelEx5.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx5.Controls.Add(Me.JGr_UltimosPedidos)
        Me.PanelEx5.Controls.Add(Me.Tb_TotalPedidos3Meses)
        Me.PanelEx5.Controls.Add(Me.LabelX18)
        Me.PanelEx5.Controls.Add(Me.LabelX16)
        Me.PanelEx5.Controls.Add(Me.Tb_PromCosumo)
        Me.PanelEx5.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx5.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx5.Name = "PanelEx5"
        Me.PanelEx5.Size = New System.Drawing.Size(376, 218)
        Me.PanelEx5.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx5.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PanelEx5.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PanelEx5.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx5.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx5.Style.GradientAngle = 90
        Me.PanelEx5.TabIndex = 14
        '
        'JGr_UltimosPedidos
        '
        Me.JGr_UltimosPedidos.Dock = System.Windows.Forms.DockStyle.Top
        Me.JGr_UltimosPedidos.Location = New System.Drawing.Point(0, 0)
        Me.JGr_UltimosPedidos.Name = "JGr_UltimosPedidos"
        Me.JGr_UltimosPedidos.Size = New System.Drawing.Size(359, 170)
        Me.JGr_UltimosPedidos.TabIndex = 0
        '
        'Tb_TotalPedidos3Meses
        '
        Me.Tb_TotalPedidos3Meses.Location = New System.Drawing.Point(241, 176)
        Me.Tb_TotalPedidos3Meses.Name = "Tb_TotalPedidos3Meses"
        Me.Tb_TotalPedidos3Meses.Size = New System.Drawing.Size(69, 23)
        Me.Tb_TotalPedidos3Meses.TabIndex = 13
        Me.Tb_TotalPedidos3Meses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX18
        '
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Location = New System.Drawing.Point(0, 205)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(239, 23)
        Me.LabelX18.TabIndex = 9
        Me.LabelX18.Text = "PROMEDIO CONSUMO EN DIAS.......:"
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Location = New System.Drawing.Point(0, 176)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(239, 23)
        Me.LabelX16.TabIndex = 12
        Me.LabelX16.Text = "TOTAL PEDIDOS ULTIMOS 3 MESES:"
        '
        'Tb_PromCosumo
        '
        Me.Tb_PromCosumo.Location = New System.Drawing.Point(241, 205)
        Me.Tb_PromCosumo.Name = "Tb_PromCosumo"
        Me.Tb_PromCosumo.Size = New System.Drawing.Size(69, 23)
        Me.Tb_PromCosumo.TabIndex = 11
        Me.Tb_PromCosumo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.GroupPanel7, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.GroupPanel6, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(990, 516)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'GroupPanel7
        '
        Me.GroupPanel7.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel7.Controls.Add(Me.JGr_Buscador)
        Me.GroupPanel7.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel7.Location = New System.Drawing.Point(3, 93)
        Me.GroupPanel7.Name = "GroupPanel7"
        Me.GroupPanel7.Size = New System.Drawing.Size(984, 420)
        '
        '
        '
        Me.GroupPanel7.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanel7.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanel7.Style.BackColorGradientAngle = 90
        Me.GroupPanel7.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel7.Style.BorderBottomWidth = 1
        Me.GroupPanel7.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel7.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel7.Style.BorderLeftWidth = 1
        Me.GroupPanel7.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel7.Style.BorderRightWidth = 1
        Me.GroupPanel7.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel7.Style.BorderTopWidth = 1
        Me.GroupPanel7.Style.CornerDiameter = 4
        Me.GroupPanel7.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel7.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel7.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel7.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel7.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel7.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel7.TabIndex = 1
        Me.GroupPanel7.Text = "BUSQUEDA GENERAL"
        '
        'JGr_Buscador
        '
        Me.JGr_Buscador.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JGr_Buscador.Location = New System.Drawing.Point(0, 0)
        Me.JGr_Buscador.Name = "JGr_Buscador"
        Me.JGr_Buscador.Size = New System.Drawing.Size(978, 396)
        Me.JGr_Buscador.TabIndex = 1
        '
        'GroupPanel6
        '
        Me.GroupPanel6.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel6.Controls.Add(Me.PanelEx9)
        Me.GroupPanel6.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel6.Location = New System.Drawing.Point(3, 3)
        Me.GroupPanel6.Name = "GroupPanel6"
        Me.GroupPanel6.Size = New System.Drawing.Size(984, 84)
        '
        '
        '
        Me.GroupPanel6.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanel6.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanel6.Style.BackColorGradientAngle = 90
        Me.GroupPanel6.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderBottomWidth = 1
        Me.GroupPanel6.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel6.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderLeftWidth = 1
        Me.GroupPanel6.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderRightWidth = 1
        Me.GroupPanel6.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderTopWidth = 1
        Me.GroupPanel6.Style.CornerDiameter = 4
        Me.GroupPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel6.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel6.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel6.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel6.TabIndex = 0
        Me.GroupPanel6.Text = "FILTRO GENERAL"
        '
        'PanelEx9
        '
        Me.PanelEx9.AutoScroll = True
        Me.PanelEx9.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx9.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx9.Controls.Add(Me.ButtonX3)
        Me.PanelEx9.Controls.Add(Me.btBuscar)
        Me.PanelEx9.Controls.Add(Me.LabelX17)
        Me.PanelEx9.Controls.Add(Me.tbFechaAl)
        Me.PanelEx9.Controls.Add(Me.LabelX15)
        Me.PanelEx9.Controls.Add(Me.tbFechaDel)
        Me.PanelEx9.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx9.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx9.Name = "PanelEx9"
        Me.PanelEx9.Size = New System.Drawing.Size(978, 60)
        Me.PanelEx9.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx9.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PanelEx9.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PanelEx9.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx9.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx9.Style.GradientAngle = 90
        Me.PanelEx9.TabIndex = 5
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.ButtonX3.Location = New System.Drawing.Point(612, 8)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(213, 49)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX3.TabIndex = 5
        Me.ButtonX3.Text = "MOSTRAR ULTIMOS 100 PEDIDOS"
        '
        'btBuscar
        '
        Me.btBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btBuscar.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btBuscar.Location = New System.Drawing.Point(462, 8)
        Me.btBuscar.Name = "btBuscar"
        Me.btBuscar.Size = New System.Drawing.Size(144, 49)
        Me.btBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btBuscar.TabIndex = 4
        Me.btBuscar.Text = "BUSCAR POR FECHA"
        '
        'LabelX17
        '
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Location = New System.Drawing.Point(234, 16)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(53, 23)
        Me.LabelX17.TabIndex = 3
        Me.LabelX17.Text = "AL:"
        '
        'tbFechaAl
        '
        Me.tbFechaAl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tbFechaAl.Location = New System.Drawing.Point(293, 16)
        Me.tbFechaAl.Name = "tbFechaAl"
        Me.tbFechaAl.Size = New System.Drawing.Size(124, 23)
        Me.tbFechaAl.TabIndex = 2
        '
        'LabelX15
        '
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Location = New System.Drawing.Point(12, 16)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(53, 23)
        Me.LabelX15.TabIndex = 1
        Me.LabelX15.Text = "DEL:"
        '
        'tbFechaDel
        '
        Me.tbFechaDel.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tbFechaDel.Location = New System.Drawing.Point(71, 16)
        Me.tbFechaDel.Name = "tbFechaDel"
        Me.tbFechaDel.Size = New System.Drawing.Size(124, 23)
        Me.tbFechaDel.TabIndex = 0
        '
        'ConMenu_Clientes
        '
        Me.ConMenu_Clientes.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ConMenu_Clientes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ACTUALIZARCLIENTESToolStripMenuItem, Me.VERCLIENTESPASIVOSYACTIVOSToolStripMenuItem, Me.VERCLIENTESACTIVOSToolStripMenuItem})
        Me.ConMenu_Clientes.Name = "ConMenu_Clientes"
        Me.ConMenu_Clientes.Size = New System.Drawing.Size(256, 70)
        '
        'ACTUALIZARCLIENTESToolStripMenuItem
        '
        Me.ACTUALIZARCLIENTESToolStripMenuItem.Name = "ACTUALIZARCLIENTESToolStripMenuItem"
        Me.ACTUALIZARCLIENTESToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.ACTUALIZARCLIENTESToolStripMenuItem.Text = "ACTUALIZAR CLIENTES"
        '
        'VERCLIENTESPASIVOSYACTIVOSToolStripMenuItem
        '
        Me.VERCLIENTESPASIVOSYACTIVOSToolStripMenuItem.Name = "VERCLIENTESPASIVOSYACTIVOSToolStripMenuItem"
        Me.VERCLIENTESPASIVOSYACTIVOSToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.VERCLIENTESPASIVOSYACTIVOSToolStripMenuItem.Text = "VER CLIENTES PASIVOS Y ACTIVOS"
        '
        'VERCLIENTESACTIVOSToolStripMenuItem
        '
        Me.VERCLIENTESACTIVOSToolStripMenuItem.Name = "VERCLIENTESACTIVOSToolStripMenuItem"
        Me.VERCLIENTESACTIVOSToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.VERCLIENTESACTIVOSToolStripMenuItem.Text = "VER CLIENTES ACTIVOS"
        '
        'ConMenu_Buscador
        '
        Me.ConMenu_Buscador.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ConMenu_Buscador.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VERHISTORIALToolStripMenuItem})
        Me.ConMenu_Buscador.Name = "ConMenu_Buscador"
        Me.ConMenu_Buscador.Size = New System.Drawing.Size(146, 26)
        '
        'VERHISTORIALToolStripMenuItem
        '
        Me.VERHISTORIALToolStripMenuItem.Name = "VERHISTORIALToolStripMenuItem"
        Me.VERHISTORIALToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.VERHISTORIALToolStripMenuItem.Text = "VER ESTADOS"
        '
        'ConMenu_Opciones1
        '
        Me.ConMenu_Opciones1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ConMenu_Opciones1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.GRABARRECLAMOREPARTIDORToolStripMenuItem, Me.VERHISTORIALToolStripMenuItem1, Me.REGERARPEDIDOToolStripMenuItem, Me.ANULARPEDIDOToolStripMenuItem})
        Me.ConMenu_Opciones1.Name = "ConMenu_Opciones"
        Me.ConMenu_Opciones1.Size = New System.Drawing.Size(247, 114)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(246, 22)
        Me.ToolStripMenuItem1.Text = "GRABAR RECLAMO CLIENTE"
        '
        'GRABARRECLAMOREPARTIDORToolStripMenuItem
        '
        Me.GRABARRECLAMOREPARTIDORToolStripMenuItem.Name = "GRABARRECLAMOREPARTIDORToolStripMenuItem"
        Me.GRABARRECLAMOREPARTIDORToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.GRABARRECLAMOREPARTIDORToolStripMenuItem.Text = "GRABAR RECLAMO REPARTIDOR"
        '
        'VERHISTORIALToolStripMenuItem1
        '
        Me.VERHISTORIALToolStripMenuItem1.Name = "VERHISTORIALToolStripMenuItem1"
        Me.VERHISTORIALToolStripMenuItem1.Size = New System.Drawing.Size(246, 22)
        Me.VERHISTORIALToolStripMenuItem1.Text = "VER ESTADOS"
        '
        'REGERARPEDIDOToolStripMenuItem
        '
        Me.REGERARPEDIDOToolStripMenuItem.Name = "REGERARPEDIDOToolStripMenuItem"
        Me.REGERARPEDIDOToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.REGERARPEDIDOToolStripMenuItem.Text = "REGENERAR PEDIDO"
        '
        'ANULARPEDIDOToolStripMenuItem
        '
        Me.ANULARPEDIDOToolStripMenuItem.Name = "ANULARPEDIDOToolStripMenuItem"
        Me.ANULARPEDIDOToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.ANULARPEDIDOToolStripMenuItem.Text = "ANULAR PEDIDO"
        '
        'btActualizar
        '
        Me.btActualizar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btActualizar.BackColor = System.Drawing.Color.Transparent
        Me.btActualizar.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.btActualizar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btActualizar.Image = Global.Presentacion.My.Resources.Resources.BT_ACTUALIZAR
        Me.btActualizar.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.btActualizar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btActualizar.Location = New System.Drawing.Point(0, 0)
        Me.btActualizar.Name = "btActualizar"
        Me.btActualizar.Size = New System.Drawing.Size(80, 70)
        Me.btActualizar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btActualizar.TabIndex = 12
        Me.btActualizar.Text = "ACTUALIZAR"
        Me.btActualizar.TextColor = System.Drawing.Color.Black
        '
        'F02_Pedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 602)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "F02_Pedido"
        Me.Text = "F02_Pedido"
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
        Me.TableLayoutPanelPrincipal.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GrPan_PeriodoPedido.ResumeLayout(False)
        Me.PaFrecEnDias.ResumeLayout(False)
        Me.GrB_FrecEnDias.ResumeLayout(False)
        CType(Me.Tb_FrecEnDias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PaFrecMensual.ResumeLayout(False)
        Me.GrB_FrecMensual.ResumeLayout(False)
        CType(Me.Tb_FrecMensual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PaFrecSem.ResumeLayout(False)
        Me.GrB_FrecSemanal.ResumeLayout(False)
        Me.GroupPanel5.ResumeLayout(False)
        CType(Me.JGr_DetallePedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmQuitarDetalle.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.PanelEx1.ResumeLayout(False)
        Me.GroupPanel4.ResumeLayout(False)
        Me.PanelEx2.ResumeLayout(False)
        Me.PanelEx2.PerformLayout()
        CType(Me.cbPreVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDistribuidor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.PanelEx4.ResumeLayout(False)
        CType(Me.JGr_Productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.PanelEx3.ResumeLayout(False)
        CType(Me.JGr_TipoProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.GroupPanel10.ResumeLayout(False)
        CType(Me.JGr_Reclamos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel8.ResumeLayout(False)
        CType(Me.JGr_Clientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.GroupPanel12.ResumeLayout(False)
        Me.GroupPanel11.ResumeLayout(False)
        Me.PanelEx6.ResumeLayout(False)
        Me.GroupPanel9.ResumeLayout(False)
        Me.PanelEx5.ResumeLayout(False)
        Me.PanelEx5.PerformLayout()
        CType(Me.JGr_UltimosPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.GroupPanel7.ResumeLayout(False)
        CType(Me.JGr_Buscador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel6.ResumeLayout(False)
        Me.PanelEx9.ResumeLayout(False)
        Me.ConMenu_Clientes.ResumeLayout(False)
        Me.ConMenu_Buscador.ResumeLayout(False)
        Me.ConMenu_Opciones1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanelPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents JGr_Productos As Janus.Windows.GridEX.GridEX
    Friend WithEvents JGr_TipoProd As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Tb_CliEstado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Tb_CliTelef As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb_CliDireccion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb_CliNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb_CliCod As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel5 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents Tb_Estado As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Lb_Estado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb_CliCateg As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Tb_CliCodZona As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb_Observaciones As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Tb_Zona As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb_Hora As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb_Id As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents JGr_DetallePedido As Janus.Windows.GridEX.GridEX
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PanelEx4 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents Btn_AddProd As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_TerminarAdd As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItemCliente As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents GrPan_PeriodoPedido As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PaFrecEnDias As System.Windows.Forms.Panel
    Friend WithEvents GrB_FrecEnDias As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_FrecEnDias As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Check2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PaFrecMensual As System.Windows.Forms.Panel
    Friend WithEvents GrB_FrecMensual As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_FrecMensual As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Check3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PaFrecSem As System.Windows.Forms.Panel
    Friend WithEvents GrB_FrecSemanal As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxX7 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX6 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX5 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX4 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX3 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX2 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Check1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupPanel7 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel6 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PanelEx9 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbFechaAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbFechaDel As System.Windows.Forms.DateTimePicker
    Friend WithEvents JGr_Buscador As Janus.Windows.GridEX.GridEX
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupPanel8 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents JGr_Clientes As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupPanel9 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Tb_TotalPedidos3Meses As System.Windows.Forms.TextBox
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb_PromCosumo As System.Windows.Forms.TextBox
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents JGr_UltimosPedidos As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupPanel10 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents JGr_Reclamos As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupPanel11 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Tb_Obs2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb_Obs As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel12 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Tb_DireccionDetalle As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents PanelEx6 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PanelEx5 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ConMenu_Clientes As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ACTUALIZARCLIENTESToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VERCLIENTESPASIVOSYACTIVOSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VERCLIENTESACTIVOSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConMenu_Buscador As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents VERHISTORIALToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConMenu_Opciones1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GRABARRECLAMOREPARTIDORToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VERHISTORIALToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents REGERARPEDIDOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ANULARPEDIDOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_GenerarPedidos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbCodCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Tb_CantProd As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbPreVendedor As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbDistribuidor As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btActualizar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmQuitarDetalle As ContextMenuStrip
    Friend WithEvents QuitarItemToolStripMenuItem As ToolStripMenuItem
End Class
