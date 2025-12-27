Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BConductores

#Region " Variables "
	
	Private m_conductores As EConductores
	Private m_listConductores As List(Of EConductores)
	Private m_dtConductores As DataTable

	Private m_dsConductores As DataSet
	Private d_conductores As DConductores 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_conductores = New DConductores()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Conductores() As EConductores 
		Get
			return m_conductores
		End Get
		Set(ByVal value As EConductores)
			m_conductores = value
		End Set
	End Property
	Public Property ListConductores() As List(Of EConductores)
		Get
			return m_listConductores
		End Get
		Set(ByVal value As List(Of EConductores))
			m_listConductores = value
		End Set
	End Property
	Public Property DTConductores() As DataTable
		Get
			return m_dtConductores
		End Get
		Set(ByVal value As DataTable)
			m_dtConductores = value
		End Set
	End Property
	Public Property DSConductores() As DataSet
		Get
			return m_dsConductores
		End Get
		Set(ByVal value As DataSet)
			m_dsConductores = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListConductores() As List(Of EConductores)
			Return Me.m_listConductores
		End Function
		Public Sub setListConductores(ByVal _listconductores As List (Of EConductores))
			Me.m_listConductores = m_listconductores 
		End Sub
		Public Function getConductores() As EConductores
			Return Me.m_conductores
		End Function
		Public Sub setConductores(ByVal x_conductores As EConductores)
			Me.m_conductores = x_conductores 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listConductores = new List(Of EConductores)()
			return d_conductores.CONDUSS_Todos(m_listConductores)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listConductores = new List(Of EConductores)()
			return d_conductores.CONDUSS_Todos(m_listConductores, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listConductores = new List(Of EConductores)()
			return d_conductores.CONDUSS_Todos(m_listConductores, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listConductores = new List(Of EConductores)()
			return d_conductores.CONDUSS_Todos(m_listConductores, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsConductores = new DataSet()
			return d_conductores.CONDUSS_Todos(m_dsConductores, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsConductores = new DataSet()
			return d_conductores.CONDUSS_Todos(m_dsConductores, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsConductores = new DataSet()
			Dim _opcion As Boolean = d_conductores.CONDUSS_Todos(m_dsConductores, x_where)
		If _opcion Then
			m_dtConductores = m_dsConductores.Tables(0)
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
			m_dsConductores = new DataSet()
			Dim _opcion As Boolean = d_conductores.CONDUSS_Todos(m_dsConductores, x_join, x_where)
		If _opcion Then
			m_dtConductores = m_dsConductores.Tables(0)
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
			m_conductores = New EConductores()
			Return d_conductores.CONDUSS_UnReg(m_conductores, x_entid_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_conductores = New EConductores()
			Return d_conductores.CONDUSS_UnReg(m_conductores, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_conductores = New EConductores()
			Return d_conductores.CONDUSS_UnReg(m_conductores, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_conductores.Nuevo Then
				d_conductores.CONDUSI_UnReg(m_conductores, x_usuario)
			ElseIf m_conductores.Modificado Then
				d_conductores.CONDUSU_UnReg(m_conductores, x_usuario)
			ElseIf m_conductores.Eliminado Then
				d_conductores.CONDUSD_UnReg(m_conductores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_conductores.Nuevo Then
				d_conductores.CONDUSI_UnReg(m_conductores, x_usuario)
			ElseIf m_conductores.Modificado Then
				d_conductores.CONDUSU_UnReg(m_conductores, x_where, x_usuario)
			ElseIf m_conductores.Eliminado Then
				d_conductores.CONDUSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_conductores.Nuevo Then
				d_conductores.CONDUSI_UnReg(m_conductores, x_usuario, x_excluir, x_setfecha)
			ElseIf m_conductores.Modificado Then
				d_conductores.CONDUSU_UnReg(m_conductores, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_conductores.Eliminado Then
				d_conductores.CONDUSD_UnReg(m_conductores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_conductores.Nuevo Then
				d_conductores.CONDUSI_UnReg(m_conductores, x_usuario, x_excluir, x_setfecha)
			ElseIf m_conductores.Modificado Then
				d_conductores.CONDUSU_UnReg(m_conductores, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_conductores.Eliminado Then
				d_conductores.CONDUSD_UnReg(m_conductores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_conductores.Nuevo Then
				d_conductores.CONDUSI_UnReg(m_conductores, x_usuario, x_setfecha)
			ElseIf m_conductores.Modificado Then
				d_conductores.CONDUSU_UnReg(m_conductores, x_usuario, x_setfecha)
			ElseIf m_conductores.Eliminado Then
				d_conductores.CONDUSD_UnReg(m_conductores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_conductores.Nuevo Then
				d_conductores.CONDUSI_UnReg(m_conductores, x_usuario, x_excluir, x_setfecha)
			ElseIf m_conductores.Eliminado Then
				d_conductores.CONDUSD_UnReg(m_conductores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listConductores = new List(Of EConductores)()
			return d_conductores.CONDUSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_conductores.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_conductores.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_conductores.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_conductores.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

