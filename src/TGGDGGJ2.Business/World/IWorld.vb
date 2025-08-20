Public Interface IWorld
    Inherits IEntity
    Sub Clear()
    Function CreateLocation(locationType As String) As ILocation
    ReadOnly Property Locations As IEnumerable(Of ILocation)
    Function CreateCharacter(characterType As String, location As ILocation) As ICharacter
    Property Avatar As ICharacter
    Sub Abandon()
End Interface
