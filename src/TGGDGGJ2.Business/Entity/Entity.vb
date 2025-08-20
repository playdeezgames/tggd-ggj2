Imports TGGDGGJ2.Data

Public MustInherit Class Entity(Of TEntityData As EntityData)
    Implements IEntity
    Protected ReadOnly Property Data As WorldData
    Protected ReadOnly Property PlaySfx As Action(Of String)
    Sub New(data As WorldData, playSfx As Action(Of String))
        Me.Data = data
        Me.PlaySfx = playSfx
    End Sub

    Public Function GetMetadata(metadataType As String) As String Implements IEntity.GetMetadata
        Dim result As String = Nothing
        If EntityData.Metadatas.TryGetValue(metadataType, result) Then
            Return result
        End If
        Return Nothing
    End Function

    Protected MustOverride ReadOnly Property EntityData As TEntityData
    Public ReadOnly Property World As IWorld Implements IEntity.World
        Get
            Return New World(Data, PlaySfx)
        End Get
    End Property
End Class
