Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica

Partial Public Class BLOG_StockIniciales

#Region " Variables "
	
	Private m_elog_stockiniciales As ELOG_StockIniciales
	Private m_listLOG_StockIniciales As List(Of ELOG_StockIniciales)
	Private m_dtLOG_StockIniciales As DataTable

	Private m_dsLOG_StockIniciales As DataSet
	Private d_log_stockiniciales As DLOG_StockIniciales 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_log_stockiniciales = New DLOG_StockIniciales()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property LOG_StockIniciales() As ELOG_StockIniciales 
		Get
			return m_elog_stockiniciales
		End Get
		Set(ByVal value As ELOG_StockIniciales)
			m_elog_stockiniciales = value
		End Set
	End Property

	Public Property ListLOG_StockIniciales() As List(Of ELOG_StockIniciales)
		Get
			return m_listLOG_StockIniciales
		End Get
		Set(ByVal value As List(Of ELOG_StockIniciales))
			m_listLOG_StockIniciales = value
		End Set
	End Property

	Public Property DTLOG_StockIniciales() As DataTable
		Get
			return m_dtLOG_StockIniciales
		End Get
		Set(ByVal value As DataTable)
			m_dtLOG_StockIniciales = value
		End Set
	End Property

	Public Property DSLOG_StockIniciales() As DataSet
		Get
			return m_dsLOG_StockIniciales
		End Get
		Set(ByVal value As DataSet)
			m_dsLOG_StockIniciales = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listLOG_StockIniciales = new List(Of ELOG_StockIniciales)()
			return d_log_stockiniciales.LOG_STINISS_Todos(m_listLOG_StockIniciales)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listLOG_StockIniciales = new List(Of ELOG_StockIniciales)()
			return d_log_stockiniciales.LOG_STINISS_Todos(m_listLOG_StockIniciales, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listLOG_StockIniciales = new List(Of ELOG_StockIniciales)()
			return d_log_stockiniciales.LOG_STINISS_Todos(m_listLOG_StockIniciales, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listLOG_StockIniciales = new List(Of ELOG_StockIniciales)()
			return d_log_stockiniciales.LOG_STINISS_Todos(m_listLOG_StockIniciales, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsLOG_StockIniciales = new DataSet()
			return d_log_stockiniciales.LOG_STINISS_Todos(m_dsLOG_StockIniciales, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsLOG_StockIniciales = new DataSet()
			return d_log_stockiniciales.LOG_STINISS_Todos(m_dsLOG_StockIniciales, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsLOG_StockIniciales = new DataSet()
			Dim _opcion As Boolean = d_log_stockiniciales.LOG_STINISS_Todos(m_dsLOG_StockIniciales, x_where)
		If _opcion Then
			m_dtLOG_StockIniciales = m_dsLOG_StockIniciales.Tables(0)
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
			m_dsLOG_StockIniciales = new DataSet()
			Dim _opcion As Boolean = d_log_stockiniciales.LOG_STINISS_Todos(m_dsLOG_StockIniciales, x_join, x_where)
		If _opcion Then
			m_dtLOG_StockIniciales = m_dsLOG_StockIniciales.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_perio_codigo As String, x_artic_codigo As String) As Boolean
		Try
			m_elog_stockiniciales = New ELOG_StockIniciales()
			Return d_log_stockiniciales.LOG_STINISS_UnReg(m_elog_stockiniciales, x_perio_codigo, x_artic_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_elog_stockiniciales = New ELOG_StockIniciales()
			Return d_log_stockiniciales.LOG_STINISS_UnReg(m_elog_stockiniciales, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_elog_stockiniciales = New ELOG_StockIniciales()
			Return d_log_stockiniciales.LOG_STINISS_UnReg(m_elog_stockiniciales, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_elog_stockiniciales.Nuevo Then
				d_log_stockiniciales.LOG_STINISI_UnReg(m_elog_stockiniciales, x_usuario)
			ElseIf m_elog_stockiniciales.Modificado Then
				d_log_stockiniciales.LOG_STINISU_UnReg(m_elog_stockiniciales, x_usuario)
			ElseIf m_elog_stockiniciales.Eliminado Then
				d_log_stockiniciales.LOG_STINISD_UnReg(LOG_StockIniciales)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_elog_stockiniciales.Nuevo Then
				d_log_stockiniciales.LOG_STINISI_UnReg(m_elog_stockiniciales, x_usuario)
			ElseIf m_elog_stockiniciales.Modificado Then
				d_log_stockiniciales.LOG_STINISU_UnReg(m_elog_stockiniciales, x_where, x_usuario)
			ElseIf m_elog_stockiniciales.Eliminado Then
				d_log_stockiniciales.LOG_STINISD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_elog_stockiniciales.Nuevo Then
				d_log_stockiniciales.LOG_STINISI_UnReg(m_elog_stockiniciales, x_usuario, x_excluir, x_setfecha)
			ElseIf m_elog_stockiniciales.Modificado Then
				d_log_stockiniciales.LOG_STINISU_UnReg(m_elog_stockiniciales, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_elog_stockiniciales.Eliminado Then
				d_log_stockiniciales.LOG_STINISD_UnReg(LOG_StockIniciales)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_elog_stockiniciales.Nuevo Then
				d_log_stockiniciales.LOG_STINISI_UnReg(m_elog_stockiniciales, x_usuario, x_excluir, x_setfecha)
			ElseIf m_elog_stockiniciales.Modificado Then
				d_log_stockiniciales.LOG_STINISU_UnReg(m_elog_stockiniciales, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_elog_stockiniciales.Eliminado Then
				d_log_stockiniciales.LOG_STINISD_UnReg(LOG_StockIniciales)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_elog_stockiniciales.Nuevo Then
				d_log_stockiniciales.LOG_STINISI_UnReg(m_elog_stockiniciales, x_usuario, x_setfecha)
			ElseIf m_elog_stockiniciales.Modificado Then
				d_log_stockiniciales.LOG_STINISU_UnReg(m_elog_stockiniciales, x_usuario, x_setfecha)
			ElseIf m_elog_stockiniciales.Eliminado Then
				d_log_stockiniciales.LOG_STINISD_UnReg(LOG_StockIniciales)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_elog_stockiniciales.Nuevo Then
				d_log_stockiniciales.LOG_STINISI_UnReg(m_elog_stockiniciales, x_usuario, x_excluir, x_setfecha)
			ElseIf m_elog_stockiniciales.Eliminado Then
				d_log_stockiniciales.LOG_STINISD_UnReg(LOG_StockIniciales)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listLOG_StockIniciales = new List(Of ELOG_StockIniciales)()
			return d_log_stockiniciales.LOG_STINISD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_log_stockiniciales.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_log_stockiniciales.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_log_stockiniciales.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_log_stockiniciales.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

