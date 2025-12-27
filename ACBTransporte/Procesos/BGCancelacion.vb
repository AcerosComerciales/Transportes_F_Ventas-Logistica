Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Imports ACBVentas
Imports ACEVentas

Imports ACFramework
Imports DAConexion

Public Class BGCancelacion

#Region " Variables "
   Private m_dtGCancelacion As DataTable

	Private m_dsGCancelacion As DataSet
   Private d_gcancelacion As DGCancelacion

   Private m_eteso_caja As ETESO_Caja
   Private m_etran_recibos As ETRAN_Recibos

   Private m_tipocambiosunat As ETipoCambio
   Private m_tipocambiooficina As ETipoCambio

   Private m_listVENT_PagosFacturas As List(Of EVENT_DocsVenta)
   Private m_listEntidades As List(Of EEntidades)

   Private m_listteso_docspagos As List(Of ETESO_DocsPagos)

    Private m_listSaldoAFavorCliente As List(Of ETESO_Recibos)
    Private m_pvent_id As Integer
   Private m_periodo As String
   Private m_zonas_codigo As String
    Private m_sucur_id As Short
    Private m_app As String


    Private m_listvent_docsventa As List(Of EVENT_DocsVenta)


    Public Enum TRedondeo
        SinRedondeo
        PorExcesoPago
        PorFaltaPago
    End Enum
#End Region

#Region " Constructores "

   Public Sub New(ByVal x_pvent_id As Integer, ByVal x_periodo As String, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short)
      d_gcancelacion = New DGCancelacion
      m_pvent_id = x_pvent_id
      m_periodo = x_periodo
      m_zonas_codigo = x_zonas_codigo
      m_sucur_id = x_sucur_id
   End Sub

#End Region

