Imports MySql.Data.MySqlClient

Public Class MySQLFilter

    Private Dicionario As Dictionary(Of Data.DbType, MySqlDbType)
    Private ListaFiltros As Dictionary(Of String, Colunas)

    Private Sub MontarDicionario()
        Dicionario.Add(Data.DbType.Binary, MySqlDbType.Binary)
        Dicionario.Add(Data.DbType.Boolean, MySqlDbType.Bit)
        Dicionario.Add(Data.DbType.Byte, MySqlDbType.Byte)
        Dicionario.Add(Data.DbType.Currency, MySqlDbType.Decimal)
        Dicionario.Add(Data.DbType.Date, MySqlDbType.Date)
        Dicionario.Add(Data.DbType.DateTime, MySqlDbType.DateTime)
        Dicionario.Add(Data.DbType.DateTime2, MySqlDbType.DateTime)
        Dicionario.Add(Data.DbType.DateTimeOffset, MySqlDbType.DateTime)
        Dicionario.Add(Data.DbType.Decimal, MySqlDbType.Decimal)
        Dicionario.Add(Data.DbType.Double, MySqlDbType.Double)
        Dicionario.Add(Data.DbType.Guid, MySqlDbType.Guid)
        Dicionario.Add(Data.DbType.Int16, MySqlDbType.Int16)
        Dicionario.Add(Data.DbType.Int32, MySqlDbType.Int32)
        Dicionario.Add(Data.DbType.Int64, MySqlDbType.Int64)
        Dicionario.Add(Data.DbType.Object, MySqlDbType.Blob)
        Dicionario.Add(Data.DbType.SByte, MySqlDbType.UByte)
        Dicionario.Add(Data.DbType.String, MySqlDbType.String)
        Dicionario.Add(Data.DbType.StringFixedLength, MySqlDbType.VarChar)
        Dicionario.Add(Data.DbType.Time, MySqlDbType.Time)
        Dicionario.Add(Data.DbType.UInt16, MySqlDbType.UInt16)
        Dicionario.Add(Data.DbType.UInt32, MySqlDbType.UInt32)
        Dicionario.Add(Data.DbType.UInt64, MySqlDbType.UInt64)
        Dicionario.Add(Data.DbType.VarNumeric, MySqlDbType.LongBlob)
        Dicionario.Add(Data.DbType.Xml, MySqlDbType.Text)
    End Sub

    Private Class Colunas
        Public Property Sintaxe As String
        Public Property Parametro As MySQLParametros
        Public Property Conjucao As TipoConjuncao
    End Class

    Public Sub New()
        Try
            Dicionario = New Dictionary(Of Data.DbType, MySqlDbType)
            MontarDicionario()
            ListaFiltros = New Dictionary(Of String, Colunas)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub Remove(ByVal Key As String)
        If ListaFiltros.ContainsKey(Key) Then
            ListaFiltros.Remove(Key)
        End If
    End Sub

    Private Sub Add(ByVal key As String, ByVal Valor As Colunas)
        Try
            Remove(key)
            ListaFiltros.Add(key, Valor)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub AddIgual(ByVal Coluna As String, ByVal Valor As Object, ByVal Conj As TipoConjuncao, ByVal Tipo As Data.DbType, Optional ByVal NomeParametro As String = Nothing)
        Try
            Dim F As New Colunas
            Dim col As String
            If NomeParametro Is Nothing Then
                col = Coluna & ListaFiltros.Count.ToString
            Else
                col = NomeParametro & ListaFiltros.Count.ToString
            End If
            F.Parametro = New MySQLParametros
            F.Parametro.Add(col, Valor, Dicionario(Tipo))
            F.Conjucao = Conj
            F.Sintaxe = String.Format("({0} = @{1})", Coluna, col)
            Add(Coluna, F)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub AddIniciaCom(ByVal Coluna As String, ByVal Valor As String, ByVal Conj As TipoConjuncao, ByVal Tipo As Data.DbType, Optional ByVal NomeParametro As String = Nothing)
        Try
            Dim F As New Colunas
            Dim col As String
            If NomeParametro Is Nothing Then
                col = Coluna & ListaFiltros.Count.ToString
            Else
                col = NomeParametro & ListaFiltros.Count.ToString
            End If
            F.Parametro = New MySQLParametros
            F.Parametro.Add(col, Valor & "%", Dicionario(Tipo))
            F.Conjucao = Conj
            F.Sintaxe = String.Format("({0} LIKE @{1})", Coluna, col)
            Add(Coluna, F)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub AddContem(ByVal Coluna As String, ByVal Valor As String, ByVal Conj As TipoConjuncao, ByVal Tipo As Data.DbType, Optional ByVal NomeParametro As String = Nothing)
        Try
            Dim F As New Colunas
            Dim col As String
            If NomeParametro Is Nothing Then
                col = Coluna & ListaFiltros.Count.ToString
            Else
                col = NomeParametro & ListaFiltros.Count.ToString
            End If
            F.Parametro = New MySQLParametros
            F.Parametro.Add(col, "%" & Valor & "%", Dicionario(Tipo))
            F.Conjucao = Conj
            F.Sintaxe = String.Format("({0} LIKE @{1})", Coluna, col)
            Add(Coluna, F)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub AddMaiorQue(ByVal Coluna As String, ByVal Valor As Object, ByVal Conj As TipoConjuncao, ByVal Tipo As Data.DbType, Optional ByVal NomeParametro As String = Nothing)
        Try
            Dim F As New Colunas
            Dim col As String
            If NomeParametro Is Nothing Then
                col = Coluna & ListaFiltros.Count.ToString
            Else
                col = NomeParametro & ListaFiltros.Count.ToString
            End If
            F.Parametro = New MySQLParametros
            F.Parametro.Add(col, Valor, Dicionario(Tipo))
            F.Conjucao = Conj
            F.Sintaxe = String.Format("({0} >= @{1})", Coluna, col)
            Add(Coluna, F)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub AddMenorQue(ByVal Coluna As String, ByVal Valor As Object, ByVal Conj As TipoConjuncao, ByVal Tipo As Data.DbType, Optional ByVal NomeParametro As String = Nothing)
        Try
            Dim F As New Colunas
            Dim col As String
            If NomeParametro Is Nothing Then
                col = Coluna & ListaFiltros.Count.ToString
            Else
                col = NomeParametro & ListaFiltros.Count.ToString
            End If
            F.Parametro = New MySQLParametros
            F.Parametro.Add(col, Valor, Dicionario(Tipo))
            F.Conjucao = Conj
            F.Sintaxe = String.Format("({0} <= @{1})", Coluna, col)
            Add(Coluna, F)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub RemoveFiltro(ByVal Coluna As String)
        Try
            Remove(Coluna)
            For i As Integer = 0 To ListaFiltros.Count
                Remove(Coluna & i.ToString)
            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub AddEntre(ByVal Coluna As String, ByVal Valor1 As Object, ByVal Valor2 As Object, ByVal Conj As TipoConjuncao, ByVal Tipo As Data.DbType, Optional ByVal NomeParametro As String = Nothing)
        Try
            Dim F As New Colunas
            Dim col1 As String
            If NomeParametro Is Nothing Then
                col1 = Coluna & ListaFiltros.Count.ToString
            Else
                col1 = NomeParametro & ListaFiltros.Count.ToString
            End If
            Dim col2 As String = col1 & "A"
            F.Parametro = New MySQLParametros
            F.Parametro.Add(col1, Valor1, Dicionario(Tipo))
            F.Parametro.Add(col2, Valor2, Dicionario(Tipo))
            F.Conjucao = Conj
            F.Sintaxe = String.Format("({0} BETWEEN @{1} AND @{2})", Coluna, col1, col2)
            Add(Coluna, F)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetSintaxe() As String
        Try

            Dim Sintaxe As New Text.StringBuilder
            Dim F As Colunas

            Sintaxe.Append("(")

            For i As Integer = 0 To ListaFiltros.Count - 1

                F = ListaFiltros(ListaFiltros.ElementAt(i).Key)

                If i > 0 Then
                    Select Case F.Conjucao
                        Case TipoConjuncao._OU, TipoConjuncao._NaoOU
                            Sintaxe.Append(" OR ")
                        Case Else
                            Sintaxe.Append(" AND ")
                    End Select
                End If

                Select Case F.Conjucao
                    Case TipoConjuncao._NaoE, TipoConjuncao._NaoOU
                        Sintaxe.Append(" NOT ")
                End Select

                Sintaxe.AppendFormat("{0}", F.Sintaxe)

            Next

            Sintaxe.Append(")")

            Return Sintaxe.ToString
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetParametros() As MySQLParametros
        Try
            Dim Param As New MySQLParametros
            Dim F As Colunas

            For i As Integer = 0 To ListaFiltros.Count - 1

                F = ListaFiltros(ListaFiltros.ElementAt(i).Key)

                If F.Parametro IsNot Nothing AndAlso F.Parametro.GetParametros.Count > 0 Then
                    Param.AddRange(F.Parametro)
                End If

            Next

            Return Param
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetFiltros() As List(Of FiltroInfo)
        Try
            Dim Retorno As List(Of FiltroInfo) = Nothing
            Dim F As Colunas
            Dim novo As FiltroInfo
            For i As Integer = 0 To ListaFiltros.Count - 1

                F = ListaFiltros(ListaFiltros.ElementAt(i).Key)
                If F.Parametro IsNot Nothing AndAlso F.Parametro.GetParametros.Count > 0 Then
                    If Retorno Is Nothing Then Retorno = New List(Of FiltroInfo)
                    For Each par As MySqlParameter In F.Parametro.GetParametros
                        novo = New FiltroInfo
                        novo.Nome = par.ParameterName.Replace("@", "")
                        novo.Valor = par.Value
                        Retorno.Add(novo)
                    Next
                End If

            Next

            Return Retorno
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Class FiltroInfo
        Public Property Nome As String
        Public Property Valor As Object
    End Class

End Class

Public Enum TipoConjuncao
    _E = 0
    _OU = 1
    _NaoE = 2
    _NaoOU = 3
End Enum