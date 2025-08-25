Imports TGGD.UI
Imports TGGDGGJ2.Business

Friend Class EmbarkState
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
        ''''''''''''''''''''''''''12345678901234567890123456789012
        buffer.WriteText((0, 0), "YOU ARE ADELINE, AND YER MISSION")
        buffer.WriteText((0, 1), "IN LIFE IS TO COLLECT CUTE")
        buffer.WriteText((0, 2), "THINGS, AND SQUISHMALLOWS ARE")
        buffer.WriteText((0, 3), "THE CUTEST THINGS evar!")
        buffer.WriteText((0, 5), "BUT THEY AREN'T FREE AND THEY")
        buffer.WriteText((0, 6), "AREN'T CHEAP!")
        buffer.WriteText((0, 8), "YOU WILL HAVE TO FIND A WAY TO")
        buffer.WriteText((0, 9), "EARN MONEY, OR CONVINCE OTHERS")
        buffer.WriteText((0, 10), "TO BUY THEM FOR YOU!")
        buffer.WriteText((0, 12), "IF YOU WIND UP WITH DUPLICATES,")
        buffer.WriteText((0, 13), "YOU CAN SELL THEM ON SQUEEBAY.")
        buffer.WriteInvertedCenteredText(buffer.Rows - 1, "<ACTION>")
    End Sub

    Public Function HandleCommand(command As String) As IUIState Implements IUIState.HandleCommand
        Select Case command
            Case UI.Command.Green
                world.Initialize()
                Return NeutralState.DetermineState(buffer, world, playSfx)
            Case Else
                Return Me
        End Select
    End Function
End Class
