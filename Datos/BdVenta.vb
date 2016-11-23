Imports System.Data.SqlClient
Public Class BdVenta
    Inherits Conexion
    Dim cmd As SqlCommand
    Dim reporte As New DataSet

    Public Function insertarVenta(v As Entidades.Venta) As Integer


        Try
            conectarse()
            cmd = New SqlCommand("INSERT INTO VentaR VALUES(" & v.IdVenta_r & ",'" & v.Cliente & "','" & v.fechaVenta & "'," & v.Numero_Mesa & "," & v.total & ",'" & v.Usuario & "')", CONEXION)
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
            Dim da As New SqlDataAdapter("SELECT VentaR.IdVenta, VentaR.IdCliente, Clientes.Nombre, Clientes.Apellido, VentaR.FechaVenta, VentaR.Nmesa, VentaR.TotalVenta, VentaR.Usuario FROM VentaR INNER JOIN Clientes ON VentaR.IdCliente= Clientes.CCliente", CONEXION)
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

            cmd = New SqlCommand("DELETE FROM VentaR WHERE IdVenta=" & id, CONEXION)
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

    Public Function actualizar(v As Entidades.Venta) As Boolean
        Try
            Dim sql As String
            conectarse()
            sql = String.Format("UPDATE [VentaR] SET [IdCliente]='{0}',[FechaVenta]='{1}',[Nmesa]={2} WHERE [IdVenta]={3};", v.Cliente, v.fechaVenta.ToShortDateString, v.Numero_Mesa, v.IdVenta_r)
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
    Dim ds As New DataSet
    Public Function generarReporte(idVenta As Integer) As Boolean
        Try
            Dim sql As String

            sql = String.Format("SELECT *  FROM dbo.VentaR a INNER JOIN dbo.Clientes b ON a.IdCliente = b.CCliente WHERE IdVenta= " & idVenta & ";" & "SELECT * FROM Detalle a INNER JOIN ProdcuctoR b ON a.IdProducto=b.IdProducto WHERE a.IdVenta=" & idVenta & ";")
            If buscarRegistro(sql) = True Then
                If ds.Tables("VentaR").Rows.Count = 0 Then
                    MsgBox("NO SE HA ENCONTRADO NINGUN REGISTRO")
                Else
                    MsgBox("GENERADO OK!", MsgBoxStyle.Information, "OK")
                    My.Computer.FileSystem.CreateDirectory("C:\XML")
                    Dim url As String = "C:\XML\Ventas.xml"
                    ds.WriteXml(url, XmlWriteMode.WriteSchema)

                End If

            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Function buscarRegistro(consulta As String) As Boolean
        Try
            Dim da As SqlDataAdapter

            conectarse()
            da = New SqlDataAdapter(consulta, CONEXION)
            da.TableMappings.Add("VentaR1", "Detalle")
            da.Fill(ds, "VentaR")
            desconectarse()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        
    End Function

   

    Function tablaDetalleR(idventa As Integer) As DataSet
        Try
            Dim da, da1 As SqlDataAdapter
            Dim sql, sql1 As String
            conectarse()
            sql = String.Format("SELECT *  FROM dbo.VentaR a INNER JOIN dbo.Clientes b ON a.IdCliente = b.CCliente WHERE IdVenta=" & idventa & ";")
            da = New SqlDataAdapter(sql, CONEXION)
            da.Fill(reporte, "VentaR")
            sql1 = String.Format("SELECT * FROM Detalle a INNER JOIN ProdcuctoR b ON a.IdProducto=b.IdProducto WHERE a.IdVenta=" & idventa & ";")
            da1 = New SqlDataAdapter(sql, CONEXION)
            da1.Fill(reporte, "Detalle")

            MsgBox("Se ejecuto")
            Return reporte
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectarse()

        End Try

    End Function

    


End Class
