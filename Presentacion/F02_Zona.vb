Imports Logica.AccesoLogica
Imports GMap.NET.MapProviders
Imports GMap.NET
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.WindowsForms.ToolTips
Imports DevComponents.DotNetBar
Imports System.IO
Imports Janus.Data
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar.Controls

Public Class F02_Zona

#Region "Atributos generales"

    Dim StTitulo As String = "Z O N A S"

    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

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

#End Region

#Region "Variables globales locales"
    Dim FtTitulo As Font = New Font("Arial", gi_fuenteTamano + 1)
    Dim FtNormal As Font = New Font("Arial", gi_fuenteTamano)

    Dim DtBusqueda As DataTable
    Dim InDuracion As Byte = 5

    Dim BoNuevo As Boolean = False
    Dim BoModificar As Boolean = False
    Dim BoEliminar As Boolean = False
    Dim BoNavegar As Boolean = False

    Dim _poligono As Integer
    Dim _listPuntos As List(Of PointLatLng)
    Dim _overlay As GMapOverlay
#End Region

#Region "Eventos generales"

    Private Sub prLoad(sender As Object, e As EventArgs) Handles MyBase.Load
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
        P_PrArmarGrillas()
        BoNavegar = True

        P_prActualizarPaginacion(0)
        P_prLlenarDatos(0)
    End Sub

    Private Function P_fnValidarRequisitos() As String
        Dim sms As String = ""

        'Crea la carpeta de imagenes si es que no estuviera creada.
        'P_prValidarCarpetaImagenes()

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
        Me.MSuperTabControlPrincipal.SelectedTabIndex = 1

        'Visializacion del mapa
        If (gb_mostrarMapa = False) Then
            GmMapa.Visible = False
            PanelExZoom.Visible = False
        End If

        'Visible
        MBtImprimir.Visible = False
        BtAddCiudad.Visible = False
        BtAddProvincia.Visible = False
        BtAddZona.Visible = False

        'Enabled
        MBtGrabar.Enabled = False

        'ReadOnly
        TbCodigo.ReadOnly = True
        TbColor.ReadOnly = True

        'Grid Busqueda
        DgjBusqueda.AllowEdit = Janus.Data.InheritableBoolean.False

        'Botones
        BtMarcarZona.Text = "Marcar Zona"

        'Funciones
        P_prAsignarPermisos()
        P_prCambiarFuenteComponentes()

        'Mapa
        _poligono = 0
        _listPuntos = New List(Of PointLatLng)
        _overlay = New GMapOverlay("polygons")
        GmMapa.Overlays.Add(_overlay)

        P_prCargarMapa()

        'Usuario del sistema
        MTbUsuario.Text = gs_user

        'Super Tab's
        SuperTabControlPersonal.SelectedTabIndex = 0
    End Sub

    Private Sub P_prCambiarFuenteComponentes()
        Dim xCtrl As Control
        For Each xCtrl In TableLayoutPanelBase.Controls
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
        BtMarcarZona.Enabled = flat

        CbCiudad.ReadOnly = Not flat
        CbProvincia.ReadOnly = Not flat
        CbZona.ReadOnly = Not flat

        dgjRepartidor.AllowEdit = IIf(flat, 1, 2)
        dgjPrevendedor.AllowEdit = IIf(flat, 1, 2)
    End Sub

    Private Sub P_prLimpiar()
        TbCodigo.Clear()
        TbColor.Clear()

        CbCiudad.SelectedIndex = 0
        CbProvincia.SelectedIndex = 0
        CbZona.SelectedIndex = 0

        _listPuntos.Clear()
        _overlay.Polygons.Clear()
        _overlay.Markers.Clear()

        P_prArmarGrillaRepartidor()
        P_prArmarGrillaPrevendedor()
        P_prLimpiarErrores()

        _poligono = 0
        _listPuntos = New List(Of PointLatLng)
        _overlay = New GMapOverlay("polygons")
        GmMapa.Overlays.Add(_overlay)

        BtMarcarZona.Text = "Marcar Zona"
        MBtGrabar.Tooltip = "GRABAR"
    End Sub

    Private Sub P_prArmarCombos()
        P_prArmarComboCiudad()
        P_prArmarComboProvincia()
        P_prArmarComboZona()
    End Sub

    Private Sub P_PrArmarGrillas()
        P_prArmarGrillaBusqueda()
        P_prArmarGrillaRepartidor()
        P_prArmarGrillaPrevendedor()
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
                    Me.CbCiudad.Clear()
                    Me.CbCiudad.SelectedText = .GetValue("ncity").ToString
                    Me.CbProvincia.Clear()
                    Me.CbProvincia.SelectedText = .GetValue("nprov").ToString
                    Me.CbZona.Clear()
                    Me.CbZona.SelectedText = .GetValue("nzona").ToString

                    MLbFecha.Text = CType(.GetValue("fact").ToString, Date).ToString("dd/MM/yyyy")
                    MLbHora.Text = .GetValue("hact").ToString
                    MLbUsuario.Text = .GetValue("uact").ToString
                End With

                Dim tPuntos As DataTable = L_ZonaDetallePuntos_General(-1, TbCodigo.Text).Tables(0)
                Dim i As Integer
                Dim lati, longi As Double
                _listPuntos.Clear()
                For i = 0 To tPuntos.Rows.Count - 1
                    lati = tPuntos.Rows(i).Item(1)
                    longi = tPuntos.Rows(i).Item(2)
                    Dim plg As PointLatLng = New PointLatLng(lati, longi)
                    _listPuntos.Add(plg)
                Next

                If (GmMapa.Visible) Then 'AUMENTADO PARA QUE SI ESTA VISIBLE EL MAPA DIBUJE LA ZONA
                    If tPuntos.Rows.Count > 0 Then
                        'posicionar en la zona
                        Dim latiZona, longiZona As Double
                        latiZona = tPuntos.Rows(0).Item(1)
                        longiZona = tPuntos.Rows(0).Item(2)
                        GmMapa.Position = New PointLatLng(latiZona, longiZona)

                        Dim colorZona As String = DgjBusqueda.GetValue("color").ToString
                        ColorDialogZona.Color = ColorTranslator.FromHtml(colorZona)

                        TbColor.Text = colorZona

                        Dim polygon As New GMapPolygon(_listPuntos, "mypolygon")
                        'agregar color
                        polygon.Fill = New SolidBrush(Color.FromArgb(50, ColorDialogZona.Color))
                        polygon.Stroke = New Pen(Color.Red, 1)
                        _overlay.Polygons.Clear()
                        _overlay.Polygons.Add(polygon)
                    Else
                        _overlay.Polygons.Clear()
                    End If

                End If

                'cargar lista repartidores
                P_prArmarGrillaRepartidor()
                Dim tRep As DataTable = L_ZonaDetalleRepartidor_General(-1, TbCodigo.Text).Tables(0)
                Dim codRep As Integer
                For Each fil1 As GridEXRow In dgjRepartidor.GetRows
                    codRep = fil1.Cells("numi").Value
                    For Each fil2 As DataRow In tRep.Rows
                        If (codRep = fil2.Item("lccbnumi")) Then
                            fil1.BeginEdit()
                            fil1.Cells("check").Value = True
                            fil1.EndEdit()
                            Exit For
                        End If
                    Next
                Next

                'cargar lista prevendedor
                P_prArmarGrillaPrevendedor()
                Dim tPre As DataTable = L_ZonaDetalleRepartidor_General(-1, TbCodigo.Text).Tables(0)
                Dim codPre As Integer
                For Each fil1 As GridEXRow In dgjPrevendedor.GetRows
                    codPre = fil1.Cells("numi").Value
                    For Each fil2 As DataRow In tPre.Rows
                        If (codPre = fil2.Item("lccbnumi")) Then
                            fil1.BeginEdit()
                            fil1.Cells("check").Value = True
                            fil1.EndEdit()
                            Exit For
                        End If
                    Next
                Next

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
        CbCiudad.Select()

        GmMapa.Position = New PointLatLng(-16.50097, -68.132683)
        GmMapa.Zoom = 13
    End Sub

    Private Sub P_prModificarRegistro()
        P_prEstadoNueModEli(2)
        P_prHDComponentes(BoModificar)
        CbCiudad.SelectAll()
    End Sub

    Private Sub P_prEliminarRegistro()
        Dim numi As String = TbCodigo.Text 'Valor del código único
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper,
                                       eTaskDialogIcon.Delete, "advertencia".ToUpper,
                                       "Esta a punto de eliminar la zona con".ToUpper _
                                       + vbCrLf + "código -> ".ToUpper _
                                       + numi + " " + vbCrLf + "Desea continuar?".ToUpper,
                                       eTaskDialogButton.Yes Or eTaskDialogButton.Cancel,
                                       eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If (result = eTaskDialogResult.Yes) Then
            'Dim mensajeError As String = ""
            'Dim resEliminar As Boolean = L_fnbValidarEliminacion(numi, "TC001", "canumi", mensajeError)
            'If (resEliminar) Then
            'Dim res As Boolean = L_fnProductoBorrar(numi) 'Medoto de lógica para eliminar
            L_ZonaCabecera_Borrar(TbCodigo.Text)
            L_ZonaDetallePuntos_Borrar(TbCodigo.Text)
            L_ZonaDetalleRepartidor_Borrar(TbCodigo.Text)
            'If (res) Then
            ToastNotification.Show(Me, "Codigo de zona: ".ToUpper + numi + " eliminado con Exito.".ToUpper,
                                   My.Resources.GRABACION_EXITOSA, InDuracion * 1000,
                                   eToastGlowColor.Green,
                                   eToastPosition.TopCenter)
            BoNavegar = False
            P_prArmarGrillaBusqueda()
            BoNavegar = True
            P_prMoverIndexActual()
            'Else
            '    ToastNotification.Show(Me, "No se pudo eliminar el producto con código: ".ToUpper + numi + ", intente nuevamente.".ToUpper,
            '                           My.Resources.WARNING, InDuracion * 1000,
            '                           eToastGlowColor.Red,
            '                           eToastPosition.TopCenter)
            'End If
            'Else
            '    ToastNotification.Show(Me, mensajeError.ToUpper,
            '                               My.Resources._ERROR, InDuracion * 1000,
            '                               eToastGlowColor.Red,
            '                               eToastPosition.TopCenter)
            'End If
        End If
    End Sub

    Private Sub P_prGrabarRegistro()
        'Dim numi As String

        CbCiudad.Select()
        If (BoNuevo) Then
            If (P_fnValidarGrabacion()) Then
                'numi = TbCodigo.Text.Trim

                'Grabar
                'Dim res As Boolean = L_fnProductoGrabar(numi, cod, desc, desc2, cat, img, stc, est, serie, pcom, fing)

                TbCodigo.Text = L_GetLastIdTablas("TL001", "lanumi")
                L_ZonaCabecera_Grabar(TbCodigo.Text, CbCiudad.Value, CbProvincia.Value, CbZona.Value, TbColor.Text)
                'grabar detalle
                Dim i As Integer
                Dim lati, longi As Double
                For i = 0 To _listPuntos.Count - 1
                    lati = _listPuntos.Item(i).Lat
                    longi = _listPuntos.Item(i).Lng
                    L_ZonaDetallePuntos_Grabar(TbCodigo.Text, lati, longi)
                Next

                'grabar detalle repartidores
                For Each fil As GridEXRow In dgjRepartidor.GetRows
                    If (fil.Cells("check").Value) Then
                        L_ZonaDetalleRepartidor_Grabar(TbCodigo.Text, fil.Cells("numi").Value.ToString)
                    End If
                Next

                'grabar detalle prevendedores
                For Each fil As GridEXRow In dgjPrevendedor.GetRows
                    If (fil.Cells("check").Value) Then
                        L_ZonaDetalleRepartidor_Grabar(TbCodigo.Text, fil.Cells("numi").Value.ToString)
                    End If
                Next

                'If (res) Then
                P_prLimpiar()
                BoNavegar = False
                P_prArmarGrillaBusqueda()
                BoNavegar = True

                CbCiudad.Select()
                ToastNotification.Show(Me, "Codigo de zona ".ToUpper + TbCodigo.Text + " Grabado con Exito.".ToUpper,
                                   My.Resources.GRABACION_EXITOSA,
                                   InDuracion * 1000,
                                   eToastGlowColor.Green,
                                   eToastPosition.TopCenter)
                'Else
                'ToastNotification.Show(Me, "No se pudo grabar el codigo de producto ".ToUpper + TbCodigo.Text + ", intente nuevamente.".ToUpper,
                '                   My.Resources.WARNING,
                '                   InDuracion * 1000,
                '                   eToastGlowColor.Red,
                '                   eToastPosition.TopCenter)
                'End If
            End If
        ElseIf (BoModificar) Then
            If (P_fnValidarGrabacion()) Then
                'numi = TbCodigo.Text.Trim

                'Grabar
                'Dim res As Boolean = L_fnProductoModificar(numi, cod, desc, desc2, cat, img, stc, est, serie, pcom, fing)

                L_ZonaCabacera_Modificar(TbCodigo.Text, CbCiudad.Value, CbProvincia.Value, CbZona.Value, TbColor.Text)
                'grabar detalle
                L_ZonaDetallePuntos_Borrar(TbCodigo.Text)
                Dim i As Integer
                Dim lati, longi As Double
                For i = 0 To _listPuntos.Count - 1
                    lati = _listPuntos.Item(i).Lat
                    longi = _listPuntos.Item(i).Lng
                    L_ZonaDetallePuntos_Grabar(TbCodigo.Text, lati, longi)
                Next

                'grabar detalle repartidores
                L_ZonaDetalleRepartidor_Borrar(TbCodigo.Text)
                For Each fil As GridEXRow In dgjRepartidor.GetRows
                    If (fil.Cells("check").Value) Then
                        L_ZonaDetalleRepartidor_Grabar(TbCodigo.Text, fil.Cells("numi").Value.ToString)
                    End If
                Next

                'grabar detalle prevendedores
                For Each fil As GridEXRow In dgjPrevendedor.GetRows
                    If (fil.Cells("check").Value) Then
                        L_ZonaDetalleRepartidor_Grabar(TbCodigo.Text, fil.Cells("numi").Value.ToString)
                    End If
                Next

                'If (res) Then
                BoNavegar = False
                P_prArmarGrillaBusqueda()
                BoNavegar = True

                P_prMoverIndexActual()

                CbCiudad.Select()
                MBtSalir.PerformClick()

                ToastNotification.Show(Me, "Codigo de zona ".ToUpper + TbCodigo.Text + " Modificado con Exito.".ToUpper,
                                   My.Resources.GRABACION_EXITOSA,
                                   InDuracion * 1000,
                                   eToastGlowColor.Green,
                                   eToastPosition.TopCenter)
                'Else
                'ToastNotification.Show(Me, "No se pudo modificar el codigo de producto ".ToUpper + TbCodigo.Text + ", intente nuevamente.".ToUpper,
                '                   My.Resources.WARNING,
                '                   InDuracion * 1000,
                '                   eToastGlowColor.Red,
                '                   eToastPosition.TopCenter)
                'End If
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

        MSuperTabItemBusqueda.Visible = (value = 4)
        'Compentes

        If (MSuperTabControlPrincipal.SelectedTabIndex = 1) Then
            MSuperTabControlPrincipal.SelectedTabIndex = 0
        End If

    End Sub

