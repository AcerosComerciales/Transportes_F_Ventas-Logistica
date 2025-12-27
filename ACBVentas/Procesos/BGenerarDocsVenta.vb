Imports System
Imports System.Data
Imports System.Collections.Generic


Imports ACBVentas
Imports ACEVentas
Imports ACDVentas
Imports ACBLogistica
Imports System.Configuration
Imports DAConexion
Imports ACFramework

Public Class BGenerarDocsVenta

#Region " Variables "
   Private m_dtGenerarDocsVenta As DataTable
    Private m_bvent_docsVenta As BVENT_DocsVenta
   Private ds_generardocsventa As DataSet

   Private d_generardocsventa As DGenerarDocsVenta
 Private m_event_docsventa As EVENT_DocsVenta
   Private m_tipocambio As ETipoCambio
   Private m_periodo As String
   Private m_pvent_id As Long
   Private m_sucur_id As Integer
   Private m_zonas_codigo As String
   Private m_listVENT_PVentDocumento As List(Of EVENT_PVentDocumento)
   Private m_listvent_docsventa As List(Of EVENT_DocsVenta)
   Private m_parStockNegativo As Boolean

   Private m_bvent_pedidos As BVENT_Pedidos
   'para cuadre pendientes
    Private m_listccuadrependientes As List(Of ECCuadrePendientes)
    Private m_listnotas_credito As List(Of EVENT_DocsVenta)
#End Region

#Region " Constructores "
   Public Sub New(ByVal x_pvent_id As Long, ByVal x_periodo As String, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Integer)
      m_pvent_id = x_pvent_id
      m_periodo = x_periodo
      m_zonas_codigo = x_zonas_codigo
      m_sucur_id = x_sucur_id
      d_generardocsventa = New DGenerarDocsVenta()
   End Sub
     Public Sub New(ByVal x_periodo As String, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Integer)
      m_periodo = x_periodo
      m_zonas_codigo = x_zonas_codigo
      m_sucur_id = x_sucur_id
      d_generardocsventa = New DGenerarDocsVenta()
   End Sub
#End Region

