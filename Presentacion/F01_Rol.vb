Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar.Controls

Public Class F01_Rol


#Region "Atributos generales"

    Dim StTitulo As String = "P R O D U C T O"
    Dim InTipoForm As Byte = 1

    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

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

    Private Sub grDetalle_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles grDetalle.CellEdited
        Dim estado As Integer = grDetalle.GetValue("estado")
        If estado = 1 Then
            grDetalle.SetValue("estado", 2)

        End If

    End Sub

    Private Sub grDetalle_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grDetalle.EditingCell
        If MBtGrabar.Enabled Then
            If e.Column.Key <> "ycshow" And e.Column.Key <> "ycadd" And e.Column.Key <> "ycmod" And e.Column.Key <> "ycdel" Then
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If


    End Sub

    Private Sub SELECCIONARTODOSSHOWToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SELECCIONARTODOSSHOWToolStripMenuItem.Click
        _prSeleccionarTodos("ycshow")
    End Sub

    Private Sub SELECCIONARTODOSADDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SELECCIONARTODOSADDToolStripMenuItem.Click
        _prSeleccionarTodos("ycadd")
    End Sub

    Private Sub SELECCIONARTODOSEDITToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SELECCIONARTODOSEDITToolStripMenuItem.Click
        _prSeleccionarTodos("ycmod")
    End Sub

    Private Sub SELECCIONARTODOSDELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SELECCIONARTODOSDELToolStripMenuItem.Click
        _prSeleccionarTodos("ycdel")
    End Sub

#End Region

