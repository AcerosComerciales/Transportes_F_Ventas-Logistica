Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BProveedores

#Region " Variables "
	
	Private m_proveedores As EProveedores
	Private m_listProveedores As List(Of EProveedores)
	Private m_dtProveedores As DataTable

	Private m_dsProveedores As DataSet
	Private d_proveedores As DProveedores 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_proveedores = New DProveedores()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Proveedores() As EProveedores 
		Get
			return m_proveedores
		End Get
		Set(ByVal value As EProveedores)
			m_proveedores = value
		End Set
	End Property
	Public Property ListProveedores() As List(Of EProveedores)
		Get
			return m_listProveedores
		End Get
		Set(ByVal value As List(Of EProveedores))
			m_listProveedores = value
		End Set
	End Property
	Public Property DTProveedores() As DataTable
		Get
			return m_dtProveedores
		End Get
		Set(ByVal value As DataTable)
			m_dtProveedores = value
		End Set
	End Property
	Public Property DSProveedores() As DataSet
		Get
			return m_dsProveedores
		End Get
		Set(ByVal value As DataSet)
			m_dsProveedores = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListProveedores() As List(Of EProveedores)
			Return Me.m_listProveedores
		End Function
		Public Sub setListProveedores(ByVal _listproveedores As List (Of EProveedores))
			Me.m_listProveedores = m_listproveedores 
		End Sub
		Public Function getProveedores() As EProveedores
			Return Me.m_proveedores
		End Function
		Public Sub setProveedores(ByVal x_proveedores As EProveedores)
			Me.m_proveedores = x_proveedores 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listProveedores = new List(Of EProveedores)()
			return d_proveedores.PROVESS_Todos(m_listProveedores)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listProveedores = new List(Of EProveedores)()
			return d_proveedores.PROVESS_Todos(m_listProveedores, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listProveedores = new List(Of EProveedores)()
			return d_proveedores.PROVESS_Todos(m_listProveedores, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listProveedores = new List(Of EProveedores)()
			return d_proveedores.PROVESS_Todos(m_listProveedores, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsProveedores = new DataSet()
			return d_proveedores.PROVESS_Todos(m_dsProveedores, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsProveedores = new DataSet()
			return d_proveedores.PROVESS_Todos(m_dsProveedores, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsProveedores = new DataSet()
			Dim _opcion As Boolean = d_proveedores.PROVESS_Todos(m_dsProveedores, x_where)
		If _opcion Then
			m_dtProveedores = m_dsProveedores.Tables(0)
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
			m_dsProveedores = new DataSet()
			Dim _opcion As Boolean = d_proveedores.PROVESS_Todos(m_dsProveedores, x_join, x_where)
		If _opcion Then
			m_dtProveedores = m_dsProveedores.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_entid_codigo As String) As Boolean
		Try
			m_proveedores = New EProveedores()
			Return d_proveedores.PROVESS_UnReg(m_proveedores, x_entid_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_proveedores = New EProveedores()
			Return d_proveedores.PROVESS_UnReg(m_proveedores, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_proveedores = New EProveedores()
			Return d_proveedores.PROVESS_UnReg(m_proveedores, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_proveedores.Nuevo Then
				d_proveedores.PROVESI_UnReg(m_proveedores, x_usuario)
			ElseIf m_proveedores.Modificado Then
				d_proveedores.PROVESU_UnReg(m_proveedores, x_usuario)
			ElseIf m_proveedores.Eliminado Then
				d_proveedores.PROVESD_UnReg(m_proveedores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_proveedores.Nuevo Then
				d_proveedores.PROVESI_UnReg(m_proveedores, x_usuario)
			ElseIf m_proveedores.Modificado Then
				d_proveedores.PROVESU_UnReg(m_proveedores, x_where, x_usuario)
			ElseIf m_proveedores.Eliminado Then
				d_proveedores.PROVESD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_proveedores.Nuevo Then
				d_proveedores.PROVESI_UnReg(m_proveedores, x_usuario, x_excluir, x_setfecha)
			ElseIf m_proveedores.Modificado Then
				d_proveedores.PROVESU_UnReg(m_proveedores, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_proveedores.Eliminado Then
				d_proveedores.PROVESD_UnReg(m_proveedores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_proveedores.Nuevo Then
				d_proveedores.PROVESI_UnReg(m_proveedores, x_usuario, x_excluir, x_setfecha)
			ElseIf m_proveedores.Modificado Then
				d_proveedores.PROVESU_UnReg(m_proveedores, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_proveedores.Eliminado Then
				d_proveedores.PROVESD_UnReg(m_proveedores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_proveedores.Nuevo Then
				d_proveedores.PROVESI_UnReg(m_proveedores, x_usuario, x_setfecha)
			ElseIf m_proveedores.Modificado Then
				d_proveedores.PROVESU_UnReg(m_proveedores, x_usuario, x_setfecha)
			ElseIf m_proveedores.Eliminado Then
				d_proveedores.PROVESD_UnReg(m_proveedores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_proveedores.Nuevo Then
				d_proveedores.PROVESI_UnReg(m_proveedores, x_usuario, x_excluir, x_setfecha)
			ElseIf m_proveedores.Eliminado Then
				d_proveedores.PROVESD_UnReg(m_proveedores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listProveedores = new List(Of EProveedores)()
			return d_proveedores.PROVESD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_proveedores.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_proveedores.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_proveedores.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_proveedores.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

