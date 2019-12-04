Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX.EditControls

Module P_Global

#Region "Configuracion del sistema"
    Public gs_llaveDinases As String = "carlosdinases123"
    Public gb_mostrarMapa As Boolean = True
    Public gi_userFuente As Integer = 8
    Public gs_user As String = "DEFAULT"
    Public gi_userNumi As Integer = 0
    Public gi_userRol As Integer = 0
    Public gi_userSuc As Integer = 0

    Public gi_fuenteTamano As Integer = 8

    Public gi_mapa As Byte = 0 '0=no admite visualización de mapas, 1=si admite visualización de mapas - 
    Public gi_notiPed As Byte = 0 '0=no admite envio de notificaciones, 1=si admite envio de notificaciones - 
    Public gi_vcre As Byte = 0 '0=no admite ventas al credito, 1=si admite ventas al credito - Programa Ventas 
    Public gi_vdes As Byte = 0 '0=no admite ventas con descuento, 1=si admite ventas con descuento - 
    Public gi_vccli As Byte = 0 '0=no admite visualización de codigo cliente, 1=si admite visualización de codigo cliente - cliente, pedido, control de pedido, venta, ubicación de cliente
    Public gi_vacu As Byte = 0 '0=no admite visualización de acuerdo, 1=si admite visualización de acuerdo
    Public gi_ftp As Byte = 0 '0=no graba en el servidor ftp, 1=graba en el servidor ftp
    Public gi_vcre2 As Byte = 0 '0=no admite credito, 1=si admite credito - Programa Caja
    Public gi_mprec As Byte = 0 '0=modo precio por categoria de cliente, 1=modo de precio de categoria por cada producto'
    Public gi_adev As Byte = 0 '0=no advierte en la devolucion, 1=advierte en la devolucion
    Public gb_despacho As Boolean = False 'true=cargar el despacho en salida de producto, false=no cargar el despacho en salida de producto
#End Region

    Public gs_Ip As String = "localhost"
    Public gs_UsuarioSql As String = "sa"
    Public gs_ClaveSql As String = "123"
    Public gs_NombreBD As String = "BDDistBHF"
    Public gs_CarpetaRaiz As String = "C:\BD"

    'Datos para conexion FTP
    Public gs_ftpIp As String = "localhost"
    Public gs_ftpUsuario As String = "usuarioftp"
    Public gs_ftpPass As String = "123"

    Public gs_RutaImagenes As String = gs_CarpetaRaiz + "\Imagenes"
    Public gs_RutaArchivos As String = "C:\Doc"
    Public gs_RutaManuales As String = "C:\BD"

    Public gb_ConexionAbierta As Boolean = False

    Public gt_Cliente As DataTable
    Public gb_DtClienteEstado As Boolean = False

    Public gt_Productos As DataTable

#Region "Variables"

    Public gs_separadorDecimal As Char = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
    Public Visualizador As Visualizador

#End Region

#Region "Librerias"
    Public gi_LibCiudad As Integer = 4
    Public gi_LibProv As Integer = 3
    Public gi_LibZona As Integer = 2
    Public gi_LibMovimientoInv As Integer = 12
    Public gi_CategoriaEquipo As Integer = 1
    Public gi_TipoMovimiento As Integer = 10
    Public gi_ConceptoReclamo As Integer = 13

    Public gi_LibSistema As Integer = 11
    Public gi_LibSISModulo As Integer = 1

#End Region

#Region "Clientes"

    Public G_CodProducto As String = ""
    Public G_NroLinea As String = ""

#End Region

