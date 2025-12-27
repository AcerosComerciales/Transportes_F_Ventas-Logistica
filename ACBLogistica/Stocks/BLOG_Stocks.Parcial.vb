Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica

Partial Public Class BLOG_Stocks

#Region " Variables "
	
	Private m_elog_stocks As ELOG_Stocks
	Private m_listLOG_Stocks As List(Of ELOG_Stocks)
	Private m_dtLOG_Stocks As DataTable

	Private m_dsLOG_Stocks As DataSet
	Private d_log_stocks As DLOG_Stocks 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_log_stocks = New DLOG_Stocks()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property LOG_Stocks() As ELOG_Stocks 
		Get
			return m_elog_stocks
		End Get
		Set(ByVal value As ELOG_Stocks)
			m_elog_stocks = value
		End Set
	End Property

	Public Property ListLOG_Stocks() As List(Of ELOG_Stocks)
		Get
			return m_listLOG_Stocks
		End Get
		Set(ByVal value As List(Of ELOG_Stocks))
			m_listLOG_Stocks = value
		End Set
	End Property

	Public Property DTLOG_Stocks() As DataTable
		Get
			return m_dtLOG_Stocks
		End Get
		Set(ByVal value As DataTable)
			m_dtLOG_Stocks = value
		End Set
	End Property

	Public Property DSLOG_Stocks() As DataSet
		Get
			return m_dsLOG_Stocks
		End Get
		Set(ByVal value As DataSet)
			m_dsLOG_Stocks = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listLOG_Stocks = new List(Of ELOG_Stocks)()
			return d_log_stocks.LOG_STOCKSS_Todos(m_listLOG_Stocks)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listLOG_Stocks = new List(Of ELOG_Stocks)()
			return d_log_stocks.LOG_STOCKSS_Todos(m_listLOG_Stocks, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listLOG_Stocks = new List(Of ELOG_Stocks)()
			return d_log_stocks.LOG_STOCKSS_Todos(m_listLOG_Stocks, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listLOG_Stocks = new List(Of ELOG_Stocks)()
			return d_log_stocks.LOG_STOCKSS_Todos(m_listLOG_Stocks, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_almac_id As Short) As Boolean
		Try
			m_elog_stocks = New ELOG_Stocks()
			Return d_log_stocks.LOG_STOCKSS_Todos(m_elog_stocks, x_almac_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsLOG_Stocks = new DataSet()
			return d_log_stocks.LOG_STOCKSS_Todos(m_dsLOG_Stocks, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsLOG_Stocks = new DataSet()
			return d_log_stocks.LOG_STOCKSS_Todos(m_dsLOG_Stocks, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsLOG_Stocks = new DataSet()
			Dim _opcion As Boolean = d_log_stocks.LOG_STOCKSS_Todos(m_dsLOG_Stocks, x_where)
		If _opcion Then
			m_dtLOG_Stocks = m_dsLOG_Stocks.Tables(0)
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
			m_dsLOG_Stocks = new DataSet()
			Dim _opcion As Boolean = d_log_stocks.LOG_STOCKSS_Todos(m_dsLOG_Stocks, x_join, x_where)
		If _opcion Then
			m_dtLOG_Stocks = m_dsLOG_Stocks.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_stock_id As Long, x_almac_id As Short) As Boolean
		Try
			m_elog_stocks = New ELOG_Stocks()
			Return d_log_stocks.LOG_STOCKSS_UnReg(m_elog_stocks, x_stock_id, x_almac_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_elog_stocks = New ELOG_Stocks()
			Return d_log_stocks.LOG_STOCKSS_UnReg(m_elog_stocks, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_elog_stocks = New ELOG_Stocks()
			Return d_log_stocks.LOG_STOCKSS_UnReg(m_elog_stocks, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_elog_stocks.Nuevo Then
				d_log_stocks.LOG_STOCKSI_UnReg(m_elog_stocks, x_usuario)
			ElseIf m_elog_stocks.Modificado Then
				d_log_stocks.LOG_STOCKSU_UnReg(m_elog_stocks, x_usuario)
			ElseIf m_elog_stocks.Eliminado Then
				d_log_stocks.LOG_STOCKSD_UnReg(LOG_Stocks)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_elog_stocks.Nuevo Then
				d_log_stocks.LOG_STOCKSI_UnReg(m_elog_stocks, x_usuario)
			ElseIf m_elog_stocks.Modificado Then
				d_log_stocks.LOG_STOCKSU_UnReg(m_elog_stocks, x_where, x_usuario)
			ElseIf m_elog_stocks.Eliminado Then
				d_log_stocks.LOG_STOCKSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_elog_stocks.Nuevo Then
				d_log_stocks.LOG_STOCKSI_UnReg(m_elog_stocks, x_usuario, x_excluir, x_setfecha)
			ElseIf m_elog_stocks.Modificado Then
				d_log_stocks.LOG_STOCKSU_UnReg(m_elog_stocks, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_elog_stocks.Eliminado Then
				d_log_stocks.LOG_STOCKSD_UnReg(LOG_Stocks)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_elog_stocks.Nuevo Then
				d_log_stocks.LOG_STOCKSI_UnReg(m_elog_stocks, x_usuario, x_excluir, x_setfecha)
			ElseIf m_elog_stocks.Modificado Then
				d_log_stocks.LOG_STOCKSU_UnReg(m_elog_stocks, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_elog_stocks.Eliminado Then
				d_log_stocks.LOG_STOCKSD_UnReg(LOG_Stocks)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_elog_stocks.Nuevo Then
				d_log_stocks.LOG_STOCKSI_UnReg(m_elog_stocks, x_usuario, x_setfecha)
			ElseIf m_elog_stocks.Modificado Then
				d_log_stocks.LOG_STOCKSU_UnReg(m_elog_stocks, x_usuario, x_setfecha)
			ElseIf m_elog_stocks.Eliminado Then
				d_log_stocks.LOG_STOCKSD_UnReg(LOG_Stocks)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_elog_stocks.Nuevo Then
				d_log_stocks.LOG_STOCKSI_UnReg(m_elog_stocks, x_usuario, x_excluir, x_setfecha)
			ElseIf m_elog_stocks.Eliminado Then
				d_log_stocks.LOG_STOCKSD_UnReg(LOG_Stocks)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listLOG_Stocks = new List(Of ELOG_Stocks)()
			return d_log_stocks.LOG_STOCKSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_log_stocks.getCorrelativo("STOCK_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_log_stocks.getCorrelativo("STOCK_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_log_stocks.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_log_stocks.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_log_stocks.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_log_stocks.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

