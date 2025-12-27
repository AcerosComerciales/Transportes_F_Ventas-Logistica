Imports System.Net
Imports System.Text.RegularExpressions

Namespace LibSunat
    Public Class Sunat

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

        Public ConsultaSunat(17) As String

        Const webLR As String = "https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias?accion=consPorRazonSoc&razSoc=Luis"
        Const webLR2 As String = "https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias?accion=consPorRuc&actReturn=1&modo=1&nroRuc="

#Region "Propiedades"
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
#End Region


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
            '''consulta rapida pero sin direccion

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
