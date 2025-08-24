Friend Class InventoryDialog
    Inherits BaseDialog
    Implements IDialog

    Private ReadOnly character As ICharacter

    Public Sub New(character As ICharacter)
        Me.character = character
    End Sub

    Public ReadOnly Property Caption As String Implements IDialog.Caption
        Get
            Return "INVENTORY"
        End Get
    End Property

    Public ReadOnly Property Choices As IEnumerable(Of (Choice As String, Text As String)) Implements IDialog.Choices
        Get
            Dim result As New List(Of (Choice As String, Text As String)) From {
                (NEVER_MIND_CHOICE, NEVER_MIND_TEXT)
            }
            result.AddRange(character.Items.OrderBy(Function(x) x.GetName).Select(Function(x) (x.ItemId.ToString, x.GetName)))
            Return result
        End Get
    End Property

    Public ReadOnly Property Lines As IEnumerable(Of String) Implements IDialog.Lines
        Get
            Return {
                $"ITEM COUNT: {character.Items.Count}"
                }
        End Get
    End Property

    Public Function Choose(choice As String) As IDialog Implements IDialog.Choose
        Select Case choice
            Case NEVER_MIND_CHOICE
                Return Nothing
            Case Else
                Return New InventoryItemDialog(character, character.World.GetItem(CInt(choice)))
        End Select
    End Function
End Class
