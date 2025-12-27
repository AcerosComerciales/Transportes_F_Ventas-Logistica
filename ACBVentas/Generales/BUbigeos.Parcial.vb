Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BUbigeos

#Region " Variables "
	
	Private m_ubigeos As EUbigeos
	Private m_listUbigeos As List(Of EUbigeos)
	Private m_dtUbigeos As DataTable

	Private m_dsUbigeos As DataSet
	Private d_ubigeos As DUbigeos 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_ubigeos = New DUbigeos()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Ubigeos() As EUbigeos 
		Get
			return m_ubigeos
		End Get
		Set(ByVal value As EUbigeos)
			m_ubigeos = value
		End Set
	End Property
	Public Property ListUbigeos() As List(Of EUbigeos)
		Get
			return m_listUbigeos
		End Get
		Set(ByVal value As List(Of EUbigeos))
			m_listUbigeos = value
		End Set
	End Property
	Public Property DTUbigeos() As DataTable
		Get
			return m_dtUbigeos
		End Get
		Set(ByVal value As DataTable)
			m_dtUbigeos = value
		End Set
	End Property
	Public Property DSUbigeos() As DataSet
		Get
			return m_dsUbigeos
		End Get
		Set(ByVal value As DataSet)
			m_dsUbigeos = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListUbigeos() As List(Of EUbigeos)
			Return Me.m_listUbigeos
		End Function
		Public Sub setListUbigeos(ByVal _listubigeos As List (Of EUbigeos))
			Me.m_listUbigeos = m_listubigeos 
		End Sub
		Public Function getUbigeos() As EUbigeos
			Return Me.m_ubigeos
		End Function
		Public Sub setUbigeos(ByVal x_ubigeos As EUbigeos)
			Me.m_ubigeos = x_ubigeos 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listUbigeos = new List(Of EUbigeos)()
			return d_ubigeos.UBIGOSS_Todos(m_listUbigeos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listUbigeos = new List(Of EUbigeos)()
			return d_ubigeos.UBIGOSS_Todos(m_listUbigeos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listUbigeos = new List(Of EUbigeos)()
			return d_ubigeos.UBIGOSS_Todos(m_listUbigeos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listUbigeos = new List(Of EUbigeos)()
			return d_ubigeos.UBIGOSS_Todos(m_listUbigeos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsUbigeos = new DataSet()
			return d_ubigeos.UBIGOSS_Todos(m_dsUbigeos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsUbigeos = new DataSet()
			return d_ubigeos.UBIGOSS_Todos(m_dsUbigeos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsUbigeos = new DataSet()
			Dim _opcion As Boolean = d_ubigeos.UBIGOSS_Todos(m_dsUbigeos, x_where)
		If _opcion Then
			m_dtUbigeos = m_dsUbigeos.Tables(0)
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
			m_dsUbigeos = new DataSet()
			Dim _opcion As Boolean = d_ubigeos.UBIGOSS_Todos(m_dsUbigeos, x_join, x_where)
		If _opcion Then
			m_dtUbigeos = m_dsUbigeos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_ubigo_codigo As String) As Boolean
		Try
			m_ubigeos = New EUbigeos()
			Return d_ubigeos.UBIGOSS_UnReg(m_ubigeos, x_ubigo_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_ubigeos = New EUbigeos()
			Return d_ubigeos.UBIGOSS_UnReg(m_ubigeos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_ubigeos = New EUbigeos()
			Return d_ubigeos.UBIGOSS_UnReg(m_ubigeos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_ubigeos.Nuevo Then
				d_ubigeos.UBIGOSI_UnReg(m_ubigeos, x_usuario)
			ElseIf m_ubigeos.Modificado Then
				d_ubigeos.UBIGOSU_UnReg(m_ubigeos, x_usuario)
			ElseIf m_ubigeos.Eliminado Then
				d_ubigeos.UBIGOSD_UnReg(m_ubigeos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_ubigeos.Nuevo Then
				d_ubigeos.UBIGOSI_UnReg(m_ubigeos, x_usuario)
			ElseIf m_ubigeos.Modificado Then
				d_ubigeos.UBIGOSU_UnReg(m_ubigeos, x_where, x_usuario)
			ElseIf m_ubigeos.Eliminado Then
				d_ubigeos.UBIGOSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_ubigeos.Nuevo Then
				d_ubigeos.UBIGOSI_UnReg(m_ubigeos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_ubigeos.Modificado Then
				d_ubigeos.UBIGOSU_UnReg(m_ubigeos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_ubigeos.Eliminado Then
				d_ubigeos.UBIGOSD_UnReg(m_ubigeos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_ubigeos.Nuevo Then
				d_ubigeos.UBIGOSI_UnReg(m_ubigeos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_ubigeos.Modificado Then
				d_ubigeos.UBIGOSU_UnReg(m_ubigeos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_ubigeos.Eliminado Then
				d_ubigeos.UBIGOSD_UnReg(m_ubigeos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_ubigeos.Nuevo Then
				d_ubigeos.UBIGOSI_UnReg(m_ubigeos, x_usuario, x_setfecha)
			ElseIf m_ubigeos.Modificado Then
				d_ubigeos.UBIGOSU_UnReg(m_ubigeos, x_usuario, x_setfecha)
			ElseIf m_ubigeos.Eliminado Then
				d_ubigeos.UBIGOSD_UnReg(m_ubigeos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_ubigeos.Nuevo Then
				d_ubigeos.UBIGOSI_UnReg(m_ubigeos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_ubigeos.Eliminado Then
				d_ubigeos.UBIGOSD_UnReg(m_ubigeos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listUbigeos = new List(Of EUbigeos)()
			return d_ubigeos.UBIGOSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_ubigeos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_ubigeos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_ubigeos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_ubigeos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

