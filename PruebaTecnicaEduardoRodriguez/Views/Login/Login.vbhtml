@ModelType LoginModel
@Code
    ViewData("Title") = "Iniciar sesión"
End Code

<div class="row justify-content-center">
    <div class="col-md-5">
        <h2 class="mb-3">Iniciar sesión</h2>

        @Using Html.BeginForm()
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})

            @<div class="mb-3">
                <label for="NombreUsuario" class="form-label">Usuario</label>
                @Html.TextBoxFor(Function(m) m.NombreUsuario, New With {.class = "form-control", .autofocus = "autofocus"})
                @Html.ValidationMessageFor(Function(m) m.NombreUsuario, "", New With {.class = "text-danger"})
            </div>

            @<div class="mb-3">
                <label for="Password" class="form-label">Contraseña</label>
                @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "text-danger"})
            </div>

            @<button type="submit" class="btn btn-primary">Iniciar sesión</button>
        End Using
    </div>
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section