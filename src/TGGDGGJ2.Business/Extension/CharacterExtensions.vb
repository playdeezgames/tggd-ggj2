Imports System.Runtime.CompilerServices

Public Module CharacterExtensions
    <Extension>
    Friend Function GetDescriptor(character As ICharacter) As CharacterTypeDescriptor
        Return CharacterTypes.Descriptors(character.CharacterType)
    End Function
    <Extension>
    Friend Sub Initialize(character As ICharacter)
        character.GetDescriptor().OnInitialize(character)
    End Sub
    <Extension>
    Public Function UniqueSquishmallowCount(character As ICharacter) As Integer
        Return character.Items.Where(Function(x) x.ItemType = ItemType.Squishmallow).GroupBy(Function(x) x.GetName).Count
    End Function
End Module
