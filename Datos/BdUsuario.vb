Imports System.Data.SqlClient
Public Class BdUsuario
    Inherits Conexion
    Dim cmd As SqlCommand

    Public Function insertarUsuario(usuario As Entidades.Usuario) As Integer

        If Me.validarUsuario(usuario.Cedula) Then
            Try
                conectarse()
                cmd = New SqlCommand("INSERT INTO Usuario VALUES('" & usuario.Cedula & "','" & usuario.NombreU & "','" & usuario.ApellidoU & "','" & usuario.UserNameU & "','" & usuario.LoginU & "','" & usuario.TelefonoU & "','" & usuario.DireccionU & "'," & usuario.TipoUser & ")", CONEXION)
                If cmd.ExecuteNonQuery Then
                    Return 1
                Else
                    Return 0
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Return 0
            Finally
                desconectarse()
            End Try
        Else
            Return 0
        End If
    End Function

    Public Function consulta() As DataTable
        Try
            conectarse()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter("SELECT Usuario.IdUsuario, Usuario.Nombre,Usuario.Apellido,Usuario.UserName,Usuario.login,Usuario.Telefono,Usuario.Direccion,TipoUsuario.Tipo_Usuario FROM Usuario INNER JOIN TipoUsuario ON Usuario.Tipo_Usuario=TipoUsuario.Numero", CONEXION)
            da.Fill(ds)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.Message)
        Finally
            desconectarse()
        End Try
    End Function

    Public Function eliminar(cc As String) As Boolean
        Try
            conectarse()

            cmd = New SqlCommand("DELETE FROM Usuario WHERE IdUsuario='" & cc & "'", CONEXION)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectarse()
        End Try



    End Function

    Public Function actualizar(cl As Entidades.Usuario) As Boolean
        Try
            Dim sql As String
            conectarse()
            sql = String.Format("UPDATE [Usuario] SET [Nombre]='{0}',[Apellido]='{1}',[UserName]='{2}',[login]='{3}',[Telefono]='{4}',[Direccion]='{5}' WHERE [IdUsuario]='{6}';", cl.NombreU, cl.ApellidoU, cl.UserNameU, cl.LoginU, cl.TelefonoU, cl.DireccionU, cl.Cedula)
            cmd = New SqlCommand(sql, CONEXION)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False

            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectarse()
        End Try

    End Function

    Public Function validarUsuario(ced As String) As Boolean
        Try
            conectarse()

            Dim dr As SqlDataReader
            Dim consult As String
            consult = String.Format("SELECT * FROM Usuario WHERE [IdUsuario]='{0}'", ced)
            cmd = New SqlCommand(consult, CONEXION)
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        Finally
            desconectarse()
        End Try

    End Function

    Public Function listadeTipos() As DataTable

        Try
            Dim ds As New DataSet
            conectarse()
            Dim sa As New SqlDataAdapter("SELECT * FROM TipoUsuario", CONEXION)
            sa.Fill(ds)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectarse()
        End Try
    End Function
End Class
