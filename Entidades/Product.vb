Imports System.Runtime.Serialization

<DataContractAttribute()> _
Public Class Product
    <DataMember()> Public canumi As Integer
    <DataMember()> Public cacod As String
    <DataMember()> Public cadesc As String
    <DataMember()> Public cadesc2 As String
    <DataMember()> Public cacat As Integer
    <DataMember()> Public caimg As String
    <DataMember()> Public castc As Boolean
    <DataMember()> Public caest As Boolean
    <DataMember()> Public caserie As Boolean
    <DataMember()> Public cafact As String
    <DataMember()> Public cahact As String
    <DataMember()> Public cauact As String

    Public Sub New(numi As Integer, cod As String, desc As String, desc2 As String, cat As Integer, img As String, stock As Boolean, estado As Boolean, serie As Boolean, fact As String, hact As String, uact As String)
        canumi = numi
        cacod = cod
        cadesc = desc
        cadesc2 = desc2
        cacat = cat
        caimg = img
        castc = stock
        caest = estado
        caserie = serie
        cafact = fact
        cahact = hact
        cauact = uact
    End Sub
End Class
