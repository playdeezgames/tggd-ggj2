Public Interface IEntity
    ReadOnly Property World As IWorld
    Function GetMetadata(metadataType As String) As String
    Sub SetMetadata(metadataType As String, value As String)
End Interface
