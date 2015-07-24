Imports System.Net
Imports System.IO

Public Module Geral

    Public Sub CarregarReport(ByVal PathAplicacao As String, ByVal RelatorioName As String)
        Try
            Dim local As String = "ftp.vieiramachado.adv.br/jireh/Reports/" & RelatorioName ' ComprovantePagamento.rdlc"  '"http://www.vieiramachado.adv.br/jireh/Reports"

            Dim request As FtpWebRequest = FtpWebRequest.Create(local)
            request.Credentials = New NetworkCredential("vieiramachado", "alegre1")
            request.Method = WebRequestMethods.Ftp.DownloadFile
            request.UsePassive = True
            request.UseBinary = True
            request.KeepAlive = True

            Dim response As FtpWebResponse = DirectCast(request.GetResponse(), FtpWebResponse)
            Dim responseStream As Stream = response.GetResponseStream()

            Dim buffer As Byte() = New Byte(2047) {}

            'Definir o local onde o arquivo será criado.
            Dim newFile As New FileStream(PathAplicacao & RelatorioName, FileMode.Create)
            'Ler o arquivo de origem
            Dim readCount As Integer = responseStream.Read(buffer, 0, buffer.Length)
            While readCount > 0
                'Escrever o arquivo
                newFile.Write(buffer, 0, readCount)
                readCount = responseStream.Read(buffer, 0, buffer.Length)
            End While
            newFile.Close()
            responseStream.Close()
            response.Close()

        Catch ex As Exception
            Throw
        End Try
    End Sub

End Module