#End Region

#Region "Metodos y funciones generales"

    Private Sub P_prArmarComboCiudad()
        Dim Dt As DataTable

        Dt = L_fnObtenerLibreria("4", " 1=1 ")
        g_prArmarCombo(CbCiudad, Dt, 60, 200, "Código", "Ciudad")
    End Sub

    Private Sub P_prArmarComboProvincia()
        Dim Dt As DataTable

        Dt = L_fnObtenerLibreria("3", " 1=1 ")
        g_prArmarCombo(CbProvincia, Dt, 60, 200, "Código", "Provincia")
    End Sub

    Private Sub P_prArmarComboZona()
        Dim Dt As DataTable

        Dt = L_fnObtenerLibreria("2", " 1= 1 ")
        g_prArmarCombo(CbZona, Dt, 60, 200, "Código", "Zona")
    End Sub

    Private Sub P_prArmarGrillaBusqueda()
        DtBusqueda = New DataTable
        DtBusqueda = L_fnZonaGeneral()

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
            .Caption = ""
            .Key = "ccity"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(2)
            .Caption = "Ciudad"
            .Key = "ncity"
            .Width = 150
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(3)
            .Caption = ""
            .Key = "cprov"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(4)
            .Caption = "Provincia"
            .Key = "nprov"
            .Width = 150
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(5)
            .Caption = ""
            .Key = "czona"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(6)
            .Caption = "Zona"
            .Key = "nzona"
            .Width = 150
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(7)
            .Caption = "Color"
            .Key = "Color"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(8)
            .Caption = ""
            .Key = "fact"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(9)
            .Caption = ""
            .Key = "hact"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(10)
            .Caption = ""
            .Key = "uact"
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

    Private Sub P_prArmarGrillaRepartidor()
        Dim dt As New DataTable
        dt = L_fnObtenerTabla("cast(0 as bit) as [check], a.cbnumi as numi, a.cbdesc as [desc]", "TC002 a", "a.cbcat=1 and a.cbest=1")

        dgjRepartidor.BoundMode = Janus.Data.BoundMode.Bound
        dgjRepartidor.DataSource = dt
        dgjRepartidor.RetrieveStructure()

        'dar formato a las columnas
        With dgjRepartidor.RootTable.Columns("check")
            .Caption = "Check"
            .Width = 50
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = True
        End With
        With dgjRepartidor.RootTable.Columns("numi")
            .Visible = False
        End With
        With dgjRepartidor.RootTable.Columns("desc")
            .Caption = "Nombre Repartidor"
            .Width = 350
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With

        'Habilitar Filtradores
        With dgjRepartidor
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
            .SelectionMode = SelectionMode.MultipleSelection
            .AlternatingColors = True
        End With
    End Sub

    Private Sub P_prArmarGrillaPrevendedor()
        Dim dt As New DataTable
        dt = L_fnObtenerTabla("cast(0 as bit) as [check], a.cbnumi as numi, a.cbdesc as [desc]", "TC002 a", "a.cbcat=3 and a.cbest=1")

        dgjPrevendedor.BoundMode = Janus.Data.BoundMode.Bound
        dgjPrevendedor.DataSource = dt
        dgjPrevendedor.RetrieveStructure()

        'dar formato a las columnas
        With dgjPrevendedor.RootTable.Columns("check")
            .Caption = "Check"
            .Width = 50
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = True
        End With
        With dgjPrevendedor.RootTable.Columns("numi")
            .Visible = False
        End With
        With dgjPrevendedor.RootTable.Columns("desc")
            .Caption = "Nombre Repartidor"
            .Width = 350
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With

        'Habilitar Filtradores
        With dgjPrevendedor
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
            .SelectionMode = SelectionMode.MultipleSelection
            .AlternatingColors = True
        End With
    End Sub

    Private Function P_fnValidarGrabacion() As Boolean
        Dim res As Boolean = True
        MEP.Clear()

        If (Not IsNumeric(CbCiudad.Value)) Then
            CbCiudad.BackColor = Color.Red
            MEP.SetError(CbCiudad, "elija una ciudad valida!".ToUpper)
            res = False
        Else
            CbCiudad.BackColor = Color.White
            MEP.SetError(CbCiudad, "")
        End If

        If (Not IsNumeric(CbProvincia.Value)) Then
            CbProvincia.BackColor = Color.Red
            MEP.SetError(CbProvincia, "elija una ciudad valida!".ToUpper)
            res = False
        Else
            CbProvincia.BackColor = Color.White
            MEP.SetError(CbProvincia, "")
        End If

        If (Not IsNumeric(CbZona.Value)) Then
            CbZona.BackColor = Color.Red
            MEP.SetError(CbZona, "elija una ciudad valida!".ToUpper)
            res = False
        Else
            CbZona.BackColor = Color.White
            MEP.SetError(CbZona, "")
        End If

        'Validar que este eligido un repartidor
        Dim flat As Boolean = False
        For Each fil As GridEXRow In dgjRepartidor.GetRows
            If (fil.Cells("check").Value) Then
                flat = True
                Exit For
            End If
        Next

        If (Not flat) Then
            dgjRepartidor.BackColor = Color.Red
            ToastNotification.Show(Me,
                                   "Elija un repartidor.".ToUpper,
                                   My.Resources.WARNING,
                                   InDuracion * 1000,
                                   eToastGlowColor.Red,
                                   eToastPosition.TopCenter)

            res = False
        Else
            dgjRepartidor.BackColor = Color.White
        End If

        Return res
    End Function

