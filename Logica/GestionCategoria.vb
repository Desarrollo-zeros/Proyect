Public Class GestionCategoria
    Dim lcat As New Datos.BdCategoria

    Public Function guardar(cat As Entidades.Categoria) As String
        Try
            If lcat.insertarCategoria(cat) = 1 Then
                Return "SE GUARDO CORRECTAMENTE LA CATEGORIA " & cat.NombreCategoria
            Else
                Return "NO SE GUARDO" & cat.NombreCategoria
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return "ERROR AL GUARDAR"
        End Try
    End Function

    Public Function listado() As DataTable
        Try
            Dim dt As New DataTable
            dt = lcat.consulta
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function actualizarCategoria(ct As Entidades.Categoria) As String
        Try
            If lcat.actualizar(ct) Then
                Return "ACTUALIZADO CORRECTAMENTE " & ct.NombreCategoria
            Else
                Return "NO SE ACTUALIZO CORRECTAMENTE " & ct.NombreCategoria
            End If
        Catch ex As Exception
            Return "ERROR AL GUARDAR"
        End Try
    End Function

    Public Function buscar(id As Integer) As Entidades.Categoria
        Try
            Dim dr As DataRow
            Dim filtro As String
            Dim cat As New Entidades.Categoria
            filtro = String.Format("[IdCategoria]={0}", id)
            dr = listado.Select(filtro)(0)
            cat.ID = dr.Item("IdCategoria")
            cat.NombreCategoria = dr.Item("NombreCategoria")
            Return cat
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function eliminarCategoria(id As Integer) As String
        If lcat.eliminar(id) Then
            Return "ELIMINADO CORRECTAMENTE"
        Else
            Return "ERROR AL ELIMINAR"
        End If
    End Function
End Class
