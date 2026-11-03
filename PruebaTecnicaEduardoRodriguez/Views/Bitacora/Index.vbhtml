@ModelType List(Of Bitacora)
@Code
    ViewData("Title") = "Bitácora"
End Code
<h2 class="mb-3">Bitácora de movimientos</h2>
<p class="text-muted">Movimientos registrados en los registros de clientes</p>

@If Model.Count = 0 Then
    @<p class="text-muted">No hay movimientos registrados</p>
Else
    @<div class="table-responsive">
        <table class="table table-striped table-hover align-middle">
            <thead>
                <tr>
                    <th>Fecha y hora</th>
                    <th>Acción</th>
                    <th>ID cliente</th>
                    <th>Usuario</th>
                    <th>Detalle</th>
                </tr>
            </thead>
            <tbody>
                @For Each b In Model
                    Dim clase As String = "bg-secondary"
                    If b.Accion = "Agregar" Then clase = "bg-success"
                    If b.Accion = "Editar" Then clase = "bg-warning text-dark"
                    If b.Accion = "Eliminar" Then clase = "bg-danger"
                    @<tr>
                        <td class="text-nowrap">@b.FechaHora.ToString("dd/MM/yyyy HH:mm:ss")</td>
                        <td><span class="badge @clase">@b.Accion</span></td>
                        <td>@b.ClienteId</td>
                        <td>@b.NombreUsuario</td>
                        <td>@b.Detalle</td>
                    </tr>
                Next
            </tbody>
        </table>
    </div>
End If