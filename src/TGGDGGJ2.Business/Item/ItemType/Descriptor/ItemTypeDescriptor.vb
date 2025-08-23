Friend MustInherit Class ItemTypeDescriptor
    ReadOnly Property ItemType As String
    ReadOnly Property ItemCount As Integer
    Sub New(itemType As String, itemCount As Integer)
        Me.ItemType = itemType
        Me.ItemCount = itemCount
    End Sub

    Friend MustOverride Sub OnInitialize(item As Item)
End Class
