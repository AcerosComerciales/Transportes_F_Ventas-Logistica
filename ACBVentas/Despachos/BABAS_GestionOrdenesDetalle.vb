Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas


Public Class BABAS_GestionOrdenesDetalle


    
#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "
	
#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
#End Region
End Class



Partial Public Class BABAS_GestionOrdenesDetalle

#Region " Variables "
	
	Private m_eabas_gestionordenesdetalle As EABAS_GestionOrdenesDetalle
	Private m_listABAS_GestionOrdenesDetalle As List(Of EABAS_GestionOrdenesDetalle)
	Private m_dtABAS_GestionOrdenesDetalle As DataTable

	Private m_dsABAS_GestionOrdenesDetalle As DataSet
	Private d_abas_gestionordenesdetalle As DABAS_GestionOrdenesDetalle


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_abas_gestionordenesdetalle = New DABAS_GestionOrdenesDetalle()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property ABAS_GestionOrdenesDetalle() As EABAS_GestionOrdenesDetalle 
		Get
			return m_eabas_gestionordenesdetalle
		End Get
		Set(ByVal value As EABAS_GestionOrdenesDetalle)
			m_eabas_gestionordenesdetalle = value
		End Set
	End Property

	Public Property ListABAS_GestionOrdenesDetalle() As List(Of EABAS_GestionOrdenesDetalle)
		Get
			return m_listABAS_GestionOrdenesDetalle
		End Get
		Set(ByVal value As List(Of EABAS_GestionOrdenesDetalle))
			m_listABAS_GestionOrdenesDetalle = value
		End Set
	End Property

	Public Property DTABAS_GestionOrdenesDetalle() As DataTable
		Get
			return m_dtABAS_GestionOrdenesDetalle
		End Get
		Set(ByVal value As DataTable)
			m_dtABAS_GestionOrdenesDetalle = value
		End Set
	End Property

	Public Property DSABAS_GestionOrdenesDetalle() As DataSet
		Get
			return m_dsABAS_GestionOrdenesDetalle
		End Get
		Set(ByVal value As DataSet)
			m_dsABAS_GestionOrdenesDetalle = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listABAS_GestionOrdenesDetalle = new List(Of EABAS_GestionOrdenesDetalle)()
			return d_abas_gestionordenesdetalle.DIST_GESTIONORDSS_Todos(m_listABAS_GestionOrdenesDetalle)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_GestionOrdenesDetalle = new List(Of EABAS_GestionOrdenesDetalle)()
			return d_abas_gestionordenesdetalle.DIST_GESTIONORDSS_Todos(m_listABAS_GestionOrdenesDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_GestionOrdenesDetalle = new List(Of EABAS_GestionOrdenesDetalle)()
			return d_abas_gestionordenesdetalle.DIST_GESTIONORDSS_Todos(m_listABAS_GestionOrdenesDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listABAS_GestionOrdenesDetalle = new List(Of EABAS_GestionOrdenesDetalle)()
			return d_abas_gestionordenesdetalle.DIST_GESTIONORDSS_Todos(m_listABAS_GestionOrdenesDetalle, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_orden_codigo As String) As Boolean
		Try
			m_eabas_gestionordenesdetalle = New EABAS_GestionOrdenesDetalle()
			Return d_abas_gestionordenesdetalle.DIST_GESTIONORDSS_Todos(m_eabas_gestionordenesdetalle, x_orden_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_GestionOrdenesDetalle = new DataSet()
			return d_abas_gestionordenesdetalle.DIST_GESTIONORDSS_Todos(m_dsABAS_GestionOrdenesDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_GestionOrdenesDetalle = new DataSet()
			return d_abas_gestionordenesdetalle.DIST_GESTIONORDSS_Todos(m_dsABAS_GestionOrdenesDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_GestionOrdenesDetalle = new DataSet()
			Dim _opcion As Boolean = d_abas_gestionordenesdetalle.DIST_GESTIONORDSS_Todos(m_dsABAS_GestionOrdenesDetalle, x_where)
		If _opcion Then
			m_dtABAS_GestionOrdenesDetalle = m_dsABAS_GestionOrdenesDetalle.Tables(0)
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
			m_dsABAS_GestionOrdenesDetalle = new DataSet()
			Dim _opcion As Boolean = d_abas_gestionordenesdetalle.DIST_GESTIONORDSS_Todos(m_dsABAS_GestionOrdenesDetalle, x_join, x_where)
		If _opcion Then
			m_dtABAS_GestionOrdenesDetalle = m_dsABAS_GestionOrdenesDetalle.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_orden_codigo As String, x_ordet_item As Short) As Boolean
		Try
			m_eabas_gestionordenesdetalle = New EABAS_GestionOrdenesDetalle()
			Return d_abas_gestionordenesdetalle.DIST_GESTIONORDSS_UnReg(m_eabas_gestionordenesdetalle, x_orden_codigo, x_ordet_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_eabas_gestionordenesdetalle = New EABAS_GestionOrdenesDetalle()
			Return d_abas_gestionordenesdetalle.DIST_GESTIONORDSS_UnReg(m_eabas_gestionordenesdetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_eabas_gestionordenesdetalle = New EABAS_GestionOrdenesDetalle()
			Return d_abas_gestionordenesdetalle.DIST_GESTIONORDSS_UnReg(m_eabas_gestionordenesdetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_eabas_gestionordenesdetalle.Nuevo Then
				d_abas_gestionordenesdetalle.DIST_GESTIONORDSI_UnReg(m_eabas_gestionordenesdetalle, x_usuario)
			ElseIf m_eabas_gestionordenesdetalle.Modificado Then
				d_abas_gestionordenesdetalle.DIST_GESTIONORDSU_UnReg(m_eabas_gestionordenesdetalle, x_usuario)
			ElseIf m_eabas_gestionordenesdetalle.Eliminado Then
				d_abas_gestionordenesdetalle.DIST_GESTIONORDSD_UnReg(ABAS_GestionOrdenesDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eabas_gestionordenesdetalle.Nuevo Then
				d_abas_gestionordenesdetalle.DIST_GESTIONORDSI_UnReg(m_eabas_gestionordenesdetalle, x_usuario)
			ElseIf m_eabas_gestionordenesdetalle.Modificado Then
				d_abas_gestionordenesdetalle.DIST_GESTIONORDSU_UnReg(m_eabas_gestionordenesdetalle, x_where, x_usuario)
			ElseIf m_eabas_gestionordenesdetalle.Eliminado Then
				d_abas_gestionordenesdetalle.DIST_GESTIONORDSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_gestionordenesdetalle.Nuevo Then
				d_abas_gestionordenesdetalle.DIST_GESTIONORDSI_UnReg(m_eabas_gestionordenesdetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_gestionordenesdetalle.Modificado Then
				d_abas_gestionordenesdetalle.DIST_GESTIONORDSU_UnReg(m_eabas_gestionordenesdetalle, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_gestionordenesdetalle.Eliminado Then
				d_abas_gestionordenesdetalle.DIST_GESTIONORDSD_UnReg(ABAS_GestionOrdenesDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eabas_gestionordenesdetalle.Nuevo Then
				d_abas_gestionordenesdetalle.DIST_GESTIONORDSI_UnReg(m_eabas_gestionordenesdetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_gestionordenesdetalle.Modificado Then
				d_abas_gestionordenesdetalle.DIST_GESTIONORDSU_UnReg(m_eabas_gestionordenesdetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_eabas_gestionordenesdetalle.Eliminado Then
				d_abas_gestionordenesdetalle.DIST_GESTIONORDSD_UnReg(ABAS_GestionOrdenesDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_gestionordenesdetalle.Nuevo Then
				d_abas_gestionordenesdetalle.DIST_GESTIONORDSI_UnReg(m_eabas_gestionordenesdetalle, x_usuario, x_setfecha)
			ElseIf m_eabas_gestionordenesdetalle.Modificado Then
				d_abas_gestionordenesdetalle.DIST_GESTIONORDSU_UnReg(m_eabas_gestionordenesdetalle, x_usuario, x_setfecha)
			ElseIf m_eabas_gestionordenesdetalle.Eliminado Then
				d_abas_gestionordenesdetalle.DIST_GESTIONORDSD_UnReg(ABAS_GestionOrdenesDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_gestionordenesdetalle.Nuevo Then
				d_abas_gestionordenesdetalle.DIST_GESTIONORDSI_UnReg(m_eabas_gestionordenesdetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_gestionordenesdetalle.Eliminado Then
				d_abas_gestionordenesdetalle.DIST_GESTIONORDSD_UnReg(m_eabas_gestionordenesdetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_GestionOrdenesDetalle = new List(Of EABAS_GestionOrdenesDetalle)()
			return d_abas_gestionordenesdetalle.DIST_GESTIONORDSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_abas_gestionordenesdetalle.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_abas_gestionordenesdetalle.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_abas_gestionordenesdetalle.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_abas_gestionordenesdetalle.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region



End Class
