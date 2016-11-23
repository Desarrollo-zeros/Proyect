
Public Class Mesas
    Dim binMesa As New BindingSource


    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Dim result As DialogResult
            result = MessageBox.Show("Desea agregar una Mesa?", "AGREGAR MESA", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If result = Windows.Forms.DialogResult.OK Then
                Dim msj As String
                Dim m As New Entidades.Mesa
                msj = lm.guardar(m)
                MessageBox.Show("Mesa Creada Correctamente", "AGREGAR MESA", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Cancelando Creacion de Mesa", "AGREGAR MESA", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            
        Catch ex As Exception
            MessageBox.Show("Error al crear la Mesa", "AGREGAR MESA", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        mostrar()
    End Sub

    Sub mostrar()
        binMesa.DataSource = lm.listado
        ListaMesa.DataSource = binMesa
        ListaMesa.Columns.Item("Eliminar").Visible = False
    End Sub

    Private Sub Mesas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If txtsw.Text = "0" Then
            cmbOpciones.Enabled = True
            btnAgregar.Visible = True
            btnEliminar.Visible = True
        End If
        mostrar()
        ocultarColumna()
        buscar()
    End Sub
    Sub ocultarColumna()
        ListaMesa.Columns.Item("Estado").Visible = False
    End Sub
    Private Sub cmbOpciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOpciones.SelectedIndexChanged
        buscar()

    End Sub
    Sub buscar()
        If cmbOpciones.Text = "Todas" Then
            binMesa.RemoveFilter()
            Exit Sub
        End If
        Try
            If cmbOpciones.Text = "Ocupadas" Then
                binMesa.Filter = "Estado =" & 0
            Else
                binMesa.Filter = "Estado =" & 1
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chEliminar_CheckedChanged(sender As Object, e As EventArgs) Handles chEliminar.CheckedChanged
        If chEliminar.CheckState = CheckState.Checked Then
            ListaMesa.Columns.Item("Eliminar").Visible = True
        Else
            ListaMesa.Columns.Item("Eliminar").Visible = False
        End If
    End Sub

    Private Sub ListaMesa_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListaMesa.CellContentClick
        If e.ColumnIndex = ListaMesa.Columns.Item("Eliminar").Index Then
            Dim checCell As DataGridViewCheckBoxCell = ListaMesa.Rows(e.RowIndex).Cells("Eliminar")
            checCell.Value = Not checCell.Value
        End If
    End Sub

    Sub eliminarMesa()
        Dim resultado As DialogResult
        resultado = MessageBox.Show("Desea Realmente Eliminar las Mesas Seleccionadas?", "Eliminando Mesas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If resultado = Windows.Forms.DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In ListaMesa.Rows
                    Dim mark = Convert.ToBoolean(row.Cells("Eliminar").Value)
                    If mark Then
                        Dim nm As String = row.Cells("Numero").Value
                        lm.eliminarMesa(nm)
                    End If
                Next
                MessageBox.Show("Mesas Eliminadas Correctamente", "Eliminacion de Mesas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error al eliminar", "Eliminacion de Mesas", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Cancelando Eliminacion de Mesas", "Eliminacion de Mesas", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim mark As Boolean
        For Each row As DataGridViewRow In ListaMesa.Rows
            mark = Convert.ToBoolean(row.Cells("Eliminar").Value)
            If mark Then
                Exit For
            End If
        Next
        If chEliminar.CheckState = CheckState.Checked And mark Then
            eliminarMesa()
        Else
            MessageBox.Show("No ha seleccionado Mesas a Eliminar", "Eliminacion de Mesas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If





    End Sub

    Private Sub ListaMesa_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListaMesa.CellDoubleClick

        If txtsw.Text = "1" Then
            PedidosMesa.txtNMesa.Text = Me.ListaMesa.CurrentRow.Cells.Item(1).Value
            
            PedidosMesa.ShowDialog()
            txtsw.Text = "0"
            Me.Close()
        ElseIf txtsw.Text = "2" Then
            VentasR.txtNMesa.Text = Me.ListaMesa.CurrentRow.Cells.Item(1).Value
            txtsw.Text = "0"
            Me.Close()
        End If
        buscar()
    End Sub

    
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dispose()

    End Sub
End Class