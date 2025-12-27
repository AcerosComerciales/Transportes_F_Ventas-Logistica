Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_VehiculosInventarioDetalle

#Region " Variables "
	
	Private m_tran_vehiculosinventariodetalle As ETRAN_VehiculosInventarioDetalle
	Private m_listTRAN_VehiculosInventarioDetalle As List(Of ETRAN_VehiculosInventarioDetalle)
	Private m_dtTRAN_VehiculosInventarioDetalle As DataTable

	Private m_dsTRAN_VehiculosInventarioDetalle As DataSet
	Private d_tran_vehiculosinventariodetalle As DTRAN_VehiculosInventarioDetalle 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_vehiculosinventariodetalle = New DTRAN_VehiculosInventarioDetalle()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_VehiculosInventarioDetalle() As ETRAN_VehiculosInventarioDetalle 
		Get
			return m_tran_vehiculosinventariodetalle
		End Get
		Set(ByVal value As ETRAN_VehiculosInventarioDetalle)
			m_tran_vehiculosinventariodetalle = value
		End Set
	End Property

	Public Property ListTRAN_VehiculosInventarioDetalle() As List(Of ETRAN_VehiculosInventarioDetalle)
		Get
			return m_listTRAN_VehiculosInventarioDetalle
		End Get
		Set(ByVal value As List(Of ETRAN_VehiculosInventarioDetalle))
			m_listTRAN_VehiculosInventarioDetalle = value
		End Set
	End Property

	Public Property DTTRAN_VehiculosInventarioDetalle() As DataTable
		Get
			return m_dtTRAN_VehiculosInventarioDetalle
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_VehiculosInventarioDetalle = value
		End Set
	End Property

	Public Property DSTRAN_VehiculosInventarioDetalle() As DataSet
		Get
			return m_dsTRAN_VehiculosInventarioDetalle
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_VehiculosInventarioDetalle = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_VehiculosInventarioDetalle = new List(Of ETRAN_VehiculosInventarioDetalle)()
			return d_tran_vehiculosinventariodetalle.TRAN_VEHIDSS_Todos(m_listTRAN_VehiculosInventarioDetalle)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosInventarioDetalle = new List(Of ETRAN_VehiculosInventarioDetalle)()
			return d_tran_vehiculosinventariodetalle.TRAN_VEHIDSS_Todos(m_listTRAN_VehiculosInventarioDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosInventarioDetalle = new List(Of ETRAN_VehiculosInventarioDetalle)()
			return d_tran_vehiculosinventariodetalle.TRAN_VEHIDSS_Todos(m_listTRAN_VehiculosInventarioDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_VehiculosInventarioDetalle = new List(Of ETRAN_VehiculosInventarioDetalle)()
			return d_tran_vehiculosinventariodetalle.TRAN_VEHIDSS_Todos(m_listTRAN_VehiculosInventarioDetalle, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosInventarioDetalle = new DataSet()
			return d_tran_vehiculosinventariodetalle.TRAN_VEHIDSS_Todos(m_dsTRAN_VehiculosInventarioDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosInventarioDetalle = new DataSet()
			return d_tran_vehiculosinventariodetalle.TRAN_VEHIDSS_Todos(m_dsTRAN_VehiculosInventarioDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosInventarioDetalle = new DataSet()
			Dim _opcion As Boolean = d_tran_vehiculosinventariodetalle.TRAN_VEHIDSS_Todos(m_dsTRAN_VehiculosInventarioDetalle, x_where)
		If _opcion Then
			m_dtTRAN_VehiculosInventarioDetalle = m_dsTRAN_VehiculosInventarioDetalle.Tables(0)
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
			m_dsTRAN_VehiculosInventarioDetalle = new DataSet()
			Dim _opcion As Boolean = d_tran_vehiculosinventariodetalle.TRAN_VEHIDSS_Todos(m_dsTRAN_VehiculosInventarioDetalle, x_join, x_where)
		If _opcion Then
			m_dtTRAN_VehiculosInventarioDetalle = m_dsTRAN_VehiculosInventarioDetalle.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_vehic_id As Long, x_vehin_id As Long, x_tipos_codobjeto As String) As Boolean
		Try
			m_tran_vehiculosinventariodetalle = New ETRAN_VehiculosInventarioDetalle()
			Return d_tran_vehiculosinventariodetalle.TRAN_VEHIDSS_UnReg(m_tran_vehiculosinventariodetalle, x_vehic_id, x_vehin_id, x_tipos_codobjeto)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_vehiculosinventariodetalle = New ETRAN_VehiculosInventarioDetalle()
			Return d_tran_vehiculosinventariodetalle.TRAN_VEHIDSS_UnReg(m_tran_vehiculosinventariodetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_vehiculosinventariodetalle = New ETRAN_VehiculosInventarioDetalle()
			Return d_tran_vehiculosinventariodetalle.TRAN_VEHIDSS_UnReg(m_tran_vehiculosinventariodetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_vehiculosinventariodetalle.Nuevo Then
				d_tran_vehiculosinventariodetalle.TRAN_VEHIDSI_UnReg(m_tran_vehiculosinventariodetalle, x_usuario)
			ElseIf m_tran_vehiculosinventariodetalle.Modificado Then
				d_tran_vehiculosinventariodetalle.TRAN_VEHIDSU_UnReg(m_tran_vehiculosinventariodetalle, x_usuario)
			ElseIf m_tran_vehiculosinventariodetalle.Eliminado Then
				d_tran_vehiculosinventariodetalle.TRAN_VEHIDSD_UnReg(TRAN_VehiculosInventarioDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_vehiculosinventariodetalle.Nuevo Then
				d_tran_vehiculosinventariodetalle.TRAN_VEHIDSI_UnReg(m_tran_vehiculosinventariodetalle, x_usuario)
			ElseIf m_tran_vehiculosinventariodetalle.Modificado Then
				d_tran_vehiculosinventariodetalle.TRAN_VEHIDSU_UnReg(m_tran_vehiculosinventariodetalle, x_where, x_usuario)
			ElseIf m_tran_vehiculosinventariodetalle.Eliminado Then
				d_tran_vehiculosinventariodetalle.TRAN_VEHIDSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosinventariodetalle.Nuevo Then
				d_tran_vehiculosinventariodetalle.TRAN_VEHIDSI_UnReg(m_tran_vehiculosinventariodetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosinventariodetalle.Modificado Then
				d_tran_vehiculosinventariodetalle.TRAN_VEHIDSU_UnReg(m_tran_vehiculosinventariodetalle, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosinventariodetalle.Eliminado Then
				d_tran_vehiculosinventariodetalle.TRAN_VEHIDSD_UnReg(TRAN_VehiculosInventarioDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_vehiculosinventariodetalle.Nuevo Then
				d_tran_vehiculosinventariodetalle.TRAN_VEHIDSI_UnReg(m_tran_vehiculosinventariodetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosinventariodetalle.Modificado Then
				d_tran_vehiculosinventariodetalle.TRAN_VEHIDSU_UnReg(m_tran_vehiculosinventariodetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_vehiculosinventariodetalle.Eliminado Then
				d_tran_vehiculosinventariodetalle.TRAN_VEHIDSD_UnReg(TRAN_VehiculosInventarioDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosinventariodetalle.Nuevo Then
				d_tran_vehiculosinventariodetalle.TRAN_VEHIDSI_UnReg(m_tran_vehiculosinventariodetalle, x_usuario, x_setfecha)
			ElseIf m_tran_vehiculosinventariodetalle.Modificado Then
				d_tran_vehiculosinventariodetalle.TRAN_VEHIDSU_UnReg(m_tran_vehiculosinventariodetalle, x_usuario, x_setfecha)
			ElseIf m_tran_vehiculosinventariodetalle.Eliminado Then
				d_tran_vehiculosinventariodetalle.TRAN_VEHIDSD_UnReg(TRAN_VehiculosInventarioDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosinventariodetalle.Nuevo Then
				d_tran_vehiculosinventariodetalle.TRAN_VEHIDSI_UnReg(m_tran_vehiculosinventariodetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosinventariodetalle.Eliminado Then
				d_tran_vehiculosinventariodetalle.TRAN_VEHIDSD_UnReg(TRAN_VehiculosInventarioDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosInventarioDetalle = new List(Of ETRAN_VehiculosInventarioDetalle)()
			return d_tran_vehiculosinventariodetalle.TRAN_VEHIDSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_vehiculosinventariodetalle.getCorrelativo("VEHIC_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_vehiculosinventariodetalle.getCorrelativo("VEHIC_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_vehiculosinventariodetalle.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_vehiculosinventariodetalle.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_vehiculosinventariodetalle.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_vehiculosinventariodetalle.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

