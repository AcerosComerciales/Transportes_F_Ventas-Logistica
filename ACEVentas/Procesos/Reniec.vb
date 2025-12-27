
Imports System.Drawing
Imports System.Net
Imports System.IO
Imports System.Web

Namespace Libreria
    Public Class Persona

        Public Enum Resul
            Ok = 0
            NoResul = 1
            ErrorCapcha = 2
            [Error] = 3
        End Enum
        Private state As Resul
        Private _Nombres As String
        Private _ApePaterno As String
        Private _ApeMaterno As String
        Private _NombreCompleto As String
        Private myCookie As CookieContainer

        Public ReadOnly Property GetCapcha() As Image
            Get
                Return ReadCapcha()
            End Get
        End Property
        Public ReadOnly Property Nombres() As String
            Get
                Return _Nombres
            End Get
        End Property
        Public ReadOnly Property ApePaterno() As String
            Get
                Return _ApePaterno
            End Get
        End Property
        Public ReadOnly Property ApeMaterno() As String
            Get
                Return _ApeMaterno
            End Get
        End Property
        Public ReadOnly Property NombreCompleto() As String
            Get
                Return _NombreCompleto
            End Get
        End Property
        Public ReadOnly Property GetResul() As Resul
            Get
                Return state
            End Get
        End Property
        Public Sub New(numDni As String)
            Try
                myCookie = Nothing
                myCookie = New CookieContainer()
                ServicePointManager.Expect100Continue = True
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3
                ' ReadCapcha()
                GetInfo(numDni)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Private Function ValidarCertificado(sender As Object, certificate As System.Security.Cryptography.X509Certificates.X509Certificate, chain As System.Security.Cryptography.X509Certificates.X509Chain, sslPolicyErrors As System.Net.Security.SslPolicyErrors) As [Boolean]
            Return True
        End Function
        Private Function ReadCapcha() As Image
            Try
                System.Net.ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidarCertificado)
                'Dim myWebRequest As HttpWebRequest = DirectCast(WebRequest.Create("https://cel.reniec.gob.pe/valreg/codigo.do"), HttpWebRequest)
                Dim myWebRequest As HttpWebRequest = DirectCast(WebRequest.Create("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetCapcha"), HttpWebRequest)
                myWebRequest.CookieContainer = myCookie
                myWebRequest.Proxy = Nothing
                myWebRequest.Credentials = CredentialCache.DefaultCredentials
                Dim myWebResponse As HttpWebResponse = DirectCast(myWebRequest.GetResponse(), HttpWebResponse)
                Dim myImgStream As Stream = myWebResponse.GetResponseStream()
                Return Image.FromStream(myImgStream)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '  Public Sub GetInfo(numDni As String, ImgCapcha As String)
        Public Sub GetInfo(numDni As String)
            Try
                
                Dim Respuesta, parametros, enviado, Solicitud As Object
                Solicitud = CreateObject("winhttp.winhttprequest.5.1")
                Dim url As String

                url = "https://api.apis.net.pe/v1/"
                parametros = "dni?numero=" & numDni
                Solicitud.Open("GET", url & parametros, False)
                Solicitud.send("")
                Respuesta = Solicitud.responseText

                If InStr(Respuesta, "Not Found") > 0 Then
                    'consultaDNI1 = False
                    Exit Sub
                Else

                    Respuesta = Solicitud.responsetext
                    Me._Nombres = limpiarRespuesta(Respuesta, "nombres", "}")
                    Me._ApePaterno = limpiarRespuesta(Respuesta, "apellidoPaterno", "apellidoMaterno")
                    Me._ApeMaterno = limpiarRespuesta(Respuesta, "apellidoMaterno", "nombres")
                    ' consultaDNI1 = True
                    Exit Sub
                End If

                'Dim suma As Integer, resto As Integer, complemento As Byte
                'suma = 5 + Val(Mid(numDni, 1, 1)) * 3 + Val(Mid(numDni, 2, 1)) * 2 + Val(Mid(numDni, 3, 1)) * 7 + Val(Mid(numDni, 4, 1)) * 6 + Val(Mid(numDni, 5, 1)) * 5 + Val(Mid(numDni, 6, 1)) * 4 + Val(Mid(numDni, 7, 1)) * 3 + Val(Mid(numDni, 8, 1)) * 2
                'resto = suma Mod 11
                'codval = IIf(resto = 1, 0, Val(Left(11 - resto, 1)))



            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Function limpiarRespuesta(Resp As String, pi As String, pf As String) As String
            Dim devu, posi, posf

            posi = InStr(Resp, pi) + Len(pi) + 1
            posf = InStr(Resp, pf) - 1
            devu = Mid(Resp, posi, posf - posi)
            devu = Replace(devu, ":", "")
            devu = Replace(devu, ",", "")
            devu = Replace(devu, Chr(34), "")
            devu = Replace(devu, Chr(10), "")
            devu = Replace(devu, Chr(13), "")
            devu = Replace(devu, Chr(92), "")

            devu = Trim(devu)
            limpiarRespuesta = devu
        End Function
    End Class
End Namespace

