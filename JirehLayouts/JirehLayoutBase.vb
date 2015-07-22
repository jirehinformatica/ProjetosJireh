
Public MustInherit Class JirehLayoutBase
    Implements ILayout

    Public Sub New(ByVal PathArquivoRetorno As String, ByRef EventoEmExecucao As JirehLayoutEventos, ByVal QuantidadeColunasPorLinha As Integer)
        Try
            If EventoEmExecucao Is Nothing Then
                EventoEmExecucao = New JirehLayoutEventos
            End If
            EventosValue = EventoEmExecucao
            QuantidadeColunas = QuantidadeColunasPorLinha
            ArquivoValidoValue = True

            If Not IO.File.Exists(PathArquivoRetorno) Then
                Eventos.OnMensagem("O arquivo " * PathArquivoRetorno & " informado, não foi localizado. ", True)
                Exit Sub
            End If

            Linhas = IO.File.ReadAllLines(PathArquivoRetorno)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Linhas() As String
    Protected ArquivoValidoValue As Boolean
    Private QuantidadeColunas As Integer

    Protected Function Ler(ByVal NumeroLinha As Long, ByVal Inicio As Integer, Optional ByVal Tamanho As Integer = -1) As String
        Try
            ArquivoValidoValue = Linhas(NumeroLinha).Length = QuantidadeColunas
            If ArquivoValidoValue Then
                If Inicio = 0 Then
                    Inicio = 1
                End If
                Inicio -= 1
                If Tamanho = -1 Then
                    Return Linhas(NumeroLinha).Substring(Inicio).Trim
                End If
                Return Linhas(NumeroLinha).Substring(Inicio, Tamanho).Trim
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function
    Protected Function Ler(ByVal Linha As String, ByVal Inicio As Integer, Optional ByVal Tamanho As Integer = -1) As String
        Try
            ArquivoValidoValue = Linha.Length = QuantidadeColunas
            If ArquivoValidoValue Then
                If Inicio = 0 Then
                    Inicio = 1
                End If
                Inicio -= 1
                If Tamanho = -1 Then
                    Return Linha.Substring(Inicio).Trim
                End If
                Return Linha.Substring(Inicio, Tamanho).Trim
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private EventosValue As JirehLayoutEventos
    Public ReadOnly Property Eventos As JirehLayoutEventos Implements ILayout.Eventos
        Get
            Return EventosValue
        End Get
    End Property

    Public ReadOnly Property LinhasCount As Long Implements ILayout.LinhasCount
        Get
            Return Linhas.Length
        End Get
    End Property

    Public MustOverride ReadOnly Property NumeroBanco As Integer Implements ILayout.NumeroBanco
    Public MustOverride Function ArquivoValido(ByVal NumeroConvenios As String) As Boolean Implements ILayout.ArquivoValido

End Class

Public Enum TipoInscricao
    CPF = 1
    CNPJ = 2
End Enum