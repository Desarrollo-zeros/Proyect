Public Class GestionPedido
    Public lp As New Datos.BdPedido

    Public Function listado() As DataTable
        Dim dt As New DataTable
        dt = lp.consulta
        Return dt
    End Function
    Public Function buscar(id As Integer) As Entidades.Pedido
        Try
            Dim dr As DataRow
            Dim filtro As String
            Dim p As New Entidades.Pedido
            filtro = String.Format("[IdPedido]={0}", id)
            dr = listado().Select(filtro)(0)
            p.IDProductoP = dr.Item("IdProducto")
            p.IDPedidoP = dr.Item("IdPedido")
            p.IDProductoP = dr.Item("IdProducto")
            p.cantidadPr = dr.Item("Cantidad")
            p.PrecioUnit = dr.Item("PrecioUnitario")
            p.NumeroMesa = dr.Item("Nmesa")

            p.TotalPedido()
            Return p
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function GuardarPedido(p As Entidades.Pedido) As String
        Dim i As Integer = lp.insertarPedido(p)
        If i = 1 Then
            Return "SE GUARDO CORRECTAMENTE " & p.IDPedidoP
        Else
            Return "NO SE PUDO GUARDAR"
        End If

    End Function

    Public Function actualizarPedido(p As Entidades.Pedido) As String
        If lp.actualizar(p) Then
            Return "ACTUALIZADO CORRECTAMENTE"
        Else
            Return "ERROR AL ACTUALIZAR"
        End If
    End Function

    Public Function eliminarPedido(id As Integer) As String
        If lp.eliminar(id) Then
            Return "ELIMINADO CORRECTAMENTE"
        Else
            Return "ERROR AL ELIMINAR"
        End If

    End Function

   

   
    Public Function totalVentaPorMesa(nm As Integer) As Double
        Dim total As Double = 0
        For Each r As DataRow In listado.Rows
            If r.Item("Nmesa") = nm Then
                total = total + r.Item("Cantidad") * r.Item("PrecioUnitario")
            End If
        Next
        Return total
    End Function
    Public Function listaPedidosPorMesa(nm As Integer) As List(Of Entidades.Pedido)
        Dim lp As New List(Of Entidades.Pedido)
        For Each r As DataRow In listado.Rows
            If r.Item("Nmesa") = nm Then
                Dim p As New Entidades.Pedido
                p.IDProductoP = r.Item("IdProducto")
                p.IDPedidoP = r.Item("IdPedido")
                p.IDProductoP = r.Item("IdProducto")
                p.cantidadPr = r.Item("Cantidad")
                p.PrecioUnit = r.Item("PrecioUnitario")
                p.NumeroMesa = r.Item("Nmesa")
                p.TotalPedido()
                lp.Add(p)
            End If
        Next
        Return lp
    End Function
End Class
