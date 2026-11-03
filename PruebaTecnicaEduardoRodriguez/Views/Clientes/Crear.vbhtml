@ModelType Cliente
@Code
    ViewData("Title") = "Nuevo cliente"
End Code

<h2 class="mb-3">Crear Nuevo cliente</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.Partial("_Form", Model)

    @<div class="d-flex gap-2">
        <button type="submit" class="btn btn-primary">Guardar</button>
        @Html.ActionLink("Cancelar", "Index", "Clientes", Nothing, New With {.class = "btn btn-secondary"})
    </div>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section