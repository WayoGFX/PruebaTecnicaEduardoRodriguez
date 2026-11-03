@ModelType Cliente
@Code
    ViewData("Title") = "Editar cliente"
End Code

<h2 class="mb-3">Editar cliente</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.HiddenFor(Function(m) m.Id)
    @Html.Partial("_Form", Model)

    @<div class="d-flex gap-2">
        <button type="submit" class="btn btn-primary">Guardar cambios</button>
        @Html.ActionLink("Cancelar", "Index", "Clientes", Nothing, New With {.class = "btn btn-secondary"})
    </div>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section