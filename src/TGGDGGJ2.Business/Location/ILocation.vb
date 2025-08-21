Public Interface ILocation
    Inherits IEntity
    ReadOnly Property LocationId As Integer
    ReadOnly Property LocationType As String
    Sub AddCharacter(character As ICharacter)
    Sub RemoveCharacter(character As ICharacter)
End Interface
