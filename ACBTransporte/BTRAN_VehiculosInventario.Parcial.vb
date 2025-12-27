Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_VehiculosInventario

#Region " Variables "
	
	Private m_tran_vehiculosinventario As ETRAN_VehiculosInventario
	Private m_listTRAN_VehiculosInventario As List(Of ETRAN_VehiculosInventario)
	Private m_dtTRAN_VehiculosInventario As DataTable

	Private m_dsTRAN_VehiculosInventario As DataSet
	Private d_tran_vehiculosinventario As DTRAN_VehiculosInventario 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_vehiculosinventario = New DTRAN_VehiculosInventario()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_VehiculosInventario() As ETRAN_VehiculosInventario 
		Get
			return m_tran_vehiculosinventario
		End Get
		Set(ByVal value As ETRAN_VehiculosInventario)
			m_tran_vehiculosinventario = value
		End Set
	End Property

	Public Property ListTRAN_VehiculosInventario() As List(Of ETRAN_VehiculosInventario)
		Get
			return m_listTRAN_VehiculosInventario
		End Get
		Set(ByVal value As List(Of ETRAN_VehiculosInventario))
			m_listTRAN_VehiculosInventario = value
		End Set
	End Property

	Public Property DTTRAN_VehiculosInventario() As DataTable
		Get
			return m_dtTRAN_VehiculosInventario
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_VehiculosInventario = value
		End Set
	End Property

	Public Property DSTRAN_VehiculosInventario() As DataSet
		Get
			return m_dsTRAN_VehiculosInventario
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_VehiculosInventario = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_VehiculosInventario = new List(Of ETRAN_VehiculosInventario)()
			return d_tran_vehiculosinventario.TRAN_VEHINSS_Todos(m_listTRAN_VehiculosInventario)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosInventario = new List(Of ETRAN_VehiculosInventario)()
			return d_tran_vehiculosinventario.TRAN_VEHINSS_Todos(m_listTRAN_VehiculosInventario, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosInventario = new List(Of ETRAN_VehiculosInventario)()
			return d_tran_vehiculosinventario.TRAN_VEHINSS_Todos(m_listTRAN_VehiculosInventario, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_VehiculosInventario = new List(Of ETRAN_VehiculosInventario)()
			return d_tran_vehiculosinventario.TRAN_VEHINSS_Todos(m_listTRAN_VehiculosInventario, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_vehic_id As Long) As Boolean
		Try
			m_tran_vehiculosinventario = New ETRAN_VehiculosInventario()
			Return d_tran_vehiculosinventario.TRAN_VEHINSS_Todos(m_tran_vehiculosinventario, x_vehic_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosInventario = new DataSet()
			return d_tran_vehiculosinventario.TRAN_VEHINSS_Todos(m_dsTRAN_VehiculosInventario, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosInventario = new DataSet()
			return d_tran_vehiculosinventario.TRAN_VEHINSS_Todos(m_dsTRAN_VehiculosInventario, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosInventario = new DataSet()
			Dim _opcion As Boolean = d_tran_vehiculosinventario.TRAN_VEHINSS_Todos(m_dsTRAN_VehiculosInventario, x_where)
		If _opcion Then
			m_dtTRAN_VehiculosInventario = m_dsTRAN_VehiculosInventario.Tables(0)
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
			m_dsTRAN_VehiculosInventario = new DataSet()
			Dim _opcion As Boolean = d_tran_vehiculosinventario.TRAN_VEHINSS_Todos(m_dsTRAN_VehiculosInventario, x_join, x_where)
		If _opcion Then
			m_dtTRAN_VehiculosInventario = m_dsTRAN_VehiculosInventario.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_vehic_id As Long, x_vehin_id As Long) As Boolean
		Try
			m_tran_vehiculosinventario = New ETRAN_VehiculosInventario()
			Return d_tran_vehiculosinventario.TRAN_VEHINSS_UnReg(m_tran_vehiculosinventario, x_vehic_id, x_vehin_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_vehiculosinventario = New ETRAN_VehiculosInventario()
			Return d_tran_vehiculosinventario.TRAN_VEHINSS_UnReg(m_tran_vehiculosinventario, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_vehiculosinventario = New ETRAN_VehiculosInventario()
			Return d_tran_vehiculosinventario.TRAN_VEHINSS_UnReg(m_tran_vehiculosinventario, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_vehiculosinventario.Nuevo Then
				d_tran_vehiculosinventario.TRAN_VEHINSI_UnReg(m_tran_vehiculosinventario, x_usuario)
			ElseIf m_tran_vehiculosinventario.Modificado Then
				d_tran_vehiculosinventario.TRAN_VEHINSU_UnReg(m_tran_vehiculosinventario, x_usuario)
			ElseIf m_tran_vehiculosinventario.Eliminado Then
				d_tran_vehiculosinventario.TRAN_VEHINSD_UnReg(TRAN_VehiculosInventario)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_vehiculosinventario.Nuevo Then
				d_tran_vehiculosinventario.TRAN_VEHINSI_UnReg(m_tran_vehiculosinventario, x_usuario)
			ElseIf m_tran_vehiculosinventario.Modificado Then
				d_tran_vehiculosinventario.TRAN_VEHINSU_UnReg(m_tran_vehiculosinventario, x_where, x_usuario)
			ElseIf m_tran_vehiculosinventario.Eliminado Then
				d_tran_vehiculosinventario.TRAN_VEHINSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosinventario.Nuevo Then
				d_tran_vehiculosinventario.TRAN_VEHINSI_UnReg(m_tran_vehiculosinventario, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosinventario.Modificado Then
				d_tran_vehiculosinventario.TRAN_VEHINSU_UnReg(m_tran_vehiculosinventario, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosinventario.Eliminado Then
				d_tran_vehiculosinventario.TRAN_VEHINSD_UnReg(TRAN_VehiculosInventario)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_vehiculosinventario.Nuevo Then
				d_tran_vehiculosinventario.TRAN_VEHINSI_UnReg(m_tran_vehiculosinventario, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosinventario.Modificado Then
				d_tran_vehiculosinventario.TRAN_VEHINSU_UnReg(m_tran_vehiculosinventario, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_vehiculosinventario.Eliminado Then
				d_tran_vehiculosinventario.TRAN_VEHINSD_UnReg(TRAN_VehiculosInventario)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosinventario.Nuevo Then
				d_tran_vehiculosinventario.TRAN_VEHINSI_UnReg(m_tran_vehiculosinventario, x_usuario, x_setfecha)
			ElseIf m_tran_vehiculosinventario.Modificado Then
				d_tran_vehiculosinventario.TRAN_VEHINSU_UnReg(m_tran_vehiculosinventario, x_usuario, x_setfecha)
			ElseIf m_tran_vehiculosinventario.Eliminado Then
				d_tran_vehiculosinventario.TRAN_VEHINSD_UnReg(TRAN_VehiculosInventario)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosinventario.Nuevo Then
				d_tran_vehiculosinventario.TRAN_VEHINSI_UnReg(m_tran_vehiculosinventario, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosinventario.Eliminado Then
				d_tran_vehiculosinventario.TRAN_VEHINSD_UnReg(TRAN_VehiculosInventario)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosInventario = new List(Of ETRAN_VehiculosInventario)()
			return d_tran_vehiculosinventario.TRAN_VEHINSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_vehiculosinventario.getCorrelativo("VEHIC_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_vehiculosinventario.getCorrelativo("VEHIC_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_vehiculosinventario.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_vehiculosinventario.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_vehiculosinventario.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_vehiculosinventario.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

