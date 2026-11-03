@ModelType HandleErrorInfo
@Code
    ViewData("Title") = "Error"
End Code
<div class="text-center mt-5">
    <h2>Parece que algo no salió como esperaba</h2>
    <p class="text-muted">Ha ocurrido un error inesperado, intenta recargar o contactarte con el administrador</p>
    @Html.ActionLink("Volver al inicio", "Index", "Clientes", Nothing, New With {.class = "btn btn-primary"})
</div>