Imports System.Drawing.Printing 'Esta libreria esta ligada directamente a la busqueda de Impresoras en una PC  
Imports System.Text

Imports ACFramework
Imports ACBTransporte
Imports ACETransporte
Imports ACBVentas
Imports ACEVentas
Imports ACImpresion
Imports C1.C1Preview

Imports CrystalDecisions

Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Imports CrystalDecisions.CrystalReports.Engine

Public Class Impresion
    'ejemplo hecho el 23/05/2023 de una  factura 
    '___________________________________________________
    '                    TRANSPORTES                    |
    '            ACEROS COMERCIALES S.C.R.L             |
    '                R.U.C Nº 20100241022               |
    '------------------------------------------------   |
    '                 Factura Electronica               |
    '                    F010-0009677                   |
    '------------------------------------------------   |
    '    RUC/DNI:10403235186                            |
    '    CLIENTE:VILCA NOA MARCELO                      |
    '    DIRECCION : JR.CUSCO Nº 209 - ABANCAY /        |
    '        ABANCAY /APURIMAC                          |
    '    FECHA : 20/05/2023                             |
    '                                                   |
    '    Cant. Und.  Descripcion  P.Unit Imp.Total      |
    '-------------------------------------------------  |
    '    41.070 T.M        100.00    4,107.00           |
    '                    POR EL SERVICIO DE TRANSPORTE  |
    '                    DE MINERAL SULFURO DE COBRE DE |
    '                    BAJA LEY A GRANEL.             |
    '                                                   | 
    '                    SEGUN GUIA DE ACEROS COMERCIALES
    '                    ES S.C.R.L  Nº 020-04890 .     | 
    '                    SEGUN GUIA DE VILCA NOA MARCEL |    
    '                    O Nº 002-00827 .               |  

    '                    RUTA : ABANCAY - NASCA.        | 
    '-------------------------------------------------- |
    '    Total Op.Gravada  S/      3,480.51             |
    '    Total IGV (18%)   S/        626.49             | 
    '    Total Importe     S/      4,107.00             |
    '                                                   |
    '   SON : CUATRO MIL CIENTO SIETE CON 00/100        |
    '    SOLES                                          |
    '   Tipo de Pago : Credito                          |
    '   Fecha Vcto : 19/06/2023                         |
    '   Porcentaje Detraccion: 3.00  %                  |
    '   Detraccion :  1000.000<--- AGREGADO             |
    '   Monto Pend : 3785.00                            |
    '   Hora : 09:34 a.m                                |
    '   Usuario : AARIASA                               |
    '                                                   |
    '   Observ . : VALOR REFERENCIAL : 8038.22          |
    '   Documento para control Administrativo ,         |
    '   Para visualizar su representacion impresa       |
    '                    visitar                        |
    '    http://facturas.aceroscomerciales.com.pe       |
    '    Autorizado mediante Resolucion                 |
    '    052-005-0000140/SUNAT                          |
    '                                                   |
    '    ALMACEN PRINCIPAL  : Carr .Variante de Uc      |
    '    humayo Km 4 - Yanahuara / Telefax : 44927      |
    '    3 / RPM #800290 / RPC 958346551                |
    '                                                   |
    '    Operacion Sujeta al Sistema de Pago de         |
    '    ObligacionesTributarias Con el Gobierno C      |
    '    Cta . Cte. Bco . de la Nacion 101-091929       |
    '                                                   |
    '    Designado Agente de Retencion RS 228-2012      |
    '                                                   |
    '                      QR                           |
    '___________________________________________________

#Region " Variables "
    Private m_file As StringBuilder
    Private m_printername As String
#End Region

#Region " Propiedades "

    Public Property File() As StringBuilder
        Get
            Return m_file
        End Get
        Set(ByVal value As StringBuilder)
            m_file = value
        End Set
    End Property

#End Region

#Region " Constructores "
    Public Sub New(ByVal x_printer As String)
        Try
            m_printername = x_printer
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", "Impresion"), "Ocurrio un error en el proceso Inicializar Impresora", ex)
        End Try
    End Sub
#End Region

#Region " Impresion Nota Credito Electronica"
    Public Function Print_NotaCre(ByVal x_docve_codigo As String, ByVal x_serie As String, Optional ByVal x_lineas As Integer = 25) As Boolean
        Try

            Dim m_docven As New EVENT_DocsVenta
            If Get_FacturaTransportista(m_docven, x_docve_codigo) Then


                Dim _reporte As New Reporte

                Return _reporte.RNotasCredito(x_docve_codigo, m_printername, False)

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
#Region " Metodos "

    Public Function Print_GuiaTransportista(ByVal x_gtran_codigo As String) As Boolean
        Try
            Dim m_guia As New ETRAN_GuiasTransportista
            Dim _reporte As New Reporte
            If Get_GuiaTransportista(m_guia, x_gtran_codigo) Then
                Dim x_serie As String = m_guia.GTRAN_Serie
                Select Case GApp.Empresa
                    Case "ACERO"
                        Select Case x_serie
                            Case "018"
                                Return ImprimirG018Aceros(m_guia, 25)
                            Case "023"
                                Return ImprimirG023Aceros(m_guia, 12, 6, 0)
                            Case "T023"
                                Return _reporte.REPOS_GuiaElectronica(x_gtran_codigo, m_printername, False)
                            Case "V016", "0016"
                                Return _reporte.REPOS_GuiaElectronicaTransportista(x_gtran_codigo, m_printername, False)
                            Case ""
                                Throw New Exception("Metodo de Impresión no Implementado")
                            Case Else
                                Throw New Exception("Metodo de Impresión no Implementado")
                        End Select
                    Case "JRANC"
                        Throw New Exception("Metodo de Impresión no Implementado")
                End Select
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Print_FacturaTransportista(ByVal x_docve_codigo As String, ByVal x_serie As String, ByVal x_spot As Boolean, Optional ByVal x_lineas As Integer = 25) As Boolean
        Try

            Dim m_docven As New EVENT_DocsVenta
            If Get_FacturaTransportista(m_docven, x_docve_codigo) Then


                Dim _reporte As New Reporte


                Select Case GApp.Empresa
                    Case "ACERO"
                        Return _reporte.RVentas(x_docve_codigo, m_printername, False, x_spot)
                    Case "JRANC"
                        Select Case x_serie
                            Case "001"
                                Return ImprimirF001JRAnc(m_docven, 14)
                            Case ""
                                Throw New Exception("Metodo de Impresión no Implementado")
                            Case Else
                                Throw New Exception("Metodo de Impresión no Implementado")
                        End Select
                End Select

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Print_FacturaTermica(ByVal x_docve_codigo As String, ByVal x_serie As String, ByVal x_spot As Boolean,
                                      ByVal imagen As PrintDocument, Optional ByVal x_lineas As Integer = 25) As Boolean
        Try

            Dim m_docven As New EVENT_DocsVenta
            If Get_FacturaTransportista(m_docven, x_docve_codigo) Then


                Select Case GApp.Empresa
                    Case "ACERO"

                        ' Return _reporte.REPOS_Fac(x_docve_codigo, m_printername, False)

                        Return ImprimirF010termica(m_docven, x_spot, x_lineas, imagen)


                    Case "JRANC"
                        Select Case x_serie
                            Case "001"
                                Return ImprimirF001JRAnc(m_docven, 14)
                            Case ""
                                Throw New Exception("Metodo de Impresión no Implementado")
                            Case Else
                                Throw New Exception("Metodo de Impresión no Implementado")
                        End Select
                End Select

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Print_FacturaTransportistaSimple(ByVal x_docve_codigo As String, ByVal x_serie As String, ByVal x_spot As Boolean, Optional ByVal x_lineas As Integer = 25) As Boolean
        Try

            Dim m_docven As New EVENT_DocsVenta
            If Get_FacturaTransportista(m_docven, x_docve_codigo) Then


                Dim _reporte As New Reporte


                Select Case GApp.Empresa
                    Case "ACERO"
                        Return _reporte.RVentasSimple(x_docve_codigo, m_printername, False, x_spot)
                    Case "JRANC"
                        Select Case x_serie
                            Case "001"
                                Return ImprimirF001JRAnc(m_docven, 14)
                            Case ""
                                Throw New Exception("Metodo de Impresión no Implementado")
                            Case Else
                                Throw New Exception("Metodo de Impresión no Implementado")
                        End Select
                End Select

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    Public Function Print_CotizacionTransportista(ByVal x_cotiz_codigo As String, ByVal x_imprimir As Boolean) As Boolean
        Try
            Dim m_docven As New ETRAN_Cotizaciones
            If Get_Cotizacion(m_docven, x_cotiz_codigo) Then
                Dim strReportName As String = "CRCotizacionAC.rpt"
                Dim m_Path_Plantillas As String = System.IO.Path.Combine(Application.StartupPath, "Plantillas")
                Dim strReportPath As String = System.IO.Path.Combine(m_Path_Plantillas, strReportName)
                If Not IO.File.Exists(strReportPath) Then
                    'Throw (New Exception("No Existe el reporte:" & vbCrLf & strReportPath))
                    ACControles.ACDialogos.ACMostrarMensajeError("Archivo No Encontrado", "El Reporte no existe, verifique que tiene el reporte en su sistema")
                    Return False
                End If

                If x_imprimir Then
                    Return Imprimir(m_docven, strReportPath)
                Else
                    Return Visualizar(m_docven, strReportPath)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function Print_Recibos(ByVal x_recib_codigo As String, ByVal printd As PrintDocument) As Boolean
        Try
            Dim m_recibo As New ETRAN_Recibos
            If Get_Recibo(m_recibo, x_recib_codigo) Then
                If Imprimir(m_recibo, False, printd) Then
                    Dim _recibo As New BTRAN_Recibos
                    _recibo.TRAN_Recibos = m_recibo
                    _recibo.TRAN_Recibos.RECIB_Impresa = True
                    _recibo.TRAN_Recibos.RECIB_Impresiones += 1
                    _recibo.TRAN_Recibos.Instanciar(ACEInstancia.Modificado)
                    Return _recibo.Guardar(GApp.Usuario)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Print_Recibos(ByVal m_recibo As ETRAN_Recibos, ByVal printd As PrintDocument) As Boolean
        Try
            If Imprimir(m_recibo, False, printd) Then
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region " Imprimir "

