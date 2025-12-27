Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BVENT_ListaPrecios

#Region " Variables "
	
	Private m_vent_listaprecios As EVENT_ListaPrecios
	Private m_listVENT_ListaPrecios As List(Of EVENT_ListaPrecios)
	Private m_dtVENT_ListaPrecios As DataTable

	Private m_dsVENT_ListaPrecios As DataSet
	Private d_vent_listaprecios As DVENT_ListaPrecios 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_vent_listaprecios = New DVENT_ListaPrecios()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property VENT_ListaPrecios() As EVENT_ListaPrecios 
		Get
			return m_vent_listaprecios
		End Get
		Set(ByVal value As EVENT_ListaPrecios)
			m_vent_listaprecios = value
		End Set
	End Property
	Public Property ListVENT_ListaPrecios() As List(Of EVENT_ListaPrecios)
		Get
			return m_listVENT_ListaPrecios
		End Get
		Set(ByVal value As List(Of EVENT_ListaPrecios))
			m_listVENT_ListaPrecios = value
		End Set
	End Property
	Public Property DTVENT_ListaPrecios() As DataTable
		Get
			return m_dtVENT_ListaPrecios
		End Get
		Set(ByVal value As DataTable)
			m_dtVENT_ListaPrecios = value
		End Set
	End Property
	Public Property DSVENT_ListaPrecios() As DataSet
		Get
			return m_dsVENT_ListaPrecios
		End Get
		Set(ByVal value As DataSet)
			m_dsVENT_ListaPrecios = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListVENT_ListaPrecios() As List(Of EVENT_ListaPrecios)
			Return Me.m_listVENT_ListaPrecios
		End Function
		Public Sub setListVENT_ListaPrecios(ByVal _listvent_listaprecios As List (Of EVENT_ListaPrecios))
			Me.m_listVENT_ListaPrecios = m_listvent_listaprecios 
		End Sub
		Public Function getVENT_ListaPrecios() As EVENT_ListaPrecios
			Return Me.m_vent_listaprecios
		End Function
		Public Sub setVENT_ListaPrecios(ByVal x_vent_listaprecios As EVENT_ListaPrecios)
			Me.m_vent_listaprecios = x_vent_listaprecios 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listVENT_ListaPrecios = new List(Of EVENT_ListaPrecios)()
			return d_vent_listaprecios.VENT_LPRECSS_Todos(m_listVENT_ListaPrecios)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_ListaPrecios = new List(Of EVENT_ListaPrecios)()
			return d_vent_listaprecios.VENT_LPRECSS_Todos(m_listVENT_ListaPrecios, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_ListaPrecios = new List(Of EVENT_ListaPrecios)()
			return d_vent_listaprecios.VENT_LPRECSS_Todos(m_listVENT_ListaPrecios, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listVENT_ListaPrecios = new List(Of EVENT_ListaPrecios)()
			return d_vent_listaprecios.VENT_LPRECSS_Todos(m_listVENT_ListaPrecios, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_zonas_codigo As String) As Boolean
		Try
			m_listVENT_ListaPrecios = new List(Of EVENT_ListaPrecios)()
			Return d_vent_listaprecios.VENT_LPRECSS_Todos(m_listVENT_ListaPrecios, x_zonas_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_ListaPrecios = new DataSet()
			return d_vent_listaprecios.VENT_LPRECSS_Todos(m_dsVENT_ListaPrecios, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_ListaPrecios = new DataSet()
			return d_vent_listaprecios.VENT_LPRECSS_Todos(m_dsVENT_ListaPrecios, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_ListaPrecios = new DataSet()
			Dim _opcion As Boolean = d_vent_listaprecios.VENT_LPRECSS_Todos(m_dsVENT_ListaPrecios, x_where)
		If _opcion Then
			m_dtVENT_ListaPrecios = m_dsVENT_ListaPrecios.Tables(0)
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
			m_dsVENT_ListaPrecios = new DataSet()
			Dim _opcion As Boolean = d_vent_listaprecios.VENT_LPRECSS_Todos(m_dsVENT_ListaPrecios, x_join, x_where)
		If _opcion Then
			m_dtVENT_ListaPrecios = m_dsVENT_ListaPrecios.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_zonas_codigo As String, x_lprec_id As Long) As Boolean
		Try
			m_vent_listaprecios = New EVENT_ListaPrecios()
			Return d_vent_listaprecios.VENT_LPRECSS_UnReg(m_vent_listaprecios, x_zonas_codigo, x_lprec_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_vent_listaprecios = New EVENT_ListaPrecios()
			Return d_vent_listaprecios.VENT_LPRECSS_UnReg(m_vent_listaprecios, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_vent_listaprecios = New EVENT_ListaPrecios()
			Return d_vent_listaprecios.VENT_LPRECSS_UnReg(m_vent_listaprecios, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_vent_listaprecios.Nuevo Then
				d_vent_listaprecios.VENT_LPRECSI_UnReg(m_vent_listaprecios, x_usuario)
			ElseIf m_vent_listaprecios.Modificado Then
				d_vent_listaprecios.VENT_LPRECSU_UnReg(m_vent_listaprecios, x_usuario)
			ElseIf m_vent_listaprecios.Eliminado Then
				d_vent_listaprecios.VENT_LPRECSD_UnReg(m_vent_listaprecios)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_vent_listaprecios.Nuevo Then
				d_vent_listaprecios.VENT_LPRECSI_UnReg(m_vent_listaprecios, x_usuario)
			ElseIf m_vent_listaprecios.Modificado Then
				d_vent_listaprecios.VENT_LPRECSU_UnReg(m_vent_listaprecios, x_where, x_usuario)
			ElseIf m_vent_listaprecios.Eliminado Then
				d_vent_listaprecios.VENT_LPRECSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_listaprecios.Nuevo Then
				d_vent_listaprecios.VENT_LPRECSI_UnReg(m_vent_listaprecios, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_listaprecios.Modificado Then
				d_vent_listaprecios.VENT_LPRECSU_UnReg(m_vent_listaprecios, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_listaprecios.Eliminado Then
				d_vent_listaprecios.VENT_LPRECSD_UnReg(m_vent_listaprecios)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_vent_listaprecios.Nuevo Then
				d_vent_listaprecios.VENT_LPRECSI_UnReg(m_vent_listaprecios, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_listaprecios.Modificado Then
				d_vent_listaprecios.VENT_LPRECSU_UnReg(m_vent_listaprecios, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_vent_listaprecios.Eliminado Then
				d_vent_listaprecios.VENT_LPRECSD_UnReg(m_vent_listaprecios)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_listaprecios.Nuevo Then
				d_vent_listaprecios.VENT_LPRECSI_UnReg(m_vent_listaprecios, x_usuario, x_setfecha)
			ElseIf m_vent_listaprecios.Modificado Then
				d_vent_listaprecios.VENT_LPRECSU_UnReg(m_vent_listaprecios, x_usuario, x_setfecha)
			ElseIf m_vent_listaprecios.Eliminado Then
				d_vent_listaprecios.VENT_LPRECSD_UnReg(m_vent_listaprecios)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_listaprecios.Nuevo Then
				d_vent_listaprecios.VENT_LPRECSI_UnReg(m_vent_listaprecios, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_listaprecios.Eliminado Then
				d_vent_listaprecios.VENT_LPRECSD_UnReg(m_vent_listaprecios)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_ListaPrecios = new List(Of EVENT_ListaPrecios)()
			return d_vent_listaprecios.VENT_LPRECSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_vent_listaprecios.getCorrelativo("LPREC_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_vent_listaprecios.getCorrelativo("LPREC_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_vent_listaprecios.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_vent_listaprecios.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_vent_listaprecios.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_vent_listaprecios.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

