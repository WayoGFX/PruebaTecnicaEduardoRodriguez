Public Class NegocioException
    Inherits Exception
    Public Sub New(mensaje As String)
        MyBase.New(mensaje)
    End Sub
End Class