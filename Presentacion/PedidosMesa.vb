Public Class PedidosMesa
    Dim binPedido As New BindingSource


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Guardar()
    End Sub
    Sub guardar()


        If txtCantidad.Text = "" Or txtIdProducto.Text = "" Then
            MessageBox.Show("Faltan Campos", "AGREGAR PEDIDO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            Dim msj As String
            Dim pe As New Entidades.Pedido
            Dim cl As New Entidades.Cliente


            pe.cantidadPr = txtCantidad.Text

            pe.PrecioUnit = txtPrecioU.Text
            pe.NumeroMesa = txtNMesa.Text
            pe.IDProductoP = txtIdProducto.Text
            Dim b As Boolean = False
            For Each d As DataGridViewRow In ListaPedidos.Rows
                If d.Cells.Item(2).Value = pe.IDProductoP Then
                    b = True
                End If
            Next
            If b = False Then
                pe.TotalPedido()
                msj = lp.GuardarPedido(pe)
                MessageBox.Show(msj, "AGREGAR PEDIDO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If ListaPedidos.RowCount > -1 Then
                    lm.actualizarMesas(txtNMesa.Text)
                Else
                    lm.actualizarDesocupada(txtNMesa.Text)

                End If
            Else
                MessageBox.Show("PEDIDO YA EXISTE VERIFIQUE", "AGREGAR PEDIDO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            mostrar()
            totalPedido()
            limpiar()
        End If



    End Sub
   

    Private Sub PedidosMesa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
        limpiar()
        totalPedido()
    End Sub
    Sub mostrar()
        Try
            binPedido.DataSource = lp.listado
            If txtMesa.Text = "1" Then
                binPedido.Filter = "Nmesa = " & txtNMesa.Text
                ListaPedidos.DataSource = binPedido

                If ListaPedidos.RowCount > 0 Then
                    lm.actualizarMesas(txtNMesa.Text)

                Else
                    lm.actualizarDesocupada(txtNMesa.Text)

                End If
            Else
                binPedido.Filter = "Nmesa = " & Mesas.ListaMesa.CurrentRow.Cells.Item(1).Value
                ListaPedidos.DataSource = binPedido

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            ListaPedidos.Columns.Item("Eliminar").Visible = False
            btnEditar.Visible = False
            If ListaPedidos.RowCount > 0 Then
                lm.actualizarMesas(txtNMesa.Text)

            Else
                lm.actualizarDesocupada(txtNMesa.Text)

            End If
            ocultarColumnas()
        End Try

    End Sub
    Sub ocultarColumnas()
        ListaPedidos.Columns.Item("Nmesa").Visible = False
        ListaPedidos.Columns.Item(2).Visible = False
        ListaPedidos.Columns.Item(1).Visible = False
    End Sub

    Private Sub BuscarCliente_Click(sender As Object, e As EventArgs)
        Cliente.txtsw.Text = "1"
        Cliente.ShowDialog()
        Cliente.txtsw.Text = "0"
    End Sub

    Private Sub BuscarProducto_Click(sender As Object, e As EventArgs) Handles BuscarProducto.Click
        Productos.txtSw.Text = "1"
        Productos.ShowDialog()
        Productos.txtSw.Text = "0"
    End Sub

    Private Sub txtIdProducto_TextChanged(sender As Object, e As EventArgs) Handles txtIdProducto.TextChanged
        Try
            txtPrecioU.Text = lprod.buscar(txtIdProducto.Text).PrecioProducto
        Catch ex As Exception

        End Try

    End Sub

    
   

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiar()

    End Sub
    Sub limpiar()
        txtNombreProducto.Clear()
        txtIdPedido.Clear()
        txtIdProducto.Clear()
        txtCantidad.Clear()
        txtPrecioU.Clear()

       
        txtNMesa.ReadOnly = True
        txtIdProducto.ReadOnly = True
        txtNombreProducto.ReadOnly = True
        txtPrecioU.ReadOnly = True
        txtTotalPedido.ReadOnly = True
        btnEditar.Visible = False
        btnGuardar.Visible = True
    End Sub

    

    Sub totalPedido()

        Dim total As Double = 0
        For Each row As DataGridViewRow In ListaPedidos.Rows
            total = total + row.Cells.Item(7).Value
        Next
        txtTotalPedido.Text = total.ToString




    End Sub

  

    Private Sub ListaPedidos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.ColumnIndex = ListaPedidos.Columns.Item("Eliminar").Index Then
            Dim checCell As DataGridViewCheckBoxCell = ListaPedidos.Rows(e.RowIndex).Cells("Eliminar")
            checCell.Value = Not checCell.Value
        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        eliminacion()
    End Sub
    Sub eliminacion()
        Dim resultado As DialogResult
        resultado = MessageBox.Show("Desea Realmente Eliminar los Pedidos Seleccionados?", "Eliminando Pedidos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If resultado = Windows.Forms.DialogResult.OK Then
            Try
                Dim sw As Boolean = False
                For Each row As DataGridViewRow In ListaPedidos.Rows
                    Dim mark = Convert.ToBoolean(row.Cells("Eliminar").Value)
                    If mark Then
                        sw = True
                        Dim id As String = row.Cells("IdPedido").Value
                        lp.eliminarPedido(id)

                    End If
                Next
                If sw = True Then
                    MessageBox.Show("Productos Eliminados Correctamente", "Eliminacion de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Seleccione items a  Eliminar", "Eliminacion de Productos", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If
                'MessageBox.Show("Pedidos Eliminados Correctamente", "Eliminacion de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error al eliminar", "Eliminacion de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Cancelando Eliminacion de Pedidos", "Eliminacion de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
        mostrar()
        limpiar()
        totalPedido()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        editar()
    End Sub
    Sub editar()
        Dim result As DialogResult
        result = MessageBox.Show("Desea Realmente modificar?", "MODIFICAR PEDIDO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If result = Windows.Forms.DialogResult.OK Then
            Dim msj As String
            Dim p As New Entidades.Pedido

            p.IDPedidoP = txtIdPedido.Text
            p.IDProductoP = txtIdProducto.Text
            p.NumeroMesa = txtNMesa.Text
            p.PrecioUnit = txtPrecioU.Text

            p.cantidadPr = txtCantidad.Text
            msj = lp.actualizarPedido(p)
            MessageBox.Show(msj, "MODIFICAR PEDIDO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Cancelando Modificacion", "MODIFICAR PEDIDO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        mostrar()
        totalPedido()
        limpiar()
    End Sub

    Private Sub chEliminar_CheckedChanged(sender As Object, e As EventArgs) Handles chEliminar.CheckedChanged
        If chEliminar.CheckState = CheckState.Checked Then
            ListaPedidos.Columns.Item("Eliminar").Visible = True
        Else
            ListaPedidos.Columns.Item("Eliminar").Visible = False
        End If
    End Sub


    Private Sub ListaPedidos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs)
        totalPedido()
    End Sub

   
    Private Sub ListaPedidos_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs)
        totalPedido()
    End Sub

    Private Sub txtIdCliente_KeyDown(sender As Object, e As KeyEventArgs)
       
    End Sub

    Private Sub ListaPedidos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListaPedidos.CellClick
        txtIdPedido.Text = ListaPedidos.CurrentRow.Cells.Item(1).Value
        txtIdProducto.Text = ListaPedidos.CurrentRow.Cells.Item(2).Value
        txtNombreProducto.Text = ListaPedidos.CurrentRow.Cells.Item(3).Value
        txtCantidad.Text = ListaPedidos.CurrentRow.Cells.Item(5).Value
        btnEditar.Visible = True
        btnGuardar.Visible = False
        totalPedido()
    End Sub

    

    

    Private Sub ListaPedidos_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles ListaPedidos.CellContentClick
        If e.ColumnIndex = ListaPedidos.Columns.Item("Eliminar").Index Then
            Dim checCell As DataGridViewCheckBoxCell = ListaPedidos.Rows(e.RowIndex).Cells("Eliminar")
            checCell.Value = Not checCell.Value
        End If
    End Sub

    Private Sub txtIdCliente_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True

        End If
    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dispose()

    End Sub
End Class