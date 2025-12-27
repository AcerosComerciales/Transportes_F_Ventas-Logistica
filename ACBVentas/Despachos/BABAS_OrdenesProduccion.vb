Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Public Class BABAS_OrdenesProduccion


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
      m_listDIST_Ordenes = New List(Of EABAS_OrdenesProduccion)
      Try
         Return d_dist_ordenes.LOG_DISTSS_BuscarOrdenesIngreso(m_listDIST_Ordenes, x_fecini, x_fecfin, x_pvent_id, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    
      Public Function BuscarOrdenesParaConfirmarIngPro(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_Ordenes = New List(Of EABAS_OrdenesProduccion)
      Try
         Return d_dist_ordenes.LOG_DISTSS_BuscarOrdParaConfirIngPro(m_listDIST_Ordenes, x_fecini, x_fecfin, x_pvent_id, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    
    Public Function BuscarOrdenesSalidaProConf(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_Ordenes = New List(Of EABAS_OrdenesProduccion)
      Try
         Return d_dist_ordenes.LOG_DISTSS_BuscarOrdenesSalidaProConf(m_listDIST_Ordenes, x_fecini, x_fecfin, x_pvent_id, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function



    
     Public Function BuscarOrdenesIngresoConf(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_Ordenes = New List(Of EABAS_OrdenesProduccion)
      Try
         Return d_dist_ordenes.LOG_DISTSS_BuscarOrdenesIngresoConf(m_listDIST_Ordenes, x_fecini, x_fecfin, x_pvent_id, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos)
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
      m_listDIST_Ordenes = New List(Of EABAS_OrdenesProduccion)
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
      m_listDIST_Ordenes = New List(Of EABAS_OrdenesProduccion)
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
   Public Function ObtenerOrdend(ByVal x_orden_codigo As String, ByVal x_detalle As Boolean,m_edist_ordenes As EABAS_OrdenesProduccion) As Boolean
      'm_edist_ordenes = New EABAS_OrdenesProduccion
      Try
         Return d_dist_ordenes.LOG_DISTSS_ObtenerOrdenD(m_edist_ordenes, x_orden_codigo, x_detalle)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    Public Function ObtenerOrden(ByVal x_orden_codigo As String, ByVal x_detalle As Boolean) As Boolean
      m_edist_ordenes = New EABAS_OrdenesProduccion
      Try
         Return d_dist_ordenes.LOG_DISTSS_ObtenerOrden(m_edist_ordenes, x_orden_codigo, x_detalle)
      Catch ex As Exception
         Throw ex
      End Try
   End Function


#End Region
End Class
  



Partial Public Class BABAS_OrdenesProduccion

#Region " Variables "
	
	Private m_edist_ordenes As EABAS_OrdenesProduccion
	Private m_listDIST_Ordenes As List(Of EABAS_OrdenesProduccion)
	Private m_dtDIST_Ordenes As DataTable

	Private m_dsDIST_Ordenes As DataSet
	Private d_dist_ordenes As DABAS_OrdenesProduccion 
     Private m_dttable As DataTable
#End Region

#Region " Constructores "
	
	Public Sub New()
		d_dist_ordenes = New DABAS_OrdenesProduccion()
	End Sub

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

	Public Property DIST_Ordenes() As EABAS_OrdenesProduccion 
		Get
			return m_edist_ordenes
		End Get
		Set(ByVal value As EABAS_OrdenesProduccion)
			m_edist_ordenes = value
		End Set
	End Property

	Public Property ListDIST_Ordenes() As List(Of EABAS_OrdenesProduccion)
		Get
			return m_listDIST_Ordenes
		End Get
		Set(ByVal value As List(Of EABAS_OrdenesProduccion))
			m_listDIST_Ordenes = value
		End Set
	End Property

	Public Property DTDIST_Ordenes() As DataTable
		Get
			return m_dtDIST_Ordenes
		End Get
		Set(ByVal value As DataTable)
			m_dtDIST_Ordenes = value
		End Set
	End Property

	Public Property DSDIST_Ordenes() As DataSet
		Get
			return m_dsDIST_Ordenes
		End Get
		Set(ByVal value As DataSet)
			m_dsDIST_Ordenes = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listDIST_Ordenes = new List(Of EABAS_OrdenesProduccion)()
			return d_dist_ordenes.DIST_ORDENSS_Todos(m_listDIST_Ordenes)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listDIST_Ordenes = new List(Of EABAS_OrdenesProduccion)()
			return d_dist_ordenes.DIST_ORDENSS_Todos(m_listDIST_Ordenes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listDIST_Ordenes = new List(Of EABAS_OrdenesProduccion)()
			return d_dist_ordenes.DIST_ORDENSS_Todos(m_listDIST_Ordenes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listDIST_Ordenes = new List(Of EABAS_OrdenesProduccion)()
			return d_dist_ordenes.DIST_ORDENSS_Todos(m_listDIST_Ordenes, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDIST_Ordenes = new DataSet()
			return d_dist_ordenes.DIST_ORDENSS_Todos(m_dsDIST_Ordenes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDIST_Ordenes = new DataSet()
			return d_dist_ordenes.DIST_ORDENSS_Todos(m_dsDIST_Ordenes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDIST_Ordenes = new DataSet()
			Dim _opcion As Boolean = d_dist_ordenes.DIST_ORDENSS_Todos(m_dsDIST_Ordenes, x_where)
		If _opcion Then
			m_dtDIST_Ordenes = m_dsDIST_Ordenes.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDIST_Ordenes = new DataSet()
			Dim _opcion As Boolean = d_dist_ordenes.DIST_ORDENSS_Todos(m_dsDIST_Ordenes, x_join, x_where)
		If _opcion Then
			m_dtDIST_Ordenes = m_dsDIST_Ordenes.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_orden_codigo As String) As Boolean
		Try
			m_edist_ordenes = New EABAS_OrdenesProduccion()
			Return d_dist_ordenes.DIST_ORDENSS_UnReg(m_edist_ordenes, x_orden_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
      Public Function Obtener_Deta_Anulada(ByVal x_docve_codigo As String,ByVal x_documento As String) As Boolean
        Try
            m_dttable = New DataTable
            Return d_dist_ordenes.Obtener_Deta_Anulada(m_dttable, x_docve_codigo,x_documento)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_edist_ordenes = New EABAS_OrdenesProduccion()
			Return d_dist_ordenes.DIST_ORDENSS_UnReg(m_edist_ordenes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_edist_ordenes = New EABAS_OrdenesProduccion()
			Return d_dist_ordenes.DIST_ORDENSS_UnReg(m_edist_ordenes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_edist_ordenes.Nuevo Then
				d_dist_ordenes.DIST_ORDENSI_UnReg(m_edist_ordenes, x_usuario)
			ElseIf m_edist_ordenes.Modificado Then
				d_dist_ordenes.DIST_ORDENSU_UnReg(m_edist_ordenes, x_usuario)
			ElseIf m_edist_ordenes.Eliminado Then
				d_dist_ordenes.DIST_ORDENSD_UnReg(DIST_Ordenes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_edist_ordenes.Nuevo Then
				d_dist_ordenes.DIST_ORDENSI_UnReg(m_edist_ordenes, x_usuario)
			ElseIf m_edist_ordenes.Modificado Then
				d_dist_ordenes.DIST_ORDENSU_UnReg(m_edist_ordenes, x_where, x_usuario)
			ElseIf m_edist_ordenes.Eliminado Then
				d_dist_ordenes.DIST_ORDENSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edist_ordenes.Nuevo Then
				d_dist_ordenes.DIST_ORDENSI_UnReg(m_edist_ordenes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edist_ordenes.Modificado Then
				d_dist_ordenes.DIST_ORDENSU_UnReg(m_edist_ordenes, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edist_ordenes.Eliminado Then
				d_dist_ordenes.DIST_ORDENSD_UnReg(DIST_Ordenes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_edist_ordenes.Nuevo Then
				d_dist_ordenes.DIST_ORDENSI_UnReg(m_edist_ordenes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edist_ordenes.Modificado Then
				d_dist_ordenes.DIST_ORDENSU_UnReg(m_edist_ordenes, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_edist_ordenes.Eliminado Then
				d_dist_ordenes.DIST_ORDENSD_UnReg(DIST_Ordenes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edist_ordenes.Nuevo Then
				d_dist_ordenes.DIST_ORDENSI_UnReg(m_edist_ordenes, x_usuario, x_setfecha)
			ElseIf m_edist_ordenes.Modificado Then
				d_dist_ordenes.DIST_ORDENSU_UnReg(m_edist_ordenes, x_usuario, x_setfecha)
			ElseIf m_edist_ordenes.Eliminado Then
				d_dist_ordenes.DIST_ORDENSD_UnReg(DIST_Ordenes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edist_ordenes.Nuevo Then
				d_dist_ordenes.DIST_ORDENSI_UnReg(m_edist_ordenes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edist_ordenes.Eliminado Then
				d_dist_ordenes.DIST_ORDENSD_UnReg(DIST_Ordenes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listDIST_Ordenes = new List(Of EABAS_OrdenesProduccion)()
			return d_dist_ordenes.DIST_ORDENSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_dist_ordenes.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
    Public Function getTipoUnidadMedida(ByVal x_campo As String) As String
		Try
			Return d_dist_ordenes.getUnidadMedida(x_campo) 
		Catch ex As Exception
			Throw ex
		End Try
	End Function



	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_dist_ordenes.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_dist_ordenes.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_dist_ordenes.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region



End Class
