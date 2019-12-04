Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports GMap.NET.MapProviders
Imports GMap.NET
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.ToolTips
Imports DevComponents.DotNetBar.SuperGrid
Imports System.IO
Imports DevComponents.Editors
Imports Janus.Windows.GridEX
Imports System.Threading

Public Class P_Clientes

#Region "Variable Globales"

    Dim _Nuevo As Boolean
    Dim _Mofificar As Boolean
    Dim _Eliminar As Boolean

    Dim _Grabar As Integer '1,2 Nuevo; 3,4 Modificar; 5,6 Eliminar

    Dim G_Usuario As String = P_Global.gs_user

    Dim _CodigoZona As Integer = 0
    Dim _CodigoCategoria As Integer = 0

    Dim _DuracionSms As Integer = 5
    Dim _Cont As Integer = 0

    'Dim _DsCliente As DataTable
    Dim _DsEquipo As DataSet

    Dim _MaxReg As Integer
    Dim _NavegadorReg As Integer

    Dim _Punto As Integer
    Dim _ListPuntos As List(Of PointLatLng)
    Dim _Overlay As GMapOverlay

    Dim Gr1Navegacion As GridEXRow()
    Dim ModifRestringido As Boolean = False

    Dim DtDetalle As DataTable

    Dim Bool As Boolean = False
    Dim ThCliente As Thread

    Dim DtProductosCompuestos As DataTable 'Aqui estaran todo los productos que son compuestos y los produstos que los componen

    Dim StCod As String = "0"
#End Region

#Region "Eventos"

    Private Sub P_Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        P_Inicio()
    End Sub

    Private Sub BBtn_Nuevo_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Nuevo.Click
        P_NuevoRegistro()
    End Sub

    Private Sub BBtn_Modificar_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Modificar.Click
        P_ModificarRegistro()
    End Sub

    Private Sub BBtn_Eliminar_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Eliminar.Click
        P_EliminarRegistro()
    End Sub

    Private Sub BBtn_Grabar_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Grabar.Click
        P_GrabarRegistro()
    End Sub

    Private Sub BBtn_Cancelar_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Cancelar.Click
        P_CancelarRegistro()
    End Sub

    Private Sub BBtn_Inicio_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Inicio.Click
        _NavegadorReg = 0
        P_LlenarDatos(_NavegadorReg)
        P_ActualizarPaginacion(_NavegadorReg)
    End Sub

    Private Sub BBtn_Anterior_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Anterior.Click
        _NavegadorReg -= 1
        P_LlenarDatos(_NavegadorReg)
        P_ActualizarPaginacion(_NavegadorReg)
    End Sub

    Private Sub BBtn_Siguiente_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Siguiente.Click
        _NavegadorReg += 1
        P_LlenarDatos(_NavegadorReg)
        P_ActualizarPaginacion(_NavegadorReg)
    End Sub

    Private Sub BBtn_Ultimo_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Ultimo.Click
        _NavegadorReg = _MaxReg
        P_LlenarDatos(_NavegadorReg)
        P_ActualizarPaginacion(_NavegadorReg)
    End Sub

#End Region

#Region "Metodos"



