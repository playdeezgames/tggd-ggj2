Imports TGGD.UI

Friend Class ConfirmState
    Inherits PickerState
    Shared ReadOnly NO_IDENTIFIER As String = NameOf(NO_IDENTIFIER)
    Shared ReadOnly YES_IDENTIFIER As String = NameOf(YES_IDENTIFIER)
    Const NO_TEXT = "NO"
    Const YES_TEXT = "YES"
    ReadOnly confirmDialog As Func(Of IUIState)
    ReadOnly cancelDialog As Func(Of IUIState)
    Public Sub New(
                  buffer As IUIBuffer(Of Integer),
                  caption As String,
                  confirmDialog As Func(Of IUIState),
                  cancelDialog As Func(Of IUIState))
        MyBase.New(buffer, caption, {}, {(NO_IDENTIFIER, NO_TEXT), (YES_IDENTIFIER, YES_TEXT)})
        Me.confirmDialog = confirmDialog
        Me.cancelDialog = cancelDialog
    End Sub

    Protected Overrides Function HandleCancel() As IUIState
        Return cancelDialog()
    End Function

    Protected Overrides Function HandlePick(pick As String) As IUIState
        Select Case pick
            Case YES_IDENTIFIER
                Return confirmDialog()
            Case NO_IDENTIFIER
                Return cancelDialog()
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Class
