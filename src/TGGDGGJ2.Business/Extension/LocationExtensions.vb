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
    <Extension>
    Public Function GetDisplayName(location As ILocation) As String
        Return location.GetName().ToUpper
    End Function
    <Extension>
    Public Function IsOpen(location As ILocation) As Boolean
        Dim openHour = location.GetStatistic(StatisticType.OpenHour)
        Dim closeHour = location.GetStatistic(StatisticType.CloseHour)
        Dim currentHour = location.World.GetStatistic(StatisticType.Hour)
        Return currentHour >= openHour AndAlso currentHour < closeHour
    End Function
End Module
