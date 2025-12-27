Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BUsuariosPorAlmacen

#Region " Variables "
	
	Private m_eusuariosporalmacen As EUsuariosPorAlmacen
	Private m_listUsuariosPorAlmacen As List(Of EUsuariosPorAlmacen)
	Private m_dtUsuariosPorAlmacen As DataTable

	Private m_dsUsuariosPorAlmacen As DataSet
	Private d_usuariosporalmacen As DUsuariosPorAlmacen 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_usuariosporalmacen = New DUsuariosPorAlmacen()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property UsuariosPorAlmacen() As EUsuariosPorAlmacen 
		Get
			return m_eusuariosporalmacen
		End Get
		Set(ByVal value As EUsuariosPorAlmacen)
			m_eusuariosporalmacen = value
		End Set
	End Property

	Public Property ListUsuariosPorAlmacen() As List(Of EUsuariosPorAlmacen)
		Get
			return m_listUsuariosPorAlmacen
		End Get
		Set(ByVal value As List(Of EUsuariosPorAlmacen))
			m_listUsuariosPorAlmacen = value
		End Set
	End Property

	Public Property DTUsuariosPorAlmacen() As DataTable
		Get
			return m_dtUsuariosPorAlmacen
		End Get
		Set(ByVal value As DataTable)
			m_dtUsuariosPorAlmacen = value
		End Set
	End Property

	Public Property DSUsuariosPorAlmacen() As DataSet
		Get
			return m_dsUsuariosPorAlmacen
		End Get
		Set(ByVal value As DataSet)
			m_dsUsuariosPorAlmacen = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listUsuariosPorAlmacen = new List(Of EUsuariosPorAlmacen)()
			return d_usuariosporalmacen.USUARSS_Todos(m_listUsuariosPorAlmacen)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listUsuariosPorAlmacen = new List(Of EUsuariosPorAlmacen)()
			return d_usuariosporalmacen.USUARSS_Todos(m_listUsuariosPorAlmacen, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listUsuariosPorAlmacen = new List(Of EUsuariosPorAlmacen)()
			return d_usuariosporalmacen.USUARSS_Todos(m_listUsuariosPorAlmacen, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listUsuariosPorAlmacen = new List(Of EUsuariosPorAlmacen)()
			return d_usuariosporalmacen.USUARSS_Todos(m_listUsuariosPorAlmacen, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsUsuariosPorAlmacen = new DataSet()
			return d_usuariosporalmacen.USUARSS_Todos(m_dsUsuariosPorAlmacen, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsUsuariosPorAlmacen = new DataSet()
			return d_usuariosporalmacen.USUARSS_Todos(m_dsUsuariosPorAlmacen, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsUsuariosPorAlmacen = new DataSet()
			Dim _opcion As Boolean = d_usuariosporalmacen.USUARSS_Todos(m_dsUsuariosPorAlmacen, x_where)
		If _opcion Then
			m_dtUsuariosPorAlmacen = m_dsUsuariosPorAlmacen.Tables(0)
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
			m_dsUsuariosPorAlmacen = new DataSet()
			Dim _opcion As Boolean = d_usuariosporalmacen.USUARSS_Todos(m_dsUsuariosPorAlmacen, x_join, x_where)
		If _opcion Then
			m_dtUsuariosPorAlmacen = m_dsUsuariosPorAlmacen.Tables(0)
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
			If m_eusuariosporalmacen.Nuevo Then
				d_usuariosporalmacen.USUARSI_UnReg(m_eusuariosporalmacen, x_usuario)
			ElseIf m_eusuariosporalmacen.Eliminado Then
				d_usuariosporalmacen.USUARSD_UnReg(UsuariosPorAlmacen)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eusuariosporalmacen.Nuevo Then
				d_usuariosporalmacen.USUARSI_UnReg(m_eusuariosporalmacen, x_usuario)
			ElseIf m_eusuariosporalmacen.Eliminado Then
				d_usuariosporalmacen.USUARSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eusuariosporalmacen.Nuevo Then
				d_usuariosporalmacen.USUARSI_UnReg(m_eusuariosporalmacen, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eusuariosporalmacen.Eliminado Then
				d_usuariosporalmacen.USUARSD_UnReg(UsuariosPorAlmacen)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eusuariosporalmacen.Nuevo Then
				d_usuariosporalmacen.USUARSI_UnReg(m_eusuariosporalmacen, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eusuariosporalmacen.Eliminado Then
				d_usuariosporalmacen.USUARSD_UnReg(UsuariosPorAlmacen)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eusuariosporalmacen.Nuevo Then
				d_usuariosporalmacen.USUARSI_UnReg(m_eusuariosporalmacen, x_usuario, x_setfecha)
			ElseIf m_eusuariosporalmacen.Eliminado Then
				d_usuariosporalmacen.USUARSD_UnReg(UsuariosPorAlmacen)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eusuariosporalmacen.Nuevo Then
				d_usuariosporalmacen.USUARSI_UnReg(m_eusuariosporalmacen, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eusuariosporalmacen.Eliminado Then
				d_usuariosporalmacen.USUARSD_UnReg(UsuariosPorAlmacen)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listUsuariosPorAlmacen = new List(Of EUsuariosPorAlmacen)()
			return d_usuariosporalmacen.USUARSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_usuariosporalmacen.getCorrelativo("ALMAC_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_usuariosporalmacen.getCorrelativo("ALMAC_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_usuariosporalmacen.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_usuariosporalmacen.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_usuariosporalmacen.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_usuariosporalmacen.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

