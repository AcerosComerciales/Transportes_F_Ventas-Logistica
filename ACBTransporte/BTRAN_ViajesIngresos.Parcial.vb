Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_ViajesIngresos

#Region " Variables "
	
	Private m_tran_viajesingresos As ETRAN_ViajesIngresos
	Private m_listTRAN_ViajesIngresos As List(Of ETRAN_ViajesIngresos)
	Private m_dtTRAN_ViajesIngresos As DataTable

	Private m_dsTRAN_ViajesIngresos As DataSet
	Private d_tran_viajesingresos As DTRAN_ViajesIngresos 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_viajesingresos = New DTRAN_ViajesIngresos()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_ViajesIngresos() As ETRAN_ViajesIngresos 
		Get
			return m_tran_viajesingresos
		End Get
		Set(ByVal value As ETRAN_ViajesIngresos)
			m_tran_viajesingresos = value
		End Set
	End Property
	Public Property ListTRAN_ViajesIngresos() As List(Of ETRAN_ViajesIngresos)
		Get
			return m_listTRAN_ViajesIngresos
		End Get
		Set(ByVal value As List(Of ETRAN_ViajesIngresos))
			m_listTRAN_ViajesIngresos = value
		End Set
	End Property
	Public Property DTTRAN_ViajesIngresos() As DataTable
		Get
			return m_dtTRAN_ViajesIngresos
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_ViajesIngresos = value
		End Set
	End Property
	Public Property DSTRAN_ViajesIngresos() As DataSet
		Get
			return m_dsTRAN_ViajesIngresos
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_ViajesIngresos = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_ViajesIngresos() As List(Of ETRAN_ViajesIngresos)
			Return Me.m_listTRAN_ViajesIngresos
		End Function
		Public Sub setListTRAN_ViajesIngresos(ByVal _listtran_viajesingresos As List (Of ETRAN_ViajesIngresos))
			Me.m_listTRAN_ViajesIngresos = m_listtran_viajesingresos 
		End Sub
		Public Function getTRAN_ViajesIngresos() As ETRAN_ViajesIngresos
			Return Me.m_tran_viajesingresos
		End Function
		Public Sub setTRAN_ViajesIngresos(ByVal x_tran_viajesingresos As ETRAN_ViajesIngresos)
			Me.m_tran_viajesingresos = x_tran_viajesingresos 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_ViajesIngresos = new List(Of ETRAN_ViajesIngresos)()
			return d_tran_viajesingresos.TRAN_VINGRSS_Todos(m_listTRAN_ViajesIngresos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_ViajesIngresos = new List(Of ETRAN_ViajesIngresos)()
			return d_tran_viajesingresos.TRAN_VINGRSS_Todos(m_listTRAN_ViajesIngresos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_ViajesIngresos = new List(Of ETRAN_ViajesIngresos)()
			return d_tran_viajesingresos.TRAN_VINGRSS_Todos(m_listTRAN_ViajesIngresos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_ViajesIngresos = new List(Of ETRAN_ViajesIngresos)()
			return d_tran_viajesingresos.TRAN_VINGRSS_Todos(m_listTRAN_ViajesIngresos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_viaje_id As Long) As Boolean
		Try
			m_listTRAN_ViajesIngresos = new List(Of ETRAN_ViajesIngresos)()
			Return d_tran_viajesingresos.TRAN_VINGRSS_Todos(m_listTRAN_ViajesIngresos, x_viaje_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_ViajesIngresos = new DataSet()
			return d_tran_viajesingresos.TRAN_VINGRSS_Todos(m_dsTRAN_ViajesIngresos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_ViajesIngresos = new DataSet()
			return d_tran_viajesingresos.TRAN_VINGRSS_Todos(m_dsTRAN_ViajesIngresos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_ViajesIngresos = new DataSet()
			Dim _opcion As Boolean = d_tran_viajesingresos.TRAN_VINGRSS_Todos(m_dsTRAN_ViajesIngresos, x_where)
		If _opcion Then
			m_dtTRAN_ViajesIngresos = m_dsTRAN_ViajesIngresos.Tables(0)
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
			m_dsTRAN_ViajesIngresos = new DataSet()
			Dim _opcion As Boolean = d_tran_viajesingresos.TRAN_VINGRSS_Todos(m_dsTRAN_ViajesIngresos, x_join, x_where)
		If _opcion Then
			m_dtTRAN_ViajesIngresos = m_dsTRAN_ViajesIngresos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_viaje_id As Long, x_vingr_id As Long) As Boolean
		Try
			m_tran_viajesingresos = New ETRAN_ViajesIngresos()
			Return d_tran_viajesingresos.TRAN_VINGRSS_UnReg(m_tran_viajesingresos, x_viaje_id, x_vingr_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_viajesingresos = New ETRAN_ViajesIngresos()
			Return d_tran_viajesingresos.TRAN_VINGRSS_UnReg(m_tran_viajesingresos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_viajesingresos = New ETRAN_ViajesIngresos()
			Return d_tran_viajesingresos.TRAN_VINGRSS_UnReg(m_tran_viajesingresos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_viajesingresos.Nuevo Then
				d_tran_viajesingresos.TRAN_VINGRSI_UnReg(m_tran_viajesingresos, x_usuario)
			ElseIf m_tran_viajesingresos.Modificado Then
				d_tran_viajesingresos.TRAN_VINGRSU_UnReg(m_tran_viajesingresos, x_usuario)
			ElseIf m_tran_viajesingresos.Eliminado Then
				d_tran_viajesingresos.TRAN_VINGRSD_UnReg(m_tran_viajesingresos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_viajesingresos.Nuevo Then
				d_tran_viajesingresos.TRAN_VINGRSI_UnReg(m_tran_viajesingresos, x_usuario)
			ElseIf m_tran_viajesingresos.Modificado Then
				d_tran_viajesingresos.TRAN_VINGRSU_UnReg(m_tran_viajesingresos, x_where, x_usuario)
			ElseIf m_tran_viajesingresos.Eliminado Then
				d_tran_viajesingresos.TRAN_VINGRSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_viajesingresos.Nuevo Then
				d_tran_viajesingresos.TRAN_VINGRSI_UnReg(m_tran_viajesingresos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_viajesingresos.Modificado Then
				d_tran_viajesingresos.TRAN_VINGRSU_UnReg(m_tran_viajesingresos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_viajesingresos.Eliminado Then
				d_tran_viajesingresos.TRAN_VINGRSD_UnReg(m_tran_viajesingresos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_viajesingresos.Nuevo Then
				d_tran_viajesingresos.TRAN_VINGRSI_UnReg(m_tran_viajesingresos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_viajesingresos.Modificado Then
				d_tran_viajesingresos.TRAN_VINGRSU_UnReg(m_tran_viajesingresos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_viajesingresos.Eliminado Then
				d_tran_viajesingresos.TRAN_VINGRSD_UnReg(m_tran_viajesingresos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_viajesingresos.Nuevo Then
				d_tran_viajesingresos.TRAN_VINGRSI_UnReg(m_tran_viajesingresos, x_usuario, x_setfecha)
			ElseIf m_tran_viajesingresos.Modificado Then
				d_tran_viajesingresos.TRAN_VINGRSU_UnReg(m_tran_viajesingresos, x_usuario, x_setfecha)
			ElseIf m_tran_viajesingresos.Eliminado Then
				d_tran_viajesingresos.TRAN_VINGRSD_UnReg(m_tran_viajesingresos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_viajesingresos.Nuevo Then
				d_tran_viajesingresos.TRAN_VINGRSI_UnReg(m_tran_viajesingresos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_viajesingresos.Eliminado Then
				d_tran_viajesingresos.TRAN_VINGRSD_UnReg(m_tran_viajesingresos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_ViajesIngresos = new List(Of ETRAN_ViajesIngresos)()
			return d_tran_viajesingresos.TRAN_VINGRSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_viajesingresos.getCorrelativo("VIAJE_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_viajesingresos.getCorrelativo("VIAJE_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_viajesingresos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_viajesingresos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_viajesingresos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_viajesingresos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

