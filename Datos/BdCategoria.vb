Imports System.Data.SqlClient
Public Class BdCategoria
    Inherits Conexion
    Dim cmd As SqlCommand

    Public Function insertarCategoria(Categoria As Entidades.Categoria) As Integer
        Try
            conectarse()
            cmd = New SqlCommand("INSERT INTO Categoria VALUES('" & Categoria.NombreCategoria & "')", CONEXION)
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
    End Function

    Public Function consulta() As DataTable
        Try
            conectarse()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter("SELECT * FROM Categoria", CONEXION)
            da.Fill(ds)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.Message)
        Finally
            desconectarse()
        End Try
    End Function

    Public Function eliminar(id As Integer) As Boolean
        Try
            conectarse()

            cmd = New SqlCommand("DELETE FROM Categoria WHERE IdCategoria=" & id, CONEXION)
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

    Public Function actualizar(ct As Entidades.Categoria) As Boolean
        Try
            Dim sql As String
            conectarse()
            sql = String.Format("UPDATE [Categoria] SET [NombreCategoria]='{0}' WHERE [IdCategoria]='{1}';", ct.NombreCategoria, ct.ID)
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

    
End Class
