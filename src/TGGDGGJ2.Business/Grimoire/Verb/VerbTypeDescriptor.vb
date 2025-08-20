Friend MustInherit Class VerbTypeDescriptor
    Friend ReadOnly VerbType As String
    Friend ReadOnly Caption As String
    Sub New(verbType As String, caption As String)
        Me.VerbType = verbType
        Me.Caption = caption
    End Sub
    MustOverride Function CanPerform(character As ICharacter) As Boolean
End Class
