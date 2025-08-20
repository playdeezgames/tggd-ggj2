Friend Class GoToStoreVerbTypeDescriptor
    Inherits VerbTypeDescriptor

    Public Sub New()
        MyBase.New(Business.VerbType.GoToStore, "GO TO STORE")
    End Sub

    Public Overrides Function CanPerform(character As ICharacter) As Boolean
        Return character.Location.LocationType = Business.LocationType.Home
    End Function
End Class
