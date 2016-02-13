Public Class CaixaCIGCB240
    Inherits ArquivoRemessa

    Private Const NumeroPosicoes As Integer = 240

    Public Sub New()
        LayoutValue = GetLayoutPorCodigo()
    End Sub

    Protected Overrides Function GetLayoutPorCodigo() As LayoutsDescricao
        Return New LayoutsDescricao(LayoutRemessa.CaixaCIGCB240, "Remessa Caixa Econômica Federal (CIGCB 240)")
    End Function

    Private LayoutValue As LayoutsDescricao
    Public Overrides ReadOnly Property Layout As LayoutsDescricao
        Get
            Return LayoutValue
        End Get
    End Property

    Public Overrides Function GetArquivoRemessa() As String()
        Try
            'Header Arquivo
            Dim sequencia As Integer = Add(TiposLinha.HeaderArquivo, TipoSegmento.Nenhum, NumeroPosicoes).Sequencia
            Item(sequencia).Add(BancoCodigo, 1, 3)                                              'Código do Banco na Compensação
            Item(sequencia).Add("0000", 4, 4)                                                   'Lote de Serviço
            Item(sequencia).Add("0", 8, 1)                                                      'Tipo de Registro
            Item(sequencia).Add("", 9, 9)                                                       'Uso Exclusivo FEBRABAN / CNAB
            Item(sequencia).Add(CInt(DadosCedente.TipoInscricao), 18, 1)                        'Tipo de Inscrição da Empresa
            Item(sequencia).Add(DadosCedente.CnpjCpf, 19, 14)                                   'Número de Inscrição da Empresa
            Item(sequencia).Add(0, 33, 20, TipoFormato.ZerosEsquerda)                           'Uso Exclusivo CAIXA
            Item(sequencia).Add(DadosCedente.BancoAgencia, 53, 5, TipoFormato.ZerosEsquerda)    'Agência Mantenedora da Conta
            Item(sequencia).Add(DadosCedente.BancoAgenciaDig, 58, 1)                            'Dígito Verificador da Agência
            Item(sequencia).Add(DadosCedente.CodigoCedente, 59, 6)                              'Código do Convênio no Banco
            Item(sequencia).Add(0, 65, 7, TipoFormato.ZerosEsquerda)                            'Uso Exclusivo CAIXA
            Item(sequencia).Add(0, 72, 1, TipoFormato.ZerosEsquerda)                            'Uso Exclusivo CAIXA
            Item(sequencia).Add(DadosCedente.NomeRazao, 73, 30)                                 'Nome da Empresa
            Item(sequencia).Add(NomeBanco(BancoCodigo).ToUpper, 103, 30)                        'Nome do Banco
            Item(sequencia).Add("", 133, 10)                                                    'Uso Exclusivo FEBRABAN / CNAB
            Item(sequencia).Add(CInt(G015.Remessa_Cliente_a_Banco), 143, 1)                     'Código Remessa / Retorno
            Item(sequencia).Add(DataGeracao, 144, 8, TipoFormato.Data)                          'Data de Geração do Arquivo
            Item(sequencia).Add(HoraGeracao, 152, 6, TipoFormato.Hora)                          'Hora de Geração do Arquivo
            Item(sequencia).Add(NSA, 158, 6, TipoFormato.ZerosEsquerda)                         'Número Seqüencial do Arquivo
            Item(sequencia).Add("050", 164, 3)                                                  'No da Versão do Layout do Arquivo
            Item(sequencia).Add(0, 167, 5, TipoFormato.ZerosEsquerda)                           'Densidade de Gravação do Arquivo
            Item(sequencia).Add("", 172, 20)                                                    'Para Uso Reservado do Banco
            Item(sequencia).Add(MensagemEmpresa, 192, 20)                                       'Para Uso Reservado da Empresa
            Item(sequencia).Add("", 212, 4)                                                     'Versão Aplicativo CAIXA
            Item(sequencia).Add("", 216, 25)                                                    'Uso Exclusivo FEBRABAN / CNAB

            'Header Lote
            sequencia = Add(TiposLinha.Headerlote, TipoSegmento.Nenhum, NumeroPosicoes).Sequencia
            Item(sequencia).Add("", 9, 9)




            'Trailer Arquivo
            sequencia = Add(TiposLinha.TrailerArquivo, TipoSegmento.Nenhum, NumeroPosicoes).Sequencia

            Item(sequencia).Add(BancoCodigo, 1, 3)                                              'Código do Banco na Compensação
            Item(sequencia).Add("9999", 7, 4)                                                   'Lote de Serviço
            Item(sequencia).Add("9", 8, 1)                                                      'Tipo de Registro
            Item(sequencia).Add("", 9, 9)                                                       'Uso Exclusivo FEBRABAN/CNAB
            Item(sequencia).Add("", 9, 9) 'Quantidade de Lotes do Arquivo
            Item(sequencia).Add("", 9, 9) 'Quantidade de Registros do Arquivo
            Item(sequencia).Add("", 9, 9) 'Uso Exclusivo FEBRABAN/CNAB
            Item(sequencia).Add("", 9, 9) 'Uso Exclusivo FEBRABAN/CNAB



            Return GetArquivoMontado(19)
        Catch ex As Exception
            Throw
        End Try
    End Function

End Class
