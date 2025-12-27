Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_MovimientosAlmacenes

#Region " Variables "
	
	Private m_tran_movimientosalmacenes As ETRAN_MovimientosAlmacenes
	Private m_listTRAN_MovimientosAlmacenes As List(Of ETRAN_MovimientosAlmacenes)
	Private m_dtTRAN_MovimientosAlmacenes As DataTable

	Private m_dsTRAN_MovimientosAlmacenes As DataSet
	Private d_tran_movimientosalmacenes As DTRAN_MovimientosAlmacenes 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_movimientosalmacenes = New DTRAN_MovimientosAlmacenes()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_MovimientosAlmacenes() As ETRAN_MovimientosAlmacenes 
		Get
			return m_tran_movimientosalmacenes
		End Get
		Set(ByVal value As ETRAN_MovimientosAlmacenes)
			m_tran_movimientosalmacenes = value
		End Set
	End Property
	Public Property ListTRAN_MovimientosAlmacenes() As List(Of ETRAN_MovimientosAlmacenes)
		Get
			return m_listTRAN_MovimientosAlmacenes
		End Get
		Set(ByVal value As List(Of ETRAN_MovimientosAlmacenes))
			m_listTRAN_MovimientosAlmacenes = value
		End Set
	End Property
	Public Property DTTRAN_MovimientosAlmacenes() As DataTable
		Get
			return m_dtTRAN_MovimientosAlmacenes
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_MovimientosAlmacenes = value
		End Set
	End Property
	Public Property DSTRAN_MovimientosAlmacenes() As DataSet
		Get
			return m_dsTRAN_MovimientosAlmacenes
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_MovimientosAlmacenes = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_MovimientosAlmacenes() As List(Of ETRAN_MovimientosAlmacenes)
			Return Me.m_listTRAN_MovimientosAlmacenes
		End Function
		Public Sub setListTRAN_MovimientosAlmacenes(ByVal _listtran_movimientosalmacenes As List (Of ETRAN_MovimientosAlmacenes))
			Me.m_listTRAN_MovimientosAlmacenes = m_listtran_movimientosalmacenes 
		End Sub
		Public Function getTRAN_MovimientosAlmacenes() As ETRAN_MovimientosAlmacenes
			Return Me.m_tran_movimientosalmacenes
		End Function
		Public Sub setTRAN_MovimientosAlmacenes(ByVal x_tran_movimientosalmacenes As ETRAN_MovimientosAlmacenes)
			Me.m_tran_movimientosalmacenes = x_tran_movimientosalmacenes 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_MovimientosAlmacenes = new List(Of ETRAN_MovimientosAlmacenes)()
			return d_tran_movimientosalmacenes.TRAN_MOVALSS_Todos(m_listTRAN_MovimientosAlmacenes)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_MovimientosAlmacenes = new List(Of ETRAN_MovimientosAlmacenes)()
			return d_tran_movimientosalmacenes.TRAN_MOVALSS_Todos(m_listTRAN_MovimientosAlmacenes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_MovimientosAlmacenes = new List(Of ETRAN_MovimientosAlmacenes)()
			return d_tran_movimientosalmacenes.TRAN_MOVALSS_Todos(m_listTRAN_MovimientosAlmacenes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_MovimientosAlmacenes = new List(Of ETRAN_MovimientosAlmacenes)()
			return d_tran_movimientosalmacenes.TRAN_MOVALSS_Todos(m_listTRAN_MovimientosAlmacenes, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_MovimientosAlmacenes = new DataSet()
			return d_tran_movimientosalmacenes.TRAN_MOVALSS_Todos(m_dsTRAN_MovimientosAlmacenes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_MovimientosAlmacenes = new DataSet()
			return d_tran_movimientosalmacenes.TRAN_MOVALSS_Todos(m_dsTRAN_MovimientosAlmacenes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_MovimientosAlmacenes = new DataSet()
			Dim _opcion As Boolean = d_tran_movimientosalmacenes.TRAN_MOVALSS_Todos(m_dsTRAN_MovimientosAlmacenes, x_where)
		If _opcion Then
			m_dtTRAN_MovimientosAlmacenes = m_dsTRAN_MovimientosAlmacenes.Tables(0)
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
			m_dsTRAN_MovimientosAlmacenes = new DataSet()
			Dim _opcion As Boolean = d_tran_movimientosalmacenes.TRAN_MOVALSS_Todos(m_dsTRAN_MovimientosAlmacenes, x_join, x_where)
		If _opcion Then
			m_dtTRAN_MovimientosAlmacenes = m_dsTRAN_MovimientosAlmacenes.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_moval_id As Long) As Boolean
		Try
			m_tran_movimientosalmacenes = New ETRAN_MovimientosAlmacenes()
			Return d_tran_movimientosalmacenes.TRAN_MOVALSS_UnReg(m_tran_movimientosalmacenes, x_moval_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_movimientosalmacenes = New ETRAN_MovimientosAlmacenes()
			Return d_tran_movimientosalmacenes.TRAN_MOVALSS_UnReg(m_tran_movimientosalmacenes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_movimientosalmacenes = New ETRAN_MovimientosAlmacenes()
			Return d_tran_movimientosalmacenes.TRAN_MOVALSS_UnReg(m_tran_movimientosalmacenes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_movimientosalmacenes.Nuevo Then
				d_tran_movimientosalmacenes.TRAN_MOVALSI_UnReg(m_tran_movimientosalmacenes, x_usuario)
			ElseIf m_tran_movimientosalmacenes.Modificado Then
				d_tran_movimientosalmacenes.TRAN_MOVALSU_UnReg(m_tran_movimientosalmacenes, x_usuario)
			ElseIf m_tran_movimientosalmacenes.Eliminado Then
				d_tran_movimientosalmacenes.TRAN_MOVALSD_UnReg(m_tran_movimientosalmacenes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_movimientosalmacenes.Nuevo Then
				d_tran_movimientosalmacenes.TRAN_MOVALSI_UnReg(m_tran_movimientosalmacenes, x_usuario)
			ElseIf m_tran_movimientosalmacenes.Modificado Then
				d_tran_movimientosalmacenes.TRAN_MOVALSU_UnReg(m_tran_movimientosalmacenes, x_where, x_usuario)
			ElseIf m_tran_movimientosalmacenes.Eliminado Then
				d_tran_movimientosalmacenes.TRAN_MOVALSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_movimientosalmacenes.Nuevo Then
				d_tran_movimientosalmacenes.TRAN_MOVALSI_UnReg(m_tran_movimientosalmacenes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_movimientosalmacenes.Modificado Then
				d_tran_movimientosalmacenes.TRAN_MOVALSU_UnReg(m_tran_movimientosalmacenes, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_movimientosalmacenes.Eliminado Then
				d_tran_movimientosalmacenes.TRAN_MOVALSD_UnReg(m_tran_movimientosalmacenes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_movimientosalmacenes.Nuevo Then
				d_tran_movimientosalmacenes.TRAN_MOVALSI_UnReg(m_tran_movimientosalmacenes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_movimientosalmacenes.Modificado Then
				d_tran_movimientosalmacenes.TRAN_MOVALSU_UnReg(m_tran_movimientosalmacenes, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_movimientosalmacenes.Eliminado Then
				d_tran_movimientosalmacenes.TRAN_MOVALSD_UnReg(m_tran_movimientosalmacenes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_movimientosalmacenes.Nuevo Then
				d_tran_movimientosalmacenes.TRAN_MOVALSI_UnReg(m_tran_movimientosalmacenes, x_usuario, x_setfecha)
			ElseIf m_tran_movimientosalmacenes.Modificado Then
				d_tran_movimientosalmacenes.TRAN_MOVALSU_UnReg(m_tran_movimientosalmacenes, x_usuario, x_setfecha)
			ElseIf m_tran_movimientosalmacenes.Eliminado Then
				d_tran_movimientosalmacenes.TRAN_MOVALSD_UnReg(m_tran_movimientosalmacenes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_movimientosalmacenes.Nuevo Then
				d_tran_movimientosalmacenes.TRAN_MOVALSI_UnReg(m_tran_movimientosalmacenes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_movimientosalmacenes.Eliminado Then
				d_tran_movimientosalmacenes.TRAN_MOVALSD_UnReg(m_tran_movimientosalmacenes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_MovimientosAlmacenes = new List(Of ETRAN_MovimientosAlmacenes)()
			return d_tran_movimientosalmacenes.TRAN_MOVALSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_movimientosalmacenes.getCorrelativo("MOVAL_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_movimientosalmacenes.getCorrelativo("MOVAL_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_movimientosalmacenes.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_movimientosalmacenes.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_movimientosalmacenes.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_movimientosalmacenes.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

