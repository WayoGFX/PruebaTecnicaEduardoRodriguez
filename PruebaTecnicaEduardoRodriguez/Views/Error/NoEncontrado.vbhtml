@Code
    ViewData("Title") = "No encontrado"
End Code

<div class="text-center mt-5">
    <h2>Página no encontrada</h2>
    <p class="text-muted">La página no existe.</p>
    @Html.ActionLink("Volver al inicio", "Index", "Clientes", Nothing, New With {.class = "btn btn-primary"})
</div>