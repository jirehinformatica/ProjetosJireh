<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DebitoAutomatico
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
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.tsbPessoas = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbPessoas, Me.tsbImprimir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 23)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(58, 516)
        Me.tsMenu.TabIndex = 1
        Me.tsMenu.Text = "ToolStrip1"
        '
        'lblCaption
        '
        Me.lblCaption.BackColor = System.Drawing.Color.Ivory
        Me.lblCaption.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(0, 0)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(757, 23)
        Me.lblCaption.TabIndex = 3
        Me.lblCaption.Text = "Gerenciador de débitos do sistema"
        Me.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tsbPessoas
        '
        Me.tsbPessoas.Image = Global.JirehComprovante.My.Resources.Resources.Pessoas24_24
        Me.tsbPessoas.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tsbPessoas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPessoas.Name = "tsbPessoas"
        Me.tsbPessoas.Size = New System.Drawing.Size(55, 35)
        Me.tsbPessoas.Text = "&Pessoas"
        Me.tsbPessoas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsbPessoas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbPessoas.ToolTipText = "Cadastro de pessoas"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.JirehComprovante.My.Resources.Resources.Impressora24x24
        Me.tsbImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(55, 35)
        Me.tsbImprimir.Text = "Imprimir"
        Me.tsbImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsbImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbImprimir.ToolTipText = "Imprimir Comprovante"
        '
        'DebitoAutomatico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 539)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.lblCaption)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "DebitoAutomatico"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Debito automático"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbPessoas As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblCaption As System.Windows.Forms.Label
End Class