#Region " Facturas "
    Private Function Imprimir(ByVal dtDatos As DSFactura, ByVal strReportName As String) As Boolean
        Dim _cad As String = "{0} {1}"
        Try
            Dim strReportPath As String = System.IO.Path.Combine(GApp.Path_Plantillas, strReportName)
            If Not IO.File.Exists(strReportPath) Then
                Throw (New Exception("No Existe el reporte:" & vbCrLf & strReportPath))
            End If

            Dim Informe As New ReportDocument
            Informe.Load(strReportPath)

            Informe.SetDataSource(dtDatos)

            Informe.PrintOptions.PrinterName = m_printername
            Informe.PrintOptions.PaperSize = [Shared].PaperSize.PaperA3
            Informe.PrintOptions.PaperOrientation = [Shared].PaperOrientation.Portrait
            Informe.PrintToPrinter(1, True, 1, 1)
            Informe.Close()

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function ImprimirF010Aceros(ByVal m_docventa As EVENT_DocsVenta, ByVal x_filas As Integer) As Boolean
        Dim m_texto As String = ""
        Dim m_space As Integer = 0
        Dim m_cabecera As New StringBuilder
        Dim m_cuerpo As New StringBuilder
        Dim m_pie As New StringBuilder
        Try
            '' Generar Cabecera
            m_cabecera.Append(String.Format("{0}AV. DOLORES Nro. 145 - A  JOSÉ LUIS BUSTAMANTE Y RIVERO - AREQUIPA - AREQUIPA{1}", Space(m_space + 10), vbNewLine))
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 5)
            m_cabecera.Append(String.Format("{0}{1}", Space(m_space + 110), m_docventa.Documento))
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 2)
            Dim _cab As New List(Of String)
            _cab.Add(String.Format("{0}{1}{2}{3}", Space(m_space + 37) _
                                             , m_docventa.DOCVE_FechaDocumento.Day.ToString("00").PadRight(10, " ") _
                                             , MonthName(m_docventa.DOCVE_FechaDocumento.Month).ToUpper().PadRight(28, " ").Substring(0, 28), m_docventa.DOCVE_FechaDocumento.Year.ToString("0000")))
            _cab.Add(String.Format("{0}{1}", Space(m_space + 12), m_docventa.DOCVE_DescripcionCliente))
            _cab.Add(String.Format("{0}{1}", Space(m_space + 12), m_docventa.DOCVE_DireccionCliente))
            _cab.Add(String.Format("{0}{1}{2}", Space(m_space + 10), m_docventa.ENTID_NroDocumento.PadRight(100, " "), m_docventa.DOCVE_FechaDocumento.ToString("dd/MM/yyyy")))
            _cab.Add(New String(""))

            ACUtilitarios.genTexto(_cab, m_cabecera)
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 1)
            '' Generar Detalle
            Dim x_fila As Integer = 0
            For Each item As EVENT_DocsVentaDetalle In m_docventa.ListVENT_DocsVentaDetalle
                Dim x_lista As New List(Of String)
                If IsNothing(item.DOCVD_Detalle) Then item.DOCVD_Detalle = ""
                Dim _precio As Decimal
                Dim _importe As Decimal
                If m_docventa.DOCVE_PrecIncIVG Then
                    _precio = item.DOCVD_PrecioUnitarioPrecIncIGV
                    _importe = _precio * item.DOCVD_Cantidad
                Else
                    _precio = item.DOCVD_PrecioUnitario
                    _importe = item.DOCVD_SubImporteVenta
                End If

                If ACUtilitarios.GetTextoLines(item.DOCVD_Detalle, 90, x_lista) > 0 Then
                    m_cuerpo.Append(String.Format("{0}{1}{2}{3}{4}{5}{6}", Space(m_space) _
                                                  , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_Cantidad.ToString("###,##0.000"), 11) _
                                                  , ACUtilitarios.Alinear(ACAlineacion.Centro, item.DOCVD_Unidad, 17) _
                                                  , x_lista(0).PadRight(75, " ").Substring(0, 75) _
                                                , ACUtilitarios.Alinear(ACAlineacion.Derecha, _precio.ToString("###,##0.00"), 17) _
                                                  , ACUtilitarios.Alinear(ACAlineacion.Derecha, _importe.ToString("###,##0.00"), 17) _
                                                  , vbNewLine))
                    If x_lista.Count > 1 Then
                        Dim j As Integer
                        For j = 1 To x_lista.Count - 1
                            m_cuerpo.Append(String.Format("{0}{1}{2}", Space(m_space + 28), x_lista(j).Trim(), vbNewLine))
                        Next
                    End If
                    x_fila += x_lista.Count
                Else
                    x_fila += 1
                    m_cuerpo.Append(String.Format("{0}{1}{2}{3}{4}{5}", Space(m_space) _
                                                  , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_Cantidad.ToString("###,##0.0000"), 11) _
                                                  , ACUtilitarios.Alinear(ACAlineacion.Centro, item.DOCVD_Unidad, 16) _
                                                  , "" _
                                                  , ACUtilitarios.Alinear(ACAlineacion.Derecha, _precio.ToString("###,##0.0000"), 18) _
                                                  , ACUtilitarios.Alinear(ACAlineacion.Derecha, _importe.ToString("###,##0.0000"), 18) _
                                                  ))
                End If

            Next
            ACUtilitarios.ImprimeLinBlanco(m_cuerpo, x_filas - x_fila - 1)

            '' Generar Pie de Pagina

            Dim _pie As New List(Of String)
            _pie.Add(New String(String.Format("{0}Operacion Sujeta al Sistema de Pago de ObligacionesTributarias Con el Gobierno Central.", Space(m_space + 26))))
            If (IsNothing(m_docventa.DOCVE_NotaPie)) Then
                _pie.Add(New String(" "))
            Else
                _pie.Add(New String(String.Format("{0}{1}", Space(m_space + 28), m_docventa.DOCVE_NotaPie.Trim())))
            End If

            _pie.Add(New String(" "))
            Dim _filter As New ACFiltrador(Of ETipos)
            _filter.ACFiltro = String.Format("TIPOS_Codigo={0}", m_docventa.TIPOS_CodTipoMoneda)
            _filter.ACFiltrar(Colecciones.Tipos)
            Dim _simb = "S/"
            'If _filter.ACListaFiltrada.Count > 0 Then
            '   _simb = _filter.ACListaFiltrada(0).TIPOS_DescCorta
            '       _pie.Add(String.Format("{0}{1}", Space(m_space + 5), ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalPagar, " SOLES")))
            'Else
            '       _pie.Add(String.Format("{0}{1}", Space(m_space + 5), ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalPagar, " SOLES")))
            'End If
            If _filter.ACListaFiltrada.Count > 0 Then
                _simb = _filter.ACListaFiltrada(0).TIPOS_DescCorta

                If _simb = "S/" Then
                    _pie.Add(String.Format("{0}{1}", Space(m_space + 5), ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalPagar, " SOLES")))
                Else
                    _pie.Add(String.Format("{0}{1}", Space(m_space + 5), ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalPagar, " DÓLARES AMERICANOS")))
                End If
            End If



            _pie.Add(New String("")) '62
            _pie.Add(String.Format("{0} {1} {2} {3} {4}", Space(m_space + 62) _
                                , ACFramework.ACUtilitarios.Alinear(ACUtilitarios.ACAlineacion.Centro, m_docventa.ENTID_CodUsuario, 20).ToString().PadRight(20, " ").Substring(0, 20) _
                                , (_simb & " " & m_docventa.DOCVE_ImporteVenta.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))).ToString().PadLeft(16, " ").Substring(0, 16) _
                                , (_simb & " " & m_docventa.DOCVE_ImporteIgv.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))).ToString().PadLeft(17, " ").Substring(0, 17) _
                                , (_simb & " " & m_docventa.DOCVE_TotalPagar.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))).ToString().PadLeft(16, " ").Substring(0, 16)))

            '_pie.Add(String.Format("{0}{1}",Space(), GApp.EUsuario.USER_CodUsr))

            ACUtilitarios.genTexto(_pie, m_pie)

            '' Generar Documento Final
            m_cabecera.Append(m_cuerpo)
            m_cabecera.Append(m_pie)

            '' Imprimir
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 3)

            ACImpresion.ACImprimir.Inicializar(m_printername)
            ACImpresion.ACImprimir.SendStringToPrinter(Chr(18))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.NumeroLineas(68))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Fuente(ACFuentes.Draft))
            ACImpresion.ACImprimir.SendStringToPrinter(String.Format("{0}{1}", Chr(27), Chr(15)))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.FuenteDraft(ACDrafts.Draft10PCI))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Condensado(False))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Interespaciado(ACInterEspaciado.Seis))
            ACImprimir.SendStringToPrinter(m_cabecera.ToString())

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function ImprimirF017Aceros(ByVal m_docventa As EVENT_DocsVenta, ByVal x_filas As Integer) As Boolean
        Dim m_texto As String = ""
        Dim m_space As Integer = 0
        Dim m_cabecera As New StringBuilder
        Dim m_cuerpo As New StringBuilder
        Dim m_pie As New StringBuilder
        Try
            '' Generar Cabecera
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 6)
            m_cabecera.Append(String.Format("{0}{1}", Space(m_space + 110), m_docventa.Documento))
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 2)
            Dim _cab As New List(Of String)
            _cab.Add(String.Format("{0}{1}{2}{3}", Space(m_space + 37) _
                                             , m_docventa.DOCVE_FechaDocumento.Day.ToString("00").PadRight(10, " ") _
                                             , MonthName(m_docventa.DOCVE_FechaDocumento.Month).ToUpper().PadRight(28, " ").Substring(0, 28), m_docventa.DOCVE_FechaDocumento.Year.ToString("0000")))
            _cab.Add(String.Format("{0}{1}", Space(m_space + 12), m_docventa.DOCVE_DescripcionCliente))
            _cab.Add(String.Format("{0}{1}", Space(m_space + 12), m_docventa.DOCVE_DireccionCliente))
            _cab.Add(String.Format("{0}{1}{2}", Space(m_space + 10), m_docventa.ENTID_NroDocumento.PadRight(100, " "), m_docventa.DOCVE_FechaDocumento.ToString("dd/MM/yyyy")))
            _cab.Add(New String(""))

            ACUtilitarios.genTexto(_cab, m_cabecera)
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 1)
            '' Generar Detalle
            Dim x_fila As Integer = 0
            Dim x_peso As Decimal = 0
            For Each item As EVENT_DocsVentaDetalle In m_docventa.ListVENT_DocsVentaDetalle
                x_peso += item.DOCVD_Cantidad
                Dim x_lista As New List(Of String)
                If IsNothing(item.DOCVD_Detalle) Then item.DOCVD_Detalle = ""
                If ACUtilitarios.GetTextoLines(item.DOCVD_Detalle, 75, x_lista) > 0 Then
                    m_cuerpo.Append(String.Format("{0}{1}{2}{3}{4}{5}{6}", Space(m_space) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_Cantidad.ToString("###,##0.000"), 11) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Centro, item.DOCVD_Unidad, 17) _
                                                        , x_lista(0).PadRight(75, " ").Substring(0, 75) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_PrecioUnitario.ToString("###,##0.00"), 17) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_SubImporteVenta.ToString("###,##0.00"), 17) _
                                                        , vbNewLine))
                    If x_lista.Count > 1 Then
                        Dim j As Integer
                        For j = 1 To x_lista.Count - 1
                            m_cuerpo.Append(String.Format("{0}{1}{2}", Space(m_space + 28), x_lista(j).Trim(), vbNewLine))
                        Next
                    End If
                    x_fila += x_lista.Count
                Else
                    x_fila += 1
                    m_cuerpo.Append(String.Format("{0}{1}{2}{3}{4}{5}", Space(m_space) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_Cantidad.ToString("###,##0.0000"), 11) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Centro, item.DOCVD_Unidad, 16) _
                                                        , "" _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_PrecioUnitario.ToString("###,##0.0000"), 18) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_SubImporteVenta.ToString("###,##0.0000"), 18) _
                                                        ))
                End If

            Next
            ACUtilitarios.ImprimeLinBlanco(m_cuerpo, x_filas - x_fila)

            '' Generar Pie de Pagina
            Dim _pie As New List(Of String)
            If (IsNothing(m_docventa.DOCVE_NotaPie)) Then
                _pie.Add(New String(" "))
            Else
                _pie.Add(New String(String.Format("{0}{1}", Space(m_space + 28), m_docventa.DOCVE_NotaPie.Trim())))
            End If
            _pie.Add(New String(" "))
            Dim _filter As New ACFiltrador(Of ETipos)
            _filter.ACFiltro = String.Format("TIPOS_Codigo={0}", m_docventa.TIPOS_CodTipoMoneda)
            _filter.ACFiltrar(Colecciones.Tipos)
            Dim _simb = "S/."
            If _filter.ACListaFiltrada.Count > 0 Then
                _simb = _filter.ACListaFiltrada(0).TIPOS_DescCorta
                _pie.Add(String.Format("{0}{1}", Space(m_space + 5), ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalPagar, " SOLES")))
            Else
                _pie.Add(String.Format("{0}{1}", Space(m_space + 5), ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalPagar, " SOLES")))
            End If

            _pie.Add(New String(""))
            _pie.Add(String.Format("{0} {1} {2} {3} {4}", Space(m_space) _
                                       , (_simb & " " & m_docventa.DOCVE_ImporteVenta.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))).ToString().PadLeft(16, " ").Substring(0, 16) _
                                       , (_simb & " " & m_docventa.DOCVE_ImporteIgv.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))).ToString().PadLeft(22, " ").Substring(0, 22) _
                                       , (_simb & " " & m_docventa.DOCVE_TotalPagar.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))).ToString().PadLeft(22, " ").Substring(0, 22) _
                                       , (_simb & " " & m_docventa.DOCVE_TotalPagar.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))).ToString().PadLeft(70, " ").Substring(0, 70)))
            _pie.Add(New String(""))
            _pie.Add(New String(""))
            _pie.Add(String.Format("{0} {1} {2} {3} {4}", Space(m_space + 3) _
                                       , (" " & x_peso.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) & " T.M.").ToString().PadLeft(16, " ").Substring(0, 16) _
                                       , (" " & DateTime.Now.ToString("hh:mm tt")).PadLeft(27, " ").Substring(0, 27) _
                                       , (" " & m_docventa.ENTID_Vendedor.PadRight(22, " ").Substring(0, 22)).ToString().PadLeft(22, " ").Substring(0, 22) _
                                       , (" " & GApp.EUsuario.USER_CodUsr).ToString().PadLeft(24, " ").Substring(0, 24)))

            ACUtilitarios.genTexto(_pie, m_pie)

            '' Generar Documento Final
            m_cabecera.Append(m_cuerpo)
            m_cabecera.Append(m_pie)

            '' Imprimir
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 3)

            ACImpresion.ACImprimir.Inicializar(m_printername)
            ACImpresion.ACImprimir.SendStringToPrinter(Chr(18))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.NumeroLineas(68))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Fuente(ACFuentes.Draft))
            ACImpresion.ACImprimir.SendStringToPrinter(String.Format("{0}{1}", Chr(27), Chr(15)))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.FuenteDraft(ACDrafts.Draft10PCI))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Condensado(False))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Interespaciado(ACInterEspaciado.Seis))
            ACImprimir.SendStringToPrinter(m_cabecera.ToString())

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function ImprimirF010termica(ByVal m_docventa As EVENT_DocsVenta, ByVal x_spot As Boolean, ByVal x_filas As Integer, ByVal imagenPD As PrintDocument) As Boolean

        Dim m_texto As String = ""
        Dim m_space As Integer = 0
        Dim m_cabecera As New StringBuilder
        Dim m_cabecera1 As New StringBuilder
        Dim m_cabecera_1 As New StringBuilder
        Dim m_observaciones As New StringBuilder
        Dim m_cuerpo As New StringBuilder
        Dim m_cuerpo1 As New StringBuilder
        Dim m_cuerpoespacio As New StringBuilder
        Dim m_pieespacios As New StringBuilder
        Dim m_cuerpoprecios As New StringBuilder
        Dim m_pie As New StringBuilder
        Dim m_pie1 As New StringBuilder
        Try
            Dim _pie1 As New List(Of String)
            Dim _cab As New List(Of String)

            'Dim tamaño As Integer = 41
            'Dim resultado As Integer
            Dim _cab1 As New List(Of String)
            'resultado = tamaño - GApp.EPuntoVenta.PVENT_Descripcion.Length
            'resultado = resultado / 2
            '_cab1.Add(String.Format("{0}{1}", Space(m_space + resultado), ACUtilitarios.Alinear(ACAlineacion.Centro, GApp.EPuntoVenta.PVENT_Descripcion, 28).PadRight(28, " ").Substring(0, 28)))
            '_cab1.Add(String.Format("{0}{1}", Space(m_space + centrar(GApp.EPuntoVenta.PVENT_Descripcion)), ACUtilitarios.Alinear(ACAlineacion.Centro, GApp.EPuntoVenta.PVENT_Descripcion, 28).PadRight(28, " ").Substring(0, 28)))
            _cab1.Add(String.Format("{0}{1}", Space(m_space + 1), ACUtilitarios.Alinear(ACAlineacion.Centro, GApp.EPuntoVenta.PVENT_Descripcion.ToUpper(), 35).PadRight(35, " ").Substring(0, 35)))
            _cab1.Add(New String(""))
            _cab1.Add(New String(""))
            _cab1.Add(New String(""))

            m_docventa.TIPOS_CodTipoDocumento = m_docventa.TIPOS_CodTipoDocumento + " Electrónica"

            _cab.Add(String.Format("{0}{1}", Space(m_space + 9), GApp.EEmpresa.EMPR_Desc))
            _cab.Add(String.Format("{0}{1}{2}", Space(m_space + 11), "R.U.C Nº ", GApp.EmpresaRUC))
            _cab.Add(String.Format("{0}", "-----------------------------------------"))

            _cab1.Add(String.Format("{0}{1}", Space(m_space + 7), ACUtilitarios.Alinear(ACAlineacion.Centro, m_docventa.TIPOS_CodTipoDocumento, 27).PadRight(27, " ").Substring(0, 27)))
            _cab1.Add(String.Format("{0}{1}", Space(m_space + 12), m_docventa.Documento))
            _cab.Add(New String(""))
            _cab.Add(New String(""))
            _cab.Add(String.Format("{0}", "-----------------------------------------"))

            ACUtilitarios.genTexto(_cab1, m_cabecera1)

            _cab.Add(String.Format("{0}{1}{2}{3}", Space(m_space), "RUC/DNI: ", Space(m_space + 3), m_docventa.ENTID_CodigoCliente))


            If (m_docventa.ENTID_RazonSocial.Length > 29 And m_docventa.ENTID_RazonSocial.Length < 71) Then
                _cab.Add(String.Format("{0}{1}{2}{3}", Space(m_space), "CLIENTE: ", Space(m_space + 3), m_docventa.ENTID_RazonSocial.Substring(0, 29)))
                _cab.Add(String.Format("{0}{1}", Space(m_space), m_docventa.ENTID_RazonSocial.Substring(29, m_docventa.ENTID_RazonSocial.Length - 29)))
            ElseIf m_docventa.ENTID_RazonSocial.Length > 70 Then
                _cab.Add(String.Format("{0}{1}{2}{3}", Space(m_space), "CLIENTE: ", Space(m_space + 3), m_docventa.ENTID_RazonSocial.Substring(0, 29)))
                _cab.Add(String.Format("{0}{1}", Space(m_space), m_docventa.ENTID_RazonSocial.Substring(29, m_docventa.ENTID_RazonSocial.Length - 40)))
                _cab.Add(String.Format("{0}{1}", Space(m_space), m_docventa.ENTID_RazonSocial.Substring(70, m_docventa.ENTID_RazonSocial.Length - 70)))
            ElseIf m_docventa.ENTID_RazonSocial.Length = 0 Then
                _cab.Add(String.Format("{0}{1}", Space(m_space), "CLIENTE: "))
            Else
                _cab.Add(String.Format("{0}{1}{2}{3}", Space(m_space), "CLIENTE: ", Space(m_space + 3), m_docventa.ENTID_RazonSocial.Substring(0, m_docventa.ENTID_RazonSocial.Length)))
            End If

            If (m_docventa.DOCVE_DireccionCliente.Length > 29 And m_docventa.DOCVE_DireccionCliente.Length < 71) Then
                _cab.Add(String.Format("{0}{1}{2}{3}", Space(m_space), "DIRECCIÓN: ", Space(m_space + 1), m_docventa.DOCVE_DireccionCliente.Substring(0, 29)))
                _cab.Add(String.Format("{0}{1}", Space(m_space), m_docventa.DOCVE_DireccionCliente.Substring(29, m_docventa.DOCVE_DireccionCliente.Length - 29)))
            ElseIf m_docventa.DOCVE_DireccionCliente.Length > 70 Then
                _cab.Add(String.Format("{0}{1}{2}{3}", Space(m_space), "DIRECCIÓN: ", Space(m_space + 1), m_docventa.DOCVE_DireccionCliente.Substring(0, 29)))
                _cab.Add(String.Format("{0}{1}", Space(m_space), m_docventa.DOCVE_DireccionCliente.Substring(29, 41))) '40
                _cab.Add(String.Format("{0}{1}", Space(m_space), m_docventa.DOCVE_DireccionCliente.Substring(70, m_docventa.DOCVE_DireccionCliente.Length - 70))) '52-58  '70-81=11caracteres
            ElseIf m_docventa.DOCVE_DireccionCliente.Length = 0 Then
                _cab.Add(String.Format("{0}{1}", Space(m_space), "DIRECCIÓN: "))
            Else
                _cab.Add(String.Format("{0}{1}{2}{3}", Space(m_space), "DIRECCIÓN: ", Space(m_space + 1), m_docventa.DOCVE_DireccionCliente.Substring(0, m_docventa.DOCVE_DireccionCliente.Length - 1)))
            End If



            _cab.Add(String.Format("{0}{1}{2}{3}", Space(m_space), "FECHA:", Space(m_space + 6), m_docventa.DOCVE_FechaDocumento.ToString("dd/MM/yyyy")))


            _cab.Add(New String(""))
            _cab.Add(New String(""))
            ACUtilitarios.genTexto(_cab, m_cabecera)

            Dim x_fila As Integer = 0
            Dim x_peso As Decimal = 0
            Dim x_tamdetalle As Integer
            Dim _cuerpo As New List(Of String)
            Dim _cuerpo1 As New List(Of String)
            Dim _cuerpoespacio As New List(Of String)

            '_cuerpo.Add(String.Format("{0}{1}{2}{3}{4}{5}{6}", "Descripción", Space(m_space + 3), "Cant.", Space(m_space + 3), "P.Unit", Space(m_space + 3), "Imp. Total"))

            _cuerpo.Add(String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}", "Cant.", Space(m_space + 1), "Und.", Space(m_space + 2), "Descripción", Space(m_space + 1), "P.Unit", Space(m_space + 1), "Imp. Total"))
            _cuerpoespacio.Add(New String(""))
            _cuerpo.Add(String.Format("{0}", "-----------------------------------------"))

            x_peso = m_docventa.DOCVE_TotalPeso
            For Each item As EVENT_DocsVentaDetalle In m_docventa.ListVENT_DocsVentaDetalle
                'x_peso += item.DOCVD_Cantidad * item.DOCVD_PesoUnitario
                _cuerpo.Add(New String(""))
                Dim x_lista As New List(Of String)
                If IsNothing(item.DOCVD_Detalle) Then item.DOCVD_Detalle = ""
                If ACUtilitarios.GetTextoLines(item.DOCVD_Detalle, 100, x_lista) > 0 Then 'HACE DOS ESPACHOS 


                    'If (x_lista(0).Length > 60 And x_lista.Count = 1) Then
                    '    _cuerpo1.Add(String.Format("{0}{1}", ACUtilitarios.Alinear(ACAlineacion.Centro, item.DOCVD_Cantidad.ToString(), 8).PadRight(8, " ").Substring(0, 8) _
                    '                                          , ACUtilitarios.Alinear(ACAlineacion.Izquierda, item.TIPOS_CodUnidadMedida.ToString(), 3).PadRight(3, " ").Substring(0, 3)))
                    '    _cuerpo1.Add(New String(""))
                    '    _cuerpo1.Add(New String(""))

                    '    _cuerpo.Add(String.Format("{0}{1}", Space(m_space + 11), x_lista(0).Substring(0, 30)))
                    '    _cuerpo.Add(String.Format("{0}{1}", Space(m_space + 11), x_lista(0).Substring(30, 30)))
                    '    _cuerpo.Add(String.Format("{0}{1}", Space(m_space + 11), x_lista(0).Substring(60, x_lista(0).Length - 60).PadRight(30, " ").Substring(0, 30)))
                    '    _cuerpo.Add(New String(""))
                    '    _cuerpo1.Add(String.Format("{0}{1}{2}{3}", Space(m_space + 17) _
                    '                                    , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_PrecioUnitario.ToString("###,##0.00"), 10).PadRight(10, " ").Substring(0, 10) _
                    '                                    , Space(m_space + 4) _
                    '                                    , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_SubImporteVenta.ToString("###,##0.00"), 10).PadRight(10, " ").Substring(0, 10)))

                    'ElseIf (x_lista(0).Length > 30 And x_lista.Count = 1) Then

                    '    _cuerpo1.Add(String.Format("{0}{1}", ACUtilitarios.Alinear(ACAlineacion.Centro, item.DOCVD_Cantidad.ToString(""), 8).PadRight(8, " ").Substring(0, 8) _
                    '                                          , ACUtilitarios.Alinear(ACAlineacion.Izquierda, item.DOCVD_Unidad.ToString(), 3).PadRight(3, " ").Substring(0, 3)))
                    '    _cuerpo1.Add(New String(""))
                    '    '_cuerpo1.Add(New String(""))


                    '    _cuerpo.Add(String.Format("{0}{1}", Space(m_space + 11), x_lista(0).Substring(0, 30)))
                    '    _cuerpo.Add(String.Format("{0}{1}", Space(m_space + 11), x_lista(0).Substring(30, x_lista(0).Length - 30).PadRight(30, " ").Substring(0, 30)))
                    '    _cuerpo.Add(New String(""))
                    '    _cuerpo1.Add(String.Format("{0}{1}{2}{3}", Space(m_space + 17) _
                    '                                    , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_PrecioUnitario.ToString("###,##0.00"), 10).PadRight(10, " ").Substring(0, 10) _
                    '                                    , Space(m_space + 4) _
                    '                                    , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_SubImporteVenta.ToString("###,##0.00"), 10).PadRight(10, " ").Substring(0, 10)))

                    'Else
                    '    _cuerpo1.Add(String.Format("{0}{1}", ACUtilitarios.Alinear(ACAlineacion.Centro, item.DOCVD_Cantidad.ToString(""), 8).PadRight(8, " ").Substring(0, 8) _
                    '                                         , ACUtilitarios.Alinear(ACAlineacion.Izquierda, item.TIPOS_CodUnidadMedida.ToString(), 3).PadRight(3, " ").Substring(0, 3)))
                    '    '_cuerpo1.Add(New String(""))


                    '    _cuerpo.Add(String.Format("{0}{1}", Space(m_space + 11), x_lista(0).Substring(0, x_lista(0).Length).PadRight(30, " ").Substring(0, 30)))
                    '    _cuerpo.Add(New String(""))
                    '    _cuerpo1.Add(String.Format("{0}{1}{2}{3}", Space(m_space + 17) _
                    '                                    , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_PrecioUnitario.ToString("###,##0.00"), 10).PadRight(10, " ").Substring(0, 10) _
                    '                                    , Space(m_space + 4) _
                    '                                    , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_SubImporteVenta.ToString("###,##0.00"), 10).PadRight(10, " ").Substring(0, 10)))



                    'End If
                    'COMENTADO DE 4 A  02-04-2024    FRANK 
                    If x_lista.Count >= 1 Then
                        Dim j As Integer
                        '_cuerpo1.Add(String.Format("{0}{1}", ACUtilitarios.Alinear(ACAlineacion.Centro, item.DOCVD_Cantidad.ToString(), 8).PadRight(8, " ").Substring(0, 8) _
                        '                                      , ACUtilitarios.Alinear(ACAlineacion.Izquierda, item.TIPOS_CodUnidadMedida.ToString(), 3).PadRight(3, " ").Substring(0, 3)))
                        _cuerpo1.Add(String.Format("{0}{1}{2}{3}{4}{5}", ACUtilitarios.Alinear(ACAlineacion.Centro, item.DOCVD_Cantidad.ToString("#,##0.000"), 9).PadRight(9, " ").Substring(0, 9) _
                                                               , ACUtilitarios.Alinear(ACAlineacion.Izquierda, item.TIPOS_CodUnidadMedida.ToString(), 5).PadRight(5, " ").Substring(0, 5) _
                                                               , Space(m_space + 3) _
                                                               , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_PrecioUnitario.ToString("###,##0.00"), 10).PadRight(10, " ").Substring(0, 10) _
                                                               , Space(m_space + 4) _
                                                               , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_SubImporteVenta.ToString("###,##0.00"), 10).PadRight(10, " ").Substring(0, 10)))
                        '_cuerpo1.Add(String.Format("{0}{1}{2}{3}", Space(m_space + 17) _
                        '                               , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_PrecioUnitario.ToString("###,##0.00"), 10).PadRight(10, " ").Substring(0, 10) _
                        '                               , Space(m_space + 4) _
                        '                               , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_SubImporteVenta.ToString("###,##0.00"), 10).PadRight(10, " ").Substring(0, 10)))
                        _cuerpo1.Add(New String("")) ' comentado frank 

                        For j = 0 To x_lista.Count - 1
                            Dim l As Integer = x_lista(j).Length()
                            If (x_lista(j).Length > 90) Then

                                _cuerpo.Add(String.Format("{0}{1}", Space(m_space + 11), x_lista(j).Substring(0, 30)))
                                _cuerpo.Add(String.Format("{0}{1}", Space(m_space + 11), x_lista(j).Substring(30, 30)))
                                _cuerpo.Add(String.Format("{0}{1}", Space(m_space + 11), x_lista(j).Substring(60, 30)))
                                '_cuerpo.Add(String.Format("{0}{1}", Space(m_space + 11), x_lista(j).Substring(60, 60)))
                                _cuerpo.Add(String.Format("{0}{1}", Space(m_space + 11), x_lista(j).Substring(90, x_lista(j).Length - 90).PadRight(30, " ").Substring(0, 30)))
                                'm_cuerpo.Append(String.Format("{0}{1}{2}", Space(m_space + 28), x_lista(j).Trim(), vbNewLine))
                            ElseIf (x_lista(j).Length > 60) Then

                                _cuerpo.Add(String.Format("{0}{1}", Space(m_space + 11), x_lista(j).Substring(0, 30)))
                                _cuerpo.Add(String.Format("{0}{1}", Space(m_space + 11), x_lista(j).Substring(30, 30)))
                                _cuerpo.Add(String.Format("{0}{1}", Space(m_space + 11), x_lista(j).Substring(60, x_lista(j).Length - 60).PadRight(30, " ").Substring(0, 30)))
                                'm_cuerpo.Append(String.Format("{0}{1}{2}", Space(m_space + 28), x_lista(j).Trim(), vbNewLine))
                            ElseIf (x_lista(j).Length > 30) Then
                                If x_lista(j).Substring(0, 1) = Chr(10) Then
                                    _cuerpo.Add(String.Format("{0}{1}", Space(m_space + 11), x_lista(j).Substring(1, 31)))
                                    _cuerpo.Add(String.Format("{0}{1}", Space(m_space + 11), x_lista(j).Substring(31, x_lista(j).Length - 31).PadRight(31, " ").Substring(0, 31)))
                                Else
                                    _cuerpo.Add(String.Format("{0}{1}", Space(m_space + 11), x_lista(j).Substring(0, 30)))
                                    _cuerpo.Add(String.Format("{0}{1}", Space(m_space + 11), x_lista(j).Substring(30, x_lista(j).Length - 30).PadRight(30, " ").Substring(0, 30)))

                                End If
                            Else
                                _cuerpo.Add(String.Format("{0}{1}", Space(m_space + 11), x_lista(j).Substring(0, x_lista(j).Length).PadRight(30, " ").Substring(0, 30)))
                            End If
                        Next

                        Dim m As Integer
                        Dim text As Integer = _cuerpo1.Count

                        For m = 2 To (_cuerpo.Count - text) - 1 'x_lista.Count - 1
                            _cuerpo1.Add(New String(""))

                        Next

                        ' _cuerpo1.Add(New String(""))

                        _cuerpo.Add(New String("")) 'Comentado 2-4-2024
                    End If
                    x_fila += x_lista.Count
                    x_tamdetalle += 1

                Else
                    x_fila += 1

                    _cuerpo.Add(String.Format("{0}{1}{2}{3}{4}{5}", Space(m_space + 7), ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_Cantidad.ToString("###,##0.00"), 10).PadRight(9, " ").Substring(0, 9) _
                                                        , Space(m_space + 1) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_PrecioUnitario.ToString("###,##0.00"), 10).PadRight(10, " ").Substring(0, 10) _
                                                        , Space(m_space + 4) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_SubImporteVenta.ToString("###,##0.00"), 10).PadRight(10, " ").Substring(0, 10)))

                End If

            Next


            '_cuerpo.Add(New String(""))
            _cuerpo.Add(String.Format("{0}", "-----------------------------------------"))

            ACUtilitarios.genTexto(_cuerpo, m_cuerpo)
            ACUtilitarios.genTexto(_cuerpo1, m_cuerpo1)
            ACUtilitarios.genTexto(_cuerpoespacio, m_cuerpoespacio)
            Dim _pieespacio As New List(Of String)


            Dim _simb = m_docventa.TIPOS_CodTipoMoneda
            ' MessageBox.Show(m_docventa.TIPOS_CodTipoMoneda) 'aqui sale este signo de moneda 

            Dim Soles As String = "S/." 'Se creo Variable para SOles Factura 

            Dim _pie As New List(Of String)
            If (_simb = "US$") Then
                _pie.Add(String.Format("{0}{1}{2}{3}{4}{5}", Space(m_space + 7), "Total Op.Gravada", Space(m_space + 2), _simb, Space(m_space + 1), ACUtilitarios.Alinear(ACAlineacion.Derecha, m_docventa.DOCVE_ImporteVenta.ToString("##,###,##0.00"), 12).PadRight(12, " ").Substring(0, 12)))
                _pie.Add(String.Format("{0}{1}{2}{3}{4}{5}", Space(m_space + 7), "Total IGV (18%)", Space(m_space + 3), _simb, Space(m_space + 1), ACUtilitarios.Alinear(ACAlineacion.Derecha, m_docventa.DOCVE_ImporteIgv.ToString("##,###,##0.00"), 12).PadRight(12, " ").Substring(0, 12)))
                _pie.Add(String.Format("{0}{1}{2}{3}{4}{5}", Space(m_space + 7), "Total Importe", Space(m_space + 5), _simb, Space(m_space + 1), ACUtilitarios.Alinear(ACAlineacion.Derecha, m_docventa.DOCVE_TotalVenta.ToString("##,###,##0.00"), 12).PadRight(12, " ").Substring(0, 12)))
                _pieespacio.Add(New String(""))
                '_pieespacio.Add(New String(""))
                ' _pieespacio.Add(New String("")) 'comentado frank 
            Else
                _pie.Add(String.Format("{0}{1}{2}{3}{4}{5}", Space(m_space + 8), "Total Op.Gravada", Space(m_space + 2), _simb, Space(m_space + 1), ACUtilitarios.Alinear(ACAlineacion.Derecha, m_docventa.DOCVE_ImporteVenta.ToString("##,###,##0.00"), 12).PadRight(12, " ").Substring(0, 12)))
                _pie.Add(String.Format("{0}{1}{2}{3}{4}{5}", Space(m_space + 8), "Total IGV (18%)", Space(m_space + 3), _simb, Space(m_space + 1), ACUtilitarios.Alinear(ACAlineacion.Derecha, m_docventa.DOCVE_ImporteIgv.ToString("##,###,##0.00"), 12).PadRight(12, " ").Substring(0, 12)))
                _pie.Add(String.Format("{0}{1}{2}{3}{4}{5}", Space(m_space + 8), "Total Importe", Space(m_space + 5), _simb, Space(m_space + 1), ACUtilitarios.Alinear(ACAlineacion.Derecha, m_docventa.DOCVE_TotalVenta.ToString("##,###,##0.00"), 12).PadRight(12, " ").Substring(0, 12)))
                _pieespacio.Add(New String(""))
                '_pieespacio.Add(New String(""))
                '_pieespacio.Add(New String(""))'comentado frank 
            End If
            _pie.Add(New String(""))
            _pie.Add(New String(""))
            _pieespacio.Add(New String(""))
            _pieespacio.Add(New String(""))

            ' If m_docventa.TIPOS_CodTipoMoneda.Equals(ETipos.getTipo(ETipos.TipoMoneda.Dolares)) Then
            If (_simb = "US$") Then
                If (ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " DOLARES AMERICANOS").Length > 36 And ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " DOLARES AMERICANOS").Length < 78) Then
                    _pie.Add(String.Format("{0}{1}", "SON: ", ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " DOLARES AMERICANOS").Substring(0, 36)))
                    _pie.Add(String.Format("{0}{1}", Space(m_space), ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " DOLARES AMERICANOS").Substring(36, ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " DOLARES AMERICANOS").Length - 36)))
                    _pieespacio.Add(New String(""))
                    _pieespacio.Add(New String(""))
                ElseIf ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " DOLARES AMERICANOS").Length > 78 Then
                    _pie.Add(String.Format("{0}{1}", "SON: ", ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " DOLARES AMERICANOS").Substring(0, 36)))
                    _pie.Add(String.Format("{0}{1}", Space(m_space), ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " DOLARES AMERICANOS").Substring(36, 41)))
                    _pie.Add(String.Format("{0}", ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " DOLARES AMERICANOS").Substring(77, ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " DOLARES AMERICANOS").Length - 77)))
                    _pieespacio.Add(New String(""))
                    _pieespacio.Add(New String(""))
                    _pieespacio.Add(New String(""))
                Else
                    _pie.Add(String.Format("{0}{1}", "SON: ", ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " DOLARES AMERICANOS").Substring(0, ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " DOLARES AMERICANOS").Length - 1)))
                    _pieespacio.Add(New String(""))
                End If

            Else

                If (ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " SOLES").Length > 36 And ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " SOLES").Length < 78) Then
                    _pie.Add(String.Format("{0}{1}", "SON: ", ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " SOLES").Substring(0, 36)))
                    _pie.Add(String.Format("{0}{1}", Space(m_space), ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " SOLES").Substring(36, ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " SOLES").Length - 36)))
                    _pieespacio.Add(New String(""))
                    _pieespacio.Add(New String(""))
                ElseIf ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " SOLES").Length > 78 Then
                    _pie.Add(String.Format("{0}{1}", "SON: ", ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " SOLES").Substring(0, 36)))
                    _pie.Add(String.Format("{0}{1}", Space(m_space), ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " SOLES").Substring(36, 41)))
                    _pie.Add(String.Format("{0}", ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " SOLES").Substring(77, ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " SOLES").Length - 77)))
                    _pieespacio.Add(New String(""))
                    _pieespacio.Add(New String(""))
                    _pieespacio.Add(New String(""))
                Else

                    _pie.Add(String.Format("{0}{1}", "SON: ", ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " SOLES").Substring(0, ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalVenta, " SOLES").Length - 1)))
                    _pieespacio.Add(New String(""))

                End If

            End If


            _pie.Add(String.Format("{0}{1}{2}", "Tipo Pago:", Space(m_space + 2), m_docventa.TIPOS_CondicionPagoCorto))
            ' End If

            If m_docventa.TIPOS_CondicionPagoCorto.Substring(0, 7) = "Credito" Then 'SI ES A CREDITO 

                _pie.Add(String.Format("{0}{1}{2}", "Fecha Vcto:", Space(m_space + 2), m_docventa.DOCVE_PlazoFecha.ToString("dd/MM/yyyy")))
                _pie.Add(String.Format("{0}{1}{2}", "Porcentaje Detraccion:", Space(m_space + 1), m_docventa.DOCVE_PorcentajeDetraccion.ToString() & "%")) '<-----agregado m_docventa.TIPOS_CodTipoMoneda = S/. || USDolares
                _pie.Add(String.Format("{0}{1}{2}", "Importe Detraccion:", Space(m_space + 1), "S/." & m_docventa.DOCVE_ImporteDetraccion.ToString())) '<---- 
                _pie.Add(String.Format("{0}{1}{2}", "Monto Pend:", Space(m_space + 2) & Soles, m_docventa.DOCVE_TotalPagar - m_docventa.DOCVE_ImporteDetraccion))

            Else
                _pie.Add(String.Format("{0}{1}{2}", "Fecha Vcto:", Space(m_space + 2), "-"))
                _pie.Add(String.Format("{0}{1}{2}", "Monto Pend:", Space(m_space + 2), "0.00"))
            End If
            _pie.Add(String.Format("{0}{1}{2}", "Hora:", Space(m_space + 7), DateTime.Now.ToString("hh:mm tt")))
            ' _pie.Add(String.Format("{0}{1}{2}", "O. Compra:", Space(m_space + 2), m_docventa.DOCVE_OrdenCompra))
            _pie.Add(String.Format("{0}{1}{2}", "Usuario:", Space(m_space + 2), m_docventa.DOCVE_UsrCrea)) 'm_docventa.Cotizador))


            _pieespacio.Add(New String(""))
            _pieespacio.Add(New String(""))
            '   _pieespacio.Add(New String("")) comentado frank 
            '   _pieespacio.Add(New String("")) comentado frank
            '_pie.Add(String.Format("{0}{1}{2}", "Vendedor:", Space(m_space + 3), m_docventa.ENTID_Vendedor))
            ''_pie.Add(New String(""))
            _pie.Add(New String(""))


            '  _pie.Add(String.Format("{0}{1}", "Observ.:", Space(m_space + 2) + m_docventa.DOCVE_Observaciones))
            _pie.Add("Observ.:" & Space(m_space + 2) & m_docventa.DOCVE_Observaciones)
            '  MessageBox.Show(m_docventa.DOCVE_Observaciones)

            _pie.Add(New String(""))
            _pie.Add(String.Format("{0}{1}", Space(m_space), "Documento para  control Administrativo,"))
            _pie.Add(String.Format("{0}{1}", Space(m_space), "Para visualizar su representación impresa"))
            _pie.Add(String.Format("{0}{1}", Space(m_space + 17), "visitar"))
            _pieespacio.Add(New String(""))
            _pieespacio.Add(New String(""))
            _pieespacio.Add(New String(""))
            _pieespacio.Add(New String(""))

            _pie.Add(String.Format("{0}{1}", Space(m_space), "http://facturas.aceroscomerciales.com.pe"))
            _pie.Add(String.Format("{0}{1}", Space(m_space + 6), "Autorizado mediante Resolución"))
            _pie.Add(String.Format("{0}{1}", Space(m_space + 10), "052-005-0000140/SUNAT"))
            ' _pieespacio.Add(New String(""))
            ' _pieespacio.Add(New String("")) 'comentado frank 
            '  _pieespacio.Add(New String("")) 'comentado frank 

            '_pie.Add(New String(""))
            '_pie.Add(New String(""))
            '_pie.Add(New String(""))
            _pie.Add(New String(""))
            _pie.Add(New String(""))
            If (GApp.EPuntoVenta.PVENT_Glosa.Length > 41 And GApp.EPuntoVenta.PVENT_Glosa.Length < 83) Then
                _pie.Add(String.Format("{0}", GApp.EPuntoVenta.PVENT_Glosa.Substring(0, 41)))
                _pie.Add(String.Format("{0}", GApp.EPuntoVenta.PVENT_Glosa.Substring(41, GApp.EPuntoVenta.PVENT_Glosa.Length - 41)))
            ElseIf GApp.EPuntoVenta.PVENT_Glosa.Length > 82 Then
                _pie.Add(String.Format("{0}", GApp.EPuntoVenta.PVENT_Glosa.Substring(0, 41)))
                _pie.Add(String.Format("{0}", GApp.EPuntoVenta.PVENT_Glosa.Substring(41, 41)))
                _pie.Add(String.Format("{0}", GApp.EPuntoVenta.PVENT_Glosa.Substring(82, GApp.EPuntoVenta.PVENT_Glosa.Length - 82)))

            Else
                _pie.Add(String.Format("{0}{1}", Space(m_space), GApp.EPuntoVenta.PVENT_Glosa.Substring(0, GApp.EPuntoVenta.PVENT_Glosa.Length - 1)))

            End If
            _pie.Add(New String(""))
            _pie.Add(New String(""))

            If x_spot = True Then
                _pie.Add(String.Format("{0}{1}", Space(m_space), "Operacion Sujeta al Sistema de Pago de"))
                _pie.Add(String.Format("{0}{1}", Space(m_space), "ObligacionesTributarias Con el Gobierno Central."))
                _pie.Add(String.Format("{0}{1}", Space(m_space), "Cta. Cte. Bco. de la Nacion 101-091929"))
                _pie.Add(New String(""))
                _pie.Add(New String(String.Format("{0}{1}", Space(m_space), "Designado Agente de Retención RS 228-2012")))
            Else
                _pie.Add(New String(String.Format("{0}{1}", Space(m_space), "Designado Agente de Retención RS 228-2012")))
            End If

            m_pie = New StringBuilder()
            ACUtilitarios.genTexto(_pie, m_pie)
            ACUtilitarios.genTexto(_pie1, m_pie1)
            ACUtilitarios.genTexto(_pieespacio, m_pieespacios)

            ''For index As Integer = 1 To 2
            ''    If index = 1 Then
            'globales_.cabecera = m_cabecera.ToString()
            'globales_.cuerpo = m_cuerpo.ToString()
            'globales_.pie = m_pie.ToString()
            'globales_.pie1 = m_pie1.ToString()
            'globales_.Pieespacios = m_pieespacios.ToString()
            ' '''
            'globales_.cuerpo1 = m_cuerpo1.ToString()
            'globales_.cuerpoespacio = m_cuerpoespacio.ToString()
            ' '''
            'globales_.tamdeta = x_tamdetalle
            'globales_.cabecera1 = m_cabecera1.ToString()
            'imagenPD.PrinterSettings.PrinterName = m_printername

            'Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", 1000, 2600)
            'imagenPD.DefaultPageSettings.PaperSize = pkCustomSize1
            'Dim printControl = New Printing.StandardPrintController
            'imagenPD.PrintController = printControl
            'imagenPD.Print()
            For index As Integer = 1 To 2
                If index = 1 Then
                    globales_.cabecera = m_cabecera.ToString()
                    globales_.cuerpo = m_cuerpo.ToString()
                    globales_.pie = m_pie.ToString()
                    globales_.pie1 = m_pie1.ToString()
                    globales_.Pieespacios = m_pieespacios.ToString()
                    '''
                    globales_.cuerpo1 = m_cuerpo1.ToString()
                    globales_.cuerpoespacio = m_cuerpoespacio.ToString()
                    '''
                    globales_.tamdeta = x_tamdetalle
                    globales_.cabecera1 = m_cabecera1.ToString()
                    imagenPD.PrinterSettings.PrinterName = m_printername

                    Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", 1000, 2600)
                    imagenPD.DefaultPageSettings.PaperSize = pkCustomSize1
                    Dim printControl = New Printing.StandardPrintController
                    imagenPD.PrintController = printControl
                    imagenPD.Print()

                ElseIf index = 2 Then

                    globales_.cabecera = m_cabecera.ToString()
                    globales_.cuerpo = m_cuerpo.ToString()
                    globales_.cuerpoprecios = m_cuerpoprecios.ToString()
                    globales_.pie = m_pie.ToString()
                    globales_.tamdeta = x_tamdetalle


                    imagenPD.PrinterSettings.PrinterName = m_printername
                    Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", 1000, 3000)
                    imagenPD.DefaultPageSettings.PaperSize = pkCustomSize1

                    imagenPD.Print()

                End If
            Next


            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function ImprimirF001JRAnc(ByVal m_docventa As EVENT_DocsVenta, ByVal x_filas As Integer) As Boolean
        Dim m_texto As String = ""
        Dim m_space As Integer = 0
        Dim m_cabecera As New StringBuilder
        Dim m_cuerpo As New StringBuilder
        Dim m_pie As New StringBuilder
        Dim m_lineasCabecera As Integer = 10
        Try
            '' Generar Cabecera
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, m_lineasCabecera)
            m_cabecera.Append(String.Format("{0}{1}", Space(m_space + 100), m_docventa.Documento))
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 2)
            Dim _cab As New List(Of String)
            _cab.Add(String.Format("{0}{1}", Space(m_space + 16), m_docventa.DOCVE_DescripcionCliente))
            _cab.Add(New String(""))
            _cab.Add(String.Format("{0}{1}", Space(m_space + 16), m_docventa.DOCVE_DireccionCliente))
            _cab.Add(New String(""))
            '_cab.Add(String.Format("{0}{1}{2}{3}", Space(m_space + 96) _
            '                       , m_docventa.DOCVE_FechaDocumento.Day.ToString("00").PadRight(9, " ") _
            '                       , MonthName(m_docventa.DOCVE_FechaDocumento.Month).ToUpper().PadRight(26, " ").Substring(0, 26) _
            '                       , m_docventa.DOCVE_FechaDocumento.Year.ToString("0000")))
            _cab.Add(String.Format("{0}{1}{2}{3}{4}{5}{6}", Space(m_space + 14), m_docventa.ENTID_NroDocumento.PadRight(36, " ") _
                                   , m_docventa.DOCVE_Guias.PadRight(42, " "), Space(3) _
                                   , m_docventa.DOCVE_FechaDocumento.Day.ToString("00").PadRight(11, " ") _
                                   , MonthName(m_docventa.DOCVE_FechaDocumento.Month).ToUpper().PadRight(26, " ").Substring(0, 24) _
                                   , m_docventa.DOCVE_FechaDocumento.Year.ToString("0000")))
            _cab.Add(New String("")) ': _cab.Add(New String(""))

            ACUtilitarios.genTexto(_cab, m_cabecera)
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 2)
            '' Generar Detalle
            Dim x_fila As Integer = 0
            For Each item As EVENT_DocsVentaDetalle In m_docventa.ListVENT_DocsVentaDetalle
                Dim x_lista As New List(Of String)
                If IsNothing(item.DOCVD_Detalle) Then item.DOCVD_Detalle = ""
                Dim _precio As Decimal
                Dim _importe As Decimal
                If m_docventa.DOCVE_PrecIncIVG Then
                    _precio = item.DOCVD_PrecioUnitarioPrecIncIGV
                    _importe = _precio * item.DOCVD_Cantidad
                Else
                    _precio = item.DOCVD_PrecioUnitario
                    _importe = item.DOCVD_SubImporteVenta
                End If
                If ACUtilitarios.GetTextoLines(item.DOCVD_Detalle, 75, x_lista) > 0 Then
                    m_cuerpo.Append(String.Format("{0}{1}  {2}{3}{4}{5}{5}", Space(m_space) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_Cantidad.ToString("###,##0.000"), 17) _
                                                        , x_lista(0).PadRight(78, " ").Substring(0, 78) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, _precio.ToString("###,##0.00"), 17) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, _importe.ToString("###,##0.00"), 18) _
                                                        , vbNewLine))
                    If x_lista.Count > 1 Then
                        Dim j As Integer
                        For j = 1 To x_lista.Count - 1
                            m_cuerpo.Append(String.Format("{0}{1}{2}{2}", Space(m_space + 19), x_lista(j).Trim(), vbNewLine))
                        Next
                    End If
                    x_fila += x_lista.Count * 2
                Else
                    x_fila += 1
                    m_cuerpo.Append(String.Format("{0}{1}{2}{3}{4}{5}", Space(m_space) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_Cantidad.ToString("###,##0.0000"), 17) _
                                                        , "".PadRight(78, " ").Substring(0, 78) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_PrecioUnitario.ToString("###,##0.0000"), 17) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_SubImporteVenta.ToString("###,##0.0000"), 18)
                                                        ))
                End If

            Next
            ACUtilitarios.ImprimeLinBlanco(m_cuerpo, x_filas - x_fila + 1)

            ' Generar Pie de Pagina
            Dim _pie As New List(Of String)
            If (IsNothing(m_docventa.DOCVE_NotaPie)) Then
                _pie.Add(New String(" "))
            Else
                _pie.Add(New String(String.Format("{0}{1}", Space(m_space + 18), m_docventa.DOCVE_NotaPie.Trim())))
            End If
            _pie.Add(New String(" "))
            Dim _filter As New ACFiltrador(Of ETipos)
            _filter.ACFiltro = String.Format("TIPOS_Codigo={0}", m_docventa.TIPOS_CodTipoMoneda)
            _filter.ACFiltrar(Colecciones.Tipos)
            Dim _simb = "S/."
            If _filter.ACListaFiltrada.Count > 0 Then
                _simb = _filter.ACListaFiltrada(0).TIPOS_DescCorta
                _pie.Add(String.Format("{0}{1}", Space(m_space + 115), (_simb & " " & m_docventa.DOCVE_ImporteVenta.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))).ToString().PadLeft(18, " ").Substring(0, 18)))
                _pie.Add(String.Format("{0}{1}", Space(m_space + 11), ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalPagar, " SOLES").PadRight(104, " ")))
            Else
                _pie.Add(String.Format("{0}{1}", Space(m_space + 115), (_simb & " " & m_docventa.DOCVE_ImporteVenta.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))).ToString().PadLeft(18, " ").Substring(0, 18)))
                _pie.Add(String.Format("{0}{1}", Space(m_space + 11), ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalPagar, " SOLES").PadRight(102, " ")))
            End If
            '_pie.Add(New String("{0}{1}", Space(m_space + 115), (_simb & " " & m_docventa.DOCVE_ImporteVenta.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))).ToString().PadLeft(16, " ").Substring(0, 16)))
            _pie.Add(String.Format("{0}{1}", Space(m_space + 115), (_simb & " " & m_docventa.DOCVE_ImporteIgv.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))).ToString().PadLeft(18, " ").Substring(0, 18)))
            _pie.Add(New String(" "))
            _pie.Add(String.Format("{0}{1}", Space(m_space + 115), (_simb & " " & m_docventa.DOCVE_TotalPagar.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))).ToString().PadLeft(18, " ").Substring(0, 18)))

            ACUtilitarios.genTexto(_pie, m_pie)

            '' Generar Documento Final
            m_cabecera.Append(m_cuerpo)
            m_cabecera.Append(m_pie)

            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 3)

            ACImpresion.ACImprimir.Inicializar(m_printername)
            ACImpresion.ACImprimir.SendStringToPrinter(Chr(18))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.NumeroLineas(78))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Fuente(ACFuentes.Draft))
            ACImpresion.ACImprimir.SendStringToPrinter(String.Format("{0}{1}", Chr(27), Chr(15)))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.FuenteDraft(ACDrafts.Draft10PCI))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Condensado(False))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Interespaciado(ACInterEspaciado.Ocho))
            ACImprimir.SendStringToPrinter(m_cabecera.ToString())

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function ImprimirF001JRAncVOld(ByVal m_docventa As EVENT_DocsVenta, ByVal x_filas As Integer) As Boolean
        Dim m_texto As String = ""
        Dim m_space As Integer = 0
        Dim m_cabecera As New StringBuilder
        Dim m_cuerpo As New StringBuilder
        Dim m_pie As New StringBuilder
        Try
            '' Generar Cabecera
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 10)
            m_cabecera.Append(String.Format("{0}{1}", Space(m_space + 100), m_docventa.Documento))
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 2)
            Dim _cab As New List(Of String)
            _cab.Add(String.Format("{0}{1}", Space(m_space + 14), m_docventa.DOCVE_DescripcionCliente))
            _cab.Add(New String(""))
            _cab.Add(String.Format("{0}{1}", Space(m_space + 14), m_docventa.DOCVE_DireccionCliente))
            _cab.Add(String.Format("{0}{1}{2}{3}", Space(m_space + 94) _
                                   , m_docventa.DOCVE_FechaDocumento.Day.ToString("00").PadRight(7, " ") _
                                   , MonthName(m_docventa.DOCVE_FechaDocumento.Month).ToUpper().PadRight(28, " ").Substring(0, 28) _
                                   , m_docventa.DOCVE_FechaDocumento.Year.ToString("0000")))
            _cab.Add(String.Format("{0}{1}{2}", Space(m_space + 12), m_docventa.ENTID_NroDocumento.PadRight(34, " ") _
                                   , m_docventa.DOCVE_Guias))
            _cab.Add(New String(""))

            ACUtilitarios.genTexto(_cab, m_cabecera)
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 2)
            '' Generar Detalle
            Dim x_fila As Integer = 0
            For Each item As EVENT_DocsVentaDetalle In m_docventa.ListVENT_DocsVentaDetalle
                Dim x_lista As New List(Of String)
                If IsNothing(item.DOCVD_Detalle) Then item.DOCVD_Detalle = ""
                If ACUtilitarios.GetTextoLines(item.DOCVD_Detalle, 75, x_lista) > 0 Then
                    m_cuerpo.Append(String.Format("{0}{1}  {2}{3}{4}{5}{5}", Space(m_space) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_Cantidad.ToString("###,##0.000"), 14) _
                                                        , x_lista(0).PadRight(81, " ").Substring(0, 81) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_PrecioUnitario.ToString("###,##0.00"), 17) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_SubImporteVenta.ToString("###,##0.00"), 18) _
                                                        , vbNewLine))
                    If x_lista.Count > 1 Then
                        Dim j As Integer
                        For j = 1 To x_lista.Count - 1
                            m_cuerpo.Append(String.Format("{0}{1}{2}{2}", Space(m_space + 16), x_lista(j).Trim(), vbNewLine))
                        Next
                    End If
                    x_fila += x_lista.Count * 2
                Else
                    x_fila += 1
                    m_cuerpo.Append(String.Format("{0}{1}{2}{3}{4}{5}", Space(m_space) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_Cantidad.ToString("###,##0.0000"), 14) _
                                                        , "".PadRight(81, " ").Substring(0, 81) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_PrecioUnitario.ToString("###,##0.0000"), 17) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.DOCVD_SubImporteVenta.ToString("###,##0.0000"), 18)
                                                        ))
                End If

            Next
            ACUtilitarios.ImprimeLinBlanco(m_cuerpo, x_filas - x_fila + 1)

            '' Generar Pie de Pagina
            Dim _pie As New List(Of String)
            If (IsNothing(m_docventa.DOCVE_NotaPie)) Then
                _pie.Add(New String(" "))
            Else
                _pie.Add(New String(String.Format("{0}{1}", Space(m_space + 16), m_docventa.DOCVE_NotaPie.Trim())))
            End If
            _pie.Add(New String(" "))
            Dim _filter As New ACFiltrador(Of ETipos)
            _filter.ACFiltro = String.Format("TIPOS_Codigo={0}", m_docventa.TIPOS_CodTipoMoneda)
            _filter.ACFiltrar(Colecciones.Tipos)
            Dim _simb = "S/."
            If _filter.ACListaFiltrada.Count > 0 Then
                _simb = _filter.ACListaFiltrada(0).TIPOS_DescCorta
                _pie.Add(String.Format("{0}{1}", Space(m_space + 115), (_simb & " " & m_docventa.DOCVE_ImporteVenta.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))).ToString().PadLeft(18, " ").Substring(0, 18)))
                _pie.Add(String.Format("{0}{1}", Space(m_space + 9), ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalPagar, _filter.ACListaFiltrada(0).TIPOS_Descripcion).PadRight(106, " ")))
            Else
                _pie.Add(String.Format("{0}{1}", Space(m_space + 115), (_simb & " " & m_docventa.DOCVE_ImporteVenta.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))).ToString().PadLeft(18, " ").Substring(0, 18)))
                _pie.Add(String.Format("{0}{1}", Space(m_space + 9), ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalPagar, "NUEVOS SOLES").PadRight(104, " ")))
            End If
            '_pie.Add(New String("{0}{1}", Space(m_space + 115), (_simb & " " & m_docventa.DOCVE_ImporteVenta.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))).ToString().PadLeft(16, " ").Substring(0, 16)))
            _pie.Add(String.Format("{0}{1}", Space(m_space + 115), (_simb & " " & m_docventa.DOCVE_ImporteIgv.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))).ToString().PadLeft(18, " ").Substring(0, 18)))
            _pie.Add(New String(" "))
            _pie.Add(String.Format("{0}{1}", Space(m_space + 115), (_simb & " " & m_docventa.DOCVE_TotalPagar.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))).ToString().PadLeft(18, " ").Substring(0, 18)))

            ACUtilitarios.genTexto(_pie, m_pie)

            '' Generar Documento Final
            m_cabecera.Append(m_cuerpo)
            m_cabecera.Append(m_pie)

            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 3)

            ACImpresion.ACImprimir.Inicializar(m_printername)
            ACImpresion.ACImprimir.SendStringToPrinter(Chr(18))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.NumeroLineas(78))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Fuente(ACFuentes.Draft))
            ACImpresion.ACImprimir.SendStringToPrinter(String.Format("{0}{1}", Chr(27), Chr(15)))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.FuenteDraft(ACDrafts.Draft10PCI))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Condensado(False))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Interespaciado(ACInterEspaciado.Ocho))
            ACImprimir.SendStringToPrinter(m_cabecera.ToString())

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

    Public Function ImprimirLinea(ByVal x_cadena As String, ByVal x_filas As Integer, ByVal x_columnas As Integer, ByVal x_interlineado As Integer)
        Dim m_cabecera As New StringBuilder
        Try
            '' Generar Documento Final
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, x_filas)
            m_cabecera.Append(String.Format("{0}{1}", Space(x_columnas), x_cadena))

            '' Imprimir
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 3)

            ACImpresion.ACImprimir.Inicializar(m_printername)
            ACImpresion.ACImprimir.SendStringToPrinter(Chr(18))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.NumeroLineas(68))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Fuente(ACFuentes.Draft))
            ACImpresion.ACImprimir.SendStringToPrinter(String.Format("{0}{1}", Chr(27), Chr(15)))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.FuenteDraft(ACDrafts.Draft10PCI))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Condensado(False))
            If x_interlineado = 6 Then
                ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Interespaciado(ACInterEspaciado.Seis))
            Else
                ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Interespaciado(ACInterEspaciado.Ocho))
            End If
            ACImprimir.SendStringToPrinter(m_cabecera.ToString())

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImprimirLista(ByVal m_cabecera As StringBuilder)
        Try
            '' Generar Documento Final
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 15)
            '' Imprimir
            ACImpresion.ACImprimir.Inicializar(m_printername)
            ACImpresion.ACImprimir.SendStringToPrinter(Chr(18))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.NumeroLineas(68))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Fuente(ACFuentes.Draft))
            ACImpresion.ACImprimir.SendStringToPrinter(String.Format("{0}{1}", Chr(27), Chr(15)))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.FuenteDraft(ACDrafts.Draft10PCI))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Condensado(False))

            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Interespaciado(ACInterEspaciado.Seis))

            ACImprimir.SendStringToPrinter(m_cabecera.ToString())

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region " Guias de Remision "

    Private Function ImprimirG018Aceros(ByVal m_guia As ETRAN_GuiasTransportista, ByVal x_filas As Integer) As Boolean
        Try
            Dim dtDatos As New DSGuiaTransportista
            Dim _dr As DataRow = dtDatos.TRAN_GuiasTransportista.NewRow()
            _dr("GTRAN_Codigo") = m_guia.GTRAN_Codigo
            _dr("GTRAN_Fecha") = m_guia.GTRAN_Fecha
            _dr("GTRAN_FechaTraslado") = m_guia.GTRAN_FechaTraslado
            _dr("GTRAN_DireccionPartida") = m_guia.ENTID_DireccionProveedor 'GTRAN_DireccionProveedor
            _dr("GTRAN_DireccionLlegada") = m_guia.GTRAN_DireccionDestinatario
            _dr("GTRAN_ZonaSalida") = m_guia.GTRAN_ZonaProveedor
            _dr("GTRAN_ZonaLlegada") = m_guia.GTRAN_ZonaDestinatario
            _dr("SalidaDistrito") = m_guia.SalidaDistrito
            _dr("SalidaProvincia") = m_guia.SalidaProvincia
            _dr("SalidaDepartamento") = m_guia.SalidaDepartamento
            _dr("LlegadaDistrito") = m_guia.LlegadaDistrito
            _dr("LlegadaProvincia") = m_guia.LlegadaProvincia
            _dr("LlegadaDepartamento") = m_guia.LlegadaDepartamento
            _dr("LlegadaRuc") = m_guia.GTRAN_RUCDestinatario
            _dr("LlegadaEntidad") = m_guia.GTRAN_DesEntidadDestinatario
            _dr("GTRAN_DescripcionEntidad") = m_guia.GTRAN_DescEntidadProveedor
            _dr("GTRAN_DescripcionVehiculo") = m_guia.GTRAN_DescripcionVehiculo
            '_dr("GTRAN_ZonaSalida") = m_guia.GTRAN_DescripcionEntidad
            _dr("GTRAN_RUCLlegada") = m_guia.GTRAN_RUCDestinatario
            '_dr("GTRAN_ZonaSalida") = m_guia.GTRAN_ZonaSalida
            _dr("GTRAN_PesoTotal") = m_guia.GTRAN_PesoTotal
            _dr("ENTID_Transportista") = m_guia.ENTID_Transportista
            _dr("ENTID_TranRUC") = m_guia.ENTID_TranRUC
            _dr("TipoComprobante") = m_guia.TipoComprobante
            _dr("NumeroComprobante") = m_guia.NumeroComprobante
            _dr("GTRAN_NroPedido") = m_guia.GTRAN_NroPedido
            _dr("ENTID_Conductor") = m_guia.ENTID_Conductor
            If IsNothing(m_guia.GTRAN_CertificadosVehiculo) Then
                _dr("Certificados") = m_guia.Certificados
            Else
                _dr("Certificados") = m_guia.GTRAN_CertificadosVehiculo
            End If
            _dr("CONDU_Licencia") = m_guia.CONDU_Licencia
            _dr("FechaDia") = m_guia.GTRAN_Fecha.Day.ToString("00")
            _dr("FechaMes") = m_guia.GTRAN_Fecha.Month.ToString("00")
            _dr("FecTraDia") = m_guia.GTRAN_FechaTraslado.Day.ToString("00")
            _dr("FecTraMes") = m_guia.GTRAN_FechaTraslado.Month.ToString("00")
            _dr("NroGuia") = String.Format("{0}-{1}", m_guia.GTRAN_Serie, m_guia.GTRAN_Numero.ToString("000000"))

            dtDatos.TRAN_GuiasTransportista.Rows.Add(_dr)

            For Each Item As ETRAN_GuiasTransportistaDetalles In m_guia.ListETRAN_GuiasTransportistaDetalles
                Dim x_dr As DataRow = dtDatos.TRAN_GuiasTransportistaDetalles.NewRow()
                x_dr("GTRAN_Codigo") = Item.GTRAN_Codigo
                x_dr("GTDET_Unidad") = Item.GTDET_Unidad
                x_dr("GTDET_Descripcion") = Item.GTDET_Descripcion
                x_dr("GTDET_Cantidad") = Item.GTDET_Cantidad.ToString("#0")
                dtDatos.TRAN_GuiasTransportistaDetalles.Rows.Add(x_dr)
            Next

            'Dim Informe As New CRGuiaTransportista
            Dim strReportName As String = "CRGuiaTransportista.rpt"
            Dim strReportPath As String = System.IO.Path.Combine(GApp.Path_Plantillas, strReportName)
            If Not IO.File.Exists(strReportPath) Then
                Throw (New Exception("No Existe el reporte:" & vbCrLf & strReportPath))
            End If

            Dim Informe As New ReportDocument
            Informe.Load(strReportPath)

            Informe.SetDataSource(dtDatos)

            Informe.PrintOptions.PrinterName = m_printername
            Informe.PrintOptions.PaperSize = [Shared].PaperSize.PaperA4
            Informe.PrintOptions.PaperOrientation = [Shared].PaperOrientation.Portrait
            Informe.PrintToPrinter(1, True, 1, 1)

            Informe.Close()
            'Dim reporte As New RReportView(Informe)
            'reporte.ShowDialog()
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function ImprimirG011Aceros(ByVal m_guia As ETRAN_GuiasTransportista, ByVal x_filas As Integer) As Boolean
        Dim m_texto As String = ""
        Dim m_space As Integer = 0
        Dim m_cabecera As New StringBuilder
        Dim m_cuerpo As New StringBuilder
        Dim m_pie As New StringBuilder
        Try
            '' Generar Cabecera
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 5)
            m_cabecera.Append(String.Format("{0}{1}", Space(m_space + 100), m_guia.Documento))
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 1)
            Dim _cab As New List(Of String)
            _cab.Add(String.Format("{0}Arequipa  {1}  {2}{4}", Space(m_space), m_guia.GTRAN_Fecha.Day.ToString("00") _
                                   , MonthName(m_guia.GTRAN_Fecha.Month).ToString().PadRight(20, " ") _
                                   , m_guia.GTRAN_Fecha.Year.ToString()))
            _cab.Add(New String(""))
            _cab.Add(String.Format("{0}{1}-{2}/{3}/{4}", Space(m_space + 14), m_guia.GTRAN_DireccionRemitente, m_guia.SalidaDepartamento _
                                   , m_guia.SalidaProvincia, m_guia.SalidaDistrito))
            _cab.Add(New String(""))
            _cab.Add(String.Format("{0}{1}-{2}/{3}/{4}", Space(m_space + 14), m_guia.GTRAN_DireccionDestinatario, m_guia.LlegadaDepartamento _
                                   , m_guia.LlegadaProvincia, m_guia.LlegadaDistrito))
            _cab.Add(New String("{0}{1}", Space(m_space), m_guia.GTRAN_DescEntidadRemitente))
            _cab.Add(New String("{0}{1}", Space(m_space), m_guia.ENTID_Codigo.Substring(1)))
            _cab.Add(New String(""))
            _cab.Add(New String("{0}{1}", Space(m_space), m_guia.GTRAN_DesEntidadDestinatario))
            _cab.Add(New String("{0}{1}", Space(m_space), m_guia.ENTID_CodigoDestinatario.Substring(1)))

            _cab.Add(New String("{0}{1}", Space(m_space), m_guia.GTRAN_FechaTraslado.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha))))
            _cab.Add(New String(""))

            ACUtilitarios.genTexto(_cab, m_cabecera)
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 2)
            '' Generar Detalle
            Dim x_fila As Integer = 0
            For Each item As ETRAN_GuiasTransportistaDetalles In m_guia.ListETRAN_GuiasTransportistaDetalles
                Dim x_lista As New List(Of String)
                If IsNothing(item.GTDET_Descripcion) Then item.GTDET_Descripcion = ""
                If ACUtilitarios.GetTextoLines(item.GTDET_Descripcion, 75, x_lista) > 0 Then
                    m_cuerpo.Append(String.Format("{0}{1}  {2}{3}{4}{5}{5}", Space(m_space) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.ARTIC_Codigo, 10) _
                                                        , x_lista(0).PadRight(81, " ").Substring(0, 81) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.GTDET_Unidad, 17) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.GTDET_Cantidad.ToString("###,##0.000"), 14) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.GTDET_Peso.ToString("###,##0.00"), 18) _
                                                        , vbNewLine))
                    If x_lista.Count > 1 Then
                        Dim j As Integer
                        For j = 1 To x_lista.Count - 1
                            m_cuerpo.Append(String.Format("{0}{1}{2}{2}", Space(m_space + 10), x_lista(j).Trim(), vbNewLine))
                        Next
                    End If
                    x_fila += x_lista.Count * 2
                Else
                    x_fila += 1
                    m_cuerpo.Append(String.Format("{0}{1}{2}{3}{4}{5}", Space(m_space) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.ARTIC_Codigo, 10) _
                                                        , "".Substring(0, 81) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.GTDET_Unidad, 17) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.GTDET_Cantidad.ToString("###,##0.000"), 14) _
                                                        , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.GTDET_Peso.ToString("###,##0.00"), 18) _
                                                        , vbNewLine))
                End If

            Next
            ACUtilitarios.ImprimeLinBlanco(m_cuerpo, x_filas - x_fila + 1)

            '' Generar Pie de Pagina
            Dim _pie As New List(Of String)
            '_pie.Add(New String("{0}{1}", Space(m_space + 115), (_simb & " " & m_docventa.DOCVE_ImporteVenta.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))).ToString().PadLeft(16, " ").Substring(0, 16)))
            '_pie.Add(String.Format("{0}{1}", Space(m_space + 115), (_simb & " " & m_guia.DOCVE_ImporteIgv.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))).ToString().PadLeft(18, " ").Substring(0, 18)))
            '_pie.Add(New String(" "))
            '_pie.Add(String.Format("{0}{1}", Space(m_space + 115), (_simb & " " & m_guia.DOCVE_TotalPagar.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))).ToString().PadLeft(18, " ").Substring(0, 18)))

            ACUtilitarios.genTexto(_pie, m_pie)

            '' Generar Documento Final
            m_cabecera.Append(m_cuerpo)
            m_cabecera.Append(m_pie)

            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 3)

            ACImpresion.ACImprimir.Inicializar(m_printername)
            ACImpresion.ACImprimir.SendStringToPrinter(Chr(18))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.NumeroLineas(78))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Fuente(ACFuentes.Draft))
            ACImpresion.ACImprimir.SendStringToPrinter(String.Format("{0}{1}", Chr(27), Chr(15)))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.FuenteDraft(ACDrafts.Draft10PCI))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Condensado(False))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Interespaciado(ACInterEspaciado.Ocho))
            ACImprimir.SendStringToPrinter(m_cabecera.ToString())

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function ImprimirG023Aceros(ByVal m_guiaventa As ETRAN_GuiasTransportista, ByVal x_filas As Integer, x_top As Integer, x_left As Integer) As Boolean
        Dim m_texto As String = ""
        Dim m_space As Integer = 0
        Dim m_cabecera As New StringBuilder
        Dim m_cabeceradet As New StringBuilder
        Dim m_cuerpo As New StringBuilder
        Dim m_cuerpo_esp As New StringBuilder
        Dim m_pie As New StringBuilder
        Try
            '' Generar Cabecera
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, x_top)
            m_cabecera.Append(String.Format("{0}{1}", Space(m_space + 110), m_guiaventa.Documento))
            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 2)
            Dim _cab As New List(Of String)
            _cab.Add(String.Format("{0}{1}{2}{3}", Space(m_space + 25) _
                                             , m_guiaventa.GTRAN_Fecha.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)).PadRight(10, " ") _
                                             , Space(33) _
                                             , m_guiaventa.GTRAN_FechaTraslado.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)).PadRight(10, " ")))

            Dim _lon1 As Integer = 43
            Dim _lon2 As Integer = 60
            Dim x_lista1 As New List(Of String)
            ACUtilitarios.GetTextoLines(m_guiaventa.ENTID_DireccionProveedor + " " + Space(10) + m_guiaventa.SalidaDistrito + " /" + m_guiaventa.SalidaProvincia + " /" + m_guiaventa.SalidaDepartamento, _lon1, x_lista1)

            'ACUtilitarios.GetTextoLines(" ", _lon1, x_lista1)
            Dim x_lista2 As New List(Of String)

            ACUtilitarios.GetTextoLines(m_guiaventa.GTRAN_DireccionDestinatario + " " + Space(20) + m_guiaventa.LlegadaDistrito + " /" + m_guiaventa.LlegadaProvincia + " /" + m_guiaventa.LlegadaDepartamento, _lon2, x_lista2)

            Dim _i As Integer = IIf(x_lista1.Count > x_lista2.Count, x_lista1.Count, x_lista2.Count)
            ''
            _cab.Add(String.Format("{0}{1}", Space(m_space + 5), ""))
            ''_cab.Add(New String(""))

            Dim y As Integer
            For y = 0 To 2
                Dim _cad1 As String = "".PadRight(_lon1, " ")
                Dim _cad2 As String = "".PadRight(_lon2, " ")
                If x_lista1.Count > y Then _cad1 = x_lista1(y).PadRight(_lon1, " ")
                If x_lista2.Count > y Then _cad2 = x_lista2(y).PadRight(_lon2, " ")
                _cab.Add(String.Format("{0}{1}{2}{3}", Space(m_space + 9), _cad1, Space(11), _cad2))
            Next

            ACUtilitarios.genTexto(_cab, m_cabecera)
            _cab = New List(Of String)
            _cab.Add(New String(""))
            _cab.Add(String.Format("{0}{1}{2}{3}", Space(m_space + 12), m_guiaventa.GTRAN_DesEntidadDestinatario.PadRight(71).Substring(0, 71), Space(10),
                                   m_guiaventa.GTRAN_DescripcionVehiculo))
            _cab.Add(String.Format("{0}{1}{2}{3}", Space(m_space + 10), m_guiaventa.ENTID_CodigoDestinatario.PadRight(64, " "), Space(20),
                                   m_guiaventa.GTRAN_CertificadosVehiculo))

            _cab.Add(String.Format("{0}{1} ", Space(m_space + 92), m_guiaventa.CONDU_Licencia))

            ACUtilitarios.genTexto(_cab, m_cabeceradet)

            ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabeceradet, 4)
            '' Generar Detalle
            Dim x_fila As Integer = 0
            Dim x_peso As Decimal = 0
            For Each item As ETRAN_GuiasTransportistaDetalles In m_guiaventa.ListETRAN_GuiasTransportistaDetalles
                x_peso += item.GTDET_Cantidad
                m_cuerpo.Append(String.Format("{0}{1}{2}{3}{4}", Space(m_space) _
                                              , ACUtilitarios.Alinear(ACAlineacion.Derecha, item.GTDET_Cantidad.ToString("###,##0.00"), 11) _
                                              , ACUtilitarios.Alinear(ACAlineacion.Centro, item.GTDET_Unidad, 17) _
                                              , item.GTDET_Descripcion.PadRight(75, " ").Substring(0, 75) _
                                              , vbNewLine))

                x_fila += 1
            Next
            ', ACUtilitarios.Alinear(ACAlineacion.Derecha, (item.GUIRD_PesoUnitario * item.GUIRD_Cantidad).ToString("###,##0.00 Kg."), 17) _
            ACUtilitarios.ImprimeLinBlanco(m_cuerpo, x_filas - 4 - (x_fila - 1))
            ACUtilitarios.ImprimeLinBlanco(m_cuerpo, 3)



            ''cuerpo especial
            Dim _cuerpo_es As New List(Of String)
            _cuerpo_es.Add(String.Format("{0}{1}", Space(m_space + 5), ""))
            _cuerpo_es.Add(String.Format("{0}{1}{2}", Space(m_space + 30), "Nro. Pedido: ", m_guiaventa.GTRAN_NroPedido))
            _cuerpo_es.Add(String.Format("{0}{1}{2}", Space(m_space + 30), "Chofer     : ", m_guiaventa.ENTID_Conductor))
            _cuerpo_es.Add(String.Format("{0}{1}", Space(m_space + 5), ""))
            _cuerpo_es.Add(String.Format("{0}{1}", Space(m_space + 5), ""))
            _cuerpo_es.Add(String.Format("{0}{1}", Space(m_space + 5), ""))
            _cuerpo_es.Add(String.Format("{0}{1}", Space(m_space + 5), ""))
            _cuerpo_es.Add(New String(""))

            ACUtilitarios.genTexto(_cuerpo_es, m_cuerpo_esp)


            '' Generar Pie de Pagina
            Dim _pie As New List(Of String)



            _pie.Add(String.Format("{0}{1}{2} Kg.", Space(m_space + 7), m_guiaventa.ENTID_Transportista.PadRight(75, " "), m_guiaventa.GTRAN_PesoTotal.ToString("###,##0.0000").PadLeft(25, " ")))
            _pie.Add(String.Format("{0}{1}", Space(m_space + 5), m_guiaventa.ENTID_CodigoTransportista))
            _pie.Add(String.Format("{0}{1}", Space(m_space + 95), DateTime.Now.ToString("hh:mm:ss tt")))
            _pie.Add(New String(" "))
            If IsNothing(m_guiaventa.DocVenta) Then
                _pie.Add(String.Format("{0}{1}", Space(80), "3"))
                '_pie.Add(String.Format("{0}{1}{2}{3}{4}{5}", Space(m_space + 5), m_guiaventa.DocComprobante.PadRight(15, " "), Space(60), " ", _
                '         Space(10), m_guiaventa.GTRAN_UsrCrea))

                _pie.Add(String.Format("{0}{1}{2}{3}{4}{5}{6}{7}", Space(m_space + 4), m_guiaventa.TipoComprobante.PadRight(10, " "), Space(m_space + 11), m_guiaventa.GTRAN_NroComprobantePago.PadRight(10, " ").Substring(2, 3) + "-" + m_guiaventa.GTRAN_NroComprobantePago.PadRight(10, " ").Substring(5, 7), Space(48), " ", _
                Space(10), m_guiaventa.ENTID_Codigo))


                '_pie.Add(String.Format("{0}{1}", Space(m_space + 95), m_guiaventa.ENTID_CodUsuario))
            Else
                _pie.Add(String.Format("{0}{1}", Space(77), m_guiaventa.TIPOS_CodMotivoTraslado))
                _pie.Add(String.Format("{0}{1}{2}{3}{4}{5}", Space(m_space + 5), m_guiaventa.DocVenta.PadRight(15, " "), Space(60), " ", _
                         Space(10), m_guiaventa.ENTID_Codigo))
                '_pie.Add(String.Format("{0}{1}", Space(m_space + 95), m_guiaventa.ENTID_CodUsuario))
            End If




            ACUtilitarios.genTexto(_pie, m_pie)

            '' Generar Documento Final
            Dim _texto As New StringBuilder
            _texto.Append(m_cabecera)
            _texto.Append(m_cuerpo)
            _texto.Append(m_cuerpo_esp)
            _texto.Append(m_pie)
            SetPrinter(m_cabecera, ACInterEspaciado.Seis)
            SetPrinter(m_cabeceradet, ACInterEspaciado.Ocho)
            SetPrinter(m_cuerpo, ACInterEspaciado.Seis)
            SetPrinter(m_cuerpo_esp, ACInterEspaciado.Seis)
            SetPrinter(m_pie, ACInterEspaciado.Ocho, 19)
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.SaltoPagina)

            '' Imprimir
            'ACFramework.ACUtilitarios.ImprimeLinBlanco(m_cabecera, 3)
            'ACImpresion.ACImprimir.Inicializar(m_printername)
            'ACImpresion.ACImprimir.SendStringToPrinter(Chr(18))
            'ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.NumeroLineas(68))
            'ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Fuente(ACFuentes.Draft))
            'ACImpresion.ACImprimir.SendStringToPrinter(String.Format("{0}{1}", Chr(27), Chr(15)))
            'ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.FuenteDraft(ACDrafts.Draft10PCI))
            'ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Condensado(False))
            'ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Interespaciado(ACInterEspaciado.Seis))
            'ACImprimir.SendStringToPrinter(m_cabecera.ToString())

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Sub SetPrinter(ByVal x_file As StringBuilder, ByVal x_interlineado As ACInterEspaciado, Optional ByVal x_lineas As Integer = 10)
        Try
            ACImpresion.ACImprimir.Inicializar(m_printername)
            ACImpresion.ACImprimir.SendStringToPrinter(Chr(18))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.NumeroLineas(x_lineas))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Fuente(ACFuentes.Draft))
            ACImpresion.ACImprimir.SendStringToPrinter(String.Format("{0}{1}", Chr(27), Chr(15)))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.FuenteDraft(ACDrafts.Draft10PCI))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Condensado(False))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Interespaciado(x_interlineado))
            ACImprimir.SendStringToPrinter(x_file.ToString())
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region " Cotizaciones "

    Private Sub getDatos(ByRef m_cotizacion As ETRAN_Cotizaciones, ByRef _dsdatos As DSCotizacionAC)
        Try
            Dim _dr As DataRow = _dsdatos.DTTRAN_Cotizacion.NewRow()
            _dr("COTIZ_Codigo") = m_cotizacion.COTIZ_Codigo
            _dr("ENTID_RazonSocial") = m_cotizacion.ENTID_Cliente
            _dr("ENTID_Direccion") = m_cotizacion.ENTID_Direccion
            _dr("COTIZ_FechaDocumento") = m_cotizacion.COTIZ_FechaFlete.ToString("dd'/'MM'/'yyyy")
            _dr("Atencion") = ""
            _dr("Tel-Fax") = ""
            _dr("RUTAS_Nombre") = m_cotizacion.RUTAS_Nombre
            If (m_cotizacion.COTIZ_TotalPagar = 0) Then
                _dr("COTIZ_TotalVenta") = m_cotizacion.COTIZ_Monto.ToString("#.00")
            Else
                _dr("COTIZ_TotalVenta") = m_cotizacion.COTIZ_TotalPagar.ToString("#.00")
            End If
            _dr("TIPOS_TipoMoneda") = m_cotizacion.TIPOS_TipoMoneda
            _dr("TIPOS_TipoDocumento") = m_cotizacion.TIPOS_TipoDocumento
            _dr("TIPOS_CondicionPago") = m_cotizacion.TIPOS_CondicionPago
            _dr("COTIZ_Observaciones") = m_cotizacion.COTIZ_Observaciones
            _dr("Cotizador") = GApp.EUsuarioEntidad.ENTID_Nombres

            _dsdatos.DTTRAN_Cotizacion.Rows.Add(_dr)
            Dim x_dr As DataRow = _dsdatos.DTTRAN_CotizacionDetalle.NewRow()
            If IsNothing(m_cotizacion.ListTRAN_CotizacionesDetalle) Then
                x_dr("COTIZ_Codigo") = m_cotizacion.COTIZ_Codigo
                x_dr("COTDT_Item") = "1"
                x_dr("COTDT_Unidad") = "T.M."
                x_dr("COTDT_Detalle") = m_cotizacion.COTIZ_Carga
                x_dr("COTDT_CostoUnitario") = (m_cotizacion.COTIZ_MontoPorTM.ToString("#.00") / 1.18)
                x_dr("COTDT_PesoUnitario") = m_cotizacion.COTIZ_PesoEnTM.ToString("#.0000")
                x_dr("COTDT_PrecioUnitario") = m_cotizacion.COTIZ_MontoPorTM.ToString("#.00")
                x_dr("COTDT_Cantidad") = m_cotizacion.COTIZ_PesoEnTM.ToString("#.0000")
                x_dr("COTDT_SubImporteVenta") = m_cotizacion.COTIZ_Monto.ToString("#.00")
                _dsdatos.DTTRAN_CotizacionDetalle.Rows.Add(x_dr)

            Else
                For Each Item As ETRAN_CotizacionesDetalle In m_cotizacion.ListTRAN_CotizacionesDetalle

                    x_dr("COTIZ_Codigo") = Item.COTIZ_Codigo
                    x_dr("COTDT_Item") = Item.COTDT_Item
                    x_dr("COTDT_Unidad") = Item.COTDT_Unidad
                    x_dr("COTDT_Detalle") = Item.COTDT_Detalle
                    x_dr("COTDT_CostoUnitario") = Item.COTDT_CostoUnitario.ToString("#.00")
                    x_dr("COTDT_PesoUnitario") = Item.COTDT_PesoUnitario.ToString("#.0000")
                    x_dr("COTDT_PrecioUnitario") = Item.COTDT_PrecioUnitario.ToString("#.00")
                    x_dr("COTDT_Cantidad") = Item.COTDT_Cantidad.ToString("#.0000")
                    x_dr("COTDT_SubImporteVenta") = Item.COTDT_SubImporteVenta.ToString("#.00")
                    _dsdatos.DTTRAN_CotizacionDetalle.Rows.Add(x_dr)
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function Imprimir(ByVal m_cotizacion As ETRAN_Cotizaciones, ByVal strReportPath As String) As Boolean
        Try
            Dim _dsdatos As New DSCotizacionAC
            getDatos(m_cotizacion, _dsdatos)

            Dim Informe As New ReportDocument
            Informe.Load(strReportPath)
            Informe.SetDataSource(_dsdatos)

            Informe.PrintOptions.PrinterName = m_printername
            Informe.PrintOptions.PaperSize = [Shared].PaperSize.PaperA5
            Informe.PrintOptions.PaperSource = [Shared].PaperSource.Auto
            Informe.PrintOptions.PaperOrientation = [Shared].PaperOrientation.Landscape

            Informe.PrintToPrinter(1, True, 1, 1)

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Visualizar(ByRef m_percep As ETRAN_Cotizaciones, ByVal strReportPath As String) As Boolean
        Try
            Dim _dsdatos As New DSCotizacionAC()
            getDatos(m_percep, _dsdatos)

            Dim Informe As New ReportDocument
            Informe.Load(strReportPath)
            Informe.SetDataSource(_dsdatos)

            Dim reporte As New RReportView(Informe)
            reporte.ShowDialog()

            Informe.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


