Imports Logica.AccesoLogica
Imports GMap.NET
Imports GMap.NET.WindowsForms
Imports Janus.Windows.GridEX
Imports System.Threading
Imports DevComponents.DotNetBar
Imports System.IO
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.WindowsForms.ToolTips
Imports DevComponents.DotNetBar.Controls

Public Class F02_Cliente

#Region "Atributos generales"

    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

#End Region

#Region "Propiedades generales"

#End Region

#Region "Variables globales locales"
    Dim FtTitulo As Font = New Font("Arial", gi_fuenteTamano + 1)
    Dim FtNormal As Font = New Font("Arial", gi_fuenteTamano)

    Dim DtBusqueda As DataTable
    Dim DtDetalle As DataTable
    Dim StRutaDocumentos As String = gs_CarpetaRaiz + "\Documentos\Cliente\"
    Dim InDuracion As Byte = 5

    Dim BoNuevo As Boolean = False
    Dim BoModificar As Boolean = False
    Dim BoEliminar As Boolean = False
    Dim BoNavegar As Boolean = False

    'Dim StCod As String

    Dim Punto As Integer
    Dim ListPuntos As List(Of PointLatLng)
    Dim Overlay As GMapOverlay

    Dim DtProductoCompuesto As DataTable

#End Region

#Region "Eventos generales"

    Private Sub My_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        P_prInicio()
    End Sub

    Private Sub MBtNuevo_Click(sender As Object, e As EventArgs) Handles MBtNuevo.Click
        P_prNuevoRegistro()
    End Sub

    Private Sub MBtModificar_Click(sender As Object, e As EventArgs) Handles MBtModificar.Click
        P_prModificarRegistro()
    End Sub

    Private Sub MBtEliminar_Click(sender As Object, e As EventArgs) Handles MBtEliminar.Click
        P_prEliminarRegistro()
    End Sub

    Private Sub MBtGrabar_Click(sender As Object, e As EventArgs) Handles MBtGrabar.Click
        P_prGrabarRegistro()
    End Sub

    Private Sub MBtSalir_Click(sender As Object, e As EventArgs) Handles MBtSalir.Click
        P_prCancelarRegistro()
    End Sub

    Private Sub MBtPrimero_Click(sender As Object, e As EventArgs) Handles MBtPrimero.Click
        If (DgjBusqueda.RowCount > 0) Then
            DgjBusqueda.MoveFirst()
        End If
    End Sub

    Private Sub MBtAnterior_Click(sender As Object, e As EventArgs) Handles MBtAnterior.Click
        If (DgjBusqueda.RowCount > 0) Then
            DgjBusqueda.MovePrevious()
        End If
    End Sub

    Private Sub MBtSiguiente_Click(sender As Object, e As EventArgs) Handles MBtSiguiente.Click
        If (DgjBusqueda.RowCount > 0) Then
            DgjBusqueda.MoveNext()
        End If
    End Sub

    Private Sub MBtUltimo_Click(sender As Object, e As EventArgs) Handles MBtUltimo.Click
        If (DgjBusqueda.RowCount > 0) Then
            DgjBusqueda.MoveLast()
        End If
    End Sub

    Private Sub DgjBusqueda_SelectionChanged(sender As Object, e As EventArgs) Handles DgjBusqueda.SelectionChanged
        If (DgjBusqueda.Row > -1 And (Not BoNuevo And Not BoModificar)) Then
            P_prLlenarDatos(DgjBusqueda.Row)
        End If
    End Sub

#End Region

