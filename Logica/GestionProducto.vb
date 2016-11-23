Public Class GestionProducto
    Dim lp As New Datos.BdProducto

    Public Function listado() As DataTable
        Dim dt As New DataTable
        dt = lp.consulta
        Return dt
    End Function

    Public Function buscar(id As Integer) As Entidades.Producto
        Try
            Dim dr As DataRow
            Dim filtro As String
            Dim pr As New Entidades.Producto
            filtro = String.Format("[IdProducto]={0}", id)
            dr = listado().Select(filtro)(0)
            pr.iProducto = dr.Item("IdProducto")
            pr.icategoria = dr.Item("Categoria")
            pr.NombreProducto = dr.Item("Nombre")
            pr.DescripcionProducto = dr.Item("Descripcion")
            pr.PrecioProducto = dr.Item("Precio")
            Return pr
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function GuardarProducto(p As Entidades.Producto) As String
        Dim i As Integer = lp.insertarProducto(p)
        If i = 1 Then
            Return "SE GUARDO CORRECTAMENTE " & p.NombreProducto
        Else
            Return "ERROR AL GUARDAR"
        End If

    End Function

    Public Function actualizarProducto(p As Entidades.Producto) As String
        If lp.actualizar(p) Then
            Return "ACTUALIZADO CORRECTAMENTE"
        Else
            Return "ERROR AL ACTUALIZAR"
        End If
    End Function

    Public Function eliminarProducto(id As Integer) As String
        If lp.eliminar(id) Then
            Return "ELIMINADO CORRECTAMENTE"
        Else
            Return "ERROR AL ELIMINAR"
        End If

    End Function
End Class