#Region " Propiedades "
	
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

   Public Property ListVENT_DocsVenta() As List(Of EVENT_DocsVenta)
      Get
         Return m_listvent_docsventa
      End Get
      Set(ByVal value As List(Of EVENT_DocsVenta))
         m_listvent_docsventa = value
      End Set
   End Property

   Public Property ParStockNegativo() As Boolean
      Get
         Return m_parStockNegativo
      End Get
      Set(ByVal value As Boolean)
         m_parStockNegativo = value
      End Set
   End Property
   Public Property ListCCuadrePendientes() As List(Of ECCuadrePendientes)
      Get
         Return m_listccuadrependientes
      End Get
      Set(ByVal value As List(Of ECCuadrePendientes))
         m_listccuadrependientes = value
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
         Return d_generardocsventa.getNumero(x_docve_serie, x_tipos_codtipodocumento)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

     ' <summary>
   ' Genera el correlativo segun el documento de venta y la serie NC
   ' </summary>
   ' <param name="x_docve_serie">Serie del documento</param>
   ' <param name="x_tipos_codtipodocumento">Tipo de documento/comprobante de venta</param>
   ' <returns>Retorna el numero correspondiente al ultimo generado</returns>
   ' <remarks></remarks>
   Public Function getNumeroNC(ByVal x_docve_serie As String, ByVal x_tipos_codtipodocumento As String) As Integer
      Try
         Return d_generardocsventa.getNumeroNC(x_docve_serie, x_tipos_codtipodocumento)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary>
   ' genera el numero de transacción
   ' </summary>
   ' <param name="x_pvent_id">codigo del punto de venta</param>
   ' <param name="x_serie">numero de serie</param>
   ' <returns></returns>
   ' <remarks></remarks>
   Public Function getNroTransaccion(ByVal x_pvent_id As Long, ByVal x_serie As String) As Integer
      Dim x_where As New Hashtable
      Try
         x_where.Add("PVENT_Id", New ACWhere(x_pvent_id))
         x_where.Add("CAJA_Serie", New ACWhere(x_serie))
         Dim _caja As New BTESO_Caja
         Return _caja.getCorrelativo("CAJA_Numero", x_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    ' <summary>
    '
    ' </summary>
    ' <param name="x_usuario"></param>
    ' <returns></returns>
    ' <remarks></remarks>
     Public Function ActualizarImpresion(ByVal x_usuario As String) As Boolean
      Try
         Dim _where As New Hashtable
         _where.Add("DOCVE_Codigo", New ACWhere(m_event_docsventa.DOCVE_Codigo))
         Dim _venta As New BVENT_DocsVenta
         _venta.VENT_DocsVenta = New EVENT_DocsVenta()
         _venta.VENT_DocsVenta.DOCVE_Codigo = m_event_docsventa.DOCVE_Codigo
            _venta.VENT_DocsVenta.Instanciar(ACEInstancia.Modificado)
            _venta.VENT_DocsVenta.DOCVE_Impresa = True
            _venta.VENT_DocsVenta.DOCVE_Impresiones = _venta.getCorrelativo("DOCVE_Impresiones", _where)
         Return _venta.Guardar(x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

     ' <summary>
    '
    ' </summary>
    ' <param name="x_usuario"></param>
    ' <returns></returns>
    ' <remarks></remarks>
     Public Function ActualizarFechaImpresion(ByVal x_usuario As String,ByVal x_fechaImpresion As DateTime) As Boolean
      Try
         Dim _where As New Hashtable
         _where.Add("DOCVE_Codigo", New ACWhere(m_event_docsventa.DOCVE_Codigo))
         Dim _venta As New BVENT_DocsVenta
         _venta.VENT_DocsVenta = New EVENT_DocsVenta()
         _venta.VENT_DocsVenta.DOCVE_Codigo = m_event_docsventa.DOCVE_Codigo
            _venta.VENT_DocsVenta.Instanciar(ACEInstancia.Modificado)
            _venta.VENT_DocsVenta.DOCVE_Impresa = True
        _venta.VENT_DocsVenta.DOCVE_FecImpresion = x_fechaImpresion
         Return _venta.Guardar(x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function



   ' <summary>
   ' Grabar documento de pago - Nota de credito
   ' </summary>
   ' <param name="x_usuario">codigo de usuario</param>
   ' <param name="_codigo">codigo de caja</param>
   ' <param name="x_msg">mensaje a devolver si no se completo el grabado</param>
   ' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ' <remarks></remarks>
   Private Function GrabarDocPagoNC(ByVal x_usuario As String, ByVal _codigo As String, ByRef x_msg As String) As Boolean
      Try
         Dim _bteso_docspagos As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)

         _bteso_docspagos.TESO_DocsPagos = m_event_docsventa.TESO_DocsPagos
         _bteso_docspagos.TESO_DocsPagos.ENTID_Codigo = m_event_docsventa.ENTID_CodigoCliente
         _bteso_docspagos.TESO_DocsPagos.DPAGO_Numero = String.Format("NC {0}-{1:0000000}", _bteso_docspagos.TESO_DocsPagos.VENT_DocsVenta.DOCVE_Serie, _bteso_docspagos.TESO_DocsPagos.VENT_DocsVenta.DOCVE_Numero)
         If _bteso_docspagos.Guardar(x_usuario) Then
            Dim _bteso_cajadocspago As New BTESO_CajaDocsPago
            _bteso_cajadocspago.TESO_CajaDocsPago = New ETESO_CajaDocsPago
            _bteso_cajadocspago.TESO_CajaDocsPago.Instanciar(ACEInstancia.Nuevo)
            _bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Codigo = _codigo
            _bteso_cajadocspago.TESO_CajaDocsPago.DPAGO_Id = _bteso_docspagos.TESO_DocsPagos.DPAGO_Id
            _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Importe = m_event_docsventa.TESO_DocsPagos.ImporteUsado
            _bteso_cajadocspago.TESO_CajaDocsPago.PVENT_Id = _bteso_docspagos.TESO_DocsPagos.PVENT_Id
            _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Numero = 1
            _bteso_cajadocspago.Guardar(x_usuario)
         End If
         '' Grabar Nota de Credito
         _bteso_docspagos.TESO_DocsPagos.VENT_DocsVenta.ENTID_CodigoCliente = m_event_docsventa.ENTID_CodigoCliente
         Dim _bgenerardocsventa As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
         _bgenerardocsventa.VENT_DocsVenta = _bteso_docspagos.TESO_DocsPagos.VENT_DocsVenta
         _bgenerardocsventa.VENT_DocsVenta.Instanciar(ACEInstancia.Nuevo)
         _bgenerardocsventa.VENT_DocsVenta.DOCVE_Estado = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Ingresado)
         _bgenerardocsventa.VENT_DocsVenta.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
         Dim _detalle As New EVENT_DocsVentaDetalle
         _detalle.DOCVD_PrecioUnitario = _bgenerardocsventa.VENT_DocsVenta.DOCVE_ImporteVenta
         _detalle.DOCVD_SubImporteVenta = _bgenerardocsventa.VENT_DocsVenta.DOCVE_ImporteVenta
         _detalle.DOCVD_Cantidad = 1
         _bgenerardocsventa.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Add(_detalle)
            If Not _bgenerardocsventa.generarDocumento(x_usuario, _bgenerardocsventa.VENT_DocsVenta.DOCVE_FechaDocumento, _
                                                    _bgenerardocsventa.VENT_DocsVenta.DOCVE_Serie, _
                                                    _bgenerardocsventa.VENT_DocsVenta.DOCVE_Numero, "E", x_msg, False, "") Then
                Throw New Exception("No Se puede Generar el Documento Nota de Credito")
            End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary>
   ' Grabar documento de pago
   ' </summary>
   ' <param name="x_usuario">codigo de usuario</param>
   ' <param name="_codigo">codigo de caja</param>
   ' <param name="x_efectivo">verdadero: si el tipo de pago es efectivo</param>
   ' <returns></returns>
   ' <remarks></remarks>
   Private Function GrabarDocPago(ByVal x_usuario As String, ByVal _codigo As String, ByVal x_efectivo As Boolean) As Boolean
      Try
         Dim _bteso_docspagos As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
         Dim i As Integer = 1
         _bteso_docspagos.TESO_DocsPagos = m_event_docsventa.TESO_DocsPagos
         _bteso_docspagos.TESO_DocsPagos.ENTID_Codigo = m_event_docsventa.ENTID_CodigoCliente
         Dim _whereid As New Hashtable
         _whereid.Add("PVENT_Id", New ACWhere(_bteso_docspagos.TESO_DocsPagos.PVENT_Id))
         Dim m_caja As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
         _bteso_docspagos.TESO_DocsPagos.DPAGO_Id = m_caja.getCorrelativo("DPAGO_Id", _whereid)
         If x_efectivo Then
            Dim _where As New Hashtable
            _where.Add("TIPOS_CodTipoDocumento", New ACWhere(_bteso_docspagos.TESO_DocsPagos.TIPOS_CodTipoDocumento))
            _where.Add("ENTID_Codigo", New ACWhere(_bteso_docspagos.TESO_DocsPagos.ENTID_Codigo))
            _bteso_docspagos.TESO_DocsPagos.DPAGO_Numero = _bteso_docspagos.getCorrelativo("DPAGO_Numero", _where)
         End If
         If _bteso_docspagos.Guardar(x_usuario) Then
            Dim _bteso_cajadocspago As New BTESO_CajaDocsPago
            _bteso_cajadocspago.TESO_CajaDocsPago = New ETESO_CajaDocsPago
            _bteso_cajadocspago.TESO_CajaDocsPago.Instanciar(ACEInstancia.Nuevo)
            _bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Codigo = _codigo
            _bteso_cajadocspago.TESO_CajaDocsPago.DPAGO_Id = _bteso_docspagos.TESO_DocsPagos.DPAGO_Id
            _bteso_cajadocspago.TESO_CajaDocsPago.PVENT_Id = _bteso_docspagos.TESO_DocsPagos.PVENT_Id
            _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Numero = i
            _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Importe = m_event_docsventa.DOCVE_TotalPagar
            '_bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Id = item.
            Return _bteso_cajadocspago.Guardar(x_usuario)
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary>
   ' Grabar Pago en Caja al Cancelar una Factura
   ' </summary>
   ' <param name="x_usuario"></param>
   ' <param name="x_caja_numero"></param>
   ' <param name="x_caja_codigo"></param>
   ' <param name="x_serie"></param>
   ' <param name="x_numero"></param>
   ' <param name="x_tipocambio"></param>
   ' <param name="m_tipopago"></param>
   ' <returns></returns>
   ' <remarks></remarks>
   Private Function GrabarCaja(ByVal x_usuario As String, ByVal x_caja_numero As Integer, ByVal x_caja_codigo As String, _
                               ByVal x_serie As String, ByVal x_numero As Integer, ByVal x_tipocambio As Decimal, _
                               ByVal m_tipopago As ETipos.TipoDePago) As Boolean
      Try
         Dim m_admincaja As New BAdminCaja(m_zonas_codigo, m_sucur_id, m_pvent_id, m_periodo)
         Dim x_entid_codigocliente As String = ""
         m_event_docsventa.TESO_Caja.TIPOS_CodTipoOrigen = ETipos.getTipoOrigen(ETipos.OrigenCancelacion.FactCancelacionVentas)
         m_event_docsventa.TESO_Caja.CAJA_Numero = x_caja_numero
         m_event_docsventa.TESO_Caja.TIPOS_CodTransaccion = ETipos.getTipoDePago(m_tipopago)
         m_event_docsventa.TESO_Caja.CAJA_Glosa = IIf(m_tipopago = ETipos.TipoDePago.Efectivo, ACEVentas.Constantes.getGlosaTipoDePago(ETipos.TipoDePago.Efectivo), _
                                                   ACEVentas.Constantes.getGlosaTipoDePago(m_tipopago)) & " - " & String.Format("{0}-{1:00000000}", m_event_docsventa.DOCVE_Serie, m_event_docsventa.DOCVE_Numero)
         m_event_docsventa.TESO_Caja.CAJA_Codigo = x_caja_codigo
         m_event_docsventa.TESO_Caja.CAJA_OrdenDocumento = 1
         m_admincaja.GrabarCajaDocumento(m_event_docsventa, x_entid_codigocliente, x_tipocambio, x_usuario)
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary>
   ' Permite Validar el Stock, y tambien carga la Clase Factura para posteriormente ser grabada en la base de datos
   ' </summary>
   ' <param name="x_pedid_codigo">Codigo del Pedido</param>
   ' <param name="x_msg">Mensaje de error, en caso de que la validacion detecte algun inconveniente</param>
   ' <returns></returns>
   ' <remarks></remarks>
   Public Function ValidarStock(ByVal x_pedid_codigo As String, ByRef x_msg As String) As Boolean
      Try
         m_bvent_pedidos = New BVENT_Pedidos
         If m_bvent_pedidos.Cargar(x_pedid_codigo, True) Then
            '' Obtener el los datos de la cabecera 
            getCabecera(m_bvent_pedidos, m_event_docsventa)
            m_event_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
            '' Obtener el detalle del pedido a  la factura
                getDetalle(m_bvent_pedidos.VENT_Pedidos, m_event_docsventa)



            For Each Item As EVENT_DocsVentaDetalle In m_event_docsventa.ListVENT_DocsVentaDetalle
               Dim _stock As Decimal = 0
               If Not ValidarStock(m_periodo, Item.ARTIC_Codigo, Item.ALMAC_Id, Item.DOCVD_Cantidad, m_zonas_codigo, _stock) Then
                  '' Validar si documento tiene permiso para articulos sin stock
                  x_msg &= String.Format("-{1}-{2}, Stock Actual: {3}, Cantidad Solicitada: {4}. {0}", vbNewLine, _
                                         Item.ARTIC_Codigo, Item.ARTIC_Descripcion, _stock, Item.DOCVD_Cantidad)
                    End If

                Next
            Return x_msg.Length > 0
         Else
                Throw New Exception("No se puede cargar el Pedido")
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
    End Function


   ' <summary>
   ' Generar documento de venta
   ' </summary>
   ' <param name="x_usuario">Codigo de usuario</param>
   ' <param name="x_pedid_codigo">Codigo de pedido</param>
   ' <param name="x_docve_serie">serie del documento</param>
   ' <param name="x_docve_numero">numero del documento</param>
   ' <param name="x_estentrega">estado de entrega del documento de venta</param>
   ' <param name="x_tipopago">tipo de pago del documento</param>
   ' <param name="x_cancelar">Verdader: se cancelo el documento usando efectivo u otro medio disponible</param>
   ' <param name="x_tipocambio">tipo de cambio</param>
   ' <param name="x_msg">mensaje devuelto si existe algun error</param>
   ' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ' <remarks></remarks>
    Public Function generarDocumento(ByVal x_usuario As String, ByVal x_pedid_codigo As String _
                                   , ByVal x_docve_serie As String, ByVal x_docve_numero As Integer, ByVal x_estentrega As String _
                                   , ByVal x_tipopago As ETipos.TipoDePago, ByVal x_cancelar As Boolean, ByVal x_tipocambio As Decimal,
                                     ByVal x_plazo As Integer, ByVal x_plazofecha As Date, ByRef x_msg As String, ByVal x_tipocancelacion As String) As Boolean
        Try '' Cargar Pedido/Cotizacion y su detalle
            '' Validar que el numero de documento no este ya creado
            If validarNumeroDocumento(x_docve_serie, x_docve_numero, m_bvent_pedidos.VENT_Pedidos.TIPOS_CodTipoDocumento) Then
                x_msg &= String.Format("- El numero de documento ya fue usado{0}", vbNewLine)
                Return False
            End If
            '' Iniciar el proceso de creacion del documento de venta
            DAEnterprise.BeginTransaction()
            '' Crear las clases de Documento de Venta con los datos del Pedido
            '' Cargar la cabecera del Documento de Venta
            m_event_docsventa.DOCVE_Serie = x_docve_serie : m_event_docsventa.DOCVE_Numero = x_docve_numero
            m_event_docsventa.DOCVE_EstEntrega = x_estentrega
            m_event_docsventa.DOCVE_Plazo = x_plazo
            m_event_docsventa.DOCVE_PlazoFecha = x_plazofecha
            '==========> getCabecera(m_bvent_pedidos, m_event_docsventa)
            '' Generar el codigo del documento de venta
            m_event_docsventa.DOCVE_Codigo = m_event_docsventa.TIPOS_CodTipoDocumento.Substring(3, 2) & x_docve_serie & x_docve_numero.ToString().PadLeft(7, "0")
            '' Grabar cabecera
            Dim x_bevent_docsventa As New BVENT_DocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
            m_event_docsventa.DOCVE_Id = x_bevent_docsventa.getCorrelativo("DOCVE_Id")
            x_bevent_docsventa.setVENT_DocsVenta(m_event_docsventa)
            If x_bevent_docsventa.Guardar(x_usuario) Then
                '' Cargar el detalle del documento de venta
                'm_event_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                '==============> getDetalle(m_bvent_pedidos.VENT_Pedidos, m_event_docsventa)
                '' verifica la autorizacion del Stock Negativo
                Dim x_msgStock As String = ""
                Dim _bauditoria As New BAuditoria()

                Dim _autor As Boolean
                '' Validacion de Stock Negativo por Parametro General Pre-Configurado
                If m_parStockNegativo Then
                    _autor = True
                Else
                    _autor = _bauditoria.VerificarAutorizacion(BConstantes.APLIC_Codigo, BConstantes.ZONAS_Codigo, m_event_docsventa.SUCUR_Id, _
                                                                           ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.CotizacionVenta), _
                                                                           x_pedid_codigo, ETipos.getTipo(ETipos.TipoAuditoria.StocksNegativo))
                End If

                '' Grabar el detalle del documento de venta
                Dim x_bevent_docsventadetalle As New BVENT_DocsVentaDetalle
                For Each Item As EVENT_DocsVentaDetalle In m_event_docsventa.ListVENT_DocsVentaDetalle
                    Item.Instanciar(ACFramework.ACEInstancia.Nuevo)
                    Item.ZONAS_Codigo = m_event_docsventa.ZONAS_Codigo
                    x_bevent_docsventadetalle.VENT_DocsVentaDetalle = Item
                    x_bevent_docsventadetalle.VENT_DocsVentaDetalle.DOCVE_Codigo = m_event_docsventa.DOCVE_Codigo
                    ' x_bevent_docsventadetalle.VENT_DocsVentaDetalle.DOCVD_EstAlmacen = "P"
                    '' Verificar que hay Stock disponible del Articulo

                    '''revisar si el detalle es servicio - se realiza la entrega
                    If Not (Item.Linea <> "1309") Or Item.ARTIC_Codigo = "1301034" Or Item.ARTIC_Codigo = "1301001" Then
                        x_bevent_docsventadetalle.VENT_DocsVentaDetalle.DOCVD_CantidadEntregada = Item.DOCVD_Cantidad
                        x_bevent_docsventadetalle.VENT_DocsVentaDetalle.DOCVD_UsuarioAlmacen = x_usuario
                        x_bevent_docsventadetalle.VENT_DocsVentaDetalle.DOCVD_FecAlmacen = m_event_docsventa.DOCVE_FechaDocumento

                    End If

                    If Not x_bevent_docsventadetalle.Guardar(x_usuario) Then
                        '' Terminar el proceso
                        DAEnterprise.RollBackTransaction()
                        Return False
                        Exit For
                    Else
                        '' Si es una cotización se hace el descuento respectivo
                        Dim m_tipoDocumento As EVENT_Pedidos.TipoPedido = EVENT_Pedidos.TipoCotizacionCodigo(x_pedid_codigo)
                        Select Case m_tipoDocumento
                            Case EVENT_Pedidos.TipoPedido.CT
                                '' Descontar Stock del Articulo
                                Dim m_bmanejarstocks As New BManejarStock()
                                m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                                m_bmanejarstocks.LOG_Stocks.DOCVE_Codigo = Item.DOCVE_Codigo
                                m_bmanejarstocks.LOG_Stocks.DOCVD_Item = Item.DOCVD_Item
                                m_bmanejarstocks.Egreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, Item.ALMAC_Id, Item.DOCVD_Cantidad, _
                                                        x_bevent_docsventa.VENT_DocsVenta.DOCVE_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.SalidaVenta), x_usuario)
                            Case EVENT_Pedidos.TipoPedido.PD, EVENT_Pedidos.TipoPedido.PI
                                Dim _generarpedido As New BGenerarCotizacion(m_periodo)
                                If _generarpedido.AnularPedidoStock(m_event_docsventa.PEDID_Codigo, x_usuario, False) Then
                                    Dim m_bmanejarstocks As New BManejarStock()
                                    m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                                    m_bmanejarstocks.LOG_Stocks.DOCVE_Codigo = Item.DOCVE_Codigo
                                    m_bmanejarstocks.LOG_Stocks.DOCVD_Item = Item.DOCVD_Item
                                    m_bmanejarstocks.Egreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, Item.ALMAC_Id, Item.DOCVD_Cantidad, _
                                                            x_bevent_docsventa.VENT_DocsVenta.DOCVE_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.SalidaVenta), x_usuario)
                                End If
                            Case EVENT_Pedidos.TipoPedido.PS
                                Dim _generarpedido As New BGenerarCotizacion(m_periodo)
                                If _generarpedido.AnularPedidoStock(m_event_docsventa.PEDID_Codigo, x_usuario, False) Then
                                    Dim m_bmanejarstocks As New BManejarStock()
                                    m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                                    m_bmanejarstocks.LOG_Stocks.DOCVE_Codigo = Item.DOCVE_Codigo
                                    m_bmanejarstocks.LOG_Stocks.DOCVD_Item = Item.DOCVD_Item
                                    m_bmanejarstocks.Egreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, Item.ALMAC_Id, Item.DOCVD_Cantidad, _
                                                            x_bevent_docsventa.VENT_DocsVenta.DOCVE_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.SalidaVenta), x_usuario)
                                End If
                            Case Else

                        End Select
                    End If
                Next
                x_tipocancelacion = Convert.ToInt32(Right(x_tipocancelacion, 2))
                '' Ingresar Documento de Pago
                If x_cancelar Then

                    Dim _caja_numero As Integer = getNroTransaccion(m_pvent_id, m_event_docsventa.TESO_Caja.CAJA_Serie)
                    Dim _caja_codigo As String = String.Format("{0:00}{1}{2:0000000}", m_pvent_id, m_event_docsventa.TESO_Caja.CAJA_Serie, _caja_numero)

                    If m_event_docsventa.DOCVE_TotalVenta <> 0 Then
                        '                        MsgBox("es diferente que cero")
                        Select Case x_tipopago
                            Case ETipos.TipoDePago.Efectivo
                                GrabarDocPago(x_usuario, _caja_codigo, True)

                            Case ETipos.TipoDePago.Cheque, ETipos.TipoDePago.DepositoBancario, ETipos.TipoDePago.Detraccion, ETipos.TipoDePago.Letra, ETipos.TipoDePago.RecEgreInterno
                                GrabarDocPago(x_usuario, _caja_codigo, False)
                                m_event_docsventa.TESO_Caja.BANCO_Id = m_event_docsventa.TESO_DocsPagos.BANCO_Id
                            Case ETipos.TipoDePago.NotaCredito
                                GrabarDocPagoNC(x_usuario, _caja_codigo, x_msg)
                        End Select
                        GrabarCaja(x_usuario, _caja_numero, _caja_codigo, m_event_docsventa.TESO_Caja.CAJA_Serie, x_docve_numero, x_tipocambio, x_tipopago)
                    Else
                        ' MsgBox("es = a cero")
                    End If


                Else
                    '' _M

                    If m_event_docsventa.DOCVE_TotalVenta <> 0 Then
                        Select Case x_tipocancelacion
                            'Case ETipos.TipoPago.Contado
                            '    'cambia tipo de pago
                            '    Dim x_bvent_DocsVenta As New BVENT_DocsVenta() With {.VENT_DocsVenta = New EVENT_DocsVenta()}
                            '    x_bvent_DocsVenta.VENT_DocsVenta.DOCVE_Codigo = m_event_docsventa.DOCVE_Codigo
                            '    x_bvent_DocsVenta.VENT_DocsVenta.TIPOS_CodCondicionPago = ETipos.getCondicionPago(ETipos.TipoPago.Bancarizacion) 'ETipos.getTipo(ETipos.TipoPago.Bancarizacion)
                            '    x_bvent_DocsVenta.VENT_DocsVenta.Instanciar(ACEInstancia.Modificado)
                            '    x_bvent_DocsVenta.Guardar(x_usuario)
                            'Case ETipos.TipoPago.Contado
                            '    Dim x_bvent_DocsVenta As New BVENT_DocsVenta() With {.VENT_DocsVenta = New EVENT_DocsVenta()}
                            '    x_bvent_DocsVenta.VENT_DocsVenta.DOCVE_Codigo = m_event_docsventa.DOCVE_Codigo
                            '    x_bvent_DocsVenta.VENT_DocsVenta.TIPOS_CodCondicionPago = ETipos.getCondicionPago(ETipos.TipoPago.Bancarizacion) 'ETipos.getTipo(ETipos.TipoPago.Bancarizacion)
                            '    x_bvent_DocsVenta.VENT_DocsVenta.Instanciar(ACEInstancia.Modificado)
                            '    x_bvent_DocsVenta.Guardar(x_usuario)
                            Case ETipos.TipoPago.Credito
                                Dim _credito As Boolean = _bauditoria.VerificarAutorizacion(BConstantes.APLIC_Codigo, BConstantes.ZONAS_Codigo, BConstantes.SUCUR_Id _
                                                                                      , m_bvent_pedidos.VENT_Pedidos.TIPOS_CodTipoDocumento, x_pedid_codigo _
                                                                                      , ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido))
                                If _credito Then
                                    _bauditoria.ConfirmarAutorizacion(_bauditoria.Auditoria.AUDIT_Id, BConstantes.EUsuarioEntidad.ENTID_Codigo, m_event_docsventa.DOCVE_Codigo, ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido), x_usuario)
                                End If
                            Case ETipos.TipoPago.CreditoL30
                                Dim _credito As Boolean = _bauditoria.VerificarAutorizacion(BConstantes.APLIC_Codigo, BConstantes.ZONAS_Codigo, BConstantes.SUCUR_Id _
                                                                                    , m_bvent_pedidos.VENT_Pedidos.TIPOS_CodTipoDocumento, x_pedid_codigo _
                                                                                    , ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido))
                                If _credito Then
                                    _bauditoria.ConfirmarAutorizacion(_bauditoria.Auditoria.AUDIT_Id, BConstantes.EUsuarioEntidad.ENTID_Codigo, m_event_docsventa.DOCVE_Codigo, ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido), x_usuario)
                                End If
                            Case ETipos.TipoPago.CreditoL45
                                Dim _credito As Boolean = _bauditoria.VerificarAutorizacion(BConstantes.APLIC_Codigo, BConstantes.ZONAS_Codigo, BConstantes.SUCUR_Id _
                                                                                    , m_bvent_pedidos.VENT_Pedidos.TIPOS_CodTipoDocumento, x_pedid_codigo _
                                                                                    , ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido))
                                If _credito Then
                                    _bauditoria.ConfirmarAutorizacion(_bauditoria.Auditoria.AUDIT_Id, BConstantes.EUsuarioEntidad.ENTID_Codigo, m_event_docsventa.DOCVE_Codigo, ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido), x_usuario)
                                End If
                            Case ETipos.TipoPago.CreditoL60
                                Dim _credito As Boolean = _bauditoria.VerificarAutorizacion(BConstantes.APLIC_Codigo, BConstantes.ZONAS_Codigo, BConstantes.SUCUR_Id _
                                                                                    , m_bvent_pedidos.VENT_Pedidos.TIPOS_CodTipoDocumento, x_pedid_codigo _
                                                                                    , ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido))
                                If _credito Then
                                    _bauditoria.ConfirmarAutorizacion(_bauditoria.Auditoria.AUDIT_Id, BConstantes.EUsuarioEntidad.ENTID_Codigo, m_event_docsventa.DOCVE_Codigo, ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido), x_usuario)
                                End If
                            Case ETipos.TipoPago.CreditoL90
                                Dim _credito As Boolean = _bauditoria.VerificarAutorizacion(BConstantes.APLIC_Codigo, BConstantes.ZONAS_Codigo, BConstantes.SUCUR_Id _
                                                                                    , m_bvent_pedidos.VENT_Pedidos.TIPOS_CodTipoDocumento, x_pedid_codigo _
                                                                                    , ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido))
                                If _credito Then
                                    _bauditoria.ConfirmarAutorizacion(_bauditoria.Auditoria.AUDIT_Id, BConstantes.EUsuarioEntidad.ENTID_Codigo, m_event_docsventa.DOCVE_Codigo, ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido), x_usuario)
                                End If
                            Case ETipos.TipoPago.CreditoCh8
                                Dim _credito As Boolean = _bauditoria.VerificarAutorizacion(BConstantes.APLIC_Codigo, BConstantes.ZONAS_Codigo, BConstantes.SUCUR_Id _
                                                                                    , m_bvent_pedidos.VENT_Pedidos.TIPOS_CodTipoDocumento, x_pedid_codigo _
                                                                                    , ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido))
                                If _credito Then
                                    _bauditoria.ConfirmarAutorizacion(_bauditoria.Auditoria.AUDIT_Id, BConstantes.EUsuarioEntidad.ENTID_Codigo, m_event_docsventa.DOCVE_Codigo, ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido), x_usuario)
                                End If
                            Case ETipos.TipoPago.CreditoCh15
                                Dim _credito As Boolean = _bauditoria.VerificarAutorizacion(BConstantes.APLIC_Codigo, BConstantes.ZONAS_Codigo, BConstantes.SUCUR_Id _
                                                                                    , m_bvent_pedidos.VENT_Pedidos.TIPOS_CodTipoDocumento, x_pedid_codigo _
                                                                                    , ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido))
                                If _credito Then
                                    _bauditoria.ConfirmarAutorizacion(_bauditoria.Auditoria.AUDIT_Id, BConstantes.EUsuarioEntidad.ENTID_Codigo, m_event_docsventa.DOCVE_Codigo, ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido), x_usuario)
                                End If
                            Case ETipos.TipoPago.CreditoCh30
                                Dim _credito As Boolean = _bauditoria.VerificarAutorizacion(BConstantes.APLIC_Codigo, BConstantes.ZONAS_Codigo, BConstantes.SUCUR_Id _
                                                                                    , m_bvent_pedidos.VENT_Pedidos.TIPOS_CodTipoDocumento, x_pedid_codigo _
                                                                                    , ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido))
                                If _credito Then
                                    _bauditoria.ConfirmarAutorizacion(_bauditoria.Auditoria.AUDIT_Id, BConstantes.EUsuarioEntidad.ENTID_Codigo, m_event_docsventa.DOCVE_Codigo, ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido), x_usuario)
                                End If
                            Case ETipos.TipoPago.Credito8
                                Dim _credito As Boolean = _bauditoria.VerificarAutorizacion(BConstantes.APLIC_Codigo, BConstantes.ZONAS_Codigo, BConstantes.SUCUR_Id _
                                                                                    , m_bvent_pedidos.VENT_Pedidos.TIPOS_CodTipoDocumento, x_pedid_codigo _
                                                                                    , ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido))
                                If _credito Then
                                    _bauditoria.ConfirmarAutorizacion(_bauditoria.Auditoria.AUDIT_Id, BConstantes.EUsuarioEntidad.ENTID_Codigo, m_event_docsventa.DOCVE_Codigo, ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido), x_usuario)
                                End If
                            Case ETipos.TipoPago.Credito15
                                Dim _credito As Boolean = _bauditoria.VerificarAutorizacion(BConstantes.APLIC_Codigo, BConstantes.ZONAS_Codigo, BConstantes.SUCUR_Id _
                                                                                    , m_bvent_pedidos.VENT_Pedidos.TIPOS_CodTipoDocumento, x_pedid_codigo _
                                                                                    , ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido))
                                If _credito Then
                                    _bauditoria.ConfirmarAutorizacion(_bauditoria.Auditoria.AUDIT_Id, BConstantes.EUsuarioEntidad.ENTID_Codigo, m_event_docsventa.DOCVE_Codigo, ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido), x_usuario)
                                End If
                            Case ETipos.TipoPago.Credito30
                                Dim _credito As Boolean = _bauditoria.VerificarAutorizacion(BConstantes.APLIC_Codigo, BConstantes.ZONAS_Codigo, BConstantes.SUCUR_Id _
                                                                                    , m_bvent_pedidos.VENT_Pedidos.TIPOS_CodTipoDocumento, x_pedid_codigo _
                                                                                    , ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido))
                                If _credito Then
                                    _bauditoria.ConfirmarAutorizacion(_bauditoria.Auditoria.AUDIT_Id, BConstantes.EUsuarioEntidad.ENTID_Codigo, m_event_docsventa.DOCVE_Codigo, ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido), x_usuario)
                                End If
                            Case ETipos.TipoPago.Credito45
                                Dim _credito As Boolean = _bauditoria.VerificarAutorizacion(BConstantes.APLIC_Codigo, BConstantes.ZONAS_Codigo, BConstantes.SUCUR_Id _
                                                                                     , m_bvent_pedidos.VENT_Pedidos.TIPOS_CodTipoDocumento, x_pedid_codigo _
                                                                                     , ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido))
                                If _credito Then
                                    _bauditoria.ConfirmarAutorizacion(_bauditoria.Auditoria.AUDIT_Id, BConstantes.EUsuarioEntidad.ENTID_Codigo, m_event_docsventa.DOCVE_Codigo, ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido), x_usuario)
                                End If
                            Case ETipos.TipoPago.Credito60
                                Dim _credito As Boolean = _bauditoria.VerificarAutorizacion(BConstantes.APLIC_Codigo, BConstantes.ZONAS_Codigo, BConstantes.SUCUR_Id _
                                                                                    , m_bvent_pedidos.VENT_Pedidos.TIPOS_CodTipoDocumento, x_pedid_codigo _
                                                                                    , ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido))
                                If _credito Then
                                    _bauditoria.ConfirmarAutorizacion(_bauditoria.Auditoria.AUDIT_Id, BConstantes.EUsuarioEntidad.ENTID_Codigo, m_event_docsventa.DOCVE_Codigo, ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido), x_usuario)
                                End If
                            Case ETipos.TipoPago.Credito75
                                Dim _credito As Boolean = _bauditoria.VerificarAutorizacion(BConstantes.APLIC_Codigo, BConstantes.ZONAS_Codigo, BConstantes.SUCUR_Id _
                                                                                    , m_bvent_pedidos.VENT_Pedidos.TIPOS_CodTipoDocumento, x_pedid_codigo _
                                                                                    , ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido))
                                If _credito Then
                                    _bauditoria.ConfirmarAutorizacion(_bauditoria.Auditoria.AUDIT_Id, BConstantes.EUsuarioEntidad.ENTID_Codigo, m_event_docsventa.DOCVE_Codigo, ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido), x_usuario)
                                End If
                            Case ETipos.TipoPago.Credito90
                                Dim _credito As Boolean = _bauditoria.VerificarAutorizacion(BConstantes.APLIC_Codigo, BConstantes.ZONAS_Codigo, BConstantes.SUCUR_Id _
                                                                                    , m_bvent_pedidos.VENT_Pedidos.TIPOS_CodTipoDocumento, x_pedid_codigo _
                                                                                    , ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido))
                                If _credito Then
                                    _bauditoria.ConfirmarAutorizacion(_bauditoria.Auditoria.AUDIT_Id, BConstantes.EUsuarioEntidad.ENTID_Codigo, m_event_docsventa.DOCVE_Codigo, ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido), x_usuario)
                                End If

                                '''prueba para bancarizaciones
                                'Case Else
                                '    Dim x_bvent_DocsVenta As New BVENT_DocsVenta() With {.VENT_DocsVenta = New EVENT_DocsVenta()}
                                '    x_bvent_DocsVenta.VENT_DocsVenta.DOCVE_Codigo = m_event_docsventa.DOCVE_Codigo
                                '    x_bvent_DocsVenta.VENT_DocsVenta.TIPOS_CodCondicionPago = ETipos.getCondicionPago(ETipos.TipoPago.BancarizacionDeposito) 'ETipos.getTipo(ETipos.TipoPago.Bancarizacion)
                                '    x_bvent_DocsVenta.VENT_DocsVenta.Instanciar(ACEInstancia.Modificado)
                                '    x_bvent_DocsVenta.Guardar(x_usuario)

                        End Select
                    Else

                    End If



                End If
                '' Enumerar los articulos que no tienes stock y mostrarlos
                If x_msg.Length > 0 Then
                    DAEnterprise.RollBackTransaction()
                    Return False
                Else
                    If Not m_parStockNegativo Then
                        _bauditoria.ConfirmarAutorizacion(_bauditoria.Auditoria.AUDIT_Id, BConstantes.EUsuarioEntidad.ENTID_Codigo, m_event_docsventa.DOCVE_Codigo, ETipos.getTipo(ETipos.TipoAuditoria.StocksNegativo), x_usuario)
                    End If
                    x_msg = x_msgStock
                End If
                '' Cambiar de estado a la Cotizacion/Pedido
                Dim x_bvent_pedidos As New BVENT_Pedidos() With {.VENT_Pedidos = New EVENT_Pedidos()}
                x_bvent_pedidos.VENT_Pedidos.PEDID_Codigo = m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo
                x_bvent_pedidos.VENT_Pedidos.PEDID_Estado = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Confirmado)
                x_bvent_pedidos.VENT_Pedidos.PEDID_DocumentoPercepcion = m_bvent_pedidos.VENT_Pedidos.PEDID_DocumentoPercepcion
                x_bvent_pedidos.VENT_Pedidos.PEDID_GenerarGuia = m_bvent_pedidos.VENT_Pedidos.PEDID_GenerarGuia
                x_bvent_pedidos.VENT_Pedidos.PEDID_ParaFacturar = m_bvent_pedidos.VENT_Pedidos.PEDID_ParaFacturar
                x_bvent_pedidos.VENT_Pedidos.Instanciar(ACEInstancia.Modificado)
                x_bvent_pedidos.Guardar(x_usuario)
                '' Ejecutar operaciones anexas
                ' '' '' '' '' '' ''Dim _credito As Boolean = _bauditoria.VerificarAutorizacion(BConstantes.APLIC_Codigo, BConstantes.ZONAS_Codigo, BConstantes.SUCUR_Id _
                ' '' '' '' '' '' ''                                                                     , m_bvent_pedidos.VENT_Pedidos.TIPOS_CodTipoDocumento, x_pedid_codigo _
                ' '' '' '' '' '' ''                                                                     , ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido))
                ' '' '' '' '' '' ''If _credito Then
                ' '' '' '' '' '' ''    _bauditoria.ConfirmarAutorizacion(_bauditoria.Auditoria.AUDIT_Id, BConstantes.EUsuarioEntidad.ENTID_Codigo, m_event_docsventa.DOCVE_Codigo, ETipos.getTipo(ETipos.TipoAuditoria.FacturarCreditoExcedido), x_usuario)
                ' '' '' '' '' '' ''End If

                '' Culminar transaccion
                DAEnterprise.CommitTransaction()
                Return True
            Else
                DAEnterprise.RollBackTransaction()
                Return False
            End If
            'Else
            'x_msg &= String.Format("- No cargo el pedido.{0}", vbNewLine)
            'Return False
            'End If
            DAEnterprise.RollBackTransaction()
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
    Public Function  generarDocumento_trans(ByVal x_usuario As String, ByVal x_fecfacturacion As DateTime _
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
            'creado por Frank 18-04-2024
            x_bevent_docsventa.VENT_DocsVenta.DOCVE_ValorReferencial = m_event_docsventa.DOCVE_ValorReferencial


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
                    if m_event_docsventa.TIPOS_CodTipoDocumento="CPD07" Then
                        Item.ARTIC_Codigo="1301003"
                    Else 
                    Item.ARTIC_Codigo="1301001"
                        End If
                    Item.ALMAC_Id=3
                    Item.LPREC_Id = 1
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
                        If x_bevent_docsventa.getVENT_DocsVenta.TIPOS_CodTipoMotivo = "MNC001" OR x_bevent_docsventa.getVENT_DocsVenta.TIPOS_CodTipoMotivo = "MNC006" OR x_bevent_docsventa.getVENT_DocsVenta.TIPOS_CodTipoMotivo = "MNC007" Then
                            '' guardar Stock del Articulo
                            Dim m_bmanejarstocks As New BManejarStock()
                            m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                            m_bmanejarstocks.LOG_Stocks.DOCVE_Codigo = Item.DOCVE_Codigo
                            m_bmanejarstocks.LOG_Stocks.ENTID_CodigoCliente = Item.ENTID_CodigoCliente
                            m_bmanejarstocks.LOG_Stocks.DOCVD_Item = Item.DOCVD_Item
                            If Not m_bmanejarstocks.Ingreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, Item.ALMAC_Id, Item.DOCVD_Cantidad, x_fecfacturacion, "MST14", x_usuario) Then
                                If x_trans Then DAEnterprise.RollBackTransaction()
                                Return False
                            End If
                        End If
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
    Public Function  generarDocumentoSimple(ByVal x_usuario As String, ByVal x_fecfacturacion As DateTime _
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
                    ''se le agrega la referencia para el detalle de la nota de credito
                    Item.DOCVE_CodigoReferencia = refer
                    ''Item.DOCVD_PrecioUnitario = m_event_docsventa.DOCVE_TotalVenta
                    '''''''''''''''''''''''''''''''''''''''''''''
                    'Item.DOCVD_Cantidad = 1
                    If m_event_docsventa.TIPOS_CodTipoDocumento = "CPD08" Then
                        Item.ARTIC_Codigo = "1301007"
                        'Else
                        '    Item.ARTIC_Codigo = "1301001"
                    End If
                    x_bevent_docsventadetalle.setVENT_DocsVentaDetalle(Item)
                    '' Verificar que hay Stock disponible del Articulo
                    If Not x_bevent_docsventadetalle.Guardar(x_usuario) Then
                        If x_trans Then DAEnterprise.RollBackTransaction()
                        Return False
                    Else
                        If x_bevent_docsventa.getVENT_DocsVenta.TIPOS_CodTipoMotivo = "MNC001" OR x_bevent_docsventa.getVENT_DocsVenta.TIPOS_CodTipoMotivo = "MNC006" OR x_bevent_docsventa.getVENT_DocsVenta.TIPOS_CodTipoMotivo = "MNC007" OR x_bevent_docsventa.getVENT_DocsVenta.TIPOS_CodTipoMotivo = "MNC002" Then
                            '' guardar Stock del Articulo
                            Dim m_bmanejarstocks As New BManejarStock()
                            m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                            m_bmanejarstocks.LOG_Stocks.DOCVE_Codigo = Item.DOCVE_Codigo
                            m_bmanejarstocks.LOG_Stocks.ENTID_CodigoCliente = Item.ENTID_CodigoCliente
                            m_bmanejarstocks.LOG_Stocks.DOCVD_Item = Item.DOCVD_Item
                            If Not m_bmanejarstocks.Ingreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, Item.ALMAC_Id, Item.DOCVD_Cantidad, x_fecfacturacion, "MST14", x_usuario) Then
                                If x_trans Then DAEnterprise.RollBackTransaction()
                                Return False
                            End If
                        End If
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
    Public Function  generarDocumento(ByVal x_usuario As String, ByVal x_fecfacturacion As DateTime _
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
                    ''se le agrega la referencia para el detalle de la nota de credito
                    Item.DOCVE_CodigoReferencia = refer
                    ''Item.DOCVD_PrecioUnitario = m_event_docsventa.DOCVE_TotalVenta
                    '''''''''''''''''''''''''''''''''''''''''''''
                    'Item.DOCVD_Cantidad = 1
                    If m_event_docsventa.TIPOS_CodTipoDocumento = "CPD08" Then
                        If x_bevent_docsventa.getVENT_DocsVenta.TIPOS_CodTipoMotivo = "NDM002" Then
                            x_bevent_docsventadetalle.setVENT_DocsVentaDetalle(Item)
                        Else
                            Item.ARTIC_Codigo = "1301007"
                        End If

                        'Else
                        '    Item.ARTIC_Codigo = "1301001"
                    End If
                    x_bevent_docsventadetalle.setVENT_DocsVentaDetalle(Item)
                    '' Verificar que hay Stock disponible del Articulo
                    If Not x_bevent_docsventadetalle.Guardar(x_usuario) Then
                        If x_trans Then DAEnterprise.RollBackTransaction()
                        Return False
                    Else
                        If x_bevent_docsventa.getVENT_DocsVenta.TIPOS_CodTipoMotivo = "MNC001" Or x_bevent_docsventa.getVENT_DocsVenta.TIPOS_CodTipoMotivo = "MNC006" Or x_bevent_docsventa.getVENT_DocsVenta.TIPOS_CodTipoMotivo = "MNC007" Or x_bevent_docsventa.getVENT_DocsVenta.TIPOS_CodTipoMotivo = "MNC002" Or x_bevent_docsventa.getVENT_DocsVenta.TIPOS_CodTipoMotivo = "MNC010" Then
                            '' guardar Stock del Articulo
                            Dim m_bmanejarstocks As New BManejarStock()
                            m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                            m_bmanejarstocks.LOG_Stocks.DOCVE_Codigo = Item.DOCVE_Codigo
                            m_bmanejarstocks.LOG_Stocks.ENTID_CodigoCliente = Item.ENTID_CodigoCliente
                            m_bmanejarstocks.LOG_Stocks.DOCVD_Item = Item.DOCVD_Item
                            If Not m_bmanejarstocks.Ingreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, Item.ALMAC_Id, Item.DOCVD_Cantidad, x_fecfacturacion, "MST14", x_usuario) Then
                                If x_trans Then DAEnterprise.RollBackTransaction()
                                Return False
                            End If
                        End If
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
    Public Function  generarDocumento_transNC(ByVal x_usuario As String, ByVal x_fecfacturacion As DateTime _
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
                     if m_event_docsventa.TIPOS_CodTipoDocumento="CPD07" Then
                        Item.ARTIC_Codigo="1301003"
                    Else 
                    Item.ARTIC_Codigo="1301001"
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
                        If x_bevent_docsventa.getVENT_DocsVenta.TIPOS_CodTipoMotivo = "MNC001" OR x_bevent_docsventa.getVENT_DocsVenta.TIPOS_CodTipoMotivo = "MNC006" OR x_bevent_docsventa.getVENT_DocsVenta.TIPOS_CodTipoMotivo = "MNC007" Then
                            '' guardar Stock del Articulo
                            Dim m_bmanejarstocks As New BManejarStock()
                            m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                            m_bmanejarstocks.LOG_Stocks.DOCVE_Codigo = Item.DOCVE_Codigo
                            m_bmanejarstocks.LOG_Stocks.ENTID_CodigoCliente = Item.ENTID_CodigoCliente
                            m_bmanejarstocks.LOG_Stocks.DOCVD_Item = Item.DOCVD_Item
                            If Not m_bmanejarstocks.Ingreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, Item.ALMAC_Id, Item.DOCVD_Cantidad, x_fecfacturacion, "MST14", x_usuario) Then
                                If x_trans Then DAEnterprise.RollBackTransaction()
                                Return False
                            End If
                        End If
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
    ' anular Entrega de almacen
    ' </summary>
    ' <param name="x_periodo"></param>
    ' <param name="x_artic_codigo"></param>
    ' <param name="x_almac_id"></param>
    ' <param name="x_guiar_codigo"></param>
    ' <param name="x_guird_item"></param>
    ' <param name="x_cantidad"></param>
    ' <param name="x_usuario"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function AnularEntregaAlmacen(ByVal x_periodo As String, ByVal x_artic_codigo As String, _
                                       ByVal x_almac_id As Short, ByVal x_guiar_codigo As String, ByVal x_guird_item As Short, _
                                       ByVal x_cantidad As Double, ByVal x_motivo As String, ByVal x_usuario As String, ByRef x_msg As String) As Boolean
        Try
            Dim m_documento As New BVENT_DocsVentaDetalle
            m_documento.VENT_DocsVentaDetalle = New EVENT_DocsVentaDetalle
            Dim _where As New Hashtable
            _where.Add("ARTIC_Codigo", New ACFramework.ACWhere(x_artic_codigo))
            _where.Add("DOCVE_Codigo", New ACFramework.ACWhere(x_guiar_codigo))
            _where.Add("DOCVD_Item", New ACFramework.ACWhere(x_guird_item))
            If m_documento.Cargar(_where) Then
                If m_documento.VENT_DocsVentaDetalle.DOCVD_CantidadEntregada > 0 Then
                    Dim _cant As Decimal = m_documento.VENT_DocsVentaDetalle.DOCVD_CantidadEntregada
                    m_documento.VENT_DocsVentaDetalle = New EVENT_DocsVentaDetalle()
                    m_documento.VENT_DocsVentaDetalle.Instanciar(ACFramework.ACEInstancia.Modificado)
                    m_documento.VENT_DocsVentaDetalle.DOCVE_Codigo = x_guiar_codigo
                    m_documento.VENT_DocsVentaDetalle.ARTIC_Codigo = x_artic_codigo
                    m_documento.VENT_DocsVentaDetalle.DOCVD_Item = x_guird_item
                    m_documento.VENT_DocsVentaDetalle.DOCVD_Motivo = x_motivo
                    m_documento.VENT_DocsVentaDetalle.DOCVD_CantidadEntregada = _cant - x_cantidad
                    _cant = _cant - x_cantidad
                    'Return m_documento.Guardar(x_usuario, _cant, True)
                    If m_documento.Guardar(x_usuario, _cant, True) Then
                        x_msg &= String.Format("-{1}-{2}, Cantidad Entregada: {3}. {0}", vbNewLine, _
                                                                x_artic_codigo, m_documento.VENT_DocsVentaDetalle.ARTIC_Descripcion, x_cantidad)
                    End If
                    Return x_msg.Length > 0
                Else
                    'Return True
                    x_msg &= String.Format("No se registra entregas en Almacen")
                    Return x_msg.Length > 0
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ' <summary>
    ' cargar el documento de venta
    ' </summary>
    ' <param name="x_codigo">codigo del documento de venta</param>
    ' <param name="x_almac_id">codigo del almacen</param>
    ' <param name="x_opcion">cargar el detalle del documento de venta</param>
    ' <param name="x_ordenes">opcion para saber si son ordenes de documentos de venta</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function cargar(ByVal x_codigo As String, ByVal x_almac_id As Short, ByVal x_opcion As Boolean, ByVal x_ordenes As Boolean) As Boolean
        Try
            Dim m_bvent_docsventa As New BVENT_DocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
            If x_ordenes Then
                Dim m_dist_ordenes As New BDIST_Ordenes
                'If m_dist_ordenes.ObtenerOrden(x_codigo, False) Then
                '    m_event_docsventa = New EVENT_DocsVenta()
                '    m_event_docsventa.DOCVE_Codigo = m_dist_ordenes.DIST_Ordenes.DOCVE_Codigo
                '    m_event_docsventa.ORDEN_Codigo = m_dist_ordenes.DIST_Ordenes.ORDEN_Codigo
                '    m_event_docsventa.Codigo = m_dist_ordenes.DIST_Ordenes.Codigo
                '    m_event_docsventa.ENTID_CodigoCliente = m_dist_ordenes.DIST_Ordenes.ENTID_CodigoCliente
                '    m_event_docsventa.DOCVE_Serie = m_dist_ordenes.DIST_Ordenes.DOCVE_Codigo.Substring(2, 4)
                '    m_event_docsventa.DOCVE_Numero = m_dist_ordenes.DIST_Ordenes.DOCVE_Codigo.Substring(3, 7) '010130000015
                '    m_event_docsventa.DOCVE_DireccionCliente = m_dist_ordenes.DIST_Ordenes.ORDEN_DireccionDestino
                '    m_event_docsventa.DOCVE_DescripcionCliente = m_dist_ordenes.DIST_Ordenes.ORDEN_DescripcionCliente
                '    m_event_docsventa.DOCVE_FechaDocumento = m_dist_ordenes.DIST_Ordenes.ORDEN_FechaDocumento
                '    m_event_docsventa.DOCVE_Observaciones = m_dist_ordenes.DIST_Ordenes.ORDEN_Observaciones
                '    m_event_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                '    If ObtDetOrdenes(m_event_docsventa.ListVENT_DocsVentaDetalle, m_dist_ordenes.DIST_Ordenes.ORDEN_Codigo, 1) Then
                '        Return True
                '    Else
                '        Return True
                '    End If
                '    Return False
                'End If
            Else
                If m_bvent_docsventa.Cargar(x_codigo, False) Then
                    m_event_docsventa = New EVENT_DocsVenta()
                    m_event_docsventa = m_bvent_docsventa.VENT_DocsVenta
                    Dim x_orden As String = ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionRemitente)
                    If x_opcion Then
                        m_event_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                        If VENT_Alm_ObtDetDocVenta(x_codigo, x_almac_id) Then
                            Return True
                        Else
                            Return True
                        End If
                    Else
                        Return True
                    End If
                End If
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
  
    ' <summary>
    ' cargar el documento de venta
    ' </summary>
    ' <param name="x_codigo">codigo del documento de venta</param>
    ' <param name="x_articcodigo">codigo del almacen</param>

    ' <returns></returns>
    ' <remarks></remarks>
    Public Function cargarEntregasAlmacen(ByVal x_codigo As String, ByVal x_articcodigo As String) As Boolean
         Try
          ' Dim m_bvent_docsventa As New BVENT_DocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
             m_event_docsventa = New EVENT_DocsVenta()
                   ' m_event_docsventa = m_bvent_docsventa.VENT_DocsVenta
             m_event_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                        If LOG_DIST_ObtenerEntregasAlmacenDetalle(x_codigo, x_articcodigo) Then
                            Return True
                        Else
                            Return True
                        End If
             Catch ex As Exception
            Throw ex
        End Try
  End Function

    
    ' <summary> 
    ' Capa de Negocio: LOG_DIST_GUIASS_ObtDetDocVenta
    ' </summary>
    ' <param name="x_docve_codigo">Parametro 1: </param> 
    ' <param name="x_artic_codigo">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function LOG_DIST_ObtenerEntregasAlmacenDetalle(ByVal x_docve_codigo As String, ByVal x_artic_codigo As String) As Boolean
        m_event_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
        Try
            Return d_generardocsventa.LOG_DIST_ObtenerEntregasAlmacenDetalle(m_event_docsventa.ListVENT_DocsVentaDetalle, x_docve_codigo, x_artic_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Capa de Negocio: LOG_DIST_GUIASS_ObtDetDocVenta
    ' </summary>
    ' <param name="x_docve_codigo">Parametro 1: </param> 
    ' <param name="x_almac_id">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function VENT_Alm_ObtDetDocVenta(ByVal x_docve_codigo As String, ByVal x_almac_id As Short) As Boolean
        m_event_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
        Try
            Return d_generardocsventa.VENT_Alm_ObtDetDocVenta(m_event_docsventa.ListVENT_DocsVentaDetalle, x_docve_codigo, x_almac_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   ' <summary>
   ' obtener la series del documento
   ' </summary>
   ' <param name="x_tipo_documento">tipo de documento</param>
   ' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ' <remarks></remarks>
   Public Function GetSeries(ByVal x_tipo_documento As String) As Boolean
      Try
         m_listVENT_PVentDocumento = New List(Of EVENT_PVentDocumento)()

         Dim _join As New List(Of ACJoin)()
         _join.Add(New ACJoin(ESucursales.Esquema, ESucursales.Tabla, "Sucur", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("SUCUR_Id", "SUCUR_Id")} _
                              , New ACCampos() {New ACCampos("SUCUR_Nombre", "SUCUR_Nombre")}))
         _join.Add(New ACJoin(EPuntoVenta.Esquema, EPuntoVenta.Tabla, "PVta", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("PVENT_Id", "PVENT_Id")} _
                              , New ACCampos() {New ACCampos("PVENT_Descripcion", "PVENT_Descripcion")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                              , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoDocumento")}))

         Dim x_where As New Hashtable
         x_where.Add("ZONAS_Codigo", New ACWhere(m_zonas_codigo))
         x_where.Add("SUCUR_Id", New ACWhere(m_sucur_id))

         If m_pvent_id > 0 Then x_where.Add("PVENT_Id", New ACWhere(m_pvent_id))
         If x_tipo_documento.Length > 3 Then x_where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_tipo_documento))

         ''Jalar los datos de la capa de Negocio de BVENT_PVentDocumento
         Dim m_bvent_pventdoc As New BVENT_PVentDocumento
         '' CargarTodos: Metodo para Cargar todas las listas de los registros
         If m_bvent_pventdoc.CargarTodos(_join, x_where) Then
            m_listVENT_PVentDocumento = New List(Of EVENT_PVentDocumento)(m_bvent_pventdoc.ListVENT_PVentDocumento)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary>
   ' Obtener la serie de un documento
   ' </summary>
   ' <param name="x_app">codigo de aplicacione</param>
   ' <param name="x_zonas_codigo">codigo de la zona</param>
   ' <param name="x_sucur_id">codigo de la sucursal</param>
   ' <param name="x_pvent_id">codigo del punto de venta</param>
   ' <param name="x_tipo_documento">tipo de documento</param>
   ' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ' <remarks></remarks>
   Public Function GetSeries(ByVal x_app As String, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Integer, ByVal x_pvent_id As Integer, ByVal x_tipo_documento As String) As Boolean
      Try
         m_listVENT_PVentDocumento = New List(Of EVENT_PVentDocumento)()

         Dim _join As New List(Of ACJoin)()
         _join.Add(New ACJoin(ESucursales.Esquema, ESucursales.Tabla, "Sucur", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("SUCUR_Id", "SUCUR_Id")} _
                              , New ACCampos() {New ACCampos("SUCUR_Nombre", "SUCUR_Nombre")}))
         _join.Add(New ACJoin(EPuntoVenta.Esquema, EPuntoVenta.Tabla, "PVta", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("PVENT_Id", "PVENT_Id")} _
                              , New ACCampos() {New ACCampos("PVENT_Descripcion", "PVENT_Descripcion")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                              , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoDocumento")}))

         Dim x_where As New Hashtable
         x_where.Add("ZONAS_Codigo", New ACWhere(x_zonas_codigo))
         x_where.Add("SUCUR_Id", New ACWhere(x_sucur_id))
         x_where.Add("PVDOCU_App", New ACWhere(x_app))

         If x_pvent_id > 0 Then x_where.Add("PVENT_Id", New ACWhere(x_pvent_id))
         If x_tipo_documento.Length > 3 Then x_where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_tipo_documento))

         ''Jalar los datos de la capa de Negocio de BVENT_PVentDocumento
         Dim m_bvent_pventdoc As New BVENT_PVentDocumento
         '' CargarTodos: Metodo para Cargar todas las listas de los registros
         If m_bvent_pventdoc.CargarTodos(_join, x_where) Then
            m_listVENT_PVentDocumento = New List(Of EVENT_PVentDocumento)(m_bvent_pventdoc.ListVENT_PVentDocumento)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary>
   ' Obtener el tipo de cambio
   ' </summary>
   ' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ' <remarks></remarks>
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

   ' <summary>
   ' obtener el documento de venta
   ' </summary>
   ' <param name="x_docsventa">codigo del docuemtno de venta</param>
   ' <returns></returns>
   ' <remarks></remarks>
   Public Function getDocsVenta(ByVal x_docsventa As String) As Boolean
      Try
         Dim m_bvent_docsventa As New BVENT_DocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
            If (m_bvent_docsventa.CargarSinArticulos(x_docsventa, True)) Then 'true
                m_event_docsventa = m_bvent_docsventa.VENT_DocsVenta
                Return True
            End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary>
   ' Obtener el docuemtno de venta para la impresion
   ' </summary>
   ' <param name="x_docsventa">codigo del documento de venta</param>
   ' <returns></returns>
   ' <remarks></remarks>
   Public Function getDocsVentaVentas(ByVal x_docsventa As String) As Boolean
      Try
         Dim m_bvent_docsventa As New BVENT_DocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
         If (m_bvent_docsventa.CargarUnDocumento(x_docsventa)) Then
            m_event_docsventa = m_bvent_docsventa.VENT_DocsVenta
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary>
   ' Generar documento nota de credito
   ' </summary>
   ' <param name="x_usuario">codigo de usuario</param>
   ' <param name="x_fecfacturacion">fecha de facturacion</param>
   ' <param name="x_serie">numero de serie</param>
   ' <param name="x_numero">numero correlativo</param>
   ' <param name="x_msg">mensaje devuelto cuando existe un error</param>
   ' <param name="x_bauditoria"></param>
   ' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ' <remarks></remarks>
   Public Function generarDocumentoNota(ByVal x_usuario As String, ByVal x_fecfacturacion As DateTime _
                               , ByVal x_serie As String, ByVal x_numero As Integer _
                               , ByRef x_msg As String, ByVal x_bauditoria As BAuditoria) As Boolean
      Dim m_bgenerardocsventa As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
      Try
         m_bgenerardocsventa.VENT_DocsVenta = m_event_docsventa
         DAEnterprise.BeginTransaction()
            If m_bgenerardocsventa.generarDocumento(x_usuario, x_fecfacturacion, x_serie, x_numero, "E", x_msg, False, "") Then
                '' Crear la relacion entre Nota de Debito y Facturas
                'Dim _partes As Integer = m_event_docsventa.ListVENT_DocsVenta.Count
                'If _partes = 0 Then _partes = 1
                'Dim _porcentaje As Decimal = 100 / _partes
                Dim _importe As Decimal = m_event_docsventa.DOCVE_TotalPagar '/ _partes

                Dim x_bvent_docsrelacion As New BVENT_DocsRelacion
                For Each item As EVENT_DocsVenta In m_listvent_docsventa
                    x_bvent_docsrelacion.VENT_DocsRelacion = New EVENT_DocsRelacion
                    x_bvent_docsrelacion.VENT_DocsRelacion.Instanciar(ACEInstancia.Nuevo)
                    x_bvent_docsrelacion.VENT_DocsRelacion.DOCVE_Codigo = m_event_docsventa.DOCVE_Codigo
                    x_bvent_docsrelacion.VENT_DocsRelacion.DOCVE_CodReferencia = item.DOCVE_Codigo
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
      'Dim m_bgenerardocsventa As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
      Try
         'm_bgenerardocsventa.VENT_DocsVenta = m_event_docsventa
            DAEnterprise.BeginTransaction()
            Dim refer As String
            For Each item_r As EVENT_DocsVenta In m_event_docsventa.ListVENT_DocsVenta
                refer = item_r.DOCVE_Codigo
            Next
            If generarDocumento(x_usuario, x_fecfacturacion, x_serie, x_numero, "E", x_msg, False, refer) Then
                '' Crear la relacion entre Nota de Debito y Facturas
                Dim _partes As Integer = m_event_docsventa.ListVENT_DocsVenta.Count
                If _partes = 0 Then _partes = 1
                Dim _porcentaje As Decimal = 100 / _partes
                Dim _importe As Decimal = m_event_docsventa.DOCVE_TotalPagar / _partes
                Dim x_bvent_docsrelacion As New BVENT_DocsRelacion
                For Each item As EVENT_DocsVenta In m_event_docsventa.ListVENT_DocsVenta
                    x_bvent_docsrelacion.VENT_DocsRelacion = New EVENT_DocsRelacion
                    x_bvent_docsrelacion.VENT_DocsRelacion.Instanciar(ACEInstancia.Nuevo)
                    x_bvent_docsrelacion.VENT_DocsRelacion.DOCVE_Codigo = m_event_docsventa.DOCVE_Codigo
                    x_bvent_docsrelacion.VENT_DocsRelacion.DOCVE_CodReferencia = item.DOCVE_Codigo
                    x_bvent_docsrelacion.VENT_DocsRelacion.DOCRE_NCPorcentaje = _porcentaje
                    x_bvent_docsrelacion.VENT_DocsRelacion.DOCRE_NCImporte = _importe
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
   ' Capa de Negocio: VENT_DOCVESS_DocumentosXNotaDebito
   ' </summary>
   ' <param name="x_docve_codigo">Parametro 1: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function DocumentosRelacionados(ByVal x_docve_codigo As String) As Boolean
        m_listnotas_credito = New List(Of EVENT_DocsVenta)

      Try
         Dim _vent_docsventa As New BVENT_DocsVenta
         If _vent_docsventa.DocumentosRelacionados(x_docve_codigo) Then
                ' m_event_docsventa.ListVENT_DocsVenta = _vent_docsventa.ListVENT_DocsVenta
                m_listvent_docsventa = _vent_docsventa.ListVENT_DocsVenta
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
    End Function
  

   
    ' <summary> 
    ' Capa de Negocio: VENT_DOCVESS_DocumentosXNotaDebito
    ' </summary>
    ' <param name="x_docve_codigo">Parametro 1: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function DocumentosRelacionadoss(ByVal x_docve_codigo As String) As Boolean
        m_listnotas_credito = New List(Of EVENT_DocsVenta)

        Try
            Dim _vent_docsventa As New BVENT_DocsVenta
            If _vent_docsventa.DocumentosRelacionadoss(x_docve_codigo) Then
                ' m_event_docsventa.ListVENT_DocsVenta = _vent_docsventa.ListVENT_DocsVenta
                m_listvent_docsventa = _vent_docsventa.ListVENT_DocsVenta
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Capa de Negocio: CAJASS_ObtenerPendiestesPago
    ' </summary>
    ' <param name="x_pvent_id">Parametro 1: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function ObtenerPendientesPago(ByVal x_pvent_id As Long, ByVal x_entidad As String) As Boolean

        Try
            Dim _vent_docsventa As New BVENT_DocsVenta

            If _vent_docsventa.ObtenerPendientesPago(x_pvent_id, x_entidad) Then
                ' m_event_docsventa.ListVENT_DocsVenta = _vent_docsventa.ListVENT_DocsVenta
                m_listvent_docsventa = _vent_docsventa.ListVENT_DocsVenta
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function
   ' <summary> 
   ' Capa de Negocio: CAJASS_ObtenerDeuda
   ' </summary>
   ' <param name="x_entid_codigo">Parametro 1: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function ObtenerDeuda(ByVal x_entid_codigo As String, ByVal x_pvent_id As Long) As Decimal
      Dim _ventas As New EVENT_DocsVenta
      Try
         If d_generardocsventa.CAJASS_ObtenerDeuda(_ventas, x_entid_codigo, x_pvent_id) Then
            Return _ventas.DOCVE_TotalPagar
         Else
            Return 0
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function ObtenerDeuda(ByVal x_entid_codigo As String, ByVal x_pvent_id As Long, ByVal x_fecfin As Date) As Decimal
      Dim dtRegistros As New DataTable
      Try
         If d_generardocsventa.CAJASS_ObtenerDeudaReg(dtRegistros, x_entid_codigo, x_pvent_id, x_fecfin) Then
            If dtRegistros.Rows.Count > 0 Then
               Return dtRegistros.Rows(0)("PendienteSoles")
            Else
               Return 0
            End If
         Else
            Return 0
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function
   Public Function ObtenerExcedenPlazo(ByVal x_entid_codigo As String, ByVal x_pvent_id As Long, ByVal x_fecfin As Date) As Boolean
      m_listccuadrependientes = New List(Of ECCuadrePendientes)
      Try
         If d_generardocsventa.CAJASS_ExcedenPlazo(m_listccuadrependientes, x_entid_codigo, x_pvent_id, x_fecfin) Then
            Return True
         End If
         Return False

      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary>
   ' Grabar documento de venta
   ' </summary>
   ' <param name="x_usuario"></param>
   ' <returns></returns>
   ' <remarks></remarks>
   Public Function GrabarDocVenta(ByVal x_usuario As String) As Boolean
      Try
         Dim _docsventa As New BVENT_DocsVenta
         _docsventa.VENT_DocsVenta = m_event_docsventa
         If _docsventa.Guardar(x_usuario) Then

            Return True
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#Region " De DocsVenta "

   ' <summary>
   ' cargar documento de venta solo cabecera
   ' </summary>
   ' <param name="x_docve_codigo">codigo del documento de venta</param>
   ' <param name="x_detalle">opcion para cargar el detalle</param>
   ' <returns></returns>
   ' <remarks></remarks>
   Public Function CargarSinArticulos(ByVal x_docve_codigo As String, ByVal x_detalle As Boolean) As Boolean
      Try
         Dim _docsventas As New BVENT_DocsVenta
         If _docsventas.CargarSinArticulos(x_docve_codigo, x_detalle) Then
            m_event_docsventa = _docsventas.VENT_DocsVenta
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary>
   ' obtener el cliente
   ' </summary>
   ' <param name="x_cadena">cadena de busqueda</param>
   ' <param name="x_campo">campo sobre el que se busca la cadena</param>
   ' <param name="x_todos">mostrar todos</param>
   ' <param name="x_fechas">opcion para tomar en cuenta la fecha</param>
   ' <param name="x_fecini">fecha inicial de busqueda</param>
   ' <param name="x_fecfin">fecha dinal de busqueda</param>
   ' <param name="x_pvent_id">odigo del punto de venta</param>
   ' <param name="x_in"></param>
   ' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ' <remarks></remarks>
   Public Function getCliente(ByVal x_cadena As String, ByVal x_campo As String, ByVal x_todos As Boolean _
                         , ByVal x_fechas As Boolean, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime _
                         , ByVal x_pvent_id As Long, ByVal x_in As String) As Boolean
      Try
         Dim _docsventas As New BVENT_DocsVenta
         If _docsventas.getCliente(x_cadena, x_campo, x_todos, x_fechas, x_fecini, x_fecfin, x_pvent_id, x_in) Then
            m_listvent_docsventa = _docsventas.ListVENT_DocsVenta
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary>
   ' Obtener los documentos de venta
   ' </summary>
   ' <param name="x_serie">numero de serie</param>
   ' <param name="x_numero">numero del documento </param>
   ' <param name="x_todos">mostrar todos</param>
   ' <param name="x_tipo">tipo de documento de venta</param>
   ' <returns></returns>
   ' <remarks></remarks>
   Public Function getDocumentos(ByVal x_serie As String, ByVal x_numero As Integer, ByVal x_todos As Boolean, ByVal x_tipo As String) As Boolean
      Try
         Dim _docsventas As New BVENT_DocsVenta
         If _docsventas.getDocumentos(x_serie, x_numero, x_todos, x_tipo) Then
            m_listvent_docsventa = _docsventas.ListVENT_DocsVenta
            Return True
         End If
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

