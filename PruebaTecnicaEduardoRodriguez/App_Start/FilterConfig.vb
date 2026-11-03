Imports System.Web.Mvc
Public Module FilterConfig
    Public Sub RegisterGlobalFilters(filters As GlobalFilterCollection)
        filters.Add(New HandleErrorAttribute())
        filters.Add(New AuthorizeAttribute())
    End Sub
End Module