Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_ViajesVentas

#Region " Variables "
	
	Private m_tran_viajesventas As ETRAN_ViajesVentas
	Private m_listTRAN_ViajesVentas As List(Of ETRAN_ViajesVentas)
	Private m_dtTRAN_ViajesVentas As DataTable

	Private m_dsTRAN_ViajesVentas As DataSet
	Private d_tran_viajesventas As DTRAN_ViajesVentas 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_viajesventas = New DTRAN_ViajesVentas()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_ViajesVentas() As ETRAN_ViajesVentas 
		Get
			return m_tran_viajesventas
		End Get
		Set(ByVal value As ETRAN_ViajesVentas)
			m_tran_viajesventas = value
		End Set
	End Property
	Public Property ListTRAN_ViajesVentas() As List(Of ETRAN_ViajesVentas)
		Get
			return m_listTRAN_ViajesVentas
		End Get
		Set(ByVal value As List(Of ETRAN_ViajesVentas))
			m_listTRAN_ViajesVentas = value
		End Set
	End Property
	Public Property DTTRAN_ViajesVentas() As DataTable
		Get
			return m_dtTRAN_ViajesVentas
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_ViajesVentas = value
		End Set
	End Property
	Public Property DSTRAN_ViajesVentas() As DataSet
		Get
			return m_dsTRAN_ViajesVentas
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_ViajesVentas = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	
		Public Function getTRAN_ViajesVentas() As ETRAN_ViajesVentas
			Return Me.m_tran_viajesventas
		End Function
		Public Sub setTRAN_ViajesVentas(ByVal x_tran_viajesventas As ETRAN_ViajesVentas)
			Me.m_tran_viajesventas = x_tran_viajesventas 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_ViajesVentas = new List(Of ETRAN_ViajesVentas)()
			return d_tran_viajesventas.TRAN_TRANSS_Todos(m_listTRAN_ViajesVentas)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_ViajesVentas = new List(Of ETRAN_ViajesVentas)()
			return d_tran_viajesventas.TRAN_TRANSS_Todos(m_listTRAN_ViajesVentas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_ViajesVentas = new List(Of ETRAN_ViajesVentas)()
			return d_tran_viajesventas.TRAN_TRANSS_Todos(m_listTRAN_ViajesVentas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_ViajesVentas = new List(Of ETRAN_ViajesVentas)()
			return d_tran_viajesventas.TRAN_TRANSS_Todos(m_listTRAN_ViajesVentas, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_ViajesVentas = new DataSet()
			return d_tran_viajesventas.TRAN_TRANSS_Todos(m_dsTRAN_ViajesVentas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_ViajesVentas = new DataSet()
			return d_tran_viajesventas.TRAN_TRANSS_Todos(m_dsTRAN_ViajesVentas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_ViajesVentas = new DataSet()
			Dim _opcion As Boolean = d_tran_viajesventas.TRAN_TRANSS_Todos(m_dsTRAN_ViajesVentas, x_where)
		If _opcion Then
			m_dtTRAN_ViajesVentas = m_dsTRAN_ViajesVentas.Tables(0)
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
			m_dsTRAN_ViajesVentas = new DataSet()
			Dim _opcion As Boolean = d_tran_viajesventas.TRAN_TRANSS_Todos(m_dsTRAN_ViajesVentas, x_join, x_where)
		If _opcion Then
			m_dtTRAN_ViajesVentas = m_dsTRAN_ViajesVentas.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_viajesventas.Nuevo Then
				d_tran_viajesventas.TRAN_TRANSI_UnReg(m_tran_viajesventas, x_usuario)
			ElseIf m_tran_viajesventas.Eliminado Then
				d_tran_viajesventas.TRAN_TRANSD_UnReg(m_tran_viajesventas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_viajesventas.Nuevo Then
				d_tran_viajesventas.TRAN_TRANSI_UnReg(m_tran_viajesventas, x_usuario)
			ElseIf m_tran_viajesventas.Eliminado Then
				d_tran_viajesventas.TRAN_TRANSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_viajesventas.Nuevo Then
				d_tran_viajesventas.TRAN_TRANSI_UnReg(m_tran_viajesventas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_viajesventas.Eliminado Then
				d_tran_viajesventas.TRAN_TRANSD_UnReg(m_tran_viajesventas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_viajesventas.Nuevo Then
				d_tran_viajesventas.TRAN_TRANSI_UnReg(m_tran_viajesventas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_viajesventas.Eliminado Then
				d_tran_viajesventas.TRAN_TRANSD_UnReg(m_tran_viajesventas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_viajesventas.Nuevo Then
				d_tran_viajesventas.TRAN_TRANSI_UnReg(m_tran_viajesventas, x_usuario, x_setfecha)
			ElseIf m_tran_viajesventas.Eliminado Then
				d_tran_viajesventas.TRAN_TRANSD_UnReg(m_tran_viajesventas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_viajesventas.Nuevo Then
				d_tran_viajesventas.TRAN_TRANSI_UnReg(m_tran_viajesventas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_viajesventas.Eliminado Then
				d_tran_viajesventas.TRAN_TRANSD_UnReg(m_tran_viajesventas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_ViajesVentas = new List(Of ETRAN_ViajesVentas)()
			return d_tran_viajesventas.TRAN_TRANSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_viajesventas.getCorrelativo("VIAJE_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_viajesventas.getCorrelativo("VIAJE_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_viajesventas.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_viajesventas.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_viajesventas.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_viajesventas.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

