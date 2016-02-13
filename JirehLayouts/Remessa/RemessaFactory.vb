Public Class RemessaFactory

    Public Sub New(ByVal CodigoLayout As Integer)
        Try
            ArquivoValue = ArquivoRemessa.GetInstance(CodigoLayout)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private ArquivoValue As IRemessa
    Public ReadOnly Property Arquivo As IRemessa
        Get
            Return ArquivoValue
        End Get
    End Property


End Class

Public Enum LayoutRemessa
    CaixaCIGCB240 = 1
End Enum