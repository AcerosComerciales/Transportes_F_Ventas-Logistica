Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_Ranflas

#Region " Variables "
	
	Private m_tran_ranflas As ETRAN_Ranflas
	Private m_listTRAN_Ranflas As List(Of ETRAN_Ranflas)
	Private m_dtTRAN_Ranflas As DataTable

	Private m_dsTRAN_Ranflas As DataSet
	Private d_tran_ranflas As DTRAN_Ranflas 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_ranflas = New DTRAN_Ranflas()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_Ranflas() As ETRAN_Ranflas 
		Get
			return m_tran_ranflas
		End Get
		Set(ByVal value As ETRAN_Ranflas)
			m_tran_ranflas = value
		End Set
	End Property
	Public Property ListTRAN_Ranflas() As List(Of ETRAN_Ranflas)
		Get
			return m_listTRAN_Ranflas
		End Get
		Set(ByVal value As List(Of ETRAN_Ranflas))
			m_listTRAN_Ranflas = value
		End Set
	End Property
	Public Property DTTRAN_Ranflas() As DataTable
		Get
			return m_dtTRAN_Ranflas
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_Ranflas = value
		End Set
	End Property
	Public Property DSTRAN_Ranflas() As DataSet
		Get
			return m_dsTRAN_Ranflas
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_Ranflas = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_Ranflas() As List(Of ETRAN_Ranflas)
			Return Me.m_listTRAN_Ranflas
		End Function
		Public Sub setListTRAN_Ranflas(ByVal _listtran_ranflas As List (Of ETRAN_Ranflas))
			Me.m_listTRAN_Ranflas = m_listtran_ranflas 
		End Sub
		Public Function getTRAN_Ranflas() As ETRAN_Ranflas
			Return Me.m_tran_ranflas
		End Function
		Public Sub setTRAN_Ranflas(ByVal x_tran_ranflas As ETRAN_Ranflas)
			Me.m_tran_ranflas = x_tran_ranflas 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_Ranflas = new List(Of ETRAN_Ranflas)()
			return d_tran_ranflas.TRAN_RANFLSS_Todos(m_listTRAN_Ranflas)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Ranflas = new List(Of ETRAN_Ranflas)()
			return d_tran_ranflas.TRAN_RANFLSS_Todos(m_listTRAN_Ranflas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Ranflas = new List(Of ETRAN_Ranflas)()
			return d_tran_ranflas.TRAN_RANFLSS_Todos(m_listTRAN_Ranflas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_Ranflas = new List(Of ETRAN_Ranflas)()
			return d_tran_ranflas.TRAN_RANFLSS_Todos(m_listTRAN_Ranflas, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Ranflas = new DataSet()
			return d_tran_ranflas.TRAN_RANFLSS_Todos(m_dsTRAN_Ranflas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Ranflas = new DataSet()
			return d_tran_ranflas.TRAN_RANFLSS_Todos(m_dsTRAN_Ranflas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Ranflas = new DataSet()
			Dim _opcion As Boolean = d_tran_ranflas.TRAN_RANFLSS_Todos(m_dsTRAN_Ranflas, x_where)
		If _opcion Then
			m_dtTRAN_Ranflas = m_dsTRAN_Ranflas.Tables(0)
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
			m_dsTRAN_Ranflas = new DataSet()
			Dim _opcion As Boolean = d_tran_ranflas.TRAN_RANFLSS_Todos(m_dsTRAN_Ranflas, x_join, x_where)
		If _opcion Then
			m_dtTRAN_Ranflas = m_dsTRAN_Ranflas.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_ranfl_id As Long) As Boolean
		Try
			m_tran_ranflas = New ETRAN_Ranflas()
			Return d_tran_ranflas.TRAN_RANFLSS_UnReg(m_tran_ranflas, x_ranfl_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_ranflas = New ETRAN_Ranflas()
			Return d_tran_ranflas.TRAN_RANFLSS_UnReg(m_tran_ranflas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_ranflas = New ETRAN_Ranflas()
			Return d_tran_ranflas.TRAN_RANFLSS_UnReg(m_tran_ranflas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_ranflas.Nuevo Then
				d_tran_ranflas.TRAN_RANFLSI_UnReg(m_tran_ranflas, x_usuario)
			ElseIf m_tran_ranflas.Modificado Then
				d_tran_ranflas.TRAN_RANFLSU_UnReg(m_tran_ranflas, x_usuario)
			ElseIf m_tran_ranflas.Eliminado Then
				d_tran_ranflas.TRAN_RANFLSD_UnReg(m_tran_ranflas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_ranflas.Nuevo Then
				d_tran_ranflas.TRAN_RANFLSI_UnReg(m_tran_ranflas, x_usuario)
			ElseIf m_tran_ranflas.Modificado Then
				d_tran_ranflas.TRAN_RANFLSU_UnReg(m_tran_ranflas, x_where, x_usuario)
			ElseIf m_tran_ranflas.Eliminado Then
				d_tran_ranflas.TRAN_RANFLSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_ranflas.Nuevo Then
				d_tran_ranflas.TRAN_RANFLSI_UnReg(m_tran_ranflas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_ranflas.Modificado Then
				d_tran_ranflas.TRAN_RANFLSU_UnReg(m_tran_ranflas, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_ranflas.Eliminado Then
				d_tran_ranflas.TRAN_RANFLSD_UnReg(m_tran_ranflas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_ranflas.Nuevo Then
				d_tran_ranflas.TRAN_RANFLSI_UnReg(m_tran_ranflas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_ranflas.Modificado Then
				d_tran_ranflas.TRAN_RANFLSU_UnReg(m_tran_ranflas, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_ranflas.Eliminado Then
				d_tran_ranflas.TRAN_RANFLSD_UnReg(m_tran_ranflas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_ranflas.Nuevo Then
				d_tran_ranflas.TRAN_RANFLSI_UnReg(m_tran_ranflas, x_usuario, x_setfecha)
			ElseIf m_tran_ranflas.Modificado Then
				d_tran_ranflas.TRAN_RANFLSU_UnReg(m_tran_ranflas, x_usuario, x_setfecha)
			ElseIf m_tran_ranflas.Eliminado Then
				d_tran_ranflas.TRAN_RANFLSD_UnReg(m_tran_ranflas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_ranflas.Nuevo Then
				d_tran_ranflas.TRAN_RANFLSI_UnReg(m_tran_ranflas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_ranflas.Eliminado Then
				d_tran_ranflas.TRAN_RANFLSD_UnReg(m_tran_ranflas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Ranflas = new List(Of ETRAN_Ranflas)()
			return d_tran_ranflas.TRAN_RANFLSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_ranflas.getCorrelativo("RANFL_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_ranflas.getCorrelativo("RANFL_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_ranflas.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_ranflas.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_ranflas.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_ranflas.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

