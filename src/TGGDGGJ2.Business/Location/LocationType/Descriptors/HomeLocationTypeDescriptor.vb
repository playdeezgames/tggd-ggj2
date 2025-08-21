Friend Class HomeLocationTypeDescriptor
    Inherits LocationTypeDescriptor

    Public Sub New()
        MyBase.New(Business.LocationType.Home, 1)
    End Sub

    Public Overrides Sub OnInitialize(location As ILocation)
        location.SetMetadata(MetadataType.Name, "HOME")
    End Sub

    Public Overrides Function Describe(location As ILocation) As IEnumerable(Of String)
        Return {
            "HOME IS WHERE YOU KEEP YER",
            "SQUISHMALLOWS."
            }
    End Function
End Class
