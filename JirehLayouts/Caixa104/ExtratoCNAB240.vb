Public Class ExtratoCNAB240
    Inherits JirehLayoutBase

    Public Sub New(ByVal PathArquivoRetorno As String, ByRef EventoEmExecucao As JirehLayoutEventos)
        MyBase.New(PathArquivoRetorno, EventoEmExecucao, 240)
        Try
            HeaderArquivo = New tpHeaderArquivo
            'HeaderLote = New tpHeaderLote
            'ItensArquivo = New List(Of tpItemArquivo)
            'Dim Item As tpItemArquivo = Nothing
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

            Next

            Eventos.OnProgresso(0, "Iniciando a leitura do arquivo", LinhasCount)

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
                .OperacaoDCE = Ler(Linha, 9, 1)
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

#Region "PROPRIEDADES HEADER ARQUIVO"

    Public Property HeaderArquivo As tpHeaderArquivo

    Public Class tpHeaderArquivo

        Public Sub New()
            Ocorrencia = New ArquivoOcorrencia("00|  ")
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

    Public Property HeaderLote As tpHeaderLote

    Public Class tpHeaderLote

        Private ArquivoValidoValue As Boolean
        Public Sub New(ByVal ArquivoValido As Boolean)
            ArquivoValidoValue = ArquivoValido
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



        Public ReadOnly Property AgenciaEContaCompleto As String
            Get
                If Not ArquivoValidoValue Then
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

    Public Overrides ReadOnly Property NumeroBanco As Integer
        Get
            Return 104
        End Get
    End Property

End Class
