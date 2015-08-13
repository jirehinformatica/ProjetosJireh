Public Class Extrato

    Protected WithEvents Eventos As JirehLayouts.JirehLayoutEventos
    Private Extrato As List(Of JirehLayouts.ExtratoCNAB240.tpItemExtrato)
    Private Leitura As JirehLayouts.ExtratoCNAB240

#Region "PREENCHER A TELA"

    Private Sub PreencherDados(ByVal IdEmp As String, ByVal idCon As String, ByVal idSeq As String)
        Try
            Dim Query As JirehLayouts.ExtratoCNAB240.tpHeaderLote = (From i In Leitura.HeaderLote Where i.NomeEmpresa = IdEmp AndAlso i.AgenciaEContaCompleto = idCon AndAlso i.NumeroSeqExtrato = idSeq).FirstOrDefault

            If Query Is Nothing OrElse String.IsNullOrEmpty(Query.NumeroInscricao) Then
                LimparDados()
                Exit Sub
            End If

            txtDataInicio.Text = Query.DataSaldoInicio.ToString("dd/MM/yyyy")
            txtDataFinal.Text = Query.TrailerLote.DataSaldoFinal.ToString("dd/MM/yyyy")
            txtSaldoInicio.Text = Query.ValorSaldoInicio.ToString("N")
            txtSaldoFinal.Text = Query.TrailerLote.ValorSaldoFinal.ToString("N")
            txtPosicaoInicio.Text = Query.StatusPF
            txtPosicaoFinal.Text = Query.TrailerLote.StatusPF
            txtStatus.Text = Query.TrailerLote.SituacaoDC
            txtSadoBloqueado.Text = Query.TrailerLote.SaldoBloqueado.ToString("N")
            txtCreditos.Text = Query.TrailerLote.TotalCredito.ToString("N")
            txtDebitos.Text = Query.TrailerLote.TotalDebito.ToString("N")
            txtLimite.Text = Query.TrailerLote.LimiteConta.ToString("N")

            dgvExtrato.DataSource = Query.SegmentoE

            Extrato = Query.SegmentoE

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub LimparDados()
        Try
            txtDataInicio.Text = String.Empty
            txtDataFinal.Text = String.Empty
            txtSaldoInicio.Text = String.Empty
            txtSaldoFinal.Text = String.Empty
            txtPosicaoInicio.Text = String.Empty
            txtPosicaoFinal.Text = String.Empty
            txtStatus.Text = String.Empty
            txtSadoBloqueado.Text = String.Empty
            txtCreditos.Text = String.Empty
            txtDebitos.Text = String.Empty
            txtLimite.Text = String.Empty

            Extrato = New List(Of JirehLayouts.ExtratoCNAB240.tpItemExtrato)

        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region

