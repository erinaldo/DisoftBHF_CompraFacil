
Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports System.Drawing
Imports DevComponents.DotNetBar.Controls
Imports System.Threading
Imports System.Drawing.Text
Imports System.Reflection
Imports System.Runtime.InteropServices

Public Class F0G_MovimientoChoferEntrada

#Region "Variables Globales"
    Dim _codChofer As Integer = 0
    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

    Private boShow As Boolean = False
    Private boAdd As Boolean = False
    Private boModif As Boolean = False
    Private boDel As Boolean = False

    Dim _IdConciliacion As Integer = 0
    Dim _numiConciliacio As Integer = 0 ''Aqui se guardar el numi de la conciliacion
    Dim _icibid As String = ""

    Dim Bin As New MemoryStream
#End Region

#Region "Metodos Privados"
    Private Sub _IniciarTodo()
        MSuperTabControlPrincipal.SelectedTabIndex = 0
        If (Not gb_ConexionAbierta) Then
            L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        End If

        Me.Text = "C O N C I L I A C I O N    D E   P R O D U C T O S"
        Me.WindowState = FormWindowState.Maximized
        _prInhabiliitar()
        _prCargarComboLibreriaConcepto(cbConcepto)
        _prCargarVenta()
        'Dim blah As New Bitmap(New Bitmap(My.Resources.compra), 20, 20)
        'Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        'Me.Icon = ico

        MBtNuevo.Visible = False
        MBtEliminar.Visible = False
        _prAsignarPermisos()

        If (grmovimiento.RowCount > 0) Then
            _prMostrarRegistro(0)
        End If
    End Sub

    Private Sub _prCargarComboLibreriaConcepto(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
        Dim dt As New DataTable
        dt = L_prMovimientoChoferConcepto()
        With mCombo
            .DropDownList.Columns.Clear()
            .DropDownList.Columns.Add("cpnumi").Width = 60
            .DropDownList.Columns("cpnumi").Caption = "COD"
            .DropDownList.Columns.Add("cpdesc").Width = 250
            .DropDownList.Columns("cpdesc").Caption = "CONCEPTO"
            .ValueMember = "cpnumi"
            .DisplayMember = "cpdesc"
            .DataSource = dt
            .Refresh()
        End With
    End Sub
    Private Sub _prAsignarPermisos()
        Dim dtRolUsu() As DataRow = L_prRolDetalleGeneral(gi_userRol).Select("yaprog='" + _nameButton + "'")

        If (dtRolUsu.Count = 1) Then
            boShow = dtRolUsu(0).Item("ycshow")
            boAdd = dtRolUsu(0).Item("ycadd")
            boModif = dtRolUsu(0).Item("ycmod")
            boDel = dtRolUsu(0).Item("ycdel")
        End If

        'If boDel = False Then
        '    MBtEliminar.Visible = False
        'End If
        If boModif = False Then
            MBtModificar.Visible = False
        End If
        'If boAdd = False Then
        '    MBtNuevo.Visible = False
        'End If
        If boAdd = True Then
            MBtModificar.Visible = True
        End If
    End Sub
    Private Sub _prInhabiliitar()

        tbChofer.ReadOnly = True
        cbConcepto.ReadOnly = True
        tbObservacion.ReadOnly = True
        tbFecha.IsInputReadOnly = True

        ''''''''''
        MBtModificar.Enabled = True
        MBtGrabar.Enabled = False
        MBtNuevo.Enabled = True
        MBtEliminar.Enabled = True
        grmovimiento.Enabled = True
        MPanelToolBarNavegacion.Enabled = True

    End Sub
    Private Sub _prhabilitar()

        tbChofer.ReadOnly = False
        cbConcepto.ReadOnly = False
        tbObservacion.ReadOnly = False
        tbFecha.IsInputReadOnly = False
        grmovimiento.Enabled = False

        MBtGrabar.Enabled = True
    End Sub
    Public Sub _prFiltrar()
        'cargo el buscador
        Dim _Mpos As Integer
        _prCargarVenta()
        If grmovimiento.RowCount > 0 Then
            _Mpos = grmovimiento.RowCount - 1
            grmovimiento.Row = _Mpos
        Else
            _Limpiar()
            MLbPaginacion.Text = "0/0"
        End If
    End Sub
    Private Sub _Limpiar()

        tbChofer.Clear()
        tbObservacion.Clear()
        _codChofer = 0
        tbFecha.Value = Now.Date

        _IdConciliacion = 0

        MPnInferior.Visible = True

        tbChofer.Focus()
        rlEstado.Text = ""
    End Sub
    Public Sub _prMostrarRegistro(_N As Integer)
        '   a.ibid ,a.ibfdoc ,a.ibconcep ,b.cpdesc as concepto,a.ibobs ,a.ibest ,a.ibalm ,a.ibiddc ,a.ibidchof
        ',c.cbdesc as chofer ,a.ibidvent ,a.ibfact ,a.ibhact ,a.ibuact
        With grmovimiento
            lbcodigo.Text = .GetValue("ibid")
            tbFecha.Value = .GetValue("ibfdoc")
            _codChofer = .GetValue("ibidchof")
            cbConcepto.Value = .GetValue("ibconcep")
            tbObservacion.Text = .GetValue("ibobs")
            tbChofer.Text = .GetValue("chofer")
            MLbFecha.Text = CType(.GetValue("ibfact"), Date).ToString("dd/MM/yyyy")
            MLbHora.Text = .GetValue("ibhact").ToString
            MLbUsuario.Text = .GetValue("ibuact").ToString
            _prValidar(.GetValue("ieest"))
            _icibid = .GetValue("ibiddc")
        End With

        _prCrearTablaConciliacion()
        MLbPaginacion.Text = Str(grmovimiento.Row + 1) + "/" + grmovimiento.RowCount.ToString

        If (Not boModif And boAdd) Then
            If (Now.Date = Me.tbFecha.Value) Then
                MBtModificar.Enabled = True
            Else
                MBtModificar.Enabled = False
            End If
            MBtModificar.Refresh()
        End If
    End Sub
    Public Sub _prValidar(_estado As Integer)
        Select Case _estado
            Case 1
                MBtModificar.Enabled = True
                MBtEliminar.Enabled = True
                swestado.Value = True
                rlEstado.Text = "Accesible"
            Case 2
                MBtModificar.Enabled = True
                MBtEliminar.Enabled = True
                swestado.Value = True
                rlEstado.Text = "Consolidado"
            Case 3
                MBtModificar.Enabled = False
                MBtEliminar.Enabled = False
                swestado.Value = False
                rlEstado.Text = "Venta OK"
        End Select
    End Sub

    Private Sub _prCargarVenta()
        Dim dt As New DataTable

        If (tbTablet.Value = True) Then
            dt = L_prMovimientoChoferGeneralEntradaTop20(10)
        Else
            dt = L_prMovimientoChoferGeneralEntrada(10)
        End If

        grmovimiento.DataSource = dt
        grmovimiento.RetrieveStructure()
        grmovimiento.AlternatingColors = True

        With grmovimiento.RootTable.Columns("ibid")
            .Width = 220
            .Caption = "NRO CONCILIACION"
            .Visible = True
        End With

        With grmovimiento.RootTable.Columns("ibfdoc")
            .Width = 90
            .Visible = True
            .Caption = "FECHA"
            .FormatString = "yyyy/MM/dd"
        End With

        With grmovimiento.RootTable.Columns("ibconcep")
            .Width = 90
            .Visible = False
        End With

        With grmovimiento.RootTable.Columns("ibidconcil")
            .Width = 90
            .Visible = False
        End With

        With grmovimiento.RootTable.Columns("concepto")
            .Width = 250
            .Visible = True
            .Caption = "CONCEPTO"
        End With

        With grmovimiento.RootTable.Columns("ibobs")
            .Width = 250
            .Visible = True
            .Caption = "observacion".ToUpper
        End With

        With grmovimiento.RootTable.Columns("ibest")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With

        With grmovimiento.RootTable.Columns("ibalm")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With

        With grmovimiento.RootTable.Columns("ibiddc")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With

        With grmovimiento.RootTable.Columns("ibidchof")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With

        With grmovimiento.RootTable.Columns("chofer")
            .Width = 250
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            .Caption = "CHOFER"
        End With

        With grmovimiento.RootTable.Columns("ibidvent")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With

        With grmovimiento.RootTable.Columns("ibfact")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With

        With grmovimiento.RootTable.Columns("ibhact")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With

        With grmovimiento.RootTable.Columns("ibuact")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With

        With grmovimiento.RootTable.Columns("ieest")
            .Width = 90
            .Visible = False
        End With

        With grmovimiento
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With
        


    End Sub

    Public Function _fnAccesible()
        Return tbFecha.IsInputReadOnly = False
    End Function

    Public Sub _fnObtenerFilaDetalleConciliacion(ByRef pos As Integer, producto As Integer)
        For i As Integer = 0 To CType(grdetalle.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim _numi As Integer = CType(grdetalle.DataSource, DataTable).Rows(i).Item("canumi")
            If (_numi = producto) Then
                pos = i
                Return
            End If
        Next
    End Sub

    Public Function _ValidarCampos() As Boolean
        If (_codChofer <= 0) Then
            Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
            ToastNotification.Show(Me, "Por Favor Seleccione un Chofer con Ctrl+Enter".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            tbChofer.Focus()
            Return False
        End If
        Return True
    End Function

    Public Function _prGuardarDetalleAbmConciliacion(numi As String) As DataTable
        Dim Bin As New MemoryStream
        Dim img As New Bitmap(My.Resources.delete, 28, 28)
        img.Save(Bin, Imaging.ImageFormat.Png)
        Dim contador As Integer = 0 ''Este contador me indicara si hay detalle de devolucion insertado para cambiar el estado o poner en estado sin devolucion
        Dim detalleCopia As DataTable = L_prMovimientoChoferDetalleSalida(-1)
        For i As Integer = 0 To CType(grdetalle.DataSource, DataTable).Rows.Count - 1 Step 1
            'icid,icibid,iccprod ,iccant
            Dim data As Decimal = IIf(IsDBNull(CType(grdetalle.DataSource, DataTable).Rows(i).Item("DEVOLUCION")), 0, CType(grdetalle.DataSource, DataTable).Rows(i).Item("DEVOLUCION"))
            Dim estado As Integer = IIf(IsDBNull(CType(grdetalle.DataSource, DataTable).Rows(i).Item("estado")), 0, CType(grdetalle.DataSource, DataTable).Rows(i).Item("estado"))
            'a.icid ,a.icibid ,a.iccprod ,b.cadesc as producto,a.iccant ,Cast(null as image ) as img,1 as estado
            If (estado = 2) Then
                If (data > 0) Then
                    detalleCopia.Rows.Add(CType(grdetalle.DataSource, DataTable).Rows(i).Item("icid"), numi, CType(grdetalle.DataSource, DataTable).Rows(i).Item("canumi"), "", "", data, Bin.GetBuffer, estado)
                    contador += 1
                Else
                    detalleCopia.Rows.Add(CType(grdetalle.DataSource, DataTable).Rows(i).Item("icid"), numi, CType(grdetalle.DataSource, DataTable).Rows(i).Item("canumi"), "", "", data, Bin.GetBuffer, -1)
                End If
            Else
                If (estado = 0) Then
                    'If (data > 0) Then
                    detalleCopia.Rows.Add(0, numi, CType(grdetalle.DataSource, DataTable).Rows(i).Item("canumi"), "", "", data, Bin.GetBuffer, 0)
                        contador += 1
                    'End If
                End If
            End If
        Next
        Return detalleCopia
    End Function

    Public Sub _GuardarNuevo()
        'L_prMovimientoChoferGrabar(ByRef _ibid As String, _ibfdoc As String, _ibconcep As Integer, _ibobs As String, _ibidchof As Integer,
        '                                    detalle As DataTable)
    End Sub

    Private Sub _prGuardarModificado()
        Dim res As Boolean = L_prMovimientoChoferModificarSalida(lbcodigo.Text, tbFecha.Value.ToString("yyyy/MM/dd"),
                                                                 cbConcepto.Value, tbObservacion.Text, _codChofer,
                                                                 _prGuardarDetalleAbmConciliacion(0), _icibid)
        If res Then
            '----------Se lo comento para que no grabe los pedidos moviles en la conciliación
            'Dim dt As DataTable = New DataTable
            'With dt.Columns
            '    .Add("idnumi", Type.GetType("System.Int32"))
            '    .Add("idtm1id", Type.GetType("System.Int32"))
            '    .Add("idto1numi", Type.GetType("System.Int32"))
            '    .Add("idtipo", Type.GetType("System.Int32"))
            '    .Add("estado", Type.GetType("System.Int32"))
            'End With

            'For Each fil As GridEXRow In grdetalle.GetRows
            '    Dim cad As String() = fil.Cells("ID_TO1").Value.ToString.Split(",")
            '    For Each i As String In cad
            '        If (Not i = String.Empty) Then
            '            If (dt.Select("idto1numi=" + i).Count = 0) Then
            '                dt.Rows.Add({0, lbcodigo.Text, CInt(i), 1, 0})
            '            End If
            '        End If
            '    Next
            'Next

            'L_prMovimientoChoferInsertarEnlacePedidoMovil(lbcodigo.Text, dt)
            _prCargarVenta()
            _prSalir()

            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me,
                                   "Código de Movimiento ".ToUpper + lbcodigo.Text + " Modificado con Exito.".ToUpper,
                                   img,
                                   2000,
                                   eToastGlowColor.Green,
                                   eToastPosition.TopCenter)
        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me,
                                   "La Venta no pudo ser Modificada".ToUpper,
                                   img,
                                   2000,
                                   eToastGlowColor.Red,
                                   eToastPosition.BottomCenter)
        End If
    End Sub
    Private Sub _prSalir()
        If MBtGrabar.Enabled = True Then
            _prInhabiliitar()
            If grmovimiento.RowCount > 0 Then
                _prMostrarRegistro(0)
            End If
            MBtSalir.Text = "SALIR"
        Else
            Me.Close()
            _modulo.Select()
            _tab.Close()
        End If
    End Sub

    Public Sub _PrimerRegistro()
        Dim _MPos As Integer
        If grmovimiento.RowCount > 0 Then
            _MPos = 0
            ''   _prMostrarRegistro(_MPos)
            grmovimiento.Row = _MPos
        End If
    End Sub
#End Region

    Private Sub F0G_MovimientoChofer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _IniciarTodo()
    End Sub

    Private Sub MBtNuevo_Click(sender As Object, e As EventArgs) Handles MBtNuevo.Click
        _Limpiar()
        _prhabilitar()

        MBtNuevo.Enabled = False
        MBtModificar.Enabled = False
        MBtEliminar.Enabled = False
        MBtGrabar.Enabled = True
        MPanelToolBarNavegacion.Enabled = False
    End Sub

    Private Sub MBtSalir_Click(sender As Object, e As EventArgs) Handles MBtSalir.Click
        _prSalir()
    End Sub

    Private Sub grdetalle_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grdetalle.EditingCell
        If (_fnAccesible()) Then
            If (cbConcepto.Value = 10) Then
                If (e.Column.Index = grdetalle.RootTable.Columns("DEVOLUCION").Index) Then
                    e.Cancel = False
                Else
                    e.Cancel = True
                End If
            End If
        Else
            e.Cancel = True
        End If
    End Sub


    Private Sub grdetalle_CellValueChanged(sender As Object, e As ColumnActionEventArgs) Handles grdetalle.CellValueChanged


        Dim lin As Integer = grdetalle.GetValue("canumi")
        Dim pos As Integer = -1
        _fnObtenerFilaDetalleConciliacion(pos, lin)
        If (e.Column.Index = grdetalle.RootTable.Columns("DEVOLUCION").Index) Then
            If (Not IsNumeric(grdetalle.GetValue("DEVOLUCION")) Or grdetalle.GetValue("DEVOLUCION").ToString = String.Empty) Then

                CType(grdetalle.DataSource, DataTable).Rows(pos).Item("DEVOLUCION") = 0
                grdetalle.SetValue("TOTAL", CType(grdetalle.DataSource, DataTable).Rows(pos).Item("TOTALCOPIA"))
            Else
                Dim data As Decimal = grdetalle.GetValue("DEVOLUCION")
                Dim TotalCopias As Decimal = grdetalle.GetValue("TOTALCOPIA")
                If ((data > 0) And (data <= TotalCopias)) Then

                    Dim devolucion As Decimal = IIf(IsDBNull(grdetalle.GetValue("DEVOLUCION")), 0, grdetalle.GetValue("DEVOLUCION"))
                    Dim total As Decimal = CType(grdetalle.DataSource, DataTable).Rows(pos).Item("TOTALCOPIA") - devolucion
                    CType(grdetalle.DataSource, DataTable).Rows(pos).Item("TOTAL") = CType(grdetalle.DataSource, DataTable).Rows(pos).Item("TOTALCOPIA") - devolucion
                    grdetalle.SetValue("TOTAL", total)
                    'Dim estado As Integer = CType(grdetalle.DataSource, DataTable).Rows(pos).Item("estado")

                    'If (estado = 1) Then
                    '    CType(grdetalle.DataSource, DataTable).Rows(pos).Item("estado") = 2
                    'End If

                Else

                    CType(grdetalle.DataSource, DataTable).Rows(pos).Item("DEVOLUCION") = 0
                    grdetalle.SetValue("TOTAL", CType(grdetalle.DataSource, DataTable).Rows(pos).Item("TOTALCOPIA"))
                End If
            End If
            Dim estado As Integer = IIf(IsDBNull(CType(grdetalle.DataSource, DataTable).Rows(pos).Item("estado")), 0, CType(grdetalle.DataSource, DataTable).Rows(pos).Item("estado"))
            If (estado = 1) Then
                CType(grdetalle.DataSource, DataTable).Rows(pos).Item("estado") = 2
            End If
        End If



    End Sub

    Private Sub grdetalle_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles grdetalle.CellEdited

        ''''Aqui la conciliacion
        'TablaPrincipal.Columns.Add("DEVOLUCION")
        'TablaPrincipal.Columns.Add("TOTAL")
        'TablaPrincipal.Columns.Add("TOTALCOPIA")
        If (e.Column.Index = grdetalle.RootTable.Columns("DEVOLUCION").Index) Then
            If (Not IsNumeric(grdetalle.GetValue("DEVOLUCION")) Or grdetalle.GetValue("DEVOLUCION").ToString = String.Empty) Then

                grdetalle.SetValue("DEVOLUCION", 0)
                grdetalle.SetValue("TOTAL", grdetalle.GetValue("TOTALCOPIA"))
            Else
                Dim data As Decimal = grdetalle.GetValue("DEVOLUCION")
                Dim TotalCopias As Decimal = grdetalle.GetValue("TOTALCOPIA")
                If ((data > 0) And (data <= TotalCopias)) Then


                Else

                    grdetalle.SetValue("DEVOLUCION", 0)
                    grdetalle.SetValue("TOTAL", grdetalle.GetValue("TOTALCOPIA"))
                End If
            End If
            If (gi_adev = 1) Then
                If (IsDBNull(grdetalle.GetValue("estado"))) Then
                    If (IIf(IsDBNull(grdetalle.GetValue("DEVOLUCION")), 0, grdetalle.GetValue("DEVOLUCION")) = grdetalle.GetValue("TOTALCOPIA") - IIf(IsDBNull(grdetalle.GetValue("DevCopia")), 0, grdetalle.GetValue("DevCopia"))) Then
                        CType(grdetalle.DataSource, DataTable).Rows(grdetalle.Row).Item("FiltroEstado") = True
                        _prCargarIcono(grdetalle.Row, grdetalle.DataSource, True)
                    Else
                        CType(grdetalle.DataSource, DataTable).Rows(grdetalle.Row).Item("FiltroEstado") = False
                        _prCargarIcono(grdetalle.Row, grdetalle.DataSource, False)
                        MessageBox.Show("LOS SALDOS DE ENTRADA Y SALIDA NO CUADRAN!", "AVERTENCIA", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub grdetalle_MouseClick(sender As Object, e As MouseEventArgs) Handles grdetalle.MouseClick
        If (Not _fnAccesible()) Then
            Return
        End If



    End Sub

    Private Sub MBtGrabar_Click(sender As Object, e As EventArgs) Handles MBtGrabar.Click
        If _ValidarCampos() = False Then
            Exit Sub
        End If
        If (lbcodigo.Text = String.Empty) Then
            _GuardarNuevo()
        Else
            If (lbcodigo.Text <> String.Empty) Then
                _prGuardarModificado()
            End If
        End If
    End Sub

    Private Sub MBtModificar_Click(sender As Object, e As EventArgs) Handles MBtModificar.Click
        If (grmovimiento.RowCount > 0) Then
            _prhabilitar()
            MBtNuevo.Enabled = False
            MBtModificar.Enabled = False
            MBtEliminar.Enabled = False
            MBtGrabar.Enabled = True

            MPanelToolBarNavegacion.Enabled = False
            MBtSalir.Text = "CANCELAR"
        End If

    End Sub

    Private Sub MBtEliminar_Click(sender As Object, e As EventArgs) Handles MBtEliminar.Click
        Dim ef = New Efecto

        ef.tipo = 2
        ef.Context = "¿esta seguro de eliminar el registro?".ToUpper
        ef.Header = "mensaje principal".ToUpper
        ef.ShowDialog()
        Dim bandera As Boolean = False
        bandera = ef.band
        If (bandera = True) Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_prMovimientoChofeEliminarSalida(lbcodigo.Text, _icibid)
            If res Then
                Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)

                ToastNotification.Show(Me, "Código de Movimiento ".ToUpper + lbcodigo.Text + " eliminado con Exito.".ToUpper,
                                          img, 2000,
                                          eToastGlowColor.Green,
                                          eToastPosition.TopCenter)

                _prFiltrar()
            Else
                Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                ToastNotification.Show(Me, mensajeError, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            End If
        End If
    End Sub

    Private Sub grmovimiento_SelectionChanged(sender As Object, e As EventArgs) Handles grmovimiento.SelectionChanged
        If (grmovimiento.RowCount >= 0 And grmovimiento.Row >= 0) Then
            _prMostrarRegistro(grmovimiento.Row)
        End If
    End Sub

    Private Sub MBtSiguiente_Click(sender As Object, e As EventArgs) Handles MBtSiguiente.Click
        Dim _pos As Integer = grmovimiento.Row
        If _pos < grmovimiento.RowCount - 1 Then
            _pos = grmovimiento.Row + 1
            '' _prMostrarRegistro(_pos)
            grmovimiento.Row = _pos
        End If
    End Sub

    Private Sub MBtUltimo_Click(sender As Object, e As EventArgs) Handles MBtUltimo.Click
        Dim _pos As Integer = grmovimiento.Row
        If grmovimiento.RowCount > 0 Then
            _pos = grmovimiento.RowCount - 1
            ''  _prMostrarRegistro(_pos)
            grmovimiento.Row = _pos
        End If
    End Sub

    Private Sub MBtAnterior_Click(sender As Object, e As EventArgs) Handles MBtAnterior.Click
        Dim _MPos As Integer = grmovimiento.Row
        If _MPos > 0 And grmovimiento.RowCount > 0 Then
            _MPos = _MPos - 1
            ''  _prMostrarRegistro(_MPos)
            grmovimiento.Row = _MPos
        End If
    End Sub

    Private Sub MBtPrimero_Click(sender As Object, e As EventArgs) Handles MBtPrimero.Click
        _PrimerRegistro()
    End Sub

    Private Sub grmovimiento_KeyDown(sender As Object, e As KeyEventArgs) Handles grmovimiento.KeyDown
        If e.KeyData = Keys.Enter Then
            MSuperTabControlPrincipal.SelectedTabIndex = 0
            grdetalle.Focus()

        End If
    End Sub

    Private Sub grdetalle_Enter(sender As Object, e As EventArgs) Handles grdetalle.Enter
        If (grdetalle.RowCount > 0) Then
            grdetalle.Select()
            grdetalle.Col = 3
            grdetalle.Row = 0
        End If

    End Sub

    Public Sub _prCrearTablaConciliacionReporte()
        Dim TablaPrincipal As DataTable = L_prConciliacionObtenerProducto(lbcodigo.Text) ''2=Chofer   1=Concepto
        Dim columnas As DataTable = L_prConciliacionObtenerIdNumiTI002(lbcodigo.Text)
        For Each fila As DataRow In columnas.Rows
            TablaPrincipal.Columns.Add(fila.Item("ibid").ToString.Trim)
        Next
        If (columnas.Rows.Count < 4) Then
            Dim dif As Integer = 4 - columnas.Rows.Count
            Dim u As Integer = 0
            Dim numi As Integer = columnas.Rows.Count + 1
            While (u < dif)
                TablaPrincipal.Columns.Add("columna" + Str(numi).Trim)
                numi += 1
                u += 1
            End While
        End If
        Dim Productos As DataTable = L_prConciliacionObtenerProductoTI0021(lbcodigo.Text)
        For j As Integer = 0 To TablaPrincipal.Rows.Count - 1 Step 1
            Dim idprod As Integer = TablaPrincipal.Rows(j).Item("canumi")
            Dim result As DataRow() = Productos.Select("iccprod=" + Str(idprod))
            For i As Integer = 0 To result.Length - 1 Step 1
                Dim rowIndex As Integer = TablaPrincipal.Rows.IndexOf(result(i))
                Dim columnnumi As String = result(i).Item("ibid")

                TablaPrincipal.Rows(j).Item(columnnumi) = result(i).Item("iccant")
            Next
        Next
        TablaPrincipal.Columns.Add("DEVOLUCION")
        TablaPrincipal.Columns.Add("TOTAL")

        '''''''''''Aqui inserto los movimientos ya insertados para modificarlos
        Dim ProductosMovimientoSalida As DataTable = L_prConciliacionObtenerProductoTI0021Idnumi(lbcodigo.Text) ''''Estado=3 Conciliacion Chofer
        For j As Integer = 0 To TablaPrincipal.Rows.Count - 1 Step 1
            Dim idprod As Integer = TablaPrincipal.Rows(j).Item("canumi")
            Dim result As DataRow() = ProductosMovimientoSalida.Select("iccprod=" + Str(idprod))
            For i As Integer = 0 To result.Length - 1 Step 1
                Dim rowIndex As Integer = TablaPrincipal.Rows.IndexOf(result(i))
                TablaPrincipal.Rows(j).Item("DEVOLUCION") = result(i).Item("iccant")

            Next
        Next
        'TablaPrincipal.Columns.Add("DEVOLUCION")

        '''''''Suma de Totales
        For i As Integer = 0 To TablaPrincipal.Rows.Count - 1 Step 1
            Dim suma As Double = 0
            For c As Integer = 0 To columnas.Rows.Count - 1 Step 1
                Dim colum As String = columnas.Rows(c).Item("ibid")
                suma = suma + IIf(IsDBNull(TablaPrincipal.Rows(i).Item(colum)), 0, TablaPrincipal.Rows(i).Item(colum))
            Next

            suma = suma - IIf(IsDBNull(TablaPrincipal.Rows(i).Item("DEVOLUCION")), 0, TablaPrincipal.Rows(i).Item("DEVOLUCION"))
            TablaPrincipal.Rows(i).Item("TOTAL") = suma
        Next
        Dim k As Integer = 0
        For Each fila As DataRow In columnas.Rows
            k += 1
            TablaPrincipal.Columns(fila.Item("ibid").ToString.Trim).ColumnName = "columna" + Str(k).Trim
        Next

        If (TablaPrincipal.Rows.Count > 0) Then
            P_GenerarReporte(TablaPrincipal)
        Else
            ToastNotification.Show(Me, "No hay SALIDAS DE PRODUCTOS EN LA FECHA".ToUpper,
                       My.Resources.INFORMATION,
                        3000,
                       eToastGlowColor.Blue,
                       eToastPosition.BottomLeft)
        End If
    End Sub
    Private Sub P_GenerarReporte(dt As DataTable)

        If Not IsNothing(P_Global.Visualizador) Then
            P_Global.Visualizador.Close()
        End If

        P_Global.Visualizador = New Visualizador
        Dim objrep As New R_ConciliacionChofer

        ''GenerarNro(_dt)
        ''objrep.SetDataSource(Dt1Kardex)
        objrep.SetDataSource(dt)

        objrep.SetParameterValue("chofer", tbChofer.Text.Trim)
        objrep.SetParameterValue("nro", lbcodigo.Text.Trim)
        objrep.SetParameterValue("fecha", tbFecha.Value.ToLongDateString)
        objrep.SetParameterValue("obs", tbObservacion.Text.Trim)

        P_Global.Visualizador.CRV1.ReportSource = objrep 'Comentar
        P_Global.Visualizador.Show() 'Comentar
        P_Global.Visualizador.BringToFront() 'Comentar
    End Sub

    Public Sub _prCrearTablaConciliacion()

        Dim TablaPrincipal As DataTable = L_prConciliacionObtenerProducto(lbcodigo.Text) ''2=Chofer   1=Concepto
        Dim columnas As DataTable = L_prConciliacionObtenerIdNumiTI002(lbcodigo.Text)
        For Each fila As DataRow In columnas.Rows
            TablaPrincipal.Columns.Add(fila.Item("ibid").ToString.Trim)
        Next
        Dim Productos As DataTable = L_prConciliacionObtenerProductoTI0021(lbcodigo.Text)
        For j As Integer = 0 To TablaPrincipal.Rows.Count - 1 Step 1
            Dim idprod As Integer = TablaPrincipal.Rows(j).Item("canumi")
            Dim result As DataRow() = Productos.Select("iccprod=" + Str(idprod))
            For i As Integer = 0 To result.Length - 1 Step 1
                Dim rowIndex As Integer = TablaPrincipal.Rows.IndexOf(result(i))
                Dim columnnumi As String = result(i).Item("ibid")

                TablaPrincipal.Rows(j).Item(columnnumi) = result(i).Item("iccant")

            Next
        Next
        TablaPrincipal.Columns.Add("ID_TO1", Type.GetType("System.String"))
        TablaPrincipal.Columns.Add("MOVIL")
        TablaPrincipal.Columns.Add("DEVOLUCION")
        TablaPrincipal.Columns.Add("TOTAL")
        TablaPrincipal.Columns.Add("TOTALCOPIA")
        TablaPrincipal.Columns.Add("estado")
        TablaPrincipal.Columns.Add("icid")
        TablaPrincipal.Columns.Add("DevCopia")
        TablaPrincipal.Columns.Add("FiltroEstado", Type.GetType("System.Boolean"))
        TablaPrincipal.Columns.Add("ImgEstado", Type.GetType("System.Byte[]"))

        '''''''''''Aqui inserto los movimientos ya insertados para modificarlos
        Dim ProductosMovimientoSalida As DataTable = L_prConciliacionObtenerProductoTI0021Idnumi(lbcodigo.Text) ''''Estado=3 Conciliacion Chofer
        For j As Integer = 0 To TablaPrincipal.Rows.Count - 1 Step 1
            Dim idprod As Integer = TablaPrincipal.Rows(j).Item("canumi")
            Dim result As DataRow() = ProductosMovimientoSalida.Select("iccprod=" + Str(idprod))
            For i As Integer = 0 To result.Length - 1 Step 1
                Dim rowIndex As Integer = TablaPrincipal.Rows.IndexOf(result(i))
                TablaPrincipal.Rows(j).Item("DEVOLUCION") = result(i).Item("iccant")
                TablaPrincipal.Rows(j).Item("estado") = 1
                TablaPrincipal.Rows(j).Item("icid") = result(i).Item("icid")
            Next
            TablaPrincipal.Rows(j).Item("FiltroEstado") = True
        Next
        'TablaPrincipal.Columns.Add("DEVOLUCION")

        '''''''''''Aqui inserto las ventas realidas con el movil
        Dim dtVer As DataTable = L_fnObtenerTabla("*", "TM0013", "idtm1id=" + lbcodigo.Text)
        Dim dtVentaMovil As DataTable
        If (dtVer.Rows.Count = 0) Then
            dtVentaMovil = L_prConciliacionObtenerPedidoEntregado(_codChofer)
        Else
            dtVentaMovil = L_prConciliacionObtenerPedidoEntregadoGrabado(lbcodigo.Text, _codChofer)
        End If

        For j As Integer = 0 To TablaPrincipal.Rows.Count - 1 Step 1
            Dim idprod As Integer = TablaPrincipal.Rows(j).Item("canumi")
            Dim result As DataRow() = dtVentaMovil.Select("obcprod=" + Str(idprod))
            For i As Integer = 0 To result.Length - 1 Step 1
                Dim rowIndex As Integer = TablaPrincipal.Rows.IndexOf(result(i))
                TablaPrincipal.Rows(j).Item("MOVIL") = IIf(IsDBNull(TablaPrincipal.Rows(j).Item("MOVIL")), 0, TablaPrincipal.Rows(j).Item("MOVIL")) + result(i).Item("obpcant")
                If (TablaPrincipal.Rows(j).Item("ID_TO1").ToString.Trim = String.Empty Or IsDBNull(TablaPrincipal.Rows(j).Item("ID_TO1"))) Then
                    TablaPrincipal.Rows(j).Item("ID_TO1") = result(i).Item("oanumi").ToString
                Else
                    TablaPrincipal.Rows(j).Item("ID_TO1") = TablaPrincipal.Rows(j).Item("ID_TO1").ToString + "," + result(i).Item("oanumi").ToString
                End If

            Next
        Next

        '''''''Suma de Totales
        For i As Integer = 0 To TablaPrincipal.Rows.Count - 1 Step 1
            Dim suma As Double = 0
            Dim sumaMovil As Double = 0
            For c As Integer = 0 To columnas.Rows.Count - 1 Step 1
                Dim colum As String = columnas.Rows(c).Item("ibid")
                suma = suma + IIf(IsDBNull(TablaPrincipal.Rows(i).Item(colum)), 0, TablaPrincipal.Rows(i).Item(colum))
            Next
            sumaMovil = IIf(IsDBNull(TablaPrincipal.Rows(i).Item("MOVIL")), 0, TablaPrincipal.Rows(i).Item("MOVIL"))
            TablaPrincipal.Rows(i).Item("TOTALCOPIA") = suma '- sumaMovil
            suma = suma - IIf(IsDBNull(TablaPrincipal.Rows(i).Item("DEVOLUCION")), 0, TablaPrincipal.Rows(i).Item("DEVOLUCION"))
            TablaPrincipal.Rows(i).Item("TOTAL") = suma '- sumaMovil
        Next

        'Aqui se trae los pedido de un determinado chofer que esta cerrada su caja 

        Dim dtPedidosEntregados As DataTable = New DataTable()
        dtPedidosEntregados = L_prConciliacionObtenerPedidoEntregadoGral(_codChofer, tbFecha.Value)
        dtPedidosEntregados.AcceptChanges()
        If (dtPedidosEntregados.Rows.Count > 0) Then
            For j As Integer = 0 To TablaPrincipal.Rows.Count - 1 Step 1
                Dim flag As Boolean = False
                If (IsDBNull(TablaPrincipal.Rows(j).Item("estado"))) Then
                    flag = True
                Else
                    If (Not TablaPrincipal.Rows(j).Item("estado") = 1) Then
                        flag = True
                    End If
                End If
                If (flag) Then
                    Dim idprod As Integer = TablaPrincipal.Rows(j).Item("canumi")
                    'Dim suma As Double = dtPedidosEntregados.Compute("sum(obptot)", "obcprod='" + idprod.ToString + "'")
                    Dim result As DataRow() = dtPedidosEntregados.Select("obcprod='" + idprod.ToString + "'")
                    For i As Integer = 0 To result.Length - 1 Step 1
                        Dim rowIndex As Integer = TablaPrincipal.Rows.IndexOf(result(i))
                        TablaPrincipal.Rows(j).Item("DevCopia") = IIf(IsDBNull(TablaPrincipal.Rows(j).Item("DevCopia")), 0, TablaPrincipal.Rows(j).Item("DevCopia")) + result(i).Item("obpcant")
                        If (TablaPrincipal.Rows(j).Item("ID_TO1").ToString.Trim = String.Empty Or IsDBNull(TablaPrincipal.Rows(j).Item("ID_TO1"))) Then
                            TablaPrincipal.Rows(j).Item("ID_TO1") = result(i).Item("oanumi").ToString
                        Else
                            TablaPrincipal.Rows(j).Item("ID_TO1") = TablaPrincipal.Rows(j).Item("ID_TO1").ToString + "," + result(i).Item("oanumi").ToString
                        End If
                    Next

                    TablaPrincipal.Rows(j).Item("DEVOLUCION") = IIf(IsDBNull(TablaPrincipal.Rows(j).Item("TOTALCOPIA")), 0, TablaPrincipal.Rows(j).Item("TOTALCOPIA")) - IIf(IsDBNull(TablaPrincipal.Rows(j).Item("DevCopia")), 0, TablaPrincipal.Rows(j).Item("DevCopia"))
                    TablaPrincipal.Rows(j).Item("FiltroEstado") = (IIf(IsDBNull(TablaPrincipal.Rows(j).Item("TOTALCOPIA")), 0, TablaPrincipal.Rows(j).Item("TOTALCOPIA")) - IIf(IsDBNull(TablaPrincipal.Rows(j).Item("DevCopia")), 0, TablaPrincipal.Rows(j).Item("DevCopia")))
                    TablaPrincipal.Rows(j).Item("TOTAL") = TablaPrincipal.Rows(j).Item("TOTALCOPIA") - TablaPrincipal.Rows(j).Item("DEVOLUCION")
                End If
            Next
        End If

        Dim dt As New DataTable
        dt = TablaPrincipal
        If (gi_adev = 1) Then
            _prCargarIcono(dt)
        End If
        grdetalle.DataSource = dt
        grdetalle.RetrieveStructure()
        grdetalle.AlternatingColors = True
        For c As Integer = 0 To columnas.Rows.Count - 1 Step 1
            Dim colum As String = columnas.Rows(c).Item("ibid")
            With grdetalle.RootTable.Columns(colum)
                .Width = 150
                .Visible = True
                .TextAlignment = TextAlignment.Far
                .FormatString = "0"
                .Caption = "Salida " + Str(c + 1)
            End With
        Next

        With grdetalle.RootTable.Columns("canumi")
            .Width = 150
            .Visible = False
        End With
        With grdetalle.RootTable.Columns("estado")
            .Width = 150
            .Visible = False
        End With
        With grdetalle.RootTable.Columns("icid")
            .Width = 150
            .Visible = False
        End With
        With grdetalle.RootTable.Columns("cadesc")
            .Width = 200
            .Visible = True
            .Caption = "PRODUCTO"
        End With
        With grdetalle.RootTable.Columns("ID_TO1")
            .Width = 150
            .Visible = False
        End With
        With grdetalle.RootTable.Columns("MOVIL")
            .Width = 150
            .Visible = False
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
            .Caption = "MOVIL"
            .CellStyle.BackColor = Color.CadetBlue
        End With
        With grdetalle.RootTable.Columns("DEVOLUCION")
            .Width = 150
            .Visible = True
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
            .Caption = "DEVOLUCION"
        End With
        With grdetalle.RootTable.Columns("TOTAL")
            .Width = 150
            .Visible = True
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
            .Caption = "TOTAL"
        End With
        With grdetalle.RootTable.Columns("TOTALCOPIA")
            .Width = 150
            .Visible = False
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With
        With grdetalle.RootTable.Columns("DevCopia")
            .Visible = False
        End With
        With grdetalle.RootTable.Columns("FiltroEstado")
            .Visible = False
        End With
        With grdetalle.RootTable.Columns("ImgEstado")
            .Width = 80
            .Caption = "COMPARA".ToUpper
            .CellStyle.ImageHorizontalAlignment = ImageHorizontalAlignment.Center
            .Visible = (gi_adev = 1)
        End With
        With grdetalle
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
            .RootTable.RowHeight = 30

            If (gi_adev = 1) Then
                Dim fc As GridEXFormatCondition = New GridEXFormatCondition(.RootTable.Columns("FiltroEstado"), ConditionOperator.Equal, False)
                fc.FormatStyle.BackColor = Color.LightSalmon

                .RootTable.FormatConditions.Add(fc)
            End If
        End With
    End Sub

    Public Sub _prCargarIcono(dt As DataTable)
        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            If (Not IsDBNull(dt.Rows(i).Item("estado"))) Then
                dt.Rows(i).Item("ImgEstado") = _fnBytesArchivo(My.Resources.checked, 20, 20)
            Else
                Dim cantidad As Double = 0
                Dim devolucion As Double = 0
                If (Not IsDBNull(dt.Rows(i).Item("DevCopia"))) Then
                    cantidad = dt.Rows(i).Item("DevCopia")
                End If

                If (Not IsDBNull(dt.Rows(i).Item("DEVOLUCION"))) Then
                    devolucion = dt.Rows(i).Item("DEVOLUCION")
                End If

                If (devolucion = dt.Rows(i).Item("TOTALCOPIA") - cantidad) Then
                    dt.Rows(i).Item("ImgEstado") = _fnBytesArchivo(My.Resources.checked, 20, 20)
                Else
                    dt.Rows(i).Item("ImgEstado") = _fnBytesArchivo(My.Resources.cancel, 20, 20)
                    End If
                End If
        Next
    End Sub

    Public Sub _prCargarIcono(fil As Integer, dt As DataTable, flag As Boolean)
        If (flag) Then
            dt.Rows(fil).Item("ImgEstado") = _fnBytesArchivo(My.Resources.checked, 20, 20)
        Else
            dt.Rows(fil).Item("ImgEstado") = _fnBytesArchivo(My.Resources.cancel, 20, 20)
        End If
    End Sub

    Private Function _fnBytesArchivo(img As Bitmap, ancho As Integer, alto As Integer) As Object
        Bin = New MemoryStream()
        Dim img2 As New Bitmap(img, ancho, alto)
        img2.Save(Bin, System.Drawing.Imaging.ImageFormat.Png)
        Return Bin.ToArray()
    End Function

    Private Sub MBtImprimir_Click(sender As Object, e As EventArgs) Handles MBtImprimir.Click
        _prCrearTablaConciliacionReporte()
    End Sub

    Private Sub tbTablet_ValueChanged(sender As Object, e As EventArgs) Handles tbTablet.ValueChanged

        _prCargarVenta()

    End Sub

    Private Sub grdetalle_Error(sender As Object, e As Janus.Windows.GridEX.ErrorEventArgs) Handles grdetalle.[Error]

    End Sub
End Class
