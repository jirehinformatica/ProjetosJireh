Public MustInherit Class InfoPessoa

    Public Overridable Property CnpjCpf As String
    Public Overridable Property NomeRazao As String
    Public Overridable Property BancoCodigo As String
    'Não é necessário o nome do banco, isso será preenchido de forma automática
    Public Overridable Property BancoAgencia As String
    Public Overridable Property BancoAgenciaDig As String
    Public Overridable Property BancoContaCorr As String
    Public Overridable Property BancoContaCorrDig As String

End Class
