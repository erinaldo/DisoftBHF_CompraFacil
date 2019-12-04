Imports System.IO
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.Editors.DateTimeAdv
Imports Logica.AccesoLogica

Public Class P_IntegradorFlextel

#Region "Atributos"

    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem

#End Region

#Region "Eventos"

    Private Sub P_IntegradorFlextel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        P_IniciarTodo()
    End Sub

    Private Sub btFachis_Click(sender As Object, e As EventArgs) Handles btFachis.Click
        P_GenerarFachis()
    End Sub

    Private Sub btStomov_Click(sender As Object, e As EventArgs) Handles btStomov.Click
        P_GenerarStomov()
    End Sub

#End Region

#Region "Metodos"

    Private Sub P_IniciarTodo()

        If (Not gb_ConexionAbierta) Then
            L_prAbrirConexion()
        End If

        Me.Text = "I N T E G R A D O R   F L E X T E L"
        Me.tbRutaSalida.ReadOnly = True
        Me.dtiFachisFechaIni.Value = Now.Date
        Me.dtiFachisFechaFin.Value = Now.Date
        Me.dtiStomovFechaIni.Value = Now.Date
        Me.dtiStomovFechaFin.Value = Now.Date

        Me.tbRutaSalida.Text = gs_CarpetaRaiz + "\Integracion-Flextel"

    End Sub

    Private Sub P_GenerarFachis()
        If (P_EscribirFachisTxt()) Then
            ToastNotification.Show(Me, "GENERACIÓN DE FACHIS EXITOSA..!!!",
                                       My.Resources.OK, 5 * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.BottomLeft)
        Else
            ToastNotification.Show(Me, "FALLO AL GENERAR DE FACHIS..!!!",
                                       My.Resources.WARNING, 5 * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.BottomLeft)
        End If
    End Sub

    Private Function P_EscribirFachisTxt() As Boolean
        If (P_Validar(dtiFachisFechaIni, dtiFachisFechaFin)) Then
            Try
                Dim ruta As String = tbRutaSalida.Text.Trim + "\Fachis\" + Now.Date.Day.ToString + "-" & Now.Date.Month.ToString + "-" + Now.Date.Year.ToString + "_" + Now.Hour.ToString + "-" + Now.Minute.ToString + "-" + Now.Second.ToString
                If (Not Directory.Exists(ruta)) Then
                    Directory.CreateDirectory(ruta)
                End If

                Dim stream As Stream
                Dim escritor As StreamWriter
                Dim archivo As String = ruta + "\fachis.txt"
                Dim linea As String = String.Empty
                Dim filadata = 0, columndata As Int32 = 0
                File.Delete(archivo)
                stream = File.OpenWrite(archivo)
                escritor = New StreamWriter(stream, System.Text.Encoding.ASCII)

                Dim dtMaster As DataTable = L_fnObtenerTabla("a.oanumi", "TO001 a", "a.oaest=3 and a.oafdoc>='" + dtiFachisFechaIni.Value.ToString("yyyy/MM/dd") + "' and a.oafdoc<='" + dtiFachisFechaFin.Value.ToString("yyyy/MM/dd") + "'")
                Dim dt As DataTable

                'Escribir fecha y hora
                linea = Now.Date.ToString("dd/MM/yyyy")
                escritor.WriteLine(linea)
                linea = String.Empty
                linea = Now.Hour.ToString("00") + ":" + Now.Minute.ToString("00") + ":" + Now.Second.ToString("00")
                escritor.WriteLine(linea)
                linea = String.Empty

                For Each filMaster As DataRow In dtMaster.Rows
                    dt = L_fnObtenerTabla("*", "TO001 a inner join TO0011 b on a.oanumi=b.obnumi and a.oaest=3 and oanumi=" + filMaster.Item("oanumi").ToString + " inner join TC004 c on a.oaccli=c.ccnumi", "1=1")

                    'Escribir Cabecera
                    linea = dt.Rows(0).Item("cccat").ToString '1
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = dt.Rows(0).Item("oanumi").ToString '2
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '3
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '4
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = CDate(dt.Rows(0).Item("oafdoc")).ToString("dd/MM/yyyy") '5
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = dt.Rows(0).Item("oanumi").ToString '6
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = dt.Rows(0).Item("ccnumi").ToString '7
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "" '8
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "" '9
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '10
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = dt.Rows(0).Item("oarepa").ToString '11
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '12
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '13
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = dt.Rows(0).Item("oazona").ToString '14
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = dt.Rows(0).Item("cccat").ToString '15
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '16
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "*" '17
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = dt.Compute("sum (obptot)", "1=1") '18
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '19
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '20
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '21
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '22
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '23
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '24
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '25
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = dt.Compute("sum (obptot)", "1=1") '26
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = dt.Compute("sum (obptot)", "1=1") '27
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "1" '28
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "1" '29
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "2" '30
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '31
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '32
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '33
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '34
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '35
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '36
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '37
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '38
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '39
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "1" '40
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "" '41
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "" '42
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    'Escribir Detalle
                    Dim index As Integer = 1
                    For Each fil As DataRow In dt.Rows
                        linea = dt.Rows(0).Item("cccat").ToString '1
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = dt.Rows(0).Item("oanumi").ToString '2
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "1" '3
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = index.ToString '4
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = CDate(dt.Rows(0).Item("oafdoc")).ToString("dd/MM/yyyy") '5
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '6
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = dt.Rows(0).Item("ccnumi").ToString '7
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "" '8
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "" '9
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '10
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = dt.Rows(0).Item("oarepa").ToString '11
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '12
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '13
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = dt.Rows(0).Item("oazona").ToString '14
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = dt.Rows(0).Item("cccat").ToString '15
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '16
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = dt.Rows(0).Item("obcprod").ToString '17
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = dt.Rows(0).Item("obpcant").ToString '18
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = dt.Rows(0).Item("obpbase").ToString '19
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = dt.Rows(0).Item("obptot").ToString '20
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = dt.Rows(0).Item("obpbase").ToString '21
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '22
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '23
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '24
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '25
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '26
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '27
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "1" '28
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "1" '29
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "2" '30
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '31
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '32
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '33
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '34
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '35
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '36
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '37
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '38
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '39
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '40
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "" '41
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "N" '42
                        escritor.WriteLine(linea)
                        linea = String.Empty
                    Next
                Next

                escritor.Close()
                Try
                    If (MessageBox.Show("DESEA ABRIR EL ARCHIVO?", "PREGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                        Process.Start(archivo)
                    End If
                    Return True
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return False
                End Try
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
            Return False
        End If
        Return False
    End Function

    Private Sub P_GenerarStomov()
        If (P_EscribirStomovTxt()) Then
            ToastNotification.Show(Me, "GENERACIÓN DE STOMOV EXITOSA..!!!",
                                       My.Resources.OK, 5 * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.BottomLeft)
        Else
            ToastNotification.Show(Me, "FALLO AL GENERAR DE STOMOV..!!!",
                                       My.Resources.WARNING, 5 * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.BottomLeft)
        End If
    End Sub

    Private Function P_EscribirStomovTxt() As Boolean
        If (P_Validar(dtiStomovFechaIni, dtiStomovFechaFin)) Then
            Try
                Dim ruta As String = tbRutaSalida.Text.Trim + "\Stomov\" + Now.Date.Day.ToString + "-" & Now.Date.Month.ToString + "-" + Now.Date.Year.ToString + "_" + Now.Hour.ToString + "-" + Now.Minute.ToString + "-" + Now.Second.ToString
                If (Not Directory.Exists(ruta)) Then
                    Directory.CreateDirectory(ruta)
                End If

                Dim stream As Stream
                Dim escritor As StreamWriter
                Dim archivo As String = ruta + "\stomov.txt"
                Dim linea As String = String.Empty
                Dim filadata = 0, columndata As Int32 = 0
                File.Delete(archivo)
                stream = File.OpenWrite(archivo)
                escritor = New StreamWriter(stream, System.Text.Encoding.ASCII)

                Dim dtMaster As DataTable = L_fnObtenerTabla("a.oanumi", "TO001 a", "a.oaest=3 and a.oafdoc>='" + dtiFachisFechaIni.Value.ToString("yyyy/MM/dd") + "' and a.oafdoc<='" + dtiFachisFechaFin.Value.ToString("yyyy/MM/dd") + "'")
                Dim dt As DataTable

                'Escribir fecha y hora
                linea = Now.Date.ToString("dd/MM/yyyy")
                escritor.WriteLine(linea)
                linea = String.Empty
                linea = Now.Hour.ToString("00") + ":" + Now.Minute.ToString("00") + ":" + Now.Second.ToString("00")
                escritor.WriteLine(linea)
                linea = String.Empty

                For Each filMaster As DataRow In dtMaster.Rows
                    dt = L_fnObtenerTabla("*", "TO001 a inner join TO0011 b on a.oanumi=b.obnumi and a.oaest=3 and oanumi=" + filMaster.Item("oanumi").ToString + " inner join TC004 c on a.oaccli=c.ccnumi", "1=1")

                    'Escribir Cabecera
                    linea = "1" '1
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = dt.Rows(0).Item("oanumi").ToString '2
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '3
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '4
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = CDate(dt.Rows(0).Item("oafdoc")).ToString("dd/MM/yyyy") '5
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = dt.Rows(0).Item("oanumi").ToString '6
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = dt.Rows(0).Item("ccnumi").ToString '7
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "" '8
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "" '9
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '10
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = dt.Rows(0).Item("oarepa").ToString '11
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '12
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '13
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = dt.Rows(0).Item("oazona").ToString '14
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = dt.Rows(0).Item("cccat").ToString '15
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "0" '16
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = "*" '17
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    linea = dt.Compute("sum (obptot)", "1=1") '18
                    escritor.WriteLine(linea)
                    linea = String.Empty

                    'Escribir Detalle
                    Dim index As Integer = 1
                    For Each fil As DataRow In dt.Rows
                        linea = dt.Rows(0).Item("cccat").ToString '1
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = dt.Rows(0).Item("oanumi").ToString '2
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "1" '3
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = index.ToString '4
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = CDate(dt.Rows(0).Item("oafdoc")).ToString("dd/MM/yyyy") '5
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '6
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = dt.Rows(0).Item("ccnumi").ToString '7
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "" '8
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "" '9
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '10
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = dt.Rows(0).Item("oarepa").ToString '11
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '12
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '13
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = dt.Rows(0).Item("oazona").ToString '14
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = dt.Rows(0).Item("cccat").ToString '15
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = "0" '16
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = dt.Rows(0).Item("obcprod").ToString '17
                        escritor.WriteLine(linea)
                        linea = String.Empty

                        linea = dt.Rows(0).Item("obpcant").ToString '18
                        escritor.WriteLine(linea)
                        linea = String.Empty
                    Next
                Next

                escritor.Close()
                Try
                    If (MessageBox.Show("DESEA ABRIR EL ARCHIVO?", "PREGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                        Process.Start(archivo)
                    End If
                    Return True
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return False
                End Try
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
            Return False
        End If
        Return False
    End Function

    Private Function P_Validar(FechaIni As DateTimeInput, FechaFin As DateTimeInput) As Boolean
        If (Not Directory.Exists(tbRutaSalida.Text.Trim)) Then
            Directory.CreateDirectory(tbRutaSalida.Text.Trim)
        End If
        If (FechaIni.Value > FechaFin.Value) Then
            Return False
        End If
        Return True
    End Function



#End Region

End Class