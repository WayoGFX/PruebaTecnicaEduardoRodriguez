@ModelType LoginModel
@Code
    ViewData("Title") = "Iniciar sesión"
End Code

<div class="row justify-content-center align-items-center" style="min-height: 60vh;">
    <div class="col-sm-10 col-md-6 col-lg-5 col-xl-4">
        <div class="text-center mb-4">
            <h2 class="fw-bold mb-1">Iniciar sesión</h2>
            <p class="text-secondary small mb-0">Ingresa tus credenciales para continuar</p>
        </div>
        <div class="card border rounded-3 shadow-sm">
            <div class="card-body p-4">
                @Using Html.BeginForm()
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True, "", New With {.class = "text-danger small"})
                    @<div class="mb-3">
                        <label for="NombreUsuario" class="form-label fw-medium small mb-1">Usuario</label>
                        @Html.TextBoxFor(Function(m) m.NombreUsuario, New With {.class = "form-control py-2", .autofocus = "autofocus", .placeholder = "Nombre de usuario"})
                        @Html.ValidationMessageFor(Function(m) m.NombreUsuario, "", New With {.class = "text-danger small"})
                    </div>
                    @<div class="mb-4">
                        <label for="Password" class="form-label fw-medium small mb-1">Contraseña</label>
                        @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control py-2", .placeholder = "********"})
                        @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "text-danger small"})
                    </div>
                    @<div class="d-grid">
                        <button type="submit" class="btn btn-dark py-2">Iniciar sesión</button>
                    </div>
                End Using
            </div>
        </div>
    </div>
</div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section