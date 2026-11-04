<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - Eduardo Rodríguez</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
    <style>
        .form-control:focus,
        .form-select:focus {
            border-color: #6c757d;
            box-shadow: 0 0 0 0.2rem rgba(108, 117, 125, 0.2);
        }

        .btn:focus-visible {
            box-shadow: 0 0 0 0.2rem rgba(108, 117, 125, 0.35);
        }

        .navbar-brand {
            letter-spacing: 0.08em;
        }

        .table thead th {
            letter-spacing: 0.06em;
        }
    </style>
</head>
<body class="bg-light d-flex flex-column min-vh-100">
    @If Request.IsAuthenticated Then
        @<nav class="navbar navbar-expand-sm navbar-dark bg-dark border-bottom border-secondary-subtle">
            <div class="container py-1">
                @Html.ActionLink("PRUEBA TÉCNICA FUNDAMICRO", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand fw-semibold small"})
                <button type="button" class="navbar-toggler border-0" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" title="Alternar navegación" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse d-sm-inline-flex justify-content-between">
                    <ul class="navbar-nav flex-grow-1 gap-sm-1">
                        <li class="nav-item">@Html.ActionLink("Inicio", "Index", "Home", Nothing, New With {.class = "nav-link"})</li>
                        <li class="nav-item">@Html.ActionLink("Clientes", "Index", "Clientes", Nothing, New With {.class = "nav-link"})</li>
                        <li class="nav-item">@Html.ActionLink("Bitácora", "Index", "Bitacora", Nothing, New With {.class = "nav-link"})</li>
                    </ul>
                </div>
                @Html.Partial("_LoginPartial")
            </div>
        </nav>
    End If
    <main class="container py-5 flex-grow-1">
        @RenderBody()
    </main>
    <footer class="border-top bg-white">
        <div class="container py-3">
            <p class="text-secondary small mb-0">&copy; @DateTime.Now.Year - Eduardo Rodríguez, Prueba Técnica Fundamicro</p>
        </div>
    </footer>
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>