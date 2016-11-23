Public Class GestionUsuario
    Dim lu As New Datos.BdUsuario

    Public Function listado() As DataTable
        Dim dt As New DataTable
        dt = lu.consulta
        Return dt
    End Function

    Public Function buscar(ced As String) As Entidades.Usuario
        Try
            Dim dr As DataRow
            Dim filtro As String
            Dim usu As New Entidades.Usuario
            filtro = String.Format("[IdUsuario]='{0}'", ced)
            dr = listado().Select(filtro)(0)
            usu.Cedula = dr.Item("IdUsuario")
            usu.NombreU = dr.Item("Nombre")
            usu.ApellidoU = dr.Item("Apellido")
            usu.TelefonoU = dr.Item("Telefono")
            usu.UserNameU = dr.Item("UserName")
            usu.LoginU = dr.Item("login")
            usu.DireccionU = dr.Item("Direccion")
            usu.Tipo = dr.Item("Tipo_Usuario")

            Return usu
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function buscarPorNombre(nom As String) As Entidades.Usuario
        Try
            Dim dr As DataRow
            Dim filtro As String
            Dim usu As New Entidades.Usuario
            filtro = String.Format("[Nombre]='{0}'", nom)
            dr = listado().Select(filtro)(0)
            usu.Cedula = dr.Item("IdUsuario")
            usu.NombreU = dr.Item("Nombre")
            usu.ApellidoU = dr.Item("Apellido")
            usu.TelefonoU = dr.Item("Telefono")
            usu.UserNameU = dr.Item("UserName")
            usu.LoginU = dr.Item("login")
            usu.DireccionU = dr.Item("Direccion")
            usu.Tipo = dr.Item("Tipo_Usuario")

            Return usu
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function buscarPorUser(u As String) As Entidades.Usuario
        Try
            Dim dr As DataRow
            Dim filtro As String
            Dim usu As New Entidades.Usuario
            filtro = String.Format("[UserName]='{0}'", u)
            dr = listado().Select(filtro)(0)
            usu.Cedula = dr.Item("IdUsuario")
            usu.NombreU = dr.Item("Nombre")
            usu.ApellidoU = dr.Item("Apellido")
            usu.TelefonoU = dr.Item("Telefono")
            usu.UserNameU = dr.Item("UserName")
            usu.LoginU = dr.Item("login")
            usu.DireccionU = dr.Item("Direccion")
            usu.Tipo = dr.Item("Tipo_Usuario")
            Return usu
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function GuardarUsuario(us As Entidades.Usuario) As String
        Dim i As Integer = lu.insertarUsuario(us)
        If i = 1 Then
            Return "SE GUARDO CORRECTAMENTE " & us.NombreU
        Else
            Return "USUARIO YA REGISTRADO"
        End If

    End Function

    Public Function actualizarUsuario(u As Entidades.Usuario) As String
        If lu.actualizar(u) Then
            Return "ACTUALIZADO CORRECTAMENTE"
        Else
            Return "ERROR AL ACTUALIZAR"
        End If
    End Function

    Public Function eliminarUsuario(cc As String) As String
        If lu.eliminar(cc) Then
            Return "ELIMINADO CORRECTAMENTE"
        Else
            Return "ERROR AL ELIMINAR"
        End If

    End Function
    Public Function listaTipos() As DataTable
        Dim dt As New DataTable
        dt = lu.listadeTipos
        Return dt
    End Function
    
End Class
