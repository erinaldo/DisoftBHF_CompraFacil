Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar

Public Class F0_ConceptoInventario

#Region "Variables Globales"

    Public VButon As Integer
    Public WActivar1 As Boolean
    Public WActivar2 As Boolean
    Dim Duracion As Integer = 5
    Public SW As Boolean
    Public SW2 As Boolean
    Dim DtBusqueda As DataTable
    Public gi_fuenteTamano As Integer = 10
    Dim GrDatos As GridEXRow()
    Dim IndexReg As Integer 'Indice de navegación de registro
    Dim CantidadReg As Integer 'Cantidad de registro de la Tabla

    Public Nuevo As Integer
    Public Modificar As Integer
    Public Eliminar As Integer

    Dim FtTitulo As Font = New Font("Arial", gi_fuenteTamano + 2, FontStyle.Bold Or FontStyle.Italic)
    Dim FtNormal As Font = New Font("Arial", gi_fuenteTamano, FontStyle.Regular)

    Dim BoBool As Boolean = False

#End Region

#Region "Atributos"

    Private StTitulo As String
    Private InTipo As Integer

    Public Property pStTitulo As String
        Get
            Return StTitulo
        End Get
        Set(value As String)
            StTitulo = value
        End Set
    End Property

    Public Property pInTipo As Integer
        Get
            Return InTipo
        End Get
        Set(value As Integer)
            InTipo = value
        End Set
    End Property

#End Region

#Region "Eventos"

    Private Sub F0_ConceptoInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicio()
    End Sub

#End Region

#Region "Metodos"

    Private Sub Inicio()
        'L_prAbrirConexion("", "", "", "")
        Me.Text = pStTitulo
        Me.WindowState = FormWindowState.Maximized

        SbMovimientoCliente.Visible = (pInTipo = 1)
        LbMovimientoCliente.Visible = (pInTipo = 1)

        P_Habilita_Deshabilitar(False)
        CargarDatosAlGrid()
        P_ActualizarPunterosNavegacion()
        IndexReg = 0
        P_LlenarDatos(IndexReg)
        BBtn_Grabar.Enabled = False
        BubbleBar1.Refresh()
        BBtn_Imprimir.Visible = False
        BBtn_Error.Visible = False

        BoBool = True
    End Sub

    Private Sub CargarDatosAlGrid()
        DtBusqueda = L_ObtenerDatosTCI001(pInTipo)
        GridBuscador.BoundMode = Janus.Data.BoundMode.Bound
        GridBuscador.DataSource = DtBusqueda
        GridBuscador.RetrieveStructure()

        With GridBuscador.RootTable.Columns(0)
            .Caption = "Código"
            .Key = "numi"
            .Width = 80
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With GridBuscador.RootTable.Columns(1)
            .Caption = "Descripción"
            .Key = "desc"
            .Width = 250
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With GridBuscador.RootTable.Columns(2)
            .Caption = ""
            .Key = "mov"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With GridBuscador.RootTable.Columns(3)
            .Caption = "Movimiento"
            .Key = "nmov"
            .Width = 120
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With GridBuscador.RootTable.Columns(4)
            .Caption = ""
            .Key = "movcli"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With GridBuscador.RootTable.Columns(5)
            .Caption = "Afecta Cliente"
            .Key = "nmovcli"
            .Width = 120
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = (pInTipo = 1)
        End With
        With GridBuscador.RootTable.Columns(6)
            .Caption = ""
            .Key = "tipo1"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With GridBuscador.RootTable.Columns(7)
            .Caption = ""
            .Key = "est"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With GridBuscador.RootTable.Columns(8)
            .Caption = "Estado"
            .Key = "nest"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With GridBuscador.RootTable.Columns(9)
            .Caption = ""
            .Key = "fact"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With GridBuscador.RootTable.Columns(10)
            .Caption = ""
            .Key = "hact"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With GridBuscador.RootTable.Columns(11)
            .Caption = ""
            .Key = "uact"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With

        With GridBuscador
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

#End Region

#Region "Habilitar y desabilitar Controles"
    Private Sub P_Habilita_Deshabilitar(SW)
        'Componentes a deshabilitar
        TbCodigo.Enabled = False
        TbDescripcion.ReadOnly = Not SW
        SbMovimiento.IsReadOnly = Not SW
        SbMovimientoCliente.IsReadOnly = Not SW
        SbEstado.IsReadOnly = Not SW
    End Sub
#End Region


