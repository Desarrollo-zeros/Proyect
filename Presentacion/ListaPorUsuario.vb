Public Class ListaPorUsuario
    Dim binU As New BindingSource
    Private Sub ListaPorUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarcombo()

    End Sub
    Sub llenarcombo()

        ListaUsuario.DataSource = lu.listado

        ListaUsuario.DisplayMember = "Nombre"
        ListaUsuario.ValueMember = "IdUsuario"
    End Sub
    
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
    Sub filtro()
        Dim total As Double = 0
        binU.DataSource = lv.listado
        binU.Filter = "Usuario =" & ListaUsuario.SelectedValue.ToString
        ListaVenta.DataSource = binU
        CantidadVentas.Text = ListaVenta.RowCount
        ocultarColumnas()
        For Each r As DataGridViewRow In ListaVenta.Rows
            total = total + r.Cells.Item(6).Value
        Next
        TotalVentas.Text = total

    End Sub

    Sub ocultarColumnas()
        ListaVenta.Columns.Item(0).Visible = False
        ListaVenta.Columns.Item(1).Visible = False
        ListaVenta.Columns.Item(5).Visible = False
        ListaVenta.Columns.Item(7).Visible = False

    End Sub

    Private Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click
        filtro()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dispose()

    End Sub
End Class