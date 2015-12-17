Imports MySql.Data.MySqlClient

Public Class Dal_Pessoas

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
            Return "pessoas"
        End Get
    End Property

    Public ReadOnly Property Transacao As MySQLTransacao
        Get
            Return TransacaoValue
        End Get
    End Property

    Public Class PessoasColunms
        Public Property CpfCnpj_pes As String
        Public Property CnpjEmp_pes As String
        Public Property NomeRazao_pes As String
        Public Property Cadastro_pes As DateTime
        Public Property Ativo_pes As Boolean
    End Class

    Public Class PessoasColunmsName
        Public Const CpfCnpj_pes As String = "CpfCnpj_pes"
        Public Const CnpjEmp_pes As String = "CnpjEmp_pes"
        Public Const NomeRazao_pes As String = "NomeRazao_pes"
        Public Const Cadastro_pes As String = "Cadastro_pes"
        Public Const Ativo_pes As String = "Ativo_pes"
    End Class

    Public Sub Inserir(ByVal Item As PessoasColunms)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("INSERT INTO {0}(", TableName)
            Sintaxe.AppendFormat("{0}, ", PessoasColunmsName.CnpjEmp_pes)
            Sintaxe.AppendFormat("{0}, ", PessoasColunmsName.CpfCnpj_pes)
            Sintaxe.AppendFormat("{0}, ", PessoasColunmsName.NomeRazao_pes)
            Sintaxe.AppendFormat("{0}, ", PessoasColunmsName.Cadastro_pes)
            Sintaxe.AppendFormat("{0}) ", PessoasColunmsName.Ativo_pes)

            Sintaxe.AppendFormat("VALUES(@{0}, ", PessoasColunmsName.CnpjEmp_pes)
            Parametros.Add(PessoasColunmsName.CnpjEmp_pes, Item.CnpjEmp_pes, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("@{0}, ", PessoasColunmsName.CpfCnpj_pes)
            Parametros.Add(PessoasColunmsName.CpfCnpj_pes, Item.CpfCnpj_pes, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("@{0}, ", PessoasColunmsName.NomeRazao_pes)
            Parametros.Add(PessoasColunmsName.NomeRazao_pes, Item.NomeRazao_pes, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("@{0}, ", PessoasColunmsName.Cadastro_pes)
            Parametros.Add(PessoasColunmsName.Cadastro_pes, Item.Cadastro_pes, MySqlDbType.DateTime)
            Sintaxe.AppendFormat("@{0})", PessoasColunmsName.Ativo_pes)
            Parametros.Add(PessoasColunmsName.Ativo_pes, Item.Ativo_pes, MySqlDbType.Bit)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Sub Excluir(ByVal EmpresaCNPJ As String, ByVal PessoaCpfCnpj As String)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("DELETE FROM {0} ", TableName)
            Sintaxe.AppendFormat("WHERE @{0} = @{0} ", PessoasColunmsName.CnpjEmp_pes)
            Parametros.Add(PessoasColunmsName.CnpjEmp_pes, EmpresaCNPJ, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("AND @{0} = @{0} ", PessoasColunmsName.CpfCnpj_pes)
            Parametros.Add(PessoasColunmsName.CpfCnpj_pes, PessoaCpfCnpj, MySqlDbType.VarChar)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Sub Alterar(ByVal Item As PessoasColunms)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("UPDATE {0} SET ", TableName)

            Sintaxe.AppendFormat("{0} = @{0}, ", PessoasColunmsName.Ativo_pes)
            Parametros.Add(PessoasColunmsName.Ativo_pes, Item.Ativo_pes, MySqlDbType.Bit)
            Sintaxe.AppendFormat("{0} = @{0}, ", PessoasColunmsName.Cadastro_pes)
            Parametros.Add(PessoasColunmsName.Cadastro_pes, Item.Cadastro_pes, MySqlDbType.DateTime)
            Sintaxe.AppendFormat("{0} = @{0} ", PessoasColunmsName.NomeRazao_pes)
            Parametros.Add(PessoasColunmsName.NomeRazao_pes, Item.NomeRazao_pes, MySqlDbType.VarChar)

            Sintaxe.AppendFormat("WHERE {0} = @{0} ", PessoasColunmsName.CnpjEmp_pes)
            Parametros.Add(PessoasColunmsName.CnpjEmp_pes, Item.CnpjEmp_pes, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("AND {0} = @{0} ", PessoasColunmsName.CpfCnpj_pes)
            Parametros.Add(PessoasColunmsName.CpfCnpj_pes, Item.CpfCnpj_pes, MySqlDbType.VarChar)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Function Consultar(ByVal EmpresaCNPJ As String, ByVal PessoaCpfCnpj As String) As PessoasColunms
        Try
            Dim Row As DataRow
            Dim Parametros As New MySQLParametros

            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("SELECT * FROM {0} ", TableName)
            Parametros.Add(PessoasColunmsName.CnpjEmp_pes, EmpresaCNPJ, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("WHERE {0} = @{0} ", PessoasColunmsName.CnpjEmp_pes)
            Parametros.Add(PessoasColunmsName.CpfCnpj_pes, PessoaCpfCnpj, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("AND {0} = @{0} ", PessoasColunmsName.CpfCnpj_pes)

            Row = Conexao.FillRow(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()

            Dim item As New PessoasColunms
            If Row IsNot Nothing Then
                item.Ativo_pes = Row(PessoasColunmsName.Ativo_pes).ToString.ToBool
                item.Cadastro_pes = Row(PessoasColunmsName.Cadastro_pes).ToString.ToDate
                item.CnpjEmp_pes = Row(PessoasColunmsName.CnpjEmp_pes).ToString
                item.CpfCnpj_pes = Row(PessoasColunmsName.CpfCnpj_pes).ToString
                item.NomeRazao_pes = Row(PessoasColunmsName.NomeRazao_pes).ToString
            End If

            Return item
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Function

    Public Function Consultar(ByVal EmpresaCNPJ As String) As List(Of PessoasColunms)
        Try
            Dim Tabela As DataTable
            Dim Parametros As New MySQLParametros

            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("SELECT * FROM {0} ", TableName)
            Parametros.Add(PessoasColunmsName.CnpjEmp_pes, EmpresaCNPJ, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("WHERE {0} = @{0} ", PessoasColunmsName.CnpjEmp_pes)

            Tabela = Conexao.FillTable(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()

            Dim itens As New List(Of PessoasColunms)
            If Tabela.Rows.Count > 0 Then
                itens = (From i In Tabela.AsEnumerable Select New PessoasColunms With {
                       .Ativo_pes = i.Field(Of Boolean)(PessoasColunmsName.Ativo_pes).ToBool,
                       .Cadastro_pes = i.Field(Of DateTime)(PessoasColunmsName.Cadastro_pes).ToDate,
                       .CnpjEmp_pes = i.Field(Of String)(PessoasColunmsName.CnpjEmp_pes).ToStr,
                       .CpfCnpj_pes = i.Field(Of String)(PessoasColunmsName.CpfCnpj_pes).ToStr,
                       .NomeRazao_pes = i.Field(Of String)(PessoasColunmsName.NomeRazao_pes).ToStr
                       }).ToList
            End If

            Return itens
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Function

    Public Function ConsultarTable(ByVal EmpresaCNPJ As String) As DataTable
        Try
            Dim Tabela As DataTable
            Dim Parametros As New MySQLParametros

            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("SELECT * FROM {0} ", TableName)
            Parametros.Add(PessoasColunmsName.CnpjEmp_pes, EmpresaCNPJ, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("WHERE {0} = @{0} ", PessoasColunmsName.CnpjEmp_pes)

            Tabela = Conexao.FillTable(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()

            Return Tabela
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Function

End Class
