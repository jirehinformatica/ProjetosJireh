<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TelaPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TelaPrincipal))
        Me.tbGeral = New System.Windows.Forms.TabControl()
        Me.tpGeral = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnMaqExcluir = New System.Windows.Forms.Button()
        Me.btnMaqLiberar = New System.Windows.Forms.Button()
        Me.lbMaquinas = New System.Windows.Forms.ListBox()
        Me.btnAtualizarQtd = New System.Windows.Forms.Button()
        Me.txtQuantidade = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbInativo = New System.Windows.Forms.RadioButton()
        Me.rbAtivo = New System.Windows.Forms.RadioButton()
        Me.tpConvenios = New System.Windows.Forms.TabPage()
        Me.lbConvenios = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnExcluirConvenio = New System.Windows.Forms.Button()
        Me.btnAtivoConvenio = New System.Windows.Forms.Button()
        Me.btnIncluirConvenio = New System.Windows.Forms.Button()
        Me.txtNumConvenio = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tpNovoEmpresa = New System.Windows.Forms.TabPage()
        Me.btnExcluirEmpresa = New System.Windows.Forms.Button()
        Me.btnAtualizarEmpresa = New System.Windows.Forms.Button()
        Me.btnIncluirEmpresa = New System.Windows.Forms.Button()
        Me.txtCadastro = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFantasia = New System.Windows.Forms.TextBox()
        Me.txtRazao = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboSemVencimento = New System.Windows.Forms.CheckBox()
        Me.txtVencimento = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTipoPessoa = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCnpj = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbEmpresas = New System.Windows.Forms.ListBox()
        Me.tpTelas = New System.Windows.Forms.TabPage()
        Me.lsbTelas = New System.Windows.Forms.ListBox()
        Me.lsbTelasLiberadas = New System.Windows.Forms.ListBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnTelaAdd = New System.Windows.Forms.Button()
        Me.btnTelaRemove = New System.Windows.Forms.Button()
        Me.tbGeral.SuspendLayout()
        Me.tpGeral.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpConvenios.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tpNovoEmpresa.SuspendLayout()
        Me.tpTelas.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbGeral
        '
        Me.tbGeral.Controls.Add(Me.tpGeral)
        Me.tbGeral.Controls.Add(Me.tpConvenios)
        Me.tbGeral.Controls.Add(Me.tpNovoEmpresa)
        Me.tbGeral.Controls.Add(Me.tpTelas)
        Me.tbGeral.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tbGeral.Location = New System.Drawing.Point(0, 163)
        Me.tbGeral.Name = "tbGeral"
        Me.tbGeral.SelectedIndex = 0
        Me.tbGeral.Size = New System.Drawing.Size(618, 278)
        Me.tbGeral.TabIndex = 0
        '
        'tpGeral
        '
        Me.tpGeral.BackColor = System.Drawing.SystemColors.Control
        Me.tpGeral.Controls.Add(Me.GroupBox1)
        Me.tpGeral.Controls.Add(Me.lbMaquinas)
        Me.tpGeral.Controls.Add(Me.btnAtualizarQtd)
        Me.tpGeral.Controls.Add(Me.txtQuantidade)
        Me.tpGeral.Controls.Add(Me.Label2)
        Me.tpGeral.Controls.Add(Me.rbInativo)
        Me.tpGeral.Controls.Add(Me.rbAtivo)
        Me.tpGeral.Location = New System.Drawing.Point(4, 22)
        Me.tpGeral.Name = "tpGeral"
        Me.tpGeral.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGeral.Size = New System.Drawing.Size(610, 252)
        Me.tpGeral.TabIndex = 0
        Me.tpGeral.Text = "Geral"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnMaqExcluir)
        Me.GroupBox1.Controls.Add(Me.btnMaqLiberar)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(3, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(604, 50)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selecione a maquina para liberar ativação novamente (Ativo = Sim - maquina já foi" & _
    " ativada, não consegue ativar novamente)"
        '
        'btnMaqExcluir
        '
        Me.btnMaqExcluir.Enabled = False
        Me.btnMaqExcluir.Location = New System.Drawing.Point(523, 17)
        Me.btnMaqExcluir.Name = "btnMaqExcluir"
        Me.btnMaqExcluir.Size = New System.Drawing.Size(75, 23)
        Me.btnMaqExcluir.TabIndex = 3
        Me.btnMaqExcluir.Text = "Excluir"
        Me.btnMaqExcluir.UseVisualStyleBackColor = True
        '
        'btnMaqLiberar
        '
        Me.btnMaqLiberar.Enabled = False
        Me.btnMaqLiberar.Location = New System.Drawing.Point(398, 17)
        Me.btnMaqLiberar.Name = "btnMaqLiberar"
        Me.btnMaqLiberar.Size = New System.Drawing.Size(75, 23)
        Me.btnMaqLiberar.TabIndex = 2
        Me.btnMaqLiberar.Text = "Liberar"
        Me.btnMaqLiberar.UseVisualStyleBackColor = True
        '
        'lbMaquinas
        '
        Me.lbMaquinas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lbMaquinas.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMaquinas.FormattingEnabled = True
        Me.lbMaquinas.ItemHeight = 14
        Me.lbMaquinas.Location = New System.Drawing.Point(3, 105)
        Me.lbMaquinas.Name = "lbMaquinas"
        Me.lbMaquinas.Size = New System.Drawing.Size(604, 144)
        Me.lbMaquinas.TabIndex = 5
        '
        'btnAtualizarQtd
        '
        Me.btnAtualizarQtd.Enabled = False
        Me.btnAtualizarQtd.Location = New System.Drawing.Point(470, 14)
        Me.btnAtualizarQtd.Name = "btnAtualizarQtd"
        Me.btnAtualizarQtd.Size = New System.Drawing.Size(75, 23)
        Me.btnAtualizarQtd.TabIndex = 4
        Me.btnAtualizarQtd.Text = "Atualizar"
        Me.btnAtualizarQtd.UseVisualStyleBackColor = True
        '
        'txtQuantidade
        '
        Me.txtQuantidade.Location = New System.Drawing.Point(390, 15)
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.Size = New System.Drawing.Size(67, 20)
        Me.txtQuantidade.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(224, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Quantidade Maquinas Liberadas"
        '
        'rbInativo
        '
        Me.rbInativo.AutoSize = True
        Me.rbInativo.Location = New System.Drawing.Point(87, 17)
        Me.rbInativo.Name = "rbInativo"
        Me.rbInativo.Size = New System.Drawing.Size(57, 17)
        Me.rbInativo.TabIndex = 1
        Me.rbInativo.TabStop = True
        Me.rbInativo.Text = "Inativo"
        Me.rbInativo.UseVisualStyleBackColor = True
        '
        'rbAtivo
        '
        Me.rbAtivo.AutoSize = True
        Me.rbAtivo.Location = New System.Drawing.Point(19, 17)
        Me.rbAtivo.Name = "rbAtivo"
        Me.rbAtivo.Size = New System.Drawing.Size(49, 17)
        Me.rbAtivo.TabIndex = 0
        Me.rbAtivo.TabStop = True
        Me.rbAtivo.Text = "Ativo"
        Me.rbAtivo.UseVisualStyleBackColor = True
        '
        'tpConvenios
        '
        Me.tpConvenios.Controls.Add(Me.lbConvenios)
        Me.tpConvenios.Controls.Add(Me.GroupBox2)
        Me.tpConvenios.Location = New System.Drawing.Point(4, 22)
        Me.tpConvenios.Name = "tpConvenios"
        Me.tpConvenios.Padding = New System.Windows.Forms.Padding(3)
        Me.tpConvenios.Size = New System.Drawing.Size(610, 252)
        Me.tpConvenios.TabIndex = 1
        Me.tpConvenios.Text = "Convênios"
        Me.tpConvenios.UseVisualStyleBackColor = True
        '
        'lbConvenios
        '
        Me.lbConvenios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbConvenios.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbConvenios.FormattingEnabled = True
        Me.lbConvenios.ItemHeight = 14
        Me.lbConvenios.Location = New System.Drawing.Point(3, 56)
        Me.lbConvenios.Name = "lbConvenios"
        Me.lbConvenios.Size = New System.Drawing.Size(604, 193)
        Me.lbConvenios.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnExcluirConvenio)
        Me.GroupBox2.Controls.Add(Me.btnAtivoConvenio)
        Me.GroupBox2.Controls.Add(Me.btnIncluirConvenio)
        Me.GroupBox2.Controls.Add(Me.txtNumConvenio)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(604, 53)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Incluir novo convênio"
        '
        'btnExcluirConvenio
        '
        Me.btnExcluirConvenio.Location = New System.Drawing.Point(514, 17)
        Me.btnExcluirConvenio.Name = "btnExcluirConvenio"
        Me.btnExcluirConvenio.Size = New System.Drawing.Size(75, 23)
        Me.btnExcluirConvenio.TabIndex = 5
        Me.btnExcluirConvenio.Text = "Excluir"
        Me.btnExcluirConvenio.UseVisualStyleBackColor = True
        '
        'btnAtivoConvenio
        '
        Me.btnAtivoConvenio.Location = New System.Drawing.Point(352, 17)
        Me.btnAtivoConvenio.Name = "btnAtivoConvenio"
        Me.btnAtivoConvenio.Size = New System.Drawing.Size(87, 23)
        Me.btnAtivoConvenio.TabIndex = 4
        Me.btnAtivoConvenio.Text = "Mudar Status"
        Me.btnAtivoConvenio.UseVisualStyleBackColor = True
        '
        'btnIncluirConvenio
        '
        Me.btnIncluirConvenio.Location = New System.Drawing.Point(212, 17)
        Me.btnIncluirConvenio.Name = "btnIncluirConvenio"
        Me.btnIncluirConvenio.Size = New System.Drawing.Size(75, 23)
        Me.btnIncluirConvenio.TabIndex = 3
        Me.btnIncluirConvenio.Text = "Incluir"
        Me.btnIncluirConvenio.UseVisualStyleBackColor = True
        '
        'txtNumConvenio
        '
        Me.txtNumConvenio.Location = New System.Drawing.Point(65, 19)
        Me.txtNumConvenio.MaxLength = 20
        Me.txtNumConvenio.Name = "txtNumConvenio"
        Me.txtNumConvenio.Size = New System.Drawing.Size(131, 20)
        Me.txtNumConvenio.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Número"
        '
        'tpNovoEmpresa
        '
        Me.tpNovoEmpresa.Controls.Add(Me.btnExcluirEmpresa)
        Me.tpNovoEmpresa.Controls.Add(Me.btnAtualizarEmpresa)
        Me.tpNovoEmpresa.Controls.Add(Me.btnIncluirEmpresa)
        Me.tpNovoEmpresa.Controls.Add(Me.txtCadastro)
        Me.tpNovoEmpresa.Controls.Add(Me.Label9)
        Me.tpNovoEmpresa.Controls.Add(Me.txtFantasia)
        Me.tpNovoEmpresa.Controls.Add(Me.txtRazao)
        Me.tpNovoEmpresa.Controls.Add(Me.Label8)
        Me.tpNovoEmpresa.Controls.Add(Me.Label7)
        Me.tpNovoEmpresa.Controls.Add(Me.cboSemVencimento)
        Me.tpNovoEmpresa.Controls.Add(Me.txtVencimento)
        Me.tpNovoEmpresa.Controls.Add(Me.Label4)
        Me.tpNovoEmpresa.Controls.Add(Me.cboTipoPessoa)
        Me.tpNovoEmpresa.Controls.Add(Me.Label5)
        Me.tpNovoEmpresa.Controls.Add(Me.txtCnpj)
        Me.tpNovoEmpresa.Controls.Add(Me.Label6)
        Me.tpNovoEmpresa.Location = New System.Drawing.Point(4, 22)
        Me.tpNovoEmpresa.Name = "tpNovoEmpresa"
        Me.tpNovoEmpresa.Padding = New System.Windows.Forms.Padding(3)
        Me.tpNovoEmpresa.Size = New System.Drawing.Size(610, 252)
        Me.tpNovoEmpresa.TabIndex = 2
        Me.tpNovoEmpresa.Text = "Nova Empresa"
        Me.tpNovoEmpresa.UseVisualStyleBackColor = True
        '
        'btnExcluirEmpresa
        '
        Me.btnExcluirEmpresa.Location = New System.Drawing.Point(523, 184)
        Me.btnExcluirEmpresa.Name = "btnExcluirEmpresa"
        Me.btnExcluirEmpresa.Size = New System.Drawing.Size(75, 23)
        Me.btnExcluirEmpresa.TabIndex = 18
        Me.btnExcluirEmpresa.Text = "Excluir"
        Me.btnExcluirEmpresa.UseVisualStyleBackColor = True
        '
        'btnAtualizarEmpresa
        '
        Me.btnAtualizarEmpresa.Location = New System.Drawing.Point(397, 184)
        Me.btnAtualizarEmpresa.Name = "btnAtualizarEmpresa"
        Me.btnAtualizarEmpresa.Size = New System.Drawing.Size(75, 23)
        Me.btnAtualizarEmpresa.TabIndex = 17
        Me.btnAtualizarEmpresa.Text = "Atualizar"
        Me.btnAtualizarEmpresa.UseVisualStyleBackColor = True
        '
        'btnIncluirEmpresa
        '
        Me.btnIncluirEmpresa.Location = New System.Drawing.Point(309, 184)
        Me.btnIncluirEmpresa.Name = "btnIncluirEmpresa"
        Me.btnIncluirEmpresa.Size = New System.Drawing.Size(75, 23)
        Me.btnIncluirEmpresa.TabIndex = 16
        Me.btnIncluirEmpresa.Text = "Incluir"
        Me.btnIncluirEmpresa.UseVisualStyleBackColor = True
        '
        'txtCadastro
        '
        Me.txtCadastro.Location = New System.Drawing.Point(11, 187)
        Me.txtCadastro.Name = "txtCadastro"
        Me.txtCadastro.ReadOnly = True
        Me.txtCadastro.Size = New System.Drawing.Size(146, 20)
        Me.txtCadastro.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 171)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Cadastro"
        '
        'txtFantasia
        '
        Me.txtFantasia.Location = New System.Drawing.Point(8, 118)
        Me.txtFantasia.MaxLength = 70
        Me.txtFantasia.Name = "txtFantasia"
        Me.txtFantasia.Size = New System.Drawing.Size(590, 20)
        Me.txtFantasia.TabIndex = 13
        '
        'txtRazao
        '
        Me.txtRazao.Location = New System.Drawing.Point(8, 79)
        Me.txtRazao.MaxLength = 70
        Me.txtRazao.Name = "txtRazao"
        Me.txtRazao.Size = New System.Drawing.Size(590, 20)
        Me.txtRazao.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(5, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Razão Social"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Nome Fantasia"
        '
        'cboSemVencimento
        '
        Me.cboSemVencimento.AutoSize = True
        Me.cboSemVencimento.Location = New System.Drawing.Point(492, 27)
        Me.cboSemVencimento.Name = "cboSemVencimento"
        Me.cboSemVencimento.Size = New System.Drawing.Size(106, 17)
        Me.cboSemVencimento.TabIndex = 9
        Me.cboSemVencimento.Text = "Sem Vencimento"
        Me.cboSemVencimento.UseVisualStyleBackColor = True
        '
        'txtVencimento
        '
        Me.txtVencimento.CustomFormat = "dd/MM/yyyy"
        Me.txtVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtVencimento.Location = New System.Drawing.Point(363, 25)
        Me.txtVencimento.Name = "txtVencimento"
        Me.txtVencimento.Size = New System.Drawing.Size(109, 20)
        Me.txtVencimento.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(360, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Vencimento"
        '
        'cboTipoPessoa
        '
        Me.cboTipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPessoa.FormattingEnabled = True
        Me.cboTipoPessoa.Items.AddRange(New Object() {"Pessoa Jurídica", "Pessoa Física"})
        Me.cboTipoPessoa.Location = New System.Drawing.Point(8, 24)
        Me.cboTipoPessoa.Name = "cboTipoPessoa"
        Me.cboTipoPessoa.Size = New System.Drawing.Size(180, 21)
        Me.cboTipoPessoa.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(5, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Tipo Inscrição"
        '
        'txtCnpj
        '
        Me.txtCnpj.Location = New System.Drawing.Point(213, 25)
        Me.txtCnpj.Mask = "00,000,000/0000-00"
        Me.txtCnpj.Name = "txtCnpj"
        Me.txtCnpj.Size = New System.Drawing.Size(117, 20)
        Me.txtCnpj.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(210, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "CNPJ da empresa"
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(618, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Selecione a empresa para ativação"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbEmpresas
        '
        Me.lbEmpresas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbEmpresas.FormattingEnabled = True
        Me.lbEmpresas.Location = New System.Drawing.Point(0, 23)
        Me.lbEmpresas.Name = "lbEmpresas"
        Me.lbEmpresas.Size = New System.Drawing.Size(618, 140)
        Me.lbEmpresas.TabIndex = 2
        '
        'tpTelas
        '
        Me.tpTelas.Controls.Add(Me.btnTelaRemove)
        Me.tpTelas.Controls.Add(Me.btnTelaAdd)
        Me.tpTelas.Controls.Add(Me.Label11)
        Me.tpTelas.Controls.Add(Me.Label10)
        Me.tpTelas.Controls.Add(Me.lsbTelasLiberadas)
        Me.tpTelas.Controls.Add(Me.lsbTelas)
        Me.tpTelas.Location = New System.Drawing.Point(4, 22)
        Me.tpTelas.Name = "tpTelas"
        Me.tpTelas.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTelas.Size = New System.Drawing.Size(610, 252)
        Me.tpTelas.TabIndex = 3
        Me.tpTelas.Text = "Telas/Programas"
        Me.tpTelas.UseVisualStyleBackColor = True
        '
        'lsbTelas
        '
        Me.lsbTelas.FormattingEnabled = True
        Me.lsbTelas.Location = New System.Drawing.Point(8, 28)
        Me.lsbTelas.Name = "lsbTelas"
        Me.lsbTelas.Size = New System.Drawing.Size(280, 212)
        Me.lsbTelas.TabIndex = 0
        '
        'lsbTelasLiberadas
        '
        Me.lsbTelasLiberadas.FormattingEnabled = True
        Me.lsbTelasLiberadas.Location = New System.Drawing.Point(322, 28)
        Me.lsbTelasLiberadas.Name = "lsbTelasLiberadas"
        Me.lsbTelasLiberadas.Size = New System.Drawing.Size(280, 212)
        Me.lsbTelasLiberadas.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(142, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Telas que existe no sistemas"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(350, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(216, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Telas que a empresa selecionada pode usar"
        '
        'btnTelaAdd
        '
        Me.btnTelaAdd.Location = New System.Drawing.Point(292, 104)
        Me.btnTelaAdd.Name = "btnTelaAdd"
        Me.btnTelaAdd.Size = New System.Drawing.Size(27, 23)
        Me.btnTelaAdd.TabIndex = 4
        Me.btnTelaAdd.Text = ">>"
        Me.btnTelaAdd.UseVisualStyleBackColor = True
        '
        'btnTelaRemove
        '
        Me.btnTelaRemove.Location = New System.Drawing.Point(292, 133)
        Me.btnTelaRemove.Name = "btnTelaRemove"
        Me.btnTelaRemove.Size = New System.Drawing.Size(27, 23)
        Me.btnTelaRemove.TabIndex = 5
        Me.btnTelaRemove.Text = "<<"
        Me.btnTelaRemove.UseVisualStyleBackColor = True
        '
        'TelaPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(618, 441)
        Me.Controls.Add(Me.lbEmpresas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbGeral)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TelaPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selecionar a empresa que deseja liberar"
        Me.tbGeral.ResumeLayout(False)
        Me.tpGeral.ResumeLayout(False)
        Me.tpGeral.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpConvenios.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tpNovoEmpresa.ResumeLayout(False)
        Me.tpNovoEmpresa.PerformLayout()
        Me.tpTelas.ResumeLayout(False)
        Me.tpTelas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbGeral As System.Windows.Forms.TabControl
    Friend WithEvents tpGeral As System.Windows.Forms.TabPage
    Friend WithEvents tpConvenios As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbEmpresas As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbMaquinas As System.Windows.Forms.ListBox
    Friend WithEvents btnAtualizarQtd As System.Windows.Forms.Button
    Friend WithEvents txtQuantidade As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbInativo As System.Windows.Forms.RadioButton
    Friend WithEvents rbAtivo As System.Windows.Forms.RadioButton
    Friend WithEvents btnMaqExcluir As System.Windows.Forms.Button
    Friend WithEvents btnMaqLiberar As System.Windows.Forms.Button
    Friend WithEvents tpNovoEmpresa As System.Windows.Forms.TabPage
    Friend WithEvents cboTipoPessoa As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCnpj As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnExcluirEmpresa As System.Windows.Forms.Button
    Friend WithEvents btnAtualizarEmpresa As System.Windows.Forms.Button
    Friend WithEvents btnIncluirEmpresa As System.Windows.Forms.Button
    Friend WithEvents txtCadastro As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFantasia As System.Windows.Forms.TextBox
    Friend WithEvents txtRazao As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboSemVencimento As System.Windows.Forms.CheckBox
    Friend WithEvents txtVencimento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbConvenios As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExcluirConvenio As System.Windows.Forms.Button
    Friend WithEvents btnAtivoConvenio As System.Windows.Forms.Button
    Friend WithEvents btnIncluirConvenio As System.Windows.Forms.Button
    Friend WithEvents txtNumConvenio As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tpTelas As System.Windows.Forms.TabPage
    Friend WithEvents btnTelaRemove As System.Windows.Forms.Button
    Friend WithEvents btnTelaAdd As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lsbTelasLiberadas As System.Windows.Forms.ListBox
    Friend WithEvents lsbTelas As System.Windows.Forms.ListBox

End Class
