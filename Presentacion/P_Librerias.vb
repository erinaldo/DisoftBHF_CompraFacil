Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX

Public Class P_Librerias

#Region "Variables Lcales"
    'Dim _Dsencabezado As DataSet
    Dim _Pos As Integer
    Dim _Nuevo As Boolean
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

        bbtNuevo.Enabled = False
        bbtModificar.Enabled = False
        bbtEliminar.Enabled = False
        bbtGrabar.Enabled = True
        BubbleBar4.Enabled = True

        'habilitar adicion de nuevas filas en el grid de sueldos
        JGr_Detalle.AllowAddNew = InheritableBoolean.True
        JGr_Detalle.Enabled = True

    End Sub
    Private Sub _PInhabilitar()
        Tb_id.ReadOnly = True
        Tb_Desc.ReadOnly = True

        bbtNuevo.Enabled = True
        bbtModificar.Enabled = True
        bbtEliminar.Enabled = True
        bbtGrabar.Enabled = False
        BubbleBar4.Enabled = True

        JGr_Detalle.Enabled = False

        bbtGrabar.Image = My.Resources.GRABAR
        bbtGrabar.ImageLarge = My.Resources.GRABAR

        _PLimpiarErrores()
    End Sub
    Private Sub _PLimpiarErrores()
        EP1.Clear()
        Tb_Desc.BackColor = Color.White
    End Sub
    Private Sub _PLimpiar()
        Tb_id.Text = ""
        Tb_Desc.Text = ""

        'aumentado 
        Txt_Paginacion.Text = ""

        'limpiar grid detalle
        _PCargarGridDetalle(-1)
        'permitir adicion de nuevas columnas
        JGr_Detalle.AllowAddNew = InheritableBoolean.True

    End Sub
    Private Sub _PHabilitarFocus()

        HighLigthter_Focus.SetHighlightOnFocus(Tb_Desc, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        HighLigthter_Focus.SetHighlightOnFocus(JGr_Detalle, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)

        Tb_Desc.TabIndex = 1
        JGr_Detalle.TabIndex = 2

    End Sub


    Private Sub _PIniciarTodo()

        Me.Text = "L I B R E R I A S"
        Me.WindowState = FormWindowState.Maximized
        BBtn_Imprimir.Visible = False
        BBtn_Error.Visible = False
        _PFiltrar()
        _PInhabilitar()

        _PHabilitarFocus()

        ''_PCargarGridBuscador()

        SuperTabControl1.SelectedTabIndex = 0

        _pCambiarFuente()
    End Sub

    Private Sub _pCambiarFuente()
        Dim fuente As New Font("Tahoma", gi_fuenteTamano, FontStyle.Regular)
        Dim xCtrl As Control
        For Each xCtrl In PanelEx3.Controls
            Try
                xCtrl.Font = fuente
            Catch ex As Exception
            End Try
        Next

        For Each xCtrl In PanelEx4.Controls
            Try
                xCtrl.Font = fuente
            Catch ex As Exception
            End Try
        Next
        
    End Sub

    Private Sub _PFiltrar()
        _PCargarGridBuscador()
        If JGr_Buscador.RowCount <> 0 Then
            _Pos = 0
            _PMostrarRegistro(_Pos)
            If JGr_Buscador.RowCount > 0 Then
                BBtn_Inicio.Visible = True
                BBtn_Anterior.Visible = True
                BBtn_Siguiente.Visible = True
                BBtn_Ultimo.Visible = True
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
        
        Txt_Paginacion.Text = Str(_Pos + 1) + "/" + JGr_Buscador.RowCount.ToString
    End Sub
    Private Function _PValidar() As Boolean
        Dim _Error As Boolean = False

        If Tb_Desc.Text = "" Then
            Tb_Desc.BackColor = Color.Red
            EP1.SetError(Tb_Desc, "Ingrese descripcion!".ToUpper)
            _Error = True
        Else
            Tb_Desc.BackColor = Color.White
            EP1.SetError(Tb_Desc, "")
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
        If bbtGrabar.Enabled = False Then
            Exit Sub
        End If

        If bbtGrabar.Tag = 0 Then
            bbtGrabar.Tag = 1
            bbtGrabar.Image = My.Resources.CONFIRMACION
            bbtGrabar.ImageLarge = My.Resources.CONFIRMACION
            BubbleBar6.Refresh()
            Exit Sub
        Else
            bbtGrabar.Tag = 0
            bbtGrabar.Image = My.Resources.GRABAR
            bbtGrabar.ImageLarge = My.Resources.GRABAR
            BubbleBar6.Refresh()
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
        bbtNuevo.Enabled = True

        _PLimpiar()
        Tb_Desc.Focus()
        _Nuevo = True

    End Sub

    Private Sub _PModificarRegistro()
        _Nuevo = False
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
        If bbtGrabar.Enabled = True Then
            Dim _Result As MsgBoxResult
            _Result = MsgBox("¿ESTA SEGURO DE SALIR SIN GUARDAR?", MsgBoxStyle.YesNo, "Advertencia".ToUpper)
            If _Result = MsgBoxResult.Yes Then
                _PInhabilitar()
                _PFiltrar()
                bbtGrabar.Tag = 0
            End If
        Else
            Me.Close()
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


    Private Sub BBtn_Nuevo_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Nuevo.Click, bbtNuevo.Click
        _PNuevoRegistro()
    End Sub

    Private Sub BBtn_Modificar_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Modificar.Click, bbtModificar.Click
        _PModificarRegistro()
    End Sub

    Private Sub BBtn_Eliminar_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Eliminar.Click, bbtEliminar.Click
        _PEliminarRegistro()
    End Sub

    Private Sub BBtn_Grabar_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Grabar.Click, bbtGrabar.Click
        _PGrabarRegistro()
    End Sub

    Private Sub BBtn_Cancelar_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Cancelar.Click, bbtSalir.Click
        _PSalirRegistro()
    End Sub

    Private Sub P_BonosDescuentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _PIniciarTodo()
    End Sub

    Private Sub BBtn_Inicio_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Inicio.Click
        _PPrimerRegistro()
    End Sub

    Private Sub BBtn_Anterior_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Anterior.Click
        _PAnteriorRegistro()
    End Sub

    Private Sub BBtn_Siguiente_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Siguiente.Click
        _PSiguienteRegistro()
    End Sub

    Private Sub BBtn_Ultimo_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Ultimo.Click
        _PUltimoRegistro()
    End Sub
    Private Sub P_BonosDescuentos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FlyoutUsuario_PrepareContent(sender As Object, e As EventArgs) Handles FlyoutUsuario.PrepareContent
        If sender Is BubbleBar5 And bbtGrabar.Enabled = False Then
            Dim dtAud As DataTable = L_ObtenerAuditoria("TP002", "pb", "pbnumi=" + Tb_id.Text)
            If IsDBNull(dtAud.Rows(0).Item(0)) = True Then
                lbFecha.Text = ""
            Else
                lbFecha.Text = Convert.ToDateTime(dtAud.Rows(0).Item(0)).ToString("dd/MM/yyyy")
            End If
            lbHora.Text = dtAud.Rows(0).Item(1).ToString
            lbUsuario.Text = dtAud.Rows(0).Item(2).ToString
            FlyoutUsuario.BorderColor = Color.FromArgb(&HC0, 0, 0)
            FlyoutUsuario.Content = PanelUsuario
        End If

    End Sub

    Private Sub BBtn_Usuario_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Usuario.Click
        FlyoutUsuario_PrepareContent(BubbleBar5, e)
    End Sub

    Private Sub JGr_Detalle_KeyDown(sender As Object, e As KeyEventArgs) Handles JGr_Detalle.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Tb_Mes_KeyDown(sender As Object, e As KeyEventArgs) Handles Tb_Desc.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            PanelEx4.Focus()
            JGr_Detalle.Focus()
            JGr_Detalle.MoveTo(0) 'JGr_Detalle.NewRowPosition
            JGr_Detalle.Col = 1
        End If
    End Sub

    Private Sub P_BonosDescuentos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If bbtGrabar.Enabled = True Then
            If (MessageBox.Show("ESTA SEGURO DE SALIR SIN GUARDAR?", "AVERTENCIA", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK) Then
                Me.Dispose()
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If e.NewValue.ToString = "RESGITRO" And _Nuevo = False Then
            If JGr_Buscador.RowCount > 0 Then
                _Pos = 0
                _PMostrarRegistro(0)
            Else
                Txt_Paginacion.Text = 0
            End If

        End If
    End Sub

    Private Sub JGr_Detalle_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_Detalle.EditingCell
        If e.Column.Key <> "cedesc" Then
            e.Cancel = True
        End If
    End Sub

End Class