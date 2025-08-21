Imports System.Runtime.CompilerServices

Public Module LocationExtensions
    <Extension>
    Friend Function GetDescriptor(location As ILocation) As LocationTypeDescriptor
        Return LocationTypes.Descriptors(location.LocationType)
    End Function
    <Extension>
    Friend Sub Initialize(location As ILocation)
        location.GetDescriptor().OnInitialize(location)
    End Sub
    <Extension>
    Public Function GetName(location As ILocation) As String
        Return location.GetMetadata(MetadataType.Name)
    End Function
End Module
