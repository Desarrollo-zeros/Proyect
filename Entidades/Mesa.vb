Public Class Mesa
    Private Nmesa As Integer
    Private estado As Integer

    Public Property MesaN() As Integer
        Get
            Return Nmesa
        End Get
        Set(ByVal value As Integer)
            Nmesa = value
        End Set
    End Property

    Public Property EstadoM() As Integer
        Get
            Return estado
        End Get
        Set(ByVal value As Integer)
            estado = value
        End Set
    End Property

    Public Function EstadoMesa(p As Pedido) As Integer
        If p.NumeroMesa = Me.Nmesa Then
            Return 0
        Else
            Return 1
        End If
    End Function
    

    Sub New()
        estado = 1
    End Sub
End Class
