Imports System
Imports System.Windows.Forms

Public Class SearchTextbox
    Inherits ToolStripTextBox

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            Me.Visible = False
            Return True
        End If
    End Function
End Class
