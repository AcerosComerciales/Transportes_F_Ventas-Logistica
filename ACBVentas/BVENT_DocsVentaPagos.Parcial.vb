Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BVENT_DocsVentaPagos

#Region " Variables "
	
	Private m_event_docsventapagos As EVENT_DocsVentaPagos
	Private m_listVENT_DocsVentaPagos As List(Of EVENT_DocsVentaPagos)
	Private m_dtVENT_DocsVentaPagos As DataTable

	Private m_dsVENT_DocsVentaPagos As DataSet
	Private d_vent_docsventapagos As DVENT_DocsVentaPagos 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_vent_docsventapagos = New DVENT_DocsVentaPagos()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property VENT_DocsVentaPagos() As EVENT_DocsVentaPagos 
		Get
			return m_event_docsventapagos
		End Get
		Set(ByVal value As EVENT_DocsVentaPagos)
			m_event_docsventapagos = value
		End Set
	End Property

	Public Property ListVENT_DocsVentaPagos() As List(Of EVENT_DocsVentaPagos)
		Get
			return m_listVENT_DocsVentaPagos
		End Get
		Set(ByVal value As List(Of EVENT_DocsVentaPagos))
			m_listVENT_DocsVentaPagos = value
		End Set
	End Property

	Public Property DTVENT_DocsVentaPagos() As DataTable
		Get
			return m_dtVENT_DocsVentaPagos
		End Get
		Set(ByVal value As DataTable)
			m_dtVENT_DocsVentaPagos = value
		End Set
	End Property

	Public Property DSVENT_DocsVentaPagos() As DataSet
		Get
			return m_dsVENT_DocsVentaPagos
		End Get
		Set(ByVal value As DataSet)
			m_dsVENT_DocsVentaPagos = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listVENT_DocsVentaPagos = new List(Of EVENT_DocsVentaPagos)()
			return d_vent_docsventapagos.VENT_VENTSS_Todos(m_listVENT_DocsVentaPagos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_DocsVentaPagos = new List(Of EVENT_DocsVentaPagos)()
			return d_vent_docsventapagos.VENT_VENTSS_Todos(m_listVENT_DocsVentaPagos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_DocsVentaPagos = new List(Of EVENT_DocsVentaPagos)()
			return d_vent_docsventapagos.VENT_VENTSS_Todos(m_listVENT_DocsVentaPagos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listVENT_DocsVentaPagos = new List(Of EVENT_DocsVentaPagos)()
			return d_vent_docsventapagos.VENT_VENTSS_Todos(m_listVENT_DocsVentaPagos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_DocsVentaPagos = new DataSet()
			return d_vent_docsventapagos.VENT_VENTSS_Todos(m_dsVENT_DocsVentaPagos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_DocsVentaPagos = new DataSet()
			return d_vent_docsventapagos.VENT_VENTSS_Todos(m_dsVENT_DocsVentaPagos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_DocsVentaPagos = new DataSet()
			Dim _opcion As Boolean = d_vent_docsventapagos.VENT_VENTSS_Todos(m_dsVENT_DocsVentaPagos, x_where)
		If _opcion Then
			m_dtVENT_DocsVentaPagos = m_dsVENT_DocsVentaPagos.Tables(0)
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
			m_dsVENT_DocsVentaPagos = new DataSet()
			Dim _opcion As Boolean = d_vent_docsventapagos.VENT_VENTSS_Todos(m_dsVENT_DocsVentaPagos, x_join, x_where)
		If _opcion Then
			m_dtVENT_DocsVentaPagos = m_dsVENT_DocsVentaPagos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_event_docsventapagos.Nuevo Then
				d_vent_docsventapagos.VENT_VENTSI_UnReg(m_event_docsventapagos, x_usuario)
			ElseIf m_event_docsventapagos.Eliminado Then
				d_vent_docsventapagos.VENT_VENTSD_UnReg(VENT_DocsVentaPagos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_event_docsventapagos.Nuevo Then
				d_vent_docsventapagos.VENT_VENTSI_UnReg(m_event_docsventapagos, x_usuario)
			ElseIf m_event_docsventapagos.Eliminado Then
				d_vent_docsventapagos.VENT_VENTSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_event_docsventapagos.Nuevo Then
				d_vent_docsventapagos.VENT_VENTSI_UnReg(m_event_docsventapagos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_event_docsventapagos.Eliminado Then
				d_vent_docsventapagos.VENT_VENTSD_UnReg(VENT_DocsVentaPagos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_event_docsventapagos.Nuevo Then
				d_vent_docsventapagos.VENT_VENTSI_UnReg(m_event_docsventapagos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_event_docsventapagos.Eliminado Then
				d_vent_docsventapagos.VENT_VENTSD_UnReg(VENT_DocsVentaPagos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_event_docsventapagos.Nuevo Then
				d_vent_docsventapagos.VENT_VENTSI_UnReg(m_event_docsventapagos, x_usuario, x_setfecha)
			ElseIf m_event_docsventapagos.Eliminado Then
				d_vent_docsventapagos.VENT_VENTSD_UnReg(VENT_DocsVentaPagos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_event_docsventapagos.Nuevo Then
				d_vent_docsventapagos.VENT_VENTSI_UnReg(m_event_docsventapagos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_event_docsventapagos.Eliminado Then
				d_vent_docsventapagos.VENT_VENTSD_UnReg(VENT_DocsVentaPagos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_DocsVentaPagos = new List(Of EVENT_DocsVentaPagos)()
			return d_vent_docsventapagos.VENT_VENTSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_vent_docsventapagos.getCorrelativo("PVENT_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_vent_docsventapagos.getCorrelativo("PVENT_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_vent_docsventapagos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_vent_docsventapagos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_vent_docsventapagos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_vent_docsventapagos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