#End Region

    Private Sub P_Inicio()
        'L_abrirConexion()
        If gb_mostrarMapa = False Then
            StiUbicacion.Visible = False
        End If

        SuperTabControl1.SelectedTab = SuperTabItem1

        'BBtn_Imprimir.Visible = False
        BBtn_Error.Visible = False
        BtPasarCliente.Visible = False

        P_HabilitarComponentes(False)

        'Lbl_Sms.Text = ""
        If (gb_mostrarMapa) Then
            P_MapLoad()
        End If

        gt_Productos = L_GetProductos("caserie = " + CStr(1)).Tables(0)
        DtProductosCompuestos = New DataTable
        DtProductosCompuestos = L_fnClienteEquipoProductosCompuestos()

        'P_ArmarGrilla()
        'P_ArmarGrillaSugerencia()
        P_ArmarComboZona()
        P_ArmarComboTipoDoc()
        P_ArmarComboCategoria()
        P_ArmarComboProducto()
        CbFiltroResumenEquipo.SelectedIndex = 0

        P_ArmarGrillaEquipos()

        'P_ActualizarPuterosNavegacion()
        '_NavegadorReg = 0
        'P_LlenarDatos(_NavegadorReg)

        BBtn_Grabar.Enabled = False
        CpActCliente.Visible = False

        'activar los permisos del rol
        _PAsignarPermisos()
        _pCambiarFuente()

        Bool = True
        Gr1Navegacion = Dgj1Busqueda.GetRows
    End Sub

    Private Sub _pCambiarFuente()
        Dim fuente As New Font("Tahoma", gi_fuenteTamano, FontStyle.Regular)
        Dim xCtrl As Control
        For Each xCtrl In PanelEx3.Controls
            Try
                xCtrl.Font = fuente
            Catch ex As Exception
            End Try
        Next
        For Each xCtrl In PanelEx4.Controls
            Try
                xCtrl.Font = fuente
            Catch ex As Exception
            End Try
        Next

    End Sub

    Private Sub _PAsignarPermisos()
        Dim idRolUsu As String = L_Usuario_General(-1, " AND yduser='" + P_Global.gs_user + "' ").Tables(0).Rows(0).Item("ybnumi")
        Dim dtRolUsu As DataTable = L_RolDetalle_General2(-1, idRolUsu, "ycyanumi=1")
        Dim show As Boolean = dtRolUsu.Rows(0).Item("ycshow")
        Dim add As Boolean = dtRolUsu.Rows(0).Item("ycadd")
        Dim modif As Boolean = dtRolUsu.Rows(0).Item("ycmod")
        Dim del As Boolean = dtRolUsu.Rows(0).Item("ycdel")

        If add = False Then
            BBtn_Nuevo.Visible = False
        End If
        If modif = False Then
            BBtn_Modificar.Visible = False
        Else
            ModifRestringido = True
        End If
        If del = False Then
            BBtn_Eliminar.Visible = False
        Else
            If (gi_expcli = 1) Then
                BtPasarCliente.Visible = True
            End If
        End If

        If (add And Not modif) Then
            BBtn_Modificar.Visible = True
            ModifRestringido = False
        End If

    End Sub

    Private Sub P_HabilitarComponentes(ByVal _Bool As Boolean)
        Txt_Codigo.ReadOnly = Not _Bool
        Txt_Nombre.ReadOnly = Not _Bool
        Cbx_TipoDoc.Enabled = _Bool
        Txt_NroDoc.ReadOnly = Not _Bool
        Cbx_Categoria.Enabled = _Bool
        Gp1Estado.Enabled = _Bool
        Txt_Latitud.ReadOnly = Not _Bool
        Txt_Longitud.ReadOnly = Not _Bool
        Btnx_ChekGetPoint.Enabled = _Bool
        Gmc_Cliente.Enabled = _Bool
        Txt_Obs.ReadOnly = Not _Bool
        Sb_Eventual.Enabled = _Bool
        Dt1FechaNac.Enabled = _Bool
        Dt2FechaIng.Enabled = _Bool
        Tb10NombreFactura.ReadOnly = Not _Bool
        Tb11Nit.ReadOnly = Not _Bool

        Bt1AddEquipos.Enabled = _Bool
        Dgs_Equipos.PrimaryGrid.ReadOnly = Not _Bool

        Txt_Direccion.ReadOnly = Not _Bool
        Txt_Telefono1.ReadOnly = Not _Bool
        Txt_Telefono2.ReadOnly = Not _Bool
        Cbx_Zona.Enabled = _Bool

        SuperTabItem2.Visible = Not _Bool

        Tsmi1Eliminar.Visible = _Bool

        If (Not ModifRestringido And _Mofificar) Then
            _Bool = False
            Txt_Codigo.ReadOnly = Not _Bool
            Txt_Nombre.ReadOnly = Not _Bool
            Cbx_TipoDoc.Enabled = _Bool
            Txt_NroDoc.ReadOnly = Not _Bool
            Cbx_Categoria.Enabled = _Bool
            Gp1Estado.Enabled = _Bool
            Txt_Latitud.ReadOnly = Not _Bool
            Txt_Longitud.ReadOnly = Not _Bool
            Btnx_ChekGetPoint.Enabled = _Bool
            Gmc_Cliente.Enabled = _Bool
            Txt_Obs.ReadOnly = Not _Bool
            Sb_Eventual.Enabled = _Bool
            Dt1FechaNac.Enabled = _Bool
            Dt2FechaIng.Enabled = _Bool
            'Tb10NombreFactura.ReadOnly = Not _Bool
            'Tb11Nit.ReadOnly = Not _Bool

            Bt1AddEquipos.Enabled = _Bool
            Dgs_Equipos.PrimaryGrid.ReadOnly = Not _Bool
        End If


    End Sub

    Private Sub P_ArmarGrilla()
        '_DsCliente = New DataTable
        '_DsCliente = L_GetClientes(1)
        '_DsCliente = L_fnClientes()

        Dgj1Busqueda.BoundMode = Janus.Data.BoundMode.Bound
        Dgj1Busqueda.DataSource = P_Global.gt_Cliente
        Dgj1Busqueda.RetrieveStructure()

        'dar formato a las columnas
        With Dgj1Busqueda.RootTable.Columns(0)
            .Caption = "Código"
            .Key = "ccnumi"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With Dgj1Busqueda.RootTable.Columns(1)
            .Caption = ""
            .Key = "cccod"
            .Width = 10
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With Dgj1Busqueda.RootTable.Columns(2)
            .Caption = "Nombre"
            .Key = "ccdesc"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With Dgj1Busqueda.RootTable.Columns(3)
            .Caption = "Dirección"
            .Key = "ccdirec"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Busqueda.RootTable.Columns(4)
            .Caption = "Teléfono 2"
            .Key = "cctelf1"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With Dgj1Busqueda.RootTable.Columns(5)
            .Caption = "Teléfono 1"
            .Key = "cctelf2"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Busqueda.RootTable.Columns(6)
            .Caption = ""
            .Key = "numZona"
            .Width = 10
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With Dgj1Busqueda.RootTable.Columns(7)
            .Caption = "Zona"
            .Key = "descZona"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Busqueda.RootTable.Columns(8)
            .Caption = ""
            .Key = "numDct"
            .Width = 10
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Busqueda.RootTable.Columns(9)
            .Caption = "Tipo de Documento"
            .Key = "descDct"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Busqueda.RootTable.Columns(10)
            .Caption = "Nro Documento"
            .Key = "ccdctnum"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Busqueda.RootTable.Columns(11)
            .Caption = ""
            .Key = "numCat"
            .Width = 10
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Busqueda.RootTable.Columns(12)
            .Caption = "Categoria"
            .Key = "descCat"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Busqueda.RootTable.Columns(13)
            .Caption = "Estado"
            .Key = "ccest"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Busqueda.RootTable.Columns(14)
            .Caption = "Latitud"
            .Key = "cclat"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Busqueda.RootTable.Columns(15)
            .Caption = "Longitud"
            .Key = "cclongi"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Busqueda.RootTable.Columns(16)
            .Caption = "Eventual"
            .Key = "cceven"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Busqueda.RootTable.Columns(17)
            .Caption = "Observación"
            .Key = "ccobs"
            .Width = 250
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Busqueda.RootTable.Columns(18)
            .Caption = "Fecha de Nac"
            .Key = "ccfnac"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Busqueda.RootTable.Columns(19)
            .Caption = "Nombre Factura"
            .Key = "ccnomfac"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Busqueda.RootTable.Columns(20)
            .Caption = "NIT"
            .Key = "ccnit"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Busqueda.RootTable.Columns(21)
            .Caption = "Fecha de Ingreso"
            .Key = "ccfecing"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Busqueda.RootTable.Columns(22)
            .Caption = "Fecha de Ultimo Pedido"
            .Key = "ccultped"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Busqueda.RootTable.Columns(23)
            .Caption = "Fecha de Ultimo Venta"
            .Key = "ccultvent"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(24)
            .Caption = ""
            .Key = "ccfact"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Busqueda.RootTable.Columns(25)
            .Caption = ""
            .Key = "cchact"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With Dgj1Busqueda.RootTable.Columns(26)
            .Caption = ""
            .Key = "ccuact"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        'Habilitar Filtradores
        With Dgj1Busqueda
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
        End With
        'Dgj1Busqueda.Dock = DockStyle.Fill
        Dgj1Busqueda.BringToFront()
        Dgj1Busqueda.Refresh()
    End Sub

    Private Sub P_ArmarComboZona()
        Dim _Ds As New DataSet
        _Ds = L_GetZonasCPZ()

        Cbx_Zona.DropDownList.Columns.Add(_Ds.Tables(0).Columns("lanumi").ToString).Width = 50
        Cbx_Zona.DropDownList.Columns(0).Caption = "Código"

        Cbx_Zona.DropDownList.Columns.Add(_Ds.Tables(0).Columns("city").ToString).Width = 150
        Cbx_Zona.DropDownList.Columns(1).Caption = "Cuidad"

        Cbx_Zona.DropDownList.Columns.Add(_Ds.Tables(0).Columns("prov").ToString).Width = 150
        Cbx_Zona.DropDownList.Columns(2).Caption = "Provincia"

        Cbx_Zona.DropDownList.Columns.Add(_Ds.Tables(0).Columns("Zona").ToString).Width = 150
        Cbx_Zona.DropDownList.Columns(3).Caption = "Zona"

        Cbx_Zona.ValueMember = _Ds.Tables(0).Columns("lanumi").ToString
        Cbx_Zona.DisplayMember = _Ds.Tables(0).Columns("zona").ToString
        Cbx_Zona.DataSource = _Ds.Tables(0)
        Cbx_Zona.Refresh()
    End Sub

    Private Sub P_ArmarComboTipoDoc()
        Dim _Ds As New DataSet
        _Ds = L_GetItemsConceptoLibreria("9")

        Cbx_TipoDoc.DropDownList.Columns.Add(_Ds.Tables(0).Columns(0).ToString).Width = 50
        Cbx_TipoDoc.DropDownList.Columns(0).Caption = "Código"

        Cbx_TipoDoc.DropDownList.Columns.Add(_Ds.Tables(0).Columns(1).ToString).Width = 120
        Cbx_TipoDoc.DropDownList.Columns(1).Caption = "Descripción"

        Cbx_TipoDoc.ValueMember = _Ds.Tables(0).Columns(0).ToString
        Cbx_TipoDoc.DisplayMember = _Ds.Tables(0).Columns(1).ToString
        Cbx_TipoDoc.DataSource = _Ds.Tables(0)
        Cbx_TipoDoc.Refresh()
    End Sub

    Private Sub P_ArmarComboCategoria()
        Dim _Ds As New DataSet
        _Ds.Tables.Add(L_CategoriaPrecioGeneral())

        Cbx_Categoria.DropDownList.Columns.Add(_Ds.Tables(0).Columns(0).ToString).Width = 50
        Cbx_Categoria.DropDownList.Columns(0).Caption = "Código"

        Cbx_Categoria.DropDownList.Columns.Add(_Ds.Tables(0).Columns(1).ToString).Width = 70
        Cbx_Categoria.DropDownList.Columns(1).Caption = "Abreviatura"

        Cbx_Categoria.DropDownList.Columns.Add(_Ds.Tables(0).Columns(2).ToString).Width = 120
        Cbx_Categoria.DropDownList.Columns(2).Caption = "Descripción"

        Cbx_Categoria.ValueMember = _Ds.Tables(0).Columns(0).ToString
        Cbx_Categoria.DisplayMember = _Ds.Tables(0).Columns(1).ToString
        Cbx_Categoria.DataSource = _Ds.Tables(0)
        Cbx_Categoria.Refresh()

    End Sub

    Private Sub P_ArmarComboProducto()
        Dim dt As DataTable
        dt = gt_Productos

        CbFiltroResumenEquipo.DropDownList.Columns.Add(dt.Columns(1).ToString).Width = 80
        CbFiltroResumenEquipo.DropDownList.Columns(0).Caption = "Código"

        CbFiltroResumenEquipo.DropDownList.Columns.Add(dt.Columns(2).ToString).Width = 200
        CbFiltroResumenEquipo.DropDownList.Columns(1).Caption = "Descripción"

        CbFiltroResumenEquipo.ValueMember = dt.Columns(1).ToString
        CbFiltroResumenEquipo.DisplayMember = dt.Columns(2).ToString
        CbFiltroResumenEquipo.DataSource = dt
        CbFiltroResumenEquipo.Refresh()
    End Sub

    

    Private Sub P_ActualizarPuterosNavegacion()
        'If (Gr1Navegacion Is Nothing) Then
        '    
        'End If
        _MaxReg = Dgj1Busqueda.GetRows.Count - 1
        If (_NavegadorReg > _MaxReg) Then
            _NavegadorReg = _MaxReg
        End If
        P_ActualizarPaginacion(_NavegadorReg)
    End Sub

    Private Sub P_LlenarDatos(ByVal _index As Integer)
        If (_index <= _MaxReg And _index >= 0 And Gr1Navegacion.Count > 0) Then
            Me.Txt_Codigo.Text = Gr1Navegacion(_index).Cells("ccnumi").Value.ToString
            Me.Txt_Nombre.Text = Gr1Navegacion(_index).Cells("ccdesc").Value.ToString
            Me.Cbx_Zona.Value = CInt(Gr1Navegacion(_index).Cells("numZona").Value.ToString)
            Me.Cbx_TipoDoc.Value = CInt(Gr1Navegacion(_index).Cells("numDct").Value.ToString)
            Me.Txt_NroDoc.Text = Gr1Navegacion(_index).Cells("ccdctnum").Value.ToString
            Me.Txt_Direccion.Text = Gr1Navegacion(_index).Cells("ccdirec").Value.ToString
            Me.Txt_Telefono1.Text = Gr1Navegacion(_index).Cells("cctelf1").Value.ToString
            Me.Txt_Telefono2.Text = Gr1Navegacion(_index).Cells("cctelf2").Value.ToString
            Me.Cbx_Categoria.Value = CInt(Gr1Navegacion(_index).Cells("numCat").Value.ToString)

            If (Gr1Navegacion(_index).Cells("ccest").Value.ToString.Equals("1")) Then 'activo
                Rb1Activo.Checked = True
            ElseIf (Gr1Navegacion(_index).Cells("ccest").Value.ToString.Equals("0")) Then 'pasivo
                Rb2Pasivo.Checked = True
            ElseIf (Gr1Navegacion(_index).Cells("ccest").Value.ToString.Equals("2")) Then 'devueto
                Rb3Devuelto.Checked = True
            End If
            Me.Txt_Latitud.Text = Gr1Navegacion(_index).Cells("cclat").Value.ToString
            Me.Txt_Longitud.Text = Gr1Navegacion(_index).Cells("cclongi").Value.ToString
            Me.Txt_Obs.Text = Gr1Navegacion(_index).Cells("ccobs").Value.ToString
            Me.Sb_Eventual.Value = Gr1Navegacion(_index).Cells("cceven").Value.ToString.Equals("False")
            Me.Dt1FechaNac.Text = Gr1Navegacion(_index).Cells("ccfnac").Value.ToString
            Me.Tb10NombreFactura.Text = Gr1Navegacion(_index).Cells("ccnomfac").Value.ToString
            Me.Tb11Nit.Text = Gr1Navegacion(_index).Cells("ccnit").Value.ToString
            Me.Dt2FechaIng.Text = Gr1Navegacion(_index).Cells("ccfecing").Value.ToString

            If (Gr1Navegacion(_index).Cells("ccultped").Value.ToString.Equals("")) Then
                Me.DtiUltimoPedido.Value = Dt2FechaIng.Value
            Else
                Me.DtiUltimoPedido.Value = Gr1Navegacion(_index).Cells("ccultped").Value.ToString
            End If

            If (Gr1Navegacion(_index).Cells("ccultvent").Value.ToString.Equals("")) Then
                Me.DtiUltimaVenta.Value = "01/01/2000"
            Else
                Me.DtiUltimaVenta.Value = Gr1Navegacion(_index).Cells("ccultvent").Value
            End If

            StCod = Gr1Navegacion(_index).Cells("cccod").Value.ToString
            'Aqui de coloca los datos del Mapa
            If (gb_mostrarMapa) Then
                If (CDbl(Txt_Latitud.Text.Replace("-", "")) > 0 And CDbl(Txt_Longitud.Text.Replace("-", "")) > 0) Then
                    '_ListPuntos.Clear()
                    _Overlay.Markers.Clear()
                    Dim plg As PointLatLng = New PointLatLng(CDbl(Txt_Latitud.Text), CDbl(Txt_Longitud.Text))
                    P_AgregarPunto(plg)
                Else
                    '_ListPuntos.Clear()
                    _Overlay.Markers.Clear()
                End If
            End If
            'Aqui se coloca los datos de la grilla de los Equipos
            P_PonerDatosEquipoPorCliente(Txt_Codigo.Text)
            P_PonerResumenEquipo()
        Else
            If (_NavegadorReg < 0) Then
                _NavegadorReg = 0
            Else
                _NavegadorReg = _MaxReg
            End If
        End If
    End Sub

    Private Sub P_ActualizarPaginacion(ByVal _index As Integer)
        Txt_Paginacion.Text = "Reg. " & _index + 1 & " de " & _MaxReg + 1
    End Sub

    Private Sub P_NuevoRegistro()
        P_Limpiar()
        _Nuevo = True
        _Mofificar = False
        _Eliminar = False
        BBtn_Grabar.TooltipText = "GRABAR NUEVO REGISTRO"
        P_HabilitarComponentes(_Nuevo)
        Sb_Eventual.Value = False
        Txt_Nombre.Select()
        _Grabar = 1

        Rl1Accion.Text = "NUEVO"
        DtDetalle = L_fnClienteEquipo("-1")
        Dgs_Equipos.PrimaryGrid.DataSource = DtDetalle
        P_ArmarGrillaSugerencia()
        'Ocultar boton BtPasarCliente
        BtPasarCliente.Enabled = False
    End Sub

    Private Sub P_ModificarRegistro()
        If (Gr1Navegacion.Count = 0) Then
            ToastNotification.Show(Me, "no hay registro para modificar".ToUpper + Chr(13) + "debe filtrar datos el la grilla de busqueda".ToUpper,
                       My.Resources.WARNING,
                       _DuracionSms * 1000,
                       eToastGlowColor.Orange,
                       eToastPosition.TopCenter)
            BBtn_Cancelar.InvokeClick(eEventSource.Mouse, Windows.Forms.MouseButtons.Left)
            Exit Sub
        End If

        _Nuevo = False
        _Mofificar = True
        _Eliminar = False
        BBtn_Grabar.TooltipText = "GRABAR MODIFICACIÓN DE REGISTRO"
        P_HabilitarComponentes(_Mofificar)
        Txt_Nombre.SelectAll()
        _Grabar = 3

        Rl1Accion.Text = "MODIFICAR"
        DtDetalle = L_fnClienteEquipo(Txt_Codigo.Text.Trim)
        Dgs_Equipos.PrimaryGrid.DataSource = DtDetalle
        'Ocultar boton BtPasarCliente
        BtPasarCliente.Enabled = False
    End Sub

    Private Sub P_EliminarRegistro()
        If (Gr1Navegacion.Count = 0) Then
            ToastNotification.Show(Me, "no hay registro para eliminar".ToUpper + Chr(13) + "debe filtrar datos el la grilla de busqueda".ToUpper,
                       My.Resources.WARNING,
                       _DuracionSms * 1000,
                       eToastGlowColor.Red,
                       eToastPosition.TopCenter)
            BBtn_Cancelar.InvokeClick(eEventSource.Mouse, Windows.Forms.MouseButtons.Left)
            Exit Sub
        End If

        _Nuevo = False
        _Mofificar = False
        _Eliminar = True
        BBtn_Grabar.TooltipText = "GRABAR ELIMINACIÓN DE REGISTRO"
        P_HabilitarComponentes(False)
        ToastNotification.Show(Me, "SE ELIMINARÁ ESTE EL CLIENTE CON CÓDIGO: " + Txt_Codigo.Text, My.Resources.INFORMATION, _DuracionSms * 1000, eToastGlowColor.Blue, eToastPosition.BottomRight)
        _Grabar = 5

        Rl1Accion.Text = "ELIMINAR"
        'Ocultar boton BtPasarCliente
        BtPasarCliente.Enabled = False
    End Sub

    Private Sub P_GrabarRegistro()
        Dim numi As String
        Dim cod As String
        Dim desc As String
        Dim zona As String
        Dim dct As String
        Dim dctnum As String
        Dim direc As String
        Dim telf1 As String
        Dim telf2 As String
        Dim cat As String
        Dim est As String
        Dim lat As String
        Dim lon As String
        Dim prconsu As String
        Dim even As String
        Dim obs As String
        Dim fnac As String
        Dim nomfac As String
        Dim nit As String
        Dim ultped As String
        Dim fecing As String
        Dim ultvent As String

        If (_Nuevo) Then
            If (P_Validar()) Then
                If (_Grabar = 2) Then
                    numi = L_GetLastIdTablas("TC004", "ccnumi") + 1
                    cod = "0"
                    desc = Txt_Nombre.Text.Trim

                    zona = Cbx_Zona.Value
                    dct = Cbx_TipoDoc.Value
                    dctnum = IIf(Txt_NroDoc.Text.Trim.Equals(""), "S/DOC", Txt_NroDoc.Text.Trim)
                    direc = IIf(Txt_Direccion.Text.Trim.Equals(""), "S/DIR", Txt_Direccion.Text.Trim)
                    telf1 = IIf(Txt_Telefono1.Text.Trim.Equals(""), "S/T", Txt_Telefono1.Text.Trim)
                    telf2 = IIf(Txt_Telefono2.Text.Trim.Equals(""), "S/T", Txt_Telefono2.Text.Trim)
                    cat = Cbx_Categoria.Value
                    est = "1"
                    If (Rb1Activo.Checked) Then
                        est = "1"
                    ElseIf (Rb2Pasivo.Checked) Then
                        est = "0"
                    ElseIf (Rb3Devuelto.Checked) Then
                        est = "2"
                    End If
                    lat = IIf(Txt_Latitud.Text.Trim.Equals(""), 0, Txt_Latitud.Text.Trim)
                    lon = IIf(Txt_Longitud.Text.Trim.Equals(""), 0, Txt_Longitud.Text.Trim)
                    prconsu = "0"
                    even = IIf(Sb_Eventual.Value, "0", "1")
                    obs = IIf(Txt_Obs.Text.Trim.Equals(""), "S/OBS", Txt_Obs.Text.Trim)
                    fnac = Dt1FechaNac.Value.Date.ToString("yyyy/MM/dd")
                    nomfac = IIf(Tb10NombreFactura.Text.Trim.Equals(""), "S/N", Tb10NombreFactura.Text.Trim)
                    nit = IIf(Tb11Nit.Text.Trim.Equals(""), "S/NIT", Tb11Nit.Text.Trim)
                    ultped = Dt2FechaIng.Value.Date.ToString("yyyy/MM/dd")
                    fecing = Dt2FechaIng.Value.Date.ToString("yyyy/MM/dd")
                    ultvent = "2000/01/01"

                    Bt1AddEquipos.Select()

                    Dim dt As DataTable = CType(Dgs_Equipos.PrimaryGrid.DataSource, DataTable).DefaultView.ToTable(True, "chnumi", "chfec", "chcod", "chdesc", "chtmov", "chnrem", "chcan", "chmonbs", "chmonsus", "chnota", "chlin", "estado")

                    L_fnGrabarCliente(numi, cod, desc, zona, dct, dctnum, direc, telf1, telf2, cat,
                                      est, lat, lon, prconsu, even, obs, fnac, nomfac, nit, ultped,
                                      fecing, ultvent, dt)



                    P_AUDFilaClientes(L_fnCliente(numi), 1)

                    'P_Limpiar()
                    BBtn_Grabar.TooltipText = "GRABAR"

                    ToastNotification.Show(Me, "SE HA GUARDADO EXITOSAMENTE..!!!", My.Resources.GRABACION_EXITOSA, _DuracionSms * 1000, eToastGlowColor.Green, eToastPosition.TopCenter)
                    _Cont = 0

                    'P_ArmarGrilla()
                    BBtn_Cancelar.InvokeClick(eEventSource.Mouse, Windows.Forms.MouseButtons.Left)

                    _Grabar = 1
                Else
                    BBtn_Grabar.TooltipText = "CONFIRMAR GRABADO DE REGISTRO"
                    _Grabar = 2
                End If
            Else
                Hl_Clientes.SetHighlightColor(Txt_Nombre, DevComponents.DotNetBar.Validator.eHighlightColor.Red)

                _Cont = 0
                ToastNotification.Show(Me, "FALTAN DATOS..!!!", My.Resources.WARNING, _DuracionSms * 1000, eToastGlowColor.Orange, eToastPosition.TopCenter)
            End If

        ElseIf (_Mofificar) Then
            If (P_Validar()) Then
                If (_Grabar = 4) Then
                    numi = Txt_Codigo.Text.Trim
                    cod = StCod
                    desc = Txt_Nombre.Text.Trim
                    zona = Cbx_Zona.Value
                    dct = Cbx_TipoDoc.Value
                    dctnum = Txt_NroDoc.Text
                    direc = Txt_Direccion.Text
                    telf1 = Txt_Telefono1.Text
                    telf2 = Txt_Telefono2.Text
                    cat = Cbx_Categoria.Value
                    est = "1"
                    If (Rb1Activo.Checked) Then
                        est = "1"
                    ElseIf (Rb2Pasivo.Checked) Then
                        est = "0"
                    ElseIf (Rb3Devuelto.Checked) Then
                        est = "2"
                    End If
                    lat = IIf(Txt_Latitud.Text.Trim.Equals(""), 0, Txt_Latitud.Text.Trim)
                    lon = IIf(Txt_Longitud.Text.Trim.Equals(""), 0, Txt_Longitud.Text.Trim)
                    even = IIf(Sb_Eventual.Value, "0", "1")
                    obs = IIf(Txt_Obs.Text.Trim.Equals(""), "S/OBS", Txt_Obs.Text.Trim)
                    fnac = Dt1FechaNac.Value.Date.ToString("yyyy/MM/dd")
                    nomfac = Tb10NombreFactura.Text.Trim
                    nit = Tb11Nit.Text.Trim
                    ultped = DtiUltimoPedido.Value.ToString("yyyy/MM/dd")
                    fecing = Dt2FechaIng.Value.Date.ToString("yyyy/MM/dd")
                    ultvent = DtiUltimaVenta.Value.ToString("yyyy/MM/dd")

                    Bt1AddEquipos.Select()

                    Dim dt As DataTable = CType(Dgs_Equipos.PrimaryGrid.DataSource, DataTable).DefaultView.ToTable(True, "chnumi", "chfec", "chcod", "chdesc", "chtmov", "chnrem", "chcan", "chmonbs", "chmonsus", "chnota", "chlin", "estado")

                    L_fnModificarCliente(numi, cod, desc, zona, dct, dctnum, direc, telf1, telf2, cat,
                                      est, lat, lon, even, obs, fnac, nomfac, nit, ultped,
                                      fecing, ultvent, dt)

                    P_AUDFilaClientes(L_fnCliente(numi), 2, numi)

                    BBtn_Grabar.TooltipText = "GRABAR"

                    ToastNotification.Show(Me, "SE HA MODIFICADO EXITOSAMENTE...!!!", My.Resources.GRABACION_EXITOSA, _DuracionSms * 1000, eToastGlowColor.Green, eToastPosition.TopCenter)
                    _Cont = 0

                    'P_ArmarGrilla()

                    BBtn_Cancelar.InvokeClick(eEventSource.Mouse, Windows.Forms.MouseButtons.Left)

                    _Grabar = 3
                Else
                    BBtn_Grabar.TooltipText = "CONFIRMAR MODIFICACIÓN DE REGISTRO"
                    _Grabar = 4
                End If
            Else
                _Cont = 0
                ToastNotification.Show(Me, "DEBE ELEGIR UN REGISTRO...!!!", My.Resources.WARNING, _DuracionSms * 1000, eToastGlowColor.Orange, eToastPosition.TopCenter)
            End If

        ElseIf (_Eliminar) Then
            If (P_Validar()) Then
                If (_Grabar = 6) Then
                    numi = Txt_Codigo.Text.Trim

                    L_fnEliminarCliente(numi)

                    P_AUDFilaClientes(L_fnCliente(numi), 3, numi)
                    BBtn_Grabar.TooltipText = "GRABAR"

                    ToastNotification.Show(Me, "SE HA ELIMINADO EXITOSAMENTE EL CLIENTE CON CÓDIGO: " + numi, My.Resources.GRABACION_EXITOSA, _DuracionSms * 1000, eToastGlowColor.Red, eToastPosition.TopCenter)
                    _Cont = 0

                    Dgj1Busqueda.RemoveFilters()
                    Dgj1Busqueda.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(Dgj1Busqueda.RootTable.Columns("ccnumi"), Janus.Windows.GridEX.ConditionOperator.Equal, "-1"))
                    Gr1Navegacion = Dgj1Busqueda.GetRows
                    P_ActualizarPuterosNavegacion()
                    _NavegadorReg = 0
                    P_LlenarDatos(_NavegadorReg)
                    P_Limpiar()

                    _Grabar = 5
                Else
                    BBtn_Grabar.TooltipText = "CONFIRMAR ELIMINACIÓN DE REGISTRO"
                    _Grabar = 6
                End If
            Else
                _Cont = 0
                ToastNotification.Show(Me, "DEBE ELEGIR UN REGISTRO...!!!", My.Resources.WARNING, _DuracionSms * 1000, eToastGlowColor.Orange, eToastPosition.TopCenter)
            End If
        End If
        'P_ActualizarPuterosNavegacion()
    End Sub

    Private Sub P_CancelarRegistro()
        If (_Nuevo Or _Mofificar Or _Eliminar) Then
            'P_Limpiar()
            P_HabilitarComponentes(False)
            'Gr1Navegacion = Dgj1Busqueda.GetRows
            'P_LlenarDatos(_NavegadorReg)
            _Grabar = 0
            Rl1Accion.Text = ""

            'Dgj1Busqueda.RemoveFilters()
            'Dgj1Busqueda.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(Dgj1Busqueda.RootTable.Columns("ccnumi"), Janus.Windows.GridEX.ConditionOperator.Equal, "-1"))
            'Gr1Navegacion = Dgj1Busqueda.GetRows
            'P_ActualizarPuterosNavegacion()
            '_NavegadorReg = 0
            'P_LlenarDatos(_NavegadorReg)
            P_Limpiar()
        End If
        SuperTabItem2.Visible = True
        'Ocultar boton BtPasarCliente
        BtPasarCliente.Enabled = True
    End Sub

    Private Sub P_Limpiar()
        Txt_Codigo.Clear()
        Txt_Nombre.Clear()
        Cbx_Zona.SelectedIndex = 0
        Cbx_TipoDoc.SelectedIndex = 0
        Txt_NroDoc.Clear()
        Txt_Direccion.Clear()
        Txt_Telefono1.Clear()
        Txt_Telefono2.Clear()
        Cbx_Categoria.SelectedIndex = 0
        Rb1Activo.Checked = True
        Sb_Eventual.Value = True
        Txt_Obs.Clear()
        Tb10NombreFactura.Clear()
        Tb11Nit.Clear()
        Dt1FechaNac.Value = "01/01/2000"
        Dt2FechaIng.Value = Now.Date.ToString("yyyy/MM/dd")
        DtiUltimoPedido.Value = Now.Date.AddDays(-1).ToString("yyyy/MM/dd")
        DtiUltimaVenta.Value = "01/01/2000"

        _Nuevo = False
        _Mofificar = False
        _Eliminar = False

        BBtn_Grabar.TooltipText = "GRABAR"

        Dgs_Equipos.PrimaryGrid.Rows.Clear()
        If (gb_mostrarMapa) Then
            _Overlay.Markers.Clear()
            P_MapLoad()

            Txt_Latitud.Clear()
            Txt_Longitud.Clear()
        End If
        DgjSugerencias.DataSource = Nothing
        StCod = "0"
    End Sub

    Private Sub Txt_NroDoc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_NroDoc.KeyPress
        g_prValidarTextBox(1, e)
    End Sub

    Private Sub Txt_Telefono1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Telefono1.KeyPress
        g_prValidarTextBox(1, e)
    End Sub

    Private Sub Txt_Telefono2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Telefono2.KeyPress
        g_prValidarTextBox(1, e)
    End Sub

    Public Overrides Function P_Validar() As Boolean
        If (Txt_Nombre.Text.Trim.Equals("")) Then
            ToastNotification.Show(Me, "El nombre no puede estar vacio".ToUpper,
                       My.Resources.WARNING,
                       _DuracionSms * 1000,
                       eToastGlowColor.Red,
                       eToastPosition.BottomLeft)
            Return False
            Exit Function
        End If
        If (Txt_NroDoc.Text.Trim.Equals("")) Then
            ToastNotification.Show(Me, "El Nro de Documento no puede estar vacio".ToUpper,
                       My.Resources.WARNING,
                       _DuracionSms * 1000,
                       eToastGlowColor.Red,
                       eToastPosition.BottomLeft)
            Return False
            Exit Function
        End If
        If (_Eliminar) Then
            If (Dt2FechaIng.Value > DtiUltimoPedido.Value) Then
                ToastNotification.Show(Me, "No se puede eliminar a este cliente, tiene pedido realizados!!!".ToUpper,
                       My.Resources.WARNING,
                       _DuracionSms * 1000,
                       eToastGlowColor.Red,
                       eToastPosition.BottomLeft)
                Return False
                Exit Function
            End If
        End If
        Return True
    End Function

    Private Sub Sdgv_Personas_CellClick(sender As Object, e As DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs)
        If (e.GridCell.RowIndex > -1) Then
            P_LlenarDatos(e.GridCell.RowIndex)
            P_ActualizarPaginacion(e.GridCell.RowIndex)
            _NavegadorReg = e.GridCell.RowIndex
        End If
    End Sub

    Private Sub P_MapLoad()
        _Punto = 0
        '_ListPuntos = New List(Of PointLatLng)
        _Overlay = New GMapOverlay("points")
        Gmc_Cliente.Overlays.Add(_Overlay)

        P_IniciarMap()
    End Sub

    Private Sub P_IniciarMap()
        Gmc_Cliente.DragButton = MouseButtons.Left
        Gmc_Cliente.CanDragMap = True
        Gmc_Cliente.MapProvider = GMapProviders.GoogleMap
        Gmc_Cliente.Position = New PointLatLng(-17.782814, -63.182386)
        Gmc_Cliente.MinZoom = 0
        Gmc_Cliente.MaxZoom = 24
        Gmc_Cliente.Zoom = 15.5
        Gmc_Cliente.AutoScroll = True
        GMapProvider.Language = LanguageType.Spanish
    End Sub

    Private Sub P_AgregarPunto(pointLatLng As PointLatLng)

        'añadir puntos
        'Dim markersOverlay As New GMapOverlay("markers")
        Dim marker As New GMarkerGoogle(pointLatLng, GMarkerGoogleType.blue)
        'añadir tooltip
        Dim mode As MarkerTooltipMode = MarkerTooltipMode.OnMouseOver
        marker.ToolTip = New GMapBaloonToolTip(marker)
        marker.ToolTipMode = mode
        Dim ToolTipBackColor As New SolidBrush(Color.Red)
        marker.ToolTip.Fill = ToolTipBackColor
        marker.ToolTipText = "CLIENTE NUEVO; " + Txt_Nombre.Text

        _Overlay.Markers.Add(marker)
        'mapa.Overlays.Add(markersOverlay)

        Gmc_Cliente.Position = pointLatLng
    End Sub

    Private Sub Gmc_Cliente_Click(sender As Object, e As EventArgs) Handles Gmc_Cliente.Click
        'If _Punto = 1 Then

        '_ListPuntos.Clear()
        _Overlay.Markers.Clear()

        Dim gm As GMapControl = CType(sender, GMapControl)
        Dim hj As MouseEventArgs = CType(e, MouseEventArgs)
        Dim plg As PointLatLng = gm.FromLocalToLatLng(hj.X, hj.Y)
        Txt_Latitud.Text = plg.Lat
        Txt_Longitud.Text = plg.Lng
        P_AgregarPunto(plg)
        '_ListPuntos.Add(plg)
        Btnx_ChekGetPoint.Visible = False

        '_Punto = 2
        'End If
    End Sub

    Private Sub Txt_Latitud_KeyPress(sender As Object, e As KeyPressEventArgs)
        g_prValidarTextBox(5, e)
    End Sub

    Private Sub Txt_Longitud_KeyPress(sender As Object, e As KeyPressEventArgs)
        g_prValidarTextBox(5, e)
    End Sub

    Private Sub Btnx_ChekGetPoint_Click(sender As Object, e As EventArgs) Handles Btnx_ChekGetPoint.Click
        ''If Btnx_ChekGetPoint.Text = "PONER UBICACIÓN" Then

        '_ListPuntos.Clear()
        _Overlay.Markers.Clear()
        ''GM_mapa.Refresh()
        ''mapa.PolygonsEnabled = True
        ''Dim polyOverlay As New GMapOverlay("polygons")
        'Dim polygon As New GMapPolygon(_ListPuntos, "mypolygon")
        ''agregar color
        'polygon.Fill = New SolidBrush(Color.FromArgb(50, Color.Blue))

        ''polygon.Fill = New SolidBrush(Color.FromArgb(50, Color.Black))
        'polygon.Stroke = New Pen(Color.Red, 1)
        '_Overlay.Polygons.Add(polygon)
        ''añadir tooltip a poligono

        ''mapa.Overlays.Add(polyOverlay)

        ''    _Punto = 0

        ''    Btnx_ChekGetPoint.Text = "MARCAR UBICACIÓN"
        ''Else
        ''    Btnx_ChekGetPoint.Text = "PONER UBICACIÓN"
        ''    _Punto = 1
        ''End If

        ''If (Btnx_ChekGetPoint.Text.Equals("PONER UBICACIÓN")) Then
        Dim plg As PointLatLng = New PointLatLng(CDbl(Txt_Latitud.Text), CDbl(Txt_Longitud.Text))
        P_AgregarPunto(plg)
        ''ElseIf (Btnx_ChekGetPoint.Text.Equals("MARCAR UBICACIÓN")) Then

        ''End If
    End Sub

    Private Sub Btnx_Equipos_Click(sender As Object, e As EventArgs) Handles Bt1AddEquipos.Click
        If (Dgs_Equipos.PrimaryGrid.Rows.Count = 0) Then
            P_AddFilaEquipos()
            'Dim dt As DataTable = Dgs_Equipos.PrimaryGrid.DataSource
            Dgs_Equipos.Select()
            Dgs_Equipos.PrimaryGrid.SetActiveCell(Dgs_Equipos.PrimaryGrid.GetCell(0, Dgs_Equipos.PrimaryGrid.Columns("chcod").ColumnIndex))
        Else
            If (P_ValidarFilaGridEquipo(Dgs_Equipos.PrimaryGrid.Rows.Count - 1)) Then
                P_AddFilaEquipos()
                Dgs_Equipos.Select()
                Dgs_Equipos.PrimaryGrid.SetActiveCell(Dgs_Equipos.PrimaryGrid.GetCell(0, Dgs_Equipos.PrimaryGrid.Columns("chcod").ColumnIndex))
            End If
        End If
        SendKeys.Send("{F2}")
    End Sub

    Private Sub P_ArmarGrillaEquipos()
        'Formato de datatable
        DtDetalle = L_fnClienteEquipo("-1")

        'Formato de la grilla
        Dim col As GridColumn
        With Dgs_Equipos.PrimaryGrid
            col = New GridColumn
            col.Name = "chnumi" '1 : Numi
            col.HeaderText = "Numi"
            col.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
            col.Width = 0
            col.Visible = False
            col.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            col.CellStyles.Default.Font = New Font("Arial", gi_fuenteTamano)
            .Columns.Add(col)

            col = New GridColumn
            col.Name = "chfec" '2 : Fecha
            col.HeaderText = "Fecha"
            col.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
            col.Width = 120
            col.Visible = True
            col.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDateTimePickerEditControl)
            col.CellStyles.Default.Font = New Font("Arial", gi_fuenteTamano)
            .Columns.Add(col)

            col = New GridColumn
            col.Name = "chcod" '3 : Codigo de Producto
            col.HeaderText = "Código"
            col.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
            col.Width = 100
            col.Visible = True
            col.EditorType = GetType(MyComboBoxProducto)
            col.CellStyles.Default.Font = New Font("Arial", gi_fuenteTamano)
            .Columns.Add(col)

            col = New GridColumn
            col.Name = "chdesc" '4 : Descripción
            col.HeaderText = "Descripción"
            col.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft
            col.Width = 250
            col.Visible = True
            col.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            col.CellStyles.Default.Font = New Font("Arial", gi_fuenteTamano)
            .Columns.Add(col)

            col = New GridColumn
            col.Name = "chtmov" '5 : En Calidad de 
            col.HeaderText = "En Calidad de"
            col.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft
            col.Width = 150
            col.Visible = True
            col.EditorType = GetType(MyComboBoxMovimiento)
            col.CellStyles.Default.Font = New Font("Arial", gi_fuenteTamano)
            .Columns.Add(col)

            col = New GridColumn
            col.Name = "chnrem" '7 : Nota de Remición
            col.HeaderText = "Nro Remición"
            col.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
            col.Width = 120
            col.Visible = True
            col.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            col.CellStyles.Default.Font = New Font("Arial", gi_fuenteTamano)
            .Columns.Add(col)

            col = New GridColumn
            col.Name = "chcan" '6 : Cantidad
            col.HeaderText = "Cantidad"
            col.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
            col.Width = 100
            col.Visible = True
            col.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            col.CellStyles.Default.Font = New Font("Arial", gi_fuenteTamano)
            .Columns.Add(col)

            col = New GridColumn
            col.Name = "chmonbs" '8 : Monto Bs
            col.HeaderText = "Monto Bs"
            col.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
            col.Width = 100
            col.Visible = True
            col.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            col.CellStyles.Default.Font = New Font("Arial", gi_fuenteTamano)
            .Columns.Add(col)

            col = New GridColumn
            col.Name = "chmonsus" '9 : Monto Bs
            col.HeaderText = "Monto Sus"
            col.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
            col.Width = 100
            col.Visible = False
            col.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            col.CellStyles.Default.Font = New Font("Arial", gi_fuenteTamano)
            .Columns.Add(col)

            col = New GridColumn
            col.Name = "chnota" '10 : Nota
            col.HeaderText = "Nota"
            col.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
            col.Width = 120
            col.Visible = True
            col.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            col.CellStyles.Default.Font = New Font("Arial", gi_fuenteTamano)
            .Columns.Add(col)

            col = New GridColumn
            col.Name = "chlin" '11 : Nro de linea
            col.HeaderText = "Linea"
            col.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
            col.Width = 80
            col.Visible = False
            col.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            col.CellStyles.Default.Font = New Font("Arial", gi_fuenteTamano)
            .Columns.Add(col)

            col = New GridColumn
            col.Name = "estado" '12 : Estado
            col.HeaderText = "Estado"
            col.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
            col.Width = 80
            col.Visible = False
            col.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            col.CellStyles.Default.Font = New Font("Arial", gi_fuenteTamano)
            .Columns.Add(col)

            col = New GridColumn
            col.Name = "cpmov" '13 : cpmov
            col.HeaderText = ""
            col.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
            col.Width = 0
            col.Visible = False
            col.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            col.CellStyles.Default.Font = New Font("Arial", gi_fuenteTamano)
            .Columns.Add(col)

            col = New GridColumn
            col.Name = "cpmovcli" '14 : cpmovcli
            col.HeaderText = ""
            col.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
            col.Width = 0
            col.Visible = False
            col.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            col.CellStyles.Default.Font = New Font("Arial", gi_fuenteTamano)
            .Columns.Add(col)
        End With

    End Sub

    Dim _fil As DevComponents.DotNetBar.SuperGrid.GridRow
    Dim _cel As DevComponents.DotNetBar.SuperGrid.GridCell
    Private Sub P_AddFilaEquipos()
        _fil = New DevComponents.DotNetBar.SuperGrid.GridRow

        'numi
        _cel = New DevComponents.DotNetBar.SuperGrid.GridCell
        '_cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
        _cel.Value = "0"
        _fil.Cells.Add(_cel) '1


        'fecha
        _cel = New DevComponents.DotNetBar.SuperGrid.GridCell
        '_cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDateTimePickerEditControl)
        _cel.Value = Now.Date
        _fil.Cells.Add(_cel) '2

        'chcod producto
        _cel = New DevComponents.DotNetBar.SuperGrid.GridCell
        '_cel.EditorType = GetType(MyComboBoxProducto)
        Dim cprod As String = L_GetFilaTabla("TC001", "top(1) cacod", "caest=1 and caserie=1").Item("cacod").ToString
        _cel.Value = cprod
        _cel.SetActive(True)
        _fil.Cells.Add(_cel) '3

        'descripción de Producto
        _cel = New DevComponents.DotNetBar.SuperGrid.GridCell
        '_cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
        _cel.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft
        _cel.Value = L_GetDatoTabla("TC001", "cadesc", "cacod='" + cprod + "'")
        _cel.ReadOnly = True
        _fil.Cells.Add(_cel) '4

        'en calidad de
        _cel = New DevComponents.DotNetBar.SuperGrid.GridCell
        '_cel.EditorType = GetType(MyComboBoxMovimiento)
        _cel.Value = L_GetFilaTabla("TCI001", "top(1) cpnumi", "cptipo=1 and cpest=1").Item("cpnumi")
        _fil.Cells.Add(_cel) '5

        'nota de remicion
        _cel = New DevComponents.DotNetBar.SuperGrid.GridCell
        '_cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
        _cel.Value = 0
        _fil.Cells.Add(_cel) '6

        'cantidad
        _cel = New DevComponents.DotNetBar.SuperGrid.GridCell
        '_cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
        _cel.Value = 0
        _fil.Cells.Add(_cel) '7

        'monto bs
        _cel = New DevComponents.DotNetBar.SuperGrid.GridCell
        '_cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
        _cel.Value = 0
        _fil.Cells.Add(_cel) '8

        'monto sus
        _cel = New DevComponents.DotNetBar.SuperGrid.GridCell
        '_cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
        _cel.Value = 0
        _fil.Cells.Add(_cel) '9

        'nota
        _cel = New DevComponents.DotNetBar.SuperGrid.GridCell
        '_cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
        _cel.Value = 0
        _fil.Cells.Add(_cel) '10

        'nro linea
        _cel = New DevComponents.DotNetBar.SuperGrid.GridCell
        '_cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
        _cel.Value = 0
        _fil.Cells.Add(_cel) '11

        'estado
        _cel = New DevComponents.DotNetBar.SuperGrid.GridCell
        '_cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
        _cel.Value = 0
        _fil.Cells.Add(_cel) '12

        'indicador de movimiento
        _cel = New DevComponents.DotNetBar.SuperGrid.GridCell
        '_cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
        _cel.Value = 0
        _fil.Cells.Add(_cel) '13

        'incluidor de movimiento al progama de cliente
        _cel = New DevComponents.DotNetBar.SuperGrid.GridCell
        '_cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
        _cel.Value = 0
        _fil.Cells.Add(_cel) '13

        Dgs_Equipos.PrimaryGrid.Rows.Insert(0, _fil)
    End Sub

    Private Sub Sgc_Equipos_EndEdit(sender As Object, e As GridEditEventArgs) Handles Dgs_Equipos.EndEdit
        If (e.GridCell.RowIndex > -1) Then
            'Producto
            If (e.GridCell.ColumnIndex = Dgs_Equipos.PrimaryGrid.Columns("chcod").ColumnIndex) Then
                G_CodProducto = e.GridCell.FormattedValue.Trim

                Dim _f As GridRow = CType(Dgs_Equipos.PrimaryGrid.Rows(e.GridCell.RowIndex), GridRow)
                Dim _c As GridCell = CType(_f.Cells("chdesc"), GridCell)
                _c.Value = L_GetIdProductoEquipo("cacod = '" + e.GridCell.FormattedValue.Trim + "'")

            End If
        End If
    End Sub

    Private Sub Sgc_Equipos_GridPreviewKeyDown(sender As Object, e As GridPreviewKeyDownEventArgs) Handles Dgs_Equipos.GridPreviewKeyDown
        Dim _col As Integer = Dgs_Equipos.PrimaryGrid.ActiveCell.ColumnIndex
        Dim _fil As Integer = Dgs_Equipos.PrimaryGrid.ActiveCell.RowIndex

        If (e.KeyCode <> Keys.Enter And
            (_col = Dgs_Equipos.PrimaryGrid.Columns("chnrem").ColumnIndex Or
            _col = Dgs_Equipos.PrimaryGrid.Columns("chcan").ColumnIndex Or
            _col = Dgs_Equipos.PrimaryGrid.Columns("chmonbs").ColumnIndex Or
            _col = Dgs_Equipos.PrimaryGrid.Columns("chmonsus").ColumnIndex Or
            _col = Dgs_Equipos.PrimaryGrid.Columns("chnota").ColumnIndex)) Then

            Select Case e.KeyCode
                Case Keys.D0 To Keys.D9, Keys.NumPad0 To Keys.NumPad9
                    e.Handled = False
                Case Keys.Back
                    e.Handled = False
                Case Keys.F2
                    e.Handled = False
                Case Keys.Up
                    Debug.Print("Up")
                Case Keys.Down
                    Debug.Print("Down")
                Case Keys.Left
                    Debug.Print("Left")
                Case Keys.Right
                    Debug.Print("Right")
                Case Else
                    e.Handled = True
            End Select
            'mover a la columna cantidad
        ElseIf (_col = Dgs_Equipos.PrimaryGrid.Columns("chnrem").ColumnIndex) Then
            Dgs_Equipos.PrimaryGrid.SetActiveCell(Dgs_Equipos.PrimaryGrid.GetCell(_fil, Dgs_Equipos.PrimaryGrid.Columns("chcan").ColumnIndex))
            Dgs_Equipos.PrimaryGrid.SetSelectedCells(_fil, Dgs_Equipos.PrimaryGrid.Columns("chnrem").ColumnIndex, 1, 1, False)
            Dgs_Equipos.PrimaryGrid.SetSelectedCells(_fil, Dgs_Equipos.PrimaryGrid.Columns("chcan").ColumnIndex, 1, 1, True)
            Exit Sub
            'mover a la columna montobs
        ElseIf (_col = Dgs_Equipos.PrimaryGrid.Columns("chcan").ColumnIndex) Then
            Dgs_Equipos.PrimaryGrid.SetActiveCell(Dgs_Equipos.PrimaryGrid.GetCell(_fil, Dgs_Equipos.PrimaryGrid.Columns("chmonbs").ColumnIndex))
            Dgs_Equipos.PrimaryGrid.SetSelectedCells(_fil, Dgs_Equipos.PrimaryGrid.Columns("chcan").ColumnIndex, 1, 1, False)
            Dgs_Equipos.PrimaryGrid.SetSelectedCells(_fil, Dgs_Equipos.PrimaryGrid.Columns("chmonbs").ColumnIndex, 1, 1, True)
            Exit Sub
            'mover a la columna montosus
            'ElseIf (_col = Dgs_Equipos.PrimaryGrid.Columns("chmonbs").ColumnIndex) Then
            '    Dgs_Equipos.PrimaryGrid.SetActiveCell(Dgs_Equipos.PrimaryGrid.GetCell(_fil, Dgs_Equipos.PrimaryGrid.Columns("chmonsus").ColumnIndex))
            '    Dgs_Equipos.PrimaryGrid.SetSelectedCells(_fil, Dgs_Equipos.PrimaryGrid.Columns("chmonbs").ColumnIndex, 1, 1, False)
            '    Dgs_Equipos.PrimaryGrid.SetSelectedCells(_fil, Dgs_Equipos.PrimaryGrid.Columns("chmonsus").ColumnIndex, 1, 1, True)
            '    Exit Sub
            'mover a la columna nota
        ElseIf (_col = Dgs_Equipos.PrimaryGrid.Columns("chmonbs").ColumnIndex) Then
            Dgs_Equipos.PrimaryGrid.SetActiveCell(Dgs_Equipos.PrimaryGrid.GetCell(_fil, Dgs_Equipos.PrimaryGrid.Columns("chnota").ColumnIndex))
            Dgs_Equipos.PrimaryGrid.SetSelectedCells(_fil, Dgs_Equipos.PrimaryGrid.Columns("chmonbs").ColumnIndex, 1, 1, False)
            Dgs_Equipos.PrimaryGrid.SetSelectedCells(_fil, Dgs_Equipos.PrimaryGrid.Columns("chnota").ColumnIndex, 1, 1, True)
            Exit Sub
        End If

        'mover foco a la siguiente columna
        If (e.KeyCode = Keys.Enter And
            Not (_col = Dgs_Equipos.PrimaryGrid.Columns("chnrem").ColumnIndex Or
            _col = Dgs_Equipos.PrimaryGrid.Columns("chcan").ColumnIndex Or
            _col = Dgs_Equipos.PrimaryGrid.Columns("chmonbs").ColumnIndex Or
            _col = Dgs_Equipos.PrimaryGrid.Columns("chmonsus").ColumnIndex Or
            _col = Dgs_Equipos.PrimaryGrid.Columns("chnota").ColumnIndex)) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            If (_col = Dgs_Equipos.PrimaryGrid.Columns("chcod").ColumnIndex) Then
                e.Handled = True
                SendKeys.Send("{TAB}")
                SendKeys.Send("{F2}")
            End If
        End If

        'para llevar el foco a latitud
        If (e.Control And e.KeyValue = Keys.Enter) Then
            Txt_Latitud.Select()
        End If

        'insertar una nueva fila
        If (e.KeyCode = Keys.Insert) Then
            Bt1AddEquipos.PerformClick()
        End If
    End Sub

    Private Function P_ValidarFilaGridEquipo(_f As Integer) As Boolean
        'validando codigo de producto, no puede estar vacio
        Dim s As String = Dgs_Equipos.PrimaryGrid.GetCell(_f, Dgs_Equipos.PrimaryGrid.Columns("chcod").ColumnIndex).FormattedValue.ToString.Trim
        If (Dgs_Equipos.PrimaryGrid.GetCell(_f, Dgs_Equipos.PrimaryGrid.Columns("chcod").ColumnIndex).FormattedValue.ToString.Trim.Equals("")) Then
            ToastNotification.Show(Me, "el código, no puede estar vacio".ToUpper,
                       My.Resources.WARNING,
                       _DuracionSms * 1000,
                       eToastGlowColor.Red,
                       eToastPosition.BottomLeft)
            Return False
            Exit Function
        End If
        'validando tipo de movimiento, no puede estar vacio
        If (Dgs_Equipos.PrimaryGrid.GetCell(_f, Dgs_Equipos.PrimaryGrid.Columns("chtmov").ColumnIndex).FormattedValue.ToString.Trim.Equals("")) Then
            ToastNotification.Show(Me, "en calidad de, no puede estar vacio".ToUpper,
                       My.Resources.WARNING,
                       _DuracionSms * 1000,
                       eToastGlowColor.Red,
                       eToastPosition.BottomLeft)
            Return False
            Exit Function
        End If
        'validando nro de remición, no puede ser cero
        'If (Dgs_Equipos.PrimaryGrid.GetCell(_f, Dgs_Equipos.PrimaryGrid.Columns("chnrem").ColumnIndex).Value.ToString.Trim.Equals("0")) Then
        '    ToastNotification.Show(Me, "nro de remición, no puede cero (0)".ToUpper,
        '               My.Resources.WARNING,
        '               _DuracionSms * 1000,
        '               eToastGlowColor.Red,
        '               eToastPosition.BottomLeft)
        '    Return False
        '    Exit Function
        'End If
        'validando cantidad, no puede ser cero
        If (Dgs_Equipos.PrimaryGrid.GetCell(_f, Dgs_Equipos.PrimaryGrid.Columns("chcan").ColumnIndex).Value.ToString.Trim.Equals("0")) Then
            ToastNotification.Show(Me, "la cantidad, no puede cero (0)".ToUpper,
                       My.Resources.WARNING,
                       _DuracionSms * 1000,
                       eToastGlowColor.Red,
                       eToastPosition.BottomLeft)
            Return False
            Exit Function
        End If
        'validando monto bs, no puede ser cero
        'If (Dgs_Equipos.PrimaryGrid.GetCell(_f, Dgs_Equipos.PrimaryGrid.Columns("chmonbs").ColumnIndex).Value.ToString.Trim.Equals("0")) Then
        '    ToastNotification.Show(Me, "el monto bs, no puede cero (0)".ToUpper,
        '               My.Resources.WARNING,
        '               _DuracionSms * 1000,
        '               eToastGlowColor.Red,
        '               eToastPosition.BottomLeft)
        '    Return False
        '    Exit Function
        'End If
        'validando monto sus, no puede ser cero
        'If (Dgs_Equipos.PrimaryGrid.GetCell(_f, Dgs_Equipos.PrimaryGrid.Columns("chmonsus").ColumnIndex).Value.ToString.Trim.Equals("0")) Then
        '    ToastNotification.Show(Me, "el monto sus, no puede cero (0)".ToUpper,
        '               My.Resources.WARNING,
        '               _DuracionSms * 1000,
        '               eToastGlowColor.Red,
        '               eToastPosition.BottomLeft)
        '    Return False
        '    Exit Function
        'End If
        'validando nro nota, no puede ser cero
        'If (Dgs_Equipos.PrimaryGrid.GetCell(_f, Dgs_Equipos.PrimaryGrid.Columns("chnota").ColumnIndex).Value.ToString.Trim.Equals("0")) Then
        '    ToastNotification.Show(Me, "nro de chnota, no puede cero (0)".ToUpper,
        '               My.Resources.WARNING,
        '               _DuracionSms * 1000,
        '               eToastGlowColor.Red,
        '               eToastPosition.BottomLeft)
        '    Return False
        '    Exit Function
        'End If

        Return True
    End Function

    Private Sub Txt_Latitud_TextChanged(sender As Object, e As EventArgs)
        Dim _lat As String = "0" + Txt_Latitud.Text.Replace("-", "")
        Dim _lon As String = "0" + Txt_Longitud.Text.Replace("-", "")
        If (CDbl(_lat) > 0 And CDbl(_lon) > 0) Then
            Btnx_ChekGetPoint.Text = "PONER UBICACIÓN"
            Btnx_ChekGetPoint.Visible = True
        Else
            Btnx_ChekGetPoint.Text = "MARCAR UBICACIÓN"
            Btnx_ChekGetPoint.Visible = False
        End If
    End Sub

    Private Sub Txt_Longitud_TextChanged(sender As Object, e As EventArgs)
        Dim _lat As String = "0" + Txt_Latitud.Text.Replace("-", "")
        Dim _lon As String = "0" + Txt_Longitud.Text.Replace("-", "")
        If (CDbl(_lat) > 0 And CDbl(_lon) > 0) Then
            Btnx_ChekGetPoint.Text = "PONER UBICACIÓN"
            Btnx_ChekGetPoint.Visible = True
        Else
            Btnx_ChekGetPoint.Text = "MARCAR UBICACIÓN"
            Btnx_ChekGetPoint.Visible = False
        End If
    End Sub

    Private Sub P_PonerDatosEquipoPorCliente(_CodCli As String)
        'Dim _DsEquipo As DataSet = L_GetClienteEquipo("chnumi = " & _CodCli + " order by chfec desc ")
        DtDetalle = New DataTable
        DtDetalle = L_fnClienteEquipo(_CodCli)

        'Dgs_Equipos.PrimaryGrid.Rows.Clear()
        If (DtDetalle.Rows.Count > 0) Then
            Dgs_Equipos.PrimaryGrid.DataSource = DtDetalle
        Else
            Dgs_Equipos.PrimaryGrid.DataSource = Nothing
        End If
    End Sub

    Private Sub P_Clientes_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
        If (e.KeyData = Keys.Control + Keys.Enter) Then
            P_FiltrarCliente()
        End If
    End Sub

    Private Sub Bt2Confirmar_Click(sender As Object, e As EventArgs) Handles Bt2Confirmar.Click
        If (Txt_Codigo.Text.Length > 0) Then
            L_GrabarModificarCliente(
                                "cceven = 0",
                                "ccnumi = " + Txt_Codigo.Text
                                )
            P_ArmarGrilla()
            P_LlenarDatos(_NavegadorReg)
        End If
    End Sub


    Private Sub Dgs_Personas_CellDoubleClick(sender As Object, e As GridCellDoubleClickEventArgs)
        SuperTabControl1.SelectedTabIndex = 0
    End Sub

    Private Sub Dgj1Busqueda_EditingCell(sender As Object, e As EditingCellEventArgs) Handles Dgj1Busqueda.EditingCell
        e.Cancel = True
    End Sub

    Private Sub Dgj1Busqueda_DoubleClick(sender As Object, e As EventArgs) Handles Dgj1Busqueda.DoubleClick
        SuperTabControl1.SelectedTabIndex = 0
    End Sub

    Private Sub Dgj1Busqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgj1Busqueda.KeyDown
        If (e.KeyData = Keys.Enter) Then
            SuperTabControl1.SelectedTabIndex = 0
        End If
    End Sub

    Private Function P_ObtenerIndexFila() As Integer
        Dim res As Integer
        If (Dgj1Busqueda.CurrentRow.RowIndex = -1) Then
            res = 0
        Else
            For Each fil As GridEXRow In Dgj1Busqueda.GetRows
                If (fil.Selected) Then
                    Exit For
                Else
                    res += 1
                End If
            Next
        End If
        Return res
    End Function

    Private Sub Tsmi1Eliminar_Click(sender As Object, e As EventArgs) Handles Tsmi1Eliminar.Click
        Dim fi As Integer = Dgs_Equipos.PrimaryGrid.ActiveRow.RowIndex
        If (fi > -1) Then
            If (_Nuevo) Then
                Dgs_Equipos.PrimaryGrid.Rows.RemoveAt(fi)
            ElseIf (_Mofificar) Then
                Dgs_Equipos.PrimaryGrid.GetCell(fi, Dgs_Equipos.PrimaryGrid.Columns("estado").ColumnIndex).Value = -1
                Dgs_Equipos.PrimaryGrid.Rows(fi).Visible = False
            End If
        End If
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If (SuperTabControl1.SelectedTabIndex = 1 And Bool) Then
            If (CType(Dgj1Busqueda.DataSource, DataTable) Is Nothing) Then
                P_ArmarGrilla()
            Else
                If (CType(Dgj1Busqueda.DataSource, DataTable).Rows.Count = 0) Then
                    P_ArmarGrilla()
                Else
                    Dgj1Busqueda.RemoveFilters()
                End If
            End If
        End If

        If (SuperTabControl1.SelectedTabIndex = 0 And Bool) Then
            Dim hayFiltro As Boolean = False
            For Each cell As GridEXCell In Dgj1Busqueda.FilterRow.Cells
                If (Not cell.Text = String.Empty) Then
                    hayFiltro = True
                    Exit For
                End If
            Next
            If (hayFiltro) Then
                Gr1Navegacion = Dgj1Busqueda.GetRows
                P_ActualizarPuterosNavegacion()
                _NavegadorReg = P_ObtenerIndexFila()
                P_LlenarDatos(_NavegadorReg)
            Else
                Dgj1Busqueda.RemoveFilters()
                Dgj1Busqueda.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(Dgj1Busqueda.RootTable.Columns("ccnumi"), Janus.Windows.GridEX.ConditionOperator.Equal, "-1"))
                Gr1Navegacion = Dgj1Busqueda.GetRows
                P_ActualizarPuterosNavegacion()
                _NavegadorReg = 0
                P_LlenarDatos(_NavegadorReg)
                P_Limpiar()
            End If
        End If
    End Sub

    Private Sub BBtn_Imprimir_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Imprimir.Click
        P_FiltrarCliente()
    End Sub

    Private Sub P_FiltrarCliente()
        SuperTabControl1.SelectedTabIndex = 1

        Dgj1Busqueda.Select()
        Dgj1Busqueda.Focus()
        Dgj1Busqueda.RemoveFilters()
        Dgj1Busqueda.MoveTo(Dgj1Busqueda.FilterRow)
        Dgj1Busqueda.Col = 2
    End Sub

    Private Sub FlyoutUsuario_PrepareContent(sender As Object, e As EventArgs) Handles FlyoutUsuario.PrepareContent
        If sender Is BubbleBar5 And BBtn_Grabar.Enabled = False Then
            Dim dtAud As DataTable = L_ObtenerAuditoria("TC004", "cc", "ccnumi=" + Txt_Codigo.Text)
            If IsDBNull(dtAud.Rows(0).Item(0)) = True Then
                lbFecha.Text = ""
            Else
                lbFecha.Text = Convert.ToDateTime(dtAud.Rows(0).Item(0)).ToString("dd/MM/yyyy")
            End If
            lbHora.Text = dtAud.Rows(0).Item(1).ToString
            lbUsuario.Text = dtAud.Rows(0).Item(2).ToString
            FlyoutUsuario.BorderColor = Color.FromArgb(&HC0, 0, 0)
            FlyoutUsuario.Content = PanelUsuario
        End If

    End Sub

    Private Sub BBtn_Usuario_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Usuario.Click
        FlyoutUsuario_PrepareContent(BubbleBar5, e)
    End Sub

    Private Sub Dgs_Equipos_CellValueChanged(sender As Object, e As GridCellValueChangedEventArgs) Handles Dgs_Equipos.CellValueChanged
        Dim cel As GridCell = Dgs_Equipos.PrimaryGrid.GetCell(e.GridCell.RowIndex, Dgs_Equipos.PrimaryGrid.Columns("estado").ColumnIndex)
        If (cel.Value = 1) Then
            cel.Value = 2
        End If
    End Sub

    Private Sub P_AUDFilaClientes(dt As DataTable, AUD As Integer, Optional numi As String = "")
        If (AUD = 1) Then
            'P_Global.gt_Cliente.Merge(dt)
            'P_Global.gt_Cliente.AcceptChanges()
            P_Global.gt_Cliente.ImportRow(dt.Rows(0))
        ElseIf (AUD = 2) Then
            Dim fil As DataRow = P_Global.gt_Cliente.Select("ccnumi =" + numi)(0)
            P_Global.gt_Cliente.Rows.Remove(fil)
            'P_Global.gt_Cliente.Merge(dt)
            'P_Global.gt_Cliente.AcceptChanges()
            P_Global.gt_Cliente.ImportRow(dt.Rows(0))
        ElseIf (AUD = 3) Then
            Dim fil As DataRow = P_Global.gt_Cliente.Select("ccnumi =" + numi)(0)
            P_Global.gt_Cliente.Rows.Remove(fil)
            'P_Global.gt_Cliente.AcceptChanges()
        End If
        P_ArmarGrilla()
    End Sub

    Private Sub P_ArmarGrillaSugerencia()
        DgjSugerencias.BoundMode = Janus.Data.BoundMode.Bound
        DgjSugerencias.DataSource = P_Global.gt_Cliente
        DgjSugerencias.RetrieveStructure()

        'dar formato a las columnas
        With DgjSugerencias.RootTable.Columns(0)
            .Caption = "Código"
            .Key = "ccnumi"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With DgjSugerencias.RootTable.Columns(1)
            .Caption = ""
            .Key = "cccod"
            .Width = 10
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With DgjSugerencias.RootTable.Columns(2)
            .Caption = "Nombre"
            .Key = "ccdesc"
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With DgjSugerencias.RootTable.Columns(3)
            .Caption = "Dirección"
            .Key = "ccdirec"
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencias.RootTable.Columns(4)
            .Caption = "Teléfono 2"
            .Key = "cctelf1"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With DgjSugerencias.RootTable.Columns(5)
            .Caption = "Teléfono 1"
            .Key = "cctelf2"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencias.RootTable.Columns(6)
            .Caption = ""
            .Key = "numZona"
            .Width = 10
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With DgjSugerencias.RootTable.Columns(7)
            .Caption = "Zona"
            .Key = "descZona"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencias.RootTable.Columns(8)
            .Caption = ""
            .Key = "numDct"
            .Width = 10
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencias.RootTable.Columns(9)
            .Caption = "Tipo de Documento"
            .Key = "descDct"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencias.RootTable.Columns(10)
            .Caption = "Nro Documento"
            .Key = "ccdctnum"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencias.RootTable.Columns(11)
            .Caption = ""
            .Key = "numCat"
            .Width = 10
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencias.RootTable.Columns(12)
            .Caption = "Categoria"
            .Key = "descCat"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencias.RootTable.Columns(13)
            .Caption = "Estado"
            .Key = "ccest"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencias.RootTable.Columns(14)
            .Caption = "Latitud"
            .Key = "cclat"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencias.RootTable.Columns(15)
            .Caption = "Longitud"
            .Key = "cclongi"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencias.RootTable.Columns(16)
            .Caption = "Eventual"
            .Key = "cceven"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencias.RootTable.Columns(17)
            .Caption = "Observación"
            .Key = "ccobs"
            .Width = 250
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencias.RootTable.Columns(18)
            .Caption = "Fecha de Nac"
            .Key = "ccfnac"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencias.RootTable.Columns(19)
            .Caption = "Nombre Factura"
            .Key = "ccnomfac"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencias.RootTable.Columns(20)
            .Caption = "NIT"
            .Key = "ccnit"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencias.RootTable.Columns(21)
            .Caption = "Fecha de Ingreso"
            .Key = "ccfecing"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencias.RootTable.Columns(22)
            .Caption = "Fecha de Ultimo Pedido"
            .Key = "ccultped"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With DgjSugerencias.RootTable.Columns(23)
            .Caption = "Usuario"
            .Key = "ccuact"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        'Habilitar Filtradores
        With DgjSugerencias
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
            .AlternatingColors = True
        End With
        'DgjSugerencias.Dock = DockStyle.Fill
        DgjSugerencias.BringToFront()
        DgjSugerencias.Refresh()
    End Sub

    Private Sub Txt_Nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Nombre.KeyPress
        If (Not e.KeyChar = ChrW(Keys.Enter) And _Nuevo) Then
            DgjSugerencias.RemoveFilters()
            DgjSugerencias.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(DgjSugerencias.RootTable.Columns("ccdesc"), Janus.Windows.GridEX.ConditionOperator.Contains, Txt_Nombre.Text))
        End If
    End Sub

    Private Sub DgjSugerencias_EditingCell(sender As Object, e As EditingCellEventArgs) Handles DgjSugerencias.EditingCell
        e.Cancel = True
    End Sub

    Private Sub BtActualizar_Click(sender As Object, e As EventArgs) Handles BtActualizar.Click
        CpActCliente.Visible = True
        CpActCliente.Refresh()
        CpActCliente.Value = 0
        CpActCliente.Minimum = 0
        CpActCliente.Maximum = 100
        P_Global.gb_DtClienteEstado = False

        SuperTabControl1.Enabled = False
        Rl1Accion.Text = "SINCRONIZANDO..."

        ThCliente = New Thread(AddressOf Me.prCargarClientes)
        ThCliente.Start()
        TiCliente.Start()

        'P_Global.gt_Cliente = L_fnClientes()
        'P_Global.gb_DtClienteEstado = True
    End Sub

    Dim tiempoAC As Integer = 0
    Private Sub TiCliente_Tick(sender As Object, e As EventArgs) Handles TiCliente.Tick
        tiempoAC = tiempoAC + 40
        CpActCliente.Value = CpActCliente.Value + 1
        If (CpActCliente.Value = CpActCliente.Maximum) Then
            CpActCliente.Value = CpActCliente.Minimum + 1
        ElseIf (P_Global.gb_DtClienteEstado And tiempoAC >= 8000) Then
            P_ArmarGrilla()
            P_ArmarGrillaSugerencia()
            CpActCliente.Visible = False
            TiCliente.Stop()
            Dim info As New TaskDialogInfo("sincronización de clientes.".ToUpper, eTaskDialogIcon.Information, "información".ToUpper, "se ha sincronizado correctamente todos los cliente.".ToUpper, eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Blue)
            TaskDialog.Show(info)
            SuperTabControl1.Enabled = True
            Rl1Accion.Text = ""
            tiempoAC = 0
        End If
    End Sub

    Private Sub prCargarClientes()
        P_Global.gt_Cliente = New DataTable
        P_Global.gt_Cliente = L_fnClientes()
        P_Global.gb_DtClienteEstado = True
        ThCliente.Abort()
    End Sub

    Private Function P_ResumenProducto(cpro As String, sr As String) As Double
        Dim dt As DataTable
        Dim sum As Double = 0
        dt = CType(Dgs_Equipos.PrimaryGrid.DataSource, DataTable)
        If (Not dt Is Nothing) Then
            If (dt.Rows.Count > 0) Then

                If (IsDBNull(dt.Compute("sum(chcan)", "cpmov=" & sr & " and cpmovcli=1 and chcod=" & cpro))) Then
                    sum = 0
                Else
                    sum = CDbl(dt.Compute("sum(chcan)", "cpmov=" & sr & " and cpmovcli=1 and chcod=" & cpro))
                End If
            End If
        End If
        Return sum
    End Function

    Private Sub CbFiltroResumenEquipo_ValueChanged(sender As Object, e As EventArgs) Handles CbFiltroResumenEquipo.ValueChanged
        If (IsNumeric(CbFiltroResumenEquipo.Value)) Then
            P_PonerResumenEquipo()
        End If
    End Sub

    Private Sub P_PonerResumenEquipo()
        TbiCantSaliente.Value = 0
        TbiCantEntrante.Value = 0
        TbiCantSaldo.Value = 0
        'If (DtProductosCompuestos.Select("canumi=" + CbFiltroResumenEquipo.Value.ToString).Length = 0) Then
        TbiCantSaliente.Value = P_ResumenProducto(CbFiltroResumenEquipo.Value.ToString, "-1")
        TbiCantEntrante.Value = P_ResumenProducto(CbFiltroResumenEquipo.Value.ToString, "1") * -1
        TbiCantSaldo.Value = TbiCantSaliente.Value + TbiCantEntrante.Value
        'Else
        'ToastNotification.Show(Me, "El equipo con código: ".ToUpper + CbFiltroResumenEquipo.Value.ToString _
        '                       + " es un equipo compuesto,".ToUpper + ChrW(13) + "sus partes se sumaran como individuales".ToUpper,
        '                       My.Resources.INFORMATION, _DuracionSms * 1000,
        '                       eToastGlowColor.Orange,
        '                       eToastPosition.TopCenter)
        'End If
        P_SRProductosCompuestos() 'Sumar o Restar los Productos Compuesto
    End Sub

    Private Sub P_SRProductosCompuestos()
        Dim Suma As Double = 0
        Dim Resta As Double = 0
        Dim Array As DataRow() = DtProductosCompuestos.Select("cpcprod=" + CbFiltroResumenEquipo.Value.ToString)
        Dim Pc As String = ""
        If (Array.Length > 0) Then
            Pc = Array(0).Item("canumi").ToString
            Suma = P_ResumenProducto(Pc, "-1")
            Resta = P_ResumenProducto(Pc, "1") * -1
            TbiCantSaliente.Value = TbiCantSaliente.Value + Suma
            TbiCantEntrante.Value = TbiCantEntrante.Value - Resta
            TbiCantSaldo.Value = TbiCantSaliente.Value + TbiCantEntrante.Value
        End If
    End Sub

    Private Sub BtPasarCliente_Click(sender As Object, e As EventArgs) Handles BtPasarCliente.Click
        If (Txt_Codigo.Text.Trim = String.Empty) Then
            ToastNotification.Show(Me, "debe elegir un cliente para exportarlo.".ToUpper,
                                   My.Resources.WARNING,
                                   _DuracionSms * 1000,
                                   eToastGlowColor.Red,
                                   eToastPosition.TopCenter)
            Exit Sub
        End If

        If (Not L_fnGrabarClienteValidarBDDist2(Txt_Codigo.Text.Trim)) Then
            ToastNotification.Show(Me, "el cliente con código:  ''".ToUpper + Txt_Codigo.Text.Trim _
                                   + "''  ya ha sido exportado.".ToUpper,
                                   My.Resources.WARNING,
                                   _DuracionSms * 1000,
                                   eToastGlowColor.Red,
                                   eToastPosition.TopCenter)
            Exit Sub
        End If

        Dim numi As String
        Dim cod As String
        Dim desc As String
        Dim zona As String
        Dim dct As String
        Dim dctnum As String
        Dim direc As String
        Dim telf1 As String
        Dim telf2 As String
        Dim cat As String
        Dim est As String
        Dim lat As String
        Dim lon As String
        Dim prconsu As String
        Dim even As String
        Dim obs As String
        Dim fnac As String
        Dim nomfac As String
        Dim nit As String
        Dim ultped As String
        Dim fecing As String
        Dim ultvent As String

        numi = Txt_Codigo.Text.Trim
        cod = numi
        desc = Txt_Nombre.Text.Trim
        zona = Cbx_Zona.Value
        dct = Cbx_TipoDoc.Value
        dctnum = IIf(Txt_NroDoc.Text.Trim.Equals(""), "0", Txt_NroDoc.Text.Trim)
        direc = IIf(Txt_Direccion.Text.Trim.Equals(""), "S/DIR", Txt_Direccion.Text.Trim)
        telf1 = IIf(Txt_Telefono1.Text.Trim.Equals(""), "0", Txt_Telefono1.Text.Trim)
        telf2 = IIf(Txt_Telefono2.Text.Trim.Equals(""), "0", Txt_Telefono2.Text.Trim)
        cat = Cbx_Categoria.Value
        est = "1"
        If (Rb1Activo.Checked) Then
            est = "1"
        ElseIf (Rb2Pasivo.Checked) Then
            est = "0"
        ElseIf (Rb3Devuelto.Checked) Then
            est = "2"
        End If
        lat = IIf(Txt_Latitud.Text.Trim.Equals(""), 0, Txt_Latitud.Text.Trim)
        lon = IIf(Txt_Longitud.Text.Trim.Equals(""), 0, Txt_Longitud.Text.Trim)
        prconsu = "0"
        even = IIf(Sb_Eventual.Value, "0", "1")
        obs = IIf(Txt_Obs.Text.Trim.Equals(""), "S/OBS", Txt_Obs.Text.Trim)
        fnac = Dt1FechaNac.Value.Date.ToString("yyyy/MM/dd")
        nomfac = IIf(Tb10NombreFactura.Text.Trim.Equals(""), "S/N", Tb10NombreFactura.Text.Trim)
        nit = IIf(Tb11Nit.Text.Trim.Equals(""), "0", Tb11Nit.Text.Trim)
        ultped = Dt2FechaIng.Value.Date.AddDays(-1).ToString("yyyy/MM/dd")
        'fecing = Dt2FechaIng.Value.Date.ToString("yyyy/MM/dd")
        fecing = Now.Date.ToString("yyyy/MM/dd")
        ultvent = "2000/01/01"

        Dim res As Boolean = L_fnGrabarClienteBDist2(numi, cod, desc, zona, dct, dctnum, direc, telf1, telf2, cat,
                                                     est, lat, lon, prconsu, even, obs, fnac, nomfac, nit, ultped,
                                                     fecing, ultvent)
        If (res) Then
            ToastNotification.Show(Me, "el cliente:  ''".ToUpper + desc _
                                   + "''  se ha exportado correctamente a la BD de Ice Water.".ToUpper,
                                   My.Resources.GRABACION_EXITOSA,
                                   _DuracionSms * 1000,
                                   eToastGlowColor.Red,
                                   eToastPosition.TopCenter)
        Else
            ToastNotification.Show(Me, "exportación fallida del cliente:  ''".ToUpper + desc + "''",
                                   My.Resources.WARNING,
                                   _DuracionSms * 1000,
                                   eToastGlowColor.Red,
                                   eToastPosition.TopCenter)
        End If
    End Sub

