Imports System.Runtime.Serialization

<DataContractAttribute()> _
Public Class Client
    <DataMember()> Public ccnumi As Integer
    <DataMember()> Public cccod As String
    <DataMember()> Public ccdesc As String
    <DataMember()> Public cczona As Integer
    <DataMember()> Public ccdct As Integer
    <DataMember()> Public ccdctnum As String
    <DataMember()> Public ccdirec As String
    <DataMember()> Public cctelf1 As String
    <DataMember()> Public cctelf2 As String
    <DataMember()> Public cccat As Integer
    <DataMember()> Public ccest As Integer
    <DataMember()> Public cclat As Double
    <DataMember()> Public cclongi As Double
    <DataMember()> Public ccprconsu As Integer
    <DataMember()> Public cceven As Boolean
    <DataMember()> Public ccobs As String
    <DataMember()> Public ccfnac As String
    <DataMember()> Public ccnomfac As String
    <DataMember()> Public ccnit As String
    <DataMember()> Public ccultped As String
    <DataMember()> Public ccfecing As String
    <DataMember()> Public ccultvent As String
    <DataMember()> Public ccfact As String
    <DataMember()> Public cchact As String
    <DataMember()> Public ccuact As String

    Public Sub New(numi As Integer, cod As String, desc As String, zona As Integer, doc As Integer, numDoc As String, direc As String, _
                   telef1 As String, telef2 As String, cate As Integer, estado As Integer, latitud As Double, longi As Double, _
                   promConsu As Integer, even As Boolean, obs As String, fnac As String, nomFac As String, nit As String, ultPed As String, _
                   fIng As String, ultVen As String, fact As String, hact As String, uact As String)
        ccnumi = numi
        cccod = cod
        ccdesc = desc
        cczona = zona
        ccdct = doc
        ccdctnum = numDoc
        ccdirec = direc
        cctelf1 = telef1
        cctelf2 = telef2
        cccat = cate
        ccest = estado
        cclat = latitud
        cclongi = longi
        ccprconsu = promConsu
        cceven = even
        ccobs = obs
        ccfnac = fnac
        ccnomfac = nomFac
        ccnit = nit
        ccultped = ultPed
        ccfecing = fIng
        ccultvent = ultVen
        ccfact = fact
        cchact = hact
        ccuact = uact
    End Sub
End Class
