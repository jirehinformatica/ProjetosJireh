Imports System.Reflection

Public Class ComprovantePagamentoReport
    Implements IReports

    Public ReadOnly Property NameEmblasededReport As String Implements IReports.NameEmblasededReport
        Get
            Return "JirehReports.ComprovantePagamento.rdlc"
        End Get
    End Property

    Public ReadOnly Property NameLocalReport As String Implements IReports.NameLocalReport
        Get
            Return "ComprovantePagamento.rdlc"
        End Get
    End Property

    Public ReadOnly Property NameTable As String Implements IReports.NameTable
        Get
            Return "dsRelatorioComprovante"
        End Get
    End Property

    Public Class ItemComprovantePagamento
        Public Property Favorecido As String
        Public Property CPF As String
        Public Property ContaCredito As String
        Public Property Banco As String
        Public Property Vencimento As DateTime
        Public Property Valor As Decimal
        Public Property AutenticacaoBancaria As String

        Public Property Empresa As String
        Public Property CNPJ As String
        Public Property ContaDebito As String

        Public Property NSA As String
        Public Property DataArquivo As DateTime
        Public Property TipoCompromisso As String
        Public Property Valido As Boolean
        Public Property Ocorrencia As String
    End Class

    Public Class ItemComprovantePagamentoColumns
        Public Const Favorecido As String = "Favorecido"
        Public Const CPF As String = "CPF"
        Public Const ContaCredito As String = "ContaCredito"
        Public Const ContaDebito As String = "ContaDebito"
        Public Const Empresa As String = "Empresa"
        Public Const CNPJ As String = "CNPJ"
        Public Const Banco As String = "Banco"
        Public Const Vencimento As String = "Vencimento"
        Public Const Valor As String = "Valor"
        Public Const AutenticacaoBancaria As String = "AutenticacaoBancaria"
        Public Const NSA As String = "NSA"
        Public Const DataArquivo As String = "DataArquivo"
        Public Const TipoCompromisso As String = "TipoCompromisso"
        Public Const Valido As String = "Valido"
    End Class

End Class
