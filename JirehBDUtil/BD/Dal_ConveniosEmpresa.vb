Imports MySql.Data.MySqlClient

Public Class Dal_ConveniosEmpresa

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
            Return "conveniosempresa"
        End Get
    End Property

    Public ReadOnly Property Transacao As MySQLTransacao
        Get
            Return TransacaoValue
        End Get
    End Property

    Public Class ConveniosEmpresaColunms
        Public Property CnpjEmp_eco As String
        Public Property Convenio_eco As String
        Public Property Ativo_eco As Boolean
    End Class

    Public MustInherit Class ConveniosEmpresaColunmsName
        Private Sub New()
        End Sub
        Public Const CnpjEmp_eco As String = "CnpjEmp_eco"
        Public Const Convenio_eco As String = "Convenio_eco"
        Public Const Ativo_eco As String = "Ativo_eco"
    End Class

    Public Sub Incluir(ByVal Item As ConveniosEmpresaColunms)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("INSERT INTO {0}(", TableName)
            Sintaxe.AppendFormat("{0}, ", ConveniosEmpresaColunmsName.CnpjEmp_eco)
            Sintaxe.AppendFormat("{0}, ", ConveniosEmpresaColunmsName.Convenio_eco)
            Sintaxe.AppendFormat("{0}) ", ConveniosEmpresaColunmsName.Ativo_eco)

            Sintaxe.AppendFormat("VALUES(@{0}, ", ConveniosEmpresaColunmsName.CnpjEmp_eco)
            Parametros.Add(ConveniosEmpresaColunmsName.CnpjEmp_eco, Item.CnpjEmp_eco, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("@{0}, ", ConveniosEmpresaColunmsName.Convenio_eco)
            Parametros.Add(ConveniosEmpresaColunmsName.Convenio_eco, Item.Convenio_eco, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("@{0}) ", ConveniosEmpresaColunmsName.Ativo_eco)
            Parametros.Add(ConveniosEmpresaColunmsName.Ativo_eco, Item.Ativo_eco, MySqlDbType.Bit)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Sub Alterar(ByVal Item As ConveniosEmpresaColunms)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("UPDATE {0} SET ", TableName)
            Sintaxe.AppendFormat("{0} = @{0} ", ConveniosEmpresaColunmsName.Ativo_eco)
            Parametros.Add(ConveniosEmpresaColunmsName.Ativo_eco, Item.Ativo_eco, MySqlDbType.Bit)

            Sintaxe.AppendFormat("WHERE {0} = @{0} ", ConveniosEmpresaColunmsName.CnpjEmp_eco)
            Parametros.Add(ConveniosEmpresaColunmsName.CnpjEmp_eco, Item.CnpjEmp_eco, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("AND {0} = @{0} ", ConveniosEmpresaColunmsName.Convenio_eco)
            Parametros.Add(ConveniosEmpresaColunmsName.Convenio_eco, Item.Convenio_eco, MySqlDbType.VarChar)

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
            Sintaxe.AppendFormat("WHERE {0} = @{0} ", ConveniosEmpresaColunmsName.CnpjEmp_eco)
            Parametros.Add(ConveniosEmpresaColunmsName.CnpjEmp_eco, Cnpj, MySqlDbType.VarChar)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Sub Excluir(ByVal Item As ConveniosEmpresaColunms)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("DELETE FROM {0} ", TableName)
            Sintaxe.AppendFormat("WHERE {0} = @{0} ", ConveniosEmpresaColunmsName.CnpjEmp_eco)
            Parametros.Add(ConveniosEmpresaColunmsName.CnpjEmp_eco, Item.CnpjEmp_eco, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("AND {0} = @{0} ", ConveniosEmpresaColunmsName.Convenio_eco)
            Parametros.Add(ConveniosEmpresaColunmsName.Convenio_eco, Item.Convenio_eco, MySqlDbType.VarChar)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Function Consultar(ByVal Cnpj As String, ByVal Convenio As String) As ConveniosEmpresaColunms
        Try
            Dim Lista As List(Of ConveniosEmpresaColunms) = Consultar(Cnpj)
            Dim Item As ConveniosEmpresaColunms = (From i In Lista.AsEnumerable Where i.Convenio_eco = Convenio).FirstOrDefault
            Return Item
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function Consultar(ByVal Cnpj As String) As List(Of ConveniosEmpresaColunms)
        Try
            Dim Parametros As New MySQLParametros
            Dim Tabela As DataTable

            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("SELECT * FROM {0} ", TableName)
            Sintaxe.AppendFormat("WHERE {0} = @{0} ", ConveniosEmpresaColunmsName.CnpjEmp_eco)
            Parametros.Add(ConveniosEmpresaColunmsName.CnpjEmp_eco, Cnpj, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("ORDER BY {0} ", ConveniosEmpresaColunmsName.Convenio_eco)

            Tabela = Conexao.FillTable(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()

            If Tabela Is Nothing Then
                Return New List(Of ConveniosEmpresaColunms)
            End If

            Dim Dados As List(Of ConveniosEmpresaColunms) = (From i In Tabela.AsEnumerable Select New ConveniosEmpresaColunms With {
                              .Ativo_eco = i.Field(Of Nullable(Of Boolean))(ConveniosEmpresaColunmsName.Ativo_eco).ToBool,
                              .CnpjEmp_eco = i.Field(Of String)(ConveniosEmpresaColunmsName.CnpjEmp_eco).ToString,
                              .Convenio_eco = i.Field(Of String)(ConveniosEmpresaColunmsName.Convenio_eco).ToString
                          }).ToList

            If Dados Is Nothing Then
                Return New List(Of ConveniosEmpresaColunms)
            End If

            Return Dados

        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Function

End Class
