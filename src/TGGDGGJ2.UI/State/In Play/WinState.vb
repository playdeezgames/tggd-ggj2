Imports TGGD.UI

Friend Class WinState
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
        buffer.WriteCenteredText(buffer.Rows \ 2, "YOU WIN!")
        buffer.WriteInvertedCenteredText(buffer.Rows - 1, "<ACTION>")
    End Sub

    Public Function HandleCommand(command As String) As IUIState Implements IUIState.HandleCommand
        Select Case command
            Case UI.Command.Green
                world.Abandon()
                Return New MainMenuState(buffer, world, playSfx)
            Case Else
                Return Me
        End Select
    End Function
End Class
