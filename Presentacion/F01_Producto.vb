Imports System.IO
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports Janus.Windows.GridEX
Imports Logica.AccesoLogica

Public Class F01_Producto

#Region "Atributos generales"

    Dim StTitulo As String = "P R O D U C T O"
    Dim InTipoForm As Byte = 1

    Private stCod As String = "0"

    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem
    Public Limpiar As Boolean = False  'Bandera para indicar si limpiar todos los datos o mantener datos ya registrados


#End Region

#Region "Propiedades generales"

    Public Property Titulo As String
        Get
            Return StTitulo
        End Get
        Set(value As String)
            StTitulo = value
        End Set
    End Property

    Public Property TipoForm As Byte
        Get
            Return InTipoForm
        End Get
        Set(value As Byte)
            InTipoForm = value
        End Set
    End Property

#End Region

#Region "Variables globales locales"
    Dim FtTitulo As Font = New Font("Arial", gi_fuenteTamano + 1)
    Dim FtNormal As Font = New Font("Arial", gi_fuenteTamano)

    Dim DtBusqueda As DataTable
    Dim StRutaImagenes = ""
    Dim vlImagen As CImagen = Nothing
    Dim mstream As MemoryStream
    Dim InDuracion As Byte = 5

    Dim BoNuevo As Boolean = False
    Dim BoModificar As Boolean = False
    Dim BoEliminar As Boolean = False
    Dim BoNavegar As Boolean = False

    Dim DaFecha As Date = Now.Date
#End Region

#Region "Eventos generales"

    Private Sub F01_Producto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub BtImage_Click(sender As Object, e As EventArgs) Handles BtImage.Click
        P_prCargarImagen(UcImagen)
    End Sub

#End Region

