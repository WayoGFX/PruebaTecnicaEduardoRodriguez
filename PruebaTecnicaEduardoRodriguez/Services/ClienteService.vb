Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class ClienteService

    Private ReadOnly _connectionString As String =
        ConfigurationManager.ConnectionStrings("PruebaTecnicaDb").ConnectionString

    Private Const ColumnasCliente As String =
        "Id, Nombre, Apellido, Email, Telefono, Direccion, FechaCreacion"

    'Seleccionar todos los clientes ordenados de forma descendente
    Public Function ObtenerTodos() As List(Of Cliente)
        Dim lista As New List(Of Cliente)()
        Dim sql As String = "SELECT " & ColumnasCliente & " FROM Clientes ORDER BY Id DESC"

        Using conn As New SqlConnection(_connectionString)
            Using cmd As New SqlCommand(sql, conn)
                conn.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        lista.Add(MapearCliente(reader))
                    End While
                End Using
            End Using
        End Using

        Return lista
    End Function

    ' Seleccionar un cliente por su Id
    Public Function ObtenerPorId(id As Integer) As Cliente
        Dim resultado As Cliente = Nothing
        Dim sql As String = "SELECT " & ColumnasCliente & " FROM Clientes WHERE Id = @Id"

        Using conn As New SqlConnection(_connectionString)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id
                conn.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        resultado = MapearCliente(reader)
                    End If
                End Using
            End Using
        End Using

        Return resultado
    End Function

    'Agregar un nuevo cliente y registrar en la bitacora el movimiento
    Public Sub Agregar(cliente As Cliente, nombreUsuario As String)
        Const sql As String =
            "INSERT INTO Clientes (Nombre, Apellido, Email, Telefono, Direccion) " &
            "VALUES (@Nombre, @Apellido, @Email, @Telefono, @Direccion); " &
            "SELECT CAST(SCOPE_IDENTITY() AS INT);"

        Using conn As New SqlConnection(_connectionString)
            conn.Open()
            Using tx As SqlTransaction = conn.BeginTransaction()
                Try
                    Dim nuevoId As Integer
                    Using cmd As New SqlCommand(sql, conn, tx)
                        AgregarParametros(cmd, cliente)
                        nuevoId = CInt(cmd.ExecuteScalar())
                    End Using

                    RegistrarBitacora(conn, tx, "Agregar", nuevoId, nombreUsuario,
                                      "Cliente creado: " & cliente.Nombre & " " & cliente.Apellido)
                    tx.Commit()

                Catch ex As SqlException
                    tx.Rollback()
                    TraducirErrorSql(ex)
                    Throw
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Sub

    'Editar un cliente y registrar en la bitacora el movimiento
    Public Sub Editar(cliente As Cliente, nombreUsuario As String)
        Const sql As String =
            "UPDATE Clientes SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, " &
            "Telefono = @Telefono, Direccion = @Direccion WHERE Id = @Id"

        Using conn As New SqlConnection(_connectionString)
            conn.Open()
            Using tx As SqlTransaction = conn.BeginTransaction()
                Try
                    Dim filas As Integer
                    Using cmd As New SqlCommand(sql, conn, tx)
                        AgregarParametros(cmd, cliente)
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = cliente.Id
                        filas = cmd.ExecuteNonQuery()
                    End Using

                    If filas = 0 Then
                        Throw New NegocioException("El cliente no existe")
                    End If

                    RegistrarBitacora(conn, tx, "Editar", cliente.Id, nombreUsuario,
                                      "Cliente editado: " & cliente.Nombre & " " & cliente.Apellido)
                    tx.Commit()

                Catch ex As SqlException
                    tx.Rollback()
                    TraducirErrorSql(ex)
                    Throw
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Sub

    'Eliminar un cliente y registrar en la bitacora el movimiento
    Public Sub Eliminar(id As Integer, nombreUsuario As String)
        Using conn As New SqlConnection(_connectionString)
            conn.Open()
            Using tx As SqlTransaction = conn.BeginTransaction()
                Try
                    'Se obtiene el nombre para agregar lo en la bitácora
                    Dim nombreCompleto As String = Nothing
                    Using cmdLeer As New SqlCommand(
                        "SELECT Nombre + ' ' + Apellido FROM Clientes WHERE Id = @Id", conn, tx)
                        cmdLeer.Parameters.Add("@Id", SqlDbType.Int).Value = id
                        Dim valor As Object = cmdLeer.ExecuteScalar()
                        If valor IsNot Nothing Then nombreCompleto = valor.ToString()
                    End Using

                    If nombreCompleto Is Nothing Then
                        Throw New NegocioException("El cliente no existe")
                    End If

                    Using cmdBorrar As New SqlCommand("DELETE FROM Clientes WHERE Id = @Id", conn, tx)
                        cmdBorrar.Parameters.Add("@Id", SqlDbType.Int).Value = id
                        cmdBorrar.ExecuteNonQuery()
                    End Using

                    RegistrarBitacora(conn, tx, "Eliminar", id, nombreUsuario,
                                      "Cliente eliminado: " & nombreCompleto)
                    tx.Commit()

                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Sub

    'Métodos para la bitácora y para mapear los datos del cliente
    Private Sub RegistrarBitacora(conn As SqlConnection, tx As SqlTransaction,
                                  accion As String, clienteId As Integer,
                                  nombreUsuario As String, detalle As String)
        'Obtiene nombre y id del usuario
        Const sql As String =
            "INSERT INTO Bitacora (Accion, ClienteId, UsuarioId, NombreUsuario, Detalle) " &
            "SELECT @Accion, @ClienteId, Id, NombreUsuario, @Detalle " &
            "FROM Usuarios WHERE NombreUsuario = @NombreUsuario"

        Using cmd As New SqlCommand(sql, conn, tx)
            cmd.Parameters.Add("@Accion", SqlDbType.NVarChar, 20).Value = accion
            cmd.Parameters.Add("@ClienteId", SqlDbType.Int).Value = clienteId
            cmd.Parameters.Add("@Detalle", SqlDbType.NVarChar, 500).Value = detalle
            cmd.Parameters.Add("@NombreUsuario", SqlDbType.NVarChar, 50).Value = nombreUsuario

            If cmd.ExecuteNonQuery() = 0 Then
                Throw New NegocioException("No se pudo registrar la bitácora: usuario no encontrado.")
            End If
        End Using
    End Sub

    Private Sub AgregarParametros(cmd As SqlCommand, cliente As Cliente)
        cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = cliente.Nombre.Trim()
        cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar, 100).Value = cliente.Apellido.Trim()
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = cliente.Email.Trim()
        cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar, 20).Value = ValorODbNull(cliente.Telefono)
        cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar, 250).Value = ValorODbNull(cliente.Direccion)
    End Sub

    'Al venir vacío igual se guarda pero en null
    Private Function ValorODbNull(texto As String) As Object
        If String.IsNullOrWhiteSpace(texto) Then
            Return DBNull.Value
        End If
        Return texto.Trim()
    End Function

    Private Function MapearCliente(reader As SqlDataReader) As Cliente
        Dim c As New Cliente()
        c.Id = reader.GetInt32(0)
        c.Nombre = reader.GetString(1)
        c.Apellido = reader.GetString(2)
        c.Email = reader.GetString(3)
        c.Telefono = If(reader.IsDBNull(4), Nothing, reader.GetString(4))
        c.Direccion = If(reader.IsDBNull(5), Nothing, reader.GetString(5))
        c.FechaCreacion = reader.GetDateTime(6)
        Return c
    End Function

    '2601 y 2627 son los códigos de SQL Server para valor duplicado en índice único
    Private Sub TraducirErrorSql(ex As SqlException)
        If ex.Number = 2601 OrElse ex.Number = 2627 Then
            Throw New NegocioException("Ya existe un cliente con ese correo.")
        End If
    End Sub

End Class