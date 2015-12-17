Imports MySql.Data.MySqlClient

Public Class Dal_ContaCorrente

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
            Return "contacorrente"
        End Get
    End Property

    Public ReadOnly Property Transacao As MySQLTransacao
        Get
            Return TransacaoValue
        End Get
    End Property

    Public Class ContaCorrenteColunms
        Public Sub New()
            ID_ccoAntigo = New ContaCorrenteColunms
            Atribuido = String.Empty
        End Sub
        Private ID_ccoAntigo As ContaCorrenteColunms
        Private Atribuido As String
        Protected Friend Function GetValorAntigo() As ContaCorrenteColunms
            Return ID_ccoAntigo
        End Function
        Public ReadOnly Property ID_cco As String
            Get
                Return Banco_cco.ToString.PadLeft(5, "0") & Agencia_cco.Trim & Operacao_cco.ToString.PadLeft(3, "0") & ContaCorrente_cco.ToString
            End Get
        End Property
        Public Property CpfCnpjPes_cco As String
        Public Property Cadastro_cco As DateTime
        Private Banco_ccoValue As Integer
        Public Property Banco_cco As Integer
            Get
                Return Banco_ccoValue
            End Get
            Set(value As Integer)
                If Banco_ccoValue <> 0 AndAlso Atribuido.IndexOf("1") = -1 Then
                    ID_ccoAntigo.Banco_ccoValue = Banco_ccoValue
                    Atribuido &= "1"
                End If
                Banco_ccoValue = value
            End Set
        End Property
        Private Agencia_ccoValue As String
        Public Property Agencia_cco As String
            Get
                Return Agencia_ccoValue
            End Get
            Set(value As String)
                If Not String.IsNullOrEmpty(Agencia_ccoValue.Trim) AndAlso Atribuido.IndexOf("2") = -1 Then
                    ID_ccoAntigo.Agencia_ccoValue = Agencia_ccoValue
                    Atribuido &= "2"
                End If
                Agencia_ccoValue = value
            End Set
        End Property
        Private Operacao_ccoValue As Integer
        Public Property Operacao_cco As Integer
            Get
                Return Operacao_ccoValue
            End Get
            Set(value As Integer)
                If Operacao_ccoValue <> 0 AndAlso Atribuido.IndexOf("3") = -1 Then
                    ID_ccoAntigo.Operacao_ccoValue = Operacao_ccoValue
                    Atribuido &= "3"
                End If
                Operacao_ccoValue = value
            End Set
        End Property
        Private ContaCorrente_ccoValue As Integer
        Public Property ContaCorrente_cco As Integer
            Get
                Return ContaCorrente_ccoValue
            End Get
            Set(value As Integer)
                If ContaCorrente_ccoValue <> 0 AndAlso Atribuido.IndexOf("4") = -1 Then
                    ID_ccoAntigo.ContaCorrente_ccoValue = ContaCorrente_ccoValue
                    Atribuido &= "4"
                End If
                ContaCorrente_ccoValue = value
            End Set
        End Property
        Public Property Ativo_cco As Boolean
    End Class

    Public Class ContaCorrenteColunmsName
        Public Const CpfCnpjPes_cco As String = "CpfCnpjPes_cco"
        Public Const ID_cco As String = "ID_cco"
        Public Const Cadastro_cco As String = "Cadastro_cco"
        Public Const Banco_cco As String = "Banco_cco"
        Public Const Agencia_cco As String = "Agencia_cco"
        Public Const Operacao_cco As String = "Operacao_cco"
        Public Const ContaCorrente_cco As String = "ContaCorrente_cco"
        Public Const Ativo_cco As String = "Ativo_cco"
    End Class

    Public Sub Inserir(ByVal Item As ContaCorrenteColunms)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("INSERT INTO {0}(", TableName)
            Sintaxe.AppendFormat("{0}, ", ContaCorrenteColunmsName.CpfCnpjPes_cco)
            Sintaxe.AppendFormat("{0}, ", ContaCorrenteColunmsName.ID_cco)
            Sintaxe.AppendFormat("{0}, ", ContaCorrenteColunmsName.Cadastro_cco)
            Sintaxe.AppendFormat("{0}, ", ContaCorrenteColunmsName.Banco_cco)
            Sintaxe.AppendFormat("{0}, ", ContaCorrenteColunmsName.Agencia_cco)
            Sintaxe.AppendFormat("{0}, ", ContaCorrenteColunmsName.Operacao_cco)
            Sintaxe.AppendFormat("{0}) ", ContaCorrenteColunmsName.Ativo_cco)

            Sintaxe.AppendFormat("VALUES(@{0}, ", ContaCorrenteColunmsName.CpfCnpjPes_cco)
            Parametros.Add(ContaCorrenteColunmsName.CpfCnpjPes_cco, Item.CpfCnpjPes_cco, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("@{0}, ", ContaCorrenteColunmsName.ID_cco)
            Parametros.Add(ContaCorrenteColunmsName.ID_cco, Item.ID_cco, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("@{0}, ", ContaCorrenteColunmsName.Cadastro_cco)
            Parametros.Add(ContaCorrenteColunmsName.Cadastro_cco, Item.Cadastro_cco, MySqlDbType.DateTime)
            Sintaxe.AppendFormat("@{0}, ", ContaCorrenteColunmsName.Banco_cco)
            Parametros.Add(ContaCorrenteColunmsName.Banco_cco, Item.Banco_cco, MySqlDbType.Int32)
            Sintaxe.AppendFormat("@{0}, ", ContaCorrenteColunmsName.Agencia_cco)
            Parametros.Add(ContaCorrenteColunmsName.Agencia_cco, Item.Agencia_cco, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("@{0}, ", ContaCorrenteColunmsName.Operacao_cco)
            Parametros.Add(ContaCorrenteColunmsName.Operacao_cco, Item.Operacao_cco, MySqlDbType.Int32)
            Sintaxe.AppendFormat("@{0})", ContaCorrenteColunmsName.Ativo_cco)
            Parametros.Add(ContaCorrenteColunmsName.Ativo_cco, Item.Ativo_cco, MySqlDbType.Bit)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Sub Excluir(ByVal Item As ContaCorrenteColunms)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("DELETE FROM {0} ", TableName)
            Sintaxe.AppendFormat("WHERE @{0} = @{0} ", ContaCorrenteColunmsName.CpfCnpjPes_cco)
            Parametros.Add(ContaCorrenteColunmsName.CpfCnpjPes_cco, Item.CpfCnpjPes_cco, MySqlDbType.VarChar)
            If Not String.IsNullOrEmpty(Item.ID_cco) Then
                Sintaxe.AppendFormat("AND @{0} = @{0} ", ContaCorrenteColunmsName.ID_cco)
                Parametros.Add(ContaCorrenteColunmsName.ID_cco, Item.ID_cco, MySqlDbType.VarChar)
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

    Public Sub Alterar(ByVal Item As ContaCorrenteColunms)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            Dim ItemAux As ContaCorrenteColunms = Item.GetValorAntigo

            TransacaoValue.BeginTransacao()

            If ItemAux.ID_cco <> Item.ID_cco Then
                Excluir(ItemAux)
                Inserir(Item)
                Exit Sub
            End If

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("UPDATE {0} SET ", TableName)

            Sintaxe.AppendFormat("{0} = @{0}, ", ContaCorrenteColunmsName.Ativo_cco)
            Parametros.Add(ContaCorrenteColunmsName.Ativo_cco, Item.Ativo_cco, MySqlDbType.Bit)
            Sintaxe.AppendFormat("{0} = @{0}, ", ContaCorrenteColunmsName.Cadastro_cco)
            Parametros.Add(ContaCorrenteColunmsName.Cadastro_cco, Item.Cadastro_cco, MySqlDbType.DateTime)

            Sintaxe.AppendFormat("WHERE {0} = @{0} ", ContaCorrenteColunmsName.CpfCnpjPes_cco)
            Parametros.Add(ContaCorrenteColunmsName.CpfCnpjPes_cco, Item.CpfCnpjPes_cco, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("AND {0} = @{0} ", ContaCorrenteColunmsName.ID_cco)
            Parametros.Add(ContaCorrenteColunmsName.ID_cco, Item.ID_cco, MySqlDbType.VarChar)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Function Consultar(ByVal CnpjCpf As String) As List(Of ContaCorrenteColunms)
        Try
            Dim Tabela As DataTable
            Dim Parametros As New MySQLParametros

            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("SELECT * FROM {0} ", TableName)
            Parametros.Add(ContaCorrenteColunmsName.CpfCnpjPes_cco, CnpjCpf, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("WHERE {0} = @{0} ", ContaCorrenteColunmsName.CpfCnpjPes_cco)

            Tabela = Conexao.FillTable(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()

            Dim itens As New List(Of ContaCorrenteColunms)
            If Tabela.Rows.Count > 0 Then
                itens = (From i In Tabela.AsEnumerable Select New ContaCorrenteColunms With {
                        .Agencia_cco = i.Field(Of String)(ContaCorrenteColunmsName.Agencia_cco).ToStr,
                        .Ativo_cco = i.Field(Of Boolean)(ContaCorrenteColunmsName.Ativo_cco).ToBool,
                        .Banco_cco = i.Field(Of Integer)(ContaCorrenteColunmsName.Banco_cco).ToInteger,
                        .Cadastro_cco = i.Field(Of DateTime)(ContaCorrenteColunmsName.Cadastro_cco).ToDate,
                        .ContaCorrente_cco = i.Field(Of Integer)(ContaCorrenteColunmsName.ContaCorrente_cco).ToInteger,
                        .CpfCnpjPes_cco = i.Field(Of String)(ContaCorrenteColunmsName.CpfCnpjPes_cco).ToStr,
                        .Operacao_cco = i.Field(Of Integer)(ContaCorrenteColunmsName.Operacao_cco).ToInteger
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

    Public Function ConsultarTable(ByVal CnpjCpf As String) As DataTable
        Try
            Dim Tabela As DataTable
            Dim Parametros As New MySQLParametros

            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("SELECT * FROM {0} ", TableName)
            Parametros.Add(ContaCorrenteColunmsName.CpfCnpjPes_cco, CnpjCpf, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("WHERE {0} = @{0} ", ContaCorrenteColunmsName.CpfCnpjPes_cco)

            Tabela = Conexao.FillTable(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()

            Return Tabela
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Function

End Class
