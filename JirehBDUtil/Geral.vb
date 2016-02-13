Imports System.Runtime.CompilerServices
Imports System.IO
Imports System.Text
Imports System.Globalization

Public Module Geral

    Private Const ChaveCriptografia As String = "JeSuSeMeuPR0teT0Rm3UsocORroM1NHAeSP3RANcaMeUtUd0"

    Private Const BDNomeDataSourceHomlog As String = "localhost"
    Private Const BDNomeDataBaseHomolog As String = "JirehValidador"
    Private Const BDNomeRootHomolog As String = "root"
    Private Const BDSenhaRootHomolog As String = "root"

    Private Const BDNomeDataSource As String = "mysql05.vieiramachado.adv.br"
    Private Const BDNomeDataBase As String = "vieiramachado1"
    Private Const BDNomeRoot As String = "vieiramachado1"
    Private Const BDSenhaRoot As String = "Jireh0418"

    Public Property CnMySQL As MySQL
    Public Property InfoRegistro As ChaveExecucao

    Private ReadOnly Property Homologacao As Boolean
        Get
            'Return False
            Return True
        End Get
    End Property

    Public Function OpenConexaoMySQL() As Boolean
        Dim aux As String = String.Empty
        Try
            OpenConexaoMySQLValue = String.Empty
            If Homologacao Then
                CnMySQL = MySQL.GetBD(BDNomeDataBaseHomolog, BDNomeDataSourceHomlog, BDNomeRootHomolog, BDSenhaRootHomolog)
                aux = BDNomeDataSourceHomlog
            Else
                CnMySQL = MySQL.GetBD(BDNomeDataBase, BDNomeDataSource, BDNomeRoot, BDSenhaRoot)
                aux = BDNomeDataSource
            End If
            Return True
        Catch ex As Exception
            If ex.Message.IndexOf("Erro na conexão MySQL - Mensagem: ") > 0 Then
                OpenConexaoMySQLValue = "Não foi possível conectar no banco de dados para liberar o uso do sistema e os convênios da empresa." & vbCrLf
                OpenConexaoMySQLValue &= "É necessário liberar o acesso para o seguinte endereço da internet: " & aux & vbCrLf
                OpenConexaoMySQLValue &= "Se o endereço informado já está liberado entre em contato com o suporte."
                Return False
            Else
                Throw
            End If
        End Try
    End Function

    Private OpenConexaoMySQLValue As String
    Public ReadOnly Property OpenConexaoMySQLMensagem As String
        Get
            Return OpenConexaoMySQLValue
        End Get
    End Property

    Public Function EnCriptografar(ByVal Valor As String) As String
        Try
            Dim Chave As String = CriptografiaSistema.CreateKeyRfc2898(ChaveCriptografia)
            Dim Crip As New CriptografiaSistema(Chave, CryptProvider.Rijndael)
            If String.IsNullOrEmpty(Valor) Then
                Return String.Empty
            End If
            Return Crip.Encriptografar(Valor)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function DesCriptografar(ByVal Valor As String) As String
        Try
            Dim Chave As String = CriptografiaSistema.CreateKeyRfc2898(ChaveCriptografia)
            Dim Crip As New CriptografiaSistema(Chave, CryptProvider.Rijndael)
            If String.IsNullOrEmpty(Valor) Then
                Return String.Empty
            End If
            Return Crip.Descriptografar(Valor)
        Catch ex As Exception
            Throw
        End Try
    End Function

