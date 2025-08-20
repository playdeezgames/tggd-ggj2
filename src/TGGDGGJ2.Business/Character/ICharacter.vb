Public Interface ICharacter
    Inherits IEntity
    ReadOnly Property CharacterId As Integer
    ReadOnly Property CharacterType As String
    ReadOnly Property Location As ILocation
    ReadOnly Property AvailableVerbs As IEnumerable(Of (Identifier As String, Text As String))
End Interface
