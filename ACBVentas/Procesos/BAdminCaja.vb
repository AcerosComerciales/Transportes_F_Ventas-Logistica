Imports ACDVentas
Imports ACEVentas

Imports ACFramework
Imports DAConexion

Public Class BAdminCaja
#Region " Variables "
    Private d_administracioncaja As DAdminCaja
    Private d_cajachicapago As DTESO_CajaChicaPagos
    Private m_list_cajachicaingreso As List(Of ETESO_CajaChicaIngreso)
    Private m_list_cajaDocsPago As List(Of ETESO_CajaDocsPago)

    Private m_tipocambiosunat As ETipoCambio
   Private m_tipocambiooficina As ETipoCambio

    Private m_listVENT_PagosFacturas As List(Of EVENT_DocsVenta)
   Private m_listccuadrependientes As List(Of ECCuadrePendientes)
    Private m_listteso_cajapagos As List(Of ETESO_Caja)
    Private m_listTESO_Recibos As List(Of ETESO_Recibos) '_M
   Private m_listteso_docspagos As List(Of ETESO_DocsPagos)
   Private m_listvent_docsventa As List(Of EVENT_DocsVenta)
   Private m_listEntidades As List(Of EEntidades)

   Private m_dtGCancelacion As DataTable
   Private m_dsGCancelacion As DataSet

   Private m_zonas_codigo As String
   Private m_sucursal As Integer
   Private m_pvent_id As Integer
   Private m_periodo As String

   Private m_entid_codigovendedor As String
   Private m_porcentajeigv As Decimal

   Private m_app As String

   Public Enum TRedondeo
      SinRedondeo
      PorExcesoPago
      PorFaltaPago
   End Enum

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

   Public Property TipoCambioOficina() As ETipoCambio
      Get
         Return m_tipocambiooficina
      End Get
      Set(ByVal value As ETipoCambio)
         m_tipocambiooficina = value
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

   Public Property ListTESO_CajaPagos() As List(Of ETESO_Caja)
      Get
         Return m_listteso_cajapagos
      End Get
      Set(ByVal value As List(Of ETESO_Caja))
         m_listteso_cajapagos = value
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
    '''frank
    'Public Property ListTESO_CajaChicaIngresos() As List(Of ETESO_CajaChicaIngreso)
    '    Get
    '        Return m_list_cajachicapago
    '    End Get
    '    Set(ByVal value As List(Of ETESO_CajaChicaIngreso))
    '        m_list_cajachicapago = value
    '    End Set
    'End Property
    '_M
    Public Property ListTESO_Recibos() As List(Of ETESO_Recibos)
        Get
            Return m_listTESO_Recibos
        End Get
        Set(ByVal value As List(Of ETESO_Recibos))
            m_listTESO_Recibos = value
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

   Public Property ListEntidades() As List(Of EEntidades)
      Get
         Return m_listEntidades
      End Get
      Set(ByVal value As List(Of EEntidades))
         m_listEntidades = value
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

   Public Property ENTID_CodigoVendedor() As String
      Get
         Return m_entid_codigovendedor
      End Get
      Set(ByVal value As String)
         m_entid_codigovendedor = value
      End Set
   End Property

   Public Property PorcentajeIGV() As Decimal
      Get
         Return m_porcentajeigv
      End Get
      Set(ByVal value As Decimal)
         m_porcentajeigv = value
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

   Public Property ListCCuadrePendientes() As List(Of ECCuadrePendientes)
      Get
         Return m_listccuadrependientes
      End Get
      Set(ByVal value As List(Of ECCuadrePendientes))
         m_listccuadrependientes = value
      End Set
   End Property
#End Region

#Region " Constructores "

   ''' <summary>
   ''' Constructor
   ''' </summary>
   ''' <param name="x_zona">Codigo de la zona</param>
   ''' <param name="x_sucursal">Codigo de la sucursal</param>
   ''' <param name="x_pvent_id">Codigo del punto de venta</param>
   ''' <param name="x_periodo">Periodo activo</param>
   ''' <remarks></remarks>
   Public Sub New(ByVal x_zona As String, ByVal x_sucursal As Integer, ByVal x_pvent_id As Integer, ByVal x_periodo As String)
      m_zonas_codigo = x_zona
      m_sucursal = x_sucursal
      m_pvent_id = x_pvent_id
      m_periodo = x_periodo
      d_administracioncaja = New DAdminCaja()
   End Sub
      Public Sub New(ByVal x_zona As String, ByVal x_sucursal As Integer, ByVal x_periodo As String)
      m_zonas_codigo = x_zona
      m_sucursal = x_sucursal
      m_periodo = x_periodo
      d_administracioncaja = New DAdminCaja()
   End Sub
#End Region

#Region " Metodos "

   ''' <summary>
   ''' Genera el numero de transacción para la tabla Tesoreria.TESO_Caja
   ''' </summary>
   ''' <param name="x_pvent_id">Codigo del punto de venta</param>
   ''' <param name="x_serie">Serie de la tabla TESO_Caja</param>
   ''' <returns>Devuelve el valor encontrado, despues de ejecutar la consulta</returns>
   ''' <remarks></remarks>
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
    ' obtener el correlativo del recibo devolucion
    ' </summary>
    ' <param name="x_orden_serie">serie de la orden de recojo</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function GetCorrelativoRD(ByVal x_tipo As String) As Integer
        Try
            Dim _where As New Hashtable
            _where.Add("TIPOS_CodTipoRecibo", New ACWhere(x_tipo))
            Dim m_dist_ordenes As New BTESO_Recibos
            Return m_dist_ordenes.getCorrelativo("RECIB_Numero", _where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetClienteRD(ByVal x_codigo As String) As String
      Try
         Dim _where As New Hashtable
         _where.Add("ENTID_Codigo", New ACWhere(x_codigo))
         Dim m_dist_ordenes As New BTESO_Recibos
         Return m_dist_ordenes.getENTIDAD("ENTID_RazonSocial", _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function


   Public Function VerificarCheque()
      Try

      Catch ex As Exception
         Throw ex
      End Try
   End Function

#Region " Consultas "
   ''' <summary> 
   ''' Capa de Negocio: TRAN_CAJASS_FacturasXCancelar
   ''' </summary>
   ''' <param name="x_entid_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function CargarFacturasXCancelar(ByVal x_entid_codigo As String, ByVal x_pvent_id As Long) As Boolean
      m_listvent_docsventa = New List(Of EVENT_DocsVenta)
      Try
         Return d_administracioncaja.TRAN_CAJASS_FacturasXCancelar(m_listvent_docsventa, x_entid_codigo, x_pvent_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: VEN_CAJASS_FacturasXCancelar
   ''' </summary>
   ''' <param name="x_entid_codigo">Parametro 1: </param> 
   ''' <param name="x_pvent_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VEN_CAJASS_FacturasXCancelar(ByVal x_entid_codigo As String, ByVal x_pvent_id As Long) As Boolean
      m_listvent_docsventa = New List(Of EVENT_DocsVenta)
      Try
         Return d_administracioncaja.VEN_CAJASS_FacturasXCancelar(m_listvent_docsventa, x_entid_codigo, x_pvent_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Obtener listado de clientes
   ''' </summary>
   ''' <param name="x_cadena">Cadena de busqueda</param>
   ''' <param name="x_campo">Campo sobre el cual se buscara cadena</param>
   ''' <param name="x_todos">Opcion para poder buscar todos los clientes</param>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function getClientes(ByVal x_cadena As String, ByVal x_campo As Short, ByVal x_todos As Boolean) As Boolean
      Try
         Dim _entidades As New BEntidades
         If _entidades.ENTISS_BuscarClientes(x_cadena, x_campo) Then
            m_listEntidades = New List(Of EEntidades)(_entidades.ListEntidades)
            Return True
         Else
            m_listEntidades = New List(Of EEntidades)
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Obtener el listado de clientes
   ''' </summary>
   ''' <param name="x_cadena">Cadena de busqueda</param>
   ''' <param name="x_campo">Campo sobre el cual se busca cadena</param>
   ''' <param name="x_todos"></param>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
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

   ''' <summary>
   ''' Genera los Join para la consulta de clientes
   ''' </summary>
   ''' <param name="_join"></param>
   ''' <param name="_where"></param>
   ''' <param name="x_todos"></param>
   ''' <remarks></remarks>
   Private Sub setJoinWhereEntidad(ByRef _join As List(Of ACJoin), ByRef _where As Hashtable, ByVal x_todos As Boolean)
      Try
         _join.Add(New ACJoin(EVENT_DocsVenta.Esquema, EVENT_DocsVenta.Tabla, "Vent", ACJoin.TipoJoin.Left _
                            , New ACCampos() {New ACCampos("ENTID_CodigoCliente", "ENTID_Codigo")} _
                            , New ACCampos() {}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                            , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_DocumentoCorto") _
                                              , New ACCampos("TIPOS_Descripcion", "TIPOS_Documento")}))
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   ''' <summary>
   ''' Cargar la ayuda de busqueda de documentos de pago, todos los pago a favor del cliente
   ''' </summary>
   ''' <param name="x_fecini"></param>
   ''' <param name="x_fecfin"></param>
   ''' <param name="x_entid_codigo"></param>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function Ayuda(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String) As Boolean
      Try
         Dim _docspago As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucursal)
         If _docspago.Ayuda(x_fecini, x_fecfin, x_entid_codigo) Then
            m_dtGCancelacion = New DataTable() : m_dtGCancelacion = _docspago.DTTESO_DocsPagos
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    ''' <summary>
    ''' Cargar la ayuda de busqueda de documentos de pago, todos los pago a favor del cliente
    ''' </summary>
    ''' <param name="x_fecini"></param>
    ''' <param name="x_fecfin"></param>
    ''' <param name="x_entid_codigo"></param>
    ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
    ''' <remarks></remarks>
    Public Function AyudaNC(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String, x_entid_CodigoDoc As String) As Boolean
        Try
            Dim _docspago As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucursal)
            If _docspago.AyudaNC(x_fecini, x_fecfin, x_entid_codigo, x_entid_CodigoDoc) Then
                m_dtGCancelacion = New DataTable() : m_dtGCancelacion = _docspago.DTTESO_DocsPagos
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function
   ''' <summary> 
   ''' Capa de Negocio: TRAN_CAJASS_FacturasXCliente
   ''' </summary>
   ''' <param name="x_entid_codigo">Parametro 1: </param> 
   ''' <param name="x_todos">Parametro 2: </param> 
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns> 
   ''' <remarks></remarks> 
   Public Function FacturasXCliente(ByVal x_entid_codigo As String, ByVal x_todos As Boolean) As Boolean
      m_listvent_docsventa = New List(Of EVENT_DocsVenta)
      Try
         Return d_administracioncaja.TRAN_CAJASS_FacturasXCliente(m_listvent_docsventa, x_entid_codigo, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: VENT_DOCVESS_FacturasXCliente
   ''' </summary>
   ''' <param name="x_entid_codigo">Parametro 1: </param> 
   ''' <param name="x_todos">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_DOCVESS_FacturasXCliente(ByVal x_entid_codigo As String, ByVal x_pvent_id As Long, ByVal x_todos As Boolean) As Boolean
      m_listvent_docsventa = New List(Of EVENT_DocsVenta)
      Try
         Return d_administracioncaja.VENT_DOCVESS_FacturasXCliente(m_listvent_docsventa, x_entid_codigo, m_pvent_id, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
    End Function
    ''' <summary> 
    ''' Capa de Negocio: VENT_DOCRec_SaldosXCliente
    ''' </summary>
    ''' <param name="x_entid_codigo">Parametro 1: </param> 
    ''' <param name="x_todos">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    ''' _M
    Public Function VENT_DOCRec_SaldosXCliente(ByVal x_entid_codigo As String, ByVal x_pvent_id As Long, ByVal x_todos As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
        ' m_listvent_docsventa = New List(Of EVENT_DocsVenta)
        m_listTESO_Recibos = New List(Of ETESO_Recibos)
        Try
            Return d_administracioncaja.VENT_DOCRec_SaldosXCliente(m_listTESO_Recibos, x_entid_codigo, m_pvent_id, x_todos, x_fecini, x_fecfin)
            ' Return d_cajachicapago.VENT_DOCRec_SaldosXCliente(m_listTESO_Recibos, x_entid_codigo, m_pvent_id, x_todos, x_fecini, x_fecfin)
            'Return d_administracioncaja.VENT_DOCVESS_FacturasXCliente(m_listvent_docsventa, x_entid_codigo, m_pvent_id, x_todos)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '''' <summary> 
    '''' Capa de Negocio: [TESO_GastosXCajaChica]
    '''' </summary>
    '''' <param name="x_entid_codigo">Parametro 1: </param> 
    '''' <param name="x_todos">Parametro 2: </param> 
    '''' <returns></returns> 
    '''' <remarks></remarks> 
    '''' Frank
    'Public Function TESO_GastosXCajaChica(ByVal x_entid_codigo As String, ByVal x_pvent_id As Long, ByVal x_todos As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
    '    ' m_listvent_docsventa = New List(Of EVENT_DocsVenta)
    '    '  m_listTESO_Recibos = New List(Of ETESO_Recibos)
    '    m_list_cajachicapago = New List(Of ETESO_CajaChicaIngreso)
    '    ' m_list_cajaDocsPago = New List(Of ETESO_CajaDocsPago)
    '    Try
    '        Return d_administracioncaja.TESO_GastosXCajaChica(m_list_cajachicapago, x_entid_codigo, m_pvent_id, x_todos, x_fecini, x_fecfin)
    '        'Return d_administracioncaja.VENT_DOCVESS_FacturasXCliente(m_listvent_docsventa, x_entid_codigo, m_pvent_id, x_todos)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function



#Region " Tipo Cambio "

    ''' <summary>
    ''' Obtener el ultimo tipo de cambio ingresado, sin tener en cuenta los valores ingresados
    ''' </summary>
    ''' <returns>Valor del tipo de cambio, el tipo de cambio sunat.</returns>
    ''' <remarks></remarks>
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

   ''' <summary>
   ''' Obtener el ultimo tipo de cambio de oficina
   ''' </summary>
   ''' <returns>Valor del tipo de cambio, tipo de cambio oficina</returns>
   ''' <remarks></remarks>
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

   ''' <summary>
   ''' Devuelve el ultimo tipo de cambio sunat ingresado
   ''' </summary>
   ''' <param name="x_fecha"></param>
   ''' <returns>devuelve el valor del tipo de cambio encontrado, tipo de cambio sunat</returns>
   ''' <remarks></remarks>
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
#End Region
#End Region

#Region "Caja"
   ''' <summary> 
   ''' Capa de Negocio: TRAN_CAJASS_CuadreCajaPagos
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns> 
   ''' <remarks></remarks> 
   Public Function CuadreCajaPagos(ByVal x_docve_codigo As String) As Boolean
      m_listteso_cajapagos = New List(Of ETESO_Caja)
      Try
         Return d_administracioncaja.TRAN_CAJASS_CuadreCajaPagos(m_listteso_cajapagos, x_docve_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: VENT_DOCVESS_CajaPagos
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns> 
   ''' <remarks></remarks> 
   Public Function VENT_DOCVESS_CajaPagos(ByVal x_docve_codigo As String) As Boolean
      m_listteso_cajapagos = New List(Of ETESO_Caja)
      Try
         Return d_administracioncaja.VENT_DOCVESS_CajaPagos(m_listteso_cajapagos, x_docve_codigo)
      Catch ex As Exception
         Throw ex
      End Try
    End Function
    ''' <summary> 
    ''' Capa de Negocio: VENT_DOCVESS_CajaPagosXCajaCodigo _M
    ''' </summary>
    ''' <param name="x_caja_codigo">Parametro 1: </param> 
    ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns> 
    ''' <remarks></remarks> 
    Public Function VENT_DOCVESS_CajaPagosXCajaCodigo(ByVal x_caja_codigo As String, ByVal x_caja_codigo1 As String) As Boolean
        m_listteso_cajapagos = New List(Of ETESO_Caja)
        Try
            Return d_administracioncaja.VENT_DOCVESS_CajaPagosXCajaCodigo(m_listteso_cajapagos, x_caja_codigo, x_caja_codigo1)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''TESO_GastosXCodigoCajaChica
    'Public Function TESO_GastosXCodigoCajaChica(ByVal x_caja_codigo As String) As Boolean
    '    m_list_cajachicapago = New List(Of ETESO_CajaChicaIngreso)
    '    Try
    '        Return d_administracioncaja.VENT_DOCVESS_CajaPagosXCajaCodigo(m_list_cajachicapago, x_caja_codigo)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    ''' <summary> 
    ''' Capa de Negocio: VENT_DOCVESS_CajaPagosNC _M
    ''' </summary>
    ''' <param name="x_docve_codigo">Parametro 1: </param> 
    ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns> 
    ''' <remarks></remarks> 
    Public Function VENT_DOCVESS_CajaPagosNC(ByVal x_docve_codigo As String) As Boolean
        m_listteso_cajapagos = New List(Of ETESO_Caja)
        Try
            Return d_administracioncaja.VENT_DOCVESS_CajaPagosNC(m_listteso_cajapagos, x_docve_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   ''' <summary>
   ''' Grabar Registro en Caja de un Pago
   ''' </summary>
   ''' <param name="x_vent_docsventa">Clase documento de venta cabecera</param>
   ''' <param name="x_entid_Codigo">Codigo de Entidad</param>
   ''' <param name="x_tipocambio">Tipo de Cambio</param>
   ''' <param name="x_usuario">Codigo de usuario (DNI)</param>
   ''' <returns>devuelve un valor verdadero si se ejecuta la consulta correctamente</returns>
   ''' <remarks></remarks>
   Public Function GrabarCajaDocumento(ByVal x_vent_docsventa As EVENT_DocsVenta, ByRef x_entid_Codigo As String, ByVal x_tipocambio As Decimal, ByVal x_usuario As String) As Boolean
      Try
         Dim _caja As New BTESO_Caja
         _caja.TESO_Caja = x_vent_docsventa.TESO_Caja
         _caja.TESO_Caja.Instanciar(ACEInstancia.Nuevo)
         _caja.TESO_Caja.CAJA_Pase = ACEVentas.Constantes.GetPase(ACEVentas.Constantes.Pase.Entrada)
         _caja.TESO_Caja.CAJA_ImporteVenta = x_vent_docsventa.DOCVE_TotalPagar
         _caja.TESO_Caja.CAJA_Estado = ETESO_Caja.getEstado(ETESO_Caja.Estado.Ingresado)
         _caja.TESO_Caja.CAJA_TCDocumento = x_tipocambio
         _caja.TESO_Caja.DOCVE_Codigo = x_vent_docsventa.DOCVE_Codigo
         _caja.TESO_Caja.TIPOS_CodTipoDocumento = x_vent_docsventa.TIPOS_CodTipoDocumento
         _caja.TESO_Caja.TIPOS_CodTipoMoneda = x_vent_docsventa.TIPOS_CodTipoMoneda
         _caja.TESO_Caja.ENTID_Codigo = x_vent_docsventa.ENTID_CodigoCliente
         x_entid_Codigo = x_vent_docsventa.ENTID_CodigoCliente
         ' Obtener el correlativo correspondiente
         Dim _whereCaja As New Hashtable : _whereCaja.Add("PVENT_Id", New ACWhere(_caja.TESO_Caja.PVENT_Id))
         _caja.TESO_Caja.CAJA_Id = _caja.getCorrelativo("CAJA_Id", _whereCaja)
         '' Graba el registro, el campo "CAJA_FechaPago" coloca la fecha del servidor
         Return _caja.Guardar(x_usuario, New String() {"CAJA_FechaPago"})
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Grabar Registros por Redondeo
   ''' </summary>
   ''' <param name="item"></param>
   ''' <param name="x_codtransaccion"></param>
   ''' <param name="x_Caja_codigo"></param>
   ''' <param name="_diferencia"></param>
   ''' <param name="x_tipocambio"></param>
   ''' <param name="x_usuario"></param>
   ''' <remarks></remarks>
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
         _caja.TESO_Caja.DOCVE_Codigo = item.DOCVE_Codigo
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

   ''' <summary>
   ''' Graba el conjunto de registros de caja
   ''' </summary>
   ''' <param name="x_usuario">DNI del usuario que realiza la operación</param>
   ''' <param name="m_tipopago">Tipo de pago</param>
   ''' <param name="x_caja_codigo">Codigo de Caja</param>
   ''' <param name="x_entid_Codigo">Codigo de la entidad</param>
   ''' <param name="x_importe">Importe pagado</param>
   ''' <param name="x_tipo_moneda">Moneda del importe pagadp</param>
   ''' <param name="x_serie">Numero de serie para el registro</param>
   ''' <param name="x_fecha">fecha de cancelación</param>
   ''' <param name="x_redondeo">Tipo de redondeo</param>
   ''' <param name="x_tipocambio">Tipo de cambio</param>
   ''' <returns>devuelve un valor verdadero si se ejecuta la consulta correctamente</returns>
   ''' <remarks></remarks>
   Private Function GrabarCaja(ByVal x_usuario As String, ByVal m_tipopago As ETipos.TipoDePago, _
                               ByRef x_caja_codigo As String, ByRef x_entid_Codigo As String, ByRef x_importe As Decimal, ByRef x_tipo_moneda As String, _
                               ByVal x_serie As String, ByVal x_fecha As DateTime, ByVal x_redondeo As TRedondeo, ByVal x_tipocambio As Decimal) As Boolean
      Try
         Dim _i As Integer = 1
         Dim _numero As Integer = getNroTransaccion(m_pvent_id, x_serie)
         x_caja_codigo = String.Format("{0:00}{1}{2:0000000}", m_pvent_id, x_serie, _numero)
         '' Valores para el Redondeo
         Dim _glosa As String = ""
         Dim _factura As Decimal
         Dim _diferencia As Decimal
         Dim _pagar As Decimal = 0
         Dim _pagardiferencia As Decimal = 0
         Dim _docCaja As New EVENT_DocsVenta
         '' Iterar sobre los documentos de venta
         For Each item As EVENT_DocsVenta In m_listVENT_PagosFacturas
            item.TESO_Caja.CAJA_Importe = item.ImportePagar
            item.TESO_Caja.CAJA_Fecha = x_fecha
            item.TESO_Caja.TIPOS_CodTipoOrigen = ETipos.getTipoOrigen(ETipos.OrigenCancelacion.CancelacionDocumentosVentas)
            item.TESO_Caja.CAJA_Serie = x_serie
            item.TESO_Caja.CAJA_Numero = _numero
            item.TESO_Caja.TIPOS_CodTransaccion = ETipos.getTipoDePago(m_tipopago)
            item.TESO_Caja.CAJA_Glosa = IIf(m_tipopago = ETipos.TipoDePago.Efectivo, ACEVentas.Constantes.getGlosaTipoDePago(ETipos.TipoDePago.Efectivo), _
                                 ACEVentas.Constantes.getGlosaTipoDePago(m_tipopago)) & " - " & String.Format("{0} {1}-{2:00000000}", item.TIPOS_TipoDocumento, item.DOCVE_Serie, item.DOCVE_Numero)
            item.TESO_Caja.CAJA_Codigo = x_caja_codigo
            item.TESO_Caja.CAJA_OrdenDocumento = _i

            Select Case m_tipopago
               Case ETipos.TipoDePago.DepositoBancario
                  item.TESO_Caja.BANCO_Id = m_listteso_docspagos(0).BANCO_Id
               Case ETipos.TipoDePago.Cheque
                  item.TESO_Caja.CAJA_Importe = 0
                  x_redondeo = TRedondeo.SinRedondeo
               Case Else

            End Select
            If Not GrabarCajaDocumento(item, x_entid_Codigo, x_tipocambio, x_usuario) Then
               Throw New Exception("No se puede completar el proceso de grabado en caja")
            End If
            _i += 1

            x_importe += item.TESO_Caja.CAJA_Importe
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
            For Each Pag As ETESO_DocsPagos In m_listteso_docspagos
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
                  GrabarCajaDocumento(_docCaja, ETipos.TipoDePago.ReciboEgresoRedondeo, x_caja_codigo, _diferencia, x_tipocambio, _glosa, x_usuario)
                  _i += 1
               Case TRedondeo.PorFaltaPago
                  _docCaja.TIPOS_CodTipoDocumento = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboEgreso)
                  GrabarCajaDocumento(_docCaja, ETipos.TipoDePago.ReciboIngresoRedondeo, x_caja_codigo, -_diferencia, x_tipocambio, _glosa, x_usuario)
                  _i += 1
               Case Else
            End Select
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Grabar el deposito
   ''' </summary>
   ''' <param name="x_usuario">Codigo de usuario</param>
   ''' <param name="x_entid_codigo">Codifo de entidad</param>
   ''' <param name="x_caja_codigo">Codigo de Caja</param>
   ''' <param name="x_saldoafavor">Valor que indica si hay saldo a favor, y si puede dar un saldo a favor</param>
   ''' <param name="x_fecha"></param>
   ''' <param name="x_importe"></param>
   ''' <param name="x_tiporecibo">tipo de recibo</param>
   ''' <returns>devuelve un valor verdadero si se ejecuta la consulta correctamente</returns>
   ''' <remarks></remarks>
   Private Function GrabarDeposito(ByVal x_usuario As String, ByVal x_entid_codigo As String, ByVal x_caja_codigo As String, _
                                   ByVal x_saldoafavor As Boolean, ByVal x_fecha As DateTime, ByVal x_importe As Decimal, ByVal x_tiporecibo As ETipos) As Boolean
      Try
         Dim _bteso_docspagos As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucursal)
         Dim i As Integer = 1
         For Each item As ETESO_DocsPagos In m_listteso_docspagos
            _bteso_docspagos.TESO_DocsPagos = item
            _bteso_docspagos.TESO_DocsPagos.ENTID_Codigo = x_entid_codigo
            If _bteso_docspagos.TESO_DocsPagos.Nuevo Then
                    If Not _bteso_docspagos.Validar_Depositos(_bteso_docspagos.TESO_DocsPagos.DPAGO_Numero, _bteso_docspagos.TESO_DocsPagos.BANCO_Id, _bteso_docspagos.TESO_DocsPagos.CUENT_Id) Then
                        Dim _whereCaja As New Hashtable : _whereCaja.Add("PVENT_Id", New ACWhere(_bteso_docspagos.TESO_DocsPagos.PVENT_Id))
                        _bteso_docspagos.TESO_DocsPagos.DPAGO_Id = _bteso_docspagos.getCorrelativo("DPAGO_Id", _whereCaja)
                        _bteso_docspagos.TESO_DocsPagos.DPAGO_Fecha = _bteso_docspagos.TESO_DocsPagos.DPAGO_Fecha.Date
                        _bteso_docspagos.TESO_DocsPagos.DPAGO_FechaVenc = _bteso_docspagos.TESO_DocsPagos.DPAGO_FechaVenc.Date
                        _bteso_docspagos.TESO_DocsPagos.Cod_Confirmacion = _bteso_docspagos.TESO_DocsPagos.Cod_Confirmacion
                        If _bteso_docspagos.Guardar(x_usuario) Then
                            Dim _bteso_cajadocspago As New BTESO_CajaDocsPago
                            _bteso_cajadocspago.TESO_CajaDocsPago = New ETESO_CajaDocsPago
                            _bteso_cajadocspago.TESO_CajaDocsPago.Instanciar(ACEInstancia.Nuevo)
                            _bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Codigo = x_caja_codigo
                            _bteso_cajadocspago.TESO_CajaDocsPago.DPAGO_Id = _bteso_docspagos.TESO_DocsPagos.DPAGO_Id
                            _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Importe = item.DPAGO_Importe
                            _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Numero = i
                            _bteso_cajadocspago.TESO_CajaDocsPago.PVENT_Id = item.PVENT_Id
                            _bteso_cajadocspago.Guardar(x_usuario)
                            i += 1
                        End If

                        '' Aplicar Saldo A Favor
                        If x_saldoafavor Then
                            '' Generar Recibo de Ingreso
                            Dim _brecibos As New BTESO_Recibos
                            _brecibos.TESO_Recibos = New ETESO_Recibos
                            _brecibos.TESO_Recibos.Instanciar(ACEInstancia.Nuevo)

                            _brecibos.TESO_Recibos.TIPOS_CodTransaccion = x_tiporecibo.TIPOS_Codigo
                            '' obtiene el tipo de recibo
                            If x_tiporecibo.TIPOS_Codigo.Equals(ETipos.getTipo(ETipos.TransaccionTRecibos.AFavorCliente)) Then
                                _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboAFavorCliente)
                            ElseIf x_tiporecibo.TIPOS_Codigo.Equals(ETipos.getTipo(ETipos.TransaccionTRecibos.DevolucionCliente)) Then
                                _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboDevolucion)
                            ElseIf x_tiporecibo.TIPOS_Codigo.Equals(ETipos.getTipo(ETipos.TransaccionTRecibos.Normal)) Then
                                _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboIngreso)
                            ElseIf x_tiporecibo.TIPOS_Codigo.Equals(ETipos.getTipo(ETipos.TransaccionTRecibos.SinRecibo)) Then
                                Return True
                            Else
                                _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboIngreso)
                            End If
                            '' Obtener el numero de serie segun el tipo de recibo
                            If _brecibos.GetSeries(m_app, m_zonas_codigo, m_sucursal, m_pvent_id, _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo) Then
                                _brecibos.TESO_Recibos.RECIB_Serie = _brecibos.ListVENT_PVentDocumento(0).PVDOCU_Serie
                                Dim _where As New Hashtable
                                _where.Add("TIPOS_CodTipoRecibo", New ACWhere(_brecibos.TESO_Recibos.TIPOS_CodTipoRecibo))
                                _where.Add("RECIB_Serie", New ACWhere(_brecibos.TESO_Recibos.RECIB_Serie))
                                _brecibos.TESO_Recibos.RECIB_Numero = _brecibos.getCorrelativo("RECIB_Numero", _where)
                            End If
                            '' Genera el codigo de recibo
                            _brecibos.TESO_Recibos.RECIB_Codigo = String.Format("{0}{1}{2:0000000}", _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo.Substring(3, 2), _
                                                                                       _brecibos.TESO_Recibos.RECIB_Serie.PadLeft(3, "0"), _
                                                                                       _brecibos.TESO_Recibos.RECIB_Numero)
                            _brecibos.TESO_Recibos.TIPOS_CodTipoMoneda = item.TIPOS_CodTipoMoneda
                            _brecibos.TESO_Recibos.PVENT_Id = m_pvent_id
                            _brecibos.TESO_Recibos.RECIB_Fecha = x_fecha
                            _brecibos.TESO_Recibos.RECIB_RecibiDe = "CAJA - " & x_usuario
                            _brecibos.TESO_Recibos.RECIB_Importe = item.DPAGO_Importe - x_importe
                            _brecibos.TESO_Recibos.RECIB_Concepto = String.Format("{3} del deposito {0} OP: {1} ({2:dd/MM/yyyy})", _
                                                                                  item.BANCO_Descripcion, item.DPAGO_Numero, item.DPAGO_Fecha, _
                                                                                  x_tiporecibo.TIPOS_Descripcion)
                            _brecibos.TESO_Recibos.ENTID_Codigo = x_entid_codigo
                            _brecibos.TESO_Recibos.DPAGO_Id = item.DPAGO_Id
                            _brecibos.TESO_Recibos.TIPOS_CodTransaccion = ETipos.getTipo(ETipos.TransaccionTRecibos.AFavorCliente)
                            _brecibos.Guardar(x_usuario)
                        End If
                        Return True
                    Else
                        Throw New Exception("El deposito ya existe.")
                    End If
                Else
                    Dim _bteso_cajadocspago As New BTESO_CajaDocsPago
                    _bteso_cajadocspago.TESO_CajaDocsPago = New ETESO_CajaDocsPago
                    _bteso_cajadocspago.TESO_CajaDocsPago.Instanciar(ACEInstancia.Nuevo)
                    _bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Codigo = x_caja_codigo
                    _bteso_cajadocspago.TESO_CajaDocsPago.DPAGO_Id = _bteso_docspagos.TESO_DocsPagos.DPAGO_Id
                    _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Importe = item.DPAGO_Importe
                    _bteso_cajadocspago.TESO_CajaDocsPago.PVENT_Id = item.PVENT_Id
                    _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Numero = i
                    _bteso_cajadocspago.Guardar(x_usuario)
                    '' Aplicar Saldo A Favor
                    If x_saldoafavor Then
                        '' Generar Recibo de Ingreso
                        Dim _brecibos As New BTESO_Recibos
                        _brecibos.TESO_Recibos = New ETESO_Recibos
                        _brecibos.TESO_Recibos.Instanciar(ACEInstancia.Nuevo)

                        _brecibos.TESO_Recibos.TIPOS_CodTransaccion = x_tiporecibo.TIPOS_Codigo
                        If x_tiporecibo.TIPOS_Codigo.Equals(ETipos.getTipo(ETipos.TransaccionTRecibos.AFavorCliente)) Then
                            _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboAFavorCliente)
                        ElseIf x_tiporecibo.TIPOS_Codigo.Equals(ETipos.getTipo(ETipos.TransaccionTRecibos.DevolucionCliente)) Then
                            _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboDevolucion)
                        ElseIf x_tiporecibo.TIPOS_Codigo.Equals(ETipos.getTipo(ETipos.TransaccionTRecibos.Normal)) Then
                            _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboIngreso)
                        ElseIf x_tiporecibo.TIPOS_Codigo.Equals(ETipos.getTipo(ETipos.TransaccionTRecibos.SinRecibo)) Then
                            Return True
                        Else
                            _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboIngreso)
                        End If
                        '' Obtener el numero de serie segun el tipo de recibo
                        If _brecibos.GetSeries(m_app, m_zonas_codigo, m_sucursal, m_pvent_id, _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo) Then
                            _brecibos.TESO_Recibos.RECIB_Serie = _brecibos.ListVENT_PVentDocumento(0).PVDOCU_Serie
                            Dim _where As New Hashtable
                            _where.Add("TIPOS_CodTipoRecibo", New ACWhere(_brecibos.TESO_Recibos.TIPOS_CodTipoRecibo))
                            _where.Add("RECIB_Serie", New ACWhere(_brecibos.TESO_Recibos.RECIB_Serie))
                            _brecibos.TESO_Recibos.RECIB_Numero = _brecibos.getCorrelativo("RECIB_Numero", _where)
                        End If
                        '' Genera el codigo de recibo
                        _brecibos.TESO_Recibos.RECIB_Codigo = String.Format("{0}{1}{2:0000000}", _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo.Substring(3, 2), _
                                                                                   _brecibos.TESO_Recibos.RECIB_Serie.PadLeft(3, "0"), _
                                                                                   _brecibos.TESO_Recibos.RECIB_Numero)
                        _brecibos.TESO_Recibos.TIPOS_CodTipoMoneda = item.TIPOS_CodTipoMoneda
                        _brecibos.TESO_Recibos.PVENT_Id = m_pvent_id
                        _brecibos.TESO_Recibos.RECIB_Fecha = x_fecha
                        _brecibos.TESO_Recibos.RECIB_RecibiDe = "CAJA - " & x_usuario
                        _brecibos.TESO_Recibos.RECIB_Importe = item.DPAGO_Importe - x_importe
                        _brecibos.TESO_Recibos.RECIB_Concepto = String.Format("{3} del deposito {0} OP: {1} ({2:dd/MM/yyyy})", _
                                                                              item.BANCO_Descripcion, item.DPAGO_Numero, item.DPAGO_Fecha, _
                                                                              x_tiporecibo.TIPOS_Descripcion)
                        _brecibos.TESO_Recibos.ENTID_Codigo = x_entid_codigo
                        _brecibos.TESO_Recibos.DPAGO_Id = item.DPAGO_Id
                        _brecibos.TESO_Recibos.TIPOS_CodTransaccion = ETipos.getTipo(ETipos.TransaccionTRecibos.AFavorCliente)
                        _brecibos.Guardar(x_usuario)
                    End If
                    Return True
                End If
         Next
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Grabar una detraccion
   ''' </summary>
   ''' <param name="x_usuario">DNI de Usuario</param>
   ''' <param name="x_entid_codigo">Codigo de entidad</param>
   ''' <param name="x_caja_codigo">Codigo de Caja</param>
   ''' <returns>devuelve un valor verdadero si se ejecuta la consulta correctamente</returns>
   ''' <remarks></remarks>
   Private Function GrabarDetraccion(ByVal x_usuario As String, ByVal x_entid_codigo As String, ByVal x_caja_codigo As String) As Boolean
      Try
         Dim _bteso_docspagos As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucursal)
         Dim i As Integer = 1
         For Each item As ETESO_DocsPagos In m_listteso_docspagos
            _bteso_docspagos.TESO_DocsPagos = item
            _bteso_docspagos.TESO_DocsPagos.ENTID_Codigo = x_entid_codigo
            Dim _whereCaja As New Hashtable : _whereCaja.Add("PVENT_Id", New ACWhere(_bteso_docspagos.TESO_DocsPagos.PVENT_Id))
            _bteso_docspagos.TESO_DocsPagos.DPAGO_Id = _bteso_docspagos.getCorrelativo("DPAGO_Id", _whereCaja)
            If _bteso_docspagos.Guardar(x_usuario) Then
               Dim _bteso_cajadocspago As New BTESO_CajaDocsPago
               _bteso_cajadocspago.TESO_CajaDocsPago = New ETESO_CajaDocsPago
               _bteso_cajadocspago.TESO_CajaDocsPago.Instanciar(ACEInstancia.Nuevo)
               _bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Codigo = x_caja_codigo
               _bteso_cajadocspago.TESO_CajaDocsPago.DPAGO_Id = _bteso_docspagos.TESO_DocsPagos.DPAGO_Id
               _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Importe = item.ImporteUsado
               _bteso_cajadocspago.TESO_CajaDocsPago.PVENT_Id = item.PVENT_Id
               _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Numero = i
               _bteso_cajadocspago.Guardar(x_usuario)
               i += 1
            End If
         Next
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Grabar nota de credito
   ''' </summary>
   ''' <param name="x_usuario">Codigo de usuario</param>
   ''' <param name="x_entid_codigo">Codigo de Entidad</param>
   ''' <param name="x_caja_codigo">Codigo de Caja</param>
   ''' <param name="x_tipocambio">Tipo de cambio</param>
   ''' <param name="x_tipocambiosunat">Tipo de cambio sunat</param>
   ''' <returns>devuelve un valor verdadero si se ejecuta la consulta correctamente</returns>
   ''' <remarks></remarks>
    Private Function GrabarNotaCredito(ByVal x_usuario As String, ByVal x_entid_codigo As String, ByVal x_caja_codigo As String, ByVal x_saldoafavor As Boolean, ByVal x_saldo As Boolean, ByVal x_tipocambio As Decimal, ByVal x_tipocambiosunat As Decimal, ByVal x_fecha As DateTime, ByVal x_importe As Decimal, ByVal x_tiporecibo As ETipos) As Boolean
        Try
            '' Grabar Documentos que Pagan
            Dim _bteso_docspagos As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucursal)
            Dim i As Integer = 1
            For Each item As ETESO_DocsPagos In m_listteso_docspagos
                '_bteso_docspagos.TESO_DocsPagos.Instanciar(ACEInstancia.Nuevo)
                _bteso_docspagos.TESO_DocsPagos = item
                _bteso_docspagos.TESO_DocsPagos.ENTID_Codigo = x_entid_codigo
                _bteso_docspagos.TESO_DocsPagos.DPAGO_Numero =   _bteso_docspagos.TESO_DocsPagos.DPAGO_Numero
                If Not x_saldo Then
                    '  If _bteso_docspagos.TESO_DocsPagos.Nuevo Then
                    Dim _whereCaja As New Hashtable : _whereCaja.Add("PVENT_Id", New ACWhere(_bteso_docspagos.TESO_DocsPagos.PVENT_Id))
                    _bteso_docspagos.TESO_DocsPagos.DPAGO_Id = _bteso_docspagos.getCorrelativo("DPAGO_Id", _whereCaja)
                    _bteso_docspagos.TESO_DocsPagos.Instanciar(ACEInstancia.Nuevo)
                    If _bteso_docspagos.Guardar(x_usuario) Then
                        Dim _bteso_cajadocspago As New BTESO_CajaDocsPago
                        _bteso_cajadocspago.TESO_CajaDocsPago = New ETESO_CajaDocsPago
                        _bteso_cajadocspago.TESO_CajaDocsPago.Instanciar(ACEInstancia.Nuevo)
                        _bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Codigo = x_caja_codigo
                        _bteso_cajadocspago.TESO_CajaDocsPago.DPAGO_Id = _bteso_docspagos.TESO_DocsPagos.DPAGO_Id
                        _bteso_cajadocspago.TESO_CajaDocsPago.PVENT_Id = m_pvent_id
                        _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Importe = item.DPAGO_Importe '
                        _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Numero = i
                        _bteso_cajadocspago.Guardar(x_usuario)
                        i += 1
                    End If
                    '' Grabar Nota de Credito
                    _bteso_docspagos.TESO_DocsPagos.VENT_DocsVenta.ENTID_CodigoCliente = x_entid_codigo
                    Dim m_bgenerardocsventa As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucursal)
                    Dim x_msg As String = ""
                    m_bgenerardocsventa.VENT_DocsVenta = _bteso_docspagos.TESO_DocsPagos.VENT_DocsVenta
                    m_bgenerardocsventa.VENT_DocsVenta.Instanciar(ACEInstancia.Nuevo)
                    m_bgenerardocsventa.VENT_DocsVenta.DOCVE_Estado = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Ingresado)
                    '  m_bgenerardocsventa.VENT_DocsVenta.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                    m_bgenerardocsventa.VENT_DocsVenta.DOCVE_TipoCambio = x_tipocambio
                    m_bgenerardocsventa.VENT_DocsVenta.DOCVE_TipoCambioSunat = x_tipocambiosunat

                    '            Dim _detalle As New EVENT_DocsVentaDetalle
                    '            _detalle.DOCVD_PrecioUnitario = m_bgenerardocsventa.VENT_DocsVenta.DOCVE_ImporteVenta
                    '            _detalle.DOCVD_SubImporteVenta = m_bgenerardocsventa.VENT_DocsVenta.DOCVE_ImporteVenta
                    '            _detalle.DOCVD_Cantidad = 1
                    '            m_bgenerardocsventa.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Add(_detalle)
                    '            If Not m_bgenerardocsventa.generarDocumento(x_usuario, m_bgenerardocsventa.VENT_DocsVenta.DOCVE_FechaDocumento, _
                    '                                                    m_bgenerardocsventa.VENT_DocsVenta.DOCVE_Serie, _
                    '                                                    m_bgenerardocsventa.VENT_DocsVenta.DOCVE_Numero, "E", x_msg, False) Then
                    '               Throw New Exception("No Se puede Generar el Documento Nota de Credito")


                    '' Aplicar Saldo A Favor
                    If x_saldoafavor Then
                        '' Generar Recibo de Ingreso
                        Dim _brecibos As New BTESO_Recibos
                        _brecibos.TESO_Recibos = New ETESO_Recibos
                        _brecibos.TESO_Recibos.Instanciar(ACEInstancia.Nuevo)

                        _brecibos.TESO_Recibos.TIPOS_CodTransaccion = x_tiporecibo.TIPOS_Codigo
                        '' obtiene el tipo de recibo
                        If x_tiporecibo.TIPOS_Codigo.Equals(ETipos.getTipo(ETipos.TransaccionTRecibos.AFavorCliente)) Then
                            _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboAFavorCliente)
                        ElseIf x_tiporecibo.TIPOS_Codigo.Equals(ETipos.getTipo(ETipos.TransaccionTRecibos.DevolucionCliente)) Then
                            _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboDevolucion)
                        ElseIf x_tiporecibo.TIPOS_Codigo.Equals(ETipos.getTipo(ETipos.TransaccionTRecibos.Normal)) Then
                            _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboIngreso)
                        ElseIf x_tiporecibo.TIPOS_Codigo.Equals(ETipos.getTipo(ETipos.TransaccionTRecibos.SinRecibo)) Then
                            Return True
                        Else
                            _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboIngreso)
                        End If
                        '' Obtener el numero de serie segun el tipo de recibo
                        If _brecibos.GetSeries(m_app, m_zonas_codigo, m_sucursal, m_pvent_id, _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo) Then
                            _brecibos.TESO_Recibos.RECIB_Serie = _brecibos.ListVENT_PVentDocumento(0).PVDOCU_Serie
                            Dim _where As New Hashtable
                            _where.Add("TIPOS_CodTipoRecibo", New ACWhere(_brecibos.TESO_Recibos.TIPOS_CodTipoRecibo))
                            _where.Add("RECIB_Serie", New ACWhere(_brecibos.TESO_Recibos.RECIB_Serie))
                            _brecibos.TESO_Recibos.RECIB_Numero = _brecibos.getCorrelativo("RECIB_Numero", _where)
                        End If
                        '' Genera el codigo de recibo
                        _brecibos.TESO_Recibos.RECIB_Codigo = String.Format("{0}{1}{2:0000000}", _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo.Substring(3, 2), _
                                                                                   _brecibos.TESO_Recibos.RECIB_Serie.PadLeft(3, "0"), _
                                                                                   _brecibos.TESO_Recibos.RECIB_Numero)
                        _brecibos.TESO_Recibos.TIPOS_CodTipoMoneda = item.TIPOS_CodTipoMoneda
                        _brecibos.TESO_Recibos.PVENT_Id = m_pvent_id
                        _brecibos.TESO_Recibos.RECIB_Fecha = x_fecha
                        _brecibos.TESO_Recibos.RECIB_RecibiDe = "CAJA - " & x_usuario
                        _brecibos.TESO_Recibos.RECIB_Importe = item.DPAGO_Importe - x_importe
                        _brecibos.TESO_Recibos.RECIB_Concepto = String.Format("{3} del deposito {0} OP: {1} ({2:dd/MM/yyyy})", _
                                                                              item.BANCO_Descripcion, item.DPAGO_Numero, item.DPAGO_Fecha, _
                                                                              x_tiporecibo.TIPOS_Descripcion)
                        _brecibos.TESO_Recibos.ENTID_Codigo = x_entid_codigo
                        _brecibos.TESO_Recibos.DPAGO_Id = item.DPAGO_Id
                        _brecibos.TESO_Recibos.TIPOS_CodTransaccion = ETipos.getTipo(ETipos.TransaccionTRecibos.AFavorCliente)
                        _brecibos.Guardar(x_usuario)
                    End If
                    Return True
                Else
                    Dim _bteso_cajadocspago As New BTESO_CajaDocsPago
                    _bteso_cajadocspago.TESO_CajaDocsPago = New ETESO_CajaDocsPago
                    _bteso_cajadocspago.TESO_CajaDocsPago.Instanciar(ACEInstancia.Nuevo)
                    _bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Codigo = x_caja_codigo
                    _bteso_cajadocspago.TESO_CajaDocsPago.DPAGO_Id = _bteso_docspagos.TESO_DocsPagos.DPAGO_Id
                    _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Importe = item.DPAGO_Importe
                    _bteso_cajadocspago.TESO_CajaDocsPago.PVENT_Id = item.PVENT_Id
                    _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Numero = i
                    _bteso_cajadocspago.Guardar(x_usuario)
                    '' Aplicar Saldo A Favor
                    If x_saldoafavor Then
                        '' Generar Recibo de Ingreso
                        Dim _brecibos As New BTESO_Recibos
                        _brecibos.TESO_Recibos = New ETESO_Recibos
                        _brecibos.TESO_Recibos.Instanciar(ACEInstancia.Nuevo)

                        _brecibos.TESO_Recibos.TIPOS_CodTransaccion = x_tiporecibo.TIPOS_Codigo
                        If x_tiporecibo.TIPOS_Codigo.Equals(ETipos.getTipo(ETipos.TransaccionTRecibos.AFavorCliente)) Then
                            _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboAFavorCliente)
                        ElseIf x_tiporecibo.TIPOS_Codigo.Equals(ETipos.getTipo(ETipos.TransaccionTRecibos.DevolucionCliente)) Then
                            _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboDevolucion)
                        ElseIf x_tiporecibo.TIPOS_Codigo.Equals(ETipos.getTipo(ETipos.TransaccionTRecibos.Normal)) Then
                            _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboIngreso)
                        ElseIf x_tiporecibo.TIPOS_Codigo.Equals(ETipos.getTipo(ETipos.TransaccionTRecibos.SinRecibo)) Then
                            Return True
                        Else
                            _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboIngreso)
                        End If
                        '' Obtener el numero de serie segun el tipo de recibo
                        If _brecibos.GetSeries(m_app, m_zonas_codigo, m_sucursal, m_pvent_id, _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo) Then
                            _brecibos.TESO_Recibos.RECIB_Serie = _brecibos.ListVENT_PVentDocumento(0).PVDOCU_Serie
                            Dim _where As New Hashtable
                            _where.Add("TIPOS_CodTipoRecibo", New ACWhere(_brecibos.TESO_Recibos.TIPOS_CodTipoRecibo))
                            _where.Add("RECIB_Serie", New ACWhere(_brecibos.TESO_Recibos.RECIB_Serie))
                            _brecibos.TESO_Recibos.RECIB_Numero = _brecibos.getCorrelativo("RECIB_Numero", _where)
                        End If
                        '' Genera el codigo de recibo
                        _brecibos.TESO_Recibos.RECIB_Codigo = String.Format("{0}{1}{2:0000000}", _brecibos.TESO_Recibos.TIPOS_CodTipoRecibo.Substring(3, 2), _
                                                                                   _brecibos.TESO_Recibos.RECIB_Serie.PadLeft(3, "0"), _
                                                                                   _brecibos.TESO_Recibos.RECIB_Numero)
                        _brecibos.TESO_Recibos.TIPOS_CodTipoMoneda = item.TIPOS_CodTipoMoneda
                        _brecibos.TESO_Recibos.PVENT_Id = m_pvent_id
                        _brecibos.TESO_Recibos.RECIB_Fecha = x_fecha
                        _brecibos.TESO_Recibos.RECIB_RecibiDe = "CAJA - " & x_usuario
                        _brecibos.TESO_Recibos.RECIB_Importe = item.DPAGO_Importe - x_importe
                        _brecibos.TESO_Recibos.RECIB_Concepto = String.Format("{3} del deposito {0} OP: {1} ({2:dd/MM/yyyy})", _
                                                                              item.BANCO_Descripcion, item.DPAGO_Numero, item.DPAGO_Fecha, _
                                                                              x_tiporecibo.TIPOS_Descripcion)
                        _brecibos.TESO_Recibos.ENTID_Codigo = x_entid_codigo
                        _brecibos.TESO_Recibos.DPAGO_Id = item.DPAGO_Id
                        _brecibos.TESO_Recibos.TIPOS_CodTransaccion = ETipos.getTipo(ETipos.TransaccionTRecibos.AFavorCliente)
                        _brecibos.Guardar(x_usuario)
                    End If
                    Return True
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   ''' <summary>
   ''' Grabar recibo de Ingreso interno, para cancelaciones que no tienen sustento
   ''' </summary>
   ''' <param name="x_usuario">Codigo de Usuario</param>
   ''' <param name="x_entid_codigo">Codigo de Entidad</param>
   ''' <param name="x_caja_codigo">Codigo de caja</param>
   ''' <returns>devuelve un valor verdadero si se ejecuta la consulta correctamente</returns>
   ''' <remarks></remarks>
   Private Function GrabarRecInterno(ByVal x_usuario As String, ByVal x_entid_codigo As String, ByVal x_caja_codigo As String) As Boolean
      Try
         Dim _bteso_docspagos As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucursal)
         Dim i As Integer = 1
         For Each item As ETESO_DocsPagos In m_listteso_docspagos
            _bteso_docspagos.TESO_DocsPagos = item
            _bteso_docspagos.TESO_DocsPagos.ENTID_Codigo = x_entid_codigo
            Dim _whereCaja As New Hashtable : _whereCaja.Add("PVENT_Id", New ACWhere(_bteso_docspagos.TESO_DocsPagos.PVENT_Id))
            _bteso_docspagos.TESO_DocsPagos.DPAGO_Id = _bteso_docspagos.getCorrelativo("DPAGO_Id", _whereCaja)
            If _bteso_docspagos.Guardar(x_usuario) Then
               Dim _bteso_cajadocspago As New BTESO_CajaDocsPago
               _bteso_cajadocspago.TESO_CajaDocsPago = New ETESO_CajaDocsPago
               _bteso_cajadocspago.TESO_CajaDocsPago.Instanciar(ACEInstancia.Nuevo)
               _bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Codigo = x_caja_codigo
               _bteso_cajadocspago.TESO_CajaDocsPago.DPAGO_Id = _bteso_docspagos.TESO_DocsPagos.DPAGO_Id
               _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Importe = item.ImporteUsado
               _bteso_cajadocspago.TESO_CajaDocsPago.PVENT_Id = item.PVENT_Id
               _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Numero = i
               _bteso_cajadocspago.Guardar(x_usuario)
               i += 1
            End If
         Next
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Grabar un pago usando efectivo
   ''' </summary>
   ''' <param name="x_usuario"></param>
   ''' <param name="_entid_codigo"></param>
   ''' <param name="_caja_codigo"></param>
   ''' <param name="x_tipo_moneda"></param>
   ''' <param name="x_importe"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function GrabarEfectivo(ByVal x_usuario As String, ByVal _entid_codigo As String, ByVal _caja_codigo As String, _
                                   ByVal x_tipo_moneda As String, ByVal x_importe As Decimal) As Boolean
      Try
         Dim _bteso_docspagos As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucursal)
         Dim i As Integer = 1
         _bteso_docspagos.TESO_DocsPagos = New ETESO_DocsPagos
         _bteso_docspagos.TESO_DocsPagos.Instanciar(ACEInstancia.Nuevo)
         _bteso_docspagos.TESO_DocsPagos.ENTID_Codigo = _entid_codigo
         _bteso_docspagos.TESO_DocsPagos.TIPOS_CodTipoDocumento = ETipos.getTipoDePago(ETipos.TipoDePago.Efectivo)
         _bteso_docspagos.TESO_DocsPagos.PVENT_Id = m_pvent_id
         _bteso_docspagos.TESO_DocsPagos.TIPOS_CodTipoMoneda = x_tipo_moneda
         _bteso_docspagos.TESO_DocsPagos.DPAGO_Importe = x_importe
         Dim _whereCaja As New Hashtable : _whereCaja.Add("PVENT_Id", New ACWhere(_bteso_docspagos.TESO_DocsPagos.PVENT_Id))
         _bteso_docspagos.TESO_DocsPagos.DPAGO_Id = _bteso_docspagos.getCorrelativo("DPAGO_Id", _whereCaja)
         '' Obtener el correlativo para el numero de pago, usando efectivo
         Dim _wheredpago As New Hashtable
         _wheredpago.Add("TIPOS_CodTipoDocumento", New ACWhere(_bteso_docspagos.TESO_DocsPagos.TIPOS_CodTipoDocumento))
         _wheredpago.Add("ENTID_Codigo", New ACWhere(_bteso_docspagos.TESO_DocsPagos.ENTID_Codigo))
         _bteso_docspagos.TESO_DocsPagos.DPAGO_Numero = _bteso_docspagos.getCorrelativo("DPAGO_Numero", _wheredpago)
         If _bteso_docspagos.Guardar(x_usuario, New String() {"DPAGO_Fecha", "DPAGO_FechaVenc"}) Then
            Dim _bteso_cajadocspago As New BTESO_CajaDocsPago
            _bteso_cajadocspago.TESO_CajaDocsPago = New ETESO_CajaDocsPago
            _bteso_cajadocspago.TESO_CajaDocsPago.Instanciar(ACEInstancia.Nuevo)
            _bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Codigo = _caja_codigo
            _bteso_cajadocspago.TESO_CajaDocsPago.DPAGO_Id = _bteso_docspagos.TESO_DocsPagos.DPAGO_Id
            _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Importe = x_importe
            _bteso_cajadocspago.TESO_CajaDocsPago.PVENT_Id = m_pvent_id
            _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Numero = i
            _bteso_cajadocspago.Guardar(x_usuario)
            i += 1
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Grabar letra de cambio, esta reemplaza a todas las facturas que cancela
   ''' </summary>
   ''' <param name="x_usuario">Codigo de usuario</param>
   ''' <param name="x_entid_codigo">Codigo de entidad</param>
   ''' <param name="x_caja_codigo">Codigo de caja</param>
   ''' <param name="x_tipocambio">tipo de cambio</param>
   ''' <param name="x_tipocambiosunat">Tipo de cambio sunat</param>
   ''' <returns>devuelve un valor verdadero si se ejecuta la consulta correctamente</returns>
   ''' <remarks></remarks>
   Private Function GrabarLetra(ByVal x_usuario As String, ByVal x_entid_codigo As String, ByVal x_caja_codigo As String, ByVal x_tipocambio As Decimal, ByVal x_tipocambiosunat As Decimal) As Boolean
      Try
         '' Grabar Documentos que Pagan
         Dim _bteso_docspagos As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucursal)
         Dim _numero As Integer
         Dim i As Integer = 1
         For Each item As ETESO_DocsPagos In m_listteso_docspagos
            _bteso_docspagos.TESO_DocsPagos = item
            _bteso_docspagos.TESO_DocsPagos.ENTID_Codigo = x_entid_codigo
            _numero = _bteso_docspagos.TESO_DocsPagos.DPAGO_Numero
            Dim _whereCaja As New Hashtable : _whereCaja.Add("PVENT_Id", New ACWhere(_bteso_docspagos.TESO_DocsPagos.PVENT_Id))
            _bteso_docspagos.TESO_DocsPagos.DPAGO_Id = _bteso_docspagos.getCorrelativo("DPAGO_Id", _whereCaja)
            If _bteso_docspagos.Guardar(x_usuario) Then
               Dim _bteso_cajadocspago As New BTESO_CajaDocsPago
               _bteso_cajadocspago.TESO_CajaDocsPago = New ETESO_CajaDocsPago
               _bteso_cajadocspago.TESO_CajaDocsPago.Instanciar(ACEInstancia.Nuevo)
               _bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Codigo = x_caja_codigo
               _bteso_cajadocspago.TESO_CajaDocsPago.DPAGO_Id = _bteso_docspagos.TESO_DocsPagos.DPAGO_Id
               _bteso_cajadocspago.TESO_CajaDocsPago.PVENT_Id = item.PVENT_Id
               _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Importe = item.ImporteUsado
               _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Numero = i
               _bteso_cajadocspago.Guardar(x_usuario)
               i += 1
            End If
            '' Grabar Letra
            Dim m_bgenerardocsventa As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucursal)
            Dim x_msg As String = ""
            m_bgenerardocsventa.VENT_DocsVenta = New EVENT_DocsVenta
            m_bgenerardocsventa.VENT_DocsVenta.Instanciar(ACEInstancia.Nuevo)
            m_bgenerardocsventa.VENT_DocsVenta.ENTID_CodigoCliente = x_entid_codigo
            m_bgenerardocsventa.VENT_DocsVenta.TIPOS_CodTipoDocumento = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Letra)
            m_bgenerardocsventa.VENT_DocsVenta.DOCVE_Serie = m_pvent_id.ToString("000")
            '' Obtiene el correlativo para la letra
            Dim _wheredoc As New Hashtable
            _whereCaja.Add("TIPOS_CodTipoDocumento", New ACWhere(ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Letra)))
            _whereCaja.Add("DOCVE_Serie", New ACWhere(m_pvent_id.ToString("000")))

            m_bgenerardocsventa.VENT_DocsVenta.DOCVE_Numero = _numero ''_docventa.getCorrelativo("DOCVE_Numero", _whereCaja)
            m_bgenerardocsventa.VENT_DocsVenta.DOCVE_Estado = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Ingresado)
            m_bgenerardocsventa.VENT_DocsVenta.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
            m_bgenerardocsventa.VENT_DocsVenta.DOCVE_TipoCambio = x_tipocambio
            m_bgenerardocsventa.VENT_DocsVenta.DOCVE_TipoCambioSunat = x_tipocambiosunat
            m_bgenerardocsventa.VENT_DocsVenta.ZONAS_Codigo = m_zonas_codigo
            m_bgenerardocsventa.VENT_DocsVenta.PVENT_Id = m_pvent_id
            m_bgenerardocsventa.VENT_DocsVenta.SUCUR_Id = m_sucursal
            m_bgenerardocsventa.VENT_DocsVenta.ENTID_CodigoVendedor = _bteso_docspagos.TESO_DocsPagos.ENTID_CodigoVendedor
            m_bgenerardocsventa.VENT_DocsVenta.TIPOS_CodTipoMoneda = _bteso_docspagos.TESO_DocsPagos.TIPOS_CodTipoMoneda
            m_bgenerardocsventa.VENT_DocsVenta.DOCVE_FechaDocumento = _bteso_docspagos.TESO_DocsPagos.DPAGO_FechaGiro
            m_bgenerardocsventa.VENT_DocsVenta.DOCVE_FechaTransaccion = _bteso_docspagos.TESO_DocsPagos.DPAGO_Fecha
            m_bgenerardocsventa.VENT_DocsVenta.DOCVE_PorcentajeIGV = m_porcentajeigv
            m_bgenerardocsventa.VENT_DocsVenta.DOCVE_ImporteIgv = Math.Round(_bteso_docspagos.TESO_DocsPagos.DPAGO_Importe / (1 + m_porcentajeigv / 100), 2, MidpointRounding.AwayFromZero)
            m_bgenerardocsventa.VENT_DocsVenta.DOCVE_ImporteVenta = _bteso_docspagos.TESO_DocsPagos.DPAGO_Importe - m_bgenerardocsventa.VENT_DocsVenta.DOCVE_ImporteIgv
            m_bgenerardocsventa.VENT_DocsVenta.DOCVE_TotalVenta = _bteso_docspagos.TESO_DocsPagos.DPAGO_Importe
            m_bgenerardocsventa.VENT_DocsVenta.DOCVE_TotalPagar = _bteso_docspagos.TESO_DocsPagos.DPAGO_Importe
            '' carga los datos para generar el documento Letra
            Dim _detalle As New EVENT_DocsVentaDetalle
            _detalle.DOCVD_PrecioUnitario = m_bgenerardocsventa.VENT_DocsVenta.DOCVE_ImporteVenta
            _detalle.DOCVD_SubImporteVenta = m_bgenerardocsventa.VENT_DocsVenta.DOCVE_ImporteVenta
            _detalle.DOCVD_Cantidad = 1
            m_bgenerardocsventa.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Add(_detalle)
            '' Genera un documento Letra , en la tabla VENT_DocsVenta para que figure como nueva deuda, al cancelar las facturas seleccionadas
                If m_bgenerardocsventa.generarDocumento(x_usuario, m_bgenerardocsventa.VENT_DocsVenta.DOCVE_FechaDocumento, _
                                                        m_bgenerardocsventa.VENT_DocsVenta.DOCVE_Serie, _
                                                        m_bgenerardocsventa.VENT_DocsVenta.DOCVE_Numero, "E", x_msg, False, "") Then
                Else
                    Throw New Exception("No Se puede Generar el Documento Letra")
                End If
         Next
      Catch ex As Exception
         Throw ex
      End Try
   End Function


   ''' <summary>
   ''' Grabar Cheque, el cheque solo es una cancelación con un monto cero, para hacer referencia de que existe un cheque asociado a la deuda
   ''' </summary>
   ''' <param name="x_usuario">Codigo de usuario</param>
   ''' <param name="x_entid_codigo">Codigo de entidad</param>
   ''' <param name="x_caja_codigo">codigo de caja</param>
   ''' <param name="x_saldoafavor">valor que indica si se va a realizar un saldo a favor del sobrante</param>
   ''' <param name="x_fecha">fecha de cancelacion</param>
   ''' <param name="x_importe">importe a se cancelado, dado que al final se convierte en cero</param>
   ''' <returns>devuelve un valor verdadero si se ejecuta la consulta correctamente</returns>
   ''' <remarks></remarks>
   Private Function GrabarCheque(ByVal x_usuario As String, ByVal x_entid_codigo As String, ByVal x_caja_codigo As String, _
                                   ByVal x_saldoafavor As Boolean, ByVal x_fecha As DateTime, ByVal x_importe As Decimal) As Boolean
      Try
         Dim _bteso_docspagos As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucursal)
         Dim i As Integer = 1
         For Each item As ETESO_DocsPagos In m_listteso_docspagos
            _bteso_docspagos.TESO_DocsPagos = item
            _bteso_docspagos.TESO_DocsPagos.ENTID_Codigo = x_entid_codigo
            If _bteso_docspagos.TESO_DocsPagos.Nuevo Then
               Dim _whereCaja As New Hashtable : _whereCaja.Add("PVENT_Id", New ACWhere(_bteso_docspagos.TESO_DocsPagos.PVENT_Id))
               _bteso_docspagos.TESO_DocsPagos.DPAGO_Id = _bteso_docspagos.getCorrelativo("DPAGO_Id", _whereCaja)
               If _bteso_docspagos.Guardar(x_usuario) Then
                  Dim _bteso_cajadocspago As New BTESO_CajaDocsPago
                  _bteso_cajadocspago.TESO_CajaDocsPago = New ETESO_CajaDocsPago
                  _bteso_cajadocspago.TESO_CajaDocsPago.Instanciar(ACEInstancia.Nuevo)
                  _bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Codigo = x_caja_codigo
                  _bteso_cajadocspago.TESO_CajaDocsPago.DPAGO_Id = _bteso_docspagos.TESO_DocsPagos.DPAGO_Id
                  _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Importe = item.DPAGO_Importe
                  _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Numero = i
                  _bteso_cajadocspago.TESO_CajaDocsPago.PVENT_Id = item.PVENT_Id
                  '_bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Id = item.
                  _bteso_cajadocspago.Guardar(x_usuario)
                  i += 1
               End If
            Else
               Dim _bteso_cajadocspago As New BTESO_CajaDocsPago
               _bteso_cajadocspago.TESO_CajaDocsPago = New ETESO_CajaDocsPago
               _bteso_cajadocspago.TESO_CajaDocsPago.Instanciar(ACEInstancia.Nuevo)
               _bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Codigo = x_caja_codigo
               _bteso_cajadocspago.TESO_CajaDocsPago.DPAGO_Id = _bteso_docspagos.TESO_DocsPagos.DPAGO_Id
               _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Importe = item.DPAGO_Importe
               _bteso_cajadocspago.TESO_CajaDocsPago.PVENT_Id = item.PVENT_Id
               _bteso_cajadocspago.TESO_CajaDocsPago.CDEPO_Numero = i
               '_bteso_cajadocspago.TESO_CajaDocsPago.CAJA_Id = item.
               _bteso_cajadocspago.Guardar(x_usuario)
            End If
         Next
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Grabar Pagos de Ventas
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <param name="m_tipopago">tipo de pago</param>
   ''' <param name="x_serie">numero de serie asignado</param>
   ''' <param name="x_fecha">fecha de cancelacion</param>
   ''' <param name="x_tipocambio">tipo de cambio</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
    Public Function GrabarPagos(ByVal x_usuario As String, ByVal m_tipopago As ETipos.TipoDePago, ByVal x_serie As String, _
                                ByVal x_fecha As DateTime, ByVal x_tipocambio As Decimal, ByVal x_tipocambiosunat As Decimal, _
                                ByVal x_redondeo As TRedondeo, ByVal x_saldoafavor As Boolean, ByVal x_saldo As Boolean, ByVal x_tiporecibo As ETipos)
        Try
            '' inicia la transacción
            DAEnterprise.BeginTransaction()
            Dim _caja_codigo As String = ""
            Dim _entid_Codigo As String = ""
            Dim _importe As Decimal : Dim _tipo_moneda As String = ""
            '' Grabar en caja
            GrabarCaja(x_usuario, m_tipopago, _
                       _caja_codigo, _entid_Codigo, _importe, _tipo_moneda, _
                       x_serie, x_fecha, x_redondeo, x_tipocambio)
            '' selecciona el tipo de pago segun lo seleccionado en el formulario de cancelaciones
            Select Case m_tipopago
                Case ETipos.TipoDePago.DepositoBancario
                    GrabarDeposito(x_usuario, _entid_Codigo, _caja_codigo, x_saldoafavor, x_fecha, _importe, x_tiporecibo)
                Case ETipos.TipoDePago.Detraccion
                    GrabarDetraccion(x_usuario, _entid_Codigo, _caja_codigo)
                Case ETipos.TipoDePago.NotaCredito
                    GrabarNotaCredito(x_usuario, _entid_Codigo, _caja_codigo, x_saldoafavor, x_saldo, x_tipocambio, x_tipocambiosunat, x_fecha, _importe, x_tiporecibo)
                Case ETipos.TipoDePago.RecEgreInterno
                    GrabarRecInterno(x_usuario, _entid_Codigo, _caja_codigo)
                Case ETipos.TipoDePago.Efectivo
                    GrabarEfectivo(x_usuario, _entid_Codigo, _caja_codigo, _tipo_moneda, _importe)
                Case ETipos.TipoDePago.Letra
                    GrabarLetra(x_usuario, _entid_Codigo, _caja_codigo, x_tipocambio, x_tipocambiosunat)
                Case ETipos.TipoDePago.Cheque
                    GrabarCheque(x_usuario, _entid_Codigo, _caja_codigo, x_saldoafavor, x_fecha, _importe)
            End Select
            '' termina la transacción
            DAEnterprise.CommitTransaction()
            Return True
        Catch ex As Exception
            '' cancela la transacción en caso de haber ocurrido un error no recuperable
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

   ''' <summary>
   ''' Anular pago, esto lleva a anular el registro de caja, dependiendo del tipo de pago, si el pago fue en efectivo se anulan todos los registros generados
   ''' en el pago del documento, si el pago fue con otro medio esto genera la anulacion de solo el registro de caja, para que el medio de pago utilizado pueda
   ''' ser rehusado como pago de otra factura o de la misma
   ''' 
   ''' Se tiene que tener en cuenta que la anulacion tambien es diferente si es en el mismo dia o en un dia posterior, para cuestiones del cuadre de caja, se
   ''' genera documentos adicionales
   ''' </summary>
   ''' <param name="x_pvent_id">Codigo del punto de venta</param>
   ''' <param name="x_caja_id">ID Unico de caja</param>
   ''' <param name="x_motivo">Motivo de Anulacion del pago</param>
   ''' <param name="x_usuario">Codigo de usuario</param>
   ''' <param name="x_fecha">Fecha de anulacion</param>
   ''' <param name="x_tran">Si iinicia transaccion</param>
   ''' <returns>devuelve un valor verdadero si se ejecuta la consulta correctamente</returns>
   ''' <remarks></remarks>
   Public Function AnularPago(ByVal x_pvent_id As Integer, ByVal x_caja_id As Long, ByVal x_motivo As String, ByVal x_usuario As String, ByVal x_fecha As Date, Optional ByVal x_tran As Boolean = True) As Boolean
      Try
         If x_tran Then DAEnterprise.BeginTransaction()
         Dim _caja As New BTESO_Caja
         _caja.TESO_Caja = New ETESO_Caja
         _caja.TESO_Caja.CAJA_Estado = Constantes.getEstado(Constantes.Estado.Anulado)
         _caja.TESO_Caja.PVENT_Id = x_pvent_id
         _caja.TESO_Caja.CAJA_Id = x_caja_id
         _caja.TESO_Caja.CAJA_MotivoAnulacion = x_motivo
         _caja.TESO_Caja.Instanciar(ACEInstancia.Modificado)
         Dim _constantes As New BConstantes
         Dim _fecha As DateTime = _constantes.getFecha()
         If Not _fecha.Date = x_fecha.Date Then
            '' Verificar si el usuario tiene autorizacion
            _caja.TESO_Caja.CAJA_AnuladoCaja = True
            _caja.TESO_Caja.CAJA_FechaAnulado = _fecha
         End If
         If _caja.Guardar(x_usuario) Then
            '' Anular el Pago en Efectivo
            Dim _cajadoc As New BTESO_CajaDocsPago
            If _caja.Cargar(m_pvent_id, x_caja_id) Then
               Dim _whereCD As New Hashtable
               _whereCD.Add("CAJA_Codigo", New ACWhere(_caja.TESO_Caja.CAJA_Codigo))
               _whereCD.Add("PVENT_Id", New ACWhere(_caja.TESO_Caja.PVENT_Id))
               ' Buscar Documento de Pago
               If _cajadoc.Cargar(_whereCD) Then
                  If Not _caja.TESO_Caja.TIPOS_CodTransaccion.Equals(ETipos.getTipoDePago(ETipos.TipoDePago.Efectivo)) Then
                     If x_tran Then DAEnterprise.CommitTransaction()
                     Return True
                  End If
                  Dim _dpago As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucursal)
                  _dpago.TESO_DocsPagos = New ETESO_DocsPagos
                  _dpago.TESO_DocsPagos.Instanciar(ACEInstancia.Modificado)
                  _dpago.TESO_DocsPagos.DPAGO_Id = _cajadoc.TESO_CajaDocsPago.DPAGO_Id
                  _dpago.TESO_DocsPagos.PVENT_Id = m_pvent_id
                  _dpago.TESO_DocsPagos.DPAGO_Estado = Constantes.getEstado(Constantes.Estado.Anulado)
                  If _dpago.Guardar(x_usuario) Then
                     If x_tran Then DAEnterprise.CommitTransaction()
                     Return True
                  End If
               End If
               Return True
            End If
         End If
      Catch ex As Exception
         If x_tran Then DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function
