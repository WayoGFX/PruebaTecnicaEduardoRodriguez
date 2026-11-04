@Code
    ViewData("Title") = "No encontrado"
End Code

<div class="row justify-content-center">
    <div class="col-md-8 col-lg-6">
        <div class="card border rounded-3 shadow-sm">
            <div class="card-body text-center p-5">
                <p class="display-1 fw-bold text-secondary opacity-25 mb-2">404</p>
                <h2 class="h4 fw-bold mb-2">Página no encontrada</h2>
                <p class="text-secondary small mb-4">La página que buscas no existe</p>
                @Html.ActionLink("Volver al inicio", "Index", "Clientes", Nothing, New With {.class = "btn btn-dark px-4"})
            </div>
        </div>
    </div>
</div>