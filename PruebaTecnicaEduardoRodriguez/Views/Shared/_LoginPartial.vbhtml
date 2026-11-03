@If Request.IsAuthenticated Then
    @Using Html.BeginForm("Logout", "Login", FormMethod.Post, New With {.class = "d-inline"})
        @Html.AntiForgeryToken()
        @<span class="me-2">Bienvenido, @User.Identity.Name</span>
        @<button type="submit" class="btn btn-sm btn-outline-secondary">Cerrar sesión</button>
    End Using
End If