Public Class MySQLOrdem

    Private ListaOrdem As Dictionary(Of String, Colunas)

    Private Class Colunas
        Public Property Sintaxe As String
        Public Property Ordem As Integer
    End Class

    Public Sub New()
        Try
            ListaOrdem = New Dictionary(Of String, Colunas)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub Add(ByVal Coluna As String, ByVal Ordem As Integer, Optional ByVal Direcao As TipoDirecao = TipoDirecao.Crescente)
        Try
            If ListaOrdem.ContainsKey(Coluna) Then
                ListaOrdem.Remove(Coluna)
            End If

            For i As Integer = 0 To ListaOrdem.Count - 1
                If ListaOrdem(ListaOrdem.ElementAt(i).Key).Ordem >= Ordem Then
                    ListaOrdem(ListaOrdem.ElementAt(i).Key).Ordem += 1
                End If
            Next

            Dim c As New Colunas
            If Direcao = TipoDirecao.Decrescente Then
                c.Sintaxe = Coluna & " DESC"
            Else
                c.Sintaxe = Coluna
            End If
            c.Ordem = Ordem

            ListaOrdem.Add(Coluna, c)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetSintaxe() As String
        Try

            Dim Sintaxe As New Text.StringBuilder

            For i As Integer = 0 To ListaOrdem.Count

                For c As Integer = 0 To ListaOrdem.Count - 1

                    If ListaOrdem(ListaOrdem.ElementAt(c).Key).Ordem = i Then

                        If i > 0 Then
                            Sintaxe.Append(", ")
                        End If

                        Sintaxe.Append(ListaOrdem(ListaOrdem.ElementAt(c).Key).Sintaxe)

                    End If

                Next

            Next

            Return Sintaxe.ToString
        Catch ex As Exception
            Throw
        End Try
    End Function

End Class

Public Enum TipoDirecao
    Crescente = 0
    Decrescente = 1
End Enum