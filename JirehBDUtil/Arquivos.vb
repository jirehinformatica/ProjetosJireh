Imports System.Windows.Forms

Public Class Arquivos

    Dim Open As OpenFileDialog

    Public Sub New()
        Try
            Open = New OpenFileDialog
            ResultadoOpen = DialogResult.Ignore
            ClearSelecionarFiltros()
        Catch ex As Exception
            Throw
        End Try
    End Sub

#Region "Selecionar arquivos"

    Private FiltrosOpenValue As List(Of String)
    ''' <summary>
    ''' Adicionar os filtros que serão exibidos na caixa de arquivos
    ''' </summary>
    ''' <param name="Descricao">Descrição do tipo de extenção</param>
    ''' <param name="Extencao">Nome da extenção ex: exe ou doc ou * (todos)</param>
    ''' <remarks></remarks>
    Public Sub AddSelecionarFiltros(ByVal Descricao As String, ByVal Extencao As String)
        Try
            If FiltrosOpenValue Is Nothing Then
                ClearSelecionarFiltros()
            End If
            FiltrosOpenValue.Add(String.Format("{0}|*.{1}", Descricao, Extencao))
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub ClearSelecionarFiltros()
        FiltrosOpenValue = New List(Of String)
    End Sub

    Private TituloCaixaValue As String
    Public WriteOnly Property TituloCaixa As String
        Set(value As String)
            TituloCaixaValue = value
        End Set
    End Property

    Private ResultadoOpen As DialogResult
    Public Function SelecionarUmArquivo() As Boolean
        Try
            Dim aux As String = String.Empty
            If FiltrosOpenValue IsNot Nothing Then
                Dim pre As String = String.Empty
                aux = FiltrosOpenValue.AsEnumerable.Select(Function(i)
                                                               Dim aux2 As String = pre & i
                                                               pre = ";"
                                                               Return aux2
                                                           End Function).ToList.FirstOrDefault.ToString
            End If
            Open.Filter = aux
            Open.Title = TituloCaixaValue
            Open.Multiselect = False
            ResultadoOpen = Open.ShowDialog
            If ResultadoOpen = DialogResult.OK OrElse ResultadoOpen = DialogResult.Yes Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function SelecionarVariosArquivo() As Boolean
        Try
            Dim aux As String = String.Empty
            If FiltrosOpenValue IsNot Nothing Then
                Dim pre As String = String.Empty
                aux = FiltrosOpenValue.AsEnumerable.Select(Function(i)
                                                               Dim aux2 As String = pre & i
                                                               pre = ";"
                                                               Return aux2
                                                           End Function).ToList.FirstOrDefault.ToString
            End If
            Open.Filter = aux
            Open.Title = TituloCaixaValue
            Open.Multiselect = True
            ResultadoOpen = Open.ShowDialog
            If ResultadoOpen = DialogResult.OK OrElse ResultadoOpen = DialogResult.Yes Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ArquivoSelecionadoPath() As String
        If ResultadoOpen = DialogResult.OK OrElse ResultadoOpen = DialogResult.Yes Then
            Return Open.FileName
        End If
        Return String.Empty
    End Function
    Public Function ArquivosSelecionadosPaths() As String()
        If ResultadoOpen = DialogResult.OK OrElse ResultadoOpen = DialogResult.Yes Then
            Return Open.FileNames
        End If
        Return {}
    End Function

#End Region

#Region "Gravar Arquivos"

    Public Function Copiar(ByVal ArquivoPathOrigem As String, ByVal ArquivoPathDestino As String, Optional ByVal Sobrescrever As Boolean = True) As Boolean
        Try
            IO.File.Copy(ArquivoPathOrigem, ArquivoPathDestino, Sobrescrever)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

End Class
