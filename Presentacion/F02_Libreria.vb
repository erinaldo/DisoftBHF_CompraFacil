Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar.Controls

Public Class F02_Libreria

#Region "Variables Lcales"
    'Dim _Dsencabezado As DataSet
    Dim _Pos As Integer
    Dim _Nuevo As Boolean

    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

#End Region

#Region "Metodos Privados"

    Private Sub _PCargarGridBuscador()
        Dim dt As New DataTable
        dt = L_General_LibreriaCabecera(0).Tables(0)

        JGr_Buscador.BoundMode = BoundMode.Bound
        JGr_Buscador.DataSource = dt
        JGr_Buscador.RetrieveStructure()

        'dar formato a las columnas
        With JGr_Buscador.RootTable.Columns("cdId")
            .Caption = "Codigo"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With

        With JGr_Buscador.RootTable.Columns("cdcon")
            .Caption = "Codigo"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.BackColor = Color.AliceBlue
        End With

        With JGr_Buscador.RootTable.Columns("cddesc")
            .Caption = "Nombre"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.BackColor = Color.AliceBlue
        End With

        With JGr_Buscador.RootTable.Columns("cdfact")
            .Caption = "Fecha"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Buscador.RootTable.Columns("cdhact")
            .Caption = "Hora"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Buscador.RootTable.Columns("cduact")
            .Caption = "Usuario"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        'Habilitar Filtradores
        With JGr_Buscador
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False

            'diseño de la grilla
            JGr_Buscador.VisualStyle = VisualStyle.Office2007
        End With


    End Sub

    Private Sub _PCargarGridDetalle(idCabecera As String)
        Dim dt As New DataTable
        dt = L_General_LibreriaDetalle(-1, idCabecera).Tables(0)

        JGr_Detalle.BoundMode = BoundMode.Bound
        JGr_Detalle.DataSource = dt
        JGr_Detalle.RetrieveStructure()

        'dar formato a las columnas
        With JGr_Detalle.RootTable.Columns("ceId")
            .Visible = False
            .Caption = "Codigo"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Detalle.RootTable.Columns("cecon")
            .Caption = "Codigo"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .DefaultValue = 0
            .Visible = False
        End With

        With JGr_Detalle.RootTable.Columns("cenum")
            .Caption = "Codigo"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Detalle.RootTable.Columns("cedesc")
            .Caption = "Descripcion"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        'Habilitar Filtradores
        With JGr_Detalle
            '.DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            '.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False

            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007

            .AllowAddNew = InheritableBoolean.False
        End With
    End Sub

    Private Sub _PHabilitar()
        Tb_Desc.ReadOnly = False

        MBtNuevo.Enabled = False
        MBtModificar.Enabled = False
        MBtEliminar.Enabled = False
        MBtGrabar.Enabled = True

        MBtPrimero.Enabled = False
        MBtAnterior.Enabled = False
        MBtSiguiente.Enabled = False
        MBtUltimo.Enabled = False

        'habilitar adicion de nuevas filas en el grid de sueldos
        JGr_Detalle.AllowAddNew = InheritableBoolean.True
        JGr_Detalle.Enabled = True

    End Sub
    Private Sub _PInhabilitar()
        Tb_id.ReadOnly = True
        Tb_Desc.ReadOnly = True

        MBtNuevo.Enabled = True
        MBtModificar.Enabled = True
        MBtEliminar.Enabled = True
        MBtGrabar.Enabled = False

        MBtPrimero.Enabled = True
        MBtAnterior.Enabled = True
        MBtSiguiente.Enabled = True
        MBtUltimo.Enabled = True

        JGr_Detalle.Enabled = False

        _PLimpiarErrores()
    End Sub
    Private Sub _PLimpiarErrores()
        MEP.Clear()
        Tb_Desc.BackColor = Color.White
    End Sub
    Private Sub _PLimpiar()
        Tb_id.Text = ""
        Tb_Desc.Text = ""

        'aumentado 
        MLbPaginacion.Text = ""

        'limpiar grid detalle
        _PCargarGridDetalle(-1)
        'permitir adicion de nuevas columnas
        JGr_Detalle.AllowAddNew = InheritableBoolean.True

    End Sub
    Private Sub _PHabilitarFocus()

        'HighLigthter_Focus.SetHighlightOnFocus(Tb_Desc, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        'HighLigthter_Focus.SetHighlightOnFocus(JGr_Detalle, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)

        Tb_Desc.TabIndex = 1
        JGr_Detalle.TabIndex = 2

    End Sub


    Private Sub _PIniciarTodo()

        If (Not gb_ConexionAbierta) Then
            L_prAbrirConexion("localhost", "sersolinf", "321", "BDDistBHF")
        End If

        Me.Text = "L I B R E R I A S"
        Me.WindowState = FormWindowState.Maximized
        MBtImprimir.Visible = False
        _PFiltrar()
        _PInhabilitar()

        _PHabilitarFocus()

        ''_PCargarGridBuscador()

        MSuperTabControlPrincipal.SelectedTabIndex = 0

        '_pCambiarFuente()
    End Sub

    'Private Sub _pCambiarFuente()
    '    Dim fuente As New Font("Tahoma", gi_fuenteTamano, FontStyle.Regular)
    '    Dim xCtrl As Control
    '    For Each xCtrl In PanelEx3.Controls
    '        Try
    '            xCtrl.Font = fuente
    '        Catch ex As Exception
    '        End Try
    '    Next

    '    For Each xCtrl In PanelEx4.Controls
    '        Try
    '            xCtrl.Font = fuente
    '        Catch ex As Exception
    '        End Try
    '    Next

    'End Sub

    Private Sub _PFiltrar()
        _PCargarGridBuscador()
        If JGr_Buscador.RowCount <> 0 Then
            _Pos = 0
            _PMostrarRegistro(_Pos)
            If JGr_Buscador.RowCount > 0 Then
                MBtPrimero.Visible = True
                MBtAnterior.Visible = True
                MBtSiguiente.Visible = True
                MBtUltimo.Visible = True
            End If
        End If

    End Sub
    Private Sub _PMostrarRegistro(_N As Integer)
        JGr_Buscador.Row = _N
        With JGr_Buscador
            Tb_id.Text = .GetValue("cdId").ToString
            Tb_Desc.Text = .GetValue("cddesc").ToString
        End With

        'cargar detalle
        _PCargarGridDetalle(Tb_id.Text)

        MLbPaginacion.Text = Str(_Pos + 1) + "/" + JGr_Buscador.RowCount.ToString
    End Sub
    Private Function _PValidar() As Boolean
        Dim _Error As Boolean = False

        If Tb_Desc.Text = "" Then
            Tb_Desc.BackColor = Color.Red
            MEP.SetError(Tb_Desc, "Ingrese descripcion!".ToUpper)
            _Error = True
        Else
            Tb_Desc.BackColor = Color.White
            MEP.SetError(Tb_Desc, "")
        End If

        If JGr_Detalle.RowCount = 0 Then
            ToastNotification.Show(Me, "ingrese por lo menos 1 fila en el detalle".ToUpper, My.Resources.WARNING, 3000, eToastGlowColor.Green, eToastPosition.BottomCenter)
            _Error = True
        Else
            Dim i As Integer
            With JGr_Detalle
                For i = 0 To .RowCount - 1
                    .Row = i
                    If .GetValue("cedesc").ToString = String.Empty Then
                        ToastNotification.Show(Me, "falta ingresar datos en el detalle".ToUpper, My.Resources.WARNING, 3000, eToastGlowColor.Green, eToastPosition.BottomCenter)
                        _Error = True
                        Exit For
                    End If
                Next
            End With
        End If

        Return _Error
    End Function

    Private Sub _PGrabarRegistro()
        Dim _Error As Boolean = False
        If _PValidar() Then
            Exit Sub
        End If
        If MBtGrabar.Enabled = False Then
            Exit Sub
        End If

        If _Nuevo Then

            L_Grabar_LibreriaCabecera(Tb_id.Text, Tb_id.Text, Tb_Desc.Text)

            'grabar detalle
            Dim i As Integer
            Dim num, desc As String
            With JGr_Detalle
                For i = 0 To .RowCount - 1
                    .Row = i
                    num = i + 1
                    desc = .GetValue("cedesc")
                    L_Grabar_LibreriaDetalle("", Tb_id.Text, "", desc)
                Next
            End With

            ToastNotification.Show(Me, "Codigo " + Tb_id.Text + " Grabado con Exito.", My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.BottomLeft)

            _Nuevo = False 'aumentado danny
            '_Modificar = False 'aumentado danny
            _PInhabilitar()
            _PFiltrar()
        Else

            L_Modificar_LibreriasCabecera(Tb_id.Text, Tb_id.Text, Tb_Desc.Text)
            'grabar detalle
            Dim i As Integer
            Dim num, desc, idDet As String
            With JGr_Detalle
                For i = 0 To .RowCount - 1
                    .Row = i
                    idDet = .GetValue("ceid").ToString
                    num = .GetValue("cenum").ToString
                    desc = .GetValue("cedesc").ToString
                    If idDet = String.Empty Then 'es una nueva libreria
                        L_Grabar_LibreriaDetalle("", Tb_id.Text, num, desc)
                    Else
                        L_Modificar_LibreriasDetalle(idDet, Tb_id.Text, num.ToString, desc)
                    End If
                Next
            End With

            ToastNotification.Show(Me, "Codigo " + Tb_id.Text + " Modificado con Exito.", My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.BottomLeft)

            _Nuevo = False 'aumentado danny
            '_Modificar = False 'aumentado danny
            _PInhabilitar()
            _PFiltrar()
        End If
    End Sub

    Private Sub _PNuevoRegistro()
        _PHabilitar()
        MBtNuevo.Enabled = True

        MBtSalir.Text = "CANCELAR"

        _PLimpiar()
        Tb_Desc.Focus()
        _Nuevo = True

    End Sub

    Private Sub _PModificarRegistro()
        _Nuevo = False
        MBtSalir.Text = "CANCELAR"
        '_Modificar = True
        _PHabilitar()
    End Sub

    Private Sub _PEliminarRegistro()
        Dim _Result As MsgBoxResult
        _Result = MsgBox("¿Esta seguro de Eliminar el Registro?".ToUpper, MsgBoxStyle.YesNo, "Advertencia".ToUpper)
        If _Result = MsgBoxResult.Yes Then
            L_Borrar_LibreriasCabecera(Tb_id.Text) 'ya borra la cabecera y el detalle

            _PFiltrar()
        End If
    End Sub

    Private Sub _PSalirRegistro()
        If MBtGrabar.Enabled = True Then
            Dim _Result As MsgBoxResult
            _Result = MsgBox("¿ESTA SEGURO DE SALIR SIN GUARDAR?", MsgBoxStyle.YesNo, "Advertencia".ToUpper)
            If _Result = MsgBoxResult.Yes Then
                _PInhabilitar()
                _PFiltrar()
                MBtGrabar.Tag = 0
                MBtSalir.Text = "SALIR"
            End If
        Else
            Me.Close()
            _modulo.Select()
            _tab.Close()
        End If
    End Sub


    Private Sub _PPrimerRegistro()
        If JGr_Buscador.RowCount > 0 Then
            _Pos = 0
            _PMostrarRegistro(_Pos)
        End If

    End Sub
    Private Sub _PAnteriorRegistro()
        If _Pos > 0 Then
            _Pos = _Pos - 1
            _PMostrarRegistro(_Pos)
        End If
    End Sub
    Private Sub _PSiguienteRegistro()
        If _Pos < JGr_Buscador.RowCount - 1 Then
            _Pos = _Pos + 1
            _PMostrarRegistro(_Pos)
        End If
    End Sub
    Private Sub _PUltimoRegistro()
        If JGr_Buscador.RowCount > 0 Then
            _Pos = JGr_Buscador.RowCount - 1
            _PMostrarRegistro(_Pos)
        End If
    End Sub



