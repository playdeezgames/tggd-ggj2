Imports TGGDGGJ2.Data

Public MustInherit Class InventoryEntity(Of TEntityData As InventoryEntityData)
    Inherits Entity(Of TEntityData)
    Implements IInventoryEntity

    Protected Sub New(data As WorldData, playSfx As Action(Of String))
        MyBase.New(data, playSfx)
    End Sub

    Public Sub AddItem(item As IItem) Implements IInventoryEntity.AddItem
        EntityData.ItemIds.Add(item.ItemId)
    End Sub
End Class
