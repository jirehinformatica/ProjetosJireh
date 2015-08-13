Imports System
Imports System.Text
Imports System.Net
Imports System.Net.Mail

Public Class Email

    Private oEmail As MailMessage
    Private oSmtp As SmtpClient
    Private oRemetente As MailAddress

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        oEmail = New MailMessage
        oSmtp = New SmtpClient
        oEmail.IsBodyHtml = True
        MensagemPrioridade = MailPriority.Normal
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Email"></param>
    ''' <param name="Display"></param>
    ''' <remarks></remarks>
    Public Sub RemetenteEmail(ByVal Email As String, Optional ByVal Display As String = "")
        If Display = "" Then
            oRemetente = New MailAddress(Email)
        Else
            oRemetente = New MailAddress(Email, Display, Encoding.GetEncoding("ISO-8859-1"))
        End If
        oEmail.From = oRemetente
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Email"></param>
    ''' <remarks></remarks>
    Public Sub DestinatarioEmailAdd(ByVal Email As String)
        oEmail.To.Add(Email)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Email"></param>
    ''' <remarks></remarks>
    Public Sub DestinatarioCopiaAdd(ByVal Email As String)
        oEmail.CC.Add(Email)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Email"></param>
    ''' <remarks></remarks>
    Public Sub DestinatarioCopiaOcultaAdd(ByVal Email As String)
        oEmail.Bcc.Add(Email)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Assunto As String
        Get
            Return oEmail.Subject
        End Get
        Set(ByVal value As String)
            oEmail.Subject = value
            oEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1")
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MensagemEmail As String
        Get
            Return oEmail.Body
        End Get
        Set(ByVal value As String)
            oEmail.Body = value
            oEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1")
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MensagemTextoPossuiHTML As Boolean
        Get
            Return oEmail.IsBodyHtml
        End Get
        Set(ByVal value As Boolean)
            oEmail.IsBodyHtml = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MensagemPrioridade As System.Net.Mail.MailPriority
        Get
            Return oEmail.Priority
        End Get
        Set(ByVal value As System.Net.Mail.MailPriority)
            oEmail.Priority = value
        End Set
    End Property

    Public Sub AnexoAdd(ByVal CaminhoArquivo As String)

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EnviarServidorEmail As String
        Get
            Return oSmtp.Host
        End Get
        Set(ByVal value As String)
            oSmtp.Host = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="senha"></param>
    ''' <remarks></remarks>
    Public Sub EnviarUsuarioSenhaAdd(ByVal usuario As String, ByVal senha As String)
        oSmtp.Credentials = New NetworkCredential(usuario, senha)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EnviarServidorPorta As Integer
        Get
            Return oSmtp.Port
        End Get
        Set(ByVal value As Integer)
            oSmtp.Port = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EnviarEmail() As Boolean
        Try
            oSmtp.Send(oEmail)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

End Class
