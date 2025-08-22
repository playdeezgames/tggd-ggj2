Friend Class DoChoresDialog
    Implements IDialog

    Private ReadOnly character As ICharacter
    Shared ReadOnly DONE_IDENTIFIER As String = NameOf(DONE_IDENTIFIER)
    Const DONE_TEXT = "DONE!"
    Shared ReadOnly DO_MORE_IDENTIFIER As String = NameOf(DO_MORE_IDENTIFIER)
    Const DO_MORE_TEXT = "DO MORE!"

    Public Sub New(character As ICharacter)
        Me.character = character
        character.ChangeStatistic(StatisticType.Money, 1)
        character.World.ChangeStatistic(StatisticType.Hour, 1)
        Lines = {
            "YOU DO SOME CHORES!",
            "YOU EARN $1",
            $"YOU HAVE ${character.GetStatistic(StatisticType.Money)}"
        }.ToList
        Caption = $"DAY {character.World.GetStatistic(StatisticType.Day)} HOUR {character.World.GetStatistic(StatisticType.Hour)}"
    End Sub

    Public ReadOnly Property Caption As String Implements IDialog.Caption

    Public ReadOnly Property Choices As IEnumerable(Of (Choice As String, Text As String)) Implements IDialog.Choices
        Get
            Dim result As New List(Of (Choice As String, Text As String)) From {
                (DONE_IDENTIFIER, DONE_TEXT)
            }
            If character.World.GetStatistic(StatisticType.Hour) < character.World.GetStatisticMaximum(StatisticType.Hour) Then
                result.Add((DO_MORE_IDENTIFIER, DO_MORE_TEXT))
            End If
            Return result
        End Get
    End Property

    Public ReadOnly Property Lines As IEnumerable(Of String) Implements IDialog.Lines

    Public Function Choose(choice As String) As IDialog Implements IDialog.Choose
        Select Case choice
            Case DONE_IDENTIFIER
                Return Nothing
            Case DO_MORE_IDENTIFIER
                Return New DoChoresDialog(character)
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Class
