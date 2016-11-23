Public Class TopProductos


    Private Sub TopProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim i As Integer = 0
        For Each prod As Integer In ldv.cantidadProducto

            Dim nom As String = lprod.buscar(ldv.listacodigos.Item(i)).NombreProducto

            top.Rows.Add(nom, prod)
            i += 1

        Next
        Dim total As Integer
        For Each d As DataGridViewRow In top.Rows
            total += d.Cells.Item(1).Value
        Next
        Cantidad.ReadOnly = True
        Cantidad.Text = total

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dispose()
    End Sub

    
End Class