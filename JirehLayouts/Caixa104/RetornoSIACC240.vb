Public Class RetornoSIACC240
    Inherits JirehLayoutBase

    Public Sub New(ByVal PathArquivoRetorno As String, ByRef EventoEmExecucao As JirehLayoutEventos)
        MyBase.New(PathArquivoRetorno, EventoEmExecucao, 240)
        Try
            HeaderArquivo = New tpHeaderArquivo
            HeaderLote = New tpHeaderLote
            ItensArquivo = New List(Of tpItemArquivo)
            Dim Item As tpItemArquivo = Nothing

            Eventos.OnProgresso(0, "Iniciando a leitura do arquivo", LinhasCount)
            For I As Long = 0 To LinhasCount - 1

                If Eventos.Cancelado Then
                    Exit For
                End If
                Eventos.OnProgresso(I, "lendo a linha " & I.ToString("0000") & " do arquivo.")

                'Buscando header arquivo (posição 8 = 0)
                If Ler(I, 8, 1) = "0" Then
                    ExeHeader(I)
                End If
                'Buscando header de lote (posição 8 = 1)
                If Ler(I, 8, 1) = "1" Then
                    ExeLote(I)
                End If

                'Corpo de lote SEG. A (posição 8 = 3) e (posição 14 = A)
                If Ler(I, 8, 1) = "3" AndAlso Ler(I, 14, 1).ToUpper() = "A" Then
                    If Item IsNot Nothing Then
                        ItensArquivo.Add(Item)
                    End If
                    Item = ExeSegA(I)
                End If

                'Corpo de lote SEG. B (posição 8 = 3) e (posição 14 = B)
                If Ler(I, 8, 1) = "3" AndAlso Ler(I, 14, 1).ToUpper() = "B" Then
                    ExeSegB(I, Item)
                End If

                'Corpo de lote SEG. Z (posição 8 = 3) e (posição 14 = Z)
                If Ler(I, 8, 1) = "3" AndAlso Ler(I, 14, 1).ToUpper() = "Z" Then
                    ExeSegZ(I, Item)
                End If

            Next
            If Item IsNot Nothing Then
                ItensArquivo.Add(Item)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Overrides ReadOnly Property NumeroBanco As Integer
        Get
            Return 104
        End Get
    End Property

    ''' <summary>
    ''' Header do arquivo
    ''' </summary>
    Private Sub ExeHeader(ByVal Linha As Long)
        Try
            If Not ArquivoValidoValue Then
                Exit Sub
            End If

            With HeaderArquivo

                '0.01 001 003 9(003) Código do Banco
                .CodigoBancoArquivo = Ler(Linha, 1, 3).ToInteger(0)
                '0.14 053 057 9(005) Agencia da conta corrente
                .ContaCorrenteAgencia = Ler(Linha, 53, 5)
                '0.15 058 058 9(001) DV da Agência
                .ContaCorrenteAgenciaDv = Ler(Linha, 58, 1)
                '0.16 059 070 9(012) Número da conta
                .ContaCorrenteNumero = Ler(Linha, 59, 12)
                '0.17 071 071 X(001) DV da conta
                .ContaCorrenteNumeroDv = Ler(Linha, 71, 1)
                '0.20 103 132 X(030) Nome do Banco
                .NomeBancoArquivo = Ler(Linha, 103, 30)
                '0.23 144 151 9(008) Data geração do arquivo
                '0.24 152 157 9(006) Hora geração do arquivo
                .DataHoraGeracao = Ler(Linha, 144, 14).ToDateTimeConvert
                '0.19 073 102 X(030) Nome da empresa
                .NomeEmpresa = Ler(Linha, 73, 30)
                '0.25 158 163 9(006) NSA
                .NSA = Ler(Linha, 158, 6)
                '0.26 164 166 9(003) Versão leiaute do arquivo
                .VersaoNoArquivo = Ler(Linha, 164, 3)

            End With

        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Header do lote
    ''' </summary>
    Private Sub ExeLote(ByVal Linha As Long)
        Try
            If Not ArquivoValidoValue Then
                Exit Sub
            End If

            With HeaderLote

                '1.31 231 240 X(010) Ocorrências
                .Ocorrencia.SetOcorrencia(Ler(Linha, 231, 10), NameTabelaOcorrecia.G059)
                If Not .Ocorrencia.Sucesso Then
                    Exit Sub
                End If
                '0.01 001 003 9(003) Código do Banco
                .CodigoBancoArquivo = Ler(Linha, 1, 3).ToInteger(0)
                '1.02 004 007 9(004) Lote de Serviço
                .LoteServico = Ler(Linha, 4, 4)
                '1.04 009 009 X(001) Tipo de Operação
                .OperacaoDC = Ler(Linha, 9, 1)
                '1.07 014 016 9(003) Versão do leiaute do lote
                .VersaoNoLote = Ler(Linha, 14, 3)
                '1.09 018 018 9(001) Tipo de inscrição
                .TipoInscricao = Ler(Linha, 18, 1).ToInteger(1)
                '1.10 019 032 9(014) Número da inscrição
                .NumeroInscricao = Ler(Linha, 19, 14)
                '1.11 033 038 9(006) Código Convênio no Banco
                .CodigoConvenio = Ler(Linha, 33, 6)
                '1.12 039 040 9(002) Tipo de Compromisso
                .TipoCompromisso = Ler(Linha, 39, 2).ToInteger
                '1.16 053 057 9(005) Agencia da Conta Corrente
                .ContaCorrenteAgencia = Ler(Linha, 53, 5)
                '1.17 058 058 X(001) DV da Agência
                .ContaCorrenteAgenciaDv = Ler(Linha, 58, 1)
                '1.18 059 070 9(012) Número da Conta Corrente
                .ContaCorrenteNumero = Ler(Linha, 59, 12)
                '1.19 071 071 X(001) DV da Conta Corrente
                .ContaCorrenteNumeroDv = Ler(Linha, 71, 1)
                '1.21 073 102 X(030) Nome da Empresa
                .NomeEmpresa = Ler(Linha, 73, 30)
                '1.23 143 172 X(030) Logradouro
                .EnderecoLogradouro = Ler(Linha, 143, 30)
                '1.24 173 177 9(005) Número no local
                .EnderecoNumero = Ler(Linha, 173, 5)
                '1.25 178 192 X(015) Complemento
                .EnderecoComplemento = Ler(Linha, 178, 15)
                '1.26 193 212 X(020) Cidade
                .EnderecoCidade = Ler(Linha, 193, 20)
                '1.27 213 217 9(005) CEP
                '1.28 218 220 X(003) Complemento CEP
                .EnderecoCEP = Ler(Linha, 213, 8)
                '1.29 221 222 X(002) Sigla do Estado
                .EnderecoEstado = Ler(Linha, 221, 2)

            End With

        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' SEG A
    ''' </summary>
    Private Function ExeSegA(ByVal Linha As Long) As tpItemArquivo
        Try
            Dim Novo As New tpItemArquivo

            With Novo

                'A.01 001 003 9(003) Código do Banco
                .CodigoBancoArquivo = Ler(Linha, 1, 3)
                'A.02 004 007 9(004) Lote de Serviço
                .LoteServico = Ler(Linha, 4, 4)
                'A.04 009 013 9(005) NSR
                .NSR = Ler(Linha, 9, 5)
                'A.06 015 015 9(001) Tipo Movimento
                .TipoMovimento = Ler(Linha, 15, 1).ToInteger
                'A.15 044 073 X(030) Nome do Terceiro (favorecido)
                .NomeFavorecido = Ler(Linha, 44, 30)

                'A.36 231 240 X(010) Ocorrências
                .Ocorrencia.SetOcorrencia(Ler(Linha, 231, 10), NameTabelaOcorrecia.G059)
                If Not .Ocorrencia.Sucesso Then
                    Return Novo
                End If

                'A.09 021 023 9(003) Código Banco Destino
                .ContaCorrenteBancoDestino = Ler(Linha, 21, 3)
                'A.10 024 028 9(005) Código Agencia Destino
                .ContaCorrenteAgencia = Ler(Linha, 24, 5)
                'A.11 029 029 X(001) DV Agência Destino
                .ContaCorrenteAgenciaDv = Ler(Linha, 29, 1)
                'A.12 030 041 9(012) Conta Corrente Destino
                .ContaCorrenteNumero = Ler(Linha, 30, 12)
                'A.13 042 042 X(001) DV Conta Destino
                .ContaCorrenteNumeroDv = Ler(Linha, 42, 1)
                'A.16 074 079 9(006) Número Documento atribuído pela Empresa
                .NumeroDocumentoEmpresa = Ler(Linha, 74, 6)
                'A.19 094 101 9(008) Data Vencimento
                .DataVencimento = Ler(Linha, 94, 8).ToDateTimeConvert("ddMMyyyy")
                'A.22 120 134 9(013)V99 Valor Lançamento
                .ValorLancamento = Ler(Linha, 120, 15).ToDecimal100
                'A.25 147 148 9(002) Quantidade de Parcelas
                .ParcelaQuantidade = Ler(Linha, 147, 2).ToInteger
                'A.29 153 154 9(002) Número Parcela
                .ParcelaNumero = Ler(Linha, 153, 2).ToInteger
                'A.30 155 162 9(008) Data da Efetivação
                .DataPagamento = Ler(Linha, 155, 8).ToDateTimeConvert("ddMMyyyy")
                'A.31 163 177 9(013) V99 Valor Real Efetivado
                .ValorPagamento = Ler(Linha, 163, 15).ToDecimal100

            End With

            Return Novo
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' SEG B
    ''' </summary>
    Private Sub ExeSegB(ByVal Linha As Long, ByRef Item As tpItemArquivo)
        Try

            With Item

                If Not .Ocorrencia.Sucesso OrElse Item Is Nothing Then
                    Exit Sub
                End If

                'B.07 018 018 9(001) Tipo Inscrição
                .TipoInscricao = Ler(Linha, 18, 1).ToInteger(1)
                'B.08 019 032 9(014) Número Inscrição
                .NumeroInscricao = Ler(Linha, 19, 14)
                'B.09 033 062 X(030) Logradouro
                .EnderecoLogradouro = Ler(Linha, 33, 30)
                'B.10 063 067 9(005) Número no local
                .EnderecoNumero = Ler(Linha, 63, 5)
                'B.11 068 082 X(015) Complemento
                .EnderecoComplemento = Ler(Linha, 68, 15)
                'B.12 083 097 X(015) Bairro
                .EnderecoBairro = Ler(Linha, 83, 15)
                'B.13 098 117 X(020) Cidade
                .EnderecoCidade = Ler(Linha, 98, 20)
                'B.14 118 122 9(005) CEP
                'B.15 123 125 X(003) Complemento CEP
                .EnderecoCEP = Ler(Linha, 118, 8)
                'B.16 126 127 X(002) UF do Estado
                .EnderecoEstado = Ler(Linha, 126, 2)
                'B.18 136 150 9(013) V99 Valor do Documento
                .ValorDocumento = Ler(Linha, 136, 15).ToDecimal100
                'B.19 151 165 9(013) V99 Valor do Abatimento
                .ValorAbatimento = Ler(Linha, 151, 15).ToDecimal100
                'B.20 166 180 9(013) V99 Valor do Desconto
                .ValorDesconto = Ler(Linha, 166, 15).ToDecimal100
                'B.21 181 195 9(013) V99 Valor da Mora
                .ValorMora = Ler(Linha, 181, 15).ToDecimal100
                'B.22 196 210 9(013) V99 Valor da Multa
                .ValorMulta = Ler(Linha, 196, 15).ToDecimal100

            End With

        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' SEG Z
    ''' </summary>
    Private Sub ExeSegZ(ByVal Linha As Long, ByRef Item As tpItemArquivo)
        Try

            With Item

                If Not .Ocorrencia.Sucesso OrElse Item Is Nothing Then
                    Exit Sub
                End If

                'Z.06 015 078 9(064) Autenticação para atender Legislação
                .AutenticacaoLegislacao = Ler(Linha, 15, 64)
                'Z.07 079 103 9(025) Autenticação Bancária / Protocolo
                .AutenticacaoBancaria = Ler(Linha, 79, 25)

            End With

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Property ItensArquivo As List(Of tpItemArquivo)

#Region "PROPRIEDADES HEADER ARQUIVO"

    Public Property HeaderArquivo As tpHeaderArquivo

    Public Class tpHeaderArquivo

        Public Property DataHoraGeracao As DateTime
        Public Property CodigoBancoArquivo As Integer
        Public Property NomeBancoArquivo As String
        Public Property ContaCorrenteAgencia As String
        Public Property ContaCorrenteAgenciaDv As String
        Public Property ContaCorrenteNumero As String
        Public Property ContaCorrenteNumeroDv As String
        Public Property NomeEmpresa As String
        Public Property VersaoNoArquivo As String
        Public Property NSA As String
        Public ReadOnly Property AgenciaEContaCompleto As String
            Get
                Return ContaCorrenteAgencia.Substring(1) & "." & ContaCorrenteNumero.Substring(1, 3) & "." & ContaCorrenteNumero.Substring(4, 8) & "-" & ContaCorrenteNumeroDv
            End Get
        End Property

    End Class

#End Region

#Region "PROPRIEDADES HEADER LOTE"

    Public Property HeaderLote As tpHeaderLote

    Public Class tpHeaderLote

        Public Sub New()
            Ocorrencia = New ArquivoOcorrencia
        End Sub

        Public Property Ocorrencia As ArquivoOcorrencia
        Public Property OperacaoDC As String
        Public Property CodigoBancoArquivo As Integer
        Public Property LoteServico As String
        Public Property VersaoNoLote As String
        Public Property TipoInscricao As TipoInscricao
        Private NumeroInscricaoValue As String
        Public Property NumeroInscricao As String
            Get
                If Not Ocorrencia.Sucesso Then
                    Return String.Empty
                End If
                If TipoInscricao = JirehLayouts.TipoInscricao.CPF Then
                    Return NumeroInscricaoValue.Substring(3, 3) & "." & NumeroInscricaoValue.Substring(6, 3) & "." & NumeroInscricaoValue.Substring(9, 3) & "-" & NumeroInscricaoValue.Substring(12, 2)
                Else
                    Return NumeroInscricaoValue.Substring(0, 2) & "." & NumeroInscricaoValue.Substring(2, 3) & "." & NumeroInscricaoValue.Substring(5, 3) & "/" & NumeroInscricaoValue.Substring(8, 4) & "-" & NumeroInscricaoValue.Substring(12, 2)
                End If
            End Get
            Set(value As String)
                NumeroInscricaoValue = value
            End Set
        End Property
        Public Property CodigoConvenio As String
        Public Property TipoCompromisso As TipoCompromissoSIACC240
        Public Property ContaCorrenteAgencia As String
        Public Property ContaCorrenteAgenciaDv As String
        Public Property ContaCorrenteNumero As String
        Public Property ContaCorrenteNumeroDv As String
        Public Property NomeEmpresa As String

        Public Property EnderecoLogradouro As String
        Public Property EnderecoNumero As String
        Public Property EnderecoComplemento As String
        Public Property EnderecoCidade As String
        Private EnderecoCEPValue As String
        Public Property EnderecoCEP As String
            Get
                If Not Ocorrencia.Sucesso Then
                    Return String.Empty
                End If
                Return EnderecoCEPValue.Substring(0, 2) & "." & EnderecoCEPValue.Substring(2, 3) & "-" & EnderecoCEPValue.Substring(5)
            End Get
            Set(value As String)
                EnderecoCEPValue = value
            End Set
        End Property
        Public Property EnderecoEstado As String

        Public ReadOnly Property AgenciaEContaCompleto As String
            Get
                If Not Ocorrencia.Sucesso Then
                    Return String.Empty
                End If
                Return ContaCorrenteAgencia.Substring(1) & "." & ContaCorrenteNumero.Substring(1, 3) & "." & ContaCorrenteNumero.Substring(4, 8) & "-" & ContaCorrenteNumeroDv
            End Get
        End Property

    End Class

#End Region

#Region "DEFINIÇÕES DE ITENS DO ARQUIVO"

    Public Class tpItemArquivo

        Public Sub New()
            Ocorrencia = New ArquivoOcorrencia
        End Sub

        Public Property CodigoBancoArquivo As Integer
        Public Property Ocorrencia As ArquivoOcorrencia
        Public Property LoteServico As String
        Public Property NSR As String
        Public Property TipoMovimento As TipoMovimentoSIACC240
        Public Property ContaCorrenteBancoDestino As String
        Public Property ContaCorrenteAgencia As String
        Public Property ContaCorrenteAgenciaDv As String
        Public Property ContaCorrenteNumero As String
        Public Property ContaCorrenteNumeroDv As String
        Public Property NomeFavorecido As String
        Public Property NumeroDocumentoEmpresa As String
        Public Property DataVencimento As DateTime
        Public Property ValorLancamento As Decimal
        Public Property ParcelaQuantidade As Integer
        Public Property ParcelaNumero As Integer
        Public Property DataPagamento As DateTime
        Public Property ValorPagamento As Decimal
        Public Property TipoInscricao As TipoInscricao
        Private NumeroInscricaoValue As String
        Public Property NumeroInscricao As String
            Get
                If Not Ocorrencia.Sucesso Then
                    Return String.Empty
                End If
                If TipoInscricao = JirehLayouts.TipoInscricao.CPF Then
                    Return NumeroInscricaoValue.Substring(3, 3) & "." & NumeroInscricaoValue.Substring(6, 3) & "." & NumeroInscricaoValue.Substring(9, 3) & "-" & NumeroInscricaoValue.Substring(12, 2)
                Else
                    Return NumeroInscricaoValue.Substring(0, 2) & "." & NumeroInscricaoValue.Substring(2, 3) & "." & NumeroInscricaoValue.Substring(5, 3) & "/" & NumeroInscricaoValue.Substring(8, 4) & "-" & NumeroInscricaoValue.Substring(12, 2)
                End If
            End Get
            Set(value As String)
                NumeroInscricaoValue = value
            End Set
        End Property
        Public Property EnderecoLogradouro As String
        Public Property EnderecoNumero As String
        Public Property EnderecoComplemento As String
        Public Property EnderecoBairro As String
        Public Property EnderecoCidade As String
        Private EnderecoCEPValue As String
        Public Property EnderecoCEP As String
            Get
                If Not Ocorrencia.Sucesso Then
                    Return String.Empty
                End If
                Return EnderecoCEPValue.Substring(0, 2) & "." & EnderecoCEPValue.Substring(2, 3) & "-" & EnderecoCEPValue.Substring(5)
            End Get
            Set(value As String)
                EnderecoCEPValue = value
            End Set
        End Property
        Public Property EnderecoEstado As String
        Public Property ValorDocumento As Decimal
        Public Property ValorAbatimento As Decimal
        Public Property ValorDesconto As Decimal
        Public Property ValorMora As Decimal
        Public Property ValorMulta As Decimal
        Public Property AutenticacaoLegislacao As String
        Public Property AutenticacaoBancaria As String

        Public ReadOnly Property AgenciaEContaCompleto As String
            Get
                If Not Ocorrencia.Sucesso Then
                    Return String.Empty
                End If
                Return ContaCorrenteAgencia.Substring(1) & "." & ContaCorrenteNumero.Substring(1, 3) & "." & ContaCorrenteNumero.Substring(4, 8) & "-" & ContaCorrenteNumeroDv
            End Get
        End Property

    End Class

#End Region

    Public Overrides Function ArquivoValido(NumeroConvenios As String) As Boolean
        Try
            If Not ArquivoValidoValue Then
                Return False
            End If

            Dim Existe As Integer = (From i In NumeroConvenios.Split(";").AsEnumerable Where i.Trim = HeaderLote.CodigoConvenio.Trim).ToList.Count
            ArquivoValidoValue = Existe > 0

            If Not ArquivoValidoValue Then
                Dim aux As Boolean = False
                Eventos.OnMensagem("Convênio não autorizado para leitura do arquivo. Entre em contato com o suporte.", aux)
                Return False
            End If
            Return ArquivoValidoValue
        Catch ex As Exception
            Throw
        End Try
    End Function

End Class

Public Enum TipoCompromissoSIACC240
    Nenhum = 0
    PagamentoFornecedor = 1
    PagamentoDeSalarios = 2
    Autopagamento = 3
    SalarioAmpliacaoDeBase = 6
    DebitoEmConta = 11
End Enum

Public Enum TipoMovimentoSIACC240
    Inclusao = 0
    Exclusao = 9
End Enum