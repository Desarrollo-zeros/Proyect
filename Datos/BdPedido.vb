Imports System.Data.SqlClient
Public Class BdPedido
    Inherits Conexion
    Dim cmd As SqlCommand

    Public Function insertarPedido(p As Entidades.Pedido) As Integer

        Try
            conectarse()
            cmd = New SqlCommand("INSERT INTO Pedido VALUES(" & p.IDProductoP & "," & p.cantidadPr & "," & p.PrecioUnit & "," & p.NumeroMesa & "," & p.TotalPedido & ")", CONEXION)
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
            Dim da As New SqlDataAdapter("SELECT Pedido.IdPedido, Pedido.IdProducto, ProdcuctoR.Nombre,Pedido.PrecioUnitario, Pedido.Cantidad,Pedido.Nmesa, Pedido.Importe FROM Pedido INNER JOIN ProdcuctoR ON Pedido.IdProducto= ProdcuctoR.IdProducto ", CONEXION)
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

            cmd = New SqlCommand("DELETE FROM Pedido WHERE IdPedido=" & id, CONEXION)
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

    Public Function actualizar(p As Entidades.Pedido) As Boolean
        Try
            Dim sql As String
            conectarse()
            sql = String.Format("UPDATE [Pedido] SET [IdProducto]={0},[Cantidad]={1},[Importe]={2} WHERE [IdPedido]={3};", p.IDProductoP, p.cantidadPr, p.TotalPedido, p.IDPedidoP)
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
