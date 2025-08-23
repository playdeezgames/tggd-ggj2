Imports TGGDGGJ2.Data

Public MustInherit Class InventoryEntity(Of TEntityData As InventoryEntityData)
    Inherits Entity(Of TEntityData)
    Implements IInventoryEntity

    Protected Sub New(data As WorldData, playSfx As Action(Of String))
        MyBase.New(data, playSfx)
    End Sub

    Public ReadOnly Property HasItems As Boolean Implements IInventoryEntity.HasItems
        Get
            Return EntityData.ItemIds.Any
        End Get
    End Property

    Public ReadOnly Property ItemCount As Integer Implements IInventoryEntity.ItemCount
        Get
            Return EntityData.ItemIds.Count
        End Get
    End Property

    Public ReadOnly Property Items As IEnumerable(Of IItem) Implements IInventoryEntity.Items
        Get
            Return EntityData.ItemIds.Select(Function(x) New Item(Data, x, PlaySfx))
        End Get
    End Property

    Public Sub AddItem(item As IItem) Implements IInventoryEntity.AddItem
        EntityData.ItemIds.Add(item.ItemId)
    End Sub
End Class
