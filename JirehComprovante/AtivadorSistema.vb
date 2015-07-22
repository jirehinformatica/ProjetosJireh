Imports JirehBDUtil
Public Class AtivadorSistema

    Private info As Dal_SerialHd.SerialHDEmpresaColunms

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Try

            If String.IsNullOrEmpty(txtCnpj.Text) OrElse txtCnpj.Text.Trim = ".   .   /    -" OrElse txtCnpj.Text.Trim = ".   .   -" Then
                Alerta(String.Format("O {0} é necessário para realizar a ativação do sistema.", IIf(cboTipoPessoa.SelectedIndex = 0, "CNPJ", "CPF")))
                Exit Sub
            End If

            lblStatus.Text = "Verificando se o hardware já foi cadastrado para está inscrição."

            Dim Tx As New MySQLTransacao(CnMySQL)
            Dim GerLocal As New Dal_SerialHd(CnMySQL, Tx)
            Dim aux As Dal_SerialHd.SerialHDEmpresaColunms = GerLocal.ConsultarEmpresa(InfoRegistro.InformacoesUso.Serial, txtCnpj.Text)

            lblStatus.Text = "Preparando para enviar as informações para ativar o hardware."

            If info IsNot Nothing AndAlso aux IsNot Nothing Then

                If info.Cnpj_emp <> aux.Cnpj_emp Then
                    Alerta("ATENÇÃO!!!" & vbNewLine & "Este hardware está registrado para outra inscrição. Será feito uma tentativa de validação para esta inscrição.")
                End If
                If aux.SerialAtivo IsNot Nothing AndAlso aux.SerialAtivo.CodigoSer_mai <> 0 AndAlso aux.SerialAtivo.CnpjEmp_mai <> info.Cnpj_emp Then
                    Alerta("Não é possível ativar este hadware para essa inscrição. Este hardware está registrado para outro número de inscrição. Entre em contato com o suporte.")
                    Exit Sub
                End If
                If Not aux.Ativo_emp AndAlso Not String.IsNullOrEmpty(aux.Cnpj_emp) Then
                    Alerta("A inscrição informada está inativa. Entre em contato com o suporte.")
                    Close()
                End If

            ElseIf aux IsNot Nothing Then

                If Not aux.Ativo_emp AndAlso Not String.IsNullOrEmpty(aux.Cnpj_emp) Then
                    Alerta("A inscrição informada está inativa. Entre em contato com o suporte.")
                    Close()
                End If

            End If

            Try
                Dim GerSer As New Dal_SerialEmpresas(CnMySQL, Tx)
                Dim GerEmp As New Dal_Empresas(CnMySQL, Tx)
                Dim auxSer As Dal_SerialEmpresas.SerialEmpresasColunms = Nothing
                Dim auxEmp As New Dal_Empresas.EmpresasColunms

                lblStatus.Text = "Enviando informações da empresa. Aguarde..."

                CnMySQL.Open()
                Tx.BeginTransacao()

                auxEmp = GerEmp.Consultar(txtCnpj.Text)
                Dim existe As Boolean = Not String.IsNullOrEmpty(auxEmp.Cnpj_emp)
                If Not existe Then
                    auxEmp.Ativo_emp = True
                    auxEmp.Cadastro_emp = DataHoraServidor
                    auxEmp.Cnpj_emp = txtCnpj.Text
                    If String.IsNullOrEmpty(txtRazaoSocial.Text) Then
                        auxEmp.RazaoSocial_emp = "Não informado"
                    Else
                        auxEmp.RazaoSocial_emp = txtRazaoSocial.Text
                    End If
                    auxEmp.Fantasia_emp = auxEmp.RazaoSocial_emp
                    auxEmp.Vencimento_emp = DateTime.MinValue
                Else
                    If Not String.IsNullOrEmpty(txtRazaoSocial.Text) Then
                        auxEmp.RazaoSocial_emp = txtRazaoSocial.Text
                    End If
                    If String.IsNullOrEmpty(auxEmp.Fantasia_emp) Then
                        auxEmp.Fantasia_emp = auxEmp.RazaoSocial_emp
                    End If
                End If
                lblStatus.Text = "Validando a inscrição informada."
                If existe Then
                    GerEmp.Alterar(auxEmp)
                    auxSer = GerSer.ConsultarCnpjPorSerialLista(InfoRegistro.InformacoesUso.Serial, auxEmp.Cnpj_emp)
                Else
                    GerEmp.Inserir(auxEmp)
                End If

                If auxSer Is Nothing Then
                    lblStatus.Text = "Vinculando o hardware com a inscrição informada."
                    auxSer = New Dal_SerialEmpresas.SerialEmpresasColunms
                    auxSer.CnpjEmp_sem = txtCnpj.Text
                    auxSer.CodigoSer_sem = GerLocal.Consultar(InfoRegistro.InformacoesUso.Serial)
                    GerSer.Inserir(auxSer)
                End If

                Tx.CommitTransacao()

                lblStatus.Text = "Gravando todas as informações local."

                Dim GerHd As New Dal_SerialHd(CnMySQL)

                info = GerHd.ConsultarEmpresa(InfoRegistro.InformacoesUso.Serial, auxSer.CnpjEmp_sem)

                Alerta("Informações enviadas com sucesso. Pronto para ativar o sistema.")

                lblStatus.Text = "Informações enviadas com sucesso."

                btnContinuar.Enabled = True

            Catch ex As Exception
                Tx.RollBackTransacao()
                TratarErros(ex)
            Finally
                CnMySQL.Close()
            End Try

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub btnContinuar_Click(sender As Object, e As EventArgs) Handles btnContinuar.Click
        Try
            Dim Liberar As New Dal_MaquinasAtivasItens(CnMySQL)
            Dim Maquina As Dal_MaquinasAtivasItens.MaquinasAtivasEmpresasColunms
            Maquina = Liberar.Consultar(info.Cnpj_emp)

            lblStatus.Text = "Iniciando o processo. Aguarde."

            If Maquina Is Nothing OrElse String.IsNullOrEmpty(Maquina.CnpjEmp_maa) Then
                lblStatus.Text = ""
                Alerta("Não foi liberado o registro para este hardware. Entre em contato com o suporte.")
                Close()
                Exit Sub
            End If

            Dim valido As Boolean = (Maquina.Quantidade_maa > 0 AndAlso Maquina.Maquinas IsNot Nothing AndAlso Maquina.Maquinas.Count <= Maquina.Quantidade_maa) _
                OrElse (Maquina.Quantidade_maa > 0 AndAlso Maquina.Maquinas Is Nothing)

            lblStatus.Text = "Verificando se o sistema já foi ativado."

            Dim aux As Dal_MaquinasAtivasItens.MaquinasAtivasItensSerialColunms = Maquina.ConsultarSerial(InfoRegistro.InformacoesUso.Serial)
            If aux IsNot Nothing AndAlso aux.Ativou_mai Then
                Alerta("Este hardware já está registrado. Não é possível ativá-lo novamente. Entre em contato com o suporte.")
                Close()
                Exit Sub
            ElseIf aux IsNot Nothing Then
                Liberar.Excluir(aux.CnpjEmp_mai, aux.CodigoSer_mai)
            End If

            If valido Then
                lblStatus.Text = "Ativando o sistema. Aguarde..."
                Dim Ger As New Dal_SerialHd(CnMySQL)
                Dim Numero As Integer = Ger.Consultar(InfoRegistro.InformacoesUso.Serial)
                InfoRegistro.RegistrarPc(info.Cnpj_emp, Numero, DataHoraServidor)
            Else
                lblStatus.Text = ""
                Alerta("Não foi liberado o registro para este hardware. Entre em contato com o suporte.")
            End If

            Me.Close()
        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub AtivadorSistema_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            cboTipoPessoa.SelectedIndex = 0
            txtCnpj.Mask = "00,000,000/0000-00"
            lblValidarCnpj.Text = String.Empty
            btnContinuar.Enabled = False

            lblStatus.Text = "Buscando serial de ativação, aguarde..."
            My.Application.DoEvents()

            Dim aux As List(Of Dal_SerialHd.SerialHDEmpresaColunms)
            Dim Ger As New Dal_SerialHd(CnMySQL)
            aux = Ger.ConsultarEmpresa(InfoRegistro.InformacoesUso.Serial)

            If aux IsNot Nothing AndAlso aux.Count > 0 Then
                info = (From i In aux.AsEnumerable Where ((i.SerialAtivo IsNot Nothing AndAlso i.SerialAtivo.CnpjEmp_mai = i.Cnpj_emp) OrElse (i.SerialCadastrados IsNot Nothing _
                                                          AndAlso i.SerialCadastrados.Count = 1 AndAlso i.SerialCadastrados(0).CnpjEmp_sem = i.Cnpj_emp))).FirstOrDefault
            End If

            If info IsNot Nothing Then
                If info.Cnpj_emp.Length = 14 Then
                    cboTipoPessoa.SelectedIndex = 1
                End If
                txtCnpj.Text = info.Cnpj_emp
                txtRazaoSocial.Text = info.RazaoSocial_emp
            Else
                lblStatus.Text = "Verificando se o PC pode ser ativado."
                Ger.Inserir(InfoRegistro.InformacoesUso.Serial)
            End If

            lblStatus.Text = ""

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub cboTipoPessoa_TextChanged(sender As Object, e As EventArgs) Handles cboTipoPessoa.TextChanged
        Try
            If cboTipoPessoa.SelectedIndex = 0 Then
                txtCnpj.Mask = "00,000,000/0000-00"
            Else
                txtCnpj.Mask = "000,000,000-00"
            End If
        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

End Class