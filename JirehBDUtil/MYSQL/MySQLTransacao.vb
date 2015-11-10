Imports MySql.Data.MySqlClient

Public Class MySQLTransacao

    Private tx As MySqlTransaction
    Private Cnx As MySQL

    Public Sub New(ByRef Conexao As MySQL)
        Try
            Cnx = Conexao
            Abriu = False
            AberturaCount = 0
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function Transacao() As MySqlTransaction
        Return tx
    End Function

    Private AberturaCount As Integer
    Private Abriu As Boolean

    Public Sub BeginTransacao()
        Try

            If Not Abriu Then
                tx = Cnx.Conexao.BeginTransaction
            End If
            Abriu = True
            AberturaCount += 1

        Catch exM As MySqlException
            Throw New Exception("Erro na conexão MySQL - Mensagem: " & exM.Message & " - Strack: " & exM.StackTrace, exM)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub CommitTransacao()
        Try

            AberturaCount -= 1
            If AberturaCount = 0 Then
                tx.Commit()
                Abriu = False
            End If
            If AberturaCount < 0 Then
                AberturaCount = 0
            End If

        Catch exM As MySqlException
            Throw New Exception("Erro na conexão MySQL - Mensagem: " & exM.Message & " - Strack: " & exM.StackTrace, exM)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub RollBackTransacao()
        Try

            AberturaCount = 0
            If Abriu Then
                Try
                    tx.Rollback()
                Catch ex As Exception
                End Try
            End If
            Abriu = False

        Catch exM As MySqlException
            Throw New Exception("Erro na conexão MySQL - Mensagem: " & exM.Message & " - Strack: " & exM.StackTrace, exM)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public ReadOnly Property EmTransacao As Boolean
        Get
            Return Abriu
        End Get
    End Property
End Class
