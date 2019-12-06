Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar.Controls


Public Class F02_Compra

#Region "Atributos generales"

    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

    Private boShow As Boolean = False
    Private boAdd As Boolean = False
    Private boModif As Boolean = False
    Private boDel As Boolean = False
    Public _detalleCompras As DataTable 'Almacena el detalle para insertar a la tabla TPA001 del BDDiconCF


#End Region

#Region "Propiedades generales"

#End Region

#Region "Variables globales locales"
    Dim FtTitulo As Font = New Font("Arial", gi_fuenteTamano + 1)
    Dim FtNormal As Font = New Font("Arial", gi_fuenteTamano)

    Dim DtBusqueda As DataTable
    Dim DtDetalle As DataTable
    Dim StRutaDocumentos = gs_CarpetaRaiz + "\Documentos\Compra\"
    Dim InDuracion As Byte = 5

    Dim BoNuevo As Boolean = False
    Dim BoModificar As Boolean = False
    Dim BoEliminar As Boolean = False
    Dim BoNavegar As Boolean = False

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
        If (dgjBusqueda.RowCount > 0) Then
            dgjBusqueda.MoveFirst()
        End If
    End Sub

    Private Sub MBtAnterior_Click(sender As Object, e As EventArgs) Handles MBtAnterior.Click
        If (dgjBusqueda.RowCount > 0) Then
            dgjBusqueda.MovePrevious()
        End If
    End Sub

    Private Sub MBtSiguiente_Click(sender As Object, e As EventArgs) Handles MBtSiguiente.Click
        If (dgjBusqueda.RowCount > 0) Then
            dgjBusqueda.MoveNext()
        End If
    End Sub

    Private Sub MBtUltimo_Click(sender As Object, e As EventArgs) Handles MBtUltimo.Click
        If (dgjBusqueda.RowCount > 0) Then
            dgjBusqueda.MoveLast()
        End If
    End Sub

    Private Sub DgjBusqueda_SelectionChanged(sender As Object, e As EventArgs) Handles dgjBusqueda.SelectionChanged
        If (dgjBusqueda.Row > -1 And (Not BoNuevo And Not BoModificar)) Then
            P_prLlenarDatos(dgjBusqueda.Row)
        End If
    End Sub

    Private Sub dgjBusqueda_DoubleClick(sender As Object, e As EventArgs) Handles dgjBusqueda.DoubleClick
        If (dgjBusqueda.Row > -1) Then
            MSuperTabControlPrincipal.SelectedTabIndex = 0
        End If
    End Sub

    Private Sub dgjBusqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles dgjBusqueda.KeyDown
        If (e.KeyData = Keys.Enter) Then
            MSuperTabControlPrincipal.SelectedTabIndex = 0
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub tbProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles tbProveedor.KeyDown
        If (BoNuevo Or BoModificar) Then
            If (e.KeyData = Keys.Control + Keys.Enter) Then
                P_prArmarAyudaProveedor()
            End If
        End If
    End Sub

    Private Sub btBuscarProveedor_Click(sender As Object, e As EventArgs) Handles btBuscarProveedor.Click
        P_prArmarAyudaProveedor()
    End Sub

    Private Sub tbNroFactura_KeyPress(sender As Object, e As KeyPressEventArgs)
        g_prValidarTextBox(1, e)
    End Sub

    Private Sub tbObs_Leave(sender As Object, e As EventArgs) Handles tbObs.Leave
        If (BoNuevo Or BoModificar) Then
            dgjDetalle.Select()
        End If
    End Sub

    Private Sub dgjDetalle_Enter(sender As Object, e As EventArgs) Handles dgjDetalle.Enter

        If (tbCodProveedor.Text = String.Empty) Then
            ToastNotification.Show(Me, "           Antes de Continuar Por favor Seleccione un Proveedor!!             ", My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)
            tbProveedor.Focus()
            Return
        End If
        dgjDetalle.Row = 0
        dgjDetalle.Col = dgjDetalle.RootTable.Columns("cabtc1numi").Index

    End Sub

    Private Sub dgjDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles dgjDetalle.KeyDown

        If (e.KeyData = Keys.Control + Keys.Enter) Then
            P_prArmarAyudaProducto()
        ElseIf (e.KeyData = Keys.Enter) Then
            Dim f, c As Integer
            c = dgjDetalle.Col
            f = dgjDetalle.Row

            'Pasar el foco a peso
            If (c = dgjDetalle.RootTable.Columns("cabtc1numi").Index) Then
                dgjDetalle.Row = f
                dgjDetalle.Col = c + 2
            End If
            If (c = dgjDetalle.RootTable.Columns("ntc1numi").Index) Then
                dgjDetalle.Row = f
                dgjDetalle.Col = c + 1
            End If
            If (c = dgjDetalle.RootTable.Columns("cabcant").Index) Then
                dgjDetalle.Row = f
                dgjDetalle.Col = c + 1
            End If
            If (c = dgjDetalle.RootTable.Columns("cabpcom").Index) Then
                If (dgjDetalle.Row = dgjDetalle.RowCount - 1) Then
                    P_prAddFilaDetalle()
                End If
                dgjDetalle.Row = f + 1
                dgjDetalle.Col = dgjDetalle.RootTable.Columns("ntc1numi").Index
                P_prArmarAyudaProducto()
            End If
        End If
    End Sub
    Public Sub _prCalcularPrecioTotal()
        ''Agregado para que Muestre el Subtotal de la compra
        'tbSubtotalC.Value = dgjDetalle.GetTotal(dgjDetalle.RootTable.Columns("cabtot"), AggregateFunction.Sum)
        tbSubtotalC.Value = dgjDetalle.GetTotal(dgjDetalle.RootTable.Columns("cabsubtot"), AggregateFunction.Sum)

        'Dim montodesc As Double = tbMdesc.Value
        Dim montodesc As Double = dgjDetalle.GetTotal(dgjDetalle.RootTable.Columns("cabdesc"), AggregateFunction.Sum)

        tbMdesc.Value = montodesc

        ' tbtotal.Value = dgjDetalle.GetTotal(dgjDetalle.RootTable.Columns("cabtot"), AggregateFunction.Sum) - montodesc
        tbtotal.Value = dgjDetalle.GetTotal(dgjDetalle.RootTable.Columns("cabsubtot"), AggregateFunction.Sum) - montodesc

    End Sub
    Private Sub dgjDetalle_EditingCell(sender As Object, e As EditingCellEventArgs) Handles dgjDetalle.EditingCell
        If (BoNuevo Or BoModificar) Then
            If (e.Column.Key.Equals("cabcant") Or e.Column.Key.Equals("cabpcom") Or e.Column.Key.Equals("cabporc") Or e.Column.Key.Equals("cabdesc")) Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub dgjDetalle_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles dgjDetalle.CellEdited
        If (BoModificar Or BoNuevo) Then
            If ((e.Column.Key.Equals("cabcant")) Or (e.Column.Key.Equals("cabpcom"))) Then
                'If (e.Column.Key.Equals("cabcant")) Then
                '    'dgjDetalle.SetValue("total", dgjDetalle.GetValue("cabcant") * dgjDetalle.GetValue("cabpcom"))
                '    dgjDetalle.SetValue("cabsubtot", dgjDetalle.GetValue("cabcant") * dgjDetalle.GetValue("cabpcom"))
                'End If

                'If (e.Column.Key.Equals("cabpcom")) Then
                '    'dgjDetalle.SetValue("total", dgjDetalle.GetValue("cabcant") * dgjDetalle.GetValue("cabpcom"))
                '    dgjDetalle.SetValue("cabsubtot", dgjDetalle.GetValue("cabcant") * dgjDetalle.GetValue("cabpcom"))
                'End If

                If (dgjDetalle.GetValue("cabtca1numi") <> 0) Then
                    dgjDetalle.SetValue("estado", 2)
                End If
            End If
        End If
    End Sub

    Private Sub tsmiEliminarFilaDetalle_Click(sender As Object, e As EventArgs) Handles tsmiEliminarFilaDetalle.Click
        Try
            dgjDetalle.CurrentRow.EndEdit()
            dgjDetalle.CurrentRow.Delete()
            dgjDetalle.Refetch()
            dgjDetalle.Refresh()
            _prCalcularPrecioTotal()
        Catch ex As Exception
            'sms
            'MsgBox(ex)
        End Try
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
        Me.Text = "C O M P R A"
        Me.WindowState = FormWindowState.Maximized

        'Tab
        MSuperTabControlPrincipal.SelectedTabIndex = 0

        'Visible
        MBtImprimir.Visible = False
        tsmiEliminarFilaDetalle.Visible = False
        tbCodProveedor.Visible = False

        'Enabled
        MBtGrabar.Enabled = False

        'ReadOnly
        tbCodigo.ReadOnly = True
        tbProveedor.ReadOnly = True

        'Grid Busqueda
        dgjBusqueda.AllowEdit = Janus.Data.InheritableBoolean.False

        'Botones

        'Funciones
        P_prCambiarFuenteComponentes()
        P_prAsignarPermisos()

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

        If (dtRolUsu.Count = 1) Then
            boShow = dtRolUsu(0).Item("ycshow")
            boAdd = dtRolUsu(0).Item("ycadd")
            boModif = dtRolUsu(0).Item("ycmod")
            boDel = dtRolUsu(0).Item("ycdel")
        End If

        If boAdd = False Then
            MBtNuevo.Visible = False
        End If
        If boModif = False Then
            MBtModificar.Visible = False
        End If
        If boDel = False Then
            MBtEliminar.Visible = False
        End If

    End Sub

    Private Sub P_prHDComponentes(ByVal flat As Boolean)
        'TextBox
        'tbProveedor.ReadOnly = Not flat
        tbNroFactura.ReadOnly = Not flat
        tbObs.ReadOnly = Not flat
        tbNitProv.ReadOnly = Not flat
        tbNAutorizacion.ReadOnly = Not flat
        tbCodControl.ReadOnly = Not flat
        tbNDui.ReadOnly = Not flat
        tbSACF.ReadOnly = Not flat

        tbMdesc.IsInputReadOnly = Not flat

        If MBtNuevo.Enabled = True Then
            tbSubtotalC.IsInputReadOnly = Not flat
            tbtotal.IsInputReadOnly = Not flat
        Else
            tbSubtotalC.IsInputReadOnly = flat
            tbtotal.IsInputReadOnly = flat
        End If

        'ComboBox

        'DateTimer
        dtiFechaCompra.IsInputReadOnly = Not flat
        dtiFechaCompra.ButtonDropDown.Enabled = flat

        'Button
        btBuscarProveedor.Enabled = flat

        'Switch Button
        swTipoVenta.IsReadOnly = Not flat
        swEmision.IsReadOnly = Not flat
        swConsigna.IsReadOnly = Not flat
        swRetencion.IsReadOnly = Not flat
        'Radio Button

        'Grillas
        dgjDetalle.AllowEdit = IIf(flat, 1, 2)
    End Sub

    Private Sub P_prLimpiar()
        'TextBox
        tbCodigo.Clear()
        tbCodProveedor.Clear()
        tbProveedor.Clear()
        tbNroFactura.Text = "0"
        tbObs.Clear()
        tbNitProv.Clear()
        swEmision.Value = True
        swConsigna.Value = False
        swRetencion.Value = False
        swTipoVenta.Value = False
        tbFechaVenc.Value = Now.Date
        tbNroFactura.Clear()
        tbNAutorizacion.Clear()
        tbCodControl.Clear()
        tbNDui.Clear()
        tbSACF.Clear()


        tbMdesc.Value = 0
        tbtotal.Value = 0
        tbSubtotalC.Value = 0


        'ComboBox

        'DateTimer
        dtiFechaCompra.Value = Now.Date

        'Switch Button

        'Radio Button

        'Grillas
        P_prArmarGrillaDetalle("-1")

        MBtGrabar.Tooltip = "GRABAR"
    End Sub

    Private Sub P_prArmarCombos()

    End Sub

    Private Sub P_prArmarGrillas()
        P_prArmarGrillaBusqueda()
        P_prArmarGrillaDetalle("-1")
    End Sub

    Private Sub P_prActualizarPaginacion(ByVal index As Integer)
        MLbPaginacion.Text = "Reg. " & index + 1 & " de " & dgjBusqueda.GetRows.Count
    End Sub

    Private Sub P_prMoverIndexActual()
        Dim index As Integer = CInt(MLbPaginacion.Text.Trim.Split(" ")(1).Trim)
        If (index < 0) Then
            index = 0
        End If
        If (index > dgjBusqueda.RowCount) Then
            index = dgjBusqueda.RowCount
        End If
        dgjBusqueda.MoveTo(index - 1)
        P_prLlenarDatos(dgjBusqueda.Row)
    End Sub

    Private Sub P_prLlenarDatos(ByVal index As Integer)
        If (index <= dgjBusqueda.GetRows.Count - 1 And index >= 0) Then
            If (BoNavegar) Then
                With dgjBusqueda
                    Me.tbCodigo.Text = .GetValue("caanumi").ToString
                    Me.dtiFechaCompra.Value = .GetValue("caafdoc")
                    Me.tbCodProveedor.Text = .GetValue("caaprov").ToString
                    Me.tbProveedor.Text = .GetValue("nprov").ToString
                    Me.tbNroFactura.Text = .GetValue("caanfac").ToString
                    Me.tbObs.Text = .GetValue("caaobs").ToString
                    Me.tbNitProv.Text = .GetValue("cmnit").ToString
                    Me.swTipoVenta.Value = .GetValue("caatven")
                    Me.tbFechaVenc.Value = .GetValue("caafvcred").ToString
                    Me.swEmision.Value = .GetValue("caaemision")
                    Me.swConsigna.Value = .GetValue("caaconsigna")
                    'a.caatven, a.caafvcred, a.caamon, a.caaest, a.caadesc, a.caatotal, a.caaemision, a.caaconsigna
                    'Aqui se coloca los datos de la grilla de los Equipos
                    P_prArmarGrillaDetalle(tbCodigo.Text)

                    MLbFecha.Text = CType(.GetValue("caafact").ToString, Date).ToString("dd/MM/yyyy")
                    MLbHora.Text = .GetValue("caahact").ToString
                    MLbUsuario.Text = .GetValue("caauact").ToString
                End With

                tbMdesc.Value = dgjBusqueda.GetValue("caadesc")
                _prCalcularPrecioTotal()
                If swEmision.Value = True Then
                    _prCargarFacturacion(tbCodigo.Text)
                End If

                P_prActualizarPaginacion(dgjBusqueda.Row)

                If (Not boModif And boAdd) Then
                    If (Now.Date = Me.dtiFechaCompra.Value) Then
                        MBtModificar.Visible = True
                    Else
                        MBtModificar.Visible = False
                    End If
                End If
            End If
        Else
            If (dgjBusqueda.GetRows.Count > 0) Then
                P_prMoverIndexActual()
            End If
        End If
    End Sub
    Private Sub _prCargarFacturacion(_numi As String)
        Dim dtC As New DataTable
        dtC = L_prCompraComprobanteGeneralPorNumi(_numi)

        If dtC.Rows.Count = 0 Then
            tbNAutorizacion.Text = ""
            tbCodControl.Text = ""
            tbNDui.Text = ""
            tbSACF.Text = ""
        Else
            tbNAutorizacion.Text = dtC.Rows(0).Item("fcaautoriz")
            tbCodControl.Text = dtC.Rows(0).Item("fcaccont")
            tbNDui.Text = dtC.Rows(0).Item("fcandui")
            tbSACF.Text = tbtotal.Text - dtC.Rows(0).Item("fcanscf")
        End If

    End Sub

    Private Sub P_prNuevoRegistro()
        P_prLimpiar()
        P_prEstadoNueModEli(1)
        P_prHDComponentes(BoNuevo)
        P_prAddFilaDetalle()
        dtiFechaCompra.Select()
    End Sub

    Private Sub P_prModificarRegistro()
        P_prEstadoNueModEli(2)
        P_prHDComponentes(BoModificar)
        P_prAddFilaDetalle()
        dtiFechaCompra.Select()
    End Sub

    Private Sub P_prEliminarRegistro()
        Dim numi As String = tbCodigo.Text 'Valor del código único
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper,
                                       eTaskDialogIcon.Delete, "advertencia".ToUpper,
                                       "Esta a punto de eliminar la compra con".ToUpper _
                                       + vbCrLf + "código -> ".ToUpper _
                                       + numi + " " + vbCrLf + "Desea continuar?".ToUpper,
                                       eTaskDialogButton.Yes Or eTaskDialogButton.Cancel,
                                       eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim resEliminar As Boolean = L_fnbValidarEliminacion(numi, "TCA001", "caanumi", mensajeError)
            If (resEliminar) Then
                Dim res As Boolean = L_fnCompraEliminar(numi) 'Medoto de lógica para eliminar
                If (res) Then
                    ToastNotification.Show(Me, "Codigo de compra: ".ToUpper + numi + " eliminado con Exito.".ToUpper,
                                           My.Resources.GRABACION_EXITOSA, InDuracion * 1000,
                                           eToastGlowColor.Green,
                                           eToastPosition.TopCenter)
                    BoNavegar = False
                    P_prArmarGrillaBusqueda()
                    BoNavegar = True
                    P_prMoverIndexActual()
                Else
                    ToastNotification.Show(Me, "No se pudo eliminar la compra con código: ".ToUpper + numi + ", intente nuevamente.".ToUpper,
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
        Dim fdoc As String
        Dim prov As String
        Dim nfac As String
        Dim obs As String
        Dim tven As String
        Dim fvcred As String
        Dim mon As String
        Dim desc As Double
        Dim total As Double
        Dim emision As String
        Dim consigna As String
        Dim retencion As String
        Dim asiento As String


        If (BoNuevo) Then
            If (P_fnValidarGrabacion()) Then

                numi = tbCodigo.Text.Trim
                fdoc = dtiFechaCompra.Value.ToString("yyyy/MM/dd")
                prov = tbCodProveedor.Text.Trim
                nfac = IIf(tbNroFactura.Text.Trim = String.Empty, "0", tbNroFactura.Text.Trim)
                obs = tbObs.Text.Trim
                tven = IIf(swTipoVenta.Value = True, 1, 0)
                fvcred = IIf(swTipoVenta.Value = True, Now.Date.ToString("yyyy/MM/dd"), tbFechaVenc.Value.ToString("yyyy/MM/dd"))
                mon = 1
                desc = tbMdesc.Value
                total = tbtotal.Value
                emision = IIf(swEmision.Value = True, 1, 0)
                consigna = IIf(swConsigna.Value = True, 1, 0)
                retencion = IIf(swRetencion.Value = True, 1, 0)
                asiento = IIf(swAsiento.Value = True, 1, 0)

                dtiFechaCompra.Select()

                Dim dt As DataTable = CType(dgjDetalle.DataSource, DataTable).DefaultView.ToTable(False, "cabnumi", "cabtc1numi", "cabcant", "cabpcom", "cabsubtot", "cabporc", "cabdesc", "cabtot", "cabputi", "cabpven", "cabnfr", "cabstocka", "cabstockf", "cabtca1numi", "estado")

                RecuperarDatosTFC001()  'Recupera datos para grabar en la BDDiconCF en la Tabla TFC001
                'Grabar
                Dim res As Boolean = L_fnCompraGrabar(numi, fdoc, prov, nfac, obs, dt, tven, fvcred, mon, desc, total, emision, consigna, retencion, asiento, _detalleCompras)


                If (res) Then
                    P_prLimpiar()
                    BoNavegar = False
                    P_prArmarGrillaBusqueda()
                    BoNavegar = True

                    dtiFechaCompra.Select()
                    ToastNotification.Show(Me, "Codigo de compra ".ToUpper + tbCodigo.Text + " Grabado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA,
                                       InDuracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
                Else
                    ToastNotification.Show(Me, "No se pudo grabar el codigo de compra ".ToUpper + tbCodigo.Text + ", intente nuevamente.".ToUpper,
                                       My.Resources.WARNING,
                                       InDuracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)
                End If
            End If
        ElseIf (BoModificar) Then
            If (P_fnValidarGrabacion()) Then
                numi = tbCodigo.Text.Trim
                fdoc = dtiFechaCompra.Value.ToString("yyyy/MM/dd")
                prov = tbCodProveedor.Text.Trim
                nfac = IIf(tbNroFactura.Text.Trim = String.Empty, "0", tbNroFactura.Text.Trim)
                obs = tbObs.Text.Trim

                dtiFechaCompra.Select()

                Dim dt As DataTable = CType(dgjDetalle.DataSource, DataTable).DefaultView.ToTable(False, "cabnumi", "cabtc1numi", "cabcant", "cabpcom", "cabputi", "cabpven", "cabnfr", "cabstocka", "cabstockf", "cabtca1numi", "estado")

                'Grabar
                Dim res As Boolean = L_fnCompraModificar(numi, fdoc, prov, nfac, obs, dt)

                If (res) Then

                    BoNavegar = False
                    P_prArmarGrillaBusqueda()
                    BoNavegar = True

                    P_prMoverIndexActual()

                    dtiFechaCompra.Select()
                    MBtSalir.PerformClick()

                    ToastNotification.Show(Me, "Codigo de compra ".ToUpper + tbCodigo.Text + " Modificado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA,
                                       InDuracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
                Else
                    ToastNotification.Show(Me, "No se pudo modificar el codigo de compra ".ToUpper + tbCodigo.Text + ", intente nuevamente.".ToUpper,
                                       My.Resources.WARNING,
                                       InDuracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)
                End If
            End If
        End If
    End Sub

    Public Sub RecuperarDatosTFC001()
        _detalleCompras = L_prCompraComprobanteGeneralPorNumi(-1)
        '_ValidarDatosFacturacion()
        Dim ffec As String
        Dim fnit As String
        Dim frsocial As String
        Dim fnro As String
        Dim fndui As String
        Dim fautoriz As String
        Dim fmonto As String
        Dim fccont As String
        Dim sujetoCreditoFiscal As String
        Dim nosujetoCreditoFiscal As String
        Dim subTotal As String
        Dim fdesc As String
        Dim importeBaseCreditoFiscal As String
        Dim creditoFiscal As String

        If swEmision.Value = True Then
            ffec = dtiFechaCompra.Value.ToString("yyyy/MM/dd")
            fnit = tbNitProv.Text
            frsocial = tbProveedor.Text
            fnro = tbNroFactura.Text
            If tbNDui.Text = String.Empty Then
                tbNDui.Text = 0
            End If
            fndui = tbNDui.Text

            fautoriz = tbNAutorizacion.Text
            fmonto = tbtotal.Value.ToString + tbMdesc.Value
            sujetoCreditoFiscal = tbSACF.Text
            nosujetoCreditoFiscal = tbtotal.Value.ToString - sujetoCreditoFiscal
            subTotal = fmonto - nosujetoCreditoFiscal
            fdesc = tbMdesc.Value.ToString
            'tbImporteBaseCreditoFiscal.Value = TbSubTotal.Value - TbdDescuento.Value
            importeBaseCreditoFiscal = fmonto - fdesc
            creditoFiscal = importeBaseCreditoFiscal * 0.13
            fccont = tbCodControl.Text
            Dim numi As String = ""

            _detalleCompras.Rows.Add(1, ffec, fnit, frsocial, fnro, fndui, fautoriz, fmonto, nosujetoCreditoFiscal, subTotal, fdesc, importeBaseCreditoFiscal, creditoFiscal, fccont, 1, 0, 0)

        Else
            ffec = dtiFechaCompra.Value.ToString("yyyy/MM/dd")
            fnit = tbNitProv.Text
            frsocial = tbProveedor.Text
            fnro = tbNroFactura.Text
            fndui = 0
            fautoriz = 0
            fmonto = tbtotal.Value.ToString
            sujetoCreditoFiscal = tbSACF.Text
            nosujetoCreditoFiscal = 0
            subTotal = fmonto
            fdesc = tbMdesc.Value.ToString
            importeBaseCreditoFiscal = fmonto - fdesc
            creditoFiscal = 0
            fccont = 0
            Dim numi As String = ""

            _detalleCompras.Rows.Add(1, ffec, fnit, frsocial, fnro, fndui, fautoriz, fmonto, nosujetoCreditoFiscal, subTotal, fdesc, importeBaseCreditoFiscal, creditoFiscal, fccont, 1, 0, 0)

        End If

    End Sub
    Private Sub P_prCancelarRegistro()
        If (Not MBtGrabar.Enabled) Then
            Me.Close()
            If (gb_ConexionAbierta) Then
                _modulo.Select()
                _tab.Close()
            End If
        Else
            P_prLimpiar()
            P_prHDComponentes(False)
            P_prLlenarDatos(dgjBusqueda.Row)
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

        tsmiEliminarFilaDetalle.Visible = Not (value = 4)

        MBtGrabar.Tooltip = IIf(value = 1, "GRABAR NUEVO REGISTRO", IIf(value = 2, "GRABAR MODIFICACIÓN DE REGISTRO", "GRABAR"))
        MRlAccion.Text = IIf(value = 1, "NUEVO", IIf(value = 2, "MODIFICAR", ""))

        'Compentes

        If (MSuperTabControlPrincipal.SelectedTabIndex = 1) Then
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
        'Try
        '    For Each foundFile As String In My.Computer.FileSystem.GetFiles(ruta)
        '        Dim split As String() = foundFile.Split("\")
        '        Dim nomImg As String = split(split.Length - 1)
        '        Dim array As DataRow() = dt.Select(col + "='" + nomImg + "'")
        '        If (array.Length = 0) Then
        '            My.Computer.FileSystem.DeleteFile(ruta + "\" + nomImg, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        '        End If
        '    Next
        'Catch ex As Exception

        'End Try
    End Sub

#End Region

#Region "Metodos y funciones generales"

    Private Sub P_prValidarCarpetaImagenes()
        Dim rutaDestino As String = StRutaDocumentos
        If (System.IO.Directory.Exists(rutaDestino) = False) Then
            System.IO.Directory.CreateDirectory(rutaDestino)
        End If
    End Sub

    Private Sub P_prArmarGrillaBusqueda()
        DtBusqueda = New DataTable
        DtBusqueda = L_fnCompraGeneral()

        dgjBusqueda.BoundMode = Janus.Data.BoundMode.Bound
        dgjBusqueda.DataSource = DtBusqueda
        dgjBusqueda.RetrieveStructure()

        'dar formato a las columnas
        With dgjBusqueda.RootTable.Columns("caanumi")
            .Caption = "Código"
            .Width = 80
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With dgjBusqueda.RootTable.Columns("caafdoc")
            .Caption = "Fecha"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With dgjBusqueda.RootTable.Columns("caaprov")
            .Visible = False
        End With

        With dgjBusqueda.RootTable.Columns("nprov")
            .Caption = "Proveedor"
            .Width = 200
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With
        With dgjBusqueda.RootTable.Columns("cmnit")
            .Visible = False
        End With
        With dgjBusqueda.RootTable.Columns("caanfac")
            .Caption = "Nro Factura"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With dgjBusqueda.RootTable.Columns("caaobs")
            .Caption = "Observación"
            .Width = 300
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With dgjBusqueda.RootTable.Columns("caafact")
            .Visible = False
        End With

        With dgjBusqueda.RootTable.Columns("caahact")
            .Visible = False
        End With
        With dgjBusqueda.RootTable.Columns("caauact")
            .Visible = False
        End With
        With dgjBusqueda.RootTable.Columns("caatven")
            .Visible = False
        End With
        With dgjBusqueda.RootTable.Columns("caafvcred")
            .Visible = False
        End With
        With dgjBusqueda.RootTable.Columns("caamon")
            .Visible = False
        End With
        With dgjBusqueda.RootTable.Columns("caaest")
            .Visible = False
        End With
        With dgjBusqueda.RootTable.Columns("caadesc")
            .Visible = False
        End With
        With dgjBusqueda.RootTable.Columns("caatotal")
            .Caption = "Total"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            .FormatString = "0.00"
        End With
        With dgjBusqueda.RootTable.Columns("caaemision")
            .Visible = False
        End With
        With dgjBusqueda.RootTable.Columns("caaconsigna")
            .Visible = False
        End With

        'Habilitar Filtradores
        With dgjBusqueda
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

    Private Sub P_prArmarGrillaDetalle(numi As String)
        DtDetalle = New DataTable
        DtDetalle = L_fnCompraDetalle(numi)

        dgjDetalle.BoundMode = Janus.Data.BoundMode.Bound
        dgjDetalle.DataSource = DtDetalle
        dgjDetalle.RetrieveStructure()

        'dar formato a las columnas
        With dgjDetalle.RootTable.Columns("cabnumi")
            .Visible = False
        End With

        With dgjDetalle.RootTable.Columns("cabtc1numi")
            .Caption = "Cod. Producto"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With dgjDetalle.RootTable.Columns("cacod")
            .Caption = "Codigo Flex"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With dgjDetalle.RootTable.Columns("ntc1numi")
            .Caption = "Descripción Producto"
            .Width = 350
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With dgjDetalle.RootTable.Columns("cabcant")
            .Caption = "Cantidad"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
            .FormatString = "0.00"
        End With

        With dgjDetalle.RootTable.Columns("cabpcom")
            .Caption = "Precio Costo"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
            .FormatString = "0.00"
        End With

        With dgjDetalle.RootTable.Columns("cabputi")
            .Caption = "% Utilidad"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
            .FormatString = "0.00"
        End With

        With dgjDetalle.RootTable.Columns("cabpven")
            .Caption = "Precio Venta"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
            .FormatString = "0.00"
        End With

        With dgjDetalle.RootTable.Columns("cabnfr")
            .Caption = "Nro. Factura/Recibo"
            .Width = 120
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
            .FormatString = "0"
        End With

        With dgjDetalle.RootTable.Columns("cabstocka")
            .Caption = "Stock Actual"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
            .FormatString = "0.00"
        End With

        With dgjDetalle.RootTable.Columns("cabstockf")
            .Caption = "Stock Final"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
            .FormatString = "0.00"
        End With

        With dgjDetalle.RootTable.Columns("cabtca1numi")
            .Visible = False
        End With

        With dgjDetalle.RootTable.Columns("total")
            .Caption = "Total"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
            '.CellStyle.BackColor = Color.AliceBlue
            .FormatString = "0.00"
            .AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
            .TotalFormatString = "0.00"
        End With
        With dgjDetalle.RootTable.Columns("cabsubtot")
            .Caption = "Sub Total"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            .FormatString = "0.00"
            .AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
            .TotalFormatString = "0.00"
        End With
        With dgjDetalle.RootTable.Columns("cabporc")
            .Caption = "Desc. (%)"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
            .FormatString = "0.00"
            .AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
            .TotalFormatString = "0.00"
        End With
        With dgjDetalle.RootTable.Columns("cabdesc")
            .Caption = "Desc. (Bs)"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
            .FormatString = "0.00"
            .AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
            .TotalFormatString = "0.00"
        End With
        With dgjDetalle.RootTable.Columns("cabtot")
            .Caption = "Total"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
            .FormatString = "0.00"
            .AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
            .TotalFormatString = "0.00"
        End With

        With dgjDetalle.RootTable.Columns("estado")
            .Visible = False
        End With

        'Habilitar Filtradores
        With dgjDetalle
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
            .TotalRow = Janus.Windows.GridEX.InheritableBoolean.True
            .TotalRowPosition = TotalRowPosition.BottomFixed
            .TotalRowFormatStyle.BackColor = Color.Yellow

        End With
    End Sub

    Private Function P_fnValidarGrabacion() As Boolean
        Dim sms As String = ""

        If (Not IsDate(dtiFechaCompra.Value)) Then
            sms = "elija una fecha de compra valida."
        End If

        If (tbProveedor.Text.Trim = String.Empty) Then
            If (sms = String.Empty) Then
                sms = "el proveedor no puede quedar vacio."
            Else
                sms = sms + vbCrLf + "el proveedor no puede quedar vacio."
            End If
        End If
        If swEmision.Value = True Then
            If (tbNroFactura.Text = String.Empty) Then
                If (sms = String.Empty) Then
                    sms = "Debe llenar el número de factura."
                Else
                    sms = sms + vbCrLf + "Debe llenar el número de factura."
                End If
                tbNroFactura.Focus()
            End If
            If (tbNAutorizacion.Text = String.Empty) Then
                If (sms = String.Empty) Then
                    sms = "Debe llenar el número de autorización."
                Else
                    sms = sms + vbCrLf + "Debe llenar el número de autorización."
                End If
                tbNAutorizacion.Focus()
            End If
            If (tbCodControl.Text = String.Empty) Then
                If (sms = String.Empty) Then
                    sms = "Debe llenar el código de control."
                Else
                    sms = sms + vbCrLf + "Debe llenar el código de control."
                End If
                tbCodControl.Focus()
            End If
        Else
            If (tbNroFactura.Text = String.Empty) Then
                If (sms = String.Empty) Then
                    sms = "Debe llenar el número de recibo."
                Else
                    sms = sms + vbCrLf + "Debe llenar el número de recibo."
                End If
                tbNroFactura.Focus()
            End If
        End If

        If (Not sms = String.Empty) Then
            ToastNotification.Show(Me,
                                   sms.ToUpper,
                                   My.Resources.INFORMATION,
                                   InDuracion * 1000,
                                   eToastGlowColor.Red,
                                   eToastPosition.TopCenter)
        End If


        Return (sms = String.Empty)
    End Function

    Private Sub P_prArmarAyudaProveedor()
        Dim frmAyuda As Modelo.ModeloAyuda
        Dim dt As DataTable = L_fnObtenerTabla("cmnumi, cmdesc, cmnit", "TC010", "cmest=1")
        Dim listEstCeldas As New List(Of Modelo.MCelda)
        listEstCeldas.Add(New Modelo.MCelda("cmnumi", True, "Código", 70))
        listEstCeldas.Add(New Modelo.MCelda("cmdesc", True, "Proveedor", 280))
        listEstCeldas.Add(New Modelo.MCelda("cmnit", False, "Proveedor", 100))

        frmAyuda = New Modelo.ModeloAyuda(300, 360, dt, "Seleccionar proveedor".ToUpper, listEstCeldas)
        frmAyuda.StartPosition = FormStartPosition.CenterScreen
        frmAyuda.ShowDialog()

        If frmAyuda.seleccionado = True Then
            Dim id As String = frmAyuda.filaSelect.Cells("cmnumi").Value
            Dim desc As String = frmAyuda.filaSelect.Cells("cmdesc").Value
            Dim nit As String = frmAyuda.filaSelect.Cells("cmnit").Value
            tbCodProveedor.Text = id
            tbProveedor.Text = desc
            tbNitProv.Text = nit
        End If
    End Sub

    Private Sub P_prArmarAyudaProducto()
        Dim frmAyuda As Modelo.ModeloAyuda

        'Dim dt As DataTable = L_ProductosGeneral(1, "caest=1 and caserie=0").Tables(0)
        Dim dt As DataTable = L_ProductosGeneral(1, "caest=1 and caserie=0 and cagr1= " + tbCodProveedor.Text + " ").Tables(0)

        Dim listEstCeldas As New List(Of Modelo.MCelda)
        listEstCeldas.Add(New Modelo.MCelda("canumi", True, "Código", 80))
        listEstCeldas.Add(New Modelo.MCelda("cacod", True, "Cod Flex", 100))
        listEstCeldas.Add(New Modelo.MCelda("cadesc", True, "Producto", 300))
        listEstCeldas.Add(New Modelo.MCelda("cadesc2", True, "Desc", 150))

        frmAyuda = New Modelo.ModeloAyuda(600, 540, dt, "Seleccione Producto".ToUpper, listEstCeldas)
        frmAyuda.StartPosition = FormStartPosition.CenterScreen
        frmAyuda.ShowDialog()

        If frmAyuda.seleccionado = True Then
            Dim id As String = frmAyuda.filaSelect.Cells("canumi").Value
            Dim cod As String = frmAyuda.filaSelect.Cells("cacod").Value
            Dim desc As String = frmAyuda.filaSelect.Cells("cadesc").Value

            dgjDetalle.Col = dgjDetalle.RootTable.Columns("cabcant").Index
            dgjDetalle.SetValue(1, id)
            dgjDetalle.SetValue(2, cod)
            dgjDetalle.SetValue(3, desc)
            '_prCalcularPrecioTotal()
        End If
    End Sub

    Private Sub P_prAddFilaDetalle()
        Dim f As DataRow
        f = DtDetalle.NewRow

        f.Item("cabnumi") = DtDetalle.Rows.Count + 1
        f.Item("cabtc1numi") = 0
        f.Item("ntc1numi") = ""
        f.Item("cabcant") = 0
        f.Item("cabpcom") = 0
        f.Item("cabputi") = 0
        f.Item("cabpven") = 0
        f.Item("cabnfr") = "0"
        f.Item("cabstocka") = 0
        f.Item("cabstockf") = 0
        f.Item("cabtca1numi") = 0
        f.Item("total") = 0
        f.Item("cabsubtot") = 0
        f.Item("cabporc") = 0
        f.Item("cabdesc") = 0
        f.Item("cabtot") = 0
        f.Item("estado") = 0

        DtDetalle.Rows.Add(f)
    End Sub

    Private Sub tbNroFactura_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles tbNroFactura.KeyPress
        g_prValidarTextBox(1, e)
    End Sub

    Private Sub tbNAutorizacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbNAutorizacion.KeyPress
        g_prValidarTextBox(1, e)
    End Sub

    Private Sub tbNDui_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbNDui.KeyPress
        g_prValidarTextBox(1, e)
    End Sub

    Private Sub tbSACF_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbSACF.KeyPress
        g_prValidarTextBox(1, e)
    End Sub

    Private Sub swEmision_ValueChanged(sender As Object, e As EventArgs) Handles swEmision.ValueChanged
        If swEmision.Value = False Then
            lbNFactura.Text = "Nro. Recibo:"
            GroupPanelFactura2.Text = "DATOS RECIBO"
            lbNAutoriz.Visible = False
            tbNAutorizacion.Visible = False
            lbCodCtrl.Visible = False
            tbCodControl.Visible = False
            lbNDui.Visible = False
            tbNDui.Visible = False
            lbSACF.Visible = False
            tbSACF.Visible = False
        Else
            lbNFactura.Text = "Nro. Factura:"
            GroupPanelFactura2.Text = "DATOS FACTURACIÓN"
            lbNAutoriz.Visible = True
            tbNAutorizacion.Visible = True
            lbCodCtrl.Visible = True
            tbCodControl.Visible = True
            lbNDui.Visible = True
            tbNDui.Visible = True
            lbSACF.Visible = True
            tbSACF.Visible = True

        End If
    End Sub


    Private Sub swTipoVenta_ValueChanged(sender As Object, e As EventArgs) Handles swTipoVenta.ValueChanged
        If (swTipoVenta.Value = False) Then
            lbCredito.Visible = True
            tbFechaVenc.Visible = True
            tbFechaVenc.Value = Now.Date
        Else
            lbCredito.Visible = False
            tbFechaVenc.Visible = False
        End If
    End Sub

    Private Sub tbtotal_ValueChanged(sender As Object, e As EventArgs) Handles tbtotal.ValueChanged
        tbSACF.Text = tbtotal.Text
    End Sub

    Private Sub dgjDetalle_CellValueChanged(sender As Object, e As ColumnActionEventArgs) Handles dgjDetalle.CellValueChanged
        If (BoModificar Or BoNuevo) Then
            If ((e.Column.Key.Equals("cabcant")) Or (e.Column.Key.Equals("cabpcom"))) Then
                Dim lin As Integer = dgjDetalle.GetValue("cabnumi")
                Dim pos As Integer = -1
                _fnObtenerFilaDetalle(pos, lin)
                If (e.Column.Key.Equals("cabcant")) Then
                    'dgjDetalle.SetValue("total", dgjDetalle.GetValue("cabcant") * dgjDetalle.GetValue("cabpcom"))

                    dgjDetalle.SetValue("cabsubtot", dgjDetalle.GetValue("cabcant") * dgjDetalle.GetValue("cabpcom"))

                    'CType(dgjBusqueda.DataSource, DataTable).Rows(5).Item("total") = dgjDetalle.GetValue("cabcant") * dgjDetalle.GetValue("cabpcom")
                    '_prCalcularPrecioTotal()

                End If

                If (e.Column.Key.Equals("cabpcom")) Then
                    If (Not IsNumeric(dgjDetalle.GetValue("cabpcom")) Or dgjDetalle.GetValue("cabpcom").ToString = String.Empty) Then
                        Dim cantidad As Double = dgjDetalle.GetValue("cabcant")
                        CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabpcom") = CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabpcom")
                        'CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cbptot") = cantidad * CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cbpcost")


                    Else
                        'dgjDetalle.SetValue("total", dgjDetalle.GetValue("cabcant") * dgjDetalle.GetValue("cabpcom"))

                        dgjDetalle.SetValue("cabsubtot", dgjDetalle.GetValue("cabcant") * dgjDetalle.GetValue("cabpcom"))

                        Dim porcdesc As Double = dgjDetalle.GetValue("cabporc")
                        Dim montodesc As Double = ((dgjDetalle.GetValue("cabpcom") * dgjDetalle.GetValue("cabcant")) * (porcdesc / 100))


                        Dim totalF As Double = dgjDetalle.GetValue("cabsubtot") - montodesc
                        CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabtot") = totalF
                        CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabsubtot") = dgjDetalle.GetValue("cabsubtot")
                        CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabdesc") = montodesc

                        dgjDetalle.SetValue("cabdesc", montodesc)
                        dgjDetalle.SetValue("cabtot", totalF)


                        'Dim total As Double = dgjDetalle.GetValue("total")
                        'Dim total As Double = dgjDetalle.GetValue("cabtot")
                        _prCalcularPrecioTotal()
                        'tbSubtotalC.Text = tbSubtotalC.Value + total
                        'tbtotal.Text = tbSubtotalC.Text
                    End If

                    If (dgjDetalle.GetValue("cabtca1numi") <> 0) Then
                        dgjDetalle.SetValue("estado", 2)
                    End If
                End If
            End If


            '''''''''''''''''''''PORCENTAJE DE DESCUENTO '''''''''''''''''''''
            If (e.Column.Index = dgjDetalle.RootTable.Columns("cabporc").Index) Then
                If (Not IsNumeric(dgjDetalle.GetValue("cabporc")) Or dgjDetalle.GetValue("cabporc").ToString = String.Empty) Then
                    Dim lin As Integer = dgjDetalle.GetValue("cabnumi")
                    Dim pos As Integer = -1
                    _fnObtenerFilaDetalle(pos, lin)
                    CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabporc") = 0
                    CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabdesc") = 0
                    CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabtot") = CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabsubtot")
                Else
                    If (dgjDetalle.GetValue("cabporc") > 0 And dgjDetalle.GetValue("cabporc") <= 100) Then

                        Dim porcdesc As Double = dgjDetalle.GetValue("cabporc")
                        Dim montodesc As Double = (dgjDetalle.GetValue("cabsubtot") * (porcdesc / 100))
                        Dim lin As Integer = dgjDetalle.GetValue("cabnumi")
                        Dim pos As Integer = -1
                        _fnObtenerFilaDetalle(pos, lin)
                        CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabdesc") = montodesc


                        Dim totalF As Double = dgjDetalle.GetValue("cabsubtot") - montodesc

                        dgjDetalle.SetValue("cabdesc", montodesc)
                        dgjDetalle.SetValue("cabtot", totalF)
                        CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabtot") = totalF
                        CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabsubtot") = dgjDetalle.GetValue("cabsubtot")



                        'Dim total As Double = dgjDetalle.GetValue("total")
                        'Dim total As Double = dgjDetalle.GetValue("cabtot")
                        _prCalcularPrecioTotal()
                        'tbSubtotalC.Text = tbSubtotalC.Value + total
                        'tbtotal.Text = tbSubtotalC.Text
                    Else
                        Dim lin As Integer = dgjDetalle.GetValue("cabnumi")
                        Dim pos As Integer = -1
                        _fnObtenerFilaDetalle(pos, lin)
                        CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabporc") = 0
                        CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabdesc") = 0
                        CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabtot") = CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabsubtot")
                        dgjDetalle.SetValue("cabporc", 0)
                        dgjDetalle.SetValue("cabdesc", 0)
                        dgjDetalle.SetValue("cabtot", dgjDetalle.GetValue("cabsubtot"))
                        _prCalcularPrecioTotal()
                    End If
                End If
            End If

            '''''''''''''''''''''MONTO DE DESCUENTO '''''''''''''''''''''
            If (e.Column.Index = dgjDetalle.RootTable.Columns("cabdesc").Index) Then
                If (Not IsNumeric(dgjDetalle.GetValue("cabdesc")) Or dgjDetalle.GetValue("cabdesc").ToString = String.Empty) Then

                    Dim lin As Integer = dgjDetalle.GetValue("cabnumi")
                    Dim pos As Integer = -1
                    _fnObtenerFilaDetalle(pos, lin)
                    CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabporc") = 0
                    CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabdesc") = 0
                    CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabtot") = CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabsubtot")
                Else
                    If (dgjDetalle.GetValue("cabdesc") > 0 And dgjDetalle.GetValue("cabdesc") <= dgjDetalle.GetValue("cabsubtot")) Then

                        Dim montodesc As Double = dgjDetalle.GetValue("cabdesc")
                        Dim pordesc As Double = ((montodesc * 100) / dgjDetalle.GetValue("cabsubtot"))

                        Dim lin As Integer = dgjDetalle.GetValue("cabnumi")
                        Dim pos As Integer = -1
                        _fnObtenerFilaDetalle(pos, lin)
                        CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabdesc") = montodesc
                        CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabporc") = pordesc

                        dgjDetalle.SetValue("cabporc", pordesc)

                        Dim totalF As Double = dgjDetalle.GetValue("cabsubtot") - montodesc

                        dgjDetalle.SetValue("cabdesc", montodesc)
                        dgjDetalle.SetValue("cabtot", totalF)
                        CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabtot") = totalF
                        CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabsubtot") = dgjDetalle.GetValue("cabsubtot")

                        'Dim total As Double = dgjDetalle.GetValue("total")
                        'Dim total As Double = dgjDetalle.GetValue("cabtot")
                        _prCalcularPrecioTotal()
                        'tbSubtotalC.Text = tbSubtotalC.Value + total
                        'tbtotal.Text = tbSubtotalC.Text

                    Else
                        Dim lin As Integer = dgjDetalle.GetValue("cabnumi")
                        Dim pos As Integer = -1
                        _fnObtenerFilaDetalle(pos, lin)
                        CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabporc") = 0
                        CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabdesc") = 0
                        CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabtot") = CType(dgjDetalle.DataSource, DataTable).Rows(pos).Item("cabsubtot")
                        dgjDetalle.SetValue("cabporc", 0)
                        dgjDetalle.SetValue("cabdesc", 0)
                        dgjDetalle.SetValue("cabtot", dgjDetalle.GetValue("cabsubtot"))
                        _prCalcularPrecioTotal()


                    End If
                End If
            End If



        End If
    End Sub
    Public Sub _fnObtenerFilaDetalle(ByRef pos As Integer, numi As Integer)
        For i As Integer = 0 To CType(dgjDetalle.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim _numi As Integer = CType(dgjDetalle.DataSource, DataTable).Rows(i).Item("cabnumi")
            If (_numi = numi) Then
                pos = i
                Return
            End If
        Next

    End Sub

    Private Sub tbMdesc_ValueChanged(sender As Object, e As EventArgs) Handles tbMdesc.ValueChanged
        If (tbMdesc.Focused) Then

            Dim total As Double = tbtotal.Value
            If (Not tbMdesc.Text = String.Empty And Not tbMdesc.Text = String.Empty) Then
                If (tbMdesc.Value = 0 Or tbMdesc.Value > total) Then
                    tbMdesc.Value = 0
                    _prCalcularPrecioTotal()
                Else

                    Dim montodesc As Double = tbMdesc.Value
                    'tbtotal.Value = dgjDetalle.GetTotal(dgjDetalle.RootTable.Columns("cabtot"), AggregateFunction.Sum) - montodesc
                    tbtotal.Value = dgjDetalle.GetTotal(dgjDetalle.RootTable.Columns("cabsubtot"), AggregateFunction.Sum) - montodesc

                End If

            End If

            If (tbMdesc.Text = String.Empty) Then
                tbMdesc.Value = 0

            End If
        End If

    End Sub











#End Region

End Class