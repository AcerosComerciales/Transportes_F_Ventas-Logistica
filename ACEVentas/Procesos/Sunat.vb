Imports System.Drawing
Imports System.Net
Imports System.IO
Imports System.Web
Imports System.Text
Imports System.Text.RegularExpressions

Imports System.Collections.Generic
Imports System.Linq
Imports System.Net.Mime

Imports System.Threading.Tasks
Imports System.Net.Security
Imports System.Security


Imports System.Security.Policy
Imports mshtml


Namespace LibSunat
    Public Class Persona

        Public Enum Resul
            Ok = 0
            NoResul = 1
            ErrorCapcha = 2
            [Error] = 3
            RucInvalido = 4
        End Enum

        Private state As Resul
        Private _RazonSocial As String
        Private _nombrecomercial As String
        Private _Estado As String
        Private _Condicion As String
        Private _Direccion As String
        Private _Telefonos As String
        Private _tiporespuesta As Integer
        Private _mensajerespuesta As String
        Private _actividadesconomicas As String
        Private _afiliadopledesde As String
        Private _condicioncontribuyente As String
        Private _comprobantespago As String
        Private _estadocontribuyente As String
        Private _fechainicioactividades As String
        Private _fechainscripcion As String
        Private _tipocontribuyente As String
        Private _sistemaemisioncomprobante As String
        Private _padrones As String
        Private myCookie As CookieContainer

#Region "Propiedades"
        Public ReadOnly Property GetCapcha() As Image
            Get
                Return ReadCapcha()
            End Get
        End Property
        Public ReadOnly Property RazonSocial() As String
            Get
                Return _RazonSocial
            End Get
        End Property
        Public ReadOnly Property NombreComercial() As String
            Get
                Return _nombrecomercial
            End Get

        End Property
        Public ReadOnly Property Estado() As String
            Get
                Return _Estado
            End Get
        End Property
        Public ReadOnly Property Condicion() As String
            Get
                Return _Condicion
            End Get
        End Property
        Public ReadOnly Property Direccion() As String
            Get
                Return _Direccion
            End Get
        End Property
        Public ReadOnly Property Telefonos() As String
            Get
                Return _Telefonos
            End Get
        End Property

        Public ReadOnly Property GetResul() As Resul
            Get
                Return state
            End Get
        End Property
        Public ReadOnly Property TipoRespuesta() As Integer
            Get
                Return _tiporespuesta
            End Get
        End Property
        Public ReadOnly Property MensajeRespuesta() As Integer
            Get
                Return _mensajerespuesta
            End Get

        End Property
        Public ReadOnly Property ActividadesEconomicas() As Integer
            Get
                Return _actividadesconomicas
            End Get

        End Property
        Public ReadOnly Property ComprobantesPago() As Integer
            Get
                Return _comprobantespago
            End Get

        End Property
        Public ReadOnly Property FechaInscripcion() As Integer
            Get
                Return _fechainscripcion
            End Get

        End Property
        Public ReadOnly Property TipoContribuyente() As Integer
            Get
                Return _tipocontribuyente
            End Get

        End Property
        Public ReadOnly Property SistemaEmisionComprobante() As Integer
            Get
                Return _sistemaemisioncomprobante
            End Get

        End Property
        Public ReadOnly Property Padrones() As Integer
            Get
                Return _padrones
            End Get

        End Property

