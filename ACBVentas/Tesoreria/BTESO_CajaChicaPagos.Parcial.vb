Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BTESO_CajaChicaPagos

#Region " Variables "
	
	Private m_eteso_cajachicapagos As ETESO_CajaChicaPagos
	Private m_listTESO_CajaChicaPagos As List(Of ETESO_CajaChicaPagos)
	Private m_dtTESO_CajaChicaPagos As DataTable

	Private m_dsTESO_CajaChicaPagos As DataSet



#End Region

#Region " Constructores "

    Public Sub New()
		d_teso_cajachicapagos = New DTESO_CajaChicaPagos()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TESO_CajaChicaPagos() As ETESO_CajaChicaPagos 
		Get
			return m_eteso_cajachicapagos
		End Get
		Set(ByVal value As ETESO_CajaChicaPagos)
			m_eteso_cajachicapagos = value
		End Set
	End Property

	Public Property ListTESO_CajaChicaPagos() As List(Of ETESO_CajaChicaPagos)
		Get
			return m_listTESO_CajaChicaPagos
		End Get
		Set(ByVal value As List(Of ETESO_CajaChicaPagos))
			m_listTESO_CajaChicaPagos = value
		End Set
	End Property

	Public Property DTTESO_CajaChicaPagos() As DataTable
		Get
			return m_dtTESO_CajaChicaPagos
		End Get
		Set(ByVal value As DataTable)
			m_dtTESO_CajaChicaPagos = value
		End Set
	End Property

	Public Property DSTESO_CajaChicaPagos() As DataSet
		Get
			return m_dsTESO_CajaChicaPagos
		End Get
		Set(ByVal value As DataSet)
			m_dsTESO_CajaChicaPagos = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTESO_CajaChicaPagos = new List(Of ETESO_CajaChicaPagos)()
			return d_teso_cajachicapagos.TESO_CAJAPSS_Todos(m_listTESO_CajaChicaPagos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_CajaChicaPagos = new List(Of ETESO_CajaChicaPagos)()
			return d_teso_cajachicapagos.TESO_CAJAPSS_Todos(m_listTESO_CajaChicaPagos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_CajaChicaPagos = new List(Of ETESO_CajaChicaPagos)()
			return d_teso_cajachicapagos.TESO_CAJAPSS_Todos(m_listTESO_CajaChicaPagos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTESO_CajaChicaPagos = new List(Of ETESO_CajaChicaPagos)()
			return d_teso_cajachicapagos.TESO_CAJAPSS_Todos(m_listTESO_CajaChicaPagos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_pvent_id As Long, ByVal x_cajac_id As Long) As Boolean
		Try
			m_eteso_cajachicapagos = New ETESO_CajaChicaPagos()
			Return d_teso_cajachicapagos.TESO_CAJAPSS_Todos(m_eteso_cajachicapagos, x_pvent_id, x_cajac_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_CajaChicaPagos = new DataSet()
			return d_teso_cajachicapagos.TESO_CAJAPSS_Todos(m_dsTESO_CajaChicaPagos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_CajaChicaPagos = new DataSet()
			return d_teso_cajachicapagos.TESO_CAJAPSS_Todos(m_dsTESO_CajaChicaPagos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_CajaChicaPagos = new DataSet()
			Dim _opcion As Boolean = d_teso_cajachicapagos.TESO_CAJAPSS_Todos(m_dsTESO_CajaChicaPagos, x_where)
		If _opcion Then
			m_dtTESO_CajaChicaPagos = m_dsTESO_CajaChicaPagos.Tables(0)
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
			m_dsTESO_CajaChicaPagos = new DataSet()
			Dim _opcion As Boolean = d_teso_cajachicapagos.TESO_CAJAPSS_Todos(m_dsTESO_CajaChicaPagos, x_join, x_where)
		If _opcion Then
			m_dtTESO_CajaChicaPagos = m_dsTESO_CajaChicaPagos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_pvent_id As Long, x_cajac_id As Long, x_cajap_item As Short) As Boolean
		Try
			m_eteso_cajachicapagos = New ETESO_CajaChicaPagos()
			Return d_teso_cajachicapagos.TESO_CAJAPSS_UnReg(m_eteso_cajachicapagos, x_pvent_id, x_cajac_id, x_cajap_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_cajachicapagos = New ETESO_CajaChicaPagos()
			Return d_teso_cajachicapagos.TESO_CAJAPSS_UnReg(m_eteso_cajachicapagos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_cajachicapagos = New ETESO_CajaChicaPagos()
			Return d_teso_cajachicapagos.TESO_CAJAPSS_UnReg(m_eteso_cajachicapagos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_cajachicapagos.Nuevo Then
				d_teso_cajachicapagos.TESO_CAJAPSI_UnReg(m_eteso_cajachicapagos, x_usuario)
			ElseIf m_eteso_cajachicapagos.Modificado Then
				d_teso_cajachicapagos.TESO_CAJAPSU_UnReg(m_eteso_cajachicapagos, x_usuario)
			ElseIf m_eteso_cajachicapagos.Eliminado Then
				d_teso_cajachicapagos.TESO_CAJAPSD_UnReg(TESO_CajaChicaPagos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_cajachicapagos.Nuevo Then
				d_teso_cajachicapagos.TESO_CAJAPSI_UnReg(m_eteso_cajachicapagos, x_usuario)
			ElseIf m_eteso_cajachicapagos.Modificado Then
				d_teso_cajachicapagos.TESO_CAJAPSU_UnReg(m_eteso_cajachicapagos, x_where, x_usuario)
			ElseIf m_eteso_cajachicapagos.Eliminado Then
				d_teso_cajachicapagos.TESO_CAJAPSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_cajachicapagos.Nuevo Then
				d_teso_cajachicapagos.TESO_CAJAPSI_UnReg(m_eteso_cajachicapagos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_cajachicapagos.Modificado Then
				d_teso_cajachicapagos.TESO_CAJAPSU_UnReg(m_eteso_cajachicapagos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_cajachicapagos.Eliminado Then
				d_teso_cajachicapagos.TESO_CAJAPSD_UnReg(TESO_CajaChicaPagos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eteso_cajachicapagos.Nuevo Then
				d_teso_cajachicapagos.TESO_CAJAPSI_UnReg(m_eteso_cajachicapagos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_cajachicapagos.Modificado Then
				d_teso_cajachicapagos.TESO_CAJAPSU_UnReg(m_eteso_cajachicapagos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_eteso_cajachicapagos.Eliminado Then
				d_teso_cajachicapagos.TESO_CAJAPSD_UnReg(TESO_CajaChicaPagos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_cajachicapagos.Nuevo Then
				d_teso_cajachicapagos.TESO_CAJAPSI_UnReg(m_eteso_cajachicapagos, x_usuario, x_setfecha)
			ElseIf m_eteso_cajachicapagos.Modificado Then
				d_teso_cajachicapagos.TESO_CAJAPSU_UnReg(m_eteso_cajachicapagos, x_usuario, x_setfecha)
			ElseIf m_eteso_cajachicapagos.Eliminado Then
				d_teso_cajachicapagos.TESO_CAJAPSD_UnReg(TESO_CajaChicaPagos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_cajachicapagos.Nuevo Then
				d_teso_cajachicapagos.TESO_CAJAPSI_UnReg(m_eteso_cajachicapagos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_cajachicapagos.Eliminado Then
				d_teso_cajachicapagos.TESO_CAJAPSD_UnReg(TESO_CajaChicaPagos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_CajaChicaPagos = new List(Of ETESO_CajaChicaPagos)()
			return d_teso_cajachicapagos.TESO_CAJAPSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_teso_cajachicapagos.getCorrelativo("PVENT_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_teso_cajachicapagos.getCorrelativo("PVENT_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_teso_cajachicapagos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_teso_cajachicapagos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_teso_cajachicapagos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_teso_cajachicapagos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

