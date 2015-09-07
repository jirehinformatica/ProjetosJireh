Public Class ExtratoReport
    Implements IReports

    Public ReadOnly Property NameEmblasededReport As String Implements IReports.NameEmblasededReport
        Get
            Return "JirehReports.Extrato.rdlc"
        End Get
    End Property

    Public ReadOnly Property NameLocalReport As String Implements IReports.NameLocalReport
        Get
            Return "Extrato.rdlc"
        End Get
    End Property

    Public ReadOnly Property NameTable As String Implements IReports.NameTable
        Get
            Return "dsExtrato"
        End Get
    End Property

    Public Class ItemExtrato
        Public Property ContaCorrente As String
        Public Property LimiteCheque As Decimal
        Public Property SaldoBloqueado As Decimal
        Public Property SaldoDisponivel As Decimal
        Public Property SaldoInicio As Decimal
        Public Property DataLancamento As Date
        Public Property NumeroDoc As String
        Public Property Historico As String
        Public Property ValorLancamento As Decimal
        Public Property SaldoLinha As Decimal
        Public Property DCSaldoLinha As String
        Public Property DCSaldoValor As String
        Public Property DataExtrato As Date
    End Class

    Public Class ItemExtratoColumns
        Public Const ContaCorrente As String = "ContaCorrente"
        Public Const LimiteCheque As String = "LimiteCheque"
        Public Const SaldoBloqueado As String = "SaldoBloqueado"
        Public Const SaldoInicio As String = "SaldoInicio"
        Public Const SaldoTotal As String = "SaldoTotal"
        Public Const DataLancamento As String = "DataLancamento"
        Public Const NumeroDoc As String = "NumeroDoc"
        Public Const Historico As String = "Historico"
        Public Const ValorLancamento As String = "ValorLancamento"
        Public Const SaldoLinha As String = "SaldoLinha"
        Public Const DCSaldoLinha As String = "DCSaldoLinha"
        Public Const DCSaldoValor As String = "DCSaldoValor"
        Public Const DataExtrato As String = "DataExtrato"
    End Class

End Class
