Imports System.IO
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports Janus.Windows.GridEX
Imports Logica.AccesoLogica

Public Class F01_Pagos

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
    Dim InDuracion As Byte = 5

    Dim BoNuevo As Boolean = False
    Dim BoModificar As Boolean = False
    Dim BoEliminar As Boolean = False
    Dim BoNavegar As Boolean = False

#End Region

#Region "Eventos generales"

    Private Sub F01_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            L_prAbrirConexion("localhost", "goku", "321", "BDDistBHF_HO")
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
        Me.Text = "P A G O S"
        Me.WindowState = FormWindowState.Maximized

        'Visible
        MBtImprimir.Visible = False

        'Enabled
        MBtGrabar.Enabled = False

        'ReadOnly
        tbCodigo.ReadOnly = True
        tbdSaldo.IsInputReadOnly = True

        'Grid Busqueda
        dgjBusqueda.AllowEdit = InheritableBoolean.False

        'Botones

        'Funciones
        P_prCambiarFuenteComponentes()
        P_prAsignarPermisos()

        'Usuario del sistema
        MTbUsuario.Text = gs_user
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
        tbRecibo.ReadOnly = Not flat
        dtiFecha.IsInputReadOnly = Not flat
        tbCliente.ReadOnly = Not flat
        btBuscar.Enabled = flat
        tbdMonto.IsInputReadOnly = Not flat
    End Sub

    Private Sub P_prLimpiar()
        TbCodigo.Clear()
        tbRecibo.Clear()
        dtiFecha.Value = Now.Date
        tbCliente.Clear()
        tbdMonto.Value = 0
        tbdSaldo.Value = 0

        MBtGrabar.Tooltip = "GRABAR"
    End Sub

    Private Sub P_prArmarCombos()

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
                With dgjBusqueda
                    Me.tbCodigo.Text = .GetValue("ognumi").ToString
                    Me.tbRecibo.Text = .GetValue("ogrec").ToString
                    Me.dtiFecha.Value = .GetValue("ogfdoc")
                    Me.tbCliente.Tag = .GetValue("ogcli").ToString
                    Me.tbCliente.Text = .GetValue("nogcli")
                    Me.tbdMonto.Value = .GetValue("ogmon")
                    Me.tbdSaldo.Value = .GetValue("saldo")


                    MLbFecha.Text = CType(.GetValue("ogfact").ToString, Date).ToString("dd/MM/yyyy")
                    MLbHora.Text = .GetValue("oghact").ToString
                    MLbUsuario.Text = .GetValue("oguact").ToString
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
        tbRecibo.Select()
    End Sub

    Private Sub P_prModificarRegistro()
        P_prEstadoNueModEli(2)
        P_prHDComponentes(BoModificar)
        tbRecibo.SelectAll()
    End Sub

    Private Sub P_prEliminarRegistro()
        Dim numi As String = TbCodigo.Text 'Valor del código único
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper,
                                       eTaskDialogIcon.Delete, "advertencia".ToUpper,
                                       "Esta a punto de eliminar el pago con".ToUpper _
                                       + vbCrLf + "código -> ".ToUpper _
                                       + numi + " " + vbCrLf + "Desea continuar?".ToUpper,
                                       eTaskDialogButton.Yes Or eTaskDialogButton.Cancel,
                                       eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim resEliminar As Boolean = L_fnbValidarEliminacion(numi, "TO003", "ognumi", mensajeError)
            If (resEliminar) Then
                Dim res As Boolean = L_fnPagoBorrar(numi) 'Medoto de lógica para eliminar
                If (res) Then
                    ToastNotification.Show(Me, "Codigo de pago: ".ToUpper + numi + " eliminado con Exito.".ToUpper,
                                           My.Resources.GRABACION_EXITOSA, InDuracion * 1000,
                                           eToastGlowColor.Green,
                                           eToastPosition.TopCenter)
                    BoNavegar = False
                    P_prArmarGrillaBusqueda()
                    BoNavegar = True
                    P_prMoverIndexActual()
                Else
                    ToastNotification.Show(Me, "No se pudo eliminar el pago con código: ".ToUpper + numi + ", intente nuevamente.".ToUpper,
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
        Dim rec As String
        Dim fdoc As String
        Dim cli As String
        Dim mon As String
        Dim nota As String
        Dim tprod As String

        If (BoNuevo) Then
            If (P_fnValidarGrabacion()) Then
                numi = TbCodigo.Text.Trim
                rec = tbRecibo.Text.Trim
                fdoc = dtiFecha.Value.ToString("yyyy/MM/dd")
                cli = tbCliente.Tag.ToString
                mon = tbdMonto.Value.ToString
                nota = "0"
                tprod = "0"

                'Grabar
                Dim res As Boolean = L_fnPagoGrabar(numi, rec, fdoc, cli, mon, nota, tprod)

                If (res) Then
                    P_prLimpiar()
                    BoNavegar = False
                    P_prArmarGrillaBusqueda()
                    BoNavegar = True

                    tbRecibo.Select()
                    ToastNotification.Show(Me, "Codigo de pago ".ToUpper + tbCodigo.Text + " Grabado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA,
                                       InDuracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
                Else
                    ToastNotification.Show(Me, "No se pudo grabar el codigo de pago ".ToUpper + tbCodigo.Text + ", intente nuevamente.".ToUpper,
                                       My.Resources.WARNING,
                                       InDuracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)
                End If
            End If
        ElseIf (BoModificar) Then
            If (P_fnValidarGrabacion()) Then
                numi = tbCodigo.Text.Trim
                rec = tbRecibo.Text.Trim
                fdoc = dtiFecha.Value.ToString("yyyy/MM/dd")
                cli = tbCliente.Tag.ToString
                mon = tbdMonto.Value.ToString
                nota = "0"
                tprod = "0"

                'Grabar
                Dim res As Boolean = L_fnPagoModificar(numi, rec, fdoc, cli, mon, nota, tprod)

                If (res) Then
                    BoNavegar = False
                    P_prArmarGrillaBusqueda()
                    BoNavegar = True

                    P_prMoverIndexActual()

                    tbRecibo.Select()
                    MBtSalir.PerformClick()

                    ToastNotification.Show(Me, "Codigo de pago ".ToUpper + tbCodigo.Text + " Modificado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA,
                                       InDuracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
                Else
                    ToastNotification.Show(Me, "No se pudo modificar el codigo de pago ".ToUpper + tbCodigo.Text + ", intente nuevamente.".ToUpper,
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

        MBtGrabar.Tooltip = IIf(value = 1, "GRABAR NUEVO REGISTRO", IIf(value = 2, "GRABAR MODIFICACIÓN DE REGISTRO", "GRABAR"))
        MRlAccion.Text = IIf(value = 1, "NUEVO", IIf(value = 2, "MODIFICAR", ""))

    End Sub

    Private Function P_fnObtenerID() As String
        Dim res As String = ""
        res = res + Now.Hour.ToString("00") + Now.Minute.ToString("00") + Now.Second.ToString("00") + "_" _
            + Now.Day.ToString("00") + Now.Month.ToString("00") + Now.Year.ToString("0000")
        Return res
    End Function

#End Region

#Region "Metodos y funciones generales"

    Private Sub P_prValidarCarpetaImagenes()
        'Dim rutaDestino As String = StRutaImagenes
        'If (System.IO.Directory.Exists(rutaDestino) = False) Then
        '    System.IO.Directory.CreateDirectory(rutaDestino)
        'End If
    End Sub

    Private Sub P_prArmarGrillaBusqueda()
        DtBusqueda = New DataTable
        DtBusqueda = L_fnPagoGeneral()

        dgjBusqueda.BoundMode = Janus.Data.BoundMode.Bound
        DgjBusqueda.DataSource = DtBusqueda
        DgjBusqueda.RetrieveStructure()

        'dar formato a las columnas
        With dgjBusqueda.RootTable.Columns("ognumi")
            .Caption = "Código"
            .Width = 80
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With dgjBusqueda.RootTable.Columns("ogrec")
            .Caption = "Recibo"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With dgjBusqueda.RootTable.Columns("ogfdoc")
            .Caption = "Fecha"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = True
        End With
        With dgjBusqueda.RootTable.Columns("ogcli")
            .Visible = False
        End With
        With dgjBusqueda.RootTable.Columns("nogcli")
            .Caption = "Cliente"
            .Width = 250
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With dgjBusqueda.RootTable.Columns("ogmon")
            .Caption = "Monto"
            .Width = 120
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With dgjBusqueda.RootTable.Columns("saldo")
            .Caption = "Saldo"
            .Width = 120
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With dgjBusqueda.RootTable.Columns("ognota")
            .Visible = False
        End With
        With dgjBusqueda.RootTable.Columns("ogtprod")
            .Visible = False
        End With
        With dgjBusqueda.RootTable.Columns("ogfact")
            .Visible = False
        End With
        With dgjBusqueda.RootTable.Columns("oghact")
            .Visible = False
        End With
        With dgjBusqueda.RootTable.Columns("oguact")
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

        If (tbRecibo.Text = String.Empty) Then
            tbRecibo.BackColor = Color.Red
            MEP.SetError(tbRecibo, "ingrese el recibo del pago!".ToUpper)
            res = False
        Else
            tbRecibo.BackColor = Color.White
            MEP.SetError(tbRecibo, "")
        End If

        If (tbCliente.Text = String.Empty) Then
            tbCliente.BackColor = Color.Red
            MEP.SetError(tbCliente, "ingrese el nombre del cliente!".ToUpper)
            res = False
        Else
            tbCliente.BackColor = Color.White
            MEP.SetError(tbCliente, "")
        End If

        If (tbdMonto.Value = 0) Then
            tbdMonto.BackColor = Color.Red
            MEP.SetError(tbdMonto, "El monto debe ser mayor a cero (0)!".ToUpper)
            res = False
        Else
            tbdMonto.BackColor = Color.White
            MEP.SetError(tbdMonto, "")
        End If

        Return res
    End Function

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        P_ListarClientes
    End Sub

    Private Sub P_ListarClientes()
        If (BoNuevo Or BoModificar) Then
            Dim dt As DataTable
            dt = L_fnObtenerTabla("a.ccnumi, a.ccdesc, a.ccdirec, a.cctelf1",
                                  "TC004 a",
                                  "1=1")

            Dim listEstCeldas As New List(Of Modelo.MCelda)
            listEstCeldas.Add(New Modelo.MCelda("ccnumi,", True, "Código", 80))
            listEstCeldas.Add(New Modelo.MCelda("ccdesc", True, "Nombre", 250))
            listEstCeldas.Add(New Modelo.MCelda("ccdirec,", True, "Direción", 250))
            listEstCeldas.Add(New Modelo.MCelda("cctelf1,", True, "Teléfono", 100))

            Dim ef = New Efecto
            ef.tipo = 3
            ef.dt = dt
            ef.SeleclCol = 2
            ef.listEstCeldas = listEstCeldas
            ef.alto = 50
            ef.ancho = 350
            ef.Context = "Seleccione Cliente".ToUpper
            ef.ShowDialog()
            ef.StartPosition = FormStartPosition.CenterScreen
            Dim bandera As Boolean = False
            bandera = ef.band
            If (bandera = True) Then
                Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row
                tbCliente.Tag = Row.Cells("ccnumi").Value
                tbCliente.Text = Row.Cells("ccdesc").Value.ToString
            End If
        End If
    End Sub

    Private Sub tbCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles tbCliente.KeyDown
        If (e.KeyData = Keys.Control + Keys.Enter) Then
            P_ListarClientes()
        End If
    End Sub

#End Region

End Class