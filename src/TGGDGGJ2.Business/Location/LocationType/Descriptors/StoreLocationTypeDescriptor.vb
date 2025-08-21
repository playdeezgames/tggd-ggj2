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
    End Sub
End Class
