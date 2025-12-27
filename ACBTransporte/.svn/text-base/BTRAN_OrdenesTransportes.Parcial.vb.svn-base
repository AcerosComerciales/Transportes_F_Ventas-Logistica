Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_OrdenesTransportes

#Region " Variables "
	
	Private m_tran_ordenestransportes As ETRAN_OrdenesTransportes
	Private m_listTRAN_OrdenesTransportes As List(Of ETRAN_OrdenesTransportes)
	Private m_dtTRAN_OrdenesTransportes As DataTable

	Private m_dsTRAN_OrdenesTransportes As DataSet
	Private d_tran_ordenestransportes As DTRAN_OrdenesTransportes 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_ordenestransportes = New DTRAN_OrdenesTransportes()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_OrdenesTransportes() As ETRAN_OrdenesTransportes 
		Get
			return m_tran_ordenestransportes
		End Get
		Set(ByVal value As ETRAN_OrdenesTransportes)
			m_tran_ordenestransportes = value
		End Set
	End Property
	Public Property ListTRAN_OrdenesTransportes() As List(Of ETRAN_OrdenesTransportes)
		Get
			return m_listTRAN_OrdenesTransportes
		End Get
		Set(ByVal value As List(Of ETRAN_OrdenesTransportes))
			m_listTRAN_OrdenesTransportes = value
		End Set
	End Property
	Public Property DTTRAN_OrdenesTransportes() As DataTable
		Get
			return m_dtTRAN_OrdenesTransportes
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_OrdenesTransportes = value
		End Set
	End Property
	Public Property DSTRAN_OrdenesTransportes() As DataSet
		Get
			return m_dsTRAN_OrdenesTransportes
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_OrdenesTransportes = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_OrdenesTransportes() As List(Of ETRAN_OrdenesTransportes)
			Return Me.m_listTRAN_OrdenesTransportes
		End Function
		Public Sub setListTRAN_OrdenesTransportes(ByVal _listtran_ordenestransportes As List (Of ETRAN_OrdenesTransportes))
			Me.m_listTRAN_OrdenesTransportes = m_listtran_ordenestransportes 
		End Sub
		Public Function getTRAN_OrdenesTransportes() As ETRAN_OrdenesTransportes
			Return Me.m_tran_ordenestransportes
		End Function
		Public Sub setTRAN_OrdenesTransportes(ByVal x_tran_ordenestransportes As ETRAN_OrdenesTransportes)
			Me.m_tran_ordenestransportes = x_tran_ordenestransportes 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_OrdenesTransportes = new List(Of ETRAN_OrdenesTransportes)()
			return d_tran_ordenestransportes.TRAN_ORDTRSS_Todos(m_listTRAN_OrdenesTransportes)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_OrdenesTransportes = new List(Of ETRAN_OrdenesTransportes)()
			return d_tran_ordenestransportes.TRAN_ORDTRSS_Todos(m_listTRAN_OrdenesTransportes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_OrdenesTransportes = new List(Of ETRAN_OrdenesTransportes)()
			return d_tran_ordenestransportes.TRAN_ORDTRSS_Todos(m_listTRAN_OrdenesTransportes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_OrdenesTransportes = new List(Of ETRAN_OrdenesTransportes)()
			return d_tran_ordenestransportes.TRAN_ORDTRSS_Todos(m_listTRAN_OrdenesTransportes, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_OrdenesTransportes = new DataSet()
			return d_tran_ordenestransportes.TRAN_ORDTRSS_Todos(m_dsTRAN_OrdenesTransportes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_OrdenesTransportes = new DataSet()
			return d_tran_ordenestransportes.TRAN_ORDTRSS_Todos(m_dsTRAN_OrdenesTransportes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_OrdenesTransportes = new DataSet()
			Dim _opcion As Boolean = d_tran_ordenestransportes.TRAN_ORDTRSS_Todos(m_dsTRAN_OrdenesTransportes, x_where)
		If _opcion Then
			m_dtTRAN_OrdenesTransportes = m_dsTRAN_OrdenesTransportes.Tables(0)
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
			m_dsTRAN_OrdenesTransportes = new DataSet()
			Dim _opcion As Boolean = d_tran_ordenestransportes.TRAN_ORDTRSS_Todos(m_dsTRAN_OrdenesTransportes, x_join, x_where)
		If _opcion Then
			m_dtTRAN_OrdenesTransportes = m_dsTRAN_OrdenesTransportes.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_ordtr_codigo As String) As Boolean
		Try
			m_tran_ordenestransportes = New ETRAN_OrdenesTransportes()
			Return d_tran_ordenestransportes.TRAN_ORDTRSS_UnReg(m_tran_ordenestransportes, x_ordtr_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_ordenestransportes = New ETRAN_OrdenesTransportes()
			Return d_tran_ordenestransportes.TRAN_ORDTRSS_UnReg(m_tran_ordenestransportes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_ordenestransportes = New ETRAN_OrdenesTransportes()
			Return d_tran_ordenestransportes.TRAN_ORDTRSS_UnReg(m_tran_ordenestransportes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_ordenestransportes.Nuevo Then
				d_tran_ordenestransportes.TRAN_ORDTRSI_UnReg(m_tran_ordenestransportes, x_usuario)
			ElseIf m_tran_ordenestransportes.Modificado Then
				d_tran_ordenestransportes.TRAN_ORDTRSU_UnReg(m_tran_ordenestransportes, x_usuario)
			ElseIf m_tran_ordenestransportes.Eliminado Then
				d_tran_ordenestransportes.TRAN_ORDTRSD_UnReg(m_tran_ordenestransportes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_ordenestransportes.Nuevo Then
				d_tran_ordenestransportes.TRAN_ORDTRSI_UnReg(m_tran_ordenestransportes, x_usuario)
			ElseIf m_tran_ordenestransportes.Modificado Then
				d_tran_ordenestransportes.TRAN_ORDTRSU_UnReg(m_tran_ordenestransportes, x_where, x_usuario)
			ElseIf m_tran_ordenestransportes.Eliminado Then
				d_tran_ordenestransportes.TRAN_ORDTRSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_ordenestransportes.Nuevo Then
				d_tran_ordenestransportes.TRAN_ORDTRSI_UnReg(m_tran_ordenestransportes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_ordenestransportes.Modificado Then
				d_tran_ordenestransportes.TRAN_ORDTRSU_UnReg(m_tran_ordenestransportes, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_ordenestransportes.Eliminado Then
				d_tran_ordenestransportes.TRAN_ORDTRSD_UnReg(m_tran_ordenestransportes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_ordenestransportes.Nuevo Then
				d_tran_ordenestransportes.TRAN_ORDTRSI_UnReg(m_tran_ordenestransportes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_ordenestransportes.Modificado Then
				d_tran_ordenestransportes.TRAN_ORDTRSU_UnReg(m_tran_ordenestransportes, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_ordenestransportes.Eliminado Then
				d_tran_ordenestransportes.TRAN_ORDTRSD_UnReg(m_tran_ordenestransportes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_ordenestransportes.Nuevo Then
				d_tran_ordenestransportes.TRAN_ORDTRSI_UnReg(m_tran_ordenestransportes, x_usuario, x_setfecha)
			ElseIf m_tran_ordenestransportes.Modificado Then
				d_tran_ordenestransportes.TRAN_ORDTRSU_UnReg(m_tran_ordenestransportes, x_usuario, x_setfecha)
			ElseIf m_tran_ordenestransportes.Eliminado Then
				d_tran_ordenestransportes.TRAN_ORDTRSD_UnReg(m_tran_ordenestransportes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_ordenestransportes.Nuevo Then
				d_tran_ordenestransportes.TRAN_ORDTRSI_UnReg(m_tran_ordenestransportes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_ordenestransportes.Eliminado Then
				d_tran_ordenestransportes.TRAN_ORDTRSD_UnReg(m_tran_ordenestransportes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_OrdenesTransportes = new List(Of ETRAN_OrdenesTransportes)()
			return d_tran_ordenestransportes.TRAN_ORDTRSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_ordenestransportes.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_ordenestransportes.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_ordenestransportes.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_ordenestransportes.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

