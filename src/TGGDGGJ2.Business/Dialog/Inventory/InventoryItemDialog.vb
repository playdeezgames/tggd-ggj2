Imports TGGD.Business

Friend Class InventoryItemDialog
    Inherits BaseDialog
    Implements IDialog

    Shared ReadOnly SELL_ONE_CHOICE As String = NameOf(SELL_ONE_CHOICE)
    Const SELL_ONE_TEXT = "SELL ONE ON SQUEEBAY!"

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
            Dim ownedCount = character.GetOwnedSquichmallowCount(item.GetName)
            Dim result As New List(Of (Choice As String, Text As String)) From {
                (NEVER_MIND_CHOICE, NEVER_MIND_TEXT)
            }
            If ownedCount > 1 Then
                result.Add((SELL_ONE_CHOICE, SELL_ONE_TEXT))
            End If
            Return result
        End Get
    End Property

    Public ReadOnly Property Lines As IEnumerable(Of String) Implements IDialog.Lines
        Get
            Dim ownedCount = character.GetOwnedSquichmallowCount(item.GetName)
            Return {
                $"YOU OWN {ownedCount}",
                $"VALUE: ${item.GetStatistic(StatisticType.Price)} EACH"
                }
        End Get
    End Property

    Public Function Choose(choice As String) As IDialog Implements IDialog.Choose
        Select Case choice
            Case NEVER_MIND_CHOICE
                Return New InventoryDialog(character)
            Case SELL_ONE_CHOICE
                SellOnSqueebay()
                Return Nothing
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Shared ReadOnly sellPriceMultiplierTable As IReadOnlyDictionary(Of Double, Integer) =
        New Dictionary(Of Double, Integer) From
        {
            {0.5, 1},
            {0.6, 2},
            {0.7, 3},
            {0.8, 4},
            {0.9, 5},
            {1.0, 6},
            {1.2, 5},
            {1.4, 4},
            {1.6, 3},
            {1.8, 2},
            {2.0, 1}
        }

    Private Sub SellOnSqueebay()
        Dim price = item.GetStatistic(StatisticType.Price)
        Dim sellPrice = CInt(RNG.FromGenerator(sellPriceMultiplierTable) * price)
        Dim result As New List(Of String) From
            {
                $"YOU SELL ONE FOR ${sellPrice}",
                "ON SQUEEBAY!"
            }
        If price > sellPrice Then
            result.Add($"(${price - sellPrice} UNDER VALUE!)")
        ElseIf price < sellPrice Then
            result.Add($"(${sellPrice - price} OVER VALUE!)")
        Else
            result.Add("(YOU BROKE EVEN!)")
        End If
        character.RemoveItem(item)
        character.ChangeStatistic(StatisticType.Money, sellPrice)
        character.AddMessage(result.ToArray)
    End Sub
End Class
