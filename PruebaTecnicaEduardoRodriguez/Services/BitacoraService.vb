Imports System.Configuration
Imports System.Data.SqlClient

Public Class BitacoraService
    Private ReadOnly _connectionString As String =
        ConfigurationManager.ConnectionStrings("PruebaTecnicaDb").ConnectionString

    'Solo 100 movimientos para optimizar la petición
    Public Function ObtenerRecientes() As List(Of Bitacora)
        Dim lista As New List(Of Bitacora)()

        Const sql As String =
            "SELECT TOP 100 Id, Accion, ClienteId, FechaHora, UsuarioId, NombreUsuario, Detalle " &
            "FROM Bitacora ORDER BY FechaHora DESC, Id DESC"

        Using conn As New SqlConnection(_connectionString)
            Using cmd As New SqlCommand(sql, conn)
                conn.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim b As New Bitacora()
                        b.Id = reader.GetInt32(0)
                        b.Accion = reader.GetString(1)
                        b.ClienteId = reader.GetInt32(2)
                        b.FechaHora = reader.GetDateTime(3)
                        b.UsuarioId = reader.GetInt32(4)
                        b.NombreUsuario = reader.GetString(5)
                        b.Detalle = If(reader.IsDBNull(6), Nothing, reader.GetString(6))
                        lista.Add(b)
                    End While
                End Using
            End Using
        End Using
        Return lista
    End Function
End Class