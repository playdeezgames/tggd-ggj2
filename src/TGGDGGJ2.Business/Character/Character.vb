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

    Public Property Location As ILocation Implements ICharacter.Location
        Get
            Return New Location(Data, EntityData.LocationId, PlaySfx)
        End Get
        Set(value As ILocation)
            Dim oldLocation = Me.Location
            If oldLocation.LocationId <> value.LocationId Then
                oldLocation.RemoveCharacter(Me)
                EntityData.LocationId = value.LocationId
                value.AddCharacter(Me)
            End If
        End Set
    End Property

    Public ReadOnly Property AvailableVerbs As IEnumerable(Of (Identifier As String, Text As String)) Implements ICharacter.AvailableVerbs
        Get
            Return VerbTypes.All.Where(Function(x) CanPerform(x)).Select(Function(x) (x, x.ToVerbTypeDescriptor.Caption))
        End Get
    End Property

    Private Function CanPerform(verbType As String) As Boolean
        Return verbType.ToVerbTypeDescriptor.CanPerform(Me)
    End Function

    Public Function Perform(verbType As String) As IDialog Implements ICharacter.Perform
        Return verbType.ToVerbTypeDescriptor.Perform(Me)
    End Function

    Protected Overrides ReadOnly Property EntityData As CharacterData
        Get
            Return Data.Characters(CharacterId)
        End Get
    End Property
End Class
