Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar

Public Class P_HistorialAyuda


#Region "ATRIBUTOS PRIVADOS"

#End Region

#Region "METODOS PRIVADOS"

    Public Sub New(idPEdido As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.StartPosition = FormStartPosition.CenterParent

        _PCargarGridHistorial(idPEdido)

        GroupPanel1.Text = "h i s t o r i a l     d e l     p e d i d o  :  ".ToUpper + idPEdido
        'poner en el filtrador
        'JGr_Reclamos.Focus()
        'JGr_Reclamos.MoveTo(JGr_Reclamos.FilterRow)
        'JGr_Reclamos.Col = 5

    End Sub
    Private Sub _PCargarGridHistorial(idPedido As Integer)
        Dim dt As New DataTable
        dt = L_PedidoHistorial_General(-1, "ocnumi=" + idPedido.ToString, " order by ocfecha,ochora")

        JGr_Reclamos.DataSource = dt
        JGr_Reclamos.RetrieveStructure()

        'dar formato a las columnas
        With JGr_Reclamos.RootTable.Columns("ocnumi")
            .Visible = False
            .Caption = "Id"
            .Width = 40
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With
        With JGr_Reclamos.RootTable.Columns("ocest")
            .Visible = False
        End With
        With JGr_Reclamos.RootTable.Columns("ocest2")
            .Caption = "ESTADO"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With
        With JGr_Reclamos.RootTable.Columns("ocfecha")
            .Caption = "FECHA"
            .Width = 90
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With
        With JGr_Reclamos.RootTable.Columns("ochora")
            .Caption = "HORA"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With

        With JGr_Reclamos.RootTable.Columns("ocobs")
            .Caption = "USUARIO"
            .Width = 180
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With



        'Habilitar Filtradores
        With JGr_Reclamos
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            .VisualStyle = VisualStyle.Office2007
        End With

        ''poner color a la fila de acuerdo a la condicion 
        'Dim fc, fc1 As GridEXFormatCondition
        'fc = New GridEXFormatCondition(JGr_Reclamos.RootTable.Columns("oftip"), ConditionOperator.Equal, 1)
        'fc.FormatStyle.BackColor = Color.LightGreen

        'fc1 = New GridEXFormatCondition(JGr_Reclamos.RootTable.Columns("oftip"), ConditionOperator.Equal, 2)
        'fc1.FormatStyle.BackColor = Color.LightBlue

        'JGr_Reclamos.RootTable.FormatConditions.Add(fc)
        'JGr_Reclamos.RootTable.FormatConditions.Add(fc1)



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