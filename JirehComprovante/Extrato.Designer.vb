<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Extrato
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbAbrir = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboSequencia = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboEmpresas = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboConta = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.opArquivo = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtSadoBloqueado = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCreditos = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtDebitos = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPosicaoFinal = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSaldoFinal = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDataFinal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtLimite = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPosicaoInicio = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSaldoInicio = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDataInicio = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvExtrato = New System.Windows.Forms.DataGridView()
        Me.DataLancamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescricaoHistorico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorLancamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoLancamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroSequencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AgenciaEContaCompleto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoBancoArquivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LoteServico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoInscricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroInscricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoConvenio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoServico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContaCorrenteAgencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContaCorrenteAgenciaDv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContaCorrenteNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContaCorrenteNumeroDv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomeEmpresa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CPMF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataContabil = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoLancamentoDescricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Categoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoHistorico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoComplemento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComplementoBancoOrigem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComplementoAgenciaOrigem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsMenu.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvExtrato, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAbrir, Me.tsbImprimir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(730, 38)
        Me.tsMenu.TabIndex = 0
        Me.tsMenu.Text = "ToolStrip1"
        '
        'tsbAbrir
        '
        Me.tsbAbrir.Image = Global.JirehComprovante.My.Resources.Resources.Open24x24
        Me.tsbAbrir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tsbAbrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAbrir.Name = "tsbAbrir"
        Me.tsbAbrir.Size = New System.Drawing.Size(37, 35)
        Me.tsbAbrir.Text = "Abrir"
        Me.tsbAbrir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsbAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbAbrir.ToolTipText = "Abrir arquivo extrato"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.JirehComprovante.My.Resources.Resources.Impressora24x24
        Me.tsbImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(57, 35)
        Me.tsbImprimir.Text = "Imprimir"
        Me.tsbImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsbImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbImprimir.ToolTipText = "Imprimir extrato"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cboSequencia)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cboEmpresas)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cboConta)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(730, 56)
        Me.Panel1.TabIndex = 1
        '
        'cboSequencia
        '
        Me.cboSequencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSequencia.FormattingEnabled = True
        Me.cboSequencia.Location = New System.Drawing.Point(617, 23)
        Me.cboSequencia.Name = "cboSequencia"
        Me.cboSequencia.Size = New System.Drawing.Size(101, 21)
        Me.cboSequencia.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(614, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nº Sequência"
        '
        'cboEmpresas
        '
        Me.cboEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpresas.FormattingEnabled = True
        Me.cboEmpresas.Location = New System.Drawing.Point(12, 23)
        Me.cboEmpresas.Name = "cboEmpresas"
        Me.cboEmpresas.Size = New System.Drawing.Size(318, 21)
        Me.cboEmpresas.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Empresa"
        '
        'cboConta
        '
        Me.cboConta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConta.FormattingEnabled = True
        Me.cboConta.Location = New System.Drawing.Point(336, 23)
        Me.cboConta.Name = "cboConta"
        Me.cboConta.Size = New System.Drawing.Size(275, 21)
        Me.cboConta.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(333, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Conta Corrente"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtStatus)
        Me.GroupBox1.Controls.Add(Me.txtSadoBloqueado)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtCreditos)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtDebitos)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtPosicaoFinal)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtSaldoFinal)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtDataFinal)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox1.Location = New System.Drawing.Point(0, 424)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(730, 70)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Final"
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(185, 16)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(90, 20)
        Me.txtStatus.TabIndex = 26
        '
        'txtSadoBloqueado
        '
        Me.txtSadoBloqueado.Location = New System.Drawing.Point(380, 42)
        Me.txtSadoBloqueado.Name = "txtSadoBloqueado"
        Me.txtSadoBloqueado.ReadOnly = True
        Me.txtSadoBloqueado.Size = New System.Drawing.Size(140, 20)
        Me.txtSadoBloqueado.TabIndex = 25
        Me.txtSadoBloqueado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(283, 45)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Saldo Bloqueado:"
        '
        'txtCreditos
        '
        Me.txtCreditos.Location = New System.Drawing.Point(380, 16)
        Me.txtCreditos.Name = "txtCreditos"
        Me.txtCreditos.ReadOnly = True
        Me.txtCreditos.Size = New System.Drawing.Size(140, 20)
        Me.txtCreditos.TabIndex = 23
        Me.txtCreditos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(326, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Créditos:"
        '
        'txtDebitos
        '
        Me.txtDebitos.Location = New System.Drawing.Point(578, 16)
        Me.txtDebitos.Name = "txtDebitos"
        Me.txtDebitos.ReadOnly = True
        Me.txtDebitos.Size = New System.Drawing.Size(140, 20)
        Me.txtDebitos.TabIndex = 21
        Me.txtDebitos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(526, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Débitos:"
        '
        'txtPosicaoFinal
        '
        Me.txtPosicaoFinal.Location = New System.Drawing.Point(66, 42)
        Me.txtPosicaoFinal.Name = "txtPosicaoFinal"
        Me.txtPosicaoFinal.ReadOnly = True
        Me.txtPosicaoFinal.Size = New System.Drawing.Size(70, 20)
        Me.txtPosicaoFinal.TabIndex = 19
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Posição:"
        '
        'txtSaldoFinal
        '
        Me.txtSaldoFinal.Location = New System.Drawing.Point(578, 42)
        Me.txtSaldoFinal.Name = "txtSaldoFinal"
        Me.txtSaldoFinal.ReadOnly = True
        Me.txtSaldoFinal.Size = New System.Drawing.Size(140, 20)
        Me.txtSaldoFinal.TabIndex = 17
        Me.txtSaldoFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(528, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Saldo:"
        '
        'txtDataFinal
        '
        Me.txtDataFinal.Location = New System.Drawing.Point(66, 16)
        Me.txtDataFinal.Name = "txtDataFinal"
        Me.txtDataFinal.ReadOnly = True
        Me.txtDataFinal.Size = New System.Drawing.Size(70, 20)
        Me.txtDataFinal.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Data:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtLimite)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtPosicaoInicio)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtSaldoInicio)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtDataInicio)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox2.Location = New System.Drawing.Point(0, 94)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(730, 45)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Início"
        '
        'txtLimite
        '
        Me.txtLimite.Location = New System.Drawing.Point(578, 15)
        Me.txtLimite.Name = "txtLimite"
        Me.txtLimite.ReadOnly = True
        Me.txtLimite.Size = New System.Drawing.Size(140, 20)
        Me.txtLimite.TabIndex = 17
        Me.txtLimite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(493, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Limite especial:"
        '
        'txtPosicaoInicio
        '
        Me.txtPosicaoInicio.Location = New System.Drawing.Point(402, 15)
        Me.txtPosicaoInicio.Name = "txtPosicaoInicio"
        Me.txtPosicaoInicio.ReadOnly = True
        Me.txtPosicaoInicio.Size = New System.Drawing.Size(70, 20)
        Me.txtPosicaoInicio.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(348, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Posição:"
        '
        'txtSaldoInicio
        '
        Me.txtSaldoInicio.Location = New System.Drawing.Point(170, 15)
        Me.txtSaldoInicio.Name = "txtSaldoInicio"
        Me.txtSaldoInicio.ReadOnly = True
        Me.txtSaldoInicio.Size = New System.Drawing.Size(140, 20)
        Me.txtSaldoInicio.TabIndex = 13
        Me.txtSaldoInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(127, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Saldo:"
        '
        'txtDataInicio
        '
        Me.txtDataInicio.Location = New System.Drawing.Point(51, 15)
        Me.txtDataInicio.Name = "txtDataInicio"
        Me.txtDataInicio.ReadOnly = True
        Me.txtDataInicio.Size = New System.Drawing.Size(70, 20)
        Me.txtDataInicio.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Data:"
        '
        'dgvExtrato
        '
        Me.dgvExtrato.AllowUserToAddRows = False
        Me.dgvExtrato.AllowUserToDeleteRows = False
        Me.dgvExtrato.AllowUserToResizeRows = False
        Me.dgvExtrato.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExtrato.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvExtrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvExtrato.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataLancamento, Me.NumeroDocumento, Me.DescricaoHistorico, Me.ValorLancamento, Me.TipoLancamento, Me.NumeroSequencia, Me.AgenciaEContaCompleto, Me.CodigoBancoArquivo, Me.LoteServico, Me.TipoInscricao, Me.NumeroInscricao, Me.CodigoConvenio, Me.TipoServico, Me.ContaCorrenteAgencia, Me.ContaCorrenteAgenciaDv, Me.ContaCorrenteNumero, Me.ContaCorrenteNumeroDv, Me.NomeEmpresa, Me.CPMF, Me.DataContabil, Me.TipoLancamentoDescricao, Me.Categoria, Me.CodigoHistorico, Me.TipoComplemento, Me.ComplementoBancoOrigem, Me.ComplementoAgenciaOrigem})
        Me.dgvExtrato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvExtrato.Location = New System.Drawing.Point(0, 139)
        Me.dgvExtrato.MultiSelect = False
        Me.dgvExtrato.Name = "dgvExtrato"
        Me.dgvExtrato.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvExtrato.Size = New System.Drawing.Size(730, 285)
        Me.dgvExtrato.TabIndex = 13
        '
        'DataLancamento
        '
        Me.DataLancamento.DataPropertyName = "DataLancamento"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DataLancamento.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataLancamento.HeaderText = "Lançamento"
        Me.DataLancamento.Name = "DataLancamento"
        Me.DataLancamento.ReadOnly = True
        Me.DataLancamento.Width = 80
        '
        'NumeroDocumento
        '
        Me.NumeroDocumento.DataPropertyName = "NumeroDocumento"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NumeroDocumento.DefaultCellStyle = DataGridViewCellStyle3
        Me.NumeroDocumento.HeaderText = "Nº Doc."
        Me.NumeroDocumento.Name = "NumeroDocumento"
        Me.NumeroDocumento.ReadOnly = True
        Me.NumeroDocumento.Width = 70
        '
        'DescricaoHistorico
        '
        Me.DescricaoHistorico.DataPropertyName = "DescricaoHistorico"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DescricaoHistorico.DefaultCellStyle = DataGridViewCellStyle4
        Me.DescricaoHistorico.HeaderText = "Histórico"
        Me.DescricaoHistorico.Name = "DescricaoHistorico"
        Me.DescricaoHistorico.ReadOnly = True
        Me.DescricaoHistorico.Width = 375
        '
        'ValorLancamento
        '
        Me.ValorLancamento.DataPropertyName = "ValorLancamento"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.ValorLancamento.DefaultCellStyle = DataGridViewCellStyle5
        Me.ValorLancamento.HeaderText = "Valor"
        Me.ValorLancamento.Name = "ValorLancamento"
        Me.ValorLancamento.ReadOnly = True
        '
        'TipoLancamento
        '
        Me.TipoLancamento.DataPropertyName = "TipoLancamento"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TipoLancamento.DefaultCellStyle = DataGridViewCellStyle6
        Me.TipoLancamento.HeaderText = "D/C"
        Me.TipoLancamento.Name = "TipoLancamento"
        Me.TipoLancamento.ReadOnly = True
        Me.TipoLancamento.Width = 40
        '
        'NumeroSequencia
        '
        Me.NumeroSequencia.DataPropertyName = "NumeroSequencia"
        Me.NumeroSequencia.HeaderText = "NumeroSequencia"
        Me.NumeroSequencia.Name = "NumeroSequencia"
        Me.NumeroSequencia.Visible = False
        '
        'AgenciaEContaCompleto
        '
        Me.AgenciaEContaCompleto.DataPropertyName = "AgenciaEContaCompleto"
        Me.AgenciaEContaCompleto.HeaderText = "AgenciaEContaCompleto"
        Me.AgenciaEContaCompleto.Name = "AgenciaEContaCompleto"
        Me.AgenciaEContaCompleto.Visible = False
        '
        'CodigoBancoArquivo
        '
        Me.CodigoBancoArquivo.DataPropertyName = "CodigoBancoArquivo"
        Me.CodigoBancoArquivo.HeaderText = "CodigoBancoArquivo "
        Me.CodigoBancoArquivo.Name = "CodigoBancoArquivo"
        Me.CodigoBancoArquivo.Visible = False
        '
        'LoteServico
        '
        Me.LoteServico.DataPropertyName = "LoteServico"
        Me.LoteServico.HeaderText = "LoteServico "
        Me.LoteServico.Name = "LoteServico"
        Me.LoteServico.Visible = False
        '
        'TipoInscricao
        '
        Me.TipoInscricao.DataPropertyName = "TipoInscricao"
        Me.TipoInscricao.HeaderText = "TipoInscricao"
        Me.TipoInscricao.Name = "TipoInscricao"
        Me.TipoInscricao.Visible = False
        '
        'NumeroInscricao
        '
        Me.NumeroInscricao.DataPropertyName = "NumeroInscricao"
        Me.NumeroInscricao.HeaderText = "NumeroInscricao"
        Me.NumeroInscricao.Name = "NumeroInscricao"
        Me.NumeroInscricao.Visible = False
        '
        'CodigoConvenio
        '
        Me.CodigoConvenio.DataPropertyName = "CodigoConvenio"
        Me.CodigoConvenio.HeaderText = "CodigoConvenio"
        Me.CodigoConvenio.Name = "CodigoConvenio"
        Me.CodigoConvenio.Visible = False
        '
        'TipoServico
        '
        Me.TipoServico.DataPropertyName = "TipoServico"
        Me.TipoServico.HeaderText = "TipoServico"
        Me.TipoServico.Name = "TipoServico"
        Me.TipoServico.Visible = False
        '
        'ContaCorrenteAgencia
        '
        Me.ContaCorrenteAgencia.DataPropertyName = "ContaCorrenteAgencia"
        Me.ContaCorrenteAgencia.HeaderText = "ContaCorrenteAgencia"
        Me.ContaCorrenteAgencia.Name = "ContaCorrenteAgencia"
        Me.ContaCorrenteAgencia.Visible = False
        '
        'ContaCorrenteAgenciaDv
        '
        Me.ContaCorrenteAgenciaDv.DataPropertyName = "ContaCorrenteAgenciaDv"
        Me.ContaCorrenteAgenciaDv.HeaderText = "ContaCorrenteAgenciaDv"
        Me.ContaCorrenteAgenciaDv.Name = "ContaCorrenteAgenciaDv"
        Me.ContaCorrenteAgenciaDv.Visible = False
        '
        'ContaCorrenteNumero
        '
        Me.ContaCorrenteNumero.DataPropertyName = "ContaCorrenteNumero"
        Me.ContaCorrenteNumero.HeaderText = "ContaCorrenteNumero"
        Me.ContaCorrenteNumero.Name = "ContaCorrenteNumero"
        Me.ContaCorrenteNumero.Visible = False
        '
        'ContaCorrenteNumeroDv
        '
        Me.ContaCorrenteNumeroDv.DataPropertyName = "ContaCorrenteNumeroDv"
        Me.ContaCorrenteNumeroDv.HeaderText = "ContaCorrenteNumeroDv"
        Me.ContaCorrenteNumeroDv.Name = "ContaCorrenteNumeroDv"
        Me.ContaCorrenteNumeroDv.Visible = False
        '
        'NomeEmpresa
        '
        Me.NomeEmpresa.DataPropertyName = "NomeEmpresa"
        Me.NomeEmpresa.HeaderText = "NomeEmpresa"
        Me.NomeEmpresa.Name = "NomeEmpresa"
        Me.NomeEmpresa.Visible = False
        '
        'CPMF
        '
        Me.CPMF.DataPropertyName = "CPMF"
        Me.CPMF.HeaderText = "CPMF"
        Me.CPMF.Name = "CPMF"
        Me.CPMF.Visible = False
        '
        'DataContabil
        '
        Me.DataContabil.DataPropertyName = "DataContabil"
        Me.DataContabil.HeaderText = "DataContabil"
        Me.DataContabil.Name = "DataContabil"
        Me.DataContabil.Visible = False
        '
        'TipoLancamentoDescricao
        '
        Me.TipoLancamentoDescricao.DataPropertyName = "TipoLancamentoDescricao"
        Me.TipoLancamentoDescricao.HeaderText = "TipoLancamentoDescricao"
        Me.TipoLancamentoDescricao.Name = "TipoLancamentoDescricao"
        Me.TipoLancamentoDescricao.Visible = False
        '
        'Categoria
        '
        Me.Categoria.DataPropertyName = "Categoria"
        Me.Categoria.HeaderText = "Categoria"
        Me.Categoria.Name = "Categoria"
        Me.Categoria.Visible = False
        '
        'CodigoHistorico
        '
        Me.CodigoHistorico.DataPropertyName = "CodigoHistorico"
        Me.CodigoHistorico.HeaderText = "CodigoHistorico"
        Me.CodigoHistorico.Name = "CodigoHistorico"
        Me.CodigoHistorico.Visible = False
        '
        'TipoComplemento
        '
        Me.TipoComplemento.DataPropertyName = "TipoComplemento"
        Me.TipoComplemento.HeaderText = "TipoComplemento"
        Me.TipoComplemento.Name = "TipoComplemento"
        Me.TipoComplemento.Visible = False
        '
        'ComplementoBancoOrigem
        '
        Me.ComplementoBancoOrigem.DataPropertyName = "ComplementoBancoOrigem"
        Me.ComplementoBancoOrigem.HeaderText = "ComplementoBancoOrigem"
        Me.ComplementoBancoOrigem.Name = "ComplementoBancoOrigem"
        Me.ComplementoBancoOrigem.Visible = False
        '
        'ComplementoAgenciaOrigem
        '
        Me.ComplementoAgenciaOrigem.DataPropertyName = "ComplementoAgenciaOrigem"
        Me.ComplementoAgenciaOrigem.HeaderText = "ComplementoAgenciaOrigem"
        Me.ComplementoAgenciaOrigem.Name = "ComplementoAgenciaOrigem"
        Me.ComplementoAgenciaOrigem.Visible = False
        '
        'Extrato
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(730, 494)
        Me.Controls.Add(Me.dgvExtrato)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "Extrato"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Extrato"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvExtrato, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbAbrir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboEmpresas As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboConta As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSequencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents opArquivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtSadoBloqueado As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCreditos As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtDebitos As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPosicaoFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSaldoFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDataFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLimite As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPosicaoInicio As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSaldoInicio As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDataInicio As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvExtrato As System.Windows.Forms.DataGridView
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataLancamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumeroDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescricaoHistorico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValorLancamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoLancamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumeroSequencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AgenciaEContaCompleto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodigoBancoArquivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoteServico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoInscricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumeroInscricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodigoConvenio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoServico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContaCorrenteAgencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContaCorrenteAgenciaDv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContaCorrenteNumero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContaCorrenteNumeroDv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomeEmpresa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CPMF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataContabil As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoLancamentoDescricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Categoria As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodigoHistorico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoComplemento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComplementoBancoOrigem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComplementoAgenciaOrigem As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
