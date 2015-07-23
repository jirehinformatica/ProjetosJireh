Imports System.Windows.Forms

Public Class TratarErros

    Private Shared Local As TratarErros

    Private Sub New()
        PrimeiroErro = True
        Lista = New List(Of ErroOcorrido)
        TempoEnvio = New Timer
        TempoEnvio.Interval = 300000
        TempoEnvio.Start()

    End Sub

    Private Sub TempoEnvio_Tick(sender As Object, e As EventArgs) Handles TempoEnvio.Tick
        Try
            If Local.Lista.Count = 0 Then
                Exit Sub
            End If
            Local.TransmitirErros()

        Catch ex As Exception
            'Não será enviado
        End Try
    End Sub

    Public Shared Sub Add(ByVal ex As Exception, ByVal NomeSistema As String, ByVal DataHora As DateTime)
        Try
            If Local Is Nothing Then
                Local = New TratarErros
            End If

            Dim novo As New ErroOcorrido
            novo.Add(ex, NomeSistema, DataHora)
            Local.Lista.Add(novo)

            EnviarErros(DataHora)

        Catch exx As Exception
            'Não foi possível gravar a mensagem
        End Try
    End Sub

    Private Lista As List(Of ErroOcorrido)
    Private WithEvents TempoEnvio As Timer

    Private PrimeiroErro As Boolean
    Public Shared Sub EnviarErros(ByVal DataHora As DateTime, Optional ByVal ForcarEnvio As Boolean = False)
        Try
            Dim chamada As Boolean = Local.Lista.Count > 0
            If chamada Then
                Dim Ultimo As DateTime = (From d In Local.Lista.AsEnumerable Select d.Data).Max
                Dim timeSpa As TimeSpan = DataHora.Subtract(Ultimo)
                Dim i As Integer = (DataHora - Ultimo).Minutes
                chamada = i > 1
            End If

            If (Not chamada AndAlso ForcarEnvio) OrElse Local.PrimeiroErro Then
                chamada = True
            End If

            Local.TransmitirErros()

        Catch ex As Exception
            'Naõ foi possivel a transmição
        End Try
    End Sub

    Private Sub TransmitirErros()
        Try
            Dim Em As New Email
            Em.Assunto = "Erro - Transmissão de erros do sistema (Projetos Jireh)"
            Em.MensagemTextoPossuiHTML = True
            Em.MensagemPrioridade = Net.Mail.MailPriority.Normal
            Em.EnviarServidorEmail = "email-ssl.com.br"
            Em.EnviarServidorPorta = 465
            Em.DestinatarioEmailAdd("sistemas@jireh.net.br")
            Em.RemetenteEmail("sistemas@jireh.net.br", "Sistema Jireh")
            Em.EnviarUsuarioSenhaAdd("sistemas@jireh.net.br", "jirehsis01")

            Dim aux As String = ""
            For Each i As ErroOcorrido In Lista
                aux &= i.MenssagemEnvio
            Next

            Em.MensagemEmail = aux

            Em.EnviarEmail()

            Lista.Clear()

        Catch ex As Exception
            'Existe um bloqueio no envio do email
        End Try
    End Sub

    Protected Friend Class ErroOcorrido

        Private Sistema As String
        Private DataValue As DateTime

        Public ReadOnly Property Data As DateTime
            Get
                Return DataValue
            End Get
        End Property

        Public Sub Add(ByVal e As Exception, ByVal NomeSistema As String, ByVal DataHora As DateTime)
            Try
                Sistema = NomeSistema
                DataValue = DataHora
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
                texto.Append("</div><div><div style=""float:left"">Data/Hora: </div><div style=""float:left"">{0}</div>", DataValue.ToString("dd/MM/yyyy HH:mm"))
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
