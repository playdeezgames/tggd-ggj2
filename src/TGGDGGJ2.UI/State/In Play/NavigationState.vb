Imports TGGD.UI
Imports TGGDGGJ2.Business

Friend Class NavigationState
    Implements IUIState

    ReadOnly GAME_MENU_IDENTIFIER As String = NameOf(GAME_MENU_IDENTIFIER)
    Const GAME_MENU_TEXT = "GAME MENU"

    Private ReadOnly buffer As IUIBuffer(Of Integer)
    Private ReadOnly world As Business.IWorld
    Private ReadOnly playSfx As Action(Of String)
    Private ReadOnly menuItems As New List(Of (Identifier As String, Text As String))
    Private menuItemIndex As Integer
    Private menuItemRefresh As Boolean = True

    Public Sub New(buffer As IUIBuffer(Of Integer), world As Business.IWorld, playSfx As Action(Of String))
        Me.buffer = buffer
        Me.world = world
        Me.playSfx = playSfx
    End Sub

    Public Sub Refresh() Implements IUIState.Refresh
        RefreshMenuItems()
        buffer.Fill(MagentaBlock)
        buffer.WriteInvertedCenteredText(0, $"DAY {world.GetStatistic(StatisticType.Day)} HOUR {world.GetStatistic(StatisticType.Hour)}")
        Dim character = world.Avatar
        buffer.WriteText((0, 1), $"LOCATION: {character.Location.GetMetadata(MetadataType.Name)}")
        Dim menuItem = menuItems(menuItemIndex)
        buffer.WriteText((0, buffer.Rows - 1), "<")
        buffer.WriteText((buffer.Columns - 1, buffer.Rows - 1), ">")
        buffer.WriteInvertedCenteredText(buffer.Rows - 1, menuItem.Text)
    End Sub

    Private Sub RefreshMenuItems()
        If menuItemRefresh Then
            menuItems.Clear()
            menuItems.AddRange(world.Avatar.AvailableVerbs)
            menuItems.Add((GAME_MENU_IDENTIFIER, GAME_MENU_TEXT))
            menuItemIndex = 0
            menuItemRefresh = False
        End If
    End Sub

    Public Function HandleCommand(command As String) As IUIState Implements IUIState.HandleCommand
        Select Case command
            Case UI.Command.Left
                menuItemIndex = (menuItemIndex + menuItems.Count - 1) Mod menuItems.Count
                Return Me
            Case UI.Command.Right
                menuItemIndex = (menuItemIndex + 1) Mod menuItems.Count
                Return Me
            Case UI.Command.Green
                Return HandleMenuItem(menuItems(menuItemIndex).Identifier)
            Case Else
                Return Me
        End Select
    End Function

    Private Function HandleMenuItem(identifier As String) As IUIState
        Select Case identifier
            Case GAME_MENU_IDENTIFIER
                Return New GameMenuState(buffer, world, playSfx)
            Case Else
                Return Me
        End Select
    End Function
End Class
