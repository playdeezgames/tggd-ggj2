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
    MustOverride Function Describe(location As ILocation) As IEnumerable(Of String)
End Class
