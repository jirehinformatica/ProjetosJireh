Public Class DebitoAutomatico

    Private Sub tsbPessoas_Click(sender As Object, e As EventArgs) Handles tsbPessoas.Click
        Try

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

End Class