Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Public Class BABAS_GestionOrdenes

    
#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "
	
#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
 
   'Public Function BuscarOrdenesIngresoLocal(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_iddestino As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
   '   m_listDIST_Ordenes = New List(Of EABAS_OrdenesProduccion)
   '   Try
   '      Return d_dist_ordenes.LOG_DISTSS_BuscarOrdenesIngresoLocal(m_listDIST_Ordenes, x_fecini, x_fecfin, x_pvent_iddestino, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos)
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function


   'Public Function ObtenerOrdend(ByVal x_orden_codigo As String, ByVal x_detalle As Boolean,m_edist_ordenes As EABAS_OrdenesProduccion) As Boolean
   '   'm_edist_ordenes = New EABAS_OrdenesProduccion
   '   Try
   '      Return d_dist_ordenes.LOG_DISTSS_ObtenerOrdenD(m_edist_ordenes, x_orden_codigo, x_detalle)
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function


#End Region
    
End Class




Partial Public Class BABAS_GestionOrdenes

#Region " Variables "
	
	Private m_eabas_gestionordenes As EABAS_GestionOrdenes
	Private m_listABAS_GestionOrdenes As List(Of EABAS_GestionOrdenes)
    Private m_listABAS_GestionOrdenescantidades As List(Of EABAS_GestionOrdenes)
	Private m_dtABAS_GestionOrdenes As DataTable

	Private m_dsABAS_GestionOrdenes As DataSet
	Private d_dabas_gestionordenes As DABAS_GestionOrdenes 
     Private m_dttable As DataTable
#End Region

