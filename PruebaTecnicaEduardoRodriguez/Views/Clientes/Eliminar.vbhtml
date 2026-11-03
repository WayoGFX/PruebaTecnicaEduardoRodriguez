@ModelType Cliente
@Code
    ViewData("Title") = "Eliminar cliente"
End Code

<h2 class="mb-3">Eliminar cliente</h2>

<div class="alert alert-warning">
    El cliente será eliminado, ¿Estás seguro?
</div>

<dl class="row">
    <dt class="col-sm-2">Nombre</dt>
    <dd class="col-sm-10">@Model.Nombre @Model.Apellido</dd>

    <dt class="col-sm-2">Correo</dt>
    <dd class="col-sm-10">@Model.Email</dd>

    <dt class="col-sm-2">Teléfono</dt>
    <dd class="col-sm-10">@Model.Telefono</dd>

    <dt class="col-sm-2">Dirección</dt>
    <dd class="col-sm-10">@Model.Direccion</dd>
</dl>

@Using Html.BeginForm("Eliminar", "Clientes", FormMethod.Post)
    @Html.AntiForgeryToken()
    @Html.Hidden("id", Model.Id)

    @<div class="d-flex gap-2">
        <button type="submit" class="btn btn-danger">Sí, eliminar</button>
        @Html.ActionLink("Cancelar", "Index", "Clientes", Nothing, New With {.class = "btn btn-secondary"})
    </div>
End Using