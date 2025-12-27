Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_Rutas

#Region " Variables "
	
	Private m_tran_rutas As ETRAN_Rutas
	Private m_listTRAN_Rutas As List(Of ETRAN_Rutas)
	Private m_dtTRAN_Rutas As DataTable

	Private m_dsTRAN_Rutas As DataSet
	Private d_tran_rutas As DTRAN_Rutas 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_rutas = New DTRAN_Rutas()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_Rutas() As ETRAN_Rutas 
		Get
			return m_tran_rutas
		End Get
		Set(ByVal value As ETRAN_Rutas)
			m_tran_rutas = value
		End Set
	End Property
	Public Property ListTRAN_Rutas() As List(Of ETRAN_Rutas)
		Get
			return m_listTRAN_Rutas
		End Get
		Set(ByVal value As List(Of ETRAN_Rutas))
			m_listTRAN_Rutas = value
		End Set
	End Property
	Public Property DTTRAN_Rutas() As DataTable
		Get
			return m_dtTRAN_Rutas
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_Rutas = value
		End Set
	End Property
	Public Property DSTRAN_Rutas() As DataSet
		Get
			return m_dsTRAN_Rutas
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_Rutas = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_Rutas() As List(Of ETRAN_Rutas)
			Return Me.m_listTRAN_Rutas
		End Function
		Public Sub setListTRAN_Rutas(ByVal _listtran_rutas As List (Of ETRAN_Rutas))
			Me.m_listTRAN_Rutas = m_listtran_rutas 
		End Sub
		Public Function getTRAN_Rutas() As ETRAN_Rutas
			Return Me.m_tran_rutas
		End Function
		Public Sub setTRAN_Rutas(ByVal x_tran_rutas As ETRAN_Rutas)
			Me.m_tran_rutas = x_tran_rutas 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_Rutas = new List(Of ETRAN_Rutas)()
			return d_tran_rutas.TRAN_RUTASSS_Todos(m_listTRAN_Rutas)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Rutas = new List(Of ETRAN_Rutas)()
			return d_tran_rutas.TRAN_RUTASSS_Todos(m_listTRAN_Rutas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Rutas = new List(Of ETRAN_Rutas)()
			return d_tran_rutas.TRAN_RUTASSS_Todos(m_listTRAN_Rutas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_Rutas = new List(Of ETRAN_Rutas)()
			return d_tran_rutas.TRAN_RUTASSS_Todos(m_listTRAN_Rutas, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Rutas = new DataSet()
			return d_tran_rutas.TRAN_RUTASSS_Todos(m_dsTRAN_Rutas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Rutas = new DataSet()
			return d_tran_rutas.TRAN_RUTASSS_Todos(m_dsTRAN_Rutas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Rutas = new DataSet()
			Dim _opcion As Boolean = d_tran_rutas.TRAN_RUTASSS_Todos(m_dsTRAN_Rutas, x_where)
		If _opcion Then
			m_dtTRAN_Rutas = m_dsTRAN_Rutas.Tables(0)
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
			m_dsTRAN_Rutas = new DataSet()
			Dim _opcion As Boolean = d_tran_rutas.TRAN_RUTASSS_Todos(m_dsTRAN_Rutas, x_join, x_where)
		If _opcion Then
			m_dtTRAN_Rutas = m_dsTRAN_Rutas.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_rutas_id As Long) As Boolean
		Try
			m_tran_rutas = New ETRAN_Rutas()
			Return d_tran_rutas.TRAN_RUTASSS_UnReg(m_tran_rutas, x_rutas_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_rutas = New ETRAN_Rutas()
			Return d_tran_rutas.TRAN_RUTASSS_UnReg(m_tran_rutas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_rutas = New ETRAN_Rutas()
			Return d_tran_rutas.TRAN_RUTASSS_UnReg(m_tran_rutas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_rutas.Nuevo Then
				d_tran_rutas.TRAN_RUTASSI_UnReg(m_tran_rutas, x_usuario)
			ElseIf m_tran_rutas.Modificado Then
				d_tran_rutas.TRAN_RUTASSU_UnReg(m_tran_rutas, x_usuario)
			ElseIf m_tran_rutas.Eliminado Then
				d_tran_rutas.TRAN_RUTASSD_UnReg(m_tran_rutas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_rutas.Nuevo Then
				d_tran_rutas.TRAN_RUTASSI_UnReg(m_tran_rutas, x_usuario)
			ElseIf m_tran_rutas.Modificado Then
				d_tran_rutas.TRAN_RUTASSU_UnReg(m_tran_rutas, x_where, x_usuario)
			ElseIf m_tran_rutas.Eliminado Then
				d_tran_rutas.TRAN_RUTASSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_rutas.Nuevo Then
				d_tran_rutas.TRAN_RUTASSI_UnReg(m_tran_rutas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_rutas.Modificado Then
				d_tran_rutas.TRAN_RUTASSU_UnReg(m_tran_rutas, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_rutas.Eliminado Then
				d_tran_rutas.TRAN_RUTASSD_UnReg(m_tran_rutas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_rutas.Nuevo Then
				d_tran_rutas.TRAN_RUTASSI_UnReg(m_tran_rutas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_rutas.Modificado Then
				d_tran_rutas.TRAN_RUTASSU_UnReg(m_tran_rutas, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_rutas.Eliminado Then
				d_tran_rutas.TRAN_RUTASSD_UnReg(m_tran_rutas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_rutas.Nuevo Then
				d_tran_rutas.TRAN_RUTASSI_UnReg(m_tran_rutas, x_usuario, x_setfecha)
			ElseIf m_tran_rutas.Modificado Then
				d_tran_rutas.TRAN_RUTASSU_UnReg(m_tran_rutas, x_usuario, x_setfecha)
			ElseIf m_tran_rutas.Eliminado Then
				d_tran_rutas.TRAN_RUTASSD_UnReg(m_tran_rutas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_rutas.Nuevo Then
				d_tran_rutas.TRAN_RUTASSI_UnReg(m_tran_rutas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_rutas.Eliminado Then
				d_tran_rutas.TRAN_RUTASSD_UnReg(m_tran_rutas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Rutas = new List(Of ETRAN_Rutas)()
			return d_tran_rutas.TRAN_RUTASSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_rutas.getCorrelativo("RUTAS_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_rutas.getCorrelativo("RUTAS_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_rutas.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_rutas.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_rutas.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_rutas.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

