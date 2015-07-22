<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Comprovante
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
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbAbrir = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.opArquivo = New System.Windows.Forms.OpenFileDialog()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.lblSubRelatorio = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvComprovantes = New System.Windows.Forms.DataGridView()
        Me.Imprimir = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Favorecido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CPF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pagamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ocorrencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Banco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContaCredito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AutenticacaoBancaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Empresa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CNPJ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContaDebito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NSA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataArquivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoCompromisso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsMenu.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvComprovantes, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.tsbAbrir.Text = "&Abrir"
        Me.tsbAbrir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsbAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbAbrir.ToolTipText = "Abrir arquivo retorno"
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
        Me.tsbImprimir.ToolTipText = "Imprimir Comprovante"
        '
        'lblCaption
        '
        Me.lblCaption.BackColor = System.Drawing.Color.Ivory
        Me.lblCaption.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(0, 38)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(730, 23)
        Me.lblCaption.TabIndex = 2
        Me.lblCaption.Text = "Comprovantes de pagamentos"
        Me.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSubRelatorio
        '
        Me.lblSubRelatorio.BackColor = System.Drawing.Color.Ivory
        Me.lblSubRelatorio.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblSubRelatorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubRelatorio.Location = New System.Drawing.Point(0, 485)
        Me.lblSubRelatorio.Name = "lblSubRelatorio"
        Me.lblSubRelatorio.Size = New System.Drawing.Size(730, 23)
        Me.lblSubRelatorio.TabIndex = 3
        Me.lblSubRelatorio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvComprovantes)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 61)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(730, 424)
        Me.Panel1.TabIndex = 4
        '
        'dgvComprovantes
        '
        Me.dgvComprovantes.AllowUserToAddRows = False
        Me.dgvComprovantes.AllowUserToDeleteRows = False
        Me.dgvComprovantes.AllowUserToResizeRows = False
        Me.dgvComprovantes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvComprovantes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.dgvComprovantes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComprovantes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvComprovantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvComprovantes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Imprimir, Me.Favorecido, Me.CPF, Me.Pagamento, Me.Valor, Me.Ocorrencia, Me.Banco, Me.ContaCredito, Me.AutenticacaoBancaria, Me.Empresa, Me.CNPJ, Me.ContaDebito, Me.NSA, Me.DataArquivo, Me.TipoCompromisso})
        Me.dgvComprovantes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvComprovantes.Location = New System.Drawing.Point(0, 0)
        Me.dgvComprovantes.Name = "dgvComprovantes"
        Me.dgvComprovantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvComprovantes.ShowRowErrors = False
        Me.dgvComprovantes.Size = New System.Drawing.Size(730, 424)
        Me.dgvComprovantes.TabIndex = 3
        '
        'Imprimir
        '
        Me.Imprimir.DataPropertyName = "Valido"
        Me.Imprimir.HeaderText = ""
        Me.Imprimir.Name = "Imprimir"
        Me.Imprimir.Width = 40
        '
        'Favorecido
        '
        Me.Favorecido.DataPropertyName = "Favorecido"
        Me.Favorecido.HeaderText = "Favorecido"
        Me.Favorecido.Name = "Favorecido"
        Me.Favorecido.ReadOnly = True
        Me.Favorecido.Width = 160
        '
        'CPF
        '
        Me.CPF.DataPropertyName = "CPF"
        Me.CPF.HeaderText = "CPF/CNPJ"
        Me.CPF.Name = "CPF"
        Me.CPF.ReadOnly = True
        Me.CPF.Width = 105
        '
        'Pagamento
        '
        Me.Pagamento.DataPropertyName = "Vencimento"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "d"
        Me.Pagamento.DefaultCellStyle = DataGridViewCellStyle2
        Me.Pagamento.HeaderText = "Pagamento"
        Me.Pagamento.Name = "Pagamento"
        Me.Pagamento.ReadOnly = True
        Me.Pagamento.Width = 90
        '
        'Valor
        '
        Me.Valor.DataPropertyName = "Valor"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = """"""
        Me.Valor.DefaultCellStyle = DataGridViewCellStyle3
        Me.Valor.HeaderText = "Valor"
        Me.Valor.Name = "Valor"
        Me.Valor.ReadOnly = True
        '
        'Ocorrencia
        '
        Me.Ocorrencia.DataPropertyName = "Ocorrencia"
        Me.Ocorrencia.HeaderText = "Ocorrência"
        Me.Ocorrencia.Name = "Ocorrencia"
        Me.Ocorrencia.ReadOnly = True
        Me.Ocorrencia.Width = 170
        '
        'Banco
        '
        Me.Banco.DataPropertyName = "Banco"
        Me.Banco.HeaderText = "Banco"
        Me.Banco.Name = "Banco"
        Me.Banco.ReadOnly = True
        Me.Banco.Visible = False
        '
        'ContaCredito
        '
        Me.ContaCredito.DataPropertyName = "ContaCredito"
        Me.ContaCredito.HeaderText = "ContaCredito"
        Me.ContaCredito.Name = "ContaCredito"
        Me.ContaCredito.ReadOnly = True
        Me.ContaCredito.Visible = False
        '
        'AutenticacaoBancaria
        '
        Me.AutenticacaoBancaria.DataPropertyName = "AutenticacaoBancaria"
        Me.AutenticacaoBancaria.HeaderText = "AutenticacaoBancaria"
        Me.AutenticacaoBancaria.Name = "AutenticacaoBancaria"
        Me.AutenticacaoBancaria.ReadOnly = True
        Me.AutenticacaoBancaria.Visible = False
        '
        'Empresa
        '
        Me.Empresa.DataPropertyName = "Empresa"
        Me.Empresa.HeaderText = "Empresa"
        Me.Empresa.Name = "Empresa"
        Me.Empresa.ReadOnly = True
        Me.Empresa.Visible = False
        '
        'CNPJ
        '
        Me.CNPJ.DataPropertyName = "CNPJ"
        Me.CNPJ.HeaderText = "CNPJ"
        Me.CNPJ.Name = "CNPJ"
        Me.CNPJ.ReadOnly = True
        Me.CNPJ.Visible = False
        '
        'ContaDebito
        '
        Me.ContaDebito.DataPropertyName = "ContaDebito"
        Me.ContaDebito.HeaderText = "ContaDebito"
        Me.ContaDebito.Name = "ContaDebito"
        Me.ContaDebito.ReadOnly = True
        Me.ContaDebito.Visible = False
        '
        'NSA
        '
        Me.NSA.DataPropertyName = "NSA"
        Me.NSA.HeaderText = "NSA"
        Me.NSA.Name = "NSA"
        Me.NSA.ReadOnly = True
        Me.NSA.Visible = False
        '
        'DataArquivo
        '
        Me.DataArquivo.DataPropertyName = "DataArquivo"
        Me.DataArquivo.HeaderText = "DataArquivo"
        Me.DataArquivo.Name = "DataArquivo"
        Me.DataArquivo.ReadOnly = True
        Me.DataArquivo.Visible = False
        '
        'TipoCompromisso
        '
        Me.TipoCompromisso.DataPropertyName = "TipoCompromisso"
        Me.TipoCompromisso.HeaderText = "TipoCompromisso"
        Me.TipoCompromisso.Name = "TipoCompromisso"
        Me.TipoCompromisso.ReadOnly = True
        Me.TipoCompromisso.Visible = False
        '
        'Comprovante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(730, 508)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblSubRelatorio)
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.tsMenu)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Comprovante"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Emissão de comprovante"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvComprovantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbAbrir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents opArquivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents lblSubRelatorio As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvComprovantes As System.Windows.Forms.DataGridView
    Friend WithEvents Imprimir As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Favorecido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CPF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pagamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ocorrencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Banco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContaCredito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AutenticacaoBancaria As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Empresa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CNPJ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContaDebito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NSA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataArquivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoCompromisso As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
