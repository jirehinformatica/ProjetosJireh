Imports MySql.Data.MySqlClient

Public Class Dal_MaquinasAtivasItens

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
            Return "maquinasativasitens"
        End Get
    End Property

    Public ReadOnly Property Transacao As MySQLTransacao
        Get
            Return TransacaoValue
        End Get
    End Property

    Public Class MaquinasAtivasItensColunms
        Public Property CnpjEmp_mai As String
        Public Property CodigoSer_mai As Integer
        Public Property Cadastro_mai As DateTime
        Public Property Ativou_mai As Boolean
    End Class

    Public MustInherit Class MaquinasAtivasItensColunmsName
        Private Sub New()
        End Sub
        Public Const CnpjEmp_mai As String = "CnpjEmp_mai"
        Public Const CodigoSer_mai As String = "CodigoSer_mai"
        Public Const Cadastro_mai As String = "Cadastro_mai"
        Public Const Ativou_mai As String = "Ativou_mai"
    End Class

    Public Sub Incluir(ByVal Item As MaquinasAtivasItensColunms)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("INSERT INTO {0}(", TableName)
            Sintaxe.AppendFormat("{0}, ", MaquinasAtivasItensColunmsName.Ativou_mai)
            Sintaxe.AppendFormat("{0}, ", MaquinasAtivasItensColunmsName.Cadastro_mai)
            Sintaxe.AppendFormat("{0}, ", MaquinasAtivasItensColunmsName.CnpjEmp_mai)
            Sintaxe.AppendFormat("{0}) ", MaquinasAtivasItensColunmsName.CodigoSer_mai)

            Sintaxe.AppendFormat("VALUES(@{0}, ", MaquinasAtivasItensColunmsName.Ativou_mai)
            Parametros.Add(MaquinasAtivasItensColunmsName.Ativou_mai, Item.Ativou_mai, MySqlDbType.Bit)
            Sintaxe.AppendFormat("@{0}, ", MaquinasAtivasItensColunmsName.Cadastro_mai)
            Parametros.Add(MaquinasAtivasItensColunmsName.Cadastro_mai, Item.Cadastro_mai, MySqlDbType.DateTime)
            Sintaxe.AppendFormat("@{0}, ", MaquinasAtivasItensColunmsName.CnpjEmp_mai)
            Parametros.Add(MaquinasAtivasItensColunmsName.CnpjEmp_mai, Item.CnpjEmp_mai, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("@{0}) ", MaquinasAtivasItensColunmsName.CodigoSer_mai)
            Parametros.Add(MaquinasAtivasItensColunmsName.CodigoSer_mai, Item.CodigoSer_mai, MySqlDbType.Int32)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Sub Alterar(ByVal Item As MaquinasAtivasItensColunms)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("UPDATE {0} SET ", TableName)
            Sintaxe.AppendFormat("{0} = @{0}, ", MaquinasAtivasItensColunmsName.Ativou_mai)
            Parametros.Add(MaquinasAtivasItensColunmsName.Ativou_mai, Item.Ativou_mai, MySqlDbType.Bit)
            Sintaxe.AppendFormat("{0} = @{0} ", MaquinasAtivasItensColunmsName.Cadastro_mai)
            Parametros.Add(MaquinasAtivasItensColunmsName.Cadastro_mai, Item.Cadastro_mai, MySqlDbType.DateTime)

            Sintaxe.AppendFormat("WHERE {0} = @{0} ", MaquinasAtivasItensColunmsName.CnpjEmp_mai)
            Parametros.Add(MaquinasAtivasItensColunmsName.CnpjEmp_mai, Item.CnpjEmp_mai, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("AND {0} = @{0} ", MaquinasAtivasItensColunmsName.CodigoSer_mai)
            Parametros.Add(MaquinasAtivasItensColunmsName.CodigoSer_mai, Item.CodigoSer_mai, MySqlDbType.Int32)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Sub Excluir(ByVal Cnpj As String, ByVal CodigoSerial As Integer)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("DELETE FROM {0} ", TableName)
            Sintaxe.AppendFormat("WHERE {0} = @{0} ", MaquinasAtivasItensColunmsName.CnpjEmp_mai)
            Parametros.Add(MaquinasAtivasItensColunmsName.CnpjEmp_mai, Cnpj, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("AND {0} = @{0} ", MaquinasAtivasItensColunmsName.CodigoSer_mai)
            Parametros.Add(MaquinasAtivasItensColunmsName.CodigoSer_mai, CodigoSerial, MySqlDbType.Int32)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Sub Excluir(ByVal Cnpj As String)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("DELETE FROM {0} ", TableName)
            Sintaxe.AppendFormat("WHERE {0} = @{0} ", MaquinasAtivasItensColunmsName.CnpjEmp_mai)
            Parametros.Add(MaquinasAtivasItensColunmsName.CnpjEmp_mai, Cnpj, MySqlDbType.VarChar)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Function Consultar(ByVal Cnpj As String, ByVal CodigoSerial As Integer) As MaquinasAtivasItensColunms
        Try
            Dim Parametros As New MySQLParametros
            Dim Tabela As DataTable

            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("SELECT * FROM {0} ", TableName)
            Sintaxe.AppendFormat("WHERE {0} = @{0} ", MaquinasAtivasItensColunmsName.CnpjEmp_mai)
            Parametros.Add(MaquinasAtivasItensColunmsName.CnpjEmp_mai, Cnpj, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("AND {0} = @{0} ", MaquinasAtivasItensColunmsName.CodigoSer_mai)
            Parametros.Add(MaquinasAtivasItensColunmsName.CodigoSer_mai, CodigoSerial, MySqlDbType.Int32)

            Tabela = Conexao.FillTable(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()

            If Tabela Is Nothing Then
                Return New MaquinasAtivasItensColunms
            End If

            Dim Dados As MaquinasAtivasItensColunms = (From i In Tabela.AsEnumerable Select New MaquinasAtivasItensColunms With {
                              .Ativou_mai = i.Field(Of Nullable(Of Boolean))(MaquinasAtivasItensColunmsName.Ativou_mai).ToBool,
                              .Cadastro_mai = i.Field(Of Nullable(Of DateTime))(MaquinasAtivasItensColunmsName.Cadastro_mai).ToDate,
                              .CnpjEmp_mai = i.Field(Of String)(MaquinasAtivasItensColunmsName.CnpjEmp_mai).ToString,
                              .CodigoSer_mai = i.Field(Of Nullable(Of Integer))(MaquinasAtivasItensColunmsName.CodigoSer_mai).ToInteger
                          }).FirstOrDefault

            If Dados Is Nothing Then
                Return New MaquinasAtivasItensColunms
            End If

            Return Dados

        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Function

    Public Function Consultar(ByVal Cnpj As String) As MaquinasAtivasEmpresasColunms
        Try
            Dim Parametros As New MySQLParametros
            Dim Tabela As DataTable

            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("SELECT * FROM {0} ", Dal_MaquinasAtivas.TableName)
            Sintaxe.AppendFormat("LEFT JOIN {0} ON {0}.{1} = {2}.{3} ", TableName, MaquinasAtivasItensColunmsName.CnpjEmp_mai, Dal_MaquinasAtivas.TableName, Dal_MaquinasAtivas.MaquinasAtivasColunmsName.CnpjEmp_maa)
            Sintaxe.AppendFormat("LEFT JOIN {0} ON {0}.{1} = {2}.{3} ", Dal_SerialHd.TableName, Dal_SerialHd.SerialHDColunmsName.Codigo_ser, TableName, MaquinasAtivasItensColunmsName.CodigoSer_mai)

            Sintaxe.AppendFormat("LEFT JOIN {0} ON {0}.{1} = {2}.{3} ", Dal_SerialEmpresas.TableName, Dal_SerialEmpresas.SerialEmpresasColunmsName.CodigoSer_sem, TableName, MaquinasAtivasItensColunmsName.CodigoSer_mai)
            Sintaxe.AppendFormat("      AND {0}.{1} = {2}.{3} ", Dal_SerialEmpresas.TableName, Dal_SerialEmpresas.SerialEmpresasColunmsName.CnpjEmp_sem, TableName, MaquinasAtivasItensColunmsName.CnpjEmp_mai)

            Sintaxe.AppendFormat("WHERE {1}.{0} = @{0} ", Dal_MaquinasAtivas.MaquinasAtivasColunmsName.CnpjEmp_maa, Dal_MaquinasAtivas.TableName)
            Parametros.Add(Dal_MaquinasAtivas.MaquinasAtivasColunmsName.CnpjEmp_maa, Cnpj, MySqlDbType.VarChar)

            Tabela = Conexao.FillTable(Sintaxe.ToString, Parametros, TransacaoValue)

            Sintaxe = New Text.StringBuilder
            Parametros = New MySQLParametros
            Sintaxe.AppendFormat("SELECT COUNT(*) AS `{1}` FROM {0} WHERE {1} = @{1} ", TableName, MaquinasAtivasItensColunmsName.CnpjEmp_mai)
            Parametros.Add(MaquinasAtivasItensColunmsName.CnpjEmp_mai, Cnpj, MySqlDbType.VarChar)

            Dim TemItens As Boolean = Conexao.ExecuteScalar(Sintaxe.ToString, Parametros, TransacaoValue).ToString.ToInteger > 0

            TransacaoValue.CommitTransacao()

            If Tabela Is Nothing OrElse Tabela.Rows.Count = 0 Then
                Return New MaquinasAtivasEmpresasColunms
            End If

            Dim Dados As MaquinasAtivasEmpresasColunms = (From i In Tabela.AsEnumerable Select New MaquinasAtivasEmpresasColunms With {
                              .CnpjEmp_maa = i.Field(Of String)(Dal_MaquinasAtivas.MaquinasAtivasColunmsName.CnpjEmp_maa).ToString,
                              .Quantidade_maa = i.Field(Of Nullable(Of Integer))(Dal_MaquinasAtivas.MaquinasAtivasColunmsName.Quantidade_maa).ToInteger
                          }).Distinct.FirstOrDefault

            If Dados IsNot Nothing AndAlso TemItens Then
                Dim Query2 As List(Of MaquinasAtivasItensSerialColunms) = (From i In Tabela.AsEnumerable Select New MaquinasAtivasItensSerialColunms With {
                            .Ativou_mai = i.Field(Of Nullable(Of Boolean))(MaquinasAtivasItensColunmsName.Ativou_mai).ToBool,
                            .Cadastro_mai = i.Field(Of Nullable(Of DateTime))(MaquinasAtivasItensColunmsName.Cadastro_mai).ToDate,
                            .CnpjEmp_mai = i.Field(Of String)(MaquinasAtivasItensColunmsName.CnpjEmp_mai).ToString,
                            .Serial_ser = i.Field(Of String)(Dal_SerialHd.SerialHDColunmsName.Serial_ser).ToString,
                            .CodigoSer_mai = i.Field(Of Nullable(Of Integer))(MaquinasAtivasItensColunmsName.CodigoSer_mai).ToInteger,
                            .Estacao_sem = i.Field(Of Nullable(Of Integer))(Dal_SerialEmpresas.SerialEmpresasColunmsName.Estacao_sem).ToInteger
                    }).Distinct.ToList

                If Query2 IsNot Nothing Then
                    Dados.Maquinas = Query2
                End If
            End If

            If Dados Is Nothing Then
                Return New MaquinasAtivasEmpresasColunms
            End If

            Return Dados

        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Function

    Public Class MaquinasAtivasEmpresasColunms
        Inherits Dal_MaquinasAtivas.MaquinasAtivasColunms

        Public Property Maquinas As List(Of MaquinasAtivasItensSerialColunms)

        Public Function ConsultarSerial(ByVal Valor As String) As MaquinasAtivasItensSerialColunms
            Try
                If Maquinas Is Nothing OrElse Maquinas.Count = 0 Then
                    Return Nothing
                End If

                Dim info As MaquinasAtivasItensSerialColunms = (From i In Maquinas.AsEnumerable Where i.Serial_ser = Valor).FirstOrDefault
                Return info

            Catch ex As Exception
                Throw
            End Try
        End Function

        Protected Friend Sub New()
            Maquinas = New List(Of MaquinasAtivasItensSerialColunms)
        End Sub

    End Class

    Public Class MaquinasAtivasItensSerialColunms
        Inherits MaquinasAtivasItensColunms

        Public Property Serial_ser As String
        Public Property Estacao_sem As Integer

        Protected Friend Sub New()

        End Sub

    End Class


    Public Function ConsultarParaRegistro(ByVal Cnpj As String, ByVal CodigoSerial As Integer) As MaquinasRegistroColunms
        Try
            Dim Parametros As New MySQLParametros
            Dim Tabela As DataTable

            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("SELECT * FROM {0} ", TableName)
            Sintaxe.AppendFormat("INNER JOIN {0} ON {0}.{1} = {2}.{3} ", Dal_Empresas.TableName, Dal_Empresas.EmpresasColunmsName.Cnpj_emp, TableName, MaquinasAtivasItensColunmsName.CnpjEmp_mai)
            Sintaxe.AppendFormat("INNER JOIN {0} ON {0}.{1} = {2}.{3} ", Dal_SerialEmpresas.TableName, Dal_SerialEmpresas.SerialEmpresasColunmsName.CnpjEmp_sem, TableName, MaquinasAtivasItensColunmsName.CnpjEmp_mai)
            Sintaxe.AppendFormat("AND {0}.{1} = {2}.{3} ", Dal_SerialEmpresas.TableName, Dal_SerialEmpresas.SerialEmpresasColunmsName.CodigoSer_sem, TableName, MaquinasAtivasItensColunmsName.CodigoSer_mai)
            Sintaxe.AppendFormat("INNER JOIN {0} ON {0}.{1} = {2}.{3} ", Dal_SerialHd.TableName, Dal_SerialHd.SerialHDColunmsName.Codigo_ser, TableName, MaquinasAtivasItensColunmsName.CodigoSer_mai)
            Sintaxe.AppendFormat("INNER JOIN {0} ON {0}.{1} = {2}.{3} ", Dal_MaquinasAtivas.TableName, Dal_MaquinasAtivas.MaquinasAtivasColunmsName.CnpjEmp_maa, TableName, MaquinasAtivasItensColunmsName.CnpjEmp_mai)
            Sintaxe.AppendFormat("LEFT JOIN {0} ON {0}.{1} = {2}.{3} ", Dal_ConveniosEmpresa.TableName, Dal_ConveniosEmpresa.ConveniosEmpresaColunmsName.CnpjEmp_eco, TableName, MaquinasAtivasItensColunmsName.CnpjEmp_mai)

            Sintaxe.AppendFormat("WHERE {1}.{0} = @{0} ", MaquinasAtivasItensColunmsName.CnpjEmp_mai, TableName)
            Parametros.Add(MaquinasAtivasItensColunmsName.CnpjEmp_mai, Cnpj, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("AND {1}.{0} = @{0} ", MaquinasAtivasItensColunmsName.CodigoSer_mai, TableName)
            Parametros.Add(MaquinasAtivasItensColunmsName.CodigoSer_mai, CodigoSerial, MySqlDbType.Int32)


            Tabela = Conexao.FillTable(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()

            If Tabela Is Nothing OrElse Tabela.Rows.Count = 0 Then
                Return New MaquinasRegistroColunms
            End If

            Dim Novo As MaquinasRegistroColunms = (From i In Tabela.AsEnumerable Select New MaquinasRegistroColunms With { _
                              .Ativo_emp = i.Field(Of Nullable(Of Boolean))(Dal_Empresas.EmpresasColunmsName.Ativo_emp).ToBool,
                              .Ativou_mai = i.Field(Of Nullable(Of Boolean))(MaquinasAtivasItensColunmsName.Ativou_mai).ToBool,
                              .Cadastro_emp = i.Field(Of Nullable(Of DateTime))(Dal_Empresas.EmpresasColunmsName.Cadastro_emp).ToDate,
                              .Cnpj_emp = i.Field(Of String)(Dal_Empresas.EmpresasColunmsName.Cnpj_emp).ToString,
                              .Estacao_sem = i.Field(Of Nullable(Of Integer))(Dal_SerialEmpresas.SerialEmpresasColunmsName.Estacao_sem).ToInteger,
                              .Codigo_ser = i.Field(Of Nullable(Of Integer))(Dal_SerialHd.SerialHDColunmsName.Codigo_ser).ToInteger,
                              .Fantasia_emp = i.Field(Of String)(Dal_Empresas.EmpresasColunmsName.Fantasia_emp).ToString,
                              .Quantidade_maa = i.Field(Of Nullable(Of Integer))(Dal_MaquinasAtivas.MaquinasAtivasColunmsName.Quantidade_maa).ToInteger,
                              .RazaoSocial_emp = i.Field(Of String)(Dal_Empresas.EmpresasColunmsName.RazaoSocial_emp).ToString,
                              .Serial_ser = i.Field(Of String)(Dal_SerialHd.SerialHDColunmsName.Serial_ser).ToString,
                              .Vencimento_emp = i.Field(Of Nullable(Of DateTime))(Dal_Empresas.EmpresasColunmsName.Vencimento_emp).ToDate,
                              .Cadastro_mai = i.Field(Of Nullable(Of DateTime))(Dal_MaquinasAtivasItens.MaquinasAtivasItensColunmsName.Cadastro_mai).ToDate
                          }).Distinct.FirstOrDefault

            If Novo IsNot Nothing AndAlso Not String.IsNullOrEmpty(Novo.Cnpj_emp) Then
                Try
                    Dim Query2 As List(Of Dal_ConveniosEmpresa.ConveniosEmpresaColunms) = (From i In Tabela.AsEnumerable Select New Dal_ConveniosEmpresa.ConveniosEmpresaColunms With { _
                              .Ativo_eco = i.Field(Of Nullable(Of Boolean))(Dal_ConveniosEmpresa.ConveniosEmpresaColunmsName.Ativo_eco).ToBool,
                              .CnpjEmp_eco = i.Field(Of String)(Dal_ConveniosEmpresa.ConveniosEmpresaColunmsName.CnpjEmp_eco).ToString,
                              .Convenio_eco = i.Field(Of String)(Dal_ConveniosEmpresa.ConveniosEmpresaColunmsName.Convenio_eco).ToString
                          }).Distinct.ToList

                    If Query2 IsNot Nothing Then
                        Novo.Convenio_eco = Query2
                    End If

                Catch ex As Exception
                    'Não existe nenhum item de convevio
                End Try
            End If

            If Novo Is Nothing Then
                Return New MaquinasRegistroColunms
            End If

            Return Novo

        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Function

    Public Class MaquinasRegistroColunms
        Inherits Dal_Empresas.EmpresasColunms

        Public Property Serial_ser As String
        Public Property Codigo_ser As Integer
        Public Property Quantidade_maa As Integer
        Public Property Estacao_sem As Integer
        Public Property Ativou_mai As Boolean
        ''' <summary>
        ''' Data em que foi feito a ativação
        ''' </summary>
        Public Property Cadastro_mai As DateTime

        Public Property Convenio_eco As List(Of Dal_ConveniosEmpresa.ConveniosEmpresaColunms)
        Public Function GetConveniosString() As String
            Try
                Dim Convenios As String = ""
                Dim aux As String = ""
                If Convenio_eco IsNot Nothing AndAlso Convenio_eco.Count > 0 Then
                    For Each i As Dal_ConveniosEmpresa.ConveniosEmpresaColunms In Convenio_eco
                        If i.Ativo_eco Then
                            Convenios &= aux & i.Convenio_eco.Trim
                            aux = ";"
                        End If
                    Next
                End If

                Return Convenios
            Catch ex As Exception
                Throw
            End Try
        End Function

        Protected Friend Sub New()
            Convenio_eco = New List(Of Dal_ConveniosEmpresa.ConveniosEmpresaColunms)
        End Sub

    End Class

End Class
