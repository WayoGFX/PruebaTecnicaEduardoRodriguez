Imports System.Web.Mvc
Imports System.Web.Security

Public Class LoginController
    Inherits Controller

    Private ReadOnly _usuarioService As New UsuarioService()

    'Obtener vista de login
    <HttpGet>
    <AllowAnonymous>
    Public Function Login() As ActionResult
        If User.Identity.IsAuthenticated Then
            Return RedirectToAction("Index", "Clientes")
        End If
        Return View(New LoginModel())
    End Function

    'Login metodo post para validar credenciales
    <HttpPost>
    <AllowAnonymous>
    <ValidateAntiForgeryToken>
    Public Function Login(modelo As LoginModel, returnUrl As String) As ActionResult
        If Not ModelState.IsValid Then
            Return View(modelo)
        End If

        Try
            Dim usuario As Usuario = _usuarioService.ValidarLogin(modelo.NombreUsuario, modelo.Password)

            If usuario Is Nothing Then
                ModelState.AddModelError("", "Usuario o contraseña incorrectos")
                Return View(modelo)
            End If

            FormsAuthentication.SetAuthCookie(usuario.NombreUsuario, False)

            'Solo a url local
            If Url.IsLocalUrl(returnUrl) Then
                Return Redirect(returnUrl)
            End If
            Return RedirectToAction("Index", "Clientes")

        Catch ex As Exception
            System.Diagnostics.Trace.TraceError(ex.ToString())
            ModelState.AddModelError("", "Ocurrió un error al iniciar sesión, puede intentar de nuevo")
            Return View(modelo)
        End Try
    End Function

    'Logout de usuario
    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Function Logout() As ActionResult
        FormsAuthentication.SignOut()
        Session.Abandon()
        Return RedirectToAction("Login")
    End Function
End Class