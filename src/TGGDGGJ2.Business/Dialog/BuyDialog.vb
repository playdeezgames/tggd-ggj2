Friend Class BuyDialog
    Implements IDialog

    Private ReadOnly character As ICharacter
    Shared ReadOnly NEVER_MIND_CHOICE As String = NameOf(NEVER_MIND_CHOICE)
    Const NEVER_MIND_TEXT = "NEVER MIND"

    Public Sub New(character As ICharacter)
        Me.character = character
    End Sub

    Public ReadOnly Property Caption As String Implements IDialog.Caption
        Get
            Return "BUY..."
        End Get
    End Property

    Public ReadOnly Property Choices As IEnumerable(Of (Choice As String, Text As String)) Implements IDialog.Choices
        Get
            Dim result As New List(Of (Choice As String, Text As String)) From {
                (NEVER_MIND_CHOICE, NEVER_MIND_TEXT)
            }
            result.AddRange(character.Location.Items.Select(Function(x) (x.ItemId.ToString(), x.GetName)))
            Return result
        End Get
    End Property

    Public ReadOnly Property Lines As IEnumerable(Of String) Implements IDialog.Lines
        Get
            Return {
                $"{character.Location.ItemCount} ITEMS AVAILABLE!"
                }
        End Get
    End Property

    Public Function Choose(choice As String) As IDialog Implements IDialog.Choose
        Select Case choice
            Case NEVER_MIND_CHOICE
                Return Nothing
            Case Else
                Dim itemId = CInt(choice)
                Return New BuyItemDialog(character, character.World.GetItem(itemId))
        End Select
    End Function
End Class
