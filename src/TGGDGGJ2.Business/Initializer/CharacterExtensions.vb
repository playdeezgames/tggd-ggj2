Imports System.Runtime.CompilerServices

Friend Module CharacterExtensions
    <Extension>
    Function GetDescriptor(character As ICharacter) As CharacterTypeDescriptor
        Return CharacterTypes.Descriptors(character.CharacterType)
    End Function
    <Extension>
    Sub Initialize(character As ICharacter)
        character.GetDescriptor().OnInitialize(character)
    End Sub
End Module
