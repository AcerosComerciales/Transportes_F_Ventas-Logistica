Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BTESO_SIniciales

#Region " Variables "
	
	Private m_eteso_siniciales As ETESO_SIniciales
	Private m_listTESO_SIniciales As List(Of ETESO_SIniciales)
	Private m_dtTESO_SIniciales As DataTable

	Private m_dsTESO_SIniciales As DataSet
	Private d_teso_siniciales As DTESO_SIniciales 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_teso_siniciales = New DTESO_SIniciales()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TESO_SIniciales() As ETESO_SIniciales 
		Get
			return m_eteso_siniciales
		End Get
		Set(ByVal value As ETESO_SIniciales)
			m_eteso_siniciales = value
		End Set
	End Property

	Public Property ListTESO_SIniciales() As List(Of ETESO_SIniciales)
		Get
			return m_listTESO_SIniciales
		End Get
		Set(ByVal value As List(Of ETESO_SIniciales))
			m_listTESO_SIniciales = value
		End Set
	End Property

	Public Property DTTESO_SIniciales() As DataTable
		Get
			return m_dtTESO_SIniciales
		End Get
		Set(ByVal value As DataTable)
			m_dtTESO_SIniciales = value
		End Set
	End Property

	Public Property DSTESO_SIniciales() As DataSet
		Get
			return m_dsTESO_SIniciales
		End Get
		Set(ByVal value As DataSet)
			m_dsTESO_SIniciales = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTESO_SIniciales = new List(Of ETESO_SIniciales)()
			return d_teso_siniciales.TESO_SINICSS_Todos(m_listTESO_SIniciales)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_SIniciales = new List(Of ETESO_SIniciales)()
			return d_teso_siniciales.TESO_SINICSS_Todos(m_listTESO_SIniciales, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_SIniciales = new List(Of ETESO_SIniciales)()
			return d_teso_siniciales.TESO_SINICSS_Todos(m_listTESO_SIniciales, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTESO_SIniciales = new List(Of ETESO_SIniciales)()
			return d_teso_siniciales.TESO_SINICSS_Todos(m_listTESO_SIniciales, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_SIniciales = new DataSet()
			return d_teso_siniciales.TESO_SINICSS_Todos(m_dsTESO_SIniciales, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_SIniciales = new DataSet()
			return d_teso_siniciales.TESO_SINICSS_Todos(m_dsTESO_SIniciales, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_SIniciales = new DataSet()
			Dim _opcion As Boolean = d_teso_siniciales.TESO_SINICSS_Todos(m_dsTESO_SIniciales, x_where)
		If _opcion Then
			m_dtTESO_SIniciales = m_dsTESO_SIniciales.Tables(0)
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
			m_dsTESO_SIniciales = new DataSet()
			Dim _opcion As Boolean = d_teso_siniciales.TESO_SINICSS_Todos(m_dsTESO_SIniciales, x_join, x_where)
		If _opcion Then
			m_dtTESO_SIniciales = m_dsTESO_SIniciales.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_entid_codigo As String) As Boolean
		Try
			m_eteso_siniciales = New ETESO_SIniciales()
			Return d_teso_siniciales.TESO_SINICSS_UnReg(m_eteso_siniciales, x_entid_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_siniciales = New ETESO_SIniciales()
			Return d_teso_siniciales.TESO_SINICSS_UnReg(m_eteso_siniciales, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_siniciales = New ETESO_SIniciales()
			Return d_teso_siniciales.TESO_SINICSS_UnReg(m_eteso_siniciales, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_siniciales.Nuevo Then
				d_teso_siniciales.TESO_SINICSI_UnReg(m_eteso_siniciales, x_usuario)
			ElseIf m_eteso_siniciales.Modificado Then
				d_teso_siniciales.TESO_SINICSU_UnReg(m_eteso_siniciales, x_usuario)
			ElseIf m_eteso_siniciales.Eliminado Then
				d_teso_siniciales.TESO_SINICSD_UnReg(TESO_SIniciales)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_siniciales.Nuevo Then
				d_teso_siniciales.TESO_SINICSI_UnReg(m_eteso_siniciales, x_usuario)
			ElseIf m_eteso_siniciales.Modificado Then
				d_teso_siniciales.TESO_SINICSU_UnReg(m_eteso_siniciales, x_where, x_usuario)
			ElseIf m_eteso_siniciales.Eliminado Then
				d_teso_siniciales.TESO_SINICSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_siniciales.Nuevo Then
				d_teso_siniciales.TESO_SINICSI_UnReg(m_eteso_siniciales, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_siniciales.Modificado Then
				d_teso_siniciales.TESO_SINICSU_UnReg(m_eteso_siniciales, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_siniciales.Eliminado Then
				d_teso_siniciales.TESO_SINICSD_UnReg(TESO_SIniciales)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eteso_siniciales.Nuevo Then
				d_teso_siniciales.TESO_SINICSI_UnReg(m_eteso_siniciales, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_siniciales.Modificado Then
				d_teso_siniciales.TESO_SINICSU_UnReg(m_eteso_siniciales, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_eteso_siniciales.Eliminado Then
				d_teso_siniciales.TESO_SINICSD_UnReg(TESO_SIniciales)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_siniciales.Nuevo Then
				d_teso_siniciales.TESO_SINICSI_UnReg(m_eteso_siniciales, x_usuario, x_setfecha)
			ElseIf m_eteso_siniciales.Modificado Then
				d_teso_siniciales.TESO_SINICSU_UnReg(m_eteso_siniciales, x_usuario, x_setfecha)
			ElseIf m_eteso_siniciales.Eliminado Then
				d_teso_siniciales.TESO_SINICSD_UnReg(TESO_SIniciales)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_siniciales.Nuevo Then
				d_teso_siniciales.TESO_SINICSI_UnReg(m_eteso_siniciales, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_siniciales.Eliminado Then
				d_teso_siniciales.TESO_SINICSD_UnReg(TESO_SIniciales)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_SIniciales = new List(Of ETESO_SIniciales)()
			return d_teso_siniciales.TESO_SINICSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_teso_siniciales.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_teso_siniciales.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_teso_siniciales.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_teso_siniciales.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

