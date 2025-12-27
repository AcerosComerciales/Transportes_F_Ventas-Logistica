Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BDESP_Salidas

#Region " Variables "
	
	Private m_edesp_salidas As EDESP_Salidas
	Private m_listDESP_Salidas As List(Of EDESP_Salidas)
	Private m_dtDESP_Salidas As DataTable

	Private m_dsDESP_Salidas As DataSet
	Private d_desp_salidas As DDESP_Salidas 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_desp_salidas = New DDESP_Salidas()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property DESP_Salidas() As EDESP_Salidas 
		Get
			return m_edesp_salidas
		End Get
		Set(ByVal value As EDESP_Salidas)
			m_edesp_salidas = value
		End Set
	End Property

	Public Property ListDESP_Salidas() As List(Of EDESP_Salidas)
		Get
			return m_listDESP_Salidas
		End Get
		Set(ByVal value As List(Of EDESP_Salidas))
			m_listDESP_Salidas = value
		End Set
	End Property

	Public Property DTDESP_Salidas() As DataTable
		Get
			return m_dtDESP_Salidas
		End Get
		Set(ByVal value As DataTable)
			m_dtDESP_Salidas = value
		End Set
	End Property

	Public Property DSDESP_Salidas() As DataSet
		Get
			return m_dsDESP_Salidas
		End Get
		Set(ByVal value As DataSet)
			m_dsDESP_Salidas = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listDESP_Salidas = new List(Of EDESP_Salidas)()
			return d_desp_salidas.DESP_PVENTSS_Todos(m_listDESP_Salidas)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listDESP_Salidas = new List(Of EDESP_Salidas)()
			return d_desp_salidas.DESP_PVENTSS_Todos(m_listDESP_Salidas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listDESP_Salidas = new List(Of EDESP_Salidas)()
			return d_desp_salidas.DESP_PVENTSS_Todos(m_listDESP_Salidas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listDESP_Salidas = new List(Of EDESP_Salidas)()
			return d_desp_salidas.DESP_PVENTSS_Todos(m_listDESP_Salidas, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDESP_Salidas = new DataSet()
			return d_desp_salidas.DESP_PVENTSS_Todos(m_dsDESP_Salidas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDESP_Salidas = new DataSet()
			return d_desp_salidas.DESP_PVENTSS_Todos(m_dsDESP_Salidas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDESP_Salidas = new DataSet()
			Dim _opcion As Boolean = d_desp_salidas.DESP_PVENTSS_Todos(m_dsDESP_Salidas, x_where)
		If _opcion Then
			m_dtDESP_Salidas = m_dsDESP_Salidas.Tables(0)
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
			m_dsDESP_Salidas = new DataSet()
			Dim _opcion As Boolean = d_desp_salidas.DESP_PVENTSS_Todos(m_dsDESP_Salidas, x_join, x_where)
		If _opcion Then
			m_dtDESP_Salidas = m_dsDESP_Salidas.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_pvent_id As Long, x_salid_id As Long, x_vehic_id As Long) As Boolean
		Try
			m_edesp_salidas = New EDESP_Salidas()
			Return d_desp_salidas.DESP_PVENTSS_UnReg(m_edesp_salidas, x_pvent_id, x_salid_id, x_vehic_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_edesp_salidas = New EDESP_Salidas()
			Return d_desp_salidas.DESP_PVENTSS_UnReg(m_edesp_salidas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_edesp_salidas = New EDESP_Salidas()
			Return d_desp_salidas.DESP_PVENTSS_UnReg(m_edesp_salidas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_edesp_salidas.Nuevo Then
				d_desp_salidas.DESP_PVENTSI_UnReg(m_edesp_salidas, x_usuario)
			ElseIf m_edesp_salidas.Modificado Then
				d_desp_salidas.DESP_PVENTSU_UnReg(m_edesp_salidas, x_usuario)
			ElseIf m_edesp_salidas.Eliminado Then
				d_desp_salidas.DESP_PVENTSD_UnReg(DESP_Salidas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_edesp_salidas.Nuevo Then
				d_desp_salidas.DESP_PVENTSI_UnReg(m_edesp_salidas, x_usuario)
			ElseIf m_edesp_salidas.Modificado Then
				d_desp_salidas.DESP_PVENTSU_UnReg(m_edesp_salidas, x_where, x_usuario)
			ElseIf m_edesp_salidas.Eliminado Then
				d_desp_salidas.DESP_PVENTSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edesp_salidas.Nuevo Then
				d_desp_salidas.DESP_PVENTSI_UnReg(m_edesp_salidas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edesp_salidas.Modificado Then
				d_desp_salidas.DESP_PVENTSU_UnReg(m_edesp_salidas, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edesp_salidas.Eliminado Then
				d_desp_salidas.DESP_PVENTSD_UnReg(DESP_Salidas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_edesp_salidas.Nuevo Then
				d_desp_salidas.DESP_PVENTSI_UnReg(m_edesp_salidas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edesp_salidas.Modificado Then
				d_desp_salidas.DESP_PVENTSU_UnReg(m_edesp_salidas, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_edesp_salidas.Eliminado Then
				d_desp_salidas.DESP_PVENTSD_UnReg(DESP_Salidas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edesp_salidas.Nuevo Then
				d_desp_salidas.DESP_PVENTSI_UnReg(m_edesp_salidas, x_usuario, x_setfecha)
			ElseIf m_edesp_salidas.Modificado Then
				d_desp_salidas.DESP_PVENTSU_UnReg(m_edesp_salidas, x_usuario, x_setfecha)
			ElseIf m_edesp_salidas.Eliminado Then
				d_desp_salidas.DESP_PVENTSD_UnReg(DESP_Salidas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edesp_salidas.Nuevo Then
				d_desp_salidas.DESP_PVENTSI_UnReg(m_edesp_salidas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edesp_salidas.Eliminado Then
				d_desp_salidas.DESP_PVENTSD_UnReg(DESP_Salidas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listDESP_Salidas = new List(Of EDESP_Salidas)()
			return d_desp_salidas.DESP_PVENTSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_desp_salidas.getCorrelativo("PVENT_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_desp_salidas.getCorrelativo("PVENT_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_desp_salidas.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_desp_salidas.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_desp_salidas.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_desp_salidas.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

