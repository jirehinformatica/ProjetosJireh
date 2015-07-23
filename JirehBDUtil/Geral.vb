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

End Module

