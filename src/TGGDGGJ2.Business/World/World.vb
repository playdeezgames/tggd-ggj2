Imports TGGDGGJ2.Data

Public Class World
    Inherits Entity(Of WorldData)
    Implements IWorld
    Sub New(data As WorldData, playSfx As Action(Of String))
        MyBase.New(data, playSfx)
    End Sub

    Public ReadOnly Property Locations As IEnumerable(Of ILocation) Implements IWorld.Locations
        Get
            Return Enumerable.Range(0, Data.Locations.Count).Select(Function(x) New Location(Data, x, PlaySfx))
        End Get
    End Property

    Public Property Avatar As ICharacter Implements IWorld.Avatar
        Get
            Return If(Data.AvatarId.HasValue, New Character(Data, Data.AvatarId.Value, PlaySfx), Nothing)
        End Get
        Set(value As ICharacter)
            If value Is Nothing Then
                Data.AvatarId = Nothing
            Else
                Data.AvatarId = value.CharacterId
            End If
        End Set
    End Property

    Protected Overrides ReadOnly Property EntityData As WorldData
        Get
            Return Data
        End Get
    End Property

    Public Sub Clear() Implements IWorld.Clear
        Data.Characters.Clear()
        Data.Locations.Clear()
        Data.AvatarId = Nothing
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

    Public Function CreateCharacter(characterType As String, location As ILocation) As ICharacter Implements IWorld.CreateCharacter
        Dim characterId = EntityData.Characters.Count
        EntityData.Characters.Add(New CharacterData With
                                 {
                                    .CharacterType = characterType,
                                    .LocationId = location.LocationId
                                 })
        Dim result As ICharacter = New Character(Data, characterId, PlaySfx)
        result.Initialize()
        location.AddCharacter(result)
        Return result
    End Function
End Class
