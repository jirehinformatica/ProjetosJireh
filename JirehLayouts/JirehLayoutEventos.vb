Public Class JirehLayoutEventos

    Public Sub New()
        CanceladoValue = False
        Maximo = 0
    End Sub

    Public Event Progresso(ByVal sender As Object, ByRef e As LayoutEventosEventArgs)
    Public Event Mensagem(ByVal sender As Object, ByVal e As LayoutPendenciaEventArgs)

    Public Sub OnMensagem(ByVal Mensagem As String, ByVal Cancelar As Boolean)
        Try
            Dim ev As New LayoutPendenciaEventArgs(Mensagem, Cancelar)
            RaiseEvent Mensagem(Me, ev)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub OnProgresso(ByVal Posicao As Integer, Optional ByVal Mensagem As String = "", Optional ByVal MaximoValor As Integer = -1)
        Try
            If MaximoValor <> -1 Then
                Maximo = MaximoValor
            End If

            Dim ev As New LayoutEventosEventArgs(Posicao, Maximo, Mensagem, CanceladoValue)
            RaiseEvent Progresso(Me, ev)
            CanceladoValue = ev.Cancelar

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Maximo As Integer
    Private CanceladoValue As Boolean
    Public ReadOnly Property Cancelado As Boolean
        Get
            Return CanceladoValue
        End Get
    End Property

End Class
