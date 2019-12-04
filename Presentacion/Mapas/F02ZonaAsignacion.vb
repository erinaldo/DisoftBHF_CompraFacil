Imports Logica.AccesoLogica
Imports GMap.NET.MapProviders
Imports GMap.NET
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.WindowsForms.ToolTips
Imports DevComponents.DotNetBar
Imports System.IO
Imports Janus.Data
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar.Controls

Public Class F02ZonaAsignacion

#Region "Atributos generales"

    Dim StTitulo As String = "Z O N A S"

    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

    Public _DtRepartidores As DataTable
    Public _DtZonas As DataTable
    Public _DtDetalleZonas As DataTable

#End Region

#Region "Propiedades generales"

    Public Property Titulo As String
        Get
            Return StTitulo
        End Get
        Set(value As String)
            StTitulo = value
        End Set
    End Property

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

    Dim _poligono As Integer
    Dim _listPuntos As List(Of PointLatLng)
    Dim _overlay As GMapOverlay

    Private Sub F02ZonaAsignacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        P_prInicio()
    End Sub

    Private Sub MBtModificar_Click(sender As Object, e As EventArgs) Handles MBtModificar.Click
        P_prModificarRegistro()
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
        If (DgjBusqueda.Row > -1) Then
            P_prLlenarDatos(DgjBusqueda.Row)
        End If
    End Sub


#End Region

