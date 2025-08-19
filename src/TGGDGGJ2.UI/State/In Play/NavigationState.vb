Imports TGGD.UI

Friend Class NavigationState
    Implements IUIState

    Private ReadOnly buffer As IUIBuffer(Of Integer)
    Private ReadOnly world As Business.IWorld
    Private ReadOnly playSfx As Action(Of String)

    Public Sub New(buffer As IUIBuffer(Of Integer), world As Business.IWorld, playSfx As Action(Of String))
        Me.buffer = buffer
        Me.world = world
        Me.playSfx = playSfx
    End Sub

    Public Sub Refresh() Implements IUIState.Refresh
        buffer.Fill(MagentaBlock)
        buffer.WriteInvertedCenteredText(0, "NAVIGATION")
        Dim character = world.Avatar
        buffer.WriteText((0, 1), $"CHARACTER: {character.CharacterType}")
        buffer.WriteText((0, 2), $"LOCATION: {character.Location.LocationType}")
    End Sub

    Public Function HandleCommand(command As String) As IUIState Implements IUIState.HandleCommand
        Return Me
    End Function
End Class
