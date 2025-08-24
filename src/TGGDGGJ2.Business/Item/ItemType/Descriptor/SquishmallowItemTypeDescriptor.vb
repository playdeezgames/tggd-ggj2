Imports TGGD.Business

Friend Class SquishmallowItemTypeDescriptor
    Inherits ItemTypeDescriptor

    Shared ReadOnly namesRemaining As New HashSet(Of String)(SquishmallowNames.Names)
    ReadOnly namePrices As New Dictionary(Of String, Integer)

    Public Sub New()
        MyBase.New(
            Business.ItemType.Squishmallow,
            SquishmallowNames.Names.Count)
    End Sub

    Friend Overrides Sub OnInitialize(item As Item)
        Dim name As String
        Dim assignLocation As Boolean = False
        If namesRemaining.Any Then
            name = RNG.FromEnumerable(namesRemaining)
            namesRemaining.Remove(name)
            namePrices(name) = RNG.RollXDY(5, 3)
            assignLocation = True
        Else
            name = RNG.FromEnumerable(SquishmallowNames.Names)
        End If
        item.SetMetadata(MetadataType.Name, name)
        item.SetStatistic(StatisticType.Price, namePrices(name))
        If assignLocation Then
            Dim location = RNG.FromEnumerable(item.World.Locations.Where(Function(x) x.LocationType = LocationType.Store))
            location.AddItem(item)
        End If
    End Sub
End Class