#End Region

#Region " Procedimientos Almancenados "

   ''' <summary>
   ''' Valida si en el dia que se obtiene el cuadre de caja tiene pendientes no canceladas, si existe alguna pendientes se mostrara este listado con todos los
   ''' pendientes, hasta que no sean retirados no se mostrara el cuadre de caja y el cuadre de pendientes
   ''' </summary>
   ''' <param name="x_fecfin">Fecha final del cuadre de caja</param>
   ''' <param name="x_zonas_codigo">Codigo de la zona</param>
   ''' <param name="x_sucur_id">Codigo de la sucursal</param>
   ''' <param name="x_almac_id">Codigo del almacen</param>
   ''' <param name="x_pvent_id">Codigo del punto de venta</param>
   ''' <param name="x_entid_razonsocial">Razon social de la entidad</param>
   ''' <returns>devuelve un valor verdadero si se ejecuta la consulta correctamente</returns>
   ''' <remarks></remarks>
   Public Function ValidarPendientes(ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_entid_razonsocial As String) As Boolean
      m_listccuadrependientes = New List(Of ECCuadrePendientes)
      Try
         '' Consultara los pagos pendientes
         If VENT_CAJASS_ValidarPagos(x_fecfin, x_pvent_id, x_entid_razonsocial) Then
            For Each item As ECCuadrePendientes In m_listccuadrependientes
               item.TipoDocumento = "Pendiente de Pago"
            Next
         End If
         Dim _ordenes As New BDIST_Ordenes
         '' Consultara la ordenes pendientes de entrega
         If _ordenes.LOG_DIST_ObtenerPendientesOrdenes(x_fecfin, x_almac_id, x_pvent_id, False) Then
            For Each item As EDIST_Ordenes In _ordenes.ListDIST_Ordenes
               Dim _cpendiente As New ECCuadrePendientes
               _cpendiente.Documento = item.Documento
               _cpendiente.ENTID_RazonSocial = item.Cliente
               _cpendiente.ENTID_Codigo = item.ENTID_CodigoCliente
               _cpendiente.Seleccion = True
               _cpendiente.DOCVE_FechaPago = item.ORDEN_FechaIngreso
               _cpendiente.DOCVE_FechaPago_Old = item.ORDEN_FechaEntrega
               _cpendiente.TipoDocumento = "Pendiente de Entrega"
               m_listccuadrependientes.Add(_cpendiente)
            Next
         End If

         Dim _pedidos As New BVENT_Pedidos
         '' Consultara los pedidos de reposicion pendientes de entrega
         If _pedidos.VENT_PEDIDSS_ObtenerPedidoReposicion(x_fecfin, x_zonas_codigo, x_pvent_id, x_sucur_id, EVENT_Pedidos.TipoPedido.PR.ToString().Substring(1, 1), 0, "") Then
            For Each item As EVENT_Pedidos In _pedidos.ListVENT_Pedidos
               Dim _cpendiente As New ECCuadrePendientes
               _cpendiente.Documento = item.PEDID_Codigo
               _cpendiente.ENTID_RazonSocial = item.PVtaRelacionado
               _cpendiente.ENTID_Codigo = item.TIPOS_TipoDocumento
               _cpendiente.DOCVE_FechaPago = item.PEDID_FechaDocumento
               _cpendiente.DOCVE_FechaPago_Old = item.PEDID_FechaEntrega
               _cpendiente.TipoDocumento = "Pendiente de Entrega"
               _cpendiente.Seleccion = True
               m_listccuadrependientes.Add(_cpendiente)
            Next
         End If
         Return m_listccuadrependientes.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
    End Function
    ''' <summary>
    ''' Valida si en el dia que se obtiene el cuadre de caja tiene pendientes no canceladas, si existe alguna pendientes se mostrara este listado con todos los
    ''' pendientes, hasta que no sean retirados no se mostrara el cuadre de caja y el cuadre de pendientes
    ''' </summary>
    ''' <param name="x_fecfin">Fecha final del cuadre de caja</param>
    ''' <param name="x_zonas_codigo">Codigo de la zona</param>
    ''' <param name="x_sucur_id">Codigo de la sucursal</param>
    ''' <param name="x_almac_id">Codigo del almacen</param>
    ''' <param name="x_pvent_id">Codigo del punto de venta</param>
    ''' <param name="x_entid_razonsocial">Razon social de la entidad</param>
    ''' <returns>devuelve un valor verdadero si se ejecuta la consulta correctamente</returns>
    ''' <remarks></remarks>
    Public Function ValidarPendientesCreditos(ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_entid_razonsocial As String) As Boolean
        m_listccuadrependientes = New List(Of ECCuadrePendientes)
        Try
            '' Consultara los pagos pendientes
            If VENT_CAJASS_ValidarPagosCreditos(x_fecfin, x_pvent_id, x_entid_razonsocial) Then
                For Each item As ECCuadrePendientes In m_listccuadrependientes
                    item.TipoDocumento = "Pendiente de Pago"
                Next
            End If
            'Dim _ordenes As New BDIST_Ordenes
            ' '' Consultara la ordenes pendientes de entrega
            'If _ordenes.LOG_DIST_ObtenerPendientesOrdenesCreditos(x_fecfin, x_almac_id, x_pvent_id, False) Then
            '    For Each item As EDIST_Ordenes In _ordenes.ListDIST_Ordenes
            '        Dim _cpendiente As New ECCuadrePendientes
            '        _cpendiente.Documento = item.Documento
            '        _cpendiente.ENTID_RazonSocial = item.Cliente
            '        _cpendiente.ENTID_Codigo = item.ENTID_CodigoCliente
            '        _cpendiente.Seleccion = True
            '        _cpendiente.DOCVE_FechaPago = item.ORDEN_FechaIngreso
            '        _cpendiente.DOCVE_FechaPago_Old = item.ORDEN_FechaEntrega
            '        _cpendiente.TipoDocumento = "Pendiente de Entrega"
            '        m_listccuadrependientes.Add(_cpendiente)
            '    Next
            'End If

            'Dim _pedidos As New BVENT_Pedidos
            ' '' Consultara los pedidos de reposicion pendientes de entrega
            'If _pedidos.VENT_PEDIDSS_ObtenerPedidoReposicionCreditos(x_fecfin, x_zonas_codigo, x_pvent_id, x_sucur_id, EVENT_Pedidos.TipoPedido.PR.ToString().Substring(1, 1), 0, "") Then
            '    For Each item As EVENT_Pedidos In _pedidos.ListVENT_Pedidos
            '        Dim _cpendiente As New ECCuadrePendientes
            '        _cpendiente.Documento = item.PEDID_Codigo
            '        _cpendiente.ENTID_RazonSocial = item.PVtaRelacionado
            '        _cpendiente.ENTID_Codigo = item.TIPOS_TipoDocumento
            '        _cpendiente.DOCVE_FechaPago = item.PEDID_FechaDocumento
            '        _cpendiente.DOCVE_FechaPago_Old = item.PEDID_FechaEntrega
            '        _cpendiente.TipoDocumento = "Pendiente de Entrega"
            '        _cpendiente.Seleccion = True
            '        m_listccuadrependientes.Add(_cpendiente)
            '    Next
            'End If
            Return m_listccuadrependientes.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function


   ''' <summary> 
   ''' Capa de Negocio: VENT_CAJASS_ValidarPagos
   ''' </summary>
   ''' <param name="x_fecfin">Parametro 1: </param> 
   ''' <param name="x_pvent_id">Parametro 2: </param> 
   ''' <param name="x_entid_razonsocial">Parametro 3: </param> 
   ''' <returns>devuelve un valor verdadero si se ejecuta la consulta correctamente</returns> 
   ''' <remarks></remarks> 
   Public Function VENT_CAJASS_ValidarPagos(ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_entid_razonsocial As String) As Boolean
      m_listccuadrependientes = New List(Of ECCuadrePendientes)
      Try
         Return d_administracioncaja.VENT_CAJASS_ValidarPagos(m_listccuadrependientes, x_fecfin, x_pvent_id, x_entid_razonsocial)
      Catch ex As Exception
         Throw ex
      End Try
    End Function
    ''' <summary> 
    ''' Capa de Negocio: VENT_CAJASS_ValidarPagos ''' credito _M 05/02/2019
    ''' </summary>
    ''' <param name="x_fecfin">Parametro 1: </param> 
    ''' <param name="x_pvent_id">Parametro 2: </param> 
    ''' <param name="x_entid_razonsocial">Parametro 3: </param> 
    ''' <returns>devuelve un valor verdadero si se ejecuta la consulta correctamente</returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CAJASS_ValidarPagosCreditos(ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_entid_razonsocial As String) As Boolean
        m_listccuadrependientes = New List(Of ECCuadrePendientes)
        Try
            Return d_administracioncaja.VENT_CAJASS_ValidarPagosCreditos(m_listccuadrependientes, x_fecfin, x_pvent_id, x_entid_razonsocial)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Modulo para actualizar la fecha de pago
    ''' </summary>
    ''' <param name="x_usuario"></param>
    ''' <returns>devuelve un valor verdadero si se ejecuta la consulta correctamente</returns>
    ''' <remarks></remarks>
    Public Function ActualizarFechaPago(ByVal x_usuario As String)
        Try
            For Each item As ECCuadrePendientes In m_listccuadrependientes
                If item.Seleccion Then
                    d_administracioncaja.ActualizarFechaPago(item.DOCVE_Codigo, item.DOCVE_FechaPago, x_usuario)
                End If
            Next
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#End Region

#Region " Metodos de Controles"

#End Region
End Class
