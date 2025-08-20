Friend Class AdelineCharacterTypeDescriptor
    Inherits CharacterTypeDescriptor

    Public Sub New()
        MyBase.New(Business.CharacterType.Adeline)
    End Sub

    Public Overrides Sub OnInitialize(character As ICharacter)
        character.SetMetadata(MetadataType.Name, "ADELINE")
        character.World.Avatar = character
    End Sub

    Public Overrides Function CanSpawn(location As ILocation) As Boolean
        Return location.LocationType = LocationType.Home
    End Function
End Class