#Region "Metodos"

    'Tipos de Modos
    '1 Valida que sea solo Numeros
    '2 Valida que sea solo Letras
    '3 Valida que sea Numeros y el Separador de Decimales
    '4 Valida que sea Numeros y el guion (-)
    Public Sub g_prValidarTextBox(ByVal modo As Byte, ByRef ee As KeyPressEventArgs, Optional sender As Object = Nothing)
        Select Case modo
            Case 1
                If (Char.IsNumber(ee.KeyChar)) Then
                    ee.Handled = False
                ElseIf (ChrW(Keys.Back) = (ee.KeyChar)) Then
                    ee.Handled = False
                ElseIf (ChrW(Keys.Delete) = (ee.KeyChar)) Then
                    ee.Handled = False
                Else
                    ee.Handled = True
                End If
            Case 2
                If (Char.IsLetter(ee.KeyChar)) Then
                    ee.Handled = False
                ElseIf (ChrW(Keys.Back) = (ee.KeyChar)) Then
                    ee.Handled = False
                ElseIf (ChrW(Keys.Delete) = (ee.KeyChar)) Then
                    ee.Handled = False
                Else
                    ee.Handled = True
                End If
            Case 3
                If (Char.IsNumber(ee.KeyChar)) Then
                    ee.Handled = False
                ElseIf (ee.KeyChar.Equals(gs_separadorDecimal)) Then
                    Dim tb As TextBox = CType(sender, TextBox)
                    If (tb.Text.Contains(gs_separadorDecimal)) Then
                        ee.Handled = True
                    Else
                        ee.Handled = False
                    End If
                ElseIf (ChrW(Keys.Back) = (ee.KeyChar)) Then
                    ee.Handled = False
                ElseIf (ChrW(Keys.Delete) = (ee.KeyChar)) Then
                    ee.Handled = False
                Else
                    ee.Handled = True
                End If
            Case 4
                If (Char.IsNumber(ee.KeyChar)) Then
                    ee.Handled = False
                ElseIf (ee.KeyChar.Equals(Convert.ToChar("-"))) Then
                    ee.Handled = False
                ElseIf (Char.IsControl(ee.KeyChar)) Then
                    ee.Handled = False
                Else
                    ee.Handled = True
                End If
        End Select
    End Sub

    Public Sub G_ActStock(_Tabla As DataTable, _Signo As Boolean) 'True=Signo (+), False=Signo(-)
        For Each _fila As DataRow In _Tabla.Rows
            Dim codC As String = _fila.Item("codC").ToString
            Dim mon As String = IIf(_Signo, "", "-") + _fila.Item("mon").ToString
            L_Actualizar_Saldo(codC, mon)
        Next
    End Sub

    Public Sub G_ActStock(_Tabla As DataTable, _Signo As Boolean, _almacen As String) 'True=Signo (+), False=Signo(-)
        For Each _fila As DataRow In _Tabla.Rows
            Dim codP As String = _fila.Item("codP").ToString
            Dim cant As String = IIf(_Signo, "", "-") + _fila.Item("can").ToString
            L_Actualizar_StockMovimiento(codP, cant, _almacen)
        Next
    End Sub

    Public Sub g_prArmarCombo(cbj As MultiColumnCombo, dtCombo As DataTable,
                              Optional anchoCodigo As Integer = 60, Optional anchoDesc As Integer = 200,
                              Optional nombreCodigo As String = "Código", Optional nombreDescripción As String = "Nombre")
        With cbj.DropDownList
            .Columns.Clear()

            .Columns.Add(dtCombo.Columns("cod").ToString).Width = anchoCodigo
            '.Columns(0).Key =dtCombo.Columns(0).Caption
            .Columns(0).Caption = nombreCodigo
            .Columns(0).Visible = True

            .Columns.Add(dtCombo.Columns("desc").ToString).Width = anchoDesc
            '.Columns(1).Key =dtCombo.Columns(1).Caption
            .Columns(1).Caption = nombreDescripción
            .Columns(1).Visible = True

            .ValueMember = dtCombo.Columns("cod").ToString
            .DisplayMember = dtCombo.Columns("desc").ToString
            .DataSource = dtCombo
            .Refresh()
        End With
    End Sub

#End Region

#Region "Ventanas"

    Public Function _fnCrearPanelVentanas(frm As Form) As Panel
        Dim panel As New Panel()
        panel.Name = "panelA"
        panel.Dock = DockStyle.Fill
        panel.BackColor = Color.White
        frm.TopLevel = False
        frm.Location = New Point(0, 0)
        frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frm.Dock = panel.Dock
        panel.Controls.Add(frm)
        Return panel

    End Function
#End Region

