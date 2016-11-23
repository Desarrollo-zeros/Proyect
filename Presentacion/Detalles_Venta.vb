Public Class Detalles_Venta
    Dim binDetalle As New BindingSource
    Private Sub Detalles_Venta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDetalle()

    End Sub
    Sub cargarDetalle()
        binDetalle.RemoveFilter()
        binDetalle.DataSource = ldv.listado
        ListaPedidos.DataSource = binDetalle
        ocultarColumna()
        totalventa()
    End Sub
    Sub ocultarColumna()
        ListaPedidos.Columns.Item(0).Visible = False
        ListaPedidos.Columns.Item(2).Visible = False
        ListaPedidos.Columns.Item(1).Visible = False
    End Sub
    Sub totalventa()
        Dim total As Double
        For Each p As DataRow In ldv.listado.Rows
            total += p.Item("Importe")
        Next
        txtTotalPedido.Text = total
    End Sub
    Sub filtro()
        If txtCod.Text = "" Then
            MsgBox("DIGITE CODIGO ")

        Else

            Try
                binDetalle.DataSource = ldv.listado
                binDetalle.Filter = "IdVenta=" & txtCod.Text
                ListaPedidos.DataSource = binDetalle
                totalPorventa()
            Catch ex As Exception
                MsgBox("No existe codigo")

            End Try
            
        End If

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        filtro()

    End Sub

    
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtCod.Clear()
        cargarDetalle()
        txtporVenta.Clear()
    End Sub
    Sub totalPorventa()
        Try
            Dim total As Double
            For Each p As DataRow In ldv.listado.Rows
                If p.Item("IdVenta") = txtCod.Text Then
                    total += p.Item("Importe")
                End If

            Next
            txtporVenta.Text = total
        Catch ex As Exception

        End Try
       
    End Sub

    Private Sub txtCod_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCod.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True

        End If
    End Sub

    
    Private Sub txtCod_TextChanged(sender As Object, e As EventArgs) Handles txtCod.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dispose()

    End Sub
End Class