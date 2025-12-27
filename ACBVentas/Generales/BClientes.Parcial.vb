Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BClientes

#Region " Variables "
	
	Private m_clientes As EClientes
	Private m_listClientes As List(Of EClientes)
	Private m_dtClientes As DataTable

	Private m_dsClientes As DataSet
	Private d_clientes As DClientes 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_clientes = New DClientes()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Clientes() As EClientes 
		Get
			return m_clientes
		End Get
		Set(ByVal value As EClientes)
			m_clientes = value
		End Set
	End Property
	Public Property ListClientes() As List(Of EClientes)
		Get
			return m_listClientes
		End Get
		Set(ByVal value As List(Of EClientes))
			m_listClientes = value
		End Set
	End Property
	Public Property DTClientes() As DataTable
		Get
			return m_dtClientes
		End Get
		Set(ByVal value As DataTable)
			m_dtClientes = value
		End Set
	End Property
	Public Property DSClientes() As DataSet
		Get
			return m_dsClientes
		End Get
		Set(ByVal value As DataSet)
			m_dsClientes = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListClientes() As List(Of EClientes)
			Return Me.m_listClientes
		End Function
		Public Sub setListClientes(ByVal _listclientes As List (Of EClientes))
			Me.m_listClientes = m_listclientes 
		End Sub
		Public Function getClientes() As EClientes
			Return Me.m_clientes
		End Function
		Public Sub setClientes(ByVal x_clientes As EClientes)
			Me.m_clientes = x_clientes 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listClientes = new List(Of EClientes)()
			return d_clientes.CLIENSS_Todos(m_listClientes)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listClientes = new List(Of EClientes)()
			return d_clientes.CLIENSS_Todos(m_listClientes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listClientes = new List(Of EClientes)()
			return d_clientes.CLIENSS_Todos(m_listClientes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listClientes = new List(Of EClientes)()
			return d_clientes.CLIENSS_Todos(m_listClientes, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsClientes = new DataSet()
			return d_clientes.CLIENSS_Todos(m_dsClientes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsClientes = new DataSet()
			return d_clientes.CLIENSS_Todos(m_dsClientes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsClientes = new DataSet()
			Dim _opcion As Boolean = d_clientes.CLIENSS_Todos(m_dsClientes, x_where)
		If _opcion Then
			m_dtClientes = m_dsClientes.Tables(0)
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
			m_dsClientes = new DataSet()
			Dim _opcion As Boolean = d_clientes.CLIENSS_Todos(m_dsClientes, x_join, x_where)
		If _opcion Then
			m_dtClientes = m_dsClientes.Tables(0)
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
			m_clientes = New EClientes()
			Return d_clientes.CLIENSS_UnReg(m_clientes, x_entid_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_clientes = New EClientes()
			Return d_clientes.CLIENSS_UnReg(m_clientes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_clientes = New EClientes()
			Return d_clientes.CLIENSS_UnReg(m_clientes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_clientes.Nuevo Then
				d_clientes.CLIENSI_UnReg(m_clientes, x_usuario)
			ElseIf m_clientes.Modificado Then
				d_clientes.CLIENSU_UnReg(m_clientes, x_usuario)
			ElseIf m_clientes.Eliminado Then
				d_clientes.CLIENSD_UnReg(m_clientes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_clientes.Nuevo Then
				d_clientes.CLIENSI_UnReg(m_clientes, x_usuario)
			ElseIf m_clientes.Modificado Then
				d_clientes.CLIENSU_UnReg(m_clientes, x_where, x_usuario)
			ElseIf m_clientes.Eliminado Then
				d_clientes.CLIENSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_clientes.Nuevo Then
				d_clientes.CLIENSI_UnReg(m_clientes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_clientes.Modificado Then
				d_clientes.CLIENSU_UnReg(m_clientes, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_clientes.Eliminado Then
				d_clientes.CLIENSD_UnReg(m_clientes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_clientes.Nuevo Then
				d_clientes.CLIENSI_UnReg(m_clientes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_clientes.Modificado Then
				d_clientes.CLIENSU_UnReg(m_clientes, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_clientes.Eliminado Then
				d_clientes.CLIENSD_UnReg(m_clientes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_clientes.Nuevo Then
				d_clientes.CLIENSI_UnReg(m_clientes, x_usuario, x_setfecha)
			ElseIf m_clientes.Modificado Then
				d_clientes.CLIENSU_UnReg(m_clientes, x_usuario, x_setfecha)
			ElseIf m_clientes.Eliminado Then
				d_clientes.CLIENSD_UnReg(m_clientes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_clientes.Nuevo Then
				d_clientes.CLIENSI_UnReg(m_clientes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_clientes.Eliminado Then
				d_clientes.CLIENSD_UnReg(m_clientes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listClientes = new List(Of EClientes)()
			return d_clientes.CLIENSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_clientes.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_clientes.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_clientes.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_clientes.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

