Public Interface ICharacter
    Inherits IEntity
    ReadOnly Property CharacterId As Integer
    ReadOnly Property CharacterType As String
    Property Location As ILocation
    ReadOnly Property AvailableVerbs As IEnumerable(Of (Identifier As String, Text As String))
    Function Perform(verbType As String) As IDialog
End Interface
