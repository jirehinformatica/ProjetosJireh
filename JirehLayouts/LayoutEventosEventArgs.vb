Public Class LayoutEventosEventArgs
    Inherits EventArgs

    Public Sub New(ByVal onProgresso As Integer, ByVal onMaximoValor As Integer, ByVal onMensagem As String, ByVal onCancelar As Boolean)
        ProgressoValue = onProgresso
        MensagemValue = onMensagem
        Cancelar = onCancelar
        MaximoValorValue = onMaximoValor
    End Sub

    Private ProgressoValue As Integer
    Public ReadOnly Property Progresso As Integer
        Get
            Return ProgressoValue
        End Get
    End Property

    Private MaximoValorValue As Integer
    Public ReadOnly Property MaximoValor As Integer
        Get
            Return MaximoValorValue
        End Get
    End Property

    Private MensagemValue As String
    Public ReadOnly Property Mensagem As String
        Get
            Return MensagemValue
        End Get
    End Property

    Public Property Cancelar As Boolean

End Class
