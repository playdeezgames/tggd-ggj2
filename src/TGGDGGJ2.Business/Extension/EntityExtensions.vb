Imports System.Runtime.CompilerServices

Public Module EntityExtensions
    <Extension>
    Public Function GetName(entity As IEntity) As String
        Return entity.GetMetadata(MetadataType.Name)
    End Function
End Module
