Public MustInherit Class ArquivoRemessa
    Implements IRemessa

    Private MeuArquivo As List(Of LinhaArquivo)

    Public Shared Function GetInstance(ByVal CodigoLayout As Integer) As IRemessa
        Try
            Dim Valor As LayoutsDescricao = New LayoutsDescricao(CodigoLayout, String.Empty)
            Dim Novo As IRemessa = Activator.CreateInstance(Valor.TypeNameSpace, Valor.TypeClassName)
            Return Novo
        Catch ex As Exception
            Throw
        End Try
    End Function

    Protected Function Add(ByVal nTipo As TiposLinha, ByVal nSegmento As TipoSegmento, ByVal nPosicoes As Integer) As LinhaArquivo
        If MeuArquivo Is Nothing Then
            MeuArquivo = New List(Of LinhaArquivo)
        End If
        Dim NovaLinha As New LinhaArquivo(MeuArquivo.Count + 1, nTipo, nSegmento, nPosicoes)
        MeuArquivo.Add(NovaLinha)
        Return NovaLinha
    End Function
    Protected Function Item(ByVal Sequencia As Integer) As LinhaArquivo
        Try
            Dim pos As Integer = MeuArquivo.FindIndex(Function(i) i.Sequencia = Sequencia)
            If pos = -1 Then
                Return Nothing
            End If
            Return MeuArquivo(pos)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Protected Function GetArquivoMontado(ByVal QuantidadePorArquivo As Integer) As String()
        Try

            Dim Arquivo As String = String.Empty
            Dim aux As String = String.Empty
            If MeuArquivo IsNot Nothing Then
                For Each l As LinhaArquivo In MeuArquivo
                    Arquivo &= aux & l.GetLinha
                    aux = vbNewLine
                Next
            End If
            Return {Arquivo}

        Catch ex As Exception
            Throw
        Finally
            MeuArquivo = Nothing
        End Try
    End Function

    Protected MustOverride Function GetLayoutPorCodigo() As LayoutsDescricao

    Public MustOverride ReadOnly Property Layout As LayoutsDescricao Implements IRemessa.Layout

    Public Property BancoCodigo As Integer Implements IRemessa.BancoCodigo

    Public Property DadosCedente As InfoCedente Implements IRemessa.DadosCedente

    Public Property DataGeracao As Date Implements IRemessa.DataGeracao

    Public Property DataGravacao As Date Implements IRemessa.DataGravacao

    Public Property HoraGeracao As Date Implements IRemessa.HoraGeracao

    Public Property Itens As List(Of InfoRemessa) Implements IRemessa.Itens

    Public Property Mensagem01 As String Implements IRemessa.Mensagem01

    Public Property Mensagem02 As String Implements IRemessa.Mensagem02

    Public Property MensagemEmpresa As String Implements IRemessa.MensagemEmpresa

    Public Property NSA As String Implements IRemessa.NSA

    Public MustOverride Function GetArquivoRemessa() As String() Implements IRemessa.GetArquivoRemessa

    Protected Class LinhaArquivo

        Protected Friend Sub New(ByVal nSequencia As Integer, ByVal nTipo As TiposLinha, ByVal nSegmento As TipoSegmento, ByVal nPosicoes As Integer)
            Try

                SequenciaValue = nSequencia
                TipoValue = nTipo
                SegmentoValue = nSegmento
                PosicoesValue = nPosicoes
                Lista = New List(Of ItensLinha)

            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private SequenciaValue As Integer
        Public ReadOnly Property Sequencia As Integer
            Get
                Return SequenciaValue
            End Get
        End Property

        Private TipoValue As TiposLinha
        Public ReadOnly Property Tipo As TiposLinha
            Get
                Return TipoValue
            End Get
        End Property

        Private SegmentoValue As TipoSegmento
        Public ReadOnly Property Segmento As TipoSegmento
            Get
                Return SegmentoValue
            End Get
        End Property

        Private PosicoesValue As Integer
        Public ReadOnly Property Posicoes As Integer
            Get
                Return PosicoesValue
            End Get
        End Property

        Private Lista As List(Of ItensLinha)

        Public Sub Add(ByVal Valor As String, ByVal Pos As Integer, ByVal Tam As Integer, Optional ByVal TipVal As TipoFormato = TipoFormato.SpaceDireita)
            Try

                Dim Novo As New ItensLinha
                Novo.Inicio = Pos
                Novo.Tamanho = Tam
                Novo.Valor = Valor
                Novo.Formato = TipVal
                Lista.Add(Novo)

            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Function GetLinha() As String
            Try

                Dim aux As List(Of ItensLinha) = Lista.OrderBy(Function(i) i.Inicio).ToList
                Dim texto As New Text.StringBuilder
                Dim old As String

                For Each i As ItensLinha In aux

                    Select Case i.Formato
                        Case TipoFormato.SpaceEsquerda
                            old = Space(i.Tamanho) & i.Valor.Trim
                            old = old.PadLeft(i.Tamanho)

                        Case TipoFormato.ZerosDireita
                            old = i.Valor.PadRight(i.Tamanho, "0")

                        Case TipoFormato.ZerosEsquerda
                            old = i.Valor.PadLeft(i.Tamanho, "0")

                        Case TipoFormato.Data
                            If IsDate(i.Valor) Then
                                old = CDate(i.Valor).ToString("ddMMyyyy")
                            Else
                                old = "00000000"
                            End If

                        Case TipoFormato.Hora
                            If IsDate(i.Valor) Then
                                old = CDate(i.Valor).ToString("HHmmss")
                            Else
                                old = "000000"
                            End If

                        Case TipoFormato.DataEhora
                            If IsDate(i.Valor) Then
                                old = CDate(i.Valor).ToString("ddMMyyyyHHmmss")
                            Else
                                old = "00000000000000"
                            End If

                        Case Else
                            old = Space(i.Tamanho) & i.Valor.Trim
                            old = old.PadLeft(i.Tamanho)

                    End Select

                    texto.Append(old)

                Next

                Return texto.ToString

            Catch ex As Exception
                Throw
            End Try
        End Function

        Private Class ItensLinha
            Public Property Inicio As Integer
            Public Property Tamanho As Integer
            Public Property Valor As String
            Public Property Formato As TipoFormato
        End Class

    End Class

End Class

Public Enum TiposLinha
    HeaderArquivo = 0
    Headerlote = 1
    Segmento = 2
    TrailerLote = 3
    TrailerArquivo = 4
End Enum

Public Enum TipoSegmento
    Nenhum = 0
    SegA = 1
    SegB = 2
End Enum

Public Enum TipoFormato
    ZerosEsquerda = 1
    ZerosDireita = 2
    SpaceEsquerda = 3
    SpaceDireita = 4
    Data = 5
    Hora = 6
    DataEhora = 7
End Enum