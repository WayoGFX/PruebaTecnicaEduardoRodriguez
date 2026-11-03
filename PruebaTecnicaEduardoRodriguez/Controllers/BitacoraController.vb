Imports System.Web.Mvc
Public Class BitacoraController
    Inherits Controller

    Private ReadOnly _bitacoraService As New BitacoraService()

    'método get para mostrar la vista de la bitácora
    Public Function Index() As ActionResult
        Return View(_bitacoraService.ObtenerRecientes())
    End Function
End Class