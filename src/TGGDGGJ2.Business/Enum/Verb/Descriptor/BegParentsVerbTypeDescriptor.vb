Imports TGGD.Business

Friend Class BegParentsVerbTypeDescriptor
    Inherits VerbTypeDescriptor

    Public Sub New()
        MyBase.New(Business.VerbType.BegParents, "BEG PARENTS", 1)
    End Sub

    Public Overrides Function CanPerform(character As ICharacter) As Boolean
        Return character.Location.LocationType = LocationType.Home AndAlso character.GetStatistic(StatisticType.DaysSinceGift) > 0
    End Function

    Public Overrides Function Perform(character As ICharacter) As IDialog
        Dim daysSinceGift = character.GetStatistic(StatisticType.DaysSinceGift)
        If RNG.RollXDY(2, 6) < daysSinceGift Then
            Dim item = character.World.CreateItem(ItemType.Squishmallow)
            character.AddItem(item)
            character.SetStatistic(StatisticType.DaysSinceGift, 0)
            character.AddMessage($"THEY GET YOU", $"{item.GetName}!")
        Else
            character.AddMessage($"SORRY, WE GOT YOU ONE", $"{daysSinceGift} DAY{If(daysSinceGift > 1, "S", "")} AGO!")
        End If
        Return Nothing
    End Function
End Class
