Public Interface IEntity
    ReadOnly Property World As IWorld
    Function GetMetadata(metadataType As String) As String
End Interface
