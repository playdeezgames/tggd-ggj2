Imports System.Diagnostics.CodeAnalysis
Imports TGGD.Business

Friend Class StoreLocationTypeDescriptor
    Inherits LocationTypeDescriptor

    Public Sub New()
        MyBase.New(
            Business.LocationType.Store,
            StoreNames.Names.Count)
    End Sub

    Public Overrides Sub OnInitialize(location As ILocation)
        Dim candidates As New HashSet(Of String)(StoreNames.Names)
        For Each otherStores In location.World.Locations.Where(Function(x) x.LocationType = LocationType AndAlso x.LocationId <> location.LocationId)
            candidates.Remove(otherStores.GetName())
        Next
        location.SetMetadata(MetadataType.Name, RNG.FromEnumerable(candidates))
        location.SetStatistic(Business.StatisticType.OpenHour, RNG.FromRange(6, 10))
        location.SetStatistic(Business.StatisticType.CloseHour, RNG.FromRange(17, 22))
    End Sub

    Public Overrides Function Describe(location As ILocation) As IEnumerable(Of String)
        Dim result As New List(Of String) From
            {
                $"HOURS: {location.GetStatistic(StatisticType.OpenHour)}-{location.GetStatistic(StatisticType.CloseHour)}"
            }
        If location.IsOpen() Then
            result.Add("WE ARE OPEN!")
        Else
            result.Add("SORRY! WE'RE CLOSED!")
        End If
        Return result
    End Function
End Class
