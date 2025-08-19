Friend MustInherit Class CharacterTypeDescriptor
    ReadOnly Property CharacterType As String
    Sub New(characterType As String)
        Me.CharacterType = characterType
    End Sub
    MustOverride Sub OnInitialize(character As ICharacter)
    MustOverride Function CanSpawn(location As ILocation) As Boolean
End Class
