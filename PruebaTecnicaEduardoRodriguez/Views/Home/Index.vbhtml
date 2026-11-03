@Code
    ViewData("Title") = "Inicio"
End Code
<main>
    <section class="mb-4">
        <h1>Gestión de Clientes</h1>
        <p class="lead">
            Prueba técnica para Fundamicro: Aplicación web en ASP.NET MVC (VB.NET) con SQL Server
            para administrar clientes y registrar los movimientos en una bitácora
        </p>
        <p class="text-muted">Bienvenido, <strong>@User.Identity.Name</strong>. ¿Qué desea realizar?</p>
        <p>
            @Html.ActionLink("Ir a Clientes", "Index", "Clientes", Nothing, New With {.class = "btn btn-primary btn-md"})
            @Html.ActionLink("Ver bitácora", "Index", "Bitacora", Nothing, New With {.class = "btn btn-outline-dark btn-md"})
        </p>
    </section>
    <div class="row">
        <section class="col-md-4 mb-4">
            <h2>Login de acceso</h2>
            <p>Los usuarios se validan en la base de datos en SQL Server donde en el controller del login llama al service de Usuario para validar el usuario y contraseña, realizando uso del helper para resolver el hash</p>
        </section>
        <section class="col-md-4 mb-4">
            <h2>Mantenimiento de clientes</h2>
            <p>Funcionalidades que permiten ver, agregar, editar y eliminar clientes, evitando duplicación en los correos, esto es por medio del controller de clientes que instancia un servicio para ejecutar los procesos</p>
            <p>@Html.ActionLink("Abrir clientes", "Index", "Clientes", Nothing, New With {.class = "btn btn-outline-dark"})</p>
        </section>
        <section class="col-md-4 mb-4">
            <h2>Bitácora de acciones</h2>
            <p>Cada movimiento en la tabla de clientes ya sea agregar, editar o eliminar queda registrada en la bitácora con el ID del cliente,la fecha y hora y el usuario</p>
            <p>@Html.ActionLink("Abrir bitácora", "Index", "Bitacora", Nothing, New With {.class = "btn btn-outline-dark"})</p>
        </section>
    </div>
    <section class="mt-2">
        <h2>Buenas prácticas aplicadas</h2>
        <ul>
            <li>Consultas parametrizadas con ADO.NET para evitar inyección SQL</li>
            <li>Acceso restringido con autorización global</li>
            <li>Manejo de errores con try/catch y páginas de error</li>
        </ul>
    </section>
</main>