Imports System.IO

Public Class Productos
    Dim binProductos As New BindingSource
    Private Sub Productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PicImagen.Image = My.Resources.sinft
        mostrar()
        If txtSw.Text = 1 Then
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
        binProductos.DataSource = lprod.listado
        Me.ListaProductos.DataSource = binProductos
        ListaProductos.Columns.Item("Eliminar").Visible = False
        btnEditar.Visible = False
        ListaProductos.Columns(1).Visible = False
        ListaProductos.Columns(2).Visible = False

    End Sub
    Sub buscar()
        If txtFiltro.TextLength = 0 Then
            binProductos.RemoveFilter()
            Exit Sub
        End If
        Try
            If cmbOpciones.Text = "Nombre" Then
                binProductos.Filter = cmbOpciones.Text & " LIKE " & "'%" & txtFiltro.Text & "%'"
            Else
                binProductos.Filter = cmbOpciones.Text & "=" & txtFiltro.Text
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub txtFlitro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        buscar()
    End Sub
    Sub limpiar()
        txtIdProducto.Clear()
        txtNombreP.Clear()
        txtIdCat.Clear()
        txtDescrip.Clear()
        txtPrecio.Clear()
        PicImagen.Image = My.Resources.sinft
        txtIdProducto.ReadOnly = False
        btnEditar.Visible = False
        btnGuardar.Visible = True
    End Sub


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiar()
        mostrar()

    End Sub

    Private Sub chEliminar_CheckedChanged(sender As Object, e As EventArgs) Handles chEliminar.CheckedChanged
        If chEliminar.CheckState = CheckState.Checked Then
            ListaProductos.Columns.Item("Eliminar").Visible = True
        Else
            ListaProductos.Columns.Item("Eliminar").Visible = False
        End If
    End Sub

    Private Sub ListaClientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListaProductos.CellClick
        Try
            Dim b() As Byte = ListaProductos.SelectedCells.Item(7).Value
            Dim ms As New MemoryStream(b)
            PicImagen.Image = Image.FromStream(ms)
            PicImagen.SizeMode = PictureBoxSizeMode.StretchImage
        Catch ex As Exception

        End Try
        
        txtIdProducto.Text = ListaProductos.CurrentRow.Cells.Item(1).Value
        txtNombreP.Text = ListaProductos.CurrentRow.Cells.Item(4).Value
        txtIdCat.Text = ListaProductos.CurrentRow.Cells.Item(2).Value
        TxtNomCat.Text = lcat.buscar(txtIdCat.Text).NombreCategoria
        txtPrecio.Text = ListaProductos.CurrentRow.Cells.Item(6).Value
        txtDescrip.Text = ListaProductos.CurrentRow.Cells.Item(5).Value
        'PicImagen.Image = Nothing
       
        btnEditar.Visible = True
        btnGuardar.Visible = False
        txtIdProducto.ReadOnly = True


    End Sub



    Private Sub ListaClientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListaProductos.CellContentClick
        If e.ColumnIndex = ListaProductos.Columns.Item("Eliminar").Index Then
            Dim checCell As DataGridViewCheckBoxCell = ListaProductos.Rows(e.RowIndex).Cells("Eliminar")
            checCell.Value = Not checCell.Value
        End If

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles btnEliminar.Click
        eliminacion()
    End Sub
    Sub eliminacion()

        Dim resultado As DialogResult
        resultado = MessageBox.Show("Desea Realmente Eliminar los Productos Seleccionados?", "Eliminando Productoss", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If resultado = Windows.Forms.DialogResult.OK Then
            Try
                Dim sw As Boolean = False
                For Each row As DataGridViewRow In ListaProductos.Rows
                    Dim mark = Convert.ToBoolean(row.Cells("Eliminar").Value)
                    If mark Then
                        sw = True
                        Dim id As String = row.Cells("IdProducto").Value
                        lprod.eliminarProducto(id)
                    End If
                Next
                If sw = True Then
                    MessageBox.Show("Productos Eliminados Correctamente", "Eliminacion de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Seleccione items a  Eliminar", "Eliminacion de Productos", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If

            Catch ex As Exception
                MessageBox.Show("Error al eliminar", "Eliminacion de Productos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Cancelando Eliminacion de de Productos", "Eliminacion de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
        mostrar()
        limpiar()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Guardar()

    End Sub
    Sub Guardar()
        If txtNombreP.Text = "" Or txtIdCat.Text = "" Or txtPrecio.Text = "" Or txtDescrip.Text = "" Then
            MessageBox.Show("Faltan Campos", "AGREGAR PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim ms As New MemoryStream
            Dim msj As String
            Dim p As New Entidades.Producto

            p.NombreProducto = txtNombreP.Text
            p.icategoria = txtIdCat.Text
            p.PrecioProducto = txtPrecio.Text
            p.DescripcionProducto = txtDescrip.Text
            PicImagen.Image.Save(ms, PicImagen.Image.RawFormat)
            p.ImagenProducto = ms.GetBuffer
            msj = lprod.GuardarProducto(p)
            MessageBox.Show(msj, "AGREGAR Producto", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        mostrar()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        editar()

    End Sub
    Sub editar()
        Dim result As DialogResult
        result = MessageBox.Show("Desea Realmente modificar?", "MODIFICAR Producto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If result = Windows.Forms.DialogResult.OK Then
            Dim msj As String
            Dim ms As New MemoryStream
            Dim p As New Entidades.Producto

            p.iProducto = txtIdProducto.Text
            p.NombreProducto = txtNombreP.Text
            p.icategoria = txtIdCat.Text
            p.PrecioProducto = txtPrecio.Text
            p.DescripcionProducto = txtDescrip.Text
            Try
                PicImagen.Image.Save(ms, PicImagen.Image.RawFormat)
            Catch ex As Exception

            End Try

            p.ImagenProducto = ms.GetBuffer
            msj = lprod.actualizarProducto(p)
            MessageBox.Show(msj, "MODIFICAR PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Cancelando Modificacion", "MODIFICAR PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        mostrar()
        limpiar()
    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        OpenFileDialog1.Filter = "Imagenes JPG|*.jpg|Imagenes GIF|*.gif|Imagenes bitmasps|*.bmp"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PicImagen.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BuscarCategoria.Click
        CategoriaP.txtsw.Text = "1"
        CategoriaP.GroupBox1.Enabled = False
        CategoriaP.ShowDialog()
        CategoriaP.txtsw.Text = "0"

    End Sub

    Private Sub ListaProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListaProductos.CellDoubleClick
        If txtSw.Text = "1" Then
            PedidosMesa.txtIdProducto.Text = ListaProductos.CurrentRow.Cells.Item(1).Value
            PedidosMesa.txtNombreProducto.Text = ListaProductos.CurrentRow.Cells.Item(4).Value
            Me.Close()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dispose()

    End Sub
End Class