#Region "Metodos y funciones indispensables"

    Private Sub P_prInicio()
        'Abrir conexión
        If (Not gb_ConexionAbierta) Then
            L_prAbrirConexion()
        End If

        'Validar requisitos del programa
        If (Not P_fnValidarRequisitos() = String.Empty) Then
            Return
        End If

        'Inicializar componentes
        P_prInicializarComponentes()

        'Habilitar/Deshabilitar compotentes del formulario
        P_prHDComponentes(False)

        'Armar todo los combobox 
        P_prArmarCombos()

        'Armar todo las grillas
        BoNavegar = False
        P_prArmarGrillas()
        P_prEliminarArchivosSinReferencia(DtBusqueda, "nimg", StRutaDocumentos)
        BoNavegar = True

        If gi_mprec = 0 Then
            catProd.Visible = False
        End If

        P_prActualizarPaginacion(0)
        P_prLlenarDatos(0)
    End Sub

    Private Function P_fnValidarRequisitos() As String
        Dim sms As String = ""

        'Crea la carpeta de imagenes si es que no estuviera creada.
        P_prValidarCarpetaImagenes()

        If (Not sms = String.Empty) Then
            ToastNotification.Show(Me,
                                   "".ToUpper,
                                   My.Resources.WARNING,
                                   InDuracion * 1000,
                                   eToastGlowColor.Red,
                                   eToastPosition.TopCenter)
        End If

        Return sms
    End Function

    Private Sub P_prInicializarComponentes()
        'Form
        Me.Text = "C L I E N T E"
        Me.WindowState = FormWindowState.Maximized

        'Visible
        MBtImprimir.Visible = True
        Tsmi1Eliminar.Visible = False
        SuperTabItemAcuerdo.Visible = (gi_vacu = 1)

        'Enabled
        MBtGrabar.Enabled = False

        'ReadOnly
        TbCodigo.ReadOnly = True
        DtiUltimoPedido.IsInputReadOnly = True
        DtiUltimoPedido.ButtonDropDown.Enabled = False
        DtiUltimaVenta.IsInputReadOnly = True
        DtiUltimaVenta.ButtonDropDown.Enabled = False
        TbiCantEntrante.IsInputReadOnly = True
        TbiCantSaliente.IsInputReadOnly = True
        TbiCantSaldo.IsInputReadOnly = True
        tbAcuCodCliente.ReadOnly = True
        tbAcuNombre.ReadOnly = True

        'Grid Busqueda
        DgjBusqueda.AllowEdit = InheritableBoolean.False
        DgjSugerencia.AllowEdit = InheritableBoolean.False

        dgjProducto.ContextMenuStrip = cmsProducto

        'Botones

        'Funciones
        P_prCambiarFuenteComponentes()
        P_prAsignarPermisos()

        gt_Productos = L_GetProductos("caserie = " + CStr(1)).Tables(0)
        DtProductoCompuesto = New DataTable
        DtProductoCompuesto = L_fnClienteEquipoProductosCompuestos()

        If (gb_mostrarMapa) Then
            P_prMapaLoad()
        End If

        'Usuario del sistema
        MTbUsuario.Text = gs_user
    End Sub

    Private Sub P_prCambiarFuenteComponentes()
        Dim xCtrl As Control
        For Each xCtrl In TableLayoutPanelPrincipal.Controls
            Try
                xCtrl.Font = FtNormal
            Catch ex As Exception
            End Try
        Next
        'For Each xCtrl In TableLayoutPanelPrincipal.Controls
        '    Try
        '        xCtrl.Font = FtNormal
        '    Catch ex As Exception
        '    End Try
        'Next
    End Sub

    Private Sub P_prAsignarPermisos()
        Dim dtRolUsu() As DataRow = L_prRolDetalleGeneral(gi_userRol).Select("yaprog='" + _nameButton + "'")

        Dim show As Boolean = False
        Dim add As Boolean = False
        Dim modif As Boolean = False
        Dim del As Boolean = False

        If (dtRolUsu.Count = 1) Then
            show = dtRolUsu(0).Item("ycshow")
            add = dtRolUsu(0).Item("ycadd")
            modif = dtRolUsu(0).Item("ycmod")
            del = dtRolUsu(0).Item("ycdel")
        End If

        If add = False Then
            MBtNuevo.Visible = False
        End If
        If modif = False Then
            MBtModificar.Visible = False
        End If
        If del = False Then
            MBtEliminar.Visible = False
        End If
    End Sub

    Private Sub P_prHDComponentes(ByVal flat As Boolean)
        'TextBox
        tbCodCliente.ReadOnly = Not flat
        TbNombre.ReadOnly = Not flat
        TbNroDoc.ReadOnly = Not flat
        TbDireccion.ReadOnly = Not flat
        TbTelefono1.ReadOnly = Not flat
        TbTelefono2.ReadOnly = Not flat
        TbObs.ReadOnly = Not flat
        TbNombreFactura.ReadOnly = Not flat
        TbNit.ReadOnly = Not flat
        tbLatitud.ReadOnly = Not flat
        tbLongitud.ReadOnly = Not flat
        tbRecorrido.ReadOnly = Not flat

        'ComboBox
        CbZona.ReadOnly = Not flat
        CbTipoDoc.ReadOnly = Not flat
        CbCategoria.ReadOnly = Not flat
        cbSupervisor.ReadOnly = Not flat
        cbPrevendedor.ReadOnly = Not flat
        cbTipoCredito.ReadOnly = Not flat

        'DateTimer
        DtiFechaNac.IsInputReadOnly = Not flat
        DtiFechaNac.ButtonDropDown.Enabled = flat
        DtiFechaIng.IsInputReadOnly = Not flat
        DtiFechaIng.ButtonDropDown.Enabled = flat

        'Button
        BtMarcarPunto.Enabled = flat
        BtAddEquipo.Enabled = flat

        'Switch Button
        SbEventual.IsReadOnly = Not flat

        'Radio Button
        RbActivo.Enabled = flat
        RbPasivo.Enabled = flat
        RbDevuelto.Enabled = flat

        'Grillas
        DgjEquipo.AllowEdit = CType(IIf(flat, 1, 2), InheritableBoolean)
        grCatProd.AllowEdit = CType(IIf(flat, 1, 2), InheritableBoolean)

        If (gi_vacu = 1) Then
            'Pestaña acuerdo
            cbTipoAcuerdo.ReadOnly = Not flat
            dtFechaInicio.IsInputReadOnly = Not flat
            dtFechaFinal.IsInputReadOnly = Not flat
            cbFrecuencia.ReadOnly = Not flat
            btEstado.IsReadOnly = Not flat
            tbAcuObs.ReadOnly = Not flat

            dgjDias.AllowEdit = CType(IIf(flat, 1, 2), InheritableBoolean)
            dgjProducto.AllowEdit = CType(IIf(flat, 1, 2), InheritableBoolean)
        End If
    End Sub

    Private Sub P_prLimpiar()
        'TextBox
        TbCodigo.Clear()
        tbCodCliente.Clear()
        TbNombre.Clear()
        TbNroDoc.Clear()
        TbDireccion.Clear()
        TbTelefono1.Clear()
        TbTelefono2.Clear()
        TbObs.Clear()
        TbNombreFactura.Clear()
        TbNit.Clear()
        tbLatitud.Clear()
        tbLongitud.Clear()
        tbRecorrido.Text = "0"
        TbiCantEntrante.Value = 0
        TbiCantSaliente.Value = 0
        TbiCantSaldo.Value = 0

        'ComboBox
        CbZona.SelectedIndex = 0
        CbTipoDoc.SelectedIndex = 0
        CbCategoria.SelectedIndex = 0
        CbFiltroResumenEquipo.SelectedIndex = 0
        cbSupervisor.SelectedIndex = 0
        cbPrevendedor.SelectedIndex = 0
        cbTipoCredito.SelectedIndex = 0

        'DateTimer
        DtiFechaNac.Value = Now.Date
        DtiFechaIng.Value = Now.Date

        'Switch Button
        SbEventual.Value = True

        'Radio Button
        RbActivo.Checked = True

        'Grillas
        P_prArmarGrillaEquipo("-1")

        MBtGrabar.Tooltip = "GRABAR"

        If (gi_vacu = 1) Then
            'Limpiar acuerdo
            tbAcuCodCliente.Clear()
            tbAcuNombre.Clear()
            If (CType(cbTipoAcuerdo.DataSource, DataTable).Rows.Count > 0) Then
                cbTipoAcuerdo.SelectedIndex = 0
            End If
            dtFechaInicio.Value = Now.Date
            dtFechaFinal.Value = Now.Date
            If (CType(cbFrecuencia.DataSource, DataTable).Rows.Count > 0) Then
                cbFrecuencia.SelectedIndex = 0
            End If
            btEstado.Value = True
            tbAcuObs.Clear()

            P_prArmarGrillaDias("-1")
            P_prArmarGrillaProducto("-1")
        End If

    End Sub

    Private Sub P_prArmarCombos()
        P_prArmarComboZona()
        P_prArmarComboTipoDoc()
        P_prArmarComboCatCliente()
        P_prArmarComboEquipo()
        P_prArmarComboSupervisor()
        P_prArmarComboPrevendedor()
        P_prArmarComboTipoCredito()

        If (gi_vacu = 1) Then
            'Combos acuerdo
            P_prArmarComboTipoAcuerdo()
            P_prArmarComboFrecuencia()
        End If
    End Sub

    Private Sub P_prArmarGrillas()
        P_prArmarGrillaBusqueda()
        P_ArmarGrillaSugerencia()
        P_prArmarGrillaEquipo("-1")

        If (gi_vacu = 1) Then
            'Grillas acuerdo
            P_prArmarGrillaDias("-1")
            P_prArmarGrillaProducto("-1")
        End If
    End Sub

    Private Sub P_prActualizarPaginacion(ByVal index As Integer)
        MLbPaginacion.Text = "Reg. " & index + 1 & " de " & DgjBusqueda.GetRows.Count
    End Sub

    Private Sub P_prMoverIndexActual()
        Dim index As Integer = CInt(MLbPaginacion.Text.Trim.Split(" ")(1).Trim)
        If (index < 0) Then
            index = 0
        End If
        If (index > DgjBusqueda.RowCount) Then
            index = DgjBusqueda.RowCount
        End If
        DgjBusqueda.MoveTo(index - 1)
        P_prLlenarDatos(DgjBusqueda.Row)
    End Sub

    Private Sub P_prLlenarDatos(ByVal index As Integer)
        If (index <= DgjBusqueda.GetRows.Count - 1 And index >= 0) Then
            If (BoNavegar) Then
                With DgjBusqueda
                    Me.TbCodigo.Text = .GetValue("numi").ToString
                    Me.TbNombre.Text = .GetValue("desc").ToString
                    Me.CbZona.Value = .GetValue("zona")
                    Me.CbTipoDoc.Value = .GetValue("dct")
                    Me.TbNroDoc.Text = .GetValue("dctnum").ToString
                    Me.DtiFechaNac.Value = .GetValue("fnac")
                    Me.DtiFechaIng.Value = .GetValue("fing")
                    Me.TbDireccion.Text = .GetValue("direc").ToString

                    If (.GetValue("ultped").ToString.Equals("")) Then
                        Me.DtiUltimoPedido.Value = DtiFechaIng.Value
                    Else
                        Me.DtiUltimoPedido.Value = .GetValue("ultped")
                    End If

                    Me.TbTelefono1.Text = .GetValue("telf1").ToString
                    Me.TbTelefono2.Text = .GetValue("telf2").ToString
                    Me.CbCategoria.Value = .GetValue("cat")

                    If (.GetValue("est").ToString.Equals("1")) Then 'activo
                        RbActivo.Checked = True
                    ElseIf (.GetValue("est").ToString.Equals("0")) Then 'pasivo
                        RbPasivo.Checked = True
                    ElseIf (.GetValue("est").ToString.Equals("2")) Then 'devueto
                        RbDevuelto.Checked = True
                    End If

                    Me.TbObs.Text = .GetValue("obs").ToString

                    If (.GetValue("ultven").ToString.Equals("")) Then
                        Me.DtiUltimaVenta.Value = "01/01/2000"
                    Else
                        Me.DtiUltimaVenta.Value = .GetValue("ultven")
                    End If

                    Me.SbEventual.Value = .GetValue("even").ToString.Equals("False")
                    Me.TbNombreFactura.Text = .GetValue("nomfac").ToString
                    Me.TbNit.Text = .GetValue("nit").ToString

                    Me.tbLatitud.Text = .GetValue("lat").ToString
                    Me.tbLongitud.Text = .GetValue("longi").ToString
                    Me.tbCodCliente.Text = .GetValue("cod").ToString

                    Me.tbRecorrido.Text = .GetValue("recven").ToString

                    Me.cbSupervisor.Clear()
                    Me.cbSupervisor.SelectedText = .GetValue("nsupven").ToString

                    Me.cbPrevendedor.Clear()
                    Me.cbPrevendedor.SelectedText = .GetValue("npreven").ToString

                    'Me.cbTipoCredito.Clear()
                    Dim s As String = .GetValue("tcre").ToString
                    Me.cbTipoCredito.Value = .GetValue("tcre")

                    'Aqui de coloca los datos del Mapa
                    If (gb_mostrarMapa) Then
                        If (CDbl(tbLatitud.Text.Replace("-", "")) > 0 And CDbl(tbLongitud.Text.Replace("-", "")) > 0) Then
                            'ListPuntos.Clear()
                            Overlay.Markers.Clear()
                            Dim plg As PointLatLng = New PointLatLng(CDbl(tbLatitud.Text), CDbl(tbLongitud.Text))
                            P_prAgregarPunto(plg)
                        Else
                            'ListPuntos.Clear()
                            Overlay.Markers.Clear()
                        End If
                    End If
                    'Aqui se coloca los datos de la grilla de los Equipos
                    P_prArmarGrillaEquipo(TbCodigo.Text)
                    P_prPonerResumenEquipo()

                    If (gi_vacu = 1) Then
                        Dim dtAcuerdo As DataTable
                        dtAcuerdo = New DataTable
                        dtAcuerdo = L_fnObtenerTabla("a.ccatc4numi, a.ccatacu, b1.cedesc as ntacu, a.ccafini, a.ccaffin, a.ccafre, b2.cedesc as nfre, a.ccaest, a.ccaobs",
                                                     "TC004A a inner join TC0051 b1 on a.ccatacu=b1.cenum and b1.cecon=14 " _
                                                     + " inner join TC0051 b2 on a.ccafre=b2.cenum And b2.cecon=15",
                                                     "a.ccatc4numi=" + TbCodigo.Text)
                        If (dtAcuerdo.Rows.Count = 1) Then
                            tbAcuCodCliente.Text = tbCodCliente.Text
                            tbAcuNombre.Text = TbNombre.Text
                            cbTipoAcuerdo.Clear()
                            cbTipoAcuerdo.SelectedText = dtAcuerdo.Rows(0).Item("ntacu").ToString
                            dtFechaInicio.Value = CDate(dtAcuerdo.Rows(0).Item("ccafini"))
                            dtFechaFinal.Value = CDate(dtAcuerdo.Rows(0).Item("ccaffin"))
                            cbFrecuencia.Clear()
                            cbFrecuencia.SelectedText = dtAcuerdo.Rows(0).Item("nfre").ToString
                            btEstado.Value = (CInt(dtAcuerdo.Rows(0).Item("ccaest")) = 1)
                            tbAcuObs.Text = dtAcuerdo.Rows(0).Item("ccaobs").ToString

                            P_prArmarGrillaDias(TbCodigo.Text)
                            P_prArmarGrillaProducto(TbCodigo.Text)
                        Else
                            tbAcuCodCliente.Clear()
                            tbAcuNombre.Clear()

                            Try
                                cbTipoAcuerdo.Clear()
                                If (CType(cbTipoAcuerdo.DataSource, DataTable).Rows.Count > 0) Then
                                    cbTipoAcuerdo.SelectedIndex = 0
                                End If
                            Catch ex As Exception

                            End Try

                            dtFechaInicio.Value = Now.Date
                            dtFechaFinal.Value = Now.Date

                            Try
                                cbFrecuencia.Clear()
                                If (CType(cbFrecuencia.DataSource, DataTable).Rows.Count > 0) Then
                                    cbFrecuencia.SelectedIndex = 0
                                End If
                            Catch ex As Exception

                            End Try

                            btEstado.Value = True
                            tbAcuObs.Clear()

                            P_prArmarGrillaDias("-1")
                            P_prArmarGrillaProducto("-1")
                        End If
                    End If

                    MLbFecha.Text = CType(.GetValue("fact").ToString, Date).ToString("dd/MM/yyyy")
                    MLbHora.Text = .GetValue("hact").ToString
                    MLbUsuario.Text = .GetValue("uact").ToString
                End With

                P_prActualizarPaginacion(DgjBusqueda.Row)
            End If
        Else
            If (DgjBusqueda.GetRows.Count > 0) Then
                P_prMoverIndexActual()
            End If
        End If

        _prCargarGridCategoria(TbCodigo.Text)
    End Sub

    Private Sub P_prNuevoRegistro()
        P_prLimpiar()
        P_prEstadoNueModEli(1)
        P_prHDComponentes(BoNuevo)
        TbNombre.Select()
        P_prAddFilaProducto()
        _prCargarGridCategoria()
    End Sub

    Private Sub P_prModificarRegistro()
        P_prEstadoNueModEli(2)
        P_prHDComponentes(BoModificar)
        TbNombre.SelectAll()
        P_prAddFilaProducto()
        If grCatProd.RowCount <= 0 Then
            _prCargarGridCategoria()
        End If
    End Sub

    Private Sub P_prEliminarRegistro()
        Dim numi As String = TbCodigo.Text 'Valor del código único
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper,
                                       eTaskDialogIcon.Delete, "advertencia".ToUpper,
                                       "Esta a punto de eliminar el cliente con".ToUpper _
                                       + vbCrLf + "código -> ".ToUpper _
                                       + numi + " " + vbCrLf + "Desea continuar?".ToUpper,
                                       eTaskDialogButton.Yes Or eTaskDialogButton.Cancel,
                                       eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim resEliminar As Boolean = L_fnbValidarEliminacion(numi, "TC004", "ccnumi", mensajeError)
            If (resEliminar) Then
                Dim res As Boolean = L_fnEliminarCliente(numi) 'Medoto de lógica para eliminar
                If (res) Then
                    ToastNotification.Show(Me, "Codigo de cliente:  ".ToUpper + numi + " eliminado con Exito.".ToUpper,
                                           My.Resources.GRABACION_EXITOSA, InDuracion * 1000,
                                           eToastGlowColor.Green,
                                           eToastPosition.TopCenter)
                    BoNavegar = False
                    P_prArmarGrillaBusqueda()
                    P_ArmarGrillaSugerencia()
                    BoNavegar = True
                    P_prMoverIndexActual()
                Else
                    ToastNotification.Show(Me, "No se pudo eliminar el cliente con código: ".ToUpper + numi + ", intente nuevamente.".ToUpper,
                                           My.Resources.WARNING, InDuracion * 1000,
                                           eToastGlowColor.Red,
                                           eToastPosition.TopCenter)
                End If
            Else
                ToastNotification.Show(Me, mensajeError.ToUpper,
                                           My.Resources.I64x64_error, InDuracion * 1000,
                                           eToastGlowColor.Red,
                                           eToastPosition.TopCenter)
            End If
        End If
    End Sub

    Private Sub P_prGrabarRegistro()
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
        Dim recven As String
        Dim supven As String
        Dim preven As String

        Dim tacu As String
        Dim fini As String
        Dim ffin As String
        Dim fre As String
        Dim acuEst As String
        Dim acuObs As String

        Dim tcre As String


        DgjEquipo.Refetch()
        If (BoNuevo) Then
            If (P_fnValidarGrabacion()) Then

                numi = L_GetLastIdTablas("TC004", "ccnumi") + 1
                cod = tbCodCliente.Text.Trim
                desc = TbNombre.Text.Trim

                zona = CbZona.Value
                dct = CbTipoDoc.Value
                dctnum = IIf(TbNroDoc.Text.Trim.Equals(""), "0", TbNroDoc.Text.Trim)
                direc = IIf(TbDireccion.Text.Trim.Equals(""), "S/DIR", TbDireccion.Text.Trim)
                telf1 = IIf(TbTelefono1.Text.Trim.Equals(""), "0", TbTelefono1.Text.Trim)
                telf2 = IIf(TbTelefono2.Text.Trim.Equals(""), "0", TbTelefono2.Text.Trim)
                cat = CbCategoria.Value
                est = "1"
                If (RbActivo.Checked) Then
                    est = "1"
                ElseIf (RbPasivo.Checked) Then
                    est = "0"
                ElseIf (RbDevuelto.Checked) Then
                    est = "2"
                End If
                lat = IIf(tbLatitud.Text.Trim.Equals(""), 0, tbLatitud.Text.Trim)
                lon = IIf(tbLongitud.Text.Trim.Equals(""), 0, tbLongitud.Text.Trim)
                prconsu = "0"
                even = IIf(SbEventual.Value, "0", "1")
                obs = IIf(TbObs.Text.Trim.Equals(""), "S/OBS", TbObs.Text.Trim)
                fnac = DtiFechaNac.Value.ToString("yyyy/MM/dd")
                nomfac = IIf(TbNombreFactura.Text.Trim.Equals(""), "S/N", TbNombreFactura.Text.Trim)
                nit = IIf(TbNit.Text.Trim.Equals(""), "0", TbNit.Text.Trim)
                ultped = DtiUltimoPedido.Value.ToString("yyyy/MM/dd")
                fecing = DtiFechaIng.Value.ToString("yyyy/MM/dd")
                ultvent = "2000/01/01"
                recven = tbRecorrido.Text.Trim
                supven = cbSupervisor.Value.ToString
                preven = cbPrevendedor.Value.ToString

                tcre = cbTipoCredito.Value.ToString

                Dim dtDet1 As DataTable = Nothing
                Dim dtDet2 As DataTable = Nothing
                If (gi_vacu = 1) Then
                    dtDet1 = CType(dgjDias.DataSource, DataTable).Clone
                    dtDet2 = CType(dgjProducto.DataSource, DataTable).Clone
                End If

                If (gi_vacu = 1 And dgjProducto.GetRows.Count > 1) Then
                    tacu = cbTipoAcuerdo.Value.ToString
                    fini = dtFechaInicio.Value.ToString("yyyy/MM/dd")
                    ffin = dtFechaFinal.Value.ToString("yyyy/MM/dd")
                    fre = cbFrecuencia.Value.ToString
                    acuEst = IIf(btEstado.Value, "1", "0")
                    acuObs = tbAcuObs.Text.Trim

                    For Each fil As DataRow In CType(dgjDias.DataSource, DataTable).Rows
                        If (fil.Item("check")) Then
                            fil.Item("estado") = 1
                            dtDet1.ImportRow(fil)
                        End If
                    Next

                    dtDet1 = dtDet1.DefaultView.ToTable(False, "ccaanumi", "ccatc4anumi", "ccaandia", "estado")
                    dtDet2 = CType(dgjProducto.DataSource, DataTable).DefaultView.ToTable(False, "ccabnumi", "ccabtc4anumi", "ccabprod", "ccabcant", "estado")
                Else
                    tacu = "-1"
                End If

                BtAddEquipo.Select()

                Dim dt As DataTable = CType(DgjEquipo.DataSource, DataTable).DefaultView.ToTable(False, "chnumi", "chfec", "chcod", "chdesc", "chtmov", "chnrem", "chcan", "chmonbs", "chmonsus", "chnota", "chlin", "chobs", "estado")
                Dim dt2 As DataTable = CType(grCatProd.DataSource, DataTable).DefaultView.ToTable(False, "cpnumi", "cpcli", "cpprod", "cpcat")
                'Grabar
                Dim res As Boolean = L_fnGrabarCliente(numi, cod, desc, zona, dct, dctnum, direc, telf1, telf2, cat,
                                                       est, lat, lon, prconsu, even, obs, fnac, nomfac, nit, ultped,
                                                       fecing, ultvent, recven, supven, preven, dt, dt2, tacu, fini, ffin,
                                                       fre, acuEst, acuObs, tcre,
                                                       dtDet1,
                                                       dtDet2)

                If (res) Then
                    P_prLimpiar()
                    BoNavegar = False
                    P_prArmarGrillaBusqueda()
                    P_ArmarGrillaSugerencia()
                    BoNavegar = True

                    TbNombre.Select()
                    ToastNotification.Show(Me, "Codigo de cliente ".ToUpper + TbCodigo.Text + " Grabado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA,
                                       InDuracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
                Else
                    ToastNotification.Show(Me, "No se pudo grabar el codigo de cliente ".ToUpper + TbCodigo.Text + ", intente nuevamente.".ToUpper,
                                       My.Resources.WARNING,
                                       InDuracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)
                End If
            End If
        ElseIf (BoModificar) Then
            If (P_fnValidarGrabacion()) Then
                numi = TbCodigo.Text.Trim
                cod = tbCodCliente.Text
                desc = TbNombre.Text.Trim
                zona = CbZona.Value
                dct = CbTipoDoc.Value
                dctnum = TbNroDoc.Text
                direc = TbDireccion.Text
                telf1 = TbTelefono1.Text
                telf2 = TbTelefono2.Text
                cat = CbCategoria.Value
                est = "1"
                If (RbActivo.Checked) Then
                    est = "1"
                ElseIf (RbPasivo.Checked) Then
                    est = "0"
                ElseIf (RbDevuelto.Checked) Then
                    est = "2"
                End If
                lat = IIf(tbLatitud.Text.Trim.Equals(""), 0, tbLatitud.Text.Trim)
                lon = IIf(tbLongitud.Text.Trim.Equals(""), 0, tbLongitud.Text.Trim)
                even = IIf(SbEventual.Value, "0", "1")
                obs = IIf(TbObs.Text.Trim.Equals(""), "S/OBS", TbObs.Text.Trim)
                fnac = DtiFechaNac.Value.ToString("yyyy/MM/dd")
                nomfac = TbNombreFactura.Text.Trim
                nit = TbNit.Text.Trim
                ultped = DtiUltimoPedido.Value.ToString("yyyy/MM/dd")
                fecing = DtiFechaIng.Value.ToString("yyyy/MM/dd")
                ultvent = DtiUltimaVenta.Value.ToString("yyyy/MM/dd")
                recven = tbRecorrido.Text.Trim
                supven = cbSupervisor.Value.ToString
                preven = cbPrevendedor.Value.ToString

                tcre = cbTipoCredito.Value.ToString

                Dim dtDet1 As DataTable = Nothing
                Dim dtDet2 As DataTable = Nothing
                If (gi_vacu = 1) Then
                    dtDet1 = CType(dgjDias.DataSource, DataTable).Clone
                    dtDet2 = CType(dgjProducto.DataSource, DataTable).Clone
                End If

                If (gi_vacu = 1 And dgjProducto.GetRows.Count > 1) Then
                    tacu = cbTipoAcuerdo.Value.ToString
                    fini = dtFechaInicio.Value.ToString("yyyy/MM/dd")
                    ffin = dtFechaFinal.Value.ToString("yyyy/MM/dd")
                    fre = cbFrecuencia.Value.ToString
                    acuEst = IIf(btEstado.Value, "1", "0")
                    acuObs = tbAcuObs.Text.Trim

                    For Each fil As DataRow In CType(dgjDias.DataSource, DataTable).Rows
                        If (fil.Item("check")) Then
                            fil.Item("estado") = 1
                            dtDet1.ImportRow(fil)
                        End If
                    Next

                    dtDet1 = dtDet1.DefaultView.ToTable(False, "ccaanumi", "ccatc4anumi", "ccaandia", "estado")
                    dtDet2 = CType(dgjProducto.DataSource, DataTable).DefaultView.ToTable(False, "ccabnumi", "ccabtc4anumi", "ccabprod", "ccabcant", "estado")
                Else
                    tacu = "-1"
                End If

                BtAddEquipo.Select()

                Dim dt As DataTable = CType(DgjEquipo.DataSource, DataTable).DefaultView.ToTable(False, "chnumi", "chfec", "chcod", "chdesc", "chtmov", "chnrem", "chcan", "chmonbs", "chmonsus", "chnota", "chlin", "chobs", "estado")
                Dim dt2 As DataTable = CType(grCatProd.DataSource, DataTable).DefaultView.ToTable(False, "cpnumi", "cpcli", "cpprod", "cpcat")
                'Grabar
                Dim res As Boolean = L_fnModificarCliente(numi, cod, desc, zona, dct, dctnum, direc, telf1, telf2, cat,
                                                          est, lat, lon, even, obs, fnac, nomfac, nit, ultped,
                                                          fecing, ultvent, recven, supven, preven, dt, dt2, tacu, fini, ffin,
                                                          fre, acuEst, acuObs, tcre,
                                                          dtDet1,
                                                          dtDet2)

                If (res) Then

                    BoNavegar = False
                    P_prArmarGrillaBusqueda()
                    P_ArmarGrillaSugerencia()
                    BoNavegar = True

                    P_prMoverIndexActual()

                    TbNombre.Select()
                    MBtSalir.PerformClick()

                    ToastNotification.Show(Me, "Codigo de cliente ".ToUpper + TbCodigo.Text + " Modificado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA,
                                       InDuracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
                Else
                    ToastNotification.Show(Me, "No se pudo modificar el codigo de cliente ".ToUpper + TbCodigo.Text + ", intente nuevamente.".ToUpper,
                                       My.Resources.WARNING,
                                       InDuracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)
                End If
            End If
        End If
    End Sub

    Private Sub P_prCancelarRegistro()
        If (Not MBtGrabar.Enabled) Then
            Me.Close()
            _modulo.Select()
            _tab.Close()
        Else
            P_prLimpiar()
            P_prHDComponentes(False)
            P_prLlenarDatos(DgjBusqueda.Row)
        End If
        P_prEstadoNueModEli(4)
    End Sub

    Private Sub P_prEstadoNueModEli(value As Integer)
        BoNuevo = (value = 1)
        BoModificar = (value = 2)
        BoEliminar = (value = 3)

        MBtNuevo.Enabled = (value = 4)
        MBtModificar.Enabled = (value = 4)
        MBtEliminar.Enabled = (value = 4)
        MBtGrabar.Enabled = Not (value = 4)

        If (value = 4) Then
            MBtSalir.Tooltip = "SALIR"
            MBtSalir.Text = "SALIR"
        Else
            MBtSalir.Tooltip = "CANCELAR"
            MBtSalir.Text = "CANCELAR"
        End If

        MBtPrimero.Enabled = (value = 4)
        MBtAnterior.Enabled = (value = 4)
        MBtSiguiente.Enabled = (value = 4)
        MBtUltimo.Enabled = (value = 4)
        MSuperTabItemBusqueda.Visible = (value = 4)

        Tsmi1Eliminar.Visible = Not (value = 4)

        MBtGrabar.Tooltip = IIf(value = 1, "GRABAR NUEVO REGISTRO", IIf(value = 2, "GRABAR MODIFICACIÓN DE REGISTRO", "GRABAR"))
        MRlAccion.Text = IIf(value = 1, "NUEVO", IIf(value = 2, "MODIFICAR", ""))

        'Compentes

        If (MSuperTabControlPrincipal.SelectedTabIndex = 1 Or MSuperTabControlPrincipal.SelectedTabIndex = 2) Then
            MSuperTabControlPrincipal.SelectedTabIndex = 0
        End If

    End Sub

    Private Sub P_prCargarImagen(pbimg As PictureBox)
        'OfdProducto.InitialDirectory = "C:\Users\" + Environment.UserName + "\Pictures"
        'OfdProducto.Filter = "Imagen|*.jpg;*.jpeg;*.png;*.bmp"
        'OfdProducto.FilterIndex = 1
        'If (OfdProducto.ShowDialog() = DialogResult.OK) Then
        '    vlImagen = New CImagen(OfdProducto.SafeFileName, OfdProducto.FileName, 0)
        '    pbimg.SizeMode = PictureBoxSizeMode.StretchImage
        '    pbimg.Load(vlImagen.getImagen())
        'End If
    End Sub

    Private Function P_fnObtenerID() As String
        Dim res As String = ""
        res = res + Now.Hour.ToString("00") + Now.Minute.ToString("00") + Now.Second.ToString("00") + "_" _
            + Now.Day.ToString("00") + Now.Month.ToString("00") + Now.Year.ToString("0000")
        Return res
    End Function

    Private Sub P_prEliminarArchivosSinReferencia(dt As DataTable, col As String, ruta As String)
        Try
            For Each foundFile As String In My.Computer.FileSystem.GetFiles(ruta)
                Dim split As String() = foundFile.Split("\")
                Dim nomImg As String = split(split.Length - 1)
                Dim array As DataRow() = dt.Select(col + "='" + nomImg + "'")
                If (array.Length = 0) Then
                    My.Computer.FileSystem.DeleteFile(ruta + "\" + nomImg, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Metodos y funciones generales"

    Private Sub P_prValidarCarpetaImagenes()
        Dim rutaDestino As String = StRutaDocumentos
        If (System.IO.Directory.Exists(rutaDestino) = False) Then
            System.IO.Directory.CreateDirectory(rutaDestino)
        End If
    End Sub

    Private Sub P_prArmarComboZona()
        Dim Dt As New DataTable
        Dt = L_GetZonasCPZ().Tables(0)

        With CbZona.DropDownList
            .Columns.Add(Dt.Columns("lanumi").ToString).Width = 50
            .Columns(0).Caption = "Código"

            .Columns.Add(Dt.Columns("city").ToString).Width = 150
            .Columns(1).Caption = "Cuidad"

            .Columns.Add(Dt.Columns("prov").ToString).Width = 150
            .Columns(2).Caption = "Provincia"

            .Columns.Add(Dt.Columns("Zona").ToString).Width = 150
            .Columns(3).Caption = "Zona"
        End With

        CbZona.ValueMember = Dt.Columns("lanumi").ToString
        CbZona.DisplayMember = Dt.Columns("zona").ToString
        CbZona.DataSource = Dt
        CbZona.Refresh()
    End Sub

    Private Sub P_prArmarComboTipoDoc()
        Dim Dt As New DataTable

        Dt = L_fnObtenerLibreria("9", " 1=1 ")
        g_prArmarCombo(CbTipoDoc, Dt, 60, 200, "Código", "Descripción")
    End Sub

    Private Sub P_prArmarComboCatCliente()

        Dim Dt As New DataTable
        Dt = L_CategoriaPrecioGeneral()
        With CbCategoria.DropDownList
            .Columns.Add(Dt.Columns(0).ToString).Width = 50
            .Columns(0).Caption = "Código"

            .Columns.Add(Dt.Columns(1).ToString).Width = 70
            .Columns(1).Caption = "Abreviatura"

            .Columns.Add(Dt.Columns(2).ToString).Width = 120
            .Columns(2).Caption = "Descripción"
        End With

        CbCategoria.ValueMember = Dt.Columns(0).ToString
        CbCategoria.DisplayMember = Dt.Columns(1).ToString
        CbCategoria.DataSource = Dt
        CbCategoria.Refresh()
    End Sub

    Private Sub P_prArmarComboEquipo()
        Dim dt As New DataTable

        dt = gt_Productos
        With CbFiltroResumenEquipo.DropDownList
            .Columns.Add(dt.Columns(0).ToString).Width = 80
            .Columns(0).Caption = "Código"

            .Columns.Add(dt.Columns(2).ToString).Width = 200
            .Columns(1).Caption = "Descripción"
        End With

        CbFiltroResumenEquipo.ValueMember = dt.Columns(1).ToString
        CbFiltroResumenEquipo.DisplayMember = dt.Columns(2).ToString
        CbFiltroResumenEquipo.DataSource = dt
        CbFiltroResumenEquipo.Refresh()

        CbFiltroResumenEquipo.SelectedIndex = 0
    End Sub

    Private Sub P_prArmarComboTipoAcuerdo()
        Dim Dt As New DataTable

        Dt = L_fnObtenerLibreria("14", " 1=1 ")
        g_prArmarCombo(cbTipoAcuerdo, Dt, 60, 200, "Código", "Descripción")
    End Sub

    Private Sub P_prArmarComboFrecuencia()
        Dim Dt As New DataTable

        Dt = L_fnObtenerLibreria("15", " 1=1 ")
        g_prArmarCombo(cbFrecuencia, Dt, 60, 200, "Código", "Descripción")
    End Sub

    Private Sub P_prArmarGrillaBusqueda()
        DtBusqueda = New DataTable
        DtBusqueda = L_fnClientes()

        DgjBusqueda.BoundMode = Janus.Data.BoundMode.Bound
        DgjBusqueda.DataSource = DtBusqueda
        DgjBusqueda.RetrieveStructure()

        'dar formato a las columnas
        With DgjBusqueda.RootTable.Columns(0)
            .Caption = "Cod. Sis."
            .Key = "numi"
            .Width = 80
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With DgjBusqueda.RootTable.Columns(1)
            .Caption = "Cod. Cliente"
            .Key = "cod"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With DgjBusqueda.RootTable.Columns(2)
            .Caption = "Nombre"
            .Key = "desc"
            .Width = 300
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With DgjBusqueda.RootTable.Columns(3)
            .Caption = "Dirección"
            .Key = "direc"
            .Width = 300
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjBusqueda.RootTable.Columns(4)
            .Caption = "Teléfono 2"
            .Key = "telf1"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With DgjBusqueda.RootTable.Columns(5)
            .Caption = "Teléfono 1"
            .Key = "telf2"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjBusqueda.RootTable.Columns(6)
            .Caption = ""
            .Key = "zona"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjBusqueda.RootTable.Columns(7)
            .Caption = "Zona"
            .Key = "nzona"
            .Width = 120
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjBusqueda.RootTable.Columns(8)
            .Caption = ""
            .Key = "dct"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjBusqueda.RootTable.Columns(9)
            .Caption = "Tipo de Documento"
            .Key = "ndct"
            .Width = 120
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjBusqueda.RootTable.Columns(10)
            .Caption = "Nro Documento"
            .Key = "dctnum"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjBusqueda.RootTable.Columns(11)
            .Caption = ""
            .Key = "cat"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjBusqueda.RootTable.Columns(12)
            .Caption = "Categoria"
            .Key = "ncat"
            .Width = 120
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjBusqueda.RootTable.Columns(13)
            .Caption = "Estado"
            .Key = "est"
            .Width = 80
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjBusqueda.RootTable.Columns(14)
            .Caption = "Latitud"
            .Key = "lat"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
            .FormatString = "0.00000000000000"
        End With
        With DgjBusqueda.RootTable.Columns(15)
            .Caption = "Longitud"
            .Key = "longi"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
            .FormatString = "0.00000000000000"
        End With
        With DgjBusqueda.RootTable.Columns(16)
            .Caption = "Eventual"
            .Key = "even"
            .Width = 80
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjBusqueda.RootTable.Columns(17)
            .Caption = "Observación"
            .Key = "obs"
            .Width = 300
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjBusqueda.RootTable.Columns(18)
            .Caption = "Fecha de Nac"
            .Key = "fnac"
            .Width = 120
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjBusqueda.RootTable.Columns(19)
            .Caption = "Nombre Factura"
            .Key = "nomfac"
            .Width = 200
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjBusqueda.RootTable.Columns(20)
            .Caption = "NIT"
            .Key = "nit"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjBusqueda.RootTable.Columns(21)
            .Caption = "Fecha de Ingreso"
            .Key = "fing"
            .Width = 120
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjBusqueda.RootTable.Columns(22)
            .Caption = "Fecha de Ultimo Pedido"
            .Key = "ultped"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjBusqueda.RootTable.Columns(23)
            .Caption = "Fecha de Ultimo Venta"
            .Key = "ultven"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(24)
            .Caption = "Recorrido"
            .Key = "recven"
            .Width = 80
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(25)
            .Caption = ""
            .Key = "supven"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(26)
            .Caption = "Supervisor"
            .Key = "nsupven"
            .Width = 150
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(27)
            .Caption = ""
            .Key = "preven"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(28)
            .Caption = "Pre-Vendedor"
            .Key = "npreven"
            .Width = 150
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(29)
            .Caption = "Tipo Crédito"
            .Key = "tcre"
            .Width = 150
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(30)
            .Caption = ""
            .Key = "ntcre"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(31)
            .Caption = ""
            .Key = "fact"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjBusqueda.RootTable.Columns(32)
            .Caption = ""
            .Key = "hact"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjBusqueda.RootTable.Columns(33)
            .Caption = ""
            .Key = "uact"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        'Habilitar Filtradores
        With DgjBusqueda
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
            .SelectionMode = SelectionMode.MultipleSelection
            .AlternatingColors = True
            .RecordNavigator = True
        End With
    End Sub

    Private Sub P_prArmarGrillaEquipo(numi As String)
        DtDetalle = New DataTable
        DtDetalle = L_fnClienteEquipo(numi)

        DgjEquipo.BoundMode = Janus.Data.BoundMode.Bound
        DgjEquipo.DataSource = DtDetalle
        DgjEquipo.RetrieveStructure()

        'dar formato a las columnas
        With DgjEquipo.RootTable.Columns(0)
            .Caption = "codigo"
            .Key = "numi"
            .Width = 80
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With DgjEquipo.RootTable.Columns(1)
            .Caption = "Fecha"
            .Key = "fec"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With DgjEquipo.RootTable.Columns(2)
            .Caption = "Descripción Equipo"
            .Key = "cod"
            .Width = 200
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
            .HasValueList = True
            'Set EditType to Combo or DropDownList.
            'In a MultipleValues Column, the dropdown will appear with a CheckBox
            'at the left of each item to let the user select multiple items
            .EditType = EditType.Combo
            .ValueList.PopulateValueList(gt_Productos.DefaultView, "canumi", "cadesc")
            .CompareTarget = ColumnCompareTarget.Text
            .DefaultGroupInterval = GroupInterval.Text
        End With

        With DgjEquipo.RootTable.Columns(3)
            .Caption = "descripcion equipo"
            .Key = "ncod"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With DgjEquipo.RootTable.Columns(4)
            .Caption = "En Calidad de"
            .Key = "tmov"
            .Width = 120
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
            .HasValueList = True
            'Set EditType to Combo or DropDownList.
            'In a MultipleValues Column, the dropdown will appear with a CheckBox
            'at the left of each item to let the user select multiple items
            .EditType = EditType.Combo
            .ValueList.PopulateValueList(L_GetConceptoInvetario().DefaultView, "cpnumi", "cpdesc")
            .CompareTarget = ColumnCompareTarget.Text
            .DefaultGroupInterval = GroupInterval.Text
        End With
        With DgjEquipo.RootTable.Columns(5)
            .Caption = "Nro. Boleta"
            .Key = "nrem"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With DgjEquipo.RootTable.Columns(6)
            .Caption = "Cantidad"
            .Key = "can"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            .FormatString = "0"
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjEquipo.RootTable.Columns(7)
            .Caption = "Monto"
            .Key = "monbs"
            .Width = 120
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            .FormatString = "0.00"
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjEquipo.RootTable.Columns(8)
            .Caption = "monto sus"
            .Key = "monsus"
            .Width = 120
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            .FormatString = "0.00"
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjEquipo.RootTable.Columns(9)
            .Caption = "Letra de cambio"
            .Key = "nota"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjEquipo.RootTable.Columns(10)
            .Caption = "lin"
            .Key = "lin"
            .Width = 80
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjEquipo.RootTable.Columns(11)
            .Caption = "Cod. Equipo"
            .Key = "obs"
            .Width = 180
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjEquipo.RootTable.Columns(12)
            .Key = "estado"
            .Visible = False
        End With
        With DgjEquipo.RootTable.Columns(13)
            .Caption = "mov"
            .Key = "mov"
            .Width = 80
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjEquipo.RootTable.Columns(14)
            .Caption = "mov. cli"
            .Key = "movcli"
            .Width = 80
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        'Habilitar Filtradores
        With DgjEquipo
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
            .SelectionMode = SelectionMode.MultipleSelection
            .AlternatingColors = True
            .RecordNavigator = True
        End With
    End Sub

    Private Sub P_prArmarGrillaDias(numi As String)
        Dim dtDias, dtDiasTra As DataTable
        'Dim nroDia As String = Now.Date.AddDays(1).ToString("dddd")

        Dim dias As String() = {"Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sábado", "Domingo",
                                "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sábado", "Domingo",
                                "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sábado", "Domingo",
                                "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sábado", "Domingo",
                                "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sábado", "Domingo",
                                "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sábado", "Domingo"}
        dtDias = New DataTable
        dtDiasTra = New DataTable
        dtDias = L_fnObtenerDetalleTC004A1(numi)

        dtDiasTra = dtDias.Clone

        Select Case cbFrecuencia.Value
            Case 1
                For i As Byte = 1 To 7
                    dtDiasTra.Rows.Add({0, CInt(numi), dias(i - 1), i, False, -1})
                Next
            Case 2
                For i As Byte = 1 To 15
                    dtDiasTra.Rows.Add({0, CInt(numi), dias(i - 1), i, False, -1})
                Next
            Case 3
                For i As Byte = 1 To 31
                    dtDiasTra.Rows.Add({0, CInt(numi), dias(i - 1), i, False, -1})
                Next
        End Select

        For Each fil1 As DataRow In dtDias.Rows
            For Each fil2 As DataRow In dtDiasTra.Rows
                If (fil1.Item("ccaandia") = fil2.Item("ccaandia")) Then
                    fil2.Item("ccaanumi") = fil1.Item("ccaanumi")
                    fil2.Item("estado") = 1
                    fil2.Item("check") = True
                End If
            Next
        Next

        dgjDias.BoundMode = Janus.Data.BoundMode.Bound
        dgjDias.DataSource = dtDiasTra
        dgjDias.RetrieveStructure()

        'dar formato a las columnas
        With dgjDias.RootTable.Columns("ccaanumi")
            .Visible = False
        End With

        With dgjDias.RootTable.Columns("ccatc4anumi")
            .Visible = False
        End With

        With dgjDias.RootTable.Columns("dia")
            .Caption = "Día"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With

        With dgjDias.RootTable.Columns("ccaandia")
            .Caption = "Nro Día"
            .Width = 60
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            .Position = 0
        End With

        With dgjDias.RootTable.Columns("check")
            .Caption = "Check!"
            .Width = 80
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = True
        End With

        With dgjDias.RootTable.Columns("estado")
            .Width = 80
            .Visible = False
        End With

        'Habilitar Filtradores
        With dgjDias
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
            .SelectionMode = SelectionMode.MultipleSelection
            .AlternatingColors = True
            .RecordNavigator = True
        End With
    End Sub

    Private Sub P_prArmarGrillaProducto(numi As String)
        Dim dtProducto As DataTable
        dtProducto = New DataTable
        dtProducto = L_fnObtenerDetalleTC004A2(numi)

        dgjProducto.BoundMode = Janus.Data.BoundMode.Bound
        dgjProducto.DataSource = dtProducto
        dgjProducto.RetrieveStructure()

        'dar formato a las columnas
        With dgjProducto.RootTable.Columns("ccabnumi")
            .Visible = False
        End With

        With dgjProducto.RootTable.Columns("ccabtc4anumi")
            .Visible = False
        End With

        With dgjProducto.RootTable.Columns("ccabprod")
            .Caption = "Código"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With

        With dgjProducto.RootTable.Columns("nprod")
            .Caption = "Descripción"
            .Width = 350
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With

        With dgjProducto.RootTable.Columns("ccabcant")
            .Caption = "Cantidad"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            .FormatString = "0.00"
        End With

        With dgjProducto.RootTable.Columns("estado")
            .Width = 80
            .Visible = False
        End With

        'Habilitar Filtradores
        With dgjProducto
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
            .SelectionMode = SelectionMode.MultipleSelection
            .AlternatingColors = True
            .RecordNavigator = True
        End With
    End Sub

    Private Function P_fnValidarGrabacion() As Boolean
        'Dim res As Boolean = True
        'MEP.Clear()

        'If (TbNombre.Text = String.Empty) Then
        '    TbNombre.BackColor = Color.Red
        '    MEP.SetError(TbNombre, "ingrese el nombre del producto!".ToUpper)
        '    res = False
        'Else
        '    TbNombre.BackColor = Color.White
        '    MEP.SetError(TbNombre, "")
        'End If

        'If (Not IsNumeric(CbCategoria.Value)) Then
        '    CbCategoria.BackColor = Color.Red
        '    MEP.SetError(CbCategoria, "Seleccione una categoria de producto!".ToUpper)
        '    res = False
        'Else
        '    CbCategoria.BackColor = Color.White
        '    MEP.SetError(CbCategoria, "")
        'End If

        'Return res

        If (TbNombre.Text.Trim.Equals("")) Then
            ToastNotification.Show(Me, "El nombre no puede estar vacio".ToUpper,
                       My.Resources.WARNING,
                       InDuracion * 1000,
                       eToastGlowColor.Red,
                       eToastPosition.BottomLeft)
            Return False
            Exit Function
        End If
        If (TbNroDoc.Text.Trim.Equals("")) Then
            ToastNotification.Show(Me, "El Nro de Documento no puede estar vacio".ToUpper,
                       My.Resources.WARNING,
                       InDuracion * 1000,
                       eToastGlowColor.Red,
                       eToastPosition.BottomLeft)
            Return False
            Exit Function
        End If
        If (BoEliminar) Then
            If (DtiFechaIng.Value > DtiUltimoPedido.Value) Then
                ToastNotification.Show(Me, "No se puede eliminar a este cliente, tiene pedido realizados!!!".ToUpper,
                       My.Resources.WARNING,
                       InDuracion * 1000,
                       eToastGlowColor.Red,
                       eToastPosition.BottomLeft)
                Return False
                Exit Function
            End If
        End If
        Return True
    End Function

#End Region

    Private Sub P_prMapaLoad()
        Punto = 0
        Overlay = New GMapOverlay("points")
        GmUbicacionCliente.Overlays.Add(Overlay)

        P_prIniciarMapa()
    End Sub

    Private Sub P_prIniciarMapa()
        With GmUbicacionCliente
            .DragButton = MouseButtons.Left
            .CanDragMap = True
            .MapProvider = GMapProviders.GoogleMap
            .Position = New PointLatLng(-17.782814, -63.182386)
            .MinZoom = 0
            .MaxZoom = 24
            .Zoom = 15.5
            .AutoScroll = True
            GMapProvider.Language = LanguageType.Spanish
        End With
    End Sub

    Private Sub P_prAgregarPunto(plg As PointLatLng)
        'añadir puntos
        'Dim markersOverlay As New GMapOverlay("markers")
        Dim marker As New GMarkerGoogle(plg, My.Resources.markerIcono)
        'añadir tooltip
        Dim mode As MarkerTooltipMode = MarkerTooltipMode.OnMouseOver
        marker.ToolTip = New GMapBaloonToolTip(marker)
        marker.ToolTipMode = mode
        Dim ToolTipBackColor As New SolidBrush(Color.Red)
        marker.ToolTip.Fill = ToolTipBackColor
        marker.ToolTipText = "CLIENTE-> " + TbNombre.Text

        Overlay.Markers.Add(marker)
        'mapa.Overlays.Add(markersOverlay)

        GmUbicacionCliente.Position = plg
    End Sub

    Private Sub P_prPonerDatosEquipoPorCliente(p1 As String)

    End Sub

    Private Sub P_prPonerResumenEquipo()
        TbiCantSaliente.Value = 0
        TbiCantEntrante.Value = 0
        TbiCantSaldo.Value = 0
        'If (DtProductosCompuestos.Select("canumi=" + CbFiltroResumenEquipo.Value.ToString).Length = 0) Then
        Dim s As String = CbFiltroResumenEquipo.Value.ToString
        TbiCantSaliente.Value = P_fnResumenProducto(CbFiltroResumenEquipo.Value.ToString, "-1")
        TbiCantEntrante.Value = P_fnResumenProducto(CbFiltroResumenEquipo.Value.ToString, "1") * -1
        TbiCantSaldo.Value = TbiCantSaliente.Value + TbiCantEntrante.Value
        'Else
        'ToastNotification.Show(Me, "El equipo con código: ".ToUpper + CbFiltroResumenEquipo.Value.ToString _
        '                       + " es un equipo compuesto,".ToUpper + ChrW(13) + "sus partes se sumaran como individuales".ToUpper,
        '                       My.Resources.INFORMATION, _DuracionSms * 1000,
        '                       eToastGlowColor.Orange,
        '                       eToastPosition.TopCenter)
        'End If
        P_prSRProductosCompuestos() 'Sumar o Restar los Productos Compuesto
    End Sub

    Private Function P_fnResumenProducto(cpro As String, sr As String) As Integer
        Dim dt As DataTable
        Dim sum As Double = 0
        dt = CType(DgjEquipo.DataSource, DataTable)
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

    Private Sub P_prSRProductosCompuestos()
        Dim Suma As Double = 0
        Dim Resta As Double = 0
        Dim Array As DataRow() = DtProductoCompuesto.Select("cpcprod=" + CbFiltroResumenEquipo.Value.ToString)
        Dim Pc As String = ""
        If (Array.Length > 0) Then
            Pc = Array(0).Item("canumi").ToString
            Suma = P_fnResumenProducto(Pc, "-1")
            Resta = P_fnResumenProducto(Pc, "1") * -1
            TbiCantSaliente.Value = TbiCantSaliente.Value + Suma
            TbiCantEntrante.Value = TbiCantEntrante.Value - Resta
            TbiCantSaldo.Value = TbiCantSaliente.Value + TbiCantEntrante.Value
        End If
    End Sub

    Private Sub ChBuscar_CheckedChanged(sender As Object, e As EventArgs) Handles ChBuscar.CheckedChanged
        If (ChBuscar.Checked) Then
            DgjEquipo.FilterMode = FilterMode.Automatic
        Else
            DgjEquipo.FilterMode = FilterMode.None
        End If
    End Sub

    Private Sub BtAddEquipo_Click(sender As Object, e As EventArgs) Handles BtAddEquipo.Click
        If (DgjEquipo.GetRows.Count = 0) Then
            P_AddFilaEquipos()
            'Dim dt As DataTable = Dgs_Equipos.PrimaryGrid.DataSource
            DgjEquipo.Refetch()
            DgjEquipo.Select()
            DgjEquipo.Col = DgjEquipo.RootTable.Columns("cod").Index
            DgjEquipo.Row = 0
            'Dgs_Equipos.PrimaryGrid.SetActiveCell(Dgs_Equipos.PrimaryGrid.GetCell(0, Dgs_Equipos.PrimaryGrid.Columns("chcod").ColumnIndex))
        Else
            'If (P_ValidarFilaGridEquipo(DgjEquipo.GetRows.Count - 1)) Then
            P_AddFilaEquipos()
            DgjEquipo.Refetch()
            DgjEquipo.Select()
            DgjEquipo.Col = DgjEquipo.RootTable.Columns("cod").Index
            DgjEquipo.Row = 0
            'Dgs_Equipos.PrimaryGrid.SetActiveCell(Dgs_Equipos.PrimaryGrid.GetCell(0, Dgs_Equipos.PrimaryGrid.Columns("chcod").ColumnIndex))
            'End If
        End If
    End Sub

    Private Sub P_AddFilaEquipos()
        Dim f As DataRow
        'f = DtDetalle.NewRow
        f = CType(DgjEquipo.DataSource, DataTable).NewRow

        'Codigo cabera
        f.Item(0) = 0
        'Fecha
        f.Item(1) = Now.Date

        'Código producto
        Dim cprod As String = L_GetFilaTabla("TC001", "top(1) cacod", "caest=1 and caserie=1").Item("cacod").ToString
        f.Item(2) = cprod

        'Descripción Producto
        f.Item(3) = ""

        'En calidad de
        f.Item(4) = L_GetFilaTabla("TCI001", "top(1) cpnumi", "cptipo=1 and cpest=1").Item("cpnumi")


        'Nro remicion
        f.Item(5) = 0

        'Cantidad
        f.Item(6) = 1

        'Monto bs
        f.Item(7) = 0

        'Monto sus
        f.Item(8) = 0

        'Nro venta
        f.Item(9) = 0

        'Nro linea
        f.Item(10) = 0

        'Obs
        f.Item(11) = ""

        'Estado
        f.Item(12) = 0

        'Indicador de movimiento
        f.Item(13) = L_GetFilaTabla("TCI001", "top(1) cpmov", "cptipo=1 and cpest=1").Item("cpmov")

        'Incluidor de movimiento al progama de cliente
        f.Item(14) = 0

        'DtDetalle.BeginInit()
        'DtDetalle.Rows.InsertAt(f, 0)
        'DtDetalle.EndInit()

        CType(DgjEquipo.DataSource, DataTable).Rows.InsertAt(f, 0)
    End Sub

    Private Function P_ValidarFilaGridEquipo(index As Integer) As Boolean
        'validando codigo de producto, no puede estar vacio
        If (IsNumeric(DgjEquipo.GetRow(index).Cells("cod").Value())) Then
            ToastNotification.Show(Me, "el código, no puede estar vacio".ToUpper,
                       My.Resources.WARNING,
                       InDuracion * 1000,
                       eToastGlowColor.Red,
                       eToastPosition.BottomLeft)
            Return False
            Exit Function
        End If
        'validando tipo de movimiento, no puede estar vacio
        If (IsNumeric(DgjEquipo.GetRow(index).Cells("tmov").Value())) Then
            ToastNotification.Show(Me, "en calidad de, no puede estar vacio".ToUpper,
                       My.Resources.WARNING,
                       InDuracion * 1000,
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
        If (DgjEquipo.GetRow(index).Cells("can").Value().ToString.Trim.Equals("0")) Then
            ToastNotification.Show(Me, "la cantidad, no puede cero (0)".ToUpper,
                       My.Resources.WARNING,
                       InDuracion * 1000,
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

    Private Sub DgjEquipo_KeyDown(sender As Object, e As KeyEventArgs) Handles DgjEquipo.KeyDown
        If (e.KeyData = Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Tsmi1Eliminar_Click(sender As Object, e As EventArgs) Handles Tsmi1Eliminar.Click
        Dim fi As Integer = DgjEquipo.Row
        If (fi > -1) Then
            If (BoNuevo Or BoModificar) Then
                DgjEquipo.CurrentRow.EndEdit()
                DgjEquipo.CurrentRow.Delete()
                DgjEquipo.Refetch()
                DgjEquipo.Refresh()
            End If
        End If
    End Sub

    Private Sub P_ArmarGrillaSugerencia()
        DgjSugerencia.BoundMode = Janus.Data.BoundMode.Bound
        DgjSugerencia.DataSource = L_fnClientes()
        DgjSugerencia.RetrieveStructure()

        'dar formato a las columnas
        With DgjSugerencia.RootTable.Columns(0)
            .Caption = "Código"
            .Key = "ccnumi"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With DgjSugerencia.RootTable.Columns(1)
            .Caption = ""
            .Key = "cccod"
            .Width = 10
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With DgjSugerencia.RootTable.Columns(2)
            .Caption = "Nombre"
            .Key = "ccdesc"
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With DgjSugerencia.RootTable.Columns(3)
            .Caption = "Dirección"
            .Key = "ccdirec"
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencia.RootTable.Columns(4)
            .Caption = "Teléfono 2"
            .Key = "cctelf1"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With DgjSugerencia.RootTable.Columns(5)
            .Caption = "Teléfono 1"
            .Key = "cctelf2"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencia.RootTable.Columns(6)
            .Caption = ""
            .Key = "numZona"
            .Width = 10
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With DgjSugerencia.RootTable.Columns(7)
            .Caption = "Zona"
            .Key = "descZona"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencia.RootTable.Columns(8)
            .Caption = ""
            .Key = "numDct"
            .Width = 10
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencia.RootTable.Columns(9)
            .Caption = "Tipo de Documento"
            .Key = "descDct"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencia.RootTable.Columns(10)
            .Caption = "Nro Documento"
            .Key = "ccdctnum"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencia.RootTable.Columns(11)
            .Caption = ""
            .Key = "numCat"
            .Width = 10
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencia.RootTable.Columns(12)
            .Caption = "Categoria"
            .Key = "descCat"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencia.RootTable.Columns(13)
            .Caption = "Estado"
            .Key = "ccest"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencia.RootTable.Columns(14)
            .Caption = "Latitud"
            .Key = "cclat"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencia.RootTable.Columns(15)
            .Caption = "Longitud"
            .Key = "cclongi"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencia.RootTable.Columns(16)
            .Caption = "Eventual"
            .Key = "cceven"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencia.RootTable.Columns(17)
            .Caption = "Observación"
            .Key = "ccobs"
            .Width = 250
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencia.RootTable.Columns(18)
            .Caption = "Fecha de Nac"
            .Key = "ccfnac"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencia.RootTable.Columns(19)
            .Caption = "Nombre Factura"
            .Key = "ccnomfac"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencia.RootTable.Columns(20)
            .Caption = "NIT"
            .Key = "ccnit"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencia.RootTable.Columns(21)
            .Caption = "Fecha de Ingreso"
            .Key = "ccfecing"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencia.RootTable.Columns(22)
            .Caption = "Fecha de Ultimo Pedido"
            .Key = "ccultped"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencia.RootTable.Columns(23)
            .Caption = "Fecha de Ultimo Venta"
            .Key = "ultven"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With DgjSugerencia.RootTable.Columns(24)
            .Caption = "Recorrido"
            .Key = "recven"
            .Width = 80
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With DgjSugerencia.RootTable.Columns(25)
            .Caption = ""
            .Key = "supven"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With DgjSugerencia.RootTable.Columns(26)
            .Caption = "Supervisor"
            .Key = "nsupven"
            .Width = 150
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With DgjSugerencia.RootTable.Columns(27)
            .Caption = ""
            .Key = "preven"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With DgjSugerencia.RootTable.Columns(28)
            .Caption = "Pre-Vendedor"
            .Key = "npreven"
            .Width = 150
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With DgjSugerencia.RootTable.Columns(29)
            .Caption = ""
            .Key = "fact"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencia.RootTable.Columns(30)
            .Caption = ""
            .Key = "hact"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With DgjSugerencia.RootTable.Columns(31)
            .Caption = ""
            .Key = "uact"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        'Habilitar Filtradores
        With DgjSugerencia
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
            .AlternatingColors = True
            .BringToFront()
            .Refresh()
        End With
    End Sub

    Private Sub TbNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TbNombre.KeyPress
        If (Not e.KeyChar = ChrW(Keys.Enter) And BoNuevo) Then
            DgjSugerencia.RemoveFilters()
            DgjSugerencia.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(DgjSugerencia.RootTable.Columns("ccdesc"), Janus.Windows.GridEX.ConditionOperator.Contains, TbNombre.Text))
        End If
    End Sub
    Private Sub _prCargarGridCategoria()
        Dim dtProductos As DataTable
        dtProductos = L_prTraerCategoriasPorClientesNuevo()
        Dim dtCategoria = L_prTraerCategoriasTodas()

        grCatProd.DataSource = dtProductos
        grCatProd.RetrieveStructure()
        With grCatProd.RootTable.Columns("cpnumi")
            .Visible = False
        End With

        With grCatProd.RootTable.Columns("cpcli")
            .Visible = False
        End With

        With grCatProd.RootTable.Columns("cpprod")
            .Visible = False
        End With

        With grCatProd.RootTable.Columns("cadesc")
            .Caption = "PRODUCTOS".ToUpper
            .Width = 220
            .AllowSort = False

        End With

        With grCatProd.RootTable.Columns("cicod")
            .Caption = "escuela".ToUpper
            .Width = 80
            .AllowSort = False
            .Visible = False
        End With

        With grCatProd.RootTable.Columns("cidesc")
            .Caption = "check".ToUpper
            .Width = 80
            .AllowSort = False
            .Visible = False
        End With

        With grCatProd.RootTable.Columns("cpcat")
            .Caption = "CATEGORIA"
            .HasValueList = True
            'Set EditType to Combo or DropDownList.
            'In a MultipleValues Column, the dropdown will appear with a CheckBox
            'at the left of each item to let the user select multiple items
            .EditType = EditType.DropDownList
            .ValueList.PopulateValueList(dtCategoria.DefaultView, "cinumi", "cicod")
            .CompareTarget = ColumnCompareTarget.Text
            .DefaultGroupInterval = GroupInterval.Text
            .AllowSort = False
        End With

        'Habilitar Filtradores
        With grCatProd
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With

        With grCatProd.RootTable.Columns("precio")
            .Caption = "PRECIO"
            .Width = 80
            .AllowSort = False
        End With

    End Sub

    Private Sub _prCargarGridCategoria(numi As String)
        Dim dtProductos As DataTable
        dtProductos = L_prTraerCategoriasPorClientes(numi)
        Dim dtCategoria = L_prTraerCategoriasTodas()

        grCatProd.DataSource = dtProductos
        grCatProd.RetrieveStructure()
        With grCatProd.RootTable.Columns("cpnumi")
            .Visible = False
        End With

        With grCatProd.RootTable.Columns("cpcli")
            .Visible = False
        End With

        With grCatProd.RootTable.Columns("cpprod")
            .Visible = False
        End With

        With grCatProd.RootTable.Columns("cadesc")
            .Caption = "PRODUCTOS".ToUpper
            .Width = 220
            .AllowSort = False

        End With

        With grCatProd.RootTable.Columns("cicod")
            .Caption = "escuela".ToUpper
            .Width = 80
            .AllowSort = False
            .Visible = False
        End With

        With grCatProd.RootTable.Columns("cidesc")
            .Caption = "check".ToUpper
            .Width = 80
            .AllowSort = False
            .Visible = False
        End With

        With grCatProd.RootTable.Columns("cpcat")
            .Caption = "CATEGORIA"
            .HasValueList = True
            .EditType = EditType.DropDownList
            .ValueList.PopulateValueList(dtCategoria.DefaultView, "cinumi", "cicod")
            .CompareTarget = ColumnCompareTarget.Text
            .DefaultGroupInterval = GroupInterval.Text
            .AllowSort = False
        End With

        'Habilitar Filtradores
        With grCatProd
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With
        With grCatProd.RootTable.Columns("precio")
            .Caption = "PRECIO"
            .Width = 80
            .AllowSort = False
        End With
    End Sub

    Private Sub P_prFiltrarCliente()
        DgjBusqueda.RemoveFilters()
        DgjBusqueda.MoveTo(DgjBusqueda.FilterRow)
        DgjBusqueda.Col = 2
        DgjBusqueda.Select()
        DgjBusqueda.Focus()
    End Sub

    Private Sub DgjBusqueda_DoubleClick(sender As Object, e As EventArgs) Handles DgjBusqueda.DoubleClick
        If (DgjBusqueda.Row > -1) Then
            MSuperTabControlPrincipal.SelectedTabIndex = 0
        End If
    End Sub

    Private Sub DgjBusqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles DgjBusqueda.KeyDown
        If (e.KeyData = Keys.Enter) Then
            MSuperTabControlPrincipal.SelectedTabIndex = 0
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub MSuperTabControlPrincipal_SelectedTabChanged(sender As Object, e As SuperTabStripSelectedTabChangedEventArgs) Handles MSuperTabControlPrincipal.SelectedTabChanged
        If (MSuperTabControlPrincipal.SelectedTabIndex = 1) Then
            P_prFiltrarCliente()
        End If
        If (MSuperTabControlPrincipal.SelectedTabIndex = 2) Then
            If (BoNuevo Or BoModificar) Then
                tbAcuCodCliente.Text = tbCodCliente.Text
                tbAcuNombre.Text = TbNombre.Text
            End If
        End If
    End Sub

    Private Sub tbLatitud_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbLatitud.KeyPress
        g_prValidarTextBox(3, e)
    End Sub

    Private Sub tbLongitud_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbLongitud.KeyPress
        g_prValidarTextBox(3, e)
    End Sub

    Private Sub GmUbicacionCliente_DoubleClick(sender As Object, e As EventArgs) Handles GmUbicacionCliente.DoubleClick
        If (MBtGrabar.Enabled) Then
            If (Not IsNothing(Overlay)) Then
                Overlay.Markers.Clear()

                Dim gm As GMapControl = CType(sender, GMapControl)
                Dim hj As MouseEventArgs = CType(e, MouseEventArgs)
                Dim plg As PointLatLng = gm.FromLocalToLatLng(hj.X, hj.Y)
                tbLatitud.Text = plg.Lat
                tbLongitud.Text = plg.Lng
                P_prAgregarPunto(plg)
                BtMarcarPunto.Visible = False
            End If
        End If
    End Sub

    Private Sub btZoomAcercar_Click(sender As Object, e As EventArgs) Handles btZoomAcercar.Click
        If (GmUbicacionCliente.Zoom <= GmUbicacionCliente.MaxZoom) Then
            GmUbicacionCliente.Zoom = GmUbicacionCliente.Zoom + 1
        End If
    End Sub

    Private Sub btZoomAlejar_Click(sender As Object, e As EventArgs) Handles btZoomAlejar.Click
        If (GmUbicacionCliente.Zoom >= GmUbicacionCliente.MinZoom) Then
            GmUbicacionCliente.Zoom = GmUbicacionCliente.Zoom - 1
        End If
    End Sub

    Private Sub DgjEquipo_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles DgjEquipo.CellEdited
        If (BoModificar) Then
            If (DgjEquipo.GetValue("estado") = 1) Then
                If (e.Column.Index >= DgjEquipo.RootTable.Columns("fec").Index And e.Column.Index <= DgjEquipo.RootTable.Columns("obs").Index) Then
                    DgjEquipo.SetValue("estado", 2)
                End If
            End If
        End If
    End Sub

    Private Sub P_prArmarComboSupervisor()
        Dim Dt As New DataTable

        Dt = L_fnObtenerTabla("cbnumi as [cod], cbdesc as [desc]", "TC002", "cbcat=2")
        g_prArmarCombo(cbSupervisor, Dt, 60, 200, "Código", "Supervisor")
    End Sub

    Private Sub P_prArmarComboPrevendedor()
        Dim Dt As New DataTable

        Dt = L_fnObtenerTabla("cbnumi as [cod], cbdesc as [desc]", "TC002", "cbcat=3")
        g_prArmarCombo(cbPrevendedor, Dt, 60, 200, "Código", "Pre-Vendedor")
    End Sub

    Private Sub P_prArmarComboTipoCredito()
        Dim dt As DataTable
        dt = L_fnObtenerTabla("cenum as [cod], cedesc as [desc]", "TC0051", "cecon=16")
        g_prArmarCombo(cbTipoCredito, dt, 60, 200, "Código", "Tipo Crédito")
    End Sub

    Private Sub tbRecorrido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbRecorrido.KeyPress
        g_prValidarTextBox(1, e)
    End Sub

    Private Sub BtConfirmar_Click(sender As Object, e As EventArgs) Handles BtConfirmar.Click
        If (TbCodigo.Text.Length > 0) Then
            L_GrabarModificarCliente(
                                "cceven = 0",
                                "ccnumi = " + TbCodigo.Text
                                )
            Dim fil As Integer = DgjBusqueda.Row
            BoNavegar = False
            P_prArmarGrillaBusqueda()
            BoNavegar = True
            DgjBusqueda.Row = fil
            'TODO lanzar un mensaje
        End If
    End Sub
    Public Function _fnObtenerDatatableClientes() As DataTable

        Dim dt As DataTable = CType(DgjBusqueda.DataSource, DataTable).Copy
        Dim aux As DataTable = dt.Copy

        dt.Clear()
        For i As Integer = 0 To DgjBusqueda.RowCount - 1 Step 1
            'a.ccnumi, a.cccod, a.ccdesc, a.ccdirec, a.cctelf1, a.cctelf2, a.cczona As numZona, d.cedesc As descZona, 
            '        a.ccdct as numDct, d2.cedesc As descDct, a.ccdctnum, a.cccat As numCat, b.cidesc As descCat, a.ccest,
            '        a.cclat, a.cclongi, a.cceven, a.ccobs, a.ccfnac, a.ccnomfac, a.ccnit, a.ccfecing, a.ccultped, a.ccultvent,
            '        a.ccrecven, a.ccsupven, e.cbdesc As nsupven, a.ccpreven, e2.cbdesc As npreven, 
            '        a.ccfact, a.cchact, a.ccuact

            Dim numi As Integer = DgjBusqueda.GetRow(i).Cells(0).Value
            Dim rows() As DataRow = aux.Select("ccnumi =" + Str(numi).Trim)
            dt.ImportRow(rows(0))


        Next
        Return dt
    End Function
    Private Sub MBtImprimir_Click(sender As Object, e As EventArgs) Handles MBtImprimir.Click
        Dim dt As DataTable = _fnObtenerDatatableClientes()
        P_prGenerarReporte(dt)
    End Sub
    Private Sub P_prGenerarReporte(dt As DataTable)


        If Not IsNothing(P_Global.Visualizador) Then
            P_Global.Visualizador.Close()
        End If

        P_Global.Visualizador = New Visualizador
        Dim objrep As New R_Clientes_R

        objrep.SetDataSource(dt)
        objrep.SetParameterValue("usuario", L_Usuario)
        P_Global.Visualizador.CRV1.ReportSource = objrep
        P_Global.Visualizador.Show()
        P_Global.Visualizador.BringToFront()
    End Sub

    Private Sub dgjDias_EditingCell(sender As Object, e As EditingCellEventArgs) Handles dgjDias.EditingCell
        If (BoNuevo Or BoModificar) Then
            If (e.Column.Key = "check") Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub dgjProducto_EditingCell(sender As Object, e As EditingCellEventArgs) Handles dgjProducto.EditingCell
        If (BoNuevo Or BoModificar) Then
            If (e.Column.Key = "ccabcant") Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItemEliminarProducto_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEliminarProducto.Click
        Dim fi As Integer = dgjProducto.Row
        If (fi > -1) Then
            If (BoNuevo Or BoModificar) Then
                dgjProducto.CurrentRow.EndEdit()
                dgjProducto.CurrentRow.Delete()
                dgjProducto.Refetch()
                dgjProducto.Refresh()
            End If
        End If
    End Sub

    Private Sub dgjProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles dgjProducto.KeyDown
        If (BoNuevo Or BoModificar) Then
            If (e.KeyData = Keys.Control + Keys.Enter) Then
                If (dgjProducto.CurrentRow.Cells("ccabprod").Value = 0) Then

                    Dim dt As DataTable
                    dt = L_fnObtenerTabla("a.canumi as numi, a.cadesc as [desc]",
                                          "TC001 a",
                                          "a.caserie=0 and caest=1 order by a.canumi asc")

                    Dim listEstCeldas As New List(Of Modelo.MCelda)
                    listEstCeldas.Add(New Modelo.MCelda("numi,", True, "Código", 80))
                    listEstCeldas.Add(New Modelo.MCelda("desc", True, "Descripción", 350))

                    Dim ef = New Efecto
                    ef.tipo = 3
                    ef.dt = dt
                    ef.SeleclCol = 2
                    ef.listEstCeldas = listEstCeldas
                    ef.alto = 200
                    ef.ancho = 100
                    ef.Context = "Seleccione Producto".ToUpper
                    ef.ShowDialog()
                    ef.StartPosition = FormStartPosition.CenterScreen
                    Dim bandera As Boolean = False
                    bandera = ef.band
                    If (bandera = True) Then
                        Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row

                        'dgjDetalle.SetValue("cprod", Row.Cells("numi").Value)
                        'dgjDetalle.SetValue("ncprod", Row.Cells("desc").Value)
                        dgjProducto.Col = dgjProducto.RootTable.Columns("ccabcant").Index
                        CType(dgjProducto.DataSource, DataTable).Rows(dgjProducto.Row).Item("ccabprod") = Row.Cells("numi").Value
                        CType(dgjProducto.DataSource, DataTable).Rows(dgjProducto.Row).Item("nprod") = Row.Cells("desc").Value
                        CType(dgjProducto.DataSource, DataTable).Rows(dgjProducto.Row).Item("estado") = 0

                        P_prAddFilaProducto()
                    End If
                Else
                    'Mensaje
                    ToastNotification.Show(Me, "Solo puede agregar productos, el cambio de producto no esta permitido.".ToUpper,
                                           My.Resources.WARNING,
                                           InDuracion * 1000,
                                           eToastGlowColor.Red,
                                           eToastPosition.TopCenter)
                End If
            End If
        End If
    End Sub

    Private Sub P_prAddFilaProducto()
        Try
            CType(dgjProducto.DataSource, DataTable).Rows.Add({0, 0, 0, "", 0, -1})
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgjProducto_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles dgjProducto.CellEdited
        If (BoNuevo Or BoModificar) Then
            If (e.Column.Key = "ccabcant" And dgjProducto.CurrentRow.Cells("estado").Value = 1) Then
                dgjProducto.CurrentRow.Cells("estado").Value = 2
            End If
        End If
    End Sub

    Private Sub cbFrecuencia_ValueChanged(sender As Object, e As EventArgs) Handles cbFrecuencia.ValueChanged
        If (BoNuevo Or BoModificar) Then
            If (cbFrecuencia.Value > 0) Then
                P_prArmarGrillaDias(IIf(TbCodigo.Text = String.Empty, "-1", TbCodigo.Text))
            End If
        End If
    End Sub

    Private Sub btActualizar_Click(sender As Object, e As EventArgs) Handles btActualizar.Click
        If (MBtGrabar.Enabled = False) Then
            Dim index As Integer = DgjBusqueda.Row
            BoNavegar = False
            P_prArmarGrillas()
            BoNavegar = True
            P_prActualizarPaginacion(index)
            P_prLlenarDatos(index)
        Else
            ToastNotification.Show(Me,
                                   "No se puede actualizar los datos cuando se esta haciendo un nuevo registro o modificación de registro.".ToUpper,
                                   My.Resources.WARNING,
                                   1000 * InDuracion,
                                   eToastGlowColor.Red,
                                   eToastPosition.TopCenter)
        End If
    End Sub

    Private Sub DgjSugerencia_FormattingRow(sender As Object, e As RowLoadEventArgs) Handles DgjSugerencia.FormattingRow

    End Sub

    Private Sub grCatProd_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles grCatProd.CellEdited

    End Sub

    Private Sub grCatProd_CellValueChanged(sender As Object, e As ColumnActionEventArgs) Handles grCatProd.CellValueChanged
        Dim p As Integer = grCatProd.GetValue("cpprod")
        Dim c As Integer = grCatProd.GetValue("cpcat")
        Dim dt As DataTable = L_prTraerPrecio(c, p)
        If dt.Rows.Count > 0 Then
            grCatProd.SetValue("precio", dt.Rows(0).Item(0))
        Else
            grCatProd.SetValue("precio", 0)
        End If
    End Sub
End Class