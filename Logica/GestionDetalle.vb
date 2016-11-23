Public Class GestionDetalle
    Dim ld As New Datos.BdDetalle

    Public Function listado() As DataTable
        Dim dt As New DataTable
        dt = ld.consulta
        Return dt
    End Function

    Public Function buscar(id As Integer) As Entidades.Detalle
        Try
            Dim dr As DataRow
            Dim filtro As String
            Dim d As New Entidades.Detalle
            filtro = String.Format("[IdDetalleVenta]={0}", id)
            dr = listado().Select(filtro)(0)
            d.IdDetalleV = dr.Item("IdDetalleVenta")
            d.IdVentaV = dr.Item("IdVenta")
            d.IdProductoV = dr.Item("IdProducto")
            d.CantidadP = dr.Item("Cantidad")
            d.PrecioUV = dr.Item("PrecioUnitario")
            d.PrecioTotal()
            Return d
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function GuardarDetalle(p As Entidades.Pedido, v As Entidades.Venta) As String
        Dim i As Integer = ld.insertarDetalle(p, v)
        If i = 1 Then
            Return "SE GUARDO CORRECTAMENTE " & p.IDPedidoP
        Else
            Return "NO SE PUDO GUARDAR"
        End If

    End Function

    Public Function actualizarDetalle(d As Entidades.Detalle) As String
        If ld.actualizar(d) Then
            Return "ACTUALIZADO CORRECTAMENTE"
        Else
            Return "ERROR AL ACTUALIZAR"
        End If
    End Function

    Public Function eliminarDetalle(id As Integer) As String
        If ld.eliminar(id) Then
            Return "ELIMINADO CORRECTAMENTE"
        Else
            Return "ERROR AL ELIMINAR"
        End If

    End Function

    Public Function cantidadProducto() As List(Of Integer)
        Return ld.Cantidad_Producto()
    End Function
    Public Function listacodigos() As List(Of Integer)
        Return ld.listacod
    End Function
End Class
