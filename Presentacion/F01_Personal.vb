Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class F01_Personal

#Region "Atributos"

    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

#End Region

#Region "Variables Globales"

    Dim Duracion As Integer = 5 'Duracion es segundo de los mensajes tipo (Toast)
    Dim GrDatos As GridEXRow() 'Arreglo que tiene las filas actuales de la grilla de datos
    Dim DsGeneral As DataSet 'Dataset que contendra a todos los datatable
    Dim DtCabecera As DataTable 'Datatable de la cabecera
    Dim DtDetalle As DataTable 'Datatable del detalle de la cabecera
    Dim Nuevo As Boolean 'Variable en true cuando se presiona el boton nuevo
    Dim Modificar As Boolean 'Variable en true cuando se presiona el boton modificar
    Dim Eliminar As Boolean 'Variable en true cuando se presiona el boton eliminar
    Dim IndexReg As Integer 'Indice de navegación de registro
    Dim CantidadReg As Integer 'Cantidad de registro de la Tabla

    Dim Bool As Boolean = False

#End Region

#Region "Eventos"

    Private Sub P_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        P_Inicio()
    End Sub

    Private Sub MBtNuevo_Click(sender As Object, e As EventArgs) Handles MBtNuevo.Click
        P_Nuevo()
    End Sub

    Private Sub MBtModificar_Click(sender As Object, e As EventArgs) Handles MBtModificar.Click
        P_Modificar()
    End Sub

    Private Sub MBtEliminar_Click(sender As Object, e As EventArgs) Handles MBtEliminar.Click
        P_Eliminar()
    End Sub

    Private Sub MBtGrabar_Click(sender As Object, e As EventArgs) Handles MBtGrabar.Click
        P_Grabar()
    End Sub

    Private Sub MBtSalir_Click(sender As Object, e As EventArgs) Handles MBtSalir.Click
        P_Cancelar()
    End Sub

    Private Sub MBtPrimero_Click(sender As Object, e As EventArgs) Handles MBtPrimero.Click
        IndexReg = 0
        P_LlenarDatos(IndexReg)
        P_ActualizarPaginacion(IndexReg)
    End Sub

    Private Sub MBtAnterior_Click(sender As Object, e As EventArgs) Handles MBtAnterior.Click
        IndexReg -= 1
        P_LlenarDatos(IndexReg)
        P_ActualizarPaginacion(IndexReg)
    End Sub

    Private Sub MBtSiguiente_Click(sender As Object, e As EventArgs) Handles MBtSiguiente.Click
        IndexReg += 1
        P_LlenarDatos(IndexReg)
        P_ActualizarPaginacion(IndexReg)
    End Sub

    Private Sub MBtUltimo_Click(sender As Object, e As EventArgs) Handles MBtUltimo.Click
        IndexReg = CantidadReg
        P_LlenarDatos(IndexReg)
        P_ActualizarPaginacion(IndexReg)
    End Sub

    Private Sub Dgj1Busqueda_EditingCell(sender As Object, e As EditingCellEventArgs) Handles Dgj1Busqueda.EditingCell
        e.Cancel = True
    End Sub

    Private Sub Dgj1Busqueda_SelectionChanged(sender As Object, e As EventArgs) Handles Dgj1Busqueda.SelectionChanged
        If (Dgj1Busqueda.GetRows.Count > 0) Then
            If (Dgj1Busqueda.CurrentRow.RowIndex > -1 And Bool And Not MBtGrabar.Enabled) Then
                P_LlenarDatos(Dgj1Busqueda.CurrentRow.RowIndex)
            End If
        End If
    End Sub

    Private Sub TbPassMovil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TbPassMovil.KeyPress
        g_prValidarTextBox(1, e)
    End Sub

    Private Sub My_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If (MBtGrabar.Enabled) Then
            Dim info As New TaskDialogInfo("¿esta seguro de salir?".ToUpper,
                                           eTaskDialogIcon.Delete,
                                           "advertencia".ToUpper,
                                           "esta a punto de salir sin guardar cambios".ToUpper + vbCrLf + "Desea continuar?".ToUpper,
                                           eTaskDialogButton.Yes Or eTaskDialogButton.Cancel,
                                           eTaskDialogBackgroundColor.Blue)
            Dim result As eTaskDialogResult = TaskDialog.Show(info)
            If (result = eTaskDialogResult.Yes) Then
                Me.Dispose()
                Me.Close()
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "Metodos"

    Private Sub P_Inicio()
        'Abrir la conexion de la base de datos
        If (Not gb_ConexionAbierta) Then
            L_prAbrirConexion("localhost", "sersolinf", "321", "BDDistBHF")
        End If

        'Poner visible=false, los componente que no se ocuparan
        MBtImprimir.Visible = False

        'Poner titulo al formulario
        Me.Text = "P E R S O N A L"

        'Inizializar Componentes
        Me.WindowState = FormWindowState.Maximized

        'Me.BringToFront()

        'Inhabilitar el boton de grabar
        MBtGrabar.Enabled = False

        'Poner texto de salir a boton de cancelar
        MBtSalir.Tooltip = "SALIR"

        'Deshabilitar componentes
        'Campo del Codigo poner readonly
        TbCodigo.ReadOnly = True
        TbPassMovil.ReadOnly = True

        P_Deshabilitar()

        'Armar Combos
        P_prArmarCombos()

        'Armar grillas
        P_ArmarGrillas()

        'Navegación de registro
        P_ActualizarPuterosNavegacion()
        IndexReg = 0
        P_LlenarDatos(IndexReg)

        Bool = True

        MTbUsuario.Text = gs_user
    End Sub

    Private Sub P_Nuevo()
        P_Limpiar()
        MBtGrabar.Tooltip = "GRABAR NUEVO REGISTRO"
        P_Habilitar()
        TbNombre.Select()
        MRlAccion.Text = "NUEVO"
        P_EstadoNueModEli(1)
    End Sub

    Private Sub P_Modificar()
        MBtGrabar.Tooltip = "GRABAR MODIFICACIÓN DE REGISTRO"
        P_Habilitar()
        TbNombre.Select()
        MRlAccion.Text = "MODIFICAR"
        P_EstadoNueModEli(2)
    End Sub

    Private Sub P_Eliminar()
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "Esta a punto de eliminar el usuario movil con código -> ".ToUpper + TbCodigo.Text + " " + Chr(13) + "Desea continuar?".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim res As Boolean = L_fnEliminarPersonal(TbCodigo.Text)
            If res Then
                ToastNotification.Show(Me, "Codigo de usuario movil: ".ToUpper + TbCodigo.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                Bool = False
                P_ArmarGrillaBusqueda()
                Bool = True
                GrDatos = Nothing
                P_ActualizarPuterosNavegacion()
                P_LlenarDatos(IndexReg)
            Else
                ToastNotification.Show(Me, "", My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        End If
    End Sub

    Private Sub P_Grabar()
        'Campo de la Tabla
        Dim numi As String
        Dim desc As String
        Dim direc As String
        Dim telef As String
        Dim cat As String
        Dim sal As String
        Dim ci As String
        Dim obs As String
        Dim fnac As String
        Dim fing As String
        Dim fret As String
        Dim fot As String
        Dim est As String
        Dim eciv As String
        Dim plan As String
        Dim reloj As String

        TbNombre.Select()
        If (Nuevo) Then
            If (P_Validar()) Then
                'Cargar campos
                numi = TbCodigo.Text.Trim
                desc = TbNombre.Text.Trim
                direc = ""
                telef = "0"
                cat = cbTipo.Value.ToString
                sal = "0"
                ci = TbPassMovil.Text.Trim
                obs = ""
                fnac = CType("2000/01/01", Date).ToString("yyyy/MM/dd")
                fing = CType("2000/01/01", Date).ToString("yyyy/MM/dd")
                fret = CType("2000/01/01", Date).ToString("yyyy/MM/dd")
                fot = ""
                If (SbEstado.Value) Then
                    est = "1"
                Else
                    est = "0"
                End If
                eciv = "0"
                plan = "1"
                reloj = "1"

                'Grabar cabecera
                Dim res As Boolean = L_fnGrabarPersonal(numi, desc, direc, telef, cat, sal, ci, obs, fnac, fing,
                                                        fret, fot, est, eciv, plan, reloj)

                If (res) Then
                    P_Limpiar()
                    Bool = False
                    P_ArmarGrillaBusqueda()
                    Bool = True
                    MBtSalir.PerformClick()
                    ToastNotification.Show(Me, "Codigo de usuario movil ".ToUpper + TbCodigo.Text + " Grabado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA,
                                       Duracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
                Else
                    ToastNotification.Show(Me, "No se pudo grabar el codigo de usuario movil ".ToUpper + TbCodigo.Text + ", intente nuevamente.".ToUpper,
                                       My.Resources.WARNING,
                                       Duracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)
                End If
            End If
        ElseIf (Modificar) Then
            If (P_Validar()) Then
                'Cargar variables
                numi = TbCodigo.Text.Trim
                desc = TbNombre.Text.Trim
                direc = ""
                telef = "0"
                cat = cbTipo.Value.ToString
                sal = "0"
                ci = TbPassMovil.Text.Trim
                obs = ""
                fnac = CType("2000/01/01", Date).ToString("yyyy/MM/dd")
                fing = CType("2000/01/01", Date).ToString("yyyy/MM/dd")
                fret = CType("2000/01/01", Date).ToString("yyyy/MM/dd")
                fot = ""
                If (SbEstado.Value) Then
                    est = "1"
                Else
                    est = "0"
                End If
                eciv = "0"
                plan = "1"
                reloj = "1"

                'Modificar
                Dim res As Boolean = L_fnModificarPersonal(numi, desc, direc, telef, cat, sal, ci, obs, fnac, fing,
                                                           fret, fot, est, eciv, plan, reloj)

                If (res) Then
                    Bool = False
                    P_ArmarGrillaBusqueda()
                    Bool = True
                    MBtSalir.PerformClick()
                    ToastNotification.Show(Me, "Codigo de usuario movil ".ToUpper + TbCodigo.Text + " Modificado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA,
                                       Duracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
                Else
                    ToastNotification.Show(Me, "No se pudo modificar el codigo de usuario movil ".ToUpper + TbCodigo.Text + ", intente nuevamente.".ToUpper,
                                       My.Resources.WARNING,
                                       Duracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)
                End If
            End If
        End If
        P_ActualizarPuterosNavegacion()
    End Sub

    Private Sub P_Cancelar()
        If (Not MBtGrabar.Enabled) Then
            Me.Close()
            If (gb_ConexionAbierta) Then
                _modulo.Select()
                _tab.Close()
            End If
        Else
            P_Limpiar()
            P_Deshabilitar()
            GrDatos = Dgj1Busqueda.GetRows
            P_LlenarDatos(IndexReg)
            MRlAccion.Text = ""
        End If
        P_EstadoNueModEli(4)
    End Sub

    Private Sub P_EstadoNueModEli(val As Integer)
        Nuevo = (val = 1)
        Modificar = (val = 2)
        Eliminar = (val = 3)

        MBtNuevo.Enabled = (val = 4)
        MBtModificar.Enabled = (val = 4)
        MBtEliminar.Enabled = (val = 4)
        MBtGrabar.Enabled = Not (val = 4)

        If (val = 4) Then
            MBtSalir.Tooltip = "SALIR"
        Else
            MBtSalir.Tooltip = "CANCELAR"
        End If

        MBtPrimero.Enabled = (val = 4)
        MBtAnterior.Enabled = (val = 4)
        MBtSiguiente.Enabled = (val = 4)
        MBtUltimo.Enabled = (val = 4)
    End Sub

    Private Sub P_Habilitar()
        'Componentes a habilitar
        TbNombre.ReadOnly = False
        TbPassMovil.ReadOnly = False

        'MultiCombo
        cbTipo.ReadOnly = False

        'Botones
        SbEstado.IsReadOnly = False
    End Sub

    Private Sub P_Deshabilitar()
        'Componentes a habilitar
        TbNombre.ReadOnly = True
        TbPassMovil.ReadOnly = True

        'MultiCombo
        cbTipo.ReadOnly = True

        'Botones
        SbEstado.IsReadOnly = True
    End Sub

    Private Sub P_Limpiar()
        'Componentes a limpiar
        TbCodigo.Clear()
        TbNombre.Clear()
        TbPassMovil.Clear()

        'MultiCombo
        If (CType(cbTipo.DataSource, DataTable).Rows.Count > 0) Then
            cbTipo.SelectedIndex = 0
        Else
            cbTipo.Text = ""
        End If

        'Botones
        SbEstado.Value = True
    End Sub

    Private Sub P_prArmarCombos()
        P_prArmarComboTipoPersonal()
    End Sub

    Private Sub P_ArmarGrillas()
        P_ArmarGrillaBusqueda()
    End Sub

    Private Sub P_ActualizarPuterosNavegacion()
        If (GrDatos Is Nothing) Then
            GrDatos = Dgj1Busqueda.GetRows
        End If
        CantidadReg = Dgj1Busqueda.GetRows.Count - 1
        If (IndexReg > CantidadReg) Then
            IndexReg = CantidadReg
        End If
        P_ActualizarPaginacion(IndexReg)
    End Sub

    Private Sub P_ActualizarPaginacion(index As Integer)
        MLbPaginacion.Text = "Reg. " & index + 1 & " de " & CantidadReg + 1
    End Sub

    Private Sub P_LlenarDatos(index As Integer)
        If (index <= CantidadReg And index >= 0 And GrDatos.Count > 0) Then
            'Llenar los datos a los componentes
            With GrDatos(index)
                'Campos
                TbCodigo.Text = .Cells("cbnumi").Value.ToString
                TbNombre.Text = .Cells("cbdesc").Value.ToString
                TbPassMovil.Text = .Cells("cbci").Value.ToString

                cbTipo.Clear()
                If (CType(cbTipo.DataSource, DataTable).Rows.Count > 0) Then
                    cbTipo.SelectedText = .Cells("ncat").Value.ToString
                Else
                    cbTipo.Text = ""
                End If

                SbEstado.Value = (.Cells("cbest").Value.ToString.Equals("True"))
            End With

        Else
            If (IndexReg < 0) Then
                IndexReg = 0
            Else
                IndexReg = CantidadReg
            End If
        End If
    End Sub

    Private Sub P_prArmarComboTipoPersonal()
        Dim dt As New DataTable
        dt = L_fnObtenerTabla("cenum as [cod], cedesc as [desc]", "TC0051", "cecon=7")
        g_prArmarCombo(cbTipo, dt, 60, 150, "Código", "Tipo Personal")
    End Sub

    Private Sub P_ArmarGrillaBusqueda()
        DtCabecera = New DataTable
        DtCabecera = L_fnPersonal()

        Dgj1Busqueda.BoundMode = Janus.Data.BoundMode.Bound
        Dgj1Busqueda.DataSource = DtCabecera
        Dgj1Busqueda.RetrieveStructure()

        'dar formato a las columnas
        With Dgj1Busqueda.RootTable.Columns("cbnumi")
            .Caption = "Código"
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns("cbdesc")
            .Caption = "Nombre"
            .Width = 250
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns("cbdirec")
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns("cbtelef")
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns("cbcat")
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns("ncat")
            .Caption = "Tipo Personal"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns("cbsal")
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns("cbci")
            .Caption = "Pass Movil"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns("cbobs")
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns("cbfnac")
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns("cbfing")
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns("cbfret")
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns("cbfot")
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns("cbest")
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns("nest")
            .Caption = "Estado"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns("cbeciv")
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns("cbplan")
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns("cbreloj")
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns("cbfact")
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns("cbhact")
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns("cbuact")
            .Visible = False
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
            .SelectionMode = SelectionMode.SingleSelection
            .AlternatingColors = True
            .RecordNavigator = True
        End With

    End Sub

    Public Function P_Validar() As Boolean
        Dim sms As String = ""

        If (TbNombre.Text.Trim = String.Empty) Then
            sms = "el nombre del documento no puede quedar vacio."
        End If

        If (TbPassMovil.Text.Trim = String.Empty) Then
            If (sms = String.Empty) Then
                sms = "el password del usuario movil no puede quedar vacio."
            Else
                sms = sms + vbCrLf + "el password del usuario movil no puede quedar vacio."
            End If
        End If

        If (Not IsNumeric(cbTipo.Value)) Then
            If (sms = String.Empty) Then
                sms = "debe elegir un tipo de personal valido de la lista."
            Else
                sms = sms + vbCrLf + "debe elegir un tipo de personal valido de la lista."
            End If
        End If

        If (Not sms = String.Empty) Then
            ToastNotification.Show(Me, sms.ToUpper,
                       My.Resources.WARNING,
                       Duracion * 1000,
                       eToastGlowColor.Red,
                       eToastPosition.MiddleCenter)
            Return False
            Exit Function
        End If

        Return True
    End Function

#End Region

End Class