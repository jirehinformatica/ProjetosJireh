Imports MySql.Data.MySqlClient

Public Class Dal_TelasEmpresas

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
            Return "telasempresas"
        End Get
    End Property

    Public ReadOnly Property Transacao As MySQLTransacao
        Get
            Return TransacaoValue
        End Get
    End Property

    Public Class TelasEmpresasColunms
        Public Property CodigoTel_tle As Integer
        Public Property CnpjEmp_tle As String
    End Class

    Public MustInherit Class TelasEmpresasColunmsName
        Private Sub New()
        End Sub
        Public Const CodigoTel_tle As String = "CodigoTel_tle"
        Public Const CnpjEmp_tle As String = "CnpjEmp_tle"
    End Class

    Public Sub Inserir(ByVal CNPJ As String, ByVal Codigo As Integer)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("INSERT INTO {0}(", TableName)
            Sintaxe.AppendFormat("{0}, ", TelasEmpresasColunmsName.CnpjEmp_tle)
            Sintaxe.AppendFormat("{0}) ", TelasEmpresasColunmsName.CodigoTel_tle)

            Sintaxe.AppendFormat("VALUES(@{0}, ", TelasEmpresasColunmsName.CnpjEmp_tle)
            Parametros.Add(TelasEmpresasColunmsName.CnpjEmp_tle, CNPJ, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("@{0})", TelasEmpresasColunmsName.CodigoTel_tle)
            Parametros.Add(TelasEmpresasColunmsName.CodigoTel_tle, Codigo, MySqlDbType.Int32)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Sub Excluir(ByVal CNPJ As String, ByVal Codigo As Integer)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("DELETE FROM {0} ", TableName)
            Sintaxe.AppendFormat("WHERE {0} = @{0} ", TelasEmpresasColunmsName.CnpjEmp_tle)
            Parametros.Add(TelasEmpresasColunmsName.CnpjEmp_tle, CNPJ, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("AND {0} = @{0} ", TelasEmpresasColunmsName.CodigoTel_tle)
            Parametros.Add(TelasEmpresasColunmsName.CodigoTel_tle, Codigo, MySqlDbType.Int32)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Function Consultar(ByVal Cnpj As String) As DataTable
        Try
            Dim Tabela As DataTable
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("SELECT * FROM {0} ", TableName)
            Sintaxe.AppendFormat("INNER JOIN {0} ON {0}.{1} = {2}.{3} ", Dal_Telas.TableName, Dal_Telas.TelasColunmsName.Codigo_tla, TableName, TelasEmpresasColunmsName.CodigoTel_tle)
            Parametros.Add(TelasEmpresasColunmsName.CnpjEmp_tle, Cnpj, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("WHERE {0} = @{0}", TelasEmpresasColunmsName.CnpjEmp_tle)

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
