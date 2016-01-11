Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

<System.Web.Services.WebService(Namespace:="http://jireh.net/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class wsJirehNsa
    Inherits System.Web.Services.WebService


    <WebMethod(), _
     Description("Retorna para a empresa e cedente informado o próximo número do NSA para utilização bancaria." & _
                 "Cedente: Número do cedente cadastrado ao banco;" & _
                 "EmpresaCNPJ: Número do CNPJ da empresa consumidora do cedente (Somente números);" & _
                 "O número do NSA é incrementado ao ser utilizado o serviço, sendo que a não utilização do número o mesmo deve ser descartado.")> _
    Public Function GetProximoNSA(ByVal Cedente As String, ByVal EmpresaCNPJ As String) As ControleNSA
        Dim Item As New ControleNSA
        Try
            If String.IsNullOrEmpty(EmpresaCNPJ) Then
                Item.Sucesso = False
                Item.Codigo = "MA01"
                Item.Mensagem = "CNPJ da empresa não informado. O número do CNPJ da empresa é obrigatório e deve ser informado somente números."
                Item.NumeroNSA = String.Empty
                Return Item
            End If
            If String.IsNullOrEmpty(Cedente) Then
                Item.Sucesso = False
                Item.Codigo = "MA02"
                Item.Mensagem = "Número do cedente não informado. O número do cedente é obrigatório."
                Item.NumeroNSA = String.Empty
                Return Item
            End If

            If EmpresaCNPJ.Length <> 14 AndAlso EmpresaCNPJ.Length <> 11 Then
                Item.Sucesso = False
                Item.Codigo = "MA03"
                Item.Mensagem = "CNPJ/CPF informado inválido."
                Item.NumeroNSA = String.Empty
                Return Item
            End If

            If EmpresaCNPJ.Length = 14 Then
                EmpresaCNPJ = EmpresaCNPJ.Substring(0, 2) & "." & EmpresaCNPJ.Substring(2, 3) & "." & EmpresaCNPJ.Substring(5, 3) & "/" & EmpresaCNPJ.Substring(8, 4) & "-" & EmpresaCNPJ.Substring(12, 2)
            Else
                EmpresaCNPJ = EmpresaCNPJ.Substring(0, 3) & "." & EmpresaCNPJ.Substring(3, 3) & "." & EmpresaCNPJ.Substring(6, 3) & "-" & EmpresaCNPJ.Substring(9, 2)
            End If

            If Not JirehBDUtil.OpenConexaoMySQL Then
                Item.Sucesso = False
                Item.Codigo = "S901"
                Item.Mensagem = "Serviço de banco de dados fora de operação. Tente novamente em alguns instantes."
                Item.NumeroNSA = String.Empty
                Return Item
            End If

            Dim Empresa As New JirehBDUtil.Dal_Empresas(JirehBDUtil.CnMySQL)
            Dim Ativo As JirehBDUtil.Dal_Empresas.EmpresasColunms = Empresa.Consultar(EmpresaCNPJ)
            If String.IsNullOrEmpty(Ativo.Cnpj_emp) Then
                Item.Sucesso = False
                Item.Codigo = "MA04"
                Item.Mensagem = "CNPJ/CPF não cadastrado. Informe o CNPJ/CPF corretamente e tente novamente. O CNPJ/CPF deve ser informado apenas os números."
                Item.NumeroNSA = String.Empty
                Return Item
            End If
            If Not Ativo.Ativo_emp Then
                Item.Sucesso = False
                Item.Codigo = "MA05"
                Item.Mensagem = "A empresa não está ativa. Não é possível fornecer o número do NSA."
                Item.NumeroNSA = String.Empty
                Return Item
            End If

            Dim NsaEmpresa As New JirehBDUtil.Dal_EmpresaNsa(JirehBDUtil.CnMySQL)
            Dim proximo As String = NsaEmpresa.ProximoNSA(EmpresaCNPJ, Cedente)
            If String.IsNullOrEmpty(JirehBDUtil.ToStr(proximo).Trim) Then
                Item.Sucesso = False
                Item.Codigo = "SA01"
                Item.Mensagem = "Não foi possível retornar o número de NSA. O número de NSA atual para o cedente é inválido."
                Item.NumeroNSA = String.Empty
                Return Item
            End If

            Item.Sucesso = True
            Item.Codigo = "MA99"
            Item.Mensagem = "Número de NSA gerado com sucesso."
            Item.NumeroNSA = proximo
            Return Item

        Catch ex As Exception
            Item.Sucesso = False
            Item.Codigo = "9999"
            Item.Mensagem = ex.Message
            Item.NumeroNSA = String.Empty
            Return Item
        End Try
    End Function

End Class