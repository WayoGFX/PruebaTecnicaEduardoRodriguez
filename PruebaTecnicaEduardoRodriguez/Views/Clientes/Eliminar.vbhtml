@ModelType Cliente
@Code
    ViewData("Title") = "Eliminar cliente"
End Code

<div class="row justify-content-center">
    <div class="col-lg-8 col-xl-7">
        <div class="mb-4">
            <h2 class="fw-bold mb-1">Eliminar cliente</h2>
            <p class="text-secondary small mb-0">Revisa los datos antes de confirmar</p>
        </div>
        <div class="alert alert-warning rounded-3 small py-2 px-3 mb-3">
            El cliente será eliminado, ¿estás seguro?
        </div>
        <div class="card border rounded-3 shadow-sm">
            <div class="card-body p-4">
                <dl class="row mb-0">
                    <dt class="col-sm-3 text-secondary small fw-medium text-uppercase py-2">Nombre</dt>
                    <dd class="col-sm-9 fw-medium py-2 mb-0">@Model.Nombre @Model.Apellido</dd>

                    <dt class="col-sm-3 text-secondary small fw-medium text-uppercase py-2 border-top">Correo</dt>
                    <dd class="col-sm-9 py-2 mb-0 border-top">@Model.Email</dd>

                    <dt class="col-sm-3 text-secondary small fw-medium text-uppercase py-2 border-top">Teléfono</dt>
                    <dd class="col-sm-9 py-2 mb-0 border-top">@Model.Telefono</dd>

                    <dt class="col-sm-3 text-secondary small fw-medium text-uppercase py-2 border-top">Dirección</dt>
                    <dd class="col-sm-9 py-2 mb-0 border-top">@Model.Direccion</dd>
                </dl>
                @Using Html.BeginForm("Eliminar", "Clientes", FormMethod.Post)
                    @Html.AntiForgeryToken()
                    @Html.Hidden("id", Model.Id)

                    @<div class="d-flex justify-content-end gap-2 border-top mt-4 pt-4">
                        @Html.ActionLink("Cancelar", "Index", "Clientes", Nothing, New With {.class = "btn btn-outline-secondary px-4"})
                        <button type="submit" class="btn btn-danger px-4">Eliminar</button>
                    </div>
                End Using
            </div>
        </div>
    </div>
</div>