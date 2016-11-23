Public Class PRINCIPAL

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Hora.Text = TimeOfDay
    End Sub

    Private Sub MENU_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Hora.Text = TimeOfDay
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Cliente.ShowDialog()

    End Sub

    Private Sub CategoriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoriaToolStripMenuItem.Click
        CategoriaP.ShowDialog()
    End Sub

    Private Sub ListaDeProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListaDeProductosToolStripMenuItem.Click
        Productos.ShowDialog()
    End Sub

    Private Sub MesasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MesasToolStripMenuItem.Click
        Mesas.ShowDialog()

    End Sub

    Private Sub PedirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedirToolStripMenuItem.Click

        Mesas.txtsw.Text = "1"
        Mesas.cmbOpciones.Text = "Desocupadas"
        Mesas.cmbOpciones.Enabled = False
        Mesas.btnAgregar.Visible = False
        Mesas.btnEliminar.Visible = False
        Mesas.ShowDialog()
        Mesas.txtsw.Text = "0"




    End Sub

    Private Sub ListaPedidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListaPedidosToolStripMenuItem.Click
        ListaPedidosG.ShowDialog()
    End Sub

    Private Sub RealizarVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RealizarVentaToolStripMenuItem.Click
        VentasR.ShowDialog()
    End Sub

    Private Sub ListaUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListaUsuariosToolStripMenuItem.Click
        UsuariosRes.ShowDialog()
    End Sub

    Private Sub ProductosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem1.Click
        FrmProductos.ShowDialog()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub BtnCerrarCesion_Click(sender As Object, e As EventArgs) Handles BtnCerrarCesion.Click
        Me.Close()
        Password.limpiar()
        Password.Show()
    End Sub

    Private Sub VentasPorFechaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasPorFechaToolStripMenuItem.Click
        VPorFecha.ShowDialog()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub VentasPorClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasPorClienteToolStripMenuItem.Click
        VentasPorCliente.ShowDialog()
    End Sub

    Private Sub TopProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TopProductosToolStripMenuItem.Click
        TopProductos.ShowDialog()
    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem.Click
        ListaPorUsuario.ShowDialog()
    End Sub
End Class
