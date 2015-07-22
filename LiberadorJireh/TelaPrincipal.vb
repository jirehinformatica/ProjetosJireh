Imports JirehBDUtil
Public Class TelaPrincipal

    Public Sub TratarErros(ByVal ex As Exception)

    End Sub

    Public Sub Alerta(ByVal msg As String)
        MessageBox.Show(msg, "Informação.", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Function GetEmpresa() As String
        Try
            Dim aux As Object
            aux = lbEmpresas.SelectedItem
            If aux Is Nothing OrElse String.IsNullOrEmpty(aux) Then
                Return String.Empty
            End If
            Dim aux2 As String = aux.ToString.Split("|")(0)
            aux2 = aux2.Replace("_", "")
            Return aux2.Trim
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Sub CarregarEmpresas()
        Try
            Dim Ger As New Dal_Empresas(CnMySQL)
            Dim Tabela As DataTable = Ger.Consultar

            lbEmpresas.Items.Clear()
            lbEmpresas.Items.AddRange(Tabela.AsEnumerable.Select(Function(x)
                                                                     Dim aux As String = String.Empty
                                                                     Dim aux2 As String = x.Field(Of String)(Dal_Empresas.EmpresasColunmsName.Cnpj_emp).ToString
                                                                     If aux2.Length <> 18 Then
                                                                         aux2 = "___" & aux2
                                                                     End If
                                                                     aux &= aux2 & " | "
                                                                     aux2 = IIf(x.Field(Of Boolean)(Dal_Empresas.EmpresasColunmsName.Ativo_emp).ToBool, "__Ativo", "InAtivo")
                                                                     aux &= aux2 & " | "
                                                                     aux &= x.Field(Of String)(Dal_Empresas.EmpresasColunmsName.RazaoSocial_emp).ToString
                                                                     Return aux
                                                                 End Function).ToArray)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub TelaPrincipal_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not OpenConexaoMySQL() Then
                Alerta(OpenConexaoMySQLMensagem)
                Close()
            End If

            CarregarEmpresas()
        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub

    Private Sub lbEmpresas_TextChanged(sender As Object, e As EventArgs) Handles lbEmpresas.TextChanged, lbEmpresas.TabIndexChanged, lbEmpresas.Click
        Try
            Dim Cnpj As String = GetEmpresa()
            If String.IsNullOrEmpty(Cnpj) Then
                Exit Sub
            End If



        Catch ex As Exception
            TratarErros(ex)
        End Try
    End Sub
End Class
