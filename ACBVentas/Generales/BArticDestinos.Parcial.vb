Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BArticDestinos

#Region " Variables "
	
	Private m_articdestinos As EArticDestinos
	Private m_listArticDestinos As List(Of EArticDestinos)
	Private m_dtArticDestinos As DataTable

	Private m_dsArticDestinos As DataSet
	Private d_articdestinos As DArticDestinos 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_articdestinos = New DArticDestinos()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property ArticDestinos() As EArticDestinos 
		Get
			return m_articdestinos
		End Get
		Set(ByVal value As EArticDestinos)
			m_articdestinos = value
		End Set
	End Property
	Public Property ListArticDestinos() As List(Of EArticDestinos)
		Get
			return m_listArticDestinos
		End Get
		Set(ByVal value As List(Of EArticDestinos))
			m_listArticDestinos = value
		End Set
	End Property
	Public Property DTArticDestinos() As DataTable
		Get
			return m_dtArticDestinos
		End Get
		Set(ByVal value As DataTable)
			m_dtArticDestinos = value
		End Set
	End Property
	Public Property DSArticDestinos() As DataSet
		Get
			return m_dsArticDestinos
		End Get
		Set(ByVal value As DataSet)
			m_dsArticDestinos = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	
		Public Function getArticDestinos() As EArticDestinos
			Return Me.m_articdestinos
		End Function
		Public Sub setArticDestinos(ByVal x_articdestinos As EArticDestinos)
			Me.m_articdestinos = x_articdestinos 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listArticDestinos = new List(Of EArticDestinos)()
			return d_articdestinos.ARTICSS_Todos(m_listArticDestinos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listArticDestinos = new List(Of EArticDestinos)()
			return d_articdestinos.ARTICSS_Todos(m_listArticDestinos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listArticDestinos = new List(Of EArticDestinos)()
			return d_articdestinos.ARTICSS_Todos(m_listArticDestinos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listArticDestinos = new List(Of EArticDestinos)()
			return d_articdestinos.ARTICSS_Todos(m_listArticDestinos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsArticDestinos = new DataSet()
			return d_articdestinos.ARTICSS_Todos(m_dsArticDestinos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsArticDestinos = new DataSet()
			return d_articdestinos.ARTICSS_Todos(m_dsArticDestinos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsArticDestinos = new DataSet()
			Dim _opcion As Boolean = d_articdestinos.ARTICSS_Todos(m_dsArticDestinos, x_where)
		If _opcion Then
			m_dtArticDestinos = m_dsArticDestinos.Tables(0)
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
			m_dsArticDestinos = new DataSet()
			Dim _opcion As Boolean = d_articdestinos.ARTICSS_Todos(m_dsArticDestinos, x_join, x_where)
		If _opcion Then
			m_dtArticDestinos = m_dsArticDestinos.Tables(0)
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
			If m_articdestinos.Nuevo Then
				d_articdestinos.ARTICSI_UnReg(m_articdestinos, x_usuario)
			ElseIf m_articdestinos.Eliminado Then
				d_articdestinos.ARTICSD_UnReg(m_articdestinos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_articdestinos.Nuevo Then
				d_articdestinos.ARTICSI_UnReg(m_articdestinos, x_usuario)
			ElseIf m_articdestinos.Eliminado Then
				d_articdestinos.ARTICSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_articdestinos.Nuevo Then
				d_articdestinos.ARTICSI_UnReg(m_articdestinos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_articdestinos.Eliminado Then
				d_articdestinos.ARTICSD_UnReg(m_articdestinos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_articdestinos.Nuevo Then
				d_articdestinos.ARTICSI_UnReg(m_articdestinos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_articdestinos.Eliminado Then
				d_articdestinos.ARTICSD_UnReg(m_articdestinos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_articdestinos.Nuevo Then
				d_articdestinos.ARTICSI_UnReg(m_articdestinos, x_usuario, x_setfecha)
			ElseIf m_articdestinos.Eliminado Then
				d_articdestinos.ARTICSD_UnReg(m_articdestinos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_articdestinos.Nuevo Then
				d_articdestinos.ARTICSI_UnReg(m_articdestinos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_articdestinos.Eliminado Then
				d_articdestinos.ARTICSD_UnReg(m_articdestinos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listArticDestinos = new List(Of EArticDestinos)()
			return d_articdestinos.ARTICSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_articdestinos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_articdestinos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_articdestinos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_articdestinos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

