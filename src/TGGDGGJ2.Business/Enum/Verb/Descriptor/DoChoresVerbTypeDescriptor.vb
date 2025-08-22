Friend Class DoChoresVerbTypeDescriptor
    Inherits VerbTypeDescriptor

    Public Sub New()
        MyBase.New(Business.VerbType.DoChores, "DO CHORES")
    End Sub

    Public Overrides Function CanPerform(character As ICharacter) As Boolean
        Return character.Location.LocationType = LocationType.Home AndAlso character.World.GetStatistic(StatisticType.Hour) < character.World.GetStatisticMaximum(StatisticType.Hour)
    End Function

    Public Overrides Function Perform(character As ICharacter) As IDialog
        Return New DoChoresDialog(character)
    End Function
End Class
