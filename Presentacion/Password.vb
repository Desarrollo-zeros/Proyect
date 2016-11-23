Public Class Password
    Dim cont As Integer = 0
    Private Sub checkVerpass_CheckedChanged(sender As Object, e As EventArgs) Handles checkVerpass.CheckedChanged
        If checkVerpass.Checked = False Then
            txtpass.PasswordChar = "*"
        Else
            txtpass.PasswordChar = ""
        End If
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        verificar()

    End Sub

    Sub verificar()

        Dim usu As New Entidades.Usuario
        usu = lu.buscarPorUser(txtUser.Text)
        If usu Is Nothing Then
            MsgBox("Usuario No existe")
            cont += 1
            limpiar()

        Else
            If usu.LoginU = txtpass.Text Then


                MsgBox("BIENVENIDO" & usu.NombreU)

                PRINCIPAL.Label2.Text = usu.NombreU
                PRINCIPAL.Label4.Text = usu.Tipo
                If usu.Tipo = "EmpleadoA" Or usu.Tipo = "Mesero" Then
                    PRINCIPAL.UsuariosToolStripMenuItem.Enabled = False
                    PRINCIPAL.ReportesToolStripMenuItem.Enabled = False
                    PRINCIPAL.MesasToolStripMenuItem.Enabled = False
                    PRINCIPAL.CategoriaToolStripMenuItem.Enabled = False
                    PRINCIPAL.ProductosToolStripMenuItem.Enabled = False
                    PRINCIPAL.ClientesToolStripMenuItem.Enabled = False
                End If
                Me.Hide()
                PRINCIPAL.Show()
            Else
                MsgBox("Contraseña Incorrecta")
                txtpass.Clear()
                cont += 1

            End If
            If cont = 3 Then
                MsgBox("3 intentos Fallidos.. Programa se cerrará")
                Me.Dispose()
            End If
        End If

    End Sub

    Sub limpiar()
        txtUser.Clear()
        txtpass.Clear()
        txtUser.Focus()

    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        limpiar()

    End Sub

    Private Sub LinkSalir_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkSalir.LinkClicked
        Me.Dispose()
    End Sub

    Private Sub Password_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class