#Region "Google Drive"

    Private Function g_fnAutenticar() As Google.Apis.Auth.OAuth2.UserCredential
        Dim Credenciais As Google.Apis.Auth.OAuth2.UserCredential

        Using Stream = New System.IO.FileStream("client_id.json", System.IO.FileMode.Open, System.IO.FileAccess.Read)
            Dim DiretorioAtual = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
            Dim DiretorioCredenciais = System.IO.Path.Combine(DiretorioAtual, "credential")

            Credenciais = Google.Apis.Auth.OAuth2.GoogleWebAuthorizationBroker.AuthorizeAsync(
                Google.Apis.Auth.OAuth2.GoogleClientSecrets.Load(Stream).Secrets,
                New String() {Google.Apis.Drive.v3.DriveService.Scope.Drive}, ' New String() {Google.Apis.Drive.v3.DriveService.Scope.DriveReadonly}
                "biopetrolaguasok@gmail.com",
                System.Threading.CancellationToken.None,
                New Google.Apis.Util.Store.FileDataStore(DiretorioCredenciais, True)).Result
        End Using

        Return Credenciais
    End Function

    Private Function g_fnAbrirServicio(credentials As Google.Apis.Auth.OAuth2.UserCredential) As Google.Apis.Drive.v3.DriveService
        Return New Google.Apis.Drive.v3.DriveService(New Google.Apis.Services.BaseClientService.Initializer() With {
            .HttpClientInitializer = credentials
        })
    End Function

    Private Function g_fnExisteArchivo(Service As Google.Apis.Drive.v3.DriveService, nameFolder As String, searchIn As String) As String
        Dim idFile As String = String.Empty
        Dim Request = Service.Files.List()

        Request.Fields = "nextPageToken, files(id, name)"
        Request.Q = "'" + searchIn + "' in parents"
        Request.PageSize = 1000

        Dim Resultado As Google.Apis.Drive.v3.Data.FileList = Request.Execute()
        Dim Archivos As IList(Of Google.Apis.Drive.v3.Data.File) = Resultado.Files

        While (Archivos IsNot Nothing AndAlso Archivos.Any())
            For Each archivo In Archivos
                If (archivo.Name = nameFolder) Then
                    idFile = archivo.Id.ToString
                    Exit For
                    Exit While
                End If
            Next

            If (Resultado.NextPageToken IsNot Nothing) Then
                Request.PageToken = Resultado.NextPageToken
                Resultado = Request.Execute()
                Archivos = Resultado.Files
            Else
                Archivos = Nothing
            End If
        End While

        Return idFile
    End Function


    Private Function g_fnListarArchivos(Service As Google.Apis.Drive.v3.DriveService, nameFile As String, searchIn As String) As IList(Of Google.Apis.Drive.v3.Data.File)
        Dim idFile As String = g_fnExisteArchivo(Service, nameFile, searchIn)
        If (idFile = String.Empty) Then
            Return g_fnListarArchivosPaginados(Service, 1000, idFile)
        Else
            Return Nothing
        End If
    End Function

    Private Function g_fnListarArchivosPaginados(Service As Google.Apis.Drive.v3.DriveService, fileLimit As Integer, nameFolder As String) As IList(Of Google.Apis.Drive.v3.Data.File)
        Dim Retornar As IList(Of Google.Apis.Drive.v3.Data.File) = Nothing
        Dim Request As Google.Apis.Drive.v3.FilesResource.ListRequest = Service.Files.List()
        Request.Fields = "nextPageToken, files(id, name)"
        Request.Q = "'" + nameFolder + "' in parents"

        Request.PageSize = fileLimit
        Dim Resultado As Google.Apis.Drive.v3.Data.FileList = Request.Execute()
        Dim Archivos As IList(Of Google.Apis.Drive.v3.Data.File) = Resultado.Files

        While Archivos IsNot Nothing AndAlso Archivos.Any()
            For Each archivo In Archivos
                Retornar.Add(archivo)
            Next

            If Resultado.NextPageToken IsNot Nothing Then
                Request.PageToken = Resultado.NextPageToken
                Resultado = Request.Execute()
                Archivos = Resultado.Files
            Else
                Archivos = Nothing
            End If
        End While

        Return Retornar
    End Function

    Private Sub g_prCrearDirectorio(Service As Google.Apis.Drive.v3.DriveService, nameDirectory As String, containerDirectory As String)
        Dim Diretorio = New Google.Apis.Drive.v3.Data.File()
        Dim idFolder As String = g_fnExisteArchivo(Service, nameDirectory, containerDirectory)
        If (Not idFolder = String.Empty) Then
            Diretorio.Name = nameDirectory
            Diretorio.MimeType = "application/vnd.google-apps.folder"
            Diretorio.Parents = New List(Of String)
            Diretorio.Parents.Add(idFolder)
            Dim Request = Service.Files.Create(Diretorio)
            Request.Execute()
        End If
    End Sub

    Private Function g_fnObtenerIdArchivos(Service As Google.Apis.Drive.v3.DriveService, nameFile As String, Optional includeTrash As Boolean = False) As String()
        Dim Retornar = New List(Of String)()
        Dim Request = Service.Files.List()

        Request.Q = String.Format("name = '{0}'", nameFile)
        If (Not includeTrash) Then
            Request.Q += " and trashed = false"
        End If
        Request.Fields = "files(id)"
        Dim Resultado = Request.Execute()
        Dim Archivos = Resultado.Files

        If (Archivos IsNot Nothing AndAlso Archivos.Any()) Then
            For Each archivo In Archivos
                Retornar.Add(archivo.Id)
            Next
        End If

        Return Retornar.ToArray()
    End Function

    Private Sub g_prEliminarArchivo(Service As Google.Apis.Drive.v3.DriveService, nameFile As String)
        Dim Ids = g_fnObtenerIdArchivos(Service, nameFile)
        If (Ids IsNot Nothing AndAlso Ids.Any()) Then
            For Each Id In Ids
                Dim Request = Service.Files.Delete(Id)
                Request.Execute()
            Next
        End If
    End Sub

    Private Sub g_prSubirArchivo(Service As Google.Apis.Drive.v3.DriveService, containerDirectory As String)
        Dim archivo = New Google.Apis.Drive.v3.Data.File()
        archivo.Name = System.IO.Path.GetFileName(containerDirectory)
        archivo.MimeType = MimeTypes.MimeTypeMap.GetMimeType(System.IO.Path.GetExtension(containerDirectory))

        Using Stream = New System.IO.FileStream(containerDirectory, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            Dim Ids = g_fnObtenerIdArchivos(Service, archivo.Name)
            Dim Request As Google.Apis.Upload.ResumableUpload(Of Google.Apis.Drive.v3.Data.File, Google.Apis.Drive.v3.Data.File)

            If (Ids Is Nothing OrElse Not Ids.Any()) Then
                Request = Service.Files.Create(archivo, Stream, archivo.MimeType)
            Else
                Request = Service.Files.Update(archivo, Ids.First(), Stream, archivo.MimeType)
            End If

            Request.Upload()
        End Using
    End Sub

    Private Sub g_prDescargarArchivo(Service As Google.Apis.Drive.v3.DriveService, nameFile As String, containerDirectory As String)
        Dim Ids = g_fnObtenerIdArchivos(Service, nameFile)
        If (Ids IsNot Nothing AndAlso Ids.Any()) Then
            Dim Request = Service.Files.[Get](Ids.First())
            Using Stream = New System.IO.FileStream(containerDirectory, System.IO.FileMode.Create, System.IO.FileAccess.Write)
                Request.Download(Stream)
            End Using
        End If
    End Sub

    Private Sub g_prMoverAlaPapelera(Service As Google.Apis.Drive.v3.DriveService, nameFile As String)
        Dim Ids = g_fnObtenerIdArchivos(Service, nameFile)
        If (Ids IsNot Nothing AndAlso Ids.Any()) Then
            For Each Id In Ids
                Dim Arquivo = New Google.Apis.Drive.v3.Data.File()
                Arquivo.Trashed = True
                Dim Request = Service.Files.Update(Arquivo, Id)
                Request.Execute()
            Next
        End If
    End Sub

#End Region

End Module
