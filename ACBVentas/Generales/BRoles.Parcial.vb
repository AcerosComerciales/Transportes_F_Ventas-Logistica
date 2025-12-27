Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BRoles

#Region " Variables "
	
	Private m_roles As ERoles
	Private m_listRoles As List(Of ERoles)
	Private m_dtRoles As DataTable

	Private m_dsRoles As DataSet
	Private d_roles As DRoles 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_roles = New DRoles()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Roles() As ERoles 
		Get
			return m_roles
		End Get
		Set(ByVal value As ERoles)
			m_roles = value
		End Set
	End Property
	Public Property ListRoles() As List(Of ERoles)
		Get
			return m_listRoles
		End Get
		Set(ByVal value As List(Of ERoles))
			m_listRoles = value
		End Set
	End Property
	Public Property DTRoles() As DataTable
		Get
			return m_dtRoles
		End Get
		Set(ByVal value As DataTable)
			m_dtRoles = value
		End Set
	End Property
	Public Property DSRoles() As DataSet
		Get
			return m_dsRoles
		End Get
		Set(ByVal value As DataSet)
			m_dsRoles = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListRoles() As List(Of ERoles)
			Return Me.m_listRoles
		End Function
		Public Sub setListRoles(ByVal _listroles As List (Of ERoles))
			Me.m_listRoles = m_listroles 
		End Sub
		Public Function getRoles() As ERoles
			Return Me.m_roles
		End Function
		Public Sub setRoles(ByVal x_roles As ERoles)
			Me.m_roles = x_roles 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listRoles = new List(Of ERoles)()
			return d_roles.ROLESSS_Todos(m_listRoles)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listRoles = new List(Of ERoles)()
			return d_roles.ROLESSS_Todos(m_listRoles, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listRoles = new List(Of ERoles)()
			return d_roles.ROLESSS_Todos(m_listRoles, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listRoles = new List(Of ERoles)()
			return d_roles.ROLESSS_Todos(m_listRoles, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsRoles = new DataSet()
			return d_roles.ROLESSS_Todos(m_dsRoles, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsRoles = new DataSet()
			return d_roles.ROLESSS_Todos(m_dsRoles, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsRoles = new DataSet()
			Dim _opcion As Boolean = d_roles.ROLESSS_Todos(m_dsRoles, x_where)
		If _opcion Then
			m_dtRoles = m_dsRoles.Tables(0)
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
			m_dsRoles = new DataSet()
			Dim _opcion As Boolean = d_roles.ROLESSS_Todos(m_dsRoles, x_join, x_where)
		If _opcion Then
			m_dtRoles = m_dsRoles.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_roles_id As Long) As Boolean
		Try
			m_roles = New ERoles()
			Return d_roles.ROLESSS_UnReg(m_roles, x_roles_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_roles = New ERoles()
			Return d_roles.ROLESSS_UnReg(m_roles, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_roles = New ERoles()
			Return d_roles.ROLESSS_UnReg(m_roles, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_roles.Nuevo Then
				d_roles.ROLESSI_UnReg(m_roles, x_usuario)
			ElseIf m_roles.Modificado Then
				d_roles.ROLESSU_UnReg(m_roles, x_usuario)
			ElseIf m_roles.Eliminado Then
				d_roles.ROLESSD_UnReg(m_roles)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_roles.Nuevo Then
				d_roles.ROLESSI_UnReg(m_roles, x_usuario)
			ElseIf m_roles.Modificado Then
				d_roles.ROLESSU_UnReg(m_roles, x_where, x_usuario)
			ElseIf m_roles.Eliminado Then
				d_roles.ROLESSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_roles.Nuevo Then
				d_roles.ROLESSI_UnReg(m_roles, x_usuario, x_excluir, x_setfecha)
			ElseIf m_roles.Modificado Then
				d_roles.ROLESSU_UnReg(m_roles, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_roles.Eliminado Then
				d_roles.ROLESSD_UnReg(m_roles)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_roles.Nuevo Then
				d_roles.ROLESSI_UnReg(m_roles, x_usuario, x_excluir, x_setfecha)
			ElseIf m_roles.Modificado Then
				d_roles.ROLESSU_UnReg(m_roles, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_roles.Eliminado Then
				d_roles.ROLESSD_UnReg(m_roles)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_roles.Nuevo Then
				d_roles.ROLESSI_UnReg(m_roles, x_usuario, x_setfecha)
			ElseIf m_roles.Modificado Then
				d_roles.ROLESSU_UnReg(m_roles, x_usuario, x_setfecha)
			ElseIf m_roles.Eliminado Then
				d_roles.ROLESSD_UnReg(m_roles)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_roles.Nuevo Then
				d_roles.ROLESSI_UnReg(m_roles, x_usuario, x_excluir, x_setfecha)
			ElseIf m_roles.Eliminado Then
				d_roles.ROLESSD_UnReg(m_roles)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listRoles = new List(Of ERoles)()
			return d_roles.ROLESSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_roles.getCorrelativo("ROLES_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_roles.getCorrelativo("ROLES_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_roles.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_roles.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_roles.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_roles.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