#End Region
#Region "Constructor"
        Public Sub New()
            Try
                myCookie = Nothing
                myCookie = New CookieContainer()

                ServicePointManager.Expect100Continue = True
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
#End Region
        Private Function ValidarCertificado(ByVal sender As Object, ByVal certificate As Cryptography.X509Certificates.X509Certificate, ByVal chain As Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As SslPolicyErrors) As [Boolean]
            Return True
        End Function
        Private Function ReadCapcha() As Image
            Try
                ServicePointManager.ServerCertificateValidationCallback = New RemoteCertificateValidationCallback(AddressOf ValidarCertificado)

                Dim myWebRequest As HttpWebRequest = DirectCast(WebRequest.Create("http://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/captcha?accion=image"), HttpWebRequest)

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
    



        Public Class DatosRUC
            Public Property TipoRespuesta As Short
            Public Property MensajeRespuesta As String
            Public Property RUC As String
            Public Property TipoContribuyente As String
            Public Property NombreComercial As String
            Public Property RazonSocial As String
            Public Property FechaInscripcion As String
            Public Property FechaInicioActividades As String
            Public Property EstadoContribuyente As String
            Public Property CondicionContribuyente As String
            Public Property DomicilioFiscal As String
            Public Property SistemaEmisionComprobante As String
            Public Property ActividadComercioExterior As String
            Public Property SistemaContabilidiad As String
            Public Property ActividadesEconomicas As String
            Public Property ComprobantesPago As String
            Public Property SistemaEmisionElectrónica As String
            Public Property EmisorElectrónicoDesde As String
            Public Property ComprobantesElectronicos As String
            Public Property AfiliadoPLEDesde As String
            Public Property Padrones As String

        End Class



        Public ConsultaSunat(17) As String

        Const webLR As String = "https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias?accion=consPorRazonSoc&razSoc=Luis"
        Const webLR2 As String = "https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias?accion=consPorRuc&actReturn=1&modo=1&nroRuc="


        Function ConsultaRUCSunat(ByVal numRUC As String) As Boolean

            'Dim Solicitud As New MSXML2.XMLHTTP60
            Dim Solicitud = CreateObject("MSXML2.XMLHTTP.3.0")
            Dim caracteres As Byte, Validador As Boolean, nRUC, random, randomP
            Dim inicial, final
            Dim RespuestaTexto As String
            Dim RespuestaHTML As String
            'Dim HTML As Object

            Dim Respuesta, enviado

            On Error Resume Next

            Dim i As Byte, n As Byte

            'Validación del número de RUC
            caracteres = Len(numRUC)

            Select Case caracteres
                Case 8
                    Validador = True
                    '  nRUC = ConvertirDNIaRUC(numRUC)
                Case 11
                    If ValidarRUC(numRUC) = "Correcto" Then
                        Validador = True
                        nRUC = numRUC
                    Else
                        Validador = False
                    End If

                Case Else
                    Validador = False
            End Select

            If Validador = False Then
                ConsultaRUCSunat = False
                Exit Function
            End If
            '--------------------------------

            'Crear sesión y capturar random
            enviado = ""
            Solicitud.Open("POST", webLR, False)
            Solicitud.setrequestheader("Content-type", "application/x-www-form-urlencoded")
            Solicitud.send(enviado)
            Respuesta = Solicitud.ResponseText

            randomP = limpiarRespuesta(Respuesta, "numRnd", "modo")
            random = limpiarRespuesta(randomP, "e", ">")
            '--------------------------------

            'Realizar la consulta
            Solicitud.Open("POST", webLR2 & numRUC & "&numRnd=" & random, False)
            Solicitud.setrequestheader("Content-type", "application/x-www-form-urlencoded")
            Solicitud.send(enviado)
            Respuesta = Solicitud.ResponseText
            'Solicitud = Nothing
            '--------------------------------

            'Validar
            If InStr(RespuestaTexto, "no es válido") > 0 Then
                ConsultaRUCSunat = False
                Exit Function
            End If

            If InStr(Respuesta, "Pagina de Error") > 0 Then
                ConsultaRUCSunat = False

                Exit Function
            End If



            Dim contenidoHTML As String
            contenidoHTML = WebUtility.HtmlDecode(Respuesta)
            Dim datosRUC As String = ObtenerDatos(contenidoHTML)
            'ConsultaRUCSunat = True
            '--------------------------------
            ConsultaRUCSunat = True
            Return True



            '------------------------------------------------------------------------------------
            '''''consulta rapida pero sin direccion

            'Dim Respuesta, parametros, enviado, Solicitud As Object
            'Dim url As String
            'url = "https://consultaruc.win/api/ruc/"

            'Solicitud = CreateObject("MSXML2.ServerXMLHTTP")
            'Solicitud.Open("GET", url & numRUC, False)
            'Solicitud.send("")
            'Respuesta = Solicitud.responseText

            'If InStr(Respuesta, "false") > 0 Then
            '    Exit Function
            'Else
            '    Me._RazonSocial = limpiarRespuesta2(Respuesta, "razon_social", "estado")
            '    Me._Estado = limpiarRespuesta2(Respuesta, "estado", "direccion")
            '    Me._Direccion = limpiarRespuesta2(Respuesta, "direccion", "condicion")
            '    Me._Condicion = limpiarRespuesta2(Respuesta, "condicion", "}")

            'End If



        End Function
      
        Function limpiarRespuesta(Resp As String, pi As String, pf As String) As String
            Dim devu, posi, posf

            posi = InStr(Resp, pi) + Len(pi) + 1
            posf = InStr(Resp, pf)
            devu = Mid(Resp, posi, posf - posi)
            devu = Replace(devu, ":", "")
            devu = Replace(devu, ",", "")
            devu = Replace(devu, Chr(34), "")
            devu = Replace(devu, Chr(10), " ")
            devu = Replace(devu, Chr(13), " ")
            devu = Replace(devu, Chr(92), " ")

            devu = Trim(devu)
            limpiarRespuesta = devu
        End Function
        Function limpiarRespuesta2(Respuesta As String, para1 As String, para2 As String) As String
            Dim posi As Long, posf As Long, Temporal

            posi = InStr(Respuesta, para1) + Len(para1)
            posf = InStr(Respuesta, para2)

            Temporal = Mid(Respuesta, posi, posf - posi)
            Temporal = Replace(Temporal, ",", "")
            Temporal = Replace(Temporal, Chr(34), "")
            Temporal = Replace(Temporal, ":", "")
            Temporal = Replace(Temporal, "{", "")
            Temporal = Replace(Temporal, Chr(13), "")
            Temporal = Replace(Temporal, Chr(10), "")
            Temporal = Trim(Temporal)

            limpiarRespuesta2 = Temporal
        End Function
        Private Function ObtenerDatos(ByVal contenidoHTML As String) As String
            ' Dim oCuTexto As String
            ' Dim oEnSUNAT As EnSUNAT = New EnSUNAT()
            Dim nombreInicio As String = "<HEAD><TITLE>"
            Dim nombreFin As String = "</TITLE></HEAD>"
            Dim contenidoBusqueda As String = ExtraerContenidoEntreTagString(contenidoHTML, 0, nombreInicio, nombreFin)

            If contenidoBusqueda = ".:: Pagina de Mensajes ::." Then
                nombreInicio = "<p class=""error"">"
                nombreFin = "</p>"
                _tiporespuesta = 2
                _mensajerespuesta = ExtraerContenidoEntreTagString(contenidoHTML, 0, nombreInicio, nombreFin)
            ElseIf contenidoBusqueda = ".:: Pagina de Error ::." Then
                nombreInicio = "<p class=""error"">"
                nombreFin = "</p>"
                _tiporespuesta = 3
                _mensajerespuesta = ExtraerContenidoEntreTagString(contenidoHTML, 0, nombreInicio, nombreFin)
            Else
                _tiporespuesta = 2
                nombreInicio = "<div class=""list-group"">"
                nombreFin = "<div class=""panel-footer text-center"">"
                contenidoBusqueda = ExtraerContenidoEntreTagString(contenidoHTML, 0, nombreInicio, nombreFin)

                If contenidoBusqueda = "" Then
                    nombreInicio = "<strong>"
                    nombreFin = "</strong>"
                    _mensajerespuesta = ExtraerContenidoEntreTagString(contenidoHTML, 0, nombreInicio, nombreFin)
                    If _mensajerespuesta = "" Then _mensajerespuesta = "No se encuentra las cabeceras principales del contenido HTML"
                Else
                    contenidoHTML = contenidoBusqueda
                    _mensajerespuesta = "Mensaje del inconveniente no especificado"
                    nombreInicio = "<h4 class=""list-group-item-heading"">"
                    nombreFin = "</h4>"
                    Dim resultadoBusqueda As Integer = contenidoHTML.IndexOf(nombreInicio, 0, StringComparison.OrdinalIgnoreCase)

                    If resultadoBusqueda > -1 Then
                        resultadoBusqueda += nombreInicio.Length
                        Dim arrResultado As String() = ExtraerContenidoEntreTag(contenidoHTML, resultadoBusqueda, nombreInicio, nombreFin)

                        If arrResultado IsNot Nothing Then
                            _RazonSocial = arrResultado(1)
                            nombreInicio = "<p class=""list-group-item-text"">"
                            nombreFin = "</p>"
                            arrResultado = ExtraerContenidoEntreTag(contenidoHTML, Convert.ToInt32(arrResultado(0)), nombreInicio, nombreFin)

                            If arrResultado IsNot Nothing Then
                                _tipocontribuyente = arrResultado(1)
                                arrResultado = ExtraerContenidoEntreTag(contenidoHTML, Convert.ToInt32(arrResultado(0)), nombreInicio, nombreFin)
                                'nombre comercial
                                If arrResultado IsNot Nothing Then
                                    '_fechainscripcion = arrResultado(1)
                                    _nombrecomercial = Regex.Replace(arrResultado(1).Trim(), " {2,}", " ")
                                    arrResultado = ExtraerContenidoEntreTag(contenidoHTML, Convert.ToInt32(arrResultado(0)), nombreInicio, nombreFin)

                                    If arrResultado IsNot Nothing Then
                                        _fechainicioactividades = arrResultado(1)
                                        arrResultado = ExtraerContenidoEntreTag(contenidoHTML, Convert.ToInt32(arrResultado(0)), nombreInicio, nombreFin)

                                        If arrResultado IsNot Nothing Then
                                            _estadocontribuyente = arrResultado(1).Trim()
                                            arrResultado = ExtraerContenidoEntreTag(contenidoHTML, Convert.ToInt32(arrResultado(0)), nombreInicio, nombreFin)

                                            If arrResultado IsNot Nothing Then
                                                _condicioncontribuyente = arrResultado(1).Trim()
                                                arrResultado = ExtraerContenidoEntreTag(contenidoHTML, Convert.ToInt32(arrResultado(0)), nombreInicio, nombreFin)

                                                If arrResultado IsNot Nothing Then
                                                    ' _Direccion = arrResultado(1).Trim()
                                                    _fechainscripcion = arrResultado(1)
                                                    'nombreInicio = "<tbody>"
                                                    'nombreFin = "</tbody>"
                                                    arrResultado = ExtraerContenidoEntreTag(contenidoHTML, Convert.ToInt32(arrResultado(0)), nombreInicio, nombreFin)
                                                    'direccion
                                                    If arrResultado IsNot Nothing Then
                                                        ' _actividadesconomicas = arrResultado(1).Replace(vbCrLf, "").Replace(vbTab, "").Trim()
                                                        _Direccion = Regex.Replace(arrResultado(1).Trim(), " {2,}", " ")
                                                        arrResultado = ExtraerContenidoEntreTag(contenidoHTML, Convert.ToInt32(arrResultado(0)), nombreInicio, nombreFin)

                                                        If arrResultado IsNot Nothing Then
                                                            _comprobantespago = arrResultado(1).Replace(vbCrLf, "").Replace(vbTab, "").Trim()
                                                            arrResultado = ExtraerContenidoEntreTag(contenidoHTML, Convert.ToInt32(arrResultado(0)), nombreInicio, nombreFin)

                                                            If arrResultado IsNot Nothing Then
                                                                _sistemaemisioncomprobante = arrResultado(1).Replace(vbCrLf, "").Replace(vbTab, "").Trim()
                                                                nombreInicio = "<p class=""list-group-item-text"">"
                                                                nombreFin = "</p>"
                                                                arrResultado = ExtraerContenidoEntreTag(contenidoHTML, Convert.ToInt32(arrResultado(0)), nombreInicio, nombreFin)

                                                                If arrResultado IsNot Nothing Then
                                                                    _afiliadopledesde = arrResultado(1)
                                                                    nombreInicio = "<tbody>"
                                                                    nombreFin = "</tbody>"
                                                                    arrResultado = ExtraerContenidoEntreTag(contenidoHTML, Convert.ToInt32(arrResultado(0)), nombreInicio, nombreFin)

                                                                    If arrResultado IsNot Nothing Then
                                                                        _padrones = arrResultado(1).Replace(vbCrLf, "").Replace(vbTab, "").Trim()
                                                                    End If
                                                                End If

                                                                _tiporespuesta = 1
                                                                _mensajerespuesta = "Ok"
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If

                                End If
                            End If
                        End If
                    End If
                End If
            End If

            Return True
        End Function
        Public Function ExtraerContenidoEntreTagString(ByVal cadena As String, ByVal posicion As Integer, ByVal nombreInicio As String, ByVal nombreFin As String, Optional ByVal reglaComparacion As StringComparison = StringComparison.Ordinal) As String
            Dim respuesta As String = ""
            Dim posicionInicio As Integer = cadena.IndexOf(nombreInicio, posicion, reglaComparacion)

            If posicionInicio > -1 Then
                posicionInicio += nombreInicio.Length

                If nombreFin Is Nothing OrElse nombreFin = "" Then
                    respuesta = cadena.Substring(posicionInicio, cadena.Length - posicionInicio)
                Else
                    Dim posicionFin As Integer = cadena.IndexOf(nombreFin, posicionInicio, reglaComparacion)
                    If posicionFin > -1 Then respuesta = cadena.Substring(posicionInicio, posicionFin - posicionInicio)
                End If
            End If

            Return respuesta
        End Function
        Public Function ExtraerContenidoEntreTag(ByVal cadena As String, ByVal posicion As Integer, ByVal nombreInicio As String, ByVal nombreFin As String, Optional ByVal reglaComparacion As StringComparison = StringComparison.Ordinal) As String()
            Dim arrRespuesta As String() = Nothing
            Dim posicionInicio As Integer = cadena.IndexOf(nombreInicio, posicion, reglaComparacion)

            If posicionInicio > -1 Then
                posicionInicio += nombreInicio.Length

                If nombreFin Is Nothing OrElse nombreFin = "" Then
                    arrRespuesta = New String(1) {}
                    arrRespuesta(0) = cadena.Length.ToString()
                    arrRespuesta(1) = cadena.Substring(posicionInicio, cadena.Length - posicionInicio)
                Else
                    Dim posicionFin As Integer = cadena.IndexOf(nombreFin, posicionInicio, reglaComparacion)

                    If posicionFin > -1 Then
                        posicion = posicionFin + nombreFin.Length
                        arrRespuesta = New String(1) {}
                        arrRespuesta(0) = posicion.ToString()
                        arrRespuesta(1) = cadena.Substring(posicionInicio, posicionFin - posicionInicio)
                    End If
                End If
            End If

            Return arrRespuesta
        End Function
        Function ValidarRUC(RUC As String) As String
            Dim Respuesta As String, Temporal As Integer
            On Error GoTo sale

            If Len(RUC) <> 11 Then
                Respuesta = "Incorrecto"
            End If

            Temporal = Val(Left(RUC, 2))
            If Temporal <> 10 And Temporal <> 20 And Temporal <> 15 And Temporal <> 16 And Temporal <> 17 Then
                Respuesta = "Incorrecto"
            End If

            Dim suma As Integer, resto As Integer, complemento As Byte
            suma = Val(Mid(RUC, 1, 1)) * 5 + Val(Mid(RUC, 2, 1)) * 4 + Val(Mid(RUC, 3, 1)) * 3 + Val(Mid(RUC, 4, 1)) * 2 + Val(Mid(RUC, 5, 1)) * 7 + Val(Mid(RUC, 6, 1)) * 6 + Val(Mid(RUC, 7, 1)) * 5 + Val(Mid(RUC, 8, 1)) * 4 + Val(Mid(RUC, 9, 1)) * 3 + Val(Mid(RUC, 10, 1)) * 2
            resto = suma Mod 11
            complemento = IIf(resto = 1, 0, Val(Left(11 - resto, 1)))

            If Val(Mid(RUC, 11, 1)) = complemento Then
                ValidarRUC = "Correcto"
                Exit Function
            End If
sale:
            Respuesta = "Incorrecto"
            ValidarRUC = Respuesta
        End Function
    End Class
End Namespace

