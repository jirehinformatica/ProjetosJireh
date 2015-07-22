<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Relatorio
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
        Me.rpVisual = New JirehReports.ReportViewerForm()
        Me.SuspendLayout()
        '
        'rpVisual
        '
        Me.rpVisual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rpVisual.Location = New System.Drawing.Point(0, 0)
        Me.rpVisual.Name = "rpVisual"
        Me.rpVisual.ShowBackButton = False
        Me.rpVisual.ShowFindControls = False
        Me.rpVisual.Size = New System.Drawing.Size(705, 466)
        Me.rpVisual.TabIndex = 0
        '
        'Relatorio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 466)
        Me.Controls.Add(Me.rpVisual)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "Relatorio"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visualizar"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpVisual As JirehReports.ReportViewerForm

End Class
