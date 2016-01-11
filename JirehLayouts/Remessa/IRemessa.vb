Public Interface IRemessa

    Property NSA As String
    Property BancoCodigo As Integer
    Property DataGeracao As Date
    Property DataGravacao As Date
    Property HoraGeracao As DateTime
    Property Mensagem01 As String
    Property Mensagem02 As String
    Property DadosCedente As InfoCedente
    Property Itens As List(Of InfoRemessa)

End Interface
