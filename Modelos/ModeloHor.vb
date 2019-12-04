Public Class ModeloHor
    Dim _Confir As Integer = 0

    Private Sub ModeloHor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BBtn_Grabar.Enabled = False
        Me.BBtn_Cancelar.TooltipText = "SALIR"
        Txt_NombreUsu.Text = MGlobal.gs_user
        Txt_NombreUsu.ReadOnly = True
    End Sub

    Private Sub BBtn_Nuevo_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Nuevo.Click
        Me.BBtn_Modificar.Enabled = False
        Me.BBtn_Eliminar.Enabled = False
        Me.BBtn_Grabar.Enabled = True

        Me.BBtn_Cancelar.TooltipText = "CANCELAR"

        BBtn_Inicio.Enabled = False
        BBtn_Anterior.Enabled = False
        BBtn_Siguiente.Enabled = False
        BBtn_Ultimo.Enabled = False
    End Sub

    Private Sub BBtn_Modificar_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Modificar.Click
        Me.BBtn_Nuevo.Enabled = False
        Me.BBtn_Eliminar.Enabled = False
        Me.BBtn_Grabar.Enabled = True

        Me.BBtn_Cancelar.TooltipText = "CANCELAR"

        'BBtn_Inicio.Enabled = False
        'BBtn_Anterior.Enabled = False
        'BBtn_Siguiente.Enabled = False
        'BBtn_Ultimo.Enabled = False
    End Sub

    Private Sub BBtn_Eliminar_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Eliminar.Click
        Me.BBtn_Nuevo.Enabled = True
        Me.BBtn_Modificar.Enabled = True
        Me.BBtn_Eliminar.Enabled = True
        Me.BBtn_Grabar.Enabled = True

        Me.BBtn_Cancelar.TooltipText = "CANCELAR"

        'BBtn_Inicio.Enabled = False
        'BBtn_Anterior.Enabled = False
        'BBtn_Siguiente.Enabled = False
        'BBtn_Ultimo.Enabled = False
    End Sub

    Private Sub BBtn_Grabar_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Grabar.Click

        If (Me.BBtn_Nuevo.Enabled) Then
            If (P_Validar()) Then
                If (Me._Confir = 0) Then
                    Me._Confir = 1
                    Me.BBtn_Grabar.Image = My.Resources.NUEVO2
                    Me.BBtn_Grabar.ImageLarge = My.Resources.NUEVO2
                    Me.BubbleBar1.Refresh()
                ElseIf (_Confir = 1) Then
                    Me._Confir = 0
                    Me.BBtn_Grabar.Image = My.Resources.GRABAR
                    Me.BBtn_Grabar.ImageLarge = My.Resources.GRABAR
                    Me.BubbleBar1.Refresh()
                End If
            End If
        ElseIf (Me.BBtn_Modificar.Enabled) Then
            If (P_Validar()) Then
                If (Me._Confir = 0) Then
                    Me._Confir = 1
                    Me.BBtn_Grabar.Image = My.Resources.EDITAR2
                    Me.BBtn_Grabar.ImageLarge = My.Resources.EDITAR2
                    Me.BubbleBar1.Refresh()
                ElseIf (Me._Confir = 1) Then
                    Me._Confir = 0
                    Me.BBtn_Grabar.Image = My.Resources.GRABAR
                    Me.BBtn_Grabar.ImageLarge = My.Resources.GRABAR
                    Me.BubbleBar1.Refresh()
                End If
            End If
        Else
            If (P_Validar()) Then
                If (_Confir = 0) Then
                    _Confir = 1
                    BBtn_Grabar.Image = My.Resources.ELIMINAR2
                    BBtn_Grabar.ImageLarge = My.Resources.ELIMINAR2
                    BubbleBar1.Refresh()
                ElseIf (_Confir = 1) Then
                    _Confir = 0
                    BBtn_Grabar.Image = My.Resources.GRABAR
                    BBtn_Grabar.ImageLarge = My.Resources.GRABAR
                    BubbleBar1.Refresh()
                    P_Cancelar()
                End If
            End If

        End If
    End Sub

    Private Sub BBtn_Cancelar_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles BBtn_Cancelar.Click
        If (Not BBtn_Grabar.Enabled) Then
            Me.Dispose()
        Else
            P_Cancelar()
        End If

    End Sub

    Private Sub ModeloHor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If (e.KeyChar = ChrW(Keys.Enter)) Then
            e.Handled = True
            P_Moverenfoque()
        End If
    End Sub

    Private Sub P_Moverenfoque()
        'SendKeys.Send("{TAB}")
    End Sub

    Private Sub ModeloHor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If (((BBtn_Nuevo.Enabled And Not BBtn_Modificar.Enabled And Not BBtn_Eliminar.Enabled) Or
            (Not BBtn_Nuevo.Enabled And BBtn_Modificar.Enabled And Not BBtn_Eliminar.Enabled) Or
            (Not BBtn_Nuevo.Enabled And Not BBtn_Modificar.Enabled And Not BBtn_Eliminar.Enabled))) Then
            If (MessageBox.Show("ESTA SEGURO DE SALIR SIN GUARDAR?", "AVERTENCIA", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK) Then
                Me.Dispose()
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Public Overridable Function P_Validar() As Boolean
        Return True
    End Function

    Private Sub P_Cancelar()
        Me.BBtn_Nuevo.Enabled = True
        Me.BBtn_Modificar.Enabled = True
        Me.BBtn_Eliminar.Enabled = True
        Me.BBtn_Grabar.Image = My.Resources.GRABAR
        Me.BBtn_Grabar.ImageLarge = My.Resources.GRABAR
        Me.BubbleBar1.Refresh()
        Me._Confir = 0
        Me.BBtn_Grabar.Enabled = False

        Me.BBtn_Cancelar.TooltipText = "SALIR"

        BBtn_Inicio.Enabled = True
        BBtn_Anterior.Enabled = True
        BBtn_Siguiente.Enabled = True
        BBtn_Ultimo.Enabled = True
    End Sub

End Class