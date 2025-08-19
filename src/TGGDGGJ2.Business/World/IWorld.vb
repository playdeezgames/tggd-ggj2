Public Interface IWorld
    Inherits IEntity
    Sub Clear()
    Function CreateLocation(locationType As String) As ILocation
    Function CreateCharacter(characterType As String) As ICharacter
End Interface
