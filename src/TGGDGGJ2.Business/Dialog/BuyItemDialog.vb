Imports System.Reflection

Friend Class BuyItemDialog
    Implements IDialog
    Shared ReadOnly NEVER_MIND_CHOICE As String = NameOf(NEVER_MIND_CHOICE)
    Const NEVER_MIND_TEXT = "NEVER MIND"
    Shared ReadOnly BUY_CHOICE As String = NameOf(BUY_CHOICE)
    Const BUY_TEXT = "BUY!"

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
            If character.GetStatistic(StatisticType.Money) >= item.GetStatistic(StatisticType.Price) Then
                result.Add((BUY_CHOICE, BUY_TEXT))
            End If
            Return result
        End Get
    End Property

    Public ReadOnly Property Lines As IEnumerable(Of String) Implements IDialog.Lines
        Get
            Dim result As New List(Of String) From {
                $"PRICE: ${item.GetStatistic(StatisticType.Price)}"
            }
            Return result
        End Get
    End Property

    Public Function Choose(choice As String) As IDialog Implements IDialog.Choose
        Select Case choice
            Case NEVER_MIND_CHOICE
                Return New BuyDialog(character)
            Case BUY_CHOICE
                character.Location.RemoveItem(item)
                character.AddItem(item)
                character.ChangeStatistic(StatisticType.Money, item.GetStatistic(StatisticType.Price))
                character.AddMessage({$"YOU BOUGHT", $"{item.GetMetadata(MetadataType.Name)}!"})
                Return Nothing
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Class
