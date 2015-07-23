Imports MySql.Data.MySqlClient

Public Class Dal_MaquinasAtivas

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
            Return "maquinasativas"
        End Get
    End Property

    Public ReadOnly Property Transacao As MySQLTransacao
        Get
            Return TransacaoValue
        End Get
    End Property

    Public Class MaquinasAtivasColunms
        Public Property CnpjEmp_maa As String
        Public Property Quantidade_maa As Integer
    End Class

    Public MustInherit Class MaquinasAtivasColunmsName
        Private Sub New()
        End Sub
        Public Const CnpjEmp_maa As String = "CnpjEmp_maa"
        Public Const Quantidade_maa As String = "Quantidade_maa"
    End Class

    Public Sub Inserir(ByVal item As MaquinasAtivasColunms)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("INSERT INTO {0}(", TableName)
            Sintaxe.AppendFormat("{0}, ", MaquinasAtivasColunmsName.CnpjEmp_maa)
            Sintaxe.AppendFormat("{0}) ", MaquinasAtivasColunmsName.Quantidade_maa)

            Sintaxe.AppendFormat("VALUES(@{0}, ", MaquinasAtivasColunmsName.CnpjEmp_maa)
            Parametros.Add(MaquinasAtivasColunmsName.CnpjEmp_maa, item.CnpjEmp_maa, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("@{0}) ", MaquinasAtivasColunmsName.Quantidade_maa)
            Parametros.Add(MaquinasAtivasColunmsName.Quantidade_maa, item.Quantidade_maa, MySqlDbType.Int32)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Sub Alterar(ByVal item As MaquinasAtivasColunms)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("UPDATE {0} SET ", TableName)
            Sintaxe.AppendFormat("{0} = @{0} ", MaquinasAtivasColunmsName.Quantidade_maa)
            Parametros.Add(MaquinasAtivasColunmsName.Quantidade_maa, item.Quantidade_maa, MySqlDbType.Int32)
            Sintaxe.AppendFormat("WHERE {0} = @{0} ", MaquinasAtivasColunmsName.CnpjEmp_maa)
            Parametros.Add(MaquinasAtivasColunmsName.CnpjEmp_maa, item.CnpjEmp_maa, MySqlDbType.VarChar)

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
            Sintaxe.AppendFormat("WHERE {0} = @{0} ", MaquinasAtivasColunmsName.CnpjEmp_maa)
            Parametros.Add(MaquinasAtivasColunmsName.CnpjEmp_maa, Cnpj, MySqlDbType.VarChar)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Function Consultar(ByVal Cnpj As String) As MaquinasAtivasColunms
        Try
            Dim tab As DataTable = Consultar()

            Dim dados As MaquinasAtivasColunms = Nothing

            If tab IsNot Nothing AndAlso tab.Rows.Count > 0 Then

                dados = (From i In tab.AsEnumerable Where i.Field(Of String)(MaquinasAtivasColunmsName.CnpjEmp_maa).ToString = Cnpj _
                              Select New MaquinasAtivasColunms With { _
                                  .CnpjEmp_maa = i.Field(Of String)(MaquinasAtivasColunmsName.CnpjEmp_maa).ToString,
                                  .Quantidade_maa = i.Field(Of Nullable(Of Integer))(MaquinasAtivasColunmsName.Quantidade_maa).ToInteger
                        }).FirstOrDefault
            End If

            If dados Is Nothing Then
                dados = New MaquinasAtivasColunms
            End If

            Return dados
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function Consultar() As DataTable
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Dim Tabela As DataTable
            Sintaxe.AppendFormat("SELECT * FROM {0} ", TableName)

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
