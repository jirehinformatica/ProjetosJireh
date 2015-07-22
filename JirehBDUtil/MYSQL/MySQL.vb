Imports MySql.Data.MySqlClient

Public Class MySQL

#Region "PRINCIPAIS BASE DE DADOS"

    Private Shared BaseBD As MySQL

    Private Cn As MySqlConnection

    Private Function GetStringConnection() As String
        Try
            Dim Gcns() As String = {String.Format("{0}={1}", cDataBase, DataBase), _
                                    String.Format("{0}={1}", cDataSource, DataSource), _
                                    String.Format("{0}={1}", cUserId, UserId), _
                                    String.Format("{0}={1}", cPassWord, Password), _
                                    cPooling}

            Return String.Join(";", Gcns)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Sub New(ByVal vDataBase As String, ByVal vDataSource As String, ByVal vUser As String, ByVal vPassword As String)
        Try
            DataBaseValue = vDataBase
            DataSourceValue = vDataSource
            UserIdValue = vUser
            PasswordValue = vPassword
            AberturaCount = 0

            Cn = New MySqlConnection(GetStringConnection)

            Cn.Open()

        Catch exM As MySqlException
            Throw New Exception("Erro na conexão MySQL - Mensagem: " & exM.Message & " - Strack: " & exM.StackTrace, exM)
        Catch ex As Exception
            Throw
        Finally
            Cn.Close()
        End Try
    End Sub

#End Region

#Region "PROPRIEDADES"

    Private Const cDataBase As String = "Database"
    Private Const cDataSource As String = "Data Source"
    Private Const cUserId As String = "User Id"
    Private Const cPassWord As String = "Password"
    Private Const cPooling As String = "pooling=false"

    Private DataBaseValue As String
    Private DataSourceValue As String
    Private UserIdValue As String
    Private PasswordValue As String

    Public ReadOnly Property DataBase As String
        Get
            Return DataBaseValue
        End Get
    End Property

    Public ReadOnly Property DataSource As String
        Get
            Return DataSourceValue
        End Get
    End Property

    Public ReadOnly Property UserId As String
        Get
            Return UserIdValue
        End Get
    End Property

    Public ReadOnly Property Password As String
        Get
            Return PasswordValue
        End Get
    End Property

    Public Function Conexao() As MySqlConnection
        Return Cn
    End Function

#End Region

