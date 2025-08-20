Imports TGGD.UI
Imports TGGDGGJ2.Business

Friend Class GameMenuState
    Inherits PickerState

    Shared ReadOnly CONTINUE_IDENTIFIER As String = NameOf(CONTINUE_IDENTIFIER)
    Shared ReadOnly ABANDON_IDENTIFIER As String = NameOf(ABANDON_IDENTIFIER)
    Const CONTINUE_TEXT = "CONTINUE"
    Const ABANDON_TEXT = "ABANDON"

    ReadOnly world As IWorld
    ReadOnly playSfx As Action(Of String)

    Public Sub New(
                  buffer As IUIBuffer(Of Integer),
                  world As IWorld,
                  playSfx As Action(Of String))
        MyBase.New(
            buffer,
            "GAME MENU",
            {
                (CONTINUE_IDENTIFIER, CONTINUE_TEXT),
                (ABANDON_IDENTIFIER, ABANDON_TEXT)
            })
        Me.world = world
        Me.playSfx = playSfx
    End Sub

    Protected Overrides Function HandleCancel() As IUIState
        Return NeutralState.DetermineState(buffer, world, playSfx)
    End Function

    Protected Overrides Function HandlePick(pick As String) As IUIState
        Select Case pick
            Case CONTINUE_IDENTIFIER
                Return NeutralState.DetermineState(buffer, world, playSfx)
            Case ABANDON_IDENTIFIER
                Return New ConfirmState(
                    buffer,
                    "CONFIRM ABANDON?",
                    AddressOf OnConfirmAbandon,
                    AddressOf OnCancelAbandon)
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Private Function OnCancelAbandon() As IUIState
        Return New GameMenuState(buffer, world, playSfx)
    End Function

    Private Function OnConfirmAbandon() As IUIState
        world.Abandon()
        Return New MainMenuState(buffer, world, playSfx)
    End Function
End Class
