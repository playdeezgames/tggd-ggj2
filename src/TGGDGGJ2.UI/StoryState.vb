Imports TGGD.UI

Friend Class StoryState
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
        buffer.Fill(239)
        buffer.WriteCenteredText(0, "STORY")
        buffer.Invert(0, 0, buffer.Columns, 1)
        ''''''''''''''''''''''''''12345678901234567890123456789012
        buffer.WriteText((0, 1), "YER ADELINE, COLLECTOR OF SQUISH")
        buffer.WriteText((0, 2), "MALLOWS! YER QUEST IS TO COLLECT")
        buffer.WriteText((0, 3), "AS MANY OF THEM AS YOU CAN!")
        buffer.WriteText((0, 5), "BECAUSE YER NAME IS ADELINE,")
        buffer.WriteText((0, 6), "YOU SPECIALIZE IN COLLECTING")
        buffer.WriteText((0, 7), "ONLY THOSE SQUISHMALLOWS")
        buffer.WriteText((0, 8), "WHOSE NAMES START WITH THE ")
        buffer.WriteText((0, 9), "LETTER A!")
        buffer.WriteText((0, 11), "(OR, WE'D BE HERE FOR years!)")
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
