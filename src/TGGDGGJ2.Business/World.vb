Imports TGGDGGJ2.Data

Public Class World
    Implements IWorld
    Private ReadOnly data As WorldData
    Private ReadOnly playSfx As Action(Of String)
    Sub New(data As WorldData, playSfx As Action(Of String))
        Me.data = data
        Me.playSfx = playSfx
    End Sub
End Class
