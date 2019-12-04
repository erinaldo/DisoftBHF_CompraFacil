Imports System.Runtime.Serialization

<DataContractAttribute()> _
Public Class RequestHeader
    <DataMember()> Public oanumi As Integer
    <DataMember()> Public oafdoc As String
    <DataMember()> Public oahora As String
    <DataMember()> Public oaccli As Integer
    <DataMember()> Public oazona As Integer
    <DataMember()> Public oarepa As Integer
    <DataMember()> Public oaobs As String
    <DataMember()> Public oaobs2 As String
    <DataMember()> Public oaest As Integer
    <DataMember()> Public oaap As Integer
    <DataMember()> Public oapg As Integer
    <DataMember()> Public oafact As String
    <DataMember()> Public oahact As String
    <DataMember()> Public oauact As String

    <DataMember()> Public details As List(Of RequestDetail)
    <DataMember()> Public client As Client

    Public Sub New(numi As Integer, fdoc As String, hora As String, codCli As Integer, zona As Integer, codRepa As Integer, obs As String, obs2 As String, estado As Integer, actPas As Integer, pedGen As Integer, fact As String, hact As String, uact As String, listDetalle As List(Of RequestDetail), cliente As Client)
        oanumi = numi
        oafdoc = fdoc
        oahora = hora
        oaccli = codCli
        oazona = zona
        oarepa = codRepa
        oaobs = obs
        oaobs2 = obs2
        oaest = estado
        oaap = actPas
        oapg = pedGen
        oafact = fact
        oahact = hact
        oauact = uact

        details = listDetalle
        client = cliente
    End Sub

End Class
