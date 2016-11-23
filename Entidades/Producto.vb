Public Class Producto
    Private nombre As String
    Private descripcion As String
    Private precio As Decimal
    Private categoria, idProducto As Integer
    Private imagen As Byte()

    Public Property ImagenProducto As Byte()
        Get
            Return imagen
        End Get
        Set(value As Byte())
            imagen = value
        End Set
    End Property


    Public Property NombreProducto() As String
        Get
            Return nombre
        End Get
        Set(ByVal value As String)
            nombre = value
        End Set
    End Property

    Public Property DescripcionProducto() As String
        Get
            Return descripcion
        End Get
        Set(ByVal value As String)
            descripcion = value
        End Set
    End Property

    Public Property PrecioProducto() As Decimal
        Get
            Return precio
        End Get
        Set(ByVal value As Decimal)
            precio = value
        End Set
    End Property

    Public Property iProducto() As Integer
        Get
            Return idProducto
        End Get
        Set(ByVal value As Integer)
            idProducto = value
        End Set
    End Property
    Public Property icategoria() As Integer
        Get
            Return categoria
        End Get
        Set(ByVal value As Integer)
            categoria = value
        End Set
    End Property
    Sub New()

    End Sub

    Sub New(idp As Integer, idcat As Integer, nombreP As String, descripcionP As String, precioP As Decimal)
        Me.precio = precioP
        Me.descripcion = descripcionP
        Me.nombre = nombreP
        Me.categoria = idcat
        Me.idProducto = idp

    End Sub
End Class
