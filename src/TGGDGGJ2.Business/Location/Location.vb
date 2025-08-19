Imports TGGDGGJ2.Data

Public Class Location
    Inherits Entity(Of LocationData)
    Implements ILocation
    Public Sub New(data As WorldData, locationId As Integer, playSfx As Action(Of String))
        MyBase.New(data, playSfx)
        Me.LocationId = locationId
    End Sub
    Public ReadOnly Property LocationId As Integer Implements ILocation.LocationId

    Public ReadOnly Property LocationType As String Implements ILocation.LocationType
        Get
            Return EntityData.LocationType
        End Get
    End Property

    Protected Overrides ReadOnly Property EntityData As LocationData
        Get
            Return Data.Locations(LocationId)
        End Get
    End Property

    Public Sub AddCharacter(character As ICharacter) Implements ILocation.AddCharacter
        EntityData.Characters.Add(character.CharacterId)
    End Sub
End Class
