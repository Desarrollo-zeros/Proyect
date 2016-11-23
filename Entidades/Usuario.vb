Public Class Usuario
    Private cc, nombre, apellido, username, login, telefono, direccion, tipoS As String
    Private tipoUsiario As String
    Private tipoint As Integer

    Public Property TipoUser() As Integer
        Get
            Return tipoint
        End Get
        Set(ByVal value As Integer)
            tipoint = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return tipoUsiario
        End Get
        Set(ByVal value As String)
            tipoUsiario = value
        End Set
    End Property

    Public Property Cedula() As String
        Get
            Return cc
        End Get
        Set(ByVal value As String)
            cc = value
        End Set
    End Property

    Public Property NombreU() As String
        Get
            Return nombre
        End Get
        Set(ByVal value As String)
            nombre = value
        End Set
    End Property


    Public Property ApellidoU() As String
        Get
            Return apellido
        End Get
        Set(ByVal value As String)
            apellido = value
        End Set
    End Property

    Public Property UserNameU As String
        Get
            Return username
        End Get
        Set(value As String)
            username = value
        End Set
    End Property


    Public Property LoginU() As String
        Get
            Return login
        End Get
        Set(ByVal value As String)
            login = value
        End Set
    End Property


    Public Property TelefonoU() As String
        Get
            Return telefono
        End Get
        Set(ByVal value As String)
            telefono = value
        End Set
    End Property


    Public Property DireccionU() As String
        Get
            Return direccion
        End Get
        Set(ByVal value As String)
            direccion = value
        End Set
    End Property

    Sub New()

    End Sub

    Sub New(cedu As String, nom As String, ape As String, user As String, log As String, tel As String, dir As String)
        cc = cedu
        nombre = nom
        apellido = ape
        username = user
        login = log
        telefono = tel
        direccion = dir
    End Sub
End Class
