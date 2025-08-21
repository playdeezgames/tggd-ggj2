Friend MustInherit Class LocationTypeDescriptor
    Friend ReadOnly Property LocationType As String
    Friend ReadOnly Property LocationCount As Integer
    Sub New(
           locationType As String,
           locationCount As Integer)
        Me.LocationType = locationType
        Me.LocationCount = locationCount
    End Sub
    MustOverride Sub OnInitialize(location As ILocation)
End Class
