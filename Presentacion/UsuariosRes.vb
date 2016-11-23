Public Class UsuariosRes
    Dim binUsuario As New BindingSource

    Private Sub UsuariosRes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
        llenarCombo()
    End Sub
    Sub llenarCombo()
        cmbtipo.DataSource = lu.listaTipos
        cmbtipo.DisplayMember = "Tipo_Usuario"
        cmbtipo.ValueMember = "Numero"
    End Sub
    Sub mostrar()

        binUsuario.DataSource = lu.listado
        Me.ListaUsuario.DataSource = binUsuario
        ListaUsuario.Columns.Item("Eliminar").Visible = False
        btnEditar.Visible = False

    End Sub
    Sub buscar()
        If txtFiltro.TextLength = 0 Then
            binUsuario.RemoveFilter()
            Exit Sub
        End If
        Try
            binUsuario.Filter = cmbOpciones.Text & " LIKE " & "'%" & txtFiltro.Text & "%'"
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
        txtUser.Clear()
        txtlogin.Clear()
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
            ListaUsuario.Columns.Item("Eliminar").Visible = True
        Else
            ListaUsuario.Columns.Item("Eliminar").Visible = False
        End If
    End Sub

    Private Sub ListaClientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListaUsuario.CellClick
        txtCedula.Text = ListaUsuario.CurrentRow.Cells.Item(1).Value
        txtNombre.Text = ListaUsuario.CurrentRow.Cells.Item(2).Value
        txtApellido.Text = ListaUsuario.CurrentRow.Cells.Item(3).Value
        txtUser.Text = ListaUsuario.CurrentRow.Cells.Item(4).Value
        txtlogin.Text = ListaUsuario.CurrentRow.Cells.Item(5).Value
        txtDireccion.Text = ListaUsuario.CurrentRow.Cells.Item(6).Value
        txtTelefono.Text = ListaUsuario.CurrentRow.Cells.Item(7).Value
        btnEditar.Visible = True
        btnGuardar.Visible = False
        txtCedula.ReadOnly = True
    End Sub



    Private Sub ListaClientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListaUsuario.CellContentClick
        If e.ColumnIndex = ListaUsuario.Columns.Item("Eliminar").Index Then
            Dim checCell As DataGridViewCheckBoxCell = ListaUsuario.Rows(e.RowIndex).Cells("Eliminar")
            checCell.Value = Not checCell.Value
        End If

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles btnEliminar.Click
        eliminacion()
    End Sub
    Sub eliminacion()
        Dim resultado As DialogResult
        resultado = MessageBox.Show("Desea Realmente Eliminar los Registros Seleccionados?", "Eliminando Usuarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If resultado = Windows.Forms.DialogResult.OK Then
            Try
                Dim sw As Boolean = False
                For Each row As DataGridViewRow In ListaUsuario.Rows
                    Dim mark = Convert.ToBoolean(row.Cells("Eliminar").Value)
                    If mark Then
                        sw = True
                        Dim id As String = row.Cells("IdUsuario").Value
                        lu.eliminarUsuario(id)
                    End If
                Next
                If sw = True Then
                    MessageBox.Show("Productos Eliminados Correctamente", "Eliminacion de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Seleccione items a  Eliminar", "Eliminacion de Productos", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If
                'MessageBox.Show("Clientes Eliminados Correctamente", "Eliminacion de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error al eliminar", "Eliminacion de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Cancelando Eliminacion de de registros", "Eliminacion de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
        mostrar()
        limpiar()
    End Sub






























































































































































    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Guardar()

    End Sub
    Sub Guardar()
        If txtCedula.Text = "" Or txtNombre.Text = "" Or txtApellido.Text = "" Or txtUser.Text = "" Or txtlogin.Text = "" Or cmbtipo.ValueMember = Nothing Then
            MessageBox.Show("Faltan Campos", "AGREGAR USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim msj As String
            Dim u As New Entidades.Usuario
            u.Cedula = txtCedula.Text
            u.NombreU = txtNombre.Text
            u.ApellidoU = txtApellido.Text
            u.UserNameU = txtUser.Text
            u.LoginU = txtlogin.Text
            u.DireccionU = txtDireccion.Text
            u.TelefonoU = txtTelefono.Text
            u.TipoUser = cmbtipo.SelectedValue.ToString
            msj = lu.GuardarUsuario(u)
            MessageBox.Show(msj, "AGREGAR USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            limpiar()
        End If
        mostrar()

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        editar()

    End Sub
    Sub editar()
        Dim result As DialogResult
        result = MessageBox.Show("Desea Realmente modificar?", "MODIFICAR USUARIO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If result = Windows.Forms.DialogResult.OK Then
            Dim msj As String
            Dim u As New Entidades.Usuario
            u.Cedula = txtCedula.Text
            u.NombreU = txtNombre.Text
            u.ApellidoU = txtApellido.Text
            u.UserNameU = txtUser.Text
            u.LoginU = txtlogin.Text
            u.DireccionU = txtDireccion.Text
            u.TelefonoU = txtTelefono.Text
            msj = lu.actualizarUsuario(u)
            
            MessageBox.Show(msj, "MODIFICAR USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Cancelando Modificacion", "MODIFICAR USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        mostrar()
        limpiar()

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

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