#Region "Paginacion de Registros"
    Private Sub P_ActualizarPunterosNavegacion()
        If (GrDatos Is Nothing) Then
            GrDatos = GridBuscador.GetRows
        End If
        CantidadReg = GridBuscador.GetRows.Count - 1
        If (IndexReg > CantidadReg) Then
            IndexReg = CantidadReg
        End If
        P_ActualizarPaginacion(IndexReg)
    End Sub

    Private Sub P_ActualizarPaginacion(index As Integer)
        Txt_Paginacion.Text = "Reg. " & index + 1 & " de " & CantidadReg + 1
    End Sub
    Private Sub P_LlenarDatos(index As Integer)
        If (index <= CantidadReg And index >= 0 And GrDatos.Count > 0) Then
            With GrDatos(index)
                'Campos
                TbCodigo.Text = .Cells("numi").Value.ToString
                TbDescripcion.Text = .Cells("desc").Value.ToString

                SbMovimiento.Value = IIf(.Cells("mov").Value = 1, True, False)
                SbMovimientoCliente.Value = IIf(.Cells("movcli").Value = 1, True, False)
                SbEstado.Value = IIf(.Cells("est").Value = 1, True, False)
            End With

        Else
            If (IndexReg < 0) Then
                IndexReg = 0
            Else
                IndexReg = CantidadReg
            End If
        End If
    End Sub

    Private Sub BBtn_Siguiente_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Siguiente.Click
        IndexReg += 1
        P_LlenarDatos(IndexReg)
        P_ActualizarPaginacion(IndexReg)
    End Sub

    Private Sub BBtn_Anterior_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Anterior.Click
        IndexReg -= 1
        P_LlenarDatos(IndexReg)
        P_ActualizarPaginacion(IndexReg)
    End Sub

    Private Sub BBtn_Ultimo_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Ultimo.Click
        IndexReg = CantidadReg
        P_LlenarDatos(IndexReg)
        P_ActualizarPaginacion(IndexReg)
    End Sub

    Private Sub BBtn_Inicio_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Inicio.Click
        IndexReg = 0
        P_LlenarDatos(IndexReg)
        P_ActualizarPaginacion(IndexReg)
    End Sub

#End Region

