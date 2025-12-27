Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BVENT_DocsRelacion

#Region " Variables "
	
	Private m_event_docsrelacion As EVENT_DocsRelacion
	Private m_listVENT_DocsRelacion As List(Of EVENT_DocsRelacion)
	Private m_dtVENT_DocsRelacion As DataTable

	Private m_dsVENT_DocsRelacion As DataSet
	Private d_vent_docsrelacion As DVENT_DocsRelacion 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_vent_docsrelacion = New DVENT_DocsRelacion()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property VENT_DocsRelacion() As EVENT_DocsRelacion 
		Get
			return m_event_docsrelacion
		End Get
		Set(ByVal value As EVENT_DocsRelacion)
			m_event_docsrelacion = value
		End Set
	End Property

	Public Property ListVENT_DocsRelacion() As List(Of EVENT_DocsRelacion)
		Get
			return m_listVENT_DocsRelacion
		End Get
		Set(ByVal value As List(Of EVENT_DocsRelacion))
			m_listVENT_DocsRelacion = value
		End Set
	End Property

	Public Property DTVENT_DocsRelacion() As DataTable
		Get
			return m_dtVENT_DocsRelacion
		End Get
		Set(ByVal value As DataTable)
			m_dtVENT_DocsRelacion = value
		End Set
	End Property

	Public Property DSVENT_DocsRelacion() As DataSet
		Get
			return m_dsVENT_DocsRelacion
		End Get
		Set(ByVal value As DataSet)
			m_dsVENT_DocsRelacion = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listVENT_DocsRelacion = new List(Of EVENT_DocsRelacion)()
			return d_vent_docsrelacion.VENT_DOCRESS_Todos(m_listVENT_DocsRelacion)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_DocsRelacion = new List(Of EVENT_DocsRelacion)()
			return d_vent_docsrelacion.VENT_DOCRESS_Todos(m_listVENT_DocsRelacion, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_DocsRelacion = new List(Of EVENT_DocsRelacion)()
			return d_vent_docsrelacion.VENT_DOCRESS_Todos(m_listVENT_DocsRelacion, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listVENT_DocsRelacion = new List(Of EVENT_DocsRelacion)()
			return d_vent_docsrelacion.VENT_DOCRESS_Todos(m_listVENT_DocsRelacion, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_DocsRelacion = new DataSet()
			return d_vent_docsrelacion.VENT_DOCRESS_Todos(m_dsVENT_DocsRelacion, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_DocsRelacion = new DataSet()
			return d_vent_docsrelacion.VENT_DOCRESS_Todos(m_dsVENT_DocsRelacion, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_DocsRelacion = new DataSet()
			Dim _opcion As Boolean = d_vent_docsrelacion.VENT_DOCRESS_Todos(m_dsVENT_DocsRelacion, x_where)
		If _opcion Then
			m_dtVENT_DocsRelacion = m_dsVENT_DocsRelacion.Tables(0)
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
			m_dsVENT_DocsRelacion = new DataSet()
			Dim _opcion As Boolean = d_vent_docsrelacion.VENT_DOCRESS_Todos(m_dsVENT_DocsRelacion, x_join, x_where)
		If _opcion Then
			m_dtVENT_DocsRelacion = m_dsVENT_DocsRelacion.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_docve_codigo As String, x_docve_codreferencia As String) As Boolean
		Try
			m_event_docsrelacion = New EVENT_DocsRelacion()
			Return d_vent_docsrelacion.VENT_DOCRESS_UnReg(m_event_docsrelacion, x_docve_codigo, x_docve_codreferencia)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_event_docsrelacion = New EVENT_DocsRelacion()
			Return d_vent_docsrelacion.VENT_DOCRESS_UnReg(m_event_docsrelacion, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_event_docsrelacion = New EVENT_DocsRelacion()
			Return d_vent_docsrelacion.VENT_DOCRESS_UnReg(m_event_docsrelacion, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_event_docsrelacion.Nuevo Then
				d_vent_docsrelacion.VENT_DOCRESI_UnReg(m_event_docsrelacion, x_usuario)
			ElseIf m_event_docsrelacion.Modificado Then
				d_vent_docsrelacion.VENT_DOCRESU_UnReg(m_event_docsrelacion, x_usuario)
			ElseIf m_event_docsrelacion.Eliminado Then
				d_vent_docsrelacion.VENT_DOCRESD_UnReg(VENT_DocsRelacion)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_event_docsrelacion.Nuevo Then
				d_vent_docsrelacion.VENT_DOCRESI_UnReg(m_event_docsrelacion, x_usuario)
			ElseIf m_event_docsrelacion.Modificado Then
				d_vent_docsrelacion.VENT_DOCRESU_UnReg(m_event_docsrelacion, x_where, x_usuario)
			ElseIf m_event_docsrelacion.Eliminado Then
				d_vent_docsrelacion.VENT_DOCRESD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_event_docsrelacion.Nuevo Then
				d_vent_docsrelacion.VENT_DOCRESI_UnReg(m_event_docsrelacion, x_usuario, x_excluir, x_setfecha)
			ElseIf m_event_docsrelacion.Modificado Then
				d_vent_docsrelacion.VENT_DOCRESU_UnReg(m_event_docsrelacion, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_event_docsrelacion.Eliminado Then
				d_vent_docsrelacion.VENT_DOCRESD_UnReg(VENT_DocsRelacion)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_event_docsrelacion.Nuevo Then
				d_vent_docsrelacion.VENT_DOCRESI_UnReg(m_event_docsrelacion, x_usuario, x_excluir, x_setfecha)
			ElseIf m_event_docsrelacion.Modificado Then
				d_vent_docsrelacion.VENT_DOCRESU_UnReg(m_event_docsrelacion, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_event_docsrelacion.Eliminado Then
				d_vent_docsrelacion.VENT_DOCRESD_UnReg(VENT_DocsRelacion)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_event_docsrelacion.Nuevo Then
				d_vent_docsrelacion.VENT_DOCRESI_UnReg(m_event_docsrelacion, x_usuario, x_setfecha)
			ElseIf m_event_docsrelacion.Modificado Then
				d_vent_docsrelacion.VENT_DOCRESU_UnReg(m_event_docsrelacion, x_usuario, x_setfecha)
			ElseIf m_event_docsrelacion.Eliminado Then
				d_vent_docsrelacion.VENT_DOCRESD_UnReg(VENT_DocsRelacion)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_event_docsrelacion.Nuevo Then
				d_vent_docsrelacion.VENT_DOCRESI_UnReg(m_event_docsrelacion, x_usuario, x_excluir, x_setfecha)
			ElseIf m_event_docsrelacion.Eliminado Then
				d_vent_docsrelacion.VENT_DOCRESD_UnReg(VENT_DocsRelacion)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_DocsRelacion = new List(Of EVENT_DocsRelacion)()
			return d_vent_docsrelacion.VENT_DOCRESD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_vent_docsrelacion.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_vent_docsrelacion.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_vent_docsrelacion.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_vent_docsrelacion.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

