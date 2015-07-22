Public Interface ILayout
    ReadOnly Property NumeroBanco As Integer
    ReadOnly Property Eventos As JirehLayoutEventos
    ReadOnly Property LinhasCount As Long
    Function ArquivoValido(ByVal NumeroConvenios As String) As Boolean
End Interface
