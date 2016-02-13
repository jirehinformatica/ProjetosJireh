Public Class DebitoAutomatico

    Private Sub DebitoAutomatico_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Me.WindowState = FormWindowState.Maximized
        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub tsbPessoas_Click(sender As Object, e As EventArgs) Handles tsbPessoas.Click
        Try
            Dim F As New CadastroPessoas
            F.ShowDialog()
            F.Dispose()
        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

End Class