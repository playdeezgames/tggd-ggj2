Imports TGGD.UI

Friend MustInherit Class PickerState
    Implements IUIState
    Protected ReadOnly buffer As IUIBuffer(Of Integer)
    Private ReadOnly caption As String
    Private ReadOnly menuItems As (Identifier As String, Text As String)()
    Private menuItemIndex As Integer = 0
    Sub New(
           buffer As IUIBuffer(Of Integer),
           caption As String,
           menuItems As (Identifier As String, Text As String)())
        Me.buffer = buffer
        Me.caption = caption
        Me.menuItems = menuItems
    End Sub

    Public Sub Refresh() Implements IUIState.Refresh
        buffer.Fill(MagentaBlock)
        Dim y = buffer.Rows \ 2 - menuItemIndex
        For Each menuItem In menuItems
            If y > 0 AndAlso y < buffer.Rows Then
                buffer.WriteCenteredText(y, menuItem.Text)
            End If
            y += 1
        Next
        buffer.Invert(0, buffer.Rows \ 2, buffer.Columns, 1)
        buffer.WriteCenteredText(0, caption)
        buffer.Invert(0, 0, buffer.Columns, 1)
        'TODO: bottom controls?
    End Sub

    Public Function HandleCommand(command As String) As IUIState Implements IUIState.HandleCommand
        Select Case command
            Case UI.Command.Up
                menuItemIndex = (menuItemIndex + menuItems.Length - 1) Mod menuItems.Length
                Return Me
            Case UI.Command.Down
                menuItemIndex = (menuItemIndex + 1) Mod menuItems.Length
                Return Me
            Case UI.Command.Green
                Return HandlePick(menuItems(menuItemIndex).Identifier)
            Case UI.Command.Red
                Return HandleCancel()
            Case Else
                Return Me
        End Select
    End Function

    Protected MustOverride Function HandleCancel() As IUIState
    Protected MustOverride Function HandlePick(pick As String) As IUIState
End Class