#End Region

    Private Sub My_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _PIniciarTodo()
    End Sub

    Private Sub F02_Libreria_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'Private Sub FlyoutUsuario_PrepareContent(sender As Object, e As EventArgs) Handles FlyoutUsuario.PrepareContent
    '    If sender Is BubbleBar5 And bbtGrabar.Enabled = False Then
    '        Dim dtAud As DataTable = L_ObtenerAuditoria("TP002", "pb", "pbnumi=" + Tb_id.Text)
    '        If IsDBNull(dtAud.Rows(0).Item(0)) = True Then
    '            lbFecha.Text = ""
    '        Else
    '            lbFecha.Text = Convert.ToDateTime(dtAud.Rows(0).Item(0)).ToString("dd/MM/yyyy")
    '        End If
    '        lbHora.Text = dtAud.Rows(0).Item(1).ToString
    '        lbUsuario.Text = dtAud.Rows(0).Item(2).ToString
    '        FlyoutUsuario.BorderColor = Color.FromArgb(&HC0, 0, 0)
    '        FlyoutUsuario.Content = PanelUsuario
    '    End If

    'End Sub

    'Private Sub BBtn_Usuario_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Usuario.Click
    '    FlyoutUsuario_PrepareContent(BubbleBar5, e)
    'End Sub

    Private Sub JGr_Detalle_KeyDown(sender As Object, e As KeyEventArgs) Handles JGr_Detalle.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Tb_Mes_KeyDown(sender As Object, e As KeyEventArgs) Handles Tb_Desc.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            JGr_Detalle.Focus()
            JGr_Detalle.MoveTo(0) 'JGr_Detalle.NewRowPosition
            JGr_Detalle.Col = 1
        End If
    End Sub

    Private Sub P_BonosDescuentos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MBtGrabar.Enabled = True Then
            If (MessageBox.Show("ESTA SEGURO DE SALIR SIN GUARDAR?", "AVERTENCIA", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK) Then
                Me.Dispose()
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As SuperTabStripSelectedTabChangedEventArgs) Handles MSuperTabControlPrincipal.SelectedTabChanged
        If e.NewValue.ToString = "RESGITRO" And _Nuevo = False Then
            If JGr_Buscador.RowCount > 0 Then
                _Pos = 0
                _PMostrarRegistro(0)
            Else
                MLbPaginacion.Text = 0
            End If

        End If
    End Sub

    Private Sub JGr_Detalle_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_Detalle.EditingCell
        If e.Column.Key <> "cedesc" Then
            e.Cancel = True
        End If
    End Sub

    Private Sub MBtNuevo_Click(sender As Object, e As EventArgs) Handles MBtNuevo.Click
        _PNuevoRegistro()
    End Sub

    Private Sub MBtModificar_Click(sender As Object, e As EventArgs) Handles MBtModificar.Click
        _PModificarRegistro()
    End Sub

    Private Sub MBtEliminar_Click(sender As Object, e As EventArgs) Handles MBtEliminar.Click
        _PEliminarRegistro()
    End Sub

    Private Sub MBtGrabar_Click(sender As Object, e As EventArgs) Handles MBtGrabar.Click
        _PGrabarRegistro()
    End Sub

    Private Sub MBtSalir_Click(sender As Object, e As EventArgs) Handles MBtSalir.Click
        _PSalirRegistro()
    End Sub

    Private Sub MBtPrimero_Click(sender As Object, e As EventArgs) Handles MBtPrimero.Click
        _PPrimerRegistro()
    End Sub

    Private Sub MBtAnterior_Click(sender As Object, e As EventArgs) Handles MBtAnterior.Click
        _PAnteriorRegistro()
    End Sub

    Private Sub MBtSiguiente_Click(sender As Object, e As EventArgs) Handles MBtSiguiente.Click
        _PSiguienteRegistro()
    End Sub

    Private Sub MBtUltimo_Click(sender As Object, e As EventArgs) Handles MBtUltimo.Click
        _PUltimoRegistro()
    End Sub
End Class