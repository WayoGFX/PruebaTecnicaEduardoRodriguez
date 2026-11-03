@ModelType List(Of Cliente)
@Code
    ViewData("Title") = "Clientes"
End Code

<div class="d-flex justify-content-between align-items-center mb-3">
    <h2>Clientes</h2>
    @Html.ActionLink("Nuevo cliente", "Crear", "Clientes", Nothing, New With {.class = "btn btn-primary"})
</div>

@If TempData("Mensaje") IsNot Nothing Then
    @<div class="alert alert-success">@TempData("Mensaje")</div>
End If

@If TempData("Error") IsNot Nothing Then
    @<div class="alert alert-danger">@TempData("Error")</div>
End If

@If ViewBag.Error IsNot Nothing Then
    @<div class="alert alert-danger">@ViewBag.Error</div>
End If

@If Model.Count = 0 Then
    @<p class="text-muted">No hay clientes registrados</p>
Else
    @<div class="table-responsive">
        <table class="table table-striped table-hover align-middle">
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Apellido</th>
                    <th>Correo</th>
                    <th>Teléfono</th>
                    <th>Dirección</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                @For Each c In Model
                    @<tr>
                        <td>@c.Nombre</td>
                        <td>@c.Apellido</td>
                        <td>@c.Email</td>
                        <td>@c.Telefono</td>
                        <td>@c.Direccion</td>
                        <td class="text-nowrap">
                            @Html.ActionLink("Editar", "Editar", "Clientes", New With {.id = c.Id}, New With {.class = "btn btn-sm btn-outline-primary"})
                            @Html.ActionLink("Eliminar", "Eliminar", "Clientes", New With {.id = c.Id}, New With {.class = "btn btn-sm btn-outline-danger"})
                        </td>
                    </tr>
                Next
            </tbody>
        </table>
    </div>
End If