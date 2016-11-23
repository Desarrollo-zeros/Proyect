Public Class Cliente
    Private cc, nombre, apellido, telefono, direccion As String

    Public Property cedula() As String
        Get
            Return cc
        End Get
        Set(ByVal value As String)
            cc = value
        End Set
    End Property

    Public Property NombreC() As String
        Get
            Return nombre
        End Get
        Set(ByVal value As String)
            nombre = value
        End Set
    End Property

    Public Property ApellidoC() As String
        Get
            Return apellido
        End Get
        Set(ByVal value As String)
            apellido = value
        End Set
    End Property
    Public Property TelefonoC() As String
        Get
            Return telefono
        End Get
        Set(ByVal value As String)
            telefono = value
        End Set
    End Property
    Public Property DireccionC() As String
        Get
            Return direccion
        End Get
        Set(ByVal value As String)
            direccion = value
        End Set
    End Property

    Sub New()

    End Sub

    Sub New(cedu As String, nom As String, ape As String, tel As String, dir As String)
        cc = cedu
        nombre = nom
        apellido = ape
        telefono = tel
        direccion = dir
    End Sub

End Class
