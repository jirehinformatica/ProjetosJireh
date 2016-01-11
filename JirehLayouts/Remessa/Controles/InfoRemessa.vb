Public Class InfoRemessa

    Public Sub New(ByVal ValorCedente As String)
        Sacado = New InfoSacado
        NossoNumero = New InfoNossoNumero
        CedenteValue = ValorCedente
    End Sub

    Private CedenteValue As String
    Public ReadOnly Property Cedente As String
        Get
            Return CedenteValue
        End Get
    End Property
    Public Property Sacado As InfoSacado
    Public Property NossoNumero As InfoNossoNumero
    Public Property NumeroDocumento As String
    Public Property DataVencimento As Date
    Public Property DataEmissao As Date
    Public Property DataJurosMora As Date
    Public Property DataDesconto01 As Date
    Public Property DataDesconto02 As Date
    Public Property DataDesconto03 As Date
    Public Property DataMulta As Date
    Public Property ValorTitulo As Decimal
    Public Property ValorJurosMora As Decimal
    Public Property ValorDesconto01 As Decimal
    Public Property ValorDesconto02 As Decimal
    Public Property ValorDesconto03 As Decimal
    Public Property ValorAbatimento As Decimal
    Public Property ValorMulta As Decimal
    Public Property PrazoProtesto As String
    Public Property PrazoDevolucao As String

End Class