#End Region

#Region "Metodos Privados"

    Private Sub P_prCargarMapa()
        GmMapa.DragButton = MouseButtons.Left
        GmMapa.CanDragMap = True
        GmMapa.MapProvider = GMapProviders.GoogleMap
        GmMapa.Position = New PointLatLng(-17.782814, -63.182386)
        GmMapa.MinZoom = 0
        GmMapa.MaxZoom = 24
        GmMapa.Zoom = 14
        GmMapa.AutoScroll = True
        GMapProvider.Language = LanguageType.Spanish

        'GM_mapa.Manager.Mode = AccessMode.CacheOnly
        'GM_mapa.CacheLocation = ""

        'añadir puntos
        'Dim markersOverlay As New GMapOverlay("markers")
        'Dim marker As New GMarkerGoogle(New PointLatLng(-17.782814, -63.182386), GMarkerGoogleType.green)
        ''añadir tooltip
        'Dim mode As MarkerTooltipMode = MarkerTooltipMode.OnMouseOver
        'marker.ToolTip = New GMapBaloonToolTip(marker)
        'marker.ToolTipMode = mode
        'Dim ToolTipBackColor As New SolidBrush(Color.Red)
        'marker.ToolTip.Fill = ToolTipBackColor
        'marker.ToolTipText = "Cliente 1"

        'markersOverlay.Markers.Add(marker)
        'mapa.Overlays.Add(markersOverlay)

        'añadir poligono

        'Dim points As New List(Of PointLatLng)
        'points.Add(New PointLatLng(-17.78596, -63.216289))
        'points.Add(New PointLatLng(-17.785321, -63.204572))
        'points.Add(New PointLatLng(-17.7942, -63.204268))
        'points.Add(New PointLatLng(-17.797033, -63.215597))
        'Dim polygon As New GMapPolygon(points, "mypolygon")
        'polygon.Fill = New SolidBrush(Color.FromArgb(50, Color.Red))
        'polygon.Stroke = New Pen(Color.Red, 1)
        '_overlay.Polygons.Add(polygon)
        'GM_mapa.Overlays.Add(_overlay)
    End Sub

    Private Sub _AgregarPunto(pointLatLng As PointLatLng, Optional etiqueta As String = "")
        'añadir puntos
        ''Dim markersOverlay As New GMapOverlay("markers")
        Dim marker As New GMarkerGoogle(pointLatLng, GMarkerGoogleType.blue)
        'añadir tooltip
        If etiqueta <> "" Then
            Dim mode As MarkerTooltipMode = MarkerTooltipMode.OnMouseOver
            marker.ToolTip = New GMapBaloonToolTip(marker)
            marker.ToolTipMode = mode
            Dim ToolTipBackColor As New SolidBrush(Color.Red)
            marker.ToolTip.Fill = ToolTipBackColor
            marker.ToolTipText = etiqueta
        End If
        _overlay.Markers.Add(marker)
        'mapa.Overlays.Add(markersOverlay)
    End Sub

    Private Sub _LlenarComboLibreria(ByVal cb As Janus.Windows.GridEX.EditControls.MultiColumnCombo, ByVal concep As Integer)
        Dim _Ds As New DataSet
        _Ds = L_General_LibreriaDetalle(-1, concep)

        cb.DropDownList.Columns.Clear()

        cb.DropDownList.Columns.Add(_Ds.Tables(0).Columns("cenum").ToString).Width = 50
        cb.DropDownList.Columns(0).Caption = "Código"
        cb.DropDownList.Columns.Add(_Ds.Tables(0).Columns("cedesc").ToString).Width = 250
        cb.DropDownList.Columns(1).Caption = "Descripcion"

        cb.ValueMember = _Ds.Tables(0).Columns("cenum").ToString
        cb.DisplayMember = _Ds.Tables(0).Columns("cedesc").ToString
        cb.DataSource = _Ds.Tables(0)
        cb.Refresh()
    End Sub

    Private Sub P_prLimpiarErrores()
        MEP.Clear()
        CbCiudad.BackColor = Color.White
        CbProvincia.BackColor = Color.White
        CbZona.BackColor = Color.White
        dgjRepartidor.BackColor = Color.White
        BtMarcarZona.BackColor = Color.White
    End Sub

