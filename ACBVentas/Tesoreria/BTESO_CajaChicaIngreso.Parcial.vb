Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BTESO_CajaChicaIngreso

#Region " Variables "
	
	Private m_eteso_cajachicaingreso As ETESO_CajaChicaIngreso
	Private m_listTESO_CajaChicaIngreso As List(Of ETESO_CajaChicaIngreso)
	Private m_dtTESO_CajaChicaIngreso As DataTable

	Private m_dsTESO_CajaChicaIngreso As DataSet
	Private d_teso_cajachicaingreso As DTESO_CajaChicaIngreso 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_teso_cajachicaingreso = New DTESO_CajaChicaIngreso()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TESO_CajaChicaIngreso() As ETESO_CajaChicaIngreso 
		Get
			return m_eteso_cajachicaingreso
		End Get
		Set(ByVal value As ETESO_CajaChicaIngreso)
			m_eteso_cajachicaingreso = value
		End Set
	End Property

	Public Property ListTESO_CajaChicaIngreso() As List(Of ETESO_CajaChicaIngreso)
		Get
			return m_listTESO_CajaChicaIngreso
		End Get
		Set(ByVal value As List(Of ETESO_CajaChicaIngreso))
			m_listTESO_CajaChicaIngreso = value
		End Set
	End Property

	Public Property DTTESO_CajaChicaIngreso() As DataTable
		Get
			return m_dtTESO_CajaChicaIngreso
		End Get
		Set(ByVal value As DataTable)
			m_dtTESO_CajaChicaIngreso = value
		End Set
	End Property

	Public Property DSTESO_CajaChicaIngreso() As DataSet
		Get
			return m_dsTESO_CajaChicaIngreso
		End Get
		Set(ByVal value As DataSet)
			m_dsTESO_CajaChicaIngreso = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTESO_CajaChicaIngreso = new List(Of ETESO_CajaChicaIngreso)()
			return d_teso_cajachicaingreso.TESO_CAJACSS_Todos(m_listTESO_CajaChicaIngreso)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_CajaChicaIngreso = new List(Of ETESO_CajaChicaIngreso)()
			return d_teso_cajachicaingreso.TESO_CAJACSS_Todos(m_listTESO_CajaChicaIngreso, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_CajaChicaIngreso = new List(Of ETESO_CajaChicaIngreso)()
			return d_teso_cajachicaingreso.TESO_CAJACSS_Todos(m_listTESO_CajaChicaIngreso, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTESO_CajaChicaIngreso = new List(Of ETESO_CajaChicaIngreso)()
			return d_teso_cajachicaingreso.TESO_CAJACSS_Todos(m_listTESO_CajaChicaIngreso, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_pvent_id As Long) As Boolean
		Try
			m_eteso_cajachicaingreso = New ETESO_CajaChicaIngreso()
			Return d_teso_cajachicaingreso.TESO_CAJACSS_Todos(m_eteso_cajachicaingreso, x_pvent_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_CajaChicaIngreso = new DataSet()
			return d_teso_cajachicaingreso.TESO_CAJACSS_Todos(m_dsTESO_CajaChicaIngreso, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_CajaChicaIngreso = new DataSet()
			return d_teso_cajachicaingreso.TESO_CAJACSS_Todos(m_dsTESO_CajaChicaIngreso, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_CajaChicaIngreso = new DataSet()
			Dim _opcion As Boolean = d_teso_cajachicaingreso.TESO_CAJACSS_Todos(m_dsTESO_CajaChicaIngreso, x_where)
		If _opcion Then
			m_dtTESO_CajaChicaIngreso = m_dsTESO_CajaChicaIngreso.Tables(0)
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
			m_dsTESO_CajaChicaIngreso = new DataSet()
			Dim _opcion As Boolean = d_teso_cajachicaingreso.TESO_CAJACSS_Todos(m_dsTESO_CajaChicaIngreso, x_join, x_where)
		If _opcion Then
			m_dtTESO_CajaChicaIngreso = m_dsTESO_CajaChicaIngreso.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_pvent_id As Long, x_cajac_id As Long) As Boolean
		Try
			m_eteso_cajachicaingreso = New ETESO_CajaChicaIngreso()
			Return d_teso_cajachicaingreso.TESO_CAJACSS_UnReg(m_eteso_cajachicaingreso, x_pvent_id, x_cajac_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_cajachicaingreso = New ETESO_CajaChicaIngreso()
			Return d_teso_cajachicaingreso.TESO_CAJACSS_UnReg(m_eteso_cajachicaingreso, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_cajachicaingreso = New ETESO_CajaChicaIngreso()
			Return d_teso_cajachicaingreso.TESO_CAJACSS_UnReg(m_eteso_cajachicaingreso, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_cajachicaingreso.Nuevo Then
				d_teso_cajachicaingreso.TESO_CAJACSI_UnReg(m_eteso_cajachicaingreso, x_usuario)
			ElseIf m_eteso_cajachicaingreso.Modificado Then
				d_teso_cajachicaingreso.TESO_CAJACSU_UnReg(m_eteso_cajachicaingreso, x_usuario)
			ElseIf m_eteso_cajachicaingreso.Eliminado Then
				d_teso_cajachicaingreso.TESO_CAJACSD_UnReg(TESO_CajaChicaIngreso)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_cajachicaingreso.Nuevo Then
				d_teso_cajachicaingreso.TESO_CAJACSI_UnReg(m_eteso_cajachicaingreso, x_usuario)
			ElseIf m_eteso_cajachicaingreso.Modificado Then
				d_teso_cajachicaingreso.TESO_CAJACSU_UnReg(m_eteso_cajachicaingreso, x_where, x_usuario)
			ElseIf m_eteso_cajachicaingreso.Eliminado Then
				d_teso_cajachicaingreso.TESO_CAJACSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_cajachicaingreso.Nuevo Then
				d_teso_cajachicaingreso.TESO_CAJACSI_UnReg(m_eteso_cajachicaingreso, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_cajachicaingreso.Modificado Then
				d_teso_cajachicaingreso.TESO_CAJACSU_UnReg(m_eteso_cajachicaingreso, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_cajachicaingreso.Eliminado Then
				d_teso_cajachicaingreso.TESO_CAJACSD_UnReg(TESO_CajaChicaIngreso)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eteso_cajachicaingreso.Nuevo Then
				d_teso_cajachicaingreso.TESO_CAJACSI_UnReg(m_eteso_cajachicaingreso, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_cajachicaingreso.Modificado Then
				d_teso_cajachicaingreso.TESO_CAJACSU_UnReg(m_eteso_cajachicaingreso, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_eteso_cajachicaingreso.Eliminado Then
				d_teso_cajachicaingreso.TESO_CAJACSD_UnReg(TESO_CajaChicaIngreso)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_cajachicaingreso.Nuevo Then
				d_teso_cajachicaingreso.TESO_CAJACSI_UnReg(m_eteso_cajachicaingreso, x_usuario, x_setfecha)
			ElseIf m_eteso_cajachicaingreso.Modificado Then
				d_teso_cajachicaingreso.TESO_CAJACSU_UnReg(m_eteso_cajachicaingreso, x_usuario, x_setfecha)
			ElseIf m_eteso_cajachicaingreso.Eliminado Then
				d_teso_cajachicaingreso.TESO_CAJACSD_UnReg(TESO_CajaChicaIngreso)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_cajachicaingreso.Nuevo Then
				d_teso_cajachicaingreso.TESO_CAJACSI_UnReg(m_eteso_cajachicaingreso, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_cajachicaingreso.Eliminado Then
				d_teso_cajachicaingreso.TESO_CAJACSD_UnReg(TESO_CajaChicaIngreso)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_CajaChicaIngreso = new List(Of ETESO_CajaChicaIngreso)()
			return d_teso_cajachicaingreso.TESO_CAJACSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_teso_cajachicaingreso.getCorrelativo("PVENT_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_teso_cajachicaingreso.getCorrelativo("PVENT_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_teso_cajachicaingreso.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_teso_cajachicaingreso.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_teso_cajachicaingreso.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_teso_cajachicaingreso.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