#Region " Constructores "
	
	Public Sub New()
		d_dabas_gestionordenes = New DABAS_GestionOrdenes()
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

	Public Property ABAS_GestionOrdenes() As EABAS_GestionOrdenes 
		Get
			return m_eabas_gestionordenes
		End Get
		Set(ByVal value As EABAS_GestionOrdenes)
			m_eabas_gestionordenes = value
		End Set
	End Property

	Public Property ListABAS_GestionOrdenes() As List(Of EABAS_GestionOrdenes)
		Get
			return m_listABAS_GestionOrdenes
		End Get
		Set(ByVal value As List(Of EABAS_GestionOrdenes))
			m_listABAS_GestionOrdenes = value
		End Set
	End Property
    
    Public Property ListABAS_GestionOrdenesCant() As List(Of EABAS_GestionOrdenes)
		Get
			return m_listABAS_GestionOrdenescantidades
		End Get
		Set(ByVal value As List(Of EABAS_GestionOrdenes))
			m_listABAS_GestionOrdenescantidades = value
		End Set
	End Property


	Public Property DTABAS_GestionOrdenes() As DataTable
		Get
			return m_dtABAS_GestionOrdenes
		End Get
		Set(ByVal value As DataTable)
			m_dtABAS_GestionOrdenes = value
		End Set
	End Property

	Public Property DSABAS_GestionOrdenes() As DataSet
		Get
			return m_dsABAS_GestionOrdenes
		End Get
		Set(ByVal value As DataSet)
			m_dsABAS_GestionOrdenes = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listABAS_GestionOrdenes = new List(Of EABAS_GestionOrdenes)()
			return d_dabas_gestionordenes.DIST_GESTIONORDSS_Todos(m_listABAS_GestionOrdenes)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_GestionOrdenes = new List(Of EABAS_GestionOrdenes)()
			return d_dabas_gestionordenes.DIST_GESTIONORDSS_Todos(m_listABAS_GestionOrdenes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_GestionOrdenes = new List(Of EABAS_GestionOrdenes)()
			return d_dabas_gestionordenes.DIST_GESTIONORDSS_Todos(m_listABAS_GestionOrdenes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listABAS_GestionOrdenes = new List(Of EABAS_GestionOrdenes)()
			return d_dabas_gestionordenes.DIST_GESTIONORDSS_Todos(m_listABAS_GestionOrdenes, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_GestionOrdenes = new DataSet()
			return d_dabas_gestionordenes.DIST_GESTIONORDSS_Todos(m_dsABAS_GestionOrdenes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_GestionOrdenes = new DataSet()
			return d_dabas_gestionordenes.DIST_GESTIONORDSS_Todos(m_dsABAS_GestionOrdenes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_GestionOrdenes = new DataSet()
			Dim _opcion As Boolean = d_dabas_gestionordenes.DIST_GESTIONORDSS_Todos(m_dsABAS_GestionOrdenes, x_where)
		If _opcion Then
			m_dtABAS_GestionOrdenes = m_dsABAS_GestionOrdenes.Tables(0)
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
			m_dsABAS_GestionOrdenes = new DataSet()
			Dim _opcion As Boolean = d_dabas_gestionordenes.DIST_GESTIONORDSS_Todos(m_dsABAS_GestionOrdenes, x_join, x_where)
		If _opcion Then
			m_dtABAS_GestionOrdenes = m_dsABAS_GestionOrdenes.Tables(0)
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
			m_eabas_gestionordenes = New EABAS_GestionOrdenes()
			Return d_dabas_gestionordenes.DIST_GESTIONORDSS_UnReg(m_eabas_gestionordenes, x_orden_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_eabas_gestionordenes = New EABAS_GestionOrdenes()
			Return d_dabas_gestionordenes.DIST_GESTIONORDSS_UnReg(m_eabas_gestionordenes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_eabas_gestionordenes = New EABAS_GestionOrdenes()
			Return d_dabas_gestionordenes.DIST_GESTIONORDSS_UnReg(m_eabas_gestionordenes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
    

   Public Function ObtenerGestionOrden(ByVal x_orden_codigo As String) As Boolean
      m_eabas_gestionordenes = New EABAS_GestionOrdenes
      Try
         Return d_dabas_gestionordenes.LOG_DISTSS_ObtenerGestionOrden(m_eabas_gestionordenes, x_orden_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

     Public Function BuscarGestionOrdenCantidad ( ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_almacen As Short, ByVal x_todos As Boolean) As Boolean
      m_listABAS_GestionOrdenescantidades = New List(Of EABAS_GestionOrdenes)
      Try
         Return d_dabas_gestionordenes.LOG_DISTSS_BuscarPedidoTransCANTIDAD(m_listABAS_GestionOrdenescantidades,x_fecini.AddDays(-1),x_fecfin ,x_almacen, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function


	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_eabas_gestionordenes.Nuevo Then
				d_dabas_gestionordenes.DIST_GESTIONORDSI_UnReg(m_eabas_gestionordenes, x_usuario)
			ElseIf m_eabas_gestionordenes.Modificado Then
				d_dabas_gestionordenes.DIST_GESTIONORDSU_UnReg(m_eabas_gestionordenes, x_usuario)
			ElseIf m_eabas_gestionordenes.Eliminado Then
				d_dabas_gestionordenes.DIST_GESTIONORDSD_UnReg(ABAS_GestionOrdenes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eabas_gestionordenes.Nuevo Then
				d_dabas_gestionordenes.DIST_GESTIONORDSI_UnReg(m_eabas_gestionordenes, x_usuario)
			ElseIf m_eabas_gestionordenes.Modificado Then
				d_dabas_gestionordenes.DIST_GESTIONORDSU_UnReg(m_eabas_gestionordenes, x_where, x_usuario)
			ElseIf m_eabas_gestionordenes.Eliminado Then
				d_dabas_gestionordenes.DIST_GESTIONORDSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_gestionordenes.Nuevo Then
				d_dabas_gestionordenes.DIST_GESTIONORDSI_UnReg(m_eabas_gestionordenes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_gestionordenes.Modificado Then
				d_dabas_gestionordenes.DIST_GESTIONORDSU_UnReg(m_eabas_gestionordenes, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_gestionordenes.Eliminado Then
				d_dabas_gestionordenes.DIST_GESTIONORDSD_UnReg(ABAS_GestionOrdenes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eabas_gestionordenes.Nuevo Then
				d_dabas_gestionordenes.DIST_GESTIONORDSI_UnReg(m_eabas_gestionordenes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_gestionordenes.Modificado Then
				d_dabas_gestionordenes.DIST_GESTIONORDSU_UnReg(m_eabas_gestionordenes, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_eabas_gestionordenes.Eliminado Then
				d_dabas_gestionordenes.DIST_GESTIONORDSD_UnReg(ABAS_GestionOrdenes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_gestionordenes.Nuevo Then
				d_dabas_gestionordenes.DIST_GESTIONORDSI_UnReg(m_eabas_gestionordenes, x_usuario, x_setfecha)
			ElseIf m_eabas_gestionordenes.Modificado Then
				d_dabas_gestionordenes.DIST_GESTIONORDSU_UnReg(m_eabas_gestionordenes, x_usuario, x_setfecha)
			ElseIf m_eabas_gestionordenes.Eliminado Then
				d_dabas_gestionordenes.DIST_GESTIONORDSD_UnReg(ABAS_GestionOrdenes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_gestionordenes.Nuevo Then
				d_dabas_gestionordenes.DIST_GESTIONORDSI_UnReg(m_eabas_gestionordenes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_gestionordenes.Eliminado Then
				d_dabas_gestionordenes.DIST_GESTIONORDSD_UnReg(m_eabas_gestionordenes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_GestionOrdenes = new List(Of EABAS_GestionOrdenes)()
			return d_dabas_gestionordenes.DIST_GESTIONORDSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_dabas_gestionordenes.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
    Public Function getTipoUnidadMedida(ByVal x_campo As String) As String
		Try
			Return d_dabas_gestionordenes.getUnidadMedida(x_campo) 
		Catch ex As Exception
			Throw ex
		End Try
	End Function



	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_dabas_gestionordenes.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_dabas_gestionordenes.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_dabas_gestionordenes.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region



End Class
