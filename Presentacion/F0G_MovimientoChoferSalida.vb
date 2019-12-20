
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
Imports LOGIC
Imports ENTITY

Public Class F0G_MovimientoChoferSalida

#Region "Variables Globales"
    Dim _codChofer As Integer = 0
    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

    Dim _IdConciliacion As Integer = 0
    Dim _numiConciliacio As Integer = 0 ''Aqui se guardar el numi de la conciliacion
    Dim _icibid As String = ""

    Private boShow As Boolean = False
    Private boAdd As Boolean = False
    Private boModif As Boolean = False
    Private boDel As Boolean = False

    Private InDuracion As Byte = 5
#End Region

#Region "Metodos Privados"
    Private Sub _IniciarTodo()
        MSuperTabControlPrincipal.SelectedTabIndex = 0
        L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        Me.WindowState = FormWindowState.Maximized
        _prCargarComboLibreriaConcepto(cbConcepto)
        _prInhabiliitar()
        _prCargarVenta()
        'Dim blah As New Bitmap(New Bitmap(My.Resources.compra), 20, 20)
        'Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        'Me.Icon = ico
        Me.Text = "S A L I D A   D E   P R O D U C T O   D E   C H O F E R E S"

        _prAsignarPermisos()

        If (grmovimiento.RowCount > 0) Then
            _prMostrarRegistro(0)
        End If
    End Sub
    Private Sub _prCargarComboLibreriaConcepto(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
        Dim dt As New DataTable
        dt = L_prMovimientoChoferConceptoSalida()
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

        If boAdd = False Then
            MBtNuevo.Visible = False
        End If
        If boModif = False Then
            MBtModificar.Visible = False
        End If
        If boDel = False Then
            MBtEliminar.Visible = False
        End If
    End Sub
    Private Sub _prInhabiliitar()
        tbCodigo.ReadOnly = True
        tbChofer.ReadOnly = True
        cbConcepto.ReadOnly = True
        tbObservacion.ReadOnly = True
        tbFecha.IsInputReadOnly = True

        ''''''''''
        MBtModificar.Enabled = True
        MBtGrabar.Enabled = False
        MBtNuevo.Enabled = True
        MBtEliminar.Enabled = True
        grmovimiento.Enabled = False
        If (GPanelProductos.Visible = True) Then
            _DesHabilitarProductos()
        End If
        grmovimiento.Enabled = True
        MPanelToolBarNavegacion.Enabled = True

        btBuscarChofer.Enabled = False
    End Sub
    Private Sub _prhabilitar()
        tbCodigo.ReadOnly = False
        tbChofer.ReadOnly = False
        tbObservacion.ReadOnly = False
        tbFecha.IsInputReadOnly = False
        grmovimiento.Enabled = True
        ''  tbCliente.ReadOnly = False  por que solo podra seleccionar Cliente
        ''  tbVendedor.ReadOnly = False

        MBtGrabar.Enabled = True
        btBuscarChofer.Enabled = True
    End Sub
    Public Sub _prFiltrar()
        'cargo el buscador
        Dim _Mpos As Integer
        _prCargarVenta()
        If grmovimiento.RowCount > 0 Then
            _Mpos = 0
            grmovimiento.Row = _Mpos
        Else
            _Limpiar()
            MLbPaginacion.Text = "0/0"
        End If
    End Sub
    Private Sub _Limpiar()
        tbCodigo.Clear()
        tbChofer.Clear()
        tbObservacion.Clear()
        _codChofer = 0
        tbFecha.Value = Now.Date
        _prCargarDetalleVenta(-1)
        _IdConciliacion = 0
        If (CType(cbConcepto.DataSource, DataTable).Rows.Count > 0) Then
            cbConcepto.Value = 9
        End If

        With grdetalle.RootTable.Columns("img")
            .Width = 80
            .Caption = "Eliminar"
            .CellStyle.ImageHorizontalAlignment = ImageHorizontalAlignment.Center
            .Visible = True
        End With
        _prAddDetalleVenta()
        If (GPanelProductos.Visible = True) Then
            GPanelProductos.Visible = False
            MPnInferior.Visible = True
        End If
        lbConciliacion.Text = 0
        tbChofer.Focus()

    End Sub
    Public Sub _prMostrarRegistro(_N As Integer)
        '   a.ibid ,a.ibfdoc ,a.ibconcep ,b.cpdesc as concepto,a.ibobs ,a.ibest ,a.ibalm ,a.ibiddc ,a.ibidchof
        ',c.cbdesc as chofer ,a.ibidvent ,a.ibfact ,a.ibhact ,a.ibuact
        With grmovimiento
            tbCodigo.Text = .GetValue("ibid")
            tbFecha.Value = .GetValue("ibfdoc")
            _codChofer = .GetValue("ibidchof")
            cbConcepto.Value = .GetValue("ibconcep")
            tbObservacion.Text = .GetValue("ibobs")
            tbChofer.Text = .GetValue("chofer")
            MLbFecha.Text = CType(.GetValue("ibfact"), Date).ToString("dd/MM/yyyy")
            MLbHora.Text = .GetValue("ibhact").ToString
            MLbUsuario.Text = .GetValue("ibuact").ToString
            lbConciliacion.Text = .GetValue("ieconcti2").ToString
            _prValidar(.GetValue("estado"))
            _icibid = .GetValue("ibiddc")
        End With
        _prCargarDetalleVenta(tbCodigo.Text)
        MLbPaginacion.Text = Str(grmovimiento.Row + 1) + "/" + grmovimiento.RowCount.ToString

        If (Not boModif And boAdd) Then
            If (Now.Date = Me.tbFecha.Value) Then
                MBtModificar.Visible = True
            Else
                MBtModificar.Visible = False
            End If
        End If
    End Sub
    Public Sub _prValidar(_estado As Integer)
        If (_estado = 3) Then
            MBtModificar.Enabled = False
            MBtEliminar.Enabled = False
        Else
            MBtModificar.Enabled = True
            MBtEliminar.Enabled = True
        End If
    End Sub

    Private Sub _prCargarDetalleVenta(_numi As String)
        Dim dt As New DataTable
        dt = L_prMovimientoChoferDetalleSalida(_numi)
        grdetalle.DataSource = dt
        grdetalle.RetrieveStructure()
        grdetalle.AlternatingColors = True
        'a.icid ,a.icibid ,a.iccprod ,b.cadesc as producto,a.iccant ,Cast(null as image ) as img,1 as estado

        With grdetalle.RootTable.Columns("icid")
            .Width = 100
            .Caption = "CODIGO"
            .Visible = False

        End With

        With grdetalle.RootTable.Columns("icibid")
            .Width = 90
            .Visible = False
        End With

        With grdetalle.RootTable.Columns("iccprod")
            .Width = 120
            .Caption = "CODIGO."   'Codigo p'
            .Visible = True
        End With

        With grdetalle.RootTable.Columns("cacod")
            .Width = 120
            .Caption = "CODIGO FLEX."
            .Visible = True
        End With

        With grdetalle.RootTable.Columns("producto")
            .Caption = "PRODUCTOS"
            .Width = 250
            .Visible = True
        End With

        With grdetalle.RootTable.Columns("iccant")
            .Width = 160
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            .FormatString = "0.00"
            .Caption = "Cantidad".ToUpper
        End With

        With grdetalle.RootTable.Columns("estado")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With grdetalle.RootTable.Columns("img")
            .Width = 80
            .Caption = "Eliminar".ToUpper
            .CellStyle.ImageHorizontalAlignment = ImageHorizontalAlignment.Center
            .Visible = False
        End With
        With grdetalle
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With
    End Sub

    Private Sub _prCargarVenta()
        Dim dt As New DataTable
        If (tbTablet.Value = True) Then
            dt = L_prMovimientoChoferGeneralSalidaTop20(9)
        Else
            dt = L_prMovimientoChoferGeneralSalida(9)
        End If

        grmovimiento.DataSource = dt
        grmovimiento.RetrieveStructure()
        grmovimiento.AlternatingColors = True


        With grmovimiento.RootTable.Columns("ibid")
            .Width = 100
            .Caption = "CODIGO"
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
            .Width = 160
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
        With grmovimiento.RootTable.Columns("ieconcti2")
            .Width = 250
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            .Caption = "NRO CONCILIACION"
        End With

        With grmovimiento.RootTable.Columns("ibidconcil")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With grmovimiento.RootTable.Columns("ibidvent")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        'a.ibid ,a.ibfdoc ,a.ibconcep ,b.cpdesc as concepto,a.ibobs ,a.ibest ,a.ibalm ,a.ibiddc ,a.ibidchof
        ',c.cbdesc as chofer ,a.ibidvent ,a.ibfact ,a.ibhact ,a.ibuact

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
        With grmovimiento.RootTable.Columns("estado")
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

        If (dt.Rows.Count <= 0) Then
            _prCargarDetalleVenta(-1)
        End If



    End Sub
    Private Sub _prCargarProductos()


        Dim dt As New DataTable
        dt = L_prMovimientoChoferListarProductosSalida(CType(grdetalle.DataSource, DataTable))  ''1=Almacen
        grproducto.DataSource = dt
        grproducto.RetrieveStructure()
        grproducto.AlternatingColors = True

        'a.canumi ,a.cadesc ,a.cadesc2

        With grproducto.RootTable.Columns("canumi")
            .Width = 100
            .Caption = "CODIGO"
            .Visible = True

        End With
        With grproducto.RootTable.Columns("cacod")
            .Width = 100
            .Caption = "COD FLEX"
            .Visible = True

        End With
        With grproducto.RootTable.Columns("cadesc")
            .Width = 350
            .Caption = "PRODUCTOS"
            .Visible = True

        End With

        With grproducto.RootTable.Columns("cadesc2")
            .Width = 250
            .Visible = True
            .Caption = "DESCRIPCION CORTA"
        End With



        With grproducto
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With
    End Sub
    Private Sub _prAddDetalleVenta()
        'a.icid ,a.icibid ,a.iccprod ,b.cadesc as producto,a.iccant ,Cast(null as image ) as img,1 as estado
        Dim Bin As New MemoryStream
        Dim img As New Bitmap(My.Resources.delete, 28, 28)
        img.Save(Bin, Imaging.ImageFormat.Png)
        'CType(grdetalle.DataSource, DataTable).Rows.Add(_fnSiguienteNumi() + 1, 0, 0, "", 0, Bin.GetBuffer, 0)
        CType(grdetalle.DataSource, DataTable).Rows.Add(_fnSiguienteNumi() + 1, 0, 0, "", "", 0, Bin.GetBuffer, 0)

    End Sub


    Public Function _fnSiguienteNumi()
        Dim dt As DataTable = CType(grdetalle.DataSource, DataTable)
        Dim rows() As DataRow = dt.Select("icid=MAX(icid)")
        If (rows.Count > 0) Then
            Return rows(rows.Count - 1).Item("icid")
        End If
        Return 1
    End Function
    Public Function _fnAccesible()
        Return tbFecha.IsInputReadOnly = False
    End Function
    Private Sub _HabilitarProductos()
        GPanelProductos.Visible = True

        MPnInferior.Visible = False
        _prCargarProductos()
        grproducto.Focus()
        grproducto.MoveTo(grproducto.FilterRow)
        grproducto.Col = 1
    End Sub
    Private Sub _DesHabilitarProductos()
        If (GPanelProductos.Visible = True) Then
            GPanelProductos.Visible = False
            MPnInferior.Visible = True
            grdetalle.Select()
            grdetalle.Col = 4
            grdetalle.Row = grdetalle.RowCount - 1
        End If

    End Sub
    Public Sub _fnObtenerFilaDetalle(ByRef pos As Integer, numi As Integer)
        For i As Integer = 0 To CType(grdetalle.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim _numi As Integer = CType(grdetalle.DataSource, DataTable).Rows(i).Item("icid")
            If (_numi = numi) Then
                pos = i
                Return
            End If
        Next

    End Sub

    Public Sub _fnObtenerFilaDetalleConciliacion(ByRef pos As Integer, producto As Integer)
        For i As Integer = 0 To CType(grdetalle.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim _numi As Integer = CType(grdetalle.DataSource, DataTable).Rows(i).Item("canumi")
            If (_numi = producto) Then
                pos = i
                Return
            End If
        Next

    End Sub

    Public Function _fnExisteProducto(idprod As Integer) As Boolean
        For i As Integer = 0 To CType(grdetalle.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim _idprod As Integer = CType(grdetalle.DataSource, DataTable).Rows(i).Item("iccprod")
            Dim estado As Integer = CType(grdetalle.DataSource, DataTable).Rows(i).Item("estado")
            If (_idprod = idprod And estado >= 0) Then

                Return True
            End If
        Next
        Return False
    End Function

    Public Sub _prEliminarFila()
        If (grdetalle.Row >= 0) Then
            If (grdetalle.RowCount >= 2) Then
                Dim estado As Integer = grdetalle.GetValue("estado")
                Dim pos As Integer = -1
                Dim lin As Integer = grdetalle.GetValue("icid")
                _fnObtenerFilaDetalle(pos, lin)
                If (estado = 0) Then
                    CType(grdetalle.DataSource, DataTable).Rows(pos).Item("estado") = -2

                End If
                If (estado = 1) Then
                    CType(grdetalle.DataSource, DataTable).Rows(pos).Item("estado") = -1
                End If
                grdetalle.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grdetalle.RootTable.Columns("estado"), Janus.Windows.GridEX.ConditionOperator.GreaterThanOrEqualTo, 0))

                grdetalle.Select()
                grdetalle.Col = 4
                grdetalle.Row = grdetalle.RowCount - 1
                _prCargarProductos()
            End If
        End If


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

    Public Sub _GuardarNuevo()
        Dim numi As String = ""
        Dim numiConciliacion As String = ""
        If (_IdConciliacion = 0) Then
            Dim resconciliacion As Boolean = L_prMovimientoChoferGrabar(numiConciliacion, tbFecha.Value.ToString("yyyy/MM/dd"), 10, "", _codChofer, 0)
            If (resconciliacion = False) Then
                Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                ToastNotification.Show(Me, "El Movimiento no pudo ser insertado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                Return
            Else
                Dim tabla As DataTable = L_prMovimientoChoferNoExisteConciliacion(_codChofer) ''Aqui obtengo el numi de la TI0022 
                Dim res As Boolean = L_prMovimientoChoferGrabarSalida(numi, tbFecha.Value.ToString("yyyy/MM/dd"), cbConcepto.Value, tbObservacion.Text, _codChofer, tabla.Rows(0).Item("ieid"), CType(grdetalle.DataSource, DataTable))
                If res Then

                    _prCargarVenta()
                    _Limpiar()
                    Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
                    ToastNotification.Show(Me, "Código de Movimiento ".ToUpper + tbCodigo.Text + " Grabado con Exito.".ToUpper,
                                              img, 2000,
                                              eToastGlowColor.Green,
                                              eToastPosition.TopCenter
                                              )
                    MBtSalir.PerformClick()
                Else
                    Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                    ToastNotification.Show(Me, "El Movimiento no pudo ser insertado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                End If
            End If
        Else
            Dim res As Boolean = L_prMovimientoChoferGrabarSalida(numi, tbFecha.Value.ToString("yyyy/MM/dd"), cbConcepto.Value, tbObservacion.Text, _codChofer, _IdConciliacion, CType(grdetalle.DataSource, DataTable))
            If res Then
                _prCargarVenta()
                _Limpiar()
                Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
                ToastNotification.Show(Me, "Código de Movimiento ".ToUpper + tbCodigo.Text + " Grabado con Exito.".ToUpper,
                                          img, 2000,
                                          eToastGlowColor.Green,
                                          eToastPosition.TopCenter
                                          )
                MBtSalir.PerformClick()
            Else
                Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                ToastNotification.Show(Me, "El Movimiento no pudo ser insertado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            End If
        End If


    End Sub
    Private Sub _prGuardarModificado()
        Dim res As Boolean = L_prMovimientoChoferModificarSalida(tbCodigo.Text.Trim, tbFecha.Value.ToString("yyyy/MM/dd"), cbConcepto.Value, tbObservacion.Text, _codChofer, CType(grdetalle.DataSource, DataTable), _icibid)
        If res Then
            _prCargarVenta()
            _prSalir()
            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Movimiento ".ToUpper + tbCodigo.Text + " Modificado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter
                                      )
        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "La Venta no pudo ser Modificada".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
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
    Public Sub _prCargarIconELiminar()

        For i As Integer = 0 To CType(grdetalle.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim Bin As New MemoryStream
            Dim img As New Bitmap(My.Resources.delete, 28, 28)
            img.Save(Bin, Imaging.ImageFormat.Png)
            CType(grdetalle.DataSource, DataTable).Rows(i).Item("img") = Bin.GetBuffer
            grdetalle.RootTable.Columns("img").Visible = True
        Next

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

        tbChofer.Select()
        MBtSalir.Text = "CANCELAR"
    End Sub

    Private Sub MBtSalir_Click(sender As Object, e As EventArgs) Handles MBtSalir.Click
        _prSalir()
    End Sub


    Private Sub tbChofer_KeyDown(sender As Object, e As KeyEventArgs) Handles tbChofer.KeyDown
        If (_fnAccesible()) Then
            If e.KeyData = Keys.Control + Keys.Enter Then
                P_prAyudaChofer()
            End If
        End If
    End Sub
    Public Sub _prObtenerNumiConciliacionTI0022()

        '''''Aqui verifico si el concepto es igual a salida de productos de choferes obtengo su numi de conciliacion si existiese
        Dim dt As DataTable = L_prMovimientoChoferExisteConciliacionSalida(_codChofer) ''Aqui verifico si existe conciliacion con devolucion 

        If (dt.Rows.Count > 0) Then

            Dim estado As Integer = dt.Rows(0).Item("ieest")
            'If (estado = 2) Then
            '    If (cbConcepto.SelectedIndex > 0) Then
            '        cbConcepto.SelectedIndex = 0
            '    Else
            '        cbConcepto.SelectedIndex = -1
            '    End If

            '    Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
            '    ToastNotification.Show(Me, "El Chofer: " + tbChofer.Text + " Tiene Conciliacion Pendiente. Por favor culmine la conciliacion para poder efectuar mas salidas".ToUpper, img, 4000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            '    _codChofer = 0
            '    tbChofer.Text = ""
            '    tbChofer.Focus()
            '    lbConciliacion.Text = 0
            '    _IdConciliacion = 0
            '    cbConcepto.Value = 9
            'Else
            Dim tabla As DataTable = L_prMovimientoChoferNoExisteConciliacion(_codChofer) ''Aqui obtengo el numi de la conciliacion si existiera con estado=1 si no tengo que insertar una
            If (tabla.Rows.Count > 0) Then
                _IdConciliacion = tabla.Rows(0).Item("ieid")
                lbConciliacion.Text = tabla.Rows(0).Item("ibid")
            Else
                lbConciliacion.Text = 0
                _IdConciliacion = 0
            End If
            'End If
        Else
            lbConciliacion.Text = 0
            _IdConciliacion = 0
        End If
    End Sub

    Private Sub grdetalle_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grdetalle.EditingCell
        If (_fnAccesible()) Then
            'Habilitar solo las columnas de Precio, %, Monto y Observación
            If (e.Column.Index = grdetalle.RootTable.Columns("iccant").Index) Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub grdetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles grdetalle.KeyDown
        If (Not _fnAccesible()) Then
            Return
        End If

        If (e.KeyData = Keys.Enter) Then
            Dim f, c As Integer
            c = grdetalle.Col
            f = grdetalle.Row

            If (grdetalle.Col = grdetalle.RootTable.Columns("iccant").Index) Then
                If (grdetalle.GetValue("producto") <> String.Empty) Then
                    _prAddDetalleVenta()
                    _HabilitarProductos()
                Else
                    ToastNotification.Show(Me, "Seleccione un Producto Por Favor", My.Resources.WARNING, 3000, eToastGlowColor.Red, eToastPosition.TopCenter)
                End If

            End If
            If (grdetalle.Col = grdetalle.RootTable.Columns("producto").Index) Then
                If (grdetalle.GetValue("producto") <> String.Empty) Then
                    _prAddDetalleVenta()
                    _HabilitarProductos()
                Else
                    ToastNotification.Show(Me, "Seleccione un Producto Por Favor", My.Resources.WARNING, 3000, eToastGlowColor.Red, eToastPosition.TopCenter)
                End If

            End If
salirIf:
        End If

        If (e.KeyData = Keys.Control + Keys.Enter And grdetalle.Row >= 0 And
            grdetalle.Col = grdetalle.RootTable.Columns("producto").Index) Then
            Dim indexfil As Integer = grdetalle.Row
            Dim indexcol As Integer = grdetalle.Col
            _HabilitarProductos()

        End If
        If (e.KeyData = Keys.Escape And grdetalle.Row >= 0) Then
            _prEliminarFila()
        End If
    End Sub

    Private Sub grproducto_KeyDown(sender As Object, e As KeyEventArgs) Handles grproducto.KeyDown
        If (Not _fnAccesible()) Then
            Return
        End If
        If (e.KeyData = Keys.Enter) Then
            Dim f, c As Integer
            c = grproducto.Col
            f = grproducto.Row
            If (f >= 0) Then

                grdetalle.Row = grdetalle.RowCount - 1
                If ((grdetalle.GetValue("iccprod") > 0)) Then
                    _prAddDetalleVenta()
                End If

                Dim pos As Integer = -1
                grdetalle.Row = grdetalle.RowCount - 1
                _fnObtenerFilaDetalle(pos, grdetalle.GetValue("icid"))


                Dim existe As Boolean = _fnExisteProducto(grproducto.GetValue("canumi"))
                If ((pos >= 0) And (Not existe)) Then
                    CType(grdetalle.DataSource, DataTable).Rows(pos).Item("iccprod") = grproducto.GetValue("canumi")
                    CType(grdetalle.DataSource, DataTable).Rows(pos).Item("cacod") = grproducto.GetValue("cacod")
                    CType(grdetalle.DataSource, DataTable).Rows(pos).Item("producto") = grproducto.GetValue("cadesc")

                    CType(grdetalle.DataSource, DataTable).Rows(pos).Item("iccant") = 1
                    _prCargarProductos()

                    grproducto.RemoveFilters()
                    grproducto.Focus()
                    grproducto.MoveTo(grproducto.FilterRow)
                    grproducto.Col = 1
                Else
                    If (existe) Then
                        Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
                        ToastNotification.Show(Me, "El producto ya existe en el detalle".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                        grproducto.RemoveFilters()
                        grproducto.Focus()
                        grproducto.MoveTo(grproducto.FilterRow)
                        grproducto.Col = 1
                    End If
                End If
            End If
        End If
        If e.KeyData = Keys.Escape Then
            _DesHabilitarProductos()
        End If
    End Sub

    Private Sub grdetalle_CellValueChanged(sender As Object, e As ColumnActionEventArgs) Handles grdetalle.CellValueChanged
        If (e.Column.Index = grdetalle.RootTable.Columns("iccant").Index) Then
            If (Not IsNumeric(grdetalle.GetValue("iccant")) Or grdetalle.GetValue("iccant").ToString = String.Empty) Then

                'grDetalle.GetRow(rowIndex).Cells("cant").Value = 1
                '  grDetalle.CurrentRow.Cells.Item("cant").Value = 1
                Dim lin As Integer = grdetalle.GetValue("icid")
                Dim pos As Integer = -1
                _fnObtenerFilaDetalle(pos, lin)
                CType(grdetalle.DataSource, DataTable).Rows(pos).Item("iccant") = 1

                Dim estado As Integer = CType(grdetalle.DataSource, DataTable).Rows(pos).Item("estado")

                If (estado = 1) Then
                    CType(grdetalle.DataSource, DataTable).Rows(pos).Item("estado") = 2
                End If
            Else
                If (grdetalle.GetValue("iccant") > 0) Then
                    Dim lin As Integer = grdetalle.GetValue("icid")
                    Dim pos As Integer = -1
                    _fnObtenerFilaDetalle(pos, lin)
                    Dim estado As Integer = CType(grdetalle.DataSource, DataTable).Rows(pos).Item("estado")

                    If (estado = 1) Then
                        CType(grdetalle.DataSource, DataTable).Rows(pos).Item("estado") = 2
                    End If
                Else
                    Dim lin As Integer = grdetalle.GetValue("icid")
                    Dim pos As Integer = -1
                    _fnObtenerFilaDetalle(pos, lin)
                    CType(grdetalle.DataSource, DataTable).Rows(pos).Item("iccant") = 1
                    Dim estado As Integer = CType(grdetalle.DataSource, DataTable).Rows(pos).Item("estado")

                    If (estado = 1) Then
                        CType(grdetalle.DataSource, DataTable).Rows(pos).Item("estado") = 2
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub grdetalle_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles grdetalle.CellEdited
        If (e.Column.Index = grdetalle.RootTable.Columns("iccant").Index) Then
            If (Not IsNumeric(grdetalle.GetValue("iccant")) Or grdetalle.GetValue("iccant").ToString = String.Empty) Then
                grdetalle.SetValue("iccant", 1)
            Else
                'If (grdetalle.GetValue("iccant") > 0) Then

                'Else
                '    grdetalle.SetValue("iccant", 1)
                'End If
            End If
        End If


    End Sub

    Private Sub grdetalle_MouseClick(sender As Object, e As MouseEventArgs) Handles grdetalle.MouseClick
        If (Not _fnAccesible()) Then
            Return
        End If

        If (grdetalle.RowCount >= 2) Then
            If (grdetalle.CurrentColumn.Index = grdetalle.RootTable.Columns("img").Index) Then
                _prEliminarFila()
            End If
        End If
    End Sub

    Private Sub MBtGrabar_Click(sender As Object, e As EventArgs) Handles MBtGrabar.Click
        If _ValidarCampos() = False Then
            Exit Sub
        End If
        If (tbCodigo.Text = String.Empty) Then
            _GuardarNuevo()
        Else
            If (tbCodigo.Text <> String.Empty) Then
                _prGuardarModificado()
            End If
        End If
    End Sub

    Private Sub MBtModificar_Click(sender As Object, e As EventArgs) Handles MBtModificar.Click
        Dim dt As DataTable = L_fnObtenerTabla("ieest", "TM0012", "ieconcti2=" + lbConciliacion.Text)
        If (dt.Rows.Count > 0) Then
            If (dt.Rows(0).Item("ieest").ToString.Equals("1")) Then
                If (grmovimiento.RowCount > 0) Then
                    _prhabilitar()
                    MBtNuevo.Enabled = False
                    MBtModificar.Enabled = False
                    MBtEliminar.Enabled = False
                    MBtGrabar.Enabled = True

                    MPanelToolBarNavegacion.Enabled = False
                    _prCargarIconELiminar()

                    tbChofer.Select()
                    MBtSalir.Text = "CANCELAR"
                End If
            ElseIf (dt.Rows(0).Item("ieest").ToString.Equals("2")) Then
                ToastNotification.Show(Me,
                                       "Esta salida de producto ya ha sido conciliada.".ToUpper + vbCrLf + "ya no puede ser modificada.".ToUpper,
                                       My.Resources.INFORMATION,
                                       InDuracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)
            ElseIf (dt.Rows(0).Item("ieest").ToString.Equals("3")) Then
                ToastNotification.Show(Me,
                                       "Esta salida de producto ya ha sido registrada en venta.".ToUpper + vbCrLf + "ya no puede ser modificada.".ToUpper,
                                       My.Resources.INFORMATION,
                                       InDuracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)
            End If
        Else
            ToastNotification.Show(Me,
                                   "Ha ocurrido un error-TM0012.".ToUpper + vbCrLf + "No existe el registro.".ToUpper,
                                   My.Resources.INFORMATION,
                                   InDuracion * 1000,
                                   eToastGlowColor.Red,
                                   eToastPosition.TopCenter)
        End If
    End Sub

    Private Sub MBtEliminar_Click(sender As Object, e As EventArgs) Handles MBtEliminar.Click
        Dim dt As DataTable = L_fnObtenerTabla("ieest", "TM0012", "ieconcti2=" + lbConciliacion.Text)
        If (dt.Rows.Count > 0) Then
            If (dt.Rows(0).Item("ieest").ToString.Equals("1")) Then
                If (grmovimiento.RowCount > 0) Then
                    Dim ef = New Efecto

                    ef.tipo = 2
                    ef.Context = "¿esta seguro de eliminar el registro?".ToUpper
                    ef.Header = "mensaje principal".ToUpper
                    ef.ShowDialog()
                    Dim bandera As Boolean = False
                    bandera = ef.band
                    If (bandera = True) Then
                        Dim mensajeError As String = ""
                        Dim res As Boolean = L_prMovimientoChofeEliminarSalida(tbCodigo.Text, _icibid)
                        If res Then


                            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)

                            ToastNotification.Show(Me, "Código de Movimiento ".ToUpper + tbCodigo.Text + " eliminado con Exito.".ToUpper,
                                                      img, 2000,
                                                      eToastGlowColor.Green,
                                                      eToastPosition.TopCenter)

                            _prFiltrar()

                        Else
                            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                            ToastNotification.Show(Me, mensajeError, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                        End If
                    End If
                End If
            ElseIf (dt.Rows(0).Item("ieest").ToString.Equals("2")) Then
                ToastNotification.Show(Me,
                                       "Esta salida de producto ya ha sido conciliada.".ToUpper + vbCrLf + "ya no puede ser eliminada.".ToUpper,
                                       My.Resources.INFORMATION,
                                       InDuracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)
            ElseIf (dt.Rows(0).Item("ieest").ToString.Equals("3")) Then
                ToastNotification.Show(Me,
                                       "Esta salida de producto ya ha sido registrada en venta.".ToUpper + vbCrLf + "ya no puede ser eliminada.".ToUpper,
                                       My.Resources.INFORMATION,
                                       InDuracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)
            End If
        Else
            ToastNotification.Show(Me,
                                   "Ha ocurrido un error-TM0012.".ToUpper + vbCrLf + "No existe el registro.".ToUpper,
                                   My.Resources.INFORMATION,
                                   InDuracion * 1000,
                                   eToastGlowColor.Red,
                                   eToastPosition.TopCenter)
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

    Private Sub cbConcepto_TextChanged(sender As Object, e As EventArgs) Handles cbConcepto.TextChanged
        If (cbConcepto.SelectedIndex >= 0) Then

            Dim dt As DataTable = CType(grdetalle.DataSource, DataTable)
            If (Not IsNothing(dt)) Then
                With grdetalle.RootTable.Columns("img")
                    .Width = 80
                    .Caption = "Eliminar".ToUpper
                    .CellStyle.ImageHorizontalAlignment = ImageHorizontalAlignment.Center
                    .Visible = True
                End With
            End If


        End If
    End Sub


    Private Sub cbConcepto_ValueChanged(sender As Object, e As EventArgs) Handles cbConcepto.ValueChanged
        If (_fnAccesible()) Then
            If (cbConcepto.Value = 9) Then
                '''''Aqui verifico si el concepto es igual a salida de productos de choferes obtengo su numi de conciliacion si existiese
                Dim dt As DataTable = L_prMovimientoChoferExisteConciliacionSalida(_codChofer) ''Aqui verifico si existe conciliacion con devolucion 
                If (dt.Rows.Count > 0) Then

                    Dim estado As Integer = dt.Rows(0).Item("ieest")
                    If (estado = 2) Then
                        If (cbConcepto.SelectedIndex > 0) Then
                            cbConcepto.SelectedIndex = 0
                        Else
                            cbConcepto.SelectedIndex = -1
                        End If
                    Else
                        Dim tabla As DataTable = L_prMovimientoChoferNoExisteConciliacion(_codChofer) ''Aqui obtengo el numi de la conciliacion si existiera con estado=1 si no tengo que insertar una
                        If (tabla.Rows.Count > 0) Then
                            _IdConciliacion = tabla.Rows(0).Item("ieid")
                        End If
                    End If
                End If

            Else
                '''''
            End If
        End If

    End Sub

    Private Sub btBuscarChofer_Click(sender As Object, e As EventArgs) Handles btBuscarChofer.Click
        P_prAyudaChofer()
    End Sub

    Private Sub P_prAyudaChofer()
        Dim dt As DataTable

        dt = L_prMovimientoChoferListarChoferes()
        '   a.cbnumi ,a.cbdesc ,a.cbci ,a.cbfnac

        Dim listEstCeldas As New List(Of Modelo.MCelda)
        listEstCeldas.Add(New Modelo.MCelda("cbnumi,", True, "ID", 50))
        listEstCeldas.Add(New Modelo.MCelda("cbdesc", True, "NOMBRE", 280))
        listEstCeldas.Add(New Modelo.MCelda("cbci", True, "CI".ToUpper, 150))
        listEstCeldas.Add(New Modelo.MCelda("cbfnac", True, "F.Nacimiento", 220, "MM/dd/YYYY"))

        Dim ef = New Efecto
        ef.tipo = 3
        ef.dt = dt
        ef.SeleclCol = 2
        ef.listEstCeldas = listEstCeldas
        ef.alto = 50
        ef.ancho = 350
        ef.Context = "Seleccione chofer".ToUpper
        ef.ShowDialog()
        Dim bandera As Boolean = False
        bandera = ef.band
        If (bandera = True) Then
            Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row

            _codChofer = Row.Cells("cbnumi").Value
            tbChofer.Text = Row.Cells("cbdesc").Value
            cbConcepto.Focus()

            _prCargarDetalleVenta(-1)
            _prAddDetalleVenta()
            With grdetalle.RootTable.Columns("img")
                .Width = 80
                .Caption = "Eliminar".ToUpper
                .CellStyle.ImageHorizontalAlignment = ImageHorizontalAlignment.Center
                .Visible = True
            End With
            _prObtenerNumiConciliacionTI0022()

            If (P_Global.gb_despacho) Then
                CargarDespachoDeChofer(_codChofer)
            End If
        End If
    End Sub

    Private Sub CargarDespachoDeChofer(codChofer As Integer)
        Try
            Dim listResult = New LPedido().ListarDespachoXProductoDeChoferSalida(codChofer)
            If (listResult.Count > 0) Then
                Dim info As New TaskDialogInfo("¿desea carga los producto de despacho del chofer?".ToUpper,
                                       eTaskDialogIcon.Information, "pregunta".ToUpper,
                                       "esta a punto de sobreescribir todo los productos".ToUpper _
                                       + vbCrLf + "Desea continuar?".ToUpper,
                                       eTaskDialogButton.Yes Or eTaskDialogButton.Cancel,
                                       eTaskDialogBackgroundColor.Blue)
                Dim result As eTaskDialogResult = TaskDialog.Show(info)
                If result = eTaskDialogResult.Yes Then
                    CType(grdetalle.DataSource, DataTable).Clear()
                    Dim i = 0
                    For Each item In listResult
                        _prAddDetalleVenta()
                        CType(grdetalle.DataSource, DataTable).Rows(i).Item("iccprod") = item.canumi
                        CType(grdetalle.DataSource, DataTable).Rows(i).Item("cacod") = item.cacod
                        CType(grdetalle.DataSource, DataTable).Rows(i).Item("producto") = item.cadesc

                        CType(grdetalle.DataSource, DataTable).Rows(i).Item("iccant") = item.obpcant
                        i += 1
                    Next
                    _prCargarProductos()
                End If
            Else
                Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
                ToastNotification.Show(Me, "No existe productos de despacho para el chofer".ToUpper, img, 3000, eToastGlowColor.Red, eToastPosition.TopCenter)
                'MBtGrabar.Enabled = False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub MBtImprimir_Click(sender As Object, e As EventArgs) Handles MBtImprimir.Click
        If (Not tbCodigo.Text.Trim = String.Empty) Then
            P_GenerarReporte()
        End If
    End Sub

    Private Sub P_GenerarReporte()
        Dim dt As DataTable
        dt = L_fnObtenerTabla("*", "vr_go_comprobanteSalidaItems", "id=" + tbCodigo.Text)

        If Not IsNothing(P_Global.Visualizador) Then
            P_Global.Visualizador.Close()
        End If

        P_Global.Visualizador = New Visualizador
        Dim objrep As New R_ComprobanteSalidaItems

        objrep.SetDataSource(dt)

        P_Global.Visualizador.CRV1.ReportSource = objrep
        P_Global.Visualizador.Show()
        P_Global.Visualizador.BringToFront()
    End Sub

    Private Sub tbTablet_ValueChanged(sender As Object, e As EventArgs) Handles tbTablet.ValueChanged
        _prCargarVenta()

    End Sub
End Class
