Friend Class StatisticsVerbTypeDescriptor
    Inherits VerbTypeDescriptor

    Public Sub New()
        MyBase.New(Business.VerbType.Statistics, "STATISTICS")
    End Sub

    Public Overrides Function CanPerform(character As ICharacter) As Boolean
        Return True
    End Function

    Public Overrides Function Perform(character As ICharacter) As IDialog
        character.AddMessage($"MONEY: ${character.GetStatistic(StatisticType.Money)}")
        Return Nothing
    End Function
End Class