#Region "Metodos Privados"
    Private Sub P_prInicio()
        'Abrir conexión
        If (Not gb_ConexionAbierta) Then
            L_prAbrirConexion()
        End If

        'Validar requisitos del programa
        If (Not P_fnValidarRequisitos() = String.Empty) Then
            Return
        End If
        _DtDetalleZonas = L_prListarZonas()

        'Inicializar componentes
        P_prInicializarComponentes()

        'Habilitar/Deshabilitar compotentes del formulario
        P_prHDComponentes(False)

        MBtNuevo.Visible = False
        MBtEliminar.Visible = False

        'Armar todo las grillas
        BoNavegar = False
        P_PrArmarGrillas()
        BoNavegar = True

        P_prActualizarPaginacion(0)
        P_prLlenarDatos(0)

    End Sub

    Private Function P_fnValidarRequisitos() As String
        Dim sms As String = ""

        'Crea la carpeta de imagenes si es que no estuviera creada.
        'P_prValidarCarpetaImagenes()

        If (Not sms = String.Empty) Then
            ToastNotification.Show(Me,
                                   "".ToUpper,
                                   My.Resources.WARNING,
                                   InDuracion * 1000,
                                   eToastGlowColor.Red,
                                   eToastPosition.TopCenter)
        End If

        Return sms
    End Function


    Private Sub P_prInicializarComponentes()
        'Form
        Me.Text = Titulo
        Me.WindowState = FormWindowState.Maximized
        Me.MSuperTabControlPrincipal.SelectedTabIndex = 0
        'Visible
        MBtImprimir.Visible = False


        'Enabled
        MBtGrabar.Enabled = False


        'Grid Busqueda
        DgjBusqueda.AllowEdit = Janus.Data.InheritableBoolean.False


        'Funciones
        P_prAsignarPermisos()

        'Mapa
        _poligono = 0
        _listPuntos = New List(Of PointLatLng)
        _overlay = New GMapOverlay("polygons")


        'Usuario del sistema
        MTbUsuario.Text = gs_user

        'Super Tab's
        SuperTabControlPersonal.SelectedTabIndex = 0
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
    Private Sub P_prHDComponentes(ByVal flat As Boolean)


        dgjRepartidor.AllowEdit = IIf(flat, 1, 2)
        dgjPrevendedor.AllowEdit = IIf(flat, 1, 2)

    End Sub

    Private Sub P_prLimpiar()

        _listPuntos.Clear()
        _overlay.Polygons.Clear()
        _overlay.Markers.Clear()

        P_prArmarGrillaRepartidor()
        P_prArmarGrillaPrevendedor()
        P_prLimpiarErrores()

        _poligono = 0
        _listPuntos = New List(Of PointLatLng)
        _overlay = New GMapOverlay("polygons")
        MBtGrabar.Tooltip = "GRABAR"
    End Sub



    Private Sub P_PrArmarGrillas()
        P_prArmarGrillaBusqueda()
        P_prArmarGrillaRepartidor()
        P_prArmarGrillaPrevendedor()
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

            With DgjBusqueda
                    Me.TbCodigo.Text = .GetValue("numi").ToString
                    MLbFecha.Text = CType(.GetValue("fact").ToString, Date).ToString("dd/MM/yyyy")
                    MLbHora.Text = .GetValue("hact").ToString
                    MLbUsuario.Text = .GetValue("uact").ToString
                End With


                'cargar lista repartidores
                P_prArmarGrillaRepartidor()
                '' Dim tRep As DataTable = L_ZonaDetalleRepartidor_General(-1, TbCodigo.Text).Tables(0)
                Dim tRep As DataTable = ObtenerDetalleZonas(TbCodigo.Text)
                Dim codRep As Integer
                For Each fil1 As GridEXRow In dgjRepartidor.GetRows
                    codRep = fil1.Cells("numi").Value
                    For Each fil2 As DataRow In tRep.Rows
                        If (codRep = fil2.Item("lccbnumi")) Then
                            fil1.BeginEdit()
                            fil1.Cells("check").Value = True
                            fil1.EndEdit()
                            Exit For
                        End If
                    Next
                Next

                'cargar lista prevendedor
                P_prArmarGrillaPrevendedor()
                ''  Dim tPre As DataTable = L_ZonaDetalleRepartidor_General(-1, TbCodigo.Text).Tables(0)
                Dim tPre As DataTable = ObtenerDetalleZonas(TbCodigo.Text)
                Dim codPre As Integer
                For Each fil1 As GridEXRow In dgjPrevendedor.GetRows
                    codPre = fil1.Cells("numi").Value
                    For Each fil2 As DataRow In tPre.Rows
                        If (codPre = fil2.Item("lccbnumi")) Then
                            fil1.BeginEdit()
                            fil1.Cells("check").Value = True
                            fil1.EndEdit()
                            Exit For
                        End If
                    Next
                Next

                P_prActualizarPaginacion(DgjBusqueda.Row)

            Else
            If (DgjBusqueda.GetRows.Count > 0) Then
                DgjBusqueda.MoveTo(CInt(MLbPaginacion.Text.Trim.Split(" ")(1).Trim))
            End If
        End If
    End Sub

    Public Function ObtenerDetalleZonas(zona As Integer) As DataTable
        Dim dt As DataTable = New DataTable
        Dim dc As DataColumn
        dc = New DataColumn("lcnumi", Type.GetType("System.Int32"))
        dt.Columns.Add(dc)
        Dim dc2 As DataColumn
        dc2 = New DataColumn("lccbnumi", Type.GetType("System.Int32"))
        dt.Columns.Add(dc2)

        For i As Integer = 0 To _DtDetalleZonas.Rows.Count - 1 Step 1
            If (_DtDetalleZonas.Rows(i).Item("lcnumi") = zona And _DtDetalleZonas.Rows(i).Item("estado") >= 0) Then
                dt.Rows.Add(_DtDetalleZonas.Rows(i).Item("lcnumi"), _DtDetalleZonas.Rows(i).Item("lccbnumi"))
            End If
        Next
        Return dt
    End Function
    Private Sub P_prNuevoRegistro()
        P_prLimpiar()
        P_prEstadoNueModEli(1)
        P_prHDComponentes(BoNuevo)


    End Sub

    Private Sub P_prModificarRegistro()
        P_prEstadoNueModEli(2)
        P_prHDComponentes(BoModificar)

    End Sub
    Private Sub P_prGrabarRegistro()
        'Dim numi As String
        If (BoModificar) Then
            If (P_fnValidarGrabacion()) Then
                'numi = TbCodigo.Text.Trim

                'Grabar
                Dim res As Boolean = GrabarDetalleZona(_DtDetalleZonas)




                If (res) Then
                    _DtDetalleZonas = L_prListarZonas()
                    BoNavegar = False
                    P_prArmarGrillaBusqueda()
                    BoNavegar = True

                    P_prMoverIndexActual()
                    MBtSalir.PerformClick()
                    DgjBusqueda.Enabled = True
                    ToastNotification.Show(Me, "Codigo de zona ".ToUpper + TbCodigo.Text + " Modificado con Exito.".ToUpper,
                                   My.Resources.GRABACION_EXITOSA,
                                   InDuracion * 1000,
                                   eToastGlowColor.Green,
                                   eToastPosition.TopCenter)
                Else
                    ToastNotification.Show(Me, "No se pudo modificar Zonas ".ToUpper + TbCodigo.Text + ", intente nuevamente.".ToUpper,
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
        DgjBusqueda.Enabled = True
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

        MSuperTabItemBusqueda.Visible = (value = 4)
        'Compentes

        If (MSuperTabControlPrincipal.SelectedTabIndex = 1) Then
            MSuperTabControlPrincipal.SelectedTabIndex = 0
        End If

    End Sub

    Private Sub P_prArmarGrillaBusqueda()
        DtBusqueda = New DataTable
        If (IsDBNull(_DtZonas) Or IsNothing(_DtZonas)) Then
            _DtZonas = L_fnZonaGeneral()
            DtBusqueda = _DtZonas.Copy
        Else
            DtBusqueda = _DtZonas.Copy
        End If
        DgjBusqueda.BoundMode = Janus.Data.BoundMode.Bound
        DgjBusqueda.DataSource = DtBusqueda
        DgjBusqueda.RetrieveStructure()

        'dar formato a las columnas
        With DgjBusqueda.RootTable.Columns(0)
            .Caption = "Código"
            .Key = "numi"
            .Width = 80
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(1)
            .Caption = ""
            .Key = "ccity"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(2)
            .Caption = "Ciudad"
            .Key = "ncity"
            .Width = 150
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(3)
            .Caption = ""
            .Key = "cprov"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(4)
            .Caption = "Provincia"
            .Key = "nprov"
            .Width = 150
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(5)
            .Caption = ""
            .Key = "czona"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(6)
            .Caption = "Zona"
            .Key = "nzona"
            .Width = 300
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With DgjBusqueda.RootTable.Columns(7)
            .Caption = "Color"
            .Key = "Color"
            .Width = 100
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(8)
            .Caption = ""
            .Key = "fact"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(9)
            .Caption = ""
            .Key = "hact"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With DgjBusqueda.RootTable.Columns(10)
            .Caption = ""
            .Key = "uact"
            .Width = 0
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With

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

    Private Sub P_prArmarGrillaRepartidor()
        Dim dt As New DataTable

        If (IsDBNull(_DtRepartidores) Or IsNothing(_DtRepartidores)) Then
            _DtRepartidores = L_fnObtenerTabla("cast(0 as bit) as [check], a.cbnumi as numi, a.cbdesc as [desc]", "TC002 a", "a.cbcat=1 and a.cbest=1")
            dt = _DtRepartidores.Copy

        Else
            dt = _DtRepartidores.Copy
        End If

        dgjRepartidor.BoundMode = Janus.Data.BoundMode.Bound
        dgjRepartidor.DataSource = dt
        dgjRepartidor.RetrieveStructure()

        'dar formato a las columnas
        With dgjRepartidor.RootTable.Columns("check")
            .Caption = "Check"
            .Width = 50
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = True
        End With
        With dgjRepartidor.RootTable.Columns("numi")
            .Visible = False
        End With
        With dgjRepartidor.RootTable.Columns("desc")
            .Caption = "Nombre Repartidor"
            .Width = 350
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With

        'Habilitar Filtradores
        With dgjRepartidor
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
            .SelectionMode = SelectionMode.MultipleSelection
            .AlternatingColors = True
        End With
    End Sub

    Private Sub P_prArmarGrillaPrevendedor()
        Dim dt As New DataTable
        dt = L_fnObtenerTabla("cast(0 as bit) as [check], a.cbnumi as numi, a.cbdesc as [desc]", "TC002 a", "a.cbcat=3 and a.cbest=1")

        dgjPrevendedor.BoundMode = Janus.Data.BoundMode.Bound
        dgjPrevendedor.DataSource = dt
        dgjPrevendedor.RetrieveStructure()

        'dar formato a las columnas
        With dgjPrevendedor.RootTable.Columns("check")
            .Caption = "Check"
            .Width = 50
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = True
        End With
        With dgjPrevendedor.RootTable.Columns("numi")
            .Visible = False
        End With
        With dgjPrevendedor.RootTable.Columns("desc")
            .Caption = "Nombre Repartidor"
            .Width = 350
            .HeaderStyle.Font = FtTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With

        'Habilitar Filtradores
        With dgjPrevendedor
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
            .SelectionMode = SelectionMode.MultipleSelection
            .AlternatingColors = True
        End With
    End Sub

    Private Function P_fnValidarGrabacion() As Boolean
        Dim res As Boolean = True
        MEP.Clear()





        'Validar que este eligido un repartidor
        Dim flat As Boolean = False
        For Each fil As GridEXRow In dgjRepartidor.GetRows
            If (fil.Cells("check").Value) Then
                flat = True
                Exit For
            End If
        Next

        If (Not flat) Then
            dgjRepartidor.BackColor = Color.Red
            ToastNotification.Show(Me,
                                   "Elija un repartidor.".ToUpper,
                                   My.Resources.WARNING,
                                   InDuracion * 1000,
                                   eToastGlowColor.Red,
                                   eToastPosition.TopCenter)

            res = False
        Else
            dgjRepartidor.BackColor = Color.White
        End If

        Return res
    End Function

    Private Sub P_prLimpiarErrores()
        MEP.Clear()
        dgjRepartidor.BackColor = Color.White
    End Sub

    Private Sub dgjRepartidor_EditingCell(sender As Object, e As EditingCellEventArgs) Handles dgjRepartidor.EditingCell
        If (BoNuevo Or BoModificar) Then
            If (e.Column.Index = dgjRepartidor.RootTable.Columns("check").Index) Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub dgjPrevendedor_EditingCell(sender As Object, e As EditingCellEventArgs) Handles dgjPrevendedor.EditingCell
        If (BoNuevo Or BoModificar) Then
            If (e.Column.Index = dgjPrevendedor.RootTable.Columns("check").Index) Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub dgjRepartidor_CellValueChanged(sender As Object, e As ColumnActionEventArgs) Handles dgjRepartidor.CellValueChanged


        If (e.Column.Index = dgjRepartidor.RootTable.Columns("check").Index) Then
            If (dgjRepartidor.GetValue("check") = True) Then
                Dim numi As Integer = dgjRepartidor.GetValue("numi")
                Dim posicion As Integer = _ExisteRepartidor(TbCodigo.Text, numi)
                If (posicion >= 0) Then
                    Dim estado = _DtDetalleZonas.Rows(posicion).Item("estado")
                    If (estado = -1) Then
                        _DtDetalleZonas.Rows(posicion).Item("estado") = 1
                    End If
                    If (estado = -2) Then
                        _DtDetalleZonas.Rows(posicion).Item("estado") = 0
                    End If

                Else
                    _DtDetalleZonas.Rows.Add(TbCodigo.Text, numi, 0)

                End If
            Else
                Dim numi As Integer = dgjRepartidor.GetValue("numi")
                Dim posicion As Integer = _ExisteRepartidor(TbCodigo.Text, numi)
                If (posicion >= 0) Then
                    Dim estado = _DtDetalleZonas.Rows(posicion).Item("estado")
                    If (estado = 1) Then
                        _DtDetalleZonas.Rows(posicion).Item("estado") = -1
                    Else
                        If (estado >= 0) Then
                            _DtDetalleZonas.Rows(posicion).Item("estado") = -2
                        End If
                    End If

                End If

            End If
        End If
    End Sub

    Public Function _ExisteRepartidor(zona As Integer, repartidor As Integer)

        For i As Integer = 0 To _DtDetalleZonas.Rows.Count - 1 Step 1

            If ((_DtDetalleZonas.Rows(i).Item("lcnumi") = zona) And (_DtDetalleZonas.Rows(i).Item("lccbnumi") = repartidor) And (_DtDetalleZonas.Rows(i).Item("estado") >= 0)) Then

                Return i
            End If
        Next
        Return -1
    End Function

#End Region
End Class