#Region "Metodos y funciones indispensables"

    Private Sub P_prInicio()
        'Abrir conexión
        'L_prAbrirConexion()

        'Inicializar componentes
        P_prInicializarComponentes()

        'Habilitar/Deshabilitar compotentes del formulario
        P_prHDComponentes(False)

        'Armar todo las grillas
        BoNavegar = False
        P_PrArmarGrillas()
        BoNavegar = True

        P_prActualizarPaginacion(0)
        P_prLlenarDatos(0)
    End Sub


    Private Sub P_prInicializarComponentes()
        'Form

        Me.WindowState = FormWindowState.Maximized

        'Visible
        MBtImprimir.Visible = False

        'Enabled
        MBtGrabar.Enabled = False

        'ReadOnly
        tbNumi.ReadOnly = True

        'Grid Busqueda
        DgjBusqueda.AllowEdit = InheritableBoolean.False

        'Funciones
        P_prCambiarFuenteComponentes()

        'Usuario del sistema
        MTbUsuario.Text = gs_user

        _prCargarGridModulos()
    End Sub

    Private Sub P_prCambiarFuenteComponentes()
        Dim xCtrl As Control
        For Each xCtrl In MSuperTabControlPanelRegistro.Controls
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

        Dim dtRolUsu As DataTable = Nothing ' L_prRolDetalleGeneral(gi_userRol, _nameButton)

        Dim show As Boolean = dtRolUsu.Rows(0).Item("ycshow")
        Dim add As Boolean = dtRolUsu.Rows(0).Item("ycadd")
        Dim modif As Boolean = dtRolUsu.Rows(0).Item("ycmod")
        Dim del As Boolean = dtRolUsu.Rows(0).Item("ycdel")

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
        tbRol.ReadOnly = Not flat
        If flat Then
            grModulos.ContextMenuStrip = msModulos
        Else
            grModulos.ContextMenuStrip = Nothing
        End If

    End Sub

    Private Sub P_prLimpiar()
        tbRol.Clear()

        'VACIO EL DETALLE
        _prCargarGridDetalle(-1)

        MBtGrabar.Tooltip = "GRABAR"
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
                    Me.tbNumi.Text = .GetValue("ybnumi").ToString
                    Me.tbRol.Text = .GetValue("ybrol").ToString

                    'CARGAR DETALLE
                    _prCargarGridDetalle(tbNumi.Text)

                    MLbFecha.Text = CType(.GetValue("ybfact").ToString, Date).ToString("dd/MM/yyyy")
                    MLbHora.Text = .GetValue("ybhact").ToString
                    MLbUsuario.Text = .GetValue("ybuact").ToString
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
        tbRol.Select()
    End Sub

    Private Sub P_prModificarRegistro()
        P_prEstadoNueModEli(2)
        P_prHDComponentes(BoModificar)
        tbRol.SelectAll()
    End Sub

    Private Sub P_prEliminarRegistro()
        Dim numi As String = tbNumi.Text 'Valor del código único
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper,
                                       eTaskDialogIcon.Delete, "advertencia".ToUpper,
                                       "Esta a punto de eliminar el rol con".ToUpper _
                                       + vbCrLf + "código -> ".ToUpper _
                                       + numi + " " + vbCrLf + "Desea continuar?".ToUpper,
                                       eTaskDialogButton.Yes Or eTaskDialogButton.Cancel,
                                       eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""

            Dim res As Boolean = L_prRolBorrar(numi, mensajeError) 'Medoto de lógica para eliminar
            If (res) Then

                ToastNotification.Show(Me, "Codigo de rol: ".ToUpper + numi + " eliminado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA, InDuracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
                BoNavegar = False
                P_prArmarGrillaBusqueda()
                BoNavegar = True
                P_prMoverIndexActual()
            Else
                ToastNotification.Show(Me, mensajeError.ToUpper,
                                           My.Resources.I64x64_error, InDuracion * 1000,
                                           eToastGlowColor.Red,
                                           eToastPosition.TopCenter)
            End If

        End If
    End Sub

    Private Sub P_prGrabarRegistro()
        Dim numi As String = ""
        Dim rol As String
        Dim uact As String

        If (BoNuevo) Then
            If (P_fnValidarGrabacion()) Then
                rol = tbRol.Text.Trim
                uact = MTbUsuario.Text

                'Grabar
                Dim dtDetalle As DataTable = CType(grDetalle.DataSource, DataTable).DefaultView.ToTable(True, "ycline", "ycnumi", "ycyanumi", "ycshow", "ycadd", "ycmod", "ycdel", "estado")
                Dim res As Boolean = L_prRolGrabar(numi, rol, dtDetalle)

                If (res) Then

                    P_prLimpiar()
                    BoNavegar = False
                    P_prArmarGrillaBusqueda()
                    BoNavegar = True

                    tbRol.Select()
                    ToastNotification.Show(Me, "Codigo de rol ".ToUpper + numi + " Grabado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA,
                                       InDuracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
                Else
                    ToastNotification.Show(Me, "No se pudo grabar el codigo de rol ".ToUpper + numi + ", intente nuevamente.".ToUpper,
                                       My.Resources.WARNING,
                                       InDuracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)
                End If

            End If
        ElseIf (BoModificar) Then
            If (P_fnValidarGrabacion()) Then
                rol = tbRol.Text.Trim
                uact = MTbUsuario.Text


                'Grabar
                Dim dtDetalle As DataTable = CType(grDetalle.DataSource, DataTable).DefaultView.ToTable(True, "ycline", "ycnumi", "ycyanumi", "ycshow", "ycadd", "ycmod", "ycdel", "estado")
                Dim res As Boolean = L_prRolModificar(tbNumi.Text, tbRol.Text, dtDetalle)

                If (res) Then

                    BoNavegar = False
                    P_prArmarGrillaBusqueda()
                    BoNavegar = True

                    P_prMoverIndexActual()

                    tbRol.Select()
                    MBtSalir.PerformClick()

                    ToastNotification.Show(Me, "Codigo de rol ".ToUpper + tbNumi.Text + " Modificado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA,
                                       InDuracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
                Else
                    ToastNotification.Show(Me, "No se pudo modificar el codigo de rol ".ToUpper + tbNumi.Text + ", intente nuevamente.".ToUpper,
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

#End Region

#Region "Metodos y funciones generales"

    Private Sub _prSeleccionarTodos(columna As String)
        Dim dt As DataTable = CType(grDetalle.DataSource, DataTable)
        Dim numiModulo As String = grModulos.GetValue("cenum")
        Dim filasFiltradas As DataRow() = dt.Select("yamod=" + numiModulo)
        For Each fila As DataRow In filasFiltradas
            fila.Item(columna) = 1
            If fila.Item("estado") = 1 Then
                fila.Item("estado") = 2
            End If

        Next
    End Sub
    Private Sub _prCargarGridModulos()
        Dim dt As New DataTable
        dt = L_LibreriaGeneral(gi_LibSistema).Tables(0)

        grModulos.DataSource = dt
        grModulos.RetrieveStructure()

        'dar formato a las columnas
        With grModulos.RootTable.Columns("cenum")
            .Width = 50
            .Visible = False
        End With

        With grModulos.RootTable.Columns("cedesc")
            .Caption = "MODULO"
            .Width = 240
        End With


        With grModulos
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
            .AllowAddNew = InheritableBoolean.False
            .RowFormatStyle.BackColor = Color.AliceBlue
            .SelectionMode = SelectionMode.SingleSelection
            .SelectedFormatStyle.BackColor = Color.LightGreen
            .RowFormatStyle.BackColor = Color.MediumAquamarine

        End With



    End Sub
    Private Sub _prCargarGridDetalle(numi As String)
        Dim dt As New DataTable
        dt = L_prRolDetalleGeneral(numi)

        grDetalle.DataSource = dt
        grDetalle.RetrieveStructure()

        'dar formato a las columnas
        With grDetalle.RootTable.Columns("ycline")
            .Width = 50
            .Visible = False
            .EditType = EditType.NoEdit
        End With
        With grDetalle.RootTable.Columns("yamod")
            .Width = 50
            .Visible = False
            .EditType = EditType.NoEdit
        End With

        With grDetalle.RootTable.Columns("ycnumi")
            .Width = 50
            .Visible = False
            .EditType = EditType.NoEdit
        End With

        With grDetalle.RootTable.Columns("ycyanumi")
            .Caption = "COD"
            .Width = 70
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .EditType = EditType.NoEdit
        End With

        With grDetalle.RootTable.Columns("yaprog")
            .Caption = "NOMBRE"
            .Width = 150
            .EditType = EditType.NoEdit
        End With
        With grDetalle.RootTable.Columns("yatit")
            .Caption = "PROGRAMA"
            .Width = 150
            .EditType = EditType.NoEdit
        End With

        With grDetalle.RootTable.Columns("ycshow")
            .Caption = "SHOW"
            .Width = 100
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With
        With grDetalle.RootTable.Columns("ycadd")
            .Caption = "ADD"
            .Width = 100
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With
        With grDetalle.RootTable.Columns("ycmod")
            .Caption = "EDIT"
            .Width = 100
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With
        With grDetalle.RootTable.Columns("ycdel")
            .Caption = "DEL"
            .Width = 100
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        With grDetalle.RootTable.Columns("estado")
            .Visible = False
        End With

        With grDetalle
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
            .AllowAddNew = InheritableBoolean.False

        End With

        Dim fc As GridEXFormatCondition
        fc = New GridEXFormatCondition(grDetalle.RootTable.Columns("estado"), ConditionOperator.Equal, 0)
        fc.FormatStyle.BackColor = Color.LightGreen
        grDetalle.RootTable.FormatConditions.Add(fc)

        'filtro por la primera fila del modulo
        If dt.Rows.Count > 0 Then
            Dim numiModulo As String = grModulos.GetValue("cenum")
            Dim desc As String = grModulos.GetValue("cedesc")
            grDetalle.RemoveFilters()
            grDetalle.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grDetalle.RootTable.Columns("yamod"), Janus.Windows.GridEX.ConditionOperator.Equal, numiModulo))
            GroupPanel2.Text = "privilegios del modulo ".ToUpper + desc
        End If

        'sobrecargo el metodo selection change
        AddHandler grModulos.SelectionChanged, AddressOf grModulos_SelectionChanged

    End Sub

    Private Sub grModulos_SelectionChanged(sender As Object, e As EventArgs)
        Dim numiModulo As String = grModulos.GetValue("cenum")
        Dim desc As String = grModulos.GetValue("cedesc")
        grDetalle.RemoveFilters()
        grDetalle.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grDetalle.RootTable.Columns("yamod"), Janus.Windows.GridEX.ConditionOperator.Equal, numiModulo))
        GroupPanel2.Text = "privilegios del modulo ".ToUpper + desc
    End Sub

    Private Sub P_prArmarGrillaBusqueda()
        DtBusqueda = New DataTable
        DtBusqueda = L_prRolGeneral()

        DgjBusqueda.BoundMode = Janus.Data.BoundMode.Bound
        DgjBusqueda.DataSource = DtBusqueda
        DgjBusqueda.RetrieveStructure()

        'dar formato a las columnas
        'With DgjBusqueda.RootTable.Columns(0)
        '    .Caption = "Código"
        '    .Width = 80
        '    .HeaderStyle.Font = FtTitulo
        '    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .CellStyle.Font = FtNormal
        '    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        '    .Visible = True
        'End With
        'With DgjBusqueda.RootTable.Columns(1)
        '    .Caption = ""
        '    .Key = "cod"
        '    .Width = 0
        '    .HeaderStyle.Font = FtTitulo
        '    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .CellStyle.Font = FtNormal
        '    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        '    .Visible = False
        'End With
        'With DgjBusqueda.RootTable.Columns(2)
        '    .Caption = "Nombre"
        '    .Key = "desc"
        '    .Width = 350
        '    .HeaderStyle.Font = FtTitulo
        '    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .CellStyle.Font = FtNormal
        '    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '    .Visible = True
        'End With
        'With DgjBusqueda.RootTable.Columns(3)
        '    .Caption = "Nombre Corto"
        '    .Key = "desc2"
        '    .Width = 200
        '    .HeaderStyle.Font = FtTitulo
        '    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .CellStyle.Font = FtNormal
        '    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '    .Visible = True
        'End With
        'With DgjBusqueda.RootTable.Columns(4)
        '    .Caption = ""
        '    .Key = "cat"
        '    .Width = 0
        '    .HeaderStyle.Font = FtTitulo
        '    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .CellStyle.Font = FtNormal
        '    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        '    .Visible = False
        'End With
        'With DgjBusqueda.RootTable.Columns(5)
        '    .Caption = "Categoría"
        '    .Key = "ncat"
        '    .Width = 120
        '    .HeaderStyle.Font = FtTitulo
        '    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .CellStyle.Font = FtNormal
        '    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '    .Visible = True
        'End With
        'With DgjBusqueda.RootTable.Columns(6)
        '    .Caption = ""
        '    .Key = "nimg"
        '    .Width = 0
        '    .HeaderStyle.Font = FtTitulo
        '    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .CellStyle.Font = FtNormal
        '    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '    .Visible = False
        'End With
        'With DgjBusqueda.RootTable.Columns(7)
        '    .Caption = "Imagen"
        '    .Key = "img"
        '    .Width = 130
        '    .HeaderStyle.Font = FtTitulo
        '    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .CellStyle.Font = FtNormal
        '    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        '    .Visible = True
        'End With
        'With DgjBusqueda.RootTable.Columns(8)
        '    .Caption = "Stock"
        '    .Key = "stc"
        '    .Width = 80
        '    .HeaderStyle.Font = FtTitulo
        '    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .CellStyle.Font = FtNormal
        '    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .Visible = True
        'End With
        'With DgjBusqueda.RootTable.Columns(9)
        '    .Caption = "Estado"
        '    .Key = "est"
        '    .Width = 80
        '    .HeaderStyle.Font = FtTitulo
        '    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .CellStyle.Font = FtNormal
        '    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .Visible = True
        'End With
        'With DgjBusqueda.RootTable.Columns(10)
        '    .Caption = " Es Equipo?"
        '    .Key = "serie"
        '    .Width = 80
        '    .HeaderStyle.Font = FtTitulo
        '    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .CellStyle.Font = FtNormal
        '    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .Visible = False
        'End With
        'With DgjBusqueda.RootTable.Columns(11)
        '    .Caption = ""
        '    .Key = "com"
        '    .Width = 0
        '    .HeaderStyle.Font = FtTitulo
        '    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .CellStyle.Font = FtNormal
        '    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        '    .Visible = False
        'End With
        'With DgjBusqueda.RootTable.Columns(12)
        '    .Caption = ""
        '    .Key = "fing"
        '    .Width = 0
        '    .HeaderStyle.Font = FtTitulo
        '    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .CellStyle.Font = FtNormal
        '    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        '    .Visible = False
        'End With
        'With DgjBusqueda.RootTable.Columns(13)
        '    .Caption = ""
        '    .Key = "cemp"
        '    .Width = 0
        '    .HeaderStyle.Font = FtTitulo
        '    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .CellStyle.Font = FtNormal
        '    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        '    .Visible = False
        'End With
        'With DgjBusqueda.RootTable.Columns(14)
        '    .Caption = "EMPRESA"
        '    .Key = "ncemp"
        '    .Width = 150
        '    .HeaderStyle.Font = FtTitulo
        '    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .CellStyle.Font = FtNormal
        '    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '    .Visible = True
        'End With
        'With DgjBusqueda.RootTable.Columns(15)
        '    .Caption = ""
        '    .Key = "fact"
        '    .Width = 0
        '    .HeaderStyle.Font = FtTitulo
        '    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .CellStyle.Font = FtNormal
        '    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '    .Visible = False
        'End With
        'With DgjBusqueda.RootTable.Columns(16)
        '    .Caption = ""
        '    .Key = "hact"
        '    .Width = 0
        '    .HeaderStyle.Font = FtTitulo
        '    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .CellStyle.Font = FtNormal
        '    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        '    .Visible = False
        'End With
        'With DgjBusqueda.RootTable.Columns(17)
        '    .Caption = ""
        '    .Key = "uact"
        '    .Width = 0
        '    .HeaderStyle.Font = FtTitulo
        '    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '    .CellStyle.Font = FtNormal
        '    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '    .Visible = False
        'End With

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

        If (tbRol.Text = String.Empty) Then
            tbRol.BackColor = Color.Red
            MEP.SetError(tbRol, "ingrese el nombre del producto!".ToUpper)
            res = False
        Else
            tbRol.BackColor = Color.White
            MEP.SetError(tbRol, "")
        End If

        Return res
    End Function


#End Region

End Class