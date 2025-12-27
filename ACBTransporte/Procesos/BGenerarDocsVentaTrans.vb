Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte
Imports System.Configuration
Imports ACEVentas
Imports ACBVentas
Imports ACFramework

Imports DAConexion
Imports ACBLogistica

Public Class BGenerarDocsVentaTrans

#Region " Variables "

    Private m_dtGenerarDocsVentaTrans As DataTable

    Private m_dsGenerarDocsVentaTrans As DataSet
    Private Shared d_generardocsventatrans As DGenerarDocsVentaTrans = Nothing

    Private m_event_docsventa As EVENT_DocsVenta
    Private m_listvent_docsventa As List(Of EVENT_DocsVenta)
    Private m_tran_cotizaciones As ETRAN_Cotizaciones
    Private m_tipocambio As ETipoCambio
    Private m_listVENT_PVentDocumento As List(Of EVENT_PVentDocumento)
    Private m_listTRAN_ViajesVentas As List(Of ETRAN_ViajesVentas)
    Private m_pvent_id As Long
    Private m_periodo As String
    Private m_zonas_codigo As String
    Private m_sucur_id As Short

    Private m_bvent_docsVenta As BVENT_DocsVenta
#End Region

#Region " Constructores "

    Public Sub New(ByVal x_pvent_id As Long, ByVal x_periodo As String, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short)
        m_pvent_id = x_pvent_id
        m_periodo = x_periodo
        m_zonas_codigo = x_zonas_codigo
        m_sucur_id = x_sucur_id
        d_generardocsventatrans = New DGenerarDocsVentaTrans
    End Sub

#End Region

#Region " Propiedades "

    Public Property DTGenerarDocsVentaTrans() As DataTable
        Get
            Return m_dtGenerarDocsVentaTrans
        End Get
        Set(ByVal value As DataTable)
            m_dtGenerarDocsVentaTrans = value
        End Set
    End Property

    Public Property DSGenerarDocsVentaTrans() As DataSet
        Get
            Return m_dsGenerarDocsVentaTrans
        End Get
        Set(ByVal value As DataSet)
            m_dsGenerarDocsVentaTrans = value
        End Set
    End Property

    Public Property VENT_DocsVenta() As EVENT_DocsVenta
        Get
            Return m_event_docsventa
        End Get
        Set(ByVal value As EVENT_DocsVenta)
            m_event_docsventa = value
        End Set
    End Property

    Public Property ListVENT_PVentDocumento() As List(Of EVENT_PVentDocumento)
        Get
            Return m_listVENT_PVentDocumento
        End Get
        Set(ByVal value As List(Of EVENT_PVentDocumento))
            m_listVENT_PVentDocumento = value
        End Set
    End Property

    Public Property TipoCambio() As ETipoCambio
        Get
            Return m_tipocambio
        End Get
        Set(ByVal value As ETipoCambio)
            m_tipocambio = value
        End Set
    End Property

    Public Property ListTRAN_ViajesVentas() As List(Of ETRAN_ViajesVentas)
        Get
            Return m_listTRAN_ViajesVentas
        End Get
        Set(ByVal value As List(Of ETRAN_ViajesVentas))
            m_listTRAN_ViajesVentas = value
        End Set
    End Property

    Public Property TRAN_Cotizaciones() As ETRAN_Cotizaciones
        Get
            Return m_tran_cotizaciones
        End Get
        Set(ByVal value As ETRAN_Cotizaciones)
            m_tran_cotizaciones = value
        End Set
    End Property

    Public Property ListVENT_DocsVenta() As List(Of EVENT_DocsVenta)
        Get
            Return m_listvent_docsventa
        End Get
        Set(ByVal value As List(Of EVENT_DocsVenta))
            m_listvent_docsventa = value
        End Set
    End Property