#Region "Eventos de Controles"
    Private Sub BBtn_Nuevo_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Nuevo.Click
        VButon = 1
        LimpiarControles()
        P_Habilita_Deshabilitar(True)

        P_EstadoNueModEli(1)
        MRlAccion.Text = "NUEVO"
        CargarDatosAlGrid()
        GrDatos = Nothing
        TbDescripcion.Select()
        'P_ActualizarPunterosNavegacion()
    End Sub

    Private Sub BBtn_Cancelar_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Cancelar.Click
        If (BBtn_Grabar.Enabled) Then
            P_Habilita_Deshabilitar(False)
            LimpiarControles()
            P_EstadoNueModEli(4)
            GrDatos = Nothing
            P_ActualizarPunterosNavegacion()
            MRlAccion.Text = ""
            P_LlenarDatos(IndexReg)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub BBtn_Grabar_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Grabar.Click
        Dim numi As String
        Dim desc As String
        Dim mov As String
        Dim movcli As String
        Dim tipo1 As String
        Dim est As String

        TbDescripcion.Select()

        Select Case VButon
            Case 1
                numi = TbCodigo.Text.Trim
                desc = TbDescripcion.Text
                mov = IIf(SbMovimiento.Value, "1", "-1")
                movcli = IIf(SbMovimientoCliente.Value, "1", "0")
                tipo1 = pInTipo.ToString
                est = IIf(SbEstado.Value, "1", "0")

                Dim res As Boolean = L_AgregarDatosTCI001(numi, desc, mov, movcli, tipo1, est)
                If res = True Then
                    ToastNotification.Show(Me, "Código de concepto de inventario: ".ToUpper + numi + " grabado con exito.".ToUpper,
                                           My.Resources.GRABACION_EXITOSA,
                                           Duracion * 1000,
                                           eToastGlowColor.Blue,
                                           eToastPosition.TopCenter)
                End If
            Case 2
                numi = TbCodigo.Text.Trim
                desc = TbDescripcion.Text
                mov = IIf(SbMovimiento.Value, "1", "-1")
                movcli = IIf(SbMovimientoCliente.Value, "1", "0")
                tipo1 = pInTipo.ToString
                est = IIf(SbEstado.Value, "1", "0")

                Dim res As Boolean = L_ModificarDatosTCI001(numi, desc, mov, movcli, tipo1, est)
                If res = True Then
                    ToastNotification.Show(Me, "Código de concepto de inventario: ".ToUpper + numi + " modificado con exito.".ToUpper,
                                           My.Resources.GRABACION_EXITOSA,
                                           Duracion * 1000,
                                           eToastGlowColor.Blue,
                                           eToastPosition.TopCenter)
                End If
        End Select
        P_Habilita_Deshabilitar(False)
        LimpiarControles()
        GrDatos = Nothing
        BoBool = False
        CargarDatosAlGrid()
        BoBool = True
        P_ActualizarPunterosNavegacion()
        MRlAccion.Text = ""
        P_EstadoNueModEli(4)
        P_LlenarDatos(IndexReg)
    End Sub

    Private Sub P_EstadoNueModEli(val As Integer)
        Nuevo = (val = 1)
        Modificar = (val = 2)
        Eliminar = (val = 3)

        BBtn_Nuevo.Enabled = (val = 4)
        BBtn_Modificar.Enabled = (val = 4)
        BBtn_Eliminar.Enabled = (val = 4)
        BBtn_Grabar.Enabled = Not (val = 4)

        If (val = 4) Then
            BBtn_Cancelar.TooltipText = "SALIR"
        Else
            BBtn_Cancelar.TooltipText = "CANCELAR"
        End If

        BBtn_Siguiente.Enabled = (val = 4)
        BBtn_Ultimo.Enabled = (val = 4)
        BBtn_Anterior.Enabled = (val = 4)
        BBtn_Inicio.Enabled = (val = 4)

    End Sub

    Private Sub BBtn_Modificar_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Modificar.Click
        VButon = 2
        P_Habilita_Deshabilitar(True)
        P_EstadoNueModEli(2)
        MRlAccion.Text = "MODIFICAR"
        TbDescripcion.Select()
    End Sub
    Private Sub BBtn_Eliminar_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Eliminar.Click
        Dim numi As String = TbCodigo.Text 'Valor del código único
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper,
                                       eTaskDialogIcon.Delete, "advertencia".ToUpper,
                                       "Esta a punto de eliminar el concepto de inventario con código -> ".ToUpper _
                                       + numi + " " + Chr(13) + "Desea continuar?".ToUpper,
                                       eTaskDialogButton.Yes Or eTaskDialogButton.Cancel,
                                       eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim res As Boolean = L_EliminarDatosTCI001(numi) 'L_fnXBorrar(numi) 'Medoto de lógica para eliminar
            VButon = 3
            If (res) Then
                ToastNotification.Show(Me, "Codigo de concepto de inventario: ".ToUpper + numi + " eliminado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA, Duracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
                LimpiarControles()
                BoBool = False
                CargarDatosAlGrid()
                BoBool = True
                GrDatos = Nothing
                P_ActualizarPunterosNavegacion()
                P_LlenarDatos(IndexReg)
                VButon = 0
            Else
                ToastNotification.Show(Me, "No se pudo eliminar el concepto de inventario con código: ".ToUpper + numi + ", intente nuevamente.".ToUpper,
                                       My.Resources.WARNING, Duracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)
            End If
        End If
    End Sub

#End Region
#Region "Eventos de Controles Llenos"

    Private Sub SwitchButton1_ValueChanged(sender As Object, e As EventArgs) Handles SbMovimiento.ValueChanged
        If SbMovimiento.Value = True Then
            WActivar1 = True
        Else
            WActivar1 = False
        End If
    End Sub

    Private Sub SwitchButton2_ValueChanged(sender As Object, e As EventArgs) Handles SbMovimientoCliente.ValueChanged
        If SbMovimientoCliente.Value = True Then
            WActivar2 = True
        Else
            WActivar2 = False
        End If
    End Sub

    Private Sub LimpiarControles()
        TbCodigo.Clear()
        TbDescripcion.Clear()
        SbMovimiento.Value = True
        SbMovimientoCliente.Value = False
        SbEstado.Value = True
    End Sub

    Public Function validarControles()
        If TbCodigo.Text = "" Then
            TbCodigo.Focus()
            Return False
        End If
        If TbDescripcion.Text = "" Then
            TbDescripcion.Focus()
            Return False
        End If
        Return True
    End Function

#End Region

    Private Sub GridBuscador_EditingCell(sender As Object, e As EditingCellEventArgs) Handles GridBuscador.EditingCell
        e.Cancel = True
    End Sub

    Private Sub GridBuscador_SelectionChanged(sender As Object, e As EventArgs) Handles GridBuscador.SelectionChanged
        If (GridBuscador.GetRows.Count > 0) Then
            If (GridBuscador.CurrentRow.RowIndex > -1 And BoBool And Not BBtn_Grabar.Enabled) Then
                P_LlenarDatos(GridBuscador.CurrentRow.RowIndex)
            End If
        End If
    End Sub
End Class