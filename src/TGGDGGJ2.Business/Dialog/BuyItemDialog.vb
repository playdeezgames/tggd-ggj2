Friend Class BuyItemDialog
    Implements IDialog
    Shared ReadOnly NEVER_MIND_CHOICE As String = NameOf(NEVER_MIND_CHOICE)
    Const NEVER_MIND_TEXT = "NEVER MIND"

    Private ReadOnly character As ICharacter
    Private ReadOnly item As IItem

    Public Sub New(character As ICharacter, item As IItem)
        Me.character = character
        Me.item = item
    End Sub

    Public ReadOnly Property Caption As String Implements IDialog.Caption
        Get
            Return item.GetMetadata(MetadataType.Name).ToUpper
        End Get
    End Property

    Public ReadOnly Property Choices As IEnumerable(Of (Choice As String, Text As String)) Implements IDialog.Choices
        Get
            Dim result As New List(Of (Choice As String, Text As String)) From {
                (NEVER_MIND_CHOICE, NEVER_MIND_TEXT)
            }
            Return result
        End Get
    End Property

    Public ReadOnly Property Lines As IEnumerable(Of String) Implements IDialog.Lines
        Get
            Return {}
        End Get
    End Property

    Public Function Choose(choice As String) As IDialog Implements IDialog.Choose
        Select Case choice
            Case NEVER_MIND_CHOICE
                Return New BuyDialog(character)
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Class
