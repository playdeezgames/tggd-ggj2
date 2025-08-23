Imports TGGDGGJ2.Data

Friend Class Item
    Inherits Entity(Of ItemData)
    Implements IItem

    Public Sub New(data As WorldData, itemId As Integer, playSfx As Action(Of String))
        MyBase.New(data, playSfx)
        Me.ItemId = itemId
    End Sub

    Public ReadOnly Property ItemType As String Implements IItem.ItemType
        Get
            Return EntityData.ItemType
        End Get
    End Property

    Public ReadOnly Property ItemId As Integer Implements IItem.ItemId

    Protected Overrides ReadOnly Property EntityData As ItemData
        Get
            Return Data.Items(ItemId)
        End Get
    End Property

    Public Sub Initialize() Implements IItem.Initialize
        ItemType.ToItemTypeDescriptor.OnInitialize(Me)
    End Sub
End Class
