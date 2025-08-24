Friend Class InventoryVerbTypeDescriptor
    Inherits VerbTypeDescriptor

    Public Sub New()
        MyBase.New(
            Business.VerbType.Inventory,
            "INVENTORY",
            5)
    End Sub

    Public Overrides Function CanPerform(character As ICharacter) As Boolean
        Return True
    End Function

    Public Overrides Function Perform(character As ICharacter) As IDialog
        Return New InventoryDialog(character)
    End Function
End Class
