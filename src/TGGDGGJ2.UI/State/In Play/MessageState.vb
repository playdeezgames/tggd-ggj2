Imports System.Resources
Imports TGGD.UI

Friend Class MessageState
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
        Dim message = world.CurrentMessage
        Dim row = (buffer.Rows - message.LineCount) \ 2
        For Each line In message.Lines
            buffer.WriteCenteredText(row, line)
            row += 1
        Next
        buffer.WriteInvertedCenteredText(buffer.Rows - 1, "<ACTION>")
    End Sub

    Public Function HandleCommand(command As String) As IUIState Implements IUIState.HandleCommand
        Select Case command
            Case UI.Command.Green
                world.DismissMessage()
                Return NeutralState.DetermineState(buffer, world, playSfx)
            Case Else
                Return Me
        End Select
    End Function
End Class
