Imports System.Runtime.CompilerServices
Imports TGGD.Business

Public Module WorldExtensions
    <Extension>
    Public Sub Initialize(world As IWorld)
        world.Clear()
        world.SetStatistic(StatisticType.Day, 1)
        world.SetStatistic(StatisticType.Hour, 6)
        world.SetStatisticMinimum(StatisticType.Hour, 6)
        world.SetStatisticMaximum(StatisticType.Hour, 22)
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
            Dim descriptor = locationType.ToLocationTypeDescriptor()
            For Each dummy In Enumerable.Range(0, descriptor.LocationCount)
                world.CreateLocation(locationType)
            Next
        Next
    End Sub
End Module
