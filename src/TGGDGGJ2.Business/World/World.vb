Imports TGGDGGJ2.Data

Public Class World
    Inherits Entity(Of WorldData)
    Implements IWorld
    Sub New(data As WorldData, playSfx As Action(Of String))
        MyBase.New(data, playSfx)
    End Sub

    Protected Overrides ReadOnly Property EntityData As WorldData
        Get
            Return Data
        End Get
    End Property

    Public Sub Clear() Implements IWorld.Clear
    End Sub

    Public Function CreateLocation(locationType As String) As ILocation Implements IWorld.CreateLocation
        Dim locationId = EntityData.Locations.Count
        EntityData.Locations.Add(New LocationData With
                                 {
                                    .LocationType = locationType
                                 })
        Dim result As ILocation = New Location(Data, locationId, PlaySfx)
        result.Initialize()
        Return result
    End Function
End Class
