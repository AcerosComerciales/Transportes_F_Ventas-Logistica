Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BTESO_CajaDocsPago

#Region " Variables "
	
	Private m_eteso_cajadocspago As ETESO_CajaDocsPago
	Private m_listTESO_CajaDocsPago As List(Of ETESO_CajaDocsPago)
	Private m_dtTESO_CajaDocsPago As DataTable

	Private m_dsTESO_CajaDocsPago As DataSet
	Private d_teso_cajadocspago As DTESO_CajaDocsPago 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_teso_cajadocspago = New DTESO_CajaDocsPago()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TESO_CajaDocsPago() As ETESO_CajaDocsPago 
		Get
			return m_eteso_cajadocspago
		End Get
		Set(ByVal value As ETESO_CajaDocsPago)
			m_eteso_cajadocspago = value
		End Set
	End Property

	Public Property ListTESO_CajaDocsPago() As List(Of ETESO_CajaDocsPago)
		Get
			return m_listTESO_CajaDocsPago
		End Get
		Set(ByVal value As List(Of ETESO_CajaDocsPago))
			m_listTESO_CajaDocsPago = value
		End Set
	End Property

	Public Property DTTESO_CajaDocsPago() As DataTable
		Get
			return m_dtTESO_CajaDocsPago
		End Get
		Set(ByVal value As DataTable)
			m_dtTESO_CajaDocsPago = value
		End Set
	End Property

	Public Property DSTESO_CajaDocsPago() As DataSet
		Get
			return m_dsTESO_CajaDocsPago
		End Get
		Set(ByVal value As DataSet)
			m_dsTESO_CajaDocsPago = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTESO_CajaDocsPago = new List(Of ETESO_CajaDocsPago)()
			return d_teso_cajadocspago.TESO_CAJASS_Todos(m_listTESO_CajaDocsPago)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_CajaDocsPago = new List(Of ETESO_CajaDocsPago)()
			return d_teso_cajadocspago.TESO_CAJASS_Todos(m_listTESO_CajaDocsPago, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_CajaDocsPago = new List(Of ETESO_CajaDocsPago)()
			return d_teso_cajadocspago.TESO_CAJASS_Todos(m_listTESO_CajaDocsPago, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTESO_CajaDocsPago = new List(Of ETESO_CajaDocsPago)()
			return d_teso_cajadocspago.TESO_CAJASS_Todos(m_listTESO_CajaDocsPago, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_pvent_id As Long, ByVal x_dpago_id As Long) As Boolean
		Try
			m_eteso_cajadocspago = New ETESO_CajaDocsPago()
			Return d_teso_cajadocspago.TESO_CAJASS_Todos(m_eteso_cajadocspago, x_pvent_id, x_dpago_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_CajaDocsPago = new DataSet()
			return d_teso_cajadocspago.TESO_CAJASS_Todos(m_dsTESO_CajaDocsPago, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_CajaDocsPago = new DataSet()
			return d_teso_cajadocspago.TESO_CAJASS_Todos(m_dsTESO_CajaDocsPago, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_CajaDocsPago = new DataSet()
			Dim _opcion As Boolean = d_teso_cajadocspago.TESO_CAJASS_Todos(m_dsTESO_CajaDocsPago, x_where)
		If _opcion Then
			m_dtTESO_CajaDocsPago = m_dsTESO_CajaDocsPago.Tables(0)
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
			m_dsTESO_CajaDocsPago = new DataSet()
			Dim _opcion As Boolean = d_teso_cajadocspago.TESO_CAJASS_Todos(m_dsTESO_CajaDocsPago, x_join, x_where)
		If _opcion Then
			m_dtTESO_CajaDocsPago = m_dsTESO_CajaDocsPago.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_caja_codigo As String, x_pvent_id As Long, x_dpago_id As Long) As Boolean
		Try
			m_eteso_cajadocspago = New ETESO_CajaDocsPago()
			Return d_teso_cajadocspago.TESO_CAJASS_UnReg(m_eteso_cajadocspago, x_caja_codigo, x_pvent_id, x_dpago_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_cajadocspago = New ETESO_CajaDocsPago()
			Return d_teso_cajadocspago.TESO_CAJASS_UnReg(m_eteso_cajadocspago, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_cajadocspago = New ETESO_CajaDocsPago()
			Return d_teso_cajadocspago.TESO_CAJASS_UnReg(m_eteso_cajadocspago, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_cajadocspago.Nuevo Then
				d_teso_cajadocspago.TESO_CAJASI_UnReg(m_eteso_cajadocspago, x_usuario)
			ElseIf m_eteso_cajadocspago.Modificado Then
				d_teso_cajadocspago.TESO_CAJASU_UnReg(m_eteso_cajadocspago, x_usuario)
			ElseIf m_eteso_cajadocspago.Eliminado Then
				d_teso_cajadocspago.TESO_CAJASD_UnReg(TESO_CajaDocsPago)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_cajadocspago.Nuevo Then
				d_teso_cajadocspago.TESO_CAJASI_UnReg(m_eteso_cajadocspago, x_usuario)
			ElseIf m_eteso_cajadocspago.Modificado Then
				d_teso_cajadocspago.TESO_CAJASU_UnReg(m_eteso_cajadocspago, x_where, x_usuario)
			ElseIf m_eteso_cajadocspago.Eliminado Then
				d_teso_cajadocspago.TESO_CAJASD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_cajadocspago.Nuevo Then
				d_teso_cajadocspago.TESO_CAJASI_UnReg(m_eteso_cajadocspago, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_cajadocspago.Modificado Then
				d_teso_cajadocspago.TESO_CAJASU_UnReg(m_eteso_cajadocspago, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_cajadocspago.Eliminado Then
				d_teso_cajadocspago.TESO_CAJASD_UnReg(TESO_CajaDocsPago)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eteso_cajadocspago.Nuevo Then
				d_teso_cajadocspago.TESO_CAJASI_UnReg(m_eteso_cajadocspago, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_cajadocspago.Modificado Then
				d_teso_cajadocspago.TESO_CAJASU_UnReg(m_eteso_cajadocspago, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_eteso_cajadocspago.Eliminado Then
				d_teso_cajadocspago.TESO_CAJASD_UnReg(TESO_CajaDocsPago)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_cajadocspago.Nuevo Then
				d_teso_cajadocspago.TESO_CAJASI_UnReg(m_eteso_cajadocspago, x_usuario, x_setfecha)
			ElseIf m_eteso_cajadocspago.Modificado Then
				d_teso_cajadocspago.TESO_CAJASU_UnReg(m_eteso_cajadocspago, x_usuario, x_setfecha)
			ElseIf m_eteso_cajadocspago.Eliminado Then
				d_teso_cajadocspago.TESO_CAJASD_UnReg(TESO_CajaDocsPago)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_cajadocspago.Nuevo Then
				d_teso_cajadocspago.TESO_CAJASI_UnReg(m_eteso_cajadocspago, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_cajadocspago.Eliminado Then
				d_teso_cajadocspago.TESO_CAJASD_UnReg(TESO_CajaDocsPago)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_CajaDocsPago = new List(Of ETESO_CajaDocsPago)()
			return d_teso_cajadocspago.TESO_CAJASD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_teso_cajadocspago.getCorrelativo("PVENT_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_teso_cajadocspago.getCorrelativo("PVENT_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_teso_cajadocspago.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_teso_cajadocspago.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_teso_cajadocspago.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_teso_cajadocspago.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

