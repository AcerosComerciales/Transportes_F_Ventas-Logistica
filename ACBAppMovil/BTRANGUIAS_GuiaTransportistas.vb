
Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte
Imports ACBVentas
Imports System.Configuration
Imports ACFramework
Imports DAConexion
Imports ACEVentas
Imports ACEAppMovil
Imports ACDAppMovil
Public Class BTRANGUIAS_GuiaTransportistas


    '#Region " Variables "

    '    Private m_ETRANGUIAS_GuiaTransportistas As ETRANGUIAS_GuiaTransportistas
    '    Private m_listVENT_Pedidos As List(Of ETRANGUIAS_GuiaTransportistas)
    '    Private m_dtVENT_Pedidos As DataTable

    '    Private m_dsVENT_Pedidos As DataSet
    '    Private d_vent_pedidos As DTRANGUIAS_GuiaTransportistas


    '#End Region " Variables "



    '#Region " Constructores "

    '#End Region

    '#Region " Propiedades "

    '#End Region

    '#Region " Funciones para obtencion de datos "

    '#End Region

    '#Region " Metodos "

    '    ' <summary> 
    '    ' Capa de Negocio: VENTSS_ModificarPedidosReporte
    '    ' </summary> 
    '    ' <param name="x_pedid_codigo">Parametro 1: </param> 
    '    ' <param name="x_pedid_condiciones">Parametro 2: </param> 
    '    ' <param name="x_pedid_condicionentrega">Parametro 3: </param> 
    '    ' <param name="x_pedid_nota">Parametro 4: </param> 
    '    ' <returns></returns> 
    '    ' <remarks></remarks> 
    '    Public Function VENTSS_ModificarPedidosReporte(ByVal x_pedid_codigo As String, ByVal x_pedid_condiciones As String, ByVal x_pedid_condicionentrega As String, ByVal x_pedid_nota As String) As Boolean
    '        Try
    '            Return d_vent_pedidos.VENTSS_ModificarPedidosReporte(x_pedid_codigo, x_pedid_condiciones, x_pedid_condicionentrega, x_pedid_nota)
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function

    '    ' <summary> 
    '    ' Capa de Negocio: VENT_PEDIDSS_BusCotizacion
    '    ' </summary>
    '    ' <param name="x_fecini">Parametro 1: </param> 
    '    ' <param name="x_fecfin">Parametro 2: </param> 
    '    ' <param name="x_zonas_codigo">Parametro 3: </param> 
    '    ' <param name="x_pvent_id">Parametro 4: </param> 
    '    ' <param name="x_sucur_id">Parametro 5: </param> 
    '    ' <param name="x_pedid_tipo">Parametro 6: </param> 
    '    ' <param name="x_opcion">Parametro 7: </param> 
    '    ' <param name="x_cadena">Parametro 8: </param> 
    '    ' <param name="x_todos">Parametro 9: </param> 
    '    ' <returns></returns> 
    '    ' <remarks></remarks> 
    '    Public Function BusCotizacion(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_pvent_id As Long, ByVal x_sucur_id As Short, ByVal x_pedid_tipo As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean, Optional ByVal x_rehusados As Boolean = False) As Boolean
    '        m_listVENT_Pedidos = New List(Of ETRANGUIAS_GuiaTransportistas)
    '        Try
    '            Return d_vent_pedidos.VENT_PEDIDSS_BusCotizacion(m_listVENT_Pedidos, x_fecini, x_fecfin, x_zonas_codigo, x_pvent_id, x_sucur_id, x_pedid_tipo, x_opcion, x_cadena, x_todos, x_rehusados)
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function

    '    ' <summary> 
    '    ' Capa de Negocio: VENT_PEDIDSS_ConsPedidoReposicion
    '    ' </summary>
    '    ' <param name="x_fecini">Parametro 1: </param> 
    '    ' <param name="x_fecfin">Parametro 2: </param> 
    '    ' <param name="x_zonas_codigo">Parametro 3: </param> 
    '    ' <param name="x_pvent_id">Parametro 4: </param> 
    '    ' <param name="x_sucur_id">Parametro 5: </param> 
    '    ' <param name="x_pedid_tipo">Parametro 6: </param> 
    '    ' <param name="x_opcion">Parametro 7: </param> 
    '    ' <param name="x_cadena">Parametro 8: </param> 
    '    ' <param name="x_todos">Parametro 9: </param> 
    '    ' <param name="x_pvent_idorigen">Parametro 10: </param> 
    '    ' <param name="x_rehusados">Parametro 11: </param> 
    '    ' <returns></returns> 
    '    ' <remarks></remarks> 
    '    Public Function VENT_PEDIDSS_ConsPedidoReposicion(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_pvent_id As Long, ByVal x_sucur_id As Short, ByVal x_pedid_tipo As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean, ByVal x_pvent_idorigen As Long, ByVal x_rehusados As Boolean) As Boolean
    '        m_listVENT_Pedidos = New List(Of ETRANGUIAS_GuiaTransportistas)
    '        Try
    '            Return d_vent_pedidos.VENT_PEDIDSS_ConsPedidoReposicion(m_listVENT_Pedidos, x_fecini, x_fecfin, x_zonas_codigo, x_pvent_id, x_sucur_id, x_pedid_tipo, x_opcion, x_cadena, x_todos, x_pvent_idorigen, x_rehusados)
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function

    '    ' <summary> 
    '    ' Capa de Negocio: VENT_PEDIDSS_BusPedidoReposicion
    '    ' </summary>
    '    ' <param name="x_fecini">Parametro 1: </param> 
    '    ' <param name="x_fecfin">Parametro 2: </param> 
    '    ' <param name="x_zonas_codigo">Parametro 3: </param> 
    '    ' <param name="x_pvent_id">Parametro 4: </param> 
    '    ' <param name="x_pvent_iddestino">Parametro 5: </param> 
    '    ' <param name="x_sucur_id">Parametro 6: </param> 
    '    ' <param name="x_pedid_tipo">Parametro 7: </param> 
    '    ' <param name="x_opcion">Parametro 8: </param> 
    '    ' <param name="x_cadena">Parametro 9: </param> 
    '    ' <param name="x_todos">Parametro 10: </param> 
    '    ' <returns></returns> 
    '    ' <remarks></remarks> 
    '    Public Function BusPedidoReposicion(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_pvent_id As Long, ByVal x_pvent_iddestino As Long, ByVal x_sucur_id As Short, ByVal x_pedid_tipo As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
    '        m_listVENT_Pedidos = New List(Of ETRANGUIAS_GuiaTransportistas)
    '        Try
    '            If x_pvent_iddestino = 0 Then
    '                Return d_vent_pedidos.VENT_PEDIDSS_ConsPedidoReposicion(m_listVENT_Pedidos, x_fecini, x_fecfin, x_zonas_codigo, x_pvent_id, x_sucur_id, x_pedid_tipo, x_opcion, x_cadena, x_todos, x_pvent_id, False)
    '            Else
    '                Return d_vent_pedidos.VENT_PEDIDSS_BusPedidoReposicion(m_listVENT_Pedidos, x_fecini, x_fecfin, x_zonas_codigo, x_pvent_id, x_pvent_iddestino, x_sucur_id, x_pedid_tipo, x_opcion, x_cadena, x_todos)
    '            End If
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function


    '    ' <summary> 
    '    ' Capa de Negocio: VENT_PEDIDSS_BusPedidoReposicionXnumero
    '    ' </summary>
    '    ' <param name="x_fecini">Parametro 1: </param> 
    '    ' <param name="x_fecfin">Parametro 2: </param> 
    '    ' <param name="x_zonas_codigo">Parametro 3: </param> 
    '    ' <param name="x_pvent_id">Parametro 4: </param> 
    '    ' <param name="x_pvent_iddestino">Parametro 5: </param> 
    '    ' <param name="x_sucur_id">Parametro 6: </param> 
    '    ' <param name="x_pedid_tipo">Parametro 7: </param> 
    '    ' <param name="x_opcion">Parametro 8: </param> 
    '    ' <param name="x_cadena">Parametro 9: </param> 
    '    ' <param name="x_todos">Parametro 10: </param> 
    '    ' <returns></returns> 
    '    ' <remarks></remarks>  

    '    Public Function BusPedidoReposicionXnumero(ByVal x_peventid As Short, ByVal x_numero As Long, ByVal x_serie As Long, ByVal x_tipo As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean,
    '                                             ByVal x_linea As String) As Boolean
    '        m_listVENT_Pedidos = New List(Of ETRANGUIAS_GuiaTransportistas)
    '        Try

    '            Return d_vent_pedidos.VENT_PEDIDSS_ConsPedidoReposicionXnumeroYlinea(m_listVENT_Pedidos, x_numero, x_serie, x_peventid, x_tipo, x_opcion, x_cadena, x_todos, x_linea)

    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function



    '    ' <summary> 
    '    ' Capa de Negocio: BusPedidoReposicionXnumeroYlinea
    '    ' </summary>
    '    ' <param name="x_fecini">Parametro 1: </param> 
    '    ' <param name="x_fecfin">Parametro 2: </param> 
    '    ' <param name="x_zonas_codigo">Parametro 3: </param> 
    '    ' <param name="x_pvent_id">Parametro 4: </param> 
    '    ' <param name="x_pvent_iddestino">Parametro 5: </param> 
    '    ' <param name="x_sucur_id">Parametro 6: </param> 
    '    ' <param name="x_pedid_tipo">Parametro 7: </param> 
    '    ' <param name="x_opcion">Parametro 8: </param> 
    '    ' <param name="x_cadena">Parametro 9: </param> 
    '    ' <param name="x_todos">Parametro 10: </param> 
    '    ' <returns></returns> 
    '    ' <remarks></remarks> 
    '    ' ' acCFecha.ACDtpFecha_De.Value.Date, acCFecha.ACDtpFecha_A.Value.Date,GApp.Zona,ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Factura),GApp.PuntoVenta,GApp.Sucursal getCampoC(), txtCBusqueda.Text, chkCTodos.Checked,linea_metros
    '    Public Function BusPedidoReposicionXlinea(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_pedid_tipo As String, ByVal x_peventid As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean,
    '                                                    ByVal x_linea As String) As Boolean
    '        m_listVENT_Pedidos = New List(Of ETRANGUIAS_GuiaTransportistas)
    '        Try

    '            Return d_vent_pedidos.VENT_PEDIDSS_ConsPedidoReposicionXlinea(m_listVENT_Pedidos, x_fecini, x_fecfin, x_zonas_codigo, x_pedid_tipo, x_peventid, x_opcion, x_cadena, x_todos, x_linea)

    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function


    '    ' <summary> 
    '    ' Capa de Negocio: VENT_PEDIDSS_BusPedidoReposicion
    '    ' </summary>
    '    ' <param name="x_fecini">Parametro 1: </param> 
    '    ' <param name="x_fecfin">Parametro 2: </param> 
    '    ' <param name="x_zonas_codigo">Parametro 3: </param> 
    '    ' <param name="x_pvent_id">Parametro 4: </param> 
    '    ' <param name="x_pvent_iddestino">Parametro 5: </param> 
    '    ' <param name="x_sucur_id">Parametro 6: </param> 
    '    ' <param name="x_pedid_tipo">Parametro 7: </param> 
    '    ' <param name="x_opcion">Parametro 8: </param> 
    '    ' <param name="x_cadena">Parametro 9: </param> 
    '    ' <param name="x_todos">Parametro 10: </param> 
    '    ' <returns></returns> 
    '    ' <remarks></remarks> 
    '    Public Function BusPedidoSeparacion(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_pvent_id As Long, ByVal x_pvent_iddestino As Long, ByVal x_sucur_id As Short, ByVal x_pedid_tipo As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
    '        m_listVENT_Pedidos = New List(Of ETRANGUIAS_GuiaTransportistas)
    '        Try
    '            If x_pvent_iddestino = 0 Then
    '                Return d_vent_pedidos.VENT_PEDIDSS_BusCotizacion(m_listVENT_Pedidos, x_fecini, x_fecfin, x_zonas_codigo, x_pvent_id, x_sucur_id, x_pedid_tipo, x_opcion, x_cadena, x_todos)
    '            Else

    '            End If
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function



    '    Public Function BusOrdenCorte(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_pvent_id As Long, ByVal x_sucur_id As Short, ByVal x_pedid_tipo As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean, ByVal x_artic_codigo As String) As Boolean
    '        m_listVENT_Pedidos = New List(Of ETRANGUIAS_GuiaTransportistas)
    '        Try
    '            Return d_vent_pedidos.VENT_PEDIDSS_BusOrdenCorte(m_listVENT_Pedidos, x_fecini, x_fecfin, x_zonas_codigo, x_pvent_id, x_sucur_id, x_pedid_tipo, x_opcion, x_cadena, x_artic_codigo, x_todos)
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function


    '    Public Function ActualizarOrdenCorte(ByVal x_codigo_orden As String, ByVal x_estado As String) As Boolean
    '        Try
    '            Return d_vent_pedidos.VENT_PEDIDSS_ActualizarOrden(x_codigo_orden, x_estado)
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function

    '    ' <summary> 
    '    ' Capa de Negocio: VENT_PEDIDSS_GuiasParaReposicion
    '    ' </summary>
    '    ' <param name="x_fecini">Parametro 1: </param> 
    '    ' <param name="x_fecfin">Parametro 2: </param> 
    '    ' <param name="x_zonas_codigo">Parametro 3: </param> 
    '    ' <param name="x_pvent_id">Parametro 4: </param> 
    '    ' <param name="x_sucur_id">Parametro 5: </param> 
    '    ' <param name="x_pedid_tipo">Parametro 6: </param> 
    '    ' <param name="x_opcion">Parametro 7: </param> 
    '    ' <param name="x_cadena">Parametro 8: </param> 
    '    ' <param name="x_todos">Parametro 9: </param> 
    '    ' <returns></returns> 
    '    ' <remarks></remarks> 
    '    Public Function BusPedidoReposicionParaGuia(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_pvent_id As Long, ByVal x_sucur_id As Short, ByVal x_pedid_tipo As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
    '        m_listVENT_Pedidos = New List(Of ETRANGUIAS_GuiaTransportistas)
    '        Try
    '            Return d_vent_pedidos.VENT_PEDIDSS_BusPedidoReposicionParaGuia(m_listVENT_Pedidos, x_fecini, x_fecfin, x_zonas_codigo, x_pvent_id, x_sucur_id, x_pedid_tipo, x_opcion, x_cadena, x_todos)
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function

    '    ' <summary>
    '    ' Busqueda de pedidos para la facturación
    '    ' </summary>
    '    ' <param name="x_opcion">Opcion de busqueda para filtrar a los que tienen la propiedad de facturar</param>
    '    ' <param name="x_fecini">Fecha del Pedido por la cual se realizara la busqueda</param>
    '    ' <returns></returns>
    '    ' <remarks></remarks>
    '    Public Function Busqueda(ByVal x_opcion As Boolean, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime, ByVal x_zonas_codigo As String _
    '                          , ByVal x_sucur_id As Short, ByVal x_pvent_id As Long) As Boolean
    '        m_listVENT_Pedidos = New List(Of ETRANGUIAS_GuiaTransportistas)
    '        Try
    '            Return d_vent_pedidos.VENT_PEDIDSS_Busqueda(m_listVENT_Pedidos, x_fecini, x_fecfin, x_opcion, x_zonas_codigo, x_sucur_id, x_pvent_id)
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function

    '    ' <summary>
    '    ' Busqueda General de Pedidos / Cotizaciones
    '    ' </summary>
    '    ' <param name="x_xcliente">opcion para busqueda de cliente</param>
    '    ' <param name="x_fecha">opcion para fecha</param>
    '    ' <param name="x_fecini">fecha inicial de busqueda</param>
    '    ' <param name="x_fecfin">fecha final de busqueda</param>
    '    ' <param name="x_tconsulta">tipo de consulta</param>
    '    ' <param name="x_cadena">cadena de busqueda</param>
    '    ' <param name="x_opcion">opcion de busqueda para la cadena</param>
    '    ' <param name="x_zonas_codigo">codigo de zona</param>
    '    ' <param name="x_sucur_id">codigo de sucursal</param>
    '    ' <param name="x_pvent_id">codigo de punto de venta</param>
    '    ' <returns></returns>
    '    ' <remarks></remarks>
    '    Public Function Busqueda(ByVal x_xcliente As Boolean, ByVal x_fecha As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tconsulta As Short,
    '                            ByVal x_cadena As String, ByVal x_opcion As Boolean, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short,
    '                            ByVal x_pvent_id As Long) As Boolean
    '        m_listVENT_Pedidos = New List(Of ETRANGUIAS_GuiaTransportistas)
    '        Try
    '            If x_xcliente Then
    '                If x_fecha Then
    '                    Return d_vent_pedidos.VENT_PEDIDSS_BusCliente(m_listVENT_Pedidos, x_fecini, x_fecfin, x_tconsulta, x_cadena, x_opcion, x_zonas_codigo, x_sucur_id, x_pvent_id)
    '                Else
    '                    Return d_vent_pedidos.VENT_PEDIDSS_BusClienteSF(m_listVENT_Pedidos, x_tconsulta, x_cadena, x_opcion, x_zonas_codigo, x_sucur_id, x_pvent_id)
    '                End If
    '            Else
    '                Return d_vent_pedidos.VENT_PEDIDSS_BusCodigo(m_listVENT_Pedidos, x_cadena, x_opcion, x_zonas_codigo, x_sucur_id, x_pvent_id)
    '            End If
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function

    '    ' <summary> 
    '    ' Capa de Negocio: VENT_PEDIDSS_BusCliente
    '    ' </summary>
    '    ' <param name="x_fecini">Parametro 1: </param> 
    '    ' <param name="x_fecfin">Parametro 2: </param> 
    '    ' <param name="x_tconsulta">Parametro 3: </param> 
    '    ' <param name="x_cadena">Parametro 4: </param> 
    '    ' <param name="x_opcion">Parametro 5: </param> 
    '    ' <param name="x_zonas_codigo">Parametro 6: </param> 
    '    ' <param name="x_sucur_id">Parametro 7: </param> 
    '    ' <param name="x_pvent_id">Parametro 8: </param> 
    '    ' <returns></returns> 
    '    ' <remarks></remarks> 
    '    Public Function BusCliente(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tconsulta As Short, ByVal x_cadena As String, ByVal x_opcion As Boolean, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_pvent_id As Long) As Boolean
    '        m_listVENT_Pedidos = New List(Of ETRANGUIAS_GuiaTransportistas)
    '        Try
    '            Return d_vent_pedidos.VENT_PEDIDSS_BusCliente(m_listVENT_Pedidos, x_fecini, x_fecfin, x_tconsulta, x_cadena, x_opcion, x_zonas_codigo, x_sucur_id, x_pvent_id)
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function

    '    ' <summary> 
    '    ' Capa de Negocio: VENT_PEDIDSS_BusClienteSF
    '    ' </summary>
    '    ' <param name="x_tconsulta">Parametro 1: </param> 
    '    ' <param name="x_cadena">Parametro 2: </param> 
    '    ' <param name="x_opcion">Parametro 3: </param> 
    '    ' <param name="x_zonas_codigo">Parametro 4: </param> 
    '    ' <param name="x_sucur_id">Parametro 5: </param> 
    '    ' <param name="x_pvent_id">Parametro 6: </param> 
    '    ' <returns></returns> 
    '    ' <remarks></remarks> 
    '    Public Function BusClienteSF(ByVal x_tconsulta As Short, ByVal x_cadena As String, ByVal x_opcion As Boolean, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_pvent_id As Long) As Boolean
    '        m_listVENT_Pedidos = New List(Of ETRANGUIAS_GuiaTransportistas)
    '        Try
    '            Return d_vent_pedidos.VENT_PEDIDSS_BusClienteSF(m_listVENT_Pedidos, x_tconsulta, x_cadena, x_opcion, x_zonas_codigo, x_sucur_id, x_pvent_id)
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function

    '    ' <summary> 
    '    ' Capa de Negocio: VENT_PEDIDSS_BusCodigo
    '    ' </summary>
    '    ' <param name="x_codigo">Parametro 1: </param> 
    '    ' <param name="x_opcion">Parametro 2: </param> 
    '    ' <param name="x_zonas_codigo">Parametro 3: </param> 
    '    ' <param name="x_sucur_id">Parametro 4: </param> 
    '    ' <param name="x_pvent_id">Parametro 5: </param> 
    '    ' <returns></returns> 
    '    ' <remarks></remarks> 
    '    Public Function VENT_PEDIDSS_BusCodigo(ByVal x_codigo As String, ByVal x_opcion As Boolean, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_pvent_id As Long) As Boolean
    '        m_listVENT_Pedidos = New List(Of ETRANGUIAS_GuiaTransportistas)
    '        Try
    '            Return d_vent_pedidos.VENT_PEDIDSS_BusCodigo(m_listVENT_Pedidos, x_codigo, x_opcion, x_zonas_codigo, x_sucur_id, x_pvent_id)
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function

    '    ' <summary>
    '    ' Cargar pedido / cotización
    '    ' </summary>
    '    ' <param name="x_pedid_codigo">codigo del pedido</param>
    '    ' <param name="x_detalle">opcion para la carga del detalle</param>
    '    ' <returns></returns>
    '    ' <remarks></remarks>
    '    Public Function Cargar(ByVal x_pedid_codigo As String, ByVal x_detalle As Boolean) As Boolean
    '        Try
    '            Dim _join As New List(Of ACJoin)
    '            _join.Add(New ACJoin("dbo", "Entidades", "Ent", ACJoin.TipoJoin.Inner _
    '                            , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoCliente")} _
    '                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Cliente") _
    '                                            , New ACCampos("ENTID_Codigo", "ENTID_Codigo") _
    '                                            , New ACCampos("ENTID_NroDocumento", "ENTID_NroDocumento")}))
    '            Dim _where As New Hashtable()
    '            _where.Add("PEDID_Codigo", New ACWhere(x_pedid_codigo, ACWhere.TipoWhere.Igual))
    '            If Cargar(_join, _where) Then
    '                If x_detalle Then
    '                    Dim m_bvent_pedidosdetalle As New BVENT_PedidosDetalle
    '                    Dim _joinDet As New List(Of ACJoin)
    '                    _joinDet.Add(New ACJoin("dbo", "Articulos", "Art", ACJoin.TipoJoin.Inner _
    '                                  , New ACCampos() {New ACCampos("ARTIC_Codigo", "ARTIC_Codigo")} _
    '                                  , New ACCampos() {New ACCampos("ARTIC_Descripcion", "ARTIC_Descripcion") _
    '                                                    , New ACCampos("ARTIC_Id", "ARTIC_Id"), New ACCampos("TIPOS_CodUnidadMedida", "TIPOS_CodUnidadMedida")}))
    '                    Dim _whereDet As New Hashtable()
    '                    _whereDet.Add("PEDID_Codigo", New ACWhere(x_pedid_codigo, ACWhere.TipoWhere.Igual))
    '                    m_bvent_pedidosdetalle.CargarTodos(_joinDet, _whereDet)
    '                    m_ETRANGUIAS_GuiaTransportistas.ListDetPedidos = New List(Of ETRANGUIAS_GuiaTransportistasDetalle)(m_bvent_pedidosdetalle.ListVENT_PedidosDetalle)
    '                End If
    '                Return True
    '            Else
    '                Return False
    '            End If
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function

    '    ' <summary> 
    '    ' Capa de Negocio: VENT_PEDIDSS_ObtenerPedidoReposicion
    '    ' </summary>
    '    ' <param name="x_fecfin">Parametro 1: </param> 
    '    ' <param name="x_zonas_codigo">Parametro 2: </param> 
    '    ' <param name="x_pvent_id">Parametro 3: </param> 
    '    ' <param name="x_sucur_id">Parametro 4: </param> 
    '    ' <param name="x_pedid_tipo">Parametro 5: </param> 
    '    ' <param name="x_opcion">Parametro 6: </param> 
    '    ' <param name="x_cadena">Parametro 7: </param> 
    '    ' <returns></returns> 
    '    ' <remarks></remarks> 
    '    Public Function VENT_PEDIDSS_ObtenerPedidoReposicion(ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_pvent_id As Long, ByVal x_sucur_id As Short, ByVal x_pedid_tipo As String, ByVal x_opcion As Short, ByVal x_cadena As String) As Boolean
    '        m_listVENT_Pedidos = New List(Of ETRANGUIAS_GuiaTransportistas)
    '        Try
    '            Return d_vent_pedidos.VENT_PEDIDSS_ObtenerPedidoReposicion(m_listVENT_Pedidos, x_fecfin, x_zonas_codigo, x_pvent_id, x_sucur_id, x_pedid_tipo, x_opcion, x_cadena)
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function

    '    ' <summary>
    '    ' Actualizar la fecha de entrega del pedido de reposicion, para el control de la mercaderia no entregada
    '    ' </summary>
    '    ' <param name="x_usuario">codigo de usuario</param>
    '    ' <returns></returns>
    '    ' <remarks></remarks>
    '    Public Function ActualizarFechaEntrega(ByVal x_usuario As String)
    '        Try
    '            For Each item As ETRANGUIAS_GuiaTransportistas In m_listVENT_Pedidos
    '                If item.Seleccion Then
    '                    d_vent_pedidos.ActualizarFechaEntrega(item.PEDID_Codigo, item.PEDID_FechaEntrega, x_usuario)
    '                End If
    '            Next
    '            Return True
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function

    '    ' <summary>
    '    ' asignar permisos al pedido para anular
    '    ' </summary>
    '    ' <param name="x_orden_codigo"></param>
    '    ' <param name="x_value"></param>
    '    ' <param name="x_usuario"></param>
    '    ' <returns></returns>
    '    ' <remarks></remarks>
    '    Public Function SetPermisoAnularPedido(ByVal x_pedid_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
    '        Try
    '            Return d_vent_pedidos.SetPermisoAnularPedido(x_pedid_codigo, x_value, x_usuario)
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function
End Class
