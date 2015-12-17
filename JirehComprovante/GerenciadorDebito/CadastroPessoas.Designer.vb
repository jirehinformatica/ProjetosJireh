<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CadastroPessoas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNovo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGravar = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtLocalidade = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBairro = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtComplemento = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLogradouro = New System.Windows.Forms.TextBox()
        Me.btnConsultaCep = New System.Windows.Forms.Button()
        Me.txtCep = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboBanco = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtBanco = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtContaCorrente = New System.Windows.Forms.TextBox()
        Me.txtAgencia = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOperacao = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbJuridica = New System.Windows.Forms.RadioButton()
        Me.rbFisica = New System.Windows.Forms.RadioButton()
        Me.lblNomeRazao = New System.Windows.Forms.Label()
        Me.txtNomeRazao = New System.Windows.Forms.TextBox()
        Me.txtCpfCnpj = New System.Windows.Forms.MaskedTextBox()
        Me.lblCpfCnpj = New System.Windows.Forms.Label()
        Me.DgvPessoas = New JirehDataGrid.SQLDatagridview()
        Me.CpfCnpj_pes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CnpjEmp_pes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomeRazao_pes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cadastro_pes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ativo_pes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CpfCnpjPes_cco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID_cco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cadastro_cco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Banco_cco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Agencia_cco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Operacao_cco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContaCorrente_cco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ativo_cco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsMenu.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgvPessoas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCaption
        '
        Me.lblCaption.BackColor = System.Drawing.Color.Ivory
        Me.lblCaption.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(0, 38)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(686, 23)
        Me.lblCaption.TabIndex = 1
        Me.lblCaption.Text = "Manutenção de pessoas"
        Me.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNovo, Me.tsbGravar})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(686, 38)
        Me.tsMenu.TabIndex = 0
        Me.tsMenu.Text = "ToolStrip1"
        '
        'tsbNovo
        '
        Me.tsbNovo.Image = Global.JirehComprovante.My.Resources.Resources.New24_24
        Me.tsbNovo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tsbNovo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNovo.Name = "tsbNovo"
        Me.tsbNovo.Size = New System.Drawing.Size(40, 35)
        Me.tsbNovo.Text = "&Novo"
        Me.tsbNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsbNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbNovo.ToolTipText = "Novo registro"
        '
        'tsbGravar
        '
        Me.tsbGravar.Image = Global.JirehComprovante.My.Resources.Resources.save24_24
        Me.tsbGravar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tsbGravar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGravar.Name = "tsbGravar"
        Me.tsbGravar.Size = New System.Drawing.Size(45, 35)
        Me.tsbGravar.Text = "&Gravar"
        Me.tsbGravar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsbGravar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbGravar.ToolTipText = "Gravar o registro"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.lblNomeRazao)
        Me.Panel1.Controls.Add(Me.txtNomeRazao)
        Me.Panel1.Controls.Add(Me.txtCpfCnpj)
        Me.Panel1.Controls.Add(Me.lblCpfCnpj)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 61)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(686, 242)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtEstado)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtLocalidade)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtBairro)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtComplemento)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtLogradouro)
        Me.GroupBox3.Controls.Add(Me.btnConsultaCep)
        Me.GroupBox3.Controls.Add(Me.txtCep)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 124)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(677, 108)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Dados endereço"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(627, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Estado"
        '
        'txtEstado
        '
        Me.txtEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtEstado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList
        Me.txtEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEstado.Location = New System.Drawing.Point(629, 75)
        Me.txtEstado.MaxLength = 2
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(38, 20)
        Me.txtEstado.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(317, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Localidade"
        '
        'txtLocalidade
        '
        Me.txtLocalidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtLocalidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList
        Me.txtLocalidade.Location = New System.Drawing.Point(319, 75)
        Me.txtLocalidade.MaxLength = 50
        Me.txtLocalidade.Name = "txtLocalidade"
        Me.txtLocalidade.Size = New System.Drawing.Size(300, 20)
        Me.txtLocalidade.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(9, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Bairro"
        '
        'txtBairro
        '
        Me.txtBairro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtBairro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList
        Me.txtBairro.Location = New System.Drawing.Point(11, 75)
        Me.txtBairro.MaxLength = 50
        Me.txtBairro.Name = "txtBairro"
        Me.txtBairro.Size = New System.Drawing.Size(300, 20)
        Me.txtBairro.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(415, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Complemento"
        '
        'txtComplemento
        '
        Me.txtComplemento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtComplemento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList
        Me.txtComplemento.Location = New System.Drawing.Point(417, 34)
        Me.txtComplemento.MaxLength = 25
        Me.txtComplemento.Name = "txtComplemento"
        Me.txtComplemento.Size = New System.Drawing.Size(250, 20)
        Me.txtComplemento.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(152, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Logradouro"
        '
        'txtLogradouro
        '
        Me.txtLogradouro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtLogradouro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList
        Me.txtLogradouro.Location = New System.Drawing.Point(154, 34)
        Me.txtLogradouro.MaxLength = 50
        Me.txtLogradouro.Name = "txtLogradouro"
        Me.txtLogradouro.Size = New System.Drawing.Size(250, 20)
        Me.txtLogradouro.TabIndex = 11
        '
        'btnConsultaCep
        '
        Me.btnConsultaCep.Image = Global.JirehComprovante.My.Resources.Resources.buscar_cep
        Me.btnConsultaCep.Location = New System.Drawing.Point(118, 31)
        Me.btnConsultaCep.Name = "btnConsultaCep"
        Me.btnConsultaCep.Size = New System.Drawing.Size(30, 25)
        Me.btnConsultaCep.TabIndex = 10
        Me.btnConsultaCep.UseVisualStyleBackColor = True
        '
        'txtCep
        '
        Me.txtCep.Location = New System.Drawing.Point(11, 34)
        Me.txtCep.Mask = "00.000-000"
        Me.txtCep.Name = "txtCep"
        Me.txtCep.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCep.Size = New System.Drawing.Size(103, 20)
        Me.txtCep.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(8, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Cep"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboBanco)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtBanco)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtContaCorrente)
        Me.GroupBox2.Controls.Add(Me.txtAgencia)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtOperacao)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 54)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(677, 64)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Dados bancário"
        '
        'cboBanco
        '
        Me.cboBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBanco.FormattingEnabled = True
        Me.cboBanco.Location = New System.Drawing.Point(70, 31)
        Me.cboBanco.Name = "cboBanco"
        Me.cboBanco.Size = New System.Drawing.Size(273, 21)
        Me.cboBanco.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(68, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Nome banco"
        '
        'txtBanco
        '
        Me.txtBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList
        Me.txtBanco.Location = New System.Drawing.Point(10, 31)
        Me.txtBanco.MaxLength = 5
        Me.txtBanco.Name = "txtBanco"
        Me.txtBanco.Size = New System.Drawing.Size(50, 20)
        Me.txtBanco.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(9, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Banco"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(530, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Conta corrente / digito"
        '
        'txtContaCorrente
        '
        Me.txtContaCorrente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtContaCorrente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList
        Me.txtContaCorrente.Location = New System.Drawing.Point(532, 31)
        Me.txtContaCorrente.MaxLength = 10
        Me.txtContaCorrente.Name = "txtContaCorrente"
        Me.txtContaCorrente.Size = New System.Drawing.Size(135, 20)
        Me.txtContaCorrente.TabIndex = 8
        '
        'txtAgencia
        '
        Me.txtAgencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtAgencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList
        Me.txtAgencia.Location = New System.Drawing.Point(352, 31)
        Me.txtAgencia.MaxLength = 5
        Me.txtAgencia.Name = "txtAgencia"
        Me.txtAgencia.Size = New System.Drawing.Size(90, 20)
        Me.txtAgencia.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(450, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Operação"
        '
        'txtOperacao
        '
        Me.txtOperacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtOperacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList
        Me.txtOperacao.Location = New System.Drawing.Point(452, 31)
        Me.txtOperacao.MaxLength = 3
        Me.txtOperacao.Name = "txtOperacao"
        Me.txtOperacao.Size = New System.Drawing.Size(70, 20)
        Me.txtOperacao.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(350, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Agência"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbJuridica)
        Me.GroupBox1.Controls.Add(Me.rbFisica)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(155, 42)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de pessoa"
        '
        'rbJuridica
        '
        Me.rbJuridica.AutoSize = True
        Me.rbJuridica.ForeColor = System.Drawing.Color.Blue
        Me.rbJuridica.Location = New System.Drawing.Point(66, 19)
        Me.rbJuridica.Name = "rbJuridica"
        Me.rbJuridica.Size = New System.Drawing.Size(63, 17)
        Me.rbJuridica.TabIndex = 1
        Me.rbJuridica.Text = "Jurídica"
        Me.rbJuridica.UseVisualStyleBackColor = True
        '
        'rbFisica
        '
        Me.rbFisica.AutoSize = True
        Me.rbFisica.Checked = True
        Me.rbFisica.ForeColor = System.Drawing.Color.Blue
        Me.rbFisica.Location = New System.Drawing.Point(6, 19)
        Me.rbFisica.Name = "rbFisica"
        Me.rbFisica.Size = New System.Drawing.Size(54, 17)
        Me.rbFisica.TabIndex = 0
        Me.rbFisica.TabStop = True
        Me.rbFisica.Text = "Física"
        Me.rbFisica.UseVisualStyleBackColor = True
        '
        'lblNomeRazao
        '
        Me.lblNomeRazao.AutoSize = True
        Me.lblNomeRazao.ForeColor = System.Drawing.Color.Blue
        Me.lblNomeRazao.Location = New System.Drawing.Point(286, 11)
        Me.lblNomeRazao.Name = "lblNomeRazao"
        Me.lblNomeRazao.Size = New System.Drawing.Size(35, 13)
        Me.lblNomeRazao.TabIndex = 4
        Me.lblNomeRazao.Text = "Nome"
        '
        'txtNomeRazao
        '
        Me.txtNomeRazao.Location = New System.Drawing.Point(289, 27)
        Me.txtNomeRazao.MaxLength = 80
        Me.txtNomeRazao.Name = "txtNomeRazao"
        Me.txtNomeRazao.Size = New System.Drawing.Size(391, 20)
        Me.txtNomeRazao.TabIndex = 3
        '
        'txtCpfCnpj
        '
        Me.txtCpfCnpj.Location = New System.Drawing.Point(166, 27)
        Me.txtCpfCnpj.Mask = "00..000.000/0000-00"
        Me.txtCpfCnpj.Name = "txtCpfCnpj"
        Me.txtCpfCnpj.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCpfCnpj.Size = New System.Drawing.Size(114, 20)
        Me.txtCpfCnpj.TabIndex = 2
        '
        'lblCpfCnpj
        '
        Me.lblCpfCnpj.AutoSize = True
        Me.lblCpfCnpj.ForeColor = System.Drawing.Color.Blue
        Me.lblCpfCnpj.Location = New System.Drawing.Point(163, 11)
        Me.lblCpfCnpj.Name = "lblCpfCnpj"
        Me.lblCpfCnpj.Size = New System.Drawing.Size(27, 13)
        Me.lblCpfCnpj.TabIndex = 0
        Me.lblCpfCnpj.Text = "CPF"
        '
        'DgvPessoas
        '
        Me.DgvPessoas.AllowUserToOrderColumns = True
        Me.DgvPessoas.Background_Color = System.Drawing.Color.White
        Me.DgvPessoas.BackgroundColor = System.Drawing.Color.White
        Me.DgvPessoas.Binding_Source = Nothing
        Me.DgvPessoas.Column_Reorder = True
        Me.DgvPessoas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPessoas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CpfCnpj_pes, Me.CnpjEmp_pes, Me.NomeRazao_pes, Me.Cadastro_pes, Me.Ativo_pes, Me.CpfCnpjPes_cco, Me.ID_cco, Me.Cadastro_cco, Me.Banco_cco, Me.Agencia_cco, Me.Operacao_cco, Me.ContaCorrente_cco, Me.Ativo_cco})
        Me.DgvPessoas.Combobox_Columns = Nothing
        Me.DgvPessoas.Connection_String = ""
        Me.DgvPessoas.Default_Values = Nothing
        Me.DgvPessoas.Defaultvalue_Columns = Nothing
        Me.DgvPessoas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPessoas.e = Nothing
        Me.DgvPessoas.Edit_Mode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DgvPessoas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DgvPessoas.Filter_Array = Nothing
        Me.DgvPessoas.Header_Height = 23
        Me.DgvPessoas.Header_Selected = 8
        Me.DgvPessoas.iColumn_Clicked = 0
        Me.DgvPessoas.Location = New System.Drawing.Point(0, 303)
        Me.DgvPessoas.Multiple_Rowselection = False
        Me.DgvPessoas.MultiSelect = False
        Me.DgvPessoas.Name = "DgvPessoas"
        Me.DgvPessoas.Rowheader_Visible = False
        Me.DgvPessoas.RowHeadersVisible = False
        Me.DgvPessoas.Size = New System.Drawing.Size(686, 182)
        Me.DgvPessoas.Sort_Array = Nothing
        Me.DgvPessoas.TabIndex = 16
        Me.DgvPessoas.Table_Name = ""
        '
        'CpfCnpj_pes
        '
        Me.CpfCnpj_pes.HeaderText = "CPF/CNPJ"
        Me.CpfCnpj_pes.Name = "CpfCnpj_pes"
        Me.CpfCnpj_pes.Width = 115
        '
        'CnpjEmp_pes
        '
        Me.CnpjEmp_pes.HeaderText = "CnpjEmp_pes"
        Me.CnpjEmp_pes.Name = "CnpjEmp_pes"
        Me.CnpjEmp_pes.Visible = False
        '
        'NomeRazao_pes
        '
        Me.NomeRazao_pes.HeaderText = "Nome/Razão Social"
        Me.NomeRazao_pes.Name = "NomeRazao_pes"
        Me.NomeRazao_pes.Width = 154
        '
        'Cadastro_pes
        '
        Me.Cadastro_pes.HeaderText = "Cadastro_pes"
        Me.Cadastro_pes.Name = "Cadastro_pes"
        Me.Cadastro_pes.Visible = False
        '
        'Ativo_pes
        '
        Me.Ativo_pes.HeaderText = "Ativo_pes"
        Me.Ativo_pes.Name = "Ativo_pes"
        Me.Ativo_pes.Visible = False
        '
        'CpfCnpjPes_cco
        '
        Me.CpfCnpjPes_cco.HeaderText = "CpfCnpjPes_cco"
        Me.CpfCnpjPes_cco.Name = "CpfCnpjPes_cco"
        Me.CpfCnpjPes_cco.Visible = False
        '
        'ID_cco
        '
        Me.ID_cco.HeaderText = "ID_cco"
        Me.ID_cco.Name = "ID_cco"
        Me.ID_cco.Visible = False
        '
        'Cadastro_cco
        '
        Me.Cadastro_cco.HeaderText = "Cadastro_cco"
        Me.Cadastro_cco.Name = "Cadastro_cco"
        Me.Cadastro_cco.Visible = False
        '
        'Banco_cco
        '
        Me.Banco_cco.HeaderText = "Banco"
        Me.Banco_cco.Name = "Banco_cco"
        Me.Banco_cco.Width = 105
        '
        'Agencia_cco
        '
        Me.Agencia_cco.HeaderText = "Agência"
        Me.Agencia_cco.Name = "Agencia_cco"
        Me.Agencia_cco.Width = 116
        '
        'Operacao_cco
        '
        Me.Operacao_cco.HeaderText = "Operacao_cco"
        Me.Operacao_cco.Name = "Operacao_cco"
        Me.Operacao_cco.Visible = False
        '
        'ContaCorrente_cco
        '
        Me.ContaCorrente_cco.HeaderText = "Conta Corrente"
        Me.ContaCorrente_cco.Name = "ContaCorrente_cco"
        Me.ContaCorrente_cco.Width = 168
        '
        'Ativo_cco
        '
        Me.Ativo_cco.HeaderText = "Ativo_cco"
        Me.Ativo_cco.Name = "Ativo_cco"
        Me.Ativo_cco.Visible = False
        '
        'CadastroPessoas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 485)
        Me.Controls.Add(Me.DgvPessoas)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CadastroPessoas"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de pessoas"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DgvPessoas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNovo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGravar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtCpfCnpj As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblCpfCnpj As System.Windows.Forms.Label
    Friend WithEvents lblNomeRazao As System.Windows.Forms.Label
    Friend WithEvents txtNomeRazao As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbJuridica As System.Windows.Forms.RadioButton
    Friend WithEvents rbFisica As System.Windows.Forms.RadioButton
    Friend WithEvents DgvPessoas As JirehDataGrid.SQLDatagridview
    Friend WithEvents CpfCnpj_pes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CnpjEmp_pes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomeRazao_pes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cadastro_pes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ativo_pes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CpfCnpjPes_cco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID_cco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cadastro_cco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Banco_cco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Agencia_cco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Operacao_cco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContaCorrente_cco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ativo_cco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtLocalidade As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBairro As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtComplemento As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLogradouro As System.Windows.Forms.TextBox
    Friend WithEvents btnConsultaCep As System.Windows.Forms.Button
    Friend WithEvents txtCep As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtContaCorrente As System.Windows.Forms.TextBox
    Friend WithEvents txtAgencia As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtOperacao As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBanco As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboBanco As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
