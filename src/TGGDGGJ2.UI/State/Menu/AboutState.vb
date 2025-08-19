Imports TGGD.UI

Friend Class AboutState
    Implements IUIState

    Private ReadOnly buffer As IUIBuffer(Of Integer)
    Private ReadOnly world As Business.IWorld
    Private ReadOnly playSfx As Action(Of String)

    Public Sub New(
                  buffer As IUIBuffer(Of Integer),
                  world As Business.IWorld,
                  playSfx As Action(Of String))
        Me.buffer = buffer
        Me.world = world
        Me.playSfx = playSfx
    End Sub

    Public Sub Refresh() Implements IUIState.Refresh
        buffer.Fill(MagentaBlock)
        buffer.WriteCenteredText(0, "ABOUT!")
        buffer.Invert(0, 0, buffer.Columns, 1)
        ''''''''''''''''''''''''''12345678901234567890123456789012
        buffer.WriteText((0, 1), "ADELINE'S SQUISHMALLOWS IS A")
        buffer.WriteText((0, 2), "PRODUCTION OF THEGRUMPYGAMEDEV")
        buffer.WriteText((0, 3), "MADE FOR GIRLY GAME JAM #2")
        buffer.WriteText((0, 4), "INSPIRED BY THE ACTIVITIES OF")
        buffer.WriteText((0, 5), "ONE OF GRUMPY'S CHILDREN WHO ")
        buffer.WriteText((0, 6), "DOES INDEED COLLECT THESE THINGS")
        buffer.WriteText((0, 7), "AND REARRANGES THEM ENDLESSLY")
        buffer.WriteText((0, 8), "IN HER ROOM.")

        buffer.WriteCenteredText(buffer.Rows - 1, "<ACTION>")
        buffer.Invert(0, buffer.Rows - 1, buffer.Columns, 1)
    End Sub

    Public Function HandleCommand(command As String) As IUIState Implements IUIState.HandleCommand
        Select Case command
            Case UI.Command.Green
                Return New MainMenuState(buffer, world, playSfx)
            Case Else
                Return Me
        End Select
    End Function
End Class
