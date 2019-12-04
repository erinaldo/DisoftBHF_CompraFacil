
Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.Controls
Public Class F0_Categoria


#Region "Variables Locales"
    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim stRutaImagenes As String = RutaGlobal + "\Imagenes\Imagenes Categoria\"
    Dim RutaTemporal As String = "C:\Temporal\"
    Dim Modificado As Boolean = False
    Dim nameImg As String = "Default.jpg"
    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem
    Dim vlImagen As CImagen = Nothing
    Public Limpiar As Boolean = False  'Bandera para indicar si limpiar todos los datos o mantener datos ya registrados
#End Region

#Region "METODOS PRIVADOS"

    Private Sub _prIniciarTodo()
        Me.Text = "CATEGORIAS"
        '' L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        ''L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        Me.WindowState = FormWindowState.Maximized

        _prInhabiliitar()
        _prCargarVenta()
        _prAsignarPermisos()

        If (gi_ftp = 1) Then
            P_prDescargarFotosFTP(CType(grBuscador.DataSource, DataTable), "caimg", StRutaImagenes)
        End If

        If (grBuscador.RowCount > 0) Then
            _prMostrarRegistro(0)
        End If

        Dim blah As New Bitmap(New Bitmap(My.Resources.producto), 20, 20)
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico

    End Sub
    Private Sub _prCargarVenta()
        Dim dt As New DataTable
        dt = L_prGeneralCategoria()
        grBuscador.DataSource = dt
        grBuscador.RetrieveStructure()
        grBuscador.AlternatingColors = True

        'a.canumi ,a.canombre ,a.cadesc ,a.caimg ,a.cafact,a.cahact,a.cauact
        With grBuscador.RootTable.Columns("canumi")
            .Width = 100
            .Caption = "CODIGO"
            .Visible = True

        End With
        With grBuscador.RootTable.Columns("canombre")
            .Width = 300
            .Caption = "NOMBRE CATEGORIA"
            .Visible = True
        End With


        With grBuscador.RootTable.Columns("cadesc")
            .Width = 350
            .Visible = True
            .Caption = "DESCRIPCION"
        End With
        With grBuscador.RootTable.Columns("caimg")
            .Width = 150
            .Visible = False
        End With
        With grBuscador.RootTable.Columns("caest")
            .Width = 150
            .Visible = False
        End With

        With grBuscador.RootTable.Columns("cafact")
            .Width = 120
            .Visible = True
            .Caption = "FECHA"
            .FormatString = "dd/MM/yyyy"
        End With


        With grBuscador.RootTable.Columns("cahact")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With grBuscador.RootTable.Columns("cauact")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With

        With grBuscador
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With

    End Sub
    Public Function _fnAccesible()
        Return tbnombre.ReadOnly = False
    End Function
    Private Sub _prInhabiliitar()
        tbcodigo.ReadOnly = True
        tbnombre.ReadOnly = True
        tbobservacion.ReadOnly = True
        cbagua.Enabled = False
        cbme.Enabled = False
        cbninguna.Enabled = False
        BtAdicionar.Visible = False

        ''''''''''
        MBtModificar.Enabled = True
        MBtGrabar.Enabled = False
        MBtNuevo.Enabled = True
        MBtEliminar.Enabled = True
        grBuscador.Enabled = True


    End Sub
    Private Sub _prhabilitar()
        tbnombre.ReadOnly = False
        tbobservacion.ReadOnly = False
        BtAdicionar.Visible = True
        MBtGrabar.Enabled = True
        grBuscador.Enabled = False
        _prCrearCarpetaImagenes()
        _prCrearCarpetaTemporal()

        cbagua.Enabled = True
        cbme.Enabled = True
        cbninguna.Enabled = True
    End Sub
    Public Sub _prFiltrar()
        'cargo el buscador
        Dim _Mpos As Integer
        _prCargarVenta()
        If grBuscador.RowCount > 0 Then
            _Mpos = 0
            grBuscador.Row = _Mpos
        Else
            _Limpiar()
            MLbPaginacion.Text = "0/0"
        End If
    End Sub
    Private Sub _Limpiar()
        tbcodigo.Clear()
        tbnombre.Clear()
        tbobservacion.Clear()

        pbImage.Image = My.Resources.pantalla
        cbninguna.Checked = True
    End Sub
    Public Sub _prColocarEstado(estado As Integer)
        If (estado = 0) Then
            cbninguna.Checked = True

        End If
        If (estado = 1) Then
            cbagua.Checked = True

        End If
        If (estado = 2) Then
            cbme.Checked = True

        End If
    End Sub

    Public Sub _prMostrarRegistro(_N As Integer)
        'a.canumi ,a.canombre ,a.cadesc ,a.caimg ,a.cafact,a.cahact,a.cauact
        With grBuscador
            tbcodigo.Text = .GetValue("canumi")
            tbnombre.Text = .GetValue("canombre")
            tbobservacion.Text = .GetValue("cadesc")

            MLblFecha.Text = CType(.GetValue("cafact"), Date).ToString("dd/MM/yyyy")
            MLblHora.Text = .GetValue("cahact").ToString
            MLblUsuario.Text = .GetValue("cauact").ToString
            Dim caest As Object = .GetValue("caest")
            _prColocarEstado(IIf(IsDBNull(caest), 0, caest))
        End With

        Dim name As String = grBuscador.GetValue("caimg")
        Dim ruta As String = stRutaImagenes + name + ".jpg"
        If name.Equals("Default.jpg") Or Not File.Exists(ruta) Then

            Dim im As New Bitmap(My.Resources.pantalla)
            pbImage.Image = im
        Else
            If (File.Exists(stRutaImagenes + name + ".jpg")) Then
                Dim Bin As New MemoryStream
                Dim im As New Bitmap(New Bitmap(stRutaImagenes + name + ".jpg"))
                im.Save(Bin, System.Drawing.Imaging.ImageFormat.Jpeg)
                pbImage.SizeMode = PictureBoxSizeMode.StretchImage
                pbImage.Image = Image.FromStream(Bin)
                Bin.Dispose()

            End If
        End If
        MLbPaginacion.Text = Str(grBuscador.Row + 1) + "/" + grBuscador.RowCount.ToString

    End Sub

    Private Sub _prAsignarPermisos()

        Dim dtRolUsu() As DataRow = L_prRolDetalleGeneral(gi_userRol).Select("yaprog='" + _nameButton + "'")

        Dim show As Boolean = dtRolUsu(0).Item("ycshow")
        Dim add As Boolean = dtRolUsu(0).Item("ycadd")
        Dim modif As Boolean = dtRolUsu(0).Item("ycmod")
        Dim del As Boolean = dtRolUsu(0).Item("ycdel")

        If add = False Then
            MBtNuevo.Visible = False
        End If
        If modif = False Then
            MBtModificar.Visible = False
        End If
        If del = False Then
            MBtEliminar.Visible = False
        End If
    End Sub
    Private Sub _prCrearCarpetaTemporal()

        If System.IO.Directory.Exists(RutaTemporal) = False Then
            System.IO.Directory.CreateDirectory(RutaTemporal)
        Else
            Try
                My.Computer.FileSystem.DeleteDirectory(RutaTemporal, FileIO.DeleteDirectoryOption.DeleteAllContents)
                My.Computer.FileSystem.CreateDirectory(RutaTemporal)


            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Sub _prCrearCarpetaImagenes()
        Dim rutaDestino As String = stRutaImagenes

        If System.IO.Directory.Exists(stRutaImagenes) = False Then
            If System.IO.Directory.Exists(RutaGlobal + "\Imagenes") = False Then
                System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes")
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes Categoria")
                End If
            Else
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes Categoria")

                End If
            End If
        End If
    End Sub

    Private Sub _fnMoverImagenRuta(Folder As String, name As String)
        'copio la imagen en la carpeta del sistema
        If (Not name.Equals("Default.jpg") And File.Exists(RutaTemporal + name)) Then

            Dim img As New Bitmap(New Bitmap(RutaTemporal + name), 200, 300)

            pbImage.Image.Dispose()
            pbImage.Image = Nothing
            Try
                My.Computer.FileSystem.CopyFile(RutaTemporal + name,
     Folder + name, overwrite:=True)

            Catch ex As System.IO.IOException


            End Try



        End If
    End Sub

    Private Sub P_prGuardarImagen(Folder As String, name As String)
        Dim rutaDestino As String = Folder

        Dim rutaOrigen As String
        Try
            rutaOrigen = vlImagen.getImagen()
            'Pb1FotoSocio.Image = Nothing
        Catch ex As Exception

        End Try

        If (Not name.Equals("Default.jpg") And File.Exists(rutaOrigen)) Then
            Dim finalImg As New Bitmap(pbImage.Image, 300, 200)

            Try
                If (gi_ftp = 1) Then
                    Try
                        My.Computer.Network.UploadFile(rutaOrigen,
                                                       "ftp://" + gs_ftpIp + "/Disoft_Doc/Imagenes/Imagenes%20Categoria/" + name + ".jpg",
                                                       gs_ftpUsuario,
                                                       gs_ftpPass)
                    Catch ex As Exception
                        MsgBox("Error al conectarse al servidor FTP, Form Categorias: " + ex.Message)
                    End Try
                Else
                    finalImg.Save(rutaDestino + name + ".jpg")
                End If

            Catch ex As System.IO.IOException

            End Try
        End If
        'FileCopy(rutaOrigen, rutaDestino + vlImagen.nombre + ".jpg")
    End Sub

    Private Sub BtAdicionar_Click(sender As Object, e As EventArgs) Handles BtAdicionar.Click
        '''  _fnCopiarImagenRutaDefinida()

        P_prCargarImagen(pbImage)
        MBtGrabar.Focus()
    End Sub

    Public Function _fnActionNuevo() As Boolean
        Return tbcodigo.Text.ToString = String.Empty

    End Function



    Private Sub P_prCargarImagen(pbimg As PictureBox)
        OfdProducto.InitialDirectory = "C:\Users\" + Environment.UserName + "\Pictures"
        OfdProducto.Filter = "Imagen|*.jpg;*.jpeg;*.png;*.bmp"
        OfdProducto.FilterIndex = 1
        If (OfdProducto.ShowDialog() = DialogResult.OK) Then
            vlImagen = New CImagen(OfdProducto.SafeFileName, OfdProducto.FileName, 0)
            pbimg.SizeMode = PictureBoxSizeMode.StretchImage
            Dim mayor As Integer
            mayor = grBuscador.GetTotal(grBuscador.RootTable.Columns("canumi"), AggregateFunction.Max)
            nameImg = P_fnObtenerID()
            pbimg.Load(vlImagen.getImagen())
            Modificado = True
        End If
    End Sub

    Private Function P_fnObtenerID() As String
        Dim res As String = ""
        res = res + Now.Hour.ToString("00") + Now.Minute.ToString("00") + Now.Second.ToString("00") + "_" _
            + Now.Day.ToString("00") + Now.Month.ToString("00") + Now.Year.ToString("0000")
        Return res
    End Function
    Private Function _fnCopiarImagenRutaDefinida() As String
        'copio la imagen en la carpeta del sistema

        Dim file As New OpenFileDialog()
        file.Filter = "Ficheros JPG o JPEG o PNG|*.jpg;*.jpeg;*.png" &
                      "|Ficheros GIF|*.gif" &
                      "|Ficheros BMP|*.bmp" &
                      "|Ficheros PNG|*.png" &
                      "|Ficheros TIFF|*.tif"
        If file.ShowDialog() = DialogResult.OK Then
            Dim ruta As String = file.FileName


            If file.CheckFileExists = True Then
                Dim img As New Bitmap(New Bitmap(ruta), 200, 300)
                Dim imgM As New Bitmap(New Bitmap(ruta), 200, 300)
                Dim img2 As New Bitmap(img)
                Dim Bin As New MemoryStream
                imgM.Save(Bin, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim a As Object = file.GetType.ToString
                If (_fnActionNuevo()) Then

                    Dim mayor As Integer
                    mayor = grBuscador.GetTotal(grBuscador.RootTable.Columns("canumi"), AggregateFunction.Max)
                    nameImg = "Imagen_" + Str(mayor + 1).Trim + ".jpg"
                    pbImage.SizeMode = PictureBoxSizeMode.StretchImage
                    pbImage.Image = Image.FromStream(Bin)

                    img2.Save(RutaTemporal + nameImg, System.Drawing.Imaging.ImageFormat.Jpeg)
                    img2.Dispose()
                    img.Dispose()
                    imgM.Dispose()

                Else

                    nameImg = "Imagen_" + Str(tbcodigo.Text).Trim + ".jpg"


                    pbImage.Image = Image.FromStream(Bin)
                    img2.Save(RutaTemporal + nameImg, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Modificado = True
                    img2.Dispose()
                    img.Dispose()
                    imgM.Dispose()
                End If
            End If

            Return nameImg
        End If

        Return "default.jpg"
    End Function

    Private Sub MBtNuevo_Click(sender As Object, e As EventArgs) Handles MBtNuevo.Click
        _Limpiar()
        _prhabilitar()

        MBtNuevo.Enabled = False
        MBtModificar.Enabled = False
        MBtEliminar.Enabled = False
        MBtGrabar.Enabled = True
        tbnombre.Select()

        MBtSalir.Text = "CANCELAR"
    End Sub

    Private Sub MBtModificar_Click(sender As Object, e As EventArgs) Handles MBtModificar.Click
        _prhabilitar()
        MBtNuevo.Enabled = False
        MBtModificar.Enabled = False
        MBtEliminar.Enabled = False
        MBtGrabar.Enabled = True

        tbnombre.Select()
        MBtSalir.Text = "CANCELAR"
    End Sub

    Private Sub MBtEliminar_Click(sender As Object, e As EventArgs) Handles MBtEliminar.Click
        If (grBuscador.RowCount > 0) Then
            Dim ef = New Efecto

            ef.tipo = 2
            ef.Context = "¿esta seguro de eliminar el registro?".ToUpper
            ef.Header = "mensaje principal".ToUpper
            ef.ShowDialog()
            Dim bandera As Boolean = False
            bandera = ef.band
            If (bandera = True) Then
                Dim mensajeError As String = ""
                Dim res As Boolean = L_fnCategoriaEliminar(tbcodigo.Text)
                If res Then


                    Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)

                    ToastNotification.Show(Me, "Código de Categoria ".ToUpper + tbcodigo.Text + " eliminado con Exito.".ToUpper,
                                              img, 2000,
                                              eToastGlowColor.Green,
                                              eToastPosition.TopCenter)

                    _prFiltrar()

                Else
                    Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                    ToastNotification.Show(Me, "EL REGISTRO NO PUDO SER ELIMINADO", img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                End If
            End If
        End If

    End Sub
    Public Function _ValidarCampos() As Boolean
        If (tbnombre.Text.ToString.Length <= 0) Then
            Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
            ToastNotification.Show(Me, "Por Favor Inserte un Nombre".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            tbnombre.Select()
            Return False

        End If
        If (tbobservacion.Text.ToString.Length <= 0) Then
            Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
            ToastNotification.Show(Me, "Por Favor Inserte una descripcion".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            tbobservacion.Select()
            Return False

        End If

        Return True
    End Function
    Private Sub MBtGrabar_Click(sender As Object, e As EventArgs) Handles MBtGrabar.Click
        If _ValidarCampos() = False Then
            Exit Sub


        End If
        If (tbcodigo.Text = String.Empty) Then
            _GuardarNuevo()
        Else
            If (tbcodigo.Text <> String.Empty) Then
                _prGuardarModificado()
            End If
        End If
    End Sub
    Public Sub _prGuardarModificado()

        'ByRef _olnumi As String, _olnumichof As String, _olnumiconci As Integer, _olfecha As String, _dt As DataTable
        Dim numi As String = ""
        Dim nameImage As String = grBuscador.GetValue("caimg")
        Dim Res As Boolean
        If (Modificado = False) Then
            Res = L_prCategoriaModificar(tbcodigo.Text, tbnombre.Text, tbobservacion.Text, nameImage, _fnObtenerEstado())
        Else
            Res = L_prCategoriaModificar(tbcodigo.Text, tbnombre.Text, tbobservacion.Text, nameImg, _fnObtenerEstado())
        End If

        If res Then
            If (Modificado = True) Then

                P_prGuardarImagen(stRutaImagenes, nameImg)
                If (gi_ftp = 1) Then
                    P_prDescargarFotoFTP(nameImg + ".jpg")
                    'P_prDescargarFotosFTP(DtBusqueda, "nimg", StRutaImagenes)
                End If
                '' _fnMoverImagenRuta(stRutaImagenes, nameImg)
                Modificado = False
            End If
            nameImg = "Default.jpg"
            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Caja ".ToUpper + tbcodigo.Text + " Grabado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter
                                      )

            _prCargarVenta()
            _prInhabiliitar()

        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "La Compra no pudo ser insertado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

        End If

    End Sub

    Public Function _fnObtenerEstado() As Integer
        If (cbninguna.Checked) Then
            Return 0
        End If
        If (cbagua.Checked) Then
            Return 1
        End If
        If (cbme.Checked) Then
            Return 2
        End If
        Return 0
    End Function
    Public Sub _GuardarNuevo()

        'ByRef _olnumi As String, _olnumichof As String, _olnumiconci As Integer, _olfecha As String, _dt As DataTable
        Dim numi As String = ""

        Dim res As Boolean = L_prCategoriaGrabar(numi, tbnombre.Text, tbobservacion.Text, nameImg, _fnObtenerEstado())

        If res Then
            Modificado = False
            '' _fnMoverImagenRuta(stRutaImagenes, nameImg)
            P_prGuardarImagen(stRutaImagenes, nameImg)
            If (gi_ftp = 1) Then
                P_prDescargarFotoFTP(nameImg + ".jpg")
                'P_prDescargarFotosFTP(DtBusqueda, "nimg", StRutaImagenes)
            End If
            nameImg = "Default.jpg"
            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Caja ".ToUpper + tbcodigo.Text + " Grabado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter
                                      )

            _prCargarVenta()
            _Limpiar()

        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "La Compra no pudo ser insertado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

        End If

    End Sub

    Private Sub F0_Categoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()

    End Sub
    Private Sub _prSalir()
        If MBtGrabar.Enabled = True Then
            _prInhabiliitar()
            If grBuscador.RowCount > 0 Then
                _prMostrarRegistro(0)
            End If
            MBtSalir.Text = "SALIR"
        Else
            Me.Close()
            _modulo.Select()
            _tab.Close()
        End If
    End Sub
    Private Sub MBtSalir_Click(sender As Object, e As EventArgs) Handles MBtSalir.Click
        _prSalir()
    End Sub

    Private Sub grBuscador_SelectionChanged(sender As Object, e As EventArgs) Handles grBuscador.SelectionChanged
        If (grBuscador.RowCount >= 0 And grBuscador.Row >= 0) Then

            _prMostrarRegistro(grBuscador.Row)
        End If
    End Sub

    Private Sub MBtSiguiente_Click(sender As Object, e As EventArgs) Handles MBtSiguiente.Click
        Dim _pos As Integer = grBuscador.Row
        If _pos < grBuscador.RowCount - 1 Then
            _pos = grBuscador.Row + 1
            '' _prMostrarRegistro(_pos)
            grBuscador.Row = _pos
        End If
    End Sub

    Private Sub MBtUltimo_Click(sender As Object, e As EventArgs) Handles MBtUltimo.Click
        Dim _pos As Integer = grBuscador.Row
        If grBuscador.RowCount > 0 Then
            _pos = grBuscador.RowCount - 1
            ''  _prMostrarRegistro(_pos)
            grBuscador.Row = _pos
        End If
    End Sub

    Private Sub MBtAnterior_Click(sender As Object, e As EventArgs) Handles MBtAnterior.Click
        Dim _MPos As Integer = grBuscador.Row
        If _MPos > 0 And grBuscador.RowCount > 0 Then
            _MPos = _MPos - 1
            ''  _prMostrarRegistro(_MPos)
            grBuscador.Row = _MPos
        End If
    End Sub
    Public Sub _PrimerRegistro()
        Dim _MPos As Integer
        If grBuscador.RowCount > 0 Then
            _MPos = 0
            ''   _prMostrarRegistro(_MPos)
            grBuscador.Row = _MPos
        End If
    End Sub
    Private Sub MBtPrimero_Click(sender As Object, e As EventArgs) Handles MBtPrimero.Click
        _PrimerRegistro()
    End Sub

#End Region

    Private Sub P_prDescargarFotosFTP(dt As DataTable, col As String, ruta As String)
        Try
            If (My.Computer.FileSystem.GetFiles(ruta).Count > 0) Then
                For Each fil As DataRow In dt.Rows
                    If (Not fil.Item(col).ToString = String.Empty And
                        Not My.Computer.FileSystem.FileExists(ruta + fil.Item(col).ToString) + ".jpg") Then
                        P_prDescargarFotoFTP(fil.Item(col).ToString + ".jpg")
                    End If
                Next
            Else
                For Each fil As DataRow In dt.Rows
                    If (Not fil.Item(col).ToString = String.Empty) Then
                        P_prDescargarFotoFTP(fil.Item(col).ToString + ".jpg")
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub P_prDescargarFotoFTP(nomImg As String)
        'Descargar el archivo al servido ftp
        Try
            My.Computer.Network.DownloadFile("ftp://" + gs_ftpIp + "/Disoft_Doc/Imagenes/Imagenes%20Categoria/" + nomImg,
                                             stRutaImagenes + nomImg,
                                             gs_ftpUsuario,
                                             gs_ftpPass)
        Catch ex As Exception
            'MsgBox("Error al conectarse al servidor FTP, Form Mis Manuales: " + ex.Message)
        End Try
    End Sub

End Class