﻿Public Interface IRemessa

    ReadOnly Property Layout As LayoutsDescricao
    Property NSA As String
    Property BancoCodigo As Integer
    Property DataGeracao As Date
    Property DataGravacao As Date
    Property HoraGeracao As DateTime
    Property Mensagem01 As String
    Property Mensagem02 As String
    Property MensagemEmpresa As String
    Property DadosCedente As InfoCedente
    Property Itens As List(Of InfoRemessa)
    Function GetArquivoRemessa() As String()

End Interface
