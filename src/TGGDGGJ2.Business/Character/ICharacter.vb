Public Interface ICharacter
    Inherits IEntity
    ReadOnly Property CharacterId As Integer
    ReadOnly Property CharacterType As String
    Property Location As ILocation
    ReadOnly Property AvailableVerbs As IEnumerable(Of (Identifier As String, Text As String))
    Function Perform(verbType As String) As IDialog
    Sub AddMessage(ParamArray lines As String())
    ReadOnly Property IsAvatar As Boolean
End Interface
