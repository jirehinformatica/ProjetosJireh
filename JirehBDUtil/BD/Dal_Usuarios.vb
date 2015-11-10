Imports MySql.Data.MySqlClient

Public Class Dal_Usuarios

    Private TransacaoValue As MySQLTransacao
    Private Conexao As MySQL

    Public Sub New(ByVal Cn As MySQL, Optional ByVal Tx As MySQLTransacao = Nothing)
        Try
            TransacaoValue = IIf(Tx Is Nothing, New MySQLTransacao(Cn), Tx)
            Conexao = Cn
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Shared ReadOnly Property TableName As String
        Get
            Return "usuarios"
        End Get
    End Property

    Public ReadOnly Property Transacao As MySQLTransacao
        Get
            Return TransacaoValue
        End Get
    End Property

    Public Class UsuariosColunms
        Public Property CnpjEmp_usu As String
        Public Property Login_usu As String
        Public Property Nome_usu As String
        Public Property Email_usu As String
        Public Property Senha_usu As String
        Public Property Ativo_usu As Boolean
        Public Property Cadastro_usu As DateTime
    End Class

    Public MustInherit Class UsuariosColunmsName
        Private Sub New()
        End Sub
        Public Const CnpjEmp_usu As String = "CnpjEmp_usu"
        Public Const Login_usu As String = "Login_usu"
        Public Const Nome_usu As String = "Nome_usu"
        Public Const Email_usu As String = "Email_usu"
        Public Const Senha_usu As String = "Senha_usu"
        Public Const Ativo_usu As String = "Ativo_usu"
        Public Const Cadastro_usu As String = "Cadastro_usu"
    End Class

    Public Sub Inserir(ByVal Item As UsuariosColunms)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("INSERT INTO {0}(", TableName)
            Sintaxe.AppendFormat("{0}, ", UsuariosColunmsName.CnpjEmp_usu)
            Sintaxe.AppendFormat("{0}, ", UsuariosColunmsName.Login_usu)
            Sintaxe.AppendFormat("{0}, ", UsuariosColunmsName.Nome_usu)
            Sintaxe.AppendFormat("{0}, ", UsuariosColunmsName.Email_usu)
            Sintaxe.AppendFormat("{0}, ", UsuariosColunmsName.Senha_usu)
            Sintaxe.AppendFormat("{0}, ", UsuariosColunmsName.Ativo_usu)
            Sintaxe.AppendFormat("{0}) ", UsuariosColunmsName.Cadastro_usu)

            Sintaxe.AppendFormat("VALUES(@{0}, ", UsuariosColunmsName.CnpjEmp_usu)
            Parametros.Add(UsuariosColunmsName.CnpjEmp_usu, Item.CnpjEmp_usu, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("@{0}, ", UsuariosColunmsName.Login_usu)
            Parametros.Add(UsuariosColunmsName.Login_usu, Item.Login_usu, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("@{0}, ", UsuariosColunmsName.Nome_usu)
            Parametros.Add(UsuariosColunmsName.Nome_usu, Item.Nome_usu, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("@{0}, ", UsuariosColunmsName.Email_usu)
            Parametros.Add(UsuariosColunmsName.Email_usu, Item.Email_usu, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("@{0}, ", UsuariosColunmsName.Senha_usu)
            Parametros.Add(UsuariosColunmsName.Senha_usu, EnCriptografar(Item.Senha_usu), MySqlDbType.VarChar)
            Sintaxe.AppendFormat("@{0}, ", UsuariosColunmsName.Ativo_usu)
            Parametros.Add(UsuariosColunmsName.Ativo_usu, Item.Ativo_usu, MySqlDbType.Bit)
            Sintaxe.AppendFormat("@{0})", UsuariosColunmsName.Cadastro_usu)
            Parametros.Add(UsuariosColunmsName.Cadastro_usu, Item.Cadastro_usu, MySqlDbType.DateTime)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Sub Excluir(ByVal CNPJ As String, Optional ByVal Login As String = "")
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("DELETE FROM {0} ", TableName)
            Sintaxe.AppendFormat("WHERE @{0} = @{0} ", UsuariosColunmsName.CnpjEmp_usu)
            Parametros.Add(UsuariosColunmsName.CnpjEmp_usu, CNPJ, MySqlDbType.VarChar)

            If Not String.IsNullOrEmpty(Login) Then
                Sintaxe.AppendFormat("AND @{0} = @{0} ", UsuariosColunmsName.Login_usu)
                Parametros.Add(UsuariosColunmsName.Login_usu, Login, MySqlDbType.VarChar)
            End If

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Sub Alterar(ByVal Item As UsuariosColunms)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("UPDATE {0} SET ", TableName)

            Sintaxe.AppendFormat("{0} = @{0}, ", UsuariosColunmsName.Ativo_usu)
            Parametros.Add(UsuariosColunmsName.Ativo_usu, Item.Ativo_usu, MySqlDbType.Bit)
            Sintaxe.AppendFormat("{0} = @{0}, ", UsuariosColunmsName.Cadastro_usu)
            Parametros.Add(UsuariosColunmsName.Cadastro_usu, Item.Cadastro_usu, MySqlDbType.DateTime)
            Sintaxe.AppendFormat("{0} = @{0}, ", UsuariosColunmsName.Email_usu)
            Parametros.Add(UsuariosColunmsName.Email_usu, Item.Email_usu, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("{0} = @{0}, ", UsuariosColunmsName.Nome_usu)
            Parametros.Add(UsuariosColunmsName.Nome_usu, Item.Nome_usu, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("{0} = @{0} ", UsuariosColunmsName.Senha_usu)
            Parametros.Add(UsuariosColunmsName.Senha_usu, EnCriptografar(Item.Senha_usu), MySqlDbType.VarChar)

            Sintaxe.AppendFormat("WHERE {0} = @{0} ", UsuariosColunmsName.CnpjEmp_usu)
            Parametros.Add(UsuariosColunmsName.CnpjEmp_usu, Item.CnpjEmp_usu, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("AND {0} = @{0} ", UsuariosColunmsName.Login_usu)
            Parametros.Add(UsuariosColunmsName.Login_usu, Item.Login_usu, MySqlDbType.VarChar)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Function Consultar(ByVal Cnpj As String, ByVal Login As String) As UsuariosColunms
        Try
            Dim Row As DataRow
            Dim Parametros As New MySQLParametros

            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("SELECT * FROM {0} ", TableName)
            Parametros.Add(UsuariosColunmsName.CnpjEmp_usu, Cnpj, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("WHERE {0} = @{0} ", UsuariosColunmsName.CnpjEmp_usu)
            Parametros.Add(UsuariosColunmsName.Login_usu, Login, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("AND {0} = @{0} ", UsuariosColunmsName.Login_usu)

            Row = Conexao.FillRow(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()

            Dim item As New UsuariosColunms
            If Row IsNot Nothing Then
                item.Ativo_usu = Row(UsuariosColunmsName.Ativo_usu).ToString.ToBool
                item.Cadastro_usu = Row(UsuariosColunmsName.Cadastro_usu).ToString.ToDate
                item.CnpjEmp_usu = Row(UsuariosColunmsName.CnpjEmp_usu).ToString
                item.Email_usu = Row(UsuariosColunmsName.Email_usu).ToString
                item.Login_usu = Row(UsuariosColunmsName.Login_usu).ToString
                item.Nome_usu = Row(UsuariosColunmsName.Nome_usu).ToString
                item.Senha_usu = DesCriptografar(Row(UsuariosColunmsName.Senha_usu).ToString)
            End If

            Return item
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Function

    Public Function Consultar(ByVal Cnpj As String) As List(Of UsuariosColunms)
        Try
            Dim Tabela As DataTable
            Dim Parametros As New MySQLParametros

            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("SELECT * FROM {0} ", TableName)
            Parametros.Add(UsuariosColunmsName.CnpjEmp_usu, Cnpj, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("WHERE {0} = @{0} ", UsuariosColunmsName.CnpjEmp_usu)

            Tabela = Conexao.FillTable(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()

            Dim itens As New List(Of UsuariosColunms)
            If Tabela.Rows.Count > 0 Then
                itens = (From i In Tabela.AsEnumerable Select New UsuariosColunms With {
                       .Ativo_usu = i.Field(Of Boolean)(UsuariosColunmsName.Ativo_usu).ToBool,
                       .Cadastro_usu = i.Field(Of DateTime)(UsuariosColunmsName.Cadastro_usu).ToDate,
                       .CnpjEmp_usu = i.Field(Of String)(UsuariosColunmsName.CnpjEmp_usu).ToStr,
                       .Email_usu = i.Field(Of String)(UsuariosColunmsName.Email_usu).ToStr,
                       .Login_usu = i.Field(Of String)(UsuariosColunmsName.Login_usu).ToStr,
                       .Nome_usu = i.Field(Of String)(UsuariosColunmsName.Nome_usu).ToStr,
                       .Senha_usu = DesCriptografar(i.Field(Of String)(UsuariosColunmsName.Senha_usu).ToStr)
                       }).ToList
            End If

            Return itens
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Function

End Class
