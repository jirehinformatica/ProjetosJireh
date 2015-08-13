<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MdiComprovante
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MdiComprovante))
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.ttsHora = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssVersao = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ttsTerminal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ttsProgresso = New System.Windows.Forms.ToolStripProgressBar()
        Me.ttsPorcent = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ttsPrompt = New System.Windows.Forms.ToolStripStatusLabel()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.EmissãoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsAtalho = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbComprovante = New System.Windows.Forms.ToolStripButton()
        Me.tsbExtrato = New System.Windows.Forms.ToolStripButton()
        Me.tsbSair = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssSep01 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ttsCancelar = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ComprovanteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtratoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SairTootStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssStatus.SuspendLayout()
        Me.msMenu.SuspendLayout()
        Me.tsAtalho.SuspendLayout()
        Me.SuspendLayout()
        '
        'ssStatus
        '
        Me.ssStatus.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ttsHora, Me.ToolStripStatusLabel1, Me.tssVersao, Me.tssSep01, Me.ttsTerminal, Me.ToolStripStatusLabel2, Me.ttsProgresso, Me.ttsPorcent, Me.ttsCancelar, Me.ToolStripStatusLabel3, Me.ttsPrompt})
        Me.ssStatus.Location = New System.Drawing.Point(0, 448)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ssStatus.Size = New System.Drawing.Size(718, 30)
        Me.ssStatus.TabIndex = 1
        '
        'ttsHora
        '
        Me.ttsHora.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ttsHora.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttsHora.Name = "ttsHora"
        Me.ttsHora.Size = New System.Drawing.Size(80, 25)
        Me.ttsHora.Text = "data hora"
        '
        'tssVersao
        '
        Me.tssVersao.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tssVersao.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold)
        Me.tssVersao.Name = "tssVersao"
        Me.tssVersao.Size = New System.Drawing.Size(56, 25)
        Me.tssVersao.Text = "Versao"
        '
        'ttsTerminal
        '
        Me.ttsTerminal.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ttsTerminal.Name = "ttsTerminal"
        Me.ttsTerminal.Size = New System.Drawing.Size(72, 25)
        Me.ttsTerminal.Text = "Terminal"
        '
        'ttsProgresso
        '
        Me.ttsProgresso.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ttsProgresso.Name = "ttsProgresso"
        Me.ttsProgresso.Size = New System.Drawing.Size(100, 24)
        Me.ttsProgresso.Step = 1
        '
        'ttsPorcent
        '
        Me.ttsPorcent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ttsPorcent.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ttsPorcent.Name = "ttsPorcent"
        Me.ttsPorcent.Size = New System.Drawing.Size(48, 25)
        Me.ttsPorcent.Text = "100 %"
        '
        'ttsPrompt
        '
        Me.ttsPrompt.Name = "ttsPrompt"
        Me.ttsPrompt.Size = New System.Drawing.Size(141, 25)
        Me.ttsPrompt.Text = "mensagem em progresso"
        '
        'msMenu
        '
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmissãoToolStripMenuItem})
        Me.msMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(718, 24)
        Me.msMenu.TabIndex = 2
        '
        'EmissãoToolStripMenuItem
        '
        Me.EmissãoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ComprovanteToolStripMenuItem, Me.ExtratoToolStripMenuItem, Me.ToolStripSeparator1, Me.SairTootStripMenuItem})
        Me.EmissãoToolStripMenuItem.Name = "EmissãoToolStripMenuItem"
        Me.EmissãoToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.EmissãoToolStripMenuItem.Text = "&Emissão"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'tsAtalho
        '
        Me.tsAtalho.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.tsAtalho.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbComprovante, Me.tsbExtrato, Me.ToolStripSeparator2, Me.tsbSair})
        Me.tsAtalho.Location = New System.Drawing.Point(0, 24)
        Me.tsAtalho.Name = "tsAtalho"
        Me.tsAtalho.Size = New System.Drawing.Size(718, 39)
        Me.tsAtalho.TabIndex = 3
        Me.tsAtalho.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'tsbComprovante
        '
        Me.tsbComprovante.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbComprovante.Image = Global.JirehComprovante.My.Resources.Resources.comprovante32x32
        Me.tsbComprovante.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbComprovante.Name = "tsbComprovante"
        Me.tsbComprovante.Size = New System.Drawing.Size(36, 36)
        Me.tsbComprovante.ToolTipText = "Emissão comprovante"
        '
        'tsbExtrato
        '
        Me.tsbExtrato.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbExtrato.Image = Global.JirehComprovante.My.Resources.Resources.Extrato24x24
        Me.tsbExtrato.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExtrato.Name = "tsbExtrato"
        Me.tsbExtrato.Size = New System.Drawing.Size(36, 36)
        Me.tsbExtrato.ToolTipText = "Extrato bancário"
        '
        'tsbSair
        '
        Me.tsbSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSair.Image = Global.JirehComprovante.My.Resources.Resources.Sair32x32
        Me.tsbSair.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSair.Name = "tsbSair"
        Me.tsbSair.Size = New System.Drawing.Size(36, 36)
        Me.tsbSair.ToolTipText = "Sair do Sistema"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripStatusLabel1.Image = Global.JirehComprovante.My.Resources.Resources.sep24x24
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(24, 25)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'tssSep01
        '
        Me.tssSep01.Image = Global.JirehComprovante.My.Resources.Resources.sep24x24
        Me.tssSep01.Name = "tssSep01"
        Me.tssSep01.Size = New System.Drawing.Size(24, 25)
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripStatusLabel2.Image = Global.JirehComprovante.My.Resources.Resources.sep24x24
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(24, 25)
        Me.ToolStripStatusLabel2.Text = "ToolStripStatusLabel2"
        '
        'ttsCancelar
        '
        Me.ttsCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ttsCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ttsCancelar.Image = Global.JirehComprovante.My.Resources.Resources.cancelar24x24
        Me.ttsCancelar.Name = "ttsCancelar"
        Me.ttsCancelar.Size = New System.Drawing.Size(24, 25)
        Me.ttsCancelar.Text = "ToolStripStatusLabel4"
        Me.ttsCancelar.ToolTipText = "Cancelar Execução"
        Me.ttsCancelar.Visible = False
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripStatusLabel3.Image = Global.JirehComprovante.My.Resources.Resources.sep24x24
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(24, 25)
        Me.ToolStripStatusLabel3.Text = "ToolStripStatusLabel3"
        '
        'ComprovanteToolStripMenuItem
        '
        Me.ComprovanteToolStripMenuItem.Image = Global.JirehComprovante.My.Resources.Resources.comprovante16x16
        Me.ComprovanteToolStripMenuItem.Name = "ComprovanteToolStripMenuItem"
        Me.ComprovanteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ComprovanteToolStripMenuItem.Text = "&Comprovante"
        '
        'ExtratoToolStripMenuItem
        '
        Me.ExtratoToolStripMenuItem.Image = Global.JirehComprovante.My.Resources.Resources.Extrato16x16
        Me.ExtratoToolStripMenuItem.Name = "ExtratoToolStripMenuItem"
        Me.ExtratoToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExtratoToolStripMenuItem.Text = "E&xtrato"
        '
        'SairTootStripMenuItem
        '
        Me.SairTootStripMenuItem.Image = Global.JirehComprovante.My.Resources.Resources.Sair16x16
        Me.SairTootStripMenuItem.Name = "SairTootStripMenuItem"
        Me.SairTootStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SairTootStripMenuItem.Text = "&Sair"
        Me.SairTootStripMenuItem.ToolTipText = "Sair do Sistema"
        '
        'MdiComprovante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 478)
        Me.Controls.Add(Me.tsAtalho)
        Me.Controls.Add(Me.ssStatus)
        Me.Controls.Add(Me.msMenu)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.msMenu
        Me.MaximizeBox = False
        Me.Name = "MdiComprovante"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Jireh Sistemas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        Me.tsAtalho.ResumeLayout(False)
        Me.tsAtalho.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents tsAtalho As System.Windows.Forms.ToolStrip
    Friend WithEvents ttsHora As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ttsProgresso As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ttsPorcent As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssVersao As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ttsPrompt As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents EmissãoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComprovanteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbComprovante As System.Windows.Forms.ToolStripButton
    Friend WithEvents ttsCancelar As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SairTootStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbSair As System.Windows.Forms.ToolStripButton
    Friend WithEvents tssSep01 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ttsTerminal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsbExtrato As System.Windows.Forms.ToolStripButton
    Friend WithEvents ExtratoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
