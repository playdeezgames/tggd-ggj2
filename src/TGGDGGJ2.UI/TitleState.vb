Imports TGGD.UI
Imports TGGDGGJ2.Business

Friend Class TitleState
    Implements IUIState

    Private ReadOnly buffer As IUIBuffer(Of Integer)
    Private ReadOnly world As IWorld
    Private ReadOnly playSfx As Action(Of String)

    Public Sub New(buffer As IUIBuffer(Of Integer), world As IWorld, playSfx As Action(Of String))
        Me.buffer = buffer
        Me.world = world
        Me.playSfx = playSfx
    End Sub

    Public Sub Refresh() Implements IUIState.Refresh
        buffer.Fill(239)
        buffer.WriteText((4, 1), "ADELINE'S  SQUISHMALLOWS")
        buffer.WriteText((0, 3), "A PRODUCTION OF THEGRUMPYGAMEDEV")
        buffer.WriteText((4, 4), "FOR GIRLY GAME JAM #2")
    End Sub

    Public Function HandleCommand(command As String) As IUIState Implements IUIState.HandleCommand
        Return Me
    End Function
End Class
