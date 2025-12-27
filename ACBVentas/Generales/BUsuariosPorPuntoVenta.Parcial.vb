Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BUsuariosPorPuntoVenta

#Region " Variables "
	
	Private m_usuariosporpuntoventa As EUsuariosPorPuntoVenta
	Private m_listUsuariosPorPuntoVenta As List(Of EUsuariosPorPuntoVenta)
	Private m_dtUsuariosPorPuntoVenta As DataTable

	Private m_dsUsuariosPorPuntoVenta As DataSet
	Private d_usuariosporpuntoventa As DUsuariosPorPuntoVenta 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_usuariosporpuntoventa = New DUsuariosPorPuntoVenta()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property UsuariosPorPuntoVenta() As EUsuariosPorPuntoVenta 
		Get
			return m_usuariosporpuntoventa
		End Get
		Set(ByVal value As EUsuariosPorPuntoVenta)
			m_usuariosporpuntoventa = value
		End Set
	End Property
	Public Property ListUsuariosPorPuntoVenta() As List(Of EUsuariosPorPuntoVenta)
		Get
			return m_listUsuariosPorPuntoVenta
		End Get
		Set(ByVal value As List(Of EUsuariosPorPuntoVenta))
			m_listUsuariosPorPuntoVenta = value
		End Set
	End Property
	Public Property DTUsuariosPorPuntoVenta() As DataTable
		Get
			return m_dtUsuariosPorPuntoVenta
		End Get
		Set(ByVal value As DataTable)
			m_dtUsuariosPorPuntoVenta = value
		End Set
	End Property
	Public Property DSUsuariosPorPuntoVenta() As DataSet
		Get
			return m_dsUsuariosPorPuntoVenta
		End Get
		Set(ByVal value As DataSet)
			m_dsUsuariosPorPuntoVenta = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	
		Public Function getUsuariosPorPuntoVenta() As EUsuariosPorPuntoVenta
			Return Me.m_usuariosporpuntoventa
		End Function
		Public Sub setUsuariosPorPuntoVenta(ByVal x_usuariosporpuntoventa As EUsuariosPorPuntoVenta)
			Me.m_usuariosporpuntoventa = x_usuariosporpuntoventa 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listUsuariosPorPuntoVenta = new List(Of EUsuariosPorPuntoVenta)()
			return d_usuariosporpuntoventa.USUARSS_Todos(m_listUsuariosPorPuntoVenta)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listUsuariosPorPuntoVenta = new List(Of EUsuariosPorPuntoVenta)()
			return d_usuariosporpuntoventa.USUARSS_Todos(m_listUsuariosPorPuntoVenta, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listUsuariosPorPuntoVenta = new List(Of EUsuariosPorPuntoVenta)()
			return d_usuariosporpuntoventa.USUARSS_Todos(m_listUsuariosPorPuntoVenta, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listUsuariosPorPuntoVenta = new List(Of EUsuariosPorPuntoVenta)()
			return d_usuariosporpuntoventa.USUARSS_Todos(m_listUsuariosPorPuntoVenta, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsUsuariosPorPuntoVenta = new DataSet()
			return d_usuariosporpuntoventa.USUARSS_Todos(m_dsUsuariosPorPuntoVenta, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsUsuariosPorPuntoVenta = new DataSet()
			return d_usuariosporpuntoventa.USUARSS_Todos(m_dsUsuariosPorPuntoVenta, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsUsuariosPorPuntoVenta = new DataSet()
			Dim _opcion As Boolean = d_usuariosporpuntoventa.USUARSS_Todos(m_dsUsuariosPorPuntoVenta, x_where)
		If _opcion Then
			m_dtUsuariosPorPuntoVenta = m_dsUsuariosPorPuntoVenta.Tables(0)
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
			m_dsUsuariosPorPuntoVenta = new DataSet()
			Dim _opcion As Boolean = d_usuariosporpuntoventa.USUARSS_Todos(m_dsUsuariosPorPuntoVenta, x_join, x_where)
		If _opcion Then
			m_dtUsuariosPorPuntoVenta = m_dsUsuariosPorPuntoVenta.Tables(0)
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
			If m_usuariosporpuntoventa.Nuevo Then
				d_usuariosporpuntoventa.USUARSI_UnReg(m_usuariosporpuntoventa, x_usuario)
			ElseIf m_usuariosporpuntoventa.Eliminado Then
				d_usuariosporpuntoventa.USUARSD_UnReg(m_usuariosporpuntoventa)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_usuariosporpuntoventa.Nuevo Then
				d_usuariosporpuntoventa.USUARSI_UnReg(m_usuariosporpuntoventa, x_usuario)
			ElseIf m_usuariosporpuntoventa.Eliminado Then
				d_usuariosporpuntoventa.USUARSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_usuariosporpuntoventa.Nuevo Then
				d_usuariosporpuntoventa.USUARSI_UnReg(m_usuariosporpuntoventa, x_usuario, x_excluir, x_setfecha)
			ElseIf m_usuariosporpuntoventa.Eliminado Then
				d_usuariosporpuntoventa.USUARSD_UnReg(m_usuariosporpuntoventa)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_usuariosporpuntoventa.Nuevo Then
				d_usuariosporpuntoventa.USUARSI_UnReg(m_usuariosporpuntoventa, x_usuario, x_excluir, x_setfecha)
			ElseIf m_usuariosporpuntoventa.Eliminado Then
				d_usuariosporpuntoventa.USUARSD_UnReg(m_usuariosporpuntoventa)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_usuariosporpuntoventa.Nuevo Then
				d_usuariosporpuntoventa.USUARSI_UnReg(m_usuariosporpuntoventa, x_usuario, x_setfecha)
			ElseIf m_usuariosporpuntoventa.Eliminado Then
				d_usuariosporpuntoventa.USUARSD_UnReg(m_usuariosporpuntoventa)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_usuariosporpuntoventa.Nuevo Then
				d_usuariosporpuntoventa.USUARSI_UnReg(m_usuariosporpuntoventa, x_usuario, x_excluir, x_setfecha)
			ElseIf m_usuariosporpuntoventa.Eliminado Then
				d_usuariosporpuntoventa.USUARSD_UnReg(m_usuariosporpuntoventa)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listUsuariosPorPuntoVenta = new List(Of EUsuariosPorPuntoVenta)()
			return d_usuariosporpuntoventa.USUARSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_usuariosporpuntoventa.getCorrelativo("PVENT_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_usuariosporpuntoventa.getCorrelativo("PVENT_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_usuariosporpuntoventa.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_usuariosporpuntoventa.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_usuariosporpuntoventa.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_usuariosporpuntoventa.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

