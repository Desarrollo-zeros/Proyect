Public Class GestionCliente
    Dim lc As New Datos.BdCliente

    Public Function listado() As DataTable
        Dim dt As New DataTable
        dt = lc.consulta
        Return dt
    End Function

    Public Function buscar(ced As String) As Entidades.Cliente
        Try
            Dim dr As DataRow
            Dim filtro As String
            Dim client As New Entidades.Cliente
            filtro = String.Format("[CCliente]='{0}'", ced)
            dr = listado().Select(filtro)(0)
            client.cedula = dr.Item("CCliente")
            client.NombreC = dr.Item("Nombre")
            client.ApellidoC = dr.Item("Apellido")
            client.TelefonoC = dr.Item("Telefono")
            client.DireccionC = dr.Item("Direccion")
            Return client
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.Message)

        End Try
    End Function

    Public Function GuardarCliente(cl As Entidades.Cliente) As String
        Dim i As Integer = lc.insertarCliente(cl)
        If i = 1 Then
            Return "SE GUARDO CORRECTAMENTE " & cl.NombreC
        Else
            Return "CLIENTE YA EXISTE"
        End If

    End Function

    Public Function actualizarCliente(cl As Entidades.Cliente) As String
        If lc.actualizar(cl) Then
            Return "ACTUALIZADO CORRECTAMENTE"
        Else
            Return "ERROR AL ACTUALIZAR"
        End If
    End Function

    Public Function eliminarCliente(cc As String) As String
        If lc.eliminar(cc) Then
            Return "ELIMINADO CORRECTAMENTE"
        Else
            Return "ERROR AL ELIMINAR"
        End If

    End Function
End Class
