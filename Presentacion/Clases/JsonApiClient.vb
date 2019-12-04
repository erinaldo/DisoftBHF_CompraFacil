Imports System.Net
Imports System.IO
Imports System.Runtime.Serialization.Json
Imports Entidades

'Imports System.Runtime.Serialization
'Imports System.ServiceModel.Web

Public Class JsonApiClient
    'Public Shared urlApiSendMessage As String = "https://water-delivery.herokuapp.com/api/Tc004s/sendNotification?data="
    Public Shared urlApiSendMessage As String = "http://" + gs_Ip + ":3000/api/Tc004s/sendNotification?data="

    'Public Sub GetT002()
    '    Dim syncClient As WebClient
    '    syncClient = New WebClient()
    '    Dim content As String = syncClient.DownloadData(urlApiSendMessage).ToString()
    'End Sub

    'Public Shared Function GetT002(codEmpleado As String) As String

    '    Dim url As String = urlApi + "/" + codEmpleado
    '    Dim syncClient As WebClient
    '    syncClient = New WebClient()
    '    Dim content As String = ""
    '    Try
    '        'convierto un objeto a json
    '        Dim objPedido As New RequestHeader
    '        objPedido.oanumi = 666

    '        Dim stream1 As MemoryStream = New MemoryStream()
    '        Dim ser As DataContractJsonSerializer = New DataContractJsonSerializer(objPedido.GetType)

    '        ser.WriteObject(stream1, objPedido)
    '        stream1.Position = 0
    '        Dim sr As StreamReader = New StreamReader(stream1)

    '        'content = syncClient.DownloadString(url)
    '        content = sr.ReadToEnd()
    '    Catch ex As Exception
    '        content = "no se puedo establacer conexion"
    '    End Try

    '    Return content
    'End Function

    Public Shared Function _prMandarNotificacion(objResult As Result) As Boolean
        Dim resultado As Boolean = True
        Dim syncClient As WebClient
        syncClient = New WebClient()
        Dim objJson As String = ""
        Try
            'convierto un objeto a json

            Dim stream1 As MemoryStream = New MemoryStream()
            Dim ser As DataContractJsonSerializer = New DataContractJsonSerializer(objResult.GetType)

            ser.WriteObject(stream1, objResult)

            stream1.Position = 0
            Dim sr As StreamReader = New StreamReader(stream1)
            objJson = sr.ReadToEnd()

            Dim resultadoLlamada As String = syncClient.DownloadString(urlApiSendMessage + objJson)
            If "{" + Chr(34) + "Result" + Chr(34) + ":false}" = resultadoLlamada Then
                resultado = False
            End If
        Catch ex As Exception
            objJson = "no se puedo establacer conexion"
            resultado = False
        End Try

        Return resultado
    End Function

    'Public Shared Sub GetPOSTResponse(data As String, callback As Action(Of Result)) 'uri As Uri,
    '    Dim uri As Uri
    '    Uri = New Uri(urlApiSendMessage)

    '    Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(Uri), HttpWebRequest)

    '    request.Method = "POST"
    '    'request.ContentType = "text/plain;charset=utf-8"
    '    request.ContentType = "application/json"

    '    Dim objresultao As New Result


    '    Dim encoding As New System.Text.UTF8Encoding()
    '    Dim bytes As Byte() = encoding.GetBytes(data)

    '    request.ContentLength = bytes.Length

    '    Using requestStream As Stream = request.GetRequestStream()
    '        ' Send the data.
    '        requestStream.Write(bytes, 0, bytes.Length)
    '    End Using

    '    request.BeginGetResponse(
    '        Function(x)
    '            Using response As HttpWebResponse = DirectCast(request.EndGetResponse(x), HttpWebResponse)
    '                If callback IsNot Nothing Then
    '                    Dim ser As New DataContractJsonSerializer(GetType(Result))
    '                    callback(TryCast(ser.ReadObject(response.GetResponseStream()), Result))
    '                End If
    '            End Using
    '            Return 0
    '        End Function, Nothing)
    'End Sub

    Public Shared Sub _prMandarNotificacion2()
        '        Dim client As New HttpClient()

        '    var values = new Dictionary<string, string>
        '    {
        '       { "thing1", "hello" },
        '       { "thing2", "world" }
        '    };

        '    var content = new FormUrlEncodedContent(values);

        '    var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

        '    var responseString = await response.Content.ReadAsStringAsync();
        '}
    End Sub
End Class
