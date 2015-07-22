Imports MySql.Data.MySqlClient

Public Class Dal_Empresas

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
            Return "empresas"
        End Get
    End Property

    Public ReadOnly Property Transacao As MySQLTransacao
        Get
            Return TransacaoValue
        End Get
    End Property

    Public Class EmpresasColunms
        Public Property Cnpj_emp As String
        Public Property RazaoSocial_emp As String
        Public Property Fantasia_emp As String
        Public Property Cadastro_emp As DateTime
        Public Property Vencimento_emp As DateTime
        Public Property Ativo_emp As Boolean
    End Class

    Public MustInherit Class EmpresasColunmsName
        Private Sub New()
        End Sub
        Public Const Cnpj_emp As String = "Cnpj_emp"
        Public Const RazaoSocial_emp As String = "RazaoSocial_emp"
        Public Const Fantasia_emp As String = "Fantasia_emp"
        Public Const Cadastro_emp As String = "Cadastro_emp"
        Public Const Vencimento_emp As String = "Vencimento_emp"
        Public Const Ativo_emp As String = "Ativo_emp"
    End Class

    Public Sub Inserir(ByVal Item As EmpresasColunms)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("INSERT INTO {0}(", TableName)
            Sintaxe.AppendFormat("{0}, ", EmpresasColunmsName.Ativo_emp)
            Sintaxe.AppendFormat("{0}, ", EmpresasColunmsName.Cadastro_emp)
            Sintaxe.AppendFormat("{0}, ", EmpresasColunmsName.Cnpj_emp)
            Sintaxe.AppendFormat("{0}, ", EmpresasColunmsName.Fantasia_emp)
            Sintaxe.AppendFormat("{0}, ", EmpresasColunmsName.RazaoSocial_emp)
            Sintaxe.AppendFormat("{0}) ", EmpresasColunmsName.Vencimento_emp)

            Sintaxe.AppendFormat("VALUES(@{0}, ", EmpresasColunmsName.Ativo_emp)
            Parametros.Add(EmpresasColunmsName.Ativo_emp, Item.Ativo_emp, MySqlDbType.Bit)
            Sintaxe.AppendFormat("@{0},", EmpresasColunmsName.Cadastro_emp)
            Parametros.Add(EmpresasColunmsName.Cadastro_emp, Item.Cadastro_emp, MySqlDbType.DateTime)
            Sintaxe.AppendFormat("@{0},", EmpresasColunmsName.Cnpj_emp)
            Parametros.Add(EmpresasColunmsName.Cnpj_emp, Item.Cnpj_emp, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("@{0},", EmpresasColunmsName.Fantasia_emp)
            Parametros.Add(EmpresasColunmsName.Fantasia_emp, Item.Fantasia_emp, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("@{0},", EmpresasColunmsName.RazaoSocial_emp)
            Parametros.Add(EmpresasColunmsName.RazaoSocial_emp, Item.RazaoSocial_emp, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("@{0})", EmpresasColunmsName.Vencimento_emp)
            Parametros.Add(EmpresasColunmsName.Vencimento_emp, Item.Vencimento_emp, MySqlDbType.DateTime)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Sub Excluir(ByVal CNPJ As String)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("DELETE FROM {0}", TableName)
            Sintaxe.AppendFormat("WHERE @{0} = @{0} ", EmpresasColunmsName.Cnpj_emp)
            Parametros.Add(EmpresasColunmsName.Cnpj_emp, CNPJ, MySqlDbType.VarChar)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Sub Alterar(ByVal Item As EmpresasColunms)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("UPDATE {0} SET ", TableName)

            Sintaxe.AppendFormat("{0} = @{0}, ", EmpresasColunmsName.Ativo_emp)
            Parametros.Add(EmpresasColunmsName.Ativo_emp, Item.Ativo_emp, MySqlDbType.Bit)
            Sintaxe.AppendFormat("{0} = @{0}, ", EmpresasColunmsName.Cadastro_emp)
            Parametros.Add(EmpresasColunmsName.Cadastro_emp, Item.Cadastro_emp, MySqlDbType.DateTime)
            Sintaxe.AppendFormat("{0} = @{0}, ", EmpresasColunmsName.Fantasia_emp)
            Parametros.Add(EmpresasColunmsName.Fantasia_emp, Item.Fantasia_emp, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("{0} = @{0}, ", EmpresasColunmsName.RazaoSocial_emp)
            Parametros.Add(EmpresasColunmsName.RazaoSocial_emp, Item.RazaoSocial_emp, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("{0} = @{0} ", EmpresasColunmsName.Vencimento_emp)
            Parametros.Add(EmpresasColunmsName.Vencimento_emp, Item.Vencimento_emp, MySqlDbType.DateTime)

            Sintaxe.AppendFormat("WHERE {0} = @{0} ", EmpresasColunmsName.Cnpj_emp)
            Parametros.Add(EmpresasColunmsName.Cnpj_emp, Item.Cnpj_emp, MySqlDbType.VarChar)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Function Consultar(ByVal Cnpj As String) As EmpresasColunms
        Try
            Dim Row As DataRow
            Dim Parametros As New MySQLParametros

            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("SELECT * FROM {0} ", TableName)
            Parametros.Add(EmpresasColunmsName.Cnpj_emp, Cnpj, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("WHERE {0} = @{0}", EmpresasColunmsName.Cnpj_emp)

            Row = Conexao.FillRow(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()

            Dim item As New EmpresasColunms
            If Row IsNot Nothing Then
                item.Ativo_emp = Row(EmpresasColunmsName.Ativo_emp).ToString.ToBool
                item.Cadastro_emp = Row(EmpresasColunmsName.Cadastro_emp).ToString.ToDate
                item.Cnpj_emp = Row(EmpresasColunmsName.Cnpj_emp).ToString
                item.Fantasia_emp = Row(EmpresasColunmsName.Fantasia_emp).ToString
                item.RazaoSocial_emp = Row(EmpresasColunmsName.RazaoSocial_emp).ToString
                item.Vencimento_emp = Row(EmpresasColunmsName.Vencimento_emp).ToString.ToDate
            End If

            Return item
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Function

    Public Function Consultar() As DataTable
        Try
            Dim Tabela As DataTable
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("SELECT * FROM {0} ", TableName)
            Sintaxe.AppendFormat("ORDER BY {0} ", EmpresasColunmsName.RazaoSocial_emp)

            Tabela = Conexao.FillTable(Sintaxe.ToString, , TransacaoValue)

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
