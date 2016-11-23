Imports System.Data.SqlClient
Public Class Conexion
    Private ruta As String
    Private con As SqlConnection

    Sub New()
        ruta = "Data Source=.\ZEROS;Initial Catalog=VentaRestaurante;Integrated Security=True"
        con = New SqlConnection(ruta)
    End Sub

    Public ReadOnly Property CONEXION As SqlConnection
        Get
            Return con
        End Get
    End Property
    Public Function conectarse() As Boolean
        Try
            con.Open()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function desconectarse() As Boolean
        Try
            If con.State = ConnectionState.Open Then
                con.Close()
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
End Class
