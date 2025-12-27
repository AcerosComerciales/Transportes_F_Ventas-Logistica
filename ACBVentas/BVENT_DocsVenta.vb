Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas
Imports System.Configuration
Imports ACFramework
Imports DAConexion
Imports ACBLogistica

Public Class BVENT_DocsVenta

#Region " Variables "
    Private m_dttable As DataTable
   Private m_evendedor As EEntidades
    Private m_relacion As BVENT_DocsRelacion
    Private m_docveDetalle As BVENT_DocsVentaDetalle
    ''INSTANCIA PARA MANDAR TIPO DE DATO
    Private m_EventDocveDetalle As EVENT_DocsVentaDetalle
    ''
   Private m_listEntidades As List(Of EEntidades)

   Private m_pvent_id As Long
   Private m_periodo As String
   Private m_zonas_codigo As String
    Private m_sucur_id As Integer


#End Region


Public Property DTTabla() As DataTable
        Get
            Return m_dttable
        End Get
        Set(ByVal value As DataTable)
            m_dttable = value
        End Set
    End Property



#Region " Constructores "
   Public Sub New(ByVal x_pvent_id As Long, ByVal x_periodo As String, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Integer)
      m_pvent_id = x_pvent_id
      m_periodo = x_periodo
      m_zonas_codigo = x_zonas_codigo
      m_sucur_id = x_sucur_id
      d_vent_docsventa = New DVENT_DocsVenta()
        
   End Sub
     Public Sub New(ByVal x_periodo As String, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Integer)
      m_periodo = x_periodo
      m_zonas_codigo = x_zonas_codigo
      m_sucur_id = x_sucur_id
      d_vent_docsventa = New DVENT_DocsVenta()
    End Sub

#End Region

