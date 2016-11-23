Public Class FrmFacturaP
    Public idVenta As String
    Private Sub FrmFacturaP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objReporte = New FacturaU
        objReporte.SetParameterValue("@IDVENTA", idVenta)
        VisorReporte.ReportSource = objReporte
    End Sub
End Class