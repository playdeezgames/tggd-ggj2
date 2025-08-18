Imports TGGD.UI
Imports TGGDGGJ2.Business

Friend Class MainMenuState
    Inherits PickerState
    Const EMBARK_TEXT = "EMBARK!"
    Const STORY_TEXT = "STORY!"
    Const ABOUT_TEXT = "ABOUT!"
    Private ReadOnly world As IWorld
    Private ReadOnly playSfx As Action(Of String)

    Public Sub New(buffer As IUIBuffer(Of Integer), world As IWorld, playSfx As Action(Of String))
        MyBase.New(
            buffer,
            "MAIN MENU",
            {
                (EMBARK_TEXT, EMBARK_TEXT),
                (STORY_TEXT, STORY_TEXT),
                (ABOUT_TEXT, ABOUT_TEXT)
            })
        Me.world = world
        Me.playSfx = playSfx
    End Sub

    Protected Overrides Function HandleCancel() As IUIState
        Return Me
    End Function

    Protected Overrides Function HandlePick(pick As String) As IUIState
        Select Case pick
            Case STORY_TEXT
                Return New StoryState(buffer, world, playSfx)
            Case ABOUT_TEXT
                Return New AboutState(buffer, world, playSfx)
            Case Else
                Return Me
        End Select
    End Function
End Class
