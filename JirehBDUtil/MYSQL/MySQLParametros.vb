Imports MySql.Data.MySqlClient

Public Class MySQLParametros

    Private ListaParametrosValue As List(Of MySqlParameter)

    Public Sub New()
        Try
            ListaParametrosValue = New List(Of MySqlParameter)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub Add(ByVal Nome As String, ByVal Valor As Object, ByVal Tipo As MySqlDbType)
        Try
            Dim par As New MySqlParameter(LimpaParametroName(Nome), Tipo)
            If Valor Is Nothing Then
                par.IsNullable = True
                par.Value = DBNull.Value
            Else
                par.Value = Valor
            End If
            ListaParametrosValue.Add(par)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetParametros() As List(Of MySqlParameter)
        Return ListaParametrosValue
    End Function

    Public Sub AddRange(ByVal Novos As MySQLParametros)
        Try
            ListaParametrosValue.AddRange(Novos.GetParametros.ToArray)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Function LimpaParametroName(ByVal Nome As String) As String
        Dim NomeValue As String = Nome.Replace("@", "")
        Return String.Format("@{0}", NomeValue)
    End Function

    Public ReadOnly Property ParametrosCount As Integer
        Get
            Return ListaParametrosValue.Count
        End Get
    End Property

End Class
