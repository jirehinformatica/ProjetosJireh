<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ssAbertura
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblVersao = New System.Windows.Forms.Label()
        Me.lblCorporacao = New System.Windows.Forms.Label()
        Me.lblAplicacaoNome = New System.Windows.Forms.Label()
        Me.lstAcao = New System.Windows.Forms.ListBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lstAcao)
        Me.Panel1.Controls.Add(Me.lblVersao)
        Me.Panel1.Controls.Add(Me.lblCorporacao)
        Me.Panel1.Controls.Add(Me.lblAplicacaoNome)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(208, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(286, 262)
        Me.Panel1.TabIndex = 0
        '
        'lblVersao
        '
        Me.lblVersao.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblVersao.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersao.ForeColor = System.Drawing.Color.Blue
        Me.lblVersao.Location = New System.Drawing.Point(0, 230)
        Me.lblVersao.Name = "lblVersao"
        Me.lblVersao.Size = New System.Drawing.Size(284, 30)
        Me.lblVersao.TabIndex = 2
        Me.lblVersao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCorporacao
        '
        Me.lblCorporacao.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCorporacao.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorporacao.ForeColor = System.Drawing.Color.Blue
        Me.lblCorporacao.Location = New System.Drawing.Point(0, 50)
        Me.lblCorporacao.Name = "lblCorporacao"
        Me.lblCorporacao.Size = New System.Drawing.Size(284, 57)
        Me.lblCorporacao.TabIndex = 1
        Me.lblCorporacao.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblAplicacaoNome
        '
        Me.lblAplicacaoNome.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblAplicacaoNome.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAplicacaoNome.ForeColor = System.Drawing.Color.Blue
        Me.lblAplicacaoNome.Location = New System.Drawing.Point(0, 0)
        Me.lblAplicacaoNome.Name = "lblAplicacaoNome"
        Me.lblAplicacaoNome.Size = New System.Drawing.Size(284, 50)
        Me.lblAplicacaoNome.TabIndex = 0
        '
        'lstAcao
        '
        Me.lstAcao.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstAcao.FormattingEnabled = True
        Me.lstAcao.Location = New System.Drawing.Point(0, 107)
        Me.lstAcao.Name = "lstAcao"
        Me.lstAcao.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstAcao.Size = New System.Drawing.Size(284, 123)
        Me.lstAcao.TabIndex = 3
        '
        'ssAbertura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.JirehComprovante.My.Resources.Resources.logo_jireh_170
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(494, 262)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ssAbertura"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblAplicacaoNome As System.Windows.Forms.Label
    Friend WithEvents lblCorporacao As System.Windows.Forms.Label
    Friend WithEvents lblVersao As System.Windows.Forms.Label
    Friend WithEvents lstAcao As System.Windows.Forms.ListBox

End Class
