Imports System.Data.SqlClient

Public Class BdCliente
    Inherits Conexion
    Dim cmd As SqlCommand

    Public Function insertarCliente(cliente As Entidades.Cliente) As Integer

        If Me.validarCliente(cliente.cedula) Then
            Try
                conectarse()
                cmd = New SqlCommand("INSERT INTO Clientes VALUES('" & cliente.cedula & "','" & cliente.NombreC & "','" & cliente.ApellidoC & "','" & cliente.TelefonoC & "','" & cliente.DireccionC & "')", CONEXION)
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
            Dim da As New SqlDataAdapter("SELECT * FROM Clientes", CONEXION)
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

            cmd = New SqlCommand("DELETE FROM Clientes WHERE CCliente='" & cc & "'", CONEXION)
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

    Public Function actualizar(cl As Entidades.Cliente) As Boolean
        Try
            Dim sql As String
            conectarse()
            sql = String.Format("UPDATE [Clientes] SET [Nombre]='{0}',[Apellido]='{1}',[Telefono]='{2}',[Direccion]='{3}' WHERE [CCliente]='{4}';", cl.NombreC, cl.ApellidoC, cl.TelefonoC, cl.DireccionC, cl.cedula)
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

    Public Function validarCliente(ced As String) As Boolean
        Try
            conectarse()

            Dim dr As SqlDataReader
            Dim consult As String
            consult = String.Format("SELECT * FROM Clientes WHERE [CCliente]='{0}'", ced)
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
End Class
