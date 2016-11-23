Public Class VPorFecha
    Dim binporfecha As New BindingSource
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        filtro()
    End Sub

    Sub filtro()
        Try
            binporfecha.DataSource = lv.listado
            binporfecha.Filter = "FechaVenta >= '" & FechaDe.Value.ToShortDateString & "' AND FechaVenta <= '" & FechaHasta.Value.ToShortDateString & "'"
            listaVentas.DataSource = binporfecha
            ocultarColumnas()
            TotalVenta()
        Catch ex As Exception
            binporfecha.RemoveFilter()
            MsgBox(ex.Message)

        End Try



    End Sub

    Sub ocultarColumnas()
        listaVentas.Columns.Item(0).Visible = False
        listaVentas.Columns.Item(5).Visible = False

    End Sub

    Private Sub btnAtras_Click(sender As Object, e As EventArgs) Handles btnAtras.Click
        Dispose()

    End Sub

    Sub TotalVenta()
        Dim total As Double = 0
        For Each v As DataGridViewRow In listaVentas.Rows
            total += v.Cells.Item(6).Value
        Next
        txtTotal.Text = total
    End Sub

    Private Sub VPorFecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

End Class