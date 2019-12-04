Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports Janus.Windows.GridEX.EditControls
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports GMap.NET.MapProviders
Imports GMap.NET
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.ToolTips
Imports System.Drawing
Imports System.Threading
Imports System.Drawing.Text
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing
Imports CrystalDecisions.Shared
Imports System.Math
Public Class P_Mesas
    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

    Dim _Dsencabezado As DataSet
    Dim _Nuevo As Boolean
    Dim boSalir As Boolean = True
    Private _Pos As Integer
    Dim FilaSelectLote As DataRow = Nothing
    Dim InDuracion As Byte = 5
    Dim registro As Integer
    'Dim GrDatos As GridEXRow()
    'Dim dt As DataTable
    'Dim IndexReg As Integer
    Private Sub _PIniciarTodo()

        SuperTabControl1.SelectedTabIndex = 0
        _PInhabilitar()
        P_prArmarComboDistribuidor()
        _prCargarMesas()
        _prMostrarRegistro(0)

    End Sub
    Private Sub P_prArmarComboDistribuidor()
        Dim dt As DataTable
        dt = L_fnObtenerTabla("cbnumi as [cod], cbdesc as [desc]", "TC002", "cbcat=1")
        g_prArmarCombo(JMC_Repartidor, dt, 60, 200, "Código", "Repartidor")
    End Sub
    Public Sub g_prArmarCombo(cbj As MultiColumnCombo, dtCombo As DataTable,
                              Optional anchoCodigo As Integer = 60, Optional anchoDesc As Integer = 200,
                              Optional nombreCodigo As String = "Código", Optional nombreDescripción As String = "Nombre")
        With cbj.DropDownList
            .Columns.Clear()

            .Columns.Add(dtCombo.Columns("cod").ToString).Width = anchoCodigo
            .Columns(0).Caption = nombreCodigo
            .Columns(0).Visible = True

            .Columns.Add(dtCombo.Columns("desc").ToString).Width = anchoDesc
            .Columns(1).Caption = nombreDescripción
            .Columns(1).Visible = True

            .ValueMember = dtCombo.Columns("cod").ToString
            .DisplayMember = dtCombo.Columns("desc").ToString
            .DataSource = dtCombo
            .Refresh()
        End With
    End Sub
    Private Sub BBtn_Nuevo_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Nuevo.Click
        _PNuevoRegistro()
    End Sub
    Private Sub _PNuevoRegistro()
        _PHabilitar()
        BBtn_Nuevo.Enabled = True

        _PLimpiar()
        tb_Mesa.Focus()
        _Nuevo = True
        boSalir = False
    End Sub

    Private Sub _PHabilitar()
        'Tb_Id.ReadOnly = False
        tb_Mesa.Enabled = True
        JMC_Repartidor.Enabled = True
        tb_Estado.Enabled = True
        tb_Mesa.ReadOnly = False
        JMC_Repartidor.ReadOnly = False
        tb_Estado.IsReadOnly = False
        JGr_Detalle.Enabled = True
        JGrMesas.Enabled = True

        BBtn_Nuevo.Enabled = False
        BBtn_Modificar.Enabled = False
        BBtn_Eliminar.Enabled = False
        BBtn_Grabar.Enabled = True
    End Sub
    Private Sub _PLimpiar()
        Tb_Id.Text = String.Empty
        'Tb_Id.ReadOnly = False
        tb_Mesa.Text = String.Empty
        JMC_Repartidor.Value = Nothing
        JMC_Repartidor.SelectedIndex = -1
        tb_Estado.Value = True

        _prCargarDetalle(-1)
        With JGr_Detalle.RootTable.Columns("img")
            .Width = 80
            .Caption = "ELIMINAR"
            .CellStyle.ImageHorizontalAlignment = ImageHorizontalAlignment.Center
            .Visible = True
        End With
        _prAddDetalle()

        Txt_Paginacion.Text = String.Empty
    End Sub
    Private Sub _prAddDetalle()
        Dim Bin As New MemoryStream
        Dim img As New Bitmap(My.Resources.delete, 20, 20)
        img.Save(Bin, Imaging.ImageFormat.Png)
        CType(JGr_Detalle.DataSource, DataTable).Rows.Add(_fnSiguienteNumi() + 1, 0, 0, "", 1, 0, Bin.GetBuffer)
    End Sub
    Public Function _fnSiguienteNumi()
        Dim dt As DataTable = CType(JGr_Detalle.DataSource, DataTable)
        Dim rows() As DataRow = dt.Select("mbnumi=MAX(mbnumi)")
        If (rows.Count > 0) Then
            Return rows(rows.Count - 1).Item("mbnumi")
        End If
        Return 1

    End Function

    Private Sub BBtn_Cancelar_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Cancelar.Click
        _PSalirRegistro()
    End Sub
    Private Sub _PSalirRegistro()
        'If (BBtn_Grabar.Enabled) = False Then
        '    _modulo.Select()
        '    _tab.Close()
        'Else
        '    _PInhabilitar()
        '    _prCargarMesas()
        '    _prMostrarRegistro(0)
        'End If

        If (boSalir) Then
            'Me.Close()
            _modulo.Select()
            _tab.Close()
        Else
            _PInhabilitar()
            _prCargarMesas()
            _prMostrarRegistro(0)
            boSalir = True
        End If
    End Sub
    Private Sub _Limpiar()
        Tb_Id.Text = String.Empty
        tb_Mesa.Text = String.Empty
        JMC_Repartidor.Value = Nothing
        JMC_Repartidor.SelectedIndex = -1
        Txt_Paginacion.Text = String.Empty

    End Sub
    Private Sub _PInhabilitar()
        Tb_Id.ReadOnly = True
        tb_Mesa.ReadOnly = True
        JMC_Repartidor.ReadOnly = True
        tb_Estado.IsReadOnly = True

        Tb_Id.Enabled = False
        tb_Mesa.Enabled = False

        BBtn_Nuevo.Enabled = True
        BBtn_Modificar.Enabled = True
        BBtn_Eliminar.Enabled = True
        BBtn_Grabar.Enabled = False

        JMC_Repartidor.Enabled = False
        'tb_Estado.Enabled = False
        JGr_Detalle.Enabled = False

        BBtn_Grabar.Image = My.Resources.GRABAR
        BBtn_Grabar.ImageLarge = My.Resources.GRABAR

    End Sub
    Public Sub _prCargarIconELiminar()
        For i As Integer = 0 To CType(JGr_Detalle.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim Bin As New MemoryStream
            Dim img As New Bitmap(My.Resources.delete, 20, 20)
            img.Save(Bin, Imaging.ImageFormat.Png)
            CType(JGr_Detalle.DataSource, DataTable).Rows(i).Item("img") = Bin.GetBuffer
            JGr_Detalle.RootTable.Columns("img").Visible = True
        Next
    End Sub
    Public Sub _prEliminarFila()
        If (JGr_Detalle.Row >= 0) Then
            If (JGr_Detalle.RowCount >= 2) Then
                Dim estado As Integer = JGr_Detalle.GetValue("estado")
                Dim pos As Integer = -1
                Dim lin As Integer = JGr_Detalle.GetValue("mbnumi")
                _fnObtenerFilaDetalle(pos, lin)
                If (estado = 0) Then
                    CType(JGr_Detalle.DataSource, DataTable).Rows(pos).Item("estado") = -2

                End If
                If (estado = 1) Then
                    CType(JGr_Detalle.DataSource, DataTable).Rows(pos).Item("estado") = -1
                End If
                JGr_Detalle.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(JGr_Detalle.RootTable.Columns("estado"), Janus.Windows.GridEX.ConditionOperator.GreaterThanOrEqualTo, 0))

                JGr_Detalle.Select()
                JGr_Detalle.Col = 3
                JGr_Detalle.Row = JGr_Detalle.RowCount - 1
            End If
        End If


    End Sub
    Private Sub BBtn_Grabar_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Grabar.Click
        If _ValidarCampos() = False Then
            Exit Sub
        End If
        _PGrabarRegistro()
    End Sub
    Public Function _ValidarCampos() As Boolean
        If (JGr_Detalle.RowCount = 1) Then
            JGr_Detalle.Row = JGr_Detalle.RowCount - 1
            If (JGr_Detalle.GetValue("mbcodvendedor") = 0) Then
                Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
                ToastNotification.Show(Me, "Por Favor Seleccione  un vendedor".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                JGr_Detalle.Select()
                JGr_Detalle.Col = 3
                JGr_Detalle.Focus()
                Return False
            End If
        End If
        Return True
    End Function
    Private Sub _PGrabarRegistro()
        Dim _Error As Boolean = False
        Dim dtm As New DataTable
        dtm = L_fnVerificarMesa(tb_Mesa.Text)
        If P_Validar() Then
            If BBtn_Grabar.Tag = 0 Then
                BBtn_Grabar.Tag = 1
                BubbleBar1.Refresh()
                Exit Sub
            Else
                BBtn_Grabar.Tag = 0
                BubbleBar1.Refresh()
            End If

            If _Nuevo Then
                If dtm.Rows.Count > 0 Then
                    Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                    ToastNotification.Show(Me, "El número de mesa ya existe coloque otro número de mesa".ToUpper, img, 3500, eToastGlowColor.Red, eToastPosition.BottomCenter)
                Else

                    Dim res As Boolean = L_Mesas_Grabar(Tb_Id.Text, tb_Mesa.Text, JMC_Repartidor.Value, IIf(tb_Estado.Value, 1, 0), CType(JGr_Detalle.DataSource, DataTable))
                    If res Then
                        'actualizar el grid de buscador
                        _prCargarMesas()

                        ToastNotification.Show(Me, "Codigo de Mesa " + Tb_Id.Text + " Grabado con éxito.", My.Resources.OK, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                        _PLimpiar()
                        tb_Mesa.Focus()
                    Else
                        Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                        ToastNotification.Show(Me, "El código de mesa no pudo ser insertado".ToUpper, img, 2500, eToastGlowColor.Red, eToastPosition.BottomCenter)

                    End If
                End If
            Else
                Dim res As Boolean = L_Mesas_Modificar(Tb_Id.Text, tb_Mesa.Text, JMC_Repartidor.Value, IIf(tb_Estado.Value, 1, 0), CType(JGr_Detalle.DataSource, DataTable))

                ToastNotification.Show(Me, "Codigo Mesa " + Tb_Id.Text + " Modificado con Éxito.", My.Resources.OK, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)

                '_Nuevo = False
                _prCargarMesas()
                _PInhabilitar()
                boSalir = True


            End If
            'BBtn_Cancelar.InvokeClick(eEventSource.Mouse, Windows.Forms.MouseButtons.Right)
        End If
    End Sub

    Private Sub P_Mesas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _PIniciarTodo()
    End Sub

    Private Sub JGr_Detalle_KeyDown(sender As Object, e As KeyEventArgs) Handles JGr_Detalle.KeyDown

        If (e.KeyData = Keys.Enter) Then
            Dim f, c As Integer
            c = JGr_Detalle.Col
            f = JGr_Detalle.Row
            If (JGr_Detalle.Col = JGr_Detalle.RootTable.Columns("cbdesc").Index) Then
                If (JGr_Detalle.GetValue("cbdesc") <> String.Empty) Then
                    If (Not _fnVerificarMaxVendedores()) Then
                        Dim img2 As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
                        ToastNotification.Show(Me, "Solo puede agregar 4 Vendedores por repartidor".ToUpper, img2, 3000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                        Return
                    Else
                        _prAddDetalle()
                        _prCargarVendedores()
                    End If


                Else
                    ToastNotification.Show(Me, "Seleccione un Repartidor Por Favor", My.Resources.WARNING, 3000, eToastGlowColor.Red, eToastPosition.TopCenter)
                End If

            End If

salirIf:
        End If
        If (e.KeyData = Keys.Control + Keys.Enter) Then
            'And JGr_Detalle.Row >= 0 And JGr_Detalle.Col = JGr_Detalle.RootTable.Columns("Vendedor").Index
            Dim indexfil As Integer = JGr_Detalle.Row
            Dim indexcol As Integer = JGr_Detalle.Col
            _prCargarVendedores()

        End If
        If (e.KeyData = Keys.Escape And JGr_Detalle.Row >= 0) Then
            '_prEliminarFila()
        End If
    End Sub
    Private Sub _prCargarVendedores()
        'Dim dtname As DataTable = L_fnNameLabel()
        Dim dt As New DataTable

        dt = L_fnObtenerTabla("cbnumi as [cod], cbdesc as [desc]", "TC002", "cbcat=1")

        Dim listEstCeldas As New List(Of Modelo.Celda)

        listEstCeldas.Add(New Modelo.Celda("cbnumi,", True, "Código", 100))
        listEstCeldas.Add(New Modelo.Celda("desc", True, "Vendedor", 220))


        Dim frmAyuda As Modelo.ModeloAyuda2
        frmAyuda = New Modelo.ModeloAyuda2(1000, 87, dt, "", listEstCeldas, "Vendedor", "cbnumi")
        Dim tamano As Size = New Size((50 * 740) / 100, 590)

        frmAyuda.Size = tamano
        frmAyuda.ShowDialog()
        If frmAyuda.seleccionado = True Then
            Dim Row As Janus.Windows.GridEX.GridEXRow
            Row = frmAyuda.filaSelect
            Dim pos As Integer = -1
            JGr_Detalle.Row = JGr_Detalle.RowCount - 1

            _fnObtenerFilaDetalle(pos, JGr_Detalle.GetValue("mbnumi"))

            CType(JGr_Detalle.DataSource, DataTable).Rows(pos).Item("mbcodvendedor") = Row.Cells("cod").Value
            CType(JGr_Detalle.DataSource, DataTable).Rows(pos).Item("cbdesc") = Row.Cells("desc").Value

            'FilaSelectLote = Nothing
        End If

    End Sub
    Public Sub _fnObtenerFilaDetalle(ByRef pos As Integer, numi As Integer)
        For i As Integer = 0 To CType(JGr_Detalle.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim _numi As Integer = CType(JGr_Detalle.DataSource, DataTable).Rows(i).Item("mbnumi")
            If (_numi = numi) Then
                pos = i
                Return
            End If
        Next
    End Sub
    Private Sub _DesHabilitarProductos()
        JGr_Detalle.Select()
        JGr_Detalle.Col = 3
        JGr_Detalle.Row = JGr_Detalle.RowCount - 1
    End Sub
    Private Sub _prCargarMesas()
        Dim dt = New DataTable
        dt = L_fnMostrarTodos()
        JGrMesas.DataSource = dt
        JGrMesas.RetrieveStructure()
        JGrMesas.AlternatingColors = True

        With JGrMesas.RootTable.Columns("manumi")
            .Width = 80
            .Caption = "ID"
            .Visible = True

        End With
        With JGrMesas.RootTable.Columns("mamesa")
            .Width = 80
            .Caption = "MESA"
            .Visible = True

        End With
        With JGrMesas.RootTable.Columns("macodrepart")
            .Width = 150
            .Visible = True
            .Caption = "COD. REPARTIDOR"
        End With
        With JGrMesas.RootTable.Columns("cbdesc")
            .Width = 360
            .Visible = True
            .Caption = "NOMBRE REPARTIDOR"
        End With
        With JGrMesas.RootTable.Columns("maest")
            .Width = 90
            .Visible = False
            .Caption = "Estado"
        End With
        With JGrMesas
            ''diseño de la grilla
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
        If (dt.Rows.Count <= 0) Then
            _prCargarDetalle(-1)
        End If
    End Sub
    Private Sub _prCargarDetalle(_numi As String)
        Dim dt As New DataTable
        dt = L_fnDetalle(_numi)
        JGr_Detalle.DataSource = dt
        JGr_Detalle.RetrieveStructure()
        JGr_Detalle.AlternatingColors = True

        With JGr_Detalle.RootTable.Columns("mbnumi")
            .Width = 100
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Caption = "NUMI"
            .Visible = False

        End With
        With JGr_Detalle.RootTable.Columns("mb_manumi")
            .Width = 100
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Caption = "NRO. MESA"
            .Visible = False
        End With
        With JGr_Detalle.RootTable.Columns("mbcodvendedor")
            .Width = 90
            .Caption = "CÓDIGO"
            .Visible = True

        End With
        With JGr_Detalle.RootTable.Columns("cbdesc")
            .Width = 230
            .Caption = "VENDEDOR"
            .Visible = True
        End With
        With JGr_Detalle.RootTable.Columns("mbest")
            .Width = 160
            .Caption = "ESTADO"
            .Visible = False
        End With
        With JGr_Detalle.RootTable.Columns("estado")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        If (Tb_Id.ReadOnly = True) Then
            With JGr_Detalle.RootTable.Columns("img")
                .Width = 80
                .Caption = "Eliminar".ToUpper
                .CellStyle.ImageHorizontalAlignment = ImageHorizontalAlignment.Center
                .Visible = False
            End With
        Else
            With JGr_Detalle.RootTable.Columns("img")
                .Width = 80
                .Caption = "Eliminar".ToUpper
                .CellStyle.ImageHorizontalAlignment = ImageHorizontalAlignment.Center
                .Visible = True
            End With

        End If
        With JGr_Detalle
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007

        End With
    End Sub
    Public Sub _prMostrarRegistro(_N As Integer)
        With JGrMesas
            Tb_Id.Text = .GetValue("manumi")
            tb_Mesa.Text = .GetValue("mamesa")
            JMC_Repartidor.Value = .GetValue("macodrepart")
            tb_Estado.Value = .GetValue("maest")
        End With

        _prCargarDetalle(Tb_Id.Text)
        Txt_Paginacion.Text = Str(JGrMesas.Row + 1) + "/" + JGrMesas.RowCount.ToString

    End Sub
    Private Sub JGr_Detalle_CellValueChanged(sender As Object, e As ColumnActionEventArgs) Handles JGr_Detalle.CellValueChanged
        Dim lin As Integer = JGr_Detalle.GetValue("mbnumi")
        Dim pos As Integer = -1
        _fnObtenerFilaDetalle(pos, lin)
        'Dim estado As Integer = CType(JGr_Detalle.DataSource, DataTable).Rows(pos).Item("estado")
        'If (estado = 1) Then
        '    CType(JGr_Detalle.DataSource, DataTable).Rows(pos).Item("estado") = 2
        'End If
    End Sub

    Private Sub BBtn_Eliminar_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Eliminar.Click
        Dim numi As String = Tb_Id.Text
        Dim mensajeError As String = ""
        Dim ef = New Efecto
        ef.tipo = 2
        ef.Context = "¿esta seguro de eliminar el registro?".ToUpper
        ef.Header = "mensaje principal".ToUpper
        ef.ShowDialog()
        Dim bandera As Boolean = False
        bandera = ef.band
        If (bandera = True) Then

            Dim res As Boolean = L_Mesas_Eliminar(Tb_Id.Text, mensajeError)
            If res Then
                Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)

                ToastNotification.Show(Me, "Código de Mesa ".ToUpper + Tb_Id.Text + " eliminado con Exito.".ToUpper,
                                          img, 2000,
                                          eToastGlowColor.Green,
                                          eToastPosition.TopCenter)
                _prCargarMesas()
                '_PHabilitar()
                '_PLimpiar
            Else
                Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                ToastNotification.Show(Me, mensajeError, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            End If

        End If
    End Sub

    Private Sub JGrMesas_SelectionChanged(sender As Object, e As EventArgs) Handles JGrMesas.SelectionChanged

        If (JGrMesas.RowCount >= 0 And JGrMesas.Row >= 0) Then
            _prMostrarRegistro(JGrMesas.Row)
        End If
    End Sub

    Private Sub BBtn_Inicio_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Inicio.Click
        _PPrimerRegistro()
    End Sub
    Private Sub _PPrimerRegistro()
        Dim _MPos As Integer
        If JGrMesas.RowCount > 0 Then
            _MPos = 0
            JGrMesas.Row = _MPos
        End If
    End Sub

    Private Sub BBtn_Anterior_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Anterior.Click
        _PAnteriorRegistro()
    End Sub
    Private Sub _PAnteriorRegistro()
        Dim _MPos As Integer = JGrMesas.Row
        If _MPos > 0 And JGrMesas.RowCount > 0 Then
            _MPos = _MPos - 1
            JGrMesas.Row = _MPos
        End If
    End Sub
    Private Sub BBtn_Siguiente_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Siguiente.Click
        _PSiguienteRegistro()
    End Sub
    Private Sub _PSiguienteRegistro()
        Dim _pos As Integer = JGrMesas.Row
        If _pos < JGrMesas.RowCount - 1 And _pos >= 0 Then
            _pos = JGrMesas.Row + 1
            JGrMesas.Row = _pos
        End If
    End Sub
    Private Sub BBtn_Ultimo_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Ultimo.Click
        _PUltimoRegistro()
    End Sub
    Private Sub _PUltimoRegistro()
        Dim _pos As Integer = JGrMesas.Row
        If JGrMesas.RowCount > 0 Then
            _pos = JGrMesas.RowCount - 1
            JGrMesas.Row = _pos
        End If

    End Sub
    Private Sub JGr_Detalle_MouseClick(sender As Object, e As MouseEventArgs) Handles JGr_Detalle.MouseClick
        If (JGr_Detalle.RowCount >= 2) Then
            If (JGr_Detalle.CurrentColumn.Index = JGr_Detalle.RootTable.Columns("img").Index) Then
                _prEliminarFila()
            End If
        End If
    End Sub

    Private Sub JMC_Repartidor_TextChanged(sender As Object, e As EventArgs) Handles JMC_Repartidor.TextChanged
        JGr_Detalle.Col = 3
        JGr_Detalle.Focus()
    End Sub

    Private Sub BBtn_Modificar_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Modificar.Click
        _PHabilitar()
        _prCargarIconELiminar()
        _Nuevo = False
        BBtn_Modificar.Enabled = True
        boSalir = False
    End Sub

    Function _fnVerificarMaxVendedores()
        Dim max As Integer = 4
        Dim dt As DataTable = CType(JGr_Detalle.DataSource, DataTable)
        Dim cont As Integer = 1
        If JGr_Detalle.RowCount < max Then
            Return True
        End If
        'For i As Integer = 0 To dt.Rows.Count - 1 Step 1
        '    If (dt.Rows(i).Item("mbcodvendedor") > 0) Then
        '        cont += 1
        '        If (cont > max) Then
        '            Return False
        '        End If
        '    End If
        'Next
        Return False
    End Function
End Class