Public Interface IDialog
    ReadOnly Property Caption As String
    ReadOnly Property Choices As IEnumerable(Of (Choice As String, Text As String))
    Function Choose(choice As String) As IDialog
End Interface
