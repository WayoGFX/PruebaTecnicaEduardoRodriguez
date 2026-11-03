Imports System.Web.Mvc
<AllowAnonymous>
Public Class ErrorController
    Inherits Controller

    Public Function General() As ActionResult
        Response.StatusCode = 500
        Response.TrySkipIisCustomErrors = True
        Return View()
    End Function

    Public Function NoEncontrado() As ActionResult
        Response.StatusCode = 404
        Response.TrySkipIisCustomErrors = True
        Return View()
    End Function
End Class