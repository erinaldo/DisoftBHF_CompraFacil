Imports GMap.NET.WindowsForms
Imports Logica.AccesoLogica
Imports GMap.NET
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.WindowsForms.ToolTips
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class F01_MonitoreoPedido

#Region "Atributos"
    'cantidad de colores en el marker son 37
    Dim _overlay As New GMapOverlay
    Dim _listRepAct As New List(Of DataRow)
    Dim _RutaImagenes As String

    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

#End Region

#Region "Metodos Privados"
    Dim _listColores As List(Of Color)
    Private Sub _PIniciarTodo()

        If (Not gb_ConexionAbierta) Then
            L_prAbrirConexion("localhost", "sersolinf", "321", "BDDistBHF")
        End If
        _prCargarListaColores()
        MBtNuevo.Visible = False
        MBtModificar.Visible = False
        MBtEliminar.Visible = False
        MBtGrabar.Visible = False
        MBtImprimir.Visible = False

        MPanelToolBarNavegacion.Visible = False

        _RutaImagenes = gs_RutaImagenes + "\"

        Me.Text = "M O N I T O R E O   D E   P E D I D O S"
        MRlAccion.Text = "M O N I T O R E O   D E   P E D I D O S"
        Me.WindowState = FormWindowState.Maximized

        'cargar mapas
        _PCargarMapa(GM_Mapa, _overlay)
        _PCargarZonas()


        ''_PCargarPedidos()

        'cargar ruta
        ''_prCargarRuta(GM_Mapa)

        'bloquear todos los botones
        TimerRuta.Interval = 30000
        _prCargarGridPersonal()
        _prCargarComboCiudades()
    End Sub

    Private Sub _prCargarComboCiudades()
        J_Cb_Ciudad.Items.Add("SANTA CRUZ")
        J_Cb_Ciudad.Items.Add("COCHABAMBA")
        J_Cb_Ciudad.Items.Add("LA PAZ")
        J_Cb_Ciudad.SelectedIndex = 0
    End Sub

    Private Sub _prCargarGridPersonal()
        Dim dt As New DataTable
        dt = L_Empleado_GeneralRepartidorSimple(-1, "and cbcat=1 and cbest=1").Tables(0)

        dt.Columns.Add("estado", Type.GetType("System.Boolean"))
        dt.Columns.Add("color", Type.GetType("System.Int32"))

        grRepartidores.DataSource = dt
        grRepartidores.RetrieveStructure()

        'dar formato a las columnas
        With grRepartidores.RootTable.Columns("cbnumi")
            .Caption = "Cod".ToUpper
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grRepartidores.RootTable.Columns("cbdesc")
            .Caption = "Nombre"
            .Width = 250
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        With grRepartidores.RootTable.Columns("estado")
            .Caption = "Check"
            .Width = 50
        End With

        With grRepartidores.RootTable.Columns("cbfot")
            .Visible = False
        End With

        With grRepartidores.RootTable.Columns("color")
            .Visible = False
        End With

        Dim i As Integer = 0
        For Each fila As DataRow In dt.Rows
            ''  Dim _color As Integer = _prGetColorByPos(i)
            Dim _color As Integer = i
            fila.Item("estado") = 0
            fila.Item("color") = _color

            'Dim _estiloFila As New GridEXFormatStyle()
            'Dim _fil As Janus.Windows.GridEX.GridEXRow
            '_fil = grRepartidores.GetRow(i)
            '_estiloFila.BackColor = _prGetoColor(color)
            '_fil.RowStyle = _estiloFila

            Dim fc As GridEXFormatCondition
            fc = New GridEXFormatCondition(grRepartidores.RootTable.Columns("color"), ConditionOperator.Equal, _color)
            fc.FormatStyle.BackColor = _listColores(_color)
            fc.FormatStyle.BackColorGradient = _listColores(_color)
            grRepartidores.RootTable.FormatConditions.Add(fc)
            i = i + 1
        Next

        'Habilitar Filtradores
        With grRepartidores
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
            .AllowEdit = InheritableBoolean.False
        End With
    End Sub

    Private Function _prGetoColor(i As Integer) As Color
        Select Case i
            Case GMarkerGoogleType.blue
                Return Color.Blue
            Case GMarkerGoogleType.red
                Return Color.Red
            Case GMarkerGoogleType.yellow
                Return Color.Yellow
            Case GMarkerGoogleType.green
                Return Color.Green
            Case GMarkerGoogleType.orange
                Return Color.Orange
            Case GMarkerGoogleType.pink
                Return Color.Pink
            Case GMarkerGoogleType.brown_small
                Return Color.Brown
            Case GMarkerGoogleType.gray_small
                Return Color.Gray
            Case GMarkerGoogleType.lightblue
                Return Color.LightBlue
        End Select
    End Function

    Private Sub _prCargarListaColores()
        _listColores = New List(Of Color)
        _listColores.Add(_prGetColorFromHex("#fc8894")) 'red 100
        _listColores.Add(_prGetColorFromHex("#dd5bf3")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#5266dd")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#8ff615")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#fafa2c")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100


        'mas colores repetidos
        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100

        'mas colores repetidos
        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100

        'mas colores repetidos
        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100

        'mas colores repetidos
        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100

        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100


        'mas colores repetidos
        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100

        'mas colores repetidos
        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100

        'mas colores repetidos
        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100

        'mas colores repetidos
        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100

        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100


        'mas colores repetidos
        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100

        'mas colores repetidos
        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100

        'mas colores repetidos
        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100

        'mas colores repetidos
        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100

        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100


        'mas colores repetidos
        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100

        'mas colores repetidos
        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100

        'mas colores repetidos
        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100

        'mas colores repetidos
        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100

        'mas colores repetidos
        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100

        'mas colores repetidos
        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100

        'mas colores repetidos
        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100
    End Sub


    Public Function _prGetColorFromHex(hexcolor As String) As Color
        'hex = Replace(hex, "#", "")
        'hex = "&H" & hex
        'ColorTranslator.FromOle(hex)
        Dim Red As String
        Dim Green As String
        Dim Blue As String
        hexcolor = Replace(hexcolor, "#", "")
        Red = Val("&H" & Mid(hexcolor, 1, 2))
        Green = Val("&H" & Mid(hexcolor, 3, 2))
        Blue = Val("&H" & Mid(hexcolor, 5, 2))
        Return Color.FromArgb(Red, Green, Blue)
    End Function

    Private Function _prGetColorByPos(i As Integer) As Integer
        Select Case i
            Case 0
                Return GMarkerGoogleType.blue
            Case 1
                Return GMarkerGoogleType.red
            Case 2
                Return GMarkerGoogleType.yellow
            Case 3
                Return GMarkerGoogleType.green
            Case 4
                Return GMarkerGoogleType.orange
            Case 5
                Return GMarkerGoogleType.gray_small
            Case 6
                Return GMarkerGoogleType.pink
            Case 7
                Return GMarkerGoogleType.brown_small
            Case 8
                Return GMarkerGoogleType.lightblue
            Case 9
                Return GMarkerGoogleType.blue
            Case 10
                Return GMarkerGoogleType.blue
            Case 11
                Return GMarkerGoogleType.blue
            Case 12
                Return GMarkerGoogleType.blue
            Case 13
                Return GMarkerGoogleType.blue
        End Select

    End Function

    Private Sub _prDibujarPunto(ByRef objOverlay As GMapOverlay, pointLatLng As PointLatLng, Optional etiqueta As String = "")

        'añadir puntos
        ''Dim markersOverlay As New GMapOverlay("markers")
        Dim marker As New GMarkerGoogle(pointLatLng, GMarkerGoogleType.blue)
        'añadir tooltip
        If etiqueta <> "" Then
            Dim mode As MarkerTooltipMode = MarkerTooltipMode.OnMouseOver
            marker.ToolTip = New GMapBaloonToolTip(marker)
            marker.ToolTipMode = mode
            Dim ToolTipBackColor As New SolidBrush(Color.Red)
            marker.ToolTip.Fill = ToolTipBackColor
            marker.ToolTipText = etiqueta
        End If
        objOverlay.Markers.Clear()
        objOverlay.Markers.Add(marker)
        'mapa.Overlays.Add(markersOverlay)
    End Sub

    Private Sub _prCargarRuta(ByRef objMapa As GMapControl)
        Dim route As New List(Of PointLatLng)
        Dim dtRuta As DataTable = L_RutaGeneral("ldchof=32")
        For Each fila As DataRow In dtRuta.Rows
            route.Add(New PointLatLng(fila.Item("lblat"), fila.Item("lblongi")))
        Next

        Dim ruta As GMapRoute = New GMapRoute(route.ToArray, "My route")

        ruta.Stroke.Width = 2
        ruta.Stroke.Color = Color.SeaGreen

        'codigo de cargar el mapa
        Dim routesOverlay As GMapOverlay = New GMapOverlay("routes")
        routesOverlay.Routes.Add(ruta)
        objMapa.Overlays.Add(routesOverlay)

        'objMapa.Overlays.Add(objOverlay)

        'Dim routesOverlay As GMapOverlay = New GMapOverlay("routes")
        '_overlay.Routes.Add(ruta)
        'objMapa.Overlays.Add(_overlay)
    End Sub
    Private Sub _PCargarMapa(ByRef objMapa As GMapControl, ByRef objOverlay As GMapOverlay)

        objOverlay = New GMapOverlay("polygons")
        objMapa.Overlays.Add(objOverlay)

        objMapa.DragButton = MouseButtons.Left
        objMapa.CanDragMap = True
        objMapa.MapProvider = GMapProviders.GoogleMap
        'objMapa.Position = New PointLatLng(-17.380941, -66.15976)
        objMapa.Position = New PointLatLng(-17.782814, -63.182386)
        objMapa.MinZoom = 0
        objMapa.MaxZoom = 24
        objMapa.Zoom = 13
        objMapa.AutoScroll = True
        GMapProvider.Language = LanguageType.Spanish
    End Sub
    Private Sub _PDibujarZona(idZona As Integer, ByRef objOverlay As GMapOverlay, colorZona As String)
        'cargar zona en mapa
        Dim tPuntos As DataTable = L_ZonaDetallePuntos_General(-1, idZona).Tables(0)
        Dim i As Integer
        Dim lati, longi As Double
        Dim listPuntos As New List(Of PointLatLng)
        For i = 0 To tPuntos.Rows.Count - 1
            lati = tPuntos.Rows(i).Item(1)
            longi = tPuntos.Rows(i).Item(2)
            Dim plg As PointLatLng = New PointLatLng(lati, longi)
            listPuntos.Add(plg)
        Next

        'Dim color1 As String = JGr_Zonas1.CurrentRow.Cells(7).Value
        Dim colorFinal As Color = ColorTranslator.FromHtml(colorZona)

        Dim polygon As New GMapPolygon(listPuntos, "mypolygon")
        'agregar color
        polygon.Fill = New SolidBrush(Color.FromArgb(50, colorFinal))
        polygon.Stroke = New Pen(Color.Red, 1)
        'objOverlay.Polygons.Clear()
        objOverlay.Polygons.Add(polygon)
    End Sub

    Public Function GetResourceMapa(color As Integer) As Bitmap
        Select Case color
            Case 1
                Return New Bitmap(My.Resources.mapa_1)
            Case 2
                Return New Bitmap(My.Resources.mapa_2)
            Case 3
                Return New Bitmap(My.Resources.mapa_3)
            Case 4
                Return New Bitmap(My.Resources.mapa_4)
            Case 5
                Return New Bitmap(My.Resources.mapa_5)
            Case 6
                Return New Bitmap(My.Resources.mapa_6)
            Case 7
                Return New Bitmap(My.Resources.mapa_7)
            Case 8
                Return New Bitmap(My.Resources.mapa_8)
            Case 9
                Return New Bitmap(My.Resources.mapa_9)
            Case 10
                Return New Bitmap(My.Resources.mapa_10)
            Case 11
                Return New Bitmap(My.Resources.mapa_11)
            Case 12
                Return New Bitmap(My.Resources.mapa_12)
            Case 13
                Return New Bitmap(My.Resources.mapa_13)
            Case 14
                Return New Bitmap(My.Resources.mapa_14)
            Case 15
                Return New Bitmap(My.Resources.mapa_15)
            Case 16
                Return New Bitmap(My.Resources.mapa_16)
            Case 17
                Return New Bitmap(My.Resources.mapa_17)
            Case 18
                Return New Bitmap(My.Resources.mapa_18)
            Case 19
                Return New Bitmap(My.Resources.mapa_19)
            Case 20
                Return New Bitmap(My.Resources.mapa_20)
            Case 21
                Return New Bitmap(My.Resources.mapa_21)
            Case 22
                Return New Bitmap(My.Resources.mapa_22)
        End Select
    End Function
    Private Sub _PDibujarPunto(ByRef objOverlay As GMapOverlay, pointLatLng As PointLatLng, _color As Integer, _foto As String, Optional etiqueta As String = "")

        'añadir puntos
        ''Dim markersOverlay As New GMapOverlay("markers")
        Dim marker As GMarkerGoogle
        ''If _foto = String.Empty Then
        ''marker = New GMarkerGoogle(pointLatLng, _color) '_color _RutaImagenes + _foto

        '' Else
        Dim _imagen As New Bitmap(GetResourceMapa(_color + 1), 50, 50)
        marker = New GMarkerGoogle(pointLatLng, _imagen) '_color
        '' End If
        'añadir tooltip
        If etiqueta <> "" Then 'etiqueta <> ""
            Dim mode As MarkerTooltipMode = MarkerTooltipMode.OnMouseOver
            marker.ToolTip = New GMapBaloonToolTip(marker)
            marker.ToolTipMode = mode
            Dim ToolTipBackColor As New SolidBrush(Color.Red)
            marker.ToolTip.Fill = ToolTipBackColor
            marker.ToolTipText = etiqueta
        End If
        'objOverlay.Markers.Clear()
        objOverlay.Markers.Add(marker)
        'mapa.Overlays.Add(markersOverlay)
    End Sub

    Private Sub _PCargarPedidos()
        Dim dtPedidos, dtZonas As DataTable
        Dim i, j As Integer
        'DIBUJAR ZONAS
        dtZonas = L_ZonaCabecera_GeneralCompleto1(0).Tables(0)
        Dim colorZona As String
        Dim idRegZona As Integer
        For i = 0 To dtZonas.Rows.Count - 1
            idRegZona = dtZonas.Rows(i).Item("lanumi")
            colorZona = dtZonas.Rows(i).Item("lacolor")
            'dibujar zona
            _PDibujarZona(idRegZona, _overlay, colorZona)

            'DIBUJAR PEDIDOS
            Dim estado As String
            estado = "1"
            dtPedidos = L_PedidoCabecera_General(-1, " AND oaest=" + estado + " AND oazona= " + Str(idRegZona))
            For j = 0 To dtPedidos.Rows.Count - 1
                Dim idReg As Integer = dtPedidos.Rows(j).Item("oanumi")
                Dim latitud As Double = dtPedidos.Rows(j).Item("cclat")
                Dim longitud As Double = dtPedidos.Rows(j).Item("cclongi")
                Dim nombre As String = dtPedidos.Rows(j).Item("ccdesc")
                Dim obsPedido As String = dtPedidos.Rows(j).Item("oaobs")
                Dim fechaPedido As String = dtPedidos.Rows(j).Item("oafdoc")
                Dim horaPedido As String = dtPedidos.Rows(j).Item("oahora")

                'dibujar etiqueta del cliente en el mapa
                Dim plg As New PointLatLng(latitud, longitud)
                _PDibujarPunto(_overlay, plg, nombre + vbCrLf + _
                                        "Hora Pedido: " + fechaPedido + " - " + horaPedido, "")
            Next

        Next

    End Sub

    Private Sub _PCargarZonas()
        Dim dtZonas As DataTable
        Dim i As Integer
        'DIBUJAR ZONAS
        dtZonas = L_ZonaCabecera_GeneralCompleto1(0).Tables(0)
        Dim colorZona As String
        Dim idRegZona As Integer
        For i = 0 To dtZonas.Rows.Count - 1
            idRegZona = dtZonas.Rows(i).Item("lanumi")
            colorZona = dtZonas.Rows(i).Item("lacolor")
            'dibujar zona
            _PDibujarZona(idRegZona, _overlay, colorZona)
        Next

    End Sub

    Private Sub _prDibujarPuntosEnMapa()
        'limpio los puntos en el mapa
        _overlay.Markers.Clear()

        Dim dtRuta As DataTable
        For Each elem As DataRow In _listRepAct.ToArray
            dtRuta = L_RutaUltimoPunto("ldchof=" + elem.Item("cbnumi").ToString.Trim)
            If dtRuta.Rows.Count > 0 Then
                Dim color As Integer = elem.Item("color")
                Dim nombre As String = elem.Item("cbdesc")
                _PDibujarPunto(_overlay, New PointLatLng(dtRuta.Rows(0).Item("lblat"), dtRuta.Rows(0).Item("lblongi")), color, elem.Item("cbfot").ToString, nombre)
            End If
        Next


    End Sub
#End Region

    Private Sub P_MonitoreoPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _PIniciarTodo()
    End Sub


    Private Sub Btn_ZoomMas_Click(sender As Object, e As EventArgs) Handles Btn_ZoomMas.Click
        If GM_Mapa.Zoom <> GM_Mapa.MaxZoom Then
            GM_Mapa.Zoom = GM_Mapa.Zoom + 1
        End If
    End Sub

    Private Sub Btn_ZoomMenos_Click(sender As Object, e As EventArgs) Handles Btn_ZoomMenos.Click
        If GM_Mapa.Zoom <> GM_Mapa.MinZoom Then
            GM_Mapa.Zoom = GM_Mapa.Zoom - 1
        End If
    End Sub

    Private Sub TimerRuta_Tick(sender As Object, e As EventArgs) Handles TimerRuta.Tick
        '_prCargarRuta(GM_Mapa)
        _prDibujarPuntosEnMapa()
    End Sub

    Private Sub tbTracking_ValueChanged(sender As Object, e As EventArgs) Handles tbTracking.ValueChanged
        If tbTracking.Value = True Then
            TimerRuta.Start()
            grRepartidores.AllowEdit = InheritableBoolean.True
        Else
            TimerRuta.Stop()
            grRepartidores.AllowEdit = InheritableBoolean.False
            For Each fil As DataRow In CType(grRepartidores.DataSource, DataTable).Rows
                If (fil.Item("estado")) Then
                    fil.Item("estado") = False
                End If
            Next
        End If
    End Sub

    Private Sub grRepartidores_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles grRepartidores.CellEdited
        'If grRepartidores.Row >= 0 And e.Column.Key = "estado" Then
        '    If grRepartidores.GetValue("estado").ToString = "True" Then
        '        _listRepAct.Add(CType(grRepartidores.DataSource, DataTable).Rows(grRepartidores.Row))
        '        tbTracking.Focus()
        '    Else
        '        Dim i As Integer = _listRepAct.IndexOf(grRepartidores.GetValue("cbnumi"))
        '        _listRepAct.RemoveAt(i)
        '        tbTracking.Focus()
        '    End If
        'End If
    End Sub

    Private Sub grRepartidores_CellValueChanged(sender As Object, e As ColumnActionEventArgs) Handles grRepartidores.CellValueChanged
        If grRepartidores.Row >= 0 And e.Column.Key = "estado" Then
            If grRepartidores.GetValue("estado").ToString = "True" Then
                _listRepAct.Add(CType(grRepartidores.DataSource, DataTable).Rows(grRepartidores.Row))
                tbTracking.Focus()
            Else
                Dim i As Integer = _listRepAct.IndexOf(CType(grRepartidores.DataSource, DataTable).Rows(grRepartidores.Row))
                _listRepAct.RemoveAt(i)
                tbTracking.Focus()
            End If

        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles J_Cb_Ciudad.SelectedIndexChanged
        Dim ciudad As String = J_Cb_Ciudad.Text
        Select Case ciudad
            Case "COCHABAMBA"
                GM_Mapa.Position = New PointLatLng(-17.380941, -66.15976)
            Case "LA PAZ"
                GM_Mapa.Position = New PointLatLng(-16.499225, -68.122866)
            Case "SANTA CRUZ"
                GM_Mapa.Position = New PointLatLng(-17.782814, -63.182386)
        End Select
    End Sub

    Private Sub grRepartidores_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grRepartidores.EditingCell
        If (tbTracking.Value) Then
            If (e.Column.Key.Equals("estado")) Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub MBtSalir_Click(sender As Object, e As EventArgs) Handles MBtSalir.Click
        Me.Close()
        _modulo.Select()
        _tab.Close()
    End Sub

End Class