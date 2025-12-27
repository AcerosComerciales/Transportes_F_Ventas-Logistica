Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_VehiculosIncidencias

#Region " Variables "
	
	Private m_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias
	Private m_listTRAN_VehiculosIncidencias As List(Of ETRAN_VehiculosIncidencias)
	Private m_dtTRAN_VehiculosIncidencias As DataTable

	Private m_dsTRAN_VehiculosIncidencias As DataSet
	Private d_tran_vehiculosincidencias As DTRAN_VehiculosIncidencias 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_vehiculosincidencias = New DTRAN_VehiculosIncidencias()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_VehiculosIncidencias() As ETRAN_VehiculosIncidencias 
		Get
			return m_tran_vehiculosincidencias
		End Get
		Set(ByVal value As ETRAN_VehiculosIncidencias)
			m_tran_vehiculosincidencias = value
		End Set
	End Property
	Public Property ListTRAN_VehiculosIncidencias() As List(Of ETRAN_VehiculosIncidencias)
		Get
			return m_listTRAN_VehiculosIncidencias
		End Get
		Set(ByVal value As List(Of ETRAN_VehiculosIncidencias))
			m_listTRAN_VehiculosIncidencias = value
		End Set
	End Property
	Public Property DTTRAN_VehiculosIncidencias() As DataTable
		Get
			return m_dtTRAN_VehiculosIncidencias
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_VehiculosIncidencias = value
		End Set
	End Property
	Public Property DSTRAN_VehiculosIncidencias() As DataSet
		Get
			return m_dsTRAN_VehiculosIncidencias
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_VehiculosIncidencias = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_VehiculosIncidencias() As List(Of ETRAN_VehiculosIncidencias)
			Return Me.m_listTRAN_VehiculosIncidencias
		End Function
		Public Sub setListTRAN_VehiculosIncidencias(ByVal _listtran_vehiculosincidencias As List (Of ETRAN_VehiculosIncidencias))
			Me.m_listTRAN_VehiculosIncidencias = m_listtran_vehiculosincidencias 
		End Sub
		Public Function getTRAN_VehiculosIncidencias() As ETRAN_VehiculosIncidencias
			Return Me.m_tran_vehiculosincidencias
		End Function
		Public Sub setTRAN_VehiculosIncidencias(ByVal x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias)
			Me.m_tran_vehiculosincidencias = x_tran_vehiculosincidencias 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_VehiculosIncidencias = new List(Of ETRAN_VehiculosIncidencias)()
			return d_tran_vehiculosincidencias.TRAN_INCVESS_Todos(m_listTRAN_VehiculosIncidencias)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosIncidencias = new List(Of ETRAN_VehiculosIncidencias)()
			return d_tran_vehiculosincidencias.TRAN_INCVESS_Todos(m_listTRAN_VehiculosIncidencias, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosIncidencias = new List(Of ETRAN_VehiculosIncidencias)()
			return d_tran_vehiculosincidencias.TRAN_INCVESS_Todos(m_listTRAN_VehiculosIncidencias, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_VehiculosIncidencias = new List(Of ETRAN_VehiculosIncidencias)()
			return d_tran_vehiculosincidencias.TRAN_INCVESS_Todos(m_listTRAN_VehiculosIncidencias, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosIncidencias = new DataSet()
			return d_tran_vehiculosincidencias.TRAN_INCVESS_Todos(m_dsTRAN_VehiculosIncidencias, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosIncidencias = new DataSet()
			return d_tran_vehiculosincidencias.TRAN_INCVESS_Todos(m_dsTRAN_VehiculosIncidencias, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosIncidencias = new DataSet()
			Dim _opcion As Boolean = d_tran_vehiculosincidencias.TRAN_INCVESS_Todos(m_dsTRAN_VehiculosIncidencias, x_where)
		If _opcion Then
			m_dtTRAN_VehiculosIncidencias = m_dsTRAN_VehiculosIncidencias.Tables(0)
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
			m_dsTRAN_VehiculosIncidencias = new DataSet()
			Dim _opcion As Boolean = d_tran_vehiculosincidencias.TRAN_INCVESS_Todos(m_dsTRAN_VehiculosIncidencias, x_join, x_where)
		If _opcion Then
			m_dtTRAN_VehiculosIncidencias = m_dsTRAN_VehiculosIncidencias.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_incve_id As Long) As Boolean
		Try
			m_tran_vehiculosincidencias = New ETRAN_VehiculosIncidencias()
			Return d_tran_vehiculosincidencias.TRAN_INCVESS_UnReg(m_tran_vehiculosincidencias, x_incve_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_vehiculosincidencias = New ETRAN_VehiculosIncidencias()
			Return d_tran_vehiculosincidencias.TRAN_INCVESS_UnReg(m_tran_vehiculosincidencias, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_vehiculosincidencias = New ETRAN_VehiculosIncidencias()
			Return d_tran_vehiculosincidencias.TRAN_INCVESS_UnReg(m_tran_vehiculosincidencias, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_vehiculosincidencias.Nuevo Then
				d_tran_vehiculosincidencias.TRAN_INCVESI_UnReg(m_tran_vehiculosincidencias, x_usuario)
			ElseIf m_tran_vehiculosincidencias.Modificado Then
				d_tran_vehiculosincidencias.TRAN_INCVESU_UnReg(m_tran_vehiculosincidencias, x_usuario)
			ElseIf m_tran_vehiculosincidencias.Eliminado Then
				d_tran_vehiculosincidencias.TRAN_INCVESD_UnReg(m_tran_vehiculosincidencias)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_vehiculosincidencias.Nuevo Then
				d_tran_vehiculosincidencias.TRAN_INCVESI_UnReg(m_tran_vehiculosincidencias, x_usuario)
			ElseIf m_tran_vehiculosincidencias.Modificado Then
				d_tran_vehiculosincidencias.TRAN_INCVESU_UnReg(m_tran_vehiculosincidencias, x_where, x_usuario)
			ElseIf m_tran_vehiculosincidencias.Eliminado Then
				d_tran_vehiculosincidencias.TRAN_INCVESD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosincidencias.Nuevo Then
				d_tran_vehiculosincidencias.TRAN_INCVESI_UnReg(m_tran_vehiculosincidencias, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosincidencias.Modificado Then
				d_tran_vehiculosincidencias.TRAN_INCVESU_UnReg(m_tran_vehiculosincidencias, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosincidencias.Eliminado Then
				d_tran_vehiculosincidencias.TRAN_INCVESD_UnReg(m_tran_vehiculosincidencias)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_vehiculosincidencias.Nuevo Then
				d_tran_vehiculosincidencias.TRAN_INCVESI_UnReg(m_tran_vehiculosincidencias, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosincidencias.Modificado Then
				d_tran_vehiculosincidencias.TRAN_INCVESU_UnReg(m_tran_vehiculosincidencias, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_vehiculosincidencias.Eliminado Then
				d_tran_vehiculosincidencias.TRAN_INCVESD_UnReg(m_tran_vehiculosincidencias)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosincidencias.Nuevo Then
				d_tran_vehiculosincidencias.TRAN_INCVESI_UnReg(m_tran_vehiculosincidencias, x_usuario, x_setfecha)
			ElseIf m_tran_vehiculosincidencias.Modificado Then
				d_tran_vehiculosincidencias.TRAN_INCVESU_UnReg(m_tran_vehiculosincidencias, x_usuario, x_setfecha)
			ElseIf m_tran_vehiculosincidencias.Eliminado Then
				d_tran_vehiculosincidencias.TRAN_INCVESD_UnReg(m_tran_vehiculosincidencias)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosincidencias.Nuevo Then
				d_tran_vehiculosincidencias.TRAN_INCVESI_UnReg(m_tran_vehiculosincidencias, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosincidencias.Eliminado Then
				d_tran_vehiculosincidencias.TRAN_INCVESD_UnReg(m_tran_vehiculosincidencias)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosIncidencias = new List(Of ETRAN_VehiculosIncidencias)()
			return d_tran_vehiculosincidencias.TRAN_INCVESD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_vehiculosincidencias.getCorrelativo("INCVE_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_vehiculosincidencias.getCorrelativo("INCVE_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_vehiculosincidencias.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_vehiculosincidencias.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_vehiculosincidencias.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_vehiculosincidencias.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

