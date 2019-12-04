Public Class CImagen

    Public nombre As String
    Public direccion As String
    Public tipo As Integer

    Public Sub New(nom As String, dir As String, ti As Integer)
        nombre = nom
        direccion = dir
        tipo = ti
    End Sub

    Public Function getImagen()
        Return direccion
    End Function

End Class
