Imports System.Data.SqlClient
Public Class GestionVenta
    Dim lc As New Datos.BdVenta

    Public Function listado() As DataTable
        Dim dt As New DataTable
        dt = lc.consulta
        Return dt
    End Function

    Public Function buscar(id As Integer) As Entidades.Venta
        Try
            Dim dr As DataRow
            Dim filtro As String
            Dim vent As New Entidades.Venta
            filtro = String.Format("[IdVenta]={0}", id)
            dr = listado().Select(filtro)(0)
            vent.IdVenta_r = dr.Item("IdVenta")
            vent.Cliente = dr.Item("IdCliente")
            vent.fechaVenta = dr.Item("FechaVenta")
            vent.Numero_Mesa = dr.Item("Nmesa")
            vent.Usuario = dr.Item("Usuario")

            Return vent
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function GuardarVenta(v As Entidades.Venta) As String
        Dim i As Integer = lc.insertarVenta(v)
        If i = 1 Then
            Return "SE GUARDO CORRECTAMENTE "
        Else
            Return "NO SE PUDO GUARDAR"
        End If

    End Function

    Public Function actualizarVenta(cl As Entidades.Venta) As String
        If lc.actualizar(cl) Then
            Return "ACTUALIZADO CORRECTAMENTE"
        Else
            Return "ERROR AL ACTUALIZAR"
        End If
    End Function

    Public Function eliminarVenta(cc As String) As String
        If lc.eliminar(cc) Then
            Return "ELIMINADO CORRECTAMENTE"
        Else
            Return "ERROR AL ELIMINAR"
        End If

    End Function

    Public Function TotalregVenta() As Integer
        Return listado.Rows.Count
    End Function

    Public Function Reporte(idVenta As Integer) As String


        If lc.generarReporte(idVenta) = True Then
            Return "GENERADO EXITOSAMENTE"
        Else
            Return "ERROR AL GENERAR FACTUTRA"
        End If
    End Function

    Public Function tablaReporte(id As Integer) As DataSet
        Return lc.tablaDetalleR(id)
    End Function


End Class
