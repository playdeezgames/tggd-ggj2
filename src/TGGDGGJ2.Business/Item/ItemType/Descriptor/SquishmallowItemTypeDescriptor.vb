Imports TGGD.Business

Friend Class SquishmallowItemTypeDescriptor
    Inherits ItemTypeDescriptor

    Shared ReadOnly namesRemaining As New HashSet(Of String)(SquishmallowNames.Names)

    Public Sub New()
        MyBase.New(
            Business.ItemType.Squishmallow,
            SquishmallowNames.Names.Count)
    End Sub

    Friend Overrides Sub OnInitialize(item As Item)
        Dim name As String
        If namesRemaining.Any Then
            name = RNG.FromEnumerable(namesRemaining)
            namesRemaining.Remove(name)
        Else
            name = RNG.FromEnumerable(SquishmallowNames.Names)
        End If
        item.SetMetadata(MetadataType.Name, name)
        Dim location = RNG.FromEnumerable(item.World.Locations.Where(Function(x) x.LocationType = LocationType.Store))
        location.AddItem(item)
    End Sub
End Class
