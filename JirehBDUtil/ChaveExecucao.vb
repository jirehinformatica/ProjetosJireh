Imports System.Management

Public Class ChaveExecucao

    Private Const ConsultaDisco As String = "SELECT * FROM Win32_PhysicalMedia" '"SELECT * FROM Win32_DiskDrive"
    Private Localizar As ManagementObjectSearcher
    Private ListaValue As Dictionary(Of String, List(Of ItemInterface))
    Private Tx As MySQLTransacao

    Private Const NomeRegistro As String = "JirehSistema"

    Public Function SerialHDLocal() As String()
        Try

            Dim serial As New List(Of String)

            For i As Integer = 0 To ListaValue.Count - 1
                If ListaValue(ListaValue.Keys.ElementAt(i)).Count > 0 Then
                    serial.Add(ListaValue(ListaValue.Keys(i))(0).Valor)
                End If
            Next

            Return serial.ToArray

        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub New()
        Try
            Localizar = New ManagementObjectSearcher(ConsultaDisco)
            ListaValue = New Dictionary(Of String, List(Of ItemInterface))

            Dim novo As List(Of ItemInterface)
            Dim grp As String
            Dim item As ItemInterface

            For Each busca As ManagementObject In Localizar.Get

                Try
                    grp = busca("Name").ToString
                Catch ex As Exception
                    grp = busca.ToString
                End Try

                If busca.Properties.Count <= 0 Then
                    Exit Sub
                End If

                If ListaValue.ContainsKey(grp) Then
                    Continue For
                End If

                novo = New List(Of ItemInterface)

                For Each prop As PropertyData In busca.Properties

                    If prop.Name.ToLower = "serialnumber" Then 'prop.Name.ToLower = "name" OrElse 

                        item = New ItemInterface
                        item.Chave = prop.Name
                        If prop.Value IsNot Nothing AndAlso Not String.IsNullOrEmpty(prop.Value.ToString) Then
                            item.Valor = prop.Value.ToString
                        End If
                        novo.Add(item)
                    End If

                Next
                ListaValue.Add(grp, novo)

            Next

            RegistroLocal = New RegistroSistema(NomeRegistro)
            InformacoesUso = New InfoPC

            CarregarInfoRegistro()

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub CarregarInfoRegistro()
        Try
            If RegistroLocal.ExisteKey("Autorizados") Then
                InformacoesUso.Autorizados = DesCriptografar(RegistroLocal.GetValor("Autorizados").ToString)
            End If
            If RegistroLocal.ExisteKey("CNPJ") Then
                InformacoesUso.CNPJ = RegistroLocal.GetValor("CNPJ").ToString
            End If
            If RegistroLocal.ExisteKey("Data") Then
                InformacoesUso.Data = RegistroLocal.GetValor("Data").ToString.ToDate
            End If
            If RegistroLocal.ExisteKey("Empresa") Then
                InformacoesUso.Empresa = RegistroLocal.GetValor("Empresa").ToString
            End If
            If RegistroLocal.ExisteKey("Licencas") Then
                InformacoesUso.Licencas = RegistroLocal.GetValor("Licencas").ToString.ToInteger
            End If
            If RegistroLocal.ExisteKey("Serial") Then
                InformacoesUso.Serial = DesCriptografar(RegistroLocal.GetValor("Serial").ToString)
            End If
            If RegistroLocal.ExisteKey("Vencimento") Then
                InformacoesUso.Vencimento = RegistroLocal.GetValor("Vencimento").ToString.ToDate
            End If
            If RegistroLocal.ExisteKey("Estacao") Then
                InformacoesUso.Estacao = RegistroLocal.GetValor("Estacao").ToString.ToInteger
            End If
            If RegistroLocal.ExisteKey("CodigoSerial") Then
                InformacoesUso.CodigoSerial = RegistroLocal.GetValor("CodigoSerial").ToString.ToInteger
            End If

            Dim aux As String = String.Empty
            With InformacoesUso
                aux = GerarChave(.CNPJ, .Data, .Empresa, .Licencas, .Serial, .Vencimento, .Estacao, .CodigoSerial)
            End With

            If RegistroLocal.ExisteKey("Ativo") Then
                Dim verificar As String = RegistroLocal.GetValor("Ativo").ToString
                InformacoesUso.Ativo = EnCriptografar(aux) = verificar
                If InformacoesUso.Ativo Then

                    Try
                        Dim Ger As New Dal_MaquinasAtivasItens(CnMySQL, Tx)
                        InformacoesServidor = Ger.ConsultarParaRegistro(InformacoesUso.CNPJ, InformacoesUso.CodigoSerial)

                        Dim aux2 As String = String.Empty
                        With InformacoesServidor
                            aux2 = GerarChave(.Cnpj_emp, .Cadastro_mai, .RazaoSocial_emp, .Quantidade_maa, .Serial_ser, .Vencimento_emp, .Estacao_sem, .Codigo_ser)
                        End With

                        If Not InformacoesServidor.Ativo_emp OrElse Not InformacoesServidor.Ativou_mai OrElse aux <> aux2 Then
                            ChaveAtivacaoInvalidaValue = True
                            InformacoesUso.Ativo = False
                        End If

                    Catch ex As Exception
                        'Se ocorrer erro por falta da internet não deve bloquear o uso
                    End Try

                End If
            Else
                ChaveAtivacaoInvalidaValue = False
                InformacoesUso.Ativo = False
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private ChaveAtivacaoInvalidaValue As Boolean
    Public ReadOnly Property ChaveAtivacaoInvalida As Boolean
        Get
            Return ChaveAtivacaoInvalidaValue
        End Get
    End Property

    Private Function GerarChave(ByVal onCNPJ As String, ByVal onData As DateTime, ByVal onEmpresa As String, ByVal onLicencas As Integer, ByVal onSerial As String, ByVal onVencimento As DateTime, ByVal onEstacao As Integer, ByVal onCodigoSerial As Integer) As String
        Try
            Dim aux As String = String.Empty
            aux &= onCNPJ
            aux &= onData.ToString("ddMMyyyy")
            aux &= onEmpresa
            aux &= onLicencas.ToString
            aux &= onSerial
            aux &= onVencimento.ToString("ddMMyyyy")
            aux &= onEstacao.ToString("000")
            aux &= onCodigoSerial.ToString("0000000")

            Return aux

        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Sub GravarInfoRegistro(ByVal onAutorizados As String, ByVal onCNPJ As String, ByVal onData As DateTime, ByVal onEmpresa As String, ByVal onLicencas As Integer, ByVal onSerial As String, ByVal onVencimento As DateTime, ByVal onEstacao As Integer, ByVal onCodigoSerial As Integer)
        Try
            RegistroLocal.SetValor("Autorizados", EnCriptografar(onAutorizados))
            RegistroLocal.SetValor("CNPJ", onCNPJ)
            RegistroLocal.SetValor("Data", onData)
            RegistroLocal.SetValor("Empresa", onEmpresa)
            RegistroLocal.SetValor("Licencas", onLicencas)
            RegistroLocal.SetValor("Serial", EnCriptografar(onSerial))
            RegistroLocal.SetValor("Vencimento", onVencimento)
            RegistroLocal.SetValor("Estacao", onEstacao)
            RegistroLocal.SetValor("CodigoSerial", onCodigoSerial)

            Dim aux As String = GerarChave(onCNPJ, onData, onEmpresa, onLicencas, onSerial, onVencimento, onEstacao, onCodigoSerial)
            RegistroLocal.SetValor("Ativo", EnCriptografar(aux))

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub RegistrarPc(ByVal CNPJ As String, ByVal CodigoSerialHd As String, ByVal Data As DateTime)
        Try
            Tx = New MySQLTransacao(CnMySQL)

            Dim GerItensPc As New Dal_MaquinasAtivasItens(CnMySQL, Tx)

            CnMySQL.Open()
            Tx.BeginTransacao()

            Dim Item As Dal_MaquinasAtivasItens.MaquinasAtivasItensColunms = GerItensPc.Consultar(CNPJ, CodigoSerialHd)
            If Item IsNot Nothing Then
                GerItensPc.Excluir(CNPJ, CodigoSerialHd)
            Else
                Item = New Dal_MaquinasAtivasItens.MaquinasAtivasItensColunms
            End If
            Item.Ativou_mai = True
            Item.Cadastro_mai = Data
            Item.CnpjEmp_mai = CNPJ
            Item.CodigoSer_mai = CodigoSerialHd

            GerItensPc.Incluir(Item)

            InformacoesServidor = GerItensPc.ConsultarParaRegistro(CNPJ, CodigoSerialHd)

            With InformacoesServidor
                GravarInfoRegistro(.GetConveniosString, .Cnpj_emp, Data, .RazaoSocial_emp, .Quantidade_maa, .Serial_ser, .Vencimento_emp, .Estacao_sem, CodigoSerialHd)
            End With

            Tx.CommitTransacao()

            CarregarInfoRegistro()

        Catch ex As Exception
            Tx.RollBackTransacao()
            Throw
        Finally
            CnMySQL.Close()
        End Try
    End Sub

    Public Function ExisteSerial() As Boolean
        Try
            Dim achou As Boolean = False
            For Each i As String In InformacoesUso.Serial
                achou = ExisteSerial(i)
                If achou Then
                    Exit For
                End If
            Next
            Return achou
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function ExisteSerial(ByVal serial As String) As Boolean
        Try
            Dim series() As String = SerialHDLocal()
            Dim achou As Boolean = False
            For Each i As String In series
                If serial = i Then
                    achou = True
                    Exit For
                End If
            Next

            Return achou
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Property InformacoesUso As InfoPC
    Public Property InformacoesServidor As Dal_MaquinasAtivasItens.MaquinasRegistroColunms
    Public Property RegistroLocal As RegistroSistema

    Public Class ItemInterface
        Public Property Chave As String
        Public Property Valor As String
    End Class

End Class