#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "
    ' <summary>
    ' Genera el correlativo segun el documento de venta y la serie
    ' </summary>
    ' <param name="x_docve_serie">Serie del documento</param>
    ' <param name="x_tipos_codtipodocumento">Tipo de documento/comprobante de venta</param>
    ' <returns>Retorna el numero correspondiente al ultimo generado</returns>
    ' <remarks></remarks>
    Public Function getNumero(ByVal x_docve_serie As String, ByVal x_tipos_codtipodocumento As String) As Integer
        Try
            Dim m_generardocsventa As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
            Return m_generardocsventa.getNumero(x_docve_serie, x_tipos_codtipodocumento)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetSeries(ByVal x_zonas_codigo As String, ByVal x_sucur_id As Integer, ByVal x_pvent_id As Integer, ByVal x_tipo_documento As String, ByVal x_aplicacion As String) As Boolean
        Try
            m_listVENT_PVentDocumento = New List(Of EVENT_PVentDocumento)()
            Dim m_bgenerardocsventa As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
            If m_bgenerardocsventa.GetSeries(x_aplicacion, x_zonas_codigo, x_sucur_id, x_pvent_id, x_tipo_documento) Then
                m_listVENT_PVentDocumento = New List(Of EVENT_PVentDocumento)(m_bgenerardocsventa.ListVENT_PVentDocumento)
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getTipoCambio() As Boolean
        Try
            Dim b_tipocambio As New BTipoCambio()
            Dim _where As New Hashtable
            _where.Add("TIPOC_Fecha", New ACWhere("select max(TIPOC_Fecha) from TipoCambio", ACWhere.TipoWhere._In))
            If b_tipocambio.Cargar(_where) Then
                m_tipocambio = b_tipocambio.TipoCambio
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function generarDocumento(ByVal x_usuario As String, ByVal x_cotiz_codigo As String, ByVal x_fecfacturacion As DateTime _
                                   , ByVal x_serie As String, ByVal x_numero As Integer, ByVal x_estentrega As String _
                                   , ByRef x_msg As String, ByVal x_bauditoria As BAuditoria) As Boolean
        Dim m_bgenerardocsventa As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
        Try
            m_bgenerardocsventa.VENT_DocsVenta = m_event_docsventa
            DAEnterprise.BeginTransaction()
            If m_bgenerardocsventa.generarDocumento_trans(x_usuario, x_fecfacturacion, x_serie, x_numero, x_estentrega, x_msg, False) Then
                '' Crear el enlace de fletes y facturas

                For Each item As ETRAN_ViajesVentas In m_listTRAN_ViajesVentas
                    '' Grabar Registro
                    Dim _btran_viajesventas As New BTRAN_ViajesVentas
                    _btran_viajesventas.TRAN_ViajesVentas = item
                    _btran_viajesventas.TRAN_ViajesVentas.Instanciar(ACEInstancia.Nuevo)
                    _btran_viajesventas.TRAN_ViajesVentas.DOCVE_Codigo = m_bgenerardocsventa.VENT_DocsVenta.DOCVE_Codigo
                    _btran_viajesventas.Guardar(x_usuario)
                    '' Actualizar Flete
                    Dim _flete As New BTRAN_Fletes
                    If _flete.Cargar(item.FLETE_Id) Then
                        Dim _where As New Hashtable
                        _where.Add("FLETE_Id", New ACWhere(item.FLETE_Id))
                        _where.Add("VIAVE_Estado", New ACWhere(ACEVentas.Constantes.getEstado(ACEVentas.Constantes.Estado.Anulado), ACWhere.TipoWhere.Diferente))
                        _where.Add("DOCVE_Codigo", New ACWhere(m_event_docsventa.DOCVE_Codigo, ACWhere.TipoWhere.Diferente))
                        Dim _viajesventas As New BTRAN_ViajesVentas
                        If _viajesventas.CargarTodos(_where) Then
                            Dim _err As String = ""
                            For Each Fac As ETRAN_ViajesVentas In _viajesventas.ListTRAN_ViajesVentas
                                _err &= String.Format("[{0}] ", Fac.DOCVE_Codigo)
                            Next
                            Throw New Exception(String.Format("No se puede proceder con la creación del documento, por que el Flete con Codigo: [{0:00000}] ya fue utilizado por el documento: {1}, consulte con su administrador del sistema", item.FLETE_Id, _err))
                        End If
                        _flete.TRAN_Fletes = New ETRAN_Fletes
                        _flete.TRAN_Fletes.Instanciar(ACEInstancia.Modificado)
                        _flete.TRAN_Fletes.FLETE_Id = item.FLETE_Id
                        _flete.TRAN_Fletes.FLETE_Estado = ETRAN_Fletes.getEstado(ETRAN_Fletes.Estados.Cotizado)
                        _flete.Guardar(x_usuario)
                    End If
                Next

                If x_cotiz_codigo.Length > 0 Then
                    '' Cambiar de estado a la cotización
                    Dim m_btran_cotizaciones As New BTRAN_Cotizaciones
                    m_btran_cotizaciones.TRAN_Cotizaciones = New ETRAN_Cotizaciones()
                    m_btran_cotizaciones.TRAN_Cotizaciones.Instanciar(ACEInstancia.Modificado)
                    m_btran_cotizaciones.TRAN_Cotizaciones.COTIZ_Codigo = x_cotiz_codigo
                    m_btran_cotizaciones.TRAN_Cotizaciones.DOCVE_Codigo = m_event_docsventa.DOCVE_Codigo
                    m_btran_cotizaciones.TRAN_Cotizaciones.COTIZ_Estado = ETRAN_Cotizaciones.getEstado(ETRAN_Cotizaciones.Estado.Confirmado)
                    If m_btran_cotizaciones.Guardar(x_usuario) Then
                        If x_bauditoria.Autorizacion Then
                            x_bauditoria.ConfirmarAutorizacion(x_bauditoria.Auditoria.AUDIT_Id, BConstantes.EUsuarioEntidad.ENTID_Codigo, m_bgenerardocsventa.VENT_DocsVenta.DOCVE_Codigo, ETipos.getTipo(ETipos.TipoAuditoria.StocksNegativo), x_usuario)
                        End If
                        DAEnterprise.CommitTransaction()
                        Return True
                    Else
                        Throw New Exception("No se puede cambiar el estado a las cotización")
                    End If
                Else
                    '' Cambiar Estado de los Fletes si no hay Cotizacion
                    DAEnterprise.CommitTransaction()
                    Return True
                End If
                Return False
            End If
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

    Public Function generarDocumentoNota(ByVal x_usuario As String, ByVal x_fecfacturacion As DateTime _
                                   , ByVal x_serie As String, ByVal x_numero As Integer _
                                   , ByRef x_msg As String, ByVal x_bauditoria As BAuditoria) As Boolean
        Dim m_bgenerardocsventa As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
        Try
            m_bgenerardocsventa.VENT_DocsVenta = m_event_docsventa
            DAEnterprise.BeginTransaction()
            If m_bgenerardocsventa.generarDocumento_trans(x_usuario, x_fecfacturacion, x_serie, x_numero, "E", x_msg, False) Then
                '' Crear la relacion entre Nota de Debito y Facturas
                Dim x_bvent_docsrelacion As New BVENT_DocsRelacion
                For Each item As EVENT_DocsVenta In m_listvent_docsventa
                    x_bvent_docsrelacion.VENT_DocsRelacion = New EVENT_DocsRelacion
                    x_bvent_docsrelacion.VENT_DocsRelacion.Instanciar(ACEInstancia.Nuevo)
                    x_bvent_docsrelacion.VENT_DocsRelacion.DOCVE_Codigo = m_event_docsventa.DOCVE_Codigo
                    x_bvent_docsrelacion.VENT_DocsRelacion.DOCVE_CodReferencia = item.DOCVE_Codigo
                    x_bvent_docsrelacion.VENT_DocsRelacion.DOCRE_NCImporte = item.DOCVE_TotalPagar
                    x_bvent_docsrelacion.Guardar(x_usuario)
                Next
                DAEnterprise.CommitTransaction()
                Return True
            End If
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function
    
