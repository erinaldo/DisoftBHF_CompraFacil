Imports Janus.Windows.GridEX
Public Class ModeloAyuda2
#Region "ATRIBUTOS"
    Public dtBuscador As DataTable
    Public nombreVista As String
    Public posX As Integer
    Public posY As Integer
    Public seleccionado As Boolean
    Public Columna As Integer = -1
    Public filaSelect As Janus.Windows.GridEX.GridEXRow
    Public validar As Boolean
    Public listEstrucGrilla As List(Of Celda)
    Public LabelTitulo As String
    Public NameColumna As String
#End Region

#Region "METODOS PRIVADOS"
    Public Sub New(ByVal x As Integer, y As Integer, dt1 As DataTable, titulo As String, listEst As List(Of Celda), LabelTit As String, _Columna As String)
        dtBuscador = dt1
        posX = x
        posY = y
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(posX, posY)
        GPPanelP.Text = titulo
        LabelTitulo = LabelTit
        lbtitulo.Text = LabelTit
        NameColumna = _Columna
        listEstrucGrilla = listEst

        seleccionado = False
        Columna = 1
        _PMCargarBuscador()
        'grJBuscador.Row = grJBuscador.FilterRow.RowIndex
        'grJBuscador.Col = 1

        tbtitulo.Focus()
    End Sub
    Public Sub _prSeleccionar()
        If (Columna >= 0) Then

            grJBuscador.MoveTo(0)
            grJBuscador.Col = Columna
        End If
    End Sub


    Private Sub _PMCargarBuscador()

        Dim anchoVentana As Integer = 0

        grJBuscador.DataSource = dtBuscador
        grJBuscador.RetrieveStructure()


        For i = 0 To dtBuscador.Columns.Count - 1
            With grJBuscador.RootTable.Columns(i)
                If listEstrucGrilla.Item(i).visible = True Then
                    .Caption = listEstrucGrilla.Item(i).titulo
                    .Width = listEstrucGrilla.Item(i).tamano
                    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                    .CellStyle.FontSize = 9

                    Dim col As DataColumn = dtBuscador.Columns(i)
                    Dim tipo As Type = col.DataType
                    If tipo.ToString = "System.Int32" Or tipo.ToString = "System.Decimal" Then
                        .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                    End If
                    If listEstrucGrilla.Item(i).formato = String.Empty Then
                        .FormatString = listEstrucGrilla.Item(i).formato
                    End If

                    anchoVentana = anchoVentana + listEstrucGrilla.Item(i).tamano
                Else
                    .Visible = False
                End If
            End With
        Next

        'Habilitar Filtradores
        With grJBuscador
            '.DefaultFilterRowComparison = FilterConditionOperator.BeginsWith
            '.FilterMode = FilterMode.Automatic
            '.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges

            'diseño de la grilla
            .GroupByBoxVisible = False
            .VisualStyle = VisualStyle.Office2007
        End With


        'adaptar el tamaño de la ventana
        Me.Width = anchoVentana + 50
        grJBuscador.MoveTo(0)
        grJBuscador.Col = Columna
        _prAplicarCondiccionJanusSinLote()
    End Sub

    Public Function _fnTienStock() As Boolean
        'ydrazonsocial
        Try
            Dim dt As DataTable = CType(grJBuscador.DataSource, DataTable)
            Dim a As String = IIf(IsDBNull(dt.Rows(0).Item("stock")), "", dt.Rows(0).Item("stock"))
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Public Sub _prAplicarCondiccionJanusSinLote()

        If (_fnTienStock()) Then
            Dim fc As GridEXFormatCondition
            fc = New GridEXFormatCondition(grJBuscador.RootTable.Columns("stock"), ConditionOperator.Equal, 0)
            'fc.FormatStyle.FontBold = TriState.True
            fc.FormatStyle.ForeColor = Color.Tan
            grJBuscador.RootTable.FormatConditions.Add(fc)
        End If

    End Sub
#End Region
    Private Sub ModeloAyuda2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If (e.KeyChar = ChrW(Keys.Escape)) Then
            e.Handled = True
            Me.Close()
        End If
    End Sub

    Private Sub grJBuscador_KeyDown(sender As Object, e As KeyEventArgs) Handles grJBuscador.KeyDown

        If e.KeyData = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyData = Keys.Enter Then
            filaSelect = grJBuscador.GetRow()
            seleccionado = True
            Me.Close()
        End If


    End Sub
    Public Function _fnEsClientes() As Boolean
        'ydrazonsocial
        Try
            Dim dt As DataTable = CType(grJBuscador.DataSource, DataTable)
            Dim a As String = IIf(IsDBNull(dt.Rows(0).Item("desc")), "", dt.Rows(0).Item("desc"))
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Private Sub tbtitulo_TextChanged(sender As Object, e As EventArgs) Handles tbtitulo.TextChanged
        Dim dt As DataTable = CType(grJBuscador.DataSource, DataTable)
        Dim NColumna As String = dt.Columns.Item("desc").ToString
        If (tbtitulo.Text.Trim <> String.Empty) Then

            If (_fnEsClientes()) Then
                Dim criterio As String = tbtitulo.Text.Trim
                grJBuscador.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grJBuscador.RootTable.Columns(NColumna), Janus.Windows.GridEX.ConditionOperator.BeginsWith, criterio))
            Else
                Dim criterio As String = tbtitulo.Text.Trim
                grJBuscador.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grJBuscador.RootTable.Columns(NColumna), Janus.Windows.GridEX.ConditionOperator.BeginsWith, criterio))
            End If

        Else
            grJBuscador.RootTable.RemoveFilter()


        End If
    End Sub



    Private Sub tbtitulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbtitulo.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If (e.KeyChar = ChrW(Keys.Escape)) Then
            e.Handled = True
            Me.Close()
        End If
    End Sub

    Private Sub tbtitulo_KeyDown(sender As Object, e As KeyEventArgs) Handles tbtitulo.KeyDown
        If e.KeyData = Keys.Escape Then
            Me.Close()
        End If
        If e.KeyData = Keys.Enter Then
            grJBuscador.Focus()

        End If
        If e.KeyData = Keys.Down Then
            grJBuscador.Focus()

        End If
    End Sub
End Class