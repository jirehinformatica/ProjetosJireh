<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AtivadorSistema
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AtivadorSistema))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCnpj = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboTipoPessoa = New System.Windows.Forms.ComboBox()
        Me.lblValidarCnpj = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRazaoSocial = New System.Windows.Forms.TextBox()
        Me.txtResultado = New System.Windows.Forms.TextBox()
        Me.btnContinuar = New System.Windows.Forms.Button()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(217, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CNPJ da empresa *"
        '
        'txtCnpj
        '
        Me.txtCnpj.Location = New System.Drawing.Point(220, 23)
        Me.txtCnpj.Mask = "00,000,000/0000-00"
        Me.txtCnpj.Name = "txtCnpj"
        Me.txtCnpj.Size = New System.Drawing.Size(117, 20)
        Me.txtCnpj.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(12, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tipo Inscrição *"
        '
        'cboTipoPessoa
        '
        Me.cboTipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPessoa.FormattingEnabled = True
        Me.cboTipoPessoa.Items.AddRange(New Object() {"Pessoa Jurídica", "Pessoa Física"})
        Me.cboTipoPessoa.Location = New System.Drawing.Point(15, 22)
        Me.cboTipoPessoa.Name = "cboTipoPessoa"
        Me.cboTipoPessoa.Size = New System.Drawing.Size(180, 21)
        Me.cboTipoPessoa.TabIndex = 1
        '
        'lblValidarCnpj
        '
        Me.lblValidarCnpj.AutoSize = True
        Me.lblValidarCnpj.ForeColor = System.Drawing.Color.Red
        Me.lblValidarCnpj.Location = New System.Drawing.Point(343, 26)
        Me.lblValidarCnpj.Name = "lblValidarCnpj"
        Me.lblValidarCnpj.Size = New System.Drawing.Size(44, 13)
        Me.lblValidarCnpj.TabIndex = 4
        Me.lblValidarCnpj.Text = "Invalido"
        Me.lblValidarCnpj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Razão Social"
        '
        'txtRazaoSocial
        '
        Me.txtRazaoSocial.Location = New System.Drawing.Point(15, 64)
        Me.txtRazaoSocial.MaxLength = 70
        Me.txtRazaoSocial.Name = "txtRazaoSocial"
        Me.txtRazaoSocial.Size = New System.Drawing.Size(512, 20)
        Me.txtRazaoSocial.TabIndex = 3
        '
        'txtResultado
        '
        Me.txtResultado.ForeColor = System.Drawing.Color.Blue
        Me.txtResultado.Location = New System.Drawing.Point(15, 138)
        Me.txtResultado.Multiline = True
        Me.txtResultado.Name = "txtResultado"
        Me.txtResultado.ReadOnly = True
        Me.txtResultado.Size = New System.Drawing.Size(512, 316)
        Me.txtResultado.TabIndex = 7
        Me.txtResultado.TabStop = False
        Me.txtResultado.Text = resources.GetString("txtResultado.Text")
        '
        'btnContinuar
        '
        Me.btnContinuar.Location = New System.Drawing.Point(402, 460)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(125, 23)
        Me.btnContinuar.TabIndex = 5
        Me.btnContinuar.Text = "&Continuar"
        Me.btnContinuar.UseVisualStyleBackColor = True
        '
        'btnEnviar
        '
        Me.btnEnviar.Location = New System.Drawing.Point(212, 92)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(125, 23)
        Me.btnEnviar.TabIndex = 4
        Me.btnEnviar.Text = "&Enviar Informações"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(12, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(254, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Processo de ativação do sistema Jireh Comprovante"
        '
        'lblStatus
        '
        Me.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblStatus.ForeColor = System.Drawing.Color.Blue
        Me.lblStatus.Location = New System.Drawing.Point(12, 460)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(375, 23)
        Me.lblStatus.TabIndex = 9
        Me.lblStatus.Text = "Andamento"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(462, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "* Obrigatório"
        '
        'AtivadorSistema
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 491)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.btnContinuar)
        Me.Controls.Add(Me.txtResultado)
        Me.Controls.Add(Me.txtRazaoSocial)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblValidarCnpj)
        Me.Controls.Add(Me.cboTipoPessoa)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCnpj)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AtivadorSistema"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Avaliação (Necessário Ativação)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCnpj As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTipoPessoa As System.Windows.Forms.ComboBox
    Friend WithEvents lblValidarCnpj As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRazaoSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtResultado As System.Windows.Forms.TextBox
    Friend WithEvents btnContinuar As System.Windows.Forms.Button
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
