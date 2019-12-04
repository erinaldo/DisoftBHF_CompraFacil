Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class F01_Proveedor

#Region "Atributos"

    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

#End Region

#Region "Variables Globales"

    Dim FtTitulo As Font = New Font("Arial", gi_fuenteTamano + 1)
    Dim FtNormal As Font = New Font("Arial", gi_fuenteTamano)

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

    Private Sub P_Proveedor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
        Me.Text = "P R O V E E D O R"

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
        TbTelefono.ReadOnly = True

        P_Deshabilitar()

        'Armar grillas
        P_ArmarGrillas()

        'Navegación de registro
        P_ActualizarPuterosNavegacion()
        IndexReg = 0
        P_LlenarDatos(IndexReg)

        Bool = True

        P_prCambiarFuenteComponentes()
        P_prAsignarPermisos()
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
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "Esta a punto de eliminar el proveedor con código -> ".ToUpper + TbCodigo.Text + " " + Chr(13) + "Desea continuar?".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim res As Boolean = L_fnEliminarProveedor(TbCodigo.Text)
            If res Then
                ToastNotification.Show(Me, "Codigo de proveedor: ".ToUpper + TbCodigo.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
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
        Dim telf As String
        Dim email As String
        Dim rsocial As String
        Dim nit As String
        Dim est As String
        Dim obs As String

        TbNombre.Select()
        If (Nuevo) Then
            If (P_Validar()) Then
                'Cargar campos
                numi = TbCodigo.Text.Trim
                desc = TbNombre.Text.Trim
                telf = TbTelefono.Text
                email = TbEmail.Text
                rsocial = TbRazonSocial.Text
                nit = TbNit.Text
                If (SbEstado.Value) Then
                    est = "1"
                Else
                    est = "0"
                End If
                obs = TbObs.Text

                'Grabar cabecera
                Dim res As Boolean = L_fnGrabarProveedor(numi, desc, telf, email, rsocial, nit, est, obs)

                If (res) Then
                    P_Limpiar()
                    Bool = False
                    P_ArmarGrillaBusqueda()
                    Bool = True
                    MBtSalir.PerformClick()
                    ToastNotification.Show(Me, "Codigo de proveedor ".ToUpper + TbCodigo.Text + " Grabado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA,
                                       Duracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
                Else
                    ToastNotification.Show(Me, "No se pudo grabar el codigo de proveedor ".ToUpper + TbCodigo.Text + ", intente nuevamente.".ToUpper,
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
                telf = TbTelefono.Text
                email = TbEmail.Text
                rsocial = TbRazonSocial.Text
                nit = TbNit.Text
                If (SbEstado.Value) Then
                    est = "1"
                Else
                    est = "0"
                End If
                obs = TbObs.Text

                'Modificar
                Dim res As Boolean = L_fnModificarProveedor(numi, desc, telf, email, rsocial, nit, est, obs)

                If (res) Then
                    Bool = False
                    P_ArmarGrillaBusqueda()
                    Bool = True
                    MBtSalir.PerformClick()
                    ToastNotification.Show(Me, "Codigo de proveedor ".ToUpper + TbCodigo.Text + " Modificado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA,
                                       Duracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
                Else
                    ToastNotification.Show(Me, "No se pudo modificar el codigo de proveedor ".ToUpper + TbCodigo.Text + ", intente nuevamente.".ToUpper,
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
        TbTelefono.ReadOnly = False
        TbEmail.ReadOnly = False
        TbObs.ReadOnly = False
        TbRazonSocial.ReadOnly = False
        TbNit.ReadOnly = False

        'Botones
        SbEstado.IsReadOnly = False
    End Sub

    Private Sub P_Deshabilitar()
        'Componentes a habilitar
        TbNombre.ReadOnly = True
        TbTelefono.ReadOnly = True
        TbEmail.ReadOnly = True
        TbObs.ReadOnly = True
        TbRazonSocial.ReadOnly = True
        TbNit.ReadOnly = True

        'Botones
        SbEstado.IsReadOnly = True
    End Sub

    Private Sub P_Limpiar()
        'Componentes a limpiar
        TbCodigo.Clear()
        TbNombre.Clear()
        TbTelefono.Clear()
        TbEmail.Clear()
        TbObs.Clear()
        TbRazonSocial.Clear()
        TbNit.Clear()

        'Botones
        SbEstado.Value = True
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
                TbCodigo.Text = .Cells("numi").Value.ToString
                TbNombre.Text = .Cells("desc").Value.ToString
                TbTelefono.Text = .Cells("telf").Value.ToString
                TbEmail.Text = .Cells("email").Value.ToString
                TbRazonSocial.Text = .Cells("rsocial").Value.ToString
                TbNit.Text = .Cells("nit").Value.ToString
                SbEstado.Value = (.Cells("est").Value.ToString.Equals("ACTIVO"))
                TbObs.Text = .Cells("obs").Value.ToString
            End With

        Else
            If (IndexReg < 0) Then
                IndexReg = 0
            Else
                IndexReg = CantidadReg
            End If
        End If
    End Sub

    Private Sub P_ArmarGrillaBusqueda()
        DtCabecera = New DataTable
        DtCabecera = L_fnProveedores()

        Dgj1Busqueda.BoundMode = Janus.Data.BoundMode.Bound
        Dgj1Busqueda.DataSource = DtCabecera
        Dgj1Busqueda.RetrieveStructure()

        'dar formato a las columnas
        With Dgj1Busqueda.RootTable.Columns(0)
            .Caption = "Código"
            .Key = "numi"
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(1)
            .Caption = "Nombre"
            .Key = "desc"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(2)
            .Caption = "Teléfono"
            .Key = "telf"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(3)
            .Caption = "E-mail"
            .Key = "email"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(4)
            .Caption = "Razon Social"
            .Key = "rsocial"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(5)
            .Caption = "Nit"
            .Key = "nit"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(6)
            .Caption = "Estado"
            .Key = "est"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(7)
            .Caption = "Observación"
            .Key = "obs"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With

        With Dgj1Busqueda.RootTable.Columns(8)
            .Caption = ""
            .Key = "fact"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(9)
            .Caption = ""
            .Key = "hact"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(10)
            .Caption = ""
            .Key = "uact"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
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
        End With

    End Sub

    Public Function P_Validar() As Boolean
        Dim sms As String = ""

        If (TbNombre.Text = String.Empty) Then
            sms = "el nombre del documento no puede quedar vacio.".ToUpper
        End If

        If (TbTelefono.Text = String.Empty) Then
            TbTelefono.Text = "S/T"
        End If

        If (TbEmail.Text = String.Empty) Then
            TbEmail.Text = "S/E"
        End If

        If (TbRazonSocial.Text = String.Empty) Then
            TbRazonSocial.Text = "S/RS"
        End If

        If (TbNit.Text = String.Empty) Then
            TbNit.Text = "0"
        End If

        If (TbRazonSocial.Text = String.Empty) Then
            TbEmail.Text = "S/RS"
        End If

        If (TbObs.Text = String.Empty) Then
            TbObs.Text = "S/O"
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