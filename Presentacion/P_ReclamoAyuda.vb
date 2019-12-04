Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar

Public Class P_ReclamoAyuda


#Region "ATRIBUTOS PRIVADOS"

#End Region

#Region "METODOS PRIVADOS"

    Public Sub New(idPEdido As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.StartPosition = FormStartPosition.CenterParent

        _PCargarGridReclamos(idPEdido)
        'poner en el filtrador
        JGr_Reclamos.Focus()
        JGr_Reclamos.MoveTo(JGr_Reclamos.FilterRow)
        JGr_Reclamos.Col = 5

        GroupPanel1.Text = "R E C L A M O S      G R A B A D O S  :  ".ToUpper + idPEdido

    End Sub
    Private Sub _PCargarGridReclamos(idPedido As Integer)
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
            .Width = 100
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
        Dim fc, fc1 As GridEXFormatCondition
        fc = New GridEXFormatCondition(JGr_Reclamos.RootTable.Columns("oftip"), ConditionOperator.Equal, 1)
        fc.FormatStyle.BackColor = Color.LightGreen

        fc1 = New GridEXFormatCondition(JGr_Reclamos.RootTable.Columns("oftip"), ConditionOperator.Equal, 2)
        fc1.FormatStyle.BackColor = Color.LightBlue

        JGr_Reclamos.RootTable.FormatConditions.Add(fc)
        JGr_Reclamos.RootTable.FormatConditions.Add(fc1)


        'cargar los tooltip
        JGr_Reclamos.ContextMenuStrip = ContextMenuStrip1
        JGr_Reclamos.CellToolTip = CellToolTip.UseCellToolTipText

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

    Private Sub ContextMenuStrip1_Opened(sender As Object, e As EventArgs) Handles ContextMenuStrip1.Opened
        If JGr_Reclamos.Row >= 0 Then
            Texto1ToolStripMenuItem.Text = JGr_Reclamos.GetValue("ofobs")
        End If
    End Sub
End Class