' <summary>
    ' Generar documento  de venta _modificadoalex
    ' </summary>
    ' <param name="x_usuario">codigo de usuario</param>
    ' <param name="x_fecfacturacion">fecha de facturacion</param>
    ' <param name="x_serie">serie</param>
    ' <param name="x_numero">numero</param>
    ' <param name="x_msg">mensaje devuelto en caso de error</param>
    ' <param name="x_bauditoria"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function generarDocumentoNotaCredito_(ByVal x_usuario As String, ByVal x_fecfacturacion As DateTime _
                                , ByVal x_serie As String, ByVal x_numero As Integer _
                                , ByRef x_msg As String, ByVal x_bauditoria As BAuditoria,BYVAL x_referencia As String) As Boolean
         
        Dim m_bgenerardocsventa As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
        Try
            'm_bgenerardocsventa.VENT_DocsVenta = m_event_docsventa
            DAEnterprise.BeginTransaction()
            Dim refer As String
            For Each item_r As EVENT_DocsVenta In m_event_docsventa.ListVENT_DocsVenta
                refer = item_r.DOCVE_Codigo
            Next
            If generarDocumento_transNC(x_usuario, x_fecfacturacion, x_serie, x_numero, "E", x_msg, False, refer) Then
                '' Crear la relacion entre Nota de CREDITO y Facturas
                'Dim _partes As Integer = m_event_docsventa.ListVENT_DocsVenta.Count
                'If _partes = 0 Then _partes = 1
                'Dim _porcentaje As Decimal = 100 / _partes
                'Dim _importe As Decimal = m_event_docsventa.DOCVE_TotalPagar / _partes
                Dim x_bvent_docsrelacion As New BVENT_DocsRelacion
                'For Each item As EVENT_DocsVenta In m_event_docsventa.ListVENT_DocsVenta
                    x_bvent_docsrelacion.VENT_DocsRelacion = New EVENT_DocsRelacion
                    x_bvent_docsrelacion.VENT_DocsRelacion.Instanciar(ACEInstancia.Nuevo)
                    x_bvent_docsrelacion.VENT_DocsRelacion.DOCVE_Codigo = m_event_docsventa.DOCVE_Codigo
                x_bvent_docsrelacion.VENT_DocsRelacion.DOCVE_CodReferencia = x_referencia
                x_bvent_docsrelacion.VENT_DocsRelacion.DOCRE_NCImporte = m_event_docsventa.DOCVE_TotalPagar
                    x_bvent_docsrelacion.Guardar(x_usuario)
                'Next
                DAEnterprise.CommitTransaction()
                Return True
            End If
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function



