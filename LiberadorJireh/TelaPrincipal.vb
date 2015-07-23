Imports JirehBDUtil
Public Class TelaPrincipal

    Public Sub TratarErros(ByVal ex As Exception)
        HabilitarControles(False)
        Try

            JirehBDUtil.TratarErros.Add(ex, "Ativador Jireh", Date.Now)
            Alerta("Ocorreu um erro no sistema que foi enviado para correção. Menssagem = " & vbCrLf & ex.Message)

        Catch exx As Exception
            Alerta("Não foi possível validar os erros que ocorreu " & exx.Message & vbCrLf & "Erro que ocorreu no sistema : " & ex.Message)
        End Try
    End Sub

    Public Sub Alerta(ByVal msg As String)
        MessageBox.Show(msg, "Informação.", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private EmpresaSelecionada As Dal_Empresas.EmpresasColunms
    Private GerEmpresas As Dal_Empresas
    Private Carregando As Boolean

#Region "Maquinas, classe e seleção"

    Private Class MaquinaSelecionada
        Public Property Data As DateTime
        Public Property Ativo As Boolean
        Public Property Terminal As Integer
        Public Property Codigo As Integer
        Public Property Serial As String
        Public Sub New()
            Codigo = -1
        End Sub
    End Class

    Private Function GetMaquina() As MaquinaSelecionada
        Try
            Dim aux As Object
            aux = lbMaquinas.SelectedItem
            Dim i As Integer = lbMaquinas.SelectedIndex
            If aux Is Nothing OrElse String.IsNullOrEmpty(aux) OrElse i <= 0 Then
                Return New MaquinaSelecionada
            End If
            Dim aux2 As String() = aux.ToString.Split("|")

            Dim novo As New MaquinaSelecionada
            novo.Data = aux2(0).Replace("_", "").Trim.ToDate
            novo.Ativo = aux2(1).Replace("_", "").Trim.ToBool
            novo.Terminal = aux2(2).Replace("_", "").Trim.ToInteger
            novo.Codigo = aux2(3).Replace("_", "").Trim.ToInteger
            novo.Serial = aux2(4).Replace("_", "").Trim.ToString
            Return novo
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Sub CarregarMaquinas(ByVal Maquinas As List(Of Dal_MaquinasAtivasItens.MaquinasAtivasItensSerialColunms))
        Try
            lbMaquinas.Items.Clear()
            lbMaquinas.Items.Add("___Data___|_Ativo_|_Terminal_|___Código___|_Serial___")

            If Maquinas Is Nothing OrElse Maquinas.Count = 0 Then
                Exit Sub
            End If

            lbMaquinas.Items.AddRange(Maquinas.AsEnumerable.Select(Function(x)
                                                                       Dim aux As String = String.Empty
                                                                       aux = x.Cadastro_mai.ToString("dd/MM/yyyy") & "|"
                                                                       aux &= "__" & IIf(x.Ativou_mai, "SIM", "NÃO") & "__|"
                                                                       aux &= "___" & x.Estacao_sem.ToString("0000") & "___|"
                                                                       aux &= "__" & x.CodigoSer_mai.ToString("00000000") & "__|"
                                                                       aux &= "_" & x.Serial_ser
                                                                       Return aux
                                                                   End Function).ToArray)

        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region

#Region "Convenios, classe e seleção"

    Private Class ConveniosSelecionado
        Public Property Ativo As Boolean
        Public Property Convenio As String
        Public Sub New()
            Convenio = String.Empty
        End Sub
    End Class

    Private Function GetConvenio() As ConveniosSelecionado
        Try
            Dim aux As Object
            aux = lbConvenios.SelectedItem
            Dim i As Integer = lbConvenios.SelectedIndex
            If aux Is Nothing OrElse String.IsNullOrEmpty(aux) OrElse i <= 0 Then
                Return New ConveniosSelecionado
            End If
            Dim aux2 As String() = aux.ToString.Split("|")

            Dim novo As New ConveniosSelecionado
            novo.Ativo = aux2(0).Replace("_", "").Trim.ToBool
            novo.Convenio = aux2(1).Replace("_", "").ToString.Trim
            Return novo
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Sub CarregarConvenios(ByVal Cnpj As String)
        Try

            lbConvenios.Items.Clear()
            lbConvenios.Items.Add("_Ativo_|_Convênio_")

            Dim Ger As New Dal_ConveniosEmpresa(CnMySQL, GerEmpresas.Transacao)
            Dim lista As List(Of Dal_ConveniosEmpresa.ConveniosEmpresaColunms) = Ger.Consultar(Cnpj)

            If lista Is Nothing OrElse lista.Count = 0 Then
                Exit Sub
            End If

            lbConvenios.Items.AddRange(lista.AsEnumerable.Select(Function(x)
                                                                     Dim aux As String = String.Empty
                                                                     aux = "__" & IIf(x.Ativo_eco, "SIM", "NÃO") & "__|"
                                                                     aux &= " " & x.Convenio_eco
                                                                     Return aux
                                                                 End Function).ToArray)
        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region

    Private Function GetEmpresa() As String
        Try
            Dim aux As Object
            aux = lbEmpresas.SelectedItem
            If aux Is Nothing OrElse String.IsNullOrEmpty(aux) Then
                HabilitarControles(False)
                Return String.Empty
            End If
            Dim aux2 As String = aux.ToString.Split("|")(0)
            aux2 = aux2.Replace("_", "")
            HabilitarControles(True)
            Return aux2.Trim
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Sub CarregarEmpresas()
        Try
            Dim Tabela As DataTable = GerEmpresas.Consultar

            lbEmpresas.Items.Clear()
            lbEmpresas.Items.AddRange(Tabela.AsEnumerable.Select(Function(x)
                                                                     Dim aux As String = String.Empty
                                                                     Dim aux2 As String = x.Field(Of String)(Dal_Empresas.EmpresasColunmsName.Cnpj_emp).ToString
                                                                     If aux2.Length <> 18 Then
                                                                         aux2 = "___" & aux2
                                                                     End If
                                                                     aux &= aux2 & " | "
                                                                     aux2 = IIf(x.Field(Of Boolean)(Dal_Empresas.EmpresasColunmsName.Ativo_emp).ToBool, "__Ativo", "InAtivo")
                                                                     aux &= aux2 & " | "
                                                                     aux &= x.Field(Of String)(Dal_Empresas.EmpresasColunmsName.RazaoSocial_emp).ToString
                                                                     Return aux
                                                                 End Function).ToArray)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub HabilitarControles(ByVal Value As Boolean)
        btnAtualizarQtd.Enabled = Value
        btnMaqExcluir.Enabled = Value
        btnMaqLiberar.Enabled = Value
        btnAtualizarEmpresa.Enabled = Value
        btnExcluirEmpresa.Enabled = Value
        btnIncluirEmpresa.Enabled = Value
        btnAtivoConvenio.Enabled = Value
        btnExcluirConvenio.Enabled = Value
        btnIncluirConvenio.Enabled = Value
    End Sub

    Private Sub TelaPrincipal_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not OpenConexaoMySQL() Then
                Alerta(OpenConexaoMySQLMensagem)
                Close()
            End If

            EmpresaSelecionada = Nothing
            GerEmpresas = New Dal_Empresas(CnMySQL)
            CarregarEmpresas()
            Carregando = False
            txtCadastro.Text = Date.Now.ToString("dd/MM/yyyy")

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub lbEmpresas_TextChanged(sender As Object, e As EventArgs) Handles lbEmpresas.TextChanged, lbEmpresas.TabIndexChanged, lbEmpresas.Click
        Try
            Dim Cnpj As String = GetEmpresa()
            If String.IsNullOrEmpty(Cnpj) Then
                Exit Sub
            End If

            Carregando = True

            EmpresaSelecionada = GerEmpresas.Consultar(Cnpj)

            If EmpresaSelecionada.Ativo_emp Then
                rbAtivo.Checked = True
                rbInativo.Checked = False
            Else
                rbAtivo.Checked = False
                rbInativo.Checked = True
            End If

            If EmpresaSelecionada.Cnpj_emp.Length = 18 Then
                cboTipoPessoa.SelectedIndex = 0
            Else
                cboTipoPessoa.SelectedIndex = 1
            End If
            txtCnpj.Text = EmpresaSelecionada.Cnpj_emp
            txtFantasia.Text = EmpresaSelecionada.Fantasia_emp
            txtRazao.Text = EmpresaSelecionada.RazaoSocial_emp
            txtCadastro.Text = EmpresaSelecionada.Cadastro_emp.ToString("dd/MM/yyyy")
            If EmpresaSelecionada.Vencimento_emp = DateTime.MinValue Then
                txtVencimento.Value = Date.Now
                cboSemVencimento.Checked = True
            Else
                txtVencimento.Value = EmpresaSelecionada.Vencimento_emp
                cboSemVencimento.Checked = False
            End If

            Dim GerMaquinas As New Dal_MaquinasAtivasItens(CnMySQL, GerEmpresas.Transacao)
            Dim Item As Dal_MaquinasAtivasItens.MaquinasAtivasEmpresasColunms = GerMaquinas.Consultar(EmpresaSelecionada.Cnpj_emp)
            txtQuantidade.Value = Item.Quantidade_maa

            CarregarMaquinas(Item.Maquinas)
            CarregarConvenios(EmpresaSelecionada.Cnpj_emp)

            Carregando = False
        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub rbAtivo_CheckedChanged(sender As Object, e As EventArgs) Handles rbAtivo.CheckedChanged, rbInativo.CheckedChanged
        Try
            If EmpresaSelecionada Is Nothing OrElse Carregando Then
                Exit Sub
            End If

            If String.IsNullOrEmpty(EmpresaSelecionada.Cnpj_emp) Then
                Alerta("Empresa não encontrada")
                Exit Sub
            End If

            If rbAtivo.Checked Then
                EmpresaSelecionada.Ativo_emp = True
            ElseIf rbInativo.Checked Then
                EmpresaSelecionada.Ativo_emp = False
            End If

            GerEmpresas.Alterar(EmpresaSelecionada)

            Dim aux As String = IIf(EmpresaSelecionada.Ativo_emp, "Ativou", "InAtivou")

            Alerta(aux & " a empresa com sucesso.")

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

#Region "Visão Nova Empresa"

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

    Private Sub txtCnpj_LostFocus(sender As Object, e As EventArgs) Handles txtCnpj.LostFocus
        Try
            If Not txtCnpj.Text.IsCpfOrCnpjValid Then
                Alerta("CPF ou CNPJ informado inválido.")
                txtCnpj.Focus()
            End If
        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub btnIncluirEmpresa_Click(sender As Object, e As EventArgs) Handles btnIncluirEmpresa.Click
        Try
            Dim novo As New Dal_Empresas.EmpresasColunms

            novo.Ativo_emp = True
            novo.Cadastro_emp = Date.Now
            novo.Cnpj_emp = txtCnpj.Text
            novo.Fantasia_emp = IIf(String.IsNullOrEmpty(txtFantasia.Text), txtRazao.Text, txtFantasia.Text)
            novo.RazaoSocial_emp = txtRazao.Text
            If cboSemVencimento.Checked Then
                novo.Vencimento_emp = DateTime.MinValue
            Else
                novo.Vencimento_emp = txtVencimento.Value
            End If

            If Not ValidarCamposObrigatorios(novo) Then
                Exit Sub
            End If

            Dim aux As Dal_Empresas.EmpresasColunms = GerEmpresas.Consultar(novo.Cnpj_emp)
            If aux IsNot Nothing AndAlso aux.Cnpj_emp = novo.Cnpj_emp Then
                Alerta("O Cnpj ou Cpf informado já está cadastrado para esse nome " & aux.RazaoSocial_emp)
                Exit Sub
            End If

            GerEmpresas.Inserir(novo)

            Alerta("Empresa incluída com sucesso.")
            CarregarEmpresas()

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Function ValidarCamposObrigatorios(ByVal novo As Dal_Empresas.EmpresasColunms) As Boolean
        If String.IsNullOrEmpty(novo.Cnpj_emp) Then
            Alerta("Informe o CPF ou CNPJ")
            Return False
        End If
        If String.IsNullOrEmpty(novo.RazaoSocial_emp) Then
            Alerta("Informe a Razão social")
            Return False
        End If
        If novo.Vencimento_emp = DateTime.MinValue AndAlso Not cboSemVencimento.Checked Then
            Alerta("Data de vencimento inválida")
            Return False
        End If
        Return True
    End Function

    Private Sub btnAtualizarEmpresa_Click(sender As Object, e As EventArgs) Handles btnAtualizarEmpresa.Click
        Try
            If EmpresaSelecionada.Cnpj_emp <> txtCnpj.Text Then
                Alerta("Não tem como alterar o CNPJ ou CPF de uma empresa, é necessário incluir o novo CNPJ e excluir o outro inativo.")
                Exit Sub
            End If

            If Not ValidarCamposObrigatorios(EmpresaSelecionada) Then
                Exit Sub
            End If

            GerEmpresas.Alterar(EmpresaSelecionada)

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub btnExcluirEmpresa_Click(sender As Object, e As EventArgs) Handles btnExcluirEmpresa.Click
        Dim tx As MySQLTransacao = GerEmpresas.Transacao
        Try
            Dim aux As Dal_Empresas.EmpresasColunms = GerEmpresas.Consultar(EmpresaSelecionada.Cnpj_emp)
            If aux Is Nothing OrElse String.IsNullOrEmpty(aux.Cnpj_emp) Then
                Alerta("O Cnpj ou Cpf informado não está cadastrado")
                Exit Sub
            End If
            If MessageBox.Show("Será excluído todos os dados dessa empresa. Deseja continuar?", "Excluir???", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            CnMySQL.Open()
            tx.BeginTransacao()

            Dim MaIt As New Dal_MaquinasAtivasItens(CnMySQL, tx)
            MaIt.Excluir(aux.Cnpj_emp)

            Dim EmMa As New Dal_SerialEmpresas(CnMySQL, tx)
            EmMa.Excluir(aux.Cnpj_emp)

            Dim Ma As New Dal_MaquinasAtivas(CnMySQL, tx)
            Ma.Excluir(aux.Cnpj_emp)

            Dim EmCo As New Dal_ConveniosEmpresa(CnMySQL, tx)
            EmCo.Excluir(aux.Cnpj_emp)

            Dim MaSe As New Dal_SerialEmpresas(CnMySQL, tx)
            MaSe.Excluir(aux.Cnpj_emp)

            GerEmpresas.Excluir(aux.Cnpj_emp)

            tx.CommitTransacao()

            Alerta("A empresa foi excluída com sucesso.")

            CarregarEmpresas()
        Catch ex As Exception
            tx.RollBackTransacao()
            TratarErros(ex)
        Finally
            CnMySQL.Close()
        End Try
    End Sub

#End Region

#Region "Controle das maquinas nas empresas"

    Private Sub btnAtualizarQtd_Click(sender As Object, e As EventArgs) Handles btnAtualizarQtd.Click
        Try
            If EmpresaSelecionada Is Nothing OrElse Carregando Then
                Exit Sub
            End If

            Dim Ger As New Dal_MaquinasAtivas(CnMySQL, GerEmpresas.Transacao)
            Dim item As Dal_MaquinasAtivas.MaquinasAtivasColunms = Ger.Consultar(EmpresaSelecionada.Cnpj_emp)

            item.Quantidade_maa = txtQuantidade.Value
            If String.IsNullOrEmpty(item.CnpjEmp_maa) Then
                item.CnpjEmp_maa = EmpresaSelecionada.Cnpj_emp
                Ger.Inserir(item)
            Else
                Ger.Alterar(item)
            End If

            Alerta("Foi atualizado com sucesso os terminais de uso da empresa.")

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub btnMaqLiberar_Click(sender As Object, e As EventArgs) Handles btnMaqLiberar.Click
        Try
            Dim maq As MaquinaSelecionada = GetMaquina()
            If maq.Codigo = -1 Then
                Alerta("Não existe nenhuma maquina selecionada para liberar a ativação")
                Exit Sub
            End If

            HabilitarControles(False)
            My.Application.DoEvents()

            Dim Ger As New Dal_MaquinasAtivasItens(CnMySQL, GerEmpresas.Transacao)
            Dim Item As New Dal_MaquinasAtivasItens.MaquinasAtivasItensColunms
            Item.Ativou_mai = Not maq.Ativo
            Item.Cadastro_mai = maq.Data
            Item.CnpjEmp_mai = EmpresaSelecionada.Cnpj_emp
            Item.CodigoSer_mai = maq.Codigo

            Ger.Alterar(Item)

            Dim GerMaquinas As New Dal_MaquinasAtivasItens(CnMySQL, GerEmpresas.Transacao)
            Dim Dados As Dal_MaquinasAtivasItens.MaquinasAtivasEmpresasColunms = GerMaquinas.Consultar(EmpresaSelecionada.Cnpj_emp)
            CarregarMaquinas(Dados.Maquinas)

            Alerta("Maquina atualizada com sucesso.")

            HabilitarControles(True)

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub btnMaqExcluir_Click(sender As Object, e As EventArgs) Handles btnMaqExcluir.Click
        Try
            Dim maq As MaquinaSelecionada = GetMaquina()
            If maq.Codigo = -1 Then
                Alerta("Não existe nenhuma maquina selecionada para ser excluída")
                Exit Sub
            End If

            If MessageBox.Show("Será excluído a maquina selecionada desta empresa. Deseja continuar?", "Excluir???", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            HabilitarControles(False)
            My.Application.DoEvents()

            Dim Ger As New Dal_MaquinasAtivasItens(CnMySQL, GerEmpresas.Transacao)

            Ger.Excluir(EmpresaSelecionada.Cnpj_emp, maq.Codigo)

            Dim GerMaquinas As New Dal_MaquinasAtivasItens(CnMySQL, GerEmpresas.Transacao)
            Dim Dados As Dal_MaquinasAtivasItens.MaquinasAtivasEmpresasColunms = GerMaquinas.Consultar(EmpresaSelecionada.Cnpj_emp)
            CarregarMaquinas(Dados.Maquinas)

            Alerta("Maquina excluída com sucesso.")

            HabilitarControles(True)

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

#End Region

    Private Sub btnAtivoConvenio_Click(sender As Object, e As EventArgs) Handles btnAtivoConvenio.Click
        Try
            Dim Conv As ConveniosSelecionado = GetConvenio()
            If String.IsNullOrEmpty(Conv.Convenio) Then
                Alerta("Não existe nenhum convênio selecionado")
                Exit Sub
            End If

            HabilitarControles(False)
            My.Application.DoEvents()

            Dim Ger As New Dal_ConveniosEmpresa(CnMySQL, GerEmpresas.Transacao)
            Dim Item As New Dal_ConveniosEmpresa.ConveniosEmpresaColunms
            Item.Ativo_eco = Not Conv.Ativo
            Item.CnpjEmp_eco = EmpresaSelecionada.Cnpj_emp
            Item.Convenio_eco = Conv.Convenio

            Ger.Alterar(Item)

            CarregarConvenios(EmpresaSelecionada.Cnpj_emp)

            Alerta("Status do convênio alterado com sucesso")

            HabilitarControles(True)

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub btnExcluirConvenio_Click(sender As Object, e As EventArgs) Handles btnExcluirConvenio.Click
        Try
            Dim Conv As ConveniosSelecionado = GetConvenio()
            If String.IsNullOrEmpty(Conv.Convenio) Then
                Alerta("Não existe nenhum convênio selecionado")
                Exit Sub
            End If

            If MessageBox.Show("Será excluído o convênio selecionado desta empresa. Deseja continuar?", "Excluir???", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            HabilitarControles(False)
            My.Application.DoEvents()

            Dim Ger As New Dal_ConveniosEmpresa(CnMySQL, GerEmpresas.Transacao)
            Dim Item As New Dal_ConveniosEmpresa.ConveniosEmpresaColunms
            Item.Ativo_eco = Not Conv.Ativo
            Item.CnpjEmp_eco = EmpresaSelecionada.Cnpj_emp
            Item.Convenio_eco = Conv.Convenio

            Ger.Excluir(Item)

            CarregarConvenios(EmpresaSelecionada.Cnpj_emp)

            Alerta("Convênio excluido com sucesso")

            HabilitarControles(True)

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub btnIncluirConvenio_Click(sender As Object, e As EventArgs) Handles btnIncluirConvenio.Click
        Try
            If String.IsNullOrEmpty(txtNumConvenio.Text) Then
                Alerta("Informa o número do convênio")
                Exit Sub
            End If

            Dim Ger As New Dal_ConveniosEmpresa(CnMySQL, GerEmpresas.Transacao)
            Dim Item As Dal_ConveniosEmpresa.ConveniosEmpresaColunms = Ger.Consultar(EmpresaSelecionada.Cnpj_emp, txtNumConvenio.Text)

            If Item IsNot Nothing AndAlso Not String.IsNullOrEmpty(Item.Convenio_eco) Then
                Alerta("Este convênio já está cadastrado")
                Exit Sub
            End If

            HabilitarControles(False)
            My.Application.DoEvents()

            If Item Is Nothing Then
                Item = New Dal_ConveniosEmpresa.ConveniosEmpresaColunms
            End If
            Item.Ativo_eco = True
            Item.CnpjEmp_eco = EmpresaSelecionada.Cnpj_emp
            Item.Convenio_eco = txtNumConvenio.Text

            Ger.Incluir(Item)

            txtNumConvenio.Text = ""
            CarregarConvenios(EmpresaSelecionada.Cnpj_emp)

            Alerta("Convênio incluído com sucesso")

            HabilitarControles(True)

        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub
End Class
