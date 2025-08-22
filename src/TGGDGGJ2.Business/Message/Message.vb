Imports TGGDGGJ2.Data

Friend Class Message
    Implements IMessage

    Private ReadOnly data As WorldData

    Public Sub New(data As WorldData)
        Me.data = data
    End Sub

    Public ReadOnly Property LineCount As Integer Implements IMessage.LineCount
        Get
            Return data.Messages.First.Lines.Count
        End Get
    End Property

    Public ReadOnly Property Lines As IEnumerable(Of String) Implements IMessage.Lines
        Get
            Return data.Messages.First.Lines
        End Get
    End Property
End Class
