Public Class Detalle
    Private idDetalle, idventa, idProducto As Integer
    Private cantidad, precioU, precioT As Double


    Public Property IdDetalleV() As Integer
        Get
            Return IdDetalle
        End Get
        Set(ByVal value As Integer)
            idDetalle = value
        End Set
    End Property


    Public Property IdVentaV() As Integer
        Get
            Return idventa
        End Get
        Set(ByVal value As Integer)
            idventa = value
        End Set
    End Property


    Public Property IdProductoV() As Integer
        Get
            Return idProducto
        End Get
        Set(ByVal value As Integer)
            idProducto = value
        End Set
    End Property


    Public Property CantidadP() As Double
        Get
            Return cantidad
        End Get
        Set(ByVal value As Double)
            cantidad = value
        End Set
    End Property


    Public Property PrecioUV() As Double
        Get
            Return precioU
        End Get
        Set(ByVal value As Double)
            precioU = value
        End Set
    End Property


    Public Function PrecioTotal() As Double
        PrecioTotal = precioU * cantidad
        Return PrecioTotal
    End Function


End Class
