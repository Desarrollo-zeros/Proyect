Public Class Venta
    Private IdVenta As Integer
    Private idCliente As String
    Private fecha As Date
    Private Num_mesa As Integer
    Private totalV As Double
    Private idUsuario As String


    Public Property Usuario() As String
        Get
            Return idUsuario
        End Get
        Set(ByVal value As String)
            idUsuario = value
        End Set
    End Property

    Public Property total() As Double
        Get
            Return totalV
        End Get
        Set(ByVal value As Double)
            totalV = value
        End Set
    End Property


    Public Property IdVenta_r() As Integer
        Get
            Return IdVenta
        End Get
        Set(ByVal value As Integer)
            IdVenta = value
        End Set
    End Property

    Public Property Numero_Mesa() As Integer
        Get
            Return Num_mesa
        End Get
        Set(ByVal value As Integer)
            Num_mesa = value
        End Set
    End Property

    Public Property Cliente() As String
        Get
            Return idCliente
        End Get
        Set(ByVal value As String)
            idCliente = value
        End Set
    End Property

    Public Property fechaVenta() As Date
        Get
            Return fecha
        End Get
        Set(ByVal value As Date)
            fecha = value
        End Set
    End Property
    Sub New()

    End Sub
End Class