End Class

Public Class MyComboBoxProducto
    Inherits GridComboBoxExEditControl
    Public Sub New()

        DropDownWidth = 300
        DropDownHeight = 100

        'AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        'AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems

        DropDownColumns = gt_Productos.Columns("cacod").ToString + "," + gt_Productos.Columns("cadesc").ToString
        DropDownColumnsHeaders = "CÓDIGO" + Chr(13) + "DESCRIPCIÓN"

        ValueMember = gt_Productos.Columns("cacod").ToString
        DisplayMember = gt_Productos.Columns("cacod").ToString
        DataSource = gt_Productos
    End Sub

End Class

Public Class MyComboBoxSerie
    Inherits GridComboBoxExEditControl
    Public Sub New()
        Dim _Ds As New DataSet
        _Ds = L_GetSeriesProducto(IIf(G_CodProducto.Equals(""), "", "cicod = " + G_CodProducto))

        DropDownWidth = 300
        DropDownHeight = 100

        'AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        'AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems

        DropDownColumns = _Ds.Tables(0).Columns("cilin").ToString + "," + _Ds.Tables(0).Columns("cinserie").ToString
        DropDownColumnsHeaders = "NRO." + Chr(13) + "SERIE"

        ValueMember = _Ds.Tables(0).Columns("cilin").ToString
        DisplayMember = _Ds.Tables(0).Columns("cinserie").ToString
        DataSource = _Ds.Tables(0)
    End Sub

End Class

Public Class MyComboBoxMovimiento
    Inherits GridComboBoxExEditControl
    Public Sub New()
        'Dim _Ds As New DataSet
        Dim dt As New DataTable
        dt = L_GetConceptoInvetario()
        '_Ds = L_GetItemsConceptoLibreria(gi_TipoMovimiento)

        DropDownWidth = 300
        DropDownHeight = 100

        'AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        'AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems

        DropDownColumns = dt.Columns("cpnumi").ToString + "," + dt.Columns("cpdesc").ToString
        DropDownColumnsHeaders = "NRO." + Chr(13) + "DESCRIPCIÓN"

        ValueMember = dt.Columns("cpnumi").ToString
        DisplayMember = dt.Columns("cpdesc").ToString
        DataSource = dt

    End Sub

End Class
