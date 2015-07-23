Imports MySql.Data.MySqlClient

Public Class Dal_SerialEmpresas

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
            Return "serialempresas"
        End Get
    End Property

    Public ReadOnly Property Transacao As MySQLTransacao
        Get
            Return TransacaoValue
        End Get
    End Property

    Public Class SerialEmpresasColunms
        Public Property CodigoSer_sem As Integer
        Public Property CnpjEmp_sem As String
        Public Property Estacao_sem As Integer
    End Class

    Public MustInherit Class SerialEmpresasColunmsName
        Private Sub New()
        End Sub
        Public Const CodigoSer_sem As String = "CodigoSer_sem"
        Public Const CnpjEmp_sem As String = "CnpjEmp_sem"
        Public Const Estacao_sem As String = "Estacao_sem"
    End Class

    Public Sub Inserir(ByVal Items As List(Of SerialEmpresasColunms))
        Try
            Conexao.Open()
            TransacaoValue.BeginTransacao()
            Items.AsParallel.ForAll(Sub(i As SerialEmpresasColunms)
                                        Inserir(i)
                                    End Sub)
            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Sub Inserir(ByVal Item As SerialEmpresasColunms)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Numero As Integer = MaxNumeroPorCnpj(Item.CnpjEmp_sem)

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("INSERT INTO {0}(", TableName)
            Sintaxe.AppendFormat("{0}, ", SerialEmpresasColunmsName.CnpjEmp_sem)
            Sintaxe.AppendFormat("{0}, ", SerialEmpresasColunmsName.Estacao_sem)
            Sintaxe.AppendFormat("{0}) ", SerialEmpresasColunmsName.CodigoSer_sem)

            Sintaxe.AppendFormat("VALUES(@{0}, ", SerialEmpresasColunmsName.CnpjEmp_sem)
            Parametros.Add(SerialEmpresasColunmsName.CnpjEmp_sem, Item.CnpjEmp_sem, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("@{0},", SerialEmpresasColunmsName.Estacao_sem)
            Parametros.Add(SerialEmpresasColunmsName.Estacao_sem, Numero, MySqlDbType.Int32)
            Sintaxe.AppendFormat("@{0})", SerialEmpresasColunmsName.CodigoSer_sem)
            Parametros.Add(SerialEmpresasColunmsName.CodigoSer_sem, Item.CodigoSer_sem, MySqlDbType.Int32)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Sub Excluir(ByVal Item As List(Of SerialEmpresasColunms))
        Try
            Conexao.Open()
            TransacaoValue.BeginTransacao()
            For Each i As SerialEmpresasColunms In Item
                Excluir(i)
            Next
            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Sub Excluir(ByVal Item As SerialEmpresasColunms)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("DELETE FROM {0}", TableName)
            Sintaxe.AppendFormat("WHERE @{0} = @{0} ", SerialEmpresasColunmsName.CnpjEmp_sem)
            Parametros.Add(SerialEmpresasColunmsName.CnpjEmp_sem, Item.CnpjEmp_sem, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("AND @{0} = @{0}", SerialEmpresasColunmsName.CodigoSer_sem)
            Parametros.Add(SerialEmpresasColunmsName.CodigoSer_sem, Item.CodigoSer_sem, MySqlDbType.Int32)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Sub Excluir(ByVal Cnpj As String)
        Try
            Dim Parametros As New MySQLParametros
            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("DELETE FROM {0}", TableName)
            Sintaxe.AppendFormat("WHERE @{0} = @{0} ", SerialEmpresasColunmsName.CnpjEmp_sem)
            Parametros.Add(SerialEmpresasColunmsName.CnpjEmp_sem, Cnpj, MySqlDbType.VarChar)

            Conexao.Execute(Sintaxe.ToString, Parametros, TransacaoValue)

            TransacaoValue.CommitTransacao()
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Sub

    Public Function ConsultarSerialPorCnpjLista(ByVal Cnpj As String) As List(Of SerialEmpresasColunms)
        Try
            Dim Tabela As DataTable = ConsultarSerialPorCnpjTable(Cnpj)

            Dim Dados As List(Of SerialEmpresasColunms)
            Dados = (From i In Tabela.AsEnumerable Select New SerialEmpresasColunms With { _
                     .CnpjEmp_sem = i.Field(Of String)(SerialEmpresasColunmsName.CnpjEmp_sem),
                     .CodigoSer_sem = i.Field(Of String)(SerialEmpresasColunmsName.CodigoSer_sem),
                     .Estacao_sem = i.Field(Of Integer)(SerialEmpresasColunmsName.Estacao_sem)
                 }).ToList

            Return Dados

        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ConsultarSerialPorCnpjTable(ByVal Cnpj As String) As DataTable
        Try
            Dim Tabela As DataTable
            Dim Parametros As New MySQLParametros

            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("SELECT * FROM {0} ", TableName)
            Parametros.Add(SerialEmpresasColunmsName.CnpjEmp_sem, Cnpj, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("WHERE {0} = @{0}", SerialEmpresasColunmsName.CnpjEmp_sem)

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

    Public Function ConsultarCnpjPorSerialLista(ByVal Serial As String, ByVal Cnpj As String) As SerialEmpresasColunms
        Try
            Dim Tabela As DataTable = ConsultarCnpjPorSerialTable(Serial)

            Dim Dados As SerialEmpresasColunms
            Dados = (From i In Tabela.AsEnumerable Select New SerialEmpresasColunms With { _
                     .CnpjEmp_sem = i.Field(Of String)(SerialEmpresasColunmsName.CnpjEmp_sem).ToString,
                     .CodigoSer_sem = i.Field(Of Nullable(Of Integer))(SerialEmpresasColunmsName.CodigoSer_sem).ToInteger,
                     .Estacao_sem = i.Field(Of Nullable(Of Integer))(SerialEmpresasColunmsName.Estacao_sem).ToInteger
                 }).ToList.Where(Function(x As SerialEmpresasColunms)
                                     If x.CnpjEmp_sem = Cnpj Then
                                         Return True
                                     Else
                                         Return False
                                     End If
                                 End Function).FirstOrDefault

            Return Dados

        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ConsultarCnpjPorSerialLista(ByVal Serial As String) As List(Of SerialEmpresasColunms)
        Try
            Dim Tabela As DataTable = ConsultarCnpjPorSerialTable(Serial)

            Dim Dados As List(Of SerialEmpresasColunms)
            Dados = (From i In Tabela.AsEnumerable Select New SerialEmpresasColunms With { _
                     .CnpjEmp_sem = i.Field(Of String)(SerialEmpresasColunmsName.CnpjEmp_sem),
                     .CodigoSer_sem = i.Field(Of String)(SerialEmpresasColunmsName.CodigoSer_sem),
                     .Estacao_sem = i.Field(Of Integer)(SerialEmpresasColunmsName.Estacao_sem)
                 }).ToList

            Return Dados

        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ConsultarCnpjPorSerialTable(ByVal Serial As String) As DataTable
        Try
            Dim Tabela As DataTable
            Dim Parametros As New MySQLParametros

            Conexao.Open()

            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("SELECT * FROM {0} ", TableName)
            Sintaxe.AppendFormat("INNER JOIN {0} ON {0}.{1} = {2}.{3} ", Dal_SerialHd.TableName, Dal_SerialHd.SerialHDColunmsName.Codigo_ser, TableName, SerialEmpresasColunmsName.CodigoSer_sem)
            Parametros.Add(Dal_SerialHd.SerialHDColunmsName.Serial_ser, Serial, MySqlDbType.VarChar)
            Sintaxe.AppendFormat("WHERE {1}.{0} = @{0}", Dal_SerialHd.SerialHDColunmsName.Serial_ser, Dal_SerialHd.TableName)

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

    Public Function MaxNumeroPorCnpj(ByVal Cnpj As String) As Integer
        Try
            Dim Row As DataRow
            Dim Parametros As New MySQLParametros
            Dim Valor As Integer = 1

            Conexao.Open()
            TransacaoValue.BeginTransacao()

            Dim Sintaxe As New Text.StringBuilder
            Sintaxe.AppendFormat("SELECT MAX({1}) AS {1} FROM {0} ", TableName, SerialEmpresasColunmsName.Estacao_sem)
            Sintaxe.AppendFormat("WHERE {0} = @{0}", SerialEmpresasColunmsName.CnpjEmp_sem)
            Parametros.Add(SerialEmpresasColunmsName.CnpjEmp_sem, Cnpj, MySqlDbType.VarChar)

            Row = Conexao.FillRow(Sintaxe.ToString, Parametros, TransacaoValue)
            If Row IsNot Nothing Then
                Valor += Row(SerialEmpresasColunmsName.Estacao_sem).ToString.ToInteger
            End If

            TransacaoValue.CommitTransacao()

            Return Valor
        Catch ex As Exception
            TransacaoValue.RollBackTransacao()
            Throw
        Finally
            Conexao.Close()
        End Try
    End Function

End Class
