Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_Recibos

#Region " Variables "
	
	Private m_tran_recibos As ETRAN_Recibos
	Private m_listTRAN_Recibos As List(Of ETRAN_Recibos)
	Private m_dtTRAN_Recibos As DataTable

	Private m_dsTRAN_Recibos As DataSet
	Private d_tran_recibos As DTRAN_Recibos 


#End Region

#Region " Constructores "
	
   Public Sub New()
      d_tran_recibos = New DTRAN_Recibos()
   End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_Recibos() As ETRAN_Recibos 
		Get
			return m_tran_recibos
		End Get
		Set(ByVal value As ETRAN_Recibos)
			m_tran_recibos = value
		End Set
	End Property

	Public Property ListTRAN_Recibos() As List(Of ETRAN_Recibos)
		Get
			return m_listTRAN_Recibos
		End Get
		Set(ByVal value As List(Of ETRAN_Recibos))
			m_listTRAN_Recibos = value
		End Set
	End Property

	Public Property DTTRAN_Recibos() As DataTable
		Get
			return m_dtTRAN_Recibos
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_Recibos = value
		End Set
	End Property

	Public Property DSTRAN_Recibos() As DataSet
		Get
			return m_dsTRAN_Recibos
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_Recibos = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_Recibos = new List(Of ETRAN_Recibos)()
			return d_tran_recibos.TRAN_RECIBSS_Todos(m_listTRAN_Recibos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Recibos = new List(Of ETRAN_Recibos)()
			return d_tran_recibos.TRAN_RECIBSS_Todos(m_listTRAN_Recibos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Recibos = new List(Of ETRAN_Recibos)()
			return d_tran_recibos.TRAN_RECIBSS_Todos(m_listTRAN_Recibos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_Recibos = new List(Of ETRAN_Recibos)()
			return d_tran_recibos.TRAN_RECIBSS_Todos(m_listTRAN_Recibos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Recibos = new DataSet()
			return d_tran_recibos.TRAN_RECIBSS_Todos(m_dsTRAN_Recibos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Recibos = new DataSet()
			return d_tran_recibos.TRAN_RECIBSS_Todos(m_dsTRAN_Recibos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Recibos = new DataSet()
			Dim _opcion As Boolean = d_tran_recibos.TRAN_RECIBSS_Todos(m_dsTRAN_Recibos, x_where)
		If _opcion Then
			m_dtTRAN_Recibos = m_dsTRAN_Recibos.Tables(0)
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
			m_dsTRAN_Recibos = new DataSet()
			Dim _opcion As Boolean = d_tran_recibos.TRAN_RECIBSS_Todos(m_dsTRAN_Recibos, x_join, x_where)
		If _opcion Then
			m_dtTRAN_Recibos = m_dsTRAN_Recibos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_recib_codigo As String) As Boolean
		Try
			m_tran_recibos = New ETRAN_Recibos()
			Return d_tran_recibos.TRAN_RECIBSS_UnReg(m_tran_recibos, x_recib_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_recibos = New ETRAN_Recibos()
			Return d_tran_recibos.TRAN_RECIBSS_UnReg(m_tran_recibos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_recibos = New ETRAN_Recibos()
			Return d_tran_recibos.TRAN_RECIBSS_UnReg(m_tran_recibos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_recibos.Nuevo Then
				d_tran_recibos.TRAN_RECIBSI_UnReg(m_tran_recibos, x_usuario)
			ElseIf m_tran_recibos.Modificado Then
				d_tran_recibos.TRAN_RECIBSU_UnReg(m_tran_recibos, x_usuario)
			ElseIf m_tran_recibos.Eliminado Then
				d_tran_recibos.TRAN_RECIBSD_UnReg(TRAN_Recibos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_recibos.Nuevo Then
				d_tran_recibos.TRAN_RECIBSI_UnReg(m_tran_recibos, x_usuario)
			ElseIf m_tran_recibos.Modificado Then
				d_tran_recibos.TRAN_RECIBSU_UnReg(m_tran_recibos, x_where, x_usuario)
			ElseIf m_tran_recibos.Eliminado Then
				d_tran_recibos.TRAN_RECIBSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_recibos.Nuevo Then
				d_tran_recibos.TRAN_RECIBSI_UnReg(m_tran_recibos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_recibos.Modificado Then
				d_tran_recibos.TRAN_RECIBSU_UnReg(m_tran_recibos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_recibos.Eliminado Then
				d_tran_recibos.TRAN_RECIBSD_UnReg(TRAN_Recibos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_recibos.Nuevo Then
				d_tran_recibos.TRAN_RECIBSI_UnReg(m_tran_recibos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_recibos.Modificado Then
				d_tran_recibos.TRAN_RECIBSU_UnReg(m_tran_recibos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_recibos.Eliminado Then
				d_tran_recibos.TRAN_RECIBSD_UnReg(TRAN_Recibos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_recibos.Nuevo Then
				d_tran_recibos.TRAN_RECIBSI_UnReg(m_tran_recibos, x_usuario, x_setfecha)
			ElseIf m_tran_recibos.Modificado Then
				d_tran_recibos.TRAN_RECIBSU_UnReg(m_tran_recibos, x_usuario, x_setfecha)
			ElseIf m_tran_recibos.Eliminado Then
				d_tran_recibos.TRAN_RECIBSD_UnReg(TRAN_Recibos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_recibos.Nuevo Then
				d_tran_recibos.TRAN_RECIBSI_UnReg(m_tran_recibos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_recibos.Eliminado Then
				d_tran_recibos.TRAN_RECIBSD_UnReg(TRAN_Recibos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Recibos = new List(Of ETRAN_Recibos)()
			return d_tran_recibos.TRAN_RECIBSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_recibos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_recibos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_recibos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_recibos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

