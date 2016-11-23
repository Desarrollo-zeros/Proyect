Imports System.Data.SqlClient
Public Class BdMesa
    Inherits Conexion
    Dim sc As SqlCommand

    Public Function insertarMesa(m As Entidades.Mesa) As Integer
        Try
            conectarse()
            Dim sql As String
            sql = String.Format("INSERT INTO Mesa VALUES({0})", m.EstadoM)
            sc = New SqlCommand(sql, CONEXION)
            If sc.ExecuteNonQuery Then
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
    End Function

    Public Function consulta() As DataTable
        Try
            conectarse()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter("SELECT Mesa.Numero, Mesa.Estado, Estado_Mesa.Estado_Mesa FROM Mesa INNER JOIN Estado_Mesa ON Mesa.Estado= Estado_Mesa.Numero", CONEXION)
            da.Fill(ds)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.Message)
        Finally
            desconectarse()
        End Try
    End Function

    Public Function eliminar(n As Integer) As Boolean
        Try
            conectarse()

            sc = New SqlCommand("DELETE FROM Mesa WHERE Nmesa=" & n, CONEXION)
            If sc.ExecuteNonQuery Then
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

    Public Function actualizarEstado(nm As Integer) As Boolean
        Try
            Dim sql As String
            conectarse()

            sql = String.Format("UPDATE [Mesa] SET [Estado]={0} WHERE [Numero]={1};", 0, nm)
            sc = New SqlCommand(sql, CONEXION)
            If sc.ExecuteNonQuery Then
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

    Public Function actualizarEstadoDes(m As Entidades.Mesa) As Boolean
        Try
            Dim sql As String
            conectarse()

            sql = String.Format("UPDATE [Mesa] SET [Estado]={0} WHERE [Numero]={1} ;", 1, m.MesaN)
            sc = New SqlCommand(sql, CONEXION)
            If sc.ExecuteNonQuery Then
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

End Class
