Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BDIST_GuiasRemision

#Region " Variables "
    Private m_dttable As DataTable
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "
    Public Property DTTabla() As DataTable
        Get
            Return m_dttable
        End Get
        Set(ByVal value As DataTable)
            m_dttable = value
        End Set
    End Property
#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
   ''' <summary> 
   ''' Capa de Negocio: LOG_DISTSS_ObtenerGuiaVenta
   ''' </summary>
   ''' <param name="x_guiar_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerGuiaVenta(ByVal x_guiar_codigo As String) As Boolean
      m_edist_guiasremision = New EDIST_GuiasRemision
      Try
         Return d_dist_guiasremision.LOG_DISTSS_ObtenerGuiaVenta(m_edist_guiasremision, x_guiar_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

      ''' <summary> 
   ''' Capa de Negocio: LOG_DISTSS_ObtenerGuiaVenta
   ''' </summary>
   ''' <param name="x_guiar_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   ''' 
     Public Function ObtenerGuiaTransformacion(ByVal x_guiar_codigo As String) As Boolean
      m_edist_guiasremision = New EDIST_GuiasRemision
      Try
         Return d_dist_guiasremision.LOG_DISTSS_ObtenerGuiaTransformacion(m_edist_guiasremision, x_guiar_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function


   ''' <summary> 
   ''' Capa de Negocio: LOG_DISTSS_ObtenerGuiaVenta
   ''' </summary>
   ''' <param name="x_guiar_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerGuiaTransf(ByVal x_guiar_codigo As String) As Boolean
      m_edist_guiasremision = New EDIST_GuiasRemision
      Try
         Return d_dist_guiasremision.LOG_DISTSS_ObtenerGuiaTransf(m_edist_guiasremision, x_guiar_codigo)
      Catch ex As Exception
         Throw ex
      End Try
    End Function
    ''' <summary> 
    ''' Capa de Negocio: LOG_DISTSS_ObtenerGuiaVenta
    ''' </summary>
    ''' <param name="x_guiar_codigo">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function ObtenerGuiaCompra(ByVal x_guiar_codigo As String) As Boolean
        m_edist_guiasremision = New EDIST_GuiasRemision
        Try
            Return d_dist_guiasremision.LOG_DISTSS_ObtenerGuiaCompra(m_edist_guiasremision, x_guiar_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   ''' <summary> 
   ''' Capa de Negocio: LOG_DISTSS_BuscarFacturasVenta
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_pvent_id">Parametro 3: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
   ''' <param name="x_opcion">Parametro 5: </param> 
   ''' <param name="x_cadena">Parametro 6: </param> 
   ''' <param name="x_todos">Parametro 7: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function BuscarGuiasRemision(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codmotivotraslado As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
      Try
         Return d_dist_guiasremision.LOG_DISTSS_BuscarGuiasRemision(m_listDIST_GuiasRemision, x_fecini, x_fecfin, x_pvent_id, x_tipos_codmotivotraslado, x_opcion, x_cadena, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    Public Function Obtener_Deta_Anulada(ByVal x_docve_codigo As String,ByVal x_documento As String) As Boolean
        Try
            m_dttable = New DataTable
            Return d_dist_guiasremision.Obtener_Deta_Anulada(m_dttable, x_docve_codigo,x_documento)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


   ''' <summary> 
   ''' Capa de Negocio: LOG_DISTSS_BuscarFacturasVentaXNumero
   ''' </summary>
   ''' <param name="x_numero">Parametro 1: </param> 
   ''' <param name="x_serie">Parametro 2: </param> 
   ''' <param name="x_pvent_id">Parametro 3: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
   ''' <param name="x_todos">Parametro 5: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function BuscarGuiasRemisionXNumero(ByVal x_numero As String, ByVal x_serie As String, ByVal x_pvent_id As Long, ByVal x_tipos_codmotivotraslado As String, ByVal x_tipos_codtipodocumento As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
      Try
         Return d_dist_guiasremision.LOG_DISTSS_BuscarGuiasRemisionXNumero(m_listDIST_GuiasRemision, x_numero, x_serie, x_pvent_id, x_tipos_codmotivotraslado, x_tipos_codtipodocumento, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: LOG_DISTSS_GetSaldoArticulo
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <param name="x_artic_codigo">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function GetSaldoArticulo(ByVal x_docve_codigo As String, ByVal x_artic_codigo As String, ByRef x_saldo As Decimal, ByVal x_orden As Boolean) As Boolean
      Try
         Return d_dist_guiasremision.LOG_DISTSS_GetSaldoArticulo(x_docve_codigo, x_artic_codigo, x_saldo, x_orden)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: LOG_GUIASS_ObtenerGuias
   ''' </summary>
   ''' <param name="x_almac_iddestino">Parametro 1: </param> 
   ''' <param name="x_fecini">Parametro 2: </param> 
   ''' <param name="x_fecfin">Parametro 3: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
   ''' <param name="x_opcionfecha">Parametro 5: </param> 
   ''' <param name="x_opcion">Parametro 6: </param> 
   ''' <param name="x_cadena">Parametro 7: </param> 
   ''' <param name="x_todos">Parametro 8: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerGuias(ByVal x_almac_iddestino As Short, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tipos_codmotivotraslado As String, ByVal x_opcionfecha As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
      Try
         Return d_dist_guiasremision.LOG_GUIASS_ObtenerGuias(m_listDIST_GuiasRemision, x_almac_iddestino, x_fecini, x_fecfin, x_tipos_codmotivotraslado, x_opcionfecha, x_opcion, x_cadena, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: LOG_GUIASS_ObtenerGuiasSalida
   ''' </summary>
   ''' <param name="x_almac_iddestino">Parametro 1: </param> 
   ''' <param name="x_fecini">Parametro 2: </param> 
   ''' <param name="x_fecfin">Parametro 3: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
   ''' <param name="x_opcionfecha">Parametro 5: </param> 
   ''' <param name="x_opcion">Parametro 6: </param> 
   ''' <param name="x_cadena">Parametro 7: </param> 
   ''' <param name="x_todos">Parametro 8: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerGuiasSalida(ByVal x_almac_iddestino As Short, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tipos_codmotivotraslado As String, ByVal x_opcionfecha As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
      Try
         Return d_dist_guiasremision.LOG_GUIASS_ObtenerGuiasSalida(m_listDIST_GuiasRemision, x_almac_iddestino, x_fecini, x_fecfin, x_tipos_codmotivotraslado, x_opcionfecha, x_opcion, x_cadena, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
    End Function
    ''' <summary> 
    ''' Capa de Negocio: LOG_GUIASS_ObtenerGuiasSalida
    ''' </summary>
    ''' <param name="x_almac_iddestino">Parametro 1: </param> 
    ''' <param name="x_fecini">Parametro 2: </param> 
    ''' <param name="x_fecfin">Parametro 3: </param> 
    ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
    ''' <param name="x_opcionfecha">Parametro 5: </param> 
    ''' <param name="x_opcion">Parametro 6: </param> 
    ''' <param name="x_cadena">Parametro 7: </param> 
    ''' <param name="x_todos">Parametro 8: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function ObtenerGuiasCompra(ByVal x_almac_iddestino As Short, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tipos_codmotivotraslado As String, ByVal x_opcionfecha As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
        m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
        Try
            Return d_dist_guiasremision.LOG_GUIASS_ObtenerGuiasCompra(m_listDIST_GuiasRemision, x_almac_iddestino, x_fecini, x_fecfin, x_tipos_codmotivotraslado, x_opcionfecha, x_opcion, x_cadena, x_todos)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   ''' <summary> 
   ''' Capa de Negocio: LOG_GUIASS_ObtenerGuiasIngresosXNumero
   ''' </summary>
   ''' <param name="x_almac_idorigen">Parametro 1: </param> 
   ''' <param name="x_numero">Parametro 2: </param> 
   ''' <param name="x_serie">Parametro 3: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
   ''' <param name="x_todos">Parametro 5: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerGuiasIngresosXNumero(ByVal x_almac_idorigen As Short, ByVal x_numero As String, ByVal x_serie As String, ByVal x_tipos_codmotivotraslado As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
      Try
         Return d_dist_guiasremision.LOG_GUIASS_ObtenerGuiasIngresosXNumero(m_listDIST_GuiasRemision, x_almac_idorigen, x_numero, x_serie, x_tipos_codmotivotraslado, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: LOG_GUIASS_ObtenerGuiasSalidaRemoto
   ''' </summary>
   ''' <param name="x_almac_idorigen">Parametro 1: </param> 
   ''' <param name="x_almac_iddestino">Parametro 2: </param> 
   ''' <param name="x_fecini">Parametro 3: </param> 
   ''' <param name="x_fecfin">Parametro 4: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 5: </param> 
   ''' <param name="x_opcionfecha">Parametro 6: </param> 
   ''' <param name="x_opcion">Parametro 7: </param> 
   ''' <param name="x_cadena">Parametro 8: </param> 
   ''' <param name="x_todos">Parametro 9: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerGuiasSalidaRemoto(ByVal x_almac_idorigen As Short, ByVal x_almac_iddestino As Short, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tipos_codmotivotraslado As String, ByVal x_opcionfecha As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
      Try
         Return d_dist_guiasremision.LOG_GUIASS_ObtenerGuiasSalidaRemoto(m_listDIST_GuiasRemision, x_almac_idorigen, x_almac_iddestino, x_fecini, x_fecfin, x_tipos_codmotivotraslado, x_opcionfecha, x_opcion, x_cadena, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: LOG_GUIASS_ObtenerGuiasSalidaXNumero
   ''' </summary>
   ''' <param name="x_almac_idorigen">Parametro 1: </param> 
   ''' <param name="x_numero">Parametro 2: </param> 
   ''' <param name="x_serie">Parametro 3: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
   ''' <param name="x_todos">Parametro 5: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerGuiasSalidaXNumero(ByVal x_almac_idorigen As Short, ByVal x_numero As String, ByVal x_serie As String, ByVal x_tipos_codmotivotraslado As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
      Try
         Return d_dist_guiasremision.LOG_GUIASS_ObtenerGuiasSalidaXNumero(m_listDIST_GuiasRemision, x_almac_idorigen, x_numero, x_serie, x_tipos_codmotivotraslado, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: LOG_GUIASS_ObtenerGuiasSalidaXNumero
    ''' </summary>
    ''' <param name="x_almac_idorigen">Parametro 1: </param> 
    ''' <param name="x_numero">Parametro 2: </param> 
    ''' <param name="x_serie">Parametro 3: </param> 
    ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
    ''' <param name="x_todos">Parametro 5: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function ObtenerGuiasCompraXNumero(ByVal x_almac_idorigen As Short, ByVal x_numero As String, ByVal x_serie As String, ByVal x_tipos_codmotivotraslado As String, ByVal x_todos As Boolean) As Boolean
        m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
        Try
            Return d_dist_guiasremision.LOG_GUIASS_ObtenerGuiasCompraXNumero(m_listDIST_GuiasRemision, x_almac_idorigen, x_numero, x_serie, x_tipos_codmotivotraslado, x_todos)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   ''' <summary> 
   ''' Capa de Negocio: LOG_GUIASS_ObtenerGuiasSalidaXNumeroRemoto
   ''' </summary>
   ''' <param name="x_almac_idorigen">Parametro 1: </param> 
   ''' <param name="x_almac_iddestino">Parametro 2: </param> 
   ''' <param name="x_numero">Parametro 3: </param> 
   ''' <param name="x_serie">Parametro 4: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 5: </param> 
   ''' <param name="x_todos">Parametro 6: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerGuiasSalidaXNumeroRemoto(ByVal x_almac_idorigen As Short, ByVal x_almac_iddestino As Short, ByVal x_numero As String, ByVal x_serie As String, ByVal x_tipos_codmotivotraslado As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
      Try
         Return d_dist_guiasremision.LOG_GUIASS_ObtenerGuiasSalidaXNumeroRemoto(m_listDIST_GuiasRemision, x_almac_idorigen, x_almac_iddestino, x_numero, x_serie, x_tipos_codmotivotraslado, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: LOG_GUIASS_ObtenerGuiasIngresos
   ''' </summary>
   ''' <param name="x_almac_iddestino">Parametro 1: </param> 
   ''' <param name="x_fecini">Parametro 2: </param> 
   ''' <param name="x_fecfin">Parametro 3: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
   ''' <param name="x_opcionfecha">Parametro 5: </param> 
   ''' <param name="x_opcion">Parametro 6: </param> 
   ''' <param name="x_cadena">Parametro 7: </param> 
   ''' <param name="x_todos">Parametro 8: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerGuiasIngresos(ByVal x_almac_iddestino As Short, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tipos_codmotivotraslado As String, ByVal x_opcionfecha As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
      Try
         Return d_dist_guiasremision.LOG_GUIASS_ObtenerGuiasIngresos(m_listDIST_GuiasRemision, x_almac_iddestino, x_fecini, x_fecfin, x_tipos_codmotivotraslado, x_opcionfecha, x_opcion, x_cadena, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: LOG_GUIASS_ObtenerGuiasReposicion
   ''' </summary>
   ''' <param name="x_almac_idorigen">Parametro 1: </param> 
   ''' <param name="x_fecini">Parametro 2: </param> 
   ''' <param name="x_fecfin">Parametro 3: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
   ''' <param name="x_opcionfecha">Parametro 5: </param> 
   ''' <param name="x_opcion">Parametro 6: </param> 
   ''' <param name="x_cadena">Parametro 7: </param> 
   ''' <param name="x_todos">Parametro 8: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerGuiasReposicion(ByVal x_almac_idorigen As Short, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tipos_codmotivotraslado As String, ByVal x_opcionfecha As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
      Try
         Return d_dist_guiasremision.LOG_GUIASS_ObtenerGuiasReposicion(m_listDIST_GuiasRemision, x_almac_idorigen, x_fecini, x_fecfin, x_tipos_codmotivotraslado, x_opcionfecha, x_opcion, x_cadena, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: LOG_GUIASS_ObtenerGuiasReposicionXNumero
   ''' </summary>
   ''' <param name="x_almac_idorigen">Parametro 1: </param> 
   ''' <param name="x_numero">Parametro 2: </param> 
   ''' <param name="x_serie">Parametro 3: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
   ''' <param name="x_todos">Parametro 5: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerGuiasReposicionXNumero(ByVal x_almac_idorigen As Short, ByVal x_numero As String, ByVal x_serie As String, ByVal x_tipos_codmotivotraslado As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
      Try
         Return d_dist_guiasremision.LOG_GUIASS_ObtenerGuiasReposicionXNumero(m_listDIST_GuiasRemision, x_almac_idorigen, x_numero, x_serie, x_tipos_codmotivotraslado, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#Region " Control de Despachos "
   ''' <summary> 
   ''' Procedimiento "GUIA_SalidasPendientes" por el Generador 17/11/2011
   ''' </summary> 
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_trans_id">Parametro 3: </param> 
   ''' <returns>Si no hay registros devuelve Falso</returns> 
   ''' <remarks></remarks> 
   Public Function GUIA_SalidasPendientes(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_trans_id As String) As Boolean
      m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
      Try
         Return d_dist_guiasremision.GUIA_SalidasPendientes(m_listDIST_GuiasRemision, x_fecini, x_fecfin, x_trans_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Procedimiento "GUIA_GuiasPorConductor" por el Generador 17/11/2011
   ''' </summary> 
   ''' <param name="x_condu_id">Parametro 1: </param> 
   ''' <param name="x_trans_id">Parametro 3: </param> 
   ''' <returns>Si no hay registros devuelve Falso</returns> 
   ''' <remarks></remarks> 
   Public Function GUIA_GuiasPorConductor(ByVal x_condu_id As String, ByVal x_vehic_id As Long, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_trans_id As String) As Boolean
      m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
      Try
         Return d_dist_guiasremision.GUIA_GuiasPorConductor(m_listDIST_GuiasRemision, x_condu_id, x_vehic_id, x_fecini, x_fecfin, x_trans_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' obtener las guias por conductor
   ''' </summary>
   ''' <param name="x_condu_id">codigo del conductor</param>
   ''' <param name="x_vehic_id">codigo del vehiculo</param>
   ''' <param name="x_fecini">fecha de inicio de busqueda</param>
   ''' <param name="x_trans_id">condigo del transportista</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GUIA_GuiasPorConductor(ByVal x_condu_id As String, ByVal x_vehic_id As Long, ByVal x_fecini As Date, ByVal x_trans_id As String) As Boolean
      m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
      Try
         Return d_dist_guiasremision.GUIA_GuiasPorConductor(m_listDIST_GuiasRemision, x_condu_id, x_vehic_id, x_fecini, x_trans_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Procedimiento "GUIA_GuiasDeSalidas" por el Generador 18/11/2011
   ''' </summary> 
   ''' <param name="x_vehic_id">Parametro 1: </param> 
   ''' <param name="x_fecha">Parametro 2: </param> 
   ''' <param name="x_trans_id">Parametro 3: </param> 
   ''' <returns>Si no hay registros devuelve Falso</returns> 
   ''' <remarks></remarks> 
   Public Function GUIA_GuiasDeSalidas(ByVal x_vehic_id As Long, ByVal x_fecha As Date, ByVal x_trans_id As String) As Boolean
      m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
      Try
         Return d_dist_guiasremision.GUIA_GuiasDeSalidas(m_listDIST_GuiasRemision, x_vehic_id, x_fecha, x_trans_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' actualizar campos de la guia de remision
   ''' </summary>
   ''' <param name="e_Guia_Remision">clase guia de remision que se actualizara</param>
   ''' <param name="x_opcion">opcion de actualizacion</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GUIAR_UnRegActGuiaRemision(ByRef e_Guia_Remision As EDIST_GuiasRemision, ByVal x_opcion As Boolean, ByVal x_usuario As String) As Integer
      Try
         Return d_dist_guiasremision.GUIAR_UnRegActGuiaRemision(e_Guia_Remision, x_opcion, x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

    ''' <summary>
    ''' asignar permisos a la orden para imprimir
    ''' </summary>
    ''' <param name="x_orden_codigo"></param>
    ''' <param name="x_value"></param>
    ''' <param name="x_usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetPermisoImpGuia(ByVal x_orden_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
        Try
            Return d_dist_guiasremision.SetPermisoImpGuia(x_orden_codigo, x_value, x_usuario)
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
    Public Function SetPermisoAnularGuia(ByVal x_orden_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
        Try
            Return d_dist_guiasremision.SetPermisoAnularGuia(x_orden_codigo, x_value, x_usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class

