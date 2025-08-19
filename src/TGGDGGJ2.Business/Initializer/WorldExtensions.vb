Imports System.Runtime.CompilerServices

Public Module WorldExtensions
    <Extension>
    Public Sub Initialize(world As IWorld)
        world.Clear()
        InitializeLocations(world)
        InitializeCharacters(world)
    End Sub

    Private Sub InitializeCharacters(world As IWorld)
        For Each characterType In CharacterTypes.All
            world.CreateCharacter(characterType)
        Next
    End Sub

    Private Sub InitializeLocations(world As IWorld)
        For Each locationType In LocationTypes.All
            world.CreateLocation(locationType)
        Next
    End Sub
End Module
