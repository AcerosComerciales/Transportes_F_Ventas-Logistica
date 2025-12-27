Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BSucursales

#Region " Variables "
	
	Private m_sucursales As ESucursales
	Private m_listSucursales As List(Of ESucursales)
	Private m_dtSucursales As DataTable

	Private m_dsSucursales As DataSet
	Private d_sucursales As DSucursales 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_sucursales = New DSucursales()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Sucursales() As ESucursales 
		Get
			return m_sucursales
		End Get
		Set(ByVal value As ESucursales)
			m_sucursales = value
		End Set
	End Property
	Public Property ListSucursales() As List(Of ESucursales)
		Get
			return m_listSucursales
		End Get
		Set(ByVal value As List(Of ESucursales))
			m_listSucursales = value
		End Set
	End Property
	Public Property DTSucursales() As DataTable
		Get
			return m_dtSucursales
		End Get
		Set(ByVal value As DataTable)
			m_dtSucursales = value
		End Set
	End Property
	Public Property DSSucursales() As DataSet
		Get
			return m_dsSucursales
		End Get
		Set(ByVal value As DataSet)
			m_dsSucursales = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListSucursales() As List(Of ESucursales)
			Return Me.m_listSucursales
		End Function
		Public Sub setListSucursales(ByVal _listsucursales As List (Of ESucursales))
			Me.m_listSucursales = m_listsucursales 
		End Sub
		Public Function getSucursales() As ESucursales
			Return Me.m_sucursales
		End Function
		Public Sub setSucursales(ByVal x_sucursales As ESucursales)
			Me.m_sucursales = x_sucursales 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listSucursales = new List(Of ESucursales)()
			return d_sucursales.SUCURSS_Todos(m_listSucursales)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listSucursales = new List(Of ESucursales)()
			return d_sucursales.SUCURSS_Todos(m_listSucursales, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listSucursales = new List(Of ESucursales)()
			return d_sucursales.SUCURSS_Todos(m_listSucursales, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listSucursales = new List(Of ESucursales)()
			return d_sucursales.SUCURSS_Todos(m_listSucursales, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_zonas_codigo As String) As Boolean
		Try
			m_listSucursales = new List(Of ESucursales)()
			Return d_sucursales.SUCURSS_Todos(m_listSucursales, x_zonas_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsSucursales = new DataSet()
			return d_sucursales.SUCURSS_Todos(m_dsSucursales, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsSucursales = new DataSet()
			return d_sucursales.SUCURSS_Todos(m_dsSucursales, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsSucursales = new DataSet()
			Dim _opcion As Boolean = d_sucursales.SUCURSS_Todos(m_dsSucursales, x_where)
		If _opcion Then
			m_dtSucursales = m_dsSucursales.Tables(0)
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
			m_dsSucursales = new DataSet()
			Dim _opcion As Boolean = d_sucursales.SUCURSS_Todos(m_dsSucursales, x_join, x_where)
		If _opcion Then
			m_dtSucursales = m_dsSucursales.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_zonas_codigo As String, x_sucur_id As Short) As Boolean
		Try
			m_sucursales = New ESucursales()
			Return d_sucursales.SUCURSS_UnReg(m_sucursales, x_zonas_codigo, x_sucur_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_sucursales = New ESucursales()
			Return d_sucursales.SUCURSS_UnReg(m_sucursales, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_sucursales = New ESucursales()
			Return d_sucursales.SUCURSS_UnReg(m_sucursales, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_sucursales.Nuevo Then
				d_sucursales.SUCURSI_UnReg(m_sucursales, x_usuario)
			ElseIf m_sucursales.Modificado Then
				d_sucursales.SUCURSU_UnReg(m_sucursales, x_usuario)
			ElseIf m_sucursales.Eliminado Then
				d_sucursales.SUCURSD_UnReg(m_sucursales)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_sucursales.Nuevo Then
				d_sucursales.SUCURSI_UnReg(m_sucursales, x_usuario)
			ElseIf m_sucursales.Modificado Then
				d_sucursales.SUCURSU_UnReg(m_sucursales, x_where, x_usuario)
			ElseIf m_sucursales.Eliminado Then
				d_sucursales.SUCURSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_sucursales.Nuevo Then
				d_sucursales.SUCURSI_UnReg(m_sucursales, x_usuario, x_excluir, x_setfecha)
			ElseIf m_sucursales.Modificado Then
				d_sucursales.SUCURSU_UnReg(m_sucursales, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_sucursales.Eliminado Then
				d_sucursales.SUCURSD_UnReg(m_sucursales)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_sucursales.Nuevo Then
				d_sucursales.SUCURSI_UnReg(m_sucursales, x_usuario, x_excluir, x_setfecha)
			ElseIf m_sucursales.Modificado Then
				d_sucursales.SUCURSU_UnReg(m_sucursales, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_sucursales.Eliminado Then
				d_sucursales.SUCURSD_UnReg(m_sucursales)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_sucursales.Nuevo Then
				d_sucursales.SUCURSI_UnReg(m_sucursales, x_usuario, x_setfecha)
			ElseIf m_sucursales.Modificado Then
				d_sucursales.SUCURSU_UnReg(m_sucursales, x_usuario, x_setfecha)
			ElseIf m_sucursales.Eliminado Then
				d_sucursales.SUCURSD_UnReg(m_sucursales)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_sucursales.Nuevo Then
				d_sucursales.SUCURSI_UnReg(m_sucursales, x_usuario, x_excluir, x_setfecha)
			ElseIf m_sucursales.Eliminado Then
				d_sucursales.SUCURSD_UnReg(m_sucursales)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listSucursales = new List(Of ESucursales)()
			return d_sucursales.SUCURSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_sucursales.getCorrelativo("SUCUR_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_sucursales.getCorrelativo("SUCUR_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_sucursales.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_sucursales.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_sucursales.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_sucursales.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

