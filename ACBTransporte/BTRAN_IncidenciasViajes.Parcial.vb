Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_IncidenciasViajes

#Region " Variables "
	
	Private m_tran_incidenciasviajes As ETRAN_IncidenciasViajes
	Private m_listTRAN_IncidenciasViajes As List(Of ETRAN_IncidenciasViajes)
	Private m_dtTRAN_IncidenciasViajes As DataTable

	Private m_dsTRAN_IncidenciasViajes As DataSet
	Private d_tran_incidenciasviajes As DTRAN_IncidenciasViajes 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_incidenciasviajes = New DTRAN_IncidenciasViajes()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_IncidenciasViajes() As ETRAN_IncidenciasViajes 
		Get
			return m_tran_incidenciasviajes
		End Get
		Set(ByVal value As ETRAN_IncidenciasViajes)
			m_tran_incidenciasviajes = value
		End Set
	End Property
	Public Property ListTRAN_IncidenciasViajes() As List(Of ETRAN_IncidenciasViajes)
		Get
			return m_listTRAN_IncidenciasViajes
		End Get
		Set(ByVal value As List(Of ETRAN_IncidenciasViajes))
			m_listTRAN_IncidenciasViajes = value
		End Set
	End Property
	Public Property DTTRAN_IncidenciasViajes() As DataTable
		Get
			return m_dtTRAN_IncidenciasViajes
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_IncidenciasViajes = value
		End Set
	End Property
	Public Property DSTRAN_IncidenciasViajes() As DataSet
		Get
			return m_dsTRAN_IncidenciasViajes
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_IncidenciasViajes = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_IncidenciasViajes() As List(Of ETRAN_IncidenciasViajes)
			Return Me.m_listTRAN_IncidenciasViajes
		End Function
		Public Sub setListTRAN_IncidenciasViajes(ByVal _listtran_incidenciasviajes As List (Of ETRAN_IncidenciasViajes))
			Me.m_listTRAN_IncidenciasViajes = m_listtran_incidenciasviajes 
		End Sub
		Public Function getTRAN_IncidenciasViajes() As ETRAN_IncidenciasViajes
			Return Me.m_tran_incidenciasviajes
		End Function
		Public Sub setTRAN_IncidenciasViajes(ByVal x_tran_incidenciasviajes As ETRAN_IncidenciasViajes)
			Me.m_tran_incidenciasviajes = x_tran_incidenciasviajes 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_IncidenciasViajes = new List(Of ETRAN_IncidenciasViajes)()
			return d_tran_incidenciasviajes.TRAN_INCIVSS_Todos(m_listTRAN_IncidenciasViajes)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_IncidenciasViajes = new List(Of ETRAN_IncidenciasViajes)()
			return d_tran_incidenciasviajes.TRAN_INCIVSS_Todos(m_listTRAN_IncidenciasViajes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_IncidenciasViajes = new List(Of ETRAN_IncidenciasViajes)()
			return d_tran_incidenciasviajes.TRAN_INCIVSS_Todos(m_listTRAN_IncidenciasViajes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_IncidenciasViajes = new List(Of ETRAN_IncidenciasViajes)()
			return d_tran_incidenciasviajes.TRAN_INCIVSS_Todos(m_listTRAN_IncidenciasViajes, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_IncidenciasViajes = new DataSet()
			return d_tran_incidenciasviajes.TRAN_INCIVSS_Todos(m_dsTRAN_IncidenciasViajes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_IncidenciasViajes = new DataSet()
			return d_tran_incidenciasviajes.TRAN_INCIVSS_Todos(m_dsTRAN_IncidenciasViajes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_IncidenciasViajes = new DataSet()
			Dim _opcion As Boolean = d_tran_incidenciasviajes.TRAN_INCIVSS_Todos(m_dsTRAN_IncidenciasViajes, x_where)
		If _opcion Then
			m_dtTRAN_IncidenciasViajes = m_dsTRAN_IncidenciasViajes.Tables(0)
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
			m_dsTRAN_IncidenciasViajes = new DataSet()
			Dim _opcion As Boolean = d_tran_incidenciasviajes.TRAN_INCIVSS_Todos(m_dsTRAN_IncidenciasViajes, x_join, x_where)
		If _opcion Then
			m_dtTRAN_IncidenciasViajes = m_dsTRAN_IncidenciasViajes.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_inciv_id As Long) As Boolean
		Try
			m_tran_incidenciasviajes = New ETRAN_IncidenciasViajes()
			Return d_tran_incidenciasviajes.TRAN_INCIVSS_UnReg(m_tran_incidenciasviajes, x_inciv_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_incidenciasviajes = New ETRAN_IncidenciasViajes()
			Return d_tran_incidenciasviajes.TRAN_INCIVSS_UnReg(m_tran_incidenciasviajes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_incidenciasviajes = New ETRAN_IncidenciasViajes()
			Return d_tran_incidenciasviajes.TRAN_INCIVSS_UnReg(m_tran_incidenciasviajes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_incidenciasviajes.Nuevo Then
				d_tran_incidenciasviajes.TRAN_INCIVSI_UnReg(m_tran_incidenciasviajes, x_usuario)
			ElseIf m_tran_incidenciasviajes.Modificado Then
				d_tran_incidenciasviajes.TRAN_INCIVSU_UnReg(m_tran_incidenciasviajes, x_usuario)
			ElseIf m_tran_incidenciasviajes.Eliminado Then
				d_tran_incidenciasviajes.TRAN_INCIVSD_UnReg(m_tran_incidenciasviajes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_incidenciasviajes.Nuevo Then
				d_tran_incidenciasviajes.TRAN_INCIVSI_UnReg(m_tran_incidenciasviajes, x_usuario)
			ElseIf m_tran_incidenciasviajes.Modificado Then
				d_tran_incidenciasviajes.TRAN_INCIVSU_UnReg(m_tran_incidenciasviajes, x_where, x_usuario)
			ElseIf m_tran_incidenciasviajes.Eliminado Then
				d_tran_incidenciasviajes.TRAN_INCIVSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_incidenciasviajes.Nuevo Then
				d_tran_incidenciasviajes.TRAN_INCIVSI_UnReg(m_tran_incidenciasviajes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_incidenciasviajes.Modificado Then
				d_tran_incidenciasviajes.TRAN_INCIVSU_UnReg(m_tran_incidenciasviajes, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_incidenciasviajes.Eliminado Then
				d_tran_incidenciasviajes.TRAN_INCIVSD_UnReg(m_tran_incidenciasviajes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_incidenciasviajes.Nuevo Then
				d_tran_incidenciasviajes.TRAN_INCIVSI_UnReg(m_tran_incidenciasviajes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_incidenciasviajes.Modificado Then
				d_tran_incidenciasviajes.TRAN_INCIVSU_UnReg(m_tran_incidenciasviajes, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_incidenciasviajes.Eliminado Then
				d_tran_incidenciasviajes.TRAN_INCIVSD_UnReg(m_tran_incidenciasviajes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_incidenciasviajes.Nuevo Then
				d_tran_incidenciasviajes.TRAN_INCIVSI_UnReg(m_tran_incidenciasviajes, x_usuario, x_setfecha)
			ElseIf m_tran_incidenciasviajes.Modificado Then
				d_tran_incidenciasviajes.TRAN_INCIVSU_UnReg(m_tran_incidenciasviajes, x_usuario, x_setfecha)
			ElseIf m_tran_incidenciasviajes.Eliminado Then
				d_tran_incidenciasviajes.TRAN_INCIVSD_UnReg(m_tran_incidenciasviajes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_incidenciasviajes.Nuevo Then
				d_tran_incidenciasviajes.TRAN_INCIVSI_UnReg(m_tran_incidenciasviajes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_incidenciasviajes.Eliminado Then
				d_tran_incidenciasviajes.TRAN_INCIVSD_UnReg(m_tran_incidenciasviajes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_IncidenciasViajes = new List(Of ETRAN_IncidenciasViajes)()
			return d_tran_incidenciasviajes.TRAN_INCIVSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_incidenciasviajes.getCorrelativo("INCIV_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_incidenciasviajes.getCorrelativo("INCIV_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_incidenciasviajes.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_incidenciasviajes.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_incidenciasviajes.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_incidenciasviajes.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

