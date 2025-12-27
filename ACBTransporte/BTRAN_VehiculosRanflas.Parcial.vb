Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_VehiculosRanflas

#Region " Variables "
	
	Private m_tran_vehiculosranflas As ETRAN_VehiculosRanflas
	Private m_listTRAN_VehiculosRanflas As List(Of ETRAN_VehiculosRanflas)
	Private m_dtTRAN_VehiculosRanflas As DataTable

	Private m_dsTRAN_VehiculosRanflas As DataSet
	Private d_tran_vehiculosranflas As DTRAN_VehiculosRanflas 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_vehiculosranflas = New DTRAN_VehiculosRanflas()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_VehiculosRanflas() As ETRAN_VehiculosRanflas 
		Get
			return m_tran_vehiculosranflas
		End Get
		Set(ByVal value As ETRAN_VehiculosRanflas)
			m_tran_vehiculosranflas = value
		End Set
	End Property
	Public Property ListTRAN_VehiculosRanflas() As List(Of ETRAN_VehiculosRanflas)
		Get
			return m_listTRAN_VehiculosRanflas
		End Get
		Set(ByVal value As List(Of ETRAN_VehiculosRanflas))
			m_listTRAN_VehiculosRanflas = value
		End Set
	End Property
	Public Property DTTRAN_VehiculosRanflas() As DataTable
		Get
			return m_dtTRAN_VehiculosRanflas
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_VehiculosRanflas = value
		End Set
	End Property
	Public Property DSTRAN_VehiculosRanflas() As DataSet
		Get
			return m_dsTRAN_VehiculosRanflas
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_VehiculosRanflas = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_VehiculosRanflas() As List(Of ETRAN_VehiculosRanflas)
			Return Me.m_listTRAN_VehiculosRanflas
		End Function
		Public Sub setListTRAN_VehiculosRanflas(ByVal _listtran_vehiculosranflas As List (Of ETRAN_VehiculosRanflas))
			Me.m_listTRAN_VehiculosRanflas = m_listtran_vehiculosranflas 
		End Sub
		Public Function getTRAN_VehiculosRanflas() As ETRAN_VehiculosRanflas
			Return Me.m_tran_vehiculosranflas
		End Function
		Public Sub setTRAN_VehiculosRanflas(ByVal x_tran_vehiculosranflas As ETRAN_VehiculosRanflas)
			Me.m_tran_vehiculosranflas = x_tran_vehiculosranflas 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_VehiculosRanflas = new List(Of ETRAN_VehiculosRanflas)()
			return d_tran_vehiculosranflas.TRAN_VEHRNSS_Todos(m_listTRAN_VehiculosRanflas)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosRanflas = new List(Of ETRAN_VehiculosRanflas)()
			return d_tran_vehiculosranflas.TRAN_VEHRNSS_Todos(m_listTRAN_VehiculosRanflas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosRanflas = new List(Of ETRAN_VehiculosRanflas)()
			return d_tran_vehiculosranflas.TRAN_VEHRNSS_Todos(m_listTRAN_VehiculosRanflas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_VehiculosRanflas = new List(Of ETRAN_VehiculosRanflas)()
			return d_tran_vehiculosranflas.TRAN_VEHRNSS_Todos(m_listTRAN_VehiculosRanflas, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosRanflas = new DataSet()
			return d_tran_vehiculosranflas.TRAN_VEHRNSS_Todos(m_dsTRAN_VehiculosRanflas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosRanflas = new DataSet()
			return d_tran_vehiculosranflas.TRAN_VEHRNSS_Todos(m_dsTRAN_VehiculosRanflas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosRanflas = new DataSet()
			Dim _opcion As Boolean = d_tran_vehiculosranflas.TRAN_VEHRNSS_Todos(m_dsTRAN_VehiculosRanflas, x_where)
		If _opcion Then
			m_dtTRAN_VehiculosRanflas = m_dsTRAN_VehiculosRanflas.Tables(0)
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
			m_dsTRAN_VehiculosRanflas = new DataSet()
			Dim _opcion As Boolean = d_tran_vehiculosranflas.TRAN_VEHRNSS_Todos(m_dsTRAN_VehiculosRanflas, x_join, x_where)
		If _opcion Then
			m_dtTRAN_VehiculosRanflas = m_dsTRAN_VehiculosRanflas.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_vehrn_id As Long) As Boolean
		Try
			m_tran_vehiculosranflas = New ETRAN_VehiculosRanflas()
			Return d_tran_vehiculosranflas.TRAN_VEHRNSS_UnReg(m_tran_vehiculosranflas, x_vehrn_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_vehiculosranflas = New ETRAN_VehiculosRanflas()
			Return d_tran_vehiculosranflas.TRAN_VEHRNSS_UnReg(m_tran_vehiculosranflas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_vehiculosranflas = New ETRAN_VehiculosRanflas()
			Return d_tran_vehiculosranflas.TRAN_VEHRNSS_UnReg(m_tran_vehiculosranflas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_vehiculosranflas.Nuevo Then
				d_tran_vehiculosranflas.TRAN_VEHRNSI_UnReg(m_tran_vehiculosranflas, x_usuario)
			ElseIf m_tran_vehiculosranflas.Modificado Then
				d_tran_vehiculosranflas.TRAN_VEHRNSU_UnReg(m_tran_vehiculosranflas, x_usuario)
			ElseIf m_tran_vehiculosranflas.Eliminado Then
				d_tran_vehiculosranflas.TRAN_VEHRNSD_UnReg(m_tran_vehiculosranflas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_vehiculosranflas.Nuevo Then
				d_tran_vehiculosranflas.TRAN_VEHRNSI_UnReg(m_tran_vehiculosranflas, x_usuario)
			ElseIf m_tran_vehiculosranflas.Modificado Then
				d_tran_vehiculosranflas.TRAN_VEHRNSU_UnReg(m_tran_vehiculosranflas, x_where, x_usuario)
			ElseIf m_tran_vehiculosranflas.Eliminado Then
				d_tran_vehiculosranflas.TRAN_VEHRNSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosranflas.Nuevo Then
				d_tran_vehiculosranflas.TRAN_VEHRNSI_UnReg(m_tran_vehiculosranflas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosranflas.Modificado Then
				d_tran_vehiculosranflas.TRAN_VEHRNSU_UnReg(m_tran_vehiculosranflas, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosranflas.Eliminado Then
				d_tran_vehiculosranflas.TRAN_VEHRNSD_UnReg(m_tran_vehiculosranflas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_vehiculosranflas.Nuevo Then
				d_tran_vehiculosranflas.TRAN_VEHRNSI_UnReg(m_tran_vehiculosranflas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosranflas.Modificado Then
				d_tran_vehiculosranflas.TRAN_VEHRNSU_UnReg(m_tran_vehiculosranflas, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_vehiculosranflas.Eliminado Then
				d_tran_vehiculosranflas.TRAN_VEHRNSD_UnReg(m_tran_vehiculosranflas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosranflas.Nuevo Then
				d_tran_vehiculosranflas.TRAN_VEHRNSI_UnReg(m_tran_vehiculosranflas, x_usuario, x_setfecha)
			ElseIf m_tran_vehiculosranflas.Modificado Then
				d_tran_vehiculosranflas.TRAN_VEHRNSU_UnReg(m_tran_vehiculosranflas, x_usuario, x_setfecha)
			ElseIf m_tran_vehiculosranflas.Eliminado Then
				d_tran_vehiculosranflas.TRAN_VEHRNSD_UnReg(m_tran_vehiculosranflas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosranflas.Nuevo Then
				d_tran_vehiculosranflas.TRAN_VEHRNSI_UnReg(m_tran_vehiculosranflas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosranflas.Eliminado Then
				d_tran_vehiculosranflas.TRAN_VEHRNSD_UnReg(m_tran_vehiculosranflas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosRanflas = new List(Of ETRAN_VehiculosRanflas)()
			return d_tran_vehiculosranflas.TRAN_VEHRNSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_vehiculosranflas.getCorrelativo("VEHRN_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_vehiculosranflas.getCorrelativo("VEHRN_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_vehiculosranflas.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_vehiculosranflas.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_vehiculosranflas.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_vehiculosranflas.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

