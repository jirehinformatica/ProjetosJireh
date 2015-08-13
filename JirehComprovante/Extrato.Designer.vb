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
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbAbrir = New System.Windows.Forms.ToolStripButton()
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
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
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
        Me.dgvExtrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExtrato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvExtrato.Location = New System.Drawing.Point(0, 139)
        Me.dgvExtrato.Name = "dgvExtrato"
        Me.dgvExtrato.Size = New System.Drawing.Size(730, 285)
        Me.dgvExtrato.TabIndex = 13
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
End Class
