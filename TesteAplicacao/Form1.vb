Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Threading

Public Class Form1

    Public Sub alerta(ByVal msg As String)
        MessageBox.Show(msg, "Alerta", MessageBoxButtons.OK)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim Banco As New BoletoNet.Banco(104)
            Dim Cedente As New BoletoNet.Cedente("14160947000174", "Jireh Solucoes em Informatica LTDA", "2079", "795")
            With Cedente
                .Codigo = 1
                .ContaBancaria.Agencia = "2079"
                .ContaBancaria.DigitoAgencia = "6"
                .ContaBancaria.Conta = "795"
                .ContaBancaria.DigitoConta = "2"
                .ContaBancaria.OperacaConta = "003"
                .Convenio = 616701
                .DigitoCedente = 2
                .CPFCNPJ = "14160947000174"
                .Nome = "Jireh Solucoes em Informatica LTDA"
            End With

            Dim Boleto As New BoletoNet.Boleto
            Dim InstrucaoProtesto As New BoletoNet.Instrucao(Banco.Codigo)
            With InstrucaoProtesto
                .Codigo = 3
                .Descricao = "Não protestar"
                .QuantidadeDias = 5
            End With
            Dim InstrucaoBaixa As New BoletoNet.Instrucao(Banco.Codigo)
            With InstrucaoBaixa
                .Codigo = 1
                .Descricao = "Baixar/Devolver"
                .QuantidadeDias = 30
            End With
            Dim Sacado As New BoletoNet.Sacado
            Dim InfoSacado As New BoletoNet.InfoSacado("Pague seu boleto em dia")

            With Sacado
                .CPFCNPJ = "80860958191"
                .Endereco = New BoletoNet.Endereco
                .Endereco.Bairro = "Conj. Riviera"
                .Endereco.CEP = "74730090"
                .Endereco.Cidade = "Goiania"
                .Endereco.End = "Rua 01"
                .InformacoesSacado.Add(InfoSacado)
                .Nome = "Demetrius"
            End With


            With Boleto
                .Abatimento = 0
                .Aceite = "n"
                .Banco = Banco
                .Carteira = "02"
                .Categoria = 0
                .Cedente = Cedente
                .DataDocumento = Date.Now  'New Date(2016, 1, 28)
                .DataJurosMora = New Date(2016, 1, 29)
                .DataMulta = New Date(2016, 1, 29)
                .DataVencimento = New Date(2016, 2, 28)
                .Especie = "DM"
                .EspecieDocumento = New BoletoNet.EspecieDocumento(104)
                .EspecieDocumento.Banco = Banco
                .EspecieDocumento.Codigo = 2
                .EspecieDocumento.Especie = "DM"
                .EspecieDocumento.Sigla = "DM"
                .Instrucoes.Add(InstrucaoBaixa)
                .Instrucoes.Add(InstrucaoProtesto)
                .IOF = 0
                .JurosMora = 0.033   'Verificar a necessidade de colocar o codigo, saber se e taxa ou valor
                .LocalPagamento = "Preferencialmente em casas lotericas"
                .Moeda = 9
                .NossoNumero = "000000000000001"
                .TipoModalidade = "14"
                .NumeroDocumento = "teste 01"
                .OutrosAcrescimos = 0
                .OutrosDescontos = 0
                .QuantidadeMoeda = 0
                .Sacado = Sacado
                .UsoBanco = ""
                .ValorBoleto = 100
                .ValorCobrado = 100
                .ValorDesconto = 0
                .ValorMoeda = ""
                .ValorMulta = 0
            End With

            Boleto.Banco.FormataCodigoBarra(Boleto)
            Boleto.Banco.FormataLinhaDigitavel(Boleto)
            Boleto.Banco.FormataNossoNumero(Boleto)
            Boleto.Banco.FormataNumeroDocumento(Boleto)

            Dim BoletoImpresao As New BoletoNet.BoletoBancario
            With BoletoImpresao
                .CodigoBanco = Banco.Codigo
                .Boleto = Boleto
                .FormatoCarne = False
            End With


            Dim ArquivoDoBoleto As String = BoletoImpresao.MontaHtml

            If BoletoImpresao.GerarArquivoRemessa Then

            End If

            Dim Gerar As New BoletoNet.ArquivoRemessa(BoletoNet.TipoArquivo.CNAB240)
            Gerar.Boletos.Add(BoletoImpresao.Boleto)

            'Dim ArquivoBanco As String = Gerar.GerarArquivoRemessa("NumeroConvenio", Boleto.Banco, Boleto.Cedente, )

        Catch ex As Exception
            alerta(ex.Message)
        End Try
    End Sub


    'Private Function GerarImagem() As String
    '    Dim address As String = WebBrowser.Url.ToString()
    '    Dim width As Integer = 670
    '    Dim height As Integer = 805

    '    Dim webBrowserWidth As Integer = 670
    '    Dim webBrowserHeight As Integer = 805

    '    Dim bmp As Bitmap = WebsiteThumbnailImageGenerator.GetWebSiteThumbnail(address, webBrowserWidth, webBrowserHeight, width, height)

    '    Dim file As String = Path.Combine(Environment.CurrentDirectory, "boleto.bmp")

    '    bmp.Save(file)

    '    Return file
    'End Function

