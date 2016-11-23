Public Class Pedido
    Private idPedido, Nmesa, idProducto As Integer
    Private precioU, cantidad, importe As Double


    Public Property IDPedidoP() As Integer
        Get
            Return idPedido
        End Get
        Set(ByVal value As Integer)
            idPedido = value
        End Set
    End Property

    Public Property NumeroMesa() As Integer
        Get
            Return Nmesa
        End Get
        Set(ByVal value As Integer)
            Nmesa = value
        End Set
    End Property

    Public Property IDProductoP() As Integer
        Get
            Return idProducto
        End Get
        Set(ByVal value As Integer)
            idProducto = value
        End Set
    End Property

    

    Public Property cantidadPr() As Double
        Get
            Return cantidad
        End Get
        Set(ByVal value As Double)
            cantidad = value
        End Set
    End Property

    Public Property PrecioUnit() As Double
        Get
            Return precioU
        End Get
        Set(ByVal value As Double)
            precioU = value
        End Set
    End Property

    Public Function TotalPedido() As Double
        importe = cantidad * precioU
        Return importe
    End Function
End Class
