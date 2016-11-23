Imports System.Console
Module Module1
    Dim LC As New Logica.GestionMesa
    Dim ld As New Logica.GestionDetalle
    Dim n As Entidades.Mesa
    Sub Main()
        'Dim nm As Integer
        'WriteLine("INGRESE NUMERO MESA")
        'nm = CInt(ReadLine())
        'ld.cantidadProducto(1)
        'For Each inter As Integer In ld.listacodigos
        '    MsgBox("Aqui esta" & inter)
        'Next


        'WriteLine(LC.guardar(n))
        'WriteLine(LC.buscar(nm).MesaN & LC.buscar(nm).EstadoM)

        'Dim ca As New Entidades.Pedido
        'Dim pr As New Logica.GestionProducto

        'Dim cod As String
        'Dim cl As New Entidades.Cliente
        'Dim id As Integer
        'WriteLine("INGRESE ID  Usuario:")
        'ca.Cedula = ReadLine()
        'WriteLine("INGRESE CODIGO Pedido:")
        'ca.IDPedidoP = ReadLine()
        'WriteLine("INGRESE CODIGO CLIENTE:")
        'ca.Cliente = ReadLine()

        'WriteLine("INGRESE IdProducto")
        'ca.IDProductoP = ReadLine()
        'ca.PrecioUnit = LC.buscar(ca.IDPedidoP).PrecioUnit
        'WriteLine("INGRESE CANTIDAD")
        'ca.cantidadPr = ReadLine()

        'ca.TotalPedido()

        'WriteLine("INGRESE CODIGO PRODUCTO")
        'ca.iProducto = ReadLine()
        'WriteLine("INGRESE DIR")
        'ca.DireccionU = ReadLine()
        'WriteLine(LC.actualizarPedido(ca))

        'WriteLine(lcat.buscar(id).NombreCategoria)


        'Rutina para recorrer los pedidos y ver su mesa y se llama a actualizar mesa, 0=HAY PEDIDO  1 ESTA LIBRE
        'Try
        '    Dim row As DataRow
        '    For Each r As DataRow In lp.listado.Rows
        '        row = r
        '        WriteLine(row.Item(0))
        '        'WriteLine(lp.buscar(row.Item(0)).NumeroMesa)
        '        ' WriteLine(LC.actualizarMesas(lp.buscar(row.Item(0))))
        '    Next
        'Catch ex As Exception
        '    WriteLine(ex.Message)
        'End Try



        ReadKey()
    End Sub

End Module
