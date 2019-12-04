Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar

Public Class P_HistorialClienteAyuda


#Region "ATRIBUTOS PRIVADOS"

#End Region

#Region "METODOS PRIVADOS"

    Public Sub New(idCliente As String, nombreCli As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.StartPosition = FormStartPosition.CenterParent

        _PCargarGridRegistrosPedidos(JGr_Reclamos, idCliente)

        GroupPanel1.Text = "historial de pedidos del cliente: ".ToUpper + nombreCli
        'poner en el filtrador
        'JGr_Reclamos.Focus()
        'JGr_Reclamos.MoveTo(JGr_Reclamos.FilterRow)
        'JGr_Reclamos.Col = 5

    End Sub

    Private Sub _PCargarGridRegistrosPedidos(ByRef objGrid As Janus.Windows.GridEX.GridEX, codCli As String, Optional estado As String = "")
        Dim dt As DataTable
        If estado = "" Then
            dt = L_PedidoCabecera_GeneralTop10ConEstados(-1, " AND oaccli=" + codCli + " AND oaest>=1 AND oaest<=4 and oaap=1 ")
        Else
            dt = L_PedidoCabecera_GeneralTop10ConEstados(-1, " AND oaest=" + estado + " AND oaccli=" + codCli + " AND oaest>=1 AND oaest<=4 oaap=1 ")
        End If



        If dt.Rows.Count > 0 Then
            objGrid.BoundMode = BoundMode.Bound
            objGrid.DataSource = dt
            objGrid.RetrieveStructure()

            'dar formato a las columnas
            With objGrid.RootTable.Columns("oanumi")
                .Caption = "Cod. Pedido"
                .Key = "COD. PED."
                .Width = 70
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.FontSize = gi_fuenteTamano
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            End With
            With objGrid.RootTable.Columns("oafdoc")
                .Caption = "FECHA"
                .Width = 90
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.FontSize = gi_fuenteTamano
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            End With

            With objGrid.RootTable.Columns("oahora")
                .Caption = "HORA"
                .Width = 80
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.FontSize = gi_fuenteTamano
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            End With
            With objGrid.RootTable.Columns("oaest")
                .Visible = False
            End With
            With objGrid.RootTable.Columns("oaest2")
                .Caption = "ESTADO"
                .Width = 100
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.FontSize = gi_fuenteTamano
            End With

            With objGrid.RootTable.Columns("diasTrans")
                .Caption = "Dias Trancurridos"
                .Width = 100
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.FontSize = gi_fuenteTamano
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                .Visible = False
            End With

            With objGrid.RootTable.Columns("oaobs")
                .Visible = False
            End With

            With objGrid.RootTable.Columns("oaobs2")
                .Visible = False
            End With

            With objGrid.RootTable.Columns("reclamo")
                .Visible = False
            End With

            With objGrid.RootTable.Columns("oapg")
                .Visible = False
            End With
            'Habilitar Filtradores
            With objGrid
                '.DefaultFilterRowComparison = FilterConditionOperator.Contains
                '.FilterMode = FilterMode.Automatic
                '.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
                .GroupByBoxVisible = False
                .VisualStyle = VisualStyle.Office2007
            End With
        End If

    End Sub

    
#End Region

    Private Sub JGr_Reclamos_KeyDown(sender As Object, e As KeyEventArgs) Handles JGr_Reclamos.KeyDown
        If e.KeyData = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub JGr_Reclamos_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_Reclamos.EditingCell
        e.Cancel = True
    End Sub

    Private Sub JGr_Reclamos_MouseHover(sender As Object, e As EventArgs) Handles JGr_Reclamos.MouseHover

    End Sub


End Class