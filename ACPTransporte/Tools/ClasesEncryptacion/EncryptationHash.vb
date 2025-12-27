Imports System.Security.Cryptography

Public Class EncryptationHash


    ' Generar un Salt aleatorio
    Public Function GenerarSalt(Optional tamaño As Integer = 16) As Byte()
        Dim salt(tamaño - 1) As Byte
        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(salt)
        End Using
        Return salt
    End Function

    ' Crear Hash con PBKDF2
    Public Function HashPassword(password As String, salt As Byte(), Optional iteraciones As Integer = 10000) As String
        Using pbkdf2 As New Rfc2898DeriveBytes(password, salt, iteraciones)
            Dim hash As Byte() = pbkdf2.GetBytes(32) ' 32 bytes = 256 bits
            Return Convert.ToBase64String(hash)
        End Using
    End Function

    ' Verificar contraseña
    Public Function VerificarPassword(password As String, salt As Byte(), hashGuardado As String, Optional iteraciones As Integer = 10000) As Boolean
        Dim hashVerificar As String = HashPassword(password, salt, iteraciones) 'Recuerad papu si cambias las iteraciones la contraseña ya no va a ser la misma 
        Return hashGuardado = hashVerificar
    End Function

    'Para verigicacion de contraseñas 

    '    Dim hashGuardado As String = reader("GtusHash").ToString()
    '    Dim saltBase64 As String = reader("GtusSalt").ToString()

    '    ' Convertir el Salt de texto a bytes
    '    Dim saltBytes As Byte() = Convert.FromBase64String(saltBase64)

    '    ' Verificar
    '    Dim valido As Boolean = VerificarPassword(txtPassword.Text, saltBytes, hashGuardado)

    '    If valido Then
    '    MessageBox.Show("Contraseña correcta")
    'Else
    '    MessageBox.Show("Contraseña incorrecta")
    'End If




End Class