#Region "CARREGAR ITENS DA TELA"

    Private Sub CarregarEmpresas()
        Try
            cboEmpresas.Items.Clear()

            Dim Query = (From i In Leitura.HeaderLote.AsEnumerable Select New With { _
                        Key .Nome = i.NomeEmpresa
                        }).ToList.Distinct

            For Each i In Query
                cboEmpresas.Items.Add(i.Nome)
            Next

            If cboEmpresas.Items.Count = 1 Then
                cboEmpresas.SelectedIndex = 0
            Else
                cboEmpresas.SelectedIndex = -1
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub CarregarConta(ByVal idEmpresa As String)
        Try
            cboConta.Items.Clear()
            If cboEmpresas.Items.Count = 0 OrElse String.IsNullOrEmpty(idEmpresa) Then
                Exit Sub
            End If

            Dim Query = (From i In Leitura.HeaderLote.AsEnumerable Where i.NomeEmpresa = idEmpresa Select New With { _
                        Key .id = i.NumeroInscricao,
                        Key .Nome = i.AgenciaEContaCompleto
                        }).ToList.Distinct

            For Each i In Query
                cboConta.Items.Add(i.Nome)
            Next

            If cboConta.Items.Count = 1 Then
                cboConta.SelectedIndex = 0
            Else
                cboConta.SelectedIndex = -1
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub CarregarSequencia(ByVal idEmpresa As String, ByVal idConta As String)
        Try
            cboSequencia.Items.Clear()
            If cboConta.Items.Count = 0 OrElse String.IsNullOrEmpty(idConta) Then
                Exit Sub
            End If

            Dim Query = (From i In Leitura.HeaderLote.AsEnumerable Where i.NomeEmpresa = idEmpresa AndAlso i.AgenciaEContaCompleto = idConta Select New With {
                    Key .Id = i.NumeroSeqExtrato
                    }).ToList.Distinct

            For Each i In Query
                cboSequencia.Items.Add(i.Id)
            Next

            If cboSequencia.Items.Count = 1 Then
                cboSequencia.SelectedIndex = 0
            Else
                cboSequencia.SelectedIndex = -1
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region

    Private Sub tsbAbrir_Click(sender As Object, e As EventArgs) Handles tsbAbrir.Click
        Try
            opArquivo.Title = "Abrir o arquivo de extrato do banco."
            opArquivo.Filter = "Arquivo extrato|*.ret;*.txt"
            opArquivo.Multiselect = False

            Dim resp As DialogResult = opArquivo.ShowDialog

            If resp = Windows.Forms.DialogResult.OK OrElse resp = Windows.Forms.DialogResult.Yes Then

                FormularioMDI.SetProgresso(True)

                Eventos = New JirehLayouts.JirehLayoutEventos
                Leitura = New JirehLayouts.ExtratoCNAB240(opArquivo.FileName, Eventos)

                If Not Leitura.ArquivoValido(JirehBDUtil.InfoRegistro.InformacoesServidor.GetConveniosString) OrElse CanceladoPorUsuario Then
                    Leitura = Nothing
                    Exit Sub
                End If

                CarregarEmpresas()
                CarregarConta(cboEmpresas.Text)
                CarregarSequencia(cboEmpresas.Text, cboConta.Text)
                If Not String.IsNullOrEmpty(cboEmpresas.Text) AndAlso Not String.IsNullOrEmpty(cboConta.Text) AndAlso Not String.IsNullOrEmpty(cboSequencia.Text) Then
                    PreencherDados(cboEmpresas.Text, cboConta.Text, cboSequencia.Text)
                Else
                    LimparDados()
                End If

            End If

            FormularioMDI.SetProgresso(0, , True)

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
        Try
            If Extrato Is Nothing OrElse Extrato.Count = 0 Then
                Alerta("Não existe nenhum lançamento para o extrato informado.")
                Exit Sub
            End If



        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Try
            Extrato = New List(Of JirehLayouts.ExtratoCNAB240.tpItemExtrato)
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

    Private Sub cboEmpresas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEmpresas.SelectedIndexChanged
        Try
            CarregarConta(cboEmpresas.Text)
            CarregarSequencia(cboEmpresas.Text, cboConta.Text)
            If Not String.IsNullOrEmpty(cboEmpresas.Text) AndAlso Not String.IsNullOrEmpty(cboConta.Text) AndAlso Not String.IsNullOrEmpty(cboSequencia.Text) Then
                PreencherDados(cboEmpresas.Text, cboConta.Text, cboSequencia.Text)
            Else
                LimparDados()
            End If
        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub cboConta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboConta.SelectedIndexChanged
        Try
            CarregarSequencia(cboEmpresas.Text, cboConta.Text)
            If Not String.IsNullOrEmpty(cboEmpresas.Text) AndAlso Not String.IsNullOrEmpty(cboConta.Text) AndAlso Not String.IsNullOrEmpty(cboSequencia.Text) Then
                PreencherDados(cboEmpresas.Text, cboConta.Text, cboSequencia.Text)
            Else
                LimparDados()
            End If
        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub cboSequencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSequencia.SelectedIndexChanged
        Try
            If Not String.IsNullOrEmpty(cboEmpresas.Text) AndAlso Not String.IsNullOrEmpty(cboConta.Text) AndAlso Not String.IsNullOrEmpty(cboSequencia.Text) Then
                PreencherDados(cboEmpresas.Text, cboConta.Text, cboSequencia.Text)
            Else
                LimparDados()
            End If
        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

End Class