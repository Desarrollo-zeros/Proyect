Imports CrystalDecisions.CrystalReports.Engine
Public Class VentasR
    Dim binVentas As New BindingSource

    Private Sub VentasR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
        limpiar()

    End Sub
    Sub CargarCliente()
        If txtIdCliente.Text <> "" Then
            Dim cl As New Entidades.Cliente
            cl = lc.buscar(txtIdCliente.Text)
            If cl Is Nothing Then
                MessageBox.Show("Cliente nuevo debe llenar los demas campos del Cliente", "CODIGO CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtApellido.ReadOnly = False
                txtTel.ReadOnly = False
                txtApellido.ReadOnly = False
                txtNombre.ReadOnly = False
                Exit Sub
            Else
                txtApellido.Text = cl.ApellidoC
                txtNombre.Text = cl.NombreC
                txtTel.Text = cl.TelefonoC
            End If
        Else
            MessageBox.Show("Ingrese Campo del Codigo Valido", "CODIGO CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub
    Sub guardar()
        If txtIdCliente.Text = "" Or txtNMesa.Text = "" Or Fecha.Text = Nothing Or txtTel.Text = "" Or txtApellido.Text = "" Or txtNombre.Text = "" Then
            MessageBox.Show("Faltan Campos para Realizar La venta", "REALIZAR VENTA", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            Dim result As DialogResult
            result = MessageBox.Show("Desea Realizar La venta", "REALIZAR VENTA", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If result = Windows.Forms.DialogResult.OK Then
                Dim cl As New Entidades.Cliente
                Dim v As New Entidades.Venta
                Dim dv As New Entidades.Detalle
                Dim msj, msj1 As String
                cl = lc.buscar(txtIdCliente.Text)

                If cl Is Nothing Then
                    Dim c As New Entidades.Cliente
                    c.cedula = txtIdCliente.Text
                    c.ApellidoC = txtApellido.Text
                    c.NombreC = txtNombre.Text
                    c.TelefonoC = txtTel.Text
                    lc.GuardarCliente(c)
                End If
                v.IdVenta_r = txtIdVenta.Text
                v.Cliente = txtIdCliente.Text
                v.Numero_Mesa = txtNMesa.Text
                v.fechaVenta = Fecha.Value
                v.total = txtTotalVenta.Text
                v.Usuario = txtUsuario.Text
                msj = lv.GuardarVenta(v)
                MessageBox.Show(msj, "GUARDANDO VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                For Each p As Entidades.Pedido In lp.listaPedidosPorMesa(txtNMesa.Text)
                    msj1 = ldv.GuardarDetalle(p, v)
                    MessageBox.Show(msj1, "GUARDANDO DETALLES", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Next
                Dim id As Integer
                id = txtIdVenta.Text
                Dim objForm = New FrmFacturaP
                objForm.idVenta = id
                objForm.ShowDialog()
                actualizarMesa()
                limpiar()
            End If
        End If
       
            mostrar()
            

    End Sub

    Private Sub PedidosMesa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
        limpiar()

    End Sub
    Sub mostrar()
        Try
            binVentas.DataSource = lv.listado
            ListaVentas.DataSource = binVentas
            ocultarColumnas()
            txtUsuario.Text = lu.buscarPorNombre(PRINCIPAL.Label2.Text).Cedula
            txtNombreU.Text = lu.buscarPorNombre(PRINCIPAL.Label2.Text).ApellidoU & lu.buscarPorNombre(PRINCIPAL.Label2.Text).NombreU

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        totalventa()
    End Sub
    Sub ocultarColumnas()
        ListaVentas.Columns.Item(0).Visible = False
        ListaVentas.Columns.Item(5).Visible = False

    End Sub

    Private Sub BuscarCliente_Click(sender As Object, e As EventArgs)

        Cliente.txtsw.Text = "1"
        Cliente.ShowDialog()
        Cliente.txtsw.Text = "0"
    End Sub

    Private Sub BuscarProducto_Click(sender As Object, e As EventArgs)
        Productos.txtSw.Text = "1"
        Productos.ShowDialog()
        Productos.txtSw.Text = "0"
    End Sub


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiar()

    End Sub
    Sub limpiar()
        txtIdVenta.Text = lv.TotalregVenta + 1
        txtNMesa.Clear()
        txtNombre.ReadOnly = True
        txtApellido.ReadOnly = True
        txtTel.ReadOnly = True
        txtNombre.Clear()
        txtIdCliente.Clear()
        txtTel.Clear()
        txtApellido.Clear()
        txtTel.ReadOnly = True
        txtNMesa.ReadOnly = True
        Fecha.Value = Now.Date
        VentasTotales.ReadOnly = True

        btnGuardar.Visible = True
    End Sub



    Sub totalventa()
        Dim total As Double = 0
        For Each row As DataGridViewRow In ListaVentas.Rows
            total = total + row.Cells.Item(6).Value
        Next
        VentasTotales.Text = total.ToString
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub ListaPedidos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles ListaVentas.RowsAdded

    End Sub


    Private Sub ListaPedidos_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles ListaVentas.RowsRemoved

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Detalles_Venta.ShowDialog()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Mesas.txtsw.Text = "2"
        Mesas.cmbOpciones.Text = "Ocupadas"
        Mesas.cmbOpciones.Enabled = False
        Mesas.ShowDialog()
        Mesas.txtsw.Text = "0"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Cliente.txtsw.Text = "2"
        Cliente.GroupBox1.Enabled = False
        Cliente.ShowDialog()
        Cliente.txtsw.Text = "0"
    End Sub

    



    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        guardar()

    End Sub
    Sub actualizarMesa()
        Try
            Dim msj As String
            If txtNMesa.Text <> "" Then
                For Each p As Entidades.Pedido In lp.listaPedidosPorMesa(txtNMesa.Text)
                    msj = lp.eliminarPedido(p.IDPedidoP)

                Next

                Dim msg As String
                msg = lm.actualizarDesocupada(txtNMesa.Text)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try




    End Sub


    Private Sub txtNMesa_TextChanged(sender As Object, e As EventArgs) Handles txtNMesa.TextChanged
        totalPorVenta()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub txtIdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIdCliente.KeyDown
        If e.KeyData = Keys.Enter Then
            CargarCliente()
        End If
    End Sub

    Private Sub txtIdCliente_TextChanged(sender As Object, e As EventArgs) Handles txtIdCliente.TextChanged

    End Sub

    Private Sub txtTotalVenta_TextChanged(sender As Object, e As EventArgs) Handles txtTotalVenta.TextChanged
        
    End Sub
    Sub totalPorVenta()
        Try
            Dim total As Double
            For Each p As Entidades.Pedido In lp.listaPedidosPorMesa(txtNMesa.Text)
                total += p.TotalPedido()
            Next
            txtTotalVenta.Text = total
        Catch ex As Exception

        End Try
        

    End Sub

    Sub filtro()

        If txtFiltro.TextLength = 0 Then
            binVentas.RemoveFilter()
            Exit Sub
        End If
        Try
            If cmbOpciones.Text = "IdVenta" Then
                binVentas.Filter = cmbOpciones.Text & " LIKE " & "'%" & txtFiltro.Text & "%'"
            Else
                binVentas.Filter = cmbOpciones.Text & "=" & txtFiltro.Text
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        filtro()

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dispose()

    End Sub
End Class