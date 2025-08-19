Friend MustInherit Class LocationTypeDescriptor
    Friend ReadOnly Property LocationType As String
    Sub New(locationType As String)
        Me.LocationType = locationType
    End Sub
    MustOverride Sub OnInitialize(location As ILocation)
End Class
