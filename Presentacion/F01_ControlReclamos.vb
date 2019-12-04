Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar.Controls

Public Class F01_ControlReclamos

#Region "Atributos"

    Dim InDuracion As Byte = 5
    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

#End Region

#Region "Metodos"

    Private Sub _PIniciarTodo()
        'abrir conexion
        'L_abrirConexion()
        _PCargarListaEmpleados()
        Me.Text = "C O N T R O L     R E C L A M O S"
        Me.WindowState = FormWindowState.Maximized
        RadialMenu1.Visible = False

        '_Filtrar()
        '_Inhabilitar()

        'activar los permisos del rol
        _PAsignarPermisos()

    End Sub

    Private Sub _PAsignarPermisos()
        Dim idRolUsu As String = L_Usuario_General(-1, " AND yduser='" + gs_user + "' ").Tables(0).Rows(0).Item("ybnumi")
        Dim dtRolUsu As DataTable = L_RolDetalle_General2(-1, idRolUsu, "ycyanumi=11")
        Dim show As Boolean = dtRolUsu.Rows(0).Item("ycshow")
        Dim add As Boolean = dtRolUsu.Rows(0).Item("ycadd")
        Dim modif As Boolean = dtRolUsu.Rows(0).Item("ycmod")
        Dim del As Boolean = dtRolUsu.Rows(0).Item("ycdel")

        If add = False Then

        End If
        If modif = False Then

        End If
        If del = False Then
            Btn_ConfirPedAnulados.Visible = False
        End If

    End Sub
    Private Sub _PCargarListaEmpleados()
        Dim dt As DataTable = L_Empleado_GeneralConPedidosReclamados(0).Tables(0)

        Dim newCustomersRow As DataRow = dt.NewRow()
        newCustomersRow("oarepa") = 0
        newCustomersRow("cbdesc") = "PENDIENTES"
        dt.Rows.Add(newCustomersRow)

        ListB_Empleados.ItemHeight = 30

        ListB_Empleados.DataSource = dt
        ListB_Empleados.DisplayMember = "cbdesc"
        ListB_Empleados.ValueMember = "oarepa"

        If dt.Rows.Count > 0 Then
            ListB_Empleados.SetSelected(0, False)
        End If

        ListB_Empleados.BackColor = Color.AliceBlue
    End Sub

    Private Sub _PCargarGridPedidosConReclamos(ByRef objGrid As Janus.Windows.GridEX.GridEX, Optional ByVal codRep As String = "-1", Optional ByVal estado As String = "-1", Optional ByVal check As Integer = 0)
        Dim dtReg As DataTable

        If estado = "-1" Then
            dtReg = L_PedidoCabecera_GeneralConReclamos(-1, " oaap=1 AND tl0012.lccbnumi=" + codRep + " ") '"oarepa=" + codRep + " AND oaap=1"
        Else
            dtReg = L_PedidoCabecera_GeneralConReclamos(-1, " oaap=1 AND tl0012.lccbnumi=" + codRep + " and " + estado) '"oarepa=" + codRep + " AND oaap=1 AND " + estado
        End If

        'añadir columna de check box
        If check = 1 Then
            dtReg.Columns.Add("Check", Type.GetType("System.Boolean"))
            Dim i As Integer
            For i = 0 To dtReg.Rows.Count - 1
                dtReg.Rows(i).Item("Check") = False
            Next
        End If


        objGrid.DataSource = dtReg
        objGrid.RetrieveStructure()

        'dar formato a las columnas
        With objGrid.RootTable.Columns("oanumi")
            .Caption = "Cod."
            .Width = 40
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With
        With objGrid.RootTable.Columns("oafdoc")
            .Caption = "Fecha"
            .Width = 90
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns("oahora")
            .Caption = "Hora"
            .Width = 55
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns("oaccli")
            .Visible = False
            .Caption = "Cod. Cliente"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns("ccdesc")
            .Caption = "Nombre Cli."
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
        End With

        With objGrid.RootTable.Columns("ccdirec")
            .Visible = False
            .Caption = "Direccion"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
        End With

        With objGrid.RootTable.Columns("cctelf1")
            .Visible = False
            .Caption = "Telefono"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns("cccat")
            .Visible = False
        End With

        With objGrid.RootTable.Columns("oazona")
            .Visible = False
        End With

        With objGrid.RootTable.Columns("cedesc")
            .Caption = "Zona"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
        End With

        With objGrid.RootTable.Columns("oaobs")
            .Caption = "Observacion"
            .Visible = False
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
        End With

        With objGrid.RootTable.Columns("oaobs2")
            .Caption = "Obs. Adicional"
            .Visible = False
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
        End With

        With objGrid.RootTable.Columns("oaest")
            .Visible = False
        End With

        'latitud y longitud
        With objGrid.RootTable.Columns("oarepa")
            .Visible = False
        End With

        With objGrid.RootTable.Columns("ccultvent")
            .Caption = "Ult. Venta"
            .Width = 85
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns("oapg")
            .Visible = False
        End With


        If check = 1 Then
            'objGrid.RootTable.Columns.Add("Check")
            With objGrid.RootTable.Columns("Check")
                .Visible = True
                .Width = 45
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.FontSize = gi_fuenteTamano
                .EditType = EditType.CheckBox
                .ColumnType = ColumnType.CheckBox
                .CheckBoxFalseValue = False
                .CheckBoxTrueValue = True
            End With
        End If

        objGrid.ContextMenuStrip = CMPedidosReclamos

        'Habilitar Filtradores
        With objGrid
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            .VisualStyle = VisualStyle.Office2007
        End With

        'poner color a la fila de acuerdo a la condicion 
        Dim fc, fc1, fc2, fc3, fc66 As GridEXFormatCondition

        fc1 = New GridEXFormatCondition(objGrid.RootTable.Columns("oapg"), ConditionOperator.Equal, 1)
        fc1.FormatStyle.BackColor = Color.LightGreen

        'pedido generado desde el celular
        fc66 = New GridEXFormatCondition(objGrid.RootTable.Columns("oapg"), ConditionOperator.Equal, 11)
        fc66.FormatStyle.BackColor = Color.LightCyan

        'formato para decir si es un pedido fue regerado a partir de otro pedido
        fc3 = New GridEXFormatCondition(objGrid.RootTable.Columns("oapg"), ConditionOperator.Equal, 2)
        fc3.FormatStyle.BackColor = Color.Yellow

        objGrid.RootTable.FormatConditions.Add(fc1)
        objGrid.RootTable.FormatConditions.Add(fc3)
        objGrid.RootTable.FormatConditions.Add(fc66)
    End Sub

    Private Sub _PCargarGridPedidosPreAnulados(ByRef objGrid As Janus.Windows.GridEX.GridEX, Optional ByVal codRep As String = "-1", Optional ByVal estado As String = "-1", Optional ByVal check As Integer = 0)
        Dim dtReg As DataTable

        If estado = "-1" Then
            dtReg = L_PedidoCabecera_GeneralConReclamos(-1, " oaap=2 AND tl0012.lccbnumi=" + codRep) '"oarepa=" + codRep + " AND oaap=2"
        Else
            dtReg = L_PedidoCabecera_GeneralConReclamos(-1, " oaap=2 AND tl0012.lccbnumi=" + codRep + " AND " + estado) '"oarepa=" + codRep + " AND oaap=2 AND " + estado
        End If

        'añadir columna de check box
        If check = 1 Then
            dtReg.Columns.Add("Check", Type.GetType("System.Boolean"))
            Dim i As Integer
            For i = 0 To dtReg.Rows.Count - 1
                dtReg.Rows(i).Item("Check") = False
            Next
        End If


        objGrid.DataSource = dtReg
        objGrid.RetrieveStructure()

        'dar formato a las columnas
        With objGrid.RootTable.Columns("oanumi")
            .Caption = "Cod."
            .Width = 40
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With
        With objGrid.RootTable.Columns("oafdoc")
            .Caption = "Fecha"
            .Width = 85
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns("oahora")
            .Caption = "Hora"
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns("oaccli")
            .Visible = False
            .Caption = "Cod. Cliente"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns("ccdesc")
            .Caption = "Nombre Cli."
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
        End With

        With objGrid.RootTable.Columns("ccdirec")
            .Visible = False
            .Caption = "Direccion"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
        End With

        With objGrid.RootTable.Columns("cctelf1")
            .Visible = False
            .Caption = "Telefono"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns("cccat")
            .Visible = False
        End With

        With objGrid.RootTable.Columns("oazona")
            .Visible = False
        End With

        With objGrid.RootTable.Columns("cedesc")
            .Caption = "Zona"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
        End With

        With objGrid.RootTable.Columns("oaobs")
            .Caption = "Observacion"
            .Visible = False
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
        End With

        With objGrid.RootTable.Columns("oaobs2")
            .Caption = "Obs. Adicional"
            .Visible = False
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
        End With

        With objGrid.RootTable.Columns("oaest")
            .Visible = False
        End With

        'latitud y longitud
        With objGrid.RootTable.Columns("oarepa")
            .Visible = False
        End With

        With objGrid.RootTable.Columns("ccultvent")
            .Caption = "Ult. Venta"
            .Width = 85
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With objGrid.RootTable.Columns("oapg")
            .Visible = False
        End With

        If check = 1 Then
            'objGrid.RootTable.Columns.Add("Check")
            With objGrid.RootTable.Columns("Check")
                .Visible = True
                .Width = 45
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.FontSize = gi_fuenteTamano
                .EditType = EditType.CheckBox
                .ColumnType = ColumnType.CheckBox
                .CheckBoxFalseValue = False
                .CheckBoxTrueValue = True
            End With
        End If

        objGrid.ContextMenuStrip = CMPedidosAnulados

        'Habilitar Filtradores
        With objGrid
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            .VisualStyle = VisualStyle.Office2007
        End With

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
        End With
        With objGrid.RootTable.Columns(4)
            .Caption = "Precio"
            .Key = "Precio"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .FormatString = "0"
        End With
        With objGrid.RootTable.Columns(5)
            .Caption = "Monto Bs."
            .Key = "Monto"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .FormatString = "0"
        End With

        'Habilitar Filtradores
        With objGrid
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue

            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
        End With

    End Sub

    Private Sub _PCargarGridReclamos(ByRef JGr_Reclamos As Janus.Windows.GridEX.GridEX, idPedido As Integer)
        Dim dt As New DataTable
        dt = L_PedidoReclamos_General(-1, idPedido)

        JGr_Reclamos.DataSource = dt
        JGr_Reclamos.RetrieveStructure()

        'dar formato a las columnas
        With JGr_Reclamos.RootTable.Columns("ofnumi")
            .Caption = "Id"
            .Width = 40
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With
        With JGr_Reclamos.RootTable.Columns("ofnumiped")
            .Visible = False
        End With
        With JGr_Reclamos.RootTable.Columns("oftip")
            .Visible = False
        End With
        With JGr_Reclamos.RootTable.Columns("oftip2")
            .Caption = "TIPO"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With
        With JGr_Reclamos.RootTable.Columns("ofest")
            .Visible = False
        End With
        With JGr_Reclamos.RootTable.Columns("ofest2")
            .Caption = "ESTADO"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With

        With JGr_Reclamos.RootTable.Columns("ofobs")
            .Caption = "Observacion"
            .Width = 180
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With

        With JGr_Reclamos.RootTable.Columns("offact")
            .Caption = "Fecha"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With
        With JGr_Reclamos.RootTable.Columns("ofhact")
            .Caption = "Hora"
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Reclamos.RootTable.Columns("ofconcep")
            .Visible = False
        End With

        With JGr_Reclamos.RootTable.Columns("cedesc")
            .Caption = "Concepto"
            .Width = 210
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With

        With JGr_Reclamos.RootTable.Columns("ofuact")
            .Caption = "User"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With


        'Habilitar Filtradores
        With JGr_Reclamos
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            .VisualStyle = VisualStyle.Office2007
        End With

        'poner color a la fila de acuerdo a la condicion 
        Dim fc, fc1, fc2 As GridEXFormatCondition
        fc = New GridEXFormatCondition(JGr_Reclamos.RootTable.Columns("oftip"), ConditionOperator.Equal, 1)
        fc.FormatStyle.BackColor = Color.LightGreen

        fc1 = New GridEXFormatCondition(JGr_Reclamos.RootTable.Columns("oftip"), ConditionOperator.Equal, 2)
        fc1.FormatStyle.BackColor = Color.LightBlue

        fc2 = New GridEXFormatCondition(JGr_Reclamos.RootTable.Columns("oftip"), ConditionOperator.Equal, 3)
        fc2.FormatStyle.BackColor = Color.LightCyan

        JGr_Reclamos.RootTable.FormatConditions.Add(fc)
        JGr_Reclamos.RootTable.FormatConditions.Add(fc1)
        JGr_Reclamos.RootTable.FormatConditions.Add(fc2)

        'cargar los tooltip
        JGr_Reclamos.ContextMenuStrip = ContextMenuStrip1
        JGr_Reclamos.CellToolTip = CellToolTip.UseCellToolTipText

    End Sub


    Private Sub _PGrabarConfirmacionesPedidosConReclamos()
        Dim i, cant, codPedido As Integer
        Dim estado As Boolean
        cant = 0
        For i = 0 To JGr_PedidosReclamos.RowCount - 1
            JGr_Reclamos.Row = i
            estado = JGr_PedidosReclamos.GetValue("Check")
            If estado = True Then
                codPedido = JGr_PedidosReclamos.GetValue("oanumi")
                'L_PedidoEstados_Grabar(codPedido, "4", Date.Now.Date.ToString("yyyy/MM/dd"), Now.Hour.ToString + ":" + Now.Minute.ToString, "Confirmacion de visualizacion de pedido con reclamo")
                'L_PedidoCabacera_ModificarEstado(codPedido, "2")
                cant = cant + 1
            End If
        Next

        ToastNotification.Show(Me, Str(cant) + " Pedidos Revisados Exitosamente", My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)

        'actualizar registros 
        Dim codEmpleado As Integer = ListB_Empleados.SelectedValue
        _PCargarGridPedidosConReclamos(JGr_PedidosReclamos, codEmpleado, "(oaest=1 or oaest=2 or oaest=3)")
    End Sub

    Private Sub _PGrabarConfirmacionesPedidosAnulado()
        Dim i, cant, codPedido As Integer
        Dim estado As Boolean
        cant = 0
        For i = 0 To JGr_PedidosAnulados.RowCount - 1
            JGr_PedidosAnulados.Row = i
            estado = JGr_PedidosAnulados.GetValue("Check")
            If estado = True Then
                codPedido = JGr_PedidosAnulados.GetValue("oanumi")
                L_PedidoEstados_Grabar(codPedido, "-2", Date.Now.Date.ToString("yyyy/MM/dd"), Now.Hour.ToString + ":" + Now.Minute.ToString, "Confir Ped Anulado")
                L_PedidoCabacera_ModificarActivoPasivo(codPedido, "3")
                cant = cant + 1
            End If
        Next

        ToastNotification.Show(Me, Str(cant) + " Pedidos Revisados Exitosamente", My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)

        'cargar pedidos anulados
        Dim codEmpleado As Integer = ListB_Empleados.SelectedValue
        '_PCargarGridPedidosConReclamos(JGr_PedidosAnulados, codEmpleado, "oaest=8", 1)
        _PCargarGridPedidosPreAnulados(JGr_PedidosAnulados, codEmpleado, , 1)
    End Sub

    Private Sub _PCambiarTamañoGridRegReclamos(grande As Boolean)

        If JGr_PedidosReclamos.Row >= 0 Then

            'dar formato a las columnas
            With JGr_PedidosReclamos.RootTable.Columns("oanumi")
                If grande Then
                    .Width = 100
                Else
                    .Width = 40
                End If

            End With
            With JGr_PedidosReclamos.RootTable.Columns("oafdoc")
                If grande Then
                    .Width = 150
                Else
                    .Width = 90
                End If
            End With

            With JGr_PedidosReclamos.RootTable.Columns("oahora")
                If grande Then
                    .Width = 100
                Else
                    .Width = 55
                End If
            End With

            With JGr_PedidosReclamos.RootTable.Columns("oaccli")
                If grande Then
                    .Width = 150
                Else
                    .Width = 70
                End If
            End With

            With JGr_PedidosReclamos.RootTable.Columns("ccdesc")
                If grande Then
                    .Width = 500
                Else
                    .Width = 200
                End If
            End With

            With JGr_PedidosReclamos.RootTable.Columns("ccdirec")
                If grande Then
                    .Width = 400
                Else
                    .Width = 200
                End If
            End With

            With JGr_PedidosReclamos.RootTable.Columns("cctelf1")
                If grande Then
                    .Width = 150
                Else
                    .Width = 70
                End If
            End With

            With JGr_PedidosReclamos.RootTable.Columns("cedesc")
                If grande Then
                    .Width = 80
                Else
                    .Width = 80
                End If
            End With

            With JGr_PedidosReclamos.RootTable.Columns("oaobs")
                If grande Then
                    .Width = 150
                Else
                    .Width = 80
                End If
            End With

            With JGr_PedidosReclamos.RootTable.Columns("oaobs2")
                If grande Then
                    .Width = 150
                Else
                    .Width = 80
                End If
            End With

            With JGr_PedidosReclamos.RootTable.Columns("ccultvent")
                If grande Then
                    .Width = 150
                Else
                    .Width = 85
                End If
            End With

        End If
    End Sub

    Private Sub _PCambiarTamañoGridRegPreAnulados(grande As Boolean)
        If JGr_PedidosAnulados.Row >= 0 Then
            With JGr_PedidosAnulados.RootTable.Columns("oanumi")
                If grande Then
                    .Width = 80
                Else
                    .Width = 40
                End If
            End With
            With JGr_PedidosAnulados.RootTable.Columns("oafdoc")
                If grande Then
                    .Width = 100
                Else
                    .Width = 85
                End If

            End With

            With JGr_PedidosAnulados.RootTable.Columns("oahora")
                If grande Then
                    .Width = 100
                Else
                    .Width = 50
                End If

            End With

            With JGr_PedidosAnulados.RootTable.Columns("oaccli")

                If grande Then
                    .Width = 150
                Else
                    .Width = 70
                End If
            End With

            With JGr_PedidosAnulados.RootTable.Columns("ccdesc")
                If grande Then
                    .Width = 400
                Else
                    .Width = 200
                End If
            End With

            With JGr_PedidosAnulados.RootTable.Columns("ccdirec")
                If grande Then
                    .Width = 400
                Else
                    .Width = 200
                End If
            End With

            With JGr_PedidosAnulados.RootTable.Columns("cctelf1")

                If grande Then
                    .Width = 150
                Else
                    .Width = 70
                End If
            End With

            With JGr_PedidosAnulados.RootTable.Columns("cedesc")
                If grande Then
                    .Width = 150
                Else
                    .Width = 80
                End If
            End With

            With JGr_PedidosAnulados.RootTable.Columns("oaobs")
                If grande Then
                    .Width = 200
                Else
                    .Width = 80
                End If
            End With

            With JGr_PedidosAnulados.RootTable.Columns("oaobs2")
                If grande Then
                    .Width = 150
                Else
                    .Width = 80
                End If

            End With

            With JGr_PedidosAnulados.RootTable.Columns("ccultvent")
                If grande Then
                    .Width = 150
                Else
                    .Width = 85
                End If
            End With
        End If

    End Sub

    Private Sub _PCambiarTamañoGridDetalleReclamos(grande As Boolean)
        If JGr_Reclamos.Row >= 0 Then
            With JGr_Reclamos.RootTable.Columns("ofnumi")
                If grande Then
                    .Width = 80
                Else
                    .Width = 40
                End If
            End With
            With JGr_Reclamos.RootTable.Columns("oftip2")
                If grande Then
                    .Width = 160
                Else
                    .Width = 80
                End If
            End With
            With JGr_Reclamos.RootTable.Columns("ofest2")
                If grande Then
                    .Width = 120
                Else
                    .Width = 80
                End If
            End With

            With JGr_Reclamos.RootTable.Columns("ofobs")
                If grande Then
                    .Width = 400
                Else
                    .Width = 180
                End If
            End With

            With JGr_Reclamos.RootTable.Columns("offact")
                If grande Then
                    .Width = 150
                Else
                    .Width = 70
                End If
            End With
            With JGr_Reclamos.RootTable.Columns("ofhact")
                If grande Then
                    .Width = 100
                Else
                    .Width = 50
                End If
            End With
            With JGr_Reclamos.RootTable.Columns("ofuact")
                If grande Then
                    .Width = 150
                Else
                    .Width = 80
                End If
            End With
        End If
    End Sub
    Private Sub _PCambiarTamañoGridDetallePedidos(grande As Boolean)
        If JGr_Detalle.Row >= 0 Then
            If JGr_Detalle.Row >= 0 Then

                With JGr_Detalle.RootTable.Columns(1)
                    If grande Then
                        .Width = 100
                    Else
                        .Width = 70
                    End If
                End With

                With JGr_Detalle.RootTable.Columns(2)
                    If grande Then
                        .Width = 400
                    Else
                        .Width = 200
                    End If
                End With

                With JGr_Detalle.RootTable.Columns(3)
                    If grande Then
                        .Width = 150
                    Else
                        .Width = 70
                    End If
                End With
                With JGr_Detalle.RootTable.Columns(4)
                    If grande Then
                        .Width = 120
                    Else
                        .Width = 70
                    End If
                End With
                With JGr_Detalle.RootTable.Columns(5)
                    If grande Then
                        .Width = 120
                    Else
                        .Width = 70
                    End If
                End With
            End If
        End If

    End Sub
