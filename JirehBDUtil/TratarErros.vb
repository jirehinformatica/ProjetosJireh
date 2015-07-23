Public Class TratarErros

    Private Shared Local As TratarErros

    Private Sub New()

    End Sub

    Public Shared Sub Add(ByVal ex As Exception, ByVal NomeSistema As String, ByVal DataHora As DateTime)
        Try
            If Local Is Nothing Then
                Local = New TratarErros
            End If


        Catch exx As Exception
            'Não foi possível gravar a mensagem
        End Try
    End Sub



    Protected Friend Class ErroOcorrido

        Private Sistema As String
        Private Data As DateTime

        Public Sub Add(ByVal e As Exception, ByVal NomeSistema As String, ByVal DataHora As DateTime)
            Try
                Sistema = NomeSistema
                Data = DataHora
                Dim i As New Item
                i.Add(e.Message, e.StackTrace)
                Lista.Add(i)
                Do While e.InnerException IsNot Nothing
                    e = e.InnerException
                    i = New Item
                    i.Add(e.Message, e.StackTrace)
                    Lista.Add(i)
                Loop

            Catch ex As Exception
                Try
                    Dim n As New Item
                    n.Add(e.Message, e.StackTrace)
                    Lista.Add(n)
                Catch exx As Exception
                    'Não será adicionado
                End Try
            End Try
        End Sub

        Public Sub New()
            Lista = New List(Of Item)
        End Sub

        Private Lista As List(Of Item)

        Public Function MenssagemEnvio() As String
            Try
                Dim texto As New Text.StringBuilder
                texto.Append("<div style=""border: solid 1px #000000""><div>Dados do erro ocorrido</div><div>")
                texto.AppendFormat("<div style=""float:left"">Sistema: </div><div style=""float:left"">{0}</div>", Sistema)
                texto.Append("</div><div><div style=""float:left"">Data/Hora: </div><div style=""float:left"">{0}</div>", Data.ToString("dd/MM/yyyy HH:mm"))
                Dim aux As String
                If InfoRegistro IsNot Nothing AndAlso InfoRegistro.InformacoesUso IsNot Nothing AndAlso InfoRegistro.InformacoesUso.CNPJ <> "" Then
                    aux = InfoRegistro.InformacoesUso.CNPJ
                Else
                    aux = ""
                End If
                texto.AppendFormat("<div style=""float:right"">Empresa: </div><div style=""float:right"">{0}</div>", aux)
                If Lista IsNot Nothing Then
                    texto.Append("<div>")
                    For Each l As Item In Lista
                        texto.Append(l.Corpo)
                    Next
                    texto.Append("</div>")
                End If
                texto.Append("</div>")

                Return texto.ToString
            Catch ex As Exception
                Try
                    Dim texto As New Text.StringBuilder
                    If Lista IsNot Nothing Then
                        texto.Append("<div>")
                        For Each l As Item In Lista
                            texto.Append(l.Corpo)
                        Next
                        texto.Append("</div>")
                    End If
                    Return texto.ToString
                Catch exx As Exception
                    'Não foi possivel enviar
                    Return ""
                End Try
            End Try
        End Function

    End Class

    Protected Friend Class Item

        Private Const Parte1 As String = "<table border=""0""><tr><td style=""border-top: solid 1px #000000; border-left: solid 1px #000000"">Mensagem</td><td style=""border-top: solid 1px #000000; border-left: solid 1px #000000; border-right: solid 1px #000000"">{0}</td></tr><tr>"
        Private Const Parte2 As String = "<td style=""border-top: solid 1px #000000; border-left: solid 1px #000000; border-bottom: solid 1px #000000"">Detalhe</td><td style=""border-top: solid 1px #000000; border-left: solid 1px #000000; border-bottom: solid 1px #000000; border-right: solid 1px #000000"">{0}</td></tr></table>"

        Private Mens As String
        Private Star As String

        Public Sub Add(ByVal mensagem As String, ByVal StarTrace As String)
            Mens = mensagem
            Star = StarTrace
        End Sub

        Public Function Corpo() As String
            Try
                Dim texto As New Text.StringBuilder
                texto.AppendFormat(Parte1, Mens)
                texto.AppendFormat(Parte2, Star)

                Return texto.ToString
            Catch ex As Exception
                Return Mens & "<br />" & Star
            End Try
        End Function
    End Class

End Class