#Region "Metodos y funciones indispensables"

    Private Sub P_prInicio()
        'Abrir conexión
        If (Not gb_ConexionAbierta) Then
            L_prAbrirConexion()
        End If

        'Cargar variables locales
        StRutaImagenes = gs_CarpetaRaiz + "\Imagenes\" + IIf(TipoForm = 1, "Producto\", "Equipo\")

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
        P_PrArmarGrillas()
        P_prEliminarFotoSinReferencia(DtBusqueda, "nimg", StRutaImagenes)
        If (gi_ftp = 1) Then
            P_prDescargarFotosFTP(DtBusqueda, "nimg", StRutaImagenes)
        End If
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
        Me.Text = Titulo
        Me.WindowState = FormWindowState.Maximized

        'Visible
        MBtImprimir.Visible = False
        'GroupPanelDatosCompuesto.Visible = False
        BtImage.Visible = False
        SbEquipo.Visible = False
        LabelX7.Visible = False
        If (TipoForm = 2) Then
            lbCategoria.Visible = False
            CbCategoria.Visible = False
        End If

        'Enabled
        MBtGrabar.Enabled = False

        'ReadOnly
        TbCodigo.ReadOnly = True

        'Grid Busqueda
        DgjBusqueda.AllowEdit = InheritableBoolean.False

        'Botones
        BtImage.Image = My.Resources.imageDefault

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
        TbNombre.ReadOnly = Not flat
        TbNombreCorto.ReadOnly = Not flat
        CbCategoria.ReadOnly = Not flat
        CbEmpresa.ReadOnly = Not flat
        SbStock.IsReadOnly = Not flat
        SbEstado.IsReadOnly = Not flat
        SbEquipo.IsReadOnly = Not flat
        TbCodFlex.ReadOnly = Not flat
        tbCodBarra.ReadOnly = Not flat
        tbStockMinimo.IsInputReadOnly = Not flat
        cbgrupo1.ReadOnly = Not flat
        cbgrupo2.ReadOnly = Not flat
        cbgrupo3.ReadOnly = Not flat
        cbgrupo4.ReadOnly = Not flat
        cbUMed.ReadOnly = Not flat
        CbUnidVenta.ReadOnly = Not flat
        CbUnidMax.ReadOnly = Not flat
        TbConversion.IsInputReadOnly = Not flat

    End Sub

    Private Sub P_prLimpiar()
        TbCodigo.Clear()
        TbCodFlex.Clear()
        tbCodBarra.Clear()
        TbNombre.Clear()
        TbNombreCorto.Clear()
        CbCategoria.SelectedIndex = 0
        CbEmpresa.SelectedIndex = 0
        SbStock.Value = True
        SbEstado.Value = True
        SbEquipo.Value = False
        DaFecha = Now.Date

        If (Limpiar = False) Then
            _prSeleccionarCombo(cbgrupo1)
            _prSeleccionarCombo(cbgrupo2)
            _prSeleccionarCombo(cbgrupo3)
            _prSeleccionarCombo(cbgrupo4)
            _prSeleccionarCombo(cbUMed)
            _prSeleccionarCombo(CbUnidMax)
            _prSeleccionarCombo(CbUnidVenta)

            TbConversion.Value = 1
            tbStockMinimo.Value = 0
        End If

        UcImagen.Image = My.Resources.imageDefault
        MBtGrabar.Tooltip = "GRABAR"
    End Sub

    Private Sub P_prArmarCombos()
        P_prArmarComboCategoria()
        P_prArmarComboEmpresa()
        P_prArmarComboUnidVenta()
        P_prArmarComboUnidMax()

        '_prCargarComboLibreria(cbgrupo1, 101)
        P_prArmarComboProveedor()

        _prCargarComboLibreria(cbgrupo2, 102)
        _prCargarComboLibreria(cbgrupo3, 103)
        _prCargarComboLibreria(cbgrupo4, 104)
        _prCargarComboLibreria(cbUMed, 105)
        '_prCargarComboLibreria(cbUniVenta, 1, 6)
        '_prCargarComboLibreria(cbUnidMaxima, 1, 6)
    End Sub

    Private Sub P_PrArmarGrillas()
        P_prArmarGrillaBusqueda()
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
                    Me.stCod = .GetValue("cod").ToString
                    Me.TbCodFlex.Text = .GetValue("cod").ToString
                    Me.TbNombre.Text = .GetValue("desc").ToString
                    Me.TbNombreCorto.Text = .GetValue("desc2").ToString
                    Me.CbCategoria.Value = .GetValue("cat")
                    Me.SbStock.Value = .GetValue("stc")
                    Me.SbEstado.Value = .GetValue("est")
                    Me.SbEquipo.Value = .GetValue("serie")
                    Me.DaFecha = .GetValue("fing")
                    Me.CbEmpresa.Value = .GetValue("cemp")
                    'cacbarra, casmin, cagr1, cagr2, cagr3, cagr4, caumed, cauventa, caumax, caconv
                    Me.tbCodBarra.Text = .GetValue("cacbarra").ToString
                    Me.tbStockMinimo.Text = .GetValue("casmin")
                    Me.cbgrupo1.Value = .GetValue("cagr1")
                    Me.cbgrupo2.Value = .GetValue("cagr2")
                    Me.cbgrupo3.Value = .GetValue("cagr3")
                    Me.cbgrupo4.Value = .GetValue("cagr4")
                    Me.cbUMed.Value = .GetValue("caumed")
                    Me.CbUnidVenta.Value = .GetValue("cauventa")
                    Me.CbUnidMax.Value = .GetValue("caumax")
                    Me.TbConversion.Value = .GetValue("caconv")

                    Dim s As String = .GetValue("nimg").ToString
                    If (.GetValue("nimg").ToString.Equals("")) Then
                        UcImagen.Image = My.Resources.imageDefault
                        UcImagen.Tag = ""
                    Else
                        Dim rutaimg As String = StRutaImagenes + .GetValue("nimg").ToString
                        If (IO.File.Exists(rutaimg)) Then
                            UcImagen.Image = Image.FromFile(rutaimg)
                            UcImagen.Tag = .GetValue("nimg").ToString
                        Else
                            UcImagen.Image = My.Resources.imageDefault
                            UcImagen.Tag = ""
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
                DgjBusqueda.MoveTo(CInt(MLbPaginacion.Text.Trim.Split(" ")(1).Trim))
            End If
        End If
    End Sub

    Private Sub P_prNuevoRegistro()
        P_prLimpiar()
        P_prEstadoNueModEli(1)
        P_prHDComponentes(BoNuevo)
        TbNombre.Select()
    End Sub

    Private Sub P_prModificarRegistro()
        P_prEstadoNueModEli(2)
        P_prHDComponentes(BoModificar)
        TbNombre.SelectAll()
    End Sub

    Private Sub P_prEliminarRegistro()
        Dim numi As String = TbCodigo.Text 'Valor del código único
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper,
                                       eTaskDialogIcon.Delete, "advertencia".ToUpper,
                                       "Esta a punto de eliminar el producto con".ToUpper _
                                       + vbCrLf + "código -> ".ToUpper _
                                       + numi + " " + vbCrLf + "Desea continuar?".ToUpper,
                                       eTaskDialogButton.Yes Or eTaskDialogButton.Cancel,
                                       eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim resEliminar As Boolean = L_fnbValidarEliminacion(numi, "TC001", "canumi", mensajeError)
            If (resEliminar) Then
                Dim res As Boolean = L_fnProductoBorrar(numi) 'Medoto de lógica para eliminar
                If (res) Then
                    P_prGuardarImagen(True)
                    ToastNotification.Show(Me, "Codigo de producto: ".ToUpper + numi + " eliminado con Exito.".ToUpper,
                                           My.Resources.GRABACION_EXITOSA, InDuracion * 1000,
                                           eToastGlowColor.Green,
                                           eToastPosition.TopCenter)
                    BoNavegar = False
                    P_prArmarGrillaBusqueda()
                    BoNavegar = True
                    P_prMoverIndexActual()
                Else
                    ToastNotification.Show(Me, "No se pudo eliminar el producto con código: ".ToUpper + numi + ", intente nuevamente.".ToUpper,
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
        Dim desc2 As String
        Dim cat As String
        Dim img As String
        Dim stc As String
        Dim est As String
        Dim serie As String
        Dim pcom As String
        Dim fing As String
        Dim cemp As String
        Dim uact As String
        Dim barra As String
        Dim smin As String
        Dim gr1 As String
        Dim gr2 As String
        Dim gr3 As String
        Dim gr4 As String
        Dim umed As String
        Dim umin As String
        Dim umax As String
        Dim conv As Int32


        If (BoNuevo) Then
            If (P_fnValidarGrabacion()) Then
                numi = TbCodigo.Text.Trim
                cod = TbCodFlex.Text.Trim
                desc = TbNombre.Text.Trim
                desc2 = IIf(TbNombreCorto.Text.Trim.Equals(""), "", TbNombreCorto.Text.Trim)
                cat = CbCategoria.Value
                img = IIf(True, "IMG" + numi + ".JPG", "")
                stc = IIf(SbStock.Value, "1", "0")
                est = IIf(SbEstado.Value, "1", "0")
                serie = IIf(InTipoForm = 1, "0", "1")
                pcom = "0" 'Por apuro esta estatico
                fing = DaFecha.ToString("yyyy/MM/dd")
                cemp = CbEmpresa.Value.ToString
                uact = MTbUsuario.Text
                barra = tbCodBarra.Text
                smin = tbStockMinimo.Text
                gr1 = cbgrupo1.Value
                gr2 = cbgrupo2.Value
                gr3 = cbgrupo3.Value
                gr4 = cbgrupo4.Value
                umed = cbUMed.Value
                umin = CbUnidVenta.Value
                umax = CbUnidMax.Value
                If (TbConversion.Text.Trim = "") Then
                    conv = 0
                Else
                    conv = TbConversion.Text.Trim
                End If

                If (IsNothing(vlImagen) = True) Then
                    img = ""
                Else
                    img = P_fnObtenerID()
                End If

                'Grabar
                Dim res As Boolean = L_fnProductoGrabar(numi, cod, desc, desc2, cat, img, stc, est, serie, pcom, fing, cemp, barra, smin, gr1, gr2, gr3, gr4, umed, umin, umax, conv)

                If (res) Then
                    If (IsNothing(vlImagen) = False) Then
                        vlImagen.nombre = img
                        P_prGuardarImagen()
                    End If
                    P_prLimpiar()
                    BoNavegar = False
                    If (gi_ftp = 1) Then
                        P_prDescargarFotoFTP(img + ".jpg")
                        'P_prDescargarFotosFTP(DtBusqueda, "nimg", StRutaImagenes)
                    End If
                    P_prArmarGrillaBusqueda()
                    BoNavegar = True

                    TbNombre.Select()
                    ToastNotification.Show(Me, "Codigo de producto ".ToUpper + TbCodigo.Text + " Grabado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA,
                                       InDuracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
                Else
                    ToastNotification.Show(Me, "No se pudo grabar el codigo de producto ".ToUpper + TbCodigo.Text + ", intente nuevamente.".ToUpper,
                                       My.Resources.WARNING,
                                       InDuracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)
                End If
                vlImagen = Nothing
            End If
        ElseIf (BoModificar) Then
            If (P_fnValidarGrabacion()) Then
                numi = TbCodigo.Text.Trim
                cod = TbCodFlex.Text
                desc = TbNombre.Text.Trim
                desc2 = IIf(TbNombreCorto.Text.Trim.Equals(""), "", TbNombreCorto.Text.Trim)
                cat = CbCategoria.Value
                img = IIf(True, "IMG" + numi + ".JPG", "")
                stc = IIf(SbStock.Value, "1", "0")
                est = IIf(SbEstado.Value, "1", "0")
                serie = IIf(SbEquipo.Value, "1", "0")
                pcom = "0" 'Por apuro esta estatico
                fing = DaFecha.ToString("yyyy/MM/dd")
                cemp = CbEmpresa.Value.ToString
                uact = MTbUsuario.Text
                barra = tbCodBarra.Text
                smin = tbStockMinimo.Text
                gr1 = cbgrupo1.Value
                gr2 = cbgrupo2.Value
                gr3 = cbgrupo3.Value
                gr4 = cbgrupo4.Value
                umed = cbUMed.Value
                umin = CbUnidVenta.Value
                umax = CbUnidMax.Value

                If (TbConversion.Text.Trim = "") Then
                    conv = 0
                Else
                    conv = TbConversion.Text.Trim
                End If



                If (IsNothing(vlImagen) = True) Then
                    If (UcImagen.Tag.ToString = String.Empty) Then
                        img = ""
                    Else
                        Dim ini As Integer = UcImagen.Tag.ToString.Split("_")(0).Length + 1
                        img = UcImagen.Tag.ToString.Substring(ini, 15)
                    End If
                Else
                    img = P_fnObtenerID()
                End If

                'Grabar
                Dim res As Boolean = L_fnProductoModificar(numi, cod, desc, desc2, cat, img, stc, est, serie, pcom, fing, cemp, barra, smin, gr1, gr2, gr3, gr4, umed, umin, umax, conv)

                If (res) Then
                    If (IsNothing(vlImagen) = False) Then
                        vlImagen.nombre = img
                        P_prGuardarImagen()
                    End If
                    BoNavegar = False
                    If (gi_ftp = 1) Then
                        P_prDescargarFotoFTP(img + ".jpg")
                        'P_prDescargarFotosFTP(DtBusqueda, "nimg", StRutaImagenes)
                    End If
                    P_prArmarGrillaBusqueda()
                    BoNavegar = True

                    P_prMoverIndexActual()

                    TbNombre.Select()
                    MBtSalir.PerformClick()

                    ToastNotification.Show(Me, "Codigo de producto ".ToUpper + TbCodigo.Text + " Modificado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA,
                                       InDuracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
                Else
                    ToastNotification.Show(Me, "No se pudo modificar el codigo de producto ".ToUpper + TbCodigo.Text + ", intente nuevamente.".ToUpper,
                                       My.Resources.WARNING,
                                       InDuracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)
                End If
                vlImagen = Nothing
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

        MBtGrabar.Tooltip = IIf(value = 1, "GRABAR NUEVO REGISTRO", IIf(value = 2, "GRABAR MODIFICACIÓN DE REGISTRO", "GRABAR"))
        MRlAccion.Text = IIf(value = 1, "NUEVO", IIf(value = 2, "MODIFICAR", ""))

        'Compentes
        BtImage.Visible = (Not value = 4)
        Select Case value
            Case 1
                BtImage.Image = My.Resources.I512x512_image_add
            Case 2
                BtImage.Image = My.Resources.I512x512_image_update
            Case 3
                BtImage.Image = My.Resources.I512x512_image_remove
        End Select

    End Sub

    Private Sub P_prCargarImagen(pbimg As PictureBox)
        OfdProducto.InitialDirectory = "C:\Users\" + Environment.UserName + "\Pictures"
        OfdProducto.Filter = "Imagen|*.jpg;*.jpeg;*.png;*.bmp"
        OfdProducto.FilterIndex = 1
        If (OfdProducto.ShowDialog() = DialogResult.OK) Then
            vlImagen = New CImagen(OfdProducto.SafeFileName, OfdProducto.FileName, 0)
            pbimg.SizeMode = PictureBoxSizeMode.StretchImage
            pbimg.Load(vlImagen.getImagen())
        End If
    End Sub

    Private Sub P_prGuardarImagen()
        Dim rutaDestino As String = StRutaImagenes

        Dim rutaOrigen As String
        rutaOrigen = vlImagen.getImagen()

        If (gi_ftp = 1) Then
            Try


                Dim clsRequest As System.Net.FtpWebRequest
                Dim conexion As Net.Sockets.TcpClient
                clsRequest = DirectCast(System.Net.WebRequest.Create("ftp://" + gs_ftpIp + "/Disoft_Doc/Imagenes/" + IIf(TipoForm = 1, "Producto/", "Equipo/") + vlImagen.nombre + ".jpg"), System.Net.FtpWebRequest)
                clsRequest.Proxy = Nothing ' Esta asignación es importantisimo con los que trabajen en windows XP ya que por defecto esta propiedad esta para ser asignado a un servidor http lo cual ocacionaria un error si deseamos conectarnos con un FTP, en windows Vista y el Seven no tube este problema.sisacb
                clsRequest.Credentials = New System.Net.NetworkCredential(gs_ftpUsuario, gs_ftpPass) ' Usuario y password de acceso al server FTP, si no tubiese, dejar entre comillas, osea ""
                clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
                Try
                    Dim bFile() As Byte = System.IO.File.ReadAllBytes(rutaOrigen)
                    Dim clsStream As System.IO.Stream = clsRequest.GetRequestStream()
                    clsStream.Write(bFile, 0, bFile.Length)
                    clsStream.Close()
                    clsStream.Dispose()
                Catch ex As Exception
                    MsgBox(ex.Message + ". El Archivo no pudo ser enviado, intente en otro momento")
                End Try


                'My.Computer.Network.UploadFile(rutaOrigen,
                '                               "ftp://" + gs_ftpIp + "/Disoft_Doc/Imagenes/" + IIf(TipoForm = 1, "Producto/", "Equipo/") + vlImagen.nombre + ".jpg",
                '                               gs_ftpUsuario,
                '                               gs_ftpPass)
            Catch ex As Exception
                MsgBox("Error al conectarse al servidor FTP, Form Productos: " + ex.Message)
            End Try
        Else
            Dim finalImg As New Bitmap(UcImagen.Image, 300, 200)
            finalImg.Save(rutaDestino + vlImagen.nombre + ".jpg")
            'FileCopy(rutaOrigen, rutaDestino + vlImagen.nombre + ".jpg")
        End If
    End Sub

    Private Sub P_prPonerImagenDataSource(ByRef dt As DataTable, colJpg As String, colImg As String, ruta As String, Optional flag As Byte = 1)
        Dim rutaimg As String = ""
        For Each f As DataRow In dt.Rows
            'If (Not f.Item(colJpg).ToString = String.Empty) Then
            rutaimg = ruta + f.Item(colJpg).ToString
            f.Item(colImg) = P_fnBytesArchivo(rutaimg, 130, 80) '130=Ancho, 80=Alto
            mstream.Dispose()
            'End If
            rutaimg = ""
        Next
    End Sub

    Private Sub P_prPonerImagenDataSourceFila(ByRef dt As DataTable, colImg As String, ruta As String, filIndex As Integer)
        dt.Rows(filIndex).Item(colImg) = P_fnBytesArchivo(ruta, 130, 80) '130=Ancho, 80=Alto
        mstream.Dispose()
    End Sub

    Public Function P_fnBytesArchivo(ruta As String, ancho As Integer, alto As Integer) As Byte()
        If (IO.File.Exists(ruta)) Then
            mstream = New MemoryStream()
            Dim img0 As New Bitmap(ruta)
            Dim img As Bitmap = New Bitmap(img0, ancho, alto)
            img.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
            Return mstream.ToArray()
        Else
            mstream = New MemoryStream()
            Dim img As Bitmap = New Bitmap(My.Resources.imageDefault, ancho, alto)
            img.Save(mstream, Imaging.ImageFormat.Jpeg)
            Return mstream.ToArray()
            Throw New Exception("No se encuentra el archivo: " & ruta)
        End If
    End Function

    Private Function P_fnObtenerID() As String
        Dim res As String = ""
        res = res + Now.Hour.ToString("00") + Now.Minute.ToString("00") + Now.Second.ToString("00") + "_" _
            + Now.Day.ToString("00") + Now.Month.ToString("00") + Now.Year.ToString("0000")
        Return res
    End Function

    Private Sub P_prEliminarFotoSinReferencia(dt As DataTable, col As String, ruta As String)
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

    Private Sub P_prDescargarFotosFTP(dt As DataTable, col As String, ruta As String)
        Try
            If (My.Computer.FileSystem.GetFiles(ruta).Count > 0) Then
                For Each fil As DataRow In dt.Rows
                    If (Not fil.Item(col).ToString = String.Empty And
                        Not My.Computer.FileSystem.FileExists(ruta + fil.Item(col).ToString)) Then
                        P_prDescargarFotoFTP(fil.Item(col).ToString)
                    End If
                Next
            Else
                For Each fil As DataRow In dt.Rows
                    If (Not fil.Item(col).ToString = String.Empty) Then
                        P_prDescargarFotoFTP(fil.Item(col).ToString)
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub P_prDescargarFotoFTP(nomImg As String)
        'Descargar el archivo al servido ftp
        Try
            'Dim wrDownload As FtpWebRequest = WebRequest.Create("ftp://" + gs_ftpIp + "/Disoft_Doc/Imagenes/" + IIf(TipoForm = 1, "Producto/", "Equipo/") + nomImg)
            'wrDownload.Method = WebRequestMethods.Ftp.DownloadFile
            'wrDownload.Credentials = New NetworkCredential(gs_ftpUsuario, gs_ftpPass)
            'Dim rDownloadResponse As FtpWebResponse = wrDownload.GetResponse()
            'Dim strFileStream As Stream = rDownloadResponse.GetResponseStream()
            'Dim srFile As StreamReader = New StreamReader(strFileStream)

            'Dim bm As Bitmap = New System.Drawing.Bitmap(strFileStream)
            'bm.Save(StRutaImagenes + nomImg)

            Dim rutaOrigen As String = StRutaImagenes
            'Dim rutaOriginal As String = "ftp://" + gs_ftpIp + "/Disoft_Doc/Imagenes/" + IIf(TipoForm = 1, "Producto/", "Equipo/") + nomImg
            'Dim rutaOriginal As String = "http://190.180.84.22:8000/Disoft_Doc/Imagenes/Imagenes%20Categoria/094403_16112017.jpg"
            Dim rutaOriginal As String = "http://190.180.84.22:8000/Disoft_Doc/Imagenes/" + IIf(TipoForm = 1, "Producto/", "Equipo/") + nomImg

            Dim bm As Bitmap = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(rutaOriginal)))
            bm.Save(StRutaImagenes + nomImg)

            '    My.Computer.Network.DownloadFile("ftp://" + gs_ftpIp + "/Disoft_Doc/Imagenes/" + IIf(TipoForm = 1, "Producto/", "Equipo/") + nomImg,
            '                                     StRutaImagenes + nomImg,
            '                                     gs_ftpUsuario,
            '                                     gs_ftpPass)
        Catch ex As Exception
            MsgBox("Error al conectarse al servidor FTP, Form Producto: " + ex.Message)
        End Try
    End Sub

#End Region

#Region "Metodos y funciones generales"

    Private Sub P_prValidarCarpetaImagenes()
        Dim rutaDestino As String = StRutaImagenes
        If (System.IO.Directory.Exists(rutaDestino) = False) Then
            System.IO.Directory.CreateDirectory(rutaDestino)
        End If
    End Sub

    Private Sub P_prArmarComboCategoria()
        Dim Dt As DataTable
        Dt = L_fnObtenerCategoria()
        ''   Dt = L_fnObtenerLibreria("5", IIf(TipoForm = 1, "cenum>0", "cenum<0"))
        g_prArmarCombo(CbCategoria, Dt, 60, 200, "Código", "Categoría")
    End Sub

    Private Sub P_prArmarComboProveedor()
        Dim DtP As DataTable
        DtP = L_fnObtenerProveedor()

        g_prArmarCombo(cbgrupo1, DtP, 60, 200, "COD", "PROVEEDOR")
    End Sub
    Private Sub P_prArmarComboEmpresa()
        Dim Dt As DataTable

        Dt = L_fnObtenerTabla("scnumi as [cod], scneg as [desc]", "TS003", "1=1")
        g_prArmarCombo(CbEmpresa, Dt, 60, 200, "Código", "Empresa")
    End Sub

    Private Sub P_prArmarComboUnidVenta()
        Dim Dt As DataTable
        Dt = L_fnObtenerUnidad()
        ''   Dt = L_fnObtenerLibreria("5", IIf(TipoForm = 1, "cenum>0", "cenum<0"))
        g_prArmarCombo(CbUnidVenta, Dt, 60, 200, "Código", "Categoría")
    End Sub

    Private Sub P_prArmarComboUnidMax()
        Dim Dt As DataTable
        Dt = L_fnObtenerUnidad()
        ''   Dt = L_fnObtenerLibreria("5", IIf(TipoForm = 1, "cenum>0", "cenum<0"))
        g_prArmarCombo(CbUnidMax, Dt, 60, 200, "Código", "Categoría")
    End Sub

    Private Sub P_prArmarGrillaBusqueda()
        DtBusqueda = New DataTable
        DtBusqueda = L_fnProductoGeneral(InTipoForm.ToString)

        P_prPonerImagenDataSource(DtBusqueda, "nimg", "img", StRutaImagenes)

        'numi, cod, [desc], [desc2], cat, ncat, nimg, img, stc, est, serie, pcom, fing, fact, hact, uact

        DgjBusqueda.BoundMode = Janus.Data.BoundMode.Bound
        DgjBusqueda.DataSource = DtBusqueda
        DgjBusqueda.RetrieveStructure()

        'dar formato a las columnas
        With DgjBusqueda.RootTable.Columns(0)
            .Caption = "Código"
            .Key = "numi"
            .Width = 80
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(1)
            .Caption = "Cod.Flex"
            .Key = "cod"
            .Width = 80
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(2)
            .Caption = "Nombre"
            .Key = "desc"
            .Width = 350
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(3)
            .Caption = "Nombre Corto"
            .Key = "desc2"
            .Width = 200
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(4)
            .Caption = ""
            .Key = "cat"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(5)
            .Caption = "Categoría"
            .Key = "ncat"
            .Width = 120
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(6)
            .Caption = ""
            .Key = "nimg"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(7)
            .Caption = "Imagen"
            .Key = "img"
            .Width = 130
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(8)
            .Caption = "Stock"
            .Key = "stc"
            .Width = 80
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(9)
            .Caption = "Estado"
            .Key = "est"
            .Width = 80
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(10)
            .Caption = " Es Equipo?"
            .Key = "serie"
            .Width = 80
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(11)
            .Caption = ""
            .Key = "com"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(12)
            .Caption = ""
            .Key = "fing"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(13)
            .Caption = ""
            .Key = "cemp"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(14)
            .Caption = "EMPRESA"
            .Key = "ncemp"
            .Width = 150
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(15)
            .Caption = ""
            .Key = "fact"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(16)
            .Caption = ""
            .Key = "hact"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(17)
            .Caption = ""
            .Key = "uact"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(18)
            .Caption = ""
            .Key = "cacbarra"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(19)
            .Caption = ""
            .Key = "casmin"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(20)
            .Caption = ""
            .Key = "cagr1"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(21)
            .Caption = ""
            .Key = "cagr2"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(22)
            .Caption = ""
            .Key = "cagr3"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(23)
            .Caption = ""
            .Key = "cagr4"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(24)
            .Caption = ""
            .Key = "caumed"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(25)
            .Caption = ""
            .Key = "cauventa"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(26)
            .Caption = ""
            .Key = "caumax"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(27)
            .Caption = ""
            .Key = "caconv"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
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

    Private Function P_fnValidarGrabacion() As Boolean
        Dim res As Boolean = True
        MEP.Clear()

        If (TbNombre.Text = String.Empty) Then
            TbNombre.BackColor = Color.Red
            MEP.SetError(TbNombre, "ingrese el nombre del producto!".ToUpper)
            res = False
        Else
            TbNombre.BackColor = Color.White
            MEP.SetError(TbNombre, "")
        End If

        If (TbNombreCorto.Text = String.Empty) Then
            TbNombreCorto.BackColor = Color.Red
            MEP.SetError(TbNombreCorto, "ingrese el nombre corto del producto!".ToUpper)
            res = False
        Else
            TbNombreCorto.BackColor = Color.White
            MEP.SetError(TbNombreCorto, "")
        End If

        If (Not IsNumeric(CbCategoria.Value)) Then
            CbCategoria.BackColor = Color.Red
            MEP.SetError(CbCategoria, "Seleccione una categoria de producto!".ToUpper)
            res = False
        Else
            CbCategoria.BackColor = Color.White
            MEP.SetError(CbCategoria, "")
        End If

        If (Not IsNumeric(CbEmpresa.Value)) Then
            CbEmpresa.BackColor = Color.Red
            MEP.SetError(CbEmpresa, "Seleccione una empresa de producto!".ToUpper)
            res = False
        Else
            CbEmpresa.BackColor = Color.White
            MEP.SetError(CbCategoria, "")
        End If

        Return res
    End Function

    Private Sub P_prGuardarImagen(img As String)
        UcImagen.Image.Save(img, Drawing.Imaging.ImageFormat.Jpeg)
    End Sub

    Public Sub _prSeleccionarCombo(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
        If (CType(mCombo.DataSource, DataTable).Rows.Count > 0) Then
            mCombo.SelectedIndex = 0
        Else
            mCombo.SelectedIndex = -1
        End If
    End Sub
    Private Sub _prCargarComboLibreria(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo, cod1 As String)
        Dim dt As New DataTable
        dt = L_prLibreriaProductoGeneral(cod1)
        With mCombo
            .DropDownList.Columns.Clear()
            .DropDownList.Columns.Add("cenum").Width = 70
            .DropDownList.Columns("cenum").Caption = "COD"
            .DropDownList.Columns.Add("cedesc").Width = 200
            .DropDownList.Columns("cedesc").Caption = "DESCRIPCION"
            .ValueMember = "cenum"
            .DisplayMember = "cedesc"
            .DataSource = dt
            .Refresh()
        End With
    End Sub


    Private Sub btgrupo1_Click(sender As Object, e As EventArgs) Handles btgrupo1.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, "101", cbgrupo1.Text, "") Then
            _prCargarComboLibreria(cbgrupo1, "101")
            cbgrupo1.SelectedIndex = CType(cbgrupo1.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub btgrupo2_Click(sender As Object, e As EventArgs) Handles btgrupo2.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, "102", cbgrupo2.Text, "") Then
            _prCargarComboLibreria(cbgrupo2, "102")
            cbgrupo2.SelectedIndex = CType(cbgrupo2.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub btgrupo3_Click(sender As Object, e As EventArgs) Handles btgrupo3.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, "103", cbgrupo3.Text, "") Then
            _prCargarComboLibreria(cbgrupo3, "103")
            cbgrupo3.SelectedIndex = CType(cbgrupo3.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub btgrupo4_Click(sender As Object, e As EventArgs) Handles btgrupo4.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, "104", cbgrupo4.Text, "") Then
            _prCargarComboLibreria(cbgrupo4, "104")
            cbgrupo4.SelectedIndex = CType(cbgrupo4.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub btUMedida_Click(sender As Object, e As EventArgs) Handles btUMedida.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, "105", cbUMed.Text, "") Then
            _prCargarComboLibreria(cbUMed, "105")
            cbUMed.SelectedIndex = CType(cbUMed.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub
    Private Sub btUniVenta_Click(sender As Object, e As EventArgs) Handles btUniVenta.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, "106", CbUnidVenta.Text, "") Then
            _prCargarComboLibreria(CbUnidVenta, "106")
            _prCargarComboLibreria(CbUnidMax, "106")
            CbUnidVenta.SelectedIndex = CType(CbUnidVenta.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub
    Private Sub btUniMaxima_Click(sender As Object, e As EventArgs) Handles btUniMaxima.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, "106", CbUnidMax.Text, "") Then
            _prCargarComboLibreria(CbUnidMax, "106")
            _prCargarComboLibreria(CbUnidVenta, "106")
            CbUnidMax.SelectedIndex = CType(CbUnidMax.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub
    Private Sub cbgrupo1_ValueChanged(sender As Object, e As EventArgs) Handles cbgrupo1.ValueChanged
        'If cbgrupo1.SelectedIndex < 0 And cbgrupo1.Text <> String.Empty Then
        '    btgrupo1.Visible = True
        'Else
        '    btgrupo1.Visible = False
        'End If
    End Sub

    Private Sub cbgrupo2_ValueChanged(sender As Object, e As EventArgs) Handles cbgrupo2.ValueChanged
        If cbgrupo2.SelectedIndex < 0 And cbgrupo2.Text <> String.Empty Then
            btgrupo2.Visible = True
        Else
            btgrupo2.Visible = False
        End If
    End Sub

    Private Sub cbgrupo3_ValueChanged(sender As Object, e As EventArgs) Handles cbgrupo3.ValueChanged
        If cbgrupo3.SelectedIndex < 0 And cbgrupo3.Text <> String.Empty Then
            btgrupo3.Visible = True
        Else
            btgrupo3.Visible = False
        End If
    End Sub

    Private Sub cbgrupo4_ValueChanged(sender As Object, e As EventArgs) Handles cbgrupo4.ValueChanged
        If cbgrupo4.SelectedIndex < 0 And cbgrupo4.Text <> String.Empty Then
            btgrupo4.Visible = True
        Else
            btgrupo4.Visible = False
        End If
    End Sub

    Private Sub cbUMed_ValueChanged(sender As Object, e As EventArgs) Handles cbUMed.ValueChanged
        If cbUMed.SelectedIndex < 0 And cbUMed.Text <> String.Empty Then
            btUMedida.Visible = True
        Else
            btUMedida.Visible = False
        End If
    End Sub

    Private Sub CbUnidVenta_ValueChanged(sender As Object, e As EventArgs) Handles CbUnidVenta.ValueChanged
        If CbUnidVenta.SelectedIndex < 0 And CbUnidVenta.Text <> String.Empty Then
            btUniVenta.Visible = True
        Else
            btUniVenta.Visible = False
        End If
    End Sub

    Private Sub CbUnidMax_ValueChanged(sender As Object, e As EventArgs) Handles CbUnidMax.ValueChanged
        If CbUnidMax.SelectedIndex < 0 And CbUnidMax.Text <> String.Empty Then
            btUniMaxima.Visible = True
        Else
            btUniMaxima.Visible = False
        End If
    End Sub


#End Region
End Class