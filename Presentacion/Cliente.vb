Public Class Cliente
    Dim binClientes As New BindingSource


    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Me.Close()

    End Sub

    Private Sub Cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
        If txtsw.Text = "1" Then
            Me.GroupBox1.Enabled = False
            Me.btnEliminar.Visible = False
            Me.chEliminar.Visible = False
        Else
            Me.GroupBox1.Enabled = True
            Me.btnEliminar.Visible = True
            Me.chEliminar.Visible = True
        End If
    End Sub
    Sub mostrar()
        binClientes.DataSource = lc.listado
        Me.ListaClientes.DataSource = binClientes
        ListaClientes.Columns.Item("Eliminar").Visible = False
        btnEditar.Visible = False

    End Sub
    Sub buscar()
        If txtFiltro.TextLength = 0 Then
            binClientes.RemoveFilter()
            Exit Sub
        End If
        Try

            binClientes.Filter = cmbOpciones.Text & " LIKE " & "'%" & txtFiltro.Text & "%'"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub txtFlitro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        buscar()
    End Sub
    Sub limpiar()
        txtCedula.Clear()
        txtNombre.Clear()
        txtApellido.Clear()
        txtTelefono.Clear()
        txtDireccion.Clear()
        txtCedula.ReadOnly = False
        btnEditar.Visible = False
        btnGuardar.Visible = True
    End Sub

    
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiar()
        mostrar()

    End Sub

    Private Sub chEliminar_CheckedChanged(sender As Object, e As EventArgs) Handles chEliminar.CheckedChanged
        If chEliminar.CheckState = CheckState.Checked Then
            ListaClientes.Columns.Item("Eliminar").Visible = True
        Else
            ListaClientes.Columns.Item("Eliminar").Visible = False
        End If
    End Sub

    Private Sub ListaClientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListaClientes.CellClick
        txtCedula.Text = ListaClientes.CurrentRow.Cells.Item(1).Value
        txtNombre.Text = ListaClientes.CurrentRow.Cells.Item(2).Value
        txtApellido.Text = ListaClientes.CurrentRow.Cells.Item(3).Value
        txtDireccion.Text = ListaClientes.CurrentRow.Cells.Item(5).Value
        txtTelefono.Text = ListaClientes.CurrentRow.Cells.Item(4).Value
        btnEditar.Visible = True
        btnGuardar.Visible = False
        txtCedula.ReadOnly = True
    End Sub

    

    Private Sub ListaClientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListaClientes.CellContentClick
        If e.ColumnIndex = ListaClientes.Columns.Item("Eliminar").Index Then
            Dim checCell As DataGridViewCheckBoxCell = ListaClientes.Rows(e.RowIndex).Cells("Eliminar")
            checCell.Value = Not checCell.Value
        End If

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles btnEliminar.Click
        eliminacion()
    End Sub
    Sub eliminacion()
        Dim resultado As DialogResult
        resultado = MessageBox.Show("Desea Realmente Eliminar los Registros Seleccionados?", "Eliminando Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If resultado = Windows.Forms.DialogResult.OK Then
            Try
                Dim sw As Boolean = False
                For Each row As DataGridViewRow In ListaClientes.Rows
                    Dim mark = Convert.ToBoolean(row.Cells("Eliminar").Value)
                    If mark Then
                        sw = True
                        Dim id As String = row.Cells("CCliente").Value
                        lc.eliminarCliente(id)
                    End If
                Next
                If sw = True Then
                    MessageBox.Show("Productos Eliminados Correctamente", "Eliminacion de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Seleccione items a  Eliminar", "Eliminacion de Productos", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If
                'MessageBox.Show("Clientes Eliminados Correctamente", "Eliminacion de registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error al eliminar", "Eliminacion de registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Cancelando Eliminacion de de registros", "Eliminacion de registros", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
        mostrar()
        limpiar()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Guardar()

    End Sub
    Sub Guardar()
        If txtCedula.Text = "" Or txtNombre.Text = "" Or txtApellido.Text = "" Then
            MessageBox.Show("Faltan Campos", "AGREGAR CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim msj As String
            Dim cl As New Entidades.Cliente
            cl.cedula = txtCedula.Text
            cl.NombreC = txtNombre.Text
            cl.ApellidoC = txtApellido.Text
            cl.DireccionC = txtDireccion.Text
            cl.TelefonoC = txtTelefono.Text
            msj = lc.GuardarCliente(cl)
            MessageBox.Show(msj, "AGREGAR CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        mostrar()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        editar()

    End Sub
    Sub editar()
        Dim result As DialogResult
        result = MessageBox.Show("Desea Realmente modificar?", "MODIFICAR CLIENTE", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If result = Windows.Forms.DialogResult.OK Then
            Dim msj As String
            Dim cl As New Entidades.Cliente

            cl.cedula = txtCedula.Text
            cl.NombreC = txtNombre.Text
            cl.ApellidoC = txtApellido.Text
            cl.DireccionC = txtDireccion.Text
            cl.TelefonoC = txtTelefono.Text
            msj = lc.actualizarCliente(cl)
            MessageBox.Show(msj, "MODIFICAR CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Cancelando Modificacion", "MODIFICAR CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        mostrar()
        limpiar()

    End Sub

    Private Sub ListaClientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListaClientes.CellDoubleClick
        
        If txtsw.Text = "2" Then
            VentasR.txtIdCliente.Text = ListaClientes.CurrentRow.Cells.Item(1).Value
            VentasR.txtNombre.Text = ListaClientes.CurrentRow.Cells.Item(2).Value
            Me.Close()
        End If
    End Sub

    Private Sub txtDireccion_TextChanged(sender As Object, e As EventArgs) Handles txtDireccion.TextChanged


    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True

        End If
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged

    End Sub

    Private Sub txtApellido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApellido.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True

        End If
    End Sub

    Private Sub txtApellido_TextChanged(sender As Object, e As EventArgs) Handles txtApellido.TextChanged

    End Sub

    Private Sub txtCedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCedula.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True

        End If
    End Sub

    Private Sub txtCedula_TextChanged(sender As Object, e As EventArgs) Handles txtCedula.TextChanged

    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True

        End If
    End Sub

    Private Sub txtTelefono_TextChanged(sender As Object, e As EventArgs) Handles txtTelefono.TextChanged

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dispose()

    End Sub
End Class