Imports System.Data.SqlClient
Public Class BdProducto
    Inherits Conexion
    Dim cmd As SqlCommand

    Public Function insertarProducto(Pr As Entidades.Producto) As Integer


        Try
            conectarse()
            cmd = New SqlCommand
            cmd.Connection = CONEXION
            cmd.CommandText = "INSERT INTO ProdcuctoR VALUES(@Categoria,@Nombre,@Descripcion,@Precio,@Imagen)"
            cmd.Parameters.Add("@Categoria", SqlDbType.Int)
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar)
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar)
            cmd.Parameters.Add("@Precio", SqlDbType.Decimal)
            cmd.Parameters.Add("@Imagen", SqlDbType.Image)
            cmd.Parameters("@Categoria").Value = CInt(Pr.icategoria)
            cmd.Parameters("@Nombre").Value = CStr(Pr.NombreProducto)
            cmd.Parameters("@Descripcion").Value = CStr(Pr.DescripcionProducto)
            cmd.Parameters("@Precio").Value = CDec(Pr.PrecioProducto)
            cmd.Parameters("@Imagen").Value = Pr.ImagenProducto

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
            Dim da As New SqlDataAdapter("SELECT ProdcuctoR.IdProducto, ProdcuctoR.Categoria , Categoria.NombreCategoria ,ProdcuctoR.Nombre, ProdcuctoR.Descripcion, ProdcuctoR.Precio, ProdcuctoR.Imagen FROM ProdcuctoR INNER JOIN Categoria ON ProdcuctoR.Categoria=IdCategoria ORDER BY ProdcuctoR.IdProducto", CONEXION)
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

            cmd = New SqlCommand("DELETE FROM ProdcuctoR WHERE IdProducto= " & id, CONEXION)
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

    Public Function actualizar(Pr As Entidades.Producto) As Boolean
        Try

            conectarse()
            cmd = New SqlCommand
            cmd.Connection = CONEXION
            cmd.CommandText = "UPDATE ProdcuctoR SET [Categoria]=@Categoria,[Nombre]=@Nombre,[Descripcion]=@Descripcion, [Precio]=@Precio,[Imagen]=@Imagen WHERE IdProducto=" & Pr.iProducto & ";"
            cmd.Parameters.Add("@Categoria", SqlDbType.Int)
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar)
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar)
            cmd.Parameters.Add("@Precio", SqlDbType.Decimal)
            cmd.Parameters.Add("@Imagen", SqlDbType.Image)
            cmd.Parameters("@Categoria").Value = CInt(Pr.icategoria)
            cmd.Parameters("@Nombre").Value = CStr(Pr.NombreProducto)
            cmd.Parameters("@Descripcion").Value = CStr(Pr.DescripcionProducto)
            cmd.Parameters("@Precio").Value = CDec(Pr.PrecioProducto)
            cmd.Parameters("@Imagen").Value = Pr.ImagenProducto
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
