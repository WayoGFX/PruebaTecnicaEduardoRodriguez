Imports System.Security.Cryptography
Public Class PasswordHelper

    Private Const TamanoSalt As Integer = 16
    Private Const TamanoHash As Integer = 32
    Private Const Iteraciones As Integer = 100000

    ' Genera iteraciones.salt.hash a partir de la contraseña en texto plano
    Public Shared Function GenerarHash(password As String) As String
        Dim salt(TamanoSalt - 1) As Byte

        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(salt)
        End Using

        Dim hash As Byte()
        Using pbkdf2 As New Rfc2898DeriveBytes(password, salt, Iteraciones, HashAlgorithmName.SHA256)
            hash = pbkdf2.GetBytes(TamanoHash)
        End Using

        Return Iteraciones & "." & Convert.ToBase64String(salt) & "." & Convert.ToBase64String(hash)
    End Function

    ' Compara la contraseña ingresada contra el hash guardado en la BD
    Public Shared Function VerificarPassword(password As String, hashGuardado As String) As Boolean
        Try
            Dim partes As String() = hashGuardado.Split("."c)
            If partes.Length <> 3 Then Return False

            Dim iteraciones As Integer = Integer.Parse(partes(0))
            Dim salt As Byte() = Convert.FromBase64String(partes(1))
            Dim hashEsperado As Byte() = Convert.FromBase64String(partes(2))

            Dim hashCalculado As Byte()
            Using pbkdf2 As New Rfc2898DeriveBytes(password, salt, iteraciones, HashAlgorithmName.SHA256)
                hashCalculado = pbkdf2.GetBytes(hashEsperado.Length)
            End Using

            ' Comparación en tiempo constante así evita ataques por tiempo de respuesta
            Dim diferencia As Integer = 0
            For i As Integer = 0 To hashEsperado.Length - 1
                diferencia = diferencia Or (hashEsperado(i) Xor hashCalculado(i))
            Next
            Return diferencia = 0

        Catch ex As FormatException
            Return False
        End Try
    End Function

End Class