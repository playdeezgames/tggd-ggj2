Friend Class HomeLocationTypeDescriptor
    Inherits LocationTypeDescriptor

    Public Sub New()
        MyBase.New(Business.LocationType.Home)
    End Sub

    Public Overrides Sub OnInitialize(location As ILocation)
    End Sub
End Class
