<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F02_Cliente
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
        Me.components = New System.ComponentModel.Container()
        Dim CbFiltroResumenEquipo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbTipoCredito_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbPrevendedor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbSupervisor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim CbCategoria_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim CbTipoDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim CbZona_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbFrecuencia_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F02_Cliente))
        Dim cbTipoAcuerdo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.TableLayoutPanelPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupPanelEquipos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelEx7 = New DevComponents.DotNetBar.PanelEx()
        Me.DgjEquipo = New Janus.Windows.GridEX.GridEX()
        Me.Cms1Equipos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Tsmi1Eliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelEx6 = New DevComponents.DotNetBar.PanelEx()
        Me.ChBuscar = New System.Windows.Forms.CheckBox()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.TbiCantEntrante = New DevComponents.Editors.IntegerInput()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.TbiCantSaliente = New DevComponents.Editors.IntegerInput()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.TbiCantSaldo = New DevComponents.Editors.IntegerInput()
        Me.CbFiltroResumenEquipo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.BtAddEquipo = New DevComponents.DotNetBar.ButtonX()
        Me.TableLayoutPanelDatos = New System.Windows.Forms.TableLayoutPanel()
        Me.StcSugerenciaUbicacion = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.DgjSugerencia = New Janus.Windows.GridEX.GridEX()
        Me.StiFiltroCliente = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel6 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.grCatProd = New Janus.Windows.GridEX.GridEX()
        Me.catProd = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabControlUbicacionGeografica = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupPanelMapa = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.btZoomAlejar = New DevComponents.DotNetBar.ButtonX()
        Me.btZoomAcercar = New DevComponents.DotNetBar.ButtonX()
        Me.GmUbicacionCliente = New GMap.NET.WindowsForms.GMapControl()
        Me.SuperTabItemMapa = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupPanelCoordenadas = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.tbLongitud = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbLatitud = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.BtMarcarPunto = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.SuperTabItemCoordenadas = New DevComponents.DotNetBar.SuperTabItem()
        Me.StiUbicacion = New DevComponents.DotNetBar.SuperTabItem()
        Me.GroupPanelDatosGenerales = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PnDatosGenerales = New DevComponents.DotNetBar.PanelEx()
        Me.cbTipoCredito = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX36 = New DevComponents.DotNetBar.LabelX()
        Me.tbCodCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX27 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanelEncargados = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.cbPrevendedor = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbSupervisor = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX26 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX()
        Me.tbRecorrido = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.DtiUltimaVenta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.DtiUltimoPedido = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.DtiFechaIng = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.DtiFechaNac = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.GpEstado = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.RbDevuelto = New System.Windows.Forms.RadioButton()
        Me.RbPasivo = New System.Windows.Forms.RadioButton()
        Me.RbActivo = New System.Windows.Forms.RadioButton()
        Me.GroupPanelDatosFactura = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TbNit = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TbNombreFactura = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.BtConfirmar = New DevComponents.DotNetBar.ButtonX()
        Me.CbCategoria = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.TbDireccion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.CbTipoDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.TbNroDoc = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.CbZona = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.TbTelefono2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TbNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TbTelefono1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.SbEventual = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.TbCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TbObs = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanelBusquedaDatos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.DgjBusqueda = New Janus.Windows.GridEX.GridEX()
        Me.SuperTabItemAcuerdo = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel5 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.PanelExBaseAcuerdo = New DevComponents.DotNetBar.PanelEx()
        Me.GroupPanelProducto = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.dgjProducto = New Janus.Windows.GridEX.GridEX()
        Me.GroupPanelAcuerdo = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.v = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX34 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX33 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX32 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX31 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX30 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX29 = New DevComponents.DotNetBar.LabelX()
        Me.tbAcuObs = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btEstado = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.cbFrecuencia = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.dtFechaFinal = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dtFechaInicio = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.cbTipoAcuerdo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.tbAcuCodCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX28 = New DevComponents.DotNetBar.LabelX()
        Me.tbAcuNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX35 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanelDias = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.dgjDias = New Janus.Windows.GridEX.GridEX()
        Me.cmsProducto = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemEliminarProducto = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.GroupPanelEquipos.SuspendLayout()
        Me.PanelEx7.SuspendLayout()
        CType(Me.DgjEquipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cms1Equipos.SuspendLayout()
        Me.PanelEx6.SuspendLayout()
        CType(Me.TbiCantEntrante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbiCantSaliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbiCantSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbFiltroResumenEquipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanelDatos.SuspendLayout()
        CType(Me.StcSugerenciaUbicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StcSugerenciaUbicacion.SuspendLayout()
        Me.SuperTabControlPanel3.SuspendLayout()
        CType(Me.DgjSugerencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel6.SuspendLayout()
        CType(Me.grCatProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel4.SuspendLayout()
        CType(Me.SuperTabControlUbicacionGeografica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlUbicacionGeografica.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.GroupPanelMapa.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.GroupPanelCoordenadas.SuspendLayout()
        Me.GroupPanelDatosGenerales.SuspendLayout()
        Me.PnDatosGenerales.SuspendLayout()
        CType(Me.cbTipoCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanelEncargados.SuspendLayout()
        CType(Me.cbPrevendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSupervisor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtiUltimaVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtiUltimoPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtiFechaIng, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtiFechaNac, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GpEstado.SuspendLayout()
        Me.GroupPanelDatosFactura.SuspendLayout()
        CType(Me.CbCategoria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbZona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanelBusquedaDatos.SuspendLayout()
        CType(Me.DgjBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel5.SuspendLayout()
        Me.PanelExBaseAcuerdo.SuspendLayout()
        Me.GroupPanelProducto.SuspendLayout()
        Me.PanelEx2.SuspendLayout()
        CType(Me.dgjProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanelAcuerdo.SuspendLayout()
        Me.v.SuspendLayout()
        CType(Me.cbFrecuencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTipoAcuerdo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanelDias.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        CType(Me.dgjDias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsProducto.SuspendLayout()
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
        Me.MSuperTabControlPrincipal.Controls.Add(Me.SuperTabControlPanel5)
        Me.MSuperTabControlPrincipal.Margin = New System.Windows.Forms.Padding(4)
        Me.MSuperTabControlPrincipal.SelectedTabIndex = 1
        Me.MSuperTabControlPrincipal.Size = New System.Drawing.Size(1362, 496)
        Me.MSuperTabControlPrincipal.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItemAcuerdo})
        Me.MSuperTabControlPrincipal.Controls.SetChildIndex(Me.MSuperTabControlPanelRegistro, 0)
        Me.MSuperTabControlPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanel5, 0)
        Me.MSuperTabControlPrincipal.Controls.SetChildIndex(Me.MSuperTabControlPanelBusqueda, 0)
        '
        'MSuperTabControlPanelBusqueda
        '
        Me.MSuperTabControlPanelBusqueda.Controls.Add(Me.GroupPanelBusquedaDatos)
        Me.MSuperTabControlPanelBusqueda.Margin = New System.Windows.Forms.Padding(4)
        Me.MSuperTabControlPanelBusqueda.Size = New System.Drawing.Size(1320, 496)
        '
        'MSuperTabControlPanelRegistro
        '
        Me.MSuperTabControlPanelRegistro.Controls.Add(Me.TableLayoutPanelPrincipal)
        Me.MSuperTabControlPanelRegistro.Margin = New System.Windows.Forms.Padding(4)
        Me.MSuperTabControlPanelRegistro.Size = New System.Drawing.Size(1320, 496)
        Me.MSuperTabControlPanelRegistro.Controls.SetChildIndex(Me.MPnUsuario, 0)
        Me.MSuperTabControlPanelRegistro.Controls.SetChildIndex(Me.TableLayoutPanelPrincipal, 0)
        '
        'MPnSuperior
        '
        Me.MPnSuperior.Margin = New System.Windows.Forms.Padding(4)
        Me.MPnSuperior.Size = New System.Drawing.Size(1362, 70)
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
        Me.MPnInferior.Location = New System.Drawing.Point(0, 566)
        Me.MPnInferior.Margin = New System.Windows.Forms.Padding(4)
        Me.MPnInferior.Size = New System.Drawing.Size(1362, 36)
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
        Me.MPanelToolBarUsuario.Location = New System.Drawing.Point(1162, 0)
        Me.MPanelToolBarUsuario.Margin = New System.Windows.Forms.Padding(4)
        '
        'MTbUsuario
        '
        Me.MTbUsuario.Margin = New System.Windows.Forms.Padding(4)
        Me.MTbUsuario.ReadOnly = True
        Me.MTbUsuario.Size = New System.Drawing.Size(135, 32)
        Me.MTbUsuario.Text = "DEFAULT"
        '
        'MBtUltimo
        '
        Me.MBtUltimo.Margin = New System.Windows.Forms.Padding(2)
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
        Me.MPanelToolBarImprimir.Controls.Add(Me.btActualizar)
        Me.MPanelToolBarImprimir.Location = New System.Drawing.Point(1202, 0)
        Me.MPanelToolBarImprimir.Margin = New System.Windows.Forms.Padding(4)
        Me.MPanelToolBarImprimir.Size = New System.Drawing.Size(160, 70)
        Me.MPanelToolBarImprimir.Controls.SetChildIndex(Me.MBtImprimir, 0)
        Me.MPanelToolBarImprimir.Controls.SetChildIndex(Me.btActualizar, 0)
        '
        'MBtImprimir
        '
        Me.MBtImprimir.Location = New System.Drawing.Point(80, 0)
        Me.MBtImprimir.Margin = New System.Windows.Forms.Padding(2)
        Me.MBtImprimir.Size = New System.Drawing.Size(80, 70)
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
        'TableLayoutPanelPrincipal
        '
        Me.TableLayoutPanelPrincipal.ColumnCount = 1
        Me.TableLayoutPanelPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelPrincipal.Controls.Add(Me.GroupPanelEquipos, 0, 1)
        Me.TableLayoutPanelPrincipal.Controls.Add(Me.TableLayoutPanelDatos, 0, 0)
        Me.TableLayoutPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelPrincipal.Name = "TableLayoutPanelPrincipal"
        Me.TableLayoutPanelPrincipal.RowCount = 2
        Me.TableLayoutPanelPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.0!))
        Me.TableLayoutPanelPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.0!))
        Me.TableLayoutPanelPrincipal.Size = New System.Drawing.Size(1320, 496)
        Me.TableLayoutPanelPrincipal.TabIndex = 37
        '
        'GroupPanelEquipos
        '
        Me.GroupPanelEquipos.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelEquipos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelEquipos.Controls.Add(Me.PanelEx7)
        Me.GroupPanelEquipos.Controls.Add(Me.PanelEx6)
        Me.GroupPanelEquipos.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelEquipos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelEquipos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelEquipos.Location = New System.Drawing.Point(3, 315)
        Me.GroupPanelEquipos.Name = "GroupPanelEquipos"
        Me.GroupPanelEquipos.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupPanelEquipos.Size = New System.Drawing.Size(1314, 178)
        '
        '
        '
        Me.GroupPanelEquipos.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanelEquipos.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanelEquipos.Style.BackColorGradientAngle = 90
        Me.GroupPanelEquipos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelEquipos.Style.BorderBottomWidth = 1
        Me.GroupPanelEquipos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelEquipos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelEquipos.Style.BorderLeftWidth = 1
        Me.GroupPanelEquipos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelEquipos.Style.BorderRightWidth = 1
        Me.GroupPanelEquipos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelEquipos.Style.BorderTopWidth = 1
        Me.GroupPanelEquipos.Style.CornerDiameter = 4
        Me.GroupPanelEquipos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelEquipos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelEquipos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelEquipos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelEquipos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelEquipos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelEquipos.TabIndex = 23
        Me.GroupPanelEquipos.Text = "DATOS DE EQUIPOS"
        '
        'PanelEx7
        '
        Me.PanelEx7.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx7.Controls.Add(Me.DgjEquipo)
        Me.PanelEx7.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx7.Location = New System.Drawing.Point(5, 58)
        Me.PanelEx7.Name = "PanelEx7"
        Me.PanelEx7.Size = New System.Drawing.Size(1298, 91)
        Me.PanelEx7.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx7.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx7.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx7.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx7.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx7.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx7.Style.GradientAngle = 90
        Me.PanelEx7.TabIndex = 6
        '
        'DgjEquipo
        '
        Me.DgjEquipo.ContextMenuStrip = Me.Cms1Equipos
        Me.DgjEquipo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgjEquipo.Location = New System.Drawing.Point(0, 0)
        Me.DgjEquipo.Name = "DgjEquipo"
        Me.DgjEquipo.Size = New System.Drawing.Size(1298, 91)
        Me.DgjEquipo.TabIndex = 0
        '
        'Cms1Equipos
        '
        Me.Cms1Equipos.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.Cms1Equipos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsmi1Eliminar})
        Me.Cms1Equipos.Name = "Cms1Equipos"
        Me.Cms1Equipos.Size = New System.Drawing.Size(148, 36)
        '
        'Tsmi1Eliminar
        '
        Me.Tsmi1Eliminar.Image = Global.Presentacion.My.Resources.Resources.eliminar
        Me.Tsmi1Eliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Tsmi1Eliminar.Name = "Tsmi1Eliminar"
        Me.Tsmi1Eliminar.Size = New System.Drawing.Size(147, 32)
        Me.Tsmi1Eliminar.Text = "Eliminar Fila"
        '
        'PanelEx6
        '
        Me.PanelEx6.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx6.Controls.Add(Me.ChBuscar)
        Me.PanelEx6.Controls.Add(Me.LabelX20)
        Me.PanelEx6.Controls.Add(Me.TbiCantEntrante)
        Me.PanelEx6.Controls.Add(Me.LabelX22)
        Me.PanelEx6.Controls.Add(Me.TbiCantSaliente)
        Me.PanelEx6.Controls.Add(Me.LabelX23)
        Me.PanelEx6.Controls.Add(Me.LabelX19)
        Me.PanelEx6.Controls.Add(Me.TbiCantSaldo)
        Me.PanelEx6.Controls.Add(Me.CbFiltroResumenEquipo)
        Me.PanelEx6.Controls.Add(Me.BtAddEquipo)
        Me.PanelEx6.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx6.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx6.Location = New System.Drawing.Point(5, 5)
        Me.PanelEx6.Name = "PanelEx6"
        Me.PanelEx6.Size = New System.Drawing.Size(1298, 53)
        Me.PanelEx6.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx6.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PanelEx6.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PanelEx6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx6.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx6.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx6.Style.GradientAngle = 90
        Me.PanelEx6.TabIndex = 2
        '
        'ChBuscar
        '
        Me.ChBuscar.AutoSize = True
        Me.ChBuscar.Location = New System.Drawing.Point(653, 24)
        Me.ChBuscar.Name = "ChBuscar"
        Me.ChBuscar.Size = New System.Drawing.Size(147, 21)
        Me.ChBuscar.TabIndex = 15
        Me.ChBuscar.Text = "Habilitar Busqueda"
        Me.ChBuscar.UseVisualStyleBackColor = True
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
        'BtAddEquipo
        '
        Me.BtAddEquipo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtAddEquipo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtAddEquipo.ImageFixedSize = New System.Drawing.Size(30, 50)
        Me.BtAddEquipo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.BtAddEquipo.Location = New System.Drawing.Point(3, 8)
        Me.BtAddEquipo.Name = "BtAddEquipo"
        Me.BtAddEquipo.Size = New System.Drawing.Size(120, 40)
        Me.BtAddEquipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtAddEquipo.TabIndex = 0
        Me.BtAddEquipo.Text = "Add Registro"
        '
        'TableLayoutPanelDatos
        '
        Me.TableLayoutPanelDatos.ColumnCount = 2
        Me.TableLayoutPanelDatos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.0!))
        Me.TableLayoutPanelDatos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.TableLayoutPanelDatos.Controls.Add(Me.StcSugerenciaUbicacion, 0, 0)
        Me.TableLayoutPanelDatos.Controls.Add(Me.GroupPanelDatosGenerales, 0, 0)
        Me.TableLayoutPanelDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelDatos.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanelDatos.Name = "TableLayoutPanelDatos"
        Me.TableLayoutPanelDatos.RowCount = 1
        Me.TableLayoutPanelDatos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelDatos.Size = New System.Drawing.Size(1314, 306)
        Me.TableLayoutPanelDatos.TabIndex = 0
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
        Me.StcSugerenciaUbicacion.Controls.Add(Me.SuperTabControlPanel6)
        Me.StcSugerenciaUbicacion.Controls.Add(Me.SuperTabControlPanel4)
        Me.StcSugerenciaUbicacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StcSugerenciaUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StcSugerenciaUbicacion.Location = New System.Drawing.Point(896, 3)
        Me.StcSugerenciaUbicacion.Name = "StcSugerenciaUbicacion"
        Me.StcSugerenciaUbicacion.ReorderTabsEnabled = True
        Me.StcSugerenciaUbicacion.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.StcSugerenciaUbicacion.SelectedTabIndex = 0
        Me.StcSugerenciaUbicacion.Size = New System.Drawing.Size(415, 300)
        Me.StcSugerenciaUbicacion.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StcSugerenciaUbicacion.TabIndex = 24
        Me.StcSugerenciaUbicacion.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.StiFiltroCliente, Me.StiUbicacion, Me.catProd})
        Me.StcSugerenciaUbicacion.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.StcSugerenciaUbicacion.Text = "SuperTabControl2"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.DgjSugerencia)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 23)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Padding = New System.Windows.Forms.Padding(5)
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(415, 277)
        Me.SuperTabControlPanel3.TabIndex = 1
        Me.SuperTabControlPanel3.TabItem = Me.StiFiltroCliente
        '
        'DgjSugerencia
        '
        Me.DgjSugerencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgjSugerencia.Location = New System.Drawing.Point(5, 5)
        Me.DgjSugerencia.Name = "DgjSugerencia"
        Me.DgjSugerencia.RecordNavigator = True
        Me.DgjSugerencia.Size = New System.Drawing.Size(405, 267)
        Me.DgjSugerencia.TabIndex = 0
        '
        'StiFiltroCliente
        '
        Me.StiFiltroCliente.AttachedControl = Me.SuperTabControlPanel3
        Me.StiFiltroCliente.GlobalItem = False
        Me.StiFiltroCliente.Name = "StiFiltroCliente"
        Me.StiFiltroCliente.Text = "SUGERENCIAS"
        '
        'SuperTabControlPanel6
        '
        Me.SuperTabControlPanel6.Controls.Add(Me.grCatProd)
        Me.SuperTabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel6.Location = New System.Drawing.Point(0, 23)
        Me.SuperTabControlPanel6.Name = "SuperTabControlPanel6"
        Me.SuperTabControlPanel6.Size = New System.Drawing.Size(415, 277)
        Me.SuperTabControlPanel6.TabIndex = 0
        Me.SuperTabControlPanel6.TabItem = Me.catProd
        '
        'grCatProd
        '
        Me.grCatProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grCatProd.Location = New System.Drawing.Point(0, 0)
        Me.grCatProd.Name = "grCatProd"
        Me.grCatProd.Size = New System.Drawing.Size(415, 277)
        Me.grCatProd.TabIndex = 0
        '
        'catProd
        '
        Me.catProd.AttachedControl = Me.SuperTabControlPanel6
        Me.catProd.GlobalItem = False
        Me.catProd.Name = "catProd"
        Me.catProd.Text = "CAT. PRODUCTOS"
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.Controls.Add(Me.SuperTabControlUbicacionGeografica)
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(0, 23)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(415, 277)
        Me.SuperTabControlPanel4.TabIndex = 0
        Me.SuperTabControlPanel4.TabItem = Me.StiUbicacion
        '
        'SuperTabControlUbicacionGeografica
        '
        '
        '
        '
        '
        '
        '
        Me.SuperTabControlUbicacionGeografica.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControlUbicacionGeografica.ControlBox.MenuBox.Name = ""
        Me.SuperTabControlUbicacionGeografica.ControlBox.Name = ""
        Me.SuperTabControlUbicacionGeografica.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControlUbicacionGeografica.ControlBox.MenuBox, Me.SuperTabControlUbicacionGeografica.ControlBox.CloseBox})
        Me.SuperTabControlUbicacionGeografica.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControlUbicacionGeografica.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControlUbicacionGeografica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlUbicacionGeografica.HorizontalText = False
        Me.SuperTabControlUbicacionGeografica.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlUbicacionGeografica.Name = "SuperTabControlUbicacionGeografica"
        Me.SuperTabControlUbicacionGeografica.ReorderTabsEnabled = True
        Me.SuperTabControlUbicacionGeografica.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControlUbicacionGeografica.SelectedTabIndex = 0
        Me.SuperTabControlUbicacionGeografica.Size = New System.Drawing.Size(415, 277)
        Me.SuperTabControlUbicacionGeografica.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.SuperTabControlUbicacionGeografica.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControlUbicacionGeografica.TabIndex = 3
        Me.SuperTabControlUbicacionGeografica.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItemMapa, Me.SuperTabItemCoordenadas})
        Me.SuperTabControlUbicacionGeografica.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.GroupPanelMapa)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(179, 277)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItemMapa
        '
        'GroupPanelMapa
        '
        Me.GroupPanelMapa.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelMapa.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelMapa.Controls.Add(Me.btZoomAlejar)
        Me.GroupPanelMapa.Controls.Add(Me.btZoomAcercar)
        Me.GroupPanelMapa.Controls.Add(Me.GmUbicacionCliente)
        Me.GroupPanelMapa.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelMapa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelMapa.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanelMapa.Name = "GroupPanelMapa"
        Me.GroupPanelMapa.Size = New System.Drawing.Size(179, 277)
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
        Me.GroupPanelMapa.TabIndex = 5
        Me.GroupPanelMapa.Text = "MAPA DE UBICACIÖN"
        '
        'btZoomAlejar
        '
        Me.btZoomAlejar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btZoomAlejar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btZoomAlejar.Image = Global.Presentacion.My.Resources.Resources.iconalejar
        Me.btZoomAlejar.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.btZoomAlejar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btZoomAlejar.Location = New System.Drawing.Point(49, 3)
        Me.btZoomAlejar.Name = "btZoomAlejar"
        Me.btZoomAlejar.Size = New System.Drawing.Size(40, 40)
        Me.btZoomAlejar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btZoomAlejar.TabIndex = 9
        '
        'btZoomAcercar
        '
        Me.btZoomAcercar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btZoomAcercar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.MHighlighterFocus.SetHighlightOnFocus(Me.btZoomAcercar, True)
        Me.btZoomAcercar.Image = Global.Presentacion.My.Resources.Resources.iconacercar
        Me.btZoomAcercar.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.btZoomAcercar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btZoomAcercar.Location = New System.Drawing.Point(3, 3)
        Me.btZoomAcercar.Name = "btZoomAcercar"
        Me.btZoomAcercar.Size = New System.Drawing.Size(40, 40)
        Me.btZoomAcercar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btZoomAcercar.TabIndex = 8
        '
        'GmUbicacionCliente
        '
        Me.GmUbicacionCliente.Bearing = 0!
        Me.GmUbicacionCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GmUbicacionCliente.CanDragMap = True
        Me.GmUbicacionCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GmUbicacionCliente.EmptyTileColor = System.Drawing.Color.Navy
        Me.GmUbicacionCliente.GrayScaleMode = False
        Me.GmUbicacionCliente.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
        Me.GmUbicacionCliente.LevelsKeepInMemmory = 5
        Me.GmUbicacionCliente.Location = New System.Drawing.Point(0, 0)
        Me.GmUbicacionCliente.MarkersEnabled = True
        Me.GmUbicacionCliente.MaxZoom = 2
        Me.GmUbicacionCliente.MinZoom = 2
        Me.GmUbicacionCliente.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
        Me.GmUbicacionCliente.Name = "GmUbicacionCliente"
        Me.GmUbicacionCliente.NegativeMode = False
        Me.GmUbicacionCliente.Padding = New System.Windows.Forms.Padding(5)
        Me.GmUbicacionCliente.PolygonsEnabled = True
        Me.GmUbicacionCliente.RetryLoadTile = 0
        Me.GmUbicacionCliente.RoutesEnabled = True
        Me.GmUbicacionCliente.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
        Me.GmUbicacionCliente.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.GmUbicacionCliente.ShowTileGridLines = False
        Me.GmUbicacionCliente.Size = New System.Drawing.Size(173, 253)
        Me.GmUbicacionCliente.TabIndex = 2
        Me.GmUbicacionCliente.Zoom = 0R
        '
        'SuperTabItemMapa
        '
        Me.SuperTabItemMapa.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItemMapa.GlobalItem = False
        Me.SuperTabItemMapa.Name = "SuperTabItemMapa"
        Me.SuperTabItemMapa.Text = "MAPA"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.GroupPanelCoordenadas)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(393, 370)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItemCoordenadas
        '
        'GroupPanelCoordenadas
        '
        Me.GroupPanelCoordenadas.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelCoordenadas.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelCoordenadas.Controls.Add(Me.tbLongitud)
        Me.GroupPanelCoordenadas.Controls.Add(Me.tbLatitud)
        Me.GroupPanelCoordenadas.Controls.Add(Me.BtMarcarPunto)
        Me.GroupPanelCoordenadas.Controls.Add(Me.LabelX12)
        Me.GroupPanelCoordenadas.Controls.Add(Me.LabelX11)
        Me.GroupPanelCoordenadas.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelCoordenadas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelCoordenadas.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanelCoordenadas.Name = "GroupPanelCoordenadas"
        Me.GroupPanelCoordenadas.Size = New System.Drawing.Size(393, 370)
        '
        '
        '
        Me.GroupPanelCoordenadas.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanelCoordenadas.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanelCoordenadas.Style.BackColorGradientAngle = 90
        Me.GroupPanelCoordenadas.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelCoordenadas.Style.BorderBottomWidth = 1
        Me.GroupPanelCoordenadas.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelCoordenadas.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelCoordenadas.Style.BorderLeftWidth = 1
        Me.GroupPanelCoordenadas.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelCoordenadas.Style.BorderRightWidth = 1
        Me.GroupPanelCoordenadas.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelCoordenadas.Style.BorderTopWidth = 1
        Me.GroupPanelCoordenadas.Style.CornerDiameter = 4
        Me.GroupPanelCoordenadas.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelCoordenadas.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelCoordenadas.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelCoordenadas.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelCoordenadas.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelCoordenadas.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelCoordenadas.TabIndex = 4
        Me.GroupPanelCoordenadas.Text = "COORDENADAS DE UBICACIÓN"
        '
        'tbLongitud
        '
        '
        '
        '
        Me.tbLongitud.Border.Class = "TextBoxBorder"
        Me.tbLongitud.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbLongitud.Location = New System.Drawing.Point(64, 32)
        Me.tbLongitud.MaxLength = 30
        Me.tbLongitud.Name = "tbLongitud"
        Me.tbLongitud.PreventEnterBeep = True
        Me.tbLongitud.Size = New System.Drawing.Size(150, 23)
        Me.tbLongitud.TabIndex = 9
        Me.tbLongitud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbLatitud
        '
        '
        '
        '
        Me.tbLatitud.Border.Class = "TextBoxBorder"
        Me.tbLatitud.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbLatitud.Location = New System.Drawing.Point(64, 3)
        Me.tbLatitud.MaxLength = 30
        Me.tbLatitud.Name = "tbLatitud"
        Me.tbLatitud.PreventEnterBeep = True
        Me.tbLatitud.Size = New System.Drawing.Size(150, 23)
        Me.tbLatitud.TabIndex = 8
        Me.tbLatitud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtMarcarPunto
        '
        Me.BtMarcarPunto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtMarcarPunto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtMarcarPunto.Location = New System.Drawing.Point(64, 64)
        Me.BtMarcarPunto.Name = "BtMarcarPunto"
        Me.BtMarcarPunto.Size = New System.Drawing.Size(150, 60)
        Me.BtMarcarPunto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtMarcarPunto.TabIndex = 5
        Me.BtMarcarPunto.Text = "Marcar"
        '
        'LabelX12
        '
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Location = New System.Drawing.Point(3, 32)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(100, 23)
        Me.LabelX12.TabIndex = 2
        Me.LabelX12.Text = "Longitud:"
        '
        'LabelX11
        '
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Location = New System.Drawing.Point(3, 3)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(100, 23)
        Me.LabelX11.TabIndex = 0
        Me.LabelX11.Text = "Latitud:"
        '
        'SuperTabItemCoordenadas
        '
        Me.SuperTabItemCoordenadas.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItemCoordenadas.GlobalItem = False
        Me.SuperTabItemCoordenadas.Name = "SuperTabItemCoordenadas"
        Me.SuperTabItemCoordenadas.Text = "COORDENADAS"
        '
        'StiUbicacion
        '
        Me.StiUbicacion.AttachedControl = Me.SuperTabControlPanel4
        Me.StiUbicacion.GlobalItem = False
        Me.StiUbicacion.Name = "StiUbicacion"
        Me.StiUbicacion.Text = "UBICACIÓN"
        '
        'GroupPanelDatosGenerales
        '
        Me.GroupPanelDatosGenerales.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelDatosGenerales.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelDatosGenerales.Controls.Add(Me.PnDatosGenerales)
        Me.GroupPanelDatosGenerales.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelDatosGenerales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelDatosGenerales.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelDatosGenerales.Location = New System.Drawing.Point(3, 3)
        Me.GroupPanelDatosGenerales.Name = "GroupPanelDatosGenerales"
        Me.GroupPanelDatosGenerales.Size = New System.Drawing.Size(887, 300)
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
        Me.GroupPanelDatosGenerales.TabIndex = 23
        Me.GroupPanelDatosGenerales.Text = "DATOS GENERALES"
        '
        'PnDatosGenerales
        '
        Me.PnDatosGenerales.AutoScroll = True
        Me.PnDatosGenerales.CanvasColor = System.Drawing.SystemColors.Control
        Me.PnDatosGenerales.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PnDatosGenerales.Controls.Add(Me.cbTipoCredito)
        Me.PnDatosGenerales.Controls.Add(Me.LabelX36)
        Me.PnDatosGenerales.Controls.Add(Me.tbCodCliente)
        Me.PnDatosGenerales.Controls.Add(Me.LabelX27)
        Me.PnDatosGenerales.Controls.Add(Me.GroupPanelEncargados)
        Me.PnDatosGenerales.Controls.Add(Me.DtiUltimaVenta)
        Me.PnDatosGenerales.Controls.Add(Me.DtiUltimoPedido)
        Me.PnDatosGenerales.Controls.Add(Me.DtiFechaIng)
        Me.PnDatosGenerales.Controls.Add(Me.DtiFechaNac)
        Me.PnDatosGenerales.Controls.Add(Me.GpEstado)
        Me.PnDatosGenerales.Controls.Add(Me.GroupPanelDatosFactura)
        Me.PnDatosGenerales.Controls.Add(Me.BtConfirmar)
        Me.PnDatosGenerales.Controls.Add(Me.CbCategoria)
        Me.PnDatosGenerales.Controls.Add(Me.TbDireccion)
        Me.PnDatosGenerales.Controls.Add(Me.CbTipoDoc)
        Me.PnDatosGenerales.Controls.Add(Me.TbNroDoc)
        Me.PnDatosGenerales.Controls.Add(Me.CbZona)
        Me.PnDatosGenerales.Controls.Add(Me.TbTelefono2)
        Me.PnDatosGenerales.Controls.Add(Me.TbNombre)
        Me.PnDatosGenerales.Controls.Add(Me.TbTelefono1)
        Me.PnDatosGenerales.Controls.Add(Me.SbEventual)
        Me.PnDatosGenerales.Controls.Add(Me.TbCodigo)
        Me.PnDatosGenerales.Controls.Add(Me.TbObs)
        Me.PnDatosGenerales.Controls.Add(Me.LabelX1)
        Me.PnDatosGenerales.Controls.Add(Me.LabelX2)
        Me.PnDatosGenerales.Controls.Add(Me.LabelX3)
        Me.PnDatosGenerales.Controls.Add(Me.LabelX4)
        Me.PnDatosGenerales.Controls.Add(Me.LabelX5)
        Me.PnDatosGenerales.Controls.Add(Me.LabelX15)
        Me.PnDatosGenerales.Controls.Add(Me.LabelX6)
        Me.PnDatosGenerales.Controls.Add(Me.LabelX18)
        Me.PnDatosGenerales.Controls.Add(Me.LabelX7)
        Me.PnDatosGenerales.Controls.Add(Me.LabelX8)
        Me.PnDatosGenerales.Controls.Add(Me.LabelX9)
        Me.PnDatosGenerales.Controls.Add(Me.LabelX17)
        Me.PnDatosGenerales.Controls.Add(Me.LabelX21)
        Me.PnDatosGenerales.Controls.Add(Me.LabelX14)
        Me.PnDatosGenerales.Controls.Add(Me.LabelX13)
        Me.PnDatosGenerales.DisabledBackColor = System.Drawing.Color.Empty
        Me.PnDatosGenerales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnDatosGenerales.Location = New System.Drawing.Point(0, 0)
        Me.PnDatosGenerales.Name = "PnDatosGenerales"
        Me.PnDatosGenerales.Size = New System.Drawing.Size(881, 276)
        Me.PnDatosGenerales.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PnDatosGenerales.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PnDatosGenerales.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PnDatosGenerales.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PnDatosGenerales.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PnDatosGenerales.Style.GradientAngle = 90
        Me.PnDatosGenerales.TabIndex = 38
        '
        'cbTipoCredito
        '
        cbTipoCredito_DesignTimeLayout.LayoutString = resources.GetString("cbTipoCredito_DesignTimeLayout.LayoutString")
        Me.cbTipoCredito.DesignTimeLayout = cbTipoCredito_DesignTimeLayout
        Me.cbTipoCredito.Location = New System.Drawing.Point(728, 147)
        Me.cbTipoCredito.Name = "cbTipoCredito"
        Me.cbTipoCredito.SelectedIndex = -1
        Me.cbTipoCredito.SelectedItem = Nothing
        Me.cbTipoCredito.Size = New System.Drawing.Size(127, 23)
        Me.cbTipoCredito.TabIndex = 45
        '
        'LabelX36
        '
        '
        '
        '
        Me.LabelX36.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX36.Location = New System.Drawing.Point(644, 146)
        Me.LabelX36.Name = "LabelX36"
        Me.LabelX36.Size = New System.Drawing.Size(100, 23)
        Me.LabelX36.TabIndex = 46
        Me.LabelX36.Text = "Tipo de Venta:"
        '
        'tbCodCliente
        '
        '
        '
        '
        Me.tbCodCliente.Border.Class = "TextBoxBorder"
        Me.tbCodCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCodCliente.Location = New System.Drawing.Point(251, 9)
        Me.tbCodCliente.MaxLength = 15
        Me.tbCodCliente.Name = "tbCodCliente"
        Me.tbCodCliente.PreventEnterBeep = True
        Me.tbCodCliente.Size = New System.Drawing.Size(160, 23)
        Me.tbCodCliente.TabIndex = 44
        '
        'LabelX27
        '
        '
        '
        '
        Me.LabelX27.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX27.Location = New System.Drawing.Point(177, 9)
        Me.LabelX27.Name = "LabelX27"
        Me.LabelX27.Size = New System.Drawing.Size(88, 23)
        Me.LabelX27.TabIndex = 43
        Me.LabelX27.Text = "Cod. Cliente:"
        '
        'GroupPanelEncargados
        '
        Me.GroupPanelEncargados.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelEncargados.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelEncargados.Controls.Add(Me.cbPrevendedor)
        Me.GroupPanelEncargados.Controls.Add(Me.cbSupervisor)
        Me.GroupPanelEncargados.Controls.Add(Me.LabelX26)
        Me.GroupPanelEncargados.Controls.Add(Me.LabelX25)
        Me.GroupPanelEncargados.Controls.Add(Me.tbRecorrido)
        Me.GroupPanelEncargados.Controls.Add(Me.LabelX24)
        Me.GroupPanelEncargados.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelEncargados.Location = New System.Drawing.Point(0, 345)
        Me.GroupPanelEncargados.Name = "GroupPanelEncargados"
        Me.GroupPanelEncargados.Size = New System.Drawing.Size(855, 53)
        '
        '
        '
        Me.GroupPanelEncargados.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanelEncargados.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanelEncargados.Style.BackColorGradientAngle = 90
        Me.GroupPanelEncargados.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelEncargados.Style.BorderBottomWidth = 1
        Me.GroupPanelEncargados.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelEncargados.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelEncargados.Style.BorderLeftWidth = 1
        Me.GroupPanelEncargados.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelEncargados.Style.BorderRightWidth = 1
        Me.GroupPanelEncargados.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelEncargados.Style.BorderTopWidth = 1
        Me.GroupPanelEncargados.Style.CornerDiameter = 4
        Me.GroupPanelEncargados.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelEncargados.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelEncargados.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelEncargados.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelEncargados.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelEncargados.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelEncargados.TabIndex = 42
        Me.GroupPanelEncargados.Text = "DATOS DE ENCARGADOS"
        '
        'cbPrevendedor
        '
        cbPrevendedor_DesignTimeLayout.LayoutString = resources.GetString("cbPrevendedor_DesignTimeLayout.LayoutString")
        Me.cbPrevendedor.DesignTimeLayout = cbPrevendedor_DesignTimeLayout
        Me.cbPrevendedor.Location = New System.Drawing.Point(626, 3)
        Me.cbPrevendedor.Name = "cbPrevendedor"
        Me.cbPrevendedor.SelectedIndex = -1
        Me.cbPrevendedor.SelectedItem = Nothing
        Me.cbPrevendedor.Size = New System.Drawing.Size(220, 23)
        Me.cbPrevendedor.TabIndex = 6
        '
        'cbSupervisor
        '
        cbSupervisor_DesignTimeLayout.LayoutString = resources.GetString("cbSupervisor_DesignTimeLayout.LayoutString")
        Me.cbSupervisor.DesignTimeLayout = cbSupervisor_DesignTimeLayout
        Me.cbSupervisor.Location = New System.Drawing.Point(309, 3)
        Me.cbSupervisor.Name = "cbSupervisor"
        Me.cbSupervisor.SelectedIndex = -1
        Me.cbSupervisor.SelectedItem = Nothing
        Me.cbSupervisor.Size = New System.Drawing.Size(220, 23)
        Me.cbSupervisor.TabIndex = 5
        '
        'LabelX26
        '
        '
        '
        '
        Me.LabelX26.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX26.Location = New System.Drawing.Point(535, 3)
        Me.LabelX26.Name = "LabelX26"
        Me.LabelX26.Size = New System.Drawing.Size(100, 23)
        Me.LabelX26.TabIndex = 4
        Me.LabelX26.Text = "Pre-Vendedor:"
        '
        'LabelX25
        '
        '
        '
        '
        Me.LabelX25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX25.Location = New System.Drawing.Point(214, 3)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(100, 23)
        Me.LabelX25.TabIndex = 2
        Me.LabelX25.Text = "Supervisor:"
        '
        'tbRecorrido
        '
        '
        '
        '
        Me.tbRecorrido.Border.Class = "TextBoxBorder"
        Me.tbRecorrido.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbRecorrido.Location = New System.Drawing.Point(108, 3)
        Me.tbRecorrido.MaxLength = 200
        Me.tbRecorrido.Name = "tbRecorrido"
        Me.tbRecorrido.PreventEnterBeep = True
        Me.tbRecorrido.Size = New System.Drawing.Size(100, 23)
        Me.tbRecorrido.TabIndex = 0
        Me.tbRecorrido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX24
        '
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.Location = New System.Drawing.Point(2, 3)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(100, 23)
        Me.LabelX24.TabIndex = 0
        Me.LabelX24.Text = "Recorrido:"
        '
        'DtiUltimaVenta
        '
        '
        '
        '
        Me.DtiUltimaVenta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DtiUltimaVenta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiUltimaVenta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DtiUltimaVenta.ButtonDropDown.Visible = True
        Me.DtiUltimaVenta.IsPopupCalendarOpen = False
        Me.DtiUltimaVenta.Location = New System.Drawing.Point(728, 7)
        '
        '
        '
        '
        '
        '
        Me.DtiUltimaVenta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiUltimaVenta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DtiUltimaVenta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DtiUltimaVenta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DtiUltimaVenta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DtiUltimaVenta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DtiUltimaVenta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DtiUltimaVenta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DtiUltimaVenta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DtiUltimaVenta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiUltimaVenta.MonthCalendar.DisplayMonth = New Date(2017, 7, 1, 0, 0, 0, 0)
        Me.DtiUltimaVenta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.DtiUltimaVenta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DtiUltimaVenta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DtiUltimaVenta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DtiUltimaVenta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiUltimaVenta.MonthCalendar.TodayButtonVisible = True
        Me.DtiUltimaVenta.Name = "DtiUltimaVenta"
        Me.DtiUltimaVenta.Size = New System.Drawing.Size(127, 23)
        Me.DtiUltimaVenta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DtiUltimaVenta.TabIndex = 41
        '
        'DtiUltimoPedido
        '
        '
        '
        '
        Me.DtiUltimoPedido.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DtiUltimoPedido.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiUltimoPedido.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DtiUltimoPedido.ButtonDropDown.Visible = True
        Me.DtiUltimoPedido.IsPopupCalendarOpen = False
        Me.DtiUltimoPedido.Location = New System.Drawing.Point(515, 8)
        '
        '
        '
        '
        '
        '
        Me.DtiUltimoPedido.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiUltimoPedido.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DtiUltimoPedido.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DtiUltimoPedido.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DtiUltimoPedido.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DtiUltimoPedido.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DtiUltimoPedido.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DtiUltimoPedido.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DtiUltimoPedido.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DtiUltimoPedido.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiUltimoPedido.MonthCalendar.DisplayMonth = New Date(2017, 7, 1, 0, 0, 0, 0)
        Me.DtiUltimoPedido.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.DtiUltimoPedido.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DtiUltimoPedido.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DtiUltimoPedido.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DtiUltimoPedido.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiUltimoPedido.MonthCalendar.TodayButtonVisible = True
        Me.DtiUltimoPedido.Name = "DtiUltimoPedido"
        Me.DtiUltimoPedido.Size = New System.Drawing.Size(120, 23)
        Me.DtiUltimoPedido.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DtiUltimoPedido.TabIndex = 40
        '
        'DtiFechaIng
        '
        '
        '
        '
        Me.DtiFechaIng.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DtiFechaIng.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiFechaIng.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DtiFechaIng.ButtonDropDown.Visible = True
        Me.DtiFechaIng.IsPopupCalendarOpen = False
        Me.DtiFechaIng.Location = New System.Drawing.Point(111, 205)
        '
        '
        '
        '
        '
        '
        Me.DtiFechaIng.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiFechaIng.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DtiFechaIng.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DtiFechaIng.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DtiFechaIng.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DtiFechaIng.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DtiFechaIng.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DtiFechaIng.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DtiFechaIng.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DtiFechaIng.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiFechaIng.MonthCalendar.DisplayMonth = New Date(2017, 7, 1, 0, 0, 0, 0)
        Me.DtiFechaIng.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.DtiFechaIng.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DtiFechaIng.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DtiFechaIng.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DtiFechaIng.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiFechaIng.MonthCalendar.TodayButtonVisible = True
        Me.DtiFechaIng.Name = "DtiFechaIng"
        Me.DtiFechaIng.Size = New System.Drawing.Size(120, 23)
        Me.DtiFechaIng.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DtiFechaIng.TabIndex = 39
        '
        'DtiFechaNac
        '
        '
        '
        '
        Me.DtiFechaNac.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DtiFechaNac.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiFechaNac.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DtiFechaNac.ButtonDropDown.Visible = True
        Me.DtiFechaNac.IsPopupCalendarOpen = False
        Me.DtiFechaNac.Location = New System.Drawing.Point(111, 176)
        '
        '
        '
        '
        '
        '
        Me.DtiFechaNac.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiFechaNac.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DtiFechaNac.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DtiFechaNac.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DtiFechaNac.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DtiFechaNac.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DtiFechaNac.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DtiFechaNac.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DtiFechaNac.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DtiFechaNac.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiFechaNac.MonthCalendar.DisplayMonth = New Date(2017, 7, 1, 0, 0, 0, 0)
        Me.DtiFechaNac.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.DtiFechaNac.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DtiFechaNac.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DtiFechaNac.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DtiFechaNac.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiFechaNac.MonthCalendar.TodayButtonVisible = True
        Me.DtiFechaNac.Name = "DtiFechaNac"
        Me.DtiFechaNac.Size = New System.Drawing.Size(120, 23)
        Me.DtiFechaNac.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DtiFechaNac.TabIndex = 38
        '
        'GpEstado
        '
        Me.GpEstado.CanvasColor = System.Drawing.SystemColors.Control
        Me.GpEstado.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GpEstado.Controls.Add(Me.RbDevuelto)
        Me.GpEstado.Controls.Add(Me.RbPasivo)
        Me.GpEstado.Controls.Add(Me.RbActivo)
        Me.GpEstado.DisabledBackColor = System.Drawing.Color.Empty
        Me.GpEstado.Location = New System.Drawing.Point(398, 125)
        Me.GpEstado.Name = "GpEstado"
        Me.GpEstado.Size = New System.Drawing.Size(240, 45)
        '
        '
        '
        Me.GpEstado.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GpEstado.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GpEstado.Style.BackColorGradientAngle = 90
        Me.GpEstado.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpEstado.Style.BorderBottomWidth = 1
        Me.GpEstado.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GpEstado.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpEstado.Style.BorderLeftWidth = 1
        Me.GpEstado.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpEstado.Style.BorderRightWidth = 1
        Me.GpEstado.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpEstado.Style.BorderTopWidth = 1
        Me.GpEstado.Style.CornerDiameter = 4
        Me.GpEstado.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GpEstado.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GpEstado.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GpEstado.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GpEstado.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GpEstado.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GpEstado.TabIndex = 9
        Me.GpEstado.Text = "Estado Cliente"
        '
        'RbDevuelto
        '
        Me.RbDevuelto.AutoSize = True
        Me.RbDevuelto.Location = New System.Drawing.Point(151, 3)
        Me.RbDevuelto.Name = "RbDevuelto"
        Me.RbDevuelto.Size = New System.Drawing.Size(82, 21)
        Me.RbDevuelto.TabIndex = 2
        Me.RbDevuelto.TabStop = True
        Me.RbDevuelto.Text = "Devuelto"
        Me.RbDevuelto.UseVisualStyleBackColor = True
        '
        'RbPasivo
        '
        Me.RbPasivo.AutoSize = True
        Me.RbPasivo.Location = New System.Drawing.Point(74, 3)
        Me.RbPasivo.Name = "RbPasivo"
        Me.RbPasivo.Size = New System.Drawing.Size(68, 21)
        Me.RbPasivo.TabIndex = 1
        Me.RbPasivo.TabStop = True
        Me.RbPasivo.Text = "Pasivo"
        Me.RbPasivo.UseVisualStyleBackColor = True
        '
        'RbActivo
        '
        Me.RbActivo.AutoSize = True
        Me.RbActivo.Location = New System.Drawing.Point(3, 3)
        Me.RbActivo.Name = "RbActivo"
        Me.RbActivo.Size = New System.Drawing.Size(64, 21)
        Me.RbActivo.TabIndex = 0
        Me.RbActivo.TabStop = True
        Me.RbActivo.Text = "Activo"
        Me.RbActivo.UseVisualStyleBackColor = True
        '
        'GroupPanelDatosFactura
        '
        Me.GroupPanelDatosFactura.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelDatosFactura.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelDatosFactura.Controls.Add(Me.TbNit)
        Me.GroupPanelDatosFactura.Controls.Add(Me.TbNombreFactura)
        Me.GroupPanelDatosFactura.Controls.Add(Me.LabelX10)
        Me.GroupPanelDatosFactura.Controls.Add(Me.LabelX16)
        Me.GroupPanelDatosFactura.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelDatosFactura.Location = New System.Drawing.Point(0, 286)
        Me.GroupPanelDatosFactura.Name = "GroupPanelDatosFactura"
        Me.GroupPanelDatosFactura.Size = New System.Drawing.Size(855, 53)
        '
        '
        '
        Me.GroupPanelDatosFactura.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanelDatosFactura.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanelDatosFactura.Style.BackColorGradientAngle = 90
        Me.GroupPanelDatosFactura.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatosFactura.Style.BorderBottomWidth = 1
        Me.GroupPanelDatosFactura.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelDatosFactura.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatosFactura.Style.BorderLeftWidth = 1
        Me.GroupPanelDatosFactura.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatosFactura.Style.BorderRightWidth = 1
        Me.GroupPanelDatosFactura.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatosFactura.Style.BorderTopWidth = 1
        Me.GroupPanelDatosFactura.Style.CornerDiameter = 4
        Me.GroupPanelDatosFactura.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelDatosFactura.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelDatosFactura.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelDatosFactura.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelDatosFactura.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelDatosFactura.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelDatosFactura.TabIndex = 29
        Me.GroupPanelDatosFactura.Text = "DATOS DE FACTURA"
        '
        'TbNit
        '
        '
        '
        '
        Me.TbNit.Border.Class = "TextBoxBorder"
        Me.TbNit.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TbNit.Location = New System.Drawing.Point(626, 1)
        Me.TbNit.MaxLength = 20
        Me.TbNit.Name = "TbNit"
        Me.TbNit.PreventEnterBeep = True
        Me.TbNit.Size = New System.Drawing.Size(220, 23)
        Me.TbNit.TabIndex = 1
        '
        'TbNombreFactura
        '
        '
        '
        '
        Me.TbNombreFactura.Border.Class = "TextBoxBorder"
        Me.TbNombreFactura.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TbNombreFactura.Location = New System.Drawing.Point(108, 0)
        Me.TbNombreFactura.MaxLength = 200
        Me.TbNombreFactura.Name = "TbNombreFactura"
        Me.TbNombreFactura.PreventEnterBeep = True
        Me.TbNombreFactura.Size = New System.Drawing.Size(480, 23)
        Me.TbNombreFactura.TabIndex = 0
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Location = New System.Drawing.Point(2, 0)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(100, 23)
        Me.LabelX10.TabIndex = 0
        Me.LabelX10.Text = "Nombre Factura:"
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Location = New System.Drawing.Point(594, 0)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(47, 23)
        Me.LabelX16.TabIndex = 1
        Me.LabelX16.Text = "Nit:"
        '
        'BtConfirmar
        '
        Me.BtConfirmar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtConfirmar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtConfirmar.ImageFixedSize = New System.Drawing.Size(30, 50)
        Me.BtConfirmar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.BtConfirmar.Location = New System.Drawing.Point(728, 67)
        Me.BtConfirmar.Name = "BtConfirmar"
        Me.BtConfirmar.Size = New System.Drawing.Size(127, 40)
        Me.BtConfirmar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtConfirmar.TabIndex = 27
        Me.BtConfirmar.Text = "Confirmar"
        '
        'CbCategoria
        '
        CbCategoria_DesignTimeLayout.LayoutString = resources.GetString("CbCategoria_DesignTimeLayout.LayoutString")
        Me.CbCategoria.DesignTimeLayout = CbCategoria_DesignTimeLayout
        Me.CbCategoria.Location = New System.Drawing.Point(515, 96)
        Me.CbCategoria.Name = "CbCategoria"
        Me.CbCategoria.SelectedIndex = -1
        Me.CbCategoria.SelectedItem = Nothing
        Me.CbCategoria.Size = New System.Drawing.Size(120, 23)
        Me.CbCategoria.TabIndex = 8
        '
        'TbDireccion
        '
        '
        '
        '
        Me.TbDireccion.Border.Class = "TextBoxBorder"
        Me.TbDireccion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TbDireccion.Location = New System.Drawing.Point(111, 234)
        Me.TbDireccion.MaxLength = 200
        Me.TbDireccion.Multiline = True
        Me.TbDireccion.Name = "TbDireccion"
        Me.TbDireccion.PreventEnterBeep = True
        Me.TbDireccion.Size = New System.Drawing.Size(744, 46)
        Me.TbDireccion.TabIndex = 5
        '
        'CbTipoDoc
        '
        CbTipoDoc_DesignTimeLayout.LayoutString = resources.GetString("CbTipoDoc_DesignTimeLayout.LayoutString")
        Me.CbTipoDoc.DesignTimeLayout = CbTipoDoc_DesignTimeLayout
        Me.CbTipoDoc.Location = New System.Drawing.Point(111, 118)
        Me.CbTipoDoc.Name = "CbTipoDoc"
        Me.CbTipoDoc.SelectedIndex = -1
        Me.CbTipoDoc.SelectedItem = Nothing
        Me.CbTipoDoc.Size = New System.Drawing.Size(180, 23)
        Me.CbTipoDoc.TabIndex = 2
        '
        'TbNroDoc
        '
        '
        '
        '
        Me.TbNroDoc.Border.Class = "TextBoxBorder"
        Me.TbNroDoc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TbNroDoc.Location = New System.Drawing.Point(111, 147)
        Me.TbNroDoc.MaxLength = 20
        Me.TbNroDoc.Name = "TbNroDoc"
        Me.TbNroDoc.PreventEnterBeep = True
        Me.TbNroDoc.Size = New System.Drawing.Size(180, 23)
        Me.TbNroDoc.TabIndex = 3
        '
        'CbZona
        '
        CbZona_DesignTimeLayout.LayoutString = resources.GetString("CbZona_DesignTimeLayout.LayoutString")
        Me.CbZona.DesignTimeLayout = CbZona_DesignTimeLayout
        Me.CbZona.Location = New System.Drawing.Point(111, 89)
        Me.CbZona.Name = "CbZona"
        Me.CbZona.SelectedIndex = -1
        Me.CbZona.SelectedItem = Nothing
        Me.CbZona.Size = New System.Drawing.Size(180, 23)
        Me.CbZona.TabIndex = 1
        '
        'TbTelefono2
        '
        '
        '
        '
        Me.TbTelefono2.Border.Class = "TextBoxBorder"
        Me.TbTelefono2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TbTelefono2.Location = New System.Drawing.Point(515, 67)
        Me.TbTelefono2.MaxLength = 30
        Me.TbTelefono2.Name = "TbTelefono2"
        Me.TbTelefono2.PreventEnterBeep = True
        Me.TbTelefono2.Size = New System.Drawing.Size(120, 23)
        Me.TbTelefono2.TabIndex = 7
        '
        'TbNombre
        '
        '
        '
        '
        Me.TbNombre.Border.Class = "TextBoxBorder"
        Me.TbNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TbNombre.Location = New System.Drawing.Point(111, 38)
        Me.TbNombre.MaxLength = 50
        Me.TbNombre.Multiline = True
        Me.TbNombre.Name = "TbNombre"
        Me.TbNombre.PreventEnterBeep = True
        Me.TbNombre.Size = New System.Drawing.Size(300, 45)
        Me.TbNombre.TabIndex = 0
        '
        'TbTelefono1
        '
        '
        '
        '
        Me.TbTelefono1.Border.Class = "TextBoxBorder"
        Me.TbTelefono1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TbTelefono1.Location = New System.Drawing.Point(515, 38)
        Me.TbTelefono1.MaxLength = 30
        Me.TbTelefono1.Name = "TbTelefono1"
        Me.TbTelefono1.PreventEnterBeep = True
        Me.TbTelefono1.Size = New System.Drawing.Size(120, 23)
        Me.TbTelefono1.TabIndex = 6
        '
        'SbEventual
        '
        '
        '
        '
        Me.SbEventual.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SbEventual.Location = New System.Drawing.Point(728, 38)
        Me.SbEventual.Name = "SbEventual"
        Me.SbEventual.OffText = "EVENTUAL"
        Me.SbEventual.OnText = "CONFIRMADO"
        Me.SbEventual.Size = New System.Drawing.Size(127, 23)
        Me.SbEventual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SbEventual.TabIndex = 10
        '
        'TbCodigo
        '
        '
        '
        '
        Me.TbCodigo.Border.Class = "TextBoxBorder"
        Me.TbCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TbCodigo.Location = New System.Drawing.Point(111, 9)
        Me.TbCodigo.Name = "TbCodigo"
        Me.TbCodigo.PreventEnterBeep = True
        Me.TbCodigo.Size = New System.Drawing.Size(60, 23)
        Me.TbCodigo.TabIndex = 12
        '
        'TbObs
        '
        '
        '
        '
        Me.TbObs.Border.Class = "TextBoxBorder"
        Me.TbObs.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TbObs.Location = New System.Drawing.Point(515, 176)
        Me.TbObs.MaxLength = 150
        Me.TbObs.Multiline = True
        Me.TbObs.Name = "TbObs"
        Me.TbObs.PreventEnterBeep = True
        Me.TbObs.Size = New System.Drawing.Size(340, 52)
        Me.TbObs.TabIndex = 11
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(5, 9)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(100, 23)
        Me.LabelX1.TabIndex = 9
        Me.LabelX1.Text = "Cod. Sis.:"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(5, 38)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(100, 23)
        Me.LabelX2.TabIndex = 10
        Me.LabelX2.Text = "*Nombre:"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(5, 89)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(100, 23)
        Me.LabelX3.TabIndex = 11
        Me.LabelX3.Text = "*Zona:"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(5, 118)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(100, 23)
        Me.LabelX4.TabIndex = 12
        Me.LabelX4.Text = "*Tipo de Doc.:"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(5, 147)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(100, 23)
        Me.LabelX5.TabIndex = 13
        Me.LabelX5.Text = "*Nro de Doc.:"
        '
        'LabelX15
        '
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Location = New System.Drawing.Point(5, 176)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(100, 23)
        Me.LabelX15.TabIndex = 26
        Me.LabelX15.Text = "Fecha Nac.:"
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(5, 234)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(100, 23)
        Me.LabelX6.TabIndex = 15
        Me.LabelX6.Text = "Dirección:"
        '
        'LabelX18
        '
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Location = New System.Drawing.Point(417, 9)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(100, 23)
        Me.LabelX18.TabIndex = 35
        Me.LabelX18.Text = "Ultimo Pedido:"
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(417, 38)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(100, 23)
        Me.LabelX7.TabIndex = 16
        Me.LabelX7.Text = "Teléfono 1:"
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Location = New System.Drawing.Point(417, 67)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(100, 23)
        Me.LabelX8.TabIndex = 17
        Me.LabelX8.Text = "Teléfono 2:"
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Location = New System.Drawing.Point(417, 96)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(100, 23)
        Me.LabelX9.TabIndex = 18
        Me.LabelX9.Text = "Cat. Cliente:"
        '
        'LabelX17
        '
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Location = New System.Drawing.Point(5, 205)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(100, 23)
        Me.LabelX17.TabIndex = 31
        Me.LabelX17.Text = "Fecha Ingreso:"
        '
        'LabelX21
        '
        '
        '
        '
        Me.LabelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX21.Location = New System.Drawing.Point(644, 8)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(100, 23)
        Me.LabelX21.TabIndex = 37
        Me.LabelX21.Text = "Ultima Venta"
        '
        'LabelX14
        '
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Location = New System.Drawing.Point(644, 37)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(100, 23)
        Me.LabelX14.TabIndex = 25
        Me.LabelX14.Text = "Tipo Cliente:"
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Location = New System.Drawing.Point(417, 176)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(100, 23)
        Me.LabelX13.TabIndex = 23
        Me.LabelX13.Text = "Observación:"
        '
        'GroupPanelBusquedaDatos
        '
        Me.GroupPanelBusquedaDatos.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelBusquedaDatos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelBusquedaDatos.Controls.Add(Me.DgjBusqueda)
        Me.GroupPanelBusquedaDatos.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelBusquedaDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelBusquedaDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelBusquedaDatos.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanelBusquedaDatos.Name = "GroupPanelBusquedaDatos"
        Me.GroupPanelBusquedaDatos.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupPanelBusquedaDatos.Size = New System.Drawing.Size(1320, 496)
        '
        '
        '
        Me.GroupPanelBusquedaDatos.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanelBusquedaDatos.Style.BackColorGradientAngle = 90
        Me.GroupPanelBusquedaDatos.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanelBusquedaDatos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBusquedaDatos.Style.BorderBottomWidth = 1
        Me.GroupPanelBusquedaDatos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelBusquedaDatos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBusquedaDatos.Style.BorderLeftWidth = 1
        Me.GroupPanelBusquedaDatos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBusquedaDatos.Style.BorderRightWidth = 1
        Me.GroupPanelBusquedaDatos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBusquedaDatos.Style.BorderTopWidth = 1
        Me.GroupPanelBusquedaDatos.Style.CornerDiameter = 4
        Me.GroupPanelBusquedaDatos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelBusquedaDatos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelBusquedaDatos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelBusquedaDatos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelBusquedaDatos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelBusquedaDatos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelBusquedaDatos.TabIndex = 4
        Me.GroupPanelBusquedaDatos.Text = "BUSQUEDA DATOS"
        '
        'DgjBusqueda
        '
        Me.DgjBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgjBusqueda.Location = New System.Drawing.Point(5, 5)
        Me.DgjBusqueda.Name = "DgjBusqueda"
        Me.DgjBusqueda.Size = New System.Drawing.Size(1304, 462)
        Me.DgjBusqueda.TabIndex = 0
        '
        'SuperTabItemAcuerdo
        '
        Me.SuperTabItemAcuerdo.AttachedControl = Me.SuperTabControlPanel5
        Me.SuperTabItemAcuerdo.GlobalItem = False
        Me.SuperTabItemAcuerdo.Name = "SuperTabItemAcuerdo"
        Me.SuperTabItemAcuerdo.Text = "ACUERDO"
        '
        'SuperTabControlPanel5
        '
        Me.SuperTabControlPanel5.Controls.Add(Me.PanelExBaseAcuerdo)
        Me.SuperTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel5.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel5.Name = "SuperTabControlPanel5"
        Me.SuperTabControlPanel5.Size = New System.Drawing.Size(1328, 496)
        Me.SuperTabControlPanel5.TabIndex = 0
        Me.SuperTabControlPanel5.TabItem = Me.SuperTabItemAcuerdo
        '
        'PanelExBaseAcuerdo
        '
        Me.PanelExBaseAcuerdo.AutoScroll = True
        Me.PanelExBaseAcuerdo.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelExBaseAcuerdo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelExBaseAcuerdo.Controls.Add(Me.GroupPanelProducto)
        Me.PanelExBaseAcuerdo.Controls.Add(Me.GroupPanelAcuerdo)
        Me.PanelExBaseAcuerdo.Controls.Add(Me.GroupPanelDias)
        Me.PanelExBaseAcuerdo.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelExBaseAcuerdo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelExBaseAcuerdo.Location = New System.Drawing.Point(0, 0)
        Me.PanelExBaseAcuerdo.Name = "PanelExBaseAcuerdo"
        Me.PanelExBaseAcuerdo.Padding = New System.Windows.Forms.Padding(5)
        Me.PanelExBaseAcuerdo.Size = New System.Drawing.Size(1328, 496)
        Me.PanelExBaseAcuerdo.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelExBaseAcuerdo.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PanelExBaseAcuerdo.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PanelExBaseAcuerdo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelExBaseAcuerdo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelExBaseAcuerdo.Style.GradientAngle = 90
        Me.PanelExBaseAcuerdo.TabIndex = 0
        '
        'GroupPanelProducto
        '
        Me.GroupPanelProducto.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelProducto.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelProducto.Controls.Add(Me.PanelEx2)
        Me.GroupPanelProducto.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelProducto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelProducto.Location = New System.Drawing.Point(5, 202)
        Me.GroupPanelProducto.Name = "GroupPanelProducto"
        Me.GroupPanelProducto.Size = New System.Drawing.Size(1068, 289)
        '
        '
        '
        Me.GroupPanelProducto.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanelProducto.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanelProducto.Style.BackColorGradientAngle = 90
        Me.GroupPanelProducto.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelProducto.Style.BorderBottomWidth = 1
        Me.GroupPanelProducto.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelProducto.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelProducto.Style.BorderLeftWidth = 1
        Me.GroupPanelProducto.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelProducto.Style.BorderRightWidth = 1
        Me.GroupPanelProducto.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelProducto.Style.BorderTopWidth = 1
        Me.GroupPanelProducto.Style.CornerDiameter = 4
        Me.GroupPanelProducto.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelProducto.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelProducto.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelProducto.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelProducto.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelProducto.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelProducto.TabIndex = 26
        Me.GroupPanelProducto.Text = "LISTA DE PRODUCTOS"
        '
        'PanelEx2
        '
        Me.PanelEx2.AutoScroll = True
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.dgjProducto)
        Me.PanelEx2.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx2.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(1062, 265)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PanelEx2.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PanelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.TabIndex = 38
        '
        'dgjProducto
        '
        Me.dgjProducto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgjProducto.Location = New System.Drawing.Point(0, 0)
        Me.dgjProducto.Name = "dgjProducto"
        Me.dgjProducto.Size = New System.Drawing.Size(1062, 265)
        Me.dgjProducto.TabIndex = 0
        '
        'GroupPanelAcuerdo
        '
        Me.GroupPanelAcuerdo.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelAcuerdo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelAcuerdo.Controls.Add(Me.v)
        Me.GroupPanelAcuerdo.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelAcuerdo.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupPanelAcuerdo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelAcuerdo.Location = New System.Drawing.Point(5, 5)
        Me.GroupPanelAcuerdo.Name = "GroupPanelAcuerdo"
        Me.GroupPanelAcuerdo.Size = New System.Drawing.Size(1068, 197)
        '
        '
        '
        Me.GroupPanelAcuerdo.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanelAcuerdo.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanelAcuerdo.Style.BackColorGradientAngle = 90
        Me.GroupPanelAcuerdo.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelAcuerdo.Style.BorderBottomWidth = 1
        Me.GroupPanelAcuerdo.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelAcuerdo.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelAcuerdo.Style.BorderLeftWidth = 1
        Me.GroupPanelAcuerdo.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelAcuerdo.Style.BorderRightWidth = 1
        Me.GroupPanelAcuerdo.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelAcuerdo.Style.BorderTopWidth = 1
        Me.GroupPanelAcuerdo.Style.CornerDiameter = 4
        Me.GroupPanelAcuerdo.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelAcuerdo.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelAcuerdo.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelAcuerdo.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelAcuerdo.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelAcuerdo.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelAcuerdo.TabIndex = 24
        Me.GroupPanelAcuerdo.Text = "DATOS GENERALES ACUERDO"
        '
        'v
        '
        Me.v.AutoScroll = True
        Me.v.CanvasColor = System.Drawing.SystemColors.Control
        Me.v.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.v.Controls.Add(Me.LabelX34)
        Me.v.Controls.Add(Me.LabelX33)
        Me.v.Controls.Add(Me.LabelX32)
        Me.v.Controls.Add(Me.LabelX31)
        Me.v.Controls.Add(Me.LabelX30)
        Me.v.Controls.Add(Me.LabelX29)
        Me.v.Controls.Add(Me.tbAcuObs)
        Me.v.Controls.Add(Me.btEstado)
        Me.v.Controls.Add(Me.cbFrecuencia)
        Me.v.Controls.Add(Me.dtFechaFinal)
        Me.v.Controls.Add(Me.dtFechaInicio)
        Me.v.Controls.Add(Me.cbTipoAcuerdo)
        Me.v.Controls.Add(Me.tbAcuCodCliente)
        Me.v.Controls.Add(Me.LabelX28)
        Me.v.Controls.Add(Me.tbAcuNombre)
        Me.v.Controls.Add(Me.LabelX35)
        Me.v.DisabledBackColor = System.Drawing.Color.Empty
        Me.v.Dock = System.Windows.Forms.DockStyle.Fill
        Me.v.Location = New System.Drawing.Point(0, 0)
        Me.v.Name = "v"
        Me.v.Size = New System.Drawing.Size(1062, 173)
        Me.v.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.v.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.v.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.v.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.v.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.v.Style.GradientAngle = 90
        Me.v.TabIndex = 38
        '
        'LabelX34
        '
        '
        '
        '
        Me.LabelX34.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX34.Location = New System.Drawing.Point(417, 61)
        Me.LabelX34.Name = "LabelX34"
        Me.LabelX34.Size = New System.Drawing.Size(100, 23)
        Me.LabelX34.TabIndex = 56
        Me.LabelX34.Text = "Dato Adicional:"
        '
        'LabelX33
        '
        '
        '
        '
        Me.LabelX33.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX33.Location = New System.Drawing.Point(417, 32)
        Me.LabelX33.Name = "LabelX33"
        Me.LabelX33.Size = New System.Drawing.Size(100, 23)
        Me.LabelX33.TabIndex = 55
        Me.LabelX33.Text = "Estado:"
        '
        'LabelX32
        '
        '
        '
        '
        Me.LabelX32.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX32.Location = New System.Drawing.Point(417, 3)
        Me.LabelX32.Name = "LabelX32"
        Me.LabelX32.Size = New System.Drawing.Size(100, 23)
        Me.LabelX32.TabIndex = 54
        Me.LabelX32.Text = "Frecuencia:"
        '
        'LabelX31
        '
        '
        '
        '
        Me.LabelX31.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX31.Location = New System.Drawing.Point(237, 112)
        Me.LabelX31.Name = "LabelX31"
        Me.LabelX31.Size = New System.Drawing.Size(100, 23)
        Me.LabelX31.TabIndex = 53
        Me.LabelX31.Text = "Fecha Fin:"
        '
        'LabelX30
        '
        '
        '
        '
        Me.LabelX30.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX30.Location = New System.Drawing.Point(5, 112)
        Me.LabelX30.Name = "LabelX30"
        Me.LabelX30.Size = New System.Drawing.Size(100, 23)
        Me.LabelX30.TabIndex = 52
        Me.LabelX30.Text = "Fecha Inicio:"
        '
        'LabelX29
        '
        '
        '
        '
        Me.LabelX29.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX29.Location = New System.Drawing.Point(5, 83)
        Me.LabelX29.Name = "LabelX29"
        Me.LabelX29.Size = New System.Drawing.Size(100, 23)
        Me.LabelX29.TabIndex = 51
        Me.LabelX29.Text = "Tipo Acuerdo:"
        '
        'tbAcuObs
        '
        '
        '
        '
        Me.tbAcuObs.Border.Class = "TextBoxBorder"
        Me.tbAcuObs.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbAcuObs.Location = New System.Drawing.Point(523, 61)
        Me.tbAcuObs.MaxLength = 50
        Me.tbAcuObs.Multiline = True
        Me.tbAcuObs.Name = "tbAcuObs"
        Me.tbAcuObs.PreventEnterBeep = True
        Me.tbAcuObs.Size = New System.Drawing.Size(300, 45)
        Me.tbAcuObs.TabIndex = 50
        '
        'btEstado
        '
        '
        '
        '
        Me.btEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btEstado.Location = New System.Drawing.Point(523, 32)
        Me.btEstado.Name = "btEstado"
        Me.btEstado.OffText = "VENCIDO"
        Me.btEstado.OnText = "VIGENTE"
        Me.btEstado.Size = New System.Drawing.Size(127, 23)
        Me.btEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btEstado.TabIndex = 49
        Me.btEstado.Value = True
        Me.btEstado.ValueObject = "Y"
        '
        'cbFrecuencia
        '
        cbFrecuencia_DesignTimeLayout.LayoutString = resources.GetString("cbFrecuencia_DesignTimeLayout.LayoutString")
        Me.cbFrecuencia.DesignTimeLayout = cbFrecuencia_DesignTimeLayout
        Me.cbFrecuencia.Location = New System.Drawing.Point(523, 3)
        Me.cbFrecuencia.Name = "cbFrecuencia"
        Me.cbFrecuencia.SelectedIndex = -1
        Me.cbFrecuencia.SelectedItem = Nothing
        Me.cbFrecuencia.Size = New System.Drawing.Size(180, 23)
        Me.cbFrecuencia.TabIndex = 48
        '
        'dtFechaFinal
        '
        '
        '
        '
        Me.dtFechaFinal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtFechaFinal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaFinal.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtFechaFinal.ButtonDropDown.Visible = True
        Me.dtFechaFinal.IsPopupCalendarOpen = False
        Me.dtFechaFinal.Location = New System.Drawing.Point(343, 112)
        '
        '
        '
        '
        '
        '
        Me.dtFechaFinal.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaFinal.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtFechaFinal.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtFechaFinal.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaFinal.MonthCalendar.DisplayMonth = New Date(2017, 7, 1, 0, 0, 0, 0)
        Me.dtFechaFinal.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.dtFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtFechaFinal.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaFinal.MonthCalendar.TodayButtonVisible = True
        Me.dtFechaFinal.Name = "dtFechaFinal"
        Me.dtFechaFinal.Size = New System.Drawing.Size(120, 23)
        Me.dtFechaFinal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtFechaFinal.TabIndex = 47
        '
        'dtFechaInicio
        '
        '
        '
        '
        Me.dtFechaInicio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtFechaInicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaInicio.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtFechaInicio.ButtonDropDown.Visible = True
        Me.dtFechaInicio.IsPopupCalendarOpen = False
        Me.dtFechaInicio.Location = New System.Drawing.Point(111, 112)
        '
        '
        '
        '
        '
        '
        Me.dtFechaInicio.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaInicio.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtFechaInicio.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtFechaInicio.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaInicio.MonthCalendar.DisplayMonth = New Date(2017, 7, 1, 0, 0, 0, 0)
        Me.dtFechaInicio.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.dtFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtFechaInicio.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaInicio.MonthCalendar.TodayButtonVisible = True
        Me.dtFechaInicio.Name = "dtFechaInicio"
        Me.dtFechaInicio.Size = New System.Drawing.Size(120, 23)
        Me.dtFechaInicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtFechaInicio.TabIndex = 46
        '
        'cbTipoAcuerdo
        '
        cbTipoAcuerdo_DesignTimeLayout.LayoutString = resources.GetString("cbTipoAcuerdo_DesignTimeLayout.LayoutString")
        Me.cbTipoAcuerdo.DesignTimeLayout = cbTipoAcuerdo_DesignTimeLayout
        Me.cbTipoAcuerdo.Location = New System.Drawing.Point(111, 83)
        Me.cbTipoAcuerdo.Name = "cbTipoAcuerdo"
        Me.cbTipoAcuerdo.SelectedIndex = -1
        Me.cbTipoAcuerdo.SelectedItem = Nothing
        Me.cbTipoAcuerdo.Size = New System.Drawing.Size(180, 23)
        Me.cbTipoAcuerdo.TabIndex = 45
        '
        'tbAcuCodCliente
        '
        '
        '
        '
        Me.tbAcuCodCliente.Border.Class = "TextBoxBorder"
        Me.tbAcuCodCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbAcuCodCliente.Location = New System.Drawing.Point(111, 3)
        Me.tbAcuCodCliente.MaxLength = 15
        Me.tbAcuCodCliente.Name = "tbAcuCodCliente"
        Me.tbAcuCodCliente.PreventEnterBeep = True
        Me.tbAcuCodCliente.Size = New System.Drawing.Size(160, 23)
        Me.tbAcuCodCliente.TabIndex = 44
        '
        'LabelX28
        '
        '
        '
        '
        Me.LabelX28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX28.Location = New System.Drawing.Point(5, 3)
        Me.LabelX28.Name = "LabelX28"
        Me.LabelX28.Size = New System.Drawing.Size(100, 23)
        Me.LabelX28.TabIndex = 43
        Me.LabelX28.Text = "Cod. Cliente:"
        '
        'tbAcuNombre
        '
        '
        '
        '
        Me.tbAcuNombre.Border.Class = "TextBoxBorder"
        Me.tbAcuNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbAcuNombre.Location = New System.Drawing.Point(111, 32)
        Me.tbAcuNombre.MaxLength = 50
        Me.tbAcuNombre.Multiline = True
        Me.tbAcuNombre.Name = "tbAcuNombre"
        Me.tbAcuNombre.PreventEnterBeep = True
        Me.tbAcuNombre.Size = New System.Drawing.Size(300, 45)
        Me.tbAcuNombre.TabIndex = 0
        '
        'LabelX35
        '
        '
        '
        '
        Me.LabelX35.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX35.Location = New System.Drawing.Point(5, 32)
        Me.LabelX35.Name = "LabelX35"
        Me.LabelX35.Size = New System.Drawing.Size(100, 23)
        Me.LabelX35.TabIndex = 10
        Me.LabelX35.Text = "Nombre:"
        '
        'GroupPanelDias
        '
        Me.GroupPanelDias.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelDias.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelDias.Controls.Add(Me.PanelEx1)
        Me.GroupPanelDias.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelDias.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupPanelDias.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelDias.Location = New System.Drawing.Point(1073, 5)
        Me.GroupPanelDias.Name = "GroupPanelDias"
        Me.GroupPanelDias.Size = New System.Drawing.Size(250, 486)
        '
        '
        '
        Me.GroupPanelDias.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanelDias.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanelDias.Style.BackColorGradientAngle = 90
        Me.GroupPanelDias.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDias.Style.BorderBottomWidth = 1
        Me.GroupPanelDias.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelDias.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDias.Style.BorderLeftWidth = 1
        Me.GroupPanelDias.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDias.Style.BorderRightWidth = 1
        Me.GroupPanelDias.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDias.Style.BorderTopWidth = 1
        Me.GroupPanelDias.Style.CornerDiameter = 4
        Me.GroupPanelDias.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelDias.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelDias.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelDias.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelDias.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelDias.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelDias.TabIndex = 25
        Me.GroupPanelDias.Text = "DIAS DE VISITA"
        '
        'PanelEx1
        '
        Me.PanelEx1.AutoScroll = True
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.dgjDias)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(244, 462)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.SystemColors.Control
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.SystemColors.Control
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 38
        '
        'dgjDias
        '
        Me.dgjDias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgjDias.Location = New System.Drawing.Point(0, 0)
        Me.dgjDias.Name = "dgjDias"
        Me.dgjDias.Size = New System.Drawing.Size(244, 462)
        Me.dgjDias.TabIndex = 0
        '
        'cmsProducto
        '
        Me.cmsProducto.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsProducto.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemEliminarProducto})
        Me.cmsProducto.Name = "Cms1Equipos"
        Me.cmsProducto.Size = New System.Drawing.Size(179, 36)
        '
        'ToolStripMenuItemEliminarProducto
        '
        Me.ToolStripMenuItemEliminarProducto.Image = Global.Presentacion.My.Resources.Resources.eliminar
        Me.ToolStripMenuItemEliminarProducto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItemEliminarProducto.Name = "ToolStripMenuItemEliminarProducto"
        Me.ToolStripMenuItemEliminarProducto.Size = New System.Drawing.Size(178, 32)
        Me.ToolStripMenuItemEliminarProducto.Text = "Eliminar Producto"
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
        Me.btActualizar.TabIndex = 10
        Me.btActualizar.Text = "ACTUALIZAR"
        Me.btActualizar.TextColor = System.Drawing.Color.Black
        '
        'F02_Cliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1362, 602)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "F02_Cliente"
        Me.Text = "F00_Cliente"
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
        Me.GroupPanelEquipos.ResumeLayout(False)
        Me.PanelEx7.ResumeLayout(False)
        CType(Me.DgjEquipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cms1Equipos.ResumeLayout(False)
        Me.PanelEx6.ResumeLayout(False)
        Me.PanelEx6.PerformLayout()
        CType(Me.TbiCantEntrante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbiCantSaliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbiCantSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbFiltroResumenEquipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanelDatos.ResumeLayout(False)
        CType(Me.StcSugerenciaUbicacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StcSugerenciaUbicacion.ResumeLayout(False)
        Me.SuperTabControlPanel3.ResumeLayout(False)
        CType(Me.DgjSugerencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel6.ResumeLayout(False)
        CType(Me.grCatProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel4.ResumeLayout(False)
        CType(Me.SuperTabControlUbicacionGeografica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlUbicacionGeografica.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.GroupPanelMapa.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.GroupPanelCoordenadas.ResumeLayout(False)
        Me.GroupPanelDatosGenerales.ResumeLayout(False)
        Me.PnDatosGenerales.ResumeLayout(False)
        Me.PnDatosGenerales.PerformLayout()
        CType(Me.cbTipoCredito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanelEncargados.ResumeLayout(False)
        Me.GroupPanelEncargados.PerformLayout()
        CType(Me.cbPrevendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSupervisor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtiUltimaVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtiUltimoPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtiFechaIng, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtiFechaNac, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GpEstado.ResumeLayout(False)
        Me.GpEstado.PerformLayout()
        Me.GroupPanelDatosFactura.ResumeLayout(False)
        CType(Me.CbCategoria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbZona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanelBusquedaDatos.ResumeLayout(False)
        CType(Me.DgjBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel5.ResumeLayout(False)
        Me.PanelExBaseAcuerdo.ResumeLayout(False)
        Me.GroupPanelProducto.ResumeLayout(False)
        Me.PanelEx2.ResumeLayout(False)
        CType(Me.dgjProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanelAcuerdo.ResumeLayout(False)
        Me.v.ResumeLayout(False)
        Me.v.PerformLayout()
        CType(Me.cbFrecuencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTipoAcuerdo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanelDias.ResumeLayout(False)
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.dgjDias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsProducto.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanelPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanelDatos As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupPanelDatosGenerales As DevComponents.DotNetBar.Controls.GroupPanel
    Private WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Private WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanelDatosFactura As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TbNit As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TbNombreFactura As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GpEstado As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents RbDevuelto As System.Windows.Forms.RadioButton
    Friend WithEvents RbPasivo As System.Windows.Forms.RadioButton
    Friend WithEvents RbActivo As System.Windows.Forms.RadioButton
    Friend WithEvents BtConfirmar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CbCategoria As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents CbTipoDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents CbZona As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SbEventual As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents TbObs As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TbCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TbTelefono1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TbNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TbTelefono2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TbNroDoc As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TbDireccion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents StcSugerenciaUbicacion As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents DgjSugerencia As Janus.Windows.GridEX.GridEX
    Friend WithEvents StiFiltroCliente As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GroupPanelMapa As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GmUbicacionCliente As GMap.NET.WindowsForms.GMapControl
    Friend WithEvents GroupPanelCoordenadas As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents BtMarcarPunto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents StiUbicacion As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents GroupPanelEquipos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PanelEx7 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PanelEx6 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TbiCantEntrante As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TbiCantSaliente As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TbiCantSaldo As DevComponents.Editors.IntegerInput
    Friend WithEvents CbFiltroResumenEquipo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents BtAddEquipo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupPanelBusquedaDatos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents DgjBusqueda As Janus.Windows.GridEX.GridEX
    Friend WithEvents PnDatosGenerales As DevComponents.DotNetBar.PanelEx
    Friend WithEvents DgjEquipo As Janus.Windows.GridEX.GridEX
    Friend WithEvents SuperTabControlUbicacionGeografica As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItemCoordenadas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItemMapa As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents DtiUltimaVenta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents DtiUltimoPedido As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents DtiFechaIng As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents DtiFechaNac As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents ChBuscar As System.Windows.Forms.CheckBox
    Friend WithEvents Cms1Equipos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Tsmi1Eliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbLongitud As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbLatitud As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btZoomAlejar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btZoomAcercar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupPanelEncargados As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cbPrevendedor As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbSupervisor As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX26 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbRecorrido As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbCodCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX27 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SuperTabControlPanel5 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents PanelExBaseAcuerdo As DevComponents.DotNetBar.PanelEx
    Friend WithEvents SuperTabItemAcuerdo As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents GroupPanelAcuerdo As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents v As DevComponents.DotNetBar.PanelEx
    Friend WithEvents tbAcuCodCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX28 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbAcuNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX35 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtFechaFinal As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dtFechaInicio As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents cbTipoAcuerdo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btEstado As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents cbFrecuencia As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents GroupPanelProducto As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents dgjProducto As Janus.Windows.GridEX.GridEX
    Friend WithEvents LabelX34 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX33 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX32 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX31 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX30 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX29 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbAcuObs As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanelDias As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents dgjDias As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmsProducto As ContextMenuStrip
    Friend WithEvents ToolStripMenuItemEliminarProducto As ToolStripMenuItem
    Friend WithEvents btActualizar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents SuperTabControlPanel6 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents grCatProd As Janus.Windows.GridEX.GridEX
    Friend WithEvents catProd As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents cbTipoCredito As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX36 As DevComponents.DotNetBar.LabelX
End Class
