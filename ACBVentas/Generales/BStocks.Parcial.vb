Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BStocks

#Region " Variables "
	
	Private m_stocks As EStocks
	Private m_listStocks As List(Of EStocks)
	Private m_dtStocks As DataTable

	Private m_dsStocks As DataSet
	Private d_stocks As DStocks 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_stocks = New DStocks()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Stocks() As EStocks 
		Get
			return m_stocks
		End Get
		Set(ByVal value As EStocks)
			m_stocks = value
		End Set
	End Property
	Public Property ListStocks() As List(Of EStocks)
		Get
			return m_listStocks
		End Get
		Set(ByVal value As List(Of EStocks))
			m_listStocks = value
		End Set
	End Property
	Public Property DTStocks() As DataTable
		Get
			return m_dtStocks
		End Get
		Set(ByVal value As DataTable)
			m_dtStocks = value
		End Set
	End Property
	Public Property DSStocks() As DataSet
		Get
			return m_dsStocks
		End Get
		Set(ByVal value As DataSet)
			m_dsStocks = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListStocks() As List(Of EStocks)
			Return Me.m_listStocks
		End Function
		Public Sub setListStocks(ByVal _liststocks As List (Of EStocks))
			Me.m_listStocks = m_liststocks 
		End Sub
		Public Function getStocks() As EStocks
			Return Me.m_stocks
		End Function
		Public Sub setStocks(ByVal x_stocks As EStocks)
			Me.m_stocks = x_stocks 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listStocks = new List(Of EStocks)()
			return d_stocks.STOCKSS_Todos(m_listStocks)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listStocks = new List(Of EStocks)()
			return d_stocks.STOCKSS_Todos(m_listStocks, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listStocks = new List(Of EStocks)()
			return d_stocks.STOCKSS_Todos(m_listStocks, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listStocks = new List(Of EStocks)()
			return d_stocks.STOCKSS_Todos(m_listStocks, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsStocks = new DataSet()
			return d_stocks.STOCKSS_Todos(m_dsStocks, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsStocks = new DataSet()
			return d_stocks.STOCKSS_Todos(m_dsStocks, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsStocks = new DataSet()
			Dim _opcion As Boolean = d_stocks.STOCKSS_Todos(m_dsStocks, x_where)
		If _opcion Then
			m_dtStocks = m_dsStocks.Tables(0)
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
			m_dsStocks = new DataSet()
			Dim _opcion As Boolean = d_stocks.STOCKSS_Todos(m_dsStocks, x_join, x_where)
		If _opcion Then
			m_dtStocks = m_dsStocks.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_artic_codigo As String, x_almac_id As Short) As Boolean
		Try
			m_stocks = New EStocks()
			Return d_stocks.STOCKSS_UnReg(m_stocks, x_artic_codigo, x_almac_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_stocks = New EStocks()
			Return d_stocks.STOCKSS_UnReg(m_stocks, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_stocks = New EStocks()
			Return d_stocks.STOCKSS_UnReg(m_stocks, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_stocks.Nuevo Then
				d_stocks.STOCKSI_UnReg(m_stocks, x_usuario)
			ElseIf m_stocks.Modificado Then
				d_stocks.STOCKSU_UnReg(m_stocks, x_usuario)
			ElseIf m_stocks.Eliminado Then
				d_stocks.STOCKSD_UnReg(m_stocks)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_stocks.Nuevo Then
				d_stocks.STOCKSI_UnReg(m_stocks, x_usuario)
			ElseIf m_stocks.Modificado Then
				d_stocks.STOCKSU_UnReg(m_stocks, x_where, x_usuario)
			ElseIf m_stocks.Eliminado Then
				d_stocks.STOCKSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_stocks.Nuevo Then
				d_stocks.STOCKSI_UnReg(m_stocks, x_usuario, x_excluir, x_setfecha)
			ElseIf m_stocks.Modificado Then
				d_stocks.STOCKSU_UnReg(m_stocks, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_stocks.Eliminado Then
				d_stocks.STOCKSD_UnReg(m_stocks)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_stocks.Nuevo Then
				d_stocks.STOCKSI_UnReg(m_stocks, x_usuario, x_excluir, x_setfecha)
			ElseIf m_stocks.Modificado Then
				d_stocks.STOCKSU_UnReg(m_stocks, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_stocks.Eliminado Then
				d_stocks.STOCKSD_UnReg(m_stocks)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_stocks.Nuevo Then
				d_stocks.STOCKSI_UnReg(m_stocks, x_usuario, x_setfecha)
			ElseIf m_stocks.Modificado Then
				d_stocks.STOCKSU_UnReg(m_stocks, x_usuario, x_setfecha)
			ElseIf m_stocks.Eliminado Then
				d_stocks.STOCKSD_UnReg(m_stocks)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_stocks.Nuevo Then
				d_stocks.STOCKSI_UnReg(m_stocks, x_usuario, x_excluir, x_setfecha)
			ElseIf m_stocks.Eliminado Then
				d_stocks.STOCKSD_UnReg(m_stocks)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listStocks = new List(Of EStocks)()
			return d_stocks.STOCKSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_stocks.getCorrelativo("ALMAC_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_stocks.getCorrelativo("ALMAC_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_stocks.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_stocks.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_stocks.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_stocks.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

