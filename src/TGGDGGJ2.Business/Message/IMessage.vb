﻿Public Interface IMessage
    ReadOnly Property LineCount As Integer
    ReadOnly Property Lines As IEnumerable(Of String)
End Interface
