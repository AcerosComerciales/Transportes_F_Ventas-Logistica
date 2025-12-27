Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BVENT_PVentDocumento

#Region " Variables "
	
	Private m_vent_pventdocumento As EVENT_PVentDocumento
	Private m_listVENT_PVentDocumento As List(Of EVENT_PVentDocumento)
	Private m_dtVENT_PVentDocumento As DataTable

	Private m_dsVENT_PVentDocumento As DataSet
	Private d_vent_pventdocumento As DVENT_PVentDocumento 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_vent_pventdocumento = New DVENT_PVentDocumento()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property VENT_PVentDocumento() As EVENT_PVentDocumento 
		Get
			return m_vent_pventdocumento
		End Get
		Set(ByVal value As EVENT_PVentDocumento)
			m_vent_pventdocumento = value
		End Set
	End Property
	Public Property ListVENT_PVentDocumento() As List(Of EVENT_PVentDocumento)
		Get
			return m_listVENT_PVentDocumento
		End Get
		Set(ByVal value As List(Of EVENT_PVentDocumento))
			m_listVENT_PVentDocumento = value
		End Set
	End Property
	Public Property DTVENT_PVentDocumento() As DataTable
		Get
			return m_dtVENT_PVentDocumento
		End Get
		Set(ByVal value As DataTable)
			m_dtVENT_PVentDocumento = value
		End Set
	End Property
	Public Property DSVENT_PVentDocumento() As DataSet
		Get
			return m_dsVENT_PVentDocumento
		End Get
		Set(ByVal value As DataSet)
			m_dsVENT_PVentDocumento = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListVENT_PVentDocumento() As List(Of EVENT_PVentDocumento)
			Return Me.m_listVENT_PVentDocumento
		End Function
		Public Sub setListVENT_PVentDocumento(ByVal _listvent_pventdocumento As List (Of EVENT_PVentDocumento))
			Me.m_listVENT_PVentDocumento = m_listvent_pventdocumento 
		End Sub
		Public Function getVENT_PVentDocumento() As EVENT_PVentDocumento
			Return Me.m_vent_pventdocumento
		End Function
		Public Sub setVENT_PVentDocumento(ByVal x_vent_pventdocumento As EVENT_PVentDocumento)
			Me.m_vent_pventdocumento = x_vent_pventdocumento 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listVENT_PVentDocumento = new List(Of EVENT_PVentDocumento)()
			return d_vent_pventdocumento.VENT_PVDOCUSS_Todos(m_listVENT_PVentDocumento)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_PVentDocumento = new List(Of EVENT_PVentDocumento)()
			return d_vent_pventdocumento.VENT_PVDOCUSS_Todos(m_listVENT_PVentDocumento, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_PVentDocumento = new List(Of EVENT_PVentDocumento)()
			return d_vent_pventdocumento.VENT_PVDOCUSS_Todos(m_listVENT_PVentDocumento, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listVENT_PVentDocumento = new List(Of EVENT_PVentDocumento)()
			return d_vent_pventdocumento.VENT_PVDOCUSS_Todos(m_listVENT_PVentDocumento, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_PVentDocumento = new DataSet()
			return d_vent_pventdocumento.VENT_PVDOCUSS_Todos(m_dsVENT_PVentDocumento, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_PVentDocumento = new DataSet()
			return d_vent_pventdocumento.VENT_PVDOCUSS_Todos(m_dsVENT_PVentDocumento, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_PVentDocumento = new DataSet()
			Dim _opcion As Boolean = d_vent_pventdocumento.VENT_PVDOCUSS_Todos(m_dsVENT_PVentDocumento, x_where)
		If _opcion Then
			m_dtVENT_PVentDocumento = m_dsVENT_PVentDocumento.Tables(0)
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
			m_dsVENT_PVentDocumento = new DataSet()
			Dim _opcion As Boolean = d_vent_pventdocumento.VENT_PVDOCUSS_Todos(m_dsVENT_PVentDocumento, x_join, x_where)
		If _opcion Then
			m_dtVENT_PVentDocumento = m_dsVENT_PVentDocumento.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_pvdocu_id As Long) As Boolean
		Try
			m_vent_pventdocumento = New EVENT_PVentDocumento()
			Return d_vent_pventdocumento.VENT_PVDOCUSS_UnReg(m_vent_pventdocumento, x_pvdocu_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_vent_pventdocumento = New EVENT_PVentDocumento()
			Return d_vent_pventdocumento.VENT_PVDOCUSS_UnReg(m_vent_pventdocumento, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_vent_pventdocumento = New EVENT_PVentDocumento()
			Return d_vent_pventdocumento.VENT_PVDOCUSS_UnReg(m_vent_pventdocumento, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_vent_pventdocumento.Nuevo Then
				d_vent_pventdocumento.VENT_PVDOCUSI_UnReg(m_vent_pventdocumento, x_usuario)
			ElseIf m_vent_pventdocumento.Modificado Then
				d_vent_pventdocumento.VENT_PVDOCUSU_UnReg(m_vent_pventdocumento, x_usuario)
			ElseIf m_vent_pventdocumento.Eliminado Then
				d_vent_pventdocumento.VENT_PVDOCUSD_UnReg(m_vent_pventdocumento)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_vent_pventdocumento.Nuevo Then
				d_vent_pventdocumento.VENT_PVDOCUSI_UnReg(m_vent_pventdocumento, x_usuario)
			ElseIf m_vent_pventdocumento.Modificado Then
				d_vent_pventdocumento.VENT_PVDOCUSU_UnReg(m_vent_pventdocumento, x_where, x_usuario)
			ElseIf m_vent_pventdocumento.Eliminado Then
				d_vent_pventdocumento.VENT_PVDOCUSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_pventdocumento.Nuevo Then
				d_vent_pventdocumento.VENT_PVDOCUSI_UnReg(m_vent_pventdocumento, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_pventdocumento.Modificado Then
				d_vent_pventdocumento.VENT_PVDOCUSU_UnReg(m_vent_pventdocumento, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_pventdocumento.Eliminado Then
				d_vent_pventdocumento.VENT_PVDOCUSD_UnReg(m_vent_pventdocumento)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_vent_pventdocumento.Nuevo Then
				d_vent_pventdocumento.VENT_PVDOCUSI_UnReg(m_vent_pventdocumento, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_pventdocumento.Modificado Then
				d_vent_pventdocumento.VENT_PVDOCUSU_UnReg(m_vent_pventdocumento, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_vent_pventdocumento.Eliminado Then
				d_vent_pventdocumento.VENT_PVDOCUSD_UnReg(m_vent_pventdocumento)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_pventdocumento.Nuevo Then
				d_vent_pventdocumento.VENT_PVDOCUSI_UnReg(m_vent_pventdocumento, x_usuario, x_setfecha)
			ElseIf m_vent_pventdocumento.Modificado Then
				d_vent_pventdocumento.VENT_PVDOCUSU_UnReg(m_vent_pventdocumento, x_usuario, x_setfecha)
			ElseIf m_vent_pventdocumento.Eliminado Then
				d_vent_pventdocumento.VENT_PVDOCUSD_UnReg(m_vent_pventdocumento)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_pventdocumento.Nuevo Then
				d_vent_pventdocumento.VENT_PVDOCUSI_UnReg(m_vent_pventdocumento, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_pventdocumento.Eliminado Then
				d_vent_pventdocumento.VENT_PVDOCUSD_UnReg(m_vent_pventdocumento)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_PVentDocumento = new List(Of EVENT_PVentDocumento)()
			return d_vent_pventdocumento.VENT_PVDOCUSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_vent_pventdocumento.getCorrelativo("PVDOCU_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_vent_pventdocumento.getCorrelativo("PVDOCU_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_vent_pventdocumento.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_vent_pventdocumento.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_vent_pventdocumento.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_vent_pventdocumento.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

