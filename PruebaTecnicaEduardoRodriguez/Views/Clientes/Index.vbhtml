@ModelType List(Of Cliente)
@Code
    ViewData("Title") = "Clientes"
End Code

<div class="d-flex justify-content-between align-items-center mb-4">
    <div>
        <h2 class="fw-bold mb-1">Clientes</h2>
        <p class="text-secondary small mb-0">@Model.Count registrados</p>
    </div>
    @Html.ActionLink("Nuevo cliente", "Crear", "Clientes", Nothing, New With {.class = "btn btn-dark px-4"})
</div>

@If TempData("Mensaje") IsNot Nothing Then
    @<div class="alert alert-success rounded-3 small py-2 px-3">@TempData("Mensaje")</div>
End If

@If TempData("Error") IsNot Nothing Then
    @<div class="alert alert-danger rounded-3 small py-2 px-3">@TempData("Error")</div>
End If

@If ViewBag.Error IsNot Nothing Then
    @<div class="alert alert-danger rounded-3 small py-2 px-3">@ViewBag.Error</div>
End If

@If Model.Count = 0 Then
    @<div class="card border rounded-3 shadow-sm">
        <div class="card-body text-center py-5">
            <p class="fw-semibold mb-1">Aún no hay clientes</p>
            <p class="text-secondary small mb-3">En esta tabla aparecerán los clientes que sean agregados</p>
            @Html.ActionLink("Agregar cliente", "Crear", "Clientes", Nothing, New With {.class = "btn btn-outline-dark btn-sm px-3"})
        </div>
    </div>
Else
    @<div class="card border rounded-3 shadow-sm overflow-hidden">
        <div class="table-responsive">
            <table class="table table-hover align-middle mb-0">
                <thead class="table-light">
                    <tr class="text-uppercase small text-secondary">
                        <th class="fw-semibold py-3 ps-4">Nombre</th>
                        <th class="fw-semibold py-3">Apellido</th>
                        <th class="fw-semibold py-3">Correo</th>
                        <th class="fw-semibold py-3">Teléfono</th>
                        <th class="fw-semibold py-3">Dirección</th>
                        <th class="py-3"></th>
                    </tr>
                </thead>
                <tbody>
                    @For Each c In Model
                        @<tr>
                            <td class="fw-medium py-3 ps-4">@c.Nombre</td>
                            <td class="py-3">@c.Apellido</td>
                            <td class="text-secondary py-3">@c.Email</td>
                            <td class="text-secondary py-3">@c.Telefono</td>
                            <td class="text-secondary py-3">@c.Direccion</td>
                            <td class="text-nowrap text-end py-3 pe-4">
                                @Html.ActionLink("Editar", "Editar", "Clientes", New With {.id = c.Id}, New With {.class = "btn btn-sm btn-outline-secondary px-3"})
                                @Html.ActionLink("Eliminar", "Eliminar", "Clientes", New With {.id = c.Id}, New With {.class = "btn btn-sm btn-outline-danger px-3"})
                            </td>
                        </tr>
                    Next
                </tbody>
            </table>
        </div>
    </div>
End If