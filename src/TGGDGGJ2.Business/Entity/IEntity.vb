Public Interface IEntity
    ReadOnly Property World As IWorld
    Function GetMetadata(metadataType As String) As String
    Sub SetMetadata(metadataType As String, value As String)
    Function GetStatistic(statisticType As String) As Integer
    Sub SetStatistic(statisticType As String, value As Integer?)
End Interface
