Imports Janus.Windows.GridEX
Imports Logica.AccesoLogica
Imports GMap.NET.MapProviders
Imports GMap.NET
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.WindowsForms.ToolTips
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports System.Drawing.Printing
Imports Entidades

Public Class F0_PedidosAsignacion

#Region "Atributos"
    Dim _overlay1 As GMapOverlay
    Dim _overlay2 As GMapOverlay
    Dim _overlay3 As GMapOverlay
    Dim _soloRepartidor As Integer = 1
    Dim _colCkeck = 23 '21 '19

    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

#End Region

#Region "Metodos Privados"
    Private Sub _PIniciarTodo()

        If gb_mostrarMapa = False Then
            GM_Mapa1.Visible = False
            GM_Mapa2.Visible = False
            GM_Mapa3.Visible = False

            PanelEx24.Visible = False
            PanelEx25.Visible = False
            PanelEx26.Visible = False
        End If


        Me.Text = "A S I G N A C I O N    D E    P E D I D O S"
        Me.WindowState = FormWindowState.Maximized
        SuperTabControl1.SelectedTabIndex = 1
        SuperTabItem1.Visible = False

        'cargar mapas
        _PCargarMapa(GM_Mapa1, _overlay1)
        _PCargarMapa(GM_Mapa2, _overlay2)
        _PCargarMapa(GM_Mapa3, _overlay3)

        '_PCargarGridRegistrosPedidos()

        'cargar zonas
        If _soloRepartidor = 1 Then
            _PCargarGridZonasSoloRepartidores(JGr_Zonas1)
            _PCargarGridZonasSoloRepartidores(JGr_Zonas2)
            _PCargarGridZonasSoloRepartidores(JGr_Zonas3)

        Else
            _PCargarGridZonas(JGr_Zonas1)
            _PCargarGridZonas(JGr_Zonas2)
            _PCargarGridZonas(JGr_Zonas3)
        End If

        'inhabilitar campos
        Tb_PedidoObs1.ReadOnly = True
        Tb_PedidoObs2.ReadOnly = True
        Tb_PedidoObs3.ReadOnly = True

        'poner maximo de caracteres a los campos
        Tb_PedidoObsAdicional1.MaxLength = 60
        Tb_PedidoObsAdicional2.MaxLength = 60
        Tb_PedidoObsAdicional3.MaxLength = 60

        _pCambiarFuente()
        _PAsignarPermisos()

        'OCULTAR EL TAB DE ENTREGADOS
        'SuperTabItem4.Visible = False
    End Sub

    Private Sub _PAsignarPermisos()
        'Dim idRolUsu As String = L_Usuario_General(-1, " AND yduser='" + gs_user + "' ").Tables(0).Rows(0).Item("ybnumi")
        'Dim dtRolUsu As DataTable = L_RolDetalle_General2(-1, idRolUsu, "ycyanumi=9")
        'Dim show As Boolean = dtRolUsu.Rows(0).Item("ycshow")
        'Dim add As Boolean = dtRolUsu.Rows(0).Item("ycadd")
        'Dim modif As Boolean = dtRolUsu.Rows(0).Item("ycmod")
        'Dim del As Boolean = dtRolUsu.Rows(0).Item("ycdel")

        ''If add = False Then
        ''    'BBtn_Nuevo.Visible = False
        ''    btNuevo.Visible = False
        ''End If
        ''If modif = False Then
        ''    'BBtn_Modificar.Visible = False
        ''    btModificar.Visible = False
        ''End If
        'If del = False Then
        '    btBorrarPedInvalidos.Visible = False
        '    ANULARPEDIDOToolStripMenuItem.Visible = False
        '    ANULARPEDIDOToolStripMenuItem1.Visible = False
        'End If

    End Sub

    Private Sub _pCambiarFuente()
        Dim fuente As New Font("Tahoma", gi_fuenteTamano, FontStyle.Regular)
        Dim xCtrl As Control
        For Each xCtrl In PanelEx10.Controls
            Try
                xCtrl.Font = fuente
            Catch ex As Exception
            End Try
        Next
        'For Each xCtrl In PanelEx12.Controls
        '    Try
        '        xCtrl.Font = fuente
        '    Catch ex As Exception
        '    End Try
        'Next
        For Each xCtrl In PanelEx21.Controls
            Try
                xCtrl.Font = fuente
            Catch ex As Exception
            End Try
        Next
        For Each xCtrl In GroupPanel6.Controls
            Try
                xCtrl.Font = fuente
            Catch ex As Exception
            End Try
        Next
        For Each xCtrl In GroupPanel4.Controls
            Try
                xCtrl.Font = fuente
            Catch ex As Exception
            End Try
        Next
        For Each xCtrl In GroupPanel3.Controls
            Try
                xCtrl.Font = fuente
            Catch ex As Exception
            End Try
        Next
        GroupPanel1.Font = fuente
        GroupPanel2.Font = fuente
        GroupPanel5.Font = fuente
        GroupPanel4.Font = fuente
        GroupPanel3.Font = fuente
        GroupPanel6.Font = fuente


        JGr_Registros1.Font = fuente
        JGr_Registros2.Font = fuente
        JGr_Registros3.Font = fuente


        JGr_Zonas1.Font = fuente
        JGr_Zonas2.Font = fuente
        JGr_Zonas3.Font = fuente

    End Sub

    Private Sub _PCargarGridRegistrosPedidos(ByRef objGrid As Janus.Windows.GridEX.GridEX, estado As String, Optional ByVal codZona As String = "", Optional ByVal codRep As String = "-1")
        Dim dtReg As DataTable
        If codZona = "" Then
            If codRep = "-1" Then
                dtReg = L_PedidoCabecera_General(-1, " AND (oaest=" + estado + " ) AND oaap=1")
            Else
                If estado = "1" Then
                    dtReg = L_PedidoCabecera_GeneralSoloRepartidor(-1, " AND (oaest=" + estado + " ) AND oaap=1" + " AND tl0012.lccbnumi=" + codRep)
                Else
                    dtReg = L_PedidoCabecera_GeneralSoloRepartidor(-1, " AND (oaest=" + estado + " ) AND oaap=1" + " AND tl0012.lccbnumi=" + codRep)
                End If
            End If
        Else
            If codRep = "-1" Then
                dtReg = L_PedidoCabecera_General(-1, " AND (oaest=" + estado + ") AND oazona= " + codZona + " AND oaap=1")
            Else
                dtReg = L_PedidoCabecera_General(-1, " AND (oaest=" + estado + " ) AND oazona= " + codZona + " AND oarepa=" + codRep + " AND oaap=1")
            End If

        End If


        'añadir columna de check box
        dtReg.Columns.Add("Check", Type.GetType("System.Boolean"))
        Dim i As Integer
        For i = 0 To dtReg.Rows.Count - 1
            dtReg.Rows(i).Item("Check") = False
        Next


        objGrid.BoundMode = BoundMode.Bound
        objGrid.DataSource = dtReg
        objGrid.RetrieveStructure()

        'dar formato a las columnas
        With objGrid.RootTable.Columns(0)
            .Caption = "Cod."
            .Key = "CodPedido"
            .Width = 60
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With
        With objGrid.RootTable.Columns(1)
            .Caption = "Fecha"
            .Width = 90
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns(2)
            .Key = "hora"
            .Caption = "Hora"
            .Width = 55
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns(3)
            .Visible = True
            .Key = "codCliente"
            .Caption = "Cod. Cliente"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        End With

        With objGrid.RootTable.Columns(4)
            .Caption = "Nombre"
            .Width = 250
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
        End With

        With objGrid.RootTable.Columns(5)
            .Caption = "Direccion"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
        End With

        With objGrid.RootTable.Columns(6)
            .Caption = "Telefono"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns(7)
            .Visible = False
        End With

        With objGrid.RootTable.Columns(8)
            .Key = "zona"
            .Visible = False
        End With

        With objGrid.RootTable.Columns(9)
            .Caption = "Zona"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
        End With

        With objGrid.RootTable.Columns(10)
            .Visible = False
            .Key = "ObsPedido"
        End With

        With objGrid.RootTable.Columns(11)
            .Visible = False
            .Key = "ObsPedido2"
        End With

        With objGrid.RootTable.Columns(12) 'estado
            .Visible = False
        End With

        'latitud y longitud
        With objGrid.RootTable.Columns(13)
            .Key = "Latitud"
            .Visible = False
        End With

        With objGrid.RootTable.Columns(14)
            .Key = "Longitud"
            .Visible = False
        End With

        With objGrid.RootTable.Columns("oaap")
            .Visible = False
        End With

        With objGrid.RootTable.Columns("reclamo")
            .Visible = False
        End With

        With objGrid.RootTable.Columns("oapg")
            .Visible = False
        End With

        With objGrid.RootTable.Columns("ccultvent")
            .Caption = "Ult. Venta"
            .Width = 90
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns("tipoRecCliente")
            .Visible = False
        End With

        With objGrid.RootTable.Columns("tipoRecRepartidor")
            .Visible = False
        End With

        With objGrid.RootTable.Columns("ccnumi")
            .Visible = False
        End With

        With objGrid.RootTable.Columns("cceven")
            .Visible = False
        End With

        'objGrid.RootTable.Columns.Add("Check")
        With objGrid.RootTable.Columns(_colCkeck)
            .Visible = True
            .key = "check"
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .EditType = EditType.CheckBox
            .ColumnType = ColumnType.CheckBox
            .CheckBoxFalseValue = False
            .CheckBoxTrueValue = True
        End With

        'Habilitar Filtradores
        With objGrid
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            .VisualStyle = VisualStyle.Office2007
        End With

        'poner color a la fila de acuerdo a la condicion 
        Dim fc, fc1, fc2, fc3, fc66, fcRecClient, fcRecRepart As GridEXFormatCondition
        fc = New GridEXFormatCondition(objGrid.RootTable.Columns("reclamo"), ConditionOperator.Equal, 1)
        'fc.FormatStyle.BackColor = Color.LightYellow
        fc.FormatStyle.ForeColor = Color.Red

        fc1 = New GridEXFormatCondition(objGrid.RootTable.Columns("oapg"), ConditionOperator.Equal, 1)
        fc1.FormatStyle.BackColor = Color.LightGreen

        'pedido generado desde el celular
        fc66 = New GridEXFormatCondition(objGrid.RootTable.Columns("oapg"), ConditionOperator.Equal, 11)
        fc66.FormatStyle.BackColor = Color.LightCyan

        'formato para decir si es un pedido esta entregado y con nota
        fc2 = New GridEXFormatCondition(objGrid.RootTable.Columns("oaest"), ConditionOperator.Equal, 4)
        fc2.FormatStyle.BackColor = Color.LightGray

        'formato para decir si es un pedido fue regerado a partir de otro pedido
        fc3 = New GridEXFormatCondition(objGrid.RootTable.Columns("oapg"), ConditionOperator.Equal, 2)
        fc3.FormatStyle.BackColor = Color.Yellow

        'formato para decir si es un pedido tiene reclamo de un repartidor
        fcRecRepart = New GridEXFormatCondition(objGrid.RootTable.Columns("tipoRecRepartidor"), ConditionOperator.Equal, 1)
        fcRecRepart.FormatStyle.BackColor = Color.LightYellow

        'formato para decir si es un pedido tiene reclamo de un cliente
        fcRecClient = New GridEXFormatCondition(objGrid.RootTable.Columns("tipoRecCliente"), ConditionOperator.Equal, 1)
        fcRecClient.FormatStyle.BackColor = Color.LightGreen

        objGrid.RootTable.FormatConditions.Add(fc)
        objGrid.RootTable.FormatConditions.Add(fc1)
        objGrid.RootTable.FormatConditions.Add(fc2)
        objGrid.RootTable.FormatConditions.Add(fc3)
        objGrid.RootTable.FormatConditions.Add(fc66)

        objGrid.RootTable.FormatConditions.Add(fcRecRepart)
        objGrid.RootTable.FormatConditions.Add(fcRecClient)

        If estado = "3" Then
            objGrid.RootTable.Columns("Check").Visible = False 'oculto el check
        Else
            objGrid.RootTable.Columns("Check").Visible = True 'oculto el check
        End If
    End Sub

    Private Sub _PCargarGridRegistrosPedidosInvalidos(ByRef objGrid As Janus.Windows.GridEX.GridEX, estado As String, Optional ByVal codZona As String = "", Optional ByVal codRep As String = "-1")
        Dim dtReg As DataTable
        If codZona = "" Then
            If codRep = "-1" Then
                dtReg = L_PedidoCabecera_General(-1, " AND (oaest=" + estado + " ) AND oaap=1 and ccultvent>=oafdoc ")
            Else
                dtReg = L_PedidoCabecera_GeneralSoloRepartidor(-1, " AND (oaest=" + estado + " ) AND oaap=1" + " AND tl0012.lccbnumi=" + codRep + " and ccultvent>=oafdoc")
            End If
        Else
            If codRep = "-1" Then
                dtReg = L_PedidoCabecera_General(-1, " AND (oaest=" + estado + ") AND oazona= " + codZona + " AND oaap=1 and ccultvent>=oafdoc")
            Else
                dtReg = L_PedidoCabecera_General(-1, " AND (oaest=" + estado + " ) AND oazona= " + codZona + " AND oarepa=" + codRep + " AND oaap=1 and ccultvent>=oafdoc")
            End If

        End If


        'añadir columna de check box
        dtReg.Columns.Add("Check", Type.GetType("System.Boolean"))
        Dim i As Integer
        For i = 0 To dtReg.Rows.Count - 1
            dtReg.Rows(i).Item("Check") = False
        Next


        objGrid.BoundMode = BoundMode.Bound
        objGrid.DataSource = dtReg
        objGrid.RetrieveStructure()

        'dar formato a las columnas
        With objGrid.RootTable.Columns(0)
            .Caption = "Cod."
            .Key = "CodPedido"
            .Width = 60
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With
        With objGrid.RootTable.Columns(1)
            .Caption = "Fecha"
            .Width = 90
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns(2)
            .Caption = "Hora"
            .Width = 55
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns(3)
            .Visible = False
            .Caption = "Cod. Cliente"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns(4)
            .Caption = "Nombre"
            .Width = 250
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
        End With

        With objGrid.RootTable.Columns(5)
            .Caption = "Direccion"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
        End With

        With objGrid.RootTable.Columns(6)
            .Caption = "Telefono"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns(7)
            .Visible = False
        End With

        With objGrid.RootTable.Columns(8)
            .Visible = False
        End With

        With objGrid.RootTable.Columns(9)
            .Caption = "Zona"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
        End With

        With objGrid.RootTable.Columns(10)
            .Visible = False
            .Key = "ObsPedido"
        End With

        With objGrid.RootTable.Columns(11)
            .Visible = False
            .Key = "ObsPedido2"
        End With

        With objGrid.RootTable.Columns(12) 'estado
            .Visible = False
        End With

        'latitud y longitud
        With objGrid.RootTable.Columns(13)
            .Key = "Latitud"
            .Visible = False
        End With

        With objGrid.RootTable.Columns(14)
            .Key = "Longitud"
            .Visible = False
        End With

        With objGrid.RootTable.Columns("oaap")
            .Visible = False
        End With

        With objGrid.RootTable.Columns("reclamo")
            .Visible = False
        End With

        With objGrid.RootTable.Columns("oapg")
            .Visible = False
        End With

        With objGrid.RootTable.Columns("ccultvent")
            .Caption = "Ult. Pedido"
            .Width = 90
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns("ccnumi")
            .Visible = True
        End With

        With objGrid.RootTable.Columns("cceven")
            .Visible = True
        End With

        'objGrid.RootTable.Columns.Add("Check")
        With objGrid.RootTable.Columns(_colCkeck)
            .Visible = True
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .EditType = EditType.CheckBox
            .ColumnType = ColumnType.CheckBox
            .CheckBoxFalseValue = False
            .CheckBoxTrueValue = True
        End With

        'Habilitar Filtradores
        With objGrid
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            .VisualStyle = VisualStyle.Office2007
        End With

        'poner color a la fila de acuerdo a la condicion 
        Dim fc, fc1, fc2 As GridEXFormatCondition
        fc = New GridEXFormatCondition(objGrid.RootTable.Columns("reclamo"), ConditionOperator.Equal, 1)
        'fc.FormatStyle.BackColor = Color.LightYellow
        fc.FormatStyle.ForeColor = Color.Red

        fc1 = New GridEXFormatCondition(objGrid.RootTable.Columns("oapg"), ConditionOperator.Equal, 1)
        fc1.FormatStyle.BackColor = Color.LightGreen

        fc2 = New GridEXFormatCondition(objGrid.RootTable.Columns("oapg"), ConditionOperator.Equal, 11)
        fc2.FormatStyle.BackColor = Color.LightCyan
        'fc.FormatStyle.ForeColor = Color.Red

        objGrid.RootTable.FormatConditions.Add(fc)
        objGrid.RootTable.FormatConditions.Add(fc1)
        objGrid.RootTable.FormatConditions.Add(fc2)

        If estado = "2" Then
            objGrid.RootTable.Columns("Check").Visible = False 'oculto el check
        End If
    End Sub

    Private Sub _PCargarGridDetalle(ByRef objGrid As Janus.Windows.GridEX.GridEX, idCabecera As Integer)
        Dim dtProd As New DataTable
        dtProd = L_PedidoDetalle_General(-1, idCabecera)

        objGrid.BoundMode = BoundMode.Bound
        objGrid.DataSource = dtProd
        objGrid.RetrieveStructure()

        'dar formato a las columnas
        With objGrid.RootTable.Columns(0)
            .Visible = False
        End With

        With objGrid.RootTable.Columns(1)
            .Caption = "Cod. Producto"
            .Key = "CodProd"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns(2)
            .Caption = "Producto"
            .Key = "Producto"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With

        With objGrid.RootTable.Columns(3)
            .Caption = "Cantidad"
            .Key = "Cantidad"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .FormatString = "0.00"
        End With
        With objGrid.RootTable.Columns(4)
            .Caption = "Precio"
            .Key = "Precio"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .FormatString = "0.00"
        End With
        With objGrid.RootTable.Columns(5)
            .Caption = "Monto Bs."
            .Key = "Monto"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .FormatString = "0.00"
        End With

        'Habilitar Filtradores
        With objGrid
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue

            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
        End With

    End Sub

    Private Sub _PCargarGridZonas(ByRef objGrid As Janus.Windows.GridEX.GridEX)
        Dim dt As New DataTable
        dt = L_ZonaCabecera_GeneralCompleto(0).Tables(0)

        objGrid.BoundMode = BoundMode.Bound
        objGrid.DataSource = dt
        objGrid.RetrieveStructure()

        'dar formato a las columnas
        With objGrid.RootTable.Columns(0)
            .Caption = "Cod."
            .Key = "CodRepartidor"
            .Width = 40
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.BackColor = Color.AliceBlue
        End With

        With objGrid.RootTable.Columns(1)
            .Caption = "Repartidor"
            .Key = "Repartidor"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.BackColor = Color.AliceBlue
        End With

        With objGrid.RootTable.Columns(2)
            .Caption = "Codigo"
            .Key = "Codigo"
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns(3)
            .Key = "CodCiudad"
            .Visible = False
        End With
        With objGrid.RootTable.Columns(4)
            .Caption = "Ciudad"
            .Key = "Ciudad"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
        End With

        With objGrid.RootTable.Columns(5)
            .Key = "CodProvincia"
            .Visible = False
        End With
        With objGrid.RootTable.Columns(6)
            .Caption = "Provincia"
            .Key = "Provincia"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
        End With

        With objGrid.RootTable.Columns(7)
            .Key = "CodZona"
            .Visible = False
        End With
        With objGrid.RootTable.Columns(8)
            .Caption = "Zona"
            .Key = "Zona"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
        End With
        With objGrid.RootTable.Columns(9)
            .Visible = False
            .Key = "Color"
        End With


        'Habilitar Filtradores
        With objGrid
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
        End With

    End Sub

    Private Sub _PCargarGridZonasSoloRepartidores(ByRef objGrid As Janus.Windows.GridEX.GridEX)
        Dim dt As New DataTable
        dt = L_Empleado_GeneralSimple(-1, "and cbcat=1 and cbest=1 ").Tables(0)

        objGrid.BoundMode = BoundMode.Bound
        objGrid.DataSource = dt
        objGrid.RetrieveStructure()

        'dar formato a las columnas
        With objGrid.RootTable.Columns("cbnumi")
            .Caption = "Cod."
            .Key = "CodRepartidor"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.BackColor = Color.AliceBlue
        End With

        With objGrid.RootTable.Columns("cbdesc")
            .Caption = "Repartidor"
            .Key = "Repartidor"
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.BackColor = Color.AliceBlue
        End With


        'Habilitar Filtradores
        With objGrid
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
        End With

    End Sub

    Private Sub _PGrabarAsignaciones()
        Dim i, cant, codPedido As Integer
        Dim estado As Boolean
        cant = 0
        For i = 0 To JGr_Registros1.RowCount - 1
            JGr_Registros1.Row = i
            estado = JGr_Registros1.GetValue("Check")
            If estado = True Then
                codPedido = JGr_Registros1.GetValue("CodPedido")
                L_PedidoEstados_Grabar(codPedido, "2", Date.Now.Date.ToString("yyyy/MM/dd"), Now.Hour.ToString + ":" + Now.Minute.ToString, gs_user)
                L_PedidoCabacera_ModificarEstado(codPedido, "2")
                L_PedidoCabacera_ModificarCodRep(codPedido, Tb_CodRep1.Text)
                cant = cant + 1


                Dim objListDetalle As New List(Of RequestDetail)

                Dim codProd, cantidad, precio, subTotal As String
                For Each fil As GridEXRow In JGr_Detalles1.GetRows
                    codProd = fil.Cells("CodProd").Value.ToString
                    cantidad = fil.Cells("Cantidad").Value.ToString
                    precio = fil.Cells("Precio").Value.ToString
                    subTotal = fil.Cells("Monto").Value.ToString

                    objListDetalle.Add(New RequestDetail(codPedido, codProd, cantidad, precio, subTotal, L_ClaseGetProducto(codProd)))
                Next

                If (gi_notiPed = 1) Then
                    '-----------------'MANDAR LA NOTIFICACION DEL PEDIDO '-----------------------------------------------
                    Dim objResult As New Result
                    Dim dtRepartidor As DataTable = L_fnObtenerRepartidor(JGr_Registros1.GetValue("zona").ToString)
                    Dim codRep As String = "-1"
                    If dtRepartidor.Rows.Count > 0 Then
                        codRep = dtRepartidor.Rows(0).Item("lccbnumi").ToString
                    End If
                    'Dim s As String = JGr_Registros1.GetValue("codCliente").ToString
                    Dim objPedido As New RequestHeader(codPedido, Date.Now.Date.ToString("yyyy-MM-dd"),
                                                       JGr_Registros1.GetValue("hora").ToString,
                                                       JGr_Registros1.GetValue("ccnumi").ToString,
                                                       JGr_Registros1.GetValue("zona"),
                                                       codRep, JGr_Registros1.GetValue("ObsPedido").ToString, "",
                                                        "1", "1", "0",
                                                       Date.Now.Date.ToString("yyyy-MM-dd"),
                                                       Now.Hour.ToString + ":" + Now.Minute.ToString, gs_user,
                                                       objListDetalle, L_ClaseGetCliente(L_fnObtenerTabla("oaccli", "TO001", "oanumi=" + codPedido.ToString).Rows(0).Item("oaccli").ToString))
                    Dim dtLlave As DataTable = L_TC0022General(codRep)
                    If dtLlave.Rows.Count > 0 Then
                        Dim llaveRep As String = dtLlave(0).Item("ckidfsm").ToString
                        objResult.fcmToken = llaveRep
                        objResult.mRequestHeader = objPedido
                        Dim respuesta As Boolean = JsonApiClient._prMandarNotificacion(objResult)
                        If respuesta = False Then
                            'ToastNotification.Show(Me, "El Pedido no se pudo enviar a la app del repartidor".ToUpper, My.Resources.WARNING, 10000, eToastGlowColor.Red, eToastPosition.TopCenter)
                        End If
                    Else
                        'ToastNotification.Show(Me, "no se pudo enviar el pedido al repartidor!!! , ".ToUpper + "el repartidor con codigo: ".ToUpper + codRep + " no tiene grabado su llave en la tabla TC0022", My.Resources.WARNING, 10000, eToastGlowColor.Red, eToastPosition.TopCenter)
                    End If
                End If


            End If
        Next

        ToastNotification.Show(Me, Str(cant) + " Pedidos Asignados Exitosamente", My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)

        'actualizar registros PENDIENTE:TIENE QUE CARGAR LOS REGISTROS DE LA ZONA SELECCIONADA
        If _soloRepartidor = 0 Then
            Dim codZonaSelected As Integer = JGr_Zonas1.CurrentRow.Cells("Codigo").Value
            _PCargarGridRegistrosPedidos(JGr_Registros1, "1", codZonaSelected)
            P_prPonerCodicion()
            'actualizo  la tabla de registros del asignacion de pedidos y confirmacion de entregas
            _PCargarGridRegistrosPedidos(JGr_Registros2, "2", codZonaSelected, Tb_CodRep2.Text)
        Else
            _PCargarGridRegistrosPedidos(JGr_Registros1, "1", , Tb_CodRep1.Text)
            P_prPonerCodicion()
            'actualizo  la tabla de registros del asignacion de pedidos y confirmacion de entregas
            _PCargarGridRegistrosPedidos(JGr_Registros2, "2", , Tb_CodRep2.Text)
        End If

    End Sub

    Private Sub _PGrabarConfirmacionesEntregas()
        Dim i, cant, codPedido As Integer
        Dim estado As Boolean
        cant = 0
        For i = 0 To JGr_Registros2.RowCount - 1
            JGr_Registros2.Row = i
            estado = JGr_Registros2.GetValue("Check")
            If estado = True Then
                codPedido = JGr_Registros2.GetValue("CodPedido")
                L_PedidoEstados_Grabar(codPedido, "3", Date.Now.Date.ToString("yyyy/MM/dd"), Now.Hour.ToString + ":" + Now.Minute.ToString, gs_user)
                L_PedidoCabacera_ModificarEstado(codPedido, "3")
                L_PedidoCabacera_ModificarEntrega(codPedido, "1")
                cant = cant + 1
            End If
        Next

        ToastNotification.Show(Me, Str(cant) + " Pedidos Entregados Exitosamente", My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)

        If _soloRepartidor = 0 Then
            'actualizar registros PENDIENTE:TIENE QUE CARGAR LOS REGISTROS DE LA ZONA SELECCIONADA
            Dim codZonaSelected As Integer = JGr_Zonas2.CurrentRow.Cells("Codigo").Value
            _PCargarGridRegistrosPedidos(JGr_Registros2, "2", codZonaSelected)
        Else
            'actualizar registros PENDIENTE:TIENE QUE CARGAR LOS REGISTROS DE LA ZONA SELECCIONADA
            ''Dim codZonaSelected As Integer = JGr_Zonas2.CurrentRow.Cells("Codigo").Value
            _PCargarGridRegistrosPedidos(JGr_Registros2, "2", , Tb_CodRep2.Text)
        End If
    End Sub

    Private Sub _PCargarMapa(ByRef objMapa As GMapControl, ByRef objOverlay As GMapOverlay)

        objOverlay = New GMapOverlay("polygons")
        objMapa.Overlays.Add(objOverlay)

        objMapa.DragButton = MouseButtons.Left
        objMapa.CanDragMap = True
        objMapa.MapProvider = GMapProviders.GoogleMap
        objMapa.Position = New PointLatLng(-17.380941, -66.15976)
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

        If listPuntos.Count > 0 Then
            'Dim color1 As String = JGr_Zonas1.CurrentRow.Cells(7).Value
            Dim colorFinal As Color = ColorTranslator.FromHtml(colorZona)

            Dim polygon As New GMapPolygon(listPuntos, "mypolygon")
            'agregar color
            polygon.Fill = New SolidBrush(Color.FromArgb(50, colorFinal))
            polygon.Stroke = New Pen(Color.Red, 1)
            objOverlay.Polygons.Clear()
            objOverlay.Polygons.Add(polygon)
        Else
            objOverlay.Polygons.Clear()
        End If

    End Sub

    Private Sub _PDibujarPunto(ByRef objOverlay As GMapOverlay, pointLatLng As PointLatLng, Optional etiqueta As String = "")

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

    Private Sub _PCargarRegistroPedidos1()
        If JGr_Zonas1.Row >= 0 Then
            Tb_CodRep1.Text = JGr_Zonas1.CurrentRow.Cells(0).Value
            Tb_Repartidor1.Text = JGr_Zonas1.CurrentRow.Cells(1).Value
            Dim idRegZona As Integer
            Dim color1 As String
            If _soloRepartidor = 0 Then
                idRegZona = JGr_Zonas1.CurrentRow.Cells(2).Value
                Tb_Ciudad1.Text = JGr_Zonas1.CurrentRow.Cells(4).Value
                Tb_Provincia1.Text = JGr_Zonas1.CurrentRow.Cells(6).Value
                Tb_Zona1.Text = JGr_Zonas1.CurrentRow.Cells(8).Value
                color1 = JGr_Zonas1.CurrentRow.Cells(7).Value
            End If

            If (GM_Mapa1.Visible) Then
                If _soloRepartidor = 0 Then
                    'dibujar zona
                    _PDibujarZona(idRegZona, _overlay1, color1)

                    'cargar pedidos asignados a esa zona
                    _overlay1.Markers.Clear()

                    'posicionar en la zona
                    Dim dtPuntos = L_ZonaDetallePuntos_General(-1, idRegZona).Tables(0)
                    If dtPuntos.Rows.Count > 0 Then
                        Dim latiZona, longiZona As Double
                        latiZona = dtPuntos.Rows(0).Item(1)
                        longiZona = dtPuntos.Rows(0).Item(2)
                        GM_Mapa1.Position = New PointLatLng(latiZona, longiZona)
                    End If
                End If

            End If
            'el comentado de arriba
            If _soloRepartidor = 0 Then
                _PCargarGridRegistrosPedidos(JGr_Registros1, "1", Str(idRegZona))
                P_prPonerCodicion()
            Else
                _PCargarGridRegistrosPedidos(JGr_Registros1, "1", , Tb_CodRep1.Text)
                P_prPonerCodicion()
            End If

            JGr_Registros1.ContextMenuStrip = ConMenu_Opciones1
        End If
    End Sub

    Private Sub _PAnularPedidosInvalidos()
        If swMostrarPedInvalidos.Value Then
            Dim i, cant, codPedido As Integer
            cant = 0
            For i = 0 To JGr_Registros2.RowCount - 1
                JGr_Registros2.Row = i
                codPedido = JGr_Registros2.GetValue("CodPedido")
                Dim numi As String = ""
                Dim obs As String = "ANULACION DE PEDIDOS (FECHA ULTIMA VENTA >= FECHA VENTA)"

                L_PedidoReclamos_Grabar(numi, codPedido, "2", obs.ToUpper, "3", "1")
                L_PedidoCabacera_ModificarActivoPasivo(codPedido, "3")

                ''actualizar la grilla
                'Dim idRegZona As Integer
                'If _soloRepartidor = 0 Then
                '    idRegZona = JGr_Zonas2.CurrentRow.Cells(2).Value
                '    _PCargarGridRegistrosPedidos(JGr_Registros2, "2", Str(idRegZona), Tb_CodRep2.Text)
                'Else
                '    _PCargarGridRegistrosPedidos(JGr_Registros2, "2", , Tb_CodRep2.Text)
                'End If
                cant = cant + 1
            Next

            ToastNotification.Show(Me, Str(cant) + " Pedidos anulados Exitosamente".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            swMostrarPedInvalidos.Value = False

            If _soloRepartidor = 0 Then
                'actualizar registros PENDIENTE:TIENE QUE CARGAR LOS REGISTROS DE LA ZONA SELECCIONADA
                Dim codZonaSelected As Integer = JGr_Zonas2.CurrentRow.Cells("Codigo").Value
                _PCargarGridRegistrosPedidos(JGr_Registros2, "2", codZonaSelected)
            Else
                'actualizar registros PENDIENTE:TIENE QUE CARGAR LOS REGISTROS DE LA ZONA SELECCIONADA
                ''Dim codZonaSelected As Integer = JGr_Zonas2.CurrentRow.Cells("Codigo").Value
                _PCargarGridRegistrosPedidos(JGr_Registros2, "2", , Tb_CodRep2.Text)
            End If

        Else
            ToastNotification.Show(Me, "Debe mostrar primero los pedidos FECHA ULTIMA VENTA >= FECHA VENTA".ToUpper, My.Resources.WARNING, 5000, eToastGlowColor.Blue, eToastPosition.TopCenter)
        End If

    End Sub

#End Region

    Private Sub P_PedidosAsignacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _PIniciarTodo()
    End Sub

    Private Sub JGr_Registros_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_Registros1.EditingCell
        If e.Column.Index <> _colCkeck Then
            e.Cancel = True
        End If
    End Sub

    Private Sub JGr_Detalles_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_Detalles1.EditingCell
        e.Cancel = True
    End Sub

    Private Sub Btn_AsignarPedidos_Click(sender As Object, e As EventArgs) Handles Btn_AsignarPedidos.Click
        _PGrabarAsignaciones()
    End Sub

    Private Sub JGr_Zonas_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_Zonas1.EditingCell
        e.Cancel = True
    End Sub

    Private Sub AñadirObsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AñadirObsToolStripMenuItem.Click
        'COLOREAR FILA
        'Dim estiloFila As New GridEXFormatStyle()
        'estiloFila.BackColor = Color.LightGreen
        'JGr_Registros1.CurrentRow.RowStyle = estiloFila

        'cambio el estado del pedido seleccionado
        Dim codPedido As Integer = JGr_Registros2.GetValue("CodPedido")
        Dim codZonaSelected As Integer
        L_PedidoEstados_Grabar(codPedido, "1", Date.Now.Date.ToString("yyyy/MM/dd"), Now.Hour.ToString + ":" + Now.Minute.ToString, gs_user)
        L_PedidoCabacera_ModificarEstado(codPedido, "1")

        If _soloRepartidor = 0 Then
            codZonaSelected = JGr_Zonas2.GetValue("Codigo")
            'actualizo  la tabla de registros del asignacion de pedidos y confirmacion de entregas
            _PCargarGridRegistrosPedidos(JGr_Registros1, "1", "", Tb_CodRep1.Text)
            P_prPonerCodicion()
            _PCargarGridRegistrosPedidos(JGr_Registros2, "2", codZonaSelected, Tb_CodRep2.Text)
        Else
            'actualizo  la tabla de registros del asignacion de pedidos y confirmacion de entregas
            _PCargarGridRegistrosPedidos(JGr_Registros1, "1", "", Tb_CodRep1.Text)
            P_prPonerCodicion()
            _PCargarGridRegistrosPedidos(JGr_Registros2, "2", , Tb_CodRep2.Text)
        End If
    End Sub

    Private Sub P_prPonerCodicion()
        'poner color a la fila de acuerdo a la condicion 
        Dim fc As GridEXFormatCondition
        fc = New GridEXFormatCondition(JGr_Registros1.RootTable.Columns("cceven"), ConditionOperator.Equal, 1)
        fc.FormatStyle.BackColor = Color.Blue
        fc.FormatStyle.ForeColor = Color.White

        JGr_Registros1.RootTable.FormatConditions.Add(fc)
    End Sub

    Private Sub RETORNARPEDIDOACONFIRMACIONDEENTREGAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RETORNARPEDIDOACONFIRMACIONDEENTREGAToolStripMenuItem.Click
        'cambio el estado del pedido seleccionado
        Dim codPedido As Integer = JGr_Registros3.GetValue("CodPedido")
        Dim codZonaSelected2 As Integer
        Dim codZonaSelected3 As Integer

        L_PedidoEstados_Grabar(codPedido, "2", Date.Now.Date.ToString("yyyy/MM/dd"), Now.Hour.ToString + ":" + Now.Minute.ToString, gs_user)
        L_PedidoCabacera_ModificarEstado(codPedido, "2")
        L_PedidoCabacera_ModificarEntrega(codPedido, "0")

        If _soloRepartidor = 0 Then
            codZonaSelected2 = JGr_Zonas2.GetValue("Codigo")
            codZonaSelected3 = JGr_Zonas3.GetValue("Codigo")
            'actualizo  la tabla de registros del asignacion de pedidos y confirmacion de entregas
            _PCargarGridRegistrosPedidos(JGr_Registros2, "2", codZonaSelected2, Tb_CodRep2.Text)
            _PCargarGridRegistrosPedidos(JGr_Registros3, "3", codZonaSelected3, Tb_CodRep3.Text)
        Else
            'actualizo  la tabla de registros del asignacion de pedidos y confirmacion de entregas
            _PCargarGridRegistrosPedidos(JGr_Registros2, "2", , Tb_CodRep2.Text)
            _PCargarGridRegistrosPedidos(JGr_Registros3, "3", , Tb_CodRep3.Text)
        End If
    End Sub

    Private Sub JGr_Zonas_SelectionChanged(sender As Object, e As EventArgs) Handles JGr_Zonas1.SelectionChanged
        If JGr_Zonas1.Row >= 0 Then
            Tb_CodRep1.Text = JGr_Zonas1.CurrentRow.Cells(0).Value
            Tb_Repartidor1.Text = JGr_Zonas1.CurrentRow.Cells(1).Value
            Dim idRegZona As Integer
            Dim color1 As String
            If _soloRepartidor = 0 Then
                idRegZona = JGr_Zonas1.CurrentRow.Cells(2).Value
                Tb_Ciudad1.Text = JGr_Zonas1.CurrentRow.Cells(4).Value
                Tb_Provincia1.Text = JGr_Zonas1.CurrentRow.Cells(6).Value
                Tb_Zona1.Text = JGr_Zonas1.CurrentRow.Cells(8).Value
                color1 = JGr_Zonas1.CurrentRow.Cells(7).Value
            End If

            If (GM_Mapa1.Visible) Then
                If _soloRepartidor = 0 Then
                    'dibujar zona
                    _PDibujarZona(idRegZona, _overlay1, color1)

                    'cargar pedidos asignados a esa zona
                    _overlay1.Markers.Clear()

                    'posicionar en la zona
                    Dim dtPuntos = L_ZonaDetallePuntos_General(-1, idRegZona).Tables(0)
                    If dtPuntos.Rows.Count > 0 Then
                        Dim latiZona, longiZona As Double
                        latiZona = dtPuntos.Rows(0).Item(1)
                        longiZona = dtPuntos.Rows(0).Item(2)
                        GM_Mapa1.Position = New PointLatLng(latiZona, longiZona)
                    End If
                End If

            End If
            'el comentado de arriba
            If _soloRepartidor = 0 Then
                _PCargarGridRegistrosPedidos(JGr_Registros1, "1", Str(idRegZona))
                P_prPonerCodicion()
            Else
                _PCargarGridRegistrosPedidos(JGr_Registros1, "1", , Tb_CodRep1.Text)
                P_prPonerCodicion()
            End If

            JGr_Registros1.ContextMenuStrip = ConMenu_Opciones1
        End If

    End Sub
    Private Sub JGr_Zonas2_SelectionChanged(sender As Object, e As EventArgs) Handles JGr_Zonas2.SelectionChanged
        If JGr_Zonas2.Row >= 0 Then
            swMostrarPedInvalidos.Value = False
            Tb_CodRep2.Text = JGr_Zonas2.CurrentRow.Cells(0).Value
            Tb_Repartidor2.Text = JGr_Zonas2.CurrentRow.Cells(1).Value
            Dim idRegZona As Integer
            Dim color1 As String
            If _soloRepartidor = 0 Then
                idRegZona = JGr_Zonas2.CurrentRow.Cells(2).Value
                Tb_Ciudad2.Text = JGr_Zonas2.CurrentRow.Cells(4).Value
                Tb_Provincia2.Text = JGr_Zonas2.CurrentRow.Cells(6).Value
                Tb_Zona2.Text = JGr_Zonas2.CurrentRow.Cells(8).Value
                color1 = JGr_Zonas2.CurrentRow.Cells(7).Value
            End If

            If (GM_Mapa2.Visible) Then
                'dibujar zona
                _PDibujarZona(idRegZona, _overlay2, color1)

                'cargar pedidos asignados a esa zona
                _overlay2.Markers.Clear()
                ' ''_PCargarGridRegistrosPedidos(JGr_Registros2, "2", Str(idRegZona), Tb_CodRep2.Text) 'filtrado por repartidor seleccionado en la zona
                ' ''JGr_Registros2.ContextMenuStrip = ConMenu_Opciones2 'añadir la opcion para retornar a un estado anterior

                'posicionar en la zona
                Dim dtPuntos = L_ZonaDetallePuntos_General(-1, idRegZona).Tables(0)
                If dtPuntos.Rows.Count > 0 Then
                    Dim latiZona, longiZona As Double
                    latiZona = dtPuntos.Rows(0).Item(1)
                    longiZona = dtPuntos.Rows(0).Item(2)
                    GM_Mapa2.Position = New PointLatLng(latiZona, longiZona)
                End If

            End If
            If _soloRepartidor = 0 Then
                _PCargarGridRegistrosPedidos(JGr_Registros2, "2", Str(idRegZona), Tb_CodRep2.Text) 'filtrado por repartidor seleccionado en la zona
            Else
                _PCargarGridRegistrosPedidos(JGr_Registros2, "2", , Tb_CodRep2.Text)
            End If
            'JGr_Registros2.RootTable.Columns("Check").Visible = False 'oculto el check
            JGr_Registros2.ContextMenuStrip = ConMenu_Opciones2 'añadir la opcion para retornar a un estado anterior
        End If
    End Sub

    Private Sub JGr_Zonas3_SelectionChanged(sender As Object, e As EventArgs) Handles JGr_Zonas3.SelectionChanged
        If JGr_Zonas3.Row >= 0 Then
            Tb_CodRep3.Text = JGr_Zonas3.CurrentRow.Cells(0).Value
            Tb_Repartidor3.Text = JGr_Zonas3.CurrentRow.Cells(1).Value
            Dim idRegZona As Integer
            Dim color1 As String
            If _soloRepartidor = 0 Then
                idRegZona = JGr_Zonas3.CurrentRow.Cells(2).Value
                Tb_Ciudad3.Text = JGr_Zonas3.CurrentRow.Cells(4).Value
                Tb_Provincia3.Text = JGr_Zonas3.CurrentRow.Cells(6).Value
                Tb_Zona3.Text = JGr_Zonas3.CurrentRow.Cells(8).Value
                color1 = JGr_Zonas3.CurrentRow.Cells(7).Value
            End If

            If (GM_Mapa3.Visible) Then
                'dibujar zona
                _PDibujarZona(idRegZona, _overlay3, color1)

                'cargar pedidos asignados a esa zona
                _overlay3.Markers.Clear()
                ' ''_PCargarGridRegistrosPedidos(JGr_Registros3, "3", Str(idRegZona), Tb_CodRep3.Text) 'filtrado por repartidor seleccionado en la zona
                ' ''JGr_Registros3.RootTable.Columns("Check").Visible = False 'oculto el check
                ' ''JGr_Registros3.ContextMenuStrip = ConMenu_Opciones3 'añadir la opcion para retornar a un estado anterior


                'posicionar en la zona
                Dim dtPuntos = L_ZonaDetallePuntos_General(-1, idRegZona).Tables(0)
                If dtPuntos.Rows.Count > 0 Then
                    Dim latiZona, longiZona As Double
                    latiZona = dtPuntos.Rows(0).Item(1)
                    longiZona = dtPuntos.Rows(0).Item(2)
                    GM_Mapa3.Position = New PointLatLng(latiZona, longiZona)
                End If


            End If
            If _soloRepartidor = 0 Then
                _PCargarGridRegistrosPedidos(JGr_Registros3, "3", Str(idRegZona), Tb_CodRep3.Text) 'filtrado por repartidor seleccionado en la zona
            Else
                _PCargarGridRegistrosPedidos(JGr_Registros3, "3", , Tb_CodRep3.Text)
            End If

            JGr_Registros3.RootTable.Columns("Check").Visible = False 'oculto el check
            JGr_Registros3.ContextMenuStrip = ConMenu_Opciones3 'añadir la opcion para retornar a un estado anterior
        End If
    End Sub

    Private Sub JGr_Registros_SelectionChanged(sender As Object, e As EventArgs) Handles JGr_Registros1.SelectionChanged

        If JGr_Registros1.Row >= 0 Then
            Dim idReg As Integer = JGr_Registros1.CurrentRow.Cells(0).Value
            Dim latitud As Double = JGr_Registros1.CurrentRow.Cells(13).Value
            Dim longitud As Double = JGr_Registros1.CurrentRow.Cells(14).Value
            Dim nombre As String = JGr_Registros1.CurrentRow.Cells(4).Value
            Dim obsPedido As String = JGr_Registros1.CurrentRow.Cells(10).Value
            Dim obsPedido2 As String = IIf(IsDBNull(JGr_Registros1.CurrentRow.Cells(11).Value), "", JGr_Registros1.CurrentRow.Cells(11).Value)

            'cargar el detalle del pedido seleccionado
            _PCargarGridDetalle(JGr_Detalles1, idReg)

            'cargar obserbacion del pedido
            Tb_PedidoObs1.Text = obsPedido
            Tb_PedidoObsAdicional1.Text = obsPedido2

            'dibujar etiqueta del cliente en el mapa
            Dim plg As New PointLatLng(latitud, longitud)
            _PDibujarPunto(_overlay1, plg, nombre)

            'posicionar en la zona
            GM_Mapa1.Position = New PointLatLng(latitud, longitud)
        End If

    End Sub

    Private Sub JGr_Registros2_SelectionChanged(sender As Object, e As EventArgs) Handles JGr_Registros2.SelectionChanged
        If JGr_Registros2.Row >= 0 Then
            Dim idReg As Integer = JGr_Registros2.CurrentRow.Cells(0).Value
            Dim latitud As Double = JGr_Registros2.CurrentRow.Cells(13).Value
            Dim longitud As Double = JGr_Registros2.CurrentRow.Cells(14).Value
            Dim nombre As String = JGr_Registros2.CurrentRow.Cells(4).Value
            Dim obsPedido As String = JGr_Registros2.CurrentRow.Cells(10).Value
            Dim obsPedido2 As String = IIf(IsDBNull(JGr_Registros2.CurrentRow.Cells(11).Value), "", JGr_Registros2.CurrentRow.Cells(11).Value)

            'cargar el detalle del pedido seleccionado
            _PCargarGridDetalle(JGr_Detalles2, idReg)

            'cargar obserbacion del pedido
            Tb_PedidoObs2.Text = obsPedido
            Tb_PedidoObsAdicional2.Text = obsPedido2

            'dibujar etiqueta del cliente en el mapa
            Dim plg As New PointLatLng(latitud, longitud)
            _PDibujarPunto(_overlay2, plg, nombre)

            'posicionar en la zona
            GM_Mapa2.Position = New PointLatLng(latitud, longitud)
        End If
    End Sub

    Private Sub JGr_Registros3_SelectionChanged(sender As Object, e As EventArgs) Handles JGr_Registros3.SelectionChanged
        If JGr_Registros3.Row >= 0 Then
            Dim idReg As Integer = JGr_Registros3.CurrentRow.Cells(0).Value
            Dim latitud As Double = JGr_Registros3.CurrentRow.Cells(13).Value
            Dim longitud As Double = JGr_Registros3.CurrentRow.Cells(14).Value
            Dim nombre As String = JGr_Registros3.CurrentRow.Cells(4).Value
            Dim obsPedido As String = JGr_Registros3.CurrentRow.Cells(10).Value
            Dim obsPedido2 As String = IIf(IsDBNull(JGr_Registros3.CurrentRow.Cells(11).Value), "", JGr_Registros3.CurrentRow.Cells(11).Value)

            'cargar el detalle del pedido seleccionado
            _PCargarGridDetalle(JGr_Detalles3, idReg)

            'cargar obserbacion del pedido
            Tb_PedidoObs3.Text = obsPedido
            Tb_PedidoObsAdicional3.Text = obsPedido2

            'dibujar etiqueta del cliente en el mapa
            Dim plg As New PointLatLng(latitud, longitud)
            _PDibujarPunto(_overlay3, plg, nombre)

            'posicionar en la zona
            GM_Mapa3.Position = New PointLatLng(latitud, longitud)
        End If
    End Sub


    Private Sub Btn_ConfirmEntregaPedidos_Click(sender As Object, e As EventArgs) Handles Btn_ConfirmEntregaPedidos.Click
        _PGrabarConfirmacionesEntregas()
    End Sub

    Private Sub JGr_Zonas2_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_Zonas2.EditingCell
        e.Cancel = True
    End Sub

    Private Sub JGr_Detalles2_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_Detalles2.EditingCell
        e.Cancel = True
    End Sub

    Private Sub JGr_Registros2_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_Registros2.EditingCell
        If e.Column.Index <> _colCkeck Then
            e.Cancel = True
        End If
    End Sub

    Private Sub JGr_Zonas3_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_Zonas3.EditingCell
        e.Cancel = True
    End Sub

    Private Sub JGr_Registros3_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_Registros3.EditingCell
        e.Cancel = True
    End Sub

    Private Sub JGr_Detalles3_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_Detalles3.EditingCell
        e.Cancel = True
    End Sub


    Private Sub Btn_ZoomMas_Click(sender As Object, e As EventArgs) Handles Btn_ZoomMas.Click
        If GM_Mapa1.Zoom <> GM_Mapa1.MaxZoom Then
            GM_Mapa1.Zoom = GM_Mapa1.Zoom + 1
        End If
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        If GM_Mapa2.Zoom <> GM_Mapa2.MaxZoom Then
            GM_Mapa2.Zoom = GM_Mapa2.Zoom + 1
        End If
    End Sub

    Private Sub ButtonX5_Click(sender As Object, e As EventArgs) Handles ButtonX5.Click
        If GM_Mapa3.Zoom <> GM_Mapa3.MaxZoom Then
            GM_Mapa3.Zoom = GM_Mapa3.Zoom + 1
        End If
    End Sub

    Private Sub Btn_ZoomMenos_Click(sender As Object, e As EventArgs) Handles Btn_ZoomMenos.Click
        If GM_Mapa1.Zoom <> GM_Mapa1.MinZoom Then
            GM_Mapa1.Zoom = GM_Mapa1.Zoom - 1
        End If
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        If GM_Mapa2.Zoom <> GM_Mapa2.MinZoom Then
            GM_Mapa2.Zoom = GM_Mapa2.Zoom - 1
        End If
    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles ButtonX4.Click
        If GM_Mapa3.Zoom <> GM_Mapa3.MinZoom Then
            GM_Mapa3.Zoom = GM_Mapa3.Zoom - 1
        End If
    End Sub

    Private Sub Btn_AddObsAdicional1_Click(sender As Object, e As EventArgs) Handles Btn_AddObsAdicional1.Click
        If JGr_Registros1.Row >= 0 Then
            Dim idReg As Integer = JGr_Registros1.CurrentRow.Cells(0).Value
            L_PedidoCabacera_ModificarObservacion2(idReg, Tb_PedidoObsAdicional1.Text)

            Dim fila As Integer = JGr_Registros1.Row
            If _soloRepartidor = 0 Then
                Dim idRegZona As Integer = JGr_Zonas1.CurrentRow.Cells(2).Value
                _PCargarGridRegistrosPedidos(JGr_Registros1, "1", Str(idRegZona))
                P_prPonerCodicion()
            Else
                _PCargarGridRegistrosPedidos(JGr_Registros1, "1", , Tb_CodRep1.Text)
                P_prPonerCodicion()
            End If
            JGr_Registros1.Row = fila
        End If
    End Sub

    Private Sub Btn_AddObsAdicional2_Click(sender As Object, e As EventArgs) Handles Btn_AddObsAdicional2.Click
        If JGr_Registros2.Row >= 0 Then
            Dim idReg As Integer = JGr_Registros2.CurrentRow.Cells(0).Value
            L_PedidoCabacera_ModificarObservacion2(idReg, Tb_PedidoObsAdicional2.Text)

            Dim fila As Integer = JGr_Registros2.Row
            If _soloRepartidor = 0 Then
                Dim idRegZona As Integer = JGr_Zonas2.CurrentRow.Cells(2).Value
                _PCargarGridRegistrosPedidos(JGr_Registros2, "2", Str(idRegZona), Tb_CodRep2.Text)
            Else
                _PCargarGridRegistrosPedidos(JGr_Registros2, "2", , Tb_CodRep2.Text)
            End If
            JGr_Registros2.Row = fila
        End If
    End Sub

    Private Sub Btn_AddObsAdicional3_Click(sender As Object, e As EventArgs) Handles Btn_AddObsAdicional3.Click
        If JGr_Registros3.Row >= 0 Then
            Dim idReg As Integer = JGr_Registros3.CurrentRow.Cells(0).Value
            L_PedidoCabacera_ModificarObservacion2(idReg, Tb_PedidoObsAdicional3.Text)

            Dim fila As Integer = JGr_Registros3.Row
            If _soloRepartidor = 0 Then
                Dim idRegZona As Integer = JGr_Zonas3.CurrentRow.Cells(2).Value
                _PCargarGridRegistrosPedidos(JGr_Registros3, "3", Str(idRegZona), Tb_CodRep3.Text)
            Else
                _PCargarGridRegistrosPedidos(JGr_Registros3, "3", , Tb_CodRep3.Text)
            End If
            JGr_Registros3.Row = fila
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        'grabo el reclamo del pedido
        Dim codPedido As Integer = JGr_Registros1.GetValue("CodPedido")

        Dim frm As New F0_IngresarReclamo(codPedido, "1", "1")
        frm.ShowDialog()

        'Dim numi As String = ""
        'Dim obs As String = InputBox("INGRESE EL RECLAMO QUE SE DESEA REGISTRAR", "RECLAMO DEL CLIENTE", "")
        'If obs <> String.Empty Then
        '    L_PedidoReclamos_Grabar(numi, codPedido, "1", obs.ToUpper, "1")
        'End If

    End Sub

    Private Sub GRABARRECLAMOToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GRABARRECLAMOToolStripMenuItem1.Click
        'grabo el reclamo del pedido
        Dim codPedido As Integer = JGr_Registros2.GetValue("CodPedido")

        Dim frm As New F0_IngresarReclamo(codPedido, "2", "1")
        frm.ShowDialog()

        'Dim numi As String = ""
        'Dim obs As String = InputBox("INGRESE EL RECLAMO QUE SE DESEA REGISTRAR", "RECLAMO DEL CLIENTE", "")
        'If obs <> String.Empty Then
        '    L_PedidoReclamos_Grabar(numi, codPedido, "2", obs.ToUpper, "1")
        'End If

    End Sub

    Private Sub GRABARRECLAMOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GRABARRECLAMOToolStripMenuItem.Click
        'grabo el reclamo del pedido
        Dim codPedido As Integer = JGr_Registros3.GetValue("CodPedido")

        Dim frm As New F0_IngresarReclamo(codPedido, "3", "1")
        frm.ShowDialog()

        'Dim numi As String = ""
        'Dim obs As String = InputBox("INGRESE EL RECLAMO QUE SE DESEA REGISTRAR", "RECLAMO DEL CLIENTE", "")
        'If obs <> String.Empty Then
        '    L_PedidoReclamos_Grabar(numi, codPedido, "3", obs.ToUpper, "1")
        'End If

    End Sub

    Private Sub GRABARRECLAMOREPARTIDORToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GRABARRECLAMOREPARTIDORToolStripMenuItem.Click
        'grabo el reclamo del pedido
        Dim codPedido As Integer = JGr_Registros1.GetValue("CodPedido")

        Dim frm As New F0_IngresarReclamo(codPedido, "1", "2")
        frm.ShowDialog()

        'Dim numi As String = ""
        'Dim obs As String = InputBox("INGRESE EL RECLAMO QUE SE DESEA REGISTRAR", "RECLAMO DEL REPARTIDOR", "")
        'If obs <> String.Empty Then
        '    L_PedidoReclamos_Grabar(numi, codPedido, "1", obs.ToUpper, "2")
        'End If

    End Sub

    Private Sub GRABARRECLAMOREPARTIDORToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GRABARRECLAMOREPARTIDORToolStripMenuItem1.Click
        'grabo el reclamo del pedido
        Dim codPedido As Integer = JGr_Registros2.GetValue("CodPedido")

        Dim frm As New F0_IngresarReclamo(codPedido, "2", "2")
        frm.ShowDialog()

        'Dim numi As String = ""
        'Dim obs As String = InputBox("INGRESE EL RECLAMO QUE SE DESEA REGISTRAR", "RECLAMO DEL REPARTIDOR", "")
        'If obs <> String.Empty Then
        '    L_PedidoReclamos_Grabar(numi, codPedido, "2", obs.ToUpper, "2")
        'End If

    End Sub

    Private Sub GRABARRECLAMOREPARTIDORToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles GRABARRECLAMOREPARTIDORToolStripMenuItem2.Click
        'grabo el reclamo del pedido
        Dim codPedido As Integer = JGr_Registros3.GetValue("CodPedido")

        Dim frm As New F0_IngresarReclamo(codPedido, "3", "2")
        frm.ShowDialog()

        'Dim numi As String = ""
        'Dim obs As String = InputBox("INGRESE EL RECLAMO QUE SE DESEA REGISTRAR", "RECLAMO", "")
        'If obs <> String.Empty Then
        '    L_PedidoReclamos_Grabar(numi, codPedido, "3", obs.ToUpper, "2")
        'End If

    End Sub

    Private Sub JGr_Registros1_DoubleClick(sender As Object, e As EventArgs) Handles JGr_Registros1.DoubleClick
        If JGr_Registros1.Row >= 0 Then
            Dim frmReclamos As P_ReclamoAyuda
            Dim codPedido As Integer = JGr_Registros1.GetValue("CodPedido")
            frmReclamos = New P_ReclamoAyuda(codPedido)
            frmReclamos.ShowDialog()
        End If

    End Sub

    Private Sub JGr_Registros2_DoubleClick(sender As Object, e As EventArgs) Handles JGr_Registros2.DoubleClick
        If JGr_Registros2.Row >= 0 Then
            Dim frmReclamos As P_ReclamoAyuda
            Dim codPedido As Integer = JGr_Registros2.GetValue("CodPedido")
            frmReclamos = New P_ReclamoAyuda(codPedido)
            frmReclamos.ShowDialog()
        End If
    End Sub

    Private Sub JGr_Registros3_DoubleClick(sender As Object, e As EventArgs) Handles JGr_Registros3.DoubleClick
        If JGr_Registros3.Row >= 0 Then
            Dim frmReclamos As P_ReclamoAyuda
            Dim codPedido As Integer = JGr_Registros3.GetValue("CodPedido")
            frmReclamos = New P_ReclamoAyuda(codPedido)
            frmReclamos.ShowDialog()
        End If
    End Sub

    Private Sub ANULARPEDIDOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ANULARPEDIDOToolStripMenuItem.Click
        Dim codPedido As Integer = JGr_Registros1.GetValue("CodPedido")

        Dim frm As New F0_IngresarReclamo(codPedido, "1", "3")
        frm.GroupPanel2.Text = "INGRESE EL MOTIVO DE LA ANULACION DEL PEDIDO"
        frm.ShowDialog()

        If frm.respuesta = True Then
            'L_PedidoCabacera_ModificarEstado(codPedido, "8")
            L_PedidoCabacera_ModificarActivoPasivo(codPedido, "2")

            'actualizar la grilla
            Dim idRegZona As Integer
            If _soloRepartidor = 0 Then
                idRegZona = JGr_Zonas1.CurrentRow.Cells(2).Value
                _PCargarGridRegistrosPedidos(JGr_Registros1, "1", Str(idRegZona))
                P_prPonerCodicion()
            Else
                _PCargarGridRegistrosPedidos(JGr_Registros1, "1", , Tb_CodRep1.Text)
                P_prPonerCodicion()
            End If
        End If
    End Sub

    Private Sub ANULARPEDIDOToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ANULARPEDIDOToolStripMenuItem1.Click
        Dim codPedido As Integer = JGr_Registros2.GetValue("CodPedido")

        Dim frm As New F0_IngresarReclamo(codPedido, "2", "3")
        frm.GroupPanel2.Text = "INGRESE EL MOTIVO DE LA ANULACION DEL PEDIDO"
        frm.ShowDialog()
        If frm.respuesta = True Then
            'L_PedidoCabacera_ModificarEstado(codPedido, "8")
            L_PedidoCabacera_ModificarActivoPasivo(codPedido, "2")

            'actualizar la grilla
            Dim idRegZona As Integer
            If _soloRepartidor = 0 Then
                idRegZona = JGr_Zonas2.CurrentRow.Cells(2).Value
                _PCargarGridRegistrosPedidos(JGr_Registros2, "2", Str(idRegZona), Tb_CodRep2.Text)
            Else
                _PCargarGridRegistrosPedidos(JGr_Registros2, "2", , Tb_CodRep2.Text)
            End If
        End If



        'Dim numi As String = ""
        'Dim obs As String = InputBox("INGRESE EL MOTIVO DE LA ANULACION DEL PEDIDO", "ANULACION DE PEDIDO", "")
        'If obs <> String.Empty Then
        '    L_PedidoReclamos_Grabar(numi, codPedido, "2", obs.ToUpper, "3")
        '    'L_PedidoCabacera_ModificarEstado(codPedido, "8")
        '    L_PedidoCabacera_ModificarActivoPasivo(codPedido, "2")

        '    'actualizar la grilla
        '    Dim idRegZona As Integer
        '    If _soloRepartidor = 0 Then
        '        idRegZona = JGr_Zonas2.CurrentRow.Cells(2).Value
        '        _PCargarGridRegistrosPedidos(JGr_Registros2, "2", Str(idRegZona), Tb_CodRep2.Text)
        '    Else
        '        _PCargarGridRegistrosPedidos(JGr_Registros2, "2", , Tb_CodRep2.Text)
        '    End If
        'End If

    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar1.Click
        If JGr_Zonas1.Row >= 0 Then
            Tb_CodRep1.Text = JGr_Zonas1.CurrentRow.Cells(0).Value
            Tb_Repartidor1.Text = JGr_Zonas1.CurrentRow.Cells(1).Value
            Dim idRegZona As Integer
            Dim color1 As String
            If _soloRepartidor = 0 Then
                idRegZona = JGr_Zonas1.CurrentRow.Cells(2).Value
                Tb_Ciudad1.Text = JGr_Zonas1.CurrentRow.Cells(4).Value
                Tb_Provincia1.Text = JGr_Zonas1.CurrentRow.Cells(6).Value
                Tb_Zona1.Text = JGr_Zonas1.CurrentRow.Cells(8).Value
                color1 = JGr_Zonas1.CurrentRow.Cells(7).Value
            End If

            If (GM_Mapa1.Visible) Then
                If _soloRepartidor = 0 Then
                    'dibujar zona
                    _PDibujarZona(idRegZona, _overlay1, color1)

                    'cargar pedidos asignados a esa zona
                    _overlay1.Markers.Clear()

                    'posicionar en la zona
                    Dim dtPuntos = L_ZonaDetallePuntos_General(-1, idRegZona).Tables(0)
                    If dtPuntos.Rows.Count > 0 Then
                        Dim latiZona, longiZona As Double
                        latiZona = dtPuntos.Rows(0).Item(1)
                        longiZona = dtPuntos.Rows(0).Item(2)
                        GM_Mapa1.Position = New PointLatLng(latiZona, longiZona)
                    End If
                End If

            End If
            'el comentado de arriba
            If _soloRepartidor = 0 Then
                _PCargarGridRegistrosPedidos(JGr_Registros1, "1", Str(idRegZona))
                P_prPonerCodicion()
            Else
                _PCargarGridRegistrosPedidos(JGr_Registros1, "1", , Tb_CodRep1.Text)
                P_prPonerCodicion()
            End If

            JGr_Registros1.ContextMenuStrip = ConMenu_Opciones1
        End If

    End Sub

    Private Sub Btn_Actualizar2_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar2.Click
        If JGr_Zonas2.Row >= 0 Then
            Tb_CodRep2.Text = JGr_Zonas2.CurrentRow.Cells(0).Value
            Tb_Repartidor2.Text = JGr_Zonas2.CurrentRow.Cells(1).Value
            Dim idRegZona As Integer
            Dim color1 As String
            If _soloRepartidor = 0 Then
                idRegZona = JGr_Zonas2.CurrentRow.Cells(2).Value
                Tb_Ciudad2.Text = JGr_Zonas2.CurrentRow.Cells(4).Value
                Tb_Provincia2.Text = JGr_Zonas2.CurrentRow.Cells(6).Value
                Tb_Zona2.Text = JGr_Zonas2.CurrentRow.Cells(8).Value
                color1 = JGr_Zonas2.CurrentRow.Cells(7).Value
            End If

            If (GM_Mapa2.Visible) Then
                'dibujar zona
                _PDibujarZona(idRegZona, _overlay2, color1)

                'cargar pedidos asignados a esa zona
                _overlay2.Markers.Clear()
                ' ''_PCargarGridRegistrosPedidos(JGr_Registros2, "2", Str(idRegZona), Tb_CodRep2.Text) 'filtrado por repartidor seleccionado en la zona
                ' ''JGr_Registros2.ContextMenuStrip = ConMenu_Opciones2 'añadir la opcion para retornar a un estado anterior

                'posicionar en la zona
                Dim dtPuntos = L_ZonaDetallePuntos_General(-1, idRegZona).Tables(0)
                If dtPuntos.Rows.Count > 0 Then
                    Dim latiZona, longiZona As Double
                    latiZona = dtPuntos.Rows(0).Item(1)
                    longiZona = dtPuntos.Rows(0).Item(2)
                    GM_Mapa2.Position = New PointLatLng(latiZona, longiZona)
                End If

            End If
            If _soloRepartidor = 0 Then
                _PCargarGridRegistrosPedidos(JGr_Registros2, "2", Str(idRegZona), Tb_CodRep2.Text) 'filtrado por repartidor seleccionado en la zona
            Else
                _PCargarGridRegistrosPedidos(JGr_Registros2, "2", , Tb_CodRep2.Text)
            End If
            JGr_Registros2.ContextMenuStrip = ConMenu_Opciones2 'añadir la opcion para retornar a un estado anterior
        End If
    End Sub

    Private Sub Btn_Actualizar3_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar3.Click
        If JGr_Zonas3.Row >= 0 Then
            Tb_CodRep3.Text = JGr_Zonas3.CurrentRow.Cells(0).Value
            Tb_Repartidor3.Text = JGr_Zonas3.CurrentRow.Cells(1).Value
            Dim idRegZona As Integer
            Dim color1 As String
            If _soloRepartidor = 0 Then
                idRegZona = JGr_Zonas3.CurrentRow.Cells(2).Value
                Tb_Ciudad3.Text = JGr_Zonas3.CurrentRow.Cells(4).Value
                Tb_Provincia3.Text = JGr_Zonas3.CurrentRow.Cells(6).Value
                Tb_Zona3.Text = JGr_Zonas3.CurrentRow.Cells(8).Value
                color1 = JGr_Zonas3.CurrentRow.Cells(7).Value
            End If

            If (GM_Mapa3.Visible) Then
                'dibujar zona
                _PDibujarZona(idRegZona, _overlay3, color1)

                'cargar pedidos asignados a esa zona
                _overlay3.Markers.Clear()
                ' ''_PCargarGridRegistrosPedidos(JGr_Registros3, "3", Str(idRegZona), Tb_CodRep3.Text) 'filtrado por repartidor seleccionado en la zona
                ' ''JGr_Registros3.RootTable.Columns("Check").Visible = False 'oculto el check
                ' ''JGr_Registros3.ContextMenuStrip = ConMenu_Opciones3 'añadir la opcion para retornar a un estado anterior


                'posicionar en la zona
                Dim dtPuntos = L_ZonaDetallePuntos_General(-1, idRegZona).Tables(0)
                If dtPuntos.Rows.Count > 0 Then
                    Dim latiZona, longiZona As Double
                    latiZona = dtPuntos.Rows(0).Item(1)
                    longiZona = dtPuntos.Rows(0).Item(2)
                    GM_Mapa3.Position = New PointLatLng(latiZona, longiZona)
                End If


            End If
            If _soloRepartidor = 0 Then
                _PCargarGridRegistrosPedidos(JGr_Registros3, "3", Str(idRegZona), Tb_CodRep3.Text) 'filtrado por repartidor seleccionado en la zona
            Else
                _PCargarGridRegistrosPedidos(JGr_Registros3, "3", , Tb_CodRep3.Text)
            End If

            JGr_Registros3.RootTable.Columns("Check").Visible = False 'oculto el check
            JGr_Registros3.ContextMenuStrip = ConMenu_Opciones3 'añadir la opcion para retornar a un estado anterior
        End If
    End Sub

    Private Sub VERHISTORIALToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VERHISTORIALToolStripMenuItem.Click

        Dim codPedido As Integer = JGr_Registros1.GetValue("CodPedido")

        Dim frmReclamos As P_HistorialAyuda
        frmReclamos = New P_HistorialAyuda(codPedido)
        frmReclamos.ShowDialog()

    End Sub

    Private Sub VERHISTORIALToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VERHISTORIALToolStripMenuItem1.Click
        Dim codPedido As Integer = JGr_Registros2.GetValue("CodPedido")

        Dim frmReclamos As P_HistorialAyuda
        frmReclamos = New P_HistorialAyuda(codPedido)
        frmReclamos.ShowDialog()
    End Sub

    Private Sub VERHISTORIALToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles VERHISTORIALToolStripMenuItem2.Click
        Dim codPedido As Integer = JGr_Registros3.GetValue("CodPedido")

        Dim frmReclamos As P_HistorialAyuda
        frmReclamos = New P_HistorialAyuda(codPedido)
        frmReclamos.ShowDialog()
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        Try
            Dim iIni, iFin As Integer

            Select Case e.OldValue.ToString
                Case "PEDIDOS PENDIENTES"
                    iIni = 1
                Case "PEDIDOS DICTADOS"
                    iIni = 2
                Case "PEDIDOS ENTREGADOS"
                    iIni = 3
            End Select
            Select Case e.NewValue.ToString
                Case "PEDIDOS PENDIENTES"
                    iFin = 1
                Case "PEDIDOS DICTADOS"
                    iFin = 2
                Case "PEDIDOS ENTREGADOS"
                    iFin = 3
            End Select

            If iIni = 1 And iFin = 2 Then
                If JGr_Zonas1.Row >= 0 Then
                    JGr_Zonas2.Row = JGr_Zonas1.Row
                End If
                Exit Sub
            End If

            If iIni = 2 And iFin = 3 Then
                If JGr_Zonas2.Row >= 0 Then
                    JGr_Zonas3.Row = JGr_Zonas2.Row
                End If
                Exit Sub
            End If

            If iIni = 3 And iFin = 2 Then
                If JGr_Zonas3.Row >= 0 Then
                    JGr_Zonas2.Row = JGr_Zonas3.Row
                End If
                Exit Sub
            End If

            If iIni = 2 And iFin = 1 Then
                If JGr_Zonas2.Row >= 0 Then
                    JGr_Zonas1.Row = JGr_Zonas2.Row
                End If
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub swMostrarPedInvalidos_ValueChanged(sender As Object, e As EventArgs) Handles swMostrarPedInvalidos.ValueChanged
        If swMostrarPedInvalidos.Value Then
            If JGr_Zonas2.Row >= 0 Then
                Tb_CodRep2.Text = JGr_Zonas2.CurrentRow.Cells(0).Value
                Tb_Repartidor2.Text = JGr_Zonas2.CurrentRow.Cells(1).Value
                Dim idRegZona As Integer
                Dim color1 As String
                If _soloRepartidor = 0 Then
                    idRegZona = JGr_Zonas2.CurrentRow.Cells(2).Value
                    Tb_Ciudad2.Text = JGr_Zonas2.CurrentRow.Cells(4).Value
                    Tb_Provincia2.Text = JGr_Zonas2.CurrentRow.Cells(6).Value
                    Tb_Zona2.Text = JGr_Zonas2.CurrentRow.Cells(8).Value
                    color1 = JGr_Zonas2.CurrentRow.Cells(7).Value
                End If

                If (GM_Mapa2.Visible) Then
                    'dibujar zona
                    _PDibujarZona(idRegZona, _overlay2, color1)

                    'cargar pedidos asignados a esa zona
                    _overlay2.Markers.Clear()
                    ' ''_PCargarGridRegistrosPedidos(JGr_Registros2, "2", Str(idRegZona), Tb_CodRep2.Text) 'filtrado por repartidor seleccionado en la zona
                    ' ''JGr_Registros2.ContextMenuStrip = ConMenu_Opciones2 'añadir la opcion para retornar a un estado anterior

                    'posicionar en la zona
                    Dim dtPuntos = L_ZonaDetallePuntos_General(-1, idRegZona).Tables(0)
                    If dtPuntos.Rows.Count > 0 Then
                        Dim latiZona, longiZona As Double
                        latiZona = dtPuntos.Rows(0).Item(1)
                        longiZona = dtPuntos.Rows(0).Item(2)
                        GM_Mapa2.Position = New PointLatLng(latiZona, longiZona)
                    End If

                End If
                If _soloRepartidor = 0 Then
                    _PCargarGridRegistrosPedidosInvalidos(JGr_Registros2, "2", Str(idRegZona), Tb_CodRep2.Text) 'filtrado por repartidor seleccionado en la zona
                Else
                    _PCargarGridRegistrosPedidosInvalidos(JGr_Registros2, "2", , Tb_CodRep2.Text)
                End If
                JGr_Registros2.ContextMenuStrip = ConMenu_Opciones2 'añadir la opcion para retornar a un estado anterior
            End If
        Else
            Btn_Actualizar2.PerformClick()
        End If
        btBorrarPedInvalidos.Enabled = swMostrarPedInvalidos.Value
    End Sub

    Private Sub btBorrarPedInvalidos_Click(sender As Object, e As EventArgs) Handles btBorrarPedInvalidos.Click
        _PAnularPedidosInvalidos()
    End Sub


    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        swMostrarPedInvalidos.Value = True
    End Sub

    Private Sub Btn_MostrarTodos1_Click(sender As Object, e As EventArgs) Handles Btn_MostrarTodos1.Click
        If _soloRepartidor = 0 Then
            _PCargarGridRegistrosPedidos(JGr_Registros1, "1", )
            P_prPonerCodicion()
        Else
            _PCargarGridRegistrosPedidos(JGr_Registros1, "1", , )
            P_prPonerCodicion()
        End If

        JGr_Registros1.ContextMenuStrip = ConMenu_Opciones1
    End Sub

    Private Sub btn_MostrarTodos2_Click(sender As Object, e As EventArgs) Handles btn_MostrarTodos2.Click
        If _soloRepartidor = 0 Then
            _PCargarGridRegistrosPedidos(JGr_Registros2, "2", , ) 'filtrado por repartidor seleccionado en la zona
        Else
            _PCargarGridRegistrosPedidos(JGr_Registros2, "2", , )
        End If
        JGr_Registros2.ContextMenuStrip = ConMenu_Opciones2 'añadir la opcion para retornar a un estado anterior
    End Sub

    Private Sub btn_MostrarTodos3_Click(sender As Object, e As EventArgs) Handles btn_MostrarTodos3.Click
        If _soloRepartidor = 0 Then
            _PCargarGridRegistrosPedidos(JGr_Registros3, "3", , ) 'filtrado por repartidor seleccionado en la zona
        Else
            _PCargarGridRegistrosPedidos(JGr_Registros3, "3", , )
        End If

        JGr_Registros3.RootTable.Columns("Check").Visible = False 'oculto el check
        JGr_Registros3.ContextMenuStrip = ConMenu_Opciones3 'añadir la opcion para retornar a un estado anterior
    End Sub

    Private Sub P_PedidosAsignacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        _modulo.Select()
        _tab.Close()
    End Sub

    Private Sub P_ImprimirRecibos(numi As String, printerName As String)
        Dim dt As DataTable

        dt = L_fnObtenerTabla("oanumi, oafdoc, cedesc, oarepa, cbdesc, ccnumi, cccod, ccdesc, obpcant, cadesc2, obpbase, obptot, cctelf1, ccdirec, oaobs, oaanumiprev, cbdesc2",
                              "vr_go_reciboCliente", "oanumi=" + numi)

        Dim objrep As New R_ReciboCliente
        objrep.SetDataSource(dt)
        objrep.PrintOptions.PrinterName = printerName
        objrep.PrintToPrinter(1, False, 1, 1)
    End Sub

    Private Sub IMPRIMIRPEDIDOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IMPRIMIRPEDIDOToolStripMenuItem.Click
        If (JGr_Registros2.GetRows.Count > 0) Then
            Dim dPrinter As New PrintDialog

            If (dPrinter.ShowDialog = Windows.Forms.DialogResult.OK) Then
                For Each fil As GridEXRow In JGr_Registros2.GetRows
                    P_ImprimirRecibos(fil.Cells("CodPedido").Value.ToString, dPrinter.PrinterSettings.PrinterName)
                Next
            End If
        Else
            ToastNotification.Show(Me,
                                   "No hay ningún pedido para imprimir.".ToUpper,
                                   My.Resources.WARNING,
                                   3 * 1000,
                                   eToastGlowColor.Red,
                                   eToastPosition.TopCenter)

        End If
    End Sub

    Private Sub JGr_Registros1_CellValueChanged(sender As Object, e As ColumnActionEventArgs) Handles JGr_Registros1.CellValueChanged
        If (e.Column.Key = "check") Then
            If (JGr_Registros1.GetValue("cceven") = True) Then
                JGr_Registros1.SetValue("check", False)
                ToastNotification.Show(Me,
                                   "Este cliente esta como eventual".ToUpper _
                                   + vbCrLf + "por favor confirmar al cliente para pasar el pedido a dictado.".ToUpper,
                                   My.Resources.WARNING,
                                   3 * 1000,
                                   eToastGlowColor.Red,
                                   eToastPosition.TopCenter)
            End If
        End If
    End Sub
End Class
