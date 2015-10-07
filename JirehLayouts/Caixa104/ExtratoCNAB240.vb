Public Class ExtratoCNAB240
    Inherits JirehLayoutBase

    Public Sub New(ByVal PathArquivoRetorno As String, ByRef EventoEmExecucao As JirehLayoutEventos)
        MyBase.New(PathArquivoRetorno, EventoEmExecucao, 240)
        Try
            HeaderArquivo = New tpHeaderArquivo
            HeaderLote = New List(Of tpHeaderLote)

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
                    HeaderLoteAtual = New tpHeaderLote(HeaderArquivo.Ocorrencia.Sucesso)
                    ExeLote(I)
                End If

                'Buscando Seg E (posição 8 = 3) e (posição 14 = E)
                If Ler(I, 8, 1) = "3" AndAlso Ler(I, 14, 1).ToUpper = "E" Then
                    ExeSegE(I)
                End If

                'Buscando Trailer de lote (posição 8 = 5)
                If Ler(I, 8, 1) = "5" Then
                    ExeTrailerLote(I)
                    HeaderLote.Add(HeaderLoteAtual)
                    HeaderLoteAtual = Nothing
                End If

            Next

        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Header do arquivo
    ''' </summary>
    Private Sub ExeHeader(ByVal Linha As Long)
        Try
            If Not ArquivoValidoValue Then
                Exit Sub
            End If

            With HeaderArquivo

                '28.0	OCORRÊNICAS	CÓDIGO DAS OCORRÊNCIAS	231	240	10	-	ALFANUMÉRICO	53
                .Ocorrencia.SetOcorrencia(Ler(Linha, 231, 10), NameTabelaOcorrecia.G053SEmPapel)
                If Not .Ocorrencia.Sucesso Then
                    Exit Sub
                End If

                '01.0	CONTROLE	BANCO	CÓDIGO DO BANCO NA COMPENSAÇÃO	1	3	3	-	NUMÉRICO'104'
                .CodigoBancoArquivo = Ler(Linha, 1, 3).ToInteger(0)
                '05.0	Inscrição	TIPO	TIPO DE INSCRIÇÃO DA EMPRESA	18	18	1	
                .TipoInscricao = Ler(Linha, 18, 1).ToInteger(1)
                '06.0	NÚMERO	N.º DE INSCRIÇÃO DA EMPRESA	19	32	14	-	NUMÉRICO	6
                .NumeroInscricao = Ler(Linha, 19, 14)
                '07.0	CONVÊNIO	CÓDIGO DO CONVÊNIO NO BANCO	33	52	20	-	NUMÉRICO	6, 7
                .CodigoConvenio = Ler(Linha, 33, 20)
                '08.0	Agência	CÓDIGO	AGÊNCIA MANTENEDORA DA CONTA (AAAA)	53	57	5	-	NUMÉRICO	6, 8
                .ContaCorrenteAgencia = Ler(Linha, 53, 5)
                '09.0	DV	DÍGITO VERIFICADOR DA AGÊNCIA (Módulo 11)	58	58	1	-	NUMÉRICO	6, 8
                .ContaCorrenteAgenciaDv = Ler(Linha, 58, 1)
                '10.0	Conta	NÚMERO	NÚMERO DA CONTA CORRENTE (0000CCCCCCCC)	59	70	12	-	NUMÉRICO	6, 8
                .ContaCorrenteNumero = Ler(Linha, 59, 12)
                '11.0	DV	DÍGITO VERIFICADOR DA CONTA (Módulo 11)	71	71	1	-	NUMÉRICO	6, 8
                .ContaCorrenteNumeroDv = Ler(Linha, 71, 1)
                '13.0	NOME	NOME DA EMPRESA	73	102	30	-	ALFANUMÉRICO
                .NomeEmpresa = Ler(Linha, 73, 30)
                '14.0	NOME DO BANCO	NOME DO BANCO	103	132	30	-	ALFANUMÉRICO
                .NomeBancoArquivo = Ler(Linha, 103, 30)
                '17.0	DATA DE GERAÇÃO	DATA DE GERAÇÃO DO ARQUIVO	144	151	8	-	NUMÉRICO (DDMMAAAA)
                '18.0	HORA DE GERAÇÃO	HORA DE GERAÇÃO DO ARQUIVO	152	157	6	-	NUMÉRICO (HHMMSS)
                .DataHoraGeracao = Ler(Linha, 144, 14).ToDateTimeConvert
                '19.0	SEQUÊNCIA (NSA)	N.º SEQUENCIAL DO ARQUIVO	158	163	6	-	NUMÉRICO	17
                .NSA = Ler(Linha, 158, 6)
                '20.0	LAYOUT ARQUIVO	N.º DA VERSÃO DO LAYOUT DO ARQUIVO	164	166	3	-	'040'	9
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

            With HeaderLoteAtual

                If Not HeaderArquivo.Ocorrencia.Sucesso Then
                    Exit Sub
                End If
                '01.1	BANCO	CÓDIGO DO BANCO NA COMPENSAÇÃO	1	3	3	
                .CodigoBancoArquivo = Ler(Linha, 1, 3).ToInteger(0)
                '02.1	LOTE	LOTE DE SERVIÇO	4	7	4	-	NUMÉRICO
                .LoteServico = Ler(Linha, 4, 4)
                '04.1	OPERAÇÃO	TIPO DE OPERAÇÃO	9	9	1	-	'E'= EXTRATO C/C	3
                .OperacaoDCE = Ler(Linha, 9, 1)
                '07.1	LAYOUT DO LOTE	N.º DA VERSÃO DO LAYOUT DO LOTE	14	16	3	-	'030'	45
                .VersaoNoLote = Ler(Linha, 14, 3)
                '09.1	Inscrição	TIPO	TIPO DE INSCRIÇÃO DA EMPRESA	18	18	1	-	NUMÉRICO	30
                .TipoInscricao = Ler(Linha, 18, 1).ToInteger(1)
                '10.1	NÚMERO	N.º DE INSCRIÇÃO DA EMPRESA	19	32	14	-	NUMÉRICO	30
                .NumeroInscricao = Ler(Linha, 19, 14)
                '11.1	CÓDIGO DO CONVÊNIO NO BANCO (AAAAOOOCCCCCCCCD)	33	52	20	-	NUMÉRICO	7
                .CodigoConvenio = Ler(Linha, 33, 20)
                '12.1	CÓDIGO	AGÊNCIA MANTENEDORA DA CONTA (AAAA)	53	57	5	-	NUMÉRICO	8
                .ContaCorrenteAgencia = Ler(Linha, 53, 5)
                '13.1	DÍGITO VERIFICADOR DA AGÊNCIA (Módulo 11)	58	58	1	-	NUMÉRICO	8
                .ContaCorrenteAgenciaDv = Ler(Linha, 58, 1)
                '14.1	NÚMERO	NÚMERO DA CONTA CORRENTE (0000CCCCCCCC)	59	70	12	-	NUMÉRICO	8
                .ContaCorrenteNumero = Ler(Linha, 59, 12)
                '15.1	DV	DÍGITO VERIFICADOR DA CONTA (Módulo 11)	71	71	1	-	NUMÉRICO	8
                .ContaCorrenteNumeroDv = Ler(Linha, 71, 1)
                '17.1		NOME	NOME DA EMPRESA	73	102	30	-	ALFANUMÉRICO
                .NomeEmpresa = Ler(Linha, 73, 30)

                '19.1	DATA DO SALDO INICIAL	143	150	8	-	NUMÉRICO (DDMMAAAA)
                .DataSaldoInicio = Ler(Linha, 143, 8).ToDateTimeConvert("ddMMyyyy")
                '20.1	VALOR DO SALDO INICIAL	151	168	16	2	NUMÉRICO
                .ValorSaldoInicio = Ler(Linha, 151, 18).ToDecimal100
                '21.1	SITUAÇÃO DO SALDO INICIAL (D/C)	169	169	1	-	'D'=DEVEDOR 'C'=CREDOR
                .SituacaoDC = Ler(Linha, 169, 1)
                '22.1	POSIÇÃO DO SALDO INICIAL	170	170	1	-	'P'=PARCIAL 'F'=FINAL
                .StatusPF = Ler(Linha, 170, 1)
                '24.1	N° DE SEQUÊNCIA DO EXTRATO	174	178	5	-	NUMÉRICO
                .NumeroSeqExtrato = Ler(Linha, 174, 5)

            End With

        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Segmento E
    ''' </summary>
    Private Sub ExeSegE(ByVal Linha As Long)
        Try
            If Not ArquivoValidoValue OrElse HeaderLoteAtual Is Nothing Then
                Exit Sub
            End If

            Dim Item As New tpItemExtrato(ArquivoValidoValue)
            With Item

                If Not HeaderArquivo.Ocorrencia.Sucesso Then
                    Exit Sub
                End If

                '01.3   CÓDIGO DO BANCO NA COMPENSAÇÃO	1	3	3	-	NUMÉRICO '104'
                .CodigoBancoArquivo = Ler(Linha, 1, 3).ToInteger(0)
                '02.3   LOTE DE SERVIÇO	4	7	4	-	NUMÉRICO
                .LoteServico = Ler(Linha, 4, 4)
                '04.3   N.º DO REGISTRO	N.º SEQUENCIAL DO REGISTRO NO LOTE	9	13	5	-	NUMÉRICO	10
                .NumeroSequencia = Ler(Linha, 9, 5).ToInteger(0)
                '07.3   TIPO DE INSCRIÇÃO DA EMPRESA	18	18	1	-	NUMÉRICO	30
                .TipoInscricao = Ler(Linha, 18, 1).ToInteger(1)
                '08.3	NÚMERO	N.º DE INSCRIÇÃO DA EMPRESA	19	32	14	-	NUMÉRICO	30
                .NumeroInscricao = Ler(Linha, 19, 14)
                '09.3   CÓDIGO DO CONVÊNIO NO BANCO	33	52	20	-	ALFANUMÉRICO	7
                .CodigoConvenio = Ler(Linha, 33, 20)
                '10.3	CÓDIGO	AGÊNCIA MANTENEDORA DA CONTA (AAAA)	53	57	5	-	NUMÉRICO	8
                .ContaCorrenteAgencia = Ler(Linha, 53, 5)
                '11.3	DÍGITO VERIFICADOR DA AGÊNCIA (Módulo 11)	58	58	1	-	NUMÉRICO	8
                .ContaCorrenteAgenciaDv = Ler(Linha, 58, 1)
                '12.3	NÚMERO	NÚMERO DA CONTA CORRENTE (0000CCCCCCCC)	59	70	12	-	NUMÉRICO	8
                .ContaCorrenteNumero = Ler(Linha, 59, 12)
                '13.3	DV	DÍGITO VERIFICADOR DA CONTA (Módulo 11)	71	71	1	-	NUMÉRICO	8
                .ContaCorrenteNumeroDv = Ler(Linha, 71, 1)
                '15.3	NOME DA EMPRESA	73	102	30	-	ALFANUMÉRICO
                .NomeEmpresa = Ler(Linha, 73, 30)

                '17.3   TIPO DO COMPLEMENTO DO LANÇAMENTO	112	113	2	-	NUMÉRICO	63
                .TipoComplemento = Ler(Linha, 112, 2)
                '18.3   COMPLEMENTO DO LANÇAMENTO	114	133	20	-	ALFANUMÉRICO	63
                .ComplementoTipoLancamento = Ler(Linha, 114, 20)
                '19.3   IDENTIFICAÇÃO DE ISENÇÃO DA CPMF	134	134	1	-	S=ISENTO N=NÃO ISENTO
                .CPMF = Ler(Linha, 134, 1)
                '20.3   DATA CONTÁBIL	135	142	8	-	NUMÉRICO (DDMMAAAA)
                .DataContabil = Ler(Linha, 135, 8).ToDateTimeConvert("ddMMyyyy")

                '21.3   DATA DO LANÇAMENTO	143	150	8	-	NUMÉRICO (DDMMAAAA)
                .DataLancamento = Ler(Linha, 143, 8).ToDateTimeConvert("ddMMyyyy")
                '22.3   VALOR DO LANÇAMENTO	151	168	16	2	NUMÉRICO
                .ValorLancamento = Ler(Linha, 151, 18).ToDecimal100
                '23.3   TIPO DO LANCTO: VALOR A DEB/CRED	169	169	1	-	'D'-DÉBITO 'C'=CRÉDITO	49
                .TipoLancamento = Ler(Linha, 169, 1)
                '24.3   CATEGORIA DO LANÇAMENTO	170	172	3	-	NUMÉRICO	15
                .Categoria = CategoriaLancamento.GetCategoriaLancamento(Ler(Linha, 170, 3))
                '25.3   CÓDIGO DO LANÇAMENTO NO BANCO	173	176	4	-	ALFANUMÉRICO
                .CodigoHistorico = Ler(Linha, 173, 4)
                '26.3   DESCRIÇÃO DO HISTÓRICO DO LANCTO NO BANCO	177	201	25	-	ALFANUMÉRICO
                .DescricaoHistorico = Ler(Linha, 177, 25)
                '27.3   N° DOC/COMPLEMENTO	202	240	39	-	ALFANUMÉRICO	62
                .NumeroDocumento = Ler(Linha, 202, 39)

            End With

            HeaderLoteAtual.SegmentoE.Add(Item)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Trailer do lote
    ''' </summary>
    Private Sub ExeTrailerLote(ByVal Linha As Long)
        Try
            If Not ArquivoValidoValue Then
                Exit Sub
            End If

            With HeaderLoteAtual.TrailerLote

                If Not HeaderArquivo.Ocorrencia.Sucesso Then
                    Exit Sub
                End If
                '01.1	BANCO	CÓDIGO DO BANCO NA COMPENSAÇÃO	1	3	3	
                .CodigoBancoArquivo = Ler(Linha, 1, 3).ToInteger(0)
                '02.1	LOTE	LOTE DE SERVIÇO	4	7	4	-	NUMÉRICO
                .LoteServico = Ler(Linha, 4, 4)
                '09.1	Inscrição	TIPO	TIPO DE INSCRIÇÃO DA EMPRESA	18	18	1	-	NUMÉRICO	30
                .TipoInscricao = Ler(Linha, 18, 1).ToInteger(1)
                '10.1	NÚMERO	N.º DE INSCRIÇÃO DA EMPRESA	19	32	14	-	NUMÉRICO	30
                .NumeroInscricao = Ler(Linha, 19, 14)
                '11.1	CÓDIGO DO CONVÊNIO NO BANCO (AAAAOOOCCCCCCCCD)	33	52	20	-	NUMÉRICO	7
                .CodigoConvenio = Ler(Linha, 33, 20)
                '12.1	CÓDIGO	AGÊNCIA MANTENEDORA DA CONTA (AAAA)	53	57	5	-	NUMÉRICO	8
                .ContaCorrenteAgencia = Ler(Linha, 53, 5)
                '13.1	DÍGITO VERIFICADOR DA AGÊNCIA (Módulo 11)	58	58	1	-	NUMÉRICO	8
                .ContaCorrenteAgenciaDv = Ler(Linha, 58, 1)
                '14.1	NÚMERO	NÚMERO DA CONTA CORRENTE (0000CCCCCCCC)	59	70	12	-	NUMÉRICO	8
                .ContaCorrenteNumero = Ler(Linha, 59, 12)
                '15.1	DV	DÍGITO VERIFICADOR DA CONTA (Módulo 11)	71	71	1	-	NUMÉRICO	8
                .ContaCorrenteNumeroDv = Ler(Linha, 71, 1)

                '14.5	VALORES	BLOQUEADO > 24H	SALDO BLOQUEADO ACIMA 24 H	89	106	16	-	NUMÉRICO
                .SaldoBloqueado24 = Ler(Linha, 89, 18).ToDecimal100
                '15.5	LIMITE DA CONTA	107	124	16	2	NUMÉRICO
                .LimiteConta = Ler(Linha, 107, 18).ToDecimal100
                '16.5	BLOQUEADO 24 H	SALDO BLOQUEADO	125	142	16	2	NUMÉRICO
                .SaldoBloqueado = Ler(Linha, 125, 18).ToDecimal100
                '17.5	DATA DO SALDO FINAL	143	150	8	-	NUMÉRICO (DDMMAAAA)
                .DataSaldoFinal = Ler(Linha, 143, 8).ToDateTimeConvert("ddMMyyyy")
                '18.5	VALOR DO SALDO FINAL	151	168	16	2	NUMÉRICO
                .ValorSaldoFinal = Ler(Linha, 151, 18).ToDecimal100
                '19.5	SITUAÇÃO DO SALDO FINAL	169	169	1	-	'D'=DEVEDOR 'C'=CREDOR
                .SituacaoDC = Ler(Linha, 169, 1)
                '20.5	POSIÇÃO DO SALDO FINAL	170	170	1	-	'P'=PARCIAL 'F'=FINAL
                .StatusPF = Ler(Linha, 170, 1)
                '21.5	QUANTTDADE DE REGISTROS DO LOTE	171	176	6	-	NUMÉRICO (REG. TIPOS=1.3.5)
                .TotalRegistros = Ler(Linha, 171, 6).ToInteger
                '22.5	SOMATÓRIA DOS VALORES A CRÉDITO	177	194	16	2	NUMÉRICO (REG. TIPO=3, SEG=E)
                .TotalDebito = Ler(Linha, 177, 18).ToDecimal100
                '23.5	SOMATÓRIA DOS VALORES A CRÉDITO	195	212	16	2	NUMÉRICO (REG. TIPO=3, SEG=E)
                .TotalCredito = Ler(Linha, 195, 18).ToDecimal100

            End With

        Catch ex As Exception
            Throw
        End Try
    End Sub

#Region "PROPRIEDADES HEADER ARQUIVO"

    Public Property HeaderArquivo As tpHeaderArquivo

    Public Class tpHeaderArquivo

        Public Sub New()
            Ocorrencia = New ArquivoOcorrencia("00|  ")
            CodigoConvenio = String.Empty
        End Sub

        Public Property Ocorrencia As ArquivoOcorrencia
        Public Property DataHoraGeracao As DateTime
        Public Property CodigoBancoArquivo As Integer
        Public Property NomeBancoArquivo As String
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

    Private Property HeaderLoteAtual As tpHeaderLote
    Public Property HeaderLote As List(Of tpHeaderLote)

    Public Class tpHeaderLote

        Private ArquivoValidoValue As Boolean
        Public Sub New(ByVal ArquivoValido As Boolean)
            ArquivoValidoValue = ArquivoValido
            SegmentoE = New List(Of tpItemExtrato)
            TrailerLote = New TpTrailerLote(ArquivoValido)
        End Sub

        Public Property OperacaoDCE As String
        Public Property CodigoBancoArquivo As Integer
        Public Property LoteServico As String
        Public Property VersaoNoLote As String
        Public Property TipoInscricao As TipoInscricao
        Private NumeroInscricaoValue As String
        Public Property NumeroInscricao As String
            Get
                If Not ArquivoValidoValue Then
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
        Public Property TipoServico As TipoServicoCNAB240
        Public Property ContaCorrenteAgencia As String
        Public Property ContaCorrenteAgenciaDv As String
        Public Property ContaCorrenteNumero As String
        Public Property ContaCorrenteNumeroDv As String
        Public Property NomeEmpresa As String

        Public Property DataSaldoInicio As DateTime
        Public Property ValorSaldoInicio As Decimal
        Private SituacaoDCValue As String
        Public Property SituacaoDC As String
            Get
                If SituacaoDCValue.ToUpper = "D" Then
                    Return "D - DEVEDOR"
                Else
                    Return "C - CREDOR"
                End If
            End Get
            Set(value As String)
                SituacaoDCValue = value
            End Set
        End Property
        Private StatusPFValue As String
        Public Property StatusPF As String
            Get
                If StatusPFValue.ToUpper = "P" Then
                    Return "P - PARCIAL"
                Else
                    Return "F - FINAL"
                End If
            End Get
            Set(value As String)
                StatusPFValue = value
            End Set
        End Property
        Public Property NumeroSeqExtrato As Integer

        Public ReadOnly Property AgenciaEContaCompleto As String
            Get
                If Not ArquivoValidoValue Then
                    Return String.Empty
                End If
                Return ContaCorrenteAgencia.Substring(1) & "." & ContaCorrenteNumero.Substring(1, 3) & "." & ContaCorrenteNumero.Substring(4, 8) & "-" & ContaCorrenteNumeroDv
            End Get
        End Property

        Public SegmentoE As List(Of tpItemExtrato)

        Public TrailerLote As TpTrailerLote

    End Class

#End Region

#Region "Seg E"

    Public Class tpItemExtrato

        Private ArquivoValidoValue As Boolean
        Public Sub New(ByVal ArquivoValido As Boolean)
        End Sub

        Public Property CodigoBancoArquivo As Integer
        Public Property LoteServico As String
        Public Property NumeroSequencia As Integer
        Public Property TipoInscricao As TipoInscricao
        Private NumeroInscricaoValue As String
        Public Property NumeroInscricao As String
            Get
                If Not ArquivoValidoValue Then
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
        Public Property TipoServico As TipoServicoCNAB240
        Public Property ContaCorrenteAgencia As String
        Public Property ContaCorrenteAgenciaDv As String
        Public Property ContaCorrenteNumero As String
        Public Property ContaCorrenteNumeroDv As String
        Public Property NomeEmpresa As String
        Private CPMFValue As String
        Public Property CPMF As String
            Get
                If CPMFValue.ToUpper = "S" Then
                    Return "ISENTO"
                Else
                    Return "NÃO ISENTO"
                End If
            End Get
            Set(value As String)
                CPMFValue = value
            End Set
        End Property
        Public Property DataContabil As DateTime

        'LANÇAMENTO PARTE DO LAYOUT

        Public Property DataLancamento As DateTime
        Public Property ValorLancamento As Decimal
        Public Property TipoLancamento As String
        Public ReadOnly Property TipoLancamentoDescricao As String
            Get
                If TipoLancamento.ToUpper = "D" Then
                    Return "DÉBITO"
                Else
                    Return "CRÉDITO"
                End If
            End Get
        End Property
        Public Property Categoria As String
        Public Property CodigoHistorico As String
        Public Property DescricaoHistorico As String
        Public Property NumeroDocumento As String

        Public Property TipoComplemento As String
        Private ComplementoTipoLancamentoValue As String
        Public ReadOnly Property ComplementoBancoOrigem As Integer
            Get
                'Tipo do lançamento :
                '00 – sem informação do complemento do lançamento
                '01 – identificação da origem do lançamento
                'Complemento do lançamento
                'Para Tipo = 01 o campo terá o seguinte formato
                'Banco origem lançamento 114 116 3 numérico
                'Agência origem lançamento 117 121 5 numérico
                'Uso exclusivo Febraban/CNAB 122 133 12 brancos
                Return Ler(ComplementoTipoLancamentoValue, 0, 3).ToInteger
            End Get
        End Property
        Public ReadOnly Property ComplementoAgenciaOrigem As String
            Get
                'Tipo do lançamento :
                '00 – sem informação do complemento do lançamento
                '01 – identificação da origem do lançamento
                'Complemento do lançamento
                'Para Tipo = 01 o campo terá o seguinte formato
                'Banco origem lançamento 114 116 3 numérico
                'Agência origem lançamento 117 121 5 numérico
                'Uso exclusivo Febraban/CNAB 122 133 12 brancos
                Return Ler(ComplementoTipoLancamentoValue, 3, 5)
            End Get
        End Property
        Public WriteOnly Property ComplementoTipoLancamento As String
            Set(value As String)
                ComplementoTipoLancamentoValue = value
            End Set
        End Property

        Public ReadOnly Property AgenciaEContaCompleto As String
            Get
                If Not ArquivoValidoValue Then
                    Return String.Empty
                End If
                Return ContaCorrenteAgencia.Substring(1) & "." & ContaCorrenteNumero.Substring(1, 3) & "." & ContaCorrenteNumero.Substring(4, 8) & "-" & ContaCorrenteNumeroDv
            End Get
        End Property

        Protected Function Ler(ByVal Linha As String, ByVal Inicio As Integer, Optional ByVal Tamanho As Integer = -1) As String
            Try
                If ArquivoValidoValue Then
                    If Inicio = 0 Then
                        Inicio = 1
                    End If
                    Inicio -= 1
                    If Tamanho = -1 Then
                        Return Linha.Substring(Inicio).Trim
                    End If
                    Return Linha.Substring(Inicio, Tamanho).Trim
                Else
                    Return String.Empty
                End If
            Catch ex As Exception
                Throw
            End Try
        End Function
    End Class

#End Region

#Region "PROPRIEDADES TRAILER DO LOTE"

    Public Class TpTrailerLote

        Private ArquivoValidoValue As Boolean
        Public Sub New(ByVal ArquivoValido As Boolean)
            ArquivoValidoValue = ArquivoValido
        End Sub

        Public Property CodigoBancoArquivo As Integer
        Public Property LoteServico As String
        Public Property TipoInscricao As TipoInscricao
        Private NumeroInscricaoValue As String
        Public Property NumeroInscricao As String
            Get
                If Not ArquivoValidoValue Then
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
        Public Property ContaCorrenteAgencia As String
        Public Property ContaCorrenteAgenciaDv As String
        Public Property ContaCorrenteNumero As String
        Public Property ContaCorrenteNumeroDv As String

        Public Property SaldoBloqueado24 As String
        Public Property LimiteConta As Decimal
        Public Property SaldoBloqueado As Decimal
        Public Property DataSaldoFinal As DateTime
        Public Property ValorSaldoFinal As Decimal
        Private SituacaoDCValue As String
        Public Property SituacaoDC As String
            Get
                If SituacaoDCValue.ToUpper = "D" Then
                    Return "D - DEVEDOR"
                Else
                    Return "C - CREDOR"
                End If
            End Get
            Set(value As String)
                SituacaoDCValue = value
            End Set
        End Property
        Private StatusPFValue As String
        Public Property StatusPF As String
            Get
                If StatusPFValue.ToUpper = "P" Then
                    Return "P - PARCIAL"
                Else
                    Return "F - FINAL"
                End If
            End Get
            Set(value As String)
                StatusPFValue = value
            End Set
        End Property
        Public Property TotalRegistros As Integer
        Public Property TotalDebito As Decimal
        Public Property TotalCredito As Decimal

    End Class

#End Region

    Public Overrides Function ArquivoValido(NumeroConvenios As String) As Boolean
        Try
            If Not ArquivoValidoValue Then
                Return False
            End If

            Dim Existe As Integer = (From i In NumeroConvenios.Split(";").AsEnumerable Where TesteConvenio(i.Trim, HeaderArquivo.CodigoConvenio.Trim, 20)).ToList.Count
            ArquivoValidoValue = Existe > 0
            If Not ArquivoValidoValue Then
                Dim aux As Boolean = False
                Dim convAux As String
                If IsNumeric(HeaderArquivo.CodigoConvenio) Then
                    convAux = HeaderArquivo.CodigoConvenio.ToInteger
                Else
                    convAux = HeaderArquivo.CodigoConvenio
                End If
                Eventos.OnMensagem("O convênio " & convAux & ", não está autorizado para leitura do arquivo. Entre em contato com o suporte.", aux)
                Return False
            End If

            Dim Query As List(Of tpHeaderLote) = (From i In HeaderLote.AsEnumerable _
                                                  Where TesteConvenio(i.CodigoConvenio, ((From x In NumeroConvenios.Split(";").AsEnumerable _
                                                                                 Where TesteConvenio(x.Trim, i.CodigoConvenio, 20)).FirstOrDefault), 20)).ToList

            If Query.Count = 0 Then
                Eventos.OnMensagem("Não existe nenhum extrato para os convênios autorizados dentro do arquivo informado.", False)
                Return False
            End If

            HeaderLote = Query

            Return ArquivoValidoValue
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Overrides ReadOnly Property NumeroBanco As Integer
        Get
            Return 104
        End Get
    End Property


    Protected Friend Class CategoriaLancamento

        Private Shared Lancamentos As Dictionary(Of String, String)

        Public Shared Function GetCategoriaLancamento(ByVal Valor As String) As String
            Try
                If Lancamentos Is Nothing Then
                    CarregarLancamentos()
                End If

                If Lancamentos.ContainsKey(Valor.Trim) Then
                    Return Lancamentos(Valor.Trim)
                Else
                    Return String.Empty
                End If

            Catch ex As Exception
                Throw
            End Try
        End Function

        Private Shared Sub CarregarLancamentos()
            Try
                Lancamentos = New Dictionary(Of String, String)

                Lancamentos.Add("101", "Cheques")
                Lancamentos.Add("102", "Encargos")
                Lancamentos.Add("103", "Estornos")
                Lancamentos.Add("104", "Lançamento Avisado")
                Lancamentos.Add("105", "Tarifas.")
                Lancamentos.Add("106", "Aplicação.")
                Lancamentos.Add("107", "Empréstimo/Financiamento")
                Lancamentos.Add("108", "Câmbio.")
                Lancamentos.Add("109", "CPMF.")
                Lancamentos.Add("110", "IOF")
                Lancamentos.Add("111", "Imposto de Renda")
                Lancamentos.Add("112", "Pagamento Fornecedores")
                Lancamentos.Add("113", "Pagamento Funcionários")
                Lancamentos.Add("114", "Saque Eletrônico")
                Lancamentos.Add("115", "Ações")
                Lancamentos.Add("116", "Seguro")
                Lancamentos.Add("117", "Transferência Entre Contas")
                Lancamentos.Add("118", "Devolução da Compensação")
                Lancamentos.Add("119", "Devolução de Cheque Depositado")
                Lancamentos.Add("120", "DOC Enviado")
                Lancamentos.Add("121", "Antecipação a Fornecedores")
                Lancamentos.Add("122", "OC/AEROPS")
                Lancamentos.Add("201", "Depósitos")
                Lancamentos.Add("202", "Líquido de Cobrança")
                Lancamentos.Add("203", "Devolução de Cheques")
                Lancamentos.Add("204", "Estornos")
                Lancamentos.Add("205", "Lançamento Avisado.")
                Lancamentos.Add("206", "Resgate de Aplicação")
                Lancamentos.Add("207", "Empréstimo/Financiamento")
                Lancamentos.Add("208", "Câmbio .")
                Lancamentos.Add("209", "DOC Recebido .")
                Lancamentos.Add("210", "Ações .")
                Lancamentos.Add("211", "Dividendos.")
                Lancamentos.Add("212", "Seguro.")
                Lancamentos.Add("213", "Transferência entre Contas")
                Lancamentos.Add("214", "Depósitos Especiais")
                Lancamentos.Add("225", "Devolução da Compensação")
                Lancamentos.Add("216", "OCT")

            Catch ex As Exception
                Throw
            End Try
        End Sub

    End Class

End Class

Public Enum TipoServicoCNAB240
    Nenhum = 0
    Cobranca = 1
    CobrancaSemPapel = 2
    BloquetoEletronico = 3
    ConciliacaoBancaria = 4
    Debitos = 5
    PagamentoDividendos = 10
    PagamentoFornecedor = 20
    PagamentoSalarios = 30
    PagamentoSinistrosSegurados = 50
    PagamentoDespesasViajanteEmTransito = 60
    PagamentoAutorizado = 70
    PagamentoCredenciados = 75
    PagamentoRepresentantes_VendedoresAutorizados = 80
    PagamentoBeneficios = 90
    PagamentoDiversos = 98
End Enum