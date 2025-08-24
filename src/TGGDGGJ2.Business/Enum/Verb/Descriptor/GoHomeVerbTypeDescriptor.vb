Friend Class GoHomeVerbTypeDescriptor
    Inherits VerbTypeDescriptor

    Public Sub New()
        MyBase.New(
            Business.VerbType.GoHome,
            "GO HOME",
            1)
    End Sub

    Public Overrides Function CanPerform(character As ICharacter) As Boolean
        Return character.Location.LocationType <> LocationType.Home
    End Function

    Public Overrides Function Perform(character As ICharacter) As IDialog
        character.Location = character.World.Locations.Single(Function(x) x.LocationType = Home)
        character.AddMessage("YOU ARRIVE BACK HOME.")
        Return Nothing
    End Function
End Class
