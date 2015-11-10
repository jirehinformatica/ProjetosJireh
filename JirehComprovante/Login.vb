Imports JirehBDUtil

Public Class Login

    Private Const SenhaPadrao As String = "123456"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        EncerrarValue = False
        ValidoSenhaValue = False
        AguardarNovaSenha = False
        Tentativas = 0

    End Sub

    Private Tentativas As Integer
    Private AguardarNovaSenha As Boolean

    Private ValidoSenhaValue As Boolean
    Public ReadOnly Property ValidoSenha As Boolean
        Get
            Return ValidoSenhaValue
        End Get
    End Property

    Private EncerrarValue As Boolean
    Public ReadOnly Property Encerrar As Boolean
        Get
            Return EncerrarValue
        End Get
    End Property

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        EncerrarValue = True
        Me.Close()
    End Sub

    Private Sub btnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click
        Try
            Dim validar As Boolean = True
            Dim oConsulta As New JirehBDUtil.Dal_Usuarios(CnMySQL)
            Dim Usuario As Dal_Usuarios.UsuariosColunms
            Usuario = oConsulta.Consultar(JirehBDUtil.InfoRegistro.InformacoesUso.CNPJ, txtUsuario.Text)

            If String.IsNullOrEmpty(Usuario.Login_usu) Then
                Tentativas += 1
                Alerta("Usuário não cadastrado. Este usuário não foi cadastrado para utilizar com essa empresa.")
                validar = False
            End If

            If validar AndAlso Not Usuario.Ativo_usu Then
                Tentativas += 1
                Alerta("O usuário informado está inativo. Não é possível utilizar o sistema com esse usuário.")
                validar = False
            End If

            If validar AndAlso Not AguardarNovaSenha AndAlso Not Usuario.Senha_usu = txtSenha.Text Then
                Tentativas += 1
                Alerta("A senha informada é inválida. Informe a senha correta.")
                validar = False
            ElseIf validar AndAlso Not AguardarNovaSenha Then
                Tentativas = 0
            End If

            If validar AndAlso Usuario.Senha_usu = SenhaPadrao AndAlso txtSenha.Text = SenhaPadrao Then
                Tentativas += 1
                If AguardarNovaSenha Then
                    Alerta("Informe uma senha diferente de " & SenhaPadrao & ", essa senha não é válida para uso do sistema.")
                    validar = False
                End If
                Alerta("Usuário válido. Favor informar a nova senha e clique em entrar novamente")
                txtSenha.Text = ""
                AguardarNovaSenha = True
                validar = False
            End If

            If validar AndAlso AguardarNovaSenha Then
                Usuario.Senha_usu = txtSenha.Text
                oConsulta.Alterar(Usuario)
                Alerta("Senha atualizada com sucesso. Entrando no sistema.")
            End If

            If validar Then
                ValidoSenhaValue = True
                EncerrarValue = False
                Me.Close()
                Exit Sub
            End If

            If Tentativas > 4 Then
                Alerta("Foram feitas diversas tentativas sem sucesso. O sistema será encerrado. Se tiver duvidas para acessar o sistema entre em contato com o suporte.")
                EncerrarValue = True
                Me.Close()
            End If

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub
End Class