Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BVENT_ListaPreciosArticulos

#Region " Variables "
	
	Private m_vent_listapreciosarticulos As EVENT_ListaPreciosArticulos
	Private m_listVENT_ListaPreciosArticulos As List(Of EVENT_ListaPreciosArticulos)
	Private m_dtVENT_ListaPreciosArticulos As DataTable

	Private m_dsVENT_ListaPreciosArticulos As DataSet
	Private d_vent_listapreciosarticulos As DVENT_ListaPreciosArticulos 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_vent_listapreciosarticulos = New DVENT_ListaPreciosArticulos()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property VENT_ListaPreciosArticulos() As EVENT_ListaPreciosArticulos 
		Get
			return m_vent_listapreciosarticulos
		End Get
		Set(ByVal value As EVENT_ListaPreciosArticulos)
			m_vent_listapreciosarticulos = value
		End Set
	End Property
	Public Property ListVENT_ListaPreciosArticulos() As List(Of EVENT_ListaPreciosArticulos)
		Get
			return m_listVENT_ListaPreciosArticulos
		End Get
		Set(ByVal value As List(Of EVENT_ListaPreciosArticulos))
			m_listVENT_ListaPreciosArticulos = value
		End Set
	End Property
	Public Property DTVENT_ListaPreciosArticulos() As DataTable
		Get
			return m_dtVENT_ListaPreciosArticulos
		End Get
		Set(ByVal value As DataTable)
			m_dtVENT_ListaPreciosArticulos = value
		End Set
	End Property
	Public Property DSVENT_ListaPreciosArticulos() As DataSet
		Get
			return m_dsVENT_ListaPreciosArticulos
		End Get
		Set(ByVal value As DataSet)
			m_dsVENT_ListaPreciosArticulos = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListVENT_ListaPreciosArticulos() As List(Of EVENT_ListaPreciosArticulos)
			Return Me.m_listVENT_ListaPreciosArticulos
		End Function
		Public Sub setListVENT_ListaPreciosArticulos(ByVal _listvent_listapreciosarticulos As List (Of EVENT_ListaPreciosArticulos))
			Me.m_listVENT_ListaPreciosArticulos = m_listvent_listapreciosarticulos 
		End Sub
		Public Function getVENT_ListaPreciosArticulos() As EVENT_ListaPreciosArticulos
			Return Me.m_vent_listapreciosarticulos
		End Function
		Public Sub setVENT_ListaPreciosArticulos(ByVal x_vent_listapreciosarticulos As EVENT_ListaPreciosArticulos)
			Me.m_vent_listapreciosarticulos = x_vent_listapreciosarticulos 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listVENT_ListaPreciosArticulos = new List(Of EVENT_ListaPreciosArticulos)()
			return d_vent_listapreciosarticulos.VENT_ALPRESS_Todos(m_listVENT_ListaPreciosArticulos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_ListaPreciosArticulos = new List(Of EVENT_ListaPreciosArticulos)()
			return d_vent_listapreciosarticulos.VENT_ALPRESS_Todos(m_listVENT_ListaPreciosArticulos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_ListaPreciosArticulos = new List(Of EVENT_ListaPreciosArticulos)()
			return d_vent_listapreciosarticulos.VENT_ALPRESS_Todos(m_listVENT_ListaPreciosArticulos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listVENT_ListaPreciosArticulos = new List(Of EVENT_ListaPreciosArticulos)()
			return d_vent_listapreciosarticulos.VENT_ALPRESS_Todos(m_listVENT_ListaPreciosArticulos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_ListaPreciosArticulos = new DataSet()
			return d_vent_listapreciosarticulos.VENT_ALPRESS_Todos(m_dsVENT_ListaPreciosArticulos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_ListaPreciosArticulos = new DataSet()
			return d_vent_listapreciosarticulos.VENT_ALPRESS_Todos(m_dsVENT_ListaPreciosArticulos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_ListaPreciosArticulos = new DataSet()
			Dim _opcion As Boolean = d_vent_listapreciosarticulos.VENT_ALPRESS_Todos(m_dsVENT_ListaPreciosArticulos, x_where)
		If _opcion Then
			m_dtVENT_ListaPreciosArticulos = m_dsVENT_ListaPreciosArticulos.Tables(0)
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
			m_dsVENT_ListaPreciosArticulos = new DataSet()
			Dim _opcion As Boolean = d_vent_listapreciosarticulos.VENT_ALPRESS_Todos(m_dsVENT_ListaPreciosArticulos, x_join, x_where)
		If _opcion Then
			m_dtVENT_ListaPreciosArticulos = m_dsVENT_ListaPreciosArticulos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_zonas_codigo As String, x_lprec_id As Long, x_artic_codigo As String) As Boolean
		Try
			m_vent_listapreciosarticulos = New EVENT_ListaPreciosArticulos()
			Return d_vent_listapreciosarticulos.VENT_ALPRESS_UnReg(m_vent_listapreciosarticulos, x_zonas_codigo, x_lprec_id, x_artic_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_vent_listapreciosarticulos = New EVENT_ListaPreciosArticulos()
			Return d_vent_listapreciosarticulos.VENT_ALPRESS_UnReg(m_vent_listapreciosarticulos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_vent_listapreciosarticulos = New EVENT_ListaPreciosArticulos()
			Return d_vent_listapreciosarticulos.VENT_ALPRESS_UnReg(m_vent_listapreciosarticulos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_vent_listapreciosarticulos.Nuevo Then
				d_vent_listapreciosarticulos.VENT_ALPRESI_UnReg(m_vent_listapreciosarticulos, x_usuario)
			ElseIf m_vent_listapreciosarticulos.Modificado Then
				d_vent_listapreciosarticulos.VENT_ALPRESU_UnReg(m_vent_listapreciosarticulos, x_usuario)
			ElseIf m_vent_listapreciosarticulos.Eliminado Then
				d_vent_listapreciosarticulos.VENT_ALPRESD_UnReg(m_vent_listapreciosarticulos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_vent_listapreciosarticulos.Nuevo Then
				d_vent_listapreciosarticulos.VENT_ALPRESI_UnReg(m_vent_listapreciosarticulos, x_usuario)
			ElseIf m_vent_listapreciosarticulos.Modificado Then
				d_vent_listapreciosarticulos.VENT_ALPRESU_UnReg(m_vent_listapreciosarticulos, x_where, x_usuario)
			ElseIf m_vent_listapreciosarticulos.Eliminado Then
				d_vent_listapreciosarticulos.VENT_ALPRESD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_listapreciosarticulos.Nuevo Then
				d_vent_listapreciosarticulos.VENT_ALPRESI_UnReg(m_vent_listapreciosarticulos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_listapreciosarticulos.Modificado Then
				d_vent_listapreciosarticulos.VENT_ALPRESU_UnReg(m_vent_listapreciosarticulos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_listapreciosarticulos.Eliminado Then
				d_vent_listapreciosarticulos.VENT_ALPRESD_UnReg(m_vent_listapreciosarticulos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_vent_listapreciosarticulos.Nuevo Then
				d_vent_listapreciosarticulos.VENT_ALPRESI_UnReg(m_vent_listapreciosarticulos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_listapreciosarticulos.Modificado Then
				d_vent_listapreciosarticulos.VENT_ALPRESU_UnReg(m_vent_listapreciosarticulos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_vent_listapreciosarticulos.Eliminado Then
				d_vent_listapreciosarticulos.VENT_ALPRESD_UnReg(m_vent_listapreciosarticulos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_listapreciosarticulos.Nuevo Then
				d_vent_listapreciosarticulos.VENT_ALPRESI_UnReg(m_vent_listapreciosarticulos, x_usuario, x_setfecha)
			ElseIf m_vent_listapreciosarticulos.Modificado Then
				d_vent_listapreciosarticulos.VENT_ALPRESU_UnReg(m_vent_listapreciosarticulos, x_usuario, x_setfecha)
			ElseIf m_vent_listapreciosarticulos.Eliminado Then
				d_vent_listapreciosarticulos.VENT_ALPRESD_UnReg(m_vent_listapreciosarticulos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_listapreciosarticulos.Nuevo Then
				d_vent_listapreciosarticulos.VENT_ALPRESI_UnReg(m_vent_listapreciosarticulos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_listapreciosarticulos.Eliminado Then
				d_vent_listapreciosarticulos.VENT_ALPRESD_UnReg(m_vent_listapreciosarticulos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_ListaPreciosArticulos = new List(Of EVENT_ListaPreciosArticulos)()
			return d_vent_listapreciosarticulos.VENT_ALPRESD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_vent_listapreciosarticulos.getCorrelativo("LPREC_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_vent_listapreciosarticulos.getCorrelativo("LPREC_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_vent_listapreciosarticulos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_vent_listapreciosarticulos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_vent_listapreciosarticulos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_vent_listapreciosarticulos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

