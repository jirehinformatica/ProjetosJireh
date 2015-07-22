Imports MySql.Data.MySqlClient

Public Class Dal_SerialHd

    Private TransacaoValue As MySQLTransacao
    Private Conexao As MySQL

    Public Sub New(ByVal Cn As MySQL, Optional ByVal Tx As MySQLTransacao = Nothing)
        Try
            TransacaoValue = IIf(Tx Is Nothing, New MySQLTransacao(Cn), Tx)
            Conexao = Cn
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Shared ReadOnly Property TableName As String
        Get
            Return "serialhd"
        End Get
    End Property

    Public ReadOnly Property Transacao As MySQLTransacao
        Get
            Return TransacaoValue
        End Get
    End Property

    Public Class SerialHDColunms
        Public Property Serial_ser As String
        Public Property Codigo_ser As Integer
    End Class

    Public MustInherit Class SerialHDColunmsName
        Private Sub New()
        End Sub
        Public Const Serial_ser As String = "Serial_ser"
        Public Const Codigo_ser As String = "Codigo_ser"
    End Class

    Public Sub Inserir(ByVal NumeroSerial As String)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim valor As Integer = Consultar(NumeroSerial)

            If valor > 0 Then
                Exit Sub
            End If

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("INSERT INTO {0}(", TableName)
            Sintaxe.AppendFormat("{0}) ", SerialHDColunmsName.Serial_ser)

            Sintaxe.AppendFormat("VALUES(@{0}) ", SerialHDColunmsName.Serial_ser)
            Parametros.Add(SerialHDColunmsName.Serial_ser, NumeroSerial, MySqlDbType.VarChar)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Function Consultar(ByVal NumeroSerial As String) As Integer
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Dim Row As DataRow
            Sintaxe.AppendFormat("SELECT * FROM {0} ", TableName)
            Sintaxe.AppendFormat("WHERE {0} = @{0} ", SerialHDColunmsName.Serial_ser)
            Parametros.Add(SerialHDColunmsName.Serial_ser, NumeroSerial, MySqlDbType.VarChar)

            Row = Conexao.FillRow(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()

            If Row IsNot Nothing Then
                Return Row(SerialHDColunmsName.Codigo_ser).ToString.ToInteger
            Else
                Return 0
            End If

        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Function

    Public Function ConsultarEmpresa(ByVal NumeroSerial As String, ByVal CNPJ As String) As SerialHDEmpresaColunms
        Try
            Dim Lista As List(Of SerialHDEmpresaColunms) = ConsultarEmpresa(NumeroSerial)

            Dim novo As SerialHDEmpresaColunms = (From i In Lista Where i.Cnpj_emp = CNPJ).FirstOrDefault

            If novo Is Nothing Then
                Return New SerialHDEmpresaColunms
            Else
                Return novo
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ConsultarEmpresa(ByVal NumeroSerial As String) As List(Of SerialHDEmpresaColunms)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Dim Tabela As DataTable
            Sintaxe.AppendFormat("SELECT * FROM {0} ", TableName)
            Sintaxe.AppendFormat("INNER JOIN {0} ", Dal_SerialEmpresas.TableName)
            Sintaxe.AppendFormat("ON {0}.{1} = {2}.{3} ", TableName, SerialHDColunmsName.Codigo_ser, Dal_SerialEmpresas.TableName, Dal_SerialEmpresas.SerialEmpresasColunmsName.CodigoSer_sem)
            Sintaxe.AppendFormat("LEFT JOIN {0} ", Dal_Empresas.TableName)
            Sintaxe.AppendFormat("ON {0}.{1} = {2}.{3} ", Dal_SerialEmpresas.TableName, Dal_SerialEmpresas.SerialEmpresasColunmsName.CnpjEmp_sem, Dal_Empresas.TableName, Dal_Empresas.EmpresasColunmsName.Cnpj_emp)
            Sintaxe.AppendFormat("LEFT JOIN {0} ", Dal_MaquinasAtivasItens.TableName)
            Sintaxe.AppendFormat("ON {0}.{1} = {2}.{3} ", Dal_SerialEmpresas.TableName, Dal_SerialEmpresas.SerialEmpresasColunmsName.CodigoSer_sem, Dal_MaquinasAtivasItens.TableName, Dal_MaquinasAtivasItens.MaquinasAtivasItensColunmsName.CodigoSer_mai)
            Sintaxe.AppendFormat("WHERE {1}.{0} = @{0} ", SerialHDColunmsName.Serial_ser, TableName)
            Parametros.Add(SerialHDColunmsName.Serial_ser, NumeroSerial, MySqlDbType.VarChar)

            Tabela = Conexao.FillTable(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()

            If Tabela IsNot Nothing Then

                Dim Novo As List(Of SerialHDEmpresaColunms) = (From i In Tabela.AsEnumerable Select _
                            New SerialHDEmpresaColunms With { _
                                .Ativo_emp = i.Field(Of Boolean)(Dal_Empresas.EmpresasColunmsName.Ativo_emp).ToBool,
                                .Cadastro_emp = i.Field(Of DateTime)(Dal_Empresas.EmpresasColunmsName.Cadastro_emp).ToDate,
                                .Cnpj_emp = i.Field(Of String)(Dal_Empresas.EmpresasColunmsName.Cnpj_emp).ToString,
                                .Fantasia_emp = i.Field(Of String)(Dal_Empresas.EmpresasColunmsName.Fantasia_emp).ToString,
                                .RazaoSocial_emp = i.Field(Of String)(Dal_Empresas.EmpresasColunmsName.RazaoSocial_emp).ToString,
                                .Vencimento_emp = i.Field(Of DateTime)(Dal_Empresas.EmpresasColunmsName.Vencimento_emp).ToDate
                            }).Distinct.ToList

                If Novo IsNot Nothing Then

                    For Each emp As SerialHDEmpresaColunms In Novo

                        Dim query = (From i In Tabela.AsEnumerable Where i.Field(Of String)(Dal_Empresas.EmpresasColunmsName.Cnpj_emp).ToString = emp.Cnpj_emp Select _
                                          New Dal_SerialEmpresas.SerialEmpresasColunms With { _
                                            .CnpjEmp_sem = i.Field(Of String)(Dal_SerialEmpresas.SerialEmpresasColunmsName.CnpjEmp_sem).ToString,
                                            .CodigoSer_sem = i.Field(Of Nullable(Of Integer))(Dal_SerialEmpresas.SerialEmpresasColunmsName.CodigoSer_sem).ToInteger,
                                            .Estacao_sem = i.Field(Of Nullable(Of Integer))(Dal_SerialEmpresas.SerialEmpresasColunmsName.Estacao_sem).ToInteger
                                          }).Distinct.ToList

                        If query IsNot Nothing Then
                            emp.SerialCadastrados = query
                        End If

                        Dim query2 = (From i In Tabela.AsEnumerable Where i.Field(Of String)(Dal_Empresas.EmpresasColunmsName.Cnpj_emp).ToString = emp.Cnpj_emp AndAlso _
                                           i.Field(Of Nullable(Of Integer))(Dal_MaquinasAtivasItens.MaquinasAtivasItensColunmsName.CodigoSer_mai).ToInteger <> 0 AndAlso _
                                           i.Field(Of Nullable(Of Boolean))(Dal_MaquinasAtivasItens.MaquinasAtivasItensColunmsName.Ativou_mai).ToBool Select _
                                           New Dal_MaquinasAtivasItens.MaquinasAtivasItensColunms With { _
                                            .Cadastro_mai = i.Field(Of Nullable(Of DateTime))(Dal_MaquinasAtivasItens.MaquinasAtivasItensColunmsName.Cadastro_mai).ToDate,
                                            .CnpjEmp_mai = i.Field(Of String)(Dal_MaquinasAtivasItens.MaquinasAtivasItensColunmsName.CnpjEmp_mai).ToString,
                                            .CodigoSer_mai = i.Field(Of Nullable(Of Integer))(Dal_MaquinasAtivasItens.MaquinasAtivasItensColunmsName.CodigoSer_mai).ToInteger,
                                            .Ativou_mai = i.Field(Of Nullable(Of Boolean))(Dal_MaquinasAtivasItens.MaquinasAtivasItensColunmsName.Ativou_mai).ToBool
                                           }).FirstOrDefault

                        If query2 IsNot Nothing Then
                            emp.SerialAtivo = query2
                        End If

                    Next

                    Return Novo
                End If

            End If

            Return New List(Of SerialHDEmpresaColunms)
        Catch ex As Exception
            Transacao.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Function

    Public Class SerialHDEmpresaColunms
        Inherits Dal_Empresas.EmpresasColunms

        Public Property SerialCadastrados As List(Of Dal_SerialEmpresas.SerialEmpresasColunms)
        Public Property SerialAtivo As Dal_MaquinasAtivasItens.MaquinasAtivasItensColunms

        Protected Friend Sub New()
            SerialCadastrados = New List(Of Dal_SerialEmpresas.SerialEmpresasColunms)
            SerialAtivo = New Dal_MaquinasAtivasItens.MaquinasAtivasItensColunms
        End Sub

    End Class

End Class
