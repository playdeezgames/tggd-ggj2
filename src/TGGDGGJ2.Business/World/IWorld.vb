Public Interface IWorld
    Inherits IEntity
    Sub Clear()
    Function CreateLocation(locationType As String) As ILocation
End Interface
