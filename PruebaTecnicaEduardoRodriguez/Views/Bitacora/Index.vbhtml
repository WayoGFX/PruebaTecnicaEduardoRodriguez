@ModelType List(Of Bitacora)
@Code
    ViewData("Title") = "Bitácora"
End Code

<div class="mb-4">
    <h2 class="fw-bold mb-1">Bitácora de movimientos</h2>
    <p class="text-secondary small mb-0">Movimientos registrados en los registros de clientes | @Model.Count movimientos</p>
</div>

@If Model.Count = 0 Then
    @<div class="card border rounded-3 shadow-sm">
        <div class="card-body text-center py-5">
            <p class="fw-semibold mb-1">Aún no hay movimientos registrados</p>
            <p class="text-secondary small mb-0">Cuando se agregue, edite o elimine un cliente, el movimiento quedará registrado aquí</p>
        </div>
    </div>
Else
    @<div class="card border rounded-3 shadow-sm overflow-hidden">
        <div class="table-responsive">
            <table class="table table-hover align-middle mb-0">
                <thead class="table-light">
                    <tr class="text-uppercase small text-secondary">
                        <th class="fw-semibold py-3 ps-4">Fecha y hora</th>
                        <th class="fw-semibold py-3">Acción</th>
                        <th class="fw-semibold py-3">ID cliente</th>
                        <th class="fw-semibold py-3">Usuario</th>
                        <th class="fw-semibold py-3 pe-4">Detalle</th>
                    </tr>
                </thead>
                <tbody>
                    @For Each b In Model
                        Dim clase As String = "bg-secondary"
                        If b.Accion = "Agregar" Then clase = "bg-success"
                        If b.Accion = "Editar" Then clase = "bg-warning text-dark"
                        If b.Accion = "Eliminar" Then clase = "bg-danger"
                        @<tr>
                            <td class="text-nowrap text-secondary small py-3 ps-4">@b.FechaHora.ToString("dd/MM/yyyy HH:mm:ss")</td>
                            <td class="py-3"><span class="badge rounded-pill fw-medium px-3 py-2 @clase">@b.Accion</span></td>
                            <td class="py-3">@b.ClienteId</td>
                            <td class="fw-medium py-3">@b.NombreUsuario</td>
                            <td class="text-secondary py-3 pe-4">@b.Detalle</td>
                        </tr>
                    Next
                </tbody>
            </table>
        </div>
    </div>
End If