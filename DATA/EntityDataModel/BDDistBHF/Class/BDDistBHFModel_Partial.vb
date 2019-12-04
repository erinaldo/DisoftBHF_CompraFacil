Imports System.Data.Entity

Partial Public Class BDDistBHFEntities
    Inherits DbContext
    Public Sub New(bdDistBhf As Boolean)
        MyBase.New("name=BDDistBHFEntities")
    End Sub
End Class
