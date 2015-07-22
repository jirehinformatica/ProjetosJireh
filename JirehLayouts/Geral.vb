Imports System.Runtime.CompilerServices
Imports System.Globalization
Imports System.Text
Imports System.IO

Public Module Geral

    Private Bancos As Dictionary(Of String, String)
    Private Sub CarregarBancos()
        Try
            If Bancos Is Nothing Then

                Bancos = New Dictionary(Of String, String)

                SyncLock (Bancos)
                    Bancos.Add("001", "001 - Banco do Brasil S.A.")
                    Bancos.Add("003", "003 - Banco da Amazônia S.A.")
                    Bancos.Add("004", "004 - Banco do Nordeste do Brasil S.A.")
                    Bancos.Add("012", "012 - Banco INBURSA de Investimentos S.A.")
                    Bancos.Add("021", "021 - BANESTES S.A. Banco do Estado do Espírito Santo")
                    Bancos.Add("024", "024 - Banco BANDEPE S.A.")
                    Bancos.Add("025", "025 - Banco Alfa S.A.")
                    Bancos.Add("029", "029 - Banco Itaú BMG Consignado S.A.")
                    Bancos.Add("031", "031 - Banco Beg S.A.")
                    Bancos.Add("033", "033 - Banco Santander (Brasil) S.A.")
                    Bancos.Add("036", "036 - Banco Bradesco BBI S.A.")
                    Bancos.Add("037", "037 - Banco do Estado do Pará S.A.")
                    Bancos.Add("040", "040 - Banco Cargill S.A.")
                    Bancos.Add("041", "041 - Banco do Estado do Rio Grande do Sul S.A.")
                    Bancos.Add("045", "045 - Banco Opportunity de Investimento S.A.")
                    Bancos.Add("047", "047 - Banco do Estado de Sergipe S.A.")
                    Bancos.Add("062", "062 - Hipercard Banco Múltiplo S.A.")
                    Bancos.Add("063", "063 - Banco Bradescard S.A.")
                    Bancos.Add("064", "064 - Goldman Sachs do Brasil Banco Múltiplo S.A.")
                    Bancos.Add("065", "065 - Banco Andbank (Brasil) S.A.")
                    Bancos.Add("069", "069 - BPN Brasil Banco Múltiplo S.A.")
                    Bancos.Add("070", "070 - BRB - Banco de Brasília S.A.")
                    Bancos.Add("073", "073 - BB Banco Popular do Brasil S.A.")
                    Bancos.Add("074", "074 - Banco J. Safra S.A.")
                    Bancos.Add("075", "075 - Banco ABN AMRO S.A.")
                    Bancos.Add("078", "078 - BES Investimento do Brasil S.A.-Banco de Investimento")
                    Bancos.Add("081", "081 - BBN Banco Brasileiro de Negócios S.A.")
                    Bancos.Add("082", "082 - Banco Topázio S.A.")
                    Bancos.Add("083", "083 - Banco da China Brasil S.A.")
                    Bancos.Add("094", "094 - Banco Petra S.A.")
                    Bancos.Add("095", "095 - Banco Confidence de Câmbio S.A.")
                    Bancos.Add("096", "096 - Banco BM&FBOVESPA de Serviços de Liquidação e Custódia S.A")
                    Bancos.Add("104", "104 - Caixa Econômica Federal")
                    Bancos.Add("107", "107 - Banco BBM S.A.")
                    Bancos.Add("119", "119 - Banco Western Union do Brasil S.A.")
                    Bancos.Add("125", "125 - Brasil Plural S.A. - Banco Múltiplo")
                    Bancos.Add("184", "184 - Banco Itaú BBA S.A.")
                    Bancos.Add("204", "204 - Banco Bradesco Cartões S.A.")
                    Bancos.Add("208", "208 - Banco BTG Pactual S.A.")
                    Bancos.Add("212", "212 - Banco Original S.A.")
                    Bancos.Add("215", "215 - Banco Comercial e de Investimento Sudameris S.A.")
                    Bancos.Add("217", "217 - Banco John Deere S.A.")
                    Bancos.Add("218", "218 - Banco Bonsucesso S.A.")
                    Bancos.Add("222", "222 - Banco Credit Agricole Brasil S.A.")
                    Bancos.Add("224", "224 - Banco Fibra S.A.")
                    Bancos.Add("233", "233 - Banco Cifra S.A.")
                    Bancos.Add("237", "237 - Banco Bradesco S.A.")
                    Bancos.Add("246", "246 - Banco ABC Brasil S.A.")
                    Bancos.Add("248", "248 - Banco Boavista Interatlântico S.A.")
                    Bancos.Add("249", "249 - Banco Investcred Unibanco S.A.")
                    Bancos.Add("250", "250 - BCV - Banco de Crédito e Varejo S.A.")
                    Bancos.Add("254", "254 - Paraná Banco S.A.")
                    Bancos.Add("263", "263 - Banco Cacique S.A.")
                    Bancos.Add("265", "265 - Banco Fator S.A.")
                    Bancos.Add("318", "318 - Banco BMG S.A.")
                    Bancos.Add("320", "320 - Banco Industrial e Comercial S.A.")
                    Bancos.Add("341", "341 - Itaú Unibanco S.A.")
                    Bancos.Add("356", "356 - Banco Real S.A.")
                    Bancos.Add("366", "366 - Banco Société Générale Brasil S.A.")
                    Bancos.Add("370", "370 - Banco Mizuho do Brasil S.A.")
                    Bancos.Add("376", "376 - Banco J. P. Morgan S.A.")
                    Bancos.Add("389", "389 - Banco Mercantil do Brasil S.A.")
                    Bancos.Add("394", "394 - Banco Bradesco Financiamentos S.A.")
                    Bancos.Add("399", "399 - HSBC Bank Brasil S.A. - Banco Múltiplo")
                    Bancos.Add("422", "422 - Banco Safra S.A.")
                    Bancos.Add("456", "456 - Banco de Tokyo-Mitsubishi UFJ Brasil S.A.")
                    Bancos.Add("464", "464 - Banco Sumitomo Mitsui Brasileiro S.A.")
                    Bancos.Add("473", "473 - Banco Caixa Geral - Brasil S.A.")
                    Bancos.Add("477", "477 - Citibank N.A.")
                    Bancos.Add("479", "479 - Banco ItaúBank S.A")
                    Bancos.Add("487", "487 - Deutsche Bank S.A. - Banco Alemão")
                    Bancos.Add("488", "488 - JPMorgan Chase Bank")
                    Bancos.Add("492", "492 - ING Bank N.V.")
                    Bancos.Add("505", "505 - Banco Credit Suisse (Brasil) S.A.")
                    Bancos.Add("600", "600 - Banco Luso Brasileiro S.A.")
                    Bancos.Add("604", "604 - Banco Industrial do Brasil S.A.")
                    Bancos.Add("610", "610 - Banco VR S.A.")
                    Bancos.Add("611", "611 - Banco Paulista S.A.")
                    Bancos.Add("612", "612 - Banco Guanabara S.A.")
                    Bancos.Add("623", "623 - Banco PAN S.A.")
                    Bancos.Add("626", "626 - Banco Ficsa S.A.")
                    Bancos.Add("633", "633 - Banco Rendimento S.A.")
                    Bancos.Add("634", "634 - Banco Triângulo S.A.")
                    Bancos.Add("641", "641 - Banco Alvorada S.A.")
                    Bancos.Add("643", "643 - Banco Pine S.A.")
                    Bancos.Add("652", "652 - Itaú Unibanco Holding S.A.")
                    Bancos.Add("653", "653 - Banco Indusval S.A.")
                    Bancos.Add("655", "655 - Banco Votorantim S.A.")
                    Bancos.Add("707", "707 - Banco Daycoval S.A.")
                    Bancos.Add("719", "719 - Banif-Banco Internacional do Funchal (Brasil)S.A.")
                    Bancos.Add("739", "739 - Banco Cetelem S.A.")
                    Bancos.Add("740", "740 - Banco Barclays S.A.")
                    Bancos.Add("745", "745 - Banco Citibank S.A.")
                    Bancos.Add("746", "746 - Banco Modal S.A.")
                    Bancos.Add("747", "747 - Banco Rabobank International Brasil S.A.")
                    Bancos.Add("748", "748 - Banco Cooperativo Sicredi S.A.")
                    Bancos.Add("751", "751 - Scotiabank Brasil S.A. Banco Múltiplo")
                    Bancos.Add("752", "752 - Banco BNP Paribas Brasil S.A.")
                    Bancos.Add("755", "755 - Bank of America Merrill Lynch Banco Múltiplo S.A.")
                    Bancos.Add("756", "756 - Banco Cooperativo do Brasil S.A. - BANCOOB")
                End SyncLock

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function NomeBanco(ByVal Numero As String) As String
        Try
            If Bancos Is Nothing Then
                CarregarBancos()
            End If

            If Bancos.ContainsKey(Numero) Then
                Return Bancos(Numero)
            End If
            Return Numero

        Catch ex As Exception
            Throw
        End Try
    End Function


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
    Public Function ToDateTimeConvert(ByVal Valor As String, Optional ByVal Formato As String = "ddMMyyyyHHmmss", Optional ByVal Retorno As Date = Nothing) As DateTime
        Try

            If Valor Is Nothing OrElse Valor.Length <> Formato.Length Then
                Return Retorno
            End If
            Dim Provider As CultureInfo = CultureInfo.InvariantCulture
            Return DateTime.ParseExact(Valor, Formato, Provider)

        Catch ex As Exception
            Return Retorno
        End Try
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
    Public Function ToDecimal100(ByVal Valor As String, Optional ByVal Retorno As Decimal = 0) As Decimal
        Dim conv As Boolean
        Dim v As Decimal
        conv = Decimal.TryParse(Valor, v)
        If conv Then
            Return v / 100
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

End Module
