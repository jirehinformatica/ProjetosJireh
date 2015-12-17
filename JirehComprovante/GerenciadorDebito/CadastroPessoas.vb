Public Class CadastroPessoas

    Private filteredSource As BindingSource

    Private Sub CadastroPessoas_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            cboBanco.Items.Clear()
            cboBanco.Items.AddRange(JirehBDUtil.BuscarBancoNomes)

            DgvPessoas.MultiSelect = False
            DgvPessoas.Multiple_Rowselection = False

            Dim cep As New JirehBDUtil.GerenciadorCEP("74.730-090")

            Dim teste As New JirehBDUtil.Dal_Pessoas(JirehBDUtil.CnMySQL)
            Dim dt As DataTable = teste.ConsultarTable("80860958191")
            filteredSource = New BindingSource
            Dim dv As New DataView(dt, "", "", DataViewRowState.OriginalRows)
            filteredSource.DataSource = dv
            DgvPessoas.Bind_to_Bindingsource(filteredSource)

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub tsbNovo_Click(sender As Object, e As EventArgs) Handles tsbNovo.Click
        Try

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub tsbGravar_Click(sender As Object, e As EventArgs) Handles tsbGravar.Click
        Try

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub rbFisica_CheckedChanged(sender As Object, e As EventArgs) Handles rbFisica.CheckedChanged, rbJuridica.CheckedChanged
        Try
            If rbFisica.Checked Then
                lblNomeRazao.Text = "Nome da pessoa"
                lblCpfCnpj.Text = "CPF"
            Else
                lblNomeRazao.Text = "Razão social da empresa"
                lblCpfCnpj.Text = "CNPJ"
            End If
        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub btnConsultaCep_Click(sender As Object, e As EventArgs)
        Try
            If String.IsNullOrEmpty(JirehBDUtil.ToNumeros(txtCep.Text)) Then
                Alerta("Informe o cep para consulta.")
                Exit Sub
            End If

            Dim Consultar As New JirehBDUtil.GerenciadorCEP(txtCep.Text)

            If Not Consultar.CepEncontrado Then
                Alerta("O cep informado não foi encontrado ou a consulta dos correios está indisponível no momento.")
                Exit Sub
            End If

            txtLogradouro.Text = Consultar.Endereco.logradouro
            txtBairro.Text = Consultar.Endereco.bairro
            txtLocalidade.Text = Consultar.Endereco.localidade
            txtEstado.Text = Consultar.Endereco.uf.ToUpper

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub txtBanco_LostFocus(sender As Object, e As EventArgs) Handles txtBanco.LostFocus
        Try
            If txtBanco.Text.Trim = "" Then
                cboBanco.SelectedIndex = -1
                Exit Sub
            End If

            Dim Banco As JirehBDUtil.DadosBanco = JirehBDUtil.BuscarBanco(txtBanco.Text)
            If Banco.Nome = "" Then
                Alerta("Banco não encontrado na lista de bancos da Febraban.")
                txtBanco.Text = ""
                cboBanco.SelectedIndex = -1
            Else
                cboBanco.Text = Banco.Nome
            End If

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub cboBanco_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboBanco.SelectedValueChanged
        Try
            If cboBanco.Text.Trim = "" Then
                cboBanco.SelectedIndex = -1
                txtBanco.Text = ""
                Exit Sub
            End If

            Dim Banco As JirehBDUtil.DadosBanco = JirehBDUtil.BuscarBanco(, cboBanco.Text.Trim)
            If Banco.Nome = "" Then
                Alerta("Banco não encontrado na lista de bancos da Febraban.")
                txtBanco.Text = ""
                cboBanco.SelectedIndex = -1
            Else
                txtBanco.Text = Banco.Codigo
            End If

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub
End Class