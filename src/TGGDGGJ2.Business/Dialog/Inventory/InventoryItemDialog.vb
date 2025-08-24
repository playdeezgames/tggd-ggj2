Friend Class InventoryItemDialog
    Inherits BaseDialog
    Implements IDialog

    Private ReadOnly character As ICharacter
    Private ReadOnly item As IItem

    Public Sub New(character As ICharacter, item As IItem)
        Me.character = character
        Me.item = item
    End Sub

    Public ReadOnly Property Caption As String Implements IDialog.Caption
        Get
            Return item.GetName
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
            Dim ownedCount = character.Items.Count(Function(x) x.ItemType = ItemType.Squishmallow AndAlso x.GetName = item.GetName)
            Return {
                $"YOU OWN {ownedCount}"
                }
        End Get
    End Property

    Public Function Choose(choice As String) As IDialog Implements IDialog.Choose
        Select Case choice
            Case NEVER_MIND_CHOICE
                Return New InventoryDialog(character)
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Class