#End Region

#Region "Consumo AdBlue"

    Public Function Print_ConsumoAdBlue(ByVal x_comco_id As Long, ByVal printd As PrintDocument) As Boolean
        Try
            Dim m_recadblue As New ETRAN_CombustibleConsumo
            If Get_REcCAdblue(m_recadblue, x_comco_id) Then
                If ImprimirCAdBlue(m_recadblue, False, printd) Then
                    Dim _recadblue As New BTRAN_CombustibleConsumo
                    _recadblue.TRAN_CombustibleConsumo = m_recadblue
                    ' _recadblue.TRAN_CombustibleConsumo.RECIB_Impresa = True
                    '_recadblue.TRAN_CombustibleConsumo.RECIB_Impresiones += 1
                    '_recadblue.TRAN_CombustibleConsumo.Instanciar(ACEInstancia.Modificado)
                    '--Return _recadblue.Guardar(GApp.Usuario)
                    Return True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Function Get_REcCAdblue(ByRef x_etran_consumoadblue As ETRAN_CombustibleConsumo, ByVal x_comco_id As Long)
        Try
            Dim _consumoAdBlue As New BTRAN_CombustibleConsumo
            Return _consumoAdBlue.TRAN_ObtenerConsumoAdBlue(x_etran_consumoadblue, x_comco_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function ImprimirCAdBlue(ByVal m_tran_consumoadblue As ETRAN_CombustibleConsumo, ByVal x_viaje As Boolean, ByVal printd As PrintDocument) As Boolean
        Try
            Dim _left As Integer = 0
            Dim _largo As Integer = 41 '85
            Dim _cabecera As New StringBuilder
            'Dim m_space As Integer = 0
            Dim m_cabecera As New StringBuilder
            Dim m_observaciones As New StringBuilder
            Dim m_cuerpo As New StringBuilder
            Dim m_pie As New StringBuilder


            ACUtilitarios.ImprimeLinBlanco(_cabecera, 1)
            _cabecera.Append(ACUtilitarios.Alinear(ACUtilitarios.ACAlineacion.Centro, GApp.EEmpresa.EMPR_Desc, _left + _largo) & vbNewLine)
            _cabecera.Append(ACUtilitarios.Alinear(ACUtilitarios.ACAlineacion.Centro, "CONSUMO ADBLUE", _left + _largo) & vbNewLine) '"Recibo de " & 
            _cabecera.Append(ACUtilitarios.Alinear(ACUtilitarios.ACAlineacion.Centro, String.Format("Codigo: {0}", m_tran_consumoadblue.COMCO_CodigoVale), _left + _largo))



            Dim _texto As New StringBuilder
            _texto.Append(String.Format("{0}{1}{2}", vbNewLine, Space(_left), ACUtilitarios.getLine(_largo, False, False)))
            '_texto.Append(String.Format("{0}{1}Importe: {2}", vbNewLine, Space(20 - 6), _
            '                            'String.Format("{0} {1:#,###,##0.00}", m_tran_recibos.TIPOS_TipoMoneda, m_tran_recibos.RECIB_Monto).ToString.PadLeft(15, " ")))
            _texto.Append(String.Format("{0}{1}Fecha: {2}", vbNewLine, Space(_left), m_tran_consumoadblue.COMCO_Fecha))

            Dim x_lista2 As New List(Of String)

            Dim i2 As Boolean = True
            x_lista2 = New List(Of String)
            ACUtilitarios.GetTextoLines(m_tran_consumoadblue.ENTID_CodigoConductor, _left + _largo - 16, x_lista2)
            i2 = True
            For Each item2 As String In x_lista2
                If i2 Then
                    _texto.Append(String.Format("{0}{1}Conductor : {2}", vbNewLine, Space(_left), item2)) : i2 = False
                Else
                    _texto.Append(String.Format("{0}{1}{2}", vbNewLine, Space(_left + 16), item2))
                End If
            Next

            _texto.Append(String.Format("{0}{1}PLACA: {2}", vbNewLine, Space(_left), m_tran_consumoadblue.VEHIC_Placa))



            Dim x_lista1 As New List(Of String)

            Dim i As Boolean = True

            x_lista1 = New List(Of String)
            ACUtilitarios.GetTextoLines(m_tran_consumoadblue.VIAJE_Descripcion, _left + _largo - 16, x_lista1)
            i = True
            For Each item As String In x_lista1
                If i Then
                    _texto.Append(String.Format("{0}{1}VIAJE:    {2}", vbNewLine, Space(_left), item)) : i = False
                Else
                    _texto.Append(String.Format("{0}{1}{2}", vbNewLine, Space(_left + 16), item))
                End If
            Next

            _texto.Append(String.Format("{0}{1}GALONES: {2}", vbNewLine, Space(_left), m_tran_consumoadblue.COMCO_GalonesConsumidos))
            _texto.Append(String.Format("{0}{1}", vbNewLine, "-----------------------------------------"))
            _texto.Append(String.Format("{0}{1}Documento: {2}", vbNewLine, Space(_left), m_tran_consumoadblue.DOCUS_Codigo))
            If IsNothing(m_tran_consumoadblue.ENTID_RazonSocial) Then
                _texto.Append(String.Format("{0}{1}Fecha Doc: {2}{3}", vbNewLine, Space(_left), "-", Space(20)))
            Else
                _texto.Append(String.Format("{0}{1}Fecha Doc: {2}{3}", vbNewLine, Space(_left), m_tran_consumoadblue.COMCO_Fecha.ToString("dd/MM/yyyy"), Space(20)))
            End If
            _texto.Append(String.Format("{0}{1}RUC: {2}{3}", vbNewLine, Space(_left), m_tran_consumoadblue.ENTID_CodigoProveedor, Space(20)))
            _texto.Append(String.Format("{0}{1}PROVEEDOR: {2}{3}", vbNewLine, Space(_left), m_tran_consumoadblue.ENTID_RazonSocial, Space(20)))
            _texto.Append(String.Format("{0}{1}IMPORTE: {2}", vbNewLine, Space(_left), m_tran_consumoadblue.COMCO_Total))
            '_texto.Append(String.Format("{0}{1}Documento.: {2}", vbNewLine, Space(_left), m_tran_recibos.RECIB_Documento))
            '_texto.Append(String.Format("{0}{1}Proveedor.: {2}", vbNewLine, Space(_left), m_tran_recibos.ENTID_CodigoProveedor))
            '_texto.Append(String.Format("{0}{1}Razón Social.: {2}", vbNewLine, Space(_left), m_tran_recibos.ENTID_RazonSocialProveedor))
            _texto.Append(String.Format("{0}{1}", vbNewLine, "-----------------------------------------"))


            _texto.Append(New String(" "))
            _texto.Append(New String(" "))

            _texto.Append(String.Format("{0}{1}Usr. Crea.: {2}", vbNewLine, Space(_left), m_tran_consumoadblue.COMCO_UsrCrea))
            _texto.Append(String.Format("{0}{1}Fec. Crea.: {2:dd/MM/yyyy HH:MM}", vbNewLine, Space(_left), m_tran_consumoadblue.COMCO_FecCrea))
            ACUtilitarios.ImprimeLinBlanco(_texto, 6)
            _texto.Append(New String(" "))

            _texto.Append(String.Format("{0}{1} ---------------- {2}", vbNewLine, Space(_left), "      ----------------"))
            _texto.Append(String.Format("{0}{1} AUTORIZADO POR {2}", vbNewLine, Space(_left), "        FIRMA CONDUCTOR"))




            Dim _cadena As New StringBuilder
            _cadena.Append(_cabecera)
            _cadena.Append(_texto)

            'SetPrinterTitulo(_cabecera, ACInterEspaciado.Seis)
            'SetPrinterNormal(_texto, ACInterEspaciado.Seis)

            '_texto.Append(String.Format("{0}{1}", vbNewLine, Space(_left)))


            'm_pie = New StringBuilder()
            'ACUtilitarios.genTexto(_pie, m_pie)
            'ACUtilitarios.genTexto(_pie1, m_pie1)
            'ACUtilitarios.genTexto(_pieespacio, m_pieespacios)


            globales_.cabecera = _cabecera.ToString()
            globales_.cuerpo = _texto.ToString()
            ' globales_.pie = _pie.ToString()

            printd.PrinterSettings.PrinterName = m_printername

            Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", 1000, 2600)
            printd.DefaultPageSettings.PaperSize = pkCustomSize1
            printd.Print()




            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " Cargar Datos "
    Private Function CargarDocsventa(ByVal m_docventa As EVENT_DocsVenta, ByVal x_filas As Integer, ByRef dtDatos As DSFactura) As Boolean
        Dim _cad As String = "{0} {1}"
        Try
            Dim _dr As DataRow = dtDatos.DTDocsVenta.NewRow()
            _dr("DOCVE_Codigo") = m_docventa.DOCVE_Codigo
            _dr("ENTID_NroDocumento") = m_docventa.ENTID_NroDocumento
            _dr("DOCVE_DescripcionCliente") = m_docventa.DOCVE_DescripcionCliente
            _dr("DOCVE_DireccionCliente") = m_docventa.DOCVE_DireccionCliente
            _dr("DOCVE_ImporteVenta") = String.Format(_cad, m_docventa.TIPOS_TipoMoneda.Trim(), m_docventa.DOCVE_ImporteVenta.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)))
            _dr("DOCVE_ImporteIgv") = String.Format(_cad, m_docventa.TIPOS_TipoMoneda.Trim(), m_docventa.DOCVE_ImporteIgv.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)))
            _dr("DOCVE_TotalPagar") = String.Format(_cad, m_docventa.TIPOS_TipoMoneda.Trim(), m_docventa.DOCVE_TotalPagar.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)).ToString())
            _dr("DOCVE_FechaDocumento") = m_docventa.DOCVE_FechaDocumento.ToString("dd/MM/yyyy")
            _dr("NroFactura") = m_docventa.Documento
            _dr("Dia") = m_docventa.DOCVE_FechaDocumento.Day.ToString("00")
            _dr("Mes") = MonthName(m_docventa.DOCVE_FechaDocumento.Month).ToUpper()
            _dr("Anho") = m_docventa.DOCVE_FechaDocumento.Year.ToString("0000")
            _dr("NotaPie") = m_docventa.DOCVE_NotaPie
            _dr("Guias") = m_docventa.DOCVE_Guias

            Dim _filter As New ACFiltrador(Of ETipos)
            _filter.ACFiltro = String.Format("TIPOS_Codigo={0}", m_docventa.TIPOS_CodTipoMoneda)
            _filter.ACFiltrar(Colecciones.Tipos)
            If _filter.ACListaFiltrada.Count > 0 Then
                _dr("TextoTotal") = ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalPagar, _filter.ACListaFiltrada(0).TIPOS_Descripcion)
            Else
                _dr("TextoTotal") = ACUtilitarios.NumPalabra(m_docventa.DOCVE_TotalPagar, "NUEVOS SOLES")
            End If

            dtDatos.DTDocsVenta.Rows.Add(_dr)

            For Each Item As EVENT_DocsVentaDetalle In m_docventa.ListVENT_DocsVentaDetalle
                Dim x_dr As DataRow = dtDatos.DTDocsVentaDetalle.NewRow()
                x_dr("DOCVE_Codigo") = Item.DOCVE_Codigo
                x_dr("DOCVD_Item") = Item.DOCVD_Item
                x_dr("DOCVD_Unidad") = Item.DOCVD_Unidad
                x_dr("DOCVD_Detalle") = Item.DOCVD_Detalle
                x_dr("DOCVD_PrecioUnitario") = String.Format(_cad, m_docventa.TIPOS_TipoMoneda.Trim(), Item.DOCVD_PrecioUnitario.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)))
                x_dr("DOCVD_SubImporteVenta") = String.Format(_cad, m_docventa.TIPOS_TipoMoneda.Trim(), Item.DOCVD_SubImporteVenta.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)))
                x_dr("DOCVD_Cantidad") = Item.DOCVD_Cantidad.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo3d))
                dtDatos.DTDocsVentaDetalle.Rows.Add(x_dr)
            Next

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region " Obtener Datos "

    Private Function Get_GuiaTransportista(ByRef m_guia As ETRAN_GuiasTransportista, ByVal x_gtran_codigo As String) As Boolean
        Try
            Dim m_bGenerarGuias As New ACBTransporte.BGenerarGuias()
            If m_bGenerarGuias.TRAN_GUIASS_ObtenerGuias(x_gtran_codigo) Then
                Dim m_bdetaguia As New BTRAN_GuiasTransportistaDetalles()
                Dim _detwhere As New Hashtable()
                _detwhere.Add("GTRAN_Codigo", New ACWhere(x_gtran_codigo, ACWhere.TipoWhere.Igual))
                If m_bdetaguia.CargarTodos(_detwhere) Then
                    m_bGenerarGuias.TRAN_GuiasTransportista.ListETRAN_GuiasTransportistaDetalles = m_bdetaguia.ListTRAN_GuiasTransportistaDetalles
                    m_guia = m_bGenerarGuias.TRAN_GuiasTransportista
                    Return True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function Get_FacturaTransportista(ByRef m_docsventa As EVENT_DocsVenta, ByVal x_docve_codigo As String) As Boolean
        Try
            'Dim m_bGenerarDocs As New BGenerarDocsVenta(GApp.PuntoVenta, GApp.Periodo, GApp.Zona, GApp.Sucursal)
            'If m_bGenerarDocs.getDocsVenta(x_docve_codigo) Then
            '   m_docsventa = m_bGenerarDocs.VENT_DocsVenta
            '   Return True
            'End If
            Dim _btran As New ACBVentas.BReporte(GApp.PuntoVenta, GApp.Periodo, GApp.Sucursal)
            If _btran.REPOS_Fac(x_docve_codigo) Then
                m_docsventa = _btran.VENT_DocsVenta
                Return True

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function Get_Cotizacion(ByRef x_etran_cotizaciones As ETRAN_Cotizaciones, ByVal x_cotiz_codigo As String) As Boolean
        Try
            Dim m_btran_cotizaciones As New BTRAN_Cotizaciones
            If m_btran_cotizaciones.Cargar(x_cotiz_codigo, True) Then
                x_etran_cotizaciones = m_btran_cotizaciones.TRAN_Cotizaciones
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Function Get_Recibo(ByRef x_etran_recibos As ETRAN_Recibos, ByVal x_recib_codigo As String)
        Try
            Dim _recibo As New BTRAN_Recibos
            Return _recibo.TRAN_ObtenerRecibo(x_etran_recibos, x_recib_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region " Utiles "
    Private Sub SetPrinterTitulo(ByVal x_file As StringBuilder, ByVal x_interlineado As ACInterEspaciado, Optional ByVal x_lineas As Integer = 3)
        Try
            ACImpresion.ACImprimir.Inicializar(m_printername)
            ACImpresion.ACImprimir.SendStringToPrinter(Chr(18))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.NumeroLineas(x_lineas))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Fuente(ACFuentes.Courier))
            'ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Negrita(True))
            ACImpresion.ACImprimir.SendStringToPrinter(String.Format("{0}{1}", Chr(27), Chr(15)))
            'ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.FuenteDraft(ACDrafts.Draft10PCI))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Condensado(False))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Interespaciado(x_interlineado))
            ACImprimir.SendStringToPrinter(x_file.ToString())
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetPrinterNormal(ByVal x_file As StringBuilder, ByVal x_interlineado As ACInterEspaciado, Optional ByVal x_lineas As Integer = 78)
        Try
            ACImpresion.ACImprimir.Inicializar(m_printername)
            ACImpresion.ACImprimir.SendStringToPrinter(Chr(18))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.NumeroLineas(x_lineas))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Negrita(False))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Fuente(ACFuentes.Draft))
            ACImpresion.ACImprimir.SendStringToPrinter(String.Format("{0}{1}", Chr(27), Chr(15)))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.FuenteDraft(ACDrafts.Draft10PCI))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Condensado(False))
            ACImpresion.ACImprimir.SendStringToPrinter(ACFuncImpresion.Interespaciado(x_interlineado))
            ACImprimir.SendStringToPrinter(x_file.ToString())
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region
#End Region