#Region "BUSCAR CONEXAO"

    Public Shared Function GetBD(ByVal vDataBase As String, ByVal vDataSource As String, ByVal vUser As String, ByVal vPassword As String) As MySQL
        Try
            If BaseBD Is Nothing Then
                BaseBD = New MySQL(vDataBase, vDataSource, vUser, vPassword)
            End If
            Return BaseBD
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function GetBD(ByVal vConnetionString As String) As MySQL
        Try
            Dim vdb As String = String.Empty
            Dim vds As String = String.Empty
            Dim vus As String = String.Empty
            Dim vps As String = String.Empty

            Dim aux() As String = vConnetionString.Split(";")
            Dim bus() As String
            If aux.Length < 4 Then
                Throw New Exception("A string de conexão é invalida.")
            End If
            For Each s As String In aux
                bus = s.Split("=")
                If bus.Length <> 2 Then
                    Throw New Exception("A string de conexão é invalida.")
                End If
                Select Case bus(0).Trim.ToLower
                    Case cDataBase.ToLower
                        vdb = bus(1)
                    Case cDataSource.ToLower
                        vds = bus(1)
                    Case cUserId.ToLower
                        vus = bus(1)
                    Case cPassWord.ToLower
                        vps = bus(1)
                End Select
            Next
            Return GetBD(vdb, vds, vus, vps)
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

    Private AberturaCount As Integer

    Public Sub Open()
        If AberturaCount = 0 Then
            Cn.Open()
        End If
        AberturaCount += 1
    End Sub

    Public Sub Close()
        AberturaCount -= 1
        If AberturaCount = 0 Then
            Cn.Close()
        End If
    End Sub

    Private Function MontaCommand(ByVal SQLSintaxe As String, ByVal ParametrosMySQL As MySQLParametros, ByVal Trans As MySQLTransacao) As MySqlCommand
        Try

            Dim cm As MySqlCommand
            If Trans Is Nothing Then
                cm = New MySqlCommand(SQLSintaxe, Cn)
            Else
                cm = New MySqlCommand(SQLSintaxe, Cn, Trans.Transacao)
            End If
            If ParametrosMySQL IsNot Nothing AndAlso ParametrosMySQL.GetParametros.Count > 0 Then
                cm.Parameters.AddRange(ParametrosMySQL.GetParametros.ToArray)
            End If
            Return cm

        Catch exM As MySqlException
            Throw New Exception("Erro na conexão MySQL - Mensagem: " & exM.Message & " - Strack: " & exM.StackTrace, exM)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub Execute(ByVal SQLSintaxe As String, Optional ByVal ParametrosMySQL As MySQLParametros = Nothing, Optional ByVal Trans As MySQLTransacao = Nothing)
        Try
            Dim commad As MySqlCommand = MontaCommand(SQLSintaxe, ParametrosMySQL, Trans)
            commad.ExecuteNonQuery()
        Catch exM As MySqlException
            Throw New Exception("Erro na conexão MySQL - Mensagem: " & exM.Message & " - Strack: " & exM.StackTrace, exM)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function ExecuteScalar(ByVal SQLSintaxe As String, Optional ByVal ParametrosMySQL As MySQLParametros = Nothing, Optional ByVal Trans As MySQLTransacao = Nothing) As Object
        Try
            Dim commad As MySqlCommand = MontaCommand(SQLSintaxe, ParametrosMySQL, Trans)
            Return commad.ExecuteScalar
        Catch exM As MySqlException
            Throw New Exception("Erro na conexão MySQL - Mensagem: " & exM.Message & " - Strack: " & exM.StackTrace, exM)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function Fill(ByVal SQLSintaxe As String, Optional ByVal ParametrosMySQL As MySQLParametros = Nothing, Optional ByVal Trans As MySQLTransacao = Nothing) As DataSet
        Try

            Dim commad As MySqlCommand = MontaCommand(SQLSintaxe, ParametrosMySQL, Trans)
            Dim da As New MySqlDataAdapter(commad)
            Dim ds As New DataSet
            da.Fill(ds)
            da.FillSchema(ds, SchemaType.Source)
            Return ds

        Catch exM As MySqlException
            Throw New Exception("Erro na conexão MySQL - Mensagem: " & exM.Message & " - Strack: " & exM.StackTrace, exM)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function FillTable(ByVal SQLSintaxe As String, Optional ByVal ParametrosMySQL As MySQLParametros = Nothing, Optional ByVal Trans As MySQLTransacao = Nothing) As DataTable
        Try
            Dim ds As DataSet = Fill(SQLSintaxe, ParametrosMySQL, Trans)
            Dim dt As DataTable = Nothing
            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function FillRow(ByVal SQLSintaxe As String, Optional ByVal ParametrosMySQL As MySQLParametros = Nothing, Optional ByVal Trans As MySQLTransacao = Nothing) As DataRow
        Try
            Dim dt As DataTable = FillTable(SQLSintaxe, ParametrosMySQL, Trans)
            Dim dr As DataRow = Nothing
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
            End If
            Return dr
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function FillValue(ByVal SQLSintaxe As String, Optional ByVal ParametrosMySQL As MySQLParametros = Nothing, Optional ByVal Trans As MySQLTransacao = Nothing) As Object
        Try
            Dim dr As DataRow = FillRow(SQLSintaxe, ParametrosMySQL, Trans)
            If dr IsNot Nothing Then
                Return dr(0)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

End Class
