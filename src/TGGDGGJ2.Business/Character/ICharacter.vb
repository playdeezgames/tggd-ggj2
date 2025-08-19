Public Interface ICharacter
    Inherits IEntity
    ReadOnly Property CharacterId As Integer
    ReadOnly Property CharacterType As String
    ReadOnly Property Location As ILocation
End Interface
