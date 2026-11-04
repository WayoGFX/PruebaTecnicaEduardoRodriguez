Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class UsuarioService

    Private ReadOnly _connectionString As String =
        ConfigurationManager.ConnectionStrings("PruebaTecnicaDb").ConnectionString

    'Buscar usuario por nombre
    Public Function ObtenerPorNombre(nombreUsuario As String) As Usuario
        Dim resultado As Usuario = Nothing

        Const sql As String =
            "SELECT Id, NombreUsuario, PasswordHash, Activo " &
            "FROM Usuarios WHERE NombreUsuario = @NombreUsuario"

        Using conn As New SqlConnection(_connectionString)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.Add("@NombreUsuario", SqlDbType.NVarChar, 50).Value = nombreUsuario
                conn.Open()

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        resultado = New Usuario()
                        resultado.Id = reader.GetInt32(0)
                        resultado.NombreUsuario = reader.GetString(1)
                        resultado.PasswordHash = reader.GetString(2)
                        resultado.Activo = reader.GetBoolean(3)
                    End If
                End Using
            End Using
        End Using

        Return resultado
    End Function

    ' Validar credenciales
    Public Function ValidarLogin(nombreUsuario As String, password As String) As Usuario
        Dim usuario As Usuario = ObtenerPorNombre(nombreUsuario)

        If usuario Is Nothing OrElse Not usuario.Activo Then
            Return Nothing
        End If

        If PasswordHelper.VerificarPassword(password, usuario.PasswordHash) Then
            Return usuario
        End If

        Return Nothing
    End Function

End Class