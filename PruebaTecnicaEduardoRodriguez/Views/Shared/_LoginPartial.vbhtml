@If Request.IsAuthenticated Then
    @Using Html.BeginForm("Logout", "Login", FormMethod.Post, New With {.class = "d-flex align-items-center gap-3 mb-0 ms-sm-auto mt-2 mt-sm-0"})
        @Html.AntiForgeryToken()
        @<span class="navbar-text small text-white-50 py-0">Hola, <span class="text-white fw-medium">@User.Identity.Name</span></span>
        @<button type="submit" class="btn btn-sm btn-outline-light px-3">Cerrar sesión</button>
    End Using
End If