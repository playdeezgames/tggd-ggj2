Imports System.Runtime.CompilerServices

Friend Module LocationExtensions
    <Extension>
    Function GetDescriptor(location As ILocation) As LocationTypeDescriptor
        Return LocationTypes.Descriptors(location.LocationType)
    End Function
    <Extension>
    Sub Initialize(location As ILocation)
        location.GetDescriptor().OnInitialize(location)
    End Sub
End Module
