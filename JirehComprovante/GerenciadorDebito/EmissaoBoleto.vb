Public Class EmissaoBoleto

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bol As New BoletoNet.BoletoBancario
        Dim oo As New BoletoNet.Boletos

        Dim texto As String = bol.MontaHtml()


    End Sub
End Class