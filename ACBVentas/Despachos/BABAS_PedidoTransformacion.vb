Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Public Class BABAS_PedidoTransformacion


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
   Public Function BuscarPedidoTransformacionIngreso(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_PEDIDTrans = New List(Of EABAS_PedidoTransformacion)
      Try
         Return d_dist_PEDIDTrans.LOG_DISTSS_BuscarPedidoTransIngreso(m_listDIST_PEDIDTrans, x_fecini, x_fecfin, x_pvent_id, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    Public Function BuscarPedidoTransformacionIngresoxArticulos( ByVal x_articulo As String, ByVal x_almacen As Short, ByVal x_todos As Boolean) As Boolean
      m_listDist_PedidTransDetalle = New List(Of EABAS_PedidoTransformacionDetalle)
      Try
         Return d_dist_PEDIDTrans.LOG_DISTSS_BuscarPedidoTransIngresoxArticulo(m_listDist_PedidTransDetalle,x_articulo ,x_almacen, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    Public Function AgregarCalibres(ByVal x_codigogestor As String, ByVal x_calibre As Decimal, ByVal x_pm As Decimal, ByVal x_aprox As Decimal,
                                    ByVal x_numCalibre As string) As Boolean
      Try
         Return d_dist_PEDIDTrans.AgreagarCalibre(x_codigogestor,x_calibre ,x_pm, x_aprox,x_numCalibre)
      Catch ex As Exception
         Throw ex
      End Try
    End Function
    
     Public Function ActualizarEstadoT(ByVal x_codigogestor As String) As Boolean
      Try
         Return d_dist_PEDIDTrans.ActualizarEstadoT(x_codigogestor)
      Catch ex As Exception
         Throw ex
      End Try
    End Function
    
    Public Function BuscarPedidoTransformacionIngresoxLote( ByVal x_lote As String, ByVal x_almacen As Short, ByVal x_todos As Boolean) As Boolean
      m_listDist_PedidTransDetalle = New List(Of EABAS_PedidoTransformacionDetalle)
      Try
         Return d_dist_PEDIDTrans.LOG_DISTSS_BuscarPedidoTransIngresoxlote(m_listDist_PedidTransDetalle,x_lote ,x_almacen, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    Public Function BuscarPedidoTransformacionXnumeroYlinea(ByVal x_serie As String, ByVal x_numero As Long, ByVal x_pvent_id As Short, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean,ByVal X_linea As String) As Boolean
        m_listDIST_PEDIDTrans = New List(Of EABAS_PedidoTransformacion)
        Try
            Return d_dist_PEDIDTrans.LOG_DISTSS_BuscarPedidoTransXnumeroYlinea(m_listDIST_PEDIDTrans, x_serie, x_numero, x_pvent_id, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos, X_linea)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

     Public Function BuscarPedidoTransformacionXlinea(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean,
                                             ByVal X_linea As String) As Boolean
      m_listDIST_PEDIDTrans = New List(Of EABAS_PedidoTransformacion)
      Try
         Return d_dist_PEDIDTrans.LOG_DISTSS_BuscarOrdenessalidaXlinea(m_listDIST_PEDIDTrans, x_fecini, x_fecfin, x_pvent_id, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos,X_linea)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    
    Public Function BuscarPedidoTransformacionIngresoxfecha( ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_almacen As Short, ByVal x_todos As Boolean) As Boolean
      m_listDist_PedidTransDetalle = New List(Of EABAS_PedidoTransformacionDetalle)
      Try
         Return d_dist_PEDIDTrans.LOG_DISTSS_BuscarPedidoTransIngresoxfecha(m_listDist_PedidTransDetalle,x_fecini.AddDays(-1),x_fecfin ,x_almacen, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

     Public Function BuscarPedidoTransformacionCantidad ( ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_almacen As Short, ByVal x_todos As Boolean) As Boolean
      m_listDIST_PEDIDTransCantidad = New List(Of EABAS_PedidoTransformacion)
      Try
         Return d_dist_PEDIDTrans.LOG_DISTSS_BuscarPedidoTransCANTIDAD(m_listDIST_PEDIDTransCantidad,x_fecini.AddDays(-1),x_fecfin ,x_almacen, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    
      Public Function BuscarPedidoTransformacionConfirmar(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_PEDIDTrans = New List(Of EABAS_PedidoTransformacion)
      Try
         Return d_dist_PEDIDTrans.LOG_DISTSS_BuscarPedidoTransIngresoConfir(m_listDIST_PEDIDTrans, x_fecini, x_fecfin, x_pvent_id, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    
   ' Public Function BuscarOrdenesSalidaProConf(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
   '   m_listDIST_PEDIDTrans = New List(Of EABAS_PedidoTransformacion)
   '   Try
   '      Return d_dist_ordenes.LOG_DISTSS_BuscarOrdenesSalidaProConf(m_listDIST_Ordenes, x_fecini, x_fecfin, x_pvent_id, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos)
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function



    
   '  Public Function BuscarOrdenesIngresoConf(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
   '   m_listDIST_Ordenes = New List(Of EABAS_OrdenesProduccion)
   '   Try
   '      Return d_dist_ordenes.LOG_DISTSS_BuscarOrdenesIngresoConf(m_listDIST_Ordenes, x_fecini, x_fecfin, x_pvent_id, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos)
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function
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
   'Public Function BuscarOrdenesIngresoPtoVenta(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_iddestino As Long, ByVal x_pvent_idorigen As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
   '   m_listDIST_Ordenes = New List(Of EABAS_OrdenesProduccion)
   '   Try
   '      Return d_dist_ordenes.LOG_DISTSS_BuscarOrdenesIngresoPtoVenta(m_listDIST_Ordenes, x_fecini, x_fecfin, x_pvent_iddestino, x_pvent_idorigen, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos)
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function

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
   'Public Function BuscarOrdenesIngresoLocal(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_iddestino As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
   '   m_listDIST_Ordenes = New List(Of EABAS_OrdenesProduccion)
   '   Try
   '      Return d_dist_ordenes.LOG_DISTSS_BuscarOrdenesIngresoLocal(m_listDIST_Ordenes, x_fecini, x_fecfin, x_pvent_iddestino, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos)
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function


   ''' <summary> 
   ''' Capa de Negocio: LOG_DISTSS_ObtenerOrden
   ''' </summary>
   ''' <param name="x_orden_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   'Public Function ObtenerOrdend(ByVal x_orden_codigo As String, ByVal x_detalle As Boolean,m_edist_ordenes As EABAS_OrdenesProduccion) As Boolean
   '   'm_edist_ordenes = New EABAS_OrdenesProduccion
   '   Try
   '      Return d_dist_ordenes.LOG_DISTSS_ObtenerOrdenD(m_edist_ordenes, x_orden_codigo, x_detalle)
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function

    Public Function ObtenerPedidoTrnas(ByVal x_pedidotrans_codigo As String, ByVal x_detalle As Boolean) As Boolean
      m_edist_PedidTransformacion = New EABAS_PedidoTransformacion
      Try
         Return d_dist_PEDIDTrans.LOG_DISTSS_Obtenerpedidotrans(m_edist_PedidTransformacion, x_pedidotrans_codigo, x_detalle)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    
    
    Public Function ObtenerPedidoTrnas_consulta(ByVal x_pedidotrans_codigo As String, ByVal x_detalle As Boolean) As Boolean
      m_edist_PedidTransformacion = New EABAS_PedidoTransformacion
      Try
         Return d_dist_PEDIDTrans.LOG_DISTSS_Obtenerpedidotrans_consulta(m_edist_PedidTransformacion, x_pedidotrans_codigo, x_detalle)
      Catch ex As Exception
         Throw ex
      End Try
   End Function





#End Region
End Class
  



Partial Public Class BABAS_PedidoTransformacion

#Region " Variables "
	
	Private m_edist_PedidTransformacion As EABAS_PedidoTransformacion
	Private m_listDIST_PEDIDTrans As List(Of EABAS_PedidoTransformacion)
    Private m_listDIST_PEDIDTransCantidad As List(Of EABAS_PedidoTransformacion)
    Private m_listDist_PedidTransDetalle As List(Of EABAS_PedidoTransformacionDetalle)
	Private m_dtDIST_PEDIDTrans As DataTable

	Private m_dsDIST_PEDIDTrans As DataSet
	Private d_dist_PEDIDTrans As DABAS_PedidoTransformacion 
     Private m_dttable As DataTable
#End Region

#Region " Constructores "
	
	Public Sub New()
		d_dist_PEDIDTrans = New DABAS_PedidoTransformacion()
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

	Public Property DIST_PEDIDTrans() As EABAS_PedidoTransformacion 
		Get
			return m_edist_PedidTransformacion
		End Get
		Set(ByVal value As EABAS_PedidoTransformacion)
			m_edist_PedidTransformacion = value
		End Set
	End Property

	Public Property ListDIST_PEDIDTrans() As List(Of EABAS_PedidoTransformacion)
		Get
			return m_listDIST_PEDIDTrans
		End Get
		Set(ByVal value As List(Of EABAS_PedidoTransformacion))
			m_listDIST_PEDIDTrans = value
		End Set
	End Property
    
    Public Property ListDIST_PEDIDTransCantidad() As List(Of EABAS_PedidoTransformacion)
		Get
			return m_listDIST_PEDIDTransCantidad
		End Get
		Set(ByVal value As List(Of EABAS_PedidoTransformacion))
			m_listDIST_PEDIDTransCantidad = value
		End Set
	End Property
    
    Public Property ListDIST_PEDIDTransDetalle() As List(Of EABAS_PedidoTransformacionDetalle)
		Get
			return m_listDist_PedidTransDetalle
		End Get
		Set(ByVal value As List(Of EABAS_PedidoTransformacionDetalle))
			m_listDist_PedidTransDetalle = value
		End Set
	End Property
	Public Property DTDIST_PEDIDTrans() As DataTable
		Get
			return m_dtDIST_PEDIDTrans
		End Get
		Set(ByVal value As DataTable)
			m_dtDIST_PEDIDTrans = value
		End Set
	End Property

	Public Property DSDIST_PEDIDTrans() As DataSet
		Get
			return m_dsDIST_PEDIDTrans
		End Get
		Set(ByVal value As DataSet)
			m_dsDIST_PEDIDTrans = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listDIST_PEDIDTrans = new List(Of EABAS_PedidoTransformacion)()
			return d_dist_PEDIDTrans.DIST_PEDIDTransS_Todos(m_listDIST_PEDIDTrans)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listDIST_PEDIDTrans = new List(Of EABAS_PedidoTransformacion)()
			return d_dist_PEDIDTrans.DIST_PEDIDTransS_Todos(m_listDIST_PEDIDTrans, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listDIST_PEDIDTrans = new List(Of EABAS_PedidoTransformacion)()
			return d_dist_PEDIDTrans.DIST_PEDIDTransS_Todos(m_listDIST_PEDIDTrans, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listDIST_PEDIDTrans = new List(Of EABAS_PedidoTransformacion)()
			return d_dist_PEDIDTrans.DIST_PEDIDTransS_Todos(m_listDIST_PEDIDTrans, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDIST_PEDIDTrans = new DataSet()
			return d_dist_PEDIDTrans.DIST_PEDIDTransS_Todos(m_dsDIST_PEDIDTrans, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDIST_PEDIDTrans = new DataSet()
			return d_dist_PEDIDTrans.DIST_PEDIDTransS_Todos(m_dsDIST_PEDIDTrans, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDIST_PEDIDTrans = new DataSet()
			Dim _opcion As Boolean = d_dist_PEDIDTrans.DIST_PEDIDTransS_Todos(m_dsDIST_PEDIDTrans, x_where)
		If _opcion Then
			m_dtDIST_PEDIDTrans = m_dsDIST_PEDIDTrans.Tables(0)
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
			m_dsDIST_PEDIDTrans = new DataSet()
			Dim _opcion As Boolean = d_dist_PEDIDTrans.DIST_PEDIDTransS_Todos(m_dsDIST_PEDIDTrans, x_join, x_where)
		If _opcion Then
			m_dtDIST_PEDIDTrans = m_dsDIST_PEDIDTrans.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_pedidtrans_codigo As String) As Boolean
		Try
			m_edist_PedidTransformacion = New EABAS_PedidoTransformacion()
			Return d_dist_PEDIDTrans.DIST_PEDIDTransS_UnReg(m_edist_PedidTransformacion, x_pedidtrans_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_edist_PedidTransformacion = New EABAS_PedidoTransformacion()
			Return d_dist_PEDIDTrans.DIST_PEDIDTransSS_UnReg(m_edist_PedidTransformacion, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_edist_PedidTransformacion = New EABAS_PedidoTransformacion()
			Return d_dist_PEDIDTrans.DIST_PEDIDTransSS_UnReg(m_edist_PedidTransformacion, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_edist_PedidTransformacion.Nuevo Then
				d_dist_PEDIDTrans.DIST_PEDIDTransSI_UnReg(m_edist_PedidTransformacion, x_usuario)
			ElseIf m_edist_PedidTransformacion.Modificado Then
				d_dist_PEDIDTrans.DIST_PEDIDTransSU_UnReg(m_edist_PedidTransformacion, x_usuario)
			ElseIf m_edist_PedidTransformacion.Eliminado Then
				d_dist_PEDIDTrans.DIST_PEDIDTrans_UnReg(DIST_PEDIDTrans)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_edist_PedidTransformacion.Nuevo Then
				d_dist_PEDIDTrans.DIST_PEDIDTransSI_UnReg(m_edist_PedidTransformacion, x_usuario)
			ElseIf m_edist_PedidTransformacion.Modificado Then
				d_dist_PEDIDTrans.DIST_PEDIDTransSU_UnReg(m_edist_PedidTransformacion, x_where, x_usuario)
			ElseIf m_edist_PedidTransformacion.Eliminado Then
				d_dist_PEDIDTrans.DIST_PEDIDTrans_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edist_PedidTransformacion.Nuevo Then
				d_dist_PEDIDTrans.DIST_PEDIDTransSI_UnReg(m_edist_PedidTransformacion, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edist_PedidTransformacion.Modificado Then
				d_dist_PEDIDTrans.DIST_PEDIDTransSU_UnReg(m_edist_PedidTransformacion, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edist_PedidTransformacion.Eliminado Then
				d_dist_PEDIDTrans.DIST_PEDIDTrans_UnReg(DIST_PEDIDTrans)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_edist_PedidTransformacion.Nuevo Then
				d_dist_PEDIDTrans.DIST_PEDIDTransSI_UnReg(m_edist_PedidTransformacion, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edist_PedidTransformacion.Modificado Then
				d_dist_PEDIDTrans.DIST_PEDIDTransSU_UnReg(m_edist_PedidTransformacion, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_edist_PedidTransformacion.Eliminado Then
				d_dist_PEDIDTrans.DIST_PEDIDTrans_UnReg(DIST_PEDIDTrans)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edist_PedidTransformacion.Nuevo Then
				d_dist_PEDIDTrans.DIST_PEDIDTransSI_UnReg(m_edist_PedidTransformacion, x_usuario, x_setfecha)
			ElseIf m_edist_PedidTransformacion.Modificado Then
				d_dist_PEDIDTrans.DIST_PEDIDTransSU_UnReg(m_edist_PedidTransformacion, x_usuario, x_setfecha)
			ElseIf m_edist_PedidTransformacion.Eliminado Then
				d_dist_PEDIDTrans.DIST_PEDIDTrans_UnReg(DIST_PEDIDTrans)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edist_PedidTransformacion.Nuevo Then
				d_dist_PEDIDTrans.DIST_PEDIDTransSI_UnReg(m_edist_PedidTransformacion, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edist_PedidTransformacion.Eliminado Then
				d_dist_PEDIDTrans.DIST_PEDIDTrans_UnReg(DIST_PEDIDTrans)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listDIST_PEDIDTrans = new List(Of EABAS_PedidoTransformacion)()
			return d_dist_PEDIDTrans.DIST_PEDIDTrans_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function


    Public Function ValidarLote(ByVal x_lote As Integer, ByVal x_articcodigo As String) As Boolean
        Try
        Try
			Return d_dist_PEDIDTrans.getlote_existente(x_lote,x_articcodigo)
		Catch ex As Exception
			Throw ex
		End Try

        Catch ex As Exception

        End Try
    End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_dist_PEDIDTrans.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
    Public Function getTipoUnidadMedida(ByVal x_campo As String) As String
		Try
			Return d_dist_PEDIDTrans.getUnidadMedida(x_campo) 
		Catch ex As Exception
			Throw ex
		End Try
	End Function



	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_dist_PEDIDTrans.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_dist_PEDIDTrans.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function


    Public Function getCorrelativoXtipo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_dist_PEDIDTrans.getCorrelativoXtip(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
    
    Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_dist_PEDIDTrans.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region


End Class
