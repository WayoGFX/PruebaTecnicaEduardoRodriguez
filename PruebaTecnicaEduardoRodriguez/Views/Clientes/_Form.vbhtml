@ModelType Cliente

@Html.ValidationSummary(True, "", New With {.class = "text-danger"})

<div class="mb-3">
    <label for="Nombre" class="form-label">Nombre</label>
    @Html.TextBoxFor(Function(m) m.Nombre, New With {.class = "form-control"})
    @Html.ValidationMessageFor(Function(m) m.Nombre, "", New With {.class = "text-danger"})
</div>

<div class="mb-3">
    <label for="Apellido" class="form-label">Apellido</label>
    @Html.TextBoxFor(Function(m) m.Apellido, New With {.class = "form-control"})
    @Html.ValidationMessageFor(Function(m) m.Apellido, "", New With {.class = "text-danger"})
</div>

<div class="mb-3">
    <label for="Email" class="form-label">Correo electrónico</label>
    @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control", .type = "email"})
    @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.class = "text-danger"})
</div>

<div class="mb-3">
    <label for="Telefono" class="form-label">Teléfono (opcional)</label>
    @Html.TextBoxFor(Function(m) m.Telefono, New With {.class = "form-control"})
    @Html.ValidationMessageFor(Function(m) m.Telefono, "", New With {.class = "text-danger"})
</div>

<div class="mb-3">
    <label for="Direccion" class="form-label">Dirección (opcional)</label>
    @Html.TextBoxFor(Function(m) m.Direccion, New With {.class = "form-control"})
    @Html.ValidationMessageFor(Function(m) m.Direccion, "", New With {.class = "text-danger"})
</div>