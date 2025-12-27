Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BPrecios

#Region " Variables "
	
	Private m_precios As EPrecios
	Private m_listPrecios As List(Of EPrecios)
	Private m_dtPrecios As DataTable

	Private m_dsPrecios As DataSet
	Private d_precios As DPrecios 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_precios = New DPrecios()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Precios() As EPrecios 
		Get
			return m_precios
		End Get
		Set(ByVal value As EPrecios)
			m_precios = value
		End Set
	End Property
	Public Property ListPrecios() As List(Of EPrecios)
		Get
			return m_listPrecios
		End Get
		Set(ByVal value As List(Of EPrecios))
			m_listPrecios = value
		End Set
	End Property
	Public Property DTPrecios() As DataTable
		Get
			return m_dtPrecios
		End Get
		Set(ByVal value As DataTable)
			m_dtPrecios = value
		End Set
	End Property
	Public Property DSPrecios() As DataSet
		Get
			return m_dsPrecios
		End Get
		Set(ByVal value As DataSet)
			m_dsPrecios = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListPrecios() As List(Of EPrecios)
			Return Me.m_listPrecios
		End Function
		Public Sub setListPrecios(ByVal _listprecios As List (Of EPrecios))
			Me.m_listPrecios = m_listprecios 
		End Sub
		Public Function getPrecios() As EPrecios
			Return Me.m_precios
		End Function
		Public Sub setPrecios(ByVal x_precios As EPrecios)
			Me.m_precios = x_precios 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listPrecios = new List(Of EPrecios)()
			return d_precios.PRECISS_Todos(m_listPrecios)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listPrecios = new List(Of EPrecios)()
			return d_precios.PRECISS_Todos(m_listPrecios, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listPrecios = new List(Of EPrecios)()
			return d_precios.PRECISS_Todos(m_listPrecios, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listPrecios = new List(Of EPrecios)()
			return d_precios.PRECISS_Todos(m_listPrecios, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsPrecios = new DataSet()
			return d_precios.PRECISS_Todos(m_dsPrecios, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsPrecios = new DataSet()
			return d_precios.PRECISS_Todos(m_dsPrecios, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsPrecios = new DataSet()
			Dim _opcion As Boolean = d_precios.PRECISS_Todos(m_dsPrecios, x_where)
		If _opcion Then
			m_dtPrecios = m_dsPrecios.Tables(0)
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
			m_dsPrecios = new DataSet()
			Dim _opcion As Boolean = d_precios.PRECISS_Todos(m_dsPrecios, x_join, x_where)
		If _opcion Then
			m_dtPrecios = m_dsPrecios.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_zonas_codigo As String, x_artic_codigo As String) As Boolean
		Try
			m_precios = New EPrecios()
			Return d_precios.PRECISS_UnReg(m_precios, x_zonas_codigo, x_artic_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_precios = New EPrecios()
			Return d_precios.PRECISS_UnReg(m_precios, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_precios = New EPrecios()
			Return d_precios.PRECISS_UnReg(m_precios, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_precios.Nuevo Then
				d_precios.PRECISI_UnReg(m_precios, x_usuario)
			ElseIf m_precios.Modificado Then
				d_precios.PRECISU_UnReg(m_precios, x_usuario)
			ElseIf m_precios.Eliminado Then
				d_precios.PRECISD_UnReg(m_precios)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_precios.Nuevo Then
				d_precios.PRECISI_UnReg(m_precios, x_usuario)
			ElseIf m_precios.Modificado Then
				d_precios.PRECISU_UnReg(m_precios, x_where, x_usuario)
			ElseIf m_precios.Eliminado Then
				d_precios.PRECISD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_precios.Nuevo Then
				d_precios.PRECISI_UnReg(m_precios, x_usuario, x_excluir, x_setfecha)
			ElseIf m_precios.Modificado Then
				d_precios.PRECISU_UnReg(m_precios, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_precios.Eliminado Then
				d_precios.PRECISD_UnReg(m_precios)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_precios.Nuevo Then
				d_precios.PRECISI_UnReg(m_precios, x_usuario, x_excluir, x_setfecha)
			ElseIf m_precios.Modificado Then
				d_precios.PRECISU_UnReg(m_precios, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_precios.Eliminado Then
				d_precios.PRECISD_UnReg(m_precios)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_precios.Nuevo Then
				d_precios.PRECISI_UnReg(m_precios, x_usuario, x_setfecha)
			ElseIf m_precios.Modificado Then
				d_precios.PRECISU_UnReg(m_precios, x_usuario, x_setfecha)
			ElseIf m_precios.Eliminado Then
				d_precios.PRECISD_UnReg(m_precios)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_precios.Nuevo Then
				d_precios.PRECISI_UnReg(m_precios, x_usuario, x_excluir, x_setfecha)
			ElseIf m_precios.Eliminado Then
				d_precios.PRECISD_UnReg(m_precios)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listPrecios = new List(Of EPrecios)()
			return d_precios.PRECISD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_precios.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_precios.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_precios.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_precios.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

