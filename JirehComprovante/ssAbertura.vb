Public NotInheritable Class ssAbertura

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).

    Public Sub AddPasso(ByVal Value As String)
        Try
            If lstAcao.Items.Count > 7 Then
                lstAcao.Items.RemoveAt(0)
            End If
            lstAcao.Items.Add(Value)

            My.Application.DoEvents()

        Catch ex As Exception
            Throw
        End Try
    End Sub


    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If My.Application.Info.Title <> "" Then
            lblAplicacaoNome.Text = My.Application.Info.Title
        Else
            lblAplicacaoNome.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        lblVersao.Text = System.String.Format("Versão {0}.{1:00}", My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
        lblCorporacao.Text = My.Application.Info.Copyright
    End Sub

End Class
