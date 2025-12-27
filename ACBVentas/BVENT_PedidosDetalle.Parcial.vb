Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BVENT_PedidosDetalle

#Region " Variables "
	
	Private m_vent_pedidosdetalle As EVENT_PedidosDetalle
	Private m_listVENT_PedidosDetalle As List(Of EVENT_PedidosDetalle)
	Private m_dtVENT_PedidosDetalle As DataTable

	Private m_dsVENT_PedidosDetalle As DataSet
	Private d_vent_pedidosdetalle As DVENT_PedidosDetalle 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_vent_pedidosdetalle = New DVENT_PedidosDetalle()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property VENT_PedidosDetalle() As EVENT_PedidosDetalle 
		Get
			return m_vent_pedidosdetalle
		End Get
		Set(ByVal value As EVENT_PedidosDetalle)
			m_vent_pedidosdetalle = value
		End Set
	End Property
	Public Property ListVENT_PedidosDetalle() As List(Of EVENT_PedidosDetalle)
		Get
			return m_listVENT_PedidosDetalle
		End Get
		Set(ByVal value As List(Of EVENT_PedidosDetalle))
			m_listVENT_PedidosDetalle = value
		End Set
	End Property
	Public Property DTVENT_PedidosDetalle() As DataTable
		Get
			return m_dtVENT_PedidosDetalle
		End Get
		Set(ByVal value As DataTable)
			m_dtVENT_PedidosDetalle = value
		End Set
	End Property
	Public Property DSVENT_PedidosDetalle() As DataSet
		Get
			return m_dsVENT_PedidosDetalle
		End Get
		Set(ByVal value As DataSet)
			m_dsVENT_PedidosDetalle = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListVENT_PedidosDetalle() As List(Of EVENT_PedidosDetalle)
			Return Me.m_listVENT_PedidosDetalle
		End Function
		Public Sub setListVENT_PedidosDetalle(ByVal _listvent_pedidosdetalle As List (Of EVENT_PedidosDetalle))
			Me.m_listVENT_PedidosDetalle = m_listvent_pedidosdetalle 
		End Sub
		Public Function getVENT_PedidosDetalle() As EVENT_PedidosDetalle
			Return Me.m_vent_pedidosdetalle
		End Function
		Public Sub setVENT_PedidosDetalle(ByVal x_vent_pedidosdetalle As EVENT_PedidosDetalle)
			Me.m_vent_pedidosdetalle = x_vent_pedidosdetalle 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listVENT_PedidosDetalle = new List(Of EVENT_PedidosDetalle)()
			return d_vent_pedidosdetalle.VENT_PDDETSS_Todos(m_listVENT_PedidosDetalle)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_PedidosDetalle = new List(Of EVENT_PedidosDetalle)()
			return d_vent_pedidosdetalle.VENT_PDDETSS_Todos(m_listVENT_PedidosDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_PedidosDetalle = new List(Of EVENT_PedidosDetalle)()
			return d_vent_pedidosdetalle.VENT_PDDETSS_Todos(m_listVENT_PedidosDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listVENT_PedidosDetalle = new List(Of EVENT_PedidosDetalle)()
			return d_vent_pedidosdetalle.VENT_PDDETSS_Todos(m_listVENT_PedidosDetalle, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_pedid_codigo As String) As Boolean
		Try
			m_listVENT_PedidosDetalle = new List(Of EVENT_PedidosDetalle)()
			Return d_vent_pedidosdetalle.VENT_PDDETSS_Todos(m_listVENT_PedidosDetalle, x_pedid_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_PedidosDetalle = new DataSet()
			return d_vent_pedidosdetalle.VENT_PDDETSS_Todos(m_dsVENT_PedidosDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_PedidosDetalle = new DataSet()
			return d_vent_pedidosdetalle.VENT_PDDETSS_Todos(m_dsVENT_PedidosDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_PedidosDetalle = new DataSet()
			Dim _opcion As Boolean = d_vent_pedidosdetalle.VENT_PDDETSS_Todos(m_dsVENT_PedidosDetalle, x_where)
		If _opcion Then
			m_dtVENT_PedidosDetalle = m_dsVENT_PedidosDetalle.Tables(0)
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
			m_dsVENT_PedidosDetalle = new DataSet()
			Dim _opcion As Boolean = d_vent_pedidosdetalle.VENT_PDDETSS_Todos(m_dsVENT_PedidosDetalle, x_join, x_where)
		If _opcion Then
			m_dtVENT_PedidosDetalle = m_dsVENT_PedidosDetalle.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_pedid_codigo As String, x_pddet_item As Short) As Boolean
		Try
			m_vent_pedidosdetalle = New EVENT_PedidosDetalle()
			Return d_vent_pedidosdetalle.VENT_PDDETSS_UnReg(m_vent_pedidosdetalle, x_pedid_codigo, x_pddet_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_vent_pedidosdetalle = New EVENT_PedidosDetalle()
			Return d_vent_pedidosdetalle.VENT_PDDETSS_UnReg(m_vent_pedidosdetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_vent_pedidosdetalle = New EVENT_PedidosDetalle()
			Return d_vent_pedidosdetalle.VENT_PDDETSS_UnReg(m_vent_pedidosdetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_vent_pedidosdetalle.Nuevo Then
				d_vent_pedidosdetalle.VENT_PDDETSI_UnReg(m_vent_pedidosdetalle, x_usuario)
			ElseIf m_vent_pedidosdetalle.Modificado Then
				d_vent_pedidosdetalle.VENT_PDDETSU_UnReg(m_vent_pedidosdetalle, x_usuario)
			ElseIf m_vent_pedidosdetalle.Eliminado Then
				d_vent_pedidosdetalle.VENT_PDDETSD_UnReg(m_vent_pedidosdetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_vent_pedidosdetalle.Nuevo Then
				d_vent_pedidosdetalle.VENT_PDDETSI_UnReg(m_vent_pedidosdetalle, x_usuario)
			ElseIf m_vent_pedidosdetalle.Modificado Then
				d_vent_pedidosdetalle.VENT_PDDETSU_UnReg(m_vent_pedidosdetalle, x_where, x_usuario)
			ElseIf m_vent_pedidosdetalle.Eliminado Then
				d_vent_pedidosdetalle.VENT_PDDETSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_pedidosdetalle.Nuevo Then
				d_vent_pedidosdetalle.VENT_PDDETSI_UnReg(m_vent_pedidosdetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_pedidosdetalle.Modificado Then
				d_vent_pedidosdetalle.VENT_PDDETSU_UnReg(m_vent_pedidosdetalle, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_pedidosdetalle.Eliminado Then
				d_vent_pedidosdetalle.VENT_PDDETSD_UnReg(m_vent_pedidosdetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_vent_pedidosdetalle.Nuevo Then
				d_vent_pedidosdetalle.VENT_PDDETSI_UnReg(m_vent_pedidosdetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_pedidosdetalle.Modificado Then
				d_vent_pedidosdetalle.VENT_PDDETSU_UnReg(m_vent_pedidosdetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_vent_pedidosdetalle.Eliminado Then
				d_vent_pedidosdetalle.VENT_PDDETSD_UnReg(m_vent_pedidosdetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_pedidosdetalle.Nuevo Then
				d_vent_pedidosdetalle.VENT_PDDETSI_UnReg(m_vent_pedidosdetalle, x_usuario, x_setfecha)
			ElseIf m_vent_pedidosdetalle.Modificado Then
				d_vent_pedidosdetalle.VENT_PDDETSU_UnReg(m_vent_pedidosdetalle, x_usuario, x_setfecha)
			ElseIf m_vent_pedidosdetalle.Eliminado Then
				d_vent_pedidosdetalle.VENT_PDDETSD_UnReg(m_vent_pedidosdetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_pedidosdetalle.Nuevo Then
				d_vent_pedidosdetalle.VENT_PDDETSI_UnReg(m_vent_pedidosdetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_pedidosdetalle.Eliminado Then
				d_vent_pedidosdetalle.VENT_PDDETSD_UnReg(m_vent_pedidosdetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_PedidosDetalle = new List(Of EVENT_PedidosDetalle)()
			return d_vent_pedidosdetalle.VENT_PDDETSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_vent_pedidosdetalle.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_vent_pedidosdetalle.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_vent_pedidosdetalle.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_vent_pedidosdetalle.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

