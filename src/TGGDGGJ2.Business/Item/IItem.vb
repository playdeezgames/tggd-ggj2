Public Interface IItem
    Inherits IEntity
    ReadOnly Property ItemType As String
    ReadOnly Property ItemId As Integer
    Sub Initialize()
End Interface
