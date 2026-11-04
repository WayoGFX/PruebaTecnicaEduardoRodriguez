@ModelType Cliente
@Code
    ViewData("Title") = "Editar cliente"
End Code
<div class="row justify-content-center">
    <div class="col-lg-8 col-xl-7">
        <div class="mb-4">
            <h2 class="fw-bold mb-1">Editar cliente</h2>
            <p class="text-secondary small mb-0">Actualizar la información y guardar los cambios</p>
        </div>
        <div class="card border rounded-3 shadow-sm">
            <div class="card-body p-4">
                @Using Html.BeginForm()
                    @Html.AntiForgeryToken()
                    @Html.HiddenFor(Function(m) m.Id)
                    @Html.Partial("_Form", Model)

                    @<div class="d-flex justify-content-end gap-2 border-top mt-4 pt-4">
                        @Html.ActionLink("Cancelar", "Index", "Clientes", Nothing, New With {.class = "btn btn-outline-secondary px-4"})
                        <button type="submit" class="btn btn-dark px-4">Guardar cambios</button>
                    </div>
                End Using
            </div>
        </div>
    </div>
</div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section