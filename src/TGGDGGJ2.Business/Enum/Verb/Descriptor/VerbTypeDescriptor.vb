Friend MustInherit Class VerbTypeDescriptor
    Friend ReadOnly VerbType As String
    Friend ReadOnly Caption As String
    Friend ReadOnly Ordinal As Integer
    Sub New(verbType As String, caption As String, ordinal As Integer)
        Me.VerbType = verbType
        Me.Caption = caption
        Me.Ordinal = ordinal
    End Sub
    MustOverride Function CanPerform(character As ICharacter) As Boolean
    MustOverride Function Perform(character As ICharacter) As IDialog
End Class
