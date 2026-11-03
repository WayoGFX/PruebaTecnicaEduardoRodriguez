Imports System.ComponentModel.DataAnnotations
Public Class Cliente
    Public Property Id As Integer

    <Required(ErrorMessage:="El nombre es obligatorio")>
    <StringLength(100, ErrorMessage:="Máximo 100 caracteres")>
    Public Property Nombre As String

    <Required(ErrorMessage:="El apellido es obligatorio")>
    <StringLength(100, ErrorMessage:="Máximo 100 caracteres")>
    Public Property Apellido As String

    <Required(ErrorMessage:="El correo es obligatorio")>
    <EmailAddress(ErrorMessage:="Correo no válido")>
    <StringLength(150, ErrorMessage:="Máximo 150 caracteres")>
    Public Property Email As String

    <StringLength(8, ErrorMessage:="Máximo 8 caracteres")>
    <RegularExpression("^[0-9+\-\s]*$", ErrorMessage:="Solo números, espacios, +")>
    Public Property Telefono As String

    <StringLength(250, ErrorMessage:="Máximo 250 caracteres")>
    Public Property Direccion As String

    Public Property FechaCreacion As DateTime
End Class