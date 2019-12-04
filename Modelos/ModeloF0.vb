Public Class ModeloF0

    Private Sub ModeloHor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If (e.KeyChar = ChrW(Keys.Enter)) Then
            e.Handled = True
            P_Moverenfoque()
        End If
    End Sub

    Private Sub P_Moverenfoque()
        SendKeys.Send("{TAB}")
    End Sub

    Public Overridable Function P_Validar() As Boolean
        Return True
    End Function

    Private Sub ModeloF0_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class