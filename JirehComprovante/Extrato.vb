Public Class Extrato

    Protected WithEvents Eventos As JirehLayouts.JirehLayoutEventos
    Private Empresa As Dictionary(Of String, String)
    Private Conta As Dictionary(Of String, String)


    Private Sub tsbAbrir_Click(sender As Object, e As EventArgs) Handles tsbAbrir.Click
        Try
            opArquivo.Title = "Abrir o arquivo de extrato do banco."
            opArquivo.Filter = "Arquivo extrato|*.ret;Arquivo extrato|*.txt"
            opArquivo.Multiselect = False

            Dim resp As DialogResult = opArquivo.ShowDialog

            If resp = Windows.Forms.DialogResult.OK OrElse resp = Windows.Forms.DialogResult.Yes Then

                FormularioMDI.SetProgresso(True)

                Eventos = New JirehLayouts.JirehLayoutEventos
                Dim LerArquivo As New JirehLayouts.ExtratoCNAB240(opArquivo.FileName, Eventos)

                If Not LerArquivo.ArquivoValido(JirehBDUtil.InfoRegistro.InformacoesServidor.GetConveniosString) AndAlso CanceladoPorUsuario Then
                    Exit Sub
                End If

                Empresa = New Dictionary(Of String, String)
                Conta = New Dictionary(Of String, String)


            End If

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub Eventos_Mensagem(sender As Object, e As JirehLayouts.LayoutPendenciaEventArgs) Handles Eventos.Mensagem
        Try
            Alerta(e.Mensagem)
        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub Eventos_Progresso(sender As Object, ByRef e As JirehLayouts.LayoutEventosEventArgs) Handles Eventos.Progresso
        Try
            FormularioMDI.SetProgresso(e.Progresso, e.MaximoValor)
            FormularioMDI.SetPrompt(e.Mensagem, e.Progresso)
            e.Cancelar = CanceladoPorUsuario
        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

End Class