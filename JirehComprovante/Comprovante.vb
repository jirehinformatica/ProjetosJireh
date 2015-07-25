
Public Class Comprovante

    Private CriouColTodos As Boolean
    Protected WithEvents Eventos As JirehLayouts.JirehLayoutEventos
    Protected Lista As List(Of JirehReports.ComprovantePagamentoReport.ItemComprovantePagamento)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CriouColTodos = False

        Try
            Dim Rel As New JirehReports.ComprovantePagamentoReport
            If Not IO.File.Exists(PathAplicativo & Rel.NameLocalReport) Then
                Alerta("É necessário informar o arquivo do relatório para impressão. Isso será pedido somente desta vez.")
                Dim Selecionar As New JirehBDUtil.Arquivos
                Selecionar.AddSelecionarFiltros("Arquivo Reports", "rdlc")
                If Selecionar.SelecionarUmArquivo Then
                    Selecionar.Copiar(Selecionar.ArquivoSelecionadoPath, PathAplicativo & Rel.NameLocalReport)
                Else
                    Alerta("Não foi possível copiar o arquivo do report na pasta da aplicação. Esse processo deverá ser feito manualmente." & vbCrLf & "Copie o arquivo para essa pasta " & PathAplicativo)
                End If
            End If
        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub cbo_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If Lista Is Nothing Then
                Exit Sub
            End If
            Dim aux As Boolean = DirectCast(sender, CheckBox).Checked
            Threading.Tasks.Parallel.ForEach(Lista, Sub(i As JirehReports.ComprovantePagamentoReport.ItemComprovantePagamento)
                                                        If i.Ocorrencia.Substring(0, 2) = "00" Then
                                                            i.Valido = aux
                                                        End If
                                                    End Sub)
            dgvComprovantes.Refresh()
            Totalizar()
        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub Comprovante_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        FormCloseMDI(Me)
    End Sub

    Private Sub tsbAbrir_Click(sender As Object, e As EventArgs) Handles tsbAbrir.Click
        Try
            opArquivo.Title = "Abrir o arquivo de retorno do banco."
            opArquivo.Filter = "Arquivo retorno|*.ret"
            opArquivo.Multiselect = False

            Dim resp As DialogResult = opArquivo.ShowDialog

            If resp = Windows.Forms.DialogResult.OK OrElse resp = Windows.Forms.DialogResult.Yes Then

                FormularioMDI.SetProgresso(True)

                Eventos = New JirehLayouts.JirehLayoutEventos
                Dim LerArquivo As New JirehLayouts.RetornoSIACC240(opArquivo.FileName, Eventos)

                If LerArquivo.ArquivoValido(JirehBDUtil.InfoRegistro.InformacoesServidor.GetConveniosString) AndAlso Not CanceladoPorUsuario Then

                    'para evitar erros de threas na consulta abaixo chama essa linha nesse ponto aqui
                    JirehLayouts.NomeBanco("104")

                    FormularioMDI.SetProgresso(50, 100)
                    FormularioMDI.SetPrompt("Carregando o grid com as informações do arquivo.")

                    Lista = (From i In LerArquivo.ItensArquivo.AsParallel Select New JirehReports.ComprovantePagamentoReport.ItemComprovantePagamento With { _
                                .AutenticacaoBancaria = i.AutenticacaoBancaria,
                                .Banco = JirehLayouts.NomeBanco(LerArquivo.HeaderLote.CodigoBancoArquivo),
                                .CNPJ = LerArquivo.HeaderLote.NumeroInscricao,
                                .ContaCredito = i.AgenciaEContaCompleto,
                                .ContaDebito = LerArquivo.HeaderLote.AgenciaEContaCompleto,
                                .CPF = i.NumeroInscricao,
                                .DataArquivo = LerArquivo.HeaderArquivo.DataHoraGeracao,
                                .Empresa = LerArquivo.HeaderLote.NomeEmpresa,
                                .Favorecido = i.NomeFavorecido,
                                .NSA = LerArquivo.HeaderArquivo.NSA,
                                .Ocorrencia = i.Ocorrencia.Mensagem01,
                                .TipoCompromisso = "",
                                .Valido = i.Ocorrencia.Sucesso,
                                .Valor = i.ValorPagamento,
                                .Vencimento = i.DataPagamento
                            }).ToList

                Else
                    FormularioMDI.SetProgresso(0, , True)
                    Exit Sub
                End If

                If Lista Is Nothing Then
                    Lista = New List(Of JirehReports.ComprovantePagamentoReport.ItemComprovantePagamento)
                End If

                dgvComprovantes.DataSource = Lista

                OrdenarColunas()
                Totalizar()

                If Not CriouColTodos Then
                    CriouColTodos = True

                    Dim cbo As New CheckBox
                    cbo.Size = New Size(14, 14)
                    'Dim rect As Rectangle = dgvComprovantes.GetCellDisplayRectangle( 1, -1, True)  ' dgvComprovantes.GetCellDisplayRectangle(-1, -1, True)
                    Dim aux As Rectangle = dgvComprovantes.Columns(1).HeaderCell.ContentBounds '"Imprimir"
                    Dim rect As New Rectangle(aux.X + Math.Round(aux.Width / 2, 0) + Math.Round(cbo.Width / 2, 0) + 2, aux.Y + 1, aux.Width, aux.Height)  ' + Math.Round(cbo.Width / 2, 0)
                    cbo.Location = rect.Location
                    AddHandler cbo.CheckedChanged, AddressOf cbo_CheckedChanged
                    dgvComprovantes.Controls.Add(cbo)

                End If

            End If

            FormularioMDI.SetProgresso(0, , True)

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub OrdenarColunas()
        Try
            Dim i As Integer = 6
            For Each col As DataGridViewColumn In dgvComprovantes.Columns

                Select Case col.Name
                    Case "Imprimir"
                        col.DisplayIndex = 0
                    Case "Favorecido"
                        col.DisplayIndex = 1
                    Case "CPF"
                        col.DisplayIndex = 2
                    Case "Pagamento"
                        col.DisplayIndex = 3
                    Case "Valor"
                        col.DisplayIndex = 4
                    Case "Ocorrencia"
                        col.DisplayIndex = 5
                    Case Else
                        col.DisplayIndex = i
                        i += 1
                        'Imprimir
                        'Favorecido
                        'CPF
                        'Pagamento
                        'Valor
                        'Ocorrencia
                End Select

            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
        Try
            If dgvComprovantes.IsCurrentCellInEditMode Then
                dgvComprovantes.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
            Dim Rel As New JirehReports.ComprovantePagamentoReport
            If Lista Is Nothing Then
                Lista = New List(Of JirehReports.ComprovantePagamentoReport.ItemComprovantePagamento)
            End If
            Relatorio.Visualizar(Rel, (From i In Lista.AsParallel Where i.Valido).ToList)
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

    Private Sub Totalizar()
        Try
            If Lista Is Nothing Then
                lblSubRelatorio.Text = "Quantidade: 0000   -   Valor Total: R$ 0.00"
                Exit Sub
            End If
            Dim Total As List(Of JirehReports.ComprovantePagamentoReport.ItemComprovantePagamento)
            Total = (From i In Lista.AsParallel Where i.Valido).ToList.Select(Function(c As JirehReports.ComprovantePagamentoReport.ItemComprovantePagamento)
                                                                                  If c.Ocorrencia.Substring(0, 2) <> "00" Then
                                                                                      c.Valido = False
                                                                                  End If
                                                                                  Return c
                                                                              End Function).ToList
            Dim Valor As Decimal = Total.Sum(Function(i As JirehReports.ComprovantePagamentoReport.ItemComprovantePagamento)
                                                 Return i.Valor
                                             End Function)
            lblSubRelatorio.Text = "Quantidade: " & Total.Count.ToString("0000") & "   -   Valor Total: " & Valor.ToString("C")
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub dgvComprovantes_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvComprovantes.CellFormatting
        If IsDate(e.Value) AndAlso CDate(e.Value) = DateTime.MinValue Then
            e.Value = String.Empty
        End If
    End Sub

    Private Sub dgvComprovantes_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvComprovantes.CellValueChanged
        Try
            Totalizar()
        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

End Class