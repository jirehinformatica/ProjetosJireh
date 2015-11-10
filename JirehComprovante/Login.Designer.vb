<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Me.pnlLogar = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEntrar = New System.Windows.Forms.Button()
        Me.txtSenha = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlLogar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlLogar
        '
        Me.pnlLogar.BackColor = System.Drawing.Color.White
        Me.pnlLogar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLogar.Controls.Add(Me.Button1)
        Me.pnlLogar.Controls.Add(Me.txtEmail)
        Me.pnlLogar.Controls.Add(Me.lblEmail)
        Me.pnlLogar.Controls.Add(Me.btnCancelar)
        Me.pnlLogar.Controls.Add(Me.btnEntrar)
        Me.pnlLogar.Controls.Add(Me.txtSenha)
        Me.pnlLogar.Controls.Add(Me.Label2)
        Me.pnlLogar.Controls.Add(Me.txtUsuario)
        Me.pnlLogar.Controls.Add(Me.lblUsuario)
        Me.pnlLogar.Controls.Add(Me.Label1)
        Me.pnlLogar.Controls.Add(Me.PictureBox1)
        Me.pnlLogar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLogar.Location = New System.Drawing.Point(0, 0)
        Me.pnlLogar.Name = "pnlLogar"
        Me.pnlLogar.Size = New System.Drawing.Size(424, 253)
        Me.pnlLogar.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LightBlue
        Me.Button1.Location = New System.Drawing.Point(159, 307)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "E&nviar"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(16, 277)
        Me.txtEmail.MaxLength = 100
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(386, 23)
        Me.txtEmail.TabIndex = 9
        Me.txtEmail.Visible = False
        '
        'lblEmail
        '
        Me.lblEmail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.Color.Blue
        Me.lblEmail.Location = New System.Drawing.Point(11, 253)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(397, 20)
        Me.lblEmail.TabIndex = 8
        Me.lblEmail.Text = "Esqueceu a senha informe o e-mail cadastrado e clique em enviar"
        Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblEmail.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.LightBlue
        Me.btnCancelar.Location = New System.Drawing.Point(75, 210)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 23)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnEntrar
        '
        Me.btnEntrar.BackColor = System.Drawing.Color.LightBlue
        Me.btnEntrar.Location = New System.Drawing.Point(253, 210)
        Me.btnEntrar.Name = "btnEntrar"
        Me.btnEntrar.Size = New System.Drawing.Size(100, 23)
        Me.btnEntrar.TabIndex = 6
        Me.btnEntrar.Text = "&Entrar"
        Me.btnEntrar.UseVisualStyleBackColor = False
        '
        'txtSenha
        '
        Me.txtSenha.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSenha.Location = New System.Drawing.Point(149, 167)
        Me.txtSenha.MaxLength = 20
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSenha.Size = New System.Drawing.Size(204, 23)
        Me.txtSenha.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(72, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Senha:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtUsuario
        '
        Me.txtUsuario.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.Location = New System.Drawing.Point(149, 131)
        Me.txtUsuario.MaxLength = 30
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(204, 23)
        Me.txtUsuario.TabIndex = 3
        '
        'lblUsuario
        '
        Me.lblUsuario.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.Location = New System.Drawing.Point(72, 131)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(71, 20)
        Me.lblUsuario.TabIndex = 2
        Me.lblUsuario.Text = "Usuário:"
        Me.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(189, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(219, 65)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Módulo Leitor de Arquivos Bancário"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.JirehComprovante.My.Resources.Resources.logo_jireh_170
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(175, 105)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 253)
        Me.Controls.Add(Me.pnlLogar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.pnlLogar.ResumeLayout(False)
        Me.pnlLogar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlLogar As System.Windows.Forms.Panel
    Friend WithEvents txtSenha As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnEntrar As System.Windows.Forms.Button
End Class
