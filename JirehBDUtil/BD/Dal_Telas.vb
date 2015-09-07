Public Class Dal_Telas

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
            Return "telas"
        End Get
    End Property

    Public ReadOnly Property Transacao As MySQLTransacao
        Get
            Return TransacaoValue
        End Get
    End Property

    Public Class TelasColunms
        Public Property Codigo_tla As Integer
        Public Property Descricao_tla As String
    End Class

    Public MustInherit Class TelasColunmsName
        Private Sub New()
        End Sub
        Public Const Codigo_tla As String = "Codigo_tla"
        Public Const Descricao_tla As String = "Descricao_tla"
    End Class

    Public Function Consultar() As DataTable
        Try
            Dim Tabela As DataTable
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("SELECT * FROM {0} ", TableName)
            Sintaxe.AppendFormat("ORDER BY {0} ", TelasColunmsName.Descricao_tla)

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
