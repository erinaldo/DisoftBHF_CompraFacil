Imports System.Runtime.Serialization

<DataContractAttribute()> _
Public Class RequestDetail
    <DataMember()> Public obnumi As Integer
    <DataMember()> Public obcprod As String
    <DataMember()> Public obpcant As Double
    <DataMember()> Public obpbase As Double
    <DataMember()> Public obptot As Double

    <DataMember()> Private product As Product

    Public Sub New(numi As Integer, cprod As String, cant As Double, pbase As Double, total As Double, _producto As Product)
        obnumi = numi
        obcprod = cprod
        obpcant = cant
        obpbase = pbase
        obptot = total
        product = _producto
    End Sub
End Class
