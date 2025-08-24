Imports System.Runtime.CompilerServices

Friend Module VerbTypes
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, VerbTypeDescriptor) =
        New List(Of VerbTypeDescriptor) From
        {
            New GoHomeVerbTypeDescriptor(),
            New GoToStoreVerbTypeDescriptor(),
            New StatisticsVerbTypeDescriptor(),
            New DoChoresVerbTypeDescriptor(),
            New GoToBedVerbTypeDescriptor(),
            New BuyVerbTypeDescriptor(),
            New InventoryVerbTypeDescriptor()
        }.ToDictionary(Function(x) x.VerbType, Function(x) x)
    Friend ReadOnly Property All As IEnumerable(Of String)
        Get
            Return Descriptors.Keys
        End Get
    End Property
    <Extension>
    Friend Function ToVerbTypeDescriptor(verbType As String) As VerbTypeDescriptor
        Return Descriptors(verbType)
    End Function
End Module
