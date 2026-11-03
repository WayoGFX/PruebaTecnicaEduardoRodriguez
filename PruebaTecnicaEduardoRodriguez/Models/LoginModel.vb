Imports System.ComponentModel.DataAnnotations
Public Class LoginModel
    <Required(ErrorMessage:="El usuario es obligatorio")>
    Public Property NombreUsuario As String

    <Required(ErrorMessage:="La contraseña es obligatoria")>
    <DataType(DataType.Password)>
    Public Property Password As String
End Class