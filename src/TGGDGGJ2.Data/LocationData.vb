Public Class LocationData
    Inherits InventoryEntityData
    Public Property LocationType As String
    Public Property Characters As New HashSet(Of Integer)
End Class
