Imports Microsoft.Win32

Public Class RegistroSistema

    Private ChavePrincipal As RegistryKey
    Private AplicacaoKey As RegistryKey

    Public Sub New(ByVal NomeAplicacao As String)
        ChavePrincipal = Registry.CurrentUser.OpenSubKey("Software", True)
        Dim nomes As String() = ChavePrincipal.GetSubKeyNames
        Dim achou As Boolean = False
        For Each s As String In nomes
            If s = NomeAplicacao Then
                achou = True
                Exit For
            End If
        Next
        If achou Then
            AplicacaoKey = ChavePrincipal.OpenSubKey(NomeAplicacao, True)
        Else
            AplicacaoKey = ChavePrincipal.CreateSubKey(NomeAplicacao)
        End If
    End Sub

    Public Sub SetValor(ByVal Chave As String, ByVal Valor As Object)
        ChavePrincipal.OpenSubKey(Chave)
        AplicacaoKey.SetValue(Chave, Valor)
    End Sub

    Public Function GetValor(ByVal Chave As String) As Object
        Return AplicacaoKey.GetValue(Chave)
    End Function

    Public Sub DeleteKey()
        ChavePrincipal.DeleteSubKey(AplicacaoKey.Name)
    End Sub

    Public Function ExisteKey(ByVal Chave As String) As Boolean
        Dim nomes As String() = AplicacaoKey.GetValueNames
        Dim achou As Boolean = False
        For Each s As String In nomes
            If s = Chave Then
                achou = True
                Exit For
            End If
        Next
        Return achou
    End Function

End Class
