Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BVENT_Pedidos

#Region " Variables "
	
	Private m_event_pedidos As EVENT_Pedidos
	Private m_listVENT_Pedidos As List(Of EVENT_Pedidos)
	Private m_dtVENT_Pedidos As DataTable

	Private m_dsVENT_Pedidos As DataSet
	Private d_vent_pedidos As DVENT_Pedidos 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_vent_pedidos = New DVENT_Pedidos()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property VENT_Pedidos() As EVENT_Pedidos 
		Get
			return m_event_pedidos
		End Get
		Set(ByVal value As EVENT_Pedidos)
			m_event_pedidos = value
		End Set
	End Property

	Public Property ListVENT_Pedidos() As List(Of EVENT_Pedidos)
		Get
			return m_listVENT_Pedidos
		End Get
		Set(ByVal value As List(Of EVENT_Pedidos))
			m_listVENT_Pedidos = value
		End Set
	End Property

	Public Property DTVENT_Pedidos() As DataTable
		Get
			return m_dtVENT_Pedidos
		End Get
		Set(ByVal value As DataTable)
			m_dtVENT_Pedidos = value
		End Set
	End Property

	Public Property DSVENT_Pedidos() As DataSet
		Get
			return m_dsVENT_Pedidos
		End Get
		Set(ByVal value As DataSet)
			m_dsVENT_Pedidos = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listVENT_Pedidos = new List(Of EVENT_Pedidos)()
			return d_vent_pedidos.VENT_PEDIDSS_Todos(m_listVENT_Pedidos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_Pedidos = new List(Of EVENT_Pedidos)()
			return d_vent_pedidos.VENT_PEDIDSS_Todos(m_listVENT_Pedidos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_Pedidos = new List(Of EVENT_Pedidos)()
			return d_vent_pedidos.VENT_PEDIDSS_Todos(m_listVENT_Pedidos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listVENT_Pedidos = new List(Of EVENT_Pedidos)()
			return d_vent_pedidos.VENT_PEDIDSS_Todos(m_listVENT_Pedidos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_Pedidos = new DataSet()
			return d_vent_pedidos.VENT_PEDIDSS_Todos(m_dsVENT_Pedidos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_Pedidos = new DataSet()
			return d_vent_pedidos.VENT_PEDIDSS_Todos(m_dsVENT_Pedidos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_Pedidos = new DataSet()
			Dim _opcion As Boolean = d_vent_pedidos.VENT_PEDIDSS_Todos(m_dsVENT_Pedidos, x_where)
		If _opcion Then
			m_dtVENT_Pedidos = m_dsVENT_Pedidos.Tables(0)
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
			m_dsVENT_Pedidos = new DataSet()
			Dim _opcion As Boolean = d_vent_pedidos.VENT_PEDIDSS_Todos(m_dsVENT_Pedidos, x_join, x_where)
		If _opcion Then
			m_dtVENT_Pedidos = m_dsVENT_Pedidos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_pedid_codigo As String) As Boolean
		Try
			m_event_pedidos = New EVENT_Pedidos()
			Return d_vent_pedidos.VENT_PEDIDSS_UnReg(m_event_pedidos, x_pedid_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_event_pedidos = New EVENT_Pedidos()
			Return d_vent_pedidos.VENT_PEDIDSS_UnReg(m_event_pedidos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_event_pedidos = New EVENT_Pedidos()
			Return d_vent_pedidos.VENT_PEDIDSS_UnReg(m_event_pedidos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_event_pedidos.Nuevo Then
				d_vent_pedidos.VENT_PEDIDSI_UnReg(m_event_pedidos, x_usuario)
			ElseIf m_event_pedidos.Modificado Then
				d_vent_pedidos.VENT_PEDIDSU_UnReg(m_event_pedidos, x_usuario)
			ElseIf m_event_pedidos.Eliminado Then
				d_vent_pedidos.VENT_PEDIDSD_UnReg(VENT_Pedidos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_event_pedidos.Nuevo Then
				d_vent_pedidos.VENT_PEDIDSI_UnReg(m_event_pedidos, x_usuario)
			ElseIf m_event_pedidos.Modificado Then
				d_vent_pedidos.VENT_PEDIDSU_UnReg(m_event_pedidos, x_where, x_usuario)
			ElseIf m_event_pedidos.Eliminado Then
				d_vent_pedidos.VENT_PEDIDSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_event_pedidos.Nuevo Then
				d_vent_pedidos.VENT_PEDIDSI_UnReg(m_event_pedidos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_event_pedidos.Modificado Then
				d_vent_pedidos.VENT_PEDIDSU_UnReg(m_event_pedidos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_event_pedidos.Eliminado Then
				d_vent_pedidos.VENT_PEDIDSD_UnReg(VENT_Pedidos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_event_pedidos.Nuevo Then
				d_vent_pedidos.VENT_PEDIDSI_UnReg(m_event_pedidos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_event_pedidos.Modificado Then
				d_vent_pedidos.VENT_PEDIDSU_UnReg(m_event_pedidos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_event_pedidos.Eliminado Then
				d_vent_pedidos.VENT_PEDIDSD_UnReg(VENT_Pedidos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_event_pedidos.Nuevo Then
				d_vent_pedidos.VENT_PEDIDSI_UnReg(m_event_pedidos, x_usuario, x_setfecha)
			ElseIf m_event_pedidos.Modificado Then
				d_vent_pedidos.VENT_PEDIDSU_UnReg(m_event_pedidos, x_usuario, x_setfecha)
			ElseIf m_event_pedidos.Eliminado Then
				d_vent_pedidos.VENT_PEDIDSD_UnReg(VENT_Pedidos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_event_pedidos.Nuevo Then
				d_vent_pedidos.VENT_PEDIDSI_UnReg(m_event_pedidos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_event_pedidos.Eliminado Then
				d_vent_pedidos.VENT_PEDIDSD_UnReg(VENT_Pedidos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_Pedidos = new List(Of EVENT_Pedidos)()
			return d_vent_pedidos.VENT_PEDIDSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_vent_pedidos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

    Public Function getPV(ByVal x_campo As String) As String
		Try
			Return d_vent_pedidos.getPV(x_campo) 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

        Public Function getOrdenCorte(ByVal x_campo As String) As String
		Try
			Return d_vent_pedidos.getOC(x_campo) 
		Catch ex As Exception
			Throw ex
		End Try
	End Function


    Public Function getTPD(ByVal x_campo As String) As string
		Try
			Return d_vent_pedidos.getTPD(x_campo) 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_vent_pedidos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_vent_pedidos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_vent_pedidos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

