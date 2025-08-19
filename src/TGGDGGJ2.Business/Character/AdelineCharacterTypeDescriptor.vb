Friend Class AdelineCharacterTypeDescriptor
    Inherits CharacterTypeDescriptor

    Public Sub New()
        MyBase.New(Business.CharacterType.Adeline)
    End Sub

    Public Overrides Sub OnInitialize(character As ICharacter)
    End Sub
End Class
