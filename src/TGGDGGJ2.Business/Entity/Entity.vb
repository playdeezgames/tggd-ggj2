Imports TGGDGGJ2.Data

Public MustInherit Class Entity(Of TEntityData)
    Implements IEntity
    Protected ReadOnly Property Data As WorldData
    Protected ReadOnly Property PlaySfx As Action(Of String)
    Sub New(data As WorldData, playSfx As Action(Of String))
        Me.Data = data
        Me.PlaySfx = playSfx
    End Sub
    Protected MustOverride ReadOnly Property EntityData As TEntityData
    Public ReadOnly Property World As IWorld Implements IEntity.World
        Get
            Return New World(Data, PlaySfx)
        End Get
    End Property
End Class
