Friend Class BuyVerbTypeDescriptor
    Inherits VerbTypeDescriptor

    Public Sub New()
        MyBase.New(Business.VerbType.Buy, "BUY...")
    End Sub

    Public Overrides Function CanPerform(character As ICharacter) As Boolean
        Dim location = character.Location
        If location.LocationType <> LocationType.Store Then
            Return False
        End If
        If Not location.IsOpen Then
            Return False
        End If
        If Not location.HasItems Then
            Return False
        End If
        Return True
    End Function
    Public Overrides Function Perform(character As ICharacter) As IDialog
        Return New BuyDialog(character)
    End Function
End Class
