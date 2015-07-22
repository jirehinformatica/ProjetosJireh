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
        Me.tpConvenios = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbEmpresas = New System.Windows.Forms.ListBox()
        Me.rbAtivo = New System.Windows.Forms.RadioButton()
        Me.rbInativo = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.btnAtualizarQtd = New System.Windows.Forms.Button()
        Me.lbMaquinas = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbGeral.SuspendLayout()
        Me.tpGeral.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbGeral
        '
        Me.tbGeral.Controls.Add(Me.tpGeral)
        Me.tbGeral.Controls.Add(Me.tpConvenios)
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
        Me.tpGeral.Controls.Add(Me.NumericUpDown1)
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
        'tpConvenios
        '
        Me.tpConvenios.Location = New System.Drawing.Point(4, 22)
        Me.tpConvenios.Name = "tpConvenios"
        Me.tpConvenios.Padding = New System.Windows.Forms.Padding(3)
        Me.tpConvenios.Size = New System.Drawing.Size(738, 286)
        Me.tpConvenios.TabIndex = 1
        Me.tpConvenios.Text = "Convênios"
        Me.tpConvenios.UseVisualStyleBackColor = True
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(224, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Quantidade Maquinas Liberadas"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(390, 15)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(67, 20)
        Me.NumericUpDown1.TabIndex = 3
        '
        'btnAtualizarQtd
        '
        Me.btnAtualizarQtd.Location = New System.Drawing.Point(470, 14)
        Me.btnAtualizarQtd.Name = "btnAtualizarQtd"
        Me.btnAtualizarQtd.Size = New System.Drawing.Size(75, 23)
        Me.btnAtualizarQtd.TabIndex = 4
        Me.btnAtualizarQtd.Text = "Atualizar"
        Me.btnAtualizarQtd.UseVisualStyleBackColor = True
        '
        'lbMaquinas
        '
        Me.lbMaquinas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lbMaquinas.FormattingEnabled = True
        Me.lbMaquinas.Location = New System.Drawing.Point(3, 102)
        Me.lbMaquinas.Name = "lbMaquinas"
        Me.lbMaquinas.Size = New System.Drawing.Size(604, 147)
        Me.lbMaquinas.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(3, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(604, 50)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selecione o número da maquina para liberar ativação"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(147, 19)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(84, 20)
        Me.TextBox1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "No Grid abaixo Coluna 01"
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
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbGeral As System.Windows.Forms.TabControl
    Friend WithEvents tpGeral As System.Windows.Forms.TabPage
    Friend WithEvents tpConvenios As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbEmpresas As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lbMaquinas As System.Windows.Forms.ListBox
    Friend WithEvents btnAtualizarQtd As System.Windows.Forms.Button
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbInativo As System.Windows.Forms.RadioButton
    Friend WithEvents rbAtivo As System.Windows.Forms.RadioButton

End Class
