Public Class ModeloR02


    Private Sub ModeloR02_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MTbUsuario.Text = MGlobal.gs_user
        MTbUsuario.ReadOnly = True
    End Sub

    Private Sub ModeloR02_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If (e.KeyChar = ChrW(Keys.Enter)) Then
            e.Handled = True
            M_prMoverenfoque()
        End If
    End Sub

    Private Sub MFlyoutUsuario_PrepareContent(sender As Object, e As EventArgs) Handles MFlyoutUsuario.PrepareContent
        If (sender Is MBubbleBarUsuario And MBtGenerar.Enabled = False) Then
            MFlyoutUsuario.BorderColor = Color.FromArgb(&HC0, 0, 0)
            MFlyoutUsuario.Content = MPnUsuario
        End If
    End Sub

    Private Sub M_prMoverenfoque()
        SendKeys.Send("{TAB}")
    End Sub

End Class