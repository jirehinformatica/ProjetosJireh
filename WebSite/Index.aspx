<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebSite.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/css/bootstrap.css" rel="stylesheet" />
    <link href="Styles/Pages/Index.css" rel="stylesheet" />
    <script src="Script/JQuery/jquery-2.1.4.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Pagina">
            <div class="login_0"></div>
            <div class="login_5">
                <div class="login_1"></div>
                <div class="login_2">
                    <div class="login_3"></div>
                    <div class="login_4">
                        <div class="login_6 Text_1">Informe um usuário e senha válidos para obter acesso aos módulos da Jireh Soluções</div>
                        <div class="login_7">
                            <div class="Text_2">Módulos Jireh Soluções</div>
                            <div class="Text_3">Acesso de usuários</div>
                            <div class="form-horizontal">
                                <div class="control-group">
                                    <label class="control-label Text_label" for="txtEmpresa">CNPJ/CPF:</label>
                                    <div class="controls spac_10">
                                        <input runat="server" id="txtEmpresa" placeholder="Empresa" />
                                    </div>
                                    <label class="control-label Text_label" for="txtUsuario">Usuário:</label>
                                    <div class="controls spac_10">
                                        <input runat="server" id="txtUsuario" placeholder="Usuário" />
                                    </div>
                                    <label class="control-label Text_label" for="txtSenha">Senha:</label>
                                    <div class="controls spac_15">
                                        <input type="password" runat="server" id="txtSenha" placeholder="Senha" />
                                    </div>
                                </div>
                            </div>
                            <div class="login_8">
                                <a href="Index.aspx" class="Text_label">Esqueceu a senha?</a>&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnEntrar" runat="server" Text="Entrar" CssClass="btn btn-success" Width="100px" OnClick="btnEntrar_Click" />
                            </div>
                        </div>
                        <div>
                            <asp:Label ID="lblMensagemErro" runat="server" Font-Names="Verdana" Font-Size="8.5pt" ForeColor="#C00000" CssClass="login_10" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="login_9">&nbsp;</div>
            </div>
        </div>
    </form>
</body>
</html>
