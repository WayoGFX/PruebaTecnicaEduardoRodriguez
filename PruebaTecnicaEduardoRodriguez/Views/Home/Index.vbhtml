@Code
    ViewData("Title") = "Inicio"
End Code

<section class="card border rounded-3 shadow-sm mb-4">
    <div class="card-body p-4 p-md-5">
        <p class="text-uppercase small fw-semibold text-secondary mb-2" style="letter-spacing: 0.08em;">Prueba técnica Fundamicro</p>
        <h1 class="fw-bold mb-3">Gestión de Clientes</h1>
        <p class="lead text-secondary mb-4">Aplicación web en ASP.NET MVC (VB.NET) con SQL Server para administrar clientes y registrar los movimientos en una bitácora</p>
        <p class="mb-4">Bienvenido, <span class="fw-medium">@User.Identity.Name</span>. ¿Qué desea realizar?</p>
        <div class="d-flex flex-wrap gap-2">
            @Html.ActionLink("Ir a Clientes", "Index", "Clientes", Nothing, New With {.class = "btn btn-dark px-4"})
            @Html.ActionLink("Ver bitácora", "Index", "Bitacora", Nothing, New With {.class = "btn btn-outline-secondary px-4"})
        </div>
    </div>
</section>
<div class="row g-4 mb-4">
    <section class="col-md-4">
        <div class="card border rounded-3 shadow-sm h-100">
            <div class="card-body p-4 d-flex flex-column">
                <h2 class="h5 fw-semibold mb-2">Login de acceso</h2>
                <p class="text-secondary small mb-0">Los usuarios se validan en la base de datos en SQL Server, donde el controller del login llama al service de Usuario para validar el usuario y la contraseña, usando el helper para resolver el hash</p>
            </div>
        </div>
    </section>
    <section class="col-md-4">
        <div class="card border rounded-3 shadow-sm h-100">
            <div class="card-body p-4 d-flex flex-column">
                <h2 class="h5 fw-semibold mb-2">Mantenimiento de clientes</h2>
                <p class="text-secondary small mb-4">Funcionalidades que permiten ver, agregar, editar y eliminar clientes, evitando duplicación en los correos. Se hace por medio del controller de clientes, que instancia un servicio para ejecutar los procesos</p>
                <div class="mt-auto">
                    @Html.ActionLink("Abrir clientes", "Index", "Clientes", Nothing, New With {.class = "btn btn-outline-dark btn-sm px-3"})
                </div>
            </div>
        </div>
    </section>
    <section class="col-md-4">
        <div class="card border rounded-3 shadow-sm h-100">
            <div class="card-body p-4 d-flex flex-column">
                <h2 class="h5 fw-semibold mb-2">Bitácora de acciones</h2>
                <p class="text-secondary small mb-4">Cada movimiento en la tabla de clientes, ya sea agregar, editar o eliminar, queda registrado en la bitácora con el ID del cliente, la fecha y hora y el usuario</p>
                <div class="mt-auto">
                    @Html.ActionLink("Abrir bitácora", "Index", "Bitacora", Nothing, New With {.class = "btn btn-outline-dark btn-sm px-3"})
                </div>
            </div>
        </div>
    </section>
</div>