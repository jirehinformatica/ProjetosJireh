Public Class LayoutsDescricao

    Private CodigoValue As Integer
    Public ReadOnly Property Codigo As Integer
        Get
            Return CodigoValue
        End Get
    End Property

    Private DescricaoValue As Integer
    Public ReadOnly Property Descricao As Integer
        Get
            Return DescricaoValue
        End Get
    End Property

    Public ReadOnly Property TypeNameSpace As String
        Get
            Return System.Reflection.Assembly.GetEntryAssembly.GetName.Name
        End Get
    End Property

    Public ReadOnly Property TypeClassName As String
        Get
            Return Tipo.ToString
        End Get
    End Property

    Public ReadOnly Property Tipo As LayoutRemessa
        Get
            Return CodigoValue
        End Get
    End Property

    Public Sub New(ByVal vCodigo As Integer, ByVal vDescricao As String)
        Try
            CodigoValue = vCodigo
            DescricaoValue = vDescricao
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
