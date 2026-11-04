# Prueba técnica Fundamicro - Eduardo Rodríguez

Aplicación web para gestionar clientes, desarrollada en ASP.NET MVC 5 con VB.NET (.NET Framework 4.8) y SQL Server

**Autor:** Eduardo Rodríguez

## Funcionalidades

- **Login:** autenticación con usuario y contraseña, validados contra la tabla `Usuarios` en SQL Server
- **Mantenimiento de clientes:** ver, agregar, editar y eliminar clientes
- **Bitácora de acciones:** cada alta, edición o eliminación queda registrada en una tabla aparte con la acción, el ID del cliente, la fecha y hora y el usuario que hizo el cambio

## Requisitos

- Visual Studio 2022 con la carga de trabajo ASP.NET y desarrollo web
- .NET Framework 4.8
- SQL Server Management Studio (SSMS)

## Cómo ejecutarlo

1. **Crear la base de datos:** se debe abrir el `ScriptSQLPruebaTecnica.sql` en SSMS y ejecutarlo completo para crear la base de datos `PruebaTecnicaDb` con sus tablas `Usuarios`, `Clientes` y `Bitacora`, y el usuario de prueba. Debe ejecutarse en una instancia donde la base de datos aún no existe
2. **Ajustar la conexión:** en el `Web.config` del proyecto, se debe cambiar el `Data Source` de la cadena `PruebaTecnicaDb` por el nombre de la instancia de SQL Server que tenga en su computadora, por ejemplo:

   ```xml
   <add name="PruebaTecnicaDb"
        connectionString="Data Source=SERVIDOR\INSTANCIA;Initial Catalog=PruebaTecnicaDb;Integrated Security=True;TrustServerCertificate=True"
        providerName="System.Data.SqlClient" />
   ```

   La cadena usa autenticación de Windows (`Integrated Security=True`). Si tiene autenticación de SQL Server en su computadora, se debe reemplazar esa parte por `User Id=usuario;Password=contraseña`
3. **Ejecutar:** Para ejecutar solo se debe abrir la solución en Visual Studio, restaurar los paquetes NuGet los cuales se restauran automáticamente al compilar, y presiona **F5**

## Usuario de prueba

| Usuario | Contraseña      |
|---------|-----------------|
| `admin` | `PruebaTecnica` |

En la base de datos la contraseña se guarda como hash, en el login se escribe la contraseña normal

## Base de datos

| Tabla      | Descripción |
|------------|-------------|
| `Usuarios` | Usuarios del sistema con nombre de usuario único, hash de la contraseña y estado activo |
| `Clientes` | Nombre, apellido, correo (único), teléfono y dirección (opcionales) y fecha de creación |
| `Bitacora` | Acción (Agregar, Editar o Eliminar), ID del cliente, fecha y hora, usuario y un detalle del cambio |

`Bitacora` no tiene llave foránea hacia `Clientes`, así los registros se conservan aunque el cliente se elimine, pero sí tiene referencia con `Usuarios`

## Estructura del proyecto

```
Controllers/   LoginController, ClientesController, BitacoraController, HomeController, ErrorController
Models/        Cliente, Usuario, Bitacora, LoginModel
Services/      UsuarioService, ClienteService, BitacoraService, NegocioException
Helpers/       PasswordHelper (hash y verificación de contraseñas)
Views/         Login, Clientes, Bitacora, Home, Error, Shared
```

- Los controladores llaman a los servicios, y los servicios acceden a la base de datos con ADO.NET
- Las contraseñas se guardan con hash PBKDF2 y sal aleatoria por usuario, y se comparan en tiempo constante
- Todas las consultas usan `SqlParameter`, sin concatenar valores en el SQL
- Autenticación con `[Authorize]` como filtro global, excepto en el login y las páginas de error
- Cada cambio en un cliente y su registro en la bitácora van en la misma transacción
- El correo es único gracias a un índice en la base de datos, y el error se traduce a un mensaje claro