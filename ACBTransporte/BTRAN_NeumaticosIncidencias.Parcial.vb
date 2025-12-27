Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_NeumaticosIncidencias

#Region " Variables "
	
	Private m_tran_neumaticosincidencias As ETRAN_NeumaticosIncidencias
	Private m_listTRAN_NeumaticosIncidencias As List(Of ETRAN_NeumaticosIncidencias)
	Private m_dtTRAN_NeumaticosIncidencias As DataTable

	Private m_dsTRAN_NeumaticosIncidencias As DataSet
	Private d_tran_neumaticosincidencias As DTRAN_NeumaticosIncidencias 


#End Region

#Region " Constructores "
	
   Public Sub New()
      d_tran_neumaticosincidencias = New DTRAN_NeumaticosIncidencias()
   End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_NeumaticosIncidencias() As ETRAN_NeumaticosIncidencias 
		Get
			return m_tran_neumaticosincidencias
		End Get
		Set(ByVal value As ETRAN_NeumaticosIncidencias)
			m_tran_neumaticosincidencias = value
		End Set
	End Property
	Public Property ListTRAN_NeumaticosIncidencias() As List(Of ETRAN_NeumaticosIncidencias)
		Get
			return m_listTRAN_NeumaticosIncidencias
		End Get
		Set(ByVal value As List(Of ETRAN_NeumaticosIncidencias))
			m_listTRAN_NeumaticosIncidencias = value
		End Set
	End Property
	Public Property DTTRAN_NeumaticosIncidencias() As DataTable
		Get
			return m_dtTRAN_NeumaticosIncidencias
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_NeumaticosIncidencias = value
		End Set
	End Property
	Public Property DSTRAN_NeumaticosIncidencias() As DataSet
		Get
			return m_dsTRAN_NeumaticosIncidencias
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_NeumaticosIncidencias = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_NeumaticosIncidencias() As List(Of ETRAN_NeumaticosIncidencias)
			Return Me.m_listTRAN_NeumaticosIncidencias
		End Function
		Public Sub setListTRAN_NeumaticosIncidencias(ByVal _listtran_neumaticosincidencias As List (Of ETRAN_NeumaticosIncidencias))
			Me.m_listTRAN_NeumaticosIncidencias = m_listtran_neumaticosincidencias 
		End Sub
		Public Function getTRAN_NeumaticosIncidencias() As ETRAN_NeumaticosIncidencias
			Return Me.m_tran_neumaticosincidencias
		End Function
		Public Sub setTRAN_NeumaticosIncidencias(ByVal x_tran_neumaticosincidencias As ETRAN_NeumaticosIncidencias)
			Me.m_tran_neumaticosincidencias = x_tran_neumaticosincidencias 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_NeumaticosIncidencias = new List(Of ETRAN_NeumaticosIncidencias)()
			return d_tran_neumaticosincidencias.TRAN_INCNUSS_Todos(m_listTRAN_NeumaticosIncidencias)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_NeumaticosIncidencias = new List(Of ETRAN_NeumaticosIncidencias)()
			return d_tran_neumaticosincidencias.TRAN_INCNUSS_Todos(m_listTRAN_NeumaticosIncidencias, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_NeumaticosIncidencias = new List(Of ETRAN_NeumaticosIncidencias)()
			return d_tran_neumaticosincidencias.TRAN_INCNUSS_Todos(m_listTRAN_NeumaticosIncidencias, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_NeumaticosIncidencias = new List(Of ETRAN_NeumaticosIncidencias)()
			return d_tran_neumaticosincidencias.TRAN_INCNUSS_Todos(m_listTRAN_NeumaticosIncidencias, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_neuma_id As Long) As Boolean
		Try
			m_listTRAN_NeumaticosIncidencias = new List(Of ETRAN_NeumaticosIncidencias)()
			Return d_tran_neumaticosincidencias.TRAN_INCNUSS_Todos(m_listTRAN_NeumaticosIncidencias, x_neuma_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_NeumaticosIncidencias = new DataSet()
			return d_tran_neumaticosincidencias.TRAN_INCNUSS_Todos(m_dsTRAN_NeumaticosIncidencias, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_NeumaticosIncidencias = new DataSet()
			return d_tran_neumaticosincidencias.TRAN_INCNUSS_Todos(m_dsTRAN_NeumaticosIncidencias, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_NeumaticosIncidencias = new DataSet()
			Dim _opcion As Boolean = d_tran_neumaticosincidencias.TRAN_INCNUSS_Todos(m_dsTRAN_NeumaticosIncidencias, x_where)
		If _opcion Then
			m_dtTRAN_NeumaticosIncidencias = m_dsTRAN_NeumaticosIncidencias.Tables(0)
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
			m_dsTRAN_NeumaticosIncidencias = new DataSet()
			Dim _opcion As Boolean = d_tran_neumaticosincidencias.TRAN_INCNUSS_Todos(m_dsTRAN_NeumaticosIncidencias, x_join, x_where)
		If _opcion Then
			m_dtTRAN_NeumaticosIncidencias = m_dsTRAN_NeumaticosIncidencias.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_neuma_id As Long, x_incnu_id As Long) As Boolean
		Try
			m_tran_neumaticosincidencias = New ETRAN_NeumaticosIncidencias()
			Return d_tran_neumaticosincidencias.TRAN_INCNUSS_UnReg(m_tran_neumaticosincidencias, x_neuma_id, x_incnu_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_neumaticosincidencias = New ETRAN_NeumaticosIncidencias()
			Return d_tran_neumaticosincidencias.TRAN_INCNUSS_UnReg(m_tran_neumaticosincidencias, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_neumaticosincidencias = New ETRAN_NeumaticosIncidencias()
			Return d_tran_neumaticosincidencias.TRAN_INCNUSS_UnReg(m_tran_neumaticosincidencias, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_neumaticosincidencias.Nuevo Then
				d_tran_neumaticosincidencias.TRAN_INCNUSI_UnReg(m_tran_neumaticosincidencias, x_usuario)
			ElseIf m_tran_neumaticosincidencias.Modificado Then
				d_tran_neumaticosincidencias.TRAN_INCNUSU_UnReg(m_tran_neumaticosincidencias, x_usuario)
			ElseIf m_tran_neumaticosincidencias.Eliminado Then
				d_tran_neumaticosincidencias.TRAN_INCNUSD_UnReg(m_tran_neumaticosincidencias)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_neumaticosincidencias.Nuevo Then
				d_tran_neumaticosincidencias.TRAN_INCNUSI_UnReg(m_tran_neumaticosincidencias, x_usuario)
			ElseIf m_tran_neumaticosincidencias.Modificado Then
				d_tran_neumaticosincidencias.TRAN_INCNUSU_UnReg(m_tran_neumaticosincidencias, x_where, x_usuario)
			ElseIf m_tran_neumaticosincidencias.Eliminado Then
				d_tran_neumaticosincidencias.TRAN_INCNUSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_neumaticosincidencias.Nuevo Then
				d_tran_neumaticosincidencias.TRAN_INCNUSI_UnReg(m_tran_neumaticosincidencias, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_neumaticosincidencias.Modificado Then
				d_tran_neumaticosincidencias.TRAN_INCNUSU_UnReg(m_tran_neumaticosincidencias, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_neumaticosincidencias.Eliminado Then
				d_tran_neumaticosincidencias.TRAN_INCNUSD_UnReg(m_tran_neumaticosincidencias)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_neumaticosincidencias.Nuevo Then
				d_tran_neumaticosincidencias.TRAN_INCNUSI_UnReg(m_tran_neumaticosincidencias, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_neumaticosincidencias.Modificado Then
				d_tran_neumaticosincidencias.TRAN_INCNUSU_UnReg(m_tran_neumaticosincidencias, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_neumaticosincidencias.Eliminado Then
				d_tran_neumaticosincidencias.TRAN_INCNUSD_UnReg(m_tran_neumaticosincidencias)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_neumaticosincidencias.Nuevo Then
				d_tran_neumaticosincidencias.TRAN_INCNUSI_UnReg(m_tran_neumaticosincidencias, x_usuario, x_setfecha)
			ElseIf m_tran_neumaticosincidencias.Modificado Then
				d_tran_neumaticosincidencias.TRAN_INCNUSU_UnReg(m_tran_neumaticosincidencias, x_usuario, x_setfecha)
			ElseIf m_tran_neumaticosincidencias.Eliminado Then
				d_tran_neumaticosincidencias.TRAN_INCNUSD_UnReg(m_tran_neumaticosincidencias)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_neumaticosincidencias.Nuevo Then
				d_tran_neumaticosincidencias.TRAN_INCNUSI_UnReg(m_tran_neumaticosincidencias, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_neumaticosincidencias.Eliminado Then
				d_tran_neumaticosincidencias.TRAN_INCNUSD_UnReg(m_tran_neumaticosincidencias)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_NeumaticosIncidencias = new List(Of ETRAN_NeumaticosIncidencias)()
			return d_tran_neumaticosincidencias.TRAN_INCNUSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_neumaticosincidencias.getCorrelativo("NEUMA_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_neumaticosincidencias.getCorrelativo("NEUMA_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_neumaticosincidencias.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_neumaticosincidencias.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_neumaticosincidencias.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_neumaticosincidencias.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

