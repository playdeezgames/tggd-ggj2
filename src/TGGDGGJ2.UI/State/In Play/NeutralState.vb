Imports TGGD.UI
Imports TGGDGGJ2.Business

Friend Module NeutralState
    Function DetermineState(buffer As IUIBuffer(Of Integer), world As IWorld, playSfx As Action(Of String)) As IUIState

        If world.Avatar.UniqueSquishmallowCount >= SquishmallowNames.Count Then
            Return New WinState(buffer, world, playSfx)
        End If
        If world.HasMessage Then
                Return New MessageState(buffer, world, playSfx)
            End If
            Return New NavigationState(buffer, world, playSfx)
    End Function
End Module