' <summary>
    ' Generar documento  de venta
    ' </summary>
    ' <param name="x_usuario">codigo de usuario</param>
    ' <param name="x_fecfacturacion">fecha de facturacion</param>
    ' <param name="x_serie">serie</param>
    ' <param name="x_numero">numero</param>
    ' <param name="x_msg">mensaje devuelto en caso de error</param>
    ' <param name="x_bauditoria"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function generarDocumentoNotaCredito(ByVal x_usuario As String, ByVal x_fecfacturacion As DateTime _
                                , ByVal x_serie As String, ByVal x_numero As Integer _
                                , ByRef x_msg As String, ByVal x_bauditoria As BAuditoria) As Boolean
         
        Dim m_bgenerardocsventa As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
        Try
            'm_bgenerardocsventa.VENT_DocsVenta = m_event_docsventa
            DAEnterprise.BeginTransaction()
            Dim refer As String
            For Each item_r As EVENT_DocsVenta In m_event_docsventa.ListVENT_DocsVenta
                refer = item_r.DOCVE_Codigo
            Next
            If generarDocumento_transNC(x_usuario, x_fecfacturacion, x_serie, x_numero, "E", x_msg, False, refer) Then
                '' Crear la relacion entre Nota de CREDITO y Facturas
                'Dim _partes As Integer = m_event_docsventa.ListVENT_DocsVenta.Count
                'If _partes = 0 Then _partes = 1
                'Dim _porcentaje As Decimal = 100 / _partes
                'Dim _importe As Decimal = m_event_docsventa.DOCVE_TotalPagar / _partes
                Dim x_bvent_docsrelacion As New BVENT_DocsRelacion
                'For Each item As EVENT_DocsVenta In m_event_docsventa.ListVENT_DocsVenta
                    x_bvent_docsrelacion.VENT_DocsRelacion = New EVENT_DocsRelacion
                    x_bvent_docsrelacion.VENT_DocsRelacion.Instanciar(ACEInstancia.Nuevo)
                    x_bvent_docsrelacion.VENT_DocsRelacion.DOCVE_Codigo = m_event_docsventa.DOCVE_Codigo
                    'x_bvent_docsrelacion.VENT_DocsRelacion.DOCVE_CodReferencia = item.DOCVE_Codigo
                    x_bvent_docsrelacion.Guardar(x_usuario)
                'Next
                DAEnterprise.CommitTransaction()
                Return True
            End If
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function
    ' <summary>
    ' Para Transportes Generar documento
    ' </summary>
    ' <param name="x_usuario"></param>
    ' <param name="x_fecfacturacion"></param>
    ' <param name="x_serie"></param>
    ' <param name="x_numero"></param>
    ' <param name="x_estentrega"></param>
    ' <param name="x_msg"></param>
    ' <param name="x_trans"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function generarDocumento_transNC(ByVal x_usuario As String, ByVal x_fecfacturacion As DateTime _
                                   , ByVal x_serie As String, ByVal x_numero As Integer, ByVal x_estentrega As String _
                                   , ByRef x_msg As String, Optional ByRef x_trans As Boolean = True, Optional ByVal refer As String = "") As Boolean
        Try '' Cargar Pedido/Cotizacion y su detalle
            '' Validar que el numero de documento no este ya creado
            m_bvent_docsVenta = New BVENT_DocsVenta


            If validarNumeroDocumento(x_serie, x_numero, m_event_docsventa.TIPOS_CodTipoDocumento) Then
                x_msg &= String.Format("- El numero de documento ya fue usado{0}", vbNewLine)
                Return False
            End If
            '' Iniciar el proceso de creacion del documento de venta
            If x_trans Then DAEnterprise.BeginTransaction()
            '' Crear las clases de Documento de Venta con los datos del Pedido
            '' Cargar la cabecera del Documento de Venta
            m_event_docsventa.DOCVE_Serie = x_serie : m_event_docsventa.DOCVE_Numero = x_numero
            m_event_docsventa.DOCVE_EstEntrega = x_estentrega : m_event_docsventa.DOCVE_FechaDocumento = x_fecfacturacion
            '' Generar el codigo del documento de venta
            m_event_docsventa.DOCVE_Codigo = m_event_docsventa.TIPOS_CodTipoDocumento.Substring(3, 2) & x_serie & x_numero.ToString().PadLeft(7, "0")
            '' Grabar cabecera
            Dim x_bevent_docsventa As New BVENT_DocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
            m_event_docsventa.DOCVE_Id = x_bevent_docsventa.getCorrelativo("DOCVE_Id")
            x_bevent_docsventa.VENT_DocsVenta = m_event_docsventa
            x_bevent_docsventa.VENT_DocsVenta.DOCVE_TotalPagar = m_event_docsventa.DOCVE_TotalVenta
            x_bevent_docsventa.VENT_DocsVenta.DOCVE_TotalPagado = m_event_docsventa.DOCVE_TotalVenta



            If x_bevent_docsventa.Guardar(x_usuario) Then
                '' verifica la autorizacion del Stock Negativo
                Dim x_msgStock As String = ""
                '' Grabar el detalle del documento de venta
                ''instancia para la relacion

                '''''
                Dim x_bevent_docsventadetalle As New BVENT_DocsVentaDetalle
                Dim I As Integer = 1
                For Each Item As EVENT_DocsVentaDetalle In m_event_docsventa.ListVENT_DocsVentaDetalle
                    Item.Instanciar(ACFramework.ACEInstancia.Nuevo)
                    Item.DOCVE_Codigo = m_event_docsventa.DOCVE_Codigo
                    Item.ZONAS_Codigo = m_event_docsventa.ZONAS_Codigo
                    Item.DOCVD_Item = I : I += 1
                    Item.LPREC_Id = 1
                    Item.ALMAC_Id = 5
                    If m_event_docsventa.TIPOS_CodTipoDocumento = "CPD07" Then
                        Item.ARTIC_Codigo = "1301003"
                    Else
                        Item.ARTIC_Codigo = "1301001"
                    End If
                    ''se le agrega la referencia para el detalle de la nota de credito
                    Item.DOCVE_CodigoReferencia = refer
                    ''Item.DOCVD_PrecioUnitario = m_event_docsventa.DOCVE_TotalVenta
                    '''''''''''''''''''''''''''''''''''''''''''''
                    'Item.DOCVD_Cantidad = 1

                    x_bevent_docsventadetalle.setVENT_DocsVentaDetalle(Item)
                    '' Verificar que hay Stock disponible del Articulo
                    If Not x_bevent_docsventadetalle.Guardar(x_usuario) Then
                        If x_trans Then DAEnterprise.RollBackTransaction()
                        Return False
                    Else
                        'If x_bevent_docsventa.getVENT_DocsVenta.TIPOS_CodTipoMotivo = "MNC001" Or x_bevent_docsventa.getVENT_DocsVenta.TIPOS_CodTipoMotivo = "MNC006" Or x_bevent_docsventa.getVENT_DocsVenta.TIPOS_CodTipoMotivo = "MNC007" Then
                        '    '' guardar Stock del Articulo
                        '    Dim m_bmanejarstocks As New BManejarStock()
                        '    m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                        '    m_bmanejarstocks.LOG_Stocks.DOCVE_Codigo = Item.DOCVE_Codigo
                        '    m_bmanejarstocks.LOG_Stocks.ENTID_CodigoCliente = Item.ENTID_CodigoCliente
                        '    m_bmanejarstocks.LOG_Stocks.DOCVD_Item = Item.DOCVD_Item
                        '    If Not m_bmanejarstocks.Ingreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, Item.ALMAC_Id, Item.DOCVD_Cantidad, x_fecfacturacion, "MST14", x_usuario) Then
                        '        If x_trans Then DAEnterprise.RollBackTransaction()
                        '        Return False
                        '    End If
                        'End If
                    End If
                Next

                '' Enumerar los articulos que no tienes stock y mostrarlos
                If x_msg.Length > 0 Then
                    If x_trans Then DAEnterprise.RollBackTransaction()
                    Return False
                Else
                    x_msg = x_msgStock
                End If
                '' Culminar transaccion
                If x_trans Then DAEnterprise.CommitTransaction()
                Return True
            Else
                If x_trans Then DAEnterprise.RollBackTransaction()
                Return False
            End If
        Catch ex As Exception
            If x_trans Then DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function
    ' <summary>
    ' validade el numero del documento de venta, su disponibilidad
    ' </summary>
    ' <param name="x_serie">numero de serie</param>
    ' <param name="x_numero">numero correlativo</param>
    ' <param name="x_documento">tipo de documento</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Private Function validarNumeroDocumento(ByVal x_serie As String, ByVal x_numero As Integer, ByVal x_documento As String) As Boolean
        Try
            Dim _where As New Hashtable()
            _where.Add("DOCVE_Serie", New ACWhere(x_serie))
            _where.Add("DOCVE_Numero", New ACWhere(x_numero))
            _where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_documento))
            Dim m_dvent_docsventa As New BVENT_DocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
            Return m_dvent_docsventa.Cargar(_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function generarSoloDocumento(ByVal x_usuario As String, ByVal x_cotiz_codigo As String, ByVal x_fecfacturacion As DateTime _
                                   , ByVal x_serie As String, ByVal x_numero As Integer, ByVal x_estentrega As String _
                                   , ByRef x_msg As String) As Boolean
        Dim m_bgenerardocsventa As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
        Try
            m_bgenerardocsventa.VENT_DocsVenta = m_event_docsventa
            DAEnterprise.BeginTransaction()
            If m_bgenerardocsventa.generarDocumento(x_usuario, x_fecfacturacion, x_serie, x_numero, x_estentrega, x_msg, False) Then
                '' Crear el enlace de fletes y facturas
                DAEnterprise.CommitTransaction()
                Return True
            End If
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

    Public Function generarDocumento(ByVal x_usuario As String, ByVal x_fecfacturacion As DateTime _
                                   , ByVal x_serie As String, ByVal x_numero As Integer, ByVal x_estentrega As String _
                                   , ByRef x_msg As String) As Boolean
        Dim m_bgenerardocsventa As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
        Try
            m_bgenerardocsventa.VENT_DocsVenta = m_event_docsventa
            If m_bgenerardocsventa.generarDocumento(x_usuario, x_fecfacturacion, x_serie, x_numero, x_estentrega, x_msg) Then
                '' Cambiar de estado a la cotización
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
      Public Function generarDocumentoSimple(ByVal x_usuario As String, ByVal x_fecfacturacion As DateTime _
                                   , ByVal x_serie As String, ByVal x_numero As Integer, ByVal x_estentrega As String _
                                   , ByRef x_msg As String) As Boolean

         Dim m_bgenerardocsventa As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
    
        Try
            m_bgenerardocsventa.VENT_DocsVenta = m_event_docsventa
            If m_bgenerardocsventa.generarDocumento_trans(x_usuario, x_fecfacturacion, x_serie, x_numero, x_estentrega, x_msg, False)
                '' Cambiar de estado a la cotización
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarFletes(ByVal x_codigo As String) As Boolean
        m_listTRAN_ViajesVentas = New List(Of ETRAN_ViajesVentas)
        Dim _btran_viajesventas As New BTRAN_ViajesVentas
        Try
            Dim _btran_cotizaciones As New BTRAN_Cotizaciones
            Dim _where As New Hashtable
            _where.Add("DOCVE_Codigo", New ACWhere(x_codigo))
            If _btran_cotizaciones.Cargar(_where) Then
                m_tran_cotizaciones = _btran_cotizaciones.TRAN_Cotizaciones
            End If

            Dim _whereCF As New Hashtable
            _whereCF.Add("DOCVE_Codigo", New ACWhere(x_codigo))
            Dim _joinCF As New List(Of ACJoin)
            _joinCF.Add(New ACJoin(ETRAN_Fletes.Esquema, ETRAN_Fletes.Tabla, "Cot", ACJoin.TipoJoin.Inner _
                         , New ACCampos() {New ACCampos("FLETE_Id", "FLETE_Id")} _
                         , New ACCampos() {New ACCampos("FLETE_Glosa", "FLETE_Glosa") _
                                             , New ACCampos("FLETE_TotIngreso", "FLETE_TotIngreso") _
                                             , New ACCampos("FLETE_PesoEnTM", "FLETE_PesoEnTM") _
                                             , New ACCampos("FLETE_RazonSocial", "ENTID_RazonSocial")}))
            _joinCF.Add(New ACJoin(ETRAN_Viajes.Esquema, ETRAN_Viajes.Tabla, "Viaje", ACJoin.TipoJoin.Left _
                     , New ACCampos() {New ACCampos("VIAJE_Id", "VIAJE_Id")} _
                     , New ACCampos() {New ACCampos("VIAJE_Descripcion", "VIAJE_Descripcion")}))
            If _btran_viajesventas.CargarTodos(_joinCF, _whereCF) Then
                m_listTRAN_ViajesVentas = New List(Of ETRAN_ViajesVentas)(_btran_viajesventas.ListTRAN_ViajesVentas)
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '==================ORIGINAL =======================================
    'Public Function AnularDocumento(ByVal m_event_docsventa As EVENT_DocsVenta, ByVal x_cotiz_codigo As String, ByVal x_usuario As String, Optional ByVal x_trans As Boolean = True)
    '    Try
    '        If x_trans Then DAEnterprise.BeginTransaction()
    '        Dim m_vent_docsventa As New BVENT_DocsVenta
    '        Dim _pagos As New BTESO_Caja
    '        Dim _where As New Hashtable
    '        _where.Add("CAJA_NroDocumento", New ACWhere(m_event_docsventa.DOCVE_Codigo))
    '        _where.Add("CAJA_Estado", New ACWhere("X", ACWhere.TipoWhere.Diferente))
    '        If _pagos.CargarTodos(_where) Then
    '            Throw New Exception("El Documento no puede ser anulado, tiene pagos realizados que deben ser anulados, consulte con su administrador.")
    '        End If

    '        If m_vent_docsventa.AnularDocumentoTransportes(m_event_docsventa.DOCVE_Codigo, m_event_docsventa.PEDID_Codigo, x_usuario) Then
    '            '' Cambiar de estado a la cotización
    '            If Not x_cotiz_codigo.Length > 0 Then
    '                If Not IsNothing(m_listTRAN_ViajesVentas) Then
    '                    For Each item As ETRAN_ViajesVentas In m_listTRAN_ViajesVentas
    '                        Dim _fletes As New BTRAN_Fletes
    '                        _fletes.TRAN_Fletes = New ETRAN_Fletes
    '                        _fletes.TRAN_Fletes.FLETE_Id = item.FLETE_Id
    '                        _fletes.TRAN_Fletes.FLETE_Estado = ETRAN_Fletes.getEstado(ETRAN_Fletes.Estados.Activo)
    '                        If _fletes.Guardar(x_usuario) Then
    '                            Dim _btran_viajesventas As New BTRAN_ViajesVentas
    '                            _btran_viajesventas.AnularVentas(m_event_docsventa.DOCVE_Codigo, ETRAN_ViajesVentas.getEstado(ETRAN_ViajesVentas.Estados.Anulado))
    '                        End If
    '                    Next
    '                End If
    '                If x_trans Then DAEnterprise.CommitTransaction()
    '                Return True
    '            Else
    '                Dim m_btran_cotizaciones As New BTRAN_Cotizaciones
    '                m_btran_cotizaciones.TRAN_Cotizaciones = New ETRAN_Cotizaciones()
    '                m_btran_cotizaciones.TRAN_Cotizaciones.Instanciar(ACEInstancia.Modificado)
    '                m_btran_cotizaciones.TRAN_Cotizaciones.COTIZ_Codigo = x_cotiz_codigo
    '                m_btran_cotizaciones.TRAN_Cotizaciones.DOCVE_Codigo = m_event_docsventa.DOCVE_Codigo
    '                m_btran_cotizaciones.TRAN_Cotizaciones.COTIZ_Estado = ETRAN_Cotizaciones.getEstado(ETRAN_Cotizaciones.Estado.Ingresado)
    '                If m_btran_cotizaciones.Guardar(x_usuario) Then
    '                    Dim _btran_viajesventas As New BTRAN_ViajesVentas
    '                    _btran_viajesventas.AnularVentas(m_event_docsventa.DOCVE_Codigo, ETRAN_ViajesVentas.getEstado(ETRAN_ViajesVentas.Estados.Anulado))
    '                    If x_trans Then DAEnterprise.CommitTransaction()
    '                    Return True
    '                End If
    '            End If
    '        End If
    '        If x_trans Then DAEnterprise.RollBackTransaction()
    '        Return False
    '    Catch ex As Exception
    '        If x_trans Then DAEnterprise.RollBackTransaction()
    '        Throw ex
    '    End Try
    'End Function


    Public Function AnularDocumento(ByVal m_event_docsventa As EVENT_DocsVenta, ByVal x_cotiz_codigo As String, ByVal x_usuario As String, ByVal x_motivo As String, Optional ByVal x_trans As Boolean = True)
        Try
            If x_trans Then DAEnterprise.BeginTransaction()
            Dim m_vent_docsventa As New BVENT_DocsVenta
            Dim _pagos As New BTESO_Caja
            Dim _where As New Hashtable
            _where.Add("CAJA_NroDocumento", New ACWhere(m_event_docsventa.DOCVE_Codigo))
            _where.Add("CAJA_Estado", New ACWhere("X", ACWhere.TipoWhere.Diferente))
            If _pagos.CargarTodos(_where) Then
                Throw New Exception("El Documento no puede ser anulado, tiene pagos realizados que deben ser anulados, consulte con su administrador.")
            End If

            If m_vent_docsventa.AnularDocumentoTransportes(m_event_docsventa.DOCVE_Codigo, m_event_docsventa.PEDID_Codigo, x_motivo, x_usuario) Then
                '' Cambiar de estado a la cotización
                If Not x_cotiz_codigo.Length > 0 Then
                    If Not IsNothing(m_listTRAN_ViajesVentas) Then
                        For Each item As ETRAN_ViajesVentas In m_listTRAN_ViajesVentas
                            Dim _fletes As New BTRAN_Fletes
                            _fletes.TRAN_Fletes = New ETRAN_Fletes
                            _fletes.TRAN_Fletes.FLETE_Id = item.FLETE_Id
                            _fletes.TRAN_Fletes.FLETE_Estado = ETRAN_Fletes.getEstado(ETRAN_Fletes.Estados.Activo)
                            If _fletes.Guardar(x_usuario) Then
                                Dim _btran_viajesventas As New BTRAN_ViajesVentas
                                _btran_viajesventas.AnularVentas(m_event_docsventa.DOCVE_Codigo, ETRAN_ViajesVentas.getEstado(ETRAN_ViajesVentas.Estados.Anulado))
                            End If
                        Next
                    End If
                    If x_trans Then DAEnterprise.CommitTransaction()
                    Return True
                Else
                    Dim m_btran_cotizaciones As New BTRAN_Cotizaciones
                    m_btran_cotizaciones.TRAN_Cotizaciones = New ETRAN_Cotizaciones()
                    m_btran_cotizaciones.TRAN_Cotizaciones.Instanciar(ACEInstancia.Modificado)
                    m_btran_cotizaciones.TRAN_Cotizaciones.COTIZ_Codigo = x_cotiz_codigo
                    m_btran_cotizaciones.TRAN_Cotizaciones.DOCVE_Codigo = m_event_docsventa.DOCVE_Codigo
                    m_btran_cotizaciones.TRAN_Cotizaciones.COTIZ_Estado = ETRAN_Cotizaciones.getEstado(ETRAN_Cotizaciones.Estado.Ingresado)
                    If m_btran_cotizaciones.Guardar(x_usuario) Then
                        Dim _btran_viajesventas As New BTRAN_ViajesVentas
                        _btran_viajesventas.AnularVentas(m_event_docsventa.DOCVE_Codigo, ETRAN_ViajesVentas.getEstado(ETRAN_ViajesVentas.Estados.Anulado))
                        If x_trans Then DAEnterprise.CommitTransaction()
                        Return True
                    End If
                End If
            End If
            If x_trans Then DAEnterprise.RollBackTransaction()
            Return False
        Catch ex As Exception
            If x_trans Then DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function




    ' <summary> 
    ' Capa de Negocio: VENT_DOCVESS_DocumentosXNotaDebito
    ' </summary>
    ' <param name="x_docve_codigo">Parametro 1: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function DocumentosRelacionados(ByVal x_docve_codigo As String) As Boolean
        m_event_docsventa.ListVENT_DocsVenta = New List(Of EVENT_DocsVenta)
        Try
            Dim _vent_docsventa As New BVENT_DocsVenta
            If _vent_docsventa.DocumentosRelacionados(x_docve_codigo) Then
                m_event_docsventa.ListVENT_DocsVenta = _vent_docsventa.ListVENT_DocsVenta
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function AnularDocumento(ByVal m_event_docsventa As EVENT_DocsVenta, ByVal x_usuario As String, ByVal x_motivo As String)
        Try
            DAEnterprise.BeginTransaction()
            Dim _pagos As New BTESO_Caja
            Dim _where As New Hashtable
            _where.Add("CAJA_NroDocumento", New ACWhere(m_event_docsventa.DOCVE_Codigo))
            _where.Add("CAJA_Estado", New ACWhere("X", ACWhere.TipoWhere.Diferente))
            If _pagos.CargarTodos(_where) Then
                Throw New Exception("El Documento no puede ser anulado, tiene pagos realizados que deben ser anulados, consulte con su administrador.")
            End If

            Dim m_vent_docsventa As New BVENT_DocsVenta
            If m_vent_docsventa.AnularDocumentoTransportes(m_event_docsventa.DOCVE_Codigo, m_event_docsventa.PEDID_Codigo, x_motivo, x_usuario) Then
                '' Cambiar de estado a la cotización
                DAEnterprise.CommitTransaction()
                Return True
            End If
            DAEnterprise.RollBackTransaction()
            Return False
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

    Public Function EliminarDocumento(ByVal m_event_docsventa As EVENT_DocsVenta, ByVal x_usuario As String) As Boolean
        Try
            '' Verificar Pagos realizados
            Dim _pagos As New BTESO_Caja
            Dim _wherepagos As New Hashtable
            _wherepagos.Add("CAJA_NroDocumento", New ACWhere(m_event_docsventa.DOCVE_Codigo))
            _wherepagos.Add("CAJA_Estado", New ACWhere("X", ACWhere.TipoWhere.Diferente))
            If _pagos.CargarTodos(_wherepagos) Then
                Throw New Exception("El Documento no puede ser anulado, tiene pagos realizados que deben ser anulados, consulte con su administrador.")
            End If

            Dim _cotizaciones As New BTRAN_Cotizaciones
            _cotizaciones.TRAN_Cotizaciones = New ETRAN_Cotizaciones
            Dim _wherecotiz As New Hashtable
            _wherecotiz.Add("DOCVE_Codigo", New ACWhere(m_event_docsventa.DOCVE_Codigo))
            _wherecotiz.Add("COTIZ_Estado", New ACWhere(ETRAN_Cotizaciones.getEstado(ETRAN_Cotizaciones.Estado.Anulado), ACWhere.TipoWhere.Diferente))
            If Not _cotizaciones.Cargar(_wherecotiz) Then
                _cotizaciones.TRAN_Cotizaciones.COTIZ_Codigo = ""
            End If

            DAEnterprise.BeginTransaction()

            AnularDocumento(m_event_docsventa, _cotizaciones.TRAN_Cotizaciones.COTIZ_Codigo, x_usuario, False)
            _cotizaciones.QuitarFacturaCotizacion(m_event_docsventa.DOCVE_Codigo)
            Dim _viajesventas As New BTRAN_ViajesVentas
            Dim _where As New Hashtable
            _where.Add("DOCVE_Codigo", New ACWhere(m_event_docsventa.DOCVE_Codigo))
            _viajesventas.Eliminar(_where)

            Dim _bventasdetalle As New BVENT_DocsVentaDetalle
            _bventasdetalle.Eliminar(_where)

            Dim _bventas As New BVENT_DocsVenta
            _bventas.Eliminar(_where)

            DAEnterprise.CommitTransaction()
            Return True
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function
#End Region

End Class

