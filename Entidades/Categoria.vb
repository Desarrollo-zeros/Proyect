Public Class Categoria
    Private idCategoria As Integer
    Private nombre As String


    Public Property ID() As Integer
        Get
            Return idCategoria
        End Get
        Set(ByVal value As Integer)
            idCategoria = value
        End Set
    End Property

    Public Property NombreCategoria() As String
        Get
            Return nombre
        End Get
        Set(ByVal value As String)
            nombre = value
        End Set
    End Property

    Sub New()

    End Sub

    Sub New(ide As Integer, nom As String)
        idCategoria = ide
        nombre = nom
    End Sub

End Class
