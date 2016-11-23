Public Class ListaPedidosG
    Dim binpedidos As New BindingSource
    
    Private Sub ListaPedidosG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_Mesas()
        filtro()
    End Sub
    Sub cargar_Mesas()
        filtro()
        cmbMesas.Items.Clear()
        cmbMesas.Items.Add("Todos")
        For Each r As DataRow In lp.listado.Rows
            If Not cmbMesas.Items.Contains(r.Item("Nmesa")) Then
                cmbMesas.Items.Add(r.Item("Nmesa"))
            End If
        Next

    End Sub
    Sub ocultarColumnas()
        ListaPedidos.Columns.Item(0).Visible = False
        ListaPedidos.Columns.Item(1).Visible = False
        ListaPedidos.Columns.Item(5).Visible = False

    End Sub
    Sub filtro()
        Try
            binpedidos.DataSource = lp.listado

            If cmbMesas.Text = Nothing Then
                binpedidos.RemoveFilter()
            ElseIf cmbMesas.Text = "Todos" Then
                binpedidos.RemoveFilter()
                ListaPedidos.DataSource = binpedidos
            Else
                binpedidos.Filter = "Nmesa =" & cmbMesas.Text
                ListaPedidos.DataSource = binpedidos
            End If
            ocultarColumnas()
        Catch ex As Exception

        End Try
       
    End Sub

    Private Sub cmbMesas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMesas.SelectedIndexChanged
        filtro()

    End Sub

    
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If ListaPedidos.CurrentRow.Index > -1 Then
                PedidosMesa.txtMesa.Text = "1"
                PedidosMesa.txtNMesa.Text = ListaPedidos.CurrentRow.Cells.Item(5).Value
                PedidosMesa.ShowDialog()
                PedidosMesa.txtMesa.Text = "0"
                cargar_Mesas()
            Else
                MsgBox("No Hay pedidos Seleccionados")
            End If
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dispose()

    End Sub

    Private Sub ListaPedidos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListaPedidos.CellContentClick

    End Sub
End Class