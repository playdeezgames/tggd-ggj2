Imports System.Runtime.CompilerServices

Public Module WorldExtensions
    <Extension>
    Public Sub Initialize(world As IWorld)
        world.Clear()
        InitializeLocations(world)
    End Sub

    Private Sub InitializeLocations(world As IWorld)
        For Each locationType In LocationTypes.All
            Dim location As ILocation = world.CreateLocation(locationType)
            location.Initialize()
        Next
    End Sub
End Module
