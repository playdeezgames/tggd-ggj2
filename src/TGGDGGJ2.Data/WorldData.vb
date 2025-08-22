Public Class WorldData
    Inherits EntityData
    Public Property Locations As New List(Of LocationData)
    Public Property Characters As New List(Of CharacterData)
    Public Property AvatarId As Integer?
    Public Property Messages As New List(Of MessageData)
End Class
