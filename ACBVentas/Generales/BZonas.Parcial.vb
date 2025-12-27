Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BZonas

#Region " Variables "
	
	Private m_zonas As EZonas
	Private m_listZonas As List(Of EZonas)
	Private m_dtZonas As DataTable

	Private m_dsZonas As DataSet
	Private d_zonas As DZonas 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_zonas = New DZonas()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Zonas() As EZonas 
		Get
			return m_zonas
		End Get
		Set(ByVal value As EZonas)
			m_zonas = value
		End Set
	End Property
	Public Property ListZonas() As List(Of EZonas)
		Get
			return m_listZonas
		End Get
		Set(ByVal value As List(Of EZonas))
			m_listZonas = value
		End Set
	End Property
	Public Property DTZonas() As DataTable
		Get
			return m_dtZonas
		End Get
		Set(ByVal value As DataTable)
			m_dtZonas = value
		End Set
	End Property
	Public Property DSZonas() As DataSet
		Get
			return m_dsZonas
		End Get
		Set(ByVal value As DataSet)
			m_dsZonas = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListZonas() As List(Of EZonas)
			Return Me.m_listZonas
		End Function
		Public Sub setListZonas(ByVal _listzonas As List (Of EZonas))
			Me.m_listZonas = m_listzonas 
		End Sub
		Public Function getZonas() As EZonas
			Return Me.m_zonas
		End Function
		Public Sub setZonas(ByVal x_zonas As EZonas)
			Me.m_zonas = x_zonas 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listZonas = new List(Of EZonas)()
			return d_zonas.ZONASSS_Todos(m_listZonas)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listZonas = new List(Of EZonas)()
			return d_zonas.ZONASSS_Todos(m_listZonas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listZonas = new List(Of EZonas)()
			return d_zonas.ZONASSS_Todos(m_listZonas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listZonas = new List(Of EZonas)()
			return d_zonas.ZONASSS_Todos(m_listZonas, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsZonas = new DataSet()
			return d_zonas.ZONASSS_Todos(m_dsZonas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsZonas = new DataSet()
			return d_zonas.ZONASSS_Todos(m_dsZonas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsZonas = new DataSet()
			Dim _opcion As Boolean = d_zonas.ZONASSS_Todos(m_dsZonas, x_where)
		If _opcion Then
			m_dtZonas = m_dsZonas.Tables(0)
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
			m_dsZonas = new DataSet()
			Dim _opcion As Boolean = d_zonas.ZONASSS_Todos(m_dsZonas, x_join, x_where)
		If _opcion Then
			m_dtZonas = m_dsZonas.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_zonas_codigo As String) As Boolean
		Try
			m_zonas = New EZonas()
			Return d_zonas.ZONASSS_UnReg(m_zonas, x_zonas_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_zonas = New EZonas()
			Return d_zonas.ZONASSS_UnReg(m_zonas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_zonas = New EZonas()
			Return d_zonas.ZONASSS_UnReg(m_zonas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_zonas.Nuevo Then
				d_zonas.ZONASSI_UnReg(m_zonas, x_usuario)
			ElseIf m_zonas.Modificado Then
				d_zonas.ZONASSU_UnReg(m_zonas, x_usuario)
			ElseIf m_zonas.Eliminado Then
				d_zonas.ZONASSD_UnReg(m_zonas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_zonas.Nuevo Then
				d_zonas.ZONASSI_UnReg(m_zonas, x_usuario)
			ElseIf m_zonas.Modificado Then
				d_zonas.ZONASSU_UnReg(m_zonas, x_where, x_usuario)
			ElseIf m_zonas.Eliminado Then
				d_zonas.ZONASSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_zonas.Nuevo Then
				d_zonas.ZONASSI_UnReg(m_zonas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_zonas.Modificado Then
				d_zonas.ZONASSU_UnReg(m_zonas, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_zonas.Eliminado Then
				d_zonas.ZONASSD_UnReg(m_zonas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_zonas.Nuevo Then
				d_zonas.ZONASSI_UnReg(m_zonas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_zonas.Modificado Then
				d_zonas.ZONASSU_UnReg(m_zonas, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_zonas.Eliminado Then
				d_zonas.ZONASSD_UnReg(m_zonas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_zonas.Nuevo Then
				d_zonas.ZONASSI_UnReg(m_zonas, x_usuario, x_setfecha)
			ElseIf m_zonas.Modificado Then
				d_zonas.ZONASSU_UnReg(m_zonas, x_usuario, x_setfecha)
			ElseIf m_zonas.Eliminado Then
				d_zonas.ZONASSD_UnReg(m_zonas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_zonas.Nuevo Then
				d_zonas.ZONASSI_UnReg(m_zonas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_zonas.Eliminado Then
				d_zonas.ZONASSD_UnReg(m_zonas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listZonas = new List(Of EZonas)()
			return d_zonas.ZONASSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_zonas.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_zonas.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_zonas.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_zonas.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

