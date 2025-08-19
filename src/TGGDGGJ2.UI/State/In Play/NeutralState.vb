Imports TGGD.UI
Imports TGGDGGJ2.Business

Friend Module NeutralState
    Function DetermineState(buffer As IUIBuffer(Of Integer), world As IWorld, playSfx As Action(Of String)) As IUIState
        Return New NavigationState(buffer, world, playSfx)
    End Function
End Module
