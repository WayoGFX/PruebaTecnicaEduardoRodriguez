@ModelType Cliente

@Html.ValidationSummary(True, "", New With {.class = "text-danger small"})

<div class="row g-3">
    <div class="col-md-6">
        <label for="Nombre" class="form-label fw-medium small mb-1">Nombre</label>
        @Html.TextBoxFor(Function(m) m.Nombre, New With {.class = "form-control py-2", .placeholder = "Ej. Eduardo"})
        @Html.ValidationMessageFor(Function(m) m.Nombre, "", New With {.class = "text-danger small"})
    </div>

    <div class="col-md-6">
        <label for="Apellido" class="form-label fw-medium small mb-1">Apellido</label>
        @Html.TextBoxFor(Function(m) m.Apellido, New With {.class = "form-control py-2", .placeholder = "Ej. Rodriguez"})
        @Html.ValidationMessageFor(Function(m) m.Apellido, "", New With {.class = "text-danger small"})
    </div>

    <div class="col-md-6">
        <label for="Email" class="form-label fw-medium small mb-1">Correo electrónico</label>
        @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control py-2", .type = "email", .placeholder = "nombre@correo.com"})
        @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.class = "text-danger small"})
    </div>

    <div class="col-md-6">
        <label for="Telefono" class="form-label fw-medium small mb-1">
            Teléfono
        </label>
        @Html.TextBoxFor(Function(m) m.Telefono, New With {.class = "form-control py-2", .placeholder = "7000 0000"})
        @Html.ValidationMessageFor(Function(m) m.Telefono, "", New With {.class = "text-danger small"})
    </div>

    <div class="col-12">
        <label for="Direccion" class="form-label fw-medium small mb-1">
            Dirección 
        </label>
        @Html.TextBoxFor(Function(m) m.Direccion, New With {.class = "form-control py-2", .placeholder = "Departamento, Colonia, Calle"})
        @Html.ValidationMessageFor(Function(m) m.Direccion, "", New With {.class = "text-danger small"})
    </div>
</div>