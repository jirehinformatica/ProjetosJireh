Public Class MdiComprovante

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Function Semana(ByVal value As Integer) As String
        Select Case value
            Case 0
                Return "Domingo, "
            Case 1
                Return "Segunda-feira, "
            Case 2
                Return "Terça-feira, "
            Case 3
                Return "Quarta-feira, "
            Case 4
                Return "Quinta-feira, "
            Case 5
                Return "Sexta-feira, "
            Case Else
                Return "Sabado, "
        End Select
    End Function

    Public Sub SetDataHora(ByVal value As DateTime)
        Try
            ssStatus.Items("ttsHora").Text = Semana(value.DayOfWeek) & value.ToString("dd/MM/yyyy HH:mm")
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SetProgresso(ByVal Iniciar As Boolean)
        Try
            CanceladoPorUsuario = False
            ssStatus.Items("ttsCancelar").Visible = True
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub SetProgresso(ByVal Posicao As Integer, Optional ByVal Maximo As Integer = -1, Optional ByVal Fim As Boolean = False)
        Try
            Dim pp As ToolStripProgressBar = DirectCast(ssStatus.Items("ttsProgresso"), ToolStripProgressBar)
            If Fim Then
                pp.Value = 0
                ssStatus.Items("ttsPorcent").Text = String.Empty
                ssStatus.Items("ttsCancelar").Visible = False
                SetPrompt("")
            Else
                If Maximo <> -1 Then
                    pp.Maximum = Maximo
                End If
                pp.Value = Posicao
                If Maximo = 0 Then
                    ssStatus.Items("ttsPorcent").Text = String.Empty
                Else
                    ssStatus.Items("ttsPorcent").Text = Math.Round(pp.Value * 100 / pp.Maximum, 0).ToString("000") & " %"
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SetVersao()
        Try
            ssStatus.Items("tssVersao").Text = System.String.Format("Versão {0}.{1:00}", My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SetPrompt(Optional ByVal value As String = "", Optional ByVal Posicao As Integer = -1)
        Try
            If value = "" Then
                ssStatus.Items("ttsPrompt").Text = String.Empty
            Else
                ssStatus.Items("ttsPrompt").Text = value
            End If
            If Posicao <> -1 Then
                SetProgresso(Posicao)
            End If
            'My.Application.DoEvents()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SetTerminal(ByVal Value As Integer)
        Try
            If Value < 1 Then
                ssStatus.Items("tssSep01").Visible = False
            Else
                ssStatus.Items("tssSep01").Visible = True
            End If
            ssStatus.Items("ttsTerminal").Text = "Terminal: " & Value.ToString("000")
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub ComprovanteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprovanteToolStripMenuItem.Click, tsbComprovante.Click
        Try
            Dim F As New Comprovante
            FormOpenMDI(F)
        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub ttsCancelar_Click(sender As Object, e As EventArgs) Handles ttsCancelar.Click
        ssStatus.Items("ttsCancelar").Visible = False
        CanceladoPorUsuario = True
    End Sub

    Private Sub SairTootStripMenuItem_Click(sender As Object, e As EventArgs) Handles SairTootStripMenuItem.Click, tsbSair.Click
        Try
            FormularioMDI.Close()
        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub
End Class