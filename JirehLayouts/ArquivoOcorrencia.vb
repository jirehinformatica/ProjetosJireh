Public Class ArquivoOcorrencia

    Public Sub New()
        QuantidadeOcorrenciasValue = 0
        SucessoValue = False
        Mensagem01Value = String.Empty
        Mensagem02Value = String.Empty
        Mensagem03Value = String.Empty
        Mensagem04Value = String.Empty
        Mensagem05Value = String.Empty
    End Sub

    Public Sub SetOcorrencia(ByVal ColunaOcorrecia As String, ByVal NomeTabela As NameTabelaOcorrecia)
        Try
            Select Case NomeTabela
                Case NameTabelaOcorrecia.G059
                    CarregarG059()
            End Select

            Dim aux As String

            For ini As Integer = 0 To ColunaOcorrecia.Length - 1 Step 2
                Select Case QuantidadeOcorrenciasValue
                    Case 0
                        aux = ColunaOcorrecia.Substring(ini, 2)
                        If aux = "00" Then
                            SucessoValue = True
                        Else
                            SucessoValue = False
                        End If
                        Mensagem01Value = BuscarOcorrencia(aux)
                        QuantidadeOcorrenciasValue += 1
                    Case 1
                        Mensagem02Value = BuscarOcorrencia(ColunaOcorrecia.Substring(ini, 2))
                        QuantidadeOcorrenciasValue += 1
                    Case 2
                        Mensagem03Value = BuscarOcorrencia(ColunaOcorrecia.Substring(ini, 2))
                        QuantidadeOcorrenciasValue += 1
                    Case 3
                        Mensagem04Value = BuscarOcorrencia(ColunaOcorrecia.Substring(ini, 2))
                        QuantidadeOcorrenciasValue += 1
                    Case 4
                        Mensagem05Value = BuscarOcorrencia(ColunaOcorrecia.Substring(ini, 2))
                        QuantidadeOcorrenciasValue += 1
                End Select
            Next

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Function BuscarOcorrencia(ByVal Value As String) As String
        Try
            If TabelaOcorrencia.ContainsKey(Value) Then
                Return TabelaOcorrencia(Value)
            End If
            Return String.Empty
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private TabelaOcorrencia As Dictionary(Of String, String)
    Private Sub CarregarG059()
        Try
            TabelaOcorrencia = New Dictionary(Of String, String)

            TabelaOcorrencia.Add("  ", "")
            TabelaOcorrencia.Add("00", "00 - Crédito ou Débito Efetivado")
            TabelaOcorrencia.Add("01", "01 - Insuficiência de Fundos - Débito não efetuado")
            TabelaOcorrencia.Add("02", "02 - Crédito ou Débito Cancelado pelo Pagador/Credor")
            TabelaOcorrencia.Add("03", "03 - Débito Autorizado pela Agência - Efetuado")
            TabelaOcorrencia.Add("HA", "HA - Lote não aceito")
            TabelaOcorrencia.Add("HB", "HB - Inscrição da Empresa Inválida para o Contrato")
            TabelaOcorrencia.Add("HC", "HC - Convênio com a Empresa Inexistente/Inválido para o Contrato")
            TabelaOcorrencia.Add("HD", "HD - Agência/Conta Corrente da Empresa Inexistente/Inválido para o Contrato")
            TabelaOcorrencia.Add("HE", "HE - Tipo de Serviço Inválido para o Contrato")
            TabelaOcorrencia.Add("HF", "HF - Conta Corrente da Empresa com Saldo Insuficiente")
            TabelaOcorrencia.Add("HG", "HG - Lote de Serviço fora de Seqüência")
            TabelaOcorrencia.Add("HH", "HH - Lote de serviço inválido")
            TabelaOcorrencia.Add("HI", "HI - Número da remessa inválido")
            TabelaOcorrencia.Add("HJ", "HJ - Arquivo sem 'HEADER'")
            TabelaOcorrencia.Add("HM", "HM - Versão do arquivo inválido")
            TabelaOcorrencia.Add("AA", "AA - Controle inválido")
            TabelaOcorrencia.Add("AB", "AB - Tipo de operação inválido")
            TabelaOcorrencia.Add("AC", "AC - Tipo de serviço inválido")
            TabelaOcorrencia.Add("AD", "AD - Forma de Lançamento inválida")
            TabelaOcorrencia.Add("AE", "AE - Tipo/Número de inscrição inválido")
            TabelaOcorrencia.Add("AF", "AF - Código de convênio inválido")
            TabelaOcorrencia.Add("AG", "AG - Agência/Conta corrente/DV inválido")
            TabelaOcorrencia.Add("AH", "AH - Número seqüencial do registro no lote inválido")
            TabelaOcorrencia.Add("AI", "AI - Código de segmento de detalhe inválido")
            TabelaOcorrencia.Add("AJ", "AJ - Tipo de movimento inválido")
            TabelaOcorrencia.Add("AK", "AK - Código da câmara de compensação do banco favorecido/depositário inválido")
            TabelaOcorrencia.Add("AL", "AL - Código do banco favorecido ou depositário inválido")
            TabelaOcorrencia.Add("AM", "AM - Agência mantenedora da conta corrente do favorecido inválida")
            TabelaOcorrencia.Add("AN", "AN - Conta Corrente / DV do favorecido inválido")
            TabelaOcorrencia.Add("AO", "AO - Nome do favorecido não informado")
            TabelaOcorrencia.Add("AP", "AP - Data de lançamento inválido")
            TabelaOcorrencia.Add("AQ", "AQ - Tipo/quantidade de moeda inválida")
            TabelaOcorrencia.Add("AR", "AR - Valor do lançamento inválido")
            TabelaOcorrencia.Add("AS", "AS - Aviso ao favorecido - identificação inválida")
            TabelaOcorrencia.Add("AT", "AT - Tipo/número de inscrição do favorecido inválido")
            TabelaOcorrencia.Add("AU", "AU - Logradouro do favorecido não informado")
            TabelaOcorrencia.Add("AV", "AV - Número do local do favorecido não informado")
            TabelaOcorrencia.Add("AW", "AW - Cidade do favorecido não informada")
            TabelaOcorrencia.Add("AX", "AX - CEP/complemento do favorecido inválido")
            TabelaOcorrencia.Add("AY", "AY - Sigla do Estado do Favorecido Inválido")
            TabelaOcorrencia.Add("AZ", "AZ - Código/nome do banco depositário inválido")
            TabelaOcorrencia.Add("BA", "BA - Código/nome da agência depositária não informado")
            TabelaOcorrencia.Add("BB", "BB - Seu número inválido")
            TabelaOcorrencia.Add("BC", "BC - Nosso número inválido")
            TabelaOcorrencia.Add("BD", "BD - Inclusão efetuada com sucesso")
            TabelaOcorrencia.Add("BE", "BE - Alteração efetuada com sucesso")
            TabelaOcorrencia.Add("BF", "BF - Exclusão efetuada com sucesso")
            TabelaOcorrencia.Add("BG", "BG - Agência/conta impedida legalmente")
            TabelaOcorrencia.Add("CA", "CA - Código de barras - código do banco inválido")
            TabelaOcorrencia.Add("CB", "CB - Código de barras - código da moeda inválida")
            TabelaOcorrencia.Add("CC", "CC - Código de barras - dígito verificador geral inválido")
            TabelaOcorrencia.Add("CD", "CD - Código de barras - valor do título inválido")
            TabelaOcorrencia.Add("CE", "CE - Código de barras - campo livre inválido")
            TabelaOcorrencia.Add("CF", "CF - Valor do documento inválido")
            TabelaOcorrencia.Add("CG", "CG - Valor do abatimento inválido")
            TabelaOcorrencia.Add("CH", "CH - Valor do desconto inválido")
            TabelaOcorrencia.Add("CI", "CI - Valor de mora inválido")
            TabelaOcorrencia.Add("CJ", "CJ - Valor da multa inválido")
            TabelaOcorrencia.Add("CK", "CK - Valor do IR inválido")
            TabelaOcorrencia.Add("CL", "CL - Valor do ISS inválido")
            TabelaOcorrencia.Add("CM", "CM - Valor do IOF inválido")
            TabelaOcorrencia.Add("CN", "CN - Valor de outras deduções inválido")
            TabelaOcorrencia.Add("CO", "CO - Valor de outros acréscimos inválido")
            TabelaOcorrencia.Add("CP", "CP - Valor do INSS inválido")
            TabelaOcorrencia.Add("CQ", "CQ - Código de barras inválido")
            TabelaOcorrencia.Add("TA", "TA - Lote não aceito - totais de lote com diferença")
            TabelaOcorrencia.Add("TB", "TB - Lote sem trailler")
            TabelaOcorrencia.Add("TC", "TC - Lote de Arquivo sem trailler")
            TabelaOcorrencia.Add("YA", "YA - Título não encontrado")
            TabelaOcorrencia.Add("YB", "YB - Identificador registro opcional inválido")
            TabelaOcorrencia.Add("YC", "YC - Código padrão inválido")
            TabelaOcorrencia.Add("YD", "YD - Código de ocorrência inválido")
            TabelaOcorrencia.Add("YE", "YE - Complemento de ocorrência inválido")
            TabelaOcorrencia.Add("YF", "YF - Alegação já informada")
            TabelaOcorrencia.Add("ZA", "ZA - Agência/conta do favorecido substituída")

        Catch ex As Exception
            Throw
        End Try
    End Sub

#Region "PROPRIEDADES"

    Private Mensagem01Value As String
    Public ReadOnly Property Mensagem01 As String
        Get
            Return Mensagem01Value
        End Get
    End Property

    Private Mensagem02Value As String
    Public ReadOnly Property Mensagem02 As String
        Get
            Return Mensagem02Value
        End Get
    End Property

    Private Mensagem03Value As String
    Public ReadOnly Property Mensagem03 As String
        Get
            Return Mensagem03Value
        End Get
    End Property

    Private Mensagem04Value As String
    Public ReadOnly Property Mensagem04 As String
        Get
            Return Mensagem04Value
        End Get
    End Property

    Private Mensagem05Value As String
    Public ReadOnly Property Mensagem05 As String
        Get
            Return Mensagem05Value
        End Get
    End Property

    Private QuantidadeOcorrenciasValue As Integer
    Public ReadOnly Property QuantidadeOcorrencias As Integer
        Get
            Return QuantidadeOcorrenciasValue
        End Get
    End Property

    Private SucessoValue As Boolean
    Public ReadOnly Property Sucesso As Boolean
        Get
            Return SucessoValue
        End Get
    End Property

#End Region

End Class

Public Enum NameTabelaOcorrecia
    G059 = 0
End Enum