#Region "EXTENÇÕES DE USO STRING"

    Public Function ParaString(ByVal Valor As Object) As String
        Dim aux As String
        If Valor Is Nothing OrElse IsDBNull(Valor) OrElse String.IsNullOrEmpty(Valor) Then
            aux = String.Empty
        Else
            aux = Valor.ToString
        End If
        Return aux
    End Function

    <Extension()> _
    Public Function ToNumeros(ByVal Valor As Object) As String
        Valor = ParaString(Valor)
        Return String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(Valor, "[^\d]"))
    End Function

    <Extension()> _
    Public Function ToStr(ByVal Valor As Object) As String
        Return ParaString(Valor)
    End Function

    <Extension()> _
    Public Function ToDate(ByVal Valor As Object, Optional ByVal Retorno As Date = Nothing) As Date
        Dim conv As Boolean
        Dim v As Date
        conv = Date.TryParse(ParaString(Valor), v)
        If conv Then
            Return v
        Else
            Return Retorno
        End If
    End Function

    <Extension()> _
    Public Function ToDouble(ByVal Valor As Object, Optional ByVal Retorno As Double = 0) As Double
        Dim conv As Boolean
        Dim v As Double
        conv = Double.TryParse(ParaString(Valor), v)
        If conv Then
            Return v
        Else
            Return Retorno
        End If
    End Function

    <Extension()> _
    Public Function ToDecimal(ByVal Valor As Object, Optional ByVal Retorno As Decimal = 0) As Decimal
        Dim conv As Boolean
        Dim v As Decimal
        conv = Decimal.TryParse(ParaString(Valor), v)
        If conv Then
            Return v
        Else
            Return Retorno
        End If
    End Function

    <Extension()> _
    Public Function ToInteger(ByVal Valor As Object, Optional ByVal Retorno As Integer = 0) As Integer
        Dim conv As Boolean
        Dim v As Integer
        conv = Integer.TryParse(ParaString(Valor), v)
        If conv Then
            Return v
        Else
            Return Retorno
        End If
    End Function

    <Extension()> _
    Public Function ToBool(ByVal Valor As Object) As Boolean
        Dim conv As Boolean
        Dim v As Boolean
        conv = Boolean.TryParse(ParaString(Valor), v)
        If conv Then
            Return v
        Else
            Dim aux As String = ParaString(Valor)
            If aux = "1" OrElse aux.ToLower = "sim" OrElse aux.ToLower = "true" Then
                Return True
            End If
            Return False
        End If
    End Function

    <Extension()> _
    Public Function ToCpf(ByVal Valor As Object) As String
        Dim aux As String = ParaString(Valor).ToNumeros.PadLeft(11, "0")
        If aux.Length = 11 Then
            Return aux.Substring(0, 3) & "." & aux.Substring(3, 3) & "." & aux.Substring(6, 3) & "-" & aux.Substring(9)
        End If
        Return aux
    End Function

    <Extension()> _
    Public Function ToCnpj(ByVal Valor As Object) As String
        Dim aux As String = ParaString(Valor).ToNumeros.PadLeft(14, "0")
        If aux.Length = 14 Then
            Return aux.Substring(0, 2) & "." & aux.Substring(2, 3) & "." & aux.Substring(5, 3) & "/" & aux.Substring(8, 4) & "-" & aux.Substring(12)
        End If
        Return aux
    End Function

    <Extension()> _
    Public Function ToCep(ByVal Valor As Object) As String
        Dim aux As String = ParaString(Valor).ToNumeros.PadLeft(8, "0")
        If aux.Length = 8 Then
            Return aux.Substring(0, 2) & "." & aux.Substring(2, 3) & "-" & aux.Substring(5)
        End If
        Return aux
    End Function

    <Extension()> _
    Public Function ToTelefone(ByVal Valor As Object) As String
        Dim aux As String = ParaString(Valor).ToNumeros
        If aux.Length = 13 Then
            Return aux.Substring(0, 2) & " (" & aux.Substring(2, 2) & ") " & aux.Substring(4, 1) & " " & aux.Substring(5, 4) & "-" & aux.Substring(9, 4)
        ElseIf aux.Length = 12 Then
            Return aux.Substring(0, 2) & " (" & aux.Substring(2, 2) & ") " & aux.Substring(4, 4) & "-" & aux.Substring(8, 4)
        ElseIf aux.Length = 11 Then
            Return "(" & aux.Substring(0, 2) & ") " & aux.Substring(2, 1) & " " & aux.Substring(3, 4) & "-" & aux.Substring(7, 4)
        ElseIf aux.Length = 10 Then
            Return "(" & aux.Substring(0, 2) & ") " & aux.Substring(2, 4) & "-" & aux.Substring(6, 4)
        ElseIf aux.Length = 9 Then
            Return aux.Substring(0, 1) & " " & aux.Substring(1, 4) & "-" & aux.Substring(5, 4)
        ElseIf aux.Length = 8 Then
            Return aux.Substring(0, 4) & "-" & aux.Substring(4, 4)
        End If
        Return aux
    End Function

    <Extension()> _
    Public Function ToMemoryStream(ByVal Valor As Object, Optional ByVal EncodeArquivo As Encoding = Nothing) As MemoryStream
        Dim Buffer As Byte()
        Dim Memoria As MemoryStream = Nothing
        If EncodeArquivo Is Nothing Then
            EncodeArquivo = Encoding.UTF8
        End If
        Buffer = ParaString(Valor).ToArrayByte
        If Not Buffer Is Nothing AndAlso Buffer.Length > 0 Then
            Memoria = New MemoryStream(Buffer)
        End If
        Return Memoria
    End Function

    <Extension()> _
    Public Function ToArrayByte(ByVal Valor As Object, Optional ByVal EncodeArquivo As Encoding = Nothing) As Byte()
        Dim Buffer As Byte()
        If EncodeArquivo Is Nothing Then
            EncodeArquivo = Encoding.UTF8
        End If
        Buffer = EncodeArquivo.GetBytes(ParaString(Valor))
        Return Buffer
    End Function

    <Extension()> _
    Public Function ToEncoder(ByVal Valor As Object) As Text.Encoding
        Select Case ParaString(Valor).ToUpper
            Case "UTF7"
                Return Text.Encoding.UTF7
            Case "UTF8"
                Return Text.Encoding.UTF8
            Case "UTF32"
                Return Text.Encoding.UTF32
            Case "ASCII"
                Return Text.Encoding.ASCII
            Case "UNICODE"
                Return Text.Encoding.Unicode
            Case Else
                Dim aux As Text.Encoding
                aux = Text.Encoding.GetEncoding(ParaString(Valor))
                Return aux
        End Select
    End Function

