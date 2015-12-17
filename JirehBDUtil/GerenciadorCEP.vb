Public Class GerenciadorCEP

    Public Class EnderecoInfo
        Public Property bairro As String
        Public Property logradouro As String
        Public Property cep As String
        Public Property uf As String
        Public Property localidade As String
    End Class

    ''' <summary>
    ''' Utilização, no valor {0} informar o CEP sem uso de mascaras, o retorno é no formato JSON
    ''' </summary>
    Private Const PageCorreios As String = "http://cep.correiocontrol.com.br/{0}.js"

    Public Sub New(ByVal NumeroCep As String)
        Try
            EnderecoValue = New EnderecoInfo
            NumeroCep = String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(NumeroCep, "[^\d]"))

            If String.IsNullOrEmpty(NumeroCep) OrElse Not IsNumeric(NumeroCep) Then
                CepEncontradoValue = False
                Exit Sub
            End If

            BuscarCEP(CLng(NumeroCep))

            If String.IsNullOrEmpty(ConteudoAnalise) Then
                Exit Sub
            End If

            Dim sucesso As Byte = 0

            Dim aux() As String = ConteudoAnalise.Split("(")
            If aux.Length > 1 Then
                ConteudoAnalise = aux(1)
                sucesso += 1
            End If
            aux = ConteudoAnalise.Split(")")
            If aux.Length > 1 Then
                ConteudoAnalise = aux(0)
                sucesso += 1
            End If

            If sucesso <> 2 Then
                CepEncontradoValue = False
                Exit Sub
            End If

            DeSerializar()

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private ConteudoAnalise As String

    Private Sub DeSerializar()
        Try
            Dim Texto As New IO.StringReader(ConteudoAnalise)
            Dim Serializar As New Newtonsoft.Json.JsonSerializer
            EnderecoValue = Serializar.Deserialize(Texto, GetType(EnderecoInfo))
            CepEncontradoValue = True
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub BuscarCEP(ByVal Value As Long)
        Try
            Using UrlBuscar As New System.Net.WebClient
                UrlBuscar.Encoding = System.Text.Encoding.UTF8
                ConteudoAnalise = UrlBuscar.DownloadString(String.Format(PageCorreios, Value))
            End Using

        Catch ex As Exception
            CepEncontradoValue = False
            ConteudoAnalise = String.Empty
        End Try
    End Sub

    Private CepEncontradoValue As Boolean
    Public ReadOnly Property CepEncontrado As Boolean
        Get
            Return CepEncontradoValue
        End Get
    End Property

    Private EnderecoValue As EnderecoInfo
    Public ReadOnly Property Endereco As EnderecoInfo
        Get
            Return EnderecoValue
        End Get
    End Property

End Class
