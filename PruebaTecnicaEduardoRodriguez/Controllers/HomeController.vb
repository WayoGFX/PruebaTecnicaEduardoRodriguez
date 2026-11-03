Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Prueba Técnica Fundamicro"

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Eduardo Rodríguez - Prueba Técnica Fundamicro"

        Return View()
    End Function
End Class