#End Region

#Region "Validadores gerais"


    <Extension()> _
    Public Function IsCpfOrCnpjValid(ByVal Valor As String) As Boolean
        Try
            Dim valido As Boolean = ValidarCNPJ(Valor)
            If Not valido Then
                valido = ValidarCPF(Valor)
            End If
            Return valido
        Catch ex As Exception
            Throw
        End Try
    End Function


#Region "Funções privadas de validadores gerais"

    Private Function CNPJCPFListaInvalidos(ByVal Valor As String) As Boolean
        Try
            Dim Lista() As String = {"111.111.111-11", "222.222.222-22", "333.333.333-33", _
                         "444.444.444-44", "555.555.555-55", "666.666.666-66", _
                         "777.777.777-77", "888.888.888-88", "999.999.999-99"}

            Dim Valido As Boolean = Not (From i In Lista.AsEnumerable Where i = Valor).ToList.Count = 0

            Return Valido
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function ValidarCPF(ByVal Valor As String) As Boolean
        Try
            Valor = Valor.ToNumeros
            If Valor.Length <> 11 OrElse CNPJCPFListaInvalidos(Valor) Then
                Return False
            End If

            Dim Dv1 As Integer = Valor.Substring(9, 1).ToInteger
            Dim Dv2 As Integer = Valor.Substring(10, 1).ToInteger
            Dim Ch1 As Integer
            Dim Ch2 As Integer

            'Calculando o digito 1
            Dim soma As Double = 0
            Dim resto As Integer
            Dim i As Integer
            Dim p As Integer = 10
            For i = 0 To 8
                soma += Valor(i).ToInteger * p
                p -= 1
            Next
            resto = soma Mod 11
            If resto < 2 Then
                Ch1 = 0
            Else
                Ch1 = 11 - resto
            End If

            'Calculando o digito 2
            soma = 0
            p = 11
            For i = 0 To 9
                soma += Valor(i).ToInteger * p
                p -= 1
            Next
            resto = soma Mod 11
            If resto < 2 Then
                Ch2 = 0
            Else
                Ch2 = 11 - resto
            End If

            'Validando
            If Ch1 <> Dv1 OrElse Ch2 <> Dv2 Then
                Return False
            End If

            Return True
        Catch exA As ArgumentException
            Throw New Exception("Erro de argumentos Validando CNPJ : " & exA.Message, exA)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function ValidarCNPJ(ByVal Valor As String) As Boolean
        Try
            Valor = Valor.ToNumeros
            If Valor.Length <> 14 OrElse CNPJCPFListaInvalidos(Valor) Then
                Return False
            End If

            Dim Dv1 As Integer = Valor.Substring(12, 1).ToInteger
            Dim Dv2 As Integer = Valor.Substring(13, 1).ToInteger
            Dim Ch1 As Integer
            Dim Ch2 As Integer

            'Calculando o digito 1
            Dim soma As Double = 0
            Dim resto As Integer
            Dim i As Integer
            Dim p As Integer = 5
            For i = 0 To 11
                soma += Valor(i).ToInteger * p
                p -= 1
                If p = 1 Then p = 9
            Next
            resto = soma Mod 11
            If resto < 2 Then
                Ch1 = 0
            Else
                Ch1 = 11 - resto
            End If

            'Calculando o digito 2
            soma = 0
            p = 6
            For i = 0 To 12
                soma += Valor(i).ToInteger * p
                p -= 1
                If p = 1 Then p = 9
            Next
            resto = soma Mod 11
            If resto < 2 Then
                Ch2 = 0
            Else
                Ch2 = 11 - resto
            End If

            'Validando
            If Ch1 <> Dv1 OrElse Ch2 <> Dv2 Then
                Return False
            End If

            Return True
        Catch exA As ArgumentException
            Throw New Exception("Erro de argumentos Validando CNPJ : " & exA.Message, exA)
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

