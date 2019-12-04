Imports DATA

Public MustInherit Class RBasePrincipal(Of T As BDDistBHFEntities)
    Protected MustOverride Function GetSchema() As T
End Class

