Imports System.Web.Mvc
Public Class ClientesController
    Inherits Controller

    Private ReadOnly _clienteService As New ClienteService()

    'Obtener la lista de clientes y mostrarla en la vista
    Public Function Index() As ActionResult
        Dim lista As New List(Of Cliente)()

        Try
            lista = _clienteService.ObtenerTodos()
        Catch ex As Exception
            System.Diagnostics.Trace.TraceError(ex.ToString())
            ViewBag.Error = "No se pudo cargar la lista de clientes"
        End Try

        Return View(lista)
    End Function

    'Recibir cliente
    <HttpGet>
    Public Function Crear() As ActionResult
        Return View(New Cliente())
    End Function

    'Crear un nuevo cliente y registrar en la bitacora el movimiento
    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Function Crear(<Bind(Include:="Nombre,Apellido,Email,Telefono,Direccion")> cliente As Cliente) As ActionResult
        If Not ModelState.IsValid Then
            Return View(cliente)
        End If

        Try
            _clienteService.Agregar(cliente, User.Identity.Name)
            TempData("Mensaje") = "Cliente agregado correctamente"
            Return RedirectToAction("Index")

        Catch ex As NegocioException
            ModelState.AddModelError("", ex.Message)
        Catch ex As Exception
            System.Diagnostics.Trace.TraceError(ex.ToString())
            ModelState.AddModelError("", "Ocurrió un error al guardar el cliente, puede volver a intentarlo")
        End Try

        Return View(cliente)
    End Function

    'Editar un cliente existente y registrar en la bitacora el movimiento
    <HttpGet>
    Public Function Editar(id As Integer) As ActionResult
        Dim cliente As Cliente = _clienteService.ObtenerPorId(id)

        If cliente Is Nothing Then
            Return HttpNotFound()
        End If

        Return View(cliente)
    End Function

    'Post de la edición del cliente, validando y registrando en la bitacora el movimiento
    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Function Editar(<Bind(Include:="Id,Nombre,Apellido,Email,Telefono,Direccion")> cliente As Cliente) As ActionResult
        If Not ModelState.IsValid Then
            Return View(cliente)
        End If

        Try
            _clienteService.Editar(cliente, User.Identity.Name)
            TempData("Mensaje") = "Cliente actualizado correctamente"
            Return RedirectToAction("Index")

        Catch ex As NegocioException
            ModelState.AddModelError("", ex.Message)
        Catch ex As Exception
            System.Diagnostics.Trace.TraceError(ex.ToString())
            ModelState.AddModelError("", "Ocurrió un error al actualizar el cliente, puede intentar de nuevo")
        End Try

        Return View(cliente)
    End Function

    'Pantalla de confirmación para eliminar un cliente y registrar en la bitacora el movimiento
    <HttpGet>
    Public Function Eliminar(id As Integer) As ActionResult
        Dim cliente As Cliente = _clienteService.ObtenerPorId(id)

        If cliente Is Nothing Then
            Return HttpNotFound()
        End If

        Return View(cliente)
    End Function

    'Eliminar un cliente y registrar en la bitacora el movimiento
    <HttpPost>
    <ActionName("Eliminar")>
    <ValidateAntiForgeryToken>
    Public Function EliminarConfirmado(id As Integer) As ActionResult
        Try
            _clienteService.Eliminar(id, User.Identity.Name)
            TempData("Mensaje") = "Cliente eliminado correctamente"

        Catch ex As NegocioException
            TempData("Error") = ex.Message
        Catch ex As Exception
            System.Diagnostics.Trace.TraceError(ex.ToString())
            TempData("Error") = "Ocurrió un error al eliminar el cliente, puede intentar de nuevo"
        End Try

        Return RedirectToAction("Index")
    End Function
End Class