#Region " Metodos de Controles"

#End Region

    Private Function Imprimir(ByVal m_tran_recibos As ETRAN_Recibos, ByVal x_viaje As Boolean, ByVal printd As PrintDocument) As Boolean
        Try
            Dim _left As Integer = 0
            Dim _largo As Integer = 41 '85
            Dim _cabecera As New StringBuilder

            Dim m_cabecera As New StringBuilder
            Dim m_observaciones As New StringBuilder
            Dim m_cuerpo As New StringBuilder
            Dim m_pie As New StringBuilder


            ACUtilitarios.ImprimeLinBlanco(_cabecera, 1)
            _cabecera.Append(ACUtilitarios.Alinear(ACUtilitarios.ACAlineacion.Centro, GApp.EEmpresa.EMPR_Desc, _left + _largo) & vbNewLine)
            _cabecera.Append(ACUtilitarios.Alinear(ACUtilitarios.ACAlineacion.Centro, m_tran_recibos.TIPOS_TipoRecibo, _left + _largo) & vbNewLine) '"Recibo de " & 
            _cabecera.Append(ACUtilitarios.Alinear(ACUtilitarios.ACAlineacion.Centro, String.Format("Codigo: {0}", m_tran_recibos.RECIB_Codigo), _left + _largo))



            Dim _texto As New StringBuilder
            _texto.Append(String.Format("{0}{1}{2}", vbNewLine, Space(_left), ACUtilitarios.getLine(_largo, False, False)))
            _texto.Append(String.Format("{0}{1}Importe: {2}", vbNewLine, Space(20 - 6), _
                                        String.Format("{0} {1:#,###,##0.00}", m_tran_recibos.TIPOS_TipoMoneda, m_tran_recibos.RECIB_Monto).ToString.PadLeft(15, " ")))
            _texto.Append(String.Format("{0}{1}Recibi De: {2}", vbNewLine, Space(_left), m_tran_recibos.RECIB_De))

            Dim x_lista1 As New List(Of String)
            x_lista1 = New List(Of String)
            ACUtilitarios.GetTextoLines(ACUtilitarios.ACConvertirNumeroALetras(m_tran_recibos.RECIB_Monto, m_tran_recibos.TIPOS_TipoMoneda, ""), _left + _largo - 16, x_lista1)
            Dim i As Boolean = True
            For Each item As String In x_lista1
                If i Then
                    _texto.Append(String.Format("{0}{1}La Cantidad de: {2}", vbNewLine, Space(_left), item)) : i = False
                Else
                    _texto.Append(String.Format("{0}{1}{2}", vbNewLine, Space(_left + 16), item))
                End If
            Next

            x_lista1 = New List(Of String)
            ACUtilitarios.GetTextoLines(m_tran_recibos.RECIB_Concepto, _left + _largo - 16, x_lista1)
            i = True
            For Each item As String In x_lista1
                If i Then
                    _texto.Append(String.Format("{0}{1}Concepto:       {2}", vbNewLine, Space(_left), item)) : i = False
                Else
                    _texto.Append(String.Format("{0}{1}{2}", vbNewLine, Space(_left + 16), item))
                End If
            Next

            _texto.Append(String.Format("{0}{1}Fecha: {2:dd/MM/yyyy}", vbNewLine, Space(_left), m_tran_recibos.RECIB_Fecha))
            _texto.Append(String.Format("{0}{1}Nombre: {2}", vbNewLine, Space(_left), m_tran_recibos.RECIB_Nombre))
            _texto.Append(String.Format("{0}{1}Dirección: {2}{3}", vbNewLine, Space(_left), m_tran_recibos.RECIB_Direccion, Space(20)))
            _texto.Append(String.Format("{0}{1}D.N.I.: {2}", vbNewLine, Space(_left), ".")) 'm_tran_recibos.DOCUS_Codigo))
            '_texto.Append(String.Format("{0}{1}Documento.: {2}", vbNewLine, Space(_left), m_tran_recibos.RECIB_Documento))
            '_texto.Append(String.Format("{0}{1}Proveedor.: {2}", vbNewLine, Space(_left), m_tran_recibos.ENTID_CodigoProveedor))
            '_texto.Append(String.Format("{0}{1}Razón Social.: {2}", vbNewLine, Space(_left), m_tran_recibos.ENTID_RazonSocialProveedor))


            _texto.Append(String.Format("{0}{1}{2}", vbNewLine, Space(_left), ACUtilitarios.getLine(_largo, False, False)))

            _texto.Append(String.Format("{0}{1}Usr. Crea.: {2}", vbNewLine, Space(_left), m_tran_recibos.RECIB_UsrCrea))
            _texto.Append(String.Format("{0}{1}Fec. Crea.: {2:dd/MM/yyyy HH:MM}", vbNewLine, Space(_left), m_tran_recibos.RECIB_FecCrea))
            ACUtilitarios.ImprimeLinBlanco(_texto, 2)
            Dim _cadena As New StringBuilder
            _cadena.Append(_cabecera)
            _cadena.Append(_texto)

            'SetPrinterTitulo(_cabecera, ACInterEspaciado.Seis)
            'SetPrinterNormal(_texto, ACInterEspaciado.Seis)

            '_texto.Append(String.Format("{0}{1}", vbNewLine, Space(_left)))


            'm_pie = New StringBuilder()
            'ACUtilitarios.genTexto(_pie, m_pie)
            'ACUtilitarios.genTexto(_pie1, m_pie1)
            'ACUtilitarios.genTexto(_pieespacio, m_pieespacios)


            globales_.cabecera = _cabecera.ToString()
            globales_.cuerpo = _texto.ToString()
            ' globales_.pie = _pie.ToString()

            printd.PrinterSettings.PrinterName = m_printername

            Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", 1000, 2600)
            printd.DefaultPageSettings.PaperSize = pkCustomSize1
            printd.Print()




            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
