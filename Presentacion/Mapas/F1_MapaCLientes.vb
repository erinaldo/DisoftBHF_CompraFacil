Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports GMap.NET.MapProviders
Imports GMap.NET
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.ToolTips
Imports System.Drawing
Imports System.Threading
Imports DevComponents.DotNetBar.Controls

Public Class F1_MapaCLientes
    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim _Punto As Integer
    Dim _ListPuntos As List(Of PointLatLng)
    Dim _Overlay As GMapOverlay
    Dim _latitud As Double = 0
    Dim _longitud As Double = 0
    Dim TableCliente As DataTable
    Dim Markers As GMapMarker
    Dim cont As Integer = 0

    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

    Private Sub _IniciarTodo()
        If (Not gb_ConexionAbierta) Then
            L_prAbrirConexion("localhost", "sersolinf", "321", "BDDistBHF")
        End If
        _prCargarComboLibreriaZona(cbZona)
        Me.Text = "U B I C A C I Ó N   D E   C L I E N T E S"

        _prInicarMapa()
        _prObtenerDatatableClientes()
        _prCargarClientesJanus(TableCliente)

        slpanelInfo.Width = 0
        Panel1.Visible = True
        btnz1.Visible = True
        btnz2.Visible = True
        pbmap.Visible = True
        lbmap.Visible = True

        Gmc_Cliente.Zoom = Gmc_Cliente.Zoom - 2
        cbZona.ReadOnly = True
        checkTodos.CheckValue = True
        cbZona.Enabled = False

    End Sub

    Private Sub _prCargarComboLibreriaZona(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
        Dim dt As New DataTable
        dt = L_prListarZona()
        With mCombo
            .DropDownList.Columns.Clear()
            .DropDownList.Columns.Add("yccod3").Width = 60
            .DropDownList.Columns("yccod3").Caption = "COD"
            .DropDownList.Columns.Add("ycdes3").Width = 500
            .DropDownList.Columns("ycdes3").Caption = "DESCRIPCION"
            .ValueMember = "yccod3"
            .DisplayMember = "ycdes3"
            .DataSource = dt
            .Refresh()
        End With
    End Sub

    Public Sub _prCargarClientesJanus(Cliente As DataTable)
        Dim dt As New DataTable
        dt = Cliente
        ''''janosssssssss''''''
        grCliente.DataSource = dt
        grCliente.RetrieveStructure()
        grCliente.AlternatingColors = True
        grCliente.RowFormatStyle.Font = New Font("arial", 9)
        'dar formato a las columnas
        ''a.ccnumi ,a.ccdesc ,a.cctelf2 ,a.ccobs ,a.cclat ,a.cclongi 

        With grCliente.RootTable.Columns("ccnumi")
            .Width = 60
            .Caption = "CODIGO"

            .Visible = False

        End With

        With grCliente.RootTable.Columns("ccdesc")
            .Width = 250
            .Caption = "DESCRIPCION"
            .Visible = True
        End With

        With grCliente.RootTable.Columns("cccod")
            .Width = 90
            .Caption = "CODIGO"

            .Visible = True
        End With
        With grCliente.RootTable.Columns("cctelf2")
            .Width = 90
            .Caption = "TELEFONO"

            .Visible = False
        End With
        With grCliente.RootTable.Columns("ccobs")
            .Width = 90
            .Caption = "OBSERVACION"
            .Visible = False
        End With
        With grCliente.RootTable.Columns("cclat")
            .Width = 90

            .Visible = False
        End With
        With grCliente.RootTable.Columns("cclongi")
            .Caption = "NOMBRE"

            .Width = 110
            .Visible = False


        End With
        'With grCliente.RootTable.Columns("oblatitud")
        '    .Width = 90

        '    .Visible = False
        'End With
        'With grCliente.RootTable.Columns("oblongitud")
        '    '.Caption = "NOMBRE"

        '    .Width = 110
        '    .Visible = False
        'End With

        With grCliente
            .GroupByBoxVisible = False
            'diseño de la grilla

            '.CardSpacing = 50
            .CardHeaders = True
            .CollapseCards()

            .CardWidth = grCliente.Width - 25

            '.CardCaptionFormatStyle.FontBold = TriState.True
            .CardColumnHeaderFormatStyle.FontBold = TriState.True
            .CardColumnHeaderFormatStyle.ForeColor = Color.FromArgb(0, 85, 139)
            .VisualStyle = VisualStyle.Office2007
            '.View = View.CardView
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .RecordNavigator = True
            .RecordNavigatorText = "CLIENTES"
            .RowHeaders = InheritableBoolean.True
        End With


        grCliente.RowHeaderFormatStyle.FontBold = TriState.True
        grCliente.RowHeaderFormatStyle.FontSize = 12

        'grCliente.CardViewGridlines = CardViewGridlines.Vertical


    End Sub
    Public Sub _prObtenerDatatableClientes()
        TableCliente = L_prMapaCLienteGeneral()
        _prDibujarMarketCliente(TableCliente.Rows.Count - 1, TableCliente)
    End Sub

    Public Sub _prDibujarMarketCliente(n As Integer, Cliente As DataTable)
        If (n < 0) Then
            Return

        Else
            Dim lat As Double = Cliente.Rows(n).Item("cclat")
            Dim longitud As Double = Cliente.Rows(n).Item("cclongi")

            If (lat <> 0 And longitud <> 0) Then
                Dim plg As PointLatLng = New PointLatLng(lat, longitud)

                _latitud = plg.Lat
                _longitud = plg.Lng

                cont += 1
                P_AgregarPunto(plg, "", "", Cliente.Rows(n), 1)
            End If
            _prDibujarMarketCliente(n - 1, Cliente)

            'If RBPE.Checked Then
            '    Dim lat2 As Double = Cliente.Rows(n).Item("oblatitud")
            '    Dim longitud2 As Double = Cliente.Rows(n).Item("oblongitud")

            '    If (lat2 <> 0 And longitud2 <> 0) Then

            '        Dim plg1 As PointLatLng = New PointLatLng(lat2, longitud2)

            '        _latitud = plg1.Lat
            '        _longitud = plg1.Lng

            '        cont += 1
            '        P_AgregarPunto(plg1, "", "", Cliente.Rows(n), 2)

            '    End If
            '    _prDibujarMarketCliente(n - 1, Cliente)

            'Else
            '    Cliente.Rows(n).Item("oblatitud") = -1
            'End If

        End If

    End Sub
    Private Sub P_IniciarMap()
        Gmc_Cliente.DragButton = MouseButtons.Left
        Gmc_Cliente.CanDragMap = True
        Gmc_Cliente.MapProvider = GMapProviders.GoogleMap
        If (_latitud <> 0 And _longitud <> 0) Then

            Gmc_Cliente.Position = New PointLatLng(_latitud, _longitud)
        Else

            _Overlay.Markers.Clear()
            Gmc_Cliente.Position = New PointLatLng(-17.782814, -63.182386)
        End If

        Gmc_Cliente.MinZoom = 0
        Gmc_Cliente.MaxZoom = 24
        Gmc_Cliente.Zoom = 15.5
        Gmc_Cliente.AutoScroll = True

        GMapProvider.Language = LanguageType.Spanish
    End Sub
    Public Sub _prInicarMapa()

        _Punto = 0
        '_ListPuntos = New List(Of PointLatLng)
        _Overlay = New GMapOverlay("points")
        Gmc_Cliente.Overlays.Add(_Overlay)

        P_IniciarMap()

    End Sub
    Private Sub F1_MapaCLientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        _IniciarTodo()

    End Sub



    Private Sub P_AgregarPunto(pointLatLng As PointLatLng, _nombre As String, _ci As String, data As System.Data.DataRow, _Flag As Integer)

        If (Not IsNothing(_Overlay)) Then
            'añadir puntos
            'Dim markersOverlay As New GMapOverlay("markers")
            Dim marker As New GMarkerGoogle(pointLatLng, My.Resources.mark)

            'añadir tooltip
            Dim mode As MarkerTooltipMode = MarkerTooltipMode.OnMouseOver
            marker.ToolTip = New GMapBaloonToolTip(marker)
            marker.ToolTipMode = mode
            Dim ToolTipBackColor As SolidBrush
            If _Flag = 1 Then
                ToolTipBackColor = New SolidBrush(Color.Blue)
                marker.ToolTip.Fill = ToolTipBackColor
                marker.ToolTip.Foreground = Brushes.White
                marker.Tag = data
                _Overlay.Markers.Add(marker)
                'mapa.Overlays.Add(markersOverlay)
            Else
                ToolTipBackColor = New SolidBrush(Color.Red)
                marker.ToolTip.Fill = ToolTipBackColor
                marker.ToolTip.Foreground = Brushes.Red
                marker.Tag = data
                _Overlay.Markers.Add(marker)
                'mapa.Overlays.Add(markersOverlay)
            End If

            'mapa.Overlays.Add(markersOverlay)
        End If



    End Sub

    Private Sub Gmc_Cliente_OnMarkerClick(item As GMapMarker, e As MouseEventArgs) Handles Gmc_Cliente.OnMarkerClick
        If (Not IsNothing(Markers)) Then
            _Overlay.Markers.Remove(Markers)

        End If
        Panel1.Visible = False
        slpanelInfo.Visible = True
        Dim i As DataRow = CType(item.Tag, DataRow)
        Dim lat As String = i.Item("cclat")
        Dim tags As Object = item.Tag
        Dim longit As String = i.Item("cclongi")
        If RBPE.Checked Then
            If i.Item("oblatitud") <> -1 Then
                lat = i.Item("oblatitud")
                longit = i.Item("oblongitud")
            End If
        End If
        lbcliente.Text = i.Item("ccdesc")

        If (IsDBNull(i.Item("ccobs")) Or IsNothing(i.Item("ccobs"))) Then
            lbobs.Text = ""

        Else
            lbobs.Text = i.Item("ccobs")
        End If

        lbtel.Text = i.Item("cctelf2")






        'Dim markersOverlay As New GMapOverlay("markers")
        Dim marker As New GMarkerGoogle(New PointLatLng(lat, longit), My.Resources.markerA)

        'añadir tooltip
        Dim mode As MarkerTooltipMode = MarkerTooltipMode.OnMouseOver
        marker.ToolTip = New GMapBaloonToolTip(marker)
        marker.ToolTipMode = mode
        Dim ToolTipBackColor As New SolidBrush(Color.Blue)
        marker.ToolTip.Fill = ToolTipBackColor
        marker.ToolTip.Foreground = Brushes.White
        marker.Tag = tags

        Markers = marker

        _Overlay.Markers.Add(marker)

        Gmc_Cliente.Position = New PointLatLng(lat, longit)
        While (slpanelInfo.Width < 358)
            slpanelInfo.Width += 1
            Thread.Sleep(0.1)
        End While

        _prHabilitarLAbel()









    End Sub
    Public Sub _prHabilitarLAbel()
        lb1.Visible = True
        lb2.Visible = True
        lb3.Visible = True
        lb4.Visible = True
        lbcliente.Visible = True
        lbobs.Visible = True
        lbtel.Visible = True
        btn1.Visible = True

    End Sub

    Public Sub _prInhabilitarHabilitarLAbel()
        lb1.Visible = False
        lb2.Visible = False
        lb3.Visible = False
        lb4.Visible = False
        lbcliente.Visible = False
        lbobs.Visible = False
        lbtel.Visible = False
        btn1.Visible = False

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Panel1.Visible = True
        While (slpanelInfo.Width > 0)
            slpanelInfo.Width -= 10

        End While
        _prInhabilitarHabilitarLAbel()
        If (Not IsNothing(Markers)) Then
            _Overlay.Markers.Remove(Markers)

        End If
        '' grCliente.RemoveFilters()
        Gmc_Cliente.Position = New PointLatLng(-17.782814, -63.182386)
        Gmc_Cliente.Zoom = 13

    End Sub

    Private Sub PanelSuperior_Paint(sender As Object, e As PaintEventArgs) Handles PanelSuperior.Paint

    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles btnz1.Click
        If (Gmc_Cliente.Zoom <= Gmc_Cliente.MaxZoom) Then
            Gmc_Cliente.Zoom = Gmc_Cliente.Zoom + 1
        End If
    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles btnz2.Click
        If (Gmc_Cliente.Zoom >= Gmc_Cliente.MinZoom) Then
            Gmc_Cliente.Zoom = Gmc_Cliente.Zoom - 1
        End If
    End Sub


    Public Sub _prRecorreMArket(latitud As String, longitud As String, ByRef ma As GMapMarker)
        Dim a As List(Of GMapMarker) = _Overlay.Markers.ToList
        For k = 0 To a.Count - 1 Step 1
            Dim mark As GMapMarker = a(k)
            Dim i As DataRow = CType(mark.Tag, DataRow)
            Dim lat As String = i.Item("cclat")
            Dim longit As String = i.Item("cclongi")
            If (lat.Equals(latitud) And longit.Equals(longitud)) Then
                ma = mark
                Return

            End If
        Next


        '    Dim length As Integer = a.Length
    End Sub

    Private Sub MBtSalir_Click(sender As Object, e As EventArgs) Handles MBtSalir.Click
        Me.Close()
        _modulo.Select()
        _tab.Close()
    End Sub

    Private Sub checkTodos_CheckValueChanged(sender As Object, e As EventArgs) Handles checkTodos.CheckValueChanged
        If (checkTodos.Checked = False) Then
            cbZona.Enabled = True
            cbZona.ReadOnly = False
            If (CType(cbZona.DataSource, DataTable).Rows.Count > 0) Then
                cbZona.SelectedIndex = 0
                Dim dt As DataTable = L_prListarClienteZona(cbZona.Value)
                _prCargarClientesJanus(dt)
                _Overlay.Markers.Clear()
                _prDibujarMarketCliente(dt.Rows.Count - 1, dt)
            End If
        End If

        If (checkTodos.Checked = True) Then
            cbZona.Enabled = False
            cbZona.ReadOnly = True

            Dim dt As DataTable = L_prMapaCLienteGeneral()
            _prCargarClientesJanus(dt)
            _Overlay.Markers.Clear()
            _prDibujarMarketCliente(dt.Rows.Count - 1, dt)
        End If
    End Sub

    Private Sub cbZona_ValueChanged(sender As Object, e As EventArgs) Handles cbZona.ValueChanged
        If (cbZona.SelectedIndex >= 0) Then
            Dim dt As DataTable = L_prListarClienteZona(cbZona.Value)
            _prCargarClientesJanus(dt)
            _Overlay.Markers.Clear()
            _prDibujarMarketCliente(dt.Rows.Count - 1, dt)
        End If
    End Sub

    Private Sub grCliente_DoubleClick_1(sender As Object, e As EventArgs) Handles grCliente.DoubleClick
        Dim _MPos As Integer
        If grCliente.Row >= 0 Then
            _MPos = grCliente.Row
            Panel1.Visible = False
            slpanelInfo.Visible = True

            Dim longit As String = grCliente.GetValue("cclongi")
            lbcliente.Text = grCliente.GetValue("ccdesc").ToString
            If (IsDBNull(grCliente.GetValue("ccobs")) Or IsNothing(grCliente.GetValue("ccobs"))) Then
                lbobs.Text = ""

            Else
                lbobs.Text = grCliente.GetValue("ccobs").ToString
            End If

            lbtel.Text = grCliente.GetValue("cctelf2")


            While (slpanelInfo.Width < 358)
                slpanelInfo.Width += 5

            End While
            _prHabilitarLAbel()
            Dim gma As GMapMarker
            _prRecorreMArket(grCliente.GetValue("cclat"), grCliente.GetValue("cclongi"), gma)
            If (Not IsNothing(gma)) Then

                Dim marker As New GMarkerGoogle(New PointLatLng(grCliente.GetValue("cclat"), grCliente.GetValue("cclongi")), My.Resources.markerA)

                'añadir tooltip
                Dim mode As MarkerTooltipMode = MarkerTooltipMode.OnMouseOver
                marker.ToolTip = New GMapBaloonToolTip(marker)
                marker.ToolTipMode = mode
                Dim ToolTipBackColor As New SolidBrush(Color.Blue)
                marker.ToolTip.Fill = ToolTipBackColor
                marker.ToolTip.Foreground = Brushes.White
                marker.Tag = gma.Tag

                Markers = marker

                _Overlay.Markers.Add(marker)
                Gmc_Cliente.Position = New PointLatLng(grCliente.GetValue("cclat"), grCliente.GetValue("cclongi"))
                Gmc_Cliente.Zoom = Gmc_Cliente.MaxZoom - 8
            Else


                ToastNotification.Show(Me, "NO EXISTE UBICACION PARA ESTE CLIENTE", My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            End If

        End If
    End Sub

    Private Sub grCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grCliente.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Dim _MPos As Integer
            If grCliente.Row >= 0 Then
                _MPos = grCliente.Row
                Panel1.Visible = False
                slpanelInfo.Visible = True

                Dim longit As String = grCliente.GetValue("cclongi")
                lbcliente.Text = grCliente.GetValue("ccdesc").ToString
                If (IsDBNull(grCliente.GetValue("ccobs")) Or IsNothing(grCliente.GetValue("ccobs"))) Then
                    lbobs.Text = ""

                Else
                    lbobs.Text = grCliente.GetValue("ccobs").ToString
                End If

                lbtel.Text = grCliente.GetValue("cctelf2")


                While (slpanelInfo.Width < 358)
                    slpanelInfo.Width += 2
                    'Thread.Sleep(0.1)
                End While
                _prHabilitarLAbel()
                Dim gma As GMapMarker
                _prRecorreMArket(grCliente.GetValue("cclat"), grCliente.GetValue("cclongi"), gma)
                If (Not IsNothing(gma)) Then

                    Dim marker As New GMarkerGoogle(New PointLatLng(grCliente.GetValue("cclat"), grCliente.GetValue("cclongi")), My.Resources.markerA)

                    'añadir tooltip
                    Dim mode As MarkerTooltipMode = MarkerTooltipMode.OnMouseOver
                    marker.ToolTip = New GMapBaloonToolTip(marker)
                    marker.ToolTipMode = mode
                    Dim ToolTipBackColor As New SolidBrush(Color.Blue)
                    marker.ToolTip.Fill = ToolTipBackColor
                    marker.ToolTip.Foreground = Brushes.White
                    marker.Tag = gma.Tag

                    Markers = marker

                    _Overlay.Markers.Add(marker)
                    Gmc_Cliente.Position = New PointLatLng(grCliente.GetValue("cclat"), grCliente.GetValue("cclongi"))
                    Gmc_Cliente.Zoom = Gmc_Cliente.MaxZoom - 8

                Else


                    ToastNotification.Show(Me, "NO EXISTE UBICACION PARA ESTE CLIENTE", My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                End If

            End If
        End If
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Dim dt As DataTable = CType(grCliente.DataSource, DataTable).Copy
        dt.Clear()

        For i As Integer = 0 To grCliente.RowCount - 1 Step 1
            'a.ccnumi , a.cccod, isnull(a.ccdesc,'') as ccdesc ,isnull (a.cctelf2,'') as cctelf2 ,
            'isnull(a.ccobs,'' )as ccobs,isnull( a.cclat,'0' ) as cclat
            ', isnull(a.cclongi,'0') as cclongi
            dt.Rows.Add(grCliente.GetRow(i).Cells("ccnumi").Value, grCliente.GetRow(i).Cells("cccod").Value, grCliente.GetRow(i).Cells("ccdesc").Value, grCliente.GetRow(i).Cells("cctelf2").Value, grCliente.GetRow(i).Cells("ccobs").Value, grCliente.GetRow(i).Cells("cclat").Value, grCliente.GetRow(i).Cells("cclongi").Value)
        Next


        _Overlay.Markers.Clear()



        _prDibujarMarketCliente(dt.Rows.Count - 1, dt)
    End Sub

    Private Sub RBPE_CheckedChanged(sender As Object, e As EventArgs) Handles RBPE.CheckedChanged
        If RBPE.Checked Then
            Dt_Fecha.Visible = True
            _MostrarPedido()
        Else
            Dt_Fecha.Visible = False
            _MostrarCliente()
        End If
    End Sub
    Private Sub _MostrarPedido()
        Dim dt As DataTable
        If checkTodos.Checked Then
            dt = L_prListarClienteZona3(cbZona.Value, Dt_Fecha.Value)
        Else
            dt = L_prListarClienteZona2(cbZona.Value, Dt_Fecha.Value)
        End If
        _prCargarClientesJanus(dt)
        _Overlay.Markers.Clear()
        _prDibujarMarketCliente(dt.Rows.Count - 1, dt)
    End Sub
    Private Sub _MostrarCliente()
        If (checkTodos.Checked = False) Then
            cbZona.Enabled = True
            cbZona.ReadOnly = False
            If (CType(cbZona.DataSource, DataTable).Rows.Count > 0) Then
                cbZona.SelectedIndex = 0
                Dim dt As DataTable = L_prListarClienteZona(cbZona.Value)
                _prCargarClientesJanus(dt)
                _Overlay.Markers.Clear()
                _prDibujarMarketCliente(dt.Rows.Count - 1, dt)
            End If
        End If

        If (checkTodos.Checked = True) Then
            cbZona.Enabled = False
            cbZona.ReadOnly = True

            Dim dt As DataTable = L_prMapaCLienteGeneral()
            _prCargarClientesJanus(dt)
            _Overlay.Markers.Clear()
            _prDibujarMarketCliente(dt.Rows.Count - 1, dt)
        End If
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub Dt_Fecha_ValueChanged(sender As Object, e As EventArgs) Handles Dt_Fecha.ValueChanged
        _MostrarPedido()
    End Sub

    Private Sub grCliente_FormattingRow(sender As Object, e As RowLoadEventArgs) Handles grCliente.FormattingRow

    End Sub
End Class