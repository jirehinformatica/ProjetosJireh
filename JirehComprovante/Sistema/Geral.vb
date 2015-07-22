Public Module Geral

#Region "FORMULARIOS DO SISTEMA"

    Private MdiPrincipal As MdiComprovante
    Private FormAberto As Integer

    Public Property DataHoraServidor As DateTime

    Public Sub SetMDI(ByRef value As Form)
        FormAberto = 0
        MdiPrincipal = value
    End Sub

    Public ReadOnly Property FormularioMDI As MdiComprovante
        Get
            Return MdiPrincipal
        End Get
    End Property

    Public ReadOnly Property FormularioAberto As Boolean
        Get
            Return FormAberto > 0
        End Get
    End Property

    Public Sub FormOpenMDI(ByRef Value As Form)
        Try
            Value.MdiParent = MdiPrincipal
            FormAberto += 1
            Value.Show()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub FormCloseMDI(ByRef Value As Form)
        Try
            FormAberto -= 1
            Value.Dispose()
            Value = Nothing
        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region

#Region "VARIAVEIS GLOBAIS"

    Public Property CanceladoPorUsuario As Boolean

#End Region

    Public Sub Alerta(ByVal msg As String)
        MessageBox.Show(msg, "Informação.", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub TratarErros(ByVal ex As Exception)

    End Sub


End Module