End Class

Public Class WebsiteThumbnailImageGenerator
    Public Shared Function GetWebSiteThumbnail(Url As String, BrowserWidth As Integer, BrowserHeight As Integer, ThumbnailWidth As Integer, ThumbnailHeight As Integer) As Bitmap
        Dim thumbnailGenerator As New WebsiteThumbnailImage(Url, BrowserWidth, BrowserHeight, ThumbnailWidth, ThumbnailHeight)
        Return thumbnailGenerator.GenerateWebSiteThumbnailImage()
    End Function

    Private Class WebsiteThumbnailImage
        Public Sub New(Url As String, BrowserWidth As Integer, BrowserHeight As Integer, ThumbnailWidth As Integer, ThumbnailHeight As Integer)
            Me.m_Url = Url
            Me.m_BrowserWidth = BrowserWidth
            Me.m_BrowserHeight = BrowserHeight
            Me.m_ThumbnailHeight = ThumbnailHeight
            Me.m_ThumbnailWidth = ThumbnailWidth
        End Sub

        Private m_Url As String = Nothing
        Public Property Url() As String
            Get
                Return m_Url
            End Get
            Set(value As String)
                m_Url = value
            End Set
        End Property

        Private m_Bitmap As Bitmap = Nothing
        Public ReadOnly Property ThumbnailImage() As Bitmap
            Get
                Return m_Bitmap
            End Get
        End Property

        Private m_ThumbnailWidth As Integer
        Public Property ThumbnailWidth() As Integer
            Get
                Return m_ThumbnailWidth
            End Get
            Set(value As Integer)
                m_ThumbnailWidth = value
            End Set
        End Property

        Private m_ThumbnailHeight As Integer
        Public Property ThumbnailHeight() As Integer
            Get
                Return m_ThumbnailHeight
            End Get
            Set(value As Integer)
                m_ThumbnailHeight = value
            End Set
        End Property

        Private m_BrowserWidth As Integer
        Public Property BrowserWidth() As Integer
            Get
                Return m_BrowserWidth
            End Get
            Set(value As Integer)
                m_BrowserWidth = value
            End Set
        End Property

        Private m_BrowserHeight As Integer
        Public Property BrowserHeight() As Integer
            Get
                Return m_BrowserHeight
            End Get
            Set(value As Integer)
                m_BrowserHeight = value
            End Set
        End Property

        Public Function GenerateWebSiteThumbnailImage() As Bitmap
            Dim m_thread As New Thread(New ThreadStart(AddressOf _GenerateWebSiteThumbnailImage))
            m_thread.SetApartmentState(ApartmentState.STA)
            m_thread.Start()
            m_thread.Join()
            Return m_Bitmap
        End Function

        Private WithEvents m_WebBrowser As New WebBrowser()

        Private Sub _GenerateWebSiteThumbnailImage()

            m_WebBrowser.ScrollBarsEnabled = False
            m_WebBrowser.Navigate(m_Url)
            'm_WebBrowser.DocumentCompleted += New WebBrowserDocumentCompletedEventHandler(AddressOf WebBrowser_DocumentCompleted)
            While m_WebBrowser.ReadyState <> WebBrowserReadyState.Complete
                Application.DoEvents()
            End While
            m_WebBrowser.Dispose()
        End Sub

        Private Sub WebBrowser_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs)
            Dim m_WebBrowser As WebBrowser = DirectCast(sender, WebBrowser)
            m_WebBrowser.ClientSize = New Size(Me.m_BrowserWidth, Me.m_BrowserHeight)
            m_WebBrowser.ScrollBarsEnabled = False
            m_Bitmap = New Bitmap(m_WebBrowser.Bounds.Width, m_WebBrowser.Bounds.Height)
            m_WebBrowser.BringToFront()
            m_WebBrowser.DrawToBitmap(m_Bitmap, m_WebBrowser.Bounds)
            m_Bitmap = DirectCast(m_Bitmap.GetThumbnailImage(m_ThumbnailWidth, m_ThumbnailHeight, Nothing, IntPtr.Zero), Bitmap)
        End Sub
    End Class
End Class