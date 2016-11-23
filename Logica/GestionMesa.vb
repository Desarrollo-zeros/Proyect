Public Class GestionMesa
    Dim lm As New Datos.BdMesa


    Public Function guardar(m As Entidades.Mesa) As String
        Try
            If lm.insertarMesa(m) = 1 Then
                Return "SE GUARDO CORRECTAMENTE LA CATEGORIA " & m.MesaN
            Else
                Return "NO SE GUARDO" & m.MesaN
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return "ERROR AL GUARDAR"
        End Try
    End Function

    Public Function listado() As DataTable
        Try
            Dim dt As New DataTable
            dt = lm.consulta
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function actualizarDesocupada(NMESA As Integer) As Boolean
        Try
            lm.actualizarEstadoDes(buscar(NMESA))

            Return True
        Catch ex As Exception
            Return False
        End Try


    End Function
    Public Function actualizarMesas(nm As Integer) As Boolean
        Try
            

            lm.actualizarEstado(nm)
             
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function buscar(id As Integer) As Entidades.Mesa
        Try
            Dim dr As DataRow
            Dim filtro As String
            Dim m As New Entidades.Mesa()
            filtro = String.Format("Numero={0}", id)
            dr = listado.Select(filtro)(0)
            m.MesaN = dr.Item("Numero")
            m.EstadoM = dr.Item("Estado")
            Return m
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function eliminarMesa(id As Integer) As String
        If lm.eliminar(id) Then
            Return "ELIMINADO CORRECTAMENTE"
        Else
            Return "ERROR AL ELIMINAR"
        End If
    End Function

    

End Class
