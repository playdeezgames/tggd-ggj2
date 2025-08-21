Friend Class GoToStoreDialog
    Implements IDialog

    Private ReadOnly character As ICharacter

    Shared ReadOnly NEVER_MIND_CHOICE As String = NameOf(NEVER_MIND_CHOICE)

    Public Sub New(character As ICharacter)
        Me.character = character
    End Sub

    Public ReadOnly Property Caption As String Implements IDialog.Caption
        Get
            Return "WHICH STORE?"
        End Get
    End Property

    Public ReadOnly Property Choices As IEnumerable(Of (Choice As String, Text As String)) Implements IDialog.Choices
        Get
            Dim result As New List(Of (Choice As String, Text As String)) From
                {
                    (NEVER_MIND_CHOICE, "NEVER MIND")
                }
            For Each storeLocation In character.World.Locations.Where(Function(x) x.LocationType = LocationType.Store AndAlso x.LocationId <> character.Location.LocationId).OrderBy(Function(x) x.GetName())
                result.Add((storeLocation.GetName(), storeLocation.GetDisplayName()))
            Next
            Return result
        End Get
    End Property

    Public Function Choose(choice As String) As IDialog Implements IDialog.Choose
        Select Case choice
            Case NEVER_MIND_CHOICE
                Return Nothing
            Case Else
                Dim storeLocation = character.World.Locations.Single(Function(x) x.GetName() = choice)
                character.Location = storeLocation
                Return Nothing
        End Select
    End Function
End Class
