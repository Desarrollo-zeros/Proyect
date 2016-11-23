Imports System.Data.SqlClient
Imports System.IO
Public Class BdDetalle
    Inherits Conexion

    Dim cmd As SqlCommand

    Public Function insertarDetalle(p As Entidades.Pedido, v As Entidades.Venta) As Integer


        Try
            conectarse()
            cmd = New SqlCommand("INSERT INTO Detalle VALUES(" & v.IdVenta_r & "," & p.IDProductoP & "," & p.cantidadPr & "," & p.PrecioUnit & "," & p.TotalPedido & ")", CONEXION)
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
            Dim da As New SqlDataAdapter("SELECT  Detalle.IdDetalleVenta, Detalle.IdVenta, Detalle.IdProducto, ProdcuctoR.Nombre, Detalle.Cantidad, Detalle.PrecioUnitario, Detalle.Importe FROM Detalle INNER JOIN ProdcuctoR ON  Detalle.IdProducto= ProdcuctoR.IdProducto", CONEXION)
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

            cmd = New SqlCommand("DELETE FROM Detalle WHERE IdDetalleVenta=" & id, CONEXION)
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

    Public Function actualizar(cl As Entidades.Detalle) As Boolean
        Try
            Dim sql As String
            conectarse()
            sql = String.Format("UPDATE [Detalle] SET [IdProducto]={0},[Cantidad]={1} WHERE [IdDetalleVenta]={2};", cl.IdProductoV, cl.CantidadP, cl.IdVentaV)
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
    Dim ln, lcod As New List(Of Integer)
    Public Function Cantidad_Producto() As List(Of Integer)
        Dim lec As SqlDataReader
        Dim sql As String
        Try

            Dim cant, cod As Integer
            conectarse()
            sql = String.Format("select top 10 Detalle.IdProducto, sum(Detalle.Cantidad) as total from Detalle group by Detalle.IdProducto order by total desc")
            cmd = New SqlCommand(sql, CONEXION)
            lec = cmd.ExecuteReader

            If lec.HasRows Then
                While lec.Read
                    cant = lec.Item("total")
                    cod = lec.Item("IdProducto")
                    lcod.Add(cod)
                    ln.Add(cant)
                End While
                Me.listadeCodigos(lcod)
                lec.Close()
            End If
            Return ln
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectarse()
        End Try


    End Function

    Public Function listadeCodigos(lp As List(Of Integer)) As List(Of Integer)
        Return lcod
    End Function
    Public Function listacod() As List(Of Integer)
        Return lcod
    End Function
End Class