#Region " Propiedades "

    Public Property TipoCambioSunat() As ETipoCambio
        Get
            Return m_tipocambiosunat
        End Get
        Set(ByVal value As ETipoCambio)
            m_tipocambiosunat = value
        End Set
    End Property
    Public Property App() As String
        Get
            Return m_app
        End Get
        Set(ByVal value As String)
            m_app = value
        End Set
    End Property

    Public Property TipoCambioOficina() As ETipoCambio
      Get
         Return m_tipocambiooficina
      End Get
      Set(ByVal value As ETipoCambio)
         m_tipocambiooficina = value
      End Set
   End Property


   Public Property TESO_Caja() As ETESO_Caja
      Get
         Return m_eteso_caja
      End Get
      Set(ByVal value As ETESO_Caja)
         m_eteso_caja = value
      End Set
   End Property

   Public Property DTGCancelacion() As DataTable
      Get
         Return m_dtGCancelacion
      End Get
      Set(ByVal value As DataTable)
         m_dtGCancelacion = value
      End Set
   End Property

   Public Property DSGCancelacion() As DataSet
      Get
         Return m_dsGCancelacion
      End Get
      Set(ByVal value As DataSet)
         m_dsGCancelacion = value
      End Set
   End Property

    Public Property ListVENT_PagosFacturas() As List(Of EVENT_DocsVenta)
        Get
            Return m_listVENT_PagosFacturas
        End Get
        Set(ByVal value As List(Of EVENT_DocsVenta))
            m_listVENT_PagosFacturas = value
        End Set
    End Property

    Public Property ListVENT_RecibosAFavor() As List(Of ETESO_Recibos)
        Get
            Return m_listSaldoAFavorCliente
        End Get
        Set(ByVal value As List(Of ETESO_Recibos))
            m_listSaldoAFavorCliente = value
        End Set
    End Property


    Public Property ListEntidades() As List(Of EEntidades)
      Get
         Return m_listEntidades
      End Get
      Set(ByVal value As List(Of EEntidades))
         m_listEntidades = value
      End Set
   End Property

   Public Property ListTESO_DocsPagos() As List(Of ETESO_DocsPagos)
      Get
         Return m_listteso_docspagos
      End Get
      Set(ByVal value As List(Of ETESO_DocsPagos))
         m_listteso_docspagos = value
      End Set
   End Property

   Public Property TRAN_Recibos() As ETRAN_Recibos
      Get
         Return m_etran_recibos
      End Get
      Set(ByVal value As ETRAN_Recibos)
         m_etran_recibos = value
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
   ' Capa de Negocio: TRAN_CAJASS_FacturasXCancelar
   ' </summary>
   ' <param name="x_entid_codigo">Parametro 1: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function CargarFacturasXCancelar(ByVal x_entid_codigo As String, ByVal x_pvent_id As Long) As Boolean
      m_listvent_docsventa = New List(Of EVENT_DocsVenta)
      Try
         Return d_gcancelacion.TRAN_CAJASS_FacturasXCancelar(m_listvent_docsventa, x_entid_codigo, x_pvent_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CargarCaja(ByVal x_pvent_id As Long, ByVal x_caja_id As Long) As Boolean
      Try
         Dim _bteso_caja As New BTESO_Caja
         If _bteso_caja.Cargar(x_pvent_id, x_caja_id) Then
            m_eteso_caja = _bteso_caja.TESO_Caja
            Dim _btran_recibos = New BTRAN_Recibos
            If _btran_recibos.Cargar(_bteso_caja.TESO_Caja.CAJA_NroDocumento) Then
               m_etran_recibos = _btran_recibos.TRAN_Recibos
            End If
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function ModificarFecha(ByVal x_fecha As DateTime, ByVal x_importe As Decimal, ByVal x_usuario As String) As Boolean
      Try
         DAEnterprise.BeginTransaction()
         Dim _bteso_caja As New BTESO_Caja
         _bteso_caja.TESO_Caja = New ETESO_Caja
         _bteso_caja.TESO_Caja.CAJA_Id = m_eteso_caja.CAJA_Id
         _bteso_caja.TESO_Caja.PVENT_Id = m_pvent_id
         _bteso_caja.TESO_Caja.CAJA_Fecha = x_fecha
         _bteso_caja.TESO_Caja.CAJA_Importe = x_importe
         _bteso_caja.TESO_Caja.TIPOS_CodTransaccion = m_eteso_caja.TIPOS_CodTransaccion
         _bteso_caja.TESO_Caja.TIPOS_CodTipoOrigen = m_eteso_caja.TIPOS_CodTipoOrigen
         _bteso_caja.TESO_Caja.TIPOS_CodTipoDocumento = m_eteso_caja.TIPOS_CodTipoDocumento

         If _bteso_caja.Guardar(x_usuario) Then
            'If _bteso_caja.ModificarImpFec(x_fecha, x_importe, x_usuario) Then
            Dim _btran_recibos = New BTRAN_Recibos
            _btran_recibos.TRAN_Recibos = m_etran_recibos
            _btran_recibos.ModificarImpFec(x_fecha, x_importe, x_usuario)
            DAEnterprise.CommitTransaction()
            Return True
         End If
         DAEnterprise.RollBackTransaction()
         Return False
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw
      End Try
   End Function

   Public Function getUltimoTipoCambio() As Decimal
      Try
         Dim b_tipocambio As New BTipoCambio()
         If b_tipocambio.getUltTipoCambio() Then
            m_tipocambiosunat = b_tipocambio.TipoCambio
            Return m_tipocambiosunat.TIPOC_VentaSunat
         Else
            m_tipocambiosunat = New ETipoCambio
            Return 0
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getUltimoTipoCambioOficina() As Decimal
      Try
         Dim b_tipocambio As New BTipoCambio()
         If b_tipocambio.getUltTipoCambioOficina() Then
            m_tipocambiooficina = b_tipocambio.TipoCambio
            Return m_tipocambiooficina.TIPOC_VentaOficina
         Else
            m_tipocambiooficina = New ETipoCambio
            Return 0
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getTipoCambioSunat(ByVal x_fecha As Date) As Decimal
      Try
         Dim b_tipocambio As New BTipoCambio()
         If b_tipocambio.getTipoCambioSunat(x_fecha) Then
            m_tipocambiosunat = b_tipocambio.TipoCambio
            Return m_tipocambiosunat.TIPOC_VentaSunat
         Else
            m_tipocambiosunat = New ETipoCambio
            Return 0
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

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

    Public Function Ayuda(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String) As Boolean
        Try
            Dim _docspago As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
            If _docspago.Ayuda(x_fecini, x_fecfin, x_entid_codigo) Then
                m_dtGCancelacion = New DataTable() : m_dtGCancelacion = _docspago.DTTESO_DocsPagos
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function AyudaSaldosAFavor(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String) As Boolean
        Try
            Dim _docspago As New BTESO_Recibos(m_pvent_id)
            If _docspago.AyudaSaldo(x_entid_codigo) Then
                m_dtGCancelacion = New DataTable() : m_dtGCancelacion = _docspago.DTTESO_TesoRecibos 'DTTESO_DocsPagos
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary>
    ' Cargar la ayuda de busqueda de documentos de pago, todos los pago a favor del cliente
    ' </summary>
    ' <param name="x_fecini"></param>
    ' <param name="x_fecfin"></param>
    ' <param name="x_entid_codigo"></param>
    ' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
    ' <remarks></remarks>
    Public Function AyudaNC(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String, x_entid_CodigoDoc As String) As Boolean
        Try
            Dim _docspago As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, 5)
            If _docspago.AyudaNC(x_fecini, x_fecfin, x_entid_codigo, x_entid_CodigoDoc) Then
                m_dtGCancelacion = New DataTable() : m_dtGCancelacion = _docspago.DTTESO_DocsPagos
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function TRAN_CAJASS_ObtenerSaldosAFavorClientePendientes(ByVal x_entid_codigoCliente As String) As Boolean
        'Funcion que Llama a otro procedimiento almacenado para traer los Saldos Pendientes de Un Cliente
        Try
            Dim _ReciboAFavorPendiente As New BTESO_Recibos()
            If _ReciboAFavorPendiente.TRAN_CAJASS_ObtenerSaldosAFavorClientePendientes(x_entid_codigoCliente) Then
                Return True

            Else
                Return False

            End If


        Catch ex As Exception

        End Try

    End Function

    Public Function getPendiente(ByVal x_cadena As String, ByVal x_campo As String, ByVal x_todos As Boolean) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         Dim _where As New Hashtable()
         setJoinWhereEntidad(_join, _where, x_todos)
         _where.Add(x_campo, New ACWhere(x_cadena, ACWhere.TipoWhere._Like))
         Dim m_bentidades As New BEntidades
         If m_bentidades.CargarTodos(_join, _where, True) Then
            m_listEntidades = New List(Of EEntidades)(m_bentidades.ListEntidades)
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Sub setJoinWhereEntidad(ByRef _join As List(Of ACJoin), ByRef _where As Hashtable, ByVal x_todos As Boolean)
      Try
            _join.Add(New ACJoin(EVENT_DocsVenta.Esquema, EVENT_DocsVenta.Tabla, "Vent", ACJoin.TipoJoin.Left _
                            , New ACCampos() {New ACCampos("ENTID_CodigoCliente", "ENTID_Codigo")} _
                            , New ACCampos() {}))
            _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                            , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_DocumentoCorto") _
                                              , New ACCampos("TIPOS_Descripcion", "TIPOS_Documento")}))
         '_join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TCond", ACJoin.TipoJoin.Inner _
         '          , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodCondicionPago")} _
         '          , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_CondicionPago") _
         '                            , New ACCampos("TIPOS_Descripcion", "TIPOS_CondicionPagoCorto")}))
         '_join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TPag", ACJoin.TipoJoin.Inner _
         '          , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoPago")} _
         '          , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_TipoPago") _
         '                            , New ACCampos("TIPOS_Descripcion", "TIPOS_TipoPago")}))
         'If Not x_todos Then _where.Add("DOCVE_Estado", New ACWhere(EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Ingresado), "Vent", "System.String", ACWhere.TipoWhere.Igual))
      Catch ex As Exception
         Throw ex
      End Try
    End Sub
    ' <summary>
    ' Grabar Registros por Redondeo
    ' </summary>
    ' <param name="item"></param>
    ' <param name="x_codtransaccion"></param>
    ' <param name="x_Caja_codigo"></param>
    ' <param name="_diferencia"></param>
    ' <param name="x_tipocambio"></param>
    ' <param name="x_usuario"></param>
    ' <remarks></remarks>
    Private Sub GrabarCajaDocumento(ByVal item As EVENT_DocsVenta, ByVal x_codtransaccion As ETipos.TipoDePago, ByVal x_Caja_codigo As String, ByVal _diferencia As Decimal, ByVal x_tipocambio As Decimal, ByVal x_glosa As String, ByVal x_usuario As String)
        Try
            '' Genera el registro de la tabla TESO_Caja
            Dim _caja As New BTESO_Caja
            _caja.TESO_Caja = New ETESO_Caja()
            _caja.TESO_Caja.Instanciar(ACEInstancia.Nuevo)
            _caja.TESO_Caja.TIPOS_CodTransaccion = ETipos.getTipoDePago(x_codtransaccion)
            _caja.TESO_Caja.CAJA_Glosa = IIf(x_codtransaccion = ETipos.TipoDePago.Efectivo, ACEVentas.Constantes.getGlosaTipoDePago(ETipos.TipoDePago.Efectivo), _
                                    ACEVentas.Constantes.getGlosaTipoDePago(x_codtransaccion)) & " / " & x_glosa
            _caja.TESO_Caja.CAJA_Pase = ACEVentas.Constantes.GetPase(ACEVentas.Constantes.Pase.Entrada)
            _caja.TESO_Caja.CAJA_ImporteVenta = item.DOCVE_ImporteVenta
            _caja.TESO_Caja.CAJA_Estado = ETESO_Caja.getEstado(ETESO_Caja.Estado.Ingresado)
            _caja.TESO_Caja.CAJA_TCDocumento = x_tipocambio
            ' _caja.TESO_Caja.DOCVE_Codigo = item.DOCVE_Codigo
            _caja.TESO_Caja.CAJA_NroDocumento = item.DOCVE_Codigo
            _caja.TESO_Caja.TIPOS_CodTipoDocumento = item.TIPOS_CodTipoDocumento
            _caja.TESO_Caja.TIPOS_CodTipoMoneda = item.TIPOS_CodTipoMoneda
            _caja.TESO_Caja.ENTID_Codigo = item.ENTID_CodigoCliente
            _caja.TESO_Caja.CAJA_Codigo = x_Caja_codigo
            _caja.TESO_Caja.PVENT_Id = item.TESO_Caja.PVENT_Id
            '' Genera el correlativo
            Dim _whereCaja As New Hashtable : _whereCaja.Add("PVENT_Id", New ACWhere(_caja.TESO_Caja.PVENT_Id))
            _caja.TESO_Caja.CAJA_Id = _caja.getCorrelativo("CAJA_Id", _whereCaja)
            _caja.TESO_Caja.TIPOS_CodTipoOrigen = ETipos.getTipoOrigen(ETipos.OrigenCancelacion.CancelacionDocumentosVentas)
            _caja.TESO_Caja.CAJA_Serie = item.TESO_Caja.CAJA_Serie
            _caja.TESO_Caja.CAJA_OrdenDocumento = item.TESO_Caja.CAJA_OrdenDocumento + 1
            _caja.TESO_Caja.CAJA_Fecha = item.TESO_Caja.CAJA_Fecha
            _caja.TESO_Caja.CAJA_Hora = item.TESO_Caja.CAJA_Hora
            _caja.TESO_Caja.CAJA_FechaPago = item.TESO_Caja.CAJA_FechaPago
            _caja.TESO_Caja.CAJA_Importe = _diferencia
            _caja.TESO_Caja.CAJA_App = item.TESO_Caja.CAJA_App
            _caja.TESO_Caja.CAJA_Numero = getNroTransaccion(m_pvent_id, item.TESO_Caja.CAJA_Serie)
            _caja.TESO_Caja.TIPOS_CodMonedaPago = item.TESO_Caja.TIPOS_CodMonedaPago
            _caja.TESO_Caja.CAJA_TCambio = item.TESO_Caja.CAJA_TCambio
            _caja.TESO_Caja.CAJA_TCDocumento = item.TESO_Caja.CAJA_TCDocumento
            _caja.TESO_Caja.CAJA_TCOficinaCompra = item.TESO_Caja.CAJA_TCOficinaCompra
            _caja.TESO_Caja.CAJA_TCOficinaVenta = item.TESO_Caja.CAJA_TCOficinaVenta
            _caja.TESO_Caja.CAJA_TCPorUsuario = item.TESO_Caja.CAJA_TCPorUsuario
            _caja.TESO_Caja.CAJA_TCSunatCompra = item.TESO_Caja.CAJA_TCSunatCompra
            _caja.TESO_Caja.CAJA_TCSunatVenta = item.TESO_Caja.CAJA_TCSunatVenta
            _caja.Guardar(x_usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GrabarPagos(ByVal x_usuario As String, ByVal m_tipopago As ETipos.TipoDePago, ByVal x_serie As String,
                                ByVal x_fecha As DateTime, ByVal x_tipocambio As Decimal, ByVal x_redondeo As TRedondeo, ByVal _SwitchSaldoAFavor As Boolean, ByVal ETipoRecibos As ETipos, ByVal _RucCliente As String)
        Dim ImporteAcumulado As Decimal : Dim _Moneda As String = ""
        Dim docve_codigoRecibo As String = ""
        Try
            DAEnterprise.BeginTransaction()
            Dim _i As Integer = 1
            Dim _numero As Integer = getNroTransaccion(m_pvent_id, x_serie)
            Dim _codigo As String = String.Format("{0:00}{1}{2:0000000}", m_pvent_id, x_serie, _numero)
            Dim _entid_Codigo As String = ""
            Dim _glosa As String = ""
            Dim _pagar As Decimal = 0
            Dim _factura As Decimal
            Dim _docCaja As New EVENT_DocsVenta
            Dim x_tipo_moneda As String
            Dim _diferencia As Decimal
            Dim _pagardiferencia As Decimal = 0
            For Each item As EVENT_DocsVenta In m_listVENT_PagosFacturas
                Dim _caja As New BTESO_Caja '1 Agarra Caja ==> almacena Todo el monto en caso de cancelaciones 
                _caja.TESO_Caja = item.TESO_Caja
                _caja.TESO_Caja.Instanciar(ACEInstancia.Nuevo)
                _caja.TESO_Caja.TIPOS_CodTipoMoneda = item.TIPOS_CodTipoMoneda
                _caja.TESO_Caja.TIPOS_CodTransaccion = ETipos.getTipoDePago(m_tipopago)
                _caja.TESO_Caja.CAJA_OrdenDocumento = _i
                _caja.TESO_Caja.CAJA_Pase = ACEVentas.Constantes.GetPase(ACEVentas.Constantes.Pase.Entrada)
                _caja.TESO_Caja.CAJA_NroDocumento = item.DOCVE_Codigo
                docve_codigoRecibo = item.DOCVE_Codigo
                _caja.TESO_Caja.CAJA_Fecha = x_fecha.Date
                _caja.TESO_Caja.CAJA_Codigo = _codigo
                _caja.TESO_Caja.CAJA_Serie = x_serie
                _caja.TESO_Caja.CAJA_Numero = _numero
                _caja.TESO_Caja.TIPOS_CodTipoDocumento = item.TIPOS_CodTipoDocumento

                _caja.TESO_Caja.CAJA_Glosa = IIf(m_tipopago = ETipos.TipoDePago.Efectivo, ACEVentas.Constantes.getGlosaTipoDePago(ETipos.TipoDePago.Efectivo),
                                                 ACEVentas.Constantes.getGlosaTipoDePago(m_tipopago)) & " - " & String.Format("{0}-{1:00000000}", item.DOCVE_Serie, item.DOCVE_Numero)
                _caja.TESO_Caja.CAJA_Importe = item.ImportePagar
                _caja.TESO_Caja.CAJA_ImporteVenta = item.DOCVE_TotalPagar
                ImporteAcumulado = item.ImportePagar 'Aqui extraemos el total del Pendiente para hacer la resta con el Recibo = > 
                _caja.TESO_Caja.ENTID_Codigo = item.ENTID_CodigoCliente
                _entid_Codigo = item.ENTID_CodigoCliente
                _caja.TESO_Caja.CAJA_Estado = ETESO_Caja.getEstado(ETESO_Caja.Estado.Ingresado)

                Select Case m_tipopago
                    Case ETipos.TipoDePago.NotaCredito
                        _caja.TESO_Caja.TIPOS_CodTipoOrigen = ETipos.getTipoOrigen(ETipos.OrigenCancelacion.CancelacionDocumentosVentas)
                    Case ETipos.TipoDocPago.SaldoAFavorClientes
                        _caja.TESO_Caja.TIPOS_CodTipoOrigen = ETipos.getTipoOrigen(ETipos.OrigenCancelacion.CancelacionDocumentosVentas)
                    Case Else
                        _caja.TESO_Caja.TIPOS_CodTipoOrigen = ETipos.getTipoOrigen(ETipos.OrigenCancelacion.CFacturas)
                End Select


                '

                _caja.TESO_Caja.CAJA_TCDocumento = x_tipocambio
                _caja.TESO_Caja.CAJA_TCOficinaVenta = m_tipocambiooficina.TIPOC_VentaOficina
                _caja.TESO_Caja.CAJA_TCPorUsuario = IIf(x_tipocambio = m_tipocambiosunat.TIPOC_VentaSunat, False, True)
                _caja.TESO_Caja.CAJA_TCSunatVenta = m_tipocambiosunat.TIPOC_VentaSunat
                _caja.TESO_Caja.CAJA_TCambio = m_tipocambiooficina.TIPOC_VentaOficina
                _caja.TESO_Caja.PVENT_Id = m_pvent_id
                Dim _whereCaja As New Hashtable : _whereCaja.Add("PVENT_Id", New ACWhere(_caja.TESO_Caja.PVENT_Id))
                _caja.TESO_Caja.CAJA_Id = _caja.getCorrelativo("CAJA_Id", _whereCaja)
                _i += 1
                _caja.Guardar(x_usuario, New String() {"CAJA_FechaPago"})

                x_tipo_moneda = item.TESO_Caja.TIPOS_CodMonedaPago

                '' Para el Redondeo
                _docCaja = item.Clone
                _factura += item.TESO_Caja.CAJA_Importe
                _pagardiferencia += item.TESO_Caja.CAJA_Importe
                _glosa &= String.Format("{0}, ", item.Documento)
            Next
            '' Verificar Redondeo
            If x_redondeo <> TRedondeo.SinRedondeo Then
                _pagar = 0
                For Each Pag As ETESO_DocsPagos In m_listteso_docspagos '2 ==> TESO_DocsPagos agarra esta tbala para hacer la segunda insercion by Fran
                    If x_tipo_moneda = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
                        If Pag.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
                            _pagar += Pag.DPAGO_Importe
                        Else
                            _pagar += Pag.DPAGO_Importe * x_tipocambio
                        End If
                    Else
                        If Pag.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
                            _pagar += Pag.DPAGO_Importe
                        Else
                            _pagar += Pag.DPAGO_Importe '/ x_tipocambio
                        End If
                    End If


                Next
                _diferencia = Math.Abs(_factura - _pagar)
                '' Aplicar Redondeo
                Select Case x_redondeo
                    Case TRedondeo.PorExcesoPago
                        _docCaja.TIPOS_CodTipoDocumento = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboIngreso)
                        GrabarCajaDocumento(_docCaja, ETipos.TipoDePago.ReciboEgresoRedondeo, _codigo, _diferencia, x_tipocambio, _glosa, x_usuario)
                        _i += 1
                    Case TRedondeo.PorFaltaPago
                        _docCaja.TIPOS_CodTipoDocumento = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboEgreso)
                        GrabarCajaDocumento(_docCaja, ETipos.TipoDePago.ReciboIngresoRedondeo, _codigo, -_diferencia, x_tipocambio, _glosa, x_usuario)
                        _i += 1
                    Case Else
                End Select
            End If

            Select Case m_tipopago'Selleciona tel Tipo de Cancelacion 
                Case ETipos.TipoDePago.DepositoBancario 'Si es deposito bancario pero adema va  aser un saldo a favor 
                    Dim _bteso_docspagos As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
                    Dim i As Integer = 1
                    For Each item As ETESO_DocsPagos In m_listteso_docspagos
                        _bteso_docspagos.TESO_DocsPagos = item
                        _bteso_docspagos.TESO_DocsPagos.ENTID_Codigo = _RucCliente

                        If _bteso_docspagos.TESO_DocsPagos.Nuevo Then

                            'NUEVO =====>GRABA --> TESO_DOCSPAGOS + TESO_CAJA_DOCSPAGOS + SI TIENE SALDO A FAVOR  GRABA UN RECIBO

                            '  Dim _bteso_docspagos As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)


                            _bteso_docspagos.TESO_DocsPagos = item
                            _bteso_docspagos.TESO_DocsPagos.ENTID_Codigo = _entid_Codigo
                            Dim _dpago_id As Integer = _bteso_docspagos.TESO_DocsPagos.DPAGO_Id
                            If _bteso_docspagos.TESO_DocsPagos.DPAGO_Id = 0 Then
                                _bteso_docspagos.TESO_DocsPagos.PVENT_Id = m_pvent_id
                                Dim _whereCaja As New Hashtable : _whereCaja.Add("PVENT_Id", New ACWhere(_bteso_docspagos.TESO_DocsPagos.PVENT_Id))
                                _dpago_id = _bteso_docspagos.getCorrelativo("DPAGO_Id", _whereCaja)
                                _bteso_docspagos.TESO_DocsPagos.DPAGO_Id = _dpago_id

                                Dim _whereNroDeposito As New Hashtable
                                _whereNroDeposito.Add("DPAGO_Numero", New ACWhere(_bteso_docspagos.TESO_DocsPagos.DPAGO_Numero))
                                _whereNroDeposito.Add("CUENT_Id", New ACWhere(_bteso_docspagos.TESO_DocsPagos.CUENT_Id))
                                _whereNroDeposito.Add("BANCO_Id", New ACWhere(_bteso_docspagos.TESO_DocsPagos.BANCO_Id))
                                Dim _bteso_dp As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
                                If _bteso_dp.Cargar(_whereNroDeposito) Then
                                    Throw New Exception("El Documento con el que desea cancelar ya fue ingresado, en el mismo Banco, misma cuenta, y el mismo numero, revise el numero del documento y vuelva a intentarlo")
                                End If

                                If _bteso_docspagos.Guardar(x_usuario) Then
                                    Dim _bteso_cajadocspago As New BTESO_CajaDocsPago
                                    _bteso_cajadocspago.TESO_CajaDocsPago = New ETESO_CajaDocsPago
                                    _bteso_cajadocspago.TESO_CajaDocsPago.Instanciar(ACEInstancia.Nuevo)
                                    _bteso_cajadocspago.TESO_CajaDocsPago.PVENT_Id = m_pvent_id
                                    _bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Codigo = _codigo
                                    _bteso_cajadocspago.TESO_CajaDocsPago.DPAGO_Id = _dpago_id
                                    _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Importe = item.DPAGO_Importe
                                    _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Numero = i
                                    _bteso_cajadocspago.Guardar(x_usuario)
                                    i += 1
                                End If
                            Else
                                Dim _bteso_cajadocspago As New BTESO_CajaDocsPago
                                _bteso_cajadocspago.TESO_CajaDocsPago = New ETESO_CajaDocsPago
                                _bteso_cajadocspago.TESO_CajaDocsPago.Instanciar(ACEInstancia.Nuevo)
                                _bteso_cajadocspago.TESO_CajaDocsPago.PVENT_Id = m_pvent_id
                                _bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Codigo = _codigo
                                _bteso_cajadocspago.TESO_CajaDocsPago.DPAGO_Id = _dpago_id
                                _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Importe = item.DPAGO_Importe
                                _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Numero = i
                                _bteso_cajadocspago.Guardar(x_usuario)
                                i += 1
                            End If

                            If _SwitchSaldoAFavor = True Then 'SI EL CHECK ESTA ACTIVO ==> ENTONCES SE GENERA UN SALDO A FAVOR 


                                Dim _bteso_recibos As New BTRAN_Recibos
                                _bteso_recibos.TRAN_Recibos = New ETRAN_Recibos
                                _bteso_recibos.TRAN_Recibos.Instanciar(ACEInstancia.Nuevo)

                                _bteso_recibos.TRAN_Recibos.TIPOS_CodTransaccion = ETipoRecibos.TIPOS_Codigo
                                'Comprobamso el tipos de recibo 
                                If ETipoRecibos.TIPOS_Codigo = (ETipos.getTipo(ETipos.TransaccionTRecibos.AFavorCliente)) Then 'VA  A SER DE INGRESO 

                                    _bteso_recibos.TRAN_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboAFavorCliente)

                                End If

                                If _bteso_recibos.GetSeries(m_zonas_codigo, m_sucur_id, m_pvent_id, _bteso_recibos.TRAN_Recibos.TIPOS_CodTipoRecibo) Then
                                    _bteso_recibos.TRAN_Recibos.RECIB_Serie = _bteso_recibos.ListVENT_PVentDocumento(0).PVDOCU_Serie
                                    Dim where As New Hashtable
                                    where.Add("TIPOS_CodTipoRecibo", New ACWhere(_bteso_recibos.TRAN_Recibos.TIPOS_CodTipoRecibo))

                                    where.Add("RECIB_Serie", New ACWhere(_bteso_recibos.TRAN_Recibos.RECIB_Serie))
                                    _bteso_recibos.TRAN_Recibos.RECIB_Numero = _bteso_recibos.getCorrelativo("RECIB_Numero", where)

                                End If
                                'Vamos a Crear el Correlativo de Los recibos para y el gloasa para concatenacion
                                _bteso_recibos.TRAN_Recibos.RECIB_Codigo = String.Format("{0}{1}{2:0000000}", _bteso_recibos.TRAN_Recibos.TIPOS_CodTipoRecibo.Substring(3, 2),
                                                                                           _bteso_recibos.TRAN_Recibos.RECIB_Serie.PadLeft(3, "0"),
                                                                                           _bteso_recibos.TRAN_Recibos.RECIB_Numero)
                                _bteso_recibos.TRAN_Recibos.TIPOS_CodTipoMoneda = item.TIPOS_CodTipoMoneda
                                _bteso_recibos.TRAN_Recibos.PVENT_Id = m_pvent_id
                                _bteso_recibos.TRAN_Recibos.RECIB_Fecha = x_fecha
                                _bteso_recibos.TRAN_Recibos.RECIB_De = "CAJA - " & x_usuario
                                _bteso_recibos.TRAN_Recibos.RECIB_Monto = item.DPAGO_Importe - ImporteAcumulado
                                _bteso_recibos.TRAN_Recibos.RECIB_Concepto = String.Format("{3} del deposito {0} OP: {1} ({2:dd/MM/yyyy})",
                                                                                      item.BANCO_Descripcion, item.DPAGO_Numero, item.DPAGO_Fecha,
                                                                                      ETipoRecibos.TIPOS_Descripcion)
                                _bteso_recibos.TRAN_Recibos.ZONAS_Codigo = m_zonas_codigo
                                _bteso_recibos.TRAN_Recibos.SUCUR_Id = m_sucur_id
                                _bteso_recibos.TRAN_Recibos.RECIB_DPAGO_Id = _dpago_id
                                _bteso_recibos.TRAN_Recibos.RECIB_DOCVE_Codigo = "" 'AQUI ES NULO YA QUE NO SE INSERTAR PORQUE AL CREAR UN NUEVO DEPOSITO SE VA A CREAR UN NUEVO RECIBO QUE NO ESTA AMARRADO A NADA ESTA SIN USAR EL SALDO A FAVOR OJOJOJO  FRANK 
                                ' _bteso_recibos.TRAN_Recibos.ENTID_Codigo = _RucCliente
                                '  _bteso_recibos.TRAN_Recibos.DPAGO_Id = item.DPAGO_Id
                                _bteso_recibos.TRAN_Recibos.TIPOS_CodTransaccion = ETipos.getTipo(ETipos.TransaccionTRecibos.AFavorCliente)
                                _bteso_recibos.Guardar(x_usuario)

                                'Grabamos el Recibos Con la Capa de VENTAS 
                                '=********************************G R A B A  E L  R E C I B O - C O N  - V E N T A S ****************************************************************************************************
                                'Dim _bteso_recibos As New BTESO_Recibos
                                '_bteso_recibos.TESO_Recibos = New ETESO_Recibos
                                '_bteso_recibos.TESO_Recibos.Instanciar(ACEInstancia.Nuevo)

                                '_bteso_recibos.TESO_Recibos.TIPOS_CodTransaccion = ETipoRecibos.TIPOS_Codigo
                                ''Comprobamso el tipos de recibo 
                                'If ETipoRecibos.TIPOS_Codigo = (ETipos.getTipo(ETipos.TransaccionTRecibos.AFavorCliente)) Then 'VA  A SER DE INGRESO 

                                '    _bteso_recibos.TESO_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboAFavorCliente)

                                'End If

                                'If _bteso_recibos.GetSeries("TRA", m_zonas_codigo, m_sucur_id, m_pvent_id, _bteso_recibos.TESO_Recibos.TIPOS_CodTipoRecibo) Then
                                '    _bteso_recibos.TESO_Recibos.RECIB_Serie = _bteso_recibos.ListVENT_PVentDocumento(0).PVDOCU_Serie
                                '    Dim where As New Hashtable
                                '    where.Add("TIPOS_CodTipoRecibo", New ACWhere(_bteso_recibos.TESO_Recibos.TIPOS_CodTipoRecibo))

                                '    where.Add("RECIB_Serie", New ACWhere(_bteso_recibos.TESO_Recibos.RECIB_Serie))
                                '    _bteso_recibos.TESO_Recibos.RECIB_Numero = _bteso_recibos.getCorrelativo("RECIB_Numero", where)

                                'End If
                                ''Vamos a Crear el Correlativo de Los recibos para y el gloasa para concatenacion
                                '_bteso_recibos.TESO_Recibos.RECIB_Codigo = String.Format("{0}{1}{2:0000000}", _bteso_recibos.TESO_Recibos.TIPOS_CodTipoRecibo.Substring(3, 2),
                                '                                                           _bteso_recibos.TESO_Recibos.RECIB_Serie.PadLeft(3, "0"),
                                '                                                           _bteso_recibos.TESO_Recibos.RECIB_Numero)
                                '_bteso_recibos.TESO_Recibos.TIPOS_CodTipoMoneda = item.TIPOS_CodTipoMoneda
                                '_bteso_recibos.TESO_Recibos.PVENT_Id = m_pvent_id
                                '_bteso_recibos.TESO_Recibos.RECIB_Fecha = x_fecha
                                '_bteso_recibos.TESO_Recibos.RECIB_RecibiDe = "CAJA - " & x_usuario
                                '_bteso_recibos.TESO_Recibos.RECIB_Importe = item.DPAGO_Importe - ImporteAcumulado
                                '_bteso_recibos.TESO_Recibos.RECIB_Concepto = String.Format("{3} del deposito {0} OP: {1} ({2:dd/MM/yyyy})",
                                '                                                      item.BANCO_Descripcion, item.DPAGO_Numero, item.DPAGO_Fecha,
                                '                                                      ETipoRecibos.TIPOS_Descripcion)
                                '_bteso_recibos.TESO_Recibos.ENTID_Codigo = _RucCliente
                                '_bteso_recibos.TESO_Recibos.DPAGO_Id = item.DPAGO_Id
                                '_bteso_recibos.TESO_Recibos.TIPOS_CodTransaccion = ETipos.getTipo(ETipos.TransaccionTRecibos.AFavorCliente)
                                '_bteso_recibos.Guardar(x_usuario)

                            End If

                            ' Next

                        Else
                            '***************************===============YA EXISTE TESO_DOCSPAFOS ==> SOLO GRABA  TESO_CAJA-DOCS-PAGOS + IF ES SALDO A FAVOR GRABA RECIBO 
                            ' Dim i As Integer = 1
                            'For Each item As ETESO_DocsPagos In m_listteso_docspagos 'Recorremos los pagos que tiene pendientes
                            Dim _dpago_id As Integer = _bteso_docspagos.TESO_DocsPagos.DPAGO_Id
                        Dim _bteso_cajadocspago As New BTESO_CajaDocsPago
                        _bteso_cajadocspago.TESO_CajaDocsPago = New ETESO_CajaDocsPago
                        _bteso_cajadocspago.TESO_CajaDocsPago.Instanciar(ACEInstancia.Nuevo)
                        _bteso_cajadocspago.TESO_CajaDocsPago.PVENT_Id = m_pvent_id
                        _bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Codigo = _codigo
                        _bteso_cajadocspago.TESO_CajaDocsPago.DPAGO_Id = _dpago_id
                        _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Importe = item.ImporteUsado
                        _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Numero = i
                        '_bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Id = item.
                        _bteso_cajadocspago.Guardar(x_usuario)
                        i += 1
                            If _SwitchSaldoAFavor = True Then


                                Dim _bteso_recibos As New BTRAN_Recibos
                                _bteso_recibos.TRAN_Recibos = New ETRAN_Recibos
                                _bteso_recibos.TRAN_Recibos.Instanciar(ACEInstancia.Nuevo)

                                _bteso_recibos.TRAN_Recibos.TIPOS_CodTransaccion = ETipoRecibos.TIPOS_Codigo
                                'Comprobamso el tipos de recibo 
                                If ETipoRecibos.TIPOS_Codigo = (ETipos.getTipo(ETipos.TransaccionTRecibos.AFavorCliente)) Then 'VA  A SER DE INGRESO 

                                    _bteso_recibos.TRAN_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboAFavorCliente)

                                End If

                                If _bteso_recibos.GetSeries(m_zonas_codigo, m_sucur_id, m_pvent_id, _bteso_recibos.TRAN_Recibos.TIPOS_CodTipoRecibo) Then
                                    _bteso_recibos.TRAN_Recibos.RECIB_Serie = _bteso_recibos.ListVENT_PVentDocumento(0).PVDOCU_Serie
                                    Dim where As New Hashtable
                                    where.Add("TIPOS_CodTipoRecibo", New ACWhere(_bteso_recibos.TRAN_Recibos.TIPOS_CodTipoRecibo))

                                    where.Add("RECIB_Serie", New ACWhere(_bteso_recibos.TRAN_Recibos.RECIB_Serie))
                                    _bteso_recibos.TRAN_Recibos.RECIB_Numero = _bteso_recibos.getCorrelativo("RECIB_Numero", where)

                                End If
                                'Vamos a Crear el Correlativo de Los recibos para y el gloasa para concatenacion
                                _bteso_recibos.TRAN_Recibos.RECIB_Codigo = String.Format("{0}{1}{2:0000000}", _bteso_recibos.TRAN_Recibos.TIPOS_CodTipoRecibo.Substring(3, 2),
                                                                                           _bteso_recibos.TRAN_Recibos.RECIB_Serie.PadLeft(3, "0"),
                                                                                           _bteso_recibos.TRAN_Recibos.RECIB_Numero)
                                _bteso_recibos.TRAN_Recibos.TIPOS_CodTipoMoneda = item.TIPOS_CodTipoMoneda
                                _bteso_recibos.TRAN_Recibos.PVENT_Id = m_pvent_id
                                _bteso_recibos.TRAN_Recibos.RECIB_Fecha = x_fecha
                                _bteso_recibos.TRAN_Recibos.RECIB_De = "CAJA - " & x_usuario
                                _bteso_recibos.TRAN_Recibos.RECIB_Monto = item.DPAGO_Importe - ImporteAcumulado
                                _bteso_recibos.TRAN_Recibos.RECIB_Concepto = String.Format("{3} del deposito {0} OP: {1} ({2:dd/MM/yyyy})",
                                                                                      item.BANCO_Descripcion, item.DPAGO_Numero, item.DPAGO_Fecha,
                                                                                      ETipoRecibos.TIPOS_Descripcion)
                                ' _bteso_recibos.TRAN_Recibos.ENTID_Codigo = _RucCliente
                                '  _bteso_recibos.TRAN_Recibos.DPAGO_Id = item.DPAGO_Id
                                _bteso_recibos.TRAN_Recibos.TIPOS_CodTransaccion = ETipos.getTipo(ETipos.TransaccionTRecibos.AFavorCliente)
                                _bteso_recibos.TRAN_Recibos.ZONAS_Codigo = m_zonas_codigo
                                _bteso_recibos.TRAN_Recibos.SUCUR_Id = m_sucur_id
                                _bteso_recibos.TRAN_Recibos.RECIB_DPAGO_Id = item.DPAGO_Id
                                _bteso_recibos.TRAN_Recibos.RECIB_DOCVE_Codigo = docve_codigoRecibo 'AQUI SI SE VA A USAR EL NUMERO DE FACTURA YA QUE ESTE RECIBO YA SE ESTA ASIGNANDO A UNA FACTURA 
                                _bteso_recibos.Guardar(x_usuario)

                                'Dim _bteso_recibos As New BTESO_Recibos
                                '_bteso_recibos.TESO_Recibos = New ETESO_Recibos
                                '_bteso_recibos.TESO_Recibos.Instanciar(ACEInstancia.Nuevo)

                                '_bteso_recibos.TESO_Recibos.TIPOS_CodTransaccion = ETipoRecibos.TIPOS_Codigo
                                ''Comprobamso el tipos de recibo 
                                'If ETipoRecibos.TIPOS_Codigo = (ETipos.getTipo(ETipos.TransaccionTRecibos.AFavorCliente)) Then 'VA  A SER DE INGRESO 

                                '    _bteso_recibos.TESO_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboAFavorCliente)

                                'End If

                                'If _bteso_recibos.GetSeries("TRA", m_zonas_codigo, m_sucur_id, m_pvent_id, _bteso_recibos.TESO_Recibos.TIPOS_CodTipoRecibo) Then
                                '    _bteso_recibos.TESO_Recibos.RECIB_Serie = _bteso_recibos.ListVENT_PVentDocumento(0).PVDOCU_Serie
                                '    Dim where As New Hashtable
                                '    where.Add("TIPOS_CodTipoRecibo", New ACWhere(_bteso_recibos.TESO_Recibos.TIPOS_CodTipoRecibo))

                                '    where.Add("RECIB_Serie", New ACWhere(_bteso_recibos.TESO_Recibos.RECIB_Serie))
                                '    _bteso_recibos.TESO_Recibos.RECIB_Numero = _bteso_recibos.getCorrelativo("RECIB_Numero", where)

                                'End If
                                ''Vamos a Crear el Correlativo de Los recibos para y el gloasa para concatenacion
                                '_bteso_recibos.TESO_Recibos.RECIB_Codigo = String.Format("{0}{1}{2:0000000}", _bteso_recibos.TESO_Recibos.TIPOS_CodTipoRecibo.Substring(3, 2),
                                '                                                           _bteso_recibos.TESO_Recibos.RECIB_Serie.PadLeft(3, "0"),
                                '                                                           _bteso_recibos.TESO_Recibos.RECIB_Numero)
                                '_bteso_recibos.TESO_Recibos.TIPOS_CodTipoMoneda = item.TIPOS_CodTipoMoneda
                                '_bteso_recibos.TESO_Recibos.PVENT_Id = m_pvent_id
                                '_bteso_recibos.TESO_Recibos.RECIB_Fecha = x_fecha
                                '_bteso_recibos.TESO_Recibos.RECIB_RecibiDe = "CAJA - " & x_usuario
                                '_bteso_recibos.TESO_Recibos.RECIB_Importe = item.DPAGO_Importe - ImporteAcumulado
                                '_bteso_recibos.TESO_Recibos.RECIB_Concepto = String.Format("{3} del deposito {0} OP: {1} ({2:dd/MM/yyyy})",
                                '                                                      item.BANCO_Descripcion, item.DPAGO_Numero, item.DPAGO_Fecha,
                                '                                                      ETipoRecibos.TIPOS_Descripcion)
                                '_bteso_recibos.TESO_Recibos.ENTID_Codigo = _RucCliente
                                '_bteso_recibos.TESO_Recibos.DPAGO_Id = item.DPAGO_Id
                                '_bteso_recibos.TESO_Recibos.TIPOS_CodTransaccion = ETipos.getTipo(ETipos.TransaccionTRecibos.AFavorCliente)
                                '_bteso_recibos.Guardar(x_usuario)
                            End If

                        End If
                    Next

                Case ETipos.TipoDePago.Detraccion
                    Dim _bteso_docspagos As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
                    Dim i As Integer = 1
                    For Each item As ETESO_DocsPagos In m_listteso_docspagos
                        _bteso_docspagos.TESO_DocsPagos = item
                        _bteso_docspagos.TESO_DocsPagos.ENTID_Codigo = _entid_Codigo
                        _bteso_docspagos.TESO_DocsPagos.PVENT_Id = m_pvent_id
                        Dim _dpago_id As Integer = _bteso_docspagos.TESO_DocsPagos.DPAGO_Id
                        If _bteso_docspagos.TESO_DocsPagos.DPAGO_Id = 0 Then
                            Dim _whereCaja As New Hashtable : _whereCaja.Add("PVENT_Id", New ACWhere(_bteso_docspagos.TESO_DocsPagos.PVENT_Id))
                            _dpago_id = _bteso_docspagos.getCorrelativo("DPAGO_Id", _whereCaja)
                            _bteso_docspagos.TESO_DocsPagos.DPAGO_Id = _dpago_id

                            Dim _whereNroDeposito As New Hashtable
                            _whereNroDeposito.Add("DPAGO_Numero", New ACWhere(_bteso_docspagos.TESO_DocsPagos.DPAGO_Numero))
                            _whereNroDeposito.Add("CUENT_Id", New ACWhere(_bteso_docspagos.TESO_DocsPagos.CUENT_Id))
                            _whereNroDeposito.Add("BANCO_Id", New ACWhere(_bteso_docspagos.TESO_DocsPagos.BANCO_Id))
                            Dim _bteso_dp As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
                            If _bteso_dp.Cargar(_whereNroDeposito) Then
                                Throw New Exception("El Documento con el que desea cancelar ya fue ingresado, en el mismo Banco, misma cuenta, y el mismo numero, revise el numero del documento y vuelva a intentarlo")
                            End If

                            If _bteso_docspagos.Guardar(x_usuario) Then
                                Dim _bteso_cajadocspago As New BTESO_CajaDocsPago
                                _bteso_cajadocspago.TESO_CajaDocsPago = New ETESO_CajaDocsPago
                                _bteso_cajadocspago.TESO_CajaDocsPago.Instanciar(ACEInstancia.Nuevo)
                                _bteso_cajadocspago.TESO_CajaDocsPago.PVENT_Id = m_pvent_id
                                _bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Codigo = _codigo
                                _bteso_cajadocspago.TESO_CajaDocsPago.DPAGO_Id = _dpago_id
                                _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Importe = item.ImporteUsado
                                _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Numero = i
                                '_bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Id = item.
                                _bteso_cajadocspago.Guardar(x_usuario)
                                i += 1
                            End If
                        Else
                            Dim _bteso_cajadocspago As New BTESO_CajaDocsPago
                            _bteso_cajadocspago.TESO_CajaDocsPago = New ETESO_CajaDocsPago
                            _bteso_cajadocspago.TESO_CajaDocsPago.Instanciar(ACEInstancia.Nuevo)
                            _bteso_cajadocspago.TESO_CajaDocsPago.PVENT_Id = m_pvent_id
                            _bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Codigo = _codigo
                            _bteso_cajadocspago.TESO_CajaDocsPago.DPAGO_Id = _dpago_id
                            _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Importe = item.DPAGO_Importe
                            _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Numero = i
                            '_bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Id = item.
                            _bteso_cajadocspago.Guardar(x_usuario)
                            i += 1
                        End If

                    Next
                Case ETipos.TipoDePago.NotaCredito
                    '' Grabar Documentos que Pagan
                    Dim _bteso_docspagos As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
                    Dim i As Integer = 1
                    For Each item As ETESO_DocsPagos In m_listteso_docspagos
                        _bteso_docspagos.TESO_DocsPagos = item
                        _bteso_docspagos.TESO_DocsPagos.Instanciar(ACEInstancia.Nuevo)
                        _bteso_docspagos.TESO_DocsPagos.ENTID_Codigo = _entid_Codigo
                        _bteso_docspagos.TESO_DocsPagos.DPAGO_Numero = String.Format(m_dtGCancelacion.Rows(0)("NC")) 'String.Format("NC {0}-{1:0000000}", _bteso_docspagos.TESO_DocsPagos.VENT_DocsVenta.DOCVE_Serie, _bteso_docspagos.TESO_DocsPagos.VENT_DocsVenta.DOCVE_Numero)
                        _bteso_docspagos.TESO_DocsPagos.PVENT_Id = m_pvent_id
                        Dim _whereCaja As New Hashtable : _whereCaja.Add("PVENT_Id", New ACWhere(_bteso_docspagos.TESO_DocsPagos.PVENT_Id))
                        _bteso_docspagos.TESO_DocsPagos.DPAGO_Id = _bteso_docspagos.getCorrelativo("DPAGO_Id", _whereCaja)
                        If _bteso_docspagos.Guardar(x_usuario) Then
                            Dim _bteso_cajadocspago As New BTESO_CajaDocsPago
                            _bteso_cajadocspago.TESO_CajaDocsPago = New ETESO_CajaDocsPago
                            _bteso_cajadocspago.TESO_CajaDocsPago.Instanciar(ACEInstancia.Nuevo)
                            _bteso_cajadocspago.TESO_CajaDocsPago.PVENT_Id = m_pvent_id
                            _bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Codigo = _codigo
                            _bteso_cajadocspago.TESO_CajaDocsPago.DPAGO_Id = _bteso_docspagos.TESO_DocsPagos.DPAGO_Id
                            _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Importe = item.ImporteUsado
                            _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Numero = i
                            _bteso_cajadocspago.Guardar(x_usuario)
                            i += 1
                        End If
                        '' Grabar Nota de Credito
                        _bteso_docspagos.TESO_DocsPagos.VENT_DocsVenta.ENTID_CodigoCliente = _entid_Codigo
                        Dim m_bgenerardocsventa As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
                        Dim x_msg As String = ""
                        m_bgenerardocsventa.VENT_DocsVenta = _bteso_docspagos.TESO_DocsPagos.VENT_DocsVenta
                        m_bgenerardocsventa.VENT_DocsVenta.Instanciar(ACEInstancia.Nuevo)
                        m_bgenerardocsventa.VENT_DocsVenta.DOCVE_Estado = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Ingresado)
                        m_bgenerardocsventa.VENT_DocsVenta.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                        Dim _detalle As New EVENT_DocsVentaDetalle
                        _detalle.DOCVD_PrecioUnitario = m_bgenerardocsventa.VENT_DocsVenta.DOCVE_ImporteVenta
                        _detalle.DOCVD_SubImporteVenta = m_bgenerardocsventa.VENT_DocsVenta.DOCVE_ImporteVenta
                        _detalle.DOCVD_Cantidad = 1
                        'm_bgenerardocsventa.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Add(_detalle)
                        'If Not m_bgenerardocsventa.generarDocumento(x_usuario, m_bgenerardocsventa.VENT_DocsVenta.DOCVE_FechaDocumento, _
                        '                                        m_bgenerardocsventa.VENT_DocsVenta.DOCVE_Serie, _
                        '                                        m_bgenerardocsventa.VENT_DocsVenta.DOCVE_Numero, "E", x_msg, False) Then
                        '   Throw New Exception("No Se puede Generar el Documento Nota de Credito")
                        'End If
                    Next
                Case ETipos.TipoDePago.RecEgreInterno
                    Dim _bteso_docspagos As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
                    Dim i As Integer = 1
                    For Each item As ETESO_DocsPagos In m_listteso_docspagos
                        _bteso_docspagos.TESO_DocsPagos = item
                        _bteso_docspagos.TESO_DocsPagos.ENTID_Codigo = _entid_Codigo
                        _bteso_docspagos.TESO_DocsPagos.PVENT_Id = m_pvent_id

                        Dim _whereCaja As New Hashtable : _whereCaja.Add("PVENT_Id", New ACWhere(_bteso_docspagos.TESO_DocsPagos.PVENT_Id))
                        _bteso_docspagos.TESO_DocsPagos.DPAGO_Id = _bteso_docspagos.getCorrelativo("DPAGO_Id", _whereCaja)
                        If _bteso_docspagos.Guardar(x_usuario) Then
                            Dim _bteso_cajadocspago As New BTESO_CajaDocsPago
                            _bteso_cajadocspago.TESO_CajaDocsPago = New ETESO_CajaDocsPago
                            _bteso_cajadocspago.TESO_CajaDocsPago.Instanciar(ACEInstancia.Nuevo)
                            _bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Codigo = _codigo
                            _bteso_cajadocspago.TESO_CajaDocsPago.DPAGO_Id = _bteso_docspagos.TESO_DocsPagos.DPAGO_Id
                            _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Importe = item.ImporteUsado
                            _bteso_cajadocspago.TESO_CajaDocsPago.PVENT_Id = m_pvent_id
                            _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Numero = i
                            _bteso_cajadocspago.Guardar(x_usuario)
                            i += 1
                        End If
                    Next


                    'Agregamos siel pago es Saldo a favor 



            End Select
            DAEnterprise.CommitTransaction()
            Return True
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function
#End Region

End Class

