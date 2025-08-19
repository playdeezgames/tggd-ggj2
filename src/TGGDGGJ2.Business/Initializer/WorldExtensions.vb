Imports System.Runtime.CompilerServices
Imports TGGD.Business

Public Module WorldExtensions
    <Extension>
    Public Sub Initialize(world As IWorld)
        world.Clear()
        InitializeLocations(world)
        InitializeCharacters(world)
    End Sub

    Private Sub InitializeCharacters(world As IWorld)
        For Each characterType In CharacterTypes.All
            Dim descriptor = characterType.ToCharacterTypeDescriptor
            Dim candidates = world.Locations.Where(Function(x) descriptor.CanSpawn(x))
            world.CreateCharacter(characterType, RNG.FromEnumerable(candidates))
        Next
    End Sub

    Private Sub InitializeLocations(world As IWorld)
        For Each locationType In LocationTypes.All
            world.CreateLocation(locationType)
        Next
    End Sub
End Module
