Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BDIST_Ordenes

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "
	
#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
   ''' <summary> 
   ''' Capa de Negocio: LOG_DISTSS_BuscarOrdenesIngreso
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_pvent_id">Parametro 3: </param> 
   ''' <param name="x_tipos_codtipoorden">Parametro 4: </param> 
   ''' <param name="x_opcion">Parametro 5: </param> 
   ''' <param name="x_cadena">Parametro 6: </param> 
   ''' <param name="x_todos">Parametro 7: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function BuscarOrdenesIngreso(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_Ordenes = New List(Of EDIST_Ordenes)
      Try
         Return d_dist_ordenes.LOG_DISTSS_BuscarOrdenesIngreso(m_listDIST_Ordenes, x_fecini, x_fecfin, x_pvent_id, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    
     ''' <summary> 
   ''' Capa de Negocio: BuscarOrdenesSalidaXlinea
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_pvent_id">Parametro 3: </param> 
   ''' <param name="x_tipos_codtipoorden">Parametro 4: </param> 
   ''' <param name="x_opcion">Parametro 5: </param> 
   ''' <param name="x_cadena">Parametro 6: </param> 
   ''' <param name="x_todos">Parametro 7: </param> 
   ''' <param name="x_linea">Parametro 7: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function BuscarOrdenesSalidaXlinea(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean,
                                             ByVal X_linea As String) As Boolean
      m_listDIST_Ordenes = New List(Of EDIST_Ordenes)
      Try
         Return d_dist_ordenes.LOG_DISTSS_BuscarOrdenessalidaXlinea(m_listDIST_Ordenes, x_fecini, x_fecfin, x_pvent_id, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos,X_linea)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

       ''' <summary> 
   ''' Capa de Negocio: BuscarOrdenesSalidaXlinea
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_pvent_id">Parametro 3: </param> 
   ''' <param name="x_tipos_codtipoorden">Parametro 4: </param> 
   ''' <param name="x_opcion">Parametro 5: </param> 
   ''' <param name="x_cadena">Parametro 6: </param> 
   ''' <param name="x_todos">Parametro 7: </param> 
   ''' <param name="x_linea">Parametro 7: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
    Public Function BuscarOrdenesSalidaXnumeroYlinea(ByVal x_serie As String, ByVal x_numero As Long, ByVal x_pvent_id As Short, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean,
                                             ByVal X_linea As String) As Boolean
        m_listDIST_Ordenes = New List(Of EDIST_Ordenes)
        Try
            Return d_dist_ordenes.LOG_DISTSS_BuscarOrdenessalidaXnumeroYlinea(m_listDIST_Ordenes, x_serie, x_numero, x_pvent_id, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos, X_linea)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
   ''' <summary> 
   ''' Capa de Negocio: LOG_DISTSS_BuscarOrdenesIngresoPtoVenta
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_pvent_iddestino">Parametro 3: </param> 
   ''' <param name="x_pvent_idorigen">Parametro 4: </param> 
   ''' <param name="x_tipos_codtipoorden">Parametro 5: </param> 
   ''' <param name="x_opcion">Parametro 6: </param> 
   ''' <param name="x_cadena">Parametro 7: </param> 
   ''' <param name="x_todos">Parametro 8: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function BuscarOrdenesIngresoPtoVenta(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_iddestino As Long, ByVal x_pvent_idorigen As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_Ordenes = New List(Of EDIST_Ordenes)
      Try
         Return d_dist_ordenes.LOG_DISTSS_BuscarOrdenesIngresoPtoVenta(m_listDIST_Ordenes, x_fecini, x_fecfin, x_pvent_iddestino, x_pvent_idorigen, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: LOG_DISTSS_BuscarOrdenesIngresoLocal
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_pvent_iddestino">Parametro 3: </param> 
   ''' <param name="x_tipos_codtipoorden">Parametro 4: </param> 
   ''' <param name="x_opcion">Parametro 5: </param> 
   ''' <param name="x_cadena">Parametro 6: </param> 
   ''' <param name="x_todos">Parametro 7: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function BuscarOrdenesIngresoLocal(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_iddestino As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_Ordenes = New List(Of EDIST_Ordenes)
      Try
         Return d_dist_ordenes.LOG_DISTSS_BuscarOrdenesIngresoLocal(m_listDIST_Ordenes, x_fecini, x_fecfin, x_pvent_iddestino, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function


   ''' <summary> 
   ''' Capa de Negocio: LOG_DISTSS_ObtenerOrden
   ''' </summary>
   ''' <param name="x_orden_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerOrden(ByVal x_orden_codigo As String, ByVal x_detalle As Boolean) As Boolean
      m_edist_ordenes = New EDIST_Ordenes
      Try
         Return d_dist_ordenes.LOG_DISTSS_ObtenerOrden(m_edist_ordenes, x_orden_codigo, x_detalle)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    ''' <summary>
    ''' verificar si orden tiene guia
    ''' </summary>
    ''' <param name="x_orden_codigo"></param>
    ''' <param name="x_detalle"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function verificarordenesguias(ByVal x_orden_codigo As String) As Boolean
      m_edist_ordenes = New EDIST_Ordenes
      Try
         Return d_dist_ordenes.LOG_DISTSS_VerificarOrdenGuias(m_edist_ordenes, x_orden_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    
    Public Function actualizarEstadoOrden(ByVal x_orden_codigo As String, ByVal estentrega As string) As Boolean
     Try
         Return d_dist_ordenes.LOG_DISTSS_actualizarEstadoEntrega(x_orden_codigo, estentrega)
      Catch ex As Exception
         Throw ex
      End Try
   End Function


   ''' <summary>
   ''' asignar permisos a la orden para generar su guia de remision de entrega
   ''' </summary>
   ''' <param name="x_docve_codigo"></param>
   ''' <param name="x_value"></param>
   ''' <param name="x_usuario"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function SetPermisoGenGuia(ByVal x_docve_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
      Try
         Return d_dist_ordenes.SetPermisoGenGuia(x_docve_codigo, x_value, x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
    End Function
    ''' <summary>
    ''' asignar permisos a la orden para imprimir
    ''' </summary>
    ''' <param name="x_orden_codigo"></param>
    ''' <param name="x_value"></param>
    ''' <param name="x_usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetPermisoImpOrden(ByVal x_orden_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
        Try
            Return d_dist_ordenes.SetPermisoImpOrden(x_orden_codigo, x_value, x_usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' asignar permisos a la orden para anular
    ''' </summary>
    ''' <param name="x_orden_codigo"></param>
    ''' <param name="x_value"></param>
    ''' <param name="x_usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetPermisoAnularOrden(ByVal x_orden_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
        Try
            Return d_dist_ordenes.SetPermisoAnularOrden(x_orden_codigo, x_value, x_usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   ''' <summary> 
   ''' Capa de Negocio: LOG_DIST_ObtenerPendientesOrdenes
   ''' </summary>
   ''' <param name="x_fecfin">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <param name="x_pvent_id">Parametro 3: </param> 
   ''' <param name="x_desbloqueo">Parametro 4: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DIST_ObtenerPendientesOrdenes(ByVal x_fecfin As Date, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_desbloqueo As Boolean) As Boolean
      m_listdist_ordenes = New List(Of EDIST_Ordenes)
      Try
         Return d_dist_ordenes.LOG_DIST_ObtenerPendientesOrdenes(m_listdist_ordenes, x_fecfin, x_almac_id, x_pvent_id, x_desbloqueo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Actualizar la fecha de entrega de la orden
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function ActualizarFechaEntrega(ByVal x_usuario As String)
      Try
         For Each item As EDIST_Ordenes In m_listDIST_Ordenes
            If item.Seleccion Then
               d_dist_ordenes.ActualizarFechaEntrega(item.ORDEN_Codigo, item.ORDEN_FechaEntrega, x_usuario)
            End If
         Next
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

End Class