#End Region

    Private Sub P_ControlReclamos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _PIniciarTodo()
    End Sub

    Private Sub ListB_Empleados_ItemClick(sender As Object, e As EventArgs) Handles ListB_Empleados.ItemClick
        Try
            'Dim item As ListBoxItem = CType(sender, ListBoxItem)
            'Dim empleado As String = item.Text
            Dim codEmpleado As Integer = ListB_Empleados.SelectedValue

            'cargar pedidos 
            _PCargarGridPedidosConReclamos(JGr_PedidosReclamos, codEmpleado, "(oaest=1 or oaest=2 or oaest=3)")
            RadioButton1.Checked = True

            'cargar pedidos anulados
            '_PCargarGridPedidosConReclamos(JGr_PedidosAnulados, codEmpleado, "oaest=8", 1)
            _PCargarGridPedidosPreAnulados(JGr_PedidosAnulados, codEmpleado, , 1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListB_Empleados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListB_Empleados.SelectedIndexChanged
        'Try
        '    'Dim item As ListBoxItem = CType(sender, ListBoxItem)
        '    'Dim empleado As String = item.Text
        '    Dim codEmpleado As Integer = ListB_Empleados.SelectedValue

        '    'cargar pedidos 
        '    _PCargarGridPedidosConReclamos(JGr_PedidosReclamos, codEmpleado, "(oaest=1 or oaest=2 or oaest=3)", 1)

        '    'cargar pedidos anulados
        '    '_PCargarGridPedidosConReclamos(JGr_PedidosAnulados, codEmpleado, "oaest=8", 1)
        '    _PCargarGridPedidosPreAnulados(JGr_PedidosAnulados, codEmpleado, , 1)
        'Catch ex As Exception

        'End Try
    End Sub


    Private Sub JGr_PedidosReclamos_SelectionChanged(sender As Object, e As EventArgs) Handles JGr_PedidosReclamos.SelectionChanged
        If JGr_PedidosReclamos.Row >= 0 Then
            Dim idPedido As Integer = JGr_PedidosReclamos.CurrentRow.Cells("oanumi").Value
            'cargar el detalle del pedido seleccionado
            _PCargarGridDetalle(JGr_Detalle, idPedido)
            _PCargarGridReclamos(JGr_Reclamos, idPedido)

            If (RbNotas.Checked) Then
                JGr_Reclamos.ContextMenuStrip = CmEliminarDifPedidoNota
            Else
                JGr_Reclamos.ContextMenuStrip = ContextMenuStrip1
            End If
            EliminarToolStripMenuItem.Visible = RbNotas.Checked

        End If
    End Sub

    Private Sub JGr_PedidosReclamos_Enter(sender As Object, e As EventArgs) Handles JGr_PedidosReclamos.Enter
        If JGr_PedidosReclamos.Row >= 0 Then
            Dim idPedido As Integer = JGr_PedidosReclamos.CurrentRow.Cells("oanumi").Value
            'cargar el detalle del pedido seleccionado
            _PCargarGridDetalle(JGr_Detalle, idPedido)
            _PCargarGridReclamos(JGr_Reclamos, idPedido)

        End If
    End Sub

    Private Sub ContextMenuStrip1_Opened(sender As Object, e As EventArgs) Handles ContextMenuStrip1.Opened
        If JGr_Reclamos.Row >= 0 Then
            DetalleToolStripMenuItem.Text = JGr_Reclamos.GetValue("ofobs")
        End If
    End Sub

    Private Sub JGr_PedidosReclamos_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_PedidosReclamos.EditingCell
        If "Check" <> e.Column.Key Then
            e.Cancel = True
        End If

    End Sub

    Private Sub JGr_Reclamos_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_Reclamos.EditingCell
        e.Cancel = True
    End Sub

    Private Sub JGr_Detalle_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_Detalle.EditingCell
        e.Cancel = True
    End Sub

    Private Sub JGr_PedidosAnulados_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_PedidosAnulados.EditingCell
        If "Check" <> e.Column.Key Then
            e.Cancel = True
        End If

    End Sub

    Private Sub JGr_PedidosAnulados_SelectionChanged(sender As Object, e As EventArgs) Handles JGr_PedidosAnulados.SelectionChanged
        If JGr_PedidosAnulados.Row >= 0 Then
            Dim idPedido As Integer = JGr_PedidosAnulados.CurrentRow.Cells("oanumi").Value
            'cargar el detalle del pedido seleccionado
            _PCargarGridDetalle(JGr_Detalle, idPedido)
            _PCargarGridReclamos(JGr_Reclamos, idPedido)

        End If
    End Sub

    Private Sub JGr_PedidosAnulados_Enter(sender As Object, e As EventArgs) Handles JGr_PedidosAnulados.Enter
        If JGr_PedidosAnulados.Row >= 0 Then
            Dim idPedido As Integer = JGr_PedidosAnulados.CurrentRow.Cells("oanumi").Value
            'cargar el detalle del pedido seleccionado
            _PCargarGridDetalle(JGr_Detalle, idPedido)
            _PCargarGridReclamos(JGr_Reclamos, idPedido)

        End If
    End Sub

    Private Sub Btn_ConfirPedReclamos_Click(sender As Object, e As EventArgs)
        _PGrabarConfirmacionesPedidosConReclamos()
    End Sub

    Private Sub Btn_ConfirPedAnulados_Click(sender As Object, e As EventArgs) Handles Btn_ConfirPedAnulados.Click
        _PGrabarConfirmacionesPedidosAnulado()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            Dim codEmpleado As Integer = ListB_Empleados.SelectedValue
            _PCargarGridPedidosConReclamos(JGr_PedidosReclamos, codEmpleado, "(oaest=1 or oaest=2 or oaest=3)")
            If TableLayoutPanel3.ColumnStyles(0).Width = 100 Then
                _PCambiarTamañoGridRegReclamos(True)
            Else
                _PCambiarTamañoGridRegReclamos(False)
            End If
        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            Dim codEmpleado As Integer = ListB_Empleados.SelectedValue
            _PCargarGridPedidosConReclamos(JGr_PedidosReclamos, codEmpleado, "(oaest=4)")
            If TableLayoutPanel3.ColumnStyles(0).Width = 100 Then
                _PCambiarTamañoGridRegReclamos(True)
            Else
                _PCambiarTamañoGridRegReclamos(False)
            End If
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            Dim codEmpleado As Integer = ListB_Empleados.SelectedValue
            _PCargarGridPedidosConReclamos(JGr_PedidosReclamos, codEmpleado, "(oaest=1 OR oaest=2 OR oaest=3 or oaest=4)")
            If TableLayoutPanel3.ColumnStyles(0).Width = 100 Then
                _PCambiarTamañoGridRegReclamos(True)
            Else
                _PCambiarTamañoGridRegReclamos(False)
            End If
        End If
    End Sub

    Private Sub RadialMenu1_ItemClick(sender As Object, e As EventArgs) Handles RadialMenu1.ItemClick
        Dim item As RadialMenuItem = TryCast(sender, RadialMenuItem)
        If item IsNot Nothing AndAlso (Not String.IsNullOrEmpty(item.Text)) Then
            Select Case item.Text
                Case "PENDIENTES"
                    Dim codEmpleado As Integer = ListB_Empleados.SelectedValue
                    _PCargarGridPedidosConReclamos(JGr_PedidosReclamos, codEmpleado, "(oaest=1)")
                Case "DICTADOS"
                    Dim codEmpleado As Integer = ListB_Empleados.SelectedValue
                    _PCargarGridPedidosConReclamos(JGr_PedidosReclamos, codEmpleado, "(oaest=2)")
                Case "TODOS"
                    Dim codEmpleado As Integer = ListB_Empleados.SelectedValue
                    _PCargarGridPedidosConReclamos(JGr_PedidosReclamos, codEmpleado, "(oaest=1 OR oaest=2 OR oaest=3)")
            End Select

        End If
    End Sub

    Private Sub JGr_PedidosReclamos_FormattingRow(sender As Object, e As RowLoadEventArgs) Handles JGr_PedidosReclamos.FormattingRow

    End Sub

    Private Sub GroupPanel2_DoubleClick(sender As Object, e As EventArgs) Handles GroupPanel2.DoubleClick, JGr_PedidosReclamos.DoubleClick
        If TableLayoutPanel3.ColumnStyles(0).Width = 100 Then
            TableLayoutPanel3.ColumnStyles(0).Width = 50
            TableLayoutPanel3.RowStyles(0).Height = 50
            TableLayoutPanel3.ColumnStyles(1).Width = 50
            TableLayoutPanel3.RowStyles(1).Height = 50
            _PCambiarTamañoGridRegReclamos(False)
        Else
            TableLayoutPanel3.ColumnStyles(0).Width = 100
            TableLayoutPanel3.RowStyles(0).Height = 100
            TableLayoutPanel3.ColumnStyles(1).Width = 0
            TableLayoutPanel3.RowStyles(1).Height = 0
            _PCambiarTamañoGridRegReclamos(True)
        End If
    End Sub

    Private Sub GroupPanel3_DoubleClick(sender As Object, e As EventArgs) Handles GroupPanel3.DoubleClick, JGr_PedidosAnulados.DoubleClick
        If TableLayoutPanel3.ColumnStyles(1).Width = 100 Then
            TableLayoutPanel3.ColumnStyles(0).Width = 50
            TableLayoutPanel3.RowStyles(0).Height = 50
            TableLayoutPanel3.ColumnStyles(1).Width = 50
            TableLayoutPanel3.RowStyles(1).Height = 50
            _PCambiarTamañoGridRegPreAnulados(False)
        Else
            TableLayoutPanel3.ColumnStyles(0).Width = 0
            TableLayoutPanel3.RowStyles(0).Height = 100
            TableLayoutPanel3.ColumnStyles(1).Width = 100
            TableLayoutPanel3.RowStyles(1).Height = 0
            _PCambiarTamañoGridRegPreAnulados(True)
        End If
    End Sub

    Private Sub GroupPanel4_DoubleClick(sender As Object, e As EventArgs) Handles GroupPanel4.DoubleClick, JGr_Reclamos.DoubleClick
        If TableLayoutPanel3.ColumnStyles(0).Width = 100 Then
            TableLayoutPanel3.ColumnStyles(0).Width = 50
            TableLayoutPanel3.RowStyles(0).Height = 50
            TableLayoutPanel3.ColumnStyles(1).Width = 50
            TableLayoutPanel3.RowStyles(1).Height = 50
            _PCambiarTamañoGridDetalleReclamos(False)
        Else
            TableLayoutPanel3.ColumnStyles(0).Width = 100
            TableLayoutPanel3.RowStyles(0).Height = 0
            TableLayoutPanel3.ColumnStyles(1).Width = 0
            TableLayoutPanel3.RowStyles(1).Height = 100
            _PCambiarTamañoGridDetalleReclamos(True)
        End If
    End Sub

    Private Sub GroupPanel5_DoubleClick(sender As Object, e As EventArgs) Handles GroupPanel5.DoubleClick, JGr_Detalle.DoubleClick
        If TableLayoutPanel3.ColumnStyles(1).Width = 100 Then
            TableLayoutPanel3.ColumnStyles(0).Width = 50
            TableLayoutPanel3.RowStyles(0).Height = 50
            TableLayoutPanel3.ColumnStyles(1).Width = 50
            TableLayoutPanel3.RowStyles(1).Height = 50
            _PCambiarTamañoGridDetallePedidos(False)
        Else
            TableLayoutPanel3.ColumnStyles(0).Width = 0
            TableLayoutPanel3.RowStyles(0).Height = 0
            TableLayoutPanel3.ColumnStyles(1).Width = 100
            TableLayoutPanel3.RowStyles(1).Height = 100
            _PCambiarTamañoGridDetallePedidos(True)
        End If
    End Sub

    Private Sub VERHISTORIALToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VERHISTORIALToolStripMenuItem.Click
        Dim frmReclamos As P_HistorialAyuda
        Dim codPedido As Integer = JGr_PedidosReclamos.GetValue("oanumi")
        frmReclamos = New P_HistorialAyuda(codPedido)
        frmReclamos.ShowDialog()
    End Sub

    Private Sub VERHISTORIALToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VERHISTORIALToolStripMenuItem1.Click
        Dim frmReclamos As P_HistorialAyuda
        Dim codPedido As Integer = JGr_PedidosAnulados.GetValue("oanumi")
        frmReclamos = New P_HistorialAyuda(codPedido)
        frmReclamos.ShowDialog()
    End Sub

    Private Sub VERHISTORIALDEPEDIDOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VERHISTORIALDEPEDIDOSToolStripMenuItem.Click
        Dim frmReclamos As P_HistorialClienteAyuda
        Dim codCliente As Integer = JGr_PedidosReclamos.GetValue("oaccli")
        Dim nomCliente As String = JGr_PedidosReclamos.GetValue("ccdesc")
        frmReclamos = New P_HistorialClienteAyuda(codCliente, nomCliente)
        frmReclamos.ShowDialog()
    End Sub

    Private Sub VERHISTORIALDEPEDIDOSToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VERHISTORIALDEPEDIDOSToolStripMenuItem1.Click
        Dim frmReclamos As P_HistorialClienteAyuda
        Dim codCliente As Integer = JGr_PedidosAnulados.GetValue("oaccli")
        Dim nomCliente As String = JGr_PedidosAnulados.GetValue("ccdesc")
        frmReclamos = New P_HistorialClienteAyuda(codCliente, nomCliente)
        frmReclamos.ShowDialog()
    End Sub

    Private Sub RbNotas_CheckedChanged(sender As Object, e As EventArgs) Handles RbNotas.CheckedChanged
        If (RbNotas.Checked) Then
            P_prCargarGrillaPedidoConReclamo()
            '    JGr_Reclamos.ContextMenuStrip = CmEliminarDifPedidoNota
            'Else
            '    JGr_Reclamos.ContextMenuStrip = ContextMenuStrip1
        End If
        'EliminarToolStripMenuItem.Visible = RbNotas.Checked
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        Dim numi2 As String = JGr_Reclamos.GetValue("ofnumi") 'Valor del código único

        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper,
                                       eTaskDialogIcon.Delete, "advertencia".ToUpper,
                                       "Esta a punto de eliminar el reclamo con".ToUpper _
                                       + vbCrLf + "código -> ".ToUpper _
                                       + numi2 + " " + vbCrLf + "Desea continuar?".ToUpper,
                                       eTaskDialogButton.Yes Or eTaskDialogButton.Cancel,
                                       eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim obs As String = L_ObtenerDato("ofobs", "TO0014", "ofnumi=" + numi2)
            Dim pedi, nota, clie, cped, cnot, cpro As String
            pedi = obs.Split(";")(0).Split(" ")(0).Split("=")(1)
            nota = L_ObtenerDato("odnumi", "TO002", "odnota=" + obs.Split(";")(0).Split(" ")(1).Split("=")(1))
            clie = obs.Split(";")(0).Split(" ")(2).Split("=")(1)
            cped = obs.Split(";")(1).Trim.Split(",")(0).Trim.Split("=")(1)
            If (cped = String.Empty) Then
                cpro = "0"
            Else
                cpro = L_ObtenerDato("obcprod", "TO0011", "obnumi=" + pedi + " and obpcant=" + cped)
            End If
            cnot = obs.Split(";")(1).Trim.Split(",")(1).Trim.Split("=")(1)
            Dim numi As String = L_ObtenerDato("ojnumi", "TO0023", "ojto1=" + pedi.Trim + " and ojto2=" + nota.Trim _
                                               + " and ojtc4=" + clie.Trim + " and ojcant=" + cnot + " and ojtc1=" + cpro.Trim)

            Dim res As Boolean = L_fnTO0023Eliminar(numi, numi2) 'Medoto de lógica para eliminar
            If (res) Then
                ToastNotification.Show(Me, "Codigo de reclamo: ".ToUpper + numi + " eliminado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA, InDuracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
                P_prCargarGrillaPedidoConReclamo()
            Else
                ToastNotification.Show(Me, "No se pudo eliminar el reclamo con código: ".ToUpper + numi + ", intente nuevamente.".ToUpper,
                                           My.Resources.WARNING, InDuracion * 1000,
                                           eToastGlowColor.Red,
                                           eToastPosition.TopCenter)
            End If
        End If
    End Sub

    Private Sub P_prCargarGrillaPedidoConReclamo()
        Dim codEmpleado As Integer = ListB_Empleados.SelectedValue
        _PCargarGridPedidosConReclamos(JGr_PedidosReclamos, codEmpleado, "(ofconcep=-1)")
        If TableLayoutPanel3.ColumnStyles(0).Width = 100 Then
            _PCambiarTamañoGridRegReclamos(True)
        Else
            _PCambiarTamañoGridRegReclamos(False)
        End If
    End Sub


    Private Sub F01_ControlReclamos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _modulo.Select()
        _tab.Close()
    End Sub

End Class