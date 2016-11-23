Public Class VentasPorCliente
    Dim binporCliente As New BindingSource
    Private Sub VentasPorCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarcombo()
    End Sub
    Sub llenarcombo()
        
        ListaClientes.DataSource = lc.listado

        ListaClientes.DisplayMember = "Nombre"
        ListaClientes.ValueMember = "CCliente"
    End Sub
    Sub filtro()
        Dim total As Double = 0
        binporCliente.DataSource = lv.listado
        binporCliente.Filter = "IdCliente =" & ListaClientes.SelectedValue.ToString
        ListaVenta.DataSource = binporCliente
        CantidadVentas.Text = ListaVenta.RowCount
        ocultarColumnas()
        For Each r As DataGridViewRow In ListaVenta.Rows
            total = total + r.Cells.Item(6).Value
        Next
        TotalVentas.Text = total

    End Sub
    Sub ocultarColumnas()
        ListaVenta.Columns.Item(0).Visible = False
        ListaVenta.Columns.Item(5).Visible = False

    End Sub
    Private Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click
        filtro()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dispose()

    End Sub
End Class