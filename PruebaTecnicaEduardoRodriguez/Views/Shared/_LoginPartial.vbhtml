@If Request.IsAuthenticated Then
    @Using Html.BeginForm("Logout", "Login", FormMethod.Post, New With {.class = "d-flex align-items-center gap-3 mb-0 ms-auto"})
        @Html.AntiForgeryToken()
        @<span class="navbar-text text-light">Hola, <strong>@User.Identity.Name</strong></span>
        @<button type="submit" class="btn btn-sm btn-danger">Cerrar sesión</button>
    End Using
End If