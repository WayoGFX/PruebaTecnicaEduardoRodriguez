<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - Eduardo Rodríguez</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>
    @If Request.IsAuthenticated Then
        @<nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark">
            <div class="container">
                @Html.ActionLink("PRUEBA TÉCNICA FUNDAMICRO", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
                <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" title="Alternar navegación" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse d-sm-inline-flex justify-content-between">
                    <ul class="navbar-nav flex-grow-1">
                        <li>@Html.ActionLink("Inicio", "Index", "Home", Nothing, New With {.class = "nav-link"})</li>
                        <li>@Html.ActionLink("Clientes", "Index", "Clientes", Nothing, New With {.class = "nav-link"})</li>
                        <li>@Html.ActionLink("Bitácora", "Index", "Bitacora", Nothing, New With {.class = "nav-link"})</li>
                    </ul>
                </div>
                @Html.Partial("_LoginPartial")
            </div>
        </nav>
    End If
    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - Eduardo Rodríguez, Prueba Técnica Fundamicro</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
