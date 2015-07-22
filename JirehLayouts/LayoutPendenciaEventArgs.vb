Public Class LayoutPendenciaEventArgs
    Inherits EventArgs

    Public Sub New(ByVal onMensagem As String, ByVal onCancelado As Boolean)
        MensagemValue = onMensagem
        CanceladoValue = onCancelado
    End Sub

    Private MensagemValue As String
    Public ReadOnly Property Mensagem As String
        Get
            Return MensagemValue
        End Get
    End Property

    Private CanceladoValue As Boolean
    Public ReadOnly Property Cancelado As Boolean
        Get
            Return CanceladoValue
        End Get
    End Property

End Class