#Region " Propiedades "
   Public Property Vendedor() As EEntidades
      Get
         Return m_evendedor
      End Get
      Set(ByVal value As EEntidades)
         m_evendedor = value
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
#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "
#Region " Procedimientos Almacenados"
   ''' <summary> 
   ''' Capa de Negocio: VENTSS_VentasxVendedor
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_entid_codigovendedor">Parametro 3: </param> 
   ''' <param name="x_entid_codigocliente">Parametro 4: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VentasxVendedor(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigovendedor As String, ByVal x_entid_codigocliente As String) As Boolean
      m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
      Try
         Return d_vent_docsventa.VENTSS_VentasxVendedor(m_listVENT_DocsVenta, x_fecini, x_fecfin, x_entid_codigovendedor, x_entid_codigocliente)
      Catch ex As Exception
         Throw ex
      End Try
    End Function
    ''' <summary> 
    ''' Capa de Negocio: VENTSS_VentasConsultaDetallado
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_entid_codigovendedor">Parametro 3: </param> 
    ''' <param name="x_entid_codigocliente">Parametro 4: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VentasConsultaDetallado(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_pvent_id As Long, ByVal x_sucur_id As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
        m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
        Try
            Return d_vent_docsventa.VENTSS_VentasConsultaDetallado(m_listVENT_DocsVenta, x_fecini, x_fecfin, x_zonas_codigo, x_pvent_id, x_sucur_id, x_opcion, x_cadena, x_todos)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary> 
    ''' Capa de Negocio: VENTSS_VentasPorVendedor
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_entid_codigovendedor">Parametro 3: </param> 
    ''' <param name="x_entid_codigocliente">Parametro 4: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VentasPorVendedor(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigovendedor As String, ByVal x_entid_codigocliente As String) As Boolean
        m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
        Try
            Return d_vent_docsventa.VENTSS_VentasPorVendedor(m_listVENT_DocsVenta, x_fecini, x_fecfin, x_entid_codigovendedor, x_entid_codigocliente)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''llamara procedimiento para devolver motivo anulacion _a
        Public Function Obtener_Deta_Anulada(ByVal x_docve_codigo As String) As Boolean
        Try
            m_dttable = New DataTable
            Return d_vent_docsventa.Obtener_Deta_Anulada(m_dttable, x_docve_codigo)
           
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    ''' <summary> 
    ''' Capa de Negocio: VENTSS_VentasxVendedor
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_entid_codigocotizador">Parametro 3: </param> 
    ''' <param name="x_entid_codigocliente">Parametro 4: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function Ventasxcotizador(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigocotizador As String, ByVal x_entid_codigocliente As String) As Boolean
        m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
        Try
            Return d_vent_docsventa.VENTSS_VentasxCotizador(m_listVENT_DocsVenta, x_fecini, x_fecfin, x_entid_codigocotizador, x_entid_codigocliente)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   ''' <summary> 
   ''' Capa de Negocio: VEN_DOCVSS_ObtenerUltimaFecha
   ''' </summary>
   ''' <param name="x_tipos_codtipodocumento">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerUltimaFecha(ByVal x_tipos_codtipodocumento As String) As Boolean
      m_vent_docsventa = New EVENT_DocsVenta
      Try
         Return d_vent_docsventa.VEN_DOCVSS_ObtenerUltimaFecha(m_vent_docsventa, x_tipos_codtipodocumento)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    ''' <summary> 
    ''' Capa de Negocio: VENT_DOCVESS_DocumentosXNotaDebito
    ''' </summary>
    ''' <param name="x_docve_codigo">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function DocumentosRelacionados(ByVal x_docve_codigo As String) As Boolean
        m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
        Try
            Return d_vent_docsventa.VENT_DOCVESS_DocumentosRelacionados(m_listVENT_DocsVenta, x_docve_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary> 
    ''' Capa de Negocio: VENT_DOCVESS_DocumentosXNotaDebito
    ''' </summary>
    ''' <param name="x_docve_codigo">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_DOCSVESS_RELACIONADOSPAGOS(ByVal x_docve_codigo As String) As Boolean
        m_listTesoDocsPagos = New List(Of ETESO_DocsPagos)
        Try
            Return d_vent_docsventa.VENT_DOCSVESS_RELACIONADOSPAGOS(m_listTesoDocsPagos, x_docve_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: VENT_DOCVESS_DocumentosXNotaDebito
    ''' </summary>
    ''' <param name="x_pvent_id">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function ObtenerPendientesPago(ByVal x_pvent_id As Long, ByVal x_entidad As String) As Boolean
        m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
        Try
            Return d_vent_docsventa.CAJASS_ObtenerPendientesPago(m_listVENT_DocsVenta, x_pvent_id, x_entidad)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary> 
    ''' Capa de Negocio: VENT_DOCVESS_DocumentosXNotaDebito
    ''' </summary>
    ''' <param name="x_docve_codigo">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function DocumentosRelacionadoss(ByVal x_docve_codigo As String) As Boolean
        m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
        Try
            Return d_vent_docsventa.VENT_DOCVESS_DocumentosRelacionadoss(m_listVENT_DocsVenta, x_docve_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   ''' <summary> 
   ''' Capa de Negocio: VENT_VENTSS_RomperRelacionDocsVentas
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <param name="x_pvent_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function RomperRelacionDocsVentas(ByVal x_docve_codigo As String, ByVal x_pvent_id As Long, ByVal x_xpago As Boolean) As Boolean
      Try
         d_vent_docsventa.VENT_VENTSS_RomperRelacionDocsVentas(x_docve_codigo, x_pvent_id, x_xpago)
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

   ''' <summary>
   ''' obtener documento de venta
   ''' </summary>
   ''' <param name="x_serie">serie del documento</param>
   ''' <param name="x_numero">numero del documento</param>
   ''' <param name="x_todos">cargar todos incluidos los anulados</param>
   ''' <param name="x_tipo">tipo de documento</param>
   ''' <param name="x_fechas">opcion para buscar por fecha</param>
   ''' <param name="x_fecini">fecha inicial de busqueda</param>
   ''' <param name="x_fecfin">fecha final de busqueda</param>
   ''' <param name="x_pvenrt_id">codigo del punto de venta</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getDocumentos(ByVal x_serie As String, ByVal x_numero As String, ByVal x_todos As Boolean, ByVal x_tipo As String _
                               , ByVal x_fechas As Boolean, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime, ByVal x_pvenrt_id As Long) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         Dim _where As New Hashtable()
         setJoinWhere(_join, _where, x_todos)
         _where.Add("DOCVE_Serie", New ACWhere(x_serie, ACWhere.TipoWhere.Igual))
         _where.Add("DOCVE_Numero", New ACWhere(x_numero, ACWhere.TipoWhere._Like))
         _where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_tipo, ACWhere.TipoWhere.Igual))
         If x_pvenrt_id <> 0 Then
            _where.Add("PVENT_Id", New ACWhere(x_pvenrt_id, ACWhere.TipoWhere.Igual))
         End If
         m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
         Return d_vent_docsventa.VENT_DOCVESS_Todos(m_listVENT_DocsVenta, _join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' 'getImpresiones'
   ''' </summary>
   ''' <param name="x_docveCodigo"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getImpresiones(ByVal x_docveCodigo As String) As Boolean
      Try
         'Dim _join As New List(Of ACJoin)
         Dim _where As New Hashtable()
         _where.Add("DOCVE_Codigo", New ACWhere(x_docveCodigo, ACWhere.TipoWhere.Igual))
         _where.Add("DOCVE_Impresiones", New ACWhere(1, ACWhere.TipoWhere.MayorIgual))
        m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
         Return d_vent_docsventa.VENT_Impresiones(m_listVENT_DocsVenta, _where)
      Catch ex As Exception
         Throw ex
      End Try
    End Function

    ''' <summary>
    ''' 'getSunat'
    ''' </summary>
    ''' <param name="x_docveCodigo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getSunat(ByVal x_docveCodigo As String) As Boolean
        Try
            'Dim _join As New List(Of ACJoin)
            Dim _where As New Hashtable()
            _where.Add("DOCVE_Codigo", New ACWhere(x_docveCodigo, ACWhere.TipoWhere.Igual))
            _where.Add("generado", New ACWhere(2, ACWhere.TipoWhere.Igual))
            m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
            Return d_vent_docsventa.VENT_Sunat(m_listVENT_DocsVenta, _where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function





   ''' <summary>
   ''' Obtenr documento segun el numero de documento
   ''' </summary>
   ''' <param name="x_serie">serie del documento</param>
   ''' <param name="x_numero">numero del documento</param>
   ''' <param name="x_todos">cargar todos los documentos incluidos los anulados</param>
   ''' <param name="x_tipo">tipo de documentos</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getDocumentos(ByVal x_serie As String, ByVal x_numero As Integer, ByVal x_todos As Boolean, ByVal x_tipo As String) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         Dim _where As New Hashtable()
         setJoinWhere(_join, _where, x_todos)
         _where.Add("DOCVE_Serie", New ACWhere(x_serie, ACWhere.TipoWhere.Igual))
         _where.Add("DOCVE_Numero", New ACWhere(x_numero, ACWhere.TipoWhere._Like))
         _where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_tipo, ACWhere.TipoWhere.Igual))
         m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
         Return d_vent_docsventa.VENT_DOCVESS_Todos(m_listVENT_DocsVenta, _join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' busqueda de documentos de venta por los datos del cliente o entidad
   ''' </summary>
   ''' <param name="x_cadena">cadena de busqueda</param>
   ''' <param name="x_campo">campo para la busqueda</param>
   ''' <param name="x_todos">cargar todos incluidos los anulados</param>
   ''' <param name="x_fechas">opcion de uso de fecha</param>
   ''' <param name="x_fecini">fecha inicial de busqueda</param>
   ''' <param name="x_fecfin">fehca final de busqueda</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getCliente(ByVal x_cadena As String, ByVal x_campo As String, ByVal x_todos As Boolean _
                         , ByVal x_fechas As Boolean, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         Dim _where As New Hashtable()
         setJoinWhere(_join, _where, x_todos, x_fechas, x_fecini, x_fecfin)
         _where.Add(x_campo, New ACWhere(x_cadena, "Cli", "System.String", ACWhere.TipoWhere._Like))
         Return CargarTodos(_join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' obtener el documento de venta por cliente
   ''' </summary>
   ''' <param name="x_cadena">cadena de busqueda</param>
   ''' <param name="x_campo">campo de busqueda</param>
   ''' <param name="x_todos">cargar todos incluidos los anulados</param>
   ''' <param name="x_fechas">opcion de busqueda por fecha</param>
   ''' <param name="x_fecini">fecha inicial de busqueda</param>
   ''' <param name="x_fecfin">fecha final de busqueda</param>
   ''' <param name="x_pvent_id">codigo de punto de venta</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getCliente(ByVal x_cadena As String, ByVal x_campo As String, ByVal x_todos As Boolean _
                            , ByVal x_fechas As Boolean, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime _
                            , ByVal x_pvent_id As Long) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         Dim _where As New Hashtable()
         setJoinWhere(_join, _where, x_todos, x_fechas, x_fecini, x_fecfin)
         _where.Add(x_campo, New ACWhere(x_cadena, "Cli", "System.String", ACWhere.TipoWhere._Like))
         _where.Add("PVENT_Id", New ACWhere(x_pvent_id))
         _where.Add("TIPOS_CodTipoDocumento", New ACWhere("CPD07",ACWhere.TipoWhere.Diferente))
         Return CargarTodos(_join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: VENT_VENTSS_BusDocsVenta
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_zonas_codigo">Parametro 3: </param> 
   ''' <param name="x_pvent_id">Parametro 4: </param> 
   ''' <param name="x_sucur_id">Parametro 5: </param> 
   ''' <param name="x_opcion">Parametro 6: </param> 
   ''' <param name="x_cadena">Parametro 7: </param> 
   ''' <param name="x_todos">Parametro 8: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function BusDocsVenta(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_pvent_id As Long, ByVal x_sucur_id As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
      Try
         Return d_vent_docsventa.VENT_VENTSS_BusDocsVenta(m_listVENT_DocsVenta, x_fecini, x_fecfin, x_zonas_codigo, x_pvent_id, x_sucur_id, x_opcion, x_cadena, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

       ''' <summary> 
   ''' Capa de Negocio: VENT_VENTSS_BusDocsVenta x numero y linea
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_zonas_codigo">Parametro 3: </param> 
   ''' <param name="x_pvent_id">Parametro 4: </param> 
   ''' <param name="x_sucur_id">Parametro 5: </param> 
   ''' <param name="x_opcion">Parametro 6: </param> 
   ''' <param name="x_cadena">Parametro 7: </param> 
   ''' <param name="x_todos">Parametro 8: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
    Public Function BusDocsVentaXnumeroYlinea(ByVal x_peventid As Short, ByVal x_numero As Long, ByVal x_serie As String, ByVal x_tipo As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean,
                                             ByVal x_linea As String) As Boolean
        m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
        Try
            Return d_vent_docsventa.VENT_VENTSS_BusDocsVentaXnumYlinea(m_listVENT_DocsVenta, x_peventid, x_numero, x_serie, x_tipo, x_opcion, x_cadena, x_todos, x_linea)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
        ''' <summary> 
   ''' Capa de Negocio: VENT_VENTSS_BusDocsVenta X linea
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_zonas_codigo">Parametro 3: </param> 
   ''' <param name="x_pvent_id">Parametro 4: </param> 
   ''' <param name="x_sucur_id">Parametro 5: </param> 
   ''' <param name="x_opcion">Parametro 6: </param> 
   ''' <param name="x_cadena">Parametro 7: </param> 
   ''' <param name="x_todos">Parametro 8: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function BusDocsVentaXlinea(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_tipo As String, ByVal x_pvent_id As Long, ByVal x_sucur_id As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean,
                                             ByVal x_linea As String) As Boolean
      m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
      Try
         Return d_vent_docsventa.VENT_VENTSS_BusDocsVentaXlinea(m_listVENT_DocsVenta, x_fecini, x_fecfin, x_tipo, x_zonas_codigo, x_pvent_id, x_sucur_id, x_opcion, x_cadena, x_todos,x_linea)
      Catch ex As Exception
         Throw ex
      End Try
   End Function


   ''' <summary>
   ''' Obtener los documento de venta usando los datos de los clientes
   ''' </summary>
   ''' <param name="x_cadena">cadena de busqueda</param>
   ''' <param name="x_campo">campo de busqueda</param>
   ''' <param name="x_todos">mostrar todos los registros incluidos los anulados</param>
   ''' <param name="x_fechas">opcion de busqu3eda por fecha</param>
   ''' <param name="x_fecini">fecha inicial de busqueda</param>
   ''' <param name="x_fecfin">fecha final de busquedqa</param>
   ''' <param name="x_pvent_id">codigo de punto de venta</param>
   ''' <param name="x_in">condicion in</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getCliente(ByVal x_cadena As String, ByVal x_campo As String, ByVal x_todos As Boolean _
                         , ByVal x_fechas As Boolean, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime _
                         , ByVal x_pvent_id As Long, ByVal x_in As String) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         Dim _where As New Hashtable()
         _where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_in, ACWhere.TipoWhere._In))
         setJoinWhere(_join, _where, x_todos, x_fechas, x_fecini, x_fecfin)
         _where.Add(x_campo, New ACWhere(x_cadena, "Cli", "System.String", ACWhere.TipoWhere._Like))
         _where.Add("PVENT_Id", New ACWhere(x_pvent_id))
         Return CargarTodos(_join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' generador de join
   ''' </summary>
   ''' <param name="_join"></param>
   ''' <param name="_where"></param>
   ''' <param name="x_todos"></param>
   ''' <param name="x_fechas"></param>
   ''' <param name="x_fecini"></param>
   ''' <param name="x_fecfin"></param>
   ''' <remarks></remarks>
   Private Sub setJoinWhere(ByRef _join As List(Of ACJoin), ByRef _where As Hashtable, ByVal x_todos As Boolean, ByVal x_fechas As Boolean, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime)
      Try
         _join.Add(New ACJoin("dbo", "Entidades", "Cli", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoCliente")} _
                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Cliente"), New ACCampos("ENTID_NroDocumento", "ENTID_NroDocumento")}))
         _join.Add(New ACJoin("dbo", "Entidades", "Vend", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoVendedor")} _
                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Vendedor")}))
         _join.Add(New ACJoin("dbo", "Tipos", "TDoc", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                            , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoDocumento") _
                                              , New ACCampos("TIPOS_DescCorta", "TIPOS_TipoDocCorta")}))
         _join.Add(New ACJoin("dbo", "Tipos", "TMon", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoMoneda")} _
                            , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_TipoMoneda")}))
         _join.Add(New ACJoin("dbo", "Tipos", "TCon", ACJoin.TipoJoin.Left _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodCondicionPago")} _
                            , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_CondicionPago")}))
         _join.Add(New ACJoin("dbo", "Entidades", "Us", ACJoin.TipoJoin.Left _
                            , New ACCampos() {New ACCampos("USUAR_Codigo", "DOCVE_UsrCrea")} _
                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "Usuario")}))

         If x_fechas Then _where.Add("DOCVE_FechaDocumento", New ACWhere(x_fecini, x_fecfin, ACWhere.TipoWhere.Between))
         If Not x_todos Then _where.Add("DOCVE_Estado", New ACWhere(EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Anulado), ACWhere.TipoWhere.Diferente))
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   ''' <summary>
   ''' generador de join
   ''' </summary>
   ''' <param name="_join"></param>
   ''' <param name="_where"></param>
   ''' <param name="x_todos"></param>
   ''' <remarks></remarks>
   Private Sub setJoinWhere(ByRef _join As List(Of ACJoin), ByRef _where As Hashtable, ByVal x_todos As Boolean)
      Try
         _join.Add(New ACJoin("dbo", "Entidades", "Cli", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoCliente")} _
                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Cliente"), New ACCampos("ENTID_NroDocumento", "ENTID_NroDocumento")}))
         _join.Add(New ACJoin("dbo", "Entidades", "Vend", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoVendedor")} _
                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Vendedor")}))
         _join.Add(New ACJoin("dbo", "Tipos", "TDoc", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                            , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoDocumento") _
                                              , New ACCampos("TIPOS_DescCorta", "TIPOS_TipoDocCorta")}))
         _join.Add(New ACJoin("dbo", "Tipos", "TMon", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoMoneda")} _
                            , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_TipoMoneda")}))
         '_join.Add(New ACJoin("dbo", "Tipos", "TPag", ACJoin.TipoJoin.Left _
         '                   , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoPago")} _
         '                   , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_TipoPago")}))
         _join.Add(New ACJoin("dbo", "Tipos", "TCon", ACJoin.TipoJoin.Left _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodCondicionPago")} _
                            , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_CondicionPago")}))
         _join.Add(New ACJoin("dbo", "Entidades", "Us", ACJoin.TipoJoin.Left _
                            , New ACCampos() {New ACCampos("USUAR_Codigo", "DOCVE_UsrCrea")} _
                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "Usuario")}))

         If Not x_todos Then _where.Add("DOCVE_Estado", New ACWhere(EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Anulado), ACWhere.TipoWhere.Diferente))
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   ''' <summary>
   ''' Anular Documento de Venta para Transportes
   ''' </summary>
   ''' <param name="x_docve_codigo"></param>
   ''' <param name="x_pedid_codigo"></param>
   ''' <param name="x_usuario"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
    Public Function AnularDocumentoTransportes(ByVal x_docve_codigo As String, ByVal x_pedid_codigo As String, ByVal x_motivo As String, ByVal x_usuario As String) As Boolean
        Try
            DAEnterprise.BeginTransaction()
            m_vent_docsventa = New EVENT_DocsVenta()
            m_vent_docsventa.Instanciar(ACEInstancia.Modificado)
            m_vent_docsventa.DOCVE_Codigo = x_docve_codigo
            'Agregado frank para transportes dll
            Cargar(x_docve_codigo)
            If d_vent_docsventa.getFecha().Date <> m_vent_docsventa.DOCVE_FechaDocumento.Date Then
                m_vent_docsventa.DOCVE_AnuladoCaja = True
            End If
            m_vent_docsventa.DOCVE_Estado = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Anulado)
            m_vent_docsventa.DOCVE_MotivoAnulacion = x_motivo
            If Guardar(x_usuario, New String() {"DOCVE_FecAnulacion"}) Then                '' Cambiar el estado de la cotización
                If Not IsNothing(x_pedid_codigo) Then
                    Dim _bvent_pedidos As New BVENT_Pedidos()
                    _bvent_pedidos.VENT_Pedidos = New EVENT_Pedidos
                    _bvent_pedidos.VENT_Pedidos.PEDID_Estado = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Ingresado)
                    _bvent_pedidos.VENT_Pedidos.PEDID_Codigo = x_pedid_codigo
                    _bvent_pedidos.VENT_Pedidos.Instanciar(ACEInstancia.Modificado)
                    '' Actualizar el Pedido
                    If _bvent_pedidos.Guardar(x_usuario) Then
                        DAEnterprise.CommitTransaction()
                        Return True
                    Else
                        DAEnterprise.RollBackTransaction()
                        Return False
                    End If
                Else
                    DAEnterprise.CommitTransaction()
                    Return True
                End If
            End If
            DAEnterprise.RollBackTransaction()
            Return False
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

   ''' <summary>
   ''' Anular un documento de Venta, y liberar la cotización correspondiente
   ''' </summary>
   ''' <param name="x_docve_codigo">Codigo de Documento de Venta</param>
   ''' <param name="x_docve_fecha">Fecha del Documento de Venta</param>
   ''' <param name="x_pedid_codigo">Codigo de Pedido</param>
   ''' <param name="m_proceso">Permiso de Anulacion</param>
   ''' <param name="x_usuario">usuario que realiza el proceso</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
    Public Function AnularDocumentoVentas(ByVal x_docve_codigo As String, ByVal x_docve_fecha As Date, ByVal x_pedid_codigo As String, _
                                    ByVal m_proceso As Boolean, ByVal x_motivo As String, ByVal x_paseanulacion As Boolean, ByVal x_usuario As String) As Boolean
        Try
            '' Verificar Guias de Remision
            Dim _guias As New BDIST_GuiasRemision
            Dim _whereguia As New Hashtable
            _whereguia.Add("DOCVE_Codigo", New ACWhere(x_docve_codigo))
            _whereguia.Add("GUIAR_Estado", New ACWhere(Constantes.getEstado(Constantes.Estado.Anulado), ACWhere.TipoWhere.Diferente))
            If _guias.Cargar(_whereguia) Then
                Throw New Exception("El documento tienen Guias Generadas, primero debe anular las guias para proceder")
            End If
            '' Verificar Ordenes
            Dim _orden As New BDIST_Ordenes
            Dim _whereorden As New Hashtable
            _whereorden.Add("DOCVE_Codigo", New ACWhere(x_docve_codigo))
            _whereorden.Add("ORDEN_Estado", New ACWhere(Constantes.getEstado(Constantes.Estado.Anulado), ACWhere.TipoWhere.Diferente))
            If _orden.Cargar(_whereorden) Then
                Throw New Exception("El documento tiene ordenes, primero debe anular las ordenes para poder proceder")
            End If
            '' verificar que no tenga pagos activos
            Dim _caja As New BTESO_Caja
            Dim _wherecaja As New Hashtable
            _wherecaja.Add("DOCVE_Codigo", New ACWhere(x_docve_codigo))
            _wherecaja.Add("CAJA_Estado", New ACWhere(Constantes.getEstado(Constantes.Estado.Anulado), ACWhere.TipoWhere.Diferente))
            _wherecaja.Add("TIPOS_CodTransaccion", New ACWhere(ETipos.getTipoDePago(ETipos.TipoDePago.Efectivo), ACWhere.TipoWhere.Diferente))
            If _caja.Cargar(_wherecaja) Then
                Throw New Exception("No se puede Anular un Documento que tiene pagos, primero tiene que anular los pagos para proceder")
            End If
            '' Comerzar proceso de Anulacion de document
            DAEnterprise.BeginTransaction()
            m_vent_docsventa = New EVENT_DocsVenta()
            m_vent_docsventa.Instanciar(ACEInstancia.Modificado)
            m_vent_docsventa.DOCVE_Codigo = x_docve_codigo
            m_vent_docsventa.DOCVE_AnuladoCaja = False
            m_vent_docsventa.DOCVE_MotivoAnulacion = x_motivo
            m_vent_docsventa.DOCVE_Estado = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Anulado)
            '' Verificar opciones de Anulacion
            Dim _constantes As New BConstantes
            Dim _eliFec As Boolean = False
            If Not _constantes.getFecha().Date = x_docve_fecha.Date Then
                '' Verificar si el usuario tiene autorizacion
                If Not m_proceso Then
                    If Not x_paseanulacion Then
                        Throw New Exception("No se puede anular un documento despues de la fecha de emision, consulte con su administrador")
                    End If
                End If
                m_vent_docsventa.DOCVE_AnuladoCaja = True
                _eliFec = True
            End If
            If Guardar(x_usuario, New String() {"DOCVE_FecAnulacion"}) Then
                '' Anular Pagos
                ' Anula en Caja
                _wherecaja = New Hashtable
                _wherecaja.Add("DOCVE_Codigo", New ACWhere(x_docve_codigo))
                _wherecaja.Add("CAJA_Estado", New ACWhere(Constantes.getEstado(Constantes.Estado.Anulado), ACWhere.TipoWhere.Diferente))
                _wherecaja.Add("TIPOS_CodTransaccion", New ACWhere(ETipos.getTipoDePago(ETipos.TipoDePago.Efectivo), ACWhere.TipoWhere.Igual))
                ' Buscar el registro de pago en caja
                If _caja.Cargar(_wherecaja) Then
                    Dim managerbadministracioncaja As New BAdminCaja(m_zonas_codigo, m_sucur_id, _caja.TESO_Caja.PVENT_Id, m_periodo)
                    Dim _motivo As String = String.Format("Por anulación automatica de Documento de Venta {0}", m_vent_docsventa.DOCVE_Codigo)
                    managerbadministracioncaja.AnularPago(_caja.TESO_Caja.PVENT_Id, _caja.TESO_Caja.CAJA_Id, _motivo, x_usuario, _caja.TESO_Caja.CAJA_Fecha, False)
                    Dim _cajadoc As New BTESO_CajaDocsPago
                    Dim _whereCD As New Hashtable
                    _whereCD.Add("CAJA_Codigo", New ACWhere(_caja.TESO_Caja.CAJA_Codigo))
                    _whereCD.Add("PVENT_Id", New ACWhere(_caja.TESO_Caja.PVENT_Id))
                    ' Buscar Documento de Pago
                    If _cajadoc.Cargar(_whereCD) Then
                        Dim _dpago As New BTESO_DocsPagos(_caja.TESO_Caja.PVENT_Id, m_periodo, m_zonas_codigo, m_sucur_id)
                        _dpago.TESO_DocsPagos = New ETESO_DocsPagos
                        _dpago.TESO_DocsPagos.Instanciar(ACEInstancia.Modificado)
                        _dpago.TESO_DocsPagos.DPAGO_Id = _cajadoc.TESO_CajaDocsPago.DPAGO_Id
                        _dpago.TESO_DocsPagos.PVENT_Id = _caja.TESO_Caja.PVENT_Id
                        _dpago.TESO_DocsPagos.DPAGO_Estado = Constantes.getEstado(Constantes.Estado.Anulado)
                        _dpago.Guardar(x_usuario)
                    End If
                End If
                ' Anula el doc de pago
                '' Cambiar el estado de la cotización
                If Not IsNothing(x_pedid_codigo) Then

                    Dim _pedidos As New BVENT_Pedidos()
                    _pedidos.Cargar(x_pedid_codigo)
                    '' Actualizar Estado de la Cotización
                    Dim _bvent_pedidos As New BVENT_Pedidos()
                    _bvent_pedidos.VENT_Pedidos = New EVENT_Pedidos
                    _bvent_pedidos.VENT_Pedidos.PEDID_Estado = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Ingresado)
                    _bvent_pedidos.VENT_Pedidos.PEDID_Codigo = x_pedid_codigo
                    _bvent_pedidos.VENT_Pedidos.PEDID_DocumentoPercepcion = _pedidos.VENT_Pedidos.PEDID_DocumentoPercepcion
                    _bvent_pedidos.VENT_Pedidos.PEDID_ParaFacturar = True
                    _bvent_pedidos.VENT_Pedidos.Instanciar(ACEInstancia.Modificado)

                    ' '' Devolver el Stock Cargado si es una Cotización
                    Dim m_tipoDocumento As EVENT_Pedidos.TipoPedido = EVENT_Pedidos.TipoCotizacionCodigo(x_pedid_codigo)
                    Select Case m_tipoDocumento
                        Case EVENT_Pedidos.TipoPedido.CT
                            '' Cargar el Detalle
                            If Cargar(x_docve_codigo, True) Then
                                '' Anular Egreso de cada detalle
                                For Each Item As EVENT_DocsVentaDetalle In m_vent_docsventa.ListVENT_DocsVentaDetalle
                                    Dim m_bmanejarstocks As New BManejarStock()
                                    m_bmanejarstocks.AnulacionEgresoFactura(m_periodo, Item.ARTIC_Codigo, Item.ALMAC_Id, _
                                                                            m_vent_docsventa.DOCVE_Codigo, Item.DOCVD_Item, Item.DOCVD_Cantidad, x_usuario)
                                Next
                            End If
                        Case EVENT_Pedidos.TipoPedido.PD, EVENT_Pedidos.TipoPedido.PI
                            Dim _generarpedido As New BGenerarCotizacion(m_periodo)
                            _generarpedido.ActivarPedido(_pedidos.VENT_Pedidos.PEDID_Codigo, x_usuario, False)
                            '' Cargar el Detalle
                            If Cargar(x_docve_codigo, True) Then
                                '' Anular Egreso de cada detalle
                                For Each Item As EVENT_DocsVentaDetalle In m_vent_docsventa.ListVENT_DocsVentaDetalle
                                    Dim m_bmanejarstocks As New BManejarStock()
                                    m_bmanejarstocks.AnulacionEgresoFactura(m_periodo, Item.ARTIC_Codigo, Item.ALMAC_Id, _
                                                                            m_vent_docsventa.DOCVE_Codigo, Item.DOCVD_Item, Item.DOCVD_Cantidad, x_usuario)
                                Next
                            End If
                        Case EVENT_Pedidos.TipoPedido.PD, EVENT_Pedidos.TipoPedido.PS
                            Dim _generarpedido As New BGenerarCotizacion(m_periodo)
                            _generarpedido.ActivarPedido(_pedidos.VENT_Pedidos.PEDID_Codigo, x_usuario, False)
                    End Select
                    '' Actualizar el Pedido
                    If _bvent_pedidos.Guardar(x_usuario) Then
                        DAEnterprise.CommitTransaction()
                        Return True
                    Else
                        DAEnterprise.RollBackTransaction()
                        Return False
                    End If
                Else
                    DAEnterprise.CommitTransaction()
                    Return True
                End If
            End If
            DAEnterprise.RollBackTransaction()
            Return False
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function


    ' <summary>
    ' anular Entrega de almacen x item ---ventas
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
    Public Function AnularEntregaAlmacenXItem(ByVal x_docve_codigo As String, ByVal x_artic_codigo As String, ByVal x_docvd_item As Short, _
                                       ByVal x_cantidad As Double, ByVal x_docve_fecha As Date, ByVal m_proceso As Boolean, ByVal x_motivo As String, ByVal x_usuario As String) As Boolean
        Try
            Dim m_documento As New BVENT_DocsVentaDetalle
            m_documento.VENT_DocsVentaDetalle = New EVENT_DocsVentaDetalle
            Dim _where As New Hashtable
            _where.Add("ARTIC_Codigo", New ACFramework.ACWhere(x_artic_codigo))
            _where.Add("DOCVE_Codigo", New ACFramework.ACWhere(x_docve_codigo))
            _where.Add("DOCVD_Item", New ACFramework.ACWhere(x_docvd_item))
            If m_documento.Cargar(_where) Then
                If m_documento.VENT_DocsVentaDetalle.DOCVD_CantidadEntregada > 0 Then
                    Dim _cant As Decimal = m_documento.VENT_DocsVentaDetalle.DOCVD_CantidadEntregada
                    m_documento.VENT_DocsVentaDetalle = New EVENT_DocsVentaDetalle()
                    m_documento.VENT_DocsVentaDetalle.Instanciar(ACFramework.ACEInstancia.Modificado)
                    m_documento.VENT_DocsVentaDetalle.DOCVE_Codigo = x_docve_codigo
                    m_documento.VENT_DocsVentaDetalle.ARTIC_Codigo = x_artic_codigo
                    m_documento.VENT_DocsVentaDetalle.DOCVD_Item = x_docvd_item
                    m_documento.VENT_DocsVentaDetalle.DOCVD_Motivo = x_motivo
                    m_documento.VENT_DocsVentaDetalle.DOCVD_CantidadEntregada = _cant - x_cantidad
                    _cant = _cant - x_cantidad
                    '' Verificar opciones de Anulacion
                    Dim _constantes As New BConstantes
                    Dim _eliFec As Boolean = False
                    If Not _constantes.getFecha().Date = x_docve_fecha.Date Then
                        '' Verificar si el usuario tiene autorizacion
                        If Not m_proceso Then

                            Throw New Exception("No se puede anular una entrega despues de la fecha de emision, consulte con su administrador")

                        End If

                        _eliFec = True
                    End If
                    'Return m_documento.Guardar(x_usuario, _cant, True)
                    If m_documento.Guardar(x_usuario, _cant, True) Then
                        Return True
                    End If
                    Return False
                Else
                    'Return True
                    Return False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' anular Entrega de almacen - todo ---ventas
    ''' </summary>
    ''' <param name="x_periodo"></param>
    ''' <param name="x_artic_codigo"></param>
    ''' <param name="x_almac_id"></param>
    ''' <param name="x_guiar_codigo"></param>
    ''' <param name="x_guird_item"></param>
    ''' <param name="x_cantidad"></param>
    ''' <param name="x_usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AnularEntregaAlmacenTodo(ByVal x_docve_codigo As String, ByVal x_docve_fecha As Date, ByVal m_proceso As Boolean, ByVal x_motivo As String, ByVal x_usuario As String) As Boolean
        Try
            Dim m_documento As New BVENT_DocsVentaDetalle
            m_documento.VENT_DocsVentaDetalle = New EVENT_DocsVentaDetalle
            Dim _where As New Hashtable
            '--_where.Add("ARTIC_Codigo", New ACFramework.ACWhere(x_artic_codigo))
            _where.Add("DOCVE_Codigo", New ACFramework.ACWhere(x_docve_codigo))
            ' --- _where.Add("DOCVD_Item", New ACFramework.ACWhere(x_docvd_item))
            If m_documento.Cargar(_where) Then
                ''Anular Egreso de cada detalle
                For Each Item As EVENT_DocsVentaDetalle In m_documento.ListVENT_DocsVentaDetalle
                    AnularEntregaAlmacenXItem(x_docve_codigo, Item.ARTIC_Codigo, Item.DOCVD_Item, Item.DOCVD_Cantidad, x_docve_fecha, m_proceso, x_motivo, x_usuario)
                Next
                Return True
            Else
                'Return True
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' Anular un documento de Venta, y liberar la cotización correspondiente
    ''' </summary>
    ''' <param name="x_docve_codigo">Codigo de Documento de Venta</param>
    ''' <param name="x_docve_fecha">Fecha del Documento de Venta</param>
    ''' <param name="x_docverefer_codigo">Codigo de Pedido</param>
    ''' <param name="m_proceso">Permiso de Anulacion</param>
    ''' <param name="x_usuario">usuario que realiza el proceso</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AnularDocumentoNC(ByVal x_docve_codigo As String, ByVal x_docve_fecha As Date, ByVal x_docverefer_codigo As String, _
                                    ByVal m_proceso As Boolean, ByVal x_motivo As String, ByVal x_usuario As String, ByVal x_TIPO_NOTA As String,
                                      ByVal x_periodo As String) As Boolean
        Try


            '' verificar que no tenga pagos activos
            Dim _caja As New BTESO_Caja
            Dim _wherecaja As New Hashtable
            _wherecaja.Add("DOCVE_Codigo", New ACWhere(x_docve_codigo))
            _wherecaja.Add("CAJA_Estado", New ACWhere(Constantes.getEstado(Constantes.Estado.Anulado), ACWhere.TipoWhere.Diferente))
            _wherecaja.Add("TIPOS_CodTransaccion", New ACWhere(ETipos.getTipoDePago(ETipos.TipoDePago.Efectivo), ACWhere.TipoWhere.Diferente))
            If _caja.Cargar(_wherecaja) Then
                Throw New Exception("No se puede Anular un Documento que tiene pagos, primero tiene que anular los pagos para proceder")
            End If
            '' Comerzar proceso de Anulacion de document
            DAEnterprise.BeginTransaction()
            m_vent_docsventa = New EVENT_DocsVenta()
            m_vent_docsventa.Instanciar(ACEInstancia.Modificado)
            m_vent_docsventa.DOCVE_Codigo = x_docve_codigo
            m_vent_docsventa.DOCVE_AnuladoCaja = False
            m_vent_docsventa.DOCVE_MotivoAnulacion = x_motivo
            m_vent_docsventa.DOCVE_Estado = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Anulado)
            '' '' Verificar opciones de Anulacion
            Dim _constantes As New BConstantes
            Dim _eliFec As Boolean = False
            If Not _constantes.getFecha().Date = x_docve_fecha.Date Then
                '' Verificar si el usuario tiene autorizacion
                If Not m_proceso Then
                    Throw New Exception("No se puede anular un documento despues de la fecha de emision, consulte con su administrador")
                End If
                m_vent_docsventa.DOCVE_AnuladoCaja = True
                _eliFec = True
            End If
            If Guardar(x_usuario, New String() {"DOCVE_FecAnulacion"}) Then
                '' 
                '' verifica caja
                Dim _join As New List(Of ACJoin)
                _join.Add(New ACJoin("Tesoreria", "TESO_CajaDocsPago", "CDPag", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("CAJA_Codigo", "CAJA_Codigo")}))
                
               dim _wheRE = new String() {x_docve_codigo,Constantes.getEstado(Constantes.Estado.Anulado),ETipos.getTipoDocPago(ETipos.TipoDocPago.NotaCredito)}
              

                If _caja.Cargar_DP(_join,_where) Then
                Throw New Exception("No se puede anular la nota de credito ya que esta cancelando una factura, consulte con su administrador")
                End If
                
                '''escoger tipo de nota de credito
                ''' 
                
                If x_TIPO_NOTA =ETipos.getMotivoNotaCredito(ETipos.MotivoNotaCredito.DevolucionItem) Or x_TIPO_NOTA =ETipos.getMotivoNotaCredito(ETipos.MotivoNotaCredito.DevolucionTotal) or x_TIPO_NOTA=ETipos.getMotivoNotaCredito(ETipos.MotivoNotaCredito.AnulacionOperacion) or x_TIPO_NOTA=ETipos.getMotivoNotaCredito(ETipos.MotivoNotaCredito.AnulacionRuc)
                    ' ''ELIMINAR RELACION
                    'm_relacion = new BVENT_DocsRelacion()
                    'Dim _whererel As New Hashtable
                    '_whererel.Add("DOCVE_Codigo", New ACWhere(x_docve_codigo))
                    'm_relacion.Eliminar(_whererel)
                    ' ''ANULAR STOCK
                    If Cargar(x_docve_codigo, True) Then
                        '' Cargar el Detalle
                        ' If Cargar(x_docve_codigo, True) Then
                        '' Anular Egreso de cada detalle
                        For Each Item As EVENT_DocsVentaDetalle In m_vent_docsventa.ListVENT_DocsVentaDetalle
                            Dim m_bmanejarstocks As New BManejarStock()
                            m_bmanejarstocks.AnulacionEgresoFactura(m_periodo, Item.ARTIC_Codigo, Item.ALMAC_Id, _
                                                                    m_vent_docsventa.DOCVE_Codigo, Item.DOCVD_Item, Item.DOCVD_Cantidad, x_usuario)
                        Next
                        'End If
                        '    '' Anular Egreso de cada detalle
                        '    For Each Item As EVENT_DocsVentaDetalle In m_vent_docsventa.ListVENT_DocsVentaDetalle
                        '        Dim m_bmanejarstocks As New BManejarStock()

                        '        'eliminar de log stock
                        '        Dim m_stock As New BLOG_Stocks()
                        '        Dim _whereres As New Hashtable
                        '        _whereres.Add("DOCVE_Codigo", New ACWhere(x_docve_codigo)) 
                        '        _whereres.Add("DOCVD_Item",New ACWhere(Item.DOCVD_Item))
                        'm_stock.Eliminar(_whereres)



                        ' '' eliminar Detalle
                        'Dim m_bdocveDetalle As New BVENT_DocsVentaDetalle() With {.VENT_DocsVentaDetalle = Item}
                        'Dim _wherereD As New Hashtable
                        '_wherereD.Add("DOCVE_Codigo", New ACWhere(x_docve_codigo))
                        '_wherereD.Add("DOCVD_Item", New ACWhere(Item.DOCVD_Item))

                        'm_bdocveDetalle.Eliminar(_wherereD)
                        ''_wherereD.Add("DOCVE_CodigoReferencia",New ACWhere(x_docverefer_codigo))

                        DAEnterprise.CommitTransaction()
                        ''ingresar ventasdetalle                                    
                        'm_bdocveDetalle.VENT_DocsVentaDetalle.Instanciar(ACEInstancia.Nuevo)
                        'm_bdocveDetalle.VENT_DocsVentaDetalle.DOCVE_Codigo = x_docve_codigo
                        'm_bdocveDetalle.VENT_DocsVentaDetalle.DOCVD_Item = Item.DOCVD_Item
                        'm_bdocveDetalle.VENT_DocsVentaDetalle.DOCVE_CodigoReferencia = Nothing
                        'm_bdocveDetalle.Guardar(_wherereD, x_usuario)
                        ''ingresar stcok
                        'm_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                        'm_bmanejarstocks.LOG_Stocks.DOCVE_Codigo = Item.DOCVE_Codigo
                        'm_bmanejarstocks.LOG_Stocks.DOCVD_Item = Item.DOCVD_Item
                        'm_bmanejarstocks.Ingreso_anulado(x_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, Item.ALMAC_Id, Item.DOCVD_Cantidad, _
                        '                       x_docve_fecha.Date, "MST14", x_usuario)

                        '        Next
                    End If
                Else

                    ' m_relacion = new BVENT_DocsRelacion()
                    'Dim _whererel As New Hashtable
                    '_whererel.Add("DOCVE_Codigo", New ACWhere(x_docve_codigo))
                    'm_relacion.Eliminar(_whererel)


                End If
                DAEnterprise.CommitTransaction()
                Return True







                ' Anula el doc de pago
                '' Cambiar el estado de la cotización
                'If Not IsNothing(x_docverefer_codigo) Then

                '    Dim _pedidos As New BVENT_Pedidos()
                '    _pedidos.Cargar(x_docverefer_codigo)
                '    '' Actualizar Estado de la Cotización
                '    Dim _bvent_pedidos As New BVENT_Pedidos()
                '    _bvent_pedidos.VENT_Pedidos = New EVENT_Pedidos
                '    _bvent_pedidos.VENT_Pedidos.PEDID_Estado = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Ingresado)
                '    _bvent_pedidos.VENT_Pedidos.PEDID_Codigo = x_docverefer_codigo
                '    _bvent_pedidos.VENT_Pedidos.PEDID_DocumentoPercepcion = _pedidos.VENT_Pedidos.PEDID_DocumentoPercepcion
                '    _bvent_pedidos.VENT_Pedidos.PEDID_ParaFacturar = True
                '    _bvent_pedidos.VENT_Pedidos.Instanciar(ACEInstancia.Modificado)

                '    ' '' Devolver el Stock Cargado si es una Cotización
                '    Dim m_tipoDocumento As EVENT_Pedidos.TipoPedido
                '    m_tipoDocumento = EVENT_Pedidos.TipoCotizacionCodigo(x_docverefer_codigo)
                '    'Dim m_tipoDocumento As  EVENT_Pedidos.TipoCotizacionCodigo(x_docverefer_codigo)

                '    Select Case m_tipoDocumento
                '        Case EVENT_Pedidos.TipoPedido.CT
                '            '' Cargar el Detalle
                '            If Cargar(x_docve_codigo, True) Then
                '                '' Anular Egreso de cada detalle
                '                For Each Item As EVENT_DocsVentaDetalle In m_vent_docsventa.ListVENT_DocsVentaDetalle
                '                    Dim m_bmanejarstocks As New BManejarStock()
                '                    m_bmanejarstocks.AnulacionEgresoFactura(m_periodo, Item.ARTIC_Codigo, Item.ALMAC_Id, _
                '                                                            m_vent_docsventa.DOCVE_Codigo, Item.DOCVD_Item, Item.DOCVD_Cantidad, x_usuario)
                '                Next
                '            End If

                '    End Select

                'Else
                '    DAEnterprise.CommitTransaction()
                '    Return True
                'End If

            End If
            DAEnterprise.RollBackTransaction()
            Return False
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

   ''' <summary>
   ''' Eliminar documentos de ventas, usado por el sistema de transportes
   ''' </summary>
   ''' <param name="x_docve_codigo">codigo de documento de venta</param>
   ''' <param name="x_pedid_codigo">codifo del pedido/cotizacion de venta </param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function EliminarDocumentoTransportes(ByVal x_docve_codigo As String, ByVal x_pedid_codigo As String, ByVal x_usuario As String) As Boolean
      Try
         '' Verificar Pagos
         Dim _pagos As New BTESO_Caja

         '' Completar proceso de Eliminación
         DAEnterprise.BeginTransaction()
         Dim _where As New Hashtable
         _where.Add("DOCVE_Codigo", New ACWhere(m_vent_docsventa.DOCVE_Codigo))

         Dim _bventasdetalle As New BVENT_DocsVentaDetalle
         _bventasdetalle.Eliminar(_where)
         Dim _bventas As New BVENT_DocsVenta
         If _bventas.Eliminar(_where) Then
            '' Verificar si hay Cotización - activar Cotización-Pedido
            If m_vent_docsventa.PEDID_Codigo.Length > 0 Then
               Dim _bvent_pedidos As New BVENT_Pedidos
               _bvent_pedidos.VENT_Pedidos = New EVENT_Pedidos
               _bvent_pedidos.VENT_Pedidos.Instanciar(ACEInstancia.Modificado)
               _bvent_pedidos.VENT_Pedidos.PEDID_Codigo = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Ingresado)
               Dim _pedidos As New BVENT_Pedidos()
               _pedidos.Cargar(x_pedid_codigo)
               '' Actualizar el Pedido
               If _bvent_pedidos.Guardar(x_usuario) Then
                  DAEnterprise.CommitTransaction()
                  Return True
               Else
                  DAEnterprise.RollBackTransaction()
                  Return False
               End If
            End If
            '' Culminar Proceso
            DAEnterprise.CommitTransaction()
            Return True
         Else
            Throw New Exception("No se puede completar la operación de eliminar registro")
         End If
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' eliminar documentos de venta de area de ventas
   ''' </summary>
   ''' <param name="x_docve_codigo">codigo del documento de venta</param>
   ''' <param name="x_pedid_codigo">codigo del pedido/cotizacion</param>
   ''' <param name="x_xdocpago">opcion para anular el pago, segun el tipo de pago, efectivo o deposito</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function EliminarDocumentoVenta(ByVal x_docve_codigo As String, ByVal x_pedid_codigo As String, x_xdocpago As Boolean, ByVal x_usuario As String) As Boolean
      Try
         '' Verificar Guias de Remision
         Dim _guias As New BDIST_GuiasRemision
         Dim _whereguia As New Hashtable
         _whereguia.Add("DOCVE_Codigo", New ACWhere(x_docve_codigo))
         _whereguia.Add("GUIAR_Estado", New ACWhere(Constantes.getEstado(Constantes.Estado.Anulado), ACWhere.TipoWhere.Diferente))
         If _guias.CargarTodos(_whereguia) Then
            Throw New Exception("El documento tienen Guias Generadas, primero debe anular las guias para proceder")
         End If
         '' Verificar Ordenes
         Dim _orden As New BDIST_Ordenes
         Dim _whereorden As New Hashtable
         _whereorden.Add("DOCVE_Codigo", New ACWhere(x_docve_codigo))
         _whereorden.Add("ORDEN_Estado", New ACWhere(Constantes.getEstado(Constantes.Estado.Anulado), ACWhere.TipoWhere.Diferente))
         If _orden.CargarTodos(_whereorden) Then
            Throw New Exception("El documento tiene ordenes, primero debe anular las ordenes para poder proceder")
         End If
         '' Completar proceso de Eliminación
         DAEnterprise.BeginTransaction()

         '' verificar que no tenga pagos activos
         Dim _caja As New BTESO_Caja
         Dim _wherecaja As New Hashtable
         _wherecaja.Add("DOCVE_Codigo", New ACWhere(x_docve_codigo))
         If _caja.CargarTodos(_wherecaja) Then

         End If
         
         '' Romper la Relación de Guias de Remision
         If Not RomperRelacionDocsVentas(x_docve_codigo, m_pvent_id, x_xdocpago) Then
            Throw New Exception("No se puede completar la operación de romper relaciones con los documentos enlazados")
         End If
         '' Devolver el Stock Cargado si es una Cotización
         Dim _where As New Hashtable
         _where.Add("DOCVE_Codigo", New ACWhere(m_vent_docsventa.DOCVE_Codigo))
         Dim _pedidos As New BVENT_Pedidos()
         _pedidos.Cargar(x_pedid_codigo)
         If _pedidos.VENT_Pedidos.PEDID_Tipo = EVENT_Pedidos.TipoCotizacion(EVENT_Pedidos.TipoPedido.CT) Then
            '' Eliminar el detalle del documento de venta
            Dim _bventasdetalle As New BVENT_DocsVentaDetalle
            '' Eliminar Egreso de cada detalle
            If Cargar(x_docve_codigo, True) Then
               For Each Item As EVENT_DocsVentaDetalle In m_vent_docsventa.ListVENT_DocsVentaDetalle
                  Dim m_bmanejarstocks As New BManejarStock()
                  m_bmanejarstocks.EliminarEgresoFactura(m_periodo, Item.ARTIC_Codigo, Item.ALMAC_Id, _
                                                         m_vent_docsventa.DOCVE_Codigo, Item.DOCVD_Item, Item.DOCVD_Cantidad, x_usuario)
               Next
               ' Eliminar el Detalle del documento de Venta
               _bventasdetalle.Eliminar(_where)
            End If
         Else
            Dim _bventasdetalle As New BVENT_DocsVentaDetalle
            If Cargar(x_docve_codigo, True) Then
               For Each Item As EVENT_DocsVentaDetalle In m_vent_docsventa.ListVENT_DocsVentaDetalle
                  Dim m_bmanejarstocks As New BManejarStock()
                  m_bmanejarstocks.EliminarEgresoFactura(m_periodo, Item.ARTIC_Codigo, Item.ALMAC_Id, _
                                                         m_vent_docsventa.DOCVE_Codigo, Item.DOCVD_Item, Item.DOCVD_Cantidad, x_usuario)
               Next
               ' Eliminar el Detalle del documento de Venta
               _bventasdetalle.Eliminar(_where)
            End If
         End If

         '' Eliminar cabecera del Documento de venta
         Dim _bventas As New BVENT_DocsVenta
         If _bventas.Eliminar(_where) Then
            '' Verificar si hay Cotización - activar Cotización-Pedido
            If m_vent_docsventa.PEDID_Codigo.Length > 0 Then
               '' Actualizar Estado de la Cotización
               Dim _bvent_pedidos As New BVENT_Pedidos()
               _bvent_pedidos.VENT_Pedidos = New EVENT_Pedidos
               _bvent_pedidos.VENT_Pedidos.PEDID_Estado = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Ingresado)
               _bvent_pedidos.VENT_Pedidos.PEDID_Codigo = x_pedid_codigo
               _bvent_pedidos.VENT_Pedidos.PEDID_DocumentoPercepcion = _pedidos.VENT_Pedidos.PEDID_DocumentoPercepcion
               _bvent_pedidos.VENT_Pedidos.PEDID_ParaFacturar = True
               _bvent_pedidos.VENT_Pedidos.Instanciar(ACEInstancia.Modificado)
               '' Actualizar el Pedido
               If _bvent_pedidos.Guardar(x_usuario) Then
                  DAEnterprise.CommitTransaction()
                  Return True
               Else
                  DAEnterprise.RollBackTransaction()
                  Return False
               End If
            End If
            '' Culminar Proceso
            DAEnterprise.CommitTransaction()
            Return True
         Else
            Throw New Exception("No se puede completar la operación de eliminar registro")
         End If
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
    End Function


   ''' <summary>
   ''' cargar documento de venta
   ''' </summary>
   ''' <param name="x_docve_codigo">codigo del documento de venta</param>
   ''' <param name="x_detalle">opcion para la carga del detalle del documento de venta</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Cargar(ByVal x_docve_codigo As String, ByVal x_detalle As Boolean) As Boolean
      Try
         Dim x_join As New List(Of ACJoin)
         x_join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoCliente")} _
                              , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Cliente")}))
         x_join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Entu", ACJoin.TipoJoin.Left _
                                       , New ACCampos() {New ACCampos("ENTID_Codigo", "DOCVE_FPUsrMod")} _
                                       , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_UsrAdmin")}))
         x_join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Fact", ACJoin.TipoJoin.Left _
                                       , New ACCampos() {New ACCampos("ENTID_Codigo", "DOCVE_UsrCrea")} _
                                       , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Facturador")}))
         x_join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Coti", ACJoin.TipoJoin.Left _
                                       , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoCotizador")} _
                                       , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Cotizador")}))
         Dim x_where As New Hashtable()
         x_where.Add("DOCVE_Codigo", New ACWhere(x_docve_codigo))
         If Cargar(x_join, x_where) Then
            If x_detalle Then
               Return CargarDetalle(x_docve_codigo)
            Else
               Return True
            End If
         Else
            Return False
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' cargar detalle del documento de venta
   ''' </summary>
   ''' <param name="x_docve_codigo">codigo del documento de venta</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarDetalle(ByVal x_docve_codigo As String) As Boolean
      Try
         Dim m_bvent_docsventadetalle As New BVENT_DocsVentaDetalle
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EArticulos.Esquema, EArticulos.Tabla, "Art", ACJoin.TipoJoin.Left _
                              , New ACCampos() {New ACCampos("ARTIC_Codigo", "ARTIC_Codigo")} _
                              , New ACCampos() {New ACCampos("ARTIC_Descripcion", "ARTIC_Descripcion")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TUni", "Art", ACJoin.TipoJoin.Left _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodUnidadMedida")} _
                              , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_UnidadMedida"), New ACCampos("TIPOS_Codigo", "TIPOS_CodUnidadMedida")}))
         _join.Add(New ACJoin(EAlmacenes.Esquema, EAlmacenes.Tabla, "Alm", ACJoin.TipoJoin.Left _
                              , New ACCampos() {New ACCampos("ALMAC_Id", "ALMAC_Id")} _
                              , New ACCampos() {New ACCampos("ALMAC_Descripcion", "ALMAC_Descripcion")}))
         Dim _where As New Hashtable()
         _where.Add("DOCVE_Codigo", New ACWhere(x_docve_codigo))
         If m_bvent_docsventadetalle.CargarTodos(_join, _where) Then
            If IsNothing(m_vent_docsventa) Then m_vent_docsventa = New EVENT_DocsVenta
            m_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)(m_bvent_docsventadetalle.ListVENT_DocsVentaDetalle)
            Return True
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

     Public Function CargarDetalleP(ByVal x_docve_codigo As String) As Boolean
      Try
         Dim m_bvent_docsventadetalle As New BVENT_DocsVentaDetalle
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EArticulos.Esquema, EArticulos.Tabla, "Art", ACJoin.TipoJoin.Left _
                              , New ACCampos() {New ACCampos("ARTIC_Codigo", "ARTIC_Codigo")} _
                              , New ACCampos() {New ACCampos("ARTIC_Descripcion", "ARTIC_Descripcion")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TUni", "Art", ACJoin.TipoJoin.Left _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodUnidadMedida")} _
                              , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_UnidadMedida"), New ACCampos("TIPOS_Codigo", "TIPOS_CodUnidadMedida")}))
         _join.Add(New ACJoin(EAlmacenes.Esquema, EAlmacenes.Tabla, "Alm", ACJoin.TipoJoin.Left _
                              , New ACCampos() {New ACCampos("ALMAC_Id", "ALMAC_Id")} _
                              , New ACCampos() {New ACCampos("ALMAC_Descripcion", "ALMAC_Descripcion")}))
         Dim _where As New Hashtable()
         _where.Add("DOCVE_Codigo", New ACWhere(x_docve_codigo))
         If m_bvent_docsventadetalle.CargarTodosP(_join, _where) Then
            If IsNothing(m_vent_docsventa) Then m_vent_docsventa = New EVENT_DocsVenta
            m_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)(m_bvent_docsventadetalle.ListVENT_DocsVentaDetalle)
            Return True
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function


   ''' <summary> 
   ''' Capa de Negocio: VENT_DOCVESS_UnDocumento
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function CargarUnDocumento(ByVal x_docve_codigo As String) As Boolean
      m_vent_docsventa = New EVENT_DocsVenta
      m_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
      Try
         Return d_vent_docsventa.VENT_DOCVESS_UnDocumento(m_vent_docsventa, x_docve_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' cargar documento de venta solo cabecera
   ''' </summary>
   ''' <param name="x_docve_codigo">codigo de venta</param>
   ''' <param name="x_detalle">opcion para cargar el detalle</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarSinArticulos(ByVal x_docve_codigo As String, ByVal x_detalle As Boolean) As Boolean
      Try
         Dim x_join As New List(Of ACJoin)
         x_join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoCliente")} _
                              , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Cliente") _
                              , New ACCampos("ENTID_NroDocumento", "ENTID_NroDocumento")}))
         x_join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Vend", ACJoin.TipoJoin.Left _
                                       , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoVendedor")} _
                                       , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Vendedor")}))
         x_join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TMon", ACJoin.TipoJoin.Inner _
                                       , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoMoneda")} _
                                       , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_TipoMoneda")}))
         x_join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Us", ACJoin.TipoJoin.Inner _
                                       , New ACCampos() {New ACCampos("ENTID_Codigo", "DOCVE_UsrCrea")} _
                                       , New ACCampos() {New ACCampos("ENTID_CodUsuario", "ENTID_CodUsuario")}))
         Dim x_where As New Hashtable()
         x_where.Add("DOCVE_Codigo", New ACWhere(x_docve_codigo))
         If Cargar(x_join, x_where) Then
            If x_detalle Then
               Dim m_bvent_docsventadetalle As New BVENT_DocsVentaDetalle
               Dim _join As New List(Of ACJoin)
               _join.Add(New ACJoin(EArticulos.Esquema, EArticulos.Tabla, "Art", ACJoin.TipoJoin.Left _
                                    , New ACCampos() {New ACCampos("ARTIC_Codigo", "ARTIC_Codigo")} _
                                    , New ACCampos() {New ACCampos("ARTIC_Descripcion", "ARTIC_Descripcion")}))
               _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TUni", "Art", ACJoin.TipoJoin.Left _
                                    , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodUnidadMedida")} _
                                    , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_UnidadMedida")}))
               _join.Add(New ACJoin(EAlmacenes.Esquema, EAlmacenes.Tabla, "Alm", ACJoin.TipoJoin.Left _
                                    , New ACCampos() {New ACCampos("ALMAC_Id", "ALMAC_Id")} _
                                    , New ACCampos() {New ACCampos("ALMAC_Descripcion", "ALMAC_Descripcion")}))
               Dim _where As New Hashtable()
               _where.Add("DOCVE_Codigo", New ACWhere(x_docve_codigo))
               If m_bvent_docsventadetalle.CargarTodos(_join, _where) Then
                  m_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)(m_bvent_docsventadetalle.ListVENT_DocsVentaDetalle)
                  Return True
               End If
            Else
               Return True
            End If
            Return True
         Else
            Return False
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' cargar documento de venta de un cliente
   ''' </summary>
   ''' <param name="x_entid_codigo">codigo de entidad</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarTodos(ByVal x_entid_codigo As String) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin("dbo", "Entidades", "Vend", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoVendedor")} _
                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Vendedor")}))
         _join.Add(New ACJoin("dbo", "Tipos", "TDoc", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                            , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoDocumento") _
                                              , New ACCampos("TIPOS_DescCorta", "TIPOS_TipoDocCorta")}))
         _join.Add(New ACJoin("dbo", "Tipos", "TMon", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoMoneda")} _
                            , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_TipoMoneda")}))
         _join.Add(New ACJoin("dbo", "Tipos", "TPag", ACJoin.TipoJoin.Left _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoPago")} _
                            , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_TipoPago")}))
         _join.Add(New ACJoin("dbo", "Tipos", "TCon", ACJoin.TipoJoin.Left _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodCondicionPago")} _
                            , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_CondicionPago")}))
         _join.Add(New ACJoin("dbo", "Entidades", "Us", ACJoin.TipoJoin.Left _
                            , New ACCampos() {New ACCampos("USUAR_Codigo", "DOCVE_UsrCrea")} _
                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "Usuario")}))
         Dim _where As New Hashtable()
         _where.Add("ENTID_CodigoCliente", New ACWhere(x_entid_codigo))
         _where.Add("DOCVE_Estado", New ACWhere(EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Anulado), ACWhere.TipoWhere.Diferente))

         Return CargarTodos(_join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Obtener vendedor
   ''' </summary>
   ''' <param name="x_entid_codigo">codigo de entidad</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getVendedor(ByVal x_entid_codigo As String) As Boolean
      Try
         Dim m_bentidad As New BEntidades
         If m_bentidad.Cargar(x_entid_codigo) Then
            m_evendedor = m_bentidad.Entidades
            Return True
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' obtener el reporte de ventas
   ''' </summary>
   ''' <param name="x_fecini">fecha condicion para el reporte</param>
   ''' <param name="x_fin">fecha final</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function ReporteVentas(ByVal x_fecini As DateTime, ByVal x_fin As DateTime) As Boolean
      Try
         m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
         Return d_vent_docsventa.VENT_ReporteVentas(m_listVENT_DocsVenta, x_fecini, x_fin)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: VENT_REPOSS_Ventas
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function REPOSS_Ventas(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Integer) As Boolean
      m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
      Try
         Return d_vent_docsventa.VENT_REPOSS_Ventas(m_listVENT_DocsVenta, x_fecini, x_fecfin, x_pvent_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' guardar documentos de pago
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <param name="x_teso_docspagos">clase documento de pago</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GuardarDocsPago(ByVal x_usuario As String, ByVal x_teso_docspagos As ETESO_DocsPagos) As Boolean
      Try
         DAEnterprise.BeginTransaction()
         Dim m_teso_docspagos As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
         m_teso_docspagos.TESO_DocsPagos = x_teso_docspagos
         If m_teso_docspagos.Guardar(x_usuario) Then
            Dim m_ventaspagos As New BVENT_DocsVentaPagos
            m_ventaspagos.VENT_DocsVentaPagos = New EVENT_DocsVentaPagos
            m_ventaspagos.VENT_DocsVentaPagos.Instanciar(ACEInstancia.Nuevo)
            m_ventaspagos.VENT_DocsVentaPagos.DOCVE_Codigo = m_vent_docsventa.DOCVE_Codigo
            m_ventaspagos.VENT_DocsVentaPagos.PVENT_Id = x_teso_docspagos.PVENT_Id
            m_ventaspagos.VENT_DocsVentaPagos.DPAGO_Id = x_teso_docspagos.DPAGO_Id
            m_ventaspagos.VENT_DocsVentaPagos.DVEPG_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
            If m_ventaspagos.Guardar(x_usuario) Then
               DAEnterprise.CommitTransaction()
               m_vent_docsventa.ListTESO_DocsPagos.Add(x_teso_docspagos)
               Return True
            Else
               Throw New Exception("El proceso de guardar documento no se puede completar")
            End If
         End If
         DAEnterprise.RollBackTransaction()
         Return False
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' obtener letras
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GetLetras() As Boolean
      Try
         Dim m_letras As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
         m_vent_docsventa.ListTESO_DocsPagos = New List(Of ETESO_DocsPagos)
         If m_letras.GetDocsPago(m_vent_docsventa.DOCVE_Codigo) Then
            m_vent_docsventa.ListTESO_DocsPagos = m_letras.ListTESO_DocsPagos
            Return True
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' buscar documento de ventas
   ''' </summary>
   ''' <param name="x_campo">campo de busquedqa</param>
   ''' <param name="x_valor">cadena de busqueda</param>
   ''' <param name="x_todos">cargar todos incluido lo anulados</param>
   ''' <param name="x_fecini">fecha inicial de busqueda</param>
   ''' <param name="x_fecfin">fecha final de busqueda</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Busqueda(ByVal x_campo As String, ByVal x_valor As String, ByVal x_todos As Boolean _
                          , ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As Boolean
      Dim _join As New List(Of ACJoin)
      Dim _where As New Hashtable()
      Try
         _join.Add(New ACJoin(EAlmacenes.Esquema, EAlmacenes.Tabla, ACJoin.TipoJoin.Inner, _
                              New ACCampos() {New ACCampos("ALMAC_Id", "ALMAC_Id")}, _
                              New ACCampos() {New ACCampos("ALMAC_Descripcion", "Almacen")}))
         _join.Add(New ACJoin(EPuntoVenta.Esquema, EPuntoVenta.Tabla, ACJoin.TipoJoin.Inner, _
                              New ACCampos() {New ACCampos("PVENT_Id", "PVENT_Id")}, _
                              New ACCampos() {New ACCampos("PVENT_Descripcion", "PuntoVenta")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Inner, _
                              New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")}, _
                              New ACCampos() {New ACCampos("TIPOS_Descripcion", "TipoDocumento")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "MOneda", ACJoin.TipoJoin.Inner, _
                              New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoMoneda")}, _
                              New ACCampos() {New ACCampos("TIPOS_DescCorta", "Moneda")}))

         _where.Add(x_campo, New ACWhere(x_valor, ACWhere.TipoWhere._Like))
         _where.Add("DOCVE_FechaDocumento", New ACWhere(x_fecini, x_fecfin, ACWhere.TipoWhere.Between))
         Return CargarTodos(_join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' busqueda de documentos de venta
   ''' </summary>
   ''' <param name="x_serie">serie del documento de venta</param>
   ''' <param name="x_numero">numero del documento de venta</param>
   ''' <param name="x_todos">cargar todos los registros incluyendo los anulados</param>
   ''' <param name="x_tipo">tipo de documento</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Busqueda(ByVal x_serie As String, ByVal x_numero As Integer, ByVal x_todos As Boolean, ByVal x_tipo As String) As Boolean
      Dim _join As New List(Of ACJoin)
      Dim _where As New Hashtable()
      Try
         _join.Add(New ACJoin(EAlmacenes.Esquema, EAlmacenes.Tabla, ACJoin.TipoJoin.Inner, _
                              New ACCampos() {New ACCampos("ALMAC_Id", "ALMAC_Id")}, _
                              New ACCampos() {New ACCampos("ALMAC_Descripcion", "Almacen")}))
         _join.Add(New ACJoin(EPuntoVenta.Esquema, EPuntoVenta.Tabla, ACJoin.TipoJoin.Inner, _
                              New ACCampos() {New ACCampos("PVENT_Id", "PVENT_Id")}, _
                              New ACCampos() {New ACCampos("PVENT_Descripcion", "PuntoVenta")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Inner, _
                              New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")}, _
                              New ACCampos() {New ACCampos("TIPOS_Descripcion", "TipoDocumento")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "MOneda", ACJoin.TipoJoin.Inner, _
                              New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoMoneda")}, _
                              New ACCampos() {New ACCampos("TIPOS_DescCorta", "Moneda")}))

         _where.Add("DOCVE_Numero", New ACWhere(x_numero, ACWhere.TipoWhere._Like))
         _where.Add("DOCVE_Serie", New ACWhere(x_serie))
         _where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_tipo))
         Return CargarTodos(_join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' dar permiso para que se pueda generar guia de remision y sea despachada
   ''' </summary>
   ''' <param name="x_docve_codigo">codigo del documento de venta</param>
   ''' <param name="x_value">valor del permiso Verdadero o falso</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function SetPermisoGenGuia(ByVal x_docve_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
      Try
         Return d_vent_docsventa.SetPermisoGenGuia(x_docve_codigo, x_value, x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
    End Function

    ''' <summary>
    ''' dar permiso para que se pueda anular un documento de venta
    ''' </summary>
    ''' <param name="x_docve_codigo">codigo del documento de venta</param>
    ''' <param name="x_value">valor del permiso Verdadero o falso</param>
    ''' <param name="x_usuario">codigo de usuario</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetPermisoAnularDocumentos(ByVal x_docve_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
        Try
            Return d_vent_docsventa.SetPermisoAnularDocumentos(x_docve_codigo, x_value, x_usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Dar permiso al documento para volver a imprimir
    ''' </summary>
    ''' <param name="x_codigo">codifo del documento de venta</param>
    ''' <param name="x_value">valor verdadero o falso para el permiso</param>
    ''' <param name="x_usuario">codigo de usuario</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetPermisoImpDocu(ByVal x_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
        Try


            Return d_vent_docsventa.SetPermisoImpDocu(x_codigo, x_value, x_usuario)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region



End Class