#End Region

#Region "DADOS GERAIS DO SISTEMA"

    Private CodigosBancos() As String = {"", "654", "246", "75", "", "25", "641", "65", "213", "19", "", "24", "740", "107", "96", "318", "752", "248", "218", "", "63", "36", _
                                         "122", "204", "394", "237", "0", "208", "263", "473", "412", "40", "", "", "266", "739", "233", "745", "241", "0", "", "95", "756", _
                                         "748", "222", "505", "229", "", "3", "83", "0", "707", "", "", "300", "495", "494", "0", "456", "1", "47", "37", "41", "4", "265", _
                                         "224", "626", "", "", "0", "", "121", "734", "0", "612", "0", "0", "12", "604", "653", "630", "77", "249", "", "184", "29", "0", _
                                         "479", "", "", "376", "74", "217", "76", "757", "600", "243", "0", "", "389", "", "370", "746", "0", "738", "", "66", "7", "45", _
                                         "79", "212", "", "712", "623", "611", "613", "94", "643", "", "735", "0", "747", "88", "633", "741", "120", "", "422", "33", "743", _
                                         "366", "637", "", "464", "82", "0", "634", "18", "0", "0", "655", "610", "119", "124", "", "21", "", "719", "755", "", "81", "250", _
                                         "", "", "17", "69", "", "125", "70", "", "92", "", "104", "114-7", "320", "477", "", "136", "", "97", "085-x", "099-x", "090-2", _
                                         "089-2", "087-6", "098-1", "487", "", "64", "78", "62", "399", "168", "", "492", "652", "341", "", "488", "128", "14", "753", _
                                         "086-8", "", "254", "", "", "751", "118", "", "", "129", "091-4", "84"}

    Private NomeBancos() As String = {"Alvorada Banco de Investimento", "Banco A.J.Renner S.A.", "Banco ABC Brasil S.A.", "Banco ABN AMRO S.A.", "Banco Alfa de Investimentos SA", "Banco Alfa S.A.", _
                                      "Banco Alvorada S.A.", "Banco Andbank (Brasil) S.A.", "Banco Arbi S.A.", "Banco Azteca do Brasil S.A.", "Banco Bandeirantes de Investimentos SA", "Banco BANDEPE S.A.", _
                                      "Banco Barclays S.A.", "Banco BBM S.A.", "Banco BM&FBOVESPA de Serviços de Liquidação e Custódia S.A", "Banco BMG S.A.", "Banco BNP Paribas Brasil S.A.", _
                                      "Banco Boavista Interatlântico S.A.", "Banco Bonsucesso S.A.", "Banco BPI Investimentos SA", "Banco Bradescard S.A.", "Banco Bradesco BBI S.A.", "Banco Bradesco BERJ S.A.", _
                                      "Banco Bradesco Cartões S.A.", "Banco Bradesco Financiamentos S.A.", "Banco Bradesco S.A.", "Banco BRJ S.A.", "Banco BTG Pactual S.A.", "Banco Cacique S.A.", _
                                      "Banco Caixa Geral - Brasil S.A.", "Banco Capital S.A.", "Banco Cargill S.A.", "Banco Caterpillar S.A.", "Banco CBSS S.A.", "Banco Cédula S.A.", "Banco Cetelem S.A.", _
                                      "Banco Cifra S.A.", "Banco Citibank S.A.", "Banco Clássico S.A.", "Banco CNH Industrial Capital S.A.", "Banco Commercial Investment Trus do Brasil S.A.", _
                                      "Banco Confidence de Câmbio S.A.", "Banco Cooperativo do Brasil S.A. - BANCOOB", "Banco Cooperativo Sicredi S.A.", "Banco Credit Agricole Brasil S.A.", _
                                      "Banco Credit Suisse (Brasil) S.A.", "Banco Cruzeiro do Sul S.A.", "Banco CSF S.A.", "Banco da Amazônia S.A.", "Banco da China Brasil S.A.", "Banco Daimlerchrysler S.A.", _
                                      "Banco Daycoval S.A.", "BANCO DE INVEST TENDENCIA S.A.", "BANCO DE INVESTIMENTOS CREDIT SUISSE BRASIL S A - CREDIT SUISSE", "Banco de La Nacion Argentina", _
                                      "Banco de La Provincia de Buenos Aires", "Banco de La Republica Oriental del Uruguay", "Banco de Lage Landen Brasil S.A.", "Banco de Tokyo-Mitsubishi UFJ Brasil S.A.", _
                                      "Banco do Brasil S.A.", "Banco do Estado de Sergipe S.A.", "Banco do Estado do Pará S.A.", "Banco do Estado do Rio Grande do Sul S.A.", "Banco do Nordeste do Brasil S.A.", _
                                      "Banco Fator S.A.", "Banco Fibra S.A.", "Banco Ficsa S.A.", "Banco Fidis S.A.", "Banco Finasa de Investimentos SA", "Banco Ford S.A.", "Banco Geração Futuro de Investimentos", _
                                      "Banco Gerador S.A.", "Banco Gerdau S.A.", "Banco GMAC S.A.", "Banco Guanabara S.A.", "Banco Honda S.A.", "Banco IBM S.A.", "Banco INBURSA de Investimentos S.A.", _
                                      "Banco Industrial do Brasil S.A.", "Banco Indusval S.A.", "Banco Intercap S.A.", "Banco Intermedium S.A.", "Banco Investcred Unibanco S.A.", "Banco Investimentos BMC SA", _
                                      "Banco Itaú BBA S.A.", "Banco Itaú BMG Consignado S.A.", "Banco Itaú Veículos S.A.", "Banco ItaúBank S.A", "Banco Itaucard S.A.", "Banco ITAULEASING S.A.", _
                                      "Banco J. P. Morgan S.A.", "Banco J. Safra S.A.", "Banco John Deere S.A.", "Banco KDB S.A.", "Banco KEB do Brasil S.A.", "Banco Luso Brasileiro S.A.", "Banco Máxima S.A.", _
                                      "Banco Maxinvest S.A.", "BANCO MERCANTIL DE INVESTIMENTOS SA", "Banco Mercantil do Brasil S.A.", "Banco Mercedes-Benz S.A.", "Banco Mizuho do Brasil S.A.", "Banco Modal S.A.", _
                                      "Banco Moneo S.A.", "Banco Morada S.A.", "Banco Morada SA", "Banco Morgan Stanley S.A.", "Banco Nacional de Desenvolvimento Econômico e Social", "Banco Opportunity de Investimento S.A.", _
                                      "Banco Original do Agronegócio S.A.", "Banco Original S.A.", "Banco Ourinvest", "Banco Ourinvest S.A.", "Banco PAN S.A.", "Banco Paulista S.A.", "Banco Pecúnia S.A.", "Banco Petra S.A.", _
                                      "Banco Pine S.A.", "Banco Porto Real de Investimentos S.A.", "Banco Pottencial S.A.", "Banco PSA Finance Brasil S.A.", "Banco Rabobank International Brasil S.A.", "Banco Randon S.A.", _
                                      "Banco Rendimento S.A.", "Banco Ribeirão Preto S.A.", "Banco Rodobens S.A.", "Banco Rural de Investimentos SA", "Banco Safra S.A.", "Banco Santander (Brasil) S.A.", "Banco Semear S.A.", _
                                      "Banco Société Générale Brasil S.A.", "Banco Sofisa S.A.", "Banco Sudameris Investimento SA", "Banco Sumitomo Mitsui Brasileiro S.A.", "Banco Topázio S.A.", "Banco Toyota do Brasil S.A.", _
                                      "Banco Triângulo S.A.", "Banco Tricury S.A.", "Banco Volkswagen S.A.", "Banco Volvo (Brasil) S.A.", "Banco Votorantim S.A.", "Banco VR S.A.", "Banco Western Union do Brasil S.A.", _
                                      "Banco Woori Bank do Brasil S.A.", "Banco Yamaha Motor S.A.", "BANESTES S.A. Banco do Estado do Espírito Santo", "Banif Brasil BI SA", "Banif-Banco Internacional do Funchal (Brasil)S.A.", _
                                      "Bank of America Merrill Lynch Banco Múltiplo S.A.", "BB BANCO DE INVESTIMENTO S A - BB", "BBN Banco Brasileiro de Negócios S.A.", "BCV - Banco de Crédito e Varejo S.A.", _
                                      "BEXS Banco de Câmbio S.A.", "BMW Financeira", "BNY Mellon Banco S.A.", "BPN Brasil Banco Múltiplo S.A.", "BR PARTNERS BANCO DE INVESTIMENTO S A", "Brasil Plural S.A. - Banco Múltiplo", _
                                      "BRB - Banco de Brasília S.A.", "BRB - Crédito, Financiamento e Investimento S.A.", "Brickell S.A. Crédito, financiamento e Investimento", "BV Financeira S.A. - CFI", _
                                      "Caixa Econômica Federal", "Central das Coop. de Economia e Crédito Mutuo do Est. do ES", "China Construction Bank (Brasil) Banco Multiplo S.A.", "Citibank N.A.", _
                                      "Companhia de Crédito, Financ. e Investimento RCI Brasil", "CONFEDERACAO NACIONAL DAS COOPERATIVAS CENTRAIS UNICREDS", "Coop.de Crédito Mútuo dos Despachantes de Trâns.Sta.Catarina", _
                                      "Cooperativa Central de Crédito Noroeste Brasileiro Ltda.", "Cooperativa Central de Crédito Urbano-CECRED", "Cooperativa Central de Economia e Credito Mutuo das Unicreds", _
                                      "Cooperativa Central de Economia e Crédito Mutuo das Unicreds", "Cooperativa de Crédito Rural da Região de Mogiana", "Cooperativa Unicred Central Santa Catarina", _
                                      "CREDIALIANÇA COOPERATIVA DE CRÉDITO RURAL", "Deutsche Bank S.A. - Banco Alemão", "Finamax S/A C. F. I.", "Goldman Sachs do Brasil Banco Múltiplo S.A.", _
                                      "Haitong Banco de Investimento do Brasil S.A.", "Hipercard Banco Múltiplo S.A.", "HSBC Bank Brasil S.A. - Banco Múltiplo", "HSBC Finance (Brasil) S.A. - Banco Múltiplo", _
                                      "ICBC DO BRASIL BANCO MULTIPLO S A - ICBC DO BRASIL", "ING Bank N.V.", "Itaú Unibanco Holding S.A.", "Itaú Unibanco S.A.", "J. Malucelli", "JPMorgan Chase Bank", _
                                      "MSB Bank S.A. Banco de Câmbio", "Natixis Brasil S.A. Banco Múltiplo", "Novo Banco Continental S.A. - Banco Múltiplo", "OBOE Crédito Financiamento e Investimento S.A.", _
                                      "Omni SA Crédito Financiamento Investimento", "Paraná Banco S.A.", "Santana S.A. Crédito, Financiamento e Investimento", "Scania Banco S.A.", "Scotiabank Brasil S.A. Banco Múltiplo", _
                                      "Standard Chartered Bank (Brasil) S/A–Bco Invest.", "Sul Financeira S/A - Crédito, Financiamentos e Investimentos", "UAM - Assessoria e Gestão", "UBS Brasil Banco de Investimento S.A.", _
                                      "Unicred Central do Rio Grande do Sul", "Unicred Norte do Paraná"}

    Private SiteBancos() As String = {"", "www.bancorenner.com.br", "www.abcbrasil.com.br", "www.bancocr2.com.br", "", "www.bancoalfa.com.br", "Nãopossuisite", "www.bancobracce.com.br", "www.arbi.com.br", _
                                      "www.bancoazteca.com.br", "", "www.bandepe.com.br", "www.barclays.com", "www.bbmbank.com.br", "www.bmf.com.br", "www.bancobmg.com.br", "www.bnpparibas.com.br", "nãopossuisite", _
                                      "www.bancobonsucesso.com.br", "", "www.ibi.com.br", "Nãopossuisite", "", "www.iamex.com.br", "www.bmc.com.br", "www.bradesco.com.br", "www.brjbank.com.br", "www.btgpactual.com", _
                                      "www.bancocacique.com.br", "www.bcgbrasil.com.br", "www.bancocapital.com.br", "www.bancocargill.com.br", "www.catfinancial.com.br", "", "www.bancocedula.com.br", "www.cetelem.com.br", _
                                      "www.bancocifra.com.br", "www.citibank.com.br", "Nãopossuisite", "www.bancocnh.com.br", "", "www.bancoconfidence.com.br", "www.bancoob.com.br", "www.sicredi.com.br", _
                                      "www.calyon.com.br", "www.csfb.com", "www.bcsul.com.br", "", "www.bancoamazonia.com.br", "", "www.bancodaimlerchrysler.com.br", "www.daycoval.com.br", "", "", "www.bna.com.ar", _
                                      "www.bapro.com.ar", "Nãopossuisite", "www.delagelanden.com", "www.btm.com.br", "www.bb.com.br", "www.banese.com.br", "www.banparanet.com.br", "www.banrisul.com.br", _
                                      "www.banconordeste.gov.br", "www.bancofator.com.br", "www.bancofibra.com.br", "www.ficsa.com.br", "www.bancofidis.com.br", "", "www.bancoford.com.br", "", "", _
                                      "www.bancogerdau.com.br", "www.bancogmac.com.br", "www.bancoguanabara.com.br", "www.bancohonda.com.br", "www.ibm.com/br/financing/", "www.bancoinbursa.com", _
                                      "www.bancoindustrial.com.br", "www.bip.b.br", "www.intercap.com.br", "www.intermedium.com.br", "Nãopossuisite", "", "www.itaubba.com.br", "www.bancobmg.com.br", _
                                      "www.bancofiat.com.br", "www.itaubank.com.br", "", "", "www.jpmorgan.com", "www.jsafra.com.br", "www.johndeere.com.br", "www.bancokdb.com.br", "www.bancokeb.com.br", _
                                      "www.lusobrasileiro.com.br", "www.bancomaxima.com.br", "www.bancomaxinvest.com.br", "", "www.mercantil.com.br", "", "www.mizuhobank.com/brazil/pt/", "www.bancomodal.com.br", _
                                      "www.bancomoneo.com.br", "www.bancomorada.com.br", "", "www.morganstanley.com.br", "www.bndes.gov.br", "www.opportunity.com.br", "www.bancooriginal.com.br", _
                                      "www.bancooriginal.com.br", "", "www.ourinvest.com.br", "www.bancopan.com.br", "www.bancopaulista.com.br", "www.bancopecunia.com.br", "www.bancopetra.com.br", "www.pine.com.br", _
                                      "", "www.pottencial.com.br", "Nãopossuisite", "www.rabobank.com.br", "", "www.rendimento.com.br", "www.brp.com.br", "www.rodobens.com.br", "", "www.safra.com.br", _
                                      "www.santander.com.br", "www.bancosemear.com.br", "www.sgbrasil.com.br", "www.sofisa.com.br", "", "nãopossuesite", "www.bancotopazio.com.br", "www.bancotoyota.com.br", _
                                      "www.tribanco.com.br", "www.tricury.com.br", "www.bancovw.com.br", "Nãopossuisite", "www.bancovotorantim.com.br", "www.vr.com.br", "", "www.wooribank.com.br", _
                                      "www.yamaha-motor.com.br", "www.banestes.com.br", "", "www.banif.com.br", "www.ml.com", "", "www.concordiabanco.com", "www.bancobcv.com.br", "www.bexs.com.br", "www.bmwfs.com.br", _
                                      "www.bnymellon.com.br", "www.bpnbrasil.com.br", "", "www.brasilplural.com", "www.brb.com.br", "", "", "www.bvfinanceira.com.br", "www.caixa.gov.br", "", "www.bicbanco.com.br", _
                                      "www.citibank.com/brasil", "", "http://www.unicred.com.br/", "www.creditran.com.br", "", "", "", "", "", "", "", "www.deutsche-bank.com.br", "www.finamax.com.br", _
                                      "www.goldmansachs.com", "www.haitongib.com.br", "www.hipercard.com.br", "www.hsbc.com.br", "", "", "www.ing.com", "www.itau.com.br", "www.itau.com.br", "", "www.jpmorganchase.com", _
                                      "www.msbbank.com.br", "", "www.nbcbank.com.br", "", "www.omni.com.br", "www.paranabanco.com.br", "www.santanafinanceira.com.br", "", "www.br.scotiabank.com", _
                                      "www.standardchartered.com", "", "", "WWW.UBS.COM", "www.unicred-rs.com.br"}

    Public Function BuscarBanco(Optional ByVal Codigo As String = "", Optional ByVal Nome As String = "") As DadosBanco
        Try
            Dim Index As Integer
            If Codigo = "" Then
                Index = NomeBancos.ToList.FindIndex(Function(i) i.ToLower.Trim = Nome.ToLower.Trim)
            Else
                Index = CodigosBancos.ToList.FindIndex(Function(i) i.ToLower.Trim = Codigo.ToLower.Trim)
            End If

            Dim Banco As New DadosBanco

            If Index >= 0 Then
                Banco.Codigo = CodigosBancos(Index)
                Banco.Nome = NomeBancos(Index)
                Banco.Site = SiteBancos(Index)
            End If

            Return Banco

        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function BuscarBancoTodos() As List(Of DadosBanco)
        Try
            Dim Lista As New List(Of DadosBanco)
            Dim Item As DadosBanco
            For Index As Integer = 0 To CodigosBancos.Length - 1
                Item = New DadosBanco
                Item.Codigo = CodigosBancos(Index)
                Item.Nome = NomeBancos(Index)
                Item.Site = SiteBancos(Index)
                Lista.Add(Item)
            Next

            Return Lista.OrderBy(Function(i) i.Codigo).ToList

        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function BuscarBancoNomes() As String()
        Try
            Return NomeBancos.OrderBy(Function(i) i).ToArray
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

End Module

Public Class DadosBanco
    Public Property Nome As String
    Public Property Codigo As String
    Public Property Site As String
End Class

