Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BVENT_DocsVenta

#Region " Variables "
	
	Private m_vent_docsventa As EVENT_DocsVenta
	Private m_listVENT_DocsVenta As List(Of EVENT_DocsVenta)
	Private m_dtVENT_DocsVenta As DataTable

	Private m_dsVENT_DocsVenta As DataSet
	Private d_vent_docsventa As DVENT_DocsVenta 


#End Region

#Region " Constructores "
	
   Public Sub New()
      d_vent_docsventa = New DVENT_DocsVenta()
   End Sub

#End Region

#Region " Propiedades "
	
	Public Property VENT_DocsVenta() As EVENT_DocsVenta 
		Get
			return m_vent_docsventa
		End Get
		Set(ByVal value As EVENT_DocsVenta)
			m_vent_docsventa = value
		End Set
	End Property
	Public Property ListVENT_DocsVenta() As List(Of EVENT_DocsVenta)
		Get
			return m_listVENT_DocsVenta
		End Get
		Set(ByVal value As List(Of EVENT_DocsVenta))
			m_listVENT_DocsVenta = value
		End Set
	End Property
	Public Property DTVENT_DocsVenta() As DataTable
		Get
			return m_dtVENT_DocsVenta
		End Get
		Set(ByVal value As DataTable)
			m_dtVENT_DocsVenta = value
		End Set
	End Property
	Public Property DSVENT_DocsVenta() As DataSet
		Get
			return m_dsVENT_DocsVenta
		End Get
		Set(ByVal value As DataSet)
			m_dsVENT_DocsVenta = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListVENT_DocsVenta() As List(Of EVENT_DocsVenta)
			Return Me.m_listVENT_DocsVenta
		End Function
		Public Sub setListVENT_DocsVenta(ByVal _listvent_docsventa As List (Of EVENT_DocsVenta))
			Me.m_listVENT_DocsVenta = m_listvent_docsventa 
		End Sub
		Public Function getVENT_DocsVenta() As EVENT_DocsVenta
			Return Me.m_vent_docsventa
		End Function
		Public Sub setVENT_DocsVenta(ByVal x_vent_docsventa As EVENT_DocsVenta)
			Me.m_vent_docsventa = x_vent_docsventa 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listVENT_DocsVenta = new List(Of EVENT_DocsVenta)()
			return d_vent_docsventa.VENT_DOCVESS_Todos(m_listVENT_DocsVenta)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_DocsVenta = new List(Of EVENT_DocsVenta)()
			return d_vent_docsventa.VENT_DOCVESS_Todos(m_listVENT_DocsVenta, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_DocsVenta = new List(Of EVENT_DocsVenta)()
			return d_vent_docsventa.VENT_DOCVESS_Todos(m_listVENT_DocsVenta, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listVENT_DocsVenta = new List(Of EVENT_DocsVenta)()
			return d_vent_docsventa.VENT_DOCVESS_Todos(m_listVENT_DocsVenta, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_DocsVenta = new DataSet()
			return d_vent_docsventa.VENT_DOCVESS_Todos(m_dsVENT_DocsVenta, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_DocsVenta = new DataSet()
			return d_vent_docsventa.VENT_DOCVESS_Todos(m_dsVENT_DocsVenta, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_DocsVenta = new DataSet()
			Dim _opcion As Boolean = d_vent_docsventa.VENT_DOCVESS_Todos(m_dsVENT_DocsVenta, x_where)
		If _opcion Then
			m_dtVENT_DocsVenta = m_dsVENT_DocsVenta.Tables(0)
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
			m_dsVENT_DocsVenta = new DataSet()
			Dim _opcion As Boolean = d_vent_docsventa.VENT_DOCVESS_Todos(m_dsVENT_DocsVenta, x_join, x_where)
		If _opcion Then
			m_dtVENT_DocsVenta = m_dsVENT_DocsVenta.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_docve_codigo As String) As Boolean
		Try
			m_vent_docsventa = New EVENT_DocsVenta()
			Return d_vent_docsventa.VENT_DOCVESS_UnReg(m_vent_docsventa, x_docve_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_vent_docsventa = New EVENT_DocsVenta()
			Return d_vent_docsventa.VENT_DOCVESS_UnReg(m_vent_docsventa, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_vent_docsventa = New EVENT_DocsVenta()
			Return d_vent_docsventa.VENT_DOCVESS_UnReg(m_vent_docsventa, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_vent_docsventa.Nuevo Then
				d_vent_docsventa.VENT_DOCVESI_UnReg(m_vent_docsventa, x_usuario)
			ElseIf m_vent_docsventa.Modificado Then
				d_vent_docsventa.VENT_DOCVESU_UnReg(m_vent_docsventa, x_usuario)
			ElseIf m_vent_docsventa.Eliminado Then
				d_vent_docsventa.VENT_DOCVESD_UnReg(m_vent_docsventa)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_vent_docsventa.Nuevo Then
				d_vent_docsventa.VENT_DOCVESI_UnReg(m_vent_docsventa, x_usuario)
			ElseIf m_vent_docsventa.Modificado Then
				d_vent_docsventa.VENT_DOCVESU_UnReg(m_vent_docsventa, x_where, x_usuario)
			ElseIf m_vent_docsventa.Eliminado Then
				d_vent_docsventa.VENT_DOCVESD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_docsventa.Nuevo Then
				d_vent_docsventa.VENT_DOCVESI_UnReg(m_vent_docsventa, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_docsventa.Modificado Then
				d_vent_docsventa.VENT_DOCVESU_UnReg(m_vent_docsventa, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_docsventa.Eliminado Then
				d_vent_docsventa.VENT_DOCVESD_UnReg(m_vent_docsventa)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_vent_docsventa.Nuevo Then
				d_vent_docsventa.VENT_DOCVESI_UnReg(m_vent_docsventa, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_docsventa.Modificado Then
				d_vent_docsventa.VENT_DOCVESU_UnReg(m_vent_docsventa, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_vent_docsventa.Eliminado Then
				d_vent_docsventa.VENT_DOCVESD_UnReg(m_vent_docsventa)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_docsventa.Nuevo Then
				d_vent_docsventa.VENT_DOCVESI_UnReg(m_vent_docsventa, x_usuario, x_setfecha)
			ElseIf m_vent_docsventa.Modificado Then
				d_vent_docsventa.VENT_DOCVESU_UnReg(m_vent_docsventa, x_usuario, x_setfecha)
			ElseIf m_vent_docsventa.Eliminado Then
				d_vent_docsventa.VENT_DOCVESD_UnReg(m_vent_docsventa)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_docsventa.Nuevo Then
				d_vent_docsventa.VENT_DOCVESI_UnReg(m_vent_docsventa, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_docsventa.Eliminado Then
				d_vent_docsventa.VENT_DOCVESD_UnReg(m_vent_docsventa)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_DocsVenta = new List(Of EVENT_DocsVenta)()
			return d_vent_docsventa.VENT_DOCVESD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_vent_docsventa.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_vent_docsventa.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_vent_docsventa.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_vent_docsventa.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

