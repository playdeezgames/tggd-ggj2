Friend Class GoToBedVerbTypeDescriptor
    Inherits VerbTypeDescriptor

    Public Sub New()
        MyBase.New(
            Business.VerbType.GoToBed,
            "GO TO BED",
            1)
    End Sub

    Public Overrides Function CanPerform(character As ICharacter) As Boolean
        Return character.World.GetStatistic(StatisticType.Hour) = character.World.GetStatisticMaximum(StatisticType.Hour)
    End Function

    Public Overrides Function Perform(character As ICharacter) As IDialog
        Dim world = character.World
        world.ChangeStatistic(StatisticType.Day, 1)
        world.SetStatistic(StatisticType.Hour, world.GetStatisticMinimum(StatisticType.Hour))
        character.AddMessage("YOU SLEEP UNTIL MORNING.")
        Return Nothing
    End Function
End Class
