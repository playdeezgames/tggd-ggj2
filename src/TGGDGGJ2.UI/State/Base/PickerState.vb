Imports TGGD.UI

Friend MustInherit Class PickerState
    Implements IUIState
    Protected ReadOnly buffer As IUIBuffer(Of Integer)
    Private ReadOnly caption As String
    Private ReadOnly lines As String()
    Private ReadOnly menuItems As (Identifier As String, Text As String)()
    Private menuItemIndex As Integer = 0
    Sub New(
           buffer As IUIBuffer(Of Integer),
           caption As String,
           lines As String(),
           menuItems As (Identifier As String, Text As String)())
        Me.buffer = buffer
        Me.caption = caption
        Me.menuItems = menuItems
        Me.lines = lines
    End Sub

    Public Sub Refresh() Implements IUIState.Refresh
        buffer.Fill(MagentaBlock)
        Dim centerY = (buffer.Rows - (lines.Length + 1)) \ 2
        Dim y = centerY - menuItemIndex
        For Each menuItem In menuItems
            If y > lines.Length AndAlso y < buffer.Rows Then
                buffer.WriteCenteredText(y, menuItem.Text)
            End If
            y += 1
        Next
        y = 1
        For Each line In lines
            buffer.WriteCenteredText(y, line)
            y += 1
        Next
        buffer.Invert(0, centerY, buffer.Columns, 1)
        buffer.WriteCenteredText(0, caption)
        buffer.Invert(0, 0, buffer.Columns, 1)
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
