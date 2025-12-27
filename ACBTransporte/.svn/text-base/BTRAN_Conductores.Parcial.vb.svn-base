Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_Conductores

#Region " Variables "
	
	Private m_tran_conductores As ETRAN_Conductores
	Private m_listTRAN_Conductores As List(Of ETRAN_Conductores)
	Private m_dtTRAN_Conductores As DataTable

	Private m_dsTRAN_Conductores As DataSet
	Private d_tran_conductores As DTRAN_Conductores 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_conductores = New DTRAN_Conductores()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_Conductores() As ETRAN_Conductores 
		Get
			return m_tran_conductores
		End Get
		Set(ByVal value As ETRAN_Conductores)
			m_tran_conductores = value
		End Set
	End Property
	Public Property ListTRAN_Conductores() As List(Of ETRAN_Conductores)
		Get
			return m_listTRAN_Conductores
		End Get
		Set(ByVal value As List(Of ETRAN_Conductores))
			m_listTRAN_Conductores = value
		End Set
	End Property
	Public Property DTTRAN_Conductores() As DataTable
		Get
			return m_dtTRAN_Conductores
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_Conductores = value
		End Set
	End Property
	Public Property DSTRAN_Conductores() As DataSet
		Get
			return m_dsTRAN_Conductores
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_Conductores = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_Conductores() As List(Of ETRAN_Conductores)
			Return Me.m_listTRAN_Conductores
		End Function
		Public Sub setListTRAN_Conductores(ByVal _listtran_conductores As List (Of ETRAN_Conductores))
			Me.m_listTRAN_Conductores = m_listtran_conductores 
		End Sub
		Public Function getTRAN_Conductores() As ETRAN_Conductores
			Return Me.m_tran_conductores
		End Function
		Public Sub setTRAN_Conductores(ByVal x_tran_conductores As ETRAN_Conductores)
			Me.m_tran_conductores = x_tran_conductores 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_Conductores = new List(Of ETRAN_Conductores)()
			return d_tran_conductores.TRAN_CONDUSS_Todos(m_listTRAN_Conductores)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Conductores = new List(Of ETRAN_Conductores)()
			return d_tran_conductores.TRAN_CONDUSS_Todos(m_listTRAN_Conductores, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Conductores = new List(Of ETRAN_Conductores)()
			return d_tran_conductores.TRAN_CONDUSS_Todos(m_listTRAN_Conductores, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_Conductores = new List(Of ETRAN_Conductores)()
			return d_tran_conductores.TRAN_CONDUSS_Todos(m_listTRAN_Conductores, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Conductores = new DataSet()
			return d_tran_conductores.TRAN_CONDUSS_Todos(m_dsTRAN_Conductores, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Conductores = new DataSet()
			return d_tran_conductores.TRAN_CONDUSS_Todos(m_dsTRAN_Conductores, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Conductores = new DataSet()
			Dim _opcion As Boolean = d_tran_conductores.TRAN_CONDUSS_Todos(m_dsTRAN_Conductores, x_where)
		If _opcion Then
			m_dtTRAN_Conductores = m_dsTRAN_Conductores.Tables(0)
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
			m_dsTRAN_Conductores = new DataSet()
			Dim _opcion As Boolean = d_tran_conductores.TRAN_CONDUSS_Todos(m_dsTRAN_Conductores, x_join, x_where)
		If _opcion Then
			m_dtTRAN_Conductores = m_dsTRAN_Conductores.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_condu_id As Long) As Boolean
		Try
			m_tran_conductores = New ETRAN_Conductores()
			Return d_tran_conductores.TRAN_CONDUSS_UnReg(m_tran_conductores, x_condu_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_conductores = New ETRAN_Conductores()
			Return d_tran_conductores.TRAN_CONDUSS_UnReg(m_tran_conductores, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_conductores = New ETRAN_Conductores()
			Return d_tran_conductores.TRAN_CONDUSS_UnReg(m_tran_conductores, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_conductores.Nuevo Then
				d_tran_conductores.TRAN_CONDUSI_UnReg(m_tran_conductores, x_usuario)
			ElseIf m_tran_conductores.Modificado Then
				d_tran_conductores.TRAN_CONDUSU_UnReg(m_tran_conductores, x_usuario)
			ElseIf m_tran_conductores.Eliminado Then
				d_tran_conductores.TRAN_CONDUSD_UnReg(m_tran_conductores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_conductores.Nuevo Then
				d_tran_conductores.TRAN_CONDUSI_UnReg(m_tran_conductores, x_usuario)
			ElseIf m_tran_conductores.Modificado Then
				d_tran_conductores.TRAN_CONDUSU_UnReg(m_tran_conductores, x_where, x_usuario)
			ElseIf m_tran_conductores.Eliminado Then
				d_tran_conductores.TRAN_CONDUSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_conductores.Nuevo Then
				d_tran_conductores.TRAN_CONDUSI_UnReg(m_tran_conductores, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_conductores.Modificado Then
				d_tran_conductores.TRAN_CONDUSU_UnReg(m_tran_conductores, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_conductores.Eliminado Then
				d_tran_conductores.TRAN_CONDUSD_UnReg(m_tran_conductores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_conductores.Nuevo Then
				d_tran_conductores.TRAN_CONDUSI_UnReg(m_tran_conductores, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_conductores.Modificado Then
				d_tran_conductores.TRAN_CONDUSU_UnReg(m_tran_conductores, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_conductores.Eliminado Then
				d_tran_conductores.TRAN_CONDUSD_UnReg(m_tran_conductores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_conductores.Nuevo Then
				d_tran_conductores.TRAN_CONDUSI_UnReg(m_tran_conductores, x_usuario, x_setfecha)
			ElseIf m_tran_conductores.Modificado Then
				d_tran_conductores.TRAN_CONDUSU_UnReg(m_tran_conductores, x_usuario, x_setfecha)
			ElseIf m_tran_conductores.Eliminado Then
				d_tran_conductores.TRAN_CONDUSD_UnReg(m_tran_conductores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_conductores.Nuevo Then
				d_tran_conductores.TRAN_CONDUSI_UnReg(m_tran_conductores, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_conductores.Eliminado Then
				d_tran_conductores.TRAN_CONDUSD_UnReg(m_tran_conductores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Conductores = new List(Of ETRAN_Conductores)()
			return d_tran_conductores.TRAN_CONDUSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_conductores.getCorrelativo("CONDU_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_conductores.getCorrelativo("CONDU_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_conductores.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_conductores.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_conductores.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_conductores.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

