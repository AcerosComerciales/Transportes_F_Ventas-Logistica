Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_VehiculosMantenimientoDetalle

#Region " Variables "
	
	Private m_tran_vehiculosmantenimientodetalle As ETRAN_VehiculosMantenimientoDetalle
	Private m_listTRAN_VehiculosMantenimientoDetalle As List(Of ETRAN_VehiculosMantenimientoDetalle)
	Private m_dtTRAN_VehiculosMantenimientoDetalle As DataTable

	Private m_dsTRAN_VehiculosMantenimientoDetalle As DataSet
	Private d_tran_vehiculosmantenimientodetalle As DTRAN_VehiculosMantenimientoDetalle 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_vehiculosmantenimientodetalle = New DTRAN_VehiculosMantenimientoDetalle()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_VehiculosMantenimientoDetalle() As ETRAN_VehiculosMantenimientoDetalle 
		Get
			return m_tran_vehiculosmantenimientodetalle
		End Get
		Set(ByVal value As ETRAN_VehiculosMantenimientoDetalle)
			m_tran_vehiculosmantenimientodetalle = value
		End Set
	End Property

	Public Property ListTRAN_VehiculosMantenimientoDetalle() As List(Of ETRAN_VehiculosMantenimientoDetalle)
		Get
			return m_listTRAN_VehiculosMantenimientoDetalle
		End Get
		Set(ByVal value As List(Of ETRAN_VehiculosMantenimientoDetalle))
			m_listTRAN_VehiculosMantenimientoDetalle = value
		End Set
	End Property

	Public Property DTTRAN_VehiculosMantenimientoDetalle() As DataTable
		Get
			return m_dtTRAN_VehiculosMantenimientoDetalle
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_VehiculosMantenimientoDetalle = value
		End Set
	End Property

	Public Property DSTRAN_VehiculosMantenimientoDetalle() As DataSet
		Get
			return m_dsTRAN_VehiculosMantenimientoDetalle
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_VehiculosMantenimientoDetalle = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "

    Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_VehiculosMantenimientoDetalle = new List(Of ETRAN_VehiculosMantenimientoDetalle)()
			return d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSS_Todos(m_listTRAN_VehiculosMantenimientoDetalle)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosMantenimientoDetalle = new List(Of ETRAN_VehiculosMantenimientoDetalle)()
			return d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSS_Todos(m_listTRAN_VehiculosMantenimientoDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosMantenimientoDetalle = new List(Of ETRAN_VehiculosMantenimientoDetalle)()
			return d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSS_Todos(m_listTRAN_VehiculosMantenimientoDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_VehiculosMantenimientoDetalle = new List(Of ETRAN_VehiculosMantenimientoDetalle)()
			return d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSS_Todos(m_listTRAN_VehiculosMantenimientoDetalle, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_vehic_id As Long, ByVal x_vman_item As Long) As Boolean
		Try
			m_tran_vehiculosmantenimientodetalle = New ETRAN_VehiculosMantenimientoDetalle()
			Return d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSS_Todos(m_tran_vehiculosmantenimientodetalle, x_vehic_id, x_vman_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosMantenimientoDetalle = new DataSet()
			return d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSS_Todos(m_dsTRAN_VehiculosMantenimientoDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosMantenimientoDetalle = new DataSet()
			return d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSS_Todos(m_dsTRAN_VehiculosMantenimientoDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosMantenimientoDetalle = new DataSet()
			Dim _opcion As Boolean = d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSS_Todos(m_dsTRAN_VehiculosMantenimientoDetalle, x_where)
		If _opcion Then
			m_dtTRAN_VehiculosMantenimientoDetalle = m_dsTRAN_VehiculosMantenimientoDetalle.Tables(0)
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
			m_dsTRAN_VehiculosMantenimientoDetalle = new DataSet()
			Dim _opcion As Boolean = d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSS_Todos(m_dsTRAN_VehiculosMantenimientoDetalle, x_join, x_where)
		If _opcion Then
			m_dtTRAN_VehiculosMantenimientoDetalle = m_dsTRAN_VehiculosMantenimientoDetalle.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_vehic_id As Long, x_vman_item As Long, x_vmdet_item As Short) As Boolean
		Try
			m_tran_vehiculosmantenimientodetalle = New ETRAN_VehiculosMantenimientoDetalle()
			Return d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSS_UnReg(m_tran_vehiculosmantenimientodetalle, x_vehic_id, x_vman_item, x_vmdet_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_vehiculosmantenimientodetalle = New ETRAN_VehiculosMantenimientoDetalle()
			Return d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSS_UnReg(m_tran_vehiculosmantenimientodetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_vehiculosmantenimientodetalle = New ETRAN_VehiculosMantenimientoDetalle()
			Return d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSS_UnReg(m_tran_vehiculosmantenimientodetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_vehiculosmantenimientodetalle.Nuevo Then
				d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSI_UnReg(m_tran_vehiculosmantenimientodetalle, x_usuario)
			ElseIf m_tran_vehiculosmantenimientodetalle.Modificado Then
				d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSU_UnReg(m_tran_vehiculosmantenimientodetalle, x_usuario)
			ElseIf m_tran_vehiculosmantenimientodetalle.Eliminado Then
				d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSD_UnReg(TRAN_VehiculosMantenimientoDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_vehiculosmantenimientodetalle.Nuevo Then
				d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSI_UnReg(m_tran_vehiculosmantenimientodetalle, x_usuario)
			ElseIf m_tran_vehiculosmantenimientodetalle.Modificado Then
				d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSU_UnReg(m_tran_vehiculosmantenimientodetalle, x_where, x_usuario)
			ElseIf m_tran_vehiculosmantenimientodetalle.Eliminado Then
				d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosmantenimientodetalle.Nuevo Then
				d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSI_UnReg(m_tran_vehiculosmantenimientodetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosmantenimientodetalle.Modificado Then
				d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSU_UnReg(m_tran_vehiculosmantenimientodetalle, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosmantenimientodetalle.Eliminado Then
				d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSD_UnReg(TRAN_VehiculosMantenimientoDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_vehiculosmantenimientodetalle.Nuevo Then
				d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSI_UnReg(m_tran_vehiculosmantenimientodetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosmantenimientodetalle.Modificado Then
				d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSU_UnReg(m_tran_vehiculosmantenimientodetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_vehiculosmantenimientodetalle.Eliminado Then
				d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSD_UnReg(TRAN_VehiculosMantenimientoDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosmantenimientodetalle.Nuevo Then
				d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSI_UnReg(m_tran_vehiculosmantenimientodetalle, x_usuario, x_setfecha)
			ElseIf m_tran_vehiculosmantenimientodetalle.Modificado Then
				d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSU_UnReg(m_tran_vehiculosmantenimientodetalle, x_usuario, x_setfecha)
			ElseIf m_tran_vehiculosmantenimientodetalle.Eliminado Then
				d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSD_UnReg(TRAN_VehiculosMantenimientoDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosmantenimientodetalle.Nuevo Then
				d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSI_UnReg(m_tran_vehiculosmantenimientodetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosmantenimientodetalle.Eliminado Then
				d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSD_UnReg(TRAN_VehiculosMantenimientoDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosMantenimientoDetalle = new List(Of ETRAN_VehiculosMantenimientoDetalle)()
			return d_tran_vehiculosmantenimientodetalle.TRAN_VMDETSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_vehiculosmantenimientodetalle.getCorrelativo("VEHIC_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_vehiculosmantenimientodetalle.getCorrelativo("VEHIC_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_vehiculosmantenimientodetalle.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_vehiculosmantenimientodetalle.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_vehiculosmantenimientodetalle.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_vehiculosmantenimientodetalle.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

