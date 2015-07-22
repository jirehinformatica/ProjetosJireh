Imports System
Imports System.IO
Imports System.Text
Imports System.Security
Imports System.Collections.Generic
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices

Public Class CriptografiaSistema

    Public Sub New()
        Algoritmo = New RijndaelManaged()
        Algoritmo.Mode = CipherMode.CBC
        CriptografiaProvedor = CryptProvider.Rijndael
        keyValue = GerarNovoKey()
    End Sub

    Public Sub New(ByVal ChaveKeyCriptografia As String)
        Algoritmo = New RijndaelManaged()
        Algoritmo.Mode = CipherMode.CBC
        CriptografiaProvedor = CryptProvider.Rijndael
        keyValue = ChaveKeyCriptografia
    End Sub

    Public Sub New(ByVal ProvedorCriptografia As CryptProvider)
        Select Case ProvedorCriptografia
            Case CryptProvider.Rijndael
                Algoritmo = New RijndaelManaged()
                CriptografiaProvedor = CryptProvider.Rijndael
            Case CryptProvider.RC2
                Algoritmo = New RC2CryptoServiceProvider()
                CriptografiaProvedor = CryptProvider.RC2
            Case CryptProvider.DES
                Algoritmo = New DESCryptoServiceProvider()
                CriptografiaProvedor = CryptProvider.DES
            Case CryptProvider.TripleDES
                Algoritmo = New TripleDESCryptoServiceProvider()
                CriptografiaProvedor = CryptProvider.TripleDES
        End Select
        Algoritmo.Mode = CipherMode.CBC
        keyValue = GerarNovoKey()
    End Sub

    Public Shared Function CreateKeyRfc2898(password As String) As String
        Dim salt = New Byte() {1, 2, 23, 234, 37, 48, 134, 63, 248, 4}
        Const Iterations As Integer = 9872
        Dim nkey As Byte()
        Using rfc2898DeriveBytes = New Rfc2898DeriveBytes(password, salt, Iterations)
            nkey = rfc2898DeriveBytes.GetBytes(32)
        End Using
        Return Convert.ToBase64String(nkey)
    End Function

    Public Sub New(ByVal ChaveKeyCriptografia As String, ByVal ProvedorCriptografia As CryptProvider)
        Select Case ProvedorCriptografia
            Case CryptProvider.Rijndael
                Algoritmo = New RijndaelManaged()
                CriptografiaProvedor = CryptProvider.Rijndael
            Case CryptProvider.RC2
                Algoritmo = New RC2CryptoServiceProvider()
                CriptografiaProvedor = CryptProvider.RC2
            Case CryptProvider.DES
                Algoritmo = New DESCryptoServiceProvider()
                CriptografiaProvedor = CryptProvider.DES
            Case CryptProvider.TripleDES
                Algoritmo = New TripleDESCryptoServiceProvider()
                CriptografiaProvedor = CryptProvider.TripleDES
        End Select
        Algoritmo.Mode = CipherMode.CBC
        keyValue = ChaveKeyCriptografia
    End Sub

    Private keyValue As String
    Private keyValueFixo As String
    Private CriptografiaProvedor As CryptProvider
    Private Algoritmo As SymmetricAlgorithm

    Private Shared Function GerarNovoKey() As String
        Dim nKey As String = ""
        Dim aux As String = DateTime.Now.ToString("hhddmmyyyyssMM")
        Dim vl As Char() = {"A", "3", "6", "9", "0", "1", "B", "C", "D", "2", "E", "F", "4", "G", "5", "H", "7", "I", "8", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "0", "T", "2", "U", "5", "V", "7", "X", "Y", "W", "Z"}
        Dim p As Int32
        Dim c As Int32
        For Each i As Char In aux
            p = Int32.Parse(i.ToString())
            c = (p + 1) * 4
            Dim r As New Random
            p = r.Next(4)
            p = c - p - 1
            nKey += vl(p)
        Next
        Dim rr As Byte() = Encoding.UTF8.GetBytes(nKey)
        Return Convert.ToBase64String(rr)
    End Function


    Private Function CreateKey(ByVal strPassword As String) As Byte()
        'Convert strPassword to an array and store in chrData.
        Dim chrData() As Char = strPassword.ToCharArray
        'Use intLength to get strPassword size.
        Dim intLength As Integer = chrData.GetUpperBound(0)
        'Declare bytDataToHash and make it the same size as chrData.
        Dim bytDataToHash(intLength) As Byte

        'Use For Next to convert and store chrData into bytDataToHash.
        For i As Integer = 0 To chrData.GetUpperBound(0)
            bytDataToHash(i) = CByte(Asc(chrData(i)))
        Next

        'Declare what hash to use.
        Dim SHA512 As New System.Security.Cryptography.SHA512Managed
        'Declare bytResult, Hash bytDataToHash and store it in bytResult.
        Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)
        'Declare bytKey(31).  It will hold 256 bits.
        Dim bytKey(31) As Byte

        'Use For Next to put a specific size (256 bits) of 
        'bytResult into bytKey. The 0 To 31 will put the first 256 bits
        'of 512 bits into bytKey.
        For i As Integer = 0 To 31
            bytKey(i) = bytResult(i)
        Next

        Return bytKey 'Return the key.
    End Function
    Private Function CreateIV(ByVal strPassword As String) As Byte()
        'Convert strPassword to an array and store in chrData.
        Dim chrData() As Char = strPassword.ToCharArray
        'Use intLength to get strPassword size.
        Dim intLength As Integer = chrData.GetUpperBound(0)
        'Declare bytDataToHash and make it the same size as chrData.
        Dim bytDataToHash(intLength) As Byte

        'Use For Next to convert and store chrData into bytDataToHash.
        For i As Integer = 0 To chrData.GetUpperBound(0)
            bytDataToHash(i) = CByte(Asc(chrData(i)))
        Next

        'Declare what hash to use.
        Dim SHA512 As New System.Security.Cryptography.SHA512Managed
        'Declare bytResult, Hash bytDataToHash and store it in bytResult.
        Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)
        'Declare bytIV(15).  It will hold 128 bits.
        Dim bytIV(15) As Byte

        'Use For Next to put a specific size (128 bits) of bytResult into bytIV.
        'The 0 To 30 for bytKey used the first 256 bits of the hashed password.
        'The 32 To 47 will put the next 128 bits into bytIV.
        For i As Integer = 32 To 47
            bytIV(i - 32) = bytResult(i)
        Next

        Return bytIV 'Return the IV.
    End Function


    Private Sub SetIV()
        Select Case CriptografiaProvedor
            Case CryptProvider.Rijndael
                Algoritmo.IV = New Byte() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16} '{0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9, 0x5, 0x46, 0x9c, 0xea, 0xa8, 0x4b, 0x73, 0xcc }
            Case Else
                Algoritmo.IV = New Byte() {1, 2, 3, 4, 5, 6, 7, 8} '{ 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9 }
        End Select
    End Sub
    Private Function GetKey() As Byte()
        'keyValueFixo = String.Empty
        'Dim salt As String = String.Empty
        'If Algoritmo.LegalKeySizes.Length > 0 Then
        '    'Tamanho das chaves em bits
        '    Dim keySize As Integer = keyValue.Length * 8
        '    Dim minSize As Integer = Algoritmo.LegalKeySizes(0).MinSize
        '    Dim maxSize As Integer = Algoritmo.LegalKeySizes(0).MaxSize
        '    Dim skipSize As Integer = Algoritmo.LegalKeySizes(0).SkipSize
        '    If keySize > maxSize Then
        '        'Busca o valor máximo da chave
        '        keyValueFixo = keyValue.Substring(0, maxSize / 8)
        '    ElseIf keySize < maxSize Then
        '        'Seta um tamanho válido                                                         %
        '        Dim validSize As Integer = IIf(keySize <= minSize, minSize, (keySize - keySize Mod skipSize) + skipSize)
        '        If keySize < validSize Then
        '            'Preenche a chave com arterisco para corrigir o tamanho
        '            keyValueFixo = keyValue.PadRight(validSize / 8, "*")
        '        End If
        '    End If
        'End If
        'Dim vKey As PasswordDeriveBytes = New PasswordDeriveBytes(keyValueFixo, ASCIIEncoding.ASCII.GetBytes(salt))
        'Return vKey.Salt
        Return CreateKey(Key)
    End Function

    Public ReadOnly Property Key As String
        Get
            Return keyValue
        End Get
    End Property

    Public Function Encriptografar(ByVal texto As String) As String
        Dim plainByte As Byte() = Encoding.UTF8.GetBytes(texto)
        Dim keyByte As Byte() = GetKey()
        Algoritmo.Key = keyByte
        SetIV()
        Dim cryptoTransform As ICryptoTransform = Algoritmo.CreateEncryptor()
        Dim ms As MemoryStream = New MemoryStream()
        Dim cs As CryptoStream = New CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write)
        cs.Write(plainByte, 0, plainByte.Length)
        cs.FlushFinalBlock()
        Dim cryptoByte As Byte() = ms.ToArray()
        Return Convert.ToBase64String(cryptoByte, 0, cryptoByte.GetLength(0))
    End Function

    Public Function Descriptografar(ByVal textoCriptografado As String) As String
        Dim cryptoByte As Byte() = Convert.FromBase64String(textoCriptografado)
        Dim keyByte As Byte() = GetKey()
        Algoritmo.Key = keyByte
        SetIV()
        Dim cryptoTransform As ICryptoTransform = Algoritmo.CreateDecryptor()
        Try
            Dim ms As MemoryStream = New MemoryStream(cryptoByte, 0, cryptoByte.Length)
            Dim cs As CryptoStream = New CryptoStream(ms, cryptoTransform, CryptoStreamMode.Read)
            Dim _streamReader As StreamReader = New StreamReader(cs)
            Return _streamReader.ReadToEnd()
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

End Class

Public Enum CryptProvider
    Rijndael
    RC2
    DES
    TripleDES
End Enum