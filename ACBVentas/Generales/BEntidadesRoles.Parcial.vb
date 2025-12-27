Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BEntidadesRoles

#Region " Variables "
	
	Private m_entidadesroles As EEntidadesRoles
	Private m_listEntidadesRoles As List(Of EEntidadesRoles)
	Private m_dtEntidadesRoles As DataTable

	Private m_dsEntidadesRoles As DataSet
	Private d_entidadesroles As DEntidadesRoles 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_entidadesroles = New DEntidadesRoles()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property EntidadesRoles() As EEntidadesRoles 
		Get
			return m_entidadesroles
		End Get
		Set(ByVal value As EEntidadesRoles)
			m_entidadesroles = value
		End Set
	End Property
	Public Property ListEntidadesRoles() As List(Of EEntidadesRoles)
		Get
			return m_listEntidadesRoles
		End Get
		Set(ByVal value As List(Of EEntidadesRoles))
			m_listEntidadesRoles = value
		End Set
	End Property
	Public Property DTEntidadesRoles() As DataTable
		Get
			return m_dtEntidadesRoles
		End Get
		Set(ByVal value As DataTable)
			m_dtEntidadesRoles = value
		End Set
	End Property
	Public Property DSEntidadesRoles() As DataSet
		Get
			return m_dsEntidadesRoles
		End Get
		Set(ByVal value As DataSet)
			m_dsEntidadesRoles = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	
		Public Function getEntidadesRoles() As EEntidadesRoles
			Return Me.m_entidadesroles
		End Function
		Public Sub setEntidadesRoles(ByVal x_entidadesroles As EEntidadesRoles)
			Me.m_entidadesroles = x_entidadesroles 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listEntidadesRoles = new List(Of EEntidadesRoles)()
			return d_entidadesroles.ENTIDSS_Todos(m_listEntidadesRoles)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listEntidadesRoles = new List(Of EEntidadesRoles)()
			return d_entidadesroles.ENTIDSS_Todos(m_listEntidadesRoles, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listEntidadesRoles = new List(Of EEntidadesRoles)()
			return d_entidadesroles.ENTIDSS_Todos(m_listEntidadesRoles, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listEntidadesRoles = new List(Of EEntidadesRoles)()
			return d_entidadesroles.ENTIDSS_Todos(m_listEntidadesRoles, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsEntidadesRoles = new DataSet()
			return d_entidadesroles.ENTIDSS_Todos(m_dsEntidadesRoles, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsEntidadesRoles = new DataSet()
			return d_entidadesroles.ENTIDSS_Todos(m_dsEntidadesRoles, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsEntidadesRoles = new DataSet()
			Dim _opcion As Boolean = d_entidadesroles.ENTIDSS_Todos(m_dsEntidadesRoles, x_where)
		If _opcion Then
			m_dtEntidadesRoles = m_dsEntidadesRoles.Tables(0)
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
			m_dsEntidadesRoles = new DataSet()
			Dim _opcion As Boolean = d_entidadesroles.ENTIDSS_Todos(m_dsEntidadesRoles, x_join, x_where)
		If _opcion Then
			m_dtEntidadesRoles = m_dsEntidadesRoles.Tables(0)
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
			If m_entidadesroles.Nuevo Then
				d_entidadesroles.ENTIDSI_UnReg(m_entidadesroles, x_usuario)
			ElseIf m_entidadesroles.Eliminado Then
				d_entidadesroles.ENTIDSD_UnReg(m_entidadesroles)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_entidadesroles.Nuevo Then
				d_entidadesroles.ENTIDSI_UnReg(m_entidadesroles, x_usuario)
			ElseIf m_entidadesroles.Eliminado Then
				d_entidadesroles.ENTIDSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_entidadesroles.Nuevo Then
				d_entidadesroles.ENTIDSI_UnReg(m_entidadesroles, x_usuario, x_excluir, x_setfecha)
			ElseIf m_entidadesroles.Eliminado Then
				d_entidadesroles.ENTIDSD_UnReg(m_entidadesroles)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_entidadesroles.Nuevo Then
				d_entidadesroles.ENTIDSI_UnReg(m_entidadesroles, x_usuario, x_excluir, x_setfecha)
			ElseIf m_entidadesroles.Eliminado Then
				d_entidadesroles.ENTIDSD_UnReg(m_entidadesroles)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_entidadesroles.Nuevo Then
				d_entidadesroles.ENTIDSI_UnReg(m_entidadesroles, x_usuario, x_setfecha)
			ElseIf m_entidadesroles.Eliminado Then
				d_entidadesroles.ENTIDSD_UnReg(m_entidadesroles)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_entidadesroles.Nuevo Then
				d_entidadesroles.ENTIDSI_UnReg(m_entidadesroles, x_usuario, x_excluir, x_setfecha)
			ElseIf m_entidadesroles.Eliminado Then
				d_entidadesroles.ENTIDSD_UnReg(m_entidadesroles)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listEntidadesRoles = new List(Of EEntidadesRoles)()
			return d_entidadesroles.ENTIDSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_entidadesroles.getCorrelativo("ROLES_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_entidadesroles.getCorrelativo("ROLES_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_entidadesroles.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_entidadesroles.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_entidadesroles.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_entidadesroles.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

