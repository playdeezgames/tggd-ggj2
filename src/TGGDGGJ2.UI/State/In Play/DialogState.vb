Imports TGGD.UI

Friend Class DialogState
    Inherits PickerState

    Private ReadOnly world As Business.IWorld
    Private ReadOnly playSfx As Action(Of String)
    Private ReadOnly dialog As Business.IDialog

    Public Sub New(buffer As IUIBuffer(Of Integer), world As Business.IWorld, playSfx As Action(Of String), dialog As Business.IDialog)
        MyBase.New(buffer, dialog.Caption, dialog.Lines.ToArray, dialog.Choices.ToArray)
        Me.world = world
        Me.playSfx = playSfx
        Me.dialog = dialog
    End Sub

    Protected Overrides Function HandleCancel() As IUIState
        Return Me
    End Function

    Protected Overrides Function HandlePick(pick As String) As IUIState
        Dim nextDialog = dialog.Choose(pick)
        If nextDialog Is Nothing Then
            Return NeutralState.DetermineState(buffer, world, playSfx)
        Else
            Return New DialogState(buffer, world, playSfx, nextDialog)
        End If
    End Function
End Class
