Imports TGGDGGJ2.Data

Public Class Character
    Inherits Entity(Of CharacterData)
    Implements ICharacter

    Public Sub New(data As WorldData, characterId As Integer, playSfx As Action(Of String))
        MyBase.New(data, playSfx)
        Me.CharacterId = characterId
    End Sub

    Public ReadOnly Property CharacterId As Integer Implements ICharacter.CharacterId

    Public ReadOnly Property CharacterType As String Implements ICharacter.CharacterType
        Get
            Return EntityData.CharacterType
        End Get
    End Property

    Public ReadOnly Property Location As ILocation Implements ICharacter.Location
        Get
            Return New Location(Data, EntityData.LocationId, PlaySfx)
        End Get
    End Property

    Protected Overrides ReadOnly Property EntityData As CharacterData
        Get
            Return Data.Characters(CharacterId)
        End Get
    End Property
End Class
