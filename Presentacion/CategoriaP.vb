Public Class CategoriaP
    Dim binCategoria As New BindingSource
    Private Sub CategoriaP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
        If txtsw.Text = "0" Then
            GroupBox1.Enabled = True
        End If
    End Sub
    Sub mostrar()
        binCategoria.DataSource = lcat.listado
        Me.ListaCategoria.DataSource = binCategoria
        ListaCategoria.Columns.Item("Eliminar").Visible = False
        btnEditar.Visible = False
        'ListaCategoria.Sort(ListaCategoria.Columns(0), System.ComponentModel.ListSortDirection.Descending) ORGANIZAR DATA GRID VIEW



    End Sub
    Sub buscar()
        If txtFiltro.TextLength = 0 Then
            binCategoria.RemoveFilter()
            Exit Sub
        End If
        Try
            If cmbOpciones.Text = "NombreCategoria" Then
                binCategoria.Filter = cmbOpciones.Text & " LIKE " & "'%" & txtFiltro.Text & "%'"
            Else
                binCategoria.Filter = cmbOpciones.Text & "=" & txtFiltro.Text
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub txtFlitro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        buscar()
    End Sub
    Sub limpiar()
        txtIdCategoria.Clear()
        txtNombreCategoria.Clear()
        txtIdCategoria.ReadOnly = False
        btnEditar.Visible = False
        btnGuardar.Visible = True
    End Sub


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiar()
        mostrar()

    End Sub

    Private Sub chEliminar_CheckedChanged(sender As Object, e As EventArgs) Handles chEliminar.CheckedChanged
        If chEliminar.CheckState = CheckState.Checked Then
            ListaCategoria.Columns.Item("Eliminar").Visible = True
        Else
            ListaCategoria.Columns.Item("Eliminar").Visible = False
        End If
    End Sub

    Private Sub ListaClientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListaCategoria.CellClick
        txtIdCategoria.Text = ListaCategoria.CurrentRow.Cells.Item(1).Value
        txtNombreCategoria.Text = ListaCategoria.CurrentRow.Cells.Item(2).Value
        btnEditar.Visible = True
        btnGuardar.Visible = False
        txtIdCategoria.ReadOnly = True
    End Sub



    Private Sub ListaClientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListaCategoria.CellContentClick
        If e.ColumnIndex = ListaCategoria.Columns.Item("Eliminar").Index Then
            Dim checCell As DataGridViewCheckBoxCell = ListaCategoria.Rows(e.RowIndex).Cells("Eliminar")
            checCell.Value = Not checCell.Value
        End If

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles btnEliminar.Click
        eliminacion()
    End Sub
    Sub eliminacion()
        Dim resultado As DialogResult
        resultado = MessageBox.Show("Desea Realmente Eliminar las Categorias Seleccionadas?", "Eliminando Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If resultado = Windows.Forms.DialogResult.OK Then
            Try
                Dim sw As Boolean = False
                For Each row As DataGridViewRow In ListaCategoria.Rows
                    Dim mark = Convert.ToBoolean(row.Cells("Eliminar").Value)
                    If mark Then
                        sw = True
                        Dim id As String = row.Cells("IdCategoria").Value
                        lcat.eliminarCategoria(id)
                    End If
                Next
                If sw = True Then
                    MessageBox.Show("Productos Eliminados Correctamente", "Eliminacion de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Seleccione items a  Eliminar", "Eliminacion de Productos", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If
                'MessageBox.Show("Categorias Eliminados Correctamente", "Eliminacion de registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If txtNombreCategoria.Text = "" Then
            MessageBox.Show("Faltan Campos", "AGREGAR CATEGORIA", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim msj As String
            Dim cat As New Entidades.Categoria
            cat.NombreCategoria = txtNombreCategoria.Text
            
            msj = lcat.guardar(cat)
            MessageBox.Show(msj, "AGREGAR CATEGORIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        mostrar()
        limpiar()

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        editar()

    End Sub
    Sub editar()
        Dim result As DialogResult
        result = MessageBox.Show("Desea Realmente modificar?", "MODIFICAR CATEGORIA", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If result = Windows.Forms.DialogResult.OK Then
            Dim msj As String
            Dim cat As New Entidades.Categoria
            cat.ID = txtIdCategoria.Text
            cat.NombreCategoria = txtNombreCategoria.Text
            msj = lcat.actualizarCategoria(cat)
            MessageBox.Show(msj, "MODIFICAR CATEGORIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Cancelando Modificacion", "MODIFICAR CATEGORIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        mostrar()
        limpiar()

    End Sub

    Private Sub ListaCategoria_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListaCategoria.CellDoubleClick
        If txtsw.Text = "1" Then
            Productos.txtIdCat.Text = ListaCategoria.SelectedCells.Item(1).Value
            Productos.TxtNomCat.Text = ListaCategoria.SelectedCells.Item(2).Value

            Me.Close()
        End If

    End Sub

    Private Sub txtIdCategoria_TextChanged(sender As Object, e As EventArgs) Handles txtIdCategoria.TextChanged

    End Sub

    Private Sub txtNombreCategoria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreCategoria.KeyPress
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

    Private Sub txtNombreCategoria_TextChanged(sender As Object, e As EventArgs) Handles txtNombreCategoria.TextChanged

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dispose()

    End Sub
End Class