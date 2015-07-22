Public Class Dal_Geral

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

    Public ReadOnly Property Transacao As MySQLTransacao
        Get
            Return TransacaoValue
        End Get
    End Property

    Public Function GetDataHoraServidor() As DateTime
        Try
            Conexao.Open()
            TransacaoValue.BeginTransacao()
            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.Append("SELECT NOW() ")
            Dim data As DateTime = Conexao.ExecuteScalar(Sintaxe.ToString, , TransacaoValue).ToString.ToDate
            TransacaoValue.CommitTransacao()
            If data = DateTime.MinValue Then
                data = Date.Now
            End If
            Return data
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Function

End Class