#End Region

    Private Sub mapa_MouseClick(sender As Object, e As MouseEventArgs) Handles GmMapa.MouseClick
        If _poligono = 1 Then
            Dim gm As GMapControl = CType(sender, GMapControl)
            Dim hj As MouseEventArgs = CType(e, MouseEventArgs)
            Dim plg As PointLatLng = gm.FromLocalToLatLng(hj.X, hj.Y)
            _AgregarPunto(plg)
            _listPuntos.Add(plg)
        End If
        '_agregarPunto(plg)
        'Refresh()
        '_agregarPunto(mapa.FromLocalToLatLng(e.X, e.Y))
    End Sub

    Private Sub mapa_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles GmMapa.MouseDoubleClick
        If e.Button = MouseButtons.Left Then
            'Cursor.Current = Cursors.WaitCursor
            Dim latLng As PointLatLng = GmMapa.FromLocalToLatLng(e.X, e.Y)
            _AgregarPunto(latLng)
        End If
    End Sub

    Private Sub J_Cb_Ciudad_ValueChanged(sender As Object, e As EventArgs) Handles CbCiudad.ValueChanged
        If CbCiudad.SelectedIndex >= 0 Then
            Dim ciudad As String = CbCiudad.Text
            Select Case ciudad
                Case "COCHABAMBA"
                    GmMapa.Position = New PointLatLng(-17.380941, -66.15976)
                Case "ORURO"
                    GmMapa.Position = New PointLatLng(-17.967867, -67.117933)
                Case "SANTA CRUZ"
                    GmMapa.Position = New PointLatLng(-17.782814, -63.182386)
                Case "LA PAZ"
                    GmMapa.Position = New PointLatLng(-16.50097, -68.132683)

            End Select

            MEP.SetError(CbCiudad, "")
            CbCiudad.BackColor = Color.White
        Else
            If CbCiudad.Value <> Nothing Then
                BtAddCiudad.Visible = True
            Else
                BtAddCiudad.Visible = False
            End If

            'Ep2.SetError(J_Cb_Ciudad, "No existe la ciudad")
            'J_Cb_Ciudad.BackColor = Color.Yellow
        End If
    End Sub

    Private Sub J_Cb_Provincia_ValueChanged(sender As Object, e As EventArgs) Handles CbProvincia.ValueChanged
        If CbProvincia.SelectedIndex >= 0 Then
            MEP.SetError(CbProvincia, "")
            CbProvincia.BackColor = Color.White
        Else
            If CbProvincia.Value <> Nothing Then
                BtAddProvincia.Visible = True
            Else
                BtAddProvincia.Visible = False
            End If
            'Ep2.SetError(J_Cb_Provincia, "No existe la provincia")
            'J_Cb_Provincia.BackColor = Color.Yellow
        End If
    End Sub

    Private Sub J_Cb_Zona_ValueChanged(sender As Object, e As EventArgs) Handles CbZona.ValueChanged
        If CbZona.SelectedIndex >= 0 Then
            MEP.SetError(CbZona, "")
            CbZona.BackColor = Color.White
        Else
            If CbZona.Value <> Nothing Then
                BtAddZona.Visible = True
            Else
                BtAddZona.Visible = False
            End If
            'Ep2.SetError(J_Cb_Zona, "No existe la zona")
            'J_Cb_Zona.BackColor = Color.Yellow
        End If
    End Sub

    Private Sub ButtonX1_Click_1(sender As Object, e As EventArgs) Handles BtMarcarZona.Click
        If BtMarcarZona.Text = "Terminar" Then
            'GM_mapa.Refresh()
            'mapa.PolygonsEnabled = True
            'Dim polyOverlay As New GMapOverlay("polygons")
            Dim polygon As New GMapPolygon(_listPuntos, "mypolygon")
            'agregar color
            If ColorDialogZona.ShowDialog() = DialogResult.OK Then
                polygon.Fill = New SolidBrush(Color.FromArgb(50, ColorDialogZona.Color))
                Dim hexa As String = String.Format("#{0:X2}{1:X2}{2:X2}", ColorDialogZona.Color.R, ColorDialogZona.Color.G, ColorDialogZona.Color.B)
                TbColor.Text = hexa
            Else
                polygon.Fill = New SolidBrush(Color.FromArgb(50, Color.Blue))
                Dim hexa As String = String.Format("#{0:X2}{1:X2}{2:X2}", ColorDialogZona.Color.R, ColorDialogZona.Color.G, ColorDialogZona.Color.B)
                TbColor.Text = hexa
            End If

            'polygon.Fill = New SolidBrush(Color.FromArgb(50, Color.Black))
            polygon.Stroke = New Pen(Color.Red, 1)
            _overlay.Polygons.Clear()
            _overlay.Polygons.Add(polygon)
            'añadir tooltip a poligono

            ''mapa.Overlays.Add(polyOverlay)

            _overlay.Markers.Clear()
            _poligono = 0

            BtMarcarZona.Text = "Marcar Zona"
        Else
            BtMarcarZona.Text = "Terminar"
            _poligono = 1
            _listPuntos.Clear()
        End If
    End Sub

    Private Sub Btn_ZoomMas_Click(sender As Object, e As EventArgs) Handles BtZoomMas.Click
        If GmMapa.Zoom <> GmMapa.MaxZoom Then
            GmMapa.Zoom = GmMapa.Zoom + 1
        End If
    End Sub

    Private Sub Btn_ZoomMenos_Click(sender As Object, e As EventArgs) Handles BtZoomMenos.Click
        If GmMapa.Zoom <> GmMapa.MinZoom Then
            GmMapa.Zoom = GmMapa.Zoom - 1
        End If
    End Sub

    Private Sub btAgregarCiudad_Click(sender As Object, e As EventArgs) Handles BtAddCiudad.Click
        Dim num As Integer = 0
        L_Grabar_Libreria(gi_LibCiudad, num, CbCiudad.Value.ToString, gs_user) 'le mando num para recuperar su numero del nuevo tipo
        _LlenarComboLibreria(CbCiudad, gi_LibCiudad)
        CbCiudad.SelectedIndex = CType(CbCiudad.DataSource, DataTable).Rows.Count - 1
        CbCiudad.Focus()
    End Sub

    Private Sub btAgregarProv_Click(sender As Object, e As EventArgs) Handles BtAddProvincia.Click
        Dim num As Integer = 0
        L_Grabar_Libreria(gi_LibProv, num, CbProvincia.Value.ToString, gs_user) 'le mando num para recuperar su numero del nuevo tipo
        _LlenarComboLibreria(CbProvincia, gi_LibProv)
        CbProvincia.SelectedIndex = CType(CbProvincia.DataSource, DataTable).Rows.Count - 1
        CbProvincia.Focus()
    End Sub

    Private Sub btAgregarZona_Click(sender As Object, e As EventArgs) Handles BtAddZona.Click
        Dim num As Integer = 0
        L_Grabar_Libreria(gi_LibZona, num, CbZona.Value.ToString, gs_user) 'le mando num para recuperar su numero del nuevo tipo
        _LlenarComboLibreria(CbZona, gi_LibZona)
        CbZona.SelectedIndex = CType(CbZona.DataSource, DataTable).Rows.Count - 1
        CbZona.Focus()
    End Sub

    Private Sub J_Cb_Ciudad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CbCiudad.KeyPress, CbProvincia.KeyPress, CbZona.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub DgjBusqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles DgjBusqueda.KeyDown
        If (e.KeyData = Keys.Enter) Then
            MSuperTabControlPrincipal.SelectedTabIndex = 0
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub DgjBusqueda_DoubleClick(sender As Object, e As EventArgs) Handles DgjBusqueda.DoubleClick
        If (DgjBusqueda.Row > -1) Then
            MSuperTabControlPrincipal.SelectedTabIndex = 0
        End If
    End Sub

    Private Sub dgjRepartidor_EditingCell(sender As Object, e As EditingCellEventArgs) Handles dgjRepartidor.EditingCell
        If (BoNuevo Or BoModificar) Then
            If (e.Column.Index = dgjRepartidor.RootTable.Columns("check").Index) Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub dgjPrevendedor_EditingCell(sender As Object, e As EditingCellEventArgs) Handles dgjPrevendedor.EditingCell
        If (BoNuevo Or BoModificar) Then
            If (e.Column.Index = dgjPrevendedor.RootTable.Columns("check").Index) Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub

End Class