#Region " Metodos Privados "
   ' <summary>
   ' Validar el stock
   ' </summary>
   ' <param name="x_perio_codigo">codigo del periodo</param>
   ' <param name="x_artic_codigo">codigo del articulo</param>
   ' <param name="x_almac_id">codigo del almacen</param>
   ' <param name="x_cantidad">cantidad a validad</param>
   ' <param name="x_zonas_codigo">codigo de la zona</param>
   ' <param name="x_stockactual">Stock actual</param>
   ' <returns></returns>
   ' <remarks></remarks>
   Private Function ValidarStock(ByVal x_perio_codigo As String, ByVal x_artic_codigo As String, ByVal x_almac_id As Short, ByVal x_cantidad As Double, ByVal x_zonas_codigo As String, ByRef x_stockactual As Decimal) As Boolean
      Try
         '         Dim _bconsultaArticulos As New BConsultaArticulos()
         Dim _stocks As New BLOG_Stocks
         If _stocks.ObtenerStockAlmacen(x_perio_codigo, x_artic_codigo, x_almac_id, x_zonas_codigo) Then
            x_stockactual = _stocks.ListLOG_Stocks(0).STOCK_Cantidad
            If x_stockactual > x_cantidad Then
               Return True
            Else
               Return False
            End If
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary>
   ' Validar Stock
   ' </summary>
   ' <param name="x_perio_codigo">Codigo del perido</param>
   ' <param name="x_artic_codigo">codigo del articulo</param>
   ' <param name="x_almac_id">codigo del almacen</param>
   ' <param name="x_cantidad">cantidad a validar</param>
   ' <param name="x_zonas_codigo">codigo de zona</param>
   ' <returns></returns>
   ' <remarks></remarks>
   Private Function ValidarStock(ByVal x_perio_codigo As String, ByVal x_artic_codigo As String, ByVal x_almac_id As Short, ByVal x_cantidad As Double, ByVal x_zonas_codigo As String) As Boolean
      Try
         '         Dim _bconsultaArticulos As New BConsultaArticulos()
         Dim _stocks As New BLOG_Stocks
         If _stocks.ObtenerStockAlmacen(x_perio_codigo, x_artic_codigo, x_almac_id, x_zonas_codigo) Then
            If _stocks.ListLOG_Stocks(0).STOCK_Cantidad > x_cantidad Then
               Return True
            Else
               Return False
            End If
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary>
   ' cargar el pedido de venta y cargarlo a la clase documento de venta
   ' </summary>
   ' <param name="m_bvent_pedidos">clase pedido de venta</param>
   ' <param name="_event_docsventa">clase documento de venta</param>
   ' <remarks></remarks>
   Private Sub getCabecera(ByVal m_bvent_pedidos As BVENT_Pedidos, ByRef _event_docsventa As EVENT_DocsVenta)
      Try
         _event_docsventa.Instanciar(ACFramework.ACEInstancia.Nuevo)
         _event_docsventa.PEDID_Codigo = m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo
         _event_docsventa.DOCVE_DescripcionCliente = m_bvent_pedidos.VENT_Pedidos.PEDID_DescripcionCliente
         _event_docsventa.DOCVE_DireccionCliente = m_bvent_pedidos.VENT_Pedidos.PEDID_DireccionCliente
         _event_docsventa.ENTID_CodigoVendedor = m_bvent_pedidos.VENT_Pedidos.ENTID_CodigoVendedor
         _event_docsventa.ENTID_CodigoCliente = m_bvent_pedidos.VENT_Pedidos.ENTID_CodigoCliente
         _event_docsventa.TIPOS_CodTipoMoneda = m_bvent_pedidos.VENT_Pedidos.TIPOS_CodTipoMoneda
         '_event_docsventa.TIPOS_CodTipoDocumento = m_bvent_pedidos.VENT_Pedidos.TIPOS_CodTipoDocumento
         _event_docsventa.DOCVE_OrdenCompra = m_bvent_pedidos.VENT_Pedidos.PEDID_OrdenCompra
         _event_docsventa.DOCVE_ImporteVenta = m_bvent_pedidos.VENT_Pedidos.PEDID_ImporteVenta
         _event_docsventa.DOCVE_PorcentajeIGV = m_bvent_pedidos.VENT_Pedidos.PEDID_PorcentajeIGV
         _event_docsventa.DOCVE_ImporteIgv = m_bvent_pedidos.VENT_Pedidos.PEDID_ImporteIGV
         _event_docsventa.DOCVE_TotalVenta = m_bvent_pedidos.VENT_Pedidos.PEDID_TotalVenta
         _event_docsventa.DOCVE_AfectoPercepcion = m_bvent_pedidos.VENT_Pedidos.PEDID_AfectoPercepcion
         _event_docsventa.DOCVE_PorcentajePercepcion = m_bvent_pedidos.VENT_Pedidos.PEDID_PorcentajePercepcion
         _event_docsventa.DOCVE_ImportePercepcion = m_bvent_pedidos.VENT_Pedidos.PEDID_ImportePercepcion
         _event_docsventa.DOCVE_TotalPagar = m_bvent_pedidos.VENT_Pedidos.PEDID_TotalPagar
         _event_docsventa.DOCVE_TotalPeso = m_bvent_pedidos.VENT_Pedidos.PEDID_TotalPeso
         _event_docsventa.DOCVE_DocumentoPercepcion = m_bvent_pedidos.VENT_Pedidos.PEDID_DocumentoPercepcion
         _event_docsventa.DOCVE_TipoCambio = m_bvent_pedidos.VENT_Pedidos.PEDID_TipoCambio
         _event_docsventa.DOCVE_TipoCambioSunat = m_bvent_pedidos.VENT_Pedidos.PEDID_TipoCambioSunat
         _event_docsventa.DOCVE_Estado = EVENT_DocsVenta.getEstado(ACEVentas.EVENT_DocsVenta.Estado.Ingresado)
         _event_docsventa.DOCVE_Observaciones = m_bvent_pedidos.VENT_Pedidos.PEDID_Observaciones

         _event_docsventa.DOCVE_Plazo = m_bvent_pedidos.VENT_Pedidos.PEDID_Plazo
         _event_docsventa.DOCVE_Dirigida = m_bvent_pedidos.VENT_Pedidos.PEDID_Dirigida
         _event_docsventa.DOCVE_PlazoFecha = m_bvent_pedidos.VENT_Pedidos.PEDID_PlazoFecha
         _event_docsventa.DOCVE_NroTelefono = m_bvent_pedidos.VENT_Pedidos.PEDID_NroTelefono
         _event_docsventa.DOCVE_AfectoPercepcionSoles = m_bvent_pedidos.VENT_Pedidos.PEDID_AfectoPercepcionSoles
         _event_docsventa.DOCVE_ImportePercepcionSoles = m_bvent_pedidos.VENT_Pedidos.PEDID_ImportePercepcionSoles
            '_event_docsventa.TIPOS_CodCondicionPago = m_bvent_pedidos.VENT_Pedidos.TIPOS_CodCondicionPago

            _event_docsventa.DOCVE_AfectoRetencion = m_bvent_pedidos.VENT_Pedidos.PEDID_AfectoRetencion
            m_event_docsventa.DOCVE_ImporteRetencion = m_bvent_pedidos.VENT_Pedidos.PEDID_ImporteRetencion
            m_event_docsventa.DOCVE_PorcentajeRetencion = m_bvent_pedidos.VENT_Pedidos.PEDID_PorcentajeRetencion

         _event_docsventa.DOCVE_TipoCambio = _event_docsventa.TESO_Caja.CAJA_TCambio
         _event_docsventa.DOCVE_TipoCambioSunat = _event_docsventa.TESO_Caja.CAJA_TCSunatVenta
         _event_docsventa.DOCVE_AfectoPercepcionSoles = m_bvent_pedidos.VENT_Pedidos.PEDID_AfectoPercepcionSoles
         _event_docsventa.DOCVE_ImportePercepcionSoles = m_bvent_pedidos.VENT_Pedidos.PEDID_ImportePercepcionSoles
            _event_docsventa.ENTID_CodigoCotizador = m_bvent_pedidos.VENT_Pedidos.PEDID_UsrCrea


      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   ' <summary>
   ' cargar el detalle del pedido y cargarlo en el detalle del documento de venta
   ' </summary>
   ' <param name="x_event_pedidos">clase pedido</param>
   ' <param name="m_event_docsventa">clase documento de venta</param>
   ' <remarks></remarks>
   Private Sub getDetalle(ByVal x_event_pedidos As EVENT_Pedidos, ByRef m_event_docsventa As EVENT_DocsVenta)
      Try
         For Each Item As EVENT_PedidosDetalle In x_event_pedidos.ListDetPedidos
            Dim x_edetalle As New EVENT_DocsVentaDetalle()
            x_edetalle.DOCVD_Item = Item.PDDET_Item
            x_edetalle.DOCVE_Codigo = m_event_docsventa.DOCVE_Codigo
            x_edetalle.ARTIC_Codigo = Item.ARTIC_Codigo
            x_edetalle.LPREC_Id = Item.LPREC_Id
            x_edetalle.DOCVD_Percepcion = Item.PDDET_Percepcion

            x_edetalle.DOCVD_PesoUnitario = Item.PDDET_PesoUnitario
            x_edetalle.DOCVD_PrecioUnitario = Item.PDDET_PrecioUnitario
            x_edetalle.DOCVD_Cantidad = Item.PDDET_Cantidad
            x_edetalle.DOCVD_SubImporteVenta = Item.PDDET_SubImporteVenta
            x_edetalle.DOCVD_SubImportePercepcion = Item.PDDET_SubImportePercepcion
            x_edetalle.ALMAC_Id = Item.ALMAC_Id
            x_edetalle.ARTIC_Descripcion = Item.ARTIC_Descripcion
            x_edetalle.TIPOS_CodUnidadMedida = Item.TIPOS_CodUnidadMedida

            x_edetalle.DOCVD_CostoUnitario = Item.PDDET_CostoUnitario
            x_edetalle.DOCVD_CostoUnitarioSoles = Item.PDDET_CostoUnitarioSoles
            x_edetalle.DOCVD_CostoUnitarioDolares = Item.PDDET_CostoUnitarioDolares
            x_edetalle.DOCVD_TipoCambioCosto = Item.PDDET_TipoCambioCosto

            m_event_docsventa.ListVENT_DocsVentaDetalle.Add(x_edetalle)
         Next
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

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
#End Region
#End Region

End Class

