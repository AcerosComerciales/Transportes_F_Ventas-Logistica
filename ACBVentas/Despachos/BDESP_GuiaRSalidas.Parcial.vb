Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BDESP_GuiaRSalidas

#Region " Variables "
	
	Private m_edesp_guiarsalidas As EDESP_GuiaRSalidas
	Private m_listDESP_GuiaRSalidas As List(Of EDESP_GuiaRSalidas)
	Private m_dtDESP_GuiaRSalidas As DataTable

	Private m_dsDESP_GuiaRSalidas As DataSet
	Private d_desp_guiarsalidas As DDESP_GuiaRSalidas 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_desp_guiarsalidas = New DDESP_GuiaRSalidas()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property DESP_GuiaRSalidas() As EDESP_GuiaRSalidas 
		Get
			return m_edesp_guiarsalidas
		End Get
		Set(ByVal value As EDESP_GuiaRSalidas)
			m_edesp_guiarsalidas = value
		End Set
	End Property

	Public Property ListDESP_GuiaRSalidas() As List(Of EDESP_GuiaRSalidas)
		Get
			return m_listDESP_GuiaRSalidas
		End Get
		Set(ByVal value As List(Of EDESP_GuiaRSalidas))
			m_listDESP_GuiaRSalidas = value
		End Set
	End Property

	Public Property DTDESP_GuiaRSalidas() As DataTable
		Get
			return m_dtDESP_GuiaRSalidas
		End Get
		Set(ByVal value As DataTable)
			m_dtDESP_GuiaRSalidas = value
		End Set
	End Property

	Public Property DSDESP_GuiaRSalidas() As DataSet
		Get
			return m_dsDESP_GuiaRSalidas
		End Get
		Set(ByVal value As DataSet)
			m_dsDESP_GuiaRSalidas = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listDESP_GuiaRSalidas = new List(Of EDESP_GuiaRSalidas)()
			return d_desp_guiarsalidas.DESP_GUISASS_Todos(m_listDESP_GuiaRSalidas)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listDESP_GuiaRSalidas = new List(Of EDESP_GuiaRSalidas)()
			return d_desp_guiarsalidas.DESP_GUISASS_Todos(m_listDESP_GuiaRSalidas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listDESP_GuiaRSalidas = new List(Of EDESP_GuiaRSalidas)()
			return d_desp_guiarsalidas.DESP_GUISASS_Todos(m_listDESP_GuiaRSalidas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listDESP_GuiaRSalidas = new List(Of EDESP_GuiaRSalidas)()
			return d_desp_guiarsalidas.DESP_GUISASS_Todos(m_listDESP_GuiaRSalidas, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDESP_GuiaRSalidas = new DataSet()
			return d_desp_guiarsalidas.DESP_GUISASS_Todos(m_dsDESP_GuiaRSalidas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDESP_GuiaRSalidas = new DataSet()
			return d_desp_guiarsalidas.DESP_GUISASS_Todos(m_dsDESP_GuiaRSalidas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDESP_GuiaRSalidas = new DataSet()
			Dim _opcion As Boolean = d_desp_guiarsalidas.DESP_GUISASS_Todos(m_dsDESP_GuiaRSalidas, x_where)
		If _opcion Then
			m_dtDESP_GuiaRSalidas = m_dsDESP_GuiaRSalidas.Tables(0)
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
			m_dsDESP_GuiaRSalidas = new DataSet()
			Dim _opcion As Boolean = d_desp_guiarsalidas.DESP_GUISASS_Todos(m_dsDESP_GuiaRSalidas, x_join, x_where)
		If _opcion Then
			m_dtDESP_GuiaRSalidas = m_dsDESP_GuiaRSalidas.Tables(0)
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
			If m_edesp_guiarsalidas.Nuevo Then
				d_desp_guiarsalidas.DESP_GUISASI_UnReg(m_edesp_guiarsalidas, x_usuario)
			ElseIf m_edesp_guiarsalidas.Eliminado Then
				d_desp_guiarsalidas.DESP_GUISASD_UnReg(DESP_GuiaRSalidas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_edesp_guiarsalidas.Nuevo Then
				d_desp_guiarsalidas.DESP_GUISASI_UnReg(m_edesp_guiarsalidas, x_usuario)
			ElseIf m_edesp_guiarsalidas.Eliminado Then
				d_desp_guiarsalidas.DESP_GUISASD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edesp_guiarsalidas.Nuevo Then
				d_desp_guiarsalidas.DESP_GUISASI_UnReg(m_edesp_guiarsalidas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edesp_guiarsalidas.Eliminado Then
				d_desp_guiarsalidas.DESP_GUISASD_UnReg(DESP_GuiaRSalidas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_edesp_guiarsalidas.Nuevo Then
				d_desp_guiarsalidas.DESP_GUISASI_UnReg(m_edesp_guiarsalidas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edesp_guiarsalidas.Eliminado Then
				d_desp_guiarsalidas.DESP_GUISASD_UnReg(DESP_GuiaRSalidas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edesp_guiarsalidas.Nuevo Then
				d_desp_guiarsalidas.DESP_GUISASI_UnReg(m_edesp_guiarsalidas, x_usuario, x_setfecha)
			ElseIf m_edesp_guiarsalidas.Eliminado Then
				d_desp_guiarsalidas.DESP_GUISASD_UnReg(DESP_GuiaRSalidas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edesp_guiarsalidas.Nuevo Then
				d_desp_guiarsalidas.DESP_GUISASI_UnReg(m_edesp_guiarsalidas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edesp_guiarsalidas.Eliminado Then
				d_desp_guiarsalidas.DESP_GUISASD_UnReg(DESP_GuiaRSalidas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listDESP_GuiaRSalidas = new List(Of EDESP_GuiaRSalidas)()
			return d_desp_guiarsalidas.DESP_GUISASD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_desp_guiarsalidas.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_desp_guiarsalidas.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_desp_guiarsalidas.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_desp_guiarsalidas.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

